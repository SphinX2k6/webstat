using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x0200684E RID: 26702
	[NullableContext(1)]
	[Nullable(0)]
	public class FeiXuePreheatRewardView : UiTickViewBase
	{
		// Token: 0x060428BB RID: 272571 RVA: 0x01114E55 File Offset: 0x01113055
		public FeiXuePreheatRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060428BC RID: 272572 RVA: 0x01114E60 File Offset: 0x01113060
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x060428BD RID: 272573 RVA: 0x01114ED0 File Offset: 0x011130D0
		protected override void OnStart()
		{
			this.ActivityData = (this.OpenParam as ActivityFeiXuePreheatData);
			new PopupCaptionItem(base.GetItem(0)).SetCloseCallBack(new Action(this.OnCloseBtnClick));
			this.TaskLayout = new GenericScrollViewNew<FeiXuePreheatTaskItem, FeiXuePreheatTaskData>(base.GetScrollViewWithScrollbar(1), new Func<FeiXuePreheatTaskItem>(this.CreateTaskItem), null, false, null);
			this.RefreshTaskLayout(true);
		}

		// Token: 0x060428BE RID: 272574 RVA: 0x01114F33 File Offset: 0x01113133
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060428BF RID: 272575 RVA: 0x01114F51 File Offset: 0x01113151
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060428C0 RID: 272576 RVA: 0x01114F70 File Offset: 0x01113170
		protected override void OnTick(float delta)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, localTextNew);
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x060428C1 RID: 272577 RVA: 0x01114FB3 File Offset: 0x011131B3
		private void OnRefreshCommonActivityRedDot(int id)
		{
			if (id != this.ActivityData.Id)
			{
				return;
			}
			this.RefreshTaskLayout(false);
		}

		// Token: 0x060428C2 RID: 272578 RVA: 0x01114FCB File Offset: 0x011131CB
		private void RefreshTaskLayout(bool isPlayAnim = false)
		{
			this.TaskLayout.RefreshByData(this.ActivityData.GetTaskDataSortList(), delegate
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
				if (scrollViewWithScrollbar == null)
				{
					return;
				}
				scrollViewWithScrollbar.SetScrollProgress(0f);
			}, isPlayAnim);
		}

		// Token: 0x060428C3 RID: 272579 RVA: 0x01114FF0 File Offset: 0x011131F0
		private FeiXuePreheatTaskItem CreateTaskItem()
		{
			return new FeiXuePreheatTaskItem
			{
				OnRewardBtnClick = new Action(this.OnRewardBtnClick)
			};
		}

		// Token: 0x060428C4 RID: 272580 RVA: 0x01115009 File Offset: 0x01113209
		private void OnRewardBtnClick()
		{
			ControllerBase<ActivityFeiXuePreheatController>.Instance.RequestTaskReward(this.ActivityData.Id, null);
		}

		// Token: 0x060428C5 RID: 272581 RVA: 0x01115021 File Offset: 0x01113221
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x040250DC RID: 151772
		[Nullable(2)]
		private ActivityFeiXuePreheatData ActivityData;

		// Token: 0x040250DD RID: 151773
		private GenericScrollViewNew<FeiXuePreheatTaskItem, FeiXuePreheatTaskData> TaskLayout;
	}
}
