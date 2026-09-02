using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020012E7 RID: 4839
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyTaskTabData : IDangoMonopolyTaskTabData
{
	// Token: 0x17000AF7 RID: 2807
	// (get) Token: 0x06008307 RID: 33543 RVA: 0x0022AB22 File Offset: 0x00228D22
	// (set) Token: 0x06008308 RID: 33544 RVA: 0x0022AB2A File Offset: 0x00228D2A
	public EDangoMonopolyTaskType TaskType { get; set; }

	// Token: 0x17000AF8 RID: 2808
	// (get) Token: 0x06008309 RID: 33545 RVA: 0x0022AB33 File Offset: 0x00228D33
	// (set) Token: 0x0600830A RID: 33546 RVA: 0x0022AB3B File Offset: 0x00228D3B
	public string TaskTypeName { get; set; } = "";

	// Token: 0x17000AF9 RID: 2809
	// (get) Token: 0x0600830B RID: 33547 RVA: 0x0022AB44 File Offset: 0x00228D44
	// (set) Token: 0x0600830C RID: 33548 RVA: 0x0022AB4C File Offset: 0x00228D4C
	public IReadOnlyList<DangoMonopolyTaskData> TaskList { get; set; } = Array.Empty<DangoMonopolyTaskData>();

	// Token: 0x17000AFA RID: 2810
	// (get) Token: 0x0600830D RID: 33549 RVA: 0x0022AB55 File Offset: 0x00228D55
	// (set) Token: 0x0600830E RID: 33550 RVA: 0x0022AB5D File Offset: 0x00228D5D
	public long EndTime { get; set; }
}
