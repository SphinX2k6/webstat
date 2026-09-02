using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200281F RID: 10271
[NullableContext(1)]
[Nullable(0)]
public class NotObtainedRoleDevRoleDetailItemData
{
	// Token: 0x060144A2 RID: 83106 RVA: 0x005A5D34 File Offset: 0x005A3F34
	public void InitByRoleId(int roleId)
	{
		this.DetailItemsInternal.Clear();
		int currentLevel = 1;
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(roleId);
		if (cultivateProject == null)
		{
			return;
		}
		int roleLevel = cultivateProject.Value.RoleLevel;
		int currentBreachLevel = 0;
		int roleBreachLevel = cultivateProject.Value.RoleBreachLevel;
		this.CollectUpgradeItems(roleId, currentLevel, roleLevel);
		this.CollectBreachItems(roleId, currentBreachLevel, roleBreachLevel);
	}

	// Token: 0x060144A3 RID: 83107 RVA: 0x005A5D98 File Offset: 0x005A3F98
	private void CollectUpgradeItems(int roleId, int currentLevel, int targetLevel)
	{
		global::IRoleDevDetailItemData roleDevDetailItemData = this.CreateRoleExpItemDetailData(roleId, currentLevel, targetLevel);
		if (roleDevDetailItemData != null)
		{
			this.DetailItemsInternal.Add(roleDevDetailItemData);
		}
	}

	// Token: 0x060144A4 RID: 83108 RVA: 0x005A5DC0 File Offset: 0x005A3FC0
	private void CollectBreachItems(int roleId, int currentBreachLevel, int targetBreachLevel)
	{
		List<global::IRoleDevDetailItemData> list = this.CreateRoleBreachItemDetailData(roleId, currentBreachLevel, targetBreachLevel);
		if (list != null)
		{
			foreach (global::IRoleDevDetailItemData item in list)
			{
				this.DetailItemsInternal.Add(item);
			}
		}
	}

	// Token: 0x060144A5 RID: 83109 RVA: 0x005A5E20 File Offset: 0x005A4020
	[NullableContext(2)]
	private global::IRoleDevDetailItemData CreateRoleExpItemDetailData(int roleId, int currentLevel, int targetLevel)
	{
		if (currentLevel >= targetLevel)
		{
			return null;
		}
		int totalNeedExp = this.CalculateTotalNeedExp(roleId, currentLevel, targetLevel);
		List<ValueTuple<int, int>> sortedExpItemList = this.GetSortedExpItemList();
		List<global::IItemMaterial> totalMaterials = this.CalcRoleExpMaterials(sortedExpItemList, totalNeedExp);
		return this.BuildExpItemDetailData(roleId, totalMaterials);
	}

	// Token: 0x060144A6 RID: 83110 RVA: 0x005A5E58 File Offset: 0x005A4058
	private int CalculateTotalNeedExp(int roleId, int currentLevel, int targetLevel)
	{
		int num = 0;
		for (int i = currentLevel; i <= targetLevel; i++)
		{
			num += ModelBase<RoleModel>.Instance.GetRoleLevelUpExp(roleId, i);
		}
		return num;
	}

	// Token: 0x060144A7 RID: 83111 RVA: 0x005A5E84 File Offset: 0x005A4084
	[return: TupleElementNames(new string[]
	{
		"ItemId",
		"Count"
	})]
	[return: Nullable(new byte[]
	{
		1,
		0
	})]
	private List<ValueTuple<int, int>> GetSortedExpItemList()
	{
		List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
		foreach (ItemInfo itemInfo in ModelBase<RoleModel>.Instance.GetRoleCostExpList())
		{
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(itemInfo.Id, 0);
			list.Add(new ValueTuple<int, int>(itemInfo.Id, commonItemCount));
		}
		return this.SortExpItemsByQuality(list);
	}

