using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002475 RID: 9333
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerEditPopInfo : IPhantomManagerEditPopInfo
{
	// Token: 0x170016C9 RID: 5833
	// (get) Token: 0x06012136 RID: 74038 RVA: 0x004F7EE4 File Offset: 0x004F60E4
	// (set) Token: 0x06012137 RID: 74039 RVA: 0x004F7EEC File Offset: 0x004F60EC
	public int FetterId { get; set; }

	// Token: 0x170016CA RID: 5834
	// (get) Token: 0x06012138 RID: 74040 RVA: 0x004F7EF5 File Offset: 0x004F60F5
	// (set) Token: 0x06012139 RID: 74041 RVA: 0x004F7EFD File Offset: 0x004F60FD
	public int Count { get; set; }

	// Token: 0x170016CB RID: 5835
	// (get) Token: 0x0601213A RID: 74042 RVA: 0x004F7F06 File Offset: 0x004F6106
	// (set) Token: 0x0601213B RID: 74043 RVA: 0x004F7F0E File Offset: 0x004F610E
	public List<IPhantomManagerConfigNewSettingInfo> DataList { get; set; } = new List<IPhantomManagerConfigNewSettingInfo>();

	// Token: 0x170016CC RID: 5836
	// (get) Token: 0x0601213C RID: 74044 RVA: 0x004F7F17 File Offset: 0x004F6117
	// (set) Token: 0x0601213D RID: 74045 RVA: 0x004F7F1F File Offset: 0x004F611F
	[Nullable(2)]
	public Action CloseCb { [NullableContext(2)] get; [NullableContext(2)] set; }
}
