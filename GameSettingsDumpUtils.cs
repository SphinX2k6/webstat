using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Render;
using UnrealEngine;

// Token: 0x02000E96 RID: 3734
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GameSettingsDumpUtils : Singleton<GameSettingsDumpUtils>
{
	// Token: 0x06005B95 RID: 23445 RVA: 0x0016E7A8 File Offset: 0x0016C9A8
	private static string DumpConsoleVarNumber(string command)
	{
		float consoleVariableFloatValue = UKismetSystemLibrary.GetConsoleVariableFloatValue(command);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
		defaultInterpolatedStringHandler.AppendFormatted(command);
		defaultInterpolatedStringHandler.AppendLiteral(": ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(consoleVariableFloatValue);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005B96 RID: 23446 RVA: 0x0016E7F4 File Offset: 0x0016C9F4
	public string DumpVolume(string volumeTag)
	{
		float value = 0f;
		Singleton<AudioController>.Instance.GetRTPCValue(ref value, volumeTag, null, null, 0);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
		defaultInterpolatedStringHandler.AppendFormatted(volumeTag);
		defaultInterpolatedStringHandler.AppendLiteral(": ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(value);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005B97 RID: 23447 RVA: 0x0016E84F File Offset: 0x0016CA4F
	public string DumpImageQuality()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("sg.KuroRenderQuality") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.GlobalLightQuality");
	}

	// Token: 0x06005B98 RID: 23448 RVA: 0x0016E86C File Offset: 0x0016CA6C
	public string DumpDisplayMode()
	{
		TEnumAsByte<EWindowMode> fullscreenMode = UGameUserSettings.GetGameUserSettings().GetFullscreenMode();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetFullscreenMode: ");
		defaultInterpolatedStringHandler.AppendFormatted<TEnumAsByte<EWindowMode>>(fullscreenMode);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005B99 RID: 23449 RVA: 0x0016E8AC File Offset: 0x0016CAAC
	public string DumpResolution()
	{
		FIntPoint screenResolution = UGameUserSettings.GetGameUserSettings().GetScreenResolution();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
		defaultInterpolatedStringHandler.AppendLiteral("GetScreenResolution: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(screenResolution.X);
		defaultInterpolatedStringHandler.AppendLiteral(", ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(screenResolution.Y);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005B9A RID: 23450 RVA: 0x0016E908 File Offset: 0x0016CB08
	public string DumpBrightness()
	{
		string str = "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TonemapperGamma") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.LUT.Regenerate");
		float scalarParameterValue = UKismetMaterialLibrary.GetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetUiShowBrightnessMaterialParameterCollection(), RenderConfig.UIShowBrightness);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetScalarParameterValue_UIShowBrightness: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(scalarParameterValue);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		return str + defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005B9B RID: 23451 RVA: 0x0016E988 File Offset: 0x0016CB88
	public string DumpHighestFps()
	{
		float frameRateLimit = UGameUserSettings.GetGameUserSettings().GetFrameRateLimit();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetFrameRateLimit: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(frameRateLimit);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005B9C RID: 23452 RVA: 0x0016E9C5 File Offset: 0x0016CBC5
	public string DumpShadowQuality()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("sg.ShadowQuality");
	}

	// Token: 0x06005B9D RID: 23453 RVA: 0x0016E9D1 File Offset: 0x0016CBD1
	public string DumpNiagaraQuality()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("fx.Niagara.QualityLevel") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.DisableDistortion");
	}

	// Token: 0x06005B9E RID: 23454 RVA: 0x0016E9EC File Offset: 0x0016CBEC
	public string DumpImageDetail()
	{
		return "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.ToonOutlineDrawDistancePc") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Streaming.ForceKuroRuntimeLODBias") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.ToonOutlineDrawDistanceMobile") + GameSettingsDumpUtils.DumpConsoleVarNumber("foliage.DensityType") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Mobile.SceneObjMobileSSR") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Mobile.TreeRimLight") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.AutoExposure") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Streaming.ForceKuroRuntimeLODBias");
	}

	// Token: 0x06005B9F RID: 23455 RVA: 0x0016EA76 File Offset: 0x0016CC76
	public string DumpAntiAliasing()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.DefaultFeature.AntiAliasing");
	}

	// Token: 0x06005BA0 RID: 23456 RVA: 0x0016EA84 File Offset: 0x0016CC84
	public string DumpSceneAo()
	{
		string str = "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.AmbientOcclusionLevels") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Mobile.SSAO");
		float scalarParameterValue = UKismetMaterialLibrary.GetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), new FName("EnableMobileScreenAO"));
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetScalarParameterValue_EnableMobileScreenAO: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(scalarParameterValue);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		string str2 = str + defaultInterpolatedStringHandler.ToStringAndClear();
		scalarParameterValue = UKismetMaterialLibrary.GetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), RenderConfig.GlobalGrassAO);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetScalarParameterValue_GlobalGrassAO: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(scalarParameterValue);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		return str2 + defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BA1 RID: 23457 RVA: 0x0016EB5C File Offset: 0x0016CD5C
	public string DumpNpcDensity()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(57, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CreatureController.CurrentCreatureDensityLevelExternal: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(ControllerBase<CreatureController>.Instance.CurrentCreatureDensityLevelExternal);
		defaultInterpolatedStringHandler.AppendLiteral("\n");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BA2 RID: 23458 RVA: 0x0016EBA4 File Offset: 0x0016CDA4
	public string DumpNvidiaDlss()
	{
		string str = "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.NGX.DLSS.Enable") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAASamples") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAAFilterSize") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.FidelityFX.FSR.SecondaryUpscale");
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GameSettingsDeviceRender.IsEnableDLSSG: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(Singleton<GameSettingsDeviceRender>.Instance.IsEnableDLSSG());
		return str + defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BA3 RID: 23459 RVA: 0x0016EC28 File Offset: 0x0016CE28
	public string DumpNvidiaDlssFg()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GameSettingsDeviceRender.IsEnableDLSSG: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(Singleton<GameSettingsDeviceRender>.Instance.IsEnableDLSSG());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BA4 RID: 23460 RVA: 0x0016EC63 File Offset: 0x0016CE63
	public string DumpNvidiaDlssQuality()
	{
		return "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.NGX.DLSS.Quality.Auto") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.NGX.DLSS.Quality");
	}

	// Token: 0x06005BA5 RID: 23461 RVA: 0x0016EC88 File Offset: 0x0016CE88
	public string DumpNvidiaDlssSharpness()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SetDLSSSharpness: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(UDLSSLibrary.GetDLSSSharpness());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BA6 RID: 23462 RVA: 0x0016ECBE File Offset: 0x0016CEBE
	public string DumpNvidiaReflex()
	{
		return "[DumpNvidiaReflex]can not get setting value in engine";
	}

	// Token: 0x06005BA7 RID: 23463 RVA: 0x0016ECC5 File Offset: 0x0016CEC5
	public string DumpHdr()
	{
		return "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.HDR.EnableHDROutput");
	}

	// Token: 0x06005BA8 RID: 23464 RVA: 0x0016ECDC File Offset: 0x0016CEDC
	public string DumpFsr()
	{
		return "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAASamples") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.FidelityFX.FSR.PrimaryUpscale") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.ScreenPercentage") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.MipMapLODBias") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAACurrentFrameWeight") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAA.ClampTolerant") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAA.SharpenLimitDepth") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.NGX.DLSS.Enable");
	}

	// Token: 0x06005BA9 RID: 23465 RVA: 0x0016ED66 File Offset: 0x0016CF66
	public string DumpXess()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.XeSS.Enabled");
	}

	// Token: 0x06005BAA RID: 23466 RVA: 0x0016ED72 File Offset: 0x0016CF72
	public string DumpXessQuality()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.XeSS.Enabled");
	}

	// Token: 0x06005BAB RID: 23467 RVA: 0x0016ED7E File Offset: 0x0016CF7E
	public string DumpXess2()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.XeSS.Enabled");
	}

	// Token: 0x06005BAC RID: 23468 RVA: 0x0016ED8A File Offset: 0x0016CF8A
	public string DumpXess2Fg()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.XeFG.Enabled");
	}

	// Token: 0x06005BAD RID: 23469 RVA: 0x0016ED96 File Offset: 0x0016CF96
	public string DumpXess2Quality()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.XeSS.Quality");
	}

	// Token: 0x06005BAE RID: 23470 RVA: 0x0016EDA2 File Offset: 0x0016CFA2
	public string DumpFsr3()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.FidelityFX.FSR3.Enabled");
	}

	// Token: 0x06005BAF RID: 23471 RVA: 0x0016EDAE File Offset: 0x0016CFAE
	public string DumpFsr3Fg()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.FidelityFX.FI.Enabled");
	}

	// Token: 0x06005BB0 RID: 23472 RVA: 0x0016EDBA File Offset: 0x0016CFBA
	public string DumpFsr3Quality()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.FidelityFX.FSR3.QualityMode");
	}

	// Token: 0x06005BB1 RID: 23473 RVA: 0x0016EDC6 File Offset: 0x0016CFC6
	public string DumpMetalFxEnable()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.MetalFxUpscale") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAA.SharpenLimitDepth");
	}

	// Token: 0x06005BB2 RID: 23474 RVA: 0x0016EDE1 File Offset: 0x0016CFE1
	public string DumpIrx()
	{
		return "[DumpIrx]can not get setting value in engine";
	}

	// Token: 0x06005BB3 RID: 23475 RVA: 0x0016EDE8 File Offset: 0x0016CFE8
	public string DumpBloom()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.KuroBloomEnable");
	}

	// Token: 0x06005BB4 RID: 23476 RVA: 0x0016EDF4 File Offset: 0x0016CFF4
	public string DumpVolumeFog()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.volumetricfog");
	}

	// Token: 0x06005BB5 RID: 23477 RVA: 0x0016EE00 File Offset: 0x0016D000
	public string DumpVolumeLight()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.lightShaftQuality") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.MobileLightShaft");
	}

	// Token: 0x06005BB6 RID: 23478 RVA: 0x0016EE1B File Offset: 0x0016D01B
	public string DumpMotionBlur()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.MotionBlur.Amount");
	}

	// Token: 0x06005BB7 RID: 23479 RVA: 0x0016EE28 File Offset: 0x0016D028
	public string DumpPcVsync()
	{
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
		defaultInterpolatedStringHandler.AppendLiteral("IsVSyncEnabled: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(gameUserSettings.IsVSyncEnabled());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BB8 RID: 23480 RVA: 0x0016EE65 File Offset: 0x0016D065
	public string DumpMobileResolution()
	{
		return "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAA.SharpenLimitDepth") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.TemporalAA.Sharpness") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.ScreenPercentage");
	}

	// Token: 0x06005BB9 RID: 23481 RVA: 0x0016EE99 File Offset: 0x0016D099
	public string DumpTextLanguage()
	{
		return "LanguageSystem.PackageLanguage: " + Singleton<LanguageSystem>.Instance.PackageLanguage;
	}

	// Token: 0x06005BBA RID: 23482 RVA: 0x0016EEAF File Offset: 0x0016D0AF
	public string DumpVoiceLanguage()
	{
		return "LanguageSystem.PackageAudio: " + Singleton<LanguageSystem>.Instance.PackageAudio;
	}

	// Token: 0x06005BBB RID: 23483 RVA: 0x0016EEC8 File Offset: 0x0016D0C8
	public string DumpHorizontalViewSensitivity()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CameraBaseYawSensitivity: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(ModelBase<CameraModel>.Instance.MainModel.CameraBaseYawSensitivity);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BBC RID: 23484 RVA: 0x0016EF08 File Offset: 0x0016D108
	public string DumpVerticalViewSensitivity()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CameraBasePitchSensitivity: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(ModelBase<CameraModel>.Instance.MainModel.CameraBasePitchSensitivity);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BBD RID: 23485 RVA: 0x0016EF48 File Offset: 0x0016D148
	public string DumpAimHorizontalViewSensitivity()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CameraAimingYawSensitivity: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(ModelBase<CameraModel>.Instance.MainModel.CameraAimingYawSensitivity);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BBE RID: 23486 RVA: 0x0016EF88 File Offset: 0x0016D188
	public string DumpAimVerticalViewSensitivity()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CameraAimingPitchSensitivity: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(ModelBase<CameraModel>.Instance.MainModel.CameraAimingPitchSensitivity);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BBF RID: 23487 RVA: 0x0016EFC8 File Offset: 0x0016D1C8
	public string DumpCameraShakeStrength()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
		defaultInterpolatedStringHandler.AppendLiteral("ShakeModify: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(ModelBase<CameraModel>.Instance.MainModel.ShakeModify);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC0 RID: 23488 RVA: 0x0016F008 File Offset: 0x0016D208
	public string DumpCommonSpringArmLength()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CameraSettingNormalAdditionArmLength: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(ModelBase<CameraModel>.Instance.MainModel.CameraSettingNormalAdditionArmLength);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC1 RID: 23489 RVA: 0x0016F048 File Offset: 0x0016D248
	public string DumpFightSpringArmLength()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CameraSettingFightAdditionArmLength: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(ModelBase<CameraModel>.Instance.MainModel.CameraSettingFightAdditionArmLength);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC2 RID: 23490 RVA: 0x0016F088 File Offset: 0x0016D288
	public string DumpResetFocusEnable()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
		defaultInterpolatedStringHandler.AppendLiteral("IsEnableResetFocus: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<CameraModel>.Instance.MainModel.IsEnableResetFocus);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC3 RID: 23491 RVA: 0x0016F0C8 File Offset: 0x0016D2C8
	public string DumpIsSidestepCameraEnable()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
		defaultInterpolatedStringHandler.AppendLiteral("IsEnableSidestepCamera: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<CameraModel>.Instance.MainModel.IsEnableSidestepCamera);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC4 RID: 23492 RVA: 0x0016F108 File Offset: 0x0016D308
	public string DumpIsSoftLockCameraEnable()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
		defaultInterpolatedStringHandler.AppendLiteral("IsEnableSoftLockCameraExternal: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<CameraModel>.Instance.MainModel.IsEnableSoftLockCameraExternal);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC5 RID: 23493 RVA: 0x0016F148 File Offset: 0x0016D348
	public string DumpWalkOrRunRate()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetWalkOrRunRate: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(RoleGaitStatic.GetWalkOrRunRate());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC6 RID: 23494 RVA: 0x0016F180 File Offset: 0x0016D380
	public string DumpJoystickMode()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetIsDynamicJoystick: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<BattleUiModel>.Instance.GetIsDynamicJoystick());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC7 RID: 23495 RVA: 0x0016F1BC File Offset: 0x0016D3BC
	public string DumpSkillButtonMode()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetIsAutoSwitchSkillButtonMode: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<BattleUiModel>.Instance.GetIsAutoSwitchSkillButtonMode());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC8 RID: 23496 RVA: 0x0016F1F8 File Offset: 0x0016D3F8
	public string DumpAimAssist()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetAimAssistEnable: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<CameraModel>.Instance.MainModel.GetAimAssistEnable());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BC9 RID: 23497 RVA: 0x0016F238 File Offset: 0x0016D438
	public string DumpKeyboardLockEnemyMode()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
		defaultInterpolatedStringHandler.AppendLiteral("DumpKeyboardLockEnemyMode: ");
		defaultInterpolatedStringHandler.AppendFormatted<ELockEnemyMode>(ModelBase<FormationDataModel>.Instance.KeyboardLockEnemyMode);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BCA RID: 23498 RVA: 0x0016F274 File Offset: 0x0016D474
	public string DumpGamepadLockEnemyMode()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
		defaultInterpolatedStringHandler.AppendLiteral("DumpGamepadLockEnemyMode: ");
		defaultInterpolatedStringHandler.AppendFormatted<ELockEnemyMode>(ModelBase<FormationDataModel>.Instance.GamepadLockEnemyMode);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BCB RID: 23499 RVA: 0x0016F2B0 File Offset: 0x0016D4B0
	public string DumpEnemyHitDisplayMode()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
		defaultInterpolatedStringHandler.AppendLiteral("OpenHitMaterial: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<BulletModel>.Instance.OpenHitMaterial);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BCC RID: 23500 RVA: 0x0016F2EB File Offset: 0x0016D4EB
	public string DumpAutoAdjustImageQuality()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.AutoCoolUIEnable");
	}

	// Token: 0x06005BCD RID: 23501 RVA: 0x0016F2F8 File Offset: 0x0016D4F8
	public string DumpShowDamage()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetDamageViewVisible: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(Singleton<DamageUiManager>.Instance.GetDamageViewVisible());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BCE RID: 23502 RVA: 0x0016F334 File Offset: 0x0016D534
	public string DumpDynamicBones()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
		defaultInterpolatedStringHandler.AppendLiteral("KuroLodMask: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<CreatureModel>.Instance.KuroLodMask);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BCF RID: 23503 RVA: 0x0016F36F File Offset: 0x0016D56F
	public string DumpRayTracing()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("sg.RayTracingQuality");
	}

	// Token: 0x06005BD0 RID: 23504 RVA: 0x0016F37B File Offset: 0x0016D57B
	public string DumpRayTracedReflection()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Lumen.Reflections.Allow");
	}

	// Token: 0x06005BD1 RID: 23505 RVA: 0x0016F387 File Offset: 0x0016D587
	public string DumpRayTracedGI()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Lumen.DiffuseIndirect.Allow");
	}

	// Token: 0x06005BD2 RID: 23506 RVA: 0x0016F394 File Offset: 0x0016D594
	public string DumpTeammateFx()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
		defaultInterpolatedStringHandler.AppendLiteral("EffectEnvironment.DisableOtherEffect: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(Singleton<EffectEnvironment>.Instance.DisableOtherEffect);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BD3 RID: 23507 RVA: 0x0016F3CF File Offset: 0x0016D5CF
	public string DumpSaturation()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Client.Saturation");
	}

	// Token: 0x06005BD4 RID: 23508 RVA: 0x0016F3DB File Offset: 0x0016D5DB
	public string DumpContrast()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Client.Contrast");
	}

	// Token: 0x06005BD5 RID: 23509 RVA: 0x0016F3E8 File Offset: 0x0016D5E8
	public string DumpFilter()
	{
		int global = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.FilterSettingId, 0);
		Dictionary<int, float[]> global2 = LocalStorage.GetGlobal<Dictionary<int, float[]>>(ELocalStorageGlobalKey.FilterSettingValues, null);
		float[] array;
		if (global2 == null || !global2.TryGetValue(global, out array) || array == null)
		{
			return "滤镜数据不完整，或者尚未初始化";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 4);
		defaultInterpolatedStringHandler.AppendLiteral("滤镜数据：Id：");
		defaultInterpolatedStringHandler.AppendFormatted<int>(global);
		defaultInterpolatedStringHandler.AppendLiteral(", x: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(array[0]);
		defaultInterpolatedStringHandler.AppendLiteral(", y: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(array[1]);
		defaultInterpolatedStringHandler.AppendLiteral(", intensity: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(array[2]);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BD6 RID: 23510 RVA: 0x0016F48B File Offset: 0x0016D68B
	public string DumpImageDisplayMode()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.ImageDisplayMode");
	}

	// Token: 0x06005BD7 RID: 23511 RVA: 0x0016F497 File Offset: 0x0016D697
	public string DumpEyeProtection()
	{
		return "";
	}

	// Token: 0x06005BD8 RID: 23512 RVA: 0x0016F49E File Offset: 0x0016D69E
	public string DumpEyeProtectionMode()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.EyeProtectionMode");
	}

	// Token: 0x06005BD9 RID: 23513 RVA: 0x0016F4AA File Offset: 0x0016D6AA
	public string DumpEyeProtectionTemp()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.EyeProtectionTemp");
	}

	// Token: 0x06005BDA RID: 23514 RVA: 0x0016F4B6 File Offset: 0x0016D6B6
	public string DumpEyeProtectionStrength()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.EyeProtectionStrength");
	}

	// Token: 0x06005BDB RID: 23515 RVA: 0x0016F4C2 File Offset: 0x0016D6C2
	public string DumpEyeProtectionBrightness()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.EyeProtectionBrightness");
	}

	// Token: 0x06005BDC RID: 23516 RVA: 0x0016F4CE File Offset: 0x0016D6CE
	public string DumpEyeProtectionTexture()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.EyeProtectionTexture");
	}

	// Token: 0x06005BDD RID: 23517 RVA: 0x0016F4DC File Offset: 0x0016D6DC
	public string DumpSkinDamageMode()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CharacterSkinDamageComponent.EnableSkinDamage: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(CharacterSkinDamageComponent.EnableSkinDamage);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BDE RID: 23518 RVA: 0x0016F512 File Offset: 0x0016D712
	public string DumpAdrenoFME()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.FEstimation.Option");
	}

	// Token: 0x06005BDF RID: 23519 RVA: 0x0016F520 File Offset: 0x0016D720
	public string DumpAutoRun()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("AutoMovingSettingEnable: ");
		BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
		bool? value;
		if (instance == null)
		{
			value = null;
		}
		else
		{
			BattleUiFormationData formationData = instance.FormationData;
			value = ((formationData != null) ? new bool?(formationData.AutoMovingSettingEnable) : null);
		}
		defaultInterpolatedStringHandler.AppendFormatted<bool?>(value);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BE0 RID: 23520 RVA: 0x0016F584 File Offset: 0x0016D784
	public string DumpAutoSprint()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("AutoSprintSettingEnable: ");
		BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
		bool? value;
		if (instance == null)
		{
			value = null;
		}
		else
		{
			BattleUiFormationData formationData = instance.FormationData;
			value = ((formationData != null) ? new bool?(formationData.AutoSprintSettingEnable) : null);
		}
		defaultInterpolatedStringHandler.AppendFormatted<bool?>(value);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BE1 RID: 23521 RVA: 0x0016F5E8 File Offset: 0x0016D7E8
	public string DumpVulkan()
	{
		return "" + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Android.VulkanSetting") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Android.DefaultVulkanSetting") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Android.DisableVulkanSupport") + GameSettingsDumpUtils.DumpConsoleVarNumber("r.Mobile.FlushSceneColorRendering");
	}

	// Token: 0x06005BE2 RID: 23522 RVA: 0x0016F638 File Offset: 0x0016D838
	public string DumpWaterInteract()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SceneBattleInteractModel.Open: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(ModelBase<SceneBattleInteractModel>.Instance.Open);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005BE3 RID: 23523 RVA: 0x0016F673 File Offset: 0x0016D873
	public string DumpVegetationDither()
	{
		return "";
	}

	// Token: 0x06005BE4 RID: 23524 RVA: 0x0016F67A File Offset: 0x0016D87A
	public string DumpVegetationDensity()
	{
		return "";
	}

	// Token: 0x06005BE5 RID: 23525 RVA: 0x0016F681 File Offset: 0x0016D881
	public string DumpAutoExposure()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("r.Kuro.AutoExposurePlayerCustom");
	}

	// Token: 0x06005BE6 RID: 23526 RVA: 0x0016F68D File Offset: 0x0016D88D
	public string DumpLoadingRangeScaleLevel()
	{
		return GameSettingsDumpUtils.DumpConsoleVarNumber("wp.Runtime.PlannedLoadingRangeScaleExtra");
	}
}
