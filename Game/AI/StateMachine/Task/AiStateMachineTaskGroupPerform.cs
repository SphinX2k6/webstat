using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MonsterGroup;
using CSharpScript.Game.NewWorld.Character.Monster.Controller;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070D7 RID: 28887
	public class AiStateMachineTaskGroupPerform : AiStateMachineTask
	{
		// Token: 0x060460A1 RID: 286881 RVA: 0x01264381 File Offset: 0x01262581
		[NullableContext(1)]
		public AiStateMachineTaskGroupPerform(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x060460A2 RID: 286882 RVA: 0x0126438C File Offset: 0x0126258C
		public override void OnEnter(long? contextId = null)
		{
			MonsterEcologyInfo monsterInfoByEntityId = ControllerBase<MonsterGroupEcologyController>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id);
			if (monsterInfoByEntityId != null)
			{
				monsterInfoByEntityId.GroupEcologyState = EGroupEcologyState.Ready;
			}
		}

		// Token: 0x060460A3 RID: 286883 RVA: 0x012643C0 File Offset: 0x012625C0
		public override void OnExit(long? contextId = null)
		{
			MonsterEcologyInfo monsterInfoByEntityId = ControllerBase<MonsterGroupEcologyController>.Instance.GetMonsterInfoByEntityId(this.Node.Entity.Id);
			if (monsterInfoByEntityId != null)
			{
				monsterInfoByEntityId.GroupEcologyState = EGroupEcologyState.None;
			}
		}

		// Token: 0x060460A4 RID: 286884 RVA: 0x012643F2 File Offset: 0x012625F2
		protected override void OnTick(float delta, long? contextId = null)
		{
			if (!ControllerBase<MonsterGroupEcologyController>.Instance.CheckEntityInMonsterGroup(this.Node.Entity.Id))
			{
				this.Node.TaskFinished = true;
			}
		}
	}
}
