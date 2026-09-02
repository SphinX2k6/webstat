using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200144C RID: 5196
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewNewbieCourseV2 : ActivitySubViewBase
{
	// Token: 0x060090B0 RID: 37040 RVA: 0x002608DC File Offset: 0x0025EADC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060090B1 RID: 37041 RVA: 0x002609EA File Offset: 0x0025EBEA
	protected override void OnSetData()
	{
		this.ActivityData = (this.ActivityBaseData as ActivityNewbieCourseV2Data);
	}

	// Token: 0x060090B2 RID: 37042 RVA: 0x00260A00 File Offset: 0x0025EC00
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewNewbieCourseV2.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewNewbieCourseV2.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060090B3 RID: 37043 RVA: 0x00260A43 File Offset: 0x0025EC43
	protected override void OnRefreshView()
	{
		this.RefreshViewStateAndScrollToFocus();
	}

	// Token: 0x060090B4 RID: 37044 RVA: 0x00260A4C File Offset: 0x0025EC4C
	protected override void OnTimer(float gap)
	{
		if (this.ActivityBaseData == null)
		{
			return;
		}
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		UUIText text = base.GetText(6);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(item);
		text.SetText(item2, true);
	}

	// Token: 0x060090B5 RID: 37045 RVA: 0x00260A90 File Offset: 0x0025EC90
	protected override void OnSequenceStart(string sequenceName)
	{
		if (sequenceName != "Start")
		{
			return;
		}
		GenericScrollViewNew<NewbieCourseV2Item, NewbieCourseV2> rewardListScrollView = this.RewardListScrollView;
		if (rewardListScrollView == null)
		{
			return;
		}
		rewardListScrollView.PlayTurnAnimation();
	}

	// Token: 0x060090B6 RID: 37046 RVA: 0x00260AB0 File Offset: 0x0025ECB0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x060090B7 RID: 37047 RVA: 0x00260AEA File Offset: 0x0025ECEA
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x060090B8 RID: 37048 RVA: 0x00260B24 File Offset: 0x0025ED24
	protected override void OnBeforeDestroy()
	{
		NewbieCourseV2RewardBannerPanel rewardBannerPanel = this.RewardBannerPanel;
		if (rewardBannerPanel != null)
		{
			rewardBannerPanel.Destroy(null);
		}
		this.RewardBannerPanel = null;
		GenericScrollViewNew<NewbieCourseV2Item, NewbieCourseV2> rewardListScrollView = this.RewardListScrollView;
		foreach (NewbieCourseV2Item child in (((rewardListScrollView != null) ? rewardListScrollView.GetScrollItemList() : null) ?? new List<NewbieCourseV2Item>()))
		{
			base.AddChild(child);
		}
	}

	// Token: 0x060090B9 RID: 37049 RVA: 0x00260BA8 File Offset: 0x0025EDA8
	private NewbieCourseV2Item InitItem()
	{
		NewbieCourseV2Item newbieCourseV2Item = new NewbieCourseV2Item();
		if (this.ActivityData != null)
		{
			newbieCourseV2Item.SetActivityData(this.ActivityData);
		}
		return newbieCourseV2Item;
	}

	// Token: 0x060090BA RID: 37050 RVA: 0x00260BD0 File Offset: 0x0025EDD0
	private void OnRefreshCommonActivityRedDot(int activityId)
	{
		if (this.ActivityData == null || this.ActivityData.Id != activityId)
		{
			return;
		}
		this.RefreshViewState();
	}

	// Token: 0x060090BB RID: 37051 RVA: 0x00260BEF File Offset: 0x0025EDEF
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		if (this.ActivityData == null)
		{
			return;
		}
		this.RefreshViewStateAndScrollToFocus();
	}

	// Token: 0x060090BC RID: 37052 RVA: 0x00260C00 File Offset: 0x0025EE00
	private int GetFocusRewardRowIndex(IReadOnlyList<NewbieCourseV2> configList)
	{
		if (this.ActivityData == null || configList.Count == 0)
		{
			return 0;
		}
		for (int i = 0; i < configList.Count; i++)
		{
			if (this.ActivityData.GetRewardState(configList[i].TargetLevel) == ENewbieCourseV2ItemState.CanReceive)
			{
				return i;
			}
		}
		for (int j = 0; j < configList.Count; j++)
		{
			if (this.ActivityData.GetRewardState(configList[j].TargetLevel) == ENewbieCourseV2ItemState.Unaccomplished)
			{
				return j;
			}
		}
		return Math.Max(configList.Count - 1, 0);
	}

	// Token: 0x060090BD RID: 37053 RVA: 0x00260C8D File Offset: 0x0025EE8D
	private void RefreshViewStateAndScrollToFocus()
	{
		this.RefreshViewState();
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			this.TryScrollRewardListToFocusRow();
		}, null, null);
	}

	// Token: 0x060090BE RID: 37054 RVA: 0x00260CB0 File Offset: 0x0025EEB0
	private void ApplyRewardListContentPadding()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(2);
		AUIBaseActor auibaseActor = (scrollViewWithScrollbar != null) ? scrollViewWithScrollbar.GetContent() : null;
		if (auibaseActor == null)
		{
			return;
		}
		UUIVerticalLayout uuiverticalLayout = auibaseActor.GetComponentByClass(UUIVerticalLayout.StaticClass()) as UUIVerticalLayout;
		if (uuiverticalLayout == null)
		{
			return;
		}
		FMargin padding = uuiverticalLayout.GetPadding();
		padding.Top = 16f;
		uuiverticalLayout.SetPadding(padding);
	}

	// Token: 0x060090BF RID: 37055 RVA: 0x00260D0C File Offset: 0x0025EF0C
	private void TryScrollRewardListToFocusRow()
	{
		if (this.ActivityData == null || this.RewardListScrollView == null)
		{
			return;
		}
		IReadOnlyList<NewbieCourseV2> configList = ConfigBase<ActivityNewbieCourseV2Config>.Instance.GetConfigList(this.ActivityData.Id);
		int focusRewardRowIndex = this.GetFocusRewardRowIndex(configList);
		if (focusRewardRowIndex >= configList.Count)
		{
			return;
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(2);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		UUIItem itemByIndex = this.RewardListScrollView.GetItemByIndex(focusRewardRowIndex);
		if (itemByIndex == null)
		{
			return;
		}
		UUIItem uuiitem = scrollViewWithScrollbar.ContentUIItem.Get();
		if (uuiitem == null)
		{
			return;
		}
		FVector relativeLocation = uuiitem.RelativeLocation;
		FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
		scrollViewWithScrollbar.ScrollToTop(ref fvector2D, itemByIndex, false);
		uuiitem.SetAnchorOffsetY(uuiitem.GetAnchorOffsetY() - 16f);
	}

	// Token: 0x060090C0 RID: 37056 RVA: 0x00260DC4 File Offset: 0x0025EFC4
	private void RefreshViewState()
	{
		int? playerLevel = ModelBase<PlayerInfoModel>.Instance.GetPlayerLevel();
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(playerLevel.ToString(), true);
		}
		UUIText text2 = base.GetText(5);
		if (text2 != null)
		{
			ActivityNewbieCourseV2Data activityData = this.ActivityData;
			text2.SetText(((activityData != null) ? activityData.GetTitle() : null) ?? "", true);
		}
		UUITexture texture = base.GetTexture(4);
		if (texture != null)
		{
			string resourceId = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? "T_NewcomerLogoMale" : "T_NewcomerLogoFemale";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				base.SetTextureByPath(resourcePath, texture, null, null);
			}
		}
		if (this.RewardBannerPanel != null)
		{
			NewbieCourseV2RewardBannerPanel rewardBannerPanel = this.RewardBannerPanel;
			ActivityNewbieCourseV2Data activityData2 = this.ActivityData;
			rewardBannerPanel.SetActivityId((activityData2 != null) ? activityData2.Id : 0);
			this.RewardBannerPanel.RefreshWeaponPreviewEntrance();
		}
		GenericScrollViewNew<NewbieCourseV2Item, NewbieCourseV2> rewardListScrollView = this.RewardListScrollView;
		foreach (NewbieCourseV2Item newbieCourseV2Item in (((rewardListScrollView != null) ? rewardListScrollView.GetScrollItemList() : null) ?? new List<NewbieCourseV2Item>()))
		{
			newbieCourseV2Item.RefreshCurrentState();
		}
	}

	// Token: 0x0400431E RID: 17182
	private const string NewcomerLogoMaleResourceId = "T_NewcomerLogoMale";

	// Token: 0x0400431F RID: 17183
	private const string NewcomerLogoFemaleResourceId = "T_NewcomerLogoFemale";

	// Token: 0x04004320 RID: 17184
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<NewbieCourseV2Item, NewbieCourseV2> RewardListScrollView;

	// Token: 0x04004321 RID: 17185
	[Nullable(2)]
	private ActivityNewbieCourseV2Data ActivityData;

	// Token: 0x04004322 RID: 17186
	[Nullable(2)]
	private NewbieCourseV2RewardBannerPanel RewardBannerPanel;

	// Token: 0x02007847 RID: 30791
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040295D5 RID: 169429
		public const int BtnReward = 0;

		// Token: 0x040295D6 RID: 169430
		public const int TxtTipNum = 1;

		// Token: 0x040295D7 RID: 169431
		public const int SvList = 2;

		// Token: 0x040295D8 RID: 169432
		public const int QuestItem = 3;

		// Token: 0x040295D9 RID: 169433
		public const int TexLogo = 4;

		// Token: 0x040295DA RID: 169434
		public const int TxtTopInfo = 5;

		// Token: 0x040295DB RID: 169435
		public const int TxtTopTime = 6;
	}
}
