using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using FilterDefine;
using UnrealEngine;

// Token: 0x0200191B RID: 6427
[NullableContext(1)]
[Nullable(0)]
public class PinballFilterGroup : UiPanelBase
{
	// Token: 0x0600B8D2 RID: 47314 RVA: 0x00312561 File Offset: 0x00310761
	public PinballFilterGroup(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B8D3 RID: 47315 RVA: 0x00312580 File Offset: 0x00310780
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B8D4 RID: 47316 RVA: 0x0031260A File Offset: 0x0031080A
	protected override void OnStart()
	{
		this.Layout = new GenericLayoutNew<PinballFilterItem>(base.GetLayoutBase(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PinballFilterItem>(this.InitFilterItem), base.GetItem(2));
	}

	// Token: 0x0600B8D5 RID: 47317 RVA: 0x00312634 File Offset: 0x00310834
	private ILayoutItem<PinballFilterItem> InitFilterItem(object tempData, UUIItem uiItem, int index)
	{
		FilterItemData filterItemData = (FilterItemData)tempData;
		PinballFilterItem pinballFilterItem = new PinballFilterItem(uiItem);
		pinballFilterItem.SetToggleFunction(new TFilterItemToggleEvent(this.FilterItemToggleEvent));
		bool bSelected = this.TempFilterDataMap.ContainsKey(filterItemData.FilterId);
		pinballFilterItem.ShowTemp(filterItemData, bSelected);
		return new LayoutItem<PinballFilterItem>
		{
			Key = filterItemData,
			Value = pinballFilterItem
		};
	}

	// Token: 0x0600B8D6 RID: 47318 RVA: 0x0031268E File Offset: 0x0031088E
	private void FilterItemToggleEvent(EToggleState state, int filterId, string name)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.TempFilterDataMap[filterId] = name;
		}
		else
		{
			this.TempFilterDataMap.Remove(filterId);
		}
		TFilterItemToggleEvent toggleFunction = this.ToggleFunction;
		if (toggleFunction == null)
		{
			return;
		}
		toggleFunction(state, filterId, name);
	}

