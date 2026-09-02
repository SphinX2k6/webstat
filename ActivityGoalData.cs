using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A9A RID: 6810
[NullableContext(1)]
[Nullable(0)]
public class ActivityGoalData : DailyActivityDefine.IActivityGoalData
{
	// Token: 0x17000FF4 RID: 4084
	// (get) Token: 0x0600C31C RID: 49948 RVA: 0x00336B0E File Offset: 0x00334D0E
	// (set) Token: 0x0600C31D RID: 49949 RVA: 0x00336B16 File Offset: 0x00334D16
	public int Id { get; set; }

	// Token: 0x17000FF5 RID: 4085
	// (get) Token: 0x0600C31E RID: 49950 RVA: 0x00336B1F File Offset: 0x00334D1F
	// (set) Token: 0x0600C31F RID: 49951 RVA: 0x00336B27 File Offset: 0x00334D27
	public int Goal { get; set; }

	// Token: 0x17000FF6 RID: 4086
	// (get) Token: 0x0600C320 RID: 49952 RVA: 0x00336B30 File Offset: 0x00334D30
	// (set) Token: 0x0600C321 RID: 49953 RVA: 0x00336B38 File Offset: 0x00334D38
	public List<TItem> Rewards { get; set; } = new List<TItem>();

	// Token: 0x17000FF7 RID: 4087
	// (get) Token: 0x0600C322 RID: 49954 RVA: 0x00336B41 File Offset: 0x00334D41
	// (set) Token: 0x0600C323 RID: 49955 RVA: 0x00336B49 File Offset: 0x00334D49
	public bool Achieved { get; set; }

	// Token: 0x17000FF8 RID: 4088
	// (get) Token: 0x0600C324 RID: 49956 RVA: 0x00336B52 File Offset: 0x00334D52
	// (set) Token: 0x0600C325 RID: 49957 RVA: 0x00336B5A File Offset: 0x00334D5A
	public EDailyActiveState State { get; set; }
}
