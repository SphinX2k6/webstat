using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DF6 RID: 19958
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseShopGoods : ITrapDefenseShopGoods
	{
		// Token: 0x170088AB RID: 34987
		// (get) Token: 0x060339AB RID: 211371 RVA: 0x00CE4B10 File Offset: 0x00CE2D10
		// (set) Token: 0x060339AC RID: 211372 RVA: 0x00CE4B18 File Offset: 0x00CE2D18
		public int Id { get; set; }

		// Token: 0x170088AC RID: 34988
		// (get) Token: 0x060339AD RID: 211373 RVA: 0x00CE4B21 File Offset: 0x00CE2D21
		// (set) Token: 0x060339AE RID: 211374 RVA: 0x00CE4B29 File Offset: 0x00CE2D29
		public int? OriginalPrice { get; set; }

		// Token: 0x170088AD RID: 34989
		// (get) Token: 0x060339AF RID: 211375 RVA: 0x00CE4B32 File Offset: 0x00CE2D32
		// (set) Token: 0x060339B0 RID: 211376 RVA: 0x00CE4B3A File Offset: 0x00CE2D3A
		public int CurrentPrice { get; set; }

		// Token: 0x170088AE RID: 34990
		// (get) Token: 0x060339B1 RID: 211377 RVA: 0x00CE4B43 File Offset: 0x00CE2D43
		// (set) Token: 0x060339B2 RID: 211378 RVA: 0x00CE4B4B File Offset: 0x00CE2D4B
		public ETrapDefenseShopGoodsType Type { get; set; }

		// Token: 0x170088AF RID: 34991
		// (get) Token: 0x060339B3 RID: 211379 RVA: 0x00CE4B54 File Offset: 0x00CE2D54
		// (set) Token: 0x060339B4 RID: 211380 RVA: 0x00CE4B5C File Offset: 0x00CE2D5C
		public int QualityId { get; set; }

		// Token: 0x170088B0 RID: 34992
		// (get) Token: 0x060339B5 RID: 211381 RVA: 0x00CE4B65 File Offset: 0x00CE2D65
		// (set) Token: 0x060339B6 RID: 211382 RVA: 0x00CE4B6D File Offset: 0x00CE2D6D
		public string Name { get; set; } = "";

		// Token: 0x170088B1 RID: 34993
		// (get) Token: 0x060339B7 RID: 211383 RVA: 0x00CE4B76 File Offset: 0x00CE2D76
		// (set) Token: 0x060339B8 RID: 211384 RVA: 0x00CE4B7E File Offset: 0x00CE2D7E
		public string Desc { get; set; } = "";

		// Token: 0x170088B2 RID: 34994
		// (get) Token: 0x060339B9 RID: 211385 RVA: 0x00CE4B87 File Offset: 0x00CE2D87
		// (set) Token: 0x060339BA RID: 211386 RVA: 0x00CE4B8F File Offset: 0x00CE2D8F
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] DescArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170088B3 RID: 34995
		// (get) Token: 0x060339BB RID: 211387 RVA: 0x00CE4B98 File Offset: 0x00CE2D98
		// (set) Token: 0x060339BC RID: 211388 RVA: 0x00CE4BA0 File Offset: 0x00CE2DA0
		public string Icon { get; set; } = "";

		// Token: 0x170088B4 RID: 34996
		// (get) Token: 0x060339BD RID: 211389 RVA: 0x00CE4BA9 File Offset: 0x00CE2DA9
		public bool Disable { get; }

		// Token: 0x170088B5 RID: 34997
		// (get) Token: 0x060339BE RID: 211390 RVA: 0x00CE4BB1 File Offset: 0x00CE2DB1
		public int CanPurchaseNum { get; }

		// Token: 0x170088B6 RID: 34998
		// (get) Token: 0x060339BF RID: 211391 RVA: 0x00CE4BB9 File Offset: 0x00CE2DB9
		public ETrapDefenseShopGoodsUnavailableReason DisableReason { get; }

		// Token: 0x170088B7 RID: 34999
		// (get) Token: 0x060339C0 RID: 211392 RVA: 0x00CE4BC1 File Offset: 0x00CE2DC1
		// (set) Token: 0x060339C1 RID: 211393 RVA: 0x00CE4BC9 File Offset: 0x00CE2DC9
		public Func<PropMediumItemGrid> GetItemGridParam { get; set; }
	}
}
