using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.MonsterGroup;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F5 RID: 28917
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionCheckGroupPatrol : AiStateMachineCondition
	{
		// Token: 0x0604617F RID: 287103 RVA: 0x0126928E File Offset: 0x0126748E
		public AiStateMachineConditionCheckGroupPatrol(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x06046180 RID: 287104 RVA: 0x0126929C File Offset: 0x0126749C
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents() && this.Node.Entity != null && !Singleton<EventSystem>.Instance.Has<int>(EEventName.OnGeneratedMonsterPatrolGroup, new Action<int>(this.OnGeneratedMonsterPatrolGroup)))
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.OnGeneratedMonsterPatrolGroup, new Action<int>(this.OnGeneratedMonsterPatrolGroup));
				return true;
			}
			return false;
		}

		// Token: 0x06046181 RID: 287105 RVA: 0x012692FC File Offset: 0x012674FC
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents() && this.Node.Entity != null && Singleton<EventSystem>.Instance.Has<int>(EEventName.OnGeneratedMonsterPatrolGroup, new Action<int>(this.OnGeneratedMonsterPatrolGroup)))
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnGeneratedMonsterPatrolGroup, new Action<int>(this.OnGeneratedMonsterPatrolGroup));
				return true;
			}
			return false;
		}

		// Token: 0x06046182 RID: 287106 RVA: 0x0126935A File Offset: 0x0126755A
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.RegisterEvents();
			return true;
		}

		// Token: 0x06046183 RID: 287107 RVA: 0x01269364 File Offset: 0x01267564
		protected override void OnClear()
		{
			this.UnregisterEvents();
		}

		// Token: 0x06046184 RID: 287108 RVA: 0x01269370 File Offset: 0x01267570
		protected override void OnTick()
		{
			MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id);
			this.ResultSelf = (monsterInfoByEntityId != null);
		}

		// Token: 0x06046185 RID: 287109 RVA: 0x012693A4 File Offset: 0x012675A4
		private void OnGeneratedMonsterPatrolGroup(int groupEntityId)
		{
			if (this.Node != null && this.Node.Activated)
			{
				MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id);
				if (monsterInfoByEntityId != null != this.ResultSelf)
				{
					this.ResultSelf = (monsterInfoByEntityId != null);
					this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionCheckGroupPatrol", this.Node.Name);
				}
			}
		}

		// Token: 0x06046186 RID: 287110 RVA: 0x0126941D File Offset: 0x0126761D
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("可以集群巡逻\n");
		}
	}
}
