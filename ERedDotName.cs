using System;
using CSharpScript.Core.Common;

// Token: 0x020032CE RID: 13006
[EnumExtensions]
public enum ERedDotName
{
	// Token: 0x0400DE3F RID: 56895
	[EnumStringMember("Test")]
	Test,
	// Token: 0x0400DE40 RID: 56896
	[EnumStringMember("BattleViewMenu")]
	BattleViewMenu,
	// Token: 0x0400DE41 RID: 56897
	[EnumStringMember("BattleViewResonanceButton")]
	BattleViewResonanceButton,
	// Token: 0x0400DE42 RID: 56898
	[EnumStringMember("BattleViewShopButton")]
	BattleViewShopButton,
	// Token: 0x0400DE43 RID: 56899
	[EnumStringMember("BattleViewGachaButton")]
	BattleViewGachaButton,
	// Token: 0x0400DE44 RID: 56900
	[EnumStringMember("MailFilterAll")]
	MailFilterAll,
	// Token: 0x0400DE45 RID: 56901
	[EnumStringMember("FilterImportant")]
	FilterImportant,
	// Token: 0x0400DE46 RID: 56902
	[EnumStringMember("FilterUnScanned")]
	FilterUnScanned,
	// Token: 0x0400DE47 RID: 56903
	[EnumStringMember("RoleSystemRoleList")]
	RoleSystemRoleList,
	// Token: 0x0400DE48 RID: 56904
	[EnumStringMember("RoleAttributeTab")]
	RoleAttributeTab,
	// Token: 0x0400DE49 RID: 56905
	[EnumStringMember("RoleAttributeTabLevelUp")]
	RoleAttributeTabLevelUp,
	// Token: 0x0400DE4A RID: 56906
	[EnumStringMember("RoleAttributeTabBreakUp")]
	RoleAttributeTabBreakUp,
	// Token: 0x0400DE4B RID: 56907
	[EnumStringMember("RoleSkin")]
	RoleSkin,
	// Token: 0x0400DE4C RID: 56908
	[EnumStringMember("RoleChange")]
	RoleChange,
	// Token: 0x0400DE4D RID: 56909
	[EnumStringMember("FlySkinTab")]
	FlySkinTab,
	// Token: 0x0400DE4E RID: 56910
	[EnumStringMember("FlySkinChildTab")]
	FlySkinChildTab,
	// Token: 0x0400DE4F RID: 56911
	[EnumStringMember("HuluSkinTab")]
	HuluSkinTab,
	// Token: 0x0400DE50 RID: 56912
	[EnumStringMember("RoleOrnamentTab")]
	RoleOrnamentTab,
	// Token: 0x0400DE51 RID: 56913
	[EnumStringMember("RoleWeaponTabBreakUp")]
	RoleWeaponTabBreakUp,
	// Token: 0x0400DE52 RID: 56914
	[EnumStringMember("RoleFavorTab")]
	RoleFavorTab,
	// Token: 0x0400DE53 RID: 56915
	[EnumStringMember("RoleSkillTabPhantomSkill")]
	RoleSkillTabPhantomSkill,
	// Token: 0x0400DE54 RID: 56916
	[EnumStringMember("RoleChipTab")]
	RoleChipTab,
	// Token: 0x0400DE55 RID: 56917
	[EnumStringMember("RoleChipTabHole")]
	RoleChipTabHole,
	// Token: 0x0400DE56 RID: 56918
	[EnumStringMember("RoleResonanceTab")]
	RoleResonanceTab,
	// Token: 0x0400DE57 RID: 56919
	[EnumStringMember("RoleResonanceTabHole")]
	RoleResonanceTabHole,
	// Token: 0x0400DE58 RID: 56920
	[EnumStringMember("RedDotResonanceBtn")]
	RedDotResonanceBtn,
	// Token: 0x0400DE59 RID: 56921
	[EnumStringMember("RoleSelectionList")]
	RoleSelectionList,
	// Token: 0x0400DE5A RID: 56922
	[EnumStringMember("FunctionRole")]
	FunctionRole,
	// Token: 0x0400DE5B RID: 56923
	[EnumStringMember("FunctionPhantom")]
	FunctionPhantom,
	// Token: 0x0400DE5C RID: 56924
	[EnumStringMember("FunctionFriend")]
	FunctionFriend,
	// Token: 0x0400DE5D RID: 56925
	[EnumStringMember("FunctionGacha")]
	FunctionGacha,
	// Token: 0x0400DE5E RID: 56926
	[EnumStringMember("FunctionTutorial")]
	FunctionTutorial,
	// Token: 0x0400DE5F RID: 56927
	[EnumStringMember("FunctionAdventure")]
	FunctionAdventure,
	// Token: 0x0400DE60 RID: 56928
	[EnumStringMember("FunctionCalabash")]
	FunctionCalabash,
	// Token: 0x0400DE61 RID: 56929
	[EnumStringMember("FunctionInventory")]
	FunctionInventory,
	// Token: 0x0400DE62 RID: 56930
	[EnumStringMember("FunctionMail")]
	FunctionMail,
	// Token: 0x0400DE63 RID: 56931
	[EnumStringMember("FunctionNotice")]
	FunctionNotice,
	// Token: 0x0400DE64 RID: 56932
	[EnumStringMember("FunctionPayShop")]
	FunctionPayShop,
	// Token: 0x0400DE65 RID: 56933
	[EnumStringMember("FunctionPhantomExploreSet")]
	FunctionPhantomExploreSet,
	// Token: 0x0400DE66 RID: 56934
	[EnumStringMember("FunctionMailBind")]
	FunctionMailBind,
	// Token: 0x0400DE67 RID: 56935
	[EnumStringMember("FunctionKuroStreet")]
	FunctionKuroStreet,
	// Token: 0x0400DE68 RID: 56936
	[EnumStringMember("FunctionMap")]
	FunctionMap,
	// Token: 0x0400DE69 RID: 56937
	[EnumStringMember("FunctionPhotograph")]
	FunctionPhotograph,
	// Token: 0x0400DE6A RID: 56938
	[EnumStringMember("RedDotPhotoSetup")]
	RedDotPhotoSetup,
	// Token: 0x0400DE6B RID: 56939
	[EnumStringMember("PreDownload")]
	PreDownload,
	// Token: 0x0400DE6C RID: 56940
	[EnumStringMember("PreDownloadComplete")]
	PreDownloadComplete,
	// Token: 0x0400DE6D RID: 56941
	[EnumStringMember("FunctionSetting")]
	FunctionSetting,
	// Token: 0x0400DE6E RID: 56942
	[EnumStringMember("FunctionPhoneMsg")]
	FunctionPhoneMsg,
	// Token: 0x0400DE6F RID: 56943
	[EnumStringMember("FunctionWeatherCentral")]
	FunctionWeatherCentral,
	// Token: 0x0400DE70 RID: 56944
	[EnumStringMember("FunctionMotorDevelop")]
	FunctionMotorDevelop,
	// Token: 0x0400DE71 RID: 56945
	[EnumStringMember("PhoneMsgChatItemRedDot")]
	PhoneMsgChatItemRedDot,
	// Token: 0x0400DE72 RID: 56946
	[EnumStringMember("PhoneMsgChatPartnerRedDot")]
	PhoneMsgChatPartnerRedDot,
	// Token: 0x0400DE73 RID: 56947
	[EnumStringMember("PhoneMsgChatPartnerRedDotGiftIcon")]
	PhoneMsgChatPartnerRedDotGiftIcon,
	// Token: 0x0400DE74 RID: 56948
	[EnumStringMember("MapAreaExplore")]
	MapAreaExplore,
	// Token: 0x0400DE75 RID: 56949
	[EnumStringMember("MapAreaBoxReward")]
	MapAreaBoxReward,
	// Token: 0x0400DE76 RID: 56950
	[EnumStringMember("MapAreaShowTabCountry")]
	MapAreaShowTabCountry,
	// Token: 0x0400DE77 RID: 56951
	[EnumStringMember("MapAreaShowTabState")]
	MapAreaShowTabState,
	// Token: 0x0400DE78 RID: 56952
	[EnumStringMember("MapAreaShowTabArea")]
	MapAreaShowTabArea,
	// Token: 0x0400DE79 RID: 56953
	[EnumStringMember("ShipTower")]
	ShipTower,
	// Token: 0x0400DE7A RID: 56954
	[EnumStringMember("ShipTowerReward")]
	ShipTowerReward,
	// Token: 0x0400DE7B RID: 56955
	[EnumStringMember("CalabashTab")]
	CalabashTab,
	// Token: 0x0400DE7C RID: 56956
	[EnumStringMember("VisionRecovery")]
	VisionRecovery,
	// Token: 0x0400DE7D RID: 56957
	[EnumStringMember("VisionRefine")]
	VisionRefine,
	// Token: 0x0400DE7E RID: 56958
	[EnumStringMember("FriendNewApplication")]
	FriendNewApplication,
	// Token: 0x0400DE7F RID: 56959
	[EnumStringMember("ChatRoom")]
	ChatRoom,
	// Token: 0x0400DE80 RID: 56960
	[EnumStringMember("ChatView")]
	ChatView,
	// Token: 0x0400DE81 RID: 56961
	[EnumStringMember("TutorialItemNew")]
	TutorialItemNew,
	// Token: 0x0400DE82 RID: 56962
	[EnumStringMember("TutorialTypeNew")]
	TutorialTypeNew,
	// Token: 0x0400DE83 RID: 56963
	[EnumStringMember("AdventureManual")]
	AdventureManual,
	// Token: 0x0400DE84 RID: 56964
	[EnumStringMember("AdventureBattleButton")]
	AdventureBattleButton,
	// Token: 0x0400DE85 RID: 56965
	[EnumStringMember("AdventureFirstAward")]
	AdventureFirstAward,
	// Token: 0x0400DE86 RID: 56966
	[EnumStringMember("AdventureFirstAwardCategory")]
	AdventureFirstAwardCategory,
	// Token: 0x0400DE87 RID: 56967
	[EnumStringMember("AdventureFirstAwardResult")]
	AdventureFirstAwardResult,
	// Token: 0x0400DE88 RID: 56968
	[EnumStringMember("AdventureDailyActivityTab")]
	AdventureDailyActivityTab,
	// Token: 0x0400DE89 RID: 56969
	[EnumStringMember("AdventureDailyActivityTabDaily")]
	AdventureDailyActivityTabDaily,
	// Token: 0x0400DE8A RID: 56970
	[EnumStringMember("AdventureDailyActivityTabWeekly")]
	AdventureDailyActivityTabWeekly,
	// Token: 0x0400DE8B RID: 56971
	[EnumStringMember("AdventureNewSoundAreaTab")]
	AdventureNewSoundAreaTab,
	// Token: 0x0400DE8C RID: 56972
	[EnumStringMember("AdventureNewSoundAreaGeneral")]
	AdventureNewSoundAreaGeneral,
	// Token: 0x0400DE8D RID: 56973
	[EnumStringMember("AdventureChallengeTab")]
	AdventureChallengeTab,
	// Token: 0x0400DE8E RID: 56974
	[EnumStringMember("AdventurePeriodicityTab")]
	AdventurePeriodicityTab,
	// Token: 0x0400DE8F RID: 56975
	[EnumStringMember("InfluenceReputation")]
	InfluenceReputation,
	// Token: 0x0400DE90 RID: 56976
	[EnumStringMember("InfluenceReward")]
	InfluenceReward,
	// Token: 0x0400DE91 RID: 56977
	[EnumStringMember("CookerLevel")]
	CookerLevel,
	// Token: 0x0400DE92 RID: 56978
	[EnumStringMember("CookerLevelMain")]
	CookerLevelMain,
	// Token: 0x0400DE93 RID: 56979
	[EnumStringMember("BattlePass")]
	BattlePass,
	// Token: 0x0400DE94 RID: 56980
	[EnumStringMember("BattlePassTask")]
	BattlePassTask,
	// Token: 0x0400DE95 RID: 56981
	[EnumStringMember("BattlePassReward")]
	BattlePassReward,
	// Token: 0x0400DE96 RID: 56982
	[EnumStringMember("BattlePassAlwaysTaskTab")]
	BattlePassAlwaysTaskTab,
	// Token: 0x0400DE97 RID: 56983
	[EnumStringMember("BattlePassWeekTaskTab")]
	BattlePassWeekTaskTab,
	// Token: 0x0400DE98 RID: 56984
	[EnumStringMember("BattlePassDayTaskTab")]
	BattlePassDayTaskTab,
	// Token: 0x0400DE99 RID: 56985
	[EnumStringMember("RoleHandBook")]
	RoleHandBook,
	// Token: 0x0400DE9A RID: 56986
	[EnumStringMember("RoleHandBookActiveButton")]
	RoleHandBookActiveButton,
	// Token: 0x0400DE9B RID: 56987
	[EnumStringMember("ComposeReagentProduction")]
	ComposeReagentProduction,
	// Token: 0x0400DE9C RID: 56988
	[EnumStringMember("ItemHandBook")]
	ItemHandBook,
	// Token: 0x0400DE9D RID: 56989
	[EnumStringMember("PhantomHandBook")]
	PhantomHandBook,
	// Token: 0x0400DE9E RID: 56990
	[EnumStringMember("Achievement")]
	Achievement,
	// Token: 0x0400DE9F RID: 56991
	[EnumStringMember("AchievementCategory")]
	AchievementCategory,
	// Token: 0x0400DEA0 RID: 56992
	[EnumStringMember("ActivityEntrance")]
	ActivityEntrance,
	// Token: 0x0400DEA1 RID: 56993
	[EnumStringMember("CommonActivityPage")]
	CommonActivityPage,
	// Token: 0x0400DEA2 RID: 56994
	[EnumStringMember("ActivityRun")]
	ActivityRun,
	// Token: 0x0400DEA3 RID: 56995
	[EnumStringMember("BattleViewQuestButton")]
	BattleViewQuestButton,
	// Token: 0x0400DEA4 RID: 56996
	[EnumStringMember("QuestViewItem")]
	QuestViewItem,
	// Token: 0x0400DEA5 RID: 56997
	[EnumStringMember("QuestTab")]
	QuestTab,
	// Token: 0x0400DEA6 RID: 56998
	[EnumStringMember("FunctionViewQuestBtn")]
	FunctionViewQuestBtn,
	// Token: 0x0400DEA7 RID: 56999
	[EnumStringMember("InventoryVirtual")]
	InventoryVirtual,
	// Token: 0x0400DEA8 RID: 57000
	[EnumStringMember("InventoryCommon")]
	InventoryCommon,
	// Token: 0x0400DEA9 RID: 57001
	[EnumStringMember("InventoryWeapon")]
	InventoryWeapon,
	// Token: 0x0400DEAA RID: 57002
	[EnumStringMember("InventoryPhantom")]
	InventoryPhantom,
	// Token: 0x0400DEAB RID: 57003
	[EnumStringMember("InventoryCollection")]
	InventoryCollection,
	// Token: 0x0400DEAC RID: 57004
	[EnumStringMember("InventoryMaterial")]
	InventoryMaterial,
	// Token: 0x0400DEAD RID: 57005
	[EnumStringMember("InventoryMission")]
	InventoryMission,
	// Token: 0x0400DEAE RID: 57006
	[EnumStringMember("InventorySpecial")]
	InventorySpecial,
	// Token: 0x0400DEAF RID: 57007
	[EnumStringMember("InventoryCard")]
	InventoryCard,
	// Token: 0x0400DEB0 RID: 57008
	[EnumStringMember("TowerReward")]
	TowerReward,
	// Token: 0x0400DEB1 RID: 57009
	[EnumStringMember("TowerRewardByDifficulties")]
	TowerRewardByDifficulties,
	// Token: 0x0400DEB2 RID: 57010
	[EnumStringMember("IdentifyTab")]
	VisionIdentifyTab,
	// Token: 0x0400DEB3 RID: 57011
	[EnumStringMember("VisionOneKeyEquip")]
	VisionOneKeyEquip,
	// Token: 0x0400DEB4 RID: 57012
	[EnumStringMember("VisionTabRedDot")]
	VisionTabRedDot,
	// Token: 0x0400DEB5 RID: 57013
	[EnumStringMember("VisionGridRedDot")]
	VisionGridRedDot,
	// Token: 0x0400DEB6 RID: 57014
	[EnumStringMember("PayShopInstance")]
	PayShopInstance,
	// Token: 0x0400DEB7 RID: 57015
	[EnumStringMember("PayShopTab")]
	PayShopTab,
	// Token: 0x0400DEB8 RID: 57016
	[EnumStringMember("CustomerService")]
	CustomerService,
	// Token: 0x0400DEB9 RID: 57017
	[EnumStringMember("Introduction")]
	Introduction,
	// Token: 0x0400DEBA RID: 57018
	[EnumStringMember("RogueSkillUnlock")]
	RogueSkillUnlock,
	// Token: 0x0400DEBB RID: 57019
	[EnumStringMember("RoguelikeAchievement")]
	RoguelikeAchievement,
	// Token: 0x0400DEBC RID: 57020
	[EnumStringMember("RoguelikeShop")]
	RoguelikeShop,
	// Token: 0x0400DEBD RID: 57021
	[EnumStringMember("RoguelikeAchievementGroup")]
	RoguelikeAchievementGroup,
	// Token: 0x0400DEBE RID: 57022
	[EnumStringMember("RogueResIllustratedTokenTab")]
	RogueResIllustratedTokenTab,
	// Token: 0x0400DEBF RID: 57023
	[EnumStringMember("RogueResIllustratedNormalTab")]
	RogueResIllustratedNormalTab,
	// Token: 0x0400DEC0 RID: 57024
	[EnumStringMember("RogueResIllustratedMapTab")]
	RogueResIllustratedMapTab,
	// Token: 0x0400DEC1 RID: 57025
	[EnumStringMember("RogueResIllustrated")]
	RogueResIllustrated,
	// Token: 0x0400DEC2 RID: 57026
	[EnumStringMember("RogueResTask")]
	RogueResTask,
	// Token: 0x0400DEC3 RID: 57027
	[EnumStringMember("RogueResShop")]
	RogueResShop,
	// Token: 0x0400DEC4 RID: 57028
	[EnumStringMember("RogueResInst")]
	RogueResInst,
	// Token: 0x0400DEC5 RID: 57029
	[EnumStringMember("RogueResSkillTree")]
	RogueResSkillTree,
	// Token: 0x0400DEC6 RID: 57030
	[EnumStringMember("RogueResEnding")]
	RogueResEnding,
	// Token: 0x0400DEC7 RID: 57031
	[EnumStringMember("BossRushReward")]
	BossRushReward,
	// Token: 0x0400DEC8 RID: 57032
	[EnumStringMember("MowingTowerReward")]
	MowingTowerReward,
	// Token: 0x0400DEC9 RID: 57033
	[EnumStringMember("TowerDefenseReward")]
	TowerDefenseReward,
	// Token: 0x0400DECA RID: 57034
	[EnumStringMember("TowerDefenseInstance")]
	TowerDefenseInstance,
	// Token: 0x0400DECB RID: 57035
	[EnumStringMember("RedDotMowingRiskReward")]
	RedDotMowingRiskReward,
	// Token: 0x0400DECC RID: 57036
	[EnumStringMember("RedDotMowingRiskBuffAll")]
	RedDotMowingRiskBuffAll,
	// Token: 0x0400DECD RID: 57037
	[EnumStringMember("FragmentMemoryReward")]
	FragmentMemoryReward,
	// Token: 0x0400DECE RID: 57038
	[EnumStringMember("FragmentMemoryEntrance")]
	FragmentMemoryEntrance,
	// Token: 0x0400DECF RID: 57039
	[EnumStringMember("FragmentMemoryTopic")]
	FragmentMemoryTopic,
	// Token: 0x0400DED0 RID: 57040
	[EnumStringMember("FragmentMemoryTopicCollectRedDot")]
	FragmentMemoryTopicCollectRedDot,
	// Token: 0x0400DED1 RID: 57041
	[EnumStringMember("BattlePassPayButton")]
	BattlePassPayButton,
	// Token: 0x0400DED2 RID: 57042
	[EnumStringMember("PersonalInfo")]
	PersonalizedInfo,
	// Token: 0x0400DED3 RID: 57043
	[EnumStringMember("PersonalCard")]
	PersonalCard,
	// Token: 0x0400DED4 RID: 57044
	[EnumStringMember("PersonalTitle")]
	PersonalTitle,
	// Token: 0x0400DED5 RID: 57045
	[EnumStringMember("PersonalBirthday")]
	PersonalBirthday,
	// Token: 0x0400DED6 RID: 57046
	[EnumStringMember("PersonalImageBook")]
	PersonalImageBook,
	// Token: 0x0400DED7 RID: 57047
	[EnumStringMember("ActivityRecallSignEntry")]
	ActivityRecallSignEntry,
	// Token: 0x0400DED8 RID: 57048
	[EnumStringMember("ActivityRecallTask")]
	ActivityRecallTaskEntry,
	// Token: 0x0400DED9 RID: 57049
	[EnumStringMember("ActivityRegressQuestionnaire")]
	ActivityRegressQuestionnaire,
	// Token: 0x0400DEDA RID: 57050
	[EnumStringMember("ActivityRegressShopDiscount")]
	ActivityRegressShopDiscount,
	// Token: 0x0400DEDB RID: 57051
	[EnumStringMember("ActivityRegressDoubleDrop")]
	ActivityRegressDoubleDrop,
	// Token: 0x0400DEDC RID: 57052
	[EnumStringMember("ActivityRegressCultivate")]
	ActivityRegressCultivate,
	// Token: 0x0400DEDD RID: 57053
	[EnumStringMember("ActivityRegressConstantTask")]
	ActivityRegressConstantTask,
	// Token: 0x0400DEDE RID: 57054
	[EnumStringMember("ActivityRegressTrialRole")]
	ActivityRegressTrialRole,
	// Token: 0x0400DEDF RID: 57055
	[EnumStringMember("ActivityRegressBp")]
	ActivityRegressBp,
	// Token: 0x0400DEE0 RID: 57056
	[EnumStringMember("ActivityRegressBpTask")]
	ActivityRegressBpTask,
	// Token: 0x0400DEE1 RID: 57057
	[EnumStringMember("ActivityRegressBpReward")]
	ActivityRegressBpReward,
	// Token: 0x0400DEE2 RID: 57058
	[EnumStringMember("ActivityRegressDisposableReward")]
	ActivityRegressDisposableReward,
	// Token: 0x0400DEE3 RID: 57059
	[EnumStringMember("ActivityRegressRecommend")]
	ActivityRegressRecommend,
	// Token: 0x0400DEE4 RID: 57060
	[EnumStringMember("ActivityRegressAdventure")]
	ActivityRegressAdventure,
	// Token: 0x0400DEE5 RID: 57061
	[EnumStringMember("ActivityRegressRewardBtn")]
	ActivityRegressRewardBtn,
	// Token: 0x0400DEE6 RID: 57062
	[EnumStringMember("VisionLevelUpSetting")]
	VisionLevelUpSetting,
	// Token: 0x0400DEE7 RID: 57063
	[EnumStringMember("MoonChasingAllQuest")]
	MoonChasingAllQuest,
	// Token: 0x0400DEE8 RID: 57064
	[EnumStringMember("MoonChasingMainlineTab")]
	MoonChasingMainlineTab,
	// Token: 0x0400DEE9 RID: 57065
	[EnumStringMember("MoonChasingBranchTab")]
	MoonChasingBranchTab,
	// Token: 0x0400DEEA RID: 57066
	[EnumStringMember("MoonChasingHandbook")]
	MoonChasingHandbook,
	// Token: 0x0400DEEB RID: 57067
	[EnumStringMember("MoonChasingReward")]
	MoonChasingReward,
	// Token: 0x0400DEEC RID: 57068
	[EnumStringMember("MoonChasingShop")]
	MoonChasingShop,
	// Token: 0x0400DEED RID: 57069
	[EnumStringMember("MoonChasingRewardAndShop")]
	MoonChasingRewardAndShop,
	// Token: 0x0400DEEE RID: 57070
	[EnumStringMember("MoonChasingBuilding")]
	MoonChasingBuilding,
	// Token: 0x0400DEEF RID: 57071
	[EnumStringMember("MoonChasingRole")]
	MoonChasingRole,
	// Token: 0x0400DEF0 RID: 57072
	[EnumStringMember("MoonChasingDelegation")]
	MoonChasingDelegation,
	// Token: 0x0400DEF1 RID: 57073
	[EnumStringMember("ActivityCorniceMeeting")]
	ActivityCorniceMeeting,
	// Token: 0x0400DEF2 RID: 57074
	[EnumStringMember("Spring25AllLetter")]
	Spring25AllLetter,
	// Token: 0x0400DEF3 RID: 57075
	[EnumStringMember("Spring25Reward")]
	Spring25Reward,
	// Token: 0x0400DEF4 RID: 57076
	[EnumStringMember("Spring25Invite")]
	Spring25Invite,
	// Token: 0x0400DEF5 RID: 57077
	[EnumStringMember("Spring25Enter")]
	Spring25Enter,
	// Token: 0x0400DEF6 RID: 57078
	[EnumStringMember("FarmGoldReward")]
	FarmGoldReward,
	// Token: 0x0400DEF7 RID: 57079
	[EnumStringMember("FishingTech")]
	FishingTech,
	// Token: 0x0400DEF8 RID: 57080
	[EnumStringMember("FishingRoleTechNode")]
	FishingRoleTechNode,
	// Token: 0x0400DEF9 RID: 57081
	[EnumStringMember("FishingRoleToggleTech")]
	FishingRoleToggleTech,
	// Token: 0x0400DEFA RID: 57082
	[EnumStringMember("FishingNormalTechNode")]
	FishingNormalTechNode,
	// Token: 0x0400DEFB RID: 57083
	[EnumStringMember("FishingNormalTech")]
	FishingNormalTech,
	// Token: 0x0400DEFC RID: 57084
	[EnumStringMember("FishingRoleTech")]
	FishingRoleTech,
	// Token: 0x0400DEFD RID: 57085
	[EnumStringMember("InviteNewbie")]
	InviteNewbie,
	// Token: 0x0400DEFE RID: 57086
	[EnumStringMember("BabelTowerQuestRedDot")]
	BabelTowerQuestRedDot,
	// Token: 0x0400DEFF RID: 57087
	[EnumStringMember("BabelTowerNewLevelDifficulty")]
	BabelTowerNewLevelDifficulty,
	// Token: 0x0400DF00 RID: 57088
	[EnumStringMember("BabelTowerNewLevel")]
	BabelTowerNewLevel,
	// Token: 0x0400DF01 RID: 57089
	[EnumStringMember("CiacconaProgressReward")]
	CiacconaProgressReward,
	// Token: 0x0400DF02 RID: 57090
	[EnumStringMember("CiacconaEndingReward")]
	CiacconaEndingReward,
	// Token: 0x0400DF03 RID: 57091
	[EnumStringMember("CiacconaSubEndingReward")]
	CiacconaSubEndingReward,
	// Token: 0x0400DF04 RID: 57092
	[EnumStringMember("DangoMonopoly")]
	DangoMonopoly,
	// Token: 0x0400DF05 RID: 57093
	[EnumStringMember("DangoMonopolyTask")]
	DangoMonopolyTask,
	// Token: 0x0400DF06 RID: 57094
	[EnumStringMember("DangoMonopolyDiceNum")]
	DangoMonopolyDiceNum,
	// Token: 0x0400DF07 RID: 57095
	[EnumStringMember("DangoMonopolyRound")]
	DangoMonopolyRound,
	// Token: 0x0400DF08 RID: 57096
	[EnumStringMember("Morale")]
	Morale,
	// Token: 0x0400DF09 RID: 57097
	[EnumStringMember("MoraleScoreBox")]
	MoraleScoreBox,
	// Token: 0x0400DF0A RID: 57098
	[EnumStringMember("MoraleFlagBox")]
	MoraleFlagBox,
	// Token: 0x0400DF0B RID: 57099
	[EnumStringMember("MoraleBuff")]
	MoraleBuff,
	// Token: 0x0400DF0C RID: 57100
	[EnumStringMember("MoraleAreaBuff")]
	MoraleAreaBuff,
	// Token: 0x0400DF0D RID: 57101
	[EnumStringMember("TrapDefense")]
	TrapDefense,
	// Token: 0x0400DF0E RID: 57102
	[EnumStringMember("TrapDefenseFixedReward")]
	TrapDefenseFixedReward,
	// Token: 0x0400DF0F RID: 57103
	[EnumStringMember("TrapDefenseLimitReward")]
	TrapDefenseLimitReward,
	// Token: 0x0400DF10 RID: 57104
	[EnumStringMember("TrapDefenseMainLevel")]
	TrapDefenseMainLevel,
	// Token: 0x0400DF11 RID: 57105
	[EnumStringMember("TrapDefenseLevelModeLevelReachOpenTime")]
	TrapDefenseLevelModeLevelReachOpenTime,
	// Token: 0x0400DF12 RID: 57106
	[EnumStringMember("TrapDefenseRougeLevel")]
	TrapDefenseRougeLevel,
	// Token: 0x0400DF13 RID: 57107
	[EnumStringMember("TrapDefenseTalentTree")]
	TrapDefenseTalentTree,
	// Token: 0x0400DF14 RID: 57108
	[EnumStringMember("TrapDefenseDevelopBranchAll")]
	TrapDefenseDevelopBranchAll,
	// Token: 0x0400DF15 RID: 57109
	[EnumStringMember("TrapDefenseDevelopBranchAuxiliary")]
	TrapDefenseDevelopBranchAuxiliary,
	// Token: 0x0400DF16 RID: 57110
	[EnumStringMember("TrapDefenseDevelopBranchBuilding")]
	TrapDefenseDevelopBranchBuilding,
	// Token: 0x0400DF17 RID: 57111
	[EnumStringMember("TrapDefenseRougeModeLevelReachOpenTime")]
	TrapDefenseRougeModeLevelReachOpenTime,
	// Token: 0x0400DF18 RID: 57112
	[EnumStringMember("TrapDefenseRougeModeOpen")]
	TrapDefenseRougeModeOpen,
	// Token: 0x0400DF19 RID: 57113
	[EnumStringMember("TrapDefenseBdSum")]
	TrapDefenseBdSum,
	// Token: 0x0400DF1A RID: 57114
	[EnumStringMember("TrapDefenseBdBuffNewUnlock")]
	TrapDefenseBdBuffNewUnlock,
	// Token: 0x0400DF1B RID: 57115
	[EnumStringMember("RedDotVersionCheck")]
	RedDotVersionCheck,
	// Token: 0x0400DF1C RID: 57116
	[EnumStringMember("RedDotDangoCommonReward")]
	RedDotDangoCommonReward,
	// Token: 0x0400DF1D RID: 57117
	[EnumStringMember("RedDotDangoLimitReward")]
	RedDotDangoLimitReward,
	// Token: 0x0400DF1E RID: 57118
	[EnumStringMember("RedDotDangoPayShop")]
	RedDotDangoPayShop,
	// Token: 0x0400DF1F RID: 57119
	[EnumStringMember("RedDotDangoDevelop")]
	RedDotDangoDevelop,
	// Token: 0x0400DF20 RID: 57120
	[EnumStringMember("RedDotDangoRole")]
	RedDotDangoRole,
	// Token: 0x0400DF21 RID: 57121
	[EnumStringMember("RedDotDangoFormation")]
	RedDotDangoFormation,
	// Token: 0x0400DF22 RID: 57122
	[EnumStringMember("RedDotDangoFormationRole")]
	RedDotDangoFormationRole,
	// Token: 0x0400DF23 RID: 57123
	[EnumStringMember("RedDotRacingBetsActivityReward")]
	RedDotRacingBetsActivityReward,
	// Token: 0x0400DF24 RID: 57124
	[EnumStringMember("RedDotRacingBetsActivityInternalReward")]
	RedDotRacingBetsActivityInternalReward,
	// Token: 0x0400DF25 RID: 57125
	[EnumStringMember("RedDotPhantomArenaLimitReward")]
	RedDotPhantomArenaLimitReward,
	// Token: 0x0400DF26 RID: 57126
	[EnumStringMember("RedDotPhantomArenaTaskReward")]
	RedDotPhantomArenaTaskReward,
	// Token: 0x0400DF27 RID: 57127
	[EnumStringMember("RedDotPhantomArenaShopUpdate")]
	RedDotPhantomArenaShopUpdate,
	// Token: 0x0400DF28 RID: 57128
	[EnumStringMember("RedDotPhantomArenaCardReward")]
	RedDotPhantomArenaCardReward,
	// Token: 0x0400DF29 RID: 57129
	[EnumStringMember("RedDotPhantomArenaBadgeReward")]
	RedDotPhantomArenaBadgeReward,
	// Token: 0x0400DF2A RID: 57130
	[EnumStringMember("RedDotPhantomArenaLevelReward")]
	RedDotPhantomArenaLevelReward,
	// Token: 0x0400DF2B RID: 57131
	[EnumStringMember("RedDotPhantomArenaCollect")]
	RedDotPhantomArenaCollect,
	// Token: 0x0400DF2C RID: 57132
	[EnumStringMember("RedDotPhantomArenaRole")]
	RedDotPhantomArenaRole,
	// Token: 0x0400DF2D RID: 57133
	[EnumStringMember("RedDotPhantomArenaGym")]
	RedDotPhantomArenaGym,
	// Token: 0x0400DF2E RID: 57134
	[EnumStringMember("RedDotPhantomArenaActivity")]
	RedDotPhantomArenaActivity,
	// Token: 0x0400DF2F RID: 57135
	[EnumStringMember("RedDotPhantomArenaMapUnlock")]
	RedDotPhantomArenaMapUnlock,
	// Token: 0x0400DF30 RID: 57136
	[EnumStringMember("RedDotPhantomArenaMapUnlockDropDownItem")]
	RedDotPhantomArenaMapUnlockDropDownItem,
	// Token: 0x0400DF31 RID: 57137
	[EnumStringMember("CumulativeShopTaskTabRedDot")]
	CumulativeShopTaskTabRedDot,
	// Token: 0x0400DF32 RID: 57138
	[EnumStringMember("BeginnerCarnivalTaskTabRedDot")]
	BeginnerCarnivalTaskTabRedDot,
	// Token: 0x0400DF33 RID: 57139
	[EnumStringMember("LifePointDrawChallengeRedDot")]
	LifePointDrawChallengeRedDot,
	// Token: 0x0400DF34 RID: 57140
	[EnumStringMember("LifePointDrawGroupRedDot")]
	LifePointDrawGroupRedDot,
	// Token: 0x0400DF35 RID: 57141
	[EnumStringMember("ActivityFunPlay")]
	ActivityFunPlay,
	// Token: 0x0400DF36 RID: 57142
	[EnumStringMember("InfrShop")]
	InfrShop,
	// Token: 0x0400DF37 RID: 57143
	[EnumStringMember("InfrLimitedTask")]
	InfrLimitedTask,
	// Token: 0x0400DF38 RID: 57144
	[EnumStringMember("InfrArchive")]
	InfrArchive,
	// Token: 0x0400DF39 RID: 57145
	[EnumStringMember("Infrastructure")]
	Infrastructure,
	// Token: 0x0400DF3A RID: 57146
	[EnumStringMember("VillageInfrTask")]
	VillageInfrTask,
	// Token: 0x0400DF3B RID: 57147
	[EnumStringMember("VillageInfrTree")]
	VillageInfrTree,
	// Token: 0x0400DF3C RID: 57148
	[EnumStringMember("VillageInfr")]
	VillageInfr,
	// Token: 0x0400DF3D RID: 57149
	[EnumStringMember("RedDotNewPlayerSupportTrialRoleEntrance")]
	RedDotNewPlayerSupportTrialRoleEntrance,
	// Token: 0x0400DF3E RID: 57150
	[EnumStringMember("RedDotNewPlayerSupportAdventure")]
	RedDotNewPlayerSupportAdventure,
	// Token: 0x0400DF3F RID: 57151
	[EnumStringMember("RedDotTrialRoleGroup")]
	RedDotTrialRoleGroup,
	// Token: 0x0400DF40 RID: 57152
	[EnumStringMember("LineCrossChallengeRedDot")]
	LineCrossChallengeRedDot,
	// Token: 0x0400DF41 RID: 57153
	[EnumStringMember("LineCrossGroupRedDot")]
	LineCrossGroupRedDot,
	// Token: 0x0400DF42 RID: 57154
	[EnumStringMember("RedDotWeaponResonanceTab")]
	RedDotWeaponResonanceTab,
	// Token: 0x0400DF43 RID: 57155
	[EnumStringMember("RedDotPhantomInteractUnlock")]
	RedDotPhantomInteractUnlock,
	// Token: 0x0400DF44 RID: 57156
	[EnumStringMember("RedDotPhantomInteractEditEntry")]
	RedDotPhantomInteractEditEntry,
	// Token: 0x0400DF45 RID: 57157
	[EnumStringMember("RedDotPhantomInteractRouletteGrid")]
	RedDotPhantomInteractRouletteGrid,
	// Token: 0x0400DF46 RID: 57158
	[EnumStringMember("MotorcycleLevelTab")]
	MotorcycleLevelTab,
	// Token: 0x0400DF47 RID: 57159
	[EnumStringMember("MotorcycleTechTreeTab")]
	MotorcycleTechTreeTab,
	// Token: 0x0400DF48 RID: 57160
	[EnumStringMember("MotorcycleTreeTypeTechTab")]
	MotorcycleTreeTypeTechTab,
	// Token: 0x0400DF49 RID: 57161
	[EnumStringMember("MotorcycleTreeTypeTechTabNew")]
	MotorcycleTreeTypeTechTabNew,
	// Token: 0x0400DF4A RID: 57162
	[EnumStringMember("MotorcycleTreeTypeTaskTab")]
	MotorcycleTreeTypeTaskTab,
	// Token: 0x0400DF4B RID: 57163
	[EnumStringMember("MotorcycleTaskTab")]
	MotorcycleTaskTab,
	// Token: 0x0400DF4C RID: 57164
	[EnumStringMember("MotorcycleDiyTab")]
	MotorcycleDiyTab,
	// Token: 0x0400DF4D RID: 57165
	[EnumStringMember("MotorcycleSceneButtonRedDot")]
	MotorcycleSceneButtonRedDot,
	// Token: 0x0400DF4E RID: 57166
	[EnumStringMember("MotorcycleDiyFrameTab")]
	MotorcycleDiyFrameTab,
	// Token: 0x0400DF4F RID: 57167
	[EnumStringMember("MotorcycleDiyStickerTab")]
	MotorcycleDiyStickerTab,
	// Token: 0x0400DF50 RID: 57168
	[EnumStringMember("MotorcycleDiyStickerPartTab")]
	MotorcycleDiyStickerPartTab,
	// Token: 0x0400DF51 RID: 57169
	[EnumStringMember("MotorcycleDiyDecorationTab")]
	MotorcycleDiyDecorationTab,
	// Token: 0x0400DF52 RID: 57170
	[EnumStringMember("MotorcycleDiyDecorationPartTab")]
	MotorcycleDiyDecorationPartTab,
	// Token: 0x0400DF53 RID: 57171
	[EnumStringMember("MotorcycleDiyFramePreTab")]
	MotorcycleDiyFramePreTab,
	// Token: 0x0400DF54 RID: 57172
	[EnumStringMember("MotorcycleDiyStickerPreTab")]
	MotorcycleDiyStickerPreTab,
	// Token: 0x0400DF55 RID: 57173
	[EnumStringMember("MotorcycleDiyStickerPrePartTab")]
	MotorcycleDiyStickerPrePartTab,
	// Token: 0x0400DF56 RID: 57174
	[EnumStringMember("MotorcycleDiyDecorationPreTab")]
	MotorcycleDiyDecorationPreTab,
	// Token: 0x0400DF57 RID: 57175
	[EnumStringMember("MotorcycleDiyDecorationPrePartTab")]
	MotorcycleDiyDecorationPrePartTab,
	// Token: 0x0400DF58 RID: 57176
	[EnumStringMember("ActivityDirectTrainProEntry")]
	ActivityDirectTrainProEntry,
	// Token: 0x0400DF59 RID: 57177
	[EnumStringMember("FeedbackReward")]
	FeedbackReward,
	// Token: 0x0400DF5A RID: 57178
	[EnumStringMember("RedDotCyberPunkTask")]
	RedDotCyberPunkTask,
	// Token: 0x0400DF5B RID: 57179
	[EnumStringMember("RedDotCyberPunkTaskTab")]
	RedDotCyberPunkTaskTab,
	// Token: 0x0400DF5C RID: 57180
	[EnumStringMember("RedDotCyberPunkTrialRole")]
	RedDotCyberPunkTrialRole,
	// Token: 0x0400DF5D RID: 57181
	[EnumStringMember("RedDotCyberPunkBoss")]
	RedDotCyberPunkBoss,
	// Token: 0x0400DF5E RID: 57182
	[EnumStringMember("RedDotCyberPunkReward")]
	RedDotCyberPunkReward,
	// Token: 0x0400DF5F RID: 57183
	[EnumStringMember("SpringManorGameEntrance")]
	SpringManorGameEntrance,
	// Token: 0x0400DF60 RID: 57184
	[EnumStringMember("DrinksUnlockLevel")]
	DrinksUnlockLevel,
	// Token: 0x0400DF61 RID: 57185
	[EnumStringMember("GuessJokerUnlockLevel")]
	GuessJokerUnlockLevel,
	// Token: 0x0400DF62 RID: 57186
	[EnumStringMember("SpringManorAlbumReward")]
	SpringManorAlbumReward,
	// Token: 0x0400DF63 RID: 57187
	[EnumStringMember("SpringManorBrochureReward")]
	SpringManorBrochureReward,
	// Token: 0x0400DF64 RID: 57188
	[EnumStringMember("FurnitureEntranceRedDot")]
	FurnitureEntranceRedDot,
	// Token: 0x0400DF65 RID: 57189
	[EnumStringMember("RhythmShipTimeLimitTask")]
	RhythmShipTimeLimitTask,
	// Token: 0x0400DF66 RID: 57190
	[EnumStringMember("RhythmShipTask")]
	RhythmShipTask,
	// Token: 0x0400DF67 RID: 57191
	[EnumStringMember("RhythmShipTaskTab")]
	RhythmShipTaskTab,
	// Token: 0x0400DF68 RID: 57192
	[EnumStringMember("BossPilingReward")]
	BossPilingReward,
	// Token: 0x0400DF69 RID: 57193
	[EnumStringMember("RedDotFlagChallengeActivityReward")]
	RedDotFlagChallengeActivityReward,
	// Token: 0x0400DF6A RID: 57194
	[EnumStringMember("RedDotFlagChallengeActivityLevelNewlyUnlocked")]
	RedDotFlagChallengeActivityLevelNewlyUnlocked,
	// Token: 0x0400DF6B RID: 57195
	[EnumStringMember("RedDotFlagChallengeActivityBuffNewlyUnlocked")]
	RedDotFlagChallengeActivityBuffNewlyUnlocked,
	// Token: 0x0400DF6C RID: 57196
	[EnumStringMember("RedDotFlagChallengeActivityBuffItemNewlyUnlocked")]
	RedDotFlagChallengeActivityBuffItemNewlyUnlocked,
	// Token: 0x0400DF6D RID: 57197
	[EnumStringMember("RedDotFlagChallengeBattleBuffNewlyUnlocked")]
	RedDotFlagChallengeBattleBuffNewlyUnlocked,
	// Token: 0x0400DF6E RID: 57198
	[EnumStringMember("RedDotPinballRole")]
	RedDotPinballRole,
	// Token: 0x0400DF6F RID: 57199
	[EnumStringMember("RedDotPinballRoleFunction")]
	RedDotPinballRoleFunction,
	// Token: 0x0400DF70 RID: 57200
	[EnumStringMember("RedDotKurotatoRole")]
	RedDotKurotatoRole,
	// Token: 0x0400DF71 RID: 57201
	[EnumStringMember("RedDotKurotatoWeaponAndProp")]
	RedDotKurotatoWeaponAndProp,
	// Token: 0x0400DF72 RID: 57202
	[EnumStringMember("RedDotKurotatoWeapon")]
	RedDotKurotatoWeapon,
	// Token: 0x0400DF73 RID: 57203
	[EnumStringMember("RedDotKurotatoProp")]
	RedDotKurotatoProp,
	// Token: 0x0400DF74 RID: 57204
	[EnumStringMember("RedDotKurotatoNormalRewardBtn")]
	RedDotKurotatoNormalRewardBtn,
	// Token: 0x0400DF75 RID: 57205
	[EnumStringMember("RedDotKurotatoLimitRewardBtn")]
	RedDotKurotatoLimitRewardBtn,
	// Token: 0x0400DF76 RID: 57206
	[EnumStringMember("RedDotKurotatoLimitRewardTabItem")]
	RedDotKurotatoLimitRewardTabItem,
	// Token: 0x0400DF77 RID: 57207
	[EnumStringMember("SheriffMap")]
	SheriffMap,
	// Token: 0x0400DF78 RID: 57208
	[EnumStringMember("RedDotRoverlikeQuestRewardBtn")]
	RedDotRoverlikeQuestRewardBtn,
	// Token: 0x0400DF79 RID: 57209
	[EnumStringMember("RedDotRoverlikeShopRewardBtn")]
	RedDotRoverlikeShopRewardBtn
}
