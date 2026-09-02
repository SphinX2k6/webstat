using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E22 RID: 11810
public class AnimalPerformTakeOffState : AnimalPerformStateBase
{
	// Token: 0x06017E3C RID: 97852 RVA: 0x006B1765 File Offset: 0x006AF965
	[NullableContext(1)]
	public AnimalPerformTakeOffState(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x06017E3D RID: 97853 RVA: 0x006B1770 File Offset: 0x006AF970
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
		this.EcologicalInterface.TakeOffStart();
		float actionTime = 0f;
		this.EcologicalInterface.GetCurrentActionTime(ref actionTime);
		this.ActionTime = actionTime;
	}

	// Token: 0x06017E3E RID: 97854 RVA: 0x006B17CE File Offset: 0x006AF9CE
	protected override void OnExit(EAnimalPerformState nextState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		this.EcologicalInterface.TakeOffEnd();
	}
}
