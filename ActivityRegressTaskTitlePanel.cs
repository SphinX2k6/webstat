using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001564 RID: 5476
public class ActivityRegressTaskTitlePanel : UiPanelBase
{
	// Token: 0x060099B3 RID: 39347 RVA: 0x00283DBC File Offset: 0x00281FBC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060099B4 RID: 39348 RVA: 0x00283E37 File Offset: 0x00282037
	protected override void OnBeforeDestroy()
	{
		this.RemoveTimerCheck();
	}

	// Token: 0x060099B5 RID: 39349 RVA: 0x00283E40 File Offset: 0x00282040
	[NullableContext(1)]
	public void RefreshByData(ActivityRegressTaskDynamicData data)
	{
		bool flag = data.TaskType > ERegressTaskType.Constant;
		base.GetItem(2).SetUIActive(flag);
		base.GetItem(3).SetUIActive(!flag);
		UUIText text = base.GetText(0);
		string textStringId = (data.TaskType == ERegressTaskType.Constant) ? "RecallActivity_Task_Resident" : "RecallActivity_Task_Daily";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
		UUIItem text2 = base.GetText(1);
		bool flag2 = data.TaskType == ERegressTaskType.Daily;
		text2.SetUIActive(flag2);
		if (flag2)
		{
			this.RemoveTimerCheck();
			this.TimerHandle = TimerSystem.RealTimeInstance.Forever(new TTimerAction(this.RefreshTimerView), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
			this.RefreshTimerView(0f);
		}
	}

	// Token: 0x060099B6 RID: 39350 RVA: 0x00283EFC File Offset: 0x002820FC
	private void RefreshTimerView(float _)
	{
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RecallActivity_Task_Daily_Countdown", new <>z__ReadOnlySingleElementList<object>(ModelBase<ActivityRegressModel>.Instance.ActivityData.GetNextRefreshTime()));
	}

	// Token: 0x060099B7 RID: 39351 RVA: 0x00283F35 File Offset: 0x00282135
	private void RemoveTimerCheck()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x040046F6 RID: 18166
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x0200792A RID: 31018
	private class EComponents
	{
		// Token: 0x04029A22 RID: 170530
		public const int TxtTitle = 0;

		// Token: 0x04029A23 RID: 170531
		public const int TxtTips = 1;

		// Token: 0x04029A24 RID: 170532
		public const int TexBG1 = 2;

		// Token: 0x04029A25 RID: 170533
		public const int TexBG2 = 3;
	}
}
