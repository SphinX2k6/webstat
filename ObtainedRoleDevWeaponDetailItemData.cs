using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002837 RID: 10295
[NullableContext(1)]
[Nullable(0)]
public class ObtainedRoleDevWeaponDetailItemData
{
	// Token: 0x0601466E RID: 83566 RVA: 0x005ABAC8 File Offset: 0x005A9CC8
	public void InitByWeaponInstance(int roleId, WeaponInstance weaponInstance)
	{
		this.DetailItemsInternal.Clear();
		int level = weaponInstance.GetLevel();
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(roleId);
		if (cultivateProject == null)
		{
			return;
		}
		int weaponLevel = cultivateProject.Value.WeaponLevel;
		int breachLevel = weaponInstance.GetBreachLevel();
		int targetBreachLevel = cultivateProject.Value.WeaponBreachLevel - 1;
		this.CollectUpgradeItems(roleId, weaponInstance, level, weaponLevel);
		this.CollectBreachItems(roleId, weaponInstance, breachLevel, targetBreachLevel);
	}

	// Token: 0x0601466F RID: 83567 RVA: 0x005ABB3C File Offset: 0x005A9D3C
	private void CollectUpgradeItems(int roleId, WeaponInstance weaponInstance, int currentLevel, int targetLevel)
	{
		global::IRoleDevDetailItemData roleDevDetailItemData = this.CreateWeaponExpItemDetailData(roleId, weaponInstance, currentLevel, targetLevel);
		if (roleDevDetailItemData != null)
		{
			this.DetailItemsInternal.Add(roleDevDetailItemData);
		}
	}

	// Token: 0x06014670 RID: 83568 RVA: 0x005ABB64 File Offset: 0x005A9D64
	private void CollectBreachItems(int roleId, WeaponInstance weaponInstance, int currentBreachLevel, int targetBreachLevel)
	{
		List<global::IRoleDevDetailItemData> list = this.CreateWeaponBreachItemDetailData(roleId, weaponInstance, currentBreachLevel, targetBreachLevel);
		if (list != null)
		{
			foreach (global::IRoleDevDetailItemData item in list)
			{
				this.DetailItemsInternal.Add(item);
			}
		}
	}

	// Token: 0x06014671 RID: 83569 RVA: 0x005ABBC8 File Offset: 0x005A9DC8
	[return: Nullable(2)]
	private global::IRoleDevDetailItemData CreateWeaponExpItemDetailData(int roleId, WeaponInstance weaponInstance, int currentLevel, int targetLevel)
	{
		if (currentLevel >= targetLevel)
		{
			return null;
		}
		int totalNeedExp = this.CalculateTotalNeedExp(weaponInstance, currentLevel, targetLevel);
		List<ItemInfo> sortedExpItemList = this.GetSortedExpItemList();
		List<global::IItemMaterial> list = this.CalcRequiredExpMaterials(sortedExpItemList, totalNeedExp);
		if (list.Count == 0)
		{
			return null;
		}
		return this.BuildExpItemDetailData(roleId, list);
	}

	// Token: 0x06014672 RID: 83570 RVA: 0x005ABC0C File Offset: 0x005A9E0C
	private int CalculateTotalNeedExp(WeaponInstance weaponInstance, int currentLevel, int targetLevel)
	{
		int num = -weaponInstance.GetExp();
		for (int i = currentLevel; i < targetLevel; i++)
		{
			num += weaponInstance.GetLevelExp(i);
		}
		int num2 = this.CalculateBreachOverflowExp(weaponInstance);
		return num + num2;
	}

	// Token: 0x06014673 RID: 83571 RVA: 0x005ABC44 File Offset: 0x005A9E44
	private int CalculateBreachOverflowExp(WeaponInstance weaponInstance)
	{
		int breachLevel = weaponInstance.GetBreachLevel();
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(weaponInstance.GetRoleId());
		if (cultivateProject == null)
		{
			return 0;
		}
		int num = cultivateProject.Value.WeaponBreachLevel - breachLevel;
		if (num <= 0)
		{
			return 0;
		}
		RoleDevCulProjectConfig? roleDevStaticConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig();
		int num2 = (roleDevStaticConfig != null) ? roleDevStaticConfig.GetValueOrDefault().OverflowExperience : 1;
		return num * num2;
	}

	// Token: 0x06014674 RID: 83572 RVA: 0x005ABCB5 File Offset: 0x005A9EB5
	private List<ItemInfo> GetSortedExpItemList()
	{
		List<ItemInfo> weaponExpItemConfigList = ModelBase<WeaponModel>.Instance.GetWeaponExpItemConfigList();
		weaponExpItemConfigList.Sort((ItemInfo a, ItemInfo b) => a.QualityId - b.QualityId);
		return weaponExpItemConfigList;
	}

