using System;

// Token: 0x0200103F RID: 4159
public class FurnitureSlotScrollItemData : IFurnitureSlotScrollItemData
{
	// Token: 0x1700085C RID: 2140
	// (get) Token: 0x06006C58 RID: 27736 RVA: 0x001C5B2C File Offset: 0x001C3D2C
	// (set) Token: 0x06006C59 RID: 27737 RVA: 0x001C5B34 File Offset: 0x001C3D34
	public int SceneSlotEntityId { get; set; }

	// Token: 0x1700085D RID: 2141
	// (get) Token: 0x06006C5A RID: 27738 RVA: 0x001C5B3D File Offset: 0x001C3D3D
	// (set) Token: 0x06006C5B RID: 27739 RVA: 0x001C5B45 File Offset: 0x001C3D45
	public int PlacedFurnitureId { get; set; }

	// Token: 0x1700085E RID: 2142
	// (get) Token: 0x06006C5C RID: 27740 RVA: 0x001C5B4E File Offset: 0x001C3D4E
	// (set) Token: 0x06006C5D RID: 27741 RVA: 0x001C5B56 File Offset: 0x001C3D56
	public int SubSlotIndex { get; set; }

	// Token: 0x1700085F RID: 2143
	// (get) Token: 0x06006C5E RID: 27742 RVA: 0x001C5B5F File Offset: 0x001C3D5F
	// (set) Token: 0x06006C5F RID: 27743 RVA: 0x001C5B67 File Offset: 0x001C3D67
	public EFurnitureSlotType SlotType { get; set; }

	// Token: 0x17000860 RID: 2144
	// (get) Token: 0x06006C60 RID: 27744 RVA: 0x001C5B70 File Offset: 0x001C3D70
	// (set) Token: 0x06006C61 RID: 27745 RVA: 0x001C5B78 File Offset: 0x001C3D78
	public int TagId { get; set; }

	// Token: 0x17000861 RID: 2145
	// (get) Token: 0x06006C62 RID: 27746 RVA: 0x001C5B81 File Offset: 0x001C3D81
	// (set) Token: 0x06006C63 RID: 27747 RVA: 0x001C5B89 File Offset: 0x001C3D89
	public int TagIndex { get; set; }

	// Token: 0x17000862 RID: 2146
	// (get) Token: 0x06006C64 RID: 27748 RVA: 0x001C5B92 File Offset: 0x001C3D92
	// (set) Token: 0x06006C65 RID: 27749 RVA: 0x001C5B9A File Offset: 0x001C3D9A
	public bool ShowTagIndex { get; set; }

	// Token: 0x17000863 RID: 2147
	// (get) Token: 0x06006C66 RID: 27750 RVA: 0x001C5BA3 File Offset: 0x001C3DA3
	// (set) Token: 0x06006C67 RID: 27751 RVA: 0x001C5BAB File Offset: 0x001C3DAB
	public bool IsSelected { get; set; }

	// Token: 0x17000864 RID: 2148
	// (get) Token: 0x06006C68 RID: 27752 RVA: 0x001C5BB4 File Offset: 0x001C3DB4
	// (set) Token: 0x06006C69 RID: 27753 RVA: 0x001C5BBC File Offset: 0x001C3DBC
	public bool LineShowState { get; set; }

	// Token: 0x17000865 RID: 2149
	// (get) Token: 0x06006C6A RID: 27754 RVA: 0x001C5BC5 File Offset: 0x001C3DC5
	// (set) Token: 0x06006C6B RID: 27755 RVA: 0x001C5BCD File Offset: 0x001C3DCD
	public bool RedDotShowState { get; set; }
}
