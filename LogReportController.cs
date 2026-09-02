using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x0200210C RID: 8460
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LogReportController : UiControllerBase<LogReportController>
{
	// Token: 0x0601032D RID: 66349 RVA: 0x004747D4 File Offset: 0x004729D4
	protected override bool OnInit()
	{
		this.ClientVersion = Singleton<BaseConfigController>.Instance.GetVersionString();
		int? intConfig = ConfigCommonParamById.GetIntConfig("LogReportTimeCheckPeriod");
		if (intConfig != null)
		{
			int? num = intConfig;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				this.LogReportTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.CheckLogReport), (float)(intConfig.Value * Singleton<TimeUtil>.Instance.InverseMillisecond), 1f, null, null, false);
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601032E RID: 66350 RVA: 0x00474857 File Offset: 0x00472A57
	protected override bool OnClear()
	{
		if (this.LogReportTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.LogReportTimer);
			this.LogReportTimer = null;
		}
		return true;
	}

	// Token: 0x0601032F RID: 66351 RVA: 0x0047487C File Offset: 0x00472A7C
	public void LogReport(CommonLogData logData)
	{
		if (logData.event_id == "")
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LogReport;
			ELogAuthor author = ELogAuthor.MZJ;
			string message = "event_id 不能为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("logData", logData);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.SetLogDataInfo(logData);
		Singleton<ThinkingAnalyticsReporter>.Instance.Report("c" + logData.event_id, Json.Stringify<CommonLogData>(logData, null) ?? "");
	}

	// Token: 0x06010330 RID: 66352 RVA: 0x004748F8 File Offset: 0x00472AF8
	public void UnitLogReport(IUnitLogData logData)
	{
		AssemblyLogData timerAssemblyLogData = ModelBase<LogReportModel>.Instance.GetTimerAssemblyLogData(logData.event_id);
		if (timerAssemblyLogData != null)
		{
			timerAssemblyLogData.SetLogDataToAssembly(logData);
		}
	}

	// Token: 0x06010331 RID: 66353 RVA: 0x00474920 File Offset: 0x00472B20
	private void SetLogDataInfo(CommonLogData logData)
	{
		logData.client_version = this.ClientVersion;
		logData.platform = ModelBase<LoginModel>.Instance.Platform;
		PlayerCommonLogData playerCommonLogData = logData as PlayerCommonLogData;
		if (playerCommonLogData != null)
		{
			PlayerCommonLogData playerCommonLogData2 = playerCommonLogData;
			int? num = ModelBase<PlayerInfoModel>.Instance.GetId();
			playerCommonLogData2.player_id = (((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "0");
			playerCommonLogData.client_platform = KuroApplication.IniPlatformName();
			if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
			{
				playerCommonLogData.device_id = UKuroSDKManager.GetBasicInfo().DeviceId;
			}
			playerCommonLogData.net_status = ModelBase<PlatformModel>.Instance.GetNetStatus().ToString();
			playerCommonLogData.world_level = (ModelBase<WorldLevelModel>.Instance.CurWorldLevel.ToString() ?? "0");
			PlayerCommonLogData playerCommonLogData3 = playerCommonLogData;
			num = ModelBase<FunctionModel>.Instance.GetPlayerLevel();
			playerCommonLogData3.player_level = (((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "0");
			playerCommonLogData.world_own_id = (ModelBase<GameModeModel>.Instance.IsMulti ? ModelBase<CreatureModel>.Instance.GetWorldOwner().ToString() : "0");
		}
	}

	// Token: 0x06010332 RID: 66354 RVA: 0x00474A54 File Offset: 0x00472C54
	private void CheckLogReport(float delta)
	{
		IEnumerable<AssemblyLogData> allTimerAssemblyLogData = ModelBase<LogReportModel>.Instance.GetAllTimerAssemblyLogData();
		List<string> list = new List<string>();
		foreach (AssemblyLogData assemblyLogData in allTimerAssemblyLogData)
		{
			if (assemblyLogData.SendTimePeriod != 0)
			{
				assemblyLogData.SendTimeAccumulate += (double)delta;
				if (assemblyLogData.SendTimeAccumulate >= (double)assemblyLogData.SendTimePeriod)
				{
					assemblyLogData.SendTimeAccumulate = 0.0;
					if (assemblyLogData.CheckIsSend())
					{
						list.Add(assemblyLogData.AssemblyId);
						CommonLogData assemblyLogInfo = assemblyLogData.AssemblyLogInfo;
						this.SetLogDataInfo(assemblyLogInfo);
						Singleton<ThinkingAnalyticsReporter>.Instance.Report("c" + assemblyLogInfo.event_id, Json.Stringify<CommonLogData>(assemblyLogInfo, null) ?? "");
						assemblyLogData.AfterSend();
					}
				}
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.LogReport;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "已发送集合日志Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AssemblyIdList", list);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x04007C60 RID: 31840
	private string ClientVersion = "";

	// Token: 0x04007C61 RID: 31841
	[Nullable(2)]
	private TimerHandle LogReportTimer;
}
