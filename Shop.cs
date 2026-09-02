using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020029F8 RID: 10744
[NullableContext(1)]
[Nullable(0)]
public class Shop
{
	// Token: 0x17001BF5 RID: 7157
	// (get) Token: 0x060156EB RID: 87787 RVA: 0x005F028E File Offset: 0x005EE48E
	public uint UpdateTime
	{
		get
		{
			return this.InnerUpdateTime;
		}
	}

	// Token: 0x060156EC RID: 87788 RVA: 0x005F0296 File Offset: 0x005EE496
	public Shop(ShopInfo shopInfo)
	{
		this.InnerUpdateTime = shopInfo.UpdateTime;
		this.ItemList = new Dictionary<int, ShopItemInfoNew>();
		this.UpdateShopItemList(shopInfo.ItemInfoList.ToList<ShopItemInfoNew>());
	}

	// Token: 0x060156ED RID: 87789 RVA: 0x005F02C6 File Offset: 0x005EE4C6
	public void UpdateRefreshTime(uint refreshTime)
	{
		this.InnerUpdateTime = refreshTime;
	}

	// Token: 0x060156EE RID: 87790 RVA: 0x005F02D0 File Offset: 0x005EE4D0
	public void UpdateShopItemList(List<ShopItemInfoNew> itemInfoList)
	{
		this.ItemList.Clear();
		foreach (ShopItemInfoNew shopItemInfoNew in itemInfoList)
		{
			this.ItemList[shopItemInfoNew.Id] = shopItemInfoNew;
		}
	}

	// Token: 0x060156EF RID: 87791 RVA: 0x005F0334 File Offset: 0x005EE534
	[NullableContext(2)]
	public ShopItemInfoNew GetItemInfo(int id)
	{
		ShopItemInfoNew result;
		if (this.ItemList.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060156F0 RID: 87792 RVA: 0x005F0354 File Offset: 0x005EE554
	public Dictionary<int, ShopItemInfoNew> GetItemList()
	{
		return this.ItemList;
	}

	// Token: 0x0400A4E6 RID: 42214
	private uint InnerUpdateTime;

	// Token: 0x0400A4E7 RID: 42215
	private readonly Dictionary<int, ShopItemInfoNew> ItemList;
}
