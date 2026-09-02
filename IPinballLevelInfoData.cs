using System;
using System.Runtime.CompilerServices;

// Token: 0x020014A4 RID: 5284
[NullableContext(2)]
public interface IPinballLevelInfoData
{
	// Token: 0x17000C33 RID: 3123
	// (get) Token: 0x060093E9 RID: 37865
	// (set) Token: 0x060093EA RID: 37866
	int LevelId { get; set; }

	// Token: 0x17000C34 RID: 3124
	// (get) Token: 0x060093EB RID: 37867
	// (set) Token: 0x060093EC RID: 37868
	int RealLevelId { get; set; }

	// Token: 0x17000C35 RID: 3125
	// (get) Token: 0x060093ED RID: 37869
	// (set) Token: 0x060093EE RID: 37870
	int[] LevelStarConditionIds { get; set; }

	// Token: 0x17000C36 RID: 3126
	// (get) Token: 0x060093EF RID: 37871
	// (set) Token: 0x060093F0 RID: 37872
	int? LevelScore { get; set; }

	// Token: 0x17000C37 RID: 3127
	// (get) Token: 0x060093F1 RID: 37873
	// (set) Token: 0x060093F2 RID: 37874
	bool? LevelLock { get; set; }

	// Token: 0x17000C38 RID: 3128
	// (get) Token: 0x060093F3 RID: 37875
	// (set) Token: 0x060093F4 RID: 37876
	string LevelLockTexts { get; set; }

	// Token: 0x17000C39 RID: 3129
	// (get) Token: 0x060093F5 RID: 37877
	// (set) Token: 0x060093F6 RID: 37878
	bool? ShowDesc { get; set; }

	// Token: 0x17000C3A RID: 3130
	// (get) Token: 0x060093F7 RID: 37879
	// (set) Token: 0x060093F8 RID: 37880
	bool? ShowStar { get; set; }

	// Token: 0x17000C3B RID: 3131
	// (get) Token: 0x060093F9 RID: 37881
	// (set) Token: 0x060093FA RID: 37882
	bool? ShowScore { get; set; }

	// Token: 0x17000C3C RID: 3132
	// (get) Token: 0x060093FB RID: 37883
	// (set) Token: 0x060093FC RID: 37884
	bool? ShowReward { get; set; }

	// Token: 0x17000C3D RID: 3133
	// (get) Token: 0x060093FD RID: 37885
	// (set) Token: 0x060093FE RID: 37886
	int? RewardDropId { get; set; }

	// Token: 0x17000C3E RID: 3134
	// (get) Token: 0x060093FF RID: 37887
	// (set) Token: 0x06009400 RID: 37888
	bool? RewardReceived { get; set; }

	// Token: 0x17000C3F RID: 3135
	// (get) Token: 0x06009401 RID: 37889
	// (set) Token: 0x06009402 RID: 37890
	string RewardClearTitle { get; set; }
}
