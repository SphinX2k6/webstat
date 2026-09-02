using System;

// Token: 0x02002E96 RID: 11926
public interface IBoundsLocker
{
	// Token: 0x17002109 RID: 8457
	// (get) Token: 0x060187B0 RID: 100272
	// (set) Token: 0x060187B1 RID: 100273
	bool LockUpperBounds { get; set; }

	// Token: 0x1700210A RID: 8458
	// (get) Token: 0x060187B2 RID: 100274
	// (set) Token: 0x060187B3 RID: 100275
	bool LockLowerBounds { get; set; }

	// Token: 0x1700210B RID: 8459
	// (get) Token: 0x060187B4 RID: 100276
	// (set) Token: 0x060187B5 RID: 100277
	float UpperPercent { get; set; }

	// Token: 0x1700210C RID: 8460
	// (get) Token: 0x060187B6 RID: 100278
	// (set) Token: 0x060187B7 RID: 100279
	float UpperOffset { get; set; }

	// Token: 0x1700210D RID: 8461
	// (get) Token: 0x060187B8 RID: 100280
	// (set) Token: 0x060187B9 RID: 100281
	float LowerPercent { get; set; }

	// Token: 0x1700210E RID: 8462
	// (get) Token: 0x060187BA RID: 100282
	// (set) Token: 0x060187BB RID: 100283
	float LowerOffset { get; set; }
}
