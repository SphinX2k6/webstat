using System;
using System.Runtime.CompilerServices;

// Token: 0x020010FB RID: 4347
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerStageBase
{
	// Token: 0x06007132 RID: 28978 RVA: 0x001D983A File Offset: 0x001D7A3A
	public GuessJokerStageBase(GuessJokerStageFsm stageFsm)
	{
		this.StageFsm = stageFsm;
	}

	// Token: 0x06007133 RID: 28979 RVA: 0x001D9849 File Offset: 0x001D7A49
	public void Create()
	{
		this.OnCreate();
	}

	// Token: 0x06007134 RID: 28980 RVA: 0x001D9854 File Offset: 0x001D7A54
	public void Enter()
	{
		this.IsActive = true;
		this.OnEnter();
		this.OnAddEventListener();
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "Enter " + base.GetType().Name + " stage", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06007135 RID: 28981 RVA: 0x001D98A8 File Offset: 0x001D7AA8
	public void Tick(float deltaTime)
	{
		if (!this.IsActive)
		{
			return;
		}
		this.OnTick(deltaTime);
	}

	// Token: 0x06007136 RID: 28982 RVA: 0x001D98BC File Offset: 0x001D7ABC
	public void Exit()
	{
		this.OnRemoveEventListener();
		this.OnExit();
		this.IsActive = false;
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "Exit " + base.GetType().Name + " stage", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06007137 RID: 28983 RVA: 0x001D9910 File Offset: 0x001D7B10
	protected virtual void OnCreate()
	{
	}

	// Token: 0x06007138 RID: 28984 RVA: 0x001D9912 File Offset: 0x001D7B12
	protected virtual void OnEnter()
	{
	}

	// Token: 0x06007139 RID: 28985 RVA: 0x001D9914 File Offset: 0x001D7B14
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x0600713A RID: 28986 RVA: 0x001D9916 File Offset: 0x001D7B16
	protected virtual void OnTick(float deltaTime)
	{
	}

	// Token: 0x0600713B RID: 28987 RVA: 0x001D9918 File Offset: 0x001D7B18
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x0600713C RID: 28988 RVA: 0x001D991A File Offset: 0x001D7B1A
	protected virtual void OnExit()
	{
	}

	// Token: 0x04003672 RID: 13938
	protected bool IsActive;

	// Token: 0x04003673 RID: 13939
	protected GuessJokerStageFsm StageFsm;
}
