using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002D5E RID: 11614
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRogueRewardPopViewData : IWeeklyRogueRewardPopViewData
{
	// Token: 0x17001EE5 RID: 7909
	// (get) Token: 0x06017726 RID: 96038 RVA: 0x0068016F File Offset: 0x0067E36F
	// (set) Token: 0x06017727 RID: 96039 RVA: 0x00680177 File Offset: 0x0067E377
	public int SinglePowerCost { get; set; }

	// Token: 0x17001EE6 RID: 7910
	// (get) Token: 0x06017728 RID: 96040 RVA: 0x00680180 File Offset: 0x0067E380
	// (set) Token: 0x06017729 RID: 96041 RVA: 0x00680188 File Offset: 0x0067E388
	public Action<int, int> RewardCallBack { get; set; }

	// Token: 0x17001EE7 RID: 7911
	// (get) Token: 0x0601772A RID: 96042 RVA: 0x00680191 File Offset: 0x0067E391
	// (set) Token: 0x0601772B RID: 96043 RVA: 0x00680199 File Offset: 0x0067E399
	[Nullable(2)]
	public Action CloseCallBack { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001EE8 RID: 7912
	// (get) Token: 0x0601772C RID: 96044 RVA: 0x006801A2 File Offset: 0x0067E3A2
	// (set) Token: 0x0601772D RID: 96045 RVA: 0x006801AA File Offset: 0x0067E3AA
	public List<int> AvailableSilentArea { get; set; }

	// Token: 0x17001EE9 RID: 7913
	// (get) Token: 0x0601772E RID: 96046 RVA: 0x006801B3 File Offset: 0x0067E3B3
	// (set) Token: 0x0601772F RID: 96047 RVA: 0x006801BB File Offset: 0x0067E3BB
	public int FreeCount { get; set; }

	// Token: 0x17001EEA RID: 7914
	// (get) Token: 0x06017730 RID: 96048 RVA: 0x006801C4 File Offset: 0x0067E3C4
	// (set) Token: 0x06017731 RID: 96049 RVA: 0x006801CC File Offset: 0x0067E3CC
	public int FreeMax { get; set; }
}
