using System;

// Token: 0x0200141A RID: 5146
public class MoonChasingTaskViewData
{
	// Token: 0x06008EB1 RID: 36529 RVA: 0x00257A10 File Offset: 0x00255C10
	public MoonChasingTaskViewData(EMoonChasingTaskType taskType, int taskId, bool isLastTask)
	{
		this.TaskType = taskType;
		this.TargetTaskId = taskId;
		this.IsLastTask = isLastTask;
	}

	// Token: 0x04004271 RID: 17009
	public EMoonChasingTaskType TaskType = EMoonChasingTaskType.MainLine;

	// Token: 0x04004272 RID: 17010
	public int TargetTaskId;

	// Token: 0x04004273 RID: 17011
	public bool IsLastTask;
}
