using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003434 RID: 13364
[NullableContext(1)]
[Nullable(0)]
public class BezierArcLengthLookup : IBezierArcLengthLookup
{
	// Token: 0x17002639 RID: 9785
	// (get) Token: 0x0601C036 RID: 114742 RVA: 0x0085A009 File Offset: 0x00858209
	public IReadOnlyList<double> ParamSamples { get; }

	// Token: 0x1700263A RID: 9786
	// (get) Token: 0x0601C037 RID: 114743 RVA: 0x0085A011 File Offset: 0x00858211
	public IReadOnlyList<double> CumulativeArcLengths { get; }

	// Token: 0x1700263B RID: 9787
	// (get) Token: 0x0601C038 RID: 114744 RVA: 0x0085A019 File Offset: 0x00858219
	public double TotalLength { get; }

	// Token: 0x0601C039 RID: 114745 RVA: 0x0085A021 File Offset: 0x00858221
	public BezierArcLengthLookup(double[] paramSamples, double[] cumulativeArcLengths, double totalLength)
	{
		this.ParamSamples = paramSamples;
		this.CumulativeArcLengths = cumulativeArcLengths;
		this.TotalLength = totalLength;
	}
}
