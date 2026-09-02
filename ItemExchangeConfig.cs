using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002046 RID: 8262
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ItemExchangeConfig : ConfigBase<ItemExchangeConfig>
{
	// Token: 0x0600FBBF RID: 64447 RVA: 0x0045215C File Offset: 0x0045035C
	public IReadOnlyList<ItemExchangeContent> GetExChangeConfigList(int itemId)
	{
		IReadOnlyList<ItemExchangeContent> configList = ConfigItemExchangeContentAll.GetConfigList(true);
		List<ItemExchangeContent> list = new List<ItemExchangeContent>();
		if (configList != null)
		{
			foreach (ItemExchangeContent item in configList)
			{
				if (item.ItemId == itemId)
				{
					list.Add(item);
				}
			}
		}
		list.Sort((ItemExchangeContent a, ItemExchangeContent b) => a.Times - b.Times);
		return list;
	}

	// Token: 0x0600FBC0 RID: 64448 RVA: 0x004521E4 File Offset: 0x004503E4
	public ItemExchangeContent? GetFirstExChangeConfigList(int itemId)
	{
		return ConfigItemExchangeContentByItemId.GetConfig(itemId, true);
	}

	// Token: 0x0600FBC1 RID: 64449 RVA: 0x004521ED File Offset: 0x004503ED
	public ItemExchangeLimit? GetItemExchangeLimit(int itemId)
	{
		return ConfigItemExchangeLimitByItemId.GetConfig(itemId, true);
	}
}
