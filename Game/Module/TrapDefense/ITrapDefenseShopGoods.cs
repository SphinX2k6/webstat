using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DF5 RID: 19957
	[NullableContext(1)]
	public interface ITrapDefenseShopGoods
	{
		// Token: 0x1700889E RID: 34974
		// (get) Token: 0x06033994 RID: 211348
		// (set) Token: 0x06033995 RID: 211349
		int Id { get; set; }

		// Token: 0x1700889F RID: 34975
		// (get) Token: 0x06033996 RID: 211350
		// (set) Token: 0x06033997 RID: 211351
		int? OriginalPrice { get; set; }

		// Token: 0x170088A0 RID: 34976
		// (get) Token: 0x06033998 RID: 211352
		// (set) Token: 0x06033999 RID: 211353
		int CurrentPrice { get; set; }

		// Token: 0x170088A1 RID: 34977
		// (get) Token: 0x0603399A RID: 211354
		// (set) Token: 0x0603399B RID: 211355
		ETrapDefenseShopGoodsType Type { get; set; }

		// Token: 0x170088A2 RID: 34978
		// (get) Token: 0x0603399C RID: 211356
		// (set) Token: 0x0603399D RID: 211357
		int QualityId { get; set; }

		// Token: 0x170088A3 RID: 34979
		// (get) Token: 0x0603399E RID: 211358
		// (set) Token: 0x0603399F RID: 211359
		string Name { get; set; }

		// Token: 0x170088A4 RID: 34980
		// (get) Token: 0x060339A0 RID: 211360
		// (set) Token: 0x060339A1 RID: 211361
		string Desc { get; set; }

		// Token: 0x170088A5 RID: 34981
		// (get) Token: 0x060339A2 RID: 211362
		// (set) Token: 0x060339A3 RID: 211363
		[Nullable(new byte[]
		{
			2,
			1
		})]
		string[] DescArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170088A6 RID: 34982
		// (get) Token: 0x060339A4 RID: 211364
		// (set) Token: 0x060339A5 RID: 211365
		string Icon { get; set; }

		// Token: 0x170088A7 RID: 34983
		// (get) Token: 0x060339A6 RID: 211366
		bool Disable { get; }

		// Token: 0x170088A8 RID: 34984
		// (get) Token: 0x060339A7 RID: 211367
		int CanPurchaseNum { get; }

		// Token: 0x170088A9 RID: 34985
		// (get) Token: 0x060339A8 RID: 211368
		ETrapDefenseShopGoodsUnavailableReason DisableReason { get; }

		// Token: 0x170088AA RID: 34986
		// (get) Token: 0x060339A9 RID: 211369
		// (set) Token: 0x060339AA RID: 211370
		Func<PropMediumItemGrid> GetItemGridParam { get; set; }
	}
}
