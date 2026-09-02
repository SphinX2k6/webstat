using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020011C4 RID: 4548
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class AvignonConfig : ConfigBase<AvignonConfig>
{
	// Token: 0x060077DC RID: 30684 RVA: 0x001F6238 File Offset: 0x001F4438
	public IReadOnlyList<AvignonStage> GetStageConfigAll()
	{
		return ConfigAvignonStageAll.GetConfigList(true) ?? new AvignonStage[0];
	}

	// Token: 0x060077DD RID: 30685 RVA: 0x001F624A File Offset: 0x001F444A
	public AvignonStage? GetStageConfigById(int stageId)
	{
		return ConfigAvignonStageById.GetConfig(stageId, true);
	}

	// Token: 0x060077DE RID: 30686 RVA: 0x001F6253 File Offset: 0x001F4453
	public IReadOnlyList<AvignonTask> GetAvignonTaskConfigByStageId(int stageId)
	{
		return ConfigAvignonTaskByStageId.GetConfigList(stageId, true);
	}

	// Token: 0x060077DF RID: 30687 RVA: 0x001F625C File Offset: 0x001F445C
	public AvignonTask? GetAvignonTaskConfigByTaskId(int taskId)
	{
		return ConfigAvignonTaskByTaskId.GetConfig(taskId, true);
	}
}
