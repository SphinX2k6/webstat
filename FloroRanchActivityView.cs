using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C26 RID: 7206
[NullableContext(2)]
[Nullable(0)]
public class FloroRanchActivityView : ActivitySubViewBase
{
	// Token: 0x0600D173 RID: 53619 RVA: 0x00379572 File Offset: 0x00377772
	protected override void OnSetData()
	{
		this.ActivityData = (FloroRanchActivityData)this.ActivityBaseData;
	}

	// Token: 0x0600D174 RID: 53620 RVA: 0x00379588 File Offset: 0x00377788
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D175 RID: 53621 RVA: 0x00379654 File Offset: 0x00377854
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchActivityView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchActivityView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D176 RID: 53622 RVA: 0x00379697 File Offset: 0x00377897
	protected override void OnBeforeShow()
	{
		this.RefreshTimeText();
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.RefreshTimeText();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0600D177 RID: 53623 RVA: 0x003796C8 File Offset: 0x003778C8
	protected override void OnRefreshView()
	{
		this.RefreshCondition();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.SetFunctionRedDotVisible(this.ActivityData.CheckRedDot());
		}
		ButtonItem permanentRewardBtn = this.PermanentRewardBtn;
		if (permanentRewardBtn != null)
		{
			permanentRewardBtn.SetRedDotVisible(this.ActivityData.IsPermanentTaskHasRedDot());
		}
		ButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn != null)
		{
			limitRewardBtn.SetRedDotVisible(this.ActivityData.IsLimitTaskHasRedDot());
		}
		string permanentRewardProgress = this.ActivityData.GetPermanentRewardProgress();
		ButtonItem permanentRewardBtn2 = this.PermanentRewardBtn;
		if (permanentRewardBtn2 != null)
		{
			permanentRewardBtn2.SetText(permanentRewardProgress);
		}
		this.RefreshRecommendQuestTips();
		USpineSkeletonAnimationComponent spine = base.GetSpine(3);
		if (spine == null)
		{
			return;
		}
		spine.SetAnimation(0, "star", false);
	}

	// Token: 0x0600D178 RID: 53624 RVA: 0x0037976C File Offset: 0x0037796C
	private void RefreshTimeText()
	{
		if (!this.ActivityData.IsInLimitTime() && this.TimerHandle != null)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(this.ActivityData.IsInLimitTime());
			}
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.GetLimitTimeActivityEndTime(), "{0}");
		ButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn == null)
		{
			return;
		}
		limitRewardBtn.SetText(remainTimeText);
	}

	// Token: 0x0600D179 RID: 53625 RVA: 0x003797F0 File Offset: 0x003779F0
	private void RefreshCondition()
	{
		ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
		ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
		{
			UnlockBtnTextId = "LongShanStage_Join01",
			UnlockBtnFunction = new Action(this.OnConfirmBtnClick)
		};
		functional.RefreshGeneralPerformance(parameters);
	}

	// Token: 0x0600D17A RID: 53626 RVA: 0x00379834 File Offset: 0x00377A34
	private void RefreshRecommendQuestTips()
	{
		bool flag = !this.ActivityData.IsRecommendQuestFinished();
		this.RecommendQuestTipsSubPanel.SetUiActive(flag);
		if (flag)
		{
			string recommendQuestLabel = this.ActivityData.GetFloroRanchParamConfig().RecommendQuestLabel;
			this.RecommendQuestTipsSubPanel.SetTipsTxtByTextId(recommendQuestLabel, Array.Empty<string>());
		}
	}

	// Token: 0x0600D17B RID: 53627 RVA: 0x00379884 File Offset: 0x00377A84
	protected override void OnBeforeHide()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x0600D17C RID: 53628 RVA: 0x003798A6 File Offset: 0x00377AA6
	protected override void OnBeforeDestroy()
	{
		USpineSkeletonAnimationComponent spine = base.GetSpine(3);
		if (spine == null)
		{
			return;
		}
		spine.AnimationComplete.Remove(new Action<UTrackEntry>(this.OnAnimationComplete));
	}

	// Token: 0x0600D17D RID: 53629 RVA: 0x003798CA File Offset: 0x00377ACA
	private void OnConfirmBtnClick(ActivityBaseData data)
	{
		this.OnConfirmBtnClick();
	}

	// Token: 0x0600D17E RID: 53630 RVA: 0x003798D4 File Offset: 0x00377AD4
	private void OnConfirmBtnClick()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
			return;
		}
		if (this.ActivityData.GetIsReadComic())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchMainView, this.ActivityData, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchComicView, null, null);
	}

	// Token: 0x0600D17F RID: 53631 RVA: 0x00379937 File Offset: 0x00377B37
	private void OnLimitRewardBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchLimitRewardView, null, null);
	}

	// Token: 0x0600D180 RID: 53632 RVA: 0x0037994A File Offset: 0x00377B4A
	private void OnPermanentRewardBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchPermanentRewardView, null, null);
	}

	// Token: 0x0600D181 RID: 53633 RVA: 0x00379960 File Offset: 0x00377B60
	private void OnRecommendBtnClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DirectTrainRecommendQuest);
		Action value = delegate()
		{
			int? recommendQuestLinkId = this.ActivityData.GetRecommendQuestLinkId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, recommendQuestLinkId, null);
		};
		confirmBoxDataNew.FunctionMap[2] = value;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D182 RID: 53634 RVA: 0x0037999E File Offset: 0x00377B9E
	private void OnAnimationComplete(UTrackEntry entry)
	{
		if (entry == null)
		{
			return;
		}
		if (entry.getAnimationName() == "star")
		{
			USpineSkeletonAnimationComponent spine = base.GetSpine(3);
			if (spine == null)
			{
				return;
			}
			spine.SetAnimation(0, "idle", true);
		}
	}

	// Token: 0x040063F8 RID: 25592
	[Nullable(1)]
	protected FloroRanchActivityData ActivityData;

	// Token: 0x040063F9 RID: 25593
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x040063FA RID: 25594
	private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanel;

	// Token: 0x040063FB RID: 25595
	private ButtonItem LimitRewardBtn;

	// Token: 0x040063FC RID: 25596
	private ButtonItem PermanentRewardBtn;

	// Token: 0x040063FD RID: 25597
	private TimerHandle TimerHandle;

	// Token: 0x02007EFF RID: 32511
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B369 RID: 177001
		public const int CommonActionInfo = 0;

		// Token: 0x0402B36A RID: 177002
		public const int ItemLimitRewardBtn = 1;

		// Token: 0x0402B36B RID: 177003
		public const int ItemPermanentRewardBtn = 2;

		// Token: 0x0402B36C RID: 177004
		public const int Spine = 3;

		// Token: 0x0402B36D RID: 177005
		public const int ItemRecommendQuest = 4;
	}
}
