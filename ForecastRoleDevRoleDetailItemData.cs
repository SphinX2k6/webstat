using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x0200281D RID: 10269
[NullableContext(1)]
[Nullable(0)]
public class ForecastRoleDevRoleDetailItemData
{
	// Token: 0x06014480 RID: 83072 RVA: 0x005A568F File Offset: 0x005A388F
	public void InitByRoleId(int roleId)
	{
		this.DetailItemsInternal.Clear();
		this.AddExpItemDetails(roleId);
		this.AddBreachItemDetails(roleId);
	}

	// Token: 0x06014481 RID: 83073 RVA: 0x005A56AC File Offset: 0x005A38AC
	private void AddExpItemDetails(int roleId)
	{
		global::IRoleDevDetailItemData roleDevDetailItemData = this.CreateForecastRoleExpItemDetailData(roleId);
		if (roleDevDetailItemData != null)
		{
			this.DetailItemsInternal.Add(roleDevDetailItemData);
		}
	}

	// Token: 0x06014482 RID: 83074 RVA: 0x005A56D0 File Offset: 0x005A38D0
	private void AddBreachItemDetails(int roleId)
	{
		List<global::IRoleDevDetailItemData> list = this.CreateForecastRoleBreachItemDetailData(roleId);
		if (list != null)
		{
			foreach (global::IRoleDevDetailItemData item in list)
			{
				this.DetailItemsInternal.Add(item);
			}
		}
	}

	// Token: 0x06014483 RID: 83075 RVA: 0x005A5730 File Offset: 0x005A3930
	[NullableContext(2)]
	private global::IRoleDevDetailItemData CreateForecastRoleExpItemDetailData(int roleId)
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = this.GetRoleDevProsProjectConfig(roleId);
		if (roleDevProsProjectConfig == null)
		{
			return null;
		}
		int roleExperience = roleDevProsProjectConfig.RoleExperience;
		if (roleExperience <= 0)
		{
			return null;
		}
		List<ValueTuple<int, int>> sortedExpItemList = this.GetSortedExpItemList();
		List<global::IItemMaterial> list = this.CalcRoleExpMaterials(sortedExpItemList, roleExperience);
		if (list.Count == 0)
		{
			return null;
		}
		return this.BuildExpItemDetailData(roleId, list);
	}

	// Token: 0x06014484 RID: 83076 RVA: 0x005A577C File Offset: 0x005A397C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevDetailItemData> CreateForecastRoleBreachItemDetailData(int roleId)
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = this.GetRoleDevProsProjectConfig(roleId);
		if (roleDevProsProjectConfig == null)
		{
			return null;
		}
		List<RoleDevProsRoleItem> roleItemGroups = this.GetRoleItemGroups(roleDevProsProjectConfig);
		if (roleItemGroups.Count == 0)
		{
			return null;
		}
		return this.BuildBreachDetailItems(roleId, roleItemGroups);
	}

	// Token: 0x06014485 RID: 83077 RVA: 0x005A57B0 File Offset: 0x005A39B0
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
		accumulatedExp = this.UseExistingItems(expItemList, totalNeedExp, list, accumulatedExp);
		this.AddHighestQualityItemsIfNeeded(expItemList, totalNeedExp, list, accumulatedExp);
		return list;
	}

	// Token: 0x06014486 RID: 83078 RVA: 0x005A57DB File Offset: 0x005A39DB
	[NullableContext(2)]
	private IRoleDevProsProjectConfig GetRoleDevProsProjectConfig(int roleId)
	{
		return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId);
	}

	// Token: 0x06014487 RID: 83079 RVA: 0x005A57E8 File Offset: 0x005A39E8
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

	// Token: 0x06014488 RID: 83080 RVA: 0x005A584B File Offset: 0x005A3A4B
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

	// Token: 0x06014489 RID: 83081 RVA: 0x005A5874 File Offset: 0x005A3A74
	private global::IRoleDevDetailItemData BuildExpItemDetailData(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		return RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Role)[0];
	}

	// Token: 0x0601448A RID: 83082 RVA: 0x005A5898 File Offset: 0x005A3A98
	private int UseExistingItems([TupleElementNames(new string[]
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

	// Token: 0x0601448B RID: 83083 RVA: 0x005A595C File Offset: 0x005A3B5C
	private void AddHighestQualityItemsIfNeeded([TupleElementNames(new string[]
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

	// Token: 0x0601448C RID: 83084 RVA: 0x005A59D8 File Offset: 0x005A3BD8
	private List<RoleDevProsRoleItem> GetRoleItemGroups(IRoleDevProsProjectConfig roleDevProsListConfig)
	{
		List<RoleDevProsRoleItem> list = new List<RoleDevProsRoleItem>();
		foreach (int itemGroupId in roleDevProsListConfig.RoleItemGroup)
		{
			RoleDevProsRoleItem? roleDevProsRoleItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsRoleItemConfig(itemGroupId);
			if (roleDevProsRoleItemConfig != null)
			{
				list.Add(roleDevProsRoleItemConfig.Value);
			}
		}
		return list;
	}

	// Token: 0x0601448D RID: 83085 RVA: 0x005A5A50 File Offset: 0x005A3C50
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevDetailItemData> BuildBreachDetailItems(int roleId, List<RoleDevProsRoleItem> roleItemGroups)
	{
		List<global::IRoleDevDetailItemData> list = new List<global::IRoleDevDetailItemData>();
		foreach (RoleDevProsRoleItem group in roleItemGroups)
		{
			List<global::IItemMaterial> list2 = this.ConvertGroupToMaterials(group);
			if (list2.Count > 0)
			{
				foreach (global::IRoleDevDetailItemData item in this.BuildGroupDetailItems(roleId, group, list2))
				{
					list.Add(item);
				}
			}
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}

	// Token: 0x0601448E RID: 83086 RVA: 0x005A5B04 File Offset: 0x005A3D04
	private List<global::IItemMaterial> ConvertGroupToMaterials(RoleDevProsRoleItem group)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		int itemGroupLength = group.ItemGroupLength;
		for (int i = 0; i < itemGroupLength; i++)
		{
			IntPair? intPair = group.ItemGroup(i);
			if (intPair != null)
			{
				int item = intPair.Value.Item1;
				int item2 = intPair.Value.Item2;
				list.Add(new global::ItemMaterial
				{
					ItemId = item,
					RequiredCount = item2
				});
			}
		}
		return list;
	}

	// Token: 0x0601448F RID: 83087 RVA: 0x005A5B80 File Offset: 0x005A3D80
	private List<global::IRoleDevDetailItemData> BuildGroupDetailItems(int roleId, RoleDevProsRoleItem group, List<global::IItemMaterial> materials)
	{
		return RoleDevUtils.BuildDetailItemData(roleId, new List<global::IMaterialGroup>
		{
			new global::MaterialGroup
			{
				Type = group.ItemTypeId,
				Materials = materials
			}
		}, ERoleDevMainPage.Role);
	}

	// Token: 0x17001A2B RID: 6699
	// (get) Token: 0x06014490 RID: 83088 RVA: 0x005A5BBA File Offset: 0x005A3DBA
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.DetailItemsInternal;
		}
	}

	// Token: 0x04009D9F RID: 40351
	private List<global::IRoleDevDetailItemData> DetailItemsInternal = new List<global::IRoleDevDetailItemData>();
}
