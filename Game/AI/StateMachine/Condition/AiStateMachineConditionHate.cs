using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070FC RID: 28924
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionHate : AiStateMachineCondition
	{
		// Token: 0x060461AC RID: 287148 RVA: 0x01269DC7 File Offset: 0x01267FC7
		public AiStateMachineConditionHate(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461AD RID: 287149 RVA: 0x01269DD4 File Offset: 0x01267FD4
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents())
			{
				AiController aiController = this.Node.AiController;
				Entity entity;
				if (aiController == null)
				{
					entity = null;
				}
				else
				{
					CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
					entity = ((charAiDesignComp != null) ? charAiDesignComp.Entity : null);
				}
				Entity entity2 = entity;
				AiController summonerAiController = this.Node.SummonerAiController;
				Entity entity3;
				if (summonerAiController == null)
				{
					entity3 = null;
				}
				else
				{
					CharacterAiComponent charAiDesignComp2 = summonerAiController.CharAiDesignComp;
					entity3 = ((charAiDesignComp2 != null) ? charAiDesignComp2.Entity : null);
				}
				Entity entity4 = entity3;
				if (entity2 != null && !Singleton<EventSystem>.Instance.HasWithTarget(entity2, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget(entity2, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged));
				}
				if (entity4 != null && !Singleton<EventSystem>.Instance.HasWithTarget(entity4, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget(entity4, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged));
				}
				return true;
			}
			return false;
		}

		// Token: 0x060461AE RID: 287150 RVA: 0x01269EB4 File Offset: 0x012680B4
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents())
			{
				AiController aiController = this.Node.AiController;
				Entity entity;
				if (aiController == null)
				{
					entity = null;
				}
				else
				{
					CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
					entity = ((charAiDesignComp != null) ? charAiDesignComp.Entity : null);
				}
				Entity entity2 = entity;
				AiController summonerAiController = this.Node.SummonerAiController;
				Entity entity3;
				if (summonerAiController == null)
				{
					entity3 = null;
				}
				else
				{
					CharacterAiComponent charAiDesignComp2 = summonerAiController.CharAiDesignComp;
					entity3 = ((charAiDesignComp2 != null) ? charAiDesignComp2.Entity : null);
				}
				Entity entity4 = entity3;
				if (entity2 != null && Singleton<EventSystem>.Instance.HasWithTarget(entity2, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(entity2, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged));
				}
				if (entity4 != null && Singleton<EventSystem>.Instance.HasWithTarget(entity4, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(entity4, EEventName.AiHateTargetChanged, new Action<int?, int?>(this.OnAiHateTargetChanged));
				}
				return true;
			}
			return false;
		}

		// Token: 0x060461AF RID: 287151 RVA: 0x01269F94 File Offset: 0x01268194
		private void CheckTargetImpl()
		{
			this.ResultSelf = (this.Node.AiController.AiHateList.GetCurrentTarget() != null);
			if (this.ResultSelf && this.Node.SummonerAiController != null)
			{
				this.ResultSelf = (this.Node.SummonerAiController.AiHateList.GetCurrentTarget() != null);
			}
		}

		// Token: 0x060461B0 RID: 287152 RVA: 0x01269FF2 File Offset: 0x012681F2
		protected override void OnTick()
		{
			this.CheckTargetImpl();
		}

		// Token: 0x060461B1 RID: 287153 RVA: 0x01269FFC File Offset: 0x012681FC
		private void OnAiHateTargetChanged(int? newId, int? preId)
		{
			this.CheckTargetImpl();
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionHate", this.Node.Name);
			}
		}

		// Token: 0x060461B2 RID: 287154 RVA: 0x0126A049 File Offset: 0x01268249
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("有仇恨\n");
		}
	}
}
