using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001451 RID: 5201
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityNewcomerJourneyConfig : ConfigBase<ActivityNewcomerJourneyConfig>
{
	// Token: 0x060090E5 RID: 37093 RVA: 0x00261CE4 File Offset: 0x0025FEE4
	public AdventureTaskChapterV2? GetChapterById(int chapterId)
	{
		return ConfigAdventureTaskChapterV2ById.GetConfig(chapterId, true);
	}

	// Token: 0x060090E6 RID: 37094 RVA: 0x00261CED File Offset: 0x0025FEED
	public AdventureRole? GetRoleById(int id)
	{
		return ConfigAdventureRoleById.GetConfig(id, true);
	}

	// Token: 0x060090E7 RID: 37095 RVA: 0x00261CF6 File Offset: 0x0025FEF6
	public AdventureTaskV2? GetTaskById(int taskId)
	{
		return ConfigAdventureTaskV2ById.GetConfig(taskId, true);
	}
}
