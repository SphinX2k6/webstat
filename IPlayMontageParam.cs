using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002FF7 RID: 12279
[NullableContext(2)]
[Nullable(0)]
public class IPlayMontageParam : IActionParamMap
{
	// Token: 0x170021A1 RID: 8609
	// (get) Token: 0x0601903C RID: 102460 RVA: 0x00719737 File Offset: 0x00717937
	// (set) Token: 0x0601903D RID: 102461 RVA: 0x0071973F File Offset: 0x0071793F
	public string MontagePath { get; set; }

	// Token: 0x170021A2 RID: 8610
	// (get) Token: 0x0601903E RID: 102462 RVA: 0x00719748 File Offset: 0x00717948
	// (set) Token: 0x0601903F RID: 102463 RVA: 0x00719750 File Offset: 0x00717950
	public UAnimMontage MontageAsset { get; set; }

	// Token: 0x170021A3 RID: 8611
	// (get) Token: 0x06019040 RID: 102464 RVA: 0x00719759 File Offset: 0x00717959
	// (set) Token: 0x06019041 RID: 102465 RVA: 0x00719761 File Offset: 0x00717961
	public bool? IsLoop { get; set; }

	// Token: 0x170021A4 RID: 8612
	// (get) Token: 0x06019042 RID: 102466 RVA: 0x0071976A File Offset: 0x0071796A
	// (set) Token: 0x06019043 RID: 102467 RVA: 0x00719772 File Offset: 0x00717972
	public Action<int, EPerformGroup> OnStartCallback { get; set; }

	// Token: 0x170021A5 RID: 8613
	// (get) Token: 0x06019044 RID: 102468 RVA: 0x0071977B File Offset: 0x0071797B
	// (set) Token: 0x06019045 RID: 102469 RVA: 0x00719783 File Offset: 0x00717983
	public Action<UAnimMontage, bool> OnEndCallback { get; set; }

	// Token: 0x170021A6 RID: 8614
	// (get) Token: 0x06019046 RID: 102470 RVA: 0x0071978C File Offset: 0x0071798C
	// (set) Token: 0x06019047 RID: 102471 RVA: 0x00719794 File Offset: 0x00717994
	public Action<UAnimMontage> OnPlayCallback { get; set; }

	// Token: 0x170021A7 RID: 8615
	// (get) Token: 0x06019048 RID: 102472 RVA: 0x0071979D File Offset: 0x0071799D
	// (set) Token: 0x06019049 RID: 102473 RVA: 0x007197A5 File Offset: 0x007179A5
	public FName? InSectionToStartMontageAt { get; set; }

	// Token: 0x170021A8 RID: 8616
	// (get) Token: 0x0601904A RID: 102474 RVA: 0x007197AE File Offset: 0x007179AE
	// (set) Token: 0x0601904B RID: 102475 RVA: 0x007197B6 File Offset: 0x007179B6
	public float? Duration { get; set; }

	// Token: 0x170021A9 RID: 8617
	// (get) Token: 0x0601904C RID: 102476 RVA: 0x007197BF File Offset: 0x007179BF
	// (set) Token: 0x0601904D RID: 102477 RVA: 0x007197C7 File Offset: 0x007179C7
	public bool? KeepOtherMontage { get; set; }

	// Token: 0x170021AA RID: 8618
	// (get) Token: 0x0601904E RID: 102478 RVA: 0x007197D0 File Offset: 0x007179D0
	// (set) Token: 0x0601904F RID: 102479 RVA: 0x007197D8 File Offset: 0x007179D8
	public IAnimStateParam AnimStateParam { get; set; }

	// Token: 0x170021AB RID: 8619
	// (get) Token: 0x06019050 RID: 102480 RVA: 0x007197E1 File Offset: 0x007179E1
	// (set) Token: 0x06019051 RID: 102481 RVA: 0x007197E9 File Offset: 0x007179E9
	public bool? DisableBlinkCurve { get; set; }

	// Token: 0x170021AC RID: 8620
	// (get) Token: 0x06019052 RID: 102482 RVA: 0x007197F2 File Offset: 0x007179F2
	// (set) Token: 0x06019053 RID: 102483 RVA: 0x007197FA File Offset: 0x007179FA
	public Action<UAnimMontage, bool> OnBlendOutCallback { get; set; }

	// Token: 0x170021AD RID: 8621
	// (get) Token: 0x06019054 RID: 102484 RVA: 0x00719803 File Offset: 0x00717A03
	// (set) Token: 0x06019055 RID: 102485 RVA: 0x0071980B File Offset: 0x00717A0B
	public bool? EndActionOnBlendOut { get; set; }
}
