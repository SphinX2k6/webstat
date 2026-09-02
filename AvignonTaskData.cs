using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011CA RID: 4554
[NullableContext(1)]
[Nullable(0)]
public class AvignonTaskData
{
	// Token: 0x0600781A RID: 30746 RVA: 0x001F6E3F File Offset: 0x001F503F
	public AvignonTaskData(int taskId)
	{
		this.TaskId = taskId;
	}

	// Token: 0x17000A18 RID: 2584
	// (get) Token: 0x0600781B RID: 30747 RVA: 0x001F6E6B File Offset: 0x001F506B
	// (set) Token: 0x0600781C RID: 30748 RVA: 0x001F6E73 File Offset: 0x001F5073
	public int TaskId { get; set; }

	// Token: 0x17000A19 RID: 2585
	// (get) Token: 0x0600781D RID: 30749 RVA: 0x001F6E7C File Offset: 0x001F507C
	// (set) Token: 0x0600781E RID: 30750 RVA: 0x001F6E84 File Offset: 0x001F5084
	public EActivityTaskState Status { get; set; } = EActivityTaskState.Active;

	// Token: 0x17000A1A RID: 2586
	// (get) Token: 0x0600781F RID: 30751 RVA: 0x001F6E8D File Offset: 0x001F508D
	public bool IsFinished
	{
		get
		{
			return this.Status != EActivityTaskState.Active;
		}
	}

	// Token: 0x17000A1B RID: 2587
	// (get) Token: 0x06007820 RID: 30752 RVA: 0x001F6E9B File Offset: 0x001F509B
	public bool IsTaken
	{
		get
		{
			return this.Status == EActivityTaskState.FinishedAndClaimed;
		}
	}

	// Token: 0x17000A1C RID: 2588
	// (get) Token: 0x06007821 RID: 30753 RVA: 0x001F6EA6 File Offset: 0x001F50A6
	// (set) Token: 0x06007822 RID: 30754 RVA: 0x001F6EAE File Offset: 0x001F50AE
	public int Current { get; set; }

	// Token: 0x17000A1D RID: 2589
	// (get) Token: 0x06007823 RID: 30755 RVA: 0x001F6EB7 File Offset: 0x001F50B7
	// (set) Token: 0x06007824 RID: 30756 RVA: 0x001F6EBF File Offset: 0x001F50BF
	public int Target { get; set; }

	// Token: 0x17000A1E RID: 2590
	// (get) Token: 0x06007825 RID: 30757 RVA: 0x001F6EC8 File Offset: 0x001F50C8
	// (set) Token: 0x06007826 RID: 30758 RVA: 0x001F6ED0 File Offset: 0x001F50D0
	public int JumpId { get; set; }

	// Token: 0x17000A1F RID: 2591
	// (get) Token: 0x06007827 RID: 30759 RVA: 0x001F6ED9 File Offset: 0x001F50D9
	// (set) Token: 0x06007828 RID: 30760 RVA: 0x001F6EE1 File Offset: 0x001F50E1
	public string TitleTextId { get; set; } = "";

	// Token: 0x17000A20 RID: 2592
	// (get) Token: 0x06007829 RID: 30761 RVA: 0x001F6EEA File Offset: 0x001F50EA
	// (set) Token: 0x0600782A RID: 30762 RVA: 0x001F6EF2 File Offset: 0x001F50F2
	public List<TItem> RewardList { get; set; } = new List<TItem>();

	// Token: 0x04003A10 RID: 14864
	[Nullable(2)]
	public Action<int> ReceiveDelegate;
}
