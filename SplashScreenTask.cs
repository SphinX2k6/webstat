using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002A97 RID: 10903
[NullableContext(1)]
[Nullable(0)]
public class SplashScreenTask
{
	// Token: 0x17001C5B RID: 7259
	// (get) Token: 0x06015D13 RID: 89363 RVA: 0x0060CCF7 File Offset: 0x0060AEF7
	public ESplashScreenTaskStatus Status
	{
		get
		{
			return this.StatusInternal;
		}
	}

	// Token: 0x06015D14 RID: 89364 RVA: 0x0060CD00 File Offset: 0x0060AF00
	public SplashScreenTask(ESplashScreenSourceModuleType sourceModule, ESplashScreenType type, Action runHandle)
	{
		this.SourceModule = sourceModule;
		this.Type = type;
		this.RunHandle = runHandle;
		if (this.Type == ESplashScreenType.Config)
		{
			SplashScreen value = ConfigSplashScreenById.GetConfig((int)this.SourceModule, true).Value;
			this.SplashScreenTimeType = (ESplashScreenTimeType)value.Type;
			this.NeedInLongQueue = (this.SplashScreenTimeType == ESplashScreenTimeType.Long && value.InLongTaskQueue);
		}
	}

	// Token: 0x06015D15 RID: 89365 RVA: 0x0060CD6C File Offset: 0x0060AF6C
	public unsafe void Run()
	{
		if (this.StatusInternal != ESplashScreenTaskStatus.Pending)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SplashScreenTask;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "[SplashScreenTask] 任务被重复执行";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskSourceModule", this.SourceModule);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Status", this.Status);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		try
		{
			this.StatusInternal = ESplashScreenTaskStatus.Running;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SplashScreenTask;
			ELogAuthor author2 = ELogAuthor.CXJ;
			string message2 = "[SplashScreenTask] 任务开始执行";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskSourceModule", this.SourceModule);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			SplashScreenLogEvent splashScreenLogEvent = new SplashScreenLogEvent();
			splashScreenLogEvent.i_id = (int)this.SourceModule;
			ControllerBase<LogReportController>.Instance.LogReport(splashScreenLogEvent);
			this.RunHandle();
		}
		catch (Exception ex)
		{
			this.StatusInternal = ESplashScreenTaskStatus.Failed;
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.SplashScreenTask;
			ELogAuthor author3 = ELogAuthor.CXJ;
			string message3 = "[SplashScreenTask] 任务执行异常";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TaskSourceModule", this.SourceModule);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("error", ex.Message);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
	}

	// Token: 0x06015D16 RID: 89366 RVA: 0x0060CED4 File Offset: 0x0060B0D4
	public void FinishTask()
	{
		this.StatusInternal = ESplashScreenTaskStatus.Completed;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SplashScreenTask;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "[SplashScreenTask] 任务完成";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskSourceModule", this.SourceModule);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015D17 RID: 89367 RVA: 0x0060CF1C File Offset: 0x0060B11C
	public void CancelTask()
	{
		this.StatusInternal = ESplashScreenTaskStatus.Canceled;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SplashScreenTask;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "[SplashScreenTask] 任务取消";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskSourceModule", this.SourceModule);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015D18 RID: 89368 RVA: 0x0060CF64 File Offset: 0x0060B164
	public void FailTask()
	{
		this.StatusInternal = ESplashScreenTaskStatus.Failed;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SplashScreenTask;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "[SplashScreenTask] 任务失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TaskSourceModule", this.SourceModule);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0400A76F RID: 42863
	private ESplashScreenTaskStatus StatusInternal;

	// Token: 0x0400A770 RID: 42864
	public ESplashScreenTimeType SplashScreenTimeType;

	// Token: 0x0400A771 RID: 42865
	public bool NeedInLongQueue;

	// Token: 0x0400A772 RID: 42866
	private readonly Action RunHandle;

	// Token: 0x0400A773 RID: 42867
	public readonly ESplashScreenSourceModuleType SourceModule;

	// Token: 0x0400A774 RID: 42868
	public readonly ESplashScreenType Type;
}
