using System;

// Token: 0x02001A81 RID: 6785
public enum EConfirmBoxConfigId
{
	// Token: 0x04005AFB RID: 23291
	Default = -1,
	// Token: 0x04005AFC RID: 23292
	WeaponLevelUpThreeCondition = 1,
	// Token: 0x04005AFD RID: 23293
	WeaponLevelUpTwoCondition,
	// Token: 0x04005AFE RID: 23294
	WeaponLevelUpOneCondition,
	// Token: 0x04005AFF RID: 23295
	BattleViewLeaveInstance,
	// Token: 0x04005B00 RID: 23296
	EditBattleTeamCreate,
	// Token: 0x04005B01 RID: 23297
	EditBattleTeamExit,
	// Token: 0x04005B02 RID: 23298
	EditBattleTeamDisband,
	// Token: 0x04005B03 RID: 23299
	EditBattleTeam,
	// Token: 0x04005B04 RID: 23300
	MingsuTip,
	// Token: 0x04005B05 RID: 23301
	NetTip,
	// Token: 0x04005B06 RID: 23302
	MultiplayerTeamTip,
	// Token: 0x04005B07 RID: 23303
	PhantomCultureTip,
	// Token: 0x04005B08 RID: 23304
	RoleResonanceLevelUpTip,
	// Token: 0x04005B09 RID: 23305
	RoleResonanceActiveTip,
	// Token: 0x04005B0A RID: 23306
	TapeLevelUpHighQualityHighLevel,
	// Token: 0x04005B0B RID: 23307
	TapeLevelUpHighQuality,
	// Token: 0x04005B0C RID: 23308
	TapeLevelUpHighLevel,
	// Token: 0x04005B0D RID: 23309
	TapeEquipmentTip,
	// Token: 0x04005B0E RID: 23310
	TapeTransTip,
	// Token: 0x04005B0F RID: 23311
	TapeTransHasHighLevelTip,
	// Token: 0x04005B10 RID: 23312
	WeaponResonanceTip,
	// Token: 0x04005B11 RID: 23313
	WeaponEquipmentTip,
	// Token: 0x04005B12 RID: 23314
	RoleLevelUpExpTip,
	// Token: 0x04005B13 RID: 23315
	WeaponOverflowExpTip,
	// Token: 0x04005B14 RID: 23316
	WeaponResonanceHasResonance,
	// Token: 0x04005B15 RID: 23317
	WeaponResonanceHasStrength,
	// Token: 0x04005B16 RID: 23318
	WeaponResonanceBoth,
	// Token: 0x04005B17 RID: 23319
	MingsuTipByMoreCore,
	// Token: 0x04005B18 RID: 23320
	PhantomCultureTipWithSkill,
	// Token: 0x04005B19 RID: 23321
	NetWorkMaskTip,
	// Token: 0x04005B1A RID: 23322
	PhantomEquipRoleTip,
	// Token: 0x04005B1B RID: 23323
	PhantomUnEquipRoleTip,
	// Token: 0x04005B1C RID: 23324
	ErrorCodeTips,
	// Token: 0x04005B1D RID: 23325
	PhantomUnEquipOtherRoleTip,
	// Token: 0x04005B1E RID: 23326
	PowerNotEnoughForDungeon,
	// Token: 0x04005B1F RID: 23327
	ShowTimeDownTips,
	// Token: 0x04005B20 RID: 23328
	UseBuffItemToMaxLifeRoleTips,
	// Token: 0x04005B21 RID: 23329
	BackLoginView,
	// Token: 0x04005B22 RID: 23330
	NetWorkExcept,
	// Token: 0x04005B23 RID: 23331
	HasNewVersion,
	// Token: 0x04005B24 RID: 23332
	HasPatch,
	// Token: 0x04005B25 RID: 23333
	ServerMaintenance,
	// Token: 0x04005B26 RID: 23334
	ClientIntegrity,
	// Token: 0x04005B27 RID: 23335
	LogoutAccount,
	// Token: 0x04005B28 RID: 23336
	CreateCharacterSecondConfirm,
	// Token: 0x04005B29 RID: 23337
	RegionQuestGiveUpConfirm,
	// Token: 0x04005B2A RID: 23338
	MenuRestart,
	// Token: 0x04005B2B RID: 23339
	OneMailBeingDeleted,
	// Token: 0x04005B2C RID: 23340
	ScannedMailsBeingDeleted,
	// Token: 0x04005B2D RID: 23341
	MaintenanceNotice,
	// Token: 0x04005B2E RID: 23342
	ExitGame,
	// Token: 0x04005B2F RID: 23343
	CreateCharacterNameTooLong,
	// Token: 0x04005B30 RID: 23344
	CreateCharacterNameIllegal,
	// Token: 0x04005B31 RID: 23345
	AppVersionNotMatch,
	// Token: 0x04005B32 RID: 23346
	DefaultExploreSet,
	// Token: 0x04005B33 RID: 23347
	DeleteFriend,
	// Token: 0x04005B34 RID: 23348
	BlockFriend,
	// Token: 0x04005B35 RID: 23349
	SaveExploreSet,
	// Token: 0x04005B36 RID: 23350
	IgnoreAllFriendApplication,
	// Token: 0x04005B37 RID: 23351
	ExchangeNoEnough,
	// Token: 0x04005B38 RID: 23352
	GachaCurrency,
	// Token: 0x04005B39 RID: 23353
	SecondCurrency,
	// Token: 0x04005B3A RID: 23354
	FirstCurrency,
	// Token: 0x04005B3B RID: 23355
	ReceiveLevelPlayReward,
	// Token: 0x04005B3C RID: 23356
	BreachPreview,
	// Token: 0x04005B3D RID: 23357
	DecomposePreview,
	// Token: 0x04005B3E RID: 23358
	GachaIsInValid,
	// Token: 0x04005B3F RID: 23359
	GachaRefresh,
	// Token: 0x04005B40 RID: 23360
	GachaTimeIsMax,
	// Token: 0x04005B41 RID: 23361
	VoiceDownloadCell,
	// Token: 0x04005B42 RID: 23362
	VoiceDownload,
	// Token: 0x04005B43 RID: 23363
	VoiceDelete,
	// Token: 0x04005B44 RID: 23364
	PayResTimeOut,
	// Token: 0x04005B45 RID: 23365
	DecomposeNoGetItem,
	// Token: 0x04005B46 RID: 23366
	SkillTreeReset,
	// Token: 0x04005B47 RID: 23367
	BtRollbackTeleport = 77,
	// Token: 0x04005B48 RID: 23368
	QuitOnlineWorld,
	// Token: 0x04005B49 RID: 23369
	KnockPlayerOnlineWorld,
	// Token: 0x04005B4A RID: 23370
	RoleQuestUnlockCheck,
	// Token: 0x04005B4B RID: 23371
	VoiceDownloadShortOfSpace,
	// Token: 0x04005B4C RID: 23372
	SingleTowerContinue,
	// Token: 0x04005B4D RID: 23373
	SingleTowerExit,
	// Token: 0x04005B4E RID: 23374
	SingleTowerReSimulate,
	// Token: 0x04005B4F RID: 23375
	CycleTowerReset,
	// Token: 0x04005B50 RID: 23376
	FunctionNoOpen,
	// Token: 0x04005B51 RID: 23377
	CycleTowerLock,
	// Token: 0x04005B52 RID: 23378
	CycleTowerContinue,
	// Token: 0x04005B53 RID: 23379
	CycleTowerExit,
	// Token: 0x04005B54 RID: 23380
	CycleTowerChallengeExit,
	// Token: 0x04005B55 RID: 23381
	TakeExpSureTip,
	// Token: 0x04005B56 RID: 23382
	AdviceDeleteTips,
	// Token: 0x04005B57 RID: 23383
	ConcertoReactionTip,
	// Token: 0x04005B58 RID: 23384
	RoleTeachTip,
	// Token: 0x04005B59 RID: 23385
	AdviceExpressionDelete,
	// Token: 0x04005B5A RID: 23386
	UsingItemRevive = 98,
	// Token: 0x04005B5B RID: 23387
	PhantomSupplementTips = 96,
	// Token: 0x04005B5C RID: 23388
	PhantomReplaceTips,
	// Token: 0x04005B5D RID: 23389
	CycleTowerSeasonRefresh = 99,
	// Token: 0x04005B5E RID: 23390
	QuitOnlineWorldAndReduceTeam,
	// Token: 0x04005B5F RID: 23391
	MatchingKickOut,
	// Token: 0x04005B60 RID: 23392
	MatchingTeamLack,
	// Token: 0x04005B61 RID: 23393
	CheckOverlap,
	// Token: 0x04005B62 RID: 23394
	ButtonNotSave,
	// Token: 0x04005B63 RID: 23395
	ButtonReset,
	// Token: 0x04005B64 RID: 23396
	CookFail,
	// Token: 0x04005B65 RID: 23397
	UnlockCook,
	// Token: 0x04005B66 RID: 23398
	OnlineQuitInstance,
	// Token: 0x04005B67 RID: 23399
	SetBirthDay,
	// Token: 0x04005B68 RID: 23400
	SetName,
	// Token: 0x04005B69 RID: 23401
	OnlineInstanceInvite,
	// Token: 0x04005B6A RID: 23402
	ChangeName,
	// Token: 0x04005B6B RID: 23403
	ChangeSign,
	// Token: 0x04005B6C RID: 23404
	PlayEnd,
	// Token: 0x04005B6D RID: 23405
	ActivityEnd,
	// Token: 0x04005B6E RID: 23406
	VisionRareTipsOne,
	// Token: 0x04005B6F RID: 23407
	VisionRareTipsTwo,
	// Token: 0x04005B70 RID: 23408
	VisionRareTipsThree,
	// Token: 0x04005B71 RID: 23409
	MainVisionCannotDown,
	// Token: 0x04005B72 RID: 23410
	BlankVisionCannotChange,
	// Token: 0x04005B73 RID: 23411
	CostOver,
	// Token: 0x04005B74 RID: 23412
	DailyActivityRefresh,
	// Token: 0x04005B75 RID: 23413
	AbandonCurrentSlotWhenNotSubProp,
	// Token: 0x04005B76 RID: 23414
	AbandonCurrentSlot,
	// Token: 0x04005B77 RID: 23415
	VisionLevelUpTips3,
	// Token: 0x04005B78 RID: 23416
	VisionLevelUpTips2,
	// Token: 0x04005B79 RID: 23417
	VisionLevelUpTips1,
	// Token: 0x04005B7A RID: 23418
	VisionSlotTips,
	// Token: 0x04005B7B RID: 23419
	TotalLimitTimes,
	// Token: 0x04005B7C RID: 23420
	TodayResult,
	// Token: 0x04005B7D RID: 23421
	TowerLeave = 133,
	// Token: 0x04005B7E RID: 23422
	RoguelikeEnter = 135,
	// Token: 0x04005B7F RID: 23423
	PayShopRefresh = 131,
	// Token: 0x04005B80 RID: 23424
	MonthCardUseTips,
	// Token: 0x04005B81 RID: 23425
	IosCloseRecharge = 134,
	// Token: 0x04005B82 RID: 23426
	LeaveMultiOnLoading = 136,
	// Token: 0x04005B83 RID: 23427
	LeaveTowerOnTowerView,
	// Token: 0x04005B84 RID: 23428
	RefreshChargeView,
	// Token: 0x04005B85 RID: 23429
	UseSoundBoxDetector,
	// Token: 0x04005B86 RID: 23430
	UseTreasureBoxDetectorAtLimit,
	// Token: 0x04005B87 RID: 23431
	UseTempTeleportPointer,
	// Token: 0x04005B88 RID: 23432
	UseTempTeleportPointerAtLimit,
	// Token: 0x04005B89 RID: 23433
	ExploreSkillEmptyEquipItemTips,
	// Token: 0x04005B8A RID: 23434
	VisionDownAllEquipmentTip,
	// Token: 0x04005B8B RID: 23435
	BattlePassExpireTip,
	// Token: 0x04005B8C RID: 23436
	BattlePassTaskExpire,
	// Token: 0x04005B8D RID: 23437
	BattlePassTimeWarning,
	// Token: 0x04005B8E RID: 23438
	CdKeyVerifySuccess,
	// Token: 0x04005B8F RID: 23439
	BattlePassLock,
	// Token: 0x04005B90 RID: 23440
	BattlePassOutTime,
	// Token: 0x04005B91 RID: 23441
	BattlePassPrimaryRepeat,
	// Token: 0x04005B92 RID: 23442
	BattlePassPrimaryTimeWarning,
	// Token: 0x04005B93 RID: 23443
	BattlePassUsePrimary,
	// Token: 0x04005B94 RID: 23444
	BattlePassUseUpgrade,
	// Token: 0x04005B95 RID: 23445
	BattlePassAdvanceRepeat,
	// Token: 0x04005B96 RID: 23446
	BattlePassUseAdvance,
	// Token: 0x04005B97 RID: 23447
	JumpToCalabash,
	// Token: 0x04005B98 RID: 23448
	CostMax,
	// Token: 0x04005B99 RID: 23449
	BattlePassAdvanceTimeWarning,
	// Token: 0x04005B9A RID: 23450
	CalabashExpTipId,
	// Token: 0x04005B9B RID: 23451
	AccountIsBlocked,
	// Token: 0x04005B9C RID: 23452
	QuestForceOccupy,
	// Token: 0x04005B9D RID: 23453
	CalabashCollectSuitTipId,
	// Token: 0x04005B9E RID: 23454
	TeleportDungeonConfirm,
	// Token: 0x04005B9F RID: 23455
	BetaDisableCharge,
	// Token: 0x04005BA0 RID: 23456
	BetaDisableGacha,
	// Token: 0x04005BA1 RID: 23457
	ItemDestructionConfirm,
	// Token: 0x04005BA2 RID: 23458
	ClearHotPatchConfirm,
	// Token: 0x04005BA3 RID: 23459
	PhotoPermissionRequest,
	// Token: 0x04005BA4 RID: 23460
	UseBuffItemOverflow,
	// Token: 0x04005BA5 RID: 23461
	OpenPushNotification,
	// Token: 0x04005BA6 RID: 23462
	InventoryCapacityMax = 173,
	// Token: 0x04005BA7 RID: 23463
	ItemInvalidTips,
	// Token: 0x04005BA8 RID: 23464
	RoleSkillLevelUpTip = 172,
	// Token: 0x04005BA9 RID: 23465
	RoleBreakUpTip = 175,
	// Token: 0x04005BAA RID: 23466
	InstancePowerNotEnough,
	// Token: 0x04005BAB RID: 23467
	TakeExpOverSureTip = 178,
	// Token: 0x04005BAC RID: 23468
	ResetAllInput,
	// Token: 0x04005BAD RID: 23469
	SkipPlot,
	// Token: 0x04005BAE RID: 23470
	BossRushRoleLess = 188,
	// Token: 0x04005BAF RID: 23471
	GachaJumpToMail = 195,
	// Token: 0x04005BB0 RID: 23472
	DailyAdventureRefresh = 184,
	// Token: 0x04005BB1 RID: 23473
	HotResourceVersionNotMatch,
	// Token: 0x04005BB2 RID: 23474
	PatchCleanProcessing,
	// Token: 0x04005BB3 RID: 23475
	MoonChasingEditTeam,
	// Token: 0x04005BB4 RID: 23476
	MoonChasingJumpPreQuest = 190,
	// Token: 0x04005BB5 RID: 23477
	LogoutConfirm,
	// Token: 0x04005BB6 RID: 23478
	BanIp,
	// Token: 0x04005BB7 RID: 23479
	BanDevice,
	// Token: 0x04005BB8 RID: 23480
	BanForever,
	// Token: 0x04005BB9 RID: 23481
	MoonChasingBusinessJumpToBuilding = 196,
	// Token: 0x04005BBA RID: 23482
	MoonChasingBuildingJumpToTask,
	// Token: 0x04005BBB RID: 23483
	MoonChasingTaskJumpToBuilding,
	// Token: 0x04005BBC RID: 23484
	MoonChasingBusinessJumpToTask,
	// Token: 0x04005BBD RID: 23485
	InstanceLevelTooLowToGetPhantom,
	// Token: 0x04005BBE RID: 23486
	MoonChasingBusinessEnergyNotEnough,
	// Token: 0x04005BBF RID: 23487
	MoonChasingBusinessMoneyNotEnough,
	// Token: 0x04005BC0 RID: 23488
	BackToLoginAndEnterGame,
	// Token: 0x04005BC1 RID: 23489
	MoonChasingJinxiTaskUnlock,
	// Token: 0x04005BC2 RID: 23490
	MoonChasingBuildingNotEnough,
	// Token: 0x04005BC3 RID: 23491
	MoonChasingRoleCostNotEnough,
	// Token: 0x04005BC4 RID: 23492
	TowerDefenseLeaveInstance,
	// Token: 0x04005BC5 RID: 23493
	PlatformLoginFail,
	// Token: 0x04005BC6 RID: 23494
	PlatformSdkTokenExpire,
	// Token: 0x04005BC7 RID: 23495
	MobileInputSwitch = 212,
	// Token: 0x04005BC8 RID: 23496
	CannotFindSdkProduct,
	// Token: 0x04005BC9 RID: 23497
	SdkServerNetworkError,
	// Token: 0x04005BCA RID: 23498
	PictureConfigOverload,
	// Token: 0x04005BCB RID: 23499
	QuickTranser,
	// Token: 0x04005BCC RID: 23500
	InstanceRewardTimesNotEnoughSingle,
	// Token: 0x04005BCD RID: 23501
	InstanceRewardTimesNotEnoughMulti,
	// Token: 0x04005BCE RID: 23502
	InstanceExitReChallengeSingle,
	// Token: 0x04005BCF RID: 23503
	TeleportOutOfQuestRangeConfirm,
	// Token: 0x04005BD0 RID: 23504
	ImageQualityAdjustConfirm,
	// Token: 0x04005BD1 RID: 23505
	ShowReviewConfirm,
	// Token: 0x04005BD2 RID: 23506
	ShowDoubleCheckQuickTransfer,
	// Token: 0x04005BD3 RID: 23507
	GMWorldMapTrans = 225,
	// Token: 0x04005BD4 RID: 23508
	AllActivityClose = 224,
	// Token: 0x04005BD5 RID: 23509
	WeaponSkinReplace = 226,
	// Token: 0x04005BD6 RID: 23510
	SdkBlankTips,
	// Token: 0x04005BD7 RID: 23511
	RogueBlackFlower,
	// Token: 0x04005BD8 RID: 23512
	NoRoleBuySkin,
	// Token: 0x04005BD9 RID: 23513
	EnterPureMode,
	// Token: 0x04005BDA RID: 23514
	RoleSkinTip,
	// Token: 0x04005BDB RID: 23515
	BigStuffedBrokenRock,
	// Token: 0x04005BDC RID: 23516
	ObtainNoRole,
	// Token: 0x04005BDD RID: 23517
	DailyTurntableRefresh,
	// Token: 0x04005BDE RID: 23518
	DockyardDeleteItem,
	// Token: 0x04005BDF RID: 23519
	DockyardExitFishing,
	// Token: 0x04005BE0 RID: 23520
	DirectTrainRecommendQuest,
	// Token: 0x04005BE1 RID: 23521
	PreOpenSpoilConfirmBox,
	// Token: 0x04005BE2 RID: 23522
	RoleGenderChangeConfirmBox = 240,
	// Token: 0x04005BE3 RID: 23523
	LifePointBonus = 239,
	// Token: 0x04005BE4 RID: 23524
	VisionGroupToTop = 242,
	// Token: 0x04005BE5 RID: 23525
	VisionGroupDelete,
	// Token: 0x04005BE6 RID: 23526
	VisionGroupOtherRoleUse,
	// Token: 0x04005BE7 RID: 23527
	VisionGroupMax,
	// Token: 0x04005BE8 RID: 23528
	FishingEntrustGiveUp,
	// Token: 0x04005BE9 RID: 23529
	RayTracingOn = 248,
	// Token: 0x04005BEA RID: 23530
	DestroyVisionInGroup = 247,
	// Token: 0x04005BEB RID: 23531
	FishingEntrustsTargetSell = 249,
	// Token: 0x04005BEC RID: 23532
	ActivityPreOpen = 251,
	// Token: 0x04005BED RID: 23533
	WeeklyRogueCycleRefresh = 278,
	// Token: 0x04005BEE RID: 23534
	ShipTowerLeaveInstance = 252,
	// Token: 0x04005BEF RID: 23535
	ConfirmToTeleportToPort,
	// Token: 0x04005BF0 RID: 23536
	ShipTowerFromViewLeaveInst,
	// Token: 0x04005BF1 RID: 23537
	ExploreClearPlayPointMark,
	// Token: 0x04005BF2 RID: 23538
	ShipTowerSeasonUpdate,
	// Token: 0x04005BF3 RID: 23539
	FishingBait,
	// Token: 0x04005BF4 RID: 23540
	FishingBaitLimit,
	// Token: 0x04005BF5 RID: 23541
	FishingTeleport,
	// Token: 0x04005BF6 RID: 23542
	FishingDeliverEntrustRefresh,
	// Token: 0x04005BF7 RID: 23543
	FishingNightTraceSailingInDay,
	// Token: 0x04005BF8 RID: 23544
	VisionRefineMaterialHint,
	// Token: 0x04005BF9 RID: 23545
	DestroyTemporaryTeleport,
	// Token: 0x04005BFA RID: 23546
	PreDownloadConfirmBox,
	// Token: 0x04005BFB RID: 23547
	PreDownloadToSpeedMode,
	// Token: 0x04005BFC RID: 23548
	PreDownloadToNormalMode,
	// Token: 0x04005BFD RID: 23549
	PreDownloadNoWifi,
	// Token: 0x04005BFE RID: 23550
	PreDownloadNoSpace,
	// Token: 0x04005BFF RID: 23551
	MatchingTeamLackButNoEnter,
	// Token: 0x04005C00 RID: 23552
	ExitGameOrReturnLogin,
	// Token: 0x04005C01 RID: 23553
	BabelTowerClearDeTerm,
	// Token: 0x04005C02 RID: 23554
	GpuDriverVersionLowForRayTracing = 273,
	// Token: 0x04005C03 RID: 23555
	DlssFrameGenerateInvalid = 292,
	// Token: 0x04005C04 RID: 23556
	PreDownloadErrorOneBtn = 274,
	// Token: 0x04005C05 RID: 23557
	PreDownloadErrorTwoBtn,
	// Token: 0x04005C06 RID: 23558
	BabelTowerInstanceDungeonLeave,
	// Token: 0x04005C07 RID: 23559
	BabelTowerLowStarConfirm,
	// Token: 0x04005C08 RID: 23560
	ClientVersionNoMatchOnline = 279,
	// Token: 0x04005C09 RID: 23561
	ClientVersionNoMatchTeam,
	// Token: 0x04005C0A RID: 23562
	DungeonContinuePlayConfirm,
	// Token: 0x04005C0B RID: 23563
	ShareReviveRole,
	// Token: 0x04005C0C RID: 23564
	AbyssExit,
	// Token: 0x04005C0D RID: 23565
	UnfinishedDungeonBoxIdSupportArchive,
	// Token: 0x04005C0E RID: 23566
	UnfinishedDungeonBoxId,
	// Token: 0x04005C0F RID: 23567
	FinishedDungeonBoxId = 290,
	// Token: 0x04005C10 RID: 23568
	FlySkinApplyToAll = 293,
	// Token: 0x04005C11 RID: 23569
	FlySkinApplyHelp,
	// Token: 0x04005C12 RID: 23570
	CiacconaAvgExit,
	// Token: 0x04005C13 RID: 23571
	IOSExitInstanceConfirm,
	// Token: 0x04005C14 RID: 23572
	RacingBetsBettingConfirm,
	// Token: 0x04005C15 RID: 23573
	RacingBetsCancelBettingConfirm,
	// Token: 0x04005C16 RID: 23574
	RacingBetsBettingEndConfirm,
	// Token: 0x04005C17 RID: 23575
	AbyssUnlockTip,
	// Token: 0x04005C18 RID: 23576
	DangoQuitWorld = 317,
	// Token: 0x04005C19 RID: 23577
	Dxr1_1NotSupported = 301,
	// Token: 0x04005C1A RID: 23578
	BirthdayExitConfirm,
	// Token: 0x04005C1B RID: 23579
	DangoAbyssEquipPluginDiffDango,
	// Token: 0x04005C1C RID: 23580
	MapRogueGiveUpReward,
	// Token: 0x04005C1D RID: 23581
	DangoAbyssLockSlotToLevelUp,
	// Token: 0x04005C1E RID: 23582
	RogueResDungeonContinue,
	// Token: 0x04005C1F RID: 23583
	PreDownloadOnClickedClose,
	// Token: 0x04005C20 RID: 23584
	RacingBetsExitDungeonConfirm,
	// Token: 0x04005C21 RID: 23585
	MapRogueHighLvEventConfirm,
	// Token: 0x04005C22 RID: 23586
	RogueResCancelDungeonConfirm,
	// Token: 0x04005C23 RID: 23587
	FocusModeSwitchConfirm,
	// Token: 0x04005C24 RID: 23588
	BeforeEnterFocusModeConfirm,
	// Token: 0x04005C25 RID: 23589
	ResDownLoadDoneConfirm,
	// Token: 0x04005C26 RID: 23590
	PhantomArenaExitDeckBuilderViewConfirm,
	// Token: 0x04005C27 RID: 23591
	PhantomArenaDeleteDeckConfirm,
	// Token: 0x04005C28 RID: 23592
	VulkanOn,
	// Token: 0x04005C29 RID: 23593
	LoginResDownLoadFailedConfirm = 318,
	// Token: 0x04005C2A RID: 23594
	PhantomArenaQuicklyBuildConfirm,
	// Token: 0x04005C2B RID: 23595
	BabelTowerTeamTipsConfirm,
	// Token: 0x04005C2C RID: 23596
	VideoResDownLoadShortOfSpaceConfirm,
	// Token: 0x04005C2D RID: 23597
	FocusModeSwitchToCommonQuest,
	// Token: 0x04005C2E RID: 23598
	CloseFocusQuestTips = 341,
	// Token: 0x04005C2F RID: 23599
	PhantomArenaBattleRoundOver = 323,
	// Token: 0x04005C30 RID: 23600
	FilterSettingChangingConfirm,
	// Token: 0x04005C31 RID: 23601
	PhantomArenaOneCostCardNotEnough,
	// Token: 0x04005C32 RID: 23602
	InstanceDungeonMultiStart,
	// Token: 0x04005C33 RID: 23603
	InstanceDungeonMatchStart,
	// Token: 0x04005C34 RID: 23604
	BeginnerCarnivalNoRole,
	// Token: 0x04005C35 RID: 23605
	BeginnerCarnivalGetRole,
	// Token: 0x04005C36 RID: 23606
	RedMagic90Fps,
	// Token: 0x04005C37 RID: 23607
	PhantomManageBatchDisposeConfirm,
	// Token: 0x04005C38 RID: 23608
	VisionLevelUpIdentifyLessMin,
	// Token: 0x04005C39 RID: 23609
	VisionLevelUpIdentifyLessTarget,
	// Token: 0x04005C3A RID: 23610
	FloroRanchArchive,
	// Token: 0x04005C3B RID: 23611
	PhantomManageConfigSaveOn,
	// Token: 0x04005C3C RID: 23612
	PhantomManageConfigReset,
	// Token: 0x04005C3D RID: 23613
	PhantomManageConfigEditReset,
	// Token: 0x04005C3E RID: 23614
	PhantomManageConfigEditPreview,
	// Token: 0x04005C3F RID: 23615
	FloroRanchCardGroupSelect,
	// Token: 0x04005C40 RID: 23616
	FloroRanchSkipComic,
	// Token: 0x04005C41 RID: 23617
	FloroRanchExitConfirm = 345,
	// Token: 0x04005C42 RID: 23618
	PhantomManageConfigQuitEdit,
	// Token: 0x04005C43 RID: 23619
	UsePhantomManagePlanConfirm,
	// Token: 0x04005C44 RID: 23620
	RogueResInactiveLinkConfirm,
	// Token: 0x04005C45 RID: 23621
	RogueResSkipBattleConfirm,
	// Token: 0x04005C46 RID: 23622
	PhantomCapacityMax,
	// Token: 0x04005C47 RID: 23623
	TrapDefenseUnloadAndSell,
	// Token: 0x04005C48 RID: 23624
	RoleTrialLeaveInstanceConfirm,
	// Token: 0x04005C49 RID: 23625
	KingShipExitConfirm,
	// Token: 0x04005C4A RID: 23626
	VisionLevelUpTipsOverflow1,
	// Token: 0x04005C4B RID: 23627
	VisionLevelUpTipsOverflow2,
	// Token: 0x04005C4C RID: 23628
	VisionLevelUpTipsOverflow3,
	// Token: 0x04005C4D RID: 23629
	WeaponLevelUpTipsOverflow1,
	// Token: 0x04005C4E RID: 23630
	WeaponLevelUpTipsOverflow2,
	// Token: 0x04005C4F RID: 23631
	WeaponLevelUpTipsOverflow3,
	// Token: 0x04005C50 RID: 23632
	TrapDefenseLevelStarSwitch,
	// Token: 0x04005C51 RID: 23633
	TrapDefenseOrganResetAll = 365,
	// Token: 0x04005C52 RID: 23634
	TrapDefenseMachineFull = 363,
	// Token: 0x04005C53 RID: 23635
	PlayStationConnectFail,
	// Token: 0x04005C54 RID: 23636
	SeekTraceAddStep = 366,
	// Token: 0x04005C55 RID: 23637
	SeekTraceExit,
	// Token: 0x04005C56 RID: 23638
	TrapDefenseOrganReset,
	// Token: 0x04005C57 RID: 23639
	TrapDefenseNextLevelThreshold = 377,
	// Token: 0x04005C58 RID: 23640
	SkipAstrologyItemInspect = 369,
	// Token: 0x04005C59 RID: 23641
	OnlineSingleConfirm = 371,
	// Token: 0x04005C5A RID: 23642
	FightPhotoActivityEnd = 393,
	// Token: 0x04005C5B RID: 23643
	ParallelPackageUpdate = 373,
	// Token: 0x04005C5C RID: 23644
	SurvivorsLevelFirstEndlessConfirm = 376,
	// Token: 0x04005C5D RID: 23645
	RecommendSwitch = 375,
	// Token: 0x04005C5E RID: 23646
	SurvivorsEnterInstConfirm = 378,
	// Token: 0x04005C5F RID: 23647
	GameSettingDefaultFilter,
	// Token: 0x04005C60 RID: 23648
	PreOpenSpoilConfirmBoxFromRoleDev,
	// Token: 0x04005C61 RID: 23649
	EyeProtectModeExit,
	// Token: 0x04005C62 RID: 23650
	ShopPurchaseAvailableConfirm = 385,
	// Token: 0x04005C63 RID: 23651
	UnFinishFightPhotoLeaveInstanceConfirm = 394,
	// Token: 0x04005C64 RID: 23652
	FinishFightPhotoLeaveInstanceConfirm,
	// Token: 0x04005C65 RID: 23653
	HonamiStoryQualitySellConfirm = 384,
	// Token: 0x04005C66 RID: 23654
	PhantomArenaApplyRecommendDeckConfirm = 412,
	// Token: 0x04005C67 RID: 23655
	PhantomArenaRecommendDeckCardInsufficientConfirm,
	// Token: 0x04005C68 RID: 23656
	PhantomArenaRecommendOverrideOriginal,
	// Token: 0x04005C69 RID: 23657
	PreloadFailConfirm = 386,
	// Token: 0x04005C6A RID: 23658
	HonamiStorySlotUnlockConfirm = 389,
	// Token: 0x04005C6B RID: 23659
	GameQualityLoadOver = 388,
	// Token: 0x04005C6C RID: 23660
	AutoSynthesisOverFlowPop = 390,
	// Token: 0x04005C6D RID: 23661
	HonamiStoryLifeSupportLevelConfirm,
	// Token: 0x04005C6E RID: 23662
	WeatherCentralTimeSwitchConfirm,
	// Token: 0x04005C6F RID: 23663
	QuestResDownloadCellNetworkConfirm = 396,
	// Token: 0x04005C70 RID: 23664
	KeySubPackageDownLoadConfirm,
	// Token: 0x04005C71 RID: 23665
	SubPackageDownloadCellNetworkConfirm,
	// Token: 0x04005C72 RID: 23666
	SubPackageCommonConfirm,
	// Token: 0x04005C73 RID: 23667
	SubPackageDownloadListFinishConfirm,
	// Token: 0x04005C74 RID: 23668
	LordGymExitInstanceConfirm,
	// Token: 0x04005C75 RID: 23669
	ReplaceBuffEquipItemConfirm,
	// Token: 0x04005C76 RID: 23670
	MotorcycleDiyChangeConfirm,
	// Token: 0x04005C77 RID: 23671
	MotorcycleDiyImportConfirm,
	// Token: 0x04005C78 RID: 23672
	SubPackageTeleportToUnFinishAreaConfirm,
	// Token: 0x04005C79 RID: 23673
	WheelTowerReturnWorldConfirm,
	// Token: 0x04005C7A RID: 23674
	WheelTowerTemplateReplaceConfirm,
	// Token: 0x04005C7B RID: 23675
	WheelTowerTeamBuffNotSelectTips,
	// Token: 0x04005C7C RID: 23676
	WheelTowerRoundResetAllConfirm,
	// Token: 0x04005C7D RID: 23677
	WheelTowerInstanceExitConfirm,
	// Token: 0x04005C7E RID: 23678
	WheelTowerInstanceRetryConfirm,
	// Token: 0x04005C7F RID: 23679
	LordGymExitConfirm = 416,
	// Token: 0x04005C80 RID: 23680
	LordGymThird5ExitConfirm = 535,
	// Token: 0x04005C81 RID: 23681
	LordGymThird5BossSelectExitConfirm,
	// Token: 0x04005C82 RID: 23682
	HonamiStoryStorageFullConfirm = 418,
	// Token: 0x04005C83 RID: 23683
	WheelTowerSelectConflictConfirm = 420,
	// Token: 0x04005C84 RID: 23684
	HonamiStoryEquipWeaponConfirm,
	// Token: 0x04005C85 RID: 23685
	HonamiStoryTowerRestart,
	// Token: 0x04005C86 RID: 23686
	ResonantItemConvertConfirm = 494,
	// Token: 0x04005C87 RID: 23687
	PhantomArenaReChallengeConfirm = 423,
	// Token: 0x04005C88 RID: 23688
	PhantomInteractConfirmRecommend,
	// Token: 0x04005C89 RID: 23689
	SubPackageNeedReLogin,
	// Token: 0x04005C8A RID: 23690
	TrialRoleChooseConfirm,
	// Token: 0x04005C8B RID: 23691
	AutoPilotQuickGoToTeleportConfirm,
	// Token: 0x04005C8C RID: 23692
	WeatherCentralCooldownTips,
	// Token: 0x04005C8D RID: 23693
	WeatherCentralTeleportConfirm,
	// Token: 0x04005C8E RID: 23694
	DrinkPrevConfirm,
	// Token: 0x04005C8F RID: 23695
	DrinkCloseConfirm,
	// Token: 0x04005C90 RID: 23696
	DrinkNoBatchingConfirm,
	// Token: 0x04005C91 RID: 23697
	FurnitureExitConfirm,
	// Token: 0x04005C92 RID: 23698
	SpringManorPhantomExhibitConfirm,
	// Token: 0x04005C93 RID: 23699
	SpringManorWeaponExhibitConfirm,
	// Token: 0x04005C94 RID: 23700
	ApplyImageQualityConfirm,
	// Token: 0x04005C95 RID: 23701
	EncircleDifficultyChangeConfirm,
	// Token: 0x04005C96 RID: 23702
	EncircleExitConfirm,
	// Token: 0x04005C97 RID: 23703
	PhantomDirectRefiningWeeklyConfirm,
	// Token: 0x04005C98 RID: 23704
	FurniturePlaceToNewSlotConfirm,
	// Token: 0x04005C99 RID: 23705
	FurniturePresetApplyConfirm,
	// Token: 0x04005C9A RID: 23706
	GuessJokerExitConfirm = 459,
	// Token: 0x04005C9B RID: 23707
	FurniturePresetFillAndApplyConfirm = 442,
	// Token: 0x04005C9C RID: 23708
	MotorFightActivityEnd = 461,
	// Token: 0x04005C9D RID: 23709
	FurnitureSwitchAreaConfirm = 443,
	// Token: 0x04005C9E RID: 23710
	KeySettingResetConfirm = 446,
	// Token: 0x04005C9F RID: 23711
	VisionRefineSubUnderTwo,
	// Token: 0x04005CA0 RID: 23712
	EncircleResetConfirm,
	// Token: 0x04005CA1 RID: 23713
	TotalTopUpClaimRoleConfirm,
	// Token: 0x04005CA2 RID: 23714
	VisionRefineSubGreaterEqualTwo,
	// Token: 0x04005CA3 RID: 23715
	FurnitureDesignSaveAndTeleportConfirm,
	// Token: 0x04005CA4 RID: 23716
	FlagChallengeFormationNotFullConfirm,
	// Token: 0x04005CA5 RID: 23717
	FindSunSpiritReduceConfirm,
	// Token: 0x04005CA6 RID: 23718
	AutoClearUnusedResourcesConfirm,
	// Token: 0x04005CA7 RID: 23719
	PhantomFullFusionConfirm = 456,
	// Token: 0x04005CA8 RID: 23720
	PhantomFullDiscardConfirm,
	// Token: 0x04005CA9 RID: 23721
	FurnitureTeleportConfirm = 460,
	// Token: 0x04005CAA RID: 23722
	WheelTowerReChallengeConfirm = 458,
	// Token: 0x04005CAB RID: 23723
	PhantomConfigApplyPreRecommendConfirm = 462,
	// Token: 0x04005CAC RID: 23724
	PhantomConfigApplyClearPlanConfirm,
	// Token: 0x04005CAD RID: 23725
	PhantomConfigSaveCloseEditConfirm,
	// Token: 0x04005CAE RID: 23726
	PhantomConfigAutoDiscardNot5Confirm,
	// Token: 0x04005CAF RID: 23727
	PhantomConfigCanUpdateSelf,
	// Token: 0x04005CB0 RID: 23728
	PhantomConfigUsePlayerPlant,
	// Token: 0x04005CB1 RID: 23729
	FlagChallengeBattleExitConfirm,
	// Token: 0x04005CB2 RID: 23730
	TetrisLoseConfirm,
	// Token: 0x04005CB3 RID: 23731
	TetrisQuitConfirm,
	// Token: 0x04005CB4 RID: 23732
	TetrisDifficultyChangeConfirm,
	// Token: 0x04005CB5 RID: 23733
	TetrisTakeBackConfirm,
	// Token: 0x04005CB6 RID: 23734
	PhantomDiscardFusionConfirm = 474,
	// Token: 0x04005CB7 RID: 23735
	VisionRefineSubResultConfirm = 476,
	// Token: 0x04005CB8 RID: 23736
	RoguelikeInstEnterConfirm = 478,
	// Token: 0x04005CB9 RID: 23737
	BossPilingExitConfirm,
	// Token: 0x04005CBA RID: 23738
	RhythmCalibrationExitConfirm,
	// Token: 0x04005CBB RID: 23739
	PinballBattleRestartConfirm,
	// Token: 0x04005CBC RID: 23740
	PinballBattleRestartCowConfirm,
	// Token: 0x04005CBD RID: 23741
	PinballWeaponReplaceConfirm,
	// Token: 0x04005CBE RID: 23742
	PinballWeaponOverCapacityConfirm,
	// Token: 0x04005CBF RID: 23743
	TetrisGameFailConfirm,
	// Token: 0x04005CC0 RID: 23744
	ClearBlockSubPackageConfirm = 488,
	// Token: 0x04005CC1 RID: 23745
	MotorDiyDeletePresetConfirm,
	// Token: 0x04005CC2 RID: 23746
	MotorDiyChangePresetConfirm,
	// Token: 0x04005CC3 RID: 23747
	TetrisGameCloseConfirm,
	// Token: 0x04005CC4 RID: 23748
	PinballBattleResetLaunchConfirm,
	// Token: 0x04005CC5 RID: 23749
	KurotatoArchiveConfirm,
	// Token: 0x04005CC6 RID: 23750
	PhantomRefreshAcceptConfirm = 495,
	// Token: 0x04005CC7 RID: 23751
	KurotatoOverwriteSave,
	// Token: 0x04005CC8 RID: 23752
	RacingBetsExitDungeonBackFightConfirm,
	// Token: 0x04005CC9 RID: 23753
	GolemHackingNormalLevelExitConfirm,
	// Token: 0x04005CCA RID: 23754
	GolemHackingMainLevelExitConfirm,
	// Token: 0x04005CCB RID: 23755
	PhantomRefreshRejectConfirm,
	// Token: 0x04005CCC RID: 23756
	CyberpunkConfirm,
	// Token: 0x04005CCD RID: 23757
	XboxBindAccountWithRegionConfirm,
	// Token: 0x04005CCE RID: 23758
	KurotatoDieConfirm,
	// Token: 0x04005CCF RID: 23759
	KurotatoDieNoLimitConfirm = 540,
	// Token: 0x04005CD0 RID: 23760
	KurotatoNotBuyConfirm = 504,
	// Token: 0x04005CD1 RID: 23761
	CyberPunkExitChallengeViewConfirm,
	// Token: 0x04005CD2 RID: 23762
	CyberPunkExitDungeonConfirm,
	// Token: 0x04005CD3 RID: 23763
	CyberPunkDirectionConfirm,
	// Token: 0x04005CD4 RID: 23764
	RoleLangCustomConfirm,
	// Token: 0x04005CD5 RID: 23765
	KurotatoSaveNotifyConfirm,
	// Token: 0x04005CD6 RID: 23766
	FloroRanchWeeklyArchiveConfirm,
	// Token: 0x04005CD7 RID: 23767
	MotorDiyNewPresetConfirm,
	// Token: 0x04005CD8 RID: 23768
	KurotatoSellWeaponConfirm = 513,
	// Token: 0x04005CD9 RID: 23769
	RoguelikeBossChallengeExitConfirm,
	// Token: 0x04005CDA RID: 23770
	QuestFastReturnConfirm = 542,
	// Token: 0x04005CDB RID: 23771
	QuestFastReturnViaWorldMapConfirm,
	// Token: 0x04005CDC RID: 23772
	FastReturnDungeonConfirm,
	// Token: 0x04005CDD RID: 23773
	RoguelikeOverwriteArchiveConfirm = 515,
	// Token: 0x04005CDE RID: 23774
	RoguelikeGiveUpArchiveConfirm,
	// Token: 0x04005CDF RID: 23775
	RoguelikeTempArchiveProcessConfirm,
	// Token: 0x04005CE0 RID: 23776
	RoguelikeBossChallengeLeaveArchiveConfirm,
	// Token: 0x04005CE1 RID: 23777
	RoguelikeNormalLeaveArchiveConfirm = 530,
	// Token: 0x04005CE2 RID: 23778
	RoverlikeResultConfirm = 545,
	// Token: 0x04005CE3 RID: 23779
	CyberPunkRoleTrialExitConfirm = 512,
	// Token: 0x04005CE4 RID: 23780
	FloroRanchEventToyGridNotEnough = 520,
	// Token: 0x04005CE5 RID: 23781
	FloroRanchWeeklyEnd = 537,
	// Token: 0x04005CE6 RID: 23782
	VoiceDownloadLoginConfirm = 523,
	// Token: 0x04005CE7 RID: 23783
	VoiceDownloadLoginConfirmCell,
	// Token: 0x04005CE8 RID: 23784
	CdkGiftBuyConfirm = 521,
	// Token: 0x04005CE9 RID: 23785
	XboxExitGame,
	// Token: 0x04005CEA RID: 23786
	BuyItemSecondConfirm = 550,
	// Token: 0x04005CEB RID: 23787
	SheriffCloseConfirm = 525,
	// Token: 0x04005CEC RID: 23788
	SheriffRestartConfirm,
	// Token: 0x04005CED RID: 23789
	SubPackageRecommendConfirm = 531,
	// Token: 0x04005CEE RID: 23790
	KurotatoEndSpecialWaveCombatConfirm,
	// Token: 0x04005CEF RID: 23791
	DollGrabMachineExitConfirm = 528,
	// Token: 0x04005CF0 RID: 23792
	GuideLordGymExitDungeonConfirm = 533,
	// Token: 0x04005CF1 RID: 23793
	GuideLordGymExitChallengeConfirm,
	// Token: 0x04005CF2 RID: 23794
	ExpiredFavoriteMailUnfavoriteConfirm = 548,
	// Token: 0x04005CF3 RID: 23795
	RoverRogueSaveEnterConfirm = 556,
	// Token: 0x04005CF4 RID: 23796
	RoverRogueLootNotMatchConfirm = 555,
	// Token: 0x04005CF5 RID: 23797
	FavoriteMailDeleteConfirm = 549,
	// Token: 0x04005CF6 RID: 23798
	BabelTowerQuickSelectConfirm = 539,
	// Token: 0x04005CF7 RID: 23799
	DollGrabMachineEndlessRestartConfirm = 529,
	// Token: 0x04005CF8 RID: 23800
	DollGrabMachineNoEnoughItem = 527,
	// Token: 0x04005CF9 RID: 23801
	ConfigReloadTips = 541
}
