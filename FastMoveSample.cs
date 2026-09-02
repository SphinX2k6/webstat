using System;
using System.Runtime.CompilerServices;

// Token: 0x0200305A RID: 12378
[NullableContext(1)]
[Nullable(0)]
public class FastMoveSample : IClear
{
	// Token: 0x060196E2 RID: 104162 RVA: 0x00758505 File Offset: 0x00756705
	public bool ClearObject()
	{
		return true;
	}

	// Token: 0x0400C946 RID: 51526
	public Vector Location = Vector.Create();

	// Token: 0x0400C947 RID: 51527
	public Rotator Rotation = Rotator.Create();

	// Token: 0x0400C948 RID: 51528
	public Vector LinearVelocity = Vector.Create();

	// Token: 0x0400C949 RID: 51529
	public int MovementMode;
}
