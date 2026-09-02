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

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006599 RID: 26009
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballPermanentRewardView : UiTickViewBase
	{
		// Token: 0x06040FD8 RID: 266200 RVA: 0x010AD1EC File Offset: 0x010AB3EC
		public PinballPermanentRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040FD9 RID: 266201 RVA: 0x010AD1F8 File Offset: 0x010AB3F8
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

		// Token: 0x06040FDA RID: 266202 RVA: 0x010AD284 File Offset: 0x010AB484
		protected override void OnStart()
		{
			this.ActivityData = (this.OpenParam as PinballActivityData);
			PopupCaptionItem popupCaptionItem = new PopupCaptionItem(base.GetItem(0));
			popupCaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			popupCaptionItem.SetHelpBtnActive(false);
			this.TaskLayout = new GenericScrollViewNew<PinballPermanentRewardTaskItem, PinballTaskData>(base.GetScrollViewWithScrollbar(1), new Func<PinballPermanentRewardTaskItem>(this.CreateTaskItem), null, false, null);
			this.RefreshTaskLayout(true);
		}

		// Token: 0x06040FDB RID: 266203 RVA: 0x010AD2EE File Offset: 0x010AB4EE
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040FDC RID: 266204 RVA: 0x010AD30C File Offset: 0x010AB50C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040FDD RID: 266205 RVA: 0x010AD32A File Offset: 0x010AB52A
		private void OnRefreshCommonActivityRedDot(int id)
		{
			if (id != this.ActivityData.Id)
			{
				return;
			}
			this.RefreshTaskLayout(false);
		}

		// Token: 0x06040FDE RID: 266206 RVA: 0x010AD342 File Offset: 0x010AB542
		private void RefreshTaskLayout(bool isPlayAnim = false)
		{
			this.TaskLayout.RefreshByData(this.ActivityData.GetPermanentTaskList(), delegate
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
				if (scrollViewWithScrollbar == null)
				{
					return;
				}
				scrollViewWithScrollbar.SetScrollProgress(0f);
			}, isPlayAnim);
		}

		// Token: 0x06040FDF RID: 266207 RVA: 0x010AD367 File Offset: 0x010AB567
		private PinballPermanentRewardTaskItem CreateTaskItem()
		{
			return new PinballPermanentRewardTaskItem
			{
				OnTaskRewardClick = new Func<int, UniTask>(this.OnTaskRewardBtnClick)
			};
		}

		// Token: 0x06040FE0 RID: 266208 RVA: 0x010AD380 File Offset: 0x010AB580
		private UniTask OnTaskRewardBtnClick(int taskId)
		{
			PinballPermanentRewardView.<OnTaskRewardBtnClick>d__11 <OnTaskRewardBtnClick>d__;
			<OnTaskRewardBtnClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnTaskRewardBtnClick>d__.<>4__this = this;
			<OnTaskRewardBtnClick>d__.<>1__state = -1;
			<OnTaskRewardBtnClick>d__.<>t__builder.Start<PinballPermanentRewardView.<OnTaskRewardBtnClick>d__11>(ref <OnTaskRewardBtnClick>d__);
			return <OnTaskRewardBtnClick>d__.<>t__builder.Task;
		}

		// Token: 0x06040FE1 RID: 266209 RVA: 0x010AD3C3 File Offset: 0x010AB5C3
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402471B RID: 149275
		[Nullable(2)]
		private PinballActivityData ActivityData;

		// Token: 0x0402471C RID: 149276
		private GenericScrollViewNew<PinballPermanentRewardTaskItem, PinballTaskData> TaskLayout;

		// Token: 0x0200C58F RID: 50575
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403CCD8 RID: 249048
			ItemCaption,
			// Token: 0x0403CCD9 RID: 249049
			RewardItemScroll,
			// Token: 0x0403CCDA RID: 249050
			RewardItem
		}
	}
}
