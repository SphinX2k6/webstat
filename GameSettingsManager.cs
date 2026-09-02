using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Util;
using UnrealEngine;

// Token: 0x02000E9A RID: 3738
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GameSettingsManager : Singleton<GameSettingsManager>
{
	// Token: 0x17000696 RID: 1686
	// (get) Token: 0x06005BEC RID: 23532 RVA: 0x0016FA20 File Offset: 0x0016DC20
	public unsafe Dictionary<EFunction, MenuConfig> ValidApplyConfigMap
	{
		get
		{
			if (this.ValidApplyConfigMapInternal == null)
			{
				this.ValidApplyConfigMapInternal = new Dictionary<EFunction, MenuConfig>();
				IReadOnlyList<MenuConfig> menuBaseConfig = ConfigBase<MenuBaseConfig>.Instance.GetMenuBaseConfig();
				if (menuBaseConfig == null)
				{
					return this.ValidApplyConfigMapInternal;
				}
				foreach (MenuConfig menuConfig in menuBaseConfig)
				{
					bool item = this.CheckConfigValidByCheckList(menuConfig).Item1;
					if (item)
					{
						if (!this.IsButtonSetting(menuConfig) && !Enum.IsDefined(typeof(EFunction), menuConfig.FunctionId))
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.GameSettings;
							ELogAuthor author = ELogAuthor.WZ;
							string message = "存在未注册在EFunction中的功能（非按键），视作该功能不存在";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("cfg id", menuConfig.Id);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("cfg FunctionId", menuConfig.FunctionId);
							instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						}
						else if (this.ValidApplyConfigMapInternal.ContainsKey((EFunction)menuConfig.FunctionId))
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.GameSettings;
							ELogAuthor author2 = ELogAuthor.WZ;
							string message2 = "可应用的选项出现冲突，请认真检查配置【CheckList】";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("出现冲突的functionId", menuConfig.FunctionId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("已保存的设置id", this.ValidApplyConfigMapInternal[(EFunction)menuConfig.FunctionId].Id);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("发生冲突的设置id", menuConfig.Id);
							instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
						}
						else
						{
							this.ValidApplyConfigMapInternal[(EFunction)menuConfig.FunctionId] = menuConfig;
						}
					}
				}
			}
			return this.ValidApplyConfigMapInternal;
		}
	}

	// Token: 0x06005BED RID: 23533 RVA: 0x0016FC28 File Offset: 0x0016DE28
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, string> CheckConfigValidByCheckList(MenuConfig cfg)
	{
		ValueTuple<bool, string> valueTuple = this.CheckPlatform(cfg);
		bool item = valueTuple.Item1;
		string item2 = valueTuple.Item2;
		if (!item)
		{
			return new ValueTuple<bool, string>(false, "CheckPlatform:" + item2);
		}
		ValueTuple<bool, string> valueTuple2 = this.CheckDeviceVendor(cfg.FunctionId);
		bool item3 = valueTuple2.Item1;
		string item4 = valueTuple2.Item2;
		if (!item3)
		{
			return new ValueTuple<bool, string>(false, "CheckDeviceVendor:" + item4);
		}
		ValueTuple<bool, string> valueTuple3 = this.CheckDeviceExtraConditions(cfg);
		bool item5 = valueTuple3.Item1;
		string item6 = valueTuple3.Item2;
		if (!item5)
		{
			return new ValueTuple<bool, string>(false, "CheckDeviceExtra:" + item6);
		}
		return new ValueTuple<bool, string>(true, "NONE");
	}

	// Token: 0x06005BEE RID: 23534 RVA: 0x0016FCC5 File Offset: 0x0016DEC5
	public bool IsShowMobileVeryHighOption()
	{
		return Singleton<GameSettingsDeviceRender>.Instance.DeviceType == EGameDeviceType.ANDROID_VERY_HIGH || Singleton<GameSettingsDeviceRender>.Instance.DeviceType == EGameDeviceType.IOS_VERY_HIGH;
	}

	// Token: 0x06005BEF RID: 23535 RVA: 0x0016FCE5 File Offset: 0x0016DEE5
	public bool IsShowPcVeryHighOption()
	{
		if (Singleton<GameSettingsDeviceRender>.Instance.IsNvidiaLaptopGPU())
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.DeviceType == EGameDeviceType.PC_HIGH)
			{
				return true;
			}
		}
		else if (Singleton<GameSettingsDeviceRender>.Instance.DeviceType == EGameDeviceType.PC_VERY_HIGH)
		{
			return true;
		}
		return false;
	}

	// Token: 0x06005BF0 RID: 23536 RVA: 0x0016FD14 File Offset: 0x0016DF14
	public bool IsShowVeryHighOption()
	{
		if (Singleton<Info>.Instance.IsPcPlatform())
		{
			return this.IsShowPcVeryHighOption();
		}
		return Singleton<Info>.Instance.IsMobilePlatform() && this.IsShowMobileVeryHighOption();
	}

	// Token: 0x06005BF1 RID: 23537 RVA: 0x0016FD40 File Offset: 0x0016DF40
	public bool IsShowPcHighestOption()
	{
		if (!Singleton<GameSettingsDeviceRender>.Instance.IsFrameRate120DeviceForAllDevice())
		{
			return false;
		}
		if (Singleton<GameSettingsDeviceRender>.Instance.IsNvidiaLaptopGPU())
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.DeviceType == EGameDeviceType.PC_VERY_HIGH)
			{
				return true;
			}
		}
		else if (Singleton<GameSettingsDeviceRender>.Instance.DeviceType == EGameDeviceType.PC_HIGHEST)
		{
			return true;
		}
		return Singleton<GameSettingsDeviceRender>.Instance.IsNvidia5060AndAbove();
	}

	// Token: 0x06005BF2 RID: 23538 RVA: 0x0016FD96 File Offset: 0x0016DF96
	public bool IsPcHighestDevice()
	{
		return Singleton<GameSettingsDeviceRender>.Instance.DeviceType == EGameDeviceType.PC_HIGHEST && Singleton<GameSettingsDeviceRender>.Instance.IsFrameRate120DeviceForAllDevice();
	}

	// Token: 0x06005BF3 RID: 23539 RVA: 0x0016FDB4 File Offset: 0x0016DFB4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private ValueTuple<bool, string> CheckDeviceExtraConditions(MenuConfig cfg)
	{
		string device = cfg.Device;
		if (device == "isBelowVeryHigh")
		{
			return new ValueTuple<bool, string>(!this.IsShowVeryHighOption() && !this.IsShowPcHighestOption(), "isBelowVeryHigh");
		}
		if (device == "isShowVeryHigh")
		{
			return new ValueTuple<bool, string>(this.IsShowVeryHighOption(), "isShowVeryHigh");
		}
		if (device == "isShowHighest")
		{
			return new ValueTuple<bool, string>(this.IsShowPcHighestOption(), "isShowHighest");
		}
		if (device == "isNotAndroidVeryHigh")
		{
			return new ValueTuple<bool, string>(!Singleton<Info>.Instance.IsAndroidPlatform() || !Singleton<GameSettingsDeviceRender>.Instance.IsAndroidHighestResolutionDevice(), "isNotAndroidVeryHigh");
		}
		if (device == "isAndroidVeryHigh")
		{
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsAndroidPlatform() && Singleton<GameSettingsDeviceRender>.Instance.IsAndroidHighestResolutionDevice(), "isAndroidVeryHigh");
		}
		if (device == "isLowMemory")
		{
			return new ValueTuple<bool, string>(UKuroStaticLibrary.IsLowMemoryDevice(), "isLowMemory");
		}
		if (device == "isNotLowMemory")
		{
			return new ValueTuple<bool, string>(!UKuroStaticLibrary.IsLowMemoryDevice(), "isNotLowMemory");
		}
		if (device == "isNot120Frame")
		{
			return new ValueTuple<bool, string>(!Singleton<GameSettingsDeviceRender>.Instance.IsFrameRate120DeviceForAllDevice(), "isNot120Frame");
		}
		if (device == "is120Frame")
		{
			return new ValueTuple<bool, string>(Singleton<GameSettingsDeviceRender>.Instance.IsFrameRate120DeviceForAllDevice(), "is120Frame");
		}
		if (device == "isCloudGame")
		{
			return new ValueTuple<bool, string>(Singleton<Platform>.Instance.IsCloudGame(), "isCloudGame");
		}
		if (device == "isNotCloudGame")
		{
			return new ValueTuple<bool, string>(!Singleton<Platform>.Instance.IsCloudGame(), "isNotCloudGame");
		}
		if (device == "isNotColudGameNotOpenHarmony")
		{
			return new ValueTuple<bool, string>(!Singleton<Platform>.Instance.IsCloudGame() && !Singleton<Platform>.Instance.IsOpenHarmonyPlatform(), "isNotColudGameAndOpenHarmony");
		}
		if (device == "isOpenHarmony")
		{
			return new ValueTuple<bool, string>(Singleton<Platform>.Instance.IsOpenHarmonyPlatform(), "isOpenHarmony");
		}
		if (device == "isNotOpenHarmony")
		{
			return new ValueTuple<bool, string>(!Singleton<Platform>.Instance.IsOpenHarmonyPlatform(), "isNotOpenHarmony");
		}
		if (device == "isAutoAdjustImageQuality")
		{
			return new ValueTuple<bool, string>(Singleton<Platform>.Instance.IsPcPlatform() || Singleton<Platform>.Instance.IsAndroidPlatform() || Singleton<Platform>.Instance.IsOpenHarmonyPlatform(), "isAutoAdjustImageQuality");
		}
		if (device == "isMac")
		{
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsMacPlatform(), "isMac");
		}
		if (device == "isNotMac")
		{
			return new ValueTuple<bool, string>(!Singleton<Info>.Instance.IsMacPlatform(), "isNotMac");
		}
		if (device == "isNotMobile")
		{
			return new ValueTuple<bool, string>(!Singleton<Info>.Instance.IsMobilePlatform(), "isNotMobile");
		}
		if (device == "isMetalSupport")
		{
			return new ValueTuple<bool, string>(Singleton<GameSettingsDeviceRender>.Instance.IsMetalFxDevice(), "isMetalSupport");
		}
		if (device == "isRedMagicLow")
		{
			return new ValueTuple<bool, string>(Singleton<GameSettingsDeviceRender>.Instance.IsRedMagicLow(), "isRedMagicLow");
		}
		if (device == "isRedMagicHigh")
		{
			return new ValueTuple<bool, string>(Singleton<GameSettingsDeviceRender>.Instance.IsRedMagicHigh(), "isRedMagicHigh");
		}
		if (device == "isNotRedMagic")
		{
			return new ValueTuple<bool, string>(!Singleton<GameSettingsDeviceRender>.Instance.IsRedMagic(), "isNotRedMagic");
		}
		if (device == "isNotGrayscale")
		{
			return new ValueTuple<bool, string>(Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit(), "isNotGrayscale");
		}
		if (device == "isNotClearPack")
		{
			return new ValueTuple<bool, string>(Singleton<VideoResUpdate>.Instance.IsVideoClearGrayBoxHit(), "isNotClearPack");
		}
		if (device == "is50Series")
		{
			return new ValueTuple<bool, string>(Singleton<GameSettingsDeviceRender>.Instance.IsRTX50(), "is50Series");
		}
		if (device == "isNot50Series")
		{
			return new ValueTuple<bool, string>(!Singleton<GameSettingsDeviceRender>.Instance.IsRTX50(), "isNot50Series");
		}
		if (device == "isWindows")
		{
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsWindowsPlatform() && !Singleton<Platform>.Instance.IsCloudGame(), "isWindows");
		}
		if (device == "isNotWindows")
		{
			return new ValueTuple<bool, string>(!Singleton<Info>.Instance.IsWindowsPlatform() || Singleton<Platform>.Instance.IsCloudGame(), "isNotWindows");
		}
		if (device == "isEnergySavingFrameGen")
		{
			return new ValueTuple<bool, string>(Singleton<GameSettingsDeviceRender>.Instance.IsEnergySavingFrameInterpolationSupported(), "isEnergySavingFrameGen");
		}
		if (device == "isNotEnergySavingFrameGen")
		{
			return new ValueTuple<bool, string>(!Singleton<GameSettingsDeviceRender>.Instance.IsEnergySavingFrameInterpolationSupported(), "isNotEnergySavingFrameGen");
		}
		if (device == "isNotIOS")
		{
			return new ValueTuple<bool, string>(!Singleton<Info>.Instance.IsIosPlatform(), "isNotIOS");
		}
		if (device == "WindowsAndMobile")
		{
			return new ValueTuple<bool, string>((Singleton<Info>.Instance.IsWindowsPlatform() && !Singleton<Platform>.Instance.IsCloudGame()) || Singleton<Info>.Instance.IsMobilePlatform(), "WindowsAndMobile");
		}
		return new ValueTuple<bool, string>(true, "DEFAULT");
	}

	// Token: 0x06005BF4 RID: 23540 RVA: 0x001702B4 File Offset: 0x0016E4B4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private ValueTuple<bool, string> CheckDeviceVendor(int functionId)
	{
		bool item = Singleton<GameSettingsDeviceRender>.Instance.IsDlssGpuDevice() && Singleton<GameSettingsDeviceRender>.Instance.IsDlssSupported();
		bool flag = Singleton<GameSettingsDeviceRender>.Instance.IsFsrDevice();
		bool item2 = Singleton<GameSettingsDeviceRender>.Instance.IsPWSDKDevice();
		bool flag2 = Singleton<GameSettingsDeviceRender>.Instance.IsDlss3GpuDevice() && Singleton<GameSettingsDeviceRender>.Instance.IsDlssSupported();
		bool item3 = Singleton<GameSettingsDeviceRender>.Instance.IsVulkanDevice();
		bool flag3 = Singleton<GameSettingsDeviceRender>.Instance.GetD3D12Type() > 0;
		bool item4 = false;
		bool flag4 = Singleton<GameSettingsDeviceRender>.Instance.IsXess2Supported();
		bool flag5 = Singleton<GameSettingsDeviceRender>.Instance.IsXeFGSupported();
		bool flag6 = UKuroFFXFSR3BlueprintLibrary.IsGlobalSwitchOn();
		bool flag7 = Singleton<GameSettingsDeviceRender>.Instance.IsFsr3Supported();
		bool flag8 = Singleton<GameSettingsDeviceRender>.Instance.IsFFXFISupported();
		bool flag9 = Singleton<GameSettingsDeviceRender>.Instance.IsFsr3FallbackToFsr();
		bool flag10 = Singleton<GameSettingsDeviceRender>.Instance.IsShowRayTracingSetting();
		bool flag11 = this.GetCurrentValueSafely(EFunction.RayTracing, 0, true) > 0;
		bool item5 = UKuroRenderingRuntimeBPPluginBPLibrary.GetLumenGISupported() && flag10 && flag11;
		bool item6 = UKuroRenderingRuntimeBPPluginBPLibrary.GetLumenReflectionsSupported() && flag10 && flag11;
		bool item7 = UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingShadowsSupported() && flag10 && flag11;
		bool item8 = UKismetRenderingLibrary.IsSupportedAFME();
		if (functionId <= 831)
		{
			if (functionId <= 76)
			{
				if (functionId == 58)
				{
					return new ValueTuple<bool, string>(!Singleton<Info>.Instance.IsMobilePlatform() || Singleton<GameSettingsDeviceRender>.Instance.IsAndroidPlatformAOValid() || Singleton<GameSettingsDeviceRender>.Instance.IsIOSPlatformAOValid() || Singleton<Info>.Instance.IsOpenHarmonyPlatform(), "EFunction.SCENEAO");
				}
				if (functionId == 63)
				{
					return new ValueTuple<bool, string>(!Singleton<Info>.Instance.IsMacPlatform(), "EFunction.VOLUMEFOG");
				}
				if (functionId == 76)
				{
					return new ValueTuple<bool, string>(UKuroAudioStatics.IsDolbyAtmosGameSupported(), "EFunction.DOLBYATOMS");
				}
			}
			else
			{
				switch (functionId)
				{
				case 81:
					return new ValueTuple<bool, string>(item, "EFunction.NVIDIADLSS");
				case 82:
					return new ValueTuple<bool, string>(flag2 && flag3, "EFunction.NVIDIADLSSFG");
				case 83:
				case 86:
					break;
				case 84:
					return new ValueTuple<bool, string>(item, "EFunction.NVIDIADLSSSHARPNESS");
				case 85:
					return new ValueTuple<bool, string>(item, "EFunction.NVIDIAREFLEX");
				case 87:
					return new ValueTuple<bool, string>(flag || flag9, "EFunction.FSR");
				default:
					switch (functionId)
					{
					case 125:
						return new ValueTuple<bool, string>(item4, "EFunction.XESS");
					case 126:
						return new ValueTuple<bool, string>(item4, "EFunction.XESS_QUALITY");
					case 127:
						return new ValueTuple<bool, string>(Singleton<GameSettingsDeviceRender>.Instance.IsMetalFxDevice(), "EFunction.METALFX");
					case 128:
						return new ValueTuple<bool, string>(item2, "EFunction.IRX");
					default:
						if (functionId == 831)
						{
							return new ValueTuple<bool, string>(item, "EFunction.NVIDIADLSSQUALITY");
						}
						break;
					}
					break;
				}
			}
		}
		else if (functionId <= 20340)
		{
			switch (functionId)
			{
			case 20026:
				return new ValueTuple<bool, string>(flag10, "EFunction.RayTracing");
			case 20027:
				return new ValueTuple<bool, string>(item6, "EFunction.RayTracedReflection");
			case 20028:
				return new ValueTuple<bool, string>(item5, "EFunction.RayTracedGI");
			case 20029:
				return new ValueTuple<bool, string>(item7, "EFunction.RayTracedShadow");
			case 20030:
			case 20031:
				break;
			case 20032:
				return new ValueTuple<bool, string>(item8, "EFunction.AdrenoFME");
			default:
				if (functionId == 20310 || functionId == 20340)
				{
					return new ValueTuple<bool, string>(flag4, "EFunction.XESS2");
				}
				break;
			}
		}
		else if (functionId <= 20351)
		{
			if (functionId == 20341)
			{
				return new ValueTuple<bool, string>(flag4 && flag5, "EFunction.XESS2_FG");
			}
			if (functionId - 20350 <= 1)
			{
				return new ValueTuple<bool, string>(flag7 && flag3 && flag6, "EFunction.FSR3");
			}
		}
		else
		{
			if (functionId == 20352)
			{
				return new ValueTuple<bool, string>(flag8 && flag3 && flag6, "EFunction.FSR3_FG");
			}
			if (functionId == 20360)
			{
				return new ValueTuple<bool, string>(item3, "EFunction.Vulkan");
			}
		}
		return new ValueTuple<bool, string>(true, "DEFAULT");
	}

	// Token: 0x06005BF5 RID: 23541 RVA: 0x00170658 File Offset: 0x0016E858
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private ValueTuple<bool, string> CheckPlatform(MenuConfig menuCfg)
	{
		EMenuConfigPlatform platform = (EMenuConfigPlatform)menuCfg.Platform;
		switch (platform)
		{
		case EMenuConfigPlatform.NORMAL:
			return new ValueTuple<bool, string>(true, "EMenuConfigPlatform.NORMAL");
		case EMenuConfigPlatform.PC_OR_PS:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsPcOrGamepadPlatform() && !Singleton<Platform>.Instance.IsCloudGame(), "EMenuConfigPlatform.PC_OR_PS");
		case EMenuConfigPlatform.MOBILE:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsMobilePlatform() || Singleton<Info>.Instance.IsOpenHarmonyPlatform() || Singleton<Platform>.Instance.IsCloudGame(), "EMenuConfigPlatform.MOBILE");
		case EMenuConfigPlatform.ANDROID:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsAndroidPlatform() || Singleton<Info>.Instance.IsOpenHarmonyPlatform(), "EMenuConfigPlatform.ANDROID");
		case EMenuConfigPlatform.IOS:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsIosPlatform(), "EMenuConfigPlatform.IOS");
		case EMenuConfigPlatform.PlayStation:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsPs5Platform(), "EMenuConfigPlatform.PlayStation");
		case EMenuConfigPlatform.PC_ONLY:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsPcPlatform(), "EMenuConfigPlatform.PC_ONLY");
		case EMenuConfigPlatform.XBOX_ONLY:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsXboxPlatform(), "EMenuConfigPlatform.XBOX_ONLY");
		case EMenuConfigPlatform.WinGDK_ONLY:
			return new ValueTuple<bool, string>(Singleton<Info>.Instance.IsWinGDKPlatform(), "EMenuConfigPlatform.WinGDK_ONLY");
		default:
			if (platform != EMenuConfigPlatform.NONE)
			{
				return new ValueTuple<bool, string>(false, "DEFAULT");
			}
			return new ValueTuple<bool, string>(true, "EMenuConfigPlatform.NONE");
		}
	}

	// Token: 0x06005BF6 RID: 23542 RVA: 0x001707AC File Offset: 0x0016E9AC
	public bool IsButtonSetting(MenuConfig menuCfg)
	{
		return menuCfg.Platform != 99 && (menuCfg.MainType == 3 && menuCfg.Platform != 2 && menuCfg.FunctionId != 129) && menuCfg.FunctionId != 134;
	}

	// Token: 0x06005BF7 RID: 23543 RVA: 0x001707FC File Offset: 0x0016E9FC
	private void AssignCacheValueByDeviceRenderFeature(DeviceRenderFeature targetCfg, EGameSettingsInitSourceType sourceType)
	{
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.IMAGEQUALITY);
		if (valueOrDefault != null)
		{
			valueOrDefault.CacheValue(targetCfg.QualityType, sourceType);
		}
		foreach (KeyValuePair<EFunction, int> keyValuePair in Singleton<GameSettingsDeviceRender>.Instance.GetOtherChangedValue(targetCfg))
		{
			EFunction efunction;
			int num;
			keyValuePair.Deconstruct(out efunction, out num);
			EFunction efunction2 = efunction;
			int num2 = num;
			if (efunction2 != EFunction.RayTracing)
			{
				if (efunction2 == EFunction.SUPERRESOLUTION)
				{
					if (Singleton<Info>.Instance.IsWindowsPlatform())
					{
						EFunction efunction3 = EFunction.SUPERRESOLUTION;
						EFunction efunction4 = EFunction.SUPERRESOLUTION;
						int num3 = num2;
						ValueTuple<EFunction, EFunction, int> valueTuple = Singleton<GameSettingsDeviceRender>.Instance.MapSuperResolutionRecommendValue(efunction3, efunction4, num3);
						efunction3 = valueTuple.Item1;
						efunction4 = valueTuple.Item2;
						num3 = valueTuple.Item3;
						GameSettingsInitValueSource valueOrDefault2 = this.ValidInitValueSourceCache.GetValueOrDefault(efunction3);
						if (valueOrDefault2 != null)
						{
							valueOrDefault2.CacheValue(1, sourceType);
						}
						GameSettingsInitValueSource valueOrDefault3 = this.ValidInitValueSourceCache.GetValueOrDefault(efunction4);
						if (valueOrDefault3 != null)
						{
							valueOrDefault3.CacheValue(num3, sourceType);
						}
					}
				}
				else
				{
					GameSettingsInitValueSource valueOrDefault4 = this.ValidInitValueSourceCache.GetValueOrDefault(efunction2);
					if (valueOrDefault4 != null)
					{
						valueOrDefault4.CacheValue(num2, sourceType);
					}
				}
			}
		}
	}

	// Token: 0x06005BF8 RID: 23544 RVA: 0x0017093C File Offset: 0x0016EB3C
	private unsafe void AssignCacheValueByTransferViewSensitivity(EFunction functionId)
	{
		int? global = LocalStorage.GetGlobal<int?>((ELocalStorageGlobalKey)GameSettingsDefine.function2GameSettings.GetValueOrDefault(functionId).GetCallbackOrGlobalKey, null);
		if (global != null)
		{
			int? num = global;
			int num2 = 50;
			if (num.GetValueOrDefault() < num2 & num != null)
			{
				int num3 = (int)Math.Floor(22.22 + 0.555 * (double)global.Value);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Menu;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "[ViewSensitivity]转化视角灵敏度";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", functionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", global);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("newValue", num3);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(functionId);
				if (valueOrDefault == null)
				{
					return;
				}
				valueOrDefault.CacheValue(num3, EGameSettingsInitSourceType.InitOverride);
			}
		}
	}

	// Token: 0x06005BF9 RID: 23545 RVA: 0x00170A54 File Offset: 0x0016EC54
	private void AssignCacheValueByPlayerMenuInfo(Dictionary<int, double> data, EFunction functionId, EGameSettingsInitSourceType reason)
	{
		double num;
		if (!data.TryGetValue((int)functionId, out num))
		{
			return;
		}
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(functionId);
		if (valueOrDefault == null)
		{
			return;
		}
		valueOrDefault.CacheValue((int)num, reason);
	}

	// Token: 0x06005BFA RID: 23546 RVA: 0x00170A8C File Offset: 0x0016EC8C
	private void CacheInitDataFromOverride()
	{
		this.CacheOverrideForViewSensitivity();
		this.CacheOverrideForDisplayMode();
		this.CacheOverrideForCloudGame();
		this.CacheOverrideForDlssQuality();
		this.CacheOverrideForDlssFrameGenerate();
		this.CacheOverrideForResetBrightness();
		this.CacheOverrideForNpcDensity();
		this.CacheOverrideForHdr();
		this.CacheOverrideForMotorRoundJoyStick();
		this.CacheOverrideForMobileShadowQuality();
		GameSettingsManager.CacheOverrideForRecommendImageQualityRelated();
	}

	// Token: 0x06005BFB RID: 23547 RVA: 0x00170ADC File Offset: 0x0016ECDC
	private void CacheOverrideForViewSensitivity()
	{
		if (!LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.IsConvertAllViewSensitivity, false))
		{
			if (Singleton<Info>.Instance.IsPcPlatform())
			{
				Singleton<Log>.Instance.Info(ELogModule.Menu, ELogAuthor.WZ, " [ViewSensitivity]转化Pc视角灵敏度", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.AssignCacheValueByTransferViewSensitivity(EFunction.HorizontalViewSensitivity);
				this.AssignCacheValueByTransferViewSensitivity(EFunction.VerticalViewSensitivity);
				this.AssignCacheValueByTransferViewSensitivity(EFunction.AimHorizontalViewSensitivity);
				this.AssignCacheValueByTransferViewSensitivity(EFunction.AimVerticalViewSensitivity);
			}
			if (Singleton<Info>.Instance.IsMobilePlatform())
			{
				Singleton<Log>.Instance.Info(ELogModule.Menu, ELogAuthor.WZ, "[ViewSensitivity]转化Mobile视角灵敏度", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.AssignCacheValueByTransferViewSensitivity(EFunction.MobileHorizontalViewSensitivity);
				this.AssignCacheValueByTransferViewSensitivity(EFunction.MobileVerticalViewSensitivity);
				this.AssignCacheValueByTransferViewSensitivity(EFunction.MobileAimHorizontalViewSensitivity);
				this.AssignCacheValueByTransferViewSensitivity(EFunction.MobileAimVerticalViewSensitivity);
			}
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.IsConvertAllViewSensitivity, true);
		}
	}

	// Token: 0x06005BFC RID: 23548 RVA: 0x00170B8F File Offset: 0x0016ED8F
	private void CacheOverrideForDisplayMode()
	{
		if (UKismetSystemLibrary.GetCommandLine().Contains("-windowed"))
		{
			GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.DISPLAYMODE);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.CacheValue(1, EGameSettingsInitSourceType.InitOverride);
		}
	}

	// Token: 0x06005BFD RID: 23549 RVA: 0x00170BC0 File Offset: 0x0016EDC0
	private unsafe void CacheOverrideForCloudGame()
	{
		if (!Singleton<Platform>.Instance.IsCloudGame())
		{
			return;
		}
		DeviceRenderFeature? defaultDeviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDefaultDeviceRenderFeature();
		if (defaultDeviceRenderFeature == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GameSettings, ELogAuthor.WZ, "云游戏时不能获得渲染Feature预设值", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		else
		{
			this.AssignCacheValueByDeviceRenderFeature(defaultDeviceRenderFeature.Value, EGameSettingsInitSourceType.CloudOverride);
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Enable 1", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Quality -1", null);
		if (!Singleton<CloudGameManagerLauncher>.Instance.IsPreLaunch)
		{
			return;
		}
		if (Singleton<CloudGameManager>.Instance.ScreenWidth != 0)
		{
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			gameUserSettings.SetScreenResolution(new FIntPoint(Singleton<CloudGameManager>.Instance.ScreenWidth, Singleton<CloudGameManager>.Instance.ScreenHeight));
			gameUserSettings.ApplySettings(true);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "初始化游戏设置 - 云游戏预启动分辨率设置";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CloudGameManager.ScreenWidth", Singleton<CloudGameManager>.Instance.ScreenWidth);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CloudGameManager.ScreenHeight", Singleton<CloudGameManager>.Instance.ScreenHeight);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06005BFE RID: 23550 RVA: 0x00170CF4 File Offset: 0x0016EEF4
	public unsafe void ApplyCloudGameResolution()
	{
		if (!Singleton<CloudGameManagerLauncher>.Instance.IsPreLaunch)
		{
			return;
		}
		if (Singleton<CloudGameManager>.Instance.ScreenWidth != 0)
		{
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			gameUserSettings.SetScreenResolution(new FIntPoint(Singleton<CloudGameManager>.Instance.ScreenWidth, Singleton<CloudGameManager>.Instance.ScreenHeight));
			gameUserSettings.ApplySettings(true);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.TL;
		string message = "初始化游戏设置 - 云游戏预启动分辨率设置";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CloudGameManager.ScreenWidth", Singleton<CloudGameManager>.Instance.ScreenWidth);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CloudGameManager.ScreenHeight", Singleton<CloudGameManager>.Instance.ScreenHeight);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06005BFF RID: 23551 RVA: 0x00170DB8 File Offset: 0x0016EFB8
	private void CacheOverrideForDlssQuality()
	{
		MenuConfig? valueOrNull = this.ValidApplyConfigMap.GetValueOrNull(EFunction.NVIDIADLSSQUALITY);
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.NVIDIADLSSQUALITY);
		if (valueOrNull == null || valueOrDefault == null)
		{
			return;
		}
		int optionsDefault = valueOrNull.Value.OptionsDefault;
		if (!LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.HasRefreshNvidiaDlssQuality, false))
		{
			valueOrDefault.CacheValue(optionsDefault, EGameSettingsInitSourceType.InitOverride);
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.HasRefreshNvidiaDlssQuality, true);
		}
	}

	// Token: 0x06005C00 RID: 23552 RVA: 0x00170E2C File Offset: 0x0016F02C
	private void CacheOverrideForDlssFrameGenerate()
	{
		MenuConfig? valueOrNull = this.ValidApplyConfigMap.GetValueOrNull(EFunction.NVIDIADLSSFG);
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.NVIDIADLSSFG);
		if (valueOrNull == null || valueOrDefault == null)
		{
			return;
		}
		int optionsDefault = valueOrNull.Value.OptionsDefault;
		if (Singleton<GameSettingsDeviceRender>.Instance.IsDlss3HardwareSchedulingDisabled())
		{
			valueOrDefault.CacheValue(optionsDefault, EGameSettingsInitSourceType.InitOverride);
			return;
		}
		int? currentValue = this.GetCurrentValue(EFunction.NVIDIADLSS, false, true);
		int num = 0;
		if (currentValue.GetValueOrDefault() == num & currentValue != null)
		{
			valueOrDefault.CacheValue(0, EGameSettingsInitSourceType.InitOverride);
		}
	}

	// Token: 0x06005C01 RID: 23553 RVA: 0x00170EC0 File Offset: 0x0016F0C0
	private void CacheOverrideForRecommendImageQuality()
	{
		if (ModelBase<RecommendQualityModel>.Instance.IsNeedApply)
		{
			GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.IMAGEQUALITY);
			EGameQualitySettingLevel needApplyQuality = ModelBase<RecommendQualityModel>.Instance.NeedApplyQuality;
			if (valueOrDefault != null)
			{
				valueOrDefault.CacheValue((int)needApplyQuality, EGameSettingsInitSourceType.RecommendQualityOverride);
			}
			DeviceRenderFeature? deviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDeviceRenderFeature(needApplyQuality);
			if (deviceRenderFeature != null)
			{
				this.AssignCacheValueByDeviceRenderFeature(deviceRenderFeature.Value, EGameSettingsInitSourceType.RecommendQualityOverride);
			}
			ModelBase<RecommendQualityModel>.Instance.IsNeedApply = false;
		}
	}

	// Token: 0x06005C02 RID: 23554 RVA: 0x00170F34 File Offset: 0x0016F134
	public static void CacheOverrideForRecommendImageQualityRelated()
	{
		bool global = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.IsUsingQualityPreset, false);
		if (!global)
		{
			Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.TZJ, "[画质预设刷新] 本地保存了不使用画质预设", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int? global2 = LocalStorage.GetGlobal<int?>(ELocalStorageGlobalKey.ImageQuality, null);
		if (global2 == null)
		{
			return;
		}
		if (!global)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.TZJ, "[画质预设刷新] 应用推荐画质", default(ReadOnlySpan<ValueTuple<string, object>>));
		DeviceRenderFeature? deviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDeviceRenderFeature((EGameQualitySettingLevel)global2.Value);
		if (deviceRenderFeature == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.TZJ;
			string message = "[画质预设刷新] 推荐画质对应的渲染Feature不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cachedQuality", global2.Value);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<GameSettingsManager>.Instance.AssignCacheValueByDeviceRenderFeature(deviceRenderFeature.Value, EGameSettingsInitSourceType.InitOverride);
	}

	// Token: 0x06005C03 RID: 23555 RVA: 0x00171014 File Offset: 0x0016F214
	public static void SetIsUsingQualityPreset(bool isUsingQualityPreset)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameSettings;
		ELogAuthor author = ELogAuthor.TZJ;
		string message = "[画质预设刷新] 设置是否使用画质预设";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isUsingQualityPreset", isUsingQualityPreset);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.IsUsingQualityPreset, isUsingQualityPreset);
	}

	// Token: 0x06005C04 RID: 23556 RVA: 0x0017105C File Offset: 0x0016F25C
	private bool IsVulkanCanaryTestDevice()
	{
		return false;
	}

	// Token: 0x06005C05 RID: 23557 RVA: 0x0017106C File Offset: 0x0016F26C
	private void CacheOverrideForVulkan()
	{
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.Vulkan);
		if (valueOrDefault == null)
		{
			return;
		}
		int? currentValue = this.GetCurrentValue(EFunction.Vulkan, false, true);
		if (currentValue == null)
		{
			return;
		}
		valueOrDefault.CacheValue(currentValue.Value, EGameSettingsInitSourceType.InitOverride);
	}

	// Token: 0x06005C06 RID: 23558 RVA: 0x001710BC File Offset: 0x0016F2BC
	private void CacheOverrideForResetBrightness()
	{
		MenuConfig? valueOrNull = this.ValidApplyConfigMap.GetValueOrNull(EFunction.BRIGHTNESS);
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.BRIGHTNESS);
		if (valueOrNull == null || valueOrDefault == null)
		{
			return;
		}
		int optionsDefault = valueOrNull.Value.OptionsDefault;
		if (!LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.HasResetBrightness, false))
		{
			valueOrDefault.CacheValue(optionsDefault, EGameSettingsInitSourceType.InitOverride);
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.HasResetBrightness, true);
		}
	}

	// Token: 0x06005C07 RID: 23559 RVA: 0x00171128 File Offset: 0x0016F328
	private void CacheOverrideForNpcDensity()
	{
		if (UKuroStaticLibrary.IsLowMemoryDevice())
		{
			GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.NPCDENSITY);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.CacheValue(0, EGameSettingsInitSourceType.InitOverride);
		}
	}

	// Token: 0x06005C08 RID: 23560 RVA: 0x0017115C File Offset: 0x0016F35C
	private void CacheOverrideForHdr()
	{
		if (!UKuroGISystem.CheckWindowsSupportHDR())
		{
			GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.HDR);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.CacheValue(0, EGameSettingsInitSourceType.InitOverride);
		}
	}

	// Token: 0x06005C09 RID: 23561 RVA: 0x00171194 File Offset: 0x0016F394
	private void CacheOverrideForMotorRoundJoyStick()
	{
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.MotorIsDynamicJoystick);
		GameSettingsInitValueSource valueOrDefault2 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.MotorMobileButtonLayout);
		GameSettingsInitValueSource valueOrDefault3 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.JoystickMode);
		if (valueOrDefault == null || valueOrDefault2 == null || valueOrDefault3 == null)
		{
			return;
		}
		if (LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.MotorMobileButtonLayout, 0) == 1)
		{
			return;
		}
		int? global = LocalStorage.GetGlobal<int?>(ELocalStorageGlobalKey.JoystickMode, null);
		if (global == null)
		{
			return;
		}
		valueOrDefault.CacheValue(global.Value, EGameSettingsInitSourceType.InitOverride);
	}

	// Token: 0x06005C0A RID: 23562 RVA: 0x0017121C File Offset: 0x0016F41C
	private void CacheOverrideForMobileShadowQuality()
	{
		if (!Singleton<Info>.Instance.IsMobilePlatform())
		{
			return;
		}
		MenuConfig? valueOrNull = this.ValidApplyConfigMap.GetValueOrNull(EFunction.SHADOWQUALITY);
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.SHADOWQUALITY);
		if (valueOrNull == null || valueOrDefault == null)
		{
			return;
		}
		MenuConfig value = valueOrNull.Value;
		if (LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.HasResetMobileShadowQuality, false))
		{
			return;
		}
		int[] optionsValueArray = value.GetOptionsValueArray();
		bool flag = false;
		bool flag2 = false;
		if (optionsValueArray != null)
		{
			for (int i = 0; i < optionsValueArray.Length; i++)
			{
				if (optionsValueArray[i] == 2)
				{
					flag = true;
				}
				if (optionsValueArray[i] == 3)
				{
					flag2 = true;
				}
			}
		}
		if (!flag || !flag2)
		{
			Singleton<Log>.Instance.Error(ELogModule.GameSettings, ELogAuthor.TZJ, "移动端阴影质量重置逻辑不适用当前配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (LocalStorage.GetGlobal<int?>(ELocalStorageGlobalKey.ShadowQuality, null).GetValueOrDefault() == 3)
		{
			valueOrDefault.CacheValue(2, EGameSettingsInitSourceType.InitOverride);
		}
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.HasResetMobileShadowQuality, true);
	}

	// Token: 0x06005C0B RID: 23563 RVA: 0x0017130C File Offset: 0x0016F50C
	private void CacheInitDataFromRenderFeatureOverride()
	{
		if (Singleton<GameSettingsDeviceRender>.Instance.GetDefaultDeviceRenderFeature() == null)
		{
			return;
		}
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.RayTracing);
		if (valueOrDefault == null)
		{
			return;
		}
		valueOrDefault.CacheValue(0, EGameSettingsInitSourceType.RenderFeatureDefaultConfigOverride);
	}

	// Token: 0x06005C0C RID: 23564 RVA: 0x00171350 File Offset: 0x0016F550
	private void CacheInitDataFromLocalStorage()
	{
		foreach (KeyValuePair<EFunction, GameSettingsInitValueSource> keyValuePair in this.ValidInitValueSourceCache)
		{
			EFunction efunction;
			GameSettingsInitValueSource gameSettingsInitValueSource;
			keyValuePair.Deconstruct(out efunction, out gameSettingsInitValueSource);
			EFunction efunction2 = efunction;
			GameSettingsInitValueSource gameSettingsInitValueSource2 = gameSettingsInitValueSource;
			object getCallbackOrGlobalKey = GameSettingsDefine.function2GameSettings.GetValueOrDefault(efunction2).GetCallbackOrGlobalKey;
			if (getCallbackOrGlobalKey is ELocalStorageGlobalKey)
			{
				if (GameSettingsManager.IsFloatSetting(efunction2))
				{
					float? global = LocalStorage.GetGlobal<float?>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, null);
					if (global != null)
					{
						gameSettingsInitValueSource2.CacheValue(global.Value, EGameSettingsInitSourceType.LocalStorage);
					}
				}
				else
				{
					int? global2 = LocalStorage.GetGlobal<int?>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, null);
					if (global2 != null)
					{
						bool flag = true;
						MenuConfig? valueOrNull = this.ValidApplyConfigMap.GetValueOrNull(efunction2);
						if (valueOrNull != null && valueOrNull.Value.SetType == 2)
						{
							flag = false;
							int[] optionsValueArray = valueOrNull.Value.GetOptionsValueArray();
							if (optionsValueArray != null)
							{
								foreach (int num in optionsValueArray)
								{
									int? num2 = global2;
									if (num == num2.GetValueOrDefault() & num2 != null)
									{
										flag = true;
										break;
									}
								}
							}
						}
						if (flag)
						{
							gameSettingsInitValueSource2.CacheValue(global2.Value, EGameSettingsInitSourceType.LocalStorage);
						}
					}
				}
			}
		}
	}

	// Token: 0x06005C0D RID: 23565 RVA: 0x001714D8 File Offset: 0x0016F6D8
	public void RefreshLoginOverrideCache()
	{
		foreach (KeyValuePair<EFunction, GameSettingsInitValueSource> keyValuePair in this.ValidInitValueSourceCache)
		{
			EFunction key = keyValuePair.Key;
			GameSettingsInitValueSource value = keyValuePair.Value;
			object getCallbackOrGlobalKey = GameSettingsDefine.function2GameSettings.GetValueOrDefault(key).GetCallbackOrGlobalKey;
			if (getCallbackOrGlobalKey is ELocalStorageGlobalKey)
			{
				if (GameSettingsManager.IsFloatSetting(key))
				{
					float? global = LocalStorage.GetGlobal<float?>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, null);
					if (global != null)
					{
						value.RefreshCacheValue(global.Value, EGameSettingsInitSourceType.LoginOverride);
					}
				}
				else
				{
					int? global2 = LocalStorage.GetGlobal<int?>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, null);
					if (global2 != null)
					{
						bool flag = true;
						MenuConfig? valueOrNull = this.ValidApplyConfigMap.GetValueOrNull(key);
						if (valueOrNull != null && valueOrNull.Value.SetType == 2)
						{
							flag = false;
							int[] optionsValueArray = valueOrNull.Value.GetOptionsValueArray();
							if (optionsValueArray != null)
							{
								foreach (int num in optionsValueArray)
								{
									int? num2 = global2;
									if (num == num2.GetValueOrDefault() & num2 != null)
									{
										flag = true;
										break;
									}
								}
							}
						}
						if (flag)
						{
							value.RefreshCacheValue(global2.Value, EGameSettingsInitSourceType.LoginOverride);
						}
					}
				}
			}
		}
		Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.TZJ, "已刷新LoginOverride", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06005C0E RID: 23566 RVA: 0x00171680 File Offset: 0x0016F880
	public void OverrideLoginCacheValue(EFunction id, int value)
	{
		GameSettingsInitValueSource gameSettingsInitValueSource;
		if (!this.ValidInitValueSourceCache.TryGetValue(id, out gameSettingsInitValueSource))
		{
			return;
		}
		gameSettingsInitValueSource.RefreshCacheValue(value, EGameSettingsInitSourceType.LoginOverride);
	}

	// Token: 0x06005C0F RID: 23567 RVA: 0x001716AC File Offset: 0x0016F8AC
	public static bool HasImageQualityOrSubSettingLoginOverride()
	{
		GameSettingsInitValueSource valueOrDefault = Singleton<GameSettingsManager>.Instance.ValidInitValueSourceCache.GetValueOrDefault(EFunction.IMAGEQUALITY);
		if (valueOrDefault != null && valueOrDefault.HasCachedSource(EGameSettingsInitSourceType.LoginOverride))
		{
			return true;
		}
		EGameQualitySettingLevel? recommendQualityLv = Singleton<GameSettingsDeviceRender>.Instance.GetRecommendQualityLv();
		if (recommendQualityLv == null)
		{
			return false;
		}
		DeviceRenderFeature? deviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDeviceRenderFeature(recommendQualityLv.Value);
		if (deviceRenderFeature == null)
		{
			return false;
		}
		foreach (KeyValuePair<EFunction, int> keyValuePair in Singleton<GameSettingsDeviceRender>.Instance.GetOtherChangedValue(deviceRenderFeature.Value))
		{
			EFunction efunction;
			int num;
			keyValuePair.Deconstruct(out efunction, out num);
			EFunction key = efunction;
			GameSettingsInitValueSource valueOrDefault2 = Singleton<GameSettingsManager>.Instance.ValidInitValueSourceCache.GetValueOrDefault(key);
			if (valueOrDefault2 != null && valueOrDefault2.HasCachedSource(EGameSettingsInitSourceType.LoginOverride))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06005C10 RID: 23568 RVA: 0x00171790 File Offset: 0x0016F990
	private void CacheInitDataFrom1Dot3()
	{
		int? global = LocalStorage.GetGlobal<int?>(ELocalStorageGlobalKey.TextLanguage, null);
		if (global != null)
		{
			GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.TEXTLANGUAGE);
			if (valueOrDefault != null)
			{
				valueOrDefault.CacheValue(global.Value, EGameSettingsInitSourceType.From1Dot3);
			}
		}
		global = LocalStorage.GetGlobal<int?>(ELocalStorageGlobalKey.VoiceLanguage, null);
		if (global != null)
		{
			GameSettingsInitValueSource valueOrDefault2 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.VOICELANGUAGE);
			if (valueOrDefault2 == null)
			{
				return;
			}
			valueOrDefault2.CacheValue(global.Value, EGameSettingsInitSourceType.From1Dot3);
		}
	}

	// Token: 0x06005C11 RID: 23569 RVA: 0x0017181C File Offset: 0x0016FA1C
	private void CacheInitDataFrom1Dot2()
	{
		Dictionary<int, double> dictionary = Singleton<LauncherGameSettingLib>.Instance.LoadPlayMenuInfo();
		if (dictionary == null)
		{
			return;
		}
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.MASTERVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot2);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.VOICEVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot2);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.MUSICVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot2);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.SFXVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot2);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.AMBVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot2);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.UIVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot2);
		int? currentValue = this.GetCurrentValue(EFunction.HIGHESTFPS, true, true);
		if (currentValue != null)
		{
			int? num = currentValue;
			int num2 = 10;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.HIGHESTFPS);
				if (valueOrDefault == null)
				{
					return;
				}
				valueOrDefault.CacheValue(Singleton<GameSettingsDeviceRender>.Instance.GetFrameIndexByList(currentValue.Value), EGameSettingsInitSourceType.From1Dot2);
			}
		}
	}

	// Token: 0x06005C12 RID: 23570 RVA: 0x001718CC File Offset: 0x0016FACC
	private void CacheInitDataFrom1Dot1()
	{
		Dictionary<EFunction, int?> dictionary = new Dictionary<EFunction, int?>();
		GameQualityData global = LocalStorage.GetGlobal<GameQualityData>(ELocalStorageGlobalKey.GameQualitySetting, null);
		if (global != null)
		{
			dictionary[EFunction.IMAGEQUALITY] = global.KeyQualityLevel;
			dictionary[EFunction.DISPLAYMODE] = global.KeyPcWindowMode;
			dictionary[EFunction.BRIGHTNESS] = global.KeyBrightness;
			dictionary[EFunction.FSR] = global.KeyFsrEnable;
			dictionary[EFunction.XESS] = new int?(global.KeyXessEnable.GetValueOrDefault(1));
			dictionary[EFunction.XESS_QUALITY] = new int?(global.KeyXessQuality.GetValueOrDefault(2));
			dictionary[EFunction.METALFX] = global.KeyMetalFxEnable;
			dictionary[EFunction.IRX] = new int?(global.KeyIrxEnable.GetValueOrDefault(1));
			dictionary[EFunction.HorizontalViewSensitivity] = global.HorizontalViewSensitivity;
			dictionary[EFunction.VerticalViewSensitivity] = global.VerticalViewSensitivity;
			dictionary[EFunction.AimHorizontalViewSensitivity] = global.AimHorizontalViewSensitivity;
			dictionary[EFunction.AimVerticalViewSensitivity] = global.AimVerticalViewSensitivity;
			dictionary[EFunction.MobileHorizontalViewSensitivity] = global.MobileHorizontalViewSensitivity;
			dictionary[EFunction.MobileVerticalViewSensitivity] = global.MobileVerticalViewSensitivity;
			dictionary[EFunction.MobileAimHorizontalViewSensitivity] = global.MobileAimHorizontalViewSensitivity;
			dictionary[EFunction.MobileAimVerticalViewSensitivity] = global.MobileAimVerticalViewSensitivity;
			dictionary[EFunction.CommonSpringArmLength] = global.CommonSpringArmLength;
			dictionary[EFunction.FightSpringArmLength] = global.FightSpringArmLength;
			dictionary[EFunction.ResetFocusEnable] = global.IsResetFocusEnable;
			dictionary[EFunction.IsSidestepCameraEnable] = global.IsSidestepCameraEnable;
			dictionary[EFunction.IsSoftLockCameraEnable] = global.IsSoftLockCameraEnable;
			dictionary[EFunction.JoystickShakeStrength] = global.JoystickShakeStrength;
			dictionary[EFunction.JoystickShakeType] = global.JoystickShakeType;
			dictionary[EFunction.JoystickMode] = global.JoystickMode;
			dictionary[EFunction.SkillButtonMode] = global.IsAutoSwitchSkillButtonMode;
			dictionary[EFunction.AimAssist] = global.AimAssistEnable;
			dictionary[EFunction.HorizontalViewRevert] = global.HorizontalViewRevert;
			dictionary[EFunction.VerticalViewRevert] = global.VerticalViewRevert;
			if (global.WalkOrRunRate != null)
			{
				GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.WalkOrRunRate);
				if (valueOrDefault != null)
				{
					valueOrDefault.CacheValue(global.WalkOrRunRate.Value, EGameSettingsInitSourceType.From1Dot1);
				}
			}
			dictionary[EFunction.CameraShakeStrength] = new int?(LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.CameraShakeStrength, 0));
		}
		Dictionary<EFunction, int> global2 = LocalStorage.GetGlobal<Dictionary<EFunction, int>>(ELocalStorageGlobalKey.MenuData, null);
		if (global2 != null)
		{
			dictionary[EFunction.CameraShakeStrength] = global2.GetValueOrNull(EFunction.CameraShakeStrength);
			dictionary[EFunction.MASTERVOLUMEFUNCTION] = global2.GetValueOrNull(EFunction.MASTERVOLUMEFUNCTION);
			dictionary[EFunction.VOICEVOLUMEFUNCTION] = global2.GetValueOrNull(EFunction.VOICEVOLUMEFUNCTION);
			dictionary[EFunction.MUSICVOLUMEFUNCTION] = global2.GetValueOrNull(EFunction.MUSICVOLUMEFUNCTION);
			dictionary[EFunction.SFXVOLUMEFUNCTION] = global2.GetValueOrNull(EFunction.SFXVOLUMEFUNCTION);
			dictionary[EFunction.AMBVOLUMEFUNCTION] = global2.GetValueOrNull(EFunction.AMBVOLUMEFUNCTION);
			dictionary[EFunction.UIVOLUMEFUNCTION] = global2.GetValueOrNull(EFunction.UIVOLUMEFUNCTION);
			dictionary[EFunction.RESOLUTION] = global2.GetValueOrNull(EFunction.RESOLUTION);
			dictionary[EFunction.TEXTLANGUAGE] = global2.GetValueOrNull(EFunction.TEXTLANGUAGE);
			dictionary[EFunction.VOICELANGUAGE] = global2.GetValueOrNull(EFunction.VOICELANGUAGE);
			dictionary[EFunction.ADVICESETTING] = global2.GetValueOrNull(EFunction.ADVICESETTING);
			dictionary[EFunction.GENDERSETTING] = global2.GetValueOrNull(EFunction.GENDERSETTING);
		}
		foreach (KeyValuePair<EFunction, int?> keyValuePair in dictionary)
		{
			EFunction efunction;
			int? num;
			keyValuePair.Deconstruct(out efunction, out num);
			EFunction key = efunction;
			int? num2 = num;
			if (num2 != null)
			{
				GameSettingsInitValueSource valueOrDefault2 = this.ValidInitValueSourceCache.GetValueOrDefault(key);
				if (valueOrDefault2 != null)
				{
					valueOrDefault2.CacheValue(num2.Value, EGameSettingsInitSourceType.From1Dot1);
				}
			}
		}
	}

	// Token: 0x06005C13 RID: 23571 RVA: 0x00171C2C File Offset: 0x0016FE2C
	private void CacheInitDataFrom1Dot0()
	{
		Dictionary<int, double> dictionary = Singleton<LauncherGameSettingLib>.Instance.LoadPlayMenuInfo();
		if (dictionary == null)
		{
			return;
		}
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.CameraShakeStrength, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.MASTERVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.VOICEVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.MUSICVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.SFXVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.AMBVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.UIVOLUMEFUNCTION, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.RESOLUTION, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.TEXTLANGUAGE, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.VOICELANGUAGE, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.ADVICESETTING, EGameSettingsInitSourceType.From1Dot0);
		this.AssignCacheValueByPlayerMenuInfo(dictionary, EFunction.GENDERSETTING, EGameSettingsInitSourceType.From1Dot0);
	}

	// Token: 0x06005C14 RID: 23572 RVA: 0x00171CBC File Offset: 0x0016FEBC
	private void CacheInitDataFromRenderFeatureDefault()
	{
		DeviceRenderFeature? defaultDeviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetDefaultDeviceRenderFeature();
		if (defaultDeviceRenderFeature == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "当前机型没有设置默认画质";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("当前机型", Singleton<GameSettingsDeviceRender>.Instance.DeviceType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AssignCacheValueByDeviceRenderFeature(defaultDeviceRenderFeature.Value, EGameSettingsInitSourceType.RenderFeatureDefaultConfig);
	}

	// Token: 0x06005C15 RID: 23573 RVA: 0x00171D28 File Offset: 0x0016FF28
	private void CacheInitDataFromCustomOverrideDefault()
	{
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.KeyboardLockEnemyMode);
		if (valueOrDefault != null)
		{
			valueOrDefault.CacheValue(1, EGameSettingsInitSourceType.CustomOverrideDefault);
		}
		GameSettingsInitValueSource valueOrDefault2 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.GamepadLockEnemyMode);
		if (valueOrDefault2 != null)
		{
			valueOrDefault2.CacheValue(1, EGameSettingsInitSourceType.CustomOverrideDefault);
		}
		int num = 0;
		MenuConfig? valueOrNull = this.ValidApplyConfigMap.GetValueOrNull(EFunction.VegetationDither);
		if (valueOrNull != null)
		{
			num = valueOrNull.Value.OptionsDefault;
		}
		GameSettingsInitValueSource valueOrDefault3 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.VegetationDither);
		if (valueOrDefault3 == null)
		{
			return;
		}
		valueOrDefault3.CacheValue(Singleton<GameSettingsDeviceRender>.Instance.ShouldOverrideVegetationDitherDefaultValue() ? 0 : num, EGameSettingsInitSourceType.CustomOverrideDefault);
	}

	// Token: 0x06005C16 RID: 23574 RVA: 0x00171DD8 File Offset: 0x0016FFD8
	private void CacheInitDataFromUserSettingIni()
	{
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		int value = (gameUserSettings == null) ? 2 : Singleton<GameSettingsDeviceRender>.Instance.GetResolutionIndexByList(gameUserSettings.GetScreenResolution());
		GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.RESOLUTION);
		if (valueOrDefault != null)
		{
			valueOrDefault.CacheValue(value, EGameSettingsInitSourceType.UserSettingIni);
		}
		TEnumAsByte<EWindowMode>? tenumAsByte = (gameUserSettings != null) ? new TEnumAsByte<EWindowMode>?(gameUserSettings.GetFullscreenMode()) : null;
		if (tenumAsByte != null)
		{
			switch (tenumAsByte.Value)
			{
			case EWindowMode.Fullscreen:
			{
				GameSettingsInitValueSource valueOrDefault2 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.DISPLAYMODE);
				if (valueOrDefault2 != null)
				{
					valueOrDefault2.CacheValue(0, EGameSettingsInitSourceType.UserSettingIni);
				}
				break;
			}
			case EWindowMode.WindowedFullscreen:
			{
				GameSettingsInitValueSource valueOrDefault3 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.DISPLAYMODE);
				if (valueOrDefault3 != null)
				{
					valueOrDefault3.CacheValue(0, EGameSettingsInitSourceType.UserSettingIni);
				}
				break;
			}
			case EWindowMode.Windowed:
			{
				GameSettingsInitValueSource valueOrDefault4 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.DISPLAYMODE);
				if (valueOrDefault4 != null)
				{
					valueOrDefault4.CacheValue(1, EGameSettingsInitSourceType.UserSettingIni);
				}
				break;
			}
			}
		}
		Singleton<LanguageSystem>.Instance.FirstTimeSetLanguage(GlobalData.World);
		int languageIdByCode = this.GetLanguageIdByCode(Singleton<LanguageSystem>.Instance.PackageLanguage);
		ESpeechType speechTypeByLanguageType = this.GetSpeechTypeByLanguageType(languageIdByCode);
		GameSettingsInitValueSource valueOrDefault5 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.TEXTLANGUAGE);
		if (valueOrDefault5 != null)
		{
			valueOrDefault5.CacheValue(languageIdByCode, EGameSettingsInitSourceType.UserSettingIni);
		}
		GameSettingsInitValueSource valueOrDefault6 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.VOICELANGUAGE);
		if (valueOrDefault6 != null)
		{
			valueOrDefault6.CacheValue((int)speechTypeByLanguageType, EGameSettingsInitSourceType.UserSettingIni);
		}
		int consoleVariableIntValue = UKismetSystemLibrary.GetConsoleVariableIntValue("r.Android.VulkanSetting");
		GameSettingsInitValueSource valueOrDefault7 = this.ValidInitValueSourceCache.GetValueOrDefault(EFunction.Vulkan);
		if (valueOrDefault7 == null)
		{
			return;
		}
		valueOrDefault7.CacheValue((((consoleVariableIntValue >= 0) ? consoleVariableIntValue : UKismetSystemLibrary.GetConsoleVariableIntValue("r.Android.DefaultVulkanSetting")) > 0) ? 1 : 0, EGameSettingsInitSourceType.UserSettingIni);
	}

	// Token: 0x06005C17 RID: 23575 RVA: 0x00171F80 File Offset: 0x00170180
	private void CacheInitDataFromConfigDefault()
	{
		foreach (KeyValuePair<EFunction, MenuConfig> keyValuePair in this.ValidApplyConfigMap)
		{
			EFunction efunction;
			MenuConfig menuConfig;
			keyValuePair.Deconstruct(out efunction, out menuConfig);
			EFunction key = efunction;
			MenuConfig menuConfig2 = menuConfig;
			OneOf<int, float, double>? oneOf = null;
			switch (menuConfig2.SetType)
			{
			case 1:
				oneOf = new OneOf<int, float, double>?(menuConfig2.SliderDefault);
				break;
			case 2:
				oneOf = new OneOf<int, float, double>?(menuConfig2.OptionsDefault);
				break;
			case 4:
				oneOf = new OneOf<int, float, double>?(menuConfig2.OptionsDefault);
				break;
			case 5:
				oneOf = new OneOf<int, float, double>?(menuConfig2.OptionsDefault);
				break;
			}
			if (oneOf != null)
			{
				GameSettingsInitValueSource valueOrDefault = this.ValidInitValueSourceCache.GetValueOrDefault(key);
				if (valueOrDefault != null)
				{
					valueOrDefault.CacheValue(oneOf.Value, EGameSettingsInitSourceType.GameSettingDefaultConfig);
				}
			}
		}
	}

	// Token: 0x06005C18 RID: 23576 RVA: 0x00172090 File Offset: 0x00170290
	private int GetLanguageIdByCode(string code)
	{
		global::LanguageDefine languageDefineByCode = Singleton<LanguageSystem>.Instance.GetLanguageDefineByCode(code);
		if (languageDefineByCode == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Menu;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "LanguageSystem 未定义此语种";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("非法值", code);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return this.GetLanguageIdByCode("en");
		}
		return languageDefineByCode.LanguageType;
	}

	// Token: 0x06005C19 RID: 23577 RVA: 0x001720E5 File Offset: 0x001702E5
	private ESpeechType GetSpeechTypeByLanguageType(int languageType)
	{
		return Singleton<LanguageSystem>.Instance.GetSpeechTypeByLanguageType((ELanguageType)languageType);
	}

	// Token: 0x06005C1A RID: 23578 RVA: 0x001720F2 File Offset: 0x001702F2
	public bool IsValid(EFunction id, bool allowRebuild = true)
	{
		return (allowRebuild || this.ValidApplyConfigMapInternal != null) && this.ValidApplyConfigMap.ContainsKey(id);
	}

	// Token: 0x06005C1B RID: 23579 RVA: 0x00172110 File Offset: 0x00170310
	public void Initialize()
	{
		this.ValidInitValueSourceCache.Clear();
		foreach (KeyValuePair<EFunction, MenuConfig> keyValuePair in this.ValidApplyConfigMap)
		{
			EFunction efunction;
			MenuConfig menuConfig;
			keyValuePair.Deconstruct(out efunction, out menuConfig);
			EFunction efunction2 = efunction;
			MenuConfig menuCfg = menuConfig;
			if (!this.IsButtonSetting(menuCfg))
			{
				this.ValidInitValueSourceCache[efunction2] = new GameSettingsInitValueSource(efunction2);
			}
		}
		this.CacheInitDataFromOverride();
		this.CacheInitDataFromLocalStorage();
		this.CacheInitDataFrom1Dot3();
		this.CacheInitDataFrom1Dot2();
		this.CacheInitDataFrom1Dot1();
		this.CacheInitDataFrom1Dot0();
		this.CacheInitDataFromRenderFeatureOverride();
		this.CacheInitDataFromRenderFeatureDefault();
		this.CacheInitDataFromCustomOverrideDefault();
		this.CacheInitDataFromUserSettingIni();
		this.CacheInitDataFromConfigDefault();
		if (this.IsValid(EFunction.DISPLAYMODE, true) && this.IsValid(EFunction.RESOLUTION, true))
		{
			OneOf<int, float, double>? initValue = this.GetInitValue(EFunction.DISPLAYMODE, false);
			if (initValue != null)
			{
				this.ApplyValue(EFunction.DISPLAYMODE, (T1)initValue.Value, EGameSettingsApplyReason.WhenGameStart);
			}
			OneOf<int, float, double>? initValue2 = this.GetInitValue(EFunction.RESOLUTION, true);
			if (initValue2 != null && initValue != null && (T1)initValue.Value == 1)
			{
				this.ApplyValue(EFunction.RESOLUTION, (T1)initValue2.Value, EGameSettingsApplyReason.WhenGameStart);
			}
		}
		OneOf<int, float, double>? initValue3 = this.GetInitValue(EFunction.TEXTLANGUAGE, true);
		if (this.IsValid(EFunction.TEXTLANGUAGE, true) && initValue3 != null)
		{
			this.ApplyValue(EFunction.TEXTLANGUAGE, (T1)initValue3.Value, EGameSettingsApplyReason.WhenGameStart);
		}
		OneOf<int, float, double>? initValue4 = this.GetInitValue(EFunction.VOICELANGUAGE, true);
		if (this.IsValid(EFunction.VOICELANGUAGE, true) && initValue4 != null)
		{
			this.ApplyValue(EFunction.VOICELANGUAGE, (T1)initValue4.Value, EGameSettingsApplyReason.WhenGameStart);
		}
		if (this.IsValid(EFunction.Vulkan, true) && !LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.VulkanChangeFlag, false) && this.IsVulkanCanaryTestDevice())
		{
			Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WZ, "通过灰度测试的设备，强制开启Vulkan", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ForceSaveValue(EFunction.Vulkan, 1);
			this.ForceApplyValue(EFunction.Vulkan, 1, EGameSettingsApplyReason.WhenGameStart);
		}
		if (Singleton<Info>.Instance.IsPcPlatform() && !Singleton<GameSettingsDeviceRender>.Instance.IsShowRayTracingSetting())
		{
			Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.WZ, "不满足光追条件，强制关闭光追", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ForceSaveValue(EFunction.RayTracing, 0);
			this.ForceSaveValue(EFunction.RayTracedReflection, 0);
			this.ForceSaveValue(EFunction.RayTracedGI, 0);
			this.ForceSaveValue(EFunction.RayTracedShadow, 0);
			this.ForceApplyValue(EFunction.RayTracing, 0, EGameSettingsApplyReason.WhenGameStart);
			this.ForceApplyValue(EFunction.RayTracedReflection, 0, EGameSettingsApplyReason.WhenGameStart);
			this.ForceApplyValue(EFunction.RayTracedGI, 0, EGameSettingsApplyReason.WhenGameStart);
			this.ForceApplyValue(EFunction.RayTracedShadow, 0, EGameSettingsApplyReason.WhenGameStart);
		}
	}

	// Token: 0x06005C1C RID: 23580 RVA: 0x001723C4 File Offset: 0x001705C4
	public void HandleInitDataOnOpenLoading()
	{
		this.CacheOverrideForRecommendImageQuality();
		this.CacheOverrideForVulkan();
		foreach (KeyValuePair<EFunction, GameSettingsInitValueSource> keyValuePair in this.ValidInitValueSourceCache)
		{
			EFunction efunction;
			GameSettingsInitValueSource gameSettingsInitValueSource;
			keyValuePair.Deconstruct(out efunction, out gameSettingsInitValueSource);
			EFunction id = efunction;
			OneOf<int, float, double>? initValue = this.GetInitValue(id, true);
			if (initValue != null)
			{
				if (GameSettingsManager.IsFloatSetting(id))
				{
					this.SaveValueFloat(id, GameSettingsManager.OneOfToFloat(initValue.Value));
				}
				else
				{
					this.SaveValue(id, GameSettingsManager.OneOfToInt(initValue.Value));
				}
			}
		}
		foreach (KeyValuePair<EFunction, GameSettingsInitValueSource> keyValuePair in this.ValidInitValueSourceCache)
		{
			EFunction efunction;
			GameSettingsInitValueSource gameSettingsInitValueSource;
			keyValuePair.Deconstruct(out efunction, out gameSettingsInitValueSource);
			EFunction id2 = efunction;
			OneOf<int, float, double>? initValue2 = this.GetInitValue(id2, true);
			if (initValue2 != null)
			{
				if (GameSettingsManager.IsFloatSetting(id2))
				{
					this.HandleValueChangeFloat(id2, GameSettingsManager.OneOfToFloat(initValue2.Value), EGameSettingsApplyReason.WhenLoading);
				}
				else
				{
					this.HandleValueChange(id2, GameSettingsManager.OneOfToInt(initValue2.Value), EGameSettingsApplyReason.WhenLoading);
				}
			}
		}
	}

	// Token: 0x06005C1D RID: 23581 RVA: 0x00172500 File Offset: 0x00170700
	[NullableContext(0)]
	private static int OneOfToInt(OneOf<int, float, double> value)
	{
		if (value.IsT1)
		{
			return value.AsT1;
		}
		if (value.IsT2)
		{
			return (int)value.AsT2;
		}
		if (value.IsT3)
		{
			return (int)value.AsT3;
		}
		return 0;
	}

	// Token: 0x06005C1E RID: 23582 RVA: 0x00172538 File Offset: 0x00170738
	[NullableContext(0)]
	private static float OneOfToFloat(OneOf<int, float, double> value)
	{
		if (value.IsT1)
		{
			return (float)value.AsT1;
		}
		if (value.IsT2)
		{
			return value.AsT2;
		}
		if (value.IsT3)
		{
			return (float)value.AsT3;
		}
		return 0f;
	}

	// Token: 0x06005C1F RID: 23583 RVA: 0x00172574 File Offset: 0x00170774
	private static bool IsFloatSetting(EFunction id)
	{
		IGameSettings valueOrDefault = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id);
		return ((valueOrDefault != null) ? valueOrDefault.ApplyCallbackFloat : null) != null;
	}

	// Token: 0x06005C20 RID: 23584 RVA: 0x00172590 File Offset: 0x00170790
	public void Clear()
	{
		this.ValidApplyConfigMapInternal = null;
	}

	// Token: 0x06005C21 RID: 23585 RVA: 0x0017259C File Offset: 0x0017079C
	public int? GetCurrentValue(EFunction id, bool isLog = true, bool allowRebuild = true)
	{
		if (!this.IsValid(id, allowRebuild))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "在【GetCurrent】一个不符合条件的值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		IGameSettings valueOrDefault = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id);
		if (valueOrDefault == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "【GetCurrent】当前选项未能获取IGameSettings句柄";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("functionId", id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		object getCallbackOrGlobalKey = valueOrDefault.GetCallbackOrGlobalKey;
		Func<int> func = getCallbackOrGlobalKey as Func<int>;
		if (func != null)
		{
			return new int?(func());
		}
		int? global = LocalStorage.GetGlobal<int?>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, null);
		if (global == null)
		{
			if (isLog)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.GameSettings;
				ELogAuthor author3 = ELogAuthor.WZ;
				string message3 = "【GetCurrent】当前选项未被保存在LocalStorage中";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("functionId", id);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
			return null;
		}
		return new int?(global.Value);
	}

	// Token: 0x06005C22 RID: 23586 RVA: 0x001726BC File Offset: 0x001708BC
	public unsafe int GetCurrentValueSafely(EFunction id, int defaultValue = 0, bool allowRebuild = true)
	{
		int? num = this.GetCurrentValue(id, false, allowRebuild);
		if (num != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "【GetCurrentValueSafely】使用【Current】";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return num.Value;
		}
		OneOf<int, float, double>? initValue = this.GetInitValue(id, false);
		int? num2;
		if (initValue == null)
		{
			num2 = null;
		}
		else
		{
			num2 = new int?(initValue.GetValueOrDefault().Match<int>((int i) => i, (float f) => (int)f, (double d) => (int)d));
		}
		num = num2;
		if (num != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "【GetCurrentValueSafely】使用【Init】";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("functionId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("value", num);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return num.Value;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.GameSettings;
		ELogAuthor author3 = ELogAuthor.WZ;
		string message3 = "【GetCurrentValueSafely】当前选项不能正确获取数据来源, 使用【缺省值】";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("functionId", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("defaultValue", defaultValue);
		instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
		return defaultValue;
	}

	// Token: 0x06005C23 RID: 23587 RVA: 0x001728A8 File Offset: 0x00170AA8
	[NullableContext(0)]
	public OneOf<int, float, double>? GetInitValue(EFunction id, bool isLog = true)
	{
		GameSettingsInitValueSource gameSettingsInitValueSource;
		if (!this.ValidInitValueSourceCache.TryGetValue(id, out gameSettingsInitValueSource))
		{
			if (isLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GameSettings;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "【GetInitValue】当前选项不能正确获取数据来源";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return null;
		}
		return gameSettingsInitValueSource.ValidInitValue;
	}

	// Token: 0x06005C24 RID: 23588 RVA: 0x00172908 File Offset: 0x00170B08
	private bool ApplyValue(EFunction id, int value, EGameSettingsApplyReason reason)
	{
		if (!this.IsValid(id, true))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "在【应用】一个不符合条件的值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Func<int, EGameSettingsApplyReason, bool> applyCallback = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).ApplyCallback;
		if (applyCallback == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "[ApplyValue]该设置项不必应用";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("functionId", id);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return true;
		}
		return applyCallback(value, reason);
	}

	// Token: 0x06005C25 RID: 23589 RVA: 0x001729A0 File Offset: 0x00170BA0
	private bool ForceApplyValue(EFunction id, int value, EGameSettingsApplyReason reason)
	{
		Func<int, EGameSettingsApplyReason, bool> applyCallback = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).ApplyCallback;
		if (applyCallback == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "[ForceApplyValue]该设置项不必应用";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}
		return applyCallback(value, reason);
	}

	// Token: 0x06005C26 RID: 23590 RVA: 0x001729FC File Offset: 0x00170BFC
	private unsafe bool SaveValue(EFunction id, int value)
	{
		if (!this.IsValid(id, true))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "在【Save】一个不符合条件的值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		object getCallbackOrGlobalKey = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).GetCallbackOrGlobalKey;
		if (getCallbackOrGlobalKey is Func<int>)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "getter不必【Save】LocalStorage";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("functionId", id);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		LocalStorage.SetGlobal<int>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, value);
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.GameSettings;
		ELogAuthor author3 = ELogAuthor.WZ;
		string message3 = "设置项【Save】成功";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return true;
	}

	// Token: 0x06005C27 RID: 23591 RVA: 0x00172AFC File Offset: 0x00170CFC
	public unsafe bool ForceSaveValue(EFunction id, int value)
	{
		object getCallbackOrGlobalKey = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).GetCallbackOrGlobalKey;
		if (getCallbackOrGlobalKey is Func<int>)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "getter不必【Force Save】LocalStorage";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		LocalStorage.SetGlobal<int>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, value);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.GameSettings;
		ELogAuthor author2 = ELogAuthor.WZ;
		string message2 = "设置项【Force Save】成功";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return true;
	}

	// Token: 0x06005C28 RID: 23592 RVA: 0x00172BC4 File Offset: 0x00170DC4
	private unsafe void EnsureLanguagePairSaved(EFunction id)
	{
		EFunction efunction = EFunction.TEXTLANGUAGE;
		if (id == EFunction.TEXTLANGUAGE)
		{
			efunction = EFunction.VOICELANGUAGE;
		}
		else if (id != EFunction.VOICELANGUAGE)
		{
			return;
		}
		if (!this.IsValid(efunction, true))
		{
			return;
		}
		if (this.GetCurrentValue(efunction, false, true) != null)
		{
			return;
		}
		OneOf<int, float, double>? initValue = this.GetInitValue(efunction, false);
		if (initValue == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.TZJ;
			string message = "登录界面态：配对语言项无法取得初始值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pairedFunctionId", efunction);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int num = GameSettingsManager.OneOfToInt(initValue.Value);
		this.SaveValue(efunction, num);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.GameSettings;
		ELogAuthor author2 = ELogAuthor.TZJ;
		string message2 = "登录界面态：补齐配对语言项落盘";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("pairedFunctionId", efunction);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("pairedValue", num);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06005C29 RID: 23593 RVA: 0x00172CDC File Offset: 0x00170EDC
	public unsafe void HandleValueChange(EFunction id, int value, EGameSettingsApplyReason reason)
	{
		bool flag = reason == EGameSettingsApplyReason.WhenUi && !this.IsGameSettingsAppliedOnOpenLoading;
		if (flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.TZJ;
			string message = "【HandleValueChange】登录界面态：覆盖 InitValueSourceCache";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.OverrideLoginCacheValue(id, value);
		}
		if (this.ApplyValue(id, value, reason))
		{
			this.SaveValue(id, value);
			if (flag)
			{
				this.EnsureLanguagePairSaved(id);
			}
			Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, id);
			Action<int, EGameSettingsApplyReason> handleDoneCallback = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).HandleDoneCallback;
			if (handleDoneCallback != null)
			{
				handleDoneCallback(value, reason);
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "设置项【Handle】成功";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("functionId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("value", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("reason", reason);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.GameSettings;
		ELogAuthor author3 = ELogAuthor.WZ;
		string message3 = "【HandleValueChange】设置项应用失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
		instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06005C2A RID: 23594 RVA: 0x00172E64 File Offset: 0x00171064
	public float? GetCurrentValueFloat(EFunction id, bool isLog = true)
	{
		if (!this.IsValid(id, true))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "在【GetCurrent】一个不符合条件的值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		IGameSettings valueOrDefault = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id);
		if (valueOrDefault == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "【GetCurrent】当前选项未能获取IGameSettings句柄";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("functionId", id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		object getCallbackOrGlobalKey = valueOrDefault.GetCallbackOrGlobalKey;
		Func<int> func = getCallbackOrGlobalKey as Func<int>;
		if (func != null)
		{
			return new float?((float)func());
		}
		float? global = LocalStorage.GetGlobal<float?>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, null);
		if (global == null)
		{
			if (isLog)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.GameSettings;
				ELogAuthor author3 = ELogAuthor.WZ;
				string message3 = "【GetCurrent】当前选项未被保存在LocalStorage中";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("functionId", id);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
			return null;
		}
		return new float?(global.Value);
	}

	// Token: 0x06005C2B RID: 23595 RVA: 0x00172F84 File Offset: 0x00171184
	public float GetCurrentValueSafelyFloat(EFunction id, float defaultValue = 0f)
	{
		float? currentValueFloat = this.GetCurrentValueFloat(id, false);
		if (currentValueFloat != null)
		{
			return currentValueFloat.Value;
		}
		OneOf<int, float, double>? initValue = this.GetInitValue(id, false);
		float? num;
		if (initValue == null)
		{
			num = null;
		}
		else
		{
			num = new float?(initValue.GetValueOrDefault().Match<float>((int i) => (float)i, (float f) => f, (double d) => (float)d));
		}
		float? num2 = num;
		if (num2 != null)
		{
			return num2.Value;
		}
		return defaultValue;
	}

	// Token: 0x06005C2C RID: 23596 RVA: 0x00173050 File Offset: 0x00171250
	private bool ApplyValueFloat(EFunction id, float value, EGameSettingsApplyReason reason)
	{
		if (!this.IsValid(id, true))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "在【应用】一个不符合条件的值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Func<float, EGameSettingsApplyReason, bool> applyCallbackFloat = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).ApplyCallbackFloat;
		if (applyCallbackFloat == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "[ApplyValue]该设置项不必应用";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("functionId", id);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return true;
		}
		return applyCallbackFloat(value, reason);
	}

	// Token: 0x06005C2D RID: 23597 RVA: 0x001730E8 File Offset: 0x001712E8
	private unsafe bool SaveValueFloat(EFunction id, float value)
	{
		if (!this.IsValid(id, true))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "在【Save】一个不符合条件的值";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		object getCallbackOrGlobalKey = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).GetCallbackOrGlobalKey;
		if (getCallbackOrGlobalKey is Func<int>)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "getter不必【Save】LocalStorage";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("functionId", id);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		LocalStorage.SetGlobal<float>((ELocalStorageGlobalKey)getCallbackOrGlobalKey, value);
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.GameSettings;
		ELogAuthor author3 = ELogAuthor.WZ;
		string message3 = "设置项【Save】成功";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return true;
	}

	// Token: 0x06005C2E RID: 23598 RVA: 0x001731E8 File Offset: 0x001713E8
	public unsafe void HandleValueChangeFloat(EFunction id, float value, EGameSettingsApplyReason reason)
	{
		if (reason == EGameSettingsApplyReason.WhenUi && !this.IsGameSettingsAppliedOnOpenLoading)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.TZJ;
			string message = "【HandleValueChange】登录界面态：覆盖 InitValueSourceCache";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.OverrideLoginCacheValue(id, (int)value);
		}
		if (this.ApplyValueFloat(id, value, reason))
		{
			this.SaveValueFloat(id, value);
			Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, id);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "设置项【Handle】成功";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("functionId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("value", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("reason", reason);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.GameSettings;
		ELogAuthor author3 = ELogAuthor.WZ;
		string message3 = "【HandleValueChange】设置项应用失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
		instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06005C2F RID: 23599 RVA: 0x00173340 File Offset: 0x00171540
	public bool ReApply(EFunction id, EGameSettingsApplyReason reason = EGameSettingsApplyReason.AnyTime, bool isLog = true)
	{
		int? currentValue = this.GetCurrentValue(id, isLog, true);
		if (currentValue == null)
		{
			if (isLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GameSettings;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "不能获取用于ReApply的设置项值，放弃ReApply";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return false;
		}
		return this.ApplyValue(id, currentValue.Value, reason);
	}

	// Token: 0x06005C30 RID: 23600 RVA: 0x001733A3 File Offset: 0x001715A3
	[NullableContext(2)]
	public string DumpValue(EFunction id)
	{
		Func<string> dumpCallback = GameSettingsDefine.function2GameSettings.GetValueOrDefault(id).DumpCallback;
		if (dumpCallback == null)
		{
			return null;
		}
		return dumpCallback();
	}

	// Token: 0x06005C31 RID: 23601 RVA: 0x001733C0 File Offset: 0x001715C0
	public string GetAudioCodeById(int type)
	{
		global::LanguageDefine languageDefineByType = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(type);
		if (languageDefineByType == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Menu;
			ELogAuthor author = ELogAuthor.MZJ;
			string message = "LanguageSystem 未定义此语种";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("非法值", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return "en";
		}
		return languageDefineByType.AudioCode;
	}

	// Token: 0x06005C32 RID: 23602 RVA: 0x00173414 File Offset: 0x00171614
	public string GetLanguageCodeById(int type)
	{
		global::LanguageDefine languageDefineByType = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(type);
		if (languageDefineByType == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Menu;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "LanguageSystem 未定义此语种";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("非法值", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return "en";
		}
		return languageDefineByType.LanguageCode;
	}

	// Token: 0x06005C33 RID: 23603 RVA: 0x00173468 File Offset: 0x00171668
	public unsafe bool CheckIsMatchQualityRecommend(EGameQualitySettingLevel quality, Func<EFunction, int?> valueGetter)
	{
		DeviceRenderFeature value = Singleton<GameSettingsDeviceRender>.Instance.GetDeviceRenderFeature(quality).Value;
		foreach (KeyValuePair<EFunction, int> keyValuePair in Singleton<GameSettingsDeviceRender>.Instance.GetOtherChangedValue(value))
		{
			EFunction efunction;
			int num;
			keyValuePair.Deconstruct(out efunction, out num);
			EFunction efunction2 = efunction;
			int num2 = num;
			if ((efunction2 != EFunction.MOBILERESOLUTION || Singleton<Info>.Instance.IsMobilePlatform()) && (efunction2 != EFunction.PCVSYNC || Singleton<Info>.Instance.IsPcOrGamepadPlatform()) && (efunction2 != EFunction.VOLUMEFOG || !Singleton<Info>.Instance.IsMacPlatform()) && (efunction2 != EFunction.NPCDENSITY || !UKuroStaticLibrary.IsLowMemoryDevice()) && efunction2 != EFunction.RayTracing && efunction2 != EFunction.AnisoLevel)
			{
				if (efunction2 == EFunction.SUPERRESOLUTION)
				{
					if (Singleton<Info>.Instance.IsWindowsPlatform())
					{
						EFunction efunction3 = EFunction.SUPERRESOLUTION;
						EFunction efunction4 = EFunction.SUPERRESOLUTION;
						int num3 = num2;
						ValueTuple<EFunction, EFunction, int> valueTuple = Singleton<GameSettingsDeviceRender>.Instance.MapSuperResolutionRecommendValue(efunction3, efunction4, num3);
						efunction3 = valueTuple.Item1;
						efunction4 = valueTuple.Item2;
						num3 = valueTuple.Item3;
						if (valueGetter(efunction3).GetValueOrDefault() == 0)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.GameSettings;
							ELogAuthor author = ELogAuthor.TZJ;
							string message = "画质相关项被手动修改过：未开启超级分辨率";
							ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("superResolutionId", efunction3);
							instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
							return false;
						}
						int valueOrDefault = valueGetter(efunction4).GetValueOrDefault();
						if (num3 != valueOrDefault)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.GameSettings;
							ELogAuthor author2 = ELogAuthor.TZJ;
							string message2 = "画质相关项被手动修改过：超级分辨率质量档位";
							<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("superResolutionId", efunction3);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("qualityId", efunction4);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("target value", num3);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("current value", valueOrDefault);
							instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
							return false;
						}
					}
				}
				else
				{
					int? num4 = valueGetter(efunction2);
					if (num4 != null)
					{
						int num5 = num2;
						int? num6 = num4;
						if (!(num5 == num6.GetValueOrDefault() & num6 != null))
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.GameSettings;
							ELogAuthor author3 = ELogAuthor.TZJ;
							string message3 = "画质相关项被手动修改过";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("functionId", efunction2);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("target value", num2);
							instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
							return false;
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x04002C1D RID: 11293
	private readonly Dictionary<EFunction, GameSettingsInitValueSource> ValidInitValueSourceCache = new Dictionary<EFunction, GameSettingsInitValueSource>();

	// Token: 0x04002C1E RID: 11294
	public bool IsGameSettingsAppliedOnOpenLoading;

	// Token: 0x04002C1F RID: 11295
	[Nullable(2)]
	private Dictionary<EFunction, MenuConfig> ValidApplyConfigMapInternal;
}
