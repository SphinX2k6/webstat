using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000074 RID: 116
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class SafeDictionary<[Nullable(2)] TKey, [Nullable(2)] TValue> : Dictionary<TKey, TValue>
{
	// Token: 0x060002C8 RID: 712 RVA: 0x0000F68D File Offset: 0x0000D88D
	public SafeDictionary(TValue defaultValue = default(TValue))
	{
	}

	// Token: 0x1700005D RID: 93
	public new TValue this[TKey key]
	{
		get
		{
			return this.GetValueOrDefault(key, this.<defaultValue>P);
		}
		set
		{
			base.TryAdd(key, value);
		}
	}

	// Token: 0x04000204 RID: 516
	[CompilerGenerated]
	private TValue <defaultValue>P = defaultValue;
}
