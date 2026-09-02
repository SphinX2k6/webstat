using System;
using System.Runtime.CompilerServices;

// Token: 0x0200107E RID: 4222
[NullableContext(1)]
[Nullable(0)]
public class FurnitureAreaSelectItemData : IFurnitureAreaSelectItemData
{
	// Token: 0x170008DF RID: 2271
	// (get) Token: 0x06006DCA RID: 28106 RVA: 0x001C84B3 File Offset: 0x001C66B3
	// (set) Token: 0x06006DCB RID: 28107 RVA: 0x001C84BB File Offset: 0x001C66BB
	public int AreaId { get; set; }

	// Token: 0x170008E0 RID: 2272
	// (get) Token: 0x06006DCC RID: 28108 RVA: 0x001C84C4 File Offset: 0x001C66C4
	// (set) Token: 0x06006DCD RID: 28109 RVA: 0x001C84CC File Offset: 0x001C66CC
	public int FloorId { get; set; }

	// Token: 0x170008E1 RID: 2273
	// (get) Token: 0x06006DCE RID: 28110 RVA: 0x001C84D5 File Offset: 0x001C66D5
	// (set) Token: 0x06006DCF RID: 28111 RVA: 0x001C84DD File Offset: 0x001C66DD
	public string AreaName { get; set; }

	// Token: 0x170008E2 RID: 2274
	// (get) Token: 0x06006DD0 RID: 28112 RVA: 0x001C84E6 File Offset: 0x001C66E6
	// (set) Token: 0x06006DD1 RID: 28113 RVA: 0x001C84EE File Offset: 0x001C66EE
	public string LockAreaIcon { get; set; }

	// Token: 0x170008E3 RID: 2275
	// (get) Token: 0x06006DD2 RID: 28114 RVA: 0x001C84F7 File Offset: 0x001C66F7
	// (set) Token: 0x06006DD3 RID: 28115 RVA: 0x001C84FF File Offset: 0x001C66FF
	public string UnlockAreaIcon { get; set; }

	// Token: 0x170008E4 RID: 2276
	// (get) Token: 0x06006DD4 RID: 28116 RVA: 0x001C8508 File Offset: 0x001C6708
	// (set) Token: 0x06006DD5 RID: 28117 RVA: 0x001C8510 File Offset: 0x001C6710
	public bool IsSelected { get; set; }

	// Token: 0x170008E5 RID: 2277
	// (get) Token: 0x06006DD6 RID: 28118 RVA: 0x001C8519 File Offset: 0x001C6719
	// (set) Token: 0x06006DD7 RID: 28119 RVA: 0x001C8521 File Offset: 0x001C6721
	public bool IsUnlock { get; set; }

	// Token: 0x170008E6 RID: 2278
	// (get) Token: 0x06006DD8 RID: 28120 RVA: 0x001C852A File Offset: 0x001C672A
	// (set) Token: 0x06006DD9 RID: 28121 RVA: 0x001C8532 File Offset: 0x001C6732
	public int PlacedSlotCount { get; set; }

	// Token: 0x170008E7 RID: 2279
	// (get) Token: 0x06006DDA RID: 28122 RVA: 0x001C853B File Offset: 0x001C673B
	// (set) Token: 0x06006DDB RID: 28123 RVA: 0x001C8543 File Offset: 0x001C6743
	public int MaxSlotCount { get; set; }

	// Token: 0x170008E8 RID: 2280
	// (get) Token: 0x06006DDC RID: 28124 RVA: 0x001C854C File Offset: 0x001C674C
	// (set) Token: 0x06006DDD RID: 28125 RVA: 0x001C8554 File Offset: 0x001C6754
	public bool RedDotShowState { get; set; }

	// Token: 0x170008E9 RID: 2281
	// (get) Token: 0x06006DDE RID: 28126 RVA: 0x001C855D File Offset: 0x001C675D
	// (set) Token: 0x06006DDF RID: 28127 RVA: 0x001C8565 File Offset: 0x001C6765
	public Action<int> OnSelected { get; set; }
}
