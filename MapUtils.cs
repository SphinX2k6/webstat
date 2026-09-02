using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C11 RID: 3089
public static class MapUtils
{
	// Token: 0x0600335C RID: 13148 RVA: 0x00028B24 File Offset: 0x00026D24
	[NullableContext(1)]
	[Obsolete]
	public static void ForEach<[Nullable(2)] TKey, [Nullable(2)] TValue>(TMap<TKey, TValue> map, Action<TKey, TValue> lambda)
	{
		foreach (KeyValuePair<TKey, TValue> keyValuePair in map)
		{
			lambda(keyValuePair.Key, keyValuePair.Value);
		}
	}
}
