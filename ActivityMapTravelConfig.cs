using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200137D RID: 4989
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityMapTravelConfig : ConfigBase<ActivityMapTravelConfig>
{
	// Token: 0x060088D9 RID: 35033 RVA: 0x00241221 File Offset: 0x0023F421
	public MapTravelConfig? GetActivityConfig(int activityId)
	{
		return ConfigMapTravelConfigByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x060088DA RID: 35034 RVA: 0x0024122A File Offset: 0x0023F42A
	public MapLevelExp? GetLevelExpConfig(int id)
	{
		return ConfigMapLevelExpById.GetConfig(id, true);
	}

	// Token: 0x060088DB RID: 35035 RVA: 0x00241233 File Offset: 0x0023F433
	public IReadOnlyList<MapLevelExp> GetAllLevelExpConfig(int activityId)
	{
		return ConfigMapLevelExpByActivityId.GetConfigList(activityId, true) ?? new MapLevelExp[0];
	}

	// Token: 0x060088DC RID: 35036 RVA: 0x00241246 File Offset: 0x0023F446
	public TravelTask? GetTravelTaskConfig(int taskId)
	{
		return ConfigTravelTaskByTaskId.GetConfig(taskId, true);
	}

	// Token: 0x060088DD RID: 35037 RVA: 0x0024124F File Offset: 0x0023F44F
	public IReadOnlyList<TravelTask> GetAllTravelTaskConfig(int activityId)
	{
		return ConfigTravelTaskByActivityId.GetConfigList(activityId, true) ?? new TravelTask[0];
	}

	// Token: 0x060088DE RID: 35038 RVA: 0x00241262 File Offset: 0x0023F462
	public TravelTaskArea? GetAreaConfig(int id)
	{
		return ConfigTravelTaskAreaById.GetConfig(id, true);
	}

	// Token: 0x060088DF RID: 35039 RVA: 0x0024126B File Offset: 0x0023F46B
	public IReadOnlyList<TravelTaskArea> GetAllAreaConfig(int activityId)
	{
		return ConfigTravelTaskAreaByActivityId.GetConfigList(activityId, true) ?? new TravelTaskArea[0];
	}

	// Token: 0x060088E0 RID: 35040 RVA: 0x0024127E File Offset: 0x0023F47E
	public TravelPhantomQuest? GetQuestConfig(int id)
	{
		return ConfigTravelPhantomQuestById.GetConfig(id, true);
	}

	// Token: 0x060088E1 RID: 35041 RVA: 0x00241287 File Offset: 0x0023F487
	public TravelPhantomQuest? GetQuestConfigByMapMarkId(int markId)
	{
		return ConfigTravelPhantomQuestByMapMarkId.GetConfig(markId, true);
	}

	// Token: 0x060088E2 RID: 35042 RVA: 0x00241290 File Offset: 0x0023F490
	public IReadOnlyList<TravelPhantomQuest> GetAllQuestConfig(int activityId)
	{
		return ConfigTravelPhantomQuestByActivityId.GetConfigList(activityId, true) ?? new TravelPhantomQuest[0];
	}

	// Token: 0x060088E3 RID: 35043 RVA: 0x002412A3 File Offset: 0x0023F4A3
	public PhantomGain? GetPhantomConfig(int id)
	{
		return ConfigPhantomGainById.GetConfig(id, true);
	}

	// Token: 0x060088E4 RID: 35044 RVA: 0x002412AC File Offset: 0x0023F4AC
	public IReadOnlyList<PhantomGain> GetAllPhantomConfig(int activityId)
	{
		return ConfigPhantomGainByActivityId.GetConfigList(activityId, true) ?? new PhantomGain[0];
	}

	// Token: 0x060088E5 RID: 35045 RVA: 0x002412BF File Offset: 0x0023F4BF
	public IReadOnlyList<SoarChallenge> GetAllSoarChallengeConfig()
	{
		return ConfigSoarChallengeAll.GetConfigList(true) ?? new SoarChallenge[0];
	}

	// Token: 0x060088E6 RID: 35046 RVA: 0x002412D1 File Offset: 0x0023F4D1
	public SoarChallenge? GetSoarChallengeConfig(int id)
	{
		return ConfigSoarChallengeById.GetConfig(id, true);
	}
}
