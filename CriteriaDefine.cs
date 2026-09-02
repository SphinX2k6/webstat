using System;
using System.Runtime.CompilerServices;

// Token: 0x0200344F RID: 13391
[NullableContext(1)]
[Nullable(0)]
public static class CriteriaDefine
{
	// Token: 0x0601C168 RID: 115048 RVA: 0x00861451 File Offset: 0x0085F651
	public static bool AlwaysTrueCriteria<[Nullable(2)] T>(T target)
	{
		return true;
	}

	// Token: 0x0601C169 RID: 115049 RVA: 0x00861454 File Offset: 0x0085F654
	public static bool AlwaysFalseCriteria<[Nullable(2)] T>(T target)
	{
		return false;
	}
}
