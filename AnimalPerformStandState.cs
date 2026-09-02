using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x02002E1E RID: 11806
public class AnimalPerformStandState : AnimalPerformStateBase
{
	// Token: 0x06017E29 RID: 97833 RVA: 0x006B12BC File Offset: 0x006AF4BC
	[NullableContext(1)]
	public AnimalPerformStandState(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x06017E2A RID: 97834 RVA: 0x006B12C7 File Offset: 0x006AF4C7
	protected override void OnEnter(EAnimalPerformState? lastState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		this.EcologicalInterface.NoneStateStart();
	}

	// Token: 0x06017E2B RID: 97835 RVA: 0x006B12DD File Offset: 0x006AF4DD
	protected override void OnExit(EAnimalPerformState nextState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		PawnInteractNewComponent component = this.Owner.GetComponent<PawnInteractNewComponent>();
		if (component != null)
		{
			component.SetInteractionState(false, "AnimalPerformStandState OnExit");
		}
		this.EcologicalInterface.NoneStateEnd();
	}
}
