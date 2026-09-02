using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020031A2 RID: 12706
public class VehicleEnterRouteCache
{
	// Token: 0x0400D48F RID: 54415
	public int VehicleEntityId;

	// Token: 0x0400D490 RID: 54416
	public CommonNpcPerformComponent.EEnterVehicleDirection Direction;

	// Token: 0x0400D491 RID: 54417
	[Nullable(1)]
	public readonly List<Vector> Path = new List<Vector>();
}
