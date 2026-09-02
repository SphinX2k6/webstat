using System;
using System.Runtime.CompilerServices;

// Token: 0x02002602 RID: 9730
public class PowerItemInfo
{
	// Token: 0x170017D2 RID: 6098
	// (get) Token: 0x06013115 RID: 78101 RVA: 0x00549085 File Offset: 0x00547285
	// (set) Token: 0x06013114 RID: 78100 RVA: 0x00549060 File Offset: 0x00547260
	public int ItemId
	{
		get
		{
			return this.InnerItemId;
		}
		set
		{
			this.InnerItemId = value;
			if (this.InnerItemId <= 2000)
			{
				this.ShopId = 6;
				return;
			}
			this.ShopId = 7;
		}
	}

	// Token: 0x06013116 RID: 78102 RVA: 0x0054908D File Offset: 0x0054728D
	public PowerItemInfo(int itemId)
	{
		this.ItemId = itemId;
	}

	// Token: 0x040094CC RID: 38092
	[Nullable(1)]
	public string ItemName = "";

	// Token: 0x040094CD RID: 38093
	private int InnerItemId;

	// Token: 0x040094CE RID: 38094
	public int StackValue;

	// Token: 0x040094CF RID: 38095
	public int RenewValue;

	// Token: 0x040094D0 RID: 38096
	public int CostValue;

	// Token: 0x040094D1 RID: 38097
	public int ShopId;

	// Token: 0x040094D2 RID: 38098
	public int GoodsId;

	// Token: 0x040094D3 RID: 38099
	public bool IsHideWhenZero;

	// Token: 0x040094D4 RID: 38100
	public int RemainCount;
}
