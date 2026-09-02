using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;

// Token: 0x020030C8 RID: 12488
[RequiredMember]
public class MoveCharacterPoint
{
	// Token: 0x06019C0F RID: 105487 RVA: 0x00780690 File Offset: 0x0077E890
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public MoveCharacterPoint()
	{
	}

	// Token: 0x0400CD65 RID: 52581
	[RequiredMember]
	public int Index;

	// Token: 0x0400CD66 RID: 52582
	[Nullable(1)]
	[RequiredMember]
	public Vector Position;

	// Token: 0x0400CD67 RID: 52583
	[Nullable(2)]
	public Action Callback;

	// Token: 0x0400CD68 RID: 52584
	public EPatrolMoveState? MoveState;

	// Token: 0x0400CD69 RID: 52585
	public ECharPositionState? PosState;

	// Token: 0x0400CD6A RID: 52586
	public float? MoveSpeed;

	// Token: 0x0400CD6B RID: 52587
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ActionInfo> Actions;

	// Token: 0x0400CD6C RID: 52588
	public bool? IsHide;
}
