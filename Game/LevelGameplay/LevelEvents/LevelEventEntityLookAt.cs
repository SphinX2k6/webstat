using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B97 RID: 27543
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventEntityLookAt : LevelEventBase
	{
		// Token: 0x06043F69 RID: 278377 RVA: 0x0119BC2E File Offset: 0x01199E2E
		public LevelEventEntityLookAt(int id) : base(id)
		{
		}

		// Token: 0x06043F6A RID: 278378 RVA: 0x0119BC37 File Offset: 0x01199E37
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.Param = (inParams as EntityLookAt);
			this.CanTick = false;
			base.CreateWaitEntityTask(this.Param.EntityId);
		}

		// Token: 0x06043F6B RID: 278379 RVA: 0x0119BC6A File Offset: 0x01199E6A
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F6C RID: 278380 RVA: 0x0119BC78 File Offset: 0x01199E78
		protected override void ExecuteWhenEntitiesReady()
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.Param.EntityId);
			if (entityByPbDataId == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "执行转向动作时实体不存在:";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.Param.EntityId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(true, false, true);
				return;
			}
			this.EntityHandle = entityByPbDataId;
			CharacterActorComponent component = entityByPbDataId.Entity.GetComponent<CharacterActorComponent>();
			BaseMoveComponent component2 = entityByPbDataId.Entity.GetComponent<BaseMoveComponent>();
			UCharacterMovementComponent ucharacterMovementComponent = (component2 != null) ? component2.CharacterMovement : null;
			if (!ObjectUtils.IsValid(ucharacterMovementComponent))
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.MovementMode = ucharacterMovementComponent.MovementMode;
			ucharacterMovementComponent.MovementMode = EMovementMode.MOVE_Walking;
			global::Vector vector = global::Vector.Create((double)this.Param.Pos.X.GetValueOrDefault(), (double)this.Param.Pos.Y.GetValueOrDefault(), (double)this.Param.Pos.Z.GetValueOrDefault());
			AiControllerLibrary.TurnToTarget(component, vector, 200f, false, 0f);
			global::Vector vector2 = global::Vector.Create();
			global::Rotator rotator = global::Rotator.Create();
			vector.Subtraction(component.ActorLocationProxy, vector2);
			vector2.ToOrientationRotator(rotator);
			rotator.Pitch = 0f;
			rotator.Roll = 0f;
			EntitySimplyMoveInfoPackagePush entitySimplyMoveInfoPackagePush = EntitySimplyMoveInfoPackagePush.Create();
			EntitySimplyMoveInfo entitySimplyMoveInfo = EntitySimplyMoveInfo.Create();
			entitySimplyMoveInfo.EntityId = entityByPbDataId.CreatureDataId;
			entitySimplyMoveInfo.Location = component.ActorLocationProxy.ToProtocolVector();
			entitySimplyMoveInfo.Rotation = rotator.ToProtocolRotator();
			entitySimplyMoveInfoPackagePush.MoveInfos.Add(entitySimplyMoveInfo);
			Singleton<Net>.Instance.Send(EPushMessageId.EntitySimplyMoveInfoPackagePush, entitySimplyMoveInfoPackagePush);
			if (this.IsAsync)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			this.CanTick = true;
		}

		// Token: 0x06043F6D RID: 278381 RVA: 0x0119BE50 File Offset: 0x0119A050
		protected override void OnTick(float deltaTime)
		{
			if (!this.CanTick)
			{
				return;
			}
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.IsInit)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			WorldEntity entity = this.EntityHandle.Entity;
			CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
			if (characterActorComponent.InputRotatorProxy.Equals(characterActorComponent.ActorRotationProxy, 10f))
			{
				characterActorComponent.Entity.GetComponent<BaseMoveComponent>().CharacterMovement.MovementMode = this.MovementMode;
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x06043F6E RID: 278382 RVA: 0x0119BEE0 File Offset: 0x0119A0E0
		protected override void OnReset()
		{
			this.EntityHandle = null;
			this.CanTick = false;
			this.MovementMode = EMovementMode.MOVE_None;
		}

		// Token: 0x04026012 RID: 155666
		private const int TURN_SPEED = 200;

		// Token: 0x04026013 RID: 155667
		private const int TOLERANCE = 10;

		// Token: 0x04026014 RID: 155668
		[Nullable(2)]
		private EntityHandle EntityHandle;

		// Token: 0x04026015 RID: 155669
		[Nullable(2)]
		private EntityLookAt Param;

		// Token: 0x04026016 RID: 155670
		private bool CanTick;

		// Token: 0x04026017 RID: 155671
		private EMovementMode MovementMode;
	}
}
