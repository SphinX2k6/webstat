using System;
using System.Runtime.CompilerServices;

// Token: 0x0200113E RID: 4414
[NullableContext(2)]
[Nullable(0)]
internal class FreeCameraState : IFreeCameraState
{
	// Token: 0x1700099F RID: 2463
	// (get) Token: 0x060073EE RID: 29678 RVA: 0x001E318D File Offset: 0x001E138D
	// (set) Token: 0x060073EF RID: 29679 RVA: 0x001E3195 File Offset: 0x001E1395
	[Nullable(1)]
	public IFreeCameraConfig Config { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170009A0 RID: 2464
	// (get) Token: 0x060073F0 RID: 29680 RVA: 0x001E319E File Offset: 0x001E139E
	// (set) Token: 0x060073F1 RID: 29681 RVA: 0x001E31A6 File Offset: 0x001E13A6
	public float Timer { get; set; }

	// Token: 0x170009A1 RID: 2465
	// (get) Token: 0x060073F2 RID: 29682 RVA: 0x001E31AF File Offset: 0x001E13AF
	// (set) Token: 0x060073F3 RID: 29683 RVA: 0x001E31B7 File Offset: 0x001E13B7
	public int LastDirection { get; set; }

	// Token: 0x170009A2 RID: 2466
	// (get) Token: 0x060073F4 RID: 29684 RVA: 0x001E31C0 File Offset: 0x001E13C0
	// (set) Token: 0x060073F5 RID: 29685 RVA: 0x001E31C8 File Offset: 0x001E13C8
	public bool IsInterpolating { get; set; }

	// Token: 0x170009A3 RID: 2467
	// (get) Token: 0x060073F6 RID: 29686 RVA: 0x001E31D1 File Offset: 0x001E13D1
	// (set) Token: 0x060073F7 RID: 29687 RVA: 0x001E31D9 File Offset: 0x001E13D9
	public float InterpolationElapsedTime { get; set; }

	// Token: 0x170009A4 RID: 2468
	// (get) Token: 0x060073F8 RID: 29688 RVA: 0x001E31E2 File Offset: 0x001E13E2
	// (set) Token: 0x060073F9 RID: 29689 RVA: 0x001E31EA File Offset: 0x001E13EA
	public int StartDirection { get; set; }

	// Token: 0x170009A5 RID: 2469
	// (get) Token: 0x060073FA RID: 29690 RVA: 0x001E31F3 File Offset: 0x001E13F3
	// (set) Token: 0x060073FB RID: 29691 RVA: 0x001E31FB File Offset: 0x001E13FB
	public int TargetDirection { get; set; }

	// Token: 0x170009A6 RID: 2470
	// (get) Token: 0x060073FC RID: 29692 RVA: 0x001E3204 File Offset: 0x001E1404
	// (set) Token: 0x060073FD RID: 29693 RVA: 0x001E320C File Offset: 0x001E140C
	public bool? IsExiting { get; set; }

	// Token: 0x170009A7 RID: 2471
	// (get) Token: 0x060073FE RID: 29694 RVA: 0x001E3215 File Offset: 0x001E1415
	// (set) Token: 0x060073FF RID: 29695 RVA: 0x001E321D File Offset: 0x001E141D
	public Vector ExitRelativePos { get; set; }

	// Token: 0x170009A8 RID: 2472
	// (get) Token: 0x06007400 RID: 29696 RVA: 0x001E3226 File Offset: 0x001E1426
	// (set) Token: 0x06007401 RID: 29697 RVA: 0x001E322E File Offset: 0x001E142E
	public Rotator ExitRelativeRot { get; set; }

	// Token: 0x170009A9 RID: 2473
	// (get) Token: 0x06007402 RID: 29698 RVA: 0x001E3237 File Offset: 0x001E1437
	// (set) Token: 0x06007403 RID: 29699 RVA: 0x001E323F File Offset: 0x001E143F
	public int? ExitFollowConfigIndex { get; set; }
}
