using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using FilterDefine;

// Token: 0x020018FD RID: 6397
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FilterModel : ModelBase<FilterModel>
{
	// Token: 0x0600B79A RID: 47002 RVA: 0x0030D76F File Offset: 0x0030B96F
	public void SetFilterResultData(FilterResultData viewData)
	{
		this.FilterResultDataMap[viewData.UniqueId] = viewData;
	}

	// Token: 0x0600B79B RID: 47003 RVA: 0x0030D783 File Offset: 0x0030B983
	public void DeleteFilterResultData(int uniqueId)
	{
		if (uniqueId == -1)
		{
			return;
		}
		this.FilterResultDataMap.Remove(uniqueId);
	}

	// Token: 0x0600B79C RID: 47004 RVA: 0x0030D798 File Offset: 0x0030B998
	[NullableContext(2)]
	public FilterResultData GetFilterResultData(int uniqueId)
	{
		if (uniqueId == -1)
		{
			return null;
		}
		FilterResultData result;
		this.FilterResultDataMap.TryGetValue(uniqueId, out result);
		return result;
	}

	// Token: 0x0600B79D RID: 47005 RVA: 0x0030D7BC File Offset: 0x0030B9BC
	public void ClearData(int uniqueId)
	{
		if (uniqueId == -1)
		{
			return;
		}
		FilterResultData filterResultData;
		if (this.FilterResultDataMap.TryGetValue(uniqueId, out filterResultData) && filterResultData != null)
		{
			filterResultData.ClearSelectRuleData();
		}
	}

	// Token: 0x0600B79E RID: 47006 RVA: 0x0030D7E8 File Offset: 0x0030B9E8
	public List<T> GetFilterList<[Nullable(2)] T>(List<T> dataList, int filterId, Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> ruleData)
	{
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterId);
		EFilterDataType dataType = (EFilterDataType)filterConfig.Value.DataType;
		bool isSupportSelectAll = filterConfig.Value.IsSupportSelectAll;
		bool isSelectAllUnion = filterConfig.Value.IsSelectAllUnion;
		return this.FilterLogic.GetFilterList<T>(dataList, dataType, isSupportSelectAll, isSelectAllUnion, ruleData);
	}

	// Token: 0x0600B79F RID: 47007 RVA: 0x0030D844 File Offset: 0x0030BA44
	public Func<int[], FilterItemData[]> GetFilterDataFuncByFilterType(FilterDefine.EFilterType filterType)
	{
		return this.FilterLogic.GetDataFuncByType(filterType);
	}

	// Token: 0x0600B7A0 RID: 47008 RVA: 0x0030D852 File Offset: 0x0030BA52
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<FilterItemData> GetFilterItemDataList(int ruleId, int configId)
	{
		return this.FilterLogic.GetFilterItemDataList(ruleId, configId);
	}

	// Token: 0x0600B7A1 RID: 47009 RVA: 0x0030D864 File Offset: 0x0030BA64
	[return: Nullable(2)]
	public FilterStorageData GetFilterConfigData(EFilterSortConfigId saveConfigId, int groupId, string extraParam)
	{
		if (!ConfigBase<SortConfig>.Instance.IsConfigSortSave(saveConfigId, groupId))
		{
			return null;
		}
		string configSortFormatId = ConfigBase<SortConfig>.Instance.GetConfigSortFormatId(saveConfigId, groupId, extraParam);
		Dictionary<string, FilterStorageData> player = LocalStorage.GetPlayer<Dictionary<string, FilterStorageData>>(ELocalStoragePlayerKey.FilterConfig, null);
		FilterStorageData result;
		if (player != null && player.TryGetValue(configSortFormatId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600B7A2 RID: 47010 RVA: 0x0030D8AC File Offset: 0x0030BAAC
	public void SetFilterConfigData(EFilterSortConfigId saveConfigId, int groupId, FilterStorageData data, string extraParam)
	{
		if (!ConfigBase<SortConfig>.Instance.IsConfigSortSave(saveConfigId, groupId))
		{
			return;
		}
		string configSortFormatId = ConfigBase<SortConfig>.Instance.GetConfigSortFormatId(saveConfigId, groupId, extraParam);
		Dictionary<string, FilterStorageData> dictionary = LocalStorage.GetPlayer<Dictionary<string, FilterStorageData>>(ELocalStoragePlayerKey.FilterConfig, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, FilterStorageData>();
		}
		dictionary[configSortFormatId] = data;
		LocalStorage.SetPlayer<Dictionary<string, FilterStorageData>>(ELocalStoragePlayerKey.FilterConfig, dictionary);
	}

	// Token: 0x0600B7A3 RID: 47011 RVA: 0x0030D8FC File Offset: 0x0030BAFC
	public void ClearFilterConfigData(EFilterSortConfigId saveConfigId, int groupId, string extraParam)
	{
		if (!ConfigBase<SortConfig>.Instance.IsConfigSortSave(saveConfigId, groupId))
		{
			return;
		}
		string configSortFormatId = ConfigBase<SortConfig>.Instance.GetConfigSortFormatId(saveConfigId, groupId, extraParam);
		Dictionary<string, FilterStorageData> player = LocalStorage.GetPlayer<Dictionary<string, FilterStorageData>>(ELocalStoragePlayerKey.FilterConfig, null);
		if (player != null)
		{
			player.Remove(configSortFormatId);
			LocalStorage.SetPlayer<Dictionary<string, FilterStorageData>>(ELocalStoragePlayerKey.FilterConfig, player);
		}
	}

	// Token: 0x0400569A RID: 22170
	private readonly Dictionary<int, FilterResultData> FilterResultDataMap = new Dictionary<int, FilterResultData>();

	// Token: 0x0400569B RID: 22171
	private readonly FilterLogic FilterLogic = new FilterLogic();
}
