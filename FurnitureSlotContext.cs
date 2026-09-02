using System;

// Token: 0x02001059 RID: 4185
public class FurnitureSlotContext : IFurnitureSlotContext
{
	// Token: 0x170008A4 RID: 2212
	// (get) Token: 0x06006CD3 RID: 27859 RVA: 0x001C5E2C File Offset: 0x001C402C
	// (set) Token: 0x06006CD4 RID: 27860 RVA: 0x001C5E34 File Offset: 0x001C4034
	public int SlotEntityId { get; set; }

	// Token: 0x170008A5 RID: 2213
	// (get) Token: 0x06006CD5 RID: 27861 RVA: 0x001C5E3D File Offset: 0x001C403D
	// (set) Token: 0x06006CD6 RID: 27862 RVA: 0x001C5E45 File Offset: 0x001C4045
	public int SubSlotIndex { get; set; }
}
