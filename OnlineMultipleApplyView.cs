using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200234A RID: 9034
public class OnlineMultipleApplyView : UiTickViewBase
{
	// Token: 0x06011403 RID: 70659 RVA: 0x004BDC27 File Offset: 0x004BBE27
	[NullableContext(1)]
	public OnlineMultipleApplyView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011404 RID: 70660 RVA: 0x004BDC30 File Offset: 0x004BBE30
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

	// Token: 0x06011405 RID: 70661 RVA: 0x004BDC99 File Offset: 0x004BBE99
	protected override void OnStart()
	{
		this.InitLoopScrollView();
	}

	// Token: 0x06011406 RID: 70662 RVA: 0x004BDCA1 File Offset: 0x004BBEA1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshApply, new Action(this.OnRefreshLoopScrollView));
	}

	// Token: 0x06011407 RID: 70663 RVA: 0x004BDCBF File Offset: 0x004BBEBF
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshApply, new Action(this.OnRefreshLoopScrollView));
	}

	// Token: 0x06011408 RID: 70664 RVA: 0x004BDCE0 File Offset: 0x004BBEE0
	protected override void OnTick(float delta)
	{
		if (this.HallLoopScroll.StartGridIndex < 0)
		{
			return;
		}
		int displayGridNum = this.HallLoopScroll.GetDisplayGridNum();
		for (int i = this.HallLoopScroll.StartGridIndex; i < displayGridNum; i++)
		{
			OnlineMultipleApplyItem onlineMultipleApplyItem = this.HallLoopScroll.UnsafeGetGridProxy(i, false);
			if (onlineMultipleApplyItem != null)
			{
				onlineMultipleApplyItem.UpdateCountDownProgressBar();
			}
		}
	}

	// Token: 0x06011409 RID: 70665 RVA: 0x004BDD36 File Offset: 0x004BBF36
	protected override void OnBeforeDestroy()
	{
		if (this.HallLoopScroll != null)
		{
			this.HallLoopScroll.ClearGridProxies();
		}
		if (ModelBase<OnlineModel>.Instance.GetCurrentApplyList().Length != 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineApplyView, null, null);
		}
		this.HallLoopScroll = null;
	}

	// Token: 0x0601140A RID: 70666 RVA: 0x004BDD70 File Offset: 0x004BBF70
	public void RefreshLoopScrollView()
	{
		this.HallLoopScroll.ReloadData(ModelBase<OnlineModel>.Instance.GetCurrentApplyList(), false);
	}

	// Token: 0x0601140B RID: 70667 RVA: 0x004BDD88 File Offset: 0x004BBF88
	private void InitLoopScrollView()
	{
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(0);
		AUIBaseActor gridActor = base.GetItem(1).GetOwner() as AUIBaseActor;
		this.HallLoopScroll = new LoopScrollView<OnlineMultipleApplyItem, OnlineApplyData>(loopScrollViewComponent, gridActor, new Func<OnlineMultipleApplyItem>(this.ProxyCreateFunction), false);
		this.RefreshLoopScrollView();
	}

	// Token: 0x0601140C RID: 70668 RVA: 0x004BDDCF File Offset: 0x004BBFCF
	[NullableContext(1)]
	private OnlineMultipleApplyItem ProxyCreateFunction()
	{
		return new OnlineMultipleApplyItem();
	}

	// Token: 0x0601140D RID: 70669 RVA: 0x004BDDD8 File Offset: 0x004BBFD8
	private void OnRefreshLoopScrollView()
	{
		OnlineApplyData[] currentApplyList = ModelBase<OnlineModel>.Instance.GetCurrentApplyList();
		if (currentApplyList.Length == 0)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineMultipleApplyView, null);
		}
		this.HallLoopScroll.ReloadData(currentApplyList, false);
	}

	// Token: 0x0400878C RID: 34700
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<OnlineMultipleApplyItem, OnlineApplyData> HallLoopScroll;

	// Token: 0x02008662 RID: 34402
	private enum EOnlineMultipleApplyView
	{
		// Token: 0x0402D745 RID: 186181
		LoopScrollView,
		// Token: 0x0402D746 RID: 186182
		ScrollTemp
	}
}
