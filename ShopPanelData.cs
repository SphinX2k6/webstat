using System;
using System.Runtime.CompilerServices;

// Token: 0x020029FB RID: 10747
[NullableContext(2)]
[Nullable(0)]
public class ShopPanelData
{
	// Token: 0x06015702 RID: 87810 RVA: 0x005F063F File Offset: 0x005EE83F
	public bool IsSoldOut()
	{
		return this.BuyLimit > 0 && this.BoughtCount == this.BuyLimit;
	}

	// Token: 0x06015703 RID: 87811 RVA: 0x005F065A File Offset: 0x005EE85A
	public bool IsInteractive()
	{
		return !this.IsSoldOut() && this.InSellTime && !this.IsLock;
	}

	// Token: 0x0400A4ED RID: 42221
	public int ItemId;

	// Token: 0x0400A4EE RID: 42222
	public object ParamData;

	// Token: 0x0400A4EF RID: 42223
	public int CurrencyId;

	// Token: 0x0400A4F0 RID: 42224
	public int SingleBuyCount;

	// Token: 0x0400A4F1 RID: 42225
	public int SingleBuyPrice;

	// Token: 0x0400A4F2 RID: 42226
	public int BoughtCount;

	// Token: 0x0400A4F3 RID: 42227
	public int BuyLimit;

	// Token: 0x0400A4F4 RID: 42228
	public bool IsLock;

	// Token: 0x0400A4F5 RID: 42229
	public object LockText;

	// Token: 0x0400A4F6 RID: 42230
	public bool InSellTime;

	// Token: 0x0400A4F7 RID: 42231
	public TBuySuccess BuySuccessFunction;
}
