using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GeneralLogicTree.View.CountDown;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001DFB RID: 7675
public class CountDownTimer : LogicTreeTimerBase
{
	// Token: 0x0600E2B2 RID: 58034 RVA: 0x003D0BA4 File Offset: 0x003CEDA4
	[NullableContext(1)]
	public CountDownTimer(long treeIncId, int nodeId, ETimerType timerType, ETimerUiType uiType, string uiTitle, double intervalTime) : base(treeIncId, timerType.ToEnumString(), true, intervalTime)
	{
		this.NodeId = nodeId;
		this.UiType = uiType;
		this.UiTitle = uiTitle;
	}

	// Token: 0x0600E2B3 RID: 58035 RVA: 0x003D0BCD File Offset: 0x003CEDCD
	public override void Destroy()
	{
		this.EndShowTimer();
		this.EventsRegistered = false;
		base.Destroy();
	}

	// Token: 0x0600E2B4 RID: 58036 RVA: 0x003D0BE4 File Offset: 0x003CEDE4
	protected void OnAddEvents()
	{
		if (this.EventsRegistered)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Add<long, ETimerType, TimerSetType, int>(EEventName.GeneralLogicTreeTimerInfoChanged, new Action<long, ETimerType, TimerSetType, int>(this.OnTimerInfoChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.FailRangeTimerStartShow, new Action(this.OnFailRangeTimerStartShow));
		Singleton<EventSystem>.Instance.Add(EEventName.FailRangeTimerEndShow, new Action(this.OnFailRangeTimerEndShow));
		this.EventsRegistered = true;
	}

	// Token: 0x0600E2B5 RID: 58037 RVA: 0x003D0C58 File Offset: 0x003CEE58
	protected void OnRemoveEvents()
	{
		if (!this.EventsRegistered)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeTimerInfoChanged, new Action<long, ETimerType, TimerSetType, int>(this.OnTimerInfoChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.FailRangeTimerStartShow, new Action(this.OnFailRangeTimerStartShow));
		Singleton<EventSystem>.Instance.Remove(EEventName.FailRangeTimerEndShow, new Action(this.OnFailRangeTimerEndShow));
		this.EventsRegistered = false;
	}

	// Token: 0x0600E2B6 RID: 58038 RVA: 0x003D0CCC File Offset: 0x003CEECC
	private void OnTimerInfoChanged(long treeIncId, ETimerType timerType, TimerSetType setType, int seconds)
	{
		if (treeIncId == 0L || treeIncId != this.TreeId || this.InnerTimerType != timerType.ToEnumString())
		{
			return;
		}
		int num = seconds * 1000;
		switch (setType)
		{
		case TimerSetType.Add:
			this.TimerEndTime += (double)num;
			break;
		case TimerSetType.Sub:
			this.TimerEndTime -= (double)num;
			break;
		case TimerSetType.Set:
			this.TimerEndTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + (double)num;
			break;
		}
		this.NotifyTimerUiChange(this.GetRemainTime());
	}

	// Token: 0x0600E2B7 RID: 58039 RVA: 0x003D0D58 File Offset: 0x003CEF58
	protected override void OnTick(float delta)
	{
		double serverStopTimeStamp = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
		double num = serverStopTimeStamp - this.LastTickTime;
		this.LastTickTime = serverStopTimeStamp;
		this.TimerRunningDelta += num;
		double remainTime = this.GetRemainTime();
		if (remainTime < 0.0)
		{
			this.RequestTimerEnd();
			return;
		}
		if (this.UiType != ETimerUiType.HideUi)
		{
			this.NotifyTimerUiChange(remainTime);
		}
	}

	// Token: 0x0600E2B8 RID: 58040 RVA: 0x003D0DB8 File Offset: 0x003CEFB8
	private void RequestTimerEnd()
	{
		if (this.RequestedEnd)
		{
			return;
		}
		this.RequestedEnd = true;
		this.EndShowTimer();
		ControllerBase<GeneralLogicTreeController>.Instance.RequestTimerEnd(this.TreeId, base.TimerType);
	}

	// Token: 0x0600E2B9 RID: 58041 RVA: 0x003D0DE8 File Offset: 0x003CEFE8
	public override void StartShowTimer(double endTime, double pauseTime)
	{
		if (endTime == 0.0)
		{
			return;
		}
		this.TimerEndTime = endTime;
		this.TimerPauseTime = pauseTime;
		this.TimerStartTime = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
		this.TimerRunningDelta = 0.0;
		this.LastTickTime = this.TimerStartTime;
		ModelBase<GeneralLogicTreeModel>.Instance.SetTimerUiOwnerId(this.TreeId);
		if (this.UiType != ETimerUiType.HideUi)
		{
			this.TryOpenCountDownUi();
		}
		this.OnAddEvents();
	}

	// Token: 0x0600E2BA RID: 58042 RVA: 0x003D0E60 File Offset: 0x003CF060
	public override void EndShowTimer()
	{
		this.OnRemoveEvents();
		this.TryCloseCountDownUi();
	}

	// Token: 0x0600E2BB RID: 58043 RVA: 0x003D0E70 File Offset: 0x003CF070
	private void TryOpenCountDownUi()
	{
		Dictionary<ETimerUiType, int> countDownTimerViewMap = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerViewMap;
		int? num = (countDownTimerViewMap != null) ? countDownTimerViewMap.GetValueOrNull(this.UiType) : null;
		if (num == null)
		{
			this.OpenCountDownUi();
			return;
		}
		if (num.Value == this.NodeId)
		{
			this.NotifyTimerUiChange(this.GetRemainTime());
			return;
		}
		Dictionary<ETimerUiType, List<ValueTuple<int, Action>>> countDownTimerFuncMap = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerFuncMap;
		if (countDownTimerFuncMap != null)
		{
			List<ValueTuple<int, Action>> list;
			if (!countDownTimerFuncMap.TryGetValue(this.UiType, out list))
			{
				list = (countDownTimerFuncMap[this.UiType] = new List<ValueTuple<int, Action>>());
			}
			list.Add(new ValueTuple<int, Action>(this.NodeId, new Action(this.TryOpenCountDownUi)));
		}
	}

	// Token: 0x0600E2BC RID: 58044 RVA: 0x003D0F1C File Offset: 0x003CF11C
	private void TryCloseCountDownUi()
	{
		Dictionary<ETimerUiType, int> countDownTimerViewMap = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerViewMap;
		int? num = (countDownTimerViewMap != null) ? new int?(countDownTimerViewMap.GetValueOrDefault(this.UiType)) : null;
		if (num == null)
		{
			return;
		}
		int? num2 = num;
		int nodeId = this.NodeId;
		if (num2.GetValueOrDefault() == nodeId & num2 != null)
		{
			this.NotifyTimerUiChange(0.0);
			return;
		}
		Dictionary<ETimerUiType, List<ValueTuple<int, Action>>> countDownTimerFuncMap = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerFuncMap;
		List<ValueTuple<int, Action>> list = (countDownTimerFuncMap != null) ? countDownTimerFuncMap.GetValueOrDefault(this.UiType) : null;
		if (list == null || list.Count == 0)
		{
			return;
		}
		int num3 = list.IndexOf((ValueTuple<int, Action> x) => x.Item1 == this.NodeId);
		if (num3 > 0)
		{
			list.RemoveAt(num3);
		}
		if (list.Count == 0)
		{
			Dictionary<ETimerUiType, List<ValueTuple<int, Action>>> countDownTimerFuncMap2 = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerFuncMap;
			if (countDownTimerFuncMap2 == null)
			{
				return;
			}
			countDownTimerFuncMap2.Remove(this.UiType);
		}
	}

	// Token: 0x0600E2BD RID: 58045 RVA: 0x003D0FF8 File Offset: 0x003CF1F8
	private void OpenNextCountDownUi()
	{
		Dictionary<ETimerUiType, int> countDownTimerViewMap = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerViewMap;
		if (countDownTimerViewMap != null)
		{
			countDownTimerViewMap.Remove(this.UiType);
		}
		Dictionary<ETimerUiType, List<ValueTuple<int, Action>>> countDownTimerFuncMap = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerFuncMap;
		List<ValueTuple<int, Action>> list = (countDownTimerFuncMap != null) ? countDownTimerFuncMap.GetValueOrDefault(this.UiType) : null;
		if (list == null || list.Count == 0)
		{
			return;
		}
		ValueTuple<int, Action> valueTuple;
		if (list.TryPop(out valueTuple))
		{
			valueTuple.Item2();
		}
		if (list.Count == 0)
		{
			Dictionary<ETimerUiType, List<ValueTuple<int, Action>>> countDownTimerFuncMap2 = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerFuncMap;
			if (countDownTimerFuncMap2 == null)
			{
				return;
			}
			countDownTimerFuncMap2.Remove(this.UiType);
		}
	}

	// Token: 0x0600E2BE RID: 58046 RVA: 0x003D1084 File Offset: 0x003CF284
	private unsafe void OpenCountDownUi()
	{
		double remainTime = this.GetRemainTime();
		if (remainTime <= 0.0)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GamePlayTimer;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "倒计时剩余时间不足";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("开始时间", this.TimerStartTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("结束时间", this.TimerEndTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("treeIncId", this.TreeId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		Dictionary<ETimerUiType, int> countDownTimerViewMap = ModelBase<GeneralLogicTreeModel>.Instance.CountDownTimerViewMap;
		if (countDownTimerViewMap != null)
		{
			countDownTimerViewMap[this.UiType] = this.NodeId;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.GamePlayTimer;
		ELogAuthor author2 = ELogAuthor.YSQ;
		string message2 = "倒计时开始";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("开始时间", this.TimerStartTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("结束时间", this.TimerEndTime);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("treeIncId", this.TreeId);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		switch (this.UiType)
		{
		case ETimerUiType.Default:
			this.OpenDefaultPromptCountDown(remainTime);
			return;
		case ETimerUiType.CountDownChallengeBlackCoast:
			this.OpenChallengeCountDown(remainTime);
			return;
		case ETimerUiType.HideUi:
			break;
		case ETimerUiType.CountDownChallengeSlashAndTower:
			this.OpenShipTowerCountDown(remainTime);
			return;
		case ETimerUiType.GreatSwordChallenge:
			this.OpenGreatSwordCountDown(remainTime);
			return;
		case ETimerUiType.StoveCoreFall:
			this.OpenMotorcycleCountDown(remainTime);
			return;
		case ETimerUiType.RebeccaChallenge:
			this.OpenCyberpunkCountDown(remainTime);
			break;
		default:
			return;
		}
	}

	// Token: 0x0600E2BF RID: 58047 RVA: 0x003D1238 File Offset: 0x003CF438
	private void OpenDefaultPromptCountDown(double remainTime)
	{
		GenericPrompt? promptInfo = ConfigBase<GenericPromptConfig>.Instance.GetPromptInfo(19);
		string[] array = new string[3];
		double num = Math.Floor(remainTime % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
		double num2 = Math.Floor(remainTime % Singleton<TimeUtil>.Instance.Minute);
		double num3 = Math.Floor((remainTime - Math.Floor(remainTime)) * 100.0);
		string[] array2 = array;
		int num4 = 0;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted((num < 10.0) ? "0" : "");
		defaultInterpolatedStringHandler.AppendFormatted<double>(num);
		array2[num4] = defaultInterpolatedStringHandler.ToStringAndClear();
		string[] array3 = array;
		int num5 = 1;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted((num2 < 10.0) ? "0" : "");
		defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
		array3[num5] = defaultInterpolatedStringHandler.ToStringAndClear();
		string[] array4 = array;
		int num6 = 2;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted((num3 < 10.0) ? "0" : "");
		defaultInterpolatedStringHandler.AppendFormatted<double>(num3);
		array4[num6] = defaultInterpolatedStringHandler.ToStringAndClear();
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CountDownFloatTips) == null || ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>((EPromptSubViewType)promptInfo.Value.TypeId, null, null, null, array, new int?(19), null, null, null, false, null);
		}
		this.NotifyTimerUiChange(remainTime);
	}

	// Token: 0x0600E2C0 RID: 58048 RVA: 0x003D13A8 File Offset: 0x003CF5A8
	private void OpenChallengeCountDown(double remainTime)
	{
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CountDownChallenge) == null || ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing)
		{
			ChallengeCountDownViewParams param = new ChallengeCountDownViewParams(this.TimerEndTime, this.UiTitle);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CountDownChallenge, param, null);
		}
		this.NotifyTimerUiChange(remainTime);
	}

	// Token: 0x0600E2C1 RID: 58049 RVA: 0x003D13FC File Offset: 0x003CF5FC
	private void OpenShipTowerCountDown(double remainTime)
	{
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.ShipTowerCountDownView) == null || ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerCountDownView, new ShipTowerCountDownView.Params
			{
				EndTime = this.TimerEndTime
			}, null);
		}
		this.NotifyTimerUiChange(remainTime);
	}

	// Token: 0x0600E2C2 RID: 58050 RVA: 0x003D1450 File Offset: 0x003CF650
	private void OpenGreatSwordCountDown(double remainTime)
	{
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.GreatSwordCountDownView) == null || ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing)
		{
			ChallengeCountDownViewParams param = new ChallengeCountDownViewParams(this.TimerEndTime, this.UiTitle);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GreatSwordCountDownView, param, null);
		}
		this.NotifyTimerUiChange(remainTime);
	}

	// Token: 0x0600E2C3 RID: 58051 RVA: 0x003D14A4 File Offset: 0x003CF6A4
	private void OpenMotorcycleCountDown(double remainTime)
	{
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MotorcycleCountDownView) == null || ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleCountDownView, null, null);
		}
		this.NotifyTimerUiChange(remainTime);
	}

	// Token: 0x0600E2C4 RID: 58052 RVA: 0x003D14DC File Offset: 0x003CF6DC
	private void OpenCyberpunkCountDown(double remainTime)
	{
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CyberpunkCountDownView) == null || ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing)
		{
			SimpleLogicTreeCountDownViewParam param = new SimpleLogicTreeCountDownViewParam
			{
				Title = this.UiTitle
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CyberpunkCountDownView, param, null);
		}
		this.NotifyTimerUiChange(remainTime);
	}

	// Token: 0x0600E2C5 RID: 58053 RVA: 0x003D1530 File Offset: 0x003CF730
	public override double GetRemainTime()
	{
		double val = (this.TimerEndTime - (this.TimerStartTime + this.TimerRunningDelta)) / 1000.0;
		double val2 = (this.TimerPauseTime != 0.0) ? ((this.TimerEndTime - this.TimerPauseTime) / 1000.0) : -1.0;
		return Math.Max(Math.Max(val, 0.0), val2);
	}

	// Token: 0x0600E2C6 RID: 58054 RVA: 0x003D15A4 File Offset: 0x003CF7A4
	private void NotifyTimerUiChange(double remainTime)
	{
		if (!ModelBase<GeneralLogicTreeModel>.Instance.IsTimerUiOwner(this.TreeId))
		{
			return;
		}
		EUiViewName euiViewName = EUiViewName.CountDownFloatTips;
		switch (this.UiType)
		{
		case ETimerUiType.Default:
			euiViewName = EUiViewName.CountDownFloatTips;
			break;
		case ETimerUiType.CountDownChallengeBlackCoast:
			euiViewName = EUiViewName.CountDownChallenge;
			break;
		case ETimerUiType.CountDownChallengeSlashAndTower:
			euiViewName = EUiViewName.ShipTowerCountDownView;
			break;
		case ETimerUiType.GreatSwordChallenge:
			euiViewName = EUiViewName.GreatSwordCountDownView;
			break;
		case ETimerUiType.StoveCoreFall:
			euiViewName = EUiViewName.MotorcycleCountDownView;
			break;
		case ETimerUiType.RebeccaChallenge:
			euiViewName = EUiViewName.CyberpunkCountDownView;
			break;
		}
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(euiViewName);
		if (viewByName == null)
		{
			this.OpenNextCountDownUi();
			return;
		}
		if (remainTime != 0.0)
		{
			Singleton<EventSystem>.Instance.Emit<double, double>(EEventName.OnGamePlayCdChanged, remainTime, this.TimerEndTime);
			return;
		}
		if (viewByName.ClosePromise != null)
		{
			this.OpenNextCountDownUi();
			return;
		}
		ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = true;
		Singleton<UiManager>.Instance.CloseView(euiViewName, delegate(bool success)
		{
			if (success)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = false;
				this.OpenNextCountDownUi();
			}
		});
	}

	// Token: 0x0600E2C7 RID: 58055 RVA: 0x003D168E File Offset: 0x003CF88E
	private void OnFailRangeTimerStartShow()
	{
		this.TryCloseCountDownUi();
	}

	// Token: 0x0600E2C8 RID: 58056 RVA: 0x003D1696 File Offset: 0x003CF896
	private void OnFailRangeTimerEndShow()
	{
		this.TryOpenCountDownUi();
	}

	// Token: 0x04006CFF RID: 27903
	private const int GENERAL_TIP_ID = 19;

	// Token: 0x04006D00 RID: 27904
	private const int ONE_HUNDRED = 100;

	// Token: 0x04006D01 RID: 27905
	private double TimerEndTime;

	// Token: 0x04006D02 RID: 27906
	private double TimerPauseTime;

	// Token: 0x04006D03 RID: 27907
	private double TimerStartTime;

	// Token: 0x04006D04 RID: 27908
	private double TimerRunningDelta;

	// Token: 0x04006D05 RID: 27909
	private bool RequestedEnd;

	// Token: 0x04006D06 RID: 27910
	private double LastTickTime;

	// Token: 0x04006D07 RID: 27911
	private readonly ETimerUiType UiType;

	// Token: 0x04006D08 RID: 27912
	private readonly int NodeId;

	// Token: 0x04006D09 RID: 27913
	[Nullable(2)]
	private readonly string UiTitle;

	// Token: 0x04006D0A RID: 27914
	private bool EventsRegistered;
}
