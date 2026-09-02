using System;
using System.Runtime.CompilerServices;

// Token: 0x020025E4 RID: 9700
[NullableContext(1)]
[Nullable(0)]
public class PhotoInfoData : IInfoData
{
	// Token: 0x170017C6 RID: 6086
	// (get) Token: 0x06012FE3 RID: 77795 RVA: 0x00542252 File Offset: 0x00540452
	// (set) Token: 0x06012FE4 RID: 77796 RVA: 0x0054225A File Offset: 0x0054045A
	public string Text { get; set; } = "";

	// Token: 0x170017C7 RID: 6087
	// (get) Token: 0x06012FE5 RID: 77797 RVA: 0x00542263 File Offset: 0x00540463
	// (set) Token: 0x06012FE6 RID: 77798 RVA: 0x0054226B File Offset: 0x0054046B
	public bool IsFinish { get; set; }

	// Token: 0x170017C8 RID: 6088
	// (get) Token: 0x06012FE7 RID: 77799 RVA: 0x00542274 File Offset: 0x00540474
	// (set) Token: 0x06012FE8 RID: 77800 RVA: 0x0054227C File Offset: 0x0054047C
	public bool IsOptionFinished { get; set; }
}
