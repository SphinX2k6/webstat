using System;

namespace CSharpScript.Game.Common
{
	// Token: 0x02007063 RID: 28771
	public enum ELocalStoragePlayerKey
	{
		// Token: 0x04026EFF RID: 159487
		FirstOpenShop,
		// Token: 0x04026F00 RID: 159488
		CookerLevelKey,
		// Token: 0x04026F01 RID: 159489
		EditBattleTeam,
		// Token: 0x04026F02 RID: 159490
		GachaPoolOpenRecord,
		// Token: 0x04026F03 RID: 159491
		InventoryCommonItem,
		// Token: 0x04026F04 RID: 159492
		InventoryAttributeItem,
		// Token: 0x04026F05 RID: 159493
		InventoryCommonItemRedDot,
		// Token: 0x04026F06 RID: 159494
		InventoryAttributeItemRedDot,
		// Token: 0x04026F07 RID: 159495
		RouletteAssemblyItemRedDot,
		// Token: 0x04026F08 RID: 159496
		GetItemConfigListSaveKey,
		// Token: 0x04026F09 RID: 159497
		ComposeLevelKey,
		// Token: 0x04026F0A RID: 159498
		ForgingLevelKey,
		// Token: 0x04026F0B RID: 159499
		Chat,
		// Token: 0x04026F0C RID: 159500
		BattlePassPayButton,
		// Token: 0x04026F0D RID: 159501
		MonthCardNextShowRedDotTime,
		// Token: 0x04026F0E RID: 159502
		IsErrorChatReplace,
		// Token: 0x04026F0F RID: 159503
		LocalFriendApplication,
		// Token: 0x04026F10 RID: 159504
		MarqueeScrollingMap,
		// Token: 0x04026F11 RID: 159505
		LoginTime,
		// Token: 0x04026F12 RID: 159506
		LastTimeUploadStamp,
		// Token: 0x04026F13 RID: 159507
		Activity,
		// Token: 0x04026F14 RID: 159508
		IsTriggerMobileGuide,
		// Token: 0x04026F15 RID: 159509
		IsTriggerDesktopGuide,
		// Token: 0x04026F16 RID: 159510
		AutoInteractionGuideAppearCount,
		// Token: 0x04026F17 RID: 159511
		IsSimpleDetail,
		// Token: 0x04026F18 RID: 159512
		VisionSpecialSkillShowMap,
		// Token: 0x04026F19 RID: 159513
		ItemGridDropDown,
		// Token: 0x04026F1A RID: 159514
		HasShowNewMailTipsMap,
		// Token: 0x04026F1B RID: 159515
		RoguelikeDescModel,
		// Token: 0x04026F1C RID: 159516
		RoleDataItem,
		// Token: 0x04026F1D RID: 159517
		PersonalDataItem,
		// Token: 0x04026F1E RID: 159518
		CalabashCollect,
		// Token: 0x04026F1F RID: 159519
		CalabashCollectIsSimpleDetail,
		// Token: 0x04026F20 RID: 159520
		RoguelikeShopRecord,
		// Token: 0x04026F21 RID: 159521
		RoguelikeShopNextTimeStamp,
		// Token: 0x04026F22 RID: 159522
		VisionSkin,
		// Token: 0x04026F23 RID: 159523
		SilentTips,
		// Token: 0x04026F24 RID: 159524
		GachaRoleRecord,
		// Token: 0x04026F25 RID: 159525
		GachaWeaponRecord,
		// Token: 0x04026F26 RID: 159526
		RouletteAction01OpenConfig,
		// Token: 0x04026F27 RID: 159527
		RouletteAction02OpenConfig,
		// Token: 0x04026F28 RID: 159528
		MoonChasingShopItemUnlock,
		// Token: 0x04026F29 RID: 159529
		MoonChasingShopItemChecked,
		// Token: 0x04026F2A RID: 159530
		MoonChasingRoleUnlock,
		// Token: 0x04026F2B RID: 159531
		MoonChasingQuestUnlock,
		// Token: 0x04026F2C RID: 159532
		MoonChasingMemoryChecked,
		// Token: 0x04026F2D RID: 159533
		LoopTowerIsClickSeason,
		// Token: 0x04026F2E RID: 159534
		LoopTowerIsClickShop,
		// Token: 0x04026F2F RID: 159535
		TowerOverLockArea,
		// Token: 0x04026F30 RID: 159536
		ActivityRecallWatchFirstShow,
		// Token: 0x04026F31 RID: 159537
		ActivityRecallSplashFirstShowTime,
		// Token: 0x04026F32 RID: 159538
		ActivityRecallWatchFirstShowTime,
		// Token: 0x04026F33 RID: 159539
		ActivityRegressSignLastDailyFirstShowTimeStamp,
		// Token: 0x04026F34 RID: 159540
		ActivityRegressShopRedDotCheckedInPeriod,
		// Token: 0x04026F35 RID: 159541
		ActivityRegressQuestionnaireRedDotCheckedInPeriod,
		// Token: 0x04026F36 RID: 159542
		ActivityRegressSecondQuestionnaireRedDotCheckedInPeriod,
		// Token: 0x04026F37 RID: 159543
		ActivityRegressDoubleDropReminderLastShowTime,
		// Token: 0x04026F38 RID: 159544
		ActivityRegressDoubleDropFirstRedDotCheckedInPeriod,
		// Token: 0x04026F39 RID: 159545
		ActivityRegressBpPayButtonRedDotCheckedInPeriod,
		// Token: 0x04026F3A RID: 159546
		ActivityRegressTrialRoleRedDotCheckedInPeriod,
		// Token: 0x04026F3B RID: 159547
		ActivityRegressDoubleDropRedDotCheckedInPeriod,
		// Token: 0x04026F3C RID: 159548
		ActivityRegressRecommendRedDotCheckedInPeriod,
		// Token: 0x04026F3D RID: 159549
		ActivityRegressAdventureRedDotCheckedInPeriod,
		// Token: 0x04026F3E RID: 159550
		TowerDefenseEntered,
		// Token: 0x04026F3F RID: 159551
		VersionPreheatToQuestClicked,
		// Token: 0x04026F40 RID: 159552
		VersionPreheatBonusClicked,
		// Token: 0x04026F41 RID: 159553
		VersionPreheatToQuestPlayed,
		// Token: 0x04026F42 RID: 159554
		VersionPreheatBonusPlayed,
		// Token: 0x04026F43 RID: 159555
		Spring25FirstTimeTaskAllDone,
		// Token: 0x04026F44 RID: 159556
		Spring25FirstDoneTaskIndex,
		// Token: 0x04026F45 RID: 159557
		Spring25FirstLetterClick,
		// Token: 0x04026F46 RID: 159558
		Spring25FirstEnter,
		// Token: 0x04026F47 RID: 159559
		MoonChasingDelegation,
		// Token: 0x04026F48 RID: 159560
		ShowPersonalTip,
		// Token: 0x04026F49 RID: 159561
		HasCleanInvalidCustomMark,
		// Token: 0x04026F4A RID: 159562
		SortConfig,
		// Token: 0x04026F4B RID: 159563
		FilterConfig,
		// Token: 0x04026F4C RID: 159564
		FragmentMemoryOpened,
		// Token: 0x04026F4D RID: 159565
		VisionRecoveryBatchTip,
		// Token: 0x04026F4E RID: 159566
		VisionRecoveryBatchAimTip,
		// Token: 0x04026F4F RID: 159567
		VisionRefineTip,
		// Token: 0x04026F50 RID: 159568
		AuToTrackQuestTime,
		// Token: 0x04026F51 RID: 159569
		GoodsRemindMap,
		// Token: 0x04026F52 RID: 159570
		WeaponSkinRedDot,
		// Token: 0x04026F53 RID: 159571
		FlySkinRedDot,
		// Token: 0x04026F54 RID: 159572
		CalabashSkinRedDot,
		// Token: 0x04026F55 RID: 159573
		MowingRiskIsInstanceNew,
		// Token: 0x04026F56 RID: 159574
		TowerDefenseNewLevel,
		// Token: 0x04026F57 RID: 159575
		MailBindNextShowRedDotTime,
		// Token: 0x04026F58 RID: 159576
		ShowSkillResume,
		// Token: 0x04026F59 RID: 159577
		ShowSkillShowTag,
		// Token: 0x04026F5A RID: 159578
		GamepadUsageRecord,
		// Token: 0x04026F5B RID: 159579
		RedDotAdventureNewSoundAreaTabLastUpdateTime,
		// Token: 0x04026F5C RID: 159580
		VisionLevelUpMaterialPutInMode,
		// Token: 0x04026F5D RID: 159581
		VisionLevelUpMaterialUseType,
		// Token: 0x04026F5E RID: 159582
		VisionLevelUpSettingRedDot,
		// Token: 0x04026F5F RID: 159583
		VisionLevelUpIdentifyRedDot,
		// Token: 0x04026F60 RID: 159584
		DirectTrainGotoRedDotHaveDisplayed,
		// Token: 0x04026F61 RID: 159585
		DirectTrainGotoRedDotHaveDisplayedByActId,
		// Token: 0x04026F62 RID: 159586
		DirectTrainMakeRoleChange,
		// Token: 0x04026F63 RID: 159587
		DetectionRedDotRecord,
		// Token: 0x04026F64 RID: 159588
		SuitWeaponFirstWearRecord,
		// Token: 0x04026F65 RID: 159589
		RoleSkinRedDot,
		// Token: 0x04026F66 RID: 159590
		NewLordGymEntranceIdRecord,
		// Token: 0x04026F67 RID: 159591
		SailingIsFix,
		// Token: 0x04026F68 RID: 159592
		VisionTopTipsState,
		// Token: 0x04026F69 RID: 159593
		FirstOpenVisionGroup,
		// Token: 0x04026F6A RID: 159594
		ShipTowerSeason,
		// Token: 0x04026F6B RID: 159595
		AdventrueShipTowerSeason,
		// Token: 0x04026F6C RID: 159596
		AdventrueWeeklyRogue,
		// Token: 0x04026F6D RID: 159597
		AdventrueTower,
		// Token: 0x04026F6E RID: 159598
		DockyardListItemRead,
		// Token: 0x04026F6F RID: 159599
		FilterRedPoint,
		// Token: 0x04026F70 RID: 159600
		SolarSpeedInstanceClicked,
		// Token: 0x04026F71 RID: 159601
		PayShopTabItemChecked,
		// Token: 0x04026F72 RID: 159602
		FishingHandBookItemRecord,
		// Token: 0x04026F73 RID: 159603
		FishingShipSkinRecord,
		// Token: 0x04026F74 RID: 159604
		ShipTowerGetBuffSet,
		// Token: 0x04026F75 RID: 159605
		ShipTowerExchangeInstId,
		// Token: 0x04026F76 RID: 159606
		ExploreActivityFirstUnlock,
		// Token: 0x04026F77 RID: 159607
		PlayerTitleRecord,
		// Token: 0x04026F78 RID: 159608
		PlayerTitleUnlockRedDot,
		// Token: 0x04026F79 RID: 159609
		VersionRedDotMap,
		// Token: 0x04026F7A RID: 159610
		BabelTowerNewLevel,
		// Token: 0x04026F7B RID: 159611
		BabelTowerNewLevelHasClick,
		// Token: 0x04026F7C RID: 159612
		InviteNewbieEntered,
		// Token: 0x04026F7D RID: 159613
		AbyssDangoFormationSelect,
		// Token: 0x04026F7E RID: 159614
		RogueResDungeonNewest,
		// Token: 0x04026F7F RID: 159615
		RogueResSkillTreeOpen,
		// Token: 0x04026F80 RID: 159616
		RogueResEndingOpen,
		// Token: 0x04026F81 RID: 159617
		RogueResShopRefresh,
		// Token: 0x04026F82 RID: 159618
		RogueResShopNewGoods,
		// Token: 0x04026F83 RID: 159619
		RogueResTaskOpen,
		// Token: 0x04026F84 RID: 159620
		RogueResTrialOpen,
		// Token: 0x04026F85 RID: 159621
		RogueResNewRoleFlag,
		// Token: 0x04026F86 RID: 159622
		RogueResMapScale,
		// Token: 0x04026F87 RID: 159623
		DangoMonopolyActivityId,
		// Token: 0x04026F88 RID: 159624
		DangoMonopolySpeed,
		// Token: 0x04026F89 RID: 159625
		DangoMonopolyLastEnterBoard,
		// Token: 0x04026F8A RID: 159626
		DangoMonopolyNewTask,
		// Token: 0x04026F8B RID: 159627
		RacingBetsMatchViewRecord,
		// Token: 0x04026F8C RID: 159628
		RacingBetsRankViewRecord,
		// Token: 0x04026F8D RID: 159629
		RacingBetsReplayGameRecord,
		// Token: 0x04026F8E RID: 159630
		RacingBetsWatchGameRecord,
		// Token: 0x04026F8F RID: 159631
		RacingBetsSettlementMainViewRecord,
		// Token: 0x04026F90 RID: 159632
		RacingBetsBettingMainViewRecord,
		// Token: 0x04026F91 RID: 159633
		RacingBetsBulletScreenAlphaRecord,
		// Token: 0x04026F92 RID: 159634
		RacingBetsBulletScreenShowTypeRecord,
		// Token: 0x04026F93 RID: 159635
		SdkReportStateMap,
		// Token: 0x04026F94 RID: 159636
		PayShopRechargeRedDot,
		// Token: 0x04026F95 RID: 159637
		ShowNoteIdMap,
		// Token: 0x04026F96 RID: 159638
		AbyssSelectRole,
		// Token: 0x04026F97 RID: 159639
		AbyssDangoLevelCheck,
		// Token: 0x04026F98 RID: 159640
		AbyssDangoRoleNew,
		// Token: 0x04026F99 RID: 159641
		AbyssDangoEnterNew,
		// Token: 0x04026F9A RID: 159642
		AbyssDangoFormationNew,
		// Token: 0x04026F9B RID: 159643
		RogueResDungeonSelected,
		// Token: 0x04026F9C RID: 159644
		IsDirectTrainProOpened,
		// Token: 0x04026F9D RID: 159645
		PhantomArenaEntranceShopRefresh,
		// Token: 0x04026F9E RID: 159646
		PhantomArenaEntranceGymCheck,
		// Token: 0x04026F9F RID: 159647
		PhantomArenaRepeatLastIndex,
		// Token: 0x04026FA0 RID: 159648
		PhantomArenaEntranceGymRedDotCheck,
		// Token: 0x04026FA1 RID: 159649
		QuestReviewNodeRedDot,
		// Token: 0x04026FA2 RID: 159650
		QuestReviewNodeUnlockAnim,
		// Token: 0x04026FA3 RID: 159651
		QuestReviewLineUnlockAnim,
		// Token: 0x04026FA4 RID: 159652
		QuestReviewLineDestroyAnim,
		// Token: 0x04026FA5 RID: 159653
		QuestReviewTabUnlockAnim,
		// Token: 0x04026FA6 RID: 159654
		QuestReviewMainViewEntryAnim,
		// Token: 0x04026FA7 RID: 159655
		QuestReviewHasFused,
		// Token: 0x04026FA8 RID: 159656
		QuestReviewNewLineHasFused,
		// Token: 0x04026FA9 RID: 159657
		BeginnerCarnivalShop,
		// Token: 0x04026FAA RID: 159658
		BeginnerCarnivalGacha,
		// Token: 0x04026FAB RID: 159659
		BeginnerCarnivalChoseRoleView,
		// Token: 0x04026FAC RID: 159660
		FloroRanchSpeed,
		// Token: 0x04026FAD RID: 159661
		MoraleAreaUnlockFlagSet,
		// Token: 0x04026FAE RID: 159662
		MoraleTipsAreaBuff,
		// Token: 0x04026FAF RID: 159663
		MoraleActiveAreaBuff,
		// Token: 0x04026FB0 RID: 159664
		RoleTutorialNew,
		// Token: 0x04026FB1 RID: 159665
		AdventrueItemNew,
		// Token: 0x04026FB2 RID: 159666
		VisionSuitFilter,
		// Token: 0x04026FB3 RID: 159667
		FloroRanchSkillId,
		// Token: 0x04026FB4 RID: 159668
		FloroRanchSkillIdWeekly,
		// Token: 0x04026FB5 RID: 159669
		CustomizedThumbnailShow,
		// Token: 0x04026FB6 RID: 159670
		VisionLevelUpIdentify,
		// Token: 0x04026FB7 RID: 159671
		FloroRanchSelectedRaceIds,
		// Token: 0x04026FB8 RID: 159672
		FloroRanchSkillRedDot,
		// Token: 0x04026FB9 RID: 159673
		FloroRanchCardRedDot,
		// Token: 0x04026FBA RID: 159674
		FloroRanchCardInGameRedDot,
		// Token: 0x04026FBB RID: 159675
		FloroRanchToyRedDot,
		// Token: 0x04026FBC RID: 159676
		FloroRanchRaceRedDot,
		// Token: 0x04026FBD RID: 159677
		WeeklyRogueExtraEnterTips,
		// Token: 0x04026FBE RID: 159678
		LoopTowerSeason,
		// Token: 0x04026FBF RID: 159679
		IntroductionVersion,
		// Token: 0x04026FC0 RID: 159680
		TrapDefenseBuildingClicked,
		// Token: 0x04026FC1 RID: 159681
		TrapDefenseAuxiliaryClicked,
		// Token: 0x04026FC2 RID: 159682
		TrapDefenseBdBuffUnlock,
		// Token: 0x04026FC3 RID: 159683
		TrapDefenseLevelReachOpenTime,
		// Token: 0x04026FC4 RID: 159684
		TrapDefenseRougeModeOpen,
		// Token: 0x04026FC5 RID: 159685
		TrapDefenseRougeModeOpenSub,
		// Token: 0x04026FC6 RID: 159686
		SurvivorsHandbookClicked,
		// Token: 0x04026FC7 RID: 159687
		FightPhotoLevelRedDot,
		// Token: 0x04026FC8 RID: 159688
		QuestTreeNodeNewTag,
		// Token: 0x04026FC9 RID: 159689
		SubDownLoadAgreeUseCellData,
		// Token: 0x04026FCA RID: 159690
		SubDownLoadLastDownLoadList,
		// Token: 0x04026FCB RID: 159691
		HonamiStoryMascotUnlockSet,
		// Token: 0x04026FCC RID: 159692
		HonamiStoryWeaponUnlockSet,
		// Token: 0x04026FCD RID: 159693
		HonamiStoryMainButtonUnlockSet,
		// Token: 0x04026FCE RID: 159694
		HonamiStorySelectLvAreaUnLockTips,
		// Token: 0x04026FCF RID: 159695
		HonamiStorySelectLvUnLockTips,
		// Token: 0x04026FD0 RID: 159696
		HonamiStorySelectLvTowerUnLockTips,
		// Token: 0x04026FD1 RID: 159697
		HonamiStorySelectLvTowerUnLockTogRedDot,
		// Token: 0x04026FD2 RID: 159698
		HonamiStorySelectLvTowerUnLockBtnGoRedDot,
		// Token: 0x04026FD3 RID: 159699
		HonamiStorySkillDescMode,
		// Token: 0x04026FD4 RID: 159700
		FirstOpenCommonWeaponSelect,
		// Token: 0x04026FD5 RID: 159701
		SubDownLoadClearOnLogin,
		// Token: 0x04026FD6 RID: 159702
		MotorcycleMusicRedDot,
		// Token: 0x04026FD7 RID: 159703
		MotorcycleCurPlayAlbumId,
		// Token: 0x04026FD8 RID: 159704
		MotorcycleCurPlayMusicId,
		// Token: 0x04026FD9 RID: 159705
		MotorcyclePlayMode,
		// Token: 0x04026FDA RID: 159706
		FirstUnlockArtemisDayMap,
		// Token: 0x04026FDB RID: 159707
		FirstPlayArtemisPlaneAnimMap,
		// Token: 0x04026FDC RID: 159708
		RemindCanUpgradedLaHaiLuo,
		// Token: 0x04026FDD RID: 159709
		RemindCanUpgradedRiLing,
		// Token: 0x04026FDE RID: 159710
		InfrRecordObservatoryLevel,
		// Token: 0x04026FDF RID: 159711
		InfrRoadMarkUnlockRecord,
		// Token: 0x04026FE0 RID: 159712
		InfrObservatoryLevelUpSeq,
		// Token: 0x04026FE1 RID: 159713
		MapNPCMarkShowSeq,
		// Token: 0x04026FE2 RID: 159714
		RegionalTerminalBarFoldState,
		// Token: 0x04026FE3 RID: 159715
		PhantomArenaChallengeUnlockRedDotCheck,
		// Token: 0x04026FE4 RID: 159716
		PhantomArenaMapUnlockRedDotCheck,
		// Token: 0x04026FE5 RID: 159717
		MotorParkourLevelClicked,
		// Token: 0x04026FE6 RID: 159718
		CyberPunkBossEntranceFirstClicked,
		// Token: 0x04026FE7 RID: 159719
		WeatherCentralClicked,
		// Token: 0x04026FE8 RID: 159720
		PhantomInteractNewUnlock,
		// Token: 0x04026FE9 RID: 159721
		NewPlayerSupportTrialRoleEntranceRedDot,
		// Token: 0x04026FEA RID: 159722
		TrialRoleGroupUnlock,
		// Token: 0x04026FEB RID: 159723
		ActivityNewPlayerSupportFirstShow,
		// Token: 0x04026FEC RID: 159724
		MotorDevelopIsFirstDailyExpLimit,
		// Token: 0x04026FED RID: 159725
		MotorDevelopNewUnlockTree,
		// Token: 0x04026FEE RID: 159726
		MotorDiyNewUnlockId,
		// Token: 0x04026FEF RID: 159727
		MotorFightLevelClicked,
		// Token: 0x04026FF0 RID: 159728
		MotorFightItemClicked,
		// Token: 0x04026FF1 RID: 159729
		MotorFightRoleClicked,
		// Token: 0x04026FF2 RID: 159730
		DrinksUnlockLevelClicked,
		// Token: 0x04026FF3 RID: 159731
		GuessJokerUnlockLevelClicked,
		// Token: 0x04026FF4 RID: 159732
		GuessJokerFirstFinishAnim,
		// Token: 0x04026FF5 RID: 159733
		FlagChallengeFormationRoleIds,
		// Token: 0x04026FF6 RID: 159734
		FeedbackRewardHaveShowRewardId,
		// Token: 0x04026FF7 RID: 159735
		SpringManorBrochureUnlockSequencePlayed,
		// Token: 0x04026FF8 RID: 159736
		CoopLevelFirstRedDotClicked,
		// Token: 0x04026FF9 RID: 159737
		CoopPhotoRedDotClicked,
		// Token: 0x04026FFA RID: 159738
		PhantomDiscardPlanRecycleSet,
		// Token: 0x04026FFB RID: 159739
		RhythmShipLocalCalibrationValue,
		// Token: 0x04026FFC RID: 159740
		RhythmShipHavePlayAniLevelId,
		// Token: 0x04026FFD RID: 159741
		BossPilingQuestClicked,
		// Token: 0x04026FFE RID: 159742
		BossPilingLevelNew,
		// Token: 0x04026FFF RID: 159743
		RoguelikeInstanceSelectGroupIndex,
		// Token: 0x04027000 RID: 159744
		RoguelikeInstanceSelectEntryId,
		// Token: 0x04027001 RID: 159745
		RoguelikeFormationIdList,
		// Token: 0x04027002 RID: 159746
		RoguelikeSelectPhantomId,
		// Token: 0x04027003 RID: 159747
		RoleVoiceMap,
		// Token: 0x04027004 RID: 159748
		RoleTrialRemindMap,
		// Token: 0x04027005 RID: 159749
		GolemHackingBonusLevelGroupPlayed,
		// Token: 0x04027006 RID: 159750
		GolemHackingActivityLevelTime,
		// Token: 0x04027007 RID: 159751
		ShouldSaveCaptureCollectFlag,
		// Token: 0x04027008 RID: 159752
		FirstOpenDailyActivityDailyTab,
		// Token: 0x04027009 RID: 159753
		FirstOpenDailyActivityWeeklyTab,
		// Token: 0x0402700A RID: 159754
		IgnoreWheelTowerSeasonReviewMedalCheck,
		// Token: 0x0402700B RID: 159755
		RoguelikeShopItemChecked,
		// Token: 0x0402700C RID: 159756
		SheriffHideCompletedMarkItem,
		// Token: 0x0402700D RID: 159757
		SubPackageRecommendConfirmShown,
		// Token: 0x0402700E RID: 159758
		RoleLangCustomRecord,
		// Token: 0x0402700F RID: 159759
		RoverRogueLastPassRoleType,
		// Token: 0x04027010 RID: 159760
		UseFormation3DView,
		// Token: 0x04027011 RID: 159761
		RoverRogueSeenUnlockedInsIds,
		// Token: 0x04027012 RID: 159762
		RoverRogueSeenUnlockedBlessIds,
		// Token: 0x04027013 RID: 159763
		RoverRogueSeenUnlockedLootIds
	}
}
