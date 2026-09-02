using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056B3 RID: 22195
	[NullableContext(1)]
	public interface IPriceData
	{
		// Token: 0x170090A4 RID: 37028
		// (get) Token: 0x060387CD RID: 231373
		// (set) Token: 0x060387CE RID: 231374
		Func<int> OwnNumber { get; set; }

		// Token: 0x170090A5 RID: 37029
		// (get) Token: 0x060387CF RID: 231375
		// (set) Token: 0x060387D0 RID: 231376
		int NowPrice { get; set; }

		// Token: 0x170090A6 RID: 37030
		// (get) Token: 0x060387D1 RID: 231377
		// (set) Token: 0x060387D2 RID: 231378
		int? OriginalPrice { get; set; }

		// Token: 0x170090A7 RID: 37031
		// (get) Token: 0x060387D3 RID: 231379
		// (set) Token: 0x060387D4 RID: 231380
		int CurrencyId { get; set; }

		// Token: 0x170090A8 RID: 37032
		// (get) Token: 0x060387D5 RID: 231381
		// (set) Token: 0x060387D6 RID: 231382
		bool Enough { get; set; }

		// Token: 0x170090A9 RID: 37033
		// (get) Token: 0x060387D7 RID: 231383
		// (set) Token: 0x060387D8 RID: 231384
		bool InDiscountTime { get; set; }
	}
}
