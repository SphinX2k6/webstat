using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003436 RID: 13366
[NullableContext(1)]
public interface ICatmullRomArcLengthLookup
{
	// Token: 0x1700263C RID: 9788
	// (get) Token: 0x0601C043 RID: 114755
	IReadOnlyList<double> ParamSamples { get; }

	// Token: 0x1700263D RID: 9789
	// (get) Token: 0x0601C044 RID: 114756
	IReadOnlyList<double> CumulativeArcLengths { get; }

	// Token: 0x1700263E RID: 9790
	// (get) Token: 0x0601C045 RID: 114757
	double TotalLength { get; }
}
