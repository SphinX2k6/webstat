using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.BossRush;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.AdventureGuide.Views;
using CSharpScript.Game.Module.Inventory.Views;
using CSharpScript.Game.Module.Kurotato.View.HandBook;
using CSharpScript.Game.Module.Kurotato.View.Overview;
using CSharpScript.Game.Module.PayShop.MotorSkinTab;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.PhantomArena.Prepare.Collect;
using CSharpScript.Game.Module.PhantomArena.Prepare.Entrance;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.RoleUi.TabView;
using CSharpScript.Game.Module.Sheriff.View.Item;
using CSharpScript.Game.Module.Skin.Role.View;
using CSharpScript.Game.Module.Skin.Tab.Motor;
using CSharpScript.Game.Module.Skin.Tab.Role;
using CSharpScript.Game.Module.Skin.Tab.Weapon;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Manager
{
	// Token: 0x020069F7 RID: 27127
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiTabViewManager : Singleton<UiTabViewManager>
	{
		// Token: 0x0604336E RID: 275310 RVA: 0x0114675E File Offset: 0x0114495E
		public void Init()
		{
			Singleton<UiTabViewStorage>.Instance.AddUiTabViewBase(this.Cache);
		}

		// Token: 0x04025794 RID: 153492
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		private readonly ValueTuple<EUiTabViewName, Type, string>[] Cache = new ValueTuple<EUiTabViewName, Type, string>[]
		{
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleAttributeTabView, typeof(RoleAttributeTabView), "UiTabView_RoleAttribute_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleSkillTabView, typeof(RoleSkillTreeView), "UiTabView_RoleSkillTree_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleWeaponTabView, typeof(RoleWeaponTabView), "UiTabView_RoleWeapon_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleFavorTabView, typeof(RoleFavorTabView), "UiView_Tab_RoleDangan_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RolePreviewAttributeTabView, typeof(RolePreviewAttributeTabView), "UiTabView_RoleAttributePreview_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.WeaponLevelUpView, typeof(WeaponLevelUpView), "UiTabView_WeaponLevelUp_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.WeaponBreachView, typeof(WeaponBreachView), "UiTabView_WeaponBreach_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.WeaponResonanceView, typeof(WeaponResonanceView), "UiTabView_WeaponResonance_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RolePhantomTabView, typeof(RoleVisionTabView), "UiItem_VisionIMain_New"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PayShopGiftBagView, typeof(DiscountShopView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueShopTabView, typeof(RogueShopTabView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BabelTowerShopTabView, typeof(BabelTowerShopTabView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PayItemTabView, typeof(PayShopRechargeView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PayShopRecommendView, typeof(PayShopRecommendView), "UiItem_ExchangeSkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PayShopExchangeEntryView, typeof(DiscountShopView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PayPackageShopView, typeof(PayPackageShopView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PayShopSkinView, typeof(PayShopSkinView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleShopSkinTabView, typeof(RoleShopSkinTabView), "UiItem_ShopSkinList"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleShopOrnamentTabView, typeof(RoleShopOrnamentTabView), "UiItem_ShopSkinList"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.ShopFlySkinTabView, typeof(ShopFlySkinTabView), "UiItem_ShopSkinList"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PayShopNewPlayerView, typeof(PayShopNewPlayerView), "UiItem_Exchange1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RolePreviewDescribeTabView, typeof(RolePreviewDescribeTabView), "UiTabView_RoleDescribe_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RolePreviewSkillTabView, typeof(RolePreviewSkillTabView), "UiTabView_RoleSkill_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RolePreviewResonanceTabView, typeof(RolePreviewResonanceTabView), "UiTabView_RoleResonance_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MonthCardView, typeof(MonthCardView), "UiItem_MonthlyCard_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.WeekCardView, typeof(WeekCardView), "UiItem_WeeklyCardStore"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.NewPlayerWeekCardView, typeof(WeekCardView), "UiItem_WeeklyCardStore"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleSkinRecommendView, typeof(RoleSkinRecommendView), "UiItem_ShopSkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorSkinRecommendView, typeof(MotorSkinRecommendView), "UiItem_ShopSkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleResonanceTabNewView, typeof(ResonanceChainView), "UiTabView_RoleResonance_New_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleHandBookPreviewView, typeof(RoleHandBookPreviewView), "UiTabView_RoleDescribe_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdventureTargetView, typeof(AdventureTargetView), "UiView_Completion"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MonsterDetectView, typeof(MonsterDetectView), "UiView_Survey"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.DisposableChallengeView, typeof(NewSoundAreaView), "UiView_NewSoundArea"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.NewSoundAreaView, typeof(NewSoundAreaView), "UiView_NewSoundArea"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.DailyActivityTabView, typeof(DailyActivityView), "UiItem_Active"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PeriodicityChallengeView, typeof(PeriodicityChallengeView), "UiItem_DevelopmentPeriodPage"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.VisionLevelUpView, typeof(VisionLevelUpView), "UiView_VisionLevelUp"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.VisionIdentifyView, typeof(VisionIdentifyView), "UiView_VisionIdentify"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.CalabashLevelUpTabView, typeof(CalabashLevelUpTabView), "UiItem_VisionUpgrade"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.CalabashCollectTabView, typeof(CalabashCollectTabView), "UiItem_VisionlMap"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomBattleFettersTabView, typeof(PhantomBattleFettersTabView), "UiItem_VisionFetter"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.VisionRecoveryTabView, typeof(VisionRecoveryTabView), "UiView_VisionRecovery"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.VisionRefineTabView, typeof(VisionRefineTabView), "UiView_VisionRefining"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomManageConfigView, typeof(PhantomManageConfigView), "UiView_Inventory_EchoPlanSet_Prefab"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomManageConfigNewView, typeof(PhantomManagerConfigNewView), "UiView_Inventory_EchoPlanSet_CostSet"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.WeaponSkinTabView, typeof(WeaponSkinTabView), "UiItem_RoleWeaponSkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleSkinTabView, typeof(RoleSkinTabView), "UiItem_RoleSkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.FlySkinTabView, typeof(FlySkinTabView), "UiItem_FlySkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.CalabashSkinTabView, typeof(CalabashSkinTabView), "UiItem_RoleDataDockSkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoleOrnamentTabView, typeof(RoleOrnamentTabView), "UiItem_RoleAccessoriesSkin"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BattlePassRewardView, typeof(BattlePassRewardView), "UiItem_BattlePassReward"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BattlePassTaskView, typeof(BattlePassTaskView), "UiItem_BattlePassMission"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BattlePassWeaponView, typeof(BattlePassWeaponView), "UiItem_WeaponPreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BossRushBuffSelectView, typeof(BossRushBuffSelectView), "UiItem_BossRushEntryCard"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BossRushLevelDetailView, typeof(BossRushLevelDetailView), "UiItem_BossrushLevelInfo"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BossRushSelectView, typeof(BossRushSelectView), "UiItem_BossrushSleLevel"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.BossRushRewardView, typeof(BossRushRewardView), "UiItem_BossrushReward"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RewardTargetTabView, typeof(RewardTargetTabView), "UiItem_ShopMission"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RewardShopTabView, typeof(RewardShopTabView), "MoonChasing_UiItem_ShopItem"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.DockyardSellTabView, typeof(DockyardSellTabView), "UiItem_ShopSell"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.DockyardBuyTabView, typeof(DockyardBuyTabView), "UiItem_ShopList"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.FishingNormalTechView, typeof(FishingNormalTechView), "UiItem_NavigationUpgradeSkill"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.FishingRoleTechView, typeof(FishingRoleTechView), "UiItem_RoleUpgrade"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.FishingTimeLimitRewardTabView, typeof(FishingTimeLimitRewardTabView), "UiItem_LimitTimeReward"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.FishingTimeLimitShopTabView, typeof(FishingTimeLimitShopTabView), "UiItem_LimitTimeShop"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueIllustratedTokenTabView, typeof(RogueIllustratedTokenTabView), "UiItem_IllustratedTokenItem"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueIllustratedEventTabView, typeof(RogueIllustratedEventTabView), "UiItem_RogueHandbook"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueBattleMapSummaryTeamTabView, typeof(RogueBattleMapSummaryTeamTabView), "UiItem_RogueTeamView"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueBattleMapSummaryFettersTabView, typeof(RogueBattleMapSummaryFettersTabView), "UiItem_RogueFettersBuff"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueBattleSummaryTeamTabView, typeof(RogueBattleSummaryTeamTabView), "UiItem_RogueRoleInfo"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueBattleMapSummaryGridEffectTabView, typeof(RogueBattleMapSummaryGridEffectTabView), "UiItem_BattleAddtionView"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RogueBattleSummaryTokenTabView, typeof(RogueBattleSummaryTokenTabView), "UiItem_RogueTokenInfo"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SurvivorsRoleTabView, typeof(SurvivorsRoleTabView), "UiView_SurvivorsHandbookRole"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SurvivorsItemTabView, typeof(SurvivorsItemTabView), "UiView_SurvivorsHandbookItem"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SurvivorsWeaponTabView, typeof(SurvivorsWeaponTabView), "UiView_SurvivorsHandbookWeapon"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomArenaCollectCardTabView, typeof(PhantomArenaCollectCardTabView), "UiItem_SoundRemnantArenaCollectCard"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomArenaCollectCardTabViewNew, typeof(PhantomArenaCollectCardTabView), "UiItem_SoundRemnantArenaCollectCardNew"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomArenaCollectBadgeTabView, typeof(PhantomArenaCollectBadgeTabView), "UiItem_SoundRemnantArenaCollectBadge"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomArenaEntranceTaskTabView, typeof(PhantomArenaEntranceTaskTabView), "UiItem_SoundRemnantArenaMission"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PhantomArenaEntranceShopTabView, typeof(PhantomArenaEntranceShopTabView), "UiItem_SoundRemnantArenaShop"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.HonamiStoryEquipTabView, typeof(HonamiStoryEquipTabView), "UiItem_HonamiStoryBackpack"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdvanceNoticeNewRoleTabView, typeof(AdvanceNoticeNewRoleTabView), "UiItem_RolePreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdvanceNoticeNewJourneyTabView, typeof(AdvanceNoticeNewJourneyTabView), "UiItem_JourneyPreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdvanceNoticeNewAreaTabView, typeof(AdvanceNoticeNewAreaTabView), "UiItem_MapPreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdvanceNoticeNewSkinTabView, typeof(AdvanceNoticeNewSkinTabView), "UiItem_BusinessPreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdvanceNoticeNewEnemyTabView, typeof(AdvanceNoticeNewEnemyTabView), "UiItem_MonsterPreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdvanceNoticeNewActivityTabView, typeof(AdvanceNoticeNewActivityTabView), "UiItem_ActivityPreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.AdvanceNoticeNewSystemOptimizeTabView, typeof(AdvanceNoticeNewSystemOptimizeTabView), "UiItem_OptimizePreview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleLevelInfoTabView, typeof(MotorcycleLevelInfoTabView), "UiView_MotorcycleDevelopment"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleTechTreeTabView, typeof(MotorcycleTechTreeTabView), "UiView_MotorcycleTechTree"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleTaskTabView, typeof(MotorcycleTaskTabView), "UiView_MotorcycleTask"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleDiyMainView, typeof(MotorcycleDiyMainView), "UiView_MotorcycleDiy"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleDiyFrameTabView, typeof(MotorcycleDiyFrameTabView), "UiView_MotorcycleDiyFrame"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleDiyStickerTabView, typeof(MotorcycleDiyStickerTabView), "UiView_MotorcycleDiySticker"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleDiyDecorationTabView, typeof(MotorcycleDiyDecorationTabView), "UiView_MotorcycleDiySticker"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleDiyEditFrameTabView, typeof(MotorcycleDiyEditFrameTabView), "UiView_MotorcycleDiyFrame"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleDiyEditStickerTabView, typeof(MotorcycleDiyEditStickerTabView), "UiView_MotorcycleDiySticker"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorcycleDiyEditDecorationTabView, typeof(MotorcycleDiyEditDecorationTabView), "UiView_MotorcycleDiySticker"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.MotorSkinTabView, typeof(MotorSkinTabView), "UiItem_ShopMotoList"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PinballRoleAttributeTabView, typeof(PinballRoleAttributeTabView), "UiItem_RoleAttribute"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.PinballRoleWeaponTabView, typeof(PinballRoleWeaponTabView), "UiItem_WeaponAttribute"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.KurotatoRoleOverviewTabView, typeof(KurotatoRoleOverviewTabView), "UiItem_KurotatoRoleOverview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.KurotatoWeaponOverviewTabView, typeof(KurotatoWeaponOverviewTabView), "UiItem_KurotatoWeaponOverview"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.KurotatoHandBookRoleTabView, typeof(KurotatoHandBookRoleTabView), "UiItem_SurvivorSelectRoleOffset"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.KurotatoHandBookWeaponTabView, typeof(KurotatoHandBookWeaponTabView), "UiItem_SurvivorPageProp"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RegressBpTaskTabView, typeof(RegressBpTaskTabView), "UiItem_CircumfluenceMissionList"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RegressBpRewardTabView, typeof(RegressBpRewardTabView), "UiItem_CircumfluenceCertificate"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SheriffMainAnalysisCluePanel, typeof(SheriffMainAnalysisCluePanel), "UiItem_AnalysisClue"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SheriffMainSelectCluePanel, typeof(SheriffMainSelectCluePanel), "UiItem_SelectClue"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SheriffMainClueDetailPanel, typeof(SheriffMainClueDetailPanel), "UiItem_ClueItemDetail"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SheriffMainConclusionPanel, typeof(SheriffMainConclusionPanel), "UiItem_SkyEyeConclusion"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SheriffReportDetailItem, typeof(SheriffReportDetailItem), "UiItem_SkyEyeEventDetail"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.SheriffReportRecordItem, typeof(SheriffReportRecordItem), "UiItem_SkyEyeRecord"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoverlikeDetailRoleTabView, typeof(RoverlikeDetailRoleTabView), "UiItem_Rogue36RoleInfo"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoverlikeDetailBlessTabView, typeof(RoverlikeDetailBlessTabView), "UiItem_RugueCollect"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoverlikeDetailEnhanceTabView, typeof(RoverlikeDetailEnhanceTabView), "UiItem_RugueCollect"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoverlikeOutsideBlessTabView, typeof(RoverlikeOutsideBlessTabView), "UiItem_RugueOutSideCollect"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoverlikeOutsideEnhanceTabView, typeof(RoverlikeOutsideEnhanceTabView), "UiItem_RugueOutSideCollect1"),
			new ValueTuple<EUiTabViewName, Type, string>(EUiTabViewName.RoverlikeOutsidePropTabView, typeof(RoverlikeOutsidePropTabView), "UiItem_RugueOutSideCollect1")
		};
	}
}
