using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200190C RID: 6412
[NullableContext(2)]
[Nullable(0)]
public class PhantomBatchConfirmPopupView : UiViewBase
{
	// Token: 0x0600B83C RID: 47164 RVA: 0x0030F4B5 File Offset: 0x0030D6B5
	[NullableContext(1)]
	public PhantomBatchConfirmPopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B83D RID: 47165 RVA: 0x0030F4C0 File Offset: 0x0030D6C0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B83E RID: 47166 RVA: 0x0030F5F0 File Offset: 0x0030D7F0
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomBatchConfirmPopupView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomBatchConfirmPopupView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B83F RID: 47167 RVA: 0x0030F634 File Offset: 0x0030D834
	protected override void OnStart()
	{
		this.ViewData = (this.OpenParam as IPhantomConfirmPopupViewData);
		this.LoopScrollView = new LoopScrollView<PhantomConfirmMediumItemGrid, int>(base.GetLoopScrollViewComponent(2), base.GetItem(3).GetOwner() as AUIBaseActor, new Func<PhantomConfirmMediumItemGrid>(this.CreateGridItem), false);
		IPhantomConfirmPopupViewData viewData = this.ViewData;
		if (((viewData != null) ? viewData.OnLeft : null) != null)
		{
			ButtonItem leftButton = this.LeftButton;
			if (leftButton != null)
			{
				leftButton.SetUiActive(true);
			}
			ButtonItem leftButton2 = this.LeftButton;
			if (leftButton2 != null)
			{
				leftButton2.SetFunction(new Action<int>(this.OnClickLeft));
			}
			ButtonItem leftButton3 = this.LeftButton;
			if (leftButton3 != null)
			{
				leftButton3.SetShowText(this.ViewData.LeftTxtKey);
			}
		}
		else
		{
			ButtonItem leftButton4 = this.LeftButton;
			if (leftButton4 != null)
			{
				leftButton4.SetUiActive(false);
			}
		}
		IPhantomConfirmPopupViewData viewData2 = this.ViewData;
		if (((viewData2 != null) ? viewData2.OnMiddle : null) != null)
		{
			ButtonItem middleButton = this.MiddleButton;
			if (middleButton != null)
			{
				middleButton.SetUiActive(true);
			}
			ButtonItem middleButton2 = this.MiddleButton;
			if (middleButton2 != null)
			{
				middleButton2.SetFunction(new Action<int>(this.OnClickMiddle));
			}
			ButtonItem middleButton3 = this.MiddleButton;
			if (middleButton3 != null)
			{
				middleButton3.SetShowText(this.ViewData.MiddleTxtKey);
			}
		}
		else
		{
			ButtonItem middleButton4 = this.MiddleButton;
			if (middleButton4 != null)
			{
				middleButton4.SetUiActive(false);
			}
		}
		IPhantomConfirmPopupViewData viewData3 = this.ViewData;
		if (((viewData3 != null) ? viewData3.OnRight : null) != null)
		{
			ButtonItem rightButton = this.RightButton;
			if (rightButton != null)
			{
				rightButton.SetUiActive(true);
			}
			ButtonItem rightButton2 = this.RightButton;
			if (rightButton2 != null)
			{
				rightButton2.SetFunction(new Action<int>(this.OnClickRight));
			}
			ButtonItem rightButton3 = this.RightButton;
			if (rightButton3 != null)
			{
				rightButton3.SetShowText(this.ViewData.RightTxtKey);
			}
		}
		else
		{
			ButtonItem rightButton4 = this.RightButton;
			if (rightButton4 != null)
			{
				rightButton4.SetUiActive(false);
			}
		}
		this.RefreshView();
	}

