using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;

// Token: 0x020031D7 RID: 12759
[NullableContext(2)]
[Nullable(0)]
public class NpcPerformMonsterNearbyState : NpcPerformBaseState
{
	// Token: 0x0601A727 RID: 108327 RVA: 0x007CDB95 File Offset: 0x007CBD95
	[NullableContext(1)]
	public NpcPerformMonsterNearbyState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x0601A728 RID: 108328 RVA: 0x007CDBA0 File Offset: 0x007CBDA0
	public override bool CanChangeFrom(ENpcPerformState fromState)
	{
		CommonNpcPerformComponent component = this.Owner.Entity.GetComponent<CommonNpcPerformComponent>();
		return this.HaveConfig && fromState == ENpcPerformState.Idle && !component.IsInPlot;
	}

	// Token: 0x0601A729 RID: 108329 RVA: 0x007CDBD8 File Offset: 0x007CBDD8
	protected override void OnCreate(IEntityArgs args = null)
	{
		base.OnCreate(args);
		Aki.TDConfigMgr.Component.NpcPerformComponent p = args.GetP1<Aki.TDConfigMgr.Component.NpcPerformComponent>();
		if (((p != null) ? p.NpcMonsterClosePerform : null) == null)
		{
			this.HaveConfig = false;
			return;
		}
		this.HaveConfig = true;
		this.MontageInfo = p.NpcMonsterClosePerform.Montage;
		this.BubbleRate = (float)p.NpcMonsterClosePerform.BubbleRate;
		this.FlowConfig = p.NpcMonsterClosePerform.Bubble;
	}

	// Token: 0x0601A72A RID: 108330 RVA: 0x007CDC44 File Offset: 0x007CBE44
	protected override void OnEnter(ENpcPerformState? lastState)
	{
		this.LastState = lastState;
		CommonNpcPerformComponent component = this.Owner.Entity.GetComponent<CommonNpcPerformComponent>();
		if (component != null && component.HasBrain)
		{
			BaseMoveComponent component2 = this.Owner.Entity.GetComponent<BaseMoveComponent>();
			if (component2 != null)
			{
				component2.StopMove(false, null);
			}
		}
		string montagePath = (component != null) ? component.GetMontagePath(this.MontageInfo) : null;
		base.PlayMontage(new IPlayMontageParam
		{
			MontagePath = montagePath,
			IsLoop = new bool?(true)
		});
		if (this.PlayingMontageId < 0)
		{
			TimerSystem.Instance.Delay(delegate(float delta)
			{
				this.StateMachine.Switch(this.LastState.Value);
			}, 3000f, null, null, true, 1f);
		}
		NpcPerceptionReactionUtil.ShowHeadDialog(this.Owner.Entity, this.BubbleRate, this.FlowConfig);
	}

	// Token: 0x0601A72B RID: 108331 RVA: 0x007CDD0E File Offset: 0x007CBF0E
	protected override void OnExit(ENpcPerformState nextState)
	{
		base.StopMontage(new IStopMontageParam
		{
			Method = new EStopMethod?(EStopMethod.BlendOut)
		});
	}

	// Token: 0x0601A72C RID: 108332 RVA: 0x007CDD27 File Offset: 0x007CBF27
	protected override void OnDestroy()
	{
	}

	// Token: 0x0400D5AC RID: 54700
	private const int BUBBLE_TIME = 3;

	// Token: 0x0400D5AD RID: 54701
	private readonly int PlayingMontageId;

	// Token: 0x0400D5AE RID: 54702
	private bool HaveConfig;

	// Token: 0x0400D5AF RID: 54703
	private IMontageId MontageInfo;

	// Token: 0x0400D5B0 RID: 54704
	private float BubbleRate;

	// Token: 0x0400D5B1 RID: 54705
	private IBubbleIndex FlowConfig;

	// Token: 0x0400D5B2 RID: 54706
	private ENpcPerformState? LastState;
}
