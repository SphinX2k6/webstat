using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D54 RID: 11604
[NullableContext(2)]
[Nullable(0)]
public class WeeklyRogueSubView : ActivitySubViewBase
{
	// Token: 0x17001ED0 RID: 7888
	// (get) Token: 0x060176AB RID: 95915 RVA: 0x0067E423 File Offset: 0x0067C623
	protected new WeeklyRogueData ActivityBaseData
	{
		get
		{
			return this.ActivityBaseData as WeeklyRogueData;
		}
	}

	// Token: 0x060176AC RID: 95916 RVA: 0x0067E430 File Offset: 0x0067C630
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUITexture))
		};
	}

	// Token: 0x060176AD RID: 95917 RVA: 0x0067E4F8 File Offset: 0x0067C6F8
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueSubView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueSubView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060176AE RID: 95918 RVA: 0x0067E53C File Offset: 0x0067C73C
	protected override void OnStart()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		string descTheme = localConfig.Value.DescTheme;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		string desc = localConfig.Value.Desc;
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null);
		this.FunctionalComponent.FunctionButton.SetText(localTextNew);
		WeeklyRogueData activityBaseData = this.ActivityBaseData;
		RogueWeeklyCycle? rogueWeeklyCycle = (activityBaseData != null) ? activityBaseData.GetCycleConfig() : null;
		base.SetTextureByPath(rogueWeeklyCycle.Value.ViewBackground, base.GetTexture(7), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "PrefabTextItem_1382682910_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.ActivityBaseData.Score.ToString(),
			rogueWeeklyCycle.Value.MaxScore
		}));
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.OnRefreshView();
	}

	// Token: 0x060176AF RID: 95919 RVA: 0x0067E719 File Offset: 0x0067C919
	protected override void OnRefreshView()
	{
		this.RefreshTimerText();
		this.RefreshRedDot();
		this.RefreshCondition();
		this.RefreshScore();
	}

	// Token: 0x060176B0 RID: 95920 RVA: 0x0067E733 File Offset: 0x0067C933
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x060176B1 RID: 95921 RVA: 0x0067E73C File Offset: 0x0067C93C
	private void RefreshRedDot()
	{
		bool flag = this.ActivityBaseData.HasNewCycle();
		if (flag)
		{
			this.FunctionalComponent.SetPanelTipByTextId("WeRougeCycleUpdateBubbleText", Array.Empty<string>());
		}
		this.FunctionalComponent.SetPanelTipVisible(flag);
		this.FunctionalComponent.SetFunctionRedDotVisible(flag);
	}

	// Token: 0x060176B2 RID: 95922 RVA: 0x0067E788 File Offset: 0x0067C988
	private void RefreshTimerText()
	{
		WeeklyRogueData activityBaseData = this.ActivityBaseData;
		CommonDefine.ICountDown countDown = (activityBaseData != null) ? activityBaseData.GetCycleCountDownData() : null;
		if (countDown == null)
		{
			return;
		}
		string timeTextByText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("WeeklyRogue_Activity_Time", null), new string[]
		{
			countDown.CountDownText
		});
		this.TitleComponent.SetTimeTextByText(timeTextByText);
	}

	// Token: 0x060176B3 RID: 95923 RVA: 0x0067E7D8 File Offset: 0x0067C9D8
	private void RefreshCondition()
	{
		if (!this.ActivityBaseData.IsUnLock())
		{
			this.FunctionalComponent.SetPanelTipVisible(false);
			ActivityButtonItem functionButton = this.FunctionalComponent.FunctionButton;
			if (functionButton != null)
			{
				functionButton.SetUiActive(false);
			}
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			return;
		}
		ActivityButtonItem functionButton2 = this.FunctionalComponent.FunctionButton;
		if (functionButton2 != null)
		{
			functionButton2.SetUiActive(true);
		}
		this.FunctionalComponent.SetPanelConditionVisible(false);
	}

	// Token: 0x060176B4 RID: 95924 RVA: 0x0067E85C File Offset: 0x0067CA5C
	private void RefreshScore()
	{
		WeeklyRogueData activityBaseData = this.ActivityBaseData;
		RogueWeeklyCycle? rogueWeeklyCycle = (activityBaseData != null) ? activityBaseData.GetCycleConfig() : null;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "PrefabTextItem_1382682910_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.ActivityBaseData.Score.ToString(),
			rogueWeeklyCycle.Value.MaxScore
		}));
	}

	// Token: 0x060176B5 RID: 95925 RVA: 0x0067E8D0 File Offset: 0x0067CAD0
	private void FunctionExecute()
	{
		WeeklyRogueData activityBaseData = this.ActivityBaseData;
		bool? flag = (activityBaseData != null) ? new bool?(activityBaseData.GetPreGuideQuestFinishState()) : null;
		bool flag2 = false;
		if (flag.GetValueOrDefault() == flag2 & flag != null)
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			if (unFinishPreGuideQuestId > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			}
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueActivityView, EWeeklyRogueOpenWay.UI, null);
	}

	// Token: 0x0400B3A9 RID: 45993
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x0400B3AA RID: 45994
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x0400B3AB RID: 45995
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x0400B3AC RID: 45996
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x0200902F RID: 36911
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040305F2 RID: 198130
		TitleItem,
		// Token: 0x040305F3 RID: 198131
		DescriptionItem,
		// Token: 0x040305F4 RID: 198132
		RewardListItem,
		// Token: 0x040305F5 RID: 198133
		FunctionArea,
		// Token: 0x040305F6 RID: 198134
		BtnScore,
		// Token: 0x040305F7 RID: 198135
		ScoreRedDotItem,
		// Token: 0x040305F8 RID: 198136
		TxtScore,
		// Token: 0x040305F9 RID: 198137
		TextureBg
	}
}
