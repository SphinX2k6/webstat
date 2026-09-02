using System;

// Token: 0x020029FF RID: 10751
public class ItemPrice
{
	// Token: 0x0601572F RID: 87855 RVA: 0x005F18DE File Offset: 0x005EFADE
	public ItemPrice(int id, int price, int originPrice)
	{
		this.CoinId = id;
		this.CoinPrice = price;
		this.OriginalPrice = originPrice;
	}

	// Token: 0x0400A507 RID: 42247
	public readonly int CoinId;

	// Token: 0x0400A508 RID: 42248
	public readonly int CoinPrice;

	// Token: 0x0400A509 RID: 42249
	public readonly int OriginalPrice;
}
