using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Module.Activity.ActivityContent.FunPlay;
using CSharpScript.Game.Module.Activity.ActivityContent.LineCross;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.RedDot.RedDots.ComposeSystem;
using CSharpScript.Game.RedDot.RedDots.CookSystem;

// Token: 0x020032CF RID: 13007
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RedDotModel : ModelBase<RedDotModel>
{
	// Token: 0x0601B497 RID: 111767 RVA: 0x008319A0 File Offset: 0x0082FBA0
	protected override bool OnInit()
	{
		this.Add(ERedDotName.Test, new RedDotTest());
		this.Add(ERedDotName.BattleViewMenu, new RedDotBattleViewMenu());
		this.Add(ERedDotName.BattleViewResonanceButton, new RedDotBattleViewResonanceButton());
		this.Add(ERedDotName.BattleViewShopButton, new RedDotBattleViewShopButton());
		this.Add(ERedDotName.BattleViewGachaButton, new RedDotBattleViewGachaButton());
		this.Add(ERedDotName.MailFilterAll, new RedDotMailBoxFilter());
		this.Add(ERedDotName.FilterImportant, new RedDotMailBoxImportantFilter());
		this.Add(ERedDotName.FilterUnScanned, new RedDotMailBoxUnScannedFilter());
		this.Add(ERedDotName.RoleSystemRoleList, new RedDotRoleSystemRoleList());
		this.Add(ERedDotName.RoleAttributeTab, new RedDotAttributeTab());
		this.Add(ERedDotName.RoleAttributeTabLevelUp, new RedDotRoleLevelUp());
		this.Add(ERedDotName.RoleSkin, new RedDotRoleSkin());
		this.Add(ERedDotName.RoleChange, new RedDotRoleChange());
		this.Add(ERedDotName.FlySkinTab, new RedDotFlySkinTab());
		this.Add(ERedDotName.FlySkinChildTab, new RedDotFlySkinChildTab());
		this.Add(ERedDotName.HuluSkinTab, new RedDotHuluSkinTab());
		this.Add(ERedDotName.RoleOrnamentTab, new RedDotRoleOrnamentTab());
		this.Add(ERedDotName.RoleAttributeTabBreakUp, new RedDotRoleBreakUp());
		this.Add(ERedDotName.RoleWeaponTabBreakUp, new RedDotRoleWeaponBreakUp());
		this.Add(ERedDotName.RoleFavorTab, new RedDotRoleFavorTab());
		this.Add(ERedDotName.RoleResonanceTab, new RedDotResonanceTab());
		this.Add(ERedDotName.FunctionRole, new RedDotFunctionRole());
		this.Add(ERedDotName.FunctionPhantom, new RedDotFunctionPhantom());
		this.Add(ERedDotName.FunctionGacha, new RedDotBattleViewGachaButton());
		this.Add(ERedDotName.FunctionTutorial, new RedDotFunctionTutorial());
		this.Add(ERedDotName.FunctionAdventure, new RedDotFunctionAdventureGuide());
		this.Add(ERedDotName.FunctionInventory, new RedDotFunctionInventory());
		this.Add(ERedDotName.FunctionMail, new RedDotFunctionMail());
		this.Add(ERedDotName.FunctionNotice, new RedDotFunctionNotice());
		this.Add(ERedDotName.FunctionPayShop, new RedDotFunctionPayShop());
		this.Add(ERedDotName.FunctionPhantomExploreSet, new RedDotFunctionPhantomExploreSet());
		this.Add(ERedDotName.FunctionPhotograph, new RedDotFunctionPhotograph());
		this.Add(ERedDotName.RedDotPhotoSetup, new RedDotPhotoSetup());
		this.Add(ERedDotName.FunctionSetting, new RedDotFunctionSetting());
		this.Add(ERedDotName.AdventureManual, new RedDotAdventureManual());
		this.Add(ERedDotName.AdventureBattleButton, new RedDotAdventureBattleButtonItem());
		this.Add(ERedDotName.AdventureFirstAward, new RedDotAdventureFirstAward());
		this.Add(ERedDotName.AdventureFirstAwardCategory, new RedDotAdventureFirstAwardCategory());
		this.Add(ERedDotName.AdventureFirstAwardResult, new RedDotAdventureFirstAwardResult());
		this.Add(ERedDotName.AdventureDailyActivityTab, new RedDotAdventureDailyActivityTab());
		this.Add(ERedDotName.AdventureDailyActivityTabDaily, new RedDotAdventureDailyActivityTabDaily());
		this.Add(ERedDotName.AdventureDailyActivityTabWeekly, new RedDotAdventureDailyActivityTabWeekly());
		this.Add(ERedDotName.AdventureNewSoundAreaTab, new RedDotAdventureNewSoundAreaTab());
		this.Add(ERedDotName.AdventureChallengeTab, new RedDotAdventureChallengeTab());
		this.Add(ERedDotName.AdventurePeriodicityTab, new AdventurePeriodicityTab());
		this.Add(ERedDotName.AdventureNewSoundAreaGeneral, new RedDotAdventureNewSoundAreaGeneral());
		this.Add(ERedDotName.FunctionCalabash, new RedDotCalabashUpdate());
		this.Add(ERedDotName.CalabashTab, new RedDotCalabashTab());
		this.Add(ERedDotName.VisionRecovery, new RedDotVisionRecovery());
		this.Add(ERedDotName.VisionRefine, new RedDotVisionRefine());
		this.Add(ERedDotName.FunctionFriend, new RedDotFunctionFriend());
		this.Add(ERedDotName.FriendNewApplication, new RedDotFriendNewApplication());
		this.Add(ERedDotName.ChatView, new RedDotChatView());
		this.Add(ERedDotName.ChatRoom, new RedDotChatRoom());
		this.Add(ERedDotName.TutorialTypeNew, new RedDotTutorialType());
		this.Add(ERedDotName.RoleSelectionList, new RedDotRoleSelectionList());
		this.Add(ERedDotName.InfluenceReputation, new RedDotInfluenceReputation());
		this.Add(ERedDotName.InfluenceReward, new RedDotInfluenceReward());
		this.Add(ERedDotName.CookerLevel, new RedDotCookerLevel());
		this.Add(ERedDotName.CookerLevelMain, new RedDotCookerLevel());
		this.Add(ERedDotName.BattlePass, new RedDotBattlePass());
		this.Add(ERedDotName.BattlePassTask, new RedDotBattlePassTask());
		this.Add(ERedDotName.BattlePassReward, new RedDotBattlePassReward());
		this.Add(ERedDotName.BattlePassDayTaskTab, new RedDotBattlePassDayTaskTab());
		this.Add(ERedDotName.BattlePassWeekTaskTab, new RedDotBattlePassWeekTaskTab());
		this.Add(ERedDotName.BattlePassAlwaysTaskTab, new RedDotBattlePassAlwaysTaskTab());
		this.Add(ERedDotName.RoleHandBook, new RedDotRoleHandBook());
		this.Add(ERedDotName.ComposeReagentProduction, new RedDotComposeLevel());
		this.Add(ERedDotName.ItemHandBook, new RedDotItemHandBook());
		this.Add(ERedDotName.PhantomHandBook, new RedDotPhantomHandBook());
		this.Add(ERedDotName.Achievement, new RedDotAchievement());
		this.Add(ERedDotName.AchievementCategory, new RedDotAchievementCategory());
		this.Add(ERedDotName.ActivityEntrance, new RedDotActivityEntrance());
		this.Add(ERedDotName.CommonActivityPage, new RedDotCommonActivityPage());
		this.Add(ERedDotName.ActivityRun, new RedDotActivityRun());
		this.Add(ERedDotName.BattleViewQuestButton, new RedDotBattleViewQuestBtn());
		this.Add(ERedDotName.QuestViewItem, new RedDotQuestViewItem());
		this.Add(ERedDotName.QuestTab, new RedDotQuestViewTab());
		this.Add(ERedDotName.FunctionViewQuestBtn, new RedDotFunctionViewQuestBtn());
		this.Add(ERedDotName.InventoryVirtual, new RedDotInventoryVirtual());
		this.Add(ERedDotName.InventoryCommon, new RedDotInventoryCommon());
		this.Add(ERedDotName.InventoryWeapon, new RedDotInventoryWeapon());
		this.Add(ERedDotName.InventoryPhantom, new RedDotInventoryPhantom());
		this.Add(ERedDotName.InventoryCollection, new RedDotInventoryCollection());
		this.Add(ERedDotName.InventoryMaterial, new RedDotInventoryMaterial());
		this.Add(ERedDotName.InventoryMission, new RedDotInventoryMissionItem());
		this.Add(ERedDotName.InventorySpecial, new RedDotInventorySpecialItem());
		this.Add(ERedDotName.InventoryCard, new RedDotInventoryCard());
		this.Add(ERedDotName.TowerReward, new RedDotTowerReward());
		this.Add(ERedDotName.TowerRewardByDifficulties, new RedDotTowerRewardByDifficulties());
		this.Add(ERedDotName.VisionIdentifyTab, new VisionIdentifyRedDot());
		this.Add(ERedDotName.VisionOneKeyEquip, new VisionOneKeyEquipRedDot());
		this.Add(ERedDotName.VisionTabRedDot, new VisionTabRedDot());
		this.Add(ERedDotName.VisionGridRedDot, new VisionGridRedDot());
		this.Add(ERedDotName.PayShopInstance, new PayShopInstanceRedDot());
		this.Add(ERedDotName.PayShopTab, new PayShopTabRedDot());
		this.Add(ERedDotName.RogueSkillUnlock, new RedDotRoguelikeSkillCanUnlock());
		this.Add(ERedDotName.RoguelikeAchievement, new RedDotRoguelikeAchievement());
		this.Add(ERedDotName.RoguelikeShop, new RedDotRoguelikeShop());
		this.Add(ERedDotName.RoguelikeAchievementGroup, new RedDotRoguelikeAchievementGroup());
		this.Add(ERedDotName.BossRushReward, new BossRushRewardRedDot());
		this.Add(ERedDotName.MowingTowerReward, new MowingTowerRewardRedDot());
		this.Add(ERedDotName.TowerDefenseReward, new TowerDefenseRewardRedDot());
		this.Add(ERedDotName.TowerDefenseInstance, new TowerDefenseInstanceRedDot());
		this.Add(ERedDotName.RedDotMowingRiskReward, new RedDotMowingRiskReward());
		this.Add(ERedDotName.RedDotMowingRiskBuffAll, new RedDotMowingRiskBuffAll());
		this.Add(ERedDotName.CustomerService, new CustomerServerRedDot());
		this.Add(ERedDotName.Introduction, new IntroductionRedDot());
		this.Add(ERedDotName.FragmentMemoryReward, new FragmentMemoryCollectRewardRedDot());
		this.Add(ERedDotName.FragmentMemoryEntrance, new FragmentMemoryEntranceRedDot());
		this.Add(ERedDotName.FragmentMemoryTopic, new FragmentMemoryTopicRedDot());
		this.Add(ERedDotName.FragmentMemoryTopicCollectRedDot, new FragmentMemoryTopicCollectRedDot());
		this.Add(ERedDotName.BattlePassPayButton, new RedDotBattlePassPayButton());
		this.Add(ERedDotName.PersonalizedInfo, new PersonalizeInfoRedDot());
		this.Add(ERedDotName.PersonalCard, new PersonalCardRedDot());
		this.Add(ERedDotName.PersonalTitle, new PersonalTitleRedDot());
		this.Add(ERedDotName.PersonalBirthday, new PersonalBirthdayRedDot());
		this.Add(ERedDotName.PersonalImageBook, new PersonalImageBookRedDot());
		this.Add(ERedDotName.ActivityRecallSignEntry, new RedDotActivityRecallSignEntryButton());
		this.Add(ERedDotName.ActivityRecallTaskEntry, new RedDotActivityRecallTaskEntryButton());
		this.Add(ERedDotName.ActivityRegressQuestionnaire, new RedDotActivityRegressQuestionnaire());
		this.Add(ERedDotName.ActivityRegressShopDiscount, new RedDotActivityRegressShopDiscount());
		this.Add(ERedDotName.ActivityRegressDoubleDrop, new RedDotActivityRegressDoubleDrop());
		this.Add(ERedDotName.ActivityRegressDisposableReward, new RedDotActivityRegressDisposableReward());
		this.Add(ERedDotName.ActivityRegressRecommend, new RedDotActivityRegressRecommend());
		this.Add(ERedDotName.ActivityRegressAdventure, new RedDotActivityRegressAdventure());
		this.Add(ERedDotName.ActivityRegressCultivate, new RedDotActivityRegressCultivate());
		this.Add(ERedDotName.ActivityRegressConstantTask, new RedDotActivityRegressConstantTask());
		this.Add(ERedDotName.ActivityRegressTrialRole, new RedDotActivityRegressTrialRole());
		this.Add(ERedDotName.ActivityRegressBp, new RedDotActivityRegressBp());
		this.Add(ERedDotName.ActivityRegressBpTask, new RedDotActivityRegressBpTask());
		this.Add(ERedDotName.ActivityRegressBpReward, new RedDotActivityRegressBpReward());
		this.Add(ERedDotName.ActivityRegressRewardBtn, new RedDotActivityRegressRewardBtn());
		this.Add(ERedDotName.VisionLevelUpSetting, new VisionLevelUpSettingRedDot());
		this.Add(ERedDotName.MoonChasingAllQuest, new RedDotMoonChasingAllQuest());
		this.Add(ERedDotName.MoonChasingBranchTab, new RedDotMoonChasingBranchTab());
		this.Add(ERedDotName.MoonChasingMainlineTab, new RedDotMoonChasingMainlineTab());
		this.Add(ERedDotName.MoonChasingHandbook, new RedDotMoonChasingHandbook());
		this.Add(ERedDotName.MoonChasingReward, new RedDotMoonChasingReward());
		this.Add(ERedDotName.MoonChasingShop, new RedDotMoonChasingShop());
		this.Add(ERedDotName.MoonChasingRewardAndShop, new RedDotMoonChasingRewardAndShop());
		this.Add(ERedDotName.MoonChasingDelegation, new RedDotMoonChasingDelegation());
		this.Add(ERedDotName.MoonChasingRole, new RedDotMoonChasingRole());
		this.Add(ERedDotName.MoonChasingBuilding, new RedDotMoonChasingBuilding());
		this.Add(ERedDotName.Spring25AllLetter, new RedDotSpring25AllLetter());
		this.Add(ERedDotName.Spring25Reward, new RedDotSpring25Reward());
		this.Add(ERedDotName.Spring25Invite, new RedDotSpring25Invite());
		this.Add(ERedDotName.Spring25Enter, new RedDotSpring25Enter());
		this.Add(ERedDotName.ActivityCorniceMeeting, new RedDotActivityCorniceMeeting());
		this.Add(ERedDotName.FunctionMailBind, new RedDotFunctionMailBind());
		this.Add(ERedDotName.FunctionKuroStreet, new RedDotFunctionKuroStreet());
		this.Add(ERedDotName.ActivityDirectTrainProEntry, new RedDotDirectTrainProEntry());
		this.Add(ERedDotName.FunctionMap, new RedDotFunctionMap());
		this.Add(ERedDotName.SheriffMap, new RedDotSheriff());
		this.Add(ERedDotName.MapAreaExplore, new RedDotMapAreaExplore());
		this.Add(ERedDotName.MapAreaBoxReward, new RedDotMapAreaBoxReward());
		this.Add(ERedDotName.FarmGoldReward, new FarmGoldRewardRedDot());
		this.Add(ERedDotName.FishingTech, new FishingTechRedDot());
		this.Add(ERedDotName.FishingNormalTechNode, new FishingNormalTechNodeRedDot());
		this.Add(ERedDotName.FishingRoleTechNode, new FishingRoleTechNodeRedDot());
		this.Add(ERedDotName.FishingRoleToggleTech, new FishingRoleToggleTechRedDot());
		this.Add(ERedDotName.FishingRoleTech, new FishingTechRoleRedDot());
		this.Add(ERedDotName.FishingNormalTech, new FishingTechNormalRedDot());
		this.Add(ERedDotName.ShipTower, new RedDotShipTower());
		this.Add(ERedDotName.ShipTowerReward, new RedDotShipTowerReward());
		this.Add(ERedDotName.PreDownload, new RedDotPreDownload());
		this.Add(ERedDotName.PreDownloadComplete, new RedDotPreDownloadComplete());
		this.Add(ERedDotName.InviteNewbie, new RedDotInviteNewbie());
		this.Add(ERedDotName.BabelTowerQuestRedDot, new BabelTowerQuestRedDot());
		this.Add(ERedDotName.BabelTowerNewLevelDifficulty, new BabelTowerDifficultyRedDot());
		this.Add(ERedDotName.BabelTowerNewLevel, new BabelTowerLevelRedDot());
		this.Add(ERedDotName.CiacconaProgressReward, new RedDotCiacconaProgressReward());
		this.Add(ERedDotName.CiacconaEndingReward, new RedDotCiacconaEndingReward());
		this.Add(ERedDotName.CiacconaSubEndingReward, new RedDotCiacconaSubEndingReward());
		this.Add(ERedDotName.RogueResIllustratedTokenTab, new RedDotRogueResIllustratedTokenTab());
		this.Add(ERedDotName.RogueResIllustratedNormalTab, new RedDotRogueResIllustratedNormal());
		this.Add(ERedDotName.RogueResIllustratedMapTab, new RedDotRogueResIllustratedMap());
		this.Add(ERedDotName.RogueResIllustrated, new RedDotRogueResIllustrated());
		this.Add(ERedDotName.RogueResTask, new RedDotRogueResTask());
		this.Add(ERedDotName.RogueResShop, new RedDotRogueResShop());
		this.Add(ERedDotName.RogueResInst, new RedDotRogueResInst());
		this.Add(ERedDotName.RogueResSkillTree, new RedDotRogueResSkillTree());
		this.Add(ERedDotName.RogueResEnding, new RedDotRogueResEnding());
		this.Add(ERedDotName.DangoMonopoly, new RedDotDangoMonopoly());
		this.Add(ERedDotName.DangoMonopolyTask, new RedDotDangoMonopolyTask());
		this.Add(ERedDotName.DangoMonopolyDiceNum, new RedDotDangoMonopolyDiceNum());
		this.Add(ERedDotName.DangoMonopolyRound, new RedDotDangoMonopolyRound());
		this.Add(ERedDotName.Morale, new RedDotMorale());
		this.Add(ERedDotName.MoraleScoreBox, new RedDotMoraleScoreBox());
		this.Add(ERedDotName.MoraleFlagBox, new RedDotMoraleFlagBox());
		this.Add(ERedDotName.MoraleBuff, new RedDotMoraleBuff());
		this.Add(ERedDotName.MoraleAreaBuff, new RedDotMoraleAreaBuff());
		this.Add(ERedDotName.TrapDefense, new RedDotTrapDefense());
		this.Add(ERedDotName.TrapDefenseMainLevel, new RedDotTrapDefenseMainLevel());
		this.Add(ERedDotName.TrapDefenseRougeLevel, new RedDotTrapDefenseRougeLevel());
		this.Add(ERedDotName.TrapDefenseFixedReward, new RedDotTrapDefenseFixedReward());
		this.Add(ERedDotName.TrapDefenseLimitReward, new RedDotTrapDefenseLimitReward());
		this.Add(ERedDotName.TrapDefenseTalentTree, new RedDotTrapDefenseTalentTree());
		this.Add(ERedDotName.TrapDefenseDevelopBranchAll, new RedDotTrapDefenseDevelopBranchAll());
		this.Add(ERedDotName.TrapDefenseDevelopBranchAuxiliary, new RedDotTrapDefenseDevelopBranchAuxiliary());
		this.Add(ERedDotName.TrapDefenseDevelopBranchBuilding, new RedDotTrapDefenseDevelopBranchBuilding());
		this.Add(ERedDotName.TrapDefenseBdSum, new RedDotTrapDefenseBdSum());
		this.Add(ERedDotName.TrapDefenseBdBuffNewUnlock, new RedDotTrapDefenseBdBuffNewUnlock());
		this.Add(ERedDotName.TrapDefenseLevelModeLevelReachOpenTime, new RedDotTrapDefenseLevelModeLevelReachOpenTime());
		this.Add(ERedDotName.TrapDefenseRougeModeLevelReachOpenTime, new RedDotTrapDefenseRougeModeLevelReachOpenTime());
		this.Add(ERedDotName.TrapDefenseRougeModeOpen, new RedDotTrapDefenseRougeModeOpen());
		this.Add(ERedDotName.RedDotDangoCommonReward, new RedDotDangoCommonReward());
		this.Add(ERedDotName.RedDotDangoLimitReward, new RedDotDangoLimitReward());
		this.Add(ERedDotName.RedDotDangoPayShop, new RedDotDangoPayShop());
		this.Add(ERedDotName.RedDotDangoDevelop, new RedDotDangoDevelop());
		this.Add(ERedDotName.RedDotDangoRole, new RedDotDangoRole());
		this.Add(ERedDotName.RedDotDangoFormation, new RedDotDangoFormation());
		this.Add(ERedDotName.RedDotDangoFormationRole, new RedDotDangoFormationRole());
		this.Add(ERedDotName.RedDotVersionCheck, new RedDotVersionCheck());
		this.Add(ERedDotName.RedDotRacingBetsActivityReward, new RedDotRacingBetsActivityReward());
		this.Add(ERedDotName.RedDotRacingBetsActivityInternalReward, new RedDotRacingBetsActivityInternalReward());
		this.Add(ERedDotName.CumulativeShopTaskTabRedDot, new CumulativeShopTaskTabRedDot());
		this.Add(ERedDotName.RedDotPhantomArenaLimitReward, new RedDotPhantomArenaLimitReward());
		this.Add(ERedDotName.RedDotPhantomArenaTaskReward, new RedDotPhantomArenaTaskReward());
		this.Add(ERedDotName.RedDotPhantomArenaShopUpdate, new RedDotPhantomArenaShopUpdate());
		this.Add(ERedDotName.RedDotPhantomArenaCardReward, new RedDotPhantomArenaCardReward());
		this.Add(ERedDotName.RedDotPhantomArenaCollect, new RedDotPhantomArenaCollect());
		this.Add(ERedDotName.RedDotPhantomArenaRole, new RedDotPhantomArenaRole());
		this.Add(ERedDotName.RedDotPhantomArenaBadgeReward, new RedDotPhantomArenaBadgeReward());
		this.Add(ERedDotName.RedDotPhantomArenaLevelReward, new RedDotPhantomArenaLevelReward());
		this.Add(ERedDotName.RedDotPhantomArenaGym, new RedDotPhantomArenaGym());
		this.Add(ERedDotName.RedDotPhantomArenaActivity, new RedDotPhantomArenaActivity());
		this.Add(ERedDotName.BeginnerCarnivalTaskTabRedDot, new BeginnerCarnivalTaskTabRedDot());
		this.Add(ERedDotName.LifePointDrawChallengeRedDot, new LifePointDrawChallengeRedDot());
		this.Add(ERedDotName.LifePointDrawGroupRedDot, new LifePointDrawGroupRedDot());
		this.Add(ERedDotName.ActivityFunPlay, new RedDotActivityFunPlay());
		this.Add(ERedDotName.LineCrossChallengeRedDot, new LineCrossChallengeRedDot());
		this.Add(ERedDotName.LineCrossGroupRedDot, new LineCrossGroupRedDot());
		this.Add(ERedDotName.RedDotWeaponResonanceTab, new RedDotWeaponResonanceTab());
		this.Add(ERedDotName.FunctionPhoneMsg, new RedDotPhoneMsgEntrance());
		this.Add(ERedDotName.FunctionWeatherCentral, new RedDotWeatherCentral());
		this.Add(ERedDotName.FunctionMotorDevelop, new RedDotMotorcycleDevelop());
		this.Add(ERedDotName.InfrShop, new RedDotInfrShop());
		this.Add(ERedDotName.InfrLimitedTask, new RedDotInfrLimitedTask());
		this.Add(ERedDotName.InfrArchive, new RedDotInfrArchive());
		this.Add(ERedDotName.Infrastructure, new RedDotInfrastructure());
		this.Add(ERedDotName.VillageInfrTask, new RedDotVillageInfrTask());
		this.Add(ERedDotName.VillageInfr, new RedDotVillageInfr());
		this.Add(ERedDotName.RedDotTrialRoleGroup, new RedDotTrialRoleGroup());
		this.Add(ERedDotName.RedDotNewPlayerSupportTrialRoleEntrance, new RedDotNewPlayerSupportTrialRoleEntrance());
		this.Add(ERedDotName.RedDotNewPlayerSupportAdventure, new RedDotNewPlayerSupportAdventure());
		this.Add(ERedDotName.PhoneMsgChatItemRedDot, new RedDotPhoneMsgChatItem());
		this.Add(ERedDotName.PhoneMsgChatPartnerRedDot, new RedDotPhoneMsgChatPartner());
		this.Add(ERedDotName.PhoneMsgChatPartnerRedDotGiftIcon, new RedDotPhoneMsgChatPartnerGiftIcon());
		this.Add(ERedDotName.RedDotPhantomInteractUnlock, new RedDotPhantomInteractUnlock());
		this.Add(ERedDotName.RedDotPhantomInteractEditEntry, new RedDotPhantomInteractEditEntry());
		this.Add(ERedDotName.RedDotPhantomInteractRouletteGrid, new RedDotPhantomInteractRouletteGrid());
		this.Add(ERedDotName.MotorcycleLevelTab, new RedDotMotorcycleLevelTab());
		this.Add(ERedDotName.MotorcycleTechTreeTab, new RedDotMotorcycleTechTreeTab());
		this.Add(ERedDotName.MotorcycleTreeTypeTechTab, new RedDotMotorcycleTreeTypeTechTab());
		this.Add(ERedDotName.MotorcycleTreeTypeTechTabNew, new RedDotMotorcycleTreeTypeTechTabNew());
		this.Add(ERedDotName.MotorcycleTreeTypeTaskTab, new RedDotMotorcycleTreeTypeTaskTab());
		this.Add(ERedDotName.MotorcycleTaskTab, new RedDotMotorcycleTaskTab());
		this.Add(ERedDotName.MotorcycleDiyTab, new RedDotMotorcycleDiyTab());
		this.Add(ERedDotName.MotorcycleDiyFrameTab, new RedDotMotorcycleDiyFrameTab());
		this.Add(ERedDotName.MotorcycleDiyStickerTab, new RedDotMotorcycleDiyStickerTab());
		this.Add(ERedDotName.MotorcycleDiyStickerPartTab, new RedDotMotorcycleDiyStickerPartTab());
		this.Add(ERedDotName.MotorcycleDiyDecorationTab, new RedDotMotorcycleDiyDecorationTab());
		this.Add(ERedDotName.MotorcycleDiyDecorationPartTab, new RedDotMotorcycleDiyDecorationPartTab());
		this.Add(ERedDotName.MotorcycleSceneButtonRedDot, new RedDotMotorcycleSceneButtonRedDot());
		this.Add(ERedDotName.MotorcycleDiyFramePreTab, new RedDotMotorcycleDiyFramePreTab());
		this.Add(ERedDotName.MotorcycleDiyStickerPreTab, new RedDotMotorcycleDiyStickerPreTab());
		this.Add(ERedDotName.MotorcycleDiyStickerPrePartTab, new RedDotMotorcycleDiyStickerPrePartTab());
		this.Add(ERedDotName.MotorcycleDiyDecorationPreTab, new RedDotMotorcycleDiyDecorationPreTab());
		this.Add(ERedDotName.MotorcycleDiyDecorationPrePartTab, new RedDotMotorcycleDiyDecorationPrePartTab());
		this.Add(ERedDotName.SpringManorGameEntrance, new RedDotSpringManorGameEntrance());
		this.Add(ERedDotName.DrinksUnlockLevel, new RedDotDrinksUnlockLevel());
		this.Add(ERedDotName.GuessJokerUnlockLevel, new RedDotGuessJokerUnlockLevel());
		this.Add(ERedDotName.SpringManorAlbumReward, new RedDotSpringManorAlbumReward());
		this.Add(ERedDotName.SpringManorBrochureReward, new RedDotSpringManorBrochureReward());
		this.Add(ERedDotName.RedDotFlagChallengeActivityReward, new RedDotFlagChallengeActivityReward());
		this.Add(ERedDotName.RedDotFlagChallengeActivityLevelNewlyUnlocked, new RedDotFlagChallengeActivityLevelNewlyUnlocked());
		this.Add(ERedDotName.RedDotFlagChallengeActivityBuffNewlyUnlocked, new RedDotFlagChallengeActivityBuffNewlyUnlocked());
		this.Add(ERedDotName.RedDotFlagChallengeActivityBuffItemNewlyUnlocked, new RedDotFlagChallengeActivityBuffItemNewlyUnlocked());
		this.Add(ERedDotName.RedDotFlagChallengeBattleBuffNewlyUnlocked, new RedDotFlagChallengeBattleBuffNewlyUnlocked());
		this.Add(ERedDotName.FurnitureEntranceRedDot, new RedDotFurnitureEntrance());
		this.Add(ERedDotName.RhythmShipTask, new RedDotRhythmShipTask());
		this.Add(ERedDotName.RhythmShipTimeLimitTask, new RedDotRhythmShipTimeLimitTask());
		this.Add(ERedDotName.RhythmShipTaskTab, new RedDotRhythmShipTaskTab());
		this.Add(ERedDotName.RedDotCyberPunkTask, new RedDotCyberPunkTask());
		this.Add(ERedDotName.RedDotCyberPunkTaskTab, new RedDotCyberPunkTaskTab());
		this.Add(ERedDotName.RedDotCyberPunkTrialRole, new RedDotCyberPunkTrialRole());
		this.Add(ERedDotName.RedDotCyberPunkBoss, new RedDotCyberPunkBoss());
		this.Add(ERedDotName.RedDotCyberPunkReward, new RedDotCyberPunkReward());
		this.Add(ERedDotName.BossPilingReward, new RedDotBossPilingReward());
		this.Add(ERedDotName.FeedbackReward, new FeedbackRedDot());
		this.Add(ERedDotName.RedDotPinballRole, new RedDotPinballRole());
		this.Add(ERedDotName.RedDotPinballRoleFunction, new RedDotPinballRoleFunction());
		this.Add(ERedDotName.RedDotKurotatoRole, new RedDotKurotatoRole());
		this.Add(ERedDotName.RedDotKurotatoWeaponAndProp, new RedDotKurotatoWeaponAndProp());
		this.Add(ERedDotName.RedDotKurotatoWeapon, new RedDotKurotatoWeapon());
		this.Add(ERedDotName.RedDotKurotatoProp, new RedDotKurotatoProp());
		this.Add(ERedDotName.RedDotKurotatoNormalRewardBtn, new RedDotKurotatoNormalRewardBtn());
		this.Add(ERedDotName.RedDotKurotatoLimitRewardBtn, new RedDotKurotatoLimitRewardBtn());
		this.Add(ERedDotName.RedDotKurotatoLimitRewardTabItem, new RedDotKurotatoLimitRewardTabItem());
		this.Add(ERedDotName.RedDotRoverlikeQuestRewardBtn, new RedDotRoverlikeQuestRewardBtn());
		this.Add(ERedDotName.RedDotRoverlikeShopRewardBtn, new RedDotRoverlikeShopRewardBtn());
		this.ConstructRelationships();
		return true;
	}

	// Token: 0x0601B498 RID: 111768 RVA: 0x00832B29 File Offset: 0x00830D29
	private void Add(ERedDotName name, RedDotBase redDot)
	{
		redDot.Init(name);
		this.TryGetRedDotTree(name, redDot);
	}

	// Token: 0x0601B499 RID: 111769 RVA: 0x00832B3C File Offset: 0x00830D3C
	private void ConstructRelationships()
	{
		Dictionary<ERedDotName, ERedDotName?> relativeNameMap = RedDotConfig.GetRelativeNameMap();
		foreach (KeyValuePair<ERedDotName, Tree<RedDotBase>> keyValuePair in this.RedDotTreeMap)
		{
			ERedDotName eredDotName;
			Tree<RedDotBase> tree;
			keyValuePair.Deconstruct(out eredDotName, out tree);
			ERedDotName key = eredDotName;
			Tree<RedDotBase> tree2 = tree;
			ERedDotName? parentName = tree2.Element.GetParentName();
			ERedDotName? eredDotName2 = (parentName != null) ? parentName : relativeNameMap.GetValueOrDefault(key, null);
			Tree<RedDotBase> tree3;
			if (eredDotName2 != null && this.RedDotTreeMap.TryGetValue(eredDotName2.Value, out tree3))
			{
				tree3.AddChild(tree2);
			}
		}
	}

	// Token: 0x0601B49A RID: 111770 RVA: 0x00832BF4 File Offset: 0x00830DF4
	private Tree<RedDotBase> TryGetRedDotTree(ERedDotName name, RedDotBase redDot)
	{
		Tree<RedDotBase> tree;
		if (!this.RedDotTreeMap.TryGetValue(name, out tree))
		{
			tree = new Tree<RedDotBase>(redDot, null);
			this.RedDotTreeMap[name] = tree;
		}
		return tree;
	}

	// Token: 0x0601B49B RID: 111771 RVA: 0x00832C28 File Offset: 0x00830E28
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Tree<RedDotBase> GetRedDotTree(ERedDotName name)
	{
		Tree<RedDotBase> result;
		if (this.RedDotTreeMap.TryGetValue(name, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RedDot;
		ELogAuthor author = ELogAuthor.TL;
		string message = "获取红点树失败，当前红点未注册！";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("红点名称", name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0601B49C RID: 111772 RVA: 0x00832C74 File Offset: 0x00830E74
	[NullableContext(2)]
	public RedDotBase GetRedDot(ERedDotName name)
	{
		Tree<RedDotBase> tree;
		if (this.RedDotTreeMap.TryGetValue(name, out tree))
		{
			return tree.Element;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RedDot;
		ELogAuthor author = ELogAuthor.TL;
		string message = "获取红点失败，当前红点未注册！";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("红点名称", name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0601B49D RID: 111773 RVA: 0x00832CC8 File Offset: 0x00830EC8
	private void GetAllRedDot(RedDotBase redDot, HashSet<RedDotBase> outSet)
	{
		outSet.Add(redDot);
		Tree<RedDotBase> redDotTree = this.GetRedDotTree(redDot.Name.Value);
		if (redDotTree != null)
		{
			foreach (KeyValuePair<RedDotBase, Tree<RedDotBase>> keyValuePair in redDotTree.ChildMap)
			{
				RedDotBase redDotBase;
				Tree<RedDotBase> tree;
				keyValuePair.Deconstruct(out redDotBase, out tree);
				RedDotBase redDot2 = redDotBase;
				this.GetAllRedDot(redDot2, outSet);
			}
		}
	}

	// Token: 0x0601B49E RID: 111774 RVA: 0x00832D48 File Offset: 0x00830F48
	public void LogAllRedDotTree(ERedDotName name)
	{
		RedDotBase redDot = this.GetRedDot(name);
		if (redDot != null)
		{
			HashSet<RedDotBase> hashSet = new HashSet<RedDotBase>();
			this.GetAllRedDot(redDot, hashSet);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RedDotBase redDotBase in hashSet)
			{
				stringBuilder.Append(redDotBase.ToRedDotString());
			}
			Singleton<Log>.Instance.Info(ELogModule.RedDot, ELogAuthor.XXJ, stringBuilder.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0601B49F RID: 111775 RVA: 0x00832DDC File Offset: 0x00830FDC
	public void LogAllRedDotState(ERedDotName name)
	{
		RedDotBase redDot = this.GetRedDot(name);
		if (redDot == null)
		{
			return;
		}
		HashSet<RedDotBase> hashSet = new HashSet<RedDotBase>();
		this.GetAllRedDot(redDot, hashSet);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RedDot;
		ELogAuthor author = ELogAuthor.CX;
		string message = "===========开始打印红点状态===========";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (RedDotBase redDotBase in hashSet)
		{
			redDotBase.PrintStateDebugString();
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.RedDot;
		ELogAuthor author2 = ELogAuthor.CX;
		string message2 = "===========结束打印红点状态===========";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Name", name);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x0601B4A0 RID: 111776 RVA: 0x00832E9C File Offset: 0x0083109C
	public void SwitchAllRedDot(bool bShow)
	{
		RedDotData.StateByGm = bShow;
		HashSet<RedDotBase> hashSet = new HashSet<RedDotBase>();
		foreach (Tree<RedDotBase> tree in this.RedDotTreeMap.Values)
		{
			RedDotBase element = tree.Element;
			hashSet.Add(element);
		}
		foreach (RedDotBase redDotBase in hashSet)
		{
			redDotBase.SetRedDotActiveByGm(bShow);
		}
	}

	// Token: 0x0400DF7A RID: 57210
	private readonly Dictionary<ERedDotName, Tree<RedDotBase>> RedDotTreeMap = new Dictionary<ERedDotName, Tree<RedDotBase>>();
}
