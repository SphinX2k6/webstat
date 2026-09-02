using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F27 RID: 7975
public class HonamiStoryLeaveTip : UiViewBase
{
	// Token: 0x0600EE91 RID: 61073 RVA: 0x0041267B File Offset: 0x0041087B
	[NullableContext(1)]
	public HonamiStoryLeaveTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EE92 RID: 61074 RVA: 0x00412684 File Offset: 0x00410884
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnCancelClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnConfirmClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnCancelClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnCancelClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EE93 RID: 61075 RVA: 0x004128A0 File Offset: 0x00410AA0
	protected override void OnStart()
	{
		IHonamiStoryLeaveTipParams honamiStoryLeaveTipParams = this.OpenParam as IHonamiStoryLeaveTipParams;
		if (honamiStoryLeaveTipParams == null)
		{
			return;
		}
		this.ShowSafeLeaveUpdate = honamiStoryLeaveTipParams.ShowSafeLeaveUpdate;
		this.ConfirmCallback = honamiStoryLeaveTipParams.ConfirmCallback;
		this.CancelCallback = honamiStoryLeaveTipParams.CancelCallback;
		EHonamiStoryLeaveType ehonamiStoryLeaveType = HonamiStoryUtil.CheckInHonamiStoryTopTower() ? EHonamiStoryLeaveType.TopTowerLeave : honamiStoryLeaveTipParams.LeaveType;
		string textStringId = string.Empty;
		string textStringId2 = string.Empty;
		string textStringId3 = string.Empty;
		string textStringId4 = string.Empty;
		string textStringId5 = string.Empty;
		string textStringId6 = string.Empty;
		switch (ehonamiStoryLeaveType)
		{
		case EHonamiStoryLeaveType.SafeLeave:
			textStringId = "HonamiStory_EvacuationWindow_1";
			textStringId2 = "HonamiStory_EvacuationWindow_4";
			textStringId3 = "HonamiStory_EvacuationWindow_5";
			textStringId4 = "HonamiStory_EvacuationWindow_6";
			textStringId5 = "HonamiStory_EvacuationWindow_2";
			textStringId6 = "HonamiStory_EvacuationWindow_3";
			break;
		case EHonamiStoryLeaveType.DangerLeave:
			textStringId = "HonamiStory_EvacuationWindow_9";
			textStringId2 = "HonamiStory_EvacuationWindow_12";
			textStringId3 = "HonamiStory_EvacuationWindow_13";
			textStringId4 = "HonamiStory_EvacuationWindow_14";
			textStringId5 = "HonamiStory_EvacuationWindow_10";
			textStringId6 = "HonamiStory_EvacuationWindow_11";
			break;
		case EHonamiStoryLeaveType.InteractLeave:
			textStringId = "HonamiStory_EvacuationWindow_1";
			textStringId2 = "HonamiStory_EvacuationWindow_4";
			textStringId3 = "HonamiStory_EvacuationWindow_5";
			textStringId4 = "HonamiStory_EvacuationWindow_6";
			textStringId5 = "HonamiStory_EvacuationWindow_7";
			textStringId6 = "HonamiStory_EvacuationWindow_8";
			break;
		case EHonamiStoryLeaveType.TopTowerLeave:
			textStringId = "HonamiStory_EvacuationWindow_15";
			textStringId2 = "HonamiStory_EvacuationWindow_18";
			textStringId3 = "HonamiStory_EvacuationWindow_19";
			textStringId4 = "HonamiStory_EvacuationWindow_20";
			textStringId5 = "HonamiStory_EvacuationWindow_16";
			textStringId6 = "HonamiStory_EvacuationWindow_17";
			break;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId5, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId6, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId2, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId3, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), textStringId4, Array.Empty<object>());
		if (this.UiViewSequence != null)
		{
			this.UiViewSequence.StartSequenceName = ((ehonamiStoryLeaveType == EHonamiStoryLeaveType.DangerLeave) ? "FailStart" : "SuccessStart");
		}
	}

	// Token: 0x0600EE94 RID: 61076 RVA: 0x00412A90 File Offset: 0x00410C90
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		HonamiStoryLeaveTip.<OnPlayingCloseSequenceAsync>d__8 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<HonamiStoryLeaveTip.<OnPlayingCloseSequenceAsync>d__8>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE95 RID: 61077 RVA: 0x00412AD3 File Offset: 0x00410CD3
	protected override void OnBeforeDestroy()
	{
		if (this.ShowSafeLeaveUpdate)
		{
			ControllerBase<HonamiStoryController>.Instance.ShowSafeLeaveUpdate();
			this.ShowSafeLeaveUpdate = false;
		}
	}

	// Token: 0x0600EE96 RID: 61078 RVA: 0x00412AEE File Offset: 0x00410CEE
	private void OnCancelClick()
	{
		this.IsConfirmClose = false;
		base.CloseMe(null);
		Action cancelCallback = this.CancelCallback;
		if (cancelCallback == null)
		{
			return;
		}
		cancelCallback();
	}

	// Token: 0x0600EE97 RID: 61079 RVA: 0x00412B0E File Offset: 0x00410D0E
	private void OnConfirmClick()
	{
		this.IsConfirmClose = true;
		base.CloseMe(null);
		Action confirmCallback = this.ConfirmCallback;
		if (confirmCallback == null)
		{
			return;
		}
		confirmCallback();
	}

	// Token: 0x04007280 RID: 29312
	private bool IsConfirmClose;

	// Token: 0x04007281 RID: 29313
	private bool ShowSafeLeaveUpdate;

	// Token: 0x04007282 RID: 29314
	[Nullable(2)]
	private Action ConfirmCallback;

	// Token: 0x04007283 RID: 29315
	[Nullable(2)]
	private Action CancelCallback;

	// Token: 0x0200829E RID: 33438
	private enum EComponentType
	{
		// Token: 0x0402C4CD RID: 181453
		TitleText,
		// Token: 0x0402C4CE RID: 181454
		SubTitleText,
		// Token: 0x0402C4CF RID: 181455
		ContentText,
		// Token: 0x0402C4D0 RID: 181456
		SubContentText,
		// Token: 0x0402C4D1 RID: 181457
		CancelButton,
		// Token: 0x0402C4D2 RID: 181458
		ConfirmButton,
		// Token: 0x0402C4D3 RID: 181459
		BackButton,
		// Token: 0x0402C4D4 RID: 181460
		BgButton,
		// Token: 0x0402C4D5 RID: 181461
		CancelButtonText,
		// Token: 0x0402C4D6 RID: 181462
		ConfirmButtonText
	}
}
