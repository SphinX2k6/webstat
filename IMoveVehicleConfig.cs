using System;
using System.Runtime.CompilerServices;

// Token: 0x02003278 RID: 12920
[NullableContext(2)]
[Nullable(0)]
public class IMoveVehicleConfig
{
	// Token: 0x0400DB77 RID: 56183
	public int SplineId;

	// Token: 0x0400DB78 RID: 56184
	public bool? SimulateRotation;

	// Token: 0x0400DB79 RID: 56185
	public bool? FixedPitch;

	// Token: 0x0400DB7A RID: 56186
	public bool? NeedSync;

	// Token: 0x0400DB7B RID: 56187
	public bool? DynamicGravity;

	// Token: 0x0400DB7C RID: 56188
	public bool? StartFromNearest;

	// Token: 0x0400DB7D RID: 56189
	public bool? ForceToFirstPoint;

	// Token: 0x0400DB7E RID: 56190
	public bool? KeepForward;

	// Token: 0x0400DB7F RID: 56191
	public Action<bool> OnArriveStartPointHandle;

	// Token: 0x0400DB80 RID: 56192
	public Action<bool> OnMoveEndHandle;
}
