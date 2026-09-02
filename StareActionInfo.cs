using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020031C4 RID: 12740
[NullableContext(2)]
[Nullable(0)]
public class StareActionInfo
{
	// Token: 0x0601A69C RID: 108188 RVA: 0x007CA57C File Offset: 0x007C877C
	public void ClearInfo()
	{
		this.TargetLocation.Reset();
		this.TargetItem = null;
		this.TargetActor = null;
	}

	// Token: 0x0601A69D RID: 108189 RVA: 0x007CA598 File Offset: 0x007C8798
	public bool IsValid()
	{
		if (!this.TargetLocation.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
		{
			return true;
		}
		if (this.TargetItem != null)
		{
			return this.TargetItem.Valid;
		}
		return this.TargetActor != null && this.TargetActor.IsValid();
	}

	// Token: 0x0400D52E RID: 54574
	public bool IsDirty;

	// Token: 0x0400D52F RID: 54575
	[Nullable(1)]
	public Vector TargetLocation = Vector.Create();

	// Token: 0x0400D530 RID: 54576
	public BaseActorComponent TargetItem;

	// Token: 0x0400D531 RID: 54577
	public AActor TargetActor;
}
