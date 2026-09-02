using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E23 RID: 11811
public class AnimalPerformUnderAttackState : AnimalPerformStateBase
{
	// Token: 0x06017E3F RID: 97855 RVA: 0x006B17E4 File Offset: 0x006AF9E4
	[NullableContext(1)]
	public AnimalPerformUnderAttackState(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x06017E40 RID: 97856 RVA: 0x006B17F0 File Offset: 0x006AF9F0
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
		this.EcologicalInterface.UnderAttackStart();
		float num = 0f;
		this.EcologicalInterface.GetCurrentActionTime(ref num);
		this.ActionTime = num - 0.25f;
	}

	// Token: 0x06017E41 RID: 97857 RVA: 0x006B1854 File Offset: 0x006AFA54
	protected override void OnUpdate(float delta)
	{
	}

	// Token: 0x06017E42 RID: 97858 RVA: 0x006B1856 File Offset: 0x006AFA56
	protected override void OnExit(EAnimalPerformState nextState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		this.EcologicalInterface.UnderAttackEnd();
	}

	// Token: 0x0400B96B RID: 47467
	private const float BLEND_OUT_TIME = 0.25f;
}
