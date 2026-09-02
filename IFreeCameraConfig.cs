using System;
using UnrealEngine;

// Token: 0x02001137 RID: 4407
public interface IFreeCameraConfig
{
	// Token: 0x17000956 RID: 2390
	// (get) Token: 0x0600735F RID: 29535
	FVectorDouble Pos { get; }

	// Token: 0x17000957 RID: 2391
	// (get) Token: 0x06007360 RID: 29536
	FRotator Rot { get; }

	// Token: 0x17000958 RID: 2392
	// (get) Token: 0x06007361 RID: 29537
	float Fov { get; }

	// Token: 0x17000959 RID: 2393
	// (get) Token: 0x06007362 RID: 29538
	float Radius { get; }

	// Token: 0x1700095A RID: 2394
	// (get) Token: 0x06007363 RID: 29539
	float Interval { get; }

	// Token: 0x1700095B RID: 2395
	// (get) Token: 0x06007364 RID: 29540
	float InterpDuration { get; }
}
