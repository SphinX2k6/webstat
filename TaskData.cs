using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020012A6 RID: 4774
[NullableContext(1)]
[Nullable(0)]
public class TaskData
{
	// Token: 0x06007FF5 RID: 32757 RVA: 0x0021CC10 File Offset: 0x0021AE10
	public TaskData DeepCopy(TaskData origin)
	{
		return new TaskData
		{
			TaskId = origin.TaskId,
			Status = origin.Status,
			IsFinished = origin.IsFinished,
			IsTaken = origin.IsTaken,
			DoingTextId = origin.DoingTextId,
			JumpId = origin.JumpId,
			Current = origin.Current,
			Target = origin.Target,
			TitleTextId = origin.TitleTextId,
			RewardList = origin.RewardList,
			ReceiveDelegate = origin.ReceiveDelegate
		};
	}

	// Token: 0x04003D1A RID: 15642
	public int TaskId;

	// Token: 0x04003D1B RID: 15643
	public EActivityTaskState Status = EActivityTaskState.Active;

	// Token: 0x04003D1C RID: 15644
	public bool IsFinished;

	// Token: 0x04003D1D RID: 15645
	public bool IsTaken;

	// Token: 0x04003D1E RID: 15646
	public string DoingTextId = string.Empty;

	// Token: 0x04003D1F RID: 15647
	public int JumpId;

	// Token: 0x04003D20 RID: 15648
	public int Current;

	// Token: 0x04003D21 RID: 15649
	public int Target;

	// Token: 0x04003D22 RID: 15650
	public string TitleTextId = string.Empty;

	// Token: 0x04003D23 RID: 15651
	public List<TItem> RewardList = new List<TItem>();

	// Token: 0x04003D24 RID: 15652
	[Nullable(2)]
	public TaskReceive ReceiveDelegate;
}
