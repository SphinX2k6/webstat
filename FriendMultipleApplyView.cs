using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CA4 RID: 7332
public class FriendMultipleApplyView : UiTickViewBase
{
	// Token: 0x0600D706 RID: 55046 RVA: 0x00397044 File Offset: 0x00395244
	[NullableContext(1)]
	public FriendMultipleApplyView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D707 RID: 55047 RVA: 0x00397050 File Offset: 0x00395250
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D708 RID: 55048 RVA: 0x003970B9 File Offset: 0x003952B9
	protected override void OnStart()
	{
		this.ApplyDataList = (this.OpenParam as List<FriendApplyData>);
		this.InitLoopScrollView();
	}

	// Token: 0x0600D709 RID: 55049 RVA: 0x003970D2 File Offset: 0x003952D2
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshFriendApplicationRedDot, new Action(this.OnRefreshLoopScrollView));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FriendOnMultiItemAction, new Action<int>(this.HandleFriendOnMultiItemAction));
	}

	// Token: 0x0600D70A RID: 55050 RVA: 0x0039710C File Offset: 0x0039530C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshFriendApplicationRedDot, new Action(this.OnRefreshLoopScrollView));
		Singleton<EventSystem>.Instance.Remove(EEventName.FriendOnMultiItemAction, new Action<int>(this.HandleFriendOnMultiItemAction));
	}

	// Token: 0x0600D70B RID: 55051 RVA: 0x00397148 File Offset: 0x00395348
	protected override void OnTick(float delta)
	{
		if (this.HallLoopScroll.StartGridIndex < 0)
		{
			return;
		}
		int displayGridNum = this.HallLoopScroll.GetDisplayGridNum();
		for (int i = this.HallLoopScroll.StartGridIndex; i < displayGridNum; i++)
		{
			FriendMultipleApplyItem friendMultipleApplyItem = this.HallLoopScroll.UnsafeGetGridProxy(i, false);
			if (friendMultipleApplyItem != null)
			{
				friendMultipleApplyItem.UpdateCountDownProgressBar();
			}
		}
	}

	// Token: 0x0600D70C RID: 55052 RVA: 0x0039719E File Offset: 0x0039539E
	protected override void OnBeforeDestroy()
	{
		if (this.HallLoopScroll != null)
		{
			this.HallLoopScroll.ClearGridProxies();
		}
		this.HallLoopScroll = null;
	}

	// Token: 0x0600D70D RID: 55053 RVA: 0x003971BA File Offset: 0x003953BA
	public void RefreshLoopScrollView()
	{
		this.HallLoopScroll.RefreshByData(this.ApplyDataList, false, null, false);
	}

	// Token: 0x0600D70E RID: 55054 RVA: 0x003971D0 File Offset: 0x003953D0
	private void InitLoopScrollView()
	{
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(0);
		AUIBaseActor gridActor = base.GetItem(1).GetOwner() as AUIBaseActor;
		this.HallLoopScroll = new LoopScrollView<FriendMultipleApplyItem, FriendApplyData>(loopScrollViewComponent, gridActor, new Func<FriendMultipleApplyItem>(this.ProxyCreateFunction), false);
		this.RefreshLoopScrollView();
	}

	// Token: 0x0600D70F RID: 55055 RVA: 0x00397217 File Offset: 0x00395417
	[NullableContext(1)]
	private FriendMultipleApplyItem ProxyCreateFunction()
	{
		return new FriendMultipleApplyItem();
	}

	// Token: 0x0600D710 RID: 55056 RVA: 0x0039721E File Offset: 0x0039541E
	private void OnRefreshLoopScrollView()
	{
		if (this.ApplyDataList.Count <= 0)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendMultipleApplyView, null);
		}
		this.HallLoopScroll.RefreshByData(this.ApplyDataList, false, null, false);
	}

	// Token: 0x0600D711 RID: 55057 RVA: 0x00397252 File Offset: 0x00395452
	private void HandleFriendOnMultiItemAction(int playerId)
	{
		base.CloseMe(null);
	}

	// Token: 0x040065F0 RID: 26096
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<FriendMultipleApplyItem, FriendApplyData> HallLoopScroll;

	// Token: 0x040065F1 RID: 26097
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FriendApplyData> ApplyDataList;

	// Token: 0x02007FF9 RID: 32761
	private class EFriendMultipleApplyView
	{
		// Token: 0x0402B8C3 RID: 178371
		public const int LoopScrollView = 0;

		// Token: 0x0402B8C4 RID: 178372
		public const int ScrollTemp = 1;
	}
}
