using System;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E26 RID: 28198
	public class LevelAiTaskPlayMontage : LevelAiTask
	{
		// Token: 0x06044725 RID: 280357 RVA: 0x011C7DAC File Offset: 0x011C5FAC
		protected override ELevelAiNodeResult ExecuteTask()
		{
			PlayRegisteredMontage @params = this.Params as PlayRegisteredMontage;
			if (@params == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			this.LoopDuration = @params.LoopDuration.GetValueOrDefault();
			this.RepeatTimes = @params.RepeatTimes.GetValueOrDefault();
			Entity entity = base.CreatureDataComponent.Entity;
			BasePerformComponent component = entity.GetComponent<BasePerformComponent>();
			IMontageId montage2 = new IMontageId
			{
				IsAbp = @params.IsAbpMontage,
				MontageId = @params.MontageId
			};
			IAnimStateParam montageStateParam = component.GetMontageStateParam(montage2);
			string montagePath = component.GetMontagePath(montage2);
			if (montagePath == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			bool hasProgress = false;
			this.MontagePlayId = component.VolatileMontagePlayByLoad(EPerformMode.Ecology, montagePath, montageStateParam, delegate(UAnimMontage montage)
			{
				if (montage != null && @params.FaceExpressionId != null)
				{
					Entity entity = entity;
					CommonNpcPerformComponent commonNpcPerformComponent = (entity != null) ? entity.GetComponent<CommonNpcPerformComponent>() : null;
					if (commonNpcPerformComponent == null)
					{
						return;
					}
					NpcFacialExpressionController expressionController = commonNpcPerformComponent.ExpressionController;
					if (expressionController == null)
					{
						return;
					}
					expressionController.ChangeFaceForExpression(montage, new int?(@params.FaceExpressionId.Value));
				}
			}, delegate(UAnimMontage montage, bool _)
			{
				if (hasProgress)
				{
					this.FinishLatentTask(ELevelAiNodeResult.Succeeded);
					return;
				}
				hasProgress = true;
			}, new float?(this.LoopDuration), new float?((float)this.RepeatTimes), new bool?(false), new bool?(false), new bool?(false));
			if (hasProgress)
			{
				return ELevelAiNodeResult.Succeeded;
			}
			hasProgress = true;
			return ELevelAiNodeResult.InProgress;
		}

		// Token: 0x06044726 RID: 280358 RVA: 0x011C7EDB File Offset: 0x011C60DB
		protected override ELevelAiNodeResult AbortTask()
		{
			base.CreatureDataComponent.Entity.GetComponent<BasePerformComponent>().VolatileMontageStopByLoad(EPerformMode.Ecology, this.MontagePlayId, EStopMethod.BlendOut);
			return ELevelAiNodeResult.Aborted;
		}

		// Token: 0x04026176 RID: 156022
		private float LoopDuration;

		// Token: 0x04026177 RID: 156023
		private int RepeatTimes;

		// Token: 0x04026178 RID: 156024
		private int MontagePlayId = -1;
	}
}
