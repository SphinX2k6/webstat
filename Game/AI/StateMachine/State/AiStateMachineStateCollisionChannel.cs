using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E6 RID: 28902
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateCollisionChannel : AiStateMachineState
	{
		// Token: 0x06046123 RID: 287011 RVA: 0x012674EA File Offset: 0x012656EA
		public AiStateMachineStateCollisionChannel(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046124 RID: 287012 RVA: 0x012674FF File Offset: 0x012656FF
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.IgnoreChannels = state.BindCollisionChannel.IgnoreChannels;
			return true;
		}

		// Token: 0x06046125 RID: 287013 RVA: 0x01267514 File Offset: 0x01265714
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			TArray<UActorComponent> tarray = this.Node.ActorComponent.Actor.K2_GetComponentsByClass(UShapeComponent.StaticClass());
			foreach (int num in this.IgnoreChannels)
			{
				this.OriginalResponses[num] = new Dictionary<UShapeComponent, ECollisionResponse>();
				Dictionary<UShapeComponent, ECollisionResponse> dictionary = this.OriginalResponses[num];
				for (int i = 0; i < tarray.Num(); i++)
				{
					UShapeComponent ushapeComponent = tarray.Get(i) as UShapeComponent;
					TEnumAsByte<ECollisionResponse> collisionResponseToChannel = ushapeComponent.GetCollisionResponseToChannel((ECollisionChannel)num);
					dictionary[ushapeComponent] = collisionResponseToChannel;
					ushapeComponent.SetCollisionResponseToChannel((ECollisionChannel)num, ECollisionResponse.ECR_Ignore);
				}
			}
		}

		// Token: 0x06046126 RID: 287014 RVA: 0x012675E4 File Offset: 0x012657E4
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			TArray<UActorComponent> tarray = this.Node.ActorComponent.Actor.K2_GetComponentsByClass(UShapeComponent.StaticClass());
			foreach (int num in this.IgnoreChannels)
			{
				Dictionary<UShapeComponent, ECollisionResponse> dictionary;
				if (this.OriginalResponses.TryGetValue(num, out dictionary))
				{
					for (int i = 0; i < tarray.Num(); i++)
					{
						UShapeComponent ushapeComponent = tarray.Get(i) as UShapeComponent;
						ECollisionResponse newResponse;
						if (dictionary.TryGetValue(ushapeComponent, out newResponse))
						{
							ushapeComponent.SetCollisionResponseToChannel((ECollisionChannel)num, newResponse);
						}
					}
				}
			}
			this.OriginalResponses.Clear();
		}

		// Token: 0x040274F5 RID: 161013
		[Nullable(2)]
		public List<int> IgnoreChannels;

		// Token: 0x040274F6 RID: 161014
		private readonly Dictionary<int, Dictionary<UShapeComponent, ECollisionResponse>> OriginalResponses = new Dictionary<int, Dictionary<UShapeComponent, ECollisionResponse>>();
	}
}
