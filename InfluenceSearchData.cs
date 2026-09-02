using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001FE0 RID: 8160
public struct InfluenceSearchData
{
	// Token: 0x0400770F RID: 30479
	public bool HasResult;

	// Token: 0x04007710 RID: 30480
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public List<ValueTuple<int, List<int>>> InfluenceList;
}
