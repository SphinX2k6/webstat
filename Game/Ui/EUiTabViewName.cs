using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049E1 RID: 18913
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EUiTabViewName : IEquatable<EUiTabViewName>, IStaticVariableResetter
	{
		// Token: 0x0603178C RID: 202636 RVA: 0x00C54C19 File Offset: 0x00C52E19
		public EUiTabViewName(string value)
		{
			this._value = value;
		}

		// Token: 0x0603178D RID: 202637 RVA: 0x00C54C22 File Offset: 0x00C52E22
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x0603178E RID: 202638 RVA: 0x00C54C2A File Offset: 0x00C52E2A
		public bool Equals(EUiTabViewName other)
		{
			return this._value == other._value;
		}

		// Token: 0x0603178F RID: 202639 RVA: 0x00C54C40 File Offset: 0x00C52E40
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EUiTabViewName)
			{
				EUiTabViewName other = (EUiTabViewName)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06031790 RID: 202640 RVA: 0x00C54C65 File Offset: 0x00C52E65
		public override int GetHashCode()
		{
			string value = this._value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06031791 RID: 202641 RVA: 0x00C54C78 File Offset: 0x00C52E78
		public static bool operator ==(EUiTabViewName left, EUiTabViewName right)
		{
			return left.Equals(right);
		}

		// Token: 0x06031792 RID: 202642 RVA: 0x00C54C82 File Offset: 0x00C52E82
		public static bool operator !=(EUiTabViewName left, EUiTabViewName right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06031793 RID: 202643 RVA: 0x00C54C8F File Offset: 0x00C52E8F
		public static implicit operator string(EUiTabViewName name)
		{
			return name._value;
		}

		// Token: 0x06031794 RID: 202644 RVA: 0x00C54C97 File Offset: 0x00C52E97
		public static explicit operator EUiTabViewName(string value)
		{
			return new EUiTabViewName(value);
		}

		// Token: 0x06031795 RID: 202645 RVA: 0x00C54C9F File Offset: 0x00C52E9F
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06031796 RID: 202646 RVA: 0x00C54CA1 File Offset: 0x00C52EA1
		public static void ResetStaticDefaultValue()
		{
		}

		// Token: 0x0401CBD0 RID: 117712
		private readonly string _value;

		// Token: 0x0401CBD1 RID: 117713
		public static readonly EUiTabViewName RoleAttributeTabView = new EUiTabViewName("RoleAttributeTabView");

		// Token: 0x0401CBD2 RID: 117714
		public static readonly EUiTabViewName RoleSkillTabView = new EUiTabViewName("RoleSkillTabView");

		// Token: 0x0401CBD3 RID: 117715
		public static readonly EUiTabViewName RoleResonanceTabView = new EUiTabViewName("RoleResonanceTabView");

		// Token: 0x0401CBD4 RID: 117716
		public static readonly EUiTabViewName RoleResonanceTabNewView = new EUiTabViewName("RoleResonanceTabNewView");

		// Token: 0x0401CBD5 RID: 117717
		public static readonly EUiTabViewName RolePreviewAttributeTabView = new EUiTabViewName("RolePreviewAttributeTabView");

		// Token: 0x0401CBD6 RID: 117718
		public static readonly EUiTabViewName RoleWeaponTabView = new EUiTabViewName("RoleWeaponTabView");

		// Token: 0x0401CBD7 RID: 117719
		public static readonly EUiTabViewName RolePhantomTabView = new EUiTabViewName("RolePhantomTabView");

		// Token: 0x0401CBD8 RID: 117720
		public static readonly EUiTabViewName RoleFavorTabView = new EUiTabViewName("RoleFavorTabView");

		// Token: 0x0401CBD9 RID: 117721
		public static readonly EUiTabViewName WeaponLevelUpView = new EUiTabViewName("WeaponLevelUpView");

		// Token: 0x0401CBDA RID: 117722
		public static readonly EUiTabViewName WeaponBreachView = new EUiTabViewName("WeaponBreachView");

		// Token: 0x0401CBDB RID: 117723
		public static readonly EUiTabViewName WeaponResonanceView = new EUiTabViewName("WeaponResonanceView");

		// Token: 0x0401CBDC RID: 117724
		public static readonly EUiTabViewName PayShopGiftBagView = new EUiTabViewName("PayShopGiftBagView");

		// Token: 0x0401CBDD RID: 117725
		public static readonly EUiTabViewName RogueShopTabView = new EUiTabViewName("RogueShopTabView");

		// Token: 0x0401CBDE RID: 117726
		public static readonly EUiTabViewName PayShopExchangeEntryView = new EUiTabViewName("PayShopExchangeEntryView");

		// Token: 0x0401CBDF RID: 117727
		public static readonly EUiTabViewName PayItemTabView = new EUiTabViewName("PayItemTabView");

		// Token: 0x0401CBE0 RID: 117728
		public static readonly EUiTabViewName PayPackageShopView = new EUiTabViewName("PayPackageShopView");

		// Token: 0x0401CBE1 RID: 117729
		public static readonly EUiTabViewName PayShopRecommendView = new EUiTabViewName("PayShopRecommendView");

		// Token: 0x0401CBE2 RID: 117730
		public static readonly EUiTabViewName PayShopSkinView = new EUiTabViewName("PayShopSkinView");

		// Token: 0x0401CBE3 RID: 117731
		public static readonly EUiTabViewName MonthCardView = new EUiTabViewName("MonthCardView");

		// Token: 0x0401CBE4 RID: 117732
		public static readonly EUiTabViewName WeekCardView = new EUiTabViewName("WeekCardView");

		// Token: 0x0401CBE5 RID: 117733
		public static readonly EUiTabViewName RoleSkinRecommendView = new EUiTabViewName("RoleSkinRecommendView");

		// Token: 0x0401CBE6 RID: 117734
		public static readonly EUiTabViewName MotorSkinTabView = new EUiTabViewName("MotorSkinTabView");

		// Token: 0x0401CBE7 RID: 117735
		public static readonly EUiTabViewName PayShopNewPlayerView = new EUiTabViewName("PayShopNewPlayerView");

		// Token: 0x0401CBE8 RID: 117736
		public static readonly EUiTabViewName NewPlayerWeekCardView = new EUiTabViewName("NewPlayerWeekCardView");

		// Token: 0x0401CBE9 RID: 117737
		public static readonly EUiTabViewName MotorSkinRecommendView = new EUiTabViewName("MotorSkinRecommendView");

		// Token: 0x0401CBEA RID: 117738
		public static readonly EUiTabViewName RoleShopSkinTabView = new EUiTabViewName("RoleShopSkinTabView");

		// Token: 0x0401CBEB RID: 117739
		public static readonly EUiTabViewName RoleShopOrnamentTabView = new EUiTabViewName("RoleShopOrnamentTabView");

		// Token: 0x0401CBEC RID: 117740
		public static readonly EUiTabViewName ShopFlySkinTabView = new EUiTabViewName("ShopFlySkinTabView");

		// Token: 0x0401CBED RID: 117741
		public static readonly EUiTabViewName BabelTowerShopTabView = new EUiTabViewName("BabelTowerShopTabView");

		// Token: 0x0401CBEE RID: 117742
		public static readonly EUiTabViewName RolePreviewDescribeTabView = new EUiTabViewName("RolePreviewDescribeTabView");

		// Token: 0x0401CBEF RID: 117743
		public static readonly EUiTabViewName RolePreviewSkillTabView = new EUiTabViewName("RolePreviewSkillTabView");

		// Token: 0x0401CBF0 RID: 117744
		public static readonly EUiTabViewName RolePreviewResonanceTabView = new EUiTabViewName("RolePreviewResonanceTabView");

		// Token: 0x0401CBF1 RID: 117745
		public static readonly EUiTabViewName RoleSkillEmptyTabView = new EUiTabViewName("RoleSkillEmptyTabView");

		// Token: 0x0401CBF2 RID: 117746
		public static readonly EUiTabViewName WeaponPreviewLevelUpView = new EUiTabViewName("WeaponPreviewLevelUpView");

		// Token: 0x0401CBF3 RID: 117747
		public static readonly EUiTabViewName WeaponPreviewResonanceView = new EUiTabViewName("WeaponPreviewResonanceView");

		// Token: 0x0401CBF4 RID: 117748
		public static readonly EUiTabViewName AdventureTargetView = new EUiTabViewName("AdventureTargetView");

		// Token: 0x0401CBF5 RID: 117749
		public static readonly EUiTabViewName MonsterDetectView = new EUiTabViewName("MonsterDetectView");

		// Token: 0x0401CBF6 RID: 117750
		public static readonly EUiTabViewName DisposableChallengeView = new EUiTabViewName("DisposableChallengeView");

		// Token: 0x0401CBF7 RID: 117751
		public static readonly EUiTabViewName NewSoundAreaView = new EUiTabViewName("NewSoundAreaView");

		// Token: 0x0401CBF8 RID: 117752
		public static readonly EUiTabViewName DailyActivityTabView = new EUiTabViewName("DailyActivityTabView");

		// Token: 0x0401CBF9 RID: 117753
		public static readonly EUiTabViewName PeriodicityChallengeView = new EUiTabViewName("PeriodicityChallengeView");

		// Token: 0x0401CBFA RID: 117754
		public static readonly EUiTabViewName RoleHandBookPreviewView = new EUiTabViewName("RoleHandBookPreviewView");

		// Token: 0x0401CBFB RID: 117755
		public static readonly EUiTabViewName PersonalInfoTabView = new EUiTabViewName("PersonalInfoTabView");

		// Token: 0x0401CBFC RID: 117756
		public static readonly EUiTabViewName PersonalCardTabView = new EUiTabViewName("PersonalCardTabView");

		// Token: 0x0401CBFD RID: 117757
		public static readonly EUiTabViewName VisionLevelUpView = new EUiTabViewName("VisionLevelUpView");

		// Token: 0x0401CBFE RID: 117758
		public static readonly EUiTabViewName VisionSlotView = new EUiTabViewName("VisionSlotView");

		// Token: 0x0401CBFF RID: 117759
		public static readonly EUiTabViewName VisionIdentifyView = new EUiTabViewName("VisionIdentifyView");

		// Token: 0x0401CC00 RID: 117760
		public static readonly EUiTabViewName CalabashLevelUpTabView = new EUiTabViewName("CalabashLevelUpTabView");

		// Token: 0x0401CC01 RID: 117761
		public static readonly EUiTabViewName CalabashCollectTabView = new EUiTabViewName("CalabashCollectTabView");

		// Token: 0x0401CC02 RID: 117762
		public static readonly EUiTabViewName PhantomBattleFettersTabView = new EUiTabViewName("PhantomBattleFettersTabView");

		// Token: 0x0401CC03 RID: 117763
		public static readonly EUiTabViewName VisionRecoveryTabView = new EUiTabViewName("VisionRecoveryTabView");

		// Token: 0x0401CC04 RID: 117764
		public static readonly EUiTabViewName VisionRefineTabView = new EUiTabViewName("VisionRefineTabView");

		// Token: 0x0401CC05 RID: 117765
		public static readonly EUiTabViewName PhantomManageConfigView = new EUiTabViewName("PhantomManageConfigView");

		// Token: 0x0401CC06 RID: 117766
		public static readonly EUiTabViewName PhantomManageConfigNewView = new EUiTabViewName("PhantomManageConfigNewView");

		// Token: 0x0401CC07 RID: 117767
		public static readonly EUiTabViewName RoleSkinTabView = new EUiTabViewName("RoleSkinTabView");

		// Token: 0x0401CC08 RID: 117768
		public static readonly EUiTabViewName WeaponSkinTabView = new EUiTabViewName("WeaponSkinTabView");

		// Token: 0x0401CC09 RID: 117769
		public static readonly EUiTabViewName FlySkinTabView = new EUiTabViewName("FlySkinTabView");

		// Token: 0x0401CC0A RID: 117770
		public static readonly EUiTabViewName CalabashSkinTabView = new EUiTabViewName("CalabashSkinTabView");

		// Token: 0x0401CC0B RID: 117771
		public static readonly EUiTabViewName RoleOrnamentTabView = new EUiTabViewName("RoleOrnamentTabView");

		// Token: 0x0401CC0C RID: 117772
		public static readonly EUiTabViewName BattlePassRewardView = new EUiTabViewName("BattlePassRewardView");

		// Token: 0x0401CC0D RID: 117773
		public static readonly EUiTabViewName BattlePassTaskView = new EUiTabViewName("BattlePassTaskView");

		// Token: 0x0401CC0E RID: 117774
		public static readonly EUiTabViewName BattlePassWeaponView = new EUiTabViewName("BattlePassWeaponView");

		// Token: 0x0401CC0F RID: 117775
		public static readonly EUiTabViewName BossRushBuffSelectView = new EUiTabViewName("BossRushBuffSelectView");

		// Token: 0x0401CC10 RID: 117776
		public static readonly EUiTabViewName BossRushLevelDetailView = new EUiTabViewName("BossRushLevelDetailView");

		// Token: 0x0401CC11 RID: 117777
		public static readonly EUiTabViewName BossRushSelectView = new EUiTabViewName("BossRushSelectView");

		// Token: 0x0401CC12 RID: 117778
		public static readonly EUiTabViewName BossRushRewardView = new EUiTabViewName("BossRushRewardView");

		// Token: 0x0401CC13 RID: 117779
		public static readonly EUiTabViewName RewardTargetTabView = new EUiTabViewName("RewardTargetTabView");

		// Token: 0x0401CC14 RID: 117780
		public static readonly EUiTabViewName RewardShopTabView = new EUiTabViewName("RewardShopTabView");

		// Token: 0x0401CC15 RID: 117781
		public static readonly EUiTabViewName DockyardSellTabView = new EUiTabViewName("DockyardSellTabView");

		// Token: 0x0401CC16 RID: 117782
		public static readonly EUiTabViewName DockyardBuyTabView = new EUiTabViewName("DockyardBuyTabView");

		// Token: 0x0401CC17 RID: 117783
		public static readonly EUiTabViewName FishingNormalTechView = new EUiTabViewName("FishingNormalTechView");

		// Token: 0x0401CC18 RID: 117784
		public static readonly EUiTabViewName FishingRoleTechView = new EUiTabViewName("FishingRoleTechView");

		// Token: 0x0401CC19 RID: 117785
		public static readonly EUiTabViewName FishingTimeLimitRewardTabView = new EUiTabViewName("FishingTimeLimitRewardTabView");

		// Token: 0x0401CC1A RID: 117786
		public static readonly EUiTabViewName FishingTimeLimitShopTabView = new EUiTabViewName("FishingTimeLimitShopTabView");

		// Token: 0x0401CC1B RID: 117787
		public static readonly EUiTabViewName RogueIllustratedTokenTabView = new EUiTabViewName("RogueIllustratedTokenTabView");

		// Token: 0x0401CC1C RID: 117788
		public static readonly EUiTabViewName RogueIllustratedEventTabView = new EUiTabViewName("RogueIllustratedEventTabView");

		// Token: 0x0401CC1D RID: 117789
		public static readonly EUiTabViewName RogueBattleMapSummaryTeamTabView = new EUiTabViewName("RogueBattleMapSummaryTeamTabView");

		// Token: 0x0401CC1E RID: 117790
		public static readonly EUiTabViewName RogueBattleMapSummaryFettersTabView = new EUiTabViewName("RogueBattleMapSummaryFettersTabView");

		// Token: 0x0401CC1F RID: 117791
		public static readonly EUiTabViewName RogueBattleSummaryTeamTabView = new EUiTabViewName("RogueBattleSummaryTeamTabView");

		// Token: 0x0401CC20 RID: 117792
		public static readonly EUiTabViewName RogueBattleSummaryTokenTabView = new EUiTabViewName("RogueBattleSummaryTokenTabView");

		// Token: 0x0401CC21 RID: 117793
		public static readonly EUiTabViewName RogueBattleMapSummaryGridEffectTabView = new EUiTabViewName("RogueBattleMapSummaryGridEffectTabView");

		// Token: 0x0401CC22 RID: 117794
		public static readonly EUiTabViewName SurvivorsRoleTabView = new EUiTabViewName("SurvivorsRoleTabView");

		// Token: 0x0401CC23 RID: 117795
		public static readonly EUiTabViewName SurvivorsWeaponTabView = new EUiTabViewName("SurvivorsWeaponTabView");

		// Token: 0x0401CC24 RID: 117796
		public static readonly EUiTabViewName SurvivorsItemTabView = new EUiTabViewName("SurvivorsItemTabView");

		// Token: 0x0401CC25 RID: 117797
		public static readonly EUiTabViewName PhantomArenaEntranceGymTabView = new EUiTabViewName("PhantomArenaEntranceLevelTabView");

		// Token: 0x0401CC26 RID: 117798
		public static readonly EUiTabViewName PhantomArenaEntranceRepeatTabView = new EUiTabViewName("PhantomArenaEntranceRepeatTabView");

		// Token: 0x0401CC27 RID: 117799
		public static readonly EUiTabViewName PhantomArenaCollectCardTabView = new EUiTabViewName("PhantomArenaCollectCardTabView");

		// Token: 0x0401CC28 RID: 117800
		public static readonly EUiTabViewName PhantomArenaCollectCardTabViewNew = new EUiTabViewName("PhantomArenaCollectCardTabViewNew");

		// Token: 0x0401CC29 RID: 117801
		public static readonly EUiTabViewName PhantomArenaCollectBadgeTabView = new EUiTabViewName("PhantomArenaCollectBadgeTabView");

		// Token: 0x0401CC2A RID: 117802
		public static readonly EUiTabViewName PhantomArenaEntranceTaskTabView = new EUiTabViewName("PhantomArenaEntranceTaskTabView");

		// Token: 0x0401CC2B RID: 117803
		public static readonly EUiTabViewName PhantomArenaEntranceShopTabView = new EUiTabViewName("PhantomArenaEntranceShopTabView");

		// Token: 0x0401CC2C RID: 117804
		public static readonly EUiTabViewName HonamiStoryEquipTabView = new EUiTabViewName("HonamiStoryEquipTabView");

		// Token: 0x0401CC2D RID: 117805
		public static readonly EUiTabViewName HonamiStoryRefineTabView = new EUiTabViewName("HonamiStoryRefineTabView");

		// Token: 0x0401CC2E RID: 117806
		public static readonly EUiTabViewName AdvanceNoticeNewRoleTabView = new EUiTabViewName("AdvanceNoticeNewRoleTabView");

		// Token: 0x0401CC2F RID: 117807
		public static readonly EUiTabViewName AdvanceNoticeNewJourneyTabView = new EUiTabViewName("AdvanceNoticeNewJourneyTabView");

		// Token: 0x0401CC30 RID: 117808
		public static readonly EUiTabViewName AdvanceNoticeNewAreaTabView = new EUiTabViewName("AdvanceNoticeNewAreaTabView");

		// Token: 0x0401CC31 RID: 117809
		public static readonly EUiTabViewName AdvanceNoticeNewSkinTabView = new EUiTabViewName("AdvanceNoticeNewSkinTabView");

		// Token: 0x0401CC32 RID: 117810
		public static readonly EUiTabViewName AdvanceNoticeNewEnemyTabView = new EUiTabViewName("AdvanceNoticeNewEnemyTabView");

		// Token: 0x0401CC33 RID: 117811
		public static readonly EUiTabViewName AdvanceNoticeNewActivityTabView = new EUiTabViewName("AdvanceNoticeNewActivityTabView");

		// Token: 0x0401CC34 RID: 117812
		public static readonly EUiTabViewName AdvanceNoticeNewSystemOptimizeTabView = new EUiTabViewName("AdvanceNoticeNewSystemOptimizeTabView");

		// Token: 0x0401CC35 RID: 117813
		public static readonly EUiTabViewName MotorcycleLevelInfoTabView = new EUiTabViewName("MotorcycleLevelInfoTabView");

		// Token: 0x0401CC36 RID: 117814
		public static readonly EUiTabViewName MotorcycleTechTreeTabView = new EUiTabViewName("MotorcycleTechTreeTabView");

		// Token: 0x0401CC37 RID: 117815
		public static readonly EUiTabViewName MotorcycleTaskTabView = new EUiTabViewName("MotorcycleTaskTabView");

		// Token: 0x0401CC38 RID: 117816
		public static readonly EUiTabViewName MotorcycleDiyMainView = new EUiTabViewName("MotorcycleDiyMainView");

		// Token: 0x0401CC39 RID: 117817
		public static readonly EUiTabViewName MotorcycleDiyFrameTabView = new EUiTabViewName("MotorcycleDiyFrameTabView");

		// Token: 0x0401CC3A RID: 117818
		public static readonly EUiTabViewName MotorcycleDiyStickerTabView = new EUiTabViewName("MotorcycleDiyStickerTabView");

		// Token: 0x0401CC3B RID: 117819
		public static readonly EUiTabViewName MotorcycleDiyDecorationTabView = new EUiTabViewName("MotorcycleDiyDecorationTabView");

		// Token: 0x0401CC3C RID: 117820
		public static readonly EUiTabViewName MotorcycleDiyEditFrameTabView = new EUiTabViewName("MotorcycleDiyEditFrameTabView");

		// Token: 0x0401CC3D RID: 117821
		public static readonly EUiTabViewName MotorcycleDiyEditStickerTabView = new EUiTabViewName("MotorcycleDiyEditStickerTabView");

		// Token: 0x0401CC3E RID: 117822
		public static readonly EUiTabViewName MotorcycleDiyEditDecorationTabView = new EUiTabViewName("MotorcycleDiyEditDecorationTabView");

		// Token: 0x0401CC3F RID: 117823
		public static readonly EUiTabViewName PinballRoleAttributeTabView = new EUiTabViewName("PinballRoleAttributeTabView");

		// Token: 0x0401CC40 RID: 117824
		public static readonly EUiTabViewName PinballRoleWeaponTabView = new EUiTabViewName("PinballRoleWeaponTabView");

		// Token: 0x0401CC41 RID: 117825
		public static readonly EUiTabViewName RegressBpTaskTabView = new EUiTabViewName("RegressBpTaskTabView");

		// Token: 0x0401CC42 RID: 117826
		public static readonly EUiTabViewName RegressBpRewardTabView = new EUiTabViewName("RegressBpRewardTabView");

		// Token: 0x0401CC43 RID: 117827
		public static readonly EUiTabViewName KurotatoRoleOverviewTabView = new EUiTabViewName("KurotatoRoleOverviewTabView");

		// Token: 0x0401CC44 RID: 117828
		public static readonly EUiTabViewName KurotatoWeaponOverviewTabView = new EUiTabViewName("KurotatoWeaponOverviewTabView");

		// Token: 0x0401CC45 RID: 117829
		public static readonly EUiTabViewName KurotatoHandBookWeaponTabView = new EUiTabViewName("KurotatoHandBookWeaponTabView");

		// Token: 0x0401CC46 RID: 117830
		public static readonly EUiTabViewName KurotatoHandBookRoleTabView = new EUiTabViewName("KurotatoHandBookRoleTabView");

		// Token: 0x0401CC47 RID: 117831
		public static readonly EUiTabViewName RoverlikeDetailRoleTabView = new EUiTabViewName("RoverlikeDetailRoleTabView");

		// Token: 0x0401CC48 RID: 117832
		public static readonly EUiTabViewName RoverlikeDetailBlessTabView = new EUiTabViewName("RoverlikeDetailBlessTabView");

		// Token: 0x0401CC49 RID: 117833
		public static readonly EUiTabViewName RoverlikeDetailEnhanceTabView = new EUiTabViewName("RoverlikeDetailEnhanceTabView");

		// Token: 0x0401CC4A RID: 117834
		public static readonly EUiTabViewName RoverlikeOutsideBlessTabView = new EUiTabViewName("RoverlikeOutsideBlessTabView");

		// Token: 0x0401CC4B RID: 117835
		public static readonly EUiTabViewName RoverlikeOutsideEnhanceTabView = new EUiTabViewName("RoverlikeOutsideEnhanceTabView");

		// Token: 0x0401CC4C RID: 117836
		public static readonly EUiTabViewName RoverlikeOutsidePropTabView = new EUiTabViewName("RoverlikeOutsidePropTabView");

		// Token: 0x0401CC4D RID: 117837
		public static readonly EUiTabViewName SheriffMainAnalysisCluePanel = new EUiTabViewName("SheriffMainAnalysisCluePanel");

		// Token: 0x0401CC4E RID: 117838
		public static readonly EUiTabViewName SheriffMainSelectCluePanel = new EUiTabViewName("SheriffMainSelectCluePanel");

		// Token: 0x0401CC4F RID: 117839
		public static readonly EUiTabViewName SheriffMainClueDetailPanel = new EUiTabViewName("SheriffMainClueDetailPanel");

		// Token: 0x0401CC50 RID: 117840
		public static readonly EUiTabViewName SheriffMainConclusionPanel = new EUiTabViewName("SheriffMainConclusionPanel");

		// Token: 0x0401CC51 RID: 117841
		public static readonly EUiTabViewName SheriffReportDetailItem = new EUiTabViewName("SheriffReportDetailItem");

		// Token: 0x0401CC52 RID: 117842
		public static readonly EUiTabViewName SheriffReportRecordItem = new EUiTabViewName("SheriffReportRecordItem");
	}
}
