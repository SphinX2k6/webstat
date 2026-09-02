using System;
using System.Runtime.CompilerServices;

// Token: 0x02000C74 RID: 3188
[NullableContext(1)]
[Nullable(0)]
public class QuatNode
{
	// Token: 0x06003928 RID: 14632 RVA: 0x00040D30 File Offset: 0x0003EF30
	public QuatNode(Quat quat, double cost)
	{
		this.Quaternion = Quat.Create(quat);
		this.CostBase = cost;
		this.Cost = 0.0;
		this.VectorCache = Vector.Create();
	}

	// Token: 0x040008DF RID: 2271
	public Quat Quaternion;

	// Token: 0x040008E0 RID: 2272
	public double CostBase;

	// Token: 0x040008E1 RID: 2273
	public double Cost;

	// Token: 0x040008E2 RID: 2274
	public Vector VectorCache;
}
