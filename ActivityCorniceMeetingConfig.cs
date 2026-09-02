using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020012A8 RID: 4776
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityCorniceMeetingConfig : ConfigBase<ActivityCorniceMeetingConfig>
{
	// Token: 0x06007FFE RID: 32766 RVA: 0x0021CF79 File Offset: 0x0021B179
	public CorniceChallenge? GetCorniceMeetingChallengeConfig(int levelPlayId)
	{
		return ConfigCorniceChallengeById.GetConfig(levelPlayId, true);
	}

	// Token: 0x06007FFF RID: 32767 RVA: 0x0021CF82 File Offset: 0x0021B182
	public CorniceQuest? GetCorniceMeetingQuest(int levelPlayId)
	{
		return ConfigCorniceQuestById.GetConfig(levelPlayId, true);
	}

	// Token: 0x06008000 RID: 32768 RVA: 0x0021CF8B File Offset: 0x0021B18B
	public CorniceChallenge? GetCorniceMeetingChallengeByMarkId(int markId)
	{
		return ConfigCorniceChallengeByMarkId.GetConfig(markId, true);
	}
}
