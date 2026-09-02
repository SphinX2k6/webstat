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

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200669A RID: 26266
	public class ActivityMowingRiskSubView : ActivitySubViewBase
	{
		// Token: 0x06041978 RID: 268664 RVA: 0x010D1114 File Offset: 0x010CF314
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickBtnReward));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041979 RID: 268665 RVA: 0x010D13B4 File Offset: 0x010CF5B4
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityMowingRiskSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityMowingRiskSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604197A RID: 268666 RVA: 0x010D13F7 File Offset: 0x010CF5F7
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotMowingRiskReward, base.GetItem(12), 0);
		}

		// Token: 0x0604197B RID: 268667 RVA: 0x010D1414 File Offset: 0x010CF614
		protected override void OnStart()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(scrollViewWithScrollbar, new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
			this.FunctionalComponent.SetRewardButtonFunction(new Action(this.OnClickBtnReward));
			this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.OnClickBtnEnter));
		}

		// Token: 0x0604197C RID: 268668 RVA: 0x010D1477 File Offset: 0x010CF677
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreatePropItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0604197D RID: 268669 RVA: 0x010D147E File Offset: 0x010CF67E
		protected override void OnSetData()
		{
		}

		// Token: 0x0604197E RID: 268670 RVA: 0x010D1480 File Offset: 0x010CF680
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MowingRiskOnGetReward, new Action(this.RefreshRewardCountText));
		}

		// Token: 0x0604197F RID: 268671 RVA: 0x010D149E File Offset: 0x010CF69E
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MowingRiskOnGetReward, new Action(this.RefreshRewardCountText));
		}

		// Token: 0x06041980 RID: 268672 RVA: 0x010D14BC File Offset: 0x010CF6BC
		protected override void OnRefreshView()
		{
			this.RefreshText();
			this.RefreshRewards();
			this.RefreshState();
			this.RefreshRedDot();
			this.TryShowNewInstanceTips();
			this.RefreshRewardCountText();
		}

		// Token: 0x06041981 RID: 268673 RVA: 0x010D14E4 File Offset: 0x010CF6E4
		private void TryShowNewInstanceTips()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			if (instance.IsNewInstanceOpen && instance.IsPreQuestFinished)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ActivityMowing_Newlevelunlock", Array.Empty<object>());
			}
		}

		// Token: 0x06041982 RID: 268674 RVA: 0x010D151C File Offset: 0x010CF71C
		protected override void OnTimer(float gap)
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			base.GetText(10).SetUIActive(item);
			if (item)
			{
				base.GetText(10).SetText(item2, true);
			}
		}

		// Token: 0x06041983 RID: 268675 RVA: 0x010D155C File Offset: 0x010CF75C
		private void RefreshText()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), instance.ActivityTitleTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), instance.ActivityDescriptionTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "CollectActivity_Button_ahead", Array.Empty<object>());
		}

		// Token: 0x06041984 RID: 268676 RVA: 0x010D15C4 File Offset: 0x010CF7C4
		public void RefreshRewardCountText()
		{
			ValueTuple<int, int> rewardCount = ModelBase<MowingRiskModel>.Instance.GetRewardCount();
			UUIText text = base.GetText(16);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(rewardCount.Item1);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(rewardCount.Item2);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06041985 RID: 268677 RVA: 0x010D1628 File Offset: 0x010CF828
		private void RefreshRewards()
		{
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardScrollView.RefreshByData(previewReward, null, false);
		}

		// Token: 0x06041986 RID: 268678 RVA: 0x010D1658 File Offset: 0x010CF858
		private void RefreshState()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			if (!flag)
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
			UUIItem item = base.GetItem(11);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag);
		}

		// Token: 0x06041987 RID: 268679 RVA: 0x010D16B8 File Offset: 0x010CF8B8
		private void RefreshRedDot()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			this.FunctionalComponent.SetRewardRedDotVisible(instance.HasAnyReward);
			this.FunctionalComponent.FunctionButton.SetRedDotVisible(instance.IsNewInstanceOpen);
			Singleton<EventSystem>.Instance.Emit(EEventName.MowingRiskOnRefreshRewardRedDot);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
		}

		// Token: 0x06041988 RID: 268680 RVA: 0x010D1720 File Offset: 0x010CF920
		private void OnClickBtnReward()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, instance.BuildActivityRewardViewData(), delegate(bool success, int viewId)
			{
				if (success && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.CommonActivityView))
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonActivityView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x06041989 RID: 268681 RVA: 0x010D1768 File Offset: 0x010CF968
		private void OnClickBtnEnter()
		{
			UiAsyncTask task = new UiAsyncTask("ActivityMowingRiskSubView.OnClickBtnEnterAsync", delegate()
			{
				ActivityMowingRiskSubView.<<OnClickBtnEnter>b__20_0>d <<OnClickBtnEnter>b__20_0>d;
				<<OnClickBtnEnter>b__20_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnClickBtnEnter>b__20_0>d.<>4__this = this;
				<<OnClickBtnEnter>b__20_0>d.<>1__state = -1;
				<<OnClickBtnEnter>b__20_0>d.<>t__builder.Start<ActivityMowingRiskSubView.<<OnClickBtnEnter>b__20_0>d>(ref <<OnClickBtnEnter>b__20_0>d);
				return <<OnClickBtnEnter>b__20_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0604198A RID: 268682 RVA: 0x010D1798 File Offset: 0x010CF998
		private UniTask OnClickBtnEnterAsync()
		{
			ActivityMowingRiskSubView.<OnClickBtnEnterAsync>d__21 <OnClickBtnEnterAsync>d__;
			<OnClickBtnEnterAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnClickBtnEnterAsync>d__.<>4__this = this;
			<OnClickBtnEnterAsync>d__.<>1__state = -1;
			<OnClickBtnEnterAsync>d__.<>t__builder.Start<ActivityMowingRiskSubView.<OnClickBtnEnterAsync>d__21>(ref <OnClickBtnEnterAsync>d__);
			return <OnClickBtnEnterAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04024A1F RID: 150047
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x04024A20 RID: 150048
		[Nullable(2)]
		private ActivityFunctionalArea FunctionalComponent;

		// Token: 0x0200C69F RID: 50847
		private class EActivityMowingComponents
		{
			// Token: 0x0403D27A RID: 250490
			public const int TitleItem = 0;

			// Token: 0x0403D27B RID: 250491
			public const int TxtTitle = 1;

			// Token: 0x0403D27C RID: 250492
			public const int DescItem = 2;

			// Token: 0x0403D27D RID: 250493
			public const int TxtDesc = 3;

			// Token: 0x0403D27E RID: 250494
			public const int RewardItem = 4;

			// Token: 0x0403D27F RID: 250495
			public const int RewardScrollView = 5;

			// Token: 0x0403D280 RID: 250496
			public const int FunctionItem = 6;

			// Token: 0x0403D281 RID: 250497
			public const int PnlAactive = 7;

			// Token: 0x0403D282 RID: 250498
			public const int BtnRewardItem = 8;

			// Token: 0x0403D283 RID: 250499
			public const int BtnEnter = 9;

			// Token: 0x0403D284 RID: 250500
			public const int TxtTime = 10;

			// Token: 0x0403D285 RID: 250501
			public const int PnlButton = 11;

			// Token: 0x0403D286 RID: 250502
			public const int RedDot = 12;

			// Token: 0x0403D287 RID: 250503
			public const int TxtCondition = 13;

			// Token: 0x0403D288 RID: 250504
			public const int TxtConfirm = 14;

			// Token: 0x0403D289 RID: 250505
			public const int BtnCircle = 15;

			// Token: 0x0403D28A RID: 250506
			public const int RewardText = 16;
		}
	}
}
