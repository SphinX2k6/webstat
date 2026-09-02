using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E00 RID: 7680
[NullableContext(1)]
[Nullable(0)]
public class FailRangeTimer : LogicTreeTimerBase
{
	// Token: 0x0600E2D1 RID: 58065 RVA: 0x003D1728 File Offset: 0x003CF928
	public FailRangeTimer(long treeIncId, string timerType, double intervalTime) : base(treeIncId, timerType, true, intervalTime)
	{
	}

	// Token: 0x0600E2D2 RID: 58066 RVA: 0x003D173F File Offset: 0x003CF93F
	public override void Destroy()
	{
		this.ProcessList.Clear();
		Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestFailRangeTipsView, new Action<bool>(this.FinishCallbackForEnd));
		Singleton<EventSystem>.Instance.Emit(EEventName.FailRangeTimerEndShow);
		base.Destroy();
	}

	// Token: 0x0600E2D3 RID: 58067 RVA: 0x003D177D File Offset: 0x003CF97D
	public override void StartShowTimer(double endTime, double pauseTime)
	{
		this.ProcessList.Add(new StartShowProcess(endTime));
	}

	// Token: 0x0600E2D4 RID: 58068 RVA: 0x003D1790 File Offset: 0x003CF990
	public override void EndShowTimer()
	{
		this.ProcessList.Add(new EndShowProcess());
	}

	// Token: 0x0600E2D5 RID: 58069 RVA: 0x003D17A4 File Offset: 0x003CF9A4
	protected override void OnTick(float delta)
	{
		if (this.ProcessList.Count == 0)
		{
			return;
		}
		if (this.CurProcess != null)
		{
			return;
		}
		this.CurProcess = this.ProcessList[0];
		EProcessType processType = this.CurProcess.ProcessType;
		if (processType == EProcessType.StartShow)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.FailRangeTimerStartShow);
			StartShowProcess startShowProcess = (StartShowProcess)this.CurProcess;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestFailRangeTipsView, startShowProcess.EndTime, new TOpenViewCallBack(this.FinishCallbackForStart));
			return;
		}
		if (processType != EProcessType.EndShow)
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestFailRangeTipsView, new Action<bool>(this.FinishCallbackForEnd));
		Singleton<EventSystem>.Instance.Emit(EEventName.FailRangeTimerEndShow);
	}

	// Token: 0x0600E2D6 RID: 58070 RVA: 0x003D185C File Offset: 0x003CFA5C
	private void FinishCallbackForStart(bool success, int viewId)
	{
		this.FinishCallbackImpl(success);
	}

	// Token: 0x0600E2D7 RID: 58071 RVA: 0x003D1865 File Offset: 0x003CFA65
	private void FinishCallbackForEnd(bool success)
	{
		this.FinishCallbackImpl(success);
	}

	// Token: 0x0600E2D8 RID: 58072 RVA: 0x003D1870 File Offset: 0x003CFA70
	private void FinishCallbackImpl(bool success)
	{
		if (this.CurProcess != null)
		{
			this.CurProcess.Finished = true;
			this.CurProcess = null;
		}
		PendingProcess pendingProcess;
		this.ProcessList.TryShift(out pendingProcess);
	}

	// Token: 0x04006D13 RID: 27923
	private readonly List<PendingProcess> ProcessList = new List<PendingProcess>();

	// Token: 0x04006D14 RID: 27924
	[Nullable(2)]
	private PendingProcess CurProcess;
}
