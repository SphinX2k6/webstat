using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D6F RID: 23919
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeRewardView : UiTickViewBase
	{
		// Token: 0x0603C414 RID: 246804 RVA: 0x00F49926 File Offset: 0x00F47B26
		public FlagChallengeRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C415 RID: 246805 RVA: 0x00F4993C File Offset: 0x00F47B3C
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

		// Token: 0x0603C416 RID: 246806 RVA: 0x00F499AC File Offset: 0x00F47BAC
		protected override void OnStart()
		{
			this.ActivityId = (int)this.OpenParam;
			this.PopupCaption = new PopupCaptionItem(base.GetItem(0));
			this.PopupCaption.SetCloseCallBack(new Action(this.OnBtnClose));
			if (ConfigBase<FlagChallengeConfig>.Instance.GetRewardHelpId() != 0)
			{
				this.PopupCaption.SetHelpBtnActive(true);
				this.PopupCaption.SetHelpCallBack(new Action(this.OnBtnHelp));
			}
			else
			{
				this.PopupCaption.SetHelpBtnActive(false);
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
			AUIBaseActor gridActor = base.GetItem(2).GetOwner() as AUIBaseActor;
			this.RewardScroll = new GenericScrollViewNew<FlagChallengeRewardItem, FlagChallengeTaskData>(scrollViewWithScrollbar, new Func<FlagChallengeRewardItem>(this.CreateRewardItem), gridActor, false, null);
			this.RefreshScrollView();
			this.TimeText = base.GetText(3);
			this.ActivityData = (ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityFlagChallengeData);
			this.RemainTimeFormatText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			this.RefreshRemainTime();
		}

		// Token: 0x0603C417 RID: 246807 RVA: 0x00F49AAA File Offset: 0x00F47CAA
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnTaskUpdate));
		}

		// Token: 0x0603C418 RID: 246808 RVA: 0x00F49AC8 File Offset: 0x00F47CC8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnTaskUpdate));
		}

		// Token: 0x0603C419 RID: 246809 RVA: 0x00F49AE6 File Offset: 0x00F47CE6
		protected override void OnTick(float delta)
		{
			this.RefreshRemainTime();
		}

		// Token: 0x0603C41A RID: 246810 RVA: 0x00F49AF0 File Offset: 0x00F47CF0
		private void RefreshRemainTime()
		{
			if (this.TimeText == null || this.ActivityData == null)
			{
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, this.RemainTimeFormatText);
			this.TimeText.SetText(remainTimeText, true);
		}

		// Token: 0x0603C41B RID: 246811 RVA: 0x00F49B38 File Offset: 0x00F47D38
		private void RefreshScrollView()
		{
			List<FlagChallengeTaskData> taskDataList = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).GetTaskDataList();
			this.RewardScroll.RefreshByData(taskDataList, null, true);
		}

		// Token: 0x0603C41C RID: 246812 RVA: 0x00F49B69 File Offset: 0x00F47D69
		private void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C41D RID: 246813 RVA: 0x00F49B72 File Offset: 0x00F47D72
		private FlagChallengeRewardItem CreateRewardItem()
		{
			FlagChallengeRewardItem flagChallengeRewardItem = new FlagChallengeRewardItem();
			flagChallengeRewardItem.SetReceiveCallback(new Action<FlagChallengeTaskData>(this.OnReceiveCallback));
			return flagChallengeRewardItem;
		}

		// Token: 0x0603C41E RID: 246814 RVA: 0x00F49B8C File Offset: 0x00F47D8C
		private void OnBtnHelp()
		{
			int rewardHelpId = ConfigBase<FlagChallengeConfig>.Instance.GetRewardHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(rewardHelpId);
		}

		// Token: 0x0603C41F RID: 246815 RVA: 0x00F49BB0 File Offset: 0x00F47DB0
		private void OnReceiveCallback(FlagChallengeTaskData taskData)
		{
			List<int> canReceiveTaskIdList = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).GetCanReceiveTaskIdList();
			ControllerBase<FlagChallengeController>.Instance.RequestFlagChallengeReward(this.ActivityId, canReceiveTaskIdList);
		}

		// Token: 0x0603C420 RID: 246816 RVA: 0x00F49BE4 File Offset: 0x00F47DE4
		private void OnTaskUpdate(int activityId)
		{
			if (activityId != this.ActivityId)
			{
				return;
			}
			this.RefreshScrollView();
		}

		// Token: 0x04021DF9 RID: 138745
		private int ActivityId;

		// Token: 0x04021DFA RID: 138746
		private PopupCaptionItem PopupCaption;

		// Token: 0x04021DFB RID: 138747
		private GenericScrollViewNew<FlagChallengeRewardItem, FlagChallengeTaskData> RewardScroll;

		// Token: 0x04021DFC RID: 138748
		[Nullable(2)]
		private UUIText TimeText;

		// Token: 0x04021DFD RID: 138749
		[Nullable(2)]
		private ActivityFlagChallengeData ActivityData;

		// Token: 0x04021DFE RID: 138750
		private string RemainTimeFormatText = "";
	}
}
