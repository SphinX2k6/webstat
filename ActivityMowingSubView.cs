using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Mowing;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001447 RID: 5191
public class ActivityMowingSubView : ActivitySubViewBase
{
	// Token: 0x0600907F RID: 36991 RVA: 0x0025FB08 File Offset: 0x0025DD08
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
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
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickBtnReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009080 RID: 36992 RVA: 0x0025FD88 File Offset: 0x0025DF88
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityMowingSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityMowingSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009081 RID: 36993 RVA: 0x0025FDCC File Offset: 0x0025DFCC
	protected override void OnStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(scrollViewWithScrollbar, this.CreatePropItem, null, false, null);
		this.FunctionalComponent.SetRewardButtonFunction(new Action(this.OnClickBtnReward));
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.OnClickBtnEnter));
	}

	// Token: 0x06009082 RID: 36994 RVA: 0x0025FE29 File Offset: 0x0025E029
	protected override void OnSetData()
	{
		this.MowingData = (this.ActivityBaseData as ActivityMowingData);
	}

	// Token: 0x06009083 RID: 36995 RVA: 0x0025FE3C File Offset: 0x0025E03C
	protected override void OnAddEventListener()
	{
	}

	// Token: 0x06009084 RID: 36996 RVA: 0x0025FE3E File Offset: 0x0025E03E
	protected override void OnRemoveEventListener()
	{
	}

	// Token: 0x06009085 RID: 36997 RVA: 0x0025FE40 File Offset: 0x0025E040
	protected override void OnRefreshView()
	{
		this.RefreshText();
		this.RefreshRewards();
		this.RefreshState();
		this.RefreshRedDot();
		this.NewInstanceCheck();
	}

	// Token: 0x06009086 RID: 36998 RVA: 0x0025FE60 File Offset: 0x0025E060
	private void NewInstanceCheck()
	{
		bool flag = this.MowingData.IsNewInstanceOpen();
		bool preGuideQuestFinishState = this.MowingData.GetPreGuideQuestFinishState();
		if (flag && preGuideQuestFinishState)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityMowing_Newlevelunlock", null);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew);
		}
	}

	// Token: 0x06009087 RID: 36999 RVA: 0x0025FEA0 File Offset: 0x0025E0A0
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

	// Token: 0x06009088 RID: 37000 RVA: 0x0025FEE0 File Offset: 0x0025E0E0
	private void RefreshText()
	{
		string title = this.MowingData.GetTitle();
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(title, true);
		}
		string desc = this.MowingData.GetDesc();
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.SetText(desc, true);
		}
		UUIText text3 = base.GetText(14);
		if (text3 == null)
		{
			return;
		}
		text3.ShowTextNew("CollectActivity_Button_ahead");
	}

	// Token: 0x06009089 RID: 37001 RVA: 0x0025FF44 File Offset: 0x0025E144
	private void RefreshRewards()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardScrollView.RefreshByData(previewReward, null, false);
	}

	// Token: 0x0600908A RID: 37002 RVA: 0x0025FF74 File Offset: 0x0025E174
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

	// Token: 0x0600908B RID: 37003 RVA: 0x0025FFD4 File Offset: 0x0025E1D4
	private void RefreshRedDot()
	{
		bool rewardRedDotVisible = this.MowingData.IsHaveRewardToGet();
		this.FunctionalComponent.SetRewardRedDotVisible(rewardRedDotVisible);
		bool flag = this.MowingData.IsNewInstanceOpen();
		bool preGuideQuestFinishState = this.MowingData.GetPreGuideQuestFinishState();
		this.FunctionalComponent.FunctionButton.SetRedDotVisible(preGuideQuestFinishState && flag);
	}

	// Token: 0x0600908C RID: 37004 RVA: 0x00260024 File Offset: 0x0025E224
	private void OnClickBtnReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, this.MowingData.GetRewardViewData(), null);
	}

	// Token: 0x0600908D RID: 37005 RVA: 0x00260044 File Offset: 0x0025E244
	private void OnClickBtnEnter()
	{
		if (!this.MowingData.GetPreGuideQuestFinishState())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.MowingData.GetUnFinishPreGuideQuestId(), null);
			return;
		}
		WorldMapViewOpenParams data = new WorldMapViewOpenParams
		{
			MarkId = new int?(ConfigCommonParamById.GetIntConfig("MowingMark").GetValueOrDefault()),
			MarkType = (EMarkType)ConfigCommonParamById.GetIntConfig("MowingMarkType").GetValueOrDefault(),
			OpenFogId = new int?(0)
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		this.MowingData.ReadNewInstance();
	}

	// Token: 0x04004314 RID: 17172
	[Nullable(2)]
	private ActivityMowingData MowingData;

	// Token: 0x04004315 RID: 17173
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x04004316 RID: 17174
	[Nullable(2)]
	private ActivityFunctionalArea FunctionalComponent;

	// Token: 0x04004317 RID: 17175
	[Nullable(1)]
	private readonly Func<CommonItemSmallItemGrid> CreatePropItem = () => new CommonItemSmallItemGrid();

	// Token: 0x02007840 RID: 30784
	private class EActivityMowingComponents
	{
		// Token: 0x040295B0 RID: 169392
		public const int TitleItem = 0;

		// Token: 0x040295B1 RID: 169393
		public const int TxtTitle = 1;

		// Token: 0x040295B2 RID: 169394
		public const int DescItem = 2;

		// Token: 0x040295B3 RID: 169395
		public const int TxtDesc = 3;

		// Token: 0x040295B4 RID: 169396
		public const int RewardItem = 4;

		// Token: 0x040295B5 RID: 169397
		public const int RewardScrollView = 5;

		// Token: 0x040295B6 RID: 169398
		public const int FunctionItem = 6;

		// Token: 0x040295B7 RID: 169399
		public const int PnlAactive = 7;

		// Token: 0x040295B8 RID: 169400
		public const int RewardButtonItem = 8;

		// Token: 0x040295B9 RID: 169401
		public const int BtnEnter = 9;

		// Token: 0x040295BA RID: 169402
		public const int TxtTime = 10;

		// Token: 0x040295BB RID: 169403
		public const int PnlButton = 11;

		// Token: 0x040295BC RID: 169404
		public const int RedDot = 12;

		// Token: 0x040295BD RID: 169405
		public const int TxtCondition = 13;

		// Token: 0x040295BE RID: 169406
		public const int TxtConfirm = 14;

		// Token: 0x040295BF RID: 169407
		public const int BtnReward = 15;
	}
}
