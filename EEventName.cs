using System;

// Token: 0x02000E5F RID: 3679
public enum EEventName
{
	// Token: 0x04001E0B RID: 7691
	SetEntityCreatureDataRelation,
	// Token: 0x04001E0C RID: 7692
	KeyClick,
	// Token: 0x04001E0D RID: 7693
	UiSceneLoaded,
	// Token: 0x04001E0E RID: 7694
	UiSceneStartLoad,
	// Token: 0x04001E0F RID: 7695
	UiSceneLastStepInLoadScene,
	// Token: 0x04001E10 RID: 7696
	UiSceneLastStepInExitScene,
	// Token: 0x04001E11 RID: 7697
	OpenView,
	// Token: 0x04001E12 RID: 7698
	StackPreOpenView,
	// Token: 0x04001E13 RID: 7699
	StackOpenView,
	// Token: 0x04001E14 RID: 7700
	StackCloseView,
	// Token: 0x04001E15 RID: 7701
	OnNormalTopViewChange,
	// Token: 0x04001E16 RID: 7702
	FloatQueueCloseView,
	// Token: 0x04001E17 RID: 7703
	OpenViewBegined,
	// Token: 0x04001E18 RID: 7704
	OpenViewFail,
	// Token: 0x04001E19 RID: 7705
	CreateViewInstance,
	// Token: 0x04001E1A RID: 7706
	OnViewLoadCompleted,
	// Token: 0x04001E1B RID: 7707
	OnViewDone,
	// Token: 0x04001E1C RID: 7708
	OnViewHidden,
	// Token: 0x04001E1D RID: 7709
	CloseView,
	// Token: 0x04001E1E RID: 7710
	CloseCompositeRewardView,
	// Token: 0x04001E1F RID: 7711
	OpenTabView,
	// Token: 0x04001E20 RID: 7712
	TriggerUiTimeDilation,
	// Token: 0x04001E21 RID: 7713
	CloseTabView,
	// Token: 0x04001E22 RID: 7714
	ChangeChildView,
	// Token: 0x04001E23 RID: 7715
	SwitchAdventureGuideViewTab,
	// Token: 0x04001E24 RID: 7716
	UiManagerInit,
	// Token: 0x04001E25 RID: 7717
	UiManagerDestroy,
	// Token: 0x04001E26 RID: 7718
	HotKeyInput,
	// Token: 0x04001E27 RID: 7719
	ViewHotKeyInputPress,
	// Token: 0x04001E28 RID: 7720
	ViewHotKeyInputRelease,
	// Token: 0x04001E29 RID: 7721
	ResetNormalAction,
	// Token: 0x04001E2A RID: 7722
	UnBlockCharacterAction,
	// Token: 0x04001E2B RID: 7723
	ResetSystemAction,
	// Token: 0x04001E2C RID: 7724
	OnReduceDamageViewDepth,
	// Token: 0x04001E2D RID: 7725
	LevelSequencePlayerBandStateChange,
	// Token: 0x04001E2E RID: 7726
	UIViewPortSizeChanged,
	// Token: 0x04001E2F RID: 7727
	OnDynamicScrollViewClearItem,
	// Token: 0x04001E30 RID: 7728
	LoginSuccess,
	// Token: 0x04001E31 RID: 7729
	EnterGameSuccess,
	// Token: 0x04001E32 RID: 7730
	LoginStatusChange,
	// Token: 0x04001E33 RID: 7731
	LoginRequestResult,
	// Token: 0x04001E34 RID: 7732
	SdkLoginResult,
	// Token: 0x04001E35 RID: 7733
	OnGetLoginPlayerInfo,
	// Token: 0x04001E36 RID: 7734
	OnSelectServerItem,
	// Token: 0x04001E37 RID: 7735
	OnConfirmServerItem,
	// Token: 0x04001E38 RID: 7736
	OnNetworkDetectionSelectServerItem,
	// Token: 0x04001E39 RID: 7737
	OnConfirmNetworkDetectionItem,
	// Token: 0x04001E3A RID: 7738
	SendHeartbeat,
	// Token: 0x04001E3B RID: 7739
	SdkInitDone,
	// Token: 0x04001E3C RID: 7740
	SdkPayEnd,
	// Token: 0x04001E3D RID: 7741
	PlayStationJoinSessionEvent,
	// Token: 0x04001E3E RID: 7742
	SdkRefreshAccessToken,
	// Token: 0x04001E3F RID: 7743
	SdkRefreshNoticeRedDot,
	// Token: 0x04001E40 RID: 7744
	CharQteActive,
	// Token: 0x04001E41 RID: 7745
	CharQteConsume,
	// Token: 0x04001E42 RID: 7746
	CharInQteChanged,
	// Token: 0x04001E43 RID: 7747
	CharExecuteQte,
	// Token: 0x04001E44 RID: 7748
	CharExecuteMultiQte,
	// Token: 0x04001E45 RID: 7749
	CharQteTagRowNameChanged,
	// Token: 0x04001E46 RID: 7750
	CharHitLocal,
	// Token: 0x04001E47 RID: 7751
	CharHitRemote,
	// Token: 0x04001E48 RID: 7752
	CharBeHitLocal,
	// Token: 0x04001E49 RID: 7753
	CharHitIncludingVision,
	// Token: 0x04001E4A RID: 7754
	CharBeHitRemote,
	// Token: 0x04001E4B RID: 7755
	CharLimitDodge,
	// Token: 0x04001E4C RID: 7756
	CharBeHitAnim,
	// Token: 0x04001E4D RID: 7757
	CharBeforeSetHitRotator,
	// Token: 0x04001E4E RID: 7758
	CharBeHitTimeScale,
	// Token: 0x04001E4F RID: 7759
	CharShieldChange,
	// Token: 0x04001E50 RID: 7760
	CharAnimBreakPoint,
	// Token: 0x04001E51 RID: 7761
	CharBeforeSkillWithTarget,
	// Token: 0x04001E52 RID: 7762
	CharBeforeSkill,
	// Token: 0x04001E53 RID: 7763
	ConditionDrivenSMTickLock,
	// Token: 0x04001E54 RID: 7764
	CharBeforeInterruptWithTarget,
	// Token: 0x04001E55 RID: 7765
	CharGameplayCueChanged,
	// Token: 0x04001E56 RID: 7766
	CharUseSkill,
	// Token: 0x04001E57 RID: 7767
	CharUseSkillRemote,
	// Token: 0x04001E58 RID: 7768
	OnSkillEnd,
	// Token: 0x04001E59 RID: 7769
	CharStopAllSkills,
	// Token: 0x04001E5A RID: 7770
	CharStopGroup1Skill,
	// Token: 0x04001E5B RID: 7771
	CharSetShowTarget,
	// Token: 0x04001E5C RID: 7772
	CharEndShowTarget,
	// Token: 0x04001E5D RID: 7773
	OnSkillSimulateMontage,
	// Token: 0x04001E5E RID: 7774
	OnBeforeSkillSimulateMontage,
	// Token: 0x04001E5F RID: 7775
	OnMultiSkillIdChanged,
	// Token: 0x04001E60 RID: 7776
	OnMultiSkillEnable,
	// Token: 0x04001E61 RID: 7777
	CharSwitchControl,
	// Token: 0x04001E62 RID: 7778
	CharSkillTargetChanged,
	// Token: 0x04001E63 RID: 7779
	CharDeleteSkill,
	// Token: 0x04001E64 RID: 7780
	CharResetSkill,
	// Token: 0x04001E65 RID: 7781
	CharInterruptSkill,
	// Token: 0x04001E66 RID: 7782
	CharSkillCountChanged,
	// Token: 0x04001E67 RID: 7783
	CharSkillRemainCdChanged,
	// Token: 0x04001E68 RID: 7784
	CharSkillCdPauseStateChanged,
	// Token: 0x04001E69 RID: 7785
	CharClearSkill,
	// Token: 0x04001E6A RID: 7786
	SpecialSkillLuPaSwitchLockTarget,
	// Token: 0x04001E6B RID: 7787
	SpecialSkillRebeccaSwitchLockTarget,
	// Token: 0x04001E6C RID: 7788
	FuLuoLuoAddDuplicatedEnergy,
	// Token: 0x04001E6D RID: 7789
	CharDamage,
	// Token: 0x04001E6E RID: 7790
	CharKillTarget,
	// Token: 0x04001E6F RID: 7791
	CharBeKilled,
	// Token: 0x04001E70 RID: 7792
	CharBeDamage,
	// Token: 0x04001E71 RID: 7793
	GlobalCharDamage,
	// Token: 0x04001E72 RID: 7794
	FormationPanelUIShowRoleHeal,
	// Token: 0x04001E73 RID: 7795
	CharPartDamage,
	// Token: 0x04001E74 RID: 7796
	FollowShooterForwardEvent,
	// Token: 0x04001E75 RID: 7797
	OnBuffTriggerEvent,
	// Token: 0x04001E76 RID: 7798
	CharAfterFrozenChange,
	// Token: 0x04001E77 RID: 7799
	CharClimbStartExit,
	// Token: 0x04001E78 RID: 7800
	CharActivateClimbInput,
	// Token: 0x04001E79 RID: 7801
	CharClimbJumpCheck,
	// Token: 0x04001E7A RID: 7802
	CustomMoveSwim,
	// Token: 0x04001E7B RID: 7803
	CustomMoveSlide,
	// Token: 0x04001E7C RID: 7804
	CustomMoveSki,
	// Token: 0x04001E7D RID: 7805
	CustomMoveRailSlide,
	// Token: 0x04001E7E RID: 7806
	CustomMoveRide,
	// Token: 0x04001E7F RID: 7807
	CustomMoveWalkOnWater,
	// Token: 0x04001E80 RID: 7808
	CustomMoveClimb,
	// Token: 0x04001E81 RID: 7809
	CustomMoveGlide,
	// Token: 0x04001E82 RID: 7810
	CustomMovePendulum,
	// Token: 0x04001E83 RID: 7811
	CustomMoveCatapult,
	// Token: 0x04001E84 RID: 7812
	CustomMoveSoar,
	// Token: 0x04001E85 RID: 7813
	CustomMoveRoll,
	// Token: 0x04001E86 RID: 7814
	CustomMoveSplineClimb,
	// Token: 0x04001E87 RID: 7815
	CustomMoveFloating,
	// Token: 0x04001E88 RID: 7816
	RequestRestartRailSlide,
	// Token: 0x04001E89 RID: 7817
	CharTurnBegin,
	// Token: 0x04001E8A RID: 7818
	CharTurnEnd,
	// Token: 0x04001E8B RID: 7819
	PerformMontageStop,
	// Token: 0x04001E8C RID: 7820
	CharMovementModeChanged,
	// Token: 0x04001E8D RID: 7821
	CharActivate,
	// Token: 0x04001E8E RID: 7822
	CharOnAttrChanged,
	// Token: 0x04001E8F RID: 7823
	CharGravityDirectChanged,
	// Token: 0x04001E90 RID: 7824
	AnyCharGravityDirectChanged,
	// Token: 0x04001E91 RID: 7825
	CharOnRoleDrown,
	// Token: 0x04001E92 RID: 7826
	CharOnRoleDrownInjure,
	// Token: 0x04001E93 RID: 7827
	CharOnEnergyChanged,
	// Token: 0x04001E94 RID: 7828
	CharOnHealthChanged,
	// Token: 0x04001E95 RID: 7829
	CharOnHealthMaxChanged,
	// Token: 0x04001E96 RID: 7830
	CharOnElementEnergyChanged,
	// Token: 0x04001E97 RID: 7831
	MonsterBeginBroken,
	// Token: 0x04001E98 RID: 7832
	CharOnUnifiedMoveStateChanged,
	// Token: 0x04001E99 RID: 7833
	CharOnPositionStateChanged,
	// Token: 0x04001E9A RID: 7834
	CharOnDirectionStateChanged,
	// Token: 0x04001E9B RID: 7835
	CharOnPositionSubStateChanged,
	// Token: 0x04001E9C RID: 7836
	CharSwimStrengthChanged,
	// Token: 0x04001E9D RID: 7837
	RoleOnStateInherit,
	// Token: 0x04001E9E RID: 7838
	CharOnEndPlay,
	// Token: 0x04001E9F RID: 7839
	CharOnBuffAddUITexture,
	// Token: 0x04001EA0 RID: 7840
	CharOnBuffAddUIPrefab,
	// Token: 0x04001EA1 RID: 7841
	CharOnBuffAddUIDamage,
	// Token: 0x04001EA2 RID: 7842
	CharOnBuffAddRoleSideEnergyBar,
	// Token: 0x04001EA3 RID: 7843
	CharOnBuffAddShowMoraleBuffTips,
	// Token: 0x04001EA4 RID: 7844
	OnRoverlikeQSkillBuff,
	// Token: 0x04001EA5 RID: 7845
	SeamlessTravelUIRefresh,
	// Token: 0x04001EA6 RID: 7846
	CharOnAnimNotifyStateDurationChange,
	// Token: 0x04001EA7 RID: 7847
	CharOnLand,
	// Token: 0x04001EA8 RID: 7848
	CharPossessed,
	// Token: 0x04001EA9 RID: 7849
	CharUnpossessed,
	// Token: 0x04001EAA RID: 7850
	CharChangeMeshAnim,
	// Token: 0x04001EAB RID: 7851
	CharRecordOperate,
	// Token: 0x04001EAC RID: 7852
	CharInputAction,
	// Token: 0x04001EAD RID: 7853
	CharBasePlatformChanged,
	// Token: 0x04001EAE RID: 7854
	CharHoldingHandsChanged,
	// Token: 0x04001EAF RID: 7855
	CharOnRoleDeadBefore,
	// Token: 0x04001EB0 RID: 7856
	CharOnRoleDead,
	// Token: 0x04001EB1 RID: 7857
	CharOnRoleDeadTargetSelf,
	// Token: 0x04001EB2 RID: 7858
	CharOnRoleDeadEnd,
	// Token: 0x04001EB3 RID: 7859
	OnRevive,
	// Token: 0x04001EB4 RID: 7860
	CharOnRevive,
	// Token: 0x04001EB5 RID: 7861
	OnTeamLivingStateChange,
	// Token: 0x04001EB6 RID: 7862
	OnShareReviveTimesChange,
	// Token: 0x04001EB7 RID: 7863
	OnRoleReviveCooldownChange,
	// Token: 0x04001EB8 RID: 7864
	CharOnSetNewBeHit,
	// Token: 0x04001EB9 RID: 7865
	OnBattleStateChanged,
	// Token: 0x04001EBA RID: 7866
	OnChangeWalkOrRun,
	// Token: 0x04001EBB RID: 7867
	CharOnFallInjure,
	// Token: 0x04001EBC RID: 7868
	ChangeAiTeamLevel,
	// Token: 0x04001EBD RID: 7869
	AiHateAddOrRemove,
	// Token: 0x04001EBE RID: 7870
	AiInFight,
	// Token: 0x04001EBF RID: 7871
	AiHateTargetChanged,
	// Token: 0x04001EC0 RID: 7872
	AiTauntAddOrRemove,
	// Token: 0x04001EC1 RID: 7873
	AiTaskWanderForResetEnd,
	// Token: 0x04001EC2 RID: 7874
	OnRunBehaviorTree,
	// Token: 0x04001EC3 RID: 7875
	OnAiEnable,
	// Token: 0x04001EC4 RID: 7876
	OnAiDisable,
	// Token: 0x04001EC5 RID: 7877
	OnBeforeAiDisable,
	// Token: 0x04001EC6 RID: 7878
	OnPatrolStart,
	// Token: 0x04001EC7 RID: 7879
	OnPatrolPause,
	// Token: 0x04001EC8 RID: 7880
	OnPatrolResume,
	// Token: 0x04001EC9 RID: 7881
	OnPatrolStop,
	// Token: 0x04001ECA RID: 7882
	CloseItemTips,
	// Token: 0x04001ECB RID: 7883
	CreateRoleForwardAnimEnd,
	// Token: 0x04001ECC RID: 7884
	CreateRoleShowInputName,
	// Token: 0x04001ECD RID: 7885
	GuideFinish,
	// Token: 0x04001ECE RID: 7886
	GuideGroupOpening,
	// Token: 0x04001ECF RID: 7887
	GuideGroupFinished,
	// Token: 0x04001ED0 RID: 7888
	GuideGroupBreak,
	// Token: 0x04001ED1 RID: 7889
	GuideGroupRest,
	// Token: 0x04001ED2 RID: 7890
	GuideFocusNeedUiTabView,
	// Token: 0x04001ED3 RID: 7891
	FinishGuideStepByEvent,
	// Token: 0x04001ED4 RID: 7892
	GuideTouchIdInject,
	// Token: 0x04001ED5 RID: 7893
	OnRefreshRoleHp,
	// Token: 0x04001ED6 RID: 7894
	BeforeLoadMap,
	// Token: 0x04001ED7 RID: 7895
	BeforeTravelMap,
	// Token: 0x04001ED8 RID: 7896
	EndTravelMap,
	// Token: 0x04001ED9 RID: 7897
	OnEnterTransitionMap,
	// Token: 0x04001EDA RID: 7898
	SeamlessTravelFinishBeforeShowUI,
	// Token: 0x04001EDB RID: 7899
	AfterLoadMap,
	// Token: 0x04001EDC RID: 7900
	ClearWorld,
	// Token: 0x04001EDD RID: 7901
	OnUiManagerClearAsync,
	// Token: 0x04001EDE RID: 7902
	WorldDone,
	// Token: 0x04001EDF RID: 7903
	WorldDoneAndCloseLoading,
	// Token: 0x04001EE0 RID: 7904
	ChangeMode,
	// Token: 0x04001EE1 RID: 7905
	ChangeModeFinish,
	// Token: 0x04001EE2 RID: 7906
	ChangePerformanceLimitMode,
	// Token: 0x04001EE3 RID: 7907
	PauseGame,
	// Token: 0x04001EE4 RID: 7908
	OnInitRole,
	// Token: 0x04001EE5 RID: 7909
	OnChangeRole,
	// Token: 0x04001EE6 RID: 7910
	OnOtherChangeRole,
	// Token: 0x04001EE7 RID: 7911
	OnChangeRoleCoolDownChanged,
	// Token: 0x04001EE8 RID: 7912
	OnBeforeChangeRole,
	// Token: 0x04001EE9 RID: 7913
	OnRoleGoDown,
	// Token: 0x04001EEA RID: 7914
	OnRoleGoDownFinish,
	// Token: 0x04001EEB RID: 7915
	OnOtherRoleGoDownFinish,
	// Token: 0x04001EEC RID: 7916
	OnRoleGoUpEnable,
	// Token: 0x04001EED RID: 7917
	OnRoleGoUp,
	// Token: 0x04001EEE RID: 7918
	OnClearFollowData,
	// Token: 0x04001EEF RID: 7919
	OnRoleGameplayAnimInstChanged,
	// Token: 0x04001EF0 RID: 7920
	InitArea,
	// Token: 0x04001EF1 RID: 7921
	InitStaticEntity,
	// Token: 0x04001EF2 RID: 7922
	OnManuallyClearStreamingPool,
	// Token: 0x04001EF3 RID: 7923
	OnManuallyResetStreamingPool,
	// Token: 0x04001EF4 RID: 7924
	OnDeadEyeModeTrigger,
	// Token: 0x04001EF5 RID: 7925
	OnDeadEyeModeShowShooter,
	// Token: 0x04001EF6 RID: 7926
	OnDeadEyeModeStageChange,
	// Token: 0x04001EF7 RID: 7927
	OnDeadEyeModeFinish,
	// Token: 0x04001EF8 RID: 7928
	DeadEyeModeTargetPointCanLockStateChange,
	// Token: 0x04001EF9 RID: 7929
	DeadEyeModeTargetPointLocked,
	// Token: 0x04001EFA RID: 7930
	DeadEyeModeShootingPerformance,
	// Token: 0x04001EFB RID: 7931
	TransportFindPath,
	// Token: 0x04001EFC RID: 7932
	TransportSystemInitDone,
	// Token: 0x04001EFD RID: 7933
	VehicleMemberBlockByTraceTarget,
	// Token: 0x04001EFE RID: 7934
	ChangeArea,
	// Token: 0x04001EFF RID: 7935
	UpdateAreaView,
	// Token: 0x04001F00 RID: 7936
	CreateEntity,
	// Token: 0x04001F01 RID: 7937
	CreateEntityFail,
	// Token: 0x04001F02 RID: 7938
	AddEntity,
	// Token: 0x04001F03 RID: 7939
	FixBornLocation,
	// Token: 0x04001F04 RID: 7940
	CharBornFinished,
	// Token: 0x04001F05 RID: 7941
	PreloadEntityFinished,
	// Token: 0x04001F06 RID: 7942
	RemoveEntity,
	// Token: 0x04001F07 RID: 7943
	RemoveEntityFromBindGroup,
	// Token: 0x04001F08 RID: 7944
	EntityOnLandedPush,
	// Token: 0x04001F09 RID: 7945
	EntityVarUpdate,
	// Token: 0x04001F0A RID: 7946
	SpawnPlayer,
	// Token: 0x04001F0B RID: 7947
	OnUpdateTeamGroupType,
	// Token: 0x04001F0C RID: 7948
	OnBeforeUpdateSceneTeam,
	// Token: 0x04001F0D RID: 7949
	OnUpdateSceneTeam,
	// Token: 0x04001F0E RID: 7950
	OnItemDecompose,
	// Token: 0x04001F0F RID: 7951
	OnItemLock,
	// Token: 0x04001F10 RID: 7952
	OnItemFuncValueChange,
	// Token: 0x04001F11 RID: 7953
	OnItemFuncValueBatchChange,
	// Token: 0x04001F12 RID: 7954
	OnGetReward,
	// Token: 0x04001F13 RID: 7955
	OnReceivePlayerVar,
	// Token: 0x04001F14 RID: 7956
	OpenItemInfo,
	// Token: 0x04001F15 RID: 7957
	CloseItemInfo,
	// Token: 0x04001F16 RID: 7958
	BoughtItem,
	// Token: 0x04001F17 RID: 7959
	ShopUpdate,
	// Token: 0x04001F18 RID: 7960
	OnShopInfoResponded,
	// Token: 0x04001F19 RID: 7961
	OnGoodUnlock,
	// Token: 0x04001F1A RID: 7962
	SelectedMail,
	// Token: 0x04001F1B RID: 7963
	PickingAttachment,
	// Token: 0x04001F1C RID: 7964
	DeletingMail,
	// Token: 0x04001F1D RID: 7965
	DeletingMailPassively,
	// Token: 0x04001F1E RID: 7966
	AddingNewMail,
	// Token: 0x04001F1F RID: 7967
	SwitchUnfinishedFlag,
	// Token: 0x04001F20 RID: 7968
	MailFavoriteChanged,
	// Token: 0x04001F21 RID: 7969
	CloseMailView,
	// Token: 0x04001F22 RID: 7970
	OnlyCloseMailContentView,
	// Token: 0x04001F23 RID: 7971
	SceneBulletOwnerCreated,
	// Token: 0x04001F24 RID: 7972
	BulletCreate,
	// Token: 0x04001F25 RID: 7973
	BulletDestroy,
	// Token: 0x04001F26 RID: 7974
	BulletHit,
	// Token: 0x04001F27 RID: 7975
	PreBulletCreateFromAnimNotify,
	// Token: 0x04001F28 RID: 7976
	PostBulletCreateFromAnimNotify,
	// Token: 0x04001F29 RID: 7977
	BulletRebound,
	// Token: 0x04001F2A RID: 7978
	BulletHitSpecialCharacter,
	// Token: 0x04001F2B RID: 7979
	BulletHitAirWall,
	// Token: 0x04001F2C RID: 7980
	BulletPatternEnvironmentChanged,
	// Token: 0x04001F2D RID: 7981
	ScenePlayerChanged,
	// Token: 0x04001F2E RID: 7982
	ScenePlayerLocationChanged,
	// Token: 0x04001F2F RID: 7983
	ScenePlayerLeaveScene,
	// Token: 0x04001F30 RID: 7984
	ScenePlayerMarkItemStateChange,
	// Token: 0x04001F31 RID: 7985
	MatchTeamFlagChange,
	// Token: 0x04001F32 RID: 7986
	LoadingViewProgressSequenceEnd,
	// Token: 0x04001F33 RID: 7987
	LoadingViewOnAfterShow,
	// Token: 0x04001F34 RID: 7988
	DestroyAllUiCameraAnimationHandles,
	// Token: 0x04001F35 RID: 7989
	RoleSelectionListUpdate,
	// Token: 0x04001F36 RID: 7990
	SelectRole,
	// Token: 0x04001F37 RID: 7991
	SelectSkill,
	// Token: 0x04001F38 RID: 7992
	SelectLevelUpItem,
	// Token: 0x04001F39 RID: 7993
	RoleInfoUpdate,
	// Token: 0x04001F3A RID: 7994
	RoleRefreshAttribute,
	// Token: 0x04001F3B RID: 7995
	RoleSkillLevelUp,
	// Token: 0x04001F3C RID: 7996
	RoleLevelUp,
	// Token: 0x04001F3D RID: 7997
	RoleLevelUpReceiveItem,
	// Token: 0x04001F3E RID: 7998
	RoleBreakUp,
	// Token: 0x04001F3F RID: 7999
	ActiveRole,
	// Token: 0x04001F40 RID: 8000
	RoleSkinRedDotRefresh,
	// Token: 0x04001F41 RID: 8001
	HuluSkinRedDotRefresh,
	// Token: 0x04001F42 RID: 8002
	RoleOrnamentRedDotRefresh,
	// Token: 0x04001F43 RID: 8003
	MainViewRoleButtonRefreshByRoleOrnament,
	// Token: 0x04001F44 RID: 8004
	MainViewRoleButtonRefreshByRoleSkin,
	// Token: 0x04001F45 RID: 8005
	RoleResonUplevel,
	// Token: 0x04001F46 RID: 8006
	RoleResonActive,
	// Token: 0x04001F47 RID: 8007
	RoleResonAnimationSuccess,
	// Token: 0x04001F48 RID: 8008
	RoleResonPlayAnimation,
	// Token: 0x04001F49 RID: 8009
	RoleLangCustomFuncClicked,
	// Token: 0x04001F4A RID: 8010
	RoleLangCustomRefresh,
	// Token: 0x04001F4B RID: 8011
	CloseRoleView,
	// Token: 0x04001F4C RID: 8012
	SelectedResonanceTab,
	// Token: 0x04001F4D RID: 8013
	UnSelectedResonanceTab,
	// Token: 0x04001F4E RID: 8014
	SwitchRootTabState,
	// Token: 0x04001F4F RID: 8015
	RoleRefreshName,
	// Token: 0x04001F50 RID: 8016
	RoleSystemChangeRole,
	// Token: 0x04001F51 RID: 8017
	RoleSystemDeleteRole,
	// Token: 0x04001F52 RID: 8018
	OnSelectedRoleChanged,
	// Token: 0x04001F53 RID: 8019
	OnRoleMorphTypeChanged,
	// Token: 0x04001F54 RID: 8020
	HideVisionTabRole,
	// Token: 0x04001F55 RID: 8021
	ChangeResonance,
	// Token: 0x04001F56 RID: 8022
	OnRoleInternalViewEnter,
	// Token: 0x04001F57 RID: 8023
	OnRoleInternalViewQuit,
	// Token: 0x04001F58 RID: 8024
	AttributeComponentEvent,
	// Token: 0x04001F59 RID: 8025
	UpdateRoleLevelUpViewData,
	// Token: 0x04001F5A RID: 8026
	UpdateRoleResonanceDetailView,
	// Token: 0x04001F5B RID: 8027
	UpdateRoleSkillLevelUpView,
	// Token: 0x04001F5C RID: 8028
	RefreshSkillTreeInfoTabView,
	// Token: 0x04001F5D RID: 8029
	SkillTreeRefresh,
	// Token: 0x04001F5E RID: 8030
	RefreshSkillTreeLeftSkillPoint,
	// Token: 0x04001F5F RID: 8031
	SkillTreeReset,
	// Token: 0x04001F60 RID: 8032
	SkillTreeClickEmpty,
	// Token: 0x04001F61 RID: 8033
	SkillTreeNodeActive,
	// Token: 0x04001F62 RID: 8034
	SkillTreeNodeLevelUp,
	// Token: 0x04001F63 RID: 8035
	OnSkillTreeNodeToggleClick,
	// Token: 0x04001F64 RID: 8036
	UpdateRoleFavorData,
	// Token: 0x04001F65 RID: 8037
	UnLockRoleFavorItem,
	// Token: 0x04001F66 RID: 8038
	RoleFavorExpChange,
	// Token: 0x04001F67 RID: 8039
	UpdateRoleFavorHintView,
	// Token: 0x04001F68 RID: 8040
	RefreshFunctionOpenView,
	// Token: 0x04001F69 RID: 8041
	ExploreComponentTargetChanged,
	// Token: 0x04001F6A RID: 8042
	UpdateRoleBreachView,
	// Token: 0x04001F6B RID: 8043
	OnClickSkillLevelUp,
	// Token: 0x04001F6C RID: 8044
	OnClickSkillActive,
	// Token: 0x04001F6D RID: 8045
	OnEnterOrExitUltraSkill,
	// Token: 0x04001F6E RID: 8046
	OnRoleSkinChange,
	// Token: 0x04001F6F RID: 8047
	OnRoleSkinSubViewShow,
	// Token: 0x04001F70 RID: 8048
	OnInteractionWaterTypeChange,
	// Token: 0x04001F71 RID: 8049
	OnRoleBackgroundMusicEnabledChanged,
	// Token: 0x04001F72 RID: 8050
	OnCurTrialRoleGroupChanged,
	// Token: 0x04001F73 RID: 8051
	OnGroupTrialRoleChanged,
	// Token: 0x04001F74 RID: 8052
	OnRoleSkillBranchChanged,
	// Token: 0x04001F75 RID: 8053
	OnSkillShowTagToggleChanged,
	// Token: 0x04001F76 RID: 8054
	WeaponLevelUp,
	// Token: 0x04001F77 RID: 8055
	WeaponLevelUpReceiveItem,
	// Token: 0x04001F78 RID: 8056
	WeaponCanGoBreach,
	// Token: 0x04001F79 RID: 8057
	WeaponBreakUp,
	// Token: 0x04001F7A RID: 8058
	WeaponRoleEquipChanged,
	// Token: 0x04001F7B RID: 8059
	WeaponRoleLevelUp,
	// Token: 0x04001F7C RID: 8060
	WeaponRoleBreakUp,
	// Token: 0x04001F7D RID: 8061
	WeaponItemClick,
	// Token: 0x04001F7E RID: 8062
	WeaponEmptyClick,
	// Token: 0x04001F7F RID: 8063
	WeaponSortClick,
	// Token: 0x04001F80 RID: 8064
	WeaponMaterialPropClick,
	// Token: 0x04001F81 RID: 8065
	EquipWeapon,
	// Token: 0x04001F82 RID: 8066
	ContrastWeapon,
	// Token: 0x04001F83 RID: 8067
	WeaponResonanceSuccess,
	// Token: 0x04001F84 RID: 8068
	ReConnectBegin,
	// Token: 0x04001F85 RID: 8069
	ReConnectFail,
	// Token: 0x04001F86 RID: 8070
	CanNotReConnect,
	// Token: 0x04001F87 RID: 8071
	ReConnectSuccess,
	// Token: 0x04001F88 RID: 8072
	BackLoginView,
	// Token: 0x04001F89 RID: 8073
	LogOut,
	// Token: 0x04001F8A RID: 8074
	ExitGamePush,
	// Token: 0x04001F8B RID: 8075
	NetWorkMaskRpcAdd,
	// Token: 0x04001F8C RID: 8076
	NetWorkMaskRpcRemove,
	// Token: 0x04001F8D RID: 8077
	OnAimStateChanged,
	// Token: 0x04001F8E RID: 8078
	OnPhantomInputDataUpdate,
	// Token: 0x04001F8F RID: 8079
	OpenDragonPoolView,
	// Token: 0x04001F90 RID: 8080
	UpdateDragonPoolView,
	// Token: 0x04001F91 RID: 8081
	LoadMapTileFinish,
	// Token: 0x04001F92 RID: 8082
	MapOpenFogChange,
	// Token: 0x04001F93 RID: 8083
	MapOpenFogFullUpdate,
	// Token: 0x04001F94 RID: 8084
	MapAreaDarkShow,
	// Token: 0x04001F95 RID: 8085
	WorldMapSecondaryUiClosed,
	// Token: 0x04001F96 RID: 8086
	WorldMapSecondaryUiOpened,
	// Token: 0x04001F97 RID: 8087
	BlackScreenFadeOnPlotToWorldMap,
	// Token: 0x04001F98 RID: 8088
	MarkMenuClickItem,
	// Token: 0x04001F99 RID: 8089
	TrackMenuClickItem,
	// Token: 0x04001F9A RID: 8090
	RefreshMenuSetting,
	// Token: 0x04001F9B RID: 8091
	OnGameplaySettingsSet,
	// Token: 0x04001F9C RID: 8092
	ModelReady,
	// Token: 0x04001F9D RID: 8093
	MapReplaceMarkResponse,
	// Token: 0x04001F9E RID: 8094
	CreateMapMark,
	// Token: 0x04001F9F RID: 8095
	CreateTempMapMark,
	// Token: 0x04001FA0 RID: 8096
	AddMapMark,
	// Token: 0x04001FA1 RID: 8097
	RemoveMapMark,
	// Token: 0x04001FA2 RID: 8098
	TrackMapMark,
	// Token: 0x04001FA3 RID: 8099
	MarkHideState,
	// Token: 0x04001FA4 RID: 8100
	OnMapMarkTaskComplete,
	// Token: 0x04001FA5 RID: 8101
	UnlockTeleport,
	// Token: 0x04001FA6 RID: 8102
	TrackMark,
	// Token: 0x04001FA7 RID: 8103
	UnTrackMark,
	// Token: 0x04001FA8 RID: 8104
	OnMarkItemTrackStateChange,
	// Token: 0x04001FA9 RID: 8105
	ClearTrackMark,
	// Token: 0x04001FAA RID: 8106
	MarkForceVisibleChanged,
	// Token: 0x04001FAB RID: 8107
	UpdateTrackTarget,
	// Token: 0x04001FAC RID: 8108
	SetTrackMarkOccupied,
	// Token: 0x04001FAD RID: 8109
	TeleportComplete,
	// Token: 0x04001FAE RID: 8110
	TeleportChangeLocation,
	// Token: 0x04001FAF RID: 8111
	TeleportStart,
	// Token: 0x04001FB0 RID: 8112
	TeleportStartEntity,
	// Token: 0x04001FB1 RID: 8113
	TeleportOpenLoadingEnd,
	// Token: 0x04001FB2 RID: 8114
	SetFightDtTypeForDebug,
	// Token: 0x04001FB3 RID: 8115
	OnEnterDailyQuestNotifyRange,
	// Token: 0x04001FB4 RID: 8116
	OnEnterNearbyTrackRange,
	// Token: 0x04001FB5 RID: 8117
	OnLeaveNearbyTrackRange,
	// Token: 0x04001FB6 RID: 8118
	RemoveNearbyTrack,
	// Token: 0x04001FB7 RID: 8119
	UpdateNearbyTrackTag,
	// Token: 0x04001FB8 RID: 8120
	OnUpdateNearbyEnable,
	// Token: 0x04001FB9 RID: 8121
	OnUpdateCompassActive,
	// Token: 0x04001FBA RID: 8122
	WorldMapViewOpened,
	// Token: 0x04001FBB RID: 8123
	WorldMapPointerDown,
	// Token: 0x04001FBC RID: 8124
	WorldMapPointerDrag,
	// Token: 0x04001FBD RID: 8125
	WorldMapJoystickMoveForward,
	// Token: 0x04001FBE RID: 8126
	WorldMapJoystickMoveRight,
	// Token: 0x04001FBF RID: 8127
	WorldMapFocusPlayer,
	// Token: 0x04001FC0 RID: 8128
	WorldMapShowTrackList,
	// Token: 0x04001FC1 RID: 8129
	WorldMapDragInertia,
	// Token: 0x04001FC2 RID: 8130
	WorldMapPointerUp,
	// Token: 0x04001FC3 RID: 8131
	WorldMapFingerExpandClose,
	// Token: 0x04001FC4 RID: 8132
	WorldMapWheelAxisInput,
	// Token: 0x04001FC5 RID: 8133
	WorldMapHandleTriggerAxisInput,
	// Token: 0x04001FC6 RID: 8134
	WorldMapZoomBtnInput,
	// Token: 0x04001FC7 RID: 8135
	WorldMapPositionChanged,
	// Token: 0x04001FC8 RID: 8136
	WorldMapUpdateMultiMap,
	// Token: 0x04001FC9 RID: 8137
	MoveWorldMapToPosition,
	// Token: 0x04001FCA RID: 8138
	TaskRangeTrackStateChange,
	// Token: 0x04001FCB RID: 8139
	RangeTrackStateChanged,
	// Token: 0x04001FCC RID: 8140
	GetAreaProgress,
	// Token: 0x04001FCD RID: 8141
	PlaySoundTrackEffect,
	// Token: 0x04001FCE RID: 8142
	WorldMapNavigate,
	// Token: 0x04001FCF RID: 8143
	WorldMapFirstNavigateSelect,
	// Token: 0x04001FD0 RID: 8144
	WorldMapSecondNavigateSelect,
	// Token: 0x04001FD1 RID: 8145
	WorldMapFocalMarkItem,
	// Token: 0x04001FD2 RID: 8146
	ChangeWorldMap,
	// Token: 0x04001FD3 RID: 8147
	WorldMapBeforeChangeMap,
	// Token: 0x04001FD4 RID: 8148
	WorldMapAfterChangeMap,
	// Token: 0x04001FD5 RID: 8149
	WorldMapOpenedForQuestMapFocus,
	// Token: 0x04001FD6 RID: 8150
	EnterAreaNotify,
	// Token: 0x04001FD7 RID: 8151
	MiniMapForceUpdate,
	// Token: 0x04001FD8 RID: 8152
	MultiMapUnlockChanged,
	// Token: 0x04001FD9 RID: 8153
	MapAreaShowClickArea,
	// Token: 0x04001FDA RID: 8154
	MapExploreDetailItemClick,
	// Token: 0x04001FDB RID: 8155
	OnUpdateExploreProgressBar,
	// Token: 0x04001FDC RID: 8156
	OnUpdateGravityBtn,
	// Token: 0x04001FDD RID: 8157
	OnMarkTopRightIconUpdate,
	// Token: 0x04001FDE RID: 8158
	WorldMapActivityListDataUpdate,
	// Token: 0x04001FDF RID: 8159
	WorldMapExtraMarkTypeVisibleChange,
	// Token: 0x04001FE0 RID: 8160
	OpenExtraUiFromMap,
	// Token: 0x04001FE1 RID: 8161
	CloseAllExtraUiFromMap,
	// Token: 0x04001FE2 RID: 8162
	WorldMapPanelHudVisibleChanged,
	// Token: 0x04001FE3 RID: 8163
	OnWorldMapClose,
	// Token: 0x04001FE4 RID: 8164
	SetWorldMapCursorButtonVisible,
	// Token: 0x04001FE5 RID: 8165
	UpdatePlotSubtitle,
	// Token: 0x04001FE6 RID: 8166
	ShowPlotSubtitleOptions,
	// Token: 0x04001FE7 RID: 8167
	UpdatePlotCenterText,
	// Token: 0x04001FE8 RID: 8168
	UpdatePortraitVisible,
	// Token: 0x04001FE9 RID: 8169
	OnStartFlow,
	// Token: 0x04001FEA RID: 8170
	PlotNetworkStart,
	// Token: 0x04001FEB RID: 8171
	PlotNetworkEnd,
	// Token: 0x04001FEC RID: 8172
	OnExecuteAfterSetPlotMode,
	// Token: 0x04001FED RID: 8173
	PlotConfigChanged,
	// Token: 0x04001FEE RID: 8174
	PlotDoingTextShow,
	// Token: 0x04001FEF RID: 8175
	ClearPlotSubtitle,
	// Token: 0x04001FF0 RID: 8176
	HidePlotUi,
	// Token: 0x04001FF1 RID: 8177
	PlotInteractViewOpen,
	// Token: 0x04001FF2 RID: 8178
	TriggerPlotInteraction,
	// Token: 0x04001FF3 RID: 8179
	TriggerBlackSequence,
	// Token: 0x04001FF4 RID: 8180
	OnBlackFadeScreenStart,
	// Token: 0x04001FF5 RID: 8181
	OnBlackFadeScreenFinish,
	// Token: 0x04001FF6 RID: 8182
	EnableInteractPlot,
	// Token: 0x04001FF7 RID: 8183
	EnableSkipPlot,
	// Token: 0x04001FF8 RID: 8184
	PlotSequencePlay,
	// Token: 0x04001FF9 RID: 8185
	PlotSequenceStarted,
	// Token: 0x04001FFA RID: 8186
	PlotSequenceEnd,
	// Token: 0x04001FFB RID: 8187
	HangPlotViewHud,
	// Token: 0x04001FFC RID: 8188
	UpdatePlotUiParam,
	// Token: 0x04001FFD RID: 8189
	PlotViewChange,
	// Token: 0x04001FFE RID: 8190
	PlotViewBgFadePhoto,
	// Token: 0x04001FFF RID: 8191
	PlotViewBgFadeBlackScreen,
	// Token: 0x04002000 RID: 8192
	PlotStartShowTalk,
	// Token: 0x04002001 RID: 8193
	PlotEndShowTalk,
	// Token: 0x04002002 RID: 8194
	PlotShowTalk,
	// Token: 0x04002003 RID: 8195
	PlotEnableControlView,
	// Token: 0x04002004 RID: 8196
	PlayPlotSpine,
	// Token: 0x04002005 RID: 8197
	FiniteSpineEnd,
	// Token: 0x04002006 RID: 8198
	PrewarFormationChanged,
	// Token: 0x04002007 RID: 8199
	PrewarReadyChanged,
	// Token: 0x04002008 RID: 8200
	DissolvePrewar,
	// Token: 0x04002009 RID: 8201
	SceneStepGroupChanged,
	// Token: 0x0400200A RID: 8202
	InstanceStepChanged,
	// Token: 0x0400200B RID: 8203
	InstanceEnterCountChanged,
	// Token: 0x0400200C RID: 8204
	InstanceEntranceUnlock,
	// Token: 0x0400200D RID: 8205
	EnterInstanceDungeon,
	// Token: 0x0400200E RID: 8206
	EnterInstanceDungeonFail,
	// Token: 0x0400200F RID: 8207
	LeaveInstanceDungeon,
	// Token: 0x04002010 RID: 8208
	DungeonGuideChange,
	// Token: 0x04002011 RID: 8209
	LeaveInstanceDungeonConfirm,
	// Token: 0x04002012 RID: 8210
	LeaveInstanceExternalConfirm,
	// Token: 0x04002013 RID: 8211
	LeaveInstanceExternalCancel,
	// Token: 0x04002014 RID: 8212
	OnRefreshInstancedRecommendLevel,
	// Token: 0x04002015 RID: 8213
	OnDungeonFinish,
	// Token: 0x04002016 RID: 8214
	OnSelectInstance,
	// Token: 0x04002017 RID: 8215
	OnSelectInstanceIdChallenge,
	// Token: 0x04002018 RID: 8216
	OnChallengeInstanceRedDot,
	// Token: 0x04002019 RID: 8217
	CloseInstanceEntrancePositively,
	// Token: 0x0400201A RID: 8218
	OnRefreshEditBattleRoleSlotData,
	// Token: 0x0400201B RID: 8219
	OnRefreshEditBattleRoleReady,
	// Token: 0x0400201C RID: 8220
	EntityVisionSkillChanged,
	// Token: 0x0400201D RID: 8221
	EntityVisionPosChanged,
	// Token: 0x0400201E RID: 8222
	GetAllVisionSkill,
	// Token: 0x0400201F RID: 8223
	ActivateAbilityVision,
	// Token: 0x04002020 RID: 8224
	EndVisionSkill,
	// Token: 0x04002021 RID: 8225
	ExploreVisionSkill,
	// Token: 0x04002022 RID: 8226
	VisionMorphBegin,
	// Token: 0x04002023 RID: 8227
	VisionMorphEnd,
	// Token: 0x04002024 RID: 8228
	VisionMorphInterrupt,
	// Token: 0x04002025 RID: 8229
	AddExploreVisionSkill,
	// Token: 0x04002026 RID: 8230
	ChangeVisionSkillByTab,
	// Token: 0x04002027 RID: 8231
	ChangeVisionSimplyState,
	// Token: 0x04002028 RID: 8232
	VisionSkinViewClose,
	// Token: 0x04002029 RID: 8233
	ChangeCalabashCollectSimplyState,
	// Token: 0x0400202A RID: 8234
	SelectedPhantom,
	// Token: 0x0400202B RID: 8235
	CheckNewUnlock,
	// Token: 0x0400202C RID: 8236
	PhantomEquip,
	// Token: 0x0400202D RID: 8237
	PhantomEquipError,
	// Token: 0x0400202E RID: 8238
	VisionFilterMonster,
	// Token: 0x0400202F RID: 8239
	OnRolePropUpdate,
	// Token: 0x04002030 RID: 8240
	RefreshVisionIntensifyViewBackBtnState,
	// Token: 0x04002031 RID: 8241
	OnClickVisionIntensifyItemJump,
	// Token: 0x04002032 RID: 8242
	VisionIntensifyTabOpen,
	// Token: 0x04002033 RID: 8243
	OnVisionLevelUpMaterialPutInModeChange,
	// Token: 0x04002034 RID: 8244
	OnVisionLevelUpIdentifyChange,
	// Token: 0x04002035 RID: 8245
	PhantomPersonalSkillActive,
	// Token: 0x04002036 RID: 8246
	PhantomEquipWithSourceAndTargetPos,
	// Token: 0x04002037 RID: 8247
	PhantomCostInsufficient,
	// Token: 0x04002038 RID: 8248
	PhantomExpPreviewChange,
	// Token: 0x04002039 RID: 8249
	PhantomLevelUp,
	// Token: 0x0400203A RID: 8250
	PhantomLevelUpWithId,
	// Token: 0x0400203B RID: 8251
	PhantomLevelUpReceiveItem,
	// Token: 0x0400203C RID: 8252
	CloseSubPhantomView,
	// Token: 0x0400203D RID: 8253
	PhantomBreach,
	// Token: 0x0400203E RID: 8254
	PhantomBreachPreview,
	// Token: 0x0400203F RID: 8255
	PhantomDecomposePreview,
	// Token: 0x04002040 RID: 8256
	PhantomDecompose,
	// Token: 0x04002041 RID: 8257
	PhantomMaxLevelSkip,
	// Token: 0x04002042 RID: 8258
	HideDelFettersText,
	// Token: 0x04002043 RID: 8259
	PhantomRecommendResponse,
	// Token: 0x04002044 RID: 8260
	ClosePhantomSkillTips,
	// Token: 0x04002045 RID: 8261
	OnPhantomItemUpdate,
	// Token: 0x04002046 RID: 8262
	OnPhantomSlotUpdate,
	// Token: 0x04002047 RID: 8263
	OnPhantomEnableStateChange,
	// Token: 0x04002048 RID: 8264
	OnVisionIdentify,
	// Token: 0x04002049 RID: 8265
	OnVisionIdentifyWithId,
	// Token: 0x0400204A RID: 8266
	OnVisionIdentifyDoAnimation,
	// Token: 0x0400204B RID: 8267
	RefreshVisionIdentifyRedPoint,
	// Token: 0x0400204C RID: 8268
	RefreshVisionLevelUpSettingRedPoint,
	// Token: 0x0400204D RID: 8269
	RefreshVisionEquipRedPoint,
	// Token: 0x0400204E RID: 8270
	JumpToCalabashCollect,
	// Token: 0x0400204F RID: 8271
	JumpToPhantomBattleFettersTabView,
	// Token: 0x04002050 RID: 8272
	OnVisionSkinEquip,
	// Token: 0x04002051 RID: 8273
	RedDotRefreshCalabash,
	// Token: 0x04002052 RID: 8274
	HasCalabashExp,
	// Token: 0x04002053 RID: 8275
	CloseUpgradeCalabashView,
	// Token: 0x04002054 RID: 8276
	CloseCalabashExpAddView,
	// Token: 0x04002055 RID: 8277
	ShowCalabashControllerView,
	// Token: 0x04002056 RID: 8278
	GetCalabashRewardSuccess,
	// Token: 0x04002057 RID: 8279
	ShowCalabashUnlockItemTips,
	// Token: 0x04002058 RID: 8280
	GetCalabashReward,
	// Token: 0x04002059 RID: 8281
	SelectDirectionalFusionTarget,
	// Token: 0x0400205A RID: 8282
	PhantomDirectRefiningWeeklyReset,
	// Token: 0x0400205B RID: 8283
	CalabashLevelUpdate,
	// Token: 0x0400205C RID: 8284
	CalabashEnterInternalView,
	// Token: 0x0400205D RID: 8285
	CalabashQuitInternalView,
	// Token: 0x0400205E RID: 8286
	OnVisionRecoveryResult,
	// Token: 0x0400205F RID: 8287
	OnVisionRecoveryBatchResult,
	// Token: 0x04002060 RID: 8288
	OnVisionRecoveryStorage,
	// Token: 0x04002061 RID: 8289
	OnVisionRefineStorage,
	// Token: 0x04002062 RID: 8290
	OnVisionRefineResult,
	// Token: 0x04002063 RID: 8291
	OnVisionRefineBatchMainResult,
	// Token: 0x04002064 RID: 8292
	OnVisionRefineSubPreviewResult,
	// Token: 0x04002065 RID: 8293
	OnVisionRefineSubResult,
	// Token: 0x04002066 RID: 8294
	OnVisionRefineSubNeedAck,
	// Token: 0x04002067 RID: 8295
	OnVisionGroupDataUpdate,
	// Token: 0x04002068 RID: 8296
	OnVisionGroupDataAdd,
	// Token: 0x04002069 RID: 8297
	OnVisionGroupDataToTop,
	// Token: 0x0400206A RID: 8298
	OnVisionGroupDataDelete,
	// Token: 0x0400206B RID: 8299
	OnVisionGroupDataChangeName,
	// Token: 0x0400206C RID: 8300
	OnRefreshCalabashTabShowState,
	// Token: 0x0400206D RID: 8301
	OnSetPartStateVisible,
	// Token: 0x0400206E RID: 8302
	ShowHUD,
	// Token: 0x0400206F RID: 8303
	HideHUD,
	// Token: 0x04002070 RID: 8304
	OnGetPlayerBasicInfo,
	// Token: 0x04002071 RID: 8305
	OnLoadedNewFlagConfig,
	// Token: 0x04002072 RID: 8306
	OnPlayerLevelChanged,
	// Token: 0x04002073 RID: 8307
	OnPlayerExpChanged,
	// Token: 0x04002074 RID: 8308
	OnLevelUpLevelRefresh,
	// Token: 0x04002075 RID: 8309
	OnLevelUpExpRefresh,
	// Token: 0x04002076 RID: 8310
	OnLevelUpShowLevelOnly,
	// Token: 0x04002077 RID: 8311
	SelectFilterMultiple,
	// Token: 0x04002078 RID: 8312
	SelectFilterSingle,
	// Token: 0x04002079 RID: 8313
	SelectSort,
	// Token: 0x0400207A RID: 8314
	OnLevelPlayStateNotify,
	// Token: 0x0400207B RID: 8315
	OnEnterLevelPlayNotify,
	// Token: 0x0400207C RID: 8316
	OnLeaveLevelPlayNotify,
	// Token: 0x0400207D RID: 8317
	OnSceneItemHit,
	// Token: 0x0400207E RID: 8318
	OnSceneItemHitByHitData,
	// Token: 0x0400207F RID: 8319
	OnSceneItemEntityHit,
	// Token: 0x04002080 RID: 8320
	OnSceneItemEntityHitByHitActorData,
	// Token: 0x04002081 RID: 8321
	OnSceneItemEntityHitAlways,
	// Token: 0x04002082 RID: 8322
	OnAnySceneItemEntityHit,
	// Token: 0x04002083 RID: 8323
	OnAnySceneItemDurabilityChange,
	// Token: 0x04002084 RID: 8324
	OnSceneItemDurabilityChange,
	// Token: 0x04002085 RID: 8325
	OnEnableSceneItemDurabilityUI,
	// Token: 0x04002086 RID: 8326
	OnSceneItemSwitchMoveControl,
	// Token: 0x04002087 RID: 8327
	UpdateSceneItemState,
	// Token: 0x04002088 RID: 8328
	OnSceneItemDurabilityEmpty,
	// Token: 0x04002089 RID: 8329
	OnSceneItemStateChange,
	// Token: 0x0400208A RID: 8330
	OnSceneItemStatePreChange,
	// Token: 0x0400208B RID: 8331
	OnSceneItemStatePreChangeInSequence,
	// Token: 0x0400208C RID: 8332
	OnSceneItemCameraAlertStateChange,
	// Token: 0x0400208D RID: 8333
	OnEntityConcealedChange,
	// Token: 0x0400208E RID: 8334
	OnEntityNameChanged,
	// Token: 0x0400208F RID: 8335
	OnTimeTrackControlUpdate,
	// Token: 0x04002090 RID: 8336
	OnSceneInteractionLoadCompleted,
	// Token: 0x04002091 RID: 8337
	OnSceneInteractionLoadCompletedNew,
	// Token: 0x04002092 RID: 8338
	OnSceneInteractionShowCompleted,
	// Token: 0x04002093 RID: 8339
	OnSceneInteractionHideCompleted,
	// Token: 0x04002094 RID: 8340
	OnSceneInteractionAllEffectPlaying,
	// Token: 0x04002095 RID: 8341
	OnSceneInteractionSequencePlay,
	// Token: 0x04002096 RID: 8342
	OnSceneInteractionSequenceOver,
	// Token: 0x04002097 RID: 8343
	OnSceneItemVisionCaptureAdd,
	// Token: 0x04002098 RID: 8344
	OnSceneItemVisionCaptureRemove,
	// Token: 0x04002099 RID: 8345
	OnSceneItemVisionCaptureAddFinish,
	// Token: 0x0400209A RID: 8346
	ShowItemTips,
	// Token: 0x0400209B RID: 8347
	OnInputDistributeTagChanged,
	// Token: 0x0400209C RID: 8348
	OnDeviceLangChange,
	// Token: 0x0400209D RID: 8349
	ForceReleaseInput,
	// Token: 0x0400209E RID: 8350
	GuideLimitActionInput,
	// Token: 0x0400209F RID: 8351
	OnFormationPlayLevelUp,
	// Token: 0x040020A0 RID: 8352
	OnFormationPlayRevive,
	// Token: 0x040020A1 RID: 8353
	OnItemUse,
	// Token: 0x040020A2 RID: 8354
	OnSpecialItemUse,
	// Token: 0x040020A3 RID: 8355
	OnLevelTagChanged,
	// Token: 0x040020A4 RID: 8356
	OnGlobalGameplayTagChanged,
	// Token: 0x040020A5 RID: 8357
	LevelEventTriggerExit,
	// Token: 0x040020A6 RID: 8358
	OnLevelPlayStateChange,
	// Token: 0x040020A7 RID: 8359
	OnLevelPlayCompleteNumberChange,
	// Token: 0x040020A8 RID: 8360
	TodTimeChange,
	// Token: 0x040020A9 RID: 8361
	DayStateChange,
	// Token: 0x040020AA RID: 8362
	CrossDay,
	// Token: 0x040020AB RID: 8363
	CrossDayZone,
	// Token: 0x040020AC RID: 8364
	CrossHour,
	// Token: 0x040020AD RID: 8365
	ClickTimeItem,
	// Token: 0x040020AE RID: 8366
	OnSelectTimeItem,
	// Token: 0x040020AF RID: 8367
	AdjustTime,
	// Token: 0x040020B0 RID: 8368
	AdjustTimeInAnim,
	// Token: 0x040020B1 RID: 8369
	PowerShopReady,
	// Token: 0x040020B2 RID: 8370
	OnPowerChanged,
	// Token: 0x040020B3 RID: 8371
	OnPowerChangedWithId,
	// Token: 0x040020B4 RID: 8372
	OnHonamiStoryBackpackUpdate,
	// Token: 0x040020B5 RID: 8373
	OnHonamiStoryLifeSupportLevelUp,
	// Token: 0x040020B6 RID: 8374
	OnHonamiStoryLeaveButtonUpdate,
	// Token: 0x040020B7 RID: 8375
	OnHonamiStoryPowerLevelUpdate,
	// Token: 0x040020B8 RID: 8376
	OnHonamiStoryTechNodeLevelUpdate,
	// Token: 0x040020B9 RID: 8377
	OnHonamiStoryItemCollectGetReward,
	// Token: 0x040020BA RID: 8378
	OnHonamiStoryMascotRewardReceive,
	// Token: 0x040020BB RID: 8379
	OnHonamiStoryAreaSecretRewardReceive,
	// Token: 0x040020BC RID: 8380
	OnHonamiStoryInstInfoUpdate,
	// Token: 0x040020BD RID: 8381
	OnHonamiStoryPollutionUpdate,
	// Token: 0x040020BE RID: 8382
	OnHonamiScanMarkInfoUpdate,
	// Token: 0x040020BF RID: 8383
	OnHonamiStoryPickUpAutoEquip,
	// Token: 0x040020C0 RID: 8384
	OnHonamiStorySortSuccess,
	// Token: 0x040020C1 RID: 8385
	OnHonamiStorySkillDescModeChange,
	// Token: 0x040020C2 RID: 8386
	OnHonamiStoryBackpackClickWeapon,
	// Token: 0x040020C3 RID: 8387
	OnHonamiStorySetVisible,
	// Token: 0x040020C4 RID: 8388
	OnGamePlayCdChanged,
	// Token: 0x040020C5 RID: 8389
	InsertFloatTips,
	// Token: 0x040020C6 RID: 8390
	RemoveFloatTips,
	// Token: 0x040020C7 RID: 8391
	OriginWorldLevelUp,
	// Token: 0x040020C8 RID: 8392
	CurWorldLevelChange,
	// Token: 0x040020C9 RID: 8393
	WorldLevelUpViewRefresh,
	// Token: 0x040020CA RID: 8394
	OnShowMouseCursor,
	// Token: 0x040020CB RID: 8395
	RefreshCursor,
	// Token: 0x040020CC RID: 8396
	MoveCursorToRightDown,
	// Token: 0x040020CD RID: 8397
	InputDistribute,
	// Token: 0x040020CE RID: 8398
	OnRefreshJoinTeamRole,
	// Token: 0x040020CF RID: 8399
	LoadLguiEventSystemActor,
	// Token: 0x040020D0 RID: 8400
	InitializeLguiEventSystemActor,
	// Token: 0x040020D1 RID: 8401
	DestroyLguiEventSystemActor,
	// Token: 0x040020D2 RID: 8402
	OnUseBuffItem,
	// Token: 0x040020D3 RID: 8403
	OnEquipBuffItemUpdate,
	// Token: 0x040020D4 RID: 8404
	UpdateQuestDetails,
	// Token: 0x040020D5 RID: 8405
	UpdateQuestListAndDetails,
	// Token: 0x040020D6 RID: 8406
	UpdateRoleQuestDetails,
	// Token: 0x040020D7 RID: 8407
	QuestUpdateInfoAdd,
	// Token: 0x040020D8 RID: 8408
	AddInteractOptionByAction,
	// Token: 0x040020D9 RID: 8409
	RemoveInteractOptionByAction,
	// Token: 0x040020DA RID: 8410
	OnQuestStateChange,
	// Token: 0x040020DB RID: 8411
	OnQuestFinishListNotify,
	// Token: 0x040020DC RID: 8412
	OnQuestRedDotStateChange,
	// Token: 0x040020DD RID: 8413
	OnQuestFinishProtocolEnd,
	// Token: 0x040020DE RID: 8414
	OnRoleQuestAccept,
	// Token: 0x040020DF RID: 8415
	OnRoleQuestPointChange,
	// Token: 0x040020E0 RID: 8416
	OnRoleQuestNewUnlock,
	// Token: 0x040020E1 RID: 8417
	OnAddNewQuest,
	// Token: 0x040020E2 RID: 8418
	OnNavigationQuest,
	// Token: 0x040020E3 RID: 8419
	ActivityQuestCountdownEnd,
	// Token: 0x040020E4 RID: 8420
	OnQuestStageNameChange,
	// Token: 0x040020E5 RID: 8421
	FocusQuestChange,
	// Token: 0x040020E6 RID: 8422
	LevelGamePlayPrepareCountDownEnd,
	// Token: 0x040020E7 RID: 8423
	GeneralLogicTreeWakeUp,
	// Token: 0x040020E8 RID: 8424
	OnLogicTreeNodeStatusChange,
	// Token: 0x040020E9 RID: 8425
	OnLogicTreeChildQuestNodeStatusChange,
	// Token: 0x040020EA RID: 8426
	AfterLogicTreeChildQuestNodeStatusChange,
	// Token: 0x040020EB RID: 8427
	OnLogicTreeNodeProgressChange,
	// Token: 0x040020EC RID: 8428
	GeneralLogicTreeTimerInfoChanged,
	// Token: 0x040020ED RID: 8429
	OnGeneralLogicTreeTimerUpdate,
	// Token: 0x040020EE RID: 8430
	OnLogicTreeTrackUpdate,
	// Token: 0x040020EF RID: 8431
	CurTrackQuestUnTrackedCheck,
	// Token: 0x040020F0 RID: 8432
	OnLogicTreeTimerTick,
	// Token: 0x040020F1 RID: 8433
	GeneralLogicTreeStartShowTrackText,
	// Token: 0x040020F2 RID: 8434
	GeneralLogicTreeUpdateShowTrackText,
	// Token: 0x040020F3 RID: 8435
	GeneralLogicTreeEndShowTrackText,
	// Token: 0x040020F4 RID: 8436
	TearDownGeneralLogicTree,
	// Token: 0x040020F5 RID: 8437
	GeneralLogicTreeSuspend,
	// Token: 0x040020F6 RID: 8438
	GeneralLogicTreeCancelSuspend,
	// Token: 0x040020F7 RID: 8439
	GeneralLogicTreePrepareRollback,
	// Token: 0x040020F8 RID: 8440
	GeneralLogicTreePrepareRollbackFinish,
	// Token: 0x040020F9 RID: 8441
	GeneralLogicTreeRemovePrepareRollbackNode,
	// Token: 0x040020FA RID: 8442
	GeneralLogicTreeRollbackWaitingUpdate,
	// Token: 0x040020FB RID: 8443
	GeneralLogicTreeEntityInteractFinished,
	// Token: 0x040020FC RID: 8444
	GeneralLogicTreeEntityKilled,
	// Token: 0x040020FD RID: 8445
	GeneralLogicTreeAddTag,
	// Token: 0x040020FE RID: 8446
	GeneralLogicTreeRemoveTag,
	// Token: 0x040020FF RID: 8447
	GeneralLogicTreeViewForceRefresh,
	// Token: 0x04002100 RID: 8448
	GeneralLogicTreeApplyExpressionOccupation,
	// Token: 0x04002101 RID: 8449
	GeneralLogicTreeReleaseExpressionOccupation,
	// Token: 0x04002102 RID: 8450
	GeneralLogicTreeOccupationInfoChanged,
	// Token: 0x04002103 RID: 8451
	QuestUpdateTipsClickTrack,
	// Token: 0x04002104 RID: 8452
	QuestUpdateTipsEndSequenceStart,
	// Token: 0x04002105 RID: 8453
	MissionTrackRuleChange,
	// Token: 0x04002106 RID: 8454
	MissionPanelOut,
	// Token: 0x04002107 RID: 8455
	MissionUpdate,
	// Token: 0x04002108 RID: 8456
	MissionPanelStepTitleAnimStart,
	// Token: 0x04002109 RID: 8457
	MissionPanelStepTitleAnimEnd,
	// Token: 0x0400210A RID: 8458
	MissionPanelStepConditionIndexChange,
	// Token: 0x0400210B RID: 8459
	FailRangeTimerStartShow,
	// Token: 0x0400210C RID: 8460
	FailRangeTimerEndShow,
	// Token: 0x0400210D RID: 8461
	OnCreateBehaviorTree,
	// Token: 0x0400210E RID: 8462
	OnGeneralLogicTreeRemove,
	// Token: 0x0400210F RID: 8463
	ParkourFinished,
	// Token: 0x04002110 RID: 8464
	HudInited,
	// Token: 0x04002111 RID: 8465
	OnOpenDebugCommand,
	// Token: 0x04002112 RID: 8466
	OnResetToBattleView,
	// Token: 0x04002113 RID: 8467
	ResetModuleByResetToBattleView,
	// Token: 0x04002114 RID: 8468
	ResetModuleAfterResetToBattleView,
	// Token: 0x04002115 RID: 8469
	ExitNormalQueueState,
	// Token: 0x04002116 RID: 8470
	OnStartLoadingState,
	// Token: 0x04002117 RID: 8471
	OnFinishLoadingState,
	// Token: 0x04002118 RID: 8472
	OnOpenLoadingView,
	// Token: 0x04002119 RID: 8473
	OnCloseLoadingView,
	// Token: 0x0400211A RID: 8474
	OnLoadingNetDataDone,
	// Token: 0x0400211B RID: 8475
	PlayUiComponentCloseTween,
	// Token: 0x0400211C RID: 8476
	ChangeUiComponentMarkId,
	// Token: 0x0400211D RID: 8477
	OnMenuDataEnableChanged,
	// Token: 0x0400211E RID: 8478
	OnSelectMenuMainType,
	// Token: 0x0400211F RID: 8479
	ChangeConfigValue,
	// Token: 0x04002120 RID: 8480
	RestartFlag,
	// Token: 0x04002121 RID: 8481
	SettingFrameRateChanged,
	// Token: 0x04002122 RID: 8482
	TextLanguageChange,
	// Token: 0x04002123 RID: 8483
	UiPureModeChangedForSettingSystem,
	// Token: 0x04002124 RID: 8484
	ConfigLoadChange,
	// Token: 0x04002125 RID: 8485
	AutoMovingSettingChanged,
	// Token: 0x04002126 RID: 8486
	AutoSprintSettingChanged,
	// Token: 0x04002127 RID: 8487
	MotorcycleWaterAreaChange,
	// Token: 0x04002128 RID: 8488
	MotorcycleWaterDetectedStart2,
	// Token: 0x04002129 RID: 8489
	MotorcycleWaterDetectedEnd2,
	// Token: 0x0400212A RID: 8490
	MotorcycleWaterDetectedTick2,
	// Token: 0x0400212B RID: 8491
	MotorcycleBaseMovementChanged,
	// Token: 0x0400212C RID: 8492
	MotorcycleAutoAcceleratorSettingChanged,
	// Token: 0x0400212D RID: 8493
	MotorcycleAutoNitrogenSettingChanged,
	// Token: 0x0400212E RID: 8494
	MotorcycleDriftAcceleratorSettingChanged,
	// Token: 0x0400212F RID: 8495
	SneakResult,
	// Token: 0x04002130 RID: 8496
	SneakMonsterStart,
	// Token: 0x04002131 RID: 8497
	SneakMonsterStop,
	// Token: 0x04002132 RID: 8498
	ChannelReset,
	// Token: 0x04002133 RID: 8499
	OnShareResult,
	// Token: 0x04002134 RID: 8500
	OnFirstShare,
	// Token: 0x04002135 RID: 8501
	ShowVideo,
	// Token: 0x04002136 RID: 8502
	VideoStart,
	// Token: 0x04002137 RID: 8503
	PlayVideo,
	// Token: 0x04002138 RID: 8504
	VideoTriggerBlendOut,
	// Token: 0x04002139 RID: 8505
	VideoViewShow,
	// Token: 0x0400213A RID: 8506
	VideoViewHide,
	// Token: 0x0400213B RID: 8507
	ScanTrackedStart,
	// Token: 0x0400213C RID: 8508
	ScanTrackedEnd,
	// Token: 0x0400213D RID: 8509
	OnScanStart,
	// Token: 0x0400213E RID: 8510
	RedDotStart,
	// Token: 0x0400213F RID: 8511
	RedDotRefreshItemData,
	// Token: 0x04002140 RID: 8512
	RedDotRoleConfigList,
	// Token: 0x04002141 RID: 8513
	RedDotRefreshPhantomEquip,
	// Token: 0x04002142 RID: 8514
	RedDotRoleChange,
	// Token: 0x04002143 RID: 8515
	RedDotUnLockPhantom,
	// Token: 0x04002144 RID: 8516
	RedDotNewTutorial,
	// Token: 0x04002145 RID: 8517
	RedDotNewTutorialType,
	// Token: 0x04002146 RID: 8518
	RedDotAdventureManualUpdate,
	// Token: 0x04002147 RID: 8519
	RedDotSilentFirstAward,
	// Token: 0x04002148 RID: 8520
	RedDotSilentFirstAwardCategory,
	// Token: 0x04002149 RID: 8521
	RedDotSilentFirstAwardResult,
	// Token: 0x0400214A RID: 8522
	RedDotCreateRole,
	// Token: 0x0400214B RID: 8523
	RouletteRefreshNew,
	// Token: 0x0400214C RID: 8524
	RedDotFilter,
	// Token: 0x0400214D RID: 8525
	RedDotPhotoSetup,
	// Token: 0x0400214E RID: 8526
	OnServerStorageInfoInited,
	// Token: 0x0400214F RID: 8527
	SilentTipsRefresh,
	// Token: 0x04002150 RID: 8528
	OnRefreshElementBallData,
	// Token: 0x04002151 RID: 8529
	ShootTargetStateChanged,
	// Token: 0x04002152 RID: 8530
	InteractNavigation,
	// Token: 0x04002153 RID: 8531
	InteractionViewUpdate,
	// Token: 0x04002154 RID: 8532
	HideInteractView,
	// Token: 0x04002155 RID: 8533
	OnInteractViewVisibleChanged,
	// Token: 0x04002156 RID: 8534
	SceneItemInteractionEvent,
	// Token: 0x04002157 RID: 8535
	OnFunctionOpenSet,
	// Token: 0x04002158 RID: 8536
	OnFunctionOpenUpdate,
	// Token: 0x04002159 RID: 8537
	OnFunctionOpenUpdateNotify,
	// Token: 0x0400215A RID: 8538
	OnConcertoResponseOpen,
	// Token: 0x0400215B RID: 8539
	OnFirstOpenShopChanged,
	// Token: 0x0400215C RID: 8540
	OnSetHeadStateVisible,
	// Token: 0x0400215D RID: 8541
	OnSetBossStateVisible,
	// Token: 0x0400215E RID: 8542
	SdkKick,
	// Token: 0x0400215F RID: 8543
	SdkPostWebViewRedPointRefresh,
	// Token: 0x04002160 RID: 8544
	SdkCustomerRedPointRefresh,
	// Token: 0x04002161 RID: 8545
	SdkIntroductionRedPointRefresh,
	// Token: 0x04002162 RID: 8546
	UpdateFriendViewShow,
	// Token: 0x04002163 RID: 8547
	UpdateRecentlyTeamDataEvent,
	// Token: 0x04002164 RID: 8548
	OnRemoveFriend,
	// Token: 0x04002165 RID: 8549
	FriendApplicationListUpdate,
	// Token: 0x04002166 RID: 8550
	UpdateBlackListShow,
	// Token: 0x04002167 RID: 8551
	SearchPlayerInfo,
	// Token: 0x04002168 RID: 8552
	FriendRemarkLengthLimit,
	// Token: 0x04002169 RID: 8553
	FriendRemarkContainsDirtyWord,
	// Token: 0x0400216A RID: 8554
	RefreshFriendApplicationRedDot,
	// Token: 0x0400216B RID: 8555
	FriendApplyReceived,
	// Token: 0x0400216C RID: 8556
	FriendAdded,
	// Token: 0x0400216D RID: 8557
	LoadTestFriendsByGm,
	// Token: 0x0400216E RID: 8558
	ApplicationHandled,
	// Token: 0x0400216F RID: 8559
	ApplicationSent,
	// Token: 0x04002170 RID: 8560
	OnGetFriendInitData,
	// Token: 0x04002171 RID: 8561
	FriendOnMultiItemAction,
	// Token: 0x04002172 RID: 8562
	UpdateNavigationListener,
	// Token: 0x04002173 RID: 8563
	OnVisionAssembleNavigationRefresh,
	// Token: 0x04002174 RID: 8564
	InputControllerChange,
	// Token: 0x04002175 RID: 8565
	InputControllerMainTypeChange,
	// Token: 0x04002176 RID: 8566
	ShowTypeChange,
	// Token: 0x04002177 RID: 8567
	PointerInputTypeChange,
	// Token: 0x04002178 RID: 8568
	ControllerConnectChange,
	// Token: 0x04002179 RID: 8569
	ChangeScrollBarPosition,
	// Token: 0x0400217A RID: 8570
	RefreshGuest,
	// Token: 0x0400217B RID: 8571
	ShowGuestEffect,
	// Token: 0x0400217C RID: 8572
	OnSelectChatFriend,
	// Token: 0x0400217D RID: 8573
	OnCreatePrivateChatRoom,
	// Token: 0x0400217E RID: 8574
	OnJoinChatRoom,
	// Token: 0x0400217F RID: 8575
	OnAddChatContent,
	// Token: 0x04002180 RID: 8576
	OnRefreshChatRedDot,
	// Token: 0x04002181 RID: 8577
	OnRefreshChatRoomRedDot,
	// Token: 0x04002182 RID: 8578
	OnAddHistoryChatContentCompleted,
	// Token: 0x04002183 RID: 8579
	OnPushChatRowData,
	// Token: 0x04002184 RID: 8580
	OnPopChatRowData,
	// Token: 0x04002185 RID: 8581
	OnRefreshChatRowData,
	// Token: 0x04002186 RID: 8582
	OnAddMutePlayer,
	// Token: 0x04002187 RID: 8583
	OnRemoveMutePlayer,
	// Token: 0x04002188 RID: 8584
	OnRemovePrivateChatRoom,
	// Token: 0x04002189 RID: 8585
	OnClosePrivateChatRoom,
	// Token: 0x0400218A RID: 8586
	OnOpenChatRoom,
	// Token: 0x0400218B RID: 8587
	OnSelectExpression,
	// Token: 0x0400218C RID: 8588
	OnServerAttributeChange,
	// Token: 0x0400218D RID: 8589
	OnPayItemSuccess,
	// Token: 0x0400218E RID: 8590
	RefreshPayItemList,
	// Token: 0x0400218F RID: 8591
	RefreshPayGiftList,
	// Token: 0x04002190 RID: 8592
	OnPlayerCurrencyChange,
	// Token: 0x04002191 RID: 8593
	OnRefreshPermissionsSetting,
	// Token: 0x04002192 RID: 8594
	OnRefreshApply,
	// Token: 0x04002193 RID: 8595
	OnSearchWorld,
	// Token: 0x04002194 RID: 8596
	OnRefreshWorldList,
	// Token: 0x04002195 RID: 8597
	OnRefreshOnlineTeamList,
	// Token: 0x04002196 RID: 8598
	OnWorldTeamPlayerInfoChanged,
	// Token: 0x04002197 RID: 8599
	OnRefreshPlayerPing,
	// Token: 0x04002198 RID: 8600
	OnRefreshPlayerUiState,
	// Token: 0x04002199 RID: 8601
	OnRefreshOnlineChallengePlayer,
	// Token: 0x0400219A RID: 8602
	OnRefreshSuggestChallengePlayerInfo,
	// Token: 0x0400219B RID: 8603
	SwitchPayShopTabItem,
	// Token: 0x0400219C RID: 8604
	PayShopGoodsBuy,
	// Token: 0x0400219D RID: 8605
	GoodsRefreshDiscountTime,
	// Token: 0x0400219E RID: 8606
	SwitchPayShopView,
	// Token: 0x0400219F RID: 8607
	RefreshPayShop,
	// Token: 0x040021A0 RID: 8608
	RefreshAllPayShop,
	// Token: 0x040021A1 RID: 8609
	RefreshGoods,
	// Token: 0x040021A2 RID: 8610
	RefreshShopAccumulateCurrency,
	// Token: 0x040021A3 RID: 8611
	ShopVersionCodeChange,
	// Token: 0x040021A4 RID: 8612
	GoodsSoldOut,
	// Token: 0x040021A5 RID: 8613
	RefreshGoodsList,
	// Token: 0x040021A6 RID: 8614
	UnLockGoods,
	// Token: 0x040021A7 RID: 8615
	RefreshPayShopEntranceRedDot,
	// Token: 0x040021A8 RID: 8616
	RefreshPayShopInstanceRedDot,
	// Token: 0x040021A9 RID: 8617
	RefreshPayShopTabRedDot,
	// Token: 0x040021AA RID: 8618
	DiscountShopTimerRefresh,
	// Token: 0x040021AB RID: 8619
	TryRefreshRootShopMoney,
	// Token: 0x040021AC RID: 8620
	OnOpenGachaChanged,
	// Token: 0x040021AD RID: 8621
	OnOpenCommonWeaponSelect,
	// Token: 0x040021AE RID: 8622
	RefreshGachaMainView,
	// Token: 0x040021AF RID: 8623
	GachaPoolSelectResponse,
	// Token: 0x040021B0 RID: 8624
	GachaResponse,
	// Token: 0x040021B1 RID: 8625
	GachaHistoryResponse,
	// Token: 0x040021B2 RID: 8626
	CloseGachaSceneView,
	// Token: 0x040021B3 RID: 8627
	GachaNewNotify,
	// Token: 0x040021B4 RID: 8628
	EndGachaScene,
	// Token: 0x040021B5 RID: 8629
	GachaClick,
	// Token: 0x040021B6 RID: 8630
	GachaSelectionViewRefresh,
	// Token: 0x040021B7 RID: 8631
	AfterCloseGachaScene,
	// Token: 0x040021B8 RID: 8632
	PlaySequenceEventByStringParam,
	// Token: 0x040021B9 RID: 8633
	GachaInteractFinish,
	// Token: 0x040021BA RID: 8634
	ItemExChangeResponse,
	// Token: 0x040021BB RID: 8635
	GachaAccumulateDataUpdate,
	// Token: 0x040021BC RID: 8636
	GachaAccumulateRewardClaimed,
	// Token: 0x040021BD RID: 8637
	GachaAccumulateRedDot,
	// Token: 0x040021BE RID: 8638
	ItemHintVisibilityChange,
	// Token: 0x040021BF RID: 8639
	ShowAnimalsHeadInfo,
	// Token: 0x040021C0 RID: 8640
	OnAnimalDying,
	// Token: 0x040021C1 RID: 8641
	OnSkillButtonDataRefresh,
	// Token: 0x040021C2 RID: 8642
	OnSkillButtonDataClear,
	// Token: 0x040021C3 RID: 8643
	OnSkillButtonIndexRefresh,
	// Token: 0x040021C4 RID: 8644
	OnSkillButtonEnableRefresh,
	// Token: 0x040021C5 RID: 8645
	OnSkillButtonVisibleRefresh,
	// Token: 0x040021C6 RID: 8646
	OnSkillButtonSkillIdRefresh,
	// Token: 0x040021C7 RID: 8647
	OnSkillButtonDynamicEffectRefresh,
	// Token: 0x040021C8 RID: 8648
	OnSkillButtonCustomRefresh,
	// Token: 0x040021C9 RID: 8649
	OnSkillButtonCdRefresh,
	// Token: 0x040021CA RID: 8650
	OnSkillButtonAttributeRefresh,
	// Token: 0x040021CB RID: 8651
	OnSkillButtonIconPathRefresh,
	// Token: 0x040021CC RID: 8652
	OnSkillButtonLongPressRefresh,
	// Token: 0x040021CD RID: 8653
	OnSkillButtonExtraEffectRefresh,
	// Token: 0x040021CE RID: 8654
	OnSkillButtonSlideControlRefresh,
	// Token: 0x040021CF RID: 8655
	OnBehaviorButtonEnableRefresh,
	// Token: 0x040021D0 RID: 8656
	OnBehaviorButtonVisibleRefresh,
	// Token: 0x040021D1 RID: 8657
	OnBehaviorButtonSkillIdRefresh,
	// Token: 0x040021D2 RID: 8658
	OnBehaviorButtonIconPathRefresh,
	// Token: 0x040021D3 RID: 8659
	OnBehaviorButtonDynamicEffectRefresh,
	// Token: 0x040021D4 RID: 8660
	OnAttributeLockUpperBoundChange,
	// Token: 0x040021D5 RID: 8661
	OnMotorPadSkillButtonIndexRefresh,
	// Token: 0x040021D6 RID: 8662
	OnInputChangeForCond,
	// Token: 0x040021D7 RID: 8663
	OnInputMoveChanged,
	// Token: 0x040021D8 RID: 8664
	OnFloatingMoveInputChanged,
	// Token: 0x040021D9 RID: 8665
	OnGetNewItem,
	// Token: 0x040021DA RID: 8666
	OnElementFusion,
	// Token: 0x040021DB RID: 8667
	OnChangeSelectedExploreId,
	// Token: 0x040021DC RID: 8668
	OnRouletteViewVisibleChanged,
	// Token: 0x040021DD RID: 8669
	OnRouletteItemSelect,
	// Token: 0x040021DE RID: 8670
	OnRouletteItemUnlock,
	// Token: 0x040021DF RID: 8671
	OnRouletteSaveDataChange,
	// Token: 0x040021E0 RID: 8672
	OpenRouletteSetView,
	// Token: 0x040021E1 RID: 8673
	RouletteSwitchToggleComponentEmit,
	// Token: 0x040021E2 RID: 8674
	RouletteNavigationComponentEmit,
	// Token: 0x040021E3 RID: 8675
	OnAggroAdd,
	// Token: 0x040021E4 RID: 8676
	OnAggroRemoved,
	// Token: 0x040021E5 RID: 8677
	OnBossFight,
	// Token: 0x040021E6 RID: 8678
	OnEntityFightByBpType,
	// Token: 0x040021E7 RID: 8679
	OnSkillTagChanged,
	// Token: 0x040021E8 RID: 8680
	OnMatchingChange,
	// Token: 0x040021E9 RID: 8681
	OnMatchingBegin,
	// Token: 0x040021EA RID: 8682
	OnEnterTeam,
	// Token: 0x040021EB RID: 8683
	OnLeaveTeam,
	// Token: 0x040021EC RID: 8684
	OnEnterOnlineWorld,
	// Token: 0x040021ED RID: 8685
	OnLeaveOnlineWorld,
	// Token: 0x040021EE RID: 8686
	OnlineDisableStateChange,
	// Token: 0x040021EF RID: 8687
	PlayerChallengeStateChange,
	// Token: 0x040021F0 RID: 8688
	OnTriggerVolumeExit,
	// Token: 0x040021F1 RID: 8689
	OnSeasonAreaEffectBegin,
	// Token: 0x040021F2 RID: 8690
	OnSeasonAreaEffectEnd,
	// Token: 0x040021F3 RID: 8691
	RefreshAcquireView,
	// Token: 0x040021F4 RID: 8692
	OnResonanceMaterialChange,
	// Token: 0x040021F5 RID: 8693
	OnAddMaterialController,
	// Token: 0x040021F6 RID: 8694
	OnRemoveMaterialController,
	// Token: 0x040021F7 RID: 8695
	OnAddMaterialControllerGroup,
	// Token: 0x040021F8 RID: 8696
	OnRemoveMaterialControllerGroup,
	// Token: 0x040021F9 RID: 8697
	WeatherChange,
	// Token: 0x040021FA RID: 8698
	OnManipulateSwitchToNewTarget,
	// Token: 0x040021FB RID: 8699
	OnManipulateStartChanting,
	// Token: 0x040021FC RID: 8700
	OnManipulateCancelChanting,
	// Token: 0x040021FD RID: 8701
	OnManipulateCompleteChanting,
	// Token: 0x040021FE RID: 8702
	HiddenManipulateUI,
	// Token: 0x040021FF RID: 8703
	ManipulateStartLockCastTarget,
	// Token: 0x04002200 RID: 8704
	ManipulateEndLockCastTarget,
	// Token: 0x04002201 RID: 8705
	OnManipulatableSceneItemPosInFoundation,
	// Token: 0x04002202 RID: 8706
	AddSubCameraTag,
	// Token: 0x04002203 RID: 8707
	RemoveSubCameraTag,
	// Token: 0x04002204 RID: 8708
	AddExtraHoldingTags,
	// Token: 0x04002205 RID: 8709
	RemoveExtraHoldingTags,
	// Token: 0x04002206 RID: 8710
	HideJigsawBaseHint,
	// Token: 0x04002207 RID: 8711
	OnModifyJigsawItemPutIndex,
	// Token: 0x04002208 RID: 8712
	OnManipulatableItemStateModified,
	// Token: 0x04002209 RID: 8713
	OnManipulatedItemPosReset,
	// Token: 0x0400220A RID: 8714
	SetCameraAimVisible,
	// Token: 0x0400220B RID: 8715
	SetFollowShootAimVisible,
	// Token: 0x0400220C RID: 8716
	SetFollowShootAutoAimVisible,
	// Token: 0x0400220D RID: 8717
	SetTDFollowShootAimVisible,
	// Token: 0x0400220E RID: 8718
	ClickDisplayItem,
	// Token: 0x0400220F RID: 8719
	OnSelectItemAdd,
	// Token: 0x04002210 RID: 8720
	DetectSuccess,
	// Token: 0x04002211 RID: 8721
	AdventureTaskStateChange,
	// Token: 0x04002212 RID: 8722
	ChapterRewardReceived,
	// Token: 0x04002213 RID: 8723
	SilentRewardReceived,
	// Token: 0x04002214 RID: 8724
	AdventureHelpBtn,
	// Token: 0x04002215 RID: 8725
	NewSoundAreaRefreshReward,
	// Token: 0x04002216 RID: 8726
	RedDotNewSoundAreaTabUpdate,
	// Token: 0x04002217 RID: 8727
	RedDotAdventureChallengeTabUpdate,
	// Token: 0x04002218 RID: 8728
	RedDotAdventureSecondaryUpdate,
	// Token: 0x04002219 RID: 8729
	RedDotAdventurePeriodicityTabUpdate,
	// Token: 0x0400221A RID: 8730
	DailyActivityTaskUpdate,
	// Token: 0x0400221B RID: 8731
	DailyActivityRefresh,
	// Token: 0x0400221C RID: 8732
	DailyActivityValueChange,
	// Token: 0x0400221D RID: 8733
	DailyActivityRewardTake,
	// Token: 0x0400221E RID: 8734
	RefreshActivityRewardPopUp,
	// Token: 0x0400221F RID: 8735
	DailyActivityCountDownUpdate,
	// Token: 0x04002220 RID: 8736
	DailyUpdateNotify,
	// Token: 0x04002221 RID: 8737
	DailyActivityStateNotify,
	// Token: 0x04002222 RID: 8738
	DailyActivityMainTabOpened,
	// Token: 0x04002223 RID: 8739
	DailyTaskAreaItemClick,
	// Token: 0x04002224 RID: 8740
	DailyTaskInfluenceItemClick,
	// Token: 0x04002225 RID: 8741
	DailyTaskUnlockAreaChange,
	// Token: 0x04002226 RID: 8742
	DailyTaskStateChange,
	// Token: 0x04002227 RID: 8743
	DailyTaskChange,
	// Token: 0x04002228 RID: 8744
	DailyTaskTendencyChange,
	// Token: 0x04002229 RID: 8745
	OnAddCommonItem,
	// Token: 0x0400222A RID: 8746
	OnAddCommonItemList,
	// Token: 0x0400222B RID: 8747
	OnAddCommonItemNotify,
	// Token: 0x0400222C RID: 8748
	OnResponseCommonItem,
	// Token: 0x0400222D RID: 8749
	OnResponseCommonItemFinished,
	// Token: 0x0400222E RID: 8750
	OnRemoveCommonItem,
	// Token: 0x0400222F RID: 8751
	OnCommonItemCountRefresh,
	// Token: 0x04002230 RID: 8752
	OnCommonItemCountAnyChange,
	// Token: 0x04002231 RID: 8753
	OnAddWeaponItem,
	// Token: 0x04002232 RID: 8754
	OnAddWeaponItemList,
	// Token: 0x04002233 RID: 8755
	OnResponseWeaponItem,
	// Token: 0x04002234 RID: 8756
	OnResponseWeaponAll,
	// Token: 0x04002235 RID: 8757
	OnRemoveWeaponItem,
	// Token: 0x04002236 RID: 8758
	OnWeaponFunctionValueRefresh,
	// Token: 0x04002237 RID: 8759
	OnAddPhantomItem,
	// Token: 0x04002238 RID: 8760
	OnAddPhantomItemList,
	// Token: 0x04002239 RID: 8761
	OnResponsePhantomItem,
	// Token: 0x0400223A RID: 8762
	OnEquipPhantomItem,
	// Token: 0x0400223B RID: 8763
	OnRemovePhantomItem,
	// Token: 0x0400223C RID: 8764
	OnPhantomFunctionValueRefresh,
	// Token: 0x0400223D RID: 8765
	OnAddFavorItem,
	// Token: 0x0400223E RID: 8766
	OnAddOrnamentItemList,
	// Token: 0x0400223F RID: 8767
	NotifyInvalidItem,
	// Token: 0x04002240 RID: 8768
	NotifyExpireConvertItem,
	// Token: 0x04002241 RID: 8769
	EnterLogicRange,
	// Token: 0x04002242 RID: 8770
	LeaveLogicRange,
	// Token: 0x04002243 RID: 8771
	PlayerSenseTargetEnter,
	// Token: 0x04002244 RID: 8772
	PlayerSenseTargetLeave,
	// Token: 0x04002245 RID: 8773
	OnAiSenseEntityEnter,
	// Token: 0x04002246 RID: 8774
	OnAiSenseEntityLeave,
	// Token: 0x04002247 RID: 8775
	OnInteractStateChange,
	// Token: 0x04002248 RID: 8776
	OnGuideRangeEnter,
	// Token: 0x04002249 RID: 8777
	SwitchCookType,
	// Token: 0x0400224A RID: 8778
	UpdateFormula,
	// Token: 0x0400224B RID: 8779
	UpdateCookerInfo,
	// Token: 0x0400224C RID: 8780
	UpgradeCookerLevel,
	// Token: 0x0400224D RID: 8781
	GetCookData,
	// Token: 0x0400224E RID: 8782
	OpenProcessedStudy,
	// Token: 0x0400224F RID: 8783
	CloseProcessedStudy,
	// Token: 0x04002250 RID: 8784
	OpenCook,
	// Token: 0x04002251 RID: 8785
	OpenCookLevel,
	// Token: 0x04002252 RID: 8786
	OpenCookRole,
	// Token: 0x04002253 RID: 8787
	CloseCookRole,
	// Token: 0x04002254 RID: 8788
	CookSuccess,
	// Token: 0x04002255 RID: 8789
	CookFail,
	// Token: 0x04002256 RID: 8790
	MachiningSuccess,
	// Token: 0x04002257 RID: 8791
	MachiningStudyFail,
	// Token: 0x04002258 RID: 8792
	FixSuccess,
	// Token: 0x04002259 RID: 8793
	OpenSelected,
	// Token: 0x0400225A RID: 8794
	CloseSelected,
	// Token: 0x0400225B RID: 8795
	OnAddCommonEffect,
	// Token: 0x0400225C RID: 8796
	RefreshRewardPopUp,
	// Token: 0x0400225D RID: 8797
	ReceiveMonthCardDataEvent,
	// Token: 0x0400225E RID: 8798
	ReceiveWeekCardDataEvent,
	// Token: 0x0400225F RID: 8799
	OnClickSingleTimeTowerStageBtn,
	// Token: 0x04002260 RID: 8800
	OnClickSingleTimeTowerTeamBtn,
	// Token: 0x04002261 RID: 8801
	OnClickSingleTimeTowerTeamRoleBtn,
	// Token: 0x04002262 RID: 8802
	OnClickSingleTimeTowerStageDetailBtn,
	// Token: 0x04002263 RID: 8803
	OnClickSingleTimeTowerMonsterBtn,
	// Token: 0x04002264 RID: 8804
	OnClickSingleTimeTowerDetailSwitchBtn,
	// Token: 0x04002265 RID: 8805
	OnInstResultNotify,
	// Token: 0x04002266 RID: 8806
	OnTowerChallengeChangeTeamNotify,
	// Token: 0x04002267 RID: 8807
	OnTowerRewardReceived,
	// Token: 0x04002268 RID: 8808
	RedDotTowerReward,
	// Token: 0x04002269 RID: 8809
	RedDotTowerRewardByDifficulties,
	// Token: 0x0400226A RID: 8810
	OnTowerRefresh,
	// Token: 0x0400226B RID: 8811
	OnTowerRecordUpdate,
	// Token: 0x0400226C RID: 8812
	OnShowTowerGuideButton,
	// Token: 0x0400226D RID: 8813
	OnTowerReviewGoToReward,
	// Token: 0x0400226E RID: 8814
	OnClickCycleTowerAreaBtn,
	// Token: 0x0400226F RID: 8815
	OnResetCycleTowerArea,
	// Token: 0x04002270 RID: 8816
	OnClickCycleTowerRoleBtn,
	// Token: 0x04002271 RID: 8817
	OnClickCycleTowerDetailSwitchBtn,
	// Token: 0x04002272 RID: 8818
	OnCycleTowerUpdateSeason,
	// Token: 0x04002273 RID: 8819
	OnCycleTowerUpdateSeasonNotify,
	// Token: 0x04002274 RID: 8820
	OnCycleTowerScoreChange,
	// Token: 0x04002275 RID: 8821
	OnTowerGuideClose,
	// Token: 0x04002276 RID: 8822
	OnTowerRefreshStars,
	// Token: 0x04002277 RID: 8823
	OnReceiveAdviceData,
	// Token: 0x04002278 RID: 8824
	OnCreateAdviceSuccess,
	// Token: 0x04002279 RID: 8825
	OnModifyAdviceSuccess,
	// Token: 0x0400227A RID: 8826
	OnDeleteAdviceSuccess,
	// Token: 0x0400227B RID: 8827
	OnClickAdviceExpression,
	// Token: 0x0400227C RID: 8828
	OnClickAdviceWord,
	// Token: 0x0400227D RID: 8829
	OnChangeAdviceWord,
	// Token: 0x0400227E RID: 8830
	OnClickAdviceSort,
	// Token: 0x0400227F RID: 8831
	OnClickAdviceSortWord,
	// Token: 0x04002280 RID: 8832
	OnClickAdviceMotion,
	// Token: 0x04002281 RID: 8833
	OnChangeAdviceRole,
	// Token: 0x04002282 RID: 8834
	OnClickAdviceSelectItem,
	// Token: 0x04002283 RID: 8835
	OnSelectAdviceWord,
	// Token: 0x04002284 RID: 8836
	OnSelectAdviceExpression,
	// Token: 0x04002285 RID: 8837
	OnAdviceEntityNotify,
	// Token: 0x04002286 RID: 8838
	OnAdviceVoteNotify,
	// Token: 0x04002287 RID: 8839
	RefreshAdviceInfoView,
	// Token: 0x04002288 RID: 8840
	SneakStart,
	// Token: 0x04002289 RID: 8841
	SneakEnd,
	// Token: 0x0400228A RID: 8842
	AddAlterMark,
	// Token: 0x0400228B RID: 8843
	RemoveAlterMark,
	// Token: 0x0400228C RID: 8844
	OnSneakFoundChange,
	// Token: 0x0400228D RID: 8845
	OnChildQuestNodeFinish,
	// Token: 0x0400228E RID: 8846
	AddStalkAlertMark,
	// Token: 0x0400228F RID: 8847
	RemoveStalkAlertMark,
	// Token: 0x04002290 RID: 8848
	OnStalkAlert,
	// Token: 0x04002291 RID: 8849
	OnStalkAlertLifted,
	// Token: 0x04002292 RID: 8850
	OnStalkFound,
	// Token: 0x04002293 RID: 8851
	OnStalkFailed,
	// Token: 0x04002294 RID: 8852
	AddEavesdropMark,
	// Token: 0x04002295 RID: 8853
	RemoveEavesdropMark,
	// Token: 0x04002296 RID: 8854
	OnEavesdropFound,
	// Token: 0x04002297 RID: 8855
	OnAddFullScreenEffect,
	// Token: 0x04002298 RID: 8856
	OnRemoveFullScreenEffect,
	// Token: 0x04002299 RID: 8857
	OnClearFullScreenEffect,
	// Token: 0x0400229A RID: 8858
	OnChangeFullScreenNiagaraFloatParameter,
	// Token: 0x0400229B RID: 8859
	OnSceneItemBuffConsumed,
	// Token: 0x0400229C RID: 8860
	OnSceneItemBuffRemoved,
	// Token: 0x0400229D RID: 8861
	OnSceneItemBuffTimeout,
	// Token: 0x0400229E RID: 8862
	OnSceneItemBuffTargetRemoved,
	// Token: 0x0400229F RID: 8863
	OnSceneItemBuffConsumerPerformanceComplete,
	// Token: 0x040022A0 RID: 8864
	OnExecuteServerGm,
	// Token: 0x040022A1 RID: 8865
	ActiveBattleView,
	// Token: 0x040022A2 RID: 8866
	DisActiveBattleView,
	// Token: 0x040022A3 RID: 8867
	DragActorPlayActivationChanged,
	// Token: 0x040022A4 RID: 8868
	DragActorPlayConditionRecheck,
	// Token: 0x040022A5 RID: 8869
	BattleUiCurRoleDataChanged,
	// Token: 0x040022A6 RID: 8870
	BattleUiCurRoleDataChangedNextTick,
	// Token: 0x040022A7 RID: 8871
	BattleUiEnergyBarVisible,
	// Token: 0x040022A8 RID: 8872
	BattleUiAllRoleDataChanged,
	// Token: 0x040022A9 RID: 8873
	BattleUiRemoveRoleData,
	// Token: 0x040022AA RID: 8874
	BattleUiElementEnergyChanged,
	// Token: 0x040022AB RID: 8875
	BattleUiEnergyChanged,
	// Token: 0x040022AC RID: 8876
	BattleUiElementHideTagChanged,
	// Token: 0x040022AD RID: 8877
	BattleUiConcertoExtraEffectRefresh,
	// Token: 0x040022AE RID: 8878
	BattleUiDeadTagChanged,
	// Token: 0x040022AF RID: 8879
	BattleUiQteEnableTagChanged,
	// Token: 0x040022B0 RID: 8880
	BattleUiQteCdTagChanged,
	// Token: 0x040022B1 RID: 8881
	BattleUiUseQteTagChanged,
	// Token: 0x040022B2 RID: 8882
	BattleUiConcertoEnableTagChanged,
	// Token: 0x040022B3 RID: 8883
	BattleUiPoisonChanged,
	// Token: 0x040022B4 RID: 8884
	BattleUiHealthChanged,
	// Token: 0x040022B5 RID: 8885
	BattleUiShieldChanged,
	// Token: 0x040022B6 RID: 8886
	BattleUiLevelChanged,
	// Token: 0x040022B7 RID: 8887
	BattleUiFloatTipUpdate,
	// Token: 0x040022B8 RID: 8888
	BattleUiPlayAudio,
	// Token: 0x040022B9 RID: 8889
	BattleUiExploreModeChanged,
	// Token: 0x040022BA RID: 8890
	BattleUiMergeHeadStateVisibleChanged,
	// Token: 0x040022BB RID: 8891
	BattleUiMergeHeadStateHealthChanged,
	// Token: 0x040022BC RID: 8892
	BattleUiTowerMergeHeadStateVisibleChanged,
	// Token: 0x040022BD RID: 8893
	BattleUiTowerMergeHeadStateMonsterHpChanged,
	// Token: 0x040022BE RID: 8894
	BattleUiEnvironmentKeyChanged,
	// Token: 0x040022BF RID: 8895
	BattleUiPressCombineButtonChanged,
	// Token: 0x040022C0 RID: 8896
	BattleUiPressMotorcycleCombineButtonChanged,
	// Token: 0x040022C1 RID: 8897
	BattleUiToggleSilentAreaInfoView,
	// Token: 0x040022C2 RID: 8898
	BattleInputEnableChanged,
	// Token: 0x040022C3 RID: 8899
	BattleInputVisibleChanged,
	// Token: 0x040022C4 RID: 8900
	BattleUiFollowerAimStateChanged,
	// Token: 0x040022C5 RID: 8901
	BattleUiChatScrollViewVisibleChanged,
	// Token: 0x040022C6 RID: 8902
	BattleUiRouletteKeyChanged,
	// Token: 0x040022C7 RID: 8903
	BattleUiSwitchInteractOpenChanged,
	// Token: 0x040022C8 RID: 8904
	BattleUiSwitchInteractStateChanged,
	// Token: 0x040022C9 RID: 8905
	BattleUiToggleTowerDefenseInfoView,
	// Token: 0x040022CA RID: 8906
	BattleUiAlphaChanged,
	// Token: 0x040022CB RID: 8907
	BattleUiPureModeChanged,
	// Token: 0x040022CC RID: 8908
	BattleUiSpecialSkillEnableChanged,
	// Token: 0x040022CD RID: 8909
	BattleUiRoleSpecialStateChanged,
	// Token: 0x040022CE RID: 8910
	BattleUiSlowTimeVisibleChanged,
	// Token: 0x040022CF RID: 8911
	BattleUiTimeDilationStateChanged,
	// Token: 0x040022D0 RID: 8912
	BattleUiShowWeaknessBreakEffect,
	// Token: 0x040022D1 RID: 8913
	BattleUiMotorcycleStateChanged,
	// Token: 0x040022D2 RID: 8914
	BattleUiMotorcycleBulletJumpChanged,
	// Token: 0x040022D3 RID: 8915
	BattleUiMotorcycleHudVisibleChanged,
	// Token: 0x040022D4 RID: 8916
	BattleUiMotorcycleHudColorStateChanged,
	// Token: 0x040022D5 RID: 8917
	BattleUiMotorcycleFlyTagChanged,
	// Token: 0x040022D6 RID: 8918
	BattleUiMotorcycleCannonTagChanged,
	// Token: 0x040022D7 RID: 8919
	AddStrengthItem,
	// Token: 0x040022D8 RID: 8920
	RemoveStrengthItem,
	// Token: 0x040022D9 RID: 8921
	BattleUiBossStateAreaChanged,
	// Token: 0x040022DA RID: 8922
	BattleUiGamepadDataChanged,
	// Token: 0x040022DB RID: 8923
	BattleUiSlideControlVisibleChanged,
	// Token: 0x040022DC RID: 8924
	OnSkillButtonPanelVisibleChange,
	// Token: 0x040022DD RID: 8925
	BattleSettlementStateChanged,
	// Token: 0x040022DE RID: 8926
	BattleScoreChanged,
	// Token: 0x040022DF RID: 8927
	BattleScoreEnableChanged,
	// Token: 0x040022E0 RID: 8928
	OnRefreshFormationCooldownExternalInBattleView,
	// Token: 0x040022E1 RID: 8929
	OnCharacterCapsuleChanged,
	// Token: 0x040022E2 RID: 8930
	OnKscPlayerHpChanged,
	// Token: 0x040022E3 RID: 8931
	OnKscPlayerCreate,
	// Token: 0x040022E4 RID: 8932
	RefreshInfluencePanel,
	// Token: 0x040022E5 RID: 8933
	ReceiveReputationReward,
	// Token: 0x040022E6 RID: 8934
	SearchInfluence,
	// Token: 0x040022E7 RID: 8935
	RedDotInfluence,
	// Token: 0x040022E8 RID: 8936
	BehaviorTreeStartActionSession,
	// Token: 0x040022E9 RID: 8937
	UiPlayCloseAudio,
	// Token: 0x040022EA RID: 8938
	OnSceneItemLockPropChange,
	// Token: 0x040022EB RID: 8939
	OnSpecialItemUpdate,
	// Token: 0x040022EC RID: 8940
	EquipAndSwitchSpecialItem,
	// Token: 0x040022ED RID: 8941
	UnEquipSpecialItem,
	// Token: 0x040022EE RID: 8942
	ShowPlayerPosition,
	// Token: 0x040022EF RID: 8943
	BattlePassHadEnterUpdate,
	// Token: 0x040022F0 RID: 8944
	GetBattlePassRewardEvent,
	// Token: 0x040022F1 RID: 8945
	ReceiveBattlePassDataEvent,
	// Token: 0x040022F2 RID: 8946
	NotifyBattlePassToBuyEvent,
	// Token: 0x040022F3 RID: 8947
	BattlePassFirstUnlockAnime,
	// Token: 0x040022F4 RID: 8948
	OnReceiveBattlePassPaid,
	// Token: 0x040022F5 RID: 8949
	ReceiveBattlePassTaskEvent,
	// Token: 0x040022F6 RID: 8950
	OnChoseLevelItemEvent,
	// Token: 0x040022F7 RID: 8951
	OnClickLevelItemEvent,
	// Token: 0x040022F8 RID: 8952
	UpdateBattlePassTaskEvent,
	// Token: 0x040022F9 RID: 8953
	OnBattlePassLevelUpEvent,
	// Token: 0x040022FA RID: 8954
	OnBattlePassSkip,
	// Token: 0x040022FB RID: 8955
	OnBattlePassExpireEvent,
	// Token: 0x040022FC RID: 8956
	BattlePassMainViewHide,
	// Token: 0x040022FD RID: 8957
	OnResetSkinDamageMode,
	// Token: 0x040022FE RID: 8958
	OnExitNpcInteract,
	// Token: 0x040022FF RID: 8959
	SwitchViewType,
	// Token: 0x04002300 RID: 8960
	SwitchComposeType,
	// Token: 0x04002301 RID: 8961
	GetComposeData,
	// Token: 0x04002302 RID: 8962
	UpgradeComposeLevel,
	// Token: 0x04002303 RID: 8963
	OpenComposeLevel,
	// Token: 0x04002304 RID: 8964
	OpenCompose,
	// Token: 0x04002305 RID: 8965
	ComposeSuccess,
	// Token: 0x04002306 RID: 8966
	ComposeFail,
	// Token: 0x04002307 RID: 8967
	ComposeSwitchType,
	// Token: 0x04002308 RID: 8968
	OpenHelpRole,
	// Token: 0x04002309 RID: 8969
	CloseHelpRole,
	// Token: 0x0400230A RID: 8970
	UpdateComposeFormula,
	// Token: 0x0400230B RID: 8971
	UpdateComposeInfo,
	// Token: 0x0400230C RID: 8972
	UpdateForgingFormula,
	// Token: 0x0400230D RID: 8973
	OpenForging,
	// Token: 0x0400230E RID: 8974
	GetForgingData,
	// Token: 0x0400230F RID: 8975
	ForgingSuccess,
	// Token: 0x04002310 RID: 8976
	ForgingFail,
	// Token: 0x04002311 RID: 8977
	ChangePlayerInfoId,
	// Token: 0x04002312 RID: 8978
	OnShowGridAnimation,
	// Token: 0x04002313 RID: 8979
	OnActivateUiCameraAnimationHandle,
	// Token: 0x04002314 RID: 8980
	OnActivateUiCameraAnimationHandleFail,
	// Token: 0x04002315 RID: 8981
	OnUiBlendInTimeCameraFinished,
	// Token: 0x04002316 RID: 8982
	OnUiBlendInCameraSequenceFinished,
	// Token: 0x04002317 RID: 8983
	RoleHandBookActive,
	// Token: 0x04002318 RID: 8984
	OnSequenceCameraStatus,
	// Token: 0x04002319 RID: 8985
	LocalStorageInitPlayerId,
	// Token: 0x0400231A RID: 8986
	DynamicInteractServerResponse,
	// Token: 0x0400231B RID: 8987
	UpdateCameraInfo,
	// Token: 0x0400231C RID: 8988
	PlayCameraLevelSequence,
	// Token: 0x0400231D RID: 8989
	CameraModeChanged,
	// Token: 0x0400231E RID: 8990
	CameraViewTargetChanged,
	// Token: 0x0400231F RID: 8991
	FixedCameraRestored,
	// Token: 0x04002320 RID: 8992
	CameraCharacterChanged,
	// Token: 0x04002321 RID: 8993
	AdjustCameraSync,
	// Token: 0x04002322 RID: 8994
	OpenTreasureBox,
	// Token: 0x04002323 RID: 8995
	OnHandBookDataInit,
	// Token: 0x04002324 RID: 8996
	OnHandBookDataUpdate,
	// Token: 0x04002325 RID: 8997
	OnHandBookRedDotUpdate,
	// Token: 0x04002326 RID: 8998
	OnHandBookRead,
	// Token: 0x04002327 RID: 8999
	OnPhantomReadRedDotUpdate,
	// Token: 0x04002328 RID: 9000
	OnItemReadRedDotUpdate,
	// Token: 0x04002329 RID: 9001
	OnPhotoSelect,
	// Token: 0x0400232A RID: 9002
	OnGeographyPhotoSelect,
	// Token: 0x0400232B RID: 9003
	OnHandBookPlotNodeRefresh,
	// Token: 0x0400232C RID: 9004
	RemoveCreatureDataComponentCache,
	// Token: 0x0400232D RID: 9005
	TravelClearView,
	// Token: 0x0400232E RID: 9006
	OnPressOrReleaseBehaviorButton,
	// Token: 0x0400232F RID: 9007
	SetImageQuality,
	// Token: 0x04002330 RID: 9008
	SetImageQualityWithValue,
	// Token: 0x04002331 RID: 9009
	SetRayTracingWithValue,
	// Token: 0x04002332 RID: 9010
	SetDLSSFGWithValue,
	// Token: 0x04002333 RID: 9011
	SetDisplayMode,
	// Token: 0x04002334 RID: 9012
	SetResolution,
	// Token: 0x04002335 RID: 9013
	SetNiagaraQuality,
	// Token: 0x04002336 RID: 9014
	SetEnvironmentInteraction,
	// Token: 0x04002337 RID: 9015
	AfterGameQualitySettingsManagerInitialize,
	// Token: 0x04002338 RID: 9016
	AfterGameSettingsAppliedOnOpenLoading,
	// Token: 0x04002339 RID: 9017
	LoadingRangeScaleChanged,
	// Token: 0x0400233A RID: 9018
	SetGmIsOpen,
	// Token: 0x0400233B RID: 9019
	AddToTickList,
	// Token: 0x0400233C RID: 9020
	HandleNextAction,
	// Token: 0x0400233D RID: 9021
	HandleActionFailure,
	// Token: 0x0400233E RID: 9022
	AddGuaranteeAction,
	// Token: 0x0400233F RID: 9023
	RemGuaranteeAction,
	// Token: 0x04002340 RID: 9024
	ShareGroupCd,
	// Token: 0x04002341 RID: 9025
	AddShareGroupLimitCount,
	// Token: 0x04002342 RID: 9026
	OnInteractPlotStart,
	// Token: 0x04002343 RID: 9027
	OnInteractPlotEnd,
	// Token: 0x04002344 RID: 9028
	OnAchievementDataNotify,
	// Token: 0x04002345 RID: 9029
	OnAchievementDataWithIdNotify,
	// Token: 0x04002346 RID: 9030
	OnAchievementGroupDataNotify,
	// Token: 0x04002347 RID: 9031
	OnGetAchievementBaseData,
	// Token: 0x04002348 RID: 9032
	OnGetAchievementSearchTextChange,
	// Token: 0x04002349 RID: 9033
	OnAchievementGroupChange,
	// Token: 0x0400234A RID: 9034
	RefreshAchievementRedPoint,
	// Token: 0x0400234B RID: 9035
	OnActivityUpdate,
	// Token: 0x0400234C RID: 9036
	OnSelectActivity,
	// Token: 0x0400234D RID: 9037
	OnSelectActivityAndSubViewReady,
	// Token: 0x0400234E RID: 9038
	RefreshActivityTab,
	// Token: 0x0400234F RID: 9039
	OnReceiveActivityData,
	// Token: 0x04002350 RID: 9040
	SetActivityViewState,
	// Token: 0x04002351 RID: 9041
	SetActivityViewCurrency,
	// Token: 0x04002352 RID: 9042
	ChangeActivityViewNeedBlurState,
	// Token: 0x04002353 RID: 9043
	OnClickActivityRunChallenge,
	// Token: 0x04002354 RID: 9044
	OnSelectActivityRunChallengeItem,
	// Token: 0x04002355 RID: 9045
	RefreshCommonActivityRedDot,
	// Token: 0x04002356 RID: 9046
	RoverlikeTalentUnlockDataUpdate,
	// Token: 0x04002357 RID: 9047
	RoverlikeQuestTaskUpdate,
	// Token: 0x04002358 RID: 9048
	RoverlikeReviveTimesUpdate,
	// Token: 0x04002359 RID: 9049
	RoverlikeResourceFloatText,
	// Token: 0x0400235A RID: 9050
	RoverlikeGainDataUpdate,
	// Token: 0x0400235B RID: 9051
	RoverlikeEquippedLootChange,
	// Token: 0x0400235C RID: 9052
	RoverlikeLootInfoUpdate,
	// Token: 0x0400235D RID: 9053
	RoverlikeLevelInfoUpdate,
	// Token: 0x0400235E RID: 9054
	RoverlikeShopInfoUpdate,
	// Token: 0x0400235F RID: 9055
	OnNewbieMainTaskUpdate,
	// Token: 0x04002360 RID: 9056
	RefreshRunActivityRedDot,
	// Token: 0x04002361 RID: 9057
	OnGetRunActivityReward,
	// Token: 0x04002362 RID: 9058
	ActivityCrossDayRefresh,
	// Token: 0x04002363 RID: 9059
	ActivityDataInitComplete,
	// Token: 0x04002364 RID: 9060
	OnActivityClose,
	// Token: 0x04002365 RID: 9061
	OnActivityOpen,
	// Token: 0x04002366 RID: 9062
	OnActivityPreOpen,
	// Token: 0x04002367 RID: 9063
	OnActivitySequenceEmitEvent,
	// Token: 0x04002368 RID: 9064
	RefreshCommonActivityRewardPopUpView,
	// Token: 0x04002369 RID: 9065
	ActivityViewChange,
	// Token: 0x0400236A RID: 9066
	ActivityViewRefreshCurrent,
	// Token: 0x0400236B RID: 9067
	LongShanUpdate,
	// Token: 0x0400236C RID: 9068
	OnPhantomCollectUpdate,
	// Token: 0x0400236D RID: 9069
	TurntableStartRun,
	// Token: 0x0400236E RID: 9070
	TrackMoonHandbookUpdate,
	// Token: 0x0400236F RID: 9071
	MoonChasingRefreshBuildingRedDot,
	// Token: 0x04002370 RID: 9072
	MoonChasingRefreshRewardRedDot,
	// Token: 0x04002371 RID: 9073
	MoonChasingRefreshDelegationRedDot,
	// Token: 0x04002372 RID: 9074
	MoonChasingRefreshRoleRedDot,
	// Token: 0x04002373 RID: 9075
	MoonChasingRefreshQuestRedDot,
	// Token: 0x04002374 RID: 9076
	MoonChasingOnOpenInteractive,
	// Token: 0x04002375 RID: 9077
	DreamLinkRewardRefresh,
	// Token: 0x04002376 RID: 9078
	DreamLinkLimitRewardRefresh,
	// Token: 0x04002377 RID: 9079
	MapTravelTaskRefresh,
	// Token: 0x04002378 RID: 9080
	MapTravelSoarRefresh,
	// Token: 0x04002379 RID: 9081
	MapTravelTaskNavigationNext,
	// Token: 0x0400237A RID: 9082
	OnCyberPunkUpdate,
	// Token: 0x0400237B RID: 9083
	OnCyberPunkTaskRefresh,
	// Token: 0x0400237C RID: 9084
	OnCyberPunkItemUnLock,
	// Token: 0x0400237D RID: 9085
	GmAutoModeChange,
	// Token: 0x0400237E RID: 9086
	OnAddNotAllowFightInputViewName,
	// Token: 0x0400237F RID: 9087
	OnRemoveNotAllowFightInputViewName,
	// Token: 0x04002380 RID: 9088
	OnClearNotAllowFightInputViewName,
	// Token: 0x04002381 RID: 9089
	OnSelectedEditPanelItem,
	// Token: 0x04002382 RID: 9090
	UiRoleSequenceEndKeyFrame,
	// Token: 0x04002383 RID: 9091
	DropItemStarted,
	// Token: 0x04002384 RID: 9092
	OnRoleChangeEnd,
	// Token: 0x04002385 RID: 9093
	ComboTeachingPress,
	// Token: 0x04002386 RID: 9094
	ComboTeachingRelease,
	// Token: 0x04002387 RID: 9095
	ComboTeachingHold,
	// Token: 0x04002388 RID: 9096
	ComboTeachingNodeEnd,
	// Token: 0x04002389 RID: 9097
	ComboTeachingIndexUpdate,
	// Token: 0x0400238A RID: 9098
	ComboTeachingViewOpen,
	// Token: 0x0400238B RID: 9099
	SkillAcceptChanged,
	// Token: 0x0400238C RID: 9100
	ComboTeachingFinish,
	// Token: 0x0400238D RID: 9101
	ComboTeachingCloseGuide,
	// Token: 0x0400238E RID: 9102
	RoleIntroductionViewHide,
	// Token: 0x0400238F RID: 9103
	RequestClearMeshRotationBuffer,
	// Token: 0x04002390 RID: 9104
	NavigationViewCreate,
	// Token: 0x04002391 RID: 9105
	NavigationViewDestroy,
	// Token: 0x04002392 RID: 9106
	ResetNavigationListener,
	// Token: 0x04002393 RID: 9107
	NavigationTriggerMapForward,
	// Token: 0x04002394 RID: 9108
	NavigationTriggerMapRight,
	// Token: 0x04002395 RID: 9109
	NavigationTriggerMapZoom,
	// Token: 0x04002396 RID: 9110
	NavigationTriggerRoleLookUp,
	// Token: 0x04002397 RID: 9111
	NavigationTriggerRoleTurn,
	// Token: 0x04002398 RID: 9112
	NavigationTriggerRoleZoom,
	// Token: 0x04002399 RID: 9113
	NavigationTriggerRoleReset,
	// Token: 0x0400239A RID: 9114
	GamepadMoveOverScreen,
	// Token: 0x0400239B RID: 9115
	NavigationTriggerPlotForward,
	// Token: 0x0400239C RID: 9116
	NavigationTriggerPlotRight,
	// Token: 0x0400239D RID: 9117
	NavigationTriggerPlotZoom,
	// Token: 0x0400239E RID: 9118
	NavigationRefreshPlotNextPage,
	// Token: 0x0400239F RID: 9119
	FunctionGridSelected,
	// Token: 0x040023A0 RID: 9120
	OnPersonalCardRead,
	// Token: 0x040023A1 RID: 9121
	OnPersonalCardRefreshRedDot,
	// Token: 0x040023A2 RID: 9122
	OnHeadIconChange,
	// Token: 0x040023A3 RID: 9123
	OnSignChange,
	// Token: 0x040023A4 RID: 9124
	OnNameChange,
	// Token: 0x040023A5 RID: 9125
	OnModifyNameStateChange,
	// Token: 0x040023A6 RID: 9126
	OnBirthChange,
	// Token: 0x040023A7 RID: 9127
	OnBirthDisplayChange,
	// Token: 0x040023A8 RID: 9128
	OnBirthRoleChange,
	// Token: 0x040023A9 RID: 9129
	OnCardChange,
	// Token: 0x040023AA RID: 9130
	ResetRoleFlag,
	// Token: 0x040023AB RID: 9131
	OnRoleShowListChange,
	// Token: 0x040023AC RID: 9132
	OnRoleElementChange,
	// Token: 0x040023AD RID: 9133
	ShowRoleElementChangePreviewEffect,
	// Token: 0x040023AE RID: 9134
	OnChangedActionKeys,
	// Token: 0x040023AF RID: 9135
	OnChangedAxisKeys,
	// Token: 0x040023B0 RID: 9136
	SelectRoleTab,
	// Token: 0x040023B1 RID: 9137
	SelectRoleTabOutside,
	// Token: 0x040023B2 RID: 9138
	OnFunctionViewShow,
	// Token: 0x040023B3 RID: 9139
	OnPlayerTitleChange,
	// Token: 0x040023B4 RID: 9140
	OnPlayerTitleRefreshRedDot,
	// Token: 0x040023B5 RID: 9141
	OnPlayerTitleUnlock,
	// Token: 0x040023B6 RID: 9142
	OnPersonalTipStateSet,
	// Token: 0x040023B7 RID: 9143
	LevelFlowSequenceTriggerEvent,
	// Token: 0x040023B8 RID: 9144
	OnLevelFlowFinished,
	// Token: 0x040023B9 RID: 9145
	UpdatePanelQteWorldTimeDilation,
	// Token: 0x040023BA RID: 9146
	PanelQteStart,
	// Token: 0x040023BB RID: 9147
	PanelQteEnd,
	// Token: 0x040023BC RID: 9148
	FreeRunningQteStart,
	// Token: 0x040023BD RID: 9149
	CommonQteStart,
	// Token: 0x040023BE RID: 9150
	CommonQteEnd,
	// Token: 0x040023BF RID: 9151
	QtaStart,
	// Token: 0x040023C0 RID: 9152
	QtaEnd,
	// Token: 0x040023C1 RID: 9153
	StartHeartBeat,
	// Token: 0x040023C2 RID: 9154
	StopHeartBeat,
	// Token: 0x040023C3 RID: 9155
	CreateEffectHandle,
	// Token: 0x040023C4 RID: 9156
	RemoveEffectHandle,
	// Token: 0x040023C5 RID: 9157
	LoadEffect,
	// Token: 0x040023C6 RID: 9158
	BeforePlayEffect,
	// Token: 0x040023C7 RID: 9159
	AfterPlayEffect,
	// Token: 0x040023C8 RID: 9160
	FinishEffect,
	// Token: 0x040023C9 RID: 9161
	TestQuestAutoPilotFinish,
	// Token: 0x040023CA RID: 9162
	TestQuestFunctionFinish,
	// Token: 0x040023CB RID: 9163
	OnRefreshRewardViewItemList,
	// Token: 0x040023CC RID: 9164
	OnRefreshRewardProgressBar,
	// Token: 0x040023CD RID: 9165
	OnRefreshRewardButton,
	// Token: 0x040023CE RID: 9166
	OnItemRewardNotify,
	// Token: 0x040023CF RID: 9167
	OnExploreRewardShowEnd,
	// Token: 0x040023D0 RID: 9168
	OnShowRewardView,
	// Token: 0x040023D1 RID: 9169
	OnCloseRewardView,
	// Token: 0x040023D2 RID: 9170
	OnPlotWaitViewDone,
	// Token: 0x040023D3 RID: 9171
	OnPlayCameraAnimationStart,
	// Token: 0x040023D4 RID: 9172
	OnPlayCameraAnimationFinish,
	// Token: 0x040023D5 RID: 9173
	CommunicateFinished,
	// Token: 0x040023D6 RID: 9174
	CommunicateAgain,
	// Token: 0x040023D7 RID: 9175
	ChallengeAgain,
	// Token: 0x040023D8 RID: 9176
	OnPhotographSetUpViewVisibleChanged,
	// Token: 0x040023D9 RID: 9177
	OnEntityCameraOneSituationChanged,
	// Token: 0x040023DA RID: 9178
	OnEntityCameraMissTarget,
	// Token: 0x040023DB RID: 9179
	OnEntityCameraOptionalSituationChanged,
	// Token: 0x040023DC RID: 9180
	OnEntityCameraSearchGreat,
	// Token: 0x040023DD RID: 9181
	OnEntityCameraFinished,
	// Token: 0x040023DE RID: 9182
	OnScreenShotDone,
	// Token: 0x040023DF RID: 9183
	OnPhotographSetVisible,
	// Token: 0x040023E0 RID: 9184
	OnChangeFovByOption,
	// Token: 0x040023E1 RID: 9185
	NotifyBtFightPhotoTaskFinish,
	// Token: 0x040023E2 RID: 9186
	OnChangeFightPhotoOption,
	// Token: 0x040023E3 RID: 9187
	OnNeedShowFightPhotoFocus,
	// Token: 0x040023E4 RID: 9188
	OnRefreshFightPhotoLevelRedDot,
	// Token: 0x040023E5 RID: 9189
	OnSyncFightPhotoTiltAngle,
	// Token: 0x040023E6 RID: 9190
	OnSubmitItemSuccess,
	// Token: 0x040023E7 RID: 9191
	OnSubmitItemFail,
	// Token: 0x040023E8 RID: 9192
	OnSubmitItemLevelUp,
	// Token: 0x040023E9 RID: 9193
	OnSubmitItemLevelMax,
	// Token: 0x040023EA RID: 9194
	OnCameraSequenceSetUiVisible,
	// Token: 0x040023EB RID: 9195
	OnUiScreenRootVisibleChange,
	// Token: 0x040023EC RID: 9196
	OnTurntableControllerBusyStateChange,
	// Token: 0x040023ED RID: 9197
	OnAnyProgressControlEnableStateChange,
	// Token: 0x040023EE RID: 9198
	OnDropItemSuccess,
	// Token: 0x040023EF RID: 9199
	OnInteractDropItemSuccess,
	// Token: 0x040023F0 RID: 9200
	OnExecuteUiCameraSequenceEvent,
	// Token: 0x040023F1 RID: 9201
	OnInputAnyKey,
	// Token: 0x040023F2 RID: 9202
	OnImmersiveInputStateChange,
	// Token: 0x040023F3 RID: 9203
	OnAddDynamicOption,
	// Token: 0x040023F4 RID: 9204
	OnRemoveDynamicOption,
	// Token: 0x040023F5 RID: 9205
	OnFilterDataUpdate,
	// Token: 0x040023F6 RID: 9206
	OnPlayNpcPerformSequence,
	// Token: 0x040023F7 RID: 9207
	OnNpcPerformSequenceFinished,
	// Token: 0x040023F8 RID: 9208
	OnAntiqueShopUpgradeSequenceFinished,
	// Token: 0x040023F9 RID: 9209
	OnAntiqueShopLevelMaxSequenceFinished,
	// Token: 0x040023FA RID: 9210
	OnAntiqueShopUpgradeSequencePlayFail,
	// Token: 0x040023FB RID: 9211
	OnCookSuccessSequenceFinished,
	// Token: 0x040023FC RID: 9212
	OnBeginPlayCookSuccessDisplay,
	// Token: 0x040023FD RID: 9213
	OnPlayCookSuccessDisplayFinished,
	// Token: 0x040023FE RID: 9214
	OnBeginPlayCookFailDisplay,
	// Token: 0x040023FF RID: 9215
	OnPlayCookFailDisplayFinished,
	// Token: 0x04002400 RID: 9216
	OnBeginPlayCompositeWorkingDisplay,
	// Token: 0x04002401 RID: 9217
	OnPlayCompositeWorkingDisplayFinished,
	// Token: 0x04002402 RID: 9218
	OnBeginPlayForgingWorkingDisplay,
	// Token: 0x04002403 RID: 9219
	OnPlayForgingWorkingDisplayFinished,
	// Token: 0x04002404 RID: 9220
	OnCharFootOnTheGround,
	// Token: 0x04002405 RID: 9221
	BattleViewActiveSequenceFinish,
	// Token: 0x04002406 RID: 9222
	ShowFloatTips,
	// Token: 0x04002407 RID: 9223
	SmartObjectAiAlterNotify,
	// Token: 0x04002408 RID: 9224
	OnSetActorHidden,
	// Token: 0x04002409 RID: 9225
	OnPreSetActorHidden,
	// Token: 0x0400240A RID: 9226
	OnCheckGamePing,
	// Token: 0x0400240B RID: 9227
	OnRemoveItemRedDot,
	// Token: 0x0400240C RID: 9228
	RunGm,
	// Token: 0x0400240D RID: 9229
	GmHandleActionFailed,
	// Token: 0x0400240E RID: 9230
	TestEffectAddDaRec,
	// Token: 0x0400240F RID: 9231
	TestEffectAddEffectRec,
	// Token: 0x04002410 RID: 9232
	TestManuallyGarbageCollection,
	// Token: 0x04002411 RID: 9233
	GmEntityPerformanceTestFinish,
	// Token: 0x04002412 RID: 9234
	GmOnlyShowMiniMap,
	// Token: 0x04002413 RID: 9235
	GmOnlyShowJoyStick,
	// Token: 0x04002414 RID: 9236
	GmHideMissionAndBossName,
	// Token: 0x04002415 RID: 9237
	RogueBattleDescModeChange,
	// Token: 0x04002416 RID: 9238
	RogueBattleSelectOption,
	// Token: 0x04002417 RID: 9239
	RogueBattleSelectOptionPreview,
	// Token: 0x04002418 RID: 9240
	RoguelikeCloseGainSelectView,
	// Token: 0x04002419 RID: 9241
	RoguelikeDataUpdate,
	// Token: 0x0400241A RID: 9242
	RoguelikeChooseDataResult,
	// Token: 0x0400241B RID: 9243
	RoguelikeChooseDataNotify,
	// Token: 0x0400241C RID: 9244
	RoguelikeInfoSelectedToken,
	// Token: 0x0400241D RID: 9245
	RoguelikeRefreshGain,
	// Token: 0x0400241E RID: 9246
	RoguelikeSelectSkill,
	// Token: 0x0400241F RID: 9247
	RoguelikeTalentLevelUp,
	// Token: 0x04002420 RID: 9248
	RoguelikeCurrencyUpdate,
	// Token: 0x04002421 RID: 9249
	RoguelikeSelectToken,
	// Token: 0x04002422 RID: 9250
	RoguelikeSelectSeason,
	// Token: 0x04002423 RID: 9251
	RoguelikeGetTokenReward,
	// Token: 0x04002424 RID: 9252
	RogueTermUnlock,
	// Token: 0x04002425 RID: 9253
	RoguelikeHasSelectEntryAndShow,
	// Token: 0x04002426 RID: 9254
	RoguelikeArchiveSaved,
	// Token: 0x04002427 RID: 9255
	WeeklyRogueInstDataUpdate,
	// Token: 0x04002428 RID: 9256
	WeeklyRogueSelectOption,
	// Token: 0x04002429 RID: 9257
	WeeklyRogueDescModeChange,
	// Token: 0x0400242A RID: 9258
	WeeklyRogueShopSelect,
	// Token: 0x0400242B RID: 9259
	WeeklyRogueRefreshScoreRedDot,
	// Token: 0x0400242C RID: 9260
	WeeklyRogueCycleRefresh,
	// Token: 0x0400242D RID: 9261
	WeeklyRogueRedDotInfoRefresh,
	// Token: 0x0400242E RID: 9262
	WeeklyRogueBurstEnableChange,
	// Token: 0x0400242F RID: 9263
	MapDragMoveForward,
	// Token: 0x04002430 RID: 9264
	MapDragMoveRight,
	// Token: 0x04002431 RID: 9265
	PermanentRogueBattleSummaryInfoToggle,
	// Token: 0x04002432 RID: 9266
	PermanentRogueRewardUpdate,
	// Token: 0x04002433 RID: 9267
	PermanentRogueSeasonRedDotUpdate,
	// Token: 0x04002434 RID: 9268
	PermanentRogueSkillCurrencyRedDotUpdate,
	// Token: 0x04002435 RID: 9269
	RogueResSelectSkill,
	// Token: 0x04002436 RID: 9270
	RogueResTalentLevelUp,
	// Token: 0x04002437 RID: 9271
	RogueResEnterInstClicked,
	// Token: 0x04002438 RID: 9272
	RogueResEndingSwitch,
	// Token: 0x04002439 RID: 9273
	RogueResEndingRedDotUpdate,
	// Token: 0x0400243A RID: 9274
	RogueResMapSummaryTeamUpdate,
	// Token: 0x0400243B RID: 9275
	RogueResMapSummaryFettersSubTabUpdate,
	// Token: 0x0400243C RID: 9276
	RogueResMapSummaryTeamToBondUpdate,
	// Token: 0x0400243D RID: 9277
	RogueResMapSummaryBondUpdate,
	// Token: 0x0400243E RID: 9278
	RogueViewInfoRefresh,
	// Token: 0x0400243F RID: 9279
	RogueResMapSummaryTeamShowAgain,
	// Token: 0x04002440 RID: 9280
	RogueTeamEditViewLinkBtnRefresh,
	// Token: 0x04002441 RID: 9281
	RogueMapMoveTweenStarOrEnd,
	// Token: 0x04002442 RID: 9282
	RogueMapEventDetailOpenOrClose,
	// Token: 0x04002443 RID: 9283
	RogueResTeamLvChange,
	// Token: 0x04002444 RID: 9284
	RogueResMoodChange,
	// Token: 0x04002445 RID: 9285
	RogueResNewRoleFlagChange,
	// Token: 0x04002446 RID: 9286
	OnPreparePhotoScreenShot,
	// Token: 0x04002447 RID: 9287
	OnPhotographViewCaptureMode,
	// Token: 0x04002448 RID: 9288
	OnMarkItemViewCreate,
	// Token: 0x04002449 RID: 9289
	OnMarkItemViewDestroy,
	// Token: 0x0400244A RID: 9290
	TakeMarkComponentEnterContainer,
	// Token: 0x0400244B RID: 9291
	TakeMarkComponentExitContainer,
	// Token: 0x0400244C RID: 9292
	OnMarkItemViewEnter,
	// Token: 0x0400244D RID: 9293
	OnMarkItemViewExit,
	// Token: 0x0400244E RID: 9294
	LogCustomMarkInfo,
	// Token: 0x0400244F RID: 9295
	OnOpenSystemFeed,
	// Token: 0x04002450 RID: 9296
	OnCloseSystemFeed,
	// Token: 0x04002451 RID: 9297
	OnDeliveryProps,
	// Token: 0x04002452 RID: 9298
	OnWorldMapTrackMarkItem,
	// Token: 0x04002453 RID: 9299
	OnSundialRingChangeShine,
	// Token: 0x04002454 RID: 9300
	OnSundialRingSwitch,
	// Token: 0x04002455 RID: 9301
	OnNeedUpdateSundialTips,
	// Token: 0x04002456 RID: 9302
	OnSignalDeviceLinkingCheck,
	// Token: 0x04002457 RID: 9303
	OnSignalDeviceReset,
	// Token: 0x04002458 RID: 9304
	OnSignalDeviceLinking,
	// Token: 0x04002459 RID: 9305
	OnSignalDeviceFinish,
	// Token: 0x0400245A RID: 9306
	OnOverlapSceneItemExploreInteractRange,
	// Token: 0x0400245B RID: 9307
	OnUseMapExploreToolSuccess,
	// Token: 0x0400245C RID: 9308
	OnMapExploreToolPlaceNumUpdated,
	// Token: 0x0400245D RID: 9309
	DoLeaveLevel,
	// Token: 0x0400245E RID: 9310
	OnInstanceChange,
	// Token: 0x0400245F RID: 9311
	RefreshInputData,
	// Token: 0x04002460 RID: 9312
	ClearSceneBegin,
	// Token: 0x04002461 RID: 9313
	OnExploreProgressResponse,
	// Token: 0x04002462 RID: 9314
	OnReceiveAreaStageRewardResponse,
	// Token: 0x04002463 RID: 9315
	OnAreaExploreProgressUpdate,
	// Token: 0x04002464 RID: 9316
	ToggleShowCustomMark,
	// Token: 0x04002465 RID: 9317
	ToggleShowCompletedPlayMark,
	// Token: 0x04002466 RID: 9318
	RedDotUpdateMapAreaBoxReward,
	// Token: 0x04002467 RID: 9319
	AreaPlayPointUpdate,
	// Token: 0x04002468 RID: 9320
	AreaStoryProgressSave,
	// Token: 0x04002469 RID: 9321
	NavigateMarkAndShowRange,
	// Token: 0x0400246A RID: 9322
	HideNavigateMarkRange,
	// Token: 0x0400246B RID: 9323
	UpdateOnlinePlayersArea,
	// Token: 0x0400246C RID: 9324
	PlayerMarkItemChanged,
	// Token: 0x0400246D RID: 9325
	OpenExploreAreaDetailViewFromMap,
	// Token: 0x0400246E RID: 9326
	OnExploreScoreRewardResponse,
	// Token: 0x0400246F RID: 9327
	OnCountryExploreScoreInfoResponse,
	// Token: 0x04002470 RID: 9328
	OnExploreLevelNotify,
	// Token: 0x04002471 RID: 9329
	ShipTowerStageUpdate,
	// Token: 0x04002472 RID: 9330
	ShipTowerRewardReceive,
	// Token: 0x04002473 RID: 9331
	ShipTowerBattleTip,
	// Token: 0x04002474 RID: 9332
	ShipTowerSureResetStage,
	// Token: 0x04002475 RID: 9333
	ShipTowerSureCoverChallenge,
	// Token: 0x04002476 RID: 9334
	ShipTowerTeamRecommendApplyFinish,
	// Token: 0x04002477 RID: 9335
	BattleUiToggleShipTowerBuffInfo,
	// Token: 0x04002478 RID: 9336
	RedDotUpdateShipTowerReward,
	// Token: 0x04002479 RID: 9337
	OpenActivityViewShipTower,
	// Token: 0x0400247A RID: 9338
	ShipTowerBuffNewUpdate,
	// Token: 0x0400247B RID: 9339
	ShipTowerEndlessRecordUpdate,
	// Token: 0x0400247C RID: 9340
	DangoMonopolyTaskUpdate,
	// Token: 0x0400247D RID: 9341
	DangoMonopolyMoveStart,
	// Token: 0x0400247E RID: 9342
	DangoMonopolyMovePause,
	// Token: 0x0400247F RID: 9343
	DangoMonopolyMoveContinue,
	// Token: 0x04002480 RID: 9344
	DangoMonopolyMoveEnd,
	// Token: 0x04002481 RID: 9345
	DangoMonopolyEnterNextRound,
	// Token: 0x04002482 RID: 9346
	DangoMonopolyBoardRewardUpdate,
	// Token: 0x04002483 RID: 9347
	DangoMonopolyGridRewardUpdate,
	// Token: 0x04002484 RID: 9348
	DangoMonopolyStartShowProcess,
	// Token: 0x04002485 RID: 9349
	DangoMonopolyEndShowProcess,
	// Token: 0x04002486 RID: 9350
	DangoMonopolyTransitionClose,
	// Token: 0x04002487 RID: 9351
	DangoMonopolyMoveStepStartOrEnd,
	// Token: 0x04002488 RID: 9352
	DangoMonopolyViewStart,
	// Token: 0x04002489 RID: 9353
	DangoMonopolyViewShowProcessStartOrEnd,
	// Token: 0x0400248A RID: 9354
	DangoMonopolyCameraFocusOnMainDango,
	// Token: 0x0400248B RID: 9355
	RedDotUpdateDangoMonopolyTask,
	// Token: 0x0400248C RID: 9356
	RedDotUpdateDangoMonopolyNum,
	// Token: 0x0400248D RID: 9357
	RedDotUpdateDangoMonopolyRound,
	// Token: 0x0400248E RID: 9358
	MoraleProgressRewardUpdate,
	// Token: 0x0400248F RID: 9359
	MoraleProgressScoreUpdate,
	// Token: 0x04002490 RID: 9360
	MoraleAreaChangeFlag,
	// Token: 0x04002491 RID: 9361
	RedDotUpdateMoraleScoreBox,
	// Token: 0x04002492 RID: 9362
	RedDotUpdateMoraleFlagBox,
	// Token: 0x04002493 RID: 9363
	RedDotUpdateMoraleAreaBuff,
	// Token: 0x04002494 RID: 9364
	BattleUiToggleMoraleBuffInfo,
	// Token: 0x04002495 RID: 9365
	OnMoralePromptShow,
	// Token: 0x04002496 RID: 9366
	ActivityMapExploreStateUpdate,
	// Token: 0x04002497 RID: 9367
	OnSignalCatchSuccess,
	// Token: 0x04002498 RID: 9368
	OnSignalCatchFailed,
	// Token: 0x04002499 RID: 9369
	OnSignalCatchStart,
	// Token: 0x0400249A RID: 9370
	OnSignalCatchContinue,
	// Token: 0x0400249B RID: 9371
	OnSignalCatchStartAgain,
	// Token: 0x0400249C RID: 9372
	RefreshMonthCardRedDot,
	// Token: 0x0400249D RID: 9373
	OnSetJoystickMode,
	// Token: 0x0400249E RID: 9374
	OnSetMotorcycleJoystickMode,
	// Token: 0x0400249F RID: 9375
	OnMotorcycleRoundJoystickChanged,
	// Token: 0x040024A0 RID: 9376
	OnOverlapEncloseSpace,
	// Token: 0x040024A1 RID: 9377
	OnEncloseSpaceTypeChange,
	// Token: 0x040024A2 RID: 9378
	OnSubLevelAdded,
	// Token: 0x040024A3 RID: 9379
	OnLevelEnvChange,
	// Token: 0x040024A4 RID: 9380
	OnWorldOriginInUiMode,
	// Token: 0x040024A5 RID: 9381
	OnAndroidConfigurationChange,
	// Token: 0x040024A6 RID: 9382
	OnChatPlayerInfoChanged,
	// Token: 0x040024A7 RID: 9383
	OnPlotTransitionRemoveCallback,
	// Token: 0x040024A8 RID: 9384
	OnEnterOrExitExecutionRange,
	// Token: 0x040024A9 RID: 9385
	OnExecutionOptionChange,
	// Token: 0x040024AA RID: 9386
	OnInteractActionEnd,
	// Token: 0x040024AB RID: 9387
	OnBeforeCharActionWithTarget,
	// Token: 0x040024AC RID: 9388
	CharActionStateChange,
	// Token: 0x040024AD RID: 9389
	MReady,
	// Token: 0x040024AE RID: 9390
	OnLevelFuncFlagSet,
	// Token: 0x040024AF RID: 9391
	OnLevelFuncFlagChanged,
	// Token: 0x040024B0 RID: 9392
	OnRefreshRewardView,
	// Token: 0x040024B1 RID: 9393
	OnRefreshSpecialItemAllowReqUse,
	// Token: 0x040024B2 RID: 9394
	OnSdkFocusStateChange,
	// Token: 0x040024B3 RID: 9395
	ReconnectClearData,
	// Token: 0x040024B4 RID: 9396
	OnPreEndPIE,
	// Token: 0x040024B5 RID: 9397
	NoticeJourneyReceive,
	// Token: 0x040024B6 RID: 9398
	OnEntityInOutRangeLocal,
	// Token: 0x040024B7 RID: 9399
	OnMyPlayerInOutRangeLocal,
	// Token: 0x040024B8 RID: 9400
	OnActorInOutRangeLocal,
	// Token: 0x040024B9 RID: 9401
	OnEntityInOutRangeOnline,
	// Token: 0x040024BA RID: 9402
	OnPlayerInOutRangeOnline,
	// Token: 0x040024BB RID: 9403
	RoleTriggerInit,
	// Token: 0x040024BC RID: 9404
	OnSetLoginServerId,
	// Token: 0x040024BD RID: 9405
	SetDecalShadowEnabled,
	// Token: 0x040024BE RID: 9406
	OnSelectTimePreset,
	// Token: 0x040024BF RID: 9407
	OnGlobalUiSceneStateChanged,
	// Token: 0x040024C0 RID: 9408
	OnSetGamePaused,
	// Token: 0x040024C1 RID: 9409
	OnActionKeyChanged,
	// Token: 0x040024C2 RID: 9410
	OnAxisKeyChanged,
	// Token: 0x040024C3 RID: 9411
	BeamCastStart,
	// Token: 0x040024C4 RID: 9412
	BeamCastStop,
	// Token: 0x040024C5 RID: 9413
	BeamCastActorChange,
	// Token: 0x040024C6 RID: 9414
	BeamReflectStart,
	// Token: 0x040024C7 RID: 9415
	BeamReflectStop,
	// Token: 0x040024C8 RID: 9416
	OnResetPhotographCamera,
	// Token: 0x040024C9 RID: 9417
	OnSpecialItemNotAllow,
	// Token: 0x040024CA RID: 9418
	OnMarkItemShowStateChange,
	// Token: 0x040024CB RID: 9419
	OnMarkItemUpdateMarkHideInfo,
	// Token: 0x040024CC RID: 9420
	OnTimeStopRequest,
	// Token: 0x040024CD RID: 9421
	OnAbsoluteTimeStop,
	// Token: 0x040024CE RID: 9422
	OnFightTestEnd,
	// Token: 0x040024CF RID: 9423
	OnManipulateShowLandTips,
	// Token: 0x040024D0 RID: 9424
	BeforeUiModelLoadStart,
	// Token: 0x040024D1 RID: 9425
	OnUiModelRoleConfigIdChange,
	// Token: 0x040024D2 RID: 9426
	OnUiModelRoleDataIdChange,
	// Token: 0x040024D3 RID: 9427
	OnUiModelStartLoad,
	// Token: 0x040024D4 RID: 9428
	OnUiModelLoadComplete,
	// Token: 0x040024D5 RID: 9429
	OnUiModelSetMorphTypeComplete,
	// Token: 0x040024D6 RID: 9430
	OnUiModelVisibleChange,
	// Token: 0x040024D7 RID: 9431
	OnUiModelSetDitherEffect,
	// Token: 0x040024D8 RID: 9432
	WorldMapSubMapChanged,
	// Token: 0x040024D9 RID: 9433
	WorldMapSubMapChangedFromUpdate,
	// Token: 0x040024DA RID: 9434
	WorldMapSelectMultiMap,
	// Token: 0x040024DB RID: 9435
	RoguelikePopularEntriesChange,
	// Token: 0x040024DC RID: 9436
	OnSceneItemSplineMoveBroken,
	// Token: 0x040024DD RID: 9437
	OnSceneItemSplineMoveStarted,
	// Token: 0x040024DE RID: 9438
	OnSceneItemSplineMoveStopped,
	// Token: 0x040024DF RID: 9439
	OnSceneItemMoveBroken,
	// Token: 0x040024E0 RID: 9440
	OnSceneItemMoveStopped,
	// Token: 0x040024E1 RID: 9441
	OnSceneItemRotateStopped,
	// Token: 0x040024E2 RID: 9442
	OnFragmentMemoryDataUpdate,
	// Token: 0x040024E3 RID: 9443
	OnFragmentMemoryCollectUpdate,
	// Token: 0x040024E4 RID: 9444
	OnFragmentTopicSelect,
	// Token: 0x040024E5 RID: 9445
	OnFragmentTopicClick,
	// Token: 0x040024E6 RID: 9446
	FragmentRewardRedDot,
	// Token: 0x040024E7 RID: 9447
	FragmentRewardTopicRedDot,
	// Token: 0x040024E8 RID: 9448
	FragmentRewardEntranceRedDot,
	// Token: 0x040024E9 RID: 9449
	OnChangeBossRushBuff,
	// Token: 0x040024EA RID: 9450
	RequestChangeBossRushView,
	// Token: 0x040024EB RID: 9451
	BossRushDataUpdate,
	// Token: 0x040024EC RID: 9452
	BossRefreshBossRushRewardRedDot,
	// Token: 0x040024ED RID: 9453
	BossRefreshBossRushReward,
	// Token: 0x040024EE RID: 9454
	BossRushBuffTabChange,
	// Token: 0x040024EF RID: 9455
	BossRushSubViewChanged,
	// Token: 0x040024F0 RID: 9456
	BossRushTaskStateChanged,
	// Token: 0x040024F1 RID: 9457
	RefreshMowingTowerData,
	// Token: 0x040024F2 RID: 9458
	RefreshMowingTowerRewardRedDot,
	// Token: 0x040024F3 RID: 9459
	RefreshMowingTowerReward,
	// Token: 0x040024F4 RID: 9460
	ChangeMowingTowerBuff,
	// Token: 0x040024F5 RID: 9461
	ChangeMowingTowerMainView,
	// Token: 0x040024F6 RID: 9462
	TowerDefenseOnOpenPhantomView,
	// Token: 0x040024F7 RID: 9463
	TowerDefenseOnClickOnePhantom,
	// Token: 0x040024F8 RID: 9464
	TowerDefenseSelfPhantomConfirm,
	// Token: 0x040024F9 RID: 9465
	TowerDefensePhantomChanged,
	// Token: 0x040024FA RID: 9466
	TowerDefenseBeforeConfirmQuickRoleSelect,
	// Token: 0x040024FB RID: 9467
	TowerDefenseOnWaveChanged,
	// Token: 0x040024FC RID: 9468
	TowerDefenseOnActivityInfoUpdateNotify,
	// Token: 0x040024FD RID: 9469
	TowerDefenseOnInstanceInfoUpdateNotify,
	// Token: 0x040024FE RID: 9470
	TowerDefenseOnPhantomInfoUpdateNotify,
	// Token: 0x040024FF RID: 9471
	TowerDefenseShowInBattleView,
	// Token: 0x04002500 RID: 9472
	TowerDefenseOnShowPhantomInFormation,
	// Token: 0x04002501 RID: 9473
	TowerDefenseOnTowerDefenseBattleEndNotify,
	// Token: 0x04002502 RID: 9474
	TowerDefenseDataInit,
	// Token: 0x04002503 RID: 9475
	OnBeforeDestroyInstanceDungeonEntranceView,
	// Token: 0x04002504 RID: 9476
	TrapFollowerSkillCd,
	// Token: 0x04002505 RID: 9477
	RefreshTrapDefensePsFeedback,
	// Token: 0x04002506 RID: 9478
	TowerDefenseRecycleRaycastNotify,
	// Token: 0x04002507 RID: 9479
	TowerDefenseEventStepUpdate,
	// Token: 0x04002508 RID: 9480
	TowerDefenseEventNotifyType,
	// Token: 0x04002509 RID: 9481
	TrapDefenseMapMarkRemoved,
	// Token: 0x0400250A RID: 9482
	TrapDefenseMapChanged,
	// Token: 0x0400250B RID: 9483
	TrapDefenseComboNumChange,
	// Token: 0x0400250C RID: 9484
	TrapDefenseOnSystemInfoNotify,
	// Token: 0x0400250D RID: 9485
	OnClickEnterInstanceSingle,
	// Token: 0x0400250E RID: 9486
	OnNeedRefreshByProtocol,
	// Token: 0x0400250F RID: 9487
	MowingBasicBuffGridItemClick,
	// Token: 0x04002510 RID: 9488
	MowingSuperBuffGridItemClick,
	// Token: 0x04002511 RID: 9489
	MowingRiskInBattleViewSetActive,
	// Token: 0x04002512 RID: 9490
	MowingRiskInBattleRootUpdate,
	// Token: 0x04002513 RID: 9491
	MowingRiskOnInstanceClearRewardResponse,
	// Token: 0x04002514 RID: 9492
	MowingRiskOnScoreRewardResponse,
	// Token: 0x04002515 RID: 9493
	MowingRiskOnBuffCountRewardResponse,
	// Token: 0x04002516 RID: 9494
	MowingRiskOnRefreshRewardRedDot,
	// Token: 0x04002517 RID: 9495
	MowingRiskOnRefreshBuffAllRedDot,
	// Token: 0x04002518 RID: 9496
	MowingRiskOnBuffTipsAfterDestroy,
	// Token: 0x04002519 RID: 9497
	MowingRiskOnNeedPlayLevelUpSequence,
	// Token: 0x0400251A RID: 9498
	MowingRiskOnGetReward,
	// Token: 0x0400251B RID: 9499
	SpecialOpenMapAction,
	// Token: 0x0400251C RID: 9500
	VersionPreheatRewardResponse,
	// Token: 0x0400251D RID: 9501
	VersionPreheatOnClickVote,
	// Token: 0x0400251E RID: 9502
	VersionPreheatSendVote,
	// Token: 0x0400251F RID: 9503
	Spring25DrawRewardDone,
	// Token: 0x04002520 RID: 9504
	Spring25SkinRewardDone,
	// Token: 0x04002521 RID: 9505
	Spring25InviteDone,
	// Token: 0x04002522 RID: 9506
	Spring25SelectLetter,
	// Token: 0x04002523 RID: 9507
	Spring25ActivityParseDone,
	// Token: 0x04002524 RID: 9508
	Spring25CloseLetterList,
	// Token: 0x04002525 RID: 9509
	Spring25UnlockAnimDone,
	// Token: 0x04002526 RID: 9510
	OnSetGameModeDataDone,
	// Token: 0x04002527 RID: 9511
	OnBossRushBuffViewOpened,
	// Token: 0x04002528 RID: 9512
	OnTutorialTipExistChanged,
	// Token: 0x04002529 RID: 9513
	OnTutorialUpdate,
	// Token: 0x0400252A RID: 9514
	AddLevelLoadingTimeDilationTag,
	// Token: 0x0400252B RID: 9515
	RemoveLevelLoadingTimeDilationTag,
	// Token: 0x0400252C RID: 9516
	RogueLevelLoadingLockTimeDilation,
	// Token: 0x0400252D RID: 9517
	RogueLevelLoadingUnlockTimeDilation,
	// Token: 0x0400252E RID: 9518
	BusinessInvestResult,
	// Token: 0x0400252F RID: 9519
	SetDelegationResultData,
	// Token: 0x04002530 RID: 9520
	PopularityChange,
	// Token: 0x04002531 RID: 9521
	OpenTipsTravelView,
	// Token: 0x04002532 RID: 9522
	OpenTipsShopView,
	// Token: 0x04002533 RID: 9523
	UnlockMoonChasingData,
	// Token: 0x04002534 RID: 9524
	RefreshCorniceMeetingRedDot,
	// Token: 0x04002535 RID: 9525
	OnClickActivityCorniceMeetingTab,
	// Token: 0x04002536 RID: 9526
	OnPlayerFollowerConfigChanged,
	// Token: 0x04002537 RID: 9527
	OnPlayerFollowerPossessed,
	// Token: 0x04002538 RID: 9528
	OnPlayerFollowerUnPossessed,
	// Token: 0x04002539 RID: 9529
	OnPlayerFollowerEnableChange,
	// Token: 0x0400253A RID: 9530
	OnFollowerAdd,
	// Token: 0x0400253B RID: 9531
	BuildAnimFinish,
	// Token: 0x0400253C RID: 9532
	ConditionUnlockRole,
	// Token: 0x0400253D RID: 9533
	TakenRewardTargetData,
	// Token: 0x0400253E RID: 9534
	RefreshRewardTargetData,
	// Token: 0x0400253F RID: 9535
	RefreshDelegate,
	// Token: 0x04002540 RID: 9536
	ElevatorMove,
	// Token: 0x04002541 RID: 9537
	OnHighSpeedModeChanged,
	// Token: 0x04002542 RID: 9538
	SlowStreamingBySoar,
	// Token: 0x04002543 RID: 9539
	OnDropDownListVisibleChanged,
	// Token: 0x04002544 RID: 9540
	OnGlobalFootstepMaterialChange,
	// Token: 0x04002545 RID: 9541
	OnForbidWeatherStateChange,
	// Token: 0x04002546 RID: 9542
	OnPortalRegister,
	// Token: 0x04002547 RID: 9543
	OnPortalUnRegister,
	// Token: 0x04002548 RID: 9544
	OnRolePassPortalBeforeTeleport,
	// Token: 0x04002549 RID: 9545
	OnRolePassPortalAfterTeleport,
	// Token: 0x0400254A RID: 9546
	OnEnterVehicle,
	// Token: 0x0400254B RID: 9547
	OnLeaveVehicle,
	// Token: 0x0400254C RID: 9548
	OnVehicleBeenEntered,
	// Token: 0x0400254D RID: 9549
	OnVehicleBeenLeaved,
	// Token: 0x0400254E RID: 9550
	OnEnterVehicleAtOnceResponse,
	// Token: 0x0400254F RID: 9551
	OnLeaveVehicleAtOnceResponse,
	// Token: 0x04002550 RID: 9552
	OnEnterVehicleRideSharing,
	// Token: 0x04002551 RID: 9553
	OnLeaveVehicleRideSharing,
	// Token: 0x04002552 RID: 9554
	OnChangeRideSharingPassenger,
	// Token: 0x04002553 RID: 9555
	OnRemoveRideSharingPassenger,
	// Token: 0x04002554 RID: 9556
	OnChangeRideSharingPassengerResponse,
	// Token: 0x04002555 RID: 9557
	OnRemoveRideSharingPassengerResponse,
	// Token: 0x04002556 RID: 9558
	OnChangeRideSharingPassengerNotify,
	// Token: 0x04002557 RID: 9559
	OnRemoveRideSharingPassengerNotify,
	// Token: 0x04002558 RID: 9560
	OnSpecialVehicleShareNotify,
	// Token: 0x04002559 RID: 9561
	OnMovieMotorRideSharingModeChangeRequest,
	// Token: 0x0400255A RID: 9562
	OnMovieMotorRideSharingModeChangeResponse,
	// Token: 0x0400255B RID: 9563
	OnVehicleSkillEnableChanged,
	// Token: 0x0400255C RID: 9564
	OnVehicleSkillUsableCountChanged,
	// Token: 0x0400255D RID: 9565
	OnBeforeAttachVehicle,
	// Token: 0x0400255E RID: 9566
	OnAfterAttachVehicle,
	// Token: 0x0400255F RID: 9567
	OnWaterfallMoveBegin,
	// Token: 0x04002560 RID: 9568
	OnWaterfallMoveEnd,
	// Token: 0x04002561 RID: 9569
	OnVehicleDriverChange,
	// Token: 0x04002562 RID: 9570
	OnVehicleActivate,
	// Token: 0x04002563 RID: 9571
	OnCoBathSwitchFirstPlayerView,
	// Token: 0x04002564 RID: 9572
	OnChangeModuleDebugLevel,
	// Token: 0x04002565 RID: 9573
	OnBattleLinkStop,
	// Token: 0x04002566 RID: 9574
	OnBattleLinkRestart,
	// Token: 0x04002567 RID: 9575
	OnBattleLinkStatusChanged,
	// Token: 0x04002568 RID: 9576
	OnNewLinkStatusChanged,
	// Token: 0x04002569 RID: 9577
	OnBattleLinkToggle,
	// Token: 0x0400256A RID: 9578
	OnMoraleActiveChanged,
	// Token: 0x0400256B RID: 9579
	OnMoraleExpChanged,
	// Token: 0x0400256C RID: 9580
	OnMoraleTempExpChanged,
	// Token: 0x0400256D RID: 9581
	OnMoraleSumLevelChanged,
	// Token: 0x0400256E RID: 9582
	OnMoraleIndomitableLevelChanged,
	// Token: 0x0400256F RID: 9583
	OnMoralePlayIndomitableLevelAnim,
	// Token: 0x04002570 RID: 9584
	OnMoraleTempExpViewVisibleChanged,
	// Token: 0x04002571 RID: 9585
	OnMoraleBattleFail,
	// Token: 0x04002572 RID: 9586
	OnMarkActorInFighting,
	// Token: 0x04002573 RID: 9587
	OnPunishMarkStateChanged,
	// Token: 0x04002574 RID: 9588
	OnInputSettingResponse,
	// Token: 0x04002575 RID: 9589
	OnInputSettingUpdateNotify,
	// Token: 0x04002576 RID: 9590
	RecallActivityInfoUpdate,
	// Token: 0x04002577 RID: 9591
	ActivityDirectTrainDataUpdate,
	// Token: 0x04002578 RID: 9592
	ActivityDirectTrainRedDotUpdate,
	// Token: 0x04002579 RID: 9593
	OnActivityDirectTrainProSetActive,
	// Token: 0x0400257A RID: 9594
	OnScratchTicketConditionRefresh,
	// Token: 0x0400257B RID: 9595
	OnSelectRoleDreamDungeon,
	// Token: 0x0400257C RID: 9596
	OnMailBindInfoResponse,
	// Token: 0x0400257D RID: 9597
	OnMailBindRewardResponse,
	// Token: 0x0400257E RID: 9598
	OnMailBindResponse,
	// Token: 0x0400257F RID: 9599
	OnMailBindInfoNotify,
	// Token: 0x04002580 RID: 9600
	RefreshMailBindRedDot,
	// Token: 0x04002581 RID: 9601
	CharacterWeaponLoaded,
	// Token: 0x04002582 RID: 9602
	FightWeaponSkinChange,
	// Token: 0x04002583 RID: 9603
	EquipWeaponSkin,
	// Token: 0x04002584 RID: 9604
	UninstallWeaponSkin,
	// Token: 0x04002585 RID: 9605
	OnRoleFlyEquipNotify,
	// Token: 0x04002586 RID: 9606
	OnRoleFlyEquipChangeNotify,
	// Token: 0x04002587 RID: 9607
	OnFlySkinEquipResponse,
	// Token: 0x04002588 RID: 9608
	OnFlySkinUnLoadResponse,
	// Token: 0x04002589 RID: 9609
	OnFlySkinAllUnLoadResponse,
	// Token: 0x0400258A RID: 9610
	OnFlySkinEquipToAllRoleResponse,
	// Token: 0x0400258B RID: 9611
	OnRoleFlySkinChange,
	// Token: 0x0400258C RID: 9612
	OnFlyEquipAddNotify,
	// Token: 0x0400258D RID: 9613
	RefreshFlySkinTabRedDot,
	// Token: 0x0400258E RID: 9614
	RefreshFlySkinChildTabRed,
	// Token: 0x0400258F RID: 9615
	OnSkinRootViewDestroy,
	// Token: 0x04002590 RID: 9616
	OnUpdateAreaAlertEnable,
	// Token: 0x04002591 RID: 9617
	OnUpdateAreaAlertValue,
	// Token: 0x04002592 RID: 9618
	OnUpdateAreaAlertUiEnable,
	// Token: 0x04002593 RID: 9619
	OnUpdateAreaAlertUiVisible,
	// Token: 0x04002594 RID: 9620
	LevelPlayReportSimpleUpdate,
	// Token: 0x04002595 RID: 9621
	LevelPlayReportDetailUpdate,
	// Token: 0x04002596 RID: 9622
	LevelPlayStateDetailUpdate,
	// Token: 0x04002597 RID: 9623
	OnBigStuffedDollGameStageUpdate,
	// Token: 0x04002598 RID: 9624
	OnBigStuffedDollArrowStayAreaUpdate,
	// Token: 0x04002599 RID: 9625
	OnBigStuffedDollRingItemSequencePlayStart,
	// Token: 0x0400259A RID: 9626
	OnBigStuffedDollRingItemSequencePlayEnd,
	// Token: 0x0400259B RID: 9627
	OnRacingBetsDataRefresh,
	// Token: 0x0400259C RID: 9628
	OnRacingBetsBettingInfoUpdate,
	// Token: 0x0400259D RID: 9629
	OnRacingBetsPlayerInfoUpdate,
	// Token: 0x0400259E RID: 9630
	OnRacingBetsDangoOddsUpdate,
	// Token: 0x0400259F RID: 9631
	OnRacingBetsRewardRefresh,
	// Token: 0x040025A0 RID: 9632
	OnRacingBetsDangoOrderRefresh,
	// Token: 0x040025A1 RID: 9633
	OnRacingBetsDangoOrderEnd,
	// Token: 0x040025A2 RID: 9634
	OnRacingBetsDangoRoundStart,
	// Token: 0x040025A3 RID: 9635
	OnRacingBetsDiceAnim,
	// Token: 0x040025A4 RID: 9636
	OnRacingBetsDiceAnimEnd,
	// Token: 0x040025A5 RID: 9637
	OnRacingBetsDungeonDangoRankChange,
	// Token: 0x040025A6 RID: 9638
	OnRacingBetsLegMatchEnd,
	// Token: 0x040025A7 RID: 9639
	OnRacingBetsRedDotUpdate,
	// Token: 0x040025A8 RID: 9640
	OnRacingBetsPushBulletScreen,
	// Token: 0x040025A9 RID: 9641
	OnRacingBetsViewAfterShow,
	// Token: 0x040025AA RID: 9642
	OnRacingBetsReplay,
	// Token: 0x040025AB RID: 9643
	OnFloroRanchNextDayTaskRefresh,
	// Token: 0x040025AC RID: 9644
	OnFloroRanchInsertTask,
	// Token: 0x040025AD RID: 9645
	OnFloroRanchStageInfoRefresh,
	// Token: 0x040025AE RID: 9646
	OnFloroRanchCardEntityCountChange,
	// Token: 0x040025AF RID: 9647
	FloroRanchDataRedDot,
	// Token: 0x040025B0 RID: 9648
	FloroRanchRaceRedDot,
	// Token: 0x040025B1 RID: 9649
	FloroRanchSkillChange,
	// Token: 0x040025B2 RID: 9650
	FloroRanchSkillRedDotRefresh,
	// Token: 0x040025B3 RID: 9651
	FloroRanchSettlement,
	// Token: 0x040025B4 RID: 9652
	FloroRanchWeeklySettlement,
	// Token: 0x040025B5 RID: 9653
	FloroRanchSubInsHistoryUpdate,
	// Token: 0x040025B6 RID: 9654
	OnFloroRanchDebugInfoRefresh,
	// Token: 0x040025B7 RID: 9655
	OnFloroRanchSuccessSettleViewOpen,
	// Token: 0x040025B8 RID: 9656
	OnFloroRanchStageStartTaskBeforeFinish,
	// Token: 0x040025B9 RID: 9657
	FishingRefreshBackpackData,
	// Token: 0x040025BA RID: 9658
	FishingBackpackDeliverableRefresh,
	// Token: 0x040025BB RID: 9659
	FishingShipSkinChangeSuccess,
	// Token: 0x040025BC RID: 9660
	DriveFishingShipStateChanged,
	// Token: 0x040025BD RID: 9661
	FishingRefreshQuestView,
	// Token: 0x040025BE RID: 9662
	FishingRefreshDockId,
	// Token: 0x040025BF RID: 9663
	OnRefreshTempFishingPointNum,
	// Token: 0x040025C0 RID: 9664
	FishingEntrustStartShowTrackText,
	// Token: 0x040025C1 RID: 9665
	FishingEntrustEndShowTrackText,
	// Token: 0x040025C2 RID: 9666
	OnFishingSailing,
	// Token: 0x040025C3 RID: 9667
	FishingRefreshHandBookRewardView,
	// Token: 0x040025C4 RID: 9668
	FishingShipDataRefresh,
	// Token: 0x040025C5 RID: 9669
	FishingPointFinish,
	// Token: 0x040025C6 RID: 9670
	OnFishingQteStageUpdate,
	// Token: 0x040025C7 RID: 9671
	OnFishingQteAreaChange,
	// Token: 0x040025C8 RID: 9672
	OnFishingTechNodeRefresh,
	// Token: 0x040025C9 RID: 9673
	OnFishingTechNodeRedDotRefresh,
	// Token: 0x040025CA RID: 9674
	OnFishingRoleTechRefresh,
	// Token: 0x040025CB RID: 9675
	FishingTimeLimitRewardListRefresh,
	// Token: 0x040025CC RID: 9676
	FishingTimeLimitRewardProgressRefresh,
	// Token: 0x040025CD RID: 9677
	FishingTimeLimitShopRefresh,
	// Token: 0x040025CE RID: 9678
	FishingShipSkinClick,
	// Token: 0x040025CF RID: 9679
	FishingTechViewComeBack,
	// Token: 0x040025D0 RID: 9680
	FishingRoleTechViewOpened,
	// Token: 0x040025D1 RID: 9681
	FishingDockyardItemTipsShown,
	// Token: 0x040025D2 RID: 9682
	FishingQteBtnHitValidArea,
	// Token: 0x040025D3 RID: 9683
	OnFishingQteScoreReachedMaximum,
	// Token: 0x040025D4 RID: 9684
	FishingBackpackBtnStateChange,
	// Token: 0x040025D5 RID: 9685
	OnTreasureCompassUnitVisibleChange,
	// Token: 0x040025D6 RID: 9686
	OnFishingBackpackQuickSellToggleStateChange,
	// Token: 0x040025D7 RID: 9687
	PlayerSoarChanged,
	// Token: 0x040025D8 RID: 9688
	FilterCriteriaChanged,
	// Token: 0x040025D9 RID: 9689
	EntityToLoadFilterCreated,
	// Token: 0x040025DA RID: 9690
	EntityToLoadFilterDestroyed,
	// Token: 0x040025DB RID: 9691
	EntityToLoadParamUpdated,
	// Token: 0x040025DC RID: 9692
	VehicleInputLayerPress,
	// Token: 0x040025DD RID: 9693
	VehicleInputLayerRelease,
	// Token: 0x040025DE RID: 9694
	SkillLongPressStart,
	// Token: 0x040025DF RID: 9695
	SkillLongPressEnd,
	// Token: 0x040025E0 RID: 9696
	CheckClientEvent,
	// Token: 0x040025E1 RID: 9697
	StartMoveWithSpline,
	// Token: 0x040025E2 RID: 9698
	OnPhonographSwitchMusic,
	// Token: 0x040025E3 RID: 9699
	OnPhonographSelectDisable,
	// Token: 0x040025E4 RID: 9700
	OnPhonographPlayTick,
	// Token: 0x040025E5 RID: 9701
	OnPhonographPlayStop,
	// Token: 0x040025E6 RID: 9702
	OnPhonographRemoveNewTag,
	// Token: 0x040025E7 RID: 9703
	OnPhonographSetBgm,
	// Token: 0x040025E8 RID: 9704
	OnPhonographMusicForceRefresh,
	// Token: 0x040025E9 RID: 9705
	RefreshActivityEntranceScroller,
	// Token: 0x040025EA RID: 9706
	RefreshActivityEntranceItemContent,
	// Token: 0x040025EB RID: 9707
	FarmGoldRefreshRewardRedDot,
	// Token: 0x040025EC RID: 9708
	EntityCampModify,
	// Token: 0x040025ED RID: 9709
	MobileGamepadDisconnect,
	// Token: 0x040025EE RID: 9710
	DisableCustomInputData,
	// Token: 0x040025EF RID: 9711
	EnableCacheCustomInputData,
	// Token: 0x040025F0 RID: 9712
	EnableActionRecord,
	// Token: 0x040025F1 RID: 9713
	SolarSpeedClickRewardTab,
	// Token: 0x040025F2 RID: 9714
	SolarSpeedRewarded,
	// Token: 0x040025F3 RID: 9715
	SolarSpeedSubViewOnRefreshView,
	// Token: 0x040025F4 RID: 9716
	ShipTowerTeamPanelShown,
	// Token: 0x040025F5 RID: 9717
	OnCharacterMorphTypeChanged,
	// Token: 0x040025F6 RID: 9718
	OnBeforeCharacterMorphTypeChanged,
	// Token: 0x040025F7 RID: 9719
	OnCharacterSetMaster,
	// Token: 0x040025F8 RID: 9720
	OnSwitchSelfCenteredMode,
	// Token: 0x040025F9 RID: 9721
	OnGravityFlipAnimFinish,
	// Token: 0x040025FA RID: 9722
	BabelTowerRefreshLevelInfo,
	// Token: 0x040025FB RID: 9723
	BabelTowerRefreshQuestState,
	// Token: 0x040025FC RID: 9724
	BabelTowerDifficultyLevelClick,
	// Token: 0x040025FD RID: 9725
	BabelTowerLevelClick,
	// Token: 0x040025FE RID: 9726
	BabelTowerLevelRedDotUpdate,
	// Token: 0x040025FF RID: 9727
	BabelTowerDifficultyRedDotUpdate,
	// Token: 0x04002600 RID: 9728
	OnBabelActivityInstInfoUpdate,
	// Token: 0x04002601 RID: 9729
	OnAbyssRoleInfoUpdate,
	// Token: 0x04002602 RID: 9730
	OnAbyssPluginInfoUpdate,
	// Token: 0x04002603 RID: 9731
	OnAbyssRewardStateUpdate,
	// Token: 0x04002604 RID: 9732
	RefreshAbyssRewardRedDot,
	// Token: 0x04002605 RID: 9733
	OnAbyssUnlockChallengeStateUpdate,
	// Token: 0x04002606 RID: 9734
	OnAbyssChallengeResult,
	// Token: 0x04002607 RID: 9735
	OnAbyssLikeChange,
	// Token: 0x04002608 RID: 9736
	OnAbyssFormationUpdate,
	// Token: 0x04002609 RID: 9737
	OnAbyssAddRole,
	// Token: 0x0400260A RID: 9738
	OnAbyssDangoLevelUp,
	// Token: 0x0400260B RID: 9739
	OnAbyssPluginItemEquip,
	// Token: 0x0400260C RID: 9740
	OnAbyssPluginRecovery,
	// Token: 0x0400260D RID: 9741
	RefreshAbyssDevelopRedDot,
	// Token: 0x0400260E RID: 9742
	OnAbyssDangoSelect,
	// Token: 0x0400260F RID: 9743
	RefreshAbyssDangoRedDot,
	// Token: 0x04002610 RID: 9744
	OnAbyssRoomInfoUpdate,
	// Token: 0x04002611 RID: 9745
	OnAbyssFirstRoomEnter,
	// Token: 0x04002612 RID: 9746
	OnAbyssRoomPreloadFinished,
	// Token: 0x04002613 RID: 9747
	RefreshFormationDango,
	// Token: 0x04002614 RID: 9748
	ShowBadDangoTip,
	// Token: 0x04002615 RID: 9749
	OnAbyssPluginDangoSelect,
	// Token: 0x04002616 RID: 9750
	OnAbyssTeamBtnVisibleRefresh,
	// Token: 0x04002617 RID: 9751
	OnAbyssPluginEquipAttrRefresh,
	// Token: 0x04002618 RID: 9752
	PreDownloadStateUpdate,
	// Token: 0x04002619 RID: 9753
	OnPreDownloadAvailableUpdate,
	// Token: 0x0400261A RID: 9754
	InviteNewbieEntered,
	// Token: 0x0400261B RID: 9755
	InviteNewbieInviteCodeChanged,
	// Token: 0x0400261C RID: 9756
	RefreshCommonH5ActivityRedDot,
	// Token: 0x0400261D RID: 9757
	OnCiacconaAvgReChoose,
	// Token: 0x0400261E RID: 9758
	OnCiacconaReChooseConfirm,
	// Token: 0x0400261F RID: 9759
	OnCiacconaReChooseCancel,
	// Token: 0x04002620 RID: 9760
	NotifyBtCiacconaChapterFinish,
	// Token: 0x04002621 RID: 9761
	OnCiacconaChapterFinish,
	// Token: 0x04002622 RID: 9762
	OnCiacconaChapterDataUpdate,
	// Token: 0x04002623 RID: 9763
	OnCiacconaInspirationDataUpdate,
	// Token: 0x04002624 RID: 9764
	OnCiacconaEndingDataUpdate,
	// Token: 0x04002625 RID: 9765
	OnCiacconaRewardDataUpdate,
	// Token: 0x04002626 RID: 9766
	OnCiacconaActivityStateUpdate,
	// Token: 0x04002627 RID: 9767
	OnCiacconaAvgInspirationChoiceShow,
	// Token: 0x04002628 RID: 9768
	OnCiacconaChapterFirstStart,
	// Token: 0x04002629 RID: 9769
	OnCiacconaChapterRestart,
	// Token: 0x0400262A RID: 9770
	OnTermExplanationViewOpening,
	// Token: 0x0400262B RID: 9771
	OnTermExplanationViewBeforeStart,
	// Token: 0x0400262C RID: 9772
	OnTermExplanationViewClosed,
	// Token: 0x0400262D RID: 9773
	OnTermExplanationRegisteredTextContentChange,
	// Token: 0x0400262E RID: 9774
	OnQuestReviewMainViewBeforeHide,
	// Token: 0x0400262F RID: 9775
	OnOpenQuestReviewDetail,
	// Token: 0x04002630 RID: 9776
	ResDownLoadStateRefresh,
	// Token: 0x04002631 RID: 9777
	RefreshRound,
	// Token: 0x04002632 RID: 9778
	OwnBattleStatusChange,
	// Token: 0x04002633 RID: 9779
	OwnBattleAttrChange,
	// Token: 0x04002634 RID: 9780
	OwnHandCardAdd,
	// Token: 0x04002635 RID: 9781
	OwnHandCardRemove,
	// Token: 0x04002636 RID: 9782
	OwnHandCardAddFourCost,
	// Token: 0x04002637 RID: 9783
	OpponentBattleStatusChange,
	// Token: 0x04002638 RID: 9784
	OpponentBattleAttrChange,
	// Token: 0x04002639 RID: 9785
	ReplaceCardFinish,
	// Token: 0x0400263A RID: 9786
	OwnCardLibraryChange,
	// Token: 0x0400263B RID: 9787
	OpponentHandCardChange,
	// Token: 0x0400263C RID: 9788
	OpponentCardLibraryChange,
	// Token: 0x0400263D RID: 9789
	PhantomArenaTriggerSkillEffect,
	// Token: 0x0400263E RID: 9790
	NotifyCardTaskData,
	// Token: 0x0400263F RID: 9791
	DiscardCardPanelActive,
	// Token: 0x04002640 RID: 9792
	ReserveCardPanelActive,
	// Token: 0x04002641 RID: 9793
	RefreshBattleCardNum,
	// Token: 0x04002642 RID: 9794
	RefreshHandCardState,
	// Token: 0x04002643 RID: 9795
	PhantomArenaCardAttrRefresh,
	// Token: 0x04002644 RID: 9796
	PhantomArenaCardFactorsRefresh,
	// Token: 0x04002645 RID: 9797
	OnPhantomArenaCardUnlock,
	// Token: 0x04002646 RID: 9798
	OnPhantomArenaCardOutlookUnlock,
	// Token: 0x04002647 RID: 9799
	NotifyBattleCardChange,
	// Token: 0x04002648 RID: 9800
	OnPhantomArenaTaskAwardUpdate,
	// Token: 0x04002649 RID: 9801
	OnPhantomArenaMasterInfoUpdate,
	// Token: 0x0400264A RID: 9802
	OnPhantomArenaCardRewardUpdate,
	// Token: 0x0400264B RID: 9803
	OnPhantomArenaBadgeRewardUpdate,
	// Token: 0x0400264C RID: 9804
	OnPhantomArenaChallengeUpdate,
	// Token: 0x0400264D RID: 9805
	OnPhantomArenaRoleRewardUpdate,
	// Token: 0x0400264E RID: 9806
	OnPhantomArenaShopOpen,
	// Token: 0x0400264F RID: 9807
	OnPhantomArenaBattleLoadingHide,
	// Token: 0x04002650 RID: 9808
	OnPhantomArenaBattleDamageAccumulateEnd,
	// Token: 0x04002651 RID: 9809
	PhantomArenaStartTurnResult,
	// Token: 0x04002652 RID: 9810
	OnPhantomArenaHandCardsShowHideChange,
	// Token: 0x04002653 RID: 9811
	OnPhantomArenaCardDetailShowHideChange,
	// Token: 0x04002654 RID: 9812
	OnPhantomArenaBattleCardNumChange,
	// Token: 0x04002655 RID: 9813
	OnPhantomArenaChildViewOpen,
	// Token: 0x04002656 RID: 9814
	OnHandAreaAddCard,
	// Token: 0x04002657 RID: 9815
	GamepadTriggerCardInfo,
	// Token: 0x04002658 RID: 9816
	PhantomBattleBoardSettleNotify,
	// Token: 0x04002659 RID: 9817
	OpponentSealFieldChange,
	// Token: 0x0400265A RID: 9818
	OwnSealRecycleChange,
	// Token: 0x0400265B RID: 9819
	OnFieldCardSkillActivated,
	// Token: 0x0400265C RID: 9820
	CumulativeShopTaskRefresh,
	// Token: 0x0400265D RID: 9821
	CumulativeShopTaskViewDataRefresh,
	// Token: 0x0400265E RID: 9822
	RefreshPlayerInfoVisible,
	// Token: 0x0400265F RID: 9823
	UpdateRayTraceReflection,
	// Token: 0x04002660 RID: 9824
	OnEntityBeSlashAim,
	// Token: 0x04002661 RID: 9825
	OnSelectHintChange,
	// Token: 0x04002662 RID: 9826
	OnInEntityInteractRangeChange,
	// Token: 0x04002663 RID: 9827
	OnInteractionSpotStateChange,
	// Token: 0x04002664 RID: 9828
	SetInteractSpotOccupied,
	// Token: 0x04002665 RID: 9829
	OnInteractionLongPressProgressChange,
	// Token: 0x04002666 RID: 9830
	RefreshBeginnerCarnivalTask,
	// Token: 0x04002667 RID: 9831
	NpcAnimStateSwitchBegin,
	// Token: 0x04002668 RID: 9832
	NpcAnimStateSwitchEnd,
	// Token: 0x04002669 RID: 9833
	SoarTypeChange,
	// Token: 0x0400266A RID: 9834
	OnDemoInteractiveActorAdd,
	// Token: 0x0400266B RID: 9835
	OnDemoInteractiveActorRemove,
	// Token: 0x0400266C RID: 9836
	OnDemoInteractiveActorMemberUpdated,
	// Token: 0x0400266D RID: 9837
	OnDemoInteractiveActorMemberCalled,
	// Token: 0x0400266E RID: 9838
	TuningStandUpdate,
	// Token: 0x0400266F RID: 9839
	TuningStandSuccess,
	// Token: 0x04002670 RID: 9840
	TuningStandSuccessShowStart,
	// Token: 0x04002671 RID: 9841
	TuningStandSuccessShowEnd,
	// Token: 0x04002672 RID: 9842
	TuningStandBubbleUpdate,
	// Token: 0x04002673 RID: 9843
	TuningStandBubbleEnd,
	// Token: 0x04002674 RID: 9844
	TuningStandTooLongTime,
	// Token: 0x04002675 RID: 9845
	TuningStandOnLinkMiss,
	// Token: 0x04002676 RID: 9846
	OnKingShipAttrItemSetShow,
	// Token: 0x04002677 RID: 9847
	OnKingShipAllAttrItemShown,
	// Token: 0x04002678 RID: 9848
	OnRefreshBeginnerCarnivalChoseRole,
	// Token: 0x04002679 RID: 9849
	OnMontageRemain,
	// Token: 0x0400267A RID: 9850
	OnGeneratedMonsterPatrolGroup,
	// Token: 0x0400267B RID: 9851
	OnGroupAiSyncTagAdded,
	// Token: 0x0400267C RID: 9852
	OnStateTaskFinished,
	// Token: 0x0400267D RID: 9853
	OnStateActivated,
	// Token: 0x0400267E RID: 9854
	OnForeverTimeDilationAdd,
	// Token: 0x0400267F RID: 9855
	OnForeverTimeDilationRemove,
	// Token: 0x04002680 RID: 9856
	TrapDefenseBuildingDevelopSelectUpdate,
	// Token: 0x04002681 RID: 9857
	TrapDefenseBuildingBottomSelectUpdate,
	// Token: 0x04002682 RID: 9858
	TrapDefenseBuildingPreviewSelectUpdate,
	// Token: 0x04002683 RID: 9859
	TrapDefenseOnDevelopUpdate,
	// Token: 0x04002684 RID: 9860
	TrapDefenseOnDevelopResetAll,
	// Token: 0x04002685 RID: 9861
	TrapDefenseOnSlotUpdate,
	// Token: 0x04002686 RID: 9862
	TrapDefenseOnBranchUpdate,
	// Token: 0x04002687 RID: 9863
	TrapDefenseActivityDataUpdate,
	// Token: 0x04002688 RID: 9864
	TrapDefenseLevelDataListUpdate,
	// Token: 0x04002689 RID: 9865
	TrapDefenseBdBuffListUpdate,
	// Token: 0x0400268A RID: 9866
	TrapDefenseBdBuffAllUpdate,
	// Token: 0x0400268B RID: 9867
	TrapDefenseRewardUpdate,
	// Token: 0x0400268C RID: 9868
	TrapDefenseTalentTreeUpdate,
	// Token: 0x0400268D RID: 9869
	TrapDefenseShopRefresh,
	// Token: 0x0400268E RID: 9870
	TrapDefenseBuildingDevelopDetailUpdate,
	// Token: 0x0400268F RID: 9871
	TrapDefenseBdBuffSelectChange,
	// Token: 0x04002690 RID: 9872
	RedDotUpdateTrapDefenseFixedReward,
	// Token: 0x04002691 RID: 9873
	RedDotUpdateTrapDefenseLimitReward,
	// Token: 0x04002692 RID: 9874
	RedDotUpdateTrapDefenseTalentTree,
	// Token: 0x04002693 RID: 9875
	RedDotUpdateTrapDefenseBdBuffNewUnlock,
	// Token: 0x04002694 RID: 9876
	RedDotUpdateTrapDefenseLevelModeLevelReachOpenTime,
	// Token: 0x04002695 RID: 9877
	RedDotUpdateTrapDefenseRougeModeLevelReachOpenTime,
	// Token: 0x04002696 RID: 9878
	RedDotUpdateTrapDefenseRougeModeOpen,
	// Token: 0x04002697 RID: 9879
	TrapDefenseLevelUpPointUpdate,
	// Token: 0x04002698 RID: 9880
	TrapDefenseInventoryDataUpdate,
	// Token: 0x04002699 RID: 9881
	TrapDefenseBuildingDevelopDetailInfoItemUpdate,
	// Token: 0x0400269A RID: 9882
	TrapDefensePreviewMachine,
	// Token: 0x0400269B RID: 9883
	TrapDefenseBuildingDevelopMainViewStart,
	// Token: 0x0400269C RID: 9884
	TrapDefenseMainLevelViewOpen,
	// Token: 0x0400269D RID: 9885
	OnCommonKeySettingKeyChange,
	// Token: 0x0400269E RID: 9886
	RefreshLifePointDrawChallengeRedDot,
	// Token: 0x0400269F RID: 9887
	RefreshLifePointDrawGroupRedDot,
	// Token: 0x040026A0 RID: 9888
	OnChangeBasedPlatform,
	// Token: 0x040026A1 RID: 9889
	ForceClientTravelModify,
	// Token: 0x040026A2 RID: 9890
	GreatSwordLevelPlayUiInfoUpdated,
	// Token: 0x040026A3 RID: 9891
	GreatSwordLevelSelectedComplete,
	// Token: 0x040026A4 RID: 9892
	GreatSwordLevelRefreshUI,
	// Token: 0x040026A5 RID: 9893
	OnSelectActivityFunPlayChallengeItem,
	// Token: 0x040026A6 RID: 9894
	RefreshActivityFunPlayRedDot,
	// Token: 0x040026A7 RID: 9895
	ActivityFunPlayInfoRefresh,
	// Token: 0x040026A8 RID: 9896
	RefreshLineCrossGroupRedDot,
	// Token: 0x040026A9 RID: 9897
	RefreshLineCrossChallengeRedDot,
	// Token: 0x040026AA RID: 9898
	MoonSignRewardRefresh,
	// Token: 0x040026AB RID: 9899
	SeekTraceMoveActionInput,
	// Token: 0x040026AC RID: 9900
	SeekTraceMoveAxisInput,
	// Token: 0x040026AD RID: 9901
	SeekTraceSelectItemInput,
	// Token: 0x040026AE RID: 9902
	SeekTraceResetItemInput,
	// Token: 0x040026AF RID: 9903
	OnOnlyAllowFightInputStateChanged,
	// Token: 0x040026B0 RID: 9904
	OnVisionIntensifyViewShow,
	// Token: 0x040026B1 RID: 9905
	VersionCheckRefresh,
	// Token: 0x040026B2 RID: 9906
	CheckMusicBeatsEvent,
	// Token: 0x040026B3 RID: 9907
	OnVisionRecommendFetterGroupSelected,
	// Token: 0x040026B4 RID: 9908
	RoleDevTargetRoleIdChange,
	// Token: 0x040026B5 RID: 9909
	RoleDevelopNeedItemsChanged,
	// Token: 0x040026B6 RID: 9910
	OnRoleDevViewOpen,
	// Token: 0x040026B7 RID: 9911
	BtnStateUpdate,
	// Token: 0x040026B8 RID: 9912
	OnArtemisStateRefresh,
	// Token: 0x040026B9 RID: 9913
	OnArtemisQteAreaChange,
	// Token: 0x040026BA RID: 9914
	SurvivorsRogueShowBonusWaveTips,
	// Token: 0x040026BB RID: 9915
	SurvivorsRogueShowEndlessWaveTips,
	// Token: 0x040026BC RID: 9916
	SurvivorsRogueSwitchWaveTipsState,
	// Token: 0x040026BD RID: 9917
	SurvivorsRebindCommandView,
	// Token: 0x040026BE RID: 9918
	SurvivorsRogueWeaponGainUpdate,
	// Token: 0x040026BF RID: 9919
	SurvivorsRogueRoleGainUpdate,
	// Token: 0x040026C0 RID: 9920
	SurvivorsRogueBossTrackedMarkerUpdate,
	// Token: 0x040026C1 RID: 9921
	SurvivorsRoguePlayerEntityCreated,
	// Token: 0x040026C2 RID: 9922
	SurvivorsInstSettle,
	// Token: 0x040026C3 RID: 9923
	SurvivorsRogueTalentNodeUpdate,
	// Token: 0x040026C4 RID: 9924
	SurvivorsRogueLevelDetailViewEndlessToggleRefresh,
	// Token: 0x040026C5 RID: 9925
	SurvivorsRogueComboBuffShow,
	// Token: 0x040026C6 RID: 9926
	SurvivorsRoguePopViewRefresh,
	// Token: 0x040026C7 RID: 9927
	SurvivorsRogueWeaponDetailTabViewShow,
	// Token: 0x040026C8 RID: 9928
	QuestTreeNodeDataUpdate,
	// Token: 0x040026C9 RID: 9929
	RegionalTerminalGameplayPinUpdate,
	// Token: 0x040026CA RID: 9930
	AreaMapGroupIdChanged,
	// Token: 0x040026CB RID: 9931
	AnimCompActiveStateChange,
	// Token: 0x040026CC RID: 9932
	OnPrizeDrawingRewardStatusChanged,
	// Token: 0x040026CD RID: 9933
	OnPrizeDrawingQuestUpdated,
	// Token: 0x040026CE RID: 9934
	OnHonamiStoryLifeSupportChanged,
	// Token: 0x040026CF RID: 9935
	OnHonamiStoryRoleEquipChanged,
	// Token: 0x040026D0 RID: 9936
	OnHonamiScanMarkItemView,
	// Token: 0x040026D1 RID: 9937
	OnPickUpHonamiStoryItem,
	// Token: 0x040026D2 RID: 9938
	PlayerEntityStarted,
	// Token: 0x040026D3 RID: 9939
	PlayerEntityEnded,
	// Token: 0x040026D4 RID: 9940
	OnMarkItemAutoPilotTrackStateChange,
	// Token: 0x040026D5 RID: 9941
	OnAutoPilotStateChange,
	// Token: 0x040026D6 RID: 9942
	OnCircleStateChange,
	// Token: 0x040026D7 RID: 9943
	OnUpdateAutoPilotLine,
	// Token: 0x040026D8 RID: 9944
	MovieModeAspectOffsetUpdate,
	// Token: 0x040026D9 RID: 9945
	MovieModeAspectOffsetApply,
	// Token: 0x040026DA RID: 9946
	MovieModeHideUiChange,
	// Token: 0x040026DB RID: 9947
	OnPanoramicActive,
	// Token: 0x040026DC RID: 9948
	OnPanoramicDisable,
	// Token: 0x040026DD RID: 9949
	OnActivityNewPlayerSupportTrialRoleItemSelect,
	// Token: 0x040026DE RID: 9950
	OnActivityNewPlayerSupportTaskUpdate,
	// Token: 0x040026DF RID: 9951
	OnActivityNewPlayerSupportTrialRoleUpdate,
	// Token: 0x040026E0 RID: 9952
	OnActivityNewPlayerSupportCurTrialRoleChange,
	// Token: 0x040026E1 RID: 9953
	InfrastructureFireExpAdd,
	// Token: 0x040026E2 RID: 9954
	InfrastructureFireShopRefresh,
	// Token: 0x040026E3 RID: 9955
	InfrastructureActivityTaskDataUpdate,
	// Token: 0x040026E4 RID: 9956
	InfrastructureArchiveTaskUpdate,
	// Token: 0x040026E5 RID: 9957
	InfrastructurePhoneTaskUpdate,
	// Token: 0x040026E6 RID: 9958
	InfrastructureRoadNoticeUpdate,
	// Token: 0x040026E7 RID: 9959
	InfrastructureArchiveReadUpdate,
	// Token: 0x040026E8 RID: 9960
	InfrastructureTraceRoadUpdate,
	// Token: 0x040026E9 RID: 9961
	InfrastructureSelectRoadNetworkMark,
	// Token: 0x040026EA RID: 9962
	InfrastructureRoadDataUpdate,
	// Token: 0x040026EB RID: 9963
	InfrastructureShopRedDotUpdate,
	// Token: 0x040026EC RID: 9964
	VillageInfrActivityTaskDataUpdate,
	// Token: 0x040026ED RID: 9965
	VillageInfrTreeDataUpdate,
	// Token: 0x040026EE RID: 9966
	VillageInfrVillageDataUpdate,
	// Token: 0x040026EF RID: 9967
	VillageInfrScoreRewardDataUpdate,
	// Token: 0x040026F0 RID: 9968
	VillageInfrTreeFinishCondDataUpdate,
	// Token: 0x040026F1 RID: 9969
	VillageDeliverySuccess,
	// Token: 0x040026F2 RID: 9970
	VillageCompleteDelivery,
	// Token: 0x040026F3 RID: 9971
	VillageInfrMainViewOnSelect,
	// Token: 0x040026F4 RID: 9972
	CloseVillageInfrBuildInfoView,
	// Token: 0x040026F5 RID: 9973
	VillageInfrMissionItemClick,
	// Token: 0x040026F6 RID: 9974
	MotorDevelopRootUpdate,
	// Token: 0x040026F7 RID: 9975
	MotorDevelopInfoUpdate,
	// Token: 0x040026F8 RID: 9976
	MotorDevelopTechTreeUpdate,
	// Token: 0x040026F9 RID: 9977
	MotorDevelopTaskUpdate,
	// Token: 0x040026FA RID: 9978
	SelectMotorDevelopTab,
	// Token: 0x040026FB RID: 9979
	MotorDiyInfoUpdate,
	// Token: 0x040026FC RID: 9980
	MotorDiyFullOutlookUpdate,
	// Token: 0x040026FD RID: 9981
	MotorDiyOnSelectToggleClick,
	// Token: 0x040026FE RID: 9982
	MotorDiySceneItemUpdate,
	// Token: 0x040026FF RID: 9983
	MotorParkourFinishLap,
	// Token: 0x04002700 RID: 9984
	OnMotorSwitchMusic,
	// Token: 0x04002701 RID: 9985
	OnMotorMusicEnableStateChanged,
	// Token: 0x04002702 RID: 9986
	OnMotorMusicSortDragCancel,
	// Token: 0x04002703 RID: 9987
	OnMotorMusicPlayerShow,
	// Token: 0x04002704 RID: 9988
	OnMotorMusicForceRefresh,
	// Token: 0x04002705 RID: 9989
	OnPhoneMsgUpdateNotify,
	// Token: 0x04002706 RID: 9990
	OnUpdateShortMsgOptionData,
	// Token: 0x04002707 RID: 9991
	OnNewPhoneMsgNeedShowTips,
	// Token: 0x04002708 RID: 9992
	OnPhoneMsgChatShowChange,
	// Token: 0x04002709 RID: 9993
	OnPhoneMsgChatTabClick,
	// Token: 0x0400270A RID: 9994
	OnPhoneMsgDialogShowClick,
	// Token: 0x0400270B RID: 9995
	OnPhoneMsgBgShowClick,
	// Token: 0x0400270C RID: 9996
	OnPhoneMsgReadProgressUpdate,
	// Token: 0x0400270D RID: 9997
	OnPhoneMsgSetAsRead,
	// Token: 0x0400270E RID: 9998
	OnPhoneMsgSetReceived,
	// Token: 0x0400270F RID: 9999
	OnPhoneTipsClose,
	// Token: 0x04002710 RID: 10000
	PhoneMsgDialogAndBgUpdate,
	// Token: 0x04002711 RID: 10001
	PhoneMsgDialogAndBgRedDotUpdate,
	// Token: 0x04002712 RID: 10002
	OnWeatherCentralRedDotUpdate,
	// Token: 0x04002713 RID: 10003
	RoadBookTaskRefresh,
	// Token: 0x04002714 RID: 10004
	RoadBookMotorRefresh,
	// Token: 0x04002715 RID: 10005
	RoadBookTaskNavigationNext,
	// Token: 0x04002716 RID: 10006
	WheelTowerCycleChange,
	// Token: 0x04002717 RID: 10007
	GuessJokerCardUpdateTaskData,
	// Token: 0x04002718 RID: 10008
	GuessJokerFinishPokerPerformAction,
	// Token: 0x04002719 RID: 10009
	EncircleMapChange,
	// Token: 0x0400271A RID: 10010
	EncircleReset,
	// Token: 0x0400271B RID: 10011
	EncircleDataUpdate,
	// Token: 0x0400271C RID: 10012
	MotorArrowInitBoss,
	// Token: 0x0400271D RID: 10013
	MotorArrowSubLevelNotify,
	// Token: 0x0400271E RID: 10014
	MotorArrowBossStateChange,
	// Token: 0x0400271F RID: 10015
	MotorArrowBossCreate,
	// Token: 0x04002720 RID: 10016
	MotorArrowBossRemove,
	// Token: 0x04002721 RID: 10017
	MotorArrowScoreUpdate,
	// Token: 0x04002722 RID: 10018
	MotorArrowBossHpChange,
	// Token: 0x04002723 RID: 10019
	MotorArrowSave,
	// Token: 0x04002724 RID: 10020
	MotorArrowGameOver,
	// Token: 0x04002725 RID: 10021
	SpringManorFunctionOpenNotify,
	// Token: 0x04002726 RID: 10022
	SpringManorTaskUpdateNotify,
	// Token: 0x04002727 RID: 10023
	SpringManorAtmosphereUpdate,
	// Token: 0x04002728 RID: 10024
	FurnitureFunctionOpenNotify,
	// Token: 0x04002729 RID: 10025
	OnCoopLevelUpdate,
	// Token: 0x0400272A RID: 10026
	OnCoopSpUpdate,
	// Token: 0x0400272B RID: 10027
	OnCoopLevelToggleClick,
	// Token: 0x0400272C RID: 10028
	OnPinballRoleLevelUp,
	// Token: 0x0400272D RID: 10029
	OnPinballRoleStateChange,
	// Token: 0x0400272E RID: 10030
	OnPinballEntityHpChanged,
	// Token: 0x0400272F RID: 10031
	OnPinballFirstLaunch,
	// Token: 0x04002730 RID: 10032
	OnPinballFeverChange,
	// Token: 0x04002731 RID: 10033
	OnPinballScoreChanged,
	// Token: 0x04002732 RID: 10034
	OnPinballComboChanged,
	// Token: 0x04002733 RID: 10035
	OnPinballRoleChargeMax,
	// Token: 0x04002734 RID: 10036
	OnPinballRoleUseSkill,
	// Token: 0x04002735 RID: 10037
	OnPinballEntityCreated,
	// Token: 0x04002736 RID: 10038
	OnPinballWeaponLockChanged,
	// Token: 0x04002737 RID: 10039
	RefreshPinballRoleRedDot,
	// Token: 0x04002738 RID: 10040
	OnPinballBattleViewSwitchIn,
	// Token: 0x04002739 RID: 10041
	RefreshPinballWeaponRedDot,
	// Token: 0x0400273A RID: 10042
	OnRefreshKurotatoRoleRedDot,
	// Token: 0x0400273B RID: 10043
	OnRefreshKurotatoWeaponAndPropRedDot,
	// Token: 0x0400273C RID: 10044
	OnRefreshKurotatoNormalRewardData,
	// Token: 0x0400273D RID: 10045
	OnRefreshKurotatoLimitRewardData,
	// Token: 0x0400273E RID: 10046
	OnNpcBeenAttackedStart,
	// Token: 0x0400273F RID: 10047
	OnNpcBeenAttackedEnd,
	// Token: 0x04002740 RID: 10048
	OnNpcBeenImpactedStart,
	// Token: 0x04002741 RID: 10049
	OnNpcBeenImpactedEnd,
	// Token: 0x04002742 RID: 10050
	OnNpcSwitchTimetable,
	// Token: 0x04002743 RID: 10051
	OnNpcStopTimetable,
	// Token: 0x04002744 RID: 10052
	OnTsBasePlayerControllerReceiveSetupInputComponent,
	// Token: 0x04002745 RID: 10053
	OnTsBasePlayerControllerReceiveBeginPlay,
	// Token: 0x04002746 RID: 10054
	OnTsBasePlayerControllerReceiveDestroyed,
	// Token: 0x04002747 RID: 10055
	OnTsBasePlayerControllerReceiveTick,
	// Token: 0x04002748 RID: 10056
	OnTsBasePlayerControllerReceivedPlayer,
	// Token: 0x04002749 RID: 10057
	OnTsBasePlayerControllerInitInputHandle,
	// Token: 0x0400274A RID: 10058
	OnTsBasePlayerControllerAddInputBinding,
	// Token: 0x0400274B RID: 10059
	OnTsBasePlayerControllerClearInputBinding,
	// Token: 0x0400274C RID: 10060
	OnTsBasePlayerControllerOnSetupInputComponent,
	// Token: 0x0400274D RID: 10061
	OnTsBasePlayerControllerBindTouchHandle,
	// Token: 0x0400274E RID: 10062
	OnTsBasePlayerControllerInputAction,
	// Token: 0x0400274F RID: 10063
	OnTsBasePlayerControllerInputAxis,
	// Token: 0x04002750 RID: 10064
	OnTsBasePlayerControllerOnTouchBegin,
	// Token: 0x04002751 RID: 10065
	OnTsBasePlayerControllerOnTouchEnd,
	// Token: 0x04002752 RID: 10066
	OnTsBasePlayerControllerOnTouchMove,
	// Token: 0x04002753 RID: 10067
	OnTsBasePlayerControllerOnPressAnyKey,
	// Token: 0x04002754 RID: 10068
	OnTsBasePlayerControllerOnReleaseAnyKey,
	// Token: 0x04002755 RID: 10069
	OnTsBasePlayerControllerRemoveActionHandle,
	// Token: 0x04002756 RID: 10070
	OnTsBasePlayerControllerGetActionHandle,
	// Token: 0x04002757 RID: 10071
	OnTsBasePlayerControllerRemoveAxisHandle,
	// Token: 0x04002758 RID: 10072
	OnTsBasePlayerControllerGetAxisHandle,
	// Token: 0x04002759 RID: 10073
	OnTsBasePlayerControllerIsInTouch,
	// Token: 0x0400275A RID: 10074
	OnTsBasePlayerControllerSetIsPrintKeyName,
	// Token: 0x0400275B RID: 10075
	OnTsBasePlayerControllerTouchBegin,
	// Token: 0x0400275C RID: 10076
	OnTsBasePlayerControllerTouchEnd,
	// Token: 0x0400275D RID: 10077
	OnTsBasePlayerControllerTouchMove,
	// Token: 0x0400275E RID: 10078
	OnTsBasePlayerControllerPressAnyKey,
	// Token: 0x0400275F RID: 10079
	OnTsBasePlayerControllerReleaseAnyKey,
	// Token: 0x04002760 RID: 10080
	OnTsCharacterControllerReceiveBeginPlay,
	// Token: 0x04002761 RID: 10081
	OnTsCharacterControllerReceiveDestroyed,
	// Token: 0x04002762 RID: 10082
	OnTsCharacterControllerReceivePossess,
	// Token: 0x04002763 RID: 10083
	OnTsCharacterControllerReceiveUnPossess,
	// Token: 0x04002764 RID: 10084
	OnTsCharacterControllerOnSetupInputComponent,
	// Token: 0x04002765 RID: 10085
	OnTsCharacterControllerReceivePreProcessInput,
	// Token: 0x04002766 RID: 10086
	OnTsCharacterControllerReceivePostProcessInput,
	// Token: 0x04002767 RID: 10087
	OnTsCharacterControllerSetUiRootActive,
	// Token: 0x04002768 RID: 10088
	OnTsCharacterControllerSetUiRootDeactivate,
	// Token: 0x04002769 RID: 10089
	OnTsUiManagerInit,
	// Token: 0x0400276A RID: 10090
	OnTsLayerInit,
	// Token: 0x0400276B RID: 10091
	OnTsLguiEventSystemInit,
	// Token: 0x0400276C RID: 10092
	OpenViewRedirectToCs,
	// Token: 0x0400276D RID: 10093
	CloseViewRedirectToCs,
	// Token: 0x0400276E RID: 10094
	OpenViewRedirectToTs,
	// Token: 0x0400276F RID: 10095
	CloseViewRedirectToTs,
	// Token: 0x04002770 RID: 10096
	HideViewRedirectToTs,
	// Token: 0x04002771 RID: 10097
	CloseAndOpenRedirectToTs,
	// Token: 0x04002772 RID: 10098
	CloseAndOpenRedirectToCs,
	// Token: 0x04002773 RID: 10099
	PreOpenViewAsyncRedirectToCs,
	// Token: 0x04002774 RID: 10100
	PreOpenViewAsyncRedirectToTs,
	// Token: 0x04002775 RID: 10101
	OpenViewAfterPreOpenedAsyncToCs,
	// Token: 0x04002776 RID: 10102
	OpenViewAfterPreOpenedAsyncToTs,
	// Token: 0x04002777 RID: 10103
	TsNotifyCsViewOnCreateAsync,
	// Token: 0x04002778 RID: 10104
	TsNotifyCsBeforeStartAsync,
	// Token: 0x04002779 RID: 10105
	TsNotifyCsOnBeforeHideAsync,
	// Token: 0x0400277A RID: 10106
	TsNotifyCsOnPlayingStartSequenceAsync,
	// Token: 0x0400277B RID: 10107
	TsNotifyCsOnPlayingCloseSequenceAsync,
	// Token: 0x0400277C RID: 10108
	TsNotifyCsOnBeforeShowAsyncImplementImplement,
	// Token: 0x0400277D RID: 10109
	CsNotifyTsViewOnCreateAsync,
	// Token: 0x0400277E RID: 10110
	CsNotifyTsBeforeStartAsync,
	// Token: 0x0400277F RID: 10111
	CsNotifyTsOnBeforeHideAsync,
	// Token: 0x04002780 RID: 10112
	CsNotifyTsOnPlayingStartSequenceAsync,
	// Token: 0x04002781 RID: 10113
	CsNotifyTsOnPlayingCloseSequenceAsync,
	// Token: 0x04002782 RID: 10114
	CsNotifyTsOnBeforeShowAsyncImplementImplement,
	// Token: 0x04002783 RID: 10115
	NotifyCsOnNetReceiveResponse,
	// Token: 0x04002784 RID: 10116
	NotifyCsOnNetReceiveException,
	// Token: 0x04002785 RID: 10117
	NotifyCsOnNetReceiveTcpException,
	// Token: 0x04002786 RID: 10118
	NotifyCsOnNetReceivePush,
	// Token: 0x04002787 RID: 10119
	NotifyCsOnNetKcpConnectSuccess,
	// Token: 0x04002788 RID: 10120
	NotifyCsOnNetError,
	// Token: 0x04002789 RID: 10121
	NotifyCsCleanNetMessageCaches,
	// Token: 0x0400278A RID: 10122
	CsNetCall,
	// Token: 0x0400278B RID: 10123
	CsNotifyTsOpenWorldMapView,
	// Token: 0x0400278C RID: 10124
	CsNotifyTsTrackQuest,
	// Token: 0x0400278D RID: 10125
	TsNotifyCsTrackQuestResponse,
	// Token: 0x0400278E RID: 10126
	CsNotifyTsQuestTreeGotoQuest,
	// Token: 0x0400278F RID: 10127
	CsNotifyInfoSwitchInputControllerType,
	// Token: 0x04002790 RID: 10128
	CsNotifyTsUiNavigationBehaviorListenerAwakeBP,
	// Token: 0x04002791 RID: 10129
	CsNotifyTsUiNavigationBehaviorListenerStartBP,
	// Token: 0x04002792 RID: 10130
	CsNotifyTsUiNavigationBehaviorListenerOnNotifyNavigationEnterBP,
	// Token: 0x04002793 RID: 10131
	CsNotifyTsUiNavigationBehaviorListenerOnNotifyNavigationSelectBP,
	// Token: 0x04002794 RID: 10132
	CsNotifyTsUiNavigationBehaviorListenerOnEnableBP,
	// Token: 0x04002795 RID: 10133
	CsNotifyTsUiNavigationBehaviorListenerOnDisableBP,
	// Token: 0x04002796 RID: 10134
	CsNotifyTsUiNavigationBehaviorListenerOnNotifyInteractiveBP,
	// Token: 0x04002797 RID: 10135
	CsNotifyTsUiNavigationBehaviorListenerOnNotifyNotInteractiveBP,
	// Token: 0x04002798 RID: 10136
	CsNotifyTsUiNavigationBehaviorListenerOnDestroyBP,
	// Token: 0x04002799 RID: 10137
	CsNotifyTsUiNavigationBehaviorListenerOnCheckCanSetNavigationBP,
	// Token: 0x0400279A RID: 10138
	CsNotifyTsUiNavigationBehaviorListenerOnCheckLoopScrollChangeNavigationBP,
	// Token: 0x0400279B RID: 10139
	CsNotifyTsUiNavigationPanelConfigAwakeBP,
	// Token: 0x0400279C RID: 10140
	CsNotifyTsUiNavigationPanelConfigStartBP,
	// Token: 0x0400279D RID: 10141
	CsNotifyTsUiNavigationPanelConfigOnEnableBP,
	// Token: 0x0400279E RID: 10142
	CsNotifyTsUiNavigationPanelConfigOnDisableBP,
	// Token: 0x0400279F RID: 10143
	CsNotifyTsUiNavigationPanelConfigOnDestroyBP,
	// Token: 0x040027A0 RID: 10144
	CsNotifyTsLguiEventSystemActorInputTrigger,
	// Token: 0x040027A1 RID: 10145
	CsNotifyTsLguiEventSystemActorInputNavigation,
	// Token: 0x040027A2 RID: 10146
	CsNotifyTsLguiEventSystemActorInputTriggerForNavigation,
	// Token: 0x040027A3 RID: 10147
	CsNotifyTsLguiEventSystemActorInputScroll,
	// Token: 0x040027A4 RID: 10148
	CsNotifyTsLguiEventSystemActorInputTouchTrigger,
	// Token: 0x040027A5 RID: 10149
	CsNotifyTsLguiEventSystemActorInputTouchMove,
	// Token: 0x040027A6 RID: 10150
	CsNotifyTsLguiEventSystemActorSetClickThresholdWithInputKeyType,
	// Token: 0x040027A7 RID: 10151
	CsNotifyTsLguiEventSystemActorGetNowHitComponent,
	// Token: 0x040027A8 RID: 10152
	CsNotifyTsLguiEventSystemActorGetPointerEventData,
	// Token: 0x040027A9 RID: 10153
	CsNotifyTsLguiEventSystemActorIsPointerEventDataLineTrace,
	// Token: 0x040027AA RID: 10154
	CsNotifyTsUiBlurSetEnableUiBlur,
	// Token: 0x040027AB RID: 10155
	CsNotifyTsUiHotKeyActorComponentAwakeBP,
	// Token: 0x040027AC RID: 10156
	CsNotifyTsUiHotKeyActorComponentStartBP,
	// Token: 0x040027AD RID: 10157
	CsNotifyTsUiHotKeyActorComponentOnEnableBP,
	// Token: 0x040027AE RID: 10158
	CsNotifyTsUiHotKeyActorComponentOnDisableBP,
	// Token: 0x040027AF RID: 10159
	CsNotifyTsUiHotKeyActorComponentOnDestroyBP,
	// Token: 0x040027B0 RID: 10160
	CsNotifyTsUiNavigationTextChangeListenerAwakeBP,
	// Token: 0x040027B1 RID: 10161
	CsNotifyTsUiNavigationTextChangeListenerStartBP,
	// Token: 0x040027B2 RID: 10162
	CsNotifyTsUiNavigationTextChangeListenerOnNotifyTextChangeBP,
	// Token: 0x040027B3 RID: 10163
	CsNotifyTsUiNavigationPlatformChangeListenerAwakeBP,
	// Token: 0x040027B4 RID: 10164
	CsNotifyTsUiNavigationPlatformChangeListenerOnDestroyBP,
	// Token: 0x040027B5 RID: 10165
	CsRequestTsOpenView,
	// Token: 0x040027B6 RID: 10166
	TsWorldDone,
	// Token: 0x040027B7 RID: 10167
	TsReconnectClearData,
	// Token: 0x040027B8 RID: 10168
	TsOnPreEndPIE,
	// Token: 0x040027B9 RID: 10169
	CsNotifyUiNavigationNewControllerSetNavigationFocusForView,
	// Token: 0x040027BA RID: 10170
	TsActiveBattleView,
	// Token: 0x040027BB RID: 10171
	ResetToViewRedirectToTs,
	// Token: 0x040027BC RID: 10172
	ResetToViewRedirectToCs,
	// Token: 0x040027BD RID: 10173
	CsNotifyTsAddBlackScreen,
	// Token: 0x040027BE RID: 10174
	CsNotifyTsRemoveBlackScreen,
	// Token: 0x040027BF RID: 10175
	TsNotifyCsAddBlackScreenFinish,
	// Token: 0x040027C0 RID: 10176
	CsRequestTsHandleQuestTreeNode,
	// Token: 0x040027C1 RID: 10177
	TsHandleQuestTreeNodeResponse,
	// Token: 0x040027C2 RID: 10178
	TsClearSceneBegin,
	// Token: 0x040027C3 RID: 10179
	TsAfterLoadMap,
	// Token: 0x040027C4 RID: 10180
	TsSyncSetServerId,
	// Token: 0x040027C5 RID: 10181
	CsNotifyShowTips,
	// Token: 0x040027C6 RID: 10182
	CsRequestSelectMail,
	// Token: 0x040027C7 RID: 10183
	CsRequestPickMailAttachment,
	// Token: 0x040027C8 RID: 10184
	CsRequestDeleteMail,
	// Token: 0x040027C9 RID: 10185
	TsOnReadMailResponse,
	// Token: 0x040027CA RID: 10186
	TsOnPickMailAttachmentResponse,
	// Token: 0x040027CB RID: 10187
	TsOnDeleteMailResponse,
	// Token: 0x040027CC RID: 10188
	CsRequestOpenSdkExternalUrl,
	// Token: 0x040027CD RID: 10189
	CsRequestOpenSdkUrlWnd,
	// Token: 0x040027CE RID: 10190
	CsRequestSyncTsTimeModelParam,
	// Token: 0x040027CF RID: 10191
	TsResponseSyncToCsTimeModelParam,
	// Token: 0x040027D0 RID: 10192
	CsRequestSyncServerGameTime,
	// Token: 0x040027D1 RID: 10193
	TsResponseSyncServerGameTime,
	// Token: 0x040027D2 RID: 10194
	CsRequestAdjustTime,
	// Token: 0x040027D3 RID: 10195
	TsRequestAdjustTime,
	// Token: 0x040027D4 RID: 10196
	CsRequestLockTimeRunStateClient,
	// Token: 0x040027D5 RID: 10197
	TsRequestLockTimeRunStateClient,
	// Token: 0x040027D6 RID: 10198
	CsRequestLockTimeSyncLockStateClient,
	// Token: 0x040027D7 RID: 10199
	TsRequestLockTimeSyncLockStateClient,
	// Token: 0x040027D8 RID: 10200
	CsRequestSetTimeScale,
	// Token: 0x040027D9 RID: 10201
	TsRequestSetTimeScale,
	// Token: 0x040027DA RID: 10202
	CsRequestTimeCanOpenViewState,
	// Token: 0x040027DB RID: 10203
	TsResponseTimeCanOpenViewState,
	// Token: 0x040027DC RID: 10204
	TsOnTimeEnterGame,
	// Token: 0x040027DD RID: 10205
	TsOnTimeBeforeLoadMap,
	// Token: 0x040027DE RID: 10206
	TsOnTimeWorldDone,
	// Token: 0x040027DF RID: 10207
	TsSyncUseClientLockState,
	// Token: 0x040027E0 RID: 10208
	TsNotifyLevelSequencePlayerBannedState,
	// Token: 0x040027E1 RID: 10209
	CsNotifyOpenHelpView,
	// Token: 0x040027E2 RID: 10210
	TsNotifyQuestTrackState,
	// Token: 0x040027E3 RID: 10211
	NotifyCsLocalStorageInit,
	// Token: 0x040027E4 RID: 10212
	CsSyncItemTipsData,
	// Token: 0x040027E5 RID: 10213
	CsRequestOpenFunctionRelateView,
	// Token: 0x040027E6 RID: 10214
	TsSyncTickPauseState,
	// Token: 0x040027E7 RID: 10215
	TsSyncSceneTime,
	// Token: 0x040027E8 RID: 10216
	TsOnRequestFriendInfoResponse,
	// Token: 0x040027E9 RID: 10217
	CsRequestFriendHandle,
	// Token: 0x040027EA RID: 10218
	CsRequestChangeFriendRemark,
	// Token: 0x040027EB RID: 10219
	CsRequestFriendDelete,
	// Token: 0x040027EC RID: 10220
	CsRequestFriendApplicationDelete,
	// Token: 0x040027ED RID: 10221
	TsSyncInstanceType,
	// Token: 0x040027EE RID: 10222
	TsSyncHeadInfo,
	// Token: 0x040027EF RID: 10223
	CsSyncSelectedPlayerId,
	// Token: 0x040027F0 RID: 10224
	CsSyncFriendShowingView,
	// Token: 0x040027F1 RID: 10225
	CsSyncFriendFilterState,
	// Token: 0x040027F2 RID: 10226
	CsRequestLookCard,
	// Token: 0x040027F3 RID: 10227
	CsRequestAddMutePlayer,
	// Token: 0x040027F4 RID: 10228
	CsRequestRemoveMutePlayer,
	// Token: 0x040027F5 RID: 10229
	CsSyncRequestSearchData,
	// Token: 0x040027F6 RID: 10230
	TsSyncResponseSearchBasicData,
	// Token: 0x040027F7 RID: 10231
	TsSyncResponseSearchSdkData,
	// Token: 0x040027F8 RID: 10232
	CsRequestBlockData,
	// Token: 0x040027F9 RID: 10233
	TsResponseBlockData,
	// Token: 0x040027FA RID: 10234
	CsRequestFriendRecentlyTeam,
	// Token: 0x040027FB RID: 10235
	TsResponseFriendRecentlyTeam,
	// Token: 0x040027FC RID: 10236
	CsSyncCachePlayerData,
	// Token: 0x040027FD RID: 10237
	CsRequestReportPlayer,
	// Token: 0x040027FE RID: 10238
	CsRequestShowFriendPromptCode,
	// Token: 0x040027FF RID: 10239
	CsRequestChatOption,
	// Token: 0x04002800 RID: 10240
	CsRequestJoinWorld,
	// Token: 0x04002801 RID: 10241
	TsSyncBirthdayResetState,
	// Token: 0x04002802 RID: 10242
	CsRequestSdkBlockingUserData,
	// Token: 0x04002803 RID: 10243
	TsResponseSdkBlockingUserData,
	// Token: 0x04002804 RID: 10244
	CsRequestSdkTargetRelationData,
	// Token: 0x04002805 RID: 10245
	TsResponseSdkTargetRelationData,
	// Token: 0x04002806 RID: 10246
	CsRequestCommunicationRestricted,
	// Token: 0x04002807 RID: 10247
	TsResponseCommunicationRestricted,
	// Token: 0x04002808 RID: 10248
	CsRequestCommunicationRestrictedSync,
	// Token: 0x04002809 RID: 10249
	TsResponseCommunicationRestrictedSync,
	// Token: 0x0400280A RID: 10250
	CsRequestSdkPlayOnlyState,
	// Token: 0x0400280B RID: 10251
	TsResponseSdkPlayOnlyState,
	// Token: 0x0400280C RID: 10252
	CsRequestSdkFriendOnlyState,
	// Token: 0x0400280D RID: 10253
	TsResponseSdkFriendOnlyState,
	// Token: 0x0400280E RID: 10254
	CsRequestSaveSdkFriendOnlyState,
	// Token: 0x0400280F RID: 10255
	TsSyncAddMutePlayer,
	// Token: 0x04002810 RID: 10256
	TsSyncRemoveMutePlayer,
	// Token: 0x04002811 RID: 10257
	TsSyncLanguageChange,
	// Token: 0x04002812 RID: 10258
	TsSyncThirdPartyInfo,
	// Token: 0x04002813 RID: 10259
	LoadingPhaseChange,
	// Token: 0x04002814 RID: 10260
	TsSyncChatEnterTeam,
	// Token: 0x04002815 RID: 10261
	TsSyncChatLeaveTeam,
	// Token: 0x04002816 RID: 10262
	TsSyncChatEnterOnlineWorld,
	// Token: 0x04002817 RID: 10263
	TsSyncChatLeaveOnlineWorld,
	// Token: 0x04002818 RID: 10264
	CsRequestChangePlayerRemark,
	// Token: 0x04002819 RID: 10265
	TsSyncChangePlayerRemark,
	// Token: 0x0400281A RID: 10266
	TsSyncTime,
	// Token: 0x0400281B RID: 10267
	TsActivityCreateSubView,
	// Token: 0x0400281C RID: 10268
	TsActivityBeforeShowSelfAsync,
	// Token: 0x0400281D RID: 10269
	TsActivityBeforeHideSelfAsync,
	// Token: 0x0400281E RID: 10270
	TsActivityOnDestroy,
	// Token: 0x0400281F RID: 10271
	TsActivitySetActive,
	// Token: 0x04002820 RID: 10272
	TsActivityOnCommonViewStateChange,
	// Token: 0x04002821 RID: 10273
	TsActivityRefreshView,
	// Token: 0x04002822 RID: 10274
	TsActivityPlaySubViewSequence,
	// Token: 0x04002823 RID: 10275
	CsNotifyTsActivityOnCreateAsync,
	// Token: 0x04002824 RID: 10276
	CsNotifyTsActivityBeforeShowSelfAsync,
	// Token: 0x04002825 RID: 10277
	CsNotifyTsActivityBeforeHideSelfAsync,
	// Token: 0x04002826 RID: 10278
	CsMemoryFragmentMainViewRequestScreenshot,
	// Token: 0x04002827 RID: 10279
	CsRequestShowWorldLevelUpEffect,
	// Token: 0x04002828 RID: 10280
	CsRequestDestroyWorldLevelUpEffect,
	// Token: 0x04002829 RID: 10281
	CsRequestWorldLevelChangeInFight,
	// Token: 0x0400282A RID: 10282
	TsResponseWorldLevelChangeInFight,
	// Token: 0x0400282B RID: 10283
	CsRequestDownWorldLevel,
	// Token: 0x0400282C RID: 10284
	CsRequestRegainWorldLevel,
	// Token: 0x0400282D RID: 10285
	TsSyncWorldLevelChangeEvent,
	// Token: 0x0400282E RID: 10286
	TsSyncOriginWorldLevelUpEvent,
	// Token: 0x0400282F RID: 10287
	TsSyncAchievementFinish,
	// Token: 0x04002830 RID: 10288
	OnRefreshSubPackageDownLoadByPriority,
	// Token: 0x04002831 RID: 10289
	OnRefreshSubPackDownLoadState,
	// Token: 0x04002832 RID: 10290
	OnRefreshSubPackUseCellData,
	// Token: 0x04002833 RID: 10291
	OnRefreshSubPackClearData,
	// Token: 0x04002834 RID: 10292
	OnHookPointStateChanged,
	// Token: 0x04002835 RID: 10293
	OnSunSpiritEnableUpdated,
	// Token: 0x04002836 RID: 10294
	OnSunSpiritOccupiedByPlayerChanged,
	// Token: 0x04002837 RID: 10295
	OnSunSpiritOccupiedByGearChanged,
	// Token: 0x04002838 RID: 10296
	OnSunSpiritLauncherWatchSelectedChanged,
	// Token: 0x04002839 RID: 10297
	ShowRollBlockTips,
	// Token: 0x0400283A RID: 10298
	RollBlockAllCompleted,
	// Token: 0x0400283B RID: 10299
	OnRollBlockReseting,
	// Token: 0x0400283C RID: 10300
	OnRollBlockDifficultyChanged,
	// Token: 0x0400283D RID: 10301
	PhantomInteractEditGridRefresh,
	// Token: 0x0400283E RID: 10302
	PhantomInteractNewUnlock,
	// Token: 0x0400283F RID: 10303
	MonsterDebug,
	// Token: 0x04002840 RID: 10304
	OnEnableCrowdAiSystem,
	// Token: 0x04002841 RID: 10305
	MotorInMovieModeChange,
	// Token: 0x04002842 RID: 10306
	MotorSubStateModeChange,
	// Token: 0x04002843 RID: 10307
	MotorOnHit,
	// Token: 0x04002844 RID: 10308
	EnableGrapplingHookMark,
	// Token: 0x04002845 RID: 10309
	OnMapCustomMarkPanelShow,
	// Token: 0x04002846 RID: 10310
	OnPhantomArenaChooseCardPanelShow,
	// Token: 0x04002847 RID: 10311
	OnPhantomArenaDiscardCardPanelShow,
	// Token: 0x04002848 RID: 10312
	OnMotorDiyViewShow,
	// Token: 0x04002849 RID: 10313
	OnPhantomArenaPlayFieldEffect,
	// Token: 0x0400284A RID: 10314
	MotorDevelopTreeTypeRedDotUpdate,
	// Token: 0x0400284B RID: 10315
	OnGroupTrialRoleRedDotUpdate,
	// Token: 0x0400284C RID: 10316
	OnActivityNewPlayerSupportInfoUpdate,
	// Token: 0x0400284D RID: 10317
	OnActivityNewPlayerSupportEntranceRedDotUpdate,
	// Token: 0x0400284E RID: 10318
	OnEnterWheelTowerEndlessMode,
	// Token: 0x0400284F RID: 10319
	MotorDiyInfoRedDotUpdate,
	// Token: 0x04002850 RID: 10320
	OnGuideTriggerEvent,
	// Token: 0x04002851 RID: 10321
	OnSkillButtonAttributeFull,
	// Token: 0x04002852 RID: 10322
	OnEnterOrExitUnopenedArea,
	// Token: 0x04002853 RID: 10323
	OnForbidVehicleInUnopenedArea,
	// Token: 0x04002854 RID: 10324
	OnSetBattleUiChildCacheStateNotify,
	// Token: 0x04002855 RID: 10325
	OnSetBattleUiChildCacheState,
	// Token: 0x04002856 RID: 10326
	OnPhoneMsgPanelOpen,
	// Token: 0x04002857 RID: 10327
	OnPhoneMsgAdd,
	// Token: 0x04002858 RID: 10328
	OnPhoneHaveMsgToRemove,
	// Token: 0x04002859 RID: 10329
	OnPhoneMsgFilterChanged,
	// Token: 0x0400285A RID: 10330
	OnTouchUiEditSave,
	// Token: 0x0400285B RID: 10331
	OnViewShow,
	// Token: 0x0400285C RID: 10332
	RegressBpExpAnim,
	// Token: 0x0400285D RID: 10333
	TriggerBreakWeakness,
	// Token: 0x0400285E RID: 10334
	BreakWeaknessPanelLogicVisibleChange,
	// Token: 0x0400285F RID: 10335
	LevelPlayRewardDetailUpdate,
	// Token: 0x04002860 RID: 10336
	LevelPlayMarkGamePlayStateUpdate,
	// Token: 0x04002861 RID: 10337
	CommonPlayMarkGamePlayStateUpdate,
	// Token: 0x04002862 RID: 10338
	FeedbackRewardRefresh,
	// Token: 0x04002863 RID: 10339
	InfrastructureFireDataUpdate,
	// Token: 0x04002864 RID: 10340
	OnSceneItemNearbyTrackingEnd,
	// Token: 0x04002865 RID: 10341
	OnBrochureBookItemStateUpdate,
	// Token: 0x04002866 RID: 10342
	MotorDiyInfoPreviewRedDotUpdate,
	// Token: 0x04002867 RID: 10343
	ActivityPayShopGoodsBuy,
	// Token: 0x04002868 RID: 10344
	OnMotorDevelopTaskUpdate,
	// Token: 0x04002869 RID: 10345
	OnDrinksUnlockClickedNotify,
	// Token: 0x0400286A RID: 10346
	OnGuessJokerRedDotNotify,
	// Token: 0x0400286B RID: 10347
	OnSpringManorGameplayFinish,
	// Token: 0x0400286C RID: 10348
	OnFurnitureUnlockNotify,
	// Token: 0x0400286D RID: 10349
	OnFurnitureAreaUnlockNotify,
	// Token: 0x0400286E RID: 10350
	UpdateFurnitureEntranceRedDot,
	// Token: 0x0400286F RID: 10351
	OnRoleSkillInputPanelVisible,
	// Token: 0x04002870 RID: 10352
	OnFlagChallengeTaskUpdate,
	// Token: 0x04002871 RID: 10353
	OnFlagChallengeBattleActiveChanged,
	// Token: 0x04002872 RID: 10354
	OnFlagChallengeExpChanged,
	// Token: 0x04002873 RID: 10355
	OnFlagChallengeTempExpChanged,
	// Token: 0x04002874 RID: 10356
	OnFlagChallengeTotalLevelChanged,
	// Token: 0x04002875 RID: 10357
	OnFlagChallengeStrongholdOccupied,
	// Token: 0x04002876 RID: 10358
	OnFlagChallengeFixedRoleLevelUpdate,
	// Token: 0x04002877 RID: 10359
	OnFlagChallengeDungeonActiveChanged,
	// Token: 0x04002878 RID: 10360
	OnFlagChallengeLevelNewlyUnlock,
	// Token: 0x04002879 RID: 10361
	OnFlagChallengeBuffNewlyUnlock,
	// Token: 0x0400287A RID: 10362
	OnFlagChallengeBuffNewlyUnlockHintChanged,
	// Token: 0x0400287B RID: 10363
	OnFlagChallengeBattleBuffNewlyUnlock,
	// Token: 0x0400287C RID: 10364
	OnFlagChallengeRoleSelectCategoryUpdate,
	// Token: 0x0400287D RID: 10365
	BattleUiToggleFlagChallengeBuffInfo,
	// Token: 0x0400287E RID: 10366
	OnFlagChallengeUpdateStrongholdData,
	// Token: 0x0400287F RID: 10367
	OnFlagChallengeUpdateLevelData,
	// Token: 0x04002880 RID: 10368
	OrnamentRedDotRefresh,
	// Token: 0x04002881 RID: 10369
	OnOrnamentChange,
	// Token: 0x04002882 RID: 10370
	OnOrnamentUnlock,
	// Token: 0x04002883 RID: 10371
	OnPhantomConfigManagerDataUpdate,
	// Token: 0x04002884 RID: 10372
	OnPayShopConditionFinish,
	// Token: 0x04002885 RID: 10373
	KurotatoOnStepChanged,
	// Token: 0x04002886 RID: 10374
	KurotatoOnUpgradeRewardDataChanged,
	// Token: 0x04002887 RID: 10375
	KurotatoOnChestRewardDataChanged,
	// Token: 0x04002888 RID: 10376
	KurotatoOnShopDataChanged,
	// Token: 0x04002889 RID: 10377
	KurotatoOnItemUpdate,
	// Token: 0x0400288A RID: 10378
	KurotatoOnWeaponUpdate,
	// Token: 0x0400288B RID: 10379
	KurotatoOnWeaponRefined,
	// Token: 0x0400288C RID: 10380
	KurotatoOnRoleSaveStateUpdate,
	// Token: 0x0400288D RID: 10381
	KurotatoEnemyDetailBookGridItemClick,
	// Token: 0x0400288E RID: 10382
	KurotatoPlayerOneHpLeft,
	// Token: 0x0400288F RID: 10383
	KurotatoOnPropertyUpdate,
	// Token: 0x04002890 RID: 10384
	KurotatoBossTrackedMarkerUpdate,
	// Token: 0x04002891 RID: 10385
	KurotatoTreasureBoxTrackedMarkerUpdate,
	// Token: 0x04002892 RID: 10386
	KurotatoOnSystemInfoUpdate,
	// Token: 0x04002893 RID: 10387
	KurotatoOnPlayerDie,
	// Token: 0x04002894 RID: 10388
	KurotatoOnWaveCountDownFinish,
	// Token: 0x04002895 RID: 10389
	KurotatoOnNextWaveTypeUpdate,
	// Token: 0x04002896 RID: 10390
	OnGolemHackingLevelStateUpdate,
	// Token: 0x04002897 RID: 10391
	OnPhantomArenaMapUnlockUpdate,
	// Token: 0x04002898 RID: 10392
	NotifyGuideBreakFocus,
	// Token: 0x04002899 RID: 10393
	OnGuideTriggerResetEvent,
	// Token: 0x0400289A RID: 10394
	OnRhythmShipJumpLevel,
	// Token: 0x0400289B RID: 10395
	OnRhythmShipSelectRoleRefresh,
	// Token: 0x0400289C RID: 10396
	OnRhythmShipTaskRefresh,
	// Token: 0x0400289D RID: 10397
	OnRhythmShipTaskTabRefresh,
	// Token: 0x0400289E RID: 10398
	OnRhythmShipRedDotRefresh,
	// Token: 0x0400289F RID: 10399
	OnRhythmGameNoteResultUpdate,
	// Token: 0x040028A0 RID: 10400
	OnRhythmGameFinish,
	// Token: 0x040028A1 RID: 10401
	OnRhythmGameFeverModeChanged,
	// Token: 0x040028A2 RID: 10402
	OnRhythmGameFeverScoreChanged,
	// Token: 0x040028A3 RID: 10403
	OnRhythmGameSpeedLevelConfigIndexChanged,
	// Token: 0x040028A4 RID: 10404
	OnRhythmGameStartCoolDown,
	// Token: 0x040028A5 RID: 10405
	OnRhythmGameAutoJudgeCountChanged,
	// Token: 0x040028A6 RID: 10406
	OnRhythmGameEndCoolDown,
	// Token: 0x040028A7 RID: 10407
	OnRhythmGameStartPhase,
	// Token: 0x040028A8 RID: 10408
	OnRhythmGameStartNormalPhase,
	// Token: 0x040028A9 RID: 10409
	OnRhythmGameEndPhase,
	// Token: 0x040028AA RID: 10410
	OnRhythmGameFreePhase,
	// Token: 0x040028AB RID: 10411
	DropCatchActivityRewardUpdate,
	// Token: 0x040028AC RID: 10412
	OnAutoPilotTrackMarkVisibleChanged,
	// Token: 0x040028AD RID: 10413
	OnArcadeGameplayFinish,
	// Token: 0x040028AE RID: 10414
	OnTetrisChallengeStateUpdate,
	// Token: 0x040028AF RID: 10415
	OnTetrisScoreChanged,
	// Token: 0x040028B0 RID: 10416
	OnTetrisDragCancel,
	// Token: 0x040028B1 RID: 10417
	OnFlagChallengeCalculatedLevelUpdate,
	// Token: 0x040028B2 RID: 10418
	OnBeforeOpenLoginView,
	// Token: 0x040028B3 RID: 10419
	OnEntitySelfDirectionUpdate,
	// Token: 0x040028B4 RID: 10420
	SlidingBlockGameStageChanged,
	// Token: 0x040028B5 RID: 10421
	WuWuLogisticsTaskUpdate,
	// Token: 0x040028B6 RID: 10422
	SlidingBlockCheckLineClear,
	// Token: 0x040028B7 RID: 10423
	SlidingBlockSqueezePlayer,
	// Token: 0x040028B8 RID: 10424
	OnAnniversaryActivityRewardUpdate,
	// Token: 0x040028B9 RID: 10425
	OnBossPilingReward,
	// Token: 0x040028BA RID: 10426
	OnRoleSkillBranchInGamePlayChanged,
	// Token: 0x040028BB RID: 10427
	OnQuickHackCurrentRamChange,
	// Token: 0x040028BC RID: 10428
	OnQuickHackMaxRamChange,
	// Token: 0x040028BD RID: 10429
	OnQuickHackAllSkillChange,
	// Token: 0x040028BE RID: 10430
	OnQuickHackSelectSkillChange,
	// Token: 0x040028BF RID: 10431
	OnQuickHackDurationLimitChange,
	// Token: 0x040028C0 RID: 10432
	OnQuickHackTargetChange,
	// Token: 0x040028C1 RID: 10433
	OnQuickHackSceneItemStateChange,
	// Token: 0x040028C2 RID: 10434
	OnQuickHackCameraControlChange,
	// Token: 0x040028C3 RID: 10435
	OnQuickHackStartMark,
	// Token: 0x040028C4 RID: 10436
	OnQuickHackClose,
	// Token: 0x040028C5 RID: 10437
	OnQuickHackCameraControlClose,
	// Token: 0x040028C6 RID: 10438
	WeeklyChallengeRefresh,
	// Token: 0x040028C7 RID: 10439
	WeeklyChallengeRefreshRedDotChanged,
	// Token: 0x040028C8 RID: 10440
	WeeklyChallengeRewardStateChanged,
	// Token: 0x040028C9 RID: 10441
	WeeklyChallengeScoreChanged,
	// Token: 0x040028CA RID: 10442
	OnTrialRoleDataChanged,
	// Token: 0x040028CB RID: 10443
	OnProjectionPhotoItemStartDrag,
	// Token: 0x040028CC RID: 10444
	OnProjectionPhotoItemEndDrag,
	// Token: 0x040028CD RID: 10445
	OnProjectionPhotoFinishDrag,
	// Token: 0x040028CE RID: 10446
	OnProjectionPhotoItemPointDown,
	// Token: 0x040028CF RID: 10447
	OnProjectionPhotoItemPointUp,
	// Token: 0x040028D0 RID: 10448
	OnProjectionPhotoSliderEndDrag,
	// Token: 0x040028D1 RID: 10449
	OnHorizontalSliderValueFirstChange,
	// Token: 0x040028D2 RID: 10450
	OnProjectionPhotoItemDragCancel,
	// Token: 0x040028D3 RID: 10451
	VisionSummonEndByAction,
	// Token: 0x040028D4 RID: 10452
	ClosePlotCaptionImageView,
	// Token: 0x040028D5 RID: 10453
	MultiMotorRankInfoRefresh,
	// Token: 0x040028D6 RID: 10454
	MultiMotorRefresh,
	// Token: 0x040028D7 RID: 10455
	MultiMotorBuffRefresh,
	// Token: 0x040028D8 RID: 10456
	MultiMotorPassLine,
	// Token: 0x040028D9 RID: 10457
	MultiMotorStart,
	// Token: 0x040028DA RID: 10458
	OnDollGrabMachineClawStateStart,
	// Token: 0x040028DB RID: 10459
	OnDollGrabMachineGrabbingActorChanged,
	// Token: 0x040028DC RID: 10460
	OnDollGrabMachineClawStateEnd,
	// Token: 0x040028DD RID: 10461
	OnDollGrabMachineRemainingTimeAdd,
	// Token: 0x040028DE RID: 10462
	OnDollGrabMachineGrabDoll,
	// Token: 0x040028DF RID: 10463
	OnDollGrabMachineEndlessScoreChanged,
	// Token: 0x040028E0 RID: 10464
	OnDollGrabMachineStartCoolDown,
	// Token: 0x040028E1 RID: 10465
	OnDollGrabMachineEndCoolDown,
	// Token: 0x040028E2 RID: 10466
	OnDollGrabMachineEnd,
	// Token: 0x040028E3 RID: 10467
	OnDollGrabMachineRestart,
	// Token: 0x040028E4 RID: 10468
	OnDollGrabMachinePause,
	// Token: 0x040028E5 RID: 10469
	OnDollGrabMachineResume,
	// Token: 0x040028E6 RID: 10470
	OnDollGrabMachineDelivery,
	// Token: 0x040028E7 RID: 10471
	OnDollGrabMachineDeliveryFinish,
	// Token: 0x040028E8 RID: 10472
	OnDollGrabMachineDangerousCountdown,
	// Token: 0x040028E9 RID: 10473
	OnDollGrabMachineGameplayStateChanged,
	// Token: 0x040028EA RID: 10474
	QuestMultiLineTimePointChange,
	// Token: 0x040028EB RID: 10475
	OnEntityPerformanceStateChanged,
	// Token: 0x040028EC RID: 10476
	RestartHangingPreloadTask,
	// Token: 0x040028ED RID: 10477
	RealmBetweenTaskRefresh,
	// Token: 0x040028EE RID: 10478
	RealmBetweenMotorRefresh,
	// Token: 0x040028EF RID: 10479
	RealmBetweenTaskNavigationNext,
	// Token: 0x040028F0 RID: 10480
	OnWuWaGoRoleDead,
	// Token: 0x040028F1 RID: 10481
	OnWuWaGoDamageBatchStateChanged,
	// Token: 0x040028F2 RID: 10482
	OnWuWaGoMoveMonsterActed,
	// Token: 0x040028F3 RID: 10483
	OnWuWaGoUserPickScreen,
	// Token: 0x040028F4 RID: 10484
	OnWuWaGoUserPreviewScreen,
	// Token: 0x040028F5 RID: 10485
	OnWuWaGoUserPickDirection,
	// Token: 0x040028F6 RID: 10486
	OnWuWaGoUserUseInteraction,
	// Token: 0x040028F7 RID: 10487
	OnWuWaGoInteractionAvailable,
	// Token: 0x040028F8 RID: 10488
	OnWuWaGoPlayTipAvailable,
	// Token: 0x040028F9 RID: 10489
	OnWuWaGoMainControlInputAcceptingChanged,
	// Token: 0x040028FA RID: 10490
	OnWuWaGoCinematicPlayingChanged,
	// Token: 0x040028FB RID: 10491
	OnWuWaGoProgressUpdate,
	// Token: 0x040028FC RID: 10492
	OnWuWaGoRollbackAvailable,
	// Token: 0x040028FD RID: 10493
	OnWuWaGoUserRequestRollbackToSavePoint,
	// Token: 0x040028FE RID: 10494
	OnAnimNotifyMaterialControllerHandleAdded,
	// Token: 0x040028FF RID: 10495
	OnGotoAnomaly,
	// Token: 0x04002900 RID: 10496
	OnSheriffShopRedDotRefresh,
	// Token: 0x04002901 RID: 10497
	ActivitySignGrandRewardRefresh,
	// Token: 0x04002902 RID: 10498
	OnUnOpenedAreaCountDownUpdate,
	// Token: 0x04002903 RID: 10499
	OnPhotoSaveViewPersonalInfoShowRefresh,
	// Token: 0x04002904 RID: 10500
	OnRoleTrialStateChanged,
	// Token: 0x04002905 RID: 10501
	OnInteractiveItemsFunctionEnableChanged,
	// Token: 0x04002906 RID: 10502
	OnLevelInputLockChanged,
	// Token: 0x04002907 RID: 10503
	OnWorldMapExtraUiOpen,
	// Token: 0x04002908 RID: 10504
	OnWorldMapExtraUiClose,
	// Token: 0x04002909 RID: 10505
	Test0,
	// Token: 0x0400290A RID: 10506
	Test1,
	// Token: 0x0400290B RID: 10507
	Test2,
	// Token: 0x0400290C RID: 10508
	Test3,
	// Token: 0x0400290D RID: 10509
	Test4,
	// Token: 0x0400290E RID: 10510
	Test5,
	// Token: 0x0400290F RID: 10511
	Test6,
	// Token: 0x04002910 RID: 10512
	Test7,
	// Token: 0x04002911 RID: 10513
	ResetToBattleView,
	// Token: 0x04002912 RID: 10514
	OnHonamiStorySafeLeaveUpdate,
	// Token: 0x04002913 RID: 10515
	MovieModeAspectFadeComplete,
	// Token: 0x04002914 RID: 10516
	MotorDevelopTechTreeNodeUpdate,
	// Token: 0x04002915 RID: 10517
	RouletteRefreshRedDot,
	// Token: 0x04002916 RID: 10518
	RouletteRefreshNewOrRedDot,
	// Token: 0x04002917 RID: 10519
	RouletteAssemblyGridRefreshRedDot,
	// Token: 0x04002918 RID: 10520
	BattleUiPressMusicCombineButtonChanged,
	// Token: 0x04002919 RID: 10521
	TeleportAfterComplete,
	// Token: 0x0400291A RID: 10522
	BeforeTeleportComplete,
	// Token: 0x0400291B RID: 10523
	PlotTeleportToPositionFinished,
	// Token: 0x0400291C RID: 10524
	MotorUiModelUpdate,
	// Token: 0x0400291D RID: 10525
	ShowAreaTips,
	// Token: 0x0400291E RID: 10526
	RoleFindMotorcycleInteractiveEntity,
	// Token: 0x0400291F RID: 10527
	RoleFindFixHook,
	// Token: 0x04002920 RID: 10528
	OnMotorPlayTick,
	// Token: 0x04002921 RID: 10529
	TsSyncWorldLevel,
	// Token: 0x04002922 RID: 10530
	OnGuessJokerLevelUnlockNotify,
	// Token: 0x04002923 RID: 10531
	OnGuessJokerUnlockClickedNotify,
	// Token: 0x04002924 RID: 10532
	SpawnBoss,
	// Token: 0x04002925 RID: 10533
	MotorcycleWaterDetectedTick,
	// Token: 0x04002926 RID: 10534
	MotorcycleWaterDetectedStart,
	// Token: 0x04002927 RID: 10535
	MotorcycleWaterDetectedEnd,
	// Token: 0x04002928 RID: 10536
	OnPhantomConfigManagerSharedUpdate,
	// Token: 0x04002929 RID: 10537
	OnRacingBetsMatchStateChange,
	// Token: 0x0400292A RID: 10538
	SlidingBlockEndlessSpeedLevel,
	// Token: 0x0400292B RID: 10539
	OnGameplayTagChanged
}
