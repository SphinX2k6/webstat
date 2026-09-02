using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;

// Token: 0x02001952 RID: 6482
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SortModel : ModelBase<SortModel>
{
	// Token: 0x0600B9E5 RID: 47589 RVA: 0x00318773 File Offset: 0x00316973
	public SortModel()
	{
		this.SortResultDataMap = new Dictionary<int, SortResultData>();
		this.SortLogic = new SortLogic();
	}

	// Token: 0x0600B9E6 RID: 47590 RVA: 0x00318794 File Offset: 0x00316994
	public void SetSortResultData(SortResultData viewData)
	{
		SortResultData sortResultData;
		if (this.SortResultDataMap.TryGetValue(viewData.UniqueId, out sortResultData))
		{
			this.SortResultDataMap[viewData.UniqueId] = viewData;
			return;
		}
		this.SortResultDataMap.Add(viewData.UniqueId, viewData);
	}

	// Token: 0x0600B9E7 RID: 47591 RVA: 0x003187DB File Offset: 0x003169DB
	public void DeleteSortResultData(int uniqueId)
	{
		if (uniqueId == -1)
		{
			return;
		}
		this.SortResultDataMap.Remove(uniqueId);
	}

	// Token: 0x0600B9E8 RID: 47592 RVA: 0x003187F0 File Offset: 0x003169F0
	[NullableContext(2)]
	public SortResultData GetSortResultData(int uniqueId)
	{
		if (uniqueId == -1)
		{
			return null;
		}
		SortResultData result;
		if (this.SortResultDataMap.TryGetValue(uniqueId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600B9E9 RID: 47593 RVA: 0x00318816 File Offset: 0x00316A16
	public void SortDataList<[Nullable(2)] T>(List<T> dataList, int config, SortResultData resultData, params object[] parameters)
	{
		this.SortLogic.SortDataList<T>(dataList, config, resultData, parameters);
	}

	// Token: 0x0600B9EA RID: 47594 RVA: 0x00318828 File Offset: 0x00316A28
	public void SortDataByData<[Nullable(2)] T>(List<T> dataList, ESortDataType dataType, HashSet<int> ruleIdSet, bool isAscending)
	{
		this.SortLogic.SortDataByData<T>(dataList, dataType, ruleIdSet, isAscending, Array.Empty<object>());
	}

	// Token: 0x0600B9EB RID: 47595 RVA: 0x00318840 File Offset: 0x00316A40
	[return: Nullable(2)]
	public SortStorageData GetSortConfigData(EFilterSortConfigId saveConfigId, int groupId, string extraParam)
	{
		if (!ConfigBase<SortConfig>.Instance.IsConfigSortSave(saveConfigId, groupId))
		{
			return null;
		}
		string configSortFormatId = ConfigBase<SortConfig>.Instance.GetConfigSortFormatId(saveConfigId, groupId, extraParam);
		Dictionary<string, SortStorageData> player = LocalStorage.GetPlayer<Dictionary<string, SortStorageData>>(ELocalStoragePlayerKey.SortConfig, null);
		SortStorageData result;
		if (player != null && player.TryGetValue(configSortFormatId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600B9EC RID: 47596 RVA: 0x00318888 File Offset: 0x00316A88
	public void SetSortConfigData(EFilterSortConfigId saveConfigId, int groupId, SortStorageData data, string extraParam)
	{
		if (!ConfigBase<SortConfig>.Instance.IsConfigSortSave(saveConfigId, groupId))
		{
			return;
		}
		string configSortFormatId = ConfigBase<SortConfig>.Instance.GetConfigSortFormatId(saveConfigId, groupId, extraParam);
		Dictionary<string, SortStorageData> dictionary = LocalStorage.GetPlayer<Dictionary<string, SortStorageData>>(ELocalStoragePlayerKey.SortConfig, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, SortStorageData>();
		}
		SortStorageData sortStorageData;
		if (dictionary.TryGetValue(configSortFormatId, out sortStorageData))
		{
			dictionary[configSortFormatId] = data;
		}
		else
		{
			dictionary.Add(configSortFormatId, data);
		}
		LocalStorage.SetPlayer<Dictionary<string, SortStorageData>>(ELocalStoragePlayerKey.SortConfig, dictionary);
	}

	// Token: 0x0600B9ED RID: 47597 RVA: 0x003188EC File Offset: 0x00316AEC
	public void ClearSortConfigData(EFilterSortConfigId saveConfigId, int groupId, string extraParam)
	{
		if (!ConfigBase<SortConfig>.Instance.IsConfigSortSave(saveConfigId, groupId))
		{
			return;
		}
		string configSortFormatId = ConfigBase<SortConfig>.Instance.GetConfigSortFormatId(saveConfigId, groupId, extraParam);
		Dictionary<string, SortStorageData> player = LocalStorage.GetPlayer<Dictionary<string, SortStorageData>>(ELocalStoragePlayerKey.SortConfig, null);
		if (player != null)
		{
			player.Remove(configSortFormatId);
			LocalStorage.SetPlayer<Dictionary<string, SortStorageData>>(ELocalStoragePlayerKey.SortConfig, player);
		}
	}

	// Token: 0x040057DB RID: 22491
	private readonly Dictionary<int, SortResultData> SortResultDataMap;

	// Token: 0x040057DC RID: 22492
	private readonly SortLogic SortLogic;
}
