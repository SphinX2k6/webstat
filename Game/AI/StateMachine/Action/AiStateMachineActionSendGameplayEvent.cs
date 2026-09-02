using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007115 RID: 28949
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionSendGameplayEvent : AiStateMachineAction
	{
		// Token: 0x06046229 RID: 287273 RVA: 0x0126B9D2 File Offset: 0x01269BD2
		public AiStateMachineActionSendGameplayEvent(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x0604622A RID: 287274 RVA: 0x0126B9DC File Offset: 0x01269BDC
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			CombatStateMachineDefine.Fsm.ActionSendGameplayEvent actionSendGameplayEvent = action.ActionSendGameplayEvent;
			this.TagId = ((actionSendGameplayEvent != null) ? new int?(actionSendGameplayEvent.TagId) : null);
			return true;
		}

		// Token: 0x0604622B RID: 287275 RVA: 0x0126BA10 File Offset: 0x01269C10
		public override void DoAction(long? contextId = null)
		{
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(this.TagId.GetValueOrDefault());
			if (gameplayTagById == null)
			{
				return;
			}
			AiStateMachineBase node = this.Node;
			if (node == null)
			{
				return;
			}
			BaseAbilityComponent abilityComponent = node.AbilityComponent;
			if (abilityComponent == null)
			{
				return;
			}
			abilityComponent.SendGameplayEventToActor(gameplayTagById.Value, null);
		}

		// Token: 0x0604622C RID: 287276 RVA: 0x0126BA5A File Offset: 0x01269C5A
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027556 RID: 161110
		private int? TagId;
	}
}
