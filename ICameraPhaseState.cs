using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200113B RID: 4411
[NullableContext(1)]
internal interface ICameraPhaseState
{
	// Token: 0x1700097C RID: 2428
	// (get) Token: 0x060073A7 RID: 29607
	// (set) Token: 0x060073A8 RID: 29608
	ECameraPhaseType PhaseType { get; set; }

	// Token: 0x1700097D RID: 2429
	// (get) Token: 0x060073A9 RID: 29609
	// (set) Token: 0x060073AA RID: 29610
	Vector StartPos { get; set; }

	// Token: 0x1700097E RID: 2430
	// (get) Token: 0x060073AB RID: 29611
	// (set) Token: 0x060073AC RID: 29612
	Rotator StartRot { get; set; }

	// Token: 0x1700097F RID: 2431
	// (get) Token: 0x060073AD RID: 29613
	// (set) Token: 0x060073AE RID: 29614
	float StartFov { get; set; }

	// Token: 0x17000980 RID: 2432
	// (get) Token: 0x060073AF RID: 29615
	// (set) Token: 0x060073B0 RID: 29616
	Vector TargetPos { get; set; }

	// Token: 0x17000981 RID: 2433
	// (get) Token: 0x060073B1 RID: 29617
	// (set) Token: 0x060073B2 RID: 29618
	Rotator TargetRot { get; set; }

	// Token: 0x17000982 RID: 2434
	// (get) Token: 0x060073B3 RID: 29619
	// (set) Token: 0x060073B4 RID: 29620
	float TargetFov { get; set; }

	// Token: 0x17000983 RID: 2435
	// (get) Token: 0x060073B5 RID: 29621
	// (set) Token: 0x060073B6 RID: 29622
	float Duration { get; set; }

	// Token: 0x17000984 RID: 2436
	// (get) Token: 0x060073B7 RID: 29623
	// (set) Token: 0x060073B8 RID: 29624
	float ElapsedTime { get; set; }

	// Token: 0x17000985 RID: 2437
	// (get) Token: 0x060073B9 RID: 29625
	// (set) Token: 0x060073BA RID: 29626
	FVectorDouble PerformancePos { get; set; }

	// Token: 0x17000986 RID: 2438
	// (get) Token: 0x060073BB RID: 29627
	// (set) Token: 0x060073BC RID: 29628
	FRotator PerformanceRot { get; set; }

	// Token: 0x17000987 RID: 2439
	// (get) Token: 0x060073BD RID: 29629
	// (set) Token: 0x060073BE RID: 29630
	float PerformanceFov { get; set; }
}
