using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MonsterGroup;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070D6 RID: 28886
	public class AiStateMachineTaskGroupPatrol : AiStateMachineTask
	{
		// Token: 0x0604609D RID: 286877 RVA: 0x012642D3 File Offset: 0x012624D3
		[NullableContext(1)]
		public AiStateMachineTaskGroupPatrol(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x0604609E RID: 286878 RVA: 0x012642E0 File Offset: 0x012624E0
		public override void OnEnter(long? contextId = null)
		{
			MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id);
			if (monsterInfoByEntityId != null)
			{
				monsterInfoByEntityId.GroupPatrolState = EGroupPatrolState.Ready;
			}
		}

		// Token: 0x0604609F RID: 286879 RVA: 0x01264314 File Offset: 0x01262514
		public override void OnExit(long? contextId = null)
		{
			MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id);
			if (monsterInfoByEntityId != null)
			{
				MonsterGroupInfo group = monsterInfoByEntityId.Group;
				if (group != null)
				{
					group.PausePatrol();
				}
				monsterInfoByEntityId.GroupPatrolState = EGroupPatrolState.None;
			}
		}

		// Token: 0x060460A0 RID: 286880 RVA: 0x01264357 File Offset: 0x01262557
		protected override void OnTick(float delta, long? contextId = null)
		{
			if (ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id) == null)
			{
				this.Node.TaskFinished = true;
			}
		}
	}
}
