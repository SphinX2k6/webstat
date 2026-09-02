using System;
using System.Runtime.CompilerServices;

// Token: 0x02002246 RID: 8774
[NullableContext(1)]
[Nullable(0)]
public struct PropertyEntry<[Nullable(2)] TV>
{
	// Token: 0x060108F9 RID: 67833 RVA: 0x00487443 File Offset: 0x00485643
	public PropertyEntry(TV Value, bool IsDirty)
	{
		this.Value = Value;
		this.IsDirty = IsDirty;
	}

	// Token: 0x04008256 RID: 33366
	public TV Value;

	// Token: 0x04008257 RID: 33367
	public bool IsDirty;
}
