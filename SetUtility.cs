using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000075 RID: 117
public static class SetUtility
{
	// Token: 0x060002CB RID: 715 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
	[NullableContext(1)]
	public static void AddToSet<[Nullable(2)] T>(HashSet<T> destination, HashSet<T> source)
	{
		foreach (T item in source)
		{
			destination.Add(item);
		}
	}
}
