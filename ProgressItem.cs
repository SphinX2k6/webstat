using System;

// Token: 0x02001C55 RID: 7253
public class ProgressItem : IProgressItem
{
	// Token: 0x17001120 RID: 4384
	// (get) Token: 0x0600D39E RID: 54174 RVA: 0x00386935 File Offset: 0x00384B35
	// (set) Token: 0x0600D39F RID: 54175 RVA: 0x0038693D File Offset: 0x00384B3D
	public int DayIndex { get; set; }

	// Token: 0x17001121 RID: 4385
	// (get) Token: 0x0600D3A0 RID: 54176 RVA: 0x00386946 File Offset: 0x00384B46
	// (set) Token: 0x0600D3A1 RID: 54177 RVA: 0x0038694E File Offset: 0x00384B4E
	public bool IsPassed { get; set; }
}
