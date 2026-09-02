using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003007 RID: 12295
[NullableContext(2)]
[Nullable(0)]
public class FoleySynthModel2Config : FoleySynthModelConfig
{
	// Token: 0x0400C41A RID: 50202
	public float Ceil;

	// Token: 0x0400C41B RID: 50203
	[Nullable(1)]
	public string CeilEvent = "";

	// Token: 0x0400C41C RID: 50204
	public float Floor;

	// Token: 0x0400C41D RID: 50205
	[Nullable(1)]
	public string FloorEvent = "";

	// Token: 0x0400C41E RID: 50206
	public float FloorPrecent;

	// Token: 0x0400C41F RID: 50207
	public UAkRtpc RtpcVelMax;

	// Token: 0x0400C420 RID: 50208
	public UAkRtpc RtpcAccMax;

	// Token: 0x0400C421 RID: 50209
	public UAkRtpc RtpcVelDur;

	// Token: 0x0400C422 RID: 50210
	public float CeilInterpolation;

	// Token: 0x0400C423 RID: 50211
	public float FloorInterpolation;
}
