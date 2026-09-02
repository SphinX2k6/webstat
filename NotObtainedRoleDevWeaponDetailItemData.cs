using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002833 RID: 10291
[NullableContext(1)]
[Nullable(0)]
public class NotObtainedRoleDevWeaponDetailItemData
{
	// Token: 0x06014637 RID: 83511 RVA: 0x005AB278 File Offset: 0x005A9478
	public void InitByWeaponType(int roleId, int weaponType)
	{
		int currentBreachLevel = 0;
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(roleId);
		if (cultivateProject == null)
		{
			return;
		}
		int targetBreachLevel = cultivateProject.Value.WeaponBreachLevel - 1;
		int totalNeedExp = this.GetTotalNeedExp(weaponType);
		this.DetailItemsInternal.Clear();
		RoleDevWeaponItem? weaponItemConfig = this.GetWeaponItemConfig(weaponType);
		if (weaponItemConfig == null)
		{
			return;
		}
		this.CollectForecastUpgradeItemsWithExp(roleId, totalNeedExp);
		this.CollectForecastBreachItems(roleId, weaponItemConfig.Value, currentBreachLevel, targetBreachLevel);
	}

	// Token: 0x06014638 RID: 83512 RVA: 0x005AB2EC File Offset: 0x005A94EC
	private int GetTotalNeedExp(int weaponType)
	{
		RoleDevWeaponItem? weaponItemConfig = this.GetWeaponItemConfig(weaponType);
		if (weaponItemConfig == null)
		{
			return 0;
		}
		int? num = new int?(RoleDevUtils.GetCurrentProjectNum());
		if (num == null)
		{
			return 0;
		}
		int[] weaponTypeExperienceArray = weaponItemConfig.Value.GetWeaponTypeExperienceArray();
		if (weaponTypeExperienceArray == null || num.Value >= weaponTypeExperienceArray.Length)
		{
			return 0;
		}
		return weaponTypeExperienceArray[num.Value];
	}

	// Token: 0x06014639 RID: 83513 RVA: 0x005AB34D File Offset: 0x005A954D
	private RoleDevWeaponItem? GetWeaponItemConfig(int weaponType)
	{
		return ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(weaponType);
	}

	// Token: 0x0601463A RID: 83514 RVA: 0x005AB35C File Offset: 0x005A955C
	private void CollectForecastUpgradeItemsWithExp(int roleId, int totalNeedExp)
	{
		global::IRoleDevDetailItemData roleDevDetailItemData = this.CreateForecastWeaponExpItemDetailDataWithExp(roleId, totalNeedExp);
		if (roleDevDetailItemData != null)
		{
			this.DetailItemsInternal.Add(roleDevDetailItemData);
		}
	}

	// Token: 0x0601463B RID: 83515 RVA: 0x005AB384 File Offset: 0x005A9584
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

	// Token: 0x0601463C RID: 83516 RVA: 0x005AB3BC File Offset: 0x005A95BC
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

	// Token: 0x0601463D RID: 83517 RVA: 0x005AB44C File Offset: 0x005A964C
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

