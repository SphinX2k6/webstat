using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E24 RID: 28196
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelAiTaskMoveTo : LevelAiTask
	{
		// Token: 0x0604471D RID: 280349 RVA: 0x011C7AB4 File Offset: 0x011C5CB4
		protected override ELevelAiNodeResult ExecuteTask()
		{
			this.MoveComp = base.CreatureDataComponent.Entity.GetComponent<BaseMoveComponent>();
			if (this.MoveComp == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			MoveCharacterPoint moveCharacterPoint = new MoveCharacterPoint
			{
				Index = 0,
				Position = this.Target,
				MoveSpeed = new float?(this.MoveSpeed),
				MoveState = new EPatrolMoveState?((EPatrolMoveState)this.MoveState)
			};
			MoveCharacterConfig config = new MoveCharacterConfig
			{
				Points = new MoveCharacterPoint[]
				{
					moveCharacterPoint
				},
				Navigation = true,
				IsFly = false,
				DebugMode = true,
				Loop = false,
				Callback = new Action<ELevelEventState>(this.TaskFinishCallBack),
				ReturnFalseWhenNavigationFailed = false
			};
			this.MoveComp.MoveAlongPath(config, "LevelAiTaskMoveTo.ExecuteTask");
			return ELevelAiNodeResult.InProgress;
		}

		// Token: 0x0604471E RID: 280350 RVA: 0x011C7B81 File Offset: 0x011C5D81
		protected override ELevelAiNodeResult AbortTask()
		{
			this.MoveComp.StopMoveNew("LevelAiTaskMoveTo.AbortTask");
			return ELevelAiNodeResult.Aborted;
		}

		// Token: 0x0604471F RID: 280351 RVA: 0x011C7B94 File Offset: 0x011C5D94
		private void TaskFinishCallBack(ELevelEventState result)
		{
			this.MoveComp.StopMoveNew("LevelAiTaskMoveTo.TaskFinishCallBack");
			if (result == ELevelEventState.Success)
			{
				base.FinishLatentTask(ELevelAiNodeResult.Succeeded);
				return;
			}
			if (result - ELevelEventState.Failure > 1)
			{
				return;
			}
			base.FinishLatentTask(ELevelAiNodeResult.Failed);
		}

		// Token: 0x04026172 RID: 156018
		public Vector Target;

		// Token: 0x04026173 RID: 156019
		public EMoveSpeed MoveState = EMoveSpeed.Run;

		// Token: 0x04026174 RID: 156020
		public float MoveSpeed;

		// Token: 0x04026175 RID: 156021
		private BaseMoveComponent MoveComp;
	}
}
