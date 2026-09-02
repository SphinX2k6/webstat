using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E19 RID: 11801
public class AnimalPerformAlertState : AnimalPerformStateBase
{
	// Token: 0x06017E04 RID: 97796 RVA: 0x006B0187 File Offset: 0x006AE387
	[NullableContext(1)]
	public AnimalPerformAlertState(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x06017E05 RID: 97797 RVA: 0x006B0194 File Offset: 0x006AE394
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
		this.EcologicalInterface.AlertStart();
		float actionTime = 0f;
		this.EcologicalInterface.GetCurrentActionTime(ref actionTime);
		this.ActionTime = actionTime;
	}

	// Token: 0x06017E06 RID: 97798 RVA: 0x006B01F2 File Offset: 0x006AE3F2
	protected override void OnUpdate(float delta)
	{
	}

	// Token: 0x06017E07 RID: 97799 RVA: 0x006B01F4 File Offset: 0x006AE3F4
	protected override void OnExit(EAnimalPerformState nextState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		this.EcologicalInterface.AlertEnd();
	}
}
