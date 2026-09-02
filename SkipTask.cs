using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002A81 RID: 10881
public class SkipTask
{
	// Token: 0x06015C7D RID: 89213 RVA: 0x0060ADB1 File Offset: 0x00608FB1
	public void Initialize()
	{
		this.OnAddEvents();
		this.OnInitialize();
	}

	// Token: 0x06015C7E RID: 89214 RVA: 0x0060ADBF File Offset: 0x00608FBF
	public void Destroy()
	{
		this.Deactivate();
		this.OnDestroyed();
		this.OnRemoveEvents();
	}

	// Token: 0x06015C7F RID: 89215 RVA: 0x0060ADD4 File Offset: 0x00608FD4
	public void Run([Nullable(new byte[]
	{
		1,
		2
	})] params object[] data)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SkipInterface;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "开始跳转任务";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.Activate(data);
	}

	// Token: 0x06015C80 RID: 89216 RVA: 0x0060AE1C File Offset: 0x0060901C
	public UniTask<ESkipTaskFinishType> AsyncRun([Nullable(new byte[]
	{
		1,
		2
	})] params object[] data)
	{
		SkipTask.<AsyncRun>d__5 <AsyncRun>d__;
		<AsyncRun>d__.<>t__builder = AsyncUniTaskMethodBuilder<ESkipTaskFinishType>.Create();
		<AsyncRun>d__.<>4__this = this;
		<AsyncRun>d__.data = data;
		<AsyncRun>d__.<>1__state = -1;
		<AsyncRun>d__.<>t__builder.Start<SkipTask.<AsyncRun>d__5>(ref <AsyncRun>d__);
		return <AsyncRun>d__.<>t__builder.Task;
	}

	// Token: 0x06015C81 RID: 89217 RVA: 0x0060AE67 File Offset: 0x00609067
	public bool GetIsRunning()
	{
		return this.IsRunning;
	}

	// Token: 0x06015C82 RID: 89218 RVA: 0x0060AE70 File Offset: 0x00609070
	protected void Finish()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SkipInterface;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "结束跳转任务";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.CustomPromise != null)
		{
			this.CustomPromise.SetResult(ESkipTaskFinishType.Finish);
		}
		this.OnFinished();
		this.Deactivate();
	}

	// Token: 0x06015C83 RID: 89219 RVA: 0x0060AED4 File Offset: 0x006090D4
	public void Stop()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SkipInterface;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "停止跳转任务";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.CustomPromise != null)
		{
			this.CustomPromise.SetResult(ESkipTaskFinishType.Stop);
		}
		this.OnStopped();
		this.Deactivate();
	}

	// Token: 0x06015C84 RID: 89220 RVA: 0x0060AF35 File Offset: 0x00609135
	private void Activate([Nullable(new byte[]
	{
		1,
		2
	})] params object[] data)
	{
		this.IsRunning = true;
		this.OnRun(data);
	}

	// Token: 0x06015C85 RID: 89221 RVA: 0x0060AF45 File Offset: 0x00609145
	private void Deactivate()
	{
		this.IsRunning = false;
		this.CustomPromise = null;
	}

	// Token: 0x06015C86 RID: 89222 RVA: 0x0060AF55 File Offset: 0x00609155
	protected virtual void OnInitialize()
	{
	}

	// Token: 0x06015C87 RID: 89223 RVA: 0x0060AF57 File Offset: 0x00609157
	protected virtual void OnRun([Nullable(new byte[]
	{
		1,
		2
	})] params object[] data)
	{
	}

	// Token: 0x06015C88 RID: 89224 RVA: 0x0060AF59 File Offset: 0x00609159
	protected virtual void OnFinished()
	{
	}

	// Token: 0x06015C89 RID: 89225 RVA: 0x0060AF5B File Offset: 0x0060915B
	protected virtual void OnStopped()
	{
	}

	// Token: 0x06015C8A RID: 89226 RVA: 0x0060AF5D File Offset: 0x0060915D
	protected virtual void OnDestroyed()
	{
	}

	// Token: 0x06015C8B RID: 89227 RVA: 0x0060AF5F File Offset: 0x0060915F
	protected virtual void OnAddEvents()
	{
	}

	// Token: 0x06015C8C RID: 89228 RVA: 0x0060AF61 File Offset: 0x00609161
	protected virtual void OnRemoveEvents()
	{
	}

	// Token: 0x0400A739 RID: 42809
	private bool IsRunning;

	// Token: 0x0400A73A RID: 42810
	[Nullable(2)]
	private CustomPromise<ESkipTaskFinishType> CustomPromise;
}
