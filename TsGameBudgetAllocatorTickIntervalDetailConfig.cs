using System;
using UnrealEngine;

// Token: 0x02000BBE RID: 3006
public class TsGameBudgetAllocatorTickIntervalDetailConfig
{
	// Token: 0x060030E6 RID: 12518 RVA: 0x0001B06A File Offset: 0x0001926A
	public TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode globalMode, EGameBudgetAllocatorActorMode actorMode, uint maxInterval, uint tickReductionStartSize, uint tickReductionIntervalSize, float tickReductionStartScreenRatio = 0f, float tickReductionIntervalScreenRatio = 0f)
	{
		this.GlobalMode = globalMode;
		this.ActorMode = actorMode;
		this.MaxInterval = maxInterval;
		this.TickReductionStartSize = tickReductionStartSize;
		this.TickReductionIntervalSize = tickReductionIntervalSize;
		this.TickReductionStartScreenRatio = tickReductionStartScreenRatio;
		this.TickReductionIntervalScreenRatio = tickReductionIntervalScreenRatio;
	}

	// Token: 0x04000423 RID: 1059
	public readonly EGameBudgetAllocatorGlobalMode GlobalMode;

	// Token: 0x04000424 RID: 1060
	public readonly EGameBudgetAllocatorActorMode ActorMode;

	// Token: 0x04000425 RID: 1061
	public readonly uint MaxInterval;

	// Token: 0x04000426 RID: 1062
	public readonly uint TickReductionStartSize;

	// Token: 0x04000427 RID: 1063
	public readonly uint TickReductionIntervalSize;

	// Token: 0x04000428 RID: 1064
	public readonly float TickReductionStartScreenRatio;

	// Token: 0x04000429 RID: 1065
	public readonly float TickReductionIntervalScreenRatio;
}