	// Token: 0x0600B8D7 RID: 47319 RVA: 0x003126C3 File Offset: 0x003108C3
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600B8D8 RID: 47320 RVA: 0x003126C5 File Offset: 0x003108C5
	public void SetToggleFunction(TFilterItemToggleEvent toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x0600B8D9 RID: 47321 RVA: 0x003126D0 File Offset: 0x003108D0
	private void InitConfigId()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.UniqueId);
		this.ConfigId = filterResultData.ConfigId;
	}

	// Token: 0x0600B8DA RID: 47322 RVA: 0x003126FA File Offset: 0x003108FA
	private void InitCurrentFilterItemArray()
	{
		this.CurrentFilterItemArray = ModelBase<FilterModel>.Instance.GetFilterItemDataList(this.RuleId, this.ConfigId);
	}

	// Token: 0x0600B8DB RID: 47323 RVA: 0x00312718 File Offset: 0x00310918
	private void SetFilterType()
	{
		this.FilterType = (FilterDefine.EFilterType)ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(this.RuleId).Value.FilterType;
	}

	// Token: 0x0600B8DC RID: 47324 RVA: 0x0031274C File Offset: 0x0031094C
	private void InitTempFilterIdSet()
	{
		this.TempFilterDataMap = new Dictionary<int, string>();
		Dictionary<int, string> selectRuleDataById = ModelBase<FilterModel>.Instance.GetFilterResultData(this.UniqueId).GetSelectRuleDataById(this.FilterType);
		if (selectRuleDataById == null)
		{
			return;
		}
		foreach (KeyValuePair<int, string> keyValuePair in selectRuleDataById)
		{
			this.TempFilterDataMap[keyValuePair.Key] = keyValuePair.Value;
		}
	}

	// Token: 0x0600B8DD RID: 47325 RVA: 0x003127D8 File Offset: 0x003109D8
	public void AddCurrentSelectedFilterData()
	{
		foreach (FilterItemData filterItemData in this.CurrentFilterItemArray)
		{
			int filterId = filterItemData.FilterId;
			string value;
			if (this.CurrentSelectedDataMap != null && this.CurrentSelectedDataMap.TryGetValue(filterId, out value))
			{
				this.TempFilterDataMap[filterId] = value;
			}
		}
	}

	// Token: 0x0600B8DE RID: 47326 RVA: 0x00312850 File Offset: 0x00310A50
	private void SetTitle()
	{
		FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(this.RuleId);
		base.GetText(0).ShowTextNew(filterRuleConfig.Value.Title);
	}

	// Token: 0x0600B8DF RID: 47327 RVA: 0x0031288C File Offset: 0x00310A8C
	private void InitFilter()
	{
		this.Layout.RebuildLayoutByDataNew<FilterItemData>(this.CurrentFilterItemArray, null);
	}

	// Token: 0x0600B8E0 RID: 47328 RVA: 0x003128B3 File Offset: 0x00310AB3
	public void SetSelectedDataMap(Dictionary<int, string> data)
	{
		this.CurrentSelectedDataMap = data;
	}

	// Token: 0x0600B8E1 RID: 47329 RVA: 0x003128BC File Offset: 0x00310ABC
	public void InitFilterSetData()
	{
		this.InitTempFilterIdSet();
		this.AddCurrentSelectedFilterData();
	}

	// Token: 0x0600B8E2 RID: 47330 RVA: 0x003128CA File Offset: 0x00310ACA
	public void ShowTemp(int ruleId, int uniqueId)
	{
		this.RuleId = ruleId;
		this.UniqueId = uniqueId;
		this.InitConfigId();
		this.InitCurrentFilterItemArray();
		this.SetFilterType();
		this.InitFilterSetData();
		this.SetTitle();
		this.InitFilter();
	}

	// Token: 0x0600B8E3 RID: 47331 RVA: 0x00312900 File Offset: 0x00310B00
	public void RefreshGroupItem()
	{
		foreach (KeyValuePair<object, PinballFilterItem> keyValuePair in this.Layout.GetLayoutItemMap())
		{
			FilterItemData filterItemData = keyValuePair.Key as FilterItemData;
			keyValuePair.Value.SetToggleState(this.TempFilterDataMap.ContainsKey(filterItemData.FilterId));
		}
	}

	// Token: 0x0600B8E4 RID: 47332 RVA: 0x0031297C File Offset: 0x00310B7C
	public Dictionary<int, string> GetTempFilterDataMap()
	{
		return this.TempFilterDataMap;
	}

	// Token: 0x0600B8E5 RID: 47333 RVA: 0x00312984 File Offset: 0x00310B84
	public void ResetTempFilterDataMap()
	{
		this.TempFilterDataMap.Clear();
	}

	// Token: 0x0600B8E6 RID: 47334 RVA: 0x00312991 File Offset: 0x00310B91
	public FilterDefine.EFilterType GetFilterType()
	{
		return this.FilterType;
	}

	// Token: 0x040056FA RID: 22266
	private int RuleId;

	// Token: 0x040056FB RID: 22267
	private FilterDefine.EFilterType FilterType = FilterDefine.EFilterType.Weapon;

	// Token: 0x040056FC RID: 22268
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> TempFilterDataMap;

	// Token: 0x040056FD RID: 22269
	[Nullable(2)]
	private TFilterItemToggleEvent ToggleFunction;

	// Token: 0x040056FE RID: 22270
	private int ConfigId;

	// Token: 0x040056FF RID: 22271
	private int UniqueId;

	// Token: 0x04005700 RID: 22272
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<PinballFilterItem> Layout;

	// Token: 0x04005701 RID: 22273
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<int, string> CurrentSelectedDataMap;

	// Token: 0x04005702 RID: 22274
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FilterItemData> CurrentFilterItemArray;

	// Token: 0x02007C6E RID: 31854
	[NullableContext(0)]
	private enum EPinballFilterGroupComponent
	{
		// Token: 0x0402A7F4 RID: 174068
		Title,
		// Token: 0x0402A7F5 RID: 174069
		Layout,
		// Token: 0x0402A7F6 RID: 174070
		FilterItem
	}
}
