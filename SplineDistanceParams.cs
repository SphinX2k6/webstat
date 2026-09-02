using System;

// Token: 0x020030D8 RID: 12504
public class SplineDistanceParams
{
	// Token: 0x06019CCA RID: 105674 RVA: 0x0078803C File Offset: 0x0078623C
	public SplineDistanceParams(int spline, float r0, float r1, float wt, bool single)
	{
		this.SplineId = spline;
		this.MinSplineDistanceRange = r0;
		this.MaxSplineDistanceRange = r1;
		this.WaitingSplineDistanceRange = wt;
		this.SingleLane = single;
	}

	// Token: 0x0400CE34 RID: 52788
	public int SplineId;

	// Token: 0x0400CE35 RID: 52789
	public float MinSplineDistanceRange = 300f;

	// Token: 0x0400CE36 RID: 52790
	public float MaxSplineDistanceRange = 500f;

	// Token: 0x0400CE37 RID: 52791
	public bool SingleLane;

	// Token: 0x0400CE38 RID: 52792
	public float WaitingSplineDistanceRange = 500f;
}
