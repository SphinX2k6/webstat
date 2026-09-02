using System;

// Token: 0x020014DC RID: 5340
public class PinballItemDataMonster : IPinballItemDataMonster
{
	// Token: 0x17000CD7 RID: 3287
	// (get) Token: 0x06009560 RID: 38240 RVA: 0x0027092E File Offset: 0x0026EB2E
	// (set) Token: 0x06009561 RID: 38241 RVA: 0x00270936 File Offset: 0x0026EB36
	public EPinballItemType Type { get; set; }

	// Token: 0x17000CD8 RID: 3288
	// (get) Token: 0x06009562 RID: 38242 RVA: 0x0027093F File Offset: 0x0026EB3F
	// (set) Token: 0x06009563 RID: 38243 RVA: 0x00270947 File Offset: 0x0026EB47
	public int Id { get; set; }
}
