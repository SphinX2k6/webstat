using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001927 RID: 6439
public abstract class CommonSort<T> : CommonSort where T : Enum
{
	// Token: 0x0600B91F RID: 47391 RVA: 0x00313AC5 File Offset: 0x00311CC5
	public CommonSort()
	{
		this.SortMap = new Dictionary<T, TSortResult>();
	}

	// Token: 0x0600B920 RID: 47392 RVA: 0x00313AD8 File Offset: 0x00311CD8
	[NullableContext(2)]
	public override TSortResult GetSortFunctionByRuleId(int ruleId)
	{
		TSortResult result;
		if (this.SortMap.TryGetValue((T)((object)Enum.ToObject(typeof(T), ruleId)), out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0400571D RID: 22301
	[Nullable(1)]
	protected Dictionary<T, TSortResult> SortMap;
}
