using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BBD RID: 3005
[NullableContext(1)]
[Nullable(0)]
public class TsGameBudgetGroupConfigCache : TsGameBudgetGroupConfig
{
	// Token: 0x060030E5 RID: 12517 RVA: 0x0001B037 File Offset: 0x00019237
	public TsGameBudgetGroupConfigCache(FGameBudgetAllocatorGroupConfig ueGroupConfig) : base(ueGroupConfig.GroupName, ueGroupConfig.SignificanceGroup)
	{
		this.ueGroupConfig = ueGroupConfig;
		this.DefaultDisableActorTickDistance = ueGroupConfig.DisableActorTickDistance;
		this.DefaultDisableActorTickStrategy = ueGroupConfig.DisableActorTickStrategy;
	}

	// Token: 0x04000420 RID: 1056
	public uint DefaultDisableActorTickDistance;

	// Token: 0x04000421 RID: 1057
	public EDisableActorTickStrategy DefaultDisableActorTickStrategy;

	// Token: 0x04000422 RID: 1058
	public readonly FGameBudgetAllocatorGroupConfig ueGroupConfig;
}
