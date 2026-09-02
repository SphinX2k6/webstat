using System;
using UnrealEngine;

// Token: 0x02000C13 RID: 3091
public class FastUeFloatRange
{
	// Token: 0x06003361 RID: 13153 RVA: 0x00028B7C File Offset: 0x00026D7C
	public FastUeFloatRange(FFloatRange range)
	{
		this.LowerBoundValue = (double)range.LowerBound.Value;
		this.UpperBoundValue = (double)range.UpperBound.Value;
		this.LowerBoundType = range.LowerBound.Type;
		this.UpperBoundType = range.UpperBound.Type;
	}

	// Token: 0x040005E7 RID: 1511
	public double LowerBoundValue;

	// Token: 0x040005E8 RID: 1512
	public double UpperBoundValue;

	// Token: 0x040005E9 RID: 1513
	public ERangeBoundTypes LowerBoundType;

	// Token: 0x040005EA RID: 1514
	public ERangeBoundTypes UpperBoundType;
}
