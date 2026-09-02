using System;
using System.Runtime.CompilerServices;

// Token: 0x02001916 RID: 6422
[NullableContext(2)]
[Nullable(0)]
public class MainPropertyFilterViewData : IMainPropertyFilterViewData
{
	// Token: 0x17000F14 RID: 3860
	// (get) Token: 0x0600B89B RID: 47259 RVA: 0x003112A8 File Offset: 0x0030F4A8
	// (set) Token: 0x0600B89C RID: 47260 RVA: 0x003112B0 File Offset: 0x0030F4B0
	public int UniqueId { get; set; }

	// Token: 0x17000F15 RID: 3861
	// (get) Token: 0x0600B89D RID: 47261 RVA: 0x003112B9 File Offset: 0x0030F4B9
	// (set) Token: 0x0600B89E RID: 47262 RVA: 0x003112C1 File Offset: 0x0030F4C1
	public int DefaultSelectCostTab { get; set; }

	// Token: 0x17000F16 RID: 3862
	// (get) Token: 0x0600B89F RID: 47263 RVA: 0x003112CA File Offset: 0x0030F4CA
	// (set) Token: 0x0600B8A0 RID: 47264 RVA: 0x003112D2 File Offset: 0x0030F4D2
	public Action ConfirmFunction { get; set; }

	// Token: 0x17000F17 RID: 3863
	// (get) Token: 0x0600B8A1 RID: 47265 RVA: 0x003112DB File Offset: 0x0030F4DB
	// (set) Token: 0x0600B8A2 RID: 47266 RVA: 0x003112E3 File Offset: 0x0030F4E3
	public int? CurrentFetterId { get; set; }
}
