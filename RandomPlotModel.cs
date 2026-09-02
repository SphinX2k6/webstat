using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002749 RID: 10057
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RandomPlotModel : ModelBase<RandomPlotModel>
{
	// Token: 0x04009A70 RID: 39536
	public Dictionary<int, RandomPlotItem> RandomPlotMap = new Dictionary<int, RandomPlotItem>();

	// Token: 0x04009A71 RID: 39537
	public Dictionary<int, int[]> InstanceTriggerGroupMap = new Dictionary<int, int[]>();

	// Token: 0x04009A72 RID: 39538
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, IRandomPlotCondition> InstanceConditionMap;
}
