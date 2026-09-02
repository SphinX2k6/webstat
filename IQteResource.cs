using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;

// Token: 0x02002631 RID: 9777
[NullableContext(2)]
public interface IQteResource
{
	// Token: 0x170017DB RID: 6107
	// (get) Token: 0x060133C0 RID: 78784
	// (set) Token: 0x060133C1 RID: 78785
	ULGUITexturePackerSpriteData Icon { get; set; }

	// Token: 0x170017DC RID: 6108
	// (get) Token: 0x060133C2 RID: 78786
	// (set) Token: 0x060133C3 RID: 78787
	EffectScreenPlayData_C ScreenEffect1 { get; set; }

	// Token: 0x170017DD RID: 6109
	// (get) Token: 0x060133C4 RID: 78788
	// (set) Token: 0x060133C5 RID: 78789
	EffectModelPostProcess ScreenEffect2 { get; set; }

	// Token: 0x170017DE RID: 6110
	// (get) Token: 0x060133C6 RID: 78790
	// (set) Token: 0x060133C7 RID: 78791
	UClass CameraShake { get; set; }

	// Token: 0x170017DF RID: 6111
	// (get) Token: 0x060133C8 RID: 78792
	// (set) Token: 0x060133C9 RID: 78793
	UKuroForceFeedbackEffect GamepadShake { get; set; }

	// Token: 0x170017E0 RID: 6112
	// (get) Token: 0x060133CA RID: 78794
	// (set) Token: 0x060133CB RID: 78795
	UCurveFloat ScaleCurve { get; set; }
}
