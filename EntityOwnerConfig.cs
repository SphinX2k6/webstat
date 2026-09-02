using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02003494 RID: 13460
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class EntityOwnerConfig : ConfigBase<EntityOwnerConfig>
{
	// Token: 0x0601C650 RID: 116304 RVA: 0x00881FF0 File Offset: 0x008801F0
	public EntityOwnerData? GetEntityOwnerConfig(string guid)
	{
		EntityOwnerData? config = ConfigEntityOwnerDataByGuid.GetConfig(guid, true);
		if (config == null)
		{
			return null;
		}
		return config;
	}

	// Token: 0x0601C651 RID: 116305 RVA: 0x0088201C File Offset: 0x0088021C
	public EntityOwnerData? CheckEntityOwnerConfig(string guid)
	{
		IReadOnlyList<EntityOwnerData> configList = ConfigEntityOwnerDataById.GetConfigList(guid, true);
		if (configList == null || configList.Count == 0)
		{
			return null;
		}
		return new EntityOwnerData?(configList[0]);
	}
}
