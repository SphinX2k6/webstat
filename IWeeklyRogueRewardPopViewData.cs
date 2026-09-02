using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002D5D RID: 11613
[NullableContext(1)]
public interface IWeeklyRogueRewardPopViewData
{
	// Token: 0x17001EDF RID: 7903
	// (get) Token: 0x0601771A RID: 96026
	// (set) Token: 0x0601771B RID: 96027
	int SinglePowerCost { get; set; }

	// Token: 0x17001EE0 RID: 7904
	// (get) Token: 0x0601771C RID: 96028
	// (set) Token: 0x0601771D RID: 96029
	Action<int, int> RewardCallBack { get; set; }

	// Token: 0x17001EE1 RID: 7905
	// (get) Token: 0x0601771E RID: 96030
	// (set) Token: 0x0601771F RID: 96031
	[Nullable(2)]
	Action CloseCallBack { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001EE2 RID: 7906
	// (get) Token: 0x06017720 RID: 96032
	// (set) Token: 0x06017721 RID: 96033
	List<int> AvailableSilentArea { get; set; }

	// Token: 0x17001EE3 RID: 7907
	// (get) Token: 0x06017722 RID: 96034
	// (set) Token: 0x06017723 RID: 96035
	int FreeCount { get; set; }

	// Token: 0x17001EE4 RID: 7908
	// (get) Token: 0x06017724 RID: 96036
	// (set) Token: 0x06017725 RID: 96037
	int FreeMax { get; set; }
}
