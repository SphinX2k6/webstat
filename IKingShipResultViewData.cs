using System;

// Token: 0x020020A7 RID: 8359
public interface IKingShipResultViewData
{
	// Token: 0x17001305 RID: 4869
	// (get) Token: 0x0600FF41 RID: 65345
	// (set) Token: 0x0600FF42 RID: 65346
	int CardId { get; set; }

	// Token: 0x17001306 RID: 4870
	// (get) Token: 0x0600FF43 RID: 65347
	// (set) Token: 0x0600FF44 RID: 65348
	int ReignsId { get; set; }

	// Token: 0x17001307 RID: 4871
	// (get) Token: 0x0600FF45 RID: 65349
	// (set) Token: 0x0600FF46 RID: 65350
	bool IsSuccess { get; set; }

	// Token: 0x17001308 RID: 4872
	// (get) Token: 0x0600FF47 RID: 65351
	// (set) Token: 0x0600FF48 RID: 65352
	int NextReignsId { get; set; }
}
