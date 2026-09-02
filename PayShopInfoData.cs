using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020023B1 RID: 9137
[NullableContext(1)]
[Nullable(0)]
public class PayShopInfoData
{
	// Token: 0x06011A05 RID: 72197 RVA: 0x004D60D4 File Offset: 0x004D42D4
	public void Phrase(PayShopInfo info)
	{
		this.Id = info.Id;
		this.UpdateTime = Singleton<MathUtils>.Instance.LongToBigInt(info.UpdateTime);
		this.LastUpdateTime = Singleton<MathUtils>.Instance.LongToBigInt(info.LastUpdateTime);
		this.ShopTabViewType = info.ShopTabViewType;
		this.DynamicTabId = info.DynamicTabId;
		this.Sort = info.Sort;
		this.Money = info.Money.ToList<int>();
		this.SortRule = info.SortRule;
		this.TabContentPath = info.PayShopTabTogContent;
		this.EnableServerRedDot = info.EnableServerRedDot;
	}

	// Token: 0x04008A03 RID: 35331
	public int Id;

	// Token: 0x04008A04 RID: 35332
	public long UpdateTime;

	// Token: 0x04008A05 RID: 35333
	public long LastUpdateTime;

	// Token: 0x04008A06 RID: 35334
	public int ShopTabViewType;

	// Token: 0x04008A07 RID: 35335
	public int DynamicTabId;

	// Token: 0x04008A08 RID: 35336
	public int Sort;

	// Token: 0x04008A09 RID: 35337
	public List<int> Money = new List<int>();

	// Token: 0x04008A0A RID: 35338
	public int SortRule;

	// Token: 0x04008A0B RID: 35339
	public string TabContentPath = "";

	// Token: 0x04008A0C RID: 35340
	public bool EnableServerRedDot;
}
