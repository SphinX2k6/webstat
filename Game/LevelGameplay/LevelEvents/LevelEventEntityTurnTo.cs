using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B98 RID: 27544
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventEntityTurnTo : LevelEventBase
	{
		// Token: 0x06043F6F RID: 278383 RVA: 0x0119BEF7 File Offset: 0x0119A0F7
		public LevelEventEntityTurnTo(int id) : base(id)
		{
		}

		// Token: 0x06043F70 RID: 278384 RVA: 0x0119BF00 File Offset: 0x0119A100
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.Param = (inParams as EntityTurnTo);
			base.CreateWaitEntityTask(this.Param.EntityId);
		}

		// Token: 0x06043F71 RID: 278385 RVA: 0x0119BF20 File Offset: 0x0119A120
		protected override void ExecuteWhenEntitiesReady()
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.Param.EntityId);
			if (entityByPbDataId == null || !entityByPbDataId.IsInit)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			BasePerformComponent component = entityByPbDataId.Entity.GetComponent<BasePerformComponent>();
			if (component == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			global::Vector vector = null;
			switch (this.Param.Target.Type)
			{
			case EActorTurnToMode.Entity:
			{
				EntityHandle entityByPbDataId2 = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId((this.Param.Target as IActorTurnToEntityData).EntityId);
				BaseActorComponent baseActorComponent;
				if (entityByPbDataId2 == null)
				{
					baseActorComponent = null;
				}
				else
				{
					WorldEntity entity = entityByPbDataId2.Entity;
					baseActorComponent = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
				}
				BaseActorComponent baseActorComponent2 = baseActorComponent;
				if (baseActorComponent2 != null)
				{
					vector = global::Vector.Create(baseActorComponent2.ActorLocationProxy);
				}
				break;
			}
			case EActorTurnToMode.Position:
				vector = global::Vector.Create();
				vector.FromConfigVector((this.Param.Target as IActorTurnToPositionData).Pos);
				break;
			case EActorTurnToMode.Player:
			{
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				BaseActorComponent baseActorComponent3;
				if (getCurrentEntity == null)
				{
					baseActorComponent3 = null;
				}
				else
				{
					WorldEntity entity2 = getCurrentEntity.Entity;
					baseActorComponent3 = ((entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null);
				}
				BaseActorComponent baseActorComponent4 = baseActorComponent3;
				if (baseActorComponent4 != null)
				{
					vector = global::Vector.Create(baseActorComponent4.ActorLocationProxy);
				}
				break;
			}
			}
			if (vector == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			BaseActorComponent component2 = entityByPbDataId.Entity.GetComponent<BaseActorComponent>();
			global::Vector vector2 = global::Vector.Create();
			global::Rotator rotator = global::Rotator.Create();
			vector.Subtraction(component2.ActorLocationProxy, vector2);
			vector2.ToOrientationRotator(rotator);
			rotator.Pitch = 0f;
			rotator.Roll = 0f;
			EntitySimplyMoveInfoPackagePush entitySimplyMoveInfoPackagePush = EntitySimplyMoveInfoPackagePush.Create();
			EntitySimplyMoveInfo entitySimplyMoveInfo = EntitySimplyMoveInfo.Create();
			entitySimplyMoveInfo.EntityId = entityByPbDataId.CreatureDataId;
			entitySimplyMoveInfo.Location = component2.ActorLocationProxy.ToProtocolVector();
			entitySimplyMoveInfo.Rotation = rotator.ToProtocolRotator();
			entitySimplyMoveInfoPackagePush.MoveInfos.Add(entitySimplyMoveInfo);
			Singleton<Net>.Instance.Send(EPushMessageId.EntitySimplyMoveInfoPackagePush, entitySimplyMoveInfoPackagePush);
			if (!this.IsAsync)
			{
				this.EntityHandle = entityByPbDataId;
				Singleton<EventSystem>.Instance.AddWithTarget(entityByPbDataId, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
				component.PerformTurn(EPerformMode.Action, new TurnParam
				{
					TargetLocation = vector
				}, null, new Action<int>(this.OnEnd));
				return;
			}
			component.PerformTurn(EPerformMode.Action, new TurnParam
			{
				TargetLocation = vector
			}, null, null);
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F72 RID: 278386 RVA: 0x0119C168 File Offset: 0x0119A368
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (this.EntityHandle != handle)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "实体被移除 LevelEventEntityTurnTo保底结束";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", handle.PbDataId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnEnd(0);
		}

		// Token: 0x06043F73 RID: 278387 RVA: 0x0119C1B8 File Offset: 0x0119A3B8
		private void OnEnd(int _)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x04026018 RID: 155672
		[Nullable(2)]
		private EntityTurnTo Param;

		// Token: 0x04026019 RID: 155673
		[Nullable(2)]
		private EntityHandle EntityHandle;
	}
}
