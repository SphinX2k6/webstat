using System;

// Token: 0x02000C2A RID: 3114
public class TsFloatRange
{
	// Token: 0x060035DD RID: 13789 RVA: 0x000330CF File Offset: 0x000312CF
	public TsFloatRange(bool exclusive, float min, float max)
	{
		this.Exclusive = exclusive;
		this.Min = min;
		this.Max = max;
	}

	// Token: 0x060035DE RID: 13790 RVA: 0x000330EC File Offset: 0x000312EC
	public bool InRange(float v)
	{
		if (this.Exclusive)
		{
			return v > this.Min && v < this.Max;
		}
		return v >= this.Min && v <= this.Max;
	}

	// Token: 0x040006B2 RID: 1714
	public readonly bool Exclusive;

	// Token: 0x040006B3 RID: 1715
	public readonly float Min;

	// Token: 0x040006B4 RID: 1716
	public readonly float Max;
}
