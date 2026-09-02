using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C07 RID: 3079
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DataTableCacheData : Singleton<DataTableCacheData>
{
	// Token: 0x0600330D RID: 13069 RVA: 0x00027741 File Offset: 0x00025941
	public bool TryGet<[Nullable(0)] T>(UDataTable dataTable, string key, [Nullable(2)] out T result) where T : UnrealProxyObject
	{
		result = this.Get<T>(dataTable, key);
		return result != null;
	}

	// Token: 0x0600330E RID: 13070 RVA: 0x00027764 File Offset: 0x00025964
	[return: Nullable(2)]
	public T Get<[Nullable(0)] T>(UDataTable dataTable, string key) where T : UnrealProxyObject
	{
		Dictionary<string, UnrealProxyObject> dictionary;
		if (!this.Cache.TryGetValue(dataTable, out dictionary))
		{
			return default(T);
		}
		return dictionary.GetValueOrDefault(key) as T;
	}

	// Token: 0x0600330F RID: 13071 RVA: 0x0002779C File Offset: 0x0002599C
	public bool Contains(UDataTable dataTable, string key)
	{
		Dictionary<string, UnrealProxyObject> dictionary;
		return this.Cache.TryGetValue(dataTable, out dictionary) && dictionary.ContainsKey(key);
	}

	// Token: 0x06003310 RID: 13072 RVA: 0x000277C4 File Offset: 0x000259C4
	public bool Add<[Nullable(0)] T>(UDataTable dataTable, string key, [Nullable(2)] UnrealProxyObject value) where T : UnrealProxyObject
	{
		Dictionary<string, UnrealProxyObject> dictionary;
		if (!this.Cache.TryGetValue(dataTable, out dictionary))
		{
			dictionary = new Dictionary<string, UnrealProxyObject>();
			this.Cache.Add(dataTable, dictionary);
		}
		return dictionary.TryAdd(key, value);
	}

	// Token: 0x040005B5 RID: 1461
	[Nullable(new byte[]
	{
		1,
		1,
		1,
		1,
		2
	})]
	public Dictionary<UDataTable, Dictionary<string, UnrealProxyObject>> Cache = new Dictionary<UDataTable, Dictionary<string, UnrealProxyObject>>();
}
