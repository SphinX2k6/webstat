using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002D87 RID: 11655
public class BulletActionInfoAttachActor : BulletActionInfoBase
{
	// Token: 0x0601780C RID: 96268 RVA: 0x00683EAB File Offset: 0x006820AB
	public BulletActionInfoAttachActor(EBulletAction type) : base(type)
	{
	}

	// Token: 0x0601780D RID: 96269 RVA: 0x00683EB4 File Offset: 0x006820B4
	public override void Clear()
	{
		this.IsParentActor = false;
		this.Actor = null;
		this.SocketName = null;
		this.LocationRule = null;
		this.RotationRule = null;
		this.ScaleRule = null;
		this.WeldSimulatedBodies = false;
		this.RelativeLocation = null;
		this.RelativeRotation = null;
	}

	// Token: 0x0400B450 RID: 46160
	public bool IsParentActor;

	// Token: 0x0400B451 RID: 46161
	[Nullable(2)]
	public AActor Actor;

	// Token: 0x0400B452 RID: 46162
	public FName? SocketName;

	// Token: 0x0400B453 RID: 46163
	public EAttachmentRule? LocationRule;

	// Token: 0x0400B454 RID: 46164
	public EAttachmentRule? RotationRule;

	// Token: 0x0400B455 RID: 46165
	public EAttachmentRule? ScaleRule;

	// Token: 0x0400B456 RID: 46166
	public bool WeldSimulatedBodies;

	// Token: 0x0400B457 RID: 46167
	public FVectorDouble? RelativeLocation;

	// Token: 0x0400B458 RID: 46168
	public FRotator? RelativeRotation;
}