	// Token: 0x06014675 RID: 83573 RVA: 0x005ABCE8 File Offset: 0x005A9EE8
	private global::IRoleDevDetailItemData BuildExpItemDetailData(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		return RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Weapon)[0];
	}

	// Token: 0x06014676 RID: 83574 RVA: 0x005ABD0C File Offset: 0x005A9F0C
	private List<global::IItemMaterial> CalcRequiredExpMaterials(List<ItemInfo> expItemList, int totalNeedExp)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		int accumulatedExp = 0;
		accumulatedExp = this.UseExistingExpItems(expItemList, totalNeedExp, list, accumulatedExp);
		this.AddHighestQualityExpItemsIfNeeded(expItemList, totalNeedExp, list, accumulatedExp);
		return list;
	}

	// Token: 0x06014677 RID: 83575 RVA: 0x005ABD38 File Offset: 0x005A9F38
	private int UseExistingExpItems(List<ItemInfo> expItemList, int totalNeedExp, List<global::IItemMaterial> totalMaterials, int accumulatedExp)
	{
		int num = accumulatedExp;
		foreach (ItemInfo itemInfo in expItemList)
		{
			if (num >= totalNeedExp)
			{
				break;
			}
			int id = itemInfo.Id;
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(id, 0);
			WeaponExpItem? weaponExpItemConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(id);
			if (weaponExpItemConfig != null)
			{
				int basicExp = weaponExpItemConfig.Value.BasicExp;
				int num2 = Math.Min((int)Math.Ceiling((double)(totalNeedExp - num) / (double)basicExp), commonItemCount);
				if (num2 > 0)
				{
					totalMaterials.Add(new global::ItemMaterial
					{
						ItemId = id,
						RequiredCount = num2
					});
					num += num2 * basicExp;
				}
			}
		}
		return num;
	}

	// Token: 0x06014678 RID: 83576 RVA: 0x005ABE10 File Offset: 0x005AA010
	private void AddHighestQualityExpItemsIfNeeded(List<ItemInfo> expItemList, int totalNeedExp, List<global::IItemMaterial> totalMaterials, int accumulatedExp)
	{
		if (accumulatedExp >= totalNeedExp || expItemList.Count == 0)
		{
			return;
		}
		ItemInfo itemInfo = expItemList[expItemList.Count - 1];
		WeaponExpItem? weaponExpItemConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(itemInfo.Id);
		if (weaponExpItemConfig == null)
		{
			return;
		}
		int basicExp = weaponExpItemConfig.Value.BasicExp;
		int requiredCount = (int)Math.Ceiling((double)(totalNeedExp - accumulatedExp) / (double)basicExp);
		totalMaterials.Add(new global::ItemMaterial
		{
			ItemId = itemInfo.Id,
			RequiredCount = requiredCount
		});
	}

	// Token: 0x06014679 RID: 83577 RVA: 0x005ABE98 File Offset: 0x005AA098
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevDetailItemData> CreateWeaponBreachItemDetailData(int roleId, WeaponInstance weaponInstance, int currentBreachLevel, int targetBreachLevel)
	{
		if (currentBreachLevel > targetBreachLevel)
		{
			return null;
		}
		WeaponConf? weaponConfig = weaponInstance.GetWeaponConfig();
		if (weaponConfig == null)
		{
			return null;
		}
		List<global::IItemMaterial> list = this.CalculateBreachMaterials(weaponConfig.Value, currentBreachLevel, targetBreachLevel);
		if (list.Count == 0)
		{
			return null;
		}
		return this.BuildBreachDetailItems(roleId, list);
	}

	// Token: 0x0601467A RID: 83578 RVA: 0x005ABEE4 File Offset: 0x005AA0E4
	private List<global::IItemMaterial> CalculateBreachMaterials(WeaponConf weaponConfig, int currentBreachLevel, int targetBreachLevel)
	{
		List<global::IItemMaterial> list = new List<global::IItemMaterial>();
		int num = Math.Min(ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(weaponConfig.BreachId), targetBreachLevel);
		for (int i = currentBreachLevel; i <= num; i++)
		{
			WeaponBreach? weaponBreach = ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConfig.BreachId, i);
			if (weaponBreach != null)
			{
				this.AddBreachLevelMaterials(weaponBreach.Value, list);
			}
		}
		return list;
	}

	// Token: 0x0601467B RID: 83579 RVA: 0x005ABF48 File Offset: 0x005AA148
	private void AddBreachLevelMaterials(WeaponBreach breachConfig, List<global::IItemMaterial> totalMaterials)
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
				this.AddOrUpdateMaterial(totalMaterials, key, value);
			}
		}
	}

	// Token: 0x0601467C RID: 83580 RVA: 0x005ABFBC File Offset: 0x005AA1BC
	private void AddOrUpdateMaterial(List<global::IItemMaterial> totalMaterials, int itemId, int count)
	{
		global::IItemMaterial itemMaterial = totalMaterials.FirstOrDefault((global::IItemMaterial material) => material.ItemId == itemId);
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

	// Token: 0x0601467D RID: 83581 RVA: 0x005AC01C File Offset: 0x005AA21C
	private List<global::IRoleDevDetailItemData> BuildBreachDetailItems(int roleId, List<global::IItemMaterial> totalMaterials)
	{
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		List<global::IRoleDevDetailItemData> list = RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Weapon);
		if (list.Count <= 0)
		{
			return new List<global::IRoleDevDetailItemData>();
		}
		return list;
	}

	// Token: 0x17001A67 RID: 6759
	// (get) Token: 0x0601467E RID: 83582 RVA: 0x005AC049 File Offset: 0x005AA249
	public List<global::IRoleDevDetailItemData> DetailItems
	{
		get
		{
			return this.DetailItemsInternal;
		}
	}

	// Token: 0x04009E00 RID: 40448
	private List<global::IRoleDevDetailItemData> DetailItemsInternal = new List<global::IRoleDevDetailItemData>();
}
