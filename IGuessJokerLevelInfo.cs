using System;

// Token: 0x02001119 RID: 4377
public interface IGuessJokerLevelInfo
{
	// Token: 0x17000942 RID: 2370
	// (get) Token: 0x060071B9 RID: 29113
	// (set) Token: 0x060071BA RID: 29114
	int LevelId { get; set; }

	// Token: 0x17000943 RID: 2371
	// (get) Token: 0x060071BB RID: 29115
	// (set) Token: 0x060071BC RID: 29116
	bool Unlock { get; set; }

	// Token: 0x17000944 RID: 2372
	// (get) Token: 0x060071BD RID: 29117
	// (set) Token: 0x060071BE RID: 29118
	bool FirstPass { get; set; }

	// Token: 0x17000945 RID: 2373
	// (get) Token: 0x060071BF RID: 29119
	// (set) Token: 0x060071C0 RID: 29120
	bool RewardGet { get; set; }

	// Token: 0x17000946 RID: 2374
	// (get) Token: 0x060071C1 RID: 29121
	// (set) Token: 0x060071C2 RID: 29122
	bool PlayerWin { get; set; }
}
