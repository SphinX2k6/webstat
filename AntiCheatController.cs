using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001797 RID: 6039
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AntiCheatController : UiControllerBase<AntiCheatController>
{
	// Token: 0x0600AA8D RID: 43661 RVA: 0x002D8EDD File Offset: 0x002D70DD
	protected override bool OnInit()
	{
		this.DataUndefinedError = false;
		return true;
	}

	// Token: 0x0600AA8E RID: 43662 RVA: 0x002D8EE7 File Offset: 0x002D70E7
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ChangePlayerInfoId, new Action<int>(this.OnChangePlayerInfoId));
		Singleton<EventSystem>.Instance.Add(EEventName.SendHeartbeat, new Action(this.CheckHeartbeat));
	}

	// Token: 0x0600AA8F RID: 43663 RVA: 0x002D8F1E File Offset: 0x002D711E
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangePlayerInfoId, new Action<int>(this.OnChangePlayerInfoId));
		Singleton<EventSystem>.Instance.Remove(EEventName.SendHeartbeat, new Action(this.CheckHeartbeat));
	}

	// Token: 0x0600AA90 RID: 43664 RVA: 0x002D8F58 File Offset: 0x002D7158
	private void OnChangePlayerInfoId(int id)
	{
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		Singleton<ThirdPartySdkManager>.Instance.SetUserInfoForTpSafe(value.ToString(), value);
		this.ReportIOSBundleInfo();
	}

	// Token: 0x0600AA91 RID: 43665 RVA: 0x002D8F90 File Offset: 0x002D7190
	private void ReportIOSBundleInfo()
	{
		if (Singleton<Info>.Instance.IsIosPlatform())
		{
			AntiCheatBundleData bundleData = AntiCheatModel.GetBundleData();
			ControllerBase<LogReportController>.Instance.LogReport(bundleData);
		}
	}

	// Token: 0x0600AA92 RID: 43666 RVA: 0x002D8FBC File Offset: 0x002D71BC
	private void CheckHeartbeat()
	{
		Number number = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if ((number - this.LastHeartbeatReportTime) * 0.001f >= this.HEARTBEAT_REPORT_INTERVAL)
		{
			if (ModelBase<AntiCheatModel>.Instance.HasHeartbeatException())
			{
				AntiCheatHeartbeatData heartbeatData = ModelBase<AntiCheatModel>.Instance.GetHeartbeatData();
				if (heartbeatData != null)
				{
					ControllerBase<LogReportController>.Instance.LogReport(heartbeatData);
				}
				else if (!this.DataUndefinedError && ControllerBase<KuroSdkController>.Instance.CanUseSdk())
				{
					SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
					string text = (sdkLoginConfig != null) ? sdkLoginConfig.Uid : null;
					if (text != null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Temp;
						ELogAuthor author = ELogAuthor.LRA;
						string message = "Data undefined";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", text);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						this.DataUndefinedError = true;
					}
				}
				ModelBase<AntiCheatModel>.Instance.ResetHeartbeatException();
			}
			this.LastHeartbeatReportTime = number;
		}
		Number a = number - this.LastHeartbeatTime;
		int heartbeatInterval = Singleton<Heartbeat>.Instance.GetHeartbeatInterval();
		Number b = 0.5f * (float)heartbeatInterval;
		if (this.LastHeartbeatTime > 0 && a <= b)
		{
			ModelBase<AntiCheatModel>.Instance.HitHeartbeatException();
		}
		this.LastHeartbeatTime = number;
	}

	// Token: 0x04005020 RID: 20512
	private const float HEARTBEAT_EXCEPTION_FACTOR = 0.5f;

	// Token: 0x04005021 RID: 20513
	private Number HEARTBEAT_REPORT_INTERVAL = Singleton<TimeUtil>.Instance.Hour;

	// Token: 0x04005022 RID: 20514
	private Number LastHeartbeatTime = 0;

	// Token: 0x04005023 RID: 20515
	private Number LastHeartbeatReportTime = 0;

	// Token: 0x04005024 RID: 20516
	private bool DataUndefinedError;
}
