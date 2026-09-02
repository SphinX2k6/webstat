using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E2D RID: 28205
	public class LevelAiTaskTurnTo : LevelAiTask
	{
		// Token: 0x06044750 RID: 280400 RVA: 0x011C8D80 File Offset: 0x011C6F80
		protected override ELevelAiNodeResult ExecuteTask()
		{
			EntityLookAt entityLookAt = this.Params as EntityLookAt;
			if (entityLookAt == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityLookAt.EntityId);
			if (entityByPbDataId == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelAi;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "执行转向动作时实体不存在:";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", entityLookAt.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return ELevelAiNodeResult.Failed;
			}
			this.Character = entityByPbDataId.Entity.GetComponent<CharacterActorComponent>();
			BaseMoveComponent component = entityByPbDataId.Entity.GetComponent<BaseMoveComponent>();
			UCharacterMovementComponent ucharacterMovementComponent = (component != null) ? component.CharacterMovement : null;
			if (ucharacterMovementComponent == null || !ucharacterMovementComponent.IsValid())
			{
				return ELevelAiNodeResult.Failed;
			}
			this.MovementMode = ucharacterMovementComponent.MovementMode;
			ucharacterMovementComponent.MovementMode = EMovementMode.MOVE_Walking;
			Vector targetLocation = Vector.Create((double)entityLookAt.Pos.X.GetValueOrDefault(), (double)entityLookAt.Pos.Y.GetValueOrDefault(), (double)entityLookAt.Pos.Z.GetValueOrDefault());
			AiControllerLibrary.TurnToTarget(this.Character, targetLocation, 200f, false, 0f);
			this.NotifyTick = true;
			return ELevelAiNodeResult.InProgress;
		}

		// Token: 0x06044751 RID: 280401 RVA: 0x011C8EA4 File Offset: 0x011C70A4
		protected override void TickTask(float deltaTime)
		{
			if (this.Character.InputRotatorProxy.Equals(this.Character.ActorRotationProxy, 10f))
			{
				this.Character.Entity.GetComponent<BaseMoveComponent>().CharacterMovement.MovementMode = this.MovementMode;
				base.FinishLatentTask(ELevelAiNodeResult.Succeeded);
			}
		}

		// Token: 0x06044752 RID: 280402 RVA: 0x011C8EFF File Offset: 0x011C70FF
		protected override ELevelAiNodeResult AbortTask()
		{
			CharacterActorComponent character = this.Character;
			if (character != null)
			{
				character.ClearInput(false, true);
			}
			return ELevelAiNodeResult.Aborted;
		}

		// Token: 0x06044753 RID: 280403 RVA: 0x011C8F15 File Offset: 0x011C7115
		protected override void OnTaskFinished(ELevelAiNodeResult result)
		{
			this.Character = null;
			this.MovementMode = EMovementMode.MOVE_None;
		}

		// Token: 0x04026192 RID: 156050
		private const float TURN_SPEED = 200f;

		// Token: 0x04026193 RID: 156051
		private const float TOLERANCE = 10f;

		// Token: 0x04026194 RID: 156052
		[Nullable(2)]
		private CharacterActorComponent Character;

		// Token: 0x04026195 RID: 156053
		private EMovementMode MovementMode;
	}
}
