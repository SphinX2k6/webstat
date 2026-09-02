using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002821 RID: 10273
[NullableContext(1)]
[Nullable(0)]
public class ObtainedRoleDevRoleDetailItemData
{
	// Token: 0x060144C4 RID: 83140 RVA: 0x005A6418 File Offset: 0x005A4618
	public void InitByRoleId(int roleId)
	{
		this.DetailItemsInternal.Clear();
		RoleDataBase roleData = this.GetRoleData(roleId);
		if (roleData == null)
		{
			return;
		}
		RoleLevelData levelData = roleData.GetLevelData();
		int level = levelData.GetLevel();
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(roleId);
		if (cultivateProject == null)
		{
			return;
		}
		int roleLevel = cultivateProject.Value.RoleLevel;
		int breachLevel = levelData.GetBreachLevel();
		int roleBreachLevel = cultivateProject.Value.RoleBreachLevel;
		this.CollectUpgradeItems(roleId, level, roleLevel);
		this.CollectBreachItems(roleId, breachLevel, roleBreachLevel);
	}

	// Token: 0x060144C5 RID: 83141 RVA: 0x005A649C File Offset: 0x005A469C
	[NullableContext(2)]
	private RoleDataBase GetRoleData(int roleId)
	{
		return ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
	}

	// Token: 0x060144C6 RID: 83142 RVA: 0x005A64AC File Offset: 0x005A46AC
	private void CollectUpgradeItems(int roleId, int currentLevel, int targetLevel)
	{
		global::IRoleDevDetailItemData roleDevDetailItemData = this.CreateRoleExpItemDetailData(roleId, currentLevel, targetLevel);
		if (roleDevDetailItemData != null)
		{
			this.DetailItemsInternal.Add(roleDevDetailItemData);
		}
	}

	// Token: 0x060144C7 RID: 83143 RVA: 0x005A64D4 File Offset: 0x005A46D4
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

	// Token: 0x060144C8 RID: 83144 RVA: 0x005A6534 File Offset: 0x005A4734
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

	// Token: 0x060144C9 RID: 83145 RVA: 0x005A656C File Offset: 0x005A476C
	private int CalculateTotalNeedExp(int roleId, int currentLevel, int targetLevel)
	{
		int num = 0;
		RoleDataBase roleData = this.GetRoleData(roleId);
		if (roleData == null)
		{
			return 0;
		}
		int exp = roleData.GetLevelData().GetExp();
		for (int i = currentLevel + 1; i <= targetLevel; i++)
		{
			num += ModelBase<RoleModel>.Instance.GetRoleLevelUpExp(roleId, i);
		}
		int num2 = this.CalculateBreachOverflowExp(roleId);
		num += num2;
		return num - exp;
	}

	// Token: 0x060144CA RID: 83146 RVA: 0x005A65C8 File Offset: 0x005A47C8
	private int CalculateBreachOverflowExp(int roleId)
	{
		RoleDataBase roleData = this.GetRoleData(roleId);
		if (roleData == null)
		{
			return 0;
		}
		int breachLevel = roleData.GetLevelData().GetBreachLevel();
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(roleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		int num = cultivateProject.Value.RoleBreachLevel - breachLevel;
		if (num <= 0)
		{
			return 0;
		}
		RoleDevCulProjectConfig? roleDevCulProjectConfig;
		int num2 = (ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig() != null) ? roleDevCulProjectConfig.GetValueOrDefault().OverflowExperience : 1;
		return num * num2;
	}

	// Token: 0x060144CB RID: 83147 RVA: 0x005A6648 File Offset: 0x005A4848
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

	// Token: 0x060144CC RID: 83148 RVA: 0x005A66AB File Offset: 0x005A48AB
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

	// Token: 0x060144CD RID: 83149 RVA: 0x005A66D4 File Offset: 0x005A48D4
	private global::IRoleDevDetailItemData BuildExpItemDetailData(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		return RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Role)[0];
	}

	// Token: 0x060144CE RID: 83150 RVA: 0x005A66F8 File Offset: 0x005A48F8
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

	// Token: 0x060144CF RID: 83151 RVA: 0x005A6724 File Offset: 0x005A4924
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

	// Token: 0x060144D0 RID: 83152 RVA: 0x005A67E8 File Offset: 0x005A49E8
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

	// Token: 0x060144D1 RID: 83153 RVA: 0x005A6864 File Offset: 0x005A4A64
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

	// Token: 0x060144D2 RID: 83154 RVA: 0x005A6894 File Offset: 0x005A4A94
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

	// Token: 0x060144D3 RID: 83155 RVA: 0x005A68DC File Offset: 0x005A4ADC
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

	// Token: 0x060144D4 RID: 83156 RVA: 0x005A6950 File Offset: 0x005A4B50
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

	// Token: 0x060144D5 RID: 83157 RVA: 0x005A69B0 File Offset: 0x005A4BB0
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

	// Token: 0x17001A2F RID: 6703
	// (get) Token: 0x060144D6 RID: 83158 RVA: 0x005A69DD File Offset: 0x005A4BDD
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.DetailItemsInternal;
		}
	}

	// Token: 0x04009DA5 RID: 40357
	private List<global::IRoleDevDetailItemData> DetailItemsInternal = new List<global::IRoleDevDetailItemData>();
}
