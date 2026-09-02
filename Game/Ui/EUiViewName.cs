using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Utils.StaticVariableReset;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049E0 RID: 18912
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariablePriority(50)]
	public readonly struct EUiViewName : IEquatable<EUiViewName>, IStaticVariableResetter
	{
		// Token: 0x06031780 RID: 202624 RVA: 0x00C4F6AA File Offset: 0x00C4D8AA
		private EUiViewName(string value)
		{
			this._value = value;
		}

		// Token: 0x06031781 RID: 202625 RVA: 0x00C4F6B3 File Offset: 0x00C4D8B3
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x06031782 RID: 202626 RVA: 0x00C4F6BB File Offset: 0x00C4D8BB
		public bool Equals(EUiViewName other)
		{
			return this._value == other._value;
		}

		// Token: 0x06031783 RID: 202627 RVA: 0x00C4F6D0 File Offset: 0x00C4D8D0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EUiViewName)
			{
				EUiViewName other = (EUiViewName)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06031784 RID: 202628 RVA: 0x00C4F6F5 File Offset: 0x00C4D8F5
		public override int GetHashCode()
		{
			string value = this._value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06031785 RID: 202629 RVA: 0x00C4F708 File Offset: 0x00C4D908
		public static bool operator ==(EUiViewName left, EUiViewName right)
		{
			return left.Equals(right);
		}

		// Token: 0x06031786 RID: 202630 RVA: 0x00C4F712 File Offset: 0x00C4D912
		public static bool operator !=(EUiViewName left, EUiViewName right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06031787 RID: 202631 RVA: 0x00C4F71F File Offset: 0x00C4D91F
		public static implicit operator string(EUiViewName name)
		{
			return name._value;
		}

		// Token: 0x06031788 RID: 202632 RVA: 0x00C4F727 File Offset: 0x00C4D927
		public static explicit operator EUiViewName(string value)
		{
			return new EUiViewName(value);
		}

		// Token: 0x06031789 RID: 202633 RVA: 0x00C4F72F File Offset: 0x00C4D92F
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0603178A RID: 202634 RVA: 0x00C4F731 File Offset: 0x00C4D931
		public static void ResetStaticDefaultValue()
		{
		}

		// Token: 0x0401C627 RID: 116263
		private readonly string _value;

		// Token: 0x0401C628 RID: 116264
		public static readonly EUiViewName All = new EUiViewName("All");

		// Token: 0x0401C629 RID: 116265
		public static readonly EUiViewName BattleView = new EUiViewName("BattleView");

		// Token: 0x0401C62A RID: 116266
		public static readonly EUiViewName MailBoxView = new EUiViewName("MailBoxView");

		// Token: 0x0401C62B RID: 116267
		public static readonly EUiViewName MailContentView = new EUiViewName("MailContentView");

		// Token: 0x0401C62C RID: 116268
		public static readonly EUiViewName WorldMapView = new EUiViewName("WorldMapView");

		// Token: 0x0401C62D RID: 116269
		public static readonly EUiViewName RoleRootView = new EUiViewName("RoleRootView");

		// Token: 0x0401C62E RID: 116270
		public static readonly EUiViewName RolePreviewRootView = new EUiViewName("RolePreviewRootView");

		// Token: 0x0401C62F RID: 116271
		public static readonly EUiViewName RoleNewJoinRootView = new EUiViewName("RoleNewJoinRootView");

		// Token: 0x0401C630 RID: 116272
		public static readonly EUiViewName RoleBreachView = new EUiViewName("RoleBreachView");

		// Token: 0x0401C631 RID: 116273
		public static readonly EUiViewName RoleSkillView = new EUiViewName("RoleSkillView");

		// Token: 0x0401C632 RID: 116274
		public static readonly EUiViewName RoleLevelUpView = new EUiViewName("RoleLevelUpView");

		// Token: 0x0401C633 RID: 116275
		public static readonly EUiViewName RoleSelectionView = new EUiViewName("RoleSelectionView");

		// Token: 0x0401C634 RID: 116276
		public static readonly EUiViewName RoleNewJoinView = new EUiViewName("RoleNewJoinView");

		// Token: 0x0401C635 RID: 116277
		public static readonly EUiViewName RoleNewJoinTipView = new EUiViewName("RoleNewJoinTipView");

		// Token: 0x0401C636 RID: 116278
		public static readonly EUiViewName TeamRoleSelectView = new EUiViewName("TeamRoleSelectView");

		// Token: 0x0401C637 RID: 116279
		public static readonly EUiViewName TeamSceneRoleSelectView = new EUiViewName("TeamSceneRoleSelectView");

		// Token: 0x0401C638 RID: 116280
		public static readonly EUiViewName MultiTeamRoleSelectView = new EUiViewName("MultiTeamRoleSelectView");

		// Token: 0x0401C639 RID: 116281
		public static readonly EUiViewName QuickRoleSelectView = new EUiViewName("QuickRoleSelectView");

		// Token: 0x0401C63A RID: 116282
		public static readonly EUiViewName PersonalQuickRoleSelectView = new EUiViewName("PersonalQuickRoleSelectView");

		// Token: 0x0401C63B RID: 116283
		public static readonly EUiViewName TeamRoleSelectWithModelView = new EUiViewName("TeamRoleSelectWithModelView");

		// Token: 0x0401C63C RID: 116284
		public static readonly EUiViewName ShopView = new EUiViewName("ShopView");

		// Token: 0x0401C63D RID: 116285
		public static readonly EUiViewName AreaView = new EUiViewName("AreaView");

		// Token: 0x0401C63E RID: 116286
		public static readonly EUiViewName SubLevelLoadingView = new EUiViewName("SubLevelLoadingView");

		// Token: 0x0401C63F RID: 116287
		public static readonly EUiViewName LoginView = new EUiViewName("LoginView");

		// Token: 0x0401C640 RID: 116288
		public static readonly EUiViewName LoginQueueTipsView = new EUiViewName("LoginQueueTipsView");

		// Token: 0x0401C641 RID: 116289
		public static readonly EUiViewName LoginDebugView = new EUiViewName("LoginDebugView");

		// Token: 0x0401C642 RID: 116290
		public static readonly EUiViewName LoginDebugPlayerNameView = new EUiViewName("LoginDebugPlayerNameView");

		// Token: 0x0401C643 RID: 116291
		public static readonly EUiViewName ItemTipsView = new EUiViewName("ItemTipsView");

		// Token: 0x0401C644 RID: 116292
		public static readonly EUiViewName QuestView = new EUiViewName("QuestView");

		// Token: 0x0401C645 RID: 116293
		public static readonly EUiViewName BcView = new EUiViewName("BcView");

		// Token: 0x0401C646 RID: 116294
		public static readonly EUiViewName QuestHintView = new EUiViewName("QuestHintView");

		// Token: 0x0401C647 RID: 116295
		public static readonly EUiViewName NewItemTipsView = new EUiViewName("NewItemTipsView");

		// Token: 0x0401C648 RID: 116296
		public static readonly EUiViewName PhantomTipsView = new EUiViewName("PhantomTipsView");

		// Token: 0x0401C649 RID: 116297
		public static readonly EUiViewName FunctionView = new EUiViewName("FunctionView");

		// Token: 0x0401C64A RID: 116298
		public static readonly EUiViewName ItemHintView = new EUiViewName("ItemHintView");

		// Token: 0x0401C64B RID: 116299
		public static readonly EUiViewName EditFormationView = new EUiViewName("EditFormationView");

		// Token: 0x0401C64C RID: 116300
		public static readonly EUiViewName EditSceneFormationView = new EUiViewName("EditSceneFormationView");

		// Token: 0x0401C64D RID: 116301
		public static readonly EUiViewName ExitSkillView = new EUiViewName("ExitSkillView");

		// Token: 0x0401C64E RID: 116302
		public static readonly EUiViewName HelpView = new EUiViewName("HelpView");

		// Token: 0x0401C64F RID: 116303
		public static readonly EUiViewName InventoryView = new EUiViewName("InventoryView");

		// Token: 0x0401C650 RID: 116304
		public static readonly EUiViewName PhantomManageView = new EUiViewName("PhantomManageView");

		// Token: 0x0401C651 RID: 116305
		public static readonly EUiViewName PhantomManageConfigView = new EUiViewName("PhantomManageConfigView");

		// Token: 0x0401C652 RID: 116306
		public static readonly EUiViewName PhantomManageConfigSelectView = new EUiViewName("PhantomManageConfigSelectView");

		// Token: 0x0401C653 RID: 116307
		public static readonly EUiViewName PhantomManageConfigRenameInputView = new EUiViewName("PhantomManageConfigRenameInputView");

		// Token: 0x0401C654 RID: 116308
		public static readonly EUiViewName DestroyPreviewView = new EUiViewName("DestroyPreviewView");

		// Token: 0x0401C655 RID: 116309
		public static readonly EUiViewName GuideTipsView = new EUiViewName("GuideTipsView");

		// Token: 0x0401C656 RID: 116310
		public static readonly EUiViewName GuideTutorialView = new EUiViewName("GuideTutorialView");

		// Token: 0x0401C657 RID: 116311
		public static readonly EUiViewName GuideTutorialPopView = new EUiViewName("GuideTutorialPopView");

		// Token: 0x0401C658 RID: 116312
		public static readonly EUiViewName HelpGuideView = new EUiViewName("HelpGuideView");

		// Token: 0x0401C659 RID: 116313
		public static readonly EUiViewName SignalDeviceGuideView = new EUiViewName("SignalDeviceGuideView");

		// Token: 0x0401C65A RID: 116314
		public static readonly EUiViewName GuideFocusView = new EUiViewName("GuideFocusView");

		// Token: 0x0401C65B RID: 116315
		public static readonly EUiViewName GuideTutorialTipsView = new EUiViewName("GuideTutorialTipsView");

		// Token: 0x0401C65C RID: 116316
		public static readonly EUiViewName GmView = new EUiViewName("GmView");

		// Token: 0x0401C65D RID: 116317
		public static readonly EUiViewName ItemRewardView = new EUiViewName("ItemRewardView");

		// Token: 0x0401C65E RID: 116318
		public static readonly EUiViewName MView = new EUiViewName("MView");

		// Token: 0x0401C65F RID: 116319
		public static readonly EUiViewName AchievementRewardItemView = new EUiViewName("AchievementRewardItemView");

		// Token: 0x0401C660 RID: 116320
		public static readonly EUiViewName CipherView = new EUiViewName("CipherView");

		// Token: 0x0401C661 RID: 116321
		public static readonly EUiViewName TimeTrackControlView = new EUiViewName("TimeTrackControlView");

		// Token: 0x0401C662 RID: 116322
		public static readonly EUiViewName PickInteractionView = new EUiViewName("PickInteractionView");

		// Token: 0x0401C663 RID: 116323
		public static readonly EUiViewName MazeTipsLoseView = new EUiViewName("MazeTipsLoseView");

		// Token: 0x0401C664 RID: 116324
		public static readonly EUiViewName MazeTipsWinView = new EUiViewName("MazeTipsWinView");

		// Token: 0x0401C665 RID: 116325
		public static readonly EUiViewName TurntableControlView = new EUiViewName("TurntableControlView");

		// Token: 0x0401C666 RID: 116326
		public static readonly EUiViewName SundialControlView = new EUiViewName("SundialControlView");

		// Token: 0x0401C667 RID: 116327
		public static readonly EUiViewName EditBattleTeamView = new EUiViewName("EditBattleTeamView");

		// Token: 0x0401C668 RID: 116328
		public static readonly EUiViewName PlotSubtitleView = new EUiViewName("PlotSubtitleView");

		// Token: 0x0401C669 RID: 116329
		public static readonly EUiViewName PupuVillageItemView = new EUiViewName("PupuVillageItemView");

		// Token: 0x0401C66A RID: 116330
		public static readonly EUiViewName PupuVillageItemViewQIQIU = new EUiViewName("PupuVillageItemViewQIQIU");

		// Token: 0x0401C66B RID: 116331
		public static readonly EUiViewName PlotView = new EUiViewName("PlotView");

		// Token: 0x0401C66C RID: 116332
		public static readonly EUiViewName PlotViewHUD = new EUiViewName("PlotViewHUD");

		// Token: 0x0401C66D RID: 116333
		public static readonly EUiViewName PlotTransitionView = new EUiViewName("PlotTransitionView");

		// Token: 0x0401C66E RID: 116334
		public static readonly EUiViewName PlotTransitionViewPop = new EUiViewName("PlotTransitionViewPop");

		// Token: 0x0401C66F RID: 116335
		public static readonly EUiViewName PlotPhotoView = new EUiViewName("PlotPhotoView");

		// Token: 0x0401C670 RID: 116336
		public static readonly EUiViewName PlotLogoView = new EUiViewName("PlotLogoView");

		// Token: 0x0401C671 RID: 116337
		public static readonly EUiViewName PlotTipsView = new EUiViewName("PlotTipsView");

		// Token: 0x0401C672 RID: 116338
		public static readonly EUiViewName TransitionPopupView = new EUiViewName("TransitionPopupView");

		// Token: 0x0401C673 RID: 116339
		public static readonly EUiViewName MusicSubtitleView = new EUiViewName("MusicSubtitleView");

		// Token: 0x0401C674 RID: 116340
		public static readonly EUiViewName PlotHintView = new EUiViewName("PlotHintView");

		// Token: 0x0401C675 RID: 116341
		public static readonly EUiViewName SummaryPopView = new EUiViewName("SummaryPopView");

		// Token: 0x0401C676 RID: 116342
		public static readonly EUiViewName PlotReviewView = new EUiViewName("PlotReviewView");

		// Token: 0x0401C677 RID: 116343
		public static readonly EUiViewName AdmissionStudentCardView = new EUiViewName("AdmissionStudentCardView");

		// Token: 0x0401C678 RID: 116344
		public static readonly EUiViewName VideoPromptView = new EUiViewName("VideoPromptView");

		// Token: 0x0401C679 RID: 116345
		public static readonly EUiViewName NetWorkMaskView = new EUiViewName("NetWorkMaskView");

		// Token: 0x0401C67A RID: 116346
		public static readonly EUiViewName PlayStationNetWorkMaskView = new EUiViewName("PlayStationNetWorkMaskView");

		// Token: 0x0401C67B RID: 116347
		public static readonly EUiViewName CreateCharacterView = new EUiViewName("CreateCharacterView");

		// Token: 0x0401C67C RID: 116348
		public static readonly EUiViewName MingSuView = new EUiViewName("MingSuView");

		// Token: 0x0401C67D RID: 116349
		public static readonly EUiViewName WeaponRootView = new EUiViewName("WeaponRootView");

		// Token: 0x0401C67E RID: 116350
		public static readonly EUiViewName WeaponReplaceView = new EUiViewName("WeaponReplaceView");

		// Token: 0x0401C67F RID: 116351
		public static readonly EUiViewName WeaponBreachSuccessView = new EUiViewName("WeaponBreachSuccessView");

		// Token: 0x0401C680 RID: 116352
		public static readonly EUiViewName WeaponResonanceSuccessView = new EUiViewName("WeaponResonanceSuccessView");

		// Token: 0x0401C681 RID: 116353
		public static readonly EUiViewName GameplayEnterView = new EUiViewName("GameplayEnterView");

		// Token: 0x0401C682 RID: 116354
		public static readonly EUiViewName GameplayFirstPassView = new EUiViewName("GameplayFirstPassView");

		// Token: 0x0401C683 RID: 116355
		public static readonly EUiViewName InstanceDungeonEntranceView = new EUiViewName("InstanceDungeonEntranceView");

		// Token: 0x0401C684 RID: 116356
		public static readonly EUiViewName TowerDefenseLevelView = new EUiViewName("TowerDefenseLevelView");

		// Token: 0x0401C685 RID: 116357
		public static readonly EUiViewName InstanceDungeonVictoryView = new EUiViewName("InstanceDungeonVictoryView");

		// Token: 0x0401C686 RID: 116358
		public static readonly EUiViewName InstanceDungeonFailView = new EUiViewName("InstanceDungeonFailView");

		// Token: 0x0401C687 RID: 116359
		public static readonly EUiViewName InstanceDungeonReward = new EUiViewName("InstanceDungeonReward");

		// Token: 0x0401C688 RID: 116360
		public static readonly EUiViewName InstanceDungeonMonsterPreView = new EUiViewName("InstanceDungeonMonsterPreView");

		// Token: 0x0401C689 RID: 116361
		public static readonly EUiViewName InstanceDungeonAreaView = new EUiViewName("InstanceDungeonAreaView");

		// Token: 0x0401C68A RID: 116362
		public static readonly EUiViewName InstanceDungeonGuideView = new EUiViewName("InstanceDungeonGuideView");

		// Token: 0x0401C68B RID: 116363
		public static readonly EUiViewName LordGymEntranceView = new EUiViewName("LordGymEntranceView");

		// Token: 0x0401C68C RID: 116364
		public static readonly EUiViewName LordGymChallengeRecordView = new EUiViewName("LordGymChallengeRecordView");

		// Token: 0x0401C68D RID: 116365
		public static readonly EUiViewName LoginStatusView = new EUiViewName("LoginStatusView");

		// Token: 0x0401C68E RID: 116366
		public static readonly EUiViewName LoginOfficialStatusView = new EUiViewName("LoginOfficialStatusView");

		// Token: 0x0401C68F RID: 116367
		public static readonly EUiViewName PreDownloadView = new EUiViewName("PreDownloadView");

		// Token: 0x0401C690 RID: 116368
		public static readonly EUiViewName LordGymDifficultySelectView = new EUiViewName("LordGymDifficultySelectView");

		// Token: 0x0401C691 RID: 116369
		public static readonly EUiViewName LordGymLordEntranceSelectView = new EUiViewName("LordGymLordEntranceSelectView");

		// Token: 0x0401C692 RID: 116370
		public static readonly EUiViewName LordGymChallengeFailView = new EUiViewName("LordGymChallengeFailView");

		// Token: 0x0401C693 RID: 116371
		public static readonly EUiViewName LordGymThirdBossSelectView = new EUiViewName("LordGymThirdBossSelectView");

		// Token: 0x0401C694 RID: 116372
		public static readonly EUiViewName LordGymThirdDifficultySelectView = new EUiViewName("LordGymThirdDifficultySelectView");

		// Token: 0x0401C695 RID: 116373
		public static readonly EUiViewName LordGymThird5BossSelectView = new EUiViewName("LordGymThird5BossSelectView");

		// Token: 0x0401C696 RID: 116374
		public static readonly EUiViewName LordGymThird5DifficultySelectView = new EUiViewName("LordGymThird5DifficultySelectView");

		// Token: 0x0401C697 RID: 116375
		public static readonly EUiViewName LordGymThird5LittleLoadingView = new EUiViewName("LordGymThird5LittleLoadingView");

		// Token: 0x0401C698 RID: 116376
		public static readonly EUiViewName LordGymLoadingView = new EUiViewName("LordGymLoadingView");

		// Token: 0x0401C699 RID: 116377
		public static readonly EUiViewName LordGymThird5LoadingView = new EUiViewName("LordGymThird5LoadingView");

		// Token: 0x0401C69A RID: 116378
		public static readonly EUiViewName LordGymFirstBossSelectView = new EUiViewName("LordGymFirstBossSelectView");

		// Token: 0x0401C69B RID: 116379
		public static readonly EUiViewName LordGymFirstDifficultySelectView = new EUiViewName("LordGymFirstDifficultySelectView");

		// Token: 0x0401C69C RID: 116380
		public static readonly EUiViewName LordGymSecondBossSelectView = new EUiViewName("LordGymSecondBossSelectView");

		// Token: 0x0401C69D RID: 116381
		public static readonly EUiViewName LordGymSecondDifficultySelectView = new EUiViewName("LordGymSecondDifficultySelectView");

		// Token: 0x0401C69E RID: 116382
		public static readonly EUiViewName AdviceCreateView = new EUiViewName("AdviceCreateView");

		// Token: 0x0401C69F RID: 116383
		public static readonly EUiViewName AdviceMotionView = new EUiViewName("AdviceMotionView");

		// Token: 0x0401C6A0 RID: 116384
		public static readonly EUiViewName AdviceRoleView = new EUiViewName("AdviceRoleView");

		// Token: 0x0401C6A1 RID: 116385
		public static readonly EUiViewName AdviceView = new EUiViewName("AdviceView");

		// Token: 0x0401C6A2 RID: 116386
		public static readonly EUiViewName AdviceSortWordView = new EUiViewName("AdviceSortWordView");

		// Token: 0x0401C6A3 RID: 116387
		public static readonly EUiViewName AdviceMutiSentenceSelectView = new EUiViewName("AdviceMutiSentenceSelectView");

		// Token: 0x0401C6A4 RID: 116388
		public static readonly EUiViewName AdviceWordView = new EUiViewName("AdviceWordView");

		// Token: 0x0401C6A5 RID: 116389
		public static readonly EUiViewName AdviceExpressionView = new EUiViewName("AdviceExpressionView");

		// Token: 0x0401C6A6 RID: 116390
		public static readonly EUiViewName AdviceInfoView = new EUiViewName("AdviceInfoView");

		// Token: 0x0401C6A7 RID: 116391
		public static readonly EUiViewName PhantomHandBookView = new EUiViewName("PhantomHandBookView");

		// Token: 0x0401C6A8 RID: 116392
		public static readonly EUiViewName WeaponHandBookView = new EUiViewName("WeaponHandBookView");

		// Token: 0x0401C6A9 RID: 116393
		public static readonly EUiViewName MonsterHandBookView = new EUiViewName("MonsterHandBookView");

		// Token: 0x0401C6AA RID: 116394
		public static readonly EUiViewName ItemHandBookView = new EUiViewName("ItemHandBookView");

		// Token: 0x0401C6AB RID: 116395
		public static readonly EUiViewName AnimalHandBookView = new EUiViewName("AnimalHandBookView");

		// Token: 0x0401C6AC RID: 116396
		public static readonly EUiViewName ChipHandBookView = new EUiViewName("ChipHandBookView");

		// Token: 0x0401C6AD RID: 116397
		public static readonly EUiViewName NounHandBookView = new EUiViewName("NounHandBookView");

		// Token: 0x0401C6AE RID: 116398
		public static readonly EUiViewName GeographyHandBookView = new EUiViewName("GeographyHandBookView");

		// Token: 0x0401C6AF RID: 116399
		public static readonly EUiViewName QuestHandBookView = new EUiViewName("QuestHandBookView");

		// Token: 0x0401C6B0 RID: 116400
		public static readonly EUiViewName HandBookRoleView = new EUiViewName("HandBookRoleView");

		// Token: 0x0401C6B1 RID: 116401
		public static readonly EUiViewName HandBookQuestPlotView = new EUiViewName("HandBookQuestPlotView");

		// Token: 0x0401C6B2 RID: 116402
		public static readonly EUiViewName HandBookPhotoView = new EUiViewName("HandBookPhotoView");

		// Token: 0x0401C6B3 RID: 116403
		public static readonly EUiViewName HandBookEntranceView = new EUiViewName("HandBookEntranceView");

		// Token: 0x0401C6B4 RID: 116404
		public static readonly EUiViewName TeamTeleportFloatTips = new EUiViewName("TeamTeleportFloatTips");

		// Token: 0x0401C6B5 RID: 116405
		public static readonly EUiViewName SceneGameplayItemRewardView = new EUiViewName("SceneGameplayItemRewardView");

		// Token: 0x0401C6B6 RID: 116406
		public static readonly EUiViewName AccessPathPcView = new EUiViewName("AccessPathPcView");

		// Token: 0x0401C6B7 RID: 116407
		public static readonly EUiViewName TapeRootView = new EUiViewName("TapeRootView");

		// Token: 0x0401C6B8 RID: 116408
		public static readonly EUiViewName TapeReplaceView = new EUiViewName("TapeReplaceView");

		// Token: 0x0401C6B9 RID: 116409
		public static readonly EUiViewName PhantomExploreView = new EUiViewName("PhantomExploreView");

		// Token: 0x0401C6BA RID: 116410
		public static readonly EUiViewName ConfirmBoxView = new EUiViewName("ConfirmBoxView");

		// Token: 0x0401C6BB RID: 116411
		public static readonly EUiViewName ConfirmBoxMiddleView = new EUiViewName("ConfirmBoxMiddleView");

		// Token: 0x0401C6BC RID: 116412
		public static readonly EUiViewName ConfirmBoxMiddleWithoutItemView = new EUiViewName("ConfirmBoxMiddleWithoutItemView");

		// Token: 0x0401C6BD RID: 116413
		public static readonly EUiViewName PowerMagnificationRewardPopView = new EUiViewName("PowerMagnificationRewardPopView");

		// Token: 0x0401C6BE RID: 116414
		public static readonly EUiViewName VisionLevelUpSettingPopView = new EUiViewName("VisionLevelUpSettingPopView");

		// Token: 0x0401C6BF RID: 116415
		public static readonly EUiViewName ItemRewardWithMouseView = new EUiViewName("ItemRewardWithMouseView");

		// Token: 0x0401C6C0 RID: 116416
		public static readonly EUiViewName InteractionHintView = new EUiViewName("InteractionHintView");

		// Token: 0x0401C6C1 RID: 116417
		public static readonly EUiViewName VolumeView = new EUiViewName("VolumeView");

		// Token: 0x0401C6C2 RID: 116418
		public static readonly EUiViewName RoguePhantomSelectView = new EUiViewName("RoguePhantomSelectView");

		// Token: 0x0401C6C3 RID: 116419
		public static readonly EUiViewName RoguePhantomReplaceView = new EUiViewName("RoguePhantomReplaceView");

		// Token: 0x0401C6C4 RID: 116420
		public static readonly EUiViewName RoguePhantomSelectResultView = new EUiViewName("RoguePhantomSelectResultView");

		// Token: 0x0401C6C5 RID: 116421
		public static readonly EUiViewName RogueCharacterRoomSelectView = new EUiViewName("RogueCharacterRoomSelectView");

		// Token: 0x0401C6C6 RID: 116422
		public static readonly EUiViewName RoleBuffSelectView = new EUiViewName("RoleBuffSelectView");

		// Token: 0x0401C6C7 RID: 116423
		public static readonly EUiViewName RoleReplaceView = new EUiViewName("RoleReplaceView");

		// Token: 0x0401C6C8 RID: 116424
		public static readonly EUiViewName RogueRoleSelectResultView = new EUiViewName("RogueRoleSelectResultView");

		// Token: 0x0401C6C9 RID: 116425
		public static readonly EUiViewName RoguelikeSkillOverView = new EUiViewName("RoguelikeSkillOverView");

		// Token: 0x0401C6CA RID: 116426
		public static readonly EUiViewName CommonSelectView = new EUiViewName("CommonSelectView");

		// Token: 0x0401C6CB RID: 116427
		public static readonly EUiViewName CommonSelectResultView = new EUiViewName("CommonSelectResultView");

		// Token: 0x0401C6CC RID: 116428
		public static readonly EUiViewName RogueEventResultViewOneByOne = new EUiViewName("RogueEventResultViewOneByOne");

		// Token: 0x0401C6CD RID: 116429
		public static readonly EUiViewName RogueEventResultViewAll = new EUiViewName("RogueEventResultViewAll");

		// Token: 0x0401C6CE RID: 116430
		public static readonly EUiViewName WeeklyRoguePhantomRewardView = new EUiViewName("WeeklyRoguePhantomRewardView");

		// Token: 0x0401C6CF RID: 116431
		public static readonly EUiViewName WeeklyRogueShop = new EUiViewName("WeeklyRogueShop");

		// Token: 0x0401C6D0 RID: 116432
		public static readonly EUiViewName WeeklyRogueActivityView = new EUiViewName("WeeklyRogueActivityView");

		// Token: 0x0401C6D1 RID: 116433
		public static readonly EUiViewName WeeklyRogueSettleView = new EUiViewName("WeeklyRogueSettleView");

		// Token: 0x0401C6D2 RID: 116434
		public static readonly EUiViewName WeeklyRogueSelectToken = new EUiViewName("WeeklyRogueSelectToken");

		// Token: 0x0401C6D3 RID: 116435
		public static readonly EUiViewName WeeklyRogueSelectArtifactView = new EUiViewName("WeeklyRogueSelectArtifactView");

		// Token: 0x0401C6D4 RID: 116436
		public static readonly EUiViewName WeeklyRogueInfo = new EUiViewName("WeeklyRogueInfo");

		// Token: 0x0401C6D5 RID: 116437
		public static readonly EUiViewName WeeklyRogueRewardPreviewView = new EUiViewName("WeeklyRogueRewardPreviewView");

		// Token: 0x0401C6D6 RID: 116438
		public static readonly EUiViewName WeeklyRogueRoleSelectView = new EUiViewName("WeeklyRogueRoleSelectView");

		// Token: 0x0401C6D7 RID: 116439
		public static readonly EUiViewName WeeklyRogueExtraRoomConfirmView = new EUiViewName("WeeklyRogueExtraRoomConfirmView");

		// Token: 0x0401C6D8 RID: 116440
		public static readonly EUiViewName MapRogueMainView = new EUiViewName("MapRogueMainView");

		// Token: 0x0401C6D9 RID: 116441
		public static readonly EUiViewName MapRogueGridTakeView = new EUiViewName("MapRogueGridTakeView");

		// Token: 0x0401C6DA RID: 116442
		public static readonly EUiViewName MapRogueGridEventView = new EUiViewName("MapRogueGridEventView");

		// Token: 0x0401C6DB RID: 116443
		public static readonly EUiViewName MapRogueRewardView = new EUiViewName("MapRogueRewardView");

		// Token: 0x0401C6DC RID: 116444
		public static readonly EUiViewName MapRogueEventStartView = new EUiViewName("MapRogueEventStartView");

		// Token: 0x0401C6DD RID: 116445
		public static readonly EUiViewName MapRogueFloatTipsAView = new EUiViewName("MapRogueFloatTipsAView");

		// Token: 0x0401C6DE RID: 116446
		public static readonly EUiViewName MapRogueFloatTipsBView = new EUiViewName("MapRogueFloatTipsBView");

		// Token: 0x0401C6DF RID: 116447
		public static readonly EUiViewName MapRogueExploreEndView = new EUiViewName("MapRogueExploreEndView");

		// Token: 0x0401C6E0 RID: 116448
		public static readonly EUiViewName RogueBattleMapHelpView = new EUiViewName("RogueBattleMapHelpView");

		// Token: 0x0401C6E1 RID: 116449
		public static readonly EUiViewName MapRogueExploreView = new EUiViewName("MapRogueExploreView");

		// Token: 0x0401C6E2 RID: 116450
		public static readonly EUiViewName RogueBattleTokenSelectResultView = new EUiViewName("RogueBattleTokenSelectResultView");

		// Token: 0x0401C6E3 RID: 116451
		public static readonly EUiViewName PowerView = new EUiViewName("PowerView");

		// Token: 0x0401C6E4 RID: 116452
		public static readonly EUiViewName LevelUpView = new EUiViewName("LevelUpView");

		// Token: 0x0401C6E5 RID: 116453
		public static readonly EUiViewName ResonanceDetailView = new EUiViewName("ResonanceDetailView");

		// Token: 0x0401C6E6 RID: 116454
		public static readonly EUiViewName TimeOfDayView = new EUiViewName("TimeOfDayView");

		// Token: 0x0401C6E7 RID: 116455
		public static readonly EUiViewName TimeOfDayLoadingView = new EUiViewName("TimeOfDayLoadingView");

		// Token: 0x0401C6E8 RID: 116456
		public static readonly EUiViewName ReviveView = new EUiViewName("ReviveView");

		// Token: 0x0401C6E9 RID: 116457
		public static readonly EUiViewName MultiReviveView = new EUiViewName("MultiReviveView");

		// Token: 0x0401C6EA RID: 116458
		public static readonly EUiViewName TowerDefenceReviveView = new EUiViewName("TowerDefenceReviveView");

		// Token: 0x0401C6EB RID: 116459
		public static readonly EUiViewName ShareTimesReviveView = new EUiViewName("ShareTimesReviveView");

		// Token: 0x0401C6EC RID: 116460
		public static readonly EUiViewName WorldLevelUpView = new EUiViewName("WorldLevelUpView");

		// Token: 0x0401C6ED RID: 116461
		public static readonly EUiViewName WorldLevelInfoView = new EUiViewName("WorldLevelInfoView");

		// Token: 0x0401C6EE RID: 116462
		public static readonly EUiViewName WorldLevelChangeConfirmView = new EUiViewName("WorldLevelChangeConfirmView");

		// Token: 0x0401C6EF RID: 116463
		public static readonly EUiViewName GenericPromptView = new EUiViewName("GenericPromptView");

		// Token: 0x0401C6F0 RID: 116464
		public static readonly EUiViewName JoinTeamView = new EUiViewName("JoinTeamView");

		// Token: 0x0401C6F1 RID: 116465
		public static readonly EUiViewName MarqueeView = new EUiViewName("MarqueeView");

		// Token: 0x0401C6F2 RID: 116466
		public static readonly EUiViewName BattleSequenceQteView = new EUiViewName("BattleSequenceQteView");

		// Token: 0x0401C6F3 RID: 116467
		public static readonly EUiViewName DebugView = new EUiViewName("DebugView");

		// Token: 0x0401C6F4 RID: 116468
		public static readonly EUiViewName DebugCommandView = new EUiViewName("DebugCmdView");

		// Token: 0x0401C6F5 RID: 116469
		public static readonly EUiViewName RegionalQuestView = new EUiViewName("RegionalQuestView");

		// Token: 0x0401C6F6 RID: 116470
		public static readonly EUiViewName RegionalQuestRewardView = new EUiViewName("RegionalQuestRewardView");

		// Token: 0x0401C6F7 RID: 116471
		public static readonly EUiViewName UseBuffItemView = new EUiViewName("UseBuffItemView");

		// Token: 0x0401C6F8 RID: 116472
		public static readonly EUiViewName MenuView = new EUiViewName("MenuView");

		// Token: 0x0401C6F9 RID: 116473
		public static readonly EUiViewName PlotCaptionImageView = new EUiViewName("PlotCaptionImageView");

		// Token: 0x0401C6FA RID: 116474
		public static readonly EUiViewName MenuViewPopView = new EUiViewName("MenuViewPopView");

		// Token: 0x0401C6FB RID: 116475
		public static readonly EUiViewName CommonKeySettingView = new EUiViewName("CommonKeySettingView");

		// Token: 0x0401C6FC RID: 116476
		public static readonly EUiViewName RegionContributionLevelView = new EUiViewName("RegionContributionLevelView");

		// Token: 0x0401C6FD RID: 116477
		public static readonly EUiViewName VideoView = new EUiViewName("VideoView");

		// Token: 0x0401C6FE RID: 116478
		public static readonly EUiViewName LoginAgeTipView = new EUiViewName("LoginAgeTipView");

		// Token: 0x0401C6FF RID: 116479
		public static readonly EUiViewName UidView = new EUiViewName("UidView");

		// Token: 0x0401C700 RID: 116480
		public static readonly EUiViewName CommonSuccessView = new EUiViewName("CommonSuccessView");

		// Token: 0x0401C701 RID: 116481
		public static readonly EUiViewName NetWorkConfirmBoxView = new EUiViewName("NetWorkConfirmBoxView");

		// Token: 0x0401C702 RID: 116482
		public static readonly EUiViewName TextLanguageSettingView = new EUiViewName("TextLanguageSettingView");

		// Token: 0x0401C703 RID: 116483
		public static readonly EUiViewName VoiceLanguageDownloadView = new EUiViewName("VoiceLanguageDownloadView");

		// Token: 0x0401C704 RID: 116484
		public static readonly EUiViewName VoiceLanguageSelectView = new EUiViewName("VoiceLanguageSelectView");

		// Token: 0x0401C705 RID: 116485
		public static readonly EUiViewName FriendView = new EUiViewName("FriendView");

		// Token: 0x0401C706 RID: 116486
		public static readonly EUiViewName FriendProcessView = new EUiViewName("FriendProcessView");

		// Token: 0x0401C707 RID: 116487
		public static readonly EUiViewName OnlineProcessView = new EUiViewName("OnlineProcessView");

		// Token: 0x0401C708 RID: 116488
		public static readonly EUiViewName FriendSearchView = new EUiViewName("FriendSearchView");

		// Token: 0x0401C709 RID: 116489
		public static readonly EUiViewName FriendBlackListView = new EUiViewName("FriendBlackListView");

		// Token: 0x0401C70A RID: 116490
		public static readonly EUiViewName FriendApplyView = new EUiViewName("FriendApplyView");

		// Token: 0x0401C70B RID: 116491
		public static readonly EUiViewName FriendMultipleApplyView = new EUiViewName("FriendMultipleApplyView");

		// Token: 0x0401C70C RID: 116492
		public static readonly EUiViewName PhantomExploreSetView = new EUiViewName("PhantomExploreSetView");

		// Token: 0x0401C70D RID: 116493
		public static readonly EUiViewName SelectedFriendChatView = new EUiViewName("SelectedFriendChatView");

		// Token: 0x0401C70E RID: 116494
		public static readonly EUiViewName ChatView = new EUiViewName("ChatView");

		// Token: 0x0401C70F RID: 116495
		public static readonly EUiViewName QuickChatView = new EUiViewName("QuickChatView");

		// Token: 0x0401C710 RID: 116496
		public static readonly EUiViewName ChatOption = new EUiViewName("ChatOption");

		// Token: 0x0401C711 RID: 116497
		public static readonly EUiViewName ChatExpressionView = new EUiViewName("ChatExpressionView");

		// Token: 0x0401C712 RID: 116498
		public static readonly EUiViewName TempShopView = new EUiViewName("TempShopView");

		// Token: 0x0401C713 RID: 116499
		public static readonly EUiViewName OnlineWorldHallView = new EUiViewName("OnlineWorldHallView");

		// Token: 0x0401C714 RID: 116500
		public static readonly EUiViewName OnlineSettingView = new EUiViewName("OnlineSettingView");

		// Token: 0x0401C715 RID: 116501
		public static readonly EUiViewName OnlineWorldSearch = new EUiViewName("OnlineWorldSearchView");

		// Token: 0x0401C716 RID: 116502
		public static readonly EUiViewName OnlineApplyView = new EUiViewName("OnlineApplyView");

		// Token: 0x0401C717 RID: 116503
		public static readonly EUiViewName OnlineMultipleApplyView = new EUiViewName("OnlineMultipleApplyView");

		// Token: 0x0401C718 RID: 116504
		public static readonly EUiViewName OnlineChallengeApplyView = new EUiViewName("OnlineChallengeApplyView");

		// Token: 0x0401C719 RID: 116505
		public static readonly EUiViewName OnlineMatchSuccessView = new EUiViewName("OnlineMatchSuccessView");

		// Token: 0x0401C71A RID: 116506
		public static readonly EUiViewName OnlineChallengeStateView = new EUiViewName("OnlineChallengeStateView");

		// Token: 0x0401C71B RID: 116507
		public static readonly EUiViewName OnlineInstanceMatchTips = new EUiViewName("OnlineInstanceMatchTips");

		// Token: 0x0401C71C RID: 116508
		public static readonly EUiViewName PayShopRootView = new EUiViewName("PayShopRootView");

		// Token: 0x0401C71D RID: 116509
		public static readonly EUiViewName GiftPackageDetailsView = new EUiViewName("GiftPackageDetailsView");

		// Token: 0x0401C71E RID: 116510
		public static readonly EUiViewName CommonExchangeView = new EUiViewName("CommonExchangeView");

		// Token: 0x0401C71F RID: 116511
		public static readonly EUiViewName GachaMainView = new EUiViewName("GachaMainView");

		// Token: 0x0401C720 RID: 116512
		public static readonly EUiViewName GachaResultView = new EUiViewName("GachaResultView");

		// Token: 0x0401C721 RID: 116513
		public static readonly EUiViewName GachaScanView = new EUiViewName("GachaScanView");

		// Token: 0x0401C722 RID: 116514
		public static readonly EUiViewName GachaSelectionView = new EUiViewName("GachaSelectionView");

		// Token: 0x0401C723 RID: 116515
		public static readonly EUiViewName CalabashRootView = new EUiViewName("CalabashRootView");

		// Token: 0x0401C724 RID: 116516
		public static readonly EUiViewName VisionDirectionalFusionSelectTargetView = new EUiViewName("VisionDirectionalFusionSelectTargetView");

		// Token: 0x0401C725 RID: 116517
		public static readonly EUiViewName CalabashUpgradeSuccessView = new EUiViewName("CalabashUpgradeSuccessView");

		// Token: 0x0401C726 RID: 116518
		public static readonly EUiViewName PhantomBattleFettersView = new EUiViewName("PhantomBattleFettersView");

		// Token: 0x0401C727 RID: 116519
		public static readonly EUiViewName PhantomBattleEquipView = new EUiViewName("PhantomBattleEquipView");

		// Token: 0x0401C728 RID: 116520
		public static readonly EUiViewName PhantomManagerConfigSharePopItem = new EUiViewName("PhantomManagerConfigSharePopItem");

		// Token: 0x0401C729 RID: 116521
		public static readonly EUiViewName PhantomManagerConfigResetPopItem = new EUiViewName("PhantomManagerConfigResetPopItem");

		// Token: 0x0401C72A RID: 116522
		public static readonly EUiViewName PhantomManagerConfigRemovePopItem = new EUiViewName("PhantomManagerConfigRemovePopItem");

		// Token: 0x0401C72B RID: 116523
		public static readonly EUiViewName PhantomManagerConfigEditPopItem = new EUiViewName("PhantomManagerConfigEditPopItem");

		// Token: 0x0401C72C RID: 116524
		public static readonly EUiViewName TimeOfDaySecondView = new EUiViewName("TimeOfDaySecondView");

		// Token: 0x0401C72D RID: 116525
		public static readonly EUiViewName ExchangePopView = new EUiViewName("ExchangePopView");

		// Token: 0x0401C72E RID: 116526
		public static readonly EUiViewName GameplayExchangePopView = new EUiViewName("GameplayExchangePopView");

		// Token: 0x0401C72F RID: 116527
		public static readonly EUiViewName TutorialView = new EUiViewName("TutorialView");

		// Token: 0x0401C730 RID: 116528
		public static readonly EUiViewName TutorialPopView = new EUiViewName("TutorialPopView");

		// Token: 0x0401C731 RID: 116529
		public static readonly EUiViewName AdventureGuideView = new EUiViewName("AdventureGuideView");

		// Token: 0x0401C732 RID: 116530
		public static readonly EUiViewName AcquireView = new EUiViewName("AcquireView");

		// Token: 0x0401C733 RID: 116531
		public static readonly EUiViewName InventoryGiftView = new EUiViewName("InventoryGiftView");

		// Token: 0x0401C734 RID: 116532
		public static readonly EUiViewName InfoDisplayImgView = new EUiViewName("InfoDisplayImgView");

		// Token: 0x0401C735 RID: 116533
		public static readonly EUiViewName InfoDisplayTypeOneView = new EUiViewName("InfoDisplayTypeOneView");

		// Token: 0x0401C736 RID: 116534
		public static readonly EUiViewName InfoDisplayTypeTwoView = new EUiViewName("InfoDisplayTypeTwoView");

		// Token: 0x0401C737 RID: 116535
		public static readonly EUiViewName InfoDisplayTypeThreeView = new EUiViewName("InfoDisplayTypeThreeView");

		// Token: 0x0401C738 RID: 116536
		public static readonly EUiViewName InfoDisplayTypeFourView = new EUiViewName("InfoDisplayTypeFourView");

		// Token: 0x0401C739 RID: 116537
		public static readonly EUiViewName InfoDisplayTypeFourNewView = new EUiViewName("InfoDisplayTypeFourNewView");

		// Token: 0x0401C73A RID: 116538
		public static readonly EUiViewName InfoDisplayTypeFiveView = new EUiViewName("InfoDisplayTypeFiveView");

		// Token: 0x0401C73B RID: 116539
		public static readonly EUiViewName InfoDisplayAttachmentBigImgView = new EUiViewName("InfoDisplayAttachmentBigImgView");

		// Token: 0x0401C73C RID: 116540
		public static readonly EUiViewName WeaponPreviewView = new EUiViewName("WeaponPreviewView");

		// Token: 0x0401C73D RID: 116541
		public static readonly EUiViewName MonthCardView = new EUiViewName("MonthCardView");

		// Token: 0x0401C73E RID: 116542
		public static readonly EUiViewName MonthCardRewardView = new EUiViewName("MonthCardRewardView");

		// Token: 0x0401C73F RID: 116543
		public static readonly EUiViewName AttributeView = new EUiViewName("AttributeView");

		// Token: 0x0401C740 RID: 116544
		public static readonly EUiViewName RoleAttributeDetailView = new EUiViewName("RoleAttributeDetailView");

		// Token: 0x0401C741 RID: 116545
		public static readonly EUiViewName SkillLevelUpView = new EUiViewName("SkillLevelUpView");

		// Token: 0x0401C742 RID: 116546
		public static readonly EUiViewName RoleSkillTreeInfoView = new EUiViewName("RoleSkillTreeInfoView");

		// Token: 0x0401C743 RID: 116547
		public static readonly EUiViewName RoleSkillInputView = new EUiViewName("RoleSkillInputView");

		// Token: 0x0401C744 RID: 116548
		public static readonly EUiViewName RoleQuestView = new EUiViewName("RoleQuestView");

		// Token: 0x0401C745 RID: 116549
		public static readonly EUiViewName ReportView = new EUiViewName("ReportView");

		// Token: 0x0401C746 RID: 116550
		public static readonly EUiViewName CookRootView = new EUiViewName("CookRootView");

		// Token: 0x0401C747 RID: 116551
		public static readonly EUiViewName CookLevelView = new EUiViewName("CookLevelView");

		// Token: 0x0401C748 RID: 116552
		public static readonly EUiViewName CookRoleView = new EUiViewName("CookRoleView");

		// Token: 0x0401C749 RID: 116553
		public static readonly EUiViewName CookPopView = new EUiViewName("CookPopView");

		// Token: 0x0401C74A RID: 116554
		public static readonly EUiViewName CookSuccessView = new EUiViewName("CookSuccessView");

		// Token: 0x0401C74B RID: 116555
		public static readonly EUiViewName RoleFavorInfoView = new EUiViewName("RoleFavorInfoView");

		// Token: 0x0401C74C RID: 116556
		public static readonly EUiViewName RoleFavorHintView = new EUiViewName("RoleFavorHintView");

		// Token: 0x0401C74D RID: 116557
		public static readonly EUiViewName RoleLangCustomView = new EUiViewName("RoleLangCustomView");

		// Token: 0x0401C74E RID: 116558
		public static readonly EUiViewName RoleLangRemoveView = new EUiViewName("RoleLangRemoveView");

		// Token: 0x0401C74F RID: 116559
		public static readonly EUiViewName RoleLangNetConfirmPop = new EUiViewName("RoleLangNetConfirmPop");

		// Token: 0x0401C750 RID: 116560
		public static readonly EUiViewName RoleGiftSplashView = new EUiViewName("RoleGiftSplashView");

		// Token: 0x0401C751 RID: 116561
		public static readonly EUiViewName FunctionOpenView = new EUiViewName("FunctionOpenView");

		// Token: 0x0401C752 RID: 116562
		public static readonly EUiViewName CookPopFixView = new EUiViewName("CookPopFixView");

		// Token: 0x0401C753 RID: 116563
		public static readonly EUiViewName SingleTimeTowerView = new EUiViewName("SingleTimeTowerView");

		// Token: 0x0401C754 RID: 116564
		public static readonly EUiViewName SingleTimeTowerChallengeView = new EUiViewName("SingleTimeTowerChallengeView");

		// Token: 0x0401C755 RID: 116565
		public static readonly EUiViewName SingleTimeTowerTeamView = new EUiViewName("SingleTimeTowerTeamView");

		// Token: 0x0401C756 RID: 116566
		public static readonly EUiViewName SingleTimeTowerDetailView = new EUiViewName("SingleTimeTowerDetailView");

		// Token: 0x0401C757 RID: 116567
		public static readonly EUiViewName SingleTimeTowerVictoryView = new EUiViewName("SingleTimeTowerVictoryView");

		// Token: 0x0401C758 RID: 116568
		public static readonly EUiViewName SingleTimeTowerFailView = new EUiViewName("SingleTimeTowerFailView");

		// Token: 0x0401C759 RID: 116569
		public static readonly EUiViewName TowerRewardView = new EUiViewName("TowerRewardView");

		// Token: 0x0401C75A RID: 116570
		public static readonly EUiViewName TowerApplyFloorDataView = new EUiViewName("TowerApplyFloorDataView");

		// Token: 0x0401C75B RID: 116571
		public static readonly EUiViewName TowerNormalView = new EUiViewName("TowerNormalView");

		// Token: 0x0401C75C RID: 116572
		public static readonly EUiViewName TowerFloorView = new EUiViewName("TowerFloorView");

		// Token: 0x0401C75D RID: 116573
		public static readonly EUiViewName TowerVariationView = new EUiViewName("TowerVariationView");

		// Token: 0x0401C75E RID: 116574
		public static readonly EUiViewName TowerResetView = new EUiViewName("TowerResetView");

		// Token: 0x0401C75F RID: 116575
		public static readonly EUiViewName TowerRecommendView = new EUiViewName("TowerRecommendView");

		// Token: 0x0401C760 RID: 116576
		public static readonly EUiViewName TowerReviewView = new EUiViewName("TowerReviewView");

		// Token: 0x0401C761 RID: 116577
		public static readonly EUiViewName TowerFloorDetailView = new EUiViewName("TowerFloorDetailView");

		// Token: 0x0401C762 RID: 116578
		public static readonly EUiViewName TowerGuideView = new EUiViewName("TowerGuideView");

		// Token: 0x0401C763 RID: 116579
		public static readonly EUiViewName TowerUnlockView = new EUiViewName("TowerUnlockView");

		// Token: 0x0401C764 RID: 116580
		public static readonly EUiViewName TowerOverLockUnlockView = new EUiViewName("TowerOverLockUnlockView");

		// Token: 0x0401C765 RID: 116581
		public static readonly EUiViewName EventConditionFloatTips = new EUiViewName("EventConditionFloatTips");

		// Token: 0x0401C766 RID: 116582
		public static readonly EUiViewName ChallengeAchieveFloatTips = new EUiViewName("ChallengeAchieveFloatTips");

		// Token: 0x0401C767 RID: 116583
		public static readonly EUiViewName ChallengeWantedAchieveFloatTips = new EUiViewName("ChallengeWantedAchieveFloatTips");

		// Token: 0x0401C768 RID: 116584
		public static readonly EUiViewName ChallengeSuccessFloatTips = new EUiViewName("ChallengeSuccessFloatTips");

		// Token: 0x0401C769 RID: 116585
		public static readonly EUiViewName ChallengeFailedFloatTips = new EUiViewName("ChallengeFailedFloatTips");

		// Token: 0x0401C76A RID: 116586
		public static readonly EUiViewName AdditionalTasksFloatTips = new EUiViewName("AdditionalTasksFloatTips");

		// Token: 0x0401C76B RID: 116587
		public static readonly EUiViewName DelegateCompletionFloatTips = new EUiViewName("DelegateCompletionFloatTips");

		// Token: 0x0401C76C RID: 116588
		public static readonly EUiViewName CountDownFloatTips = new EUiViewName("CountDownFloatTips");

		// Token: 0x0401C76D RID: 116589
		public static readonly EUiViewName CountDownChallenge = new EUiViewName("CountDownChallenge");

		// Token: 0x0401C76E RID: 116590
		public static readonly EUiViewName UnOpenedAreaCountDownFloatTips = new EUiViewName("UnOpenedAreaCountDownFloatTips");

		// Token: 0x0401C76F RID: 116591
		public static readonly EUiViewName LevelGamePlayPrepareCountDown = new EUiViewName("LevelGamePlayPrepareCountDown");

		// Token: 0x0401C770 RID: 116592
		public static readonly EUiViewName LevelGamePlayMotorPrepareCountDown = new EUiViewName("LevelGamePlayMotorPrepareCountDown");

		// Token: 0x0401C771 RID: 116593
		public static readonly EUiViewName PunishReportView = new EUiViewName("PunishReportView");

		// Token: 0x0401C772 RID: 116594
		public static readonly EUiViewName PunishReportSettlementView = new EUiViewName("PunishReportSettlementView");

		// Token: 0x0401C773 RID: 116595
		public static readonly EUiViewName DungeonClearanceFloatTips = new EUiViewName("DungeonClearanceFloatTips");

		// Token: 0x0401C774 RID: 116596
		public static readonly EUiViewName DungeonAutoExitFloatTips = new EUiViewName("DungeonAutoExitFloatTips");

		// Token: 0x0401C775 RID: 116597
		public static readonly EUiViewName ChapterEndFloatTips = new EUiViewName("ChapterEndFloatTips");

		// Token: 0x0401C776 RID: 116598
		public static readonly EUiViewName FlowChapterStartTips = new EUiViewName("FlowChapterStartTips");

		// Token: 0x0401C777 RID: 116599
		public static readonly EUiViewName FlowChapterEndTips = new EUiViewName("FlowChapterEndTips");

		// Token: 0x0401C778 RID: 116600
		public static readonly EUiViewName ChapterBattleDeclarationTipsRed = new EUiViewName("ChapterBattleDeclarationTipsRed");

		// Token: 0x0401C779 RID: 116601
		public static readonly EUiViewName ChapterBattleDeclarationTipsWhite = new EUiViewName("ChapterBattleDeclarationTipsWhite");

		// Token: 0x0401C77A RID: 116602
		public static readonly EUiViewName ChapterStartFloatTips = new EUiViewName("ChapterStartFloatTips");

		// Token: 0x0401C77B RID: 116603
		public static readonly EUiViewName DailyTaskEndTips = new EUiViewName("DailyTaskEndTips");

		// Token: 0x0401C77C RID: 116604
		public static readonly EUiViewName TaskEndTips = new EUiViewName("TaskEndTips");

		// Token: 0x0401C77D RID: 116605
		public static readonly EUiViewName PrepareCountdownFloatTips = new EUiViewName("PrepareCountdownFloatTips");

		// Token: 0x0401C77E RID: 116606
		public static readonly EUiViewName ComboTeachingFloatTips = new EUiViewName("ComboTeachingFloatTips");

		// Token: 0x0401C77F RID: 116607
		public static readonly EUiViewName InfluenceReputationView = new EUiViewName("InfluenceReputationView");

		// Token: 0x0401C780 RID: 116608
		public static readonly EUiViewName InfluenceAreaSelectView = new EUiViewName("InfluenceAreaSelectView");

		// Token: 0x0401C781 RID: 116609
		public static readonly EUiViewName ReputationDetailsView = new EUiViewName("ReputationDetailsView");

		// Token: 0x0401C782 RID: 116610
		public static readonly EUiViewName ReputationTips = new EUiViewName("ReputationTips");

		// Token: 0x0401C783 RID: 116611
		public static readonly EUiViewName ReputationRewardsView = new EUiViewName("ReputationRewardsView");

		// Token: 0x0401C784 RID: 116612
		public static readonly EUiViewName InfluenceSearchView = new EUiViewName("InfluenceSearchView");

		// Token: 0x0401C785 RID: 116613
		public static readonly EUiViewName CycleTowerView = new EUiViewName("CycleTowerView");

		// Token: 0x0401C786 RID: 116614
		public static readonly EUiViewName CycleTowerChallengeView = new EUiViewName("CycleTowerChallengeView");

		// Token: 0x0401C787 RID: 116615
		public static readonly EUiViewName CycleTowerTeamView = new EUiViewName("CycleTowerTeamView");

		// Token: 0x0401C788 RID: 116616
		public static readonly EUiViewName CycleTowerDetailView = new EUiViewName("CycleTowerDetailView");

		// Token: 0x0401C789 RID: 116617
		public static readonly EUiViewName CycleTowerRewardView = new EUiViewName("CycleTowerRewardView");

		// Token: 0x0401C78A RID: 116618
		public static readonly EUiViewName CycleTowerSeasonRewardView = new EUiViewName("CycleTowerSeasonRewardView");

		// Token: 0x0401C78B RID: 116619
		public static readonly EUiViewName CycleTowerClearInfoView = new EUiViewName("CycleTowerClearInfoView");

		// Token: 0x0401C78C RID: 116620
		public static readonly EUiViewName CycleTowerSeasonInfoView = new EUiViewName("CycleTowerSeasonInfoView");

		// Token: 0x0401C78D RID: 116621
		public static readonly EUiViewName TowerDetailView = new EUiViewName("TowerDetailView");

		// Token: 0x0401C78E RID: 116622
		public static readonly EUiViewName BattlePassMainView = new EUiViewName("BattlePassMainView");

		// Token: 0x0401C78F RID: 116623
		public static readonly EUiViewName BattlePassBuyLevelView = new EUiViewName("BattlePassBuyLevelView");

		// Token: 0x0401C790 RID: 116624
		public static readonly EUiViewName BattlePassPayView = new EUiViewName("BattlePassPayView");

		// Token: 0x0401C791 RID: 116625
		public static readonly EUiViewName BattlePassUnlockView = new EUiViewName("BattlePassUnlockView");

		// Token: 0x0401C792 RID: 116626
		public static readonly EUiViewName BattlePassUpLevelView = new EUiViewName("BattlePassUpLevelView");

		// Token: 0x0401C793 RID: 116627
		public static readonly EUiViewName BattlePassFirstOpenView = new EUiViewName("BattlePassFirstOpenView");

		// Token: 0x0401C794 RID: 116628
		public static readonly EUiViewName DrawMainView = new EUiViewName("DrawMainView");

		// Token: 0x0401C795 RID: 116629
		public static readonly EUiViewName PhonographView = new EUiViewName("PhonographView");

		// Token: 0x0401C796 RID: 116630
		public static readonly EUiViewName PhonographNewMusicView = new EUiViewName("PhonographNewMusicView");

		// Token: 0x0401C797 RID: 116631
		public static readonly EUiViewName RoleHandBookRootView = new EUiViewName("RoleHandBookRootView");

		// Token: 0x0401C798 RID: 116632
		public static readonly EUiViewName RoleHandBookSelectionView = new EUiViewName("RoleHandBookSelectionView");

		// Token: 0x0401C799 RID: 116633
		public static readonly EUiViewName ComposeRootView = new EUiViewName("ComposeRootView");

		// Token: 0x0401C79A RID: 116634
		public static readonly EUiViewName ComposeLevelView = new EUiViewName("ComposeLevelView");

		// Token: 0x0401C79B RID: 116635
		public static readonly EUiViewName ManufactureHelpRoleView = new EUiViewName("ManufactureHelpRoleView");

		// Token: 0x0401C79C RID: 116636
		public static readonly EUiViewName ForgingRootView = new EUiViewName("ForgingRootView");

		// Token: 0x0401C79D RID: 116637
		public static readonly EUiViewName RewardPopView = new EUiViewName("RewardPopView");

		// Token: 0x0401C79E RID: 116638
		public static readonly EUiViewName ResolutionListView = new EUiViewName("ResolutionListView");

		// Token: 0x0401C79F RID: 116639
		public static readonly EUiViewName BrightnessView = new EUiViewName("BrightnessView");

		// Token: 0x0401C7A0 RID: 116640
		public static readonly EUiViewName LogUploadView = new EUiViewName("LogUploadView");

		// Token: 0x0401C7A1 RID: 116641
		public static readonly EUiViewName ToolWindowView = new EUiViewName("ToolWindowView");

		// Token: 0x0401C7A2 RID: 116642
		public static readonly EUiViewName VulkanSetView = new EUiViewName("VulkanSetView");

		// Token: 0x0401C7A3 RID: 116643
		public static readonly EUiViewName PhotographView = new EUiViewName("PhotographView");

		// Token: 0x0401C7A4 RID: 116644
		public static readonly EUiViewName PhotographSetupView = new EUiViewName("PhotographSetupView");

		// Token: 0x0401C7A5 RID: 116645
		public static readonly EUiViewName PhotoSaveView = new EUiViewName("PhotoSaveView");

		// Token: 0x0401C7A6 RID: 116646
		public static readonly EUiViewName FightPhotographView = new EUiViewName("FightPhotographView");

		// Token: 0x0401C7A7 RID: 116647
		public static readonly EUiViewName FightPhotoResultView = new EUiViewName("FightPhotoResultView");

		// Token: 0x0401C7A8 RID: 116648
		public static readonly EUiViewName FightPhotoRewardView = new EUiViewName("FightPhotoRewardView");

		// Token: 0x0401C7A9 RID: 116649
		public static readonly EUiViewName FightPhotoMainView = new EUiViewName("FightPhotoMainView");

		// Token: 0x0401C7AA RID: 116650
		public static readonly EUiViewName FightPhotoUnlockTipView = new EUiViewName("FightPhotoUnlockTipView");

		// Token: 0x0401C7AB RID: 116651
		public static readonly EUiViewName FightPhotoEventTipView = new EUiViewName("FightPhotoEventTipView");

		// Token: 0x0401C7AC RID: 116652
		public static readonly EUiViewName FightPhotoFocusView = new EUiViewName("FightPhotoFocusView");

		// Token: 0x0401C7AD RID: 116653
		public static readonly EUiViewName FightPhotoLoadingView = new EUiViewName("FightPhotoLoadingView");

		// Token: 0x0401C7AE RID: 116654
		public static readonly EUiViewName FightPhotoSaveView = new EUiViewName("FightPhotoSaveView");

		// Token: 0x0401C7AF RID: 116655
		public static readonly EUiViewName CaptureCollectView = new EUiViewName("CaptureCollectView");

		// Token: 0x0401C7B0 RID: 116656
		public static readonly EUiViewName UseReviveItemView = new EUiViewName("UseReviveItemView");

		// Token: 0x0401C7B1 RID: 116657
		public static readonly EUiViewName PhantomBattleSkillInfoView = new EUiViewName("PhantomBattleSkillInfoView");

		// Token: 0x0401C7B2 RID: 116658
		public static readonly EUiViewName PhantomBattleFettersObtainView = new EUiViewName("PhantomBattleFettersObtainView");

		// Token: 0x0401C7B3 RID: 116659
		public static readonly EUiViewName CalabashUnlockItemView = new EUiViewName("CalabashUnlockItemView");

		// Token: 0x0401C7B4 RID: 116660
		public static readonly EUiViewName PhantomDecomposeView = new EUiViewName("PhantomBattleDecomposeView");

		// Token: 0x0401C7B5 RID: 116661
		public static readonly EUiViewName BattleUiSetView = new EUiViewName("BattleUiSetView");

		// Token: 0x0401C7B6 RID: 116662
		public static readonly EUiViewName AchievementMainView = new EUiViewName("AchievementMainView");

		// Token: 0x0401C7B7 RID: 116663
		public static readonly EUiViewName AchievementDetailView = new EUiViewName("AchievementDetailView");

		// Token: 0x0401C7B8 RID: 116664
		public static readonly EUiViewName AchievementFinishView = new EUiViewName("AchievementFinishView");

		// Token: 0x0401C7B9 RID: 116665
		public static readonly EUiViewName AchievementCompleteTipsView = new EUiViewName("AchievementCompleteTipsView");

		// Token: 0x0401C7BA RID: 116666
		public static readonly EUiViewName ExploreProgressView = new EUiViewName("ExploreProgressView");

		// Token: 0x0401C7BB RID: 116667
		public static readonly EUiViewName RoleBreachSuccessView = new EUiViewName("RoleBreachSuccessView");

		// Token: 0x0401C7BC RID: 116668
		public static readonly EUiViewName LoginServerView = new EUiViewName("LoginServerView");

		// Token: 0x0401C7BD RID: 116669
		public static readonly EUiViewName RoleGenderChangeView = new EUiViewName("RoleGenderChangeView");

		// Token: 0x0401C7BE RID: 116670
		public static readonly EUiViewName RoleElementView = new EUiViewName("RoleElementView");

		// Token: 0x0401C7BF RID: 116671
		public static readonly EUiViewName ComboTeachingView = new EUiViewName("ComboTeachingView");

		// Token: 0x0401C7C0 RID: 116672
		public static readonly EUiViewName PersonalRootView = new EUiViewName("PersonalRootView");

		// Token: 0x0401C7C1 RID: 116673
		public static readonly EUiViewName PersonalOptionView = new EUiViewName("PersonalOptionView");

		// Token: 0x0401C7C2 RID: 116674
		public static readonly EUiViewName PersonalBirthView = new EUiViewName("PersonalBirthView");

		// Token: 0x0401C7C3 RID: 116675
		public static readonly EUiViewName PersonalEditView = new EUiViewName("PersonalEditView");

		// Token: 0x0401C7C4 RID: 116676
		public static readonly EUiViewName FrozenQteView = new EUiViewName("FrozenQteView");

		// Token: 0x0401C7C5 RID: 116677
		public static readonly EUiViewName InteractQteView = new EUiViewName("InteractQteView");

		// Token: 0x0401C7C6 RID: 116678
		public static readonly EUiViewName YouHuQteView = new EUiViewName("YouHuQteView");

		// Token: 0x0401C7C7 RID: 116679
		public static readonly EUiViewName XiaKongQteView = new EUiViewName("XiaKongQteView");

		// Token: 0x0401C7C8 RID: 116680
		public static readonly EUiViewName FreeRunningQteView = new EUiViewName("FreeRunningQteView");

		// Token: 0x0401C7C9 RID: 116681
		public static readonly EUiViewName CommonQteView = new EUiViewName("CommonQteView");

		// Token: 0x0401C7CA RID: 116682
		public static readonly EUiViewName CommonQteNoIconView = new EUiViewName("CommonQteNoIconView");

		// Token: 0x0401C7CB RID: 116683
		public static readonly EUiViewName CommonQteContinuousClickView = new EUiViewName("CommonQteContinuousClickView");

		// Token: 0x0401C7CC RID: 116684
		public static readonly EUiViewName CommonQteLongPressView = new EUiViewName("CommonQteLongPressView");

		// Token: 0x0401C7CD RID: 116685
		public static readonly EUiViewName CommonQteNoIconLongPressView = new EUiViewName("CommonQteNoIconLongPressView");

		// Token: 0x0401C7CE RID: 116686
		public static readonly EUiViewName QtaView = new EUiViewName("QtaView");

		// Token: 0x0401C7CF RID: 116687
		public static readonly EUiViewName PersonalRoleShowView = new EUiViewName("PersonalRoleShowView");

		// Token: 0x0401C7D0 RID: 116688
		public static readonly EUiViewName PersonalCardView = new EUiViewName("PersonalCardView");

		// Token: 0x0401C7D1 RID: 116689
		public static readonly EUiViewName CommonActivityView = new EUiViewName("CommonActivityView");

		// Token: 0x0401C7D2 RID: 116690
		public static readonly EUiViewName ActivityRewardPopUpView = new EUiViewName("ActivityRewardPopUpView");

		// Token: 0x0401C7D3 RID: 116691
		public static readonly EUiViewName LongShanUnlockView = new EUiViewName("LongShanUnlockView");

		// Token: 0x0401C7D4 RID: 116692
		public static readonly EUiViewName ActivityRunView = new EUiViewName("ActivityRunView");

		// Token: 0x0401C7D5 RID: 116693
		public static readonly EUiViewName ActivityRunSuccessView = new EUiViewName("ActivityRunSuccessView");

		// Token: 0x0401C7D6 RID: 116694
		public static readonly EUiViewName ActivityRunFailView = new EUiViewName("ActivityRunFailView");

		// Token: 0x0401C7D7 RID: 116695
		public static readonly EUiViewName BossRushMainView = new EUiViewName("BossRushMainView");

		// Token: 0x0401C7D8 RID: 116696
		public static readonly EUiViewName BossRushBuffInGameView = new EUiViewName("BossRushBuffInGameView");

		// Token: 0x0401C7D9 RID: 116697
		public static readonly EUiViewName ActivityTurntableRewardView = new EUiViewName("ActivityTurntableRewardView");

		// Token: 0x0401C7DA RID: 116698
		public static readonly EUiViewName ActivityUnlockTipView = new EUiViewName("ActivityUnlockTipView");

		// Token: 0x0401C7DB RID: 116699
		public static readonly EUiViewName TowerDefensePhantomView = new EUiViewName("TowerDefensePhantomView");

		// Token: 0x0401C7DC RID: 116700
		public static readonly EUiViewName ActivityUnlockTipMoonChasingView = new EUiViewName("ActivityUnlockTipMoonChasingView");

		// Token: 0x0401C7DD RID: 116701
		public static readonly EUiViewName CorniceMeetingMainView = new EUiViewName("CorniceMeetingMainView");

		// Token: 0x0401C7DE RID: 116702
		public static readonly EUiViewName ActivityConditionView = new EUiViewName("ActivityConditionView");

		// Token: 0x0401C7DF RID: 116703
		public static readonly EUiViewName CommonConditionView = new EUiViewName("CommonConditionView");

		// Token: 0x0401C7E0 RID: 116704
		public static readonly EUiViewName BlackCoastActivityMainView = new EUiViewName("BlackCoastActivityMainView");

		// Token: 0x0401C7E1 RID: 116705
		public static readonly EUiViewName BlackCoastActivityTaskView = new EUiViewName("BlackCoastActivityTaskView");

		// Token: 0x0401C7E2 RID: 116706
		public static readonly EUiViewName ActivityUnlockTipBlackCoastView = new EUiViewName("ActivityUnlockTipBlackCoastView");

		// Token: 0x0401C7E3 RID: 116707
		public static readonly EUiViewName ActivityUnlockTipDreamLinkView = new EUiViewName("ActivityUnlockTipDreamLinkView");

		// Token: 0x0401C7E4 RID: 116708
		public static readonly EUiViewName DreamLinkWhiteCatSettleView = new EUiViewName("DreamLinkWhiteCatSettleView");

		// Token: 0x0401C7E5 RID: 116709
		public static readonly EUiViewName ActivityInstanceEntranceView = new EUiViewName("ActivityInstanceEntranceView");

		// Token: 0x0401C7E6 RID: 116710
		public static readonly EUiViewName CommonRewardView = new EUiViewName("CommonRewardView");

		// Token: 0x0401C7E7 RID: 116711
		public static readonly EUiViewName PayRewardView = new EUiViewName("PayRewardView");

		// Token: 0x0401C7E8 RID: 116712
		public static readonly EUiViewName RoleIntroductionView = new EUiViewName("RoleIntroductionView");

		// Token: 0x0401C7E9 RID: 116713
		public static readonly EUiViewName QuestRewardView = new EUiViewName("QuestRewardView");

		// Token: 0x0401C7EA RID: 116714
		public static readonly EUiViewName CompositeRewardView = new EUiViewName("CompositeRewardView");

		// Token: 0x0401C7EB RID: 116715
		public static readonly EUiViewName ExploreRewardView = new EUiViewName("ExploreRewardView");

		// Token: 0x0401C7EC RID: 116716
		public static readonly EUiViewName ExploreLevelRewardView = new EUiViewName("ExploreLevelRewardView");

		// Token: 0x0401C7ED RID: 116717
		public static readonly EUiViewName BattlePassExtraRewardView = new EUiViewName("BattlePassExtraRewardView");

		// Token: 0x0401C7EE RID: 116718
		public static readonly EUiViewName CommunicateView = new EUiViewName("CommunicateView");

		// Token: 0x0401C7EF RID: 116719
		public static readonly EUiViewName FilterView = new EUiViewName("FilterView");

		// Token: 0x0401C7F0 RID: 116720
		public static readonly EUiViewName VisionFilterView = new EUiViewName("VisionFilterView");

		// Token: 0x0401C7F1 RID: 116721
		public static readonly EUiViewName SortView = new EUiViewName("SortView");

		// Token: 0x0401C7F2 RID: 116722
		public static readonly EUiViewName CommonItemSelectViewLeft = new EUiViewName("CommonItemSelectViewLeft");

		// Token: 0x0401C7F3 RID: 116723
		public static readonly EUiViewName CommonItemSelectViewRight = new EUiViewName("CommonItemSelectViewRight");

		// Token: 0x0401C7F4 RID: 116724
		public static readonly EUiViewName VisionEquipmentView = new EUiViewName("VisionEquipmentView");

		// Token: 0x0401C7F5 RID: 116725
		public static readonly EUiViewName VisionLevelUpView = new EUiViewName("VisionLevelUpView");

		// Token: 0x0401C7F6 RID: 116726
		public static readonly EUiViewName VisionSlotView = new EUiViewName("VisionSlotView");

		// Token: 0x0401C7F7 RID: 116727
		public static readonly EUiViewName VisionIntensifyView = new EUiViewName("VisionIntensifyView");

		// Token: 0x0401C7F8 RID: 116728
		public static readonly EUiViewName VisionSlotSuccessView = new EUiViewName("VisionSlotSuccessView");

		// Token: 0x0401C7F9 RID: 116729
		public static readonly EUiViewName VisionLevelUpSuccessView = new EUiViewName("VisionLevelUpSuccessView");

		// Token: 0x0401C7FA RID: 116730
		public static readonly EUiViewName VisionRecommendView = new EUiViewName("VisionRecommendView");

		// Token: 0x0401C7FB RID: 116731
		public static readonly EUiViewName VisionNewRecommendView = new EUiViewName("VisionNewRecommendView");

		// Token: 0x0401C7FC RID: 116732
		public static readonly EUiViewName VisionNewRecommendPreviewView = new EUiViewName("VisionNewRecommendPreviewView");

		// Token: 0x0401C7FD RID: 116733
		public static readonly EUiViewName VisionLookOverView = new EUiViewName("VisionLookOverView");

		// Token: 0x0401C7FE RID: 116734
		public static readonly EUiViewName VisionSkinView = new EUiViewName("VisionSkinView");

		// Token: 0x0401C7FF RID: 116735
		public static readonly EUiViewName VisionAssembleView = new EUiViewName("VisionAssembleView");

		// Token: 0x0401C800 RID: 116736
		public static readonly EUiViewName SignalDecodeView = new EUiViewName("SignalDecodeView");

		// Token: 0x0401C801 RID: 116737
		public static readonly EUiViewName SignalDeviceView = new EUiViewName("SignalDeviceView");

		// Token: 0x0401C802 RID: 116738
		public static readonly EUiViewName SignalDeviceChasingMoonView = new EUiViewName("SignalDeviceChasingMoonView");

		// Token: 0x0401C803 RID: 116739
		public static readonly EUiViewName QuestFailRangeTipsView = new EUiViewName("QuestFailRangeTipsView");

		// Token: 0x0401C804 RID: 116740
		public static readonly EUiViewName RoleLevelUpSuccessAttributeView = new EUiViewName("RoleLevelUpSuccessAttributeView");

		// Token: 0x0401C805 RID: 116741
		public static readonly EUiViewName RoleLevelUpSuccessEffectView = new EUiViewName("RoleLevelUpSuccessEffectView");

		// Token: 0x0401C806 RID: 116742
		public static readonly EUiViewName CommonSingleInputView = new EUiViewName("CommonSingleInputView");

		// Token: 0x0401C807 RID: 116743
		public static readonly EUiViewName CommonModifyNameInputView = new EUiViewName("CommonModifyNameInputView");

		// Token: 0x0401C808 RID: 116744
		public static readonly EUiViewName CommonMultiInputView = new EUiViewName("CommonMultiInputView");

		// Token: 0x0401C809 RID: 116745
		public static readonly EUiViewName CdKeyInputView = new EUiViewName("CdKeyInputView");

		// Token: 0x0401C80A RID: 116746
		public static readonly EUiViewName VersionCheckView = new EUiViewName("VersionCheckView");

		// Token: 0x0401C80B RID: 116747
		public static readonly EUiViewName VisionAssembleInputView = new EUiViewName("VisionAssembleInputView");

		// Token: 0x0401C80C RID: 116748
		public static readonly EUiViewName PingView = new EUiViewName("PingView");

		// Token: 0x0401C80D RID: 116749
		public static readonly EUiViewName RogueInfoView = new EUiViewName("RogueInfoView");

		// Token: 0x0401C80E RID: 116750
		public static readonly EUiViewName RogueShopView = new EUiViewName("RogueShopView");

		// Token: 0x0401C80F RID: 116751
		public static readonly EUiViewName RogueRoomTip = new EUiViewName("RogueRoomTip");

		// Token: 0x0401C810 RID: 116752
		public static readonly EUiViewName RoguelikeInstanceView = new EUiViewName("RoguelikeInstanceView");

		// Token: 0x0401C811 RID: 116753
		public static readonly EUiViewName RoguelikeSelectRoleView = new EUiViewName("RoguelikeSelectRoleView");

		// Token: 0x0401C812 RID: 116754
		public static readonly EUiViewName RoguelikeBossChallengeView = new EUiViewName("RoguelikeBossChallengeView");

		// Token: 0x0401C813 RID: 116755
		public static readonly EUiViewName RoguelikeBossChallengeBuffDetailView = new EUiViewName("RoguelikeBossChallengeBuffDetailView");

		// Token: 0x0401C814 RID: 116756
		public static readonly EUiViewName RoguelikeSettleView = new EUiViewName("RoguelikeSettleView");

		// Token: 0x0401C815 RID: 116757
		public static readonly EUiViewName RoguelikeExitTips = new EUiViewName("RoguelikeExitTips");

		// Token: 0x0401C816 RID: 116758
		public static readonly EUiViewName WeeklyRogueExitTips = new EUiViewName("WeeklyRogueExitTips");

		// Token: 0x0401C817 RID: 116759
		public static readonly EUiViewName WeeklyRogueResultCheckView = new EUiViewName("WeeklyRogueResultCheckView");

		// Token: 0x0401C818 RID: 116760
		public static readonly EUiViewName RoguelikeRoomFloatTips = new EUiViewName("RoguelikeRoomFloatTips");

		// Token: 0x0401C819 RID: 116761
		public static readonly EUiViewName BattleFloatTipsView = new EUiViewName("BattleFloatTipsView");

		// Token: 0x0401C81A RID: 116762
		public static readonly EUiViewName LoadingView = new EUiViewName("LoadingView");

		// Token: 0x0401C81B RID: 116763
		public static readonly EUiViewName RacingBetsLoadingView = new EUiViewName("RacingBetsLoadingView");

		// Token: 0x0401C81C RID: 116764
		public static readonly EUiViewName CyberpunkLoadingView = new EUiViewName("CyberpunkLoadingView");

		// Token: 0x0401C81D RID: 116765
		public static readonly EUiViewName FadeLoadingView = new EUiViewName("FadeLoadingView");

		// Token: 0x0401C81E RID: 116766
		public static readonly EUiViewName RoleLoadingView = new EUiViewName("RoleLoadingView");

		// Token: 0x0401C81F RID: 116767
		public static readonly EUiViewName SpecialTransitionView = new EUiViewName("SpecialTransitionView");

		// Token: 0x0401C820 RID: 116768
		public static readonly EUiViewName RoguelikeSkillView = new EUiViewName("RoguelikeSkillView");

		// Token: 0x0401C821 RID: 116769
		public static readonly EUiViewName RoguelikeActivityView = new EUiViewName("RoguelikeActivityView");

		// Token: 0x0401C822 RID: 116770
		public static readonly EUiViewName SoundAreaPlayTips = new EUiViewName("SoundAreaPlayTips");

		// Token: 0x0401C823 RID: 116771
		public static readonly EUiViewName ExploreDetailView = new EUiViewName("ExploreDetailView");

		// Token: 0x0401C824 RID: 116772
		public static readonly EUiViewName MapAreaShowView = new EUiViewName("MapAreaShowView");

		// Token: 0x0401C825 RID: 116773
		public static readonly EUiViewName MapExploreDetailView = new EUiViewName("MapExploreDetailView");

		// Token: 0x0401C826 RID: 116774
		public static readonly EUiViewName MapPlayPointDetailView = new EUiViewName("MapPlayPointDetailView");

		// Token: 0x0401C827 RID: 116775
		public static readonly EUiViewName MapExploreStoryView = new EUiViewName("MapExploreStoryView");

		// Token: 0x0401C828 RID: 116776
		public static readonly EUiViewName RoguelikeMemoryPlaceView = new EUiViewName("RoguelikeMemoryPlaceView");

		// Token: 0x0401C829 RID: 116777
		public static readonly EUiViewName RoguelikeAchievementView = new EUiViewName("RoguelikeAchievementView");

		// Token: 0x0401C82A RID: 116778
		public static readonly EUiViewName RoguelikeTokenOverView = new EUiViewName("RoguelikeTokenOverView");

		// Token: 0x0401C82B RID: 116779
		public static readonly EUiViewName ExploreLevelView = new EUiViewName("ExploreLevelView");

		// Token: 0x0401C82C RID: 116780
		public static readonly EUiViewName ExploreLevelPreviewView = new EUiViewName("ExploreLevelPreviewView");

		// Token: 0x0401C82D RID: 116781
		public static readonly EUiViewName RoguelikeRandomEventView = new EUiViewName("RoguelikeRandomEventView");

		// Token: 0x0401C82E RID: 116782
		public static readonly EUiViewName RogueBattleRandomEventView = new EUiViewName("RogueBattleRandomEventView");

		// Token: 0x0401C82F RID: 116783
		public static readonly EUiViewName RogueBattleSelectTokenView = new EUiViewName("RogueBattleSelectTokenView");

		// Token: 0x0401C830 RID: 116784
		public static readonly EUiViewName RogueBattlePhantomSelectView = new EUiViewName("RogueBattlePhantomSelectView");

		// Token: 0x0401C831 RID: 116785
		public static readonly EUiViewName RogueBattleShopView = new EUiViewName("RogueBattleShopView");

		// Token: 0x0401C832 RID: 116786
		public static readonly EUiViewName RogueBattleSettleView = new EUiViewName("RogueBattleSettleView");

		// Token: 0x0401C833 RID: 116787
		public static readonly EUiViewName RogueBattleTeamEditView = new EUiViewName("RogueBattleTeamEditView");

		// Token: 0x0401C834 RID: 116788
		public static readonly EUiViewName RogueBattleBuyRoleView = new EUiViewName("RogueBattleBuyRoleView");

		// Token: 0x0401C835 RID: 116789
		public static readonly EUiViewName RogueBattleRoleBuffSelectView = new EUiViewName("RogueBattleRoleBuffSelectView");

		// Token: 0x0401C836 RID: 116790
		public static readonly EUiViewName RogueBattleRoleStarUpView = new EUiViewName("RogueBattleRoleStarUpView");

		// Token: 0x0401C837 RID: 116791
		public static readonly EUiViewName RogueBattleLinkUnlockView = new EUiViewName("RogueBattleLinkUnlockView");

		// Token: 0x0401C838 RID: 116792
		public static readonly EUiViewName RogueBattleEnvironmentBuffView = new EUiViewName("RogueBattleEnvironmentBuffView");

		// Token: 0x0401C839 RID: 116793
		public static readonly EUiViewName RogueAttributeDetailView = new EUiViewName("RogueAttributeDetailView");

		// Token: 0x0401C83A RID: 116794
		public static readonly EUiViewName WeeklyRogueAttributeDetailView = new EUiViewName("WeeklyRogueAttributeDetailView");

		// Token: 0x0401C83B RID: 116795
		public static readonly EUiViewName WhiteCatWarningTips = new EUiViewName("WhiteCatWarningTips");

		// Token: 0x0401C83C RID: 116796
		public static readonly EUiViewName BlackCatWarningTips = new EUiViewName("BlackCatWarningTips");

		// Token: 0x0401C83D RID: 116797
		public static readonly EUiViewName DreamLinkDungeonView = new EUiViewName("DreamLinkDungeonView");

		// Token: 0x0401C83E RID: 116798
		public static readonly EUiViewName DreamLinkMainView = new EUiViewName("DreamLinkMainView");

		// Token: 0x0401C83F RID: 116799
		public static readonly EUiViewName DreamLinkWhiteCatView = new EUiViewName("DreamLinkWhiteCatView");

		// Token: 0x0401C840 RID: 116800
		public static readonly EUiViewName DreamLinkWorldRunView = new EUiViewName("DreamLinkWorldRunView");

		// Token: 0x0401C841 RID: 116801
		public static readonly EUiViewName DreamLinkRewardViewEnergy = new EUiViewName("DreamLinkRewardViewEnergy");

		// Token: 0x0401C842 RID: 116802
		public static readonly EUiViewName DreamLinkRewardViewLimit = new EUiViewName("DreamLinkRewardViewLimit");

		// Token: 0x0401C843 RID: 116803
		public static readonly EUiViewName LordGymUnlockTipView = new EUiViewName("LordGymUnlockTipView");

		// Token: 0x0401C844 RID: 116804
		public static readonly EUiViewName LordChallengeResultView = new EUiViewName("LordChallengeResultView");

		// Token: 0x0401C845 RID: 116805
		public static readonly EUiViewName ItemDeliverView = new EUiViewName("ItemDeliverView");

		// Token: 0x0401C846 RID: 116806
		public static readonly EUiViewName NewMissionTips = new EUiViewName("NewMissionTips");

		// Token: 0x0401C847 RID: 116807
		public static readonly EUiViewName QuestLockPreview = new EUiViewName("QuestLockPreview");

		// Token: 0x0401C848 RID: 116808
		public static readonly EUiViewName CsQuestLockPreview = new EUiViewName("CsQuestLockPreview");

		// Token: 0x0401C849 RID: 116809
		public static readonly EUiViewName SilentAreaRewardPreviewPopView = new EUiViewName("SilentAreaRewardPreviewPopView");

		// Token: 0x0401C84A RID: 116810
		public static readonly EUiViewName RoguelikeBlackFlowerPreviewView = new EUiViewName("RoguelikeBlackFlowerPreviewView");

		// Token: 0x0401C84B RID: 116811
		public static readonly EUiViewName RepeatKeyTipsView = new EUiViewName("RepeatKeyTipsView");

		// Token: 0x0401C84C RID: 116812
		public static readonly EUiViewName RemainStarWarningTips = new EUiViewName("RemainStarWarningTips");

		// Token: 0x0401C84D RID: 116813
		public static readonly EUiViewName MemoryFragmentMainView = new EUiViewName("MemoryFragmentMainView");

		// Token: 0x0401C84E RID: 116814
		public static readonly EUiViewName ObtainFragmentView = new EUiViewName("ObtainFragmentView");

		// Token: 0x0401C84F RID: 116815
		public static readonly EUiViewName MemoryDetailView = new EUiViewName("MemoryDetailView");

		// Token: 0x0401C850 RID: 116816
		public static readonly EUiViewName FragmentedCluesView = new EUiViewName("FragmentedCluesView");

		// Token: 0x0401C851 RID: 116817
		public static readonly EUiViewName RoguelikeUnlockTips = new EUiViewName("RoguelikeUnlockTips");

		// Token: 0x0401C852 RID: 116818
		public static readonly EUiViewName ChangeActionTipsView = new EUiViewName("ChangeActionTipsView");

		// Token: 0x0401C853 RID: 116819
		public static readonly EUiViewName ChangeModeTipsView = new EUiViewName("ChangeModeTipsView");

		// Token: 0x0401C854 RID: 116820
		public static readonly EUiViewName VisionRecoveryResultView = new EUiViewName("VisionRecoveryResultView");

		// Token: 0x0401C855 RID: 116821
		public static readonly EUiViewName VisionRecoveryBatchResultView = new EUiViewName("VisionRecoveryBatchResultView");

		// Token: 0x0401C856 RID: 116822
		public static readonly EUiViewName VisionRefineAttributeSelectView = new EUiViewName("VisionRefineAttributeSelectView");

		// Token: 0x0401C857 RID: 116823
		public static readonly EUiViewName VisionRefineResultView = new EUiViewName("VisionRefineResultView");

		// Token: 0x0401C858 RID: 116824
		public static readonly EUiViewName VisionRefineSubResultView = new EUiViewName("VisionRefineSubResultView");

		// Token: 0x0401C859 RID: 116825
		public static readonly EUiViewName RoleTagDetailView = new EUiViewName("RoleTagDetailView");

		// Token: 0x0401C85A RID: 116826
		public static readonly EUiViewName RoguelikeInstanceEntrySelectView = new EUiViewName("RoguelikeInstanceEntrySelectView");

		// Token: 0x0401C85B RID: 116827
		public static readonly EUiViewName RoguelikeSpecialDetailView = new EUiViewName("RoguelikeSpecialDetailView");

		// Token: 0x0401C85C RID: 116828
		public static readonly EUiViewName RoguelikeSelectSpecialView = new EUiViewName("RoguelikeSelectSpecialView");

		// Token: 0x0401C85D RID: 116829
		public static readonly EUiViewName RoguelikeEntranceView = new EUiViewName("RoguelikeEntranceView");

		// Token: 0x0401C85E RID: 116830
		public static readonly EUiViewName RoguelikeRoleAffixDetailView = new EUiViewName("RoguelikeRoleAffixDetailView");

		// Token: 0x0401C85F RID: 116831
		public static readonly EUiViewName RoguelikePhantomNewUnlockView = new EUiViewName("RoguelikePhantomNewUnlockView");

		// Token: 0x0401C860 RID: 116832
		public static readonly EUiViewName RoguelikeAchieveView = new EUiViewName("RoguelikeAchieveView");

		// Token: 0x0401C861 RID: 116833
		public static readonly EUiViewName CollectItemView = new EUiViewName("CollectItemView");

		// Token: 0x0401C862 RID: 116834
		public static readonly EUiViewName DifficultUnlockTipView = new EUiViewName("DifficultUnlockTipView");

		// Token: 0x0401C863 RID: 116835
		public static readonly EUiViewName LongShanView = new EUiViewName("LongShanView");

		// Token: 0x0401C864 RID: 116836
		public static readonly EUiViewName ExploreMissionView = new EUiViewName("ExploreMissionView");

		// Token: 0x0401C865 RID: 116837
		public static readonly EUiViewName RoleBreakPreviewView = new EUiViewName("RoleBreakPreviewView");

		// Token: 0x0401C866 RID: 116838
		public static readonly EUiViewName TowerDefenseWaveTipView = new EUiViewName("TowerDefenceWaveTipView");

		// Token: 0x0401C867 RID: 116839
		public static readonly EUiViewName TowerDefenseStrengthenTipsView = new EUiViewName("TowerDefenseStrengthenTipsView");

		// Token: 0x0401C868 RID: 116840
		public static readonly EUiViewName TowerDefenseInBattleTips = new EUiViewName("TowerDefenceInBattleTips");

		// Token: 0x0401C869 RID: 116841
		public static readonly EUiViewName TuningStandView = new EUiViewName("TuningStandView");

		// Token: 0x0401C86A RID: 116842
		public static readonly EUiViewName MoonChasingMainView = new EUiViewName("MoonChasingMainView");

		// Token: 0x0401C86B RID: 116843
		public static readonly EUiViewName MoonChasingUnlockRoleView = new EUiViewName("MoonChasingUnlockRoleView");

		// Token: 0x0401C86C RID: 116844
		public static readonly EUiViewName BuildingTipsInfoView = new EUiViewName("BuildingTipsInfoView");

		// Token: 0x0401C86D RID: 116845
		public static readonly EUiViewName BuildingLevelUpView = new EUiViewName("BuildingLevelUpView");

		// Token: 0x0401C86E RID: 116846
		public static readonly EUiViewName ScratchTicketMainView = new EUiViewName("ScratchTicketMainView");

		// Token: 0x0401C86F RID: 116847
		public static readonly EUiViewName BusinessMainView = new EUiViewName("BusinessMainView");

		// Token: 0x0401C870 RID: 116848
		public static readonly EUiViewName BusinessTipsTravelView = new EUiViewName("BusinessTipsTravelView");

		// Token: 0x0401C871 RID: 116849
		public static readonly EUiViewName BusinessTipsShopView = new EUiViewName("BusinessTipsShopView");

		// Token: 0x0401C872 RID: 116850
		public static readonly EUiViewName BusinessTipsBurstView = new EUiViewName("BusinessTipsBurstView");

		// Token: 0x0401C873 RID: 116851
		public static readonly EUiViewName BusinessTipsResultView = new EUiViewName("BusinessTipsResultView");

		// Token: 0x0401C874 RID: 116852
		public static readonly EUiViewName BusinessTipsFinishView = new EUiViewName("BusinessTipsFinishView");

		// Token: 0x0401C875 RID: 116853
		public static readonly EUiViewName BusinessTipsPopularityUpView = new EUiViewName("BusinessTipsPopularityUpView");

		// Token: 0x0401C876 RID: 116854
		public static readonly EUiViewName BusinessHelperView = new EUiViewName("BusinessHelperView");

		// Token: 0x0401C877 RID: 116855
		public static readonly EUiViewName SdkMailView = new EUiViewName("SdkMailView");

		// Token: 0x0401C878 RID: 116856
		public static readonly EUiViewName SdkLoginView = new EUiViewName("SdkLoginView");

		// Token: 0x0401C879 RID: 116857
		public static readonly EUiViewName SdkTipsPopUpView = new EUiViewName("SdkTipsPopUpView");

		// Token: 0x0401C87A RID: 116858
		public static readonly EUiViewName SdkEnterTipsView = new EUiViewName("SdkEnterTipsView");

		// Token: 0x0401C87B RID: 116859
		public static readonly EUiViewName SdkTipsMiddlePopUpView = new EUiViewName("SdkTipsMiddlePopUpView");

		// Token: 0x0401C87C RID: 116860
		public static readonly EUiViewName SdkLoadPopUpView = new EUiViewName("SdkLoadPopUpView");

		// Token: 0x0401C87D RID: 116861
		public static readonly EUiViewName MoonChasingTaskView = new EUiViewName("MoonChasingTaskView");

		// Token: 0x0401C87E RID: 116862
		public static readonly EUiViewName RewardMainView = new EUiViewName("RewardMainView");

		// Token: 0x0401C87F RID: 116863
		public static readonly EUiViewName MoonChasingHandbookView = new EUiViewName("MoonChasingHandbookView");

		// Token: 0x0401C880 RID: 116864
		public static readonly EUiViewName MoonChasingMemoryView = new EUiViewName("MoonChasingMemoryView");

		// Token: 0x0401C881 RID: 116865
		public static readonly EUiViewName MoonChasingMemoryDetailView = new EUiViewName("MoonChasingMemoryDetailView");

		// Token: 0x0401C882 RID: 116866
		public static readonly EUiViewName RoleGrowingMainView = new EUiViewName("RoleGrowingMainView");

		// Token: 0x0401C883 RID: 116867
		public static readonly EUiViewName RoleGrowingTaskView = new EUiViewName("RoleGrowingTaskView");

		// Token: 0x0401C884 RID: 116868
		public static readonly EUiViewName InstanceDungeonEntranceRootView = new EUiViewName("InstanceDungeonEntranceRootView");

		// Token: 0x0401C885 RID: 116869
		public static readonly EUiViewName MowingBuffView = new EUiViewName("MowingBuffView");

		// Token: 0x0401C886 RID: 116870
		public static readonly EUiViewName MowingRiskBuffTipView = new EUiViewName("MowingRiskBuffTipView");

		// Token: 0x0401C887 RID: 116871
		public static readonly EUiViewName MowingBuffNewBuffTipsView = new EUiViewName("MowingBuffNewBuffTipsView");

		// Token: 0x0401C888 RID: 116872
		public static readonly EUiViewName VersionPreheatQuestDetailView = new EUiViewName("VersionPreheatQuestDetailView");

		// Token: 0x0401C889 RID: 116873
		public static readonly EUiViewName VersionPreheatVoteView = new EUiViewName("VersionPreheatVoteView");

		// Token: 0x0401C88A RID: 116874
		public static readonly EUiViewName CookMechanismRootView = new EUiViewName("CookMechanismRootView");

		// Token: 0x0401C88B RID: 116875
		public static readonly EUiViewName Spring25MainView = new EUiViewName("Spring25MainView");

		// Token: 0x0401C88C RID: 116876
		public static readonly EUiViewName Spring25DialogueView = new EUiViewName("Spring25DialogueView");

		// Token: 0x0401C88D RID: 116877
		public static readonly EUiViewName Spring25EnvelopeView = new EUiViewName("Spring25EnvelopeView");

		// Token: 0x0401C88E RID: 116878
		public static readonly EUiViewName Spring25LetterListView = new EUiViewName("Spring25LetterListView");

		// Token: 0x0401C88F RID: 116879
		public static readonly EUiViewName Spring25InfoView = new EUiViewName("Spring25InfoView");

		// Token: 0x0401C890 RID: 116880
		public static readonly EUiViewName MapTravelMainView = new EUiViewName("MapTravelMainView");

		// Token: 0x0401C891 RID: 116881
		public static readonly EUiViewName ActivityUnlockTipMapTravelView = new EUiViewName("ActivityUnlockTipMapTravelView");

		// Token: 0x0401C892 RID: 116882
		public static readonly EUiViewName TravelLevelTipsView = new EUiViewName("TravelLevelTipsView");

		// Token: 0x0401C893 RID: 116883
		public static readonly EUiViewName ActivityRegressStartupView = new EUiViewName("ActivityRegressStartupView");

		// Token: 0x0401C894 RID: 116884
		public static readonly EUiViewName ActivityRegressNewVersionMainView = new EUiViewName("ActivityRegressNewVersionMainView");

		// Token: 0x0401C895 RID: 116885
		public static readonly EUiViewName ActivityRegressMainView = new EUiViewName("ActivityRegressMainView");

		// Token: 0x0401C896 RID: 116886
		public static readonly EUiViewName ActivityRegressQuestionnaireView = new EUiViewName("ActivityRegressQuestionnaireView");

		// Token: 0x0401C897 RID: 116887
		public static readonly EUiViewName ActivityRegressTaskMainView = new EUiViewName("ActivityRegressTaskMainView");

		// Token: 0x0401C898 RID: 116888
		public static readonly EUiViewName ActivityRecommendView = new EUiViewName("ActivityRecommendView");

		// Token: 0x0401C899 RID: 116889
		public static readonly EUiViewName DigitalScreenaView = new EUiViewName("DigitalScreenA");

		// Token: 0x0401C89A RID: 116890
		public static readonly EUiViewName DigitalScreenbView = new EUiViewName("DigitalScreenB");

		// Token: 0x0401C89B RID: 116891
		public static readonly EUiViewName GachaPoolDetailView = new EUiViewName("GachaPoolDetailView");

		// Token: 0x0401C89C RID: 116892
		public static readonly EUiViewName RogueSilentAreaFloatTips = new EUiViewName("RogueSilentAreaFloatTips");

		// Token: 0x0401C89D RID: 116893
		public static readonly EUiViewName CorniceMeetingSettleView = new EUiViewName("CorniceMeetingSettleView");

		// Token: 0x0401C89E RID: 116894
		public static readonly EUiViewName MobileSwitchInputView = new EUiViewName("MobileSwitchInputView");

		// Token: 0x0401C89F RID: 116895
		public static readonly EUiViewName SdkPayProductInformationView = new EUiViewName("SdkPayProductInformationView");

		// Token: 0x0401C8A0 RID: 116896
		public static readonly EUiViewName DarkCoastDeliveryMainView = new EUiViewName("DarkCoastDeliveryMainView");

		// Token: 0x0401C8A1 RID: 116897
		public static readonly EUiViewName DarkCoastDeliveryLevelUpView = new EUiViewName("DarkCoastDeliveryLevelUpView");

		// Token: 0x0401C8A2 RID: 116898
		public static readonly EUiViewName BattleLinkView = new EUiViewName("BattleLinkView");

		// Token: 0x0401C8A3 RID: 116899
		public static readonly EUiViewName OperationPreferencesView = new EUiViewName("OperationPreferencesView");

		// Token: 0x0401C8A4 RID: 116900
		public static readonly EUiViewName MailBindView = new EUiViewName("MailBindView");

		// Token: 0x0401C8A5 RID: 116901
		public static readonly EUiViewName SkinRootView = new EUiViewName("SkinRootView");

		// Token: 0x0401C8A6 RID: 116902
		public static readonly EUiViewName RecommendQualityView = new EUiViewName("RecommendQualityView");

		// Token: 0x0401C8A7 RID: 116903
		public static readonly EUiViewName MowingTowerMainView = new EUiViewName("MowingTowerMainView");

		// Token: 0x0401C8A8 RID: 116904
		public static readonly EUiViewName MowingTowerFloorView = new EUiViewName("MowingTowerFloorView");

		// Token: 0x0401C8A9 RID: 116905
		public static readonly EUiViewName MowingTowerBuffView = new EUiViewName("MowingTowerBuffView");

		// Token: 0x0401C8AA RID: 116906
		public static readonly EUiViewName MowingTowerRewardView = new EUiViewName("MowingTowerRewardView");

		// Token: 0x0401C8AB RID: 116907
		public static readonly EUiViewName LifePointView = new EUiViewName("LifePointView");

		// Token: 0x0401C8AC RID: 116908
		public static readonly EUiViewName CheckInteractionView = new EUiViewName("CheckInteractionView");

		// Token: 0x0401C8AD RID: 116909
		public static readonly EUiViewName BigStuffedDollView = new EUiViewName("BigStuffedDollView");

		// Token: 0x0401C8AE RID: 116910
		public static readonly EUiViewName FlySettlementView = new EUiViewName("FlySettlementView");

		// Token: 0x0401C8AF RID: 116911
		public static readonly EUiViewName SkinObtainView = new EUiViewName("SkinObtainView");

		// Token: 0x0401C8B0 RID: 116912
		public static readonly EUiViewName FlySkinObtainView = new EUiViewName("FlySkinObtainView");

		// Token: 0x0401C8B1 RID: 116913
		public static readonly EUiViewName SkinShowView = new EUiViewName("SkinShowView");

		// Token: 0x0401C8B2 RID: 116914
		public static readonly EUiViewName SkinBuyDetailView = new EUiViewName("SkinBuyDetailView");

		// Token: 0x0401C8B3 RID: 116915
		public static readonly EUiViewName FlySkinBuyDetailView = new EUiViewName("FlySkinBuyDetailView");

		// Token: 0x0401C8B4 RID: 116916
		public static readonly EUiViewName FlySkinShowView = new EUiViewName("FlySkinShowView");

		// Token: 0x0401C8B5 RID: 116917
		public static readonly EUiViewName MotorSkinBuyDetailView = new EUiViewName("MotorSkinBuyDetailView");

		// Token: 0x0401C8B6 RID: 116918
		public static readonly EUiViewName EquipBuffItemDetailView = new EUiViewName("EquipBuffItemDetailView");

		// Token: 0x0401C8B7 RID: 116919
		public static readonly EUiViewName RoleOrnamentShowView = new EUiViewName("RoleOrnamentShowView");

		// Token: 0x0401C8B8 RID: 116920
		public static readonly EUiViewName WeaponSkinShowView = new EUiViewName("WeaponSkinShowView");

		// Token: 0x0401C8B9 RID: 116921
		public static readonly EUiViewName DockyardView = new EUiViewName("DockyardView");

		// Token: 0x0401C8BA RID: 116922
		public static readonly EUiViewName DockyardWareHouseView = new EUiViewName("DockyardWareHouseView");

		// Token: 0x0401C8BB RID: 116923
		public static readonly EUiViewName DockyardCageView = new EUiViewName("DockyardCageView");

		// Token: 0x0401C8BC RID: 116924
		public static readonly EUiViewName DockyardShopMainView = new EUiViewName("DockyardShopMainView");

		// Token: 0x0401C8BD RID: 116925
		public static readonly EUiViewName DockyardInteractView = new EUiViewName("DockyardInteractView");

		// Token: 0x0401C8BE RID: 116926
		public static readonly EUiViewName FishingDockView = new EUiViewName("FishingDockView");

		// Token: 0x0401C8BF RID: 116927
		public static readonly EUiViewName SailingView = new EUiViewName("SailingView");

		// Token: 0x0401C8C0 RID: 116928
		public static readonly EUiViewName ShipSkinView = new EUiViewName("ShipSkinView");

		// Token: 0x0401C8C1 RID: 116929
		public static readonly EUiViewName FishingQteView = new EUiViewName("FishingQteView");

		// Token: 0x0401C8C2 RID: 116930
		public static readonly EUiViewName FishingQtePauseView = new EUiViewName("FishingQtePauseView");

		// Token: 0x0401C8C3 RID: 116931
		public static readonly EUiViewName FishingQteSuccessView = new EUiViewName("FishingQteSuccessView");

		// Token: 0x0401C8C4 RID: 116932
		public static readonly EUiViewName DockyardInteractFinishTipsView = new EUiViewName("DockyardInteractFinishTipsView");

		// Token: 0x0401C8C5 RID: 116933
		public static readonly EUiViewName FishingTechRootView = new EUiViewName("FishingTechRootView");

		// Token: 0x0401C8C6 RID: 116934
		public static readonly EUiViewName FishingLevelUpTips = new EUiViewName("FishingLevelUpTips");

		// Token: 0x0401C8C7 RID: 116935
		public static readonly EUiViewName FishingWarningTips = new EUiViewName("FishingWarningTips");

		// Token: 0x0401C8C8 RID: 116936
		public static readonly EUiViewName FishingQuestView = new EUiViewName("FishingQuestView");

		// Token: 0x0401C8C9 RID: 116937
		public static readonly EUiViewName FishingHandBookView = new EUiViewName("FishingHandBookView");

		// Token: 0x0401C8CA RID: 116938
		public static readonly EUiViewName FishingTimeLimitView = new EUiViewName("FishingTimeLimitView");

		// Token: 0x0401C8CB RID: 116939
		public static readonly EUiViewName FishingActivityUnlockView = new EUiViewName("FishingActivityUnlockView");

		// Token: 0x0401C8CC RID: 116940
		public static readonly EUiViewName FishingHandBookRewardView = new EUiViewName("FishingHandBookRewardView");

		// Token: 0x0401C8CD RID: 116941
		public static readonly EUiViewName FishingLoadingView = new EUiViewName("FishingLoadingView");

		// Token: 0x0401C8CE RID: 116942
		public static readonly EUiViewName FishingTechLevelUpSuccessView = new EUiViewName("FishingTechLevelUpSuccessView");

		// Token: 0x0401C8CF RID: 116943
		public static readonly EUiViewName FishingLevelUpView = new EUiViewName("FishingLevelUpView");

		// Token: 0x0401C8D0 RID: 116944
		public static readonly EUiViewName RacingBetsMainView = new EUiViewName("RacingBetsMainView");

		// Token: 0x0401C8D1 RID: 116945
		public static readonly EUiViewName RacingBetsBettingView = new EUiViewName("RacingBetsBettingView");

		// Token: 0x0401C8D2 RID: 116946
		public static readonly EUiViewName RacingBetsRewardView = new EUiViewName("RacingBetsRewardView");

		// Token: 0x0401C8D3 RID: 116947
		public static readonly EUiViewName RacingBetsConfirmBoxView = new EUiViewName("RacingBetsConfirmBoxView");

		// Token: 0x0401C8D4 RID: 116948
		public static readonly EUiViewName CyberpunkConfirmBoxView = new EUiViewName("CyberpunkConfirmBoxView");

		// Token: 0x0401C8D5 RID: 116949
		public static readonly EUiViewName RacingBetsGamePlayView = new EUiViewName("RacingBetsGamePlayView");

		// Token: 0x0401C8D6 RID: 116950
		public static readonly EUiViewName RacingBetsGamePlayPreviewView = new EUiViewName("RacingBetsGamePlayPreviewView");

		// Token: 0x0401C8D7 RID: 116951
		public static readonly EUiViewName RacingBetsHistoryView = new EUiViewName("RacingBetsHistoryView");

		// Token: 0x0401C8D8 RID: 116952
		public static readonly EUiViewName RacingBetsRankView = new EUiViewName("RacingBetsRankView");

		// Token: 0x0401C8D9 RID: 116953
		public static readonly EUiViewName RacingBetsMatchView = new EUiViewName("RacingBetsMatchView");

		// Token: 0x0401C8DA RID: 116954
		public static readonly EUiViewName RacingBetsSuccessTip = new EUiViewName("RacingBetsSuccessTip");

		// Token: 0x0401C8DB RID: 116955
		public static readonly EUiViewName RacingBetsFailTip = new EUiViewName("RacingBetsFailTip");

		// Token: 0x0401C8DC RID: 116956
		public static readonly EUiViewName RacingBetsActivityRewardView = new EUiViewName("RacingBetsActivityRewardView");

		// Token: 0x0401C8DD RID: 116957
		public static readonly EUiViewName RacingBetsDungeonBeginTip = new EUiViewName("RacingBetsDungeonBeginTip");

		// Token: 0x0401C8DE RID: 116958
		public static readonly EUiViewName RacingBetsDangoSkillView = new EUiViewName("RacingBetsDangoSkillView");

		// Token: 0x0401C8DF RID: 116959
		public static readonly EUiViewName RacingBetsDangoTerrainView = new EUiViewName("RacingBetsDangoTerrainView");

		// Token: 0x0401C8E0 RID: 116960
		public static readonly EUiViewName RacingBetsDangoSkillTip = new EUiViewName("RacingBetsDangoSkillTip");

		// Token: 0x0401C8E1 RID: 116961
		public static readonly EUiViewName RacingBetsTerrainTip = new EUiViewName("RacingBetsTerrainTip");

		// Token: 0x0401C8E2 RID: 116962
		public static readonly EUiViewName RacingBetsSpecialTip = new EUiViewName("RacingBetsSpecialTip");

		// Token: 0x0401C8E3 RID: 116963
		public static readonly EUiViewName RacingBetsDangoFrameTipView = new EUiViewName("RacingBetsDangoFrameTipView");

		// Token: 0x0401C8E4 RID: 116964
		public static readonly EUiViewName RacingBetsDungeonResultView = new EUiViewName("RacingBetsDungeonResultView");

		// Token: 0x0401C8E5 RID: 116965
		public static readonly EUiViewName RacingBetsDangoActivityOpenTips = new EUiViewName("RacingBetsDangoActivityOpenTips");

		// Token: 0x0401C8E6 RID: 116966
		public static readonly EUiViewName SkipMainQuestWindowView = new EUiViewName("SkipMainQuestWindowView");

		// Token: 0x0401C8E7 RID: 116967
		public static readonly EUiViewName DirectTrainProView = new EUiViewName("DirectTrainProView");

		// Token: 0x0401C8E8 RID: 116968
		public static readonly EUiViewName DirectTrainDetailView = new EUiViewName("DirectTrainDetailView");

		// Token: 0x0401C8E9 RID: 116969
		public static readonly EUiViewName ShipTogetherView = new EUiViewName("ShipTogetherView");

		// Token: 0x0401C8EA RID: 116970
		public static readonly EUiViewName ChapterA = new EUiViewName("ChapterA");

		// Token: 0x0401C8EB RID: 116971
		public static readonly EUiViewName PlotChapterA = new EUiViewName("PlotChapterA");

		// Token: 0x0401C8EC RID: 116972
		public static readonly EUiViewName SolarSpeedRewardView = new EUiViewName("SolarSpeedRewardView");

		// Token: 0x0401C8ED RID: 116973
		public static readonly EUiViewName SolarSpeedResultView = new EUiViewName("SolarSpeedResultView");

		// Token: 0x0401C8EE RID: 116974
		public static readonly EUiViewName HiddenBossWindow = new EUiViewName("HiddenBossWindow");

		// Token: 0x0401C8EF RID: 116975
		public static readonly EUiViewName ComposeCarryOnView = new EUiViewName("ComposeCarryOnView");

		// Token: 0x0401C8F0 RID: 116976
		public static readonly EUiViewName LiuLiDaoLingView = new EUiViewName("LiuLiDaoLingView");

		// Token: 0x0401C8F1 RID: 116977
		public static readonly EUiViewName GuYingXiongKaiView = new EUiViewName("GuYingXiongKaiView");

		// Token: 0x0401C8F2 RID: 116978
		public static readonly EUiViewName ShipTowerView = new EUiViewName("ShipTowerView");

		// Token: 0x0401C8F3 RID: 116979
		public static readonly EUiViewName ShipTowerBuffView = new EUiViewName("ShipTowerBuffView");

		// Token: 0x0401C8F4 RID: 116980
		public static readonly EUiViewName ShipTowerFightFinishView = new EUiViewName("ShipTowerFightFinishView");

		// Token: 0x0401C8F5 RID: 116981
		public static readonly EUiViewName ShipTowerDescView = new EUiViewName("ShipTowerDescView");

		// Token: 0x0401C8F6 RID: 116982
		public static readonly EUiViewName ShipTowerResetView = new EUiViewName("ShipTowerResetView");

		// Token: 0x0401C8F7 RID: 116983
		public static readonly EUiViewName ShipTowerGetBuffView = new EUiViewName("ShipTowerGetBuffView");

		// Token: 0x0401C8F8 RID: 116984
		public static readonly EUiViewName ShipTowerCoverView = new EUiViewName("ShipTowerCoverView");

		// Token: 0x0401C8F9 RID: 116985
		public static readonly EUiViewName ShipTowerRewardView = new EUiViewName("ShipTowerRewardView");

		// Token: 0x0401C8FA RID: 116986
		public static readonly EUiViewName ShipTowerPassBuffShowView = new EUiViewName("ShipTowerPassBuffShowView");

		// Token: 0x0401C8FB RID: 116987
		public static readonly EUiViewName ShipTowerTeamRecommendView = new EUiViewName("ShipTowerTeamRecommendView");

		// Token: 0x0401C8FC RID: 116988
		public static readonly EUiViewName ShipTowerMonsterDescView = new EUiViewName("ShipTowerMonsterDescView");

		// Token: 0x0401C8FD RID: 116989
		public static readonly EUiViewName ShipTowerRecordView = new EUiViewName("ShipTowerRecordView");

		// Token: 0x0401C8FE RID: 116990
		public static readonly EUiViewName ShipTowerReviewView = new EUiViewName("ShipTowerReviewView");

		// Token: 0x0401C8FF RID: 116991
		public static readonly EUiViewName ShipTowerCountDownView = new EUiViewName("ShipTowerCountDownView");

		// Token: 0x0401C900 RID: 116992
		public static readonly EUiViewName ShipTowerShowBuffView = new EUiViewName("ShipTowerShowBuffView");

		// Token: 0x0401C901 RID: 116993
		public static readonly EUiViewName ShipTowerLoadingView = new EUiViewName("ShipTowerLoadingView");

		// Token: 0x0401C902 RID: 116994
		public static readonly EUiViewName ShipTowerWelcomeView = new EUiViewName("ShipTowerWelcomeView");

		// Token: 0x0401C903 RID: 116995
		public static readonly EUiViewName ShipTowerLevelInfoView = new EUiViewName("ShipTowerLevelInfoView");

		// Token: 0x0401C904 RID: 116996
		public static readonly EUiViewName WeeklyRogueEnvironmentTips = new EUiViewName("WeeklyRogueEnvironmentTips");

		// Token: 0x0401C905 RID: 116997
		public static readonly EUiViewName NetworkDetectionView = new EUiViewName("NetworkDetectionView");

		// Token: 0x0401C906 RID: 116998
		public static readonly EUiViewName NetworkDetectionSelectServerView = new EUiViewName("NetworkDetectionSelectServerView");

		// Token: 0x0401C907 RID: 116999
		public static readonly EUiViewName DangoAbyssInsSelectView = new EUiViewName("DangoAbyssInsSelectView");

		// Token: 0x0401C908 RID: 117000
		public static readonly EUiViewName DangoAbyssEntranceView = new EUiViewName("DangoAbyssEntranceView");

		// Token: 0x0401C909 RID: 117001
		public static readonly EUiViewName DangoAbyssRootView = new EUiViewName("DangoAbyssRootView");

		// Token: 0x0401C90A RID: 117002
		public static readonly EUiViewName DangoAbyssLevelUpView = new EUiViewName("DangoAbyssLevelUpView");

		// Token: 0x0401C90B RID: 117003
		public static readonly EUiViewName DangoAbyssPluginEquipView = new EUiViewName("DangoAbyssPluginEquipView");

		// Token: 0x0401C90C RID: 117004
		public static readonly EUiViewName DangoAbyssSelectDangoView = new EUiViewName("DangoAbyssSelectDangoView");

		// Token: 0x0401C90D RID: 117005
		public static readonly EUiViewName DangoAbyssPluginRecoveryView = new EUiViewName("DangoAbyssPluginRecoveryView");

		// Token: 0x0401C90E RID: 117006
		public static readonly EUiViewName DangoAbyssPluginRecoveryResultView = new EUiViewName("DangoAbyssPluginRecoveryResultView");

		// Token: 0x0401C90F RID: 117007
		public static readonly EUiViewName DangoAbyssRankView = new EUiViewName("DangoAbyssRankView");

		// Token: 0x0401C910 RID: 117008
		public static readonly EUiViewName DangoAbyssWorldView = new EUiViewName("DangoAbyssWorldView");

		// Token: 0x0401C911 RID: 117009
		public static readonly EUiViewName DangoAbyssWorldLoadingView = new EUiViewName("DangoAbyssWorldLoadingView");

		// Token: 0x0401C912 RID: 117010
		public static readonly EUiViewName DangoAbyssInfoView = new EUiViewName("DangoAbyssInfoView");

		// Token: 0x0401C913 RID: 117011
		public static readonly EUiViewName DangoAbyssTimeLimitRewardView = new EUiViewName("DangoAbyssTimeLimitRewardView");

		// Token: 0x0401C914 RID: 117012
		public static readonly EUiViewName DangoAbyssCommonRewardView = new EUiViewName("DangoAbyssCommonRewardView");

		// Token: 0x0401C915 RID: 117013
		public static readonly EUiViewName DangoAbyssTimeLimitRewardActivityView = new EUiViewName("DangoAbyssTimeLimitRewardActivityView");

		// Token: 0x0401C916 RID: 117014
		public static readonly EUiViewName DangoAbyssCommonRewardActivityView = new EUiViewName("DangoAbyssCommonRewardActivityView");

		// Token: 0x0401C917 RID: 117015
		public static readonly EUiViewName DangoAbyssShopView = new EUiViewName("DangoAbyssShopView");

		// Token: 0x0401C918 RID: 117016
		public static readonly EUiViewName DangoAbyssGetDangoView = new EUiViewName("DangoAbyssGetDangoView");

		// Token: 0x0401C919 RID: 117017
		public static readonly EUiViewName DangoAbyssActivityOpen = new EUiViewName("DangoAbyssActivityOpen");

		// Token: 0x0401C91A RID: 117018
		public static readonly EUiViewName DangoAbyssNpcTips = new EUiViewName("DangoAbyssNpcTips");

		// Token: 0x0401C91B RID: 117019
		public static readonly EUiViewName DangoAbyssAttributeDetailView = new EUiViewName("DangoAbyssAttributeDetailView");

		// Token: 0x0401C91C RID: 117020
		public static readonly EUiViewName GravityFlipView = new EUiViewName("GravityFlipView");

		// Token: 0x0401C91D RID: 117021
		public static readonly EUiViewName BabelTowerMainView = new EUiViewName("BabelTowerMainView");

		// Token: 0x0401C91E RID: 117022
		public static readonly EUiViewName BabelTowerBuffSelectView = new EUiViewName("BabelTowerBuffSelectView");

		// Token: 0x0401C91F RID: 117023
		public static readonly EUiViewName BabelTowerNormalLevelChoseView = new EUiViewName("BabelTowerNormalLevelChoseView");

		// Token: 0x0401C920 RID: 117024
		public static readonly EUiViewName BabelTowerHardLevelChoseView = new EUiViewName("BabelTowerHardLevelChoseView");

		// Token: 0x0401C921 RID: 117025
		public static readonly EUiViewName BabelTowerDeTermSelectView = new EUiViewName("BabelTowerDeTermSelectView");

		// Token: 0x0401C922 RID: 117026
		public static readonly EUiViewName BabelTowerDeTermSelectViewNew = new EUiViewName("BabelTowerDeTermSelectViewNew");

		// Token: 0x0401C923 RID: 117027
		public static readonly EUiViewName BabelTowerLevelInfoView = new EUiViewName("BabelTowerLevelInfoView");

		// Token: 0x0401C924 RID: 117028
		public static readonly EUiViewName BabelTowerQuestView = new EUiViewName("BabelTowerQuestView");

		// Token: 0x0401C925 RID: 117029
		public static readonly EUiViewName TowerDefenseRankView = new EUiViewName("TowerDefenseRankView");

		// Token: 0x0401C926 RID: 117030
		public static readonly EUiViewName TowerDefenseRankViewV2 = new EUiViewName("TowerDefenseRankViewV2");

		// Token: 0x0401C927 RID: 117031
		public static readonly EUiViewName TowerDefenseRewardView = new EUiViewName("TowerDefenseRewardView");

		// Token: 0x0401C928 RID: 117032
		public static readonly EUiViewName TowerDefenseSettleView = new EUiViewName("TowerDefenseSettleView");

		// Token: 0x0401C929 RID: 117033
		public static readonly EUiViewName TowerDefensePopupView = new EUiViewName("TowerDefensePopupView");

		// Token: 0x0401C92A RID: 117034
		public static readonly EUiViewName BabelTowerItemInfoView = new EUiViewName("BabelTowerItemInfoView");

		// Token: 0x0401C92B RID: 117035
		public static readonly EUiViewName BabelTowerResetView = new EUiViewName("BabelTowerResetView");

		// Token: 0x0401C92C RID: 117036
		public static readonly EUiViewName ActivityUnlockTipAvignonView = new EUiViewName("ActivityUnlockTipAvignonView");

		// Token: 0x0401C92D RID: 117037
		public static readonly EUiViewName AvignonActivityMainView = new EUiViewName("AvignonActivityMainView");

		// Token: 0x0401C92E RID: 117038
		public static readonly EUiViewName AvignonStageTaskView = new EUiViewName("AvignonStageTaskView");

		// Token: 0x0401C92F RID: 117039
		public static readonly EUiViewName PlayerTitleInfoTip = new EUiViewName("PlayerTitleInfoTip");

		// Token: 0x0401C930 RID: 117040
		public static readonly EUiViewName BabelTowerBuffView = new EUiViewName("BabelTowerBuffView");

		// Token: 0x0401C931 RID: 117041
		public static readonly EUiViewName BabelTowerSettlementView = new EUiViewName("BabelTowerSettlementView");

		// Token: 0x0401C932 RID: 117042
		public static readonly EUiViewName BabelTowerReviveView = new EUiViewName("BabelTowerReviveView");

		// Token: 0x0401C933 RID: 117043
		public static readonly EUiViewName BabelTowerNewLevelTipsView = new EUiViewName("BabelTowerNewLevelTipsView");

		// Token: 0x0401C934 RID: 117044
		public static readonly EUiViewName BabelTowerHardLevelInfoView = new EUiViewName("BabelTowerHardLevelInfoView");

		// Token: 0x0401C935 RID: 117045
		public static readonly EUiViewName BabelTowerHardLevelInfoViewNew = new EUiViewName("BabelTowerHardLevelInfoViewNew");

		// Token: 0x0401C936 RID: 117046
		public static readonly EUiViewName BabelTowerRankView = new EUiViewName("BabelTowerRankView");

		// Token: 0x0401C937 RID: 117047
		public static readonly EUiViewName BasicGraphicSettingView = new EUiViewName("BasicGraphicSettingView");

		// Token: 0x0401C938 RID: 117048
		public static readonly EUiViewName RogueBattleRoleAffixDetailView = new EUiViewName("RogueBattleRoleAffixDetailView");

		// Token: 0x0401C939 RID: 117049
		public static readonly EUiViewName RogueBattleSummary = new EUiViewName("RogueBattleSummary");

		// Token: 0x0401C93A RID: 117050
		public static readonly EUiViewName RogueBattleMapSummaryView = new EUiViewName("RogueBattleMapSummaryView");

		// Token: 0x0401C93B RID: 117051
		public static readonly EUiViewName RogueTokenIllustratedView = new EUiViewName("RogueTokenIllustratedView");

		// Token: 0x0401C93C RID: 117052
		public static readonly EUiViewName RogueEventIllustratedView = new EUiViewName("RogueEventIllustratedView");

		// Token: 0x0401C93D RID: 117053
		public static readonly EUiViewName RogueIllustratedView = new EUiViewName("RogueIllustratedView");

		// Token: 0x0401C93E RID: 117054
		public static readonly EUiViewName RogueTaskView = new EUiViewName("RogueTaskView");

		// Token: 0x0401C93F RID: 117055
		public static readonly EUiViewName RogueDungeonEntryView = new EUiViewName("RogueDungeonEntryView");

		// Token: 0x0401C940 RID: 117056
		public static readonly EUiViewName RogueSeasonEntranceView = new EUiViewName("RogueSeasonEntranceView");

		// Token: 0x0401C941 RID: 117057
		public static readonly EUiViewName RogueResSkillView = new EUiViewName("RogueResSkillView");

		// Token: 0x0401C942 RID: 117058
		public static readonly EUiViewName RogueResSkillOverView = new EUiViewName("RogueResSkillOverView");

		// Token: 0x0401C943 RID: 117059
		public static readonly EUiViewName RogueResEndingView = new EUiViewName("RogueResEndingView");

		// Token: 0x0401C944 RID: 117060
		public static readonly EUiViewName RogueResEndingSubView = new EUiViewName("RogueResEndingSubView");

		// Token: 0x0401C945 RID: 117061
		public static readonly EUiViewName RogueResTrialView = new EUiViewName("RogueResTrialView");

		// Token: 0x0401C946 RID: 117062
		public static readonly EUiViewName RogueResOpenTips = new EUiViewName("RogueResOpenTips");

		// Token: 0x0401C947 RID: 117063
		public static readonly EUiViewName RogueBattleTeamRoleSelectView = new EUiViewName("RogueBattleTeamRoleSelectView");

		// Token: 0x0401C948 RID: 117064
		public static readonly EUiViewName CiacconaGalView = new EUiViewName("CiacconaGalView");

		// Token: 0x0401C949 RID: 117065
		public static readonly EUiViewName CiacconaGalChapterView = new EUiViewName("CiacconaGalChapterView");

		// Token: 0x0401C94A RID: 117066
		public static readonly EUiViewName CiacconaGalEndingView = new EUiViewName("CiacconaGalEndingView");

		// Token: 0x0401C94B RID: 117067
		public static readonly EUiViewName CiacconaGalChapterEntryView = new EUiViewName("CiacconaGalChapterEntryView");

		// Token: 0x0401C94C RID: 117068
		public static readonly EUiViewName CiacconaActivityRewardView = new EUiViewName("CiacconaActivityRewardView");

		// Token: 0x0401C94D RID: 117069
		public static readonly EUiViewName CiacconaGalEndingDetailView = new EUiViewName("CiacconaGalEndingDetailView");

		// Token: 0x0401C94E RID: 117070
		public static readonly EUiViewName PhantomArenaBattleView = new EUiViewName("PhantomArenaBattleView");

		// Token: 0x0401C94F RID: 117071
		public static readonly EUiViewName DeckBuilderCardInfoView = new EUiViewName("DeckBuilderCardInfoView");

		// Token: 0x0401C950 RID: 117072
		public static readonly EUiViewName PhantomArenaChangeCardView = new EUiViewName("PhantomArenaChangeCardView");

		// Token: 0x0401C951 RID: 117073
		public static readonly EUiViewName PhantomArenaBattleLoading = new EUiViewName("PhantomArenaBattleLoading");

		// Token: 0x0401C952 RID: 117074
		public static readonly EUiViewName PhantomArenaBattleVsView = new EUiViewName("PhantomArenaBattleVsView");

		// Token: 0x0401C953 RID: 117075
		public static readonly EUiViewName PhantomArenaBattleDetailsView = new EUiViewName("PhantomArenaBattleDetailsView");

		// Token: 0x0401C954 RID: 117076
		public static readonly EUiViewName PhantomArenaCoreCardView = new EUiViewName("PhantomArenaCoreCardView");

		// Token: 0x0401C955 RID: 117077
		public static readonly EUiViewName PhantomArenaStartView = new EUiViewName("PhantomArenaStartView");

		// Token: 0x0401C956 RID: 117078
		public static readonly EUiViewName PhantomArenaMainView = new EUiViewName("PhantomArenaMainView");

		// Token: 0x0401C957 RID: 117079
		public static readonly EUiViewName DeckBuilderCardDeleteView = new EUiViewName("DeckBuilderCardDeleteView");

		// Token: 0x0401C958 RID: 117080
		public static readonly EUiViewName PhantomArenaCardRewardView = new EUiViewName("PhantomArenaCardRewardView");

		// Token: 0x0401C959 RID: 117081
		public static readonly EUiViewName PhantomArenaCardsRewardView = new EUiViewName("PhantomArenaCardsRewardView");

		// Token: 0x0401C95A RID: 117082
		public static readonly EUiViewName PhantomArenaCardOutlookRewardView = new EUiViewName("PhantomArenaCardOutlookRewardView");

		// Token: 0x0401C95B RID: 117083
		public static readonly EUiViewName PhantomArenaEntranceView = new EUiViewName("PhantomArenaEntranceView");

		// Token: 0x0401C95C RID: 117084
		public static readonly EUiViewName PhantomArenaMatchView = new EUiViewName("PhantomArenaMatchView");

		// Token: 0x0401C95D RID: 117085
		public static readonly EUiViewName CollectCardDetailView = new EUiViewName("CollectCardDetailView");

		// Token: 0x0401C95E RID: 117086
		public static readonly EUiViewName PhantomArenaCollectView = new EUiViewName("PhantomArenaCollectView");

		// Token: 0x0401C95F RID: 117087
		public static readonly EUiViewName PhantomArenaCollectViewNew = new EUiViewName("PhantomArenaCollectViewNew");

		// Token: 0x0401C960 RID: 117088
		public static readonly EUiViewName PhantomArenaBattleResultView = new EUiViewName("PhantomArenaBattleResultView");

		// Token: 0x0401C961 RID: 117089
		public static readonly EUiViewName PhantomArenaBattleResultViewNew = new EUiViewName("PhantomArenaBattleResultViewNew");

		// Token: 0x0401C962 RID: 117090
		public static readonly EUiViewName PhantomArenaMasterInfoView = new EUiViewName("PhantomArenaMasterInfoView");

		// Token: 0x0401C963 RID: 117091
		public static readonly EUiViewName PhantomArenaRoleCutInView = new EUiViewName("PhantomArenaRoleCutInView");

		// Token: 0x0401C964 RID: 117092
		public static readonly EUiViewName PhantomArenaEntranceShopMainView = new EUiViewName("PhantomArenaEntranceShopMainView");

		// Token: 0x0401C965 RID: 117093
		public static readonly EUiViewName DeckRenameInputView = new EUiViewName("DeckRenameInputView");

		// Token: 0x0401C966 RID: 117094
		public static readonly EUiViewName DeckBuilderQuicklyBuildView = new EUiViewName("DeckBuilderQuicklyBuildView");

		// Token: 0x0401C967 RID: 117095
		public static readonly EUiViewName PhantomArenaDeckDetailView = new EUiViewName("PhantomArenaDeckDetailView");

		// Token: 0x0401C968 RID: 117096
		public static readonly EUiViewName PhantomArenaDeckDetailViewNew = new EUiViewName("PhantomArenaDeckDetailViewNew");

		// Token: 0x0401C969 RID: 117097
		public static readonly EUiViewName PhantomArenaCardBattleLoadingView = new EUiViewName("PhantomArenaCardBattleLoadingView");

		// Token: 0x0401C96A RID: 117098
		public static readonly EUiViewName PhantomArenaBattleFloatTips = new EUiViewName("PhantomArenaBattleFloatTips");

		// Token: 0x0401C96B RID: 117099
		public static readonly EUiViewName PhantomArenaBadgeUnlockView = new EUiViewName("PhantomArenaBadgeUnlockView");

		// Token: 0x0401C96C RID: 117100
		public static readonly EUiViewName PhantomArenaRoleUnlockView = new EUiViewName("PhantomArenaRoleUnlockView");

		// Token: 0x0401C96D RID: 117101
		public static readonly EUiViewName PhantomArenaBattleDamageView = new EUiViewName("PhantomArenaBattleDamageView");

		// Token: 0x0401C96E RID: 117102
		public static readonly EUiViewName PhantomArenaActivityOpen = new EUiViewName("PhantomArenaActivityOpen");

		// Token: 0x0401C96F RID: 117103
		public static readonly EUiViewName PhantomArenaHelpView = new EUiViewName("PhantomArenaHelpView");

		// Token: 0x0401C970 RID: 117104
		public static readonly EUiViewName PhantomArenaRewardView = new EUiViewName("PhantomArenaRewardView");

		// Token: 0x0401C971 RID: 117105
		public static readonly EUiViewName DangoMonopolyMainView = new EUiViewName("DangoMonopolyMainView");

		// Token: 0x0401C972 RID: 117106
		public static readonly EUiViewName DangoMonopolyTaskView = new EUiViewName("DangoMonopolyTaskView");

		// Token: 0x0401C973 RID: 117107
		public static readonly EUiViewName DangoMonopolyRoundShowView = new EUiViewName("DangoMonopolyRoundShowView");

		// Token: 0x0401C974 RID: 117108
		public static readonly EUiViewName DangoMonopolyResultView = new EUiViewName("DangoMonopolyResultView");

		// Token: 0x0401C975 RID: 117109
		public static readonly EUiViewName DangoMonopolyBuffActiveView = new EUiViewName("DangoMonopolyBuffActiveView");

		// Token: 0x0401C976 RID: 117110
		public static readonly EUiViewName DangoMonopolyRoundBuffShowView = new EUiViewName("DangoMonopolyRoundBuffShowView");

		// Token: 0x0401C977 RID: 117111
		public static readonly EUiViewName DangoMonopolyTipsView = new EUiViewName("DangoMonopolyTipsView");

		// Token: 0x0401C978 RID: 117112
		public static readonly EUiViewName DangoMonopolyRollDiceView = new EUiViewName("DangoMonopolyRollDiceView");

		// Token: 0x0401C979 RID: 117113
		public static readonly EUiViewName DangoMonopolyTransitionView = new EUiViewName("DangoMonopolyTransitionView");

		// Token: 0x0401C97A RID: 117114
		public static readonly EUiViewName MoraleBuffView = new EUiViewName("MoraleBuffView");

		// Token: 0x0401C97B RID: 117115
		public static readonly EUiViewName MoraleRewardView = new EUiViewName("MoraleRewardView");

		// Token: 0x0401C97C RID: 117116
		public static readonly EUiViewName MoraleAreaInfoView = new EUiViewName("MoraleAreaInfoView");

		// Token: 0x0401C97D RID: 117117
		public static readonly EUiViewName MoraleAreaSumView = new EUiViewName("MoraleAreaSumView");

		// Token: 0x0401C97E RID: 117118
		public static readonly EUiViewName MoraleBuffAddTips = new EUiViewName("MoraleBuffAddTips");

		// Token: 0x0401C97F RID: 117119
		public static readonly EUiViewName MoraleBuffActiveTips = new EUiViewName("MoraleBuffActiveTips");

		// Token: 0x0401C980 RID: 117120
		public static readonly EUiViewName MoraleAreaProgressTips = new EUiViewName("MoraleAreaProgressTips");

		// Token: 0x0401C981 RID: 117121
		public static readonly EUiViewName MoralePrompt = new EUiViewName("MoralePrompt");

		// Token: 0x0401C982 RID: 117122
		public static readonly EUiViewName MoraleAreaBuffActiveTips = new EUiViewName("MoraleAreaBuffActiveTips");

		// Token: 0x0401C983 RID: 117123
		public static readonly EUiViewName TrapDefenseMainView = new EUiViewName("TrapDefenseMainView");

		// Token: 0x0401C984 RID: 117124
		public static readonly EUiViewName TrapDefenseBdSumView = new EUiViewName("TrapDefenseBdSumView");

		// Token: 0x0401C985 RID: 117125
		public static readonly EUiViewName TrapDefenseBdQualityView = new EUiViewName("TrapDefenseBdQualityView");

		// Token: 0x0401C986 RID: 117126
		public static readonly EUiViewName TrapDefenseBdBuffSelectView = new EUiViewName("TrapDefenseBdBuffSelectView");

		// Token: 0x0401C987 RID: 117127
		public static readonly EUiViewName TrapDefenseBdBuffGetView = new EUiViewName("TrapDefenseBdBuffGetView");

		// Token: 0x0401C988 RID: 117128
		public static readonly EUiViewName TrapDefenseBdBuffStrengthenView = new EUiViewName("TrapDefenseBdBuffStrengthenView");

		// Token: 0x0401C989 RID: 117129
		public static readonly EUiViewName TrapDefenseRoundTips = new EUiViewName("TrapDefenseRoundTips");

		// Token: 0x0401C98A RID: 117130
		public static readonly EUiViewName TrapDefenseEventTerrainChangeTips = new EUiViewName("TrapDefenseEventTerrainChangeTips");

		// Token: 0x0401C98B RID: 117131
		public static readonly EUiViewName TrapDefenseEventShopOpenTips = new EUiViewName("TrapDefenseEventShopOpenTips");

		// Token: 0x0401C98C RID: 117132
		public static readonly EUiViewName TrapDefenseEventBossComingTips = new EUiViewName("TrapDefenseEventBossComingTips");

		// Token: 0x0401C98D RID: 117133
		public static readonly EUiViewName TrapDefenseRewardView = new EUiViewName("TrapDefenseRewardView");

		// Token: 0x0401C98E RID: 117134
		public static readonly EUiViewName TrapDefenseBuildingDevelopMainView = new EUiViewName("TrapDefenseBuildingDevelopMainView");

		// Token: 0x0401C98F RID: 117135
		public static readonly EUiViewName TrapDefenseBuildingDevelopPreviewView = new EUiViewName("TrapDefenseBuildingDevelopPreviewView");

		// Token: 0x0401C990 RID: 117136
		public static readonly EUiViewName TrapDefenseBuildingDevelopBranchSelectView = new EUiViewName("TrapDefenseBuildingDevelopBranchSelectView");

		// Token: 0x0401C991 RID: 117137
		public static readonly EUiViewName TrapDefensePauseView = new EUiViewName("TrapDefensePauseView");

		// Token: 0x0401C992 RID: 117138
		public static readonly EUiViewName TrapDefenseCountDownTips = new EUiViewName("TrapDefenseCountDownTips");

		// Token: 0x0401C993 RID: 117139
		public static readonly EUiViewName TrapDefenseResultView = new EUiViewName("TrapDefenseResultView");

		// Token: 0x0401C994 RID: 117140
		public static readonly EUiViewName TrapDefenseBuildingMachineInfoView = new EUiViewName("TrapDefenseBuildingMachineInfoView");

		// Token: 0x0401C995 RID: 117141
		public static readonly EUiViewName TrapDefenseBuildingGangsInfoView = new EUiViewName("TrapDefenseBuildingGangsInfoView");

		// Token: 0x0401C996 RID: 117142
		public static readonly EUiViewName TrapDefenseMonsterView = new EUiViewName("TrapDefenseMonsterView");

		// Token: 0x0401C997 RID: 117143
		public static readonly EUiViewName TrapDefenseTalentTreeView = new EUiViewName("TrapDefenseTalentTreeView");

		// Token: 0x0401C998 RID: 117144
		public static readonly EUiViewName TrapDefenseFixedRewardView = new EUiViewName("TrapDefenseFixedRewardView");

		// Token: 0x0401C999 RID: 117145
		public static readonly EUiViewName TrapDefenseMainLevelView = new EUiViewName("TrapDefenseMainLevelView");

		// Token: 0x0401C99A RID: 117146
		public static readonly EUiViewName TrapDefenseRougeLevelView = new EUiViewName("TrapDefenseRougeLevelView");

		// Token: 0x0401C99B RID: 117147
		public static readonly EUiViewName TrapDefenseMapView = new EUiViewName("TrapDefenseMapView");

		// Token: 0x0401C99C RID: 117148
		public static readonly EUiViewName TrapDefenseShopView = new EUiViewName("TrapDefenseShopView");

		// Token: 0x0401C99D RID: 117149
		public static readonly EUiViewName TrapDefenseTransitionView = new EUiViewName("TrapDefenseTransitionView");

		// Token: 0x0401C99E RID: 117150
		public static readonly EUiViewName TrapDefenseActivityUnlockView = new EUiViewName("TrapDefenseActivityUnlockView");

		// Token: 0x0401C99F RID: 117151
		public static readonly EUiViewName TermExplanationCenterView = new EUiViewName("TermExplanationCenterView");

		// Token: 0x0401C9A0 RID: 117152
		public static readonly EUiViewName TermExplanationSideView = new EUiViewName("TermExplanationSideView");

		// Token: 0x0401C9A1 RID: 117153
		public static readonly EUiViewName FloroRanchTermExplanationCenterView = new EUiViewName("FloroRanchTermExplanationCenterView");

		// Token: 0x0401C9A2 RID: 117154
		public static readonly EUiViewName FloroRanchTermExplanationSideView = new EUiViewName("FloroRanchTermExplanationSideView");

		// Token: 0x0401C9A3 RID: 117155
		public static readonly EUiViewName BirthdayRoleSelectView = new EUiViewName("BirthdayRoleSelectView");

		// Token: 0x0401C9A4 RID: 117156
		public static readonly EUiViewName BirthdaySelectConfirmView = new EUiViewName("BirthdaySelectConfirmView");

		// Token: 0x0401C9A5 RID: 117157
		public static readonly EUiViewName BirthdayLetterView = new EUiViewName("BirthdayLetterView");

		// Token: 0x0401C9A6 RID: 117158
		public static readonly EUiViewName CumulativeShopTaskView = new EUiViewName("CumulativeShopTaskView");

		// Token: 0x0401C9A7 RID: 117159
		public static readonly EUiViewName RogueBattleFallbackView = new EUiViewName("RogueBattleFallbackView");

		// Token: 0x0401C9A8 RID: 117160
		public static readonly EUiViewName RailSlideView = new EUiViewName("RailSlideView");

		// Token: 0x0401C9A9 RID: 117161
		public static readonly EUiViewName MotorcycleRailMoveView = new EUiViewName("MotorcycleRailMoveView");

		// Token: 0x0401C9AA RID: 117162
		public static readonly EUiViewName ResDownLoadView = new EUiViewName("ResDownLoadView");

		// Token: 0x0401C9AB RID: 117163
		public static readonly EUiViewName ResDownLoadMeOutOfMemoryView = new EUiViewName("ResDownLoadMeOutOfMemoryView");

		// Token: 0x0401C9AC RID: 117164
		public static readonly EUiViewName ResDownLoadLoadingView = new EUiViewName("ResDownLoadLoadingView");

		// Token: 0x0401C9AD RID: 117165
		public static readonly EUiViewName MoraleIndomitableLevelView = new EUiViewName("MoraleIndomitableLevelView");

		// Token: 0x0401C9AE RID: 117166
		public static readonly EUiViewName MoraleOccupiedSuccessView = new EUiViewName("MoraleOccupiedSuccessView");

		// Token: 0x0401C9AF RID: 117167
		public static readonly EUiViewName MoraleLevelDecreaseView = new EUiViewName("MoraleLevelDecreaseView");

		// Token: 0x0401C9B0 RID: 117168
		public static readonly EUiViewName ShowerInviteView = new EUiViewName("ShowerInviteView");

		// Token: 0x0401C9B1 RID: 117169
		public static readonly EUiViewName ShowerMainView = new EUiViewName("ShowerMainView");

		// Token: 0x0401C9B2 RID: 117170
		public static readonly EUiViewName QuestReviewMainView = new EUiViewName("QuestReviewMainView");

		// Token: 0x0401C9B3 RID: 117171
		public static readonly EUiViewName QuestReviewDetailView = new EUiViewName("QuestReviewDetailView");

		// Token: 0x0401C9B4 RID: 117172
		public static readonly EUiViewName QuestReviewTipsView = new EUiViewName("QuestReviewTipsView");

		// Token: 0x0401C9B5 RID: 117173
		public static readonly EUiViewName FilterSettingView = new EUiViewName("FilterSettingView");

		// Token: 0x0401C9B6 RID: 117174
		public static readonly EUiViewName BeginnerCarnivalMainView = new EUiViewName("BeginnerCarnivalMainView");

		// Token: 0x0401C9B7 RID: 117175
		public static readonly EUiViewName BeginnerCarnivalRoleTaskView = new EUiViewName("BeginnerCarnivalRoleTaskView");

		// Token: 0x0401C9B8 RID: 117176
		public static readonly EUiViewName BeginnerCarnivalChoseRoleView = new EUiViewName("BeginnerCarnivalChoseRoleView");

		// Token: 0x0401C9B9 RID: 117177
		public static readonly EUiViewName BeginnerCarnivalTaskView = new EUiViewName("BeginnerCarnivalTaskView");

		// Token: 0x0401C9BA RID: 117178
		public static readonly EUiViewName BeginnerCarnivalUnlockTipView = new EUiViewName("BeginnerCarnivalUnlockTipView");

		// Token: 0x0401C9BB RID: 117179
		public static readonly EUiViewName ActivityUnlockTipSevenHillsView = new EUiViewName("ActivityUnlockTipSevenHillsView");

		// Token: 0x0401C9BC RID: 117180
		public static readonly EUiViewName SevenHillsMainView = new EUiViewName("SevenHillsMainView");

		// Token: 0x0401C9BD RID: 117181
		public static readonly EUiViewName SevenHillsStageTaskView = new EUiViewName("SevenHillsStageTaskView");

		// Token: 0x0401C9BE RID: 117182
		public static readonly EUiViewName FloroRanchActivityView = new EUiViewName("FloroRanchActivityView");

		// Token: 0x0401C9BF RID: 117183
		public static readonly EUiViewName FloroRanchMainView = new EUiViewName("FloroRanchMainView");

		// Token: 0x0401C9C0 RID: 117184
		public static readonly EUiViewName FloroRanchCardSelectView = new EUiViewName("FloroRanchCardSelectView");

		// Token: 0x0401C9C1 RID: 117185
		public static readonly EUiViewName FloroRanchCardGroupSelectView = new EUiViewName("FloroRanchCardGroupSelectView");

		// Token: 0x0401C9C2 RID: 117186
		public static readonly EUiViewName FloroRanchPhaseTargetView = new EUiViewName("FloroRanchPhaseTargetView");

		// Token: 0x0401C9C3 RID: 117187
		public static readonly EUiViewName FloroRanchPhaseSettleView = new EUiViewName("FloroRanchPhaseSettleView");

		// Token: 0x0401C9C4 RID: 117188
		public static readonly EUiViewName FloroRanchCommonTipsView = new EUiViewName("FloroRanchCommonTipsView");

		// Token: 0x0401C9C5 RID: 117189
		public static readonly EUiViewName FloroRanchDailySettleView = new EUiViewName("FloroRanchDailySettleView");

		// Token: 0x0401C9C6 RID: 117190
		public static readonly EUiViewName FloroRanchDungeonSelectView = new EUiViewName("FloroRanchDungeonSelectView");

		// Token: 0x0401C9C7 RID: 117191
		public static readonly EUiViewName FloroRanchGamePlayExplainView = new EUiViewName("FloroRanchGamePlayExplainView");

		// Token: 0x0401C9C8 RID: 117192
		public static readonly EUiViewName FloroRanchGamePlayView = new EUiViewName("FloroRanchGamePlayView");

		// Token: 0x0401C9C9 RID: 117193
		public static readonly EUiViewName FloroRanchHandBookView = new EUiViewName("FloroRanchHandBookView");

		// Token: 0x0401C9CA RID: 117194
		public static readonly EUiViewName FloroRanchLimitRewardView = new EUiViewName("FloroRanchLimitRewardView");

		// Token: 0x0401C9CB RID: 117195
		public static readonly EUiViewName FloroRanchPermanentRewardView = new EUiViewName("FloroRanchPermanentRewardView");

		// Token: 0x0401C9CC RID: 117196
		public static readonly EUiViewName FloroRanchRaceSelectView = new EUiViewName("FloroRanchRaceSelectView");

		// Token: 0x0401C9CD RID: 117197
		public static readonly EUiViewName FloroRanchRandomEventView = new EUiViewName("FloroRanchRandomEventView");

		// Token: 0x0401C9CE RID: 117198
		public static readonly EUiViewName FloroRanchShopView = new EUiViewName("FloroRanchShopView");

		// Token: 0x0401C9CF RID: 117199
		public static readonly EUiViewName FloroRanchShopTipView = new EUiViewName("FloroRanchShopTipView");

		// Token: 0x0401C9D0 RID: 117200
		public static readonly EUiViewName FloroRanchSkillView = new EUiViewName("FloroRanchSkillView");

		// Token: 0x0401C9D1 RID: 117201
		public static readonly EUiViewName FloroRanchTechnologyView = new EUiViewName("FloroRanchTechnologyView");

		// Token: 0x0401C9D2 RID: 117202
		public static readonly EUiViewName FloroRanchIncomeDetailView = new EUiViewName("FloroRanchIncomeDetailView");

		// Token: 0x0401C9D3 RID: 117203
		public static readonly EUiViewName FloroRanchDungeonFailSettleView = new EUiViewName("FloroRanchDungeonFailSettleView");

		// Token: 0x0401C9D4 RID: 117204
		public static readonly EUiViewName FloroRanchDungeonEndlessSettleView = new EUiViewName("FloroRanchDungeonEndlessSettleView");

		// Token: 0x0401C9D5 RID: 117205
		public static readonly EUiViewName FloroRanchDungeonSuccessSettleView = new EUiViewName("FloroRanchDungeonSuccessSettleView");

		// Token: 0x0401C9D6 RID: 117206
		public static readonly EUiViewName FloroRanchConfirmBoxView = new EUiViewName("FloroRanchConfirmBoxView");

		// Token: 0x0401C9D7 RID: 117207
		public static readonly EUiViewName FloroRanchPauseView = new EUiViewName("FloroRanchPauseView");

		// Token: 0x0401C9D8 RID: 117208
		public static readonly EUiViewName FloroRanchSkillTipView = new EUiViewName("FloroRanchSkillTipView");

		// Token: 0x0401C9D9 RID: 117209
		public static readonly EUiViewName FloroRanchHelpView = new EUiViewName("FloroRanchHelpView");

		// Token: 0x0401C9DA RID: 117210
		public static readonly EUiViewName FloroRanchComicView = new EUiViewName("FloroRanchComicView");

		// Token: 0x0401C9DB RID: 117211
		public static readonly EUiViewName FloroRanchComicView2 = new EUiViewName("FloroRanchComicView2");

		// Token: 0x0401C9DC RID: 117212
		public static readonly EUiViewName FloroRanchComicView3 = new EUiViewName("FloroRanchComicView3");

		// Token: 0x0401C9DD RID: 117213
		public static readonly EUiViewName FloroRanchComicView4 = new EUiViewName("FloroRanchComicView4");

		// Token: 0x0401C9DE RID: 117214
		public static readonly EUiViewName FloroRanchUnlockTipView = new EUiViewName("FloroRanchUnlockTipView");

		// Token: 0x0401C9DF RID: 117215
		public static readonly EUiViewName FloroRanchWeeklyMainView = new EUiViewName("FloroRanchWeeklyMainView");

		// Token: 0x0401C9E0 RID: 117216
		public static readonly EUiViewName FloroRanchRecommendTipView = new EUiViewName("FloroRanchRecommendTipView");

		// Token: 0x0401C9E1 RID: 117217
		public static readonly EUiViewName KingShipMainView = new EUiViewName("KingShipMainView");

		// Token: 0x0401C9E2 RID: 117218
		public static readonly EUiViewName KingShipLoadingView = new EUiViewName("KingShipLoadingView");

		// Token: 0x0401C9E3 RID: 117219
		public static readonly EUiViewName KingShipResultView = new EUiViewName("KingShipResultView");

		// Token: 0x0401C9E4 RID: 117220
		public static readonly EUiViewName KingShipPlotView = new EUiViewName("KingShipPlotView");

		// Token: 0x0401C9E5 RID: 117221
		public static readonly EUiViewName KingShipFailView = new EUiViewName("KingShipFailView");

		// Token: 0x0401C9E6 RID: 117222
		public static readonly EUiViewName LifePointDrawDetailView = new EUiViewName("LifePointDrawDetailView");

		// Token: 0x0401C9E7 RID: 117223
		public static readonly EUiViewName LifePointDrawEntranceView = new EUiViewName("LifePointDrawEntranceView");

		// Token: 0x0401C9E8 RID: 117224
		public static readonly EUiViewName NightmareLordFloatTips = new EUiViewName("NightmareLordFloatTips");

		// Token: 0x0401C9E9 RID: 117225
		public static readonly EUiViewName NightmareSpawnPointFloatTips = new EUiViewName("NightmareSpawnPointFloatTips");

		// Token: 0x0401C9EA RID: 117226
		public static readonly EUiViewName HonamiStoryMainLoadingView = new EUiViewName("HonamiStoryMainLoadingView");

		// Token: 0x0401C9EB RID: 117227
		public static readonly EUiViewName HonamiStorySmallLoadingView = new EUiViewName("HonamiStorySmallLoadingView");

		// Token: 0x0401C9EC RID: 117228
		public static readonly EUiViewName HonamiStoryInventoryView = new EUiViewName("HonamiStoryInventoryView");

		// Token: 0x0401C9ED RID: 117229
		public static readonly EUiViewName HonamiStoryBackpackView = new EUiViewName("HonamiStoryBackpackView");

		// Token: 0x0401C9EE RID: 117230
		public static readonly EUiViewName HonamiStoryPickUpBackpackView = new EUiViewName("HonamiStoryPickUpBackpackView");

		// Token: 0x0401C9EF RID: 117231
		public static readonly EUiViewName HonamiStoryPickUpMobileView = new EUiViewName("HonamiStoryPickUpMobileView");

		// Token: 0x0401C9F0 RID: 117232
		public static readonly EUiViewName HonamiStorySettleSuccessView = new EUiViewName("HonamiStorySettleSuccessView");

		// Token: 0x0401C9F1 RID: 117233
		public static readonly EUiViewName HonamiStorySettleFailView = new EUiViewName("HonamiStorySettleFailView");

		// Token: 0x0401C9F2 RID: 117234
		public static readonly EUiViewName HonamiStorySellConfirmBoxView = new EUiViewName("HonamiStorySellConfirmBoxView");

		// Token: 0x0401C9F3 RID: 117235
		public static readonly EUiViewName HonamiStoryMascotCollectBookView = new EUiViewName("HonamiStoryMascotCollectBookView");

		// Token: 0x0401C9F4 RID: 117236
		public static readonly EUiViewName HonamiStoryQuestView = new EUiViewName("HonamiStoryQuestView");

		// Token: 0x0401C9F5 RID: 117237
		public static readonly EUiViewName HonamiStoryQuestFinishView = new EUiViewName("HonamiStoryQuestFinishView");

		// Token: 0x0401C9F6 RID: 117238
		public static readonly EUiViewName HonamiStoryShopView = new EUiViewName("HonamiStoryShopView");

		// Token: 0x0401C9F7 RID: 117239
		public static readonly EUiViewName HonamiStoryPermanentTaskView = new EUiViewName("HonamiStoryPermanentTaskView");

		// Token: 0x0401C9F8 RID: 117240
		public static readonly EUiViewName HonamiStoryLimitTaskView = new EUiViewName("HonamiStoryLimitTaskView");

		// Token: 0x0401C9F9 RID: 117241
		public static readonly EUiViewName HonamiStoryScoreRewardView = new EUiViewName("HonamiStoryScoreRewardView");

		// Token: 0x0401C9FA RID: 117242
		public static readonly EUiViewName HonamiStoryTechnologyView = new EUiViewName("HonamiStoryTechnologyView");

		// Token: 0x0401C9FB RID: 117243
		public static readonly EUiViewName HonamiStoryLevelInfoView = new EUiViewName("HonamiStoryLevelInfoView");

		// Token: 0x0401C9FC RID: 117244
		public static readonly EUiViewName HonamiStoryItemCollectView = new EUiViewName("HonamiStoryItemCollectView");

		// Token: 0x0401C9FD RID: 117245
		public static readonly EUiViewName HonamiStoryMainView = new EUiViewName("HonamiStoryMainView");

		// Token: 0x0401C9FE RID: 117246
		public static readonly EUiViewName HonamiStoryWeaponSelectView = new EUiViewName("HonamiStoryWeaponSelectView");

		// Token: 0x0401C9FF RID: 117247
		public static readonly EUiViewName HonamiStoryTechSuccessEffectView = new EUiViewName("HonamiStoryTechSuccessEffectView");

		// Token: 0x0401CA00 RID: 117248
		public static readonly EUiViewName HonamiStoryLeaveTip = new EUiViewName("HonamiStoryLeaveTip");

		// Token: 0x0401CA01 RID: 117249
		public static readonly EUiViewName HonamiStoryPollutionLevelUpdateView = new EUiViewName("HonamiStoryPollutionLevelUpdateView");

		// Token: 0x0401CA02 RID: 117250
		public static readonly EUiViewName HonamiStorySafeLeaveUpdateView = new EUiViewName("HonamiStorySafeLeaveUpdateView");

		// Token: 0x0401CA03 RID: 117251
		public static readonly EUiViewName HonamiStoryUnlockTipView = new EUiViewName("HonamiStoryUnlockTipView");

		// Token: 0x0401CA04 RID: 117252
		public static readonly EUiViewName HonamiStoryNewTipsView = new EUiViewName("HonamiStoryNewTipsView");

		// Token: 0x0401CA05 RID: 117253
		public static readonly EUiViewName HonamiWeaponRewardView = new EUiViewName("HonamiWeaponRewardView");

		// Token: 0x0401CA06 RID: 117254
		public static readonly EUiViewName HonamiStoryLoadingView = new EUiViewName("HonamiStoryLoadingView");

		// Token: 0x0401CA07 RID: 117255
		public static readonly EUiViewName CommonGameMainView = new EUiViewName("CommonGameMainView");

		// Token: 0x0401CA08 RID: 117256
		public static readonly EUiViewName CommonTouchUiEditView = new EUiViewName("CommonTouchUiEditView");

		// Token: 0x0401CA09 RID: 117257
		public static readonly EUiViewName AstrologyItemInspectView = new EUiViewName("AstrologyItemInspectView");

		// Token: 0x0401CA0A RID: 117258
		public static readonly EUiViewName SeekTraceView = new EUiViewName("SeekTraceView");

		// Token: 0x0401CA0B RID: 117259
		public static readonly EUiViewName SeekTraceStartView = new EUiViewName("SeekTraceStartView");

		// Token: 0x0401CA0C RID: 117260
		public static readonly EUiViewName GreatSwordLevelSelectView = new EUiViewName("GreatSwordLevelSelectView");

		// Token: 0x0401CA0D RID: 117261
		public static readonly EUiViewName GreatSwordCountDownView = new EUiViewName("GreatSwordCountDownView");

		// Token: 0x0401CA0E RID: 117262
		public static readonly EUiViewName GreatSwordOpenTipsView = new EUiViewName("GreatSwordOpenTipsView");

		// Token: 0x0401CA0F RID: 117263
		public static readonly EUiViewName AnchorGameplayView = new EUiViewName("AnchorGameplayView");

		// Token: 0x0401CA10 RID: 117264
		public static readonly EUiViewName Theme26UnlockTipView = new EUiViewName("Theme26UnlockTipView");

		// Token: 0x0401CA11 RID: 117265
		public static readonly EUiViewName Theme26MainView = new EUiViewName("Theme26MainView");

		// Token: 0x0401CA12 RID: 117266
		public static readonly EUiViewName Theme26StageTaskView = new EUiViewName("Theme26StageTaskView");

		// Token: 0x0401CA13 RID: 117267
		public static readonly EUiViewName ActivityFunPlayView = new EUiViewName("ActivityFunPlayView");

		// Token: 0x0401CA14 RID: 117268
		public static readonly EUiViewName LineCrossEntranceView = new EUiViewName("LineCrossEntranceView");

		// Token: 0x0401CA15 RID: 117269
		public static readonly EUiViewName LineCrossDetailView = new EUiViewName("LineCrossDetailView");

		// Token: 0x0401CA16 RID: 117270
		public static readonly EUiViewName MoonSignInMainView = new EUiViewName("MoonSignInMainView");

		// Token: 0x0401CA17 RID: 117271
		public static readonly EUiViewName MoonSignInDetailView = new EUiViewName("MoonSignInDetailView");

		// Token: 0x0401CA18 RID: 117272
		public static readonly EUiViewName MoonSignInRewardView = new EUiViewName("MoonSignInRewardView");

		// Token: 0x0401CA19 RID: 117273
		public static readonly EUiViewName SurvivorsTalentTreeView = new EUiViewName("SurvivorsTalentTreeView");

		// Token: 0x0401CA1A RID: 117274
		public static readonly EUiViewName SurvivorsTalentUnlockView = new EUiViewName("SurvivorsTalentUnlockView");

		// Token: 0x0401CA1B RID: 117275
		public static readonly EUiViewName SurvivorsTeamEditView = new EUiViewName("SurvivorsTeamEditView");

		// Token: 0x0401CA1C RID: 117276
		public static readonly EUiViewName SurvivorsHandbookView = new EUiViewName("SurvivorsHandbookView");

		// Token: 0x0401CA1D RID: 117277
		public static readonly EUiViewName SurvivorsRogueEvolveView = new EUiViewName("SurvivorsRogueEvolveView");

		// Token: 0x0401CA1E RID: 117278
		public static readonly EUiViewName SurvivorsRogueGeneralObtainView = new EUiViewName("SurvivorsRogueGeneralObtainView");

		// Token: 0x0401CA1F RID: 117279
		public static readonly EUiViewName SurvivorsRogueShopView = new EUiViewName("SurvivorsRogueShopView");

		// Token: 0x0401CA20 RID: 117280
		public static readonly EUiViewName SurvivorsRogueSettleView = new EUiViewName("SurvivorsRogueSettleView");

		// Token: 0x0401CA21 RID: 117281
		public static readonly EUiViewName SurvivorsRogueSettleExternalView = new EUiViewName("SurvivorsRogueSettleExternalView");

		// Token: 0x0401CA22 RID: 117282
		public static readonly EUiViewName SurvivorsRogueExitView = new EUiViewName("SurvivorsRogueExitView");

		// Token: 0x0401CA23 RID: 117283
		public static readonly EUiViewName SurvivorsRogueRewardView = new EUiViewName("SurvivorsRogueRewardView");

		// Token: 0x0401CA24 RID: 117284
		public static readonly EUiViewName SurvivorsRogueMainView = new EUiViewName("SurvivorsRogueMainView");

		// Token: 0x0401CA25 RID: 117285
		public static readonly EUiViewName SurvivorsRogueActivityUnlockView = new EUiViewName("SurvivorsRogueActivityUnlockView");

		// Token: 0x0401CA26 RID: 117286
		public static readonly EUiViewName SurvivorsLevelDetailView = new EUiViewName("SurvivorsLevelDetailView");

		// Token: 0x0401CA27 RID: 117287
		public static readonly EUiViewName SurvivorsTabMainView = new EUiViewName("SurvivorsTabMainView");

		// Token: 0x0401CA28 RID: 117288
		public static readonly EUiViewName SurvivorsCardTips = new EUiViewName("SurvivorsCardTips");

		// Token: 0x0401CA29 RID: 117289
		public static readonly EUiViewName SurvivorsWeaponUnlockView = new EUiViewName("SurvivorsWeaponUnlockView");

		// Token: 0x0401CA2A RID: 117290
		public static readonly EUiViewName SurvivorsAttributeDetailView = new EUiViewName("SurvivorsAttributeDetailView");

		// Token: 0x0401CA2B RID: 117291
		public static readonly EUiViewName SurvivorsWeaponAttributeView = new EUiViewName("SurvivorsWeaponAttributeView");

		// Token: 0x0401CA2C RID: 117292
		public static readonly EUiViewName RoleDevRootView = new EUiViewName("RoleDevRootView");

		// Token: 0x0401CA2D RID: 117293
		public static readonly EUiViewName RoleSkillMergeView = new EUiViewName("RoleSkillMergeView");

		// Token: 0x0401CA2E RID: 117294
		public static readonly EUiViewName RoleDevelopRootView = new EUiViewName("RoleDevelopRootView");

		// Token: 0x0401CA2F RID: 117295
		public static readonly EUiViewName RoleDevelopSelectTargetView = new EUiViewName("RoleDevelopSelectTargetView");

		// Token: 0x0401CA30 RID: 117296
		public static readonly EUiViewName ItemHintViewNew = new EUiViewName("ItemHintViewNew");

		// Token: 0x0401CA31 RID: 117297
		public static readonly EUiViewName QuestTreeMainView = new EUiViewName("QuestTreeMainView");

		// Token: 0x0401CA32 RID: 117298
		public static readonly EUiViewName QuestTreeChapterView = new EUiViewName("QuestTreeChapterView");

		// Token: 0x0401CA33 RID: 117299
		public static readonly EUiViewName QuestTreeNodeDetailView = new EUiViewName("QuestTreeNodeDetailView");

		// Token: 0x0401CA34 RID: 117300
		public static readonly EUiViewName QuestTreeNodeImageView = new EUiViewName("QuestTreeNodeImageView");

		// Token: 0x0401CA35 RID: 117301
		public static readonly EUiViewName QuestTreeAvailableListView = new EUiViewName("QuestTreeAvailableListView");

		// Token: 0x0401CA36 RID: 117302
		public static readonly EUiViewName PersonalPlayerTitleUnLockTipsView = new EUiViewName("PersonalPlayerTitleUnLockTipsView");

		// Token: 0x0401CA37 RID: 117303
		public static readonly EUiViewName VisionSettlementFloatTips = new EUiViewName("VisionSettlementFloatTips");

		// Token: 0x0401CA38 RID: 117304
		public static readonly EUiViewName EyeProtectView = new EUiViewName("EyeProtectView");

		// Token: 0x0401CA39 RID: 117305
		public static readonly EUiViewName CsViewProxy = new EUiViewName("CsViewProxy");

		// Token: 0x0401CA3A RID: 117306
		public static readonly EUiViewName InfrastructureMainView = new EUiViewName("InfrastructureMainView");

		// Token: 0x0401CA3B RID: 117307
		public static readonly EUiViewName InfrArchiveMainView = new EUiViewName("InfrArchiveMainView");

		// Token: 0x0401CA3C RID: 117308
		public static readonly EUiViewName InfrastructureSettleView = new EUiViewName("InfrastructureSettleView");

		// Token: 0x0401CA3D RID: 117309
		public static readonly EUiViewName InfrLimitTaskMainView = new EUiViewName("InfrLimitTaskMainView");

		// Token: 0x0401CA3E RID: 117310
		public static readonly EUiViewName InfrastructureShopMainView = new EUiViewName("InfrastructureShopMainView");

		// Token: 0x0401CA3F RID: 117311
		public static readonly EUiViewName InfrRoadNetworkMainView = new EUiViewName("InfrRoadNetworkMainView");

		// Token: 0x0401CA40 RID: 117312
		public static readonly EUiViewName InfrMaterialsDeliveryView = new EUiViewName("InfrMaterialsDeliveryView");

		// Token: 0x0401CA41 RID: 117313
		public static readonly EUiViewName InfrRoadNetworkInfoView = new EUiViewName("InfrRoadNetworkInfoView");

		// Token: 0x0401CA42 RID: 117314
		public static readonly EUiViewName InfrOpeningTipsView = new EUiViewName("InfrOpeningTipsView");

		// Token: 0x0401CA43 RID: 117315
		public static readonly EUiViewName RegionalTerminalOverviewView = new EUiViewName("RegionalTerminalOverviewView");

		// Token: 0x0401CA44 RID: 117316
		public static readonly EUiViewName VillageInfrMainView = new EUiViewName("VillageInfrMainView");

		// Token: 0x0401CA45 RID: 117317
		public static readonly EUiViewName VillageInfrTaskMainView = new EUiViewName("VillageInfrTaskMainView");

		// Token: 0x0401CA46 RID: 117318
		public static readonly EUiViewName VillageInfrBuildFinishTipView = new EUiViewName("VillageInfrBuildFinishTipView");

		// Token: 0x0401CA47 RID: 117319
		public static readonly EUiViewName VillageInfrWorldBuildView = new EUiViewName("VillageInfrWorldBuildView");

		// Token: 0x0401CA48 RID: 117320
		public static readonly EUiViewName VillageInfrBuildInfoView = new EUiViewName("VillageInfrBuildInfoView");

		// Token: 0x0401CA49 RID: 117321
		public static readonly EUiViewName VillageInfrNewTipsView = new EUiViewName("VillageInfrNewTipsView");

		// Token: 0x0401CA4A RID: 117322
		public static readonly EUiViewName PrizeDrawingMainView = new EUiViewName("PrizeDrawingMainView");

		// Token: 0x0401CA4B RID: 117323
		public static readonly EUiViewName PrizeDrawingTearView = new EUiViewName("PrizeDrawingTearView");

		// Token: 0x0401CA4C RID: 117324
		public static readonly EUiViewName PilotThrowView = new EUiViewName("PilotThrowView");

		// Token: 0x0401CA4D RID: 117325
		public static readonly EUiViewName DeadEyeModeView = new EUiViewName("DeadEyeJumpRampView");

		// Token: 0x0401CA4E RID: 117326
		public static readonly EUiViewName DeadEyeFloaterShooterView = new EUiViewName("DeadEyeFloaterShooterView");

		// Token: 0x0401CA4F RID: 117327
		public static readonly EUiViewName SynthesisTipsInfoView = new EUiViewName("SynthesisTipsInfoView");

		// Token: 0x0401CA50 RID: 117328
		public static readonly EUiViewName ActivityPreWarmMainView = new EUiViewName("ActivityPreWarmMainView");

		// Token: 0x0401CA51 RID: 117329
		public static readonly EUiViewName AdvanceNoticeRootView = new EUiViewName("AdvanceNoticeRootView");

		// Token: 0x0401CA52 RID: 117330
		public static readonly EUiViewName SubPackageDownLoadView = new EUiViewName("SubPackageDownLoadView");

		// Token: 0x0401CA53 RID: 117331
		public static readonly EUiViewName SubPackageDownLoadFreeSpaceTipsView = new EUiViewName("SubPackageDownLoadFreeSpaceTipsView");

		// Token: 0x0401CA54 RID: 117332
		public static readonly EUiViewName SubPackageDownLoadClearTipsView = new EUiViewName("SubPackageDownLoadClearTipsView");

		// Token: 0x0401CA55 RID: 117333
		public static readonly EUiViewName SubPackageDownLoadMobileClearPopView = new EUiViewName("SubPackageDownLoadMobileClearPopView");

		// Token: 0x0401CA56 RID: 117334
		public static readonly EUiViewName ArtemisActivityRoleChatView = new EUiViewName("ArtemisActivityRoleChatView");

		// Token: 0x0401CA57 RID: 117335
		public static readonly EUiViewName ArtemisActivityCertificationView = new EUiViewName("ArtemisActivityCertificationView");

		// Token: 0x0401CA58 RID: 117336
		public static readonly EUiViewName ArtemisQteView = new EUiViewName("ArtemisQteView");

		// Token: 0x0401CA59 RID: 117337
		public static readonly EUiViewName WeatherCentralMainView = new EUiViewName("WeatherCentralMainView");

		// Token: 0x0401CA5A RID: 117338
		public static readonly EUiViewName WeatherUnlockTips = new EUiViewName("WeatherUnlockTips");

		// Token: 0x0401CA5B RID: 117339
		public static readonly EUiViewName MotorcycleRootView = new EUiViewName("MotorcycleRootView");

		// Token: 0x0401CA5C RID: 117340
		public static readonly EUiViewName MotorcycleRewardPreviewView = new EUiViewName("MotorcycleRewardPreviewView");

		// Token: 0x0401CA5D RID: 117341
		public static readonly EUiViewName MotorcycleTechTreeDetailView = new EUiViewName("MotorcycleTechTreeDetailView");

		// Token: 0x0401CA5E RID: 117342
		public static readonly EUiViewName MotorcycleTechTreeLevelDetailView = new EUiViewName("MotorcycleTechTreeLevelDetailView");

		// Token: 0x0401CA5F RID: 117343
		public static readonly EUiViewName MotorcycleTechTreeLevelUpEffectView = new EUiViewName("MotorcycleTechTreeLevelUpEffectView");

		// Token: 0x0401CA60 RID: 117344
		public static readonly EUiViewName MotorcycleLevelAttrDetailView = new EUiViewName("MotorcycleLevelAttrDetailView");

		// Token: 0x0401CA61 RID: 117345
		public static readonly EUiViewName MotorcycleConditionView = new EUiViewName("MotorcycleConditionView");

		// Token: 0x0401CA62 RID: 117346
		public static readonly EUiViewName MotorcycleLevelUpView = new EUiViewName("MotorcycleLevelUpView");

		// Token: 0x0401CA63 RID: 117347
		public static readonly EUiViewName MotorcycleTechTreeSwitchView = new EUiViewName("MotorcycleTechTreeSwitchView");

		// Token: 0x0401CA64 RID: 117348
		public static readonly EUiViewName MotorcycleDiyRootView = new EUiViewName("MotorcycleDiyRootView");

		// Token: 0x0401CA65 RID: 117349
		public static readonly EUiViewName MotorcycleDiyEditRootView = new EUiViewName("MotorcycleDiyEditRootView");

		// Token: 0x0401CA66 RID: 117350
		public static readonly EUiViewName MotorcycleDiyImportPresetView = new EUiViewName("MotorcycleDiyImportPresetView");

		// Token: 0x0401CA67 RID: 117351
		public static readonly EUiViewName MotorcycleDiyOverviewView = new EUiViewName("MotorcycleDiyOverviewView");

		// Token: 0x0401CA68 RID: 117352
		public static readonly EUiViewName MotorcycleDiyEditOverviewView = new EUiViewName("MotorcycleDiyEditOverviewView");

		// Token: 0x0401CA69 RID: 117353
		public static readonly EUiViewName MotorcycleDiyStickerPreviewView = new EUiViewName("MotorcycleDiyStickerPreviewView");

		// Token: 0x0401CA6A RID: 117354
		public static readonly EUiViewName MotorcycleDiyDecorationPreviewView = new EUiViewName("MotorcycleDiyDecorationPreviewView");

		// Token: 0x0401CA6B RID: 117355
		public static readonly EUiViewName MotorcycleDiyNameInputView = new EUiViewName("MotorcycleDiyNameInputView");

		// Token: 0x0401CA6C RID: 117356
		public static readonly EUiViewName MotorcycleDiySkinView = new EUiViewName("MotorcycleDiySkinView");

		// Token: 0x0401CA6D RID: 117357
		public static readonly EUiViewName MotorcycleScenePopupView = new EUiViewName("MotorcycleScenePopupView");

		// Token: 0x0401CA6E RID: 117358
		public static readonly EUiViewName MotorLinkageRewardView = new EUiViewName("MotoLinkageRewardView");

		// Token: 0x0401CA6F RID: 117359
		public static readonly EUiViewName MotorcycleTogetherView = new EUiViewName("MotorcycleTogetherView");

		// Token: 0x0401CA70 RID: 117360
		public static readonly EUiViewName MotorcycleCountDownView = new EUiViewName("MotorcycleCountDownView");

		// Token: 0x0401CA71 RID: 117361
		public static readonly EUiViewName MotorcycleMusicPlayerView = new EUiViewName("MotorcycleMusicPlayerView");

		// Token: 0x0401CA72 RID: 117362
		public static readonly EUiViewName MotorcycleMusicDetailView = new EUiViewName("MotorcycleMusicDetailView");

		// Token: 0x0401CA73 RID: 117363
		public static readonly EUiViewName MotorcycleMusicSortView = new EUiViewName("MotorcycleMusicSortView");

		// Token: 0x0401CA74 RID: 117364
		public static readonly EUiViewName MotorMusicNewMusicTips = new EUiViewName("MotorMusicNewMusicTips");

		// Token: 0x0401CA75 RID: 117365
		public static readonly EUiViewName PhoneMsgTipViewA = new EUiViewName("PhoneMsgTipViewA");

		// Token: 0x0401CA76 RID: 117366
		public static readonly EUiViewName PhoneMsgTipViewB = new EUiViewName("PhoneMsgTipViewB");

		// Token: 0x0401CA77 RID: 117367
		public static readonly EUiViewName PhoneMsgTipViewC = new EUiViewName("PhoneMsgTipViewC");

		// Token: 0x0401CA78 RID: 117368
		public static readonly EUiViewName PhoneMsgPanelViewBig = new EUiViewName("PhoneMsgPanelViewBig");

		// Token: 0x0401CA79 RID: 117369
		public static readonly EUiViewName PhoneMsgPanelViewSmall = new EUiViewName("PhoneMsgPanelViewSmall");

		// Token: 0x0401CA7A RID: 117370
		public static readonly EUiViewName PhoneMsgSettingView = new EUiViewName("PhoneMsgSettingView");

		// Token: 0x0401CA7B RID: 117371
		public static readonly EUiViewName PhoneMsgLoadingView = new EUiViewName("PhoneMsgLoadingView");

		// Token: 0x0401CA7C RID: 117372
		public static readonly EUiViewName PhoneViewFilterPanel = new EUiViewName("PhoneViewFilterPanel");

		// Token: 0x0401CA7D RID: 117373
		public static readonly EUiViewName ActivityTagInfoHelpView = new EUiViewName("ActivityTagInfoHelpView");

		// Token: 0x0401CA7E RID: 117374
		public static readonly EUiViewName PanoramicPointUnlockTipsView = new EUiViewName("PanoramicPointUnlockTipsView");

		// Token: 0x0401CA7F RID: 117375
		public static readonly EUiViewName LaHaiLuoCollectView = new EUiViewName("LaHaiLuoCollectView");

		// Token: 0x0401CA80 RID: 117376
		public static readonly EUiViewName RiLingCollectView = new EUiViewName("LaHaiLuoCollectView");

		// Token: 0x0401CA81 RID: 117377
		public static readonly EUiViewName CookSchoolMechanismRootView = new EUiViewName("CookSchoolMechanismRootView");

		// Token: 0x0401CA82 RID: 117378
		public static readonly EUiViewName RoadBookMainView = new EUiViewName("RoadBookMainView");

		// Token: 0x0401CA83 RID: 117379
		public static readonly EUiViewName RoadBookTravelTaskView = new EUiViewName("RoadBookTravelTaskView");

		// Token: 0x0401CA84 RID: 117380
		public static readonly EUiViewName RoadBookVehicleTaskView = new EUiViewName("RoadBookVehicleTaskView");

		// Token: 0x0401CA85 RID: 117381
		public static readonly EUiViewName RoadBookPhantomTaskView = new EUiViewName("RoadBookPhantomTaskView");

		// Token: 0x0401CA86 RID: 117382
		public static readonly EUiViewName RoadBookLevelTipsView = new EUiViewName("RoadBookLevelTipsView");

		// Token: 0x0401CA87 RID: 117383
		public static readonly EUiViewName ActivityUnlockTipRoadBookView = new EUiViewName("ActivityUnlockTipRoadBookView");

		// Token: 0x0401CA88 RID: 117384
		public static readonly EUiViewName DeviceInfoView = new EUiViewName("DeviceInfoView");

		// Token: 0x0401CA89 RID: 117385
		public static readonly EUiViewName FeedbackRewardMainView = new EUiViewName("FeedbackRewardMainView");

		// Token: 0x0401CA8A RID: 117386
		public static readonly EUiViewName FeedbackRewardStartView = new EUiViewName("FeedbackRewardStartView");

		// Token: 0x0401CA8B RID: 117387
		public static readonly EUiViewName TotalTopUpPreviewView = new EUiViewName("TotalTopUpPreviewView");

		// Token: 0x0401CA8C RID: 117388
		public static readonly EUiViewName TotalTopUpPickRoleRewardView = new EUiViewName("TotalTopUpPickRoleRewardView");

		// Token: 0x0401CA8D RID: 117389
		public static readonly EUiViewName KurotatoTabMainView = new EUiViewName("KurotatoTabMainView");

		// Token: 0x0401CA8E RID: 117390
		public static readonly EUiViewName KurotatoAttrSelectMainView = new EUiViewName("KurotatoAttrSelectMainView");

		// Token: 0x0401CA8F RID: 117391
		public static readonly EUiViewName KurotatoBoxDropMainView = new EUiViewName("KurotatoBoxDropMainView");

		// Token: 0x0401CA90 RID: 117392
		public static readonly EUiViewName KurotatoContentView = new EUiViewName("KurotatoContentView");

		// Token: 0x0401CA91 RID: 117393
		public static readonly EUiViewName KurotatoShopMainView = new EUiViewName("KurotatoShopMainView");

		// Token: 0x0401CA92 RID: 117394
		public static readonly EUiViewName KurotatoAttributeDetailView = new EUiViewName("KurotatoAttributeDetailView");

		// Token: 0x0401CA93 RID: 117395
		public static readonly EUiViewName KurotatoPopupDetailView = new EUiViewName("KurotatoPopupDetailView");

		// Token: 0x0401CA94 RID: 117396
		public static readonly EUiViewName KurotatoPopupItemDetailView = new EUiViewName("KurotatoPopupItemDetailView");

		// Token: 0x0401CA95 RID: 117397
		public static readonly EUiViewName KurotatoSettleView = new EUiViewName("KurotatoSettleView");

		// Token: 0x0401CA96 RID: 117398
		public static readonly EUiViewName KurotatoPauseView = new EUiViewName("KurotatoPauseView");

		// Token: 0x0401CA97 RID: 117399
		public static readonly EUiViewName KurotatoPopupWeaponDetailView = new EUiViewName("KurotatoPopupWeaponDetailView");

		// Token: 0x0401CA98 RID: 117400
		public static readonly EUiViewName KurotatoPopupUnlockRoleView = new EUiViewName("KurotatoPopupUnlockRoleView");

		// Token: 0x0401CA99 RID: 117401
		public static readonly EUiViewName KurotatoMainView = new EUiViewName("KurotatoMainView");

		// Token: 0x0401CA9A RID: 117402
		public static readonly EUiViewName KurotatoEnemyDetailBookMainView = new EUiViewName("KurotatoEnemyDetailBookMainView");

		// Token: 0x0401CA9B RID: 117403
		public static readonly EUiViewName KurotatoLimitedTimeRewardView = new EUiViewName("KurotatoLimitedTimeRewardView");

		// Token: 0x0401CA9C RID: 117404
		public static readonly EUiViewName KurotatoNormalRewardView = new EUiViewName("KurotatoNormalRewardView");

		// Token: 0x0401CA9D RID: 117405
		public static readonly EUiViewName KurotatoHandBookView = new EUiViewName("KurotatoHandBookView");

		// Token: 0x0401CA9E RID: 117406
		public static readonly EUiViewName KurotatoRoleSelectView = new EUiViewName("KurotatoRoleSelectView");

		// Token: 0x0401CA9F RID: 117407
		public static readonly EUiViewName KurotatoLevelSelectView = new EUiViewName("KurotatoLevelSelectView");

		// Token: 0x0401CAA0 RID: 117408
		public static readonly EUiViewName KurotatoActivityOpenView = new EUiViewName("KurotatoActivityOpenView");

		// Token: 0x0401CAA1 RID: 117409
		public static readonly EUiViewName KurotatoPopupSaveView = new EUiViewName("KurotatoPopupSaveView");

		// Token: 0x0401CAA2 RID: 117410
		public static readonly EUiViewName KurotatoShopOpenTipView = new EUiViewName("KurotatoShopOpenTipView");

		// Token: 0x0401CAA3 RID: 117411
		public static readonly EUiViewName ActivityFeiXuePreheatMainView = new EUiViewName("ActivityFeiXuePreheatConfirmView");

		// Token: 0x0401CAA4 RID: 117412
		public static readonly EUiViewName FeiXuePreheatMainView = new EUiViewName("FeiXuePreheatMainView");

		// Token: 0x0401CAA5 RID: 117413
		public static readonly EUiViewName FeiXuePreheatRewardView = new EUiViewName("FeiXuePreheatRewardView");

		// Token: 0x0401CAA6 RID: 117414
		public static readonly EUiViewName DropCatchLevelSelectView = new EUiViewName("DropCatchLevelSelectView");

		// Token: 0x0401CAA7 RID: 117415
		public static readonly EUiViewName DropCatchRoleDetailView = new EUiViewName("DropCatchRoleDetailView");

		// Token: 0x0401CAA8 RID: 117416
		public static readonly EUiViewName DropCatchDropItemDetailView = new EUiViewName("DropCatchDropItemDetailView");

		// Token: 0x0401CAA9 RID: 117417
		public static readonly EUiViewName DropCatchGameplayView = new EUiViewName("DropCatchGameplayView");

		// Token: 0x0401CAAA RID: 117418
		public static readonly EUiViewName DropCatchGameplayPauseView = new EUiViewName("DropCatchGameplayPauseView");

		// Token: 0x0401CAAB RID: 117419
		public static readonly EUiViewName DropCatchGameplayResultView = new EUiViewName("DropCatchGameplayResultView");

		// Token: 0x0401CAAC RID: 117420
		public static readonly EUiViewName DropCatchStartGameView = new EUiViewName("DropCatchStartGameView");

		// Token: 0x0401CAAD RID: 117421
		public static readonly EUiViewName DropCatchChatPopView = new EUiViewName("DropCatchChatPopView");

		// Token: 0x0401CAAE RID: 117422
		public static readonly EUiViewName SpringManorAlbumPropView = new EUiViewName("Spring26AlbumPropView");

		// Token: 0x0401CAAF RID: 117423
		public static readonly EUiViewName SpringManorBrochureView = new EUiViewName("Spring26BrochureView");

		// Token: 0x0401CAB0 RID: 117424
		public static readonly EUiViewName SpringManorAlbumView = new EUiViewName("Spring26AlbumView");

		// Token: 0x0401CAB1 RID: 117425
		public static readonly EUiViewName SpringManorBrochureDetailView = new EUiViewName("Spring26BrochureDetailView");

		// Token: 0x0401CAB2 RID: 117426
		public static readonly EUiViewName SpringManorBrochureCompletedView = new EUiViewName("Spring26BrochureCompletedView");

		// Token: 0x0401CAB3 RID: 117427
		public static readonly EUiViewName DrinksSelectRoleView = new EUiViewName("DrinksSelectRoleView");

		// Token: 0x0401CAB4 RID: 117428
		public static readonly EUiViewName DrinksGameplayView = new EUiViewName("DrinksGameplayView");

		// Token: 0x0401CAB5 RID: 117429
		public static readonly EUiViewName DrinksShowView = new EUiViewName("DrinksShowView");

		// Token: 0x0401CAB6 RID: 117430
		public static readonly EUiViewName ActivityGamePlayPlotView = new EUiViewName("ActivityGamePlayPlotView");

		// Token: 0x0401CAB7 RID: 117431
		public static readonly EUiViewName GuessJokerGamePlayView = new EUiViewName("GuessJokerGamePlayView");

		// Token: 0x0401CAB8 RID: 117432
		public static readonly EUiViewName GuessJokerSelectRoleView = new EUiViewName("GuessJokerSelectRoleView");

		// Token: 0x0401CAB9 RID: 117433
		public static readonly EUiViewName GuessJokerSettleWinView = new EUiViewName("GuessJokerSettleWinView");

		// Token: 0x0401CABA RID: 117434
		public static readonly EUiViewName GuessJokerSettleFailView = new EUiViewName("GuessJokerSettleFailView");

		// Token: 0x0401CABB RID: 117435
		public static readonly EUiViewName GuessJokerFloatTipsView = new EUiViewName("GuessJokerFloatTipsView");

		// Token: 0x0401CABC RID: 117436
		public static readonly EUiViewName EncirclePlayView = new EUiViewName("EncirclePlayView");

		// Token: 0x0401CABD RID: 117437
		public static readonly EUiViewName EncircleLevelDetailView = new EUiViewName("EncircleLevelDetailView");

		// Token: 0x0401CABE RID: 117438
		public static readonly EUiViewName EncircleSelectLevelView = new EUiViewName("EncircleSelectLevelView");

		// Token: 0x0401CABF RID: 117439
		public static readonly EUiViewName EncircleResultView = new EUiViewName("EncircleResultView");

		// Token: 0x0401CAC0 RID: 117440
		public static readonly EUiViewName RoleSkinRewardView = new EUiViewName("RoleSkinRewardView");

		// Token: 0x0401CAC1 RID: 117441
		public static readonly EUiViewName SunSpiritHintView = new EUiViewName("SunSpiritHintView");

		// Token: 0x0401CAC2 RID: 117442
		public static readonly EUiViewName SunSpiritLauncherHintView = new EUiViewName("SunSpiritLauncherHintView");

		// Token: 0x0401CAC3 RID: 117443
		public static readonly EUiViewName FurnitureDesignView = new EUiViewName("FurnitureDesignView");

		// Token: 0x0401CAC4 RID: 117444
		public static readonly EUiViewName FurniturePresetView = new EUiViewName("FurniturePresetView");

		// Token: 0x0401CAC5 RID: 117445
		public static readonly EUiViewName FurnitureHandBookView = new EUiViewName("FurnitureHandBookView");

		// Token: 0x0401CAC6 RID: 117446
		public static readonly EUiViewName FurnitureGetWayView = new EUiViewName("FurnitureGetWayView");

		// Token: 0x0401CAC7 RID: 117447
		public static readonly EUiViewName FurnitureAreaSelectView = new EUiViewName("FurnitureAreaSelectView");

		// Token: 0x0401CAC8 RID: 117448
		public static readonly EUiViewName FurnitureShopView = new EUiViewName("FurnitureShopView");

		// Token: 0x0401CAC9 RID: 117449
		public static readonly EUiViewName MotorRaceSettlementView = new EUiViewName("MotorRaceSettlementView");

		// Token: 0x0401CACA RID: 117450
		public static readonly EUiViewName MotorParkourMainView = new EUiViewName("MotorParkourMainView");

		// Token: 0x0401CACB RID: 117451
		public static readonly EUiViewName MotorParkourRewardView = new EUiViewName("MotorParkourRewardView");

		// Token: 0x0401CACC RID: 117452
		public static readonly EUiViewName MotorParkourSettleView = new EUiViewName("MotorParkourSettleView");

		// Token: 0x0401CACD RID: 117453
		public static readonly EUiViewName MotorParkourBattleView = new EUiViewName("MotorParkourBattleView");

		// Token: 0x0401CACE RID: 117454
		public static readonly EUiViewName MotorParkourTimerView = new EUiViewName("MotorParkourTimerView");

		// Token: 0x0401CACF RID: 117455
		public static readonly EUiViewName CoopRoleSelectView = new EUiViewName("CoopRoleSelectView");

		// Token: 0x0401CAD0 RID: 117456
		public static readonly EUiViewName CoopEntranceView = new EUiViewName("CoopEntranceView");

		// Token: 0x0401CAD1 RID: 117457
		public static readonly EUiViewName CoopUpGrateView = new EUiViewName("CoopUpGrateView");

		// Token: 0x0401CAD2 RID: 117458
		public static readonly EUiViewName CoopSpRewardView = new EUiViewName("CoopSpRewardView");

		// Token: 0x0401CAD3 RID: 117459
		public static readonly EUiViewName CoopPhotoPreviewView = new EUiViewName("CoopPhotoPreviewView");

		// Token: 0x0401CAD4 RID: 117460
		public static readonly EUiViewName RollBlockView = new EUiViewName("RollBlockView");

		// Token: 0x0401CAD5 RID: 117461
		public static readonly EUiViewName PhantomInteractSummonView = new EUiViewName("PhantomInteractSummonView");

		// Token: 0x0401CAD6 RID: 117462
		public static readonly EUiViewName PhantomInteractEditView = new EUiViewName("PhantomInteractEditView");

		// Token: 0x0401CAD7 RID: 117463
		public static readonly EUiViewName ActivityNewPlayerSupportTrialRoleView = new EUiViewName("ActivityNewPlayerSupportTrialRoleView");

		// Token: 0x0401CAD8 RID: 117464
		public static readonly EUiViewName ActivityNewPlayerSupportRewardView = new EUiViewName("ActivityNewPlayerSupportRewardView");

		// Token: 0x0401CAD9 RID: 117465
		public static readonly EUiViewName ActivityNewPlayerSupportStartupView = new EUiViewName("ActivityNewPlayerSupportStartupView");

		// Token: 0x0401CADA RID: 117466
		public static readonly EUiViewName NewPlayerAdventureV2View = new EUiViewName("NewPlayerAdventureV2View");

		// Token: 0x0401CADB RID: 117467
		public static readonly EUiViewName MotorcycleArrowCollectionSelectView = new EUiViewName("MotorcycleArrowCollectionSelectView");

		// Token: 0x0401CADC RID: 117468
		public static readonly EUiViewName MotorFightMainView = new EUiViewName("MotorFightMainView");

		// Token: 0x0401CADD RID: 117469
		public static readonly EUiViewName MotorcycleArrowCollectionTipsView = new EUiViewName("MotorcycleArrowCollectionTipsView");

		// Token: 0x0401CADE RID: 117470
		public static readonly EUiViewName MotorFightRewardView = new EUiViewName("MotorFightRewardView");

		// Token: 0x0401CADF RID: 117471
		public static readonly EUiViewName MotorFightHandBookView = new EUiViewName("MotorFightHandBookView");

		// Token: 0x0401CAE0 RID: 117472
		public static readonly EUiViewName MotorFightTalentTreeView = new EUiViewName("MotorFightTalentTreeView");

		// Token: 0x0401CAE1 RID: 117473
		public static readonly EUiViewName MotorFightRankView = new EUiViewName("MotorFightRankView");

		// Token: 0x0401CAE2 RID: 117474
		public static readonly EUiViewName MotorFightRankDetailView = new EUiViewName("MotorFightRankDetailView");

		// Token: 0x0401CAE3 RID: 117475
		public static readonly EUiViewName MotorFightLevelDetailView = new EUiViewName("MotorFightLevelDetailView");

		// Token: 0x0401CAE4 RID: 117476
		public static readonly EUiViewName MotorFightRoleSelectView = new EUiViewName("MotorFightRoleSelectView");

		// Token: 0x0401CAE5 RID: 117477
		public static readonly EUiViewName MotorFightSuccessView = new EUiViewName("MotorFightSuccessView");

		// Token: 0x0401CAE6 RID: 117478
		public static readonly EUiViewName MotorFightFailView = new EUiViewName("MotorFightFailView");

		// Token: 0x0401CAE7 RID: 117479
		public static readonly EUiViewName MotorFightPauseView = new EUiViewName("MotorFightPauseView");

		// Token: 0x0401CAE8 RID: 117480
		public static readonly EUiViewName MotorFightArchiveTip = new EUiViewName("MotorFightArchiveTip");

		// Token: 0x0401CAE9 RID: 117481
		public static readonly EUiViewName MotorFightAttrDetailView = new EUiViewName("MotorFightAttrDetailView");

		// Token: 0x0401CAEA RID: 117482
		public static readonly EUiViewName MotorFightItemTips = new EUiViewName("MotorFightItemTips");

		// Token: 0x0401CAEB RID: 117483
		public static readonly EUiViewName SpringManorAtmosphereLevelView = new EUiViewName("Spring26AtmosphereLevelView");

		// Token: 0x0401CAEC RID: 117484
		public static readonly EUiViewName SpringManorRewardView = new EUiViewName("Spring26RewardView");

		// Token: 0x0401CAED RID: 117485
		public static readonly EUiViewName SpringManorQuestView = new EUiViewName("Spring26QuestView");

		// Token: 0x0401CAEE RID: 117486
		public static readonly EUiViewName SpringManorLoadingView = new EUiViewName("Spring26LoadingView");

		// Token: 0x0401CAEF RID: 117487
		public static readonly EUiViewName SpringManorHudView = new EUiViewName("Spring26HudView");

		// Token: 0x0401CAF0 RID: 117488
		public static readonly EUiViewName SpringManorGameplayEntryView = new EUiViewName("Spring26GameplayEntryView");

		// Token: 0x0401CAF1 RID: 117489
		public static readonly EUiViewName SpringManorAtmosphereLevelUpView = new EUiViewName("Spring26AtmosphereLevelUpView");

		// Token: 0x0401CAF2 RID: 117490
		public static readonly EUiViewName SpringManorUnlockView = new EUiViewName("Spring26UnlockView");

		// Token: 0x0401CAF3 RID: 117491
		public static readonly EUiViewName SpringManorWeaponExhibitView = new EUiViewName("Spring26WeaponExhibitView");

		// Token: 0x0401CAF4 RID: 117492
		public static readonly EUiViewName SpringManorPhantomExhibitView = new EUiViewName("Spring26PhantomExhibitView");

		// Token: 0x0401CAF5 RID: 117493
		public static readonly EUiViewName SpringManorActivityOpenView = new EUiViewName("Spring26ActivityOpenView");

		// Token: 0x0401CAF6 RID: 117494
		public static readonly EUiViewName SpringManorRoleSwitchView = new EUiViewName("Spring26RoleSelectView");

		// Token: 0x0401CAF7 RID: 117495
		public static readonly EUiViewName RegressBpMainView = new EUiViewName("RegressBpMainView");

		// Token: 0x0401CAF8 RID: 117496
		public static readonly EUiViewName RegressBpBuyLevelView = new EUiViewName("RegressBpBuyLevelView");

		// Token: 0x0401CAF9 RID: 117497
		public static readonly EUiViewName RegressBpPayView = new EUiViewName("RegressBpPayView");

		// Token: 0x0401CAFA RID: 117498
		public static readonly EUiViewName RegressBpLevelUpTipsView = new EUiViewName("RegressBpLevelUpTipsView");

		// Token: 0x0401CAFB RID: 117499
		public static readonly EUiViewName FindSunSpiritView = new EUiViewName("FindSunSpiritView");

		// Token: 0x0401CAFC RID: 117500
		public static readonly EUiViewName RhythmShipCalibrationView = new EUiViewName("RhythmShipCalibrationView");

		// Token: 0x0401CAFD RID: 117501
		public static readonly EUiViewName RhythmShipChoseLevelView = new EUiViewName("RhythmShipChoseLevelView");

		// Token: 0x0401CAFE RID: 117502
		public static readonly EUiViewName RhythmShipQuickSelectLevelView = new EUiViewName("RhythmShipQuickSelectLevelView");

		// Token: 0x0401CAFF RID: 117503
		public static readonly EUiViewName RhythmShipChoseRoleView = new EUiViewName("RhythmShipChoseRoleView");

		// Token: 0x0401CB00 RID: 117504
		public static readonly EUiViewName RhythmShipRatingView = new EUiViewName("RhythmShipRatingView");

		// Token: 0x0401CB01 RID: 117505
		public static readonly EUiViewName RhythmShipTaskView = new EUiViewName("RhythmShipTaskView");

		// Token: 0x0401CB02 RID: 117506
		public static readonly EUiViewName RhythmShipLimitTaskView = new EUiViewName("RhythmShipLimitTaskView");

		// Token: 0x0401CB03 RID: 117507
		public static readonly EUiViewName RhythmShipSettlementView = new EUiViewName("RhythmShipSettlementView");

		// Token: 0x0401CB04 RID: 117508
		public static readonly EUiViewName RhythmShipPauseView = new EUiViewName("RhythmShipPauseView");

		// Token: 0x0401CB05 RID: 117509
		public static readonly EUiViewName RhythmShipSetView = new EUiViewName("RhythmShipSetView");

		// Token: 0x0401CB06 RID: 117510
		public static readonly EUiViewName RhythmShipSetTipsView = new EUiViewName("RhythmShipSetTipsView");

		// Token: 0x0401CB07 RID: 117511
		public static readonly EUiViewName RhythmShipGameView = new EUiViewName("RhythmShipGameView");

		// Token: 0x0401CB08 RID: 117512
		public static readonly EUiViewName RhythmShipGameEndTipView = new EUiViewName("RhythmShipGameEndTipView");

		// Token: 0x0401CB09 RID: 117513
		public static readonly EUiViewName TetrisPlayView = new EUiViewName("TetrisPlayView");

		// Token: 0x0401CB0A RID: 117514
		public static readonly EUiViewName TetrisLevelDetailView = new EUiViewName("TetrisLevelDetailView");

		// Token: 0x0401CB0B RID: 117515
		public static readonly EUiViewName TetrisSelectLevelView = new EUiViewName("TetrisSelectLevelView");

		// Token: 0x0401CB0C RID: 117516
		public static readonly EUiViewName TetrisTipsWinView = new EUiViewName("TetrisTipsWinView");

		// Token: 0x0401CB0D RID: 117517
		public static readonly EUiViewName TetrisTipsTargetView = new EUiViewName("TetrisTipsTargetView");

		// Token: 0x0401CB0E RID: 117518
		public static readonly EUiViewName TetrisTipsLoseView = new EUiViewName("TetrisTipsLoseView");

		// Token: 0x0401CB0F RID: 117519
		public static readonly EUiViewName TetrisTipsEndLessEndView = new EUiViewName("TetrisTipsEndLessEndView");

		// Token: 0x0401CB10 RID: 117520
		public static readonly EUiViewName TetrisTipsEndLessStartView = new EUiViewName("TetrisTipsEndLessStartView");

		// Token: 0x0401CB11 RID: 117521
		public static readonly EUiViewName TetrisLoadingView = new EUiViewName("TetrisLoadingView");

		// Token: 0x0401CB12 RID: 117522
		public static readonly EUiViewName ChatPopView = new EUiViewName("ChatPopView");

		// Token: 0x0401CB13 RID: 117523
		public static readonly EUiViewName MenuDetailPopView = new EUiViewName("MenuDetailPopView");

		// Token: 0x0401CB14 RID: 117524
		public static readonly EUiViewName FlagChallengeRewardView = new EUiViewName("FlagChallengeRewardView");

		// Token: 0x0401CB15 RID: 117525
		public static readonly EUiViewName FlagChallengeSelectRoleView = new EUiViewName("FlagChallengeSelectRoleView");

		// Token: 0x0401CB16 RID: 117526
		public static readonly EUiViewName FlagChallengeBuffView = new EUiViewName("FlagChallengeBuffView");

		// Token: 0x0401CB17 RID: 117527
		public static readonly EUiViewName FlagChallengeOccupiedSuccessView = new EUiViewName("FlagChallengeOccupiedSuccessView");

		// Token: 0x0401CB18 RID: 117528
		public static readonly EUiViewName FlagChallengeSettleView = new EUiViewName("FlagChallengeSettleView");

		// Token: 0x0401CB19 RID: 117529
		public static readonly EUiViewName FlagChallengeReviveView = new EUiViewName("FlagChallengeReviveView");

		// Token: 0x0401CB1A RID: 117530
		public static readonly EUiViewName FlagChallengePauseView = new EUiViewName("FlagChallengePauseView");

		// Token: 0x0401CB1B RID: 117531
		public static readonly EUiViewName FlagChallengeMainView = new EUiViewName("FlagChallengeMainView");

		// Token: 0x0401CB1C RID: 117532
		public static readonly EUiViewName FlagChallengeAreaDetailView = new EUiViewName("FlagChallengeAreaDetailView");

		// Token: 0x0401CB1D RID: 117533
		public static readonly EUiViewName FlagChallengeBuffActiveTips = new EUiViewName("FlagChallengeBuffActiveTips");

		// Token: 0x0401CB1E RID: 117534
		public static readonly EUiViewName FlagChallengePrompt = new EUiViewName("FlagChallengePrompt");

		// Token: 0x0401CB1F RID: 117535
		public static readonly EUiViewName PhantomFilterPopupView = new EUiViewName("PhantomFilterPopupView");

		// Token: 0x0401CB20 RID: 117536
		public static readonly EUiViewName PhantomBatchConfirmPopupView = new EUiViewName("PhantomBatchConfirmPopupView");

		// Token: 0x0401CB21 RID: 117537
		public static readonly EUiViewName PhantomMainPropertyPopupView = new EUiViewName("PhantomMainPropertyPopupView");

		// Token: 0x0401CB22 RID: 117538
		public static readonly EUiViewName PhantomSmartDiscardPopupView = new EUiViewName("PhantomSmartDiscardPopupView");

		// Token: 0x0401CB23 RID: 117539
		public static readonly EUiViewName WheelTowerRoundSelectView = new EUiViewName("WheelTowerRoundSelectView");

		// Token: 0x0401CB24 RID: 117540
		public static readonly EUiViewName WheelTowerBuffSelectView = new EUiViewName("WheelTowerBuffSelectView");

		// Token: 0x0401CB25 RID: 117541
		public static readonly EUiViewName WheelTowerTeamSelectView = new EUiViewName("WheelTowerTeamSelectView");

		// Token: 0x0401CB26 RID: 117542
		public static readonly EUiViewName WheelTowerModeSelectView = new EUiViewName("WheelTowerModeSelectView");

		// Token: 0x0401CB27 RID: 117543
		public static readonly EUiViewName WheelTowerResultView = new EUiViewName("WheelTowerResultView");

		// Token: 0x0401CB28 RID: 117544
		public static readonly EUiViewName WheelTowerRewardView = new EUiViewName("WheelTowerRewardView");

		// Token: 0x0401CB29 RID: 117545
		public static readonly EUiViewName WheelTowerRecordPopup = new EUiViewName("WheelTowerRecordPopup");

		// Token: 0x0401CB2A RID: 117546
		public static readonly EUiViewName WheelTowerRoundTipsView = new EUiViewName("WheelTowerRoundTipsView");

		// Token: 0x0401CB2B RID: 117547
		public static readonly EUiViewName WheelTowerMainView = new EUiViewName("WheelTowerMainView");

		// Token: 0x0401CB2C RID: 117548
		public static readonly EUiViewName WheelTowerModeDetailView = new EUiViewName("WheelTowerModeDetailView");

		// Token: 0x0401CB2D RID: 117549
		public static readonly EUiViewName WheelTowerPrepareView = new EUiViewName("WheelTowerPrepareView");

		// Token: 0x0401CB2E RID: 117550
		public static readonly EUiViewName WheelTowerEnhanceRoleView = new EUiViewName("WheelTowerEnhanceRoleView");

		// Token: 0x0401CB2F RID: 117551
		public static readonly EUiViewName WheelTowerRecordView = new EUiViewName("WheelTowerRecordView");

		// Token: 0x0401CB30 RID: 117552
		public static readonly EUiViewName WheelTowerScoreLevelRuleView = new EUiViewName("WheelTowerScoreLevelRuleView");

		// Token: 0x0401CB31 RID: 117553
		public static readonly EUiViewName WheelTowerRecommendView = new EUiViewName("WheelTowerRecommendView");

		// Token: 0x0401CB32 RID: 117554
		public static readonly EUiViewName WheelTowerBossBuffTip = new EUiViewName("WheelTowerBossBuffTip");

		// Token: 0x0401CB33 RID: 117555
		public static readonly EUiViewName WheelTowerLoadingView = new EUiViewName("WheelTowerLoadingView");

		// Token: 0x0401CB34 RID: 117556
		public static readonly EUiViewName WheelTowerSettlementView = new EUiViewName("WheelTowerSettlementView");

		// Token: 0x0401CB35 RID: 117557
		public static readonly EUiViewName WheelTowerBossHandBookView = new EUiViewName("WheelTowerBossHandBookView");

		// Token: 0x0401CB36 RID: 117558
		public static readonly EUiViewName WheelTowerLimitRewardView = new EUiViewName("WheelTowerLimitRewardView");

		// Token: 0x0401CB37 RID: 117559
		public static readonly EUiViewName WheelTowerSeasonRewardView = new EUiViewName("WheelTowerSeasonRewardView");

		// Token: 0x0401CB38 RID: 117560
		public static readonly EUiViewName WheelTowerCoverRecordPopupView = new EUiViewName("WheelTowerCoverRecordPopupView");

		// Token: 0x0401CB39 RID: 117561
		public static readonly EUiViewName WheelTowerReviewView = new EUiViewName("WheelTowerReviewView");

		// Token: 0x0401CB3A RID: 117562
		public static readonly EUiViewName RoleSkillBranchPopView = new EUiViewName("RoleSkillBranchPopView");

		// Token: 0x0401CB3B RID: 117563
		public static readonly EUiViewName ProjectorPuzzleView = new EUiViewName("ProjectorPuzzleView");

		// Token: 0x0401CB3C RID: 117564
		public static readonly EUiViewName AdamSmasherSelectView = new EUiViewName("AdamSmasherSelectView");

		// Token: 0x0401CB3D RID: 117565
		public static readonly EUiViewName AdamSmasherFormationView = new EUiViewName("AdamSmasherFormationView");

		// Token: 0x0401CB3E RID: 117566
		public static readonly EUiViewName AdamSmasherChallengeFailView = new EUiViewName("AdamSmasherChallengeFailView");

		// Token: 0x0401CB3F RID: 117567
		public static readonly EUiViewName CyberPunkTrialRoleView = new EUiViewName("CyberPunkTrialRoleView");

		// Token: 0x0401CB40 RID: 117568
		public static readonly EUiViewName CyberPunkTaskView = new EUiViewName("CyberPunkTaskView");

		// Token: 0x0401CB41 RID: 117569
		public static readonly EUiViewName RoleDevelopWorldDropEnoughTips = new EUiViewName("RoleDevelopWorldDropEnoughTips");

		// Token: 0x0401CB42 RID: 117570
		public static readonly EUiViewName TetrisGameView = new EUiViewName("TetrisGameView");

		// Token: 0x0401CB43 RID: 117571
		public static readonly EUiViewName TetrisSettlementView = new EUiViewName("TetrisSettlementView");

		// Token: 0x0401CB44 RID: 117572
		public static readonly EUiViewName TetrisGameLoading = new EUiViewName("TetrisGameLoading");

		// Token: 0x0401CB45 RID: 117573
		public static readonly EUiViewName WuWuLogisticsMissionView = new EUiViewName("WuWuLogisticsMissionView");

		// Token: 0x0401CB46 RID: 117574
		public static readonly EUiViewName CyberpunkCountDownView = new EUiViewName("CyberpunkCountDownView");

		// Token: 0x0401CB47 RID: 117575
		public static readonly EUiViewName CommonComicView = new EUiViewName("CommonComicView");

		// Token: 0x0401CB48 RID: 117576
		public static readonly EUiViewName PinballComicView = new EUiViewName("PinballComicView");

		// Token: 0x0401CB49 RID: 117577
		public static readonly EUiViewName BossPilingMainView = new EUiViewName("BossPilingMainView");

		// Token: 0x0401CB4A RID: 117578
		public static readonly EUiViewName BossPilingLevelView = new EUiViewName("BossPilingLevelView");

		// Token: 0x0401CB4B RID: 117579
		public static readonly EUiViewName BossPilingBuffView = new EUiViewName("BossPilingBuffView");

		// Token: 0x0401CB4C RID: 117580
		public static readonly EUiViewName BossPilingLevelDescView = new EUiViewName("BossPilingLevelDescView");

		// Token: 0x0401CB4D RID: 117581
		public static readonly EUiViewName BossPilingTaskView = new EUiViewName("BossPilingTaskView");

		// Token: 0x0401CB4E RID: 117582
		public static readonly EUiViewName BossPilingSettleView = new EUiViewName("BossPilingSettleView");

		// Token: 0x0401CB4F RID: 117583
		public static readonly EUiViewName BossPilingKeyBuffFloatView = new EUiViewName("BossPilingKeyBuffFloatView");

		// Token: 0x0401CB50 RID: 117584
		public static readonly EUiViewName BossPilingNewBuffTipsView = new EUiViewName("BossPilingNewBuffTipsView");

		// Token: 0x0401CB51 RID: 117585
		public static readonly EUiViewName PinballRoleGainView = new EUiViewName("PinballRoleGainView");

		// Token: 0x0401CB52 RID: 117586
		public static readonly EUiViewName PinballSettleResultView = new EUiViewName("PinballSettleResultView");

		// Token: 0x0401CB53 RID: 117587
		public static readonly EUiViewName PinballPlotView = new EUiViewName("PinballPlotView");

		// Token: 0x0401CB54 RID: 117588
		public static readonly EUiViewName PinballMainRootView = new EUiViewName("PinballMainRootView");

		// Token: 0x0401CB55 RID: 117589
		public static readonly EUiViewName PinballWeaponDecomposeView = new EUiViewName("PinballWeaponDecomposeView");

		// Token: 0x0401CB56 RID: 117590
		public static readonly EUiViewName PinballRevivePopupView = new EUiViewName("PinballRevivePopupView");

		// Token: 0x0401CB57 RID: 117591
		public static readonly EUiViewName PinballRoleView = new EUiViewName("PinballRoleView");

		// Token: 0x0401CB58 RID: 117592
		public static readonly EUiViewName PinballShopView = new EUiViewName("PinballShopView");

		// Token: 0x0401CB59 RID: 117593
		public static readonly EUiViewName PinballLimitedRewardView = new EUiViewName("PinballLimitedRewardView");

		// Token: 0x0401CB5A RID: 117594
		public static readonly EUiViewName PinballPermanentRewardView = new EUiViewName("PinballPermanentRewardView");

		// Token: 0x0401CB5B RID: 117595
		public static readonly EUiViewName PinballRankView = new EUiViewName("PinballRankView");

		// Token: 0x0401CB5C RID: 117596
		public static readonly EUiViewName PinballExchangePopView = new EUiViewName("PinballExchangePopView");

		// Token: 0x0401CB5D RID: 117597
		public static readonly EUiViewName PinballWeaponEquipView = new EUiViewName("PinballWeaponEquipView");

		// Token: 0x0401CB5E RID: 117598
		public static readonly EUiViewName PinballFilterView = new EUiViewName("PinballFilterView");

		// Token: 0x0401CB5F RID: 117599
		public static readonly EUiViewName PinballMainHelpView = new EUiViewName("PinballMainHelpView");

		// Token: 0x0401CB60 RID: 117600
		public static readonly EUiViewName ActivityUnlockTipCatapultStoryView = new EUiViewName("ActivityUnlockTipCatapultStoryView");

		// Token: 0x0401CB61 RID: 117601
		public static readonly EUiViewName PinballBubbleView = new EUiViewName("PinballBubbleView");

		// Token: 0x0401CB62 RID: 117602
		public static readonly EUiViewName PinballBattlePauseView = new EUiViewName("PinballBattlePauseView");

		// Token: 0x0401CB63 RID: 117603
		public static readonly EUiViewName PinballBossComingTipsView = new EUiViewName("PinballBossComingTipsView");

		// Token: 0x0401CB64 RID: 117604
		public static readonly EUiViewName PinballFailureTipsView = new EUiViewName("PinballFailureTipsView");

		// Token: 0x0401CB65 RID: 117605
		public static readonly EUiViewName PinballRoleSkillReleaseTipsView = new EUiViewName("PinballRoleSkillReleaseTipsView");

		// Token: 0x0401CB66 RID: 117606
		public static readonly EUiViewName PinballSuccessTipsView = new EUiViewName("PinballSuccessTipsView");

		// Token: 0x0401CB67 RID: 117607
		public static readonly EUiViewName PinballBossSkillTipsView = new EUiViewName("PinballBossSkillTipsView");

		// Token: 0x0401CB68 RID: 117608
		public static readonly EUiViewName PinballRoleSkillMaxTipsView = new EUiViewName("PinballRoleSkillMaxTipsView");

		// Token: 0x0401CB69 RID: 117609
		public static readonly EUiViewName PinballWaveStartTipsView = new EUiViewName("PinballWaveStartTipsView");

		// Token: 0x0401CB6A RID: 117610
		public static readonly EUiViewName PinballWeaponDecomposeResultView = new EUiViewName("PinballWeaponDecomposeResultView");

		// Token: 0x0401CB6B RID: 117611
		public static readonly EUiViewName PinballRoleSelectView = new EUiViewName("PinballRoleSelectView");

		// Token: 0x0401CB6C RID: 117612
		public static readonly EUiViewName PinballFormationSelectRoleView = new EUiViewName("PinballFormationSelectRoleView");

		// Token: 0x0401CB6D RID: 117613
		public static readonly EUiViewName PinballAttributeDetailView = new EUiViewName("PinballAttributeDetailView");

		// Token: 0x0401CB6E RID: 117614
		public static readonly EUiViewName PinballFormationView = new EUiViewName("PinballFormationView");

		// Token: 0x0401CB6F RID: 117615
		public static readonly EUiViewName PinballMonsterDetailView = new EUiViewName("PinballMonsterDetailView");

		// Token: 0x0401CB70 RID: 117616
		public static readonly EUiViewName PinballLoadingView = new EUiViewName("PinballLoadingView");

		// Token: 0x0401CB71 RID: 117617
		public static readonly EUiViewName SplineConstrainedDrag = new EUiViewName("SplineConstrainedDrag");

		// Token: 0x0401CB72 RID: 117618
		public static readonly EUiViewName DollGrabMachineView = new EUiViewName("DollGrabMachineView");

		// Token: 0x0401CB73 RID: 117619
		public static readonly EUiViewName DollGrabShowcaseInspectView = new EUiViewName("DollGrabShowcaseInspectView");

		// Token: 0x0401CB74 RID: 117620
		public static readonly EUiViewName DollGrabShowcaseFocusView = new EUiViewName("DollGrabShowcaseFocusView");

		// Token: 0x0401CB75 RID: 117621
		public static readonly EUiViewName DollGrabMachineCountDownView = new EUiViewName("DollGrabMachineCountDownView");

		// Token: 0x0401CB76 RID: 117622
		public static readonly EUiViewName DollGrabFloatCountDownView = new EUiViewName("DollGrabFloatCountDownView");

		// Token: 0x0401CB77 RID: 117623
		public static readonly EUiViewName DollGrabMachineTimeUpView = new EUiViewName("DollGrabMachineTimeUpView");

		// Token: 0x0401CB78 RID: 117624
		public static readonly EUiViewName DollGrabMachineGetAllView = new EUiViewName("DollGrabMachineGetAllView");

		// Token: 0x0401CB79 RID: 117625
		public static readonly EUiViewName DollGrabMachineSeltView = new EUiViewName("DollGrabMachineSeltView");

		// Token: 0x0401CB7A RID: 117626
		public static readonly EUiViewName DollGrabMachinePauseView = new EUiViewName("DollGrabMachinePauseView");

		// Token: 0x0401CB7B RID: 117627
		public static readonly EUiViewName DollGrabMachineHelpInfoView = new EUiViewName("DollGrabMachineHelpInfoView");

		// Token: 0x0401CB7C RID: 117628
		public static readonly EUiViewName DollGrabDeliveryView = new EUiViewName("DollGrabDeliveryView");

		// Token: 0x0401CB7D RID: 117629
		public static readonly EUiViewName DollGrabEndlessStartView = new EUiViewName("DollGrabEndlessStartView");

		// Token: 0x0401CB7E RID: 117630
		public static readonly EUiViewName MachineryFactoryTouchMoveView = new EUiViewName("MachineryFactoryTouchMoveView");

		// Token: 0x0401CB7F RID: 117631
		public static readonly EUiViewName MengZhouCollectView = new EUiViewName("MengZhouCollectView");

		// Token: 0x0401CB80 RID: 117632
		public static readonly EUiViewName RealmBetweenMainView = new EUiViewName("RealmBetweenMainView");

		// Token: 0x0401CB81 RID: 117633
		public static readonly EUiViewName RealmBetweenTravelTaskView = new EUiViewName("RealmBetweenTravelTaskView");

		// Token: 0x0401CB82 RID: 117634
		public static readonly EUiViewName RealmBetweenPhantomTaskView = new EUiViewName("RealmBetweenPhantomTaskView");

		// Token: 0x0401CB83 RID: 117635
		public static readonly EUiViewName RealmBetweenVehicleTaskView = new EUiViewName("RealmBetweenVehicleTaskView");

		// Token: 0x0401CB84 RID: 117636
		public static readonly EUiViewName RealmBetweenLevelTipsView = new EUiViewName("RealmBetweenLevelTipsView");

		// Token: 0x0401CB85 RID: 117637
		public static readonly EUiViewName ActivityUnlockTipRealmBetweenView = new EUiViewName("ActivityUnlockTipRealmBetweenView");

		// Token: 0x0401CB86 RID: 117638
		public static readonly EUiViewName WriteLetterView = new EUiViewName("WriteLetterView");

		// Token: 0x0401CB87 RID: 117639
		public static readonly EUiViewName LetterBackupDisplayView = new EUiViewName("LetterBackupDisplayView");

		// Token: 0x0401CB88 RID: 117640
		public static readonly EUiViewName ProjectionPhotoView = new EUiViewName("ProjectionPhotoView");

		// Token: 0x0401CB89 RID: 117641
		public static readonly EUiViewName GolemHackingGameView = new EUiViewName("GolemHackingGameView");

		// Token: 0x0401CB8A RID: 117642
		public static readonly EUiViewName GolemHackingGameTipsPopView = new EUiViewName("GolemHackingGameTipsPopView");

		// Token: 0x0401CB8B RID: 117643
		public static readonly EUiViewName GolemHackingResultPop = new EUiViewName("GolemHackingResultPop");

		// Token: 0x0401CB8C RID: 117644
		public static readonly EUiViewName GolemHackingLevelMainView = new EUiViewName("GolemHackingLevelMainView");

		// Token: 0x0401CB8D RID: 117645
		public static readonly EUiViewName GolemHackingLevelDetailView = new EUiViewName("GolemHackingLevelDetailView");

		// Token: 0x0401CB8E RID: 117646
		public static readonly EUiViewName GachaAccumulateBonusView = new EUiViewName("GachaAccumulateBonusView");

		// Token: 0x0401CB8F RID: 117647
		public static readonly EUiViewName ItemRewardSelectView = new EUiViewName("ItemRewardSelectView");

		// Token: 0x0401CB90 RID: 117648
		public static readonly EUiViewName ItemConvertTipsView = new EUiViewName("ItemConvertTipsView");

		// Token: 0x0401CB91 RID: 117649
		public static readonly EUiViewName ItemExpiredAutoConvertTipsView = new EUiViewName("ItemExpiredAutoConvertTipsView");

		// Token: 0x0401CB92 RID: 117650
		public static readonly EUiViewName CommonQuickHackView = new EUiViewName("CommonQuickHackView");

		// Token: 0x0401CB93 RID: 117651
		public static readonly EUiViewName BattleQuickHackView = new EUiViewName("BattleQuickHackView");

		// Token: 0x0401CB94 RID: 117652
		public static readonly EUiViewName QuickHackCameraControlView = new EUiViewName("QuickHackCameraControlView");

		// Token: 0x0401CB95 RID: 117653
		public static readonly EUiViewName MotorDecalLinkRewardView = new EUiViewName("MotorDecalLinkRewardView");

		// Token: 0x0401CB96 RID: 117654
		public static readonly EUiViewName PlotWordArtView = new EUiViewName("PlotWordArtView");

		// Token: 0x0401CB97 RID: 117655
		public static readonly EUiViewName PlotWordArtCaptionView = new EUiViewName("PlotWordArtCaptionView");

		// Token: 0x0401CB98 RID: 117656
		public static readonly EUiViewName MultiMotorMainView = new EUiViewName("MultiMotorMainView");

		// Token: 0x0401CB99 RID: 117657
		public static readonly EUiViewName MultiMotorChoseLevelView = new EUiViewName("MultiMotorChoseLevelView");

		// Token: 0x0401CB9A RID: 117658
		public static readonly EUiViewName MultiMotorSettlementView = new EUiViewName("MultiMotorSettlementView");

		// Token: 0x0401CB9B RID: 117659
		public static readonly EUiViewName MultiMotorRewardView = new EUiViewName("MultiMotorRewardView");

		// Token: 0x0401CB9C RID: 117660
		public static readonly EUiViewName MoonTogetherMainView = new EUiViewName("MoonTogetherMainView");

		// Token: 0x0401CB9D RID: 117661
		public static readonly EUiViewName MoonTogetherInviteView = new EUiViewName("MoonTogetherInviteView");

		// Token: 0x0401CB9E RID: 117662
		public static readonly EUiViewName QteHourglassView = new EUiViewName("QteHourglassView");

		// Token: 0x0401CB9F RID: 117663
		public static readonly EUiViewName QuestMultiLineView = new EUiViewName("QuestMultiLineView");

		// Token: 0x0401CBA0 RID: 117664
		public static readonly EUiViewName FirstPersonTurretView = new EUiViewName("FirstPersonTurretView");

		// Token: 0x0401CBA1 RID: 117665
		public static readonly EUiViewName QuestMultiLineTipsView = new EUiViewName("QuestMultiLineTipsView");

		// Token: 0x0401CBA2 RID: 117666
		public static readonly EUiViewName NewcomerSplashView = new EUiViewName("NewcomerSplashView");

		// Token: 0x0401CBA3 RID: 117667
		public static readonly EUiViewName NewcomerJourneyChoseRoleView = new EUiViewName("NewcomerJourneyChoseRoleView");

		// Token: 0x0401CBA4 RID: 117668
		public static readonly EUiViewName WuWaGoView = new EUiViewName("WuWaGoView");

		// Token: 0x0401CBA5 RID: 117669
		public static readonly EUiViewName WuWaGoPauseView = new EUiViewName("WuWaGoPauseView");

		// Token: 0x0401CBA6 RID: 117670
		public static readonly EUiViewName WuWaGoPopupView = new EUiViewName("WuWaGoPopupView");

		// Token: 0x0401CBA7 RID: 117671
		public static readonly EUiViewName WheelTowerMedalDetailView = new EUiViewName("WheelTowerMedalDetailView");

		// Token: 0x0401CBA8 RID: 117672
		public static readonly EUiViewName WheelTowerSeasonMedalView = new EUiViewName("WheelTowerSeasonMedalView");

		// Token: 0x0401CBA9 RID: 117673
		public static readonly EUiViewName WheelTowerSeasonOverviewView = new EUiViewName("WheelTowerSeasonOverviewView");

		// Token: 0x0401CBAA RID: 117674
		public static readonly EUiViewName WheelTowerSeasonReviewView = new EUiViewName("WheelTowerSeasonReviewView");

		// Token: 0x0401CBAB RID: 117675
		public static readonly EUiViewName WheelTowerMedalRuleView = new EUiViewName("WheelTowerMedalRuleView");

		// Token: 0x0401CBAC RID: 117676
		public static readonly EUiViewName SheriffMainView = new EUiViewName("SheriffMainView");

		// Token: 0x0401CBAD RID: 117677
		public static readonly EUiViewName SheriffReportPop = new EUiViewName("SheriffReportPop");

		// Token: 0x0401CBAE RID: 117678
		public static readonly EUiViewName SheriffAnalysisResultPop = new EUiViewName("SheriffAnalysisResultPop");

		// Token: 0x0401CBAF RID: 117679
		public static readonly EUiViewName SheriffShowClueViewPop = new EUiViewName("SheriffShowClueViewPop");

		// Token: 0x0401CBB0 RID: 117680
		public static readonly EUiViewName SheriffShopView = new EUiViewName("SheriffShopView");

		// Token: 0x0401CBB1 RID: 117681
		public static readonly EUiViewName SheriffStartTrackPopupView = new EUiViewName("SheriffStartTrackPopupView");

		// Token: 0x0401CBB2 RID: 117682
		public static readonly EUiViewName SheriffArrestPopupView = new EUiViewName("SheriffArrestPopupView");

		// Token: 0x0401CBB3 RID: 117683
		public static readonly EUiViewName SheriffCriminalIdentityConfirmedView = new EUiViewName("SheriffCriminalIdentityConfirmedView");

		// Token: 0x0401CBB4 RID: 117684
		public static readonly EUiViewName SheriffErrorView = new EUiViewName("SheriffErrorView");

		// Token: 0x0401CBB5 RID: 117685
		public static readonly EUiViewName GuQinActivityMainView = new EUiViewName("GuQinActivityMainView");

		// Token: 0x0401CBB6 RID: 117686
		public static readonly EUiViewName ChineseZitherView = new EUiViewName("ChineseZitherView");

		// Token: 0x0401CBB7 RID: 117687
		public static readonly EUiViewName RoverlikeMainView = new EUiViewName("RoverlikeMainView");

		// Token: 0x0401CBB8 RID: 117688
		public static readonly EUiViewName RoverlikeShopView = new EUiViewName("RoverlikeShopView");

		// Token: 0x0401CBB9 RID: 117689
		public static readonly EUiViewName RoverlikeQuestRewardView = new EUiViewName("RoverlikeQuestRewardView");

		// Token: 0x0401CBBA RID: 117690
		public static readonly EUiViewName RoverlikeHandBookView = new EUiViewName("RoverlikeHandBookView");

		// Token: 0x0401CBBB RID: 117691
		public static readonly EUiViewName RoverlikeDetailView = new EUiViewName("RoverlikeDetailView");

		// Token: 0x0401CBBC RID: 117692
		public static readonly EUiViewName RoverlikeRoleUnlockView = new EUiViewName("RoverlikeRoleUnlockView");

		// Token: 0x0401CBBD RID: 117693
		public static readonly EUiViewName RoverlikeLevelSelectView = new EUiViewName("RoverlikeLevelSelectView");

		// Token: 0x0401CBBE RID: 117694
		public static readonly EUiViewName RoverlikeTalentTreeView = new EUiViewName("RoverlikeTalentTreeView");

		// Token: 0x0401CBBF RID: 117695
		public static readonly EUiViewName RoverlikeTalentTreeUnlockView = new EUiViewName("RoverlikeTalentTreeUnlockView");

		// Token: 0x0401CBC0 RID: 117696
		public static readonly EUiViewName RoverlikeLootView = new EUiViewName("RoverlikeLootView");

		// Token: 0x0401CBC1 RID: 117697
		public static readonly EUiViewName RoverlikeRoleSelectView = new EUiViewName("RoverlikeRoleSelectView");

		// Token: 0x0401CBC2 RID: 117698
		public static readonly EUiViewName RoverlikeLootUnlockView = new EUiViewName("RoverlikeLootUnlockView");

		// Token: 0x0401CBC3 RID: 117699
		public static readonly EUiViewName RoverlikeGeneralActionView = new EUiViewName("RoverlikeGeneralActionView");

		// Token: 0x0401CBC4 RID: 117700
		public static readonly EUiViewName RoverlikeBlessingReplaceView = new EUiViewName("RoverlikeBlessingReplaceView");

		// Token: 0x0401CBC5 RID: 117701
		public static readonly EUiViewName RoverlikeGeneralObtainView = new EUiViewName("RoverlikeGeneralObtainView");

		// Token: 0x0401CBC6 RID: 117702
		public static readonly EUiViewName RoverlikeGameShopView = new EUiViewName("RoverlikeGameShopView");

		// Token: 0x0401CBC7 RID: 117703
		public static readonly EUiViewName RoverlikePauseView = new EUiViewName("RoverlikePauseView");

		// Token: 0x0401CBC8 RID: 117704
		public static readonly EUiViewName RoverlikeResultView = new EUiViewName("RoverlikeResultView");

		// Token: 0x0401CBC9 RID: 117705
		public static readonly EUiViewName RoverlikeLevelTipsView = new EUiViewName("RoverlikeLevelTipsView");

		// Token: 0x0401CBCA RID: 117706
		public static readonly EUiViewName RoverlikeLootTipsView = new EUiViewName("RoverlikeLootTipsView");

		// Token: 0x0401CBCB RID: 117707
		public static readonly EUiViewName RoverlikeInfoTipsView = new EUiViewName("RoverlikeInfoTipsView");

		// Token: 0x0401CBCC RID: 117708
		public static readonly EUiViewName RoverlikeRoleBlessingTips = new EUiViewName("RoverlikeRoleBlessingTips");

		// Token: 0x0401CBCD RID: 117709
		public static readonly EUiViewName RoverlikeUnlockTipView = new EUiViewName("RoverlikeUnlockTipView");

		// Token: 0x0401CBCE RID: 117710
		public static readonly EUiViewName SwordControlGroundView = new EUiViewName("SwordControlGroundView");

		// Token: 0x0401CBCF RID: 117711
		public static readonly EUiViewName SwordControlFlightView = new EUiViewName("SwordControlFlightView");
	}
}
