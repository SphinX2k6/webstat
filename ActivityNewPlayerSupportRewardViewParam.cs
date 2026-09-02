using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x02001473 RID: 5235
[NullableContext(1)]
[Nullable(0)]
public class ActivityNewPlayerSupportRewardViewParam : IActivityNewPlayerSupportRewardViewParam
{
	// Token: 0x17000C29 RID: 3113
	// (get) Token: 0x0600926C RID: 37484 RVA: 0x00269F9C File Offset: 0x0026819C
	// (set) Token: 0x0600926D RID: 37485 RVA: 0x00269FA4 File Offset: 0x002681A4
	public RewardData<ICommonRewardInfo> RewardData { get; set; }

	// Token: 0x17000C2A RID: 3114
	// (get) Token: 0x0600926E RID: 37486 RVA: 0x00269FAD File Offset: 0x002681AD
	// (set) Token: 0x0600926F RID: 37487 RVA: 0x00269FB5 File Offset: 0x002681B5
	public List<int> TrialRoleList { get; set; }
}
