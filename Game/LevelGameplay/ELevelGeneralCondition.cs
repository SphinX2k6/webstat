using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A5C RID: 27228
	[EnumExtensions]
	public enum ELevelGeneralCondition
	{
		// Token: 0x040258C8 RID: 153800
		DistanceLess,
		// Token: 0x040258C9 RID: 153801
		SelfTagCheck,
		// Token: 0x040258CA RID: 153802
		ItemCheck,
		// Token: 0x040258CB RID: 153803
		CheckItemWithOperator,
		// Token: 0x040258CC RID: 153804
		CheckDis,
		// Token: 0x040258CD RID: 153805
		TargetTagCheck,
		// Token: 0x040258CE RID: 153806
		CheckOnTrap,
		// Token: 0x040258CF RID: 153807
		CheckDirection,
		// Token: 0x040258D0 RID: 153808
		QuestState,
		// Token: 0x040258D1 RID: 153809
		CheckStrikeInfo,
		// Token: 0x040258D2 RID: 153810
		CheckLevel,
		// Token: 0x040258D3 RID: 153811
		CheckLevelOp,
		// Token: 0x040258D4 RID: 153812
		CheckGuideStatus,
		// Token: 0x040258D5 RID: 153813
		CheckCharacterTag,
		// Token: 0x040258D6 RID: 153814
		CheckCharacterTagByEvent,
		// Token: 0x040258D7 RID: 153815
		CheckCharacterTagNotByEvent,
		// Token: 0x040258D8 RID: 153816
		CheckCharacterVehicleTagByEvent,
		// Token: 0x040258D9 RID: 153817
		CheckCharacterVehicleTagNotByEvent,
		// Token: 0x040258DA RID: 153818
		DragonPoolState,
		// Token: 0x040258DB RID: 153819
		SceneStepState,
		// Token: 0x040258DC RID: 153820
		CheckTeleportStatus,
		// Token: 0x040258DD RID: 153821
		RoleLevel,
		// Token: 0x040258DE RID: 153822
		CheckRoleLevel,
		// Token: 0x040258DF RID: 153823
		CheckRoleOwned,
		// Token: 0x040258E0 RID: 153824
		RoleBreach,
		// Token: 0x040258E1 RID: 153825
		SelfGameplayTagCheck,
		// Token: 0x040258E2 RID: 153826
		CheckInTodTimeSpan,
		// Token: 0x040258E3 RID: 153827
		[EnumStringMember("CheckEntityCommonTag")]
		CheckSceneItemTag,
		// Token: 0x040258E4 RID: 153828
		IsPlayer,
		// Token: 0x040258E5 RID: 153829
		CheckEntityConfigId,
		// Token: 0x040258E6 RID: 153830
		CheckSelfEntityCommonTag,
		// Token: 0x040258E7 RID: 153831
		CheckInstanceEntranceUnlockStatus,
		// Token: 0x040258E8 RID: 153832
		CheckOriginWorldLevel,
		// Token: 0x040258E9 RID: 153833
		CheckCurWorldLevel,
		// Token: 0x040258EA RID: 153834
		CheckCurWorldLevelOp,
		// Token: 0x040258EB RID: 153835
		StartShootTarget,
		// Token: 0x040258EC RID: 153836
		CheckInstanceState,
		// Token: 0x040258ED RID: 153837
		CheckInstanceMatchAble,
		// Token: 0x040258EE RID: 153838
		MoveStateCheck,
		// Token: 0x040258EF RID: 153839
		[EnumStringMember("LevelConditionCheckBuff")]
		CheckBuff,
		// Token: 0x040258F0 RID: 153840
		CheckUIState,
		// Token: 0x040258F1 RID: 153841
		CheckUIOpen,
		// Token: 0x040258F2 RID: 153842
		CheckUIOpenDone,
		// Token: 0x040258F3 RID: 153843
		CheckUIShowDone,
		// Token: 0x040258F4 RID: 153844
		CheckInputAction,
		// Token: 0x040258F5 RID: 153845
		CheckClientUseSkill,
		// Token: 0x040258F6 RID: 153846
		CheckClientUseVisionSkill,
		// Token: 0x040258F7 RID: 153847
		CheckBattleRole,
		// Token: 0x040258F8 RID: 153848
		CheckEquippedPhantom,
		// Token: 0x040258F9 RID: 153849
		CheckEnemyBuff,
		// Token: 0x040258FA RID: 153850
		CheckEnemyTag,
		// Token: 0x040258FB RID: 153851
		CheckSkillPoint,
		// Token: 0x040258FC RID: 153852
		CheckExploreSkill,
		// Token: 0x040258FD RID: 153853
		CheckFightEnergyBar,
		// Token: 0x040258FE RID: 153854
		CheckFightEnergyBall,
		// Token: 0x040258FF RID: 153855
		FunctionUnlock,
		// Token: 0x04025900 RID: 153856
		GetNewItem,
		// Token: 0x04025901 RID: 153857
		HarmonyQte,
		// Token: 0x04025902 RID: 153858
		GetWhichRole,
		// Token: 0x04025903 RID: 153859
		HpLowerThan,
		// Token: 0x04025904 RID: 153860
		FightWithMonster,
		// Token: 0x04025905 RID: 153861
		PawnInRange,
		// Token: 0x04025906 RID: 153862
		SlotOfCurrentRole,
		// Token: 0x04025907 RID: 153863
		PhantomTargetLevel,
		// Token: 0x04025908 RID: 153864
		CheckClientQuest,
		// Token: 0x04025909 RID: 153865
		CheckClientQuestNode,
		// Token: 0x0402590A RID: 153866
		PhantomMaxLevel,
		// Token: 0x0402590B RID: 153867
		RoleTargetLevel,
		// Token: 0x0402590C RID: 153868
		RoleSkillTargetLevel,
		// Token: 0x0402590D RID: 153869
		BattleRoleIsNot,
		// Token: 0x0402590E RID: 153870
		BattleRoleWeaponType,
		// Token: 0x0402590F RID: 153871
		FormationAnyRoleDead,
		// Token: 0x04025910 RID: 153872
		ComboTeachingState,
		// Token: 0x04025911 RID: 153873
		OnViewClose,
		// Token: 0x04025912 RID: 153874
		OnPlayerUseSkill,
		// Token: 0x04025913 RID: 153875
		OnSkillButtonDataRefresh,
		// Token: 0x04025914 RID: 153876
		FinishGuideStepByEvent,
		// Token: 0x04025915 RID: 153877
		PlayerRevive,
		// Token: 0x04025916 RID: 153878
		CheckTeamRoleCouldLevelUp,
		// Token: 0x04025917 RID: 153879
		CheckTeamWeaponCouldLevelUp,
		// Token: 0x04025918 RID: 153880
		ClientCalabashLevel,
		// Token: 0x04025919 RID: 153881
		TeamRoleLevel,
		// Token: 0x0402591A RID: 153882
		TeamWeaponLevel,
		// Token: 0x0402591B RID: 153883
		TeamCouldEquipPhantom,
		// Token: 0x0402591C RID: 153884
		CheckAnyPhantomCouldUpdate,
		// Token: 0x0402591D RID: 153885
		CheckAnyRoleFullPhantom,
		// Token: 0x0402591E RID: 153886
		CheckRolePhantomNum,
		// Token: 0x0402591F RID: 153887
		CheckItemCountByType,
		// Token: 0x04025920 RID: 153888
		CheckRouletteEquipItemId,
		// Token: 0x04025921 RID: 153889
		CheckVisionIntensifyTabOpen,
		// Token: 0x04025922 RID: 153890
		CheckAccountSettingOpen,
		// Token: 0x04025923 RID: 153891
		CheckOnTreasureBoxOpen,
		// Token: 0x04025924 RID: 153892
		CheckWeaponCount,
		// Token: 0x04025925 RID: 153893
		CheckOnCostInsufficient,
		// Token: 0x04025926 RID: 153894
		CheckRangeByPbDataId,
		// Token: 0x04025927 RID: 153895
		CheckDungeonId,
		// Token: 0x04025928 RID: 153896
		CheckRogueTerm,
		// Token: 0x04025929 RID: 153897
		CheckTeleportTypeUnlock,
		// Token: 0x0402592A RID: 153898
		CheckTypeItemPickUp,
		// Token: 0x0402592B RID: 153899
		CheckDungeonFinished,
		// Token: 0x0402592C RID: 153900
		CheckRogueCanUnlockSkill,
		// Token: 0x0402592D RID: 153901
		CheckPositionRolePhantomSkillEquip,
		// Token: 0x0402592E RID: 153902
		CheckHasFirstPhantomAtPosition,
		// Token: 0x0402592F RID: 153903
		CheckWorldMapSecondaryUiOpened,
		// Token: 0x04025930 RID: 153904
		CheckHasUnlockAffixInBossRush,
		// Token: 0x04025931 RID: 153905
		OnChangeBossRushBuff,
		// Token: 0x04025932 RID: 153906
		RoguelikeHasSelectEntryAndShow,
		// Token: 0x04025933 RID: 153907
		CheckActivityOpen,
		// Token: 0x04025934 RID: 153908
		CheckHasSkinInRoleSkinSubView,
		// Token: 0x04025935 RID: 153909
		OnTakingPhoto,
		// Token: 0x04025936 RID: 153910
		HasNotInvitedRoleInSpring25,
		// Token: 0x04025937 RID: 153911
		CheckMapFocusByQuestId,
		// Token: 0x04025938 RID: 153912
		OnWorldMapGravityBtnShow,
		// Token: 0x04025939 RID: 153913
		PickupInTowerDefenceBattle,
		// Token: 0x0402593A RID: 153914
		CheckOnSelectMenuMainType,
		// Token: 0x0402593B RID: 153915
		OnShowPhantomInFormation,
		// Token: 0x0402593C RID: 153916
		ForMoonChasingCheckTargetBuiltCount,
		// Token: 0x0402593D RID: 153917
		ForMoonChasingCheckHasCanLevelUpBuilding,
		// Token: 0x0402593E RID: 153918
		ForMoonChasingCheckNeedBranch,
		// Token: 0x0402593F RID: 153919
		ForMoonChasingCheckHasNotFinishedTask,
		// Token: 0x04025940 RID: 153920
		ForMoonChasingCheckTaskState,
		// Token: 0x04025941 RID: 153921
		ForMoonChasingCheckMainlineTaskDone,
		// Token: 0x04025942 RID: 153922
		ForMoonChasingOpenInteractive,
		// Token: 0x04025943 RID: 153923
		CheckPureModeWhenBattleViewActive,
		// Token: 0x04025944 RID: 153924
		OnActivitySubViewDone,
		// Token: 0x04025945 RID: 153925
		CheckLockEnemyMode,
		// Token: 0x04025946 RID: 153926
		CheckIsShowProgressBarInMapExploreDetailView,
		// Token: 0x04025947 RID: 153927
		CheckIsMulti,
		// Token: 0x04025948 RID: 153928
		CheckFishingRoleTechViewOpen,
		// Token: 0x04025949 RID: 153929
		CheckFishingDockyardItemTipsShown,
		// Token: 0x0402594A RID: 153930
		CheckShipTowerTeamOpen,
		// Token: 0x0402594B RID: 153931
		CheckDockyardWareHouseHasItem,
		// Token: 0x0402594C RID: 153932
		CheckFishingQteBtnHitValidArea,
		// Token: 0x0402594D RID: 153933
		OnFishingQteScoreReachedMaximum,
		// Token: 0x0402594E RID: 153934
		CheckFishingTechUnlock,
		// Token: 0x0402594F RID: 153935
		OnFishingBackpackBtnStateChange,
		// Token: 0x04025950 RID: 153936
		CheckFishingEntrustState,
		// Token: 0x04025951 RID: 153937
		CheckFishingWareHouseItemListLength,
		// Token: 0x04025952 RID: 153938
		CheckCurFishingEntrustAvailablePeriod,
		// Token: 0x04025953 RID: 153939
		OnTreasureCompassUnitShow,
		// Token: 0x04025954 RID: 153940
		OnFishingBackpackQuickSellToggleShow,
		// Token: 0x04025955 RID: 153941
		HideSettingInCloudGame,
		// Token: 0x04025956 RID: 153942
		OnPlayerTitleUnlock,
		// Token: 0x04025957 RID: 153943
		CheckDangoMonopolyHasFinishedRound,
		// Token: 0x04025958 RID: 153944
		OnDangoMonopolyMoveStop,
		// Token: 0x04025959 RID: 153945
		OnDangoMonopolyViewShowProcessEnd,
		// Token: 0x0402595A RID: 153946
		OnDangoAbyssPluginRoleSelect,
		// Token: 0x0402595B RID: 153947
		CheckDangoMatchState,
		// Token: 0x0402595C RID: 153948
		CheckDangoMatchPlayerNumType,
		// Token: 0x0402595D RID: 153949
		OnEnterDangoMatchView,
		// Token: 0x0402595E RID: 153950
		OnDangoMonopolyViewStart,
		// Token: 0x0402595F RID: 153951
		OnCiacconaAvgInspirationChoiceShow,
		// Token: 0x04025960 RID: 153952
		OnCiacconaChapterFirstStart,
		// Token: 0x04025961 RID: 153953
		OnCiacconaChapterRestart,
		// Token: 0x04025962 RID: 153954
		OnMovieRogueInfoRefreshWithMultipleEnds,
		// Token: 0x04025963 RID: 153955
		CheckMovieRogueFinishedEndingCount,
		// Token: 0x04025964 RID: 153956
		OnDangoAbyssEnterWithTeamExploreBtn,
		// Token: 0x04025965 RID: 153957
		OnDangoAbyssEquipPluginWithValidChange,
		// Token: 0x04025966 RID: 153958
		OnDangoAbyssEquipPluginWithInvalid,
		// Token: 0x04025967 RID: 153959
		OnMovieRogueLinkRefresh,
		// Token: 0x04025968 RID: 153960
		OnMovieRogueMapMoveEnd,
		// Token: 0x04025969 RID: 153961
		OnMapRogueEventDetailShow,
		// Token: 0x0402596A RID: 153962
		CheckMapRogueEventDetailShow,
		// Token: 0x0402596B RID: 153963
		OnDangoMonopolyCameraFocusOnMainDango,
		// Token: 0x0402596C RID: 153964
		CheckDangoAbyssProgress,
		// Token: 0x0402596D RID: 153965
		CheckDangoAbyssHasItemByType,
		// Token: 0x0402596E RID: 153966
		CheckDangoMatchFinalEnd,
		// Token: 0x0402596F RID: 153967
		CheckGridHasExplored,
		// Token: 0x04025970 RID: 153968
		GolemHackingID,
		// Token: 0x04025971 RID: 153969
		WeeklyChallengeOpen,
		// Token: 0x04025972 RID: 153970
		OnUiTabViewShow,
		// Token: 0x04025973 RID: 153971
		OnNewViewCovered,
		// Token: 0x04025974 RID: 153972
		OnHandCardsShow,
		// Token: 0x04025975 RID: 153973
		OnCardDetailShowWithFactor,
		// Token: 0x04025976 RID: 153974
		OnMonsterNumReachLimit,
		// Token: 0x04025977 RID: 153975
		OnGetSpCard,
		// Token: 0x04025978 RID: 153976
		CheckPhantomArenaChallengeId,
		// Token: 0x04025979 RID: 153977
		CheckClientQuestNodeStatus,
		// Token: 0x0402597A RID: 153978
		CheckAnyMoraleAreaFinishWithReward,
		// Token: 0x0402597B RID: 153979
		OnMoraleTempExpItemShow,
		// Token: 0x0402597C RID: 153980
		OnPhantomArenaChildViewShow,
		// Token: 0x0402597D RID: 153981
		CheckNoMoraleAreaFinished,
		// Token: 0x0402597E RID: 153982
		OnFloroRanchCardCountReachTarget,
		// Token: 0x0402597F RID: 153983
		CheckFloroRanchRound,
		// Token: 0x04025980 RID: 153984
		FloroRanchActivityID,
		// Token: 0x04025981 RID: 153985
		CheckFloroRanchHasTechCanUnlock,
		// Token: 0x04025982 RID: 153986
		OnKingShipFirstAttrShow,
		// Token: 0x04025983 RID: 153987
		OnKingShipAllAttrShown,
		// Token: 0x04025984 RID: 153988
		OnFloroRanchSettleViewOpenWithEndlessMode,
		// Token: 0x04025985 RID: 153989
		CheckFloroRanchLevel,
		// Token: 0x04025986 RID: 153990
		OnFloroRanchStageStartTaskFinish,
		// Token: 0x04025987 RID: 153991
		CheckTrapDefenseTalentCanUnlock,
		// Token: 0x04025988 RID: 153992
		CheckTrapDefenseHasCanUpgradeMachine,
		// Token: 0x04025989 RID: 153993
		OnTrapDefenseAuxiliaryMachineUpgradeToMax,
		// Token: 0x0402598A RID: 153994
		OnTrapDefenseMachineCanChooseBranch,
		// Token: 0x0402598B RID: 153995
		CheckTrapDefenseLevelFinish,
		// Token: 0x0402598C RID: 153996
		CheckTrapDefenseRogueUnlock,
		// Token: 0x0402598D RID: 153997
		OnTrapDefenseBuffGroupUpgrade,
		// Token: 0x0402598E RID: 153998
		TrapDefenseTotalStar,
		// Token: 0x0402598F RID: 153999
		TrapDefensePassFullStar,
		// Token: 0x04025990 RID: 154000
		TrapDefenseChallengeStar,
		// Token: 0x04025991 RID: 154001
		OnTrapDefenseBuildingDevelopPreviewBtnShow,
		// Token: 0x04025992 RID: 154002
		OnTrapDefenseDeployingBuilding,
		// Token: 0x04025993 RID: 154003
		OnTrapDefenseBuildingDevelopBottomLayoutShow,
		// Token: 0x04025994 RID: 154004
		CheckTrapDefenseMachineLevel,
		// Token: 0x04025995 RID: 154005
		CheckTrapDefenseTalentUnlock,
		// Token: 0x04025996 RID: 154006
		OnTrapDefenseMainLevelViewOpen,
		// Token: 0x04025997 RID: 154007
		OnVisionIntensifyViewShow,
		// Token: 0x04025998 RID: 154008
		OnSurvivorsRogueEndlessToggleShow,
		// Token: 0x04025999 RID: 154009
		OnSurvivorsRogueComboBuffShow,
		// Token: 0x0402599A RID: 154010
		CheckFightPhotoHasTarget,
		// Token: 0x0402599B RID: 154011
		CheckFightPhotoLevelFinished,
		// Token: 0x0402599C RID: 154012
		CheckCalabashChildFunctionOpen,
		// Token: 0x0402599D RID: 154013
		OnSurvivorsRoguePopViewRefresh,
		// Token: 0x0402599E RID: 154014
		CheckSurvivorRogueTalentCanUnlock,
		// Token: 0x0402599F RID: 154015
		CheckSurvivorRogueHasWeaponBond,
		// Token: 0x040259A0 RID: 154016
		OnSurvivorsRogueWeaponDetailTabViewShow,
		// Token: 0x040259A1 RID: 154017
		AlwaysFalse,
		// Token: 0x040259A2 RID: 154018
		OnEnterOrExitBattle,
		// Token: 0x040259A3 RID: 154019
		OnHonamiStoryLifeSupportChange,
		// Token: 0x040259A4 RID: 154020
		OnPickUpHonamiStoryItem,
		// Token: 0x040259A5 RID: 154021
		OnSceneItemDurabilityEmpty,
		// Token: 0x040259A6 RID: 154022
		CheckPickUpHonamiStoryItemType,
		// Token: 0x040259A7 RID: 154023
		IsHasRecommendRecActivity,
		// Token: 0x040259A8 RID: 154024
		CheckMotorMovieModeStateChange,
		// Token: 0x040259A9 RID: 154025
		OnMotorMusicPlayerShow,
		// Token: 0x040259AA RID: 154026
		OnMapCustomMarkPanelShow,
		// Token: 0x040259AB RID: 154027
		OnPhantomArenaChooseCardPanelShow,
		// Token: 0x040259AC RID: 154028
		OnPhantomArenaDiscardCardPanelShow,
		// Token: 0x040259AD RID: 154029
		OnMotorDiyViewShow,
		// Token: 0x040259AE RID: 154030
		OnPhantomArenaPlayFieldEffect,
		// Token: 0x040259AF RID: 154031
		OnRollBlockDifficultyChanged,
		// Token: 0x040259B0 RID: 154032
		CheckDungeonTypes,
		// Token: 0x040259B1 RID: 154033
		OnEnterWheelTowerEndlessMode,
		// Token: 0x040259B2 RID: 154034
		OnGuideTriggerEvent,
		// Token: 0x040259B3 RID: 154035
		CheckUiItemShow,
		// Token: 0x040259B4 RID: 154036
		CheckExploreSkillFlag,
		// Token: 0x040259B5 RID: 154037
		CheckGuessJokerRound,
		// Token: 0x040259B6 RID: 154038
		CheckMotorFightLevelFinished,
		// Token: 0x040259B7 RID: 154039
		CheckEncircleChallengeId,
		// Token: 0x040259B8 RID: 154040
		OnFlagChallengeCalculatedLevelOver,
		// Token: 0x040259B9 RID: 154041
		CheckTetrisLevelId,
		// Token: 0x040259BA RID: 154042
		CheckRhythmShipSubLevelHasRank,
		// Token: 0x040259BB RID: 154043
		CheckDropCatchGameplayId,
		// Token: 0x040259BC RID: 154044
		CheckTetrisScore,
		// Token: 0x040259BD RID: 154045
		CheckNewPlayerSupportV2,
		// Token: 0x040259BE RID: 154046
		CheckPinballLevelPass,
		// Token: 0x040259BF RID: 154047
		CheckPinballWeaponCount,
		// Token: 0x040259C0 RID: 154048
		OnNormalTopViewChange,
		// Token: 0x040259C1 RID: 154049
		CheckPopIsTargetOrEmpty,
		// Token: 0x040259C2 RID: 154050
		CheckKurotatoLevelWave,
		// Token: 0x040259C3 RID: 154051
		CheckKurotatoLevelFinished,
		// Token: 0x040259C4 RID: 154052
		CheckTrialRole,
		// Token: 0x040259C5 RID: 154053
		CheckInteractiveItemsFunctionEnable,
		// Token: 0x040259C6 RID: 154054
		CheckPhantomTeam,
		// Token: 0x040259C7 RID: 154055
		CheckTrialAssist,
		// Token: 0x040259C8 RID: 154056
		CheckQuestClosedSegment,
		// Token: 0x040259C9 RID: 154057
		CheckGameplayClosedSegment,
		// Token: 0x040259CA RID: 154058
		CheckOperationRestrict,
		// Token: 0x040259CB RID: 154059
		CheckCameraMode,
		// Token: 0x040259CC RID: 154060
		CheckCharacterMotionState,
		// Token: 0x040259CD RID: 154061
		CheckCharacterTagsRestrict,
		// Token: 0x040259CE RID: 154062
		CheckInteracting,
		// Token: 0x040259CF RID: 154063
		CheckRoverlikeInstPassed,
		// Token: 0x040259D0 RID: 154064
		CheckSubPackageDownLoadBtnShow,
		// Token: 0x040259D1 RID: 154065
		CheckFightSpecialEnergyFull,
		// Token: 0x040259D2 RID: 154066
		CheckNewbieGuideV2
	}
}
