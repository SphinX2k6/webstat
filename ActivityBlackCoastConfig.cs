using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001263 RID: 4707
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityBlackCoastConfig : ConfigBase<ActivityBlackCoastConfig>
{
	// Token: 0x06007D6F RID: 32111 RVA: 0x00211A0E File Offset: 0x0020FC0E
	public BlackCoastThemeConfig? GetActivityConfig(int activityId)
	{
		return ConfigBlackCoastThemeConfigByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x06007D70 RID: 32112 RVA: 0x00211A17 File Offset: 0x0020FC17
	public BlackCoastThemeStageRe? GetStageConfig(int stageId)
	{
		return ConfigBlackCoastThemeStageReById.GetConfig(stageId, true);
	}

	// Token: 0x06007D71 RID: 32113 RVA: 0x00211A20 File Offset: 0x0020FC20
	public IReadOnlyList<BlackCoastThemeStageRe> GetAllStageConfigByActivityId(int activityId)
	{
		return ConfigBlackCoastThemeStageReByActivityId.GetConfigList(activityId, true) ?? Array.Empty<BlackCoastThemeStageRe>();
	}

	// Token: 0x06007D72 RID: 32114 RVA: 0x00211A32 File Offset: 0x0020FC32
	public BlackCoastThemeTaskRe? GetTaskConfig(int taskId)
	{
		return ConfigBlackCoastThemeTaskReByTaskId.GetConfig(taskId, true);
	}

	// Token: 0x06007D73 RID: 32115 RVA: 0x00211A3B File Offset: 0x0020FC3B
	public IReadOnlyList<BlackCoastThemeTaskRe> GetAllTaskConfigByStageId(int stageId)
	{
		return ConfigBlackCoastThemeTaskReByStageId.GetConfigList(stageId, true) ?? Array.Empty<BlackCoastThemeTaskRe>();
	}

	// Token: 0x06007D74 RID: 32116 RVA: 0x00211A4D File Offset: 0x0020FC4D
	public BlackCoastThemeRewardRe? GetRewardConfig(int id)
	{
		return ConfigBlackCoastThemeRewardReById.GetConfig(id, true);
	}

	// Token: 0x06007D75 RID: 32117 RVA: 0x00211A56 File Offset: 0x0020FC56
	public IReadOnlyList<BlackCoastThemeRewardRe> GetAllRewardConfigByActivityId(int activityId)
	{
		return ConfigBlackCoastThemeRewardReByActivityId.GetConfigList(activityId, true) ?? Array.Empty<BlackCoastThemeRewardRe>();
	}
}
