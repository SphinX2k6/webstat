using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BBC RID: 3004
public class TsGameBudgetGroupConfig
{
	// Token: 0x060030E3 RID: 12515 RVA: 0x0001B001 File Offset: 0x00019201
	public TsGameBudgetGroupConfig(FName groupName, ESignificanceGroup significanceGroup)
	{
		this.GroupName = groupName;
		this.SignificanceGroup = significanceGroup;
	}

	// Token: 0x060030E4 RID: 12516 RVA: 0x0001B017 File Offset: 0x00019217
	[NullableContext(1)]
	public TsGameBudgetGroupConfig(TsGameBudgetGroupConfigCache ConfigCache)
	{
		this.GroupName = ConfigCache.GroupName;
		this.SignificanceGroup = ConfigCache.SignificanceGroup;
	}

	// Token: 0x0400041E RID: 1054
	public readonly FName GroupName;

	// Token: 0x0400041F RID: 1055
	public readonly ESignificanceGroup SignificanceGroup;
}
