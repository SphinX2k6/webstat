using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Launcher.Platform;

// Token: 0x02000E8E RID: 3726
[NullableContext(1)]
[Nullable(0)]
public class GameSettingsDefine : IStaticVariableResetter
{
	// Token: 0x06005AE8 RID: 23272 RVA: 0x00165356 File Offset: 0x00163556
	static GameSettingsDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GameSettingsDefine.CreateStaticDefaultValue), new Action(GameSettingsDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06005AE9 RID: 23273 RVA: 0x00165378 File Offset: 0x00163578
	public static void CreateStaticDefaultValue()
	{
		GameSettingsDefine.gameSettingsInitSourceTypePriority = new EGameSettingsInitSourceType[]
		{
			EGameSettingsInitSourceType.CloudOverride,
			EGameSettingsInitSourceType.RecommendQualityOverride,
			EGameSettingsInitSourceType.LoginOverride,
			EGameSettingsInitSourceType.InitOverride,
			EGameSettingsInitSourceType.LocalStorage,
			EGameSettingsInitSourceType.From1Dot3,
			EGameSettingsInitSourceType.From1Dot2,
			EGameSettingsInitSourceType.From1Dot1,
			EGameSettingsInitSourceType.From1Dot0,
			EGameSettingsInitSourceType.RenderFeatureDefaultConfigOverride,
			EGameSettingsInitSourceType.RenderFeatureDefaultConfig,
			EGameSettingsInitSourceType.CustomOverrideDefault,
			EGameSettingsInitSourceType.UserSettingIni,
			EGameSettingsInitSourceType.GameSettingDefaultConfig
		};
		GameSettingsDefine gameSettingsDefine = new GameSettingsDefine();
		GameSettingsDefine.function2GameSettings = new Dictionary<EFunction, IGameSettings>
		{
			{
				EFunction.MASTERVOLUMEFUNCTION,
				gameSettingsDefine.masterVolume
			},
			{
				EFunction.VOICEVOLUMEFUNCTION,
				gameSettingsDefine.voiceVolume
			},
			{
				EFunction.MUSICVOLUMEFUNCTION,
				gameSettingsDefine.musicVolume
			},
			{
				EFunction.SFXVOLUMEFUNCTION,
				gameSettingsDefine.sfxVolume
			},
			{
				EFunction.UIVOLUMEFUNCTION,
				gameSettingsDefine.uiVolume
			},
			{
				EFunction.AMBVOLUMEFUNCTION,
				gameSettingsDefine.ambVolume
			},
			{
				EFunction.BackendVolume,
				gameSettingsDefine.backendVolume
			},
			{
				EFunction.IMAGEQUALITY,
				gameSettingsDefine.imageQuality
			},
			{
				EFunction.DISPLAYMODE,
				gameSettingsDefine.displayMode
			},
			{
				EFunction.RESOLUTION,
				gameSettingsDefine.resolution
			},
			{
				EFunction.BRIGHTNESS,
				gameSettingsDefine.brightness
			},
			{
				EFunction.HIGHESTFPS,
				gameSettingsDefine.highestFps
			},
			{
				EFunction.SHADOWQUALITY,
				gameSettingsDefine.shadowQuality
			},
			{
				EFunction.NIAGARAQUALITY,
				gameSettingsDefine.niagaraQuality
			},
			{
				EFunction.IMAGEDETAIL,
				gameSettingsDefine.imageDetail
			},
			{
				EFunction.ANTIALISING,
				gameSettingsDefine.antiAliasing
			},
			{
				EFunction.SCENEAO,
				gameSettingsDefine.sceneAo
			},
			{
				EFunction.NPCDENSITY,
				gameSettingsDefine.npcDensity
			},
			{
				EFunction.NVIDIADLSS,
				gameSettingsDefine.nvidiaDlss
			},
			{
				EFunction.NVIDIADLSSFG,
				gameSettingsDefine.nvidiaDlssFg
			},
			{
				EFunction.NVIDIADLSSQUALITY,
				gameSettingsDefine.nvidiaDlssQuality
			},
			{
				EFunction.NVIDIADLSSSHARPNESS,
				gameSettingsDefine.nvidiaDlssSharpness
			},
			{
				EFunction.NVIDIAREFLEX,
				gameSettingsDefine.nvidiaReflex
			},
			{
				EFunction.HDR,
				gameSettingsDefine.hdr
			},
			{
				EFunction.FSR,
				gameSettingsDefine.fsr
			},
			{
				EFunction.XESS,
				gameSettingsDefine.xess
			},
			{
				EFunction.XESS_QUALITY,
				gameSettingsDefine.xessQuality
			},
			{
				EFunction.XESS2,
				gameSettingsDefine.xess2
			},
			{
				EFunction.XESS2_FG,
				gameSettingsDefine.xess2Fg
			},
			{
				EFunction.XESS2_QUALITY,
				gameSettingsDefine.xess2Quality
			},
			{
				EFunction.FSR3,
				gameSettingsDefine.fsr3
			},
			{
				EFunction.FSR3_FG,
				gameSettingsDefine.fsr3Fg
			},
			{
				EFunction.FSR3_QUALITY,
				gameSettingsDefine.fsr3Quality
			},
			{
				EFunction.METALFX,
				gameSettingsDefine.metalFxEnable
			},
			{
				EFunction.IRX,
				gameSettingsDefine.irx
			},
			{
				EFunction.BLOOM,
				gameSettingsDefine.bloom
			},
			{
				EFunction.VOLUMEFOG,
				gameSettingsDefine.volumeFog
			},
			{
				EFunction.VOLUMELIGHT,
				gameSettingsDefine.volumeLight
			},
			{
				EFunction.MOTIONBLUR,
				gameSettingsDefine.motionBlur
			},
			{
				EFunction.PCVSYNC,
				gameSettingsDefine.pcvSync
			},
			{
				EFunction.MOBILERESOLUTION,
				gameSettingsDefine.mobileResolution
			},
			{
				EFunction.SUPERRESOLUTION,
				gameSettingsDefine.superResolution
			},
			{
				EFunction.TEXTLANGUAGE,
				gameSettingsDefine.textLanguage
			},
			{
				EFunction.VOICELANGUAGE,
				gameSettingsDefine.voiceLanguage
			},
			{
				EFunction.VOICEPACKMANAGER,
				gameSettingsDefine.voicePackManager
			},
			{
				EFunction.VOICEROLECUSTOM,
				gameSettingsDefine.voiceRoleCustomManager
			},
			{
				EFunction.ADVICESETTING,
				gameSettingsDefine.adviceSetting
			},
			{
				EFunction.GENDERSETTING,
				gameSettingsDefine.genderSetting
			},
			{
				EFunction.HorizontalViewSensitivity,
				gameSettingsDefine.horizontalViewSensitivity
			},
			{
				EFunction.VerticalViewSensitivity,
				gameSettingsDefine.verticalViewSensitivity
			},
			{
				EFunction.AimHorizontalViewSensitivity,
				gameSettingsDefine.aimHorizontalViewSensitivity
			},
			{
				EFunction.AimVerticalViewSensitivity,
				gameSettingsDefine.aimVerticalViewSensitivity
			},
			{
				EFunction.CameraShakeStrength,
				gameSettingsDefine.cameraShakeStrength
			},
			{
				EFunction.MobileHorizontalViewSensitivity,
				gameSettingsDefine.mobileHorizontalViewSensitivity
			},
			{
				EFunction.MobileVerticalViewSensitivity,
				gameSettingsDefine.mobileVerticalViewSensitivity
			},
			{
				EFunction.MobileAimHorizontalViewSensitivity,
				gameSettingsDefine.mobileAimHorizontalViewSensitivity
			},
			{
				EFunction.MobileAimVerticalViewSensitivity,
				gameSettingsDefine.mobileAimVerticalViewSensitivity
			},
			{
				EFunction.CommonSpringArmLength,
				gameSettingsDefine.commonSpringArmLength
			},
			{
				EFunction.FightSpringArmLength,
				gameSettingsDefine.fightSpringArmLength
			},
			{
				EFunction.ResetFocusEnable,
				gameSettingsDefine.resetFocusEnable
			},
			{
				EFunction.IsSidestepCameraEnable,
				gameSettingsDefine.isSidestepCameraEnable
			},
			{
				EFunction.IsSoftLockCameraEnable,
				gameSettingsDefine.isSoftLockCameraEnable
			},
			{
				EFunction.JoystickShakeStrength,
				gameSettingsDefine.joystickShakeStrength
			},
			{
				EFunction.JoystickShakeType,
				gameSettingsDefine.joystickShakeType
			},
			{
				EFunction.WalkOrRunRate,
				gameSettingsDefine.walkOrRunRate
			},
			{
				EFunction.LogUpload,
				gameSettingsDefine.logUploadSetting
			},
			{
				EFunction.JoystickMode,
				gameSettingsDefine.joystickMode
			},
			{
				EFunction.MobileButtonCustom,
				gameSettingsDefine.mobileButtonCustom
			},
			{
				EFunction.SkillButtonMode,
				gameSettingsDefine.skillButtonMode
			},
			{
				EFunction.CdKey,
				gameSettingsDefine.cdKey
			},
			{
				EFunction.UserCenterDomestic,
				gameSettingsDefine.userCenterDomestic
			},
			{
				EFunction.TermsOfUseDomestic,
				gameSettingsDefine.termsOfUseDomestic
			},
			{
				EFunction.PrivacyPolicyDomestic,
				gameSettingsDefine.privacyPolicyDomestic
			},
			{
				EFunction.ChildrenPrivacy,
				gameSettingsDefine.childrenPrivacy
			},
			{
				EFunction.ThirdPartyInfo,
				gameSettingsDefine.thirdPartyInfo
			},
			{
				EFunction.TermsOfUseOverSeas,
				gameSettingsDefine.termsOfUseOverSeas
			},
			{
				EFunction.PrivacyPolicyOverSeas,
				gameSettingsDefine.privacyPolicyOverSeas
			},
			{
				EFunction.PrivacyPolicySetting,
				gameSettingsDefine.privacyPolicySetting
			},
			{
				EFunction.License,
				gameSettingsDefine.licenseSetting
			},
			{
				EFunction.UserCenterOverseas,
				gameSettingsDefine.userCenterOverseas
			},
			{
				EFunction.PushMode,
				gameSettingsDefine.pushMode
			},
			{
				EFunction.AimAssist,
				gameSettingsDefine.aimAssist
			},
			{
				EFunction.KeyboardLockEnemyMode,
				gameSettingsDefine.keyboardLockEnemyMode
			},
			{
				EFunction.HorizontalViewRevert,
				gameSettingsDefine.horizontalViewRevert
			},
			{
				EFunction.VerticalViewRevert,
				gameSettingsDefine.verticalViewRevert
			},
			{
				EFunction.SkillLockEnemyMode,
				gameSettingsDefine.skillLockEnemyMode
			},
			{
				EFunction.GamepadLockEnemyMode,
				gameSettingsDefine.gamepadLockEnemyMode
			},
			{
				EFunction.EnemyHitDisplayMode,
				gameSettingsDefine.enemyHitDisplayMode
			},
			{
				EFunction.PlayStationOnly,
				gameSettingsDefine.playStationOnly
			},
			{
				EFunction.MobileGamepadMode,
				gameSettingsDefine.mobileGamepadMode
			},
			{
				EFunction.AutoAdjustImageQuality,
				gameSettingsDefine.autoAdjustImageQuality
			},
			{
				EFunction.ShowDamage,
				gameSettingsDefine.showDamage
			},
			{
				EFunction.DynamicBones,
				gameSettingsDefine.dynamicBones
			},
			{
				EFunction.UIPureMode,
				gameSettingsDefine.uiPureMode
			},
			{
				EFunction.FlyControlMode,
				gameSettingsDefine.flyControlMode
			},
			{
				EFunction.DOLBYATOMS,
				gameSettingsDefine.dolbyAtmos
			},
			{
				EFunction.FlowAdaptation,
				gameSettingsDefine.flowAdaptation
			},
			{
				EFunction.RayTracing,
				gameSettingsDefine.rayTracing
			},
			{
				EFunction.RayTracedReflection,
				gameSettingsDefine.rayTracedReflection
			},
			{
				EFunction.RayTracedGI,
				gameSettingsDefine.rayTracedGI
			},
			{
				EFunction.RayTracedShadow,
				gameSettingsDefine.rayTracedShadow
			},
			{
				EFunction.TeammateFx,
				gameSettingsDefine.teammateFx
			},
			{
				EFunction.Saturation,
				gameSettingsDefine.saturation
			},
			{
				EFunction.Contrast,
				gameSettingsDefine.contrast
			},
			{
				EFunction.Filter,
				gameSettingsDefine.filter
			},
			{
				EFunction.SkinDamageMode,
				gameSettingsDefine.skinDamageMode
			},
			{
				EFunction.AdrenoFME,
				gameSettingsDefine.adrenoFME
			},
			{
				EFunction.BasicGraphicSetting,
				gameSettingsDefine.basicGraphicSetting
			},
			{
				EFunction.Vulkan,
				gameSettingsDefine.vulkan
			},
			{
				EFunction.ResDownLoad,
				gameSettingsDefine.resDownLoad
			},
			{
				EFunction.ResClear,
				gameSettingsDefine.resClear
			},
			{
				EFunction.AutoRun,
				gameSettingsDefine.autoRun
			},
			{
				EFunction.AutoSprint,
				gameSettingsDefine.autoSprint
			},
			{
				EFunction.ShowOtherName,
				gameSettingsDefine.showOtherName
			},
			{
				EFunction.WaterInteract,
				gameSettingsDefine.waterInteract
			},
			{
				EFunction.VegetationDither,
				gameSettingsDefine.vegetationDither
			},
			{
				EFunction.VegetationDensity,
				gameSettingsDefine.vegetationDensity
			},
			{
				EFunction.ImageDisplayMode,
				gameSettingsDefine.imageDisplayMode
			},
			{
				EFunction.EyeProtection,
				gameSettingsDefine.eyeProtection
			},
			{
				EFunction.EyeProtectionMode,
				gameSettingsDefine.eyeProtectionMode
			},
			{
				EFunction.EyeProtectionTemp,
				gameSettingsDefine.eyeProtectionTemp
			},
			{
				EFunction.EyeProtectionStrength,
				gameSettingsDefine.eyeProtectionStrength
			},
			{
				EFunction.EyeProtectionBrightness,
				gameSettingsDefine.eyeProtectionBrightness
			},
			{
				EFunction.EyeProtectionTexture,
				gameSettingsDefine.eyeProtectionTexture
			},
			{
				EFunction.VersionCheck,
				gameSettingsDefine.versionCheck
			},
			{
				EFunction.AutoExposure,
				gameSettingsDefine.autoExposure
			},
			{
				EFunction.AdjustiveGamePadTrigger,
				gameSettingsDefine.adjustiveGamePadTrigger
			},
			{
				EFunction.GamepadLeftStickDeadZone,
				gameSettingsDefine.gamepadLeftStickDeadZone
			},
			{
				EFunction.GamepadRightStickDeadZone,
				gameSettingsDefine.gamepadRightStickDeadZone
			},
			{
				EFunction.GamepadLeftTriggerDeadZone,
				gameSettingsDefine.gamepadLeftTriggerDeadZone
			},
			{
				EFunction.GamepadRightTriggerDeadZone,
				gameSettingsDefine.gamepadRightTriggerDeadZone
			},
			{
				EFunction.MotorAutoLongPressSpeedUp,
				gameSettingsDefine.motorAccleratePressType
			},
			{
				EFunction.MotorAutoAcceleratorSettingEnable,
				gameSettingsDefine.motorAutoAcceleratorSettingEnable
			},
			{
				EFunction.MotorDriftAcceleratorSettingEnable,
				gameSettingsDefine.motorDriftAcceleratorSettingEnable
			},
			{
				EFunction.MotorDriftModel,
				gameSettingsDefine.motorDriftModel
			},
			{
				EFunction.MotorHudVisible,
				gameSettingsDefine.motorHudVisible
			},
			{
				EFunction.SubTitleOption,
				gameSettingsDefine.subTitleOption
			},
			{
				EFunction.MotorIsDynamicJoystick,
				gameSettingsDefine.motorTouchFixedPosition
			},
			{
				EFunction.MotorMobileButtonCustom,
				gameSettingsDefine.motorMobileButtonCustom
			},
			{
				EFunction.MotorMobileButtonLayout,
				gameSettingsDefine.motorMobileButtonLayout
			},
			{
				EFunction.DeviceInfo,
				gameSettingsDefine.deviceInfo
			},
			{
				EFunction.UiBrightness,
				gameSettingsDefine.uiBrightness
			},
			{
				EFunction.PeakBrightness,
				gameSettingsDefine.peakBrightness
			},
			{
				EFunction.LOADINGRANGESCALELEVEL,
				gameSettingsDefine.loadingRangeScaleLevel
			},
			{
				EFunction.MotorFlyControlMode,
				gameSettingsDefine.motorFlyControlMode
			},
			{
				EFunction.AnisoLevel,
				gameSettingsDefine.anisoLevel
			},
			{
				EFunction.XboxOnly,
				gameSettingsDefine.xboxOnly
			}
		};
	}

	// Token: 0x06005AEA RID: 23274 RVA: 0x00165C96 File Offset: 0x00163E96
	public static void ResetStaticDefaultValue()
	{
		GameSettingsDefine.gameSettingsInitSourceTypePriority = null;
		GameSettingsDefine.function2GameSettings = null;
	}

	// Token: 0x06005AEB RID: 23275 RVA: 0x00165CA4 File Offset: 0x00163EA4
	public GameSettingsDefine()
	{
		GameSettings gameSettings = new GameSettings();
		gameSettings.GameSettingId = EFunction.MASTERVOLUMEFUNCTION;
		gameSettings.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MasterVolume;
		gameSettings.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolume((float)value, "volume_master"));
		gameSettings.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolume("volume_master"));
		this.masterVolume = gameSettings;
		GameSettings gameSettings2 = new GameSettings();
		gameSettings2.GameSettingId = EFunction.VOICEVOLUMEFUNCTION;
		gameSettings2.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VoiceVolume;
		gameSettings2.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolume((float)value, "volume_voice"));
		gameSettings2.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolume("volume_voice"));
		this.voiceVolume = gameSettings2;
		GameSettings gameSettings3 = new GameSettings();
		gameSettings3.GameSettingId = EFunction.MUSICVOLUMEFUNCTION;
		gameSettings3.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MusicVolume;
		gameSettings3.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolume((float)value, "volume_music"));
		gameSettings3.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolume("volume_music"));
		this.musicVolume = gameSettings3;
		GameSettings gameSettings4 = new GameSettings();
		gameSettings4.GameSettingId = EFunction.SFXVOLUMEFUNCTION;
		gameSettings4.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.SFXVolume;
		gameSettings4.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolume((float)value, "volume_sfx"));
		gameSettings4.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolume("volume_sfx"));
		this.sfxVolume = gameSettings4;
		GameSettings gameSettings5 = new GameSettings();
		gameSettings5.GameSettingId = EFunction.UIVOLUMEFUNCTION;
		gameSettings5.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.UIVolume;
		gameSettings5.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolume((float)value, "volume_sfx_ui"));
		gameSettings5.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolume("volume_sfx_ui"));
		this.uiVolume = gameSettings5;
		GameSettings gameSettings6 = new GameSettings();
		gameSettings6.GameSettingId = EFunction.AMBVOLUMEFUNCTION;
		gameSettings6.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AMBVolume;
		gameSettings6.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolume((float)value, "volume_sfx_amb"));
		gameSettings6.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolume("volume_sfx_amb"));
		this.ambVolume = gameSettings6;
		GameSettings gameSettings7 = new GameSettings();
		gameSettings7.GameSettingId = EFunction.BackendVolume;
		gameSettings7.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.BackendVolume;
		gameSettings7.DumpCallback = (() => "");
		this.backendVolume = gameSettings7;
		GameSettings gameSettings8 = new GameSettings();
		gameSettings8.GameSettingId = EFunction.IMAGEQUALITY;
		gameSettings8.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.ImageQuality;
		gameSettings8.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			bool result = GameSettingsUtils.ApplyImageQualityOnly(value);
			GameSettingsUtils.ApplySceneLightQuality(value);
			return result;
		};
		gameSettings8.HandleDoneCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.SetImageQualityWithValue, value);
			Singleton<EventSystem>.Instance.Emit(EEventName.SetImageQuality);
		};
		gameSettings8.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpImageQuality());
		this.imageQuality = gameSettings8;
		GameSettings gameSettings9 = new GameSettings();
		gameSettings9.GameSettingId = EFunction.LOADINGRANGESCALELEVEL;
		gameSettings9.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.LoadingRangeScaleLevel;
		gameSettings9.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyLoadingRangeScaleLevel(value));
		gameSettings9.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpLoadingRangeScaleLevel());
		this.loadingRangeScaleLevel = gameSettings9;
		GameSettings gameSettings10 = new GameSettings();
		gameSettings10.GameSettingId = EFunction.DISPLAYMODE;
		gameSettings10.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.PcWindowMode;
		gameSettings10.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyDisplayMode(value));
		gameSettings10.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpDisplayMode());
		this.displayMode = gameSettings10;
		GameSettings gameSettings11 = new GameSettings();
		gameSettings11.GameSettingId = EFunction.RESOLUTION;
		gameSettings11.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.PcResolutionIndex;
		gameSettings11.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyResolution(value));
		gameSettings11.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpResolution());
		this.resolution = gameSettings11;
		GameSettings gameSettings12 = new GameSettings();
		gameSettings12.GameSettingId = EFunction.BRIGHTNESS;
		gameSettings12.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Brightness;
		gameSettings12.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyBrightness((float)value));
		gameSettings12.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpBrightness());
		this.brightness = gameSettings12;
		GameSettings gameSettings13 = new GameSettings();
		gameSettings13.GameSettingId = EFunction.HIGHESTFPS;
		gameSettings13.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.CustomFrameRate;
		gameSettings13.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyHighestFps(value));
		gameSettings13.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpHighestFps());
		this.highestFps = gameSettings13;
		GameSettings gameSettings14 = new GameSettings();
		gameSettings14.GameSettingId = EFunction.SHADOWQUALITY;
		gameSettings14.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.ShadowQuality;
		gameSettings14.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyShadowQuality(value));
		gameSettings14.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpShadowQuality());
		this.shadowQuality = gameSettings14;
		GameSettings gameSettings15 = new GameSettings();
		gameSettings15.GameSettingId = EFunction.NIAGARAQUALITY;
		gameSettings15.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.NiagaraQuality;
		gameSettings15.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyNiagaraQuality(value));
		gameSettings15.HandleDoneCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.SetNiagaraQuality);
		};
		gameSettings15.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpNiagaraQuality());
		this.niagaraQuality = gameSettings15;
		GameSettings gameSettings16 = new GameSettings();
		gameSettings16.GameSettingId = EFunction.IMAGEDETAIL;
		gameSettings16.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.ImageDetail;
		gameSettings16.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyImageDetail(value));
		gameSettings16.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpImageDetail());
		this.imageDetail = gameSettings16;
		GameSettings gameSettings17 = new GameSettings();
		gameSettings17.GameSettingId = EFunction.ANTIALISING;
		gameSettings17.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AntiAliasing;
		gameSettings17.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyAntiAliasing(value));
		gameSettings17.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAntiAliasing());
		this.antiAliasing = gameSettings17;
		GameSettings gameSettings18 = new GameSettings();
		gameSettings18.GameSettingId = EFunction.SCENEAO;
		gameSettings18.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.SceneAo;
		gameSettings18.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplySceneAo(value));
		gameSettings18.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpSceneAo());
		this.sceneAo = gameSettings18;
		GameSettings gameSettings19 = new GameSettings();
		gameSettings19.GameSettingId = EFunction.NPCDENSITY;
		gameSettings19.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.NpcDensity;
		gameSettings19.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyNpcDensity(value));
		gameSettings19.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpNpcDensity());
		this.npcDensity = gameSettings19;
		GameSettings gameSettings20 = new GameSettings();
		gameSettings20.GameSettingId = EFunction.NVIDIADLSS;
		gameSettings20.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.NvidiaSuperSamplingEnable;
		Func<int, EGameSettingsApplyReason, bool> applyCallback;
		if ((applyCallback = GameSettingsDefine.<>O.<0>__ApplyNvidiaSuperSamplingEnable) == null)
		{
			applyCallback = (GameSettingsDefine.<>O.<0>__ApplyNvidiaSuperSamplingEnable = new Func<int, EGameSettingsApplyReason, bool>(GameSettingsUtils.ApplyNvidiaSuperSamplingEnable));
		}
		gameSettings20.ApplyCallback = applyCallback;
		gameSettings20.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpNvidiaDlss());
		this.nvidiaDlss = gameSettings20;
		GameSettings gameSettings21 = new GameSettings();
		gameSettings21.GameSettingId = EFunction.NVIDIADLSSFG;
		gameSettings21.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.NvidiaSuperSamplingFrameGenerate;
		gameSettings21.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyNvidiaSuperSamplingFrameGenerate(value));
		gameSettings21.HandleDoneCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.SetDLSSFGWithValue, value);
		};
		gameSettings21.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpNvidiaDlssFg());
		this.nvidiaDlssFg = gameSettings21;
		GameSettings gameSettings22 = new GameSettings();
		gameSettings22.GameSettingId = EFunction.NVIDIADLSSQUALITY;
		gameSettings22.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.NvidiaSuperSamplingQuality;
		gameSettings22.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyNvidiaSuperSamplingQuality(value));
		gameSettings22.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpNvidiaDlssQuality());
		this.nvidiaDlssQuality = gameSettings22;
		GameSettings gameSettings23 = new GameSettings();
		gameSettings23.GameSettingId = EFunction.NVIDIADLSSSHARPNESS;
		gameSettings23.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.NvidiaSuperSamplingSharpness;
		gameSettings23.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyNvidiaSuperSamplingSharpness((float)value));
		gameSettings23.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpNvidiaDlssSharpness());
		this.nvidiaDlssSharpness = gameSettings23;
		GameSettings gameSettings24 = new GameSettings();
		gameSettings24.GameSettingId = EFunction.NVIDIAREFLEX;
		gameSettings24.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.NvidiaReflex;
		gameSettings24.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyNvidiaReflex(value));
		gameSettings24.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpNvidiaReflex());
		this.nvidiaReflex = gameSettings24;
		GameSettings gameSettings25 = new GameSettings();
		gameSettings25.GameSettingId = EFunction.HDR;
		gameSettings25.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Hdr;
		gameSettings25.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyHdrEnable(value));
		gameSettings25.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpHdr());
		this.hdr = gameSettings25;
		GameSettings gameSettings26 = new GameSettings();
		gameSettings26.GameSettingId = EFunction.FSR;
		gameSettings26.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.FsrEnable;
		gameSettings26.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyFsrEnable(value));
		gameSettings26.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpFsr());
		this.fsr = gameSettings26;
		GameSettings gameSettings27 = new GameSettings();
		gameSettings27.GameSettingId = EFunction.XESS;
		gameSettings27.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.XessEnable;
		gameSettings27.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyXessEnable(value));
		gameSettings27.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpXess());
		this.xess = gameSettings27;
		GameSettings gameSettings28 = new GameSettings();
		gameSettings28.GameSettingId = EFunction.XESS_QUALITY;
		gameSettings28.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.XessQuality;
		gameSettings28.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyXessQuality(value));
		gameSettings28.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpXessQuality());
		this.xessQuality = gameSettings28;
		GameSettings gameSettings29 = new GameSettings();
		gameSettings29.GameSettingId = EFunction.XESS2;
		gameSettings29.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Xess2Enable;
		gameSettings29.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyXess2Enable(value));
		gameSettings29.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpXess2());
		this.xess2 = gameSettings29;
		GameSettings gameSettings30 = new GameSettings();
		gameSettings30.GameSettingId = EFunction.XESS2_FG;
		gameSettings30.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Xess2Fg;
		gameSettings30.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyXess2Fg(value));
		gameSettings30.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpXess2Fg());
		this.xess2Fg = gameSettings30;
		GameSettings gameSettings31 = new GameSettings();
		gameSettings31.GameSettingId = EFunction.XESS2_QUALITY;
		gameSettings31.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Xess2Quality;
		gameSettings31.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyXess2Quality(value));
		gameSettings31.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpXess2Quality());
		this.xess2Quality = gameSettings31;
		GameSettings gameSettings32 = new GameSettings();
		gameSettings32.GameSettingId = EFunction.FSR3;
		gameSettings32.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Fsr3Enable;
		gameSettings32.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyFsr3Enable(value));
		gameSettings32.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpFsr3());
		this.fsr3 = gameSettings32;
		GameSettings gameSettings33 = new GameSettings();
		gameSettings33.GameSettingId = EFunction.FSR3_FG;
		gameSettings33.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Fsr3Fg;
		gameSettings33.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyFsr3Fg(value, EFFXFIApplyMode.Default));
		gameSettings33.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpFsr3Fg());
		this.fsr3Fg = gameSettings33;
		GameSettings gameSettings34 = new GameSettings();
		gameSettings34.GameSettingId = EFunction.FSR3_QUALITY;
		gameSettings34.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Fsr3Quality;
		gameSettings34.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyFsr3Quality(value));
		gameSettings34.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpFsr3Quality());
		this.fsr3Quality = gameSettings34;
		GameSettings gameSettings35 = new GameSettings();
		gameSettings35.GameSettingId = EFunction.METALFX;
		gameSettings35.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MetalFxEnable;
		gameSettings35.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyMetalFxEnable(value));
		gameSettings35.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpMetalFxEnable());
		this.metalFxEnable = gameSettings35;
		GameSettings gameSettings36 = new GameSettings();
		gameSettings36.GameSettingId = EFunction.IRX;
		gameSettings36.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.IrxEnable;
		gameSettings36.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyIrxEnable(value));
		gameSettings36.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpIrx());
		this.irx = gameSettings36;
		GameSettings gameSettings37 = new GameSettings();
		gameSettings37.GameSettingId = EFunction.BLOOM;
		gameSettings37.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.BloomEnable;
		gameSettings37.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyBloomEnable(value));
		gameSettings37.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpBloom());
		this.bloom = gameSettings37;
		GameSettings gameSettings38 = new GameSettings();
		gameSettings38.GameSettingId = EFunction.VOLUMEFOG;
		gameSettings38.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VolumeFog;
		gameSettings38.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolumeFog(value));
		gameSettings38.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolumeFog());
		this.volumeFog = gameSettings38;
		GameSettings gameSettings39 = new GameSettings();
		gameSettings39.GameSettingId = EFunction.VOLUMELIGHT;
		gameSettings39.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VolumeLight;
		gameSettings39.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVolumeLight(value));
		gameSettings39.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolumeLight());
		this.volumeLight = gameSettings39;
		GameSettings gameSettings40 = new GameSettings();
		gameSettings40.GameSettingId = EFunction.MOTIONBLUR;
		gameSettings40.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotionBlur;
		gameSettings40.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyMotionBlur((float)value));
		gameSettings40.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpMotionBlur());
		this.motionBlur = gameSettings40;
		GameSettings gameSettings41 = new GameSettings();
		gameSettings41.GameSettingId = EFunction.PCVSYNC;
		gameSettings41.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.PcVsync;
		gameSettings41.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyPcVsync(value));
		gameSettings41.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpPcVsync());
		this.pcvSync = gameSettings41;
		GameSettings gameSettings42 = new GameSettings();
		gameSettings42.GameSettingId = EFunction.MOBILERESOLUTION;
		gameSettings42.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MobileResolution;
		gameSettings42.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyMobileResolution(value));
		gameSettings42.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpMobileResolution());
		this.mobileResolution = gameSettings42;
		GameSettings gameSettings43 = new GameSettings();
		gameSettings43.GameSettingId = EFunction.SUPERRESOLUTION;
		gameSettings43.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.SuperResolution;
		gameSettings43.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => true);
		gameSettings43.DumpCallback = (() => "[DumpVoicePackManager]this is just a null entry");
		this.superResolution = gameSettings43;
		GameSettings gameSettings44 = new GameSettings();
		gameSettings44.GameSettingId = EFunction.TEXTLANGUAGE;
		gameSettings44.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.TextLanguage;
		gameSettings44.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (reason == EGameSettingsApplyReason.WhenGameStart)
			{
				return GameSettingsUtils.ApplyTextLanguageOnGameStart(value);
			}
			return GameSettingsUtils.ApplyTextLanguage(value);
		};
		gameSettings44.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpTextLanguage());
		this.textLanguage = gameSettings44;
		GameSettings gameSettings45 = new GameSettings();
		gameSettings45.GameSettingId = EFunction.VOICELANGUAGE;
		gameSettings45.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VoiceLanguage;
		gameSettings45.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyLanguageAudio(value));
		gameSettings45.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVoiceLanguage());
		this.voiceLanguage = gameSettings45;
		GameSettings gameSettings46 = new GameSettings();
		gameSettings46.GameSettingId = EFunction.VOICEPACKMANAGER;
		gameSettings46.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings46.DumpCallback = (() => "[DumpVoicePackManager]this is just a switch entry");
		this.voicePackManager = gameSettings46;
		GameSettings gameSettings47 = new GameSettings();
		gameSettings47.GameSettingId = EFunction.VOICEROLECUSTOM;
		gameSettings47.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings47.DumpCallback = (() => "[DumpVoicePackManager]this is just a switch entry");
		this.voiceRoleCustomManager = gameSettings47;
		GameSettings gameSettings48 = new GameSettings();
		gameSettings48.GameSettingId = EFunction.ADVICESETTING;
		gameSettings48.GetCallbackOrGlobalKey = new Func<int>(() => (ModelBase<AdviceModel>.Instance.GetAdviceShowSetting() > false) ? 1 : 0);
		gameSettings48.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (reason == EGameSettingsApplyReason.WhenUi)
			{
				ControllerBase<AdviceController>.Instance.RequestSetAdviceShowState(value == 1);
			}
			return false;
		};
		gameSettings48.DumpCallback = (() => "[DumpAdviceSetting]same to getter");
		this.adviceSetting = gameSettings48;
		GameSettings gameSettings49 = new GameSettings();
		gameSettings49.GameSettingId = EFunction.GENDERSETTING;
		gameSettings49.GetCallbackOrGlobalKey = new Func<int>(delegate()
		{
			int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
			if (curSelectMainRoleId == null)
			{
				return 0;
			}
			MainRoleConfig? mainRoleById = ConfigBase<RoleConfig>.Instance.GetMainRoleById(curSelectMainRoleId.Value);
			if (mainRoleById == null)
			{
				return 0;
			}
			return mainRoleById.Value.Gender;
		});
		gameSettings49.DumpCallback = (() => "[DumpGenderSetting]same to getter");
		this.genderSetting = gameSettings49;
		GameSettings gameSettings50 = new GameSettings();
		gameSettings50.GameSettingId = EFunction.HorizontalViewSensitivity;
		gameSettings50.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.HorizontalViewSensitivity;
		gameSettings50.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				GameSettingsUtils.ApplyMobileHorizontalViewSensitivity((float)value);
			}
			else
			{
				GameSettingsUtils.ApplyHorizontalViewSensitivity((float)value);
			}
			return true;
		};
		gameSettings50.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpHorizontalViewSensitivity());
		this.horizontalViewSensitivity = gameSettings50;
		GameSettings gameSettings51 = new GameSettings();
		gameSettings51.GameSettingId = EFunction.VerticalViewSensitivity;
		gameSettings51.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VerticalViewSensitivity;
		gameSettings51.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				GameSettingsUtils.ApplyMobileVerticalViewSensitivity((float)value);
			}
			else
			{
				GameSettingsUtils.ApplyVerticalViewSensitivity((float)value);
			}
			return true;
		};
		gameSettings51.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVerticalViewSensitivity());
		this.verticalViewSensitivity = gameSettings51;
		GameSettings gameSettings52 = new GameSettings();
		gameSettings52.GameSettingId = EFunction.AimHorizontalViewSensitivity;
		gameSettings52.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AimHorizontalViewSensitivity;
		gameSettings52.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				GameSettingsUtils.ApplyMobileAimHorizontalViewSensitivity((float)value);
			}
			else
			{
				GameSettingsUtils.ApplyAimHorizontalViewSensitivity((float)value);
			}
			return true;
		};
		gameSettings52.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAimHorizontalViewSensitivity());
		this.aimHorizontalViewSensitivity = gameSettings52;
		GameSettings gameSettings53 = new GameSettings();
		gameSettings53.GameSettingId = EFunction.AimVerticalViewSensitivity;
		gameSettings53.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AimVerticalViewSensitivity;
		gameSettings53.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				GameSettingsUtils.ApplyMobileAimVerticalViewSensitivity((float)value);
			}
			else
			{
				GameSettingsUtils.ApplyAimVerticalViewSensitivity((float)value);
			}
			return true;
		};
		gameSettings53.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAimVerticalViewSensitivity());
		this.aimVerticalViewSensitivity = gameSettings53;
		GameSettings gameSettings54 = new GameSettings();
		gameSettings54.GameSettingId = EFunction.CameraShakeStrength;
		gameSettings54.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.CameraShakeStrength;
		gameSettings54.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyCameraShakeStrength(value);
			return true;
		};
		gameSettings54.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpCameraShakeStrength());
		this.cameraShakeStrength = gameSettings54;
		GameSettings gameSettings55 = new GameSettings();
		gameSettings55.GameSettingId = EFunction.MobileHorizontalViewSensitivity;
		gameSettings55.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MobileHorizontalViewSensitivity;
		gameSettings55.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMobileHorizontalViewSensitivity((float)value);
			return true;
		};
		gameSettings55.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpHorizontalViewSensitivity());
		this.mobileHorizontalViewSensitivity = gameSettings55;
		GameSettings gameSettings56 = new GameSettings();
		gameSettings56.GameSettingId = EFunction.MobileVerticalViewSensitivity;
		gameSettings56.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MobileVerticalViewSensitivity;
		gameSettings56.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMobileVerticalViewSensitivity((float)value);
			return true;
		};
		gameSettings56.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVerticalViewSensitivity());
		this.mobileVerticalViewSensitivity = gameSettings56;
		GameSettings gameSettings57 = new GameSettings();
		gameSettings57.GameSettingId = EFunction.MobileAimHorizontalViewSensitivity;
		gameSettings57.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MobileAimHorizontalViewSensitivity;
		gameSettings57.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMobileAimHorizontalViewSensitivity((float)value);
			return true;
		};
		gameSettings57.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAimHorizontalViewSensitivity());
		this.mobileAimHorizontalViewSensitivity = gameSettings57;
		GameSettings gameSettings58 = new GameSettings();
		gameSettings58.GameSettingId = EFunction.MobileAimVerticalViewSensitivity;
		gameSettings58.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MobileAimVerticalViewSensitivity;
		gameSettings58.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMobileAimVerticalViewSensitivity((float)value);
			return true;
		};
		gameSettings58.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAimVerticalViewSensitivity());
		this.mobileAimVerticalViewSensitivity = gameSettings58;
		GameSettings gameSettings59 = new GameSettings();
		gameSettings59.GameSettingId = EFunction.CommonSpringArmLength;
		gameSettings59.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.CommonSpringArmLength;
		gameSettings59.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyCommonSpringArmLength((float)value);
			return true;
		};
		gameSettings59.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpCommonSpringArmLength());
		this.commonSpringArmLength = gameSettings59;
		GameSettings gameSettings60 = new GameSettings();
		gameSettings60.GameSettingId = EFunction.FightSpringArmLength;
		gameSettings60.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.FightSpringArmLength;
		gameSettings60.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyFightSpringArmLength((float)value);
			return true;
		};
		gameSettings60.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpFightSpringArmLength());
		this.fightSpringArmLength = gameSettings60;
		GameSettings gameSettings61 = new GameSettings();
		gameSettings61.GameSettingId = EFunction.ResetFocusEnable;
		gameSettings61.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.IsResetFocusEnable;
		gameSettings61.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyResetFocusEnable(value);
			return true;
		};
		gameSettings61.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpResetFocusEnable());
		this.resetFocusEnable = gameSettings61;
		GameSettings gameSettings62 = new GameSettings();
		gameSettings62.GameSettingId = EFunction.IsSidestepCameraEnable;
		gameSettings62.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.IsSidestepCameraEnable;
		gameSettings62.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyIsSidestepCameraEnable(value);
			return true;
		};
		gameSettings62.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpIsSidestepCameraEnable());
		this.isSidestepCameraEnable = gameSettings62;
		GameSettings gameSettings63 = new GameSettings();
		gameSettings63.GameSettingId = EFunction.IsSoftLockCameraEnable;
		gameSettings63.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.IsSoftLockCameraEnable;
		gameSettings63.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyIsSoftLockCameraEnable(value);
			return true;
		};
		gameSettings63.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpIsSoftLockCameraEnable());
		this.isSoftLockCameraEnable = gameSettings63;
		GameSettings gameSettings64 = new GameSettings();
		gameSettings64.GameSettingId = EFunction.JoystickShakeStrength;
		gameSettings64.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.JoystickShakeStrength;
		gameSettings64.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyJoystickShakeStrength(value));
		gameSettings64.DumpCallback = (() => "[DumpJoystickShakeStrength]no way to dump");
		this.joystickShakeStrength = gameSettings64;
		GameSettings gameSettings65 = new GameSettings();
		gameSettings65.GameSettingId = EFunction.JoystickShakeType;
		gameSettings65.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.JoystickShakeType;
		gameSettings65.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyJoystickShakeType(value));
		gameSettings65.DumpCallback = (() => "[DumpJoystickShakeType]no way to dump");
		this.joystickShakeType = gameSettings65;
		GameSettings gameSettings66 = new GameSettings();
		gameSettings66.GameSettingId = EFunction.WalkOrRunRate;
		gameSettings66.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.WalkOrRunRate;
		gameSettings66.ApplyCallbackFloat = delegate(float value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyWalkOrRunRate(value);
			return true;
		};
		gameSettings66.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpWalkOrRunRate());
		this.walkOrRunRate = gameSettings66;
		GameSettings gameSettings67 = new GameSettings();
		gameSettings67.GameSettingId = EFunction.JoystickMode;
		gameSettings67.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.JoystickMode;
		gameSettings67.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyJoystickMode(value);
			return true;
		};
		gameSettings67.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpJoystickMode());
		this.joystickMode = gameSettings67;
		GameSettings gameSettings68 = new GameSettings();
		gameSettings68.GameSettingId = EFunction.MobileButtonCustom;
		gameSettings68.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings68.DumpCallback = (() => "[mobileButtonCustom]this is just a switch entry");
		this.mobileButtonCustom = gameSettings68;
		GameSettings gameSettings69 = new GameSettings();
		gameSettings69.GameSettingId = EFunction.SkillButtonMode;
		gameSettings69.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.IsAutoSwitchSkillButtonMode;
		gameSettings69.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyAutoSwitchSkillButtonMode(value);
			return true;
		};
		gameSettings69.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpSkillButtonMode());
		this.skillButtonMode = gameSettings69;
		GameSettings gameSettings70 = new GameSettings();
		gameSettings70.GameSettingId = EFunction.CdKey;
		gameSettings70.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings70.DumpCallback = (() => "[DumpCdKey]this is just a switch entry");
		this.cdKey = gameSettings70;
		GameSettings gameSettings71 = new GameSettings();
		gameSettings71.GameSettingId = EFunction.ResDownLoad;
		gameSettings71.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings71.DumpCallback = (() => "[resDownLoad]SubPackageDownLoad");
		this.resDownLoad = gameSettings71;
		GameSettings gameSettings72 = new GameSettings();
		gameSettings72.GameSettingId = EFunction.ResClear;
		gameSettings72.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings72.DumpCallback = (() => "[resClear]SubPackageDownLoadClear");
		this.resClear = gameSettings72;
		GameSettings gameSettings73 = new GameSettings();
		gameSettings73.GameSettingId = EFunction.PushMode;
		gameSettings73.GetCallbackOrGlobalKey = new Func<int>(() => (ControllerBase<KuroPushController>.Instance.GetPushState() > false) ? 1 : 0);
		gameSettings73.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (reason == EGameSettingsApplyReason.WhenUi)
			{
				GameSettingsUtils.ApplyPushEnableState(value, new EGameSettingsApplyReason?(reason));
				return true;
			}
			return false;
		};
		gameSettings73.DumpCallback = (() => "[DumpPushMode]same to getter");
		this.pushMode = gameSettings73;
		GameSettings gameSettings74 = new GameSettings();
		gameSettings74.GameSettingId = EFunction.AimAssist;
		gameSettings74.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AimAssistEnable;
		gameSettings74.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyAimAssistEnable(value);
			return true;
		};
		gameSettings74.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAimAssist());
		this.aimAssist = gameSettings74;
		GameSettings gameSettings75 = new GameSettings();
		gameSettings75.GameSettingId = EFunction.KeyboardLockEnemyMode;
		gameSettings75.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.KeyboardLockEnemyMode;
		gameSettings75.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyKeyboardLockEnemyMode(value);
			return true;
		};
		gameSettings75.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpKeyboardLockEnemyMode());
		this.keyboardLockEnemyMode = gameSettings75;
		GameSettings gameSettings76 = new GameSettings();
		gameSettings76.GameSettingId = EFunction.HorizontalViewRevert;
		gameSettings76.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.HorizontalViewRevert;
		gameSettings76.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				GameSettingsUtils.ApplyHorizontalViewRevert(value);
			}
			return true;
		};
		gameSettings76.DumpCallback = (() => "[DumpHorizontalViewRevert]no way to dump");
		this.horizontalViewRevert = gameSettings76;
		GameSettings gameSettings77 = new GameSettings();
		gameSettings77.GameSettingId = EFunction.VerticalViewRevert;
		gameSettings77.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VerticalViewRevert;
		gameSettings77.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				GameSettingsUtils.ApplyVerticalViewRevert(value);
			}
			return true;
		};
		gameSettings77.DumpCallback = (() => "[DumpVerticalViewRevert]no way to dump");
		this.verticalViewRevert = gameSettings77;
		GameSettings gameSettings78 = new GameSettings();
		gameSettings78.GameSettingId = EFunction.SkillLockEnemyMode;
		gameSettings78.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.SkillLockEnemyMode;
		gameSettings78.DumpCallback = (() => "[DumpSkillLockEnemyMode]same to getter");
		this.skillLockEnemyMode = gameSettings78;
		GameSettings gameSettings79 = new GameSettings();
		gameSettings79.GameSettingId = EFunction.GamepadLockEnemyMode;
		gameSettings79.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.GamepadLockEnemyMode;
		gameSettings79.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyGamepadLockEnemyMode(value);
			return true;
		};
		gameSettings79.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpGamepadLockEnemyMode());
		this.gamepadLockEnemyMode = gameSettings79;
		GameSettings gameSettings80 = new GameSettings();
		gameSettings80.GameSettingId = EFunction.EnemyHitDisplayMode;
		gameSettings80.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.EnemyHitDisplayMode;
		gameSettings80.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyEnemyHitDisplayMode(value);
			return true;
		};
		gameSettings80.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpEnemyHitDisplayMode());
		this.enemyHitDisplayMode = gameSettings80;
		GameSettings gameSettings81 = new GameSettings();
		gameSettings81.GameSettingId = EFunction.MobileGamepadMode;
		gameSettings81.GetCallbackOrGlobalKey = new Func<int>(() => (ModelBase<PlatformModel>.Instance.IsGamepadAttached() > false) ? 1 : 0);
		gameSettings81.DumpCallback = (() => "[DumpMobileGamepadMode]same to getter");
		this.mobileGamepadMode = gameSettings81;
		GameSettings gameSettings82 = new GameSettings();
		gameSettings82.GameSettingId = EFunction.AutoAdjustImageQuality;
		gameSettings82.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AutoAdjustImageQuality;
		gameSettings82.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyAutoAdjustImageQuality(value);
			return true;
		};
		gameSettings82.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAutoAdjustImageQuality());
		this.autoAdjustImageQuality = gameSettings82;
		GameSettings gameSettings83 = new GameSettings();
		gameSettings83.GameSettingId = EFunction.ShowDamage;
		gameSettings83.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.ShowDamage;
		gameSettings83.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyShowDamage(value);
			return true;
		};
		gameSettings83.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpShowDamage());
		this.showDamage = gameSettings83;
		GameSettings gameSettings84 = new GameSettings();
		gameSettings84.GameSettingId = EFunction.DynamicBones;
		gameSettings84.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.DynamicBones;
		gameSettings84.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyDynamicBones(value);
			return true;
		};
		gameSettings84.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpDynamicBones());
		this.dynamicBones = gameSettings84;
		GameSettings gameSettings85 = new GameSettings();
		gameSettings85.GameSettingId = EFunction.UIPureMode;
		gameSettings85.GetCallbackOrGlobalKey = new Func<int>(delegate()
		{
			if (ModelBase<BattleUiModel>.Instance.PureModeData == null || !ModelBase<BattleUiModel>.Instance.PureModeData.IsOpen)
			{
				return 0;
			}
			return 1;
		});
		gameSettings85.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyUiPureMode(value));
		gameSettings85.DumpCallback = (() => "[DumpUiPureMode]same to getter");
		this.uiPureMode = gameSettings85;
		GameSettings gameSettings86 = new GameSettings();
		gameSettings86.GameSettingId = EFunction.FlyControlMode;
		gameSettings86.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.FlyControlMode;
		gameSettings86.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => true);
		gameSettings86.DumpCallback = (() => "[DumpFlyControlMode]same to getter");
		this.flyControlMode = gameSettings86;
		GameSettings gameSettings87 = new GameSettings();
		gameSettings87.GameSettingId = EFunction.DOLBYATOMS;
		gameSettings87.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.DolbyAtmos;
		gameSettings87.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyDolbyAtmos(value);
			return true;
		};
		gameSettings87.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVolume("volume_dolby_atmos"));
		this.dolbyAtmos = gameSettings87;
		GameSettings gameSettings88 = new GameSettings();
		gameSettings88.GameSettingId = EFunction.FlowAdaptation;
		gameSettings88.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.FlowAdaptation;
		gameSettings88.DumpCallback = (() => "[DumpFlowAdaptation]same to getter");
		this.flowAdaptation = gameSettings88;
		GameSettings gameSettings89 = new GameSettings();
		gameSettings89.GameSettingId = EFunction.RayTracing;
		gameSettings89.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.RayTracing;
		gameSettings89.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyRayTracing(value));
		gameSettings89.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpRayTracing());
		gameSettings89.HandleDoneCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.SetRayTracingWithValue, value);
		};
		this.rayTracing = gameSettings89;
		GameSettings gameSettings90 = new GameSettings();
		gameSettings90.GameSettingId = EFunction.RayTracedReflection;
		gameSettings90.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.RayTracedReflection;
		gameSettings90.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyRayTracedReflection(value));
		gameSettings90.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpRayTracedReflection());
		this.rayTracedReflection = gameSettings90;
		GameSettings gameSettings91 = new GameSettings();
		gameSettings91.GameSettingId = EFunction.RayTracedGI;
		gameSettings91.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.RayTracedGI;
		gameSettings91.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyRayTracedGI(value));
		gameSettings91.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpRayTracedGI());
		this.rayTracedGI = gameSettings91;
		GameSettings gameSettings92 = new GameSettings();
		gameSettings92.GameSettingId = EFunction.RayTracedShadow;
		gameSettings92.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.RayTracedShadow;
		gameSettings92.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyRayTracedShadow(value));
		gameSettings92.DumpCallback = (() => "[DumpRayTracedShadow]not implemented");
		this.rayTracedShadow = gameSettings92;
		GameSettings gameSettings93 = new GameSettings();
		gameSettings93.GameSettingId = EFunction.TeammateFx;
		gameSettings93.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.TeammateFx;
		gameSettings93.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			Singleton<EffectEnvironment>.Instance.DisableOtherEffect = (value == 0);
			return true;
		};
		gameSettings93.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpTeammateFx());
		this.teammateFx = gameSettings93;
		GameSettings gameSettings94 = new GameSettings();
		gameSettings94.GameSettingId = EFunction.Saturation;
		gameSettings94.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.SaturationNew;
		gameSettings94.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplySaturationClient(value));
		gameSettings94.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpSaturation());
		this.saturation = gameSettings94;
		GameSettings gameSettings95 = new GameSettings();
		gameSettings95.GameSettingId = EFunction.Contrast;
		gameSettings95.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.ContrastNew;
		gameSettings95.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyContrastClient(value));
		gameSettings95.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpContrast());
		this.contrast = gameSettings95;
		GameSettings gameSettings96 = new GameSettings();
		gameSettings96.GameSettingId = EFunction.Filter;
		gameSettings96.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings96.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpFilter());
		this.filter = gameSettings96;
		GameSettings gameSettings97 = new GameSettings();
		gameSettings97.GameSettingId = EFunction.SkinDamageMode;
		gameSettings97.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.SkinDamageMode;
		gameSettings97.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplySkinDamageMode(value);
			return true;
		};
		gameSettings97.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpSkinDamageMode());
		this.skinDamageMode = gameSettings97;
		GameSettings gameSettings98 = new GameSettings();
		gameSettings98.GameSettingId = EFunction.PlayStationOnly;
		gameSettings98.GetCallbackOrGlobalKey = new Func<int>(() => (ModelBase<KuroSdkModel>.Instance.PlayStationPlayOnlyState > false) ? 1 : 0);
		gameSettings98.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (reason == EGameSettingsApplyReason.WhenUi)
			{
				ControllerBase<KuroSdkController>.Instance.RequestChangeServerPlayStationPlayOnlyState(value == 1);
			}
			return false;
		};
		gameSettings98.DumpCallback = (() => "[DumpPlayStationOnly]same to getter");
		this.playStationOnly = gameSettings98;
		GameSettings gameSettings99 = new GameSettings();
		gameSettings99.GameSettingId = EFunction.AdrenoFME;
		gameSettings99.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AfmeSince2Dot3;
		gameSettings99.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyAFMEOption(value);
			return true;
		};
		gameSettings99.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAdrenoFME());
		this.adrenoFME = gameSettings99;
		GameSettings gameSettings100 = new GameSettings();
		gameSettings100.GameSettingId = EFunction.UserCenterDomestic;
		gameSettings100.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings100.DumpCallback = (() => "[DumpUserCenterDomestic]this is just a switch entry");
		this.userCenterDomestic = gameSettings100;
		GameSettings gameSettings101 = new GameSettings();
		gameSettings101.GameSettingId = EFunction.UserCenterOverseas;
		gameSettings101.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings101.DumpCallback = (() => "[userCenterOverseas]this is just a switch entry");
		this.userCenterOverseas = gameSettings101;
		GameSettings gameSettings102 = new GameSettings();
		gameSettings102.GameSettingId = EFunction.PrivacyPolicyDomestic;
		gameSettings102.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings102.DumpCallback = (() => "[privacyPolicyDomestic]this is just a switch entry");
		this.privacyPolicyDomestic = gameSettings102;
		GameSettings gameSettings103 = new GameSettings();
		gameSettings103.GameSettingId = EFunction.PrivacyPolicyOverSeas;
		gameSettings103.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings103.DumpCallback = (() => "[privacyPolicyOverSeas]this is just a switch entry");
		this.privacyPolicyOverSeas = gameSettings103;
		GameSettings gameSettings104 = new GameSettings();
		gameSettings104.GameSettingId = EFunction.TermsOfUseDomestic;
		gameSettings104.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings104.DumpCallback = (() => "[termsOfUseDomestic]this is just a switch entry");
		this.termsOfUseDomestic = gameSettings104;
		GameSettings gameSettings105 = new GameSettings();
		gameSettings105.GameSettingId = EFunction.TermsOfUseOverSeas;
		gameSettings105.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings105.DumpCallback = (() => "[termsOfUseOverSeas]this is just a switch entry");
		this.termsOfUseOverSeas = gameSettings105;
		GameSettings gameSettings106 = new GameSettings();
		gameSettings106.GameSettingId = EFunction.ChildrenPrivacy;
		gameSettings106.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings106.DumpCallback = (() => "[childrenPrivacy]this is just a switch entry");
		this.childrenPrivacy = gameSettings106;
		GameSettings gameSettings107 = new GameSettings();
		gameSettings107.GameSettingId = EFunction.ThirdPartyInfo;
		gameSettings107.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings107.DumpCallback = (() => "[thirdPartyInfo]this is just a switch entry");
		this.thirdPartyInfo = gameSettings107;
		GameSettings gameSettings108 = new GameSettings();
		gameSettings108.GameSettingId = EFunction.PrivacyPolicySetting;
		gameSettings108.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings108.DumpCallback = (() => "[privacyPolicySetting]this is just a switch entry");
		this.privacyPolicySetting = gameSettings108;
		GameSettings gameSettings109 = new GameSettings();
		gameSettings109.GameSettingId = EFunction.License;
		gameSettings109.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings109.DumpCallback = (() => "[license]this is just a switch entry");
		this.licenseSetting = gameSettings109;
		GameSettings gameSettings110 = new GameSettings();
		gameSettings110.GameSettingId = EFunction.LogUpload;
		gameSettings110.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings110.DumpCallback = (() => "[logUpload]this is just a switch entry");
		this.logUploadSetting = gameSettings110;
		GameSettings gameSettings111 = new GameSettings();
		gameSettings111.GameSettingId = EFunction.BasicGraphicSetting;
		gameSettings111.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings111.DumpCallback = (() => "[basicGraphicSetting]this is just a switch entry");
		this.basicGraphicSetting = gameSettings111;
		GameSettings gameSettings112 = new GameSettings();
		gameSettings112.GameSettingId = EFunction.AutoRun;
		gameSettings112.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AutoRun;
		gameSettings112.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyAutoRun(value));
		gameSettings112.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAutoRun());
		this.autoRun = gameSettings112;
		GameSettings gameSettings113 = new GameSettings();
		gameSettings113.GameSettingId = EFunction.AutoSprint;
		gameSettings113.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AutoSprint;
		gameSettings113.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyAutoSprint(value));
		gameSettings113.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAutoSprint());
		this.autoSprint = gameSettings113;
		GameSettings gameSettings114 = new GameSettings();
		gameSettings114.GameSettingId = EFunction.Vulkan;
		gameSettings114.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.Vulkan;
		gameSettings114.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVulkan(value));
		gameSettings114.HandleDoneCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (reason == EGameSettingsApplyReason.WhenUi || reason == EGameSettingsApplyReason.WhenGameStart)
			{
				LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.VulkanChangeFlag, true);
			}
		};
		gameSettings114.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVulkan());
		this.vulkan = gameSettings114;
		GameSettings gameSettings115 = new GameSettings();
		gameSettings115.GameSettingId = EFunction.ShowOtherName;
		gameSettings115.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.ShowOtherName;
		gameSettings115.HandleDoneCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshPlayerInfoVisible);
		};
		gameSettings115.DumpCallback = (() => "[DumpAdviceSetting]same to getter");
		this.showOtherName = gameSettings115;
		GameSettings gameSettings116 = new GameSettings();
		gameSettings116.GameSettingId = EFunction.WaterInteract;
		gameSettings116.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.WaterInteract;
		gameSettings116.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyWaterInteract(value));
		gameSettings116.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpWaterInteract());
		this.waterInteract = gameSettings116;
		GameSettings gameSettings117 = new GameSettings();
		gameSettings117.GameSettingId = EFunction.VegetationDither;
		gameSettings117.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VegetationDither;
		gameSettings117.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVegetationDither(value));
		gameSettings117.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVegetationDither());
		this.vegetationDither = gameSettings117;
		GameSettings gameSettings118 = new GameSettings();
		gameSettings118.GameSettingId = EFunction.VegetationDensity;
		gameSettings118.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.VegetationDensity;
		gameSettings118.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyVegetationDensity(value));
		gameSettings118.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpVegetationDensity());
		this.vegetationDensity = gameSettings118;
		GameSettings gameSettings119 = new GameSettings();
		gameSettings119.GameSettingId = EFunction.VersionCheck;
		gameSettings119.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings119.DumpCallback = (() => "");
		this.versionCheck = gameSettings119;
		GameSettings gameSettings120 = new GameSettings();
		gameSettings120.GameSettingId = EFunction.ImageDisplayMode;
		gameSettings120.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.ImageDisplayMode;
		gameSettings120.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyImageDisplayMode(value));
		gameSettings120.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpImageDisplayMode());
		this.imageDisplayMode = gameSettings120;
		GameSettings gameSettings121 = new GameSettings();
		gameSettings121.GameSettingId = EFunction.EyeProtection;
		gameSettings121.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.EyeProtection;
		gameSettings121.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpEyeProtection());
		this.eyeProtection = gameSettings121;
		GameSettings gameSettings122 = new GameSettings();
		gameSettings122.GameSettingId = EFunction.EyeProtectionMode;
		gameSettings122.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.EyeProtectionMode;
		gameSettings122.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyEyeProtectionMode(value));
		gameSettings122.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpEyeProtectionMode());
		this.eyeProtectionMode = gameSettings122;
		GameSettings gameSettings123 = new GameSettings();
		gameSettings123.GameSettingId = EFunction.EyeProtectionTemp;
		gameSettings123.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.EyeProtectionTemp;
		gameSettings123.ApplyCallbackFloat = ((float value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyEyeProtectionTemp(value, Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true)));
		gameSettings123.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpEyeProtectionTemp());
		this.eyeProtectionTemp = gameSettings123;
		GameSettings gameSettings124 = new GameSettings();
		gameSettings124.GameSettingId = EFunction.EyeProtectionStrength;
		gameSettings124.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.EyeProtectionStrength;
		gameSettings124.ApplyCallbackFloat = ((float value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyEyeProtectionStrength(value, Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true)));
		gameSettings124.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpEyeProtectionStrength());
		this.eyeProtectionStrength = gameSettings124;
		GameSettings gameSettings125 = new GameSettings();
		gameSettings125.GameSettingId = EFunction.EyeProtectionBrightness;
		gameSettings125.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.EyeProtectionBrightness;
		gameSettings125.ApplyCallbackFloat = ((float value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyEyeProtectionBrightness(value, Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true)));
		gameSettings125.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpEyeProtectionBrightness());
		this.eyeProtectionBrightness = gameSettings125;
		GameSettings gameSettings126 = new GameSettings();
		gameSettings126.GameSettingId = EFunction.EyeProtectionTexture;
		gameSettings126.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.EyeProtectionTexture;
		gameSettings126.ApplyCallbackFloat = ((float value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyEyeProtectionTexture(value, Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true)));
		gameSettings126.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpEyeProtectionTexture());
		this.eyeProtectionTexture = gameSettings126;
		GameSettings gameSettings127 = new GameSettings();
		gameSettings127.GameSettingId = EFunction.AutoExposure;
		gameSettings127.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AutoExposure;
		gameSettings127.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => GameSettingsUtils.ApplyAutoExposure(value));
		gameSettings127.DumpCallback = (() => Singleton<GameSettingsDumpUtils>.Instance.DumpAutoExposure());
		this.autoExposure = gameSettings127;
		GameSettings gameSettings128 = new GameSettings();
		gameSettings128.GameSettingId = EFunction.AdjustiveGamePadTrigger;
		gameSettings128.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AdjustiveGamePadTrigger;
		gameSettings128.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyAdjustiveGamePadTrigger(value);
			return true;
		};
		gameSettings128.DumpCallback = (() => "[AdjustiveGamePadTrigger]same to getter");
		this.adjustiveGamePadTrigger = gameSettings128;
		GameSettings gameSettings129 = new GameSettings();
		gameSettings129.GameSettingId = EFunction.GamepadLeftStickDeadZone;
		gameSettings129.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.GamepadLeftStickDeadZone;
		gameSettings129.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyGamepadLeftStickDeadZone(value);
			return true;
		};
		gameSettings129.DumpCallback = (() => "[GamepadLeftStickDeadZone]same to getter");
		this.gamepadLeftStickDeadZone = gameSettings129;
		GameSettings gameSettings130 = new GameSettings();
		gameSettings130.GameSettingId = EFunction.GamepadRightStickDeadZone;
		gameSettings130.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.GamepadRightStickDeadZone;
		gameSettings130.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyGamepadRightStickDeadZone(value);
			return true;
		};
		gameSettings130.DumpCallback = (() => "[GamepadRightStickDeadZone]same to getter");
		this.gamepadRightStickDeadZone = gameSettings130;
		GameSettings gameSettings131 = new GameSettings();
		gameSettings131.GameSettingId = EFunction.GamepadLeftTriggerDeadZone;
		gameSettings131.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.GamepadLeftTriggerDeadZone;
		gameSettings131.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyGamepadLeftTriggerDeadZone(value);
			return true;
		};
		gameSettings131.DumpCallback = (() => "[GamepadLeftTriggerDeadZone]same to getter");
		this.gamepadLeftTriggerDeadZone = gameSettings131;
		GameSettings gameSettings132 = new GameSettings();
		gameSettings132.GameSettingId = EFunction.GamepadRightTriggerDeadZone;
		gameSettings132.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.GamepadRightTriggerDeadZone;
		gameSettings132.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyGamepadRightTriggerDeadZone(value);
			return true;
		};
		gameSettings132.DumpCallback = (() => "[GamepadRightTriggerDeadZone]same to getter");
		this.gamepadRightTriggerDeadZone = gameSettings132;
		GameSettings gameSettings133 = new GameSettings();
		gameSettings133.GameSettingId = EFunction.MotorAutoLongPressSpeedUp;
		gameSettings133.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorAutoLongPressSpeedUp;
		gameSettings133.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMotorAutoLongPressSpeedUp(value);
			return true;
		};
		gameSettings133.DumpCallback = (() => "[MotorAutoLongPressSpeedUp]same to getter");
		this.motorAccleratePressType = gameSettings133;
		GameSettings gameSettings134 = new GameSettings();
		gameSettings134.GameSettingId = EFunction.MotorAutoAcceleratorSettingEnable;
		gameSettings134.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorAutoAcceleratorSettingEnable;
		gameSettings134.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMotorAutoAcceleratorSettingEnable(value);
			return true;
		};
		gameSettings134.DumpCallback = (() => "[MotorAutoAcceleratorSettingEnable]same to getter");
		this.motorAutoAcceleratorSettingEnable = gameSettings134;
		GameSettings gameSettings135 = new GameSettings();
		gameSettings135.GameSettingId = EFunction.MotorDriftAcceleratorSettingEnable;
		gameSettings135.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorDriftAcceleratorSettingEnable;
		gameSettings135.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMotorDriftAcceleratorSettingEnable(value);
			return true;
		};
		gameSettings135.DumpCallback = (() => "[MotorDriftAcceleratorSettingEnable]same to getter");
		this.motorDriftAcceleratorSettingEnable = gameSettings135;
		GameSettings gameSettings136 = new GameSettings();
		gameSettings136.GameSettingId = EFunction.MotorDriftModel;
		gameSettings136.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorDriftModel;
		gameSettings136.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => true);
		gameSettings136.DumpCallback = (() => "[MotorDriftAcceleratorSettingEnable]same to getter");
		this.motorDriftModel = gameSettings136;
		GameSettings gameSettings137 = new GameSettings();
		gameSettings137.GameSettingId = EFunction.MotorHudVisible;
		gameSettings137.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorHudVisible;
		gameSettings137.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMotorHudVisible(value);
			return true;
		};
		gameSettings137.DumpCallback = (() => "[MotorHudVisible]same to getter");
		this.motorHudVisible = gameSettings137;
		GameSettings gameSettings138 = new GameSettings();
		gameSettings138.GameSettingId = EFunction.SubTitleOption;
		gameSettings138.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.SubTitleOption;
		gameSettings138.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => true);
		gameSettings138.DumpCallback = (() => "[SubTitleOption]same to getter");
		this.subTitleOption = gameSettings138;
		GameSettings gameSettings139 = new GameSettings();
		gameSettings139.GameSettingId = EFunction.MotorIsDynamicJoystick;
		gameSettings139.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorIsDynamicJoystick;
		gameSettings139.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyMotorIsDynamicJoystick(value);
			return true;
		};
		gameSettings139.DumpCallback = (() => "[MotorIsDynamicJoystick]same to getter");
		this.motorTouchFixedPosition = gameSettings139;
		GameSettings gameSettings140 = new GameSettings();
		gameSettings140.GameSettingId = EFunction.MotorMobileButtonCustom;
		gameSettings140.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings140.DumpCallback = (() => "[motorMobileButtonCustom]this is just a switch entry");
		this.motorMobileButtonCustom = gameSettings140;
		GameSettings gameSettings141 = new GameSettings();
		gameSettings141.GameSettingId = EFunction.MotorMobileButtonLayout;
		gameSettings141.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorMobileButtonLayout;
		gameSettings141.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			bool value2 = value == 0;
			if (ModelBase<BattleUiModel>.Instance.MotorcycleData != null)
			{
				ModelBase<BattleUiModel>.Instance.JoystickData.RefreshMotorMobileButtonLayout(new bool?(value2));
			}
			return true;
		};
		gameSettings141.DumpCallback = (() => "[MotorMobileButtonLayout]same to getter");
		this.motorMobileButtonLayout = gameSettings141;
		GameSettings gameSettings142 = new GameSettings();
		gameSettings142.GameSettingId = EFunction.DeviceInfo;
		gameSettings142.GetCallbackOrGlobalKey = new Func<int>(() => 0);
		gameSettings142.DumpCallback = (() => "");
		this.deviceInfo = gameSettings142;
		GameSettings gameSettings143 = new GameSettings();
		gameSettings143.GameSettingId = EFunction.UiBrightness;
		gameSettings143.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.UiBrightness;
		gameSettings143.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyUiBrightness((float)value);
			return true;
		};
		gameSettings143.DumpCallback = (() => "[UiBrightness]same to getter");
		this.uiBrightness = gameSettings143;
		GameSettings gameSettings144 = new GameSettings();
		gameSettings144.GameSettingId = EFunction.PeakBrightness;
		gameSettings144.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.PeakBrightness;
		gameSettings144.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyPeakBrightness((float)value);
			return true;
		};
		gameSettings144.DumpCallback = (() => "[PeakBrightness]same to getter");
		this.peakBrightness = gameSettings144;
		GameSettings gameSettings145 = new GameSettings();
		gameSettings145.GameSettingId = EFunction.MotorFlyControlMode;
		gameSettings145.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.MotorFlyControlMode;
		gameSettings145.ApplyCallback = ((int value, EGameSettingsApplyReason reason) => true);
		gameSettings145.DumpCallback = (() => "[MotorFlyControlMode]same to getter");
		this.motorFlyControlMode = gameSettings145;
		GameSettings gameSettings146 = new GameSettings();
		gameSettings146.GameSettingId = EFunction.AnisoLevel;
		gameSettings146.GetCallbackOrGlobalKey = ELocalStorageGlobalKey.AnisoLevel;
		gameSettings146.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			GameSettingsUtils.ApplyAnisoLevel(value);
			return true;
		};
		gameSettings146.DumpCallback = (() => "[anisoLevel]Anisotropic Level");
		this.anisoLevel = gameSettings146;
		GameSettings gameSettings147 = new GameSettings();
		gameSettings147.GameSettingId = EFunction.XboxOnly;
		gameSettings147.GetCallbackOrGlobalKey = new Func<int>(() => (ModelBase<KuroSdkModel>.Instance.XboxPlayOnlyState > false) ? 1 : 0);
		gameSettings147.ApplyCallback = delegate(int value, EGameSettingsApplyReason reason)
		{
			if (reason == EGameSettingsApplyReason.WhenUi)
			{
				ControllerBase<KuroSdkController>.Instance.RequestChangeServerXboxPlayOnlyState(value == 1);
			}
			return false;
		};
		gameSettings147.DumpCallback = (() => "[DumpXboxOnly]same to getter");
		this.xboxOnly = gameSettings147;
		base..ctor();
	}

	// Token: 0x04002B04 RID: 11012
	public const int HEAVY_SCENEVULUME_INDEX_START = 30;

	// Token: 0x04002B05 RID: 11013
	public const int HEAVY_SCENEVULUME_INDEX_END = 39;

	// Token: 0x04002B06 RID: 11014
	public const int NPC_DENSITY_THRESHOLD = 1;

	// Token: 0x04002B07 RID: 11015
	public const int NPC_DENSITY_PC_THRESHOLD = 1;

	// Token: 0x04002B08 RID: 11016
	public const int WINDOWS_RESOLUTION_INDEX = 2;

	// Token: 0x04002B09 RID: 11017
	public const int MAIN_TYPE_OF_KEY_SETTING = 3;

	// Token: 0x04002B0A RID: 11018
	[Nullable(2)]
	public static EGameSettingsInitSourceType[] gameSettingsInitSourceTypePriority;

	// Token: 0x04002B0B RID: 11019
	public GameSettings masterVolume;

	// Token: 0x04002B0C RID: 11020
	public GameSettings voiceVolume;

	// Token: 0x04002B0D RID: 11021
	public GameSettings musicVolume;

	// Token: 0x04002B0E RID: 11022
	public GameSettings sfxVolume;

	// Token: 0x04002B0F RID: 11023
	public GameSettings uiVolume;

	// Token: 0x04002B10 RID: 11024
	public GameSettings ambVolume;

	// Token: 0x04002B11 RID: 11025
	public GameSettings backendVolume;

	// Token: 0x04002B12 RID: 11026
	public GameSettings imageQuality;

	// Token: 0x04002B13 RID: 11027
	public GameSettings loadingRangeScaleLevel;

	// Token: 0x04002B14 RID: 11028
	public GameSettings displayMode;

	// Token: 0x04002B15 RID: 11029
	public GameSettings resolution;

	// Token: 0x04002B16 RID: 11030
	public GameSettings brightness;

	// Token: 0x04002B17 RID: 11031
	public GameSettings highestFps;

	// Token: 0x04002B18 RID: 11032
	public GameSettings shadowQuality;

	// Token: 0x04002B19 RID: 11033
	public GameSettings niagaraQuality;

	// Token: 0x04002B1A RID: 11034
	public GameSettings imageDetail;

	// Token: 0x04002B1B RID: 11035
	public GameSettings antiAliasing;

	// Token: 0x04002B1C RID: 11036
	public GameSettings sceneAo;

	// Token: 0x04002B1D RID: 11037
	public GameSettings npcDensity;

	// Token: 0x04002B1E RID: 11038
	public GameSettings nvidiaDlss;

	// Token: 0x04002B1F RID: 11039
	public GameSettings nvidiaDlssFg;

	// Token: 0x04002B20 RID: 11040
	public GameSettings nvidiaDlssQuality;

	// Token: 0x04002B21 RID: 11041
	public GameSettings nvidiaDlssSharpness;

	// Token: 0x04002B22 RID: 11042
	public GameSettings nvidiaReflex;

	// Token: 0x04002B23 RID: 11043
	public GameSettings hdr;

	// Token: 0x04002B24 RID: 11044
	public GameSettings fsr;

	// Token: 0x04002B25 RID: 11045
	public GameSettings xess;

	// Token: 0x04002B26 RID: 11046
	public GameSettings xessQuality;

	// Token: 0x04002B27 RID: 11047
	public GameSettings xess2;

	// Token: 0x04002B28 RID: 11048
	public GameSettings xess2Fg;

	// Token: 0x04002B29 RID: 11049
	public GameSettings xess2Quality;

	// Token: 0x04002B2A RID: 11050
	public GameSettings fsr3;

	// Token: 0x04002B2B RID: 11051
	public GameSettings fsr3Fg;

	// Token: 0x04002B2C RID: 11052
	public GameSettings fsr3Quality;

	// Token: 0x04002B2D RID: 11053
	public GameSettings metalFxEnable;

	// Token: 0x04002B2E RID: 11054
	public GameSettings irx;

	// Token: 0x04002B2F RID: 11055
	public GameSettings bloom;

	// Token: 0x04002B30 RID: 11056
	public GameSettings volumeFog;

	// Token: 0x04002B31 RID: 11057
	public GameSettings volumeLight;

	// Token: 0x04002B32 RID: 11058
	public GameSettings motionBlur;

	// Token: 0x04002B33 RID: 11059
	public GameSettings pcvSync;

	// Token: 0x04002B34 RID: 11060
	public GameSettings mobileResolution;

	// Token: 0x04002B35 RID: 11061
	public GameSettings superResolution;

	// Token: 0x04002B36 RID: 11062
	public GameSettings textLanguage;

	// Token: 0x04002B37 RID: 11063
	public GameSettings voiceLanguage;

	// Token: 0x04002B38 RID: 11064
	public GameSettings voicePackManager;

	// Token: 0x04002B39 RID: 11065
	public GameSettings voiceRoleCustomManager;

	// Token: 0x04002B3A RID: 11066
	public GameSettings adviceSetting;

	// Token: 0x04002B3B RID: 11067
	public GameSettings genderSetting;

	// Token: 0x04002B3C RID: 11068
	public GameSettings horizontalViewSensitivity;

	// Token: 0x04002B3D RID: 11069
	public GameSettings verticalViewSensitivity;

	// Token: 0x04002B3E RID: 11070
	public GameSettings aimHorizontalViewSensitivity;

	// Token: 0x04002B3F RID: 11071
	public GameSettings aimVerticalViewSensitivity;

	// Token: 0x04002B40 RID: 11072
	public GameSettings cameraShakeStrength;

	// Token: 0x04002B41 RID: 11073
	public GameSettings mobileHorizontalViewSensitivity;

	// Token: 0x04002B42 RID: 11074
	public GameSettings mobileVerticalViewSensitivity;

	// Token: 0x04002B43 RID: 11075
	public GameSettings mobileAimHorizontalViewSensitivity;

	// Token: 0x04002B44 RID: 11076
	public GameSettings mobileAimVerticalViewSensitivity;

	// Token: 0x04002B45 RID: 11077
	public GameSettings commonSpringArmLength;

	// Token: 0x04002B46 RID: 11078
	public GameSettings fightSpringArmLength;

	// Token: 0x04002B47 RID: 11079
	public GameSettings resetFocusEnable;

	// Token: 0x04002B48 RID: 11080
	public GameSettings isSidestepCameraEnable;

	// Token: 0x04002B49 RID: 11081
	public GameSettings isSoftLockCameraEnable;

	// Token: 0x04002B4A RID: 11082
	public GameSettings joystickShakeStrength;

	// Token: 0x04002B4B RID: 11083
	public GameSettings joystickShakeType;

	// Token: 0x04002B4C RID: 11084
	public GameSettings walkOrRunRate;

	// Token: 0x04002B4D RID: 11085
	public GameSettings joystickMode;

	// Token: 0x04002B4E RID: 11086
	public GameSettings mobileButtonCustom;

	// Token: 0x04002B4F RID: 11087
	public GameSettings skillButtonMode;

	// Token: 0x04002B50 RID: 11088
	public GameSettings cdKey;

	// Token: 0x04002B51 RID: 11089
	public GameSettings resDownLoad;

	// Token: 0x04002B52 RID: 11090
	public GameSettings resClear;

	// Token: 0x04002B53 RID: 11091
	public GameSettings pushMode;

	// Token: 0x04002B54 RID: 11092
	public GameSettings aimAssist;

	// Token: 0x04002B55 RID: 11093
	public GameSettings keyboardLockEnemyMode;

	// Token: 0x04002B56 RID: 11094
	public GameSettings horizontalViewRevert;

	// Token: 0x04002B57 RID: 11095
	public GameSettings verticalViewRevert;

	// Token: 0x04002B58 RID: 11096
	public GameSettings skillLockEnemyMode;

	// Token: 0x04002B59 RID: 11097
	public GameSettings gamepadLockEnemyMode;

	// Token: 0x04002B5A RID: 11098
	public GameSettings enemyHitDisplayMode;

	// Token: 0x04002B5B RID: 11099
	public GameSettings mobileGamepadMode;

	// Token: 0x04002B5C RID: 11100
	public GameSettings autoAdjustImageQuality;

	// Token: 0x04002B5D RID: 11101
	public GameSettings showDamage;

	// Token: 0x04002B5E RID: 11102
	public GameSettings dynamicBones;

	// Token: 0x04002B5F RID: 11103
	public GameSettings uiPureMode;

	// Token: 0x04002B60 RID: 11104
	public GameSettings flyControlMode;

	// Token: 0x04002B61 RID: 11105
	public GameSettings dolbyAtmos;

	// Token: 0x04002B62 RID: 11106
	public GameSettings flowAdaptation;

	// Token: 0x04002B63 RID: 11107
	public GameSettings rayTracing;

	// Token: 0x04002B64 RID: 11108
	public GameSettings rayTracedReflection;

	// Token: 0x04002B65 RID: 11109
	public GameSettings rayTracedGI;

	// Token: 0x04002B66 RID: 11110
	public GameSettings rayTracedShadow;

	// Token: 0x04002B67 RID: 11111
	public GameSettings teammateFx;

	// Token: 0x04002B68 RID: 11112
	public GameSettings saturation;

	// Token: 0x04002B69 RID: 11113
	public GameSettings contrast;

	// Token: 0x04002B6A RID: 11114
	public GameSettings filter;

	// Token: 0x04002B6B RID: 11115
	public GameSettings skinDamageMode;

	// Token: 0x04002B6C RID: 11116
	public GameSettings playStationOnly;

	// Token: 0x04002B6D RID: 11117
	public GameSettings adrenoFME;

	// Token: 0x04002B6E RID: 11118
	public GameSettings userCenterDomestic;

	// Token: 0x04002B6F RID: 11119
	public GameSettings userCenterOverseas;

	// Token: 0x04002B70 RID: 11120
	public GameSettings privacyPolicyDomestic;

	// Token: 0x04002B71 RID: 11121
	public GameSettings privacyPolicyOverSeas;

	// Token: 0x04002B72 RID: 11122
	public GameSettings termsOfUseDomestic;

	// Token: 0x04002B73 RID: 11123
	public GameSettings termsOfUseOverSeas;

	// Token: 0x04002B74 RID: 11124
	public GameSettings childrenPrivacy;

	// Token: 0x04002B75 RID: 11125
	public GameSettings thirdPartyInfo;

	// Token: 0x04002B76 RID: 11126
	public GameSettings privacyPolicySetting;

	// Token: 0x04002B77 RID: 11127
	public GameSettings licenseSetting;

	// Token: 0x04002B78 RID: 11128
	public GameSettings logUploadSetting;

	// Token: 0x04002B79 RID: 11129
	public GameSettings basicGraphicSetting;

	// Token: 0x04002B7A RID: 11130
	public GameSettings autoRun;

	// Token: 0x04002B7B RID: 11131
	public GameSettings autoSprint;

	// Token: 0x04002B7C RID: 11132
	public GameSettings vulkan;

	// Token: 0x04002B7D RID: 11133
	public GameSettings showOtherName;

	// Token: 0x04002B7E RID: 11134
	public GameSettings waterInteract;

	// Token: 0x04002B7F RID: 11135
	public GameSettings vegetationDither;

	// Token: 0x04002B80 RID: 11136
	public GameSettings vegetationDensity;

	// Token: 0x04002B81 RID: 11137
	public GameSettings versionCheck;

	// Token: 0x04002B82 RID: 11138
	public GameSettings imageDisplayMode;

	// Token: 0x04002B83 RID: 11139
	public GameSettings eyeProtection;

	// Token: 0x04002B84 RID: 11140
	public GameSettings eyeProtectionMode;

	// Token: 0x04002B85 RID: 11141
	public GameSettings eyeProtectionTemp;

	// Token: 0x04002B86 RID: 11142
	public GameSettings eyeProtectionStrength;

	// Token: 0x04002B87 RID: 11143
	public GameSettings eyeProtectionBrightness;

	// Token: 0x04002B88 RID: 11144
	public GameSettings eyeProtectionTexture;

	// Token: 0x04002B89 RID: 11145
	public GameSettings autoExposure;

	// Token: 0x04002B8A RID: 11146
	public GameSettings adjustiveGamePadTrigger;

	// Token: 0x04002B8B RID: 11147
	public GameSettings gamepadLeftStickDeadZone;

	// Token: 0x04002B8C RID: 11148
	public GameSettings gamepadRightStickDeadZone;

	// Token: 0x04002B8D RID: 11149
	public GameSettings gamepadLeftTriggerDeadZone;

	// Token: 0x04002B8E RID: 11150
	public GameSettings gamepadRightTriggerDeadZone;

	// Token: 0x04002B8F RID: 11151
	public GameSettings motorAccleratePressType;

	// Token: 0x04002B90 RID: 11152
	public GameSettings motorAutoAcceleratorSettingEnable;

	// Token: 0x04002B91 RID: 11153
	public GameSettings motorDriftAcceleratorSettingEnable;

	// Token: 0x04002B92 RID: 11154
	public GameSettings motorDriftModel;

	// Token: 0x04002B93 RID: 11155
	public GameSettings motorHudVisible;

	// Token: 0x04002B94 RID: 11156
	public GameSettings subTitleOption;

	// Token: 0x04002B95 RID: 11157
	public GameSettings motorTouchFixedPosition;

	// Token: 0x04002B96 RID: 11158
	public GameSettings motorMobileButtonCustom;

	// Token: 0x04002B97 RID: 11159
	public GameSettings motorMobileButtonLayout;

	// Token: 0x04002B98 RID: 11160
	public GameSettings deviceInfo;

	// Token: 0x04002B99 RID: 11161
	public GameSettings uiBrightness;

	// Token: 0x04002B9A RID: 11162
	public GameSettings peakBrightness;

	// Token: 0x04002B9B RID: 11163
	public GameSettings motorFlyControlMode;

	// Token: 0x04002B9C RID: 11164
	public GameSettings anisoLevel;

	// Token: 0x04002B9D RID: 11165
	public GameSettings xboxOnly;

	// Token: 0x04002B9E RID: 11166
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<EFunction, IGameSettings> function2GameSettings;

	// Token: 0x020072CA RID: 29386
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027C9A RID: 162970
		[Nullable(0)]
		public static Func<int, EGameSettingsApplyReason, bool> <0>__ApplyNvidiaSuperSamplingEnable;
	}
}
