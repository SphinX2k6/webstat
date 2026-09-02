using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024AD RID: 9389
public class PhantomSortMetric
{
	// Token: 0x04008E20 RID: 36384
	public bool HasRecommendMainProp;

	// Token: 0x04008E21 RID: 36385
	public bool HasRecommendSubProp;

	// Token: 0x04008E22 RID: 36386
	public int MainPropUsage;

	// Token: 0x04008E23 RID: 36387
	public int SubPropUsage;

	// Token: 0x04008E24 RID: 36388
	[TupleElementNames(new string[]
	{
		"AddType",
		"PropId"
	})]
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public List<ValueTuple<int, int>> SubPropConfigs;
}
