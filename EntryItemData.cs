using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B16 RID: 11030
[NullableContext(1)]
[Nullable(0)]
public class EntryItemData : IEntryItemData
{
	// Token: 0x17001CB9 RID: 7353
	// (get) Token: 0x06016089 RID: 90249 RVA: 0x0061D0E6 File Offset: 0x0061B2E6
	// (set) Token: 0x0601608A RID: 90250 RVA: 0x0061D0EE File Offset: 0x0061B2EE
	public string Text { get; set; } = "";

	// Token: 0x17001CBA RID: 7354
	// (get) Token: 0x0601608B RID: 90251 RVA: 0x0061D0F7 File Offset: 0x0061B2F7
	// (set) Token: 0x0601608C RID: 90252 RVA: 0x0061D0FF File Offset: 0x0061B2FF
	public string[] Args { get; set; } = Array.Empty<string>();

	// Token: 0x17001CBB RID: 7355
	// (get) Token: 0x0601608D RID: 90253 RVA: 0x0061D108 File Offset: 0x0061B308
	// (set) Token: 0x0601608E RID: 90254 RVA: 0x0061D110 File Offset: 0x0061B310
	public string Color { get; set; } = "";
}
