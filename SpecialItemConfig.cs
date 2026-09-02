using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200207C RID: 8316
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class SpecialItemConfig : ConfigBase<SpecialItemConfig>
{
	// Token: 0x0600FD5D RID: 64861 RVA: 0x00457AB4 File Offset: 0x00455CB4
	public SpecialItem? GetConfig(int configId)
	{
		ItemInfo? config = ConfigItemInfoById.GetConfig(configId, true);
		if (config == null || !config.Value.SpecialItem)
		{
			return null;
		}
		SpecialItem? config2 = ConfigSpecialItemById.GetConfig(configId, true);
		if (config2 == null)
		{
			return null;
		}
		return config2;
	}

	// Token: 0x0600FD5E RID: 64862 RVA: 0x00457B0C File Offset: 0x00455D0C
	public List<int> GetAllowTagIds(int configId)
	{
		SpecialItem? config = ConfigSpecialItemById.GetConfig(configId, true);
		List<int> list = new List<int>();
		foreach (string tagName in config.Value.AllowTags())
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
			list.Add(tagIdByName);
		}
		return list;
	}

	// Token: 0x0600FD5F RID: 64863 RVA: 0x00457B64 File Offset: 0x00455D64
	public List<int> GetBanTagIds(int configId)
	{
		SpecialItem? config = ConfigSpecialItemById.GetConfig(configId, true);
		List<int> list = new List<int>();
		foreach (string tagName in config.Value.BanTags())
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
			list.Add(tagIdByName);
		}
		return list;
	}
}
