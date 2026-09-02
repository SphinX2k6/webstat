using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BB4 RID: 11188
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class TimeOfDayController : UiControllerBase<TimeOfDayController>
{
	// Token: 0x06016473 RID: 91251 RVA: 0x0062BB74 File Offset: 0x00629D74
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.EnterGameSuccess, new Action(this.OnEnterGame));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.LoginSuccess, new Action<string>(this.OnLoginSuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x06016474 RID: 91252 RVA: 0x0062BC08 File Offset: 0x00629E08
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.EnterGameSuccess, new Action(this.OnEnterGame));
		Singleton<EventSystem>.Instance.Remove(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Remove(EEventName.LoginSuccess, new Action<string>(this.OnLoginSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x06016475 RID: 91253 RVA: 0x0062BC9C File Offset: 0x00629E9C
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<SceneDateNotify>(ENotifyMessageId.SceneDateNotify, new Action<SceneDateNotify, Net.CallbackStatus>(this.OnSceneDateNotify));
		Singleton<Net>.Instance.Register<SyncSceneTimeNotify>(ENotifyMessageId.SyncSceneTimeNotify, new Action<SyncSceneTimeNotify, Net.CallbackStatus>(this.SyncSceneTimeNotify));
		Singleton<Net>.Instance.Register<TimeLockInfoNotify>(ENotifyMessageId.TimeLockInfoNotify, new Action<TimeLockInfoNotify, Net.CallbackStatus>(this.OnServerTimeLock));
		Singleton<Net>.Instance.Register<TimeResetNotify>(ENotifyMessageId.TimeResetNotify, new Action<TimeResetNotify, Net.CallbackStatus>(this.OnTimeResetNotify));
	}

	// Token: 0x06016476 RID: 91254 RVA: 0x0062BD1C File Offset: 0x00629F1C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SceneDateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SyncSceneTimeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TimeLockInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TimeResetNotify);
	}

	// Token: 0x06016477 RID: 91255 RVA: 0x0062BD6C File Offset: 0x00629F6C
	protected override void OnTick(float delta)
	{
		if (!this.TimeInitState || !this.EnterGameFlag || this.LoadingFlag || this.UiAnimFlag || ModelBase<TimeOfDayModel>.Instance.TimeRunLockState)
		{
			return;
		}
		this.TickDelta += (double)delta;
		this.TimeFlow(this.TickDelta);
		this.TickDelta = 0.0;
	}

	// Token: 0x06016478 RID: 91256 RVA: 0x0062BDD0 File Offset: 0x00629FD0
	private void OnEnterGame()
	{
		this.EnterGameFlag = true;
	}

	// Token: 0x06016479 RID: 91257 RVA: 0x0062BDD9 File Offset: 0x00629FD9
	private void OnBeforeLoadMap()
	{
		this.LoadingFlag = true;
	}

	// Token: 0x0601647A RID: 91258 RVA: 0x0062BDE2 File Offset: 0x00629FE2
	private void OnWorldDoneAndCloseLoading()
	{
		this.LoadingFlag = false;
		this.SyncGlobalGameTime(ModelBase<TimeOfDayModel>.Instance.GameTime.Second, false);
	}

	// Token: 0x0601647B RID: 91259 RVA: 0x0062BE01 File Offset: 0x0062A001
	private void OnPauseGame(int flag)
	{
		if (flag == 1)
		{
			this.PauseTime();
			return;
		}
		if (flag == 0)
		{
			this.ResumeTimeScale(true);
		}
	}

	// Token: 0x0601647C RID: 91260 RVA: 0x0062BE18 File Offset: 0x0062A018
	private void OnLoginSuccess(string account)
	{
		ModelBase<TimeOfDayModel>.Instance.PlayerAccount = account;
	}

	// Token: 0x0601647D RID: 91261 RVA: 0x0062BE28 File Offset: 0x0062A028
	private void TimeFlow(double realTimeMillionSecond)
	{
		float num = ModelBase<GameModeModel>.Instance.IsMulti ? 1f : ModelBase<TimeOfDayModel>.Instance.TimeScale;
		double num2 = TodDayTime.ConvertFromRealTimeSecond(realTimeMillionSecond / 1000.0 * (double)num);
		if (num2 <= 0.0)
		{
			return;
		}
		this.SetTimeInternal(ModelBase<TimeOfDayModel>.Instance.GameTime.Second + num2, true);
	}

	// Token: 0x0601647E RID: 91262 RVA: 0x0062BE8C File Offset: 0x0062A08C
	private bool CheckCanOpenView()
	{
		if (Global.BaseCharacter == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.YZY, "时间找不到角色", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance() && !ModelBase<RecallQuestModel>.Instance.IsInRecallInstance())
		{
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.YZY, "时间在副本", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.YZY, "时间在联机", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		foreach (FGameplayTag tag in ConfigBase<TimeOfDayConfig>.Instance.GetBanGameplayTags())
		{
			CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
			bool flag;
			if (characterActorComponent == null)
			{
				flag = false;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				bool? flag2;
				if (entity == null)
				{
					flag2 = null;
				}
				else
				{
					BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
					flag2 = ((component != null) ? new bool?(component.HasTag(tag.TagId())) : null);
				}
				bool? flag3 = flag2;
				flag = flag3.GetValueOrDefault();
			}
			if (flag)
			{
				Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.YZY, "时间在BanTag", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		if (ModelBase<TimeOfDayModel>.Instance.TimeRunLockState)
		{
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.FZX, "时间被锁定", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return true;
	}

	// Token: 0x0601647F RID: 91263 RVA: 0x0062C008 File Offset: 0x0062A208
	private void SetTimeInternal(double second, bool needCheckSendTimeToServer = true)
	{
		double second2 = second % 86400.0;
		ModelBase<TimeOfDayModel>.Instance.GameTime.Second = second2;
		this.SyncGlobalGameTime(second2, false);
		this.SyncAudioRTPCDayTime(second2);
		Singleton<EventSystem>.Instance.Emit(EEventName.TodTimeChange);
		if (needCheckSendTimeToServer && !ModelBase<TimeOfDayModel>.Instance.TimeSynLockState)
		{
			this.CheckDayChangeOrNeedSyncTimeToServer(second);
		}
	}

	// Token: 0x06016480 RID: 91264 RVA: 0x0062C068 File Offset: 0x0062A268
	private void CheckDayChangeOrNeedSyncTimeToServer(double second)
	{
		double num = second;
		if (num > 86400.0)
		{
			num = 0.0;
		}
		ETodDayState dayState = ModelBase<TimeOfDayModel>.Instance.GameTime.DayState;
		if (this.TempDayState != dayState)
		{
			this.TempDayState = dayState;
			Singleton<EventSystem>.Instance.Emit(EEventName.DayStateChange);
		}
		if ((Singleton<Time>.Instance.Now - this.SyncTime > 2000.0 && num - this.LastSyncSecond > 60.0) || this.LastSyncSecond > num)
		{
			this.SyncServerGameTime(num);
		}
		double num2 = Math.Floor(second / 3600.0);
		if (num2 < this.LastHour)
		{
			double num3 = Math.Floor((second - num2 * 3600.0) / 60.0);
			this.ChangeSceneTimeDateRequest(1U, (int)num2, (int)num3, SceneDateUpdateReason.TimeFlowAuto, false);
		}
		this.RecordLastHour((int)num2);
	}

	// Token: 0x06016481 RID: 91265 RVA: 0x0062C150 File Offset: 0x0062A350
	public void SyncServerGameTime(double second)
	{
		if (GlobalData.World == null || (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<CreatureModel>.Instance.IsMyWorld()))
		{
			return;
		}
		double num = Math.Floor(second / 3600.0);
		double num2 = Math.Floor((second - num * 3600.0) / 60.0);
		this.ChangeSceneTimeDateRequest(0U, (int)num, (int)num2, SceneDateUpdateReason.TimeFlowAuto, false);
		this.LastSyncSecond = second;
		this.SyncTime = Singleton<Time>.Instance.Now;
	}

	// Token: 0x06016482 RID: 91266 RVA: 0x0062C1CF File Offset: 0x0062A3CF
	public void SyncGlobalGameTime(double second, bool fromAnimNeed = false)
	{
		if (!this.IsSyncToEngine)
		{
			return;
		}
		if (GlobalData.World == null)
		{
			return;
		}
		if (ModelBase<LoginModel>.Instance.HasLoginPromise())
		{
			return;
		}
		UKuroRenderingRuntimeBPPluginBPLibrary.SetGlobalGITime(GlobalData.World, (float)TodDayTime.ConvertToHour(second));
	}

	// Token: 0x06016483 RID: 91267 RVA: 0x0062C204 File Offset: 0x0062A404
	private void SyncAudioRTPCDayTime(double second)
	{
		if (GlobalData.World == null)
		{
			return;
		}
		double num = this.SyncEnvironmentTime - second;
		if (num > 360.0 || num < -360.0)
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("time", (float)TodDayTime.ConvertToHour(second), null);
			Singleton<AudioSystem>.Instance.SetRtpcValue("time_local", Singleton<TimeUtil>.Instance.GetHoursFloat(), null);
			this.SyncEnvironmentTime = second;
		}
	}

	// Token: 0x06016484 RID: 91268 RVA: 0x0062C282 File Offset: 0x0062A482
	public void ChangeTimeScale(float timeScale)
	{
		ModelBase<TimeOfDayModel>.Instance.SetTimeScale(timeScale, true);
	}

	// Token: 0x06016485 RID: 91269 RVA: 0x0062C290 File Offset: 0x0062A490
	public void PauseTime()
	{
		ModelBase<TimeOfDayModel>.Instance.SetTimeScale(0f, true);
	}

	// Token: 0x06016486 RID: 91270 RVA: 0x0062C2A2 File Offset: 0x0062A4A2
	public void ResumeTimeScale(bool forceNormal = true)
	{
		ModelBase<TimeOfDayModel>.Instance.SetTimeScale(forceNormal ? 1f : ModelBase<TimeOfDayModel>.Instance.OldTimeScale, true);
	}

	// Token: 0x06016487 RID: 91271 RVA: 0x0062C2C3 File Offset: 0x0062A4C3
	public void ForcePauseTime()
	{
		this.PauseTime();
		ModelBase<TimeOfDayModel>.Instance.FreezeTimeScale = true;
	}

	// Token: 0x06016488 RID: 91272 RVA: 0x0062C2D6 File Offset: 0x0062A4D6
	public void ForceResumeTime()
	{
		ModelBase<TimeOfDayModel>.Instance.FreezeTimeScale = false;
		this.ResumeTimeScale(true);
	}

	// Token: 0x06016489 RID: 91273 RVA: 0x0062C2EA File Offset: 0x0062A4EA
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.TimeOfDaySecondView, new Func<EUiViewName, object, bool>(this.CanOpenView), "TimeOfDayController.CanOpenView");
	}

	// Token: 0x0601648A RID: 91274 RVA: 0x0062C30C File Offset: 0x0062A50C
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.TimeOfDaySecondView, new Func<EUiViewName, object, bool>(this.CanOpenView));
	}

	// Token: 0x0601648B RID: 91275 RVA: 0x0062C329 File Offset: 0x0062A529
	public bool CanOpenView(EUiViewName viewName, object param)
	{
		return this.CanOpenView(viewName);
	}

	// Token: 0x0601648C RID: 91276 RVA: 0x0062C334 File Offset: 0x0062A534
	public bool CanOpenView(EUiViewName viewName)
	{
		if (!ModelBase<WeatherModel>.Instance.CanSwitchWeather())
		{
			Singleton<Log>.Instance.Info(ELogModule.Weather, ELogAuthor.LJ, "天气切换中途禁止切换时间", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(new ConfirmBoxDataNew(EConfirmBoxConfigId.WeatherCentralCooldownTips));
			return false;
		}
		if (!this.CheckCanOpenView())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("TimeOfDayCantOpenView", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x0601648D RID: 91277 RVA: 0x0062C3A4 File Offset: 0x0062A5A4
	public unsafe void SyncSceneTime(double hour, double minute, long passedRealMillionSecond, bool showUi = false)
	{
		ModelBase<TimeOfDayModel>.Instance.SetPassSceneTime(ModelBase<TimeOfDayModel>.Instance.GameTime.Second);
		double num = hour * 60.0 * 60.0;
		double num2 = TodDayTime.ConvertFromMinute(minute);
		double num3 = num + num2;
		double num4 = 0.0;
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			num4 = TodDayTime.ConvertFromRealTimeSecond((double)Singleton<MathUtils>.Instance.LongToBigInt(passedRealMillionSecond) / 1000.0 * (double)ModelBase<TimeOfDayModel>.Instance.TimeScale);
		}
		this.TimeInitState = true;
		double setTime = num3 + num4;
		if (showUi)
		{
			TOpenViewCallBack <>9__1;
			Singleton<UiManager>.Instance.ResetToBattleView(delegate(bool success)
			{
				if (success)
				{
					ITimeOfDaySecondViewParam timeOfDaySecondViewParam = new TimeOfDaySecondViewParam
					{
						SetTime = setTime
					};
					UiManager instance2 = Singleton<UiManager>.Instance;
					EUiViewName timeOfDaySecondView = EUiViewName.TimeOfDaySecondView;
					object param = timeOfDaySecondViewParam;
					TOpenViewCallBack finishCallback;
					if ((finishCallback = <>9__1) == null)
					{
						finishCallback = (<>9__1 = delegate(bool succeed, int viewId)
						{
							if (!succeed)
							{
								this.SetTimeInternal(setTime, false);
							}
						});
					}
					instance2.OpenView(timeOfDaySecondView, param, finishCallback);
					return;
				}
				this.SetTimeInternal(setTime, false);
			});
		}
		else
		{
			this.SetTimeInternal(setTime, false);
		}
		this.SetTimeInternal(setTime, false);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TimeOfDay;
		ELogAuthor author = ELogAuthor.FZX;
		string message = "服务器同步Tod时间";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("second", setTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("showUi", showUi);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0601648E RID: 91278 RVA: 0x0062C4E0 File Offset: 0x0062A6E0
	public void AdjustTime(double second, SceneDateUpdateReason reason, uint addDay = 0U, bool needEmitTs = true)
	{
		if (GlobalData.World == null || (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<CreatureModel>.Instance.IsMyWorld()))
		{
			return;
		}
		ModelBase<TimeOfDayModel>.Instance.CacheTimeRecords();
		double num = Math.Floor(second / 3600.0);
		double num2 = Math.Floor((second - num * 3600.0) / 60.0);
		this.ChangeSceneTimeDateRequest(addDay, (int)num, (int)num2, reason, needEmitTs);
		this.SetTimeInternal(second, false);
		this.LastSyncSecond = second;
		this.RecordLastHour((int)num);
		Singleton<EventSystem>.Instance.Emit(EEventName.AdjustTime);
	}

	// Token: 0x0601648F RID: 91279 RVA: 0x0062C57C File Offset: 0x0062A77C
	private void ChangeSceneTimeDateRequest(uint addDay, int hour, int minute, SceneDateUpdateReason reason, bool needEmitTs = false)
	{
		if (GlobalData.World == null || (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<CreatureModel>.Instance.IsMyWorld()))
		{
			return;
		}
		UpdateSceneDateRequest updateSceneDateRequest = UpdateSceneDateRequest.Create();
		updateSceneDateRequest.Hour = hour;
		updateSceneDateRequest.Minute = minute;
		updateSceneDateRequest.Reason = reason;
		updateSceneDateRequest.AddDays = addDay;
		Singleton<Net>.Instance.Call<UpdateSceneDateResponse>(ERequestMessageId.UpdateSceneDateRequest, updateSceneDateRequest, delegate(UpdateSceneDateResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17269, null, true, true);
				return;
			}
			ModelBase<TimeOfDayModel>.Instance.SetCurrentDay(response.CurrDate);
		}, 0);
	}

	// Token: 0x06016490 RID: 91280 RVA: 0x0062C600 File Offset: 0x0062A800
	public bool CheckInMinuteSpan(int startMinute, int endMinute)
	{
		TTodTimeSpan minuteSpan = new TTodTimeSpan(startMinute, endMinute);
		return TodDayTime.CheckInMinuteSpan(ModelBase<TimeOfDayModel>.Instance.GameTime.Minute, minuteSpan);
	}

	// Token: 0x06016491 RID: 91281 RVA: 0x0062C62A File Offset: 0x0062A82A
	public void AdjustTimeByMinute(int minute, SceneDateUpdateReason reason)
	{
		this.AdjustTime(TodDayTime.ConvertFromMinute((double)minute), reason, 0U, true);
	}

	// Token: 0x06016492 RID: 91282 RVA: 0x0062C63C File Offset: 0x0062A83C
	private void OnSceneDateNotify(SceneDateNotify message, Net.CallbackStatus status)
	{
		ModelBase<TimeOfDayModel>.Instance.SetCurrentDay(message.CurrDate);
	}

	// Token: 0x06016493 RID: 91283 RVA: 0x0062C650 File Offset: 0x0062A850
	private void SyncSceneTimeNotify(SyncSceneTimeNotify message, Net.CallbackStatus status)
	{
		SceneTimeInfo timeInfo = message.TimeInfo;
		this.SyncSceneTime((double)timeInfo.Hour, (double)timeInfo.Minute, timeInfo.OwnerTimeClockTimeSpan, message.ShowUi);
	}

	// Token: 0x06016494 RID: 91284 RVA: 0x0062C684 File Offset: 0x0062A884
	private void OnServerTimeLock(TimeLockInfoNotify message, Net.CallbackStatus status)
	{
		if (message.IsLock)
		{
			ModelBase<TimeOfDayModel>.Instance.TimeRunLockStateServer = true;
			ModelBase<TimeOfDayModel>.Instance.TimeRunLockStateServer = true;
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.FZX, "[TimeRunLockState] 服务器通知锁定时间", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		else
		{
			ModelBase<TimeOfDayModel>.Instance.TimeRunLockStateServer = false;
			ModelBase<TimeOfDayModel>.Instance.TimeRunLockStateServer = false;
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.FZX, "[TimeRunLockState] 服务器通知解锁时间", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		double num = (double)Singleton<MathUtils>.Instance.LongToNumber(message.Hour);
		double num2 = (double)Singleton<MathUtils>.Instance.LongToNumber(message.Minute);
		if (num != -1.0 && num2 != -1.0)
		{
			double second = TodDayTime.ConvertFromHourMinute(num, num2);
			this.SetTimeInternal(second, false);
		}
	}

	// Token: 0x06016495 RID: 91285 RVA: 0x0062C74C File Offset: 0x0062A94C
	private void OnTimeResetNotify(TimeResetNotify message, Net.CallbackStatus status)
	{
		if (message.ResetId == 1)
		{
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.YYZ, "[TimeResetNotify] 收到服务器4点跨天通知,触发跨天事件", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit(EEventName.CrossDay);
			return;
		}
		if (message.ResetId == 4)
		{
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.YYZ, "[TimeResetNotify] 收到服务器0点跨天通知,触发跨天事件", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit(EEventName.CrossDayZone);
		}
	}

	// Token: 0x06016496 RID: 91286 RVA: 0x0062C7C4 File Offset: 0x0062A9C4
	public void SetUiAnimFlag(bool value)
	{
		this.UiAnimFlag = value;
	}

	// Token: 0x06016497 RID: 91287 RVA: 0x0062C7CD File Offset: 0x0062A9CD
	public void RecordLastHour(int hour)
	{
		if (this.LastHour != (double)hour)
		{
			this.LastHour = (double)hour;
			Singleton<EventSystem>.Instance.Emit(EEventName.CrossHour);
		}
	}

	// Token: 0x06016498 RID: 91288 RVA: 0x0062C7F1 File Offset: 0x0062A9F1
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x06016499 RID: 91289 RVA: 0x0062C7F4 File Offset: 0x0062A9F4
	private void TsRequestAdjustTime(double second, int reason, int addDay)
	{
		this.AdjustTime(second, (SceneDateUpdateReason)reason, (uint)addDay, false);
	}

	// Token: 0x0601649A RID: 91290 RVA: 0x0062C800 File Offset: 0x0062AA00
	private void TsRequestLockTimeRunStateClient(bool state)
	{
		ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(state, false);
	}

	// Token: 0x0601649B RID: 91291 RVA: 0x0062C80E File Offset: 0x0062AA0E
	private void TsRequestLockTimeSyncLockStateClient(bool state)
	{
		ModelBase<TimeOfDayModel>.Instance.SetTimeSyncLockStateClient(state, false);
	}

	// Token: 0x0601649C RID: 91292 RVA: 0x0062C81C File Offset: 0x0062AA1C
	private void TsRequestSetTimeScale(string scale)
	{
		float value;
		if (float.TryParse(scale, out value))
		{
			ModelBase<TimeOfDayModel>.Instance.SetTimeScale(value, false);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TimeOfDay;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "TsRequestSetTimeScale转换失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("scale", scale);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601649D RID: 91293 RVA: 0x0062C867 File Offset: 0x0062AA67
	private void TsResponseTimeCanOpenViewState(bool state)
	{
		this.CanOpenViewState = state;
	}

	// Token: 0x0601649E RID: 91294 RVA: 0x0062C870 File Offset: 0x0062AA70
	private void TsResponseSyncServerGameTime(double currentDay)
	{
		ModelBase<TimeOfDayModel>.Instance.SetCurrentDay(currentDay);
	}

	// Token: 0x0601649F RID: 91295 RVA: 0x0062C87D File Offset: 0x0062AA7D
	private void TsOnTimeEnterGame()
	{
		this.OnEnterGame();
	}

	// Token: 0x060164A0 RID: 91296 RVA: 0x0062C885 File Offset: 0x0062AA85
	private void TsOnTimeBeforeLoadMap()
	{
		this.OnBeforeLoadMap();
	}

	// Token: 0x060164A1 RID: 91297 RVA: 0x0062C88D File Offset: 0x0062AA8D
	private void TsOnTimeWorldDone()
	{
		this.OnWorldDoneAndCloseLoading();
	}

	// Token: 0x060164A2 RID: 91298 RVA: 0x0062C895 File Offset: 0x0062AA95
	private void TsSyncSceneTime(int hour, int minute, int passedRealMillionSecond)
	{
		this.SyncSceneTime((double)hour, (double)minute, (long)passedRealMillionSecond, false);
	}

	// Token: 0x060164A3 RID: 91299 RVA: 0x0062C8A4 File Offset: 0x0062AAA4
	private void TsSyncUseClientLockState(bool state)
	{
		ModelBase<TimeOfDayModel>.Instance.SetUseClientLockState(state);
	}

	// Token: 0x0400AC63 RID: 44131
	private const int SENDTIMEGAP = 2000;

	// Token: 0x0400AC64 RID: 44132
	public bool IsSyncToEngine = true;

	// Token: 0x0400AC65 RID: 44133
	private double TickDelta;

	// Token: 0x0400AC66 RID: 44134
	private ETodDayState TempDayState = ETodDayState.Count;

	// Token: 0x0400AC67 RID: 44135
	private double SyncEnvironmentTime;

	// Token: 0x0400AC68 RID: 44136
	private double LastSyncSecond;

	// Token: 0x0400AC69 RID: 44137
	private double SyncTime;

	// Token: 0x0400AC6A RID: 44138
	private double LastHour;

	// Token: 0x0400AC6B RID: 44139
	private bool EnterGameFlag;

	// Token: 0x0400AC6C RID: 44140
	private bool LoadingFlag;

	// Token: 0x0400AC6D RID: 44141
	private bool UiAnimFlag;

	// Token: 0x0400AC6E RID: 44142
	private bool TimeInitState;

	// Token: 0x0400AC6F RID: 44143
	private const double CheckTimeGap = 360.0;

	// Token: 0x0400AC70 RID: 44144
	private bool CanOpenViewState;
}
