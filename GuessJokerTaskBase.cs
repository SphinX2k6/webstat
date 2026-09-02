using System;

// Token: 0x020010F8 RID: 4344
public class GuessJokerTaskBase
{
	// Token: 0x17000924 RID: 2340
	// (get) Token: 0x06007117 RID: 28951 RVA: 0x001D94F7 File Offset: 0x001D76F7
	public bool IsExecuting
	{
		get
		{
			return this.IsExecute;
		}
	}

	// Token: 0x17000925 RID: 2341
	// (get) Token: 0x06007118 RID: 28952 RVA: 0x001D94FF File Offset: 0x001D76FF
	public bool IsWaitingForPlayerInput
	{
		get
		{
			return this.TaskType == EGuessJokerTaskType.Interactive && this.IsExecuting;
		}
	}

	// Token: 0x06007119 RID: 28953 RVA: 0x001D9512 File Offset: 0x001D7712
	public GuessJokerTaskBase()
	{
		this.TaskId = GuessJokerTaskBase.SelfIncrementId++;
	}

	// Token: 0x0600711A RID: 28954 RVA: 0x001D952D File Offset: 0x001D772D
	public void Execute()
	{
		this.IsExecute = true;
		this.OnAddEventListener();
		this.OnExecute();
	}

	// Token: 0x0600711B RID: 28955 RVA: 0x001D9544 File Offset: 0x001D7744
	public void Tick(float deltaTime)
	{
		if (!this.IsExecute)
		{
			return;
		}
		if (this.IsWaitingForPlayerInput && this.FinishTime == 0f)
		{
			return;
		}
		if (this.FinishTime > 0f)
		{
			this.CurTime += deltaTime;
			if (this.CurTime >= this.FinishTime)
			{
				this.Complete();
				return;
			}
		}
		this.OnTick(deltaTime);
	}

	// Token: 0x0600711C RID: 28956 RVA: 0x001D95A7 File Offset: 0x001D77A7
	private void Complete()
	{
		if (!this.IsExecute)
		{
			return;
		}
		this.OnRemoveEventListener();
		this.OnComplete();
		this.IsFinishedInternal = true;
	}

	// Token: 0x0600711D RID: 28957 RVA: 0x001D95C5 File Offset: 0x001D77C5
	public void FinishTask()
	{
		this.Complete();
	}

	// Token: 0x0600711E RID: 28958 RVA: 0x001D95CD File Offset: 0x001D77CD
	public bool IsFinished()
	{
		return this.IsFinishedInternal;
	}

	// Token: 0x0600711F RID: 28959 RVA: 0x001D95D5 File Offset: 0x001D77D5
	public bool CanSendRequest()
	{
		return this.TaskType == EGuessJokerTaskType.Interactive && !this.IsRequestFinished;
	}

	// Token: 0x06007120 RID: 28960 RVA: 0x001D95EB File Offset: 0x001D77EB
	public void SetRequestFinished(bool isFinished)
	{
		if (this.TaskType == EGuessJokerTaskType.Interactive)
		{
			this.IsRequestFinished = isFinished;
		}
	}

	// Token: 0x06007121 RID: 28961 RVA: 0x001D95FD File Offset: 0x001D77FD
	protected virtual void OnExecute()
	{
	}

	// Token: 0x06007122 RID: 28962 RVA: 0x001D95FF File Offset: 0x001D77FF
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x06007123 RID: 28963 RVA: 0x001D9601 File Offset: 0x001D7801
	protected virtual void OnTick(float deltaTime)
	{
	}

	// Token: 0x06007124 RID: 28964 RVA: 0x001D9603 File Offset: 0x001D7803
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x06007125 RID: 28965 RVA: 0x001D9605 File Offset: 0x001D7805
	protected virtual void OnComplete()
	{
	}

	// Token: 0x04003665 RID: 13925
	public readonly int TaskId;

	// Token: 0x04003666 RID: 13926
	[StaticVariableRuleIgnore]
	private static int SelfIncrementId = 0;

	// Token: 0x04003667 RID: 13927
	private bool IsExecute;

	// Token: 0x04003668 RID: 13928
	private bool IsFinishedInternal;

	// Token: 0x04003669 RID: 13929
	protected float FinishTime;

	// Token: 0x0400366A RID: 13930
	private float CurTime;

	// Token: 0x0400366B RID: 13931
	protected EGuessJokerTaskType TaskType;

	// Token: 0x0400366C RID: 13932
	protected bool IsRequestFinished;
}
