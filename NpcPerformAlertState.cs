using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;

// Token: 0x020031CE RID: 12750
public class NpcPerformAlertState : NpcPerformBaseState
{
	// Token: 0x0601A6C5 RID: 108229 RVA: 0x007CB4E1 File Offset: 0x007C96E1
	[NullableContext(1)]
	public NpcPerformAlertState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x0601A6C6 RID: 108230 RVA: 0x007CB4EC File Offset: 0x007C96EC
	public override bool CanChangeFrom(ENpcPerformState fromState)
	{
		CommonNpcPerformComponent component = this.Owner.Entity.GetComponent<CommonNpcPerformComponent>();
		CharacterAiComponent component2 = this.Owner.Entity.GetComponent<CharacterAiComponent>();
		bool flag;
		if (component2 == null)
		{
			flag = false;
		}
		else
		{
			AiController aiController = component2.AiController;
			if (aiController == null)
			{
				flag = false;
			}
			else
			{
				AiAlertClass aiAlert = aiController.AiAlert;
				flag = (aiAlert != null && aiAlert.AiAlertConfig != null);
			}
		}
		return flag && fromState == ENpcPerformState.Idle && !component.IsInPlot;
	}

	// Token: 0x0601A6C7 RID: 108231 RVA: 0x007CB558 File Offset: 0x007C9758
	protected override void OnEnter(ENpcPerformState? lastState)
	{
		if (Global.BaseCharacter == null)
		{
			return;
		}
		CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
		AiControllerLibrary.TurnToTarget(this.Owner.Entity.GetComponent<CharacterActorComponent>(), characterActorComponent.ActorLocationProxy, 20000f, false, 0f);
		Singleton<EventSystem>.Instance.AddWithTarget(this.Owner.Entity, EEventName.OnStalkAlertLifted, new Action(this.OnStalkAlertLifted));
	}

	// Token: 0x0601A6C8 RID: 108232 RVA: 0x007CB5C5 File Offset: 0x007C97C5
	protected override void OnExit(ENpcPerformState nextState)
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(this.Owner.Entity, EEventName.OnStalkAlertLifted, new Action(this.OnStalkAlertLifted));
	}

	// Token: 0x0601A6C9 RID: 108233 RVA: 0x007CB5EE File Offset: 0x007C97EE
	private void OnStalkAlertLifted()
	{
		this.StateMachine.Switch(ENpcPerformState.Idle);
	}

	// Token: 0x0400D55F RID: 54623
	private const int TURN_SPEED = 20000;
}
