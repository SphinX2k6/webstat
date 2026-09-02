using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C7F RID: 11391
[NullableContext(1)]
[Nullable(0)]
public class BuffHandle
{
	// Token: 0x0400B02A RID: 45098
	public readonly HashSet<int> EffectHandleSet = new HashSet<int>();

	// Token: 0x0400B02B RID: 45099
	public readonly HashSet<int> MaterialHandleSet = new HashSet<int>();
}
