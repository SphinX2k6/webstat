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

// Token: 0x02002BB0 RID: 11184
public class TermExplanationView : UiViewBase
{
	// Token: 0x06016450 RID: 91216 RVA: 0x0062B126 File Offset: 0x00629326
	[NullableContext(1)]
	public TermExplanationView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016451 RID: 91217 RVA: 0x0062B130 File Offset: 0x00629330
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnBtnCloseClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnBtnCloseClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016452 RID: 91218 RVA: 0x0062B2C0 File Offset: 0x006294C0
	protected override UniTask OnBeforeStartAsync()
	{
		TermExplanationView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TermExplanationView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016453 RID: 91219 RVA: 0x0062B303 File Offset: 0x00629503
	protected override void OnBeforeShow()
	{
		this.OnTweenStart();
	}

	// Token: 0x06016454 RID: 91220 RVA: 0x0062B30C File Offset: 0x0062950C
	protected override void OnAfterShow()
	{
		TermExplanationViewParam termExplanationViewParam = this.OpenParam as TermExplanationViewParam;
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(2);
		if (termExplanationViewParam == null || termExplanationViewParam.FocusedHyperLink == null)
		{
			return;
		}
		UUIItem itemByIndex = this.ScrollView.GetItemByIndex(termExplanationViewParam.HyperLinkList.IndexOf(termExplanationViewParam.FocusedHyperLink));
		FVector relativeLocation = scrollViewWithScrollbar.ContentUIItem.Get().RelativeLocation;
		FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
		scrollViewWithScrollbar.ScrollToTop(ref fvector2D, itemByIndex, true);
		ULTweener tweener = scrollViewWithScrollbar.Tweener;
		if (tweener != null)
		{
			tweener.OnStartCallBack.Bind(new Action(this.OnTweenStart));
		}
		ULTweener tweener2 = scrollViewWithScrollbar.Tweener;
		if (tweener2 != null)
		{
			tweener2.OnCompleteCallBack.Bind(new Action(this.OnTweenComplete));
		}
		if (scrollViewWithScrollbar.Tweener == null)
		{
			this.OnTweenComplete();
		}
	}

	// Token: 0x06016455 RID: 91221 RVA: 0x0062B3DC File Offset: 0x006295DC
	protected override void OnBeforeDestroy()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(2);
		if (scrollViewWithScrollbar != null)
		{
			ULTweener tweener = scrollViewWithScrollbar.Tweener;
			if (tweener == null)
			{
				return;
			}
			tweener.OnCompleteCallBack.Unbind();
		}
	}

	// Token: 0x06016456 RID: 91222 RVA: 0x0062B409 File Offset: 0x00629609
	protected override void OnAfterDestroy()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnTermExplanationViewClosed);
	}

	// Token: 0x06016457 RID: 91223 RVA: 0x0062B41B File Offset: 0x0062961B
	[NullableContext(2)]
	public UUIItem GetTipItem()
	{
		return base.GetItem(7);
	}

	// Token: 0x06016458 RID: 91224 RVA: 0x0062B424 File Offset: 0x00629624
	[NullableContext(1)]
	private ExplanationItem GetGrid()
	{
		return new ExplanationItem();
	}

	// Token: 0x06016459 RID: 91225 RVA: 0x0062B42B File Offset: 0x0062962B
	private void OnBtnCloseClick()
	{
		if (this.IsClosing)
		{
			return;
		}
		this.IsClosing = true;
		base.CloseMe(null);
	}

	// Token: 0x0601645A RID: 91226 RVA: 0x0062B444 File Offset: 0x00629644
	private void OnTweenStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(2);
		scrollViewWithScrollbar.ContentUIItem.Get().SetBubbleUpToParent(false);
		scrollViewWithScrollbar.SetRayCastTargetForScrollView(false);
	}

	// Token: 0x0601645B RID: 91227 RVA: 0x0062B474 File Offset: 0x00629674
	private void OnTweenComplete()
	{
		TermExplanationViewParam termExplanationViewParam = this.OpenParam as TermExplanationViewParam;
		int gridIndex = termExplanationViewParam.HyperLinkList.IndexOf(termExplanationViewParam.FocusedHyperLink);
		this.ScrollView.SelectGridProxy(gridIndex, false);
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(2);
		scrollViewWithScrollbar.ContentUIItem.Get().SetBubbleUpToParent(true);
		scrollViewWithScrollbar.SetRayCastTargetForScrollView(true);
	}

	// Token: 0x0400AC5B RID: 44123
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ExplanationItem, string> ScrollView;

	// Token: 0x0400AC5C RID: 44124
	private bool IsClosing;

	// Token: 0x02008EAB RID: 36523
	private class EComponentDefine
	{
		// Token: 0x0402FF1A RID: 196378
		public const int SpriteLight = 0;

		// Token: 0x0402FF1B RID: 196379
		public const int TextTitle = 1;

		// Token: 0x0402FF1C RID: 196380
		public const int ScrollItemList = 2;

		// Token: 0x0402FF1D RID: 196381
		public const int LayoutContent = 3;

		// Token: 0x0402FF1E RID: 196382
		public const int ItemExplanation = 4;

		// Token: 0x0402FF1F RID: 196383
		public const int BtnClose = 5;

		// Token: 0x0402FF20 RID: 196384
		public const int ItemBtnClose = 6;

		// Token: 0x0402FF21 RID: 196385
		public const int ItemTip = 7;
	}
}
