using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.RhythmGame;

// Token: 0x02001139 RID: 4409
[NullableContext(1)]
internal interface ICameraInterpolationState
{
	// Token: 0x17000962 RID: 2402
	// (get) Token: 0x06007372 RID: 29554
	// (set) Token: 0x06007373 RID: 29555
	Vector StartPos { get; set; }

	// Token: 0x17000963 RID: 2403
	// (get) Token: 0x06007374 RID: 29556
	// (set) Token: 0x06007375 RID: 29557
	Rotator StartRot { get; set; }

	// Token: 0x17000964 RID: 2404
	// (get) Token: 0x06007376 RID: 29558
	// (set) Token: 0x06007377 RID: 29559
	float StartFov { get; set; }

	// Token: 0x17000965 RID: 2405
	// (get) Token: 0x06007378 RID: 29560
	// (set) Token: 0x06007379 RID: 29561
	Vector TargetPos { get; set; }

	// Token: 0x17000966 RID: 2406
	// (get) Token: 0x0600737A RID: 29562
	// (set) Token: 0x0600737B RID: 29563
	Rotator TargetRot { get; set; }

	// Token: 0x17000967 RID: 2407
	// (get) Token: 0x0600737C RID: 29564
	// (set) Token: 0x0600737D RID: 29565
	float TargetFov { get; set; }

	// Token: 0x17000968 RID: 2408
	// (get) Token: 0x0600737E RID: 29566
	// (set) Token: 0x0600737F RID: 29567
	Vector CurrentPos { get; set; }

	// Token: 0x17000969 RID: 2409
	// (get) Token: 0x06007380 RID: 29568
	// (set) Token: 0x06007381 RID: 29569
	Rotator CurrentRot { get; set; }

	// Token: 0x1700096A RID: 2410
	// (get) Token: 0x06007382 RID: 29570
	// (set) Token: 0x06007383 RID: 29571
	float CurrentFov { get; set; }

	// Token: 0x1700096B RID: 2411
	// (get) Token: 0x06007384 RID: 29572
	// (set) Token: 0x06007385 RID: 29573
	bool IsInterpolating { get; set; }

	// Token: 0x1700096C RID: 2412
	// (get) Token: 0x06007386 RID: 29574
	// (set) Token: 0x06007387 RID: 29575
	float InterpolationDuration { get; set; }

	// Token: 0x1700096D RID: 2413
	// (get) Token: 0x06007388 RID: 29576
	// (set) Token: 0x06007389 RID: 29577
	float ElapsedTime { get; set; }

	// Token: 0x1700096E RID: 2414
	// (get) Token: 0x0600738A RID: 29578
	// (set) Token: 0x0600738B RID: 29579
	[Nullable(2)]
	RhythmGameSpeedLevelConfig PrevConfig { [NullableContext(2)] get; [NullableContext(2)] set; }
}
