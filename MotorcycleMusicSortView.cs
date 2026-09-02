using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002323 RID: 8995
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleMusicSortView : UiTickViewBase
{
	// Token: 0x060111CD RID: 70093 RVA: 0x004B3A77 File Offset: 0x004B1C77
	public MotorcycleMusicSortView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060111CE RID: 70094 RVA: 0x004B3A80 File Offset: 0x004B1C80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x060111CF RID: 70095 RVA: 0x004B3B06 File Offset: 0x004B1D06
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnMotorMusicSortDragCancel, new Action(this.OnMotorMusicSortDragCancel));
	}

	// Token: 0x060111D0 RID: 70096 RVA: 0x004B3B24 File Offset: 0x004B1D24
	private void OnMotorMusicSortDragCancel()
	{
		DragSortScrollView<MotorcycleMusicSortItem, int> scrollView = this.ScrollView;
		if (scrollView != null && scrollView.IsDragging())
		{
			this.ScrollView.CancelDrag();
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x060111D1 RID: 70097 RVA: 0x004B3B4D File Offset: 0x004B1D4D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorMusicSortDragCancel, new Action(this.OnMotorMusicSortDragCancel));
	}

	// Token: 0x060111D2 RID: 70098 RVA: 0x004B3B6C File Offset: 0x004B1D6C
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleMusicSortView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleMusicSortView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060111D3 RID: 70099 RVA: 0x004B3BAF File Offset: 0x004B1DAF
	private void OnDragBeginCallback(DragSortGridAbstract<int> item)
	{
		UUIItem item2 = base.GetItem(0);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x060111D4 RID: 70100 RVA: 0x004B3BC3 File Offset: 0x004B1DC3
	private void OnDragEndCallback(DragSortGridAbstract<int> item)
	{
		UUIItem item2 = base.GetItem(0);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(true);
	}

	// Token: 0x060111D5 RID: 70101 RVA: 0x004B3BD7 File Offset: 0x004B1DD7
	private MotorcycleMusicSortItem CreateItem()
	{
		return new MotorcycleMusicSortItem();
	}

	// Token: 0x060111D6 RID: 70102 RVA: 0x004B3BDE File Offset: 0x004B1DDE
	protected override void OnTick(float delta)
	{
		DragSortScrollView<MotorcycleMusicSortItem, int> scrollView = this.ScrollView;
		if (scrollView == null)
		{
			return;
		}
		scrollView.Tick(delta);
	}

	// Token: 0x060111D7 RID: 70103 RVA: 0x004B3BF1 File Offset: 0x004B1DF1
	protected override void OnAfterTick(float delta)
	{
	}

	// Token: 0x060111D8 RID: 70104 RVA: 0x004B3BF3 File Offset: 0x004B1DF3
	protected override void OnBeforeDestroy()
	{
		DragSortScrollView<MotorcycleMusicSortItem, int> scrollView = this.ScrollView;
		if (scrollView != null && scrollView.HasChanged())
		{
			Action<List<int>> onCallback = this.OnCallback;
			if (onCallback == null)
			{
				return;
			}
			onCallback(this.ScrollView.GetSortedData());
		}
	}

	// Token: 0x060111D9 RID: 70105 RVA: 0x004B3C24 File Offset: 0x004B1E24
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x04008690 RID: 34448
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private DragSortScrollView<MotorcycleMusicSortItem, int> ScrollView;

	// Token: 0x04008691 RID: 34449
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<List<int>> OnCallback;

	// Token: 0x02008633 RID: 34355
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402D634 RID: 185908
		public const int ItemCaption = 0;

		// Token: 0x0402D635 RID: 185909
		public const int BtnMask = 1;

		// Token: 0x0402D636 RID: 185910
		public const int SvDefault = 2;

		// Token: 0x0402D637 RID: 185911
		public const int Content = 3;

		// Token: 0x0402D638 RID: 185912
		public const int ListItem = 4;
	}
}
