using System;
using System.Runtime.CompilerServices;

// Token: 0x02001047 RID: 4167
[NullableContext(1)]
[Nullable(0)]
public class FurnitureShopViewOpenData : IFurnitureShopViewOpenData
{
	// Token: 0x17000881 RID: 2177
	// (get) Token: 0x06006C95 RID: 27797 RVA: 0x001C5CA0 File Offset: 0x001C3EA0
	// (set) Token: 0x06006C96 RID: 27798 RVA: 0x001C5CA8 File Offset: 0x001C3EA8
	public int ShopId { get; set; }

	// Token: 0x17000882 RID: 2178
	// (get) Token: 0x06006C97 RID: 27799 RVA: 0x001C5CB1 File Offset: 0x001C3EB1
	// (set) Token: 0x06006C98 RID: 27800 RVA: 0x001C5CB9 File Offset: 0x001C3EB9
	public int NpcEntityId { get; set; }

	// Token: 0x17000883 RID: 2179
	// (get) Token: 0x06006C99 RID: 27801 RVA: 0x001C5CC2 File Offset: 0x001C3EC2
	// (set) Token: 0x06006C9A RID: 27802 RVA: 0x001C5CCA File Offset: 0x001C3ECA
	public string NpcName { get; set; }

	// Token: 0x17000884 RID: 2180
	// (get) Token: 0x06006C9B RID: 27803 RVA: 0x001C5CD3 File Offset: 0x001C3ED3
	// (set) Token: 0x06006C9C RID: 27804 RVA: 0x001C5CDB File Offset: 0x001C3EDB
	public string NpcDesc { get; set; }

	// Token: 0x17000885 RID: 2181
	// (get) Token: 0x06006C9D RID: 27805 RVA: 0x001C5CE4 File Offset: 0x001C3EE4
	// (set) Token: 0x06006C9E RID: 27806 RVA: 0x001C5CEC File Offset: 0x001C3EEC
	public string NpcStartMontagePath { get; set; }

	// Token: 0x17000886 RID: 2182
	// (get) Token: 0x06006C9F RID: 27807 RVA: 0x001C5CF5 File Offset: 0x001C3EF5
	// (set) Token: 0x06006CA0 RID: 27808 RVA: 0x001C5CFD File Offset: 0x001C3EFD
	public int GoodsId { get; set; }

	// Token: 0x17000887 RID: 2183
	// (get) Token: 0x06006CA1 RID: 27809 RVA: 0x001C5D06 File Offset: 0x001C3F06
	// (set) Token: 0x06006CA2 RID: 27810 RVA: 0x001C5D0E File Offset: 0x001C3F0E
	public bool UseSpareShopNpc { get; set; }
}
