using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x02002E1C RID: 11804
public class AnimalPerformIdleState : AnimalPerformStateBase
{
	// Token: 0x06017E22 RID: 97826 RVA: 0x006B10FE File Offset: 0x006AF2FE
	[NullableContext(1)]
	public AnimalPerformIdleState(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x06017E23 RID: 97827 RVA: 0x006B110C File Offset: 0x006AF30C
	protected override void OnEnter(EAnimalPerformState? lastState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		EAnimalPerformState? eanimalPerformState = lastState;
		EAnimalPerformState eanimalPerformState2 = EAnimalPerformState.Born;
		if (eanimalPerformState.GetValueOrDefault() == eanimalPerformState2 & eanimalPerformState != null)
		{
			base.AnimalEcologicalInterface.StateMachineInitializationComplete();
		}
		this.EcologicalInterface.IdleStart();
		float actionTime = 0f;
		this.EcologicalInterface.GetCurrentActionTime(ref actionTime);
		this.ActionTime = actionTime;
	}

	// Token: 0x06017E24 RID: 97828 RVA: 0x006B116A File Offset: 0x006AF36A
	protected override void OnUpdate(float delta)
	{
	}

	// Token: 0x06017E25 RID: 97829 RVA: 0x006B116C File Offset: 0x006AF36C
	protected override void OnExit(EAnimalPerformState nextState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		PawnInteractNewComponent component = this.Owner.GetComponent<PawnInteractNewComponent>();
		if (component != null)
		{
			component.SetInteractionState(true, "AnimalPerformIdleState OnExit");
		}
		this.EcologicalInterface.IdleEnd();
	}
}
