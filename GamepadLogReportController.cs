using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200210A RID: 8458
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class GamepadLogReportController : UiControllerBase<GamepadLogReportController>
{
	// Token: 0x06010319 RID: 66329 RVA: 0x004742DC File Offset: 0x004724DC
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LocalStorageInitPlayerId, new Action(this.StartGamepadReportLog));
		Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerTypeChange));
	}

	// Token: 0x0601031A RID: 66330 RVA: 0x00474340 File Offset: 0x00472540
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LocalStorageInitPlayerId, new Action(this.StartGamepadReportLog));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerTypeChange));
	}

	// Token: 0x0601031B RID: 66331 RVA: 0x004743A4 File Offset: 0x004725A4
	protected override bool OnClear()
	{
		if (Singleton<Info>.Instance.IsInGamepad() && this.IsStart)
		{
			this.SettleActiveTime();
		}
		this.StopHeartbeat();
		this.IsStart = false;
		this.ActiveSuitName = "";
		this.LastOperateTime = 0.0;
		this.UsageMap = new Dictionary<string, GamepadTypeUsage>();
		return true;
	}

	// Token: 0x0601031C RID: 66332 RVA: 0x004743FE File Offset: 0x004725FE
	private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		if (!this.IsStart)
		{
			return;
		}
		if (last != EInputControllerMainType.Gamepad && now != EInputControllerMainType.Gamepad)
		{
			return;
		}
		if (now == EInputControllerMainType.Gamepad)
		{
			this.EnterGamepadModeLog();
			return;
		}
		if (last == EInputControllerMainType.Gamepad)
		{
			this.ExitGamepadModeLog();
		}
	}

	// Token: 0x0601031D RID: 66333 RVA: 0x00474428 File Offset: 0x00472628
	private void OnInputControllerTypeChange(EInputControllerType last, EInputControllerType now)
	{
		if (!this.IsStart)
		{
			return;
		}
		EInputControllerMainType einputControllerMainType;
		EInputControllerMainType einputControllerMainType2;
		if (!InfoDefine.InputControllerMainTypeMap.TryGetValue(last, out einputControllerMainType) || !InfoDefine.InputControllerMainTypeMap.TryGetValue(now, out einputControllerMainType2) || einputControllerMainType != EInputControllerMainType.Gamepad || einputControllerMainType2 != EInputControllerMainType.Gamepad)
		{
			return;
		}
		this.SettleActiveTime();
		this.EnterGamepadModeLog();
	}

	// Token: 0x0601031E RID: 66334 RVA: 0x00474471 File Offset: 0x00472671
	private void StartGamepadReportLog()
	{
		this.TryReportLog();
		this.InitGamepadLogReport();
	}

	// Token: 0x0601031F RID: 66335 RVA: 0x00474480 File Offset: 0x00472680
	private void TryReportLog()
	{
		Dictionary<string, GamepadTypeUsage> player = LocalStorage.GetPlayer<Dictionary<string, GamepadTypeUsage>>(ELocalStoragePlayerKey.GamepadUsageRecord, null);
		if (player == null)
		{
			return;
		}
		foreach (KeyValuePair<string, GamepadTypeUsage> keyValuePair in player)
		{
			string key = keyValuePair.Key;
			GamepadTypeUsage value = keyValuePair.Value;
			if (value.Count > 0 || value.Time > 0.0)
			{
				GamepadActiveEvent logData = new GamepadActiveEvent
				{
					i_gamepad_count = value.Count,
					i_gamepad_time = (float)Math.Floor(value.Time * Singleton<TimeUtil>.Instance.Millisecond),
					s_suit_name = key
				};
				ControllerBase<LogReportController>.Instance.LogReport(logData);
			}
		}
	}

	// Token: 0x06010320 RID: 66336 RVA: 0x0047454C File Offset: 0x0047274C
	private void InitGamepadLogReport()
	{
		this.IsStart = true;
		this.ActiveSuitName = "";
		this.UsageMap = new Dictionary<string, GamepadTypeUsage>();
		this.SaveUsage();
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.EnterGamepadModeLog();
		}
	}

	// Token: 0x06010321 RID: 66337 RVA: 0x00474584 File Offset: 0x00472784
	private void EnterGamepadModeLog()
	{
		string currentSuitName = this.GetCurrentSuitName();
		this.ActiveSuitName = currentSuitName;
		this.LastOperateTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		this.GetOrCreateUsage(currentSuitName).Count++;
		this.SaveUsage();
		this.StartHeartbeat();
	}

	// Token: 0x06010322 RID: 66338 RVA: 0x004745CF File Offset: 0x004727CF
	private void ExitGamepadModeLog()
	{
		this.SettleActiveTime();
		this.ActiveSuitName = "";
		this.StopHeartbeat();
	}

	// Token: 0x06010323 RID: 66339 RVA: 0x004745E8 File Offset: 0x004727E8
	private void SettleActiveTime()
	{
		if (string.IsNullOrEmpty(this.ActiveSuitName))
		{
			return;
		}
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		this.GetOrCreateUsage(this.ActiveSuitName).Time += (serverTimeStamp - this.LastOperateTime) * (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.LastOperateTime = serverTimeStamp;
		this.SaveUsage();
	}

	// Token: 0x06010324 RID: 66340 RVA: 0x00474647 File Offset: 0x00472847
	private void StartHeartbeat()
	{
		if (this.HeartbeatHandle != null)
		{
			return;
		}
		this.HeartbeatHandle = TimerSystem.RealTimeInstance.Forever(delegate(float _)
		{
			this.SettleActiveTime();
		}, 60000f, 1f, null, "GamepadUsageHeartbeat", true);
	}

	// Token: 0x06010325 RID: 66341 RVA: 0x0047467F File Offset: 0x0047287F
	private void StopHeartbeat()
	{
		if (this.HeartbeatHandle == null)
		{
			return;
		}
		TimerSystem.RealTimeInstance.Remove(this.HeartbeatHandle);
		this.HeartbeatHandle = null;
	}

	// Token: 0x06010326 RID: 66342 RVA: 0x004746A4 File Offset: 0x004728A4
	private GamepadTypeUsage GetOrCreateUsage(string suitName)
	{
		GamepadTypeUsage gamepadTypeUsage;
		if (!this.UsageMap.TryGetValue(suitName, out gamepadTypeUsage))
		{
			gamepadTypeUsage = new GamepadTypeUsage();
			this.UsageMap[suitName] = gamepadTypeUsage;
		}
		return gamepadTypeUsage;
	}

	// Token: 0x06010327 RID: 66343 RVA: 0x004746D8 File Offset: 0x004728D8
	private void SaveUsage()
	{
		LocalStorage.SetPlayer<Dictionary<string, GamepadTypeUsage>>(ELocalStoragePlayerKey.GamepadUsageRecord, this.UsageMap);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.LogReport;
		ELogAuthor author = ELogAuthor.SYB;
		string message = "手柄埋点记录";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("UsageMap", this.UsageMap);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06010328 RID: 66344 RVA: 0x00474724 File Offset: 0x00472924
	private string GetCurrentSuitName()
	{
		string currentActiveGamepadName = UKismetSystemLibrary.GetCurrentActiveGamepadName();
		if (string.IsNullOrEmpty(currentActiveGamepadName) || !(currentActiveGamepadName != "None"))
		{
			return "Unknown";
		}
		return currentActiveGamepadName;
	}

	// Token: 0x04007C5A RID: 31834
	private const float HEARTBEAT_INTERVAL = 60000f;

	// Token: 0x04007C5B RID: 31835
	private bool IsStart;

	// Token: 0x04007C5C RID: 31836
	private string ActiveSuitName = "";

	// Token: 0x04007C5D RID: 31837
	private double LastOperateTime;

	// Token: 0x04007C5E RID: 31838
	private Dictionary<string, GamepadTypeUsage> UsageMap = new Dictionary<string, GamepadTypeUsage>();

	// Token: 0x04007C5F RID: 31839
	[Nullable(2)]
	private TimerHandle HeartbeatHandle;
}
