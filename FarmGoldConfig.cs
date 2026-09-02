using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200131A RID: 4890
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FarmGoldConfig : ConfigBase<FarmGoldConfig>
{
	// Token: 0x0600851C RID: 34076 RVA: 0x00231198 File Offset: 0x0022F398
	public FarmGoldMapMark GetFarmGoldMarkByActivityId(int id)
	{
		return ConfigFarmGoldMapMarkByActivityId.GetConfig(id, true).Value;
	}

	// Token: 0x0600851D RID: 34077 RVA: 0x002311B4 File Offset: 0x0022F3B4
	public IReadOnlyList<FarmGoldActivity> GetAllFarmGoldActivity()
	{
		return ConfigFarmGoldActivityAll.GetConfigList(true) ?? new List<FarmGoldActivity>();
	}

	// Token: 0x0600851E RID: 34078 RVA: 0x002311C5 File Offset: 0x0022F3C5
	public FarmGoldActivity GetFarmGoldConfigByActivityIdAndInstId(int activityId, int instId)
	{
		return ConfigFarmGoldActivityByActivityIdAndInstanceId.GetConfigList(activityId, instId, true)[0];
	}

	// Token: 0x0600851F RID: 34079 RVA: 0x002311D5 File Offset: 0x0022F3D5
	public FarmGoldScore? GetScoreConfigById(int id)
	{
		return ConfigFarmGoldScoreById.GetConfig(id, true);
	}

	// Token: 0x06008520 RID: 34080 RVA: 0x002311DE File Offset: 0x0022F3DE
	public IReadOnlyList<FarmGoldScore> GetScoreConfigByActivityId(int activityId)
	{
		return ConfigFarmGoldScoreByActivityId.GetConfigList(activityId, true);
	}

	// Token: 0x06008521 RID: 34081 RVA: 0x002311E7 File Offset: 0x0022F3E7
	public IReadOnlyList<FarmGoldDifficulty> GetFarmGoldAllDifficult()
	{
		return ConfigFarmGoldDifficultyAll.GetConfigList(true) ?? new List<FarmGoldDifficulty>();
	}

	// Token: 0x06008522 RID: 34082 RVA: 0x002311F8 File Offset: 0x0022F3F8
	public FarmGoldDifficulty GetFarmGoldDifficultById(int id)
	{
		return ConfigFarmGoldDifficultyById.GetConfig(id, true).Value;
	}

	// Token: 0x06008523 RID: 34083 RVA: 0x00231214 File Offset: 0x0022F414
	public string GetFarmGoldEntranceName()
	{
		return ConfigCommonParamById.GetStringConfig("FarmGoldEntranceName") ?? "";
	}

	// Token: 0x06008524 RID: 34084 RVA: 0x00231229 File Offset: 0x0022F429
	public string GetFarmGoldEntranceSpritePath()
	{
		return ConfigCommonParamById.GetStringConfig("FarmGoldEntranceSpritePath") ?? "";
	}

	// Token: 0x06008525 RID: 34085 RVA: 0x00231240 File Offset: 0x0022F440
	public int GetFarmGoldEntranceHelpId()
	{
		return ConfigCommonParamById.GetIntConfig("FarmGoldEntranceHelpId").GetValueOrDefault();
	}
}
