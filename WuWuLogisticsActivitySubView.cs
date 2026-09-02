using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001710 RID: 5904
[NullableContext(2)]
[Nullable(0)]
public class WuWuLogisticsActivitySubView : ActivitySubViewBase
{
	// Token: 0x0600A42C RID: 42028 RVA: 0x002B68A8 File Offset: 0x002B4AA8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
		};
	}

	// Token: 0x0600A42D RID: 42029 RVA: 0x002B695A File Offset: 0x002B4B5A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.RefreshConfirmButtonRedPoint));
	}

	// Token: 0x0600A42E RID: 42030 RVA: 0x002B6978 File Offset: 0x002B4B78
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.RefreshConfirmButtonRedPoint));
	}

	// Token: 0x0600A42F RID: 42031 RVA: 0x002B6996 File Offset: 0x002B4B96
	protected override void OnSetData()
	{
		this.ActivityData = (this.ActivityBaseData as WuWuLogisticsActivityData);
	}

	// Token: 0x0600A430 RID: 42032 RVA: 0x002B69AC File Offset: 0x002B4BAC
	protected override UniTask OnBeforeStartAsync()
	{
		WuWuLogisticsActivitySubView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WuWuLogisticsActivitySubView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A431 RID: 42033 RVA: 0x002B69F0 File Offset: 0x002B4BF0
	protected override void OnStart()
	{
		ActivityBaseData activityBaseData = this.ActivityBaseData;
		ActivityTitleTypeA titleComponent = this.TitleComponent;
		if (titleComponent != null)
		{
			titleComponent.SetActivityBaseData(activityBaseData);
		}
		ActivityTitleTypeA titleComponent2 = this.TitleComponent;
		if (titleComponent2 != null)
		{
			titleComponent2.SetTitleByText(activityBaseData.GetTitle());
		}
		string descTheme = activityBaseData.LocalConfig.Value.DescTheme;
		if (!StringUtils.IsEmpty(descTheme))
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		ActivityDescriptionTypeA descriptionComponent = this.DescriptionComponent;
		if (descriptionComponent != null)
		{
			descriptionComponent.SetContentByTextId(activityBaseData.LocalConfig.Value.Desc, Array.Empty<string>());
		}
		this.InitButtonState();
		this.RefreshDisabledBar();
	}

	// Token: 0x0600A432 RID: 42034 RVA: 0x002B6A92 File Offset: 0x002B4C92
	protected override void OnRefreshView()
	{
		this.RefreshRewardComponent();
		this.RefreshTimerText();
		this.RefreshCurProgress();
		this.RefreshConfirmButtonRedPoint(0);
		this.RefreshDisabledBar();
	}

	// Token: 0x0600A433 RID: 42035 RVA: 0x002B6AB3 File Offset: 0x002B4CB3
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x0600A434 RID: 42036 RVA: 0x002B6ABB File Offset: 0x002B4CBB
	protected void InitButtonState()
	{
		this.ConfirmQuick = new ButtonItem(base.GetButton(6).RootUIComp);
		this.ConfirmQuick.SetFunction(new Action<int>(this.OnClickedForwardButton));
	}

	// Token: 0x0600A435 RID: 42037 RVA: 0x002B6AF0 File Offset: 0x002B4CF0
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x0600A436 RID: 42038 RVA: 0x002B6B20 File Offset: 0x002B4D20
	private void RefreshRewardComponent()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
	}

	// Token: 0x0600A437 RID: 42039 RVA: 0x002B6B6C File Offset: 0x002B4D6C
	private void OnClickedForwardButton(int data)
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WuWuLogisticsMissionView, null, null);
	}

	// Token: 0x0600A438 RID: 42040 RVA: 0x002B6BBC File Offset: 0x002B4DBC
	private void RefreshDisabledBar()
	{
		ActivityBaseData data = this.ActivityBaseData;
		FunctionalPanelConditionLock disabledBarPanel = this.DisabledBarPanel;
		UUIItem item = base.GetItem(5);
		if (data == null || disabledBarPanel == null || item == null)
		{
			return;
		}
		if (!data.IsUnLock())
		{
			item.SetUIActive(true);
			disabledBarPanel.SetSpriteVisible(true);
			disabledBarPanel.SetButtonVisible(true);
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(data.ConditionGroupId);
			if (!string.IsNullOrEmpty(conditionGroupHintText))
			{
				disabledBarPanel.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
			}
			disabledBarPanel.ButtonCallBack = delegate()
			{
				ControllerBase<ActivityController>.Instance.OpenActivityConditionView(data.Id);
			};
			ButtonItem confirmQuick = this.ConfirmQuick;
			if (confirmQuick == null)
			{
				return;
			}
			confirmQuick.SetUiActive(false);
			return;
		}
		else if (!data.GetPreGuideQuestFinishState())
		{
			item.SetUIActive(true);
			disabledBarPanel.SetSpriteVisible(false);
			disabledBarPanel.SetButtonVisible(false);
			string preShowGuideQuestName = data.GetPreShowGuideQuestName();
			disabledBarPanel.SetTextByTextId("Text_ActivityNeedPreGiideQuest_Text", new string[]
			{
				preShowGuideQuestName
			});
			disabledBarPanel.ButtonCallBack = null;
			ButtonItem confirmQuick2 = this.ConfirmQuick;
			if (confirmQuick2 == null)
			{
				return;
			}
			confirmQuick2.SetUiActive(false);
			return;
		}
		else
		{
			item.SetUIActive(false);
			ButtonItem confirmQuick3 = this.ConfirmQuick;
			if (confirmQuick3 == null)
			{
				return;
			}
			confirmQuick3.SetUiActive(true);
			return;
		}
	}

	// Token: 0x0600A439 RID: 42041 RVA: 0x002B6CDC File Offset: 0x002B4EDC
	private void RefreshCurProgress()
	{
		IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
		int value = (allTaskPackage != null) ? allTaskPackage.Count : 0;
		int completedPackCount = this.ActivityData.GetCompletedPackCount();
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(completedPackCount);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600A43A RID: 42042 RVA: 0x002B6D4C File Offset: 0x002B4F4C
	private void RefreshConfirmButtonRedPoint(int uid = 0)
	{
		WuWuLogisticsActivityData activityData = this.ActivityData;
		bool redDotVisible = activityData != null && activityData.RedPointShowState;
		ButtonItem confirmQuick = this.ConfirmQuick;
		if (confirmQuick == null)
		{
			return;
		}
		confirmQuick.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x04004DE7 RID: 19943
	protected WuWuLogisticsActivityData ActivityData;

	// Token: 0x04004DE8 RID: 19944
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04004DE9 RID: 19945
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04004DEA RID: 19946
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04004DEB RID: 19947
	protected ButtonItem ConfirmQuick;

	// Token: 0x04004DEC RID: 19948
	private FunctionalPanelConditionLock DisabledBarPanel;
}
