using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001249 RID: 4681
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityBeginnerBookConfig : ConfigBase<ActivityBeginnerBookConfig>
{
	// Token: 0x06007CC8 RID: 31944 RVA: 0x0020D9B0 File Offset: 0x0020BBB0
	public WorldNewJourney GetActivityBeginnerConfig(int id)
	{
		return ConfigWorldNewJourneyById.GetConfig(id, true).Value;
	}

	// Token: 0x06007CC9 RID: 31945 RVA: 0x0020D9CC File Offset: 0x0020BBCC
	public WorldNewJourney[] GetAllActivityBeginnerConfig()
	{
		return ConfigWorldNewJourneyAll.GetConfigList(true).ToArray<WorldNewJourney>();
	}
}
