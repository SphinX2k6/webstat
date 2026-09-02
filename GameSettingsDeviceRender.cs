using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

// Token: 0x02000E92 RID: 3730
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GameSettingsDeviceRender : Singleton<GameSettingsDeviceRender>
{
	// Token: 0x1700068E RID: 1678
	// (get) Token: 0x06005AFF RID: 23295 RVA: 0x00169AC4 File Offset: 0x00167CC4
	[Nullable(2)]
	private Dictionary<int, DeviceRenderFeature> DeviceRenderFeatureCfgMap
	{
		[NullableContext(2)]
		get
		{
			if (this.DeviceRenderFeatureCfgMapInternal == null)
			{
				IReadOnlyList<DeviceRenderFeature> deviceRenderFeatureConfigListByDeviceId = ConfigBase<GameSettingsConfig>.Instance.GetDeviceRenderFeatureConfigListByDeviceId((int)this.DeviceType);
				if (deviceRenderFeatureConfigListByDeviceId == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.GameSettings;
					ELogAuthor author = ELogAuthor.WZ;
					string message = "当前机型未定义RenderFeature";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("deviceType", this.DeviceType.ToString());
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
				this.DeviceRenderFeatureCfgMapInternal = new Dictionary<int, DeviceRenderFeature>();
				foreach (DeviceRenderFeature value in deviceRenderFeatureConfigListByDeviceId)
				{
					this.DeviceRenderFeatureCfgMapInternal[value.QualityType] = value;
				}
			}
			return this.DeviceRenderFeatureCfgMapInternal;
		}
	}

	// Token: 0x1700068F RID: 1679
	// (get) Token: 0x06005B00 RID: 23296 RVA: 0x00169B84 File Offset: 0x00167D84
	private int? RecommendQualityLv
	{
		get
		{
			if (this.RecommendQualityLvInternal == null)
			{
				IReadOnlyList<DeviceRenderFeature> deviceRenderFeatureConfigListByDeviceId = ConfigBase<GameSettingsConfig>.Instance.GetDeviceRenderFeatureConfigListByDeviceId((int)this.DeviceType);
				if (deviceRenderFeatureConfigListByDeviceId == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.GameSettings;
					ELogAuthor author = ELogAuthor.WZ;
					string message = "当前机型未定义RenderFeature";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("deviceType", this.DeviceType.ToString());
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
				foreach (DeviceRenderFeature deviceRenderFeature in deviceRenderFeatureConfigListByDeviceId)
				{
					if (deviceRenderFeature.DefaultQuality == 1)
					{
						this.RecommendQualityLvInternal = new int?(deviceRenderFeature.QualityType);
						break;
					}
				}
			}
			return this.RecommendQualityLvInternal;
		}
	}

	// Token: 0x17000690 RID: 1680
	// (get) Token: 0x06005B01 RID: 23297 RVA: 0x00169C54 File Offset: 0x00167E54
	public EGameQualitySettingLevel GameQualitySettingLevel
	{
		get
		{
			return (EGameQualitySettingLevel)Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.IMAGEQUALITY, 2, true);
		}
	}

	// Token: 0x17000691 RID: 1681
	// (get) Token: 0x06005B02 RID: 23298 RVA: 0x00169C64 File Offset: 0x00167E64
	public int PhysicalGBRam
	{
		get
		{
			return this.DevicePhysicalGbRam;
		}
	}

	// Token: 0x17000692 RID: 1682
	// (get) Token: 0x06005B03 RID: 23299 RVA: 0x00169C6C File Offset: 0x00167E6C
	private int[] FrameRateListAndroid
	{
		get
		{
			if (this.IsRedMagicLow())
			{
				return GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagicLow;
			}
			if (this.IsRedMagicHigh())
			{
				return GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagic;
			}
			return GameSettingsDeviceRenderDefine.FrameRateListAndroid;
		}
	}

	// Token: 0x06005B04 RID: 23300 RVA: 0x00169C8F File Offset: 0x00167E8F
	private bool IsSpecificMobileGpuByProfile(string keyword, bool fullMatch)
	{
		if (this.ProfileNameCache == null)
		{
			this.ProfileNameCache = UKuroRenderingRuntimeBPPluginBPLibrary.GetDeviceProfileProfileName();
		}
		if (fullMatch)
		{
			return keyword == this.ProfileNameCache;
		}
		return this.ProfileNameCache.Contains(keyword);
	}

	// Token: 0x06005B05 RID: 23301 RVA: 0x00169CC0 File Offset: 0x00167EC0
	public bool IsTargetBaseProfile(string keyword, bool fullMatch)
	{
		if (fullMatch)
		{
			return keyword == this.BaseProfileName;
		}
		return this.BaseProfileName.Contains(keyword);
	}

	// Token: 0x06005B06 RID: 23302 RVA: 0x00169CE0 File Offset: 0x00167EE0
	public unsafe void InitializeBaseInfo()
	{
		this.DevicePhysicalGbRam = UKuroRenderingRuntimeBPPluginBPLibrary.GetPhysicalGBRam();
		this.DeviceVideoGbRam = ((UKuroStaticLibrary.GetVideoMemoryGB() > 0) ? (UKuroStaticLibrary.GetVideoMemoryGB() + 1) : 0);
		this.VendorName = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIVendorName();
		this.DeviceName = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDeviceName();
		this.BaseProfileName = UKuroRenderingRuntimeBPPluginBPLibrary.GetDeviceProfileBaseProfileName();
		this.DeviceScore = UKuroRenderingRuntimeBPPluginBPLibrary.GetDeviceProfileDeviceScore();
		this.RHIName = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIName();
		this.HardwareLevel = UKuroRenderingRuntimeBPPluginBPLibrary.GetDeviceHardwareLevel();
		this.DriverDate = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDriverDate();
		this.DriverVersion = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDriverVersion();
		this.AdapterDriverVersion = UKuroRenderingRuntimeBPPluginBPLibrary.GetAdapterUserDriverVersion();
		this.WindowsVersion = UKuroRenderingRuntimeBPPluginBPLibrary.GetWindowsVersion();
		this.IsSSDDevice = UKuroRenderingRuntimeBPPluginBPLibrary.IsSSDDevice();
		this.IsAdreno = this.IsSpecificMobileGpuByProfile("Adreno", false);
		this.IsXuanJie = this.IsSpecificMobileGpuByProfile("Xiaomi_O1", true);
		this.MobileDeviceModel = UKuroRenderingRuntimeBPPluginBPLibrary.GetMobileDeviceModel();
		this.MobileDeviceMake = UKuroRenderingRuntimeBPPluginBPLibrary.GetMobileDeviceMake();
		this.CPUFrequency = UKuroRenderingRuntimeBPPluginBPLibrary.GetCPUFrequency();
		this.CPUCores = UKuroRenderingRuntimeBPPluginBPLibrary.GetCPUCores();
		this.CPUCoresIncludingHyperthreads = UKuroRenderingRuntimeBPPluginBPLibrary.GetCPUCoresIncludingHyperthreads();
		this.CPUBrand = UKuroRenderingRuntimeBPPluginBPLibrary.GetCPUBrand();
		this.IsSupportedAFME = UKismetRenderingLibrary.IsSupportedAFME();
		this.LowMemoryDeviceMark = UKismetSystemLibrary.GetConsoleVariableIntValue("memory.LowMemoryDeviceMark");
		if (UKuroFFXFSR3BlueprintLibrary.IsSupported())
		{
			UKuroFFXFSR3BlueprintLibrary.DumpAMDGPUInfos();
			if (UKuroFFXFSR3BlueprintLibrary.SupportFI())
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnStartLoadingState, new Action(this.TempDisableFFXFIWhenLoading));
				Singleton<EventSystem>.Instance.Add(EEventName.OnFinishLoadingState, new Action(this.RecoverFFXFITempStateWhenLoading));
				Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.TempDisableFFXFIWhenSeqC));
				Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.RecoverFFXFITempStateFromSeqC));
			}
		}
		if (Singleton<Info>.Instance.IsMobilePlatform() && this.IsVulkanRHI() == 0 && this.MobileDeviceMake.Contains("Xiaomi"))
		{
			this.IsBrokenGLPacingDevice = true;
		}
		if (Singleton<Platform>.Instance.IsMobilePlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Mobile.UseClusteredDeferredShading -1", null);
		}
		else
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Mobile.UseClusteredDeferredShading 2", null);
		}
		if (Singleton<Platform>.Instance.IsIOSPlatform())
		{
			this.DeviceType = EGameDeviceType.IOS_LOW;
			if (this.DeviceScore < 150)
			{
				this.DeviceType = EGameDeviceType.IOS_LOWEST;
			}
			else if (this.DeviceScore > 250 && this.DeviceScore < 360)
			{
				this.DeviceType = EGameDeviceType.IOS_MIDDLE;
			}
			else if (this.DeviceScore >= 360)
			{
				this.DeviceType = EGameDeviceType.IOS_HIGH;
			}
			else if (this.DeviceScore >= 650)
			{
				this.DeviceType = EGameDeviceType.IOS_VERY_HIGH;
			}
			if (UKuroStaticLibrary.IsLowMemoryDevice())
			{
				this.DeviceType = EGameDeviceType.IOS_LOWEST;
			}
		}
		else if (Singleton<Platform>.Instance.IsAndroidPlatform() || UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldFeatureLevel(GlobalData.World) == KuroFeatureLevel.ES3_1)
		{
			if (this.BaseProfileName == "Android_Lowest")
			{
				this.DeviceType = EGameDeviceType.ANDROID_LOWEST;
			}
			else if (this.BaseProfileName == "Android_Low")
			{
				this.DeviceType = EGameDeviceType.ANDROID_LOW;
			}
			else if (this.BaseProfileName == "Android_Mid")
			{
				this.DeviceType = EGameDeviceType.ANDROID_MIDDLE;
			}
			else if (this.BaseProfileName == "Android_High")
			{
				this.DeviceType = EGameDeviceType.ANDROID_HIGH;
			}
			else if (this.BaseProfileName == "Android_VeryHigh")
			{
				this.DeviceType = EGameDeviceType.ANDROID_VERY_HIGH;
			}
			else
			{
				this.DeviceType = EGameDeviceType.ANDROID_LOW;
			}
			if (!this.IsHuaweiAndroid() && !this.IsMaliNewSocOrXclipseOrPowerVR())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.HZBOcclusion 2", null);
			}
		}
		else if (Singleton<Platform>.Instance.IsPs5Platform())
		{
			this.DeviceType = EGameDeviceType.PS;
		}
		else if (Singleton<Platform>.Instance.IsMacPlatform())
		{
			if (this.BaseProfileName == "Mac_Low")
			{
				this.DeviceType = EGameDeviceType.PC_LOWEST;
			}
			else if (this.BaseProfileName == "Mac_Mid")
			{
				this.DeviceType = EGameDeviceType.PC_LOW;
			}
			else if (this.BaseProfileName == "Mac_High")
			{
				this.DeviceType = EGameDeviceType.PC_LOW;
			}
			else if (this.BaseProfileName == "Mac_VeryHigh")
			{
				this.DeviceType = EGameDeviceType.PC_MIDDLE;
				this.DeviceScore = 550;
			}
			else
			{
				this.DeviceType = EGameDeviceType.PC_MIDDLE;
			}
		}
		else if (Singleton<Platform>.Instance.IsCloudGame())
		{
			this.DeviceType = EGameDeviceType.CLOUD_GAME;
		}
		else if (this.BaseProfileName == "Windows_Lowest")
		{
			this.DeviceType = EGameDeviceType.PC_LOWEST;
		}
		else if (this.BaseProfileName == "Windows_Low")
		{
			this.DeviceType = EGameDeviceType.PC_LOW;
		}
		else if (this.BaseProfileName == "Windows_Mid")
		{
			this.DeviceType = EGameDeviceType.PC_MIDDLE;
		}
		else if (this.BaseProfileName == "Windows_High")
		{
			this.DeviceType = EGameDeviceType.PC_HIGH;
		}
		else if (this.BaseProfileName == "Windows_VeryHigh")
		{
			this.DeviceType = EGameDeviceType.PC_VERY_HIGH;
		}
		else if (this.BaseProfileName == "Windows_Highest")
		{
			this.DeviceType = EGameDeviceType.PC_HIGHEST;
		}
		else if (this.BaseProfileName == "Windows")
		{
			this.DeviceType = EGameDeviceType.PC_HIGH;
		}
		else
		{
			this.DeviceType = EGameDeviceType.PC_MIDDLE;
		}
		this.UpdateQualityRange();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Render;
		ELogAuthor author = ELogAuthor.WZ;
		string message = "初始化当前设备基本信息";
		<>y__InlineArray19<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray19<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("VendorName", this.VendorName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CPUBrand", this.CPUBrand);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("DeviceName", this.DeviceName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("BaseProfileName", this.BaseProfileName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("DriverDate", this.DriverDate);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("DriverVersion", this.DriverVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("AdapterDriverVersion", this.AdapterDriverVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("PhysicalGBRam", this.DevicePhysicalGbRam.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("VideoGbRam", this.DeviceVideoGbRam.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 9) = new ValueTuple<string, object>("DeviceScore", this.DeviceScore.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 10) = new ValueTuple<string, object>("RHIName", this.RHIName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 11) = new ValueTuple<string, object>("WindowsVersion", this.WindowsVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 12) = new ValueTuple<string, object>("IsSSDDevice", this.IsSSDDevice.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 13) = new ValueTuple<string, object>("HardwareLevel", this.HardwareLevel.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 14) = new ValueTuple<string, object>("DeviceType", this.DeviceType.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 15) = new ValueTuple<string, object>("QualityRange", this.QualityRange.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 16) = new ValueTuple<string, object>("platform", Singleton<Platform>.Instance.Type.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 17) = new ValueTuple<string, object>("MobileDeviceModel", this.MobileDeviceModel);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 18) = new ValueTuple<string, object>("LowMemoryDeviceMark", this.LowMemoryDeviceMark.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray19<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 19));
	}

	// Token: 0x06005B07 RID: 23303 RVA: 0x0016A49F File Offset: 0x0016869F
	public void Initialize()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.AfterGameQualitySettingsManagerInitialize);
	}

	// Token: 0x06005B08 RID: 23304 RVA: 0x0016A4B1 File Offset: 0x001686B1
	public void Clear()
	{
		this.CancelAllPerformanceLimit();
	}

	// Token: 0x06005B09 RID: 23305 RVA: 0x0016A4BC File Offset: 0x001686BC
	public bool IsDriverNeedUpdate()
	{
		string pattern = "(\\d{1,2})-(\\d{1,2})-(\\d{4})";
		Match match = Regex.Match(this.DriverDate, pattern);
		return (match.Success && int.Parse(match.Groups[3].Value) < 2023) || !UKuroRenderingRuntimeBPPluginBPLibrary.GetDriverValid();
	}

	// Token: 0x06005B0A RID: 23306 RVA: 0x0016A50C File Offset: 0x0016870C
	public bool IsDriverNeedUpdateForRayTracing()
	{
		string pattern = "(\\d{1,2})-(\\d{1,2})-(\\d{4})";
		Match match = Regex.Match(this.DriverDate, pattern);
		if (match.Success)
		{
			int num = int.Parse(match.Groups[3].Value);
			int num2 = int.Parse(match.Groups[1].Value);
			int num3 = int.Parse(match.Groups[2].Value);
			if (num < 2024)
			{
				return true;
			}
			if (num == 2024 && num2 < 6)
			{
				return true;
			}
			if (num == 2024 && num2 == 6 && num3 < 4)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06005B0B RID: 23307 RVA: 0x0016A5A8 File Offset: 0x001687A8
	public bool IsDriverNeedUpdateForRayTracingAMD9000()
	{
		string pattern = "(\\d{1,2})-(\\d{1,2})-(\\d{4})";
		Match match = Regex.Match(this.DriverDate, pattern);
		if (match.Success)
		{
			int num = int.Parse(match.Groups[3].Value);
			int num2 = int.Parse(match.Groups[1].Value);
			int num3 = int.Parse(match.Groups[2].Value);
			if (num < 2025)
			{
				return true;
			}
			if (num == 2025 && num2 < 10)
			{
				return true;
			}
			if (num == 2025 && num2 == 10 && num3 < 25)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06005B0C RID: 23308 RVA: 0x0016A645 File Offset: 0x00168845
	public bool IsDxr1_1NotSupported()
	{
		return UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.NotSupportedDxr1_1;
	}

	// Token: 0x06005B0D RID: 23309 RVA: 0x0016A650 File Offset: 0x00168850
	private void UpdateQualityRange()
	{
		EGameDeviceType deviceType = this.DeviceType;
		switch (deviceType)
		{
		case EGameDeviceType.PC_LOWEST:
		case EGameDeviceType.PC_LOW:
		case EGameDeviceType.ANDROID_LOWEST:
		case EGameDeviceType.ANDROID_LOW:
		case EGameDeviceType.IOS_LOWEST:
		case EGameDeviceType.IOS_LOW:
			return;
		case EGameDeviceType.PC_MIDDLE:
		case EGameDeviceType.ANDROID_MIDDLE:
		case EGameDeviceType.ANDROID_HIGH:
		case EGameDeviceType.IOS_MIDDLE:
		case EGameDeviceType.IOS_HIGH:
			this.QualityRange = EGameQualityRange.One2Three;
			return;
		case EGameDeviceType.PC_HIGH:
			this.QualityRange = EGameQualityRange.One2Three;
			return;
		case EGameDeviceType.PC_VERY_HIGH:
		case EGameDeviceType.ANDROID_VERY_HIGH:
		case EGameDeviceType.IOS_VERY_HIGH:
			this.QualityRange = EGameQualityRange.Two2Four;
			return;
		case EGameDeviceType.PC_HIGHEST:
			if (Singleton<GameSettingsManager>.Instance.IsPcHighestDevice())
			{
				this.QualityRange = EGameQualityRange.Three2Five;
				return;
			}
			this.QualityRange = EGameQualityRange.Two2Four;
			return;
		case (EGameDeviceType)17:
		case (EGameDeviceType)18:
		case (EGameDeviceType)19:
		case (EGameDeviceType)20:
		case (EGameDeviceType)26:
		case (EGameDeviceType)27:
		case (EGameDeviceType)28:
		case (EGameDeviceType)29:
		case (EGameDeviceType)30:
		case (EGameDeviceType)36:
		case (EGameDeviceType)37:
		case (EGameDeviceType)38:
		case (EGameDeviceType)39:
		case (EGameDeviceType)40:
			break;
		case EGameDeviceType.PS:
			this.QualityRange = EGameQualityRange.Zero2One;
			return;
		default:
			if (deviceType == EGameDeviceType.CLOUD_GAME)
			{
				this.QualityRange = EGameQualityRange.One;
				return;
			}
			if (deviceType == EGameDeviceType.XBox)
			{
				return;
			}
			break;
		}
		this.QualityRange = EGameQualityRange.Zero2Two;
	}

	// Token: 0x06005B0E RID: 23310 RVA: 0x0016A740 File Offset: 0x00168940
	public DeviceRenderFeature? GetDeviceRenderFeature(EGameQualitySettingLevel qualityLevel)
	{
		if (this.DeviceRenderFeatureCfgMap == null)
		{
			return null;
		}
		DeviceRenderFeature value;
		if (!this.DeviceRenderFeatureCfgMap.TryGetValue((int)qualityLevel, out value))
		{
			return null;
		}
		return new DeviceRenderFeature?(value);
	}

	// Token: 0x06005B0F RID: 23311 RVA: 0x0016A780 File Offset: 0x00168980
	public DeviceRenderFeature? GetCurrentDeviceRenderFeature()
	{
		if (this.DeviceRenderFeatureCfgMap == null)
		{
			return null;
		}
		DeviceRenderFeature value;
		if (!this.DeviceRenderFeatureCfgMap.TryGetValue((int)this.GameQualitySettingLevel, out value))
		{
			return null;
		}
		return new DeviceRenderFeature?(value);
	}

	// Token: 0x06005B10 RID: 23312 RVA: 0x0016A7C4 File Offset: 0x001689C4
	public DeviceRenderFeature? GetDefaultDeviceRenderFeature()
	{
		if (this.DeviceRenderFeatureCfgMap != null)
		{
			foreach (KeyValuePair<int, DeviceRenderFeature> keyValuePair in this.DeviceRenderFeatureCfgMap)
			{
				if (keyValuePair.Value.DefaultQuality == 1)
				{
					return new DeviceRenderFeature?(keyValuePair.Value);
				}
			}
		}
		return null;
	}

	// Token: 0x06005B11 RID: 23313 RVA: 0x0016A848 File Offset: 0x00168A48
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"superResolutionId",
		"qualityId",
		"qualityValue"
	})]
	public ValueTuple<EFunction, EFunction, int> MapSuperResolutionRecommendValue(EFunction superResolutionId, EFunction qualityId, int qualityValue)
	{
		int item = qualityValue;
		EFunction item2;
		EFunction item3;
		if (this.IsDlssGpuDevice())
		{
			item2 = EFunction.NVIDIADLSS;
			item3 = EFunction.NVIDIADLSSQUALITY;
			item = 99;
		}
		else if (this.IsXess2Supported())
		{
			item2 = EFunction.XESS2;
			item3 = EFunction.XESS2_QUALITY;
		}
		else if (this.IsFsr3Supported() && !this.IsFsr3FallbackToFsr())
		{
			item2 = EFunction.FSR3;
			item3 = EFunction.FSR3_QUALITY;
		}
		else
		{
			item2 = EFunction.FSR;
			item3 = EFunction.FSR;
			item = 1;
		}
		return new ValueTuple<EFunction, EFunction, int>(item2, item3, item);
	}

	// Token: 0x06005B12 RID: 23314 RVA: 0x0016A8B8 File Offset: 0x00168AB8
	public Dictionary<EFunction, int> GetOtherChangedValue(DeviceRenderFeature targetCfg)
	{
		this.renderFeatureValueBuffer.Clear();
		this.renderFeatureValueBuffer[EFunction.HIGHESTFPS] = this.GetFrameIndexByList(targetCfg.FPS);
		this.renderFeatureValueBuffer[EFunction.SHADOWQUALITY] = targetCfg.ShadowQuality;
		this.renderFeatureValueBuffer[EFunction.NIAGARAQUALITY] = targetCfg.FxQuality;
		this.renderFeatureValueBuffer[EFunction.IMAGEDETAIL] = targetCfg.ImageDetail;
		this.renderFeatureValueBuffer[EFunction.ANTIALISING] = targetCfg.AntiAliasing;
		this.renderFeatureValueBuffer[EFunction.SCENEAO] = targetCfg.AO;
		this.renderFeatureValueBuffer[EFunction.VOLUMEFOG] = targetCfg.VolumeFog;
		this.renderFeatureValueBuffer[EFunction.VOLUMELIGHT] = targetCfg.VolumeLight;
		this.renderFeatureValueBuffer[EFunction.MOTIONBLUR] = targetCfg.MotionBlur;
		this.renderFeatureValueBuffer[EFunction.PCVSYNC] = targetCfg.VSync;
		this.renderFeatureValueBuffer[EFunction.MOBILERESOLUTION] = targetCfg.ScreenPercentage;
		this.renderFeatureValueBuffer[EFunction.NPCDENSITY] = targetCfg.NpcDensity;
		this.renderFeatureValueBuffer[EFunction.VegetationDensity] = targetCfg.VegetationDensity;
		this.renderFeatureValueBuffer[EFunction.BLOOM] = targetCfg.Bloom;
		this.renderFeatureValueBuffer[EFunction.SUPERRESOLUTION] = targetCfg.SuperResolution;
		this.renderFeatureValueBuffer[EFunction.RayTracing] = targetCfg.Raytracing;
		this.renderFeatureValueBuffer[EFunction.LOADINGRANGESCALELEVEL] = 0;
		return this.renderFeatureValueBuffer;
	}

	// Token: 0x06005B13 RID: 23315 RVA: 0x0016AA36 File Offset: 0x00168C36
	public bool IsIosAndAndroidHighDevice()
	{
		return this.DeviceType == EGameDeviceType.ANDROID_MIDDLE || this.DeviceType == EGameDeviceType.ANDROID_HIGH || this.DeviceType == EGameDeviceType.ANDROID_VERY_HIGH || this.DeviceType == EGameDeviceType.IOS_MIDDLE || this.DeviceType == EGameDeviceType.IOS_HIGH || this.DeviceType == EGameDeviceType.IOS_VERY_HIGH;
	}

	// Token: 0x06005B14 RID: 23316 RVA: 0x0016AA76 File Offset: 0x00168C76
	public bool IsAndroidPlatformNotLow()
	{
		return this.DeviceType == EGameDeviceType.ANDROID_LOW || this.DeviceType == EGameDeviceType.ANDROID_MIDDLE || this.DeviceType == EGameDeviceType.ANDROID_HIGH || this.DeviceType == EGameDeviceType.ANDROID_VERY_HIGH;
	}

	// Token: 0x06005B15 RID: 23317 RVA: 0x0016AAA2 File Offset: 0x00168CA2
	public bool IsAndroidPlatformScreenBetter()
	{
		return this.DeviceType == EGameDeviceType.ANDROID_MIDDLE || this.DeviceType == EGameDeviceType.ANDROID_HIGH || this.DeviceType == EGameDeviceType.ANDROID_VERY_HIGH;
	}

	// Token: 0x06005B16 RID: 23318 RVA: 0x0016AAC4 File Offset: 0x00168CC4
	public bool IsAndroidPlatformScreenBad()
	{
		return this.DeviceType == EGameDeviceType.ANDROID_LOWEST || this.DeviceType == EGameDeviceType.ANDROID_LOW;
	}

	// Token: 0x06005B17 RID: 23319 RVA: 0x0016AADC File Offset: 0x00168CDC
	public bool IsAndroidPlatformLowest()
	{
		return this.DeviceType == EGameDeviceType.ANDROID_LOWEST;
	}

	// Token: 0x06005B18 RID: 23320 RVA: 0x0016AAE8 File Offset: 0x00168CE8
	public bool IsAndroidPlatformLow()
	{
		return this.DeviceType == EGameDeviceType.ANDROID_LOW;
	}

	// Token: 0x06005B19 RID: 23321 RVA: 0x0016AAF4 File Offset: 0x00168CF4
	public bool IsAndroidPlatformAOValid()
	{
		return Singleton<Platform>.Instance.IsAndroidPlatform() && !this.IsAndroidPlatformScreenBad();
	}

	// Token: 0x06005B1A RID: 23322 RVA: 0x0016AB0D File Offset: 0x00168D0D
	public bool IsIOSPlatformAOValid()
	{
		return Singleton<Platform>.Instance.IsIOSPlatform() && this.DeviceScore >= 230;
	}

	// Token: 0x06005B1B RID: 23323 RVA: 0x0016AB2D File Offset: 0x00168D2D
	public bool IsAndroidAdreno()
	{
		return this.IsAdreno;
	}

	// Token: 0x06005B1C RID: 23324 RVA: 0x0016AB35 File Offset: 0x00168D35
	public bool IsRedMagic()
	{
		return Singleton<Platform>.Instance.IsRedMagicDevice();
	}

	// Token: 0x06005B1D RID: 23325 RVA: 0x0016AB41 File Offset: 0x00168D41
	public bool IsRedMagicLow()
	{
		return Singleton<Platform>.Instance.IsRedMagicDeviceLow();
	}

	// Token: 0x06005B1E RID: 23326 RVA: 0x0016AB4D File Offset: 0x00168D4D
	public bool IsRedMagicHigh()
	{
		return Singleton<Platform>.Instance.IsRedMagicDeviceHigh();
	}

	// Token: 0x06005B1F RID: 23327 RVA: 0x0016AB59 File Offset: 0x00168D59
	public bool IsLowMemoryDevice()
	{
		return (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS && this.DevicePhysicalGbRam < 4) || (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android && this.DevicePhysicalGbRam <= 4);
	}

	// Token: 0x06005B20 RID: 23328 RVA: 0x0016AB8C File Offset: 0x00168D8C
	public int GetD3D12Type()
	{
		if (this.RHIName.Contains("D3D12"))
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06005B21 RID: 23329 RVA: 0x0016ABA3 File Offset: 0x00168DA3
	public int IsVulkanRHI()
	{
		if (this.RHIName.Contains("Vulkan"))
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06005B22 RID: 23330 RVA: 0x0016ABBA File Offset: 0x00168DBA
	public bool IsQualcommGpu()
	{
		return this.DeviceName.Contains("Qualcomm(R) Adreno(TM)");
	}

	// Token: 0x06005B23 RID: 23331 RVA: 0x0016ABCC File Offset: 0x00168DCC
	public bool IsMaliNewSocOrXclipseOrPowerVR()
	{
		return this.DeviceName.Contains("G710") || this.DeviceName.Contains("G715") || this.DeviceName.Contains("G720") || this.DeviceName.Contains("G610") || this.DeviceName.Contains("G615") || this.DeviceName.Contains("G620") || this.DeviceName.Contains("Xclipse") || this.DeviceName.Contains("BXM-8-256");
	}

	// Token: 0x06005B24 RID: 23332 RVA: 0x0016AC6C File Offset: 0x00168E6C
	public bool IsHuaweiAndroid()
	{
		if (string.IsNullOrEmpty(this.VendorName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.ZJF, "GameSettingsManager尚未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return this.DeviceName.Contains("Maleoon") && Singleton<Platform>.Instance.IsAndroidPlatform();
	}

	// Token: 0x06005B25 RID: 23333 RVA: 0x0016ACC5 File Offset: 0x00168EC5
	public bool IsNvidiaGPU()
	{
		return this.VendorName == "NVIDIA";
	}

	// Token: 0x06005B26 RID: 23334 RVA: 0x0016ACD8 File Offset: 0x00168ED8
	public bool IsUltraGpuDevice()
	{
		if (string.IsNullOrEmpty(this.VendorName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.ZJF, "GameSettingsManager尚未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return this.IsNvidiaGPU() && this.DeviceName.Contains("RTX");
	}

	// Token: 0x06005B27 RID: 23335 RVA: 0x0016AD2D File Offset: 0x00168F2D
	public bool IsNvidia4060()
	{
		return this.IsNvidiaGPU() && this.DeviceName.Contains("4060");
	}

	// Token: 0x06005B28 RID: 23336 RVA: 0x0016AD4C File Offset: 0x00168F4C
	public bool IsNvidia5060AndAbove()
	{
		Match match = Regex.Match(this.DeviceName, "\\bRTX\\s*(50\\d{2})\\b", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return false;
		}
		int num = int.Parse(match.Groups[1].Value);
		return this.IsNvidiaGPU() && num >= 5060;
	}

	// Token: 0x06005B29 RID: 23337 RVA: 0x0016ADA1 File Offset: 0x00168FA1
	public bool IsNvidiaLaptopGPU()
	{
		return this.IsNvidiaGPU() && this.DeviceName.Contains("Laptop");
	}

	// Token: 0x06005B2A RID: 23338 RVA: 0x0016ADC0 File Offset: 0x00168FC0
	public bool Is120FrameGPU()
	{
		if (string.IsNullOrEmpty(this.VendorName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.ZJF, "GameQualitySettingsManager尚未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return ((this.VendorName == "AMD" || this.IsNvidiaGPU() || this.VendorName == "Intel") && this.DeviceScore > 1300) || (this.VendorName == "Intel" && UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.Supported);
	}

	// Token: 0x06005B2B RID: 23339 RVA: 0x0016AE50 File Offset: 0x00169050
	public bool IsLaptopCPU_Old()
	{
		return this.CPUBrand.Contains("14900") || this.CPUBrand.Contains("14790") || this.CPUBrand.Contains("14700") || this.CPUBrand.Contains("14650") || this.CPUBrand.Contains("14600") || this.CPUBrand.Contains("14500") || this.CPUBrand.Contains("14490") || this.CPUBrand.Contains("14450") || this.CPUBrand.Contains("14400") || this.CPUBrand.Contains("13980") || this.CPUBrand.Contains("13950") || this.CPUBrand.Contains("13905") || this.CPUBrand.Contains("13900") || this.CPUBrand.Contains("13800") || this.CPUBrand.Contains("13790") || this.CPUBrand.Contains("13705") || this.CPUBrand.Contains("13700") || this.CPUBrand.Contains("13650") || this.CPUBrand.Contains("13620") || this.CPUBrand.Contains("13600") || this.CPUBrand.Contains("13500") || this.CPUBrand.Contains("13490") || this.CPUBrand.Contains("13450") || this.CPUBrand.Contains("13400") || this.CPUBrand.Contains("12950") || this.CPUBrand.Contains("12900") || this.CPUBrand.Contains("12850") || this.CPUBrand.Contains("12800") || this.CPUBrand.Contains("12700") || this.CPUBrand.Contains("12650") || this.CPUBrand.Contains("12600") || this.CPUBrand.Contains("12500") || this.CPUBrand.Contains("11980") || this.CPUBrand.Contains("11950") || this.CPUBrand.Contains("11900") || this.CPUBrand.Contains("11850") || this.CPUBrand.Contains("11800") || this.CPUBrand.Contains("11700") || this.CPUBrand.Contains("10980") || this.CPUBrand.Contains("10940") || this.CPUBrand.Contains("10920") || this.CPUBrand.Contains("10900") || this.CPUBrand.Contains("10885") || this.CPUBrand.Contains("10875") || this.CPUBrand.Contains("10870") || this.CPUBrand.Contains("10850") || this.CPUBrand.Contains("10700") || this.CPUBrand.Contains("9980") || this.CPUBrand.Contains("9940") || this.CPUBrand.Contains("9920") || this.CPUBrand.Contains("9900") || this.CPUBrand.Contains("9880") || this.CPUBrand.Contains("9820") || this.CPUBrand.Contains("9800") || this.CPUBrand.Contains("9-7900") || this.CPUBrand.Contains("7-7820") || this.CPUBrand.Contains("7-6900") || this.CPUBrand.Contains("9-185") || this.CPUBrand.Contains("7-165") || this.CPUBrand.Contains("7-155") || this.CPUBrand.Contains("5-135") || this.CPUBrand.Contains("5-125") || this.CPUBrand.Contains("9-3495") || this.CPUBrand.Contains("9-3475") || this.CPUBrand.Contains("7-3465") || this.CPUBrand.Contains("7-3455") || this.CPUBrand.Contains("7-3445") || this.CPUBrand.Contains("5-3435") || this.CPUBrand.Contains("5-3425") || this.CPUBrand.Contains("7-1270") || this.CPUBrand.Contains("7-1260") || this.CPUBrand.Contains("5-1250") || this.CPUBrand.Contains("5-1240") || this.CPUBrand.Contains("9700") || this.CPUBrand.Contains("9600") || this.CPUBrand.Contains("8945") || this.CPUBrand.Contains("8845") || this.CPUBrand.Contains("8840") || this.CPUBrand.Contains("8700") || this.CPUBrand.Contains("7980") || this.CPUBrand.Contains("7970") || this.CPUBrand.Contains("7960") || this.CPUBrand.Contains("7950") || this.CPUBrand.Contains("7945") || this.CPUBrand.Contains("7940") || this.CPUBrand.Contains("7900") || this.CPUBrand.Contains("7845") || this.CPUBrand.Contains("7840") || this.CPUBrand.Contains("7800") || this.CPUBrand.Contains("7745") || this.CPUBrand.Contains("7735") || this.CPUBrand.Contains("7700") || this.CPUBrand.Contains("6980") || this.CPUBrand.Contains("6900") || this.CPUBrand.Contains("6800") || this.CPUBrand.Contains("5980") || this.CPUBrand.Contains("5975") || this.CPUBrand.Contains("5965") || this.CPUBrand.Contains("5955") || this.CPUBrand.Contains("5950") || this.CPUBrand.Contains("5945") || this.CPUBrand.Contains("5900") || this.CPUBrand.Contains("5800") || this.CPUBrand.Contains("5700") || this.CPUBrand.Contains("4900") || this.CPUBrand.Contains("4800") || this.CPUBrand.Contains("4700") || this.CPUBrand.Contains("3975") || this.CPUBrand.Contains("3970") || this.CPUBrand.Contains("3960") || this.CPUBrand.Contains("3955") || this.CPUBrand.Contains("3950") || this.CPUBrand.Contains("3945") || this.CPUBrand.Contains("3900") || this.CPUBrand.Contains("3800") || this.CPUBrand.Contains("3700") || this.CPUBrand.Contains("2950") || this.CPUBrand.Contains("2920") || this.CPUBrand.Contains("2700") || this.CPUBrand.Contains("1950") || this.CPUBrand.Contains("1920") || this.CPUBrand.Contains("1900") || this.CPUBrand.Contains("1800") || this.CPUBrand.Contains("1700") || this.CPUBrand.Contains("Intel(R) Core(TM) i5-11600K") || this.CPUBrand.Contains("Intel(R) Core(TM) i5-12490F") || this.CPUBrand.Contains("Intel(R) Core(TM) Ultra 9 28") || this.CPUBrand.Contains("Intel(R) Core(TM) Ultra 9 27") || this.CPUBrand.Contains("Intel(R) Core(TM) Ultra 7 26") || this.CPUBrand.Contains("Intel(R) Core(TM) Ultra 7 25") || this.CPUBrand.Contains("Intel(R) Core(TM) Ultra 5 24") || this.CPUBrand.Contains("Intel(R) Core(TM) Ultra 5 23") || this.CPUBrand.Contains("AMD Ryzen 5 9") || this.CPUBrand.Contains("AMD Ryzen 7 9") || this.CPUBrand.Contains("AMD Ryzen 9 9") || this.CPUBrand.Contains("AMD Ryzen 5 8600") || this.CPUBrand.Contains("AMD Ryzen 7 7435H");
	}

	// Token: 0x06005B2C RID: 23340 RVA: 0x0016B984 File Offset: 0x00169B84
	public bool IsLaptopCPU()
	{
		if (this.IsLaptopCPU_Old())
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LQX, "IsOldLaptopCPU", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		string text = this.CPUBrand.ToUpperInvariant();
		if (text.Contains("INTEL"))
		{
			bool flag = Regex.IsMatch(text, "\\b\\d+(HX|HK|H|P|U|Y|G1|G2|G3|G4|G5|G6|G7)\\b");
			bool flag2 = Regex.IsMatch(text, "\\b\\d+(K|F|KF|T)\\b");
			return flag && !flag2;
		}
		if (text.Contains("AMD"))
		{
			bool flag3 = Regex.IsMatch(text, "\\b\\d+(H|HS|HX|U)\\b");
			bool flag4 = Regex.IsMatch(text, "\\b(H|HS|HX|U)\\b");
			return flag3 || flag4;
		}
		return false;
	}

	// Token: 0x06005B2D RID: 23341 RVA: 0x0016BA20 File Offset: 0x00169C20
	private bool IsFrameRate120IOSDevice()
	{
		return Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS && this.DeviceScore > 500;
	}

	// Token: 0x06005B2E RID: 23342 RVA: 0x0016BA3E File Offset: 0x00169C3E
	private bool IsFrameRate120MacDevice()
	{
		return Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Mac && this.DeviceScore > 500;
	}

	// Token: 0x06005B2F RID: 23343 RVA: 0x0016BA5C File Offset: 0x00169C5C
	private bool IsAMDX3DCPU()
	{
		return this.CPUBrand.Contains("AMD") && this.CPUBrand.Contains("X3D");
	}

	// Token: 0x06005B30 RID: 23344 RVA: 0x0016BA84 File Offset: 0x00169C84
	private unsafe bool IsFrameRate120Device()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Render;
		ELogAuthor author = ELogAuthor.YJL;
		string message = "判断IsFrameRate120Device";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CPUFrequency", this.CPUFrequency.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CPUCoresIncludingHyperthreads", this.CPUCoresIncludingHyperthreads.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("AMDX3DCPU", this.IsAMDX3DCPU().ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("IsLaptopCPU", this.IsLaptopCPU().ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Is120FrameGPU", this.Is120FrameGPU().ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		return ((this.CPUFrequency >= 3000 && this.CPUCoresIncludingHyperthreads >= 16) || this.IsAMDX3DCPU() || this.IsLaptopCPU()) && this.Is120FrameGPU();
	}

	// Token: 0x06005B31 RID: 23345 RVA: 0x0016BB99 File Offset: 0x00169D99
	public bool IsFrameRate120DeviceForAllDevice()
	{
		return (Singleton<Info>.Instance.IsPcOrGamepadPlatform() && this.IsFrameRate120Device()) || (Singleton<Info>.Instance.IsIosPlatform() && this.IsFrameRate120IOSDevice()) || (Singleton<Info>.Instance.IsMacPlatform() && this.IsFrameRate120MacDevice());
	}

	// Token: 0x06005B32 RID: 23346 RVA: 0x0016BBD9 File Offset: 0x00169DD9
	public bool IsAndroidHighestResolutionDevice()
	{
		return this.DeviceScore >= 280;
	}

	// Token: 0x06005B33 RID: 23347 RVA: 0x0016BBEB File Offset: 0x00169DEB
	public bool IsAndroidHighResolutionDevice()
	{
		return this.DeviceType == EGameDeviceType.ANDROID_MIDDLE || this.DeviceType == EGameDeviceType.ANDROID_HIGH || this.DeviceType == EGameDeviceType.ANDROID_VERY_HIGH;
	}

	// Token: 0x06005B34 RID: 23348 RVA: 0x0016BC0D File Offset: 0x00169E0D
	public bool IsMetalFxDevice()
	{
		return UKuroRenderingRuntimeBPPluginBPLibrary.IsSupportsMetalFx();
	}

	// Token: 0x06005B35 RID: 23349 RVA: 0x0016BC14 File Offset: 0x00169E14
	public bool IsPWSDKDevice()
	{
		return false;
	}

	// Token: 0x06005B36 RID: 23350 RVA: 0x0016BC17 File Offset: 0x00169E17
	public bool IsIRXActive()
	{
		return false;
	}

	// Token: 0x06005B37 RID: 23351 RVA: 0x0016BC1A File Offset: 0x00169E1A
	public void TurnOffIRX()
	{
	}

	// Token: 0x06005B38 RID: 23352 RVA: 0x0016BC1C File Offset: 0x00169E1C
	public void TurnOnIRX()
	{
	}

	// Token: 0x06005B39 RID: 23353 RVA: 0x0016BC1E File Offset: 0x00169E1E
	public bool IsNvidiaDlessPluginLoaded()
	{
		return UKismetSystemLibrary.GetConsoleVariableIntValue("r.NGX.Enable") == 1;
	}

	// Token: 0x06005B3A RID: 23354 RVA: 0x0016BC2D File Offset: 0x00169E2D
	public bool IsNvidiaStreamlinePluginLoaded()
	{
		return UKismetSystemLibrary.GetConsoleVariableBoolValue("r.Streamline.HasLoaded");
	}

	// Token: 0x06005B3B RID: 23355 RVA: 0x0016BC39 File Offset: 0x00169E39
	public bool IsNvidiaDlssPluginLoaded()
	{
		return UKismetSystemLibrary.GetConsoleVariableIntValue("r.NGX.Enable") == 1;
	}

	// Token: 0x06005B3C RID: 23356 RVA: 0x0016BC48 File Offset: 0x00169E48
	public bool IsDlssGpuDevice()
	{
		if (string.IsNullOrEmpty(this.VendorName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.ZJF, "GameSettingsManager尚未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return this.IsNvidiaGPU() && this.DeviceName.Contains("RTX");
	}

	// Token: 0x06005B3D RID: 23357 RVA: 0x0016BCA0 File Offset: 0x00169EA0
	private int? GetRTXSeriesNumber(string deviceName)
	{
		if (string.IsNullOrEmpty(deviceName))
		{
			return null;
		}
		Match match = Regex.Match(deviceName, "RTX\\s*(\\d+)", RegexOptions.IgnoreCase);
		if (match.Success && match.Groups.Count > 1)
		{
			return new int?(int.Parse(match.Groups[1].Value));
		}
		return null;
	}

	// Token: 0x06005B3E RID: 23358 RVA: 0x0016BD08 File Offset: 0x00169F08
	private int? GetAMDSeriesNumber(string deviceName)
	{
		if (string.IsNullOrEmpty(deviceName))
		{
			return null;
		}
		Match match = Regex.Match(deviceName, "RX\\s*(\\d+)", RegexOptions.IgnoreCase);
		if (match.Success && match.Groups.Count > 1)
		{
			return new int?(int.Parse(match.Groups[1].Value));
		}
		return null;
	}

	// Token: 0x06005B3F RID: 23359 RVA: 0x0016BD70 File Offset: 0x00169F70
	public unsafe bool IsRayTracingGpuDevice()
	{
		string a = this.VendorName.ToLower();
		if (a == "intel")
		{
			bool flag = UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.Supported;
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Render;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "Intel显卡，引擎底层检测不支持光追";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("deviceName", this.DeviceName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return flag;
		}
		if (a == "amd")
		{
			int? amdseriesNumber = this.GetAMDSeriesNumber(this.DeviceName);
			if (amdseriesNumber == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Render;
				ELogAuthor author2 = ELogAuthor.WZ;
				string message2 = "非AMD RX系列，或者型号解析不出来，不能开启光追";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("deviceName", this.DeviceName);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (Singleton<MathUtils>.Instance.InRangeArray((double)amdseriesNumber.Value, new double[]
			{
				6700.0,
				6799.0
			}) || Singleton<MathUtils>.Instance.InRangeArray((double)amdseriesNumber.Value, new double[]
			{
				7600.0,
				7699.0
			}))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Render;
				ELogAuthor author3 = ELogAuthor.WZ;
				string message3 = "AMD RX 某些型号不支持光追";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("amdSeriesNumber", amdseriesNumber.Value.ToString());
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return false;
			}
			if (Singleton<MathUtils>.Instance.InRangeArray((double)amdseriesNumber.Value, new double[]
			{
				9000.0,
				9999.0
			}) && this.IsDriverNeedUpdateForRayTracingAMD9000())
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Render;
				ELogAuthor author4 = ELogAuthor.WX;
				string message4 = "AMD 9000 驱动不支持光追";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("amdSeriesNumber", amdseriesNumber.Value.ToString());
				instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return false;
			}
			bool flag2 = UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.Supported;
			if (!flag2)
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.Render;
				ELogAuthor author5 = ELogAuthor.WZ;
				string message5 = "AMD显卡满足型号要求，但引擎底层检测不支持光追";
				ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("amdSeriesNumber", amdseriesNumber.Value.ToString());
				instance5.Warn(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
			}
			return flag2;
		}
		else
		{
			if (!(a == "nvidia"))
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.Render;
				ELogAuthor author6 = ELogAuthor.WZ;
				string message6 = "不可识别的显卡类型，不能开启光追";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("vendorName", this.VendorName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("deviceName", this.DeviceName);
				instance6.Warn(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (this.DeviceName.ToLower().Contains("titan rtx"))
			{
				bool flag3 = UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.Supported;
				if (!flag3)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Render, ELogAuthor.WZ, "NVIDIA Titan RTX，引擎底层检测不支持光追", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return flag3;
			}
			int? rtxseriesNumber = this.GetRTXSeriesNumber(this.DeviceName);
			if (rtxseriesNumber == null)
			{
				Log instance7 = Singleton<Log>.Instance;
				ELogModule module7 = ELogModule.Render;
				ELogAuthor author7 = ELogAuthor.WZ;
				string message7 = "非RTX系列，或者型号解析不出来，不能开启光追";
				ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>("deviceName", this.DeviceName);
				instance7.Warn(module7, author7, message7, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
				return false;
			}
			int? num = rtxseriesNumber;
			int num2 = 2070;
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = rtxseriesNumber;
				num2 = 3000;
				if (!(num.GetValueOrDefault() < num2 & num != null))
				{
					num = rtxseriesNumber;
					num2 = 3060;
					if (!(num.GetValueOrDefault() >= num2 & num != null))
					{
						goto IL_336;
					}
				}
				bool flag4 = UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.Supported;
				if (!flag4)
				{
					Log instance8 = Singleton<Log>.Instance;
					ELogModule module8 = ELogModule.Render;
					ELogAuthor author8 = ELogAuthor.WZ;
					string message8 = "NVIDIA显卡满足型号要求，但引擎底层检测不支持光追";
					ValueTuple<string, object> valueTuple7 = new ValueTuple<string, object>("nvSeriesNumber", rtxseriesNumber.Value.ToString());
					instance8.Warn(module8, author8, message8, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple7));
				}
				return flag4;
			}
			IL_336:
			Log instance9 = Singleton<Log>.Instance;
			ELogModule module9 = ELogModule.Render;
			ELogAuthor author9 = ELogAuthor.WZ;
			string message9 = "NVIDIA RTX 型号未达到光追白名单要求";
			ValueTuple<string, object> valueTuple8 = new ValueTuple<string, object>("nvSeriesNumber", rtxseriesNumber.Value.ToString());
			instance9.Warn(module9, author9, message9, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple8));
			return false;
		}
	}

	// Token: 0x06005B40 RID: 23360 RVA: 0x0016C14C File Offset: 0x0016A34C
	public bool IsRTX50()
	{
		int? rtxseriesNumber = this.GetRTXSeriesNumber(this.DeviceName);
		return rtxseriesNumber != null && rtxseriesNumber.Value > 5000;
	}

	// Token: 0x06005B41 RID: 23361 RVA: 0x0016C180 File Offset: 0x0016A380
	public bool IsShowRayTracingSetting()
	{
		if (this.IsRayTracingGpuDevice())
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.WZ, "允许显示光追设置：当前设备为支持光追的设备", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		if (UKuroRenderingRuntimeBPPluginBPLibrary.GetRayTracingSupportedType() == URayTracingSupport.NotSupportedDxr1_1)
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.WZ, "允许显示光追设置：设备不支持 DXR 1.1", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		return false;
	}

	// Token: 0x06005B42 RID: 23362 RVA: 0x0016C1DC File Offset: 0x0016A3DC
	public bool IsDlss3HardwareSchedulingDisabled()
	{
		if (string.IsNullOrEmpty(this.VendorName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.ZJF, "GameSettingsManager尚未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (!this.IsNvidiaDlssPluginLoaded() || !this.IsNvidiaStreamlinePluginLoaded())
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.WX, "DlSS or Streamline尚未加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return UStreamlineLibraryDLSSG.QueryDLSSGSupport() == EStreamlineFeatureSupport.NotSupportedHardewareSchedulingDisabled;
	}

	// Token: 0x06005B43 RID: 23363 RVA: 0x0016C24A File Offset: 0x0016A44A
	public bool IsDlssSupported()
	{
		return this.IsNvidiaDlssPluginLoaded() && UDLSSLibrary.IsDLSSSupported();
	}

	// Token: 0x06005B44 RID: 23364 RVA: 0x0016C25C File Offset: 0x0016A45C
	public bool IsDlss3GpuDevice()
	{
		if (string.IsNullOrEmpty(this.VendorName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.ZJF, "GameSettingsManager尚未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return this.IsNvidiaGPU() && (this.DeviceName.Contains("RTX 40") || this.DeviceName.Contains("RTX 50"));
	}

	// Token: 0x06005B45 RID: 23365 RVA: 0x0016C2C4 File Offset: 0x0016A4C4
	public bool IsFsrDevice()
	{
		if (Singleton<Platform>.Instance.IsPs5Platform())
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LQX, "PS5不支持Fsr", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		bool flag = this.IsDlssGpuDevice();
		bool flag2 = this.IsXess2Supported();
		bool flag3 = this.IsMetalFxDevice();
		bool flag4 = this.IsFsr3Supported() && UKuroFFXFSR3BlueprintLibrary.IsGlobalSwitchOn();
		return !flag && !flag2 && !flag3 && !flag4;
	}

	// Token: 0x06005B46 RID: 23366 RVA: 0x0016C32E File Offset: 0x0016A52E
	public bool IsXess2Supported()
	{
		return UXeSSBlueprintLibrary.IsXeSSSupported();
	}

	// Token: 0x06005B47 RID: 23367 RVA: 0x0016C335 File Offset: 0x0016A535
	public bool IsXeFGSupported()
	{
		return UXeFGBlueprintLibrary.IsXeFGSupported();
	}

	// Token: 0x06005B48 RID: 23368 RVA: 0x0016C33C File Offset: 0x0016A53C
	public bool IsFsr3Supported()
	{
		return UKuroFFXFSR3BlueprintLibrary.IsSupported() && UKuroFFXFSR3BlueprintLibrary.SupportFSR3();
	}

	// Token: 0x06005B49 RID: 23369 RVA: 0x0016C34C File Offset: 0x0016A54C
	public bool IsFFXFISupported()
	{
		return UKuroFFXFSR3BlueprintLibrary.IsSupported() && UKuroFFXFSR3BlueprintLibrary.SupportFI();
	}

	// Token: 0x06005B4A RID: 23370 RVA: 0x0016C35C File Offset: 0x0016A55C
	public bool IsFsr3FallbackToFsr()
	{
		return this.IsFsr3Supported() && this.GetD3D12Type() <= 0;
	}

	// Token: 0x06005B4B RID: 23371 RVA: 0x0016C374 File Offset: 0x0016A574
	public bool IsVulkanDevice()
	{
		bool flag = UKismetSystemLibrary.IsVulkanAutoDetectMode();
		bool flag2 = UKuroRenderingRuntimeBPPluginBPLibrary.SupportVulkan();
		if (flag)
		{
			string mobileDeviceModel = UKuroRenderingRuntimeBPPluginBPLibrary.GetMobileDeviceModel();
			TArray<string> vulkanAllowedModels = UKismetSystemLibrary.GetVulkanAllowedModels();
			bool flag3 = false;
			for (int i = 0; i < vulkanAllowedModels.Num(); i++)
			{
				if (vulkanAllowedModels.Get(i).Contains(mobileDeviceModel))
				{
					flag3 = true;
					break;
				}
			}
			flag2 = (flag2 || flag3);
			TArray<string> vulkanBlockedModels = UKismetSystemLibrary.GetVulkanBlockedModels();
			bool flag4 = false;
			for (int j = 0; j < vulkanBlockedModels.Num(); j++)
			{
				if (vulkanBlockedModels.Get(j).Contains(mobileDeviceModel))
				{
					flag4 = true;
					break;
				}
			}
			flag2 = (flag2 && !flag4);
		}
		else
		{
			TArray<string> vulkanAllowedModels2 = UKismetSystemLibrary.GetVulkanAllowedModels();
			TArray<string> vulkanBlockedModels2 = UKismetSystemLibrary.GetVulkanBlockedModels();
			string mobileDeviceModel2 = UKuroRenderingRuntimeBPPluginBPLibrary.GetMobileDeviceModel();
			if (mobileDeviceModel2.Length != 0)
			{
				bool flag5 = false;
				for (int k = 0; k < vulkanAllowedModels2.Num(); k++)
				{
					if (vulkanAllowedModels2.Get(k).Contains(mobileDeviceModel2))
					{
						flag5 = true;
						break;
					}
				}
				bool flag6 = false;
				for (int l = 0; l < vulkanBlockedModels2.Num(); l++)
				{
					if (vulkanBlockedModels2.Get(l).Contains(mobileDeviceModel2))
					{
						flag6 = true;
						break;
					}
				}
				flag2 = (flag5 && !flag6);
			}
		}
		return flag2;
	}

	// Token: 0x06005B4C RID: 23372 RVA: 0x0016C49F File Offset: 0x0016A69F
	public bool IsEnableVolumeFog()
	{
		return this.EnableVolumeFog;
	}

	// Token: 0x06005B4D RID: 23373 RVA: 0x0016C4A7 File Offset: 0x0016A6A7
	public void CloseVolumeFog()
	{
		this.EnableVolumeFog = false;
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.volumetricfog 0", null);
	}

	// Token: 0x06005B4E RID: 23374 RVA: 0x0016C4C0 File Offset: 0x0016A6C0
	public FIntPoint GetResolutionByList(int index)
	{
		List<FIntPoint> resolutionList = this.GetResolutionList();
		int index2 = Singleton<MathUtils>.Instance.Clamp(index, 0, resolutionList.Count - 1);
		return resolutionList[index2];
	}

	// Token: 0x06005B4F RID: 23375 RVA: 0x0016C4F0 File Offset: 0x0016A6F0
	public List<FIntPoint> GetResolutionList()
	{
		List<FIntPoint> list = new List<FIntPoint>();
		if (list.Count == 0)
		{
			this.ResolutionListRef = new TArray<FIntPoint>();
			if (UKismetSystemLibrary.GetSupportedFullscreenResolutions(ref this.ResolutionListRef))
			{
				for (int i = this.ResolutionListRef.Num() - 1; i >= 0; i--)
				{
					FIntPoint item = this.ResolutionListRef.Get(i);
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				list.Add(UGameUserSettings.GetGameUserSettings().GetDesktopResolution());
				Singleton<Log>.Instance.Warn(ELogModule.Menu, ELogAuthor.ZJF, "获取分辨率列表失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				list.Sort(delegate(FIntPoint a, FIntPoint b)
				{
					if (a.X == b.X)
					{
						return b.Y.CompareTo(a.Y);
					}
					return b.X.CompareTo(a.X);
				});
			}
		}
		if (list.Count > 0 && list[0].X == 3620 && list[0].Y == 2036)
		{
			list.RemoveAt(0);
		}
		return list;
	}

	// Token: 0x06005B50 RID: 23376 RVA: 0x0016C5E4 File Offset: 0x0016A7E4
	public unsafe int GetResolutionIndexByList(FIntPoint resolution)
	{
		List<FIntPoint> resolutionList = this.GetResolutionList();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < resolutionList.Count; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(',');
			}
			FIntPoint fintPoint = resolutionList[i];
			stringBuilder.Append(fintPoint.X).Append('x').Append(fintPoint.Y);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Render;
		ELogAuthor author = ELogAuthor.WZ;
		string message = "获取分辨率索引时的列表";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("resolutionList", stringBuilder.ToString());
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "current resolution";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(resolution.X);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<int>(resolution.Y);
		ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		int num = 0;
		foreach (FIntPoint fintPoint2 in resolutionList)
		{
			if (fintPoint2.Equals(resolution))
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	// Token: 0x06005B51 RID: 23377 RVA: 0x0016C730 File Offset: 0x0016A930
	public FIntPoint GetDefaultScreenResolution()
	{
		if (this.DefaultResolution == null)
		{
			List<FIntPoint> resolutionList = this.GetResolutionList();
			if (resolutionList.Count > 0)
			{
				FIntPoint fintPoint = resolutionList[0];
				if (!this.IsUltraGpuDevice() && (fintPoint.X > 2000 || fintPoint.Y > 1100))
				{
					foreach (FIntPoint fintPoint2 in resolutionList)
					{
						if (fintPoint2.X < 2000 && fintPoint2.Y < 1100)
						{
							fintPoint = fintPoint2;
							break;
						}
					}
				}
				this.DefaultResolution = new FIntPoint?(fintPoint);
			}
			else
			{
				this.DefaultResolution = new FIntPoint?(UGameUserSettings.GetGameUserSettings().GetDesktopResolution());
			}
		}
		return this.DefaultResolution.Value;
	}

	// Token: 0x06005B52 RID: 23378 RVA: 0x0016C810 File Offset: 0x0016AA10
	public int GetMobileResolutionByIndex(int index)
	{
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			return (new int[]
			{
				70,
				80,
				85,
				100
			})[index];
		}
		if (this.IsAndroidPlatformLowest())
		{
			return (new int[]
			{
				60,
				80,
				85,
				90
			})[index];
		}
		if (this.IsAndroidHighestResolutionDevice())
		{
			return (new int[]
			{
				66,
				75,
				83,
				100
			})[index];
		}
		return (new int[]
		{
			80,
			90,
			100,
			100
		})[index];
	}

	// Token: 0x06005B53 RID: 23379 RVA: 0x0016C88C File Offset: 0x0016AA8C
	public unsafe int GetFrameIndexByList(int frameRate)
	{
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			if (GameSettingsDeviceRenderDefine.FrameRateListIos.Contains(frameRate))
			{
				return Array.IndexOf<int>(GameSettingsDeviceRenderDefine.FrameRateListIos, frameRate);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "[ios]当前帧数不在帧数列表中，返回0";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("frameRate", frameRate.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("list", string.Join<int>(",", GameSettingsDeviceRenderDefine.FrameRateListIos));
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0;
		}
		else if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
		{
			if (this.FrameRateListAndroid.Contains(frameRate))
			{
				return Array.IndexOf<int>(this.FrameRateListAndroid, frameRate);
			}
			if (frameRate >= 40 && frameRate <= 45 && this.FrameRateListAndroid.Contains(40))
			{
				return Array.IndexOf<int>(this.FrameRateListAndroid, 40);
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameSettings;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "[android]当前帧数不在帧数列表中，返回0";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("frameRate", frameRate.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("list", string.Join<int>(",", this.FrameRateListAndroid));
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return 0;
		}
		else if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.OpenHarmony)
		{
			if (GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony.Contains(frameRate))
			{
				return Array.IndexOf<int>(GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony, frameRate);
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.GameSettings;
			ELogAuthor author3 = ELogAuthor.WZ;
			string message3 = "[openharmony]当前帧数不在帧数列表中，返回0";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("frameRate", frameRate.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("list", string.Join<int>(",", GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony));
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return 0;
		}
		else
		{
			if (GameSettingsDeviceRenderDefine.FrameRateListPc.Contains(frameRate))
			{
				return Array.IndexOf<int>(GameSettingsDeviceRenderDefine.FrameRateListPc, frameRate);
			}
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.GameSettings;
			ELogAuthor author4 = ELogAuthor.WZ;
			string message4 = "[pc]当前帧数不在帧数列表中，返回0";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("frameRate", frameRate.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("list", string.Join<int>(",", GameSettingsDeviceRenderDefine.FrameRateListAndroid));
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
			return 0;
		}
	}

	// Token: 0x06005B54 RID: 23380 RVA: 0x0016CB08 File Offset: 0x0016AD08
	public int GetFrameByList(int index)
	{
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			int num = Singleton<MathUtils>.Instance.Clamp(index, 0, GameSettingsDeviceRenderDefine.FrameRateListIos.Length - 1);
			return GameSettingsDeviceRenderDefine.FrameRateListIos[num];
		}
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
		{
			int num2 = Singleton<MathUtils>.Instance.Clamp(index, 0, this.FrameRateListAndroid.Length - 1);
			return this.FrameRateListAndroid[num2];
		}
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.XSX)
		{
			int num3 = Singleton<MathUtils>.Instance.Clamp(index, 0, GameSettingsDeviceRenderDefine.FrameRateListXSX.Length - 1);
			return GameSettingsDeviceRenderDefine.FrameRateListXSX[num3];
		}
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.OpenHarmony)
		{
			int num4 = Singleton<MathUtils>.Instance.Clamp(index, 0, GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony.Length - 1);
			return GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony[num4];
		}
		int num5 = Singleton<MathUtils>.Instance.Clamp(index, 0, GameSettingsDeviceRenderDefine.FrameRateListPc.Length - 1);
		return GameSettingsDeviceRenderDefine.FrameRateListPc[num5];
	}

	// Token: 0x06005B55 RID: 23381 RVA: 0x0016CBE4 File Offset: 0x0016ADE4
	public void ApplyDLSSG(int value)
	{
		try
		{
			if (value == 0)
			{
				UStreamlineLibraryDLSSG.SetDLSSGMode(EStreamlineDLSSGMode.Off);
				Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.XSZ, "ApplyDLSSG 0", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else if (this.DLSSGEnable)
			{
				if (this.IsRTX50())
				{
					if (value == 1)
					{
						UStreamlineLibraryDLSSG.SetDLSSGMode(EStreamlineDLSSGMode.On2X);
					}
					else if (value == 2)
					{
						UStreamlineLibraryDLSSG.SetDLSSGMode(EStreamlineDLSSGMode.On3X);
					}
					else if (value == 3)
					{
						UStreamlineLibraryDLSSG.SetDLSSGMode(EStreamlineDLSSGMode.On4X);
					}
					else if (value == 4)
					{
						UStreamlineLibraryDLSSG.SetDLSSGMode(EStreamlineDLSSGMode.On5X);
					}
					else if (value == 5)
					{
						UStreamlineLibraryDLSSG.SetDLSSGMode(EStreamlineDLSSGMode.On6X);
					}
				}
				else
				{
					UStreamlineLibraryDLSSG.SetDLSSGMode(EStreamlineDLSSGMode.Auto);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Game;
				ELogAuthor author = ELogAuthor.XSZ;
				string message = "ApplyDLSSG";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Mode", this.DLSSGMode.ToString());
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.ApplyUnlimitedFrameRate(value != 0);
		}
		catch (Exception ex)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Game;
			ELogAuthor author2 = ELogAuthor.XSZ;
			string message2 = "Module Streamline not found";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", ex.Message);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
	}

	// Token: 0x06005B56 RID: 23382 RVA: 0x0016CCF4 File Offset: 0x0016AEF4
	public unsafe void EnableDLSSG(int value)
	{
		this.DLSSGEnable = (value != 0);
		this.DLSSGMode = value;
		this.SetDLSSGRetainResourcesWhenOff(this.DLSSGEnable);
		if (value == 0)
		{
			UStreamlineLibraryReflex.SetReflexMode(EStreamlineReflexMode.Off);
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.XSZ, "SetReflexMode 0", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		else
		{
			UStreamlineLibraryReflex.SetReflexMode(EStreamlineReflexMode.Boost);
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.XSZ, "SetReflexMode 3", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.ApplyUnlimitedFrameRate(this.DLSSGEnable);
		if (this.DLSSGDisalbeTemporaryKeys.Count == 0)
		{
			this.ApplyDLSSG(this.DLSSGMode);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Game;
		ELogAuthor author = ELogAuthor.XSZ;
		string message = "EnableDLSSG";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Mode", this.DLSSGMode.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DisalbeTemporaryKeys", this.DLSSGDisalbeTemporaryKeys.Count.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06005B57 RID: 23383 RVA: 0x0016CDFB File Offset: 0x0016AFFB
	public bool IsEnableDLSSG()
	{
		return this.DLSSGEnable;
	}

	// Token: 0x06005B58 RID: 23384 RVA: 0x0016CE04 File Offset: 0x0016B004
	private void SetDLSSGRetainResourcesWhenOff(bool enable)
	{
		int value = (enable > false) ? 1 : 0;
		UObject world = GlobalData.World;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 1);
		defaultInterpolatedStringHandler.AppendLiteral("r.Streamline.DLSSG.RetainResourcesWhenOff ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Game;
		ELogAuthor author = ELogAuthor.XSZ;
		string message = "SetDLSSGRetainResourcesWhenOff";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Value", value.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06005B59 RID: 23385 RVA: 0x0016CE74 File Offset: 0x0016B074
	public unsafe void TemporaryDisableDLSSG(string key)
	{
		if (this.IsDlss3GpuDevice() && this.IsNvidiaStreamlinePluginLoaded())
		{
			this.DLSSGDisalbeTemporaryKeys[key] = 1;
			if (this.DLSSGDisalbeTemporaryKeys.Count > 0)
			{
				this.ApplyDLSSG(0);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.XSZ;
			string message = "disable DLSSG temploary";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("num", this.DLSSGDisalbeTemporaryKeys.Count.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06005B5A RID: 23386 RVA: 0x0016CF20 File Offset: 0x0016B120
	public unsafe void CancelTemporaryDisableDLSSG(string key)
	{
		if (this.IsDlss3GpuDevice() && this.IsNvidiaStreamlinePluginLoaded())
		{
			this.DLSSGDisalbeTemporaryKeys.Remove(key);
			if (this.DLSSGDisalbeTemporaryKeys.Count == 0 && this.IsEnableDLSSG())
			{
				this.ApplyDLSSG(this.DLSSGMode);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.XSZ;
			string message = "recover DLSSG";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("num", this.DLSSGDisalbeTemporaryKeys.Count.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06005B5B RID: 23387 RVA: 0x0016CFD6 File Offset: 0x0016B1D6
	public void EnableAFME(int value)
	{
		this.AFMEEnable = (value != 0);
		this.ApplyAFME();
	}

	// Token: 0x06005B5C RID: 23388 RVA: 0x0016CFE8 File Offset: 0x0016B1E8
	public void ApplyAFME()
	{
		if (this.AFMEDisalbeTemporaryKeys.Count <= 0 && this.AFMEEnable)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FEstimation.Option 0", null);
			this.AFMERunning = true;
		}
		else
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FEstimation.Option 1", null);
			this.AFMERunning = false;
		}
		this.ApplyFrameRate(this.FrameRateInternal);
	}

	// Token: 0x06005B5D RID: 23389 RVA: 0x0016D04C File Offset: 0x0016B24C
	public void ApplyKuroFITranslucentEnhance(bool bEnable)
	{
		int value = (bEnable > false) ? 1 : 0;
		UObject world = GlobalData.World;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted("r.KuroFI.TranslucentLightingMode");
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
	}

	// Token: 0x06005B5E RID: 23390 RVA: 0x0016D09C File Offset: 0x0016B29C
	public void ApplyKuroFISingleOcclusionBloomReplace(bool bEnable)
	{
		int value = (bEnable > false) ? 1 : 0;
		UObject world = GlobalData.World;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted("r.KuroFI.EnableSingleOcclusionBloomReplace");
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
	}

	// Token: 0x06005B5F RID: 23391 RVA: 0x0016D0EC File Offset: 0x0016B2EC
	public unsafe void TemporaryDisableAFME(string key)
	{
		if (this.IsSupportedAFME)
		{
			bool flag = this.AFMEDisalbeTemporaryKeys.Count == 0;
			this.AFMEDisalbeTemporaryKeys[key] = 1;
			if (flag)
			{
				this.ApplyAFME();
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.ZJF;
			string message = "disable AFME temploary";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("num", this.AFMEDisalbeTemporaryKeys.Count.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ApplyAFME", flag.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
	}

	// Token: 0x06005B60 RID: 23392 RVA: 0x0016D1AC File Offset: 0x0016B3AC
	public unsafe void CancelTemporaryDisableAFME(string key)
	{
		if (this.IsSupportedAFME && this.AFMEDisalbeTemporaryKeys.Count > 0)
		{
			this.AFMEDisalbeTemporaryKeys.Remove(key);
			bool flag = this.AFMEDisalbeTemporaryKeys.Count == 0;
			if (flag)
			{
				this.ApplyAFME();
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.ZJF;
			string message = "recover AFME";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("num", this.AFMEDisalbeTemporaryKeys.Count.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ApplyAFME", flag.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
	}

	// Token: 0x06005B61 RID: 23393 RVA: 0x0016D280 File Offset: 0x0016B480
	public void TemporaryDisableFrameGeneration(string key)
	{
		if (this.IsSupportedAFME)
		{
			this.TemporaryDisableAFME(key);
		}
		if (this.IsDlss3GpuDevice() && this.IsNvidiaStreamlinePluginLoaded())
		{
			this.TemporaryDisableDLSSG(key);
		}
		if (this.IsFFXFISupported())
		{
			this.ToggleFFXFIStateTemporarily(EFFXFIApplyMode.UIView, false);
		}
		if (this.IsXess2Supported())
		{
			this.TemporaryDisableXefg(key);
		}
	}

	// Token: 0x06005B62 RID: 23394 RVA: 0x0016D2D4 File Offset: 0x0016B4D4
	public void EnableXeSS(bool value)
	{
		if (value)
		{
			this.XessEnabled++;
		}
		else
		{
			this.XessEnabled--;
		}
		if (this.XessEnabled > 0)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.XeSS.Enabled 1", null);
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.XeSS.Enabled 0", null);
	}

	// Token: 0x06005B63 RID: 23395 RVA: 0x0016D32C File Offset: 0x0016B52C
	public void ApplyXefg(int mode)
	{
		bool flag = this.XessEnabled > 0 && mode > 0;
		UObject world = GlobalData.World;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
		defaultInterpolatedStringHandler.AppendLiteral("r.XeFG.MaxInterpolatedFrames ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(mode);
		UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		if (flag)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.XeFG.Enabled 1", null);
		}
		else
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.XeFG.Enabled 0", null);
		}
		this.ApplyUnlimitedFrameRate(flag);
	}

	// Token: 0x06005B64 RID: 23396 RVA: 0x0016D3A6 File Offset: 0x0016B5A6
	public void EnableXefg(int mode)
	{
		this.XefgMode = mode;
		if (this.XefgDisableTemporaryKeys.Count == 0)
		{
			this.ApplyXefg(mode);
		}
	}

	// Token: 0x06005B65 RID: 23397 RVA: 0x0016D3C4 File Offset: 0x0016B5C4
	public unsafe void TemporaryDisableXefg(string key)
	{
		if (this.IsXess2Supported())
		{
			if (this.XefgDisableTemporaryKeys.Count == 0)
			{
				this.ApplyXefg(0);
			}
			this.XefgDisableTemporaryKeys[key] = this.XefgMode;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.XSZ;
			string message = "disable Xefg temporary";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("num", this.XefgDisableTemporaryKeys.Count.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06005B66 RID: 23398 RVA: 0x0016D468 File Offset: 0x0016B668
	public unsafe void CancelTemporaryDisableXefg(string key)
	{
		if (!this.XefgDisableTemporaryKeys.ContainsKey(key) && key != "CursorVisialbe")
		{
			return;
		}
		if (this.IsXess2Supported())
		{
			this.XefgDisableTemporaryKeys.Remove(key);
			if (this.XefgDisableTemporaryKeys.Count == 0)
			{
				this.ApplyXefg(this.XefgMode);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.XSZ;
			string message = "enable Xefg temporary";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", this.XefgMode.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("num", this.XefgDisableTemporaryKeys.Count.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
	}

	// Token: 0x06005B67 RID: 23399 RVA: 0x0016D54C File Offset: 0x0016B74C
	public void CancelTemporaryDisableFrameGeneration(string key)
	{
		if (this.IsSupportedAFME)
		{
			this.CancelTemporaryDisableAFME(key);
		}
		if (this.IsDlss3GpuDevice() && this.IsNvidiaStreamlinePluginLoaded())
		{
			this.CancelTemporaryDisableDLSSG(key);
		}
		if (this.IsFFXFISupported())
		{
			this.ToggleFFXFIStateTemporarily(EFFXFIApplyMode.UIView, true);
		}
		if (this.IsXess2Supported())
		{
			this.CancelTemporaryDisableXefg(key);
		}
	}

	// Token: 0x06005B68 RID: 23400 RVA: 0x0016D5A0 File Offset: 0x0016B7A0
	public void ToggleFFXFIStateTemporarily(EFFXFIApplyMode applyMode, bool bRecover)
	{
		if (!this.IsFFXFISupported())
		{
			return;
		}
		EFFXFIApplyMode fsr3FgApplyMode = GameSettingsUtils.GetFsr3FgApplyMode();
		bool flag = GameSettingsUtils.GetFsr3FgSwitchState(EFFXFIApplyMode.Default) != 0;
		if (GameSettingsUtils.IsTemporaryFFXFIApplyMode(applyMode))
		{
			if (bRecover)
			{
				GameSettingsUtils.LeaveTemporaryFFXFIApplyState();
			}
			else
			{
				GameSettingsUtils.EnterTemporaryFFXFIApplyState();
			}
		}
		if (GameSettingsUtils.IsTemporaryFFXFIApplyMode(fsr3FgApplyMode) && GameSettingsUtils.IsTemporaryFFXFIApplyMode(applyMode))
		{
			if (fsr3FgApplyMode >= applyMode)
			{
				if (bRecover)
				{
					GameSettingsUtils.ApplyFsr3Fg((flag > false) ? 1 : 0, EFFXFIApplyMode.Default);
					return;
				}
				GameSettingsUtils.ApplyFsr3Fg(0, applyMode);
				return;
			}
		}
		else
		{
			if (bRecover)
			{
				GameSettingsUtils.ApplyFsr3Fg((flag > false) ? 1 : 0, EFFXFIApplyMode.Default);
				return;
			}
			GameSettingsUtils.ApplyFsr3Fg(0, applyMode);
		}
	}

	// Token: 0x06005B69 RID: 23401 RVA: 0x0016D620 File Offset: 0x0016B820
	public void TempDisableFFXFIWhenLoading()
	{
		if (this.IsFFXFISupported())
		{
			this.ToggleFFXFIStateTemporarily(EFFXFIApplyMode.Loading, false);
		}
	}

	// Token: 0x06005B6A RID: 23402 RVA: 0x0016D632 File Offset: 0x0016B832
	public void RecoverFFXFITempStateWhenLoading()
	{
		if (this.IsFFXFISupported())
		{
			this.ToggleFFXFIStateTemporarily(EFFXFIApplyMode.Loading, true);
		}
	}

	// Token: 0x06005B6B RID: 23403 RVA: 0x0016D644 File Offset: 0x0016B844
	public void TempDisableFFXFIWhenSeqC(PlotInfo plotInfo)
	{
		if (this.IsFFXFISupported())
		{
			this.ToggleFFXFIStateTemporarily(EFFXFIApplyMode.SeqC, false);
		}
	}

	// Token: 0x06005B6C RID: 23404 RVA: 0x0016D656 File Offset: 0x0016B856
	public void RecoverFFXFITempStateFromSeqC(PlotResultInfo plotResultInfo)
	{
		if (this.IsFFXFISupported())
		{
			this.ToggleFFXFIStateTemporarily(EFFXFIApplyMode.SeqC, true);
		}
	}

	// Token: 0x06005B6D RID: 23405 RVA: 0x0016D668 File Offset: 0x0016B868
	public void ApplyFrameRate(int value)
	{
		int num = 0;
		int num2 = 0;
		if (value > 0)
		{
			int min = 24;
			int max = 120;
			this.FrameRateInternal = Singleton<MathUtils>.Instance.Clamp(value, min, max);
			this.FrameSecondsInternal = 1f / (float)this.FrameRateInternal;
			num = this.FrameRateInternal;
			if (this.FrameRateTemploary > 0)
			{
				num = this.FrameRateTemploary;
			}
			num2 = num;
			if (Singleton<Info>.Instance.IsMobilePlatform())
			{
				if (this.AFMERunning)
				{
					num *= 2;
				}
				TArray<int> supportedRefreshRates = UKuroRenderingRuntimeBPPluginBPLibrary.GetSupportedRefreshRates();
				List<int> list = new List<int>();
				for (int i = 0; i < supportedRefreshRates.Num(); i++)
				{
					list.Add(supportedRefreshRates.Get(i));
				}
				list.Sort((int a, int b) => a - b);
				int? num3 = null;
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j] >= num)
					{
						num3 = new int?(list[j]);
						break;
					}
				}
				num = ((num3 != null) ? num3.Value : list[list.Count - 1]);
				if (this.AFMERunning && num > 0)
				{
					num2 = Math.Min(num2, num / 2);
				}
			}
		}
		if (this.IsBrokenGLPacingDevice)
		{
			num = 60;
			if (Singleton<Info>.Instance.IsMobilePlatform() && this.AFMERunning)
			{
				num2 = 30;
			}
		}
		if (Singleton<Info>.Instance.IsAndroidPlatform() && this.AFMERunning && this.IsEnergySavingFrameInterpolationSupported())
		{
			num = 60;
			num2 = 30;
			Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.TZJ, "节能插帧-锁定帧数为30", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		gameUserSettings.SetFrameRateLimit((float)num2);
		if (Singleton<Info>.Instance.IsAndroidPlatform() || Singleton<Info>.Instance.IsOpenHarmonyPlatform())
		{
			gameUserSettings.SetFramePace(num);
		}
		gameUserSettings.ApplySettings(true);
		if (PerfSightController.IsEnable)
		{
			UPerfSightHelper.PostEvent(801, value.ToString());
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.SettingFrameRateChanged, num);
	}

	// Token: 0x17000693 RID: 1683
	// (get) Token: 0x06005B6E RID: 23406 RVA: 0x0016D872 File Offset: 0x0016BA72
	public int FrameRate
	{
		get
		{
			return this.FrameRateInternal;
		}
	}

	// Token: 0x17000694 RID: 1684
	// (get) Token: 0x06005B6F RID: 23407 RVA: 0x0016D87A File Offset: 0x0016BA7A
	public float FrameSeconds
	{
		get
		{
			return this.FrameSecondsInternal;
		}
	}

	// Token: 0x06005B70 RID: 23408 RVA: 0x0016D884 File Offset: 0x0016BA84
	public void ApplyUnlimitedFrameRate(bool value)
	{
		if (value)
		{
			this.ApplyFrameRate(0);
		}
		else
		{
			this.ApplyFrameRate(this.FrameRateInternal);
		}
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		if (Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.PCVSYNC, 0, false) == 1)
		{
			gameUserSettings.SetVSyncEnabled(!value);
			gameUserSettings.ApplySettings(true);
		}
	}

	// Token: 0x06005B71 RID: 23409 RVA: 0x0016D8D4 File Offset: 0x0016BAD4
	public int GetMaxRoleShadowNum()
	{
		int gameQualitySettingLevel = (int)this.GameQualitySettingLevel;
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			return GameSettingsDeviceRenderDefine.MaxRoleShadowNumWithGameGraphQualityPc[gameQualitySettingLevel];
		}
		return GameSettingsDeviceRenderDefine.MaxRoleShadowNumWithGameGraphQualityMobile[gameQualitySettingLevel];
	}

	// Token: 0x06005B72 RID: 23410 RVA: 0x0016D904 File Offset: 0x0016BB04
	public int GetMaxRoleShadowDistance()
	{
		int gameQualitySettingLevel = (int)this.GameQualitySettingLevel;
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			return GameSettingsDeviceRenderDefine.MaxRoleShadowDistanceWithGameGraphQualityPc[gameQualitySettingLevel];
		}
		return GameSettingsDeviceRenderDefine.MaxRoleShadowDistanceWithGameGraphQualityMobile[gameQualitySettingLevel];
	}

	// Token: 0x06005B73 RID: 23411 RVA: 0x0016D934 File Offset: 0x0016BB34
	public int GetMaxDecalShadowDistance()
	{
		int gameQualitySettingLevel = (int)this.GameQualitySettingLevel;
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			return GameSettingsDeviceRenderDefine.MaxDecalShadowDistanceWithGameGraphQualityPc[gameQualitySettingLevel];
		}
		return GameSettingsDeviceRenderDefine.MaxDecalShadowDistanceWithGameGraphQualityMobile[gameQualitySettingLevel];
	}

	// Token: 0x06005B74 RID: 23412 RVA: 0x0016D964 File Offset: 0x0016BB64
	public int IsMainPlayerUseRealRoleShadow()
	{
		int gameQualitySettingLevel = (int)this.GameQualitySettingLevel;
		return GameSettingsDeviceRenderDefine.MainPlayerRealShadow[gameQualitySettingLevel];
	}

	// Token: 0x06005B75 RID: 23413 RVA: 0x0016D97F File Offset: 0x0016BB7F
	public void SetFrameRateTemploary(int frameRate)
	{
		this.FrameRateTemploary = Singleton<MathUtils>.Instance.Clamp(frameRate, 24, 120);
		this.FrameSecondsInternal = 1f / (float)this.FrameRateTemploary;
	}

	// Token: 0x06005B76 RID: 23414 RVA: 0x0016D9AC File Offset: 0x0016BBAC
	public void SetSequenceFrameRateLimit()
	{
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			if (this.FrameRateInternal > 31)
			{
				this.SetFrameRateTemploary(30);
				this.ApplyFrameRate(this.FrameRateInternal);
			}
		}
		else if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
		{
			if (this.FrameRateInternal > 31)
			{
				this.SetFrameRateTemploary(30);
				this.ApplyFrameRate(this.FrameRateInternal);
			}
		}
		else if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.OpenHarmony && this.FrameRateInternal > 31)
		{
			this.SetFrameRateTemploary(30);
			this.ApplyFrameRate(this.FrameRateInternal);
		}
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			this.TryReduceCsmUpdateFrequency("Plot");
		}
	}

	// Token: 0x06005B77 RID: 23415 RVA: 0x0016DA58 File Offset: 0x0016BC58
	public void CancleSequenceFrameRateLimit()
	{
		this.CancelFrameRateTemploary();
		this.ApplyFrameRate(this.FrameRateInternal);
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS || Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android || Singleton<Info>.Instance.PlatformType == ESourcePlatformType.OpenHarmony)
		{
			this.TryRestoreCsmUpdateFrequency("Plot");
		}
	}

	// Token: 0x06005B78 RID: 23416 RVA: 0x0016DAAA File Offset: 0x0016BCAA
	public void CancelFrameRateTemploary()
	{
		this.FrameRateTemploary = 0;
		this.FrameSecondsInternal = 1f / (float)this.FrameRateInternal;
	}

	// Token: 0x06005B79 RID: 23417 RVA: 0x0016DAC6 File Offset: 0x0016BCC6
	public void TryReduceCsmUpdateFrequency(string reason)
	{
		bool count = this.ReduceCsmReasonSet.Count != 0;
		this.ReduceCsmReasonSet.Add(reason);
		if (!count && this.ReduceCsmReasonSet.Count == 1)
		{
			this.ReduceCsmUpdateFrequency();
		}
	}

	// Token: 0x06005B7A RID: 23418 RVA: 0x0016DAF6 File Offset: 0x0016BCF6
	public void TryRestoreCsmUpdateFrequency(string reason)
	{
		if (this.ReduceCsmReasonSet.Remove(reason) && this.ReduceCsmReasonSet.Count == 0)
		{
			this.RestoreCsmUpdateFrequency();
		}
	}

	// Token: 0x06005B7B RID: 23419 RVA: 0x0016DB19 File Offset: 0x0016BD19
	private void RestoreCsmUpdateFrequency()
	{
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CSMMode3EnableUpdateIntervalOverride 0", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.PSO.IOSCompilationTimeLimit 2.0", null);
	}

	// Token: 0x06005B7C RID: 23420 RVA: 0x0016DB3B File Offset: 0x0016BD3B
	private void ReduceCsmUpdateFrequency()
	{
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CSMMode3EnableUpdateIntervalOverride 1", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CacheMode3CacheUpdateIntervalsOverride \"3000,3000,3000,3000,3000,3000\"", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.PSO.IOSCompilationTimeLimit 0.1", null);
	}

	// Token: 0x06005B7D RID: 23421 RVA: 0x0016DB70 File Offset: 0x0016BD70
	public void RefreshPerformanceLimit(string reason)
	{
		int num = 0;
		int num2 = 0;
		foreach (KeyValuePair<string, IPerformanceLimitConfig> keyValuePair in this.PerformanceLimitRunning)
		{
			if (keyValuePair.Value.FrameLimit)
			{
				num++;
			}
			if (keyValuePair.Value.CacheWorldFrame)
			{
				num2++;
			}
		}
		if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			if (num > 0)
			{
				this.SetFrameRateTemploary(30);
				this.ApplyFrameRate(this.FrameRateInternal);
			}
			else
			{
				this.CancelFrameRateTemploary();
				this.ApplyFrameRate(this.FrameRateInternal);
			}
		}
		if (num2 == 1)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.CacheSceneColor.Start", null);
			this.InCacheSceneColorMode = 1;
			return;
		}
		if (num2 == 0)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.CacheSceneColor.Stop", null);
			this.InCacheSceneColorMode = 0;
		}
	}

	// Token: 0x06005B7E RID: 23422 RVA: 0x0016DC54 File Offset: 0x0016BE54
	public void ApplyPerformanceLimit(string tag, bool cacheWorldFrame, bool frameLimit)
	{
		this.PerformanceLimitRunning[tag] = new PerformanceLimitConfig
		{
			FrameLimit = frameLimit,
			CacheWorldFrame = cacheWorldFrame
		};
		this.RefreshPerformanceLimit(tag);
	}

	// Token: 0x06005B7F RID: 23423 RVA: 0x0016DC7C File Offset: 0x0016BE7C
	public void CancelPerformanceLimit(string tag)
	{
		if (!this.PerformanceLimitRunning.Remove(tag))
		{
			return;
		}
		this.RefreshPerformanceLimit(tag);
	}

	// Token: 0x06005B80 RID: 23424 RVA: 0x0016DC94 File Offset: 0x0016BE94
	public void CancelAllPerformanceLimit()
	{
		this.PerformanceLimitRunning.Clear();
		this.CancelFrameRateTemploary();
		this.ApplyFrameRate(this.FrameRateInternal);
		this.RefreshPerformanceLimit("[CancelAll]");
	}

	// Token: 0x06005B81 RID: 23425 RVA: 0x0016DCBE File Offset: 0x0016BEBE
	public void SetIsAutoAdjustImageQuality(bool isAutoAdjustImageQuality)
	{
		if (isAutoAdjustImageQuality)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.AutoCoolUIEnable 1", null);
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.AutoCoolUIEnable 0", null);
	}

	// Token: 0x06005B82 RID: 23426 RVA: 0x0016DCE4 File Offset: 0x0016BEE4
	public EGameQualitySettingLevel? GetRecommendQualityLv()
	{
		int? recommendQualityLv = this.RecommendQualityLv;
		if (recommendQualityLv == null)
		{
			return null;
		}
		return new EGameQualitySettingLevel?((EGameQualitySettingLevel)recommendQualityLv.GetValueOrDefault());
	}

	// Token: 0x06005B83 RID: 23427 RVA: 0x0016DD17 File Offset: 0x0016BF17
	public EGameQualityRange GetQualityRange()
	{
		return this.QualityRange;
	}

	// Token: 0x06005B84 RID: 23428 RVA: 0x0016DD20 File Offset: 0x0016BF20
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetCPUInformation()
	{
		string text = this.CPUBrand.ToLower();
		bool flag = true;
		if (text.Contains("intel"))
		{
			Match match = Regex.Match(this.CPUBrand, "i([0-9])-([0-9]{4,5})", RegexOptions.IgnoreCase);
			if (match.Success && match.Groups.Count >= 3)
			{
				int num = int.Parse(match.Groups[1].Value);
				string value = match.Groups[2].Value;
				int num2;
				if (value.Length == 4)
				{
					num2 = int.Parse(value[0].ToString());
				}
				else
				{
					num2 = int.Parse(value.Substring(0, 2));
				}
				if (num < 5 || num2 < 9)
				{
					flag = false;
				}
			}
		}
		else if (text.Contains("amd"))
		{
			Match match2 = Regex.Match(this.CPUBrand, "ryzen\\s+[3579]\\s+([0-9]{4})", RegexOptions.IgnoreCase);
			if (match2.Success && match2.Groups.Count >= 2 && int.Parse(match2.Groups[1].Value) < 2700)
			{
				flag = false;
			}
		}
		return new ValueTuple<string, bool>(this.CPUBrand, !flag);
	}

	// Token: 0x06005B85 RID: 23429 RVA: 0x0016DE4C File Offset: 0x0016C04C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetGPUInformation()
	{
		string text = this.DeviceName.ToLower();
		bool flag = true;
		if (text.Contains("nvidia") || text.Contains("geforce"))
		{
			Match match = Regex.Match(this.DeviceName, "gtx\\s*(\\d{3,4})", RegexOptions.IgnoreCase);
			if (match.Success && match.Groups.Count >= 2 && int.Parse(match.Groups[1].Value) < 1060)
			{
				flag = false;
			}
		}
		else if (text.Contains("amd") || text.Contains("radeon"))
		{
			Match match2 = Regex.Match(this.DeviceName, "rx\\s*(\\d{3,4})", RegexOptions.IgnoreCase);
			if (match2.Success && match2.Groups.Count >= 2 && int.Parse(match2.Groups[1].Value) < 570)
			{
				flag = false;
			}
		}
		if (this.DeviceType == EGameDeviceType.PC_LOWEST)
		{
			flag = false;
		}
		return new ValueTuple<string, bool>(this.DeviceName, !flag);
	}

	// Token: 0x06005B86 RID: 23430 RVA: 0x0016DF4C File Offset: 0x0016C14C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetGraphicDriverVersion()
	{
		bool item = this.IsDriverNeedUpdate();
		return new ValueTuple<string, bool>(this.AdapterDriverVersion, item);
	}

	// Token: 0x06005B87 RID: 23431 RVA: 0x0016DF6C File Offset: 0x0016C16C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetGraphicAPI()
	{
		string item = this.RHIName;
		if (this.RHIName == "D3D11")
		{
			item = "DX11";
		}
		else if (this.RHIName == "D3D12")
		{
			item = "DX12";
		}
		bool flag = UKismetSystemLibrary.GetCommandLine().Contains("-dx11");
		bool item2 = this.RHIName == "D3D11" && !flag;
		return new ValueTuple<string, bool>(item, item2);
	}

	// Token: 0x06005B88 RID: 23432 RVA: 0x0016DFE4 File Offset: 0x0016C1E4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetMemoryInformation()
	{
		int num = (int)Math.Ceiling((double)this.DevicePhysicalGbRam / 4.0) * 4;
		bool flag = num >= 16;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral("GB");
		return new ValueTuple<string, bool>(defaultInterpolatedStringHandler.ToStringAndClear(), !flag);
	}

	// Token: 0x06005B89 RID: 23433 RVA: 0x0016E044 File Offset: 0x0016C244
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetVideoMemoryInformation()
	{
		if (this.DeviceVideoGbRam > 0)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.DeviceVideoGbRam);
			defaultInterpolatedStringHandler.AppendLiteral("GB");
			return new ValueTuple<string, bool>(defaultInterpolatedStringHandler.ToStringAndClear(), false);
		}
		return new ValueTuple<string, bool>("", false);
	}

	// Token: 0x06005B8A RID: 23434 RVA: 0x0016E098 File Offset: 0x0016C298
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetGameInstallPath()
	{
		string text = this.IsSSDDevice ? ConfigMultiTextLang.GetLocalTextNew("DeviceInfo_InstallPath_SSD", null) : ConfigMultiTextLang.GetLocalTextNew("DeviceInfo_InstallPath_HDD", null);
		return new ValueTuple<string, bool>(text ?? "", string.IsNullOrEmpty(text));
	}

	// Token: 0x06005B8B RID: 23435 RVA: 0x0016E0DB File Offset: 0x0016C2DB
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, bool> GetWindowsVersion()
	{
		return new ValueTuple<string, bool>(this.WindowsVersion, false);
	}

	// Token: 0x06005B8C RID: 23436 RVA: 0x0016E0EC File Offset: 0x0016C2EC
	public bool ShouldOverrideVegetationDitherDefaultValue()
	{
		return !(this.VendorName.ToLower() != "intel") && (this.DeviceName.Contains("A580") || this.DeviceName.Contains("A750") || this.DeviceName.Contains("A770"));
	}

	// Token: 0x06005B8D RID: 23437 RVA: 0x0016E148 File Offset: 0x0016C348
	public bool IsAutoExposureOn()
	{
		return UKismetSystemLibrary.GetConsoleVariableIntValue("r.Kuro.AutoExposure") == 1;
	}

	// Token: 0x06005B8E RID: 23438 RVA: 0x0016E157 File Offset: 0x0016C357
	public bool IsEnergySavingFrameInterpolationSupported()
	{
		return UKismetSystemLibrary.GetConsoleVariableIntValue("r.Mobile.EnergySavingFrameInterpolation") == 1;
	}

	// Token: 0x04002BB0 RID: 11184
	private const string KuroFITranslucentLightingModeCVar = "r.KuroFI.TranslucentLightingMode";

	// Token: 0x04002BB1 RID: 11185
	private const string KuroFIEnableSingleOcclusionBloomReplaceCVar = "r.KuroFI.EnableSingleOcclusionBloomReplace";

	// Token: 0x04002BB2 RID: 11186
	[Nullable(2)]
	private Dictionary<int, DeviceRenderFeature> DeviceRenderFeatureCfgMapInternal;

	// Token: 0x04002BB3 RID: 11187
	private int? RecommendQualityLvInternal;

	// Token: 0x04002BB4 RID: 11188
	private int DevicePhysicalGbRam;

	// Token: 0x04002BB5 RID: 11189
	public int DeviceVideoGbRam;

	// Token: 0x04002BB6 RID: 11190
	public int CPUFrequency;

	// Token: 0x04002BB7 RID: 11191
	public int CPUCores;

	// Token: 0x04002BB8 RID: 11192
	public int CPUCoresIncludingHyperthreads;

	// Token: 0x04002BB9 RID: 11193
	public string CPUBrand = "";

	// Token: 0x04002BBA RID: 11194
	public bool IsSupportedAFME;

	// Token: 0x04002BBB RID: 11195
	public string DriverDate = "Unknown";

	// Token: 0x04002BBC RID: 11196
	public string DriverVersion = "Unknown";

	// Token: 0x04002BBD RID: 11197
	public string AdapterDriverVersion = "Unknown";

	// Token: 0x04002BBE RID: 11198
	public string WindowsVersion = "Unknown";

	// Token: 0x04002BBF RID: 11199
	public bool IsSSDDevice;

	// Token: 0x04002BC0 RID: 11200
	public bool IsAdreno;

	// Token: 0x04002BC1 RID: 11201
	public bool IsXuanJie;

	// Token: 0x04002BC2 RID: 11202
	private string MobileDeviceModel = "";

	// Token: 0x04002BC3 RID: 11203
	private string MobileDeviceMake = "";

	// Token: 0x04002BC4 RID: 11204
	private string VendorName = "";

	// Token: 0x04002BC5 RID: 11205
	private string DeviceName = "";

	// Token: 0x04002BC6 RID: 11206
	private string BaseProfileName = "";

	// Token: 0x04002BC7 RID: 11207
	public int DeviceScore;

	// Token: 0x04002BC8 RID: 11208
	public int LowMemoryDeviceMark;

	// Token: 0x04002BC9 RID: 11209
	private bool IsBrokenGLPacingDevice;

	// Token: 0x04002BCA RID: 11210
	private string RHIName = "";

	// Token: 0x04002BCB RID: 11211
	private int HardwareLevel;

	// Token: 0x04002BCC RID: 11212
	public EGameDeviceType DeviceType = EGameDeviceType.PC_HIGH;

	// Token: 0x04002BCD RID: 11213
	private EGameQualityRange QualityRange = EGameQualityRange.One2Three;

	// Token: 0x04002BCE RID: 11214
	private bool EnableVolumeFog = true;

	// Token: 0x04002BCF RID: 11215
	private FIntPoint? DefaultResolution;

	// Token: 0x04002BD0 RID: 11216
	private TArray<FIntPoint> ResolutionListRef;

	// Token: 0x04002BD1 RID: 11217
	private int FrameRateTemploary;

	// Token: 0x04002BD2 RID: 11218
	private int FrameRateInternal;

	// Token: 0x04002BD3 RID: 11219
	private bool DLSSGEnable;

	// Token: 0x04002BD4 RID: 11220
	private int DLSSGMode;

	// Token: 0x04002BD5 RID: 11221
	private bool AFMEEnable;

	// Token: 0x04002BD6 RID: 11222
	private bool AFMERunning;

	// Token: 0x04002BD7 RID: 11223
	[Nullable(2)]
	private string ProfileNameCache;

	// Token: 0x04002BD8 RID: 11224
	private float FrameSecondsInternal;

	// Token: 0x04002BD9 RID: 11225
	private readonly HashSet<string> ReduceCsmReasonSet = new HashSet<string>();

	// Token: 0x04002BDA RID: 11226
	private int XessEnabled;

	// Token: 0x04002BDB RID: 11227
	private int XefgMode;

	// Token: 0x04002BDC RID: 11228
	private readonly Dictionary<string, int> XefgDisableTemporaryKeys = new Dictionary<string, int>();

	// Token: 0x04002BDD RID: 11229
	public Dictionary<string, IPerformanceLimitConfig> PerformanceLimitRunning = new Dictionary<string, IPerformanceLimitConfig>();

	// Token: 0x04002BDE RID: 11230
	public int InCacheSceneColorMode;

	// Token: 0x04002BDF RID: 11231
	private readonly Dictionary<EFunction, int> renderFeatureValueBuffer = new Dictionary<EFunction, int>();

	// Token: 0x04002BE0 RID: 11232
	private readonly Dictionary<string, int> DLSSGDisalbeTemporaryKeys = new Dictionary<string, int>();

	// Token: 0x04002BE1 RID: 11233
	private readonly Dictionary<string, int> AFMEDisalbeTemporaryKeys = new Dictionary<string, int>();
}
