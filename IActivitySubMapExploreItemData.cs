using System;
using System.Runtime.CompilerServices;

// Token: 0x02001379 RID: 4985
[NullableContext(1)]
public interface IActivitySubMapExploreItemData
{
	// Token: 0x17000B84 RID: 2948
	// (get) Token: 0x060088A0 RID: 34976
	// (set) Token: 0x060088A1 RID: 34977
	int TaskId { get; set; }

	// Token: 0x17000B85 RID: 2949
	// (get) Token: 0x060088A2 RID: 34978
	// (set) Token: 0x060088A3 RID: 34979
	string RewardDesc { get; set; }

	// Token: 0x17000B86 RID: 2950
	// (get) Token: 0x060088A4 RID: 34980
	// (set) Token: 0x060088A5 RID: 34981
	int RewardItemId { get; set; }

	// Token: 0x17000B87 RID: 2951
	// (get) Token: 0x060088A6 RID: 34982
	// (set) Token: 0x060088A7 RID: 34983
	int? RewardItemCount { get; set; }

	// Token: 0x17000B88 RID: 2952
	// (get) Token: 0x060088A8 RID: 34984
	// (set) Token: 0x060088A9 RID: 34985
	bool IsComplete { get; set; }

	// Token: 0x17000B89 RID: 2953
	// (get) Token: 0x060088AA RID: 34986
	// (set) Token: 0x060088AB RID: 34987
	bool IsCanGet { get; set; }

	// Token: 0x17000B8A RID: 2954
	// (get) Token: 0x060088AC RID: 34988
	// (set) Token: 0x060088AD RID: 34989
	bool IsRunning { get; set; }
}
