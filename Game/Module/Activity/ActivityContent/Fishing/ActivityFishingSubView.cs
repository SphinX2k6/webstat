using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006787 RID: 26503
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityFishingSubView : ActivitySubViewBase
	{
		// Token: 0x1700A0D3 RID: 41171
		// (get) Token: 0x06042106 RID: 270598 RVA: 0x010F333A File Offset: 0x010F153A
		[Nullable(2)]
		protected new ActivityFishingData ActivityBaseData
		{
			[NullableContext(2)]
			get
			{
				return this.ActivityBaseData as ActivityFishingData;
			}
		}

		// Token: 0x06042107 RID: 270599 RVA: 0x010F3348 File Offset: 0x010F1548
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042108 RID: 270600 RVA: 0x010F349C File Offset: 0x010F169C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityFishingSubView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityFishingSubView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042109 RID: 270601 RVA: 0x010F34E0 File Offset: 0x010F16E0
		protected override void OnStart()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			string descTheme = localConfig.Value.DescTheme;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.TitleComponent.SetSubTitleVisible(flag);
			if (flag)
			{
				this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			}
			string desc = localConfig.Value.Desc;
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
			this.RefreshButton();
			this.FunctionalComponent.FunctionButton.SetExtraFunction(new Action(this.ExtraButtonFunction));
			this.SwitchGenderItem();
		}

		// Token: 0x0604210A RID: 270602 RVA: 0x010F35F6 File Offset: 0x010F17F6
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivityPreOpen, new Action<int>(this.OnActivityPreOpen));
		}

		// Token: 0x0604210B RID: 270603 RVA: 0x010F3614 File Offset: 0x010F1814
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityPreOpen, new Action<int>(this.OnActivityPreOpen));
		}

		// Token: 0x0604210C RID: 270604 RVA: 0x010F3632 File Offset: 0x010F1832
		protected override void OnRefreshView()
		{
			this.RefreshTimerText();
			this.RefreshCondition();
			this.RefreshRedDot();
			this.RefreshRecommendQuestTips();
			this.RefreshButton();
		}

		// Token: 0x0604210D RID: 270605 RVA: 0x010F3654 File Offset: 0x010F1854
		protected override UniTask OnBeforeHideSelfAsync()
		{
			ActivityFishingSubView.<OnBeforeHideSelfAsync>d__16 <OnBeforeHideSelfAsync>d__;
			<OnBeforeHideSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideSelfAsync>d__.<>4__this = this;
			<OnBeforeHideSelfAsync>d__.<>1__state = -1;
			<OnBeforeHideSelfAsync>d__.<>t__builder.Start<ActivityFishingSubView.<OnBeforeHideSelfAsync>d__16>(ref <OnBeforeHideSelfAsync>d__);
			return <OnBeforeHideSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604210E RID: 270606 RVA: 0x010F3697 File Offset: 0x010F1897
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
		}

		// Token: 0x0604210F RID: 270607 RVA: 0x010F36A0 File Offset: 0x010F18A0
		private void SwitchGenderItem()
		{
			bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
		}

		// Token: 0x06042110 RID: 270608 RVA: 0x010F36E4 File Offset: 0x010F18E4
		private void RefreshCondition()
		{
			ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "Fishing_Goto",
				UnlockBtnFunction = new Action(this.FunctionExecute),
				BeforePreOpenCheck = new Func<bool>(this.BeforeFunctionCheck)
			};
			this.FunctionalComponent.RefreshGeneralPerformance(parameters);
		}

		// Token: 0x06042111 RID: 270609 RVA: 0x010F3734 File Offset: 0x010F1934
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06042112 RID: 270610 RVA: 0x010F3770 File Offset: 0x010F1970
		private void RefreshButton()
		{
			this.LimitTimeRewardItem.RefreshActive();
			bool flag = this.ActivityBaseData.IsUnLock();
			if (flag)
			{
				this.PermanentRewardItem.Refresh();
			}
			this.PermanentRewardItem.SetUiActive(flag);
		}

		// Token: 0x06042113 RID: 270611 RVA: 0x010F37B0 File Offset: 0x010F19B0
		private void RefreshRedDot()
		{
			bool buttonRedPointShowState = this.ActivityBaseData.GetButtonRedPointShowState();
			this.FunctionalComponent.SetFunctionRedDotVisible(buttonRedPointShowState);
		}

		// Token: 0x06042114 RID: 270612 RVA: 0x010F37D8 File Offset: 0x010F19D8
		private void OnRecommendBtnClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DirectTrainRecommendQuest);
			Action value = delegate()
			{
				int? recommendQuestLinkId = this.ActivityBaseData.GetRecommendQuestLinkId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, recommendQuestLinkId, null);
			};
			confirmBoxDataNew.FunctionMap[2] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06042115 RID: 270613 RVA: 0x010F3816 File Offset: 0x010F1A16
		private bool IsShowRecommend()
		{
			return !this.ActivityBaseData.IsRecommendQuestFinished();
		}

		// Token: 0x06042116 RID: 270614 RVA: 0x010F3828 File Offset: 0x010F1A28
		private void RefreshRecommendQuestTips()
		{
			bool flag = this.IsShowRecommend();
			this.RecommendQuestTipsSubPanel.SetUiActive(flag);
			if (flag)
			{
				string recommendQuestLabel = this.ActivityBaseData.GetActivityConfig().RecommendQuestLabel;
				this.RecommendQuestTipsSubPanel.SetTipsTxtByTextId(recommendQuestLabel, Array.Empty<string>());
			}
		}

		// Token: 0x06042117 RID: 270615 RVA: 0x010F3870 File Offset: 0x010F1A70
		private void ExtraButtonFunction()
		{
			if (!this.ActivityBaseData.SaveFirstCheckRedDotState(EFishingActivityCheckSaveFlag.PreOpen, 0))
			{
				this.RefreshRedDot();
			}
		}

		// Token: 0x06042118 RID: 270616 RVA: 0x010F3888 File Offset: 0x010F1A88
		private void OnActivityPreOpen(int activityId)
		{
			if (this.ActivityBaseData.Id != activityId)
			{
				return;
			}
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			if (!ModelBase<QuestNewModel>.Instance.IsTrackingQuest(unFinishPreGuideQuestId))
			{
				ControllerBase<QuestNewController>.Instance.RequestTrackQuest(unFinishPreGuideQuestId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
			}
		}

		// Token: 0x06042119 RID: 270617 RVA: 0x010F38CD File Offset: 0x010F1ACD
		private bool BeforeFunctionCheck()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CantUseInMultiplayerMode", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x0604211A RID: 270618 RVA: 0x010F38F2 File Offset: 0x010F1AF2
		private void FunctionExecute()
		{
			ControllerBase<ActivityController>.Instance.OpenActivityContentView(this.ActivityBaseData);
		}

		// Token: 0x04024D4C RID: 150860
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x04024D4D RID: 150861
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x04024D4E RID: 150862
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x04024D4F RID: 150863
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x04024D50 RID: 150864
		private FishingRewardLimitTimeButton LimitTimeRewardItem;

		// Token: 0x04024D51 RID: 150865
		private FishingPermanentRewardButton PermanentRewardItem;

		// Token: 0x04024D52 RID: 150866
		private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanel;

		// Token: 0x0200C7A2 RID: 51106
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D760 RID: 251744
			public const int TitleItem = 0;

			// Token: 0x0403D761 RID: 251745
			public const int DescriptionItem = 1;

			// Token: 0x0403D762 RID: 251746
			public const int RewardListItem = 2;

			// Token: 0x0403D763 RID: 251747
			public const int FunctionArea = 3;

			// Token: 0x0403D764 RID: 251748
			public const int LimitTimeReward = 4;

			// Token: 0x0403D765 RID: 251749
			public const int PermanentReward = 5;

			// Token: 0x0403D766 RID: 251750
			public const int RecommendQuestItem = 6;

			// Token: 0x0403D767 RID: 251751
			public const int MaleItem = 7;

			// Token: 0x0403D768 RID: 251752
			public const int FemaleItem = 8;
		}
	}
}
