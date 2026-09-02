using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x0200282F RID: 10287
[NullableContext(1)]
[Nullable(0)]
public class ForecastRoleDevWeaponDetailItemData
{
	// Token: 0x06014601 RID: 83457 RVA: 0x005AAB80 File Offset: 0x005A8D80
	public void InitByWeaponType(int roleId, int weaponType)
	{
		this.DetailItemsInternal.Clear();
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId);
		if (roleDevProsProjectConfig == null)
		{
			return;
		}
		int weaponExperience = roleDevProsProjectConfig.WeaponExperience;
		if (this.GetWeaponItemConfig(weaponType) == null)
		{
			return;
		}
		this.CollectForecastUpgradeItemsWithExp(roleId, weaponExperience);
		this.CollectForecastBreachItems(roleId);
	}

	// Token: 0x06014602 RID: 83458 RVA: 0x005AABD0 File Offset: 0x005A8DD0
	private RoleDevWeaponItem? GetWeaponItemConfig(int weaponType)
	{
		return ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(weaponType);
	}

	// Token: 0x06014603 RID: 83459 RVA: 0x005AABE0 File Offset: 0x005A8DE0
	private void CollectForecastUpgradeItemsWithExp(int roleId, int totalNeedExp)
	{
		global::IRoleDevDetailItemData roleDevDetailItemData = this.CreateForecastWeaponExpItemDetailDataWithExp(roleId, totalNeedExp);
		if (roleDevDetailItemData != null)
		{
			this.DetailItemsInternal.Add(roleDevDetailItemData);
		}
	}

	// Token: 0x06014604 RID: 83460 RVA: 0x005AAC08 File Offset: 0x005A8E08
	[NullableContext(2)]
	private global::IRoleDevDetailItemData CreateForecastWeaponExpItemDetailDataWithExp(int roleId, int totalNeedExp)
	{
		if (totalNeedExp <= 0)
		{
			return null;
		}
		List<ItemDataBase> sortedExpItemList = this.GetSortedExpItemList();
		List<global::IItemMaterial> list = this.CalcRequiredExpMaterials(sortedExpItemList, totalNeedExp);
		if (list.Count == 0)
		{
			return null;
		}
		return this.BuildExpItemDetailData(roleId, list);
	}

	// Token: 0x06014605 RID: 83461 RVA: 0x005AAC40 File Offset: 0x005A8E40
	private List<ItemDataBase> GetSortedExpItemList()
	{
		List<ItemInfo> weaponExpItemConfigList = ModelBase<WeaponModel>.Instance.GetWeaponExpItemConfigList();
		List<ItemDataBase> list = new List<ItemDataBase>();
		foreach (ItemInfo itemInfo in weaponExpItemConfigList)
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemInfo.Id, 0);
			list.Add(new CommonItemData(itemInfo.Id, -1, itemCountByConfigId, InventoryDefine.EItemDataType.CommonItem, null));
		}
		return this.SortExpItemsByQuality(list);
	}

	// Token: 0x06014606 RID: 83462 RVA: 0x005AACD0 File Offset: 0x005A8ED0
	private List<ItemDataBase> SortExpItemsByQuality(List<ItemDataBase> expItemList)
	{
		expItemList.Sort(delegate(ItemDataBase a, ItemDataBase b)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.GetConfigId());
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.GetConfigId());
			return ((itemConfigData != null) ? itemConfigData.QualityId : 0) - ((itemConfigData2 != null) ? itemConfigData2.QualityId : 0);
		});
		return expItemList;
	}

	// Token: 0x06014607 RID: 83463 RVA: 0x005AACF8 File Offset: 0x005A8EF8
	private global::IRoleDevDetailItemData BuildExpItemDetailData(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		return RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Weapon)[0];
	}

	// Token: 0x06014608 RID: 83464 RVA: 0x005AAD1C File Offset: 0x005A8F1C
	private List<global::IItemMaterial> CalcRequiredExpMaterials(List<ItemDataBase> expItemList, int totalNeedExp)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		int accumulatedExp = 0;
		accumulatedExp = this.UseExistingExpItems(expItemList, totalNeedExp, list, accumulatedExp);
		this.AddHighestQualityExpItemsIfNeeded(expItemList, totalNeedExp, list, accumulatedExp);
		return list;
	}

	// Token: 0x06014609 RID: 83465 RVA: 0x005AAD48 File Offset: 0x005A8F48
	private int UseExistingExpItems(List<ItemDataBase> expItemList, int totalNeedExp, List<global::IItemMaterial> totalMaterials, int accumulatedExp)
	{
		int num = accumulatedExp;
		foreach (ItemDataBase itemDataBase in expItemList)
		{
			if (num >= totalNeedExp)
			{
				break;
			}
			WeaponExpItem? weaponExpItemConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(itemDataBase.GetConfigId());
			if (weaponExpItemConfig != null)
			{
				int basicExp = weaponExpItemConfig.Value.BasicExp;
				int num2 = Math.Min((int)Math.Ceiling((double)(totalNeedExp - num) / (double)basicExp), itemDataBase.GetCount());
				if (num2 > 0)
				{
					totalMaterials.Add(new global::ItemMaterial
					{
						ItemId = itemDataBase.GetConfigId(),
						RequiredCount = num2
					});
					num += num2 * basicExp;
				}
			}
		}
		return num;
	}

	// Token: 0x0601460A RID: 83466 RVA: 0x005AAE18 File Offset: 0x005A9018
	private void AddHighestQualityExpItemsIfNeeded(List<ItemDataBase> expItemList, int totalNeedExp, List<global::IItemMaterial> totalMaterials, int accumulatedExp)
	{
		if (accumulatedExp >= totalNeedExp || expItemList.Count == 0)
		{
			return;
		}
		ItemDataBase itemDataBase = expItemList[expItemList.Count - 1];
		WeaponExpItem? weaponExpItemConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(itemDataBase.GetConfigId());
		if (weaponExpItemConfig == null)
		{
			return;
		}
		int basicExp = weaponExpItemConfig.Value.BasicExp;
		int requiredCount = (int)Math.Ceiling((double)(totalNeedExp - accumulatedExp) / (double)basicExp);
		totalMaterials.Add(new global::ItemMaterial
		{
			ItemId = itemDataBase.GetConfigId(),
			RequiredCount = requiredCount
		});
	}

	// Token: 0x0601460B RID: 83467 RVA: 0x005AAE9C File Offset: 0x005A909C
	private void CollectForecastBreachItems(int roleId)
	{
		List<global::IRoleDevDetailItemData> list = this.CreateForecastWeaponBreachItemDetailData(roleId);
		if (list != null)
		{
			this.DetailItemsInternal.AddRange(list);
		}
	}

	// Token: 0x0601460C RID: 83468 RVA: 0x005AAEC0 File Offset: 0x005A90C0
	[NullableContext(2)]
	private IRoleDevProsProjectConfig GetRoleDevProsProjectConfig(int roleId)
	{
		return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId);
	}

	// Token: 0x0601460D RID: 83469 RVA: 0x005AAED0 File Offset: 0x005A90D0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevDetailItemData> CreateForecastWeaponBreachItemDetailData(int roleId)
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = this.GetRoleDevProsProjectConfig(roleId);
		if (roleDevProsProjectConfig == null)
		{
			return null;
		}
		List<RoleDevProsRoleItem> weaponItemGroups = this.GetWeaponItemGroups(roleDevProsProjectConfig);
		if (weaponItemGroups.Count == 0)
		{
			return null;
		}
		return this.BuildBreachDetailItems(roleId, weaponItemGroups);
	}

	// Token: 0x0601460E RID: 83470 RVA: 0x005AAF04 File Offset: 0x005A9104
	private List<RoleDevProsRoleItem> GetWeaponItemGroups(IRoleDevProsProjectConfig roleDevProsProject)
	{
		List<RoleDevProsRoleItem> list = new List<RoleDevProsRoleItem>();
		foreach (int itemGroupId in roleDevProsProject.WeaponBreachItemGroup)
		{
			RoleDevProsRoleItem? roleDevProsRoleItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsRoleItemConfig(itemGroupId);
			if (roleDevProsRoleItemConfig != null)
			{
				list.Add(roleDevProsRoleItemConfig.Value);
			}
		}
		return list;
	}

	// Token: 0x0601460F RID: 83471 RVA: 0x005AAF7C File Offset: 0x005A917C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevDetailItemData> BuildBreachDetailItems(int roleId, List<RoleDevProsRoleItem> weaponItemGroups)
	{
		List<global::IRoleDevDetailItemData> list = new List<global::IRoleDevDetailItemData>();
		foreach (RoleDevProsRoleItem group in weaponItemGroups)
		{
			List<global::IItemMaterial> list2 = this.ConvertGroupToMaterials(group);
			if (list2.Count > 0)
			{
				List<global::IRoleDevDetailItemData> collection = this.BuildGroupDetailItems(roleId, group, list2);
				list.AddRange(collection);
			}
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}

	// Token: 0x06014610 RID: 83472 RVA: 0x005AAFFC File Offset: 0x005A91FC
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

	// Token: 0x06014611 RID: 83473 RVA: 0x005AB078 File Offset: 0x005A9278
	private List<global::IRoleDevDetailItemData> BuildGroupDetailItems(int roleId, RoleDevProsRoleItem group, List<global::IItemMaterial> materials)
	{
		return RoleDevUtils.BuildDetailItemData(roleId, new List<global::IMaterialGroup>
		{
			new global::MaterialGroup
			{
				Type = group.ItemTypeId,
				Materials = materials
			}
		}, ERoleDevMainPage.Weapon);
	}

	// Token: 0x17001A64 RID: 6756
	// (get) Token: 0x06014612 RID: 83474 RVA: 0x005AB0B2 File Offset: 0x005A92B2
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.DetailItemsInternal;
		}
	}

	// Token: 0x04009DF4 RID: 40436
	private List<global::IRoleDevDetailItemData> DetailItemsInternal = new List<global::IRoleDevDetailItemData>();
}
