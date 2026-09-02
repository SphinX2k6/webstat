using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BA8 RID: 7080
public class FloroRanchAsyncActionBase : IStaticVariableResetter
{
	// Token: 0x0600CDE1 RID: 52705 RVA: 0x0036D8B3 File Offset: 0x0036BAB3
	static FloroRanchAsyncActionBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FloroRanchAsyncActionBase.CreateStaticDefaultValue), new Action(FloroRanchAsyncActionBase.ResetStaticDefaultValue));
	}

	// Token: 0x0600CDE2 RID: 52706 RVA: 0x0036D8D2 File Offset: 0x0036BAD2
	public FloroRanchAsyncActionBase()
	{
		this.ActionId = ++FloroRanchAsyncActionBase.SelfIncrementId;
	}

	// Token: 0x0600CDE3 RID: 52707 RVA: 0x0036D8ED File Offset: 0x0036BAED
	public static void CreateStaticDefaultValue()
	{
		FloroRanchAsyncActionBase.SelfIncrementId = 0;
	}

	// Token: 0x0600CDE4 RID: 52708 RVA: 0x0036D8F5 File Offset: 0x0036BAF5
	public static void ResetStaticDefaultValue()
	{
		FloroRanchAsyncActionBase.SelfIncrementId = 0;
	}

	// Token: 0x0600CDE5 RID: 52709 RVA: 0x0036D900 File Offset: 0x0036BB00
	public UniTask ExecuteAction()
	{
		FloroRanchAsyncActionBase.<ExecuteAction>d__8 <ExecuteAction>d__;
		<ExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteAction>d__.<>4__this = this;
		<ExecuteAction>d__.<>1__state = -1;
		<ExecuteAction>d__.<>t__builder.Start<FloroRanchAsyncActionBase.<ExecuteAction>d__8>(ref <ExecuteAction>d__);
		return <ExecuteAction>d__.<>t__builder.Task;
	}

	// Token: 0x0600CDE6 RID: 52710 RVA: 0x0036D943 File Offset: 0x0036BB43
	public virtual UniTask OnExecute()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600CDE7 RID: 52711 RVA: 0x0036D94C File Offset: 0x0036BB4C
	public void Pause()
	{
		if (this.ActionState == EFloroRanchActionState.Pause)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, base.GetType().Name + " action is already paused", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.PausePromise != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, base.GetType().Name + " PausePromise is already defined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanchGamePlay;
		ELogAuthor author = ELogAuthor.BB;
		string message = base.GetType().Name + " Pause";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionId", this.ActionId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.OnPause();
		this.ActionState = EFloroRanchActionState.Pause;
		this.PausePromise = new CustomPromise<UniTaskVoid>();
	}

	// Token: 0x0600CDE8 RID: 52712 RVA: 0x0036DA26 File Offset: 0x0036BC26
	protected virtual void OnPause()
	{
	}

	// Token: 0x0600CDE9 RID: 52713 RVA: 0x0036DA28 File Offset: 0x0036BC28
	public UniTask WaitIfPause()
	{
		FloroRanchAsyncActionBase.<WaitIfPause>d__12 <WaitIfPause>d__;
		<WaitIfPause>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitIfPause>d__.<>4__this = this;
		<WaitIfPause>d__.<>1__state = -1;
		<WaitIfPause>d__.<>t__builder.Start<FloroRanchAsyncActionBase.<WaitIfPause>d__12>(ref <WaitIfPause>d__);
		return <WaitIfPause>d__.<>t__builder.Task;
	}

	// Token: 0x0600CDEA RID: 52714 RVA: 0x0036DA6B File Offset: 0x0036BC6B
	public bool IsPause()
	{
		return this.ActionState == EFloroRanchActionState.Pause;
	}

	// Token: 0x0600CDEB RID: 52715 RVA: 0x0036DA76 File Offset: 0x0036BC76
	public bool IsExit()
	{
		return this.ActionState == EFloroRanchActionState.Exit;
	}

	// Token: 0x0600CDEC RID: 52716 RVA: 0x0036DA84 File Offset: 0x0036BC84
	public void Resume()
	{
		if (this.ActionState != EFloroRanchActionState.Pause)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = base.GetType().Name + " action is not paused";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionId", this.ActionId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.PausePromise == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, base.GetType().Name + " PausePromise is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.FloroRanchGamePlay;
		ELogAuthor author2 = ELogAuthor.BB;
		string message2 = base.GetType().Name + " Resume";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ActionId", this.ActionId);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		this.OnResume();
		this.ActionState = EFloroRanchActionState.Executing;
		this.PausePromise.SetResult(default(UniTaskVoid));
		this.PausePromise = null;
	}

	// Token: 0x0600CDED RID: 52717 RVA: 0x0036DB83 File Offset: 0x0036BD83
	protected virtual void OnResume()
	{
	}

	// Token: 0x0600CDEE RID: 52718 RVA: 0x0036DB88 File Offset: 0x0036BD88
	public void Exit()
	{
		this.OnExit();
		this.ActionState = EFloroRanchActionState.Exit;
		if (this.PausePromise != null)
		{
			this.PausePromise.SetResult(default(UniTaskVoid));
			this.PausePromise = null;
		}
	}

	// Token: 0x0600CDEF RID: 52719 RVA: 0x0036DBC5 File Offset: 0x0036BDC5
	protected virtual void OnExit()
	{
	}

	// Token: 0x0400624C RID: 25164
	protected EFloroRanchActionState ActionState;

	// Token: 0x0400624D RID: 25165
	[Nullable(2)]
	private CustomPromise<UniTaskVoid> PausePromise;

	// Token: 0x0400624E RID: 25166
	public readonly int ActionId;

	// Token: 0x0400624F RID: 25167
	private static int SelfIncrementId;
}
