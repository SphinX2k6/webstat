using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C75 RID: 11381
public abstract class UiAnsContextBase
{
	// Token: 0x06016D57 RID: 93527
	[NullableContext(1)]
	public abstract bool IsEqual(UiAnsContextBase inAnsContext);

	// Token: 0x06016D58 RID: 93528 RVA: 0x006563CE File Offset: 0x006545CE
	public virtual bool IsValid()
	{
		return true;
	}

	// Token: 0x0400B008 RID: 45064
	public int ExistCount;

	// Token: 0x0400B009 RID: 45065
	public int CacheCount;
}
