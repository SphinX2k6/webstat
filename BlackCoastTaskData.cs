using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001269 RID: 4713
[NullableContext(1)]
[Nullable(0)]
public class BlackCoastTaskData
{
	// Token: 0x17000AB5 RID: 2741
	// (get) Token: 0x06007DB7 RID: 32183 RVA: 0x00212A33 File Offset: 0x00210C33
	// (set) Token: 0x06007DB8 RID: 32184 RVA: 0x00212A3B File Offset: 0x00210C3B
	public int TaskId { get; private set; }

	// Token: 0x06007DB9 RID: 32185 RVA: 0x00212A44 File Offset: 0x00210C44
	public BlackCoastTaskData(int taskId)
	{
		this.TaskId = taskId;
	}

	// Token: 0x17000AB6 RID: 2742
	// (get) Token: 0x06007DBA RID: 32186 RVA: 0x00212A70 File Offset: 0x00210C70
	public bool IsFinished
	{
		get
		{
			return this.Status != EActivityTaskState.Active;
		}
	}

	// Token: 0x17000AB7 RID: 2743
	// (get) Token: 0x06007DBB RID: 32187 RVA: 0x00212A7E File Offset: 0x00210C7E
	public bool IsTaken
	{
		get
		{
			return this.Status == EActivityTaskState.FinishedAndClaimed;
		}
	}

	// Token: 0x04003C55 RID: 15445
	public EActivityTaskState Status = EActivityTaskState.Active;

	// Token: 0x04003C56 RID: 15446
	public int Current;

	// Token: 0x04003C57 RID: 15447
	public int Target;

	// Token: 0x04003C58 RID: 15448
	public int JumpId;

	// Token: 0x04003C59 RID: 15449
	public int SortId;

	// Token: 0x04003C5A RID: 15450
	public string TitleTextId = "";

	// Token: 0x04003C5B RID: 15451
	public List<TItem> RewardList = new List<TItem>();

	// Token: 0x04003C5C RID: 15452
	[Nullable(2)]
	public Action<int> ReceiveDelegate;
}
