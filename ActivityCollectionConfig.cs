using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200129A RID: 4762
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityCollectionConfig : ConfigBase<ActivityCollectionConfig>
{
	// Token: 0x06007F8B RID: 32651 RVA: 0x0021B574 File Offset: 0x00219774
	public GatherActivity GetActivityCollectionConfig(int id)
	{
		return ConfigGatherActivityById.GetConfig(id, true).Value;
	}

	// Token: 0x06007F8C RID: 32652 RVA: 0x0021B590 File Offset: 0x00219790
	public IReadOnlyList<GatherActivity> GetAllActivityCollectionConfig()
	{
		return ConfigGatherActivityAll.GetConfigList(true);
	}
}
