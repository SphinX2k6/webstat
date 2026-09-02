using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B77 RID: 27511
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelEventCharacterMove : LevelEventBase
	{
		// Token: 0x06043EEB RID: 278251 RVA: 0x011975D2 File Offset: 0x011957D2
		public LevelEventCharacterMove(int id) : base(id)
		{
		}

		// Token: 0x06043EEC RID: 278252 RVA: 0x011975DC File Offset: 0x011957DC
		[NullableContext(1)]
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] 参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			CharacterMoveToPoint characterMoveToPoint = inParams as CharacterMoveToPoint;
			this.TargetPos = Vector.Create((double)characterMoveToPoint.Pos.X.GetValueOrDefault(), (double)characterMoveToPoint.Pos.Y.GetValueOrDefault(), (double)characterMoveToPoint.Pos.Z.GetValueOrDefault());
			switch (characterMoveToPoint.Target.Type)
			{
			case ETargetEntityType.Target:
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				this.TargetEntityHandle = ((instance != null) ? instance.GetEntityByPbDataId((characterMoveToPoint.Target as ITargetEntity).EntityId) : null);
				goto IL_153;
			}
			case ETargetEntityType.Triggered:
			{
				TriggerContext triggerContext = context as TriggerContext;
				if (triggerContext == null || triggerContext.OtherEntityId == null)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] context数据异常", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.FinishExecute(false, false, true);
					return;
				}
				CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
				this.TargetEntityHandle = ((instance2 != null) ? instance2.GetEntityById(triggerContext.OtherEntityId.Value) : null);
				goto IL_153;
			}
			case ETargetEntityType.Player:
				goto IL_153;
			}
			Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] 不支持的目标类型", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false, false, true);
			return;
			IL_153:
			if (this.TargetEntityHandle != null)
			{
				WorldEntity entity = this.TargetEntityHandle.Entity;
				CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
				if (creatureDataComponent == null || !creatureDataComponent.IsPlayer())
				{
					WorldEntity entity2 = this.TargetEntityHandle.Entity;
					if (entity2 != null)
					{
						BaseActorComponent component = entity2.GetComponent<BaseActorComponent>();
						if (component != null)
						{
							component.SetActorLocation(this.TargetPos.ToUeVector(false), "LevelEventCharacterMove:Gm推进", false);
						}
					}
				}
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043EED RID: 278253 RVA: 0x011977AC File Offset: 0x011959AC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] 参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			CharacterMoveToPoint characterMoveToPoint = inParams as CharacterMoveToPoint;
			this.TargetPos = Vector.Create((double)characterMoveToPoint.Pos.X.GetValueOrDefault(), (double)characterMoveToPoint.Pos.Y.GetValueOrDefault(), (double)characterMoveToPoint.Pos.Z.GetValueOrDefault());
			MoveCharacterPoint item = new MoveCharacterPoint
			{
				Index = 0,
				Position = this.TargetPos
			};
			this.MoveConfig = new MoveCharacterConfig
			{
				Points = new List<MoveCharacterPoint>
				{
					item
				},
				Navigation = (characterMoveToPoint.MoveType == ECharacterMoveToPointType.Walk),
				IsFly = false,
				DebugMode = true,
				Loop = false,
				Callback = (this.IsAsync ? null : new Action<ELevelEventState>(this.OnMoveEnd)),
				ReturnFalseWhenNavigationFailed = false,
				ReturnTimeoutFailed = new float?((float)10)
			};
			switch (characterMoveToPoint.Target.Type)
			{
			case ETargetEntityType.Target:
			{
				CreatureModel instance = ModelBase<CreatureModel>.Instance;
				this.TargetEntityHandle = ((instance != null) ? instance.GetEntityByPbDataId((characterMoveToPoint.Target as ITargetEntity).EntityId) : null);
				if (!this.HandleMoveEntity())
				{
					base.FinishExecute(false, false, true);
					return;
				}
				goto IL_1BA;
			}
			case ETargetEntityType.Triggered:
				if (!this.HandleMoveTriggered(context as TriggerContext))
				{
					base.FinishExecute(false, false, true);
					return;
				}
				goto IL_1BA;
			case ETargetEntityType.Player:
				if (!this.HandleMovePlayer())
				{
					base.FinishExecute(false, false, true);
					return;
				}
				goto IL_1BA;
			}
			Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] 不支持的目标类型", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.FinishExecute(false, false, true);
			return;
			IL_1BA:
			if (this.IsAsync)
			{
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x06043EEE RID: 278254 RVA: 0x01197984 File Offset: 0x01195B84
		private bool HandleMovePlayer()
		{
			this.IsPlayer = true;
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			EntityHandle targetEntityHandle;
			if (instance == null)
			{
				targetEntityHandle = null;
			}
			else
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				targetEntityHandle = instance.GetHandleByEntity((baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null);
			}
			this.TargetEntityHandle = targetEntityHandle;
			EntityHandle targetEntityHandle2 = this.TargetEntityHandle;
			if (targetEntityHandle2 == null || !targetEntityHandle2.Valid)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] 找不到玩家目标", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			CharacterMoveComponent component = this.TargetEntityHandle.Entity.GetComponent<CharacterMoveComponent>();
			if (component.IsMovingToLocation())
			{
				component.StopMoveWithCallback(ELevelEventState.Success, "LevelEventCharacterMove.HandleMovePlayer");
			}
			LevelEventCharacterMove.TogglePlayerControl(false);
			if (this.IsAsync)
			{
				EntityHandle handle = this.TargetEntityHandle;
				Vector targetPos = this.TargetPos;
				this.MoveConfig.Callback = delegate(ELevelEventState result)
				{
					LevelEventCharacterMove.OnMoveEndAsync(result, handle, true, targetPos, null);
				};
			}
			component.MoveAlongPath(this.MoveConfig, "LevelEventCharacterMove.HandleMovePlayer");
			return true;
		}

		// Token: 0x06043EEF RID: 278255 RVA: 0x01197A70 File Offset: 0x01195C70
		private bool HandleMoveEntity()
		{
			EntityHandle targetEntityHandle = this.TargetEntityHandle;
			if (targetEntityHandle == null || !targetEntityHandle.Valid)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] 找不到有效目标实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			BaseMoveComponent component = this.TargetEntityHandle.Entity.GetComponent<BaseMoveComponent>();
			CreatureDataComponent component2 = this.TargetEntityHandle.Entity.GetComponent<CreatureDataComponent>();
			if (component2 == null || !component2.IsCharacter() || component == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] 目标实体非可移动角色", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int id = this.TargetEntityHandle.Entity.Id;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num = (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null;
			if (id == num.GetValueOrDefault() & num != null)
			{
				return this.HandleMovePlayer();
			}
			if (component.IsMovingToLocation())
			{
				component.StopMoveWithCallback(ELevelEventState.Success, "LevelEventCharacterMove.HandleMoveEntity");
			}
			if (this.IsAsync)
			{
				EntityHandle handle = this.TargetEntityHandle;
				Vector targetPos = this.TargetPos;
				this.MoveConfig.Callback = delegate(ELevelEventState result)
				{
					LevelEventCharacterMove.OnMoveEndAsync(result, handle, false, targetPos, null);
				};
			}
			component.MoveAlongPath(this.MoveConfig, "LevelEventCharacterMove.HandleMoveEntity");
			return true;
		}

		// Token: 0x06043EF0 RID: 278256 RVA: 0x01197BB8 File Offset: 0x01195DB8
		private bool HandleMoveTriggered(TriggerContext context)
		{
			if (context == null || context.OtherEntityId == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZYL, "[LevelEventCharacterMove] context数据异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			this.TargetEntityHandle = ((instance != null) ? instance.GetEntityById(context.OtherEntityId.Value) : null);
			return this.HandleMoveEntity();
		}

		// Token: 0x06043EF1 RID: 278257 RVA: 0x01197C20 File Offset: 0x01195E20
		[NullableContext(1)]
		private static void OnMoveEndAsync(ELevelEventState moveResult, EntityHandle handle, bool isPlayer, Vector targetPos, [Nullable(2)] Action callback = null)
		{
			if (moveResult != ELevelEventState.Success)
			{
				CharacterActorComponent characterActorComponent;
				if (handle == null)
				{
					characterActorComponent = null;
				}
				else
				{
					WorldEntity entity = handle.Entity;
					characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
				}
				CharacterActorComponent characterActorComponent2 = characterActorComponent;
				if (isPlayer)
				{
					TeleportController instance = ControllerBase<TeleportController>.Instance;
					FVectorDouble targetPosition = targetPos.ToUeVector(false);
					FRotator value;
					if (characterActorComponent2 != null)
					{
						FRotator actorRotation = characterActorComponent2.ActorRotation;
						value = new FRotator(characterActorComponent2.ActorRotation.Pitch, characterActorComponent2.ActorRotation.Yaw, characterActorComponent2.ActorRotation.Roll);
					}
					else
					{
						value = FRotator.ZeroRotator;
					}
					instance.TeleportToPositionNoLoading(targetPosition, new FRotator?(value), "[LevelEventCharacterMove] 移动失败或超时，传送到目标位置", true).ContinueWith(delegate(bool r)
					{
						LevelEventCharacterMove.TogglePlayerControl(true);
						Action callback4 = callback;
						if (callback4 == null)
						{
							return;
						}
						callback4();
					});
					return;
				}
				if (characterActorComponent2 != null)
				{
					characterActorComponent2.TeleportAndFindStandLocation(targetPos, true);
				}
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
				return;
			}
			else
			{
				if (isPlayer)
				{
					LevelEventCharacterMove.TogglePlayerControl(true);
				}
				Action callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3();
				return;
			}
		}

		// Token: 0x06043EF2 RID: 278258 RVA: 0x01197CFB File Offset: 0x01195EFB
		private void OnMoveEnd(ELevelEventState moveResult)
		{
			LevelEventCharacterMove.OnMoveEndAsync(moveResult, this.TargetEntityHandle, this.IsPlayer, this.TargetPos, delegate
			{
				base.FinishExecute(true, false, true);
			});
		}

		// Token: 0x06043EF3 RID: 278259 RVA: 0x01197D24 File Offset: 0x01195F24
		private static void TogglePlayerControl(bool enable)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
			if (entity == null || !entity.Valid)
			{
				return;
			}
			CharacterUnifiedStateComponent component = entity.GetComponent<CharacterUnifiedStateComponent>();
			CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
			CharacterActorComponent component3 = entity.GetComponent<CharacterActorComponent>();
			CharacterInputComponent component4 = entity.GetComponent<CharacterInputComponent>();
			BaseTagComponent component5 = entity.GetComponent<BaseTagComponent>();
			CharacterMoveComponent component6 = entity.GetComponent<CharacterMoveComponent>();
			if (!enable)
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, "LevelEventCharacterMove");
				if (component != null && component.DirectionState == ECharDirectionState.AimDirection && component != null)
				{
					component.ExitAimStatus();
				}
				if (((component2 != null) ? component2.CurrentSkill : null) != null)
				{
					component2.EndOwnerAndFollowSkills();
				}
				if (component3 != null)
				{
					component3.ClearInput(false, true);
				}
				if (component4 != null)
				{
					component4.ClearMoveVectorCache();
				}
				if (component4 != null)
				{
					component4.SetActive(false);
				}
				if (component5 != null)
				{
					component5.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
				}
				if (component5 != null)
				{
					component5.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"]));
				}
				if (component5 != null)
				{
					component5.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"]));
				}
				if (component5 != null)
				{
					component5.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止锁定目标"]));
				}
				if (component5 != null)
				{
					component5.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止瞄准开镜"]));
				}
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				return;
			}
			if (component6 != null)
			{
				component6.StopMove(false, "LevelEventCharacterMove.TogglePlayerControl");
			}
			if (component6 != null)
			{
				component6.ResetMaxSpeed((component != null) ? new ECharMoveState?(component.MoveState) : null);
			}
			if (component3 != null)
			{
				component3.ClearInput(false, true);
			}
			if (component4 != null)
			{
				component4.ClearMoveVectorCache();
			}
			if (component4 != null)
			{
				component4.SetActive(true);
			}
			if (component5 != null)
			{
				component5.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
			}
			if (component5 != null)
			{
				component5.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"]));
			}
			if (component5 != null)
			{
				component5.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"]));
			}
			if (component5 != null)
			{
				component5.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止锁定目标"]));
			}
			if (component5 != null)
			{
				component5.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止瞄准开镜"]));
			}
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x04025FDF RID: 155615
		private const int MAX_EXCUTE_TIME_SEC = 10;

		// Token: 0x04025FE0 RID: 155616
		private EntityHandle TargetEntityHandle;

		// Token: 0x04025FE1 RID: 155617
		private bool IsPlayer;

		// Token: 0x04025FE2 RID: 155618
		private MoveCharacterConfig MoveConfig;

		// Token: 0x04025FE3 RID: 155619
		private Vector TargetPos;
	}
}
