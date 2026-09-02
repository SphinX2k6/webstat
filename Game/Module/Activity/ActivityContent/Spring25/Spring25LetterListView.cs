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

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006367 RID: 25447
	[NullableContext(1)]
	[Nullable(0)]
	public class Spring25LetterListView : UiViewBase
	{
		// Token: 0x0603FE44 RID: 261700 RVA: 0x010637CF File Offset: 0x010619CF
		public Spring25LetterListView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009CDB RID: 40155
		// (get) Token: 0x0603FE45 RID: 261701 RVA: 0x010637D8 File Offset: 0x010619D8
		// (set) Token: 0x0603FE46 RID: 261702 RVA: 0x010637E0 File Offset: 0x010619E0
		private UiSequencePlayer Player { get; set; }

		// Token: 0x17009CDC RID: 40156
		// (get) Token: 0x0603FE47 RID: 261703 RVA: 0x010637E9 File Offset: 0x010619E9
		// (set) Token: 0x0603FE48 RID: 261704 RVA: 0x010637F1 File Offset: 0x010619F1
		private GenericLayout<TabItem, Spring25LetterListTabData> TabList { get; set; }

		// Token: 0x0603FE49 RID: 261705 RVA: 0x010637FC File Offset: 0x010619FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.HandleBackClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FE4A RID: 261706 RVA: 0x01063928 File Offset: 0x01061B28
		protected override UniTask OnBeforeStartAsync()
		{
			Spring25LetterListView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<Spring25LetterListView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE4B RID: 261707 RVA: 0x0106396B File Offset: 0x01061B6B
		protected override void OnStart()
		{
			this.RefreshByOpenParam();
		}

		// Token: 0x0603FE4C RID: 261708 RVA: 0x01063973 File Offset: 0x01061B73
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.Spring25CloseLetterList);
		}

		// Token: 0x0603FE4D RID: 261709 RVA: 0x01063985 File Offset: 0x01061B85
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.Spring25SelectLetter, new Action<int>(this.HandleSpring25SelectLetter));
		}

		// Token: 0x0603FE4E RID: 261710 RVA: 0x010639A3 File Offset: 0x01061BA3
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.Spring25SelectLetter, new Action<int>(this.HandleSpring25SelectLetter));
		}

		// Token: 0x0603FE4F RID: 261711 RVA: 0x010639C4 File Offset: 0x01061BC4
		private void RefreshByOpenParam()
		{
			Spring25LetterListViewData spring25LetterListViewData = this.OpenParam as Spring25LetterListViewData;
			if (spring25LetterListViewData == null)
			{
				return;
			}
			this.TabList.RefreshByData(spring25LetterListViewData.TabDataList, null, false);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), spring25LetterListViewData.InfoTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(4), spring25LetterListViewData.TitleTextId, Array.Empty<object>());
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
			if (scrollViewWithScrollbar != null)
			{
				FVector relativeLocation = scrollViewWithScrollbar.ContentUIItem.Get().RelativeLocation;
				FVector2D fvector2D = new FVector2D(ref relativeLocation);
				scrollViewWithScrollbar.ScrollToTop(ref fvector2D, base.GetText(1), false);
			}
		}

		// Token: 0x0603FE50 RID: 261712 RVA: 0x01063A64 File Offset: 0x01061C64
		private void HandleBackClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603FE51 RID: 261713 RVA: 0x01063A6D File Offset: 0x01061C6D
		private void HandleSpring25SelectLetter(int i)
		{
			this.OpenParam = ModelBase<Spring25Model>.Instance.BuildLetterListViewData();
			this.RefreshByOpenParam();
			this.Player.LiteReplayAsync("Switch", false, false);
		}

		// Token: 0x0603FE52 RID: 261714 RVA: 0x01063A98 File Offset: 0x01061C98
		private TabItem BuildItem()
		{
			return new TabItem();
		}

		// Token: 0x0200C3D0 RID: 50128
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403C50A RID: 247050
			public const int BackButton = 0;

			// Token: 0x0403C50B RID: 247051
			public const int InfoText = 1;

			// Token: 0x0403C50C RID: 247052
			public const int ContentLayout = 2;

			// Token: 0x0403C50D RID: 247053
			public const int ListTemplateItem = 3;

			// Token: 0x0403C50E RID: 247054
			public const int TitleText = 4;

			// Token: 0x0403C50F RID: 247055
			public const int LetterScroll = 5;
		}
	}
}
