using System;
using System.Runtime.CompilerServices;

// Token: 0x02003401 RID: 13313
[NullableContext(2)]
[Nullable(0)]
internal class AnimNotifyStateEffectParams
{
	// Token: 0x0601BC60 RID: 113760 RVA: 0x00848EC0 File Offset: 0x008470C0
	public AnimNotifyStateEffectParams(int? effectHandle, UiEffectAnsContext uiEffectAnsContext, bool hasSeekTo, bool continuousSeek, bool isInUi)
	{
		this.EffectHandle = effectHandle;
		this.UiEffectAnsContext = uiEffectAnsContext;
		this.HasSeekTo = hasSeekTo;
		this.ContinuousSeek = continuousSeek;
		this.IsInUi = isInUi;
	}

	// Token: 0x0400E044 RID: 57412
	public int? EffectHandle;

	// Token: 0x0400E045 RID: 57413
	public UiEffectAnsContext UiEffectAnsContext;

	// Token: 0x0400E046 RID: 57414
	public bool HasSeekTo;

	// Token: 0x0400E047 RID: 57415
	public bool ContinuousSeek;

	// Token: 0x0400E048 RID: 57416
	public bool IsInUi;
}
