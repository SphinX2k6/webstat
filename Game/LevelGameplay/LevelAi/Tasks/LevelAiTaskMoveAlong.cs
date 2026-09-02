using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E23 RID: 28195
	public class LevelAiTaskMoveAlong : LevelAiTask
	{
		// Token: 0x06044719 RID: 280345 RVA: 0x011C79AC File Offset: 0x011C5BAC
		protected override ELevelAiNodeResult ExecuteTask()
		{
			this.MoveComp = base.CreatureDataComponent.Entity.GetComponent<BaseMoveComponent>();
			if (this.MoveComp == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			MoveCharacterConfig config = new MoveCharacterConfig
			{
				Points = this.PathPoint,
				Navigation = this.Navigation,
				IsFly = false,
				DebugMode = true,
				Loop = false,
				Callback = new Action<ELevelEventState>(this.TaskFinishCallBack),
				UsePreviousIndex = new bool?(true),
				UseNearestPoint = new bool?(true),
				ReturnFalseWhenNavigationFailed = false,
				ResetAllPoints = new bool?(this.ResetAllPoints)
			};
			this.MoveComp.MoveAlongPath(config, "LevelAiTaskMoveAlong.ExecuteTask");
			return ELevelAiNodeResult.InProgress;
		}

		// Token: 0x0604471A RID: 280346 RVA: 0x011C7A66 File Offset: 0x011C5C66
		protected override ELevelAiNodeResult AbortTask()
		{
			this.MoveComp.StopMoveNew("LevelAiTaskMoveAlong.AbortTask");
			return ELevelAiNodeResult.Aborted;
		}

		// Token: 0x0604471B RID: 280347 RVA: 0x011C7A79 File Offset: 0x011C5C79
		private void TaskFinishCallBack(ELevelEventState result)
		{
			this.MoveComp.StopMoveNew("LevelAiTaskMoveAlong.TaskFinishCallBack");
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

		// Token: 0x0402616E RID: 156014
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<MoveCharacterPoint> PathPoint;

		// Token: 0x0402616F RID: 156015
		public bool Navigation = true;

		// Token: 0x04026170 RID: 156016
		public bool ResetAllPoints;

		// Token: 0x04026171 RID: 156017
		[Nullable(2)]
		private BaseMoveComponent MoveComp;
	}
}
