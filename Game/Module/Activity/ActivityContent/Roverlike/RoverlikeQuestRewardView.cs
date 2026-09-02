using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006438 RID: 25656
	public class RoverlikeQuestRewardView : UiViewBase
	{
		// Token: 0x06040694 RID: 263828 RVA: 0x010834A4 File Offset: 0x010816A4
		[NullableContext(1)]
		public RoverlikeQuestRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040695 RID: 263829 RVA: 0x010834B0 File Offset: 0x010816B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnSpRewardBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040696 RID: 263830 RVA: 0x010835BC File Offset: 0x010817BC
		protected override void OnStart()
		{
			this.Caption = new PopupCaptionItem(base.GetItem(0));
			this.Caption.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.TaskScroll = new GenericScrollViewNew<RoverlikeQuestRewardItem, int>(base.GetScrollViewWithScrollbar(1), new Func<RoverlikeQuestRewardItem>(this.CreateTaskItem), null, false, null);
		}

		// Token: 0x06040697 RID: 263831 RVA: 0x01083613 File Offset: 0x01081813
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeQuestTaskUpdate, new Action(this.OnQuestTaskUpdate));
		}

		// Token: 0x06040698 RID: 263832 RVA: 0x01083631 File Offset: 0x01081831
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeQuestTaskUpdate, new Action(this.OnQuestTaskUpdate));
		}

		// Token: 0x06040699 RID: 263833 RVA: 0x0108364F File Offset: 0x0108184F
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x0604069A RID: 263834 RVA: 0x01083657 File Offset: 0x01081857
		[NullableContext(1)]
		private RoverlikeQuestRewardItem CreateTaskItem()
		{
			return new RoverlikeQuestRewardItem();
		}

		// Token: 0x0604069B RID: 263835 RVA: 0x01083660 File Offset: 0x01081860
		private void RefreshView()
		{
			RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			List<int> sortedTaskIdList = currentActivityData.QuestData.GetSortedTaskIdList();
			this.TaskScroll.RefreshByData(sortedTaskIdList, null, false);
			this.TaskScroll.PlayTurnAnimation();
			this.RefreshRestTime();
			this.RefreshProgress();
		}

		// Token: 0x0604069C RID: 263836 RVA: 0x010836B0 File Offset: 0x010818B0
		private void RefreshRestTime()
		{
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				text.SetText("", true);
				return;
			}
			string item = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(currentActivityData, null).Item2;
			text.SetText(item, true);
		}

		// Token: 0x0604069D RID: 263837 RVA: 0x01083700 File Offset: 0x01081900
		private void RefreshProgress()
		{
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0604069E RID: 263838 RVA: 0x01083720 File Offset: 0x01081920
		private void OnQuestTaskUpdate()
		{
			this.RefreshView();
		}

		// Token: 0x0604069F RID: 263839 RVA: 0x01083728 File Offset: 0x01081928
		private void OnSpRewardBtnClick()
		{
			RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			RoverRogueActivity? activityParamConfig = ConfigBase<RoverlikeConfig>.Instance.GetActivityParamConfig(currentActivityData.Id);
			int num = (activityParamConfig != null) ? activityParamConfig.GetValueOrDefault().TaskCoreReward : 0;
			if (num <= 0)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenTitleTipsByItemId(num);
		}

		// Token: 0x0402412A RID: 147754
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x0402412B RID: 147755
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<RoverlikeQuestRewardItem, int> TaskScroll;

		// Token: 0x0200C4AC RID: 50348
		private class EComponent
		{
			// Token: 0x0403C891 RID: 247953
			public const int Caption = 0;

			// Token: 0x0403C892 RID: 247954
			public const int TaskScroll = 1;

			// Token: 0x0403C893 RID: 247955
			public const int TaskItem = 2;

			// Token: 0x0403C894 RID: 247956
			public const int RestTime = 3;

			// Token: 0x0403C895 RID: 247957
			public const int Progress = 4;

			// Token: 0x0403C896 RID: 247958
			public const int SpRewardBtn = 5;
		}
	}
}
