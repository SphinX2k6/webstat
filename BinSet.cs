using System;
using System.Runtime.CompilerServices;

// Token: 0x02002254 RID: 8788
public class BinSet
{
	// Token: 0x04008271 RID: 33393
	public int BinNum;

	// Token: 0x04008272 RID: 33394
	public double MinX;

	// Token: 0x04008273 RID: 33395
	public double MaxX;

	// Token: 0x04008274 RID: 33396
	public double MinY;

	// Token: 0x04008275 RID: 33397
	public double MaxY;

	// Token: 0x04008276 RID: 33398
	public double DeltaY;

	// Token: 0x04008277 RID: 33399
	public double InvDeltaY;

	// Token: 0x04008278 RID: 33400
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Bin[] Bins;
}
