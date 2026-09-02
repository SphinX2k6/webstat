using System;
using System.Runtime.CompilerServices;

// Token: 0x0200105D RID: 4189
[NullableContext(1)]
[Nullable(0)]
public class FurniturePlaceToNewSlotContext : IFurniturePlaceToNewSlotContext
{
	// Token: 0x170008AC RID: 2220
	// (get) Token: 0x06006CE1 RID: 27873 RVA: 0x001C5E80 File Offset: 0x001C4080
	// (set) Token: 0x06006CE2 RID: 27874 RVA: 0x001C5E88 File Offset: 0x001C4088
	public IFurnitureAreaSlotContext SourceContext { get; set; }

	// Token: 0x170008AD RID: 2221
	// (get) Token: 0x06006CE3 RID: 27875 RVA: 0x001C5E91 File Offset: 0x001C4091
	// (set) Token: 0x06006CE4 RID: 27876 RVA: 0x001C5E99 File Offset: 0x001C4099
	public IFurnitureAreaSlotContext TargetContext { get; set; }
}
