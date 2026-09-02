using System;
using System.Runtime.CompilerServices;

// Token: 0x02002862 RID: 10338
[NullableContext(1)]
[Nullable(0)]
public class RoleLangCustomInfo : IRoleLangCustomInfo
{
	// Token: 0x17001ABB RID: 6843
	// (get) Token: 0x060147D3 RID: 83923 RVA: 0x005AF7A2 File Offset: 0x005AD9A2
	// (set) Token: 0x060147D4 RID: 83924 RVA: 0x005AF7AA File Offset: 0x005AD9AA
	public int RoleId { get; set; }

	// Token: 0x17001ABC RID: 6844
	// (get) Token: 0x060147D5 RID: 83925 RVA: 0x005AF7B3 File Offset: 0x005AD9B3
	// (set) Token: 0x060147D6 RID: 83926 RVA: 0x005AF7BB File Offset: 0x005AD9BB
	public int LangIndex { get; set; }

	// Token: 0x17001ABD RID: 6845
	// (get) Token: 0x060147D7 RID: 83927 RVA: 0x005AF7C4 File Offset: 0x005AD9C4
	// (set) Token: 0x060147D8 RID: 83928 RVA: 0x005AF7CC File Offset: 0x005AD9CC
	public string LangCode { get; set; }
}
