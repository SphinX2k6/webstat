using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020023B0 RID: 9136
public class PayShopGoodsPrice
{
	// Token: 0x06011A01 RID: 72193 RVA: 0x004D6063 File Offset: 0x004D4263
	[NullableContext(1)]
	public void Phrase(PayShopPrice data)
	{
		this.Id = data.Id;
		this.Count = data.Count;
		this.PromotionCount = data.PromotionCount;
	}

	// Token: 0x06011A02 RID: 72194 RVA: 0x004D6089 File Offset: 0x004D4289
	public int GetDiscount()
	{
		return (int)Math.Ceiling((double)((this.Count - this.PromotionCount) * 100) / (double)this.Count);
	}

	// Token: 0x06011A03 RID: 72195 RVA: 0x004D60AA File Offset: 0x004D42AA
	public int GetDiscountNew()
	{
		return (int)Math.Floor((double)((this.Count - this.PromotionCount) * 100) / (double)this.PromotionCount);
	}

	// Token: 0x04008A00 RID: 35328
	public int Id;

	// Token: 0x04008A01 RID: 35329
	public int Count;

	// Token: 0x04008A02 RID: 35330
	public int PromotionCount;
}
