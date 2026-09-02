using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001739 RID: 5945
public class ActivitySubViewRun : ActivitySubViewBase
{
	// Token: 0x0600A629 RID: 42537 RVA: 0x002BF150 File Offset: 0x002BD350
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A62A RID: 42538 RVA: 0x002BF2E0 File Offset: 0x002BD4E0
	protected override void OnStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(scrollViewWithScrollbar, this.CreatePropItem, null, false, null);
	}

	// Token: 0x0600A62B RID: 42539 RVA: 0x002BF30C File Offset: 0x002BD50C
	private void OnClickConfirmBtn()
	{
		if (this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			ControllerBase<ActivityController>.Instance.RequestReadActivity(this.ActivityBaseData);
			ControllerBase<ActivityController>.Instance.OpenActivityContentView(this.ActivityBaseData);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityBaseData.GetUnFinishPreGuideQuestId(), null);
	}

	// Token: 0x0600A62C RID: 42540 RVA: 0x002BF367 File Offset: 0x002BD567
	protected override void OnRefreshView()
	{
		this.RefreshTimerText();
		this.RefreshRewards();
		this.RefreshTitle();
		this.RefreshContent();
		this.BindRedPoint();
		this.RefreshConfirmButton();
		this.RefreshPreConditionText();
	}

	// Token: 0x0600A62D RID: 42541 RVA: 0x002BF393 File Offset: 0x002BD593
	public void BindRedPoint()
	{
		if (!this.RedPointBindState)
		{
			this.RedPointBindState = true;
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.CommonActivityPage, base.GetItem(6), null, this.ActivityBaseData.Id);
		}
	}

	// Token: 0x0600A62E RID: 42542 RVA: 0x002BF3C3 File Offset: 0x002BD5C3
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x0600A62F RID: 42543 RVA: 0x002BF3CB File Offset: 0x002BD5CB
	private void RefreshTitle()
	{
		base.GetText(0).SetText(this.ActivityBaseData.GetTitle(), true);
	}

	// Token: 0x0600A630 RID: 42544 RVA: 0x002BF3E8 File Offset: 0x002BD5E8
	private void RefreshContent()
	{
		base.GetText(1).ShowTextNew(this.ActivityBaseData.LocalConfig.Value.Desc);
		if (this.ActivityBaseData.IsUnLock() && this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			base.GetText(5).ShowTextNew("ReadyToFightText");
			return;
		}
		base.GetText(5).ShowTextNew("JumpToQuestText");
	}

	// Token: 0x0600A631 RID: 42545 RVA: 0x002BF458 File Offset: 0x002BD658
	private void RefreshConfirmButton()
	{
		base.GetButton(3).RootUIComp.Get().SetUIActive(this.ActivityBaseData.IsUnLock());
	}

	// Token: 0x0600A632 RID: 42546 RVA: 0x002BF48C File Offset: 0x002BD68C
	private void RefreshRewards()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardScrollView.RefreshByData(previewReward, null, false);
	}

	// Token: 0x0600A633 RID: 42547 RVA: 0x002BF4BC File Offset: 0x002BD6BC
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		base.GetText(2).SetUIActive(item);
		if (item)
		{
			base.GetText(2).SetText(item2, true);
		}
	}

	// Token: 0x0600A634 RID: 42548 RVA: 0x002BF4FC File Offset: 0x002BD6FC
	private void RefreshPreConditionText()
	{
		UUIText text = base.GetText(7);
		bool flag = !this.ActivityBaseData.IsUnLock() || !this.ActivityBaseData.GetPreGuideQuestFinishState();
		base.GetItem(8).SetUIActive(flag);
		if (flag)
		{
			text.SetText(this.GetCurrentLockConditionText(), true);
		}
	}

	// Token: 0x0600A635 RID: 42549 RVA: 0x002BF54D File Offset: 0x002BD74D
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.CommonActivityPage, base.GetItem(6), this.ActivityBaseData.Id);
	}

	// Token: 0x0600A636 RID: 42550 RVA: 0x002BF570 File Offset: 0x002BD770
	[NullableContext(1)]
	protected override string GetCurrentLockConditionText()
	{
		string currentLockConditionText = base.GetCurrentLockConditionText();
		string text = (currentLockConditionText == "") ? currentLockConditionText : ConfigMultiTextLang.GetLocalTextNew(currentLockConditionText, null);
		if (StringUtils.IsEmpty(text))
		{
			string preShowGuideQuestName = this.ActivityBaseData.GetPreShowGuideQuestName();
			text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ActivityNeedPreGiideQuest_Text", null), new string[]
			{
				preShowGuideQuestName
			});
		}
		return text;
	}

	// Token: 0x04004EB9 RID: 20153
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x04004EBA RID: 20154
	private bool RedPointBindState;

	// Token: 0x04004EBB RID: 20155
	[Nullable(1)]
	private readonly Func<CommonItemSmallItemGrid> CreatePropItem = () => new CommonItemSmallItemGrid();

	// Token: 0x02007A95 RID: 31381
	private class EComponents
	{
		// Token: 0x04029FF3 RID: 172019
		public const int TitleText = 0;

		// Token: 0x04029FF4 RID: 172020
		public const int TxtContent = 1;

		// Token: 0x04029FF5 RID: 172021
		public const int RemainTimeText = 2;

		// Token: 0x04029FF6 RID: 172022
		public const int ConfirmButton = 3;

		// Token: 0x04029FF7 RID: 172023
		public const int RewardPreviewScroller = 4;

		// Token: 0x04029FF8 RID: 172024
		public const int TxtFunc = 5;

		// Token: 0x04029FF9 RID: 172025
		public const int RedDot = 6;

		// Token: 0x04029FFA RID: 172026
		public const int PreMissionText = 7;

		// Token: 0x04029FFB RID: 172027
		public const int PnlCondition = 8;
	}
}
