using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001735 RID: 5941
[NullableContext(1)]
[Nullable(0)]
public class CommonActivityView : UiViewBase
{
	// Token: 0x0600A5A9 RID: 42409 RVA: 0x002BC840 File Offset: 0x002BAA40
	public CommonActivityView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x17000DC7 RID: 3527
	// (get) Token: 0x0600A5AA RID: 42410 RVA: 0x002BC8C0 File Offset: 0x002BAAC0
	private int CurrentSelectActivityId
	{
		get
		{
			int? currentSelectTabId = this.CurrentSelectTabId;
			int? num;
			if (currentSelectTabId == null)
			{
				IActivityCategoryTabData[] tabDataList = this.TabDataList;
				if (tabDataList == null)
				{
					num = null;
				}
				else
				{
					IActivityCategoryTabData activityCategoryTabData = tabDataList.FirstOrDefault<IActivityCategoryTabData>();
					num = ((activityCategoryTabData != null) ? activityCategoryTabData.Id : null);
				}
			}
			else
			{
				num = currentSelectTabId;
			}
			int? num2 = num;
			if (num2 == null)
			{
				return 0;
			}
			int result;
			if (!this.SelectActivityIdMap.TryGetValue((EActivityTimeType)num2.Value, out result))
			{
				return 0;
			}
			return result;
		}
	}

