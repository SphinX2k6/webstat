using System;
using System.Runtime.CompilerServices;

// Token: 0x02001066 RID: 4198
[NullableContext(1)]
[Nullable(0)]
public class FurnitureDesignReportContext : IFurnitureDesignReportContext
{
	// Token: 0x170008C1 RID: 2241
	// (get) Token: 0x06006D03 RID: 27907 RVA: 0x001C5F39 File Offset: 0x001C4139
	// (set) Token: 0x06006D04 RID: 27908 RVA: 0x001C5F41 File Offset: 0x001C4141
	public int AreaId { get; set; }

	// Token: 0x170008C2 RID: 2242
	// (get) Token: 0x06006D05 RID: 27909 RVA: 0x001C5F4A File Offset: 0x001C414A
	// (set) Token: 0x06006D06 RID: 27910 RVA: 0x001C5F52 File Offset: 0x001C4152
	public EFurnitureDesignReportOperationType OperationType { get; set; }

	// Token: 0x170008C3 RID: 2243
	// (get) Token: 0x06006D07 RID: 27911 RVA: 0x001C5F5B File Offset: 0x001C415B
	// (set) Token: 0x06006D08 RID: 27912 RVA: 0x001C5F63 File Offset: 0x001C4163
	public IFurnitureSlotContext SlotContext { get; set; }

	// Token: 0x170008C4 RID: 2244
	// (get) Token: 0x06006D09 RID: 27913 RVA: 0x001C5F6C File Offset: 0x001C416C
	// (set) Token: 0x06006D0A RID: 27914 RVA: 0x001C5F74 File Offset: 0x001C4174
	public int? OldFurnitureId { get; set; }

	// Token: 0x170008C5 RID: 2245
	// (get) Token: 0x06006D0B RID: 27915 RVA: 0x001C5F7D File Offset: 0x001C417D
	// (set) Token: 0x06006D0C RID: 27916 RVA: 0x001C5F85 File Offset: 0x001C4185
	public int? NewFurnitureId { get; set; }
}
