using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.ThinkDataReport;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Launcher
{
	// Token: 0x02004493 RID: 17555
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HotPatchLogReport : Singleton<HotPatchLogReport>
	{
		// Token: 0x17007FBC RID: 32700
		// (get) Token: 0x0602E4FA RID: 189690 RVA: 0x00ADE54F File Offset: 0x00ADC74F
		// (set) Token: 0x0602E4F9 RID: 189689 RVA: 0x00ADE484 File Offset: 0x00ADC684
		[Nullable(2)]
		public UWorld World
		{
			[NullableContext(2)]
			get
			{
				return this.WorldInternal;
			}
			[NullableContext(2)]
			set
			{
				this.WorldInternal = value;
				if (value != null)
				{
					UKuroPlayerPrefsSystem ukuroPlayerPrefsSystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(value, UKuroPlayerPrefsSystem.StaticClass()) as UKuroPlayerPrefsSystem;
					if (ukuroPlayerPrefsSystem != null && ukuroPlayerPrefsSystem.IsValid())
					{
						string @string = ukuroPlayerPrefsSystem.GetString("LoginDeviceId", UKismetGuidLibrary.NewGuid().ToString());
						ukuroPlayerPrefsSystem.SetString("LoginDeviceId", @string);
						this.DeviceIdInternal = @string;
						LauncherLog instance = Singleton<LauncherLog>.Instance;
						string message = "launcher login device id";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", @string);
						instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						ukuroPlayerPrefsSystem.Save();
					}
					this.VersionInternal = UKuroLauncherLibrary.GetAppVersion() + "(" + Singleton<BaseConfigController>.Instance.GetPackageConfigOrDefault(TBuildInfoKey.Changelist, "") + ")";
					this.PlatformInternal = KuroApplication.IniPlatformName();
				}
			}
		}

		// Token: 0x17007FBD RID: 32701
		// (get) Token: 0x0602E4FB RID: 189691 RVA: 0x00ADE557 File Offset: 0x00ADC757
		public string DeviceId
		{
			get
			{
				return this.DeviceIdInternal ?? "";
			}
		}

		// Token: 0x17007FBE RID: 32702
		// (get) Token: 0x0602E4FC RID: 189692 RVA: 0x00ADE568 File Offset: 0x00ADC768
		public string Platform
		{
			get
			{
				return this.PlatformInternal ?? "";
			}
		}

		// Token: 0x17007FBF RID: 32703
		// (get) Token: 0x0602E4FD RID: 189693 RVA: 0x00ADE579 File Offset: 0x00ADC779
		public string Version
		{
			get
			{
				return this.VersionInternal ?? "";
			}
		}

		// Token: 0x0602E4FE RID: 189694 RVA: 0x00ADE58A File Offset: 0x00ADC78A
		public void Init()
		{
		}

		// Token: 0x0602E4FF RID: 189695 RVA: 0x00ADE58C File Offset: 0x00ADC78C
		private string GetReportNetStatus()
		{
			if (this.PlatformInternal == "Android" || this.PlatformInternal == "IOS" || this.PlatformInternal == "OpenHarmony")
			{
				ENetworkType networkConnectionType = (ENetworkType)UKuroLauncherLibrary.GetNetworkConnectionType();
				if (networkConnectionType == ENetworkType.WiFi)
				{
					return "Wifi";
				}
				if (networkConnectionType == ENetworkType.Cell)
				{
					return "Stream";
				}
				return "Other";
			}
			else
			{
				if (this.PlatformInternal == "Windows" || this.PlatformInternal == "Mac" || this.PlatformInternal == "Linux")
				{
					return "Wired";
				}
				return "Other";
			}
		}

		// Token: 0x0602E500 RID: 189696 RVA: 0x00ADE630 File Offset: 0x00ADC830
		[NullableContext(2)]
		public void Report(HotPatchLog data)
		{
			if (data == null)
			{
				return;
			}
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			data.device_id = this.DeviceIdInternal;
			data.event_time = num.ToString();
			data.l_trigger_time = new long?(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
			data.s_version = (this.VersionInternal ?? "");
			data.net_status = this.GetReportNetStatus();
			data.client_platform = (this.PlatformInternal ?? "");
			if (Singleton<HotPatchKuroSdk>.Instance.CanUseSdk())
			{
				data.s_device_id = UKuroSDKManager.GetBasicInfo().DeviceId;
				if (!this.IsSet)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "launcher sdk device id";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", data.s_device_id);
					instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.IsSet = true;
				}
			}
			data.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + data.event_id, LauncherJson.Stringify<HotPatchLog>(data, null));
		}

		// Token: 0x0602E501 RID: 189697 RVA: 0x00ADE73C File Offset: 0x00ADC93C
		public void Report(HotPatchLog data)
		{
			if (data == null)
			{
				return;
			}
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			data.device_id = this.DeviceIdInternal;
			data.event_time = num.ToString();
			data.l_trigger_time = new long?(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
			data.s_version = (this.VersionInternal ?? "");
			data.net_status = this.GetReportNetStatus();
			data.client_platform = (this.PlatformInternal ?? "");
			if (Singleton<HotPatchKuroSdk>.Instance.CanUseSdk())
			{
				data.s_device_id = UKuroSDKManager.GetBasicInfo().DeviceId;
				if (!this.IsSet)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "launcher sdk device id";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", data.s_device_id);
					instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.IsSet = true;
				}
			}
			data.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + data.event_id, LauncherJson.Stringify<HotPatchLog>(data, null));
		}

		// Token: 0x0602E502 RID: 189698 RVA: 0x00ADE848 File Offset: 0x00ADCA48
		public void Report(PakKeyLog data)
		{
			if (data == null)
			{
				return;
			}
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			data.device_id = (this.DeviceIdInternal ?? "");
			data.event_time = num.ToString();
			data.l_trigger_time = new long?(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
			data.s_version = (this.VersionInternal ?? "");
			data.net_status = this.GetReportNetStatus();
			data.client_platform = (this.PlatformInternal ?? "");
			data.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + data.event_id, LauncherJson.Stringify<PakKeyLog>(data, null));
		}

		// Token: 0x0602E503 RID: 189699 RVA: 0x00ADE908 File Offset: 0x00ADCB08
		public void ReportLogin(int stepId, string stepResult)
		{
			LoginLogEvent loginLogEvent = new LoginLogEvent();
			loginLogEvent.i_step_id = stepId.ToString();
			loginLogEvent.s_step_result = stepResult;
			if (this.WorldInternal != null)
			{
				loginLogEvent.f_time = UGameplayStatics.GetTimeSeconds(this.WorldInternal).ToString();
			}
			loginLogEvent.event_time = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
			loginLogEvent.device_id = this.DeviceIdInternal;
			loginLogEvent.s_tag = this.UniqueId;
			loginLogEvent.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + loginLogEvent.event_id, LauncherJson.Stringify<LoginLogEvent>(loginLogEvent, null));
		}

		// Token: 0x0602E504 RID: 189700 RVA: 0x00ADE9B4 File Offset: 0x00ADCBB4
		public void ReportAppLinksEvent(string deepvalue, string source)
		{
			AppLinksLog appLinksLog = new AppLinksLog();
			appLinksLog.s_step_id = "launch_by_deeplink";
			appLinksLog.s_deepvalue = deepvalue;
			appLinksLog.s_source = source;
			appLinksLog.event_time = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
			appLinksLog.device_id = this.DeviceIdInternal;
			appLinksLog.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			appLinksLog.client_platform = (this.PlatformInternal ?? "");
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + appLinksLog.event_id, LauncherJson.Stringify<AppLinksLog>(appLinksLog, null));
		}

		// Token: 0x0602E505 RID: 189701 RVA: 0x00ADEA4D File Offset: 0x00ADCC4D
		public void ReportHotPatchLog(HotPatchLogData data)
		{
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + data.event_id, LauncherJson.Stringify<HotPatchLogData>(data, null));
		}

		// Token: 0x0602E506 RID: 189702 RVA: 0x00ADEA70 File Offset: 0x00ADCC70
		public void ReportNetworkDetection(LauncherNetworkDetectionBaseLog logData)
		{
			logData.device_id = (this.DeviceIdInternal ?? "");
			logData.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			logData.client_platform = (this.PlatformInternal ?? "");
			logData.event_time = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + logData.event_id, LauncherJson.Stringify<LauncherNetworkDetectionBaseLog>(logData, null) ?? "");
		}

		// Token: 0x0602E507 RID: 189703 RVA: 0x00ADEAFC File Offset: 0x00ADCCFC
		public void ReportVersionFirstDownloadType(bool typeIsAdd, int diffSpace, int allSpace, int needSpace)
		{
			LauncherVersionFirstDownloadTypeLog launcherVersionFirstDownloadTypeLog = new LauncherVersionFirstDownloadTypeLog();
			launcherVersionFirstDownloadTypeLog.i_download_type = (typeIsAdd ? 2 : 1);
			launcherVersionFirstDownloadTypeLog.i_required_space_add = diffSpace;
			launcherVersionFirstDownloadTypeLog.i_required_space_all = allSpace;
			launcherVersionFirstDownloadTypeLog.i_required_space = needSpace;
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + launcherVersionFirstDownloadTypeLog.event_id, LauncherJson.Stringify<LauncherVersionFirstDownloadTypeLog>(launcherVersionFirstDownloadTypeLog, null));
		}

		// Token: 0x0602E508 RID: 189704 RVA: 0x00ADEB54 File Offset: 0x00ADCD54
		public void ReportLoginProcessLink(string traceId, string userId, string userName, string loginStep, int errorCode)
		{
			LoginProcessLink loginProcessLink = new LoginProcessLink();
			loginProcessLink.s_trace_id = traceId;
			loginProcessLink.s_user_id = userId;
			loginProcessLink.s_user_name = userName;
			loginProcessLink.s_app_version = UKuroLauncherLibrary.GetAppVersion();
			loginProcessLink.s_launcher_version = (Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.LauncherPatchVersion, "") ?? "");
			loginProcessLink.s_resource_version = (Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.PatchVersion, "") ?? "");
			loginProcessLink.s_client_version = Singleton<BaseConfigController>.Instance.GetVersionString();
			loginProcessLink.i_error_code = errorCode;
			loginProcessLink.s_cpu_info = UKuroStaticLibrary.GetDeviceCPU();
			loginProcessLink.s_device_info = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDeviceName();
			loginProcessLink.s_driver_date = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDriverDate();
			if (Singleton<HotPatchKuroSdk>.Instance.CanUseSdk())
			{
				loginProcessLink.s_device_id = UKuroSDKManager.GetBasicInfo().DeviceId;
			}
			loginProcessLink.s_command_line = KuroApplication.GetCommandLine();
			loginProcessLink.s_login_step = loginStep;
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + loginProcessLink.event_id, LauncherJson.Stringify<LoginProcessLink>(loginProcessLink, null));
		}

		// Token: 0x0602E509 RID: 189705 RVA: 0x00ADEC50 File Offset: 0x00ADCE50
		[NullableContext(2)]
		public unsafe void ReportKeyListConfig(PakKeyLog data, long timeOffset)
		{
			if (data == null)
			{
				return;
			}
			long num = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			data.device_id = (this.DeviceId ?? "");
			data.event_time = ((num + timeOffset) / 1000L).ToString();
			data.l_trigger_time = new long?(num + timeOffset);
			data.s_version = this.Version;
			data.net_status = this.GetReportNetStatus();
			data.client_platform = this.Platform;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "ReportKeyListConfig";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("device_id", data.device_id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("event_time", data.event_time);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("timeOffset", timeOffset);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			data.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			Singleton<ThinkDataLaunchReporter>.Instance.Report("c" + data.event_id, LauncherJson.Stringify<PakKeyLog>(data, null));
		}

		// Token: 0x0401A4C8 RID: 107720
		[Nullable(2)]
		private readonly string UniqueId;

		// Token: 0x0401A4C9 RID: 107721
		[Nullable(2)]
		private string DeviceIdInternal;

		// Token: 0x0401A4CA RID: 107722
		[Nullable(2)]
		private string VersionInternal;

		// Token: 0x0401A4CB RID: 107723
		[Nullable(2)]
		private string PlatformInternal;

		// Token: 0x0401A4CC RID: 107724
		[Nullable(2)]
		private UWorld WorldInternal;

		// Token: 0x0401A4CD RID: 107725
		private bool IsSet;
	}
}
