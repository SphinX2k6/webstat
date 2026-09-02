using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020014E4 RID: 5348
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityPrizeDrawingConfig : ConfigBase<ActivityPrizeDrawingConfig>
{
	// Token: 0x0600959C RID: 38300 RVA: 0x00270B28 File Offset: 0x0026ED28
	public KujiActivity? GetKujiActivityByActivityId(int activityId)
	{
		return ConfigKujiActivityByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x0600959D RID: 38301 RVA: 0x00270B31 File Offset: 0x0026ED31
	public KujiAwardsGroup? GetKujiAwardsGroupById(int id)
	{
		return ConfigKujiAwardsGroupById.GetConfig(id, true);
	}

	// Token: 0x0600959E RID: 38302 RVA: 0x00270B3A File Offset: 0x0026ED3A
	public IReadOnlyList<KujiAwardsGroup> GetKujiAwardsGroupByKujiId(int kujiId)
	{
		return ConfigKujiAwardsGroupByKujiId.GetConfigList(kujiId, true);
	}

	// Token: 0x0600959F RID: 38303 RVA: 0x00270B43 File Offset: 0x0026ED43
	public KujiQuest? GetKujiQuestConfigById(int id)
	{
		return ConfigKujiQuestById.GetConfig(id, true);
	}

	// Token: 0x060095A0 RID: 38304 RVA: 0x00270B4C File Offset: 0x0026ED4C
	public IReadOnlyList<KujiQuest> GetKujiQuestConfigByKujiId(int kujiId)
	{
		return ConfigKujiQuestByKujiId.GetConfigList(kujiId, true);
	}
}
