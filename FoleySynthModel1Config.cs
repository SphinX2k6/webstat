using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003006 RID: 12294
[NullableContext(1)]
[Nullable(0)]
public class FoleySynthModel1Config : FoleySynthModelConfig
{
	// Token: 0x0400C413 RID: 50195
	public float Ceil;

	// Token: 0x0400C414 RID: 50196
	public string CeilEvent = "";

	// Token: 0x0400C415 RID: 50197
	public float Floor;

	// Token: 0x0400C416 RID: 50198
	public string FloorEvent = "";

	// Token: 0x0400C417 RID: 50199
	[Nullable(2)]
	public UAkRtpc Rtpc;

	// Token: 0x0400C418 RID: 50200
	public float CeilInterpolation;

	// Token: 0x0400C419 RID: 50201
	public float FloorInterpolation;
}
