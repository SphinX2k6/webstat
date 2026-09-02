using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;

// Token: 0x02002632 RID: 9778
[NullableContext(2)]
[Nullable(0)]
public class QteResource : IQteResource
{
	// Token: 0x170017E1 RID: 6113
	// (get) Token: 0x060133CC RID: 78796 RVA: 0x00558107 File Offset: 0x00556307
	// (set) Token: 0x060133CD RID: 78797 RVA: 0x0055810F File Offset: 0x0055630F
	public ULGUITexturePackerSpriteData Icon { get; set; }

	// Token: 0x170017E2 RID: 6114
	// (get) Token: 0x060133CE RID: 78798 RVA: 0x00558118 File Offset: 0x00556318
	// (set) Token: 0x060133CF RID: 78799 RVA: 0x00558120 File Offset: 0x00556320
	public EffectScreenPlayData_C ScreenEffect1 { get; set; }

	// Token: 0x170017E3 RID: 6115
	// (get) Token: 0x060133D0 RID: 78800 RVA: 0x00558129 File Offset: 0x00556329
	// (set) Token: 0x060133D1 RID: 78801 RVA: 0x00558131 File Offset: 0x00556331
	public EffectModelPostProcess ScreenEffect2 { get; set; }

	// Token: 0x170017E4 RID: 6116
	// (get) Token: 0x060133D2 RID: 78802 RVA: 0x0055813A File Offset: 0x0055633A
	// (set) Token: 0x060133D3 RID: 78803 RVA: 0x00558142 File Offset: 0x00556342
	public UClass CameraShake { get; set; }

	// Token: 0x170017E5 RID: 6117
	// (get) Token: 0x060133D4 RID: 78804 RVA: 0x0055814B File Offset: 0x0055634B
	// (set) Token: 0x060133D5 RID: 78805 RVA: 0x00558153 File Offset: 0x00556353
	public UKuroForceFeedbackEffect GamepadShake { get; set; }

	// Token: 0x170017E6 RID: 6118
	// (get) Token: 0x060133D6 RID: 78806 RVA: 0x0055815C File Offset: 0x0055635C
	// (set) Token: 0x060133D7 RID: 78807 RVA: 0x00558164 File Offset: 0x00556364
	public UCurveFloat ScaleCurve { get; set; }
}