	// Token: 0x060144A8 RID: 83112 RVA: 0x005A5EE7 File Offset: 0x005A40E7
	[return: TupleElementNames(new string[]
	{
		"ItemId",
		"Count"
	})]
	[return: Nullable(new byte[]
	{
		1,
		0
	})]
	private List<ValueTuple<int, int>> SortExpItemsByQuality([TupleElementNames(new string[]
	{
		"ItemId",
		"Count"
	})] [Nullable(new byte[]
	{
		1,
		0
	})] List<ValueTuple<int, int>> expItemList)
	{
		expItemList.Sort(delegate([TupleElementNames(new string[]
		{
			"ItemId",
			"Count"
		})] ValueTuple<int, int> a, [TupleElementNames(new string[]
		{
			"ItemId",
			"Count"
		})] ValueTuple<int, int> b)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.Item1);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.Item1);
			int num = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			int num2 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			return num - num2;
		});
		return expItemList;
	}

	// Token: 0x060144A9 RID: 83113 RVA: 0x005A5F10 File Offset: 0x005A4110
	private global::IRoleDevDetailItemData BuildExpItemDetailData(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		return RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Role)[0];
	}

	// Token: 0x060144AA RID: 83114 RVA: 0x005A5F34 File Offset: 0x005A4134
	private List<global::IItemMaterial> CalcRoleExpMaterials([TupleElementNames(new string[]
	{
		"ItemId",
		"Count"
	})] [Nullable(new byte[]
	{
		1,
		0
	})] List<ValueTuple<int, int>> expItemList, int totalNeedExp)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		int accumulatedExp = 0;
		accumulatedExp = this.UseExistingExpItems(expItemList, totalNeedExp, list, accumulatedExp);
		this.AddHighestQualityExpItemsIfNeeded(expItemList, totalNeedExp, list, accumulatedExp);
		return list;
	}

	// Token: 0x060144AB RID: 83115 RVA: 0x005A5F60 File Offset: 0x005A4160
	private int UseExistingExpItems([TupleElementNames(new string[]
	{
		"ItemId",
		"Count"
	})] [Nullable(new byte[]
	{
		1,
		0
	})] List<ValueTuple<int, int>> expItemList, int totalNeedExp, List<global::IItemMaterial> totalMaterials, int accumulatedExp)
	{
		int num = accumulatedExp;
		foreach (ValueTuple<int, int> valueTuple in expItemList)
		{
			if (num >= totalNeedExp)
			{
				break;
			}
			int? roleExpItemExp = ModelBase<RoleModel>.Instance.GetRoleExpItemExp(valueTuple.Item1);
			if (roleExpItemExp != null)
			{
				int value = roleExpItemExp.Value;
				int num2 = Math.Min((int)Math.Ceiling((double)(totalNeedExp - num) / (double)value), valueTuple.Item2);
				if (num2 > 0)
				{
					totalMaterials.Add(new global::ItemMaterial
					{
						ItemId = valueTuple.Item1,
						RequiredCount = num2
					});
					num += num2 * value;
				}
			}
		}
		return num;
	}

	// Token: 0x060144AC RID: 83116 RVA: 0x005A6024 File Offset: 0x005A4224
	private void AddHighestQualityExpItemsIfNeeded([TupleElementNames(new string[]
	{
		"ItemId",
		"Count"
	})] [Nullable(new byte[]
	{
		1,
		0
	})] List<ValueTuple<int, int>> expItemList, int totalNeedExp, List<global::IItemMaterial> totalMaterials, int accumulatedExp)
	{
		if (accumulatedExp >= totalNeedExp)
		{
			return;
		}
		if (expItemList.Count == 0)
		{
			return;
		}
		ValueTuple<int, int> valueTuple = expItemList[expItemList.Count - 1];
		int? roleExpItemExp = ModelBase<RoleModel>.Instance.GetRoleExpItemExp(valueTuple.Item1);
		if (roleExpItemExp == null)
		{
			return;
		}
		int value = roleExpItemExp.Value;
		int requiredCount = (int)Math.Ceiling((double)(totalNeedExp - accumulatedExp) / (double)value);
		totalMaterials.Add(new global::ItemMaterial
		{
			ItemId = valueTuple.Item1,
			RequiredCount = requiredCount
		});
	}

	// Token: 0x060144AD RID: 83117 RVA: 0x005A60A0 File Offset: 0x005A42A0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevDetailItemData> CreateRoleBreachItemDetailData(int roleId, int currentBreachLevel, int targetBreachLevel)
	{
		if (currentBreachLevel >= targetBreachLevel)
		{
			return null;
		}
		List<global::IItemMaterial> list = this.CalculateBreachMaterials(roleId, currentBreachLevel, targetBreachLevel);
		if (list.Count == 0)
		{
			return null;
		}
		return this.BuildBreachDetailItems(roleId, list);
	}

	// Token: 0x060144AE RID: 83118 RVA: 0x005A60D0 File Offset: 0x005A42D0
	private List<global::IItemMaterial> CalculateBreachMaterials(int roleId, int currentBreachLevel, int targetBreachLevel)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		for (int i = currentBreachLevel + 1; i <= targetBreachLevel; i++)
		{
			RoleBreach? roleBreachConfig = ConfigBase<RoleConfig>.Instance.GetRoleBreachConfig(roleId, i);
			if (roleBreachConfig != null)
			{
				this.AddBreachLevelMaterials(roleBreachConfig.Value, list);
			}
		}
		return list;
	}

	// Token: 0x060144AF RID: 83119 RVA: 0x005A6118 File Offset: 0x005A4318
	private void AddBreachLevelMaterials(RoleBreach breakConfig, List<global::IItemMaterial> totalMaterials)
	{
		Dictionary<int, int> dictionary = breakConfig.BreachConsume();
		if (dictionary == null)
		{
			return;
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			if (key != 2)
			{
				int value = keyValuePair.Value;
				this.AddOrUpdateMaterial(totalMaterials, key, value);
			}
		}
	}

	// Token: 0x060144B0 RID: 83120 RVA: 0x005A618C File Offset: 0x005A438C
	private void AddOrUpdateMaterial(List<global::IItemMaterial> totalMaterials, int itemId, int count)
	{
		global::IItemMaterial itemMaterial = totalMaterials.Find((global::IItemMaterial m) => m.ItemId == itemId);
		if (itemMaterial != null)
		{
			itemMaterial.RequiredCount += count;
			return;
		}
		totalMaterials.Add(new global::ItemMaterial
		{
			ItemId = itemId,
			RequiredCount = count
		});
	}

	// Token: 0x060144B1 RID: 83121 RVA: 0x005A61EC File Offset: 0x005A43EC
	private List<global::IRoleDevDetailItemData> BuildBreachDetailItems(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		List<global::IRoleDevDetailItemData> list = RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Role);
		if (list.Count <= 0)
		{
			return new List<global::IRoleDevDetailItemData>();
		}
		return list;
	}

	// Token: 0x17001A2D RID: 6701
	// (get) Token: 0x060144B2 RID: 83122 RVA: 0x005A6219 File Offset: 0x005A4419
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.DetailItemsInternal;
		}
	}

	// Token: 0x04009DA1 RID: 40353
	private List<global::IRoleDevDetailItemData> DetailItemsInternal = new List<global::IRoleDevDetailItemData>();
}
