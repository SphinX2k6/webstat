using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001173 RID: 4467
[NullableContext(1)]
[Nullable(0)]
public class ActivityTaskData
{
	// Token: 0x06007591 RID: 30097 RVA: 0x001ED0B0 File Offset: 0x001EB2B0
	public void Refresh(ConditionTask task, TChangeCallback statusChangeCallback = null)
	{
		this.Id = task.Id;
		this.Current = task.Current;
		this.Target = task.Target;
		EActivityTaskState status = this.Status;
		this.Status = TaskStateResolver.ConditionState[task.Status];
		if (statusChangeCallback != null)
		{
			statusChangeCallback(status != this.Status, status, this.Status);
		}
	}

	// Token: 0x06007592 RID: 30098 RVA: 0x001ED11C File Offset: 0x001EB31C
	public void Refresh(ActivityTask task, TChangeCallback statusChangeCallback = null)
	{
		this.Id = task.Id;
		this.Current = task.Current;
		this.Target = task.Target;
		EActivityTaskState status = this.Status;
		this.Status = TaskStateResolver.TaskState[task.Status];
		if (statusChangeCallback != null)
		{
			statusChangeCallback(status != this.Status, status, this.Status);
		}
	}

	// Token: 0x040038FE RID: 14590
	public int Id;

	// Token: 0x040038FF RID: 14591
	public int TypeId;

	// Token: 0x04003900 RID: 14592
	public int Current;

	// Token: 0x04003901 RID: 14593
	public int Target = 1;

	// Token: 0x04003902 RID: 14594
	public EActivityTaskState Status = EActivityTaskState.Active;
}
