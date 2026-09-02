using System;
using System.Runtime.CompilerServices;

// Token: 0x020012AF RID: 4783
[NullableContext(1)]
[Nullable(0)]
public class ActivityCorniceMeetingRewardItemData : IActivityCorniceMeetingRewardItemData
{
	// Token: 0x17000AE4 RID: 2788
	// (get) Token: 0x06008051 RID: 32849 RVA: 0x0021E6BF File Offset: 0x0021C8BF
	// (set) Token: 0x06008052 RID: 32850 RVA: 0x0021E6C7 File Offset: 0x0021C8C7
	public int RewardId { get; set; }

	// Token: 0x17000AE5 RID: 2789
	// (get) Token: 0x06008053 RID: 32851 RVA: 0x0021E6D0 File Offset: 0x0021C8D0
	// (set) Token: 0x06008054 RID: 32852 RVA: 0x0021E6D8 File Offset: 0x0021C8D8
	public Action OnClickFinishBtnCb { get; set; }
}
