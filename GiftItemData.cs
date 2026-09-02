using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002012 RID: 8210
public class GiftItemData
{
	// Token: 0x0600F8B2 RID: 63666 RVA: 0x0044303C File Offset: 0x0044123C
	public GiftItemData(int itemId, int itemCount, int incId)
	{
		this.ItemId = itemId;
		this.ItemCount = itemCount;
		this.IncId = incId;
	}

	// Token: 0x0600F8B3 RID: 63667 RVA: 0x00443059 File Offset: 0x00441259
	[NullableContext(1)]
	public void SetPhantomItemData(PhantomItem data)
	{
		this.PhantomItemData = data;
	}

	// Token: 0x040077E9 RID: 30697
	public readonly int ItemId;

	// Token: 0x040077EA RID: 30698
	public readonly int ItemCount;

	// Token: 0x040077EB RID: 30699
	public readonly int IncId;

	// Token: 0x040077EC RID: 30700
	[Nullable(2)]
	public PhantomItem PhantomItemData;
}
