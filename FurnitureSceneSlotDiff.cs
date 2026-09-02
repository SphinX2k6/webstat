using System;
using System.Runtime.CompilerServices;

// Token: 0x02001050 RID: 4176
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSceneSlotDiff : IFurnitureSceneSlotDiff
{
	// Token: 0x17000892 RID: 2194
	// (get) Token: 0x06006CB3 RID: 27827 RVA: 0x001C5D62 File Offset: 0x001C3F62
	// (set) Token: 0x06006CB4 RID: 27828 RVA: 0x001C5D6A File Offset: 0x001C3F6A
	public int RootFurnitureToPlace { get; set; }

	// Token: 0x17000893 RID: 2195
	// (get) Token: 0x06006CB5 RID: 27829 RVA: 0x001C5D73 File Offset: 0x001C3F73
	// (set) Token: 0x06006CB6 RID: 27830 RVA: 0x001C5D7B File Offset: 0x001C3F7B
	public int RootFurnitureToUnPlace { get; set; }

	// Token: 0x17000894 RID: 2196
	// (get) Token: 0x06006CB7 RID: 27831 RVA: 0x001C5D84 File Offset: 0x001C3F84
	// (set) Token: 0x06006CB8 RID: 27832 RVA: 0x001C5D8C File Offset: 0x001C3F8C
	public int[] SubFurnitureListToPlace { get; set; }

	// Token: 0x17000895 RID: 2197
	// (get) Token: 0x06006CB9 RID: 27833 RVA: 0x001C5D95 File Offset: 0x001C3F95
	// (set) Token: 0x06006CBA RID: 27834 RVA: 0x001C5D9D File Offset: 0x001C3F9D
	public int[] SubFurnitureListToUnPlace { get; set; }
}
