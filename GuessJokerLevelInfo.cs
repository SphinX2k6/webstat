using System;

// Token: 0x0200111A RID: 4378
public class GuessJokerLevelInfo : IGuessJokerLevelInfo
{
	// Token: 0x17000947 RID: 2375
	// (get) Token: 0x060071C3 RID: 29123 RVA: 0x001DAE13 File Offset: 0x001D9013
	// (set) Token: 0x060071C4 RID: 29124 RVA: 0x001DAE1B File Offset: 0x001D901B
	public int LevelId { get; set; }

	// Token: 0x17000948 RID: 2376
	// (get) Token: 0x060071C5 RID: 29125 RVA: 0x001DAE24 File Offset: 0x001D9024
	// (set) Token: 0x060071C6 RID: 29126 RVA: 0x001DAE2C File Offset: 0x001D902C
	public bool Unlock { get; set; }

	// Token: 0x17000949 RID: 2377
	// (get) Token: 0x060071C7 RID: 29127 RVA: 0x001DAE35 File Offset: 0x001D9035
	// (set) Token: 0x060071C8 RID: 29128 RVA: 0x001DAE3D File Offset: 0x001D903D
	public bool FirstPass { get; set; }

	// Token: 0x1700094A RID: 2378
	// (get) Token: 0x060071C9 RID: 29129 RVA: 0x001DAE46 File Offset: 0x001D9046
	// (set) Token: 0x060071CA RID: 29130 RVA: 0x001DAE4E File Offset: 0x001D904E
	public bool RewardGet { get; set; }

	// Token: 0x1700094B RID: 2379
	// (get) Token: 0x060071CB RID: 29131 RVA: 0x001DAE57 File Offset: 0x001D9057
	// (set) Token: 0x060071CC RID: 29132 RVA: 0x001DAE5F File Offset: 0x001D905F
	public bool PlayerWin { get; set; }
}
