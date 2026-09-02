using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x0200115D RID: 4445
[NullableContext(1)]
[Nullable(0)]
public class ActivityCache
{
	// Token: 0x06007508 RID: 29960 RVA: 0x001EC926 File Offset: 0x001EAB26
	public void InitData()
	{
		this.ActivityCacheMap = (LocalStorage.GetPlayer<Dictionary<string, List<ActivityCacheData>>>(ELocalStoragePlayerKey.Activity, null) ?? new Dictionary<string, List<ActivityCacheData>>());
		this.ActivityServerCache = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Activity) as ServerStorageMapMap);
	}

	// Token: 0x06007509 RID: 29961 RVA: 0x001EC958 File Offset: 0x001EAB58
	public void OnReceiveActivityData()
	{
		Dictionary<int, ActivityBaseData> allActivityMap = ModelBase<ActivityModel>.Instance.GetAllActivityMap();
		List<string> list = new List<string>();
		foreach (KeyValuePair<int, ActivityBaseData> keyValuePair in allActivityMap)
		{
			string cacheKey = keyValuePair.Value.GetCacheKey();
			list.Add(cacheKey);
		}
		List<string> list2 = new List<string>(this.ActivityCacheMap.Keys);
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (!list.Contains(list2[i]))
			{
				this.ActivityCacheMap.Remove(list2[i]);
			}
		}
		if (count != this.ActivityCacheMap.Count)
		{
			LocalStorage.SetPlayer<Dictionary<string, List<ActivityCacheData>>>(ELocalStoragePlayerKey.Activity, this.ActivityCacheMap);
		}
		this.OverrideLocalToServer();
	}

	// Token: 0x0600750A RID: 29962 RVA: 0x001ECA34 File Offset: 0x001EAC34
	private void OverrideLocalToServer()
	{
		Dictionary<int, ActivityBaseData> allActivityMap = ModelBase<ActivityModel>.Instance.GetAllActivityMap();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<int, ActivityBaseData> keyValuePair in allActivityMap)
		{
			string cacheKey = keyValuePair.Value.GetCacheKey();
			dictionary[cacheKey] = keyValuePair.Key;
		}
		foreach (KeyValuePair<string, List<ActivityCacheData>> keyValuePair2 in this.ActivityCacheMap)
		{
			string key = keyValuePair2.Key;
			List<ActivityCacheData> value = keyValuePair2.Value;
			if (dictionary.ContainsKey(key))
			{
				int num = dictionary[key];
				foreach (ActivityCacheData activityCacheData in value)
				{
					if (this.ActivityServerCache.Get(num, activityCacheData.Key) == null)
					{
						this.ActivityServerCache.Set(num, activityCacheData.Key, activityCacheData.Value);
					}
				}
			}
		}
	}

	// Token: 0x0600750B RID: 29963 RVA: 0x001ECB84 File Offset: 0x001EAD84
	public void SaveCacheData(ActivityBaseData activityData, int key1, int key2, int key3, int value)
	{
		int cacheKey = this.GetCacheKey(key1, key2, key3);
		this.ActivityServerCache.Set(activityData.Id, cacheKey, value);
	}

	// Token: 0x0600750C RID: 29964 RVA: 0x001ECBB0 File Offset: 0x001EADB0
	public int GetCacheData(ActivityBaseData activityData, int defaultValue, int key1, int key2, int key3)
	{
		int cacheKey = this.GetCacheKey(key1, key2, key3);
		int? num = this.ActivityServerCache.Get(activityData.Id, cacheKey);
		if (num != null)
		{
			return num.Value;
		}
		return defaultValue;
	}

	// Token: 0x0600750D RID: 29965 RVA: 0x001ECBEE File Offset: 0x001EADEE
	private int GetCacheKey(int key1, int key2, int key3)
	{
		return key1 * 100000 + key2 * 1000 + key3 * 100;
	}

	// Token: 0x040038B5 RID: 14517
	private Dictionary<string, List<ActivityCacheData>> ActivityCacheMap = new Dictionary<string, List<ActivityCacheData>>();

	// Token: 0x040038B6 RID: 14518
	private ServerStorageMapMap ActivityServerCache;
}
