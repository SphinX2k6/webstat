using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001B6A RID: 7018
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ExploreProgressConfig : ConfigBase<ExploreProgressConfig>
{
	// Token: 0x0600CBCB RID: 52171 RVA: 0x0036625B File Offset: 0x0036445B
	public ExploreProgress? GetExploreProgressConfigById(int id)
	{
		return ConfigExploreProgressById.GetConfig(id, true);
	}

	// Token: 0x0600CBCC RID: 52172 RVA: 0x00366264 File Offset: 0x00364464
	public IReadOnlyList<ExploreProgress> GetExploreProgressConfigListByArea(int areaId)
	{
		return ConfigExploreProgressByArea.GetConfigList(areaId, true);
	}

	// Token: 0x0600CBCD RID: 52173 RVA: 0x0036626D File Offset: 0x0036446D
	public IReadOnlyList<ExploreProgress> GetAllExploreProgressConfig()
	{
		return ConfigExploreProgressAll.GetConfigList(true);
	}

	// Token: 0x0600CBCE RID: 52174 RVA: 0x00366275 File Offset: 0x00364475
	public IReadOnlyList<AreaTaskExplore> GetAreaMissionConfigByAreaId(int areaId)
	{
		return ConfigAreaTaskExploreByAreaId.GetConfigList(areaId, true);
	}

	// Token: 0x0600CBCF RID: 52175 RVA: 0x0036627E File Offset: 0x0036447E
	public State? GetStateConfigByStateId(int stateId)
	{
		return ConfigStateByStateId.GetConfig(stateId, true);
	}

	// Token: 0x0600CBD0 RID: 52176 RVA: 0x00366287 File Offset: 0x00364487
	public IReadOnlyList<ExploreProgressReward> GetAreaStageAwardConfigByAreaId(int areaId)
	{
		return ConfigExploreProgressRewardByArea.GetConfigList(areaId, true);
	}

	// Token: 0x0600CBD1 RID: 52177 RVA: 0x00366290 File Offset: 0x00364490
	public IReadOnlyList<ExploreProgressReward> GetAreaStageRewardConfigList()
	{
		return ConfigExploreProgressRewardAll.GetConfigList(true);
	}

	// Token: 0x0600CBD2 RID: 52178 RVA: 0x00366298 File Offset: 0x00364498
	public ExploreType? GetExploreTypeByType(int type)
	{
		return ConfigExploreTypeByType.GetConfig(type, true);
	}
}
