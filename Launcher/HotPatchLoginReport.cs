using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.ThinkDataReport;
using CSharpScript.Launcher.Util;

namespace CSharpScript.Launcher
{
	// Token: 0x02004494 RID: 17556
	[NullableContext(1)]
	[Nullable(0)]
	public class HotPatchLoginReport
	{
		// Token: 0x0602E50B RID: 189707 RVA: 0x00ADED80 File Offset: 0x00ADCF80
		public static void HotPatchLogAppendDefaultData(HotPatchLog data)
		{
			data.s_version = Singleton<HotPatchLogReport>.Instance.Version;
			data.client_platform = Singleton<HotPatchLogReport>.Instance.Platform;
			data.s_client_version = Singleton<ThinkDataLaunchReporter>.Instance.ClientVersion;
			data.device_id = Singleton<HotPatchLogReport>.Instance.DeviceId;
		}

		// Token: 0x0602E50C RID: 189708 RVA: 0x00ADEDD0 File Offset: 0x00ADCFD0
		[NullableContext(2)]
		[return: Nullable(1)]
		public static HotPatchLog CreateHotPatchLog([Nullable(1)] string eventId, [Nullable(1)] string s_step_result, string s_step_id = null, string uniqueId = null, string playerId = null, string s_url_prefix = null)
		{
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.event_id = eventId;
			hotPatchLog.s_step_result = s_step_result;
			hotPatchLog.s_url_prefix = s_url_prefix;
			hotPatchLog.s_step_id = (s_step_id ?? eventId);
			hotPatchLog.unique_id = (uniqueId ?? "");
			hotPatchLog.player_id = (playerId ?? "");
			HotPatchLoginReport.HotPatchLogAppendDefaultData(hotPatchLog);
			return hotPatchLog;
		}

		// Token: 0x0602E50D RID: 189709 RVA: 0x00ADEE2C File Offset: 0x00ADD02C
		public static Dictionary<string, string> GetDataMapFormHotPatchLog(HotPatchLog log)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary["event_id"] = log.event_id;
			dictionary["s_version"] = (log.s_version ?? "");
			dictionary["s_step_result"] = (log.s_step_result ?? "");
			dictionary["client_platform"] = (log.client_platform ?? "");
			dictionary["s_client_version"] = (log.s_client_version ?? "");
			dictionary["s_url_prefix"] = (log.s_url_prefix ?? "");
			dictionary["s_step_id"] = (log.s_step_id ?? "");
			dictionary["device_id"] = (log.device_id ?? "");
			dictionary["unique_id"] = (log.unique_id ?? "");
			dictionary["player_id"] = (log.player_id ?? "");
			return dictionary;
		}

		// Token: 0x0602E50E RID: 189710 RVA: 0x00ADEF39 File Offset: 0x00ADD139
		public static void Report(HotPatchLog data)
		{
			LauncherSdk.Get().ReportChannelEvent(data);
		}

		// Token: 0x0602E50F RID: 189711 RVA: 0x00ADEF48 File Offset: 0x00ADD148
		public static void ReportGameLoadComplete(HotPatchLog data)
		{
			if (Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<int>(ELauncherStorageDeviceKey.GameLoadCompleteFlag, 0) != 0)
			{
				LauncherSdk.Get().ReportChannelEvent(data);
				return;
			}
			SdkGameLoadComplete sdkReportData = new SdkGameLoadComplete(HotPatchLoginReport.GetDataMapFormHotPatchLog(data));
			LauncherSdk.Get().AdditionReportForSdk(data, sdkReportData);
			Singleton<LauncherStorageLib>.Instance.SetDeviceSaved<int>(ELauncherStorageDeviceKey.GameLoadCompleteFlag, 1);
		}
	}
}
