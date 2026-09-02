using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.InputView;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using FilterDefine;
using UnrealEngine;

// Token: 0x0200191E RID: 6430
[NullableContext(1)]
[Nullable(0)]
public class VisionFilterView : UiViewBase
{
	// Token: 0x0600B8F3 RID: 47347 RVA: 0x00312C96 File Offset: 0x00310E96
	public VisionFilterView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B8F4 RID: 47348 RVA: 0x00312CAC File Offset: 0x00310EAC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ResetView));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.SaveDataAndCloseView));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B8F5 RID: 47349 RVA: 0x00312DD8 File Offset: 0x00310FD8
	private void OnClickClearSearchButton()
	{
		this.CurrentSearchingText = "";
		this.ShowViewBySearchState(false);
		foreach (FilterGroup filterGroup in this.Scroll.GetScrollItemList())
		{
			filterGroup.SetSelectedDataMap(this.TempFilterDataMap);
			filterGroup.InitFilterSetData();
			filterGroup.RefreshGroupItem();
			filterGroup.RefreshSelectAllToggleState();
		}
	}

	// Token: 0x0600B8F6 RID: 47350 RVA: 0x00312E58 File Offset: 0x00311058
	private void OnClickSearchButton(string content)
	{
		this.CurrentSearchingText = content;
		this.TempFilterDataMap.Clear();
		this.RefreshView();
	}

	// Token: 0x0600B8F7 RID: 47351 RVA: 0x00312E74 File Offset: 0x00311074
	protected override void OnStart()
	{
		this.ViewData = (this.OpenParam as FilterViewData);
		this.InitScroller();
		this.SearchComponent = new CommonSearchComponent(base.GetItem(4), new Action<string>(this.SearchResult), new Action(this.ResetSearch));
	}

	// Token: 0x0600B8F8 RID: 47352 RVA: 0x00312EC2 File Offset: 0x003110C2
	private void SearchResult(string content)
	{
		this.OnClickSearchButton(content);
	}

	// Token: 0x0600B8F9 RID: 47353 RVA: 0x00312ECB File Offset: 0x003110CB
	private void ResetSearch()
	{
		this.OnClickClearSearchButton();
	}

	// Token: 0x0600B8FA RID: 47354 RVA: 0x00312ED3 File Offset: 0x003110D3
	private void InitScroller()
	{
		this.Scroll = new GenericScrollView<FilterGroup>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<FilterGroup>(this.InitFilterGroup), null);
		this.SearchScroll = new GenericScrollView<FilterItem>(base.GetScrollViewWithScrollbar(3), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<FilterItem>(this.InitFilterItem), null);
	}

	// Token: 0x0600B8FB RID: 47355 RVA: 0x00312F14 File Offset: 0x00311114
	private ILayoutItem<FilterItem> InitFilterItem(object tempData, UUIItem uiItem, int index)
	{
		FilterItemData filterItemData = (FilterItemData)tempData;
		FilterItem filterItem = new FilterItem(uiItem);
		filterItem.SetToggleFunction(new TFilterItemToggleEvent(this.FilterItemToggleEvent));
		bool bSelected = this.TempFilterDataMap.ContainsKey(filterItemData.FilterId);
		filterItem.ShowTemp(filterItemData, bSelected);
		return new LayoutItem<FilterItem>
		{
			Key = filterItemData,
			Value = filterItem
		};
	}

	// Token: 0x0600B8FC RID: 47356 RVA: 0x00312F6E File Offset: 0x0031116E
	private void FilterItemToggleEvent(EToggleState state, int filterId, string name)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.TempFilterDataMap[filterId] = name;
			return;
		}
		this.TempFilterDataMap.Remove(filterId);
	}

	// Token: 0x0600B8FD RID: 47357 RVA: 0x00312F90 File Offset: 0x00311190
	private ILayoutItem<FilterGroup> InitFilterGroup(object tempData, UUIItem uiItem, int index)
	{
		int ruleId = (int)tempData;
		FilterGroup filterGroup = new FilterGroup(uiItem);
		filterGroup.SetSelectedDataMap(this.TempFilterDataMap);
		filterGroup.SetToggleFunction(new TFilterItemToggleEvent(this.FilterItemToggleEvent));
		filterGroup.SetOnSelectAllFunction(new TOnSelectAllEvent(this.FilterItemToggleEvent));
		filterGroup.ShowTemp(ruleId, this.ViewData.UniqueId);
		FilterDefine.EFilterType filterType = filterGroup.GetFilterType();
		return new LayoutItem<FilterGroup>
		{
			Key = filterType,
			Value = filterGroup
		};
	}

	// Token: 0x0600B8FE RID: 47358 RVA: 0x0031300C File Offset: 0x0031120C
	private void RefreshScroll()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterResultData.ConfigId);
		this.Scroll.RefreshByData<int>(filterConfig.Value.RuleList().ToList<int>(), null);
		this.ShowViewBySearchState(false);
	}

	// Token: 0x0600B8FF RID: 47359 RVA: 0x00313070 File Offset: 0x00311270
	private void RefreshSearchScroller()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterResultData.ConfigId);
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int ruleId in filterConfig.Value.RuleList())
		{
			foreach (FilterItemData filterItemData in ModelBase<FilterModel>.Instance.GetFilterItemDataList(ruleId, filterResultData.ConfigId))
			{
				if (filterItemData.Content.Contains(this.CurrentSearchingText))
				{
					list.Add(filterItemData);
				}
			}
		}
		foreach (FilterGroup filterGroup in this.Scroll.GetScrollItemList())
		{
			foreach (KeyValuePair<int, string> keyValuePair in filterGroup.GetTempFilterDataMap())
			{
				this.TempFilterDataMap[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		this.SearchScroll.RefreshByData<FilterItemData>(list, null);
		this.ShowViewBySearchState(true);
	}

	// Token: 0x0600B900 RID: 47360 RVA: 0x003131F0 File Offset: 0x003113F0
	private void ShowViewBySearchState(bool searchState)
	{
		base.GetScrollViewWithScrollbar(0).RootUIComp.Get().SetUIActive(!searchState);
		base.GetScrollViewWithScrollbar(3).RootUIComp.Get().SetUIActive(searchState);
		this.SearchingState = searchState;
	}

	// Token: 0x0600B901 RID: 47361 RVA: 0x0031323C File Offset: 0x0031143C
	private void ResetView()
	{
		this.TempFilterDataMap.Clear();
		if (!this.SearchingState)
		{
			using (List<FilterGroup>.Enumerator enumerator = this.Scroll.GetScrollItemList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FilterGroup filterGroup = enumerator.Current;
					filterGroup.ResetTempFilterDataMap();
					filterGroup.RefreshGroupItem();
					filterGroup.RefreshSelectAllToggleState();
				}
				return;
			}
		}
		foreach (FilterItem filterItem in this.SearchScroll.GetScrollItemList())
		{
			filterItem.SetToggleState(false);
		}
	}

	// Token: 0x0600B902 RID: 47362 RVA: 0x003132F8 File Offset: 0x003114F8
	private void RefreshView()
	{
		if (StringUtils.IsEmpty(this.CurrentSearchingText))
		{
			this.RefreshScroll();
			return;
		}
		this.RefreshSearchScroller();
	}

	// Token: 0x0600B903 RID: 47363 RVA: 0x00313314 File Offset: 0x00311514
	private void SaveDataAndCloseView()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		filterResultData.ClearSelectRuleData();
		foreach (KeyValuePair<int, string> keyValuePair in this.TempFilterDataMap)
		{
			int filterType;
			if (this.FilterVisionDataMap.TryGetValue(keyValuePair.Key, out filterType))
			{
				filterResultData.AddSingleRuleData((FilterDefine.EFilterType)filterType, keyValuePair.Key, keyValuePair.Value);
			}
		}
		Action confirmFunction = this.ViewData.ConfirmFunction;
		if (confirmFunction != null)
		{
			confirmFunction();
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0600B904 RID: 47364 RVA: 0x003133D4 File Offset: 0x003115D4
	protected override void OnBeforeShow()
	{
		this.FilterVisionDataMap = new Dictionary<int, int>();
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		foreach (int num in ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterResultData.ConfigId).Value.RuleList())
		{
			FilterDefine.EFilterType filterType = (FilterDefine.EFilterType)ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(num).Value.FilterType;
			foreach (FilterItemData filterItemData in ModelBase<FilterModel>.Instance.GetFilterItemDataList(num, filterResultData.ConfigId))
			{
				this.FilterVisionDataMap[filterItemData.FilterId] = (int)filterType;
			}
		}
		this.TempFilterDataMap = new Dictionary<int, string>();
		Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> dictionary = (filterResultData != null) ? filterResultData.GetSelectRuleData() : null;
		if (dictionary != null)
		{
			foreach (KeyValuePair<FilterDefine.EFilterType, Dictionary<int, string>> keyValuePair in dictionary)
			{
				foreach (KeyValuePair<int, string> keyValuePair2 in keyValuePair.Value)
				{
					this.TempFilterDataMap[keyValuePair2.Key] = keyValuePair2.Value;
				}
			}
		}
		this.RefreshView();
	}

	// Token: 0x0600B905 RID: 47365 RVA: 0x00313570 File Offset: 0x00311770
	protected override void OnBeforeDestroy()
	{
		this.SearchComponent.Destroy(null);
	}

	// Token: 0x04005706 RID: 22278
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<FilterGroup> Scroll;

	// Token: 0x04005707 RID: 22279
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<FilterItem> SearchScroll;

	// Token: 0x04005708 RID: 22280
	[Nullable(2)]
	private FilterViewData ViewData;

	// Token: 0x04005709 RID: 22281
	private string CurrentSearchingText = "";

	// Token: 0x0400570A RID: 22282
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> TempFilterDataMap;

	// Token: 0x0400570B RID: 22283
	[Nullable(2)]
	private Dictionary<int, int> FilterVisionDataMap;

	// Token: 0x0400570C RID: 22284
	[Nullable(2)]
	private CommonSearchComponent SearchComponent;

	// Token: 0x0400570D RID: 22285
	private bool SearchingState;

	// Token: 0x02007C71 RID: 31857
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402A7FF RID: 174079
		Scroll,
		// Token: 0x0402A800 RID: 174080
		ClearButton,
		// Token: 0x0402A801 RID: 174081
		ConfirmButton,
		// Token: 0x0402A802 RID: 174082
		SearchScroller,
		// Token: 0x0402A803 RID: 174083
		InputBox
	}
}
