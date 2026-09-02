using System;
using System.Runtime.CompilerServices;

// Token: 0x0200305B RID: 12379
[NullableContext(1)]
[Nullable(0)]
public class ReadOnlyFastMoveSample : IClear
{
	// Token: 0x060196E4 RID: 104164 RVA: 0x00758531 File Offset: 0x00756731
	public bool ClearObject()
	{
		this.IsInit = false;
		this.Location = Vector.Create();
		this.Rotation = Rotator.Create();
		this.LinearVelocity = Vector.Create();
		return true;
	}

	// Token: 0x0400C94A RID: 51530
	public Vector Location = Vector.Create();

	// Token: 0x0400C94B RID: 51531
	public Rotator Rotation = Rotator.Create();

	// Token: 0x0400C94C RID: 51532
	public Vector LinearVelocity = Vector.Create();

	// Token: 0x0400C94D RID: 51533
	public int MovementMode;

	// Token: 0x0400C94E RID: 51534
	public bool IsInit;
}
