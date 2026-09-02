using System;
using System.Runtime.CompilerServices;

// Token: 0x02000F01 RID: 3841
[NullableContext(1)]
[Nullable(0)]
public class ShareInfo : IShareInfo
{
	// Token: 0x17000700 RID: 1792
	// (get) Token: 0x06005EE4 RID: 24292 RVA: 0x0017B88A File Offset: 0x00179A8A
	// (set) Token: 0x06005EE5 RID: 24293 RVA: 0x0017B892 File Offset: 0x00179A92
	public string ImageData { get; set; }

	// Token: 0x17000701 RID: 1793
	// (get) Token: 0x06005EE6 RID: 24294 RVA: 0x0017B89B File Offset: 0x00179A9B
	// (set) Token: 0x06005EE7 RID: 24295 RVA: 0x0017B8A3 File Offset: 0x00179AA3
	public ShareData ShareData { get; set; }
}
