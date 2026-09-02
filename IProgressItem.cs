using System;

// Token: 0x02001C54 RID: 7252
public interface IProgressItem
{
	// Token: 0x1700111E RID: 4382
	// (get) Token: 0x0600D39A RID: 54170
	// (set) Token: 0x0600D39B RID: 54171
	int DayIndex { get; set; }

	// Token: 0x1700111F RID: 4383
	// (get) Token: 0x0600D39C RID: 54172
	// (set) Token: 0x0600D39D RID: 54173
	bool IsPassed { get; set; }
}
