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

// Token: 0x02001908 RID: 6408
[NullableContext(1)]
[Nullable(0)]
public class FilterGroup : UiPanelBase
{
	// Token: 0x0600B7F4 RID: 47092 RVA: 0x0030E9E6 File Offset: 0x0030CBE6
	public FilterGroup(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B7F5 RID: 47093 RVA: 0x0030EA04 File Offset: 0x0030CC04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.SelectAllEvent));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B7F6 RID: 47094 RVA: 0x0030EB10 File Offset: 0x0030CD10
	private void SelectAllEvent(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			using (Dictionary<object, FilterItem>.Enumerator enumerator = this.Layout.GetLayoutItemMap().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<object, FilterItem> keyValuePair = enumerator.Current;
					FilterItemData filterItemData = keyValuePair.Key as FilterItemData;
					this.TempFilterDataMap[filterItemData.FilterId] = filterItemData.Content;
					TOnSelectAllEvent onSelectAllEvent = this.OnSelectAllEvent;
					if (onSelectAllEvent != null)
					{
						onSelectAllEvent(state, filterItemData.FilterId, filterItemData.Content);
					}
				}
				goto IL_D3;
			}
		}
		if (state == EToggleState.ETT_UnChecked)
		{
			foreach (KeyValuePair<int, string> keyValuePair2 in this.TempFilterDataMap)
			{
				TOnSelectAllEvent onSelectAllEvent2 = this.OnSelectAllEvent;
				if (onSelectAllEvent2 != null)
				{
					onSelectAllEvent2(state, keyValuePair2.Key, keyValuePair2.Value);
				}
			}
			this.ResetTempFilterDataMap();
		}
		IL_D3:
		this.RefreshGroupItem();
	}

	// Token: 0x0600B7F7 RID: 47095 RVA: 0x0030EC14 File Offset: 0x0030CE14
	protected override void OnStart()
	{
		this.Layout = new GenericLayoutNew<FilterItem>(base.GetLayoutBase(3), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<FilterItem>(this.InitFilterItem), base.GetItem(4));
	}

	// Token: 0x0600B7F8 RID: 47096 RVA: 0x0030EC3C File Offset: 0x0030CE3C
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

	// Token: 0x0600B7F9 RID: 47097 RVA: 0x0030EC96 File Offset: 0x0030CE96
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
		this.RefreshSelectAllToggleState();
		TFilterItemToggleEvent toggleFunction = this.ToggleFunction;
		if (toggleFunction == null)
		{
			return;
		}
		toggleFunction(state, filterId, name);
	}

	// Token: 0x0600B7FA RID: 47098 RVA: 0x0030ECD1 File Offset: 0x0030CED1
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600B7FB RID: 47099 RVA: 0x0030ECD3 File Offset: 0x0030CED3
	public void SetToggleFunction(TFilterItemToggleEvent toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x0600B7FC RID: 47100 RVA: 0x0030ECDC File Offset: 0x0030CEDC
	public void SetOnSelectAllFunction(TOnSelectAllEvent toggleFunction)
	{
		this.OnSelectAllEvent = toggleFunction;
	}

	// Token: 0x0600B7FD RID: 47101 RVA: 0x0030ECE8 File Offset: 0x0030CEE8
	private void InitConfigId()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.UniqueId);
		this.ConfigId = filterResultData.ConfigId;
	}

	// Token: 0x0600B7FE RID: 47102 RVA: 0x0030ED12 File Offset: 0x0030CF12
	private void InitCurrentFilterItemArray()
	{
		this.CurrentFilterItemArray = ModelBase<FilterModel>.Instance.GetFilterItemDataList(this.RuleId, this.ConfigId);
	}

	// Token: 0x0600B7FF RID: 47103 RVA: 0x0030ED30 File Offset: 0x0030CF30
	private void SetFilterType()
	{
		this.FilterType = (FilterDefine.EFilterType)ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(this.RuleId).Value.FilterType;
	}

	// Token: 0x0600B800 RID: 47104 RVA: 0x0030ED64 File Offset: 0x0030CF64
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

	// Token: 0x0600B801 RID: 47105 RVA: 0x0030EDF0 File Offset: 0x0030CFF0
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

	// Token: 0x0600B802 RID: 47106 RVA: 0x0030EE68 File Offset: 0x0030D068
	private void SetTitle()
	{
		FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(this.RuleId);
		base.GetText(0).ShowTextNew(filterRuleConfig.Value.Title);
	}

	// Token: 0x0600B803 RID: 47107 RVA: 0x0030EEA4 File Offset: 0x0030D0A4
	private void InitFilter()
	{
		this.Layout.RebuildLayoutByDataNew<FilterItemData>(this.CurrentFilterItemArray, null);
	}

	// Token: 0x0600B804 RID: 47108 RVA: 0x0030EECC File Offset: 0x0030D0CC
	private void SetSelectAll()
	{
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(this.ConfigId);
		base.GetItem(1).SetUIActive(filterConfig.Value.IsSupportSelectAll);
	}

	// Token: 0x0600B805 RID: 47109 RVA: 0x0030EF08 File Offset: 0x0030D108
	public void RefreshSelectAllToggleState()
	{
		if (!ConfigBase<FilterConfig>.Instance.GetFilterConfig(this.ConfigId).Value.IsSupportSelectAll)
		{
			return;
		}
		FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(this.RuleId);
		EToggleState state = (this.TempFilterDataMap.Count == filterRuleConfig.Value.IdList().Length) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(2).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600B806 RID: 47110 RVA: 0x0030EF80 File Offset: 0x0030D180
	public void SetSelectedDataMap(Dictionary<int, string> data)
	{
		this.CurrentSelectedDataMap = data;
	}

	// Token: 0x0600B807 RID: 47111 RVA: 0x0030EF89 File Offset: 0x0030D189
	public void InitFilterSetData()
	{
		this.InitTempFilterIdSet();
		this.AddCurrentSelectedFilterData();
	}

	// Token: 0x0600B808 RID: 47112 RVA: 0x0030EF97 File Offset: 0x0030D197
	public void ShowTemp(int ruleId, int uniqueId)
	{
		this.RuleId = ruleId;
		this.UniqueId = uniqueId;
		this.InitConfigId();
		this.InitCurrentFilterItemArray();
		this.SetFilterType();
		this.InitFilterSetData();
		this.SetTitle();
		this.SetSelectAll();
		this.RefreshSelectAllToggleState();
		this.InitFilter();
	}

	// Token: 0x0600B809 RID: 47113 RVA: 0x0030EFD8 File Offset: 0x0030D1D8
	public void RefreshGroupItem()
	{
		foreach (KeyValuePair<object, FilterItem> keyValuePair in this.Layout.GetLayoutItemMap())
		{
			FilterItemData filterItemData = keyValuePair.Key as FilterItemData;
			keyValuePair.Value.SetToggleState(this.TempFilterDataMap.ContainsKey(filterItemData.FilterId));
		}
	}

	// Token: 0x0600B80A RID: 47114 RVA: 0x0030F054 File Offset: 0x0030D254
	public Dictionary<int, string> GetTempFilterDataMap()
	{
		return this.TempFilterDataMap;
	}

	// Token: 0x0600B80B RID: 47115 RVA: 0x0030F05C File Offset: 0x0030D25C
	public void ResetTempFilterDataMap()
	{
		this.TempFilterDataMap.Clear();
	}

	// Token: 0x0600B80C RID: 47116 RVA: 0x0030F069 File Offset: 0x0030D269
	public FilterDefine.EFilterType GetFilterType()
	{
		return this.FilterType;
	}

	// Token: 0x040056B7 RID: 22199
	private int RuleId;

	// Token: 0x040056B8 RID: 22200
	private FilterDefine.EFilterType FilterType = FilterDefine.EFilterType.Weapon;

	// Token: 0x040056B9 RID: 22201
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> TempFilterDataMap;

	// Token: 0x040056BA RID: 22202
	[Nullable(2)]
	private TFilterItemToggleEvent ToggleFunction;

	// Token: 0x040056BB RID: 22203
	[Nullable(2)]
	private TOnSelectAllEvent OnSelectAllEvent;

	// Token: 0x040056BC RID: 22204
	private int ConfigId;

	// Token: 0x040056BD RID: 22205
	private int UniqueId;

	// Token: 0x040056BE RID: 22206
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<FilterItem> Layout;

	// Token: 0x040056BF RID: 22207
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<int, string> CurrentSelectedDataMap;

	// Token: 0x040056C0 RID: 22208
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FilterItemData> CurrentFilterItemArray;

	// Token: 0x02007C57 RID: 31831
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402A787 RID: 173959
		Title,
		// Token: 0x0402A788 RID: 173960
		SelectAllToggleRootItem,
		// Token: 0x0402A789 RID: 173961
		SelectAllToggle,
		// Token: 0x0402A78A RID: 173962
		Layout,
		// Token: 0x0402A78B RID: 173963
		FilterItem
	}
}
