using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070FE RID: 28926
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionListenBeHit : AiStateMachineCondition
	{
		// Token: 0x060461B5 RID: 287157 RVA: 0x0126A080 File Offset: 0x01268280
		public AiStateMachineConditionListenBeHit(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461B6 RID: 287158 RVA: 0x0126A098 File Offset: 0x01268298
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			if (condition.CondListenBeHit.NoHitAnimation)
			{
				this.NoHitAnimation = true;
			}
			if (condition.CondListenBeHit.SoftKnock)
			{
				this.BeHitAnimSet.Add(EHitAnim.轻左);
				this.BeHitAnimSet.Add(EHitAnim.轻右);
				this.BeHitAnimSet.Add(EHitAnim.轻前);
				this.BeHitAnimSet.Add(EHitAnim.轻后);
			}
			if (condition.CondListenBeHit.HeavyKnock)
			{
				this.BeHitAnimSet.Add(EHitAnim.重左);
				this.BeHitAnimSet.Add(EHitAnim.重右);
				this.BeHitAnimSet.Add(EHitAnim.重前);
				this.BeHitAnimSet.Add(EHitAnim.重后);
				this.BeHitAnimSet.Add(EHitAnim.压制);
			}
			if (condition.CondListenBeHit.KnockUp)
			{
				this.BeHitAnimSet.Add(EHitAnim.击飞);
			}
			if (condition.CondListenBeHit.KnockDown)
			{
				this.BeHitAnimSet.Add(EHitAnim.击倒);
			}
			if (condition.CondListenBeHit.Parry)
			{
				this.BeHitAnimSet.Add(EHitAnim.被弹反);
			}
			if (condition.CondListenBeHit.BreakWeakness)
			{
				this.BeHitAnimSet.Add(EHitAnim.被破弱);
			}
			this.VisionCounterAttackId = condition.CondListenBeHit.VisionCounterAttackId;
			return true;
		}

		// Token: 0x060461B7 RID: 287159 RVA: 0x0126A1C6 File Offset: 0x012683C6
		protected override void OnClear()
		{
			this.Node.Owner.UnregisterBeHitEvent(new Action<bool, EHitAnim, int>(this.OnBeHit));
		}

		// Token: 0x060461B8 RID: 287160 RVA: 0x0126A1E4 File Offset: 0x012683E4
		protected override void OnEnter()
		{
			this.ResultSelf = false;
			this.Node.Owner.RegisterBeHitEvent(new Action<bool, EHitAnim, int>(this.OnBeHit));
		}

		// Token: 0x060461B9 RID: 287161 RVA: 0x0126A209 File Offset: 0x01268409
		protected override void OnExit()
		{
			this.ResultSelf = false;
			this.Node.Owner.UnregisterBeHitEvent(new Action<bool, EHitAnim, int>(this.OnBeHit));
		}

		// Token: 0x060461BA RID: 287162 RVA: 0x0126A230 File Offset: 0x01268430
		private void OnBeHit(bool hasBeHitAnim, EHitAnim beHitAnim, int visionCounterAttackId)
		{
			if (visionCounterAttackId > 0)
			{
				if (this.VisionCounterAttackId != visionCounterAttackId)
				{
					return;
				}
				this.ResultSelf = true;
			}
			if (hasBeHitAnim)
			{
				if (this.BeHitAnimSet.Contains(beHitAnim))
				{
					this.ResultSelf = true;
					return;
				}
			}
			else if (this.NoHitAnimation)
			{
				this.ResultSelf = true;
			}
		}

		// Token: 0x060461BB RID: 287163 RVA: 0x0126A27C File Offset: 0x0126847C
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("监听受击\n");
		}

		// Token: 0x04027537 RID: 161079
		private bool NoHitAnimation;

		// Token: 0x04027538 RID: 161080
		private readonly HashSet<EHitAnim> BeHitAnimSet = new HashSet<EHitAnim>();

		// Token: 0x04027539 RID: 161081
		private int VisionCounterAttackId;
	}
}
