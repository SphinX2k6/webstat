using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.VillageInfr;

namespace CSharpScript.Game.Module.Map.Marks
{
	// Token: 0x02005831 RID: 22577
	[NullableContext(2)]
	[Nullable(0)]
	public static class MarkItemDataUtil
	{
		// Token: 0x06039653 RID: 235091 RVA: 0x00E91D50 File Offset: 0x00E8FF50
		public static EMarkType TransformMarkTypeToClient(int markType)
		{
			return MarkItemDataUtil.TransformMarkTypeMap.GetValueOrDefault((PbMapMarkType.Types.ENUMS)markType, EMarkType.None);
		}

		// Token: 0x06039654 RID: 235092 RVA: 0x00E91D6C File Offset: 0x00E8FF6C
		public static string GetMarkIcon(int markConfigId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markConfigId);
			if (configMark == null)
			{
				return null;
			}
			EMarkType objectType = (EMarkType)configMark.Value.ObjectType;
			if (objectType != EMarkType.SceneGameplay && objectType != EMarkType.FixedSceneGameplay)
			{
				if (objectType - EMarkType.HonamiScan > 1)
				{
					return configMark.Value.LockMarkPic;
				}
				if (ModelBase<MapModel>.Instance.IsConfigMarkIdUnlock(markConfigId))
				{
					return configMark.Value.UnlockMarkPic;
				}
				return configMark.Value.LockMarkPic;
			}
			else
			{
				global::LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(configMark.Value.RelativeId);
				if (levelPlayInfo == null || levelPlayInfo.IsClose)
				{
					return configMark.Value.LockMarkPic;
				}
				return configMark.Value.UnlockMarkPic;
			}
		}

