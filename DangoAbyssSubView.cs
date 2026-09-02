using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B06 RID: 6918
[NullableContext(2)]
[Nullable(0)]
public class DangoAbyssSubView : ActivitySubViewBase
{
	// Token: 0x0600C74D RID: 51021 RVA: 0x0034B790 File Offset: 0x00349990
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(USpineSkeletonAnimationComponent))
		};
	}

	// Token: 0x0600C74E RID: 51022 RVA: 0x0034B89C File Offset: 0x00349A9C
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssSubView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssSubView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C74F RID: 51023 RVA: 0x0034B8DF File Offset: 0x00349ADF
	protected override void OnStart()
	{
		this.DangoAbyssActivityData = (this.ActivityBaseData as DangoAbyssActivityData);
	}

	// Token: 0x0600C750 RID: 51024 RVA: 0x0034B8F2 File Offset: 0x00349AF2
	protected override void OnBeforeShow()
	{
		this.BindRedDot();
		base.GetSpine(10).SetAnimation(0, "start", false).AnimationComplete.Add(delegate(UTrackEntry _)
		{
			base.GetSpine(10).SetAnimation(0, "idle", true);
		});
	}

	// Token: 0x0600C751 RID: 51025 RVA: 0x0034B924 File Offset: 0x00349B24
	protected override void OnBeforeHide()
	{
		this.RemoveRedDot();
		base.GetSpine(10).ClearTracks();
	}

	// Token: 0x0600C752 RID: 51026 RVA: 0x0034B93C File Offset: 0x00349B3C
	private void BindRedDot()
	{
		ActivityButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn != null)
		{
			limitRewardBtn.BindRedDot(ERedDotName.RedDotDangoLimitReward, this.ActivityBaseData.Id);
		}
		ActivityButtonItem rewardBtn = this.RewardBtn;
		if (rewardBtn == null)
		{
			return;
		}
		rewardBtn.BindRedDot(ERedDotName.RedDotDangoCommonReward, this.ActivityBaseData.Id);
	}

	// Token: 0x0600C753 RID: 51027 RVA: 0x0034B98A File Offset: 0x00349B8A
	private void RemoveRedDot()
	{
		ActivityButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn != null)
		{
			limitRewardBtn.UnBindGivenUid(this.ActivityBaseData.Id);
		}
		ActivityButtonItem rewardBtn = this.RewardBtn;
		if (rewardBtn == null)
		{
			return;
		}
		rewardBtn.UnBindGivenUid(this.ActivityBaseData.Id);
	}

	// Token: 0x0600C754 RID: 51028 RVA: 0x0034B9C4 File Offset: 0x00349BC4
	protected override void OnRefreshView()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		this.RefreshDesc();
		this.RefreshTitle();
		this.RefreshReward();
		this.RefreshFunctionalComponent();
		this.RefreshState();
		this.RefreshProgressText();
	}

	// Token: 0x0600C755 RID: 51029 RVA: 0x0034BA0C File Offset: 0x00349C0C
	private void RefreshProgressText()
	{
		bool flag = this.DangoAbyssActivityData.CheckInLimitTime();
		ActivityButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn != null)
		{
			limitRewardBtn.SetActive(flag);
		}
		if (flag)
		{
			string remainTimeText = this.DangoAbyssActivityData.GetRemainTimeText();
			ActivityButtonItem limitRewardBtn2 = this.LimitRewardBtn;
			if (limitRewardBtn2 != null)
			{
				limitRewardBtn2.SetText(remainTimeText);
			}
		}
		string rewardFinishProgressText = this.DangoAbyssActivityData.GetRewardFinishProgressText();
		this.RewardBtn.SetText(rewardFinishProgressText);
	}

	// Token: 0x0600C756 RID: 51030 RVA: 0x0034BA70 File Offset: 0x00349C70
	private void RefreshDesc()
	{
		Activity value = this.ActivityBaseData.LocalConfig.Value;
		string descTheme = value.DescTheme;
		string desc = value.Desc;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		string descThemeIcon = value.DescThemeIcon;
		if (!string.IsNullOrEmpty(descThemeIcon))
		{
			ActivityTitleTypeA titleComponent = this.TitleComponent;
			if (titleComponent == null)
			{
				return;
			}
			titleComponent.SetSubTitleIconByPath(descThemeIcon, null);
		}
	}

	// Token: 0x0600C757 RID: 51031 RVA: 0x0034BB00 File Offset: 0x00349D00
	private void RefreshTitle()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
	}

	// Token: 0x0600C758 RID: 51032 RVA: 0x0034BB78 File Offset: 0x00349D78
	private void RefreshReward()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.SetTitleByTextId("BossRushCollectReward");
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
	}

	// Token: 0x0600C759 RID: 51033 RVA: 0x0034BBB8 File Offset: 0x00349DB8
	private void RefreshState()
	{
		bool flag = this.ActivityBaseData.IsUnLock();
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
		}
		this.FunctionalComponent.FunctionButton.SetUiActive(flag);
	}

	// Token: 0x0600C75A RID: 51034 RVA: 0x0034BC18 File Offset: 0x00349E18
	private void RefreshFunctionalComponent()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("DangoAbyssEnterText", null);
		this.FunctionalComponent.FunctionButton.SetText(localTextNew);
		bool redDotVisible = this.ActivityBaseData.IsUnLock() && ModelBase<DangoAbyssModel>.Instance.GetAbyssDangoEnterNew();
		this.FunctionalComponent.FunctionButton.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x0600C75B RID: 51035 RVA: 0x0034BC70 File Offset: 0x00349E70
	private void FunctionExecute()
	{
		ModelBase<DangoAbyssModel>.Instance.SetAbyssDangoEnterNew(false);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		ControllerBase<DangoAbyssController>.Instance.OpenCurrentActivityAbyssEntrance();
	}

	// Token: 0x0600C75C RID: 51036 RVA: 0x0034BCDE File Offset: 0x00349EDE
	protected override void OnTimer(float gap)
	{
		base.OnTimer(gap);
		this.RefreshTitle();
	}

	// Token: 0x04005F74 RID: 24436
	private DangoAbyssActivityData DangoAbyssActivityData;

	// Token: 0x04005F75 RID: 24437
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04005F76 RID: 24438
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04005F77 RID: 24439
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04005F78 RID: 24440
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x04005F79 RID: 24441
	private ActivityButtonItem LimitRewardBtn;

	// Token: 0x04005F7A RID: 24442
	private ActivityButtonItem RewardBtn;

	// Token: 0x02007DE0 RID: 32224
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ADFE RID: 175614
		public const int TitleItem = 0;

		// Token: 0x0402ADFF RID: 175615
		public const int DescItem = 1;

		// Token: 0x0402AE00 RID: 175616
		public const int RewardItem = 2;

		// Token: 0x0402AE01 RID: 175617
		public const int FunctionalAreaItem = 3;

		// Token: 0x0402AE02 RID: 175618
		public const int LimitRewardBtn = 4;

		// Token: 0x0402AE03 RID: 175619
		public const int LimitRewardProgress = 5;

		// Token: 0x0402AE04 RID: 175620
		public const int RewardBtn = 6;

		// Token: 0x0402AE05 RID: 175621
		public const int RewardProgress = 7;

		// Token: 0x0402AE06 RID: 175622
		public const int LimitRewardBtnItem = 8;

		// Token: 0x0402AE07 RID: 175623
		public const int RewardBtnItem = 9;

		// Token: 0x0402AE08 RID: 175624
		public const int SpineActor = 10;
	}
}
