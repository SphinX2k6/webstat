using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;

// Token: 0x0200281A RID: 10266
[NullableContext(1)]
[Nullable(0)]
public class RoleDevUtils
{
	// Token: 0x0601444D RID: 83021 RVA: 0x005A4735 File Offset: 0x005A2935
	public static ERoleDevDataType GetRoleDevDataTypeByRoleId(int roleId)
	{
		if (ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true) != null)
		{
			return ERoleDevDataType.Obtained;
		}
		if (RoleDevUtils.GetRoleTypeTagByRoleId(roleId) == global::ERoleTypeTag.Forecast)
		{
			return ERoleDevDataType.Forecast;
		}
		return ERoleDevDataType.NotObtained;
	}

	// Token: 0x0601444E RID: 83022 RVA: 0x005A4754 File Offset: 0x005A2954
	public static RoleDevCultivateProject? GetCultivateProject(int roleId)
	{
		int? cultivateProjectId = RoleDevUtils.GetCultivateProjectId(roleId);
		if (cultivateProjectId == null)
		{
			return null;
		}
		return ConfigBase<RoleDevConfig>.Instance.GetCultivateProjectConfig(cultivateProjectId.Value);
	}

	// Token: 0x0601444F RID: 83023 RVA: 0x005A478C File Offset: 0x005A298C
	public static int? GetCultivateProjectId(int roleId)
	{
		RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId);
		int currentProjectNum = RoleDevUtils.GetCurrentProjectNum();
		int[] array = roleDevProjectConfig.Value.ProjectGroup();
		if (array.Length <= currentProjectNum)
		{
			return null;
		}
		return new int?(array[currentProjectNum]);
	}

	// Token: 0x06014450 RID: 83024 RVA: 0x005A47D4 File Offset: 0x005A29D4
	public static int[] GetRoleGachaIds(int hotRoleId)
	{
		List<int> list = new List<int>();
		if (!RoleDevUtils.IsHotRole(hotRoleId))
		{
			return list.ToArray();
		}
		IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(hotRoleId);
		if (roleDevProsListConfig == null)
		{
			return list.ToArray();
		}
		int gachaId = roleDevProsListConfig.GachaId;
		if (gachaId != 0 && ModelBase<GachaModel>.Instance.CheckGachaValidByGachaId(gachaId))
		{
			list.Add(gachaId);
		}
		foreach (IRoleDevProsSpecialGachaConfig roleDevProsSpecialGachaConfig in roleDevProsListConfig.SpecialGachaId)
		{
			if (ModelBase<GachaModel>.Instance.CheckGachaValidByGachaId(roleDevProsSpecialGachaConfig.GachaId))
			{
				list.Add(roleDevProsSpecialGachaConfig.GachaId);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06014451 RID: 83025 RVA: 0x005A4890 File Offset: 0x005A2A90
	public static global::ERoleTypeTag GetRoleProspectType(int roleId)
	{
		IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId);
		if (RoleDevUtils.IsProspectTimeValid(roleId))
		{
			return global::ERoleTypeTag.Forecast;
		}
		if (RoleDevUtils.IsGachaValid(roleDevProsListConfig.GachaId))
		{
			return global::ERoleTypeTag.Summon;
		}
		return global::ERoleTypeTag.None;
	}

	// Token: 0x06014452 RID: 83026 RVA: 0x005A48C4 File Offset: 0x005A2AC4
	public static global::ERoleTypeTag GetRoleRerunType(int roleId)
	{
		IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId);
		if (RoleDevUtils.IsProspectTimeValid(roleId))
		{
			return global::ERoleTypeTag.Rerun;
		}
		if (RoleDevUtils.IsGachaValid(roleDevProsListConfig.GachaId))
		{
			return global::ERoleTypeTag.Summon;
		}
		return global::ERoleTypeTag.None;
	}

	// Token: 0x06014453 RID: 83027 RVA: 0x005A48F8 File Offset: 0x005A2AF8
	public static bool IsHotRole(int roleId)
	{
		IReadOnlyList<IRoleDevProsConfig> allRoleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetAllRoleDevProsListConfig();
		if (allRoleDevProsListConfig == null)
		{
			return false;
		}
		using (IEnumerator<IRoleDevProsConfig> enumerator = allRoleDevProsListConfig.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Id == roleId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06014454 RID: 83028 RVA: 0x005A4958 File Offset: 0x005A2B58
	public static global::ERoleTypeTag GetRoleTypeTagByRoleId(int roleId)
	{
		IEnumerable<IRoleDevProsConfig> allRoleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetAllRoleDevProsListConfig();
		bool flag = false;
		using (IEnumerator<IRoleDevProsConfig> enumerator = allRoleDevProsListConfig.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Id == roleId)
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			return global::ERoleTypeTag.None;
		}
		IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId);
		if (roleDevProsListConfig == null)
		{
			return global::ERoleTypeTag.None;
		}
		bool flag2 = RoleDevUtils.IsProspectTimeValid(roleDevProsListConfig.Id);
		bool flag3 = RoleDevUtils.IsGachaValid(roleDevProsListConfig.GachaId);
		if (roleDevProsListConfig.TypeId == 1)
		{
			if (!flag2)
			{
				return global::ERoleTypeTag.None;
			}
			return global::ERoleTypeTag.Forecast;
		}
		else
		{
			if (roleDevProsListConfig.TypeId == 2)
			{
				return RoleDevUtils.GetRoleProspectType(roleId);
			}
			if (roleDevProsListConfig.TypeId == 3)
			{
				if (!flag2)
				{
					return global::ERoleTypeTag.None;
				}
				return global::ERoleTypeTag.Rerun;
			}
			else
			{
				if (roleDevProsListConfig.TypeId == 4)
				{
					return RoleDevUtils.GetRoleRerunType(roleId);
				}
				if (roleDevProsListConfig.TypeId != 5)
				{
					if (roleDevProsListConfig.TypeId == 6)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.RoleDev;
						ELogAuthor author = ELogAuthor.WMQ;
						string message = "武器类型调用GetRoleTypeTagByRoleId方法";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					int typeId = roleDevProsListConfig.TypeId;
					return global::ERoleTypeTag.None;
				}
				if (!flag3)
				{
					return global::ERoleTypeTag.None;
				}
				return global::ERoleTypeTag.Summon;
			}
		}
	}

	// Token: 0x06014455 RID: 83029 RVA: 0x005A4A74 File Offset: 0x005A2C74
	public static bool IsGachaValid(int gachaId)
	{
		return ModelBase<GachaModel>.Instance.CheckGachaValidByGachaId(gachaId);
	}

	// Token: 0x06014456 RID: 83030 RVA: 0x005A4A84 File Offset: 0x005A2C84
	public static int GetCurrentProjectNum()
	{
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		if (originWorldLevel == 0)
		{
			return 0;
		}
		IReadOnlyList<RoleDevLevelLimit> levelLimitConfigList = ConfigBase<RoleDevConfig>.Instance.GetLevelLimitConfigList();
		if (levelLimitConfigList == null)
		{
			return 0;
		}
		foreach (RoleDevLevelLimit roleDevLevelLimit in levelLimitConfigList)
		{
			IntPair[] array = roleDevLevelLimit.PlayerLevel();
			if (originWorldLevel >= array[0].Item1 && originWorldLevel <= array[0].Item2)
			{
				return roleDevLevelLimit.ProjectNum;
			}
		}
		return 0;
	}

	// Token: 0x06014457 RID: 83031 RVA: 0x005A4B20 File Offset: 0x005A2D20
	public static List<global::IMaterialGroup> GroupMaterialsByType(List<global::IItemMaterial> totalMaterials)
	{
		Dictionary<int, global::IItemMaterial> dictionary = new Dictionary<int, global::IItemMaterial>();
		foreach (global::IItemMaterial itemMaterial in totalMaterials)
		{
			global::IItemMaterial itemMaterial2;
			if (dictionary.TryGetValue(itemMaterial.ItemId, out itemMaterial2))
			{
				itemMaterial2.RequiredCount += itemMaterial.RequiredCount;
			}
			else
			{
				dictionary[itemMaterial.ItemId] = new global::ItemMaterial
				{
					ItemId = itemMaterial.ItemId,
					RequiredCount = itemMaterial.RequiredCount
				};
			}
		}
		List<global::IItemMaterial> list = new List<global::IItemMaterial>(dictionary.Values);
		List<global::IMaterialGroup> list2 = new List<global::IMaterialGroup>();
		foreach (global::IItemMaterial itemMaterial3 in list)
		{
			int itemId = itemMaterial3.ItemId;
			RoleDevItemJumpGroup? roleDevItemJumpGroup;
			int? num = (ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(itemId) != null) ? new int?(roleDevItemJumpGroup.GetValueOrDefault().ItemType) : null;
			if (num != null)
			{
				global::IMaterialGroup materialGroup = null;
				foreach (global::IMaterialGroup materialGroup2 in list2)
				{
					if (materialGroup2.Type == num.Value)
					{
						materialGroup = materialGroup2;
						break;
					}
				}
				if (materialGroup != null)
				{
					materialGroup.Materials.Add(itemMaterial3);
				}
				else
				{
					list2.Add(new global::MaterialGroup
					{
						Type = num.Value,
						Materials = new List<global::IItemMaterial>
						{
							itemMaterial3
						}
					});
				}
			}
		}
		list2.Sort((global::IMaterialGroup a, global::IMaterialGroup b) => a.Type - b.Type);
		return list2;
	}

	// Token: 0x06014458 RID: 83032 RVA: 0x005A4D10 File Offset: 0x005A2F10
	public static int? GetFirstOpenDungeonIdByItemGroupId(int itemGroupId)
	{
		if (itemGroupId == 0)
		{
			return null;
		}
		RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(itemGroupId);
		if (itemJumpGroupConfig == null)
		{
			return null;
		}
		return RoleDevUtils.GetFirstOpenDungeonId(itemJumpGroupConfig.Value.JumpGroup());
	}

	// Token: 0x06014459 RID: 83033 RVA: 0x005A4D60 File Offset: 0x005A2F60
	public static int? GetFirstOpenDungeonId(int[] jumpIdList)
	{
		Dictionary<int, SilentAreaDetectionRecord> allDetectSilentAreas = ModelBase<AdventureGuideModel>.Instance.GetAllDetectSilentAreas();
		if (allDetectSilentAreas == null)
		{
			return null;
		}
		foreach (int num in jumpIdList)
		{
			SilentAreaDetectionRecord silentAreaDetectionRecord;
			if (allDetectSilentAreas.TryGetValue(num, out silentAreaDetectionRecord) && silentAreaDetectionRecord != null && !silentAreaDetectionRecord.IsLock)
			{
				return new int?(num);
			}
		}
		return null;
	}

	// Token: 0x0601445A RID: 83034 RVA: 0x005A4DC4 File Offset: 0x005A2FC4
	public static int? GetFirstUnlockedTeleportId(int[] jumpIdList)
	{
		foreach (int num in jumpIdList)
		{
			if (RoleDevUtils.CheckAccessPathUnlocked(num))
			{
				return new int?(num);
			}
		}
		if (jumpIdList.Length == 0)
		{
			return null;
		}
		return new int?(jumpIdList[jumpIdList.Length - 1]);
	}

	// Token: 0x0601445B RID: 83035 RVA: 0x005A4E10 File Offset: 0x005A3010
	public static bool CheckAccessPathUnlocked(int accessPathId)
	{
		AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(accessPathId);
		if (accessPathConfig != null && accessPathConfig.Value.SkipName == 2)
		{
			return RoleDevUtils.CheckDungeonAccessUnlocked(accessPathConfig.Value);
		}
		return ModelBase<MapModel>.Instance.CheckTeleportUnlocked(accessPathId);
	}

	// Token: 0x0601445C RID: 83036 RVA: 0x005A4E5C File Offset: 0x005A305C
	public static bool CheckDungeonAccessUnlocked(AccessPath config)
	{
		int id = int.Parse(config.Val1);
		InstanceDungeonEntrance? config2 = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(id);
		bool flag = false;
		if (config2 != null)
		{
			for (int i = 0; i < config2.Value.InstanceDungeonListLength; i++)
			{
				int instanceId = config2.Value.InstanceDungeonList(i);
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(instanceId))
				{
					flag = true;
					break;
				}
			}
		}
		int markId = int.Parse(config.Val3);
		MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
		if (configMark == null)
		{
			return false;
		}
		LevelEntityConfig? entityConfigByMapIdAndEntityId = ConfigBase<MapConfig>.Instance.GetEntityConfigByMapIdAndEntityId(configMark.Value.MapId, configMark.Value.EntityConfigId);
		if (entityConfigByMapIdAndEntityId == null)
		{
			return false;
		}
		int areaId = entityConfigByMapIdAndEntityId.Value.AreaId;
		Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
		int areaId2 = (areaInfo != null) ? ModelBase<AreaModel>.Instance.GetAreaId(areaInfo.Value, new EAreaLevel?(EAreaLevel.FirstLevel)) : 0;
		bool flag2 = ModelBase<MapModel>.Instance.CheckAreasUnlocked(areaId2, true);
		return flag && flag2;
	}

	// Token: 0x0601445D RID: 83037 RVA: 0x005A4F88 File Offset: 0x005A3188
	public static List<global::IRoleDevDetailItemData> BuildDetailItemData(int roleId, List<global::IMaterialGroup> materialGroups, ERoleDevMainPage sourcePageType)
	{
		List<global::IRoleDevDetailItemData> list = new List<global::IRoleDevDetailItemData>();
		List<int> list2 = new List<int>();
		foreach (global::IMaterialGroup materialGroup in materialGroups)
		{
			list2.Add(materialGroup.Type);
		}
		list2.Sort((int a, int b) => a - b);
		foreach (int num in list2)
		{
			RoleDevTypeManage? typeManageConfig = ConfigBase<RoleDevConfig>.Instance.GetTypeManageConfig(num);
			string title = ((typeManageConfig != null) ? typeManageConfig.GetValueOrDefault().TypeDescribe : null) ?? "";
			List<global::IItemMaterial> list3 = null;
			foreach (global::IMaterialGroup materialGroup2 in materialGroups)
			{
				if (materialGroup2.Type == num)
				{
					list3 = materialGroup2.Materials;
					break;
				}
			}
			if (list3 == null)
			{
				list3 = new List<global::IItemMaterial>();
			}
			List<global::IItemMaterial> itemGroup = RoleDevUtils.SortMaterialsByQuality(list3);
			ERoleDevSubPageButton buttonTypeByType = RoleDevUtils.GetButtonTypeByType(sourcePageType, (CSharpScript.Game.Module.RoleDev.EItemMaterialType)num);
			list.Add(new global::RoleDevDetailItemData
			{
				RoleId = roleId,
				MainPage = sourcePageType,
				ButtonType = buttonTypeByType,
				Title = title,
				ItemGroupId = 0,
				ItemGroup = itemGroup
			});
		}
		return list;
	}

	// Token: 0x0601445E RID: 83038 RVA: 0x005A5128 File Offset: 0x005A3328
	private static ERoleDevSubPageButton GetButtonTypeByType(ERoleDevMainPage sourcePageType, CSharpScript.Game.Module.RoleDev.EItemMaterialType type)
	{
		ERoleDevSubPageButton eroleDevSubPageButton = ERoleDevSubPageButton.None;
		switch (sourcePageType)
		{
		case ERoleDevMainPage.Role:
			if (RoleDevDefine.roleTabMaterialTypeToSubPageButtonMap.TryGetValue(type, out eroleDevSubPageButton))
			{
				return eroleDevSubPageButton;
			}
			goto IL_51;
		case ERoleDevMainPage.Weapon:
			if (RoleDevDefine.weaponTabMaterialTypeToSubPageButtonMap.TryGetValue(type, out eroleDevSubPageButton))
			{
				return eroleDevSubPageButton;
			}
			goto IL_51;
		case ERoleDevMainPage.Skill:
			if (RoleDevDefine.skillTabMaterialTypeToSubPageButtonMap.TryGetValue(type, out eroleDevSubPageButton))
			{
				return eroleDevSubPageButton;
			}
			goto IL_51;
		}
		eroleDevSubPageButton = ERoleDevSubPageButton.None;
		IL_51:
		if (eroleDevSubPageButton == ERoleDevSubPageButton.None)
		{
			return ERoleDevSubPageButton.None;
		}
		return eroleDevSubPageButton;
	}

	// Token: 0x0601445F RID: 83039 RVA: 0x005A518D File Offset: 0x005A338D
	private static List<global::IItemMaterial> SortMaterialsByQuality(List<global::IItemMaterial> materials)
	{
		materials.Sort(delegate(global::IItemMaterial a, global::IItemMaterial b)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemId);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ItemId);
			int num = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			int num2 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			return num - num2;
		});
		return materials;
	}

	// Token: 0x06014460 RID: 83040 RVA: 0x005A51B8 File Offset: 0x005A33B8
	public static bool CheckAllItemsUp(List<global::IRoleDevDetailItemData> detailItems)
	{
		if (detailItems == null || detailItems.Count == 0)
		{
			return false;
		}
		foreach (global::IRoleDevDetailItemData roleDevDetailItemData in detailItems)
		{
			foreach (global::IItemMaterial itemMaterial in roleDevDetailItemData.ItemGroup)
			{
				int requiredCount = itemMaterial.RequiredCount;
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemMaterial.ItemId, 0) < requiredCount)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06014461 RID: 83041 RVA: 0x005A526C File Offset: 0x005A346C
	public static bool IsProspectTimeValid(int roleId)
	{
		RoleDevModel instance = ModelBase<RoleDevModel>.Instance;
		if (instance == null || !instance.IsConfigDataInitialized)
		{
			return false;
		}
		IRoleDevProsConfig roleDevPropsConfig = instance.GetRoleDevPropsConfig(roleId);
		if (roleDevPropsConfig == null)
		{
			return false;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		long prospectBeginTime = roleDevPropsConfig.ProspectBeginTime;
		long prospectEndTime = roleDevPropsConfig.ProspectEndTime;
		return prospectBeginTime != 0L && prospectEndTime != 0L && serverTime >= (double)prospectBeginTime && (prospectEndTime == 0L || serverTime <= (double)prospectEndTime);
	}

	// Token: 0x06014462 RID: 83042 RVA: 0x005A52D0 File Offset: 0x005A34D0
	public static ERoleDevWeaponTabType GetWeaponDefaultTabType(int roleId, bool isWeaponHighQuality)
	{
		if (ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true) == null)
		{
			return ERoleDevWeaponTabType.WeaponDev;
		}
		if (isWeaponHighQuality)
		{
			return ERoleDevWeaponTabType.WeaponDev;
		}
		return ERoleDevWeaponTabType.WeaponRecommend;
	}

	// Token: 0x06014463 RID: 83043 RVA: 0x005A52E8 File Offset: 0x005A34E8
	public static List<global::IRoleDevDetailItemData> CreateSkillDetailItemsData(int[] skillNodeIdList, int[] currentLevels, int[] targetLevels, int roleId)
	{
		List<global::IItemMaterial> totalMaterials = new List<global::IItemMaterial>();
		RoleDevUtils.ProcessUpgradedSkillLevelConsume(skillNodeIdList, currentLevels, targetLevels, totalMaterials);
		List<global::IMaterialGroup> materialGroups = RoleDevUtils.GroupMaterialsByType(totalMaterials);
		return RoleDevUtils.BuildDetailItemData(roleId, materialGroups, ERoleDevMainPage.Skill);
	}

	// Token: 0x06014464 RID: 83044 RVA: 0x005A5314 File Offset: 0x005A3514
	private static void ProcessUpgradedSkillLevelConsume(int[] skillNodeIdList, int[] currentLevels, int[] targetLevels, List<global::IItemMaterial> totalMaterials)
	{
		for (int i = 0; i < skillNodeIdList.Length; i++)
		{
			int num = currentLevels[i];
			int num2 = targetLevels[i];
			for (int j = num + 1; j <= num2; j++)
			{
				IEnumerable<DicIntInt?> roleSkillTreeConsume = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillTreeConsume(skillNodeIdList[i], j);
				if (roleSkillTreeConsume != null)
				{
					foreach (DicIntInt? dicIntInt in roleSkillTreeConsume)
					{
						int key = dicIntInt.Value.Key;
						int value = dicIntInt.Value.Value;
						if (!RoleDevUtils.ShouldSkipItem(key))
						{
							RoleDevUtils.AddOrUpdateMaterial(totalMaterials, key, value);
						}
					}
				}
			}
		}
	}

	// Token: 0x06014465 RID: 83045 RVA: 0x005A53CC File Offset: 0x005A35CC
	private static bool ShouldSkipItem(int itemId)
	{
		return itemId == 1 || itemId == 2;
	}

	// Token: 0x06014466 RID: 83046 RVA: 0x005A53D8 File Offset: 0x005A35D8
	private static void AddOrUpdateMaterial(List<global::IItemMaterial> totalMaterials, int itemId, int count)
	{
		global::IItemMaterial itemMaterial = null;
		foreach (global::IItemMaterial itemMaterial2 in totalMaterials)
		{
			if (itemMaterial2.ItemId == itemId)
			{
				itemMaterial = itemMaterial2;
				break;
			}
		}
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

	// Token: 0x06014467 RID: 83047 RVA: 0x005A545C File Offset: 0x005A365C
	public static bool GetDefaultSkillPlanByRoleId(int roleId)
	{
		return RoleDevUtils.GetRoleTypeTagByRoleId(roleId) == global::ERoleTypeTag.Forecast;
	}

	// Token: 0x06014468 RID: 83048 RVA: 0x005A546C File Offset: 0x005A366C
	public static void OpenWeaponReplaceView(int roleId, int weaponIncId)
	{
		RoleViewViewModel roleViewViewModel = new RoleViewViewModel(roleId, false, ERoleViewSource.Normal);
		roleViewViewModel.WeaponIncId = weaponIncId;
		roleViewViewModel.NeedShowOnViewPlayingStartSequence = true;
		roleViewViewModel.NeedHideOnViewPlayingCloseSequence = true;
		roleViewViewModel.FadeInCurveId = ERoleFadeCurveDefine.RoleFadeInCurve;
		roleViewViewModel.FadeOutCurveId = ERoleFadeCurveDefine.RoleFadeOutCurve;
		roleViewViewModel.RoleStatePlayContextOnShow = new RoleStatePlayContext
		{
			RoleState = EPerformanceRoleState.Weapon,
			ReLoop = true
		};
		roleViewViewModel.RoleStatePlayContextOnHide = new RoleStatePlayContext
		{
			RoleState = EPerformanceRoleState.Attribute
		};
		ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.WeaponReplaceView, roleViewViewModel);
	}
}