	// Token: 0x0601463E RID: 83518 RVA: 0x005AB474 File Offset: 0x005A9674
	private global::IRoleDevDetailItemData BuildExpItemDetailData(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		return RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Weapon)[0];
	}

	// Token: 0x0601463F RID: 83519 RVA: 0x005AB498 File Offset: 0x005A9698
	private List<global::IItemMaterial> CalcRequiredExpMaterials(List<ItemDataBase> expItemList, int totalNeedExp)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		int accumulatedExp = 0;
		accumulatedExp = this.UseExistingExpItems(expItemList, totalNeedExp, list, accumulatedExp);
		this.AddHighestQualityExpItemsIfNeeded(expItemList, totalNeedExp, list, accumulatedExp);
		return list;
	}

	// Token: 0x06014640 RID: 83520 RVA: 0x005AB4C4 File Offset: 0x005A96C4
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

	// Token: 0x06014641 RID: 83521 RVA: 0x005AB594 File Offset: 0x005A9794
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

	// Token: 0x06014642 RID: 83522 RVA: 0x005AB618 File Offset: 0x005A9818
	private void CollectForecastBreachItems(int roleId, RoleDevWeaponItem weaponItemConfig, int currentBreachLevel, int targetBreachLevel)
	{
		int weaponItemGroup = weaponItemConfig.WeaponItemGroup;
		if (weaponItemGroup == 0)
		{
			return;
		}
		List<global::IRoleDevDetailItemData> list = this.CreateForecastWeaponBreachItemDetailData(roleId, weaponItemGroup, currentBreachLevel, targetBreachLevel);
		if (list != null)
		{
			foreach (global::IRoleDevDetailItemData item in list)
			{
				this.DetailItemsInternal.Add(item);
			}
		}
	}

	// Token: 0x06014643 RID: 83523 RVA: 0x005AB688 File Offset: 0x005A9888
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevDetailItemData> CreateForecastWeaponBreachItemDetailData(int roleId, int breakGroupId, int currentBreachLevel, int targetBreachLevel)
	{
		if (currentBreachLevel > targetBreachLevel)
		{
			return null;
		}
		List<global::IItemMaterial> list = this.CalculateBreachMaterials(breakGroupId, currentBreachLevel, targetBreachLevel);
		if (list.Count == 0)
		{
			return null;
		}
		return this.BuildBreachDetailItems(roleId, list);
	}

	// Token: 0x06014644 RID: 83524 RVA: 0x005AB6BC File Offset: 0x005A98BC
	private List<global::IItemMaterial> CalculateBreachMaterials(int breakGroupId, int currentBreachLevel, int targetBreachLevel)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		for (int i = currentBreachLevel; i <= targetBreachLevel; i++)
		{
			WeaponBreach? weaponBreach = ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(breakGroupId, i);
			if (weaponBreach != null)
			{
				this.AddBreachLevelMaterials(weaponBreach.Value, list);
			}
		}
		return list;
	}

	// Token: 0x06014645 RID: 83525 RVA: 0x005AB700 File Offset: 0x005A9900
	private void AddBreachLevelMaterials(WeaponBreach breachConfig, List<global::IItemMaterial> materials)
	{
		Dictionary<int, int> dictionary = breachConfig.Consume();
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
				this.AddOrUpdateMaterial(materials, key, value);
			}
		}
	}

	// Token: 0x06014646 RID: 83526 RVA: 0x005AB774 File Offset: 0x005A9974
	private void AddOrUpdateMaterial(List<global::IItemMaterial> materials, int itemId, int count)
	{
		global::IItemMaterial itemMaterial = materials.FirstOrDefault((global::IItemMaterial material) => material.ItemId == itemId);
		if (itemMaterial != null)
		{
			itemMaterial.RequiredCount += count;
			return;
		}
		materials.Add(new global::ItemMaterial
		{
			ItemId = itemId,
			RequiredCount = count
		});
	}

	// Token: 0x06014647 RID: 83527 RVA: 0x005AB7D4 File Offset: 0x005A99D4
	private List<global::IRoleDevDetailItemData> BuildBreachDetailItems(int roleId, List<global::IItemMaterial> materials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(materials);
		List<global::IRoleDevDetailItemData> list = RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Weapon);
		if (list.Count <= 0)
		{
			return new List<global::IRoleDevDetailItemData>();
		}
		return list;
	}

	// Token: 0x17001A65 RID: 6757
	// (get) Token: 0x06014648 RID: 83528 RVA: 0x005AB801 File Offset: 0x005A9A01
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.DetailItemsInternal;
		}
	}

	// Token: 0x04009DFA RID: 40442
	private List<global::IRoleDevDetailItemData> DetailItemsInternal = new List<global::IRoleDevDetailItemData>();
}
