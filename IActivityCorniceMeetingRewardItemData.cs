using System;
using System.Runtime.CompilerServices;

// Token: 0x020012AE RID: 4782
[NullableContext(1)]
public interface IActivityCorniceMeetingRewardItemData
{
	// Token: 0x17000AE2 RID: 2786
	// (get) Token: 0x0600804D RID: 32845
	// (set) Token: 0x0600804E RID: 32846
	int RewardId { get; set; }

	// Token: 0x17000AE3 RID: 2787
	// (get) Token: 0x0600804F RID: 32847
	// (set) Token: 0x06008050 RID: 32848
	Action OnClickFinishBtnCb { get; set; }
}
