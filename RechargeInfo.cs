using System;
using System.Runtime.CompilerServices;

// Token: 0x0200274B RID: 10059
[NullableContext(1)]
[Nullable(0)]
public class RechargeInfo
{
	// Token: 0x06013DC1 RID: 81345 RVA: 0x005890D0 File Offset: 0x005872D0
	public void Init(int payId, string amount, string productId)
	{
		this.PayId = payId;
		this.Amount = amount;
		this.ProductId = productId;
	}

	// Token: 0x04009A74 RID: 39540
	public int PayId;

	// Token: 0x04009A75 RID: 39541
	public string Amount = "";

	// Token: 0x04009A76 RID: 39542
	public string ProductId = "";
}
