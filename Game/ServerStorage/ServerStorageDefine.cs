using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.ServerStorage
{
	// Token: 0x02004729 RID: 18217
	public class ServerStorageDefine
	{
		// Token: 0x0401AF15 RID: 110357
		public const int SERVER_STORAGE_SAVE_DELAY = 3000;

		// Token: 0x0401AF16 RID: 110358
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static IReadOnlyDictionary<EClientStorageSystemIdType, Func<EClientStorageSystemIdType, ServerStorageEntryBase>> ServerStorageEntryRegistry = new Dictionary<EClientStorageSystemIdType, Func<EClientStorageSystemIdType, ServerStorageEntryBase>>
		{
			{
				EClientStorageSystemIdType.Default,
				delegate(EClientStorageSystemIdType key)
				{
					throw new InvalidOperationException("None key is not valid");
				}
			},
			{
				EClientStorageSystemIdType.Activity,
				(EClientStorageSystemIdType key) => new ServerStorageMapMap(key)
			},
			{
				EClientStorageSystemIdType.VisionSkin,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.LoopTowerIsClickSeason,
				(EClientStorageSystemIdType key) => new ServerStorageNumber(key)
			},
			{
				EClientStorageSystemIdType.LoopTowerIsClickShop,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.TowerOverLockArea,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.WeaponSkinRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.FlySkinRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.CalabashSkinRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.MailBindNextShowRedDotTime,
				(EClientStorageSystemIdType key) => new ServerStorageLong(key)
			},
			{
				EClientStorageSystemIdType.RedDotAdventureNewSoundAreaTabLastUpdateTime,
				(EClientStorageSystemIdType key) => new ServerStorageLong(key)
			},
			{
				EClientStorageSystemIdType.SuitWeaponFirstWearRecord,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.RoleSkinRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.FirstOpenVisionGroup,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.ShipTowerSeason,
				(EClientStorageSystemIdType key) => new ServerStorageNumber(key)
			},
			{
				EClientStorageSystemIdType.AdventrueShipTowerSeason,
				(EClientStorageSystemIdType key) => new ServerStorageNumber(key)
			},
			{
				EClientStorageSystemIdType.AdventrueWeeklyRogue,
				(EClientStorageSystemIdType key) => new ServerStorageNumber(key)
			},
			{
				EClientStorageSystemIdType.AdventrueTower,
				(EClientStorageSystemIdType key) => new ServerStorageNumber(key)
			},
			{
				EClientStorageSystemIdType.IntroductionVersion,
				(EClientStorageSystemIdType key) => new ServerStorageString(key)
			},
			{
				EClientStorageSystemIdType.DetectionRedDotRecord,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.ExploreActivityFirstUnlock,
				(EClientStorageSystemIdType key) => new ServerStorageNumber(key)
			},
			{
				EClientStorageSystemIdType.FilterRedPoint,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.VisionRecoveryBatchTip,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.VisionRecoveryBatchAimTip,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.MotorDiyNewUnlockId,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.MotorSceneHadCheck,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.MotorDevelopNewUnlockTree,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.PhantomBattleConfigApplyPlanWhenSaved,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.FeiXuePreheatSubViewRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.DropCatchRoleClickDetail,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.FlagChallengeNewlyUnlockedLevelIds,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.FlagChallengeNewlyUnlockedBuff,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.PeriodicActivityRedLogReport,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.CoopRolePhotoRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.CoopRoleNewLevelRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.FlagChallengeNewlyUnlockedBuffIds,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.RoguelikeNewPhantomUnlock,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.RoguelikeNewCharacterUnlock,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.RoguelikeNewEntriesGroupUnlock,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.AnniversaryActivityFirstClick,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.VisionRefineTip,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.Ornament,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.GetOrnament,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.GolemCrack,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.GachaAccumulateFirstOpen,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.Photography,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.PhoneMsgChatShowRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.ItemBackpackFirstCheck,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.QuestBranchSystem,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.WheelTowerSeasonReview,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.ThroughTrainFirstCheck,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.VersionPayGiftRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.NormalPayGiftRedDot,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.FightPhotoTab,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			},
			{
				EClientStorageSystemIdType.FirstOpenDailyActivityTab,
				(EClientStorageSystemIdType key) => new ServerStorageMap(key)
			},
			{
				EClientStorageSystemIdType.ActivityRecommend,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.RoleLangCustomFuncClicked,
				(EClientStorageSystemIdType key) => new ServerStorageBoolean(key)
			},
			{
				EClientStorageSystemIdType.RoleLangCustomRecord,
				(EClientStorageSystemIdType key) => new ServerStorageSet(key)
			}
		};
	}
}
