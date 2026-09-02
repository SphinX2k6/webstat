using System;

// Token: 0x02001720 RID: 5920
public class WuWuTaskData
{
	// Token: 0x17000DA1 RID: 3489
	// (get) Token: 0x0600A493 RID: 42131 RVA: 0x002B863D File Offset: 0x002B683D
	public float ProgressPercent
	{
		get
		{
			if (this.TargetProgress <= 0)
			{
				return 0f;
			}
			return Math.Min((float)this.Progress / (float)this.TargetProgress, 1f);
		}
	}

	// Token: 0x17000DA2 RID: 3490
	// (get) Token: 0x0600A494 RID: 42132 RVA: 0x002B8667 File Offset: 0x002B6867
	public bool IsCompleted
	{
		get
		{
			return this.Progress >= this.TargetProgress;
		}
	}

	// Token: 0x17000DA3 RID: 3491
	// (get) Token: 0x0600A495 RID: 42133 RVA: 0x002B867A File Offset: 0x002B687A
	public bool CanReceiveReward
	{
		get
		{
			return this.State == EWuWuTaskState.Finish;
		}
	}

	// Token: 0x17000DA4 RID: 3492
	// (get) Token: 0x0600A496 RID: 42134 RVA: 0x002B8685 File Offset: 0x002B6885
	public bool IsRewarded
	{
		get
		{
			return this.State == EWuWuTaskState.Taken;
		}
	}

	// Token: 0x04004E3B RID: 20027
	public int TaskId;

	// Token: 0x04004E3C RID: 20028
	public int TaskPackId;

	// Token: 0x04004E3D RID: 20029
	public int Progress;

	// Token: 0x04004E3E RID: 20030
	public int TargetProgress;

	// Token: 0x04004E3F RID: 20031
	public EWuWuTaskState State;
}
