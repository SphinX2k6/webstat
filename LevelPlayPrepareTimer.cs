using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

// Token: 0x02001E01 RID: 7681
public class LevelPlayPrepareTimer : LogicTreeTimerBase
{
	// Token: 0x0600E2D9 RID: 58073 RVA: 0x003D18A6 File Offset: 0x003CFAA6
	[NullableContext(1)]
	public LevelPlayPrepareTimer(long treeIncId, string timerType, bool needTick = true, double intervalTime = 20.0) : base(treeIncId, timerType, needTick, intervalTime)
	{
	}

	// Token: 0x0600E2DA RID: 58074 RVA: 0x003D18B4 File Offset: 0x003CFAB4
	public override void StartShowTimer(double endTime, double pauseTime)
	{
		this.TimerEndTime = endTime;
		this.TimerPauseTime = pauseTime;
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.PrepareCountdownPrompt, null, null, null, null, null, null, null, null, false, null);
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600E2DB RID: 58075 RVA: 0x003D1910 File Offset: 0x003CFB10
	public override void EndShowTimer()
	{
		if (Singleton<EventSystem>.Instance.Has(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PrepareCountdownFloatTips);
		if (viewByName != null)
		{
			CustomPromise closePromise = viewByName.ClosePromise;
			if (closePromise == null || !closePromise.IsPending)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PrepareCountdownFloatTips, null);
				return;
			}
		}
	}

	// Token: 0x0600E2DC RID: 58076 RVA: 0x003D1988 File Offset: 0x003CFB88
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.PrepareCountdownFloatTips)
		{
			return;
		}
		this.RequestTimerEnd();
	}

	// Token: 0x0600E2DD RID: 58077 RVA: 0x003D19A0 File Offset: 0x003CFBA0
	private void RequestTimerEnd()
	{
		if (this.RequestedEnd)
		{
			return;
		}
		this.RequestedEnd = true;
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		ControllerBase<GeneralLogicTreeController>.Instance.RequestTimerEnd(this.TreeId, base.TimerType);
	}

	// Token: 0x0600E2DE RID: 58078 RVA: 0x003D19EC File Offset: 0x003CFBEC
	public override double GetRemainTime()
	{
		double val = (this.TimerEndTime - Singleton<TimeUtil>.Instance.GetServerStopTimeStamp()) / 1000.0;
		double val2 = (this.TimerPauseTime != 0.0) ? ((this.TimerEndTime - this.TimerPauseTime) / 1000.0) : -1.0;
		return Math.Max(val, Math.Max(val2, 0.0));
	}

	// Token: 0x04006D15 RID: 27925
	private double TimerEndTime;

	// Token: 0x04006D16 RID: 27926
	private double TimerPauseTime;

	// Token: 0x04006D17 RID: 27927
	private bool RequestedEnd;
}
