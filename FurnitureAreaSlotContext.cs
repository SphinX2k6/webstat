using System;
using System.Runtime.CompilerServices;

// Token: 0x0200105B RID: 4187
[NullableContext(1)]
[Nullable(0)]
public class FurnitureAreaSlotContext : IFurnitureAreaSlotContext
{
	// Token: 0x170008A8 RID: 2216
	// (get) Token: 0x06006CDA RID: 27866 RVA: 0x001C5E56 File Offset: 0x001C4056
	// (set) Token: 0x06006CDB RID: 27867 RVA: 0x001C5E5E File Offset: 0x001C405E
	public FurnitureAreaData AreaData { get; set; }

	// Token: 0x170008A9 RID: 2217
	// (get) Token: 0x06006CDC RID: 27868 RVA: 0x001C5E67 File Offset: 0x001C4067
	// (set) Token: 0x06006CDD RID: 27869 RVA: 0x001C5E6F File Offset: 0x001C406F
	public IFurnitureSlotContext SlotContext { get; set; }
}
