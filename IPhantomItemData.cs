using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200247B RID: 9339
[NullableContext(1)]
public interface IPhantomItemData
{
	// Token: 0x170016D3 RID: 5843
	// (get) Token: 0x060121F4 RID: 74228
	// (set) Token: 0x060121F5 RID: 74229
	bool IsPhantomData { get; set; }

	// Token: 0x170016D4 RID: 5844
	// (get) Token: 0x060121F6 RID: 74230
	// (set) Token: 0x060121F7 RID: 74231
	int Id { get; set; }

	// Token: 0x170016D5 RID: 5845
	// (get) Token: 0x060121F8 RID: 74232
	// (set) Token: 0x060121F9 RID: 74233
	int Quality { get; set; }

	// Token: 0x170016D6 RID: 5846
	// (get) Token: 0x060121FA RID: 74234
	// (set) Token: 0x060121FB RID: 74235
	bool IsEquip { get; set; }

	// Token: 0x170016D7 RID: 5847
	// (get) Token: 0x060121FC RID: 74236
	// (set) Token: 0x060121FD RID: 74237
	int Role { get; set; }

	// Token: 0x170016D8 RID: 5848
	// (get) Token: 0x060121FE RID: 74238
	// (set) Token: 0x060121FF RID: 74239
	int Level { get; set; }

	// Token: 0x170016D9 RID: 5849
	// (get) Token: 0x06012200 RID: 74240
	// (set) Token: 0x06012201 RID: 74241
	bool IsBreach { get; set; }

	// Token: 0x170016DA RID: 5850
	// (get) Token: 0x06012202 RID: 74242
	// (set) Token: 0x06012203 RID: 74243
	int MonsterId { get; set; }

	// Token: 0x170016DB RID: 5851
	// (get) Token: 0x06012204 RID: 74244
	// (set) Token: 0x06012205 RID: 74245
	List<PhantomSortStruct> MainPropMap { get; set; }

	// Token: 0x170016DC RID: 5852
	// (get) Token: 0x06012206 RID: 74246
	// (set) Token: 0x06012207 RID: 74247
	List<PhantomSortStruct> SubPropMap { get; set; }

	// Token: 0x170016DD RID: 5853
	// (get) Token: 0x06012208 RID: 74248
	// (set) Token: 0x06012209 RID: 74249
	bool IsLock { get; set; }

	// Token: 0x170016DE RID: 5854
	// (get) Token: 0x0601220A RID: 74250
	// (set) Token: 0x0601220B RID: 74251
	bool IsDeprecate { get; set; }

	// Token: 0x170016DF RID: 5855
	// (get) Token: 0x0601220C RID: 74252
	// (set) Token: 0x0601220D RID: 74253
	int ConfigId { get; set; }

	// Token: 0x170016E0 RID: 5856
	// (get) Token: 0x0601220E RID: 74254
	// (set) Token: 0x0601220F RID: 74255
	int Rarity { get; set; }
}
