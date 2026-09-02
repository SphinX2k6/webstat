using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction;
using UnrealEngine;

// Token: 0x0200342C RID: 13356
[NullableContext(1)]
[Nullable(0)]
public class SequenceDirectorConfig
{
	// Token: 0x0601BE9D RID: 114333 RVA: 0x00850B0C File Offset: 0x0084ED0C
	public SequenceDirectorConfig(SSceneInteractionSequence ueConfig, bool isLoopOverride = false, float playRateOverride = 0f, bool reverseOverride = false)
	{
		this.UeConfig = ueConfig;
		this.IsLoopOverride = ((!isLoopOverride) ? ueConfig.IsLoop : isLoopOverride);
		this.PlayRateOverride = ((playRateOverride == 0f) ? ueConfig.PlayRate : playRateOverride);
		this.ReverseOverride = ((!reverseOverride) ? ueConfig.Reverse : reverseOverride);
	}

	// Token: 0x17002607 RID: 9735
	// (get) Token: 0x0601BE9E RID: 114334 RVA: 0x00850B63 File Offset: 0x0084ED63
	public bool IsLoop
	{
		get
		{
			return this.IsLoopOverride;
		}
	}

	// Token: 0x17002608 RID: 9736
	// (get) Token: 0x0601BE9F RID: 114335 RVA: 0x00850B6B File Offset: 0x0084ED6B
	public float PlayRate
	{
		get
		{
			return this.PlayRateOverride;
		}
	}

	// Token: 0x17002609 RID: 9737
	// (get) Token: 0x0601BEA0 RID: 114336 RVA: 0x00850B73 File Offset: 0x0084ED73
	public bool Reverse
	{
		get
		{
			return this.ReverseOverride;
		}
	}

	// Token: 0x1700260A RID: 9738
	// (get) Token: 0x0601BEA1 RID: 114337 RVA: 0x00850B7B File Offset: 0x0084ED7B
	[Nullable(2)]
	public ULevelSequence Sequence
	{
		[NullableContext(2)]
		get
		{
			return this.UeConfig.Sequence;
		}
	}

	// Token: 0x0400E1C2 RID: 57794
	public SSceneInteractionSequence UeConfig;

	// Token: 0x0400E1C3 RID: 57795
	public bool IsLoopOverride;

	// Token: 0x0400E1C4 RID: 57796
	public float PlayRateOverride;

	// Token: 0x0400E1C5 RID: 57797
	public bool ReverseOverride;
}
