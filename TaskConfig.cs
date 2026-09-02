using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200141C RID: 5148
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class TaskConfig : ConfigBase<TaskConfig>
{
	// Token: 0x06008EBB RID: 36539 RVA: 0x00257BD9 File Offset: 0x00255DD9
	public IReadOnlyList<MainLine> GetAllMainLineTask()
	{
		return ConfigMainLineAll.GetConfigList(true);
	}

	// Token: 0x06008EBC RID: 36540 RVA: 0x00257BE1 File Offset: 0x00255DE1
	public MainLine? GetMainLineTaskById(int taskId)
	{
		return ConfigMainLineById.GetConfig(taskId, true);
	}

	// Token: 0x06008EBD RID: 36541 RVA: 0x00257BEA File Offset: 0x00255DEA
	public IReadOnlyList<BranchLine> GetAllBranchLineTask()
	{
		return ConfigBranchLineAll.GetConfigList(true);
	}

	// Token: 0x06008EBE RID: 36542 RVA: 0x00257BF2 File Offset: 0x00255DF2
	public BranchLine? GetBranchLineTaskById(int taskId)
	{
		return ConfigBranchLineById.GetConfig(taskId, true);
	}

	// Token: 0x06008EBF RID: 36543 RVA: 0x00257BFC File Offset: 0x00255DFC
	public BranchLine? GetBranchLineTaskByRealTaskId(int taskId)
	{
		IReadOnlyList<BranchLine> allBranchLineTask = this.GetAllBranchLineTask();
		for (int i = 0; i < allBranchLineTask.Count; i++)
		{
			BranchLine value = allBranchLineTask[i];
			if (value.TaskId == taskId)
			{
				return new BranchLine?(value);
			}
		}
		return null;
	}
}
