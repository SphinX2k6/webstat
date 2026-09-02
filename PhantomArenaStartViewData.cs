using System;
using System.Runtime.CompilerServices;

// Token: 0x02002448 RID: 9288
[NullableContext(1)]
[Nullable(0)]
public class PhantomArenaStartViewData : IPhantomArenaStartViewData
{
	// Token: 0x17001699 RID: 5785
	// (get) Token: 0x06011F5D RID: 73565 RVA: 0x004F1533 File Offset: 0x004EF733
	// (set) Token: 0x06011F5E RID: 73566 RVA: 0x004F153B File Offset: 0x004EF73B
	public string ContentTextId { get; set; }

	// Token: 0x1700169A RID: 5786
	// (get) Token: 0x06011F5F RID: 73567 RVA: 0x004F1544 File Offset: 0x004EF744
	// (set) Token: 0x06011F60 RID: 73568 RVA: 0x004F154C File Offset: 0x004EF74C
	public bool IsOwn { get; set; }

	// Token: 0x1700169B RID: 5787
	// (get) Token: 0x06011F61 RID: 73569 RVA: 0x004F1555 File Offset: 0x004EF755
	// (set) Token: 0x06011F62 RID: 73570 RVA: 0x004F155D File Offset: 0x004EF75D
	[Nullable(2)]
	public Action Callback { [NullableContext(2)] get; [NullableContext(2)] set; }
}
