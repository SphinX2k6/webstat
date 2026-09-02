using System;

// Token: 0x02000E89 RID: 3721
public enum EFunction
{
	// Token: 0x04002A55 RID: 10837
	MASTERVOLUMEFUNCTION = 1,
	// Token: 0x04002A56 RID: 10838
	VOICEVOLUMEFUNCTION,
	// Token: 0x04002A57 RID: 10839
	MUSICVOLUMEFUNCTION,
	// Token: 0x04002A58 RID: 10840
	SFXVOLUMEFUNCTION,
	// Token: 0x04002A59 RID: 10841
	AMBVOLUMEFUNCTION = 69,
	// Token: 0x04002A5A RID: 10842
	UIVOLUMEFUNCTION,
	// Token: 0x04002A5B RID: 10843
	DOLBYATOMS = 76,
	// Token: 0x04002A5C RID: 10844
	IMAGEQUALITY = 10,
	// Token: 0x04002A5D RID: 10845
	DISPLAYMODE = 5,
	// Token: 0x04002A5E RID: 10846
	RESOLUTION,
	// Token: 0x04002A5F RID: 10847
	BRIGHTNESS,
	// Token: 0x04002A60 RID: 10848
	HIGHESTFPS = 11,
	// Token: 0x04002A61 RID: 10849
	SHADOWQUALITY = 54,
	// Token: 0x04002A62 RID: 10850
	NIAGARAQUALITY,
	// Token: 0x04002A63 RID: 10851
	IMAGEDETAIL,
	// Token: 0x04002A64 RID: 10852
	ANTIALISING,
	// Token: 0x04002A65 RID: 10853
	SCENEAO,
	// Token: 0x04002A66 RID: 10854
	NPCDENSITY = 79,
	// Token: 0x04002A67 RID: 10855
	NVIDIADLSS = 81,
	// Token: 0x04002A68 RID: 10856
	NVIDIADLSSFG,
	// Token: 0x04002A69 RID: 10857
	NVIDIADLSSQUALITY = 831,
	// Token: 0x04002A6A RID: 10858
	NVIDIADLSSSHARPNESS = 84,
	// Token: 0x04002A6B RID: 10859
	NVIDIAREFLEX,
	// Token: 0x04002A6C RID: 10860
	HDR = 20305,
	// Token: 0x04002A6D RID: 10861
	FSR = 87,
	// Token: 0x04002A6E RID: 10862
	XESS = 125,
	// Token: 0x04002A6F RID: 10863
	XESS_QUALITY,
	// Token: 0x04002A70 RID: 10864
	XESS2 = 20310,
	// Token: 0x04002A71 RID: 10865
	XESS2_FG = 20341,
	// Token: 0x04002A72 RID: 10866
	XESS2_QUALITY = 20340,
	// Token: 0x04002A73 RID: 10867
	FSR3 = 20350,
	// Token: 0x04002A74 RID: 10868
	FSR3_FG = 20352,
	// Token: 0x04002A75 RID: 10869
	FSR3_QUALITY = 20351,
	// Token: 0x04002A76 RID: 10870
	METALFX = 127,
	// Token: 0x04002A77 RID: 10871
	IRX,
	// Token: 0x04002A78 RID: 10872
	BLOOM = 132,
	// Token: 0x04002A79 RID: 10873
	VOLUMEFOG = 63,
	// Token: 0x04002A7A RID: 10874
	VOLUMELIGHT,
	// Token: 0x04002A7B RID: 10875
	MOTIONBLUR,
	// Token: 0x04002A7C RID: 10876
	PCVSYNC,
	// Token: 0x04002A7D RID: 10877
	MOBILERESOLUTION,
	// Token: 0x04002A7E RID: 10878
	SUPERRESOLUTION,
	// Token: 0x04002A7F RID: 10879
	LOADINGRANGESCALELEVEL = 20611,
	// Token: 0x04002A80 RID: 10880
	TEXTLANGUAGE = 51,
	// Token: 0x04002A81 RID: 10881
	VOICELANGUAGE,
	// Token: 0x04002A82 RID: 10882
	VOICEPACKMANAGER,
	// Token: 0x04002A83 RID: 10883
	VOICEROLECUSTOM = 40101,
	// Token: 0x04002A84 RID: 10884
	ADVICESETTING = 59,
	// Token: 0x04002A85 RID: 10885
	GENDERSETTING = 88,
	// Token: 0x04002A86 RID: 10886
	HorizontalViewSensitivity,
	// Token: 0x04002A87 RID: 10887
	VerticalViewSensitivity,
	// Token: 0x04002A88 RID: 10888
	AimHorizontalViewSensitivity,
	// Token: 0x04002A89 RID: 10889
	AimVerticalViewSensitivity,
	// Token: 0x04002A8A RID: 10890
	CameraShakeStrength,
	// Token: 0x04002A8B RID: 10891
	MobileHorizontalViewSensitivity,
	// Token: 0x04002A8C RID: 10892
	MobileVerticalViewSensitivity,
	// Token: 0x04002A8D RID: 10893
	MobileAimHorizontalViewSensitivity,
	// Token: 0x04002A8E RID: 10894
	MobileAimVerticalViewSensitivity,
	// Token: 0x04002A8F RID: 10895
	CommonSpringArmLength = 99,
	// Token: 0x04002A90 RID: 10896
	FightSpringArmLength,
	// Token: 0x04002A91 RID: 10897
	ResetFocusEnable,
	// Token: 0x04002A92 RID: 10898
	IsSidestepCameraEnable,
	// Token: 0x04002A93 RID: 10899
	IsSoftLockCameraEnable,
	// Token: 0x04002A94 RID: 10900
	JoystickShakeStrength,
	// Token: 0x04002A95 RID: 10901
	JoystickShakeType,
	// Token: 0x04002A96 RID: 10902
	WalkOrRunRate,
	// Token: 0x04002A97 RID: 10903
	LogUpload,
	// Token: 0x04002A98 RID: 10904
	JoystickMode,
	// Token: 0x04002A99 RID: 10905
	MobileButtonCustom = 86,
	// Token: 0x04002A9A RID: 10906
	SkillButtonMode = 109,
	// Token: 0x04002A9B RID: 10907
	CdKey = 112,
	// Token: 0x04002A9C RID: 10908
	UserCenterDomestic,
	// Token: 0x04002A9D RID: 10909
	TermsOfUseDomestic,
	// Token: 0x04002A9E RID: 10910
	PrivacyPolicyDomestic,
	// Token: 0x04002A9F RID: 10911
	ChildrenPrivacy,
	// Token: 0x04002AA0 RID: 10912
	ThirdPartyInfo,
	// Token: 0x04002AA1 RID: 10913
	TermsOfUseOverSeas,
	// Token: 0x04002AA2 RID: 10914
	PrivacyPolicyOverSeas,
	// Token: 0x04002AA3 RID: 10915
	PrivacyPolicySetting,
	// Token: 0x04002AA4 RID: 10916
	License = 146,
	// Token: 0x04002AA5 RID: 10917
	UserCenterOverseas = 123,
	// Token: 0x04002AA6 RID: 10918
	PushMode = 121,
	// Token: 0x04002AA7 RID: 10919
	AimAssist,
	// Token: 0x04002AA8 RID: 10920
	KeyboardLockEnemyMode = 129,
	// Token: 0x04002AA9 RID: 10921
	HorizontalViewRevert,
	// Token: 0x04002AAA RID: 10922
	VerticalViewRevert,
	// Token: 0x04002AAB RID: 10923
	SkillLockEnemyMode = 133,
	// Token: 0x04002AAC RID: 10924
	GamepadLockEnemyMode,
	// Token: 0x04002AAD RID: 10925
	EnemyHitDisplayMode,
	// Token: 0x04002AAE RID: 10926
	PlayStationOnly,
	// Token: 0x04002AAF RID: 10927
	MobileGamepadMode,
	// Token: 0x04002AB0 RID: 10928
	BackendVolume = 10107,
	// Token: 0x04002AB1 RID: 10929
	SkinDamageMode = 20031,
	// Token: 0x04002AB2 RID: 10930
	AutoAdjustImageQuality = 145,
	// Token: 0x04002AB3 RID: 10931
	ShowDamage = 20023,
	// Token: 0x04002AB4 RID: 10932
	DynamicBones,
	// Token: 0x04002AB5 RID: 10933
	FlowAdaptation,
	// Token: 0x04002AB6 RID: 10934
	UIPureMode = 51101,
	// Token: 0x04002AB7 RID: 10935
	FlyControlMode = 60207,
	// Token: 0x04002AB8 RID: 10936
	RayTracing = 20026,
	// Token: 0x04002AB9 RID: 10937
	RayTracedReflection,
	// Token: 0x04002ABA RID: 10938
	RayTracedGI,
	// Token: 0x04002ABB RID: 10939
	RayTracedShadow,
	// Token: 0x04002ABC RID: 10940
	TeammateFx,
	// Token: 0x04002ABD RID: 10941
	Saturation = 20204,
	// Token: 0x04002ABE RID: 10942
	Contrast,
	// Token: 0x04002ABF RID: 10943
	Filter,
	// Token: 0x04002AC0 RID: 10944
	AdrenoFME = 20032,
	// Token: 0x04002AC1 RID: 10945
	BasicGraphicSetting = 20203,
	// Token: 0x04002AC2 RID: 10946
	Vulkan = 20360,
	// Token: 0x04002AC3 RID: 10947
	ResDownLoad = 55113,
	// Token: 0x04002AC4 RID: 10948
	ResClear,
	// Token: 0x04002AC5 RID: 10949
	VersionCheck = 51506,
	// Token: 0x04002AC6 RID: 10950
	AutoRun = 60208,
	// Token: 0x04002AC7 RID: 10951
	AutoSprint,
	// Token: 0x04002AC8 RID: 10952
	ShowOtherName = 51102,
	// Token: 0x04002AC9 RID: 10953
	WaterInteract = 20033,
	// Token: 0x04002ACA RID: 10954
	VegetationDither,
	// Token: 0x04002ACB RID: 10955
	VegetationDensity,
	// Token: 0x04002ACC RID: 10956
	ImageDisplayMode = 20216,
	// Token: 0x04002ACD RID: 10957
	EyeProtection = 20210,
	// Token: 0x04002ACE RID: 10958
	EyeProtectionMode,
	// Token: 0x04002ACF RID: 10959
	EyeProtectionTemp,
	// Token: 0x04002AD0 RID: 10960
	EyeProtectionStrength,
	// Token: 0x04002AD1 RID: 10961
	EyeProtectionBrightness,
	// Token: 0x04002AD2 RID: 10962
	EyeProtectionTexture,
	// Token: 0x04002AD3 RID: 10963
	AutoExposure = 20610,
	// Token: 0x04002AD4 RID: 10964
	AdjustiveGamePadTrigger = 60210,
	// Token: 0x04002AD5 RID: 10965
	MotorMobileButtonCustom = 30201,
	// Token: 0x04002AD6 RID: 10966
	MotorIsDynamicJoystick,
	// Token: 0x04002AD7 RID: 10967
	MotorMobileButtonLayout = 30200,
	// Token: 0x04002AD8 RID: 10968
	MotorAutoAcceleratorSettingEnable = 60301,
	// Token: 0x04002AD9 RID: 10969
	MotorAutoLongPressSpeedUp,
	// Token: 0x04002ADA RID: 10970
	MotorDriftAcceleratorSettingEnable,
	// Token: 0x04002ADB RID: 10971
	MotorDriftModel = 60305,
	// Token: 0x04002ADC RID: 10972
	MotorHudVisible = 51103,
	// Token: 0x04002ADD RID: 10973
	SubTitleOption,
	// Token: 0x04002ADE RID: 10974
	DeviceInfo = 201006,
	// Token: 0x04002ADF RID: 10975
	UiBrightness = 20306,
	// Token: 0x04002AE0 RID: 10976
	PeakBrightness,
	// Token: 0x04002AE1 RID: 10977
	MotorFlyControlMode = 60304,
	// Token: 0x04002AE2 RID: 10978
	AnisoLevel = 20004,
	// Token: 0x04002AE3 RID: 10979
	GamepadLeftStickDeadZone = 60235,
	// Token: 0x04002AE4 RID: 10980
	GamepadRightStickDeadZone = 60240,
	// Token: 0x04002AE5 RID: 10981
	GamepadLeftTriggerDeadZone = 60245,
	// Token: 0x04002AE6 RID: 10982
	GamepadRightTriggerDeadZone = 60250,
	// Token: 0x04002AE7 RID: 10983
	XboxOnly = 511360
}
