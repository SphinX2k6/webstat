using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003437 RID: 13367
[NullableContext(1)]
[Nullable(0)]
public class CatmullRomArcLengthLookup : ICatmullRomArcLengthLookup
{
	// Token: 0x1700263F RID: 9791
	// (get) Token: 0x0601C046 RID: 114758 RVA: 0x0085A558 File Offset: 0x00858758
	public IReadOnlyList<double> ParamSamples { get; }

	// Token: 0x17002640 RID: 9792
	// (get) Token: 0x0601C047 RID: 114759 RVA: 0x0085A560 File Offset: 0x00858760
	public IReadOnlyList<double> CumulativeArcLengths { get; }

	// Token: 0x17002641 RID: 9793
	// (get) Token: 0x0601C048 RID: 114760 RVA: 0x0085A568 File Offset: 0x00858768
	public double TotalLength { get; }

	// Token: 0x0601C049 RID: 114761 RVA: 0x0085A570 File Offset: 0x00858770
	public CatmullRomArcLengthLookup(double[] paramSamples, double[] cumulativeArcLengths, double totalLength)
	{
		this.ParamSamples = paramSamples;
		this.CumulativeArcLengths = cumulativeArcLengths;
		this.TotalLength = totalLength;
	}
}
