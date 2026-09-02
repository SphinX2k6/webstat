using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020015D8 RID: 5592
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityTowerGuideConfig : ConfigBase<ActivityTowerGuideConfig>
{
	// Token: 0x06009D67 RID: 40295 RVA: 0x0029395F File Offset: 0x00291B5F
	public TowerGuide? GetTowerGuideById(int id)
	{
		return ConfigTowerGuideById.GetConfig(id, true);
	}
}
