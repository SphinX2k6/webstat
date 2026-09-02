using System;
using System.Runtime.CompilerServices;

// Token: 0x020031A5 RID: 12709
[NullableContext(1)]
[Nullable(0)]
public class VehicleEnterBoxDebugGeometry
{
	// Token: 0x0400D49C RID: 54428
	public readonly Vector Center = Vector.Create();

	// Token: 0x0400D49D RID: 54429
	public readonly Rotator Rotation = Rotator.Create();

	// Token: 0x0400D49E RID: 54430
	public float ObstacleHalfLength;

	// Token: 0x0400D49F RID: 54431
	public float ObstacleHalfWidth;

	// Token: 0x0400D4A0 RID: 54432
	public float WaypointHalfLength;

	// Token: 0x0400D4A1 RID: 54433
	public double WaypointHalfWidth;
}
