using System;

// Token: 0x02001CFB RID: 7419
public interface IGachaViewOpenData
{
	// Token: 0x17001157 RID: 4439
	// (get) Token: 0x0600D9E7 RID: 55783
	// (set) Token: 0x0600D9E8 RID: 55784
	bool SkipOnLoadResourceFinish { get; set; }

	// Token: 0x17001158 RID: 4440
	// (get) Token: 0x0600D9E9 RID: 55785
	// (set) Token: 0x0600D9EA RID: 55786
	bool ResultViewHideExtraReward { get; set; }

	// Token: 0x17001159 RID: 4441
	// (get) Token: 0x0600D9EB RID: 55787
	// (set) Token: 0x0600D9EC RID: 55788
	bool IsOnlyShowGold { get; set; }
}
