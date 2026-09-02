using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E20 RID: 28192
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiTaskEntityTurnTo : LevelAiTask
	{
		// Token: 0x0604470E RID: 280334 RVA: 0x011C74C4 File Offset: 0x011C56C4
		protected override ELevelAiNodeResult ExecuteTask()
		{
			EntityTurnTo entityTurnTo = this.Params as EntityTurnTo;
			if (entityTurnTo == null)
			{
				return ELevelAiNodeResult.Failed;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityTurnTo.EntityId);
			if (entityByPbDataId == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelAi;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "执行转向动作时实体不存在:";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", entityTurnTo.EntityId);
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
			if (!this.GetTurnToPosition(this.TargetPos, entityTurnTo))
			{
				return ELevelAiNodeResult.Failed;
			}
			this.MovementMode = ucharacterMovementComponent.MovementMode;
			ucharacterMovementComponent.MovementMode = EMovementMode.MOVE_Walking;
			AiControllerLibrary.TurnToTarget(this.Character, this.TargetPos, 200f, false, 0f);
			this.NotifyTick = true;
			return ELevelAiNodeResult.InProgress;
		}

		// Token: 0x0604470F RID: 280335 RVA: 0x011C75B8 File Offset: 0x011C57B8
		protected override void TickTask(float deltaTime)
		{
			if (this.Character.InputRotatorProxy.Equals(this.Character.ActorRotationProxy, 10f))
			{
				this.Character.Entity.GetComponent<BaseMoveComponent>().CharacterMovement.MovementMode = this.MovementMode;
				base.FinishLatentTask(ELevelAiNodeResult.Succeeded);
			}
		}

		// Token: 0x06044710 RID: 280336 RVA: 0x011C7613 File Offset: 0x011C5813
		protected override ELevelAiNodeResult AbortTask()
		{
			CharacterActorComponent character = this.Character;
			if (character != null)
			{
				character.ClearInput(false, true);
			}
			return ELevelAiNodeResult.Aborted;
		}

		// Token: 0x06044711 RID: 280337 RVA: 0x011C7629 File Offset: 0x011C5829
		protected override void OnTaskFinished(ELevelAiNodeResult result)
		{
			this.Character = null;
			this.MovementMode = EMovementMode.MOVE_None;
		}

		// Token: 0x06044712 RID: 280338 RVA: 0x011C763C File Offset: 0x011C583C
		private bool GetTurnToPosition(Vector outPosition, EntityTurnTo @params)
		{
			switch (@params.Target.Type)
			{
			case EActorTurnToMode.Entity:
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(@params.EntityId) : null;
				if (entityHandle == null || !entityHandle.Valid)
				{
					return false;
				}
				BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
				outPosition.DeepCopy(component.ActorLocationProxy);
				break;
			}
			case EActorTurnToMode.Position:
			{
				IActorTurnToPositionData actorTurnToPositionData = @params.Target as IActorTurnToPositionData;
				outPosition.Set((double)actorTurnToPositionData.Pos.X.GetValueOrDefault(), (double)actorTurnToPositionData.Pos.Y.GetValueOrDefault(), (double)actorTurnToPositionData.Pos.Z.GetValueOrDefault());
				break;
			}
			case EActorTurnToMode.Player:
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				if (baseCharacter == null || !baseCharacter.IsValid())
				{
					return false;
				}
				outPosition.DeepCopy(baseCharacter.CharacterActorComponent.ActorLocationProxy);
				break;
			}
			default:
				return false;
			}
			return true;
		}

		// Token: 0x04026166 RID: 156006
		private const float TURN_SPEED = 200f;

		// Token: 0x04026167 RID: 156007
		private const float TOLERANCE = 10f;

		// Token: 0x04026168 RID: 156008
		[Nullable(2)]
		private CharacterActorComponent Character;

		// Token: 0x04026169 RID: 156009
		private EMovementMode MovementMode;

		// Token: 0x0402616A RID: 156010
		private readonly Vector TargetPos = Vector.Create();
	}
}
