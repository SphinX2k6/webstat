using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200113C RID: 4412
[NullableContext(1)]
[Nullable(0)]
internal class CameraPhaseState : ICameraPhaseState
{
	// Token: 0x17000988 RID: 2440
	// (get) Token: 0x060073BF RID: 29631 RVA: 0x001E308D File Offset: 0x001E128D
	// (set) Token: 0x060073C0 RID: 29632 RVA: 0x001E3095 File Offset: 0x001E1295
	public ECameraPhaseType PhaseType { get; set; }

	// Token: 0x17000989 RID: 2441
	// (get) Token: 0x060073C1 RID: 29633 RVA: 0x001E309E File Offset: 0x001E129E
	// (set) Token: 0x060073C2 RID: 29634 RVA: 0x001E30A6 File Offset: 0x001E12A6
	public Vector StartPos { get; set; } = Vector.Create();

	// Token: 0x1700098A RID: 2442
	// (get) Token: 0x060073C3 RID: 29635 RVA: 0x001E30AF File Offset: 0x001E12AF
	// (set) Token: 0x060073C4 RID: 29636 RVA: 0x001E30B7 File Offset: 0x001E12B7
	public Rotator StartRot { get; set; } = Rotator.Create();

	// Token: 0x1700098B RID: 2443
	// (get) Token: 0x060073C5 RID: 29637 RVA: 0x001E30C0 File Offset: 0x001E12C0
	// (set) Token: 0x060073C6 RID: 29638 RVA: 0x001E30C8 File Offset: 0x001E12C8
	public float StartFov { get; set; }

	// Token: 0x1700098C RID: 2444
	// (get) Token: 0x060073C7 RID: 29639 RVA: 0x001E30D1 File Offset: 0x001E12D1
	// (set) Token: 0x060073C8 RID: 29640 RVA: 0x001E30D9 File Offset: 0x001E12D9
	public Vector TargetPos { get; set; } = Vector.Create();

	// Token: 0x1700098D RID: 2445
	// (get) Token: 0x060073C9 RID: 29641 RVA: 0x001E30E2 File Offset: 0x001E12E2
	// (set) Token: 0x060073CA RID: 29642 RVA: 0x001E30EA File Offset: 0x001E12EA
	public Rotator TargetRot { get; set; } = Rotator.Create();

	// Token: 0x1700098E RID: 2446
	// (get) Token: 0x060073CB RID: 29643 RVA: 0x001E30F3 File Offset: 0x001E12F3
	// (set) Token: 0x060073CC RID: 29644 RVA: 0x001E30FB File Offset: 0x001E12FB
	public float TargetFov { get; set; }

	// Token: 0x1700098F RID: 2447
	// (get) Token: 0x060073CD RID: 29645 RVA: 0x001E3104 File Offset: 0x001E1304
	// (set) Token: 0x060073CE RID: 29646 RVA: 0x001E310C File Offset: 0x001E130C
	public float Duration { get; set; }

	// Token: 0x17000990 RID: 2448
	// (get) Token: 0x060073CF RID: 29647 RVA: 0x001E3115 File Offset: 0x001E1315
	// (set) Token: 0x060073D0 RID: 29648 RVA: 0x001E311D File Offset: 0x001E131D
	public float ElapsedTime { get; set; }

	// Token: 0x17000991 RID: 2449
	// (get) Token: 0x060073D1 RID: 29649 RVA: 0x001E3126 File Offset: 0x001E1326
	// (set) Token: 0x060073D2 RID: 29650 RVA: 0x001E312E File Offset: 0x001E132E
	public FVectorDouble PerformancePos { get; set; }

	// Token: 0x17000992 RID: 2450
	// (get) Token: 0x060073D3 RID: 29651 RVA: 0x001E3137 File Offset: 0x001E1337
	// (set) Token: 0x060073D4 RID: 29652 RVA: 0x001E313F File Offset: 0x001E133F
	public FRotator PerformanceRot { get; set; }

	// Token: 0x17000993 RID: 2451
	// (get) Token: 0x060073D5 RID: 29653 RVA: 0x001E3148 File Offset: 0x001E1348
	// (set) Token: 0x060073D6 RID: 29654 RVA: 0x001E3150 File Offset: 0x001E1350
	public float PerformanceFov { get; set; }
}
