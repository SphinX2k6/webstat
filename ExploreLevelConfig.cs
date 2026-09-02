using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001B5E RID: 7006
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ExploreLevelConfig : ConfigBase<ExploreLevelConfig>
{
	// Token: 0x0600CAE1 RID: 51937 RVA: 0x0036187F File Offset: 0x0035FA7F
	public IReadOnlyList<ExploreReward> GetExploreRewardListByCountry(int countryId)
	{
		return ConfigExploreRewardByCountry.GetConfigList(countryId, true);
	}

	// Token: 0x0600CAE2 RID: 51938 RVA: 0x00361888 File Offset: 0x0035FA88
	public IReadOnlyList<ExploreScore> GetExploreScoreConfigList()
	{
		return ConfigExploreScoreAll.GetConfigList(true);
	}

	// Token: 0x0600CAE3 RID: 51939 RVA: 0x00361890 File Offset: 0x0035FA90
	public Dictionary<int, int> GetDropShowInfo(int dropId)
	{
		DropPackage? config = ConfigDropPackageById.GetConfig(dropId, true);
		if (config == null)
		{
			return null;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < config.Value.DropPreviewLength; i++)
		{
			DicIntInt? dicIntInt = config.Value.DropPreview(i);
			dictionary[dicIntInt.Value.Key] = dicIntInt.Value.Value;
		}
		return dictionary;
	}
}