	// Token: 0x0600B840 RID: 47168 RVA: 0x0030F7E1 File Offset: 0x0030D9E1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnItemFuncValueBatchChange, new Action<IReadOnlyList<int>>(this.OnItemFuncValueBatchChange));
	}

	// Token: 0x0600B841 RID: 47169 RVA: 0x0030F81B File Offset: 0x0030DA1B
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueBatchChange, new Action<IReadOnlyList<int>>(this.OnItemFuncValueBatchChange));
	}

	// Token: 0x0600B842 RID: 47170 RVA: 0x0030F858 File Offset: 0x0030DA58
	private void RefreshView()
	{
		if (this.ViewData == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.ShowTextNew(this.ViewData.Title);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "PhantomBatchConfirmCount", new <>z__ReadOnlySingleElementList<object>(this.ViewData.PhantomUniqueIdList.Count));
		}
		UUIText text3 = base.GetText(6);
		if (text3 != null)
		{
			text3.ShowTextNew(this.ViewData.SubTitle);
		}
		LoopScrollView<PhantomConfirmMediumItemGrid, int> loopScrollView = this.LoopScrollView;
		if (loopScrollView == null)
		{
			return;
		}
		loopScrollView.RefreshByData(this.ViewData.PhantomUniqueIdList, false, null, false);
	}

	// Token: 0x0600B843 RID: 47171 RVA: 0x0030F8F9 File Offset: 0x0030DAF9
	[NullableContext(1)]
	private PhantomConfirmMediumItemGrid CreateGridItem()
	{
		PhantomConfirmMediumItemGrid phantomConfirmMediumItemGrid = new PhantomConfirmMediumItemGrid();
		phantomConfirmMediumItemGrid.SetUseFixedAsync(true);
		return phantomConfirmMediumItemGrid;
	}

	// Token: 0x0600B844 RID: 47172 RVA: 0x0030F907 File Offset: 0x0030DB07
	private void OnClickLeft(int _)
	{
		IPhantomConfirmPopupViewData viewData = this.ViewData;
		if (viewData != null)
		{
			Action onLeft = viewData.OnLeft;
			if (onLeft != null)
			{
				onLeft();
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x0600B845 RID: 47173 RVA: 0x0030F92C File Offset: 0x0030DB2C
	private void OnClickMiddle(int _)
	{
		IPhantomConfirmPopupViewData viewData = this.ViewData;
		if (viewData != null)
		{
			Action onMiddle = viewData.OnMiddle;
			if (onMiddle != null)
			{
				onMiddle();
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x0600B846 RID: 47174 RVA: 0x0030F951 File Offset: 0x0030DB51
	private void OnClickRight(int _)
	{
		IPhantomConfirmPopupViewData viewData = this.ViewData;
		if (viewData != null)
		{
			Action onRight = viewData.OnRight;
			if (onRight != null)
			{
				onRight();
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x0600B847 RID: 47175 RVA: 0x0030F978 File Offset: 0x0030DB78
	private void OnItemFuncValueChange(int changeId)
	{
		int i = 0;
		while (i < this.ViewData.PhantomUniqueIdList.Count)
		{
			int num = this.ViewData.PhantomUniqueIdList[i];
			if (changeId == num)
			{
				LoopScrollView<PhantomConfirmMediumItemGrid, int> loopScrollView = this.LoopScrollView;
				if (loopScrollView == null)
				{
					return;
				}
				loopScrollView.RefreshGridProxy(i);
				return;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600B848 RID: 47176 RVA: 0x0030F9C8 File Offset: 0x0030DBC8
	[NullableContext(1)]
	private void OnItemFuncValueBatchChange(IReadOnlyList<int> uniqueIdList)
	{
		HashSet<int> hashSet = new HashSet<int>(uniqueIdList);
		for (int i = 0; i < this.ViewData.PhantomUniqueIdList.Count; i++)
		{
			int item = this.ViewData.PhantomUniqueIdList[i];
			if (hashSet.Contains(item))
			{
				LoopScrollView<PhantomConfirmMediumItemGrid, int> loopScrollView = this.LoopScrollView;
				if (loopScrollView != null)
				{
					loopScrollView.RefreshGridProxy(i);
				}
			}
		}
	}

	// Token: 0x040056CD RID: 22221
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<PhantomConfirmMediumItemGrid, int> LoopScrollView;

	// Token: 0x040056CE RID: 22222
	private ButtonItem LeftButton;

	// Token: 0x040056CF RID: 22223
	private ButtonItem MiddleButton;

	// Token: 0x040056D0 RID: 22224
	private ButtonItem RightButton;

	// Token: 0x040056D1 RID: 22225
	private IPhantomConfirmPopupViewData ViewData;

	// Token: 0x02007C5A RID: 31834
	[NullableContext(0)]
	private class EPhantomBatchConfirmComp
	{
		// Token: 0x0402A796 RID: 173974
		public const int TxtTitle = 0;

		// Token: 0x0402A797 RID: 173975
		public const int TxtCount = 1;

		// Token: 0x0402A798 RID: 173976
		public const int Scroller = 2;

		// Token: 0x0402A799 RID: 173977
		public const int LoopItem = 3;

		// Token: 0x0402A79A RID: 173978
		public const int BtnLeft = 4;

		// Token: 0x0402A79B RID: 173979
		public const int BtnMiddle = 5;

		// Token: 0x0402A79C RID: 173980
		public const int TxtSubTitle = 6;

		// Token: 0x0402A79D RID: 173981
		public const int BtnRight = 7;
	}
}
