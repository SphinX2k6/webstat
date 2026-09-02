using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003433 RID: 13363
[NullableContext(1)]
public interface IBezierArcLengthLookup
{
	// Token: 0x17002636 RID: 9782
	// (get) Token: 0x0601C033 RID: 114739
	IReadOnlyList<double> ParamSamples { get; }

	// Token: 0x17002637 RID: 9783
	// (get) Token: 0x0601C034 RID: 114740
	IReadOnlyList<double> CumulativeArcLengths { get; }

	// Token: 0x17002638 RID: 9784
	// (get) Token: 0x0601C035 RID: 114741
	double TotalLength { get; }
}
