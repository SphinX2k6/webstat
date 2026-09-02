using System;
using System.Runtime.CompilerServices;

// Token: 0x0200105F RID: 4191
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSceneItemPlaceContext : IFurnitureSceneItemPlaceContext
{
	// Token: 0x170008B1 RID: 2225
	// (get) Token: 0x06006CE9 RID: 27881 RVA: 0x001C5EAA File Offset: 0x001C40AA
	// (set) Token: 0x06006CEA RID: 27882 RVA: 0x001C5EB2 File Offset: 0x001C40B2
	public IFurnitureAreaSlotContext AreaSlotContext { get; set; }

	// Token: 0x170008B2 RID: 2226
	// (get) Token: 0x06006CEB RID: 27883 RVA: 0x001C5EBB File Offset: 0x001C40BB
	// (set) Token: 0x06006CEC RID: 27884 RVA: 0x001C5EC3 File Offset: 0x001C40C3
	public int FurnitureId { get; set; }

	// Token: 0x170008B3 RID: 2227
	// (get) Token: 0x06006CED RID: 27885 RVA: 0x001C5ECC File Offset: 0x001C40CC
	// (set) Token: 0x06006CEE RID: 27886 RVA: 0x001C5ED4 File Offset: 0x001C40D4
	public bool KeepSubFurniture { get; set; }
}
