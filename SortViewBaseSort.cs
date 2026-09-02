using System;
using System.Runtime.CompilerServices;

// Token: 0x02001954 RID: 6484
[NullableContext(1)]
[Nullable(0)]
public class SortViewBaseSort
{
	// Token: 0x0600B9EF RID: 47599 RVA: 0x00318949 File Offset: 0x00316B49
	public SortViewBaseSort(int ruleId, string ruleName)
	{
		this.RuleId = ruleId;
		this.RuleName = ruleName;
	}

	// Token: 0x040057DF RID: 22495
	public int RuleId;

	// Token: 0x040057E0 RID: 22496
	public string RuleName;
}
