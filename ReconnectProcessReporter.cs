using System;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Launcher.BaseConfig;
using UnrealEngine;

// Token: 0x02002753 RID: 10067
public static class ReconnectProcessReporter
{
	// Token: 0x06013DED RID: 81389 RVA: 0x00589820 File Offset: 0x00587A20
	public static void ReportReconnectProcess(EReconnectProcessStep reconvStep, ErrorCode code = ErrorCode.Success)
	{
		SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
		ReconvProcessLink reconvProcessLink = new ReconvProcessLink();
		reconvProcessLink.s_trace_id = ModelBase<ReConnectModel>.Instance.ReconvTraceId;
		int? num;
		reconvProcessLink.s_player_id = (((ModelBase<PlayerInfoModel>.Instance.GetId() != null) ? num.GetValueOrDefault().ToString() : null) ?? "0");
		reconvProcessLink.s_user_id = (((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) ?? "");
		reconvProcessLink.s_user_name = (((sdkLoginConfig != null) ? sdkLoginConfig.UserName : null) ?? ModelBase<LoginModel>.Instance.GetAccount());
		reconvProcessLink.s_reconv_step = reconvStep.ToString();
		reconvProcessLink.s_app_version = UKuroLauncherLibrary.GetAppVersion();
		reconvProcessLink.s_launcher_version = LocalStorage.GetDeviceSaved<string>(ELocalStorageDeviceKey.LauncherPatchVersion, reconvProcessLink.s_app_version);
		reconvProcessLink.s_resource_version = LocalStorage.GetDeviceSaved<string>(ELocalStorageDeviceKey.PatchVersion, reconvProcessLink.s_app_version);
		reconvProcessLink.s_client_version = Singleton<BaseConfigController>.Instance.GetVersionString();
		reconvProcessLink.i_error_code = (int)code;
		ControllerBase<LogReportController>.Instance.LogReport(reconvProcessLink);
	}
}
