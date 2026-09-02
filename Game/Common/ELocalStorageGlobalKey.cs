using System;

namespace CSharpScript.Game.Common
{
	// Token: 0x02007062 RID: 28770
	public enum ELocalStorageGlobalKey
	{
		// Token: 0x04026E3D RID: 159293
		GameQualitySetting,
		// Token: 0x04026E3E RID: 159294
		LoginFailCount,
		// Token: 0x04026E3F RID: 159295
		NextLoginTime,
		// Token: 0x04026E40 RID: 159296
		ResetLoginFailCountTime,
		// Token: 0x04026E41 RID: 159297
		SingleMapId,
		// Token: 0x04026E42 RID: 159298
		MultiMapId,
		// Token: 0x04026E43 RID: 159299
		LoginSex,
		// Token: 0x04026E44 RID: 159300
		SelectBoxActive,
		// Token: 0x04026E45 RID: 159301
		SkipPlot,
		// Token: 0x04026E46 RID: 159302
		FirstOpenShop,
		// Token: 0x04026E47 RID: 159303
		LoginDebugServerIp,
		// Token: 0x04026E48 RID: 159304
		PlayMenuInfo,
		// Token: 0x04026E49 RID: 159305
		MenuData,
		// Token: 0x04026E4A RID: 159306
		Account,
		// Token: 0x04026E4B RID: 159307
		GmHistory,
		// Token: 0x04026E4C RID: 159308
		LocalGameTimeData,
		// Token: 0x04026E4D RID: 159309
		PackageAudio,
		// Token: 0x04026E4E RID: 159310
		RecentlyAccountList,
		// Token: 0x04026E4F RID: 159311
		RecentlyLoginUID,
		// Token: 0x04026E50 RID: 159312
		SubDownLoadClearLastWorldDoneUid,
		// Token: 0x04026E51 RID: 159313
		LastTimeUploadStamp,
		// Token: 0x04026E52 RID: 159314
		SdkLastTimeLoginData,
		// Token: 0x04026E53 RID: 159315
		SdkLevelData,
		// Token: 0x04026E54 RID: 159316
		RequestPhotoPermissionMinTime,
		// Token: 0x04026E55 RID: 159317
		PhotoAndShareShowPlayerName,
		// Token: 0x04026E56 RID: 159318
		CombineAction,
		// Token: 0x04026E57 RID: 159319
		GameQualityLevel,
		// Token: 0x04026E58 RID: 159320
		CustomFrameRate,
		// Token: 0x04026E59 RID: 159321
		ShadowQuality,
		// Token: 0x04026E5A RID: 159322
		NiagaraQuality,
		// Token: 0x04026E5B RID: 159323
		ImageDetail,
		// Token: 0x04026E5C RID: 159324
		Brightness,
		// Token: 0x04026E5D RID: 159325
		AntiAliasing,
		// Token: 0x04026E5E RID: 159326
		SceneAo,
		// Token: 0x04026E5F RID: 159327
		VolumeFog,
		// Token: 0x04026E60 RID: 159328
		VolumeLight,
		// Token: 0x04026E61 RID: 159329
		MotionBlur,
		// Token: 0x04026E62 RID: 159330
		StreamLevel,
		// Token: 0x04026E63 RID: 159331
		PcVsync,
		// Token: 0x04026E64 RID: 159332
		MobileResolution,
		// Token: 0x04026E65 RID: 159333
		SuperResolution,
		// Token: 0x04026E66 RID: 159334
		PcResolutionWidth,
		// Token: 0x04026E67 RID: 159335
		PcResolutionHeight,
		// Token: 0x04026E68 RID: 159336
		PcWindowMode,
		// Token: 0x04026E69 RID: 159337
		NvidiaSuperSamplingEnable,
		// Token: 0x04026E6A RID: 159338
		NvidiaSuperSamplingFrameGenerate,
		// Token: 0x04026E6B RID: 159339
		NvidiaSuperSamplingMode,
		// Token: 0x04026E6C RID: 159340
		NvidiaSuperSamplingQuality,
		// Token: 0x04026E6D RID: 159341
		NvidiaSuperSamplingSharpness,
		// Token: 0x04026E6E RID: 159342
		NvidiaReflex,
		// Token: 0x04026E6F RID: 159343
		Hdr,
		// Token: 0x04026E70 RID: 159344
		FsrEnable,
		// Token: 0x04026E71 RID: 159345
		HorizontalViewSensitivity,
		// Token: 0x04026E72 RID: 159346
		VerticalViewSensitivity,
		// Token: 0x04026E73 RID: 159347
		AimHorizontalViewSensitivity,
		// Token: 0x04026E74 RID: 159348
		AimVerticalViewSensitivity,
		// Token: 0x04026E75 RID: 159349
		CameraShakeStrength,
		// Token: 0x04026E76 RID: 159350
		MobileHorizontalViewSensitivity,
		// Token: 0x04026E77 RID: 159351
		MobileVerticalViewSensitivity,
		// Token: 0x04026E78 RID: 159352
		MobileAimHorizontalViewSensitivity,
		// Token: 0x04026E79 RID: 159353
		MobileAimVerticalViewSensitivity,
		// Token: 0x04026E7A RID: 159354
		MobileCameraShakeStrength,
		// Token: 0x04026E7B RID: 159355
		CommonSpringArmLength,
		// Token: 0x04026E7C RID: 159356
		FightSpringArmLength,
		// Token: 0x04026E7D RID: 159357
		IsResetFocusEnable,
		// Token: 0x04026E7E RID: 159358
		IsSidestepCameraEnable,
		// Token: 0x04026E7F RID: 159359
		IsSoftLockCameraEnable,
		// Token: 0x04026E80 RID: 159360
		JoystickShakeStrength,
		// Token: 0x04026E81 RID: 159361
		JoystickShakeType,
		// Token: 0x04026E82 RID: 159362
		WalkOrRunRate,
		// Token: 0x04026E83 RID: 159363
		JoystickMode,
		// Token: 0x04026E84 RID: 159364
		IsAutoSwitchSkillButtonMode,
		// Token: 0x04026E85 RID: 159365
		AimAssistEnable,
		// Token: 0x04026E86 RID: 159366
		XessEnable,
		// Token: 0x04026E87 RID: 159367
		XessQuality,
		// Token: 0x04026E88 RID: 159368
		Xess2Enable,
		// Token: 0x04026E89 RID: 159369
		Xess2Fg,
		// Token: 0x04026E8A RID: 159370
		Xess2Quality,
		// Token: 0x04026E8B RID: 159371
		Fsr3Enable,
		// Token: 0x04026E8C RID: 159372
		Fsr3Fg,
		// Token: 0x04026E8D RID: 159373
		Fsr3Quality,
		// Token: 0x04026E8E RID: 159374
		MetalFxEnable,
		// Token: 0x04026E8F RID: 159375
		IrxEnable,
		// Token: 0x04026E90 RID: 159376
		BloomEnable,
		// Token: 0x04026E91 RID: 159377
		NpcDensity,
		// Token: 0x04026E92 RID: 159378
		KeyboardLockEnemyMode,
		// Token: 0x04026E93 RID: 159379
		HorizontalViewRevert,
		// Token: 0x04026E94 RID: 159380
		VerticalViewRevert,
		// Token: 0x04026E95 RID: 159381
		SkillLockEnemyMode,
		// Token: 0x04026E96 RID: 159382
		GamepadLockEnemyMode,
		// Token: 0x04026E97 RID: 159383
		EnemyHitDisplayMode,
		// Token: 0x04026E98 RID: 159384
		RepairEnemyHitDisplayMode,
		// Token: 0x04026E99 RID: 159385
		GamepadRouletteSelectConfig,
		// Token: 0x04026E9A RID: 159386
		IsConvertViewSensitivity,
		// Token: 0x04026E9B RID: 159387
		IsConvertAllViewSensitivity,
		// Token: 0x04026E9C RID: 159388
		MasterVolume,
		// Token: 0x04026E9D RID: 159389
		VoiceVolume,
		// Token: 0x04026E9E RID: 159390
		MusicVolume,
		// Token: 0x04026E9F RID: 159391
		SFXVolume,
		// Token: 0x04026EA0 RID: 159392
		AMBVolume,
		// Token: 0x04026EA1 RID: 159393
		UIVolume,
		// Token: 0x04026EA2 RID: 159394
		PcResolutionIndex,
		// Token: 0x04026EA3 RID: 159395
		TextLanguage,
		// Token: 0x04026EA4 RID: 159396
		VoiceLanguage,
		// Token: 0x04026EA5 RID: 159397
		AdviceSetting,
		// Token: 0x04026EA6 RID: 159398
		GenderSetting,
		// Token: 0x04026EA7 RID: 159399
		ImageQuality,
		// Token: 0x04026EA8 RID: 159400
		HasLocalGameSettings,
		// Token: 0x04026EA9 RID: 159401
		IsConvertOldMenuData,
		// Token: 0x04026EAA RID: 159402
		LastReviewTime,
		// Token: 0x04026EAB RID: 159403
		IsConvertInputActionSort,
		// Token: 0x04026EAC RID: 159404
		OpenReviewTimeList,
		// Token: 0x04026EAD RID: 159405
		AutoAdjustImageQuality,
		// Token: 0x04026EAE RID: 159406
		IsConvertInput,
		// Token: 0x04026EAF RID: 159407
		IsSavedKeyMappings,
		// Token: 0x04026EB0 RID: 159408
		GamepadOperationPreferences,
		// Token: 0x04026EB1 RID: 159409
		ShowDamage,
		// Token: 0x04026EB2 RID: 159410
		DynamicBones,
		// Token: 0x04026EB3 RID: 159411
		IsCustomImageQuality,
		// Token: 0x04026EB4 RID: 159412
		DolbyAtmos,
		// Token: 0x04026EB5 RID: 159413
		IsFinishRecommendQuality,
		// Token: 0x04026EB6 RID: 159414
		FlowAdaptation,
		// Token: 0x04026EB7 RID: 159415
		FlyControlMode,
		// Token: 0x04026EB8 RID: 159416
		IsShowFinishedPlayPointMark,
		// Token: 0x04026EB9 RID: 159417
		IsShowCustomMark,
		// Token: 0x04026EBA RID: 159418
		JoystickClickMultiplier,
		// Token: 0x04026EBB RID: 159419
		AreaStoryProgress,
		// Token: 0x04026EBC RID: 159420
		RayTracing,
		// Token: 0x04026EBD RID: 159421
		RayTracedReflection,
		// Token: 0x04026EBE RID: 159422
		RayTracedGI,
		// Token: 0x04026EBF RID: 159423
		RayTracedShadow,
		// Token: 0x04026EC0 RID: 159424
		TeammateFx,
		// Token: 0x04026EC1 RID: 159425
		Saturation,
		// Token: 0x04026EC2 RID: 159426
		Contrast,
		// Token: 0x04026EC3 RID: 159427
		SaturationNew,
		// Token: 0x04026EC4 RID: 159428
		ContrastNew,
		// Token: 0x04026EC5 RID: 159429
		IconPercentAreaStory,
		// Token: 0x04026EC6 RID: 159430
		IconPercentAreaShow,
		// Token: 0x04026EC7 RID: 159431
		AreaExplorePlayState,
		// Token: 0x04026EC8 RID: 159432
		ShowNoteIdMap,
		// Token: 0x04026EC9 RID: 159433
		SkinDamageMode,
		// Token: 0x04026ECA RID: 159434
		HasRefreshNvidiaDlssQuality,
		// Token: 0x04026ECB RID: 159435
		HasRefreshNvidiaDlssFrameGenerate,
		// Token: 0x04026ECC RID: 159436
		AfmeSince2Dot3,
		// Token: 0x04026ECD RID: 159437
		AutoRun,
		// Token: 0x04026ECE RID: 159438
		AutoSprint,
		// Token: 0x04026ECF RID: 159439
		Vulkan,
		// Token: 0x04026ED0 RID: 159440
		VulkanChangeFlag,
		// Token: 0x04026ED1 RID: 159441
		PreDownloadVersionRecord,
		// Token: 0x04026ED2 RID: 159442
		IsLastGamePadPlayStation,
		// Token: 0x04026ED3 RID: 159443
		LastGamepadEnum,
		// Token: 0x04026ED4 RID: 159444
		HasResetBrightness,
		// Token: 0x04026ED5 RID: 159445
		ShowOtherName,
		// Token: 0x04026ED6 RID: 159446
		WaterInteract,
		// Token: 0x04026ED7 RID: 159447
		ImageDisplayMode,
		// Token: 0x04026ED8 RID: 159448
		EyeProtection,
		// Token: 0x04026ED9 RID: 159449
		EyeProtectionMode,
		// Token: 0x04026EDA RID: 159450
		EyeProtectionTemp,
		// Token: 0x04026EDB RID: 159451
		EyeProtectionStrength,
		// Token: 0x04026EDC RID: 159452
		EyeProtectionBrightness,
		// Token: 0x04026EDD RID: 159453
		EyeProtectionTexture,
		// Token: 0x04026EDE RID: 159454
		FilterSettingId,
		// Token: 0x04026EDF RID: 159455
		FilterSettingValues,
		// Token: 0x04026EE0 RID: 159456
		VegetationDensity,
		// Token: 0x04026EE1 RID: 159457
		VegetationDither,
		// Token: 0x04026EE2 RID: 159458
		AutoExposure,
		// Token: 0x04026EE3 RID: 159459
		ParallelPackageVersion,
		// Token: 0x04026EE4 RID: 159460
		AdjustiveGamePadTrigger,
		// Token: 0x04026EE5 RID: 159461
		BackendVolume,
		// Token: 0x04026EE6 RID: 159462
		NewPlayerSupportForbidStartView,
		// Token: 0x04026EE7 RID: 159463
		MotorAutoAcceleratorSettingEnable,
		// Token: 0x04026EE8 RID: 159464
		MotorAutoLongPressSpeedUp,
		// Token: 0x04026EE9 RID: 159465
		MotorIsDynamicJoystick,
		// Token: 0x04026EEA RID: 159466
		MotorMobileButtonLayout,
		// Token: 0x04026EEB RID: 159467
		MotorDriftAcceleratorSettingEnable,
		// Token: 0x04026EEC RID: 159468
		MotorHudVisible,
		// Token: 0x04026EED RID: 159469
		MotorDriftModel,
		// Token: 0x04026EEE RID: 159470
		SubTitleOption,
		// Token: 0x04026EEF RID: 159471
		ShowPlotDebugInfo,
		// Token: 0x04026EF0 RID: 159472
		UiBrightness,
		// Token: 0x04026EF1 RID: 159473
		PeakBrightness,
		// Token: 0x04026EF2 RID: 159474
		LoadingRangeScaleLevel,
		// Token: 0x04026EF3 RID: 159475
		HasResetMobileShadowQuality,
		// Token: 0x04026EF4 RID: 159476
		MotorFlyControlMode,
		// Token: 0x04026EF5 RID: 159477
		IsUsingQualityPreset,
		// Token: 0x04026EF6 RID: 159478
		AnisoLevel,
		// Token: 0x04026EF7 RID: 159479
		PhotographSetupOption,
		// Token: 0x04026EF8 RID: 159480
		FightPhotographSetupOption,
		// Token: 0x04026EF9 RID: 159481
		GamepadLeftStickDeadZone,
		// Token: 0x04026EFA RID: 159482
		GamepadRightStickDeadZone,
		// Token: 0x04026EFB RID: 159483
		GamepadLeftTriggerDeadZone,
		// Token: 0x04026EFC RID: 159484
		GamepadRightTriggerDeadZone,
		// Token: 0x04026EFD RID: 159485
		RoleLangCustomNeedCover
	}
}
