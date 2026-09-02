using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007117 RID: 28951
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionStopMontage : AiStateMachineAction
	{
		// Token: 0x06046231 RID: 287281 RVA: 0x0126BA7B File Offset: 0x01269C7B
		public AiStateMachineActionStopMontage(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046232 RID: 287282 RVA: 0x0126BA85 File Offset: 0x01269C85
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			this.BlendOutTime = action.ActionStopMontage.BlendOutTime / 1000f;
			return true;
		}

		// Token: 0x06046233 RID: 287283 RVA: 0x0126BAA0 File Offset: 0x01269CA0
		public override void DoAction(long? contextId = null)
		{
			CharacterSkillComponent skillComponent = this.Node.SkillComponent;
			if (((skillComponent != null) ? skillComponent.CurrentSkill : null) != null)
			{
				return;
			}
			if (this.Node.Owner.CheckAnyMontageTaskRunning(this.Node.RootNode))
			{
				return;
			}
			BaseTagComponent tagComponent = this.Node.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]))
			{
				BaseTagComponent tagComponent2 = this.Node.TagComponent;
				if (tagComponent2 == null || !tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
				{
					BaseTagComponent tagComponent3 = this.Node.TagComponent;
					if (tagComponent3 == null || !tagComponent3.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"]))
					{
						UAnimInstance mainAnimInstance = this.Node.AnimationComponent.MainAnimInstance;
						if (mainAnimInstance == null)
						{
							return;
						}
						mainAnimInstance.Montage_Stop(this.BlendOutTime, null);
						return;
					}
				}
			}
		}

		// Token: 0x06046234 RID: 287284 RVA: 0x0126BB7F File Offset: 0x01269D7F
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027557 RID: 161111
		private float BlendOutTime;
	}
}
