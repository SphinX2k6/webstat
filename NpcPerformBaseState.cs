using System;
using System.Runtime.CompilerServices;

// Token: 0x020031CF RID: 12751
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class NpcPerformBaseState : StateBase<EntityHandle, ENpcPerformState>
{
	// Token: 0x0601A6CA RID: 108234 RVA: 0x007CB5FD File Offset: 0x007C97FD
	[NullableContext(1)]
	public NpcPerformBaseState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x170023E6 RID: 9190
	// (get) Token: 0x0601A6CB RID: 108235 RVA: 0x007CB61E File Offset: 0x007C981E
	protected PawnTurnActionController TurnActionController
	{
		get
		{
			CommonNpcPerformComponent performComp = this.PerformComp;
			if (performComp == null)
			{
				return null;
			}
			return performComp.TurnActionController;
		}
	}

	// Token: 0x0601A6CC RID: 108236 RVA: 0x007CB634 File Offset: 0x007C9834
	protected override void OnCreate(IEntityArgs config = null)
	{
		this.CreatureDataComp = this.Owner.Entity.GetComponent<CreatureDataComponent>();
		this.ActorComp = this.Owner.Entity.GetComponent<BaseCharacterComponent>();
		this.PerformComp = this.Owner.Entity.GetComponent<CommonNpcPerformComponent>();
		this.ConfigId = this.CreatureDataComp.GetPbDataId();
		this.AnimComp = this.Owner.Entity.GetComponent<BaseAnimationComponent>();
	}

	// Token: 0x0601A6CD RID: 108237 RVA: 0x007CB6AA File Offset: 0x007C98AA
	public virtual void OnPlayerInteractTurnActionStart()
	{
	}

	// Token: 0x0601A6CE RID: 108238 RVA: 0x007CB6AC File Offset: 0x007C98AC
	public virtual void OnPlayerInteractTurnActionEnd()
	{
	}

	// Token: 0x0601A6CF RID: 108239 RVA: 0x007CB6AE File Offset: 0x007C98AE
	[NullableContext(1)]
	public void PlayMontage(IPlayMontageParam param)
	{
		this.PerformComp.PlayPerformMontage(EPerformMode.Ecology, param, null, null, false);
	}

	// Token: 0x0601A6D0 RID: 108240 RVA: 0x007CB6C1 File Offset: 0x007C98C1
	[NullableContext(1)]
	public void StopMontage(IStopMontageParam param)
	{
		this.PerformComp.StopPerformMontage(EPerformMode.Ecology, param, null, null);
	}

	// Token: 0x0400D560 RID: 54624
	protected CreatureDataComponent CreatureDataComp;

	// Token: 0x0400D561 RID: 54625
	protected BaseCharacterComponent ActorComp;

	// Token: 0x0400D562 RID: 54626
	protected BaseAnimationComponent AnimComp;

	// Token: 0x0400D563 RID: 54627
	protected CommonNpcPerformComponent PerformComp;

	// Token: 0x0400D564 RID: 54628
	protected int ConfigId;

	// Token: 0x0400D565 RID: 54629
	protected bool InteractRequestWaiting;

	// Token: 0x0400D566 RID: 54630
	[Nullable(1)]
	protected Transform TmpTrans = Transform.Create();

	// Token: 0x0400D567 RID: 54631
	[Nullable(1)]
	protected Vector TmpVector = Vector.Create();
}
