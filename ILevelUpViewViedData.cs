using System;

// Token: 0x020020C6 RID: 8390
public interface ILevelUpViewViedData
{
	// Token: 0x1700133F RID: 4927
	// (get) Token: 0x06010073 RID: 65651
	// (set) Token: 0x06010074 RID: 65652
	bool AddExp { get; set; }

	// Token: 0x17001340 RID: 4928
	// (get) Token: 0x06010075 RID: 65653
	// (set) Token: 0x06010076 RID: 65654
	int PreLevel { get; set; }

	// Token: 0x17001341 RID: 4929
	// (get) Token: 0x06010077 RID: 65655
	// (set) Token: 0x06010078 RID: 65656
	int PreExp { get; set; }

	// Token: 0x17001342 RID: 4930
	// (get) Token: 0x06010079 RID: 65657
	// (set) Token: 0x0601007A RID: 65658
	int CurLevel { get; set; }

	// Token: 0x17001343 RID: 4931
	// (get) Token: 0x0601007B RID: 65659
	// (set) Token: 0x0601007C RID: 65660
	int CurExp { get; set; }
}