	// Token: 0x0600A5AB RID: 42411 RVA: 0x002BC934 File Offset: 0x002BAB34
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIDynScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickBack));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickTopRedDot));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickBottomRedDot));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A5AC RID: 42412 RVA: 0x002BCC60 File Offset: 0x002BAE60
	protected override void OnAddEventListener()
	{
		this.BindToggleRedDot();
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityViewChange, new Action<int>(this.ActivityViewChange));
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityViewRefresh));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityOpen, new Action<IReadOnlySet<int>>(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnPlaySequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Add<bool, EActivityViewState, bool?>(EEventName.SetActivityViewState, new Action<bool, EActivityViewState, bool?>(this.UpdateListShowState));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, new Action<IReadOnlyList<int>>(this.OnSetActivityViewCurrency));
		Singleton<EventSystem>.Instance.Add(EEventName.ChangeActivityViewNeedBlurState, new Action<bool>(this.OnChangeActivityViewNeedBlurState));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnActivityRedDotUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnServerStorageInfoInited, new Action(this.RefreshRecommendEntryRedDot));
	}

	// Token: 0x0600A5AD RID: 42413 RVA: 0x002BCD8C File Offset: 0x002BAF8C
	protected override void OnRemoveEventListener()
	{
		this.UnBindToggleRedDot();
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityViewChange, new Action<int>(this.ActivityViewChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityViewRefresh));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityOpen, new Action<IReadOnlySet<int>>(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnPlaySequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Remove<bool, EActivityViewState, bool?>(EEventName.SetActivityViewState, new Action<bool, EActivityViewState, bool?>(this.UpdateListShowState));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, new Action<IReadOnlyList<int>>(this.OnSetActivityViewCurrency));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeActivityViewNeedBlurState, new Action<bool>(this.OnChangeActivityViewNeedBlurState));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnActivityRedDotUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnServerStorageInfoInited, new Action(this.RefreshRecommendEntryRedDot));
	}

	// Token: 0x0600A5AE RID: 42414 RVA: 0x002BCEB8 File Offset: 0x002BB0B8
	protected override UniTask OnBeforeStartAsync()
	{
		CommonActivityView.<OnBeforeStartAsync>d__34 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonActivityView.<OnBeforeStartAsync>d__34>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5AF RID: 42415 RVA: 0x002BCEFC File Offset: 0x002BB0FC
	private void InitTabDataList()
	{
		List<IActivityCategoryTabData> list = new List<IActivityCategoryTabData>();
		List<int> sortTabList = this.GetSortTabList();
		if (sortTabList == null)
		{
			return;
		}
		List<ActivityBaseData> currentShowingActivities = ModelBase<ActivityModel>.Instance.GetCurrentShowingActivities();
		foreach (int id in sortTabList)
		{
			ActivityFilter? activityFilter = ConfigBase<ActivityConfig>.Instance.GetActivityFilter(id);
			if (activityFilter != null)
			{
				ActivityFilter value = activityFilter.Value;
				List<ActivityBaseData> list2 = this.FilterActivitiesByTabId(currentShowingActivities, value.Id);
				if (list2.Count != 0)
				{
					if (list.Count > 0 && value.Id == 999)
					{
						list.Add(new ActivityCategoryTabData
						{
							IsLineType = true
						});
					}
					list.Add(new ActivityCategoryTabData
					{
						Id = new int?(value.Id),
						TextId = value.FilterName,
						IsLineType = false,
						IconPath = value.FilterIcon,
						Activities = list2
					});
				}
			}
		}
		this.TabDataList = list.ToArray();
		DynamicScrollView<ActivitySwitchToggle, ActivitySwitchToggleDynamicItem, IActivityCategoryTabData> categoryScrollView = this.CategoryScrollView;
		if (categoryScrollView == null)
		{
			return;
		}
		categoryScrollView.RefreshByData(this.TabDataList, false, false);
	}

	// Token: 0x0600A5B0 RID: 42416 RVA: 0x002BD038 File Offset: 0x002BB238
	[NullableContext(2)]
	private List<int> GetSortTabList()
	{
		IReadOnlyList<ActivityFilter> allActivityFilter = ConfigBase<ActivityConfig>.Instance.GetAllActivityFilter();
		if (allActivityFilter == null)
		{
			return null;
		}
		List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
		foreach (ActivityFilter activityFilter in allActivityFilter)
		{
			list.Add(new ValueTuple<int, int>(activityFilter.Id, activityFilter.SortId));
		}
		list.Sort(([TupleElementNames(new string[]
		{
			"Id",
			"SortId"
		})] ValueTuple<int, int> a, [TupleElementNames(new string[]
		{
			"Id",
			"SortId"
		})] ValueTuple<int, int> b) => a.Item2.CompareTo(b.Item2));
		return (from item in list
		select item.Item1).ToList<int>();
	}

	// Token: 0x0600A5B1 RID: 42417 RVA: 0x002BD0F8 File Offset: 0x002BB2F8
	private ActivitySwitchToggle OnCreateCategoryItemView(IActivityCategoryTabData data, UUIItem uiItem, int index)
	{
		ActivitySwitchToggle activitySwitchToggle = new ActivitySwitchToggle();
		activitySwitchToggle.InitData(data);
		activitySwitchToggle.SetOnToggleClicked(new TOnToggleClickCb(this.ToggleActivityTypeClick));
		return activitySwitchToggle;
	}

	// Token: 0x0600A5B2 RID: 42418 RVA: 0x002BD118 File Offset: 0x002BB318
	private void CreateLeftScrollView()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
		this.SubViewTabLayout = new GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData>(scrollViewWithScrollbar, new Func<ActivityPageSelectContent>(this.InitTabItem), null, false, null);
	}

	// Token: 0x0600A5B3 RID: 42419 RVA: 0x002BD148 File Offset: 0x002BB348
	private UniTask CreateViewSubComponents()
	{
		CommonActivityView.<CreateViewSubComponents>d__39 <CreateViewSubComponents>d__;
		<CreateViewSubComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateViewSubComponents>d__.<>4__this = this;
		<CreateViewSubComponents>d__.<>1__state = -1;
		<CreateViewSubComponents>d__.<>t__builder.Start<CommonActivityView.<CreateViewSubComponents>d__39>(ref <CreateViewSubComponents>d__);
		return <CreateViewSubComponents>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5B4 RID: 42420 RVA: 0x002BD18C File Offset: 0x002BB38C
	protected override void OnStart()
	{
		EActivityViewOpenType openType = EActivityViewOpenType.Other;
		object[] array = this.OpenParam as object[];
		if (array != null && array.Length != 0)
		{
			openType = (EActivityViewOpenType)array[0];
			if (array.Length > 1)
			{
				int num = (int)array[1];
			}
			if (array.Length > 2)
			{
				this.SubViewOpenParam = array[2];
			}
		}
		ModelBase<ActivityModel>.Instance.SendActivityViewOpenLogData(openType);
		this.ViewSaveStateSequence = ActivityViewStateSequence.Value[EActivityViewState.Side].ToList<string>();
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetTitleLocalText("Activity_Title");
		}
		this.SetDebugText();
		this.InitTabDataList();
	}

	// Token: 0x0600A5B5 RID: 42421 RVA: 0x002BD218 File Offset: 0x002BB418
	protected override void OnBeforeShow()
	{
		if (this.CurrentSelectTabId == null)
		{
			int num = 0;
			object[] array = this.OpenParam as object[];
			if (array != null && array.Length != 0)
			{
				EActivityViewOpenType eactivityViewOpenType = (EActivityViewOpenType)array[0];
				if (array.Length > 1)
				{
					num = (int)array[1];
				}
			}
			int? num2 = null;
			List<int> list = new List<int>();
			foreach (IActivityCategoryTabData activityCategoryTabData in this.TabDataList)
			{
				if (!activityCategoryTabData.IsLineType)
				{
					foreach (ActivityBaseData activityBaseData in activityCategoryTabData.Activities)
					{
						list.Add(activityBaseData.Id);
						if (activityBaseData.Id == num)
						{
							num2 = activityCategoryTabData.Id;
						}
					}
				}
			}
			if (num2 == null && num == 0)
			{
				num2 = ModelBase<ActivityModel>.Instance.GetDefaultOpenTabId(this.TabDataList);
			}
			int? num3 = num2;
			int? num4;
			if (num3 == null)
			{
				IActivityCategoryTabData[] tabDataList2 = this.TabDataList;
				if (tabDataList2 == null)
				{
					num4 = null;
				}
				else
				{
					IActivityCategoryTabData activityCategoryTabData2 = tabDataList2.FirstOrDefault<IActivityCategoryTabData>();
					num4 = ((activityCategoryTabData2 != null) ? activityCategoryTabData2.Id : null);
				}
			}
			else
			{
				num4 = num3;
			}
			num2 = num4;
			if (num2 == null)
			{
				return;
			}
			if (ModelBase<ActivityModel>.Instance.GetDebugPermanentFilterVisible())
			{
				if (num2.GetValueOrDefault() != 999)
				{
					this.CurrentPermanentFilterId = ModelBase<ActivityModel>.Instance.GetActivityPermanentFilterId();
				}
				this.InitPermanentFilter();
			}
			this.BindRedDotIds(list.ToArray());
			this.BtnRedDot.Item1 = base.GetButton(11).RootUIComp;
			this.BtnRedDot.Item2 = base.GetButton(12).RootUIComp;
			this.SelectActivityIdMap[(EActivityTimeType)num2.Value] = num;
			this.SelectTabType(num2.Value, true);
		}
		using (List<ActivityBaseData>.Enumerator enumerator = this.ActivityDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.CheckIfInShowTime())
				{
					ControllerBase<ActivityController>.Instance.RequestActivityData().ContinueWith(delegate(bool _)
					{
						this.OnActivityUpdate(null);
					});
					return;
				}
			}
		}
		this.RefreshRedDot(null);
		this.RefreshIndexRedDot();
		this.RefreshRecommendEntryRedDot();
		if (!this.IsViewFirstShow)
		{
			this.RefreshAllBubbleAndCheckTimer();
		}
		GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout = this.SubViewTabLayout;
		if (subViewTabLayout != null)
		{
			subViewTabLayout.BindScrollValueChange(new Action<FVector2D>(this.OnScrollUpdateRedDot));
		}
		ActivitySubViewBase currentShowingActivitySubView = this.CurrentShowingActivitySubView;
		if (currentShowingActivitySubView != null)
		{
			currentShowingActivitySubView.RefreshView();
		}
		Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("CommonActivityView");
		this.IsViewFirstShow = false;
	}

	// Token: 0x0600A5B6 RID: 42422 RVA: 0x002BD4CC File Offset: 0x002BB6CC
	protected override UniTask OnBeforeHideAsync()
	{
		CommonActivityView.<OnBeforeHideAsync>d__42 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<CommonActivityView.<OnBeforeHideAsync>d__42>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5B7 RID: 42423 RVA: 0x002BD510 File Offset: 0x002BB710
	protected override void OnBeforeDestroy()
	{
		ControllerBase<ActivityController>.Instance.DisableRefreshTimer();
		GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout = this.SubViewTabLayout;
		if (subViewTabLayout != null)
		{
			subViewTabLayout.UnBindScrollValueChange();
		}
		if (this.CategoryScrollView != null)
		{
			this.CategoryScrollView.ClearChildren();
			this.CategoryScrollView = null;
		}
		foreach (ActivityCaptionDecorationTagBase activityCaptionDecorationTagBase in this.CaptionDecorationTagCache.Values)
		{
			activityCaptionDecorationTagBase.Destroy(null);
		}
		this.CaptionDecorationTagCache.Clear();
	}

	// Token: 0x0600A5B8 RID: 42424 RVA: 0x002BD5A8 File Offset: 0x002BB7A8
	protected override void OnAfterDestroy()
	{
		ActivitySubViewBase currentShowingActivitySubView = this.CurrentShowingActivitySubView;
		if (currentShowingActivitySubView != null)
		{
			currentShowingActivitySubView.Destroy(null);
		}
		if (this.ActivitySubViewCache != null)
		{
			this.ActivitySubViewCache.Enable = false;
			this.ActivitySubViewCache.Clear();
		}
	}

	// Token: 0x0600A5B9 RID: 42425 RVA: 0x002BD5DB File Offset: 0x002BB7DB
	private ActivitySubViewBase CreateActivitySubView(ActivityBaseData activityData)
	{
		return ActivityManager.GetActivityController(activityData.Type).CreateSubPageComponent(activityData);
	}

	// Token: 0x0600A5BA RID: 42426 RVA: 0x002BD5EE File Offset: 0x002BB7EE
	private void OnEvictActivitySubView(ActivitySubViewBase uiItem)
	{
		if (uiItem.IsShowOrShowing)
		{
			uiItem.Hide(null);
		}
		uiItem.Destroy(null);
	}

	// Token: 0x0600A5BB RID: 42427 RVA: 0x002BD606 File Offset: 0x002BB806
	private void OnClickTopRedDot()
	{
		if (this.ItemRedDot.Item1 != null)
		{
			GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout = this.SubViewTabLayout;
			if (subViewTabLayout == null)
			{
				return;
			}
			subViewTabLayout.ScrollTo(this.ItemRedDot.Item1, false);
		}
	}

	// Token: 0x0600A5BC RID: 42428 RVA: 0x002BD631 File Offset: 0x002BB831
	private void OnClickBottomRedDot()
	{
		if (this.ItemRedDot.Item2 != null)
		{
			GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout = this.SubViewTabLayout;
			if (subViewTabLayout == null)
			{
				return;
			}
			subViewTabLayout.ScrollTo(this.ItemRedDot.Item2, false);
		}
	}

	// Token: 0x0600A5BD RID: 42429 RVA: 0x002BD65C File Offset: 0x002BB85C
	private void OnClickBack()
	{
		this.UpdateListShowState(true, EActivityViewState.Side, null);
	}

	// Token: 0x0600A5BE RID: 42430 RVA: 0x002BD67A File Offset: 0x002BB87A
	private void OnClickActivityRecommend()
	{
		ActivityNewPlayerSupportActivityV2Controller.ReportEntranceClick(ENewPlayerSupportEntrance.ActivityRecommend);
		ModelBase<ActivityRecommendModel>.Instance.MarkEntryFirstClickRead();
		ButtonItem recommendBtnItem = this.RecommendBtnItem;
		if (recommendBtnItem != null)
		{
			recommendBtnItem.SetRedDotVisible(false);
		}
		ControllerBase<ActivityRecommendController>.Instance.OpenView();
	}

	// Token: 0x0600A5BF RID: 42431 RVA: 0x002BD6A8 File Offset: 0x002BB8A8
	private void RefreshRecommendEntryRedDot()
	{
		bool redDotVisible = ModelBase<ActivityRecommendModel>.Instance.IsEntryFirstClickRedDotShow();
		ButtonItem recommendBtnItem = this.RecommendBtnItem;
		if (recommendBtnItem == null)
		{
			return;
		}
		recommendBtnItem.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x0600A5C0 RID: 42432 RVA: 0x002BD6D1 File Offset: 0x002BB8D1
	private void OpenHelpView()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(this.HelpId);
	}

	// Token: 0x0600A5C1 RID: 42433 RVA: 0x002BD6E3 File Offset: 0x002BB8E3
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A5C2 RID: 42434 RVA: 0x002BD6EC File Offset: 0x002BB8EC
	private void ToggleActivityTypeClick(IActivityCategoryTabData data, UUIExtendToggle toggle, EToggleState state)
	{
		int? id = data.Id;
		int? currentSelectTabId = this.CurrentSelectTabId;
		if (id.GetValueOrDefault() == currentSelectTabId.GetValueOrDefault() & id != null == (currentSelectTabId != null))
		{
			UUIExtendToggle currentCategoryToggle = this.CurrentCategoryToggle;
			if (currentCategoryToggle == null)
			{
				return;
			}
			currentCategoryToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		else
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			if (!string.IsNullOrEmpty(data.TextId))
			{
				PopupCaptionItem captionItem = this.CaptionItem;
				if (captionItem != null)
				{
					captionItem.SetTitleLocalText(data.TextId);
				}
			}
			UUIExtendToggle currentCategoryToggle2 = this.CurrentCategoryToggle;
			if (currentCategoryToggle2 != null)
			{
				currentCategoryToggle2.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentCategoryToggle = toggle;
			this.SetActivityTabId(data.Id.Value, true);
			return;
		}
	}

	// Token: 0x0600A5C3 RID: 42435 RVA: 0x002BD79C File Offset: 0x002BB99C
	private void SetActivityTabId(int tabId, bool manual = true)
	{
		this.CurrentSelectTabId = new int?(tabId);
		if (ModelBase<ActivityModel>.Instance.GetDebugPermanentFilterVisible())
		{
			UUIItem item = base.GetItem(13);
			if (item != null)
			{
				item.SetUIActive(tabId == 999);
			}
		}
		else
		{
			UUIItem item2 = base.GetItem(13);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		base.GetItem(8).SetUIActive(false);
		base.GetItem(9).SetUIActive(false);
		UUIItem item3 = this.BtnRedDot.Item1;
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = this.BtnRedDot.Item2;
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		this.IsInRefreshTabItem = true;
		TTimerAction <>9__1;
		this.RefreshTabPageItem(tabId, false).ContinueWith(delegate()
		{
			string sequenceName = manual ? "SwitchModel" : "SwitchList";
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName(sequenceName, true, null, false);
			}
			this.GetItem(8).SetUIActive(true);
			this.GetItem(9).SetUIActive(true);
			this.RefreshIndexRedDot();
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate(float _)
				{
					this.IsInRefreshTabItem = false;
					this.RefreshIndexRedDot();
					this.OnScrollUpdateRedDot(default(FVector2D));
				});
			}
			gameplayTimeInstance.Delay(action, 100f, null, null, true, 1f);
		});
	}

	// Token: 0x0600A5C4 RID: 42436 RVA: 0x002BD870 File Offset: 0x002BBA70
	private void SelectTabType(int tabId, bool bFireEvent)
	{
		IActivityCategoryTabData[] tabDataList = this.TabDataList;
		int? num = (tabDataList != null) ? new int?(tabDataList.ToList<IActivityCategoryTabData>().FindIndex(delegate(IActivityCategoryTabData x)
		{
			int? id = x.Id;
			int tabId2 = tabId;
			return id.GetValueOrDefault() == tabId2 & id != null;
		})) : null;
		if (num == null || num.GetValueOrDefault() == -1)
		{
			return;
		}
		DynamicScrollView<ActivitySwitchToggle, ActivitySwitchToggleDynamicItem, IActivityCategoryTabData> categoryScrollView = this.CategoryScrollView;
		ActivitySwitchToggle activitySwitchToggle = (categoryScrollView != null) ? categoryScrollView.GetScrollItemFromIndex(num.Value) : null;
		if (activitySwitchToggle == null)
		{
			return;
		}
		activitySwitchToggle.OnSelected(bFireEvent);
	}

	// Token: 0x0600A5C5 RID: 42437 RVA: 0x002BD8F4 File Offset: 0x002BBAF4
	private ActivityPageSelectContent InitTabItem()
	{
		ActivityPageSelectContent activityPageSelectContent = new ActivityPageSelectContent();
		activityPageSelectContent.BindCanToggleExecuteChange(new Func<int, bool, bool>(this.CanToggleExecuteChange));
		activityPageSelectContent.BindToggleClick(new Action<ActivityBaseData, bool>(this.ToggleClick));
		return activityPageSelectContent;
	}

	// Token: 0x0600A5C6 RID: 42438 RVA: 0x002BD91F File Offset: 0x002BBB1F
	private bool CanToggleExecuteChange(int id, bool toggleState)
	{
		return true;
	}

	// Token: 0x0600A5C7 RID: 42439 RVA: 0x002BD922 File Offset: 0x002BBB22
	private void ToggleClick(ActivityBaseData data, bool toggleState)
	{
		if (toggleState)
		{
			this.SelectOnActivity(data, true);
		}
	}

	// Token: 0x0600A5C8 RID: 42440 RVA: 0x002BD930 File Offset: 0x002BBB30
	private UniTask SelectOnActivity(ActivityBaseData data, bool playSwitchAnim)
	{
		CommonActivityView.<SelectOnActivity>d__60 <SelectOnActivity>d__;
		<SelectOnActivity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SelectOnActivity>d__.<>4__this = this;
		<SelectOnActivity>d__.data = data;
		<SelectOnActivity>d__.playSwitchAnim = playSwitchAnim;
		<SelectOnActivity>d__.<>1__state = -1;
		<SelectOnActivity>d__.<>t__builder.Start<CommonActivityView.<SelectOnActivity>d__60>(ref <SelectOnActivity>d__);
		return <SelectOnActivity>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5C9 RID: 42441 RVA: 0x002BD983 File Offset: 0x002BBB83
	private void BindToggleRedDot()
	{
	}

	// Token: 0x0600A5CA RID: 42442 RVA: 0x002BD985 File Offset: 0x002BBB85
	private void UnBindToggleRedDot()
	{
	}

	// Token: 0x0600A5CB RID: 42443 RVA: 0x002BD987 File Offset: 0x002BBB87
	private void OnActivityRedDotUpdate(int activityId)
	{
		this.RefreshRedDot(new int?(activityId));
		this.RefreshIndexRedDot();
		this.RefreshBubbleAndCheckTimer(activityId);
	}

	// Token: 0x0600A5CC RID: 42444 RVA: 0x002BD9A4 File Offset: 0x002BBBA4
	public void BindRedDotIds(int[] redDotIds)
	{
		foreach (int value in redDotIds)
		{
			this.RefreshRedDot(new int?(value));
		}
	}

	// Token: 0x0600A5CD RID: 42445 RVA: 0x002BD9D4 File Offset: 0x002BBBD4
	private void RefreshRedDot(int? activityId = null)
	{
		if (activityId != null)
		{
			bool activityRedDotState = ModelBase<ActivityModel>.Instance.GetActivityRedDotState(activityId.Value);
			this.RedDotStateMap[activityId.Value] = activityRedDotState;
			return;
		}
		foreach (ActivityBaseData activityBaseData in this.ActivityDataList)
		{
			bool activityRedDotState2 = ModelBase<ActivityModel>.Instance.GetActivityRedDotState(activityBaseData.Id);
			this.RedDotStateMap[activityBaseData.Id] = activityRedDotState2;
		}
	}

	// Token: 0x0600A5CE RID: 42446 RVA: 0x002BDA74 File Offset: 0x002BBC74
	private void RefreshIndexRedDot()
	{
		if (this.IsInRefreshTabItem || this.IsHideTabSidebar)
		{
			this.ItemRedDot = new ValueTuple<UUIItem, UUIItem>(null, null);
			return;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < this.ActivityDataList.Count; i++)
		{
			int id = this.ActivityDataList[i].Id;
			bool flag;
			if (this.RedDotStateMap.TryGetValue(id, out flag) && flag)
			{
				list.Add(i);
			}
		}
		if (list.Count <= 0)
		{
			this.ItemRedDot = new ValueTuple<UUIItem, UUIItem>(null, null);
			return;
		}
		GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout = this.SubViewTabLayout;
		UUIItem item = (subViewTabLayout != null) ? subViewTabLayout.GetItemByIndex(list[0]) : null;
		GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout2 = this.SubViewTabLayout;
		this.ItemRedDot = new ValueTuple<UUIItem, UUIItem>(item, (subViewTabLayout2 != null) ? subViewTabLayout2.GetItemByIndex(list[list.Count - 1]) : null);
	}

	// Token: 0x0600A5CF RID: 42447 RVA: 0x002BDB44 File Offset: 0x002BBD44
	private void RefreshBubbleAndCheckTimer(int activityId)
	{
		GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout = this.SubViewTabLayout;
		ActivityPageSelectContent activityPageSelectContent;
		if (subViewTabLayout == null)
		{
			activityPageSelectContent = null;
		}
		else
		{
			GenericLayout<ActivityPageSelectContent, ActivityBaseData> genericLayout = subViewTabLayout.GetGenericLayout();
			activityPageSelectContent = ((genericLayout != null) ? genericLayout.GetLayoutItemByKey(activityId) : null);
		}
		ActivityPageSelectContent activityPageSelectContent2 = activityPageSelectContent;
		if (activityPageSelectContent2 == null)
		{
			return;
		}
		activityPageSelectContent2.RefreshBubbleAndCheckTimer();
	}

	// Token: 0x0600A5D0 RID: 42448 RVA: 0x002BDB80 File Offset: 0x002BBD80
	private void RefreshAllBubbleAndCheckTimer()
	{
		GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> subViewTabLayout = this.SubViewTabLayout;
		List<ActivityPageSelectContent> list;
		if (subViewTabLayout == null)
		{
			list = null;
		}
		else
		{
			GenericLayout<ActivityPageSelectContent, ActivityBaseData> genericLayout = subViewTabLayout.GetGenericLayout();
			list = ((genericLayout != null) ? genericLayout.GetLayoutItemList() : null);
		}
		List<ActivityPageSelectContent> list2 = list;
		if (list2 == null)
		{
			return;
		}
		foreach (ActivityPageSelectContent activityPageSelectContent in list2)
		{
			activityPageSelectContent.RefreshBubbleAndCheckTimer();
		}
	}

	// Token: 0x0600A5D1 RID: 42449 RVA: 0x002BDBF0 File Offset: 0x002BBDF0
	private void OnScrollUpdateRedDot(FVector2D _)
	{
		ValueTuple<UUIItem, UUIItem> itemRedDot = this.ItemRedDot;
		if (itemRedDot.Item1 != null && itemRedDot.Item2 != null)
		{
			EOutOfBoundsType eoutOfBoundsType = this.SubViewTabLayout.IsItemInViewport(itemRedDot.Item1, 0.1f);
			EOutOfBoundsType eoutOfBoundsType2 = this.SubViewTabLayout.IsItemInViewport(itemRedDot.Item2, 0.1f);
			this.BtnRedDot.Item1.SetUIActive(eoutOfBoundsType == EOutOfBoundsType.OutOfBegin);
			this.BtnRedDot.Item2.SetUIActive(eoutOfBoundsType2 == EOutOfBoundsType.OutOfEnd);
			return;
		}
		UUIItem item = this.BtnRedDot.Item1;
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = this.BtnRedDot.Item2;
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600A5D2 RID: 42450 RVA: 0x002BDC98 File Offset: 0x002BBE98
	private void OnSetActivityViewCurrency(IReadOnlyList<int> itemConfigList)
	{
		if (itemConfigList.Count <= 0)
		{
			return;
		}
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetCurrencyItemVisible(true);
		}
		PopupCaptionItem captionItem2 = this.CaptionItem;
		if (captionItem2 == null)
		{
			return;
		}
		captionItem2.SetCurrencyItemList(itemConfigList.ToArray<int>()).Forget();
	}

	// Token: 0x0600A5D3 RID: 42451 RVA: 0x002BDCD1 File Offset: 0x002BBED1
	public UUIItem GetCaptionItemToggleRootItem()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return null;
		}
		return captionItem.GetToggleRootItem();
	}

	// Token: 0x0600A5D4 RID: 42452 RVA: 0x002BDCE4 File Offset: 0x002BBEE4
	[NullableContext(2)]
	public UUIItem GetCaptionItemTitleIconRootItem()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return null;
		}
		return captionItem.GetTitleIconRootItem();
	}

	// Token: 0x0600A5D5 RID: 42453 RVA: 0x002BDCF7 File Offset: 0x002BBEF7
	private void OnChangeActivityViewNeedBlurState(bool state)
	{
		UiBehaviourUiBlur uiBlurBehaviour = this.UiBlurBehaviour;
		if (uiBlurBehaviour == null)
		{
			return;
		}
		uiBlurBehaviour.ChangeNeedBlurState(state);
	}

	// Token: 0x0600A5D6 RID: 42454 RVA: 0x002BDD0C File Offset: 0x002BBF0C
	private UniTask RefreshTabPageItem(int tabId, bool playSwitchAnim)
	{
		CommonActivityView.<RefreshTabPageItem>d__74 <RefreshTabPageItem>d__;
		<RefreshTabPageItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabPageItem>d__.<>4__this = this;
		<RefreshTabPageItem>d__.tabId = tabId;
		<RefreshTabPageItem>d__.playSwitchAnim = playSwitchAnim;
		<RefreshTabPageItem>d__.<>1__state = -1;
		<RefreshTabPageItem>d__.<>t__builder.Start<CommonActivityView.<RefreshTabPageItem>d__74>(ref <RefreshTabPageItem>d__);
		return <RefreshTabPageItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5D7 RID: 42455 RVA: 0x002BDD60 File Offset: 0x002BBF60
	private void ActivityViewChange(int activityId)
	{
		if (activityId <= 0)
		{
			return;
		}
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(activityId);
		if (activityById == null)
		{
			return;
		}
		if (!activityById.CheckIfInShowTime())
		{
			return;
		}
		int? num = null;
		if (activityById.TimeType == EActivityTimeType.TimeLimit)
		{
			num = new int?(activityById.LocalConfig.Value.FilterTabType);
		}
		else
		{
			num = new int?(999);
		}
		this.SelectActivityIdMap[(EActivityTimeType)num.Value] = activityById.Id;
		int? num2 = num;
		int? currentSelectTabId = this.CurrentSelectTabId;
		if (!(num2.GetValueOrDefault() == currentSelectTabId.GetValueOrDefault() & num2 != null == (currentSelectTabId != null)))
		{
			this.SelectTabType(num.Value, true);
			return;
		}
		this.RefreshTabPageItem(this.CurrentSelectTabId.Value, true);
	}

	// Token: 0x0600A5D8 RID: 42456 RVA: 0x002BDE2A File Offset: 0x002BC02A
	private void OnActivityViewRefresh(int activityId)
	{
		if (this.CurrentSelectActivityId != activityId)
		{
			return;
		}
		ActivitySubViewBase currentShowingActivitySubView = this.CurrentShowingActivitySubView;
		if (currentShowingActivitySubView == null)
		{
			return;
		}
		currentShowingActivitySubView.RefreshView();
	}

	// Token: 0x0600A5D9 RID: 42457 RVA: 0x002BDE48 File Offset: 0x002BC048
	private UniTask RefreshActivityContent(bool playSwitchAnim)
	{
		CommonActivityView.<RefreshActivityContent>d__77 <RefreshActivityContent>d__;
		<RefreshActivityContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshActivityContent>d__.<>4__this = this;
		<RefreshActivityContent>d__.playSwitchAnim = playSwitchAnim;
		<RefreshActivityContent>d__.<>1__state = -1;
		<RefreshActivityContent>d__.<>t__builder.Start<CommonActivityView.<RefreshActivityContent>d__77>(ref <RefreshActivityContent>d__);
		return <RefreshActivityContent>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5DA RID: 42458 RVA: 0x002BDE94 File Offset: 0x002BC094
	private void RefreshMainView(ActivityBaseData activityData)
	{
		this.HelpId = activityData.GetHelpId();
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetHelpBtnActive(this.HelpId != 0);
		}
		ActivityTipsButton tipsButton = this.TipsButton;
		if (tipsButton != null)
		{
			tipsButton.SetActive(activityData.LocalConfig.Value.ShowPermanentTips);
		}
		bool hideTabSidebar = activityData.LocalConfig.Value.HideTabSidebar;
		base.GetScrollViewWithScrollbar(1).RootUIComp.Get().SetUIActive(!hideTabSidebar);
		UUIItem item = base.GetItem(17);
		if (item != null)
		{
			item.SetUIActive(!hideTabSidebar);
		}
		this.IsHideTabSidebar = hideTabSidebar;
		this.RefreshTabIcon();
	}

	// Token: 0x0600A5DB RID: 42459 RVA: 0x002BDF40 File Offset: 0x002BC140
	private UniTask RefreshCaptionDecorationTag(int activityId)
	{
		CommonActivityView.<RefreshCaptionDecorationTag>d__79 <RefreshCaptionDecorationTag>d__;
		<RefreshCaptionDecorationTag>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCaptionDecorationTag>d__.<>4__this = this;
		<RefreshCaptionDecorationTag>d__.activityId = activityId;
		<RefreshCaptionDecorationTag>d__.<>1__state = -1;
		<RefreshCaptionDecorationTag>d__.<>t__builder.Start<CommonActivityView.<RefreshCaptionDecorationTag>d__79>(ref <RefreshCaptionDecorationTag>d__);
		return <RefreshCaptionDecorationTag>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5DC RID: 42460 RVA: 0x002BDF8C File Offset: 0x002BC18C
	private UniTask RefreshBg(ActivityBaseData activityData)
	{
		CommonActivityView.<RefreshBg>d__80 <RefreshBg>d__;
		<RefreshBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshBg>d__.<>4__this = this;
		<RefreshBg>d__.activityData = activityData;
		<RefreshBg>d__.<>1__state = -1;
		<RefreshBg>d__.<>t__builder.Start<CommonActivityView.<RefreshBg>d__80>(ref <RefreshBg>d__);
		return <RefreshBg>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5DD RID: 42461 RVA: 0x002BDFD8 File Offset: 0x002BC1D8
	private UniTask RefreshSubView(ActivityBaseData activityData, bool playSwitchAnim)
	{
		CommonActivityView.<RefreshSubView>d__81 <RefreshSubView>d__;
		<RefreshSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSubView>d__.<>4__this = this;
		<RefreshSubView>d__.activityData = activityData;
		<RefreshSubView>d__.playSwitchAnim = playSwitchAnim;
		<RefreshSubView>d__.<>1__state = -1;
		<RefreshSubView>d__.<>t__builder.Start<CommonActivityView.<RefreshSubView>d__81>(ref <RefreshSubView>d__);
		return <RefreshSubView>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5DE RID: 42462 RVA: 0x002BE02C File Offset: 0x002BC22C
	public void OnActivityUpdate(IReadOnlySet<int> _ = null)
	{
		Action value = delegate()
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		};
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
		confirmBoxDataNew.FunctionMap[1] = value;
		confirmBoxDataNew.FunctionMap[0] = value;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A5DF RID: 42463 RVA: 0x002BE087 File Offset: 0x002BC287
	private void OnPlaySequenceEventByStringParam(string name)
	{
		ActivitySubViewBase currentShowingActivitySubView = this.CurrentShowingActivitySubView;
		if (currentShowingActivitySubView == null)
		{
			return;
		}
		currentShowingActivitySubView.PlaySubViewSequence(name, false);
	}

	// Token: 0x0600A5E0 RID: 42464 RVA: 0x002BE09C File Offset: 0x002BC29C
	private void UpdateListShowState(bool show, EActivityViewState state = EActivityViewState.Side, bool? blockClick = null)
	{
		this.ViewSaveStateSequence = ActivityViewStateSequence.Value[state].ToList<string>();
		if (show != this.ListShowInternal)
		{
			this.ListShowInternal = show;
			this.UiViewSequence.PlaySequence(show ? this.ViewSaveStateSequence[0] : this.ViewSaveStateSequence[1], blockClick.GetValueOrDefault(), null);
			ActivitySubViewBase currentShowingActivitySubView = this.CurrentShowingActivitySubView;
			if (currentShowingActivitySubView != null)
			{
				currentShowingActivitySubView.OnCommonViewStateChange(show);
			}
		}
		this.RefreshTabIcon();
	}

	// Token: 0x0600A5E1 RID: 42465 RVA: 0x002BE120 File Offset: 0x002BC320
	public void RefreshTabIcon()
	{
		Activity? localConfig = ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentSelectActivityId).LocalConfig;
		string text = this.ListShowInternal ? localConfig.Value.TabResource : localConfig.Value.TabResource2;
		if (!string.IsNullOrEmpty(text))
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetTitleIcon(text);
		}
	}

	// Token: 0x0600A5E2 RID: 42466 RVA: 0x002BE188 File Offset: 0x002BC388
	private void SetDebugText()
	{
		UUIText text = base.GetText(10);
		if (!GlobalData.IsPlayInEditor)
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
	}

	// Token: 0x0600A5E3 RID: 42467 RVA: 0x002BE1B4 File Offset: 0x002BC3B4
	private void RefreshDebugText(int activityId, ActivityType activityType)
	{
		UUIText text = base.GetText(10);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
		defaultInterpolatedStringHandler.AppendLiteral("DebugId: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(activityId);
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)activityType);
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		defaultInterpolatedStringHandler.AppendFormatted<ActivityType>(activityType);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600A5E4 RID: 42468 RVA: 0x002BE21C File Offset: 0x002BC41C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "BackToBattleViewBtn")
		{
			UActorComponent componentInChildren = ULGUIBPLibrary.GetComponentInChildren(base.GetRootActor(), TsUiHomeHelper.StaticClass(), false);
			AActor aactor = (componentInChildren != null) ? componentInChildren.GetOwner() : null;
			if (aactor == null)
			{
				return null;
			}
			UUIButtonComponent uuibuttonComponent = ULGUIBPLibrary.GetComponentInChildren(aactor, UUIButtonComponent.StaticClass(), false) as UUIButtonComponent;
			UUIItem uuiitem = (uuibuttonComponent != null) ? uuibuttonComponent.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
		else if (a == "FirstRecommendActivityTog")
		{
			UUIItem uuiitem2 = null;
			for (int i = 0; i < this.ActivityDataList.Count; i++)
			{
				ActivityBaseData activityBaseData = this.ActivityDataList[i];
				if (activityBaseData.LocalConfig != null && activityBaseData.LocalConfig.GetValueOrDefault().IsTabEffectNotice)
				{
					uuiitem2 = this.SubViewTabLayout.GetItemByIndex(i);
					this.SubViewTabLayout.ScrollTo(uuiitem2, false);
					break;
				}
			}
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
		else
		{
			if (this.CurrentShowingActivitySubView == null)
			{
				return null;
			}
			return this.CurrentShowingActivitySubView.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x0600A5E5 RID: 42469 RVA: 0x002BE33D File Offset: 0x002BC53D
	public bool IsPermanentTab(int tabId)
	{
		return tabId == 999;
	}

	// Token: 0x0600A5E6 RID: 42470 RVA: 0x002BE348 File Offset: 0x002BC548
	public List<ActivityBaseData> FilterActivitiesByTabId(List<ActivityBaseData> activities, int tabId)
	{
		bool isPermanentTab = this.IsPermanentTab(tabId);
		return activities.Where(delegate(ActivityBaseData act)
		{
			if (isPermanentTab)
			{
				return act.TimeType == EActivityTimeType.Permanent;
			}
			return act.TimeType == EActivityTimeType.TimeLimit && act.LocalConfig != null && act.LocalConfig.GetValueOrDefault().FilterTabType == tabId;
		}).ToList<ActivityBaseData>();
	}

	// Token: 0x0600A5E7 RID: 42471 RVA: 0x002BE38C File Offset: 0x002BC58C
	private void OnFilterDropDownSelect(int index, ActivityPermanentFilter data)
	{
		this.CurrentPermanentFilterId = data.Id;
		if (!this.IsPermanentTab(this.CurrentSelectTabId.Value))
		{
			return;
		}
		this.SetActivityTabId(this.CurrentSelectTabId.Value, false);
		ModelBase<ActivityModel>.Instance.SetActivityPermanentFilterId(this.CurrentPermanentFilterId);
	}

	// Token: 0x0600A5E8 RID: 42472 RVA: 0x002BE3DC File Offset: 0x002BC5DC
	private void InitPermanentFilter()
	{
		IReadOnlyList<ActivityPermanentFilter> allActivityPermanentFilter = ConfigBase<ActivityConfig>.Instance.GetAllActivityPermanentFilter();
		if (allActivityPermanentFilter == null)
		{
			return;
		}
		IActivityCategoryTabData[] tabDataList = this.TabDataList;
		IActivityCategoryTabData activityCategoryTabData;
		if (tabDataList == null)
		{
			activityCategoryTabData = null;
		}
		else
		{
			activityCategoryTabData = tabDataList.FirstOrDefault((IActivityCategoryTabData x) => x.Id.GetValueOrDefault() == 999);
		}
		IActivityCategoryTabData activityCategoryTabData2 = activityCategoryTabData;
		List<ActivityPermanentFilter> list = new List<ActivityPermanentFilter>();
		list.Add(allActivityPermanentFilter.First((ActivityPermanentFilter cfg) => cfg.Id == 999));
		if (activityCategoryTabData2 != null)
		{
			List<ActivityBaseData> activities = activityCategoryTabData2.Activities;
			IEnumerable<int> enumerable;
			if (activities == null)
			{
				enumerable = null;
			}
			else
			{
				enumerable = from act in activities
				select act.LocalConfig.Value.PermanentFilterType;
			}
			HashSet<int> hashSet = new HashSet<int>(enumerable ?? Enumerable.Empty<int>());
			foreach (ActivityPermanentFilter item in allActivityPermanentFilter)
			{
				if (item.Id != 999 && hashSet.Contains(item.Id))
				{
					list.Add(item);
				}
			}
		}
		int num = list.FindIndex((ActivityPermanentFilter x) => x.Id == this.CurrentPermanentFilterId);
		if (num == -1)
		{
			num = 0;
		}
		this.FilterDropDown.InitScroll(list, delegate(ActivityPermanentFilter tabCfg)
		{
			ActivityPermanentFilter activityPermanentFilter = tabCfg;
			return new TableTextArgNew(activityPermanentFilter.FilterName, Array.Empty<object>());
		}, num, true);
	}

	// Token: 0x04004E8F RID: 20111
	private bool IsViewFirstShow = true;

	// Token: 0x04004E90 RID: 20112
	private bool ListShowInternal = true;

	// Token: 0x04004E91 RID: 20113
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004E92 RID: 20114
	private int HelpId;

	// Token: 0x04004E93 RID: 20115
	[Nullable(2)]
	private object SubViewOpenParam;

	// Token: 0x04004E94 RID: 20116
	[Nullable(2)]
	private ActivityTipsButton TipsButton;

	// Token: 0x04004E95 RID: 20117
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ActivityPageSelectContent, ActivityBaseData> SubViewTabLayout;

	// Token: 0x04004E96 RID: 20118
	private int? CurrentSelectTabId;

	// Token: 0x04004E97 RID: 20119
	private readonly Dictionary<EActivityTimeType, int> SelectActivityIdMap = new Dictionary<EActivityTimeType, int>();

	// Token: 0x04004E98 RID: 20120
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<ActivitySwitchToggle, ActivitySwitchToggleDynamicItem, IActivityCategoryTabData> CategoryScrollView;

	// Token: 0x04004E99 RID: 20121
	[Nullable(2)]
	private UUIExtendToggle CurrentCategoryToggle;

	// Token: 0x04004E9A RID: 20122
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IActivityCategoryTabData[] TabDataList;

	// Token: 0x04004E9B RID: 20123
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonDropDown<TableTextArgNew, ActivityPermanentFilter> FilterDropDown;

	// Token: 0x04004E9C RID: 20124
	private int CurrentPermanentFilterId = 999;

	// Token: 0x04004E9D RID: 20125
	private bool IsInRefreshTabItem;

	// Token: 0x04004E9E RID: 20126
	private bool IsHideTabSidebar;

	// Token: 0x04004E9F RID: 20127
	private ECaptionDecorationFunc CurrentCaptionDecorationFunc;

	// Token: 0x04004EA0 RID: 20128
	private readonly Dictionary<ECaptionDecorationFunc, ActivityCaptionDecorationTagBase> CaptionDecorationTagCache = new Dictionary<ECaptionDecorationFunc, ActivityCaptionDecorationTagBase>();

	// Token: 0x04004EA1 RID: 20129
	[Nullable(2)]
	private ActivitySubViewBase CurrentShowingActivitySubView;

	// Token: 0x04004EA2 RID: 20130
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Lru<ActivityBaseData, ActivitySubViewBase> ActivitySubViewCache;

	// Token: 0x04004EA3 RID: 20131
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04004EA4 RID: 20132
	private List<ActivityBaseData> ActivityDataList = new List<ActivityBaseData>();

	// Token: 0x04004EA5 RID: 20133
	private readonly Dictionary<int, bool> RedDotStateMap = new Dictionary<int, bool>();

	// Token: 0x04004EA6 RID: 20134
	private List<string> ViewSaveStateSequence = new List<string>();

	// Token: 0x04004EA7 RID: 20135
	[Nullable(new byte[]
	{
		0,
		2,
		2
	})]
	private ValueTuple<UUIItem, UUIItem> ItemRedDot = new ValueTuple<UUIItem, UUIItem>(null, null);

	// Token: 0x04004EA8 RID: 20136
	[Nullable(new byte[]
	{
		0,
		2,
		2
	})]
	private ValueTuple<UUIItem, UUIItem> BtnRedDot = new ValueTuple<UUIItem, UUIItem>(null, null);

	// Token: 0x04004EA9 RID: 20137
	[Nullable(2)]
	private ButtonItem RecommendBtnItem;

	// Token: 0x02007A80 RID: 31360
	[NullableContext(0)]
	private class EActivityComponents
	{
		// Token: 0x04029F81 RID: 171905
		public const int CaptionItem = 0;

		// Token: 0x04029F82 RID: 171906
		public const int TabScrollView = 1;

		// Token: 0x04029F83 RID: 171907
		public const int TabToggle = 2;

		// Token: 0x04029F84 RID: 171908
		public const int SubView = 3;

		// Token: 0x04029F85 RID: 171909
		public const int Panel = 4;

		// Token: 0x04029F86 RID: 171910
		public const int BgTexture = 5;

		// Token: 0x04029F87 RID: 171911
		public const int BtnBack = 6;

		// Token: 0x04029F88 RID: 171912
		public const int PanelTips = 7;

		// Token: 0x04029F89 RID: 171913
		public const int Content = 8;

		// Token: 0x04029F8A RID: 171914
		public const int TabLine = 9;

		// Token: 0x04029F8B RID: 171915
		public const int TxtDebugId = 10;

		// Token: 0x04029F8C RID: 171916
		public const int BtnTopRedDot = 11;

		// Token: 0x04029F8D RID: 171917
		public const int BtnBottomRedDot = 12;

		// Token: 0x04029F8E RID: 171918
		public const int PanelTop = 13;

		// Token: 0x04029F8F RID: 171919
		public const int DropdownA = 14;

		// Token: 0x04029F90 RID: 171920
		public const int DynamicTab = 15;

		// Token: 0x04029F91 RID: 171921
		public const int PanelTab = 16;

		// Token: 0x04029F92 RID: 171922
		public const int PanelSafe = 17;

		// Token: 0x04029F93 RID: 171923
		public const int BtnActivityRecommend = 18;
	}
}
