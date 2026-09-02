using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001957 RID: 6487
[NullableContext(2)]
[Nullable(0)]
public class SortStorageData : ISortStorageData
{
	// Token: 0x17000F1D RID: 3869
	// (get) Token: 0x0600BA07 RID: 47623 RVA: 0x00318BE8 File Offset: 0x00316DE8
	// (set) Token: 0x0600BA08 RID: 47624 RVA: 0x00318BF0 File Offset: 0x00316DF0
	public int ConfigId { get; set; }

	// Token: 0x17000F1E RID: 3870
	// (get) Token: 0x0600BA09 RID: 47625 RVA: 0x00318BF9 File Offset: 0x00316DF9
	// (set) Token: 0x0600BA0A RID: 47626 RVA: 0x00318C01 File Offset: 0x00316E01
	public int? SelectBaseSort { get; set; }

	// Token: 0x17000F1F RID: 3871
	// (get) Token: 0x0600BA0B RID: 47627 RVA: 0x00318C0A File Offset: 0x00316E0A
	// (set) Token: 0x0600BA0C RID: 47628 RVA: 0x00318C12 File Offset: 0x00316E12
	public List<int> SelectAttributeSort { get; set; }

	// Token: 0x17000F20 RID: 3872
	// (get) Token: 0x0600BA0D RID: 47629 RVA: 0x00318C1B File Offset: 0x00316E1B
	// (set) Token: 0x0600BA0E RID: 47630 RVA: 0x00318C23 File Offset: 0x00316E23
	public bool IsAscending { get; set; }
}
