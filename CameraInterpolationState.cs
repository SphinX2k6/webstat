using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.RhythmGame;

// Token: 0x0200113A RID: 4410
[NullableContext(1)]
[Nullable(0)]
internal class CameraInterpolationState : ICameraInterpolationState
{
	// Token: 0x1700096F RID: 2415
	// (get) Token: 0x0600738C RID: 29580 RVA: 0x001E2F5B File Offset: 0x001E115B
	// (set) Token: 0x0600738D RID: 29581 RVA: 0x001E2F63 File Offset: 0x001E1163
	public Vector StartPos { get; set; } = Vector.Create();

	// Token: 0x17000970 RID: 2416
	// (get) Token: 0x0600738E RID: 29582 RVA: 0x001E2F6C File Offset: 0x001E116C
	// (set) Token: 0x0600738F RID: 29583 RVA: 0x001E2F74 File Offset: 0x001E1174
	public Rotator StartRot { get; set; } = Rotator.Create();

	// Token: 0x17000971 RID: 2417
	// (get) Token: 0x06007390 RID: 29584 RVA: 0x001E2F7D File Offset: 0x001E117D
	// (set) Token: 0x06007391 RID: 29585 RVA: 0x001E2F85 File Offset: 0x001E1185
	public float StartFov { get; set; }

	// Token: 0x17000972 RID: 2418
	// (get) Token: 0x06007392 RID: 29586 RVA: 0x001E2F8E File Offset: 0x001E118E
	// (set) Token: 0x06007393 RID: 29587 RVA: 0x001E2F96 File Offset: 0x001E1196
	public Vector TargetPos { get; set; } = Vector.Create();

	// Token: 0x17000973 RID: 2419
	// (get) Token: 0x06007394 RID: 29588 RVA: 0x001E2F9F File Offset: 0x001E119F
	// (set) Token: 0x06007395 RID: 29589 RVA: 0x001E2FA7 File Offset: 0x001E11A7
	public Rotator TargetRot { get; set; } = Rotator.Create();

	// Token: 0x17000974 RID: 2420
	// (get) Token: 0x06007396 RID: 29590 RVA: 0x001E2FB0 File Offset: 0x001E11B0
	// (set) Token: 0x06007397 RID: 29591 RVA: 0x001E2FB8 File Offset: 0x001E11B8
	public float TargetFov { get; set; }

	// Token: 0x17000975 RID: 2421
	// (get) Token: 0x06007398 RID: 29592 RVA: 0x001E2FC1 File Offset: 0x001E11C1
	// (set) Token: 0x06007399 RID: 29593 RVA: 0x001E2FC9 File Offset: 0x001E11C9
	public Vector CurrentPos { get; set; } = Vector.Create();

	// Token: 0x17000976 RID: 2422
	// (get) Token: 0x0600739A RID: 29594 RVA: 0x001E2FD2 File Offset: 0x001E11D2
	// (set) Token: 0x0600739B RID: 29595 RVA: 0x001E2FDA File Offset: 0x001E11DA
	public Rotator CurrentRot { get; set; } = Rotator.Create();

	// Token: 0x17000977 RID: 2423
	// (get) Token: 0x0600739C RID: 29596 RVA: 0x001E2FE3 File Offset: 0x001E11E3
	// (set) Token: 0x0600739D RID: 29597 RVA: 0x001E2FEB File Offset: 0x001E11EB
	public float CurrentFov { get; set; }

	// Token: 0x17000978 RID: 2424
	// (get) Token: 0x0600739E RID: 29598 RVA: 0x001E2FF4 File Offset: 0x001E11F4
	// (set) Token: 0x0600739F RID: 29599 RVA: 0x001E2FFC File Offset: 0x001E11FC
	public bool IsInterpolating { get; set; }

	// Token: 0x17000979 RID: 2425
	// (get) Token: 0x060073A0 RID: 29600 RVA: 0x001E3005 File Offset: 0x001E1205
	// (set) Token: 0x060073A1 RID: 29601 RVA: 0x001E300D File Offset: 0x001E120D
	public float InterpolationDuration { get; set; }

	// Token: 0x1700097A RID: 2426
	// (get) Token: 0x060073A2 RID: 29602 RVA: 0x001E3016 File Offset: 0x001E1216
	// (set) Token: 0x060073A3 RID: 29603 RVA: 0x001E301E File Offset: 0x001E121E
	public float ElapsedTime { get; set; }

	// Token: 0x1700097B RID: 2427
	// (get) Token: 0x060073A4 RID: 29604 RVA: 0x001E3027 File Offset: 0x001E1227
	// (set) Token: 0x060073A5 RID: 29605 RVA: 0x001E302F File Offset: 0x001E122F
	[Nullable(2)]
	public RhythmGameSpeedLevelConfig PrevConfig { [NullableContext(2)] get; [NullableContext(2)] set; }
}
