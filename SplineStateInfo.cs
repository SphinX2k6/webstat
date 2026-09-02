using System;
using System.Runtime.CompilerServices;

// Token: 0x02003195 RID: 12693
[NullableContext(1)]
[Nullable(0)]
public class SplineStateInfo
{
	// Token: 0x0601A557 RID: 107863 RVA: 0x007C1DF8 File Offset: 0x007BFFF8
	public SplineStateInfo(int id, Vector loc)
	{
		this.PbDataId = id;
		this.Location = loc;
	}

	// Token: 0x0400D45C RID: 54364
	public int PbDataId;

	// Token: 0x0400D45D RID: 54365
	public Vector Location = Vector.Create();

	// Token: 0x0400D45E RID: 54366
	public bool InRange;
}
