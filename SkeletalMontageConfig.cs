using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction;
using UnrealEngine;

// Token: 0x0200342D RID: 13357
[NullableContext(1)]
[Nullable(0)]
public class SkeletalMontageConfig
{
	// Token: 0x0601BEA2 RID: 114338 RVA: 0x00850B88 File Offset: 0x0084ED88
	public SkeletalMontageConfig(SSceneInteractionMontage ueConfig, int pendingFrameCount = 0, bool pendingCompHiddenInGame = false, EVisibilityBasedAnimTickOption pendingCompVisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.OnlyTickPoseWhenRendered)
	{
		this.UeConfig = ueConfig;
		this.PendingFrameCount = pendingFrameCount;
		this.PendingCompHiddenInGame = pendingCompHiddenInGame;
		this.PendingCompVisibilityBasedAnimTickOption = pendingCompVisibilityBasedAnimTickOption;
	}

	// Token: 0x0601BEA3 RID: 114339 RVA: 0x00850BAD File Offset: 0x0084EDAD
	public bool IsPendingApplyProps()
	{
		return this.PendingFrameCount > 0;
	}

	// Token: 0x0400E1C6 RID: 57798
	public SSceneInteractionMontage UeConfig;

	// Token: 0x0400E1C7 RID: 57799
	public int PendingFrameCount;

	// Token: 0x0400E1C8 RID: 57800
	public bool PendingCompHiddenInGame;

	// Token: 0x0400E1C9 RID: 57801
	public EVisibilityBasedAnimTickOption PendingCompVisibilityBasedAnimTickOption;
}
