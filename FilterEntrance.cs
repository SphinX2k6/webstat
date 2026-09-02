using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

// Token: 0x02001903 RID: 6403
[NullableContext(1)]
[Nullable(0)]
public class FilterEntrance<[Nullable(2)] T> : UiPanelBase
{
	// Token: 0x0600B7BE RID: 47038 RVA: 0x0030DCA4 File Offset: 0x0030BEA4
	public FilterEntrance(UUIItem uiItem, TUpdateDataListFunction<T> updateDataListFunction)
	{
		this.UpdateDataListFunction = updateDataListFunction;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B7BF RID: 47039 RVA: 0x0030DD00 File Offset: 0x0030BF00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OpenFilterView));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnClearClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B7C0 RID: 47040 RVA: 0x0030DE0C File Offset: 0x0030C00C
	private void OpenFilterView()
	{
		FilterViewData viewData = new FilterViewData(this.ResultData.UniqueId, new Action(this.ConfirmFunction));
		ControllerBase<FilterSortController>.Instance.OpenFilterView(viewData);
	}

	// Token: 0x0600B7C1 RID: 47041 RVA: 0x0030DE44 File Offset: 0x0030C044
	private List<IPhantomFilterData> GetFilteredDataList()
	{
		Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> selectRuleData = this.ResultData.GetSelectRuleData();
		return ModelBase<FilterModel>.Instance.GetFilterList<T>(this.DataList, this.ConfigId, selectRuleData).Cast<IPhantomFilterData>().ToList<IPhantomFilterData>();
	}

	// Token: 0x0600B7C2 RID: 47042 RVA: 0x0030DE7E File Offset: 0x0030C07E
	private void OnFilterViewClose()
	{
		FilterToggleItem toggleItem = this.ToggleItem;
		if (toggleItem == null)
		{
			return;
		}
		toggleItem.SetToggleState(EToggleState.ETT_UnChecked);
	}

	// Token: 0x0600B7C3 RID: 47043 RVA: 0x0030DE91 File Offset: 0x0030C091
	private void ConfirmFunction()
	{
		this.SaveStorage();
		this.RefreshName();
		this.UpdateDataList(false);
	}

	// Token: 0x0600B7C4 RID: 47044 RVA: 0x0030DEA6 File Offset: 0x0030C0A6
	private void OnBtnClearClick()
	{
		Action onBtnClearClickCallback = this.OnBtnClearClickCallback;
		if (onBtnClearClickCallback != null)
		{
			onBtnClearClickCallback();
		}
		this.ClearData();
	}

	// Token: 0x0600B7C5 RID: 47045 RVA: 0x0030DEBF File Offset: 0x0030C0BF
	private void ClearData()
	{
		ModelBase<FilterModel>.Instance.ClearData(this.ResultData.UniqueId);
		base.GetItem(1).SetUIActive(false);
		this.SaveStorage();
		this.UpdateDataList(false);
	}

	// Token: 0x0600B7C6 RID: 47046 RVA: 0x0030DEF0 File Offset: 0x0030C0F0
	private void OnToggleStateChange(EToggleState state)
	{
		if (!this.IsPhantomFilter())
		{
			return;
		}
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		PhantomFilterViewData<IPhantomFilterData> viewData = new PhantomFilterViewData<IPhantomFilterData>(this.ResultData.UniqueId, this.GroupId.GetValueOrDefault(), new Action(this.ConfirmFunction), new Func<List<IPhantomFilterData>>(this.GetFilteredDataList), new Action(this.OnFilterViewClose));
		ControllerBase<FilterSortController>.Instance.OpenPhantomFilterView(viewData);
	}

	// Token: 0x0600B7C7 RID: 47047 RVA: 0x0030DF56 File Offset: 0x0030C156
	public bool TryClearData()
	{
		if (this.ConfigId <= 0)
		{
			return false;
		}
		if (StringUtils.IsBlank(this.ResultData.ShowAllFilterContent()))
		{
			return false;
		}
		this.ClearData();
		return true;
	}

	// Token: 0x0600B7C8 RID: 47048 RVA: 0x0030DF7E File Offset: 0x0030C17E
	protected override void OnStart()
	{
		base.GetItem(1).SetUIActive(false);
		this.AddEventListener();
	}

	// Token: 0x0600B7C9 RID: 47049 RVA: 0x0030DF94 File Offset: 0x0030C194
	protected override void OnBeforeDestroy()
	{
		foreach (int uniqueId in this.UniqueIdMap.Values)
		{
			ModelBase<FilterModel>.Instance.DeleteFilterResultData(uniqueId);
		}
		this.UniqueIdMap.Clear();
		this.RemoveEventListener();
		FilterToggleItem toggleItem = this.ToggleItem;
		if (toggleItem != null)
		{
			toggleItem.Destroy(null);
		}
		this.ToggleItem = null;
	}

	// Token: 0x0600B7CA RID: 47050 RVA: 0x0030E01C File Offset: 0x0030C21C
	public void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFilterDataUpdate, new Action<int>(this.OnFilterDataUpdate));
	}

	// Token: 0x0600B7CB RID: 47051 RVA: 0x0030E03A File Offset: 0x0030C23A
	public void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFilterDataUpdate, new Action<int>(this.OnFilterDataUpdate));
	}

	// Token: 0x0600B7CC RID: 47052 RVA: 0x0030E058 File Offset: 0x0030C258
	private void OnFilterDataUpdate(int configId)
	{
		if (this.ConfigId == configId)
		{
			this.UpdateDataList(true);
			this.RefreshName();
		}
	}

	// Token: 0x0600B7CD RID: 47053 RVA: 0x0030E070 File Offset: 0x0030C270
	private void RefreshName()
	{
		string text = this.ResultData.ShowAllFilterContent();
		UUIItem item = base.GetItem(1);
		if (StringUtils.IsBlank(text))
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		base.GetText(2).SetText(text, true);
	}

	// Token: 0x0600B7CE RID: 47054 RVA: 0x0030E0B8 File Offset: 0x0030C2B8
	private void UpdateDataList(bool isOutSideChange)
	{
		Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> selectRuleData = this.ResultData.GetSelectRuleData();
		List<T> filterList = ModelBase<FilterModel>.Instance.GetFilterList<T>(this.DataList, this.ConfigId, selectRuleData);
		SortResultData sortResultData = ModelBase<SortModel>.Instance.GetSortResultData(this.SortUniqueId);
		if (sortResultData != null)
		{
			int sortId = ConfigBase<SortConfig>.Instance.GetSortId(this.GroupId.Value);
			ModelBase<SortModel>.Instance.SortDataList<T>(filterList, sortId, sortResultData, this.ExtraParams.ToArray());
		}
		TUpdateDataListFunction<T> updateDataListFunction = this.UpdateDataListFunction;
		if (updateDataListFunction == null)
		{
			return;
		}
		updateDataListFunction(filterList, isOutSideChange, EFilterSortType.Filter);
	}

	// Token: 0x0600B7CF RID: 47055 RVA: 0x0030E13E File Offset: 0x0030C33E
	public Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> GetSelectRuleDataMap()
	{
		return this.ResultData.GetSelectRuleData();
	}

	// Token: 0x0600B7D0 RID: 47056 RVA: 0x0030E14B File Offset: 0x0030C34B
	[NullableContext(2)]
	private void InitConfigId(EFilterSortGroupId groupId, EFilterSortConfigId? saveConfigId = null, string saveConfigExtraParam = null)
	{
		this.GroupId = new EFilterSortGroupId?(groupId);
		this.ConfigId = ConfigBase<FilterConfig>.Instance.GetFilterId(groupId);
		this.SaveConfigId = saveConfigId;
		this.SaveConfigExtraParam = (saveConfigExtraParam ?? "");
	}

	// Token: 0x0600B7D1 RID: 47057 RVA: 0x0030E184 File Offset: 0x0030C384
	private void SaveStorage()
	{
		if (this.SaveConfigId != null)
		{
			EFilterSortGroupId? groupId = this.GroupId;
			EFilterSortGroupId efilterSortGroupId = EFilterSortGroupId.None;
			if (!(groupId.GetValueOrDefault() == efilterSortGroupId & groupId != null))
			{
				FilterStorageData data = this.ResultData.ConvertToStorageData();
				ModelBase<FilterModel>.Instance.SetFilterConfigData(this.SaveConfigId.Value, (int)this.GroupId.Value, data, this.SaveConfigExtraParam);
			}
		}
	}

	// Token: 0x0600B7D2 RID: 47058 RVA: 0x0030E1F0 File Offset: 0x0030C3F0
	[NullableContext(2)]
	private void InitResultData(FilterStorageData storageData = null)
	{
		int uniqueIdByGroupId = this.GetUniqueIdByGroupId(this.GroupId.Value);
		this.ResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(uniqueIdByGroupId);
		if (this.ResultData == null)
		{
			this.ResultData = new FilterResultData();
			this.ResultData.SetConfigId(this.ConfigId);
			Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> dictionary = new Dictionary<FilterDefine.EFilterType, Dictionary<int, string>>();
			if (storageData != null)
			{
				foreach (KeyValuePair<FilterDefine.EFilterType, List<int>> keyValuePair in storageData.SelectRuleMap)
				{
					FilterDefine.EFilterType key = keyValuePair.Key;
					List<int> value = keyValuePair.Value;
					Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
					foreach (FilterItemData filterItemData in ModelBase<FilterModel>.Instance.GetFilterDataFuncByFilterType(key)(value.ToArray()))
					{
						dictionary2.Add(filterItemData.FilterId, filterItemData.Content);
					}
					dictionary.Add(key, dictionary2);
				}
			}
			this.ResultData.SetRuleData(dictionary);
			ModelBase<FilterModel>.Instance.SetFilterResultData(this.ResultData);
			this.UniqueIdMap.Add((int)this.GroupId.Value, this.ResultData.UniqueId);
		}
	}

	// Token: 0x0600B7D3 RID: 47059 RVA: 0x0030E33C File Offset: 0x0030C53C
	private void HandleFilterActive()
	{
		this.SetActive(this.ConfigId > 0);
	}

	// Token: 0x0600B7D4 RID: 47060 RVA: 0x0030E350 File Offset: 0x0030C550
	private bool IsPhantomFilter()
	{
		return this.ConfigId != 0 && ConfigBase<FilterConfig>.Instance.GetFilterConfig(this.ConfigId).Value.PrefabType == 1;
	}

	// Token: 0x0600B7D5 RID: 47061 RVA: 0x0030E38C File Offset: 0x0030C58C
	private UniTask RefreshToggleButtonActive()
	{
		FilterEntrance<T>.<RefreshToggleButtonActive>d__36 <RefreshToggleButtonActive>d__;
		<RefreshToggleButtonActive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshToggleButtonActive>d__.<>4__this = this;
		<RefreshToggleButtonActive>d__.<>1__state = -1;
		<RefreshToggleButtonActive>d__.<>t__builder.Start<FilterEntrance<T>.<RefreshToggleButtonActive>d__36>(ref <RefreshToggleButtonActive>d__);
		return <RefreshToggleButtonActive>d__.<>t__builder.Task;
	}

	// Token: 0x0600B7D6 RID: 47062 RVA: 0x0030E3D0 File Offset: 0x0030C5D0
	public void UpdateData(EFilterSortGroupId groupId, List<T> dataList, params object[] parameters)
	{
		this.InitConfigId(groupId, null, null);
		this.HandleFilterActive();
		if (this.ConfigId <= 0)
		{
			return;
		}
		this.DataList = dataList;
		this.ExtraParams = new List<object>(parameters);
		this.InitResultData(null);
		this.RefreshName();
		if (ConfigBase<SortConfig>.Instance.GetSortId(this.GroupId.Value) == 0)
		{
			this.UpdateDataList(true);
		}
		this.RefreshToggleButtonActive().Forget();
	}

	// Token: 0x0600B7D7 RID: 47063 RVA: 0x0030E448 File Offset: 0x0030C648
	public void UpdateDataWithConfig(EFilterSortGroupId groupId, EFilterSortConfigId saveConfigId, List<T> dataList, string saveConfigExtraParam = "", params object[] parameters)
	{
		FilterSortConfig sortFilterConfig = ConfigBase<SortConfig>.Instance.GetSortFilterConfig(saveConfigId);
		if (sortFilterConfig.SaveMode == 1 || sortFilterConfig.SaveMode == 3)
		{
			this.UpdateData(groupId, dataList, parameters);
			return;
		}
		this.SaveStorage();
		this.InitConfigId(groupId, new EFilterSortConfigId?(saveConfigId), saveConfigExtraParam);
		this.HandleFilterActive();
		if (this.ConfigId <= 0)
		{
			return;
		}
		this.DataList = dataList;
		this.ExtraParams = new List<object>(parameters);
		FilterStorageData filterConfigData = ModelBase<FilterModel>.Instance.GetFilterConfigData(saveConfigId, (int)this.GroupId.Value, saveConfigExtraParam);
		this.InitResultData(filterConfigData);
		this.RefreshName();
		if (ConfigBase<SortConfig>.Instance.GetSortId(this.GroupId.Value) == 0)
		{
			this.UpdateDataList(true);
		}
		this.RefreshToggleButtonActive().Forget();
	}

	// Token: 0x0600B7D8 RID: 47064 RVA: 0x0030E508 File Offset: 0x0030C708
	public bool SelectSingleById(int id)
	{
		FilterResultData resultData = this.ResultData;
		if (resultData != null)
		{
			resultData.ClearSelectRuleData();
		}
		foreach (int num in ConfigBase<FilterConfig>.Instance.GetFilterConfig(this.ConfigId).Value.RuleList())
		{
			FilterDefine.EFilterType filterType = (FilterDefine.EFilterType)ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(num).Value.FilterType;
			List<FilterItemData> filterItemDataList = ModelBase<FilterModel>.Instance.GetFilterItemDataList(num, this.ConfigId);
			FilterItemData filterItemData = null;
			foreach (FilterItemData filterItemData2 in filterItemDataList)
			{
				if (filterItemData2.FilterId == id)
				{
					filterItemData = filterItemData2;
					break;
				}
			}
			if (filterItemData != null)
			{
				this.ResultData.AddSingleRuleData(filterType, id, filterItemData.Content ?? "");
				this.ConfirmFunction();
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600B7D9 RID: 47065 RVA: 0x0030E60C File Offset: 0x0030C80C
	public int GetUniqueIdByGroupId(EFilterSortGroupId groupId)
	{
		int result;
		if (this.UniqueIdMap.TryGetValue((int)groupId, out result))
		{
			return result;
		}
		return -1;
	}

	// Token: 0x0600B7DA RID: 47066 RVA: 0x0030E62C File Offset: 0x0030C82C
	public void SetSortUniqueId(int uniqueId)
	{
		this.SortUniqueId = uniqueId;
	}

	// Token: 0x0600B7DB RID: 47067 RVA: 0x0030E635 File Offset: 0x0030C835
	[NullableContext(2)]
	public UUIItem GetFilterToggleItem()
	{
		FilterToggleItem toggleItem = this.ToggleItem;
		if (toggleItem == null)
		{
			return null;
		}
		return toggleItem.GetFilterToggleItem();
	}

	// Token: 0x040056A7 RID: 22183
	private readonly Dictionary<int, int> UniqueIdMap = new Dictionary<int, int>();

	// Token: 0x040056A8 RID: 22184
	private int SortUniqueId = -1;

	// Token: 0x040056A9 RID: 22185
	[Nullable(2)]
	private FilterResultData ResultData;

	// Token: 0x040056AA RID: 22186
	private List<T> DataList = new List<T>();

	// Token: 0x040056AB RID: 22187
	private List<object> ExtraParams = new List<object>();

	// Token: 0x040056AC RID: 22188
	private EFilterSortGroupId? GroupId;

	// Token: 0x040056AD RID: 22189
	private int ConfigId;

	// Token: 0x040056AE RID: 22190
	private EFilterSortConfigId? SaveConfigId;

	// Token: 0x040056AF RID: 22191
	private string SaveConfigExtraParam = "";

	// Token: 0x040056B0 RID: 22192
	[Nullable(2)]
	public Action OnBtnClearClickCallback;

	// Token: 0x040056B1 RID: 22193
	[Nullable(2)]
	private FilterToggleItem ToggleItem;

	// Token: 0x040056B2 RID: 22194
	protected TUpdateDataListFunction<T> UpdateDataListFunction;

	// Token: 0x02007C53 RID: 31827
	[NullableContext(0)]
	private class ECompDefine
	{
		// Token: 0x0402A777 RID: 173943
		public const int Button = 0;

		// Token: 0x0402A778 RID: 173944
		public const int FilterTipsItem = 1;

		// Token: 0x0402A779 RID: 173945
		public const int FilterTips = 2;

		// Token: 0x0402A77A RID: 173946
		public const int ClearButton = 3;
	}
}
