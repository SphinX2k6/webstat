using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020031A3 RID: 12707
[NullableContext(2)]
[Nullable(0)]
public class VehicleEnterRouteContext
{
	// Token: 0x0400D492 RID: 54418
	public UWorld World;

	// Token: 0x0400D493 RID: 54419
	public double NpcLateral;

	// Token: 0x0400D494 RID: 54420
	public float ObstacleHalfLength;

	// Token: 0x0400D495 RID: 54421
	public float ObstacleHalfWidth;

	// Token: 0x0400D496 RID: 54422
	public float WaypointHalfLength;

	// Token: 0x0400D497 RID: 54423
	public double WaypointHalfWidth;

	// Token: 0x0400D498 RID: 54424
	public VehicleRideLocation SameSideRide;

	// Token: 0x0400D499 RID: 54425
	public VehicleRideLocation OppositeRide;
}
