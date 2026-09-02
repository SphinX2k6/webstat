using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001348 RID: 4936
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LifePointDrawConfig : ConfigBase<LifePointDrawConfig>
{
	// Token: 0x060086E3 RID: 34531 RVA: 0x002383A8 File Offset: 0x002365A8
	public LifePointEntrance? GetLifePointEntranceById(int id)
	{
		return ConfigLifePointEntranceById.GetConfig(id, true);
	}

	// Token: 0x060086E4 RID: 34532 RVA: 0x002383B1 File Offset: 0x002365B1
	public LifePointGroup? GetLifePointGroupByGroupId(int groupId)
	{
		return ConfigLifePointGroupByGroupId.GetConfig(groupId, true);
	}

	// Token: 0x060086E5 RID: 34533 RVA: 0x002383BA File Offset: 0x002365BA
	public LifePointChallenge? GetLifePointChallengeById(int id)
	{
		return ConfigLifePointChallengeById.GetConfig(id, true);
	}

	// Token: 0x060086E6 RID: 34534 RVA: 0x002383C3 File Offset: 0x002365C3
	public LifePointActivity? GetLifePointDrawActivityById(int id)
	{
		return ConfigLifePointActivityByActivityId.GetConfig(id, true);
	}
}
