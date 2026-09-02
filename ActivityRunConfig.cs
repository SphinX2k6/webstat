using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001584 RID: 5508
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityRunConfig : ConfigBase<ActivityRunConfig>
{
	// Token: 0x06009AC0 RID: 39616 RVA: 0x0028898C File Offset: 0x00286B8C
	public ParkourChallenge GetActivityRunChallengeConfig(int id)
	{
		return ConfigParkourChallengeById.GetConfig(id, true).Value;
	}

	// Token: 0x06009AC1 RID: 39617 RVA: 0x002889A8 File Offset: 0x00286BA8
	public string GetActivityRunTitle(int id)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetActivityRunChallengeConfig(id).Title, null) ?? "";
	}

	// Token: 0x06009AC2 RID: 39618 RVA: 0x002889D4 File Offset: 0x00286BD4
	[return: Nullable(new byte[]
	{
		1,
		0
	})]
	public Dictionary<int, ValueTuple<int, int>> GetActivityRunScoreMap(int id)
	{
		ParkourChallenge activityRunChallengeConfig = this.GetActivityRunChallengeConfig(id);
		Dictionary<int, ValueTuple<int, int>> dictionary = new Dictionary<int, ValueTuple<int, int>>();
		int num = 0;
		if (activityRunChallengeConfig.RewardListLength != 0)
		{
			for (int i = 0; i < activityRunChallengeConfig.RewardListLength; i++)
			{
				IntPair value = activityRunChallengeConfig.RewardList(i).Value;
				int item = value.Item1;
				int item2 = value.Item2;
				dictionary.Add(num, new ValueTuple<int, int>(item, item2));
				num++;
			}
		}
		return dictionary;
	}

	// Token: 0x06009AC3 RID: 39619 RVA: 0x00288A48 File Offset: 0x00286C48
	public int GetActivityRunMarkId(int id)
	{
		return this.GetActivityRunChallengeConfig(id).MarkId;
	}

	// Token: 0x06009AC4 RID: 39620 RVA: 0x00288A64 File Offset: 0x00286C64
	public string GetActivityRunTexture(int id)
	{
		return this.GetActivityRunChallengeConfig(id).BackGroundTexture;
	}
}
