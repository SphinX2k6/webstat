using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;

// Token: 0x0200342E RID: 13358
[NullableContext(1)]
[Nullable(0)]
public class EffectInfo
{
	// Token: 0x0601BEA4 RID: 114340 RVA: 0x00850BB8 File Offset: 0x0084EDB8
	public EffectInfo(BP_EffectActor_C effect, bool isInheritTimeDilation)
	{
		this.Effect = effect;
		this.IsInheritTimeDilation = isInheritTimeDilation;
	}

	// Token: 0x0400E1CA RID: 57802
	public BP_EffectActor_C Effect;

	// Token: 0x0400E1CB RID: 57803
	public int EffectId;

	// Token: 0x0400E1CC RID: 57804
	public bool IsPlaying;

	// Token: 0x0400E1CD RID: 57805
	public bool IsInheritTimeDilation;
}