		// Token: 0x06039655 RID: 235093 RVA: 0x00E91E34 File Offset: 0x00E90034
		public static string GetMarkTopRightIconPath(int markId, EMarkType markType, bool isDisable, bool isGameplayFinish)
		{
			if (isDisable)
			{
				return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkBlock");
			}
			if (ModelBase<MapModel>.Instance.IsCompleteMark(markId))
			{
				return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComIconFinish");
			}
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (isGameplayFinish && (!MapDefine.CanDisableGameplayFinishMarkType.Contains(markType) || configMark == null || !configMark.GetValueOrDefault().IsDisableGameplayFinishIcon))
			{
				return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComIconFinish");
			}
			if (configMark != null)
			{
				MapMark value = configMark.Value;
				int relativeSubType = value.RelativeSubType;
				if (relativeSubType == 9 || relativeSubType == 10)
				{
					ValueTuple<int, int> nightMareTarget = ModelBase<AdventureGuideModel>.Instance.GetNightMareTarget(new int?(value.MapId), new int?(value.RelativeId));
					if (nightMareTarget.Item1 == nightMareTarget.Item2 && nightMareTarget.Item2 > 0)
					{
						return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkTimeLimit");
					}
				}
				if (relativeSubType == 7)
				{
					int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
					FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId);
					FlagChallengeStrongholdData flagChallengeStrongholdData = (flagChallengeData != null) ? flagChallengeData.GetStrongholdDataByMarkId(markId) : null;
					if (flagChallengeStrongholdData != null && flagChallengeStrongholdData.IsPass)
					{
						return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComIconFinish");
					}
				}
			}
			if (markType == EMarkType.InfrRoad)
			{
				InfrRoadBuild? roadConfigByMarkId = ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigByMarkId(markId);
				if (ModelBase<InfrastructureModel>.Instance.GetRoadMaterialEnough(roadConfigByMarkId.Value.Id))
				{
					return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_InfrastructureUpgradeIcon");
				}
			}
			if (markType == EMarkType.VillageInfr && ModelBase<VillageInfrModel>.Instance.GetCanVillageLevelUp())
			{
				return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_InfrastructureUpgradeIcon");
			}
			if (markType == EMarkType.VillageInfrTree)
			{
				InfrV2TreeBuild? treeConfigByMarkId = ConfigBase<VillageInfrConfig>.Instance.GetTreeConfigByMarkId(markId);
				if (treeConfigByMarkId != null)
				{
					InfrV2TreeBuild valueOrDefault = treeConfigByMarkId.GetValueOrDefault();
					if (ModelBase<VillageInfrModel>.Instance.GetCanTreeLevelUp(valueOrDefault.Id))
					{
						return ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_InfrastructureUpgradeIcon");
					}
				}
			}
			return null;
		}

		// Token: 0x06039656 RID: 235094 RVA: 0x00E92020 File Offset: 0x00E90220
		public static bool IsCommonGamePlayMarkComplete(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark == null)
			{
				return false;
			}
			LevelPlayReportModel instance = ModelBase<LevelPlayReportModel>.Instance;
			if (instance.IsCommonLevelPlayComplete(configMark.Value.RelativeDungeonId, configMark.Value.RelativeId))
			{
				return true;
			}
			if (configMark.Value.ObjectType != 29)
			{
				return false;
			}
			for (int i = 0; i < configMark.Value.AssociatedGameplayMarksLength; i++)
			{
				int markId2 = configMark.Value.AssociatedGameplayMarks(i);
				MapMark? configMark2 = ConfigBase<MapConfig>.Instance.GetConfigMark(markId2);
				if (configMark2 != null && instance.IsCommonLevelPlayComplete(configMark2.Value.RelativeDungeonId, configMark2.Value.RelativeId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06039657 RID: 235095 RVA: 0x00E920F4 File Offset: 0x00E902F4
		// Note: this type is marked as 'beforefieldinit'.
		static MarkItemDataUtil()
		{
			Dictionary<PbMapMarkType.Types.ENUMS, EMarkType> dictionary = new Dictionary<PbMapMarkType.Types.ENUMS, EMarkType>();
			dictionary[PbMapMarkType.Types.ENUMS.None] = EMarkType.None;
			dictionary[PbMapMarkType.Types.ENUMS.Custom] = EMarkType.Custom;
			dictionary[PbMapMarkType.Types.ENUMS.Quest] = EMarkType.Quest;
			dictionary[PbMapMarkType.Types.ENUMS.TemporaryTeleport] = EMarkType.TemporaryTeleport;
			dictionary[PbMapMarkType.Types.ENUMS.SoundBox] = EMarkType.SoundBox;
			dictionary[PbMapMarkType.Types.ENUMS.HookLockSoundBox] = EMarkType.SoundBox;
			dictionary[PbMapMarkType.Types.ENUMS.TreasureBoxPoint] = EMarkType.TreasureBoxDetector;
			dictionary[PbMapMarkType.Types.ENUMS.TreasureBox] = EMarkType.TreasureBox;
			dictionary[PbMapMarkType.Types.ENUMS.CalmingWindBell] = EMarkType.CalmingWindBell;
			dictionary[PbMapMarkType.Types.ENUMS.EnrichmentArea] = EMarkType.EnrichmentArea;
			dictionary[PbMapMarkType.Types.ENUMS.EnrichmentAreaChild] = EMarkType.EnrichmentCollectProduct;
			dictionary[PbMapMarkType.Types.ENUMS.HonamiStory] = EMarkType.HonamiScan;
			dictionary[PbMapMarkType.Types.ENUMS.HonamiStoryChild] = EMarkType.HonamiScanItem;
			dictionary[PbMapMarkType.Types.ENUMS.LahairoHookLock] = EMarkType.SoundBox;
			dictionary[PbMapMarkType.Types.ENUMS.LiangYuanSoundBox] = EMarkType.SoundBox;
			MarkItemDataUtil.TransformMarkTypeMap = dictionary;
		}

		// Token: 0x04020A31 RID: 133681
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<PbMapMarkType.Types.ENUMS, EMarkType> TransformMarkTypeMap;
	}
}
