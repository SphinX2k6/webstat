using System;

// Token: 0x020011BD RID: 4541
public class ContinuousRingArea : RingArea
{
	// Token: 0x06007778 RID: 30584 RVA: 0x001F3FAF File Offset: 0x001F21AF
	public ContinuousRingArea(int continuousIndex, int startCellIndex, int endCellIndex, EArrowDirection arrowDirection) : base(startCellIndex, endCellIndex, arrowDirection)
	{
		this.ContinuousIndex = continuousIndex;
	}

	// Token: 0x040039D0 RID: 14800
	public int ContinuousIndex;
}
