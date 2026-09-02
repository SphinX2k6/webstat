using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x020050AE RID: 20654
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopUtil
	{
		// Token: 0x06035358 RID: 217944 RVA: 0x00D55B90 File Offset: 0x00D53D90
		public static bool IsHotRoleDevelopValid(int roleProspectId)
		{
			if (!RoleDevelopUtil.IsHotRole(roleProspectId))
			{
				return false;
			}
			int typeId = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleProspectId).TypeId;
			return (typeId != 1 || RoleDevelopUtil.IsRoleInProspectTime(roleProspectId)) && typeId != 0 && typeId != 4;
		}

		// Token: 0x06035359 RID: 217945 RVA: 0x00D55BD0 File Offset: 0x00D53DD0
		public static RoleDevCultivateProject? GetCultivateProject(int roleId)
		{
			int? cultivateProjectId = RoleDevelopUtil.GetCultivateProjectId(roleId);
			if (cultivateProjectId == null)
			{
				return null;
			}
			return ConfigBase<RoleDevConfig>.Instance.GetCultivateProjectConfig(cultivateProjectId.Value);
		}

		// Token: 0x0603535A RID: 217946 RVA: 0x00D55C08 File Offset: 0x00D53E08
		public static int? GetCultivateProjectId(int roleId)
		{
			RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId);
			int currentProjectNum = RoleDevelopUtil.GetCurrentProjectNum();
			int[] projectGroupArray = roleDevProjectConfig.Value.GetProjectGroupArray();
			if (projectGroupArray.Length <= currentProjectNum)
			{
				return null;
			}
			return new int?(projectGroupArray[currentProjectNum]);
		}

		// Token: 0x0603535B RID: 217947 RVA: 0x00D55C50 File Offset: 0x00D53E50
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

		// Token: 0x0603535C RID: 217948 RVA: 0x00D55CEC File Offset: 0x00D53EEC
		public static bool CheckIsAllNeedItemsEnough(List<RoleDevelopNeedItem> needItems)
		{
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in needItems)
			{
				if (RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem.ItemId))
				{
					return false;
				}
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(roleDevelopNeedItem.ItemId, 0) < roleDevelopNeedItem.Count)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603535D RID: 217949 RVA: 0x00D55D64 File Offset: 0x00D53F64
		public static bool IsUnknownItem(int itemId)
		{
			return itemId == ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.UnknownItemId;
		}

		// Token: 0x0603535E RID: 217950 RVA: 0x00D55D90 File Offset: 0x00D53F90
		public static bool CheckIsAllNeedItemsEnoughOrCanBeFilled(List<RoleDevelopNeedItem> needItems)
		{
			if (RoleDevelopUtil.CheckIsItemsHaveUnknownMaterial(needItems))
			{
				return false;
			}
			foreach (RoleDevelopItemGroup itemGroup in RoleDevelopUtil.BuildGroupItemDataByNeedItems(needItems, false, true, false))
			{
				if (ModelBase<RoleDevelopModel>.Instance.GetItemGroupRequirementState(itemGroup, null) == EItemRequirementState.NotSatisfied)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603535F RID: 217951 RVA: 0x00D55E00 File Offset: 0x00D54000
		public static bool CheckIsItemsHaveUnknownMaterial(List<RoleDevelopNeedItem> items)
		{
			using (List<RoleDevelopNeedItem>.Enumerator enumerator = items.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (RoleDevelopUtil.IsUnknownItem(enumerator.Current.ItemId))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06035360 RID: 217952 RVA: 0x00D55E5C File Offset: 0x00D5405C
		public static List<RoleDevelopNeedItem> SortItemsByQuality(List<RoleDevelopNeedItem> items)
		{
			items.Sort(delegate(RoleDevelopNeedItem a, RoleDevelopNeedItem b)
			{
				bool flag = RoleDevelopUtil.IsUnknownItem(a.ItemId);
				bool flag2 = RoleDevelopUtil.IsUnknownItem(b.ItemId);
				if (flag == flag2)
				{
					ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemId);
					ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ItemId);
					int num = (itemConfigData != null) ? itemConfigData.QualityId : 0;
					int num2 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
					return num - num2;
				}
				if (!flag)
				{
					return 1;
				}
				return -1;
			});
			return items;
		}

		// Token: 0x06035361 RID: 217953 RVA: 0x00D55E84 File Offset: 0x00D54084
		public static List<RoleDevelopNeedItem> CalcUpgradeNeedItems(int totalExp, List<RoleDevelopNeedItem> sortedExpItems, Func<int, int> getItemExp)
		{
			if (totalExp <= 0 || sortedExpItems.Count == 0)
			{
				return new List<RoleDevelopNeedItem>();
			}
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			int num = totalExp;
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in sortedExpItems)
			{
				int num2 = getItemExp(roleDevelopNeedItem.ItemId);
				int num3 = Math.Min((int)Math.Ceiling((double)num / (double)num2), roleDevelopNeedItem.Count);
				if (num3 > 0)
				{
					list.Add(new RoleDevelopNeedItem
					{
						ItemId = roleDevelopNeedItem.ItemId,
						Count = num3
					});
				}
				num -= num3 * num2;
			}
			if (num > 0)
			{
				RoleDevelopNeedItem roleDevelopNeedItem2 = sortedExpItems[sortedExpItems.Count - 1];
				int num4 = getItemExp(roleDevelopNeedItem2.ItemId);
				int num5 = (int)Math.Ceiling((double)num / (double)num4);
				if (num5 > 0)
				{
					RoleDevelopNeedItem roleDevelopNeedItem3 = null;
					foreach (RoleDevelopNeedItem roleDevelopNeedItem4 in list)
					{
						if (roleDevelopNeedItem4.ItemId == roleDevelopNeedItem2.ItemId)
						{
							roleDevelopNeedItem3 = roleDevelopNeedItem4;
							break;
						}
					}
					if (roleDevelopNeedItem3 != null)
					{
						roleDevelopNeedItem3.Count += num5;
					}
					else
					{
						list.Add(new RoleDevelopNeedItem
						{
							ItemId = roleDevelopNeedItem2.ItemId,
							Count = num5
						});
					}
				}
			}
			return list;
		}

		// Token: 0x06035362 RID: 217954 RVA: 0x00D55FF8 File Offset: 0x00D541F8
		public static List<RoleDevelopItemGroup> BuildGroupItemDataByNeedItems(List<RoleDevelopNeedItem> needItems, bool useSubGroup = false, bool sortByType = true, bool excludeSatisfied = false)
		{
			Dictionary<string, RoleDevelopItemGroup> dictionary = new Dictionary<string, RoleDevelopItemGroup>();
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in needItems)
			{
				if (RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem.ItemId))
				{
					if (roleDevelopNeedItem.Type != null)
					{
						EItemMaterialType value = roleDevelopNeedItem.Type.Value;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
						defaultInterpolatedStringHandler.AppendFormatted<int>((int)value);
						string groupKey = defaultInterpolatedStringHandler.ToStringAndClear();
						RoleDevelopUtil.AddItemToGroup(dictionary, groupKey, value, roleDevelopNeedItem);
					}
				}
				else
				{
					RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(roleDevelopNeedItem.ItemId);
					if (itemJumpGroupConfig != null)
					{
						int num = (int)((roleDevelopNeedItem.Type != null) ? roleDevelopNeedItem.Type.Value : ((EItemMaterialType)itemJumpGroupConfig.Value.ItemType));
						string text;
						if (!useSubGroup)
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
							defaultInterpolatedStringHandler.AppendFormatted<int>(num);
							text = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						else
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
							defaultInterpolatedStringHandler.AppendFormatted<int>(num);
							defaultInterpolatedStringHandler.AppendLiteral("_");
							defaultInterpolatedStringHandler.AppendFormatted<int>(itemJumpGroupConfig.Value.SubGroup);
							text = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						string groupKey2 = text;
						RoleDevelopUtil.AddItemToGroup(dictionary, groupKey2, (EItemMaterialType)num, roleDevelopNeedItem);
					}
				}
			}
			if (excludeSatisfied)
			{
				InventoryModel instance = ModelBase<InventoryModel>.Instance;
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, RoleDevelopItemGroup> keyValuePair in dictionary)
				{
					RoleDevelopItemGroup value2 = keyValuePair.Value;
					bool flag = false;
					foreach (RoleDevelopNeedItem roleDevelopNeedItem2 in value2.Items)
					{
						if (RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem2.ItemId) || instance.GetItemCountByConfigId(roleDevelopNeedItem2.ItemId, 0) < roleDevelopNeedItem2.Count)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Add(keyValuePair.Key);
					}
				}
				foreach (string key in list)
				{
					dictionary.Remove(key);
				}
			}
			List<RoleDevelopItemGroup> list2 = new List<RoleDevelopItemGroup>(dictionary.Values);
			if (sortByType)
			{
				list2.Sort((RoleDevelopItemGroup a, RoleDevelopItemGroup b) => a.Type - b.Type);
			}
			return list2;
		}

		// Token: 0x06035363 RID: 217955 RVA: 0x00D562DC File Offset: 0x00D544DC
		private static void AddItemToGroup(Dictionary<string, RoleDevelopItemGroup> groupMap, string groupKey, EItemMaterialType itemType, RoleDevelopNeedItem item)
		{
			RoleDevelopItemGroup roleDevelopItemGroup;
			if (!groupMap.TryGetValue(groupKey, out roleDevelopItemGroup))
			{
				roleDevelopItemGroup = new RoleDevelopItemGroup
				{
					Type = itemType,
					Items = new List<RoleDevelopNeedItem>()
				};
				groupMap[groupKey] = roleDevelopItemGroup;
			}
			RoleDevelopNeedItem roleDevelopNeedItem = null;
			foreach (RoleDevelopNeedItem roleDevelopNeedItem2 in roleDevelopItemGroup.Items)
			{
				if (roleDevelopNeedItem2.ItemId == item.ItemId)
				{
					roleDevelopNeedItem = roleDevelopNeedItem2;
					break;
				}
			}
			if (roleDevelopNeedItem != null)
			{
				roleDevelopNeedItem.Count += item.Count;
				return;
			}
			roleDevelopItemGroup.Items.Add(item);
		}

		// Token: 0x06035364 RID: 217956 RVA: 0x00D5638C File Offset: 0x00D5458C
		public static bool IsHotRole(int roleId)
		{
			return ConfigBase<RoleDevConfig>.Instance.HasRoleDevProsListConfig(roleId);
		}

		// Token: 0x06035365 RID: 217957 RVA: 0x00D5639C File Offset: 0x00D5459C
		public static bool IsRoleInProspectTime(int roleId)
		{
			if (!RoleDevelopUtil.IsHotRole(roleId))
			{
				return false;
			}
			IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId);
			long prospectBeginTime = roleDevProsListConfig.ProspectBeginTime;
			long prospectEndTime = roleDevProsListConfig.ProspectEndTime;
			if (prospectBeginTime == 0L || prospectEndTime == 0L || prospectEndTime < prospectBeginTime)
			{
				return false;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return serverTime >= (double)prospectBeginTime && serverTime <= (double)prospectEndTime;
		}

		// Token: 0x06035366 RID: 217958 RVA: 0x00D563F1 File Offset: 0x00D545F1
		public static bool IsProspectRole(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 1;
		}

		// Token: 0x06035367 RID: 217959 RVA: 0x00D56410 File Offset: 0x00D54610
		public static bool IsProspectRoleValid(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 1 && RoleDevelopUtil.IsRoleInProspectTime(roleId);
		}

		// Token: 0x06035368 RID: 217960 RVA: 0x00D56438 File Offset: 0x00D54638
		public static bool IsAnyProspectRole(int roleId)
		{
			if (!RoleDevelopUtil.IsHotRole(roleId))
			{
				return false;
			}
			int typeId = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId;
			return typeId == 1 || (typeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(roleId));
		}

		// Token: 0x06035369 RID: 217961 RVA: 0x00D56472 File Offset: 0x00D54672
		public static bool IsCurrentVersionProspectRole(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 2;
		}

		// Token: 0x0603536A RID: 217962 RVA: 0x00D56491 File Offset: 0x00D54691
		public static bool IsCurrentVersionProspectRoleInProspect(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(roleId);
		}

		// Token: 0x0603536B RID: 217963 RVA: 0x00D564B8 File Offset: 0x00D546B8
		public static bool IsCurrentVersionProspectRoleGachaValid(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 2 && RoleDevelopUtil.GetHotRoleGachaId(roleId, true) != null;
		}

		// Token: 0x0603536C RID: 217964 RVA: 0x00D564F3 File Offset: 0x00D546F3
		public static bool IsCurrentVersionProspectRoleValid(int roleId)
		{
			return RoleDevelopUtil.IsCurrentVersionProspectRoleInProspect(roleId) || RoleDevelopUtil.IsCurrentVersionProspectRoleGachaValid(roleId);
		}

		// Token: 0x0603536D RID: 217965 RVA: 0x00D56505 File Offset: 0x00D54705
		public static bool IsReturningRole(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 3;
		}

		// Token: 0x0603536E RID: 217966 RVA: 0x00D56524 File Offset: 0x00D54724
		public static bool IsReturningRoleInProspect(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 3 && RoleDevelopUtil.IsRoleInProspectTime(roleId);
		}

		// Token: 0x0603536F RID: 217967 RVA: 0x00D5654C File Offset: 0x00D5474C
		public static bool IsReturningRoleGachaValid(int roleId)
		{
			return RoleDevelopUtil.IsHotRole(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(roleId).TypeId == 3 && RoleDevelopUtil.GetHotRoleGachaId(roleId, true) != null;
		}

		// Token: 0x06035370 RID: 217968 RVA: 0x00D56587 File Offset: 0x00D54787
		public static bool IsReturningRoleValid(int roleId)
		{
			return RoleDevelopUtil.IsReturningRoleInProspect(roleId) || RoleDevelopUtil.IsReturningRoleGachaValid(roleId);
		}

		// Token: 0x06035371 RID: 217969 RVA: 0x00D5659C File Offset: 0x00D5479C
		public static int? GetHotRoleGachaId(int id, bool checkValid = false)
		{
			if (!RoleDevelopUtil.IsHotRole(id))
			{
				return null;
			}
			int gachaId = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(id).GachaId;
			if (checkValid && !RoleDevelopUtil.IsGachaValid(gachaId))
			{
				return null;
			}
			return new int?(gachaId);
		}

		// Token: 0x06035372 RID: 217970 RVA: 0x00D565E8 File Offset: 0x00D547E8
		public static List<int> GetHotRoleSpecialGachaIds(int id, bool checkValid = false)
		{
			List<int> list = new List<int>();
			if (!RoleDevelopUtil.IsHotRole(id))
			{
				return list;
			}
			foreach (IRoleDevProsSpecialGachaConfig roleDevProsSpecialGachaConfig in ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(id).SpecialGachaId)
			{
				if (!checkValid || RoleDevelopUtil.IsGachaValid(roleDevProsSpecialGachaConfig.GachaId))
				{
					list.Add(roleDevProsSpecialGachaConfig.GachaId);
				}
			}
			return list;
		}

		// Token: 0x06035373 RID: 217971 RVA: 0x00D5666C File Offset: 0x00D5486C
		public static List<int> GetHotRoleGachaIds(int id, bool checkValid = false)
		{
			List<int> list = new List<int>();
			int? hotRoleGachaId = RoleDevelopUtil.GetHotRoleGachaId(id, checkValid);
			if (hotRoleGachaId != null)
			{
				list.Add(hotRoleGachaId.Value);
			}
			List<int> hotRoleSpecialGachaIds = RoleDevelopUtil.GetHotRoleSpecialGachaIds(id, checkValid);
			list.AddRange(hotRoleSpecialGachaIds);
			return list;
		}

		// Token: 0x06035374 RID: 217972 RVA: 0x00D566AD File Offset: 0x00D548AD
		public static bool IsGachaValid(int gachaId)
		{
			return ModelBase<GachaModel>.Instance.CheckGachaValidByGachaId(gachaId);
		}

		// Token: 0x06035375 RID: 217973 RVA: 0x00D566BA File Offset: 0x00D548BA
		public static List<int> GetHotWeaponGachaIds(int id, bool checkValid = false)
		{
			if (!RoleDevelopUtil.IsHotRole(id))
			{
				return new List<int>();
			}
			if (ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(id).TypeId != 4)
			{
				return new List<int>();
			}
			return RoleDevelopUtil.GetHotRoleGachaIds(id, checkValid);
		}

		// Token: 0x06035376 RID: 217974 RVA: 0x00D566EC File Offset: 0x00D548EC
		public static void OpenWeaponReplaceView(int roleId, int weaponIncId)
		{
			RoleViewViewModel roleViewViewModel = new RoleViewViewModel(roleId, !Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor(), ERoleViewSource.Normal);
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

		// Token: 0x06035377 RID: 217975 RVA: 0x00D56778 File Offset: 0x00D54978
		public static int GetDefaultRecommendPlanId(int roleId)
		{
			List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(roleId);
			if (roleFetterRecommendInfo == null)
			{
				return 0;
			}
			RoleDevelopUtil.SortVisionFetterRecommendInfo(roleFetterRecommendInfo);
			return roleFetterRecommendInfo[0].GetPlanId();
		}

		// Token: 0x06035378 RID: 217976 RVA: 0x00D567AC File Offset: 0x00D549AC
		public static List<int> GetDefaultRecommendFetterGroupIdList(int roleId)
		{
			List<int> list = new List<int>();
			List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(roleId);
			if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
			{
				return list;
			}
			RoleDevelopUtil.SortVisionFetterRecommendInfo(roleFetterRecommendInfo);
			VisionFetterRecommendInfo visionFetterRecommendInfo = roleFetterRecommendInfo[0];
			int recommendFetterGroupId = visionFetterRecommendInfo.GetRecommendFetterGroupId();
			EFetterGroupType fetterType = visionFetterRecommendInfo.GetFetterType();
			if (ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.GetPhantomSpecialGroupListArray().Contains(recommendFetterGroupId))
			{
				foreach (IVisionFetterCount visionFetterCount in visionFetterRecommendInfo.GetFetterCountList())
				{
					list.Add(visionFetterCount.GroupId);
				}
				return list;
			}
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup = (instance != null) ? instance.GetPhantomJumpGroupConfig(recommendFetterGroupId) : null;
			if (roleDevPhantomJumpGroup == null)
			{
				return list;
			}
			list.Add(recommendFetterGroupId);
			if (fetterType == EFetterGroupType.Special)
			{
				int specialFetterSubGroupId = visionFetterRecommendInfo.GetSpecialFetterSubGroupId();
				if (specialFetterSubGroupId > 0)
				{
					RoleDevConfig instance2 = ConfigBase<RoleDevConfig>.Instance;
					RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup2 = (instance2 != null) ? instance2.GetPhantomJumpGroupConfig(specialFetterSubGroupId) : null;
					if (roleDevPhantomJumpGroup2 != null)
					{
						list.Add(specialFetterSubGroupId);
					}
				}
			}
			return list;
		}

		// Token: 0x06035379 RID: 217977 RVA: 0x00D568DC File Offset: 0x00D54ADC
		public static List<VisionFetterRecommendInfo> SortVisionFetterRecommendInfo(List<VisionFetterRecommendInfo> recommendInfo)
		{
			recommendInfo.Sort((VisionFetterRecommendInfo a, VisionFetterRecommendInfo b) => b.GetUsage() - a.GetUsage());
			return recommendInfo;
		}

		// Token: 0x0603537A RID: 217978 RVA: 0x00D56904 File Offset: 0x00D54B04
		public static List<RoleDevelopPhantomSuitData> CreatePhantomSuitDataList(int id, List<VisionFetterRecommendInfo> recommendInfo, int recommendPlanId, int? recommendFirstVisionMonsterId = null)
		{
			List<RoleDevelopPhantomSuitData> list = new List<RoleDevelopPhantomSuitData>();
			if (recommendInfo == null || recommendInfo.Count == 0)
			{
				return list;
			}
			VisionFetterRecommendInfo visionFetterRecommendInfo = null;
			foreach (VisionFetterRecommendInfo visionFetterRecommendInfo2 in recommendInfo)
			{
				if (visionFetterRecommendInfo2.GetPlanId() == recommendPlanId)
				{
					visionFetterRecommendInfo = visionFetterRecommendInfo2;
					break;
				}
			}
			if (visionFetterRecommendInfo == null)
			{
				foreach (VisionFetterRecommendInfo visionFetterRecommendInfo3 in recommendInfo)
				{
					if (visionFetterRecommendInfo3.GetRecommendFetterGroupId() == recommendPlanId)
					{
						visionFetterRecommendInfo = visionFetterRecommendInfo3;
						break;
					}
				}
			}
			if (visionFetterRecommendInfo == null)
			{
				return list;
			}
			int recommendFetterGroupId = visionFetterRecommendInfo.GetRecommendFetterGroupId();
			EFetterGroupType fetterType = visionFetterRecommendInfo.GetFetterType();
			if (ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.GetPhantomSpecialGroupListArray().Contains(recommendFetterGroupId))
			{
				foreach (IVisionFetterCount visionFetterCount in visionFetterRecommendInfo.GetFetterCountList())
				{
					list.Add(new RoleDevelopPhantomSuitData
					{
						DevelopRoleId = id,
						FetterGroupId = visionFetterCount.GroupId,
						VisionFetterRecommendInfo = visionFetterRecommendInfo,
						FirstVisionMonsterId = recommendFirstVisionMonsterId
					});
				}
				return list;
			}
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup = (instance != null) ? instance.GetPhantomJumpGroupConfig(recommendFetterGroupId) : null;
			if (roleDevPhantomJumpGroup == null)
			{
				return list;
			}
			list.Add(new RoleDevelopPhantomSuitData
			{
				DevelopRoleId = id,
				FetterGroupId = recommendFetterGroupId,
				VisionFetterRecommendInfo = visionFetterRecommendInfo,
				FirstVisionMonsterId = recommendFirstVisionMonsterId
			});
			if (fetterType == EFetterGroupType.Special)
			{
				int specialFetterSubGroupId = visionFetterRecommendInfo.GetSpecialFetterSubGroupId();
				if (specialFetterSubGroupId > 0)
				{
					RoleDevConfig instance2 = ConfigBase<RoleDevConfig>.Instance;
					RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup2 = (instance2 != null) ? instance2.GetPhantomJumpGroupConfig(specialFetterSubGroupId) : null;
					if (roleDevPhantomJumpGroup2 != null)
					{
						list.Add(new RoleDevelopPhantomSuitData
						{
							DevelopRoleId = id,
							FetterGroupId = specialFetterSubGroupId,
							VisionFetterRecommendInfo = visionFetterRecommendInfo,
							FirstVisionMonsterId = recommendFirstVisionMonsterId
						});
					}
				}
			}
			return list;
		}

		// Token: 0x0603537B RID: 217979 RVA: 0x00D56B10 File Offset: 0x00D54D10
		public static RoleDevelopPhantomVisionSuitItemData CreateFetterGroupVisionSuitItem(int fetterGroupId, int roleId, int firstVisionMonsterId)
		{
			Aki.Config.PhantomItem phantomItem = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(firstVisionMonsterId)[0];
			return new RoleDevelopPhantomVisionSuitItemData
			{
				Name = phantomItem.MonsterName,
				ButtonName = "RoleProject_Button02",
				ItemType = EPhantomSuitItemType.Phantom,
				TypeIcon = "",
				MonsterDataList = new List<PhantomMonsterItemData>
				{
					new PhantomMonsterItemData
					{
						MonsterId = phantomItem.MonsterId,
						QualityId = 0,
						RoleId = roleId
					}
				},
				DungeonId = 0,
				FetterGroupId = fetterGroupId,
				RoleId = roleId,
				LogRoleId = new int?(roleId),
				LogMainPage = new ERoleDevelopCategoryType?(ERoleDevelopCategoryType.Phantom),
				LogSubPage = new ERoleDevelopLogSubPage?(ERoleDevelopLogSubPage.PhantomDevelopFirstVision)
			};
		}

		// Token: 0x0603537C RID: 217980 RVA: 0x00D56BCC File Offset: 0x00D54DCC
		public static RoleDevelopPhantomVisionSuitItemData CreateDungeonVisionSuitItem(int dungeonId, int roleId)
		{
			if (dungeonId == 0)
			{
				return null;
			}
			AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
			SilentAreaDetectionRecord silentAreaDetectionRecord = (instance != null) ? instance.GetSilentAreaDetectData(dungeonId) : null;
			if (silentAreaDetectionRecord == null || silentAreaDetectionRecord.IsLock)
			{
				return null;
			}
			SilentAreaDetection conf = silentAreaDetectionRecord.Conf;
			bool flag = conf.Secondary == 63 || conf.Secondary == 64;
			return new RoleDevelopPhantomVisionSuitItemData
			{
				Name = (conf.Name ?? ""),
				ButtonName = "RoleProject_Button03",
				ItemType = EPhantomSuitItemType.Dungeon,
				TypeIcon = conf.BigIcon,
				MonsterDataList = new List<PhantomMonsterItemData>(),
				RewardDataList = RoleDevelopUtil.GetDungeonDropRewards(conf),
				DungeonId = dungeonId,
				FetterGroupId = 0,
				RoleId = 0,
				LogRoleId = new int?(roleId),
				LogMainPage = new ERoleDevelopCategoryType?(ERoleDevelopCategoryType.Phantom),
				LogSubPage = new ERoleDevelopLogSubPage?(flag ? ERoleDevelopLogSubPage.PhantomDevelopNightMare : ERoleDevelopLogSubPage.PhantomDevelopVision)
			};
		}

		// Token: 0x0603537D RID: 217981 RVA: 0x00D56CB4 File Offset: 0x00D54EB4
		private static List<DropRewardItemData> GetDungeonDropRewards(SilentAreaDetection conf)
		{
			List<DropRewardItemData> list = new List<DropRewardItemData>();
			if (conf.ShowRewardMapLength != 0)
			{
				Dictionary<int, int> dictionary = (conf.Secondary == 63 || conf.Secondary == 64) ? ConfigBase<AdventureGuideConfig>.Instance.GetNightMareShowReward(conf.ShowRewardMapCalabash()) : ConfigBase<AdventureGuideConfig>.Instance.GetShowReward(conf.ShowRewardMap(), null);
				if (dictionary != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair in dictionary)
					{
						int key = keyValuePair.Key;
						int value = keyValuePair.Value;
						list.Add(new DropRewardItemData
						{
							ItemId = key,
							Count = value,
							HaveFinish = false
						});
					}
				}
			}
			return list;
		}

		// Token: 0x0603537E RID: 217982 RVA: 0x00D56D8C File Offset: 0x00D54F8C
		public static Dictionary<EItemMaterialType, int> ConvertSkillItemJumpTypes(List<IntArray> skillItemJumpTypes)
		{
			Dictionary<EItemMaterialType, int> dictionary = new Dictionary<EItemMaterialType, int>();
			foreach (IntArray intArray in skillItemJumpTypes)
			{
				if (intArray.ArrayIntLength >= 2)
				{
					EItemMaterialType key = (EItemMaterialType)intArray.GetArrayIntArray()[0];
					int value = intArray.GetArrayIntArray()[1];
					dictionary[key] = value;
				}
			}
			return dictionary;
		}

		// Token: 0x0603537F RID: 217983 RVA: 0x00D56E04 File Offset: 0x00D55004
		public static bool HandleItemJump(int roleId, RoleDevelopItemGroup groupItem)
		{
			Dictionary<EItemMaterialType, int> dictionary;
			if (RoleDevelopUtil.IsProspectRole(roleId))
			{
				dictionary = new Dictionary<EItemMaterialType, int>();
			}
			else
			{
				dictionary = RoleDevelopUtil.ConvertSkillItemJumpTypes(new List<IntArray>(ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId).Value.SkillItemJumpType()));
			}
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in groupItem.Items)
			{
				if (!RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem.ItemId))
				{
					RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(roleDevelopNeedItem.ItemId);
					if (itemJumpGroupConfig != null)
					{
						EItemMaterialType itemType = (EItemMaterialType)itemJumpGroupConfig.Value.ItemType;
						int detectionType = itemJumpGroupConfig.Value.DetectionType;
						EItemMaterialType key = itemType;
						int priorityIndex = dictionary.ContainsKey(key) ? dictionary[key] : 0;
						bool flag;
						if (detectionType == 1)
						{
							flag = RoleDevelopUtil.HandleDungeonDetectionJump(new List<int>(itemJumpGroupConfig.Value.DetectionID()), priorityIndex);
						}
						else if (detectionType == 2)
						{
							flag = RoleDevelopUtil.HandleSilentDetectionJump(new List<int>(itemJumpGroupConfig.Value.DetectionID()), priorityIndex);
						}
						else
						{
							flag = RoleDevelopUtil.HandlePathJump(new List<int>(itemJumpGroupConfig.Value.JumpGroup()), roleDevelopNeedItem.ItemId);
						}
						if (flag)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06035380 RID: 217984 RVA: 0x00D56F84 File Offset: 0x00D55184
		public static bool HandlePathJump(List<int> ids, int itemId)
		{
			foreach (int num in ids)
			{
				if (RoleDevelopUtil.CheckAccessPathUnlocked(num))
				{
					SkipTaskManager.RunByConfigId(num, itemId);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06035381 RID: 217985 RVA: 0x00D56FE8 File Offset: 0x00D551E8
		public static bool CheckAccessPathUnlocked(int accessPathId)
		{
			SkipInterfaceConfig instance = ConfigBase<SkipInterfaceConfig>.Instance;
			AccessPath? accessPath = (instance != null) ? instance.GetAccessPathConfig(accessPathId) : null;
			return accessPath == null || accessPath.Value.SkipName != 2 || RoleDevelopUtil.CheckDungeonAccessUnlocked(accessPath.Value);
		}

		// Token: 0x06035382 RID: 217986 RVA: 0x00D5703C File Offset: 0x00D5523C
		public static bool CheckDungeonAccessUnlocked(AccessPath config)
		{
			int id = int.Parse(config.Val1);
			InstanceDungeonEntrance? config2 = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(id);
			bool flag = false;
			foreach (int instanceId in config2.Value.GetInstanceDungeonListArray())
			{
				InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
				if (instance != null && instance.CheckInstanceUnlock(instanceId))
				{
					flag = true;
					break;
				}
			}
			int markId = int.Parse(config.Val3);
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			int areaId = ConfigBase<MapConfig>.Instance.GetEntityConfigByMapIdAndEntityId(configMark.Value.MapId, configMark.Value.EntityConfigId).Value.AreaId;
			Aki.Config.Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
			int areaId2 = (areaInfo != null) ? ModelBase<AreaModel>.Instance.GetAreaId(areaInfo.Value, new EAreaLevel?(EAreaLevel.FirstLevel)) : 0;
			bool flag2 = ModelBase<MapModel>.Instance.CheckAreasUnlocked(areaId2, true);
			return flag && flag2;
		}

		// Token: 0x06035383 RID: 217987 RVA: 0x00D57148 File Offset: 0x00D55348
		public static bool HandleSilentDetectionJump(List<int> ids, int priorityIndex)
		{
			if (ids == null || ids.Count == 0)
			{
				return false;
			}
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
				return false;
			}
			if (priorityIndex > 0 && priorityIndex <= ids.Count && RoleDevelopUtil.TryJumpSingleSilentAreaDetection(ids[priorityIndex - 1], false))
			{
				return true;
			}
			using (List<int>.Enumerator enumerator = ids.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (RoleDevelopUtil.TryJumpSingleSilentAreaDetection(enumerator.Current, false))
					{
						return true;
					}
				}
			}
			return RoleDevelopUtil.TryJumpSingleSilentAreaDetection(ids[ids.Count - 1], true);
		}

		// Token: 0x06035384 RID: 217988 RVA: 0x00D57200 File Offset: 0x00D55400
		public static bool HandleDungeonDetectionJump(List<int> ids, int priorityIndex)
		{
			if (ids == null || ids.Count == 0)
			{
				return false;
			}
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
				return false;
			}
			if (priorityIndex > 0 && priorityIndex <= ids.Count && RoleDevelopUtil.TryJumpSingleDungeonDetection(ids[priorityIndex - 1], false))
			{
				return true;
			}
			using (List<int>.Enumerator enumerator = ids.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (RoleDevelopUtil.TryJumpSingleDungeonDetection(enumerator.Current, false))
					{
						return true;
					}
				}
			}
			return RoleDevelopUtil.TryJumpSingleDungeonDetection(ids[ids.Count - 1], true);
		}

		// Token: 0x06035385 RID: 217989 RVA: 0x00D572B8 File Offset: 0x00D554B8
		private static bool TryPreOpenDetectionJump(int detectionId, ESoundAreaDataType soundAreaType, int preOpenId)
		{
			if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
			{
				return false;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PreOpenSpoilConfirmBoxFromRoleDev);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<AdventureGuideController>.Instance.HandlePreOpenDetection(detectionId, soundAreaType, preOpenId);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return true;
		}

		// Token: 0x06035386 RID: 217990 RVA: 0x00D57320 File Offset: 0x00D55520
		private static bool FocalDetectionMark(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark == null)
			{
				return false;
			}
			ControllerBase<WorldMapController>.Instance.FocalMarkItem((EMarkType)configMark.Value.ObjectType, markId);
			return true;
		}

		// Token: 0x06035387 RID: 217991 RVA: 0x00D57360 File Offset: 0x00D55560
		private static bool TryJumpSingleDungeonDetection(int detectionConfId, bool skipUnlockCheck = false)
		{
			if (detectionConfId == 0)
			{
				return false;
			}
			DungeonDetectionRecord soundAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSoundAreaDetectData(detectionConfId);
			if (soundAreaDetectData == null)
			{
				return false;
			}
			bool isDetectionPreOpenByRecord = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByRecord(soundAreaDetectData);
			if (soundAreaDetectData.IsLock)
			{
				if (isDetectionPreOpenByRecord)
				{
					return RoleDevelopUtil.TryPreOpenDetectionJump(soundAreaDetectData.Conf.Id, ESoundAreaDataType.Dungeon, soundAreaDetectData.Conf.PreOpenId);
				}
				if (skipUnlockCheck)
				{
					InstanceDungeonEntrance? config = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(soundAreaDetectData.Conf.DungeonId);
					if (config != null)
					{
						return RoleDevelopUtil.FocalDetectionMark(config.Value.MarkId);
					}
				}
				return false;
			}
			else
			{
				if (isDetectionPreOpenByRecord)
				{
					return RoleDevelopUtil.TryPreOpenDetectionJump(soundAreaDetectData.Conf.Id, ESoundAreaDataType.Dungeon, soundAreaDetectData.Conf.PreOpenId);
				}
				InstanceDungeonEntrance? config = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(soundAreaDetectData.Conf.DungeonId);
				if (config == null)
				{
					return false;
				}
				if (ModelBase<AdventureGuideModel>.Instance.TryAdventureJumpByDungeon(soundAreaDetectData))
				{
					return true;
				}
				if (!skipUnlockCheck)
				{
					if (!ControllerBase<AdventureGuideController>.Instance.IsMarkUnlock(config.Value.MarkId))
					{
						return false;
					}
					if (!ModelBase<MapModel>.Instance.CheckTeleportUnlocked(config.Value.MarkId))
					{
						return false;
					}
				}
				DetectionType type = (soundAreaDetectData.Conf.Secondary != 2) ? DetectionType.Dungeon : DetectionType.SilentArea;
				ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
				ControllerBase<AdventureGuideController>.Instance.RequestForDetection(type, new int[]
				{
					soundAreaDetectData.Conf.DungeonId
				}, soundAreaDetectData.Conf.Id);
				return true;
			}
		}

		// Token: 0x06035388 RID: 217992 RVA: 0x00D574F0 File Offset: 0x00D556F0
		private static bool TryJumpSingleSilentAreaDetection(int detectionConfId, bool skipUnlockCheck = false)
		{
			if (detectionConfId == 0)
			{
				return false;
			}
			SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(detectionConfId);
			if (silentAreaDetectData == null)
			{
				return false;
			}
			bool isDetectionPreOpenByRecord = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByRecord(silentAreaDetectData);
			if (silentAreaDetectData.IsLock)
			{
				if (isDetectionPreOpenByRecord)
				{
					return RoleDevelopUtil.TryPreOpenDetectionJump(silentAreaDetectData.Conf.Id, ESoundAreaDataType.SilentArea, silentAreaDetectData.Conf.PreOpenId);
				}
				return skipUnlockCheck && RoleDevelopUtil.FocalDetectionMark(silentAreaDetectData.Conf.MarkId);
			}
			else
			{
				if (isDetectionPreOpenByRecord)
				{
					return RoleDevelopUtil.TryPreOpenDetectionJump(silentAreaDetectData.Conf.Id, ESoundAreaDataType.SilentArea, silentAreaDetectData.Conf.PreOpenId);
				}
				if (ModelBase<AdventureGuideModel>.Instance.TryAdventureJumpBySilent(silentAreaDetectData))
				{
					return true;
				}
				if (!skipUnlockCheck)
				{
					if (!ControllerBase<AdventureGuideController>.Instance.IsMarkUnlock(silentAreaDetectData.Conf.MarkId))
					{
						return false;
					}
					if (!ModelBase<MapModel>.Instance.CheckTeleportUnlocked(silentAreaDetectData.Conf.MarkId))
					{
						return false;
					}
				}
				ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
				ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.SilentArea, silentAreaDetectData.Conf.GetLevelPlayListArray(), silentAreaDetectData.Conf.Id);
				return true;
			}
		}

		// Token: 0x06035389 RID: 217993 RVA: 0x00D5760C File Offset: 0x00D5580C
		public static bool IsDungeonShowDouble(EDungeonType dungeonType)
		{
			ActivityDoubleRewardData adventureUpActivity = ControllerBase<ActivityDoubleRewardController>.Instance.GetAdventureUpActivity(dungeonType);
			return (adventureUpActivity != null && adventureUpActivity.LeftUpCount > 0) || ModelBase<ActivityRegressModel>.Instance.IsHasDoubleDrop(dungeonType);
		}

		// Token: 0x0603538A RID: 217994 RVA: 0x00D57644 File Offset: 0x00D55844
		public static List<EDungeonType> GetDungeonTypesByItemDetection(List<RoleDevelopNeedItem> items)
		{
			HashSet<EDungeonType> hashSet = new HashSet<EDungeonType>();
			AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in items)
			{
				if (!RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem.ItemId))
				{
					RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(roleDevelopNeedItem.ItemId);
					if (itemJumpGroupConfig != null)
					{
						int detectionType = itemJumpGroupConfig.Value.DetectionType;
						foreach (int id in itemJumpGroupConfig.Value.DetectionID())
						{
							EDungeonType? edungeonType = null;
							if (detectionType == 1)
							{
								DungeonDetectionRecord soundAreaDetectData = instance.GetSoundAreaDetectData(id);
								if (soundAreaDetectData != null)
								{
									edungeonType = new EDungeonType?((EDungeonType)soundAreaDetectData.Conf.Secondary);
								}
							}
							else if (detectionType == 2)
							{
								SilentAreaDetectionRecord silentAreaDetectData = instance.GetSilentAreaDetectData(id);
								if (silentAreaDetectData != null)
								{
									edungeonType = new EDungeonType?((EDungeonType)silentAreaDetectData.Conf.Secondary);
								}
							}
							if (edungeonType != null)
							{
								hashSet.Add(edungeonType.Value);
							}
						}
					}
				}
			}
			return hashSet.ToList<EDungeonType>();
		}
	}
}
