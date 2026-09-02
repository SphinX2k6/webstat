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

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006769 RID: 26473
	[NullableContext(1)]
	[Nullable(0)]
	public class LineCrossEntranceView : UiViewBase
	{
		// Token: 0x06041FE1 RID: 270305 RVA: 0x010EE905 File Offset: 0x010ECB05
		public LineCrossEntranceView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041FE2 RID: 270306 RVA: 0x010EE910 File Offset: 0x010ECB10
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041FE3 RID: 270307 RVA: 0x010EE99C File Offset: 0x010ECB9C
		protected override UniTask OnBeforeStartAsync()
		{
			LineCrossEntranceView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LineCrossEntranceView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041FE4 RID: 270308 RVA: 0x010EE9DF File Offset: 0x010ECBDF
		private LineCrossItem CreateItem()
		{
			return new LineCrossItem();
		}

		// Token: 0x06041FE5 RID: 270309 RVA: 0x010EE9E6 File Offset: 0x010ECBE6
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041FE6 RID: 270310 RVA: 0x010EE9EF File Offset: 0x010ECBEF
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x06041FE7 RID: 270311 RVA: 0x010EE9F7 File Offset: 0x010ECBF7
		private void RefreshView()
		{
			this.RefreshScroller();
		}

		// Token: 0x06041FE8 RID: 270312 RVA: 0x010EEA00 File Offset: 0x010ECC00
		private UniTask RefreshScroller()
		{
			LineCrossEntranceView.<RefreshScroller>d__10 <RefreshScroller>d__;
			<RefreshScroller>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshScroller>d__.<>4__this = this;
			<RefreshScroller>d__.<>1__state = -1;
			<RefreshScroller>d__.<>t__builder.Start<LineCrossEntranceView.<RefreshScroller>d__10>(ref <RefreshScroller>d__);
			return <RefreshScroller>d__.<>t__builder.Task;
		}

		// Token: 0x06041FE9 RID: 270313 RVA: 0x010EEA43 File Offset: 0x010ECC43
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.LineCrossActivityData.Id);
		}

		// Token: 0x06041FEA RID: 270314 RVA: 0x010EEA60 File Offset: 0x010ECC60
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "FirstLevel"))
			{
				return null;
			}
			GenericScrollViewNew<LineCrossItem, ItemData> scrollView = this.ScrollView;
			UUIItem uuiitem = (scrollView != null) ? scrollView.GetItemByIndex(0) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04024CF1 RID: 150769
		private LineCrossActivityData LineCrossActivityData;

		// Token: 0x04024CF2 RID: 150770
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024CF3 RID: 150771
		protected GenericScrollViewNew<LineCrossItem, ItemData> ScrollView;

		// Token: 0x0200C785 RID: 51077
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D6D1 RID: 251601
			public const int CaptionItem = 0;

			// Token: 0x0403D6D2 RID: 251602
			public const int Scroller = 1;

			// Token: 0x0403D6D3 RID: 251603
			public const int Item = 2;
		}
	}
}
