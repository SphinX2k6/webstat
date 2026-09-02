using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CC9 RID: 7369
public class GachaAccumulateBonusView : UiViewBase
{
	// Token: 0x0600D82E RID: 55342 RVA: 0x0039D299 File Offset: 0x0039B499
	[NullableContext(1)]
	public GachaAccumulateBonusView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D82F RID: 55343 RVA: 0x0039D2A4 File Offset: 0x0039B4A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnMaskButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D830 RID: 55344 RVA: 0x0039D34A File Offset: 0x0039B54A
	private void OnMaskButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600D831 RID: 55345 RVA: 0x0039D354 File Offset: 0x0039B554
	protected override UniTask OnBeforeStartAsync()
	{
		GachaAccumulateBonusView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaAccumulateBonusView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D832 RID: 55346 RVA: 0x0039D397 File Offset: 0x0039B597
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GachaAccumulateRewardClaimed, new Action<int>(this.OnGachaAccumulateRewardClaimed));
	}

	// Token: 0x0600D833 RID: 55347 RVA: 0x0039D3B5 File Offset: 0x0039B5B5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GachaAccumulateRewardClaimed, new Action<int>(this.OnGachaAccumulateRewardClaimed));
	}

	// Token: 0x0600D834 RID: 55348 RVA: 0x0039D3D3 File Offset: 0x0039B5D3
	private void OnGachaAccumulateRewardClaimed(int accumulateId)
	{
		if (accumulateId == this.CurrentAccumulateId)
		{
			this.Content.RefreshView(accumulateId);
		}
	}

	// Token: 0x0600D835 RID: 55349 RVA: 0x0039D3EC File Offset: 0x0039B5EC
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		GachaAccumulateBonusView.<OnPlayingStartSequenceAsync>d__9 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<GachaAccumulateBonusView.<OnPlayingStartSequenceAsync>d__9>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D836 RID: 55350 RVA: 0x0039D430 File Offset: 0x0039B630
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		GachaAccumulateBonusView.<OnPlayingCloseSequenceAsync>d__10 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<GachaAccumulateBonusView.<OnPlayingCloseSequenceAsync>d__10>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D837 RID: 55351 RVA: 0x0039D474 File Offset: 0x0039B674
	protected override void OnBeforeShow()
	{
		object openParam = this.OpenParam;
		int num2;
		if (openParam is int)
		{
			int num = (int)openParam;
			num2 = num;
		}
		else
		{
			num2 = 0;
		}
		int accumulateId = num2;
		this.Content.RefreshView(accumulateId);
	}

	// Token: 0x0600D838 RID: 55352 RVA: 0x0039D4AA File Offset: 0x0039B6AA
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x040066F8 RID: 26360
	[Nullable(2)]
	private GachaAccumulateBonusContentBase Content;

	// Token: 0x040066F9 RID: 26361
	private int CurrentAccumulateId;
}
