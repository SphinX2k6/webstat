using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001B9F RID: 7071
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FeedbackRewardConfig : ConfigBase<FeedbackRewardConfig>
{
	// Token: 0x0600CDB2 RID: 52658 RVA: 0x0036CD60 File Offset: 0x0036AF60
	public GivebackScoreReward? GetGivebackScoreRewardById(int id)
	{
		return ConfigGivebackScoreRewardById.GetConfig(id, true);
	}

	// Token: 0x0600CDB3 RID: 52659 RVA: 0x0036CD69 File Offset: 0x0036AF69
	public IReadOnlyList<GivebackScoreReward> GetGivebackScoreRewardAll()
	{
		return ConfigGivebackScoreRewardAll.GetConfigList(true);
	}

	// Token: 0x0600CDB4 RID: 52660 RVA: 0x0036CD71 File Offset: 0x0036AF71
	public GivebackTask? GetGivebackTaskById(int id)
	{
		return ConfigGivebackTaskByTaskId.GetConfig(id, true);
	}

	// Token: 0x0600CDB5 RID: 52661 RVA: 0x0036CD7A File Offset: 0x0036AF7A
	public IReadOnlyList<GivebackTask> GetGivebackTaskAll()
	{
		return ConfigGivebackTaskAll.GetConfigList(true);
	}
}
