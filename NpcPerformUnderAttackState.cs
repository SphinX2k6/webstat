using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;

// Token: 0x020031DF RID: 12767
[NullableContext(1)]
[Nullable(0)]
public class NpcPerformUnderAttackState : NpcPerformBaseState
{
	// Token: 0x0601A783 RID: 108419 RVA: 0x007D1B4C File Offset: 0x007CFD4C
	public NpcPerformUnderAttackState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x0601A784 RID: 108420 RVA: 0x007D1B64 File Offset: 0x007CFD64
	public override bool CanChangeFrom(ENpcPerformState fromState)
	{
		CommonNpcPerformComponent component = this.Owner.Entity.GetComponent<CommonNpcPerformComponent>();
		return this.HaveUnderAttackConfig && fromState == ENpcPerformState.Idle && !component.IsInPlot;
	}

	// Token: 0x0601A785 RID: 108421 RVA: 0x007D1B99 File Offset: 0x007CFD99
	public void SetDefaultDirect(Vector direct)
	{
		this.DefaultDirect.DeepCopy(direct);
	}

	// Token: 0x0601A786 RID: 108422 RVA: 0x007D1BA8 File Offset: 0x007CFDA8
	[NullableContext(2)]
	protected override void OnCreate(IEntityArgs args = null)
	{
		base.OnCreate(args);
		Aki.TDConfigMgr.Component.NpcPerformComponent p = args.GetP1<Aki.TDConfigMgr.Component.NpcPerformComponent>();
		if (((p != null) ? p.NpcHitShow : null) == null)
		{
			this.HaveUnderAttackConfig = false;
			return;
		}
		this.HaveUnderAttackConfig = true;
		this.BubbleRate = p.NpcHitShow.BubbleRate;
		this.FlowConfig = p.NpcHitShow.HitBubble;
	}

	// Token: 0x0601A787 RID: 108423 RVA: 0x007D1C04 File Offset: 0x007CFE04
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
		if (component != null && component.IsMontagePlaying(EPerformGroup.DefaultGroup))
		{
			component.StopPerformMontage(EPerformMode.Ecology, new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0f)
			}, null, null);
		}
		if (!this.HaveUnderAttackConfig)
		{
			TimerSystem.Instance.Delay(delegate(float delta)
			{
				this.StateMachine.Switch(this.LastState.Value);
			}, 3000f, null, null, true, 1f);
		}
		NpcPerceptionReactionUtil.ShowHeadDialog(this.Owner.Entity, (float)this.BubbleRate, this.FlowConfig);
		Singleton<EventSystem>.Instance.EmitWithTarget(this.Owner, EEventName.OnNpcBeenAttackedStart);
	}

	// Token: 0x0601A788 RID: 108424 RVA: 0x007D1CE7 File Offset: 0x007CFEE7
	protected override void OnExit(ENpcPerformState nextState)
	{
		Singleton<EventSystem>.Instance.EmitWithTarget(this.Owner, EEventName.OnNpcBeenAttackedEnd);
	}

	// Token: 0x0601A789 RID: 108425 RVA: 0x007D1CFF File Offset: 0x007CFEFF
	protected override void OnDestroy()
	{
	}

	// Token: 0x0400D5F0 RID: 54768
	private const int BUBBLE_TIME = 3;

	// Token: 0x0400D5F1 RID: 54769
	private bool HaveUnderAttackConfig;

	// Token: 0x0400D5F2 RID: 54770
	private int BubbleRate;

	// Token: 0x0400D5F3 RID: 54771
	[Nullable(2)]
	private IBubbleIndex FlowConfig;

	// Token: 0x0400D5F4 RID: 54772
	private readonly Vector DefaultDirect = Vector.Create();

	// Token: 0x0400D5F5 RID: 54773
	private ENpcPerformState? LastState;
}
