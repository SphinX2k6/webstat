using System;
using System.Runtime.CompilerServices;

// Token: 0x020012EF RID: 4847
[NullableContext(1)]
[Nullable(0)]
public class DangoTipsInfo : IDangoTipsInfo
{
	// Token: 0x17000B15 RID: 2837
	// (get) Token: 0x0600833C RID: 33596 RVA: 0x0022AC94 File Offset: 0x00228E94
	// (set) Token: 0x0600833D RID: 33597 RVA: 0x0022AC9C File Offset: 0x00228E9C
	public string Text { get; set; } = "";

	// Token: 0x17000B16 RID: 2838
	// (get) Token: 0x0600833E RID: 33598 RVA: 0x0022ACA5 File Offset: 0x00228EA5
	// (set) Token: 0x0600833F RID: 33599 RVA: 0x0022ACAD File Offset: 0x00228EAD
	[Nullable(2)]
	public string Icon { [NullableContext(2)] get; [NullableContext(2)] set; } = "";
}
