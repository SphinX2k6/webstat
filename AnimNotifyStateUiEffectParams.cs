using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D84 RID: 3460
[NullableContext(2)]
[Nullable(0)]
internal class AnimNotifyStateUiEffectParams
{
	// Token: 0x06004C18 RID: 19480 RVA: 0x000A941B File Offset: 0x000A761B
	public AnimNotifyStateUiEffectParams(int? effectHandle, UiEffectAnsContext uiEffectAnsContext, bool hasSeekTo)
	{
		this.EffectHandle = effectHandle;
		this.UiEffectAnsContext = uiEffectAnsContext;
		this.HasSeekTo = hasSeekTo;
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x06004C19 RID: 19481 RVA: 0x000A9438 File Offset: 0x000A7638
	// (set) Token: 0x06004C1A RID: 19482 RVA: 0x000A9440 File Offset: 0x000A7640
	public int? EffectHandle { get; set; }

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x06004C1B RID: 19483 RVA: 0x000A9449 File Offset: 0x000A7649
	// (set) Token: 0x06004C1C RID: 19484 RVA: 0x000A9451 File Offset: 0x000A7651
	public UiEffectAnsContext UiEffectAnsContext { get; set; }

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x06004C1D RID: 19485 RVA: 0x000A945A File Offset: 0x000A765A
	// (set) Token: 0x06004C1E RID: 19486 RVA: 0x000A9462 File Offset: 0x000A7662
	public bool HasSeekTo { get; set; }
}
