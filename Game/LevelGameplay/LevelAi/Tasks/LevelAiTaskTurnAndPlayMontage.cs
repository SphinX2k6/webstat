using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E2C RID: 28204
	public class LevelAiTaskTurnAndPlayMontage : LevelAiTask
	{
		// Token: 0x06044748 RID: 280392 RVA: 0x011C8A6F File Offset: 0x011C6C6F
		protected override ELevelAiNodeResult ExecuteTask()
		{
			this.Phase = LevelAiTaskTurnAndPlayMontage.ETaskPhase.ExecuteTurnTo;
			this.NotifyTick = true;
			return ELevelAiNodeResult.InProgress;
		}

		// Token: 0x06044749 RID: 280393 RVA: 0x011C8A80 File Offset: 0x011C6C80
		protected override void TickTask(float deltaTime)
		{
			switch (this.Phase)
			{
			case LevelAiTaskTurnAndPlayMontage.ETaskPhase.ExecuteTurnTo:
				this.ExecuteTurnTo();
				this.Phase = LevelAiTaskTurnAndPlayMontage.ETaskPhase.TickTurnTo;
				return;
			case LevelAiTaskTurnAndPlayMontage.ETaskPhase.TickTurnTo:
				if (Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.Character) < 10f)
				{
					this.Character.Entity.GetComponent<BaseMoveComponent>().CharacterMovement.MovementMode = this.MovementMode;
					this.Phase = LevelAiTaskTurnAndPlayMontage.ETaskPhase.ExecutePlayMontage;
					return;
				}
				break;
			case LevelAiTaskTurnAndPlayMontage.ETaskPhase.ExecutePlayMontage:
				this.ExecutePlayMontage();
				this.Phase = LevelAiTaskTurnAndPlayMontage.ETaskPhase.Finish;
				return;
			case LevelAiTaskTurnAndPlayMontage.ETaskPhase.Finish:
				break;
			default:
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelAi;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[TurnToAndPlayMontage] 阶段切换出错";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurPhase", this.Phase);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				break;
			}
			}
		}

		// Token: 0x0604474A RID: 280394 RVA: 0x011C8B3F File Offset: 0x011C6D3F
		protected override ELevelAiNodeResult AbortTask()
		{
			if (this.Phase < LevelAiTaskTurnAndPlayMontage.ETaskPhase.ExecutePlayMontage)
			{
				CharacterActorComponent character = this.Character;
				if (character != null)
				{
					character.ClearInput(false, true);
				}
			}
			else
			{
				base.CreatureDataComponent.Entity.GetComponent<BasePerformComponent>().VolatileMontageStopByLoad(EPerformMode.Ecology, this.PlayingMontageId, EStopMethod.BlendOut);
			}
			return ELevelAiNodeResult.Aborted;
		}

		// Token: 0x0604474B RID: 280395 RVA: 0x011C8B7D File Offset: 0x011C6D7D
		protected override void OnTaskFinished(ELevelAiNodeResult result)
		{
			this.Character = null;
			this.MovementMode = EMovementMode.MOVE_None;
		}

		// Token: 0x0604474C RID: 280396 RVA: 0x011C8B90 File Offset: 0x011C6D90
		private void ExecuteTurnTo()
		{
			TurnAndPlayMontageParam turnAndPlayMontageParam = this.Params as TurnAndPlayMontageParam;
			if (turnAndPlayMontageParam == null)
			{
				base.FinishLatentTask(ELevelAiNodeResult.Failed);
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(turnAndPlayMontageParam.EntityId);
			if (entityByPbDataId == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelAi;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "执行转向动作时实体不存在:";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", turnAndPlayMontageParam.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishLatentTask(ELevelAiNodeResult.Failed);
				return;
			}
			this.Character = entityByPbDataId.Entity.GetComponent<CharacterActorComponent>();
			BaseMoveComponent component = entityByPbDataId.Entity.GetComponent<BaseMoveComponent>();
			UCharacterMovementComponent ucharacterMovementComponent = (component != null) ? component.CharacterMovement : null;
			if (ucharacterMovementComponent == null || !ucharacterMovementComponent.IsValid())
			{
				base.FinishLatentTask(ELevelAiNodeResult.Failed);
				return;
			}
			this.MovementMode = ucharacterMovementComponent.MovementMode;
			ucharacterMovementComponent.MovementMode = EMovementMode.MOVE_Walking;
			Vector targetLocation = Vector.Create(turnAndPlayMontageParam.Pos.X, turnAndPlayMontageParam.Pos.Y, turnAndPlayMontageParam.Pos.Z);
			AiControllerLibrary.TurnToTarget(this.Character, targetLocation, 200f, false, 0f);
		}

		// Token: 0x0604474D RID: 280397 RVA: 0x011C8CA0 File Offset: 0x011C6EA0
		private void ExecutePlayMontage()
		{
			TurnAndPlayMontageParam turnAndPlayMontageParam = this.Params as TurnAndPlayMontageParam;
			if (turnAndPlayMontageParam == null)
			{
				base.FinishLatentTask(ELevelAiNodeResult.Failed);
				return;
			}
			this.LoopDuration = turnAndPlayMontageParam.LoopDuration;
			this.RepeatTimes = turnAndPlayMontageParam.RepeatTimes;
			BasePerformComponent component = base.CreatureDataComponent.Entity.GetComponent<BasePerformComponent>();
			IMontageId montage2 = new IMontageId
			{
				IsAbp = turnAndPlayMontageParam.IsAbpMontage,
				MontageId = turnAndPlayMontageParam.MontageId
			};
			IAnimStateParam montageStateParam = component.GetMontageStateParam(montage2);
			string montagePath = component.GetMontagePath(montage2);
			if (montagePath == null)
			{
				base.FinishLatentTask(ELevelAiNodeResult.Succeeded);
				return;
			}
			this.PlayingMontageId = component.VolatileMontagePlayByLoad(EPerformMode.Ecology, montagePath, montageStateParam, null, delegate(UAnimMontage montage, bool _)
			{
				base.FinishLatentTask(ELevelAiNodeResult.Succeeded);
			}, new float?(this.LoopDuration), new float?((float)this.RepeatTimes), new bool?(false), new bool?(false), new bool?(false));
		}

		// Token: 0x0402618A RID: 156042
		private const float TURN_SPEED = 200f;

		// Token: 0x0402618B RID: 156043
		private const float TOLERANCE = 10f;

		// Token: 0x0402618C RID: 156044
		[Nullable(2)]
		private CharacterActorComponent Character;

		// Token: 0x0402618D RID: 156045
		private EMovementMode MovementMode;

		// Token: 0x0402618E RID: 156046
		private int PlayingMontageId;

		// Token: 0x0402618F RID: 156047
		private float LoopDuration;

		// Token: 0x04026190 RID: 156048
		private int RepeatTimes;

		// Token: 0x04026191 RID: 156049
		private LevelAiTaskTurnAndPlayMontage.ETaskPhase Phase;

		// Token: 0x0200CB28 RID: 52008
		private enum ETaskPhase
		{
			// Token: 0x0403E5AC RID: 255404
			None,
			// Token: 0x0403E5AD RID: 255405
			ExecuteTurnTo,
			// Token: 0x0403E5AE RID: 255406
			TickTurnTo,
			// Token: 0x0403E5AF RID: 255407
			ExecutePlayMontage,
			// Token: 0x0403E5B0 RID: 255408
			Finish
		}
	}
}
