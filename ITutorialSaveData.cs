using System;

// Token: 0x02002C2A RID: 11306
public interface ITutorialSaveData
{
	// Token: 0x17001DC4 RID: 7620
	// (get) Token: 0x060169F0 RID: 92656
	// (set) Token: 0x060169F1 RID: 92657
	int TimeStamp { get; set; }

	// Token: 0x17001DC5 RID: 7621
	// (get) Token: 0x060169F2 RID: 92658
	// (set) Token: 0x060169F3 RID: 92659
	int TutorialId { get; set; }

	// Token: 0x17001DC6 RID: 7622
	// (get) Token: 0x060169F4 RID: 92660
	// (set) Token: 0x060169F5 RID: 92661
	bool HasRedDot { get; set; }

	// Token: 0x17001DC7 RID: 7623
	// (get) Token: 0x060169F6 RID: 92662
	// (set) Token: 0x060169F7 RID: 92663
	bool IsExcludedFromWiki { get; set; }
}
