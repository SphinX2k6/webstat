using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C0E RID: 7182
public class FloroRanchDailyTaskBase : IStaticVariableResetter
{
	// Token: 0x0600D112 RID: 53522 RVA: 0x00378733 File Offset: 0x00376933
	static FloroRanchDailyTaskBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FloroRanchDailyTaskBase.CreateStaticDefaultValue), new Action(FloroRanchDailyTaskBase.ResetStaticDefaultValue));
	}

	// Token: 0x1700110C RID: 4364
	// (get) Token: 0x0600D113 RID: 53523 RVA: 0x00378752 File Offset: 0x00376952
	public bool IsExecuting
	{
		get
		{
			return this.IsExecute;
		}
	}

	// Token: 0x1700110D RID: 4365
	// (get) Token: 0x0600D114 RID: 53524 RVA: 0x0037875A File Offset: 0x0037695A
	public bool IsPause
	{
		get
		{
			return this.IsPauseInternal;
		}
	}

	// Token: 0x0600D115 RID: 53525 RVA: 0x00378762 File Offset: 0x00376962
	public static void CreateStaticDefaultValue()
	{
		FloroRanchDailyTaskBase.SelfIncrementId = 0;
	}

	// Token: 0x0600D116 RID: 53526 RVA: 0x0037876A File Offset: 0x0037696A
	public static void ResetStaticDefaultValue()
	{
		FloroRanchDailyTaskBase.SelfIncrementId = 0;
	}

	// Token: 0x0600D117 RID: 53527 RVA: 0x00378772 File Offset: 0x00376972
	public FloroRanchDailyTaskBase()
	{
		this.TaskId = FloroRanchDailyTaskBase.SelfIncrementId++;
	}

	// Token: 0x0600D118 RID: 53528 RVA: 0x0037878D File Offset: 0x0037698D
	public void BindCompleteCallBack([Nullable(new byte[]
	{
		1,
		2
	})] Action<int, Action> completeCallBack)
	{
		this.CompleteCallBack = completeCallBack;
	}

	// Token: 0x0600D119 RID: 53529 RVA: 0x00378796 File Offset: 0x00376996
	public void Execute()
	{
		this.IsExecute = true;
		this.OnAddEventListener();
		this.OnExecute();
	}

	// Token: 0x0600D11A RID: 53530 RVA: 0x003787AB File Offset: 0x003769AB
	public void Tick(float deltaTime)
	{
		if (!this.IsExecute)
		{
			return;
		}
		this.OnTick(deltaTime);
	}

	// Token: 0x0600D11B RID: 53531 RVA: 0x003787BD File Offset: 0x003769BD
	[NullableContext(2)]
	public void Complete(Action preExcuteNextCallback = null)
	{
		if (!this.IsExecute)
		{
			return;
		}
		this.IsExecute = false;
		this.OnRemoveEventListener();
		this.OnComplete();
		this.CompleteCallBack(this.TaskId, preExcuteNextCallback);
	}

	// Token: 0x0600D11C RID: 53532 RVA: 0x003787ED File Offset: 0x003769ED
	[NullableContext(2)]
	public void AsyncComplete(Action preExcuteNextCallback = null)
	{
		this.IsDataCompleteInternal = true;
		if (this.IsExecute && !this.IsPauseInternal)
		{
			this.Complete(preExcuteNextCallback);
		}
	}

	// Token: 0x0600D11D RID: 53533 RVA: 0x0037880D File Offset: 0x00376A0D
	public void ForceFinish()
	{
		if (!this.IsExecute)
		{
			return;
		}
		this.IsExecute = false;
		this.OnRemoveEventListener();
	}

	// Token: 0x0600D11E RID: 53534 RVA: 0x00378825 File Offset: 0x00376A25
	private bool CanComplete()
	{
		return this.IsExecute && !this.IsPauseInternal && this.IsDataCompleteInternal;
	}

	// Token: 0x0600D11F RID: 53535 RVA: 0x00378840 File Offset: 0x00376A40
	public void Pause()
	{
		if (!this.IsExecute)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "Pause 任务未执行 只能暂停正在执行的任务！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskId", this.TaskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.IsExecute = false;
		this.IsPauseInternal = true;
	}

	// Token: 0x0600D120 RID: 53536 RVA: 0x00378898 File Offset: 0x00376A98
	public void Resume()
	{
		if (!this.IsPauseInternal)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "Resume 任务未暂停 不能恢复！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskId", this.TaskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.IsExecute = true;
		this.IsPauseInternal = false;
		if (this.CanComplete())
		{
			this.Complete(null);
		}
	}

	// Token: 0x0600D121 RID: 53537 RVA: 0x003788FF File Offset: 0x00376AFF
	protected virtual void OnExecute()
	{
	}

	// Token: 0x0600D122 RID: 53538 RVA: 0x00378901 File Offset: 0x00376B01
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x0600D123 RID: 53539 RVA: 0x00378903 File Offset: 0x00376B03
	protected virtual void OnTick(float deltaTime)
	{
	}

	// Token: 0x0600D124 RID: 53540 RVA: 0x00378905 File Offset: 0x00376B05
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x0600D125 RID: 53541 RVA: 0x00378907 File Offset: 0x00376B07
	protected virtual void OnComplete()
	{
	}

	// Token: 0x040063D7 RID: 25559
	public readonly int TaskId;

	// Token: 0x040063D8 RID: 25560
	private static int SelfIncrementId;

	// Token: 0x040063D9 RID: 25561
	private bool IsExecute;

	// Token: 0x040063DA RID: 25562
	private bool IsPauseInternal;

	// Token: 0x040063DB RID: 25563
	private bool IsDataCompleteInternal;

	// Token: 0x040063DC RID: 25564
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private Action<int, Action> CompleteCallBack;
}
