using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056B4 RID: 22196
	[NullableContext(1)]
	[Nullable(0)]
	public class PriceData : IPriceData
	{
		// Token: 0x170090AA RID: 37034
		// (get) Token: 0x060387D9 RID: 231385 RVA: 0x00E4FDCE File Offset: 0x00E4DFCE
		// (set) Token: 0x060387DA RID: 231386 RVA: 0x00E4FDD6 File Offset: 0x00E4DFD6
		public Func<int> OwnNumber { get; set; }

		// Token: 0x170090AB RID: 37035
		// (get) Token: 0x060387DB RID: 231387 RVA: 0x00E4FDDF File Offset: 0x00E4DFDF
		// (set) Token: 0x060387DC RID: 231388 RVA: 0x00E4FDE7 File Offset: 0x00E4DFE7
		public int NowPrice { get; set; }

		// Token: 0x170090AC RID: 37036
		// (get) Token: 0x060387DD RID: 231389 RVA: 0x00E4FDF0 File Offset: 0x00E4DFF0
		// (set) Token: 0x060387DE RID: 231390 RVA: 0x00E4FDF8 File Offset: 0x00E4DFF8
		public int? OriginalPrice { get; set; }

		// Token: 0x170090AD RID: 37037
		// (get) Token: 0x060387DF RID: 231391 RVA: 0x00E4FE01 File Offset: 0x00E4E001
		// (set) Token: 0x060387E0 RID: 231392 RVA: 0x00E4FE09 File Offset: 0x00E4E009
		public int CurrencyId { get; set; }

		// Token: 0x170090AE RID: 37038
		// (get) Token: 0x060387E1 RID: 231393 RVA: 0x00E4FE12 File Offset: 0x00E4E012
		// (set) Token: 0x060387E2 RID: 231394 RVA: 0x00E4FE1A File Offset: 0x00E4E01A
		public bool Enough { get; set; }

		// Token: 0x170090AF RID: 37039
		// (get) Token: 0x060387E3 RID: 231395 RVA: 0x00E4FE23 File Offset: 0x00E4E023
		// (set) Token: 0x060387E4 RID: 231396 RVA: 0x00E4FE2B File Offset: 0x00E4E02B
		public bool InDiscountTime { get; set; }
	}
}
