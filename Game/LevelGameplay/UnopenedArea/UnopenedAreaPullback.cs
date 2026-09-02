using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.Render.Effect.PostProcess;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.UnopenedArea
{
	// Token: 0x02006A68 RID: 27240
	[NullableContext(1)]
	[Nullable(0)]
	public class UnopenedAreaPullback : IUnopenedAreaHandler
	{
		// Token: 0x1700A253 RID: 41555
		// (get) Token: 0x0604362D RID: 276013 RVA: 0x0115BBAA File Offset: 0x01159DAA
		public bool ForbidVehicleOnEnter
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0604362E RID: 276014 RVA: 0x0115BBB0 File Offset: 0x01159DB0
		public void Tick(float delta)
		{
			EntityHandle playerEntity = this.PlayerEntity;
			if (playerEntity == null || !playerEntity.Valid)
			{
				return;
			}
			if (ModelBase<TeleportModel>.Instance.IsTeleport || ModelBase<PlotModel>.Instance.IsInPlot)
			{
				this.SetTeleportTimerPause(true);
				return;
			}
			this.SetTeleportTimerPause(false);
			double num = global::Vector.Dist2D(this.EnterLocation, this.ActorComp.ActorLocationProxy);
			if (this.EnablePostProcess)
			{
				float num2 = (float)Singleton<MathUtils>.Instance.SafeDivide(num, this.ToleranceDistance);
				num2 = Singleton<MathUtils>.Instance.Clamp(num2, 0f, 1f);
				Singleton<SceneEffectStateManager>.Instance.SetSceneEffectState(ESceneEffectStateType.AirWall, num2);
			}
			if (!this.IsRunningPullback && num > this.ToleranceDistance)
			{
				this.OpenGenericPrompt();
				this.OnRunPullback();
				return;
			}
			if (this.IsRunningPullback && num < 250.0 && this.CheckStopBehaviourTree())
			{
				this.OnFinishPullback();
			}
		}

		// Token: 0x0604362F RID: 276015 RVA: 0x0115BC90 File Offset: 0x01159E90
		private bool CheckStopBehaviourTree()
		{
			if (ModelBase<MapModel>.Instance.IsInMapPolygon(this.ActorComp.ActorLocationProxy))
			{
				return true;
			}
			this.CacheVector.DeepCopy(this.ActorComp.ActorLocationProxy);
			this.CacheVector.Subtraction(this.EnterLocation, this.CacheVector);
			this.CacheVector.Z = 0.0;
			this.CacheVector2.DeepCopy(this.PullbackDirect);
			this.CacheVector2.Z = 0.0;
			return this.CacheVector2.DotProduct(this.CacheVector) < 0.0;
		}

		// Token: 0x06043630 RID: 276016 RVA: 0x0115BD3C File Offset: 0x01159F3C
		private void OpenGenericPrompt()
		{
			EUiViewName? viewNameByPromptId = ControllerBase<GenericPromptController>.Instance.GetViewNameByPromptId("NotOpenArea");
			if (viewNameByPromptId != null && !Singleton<UiManager>.Instance.IsViewOpen(viewNameByPromptId.Value))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOpenArea", Array.Empty<object>());
			}
		}

		// Token: 0x06043631 RID: 276017 RVA: 0x0115BD8C File Offset: 0x01159F8C
		private void OnRunPullback()
		{
			this.IsRunningPullback = true;
			Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "开始执行拉回移动操作,禁用玩家输入", default(ReadOnlySpan<ValueTuple<string, object>>));
			EntityHandle playerEntity = this.PlayerEntity;
			bool? flag;
			if (playerEntity == null)
			{
				flag = null;
			}
			else
			{
				WorldEntity entity = playerEntity.Entity;
				if (entity == null)
				{
					flag = null;
				}
				else
				{
					RoleDriveVehicleComponent component = entity.GetComponent<RoleDriveVehicleComponent>();
					flag = ((component != null) ? new bool?(component.IsOnVehicle) : null);
				}
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault();
			this.SetTeleportTimer(true, valueOrDefault);
			this.SetBattleViewVisibility(false);
			this.StopActivity();
			if (valueOrDefault)
			{
				return;
			}
			this.MoveToEnterLocation(this.PlayerEntity);
		}

		// Token: 0x06043632 RID: 276018 RVA: 0x0115BE34 File Offset: 0x0115A034
		private void OnFinishPullback()
		{
			this.IsRunningPullback = false;
			Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "退出拉回移动操作,恢复玩家控制", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SetTeleportTimer(false, false);
			this.SetBattleViewVisibility(true);
			this.RegainActivity(this.PlayerEntity);
		}

		// Token: 0x06043633 RID: 276019 RVA: 0x0115BE7F File Offset: 0x0115A07F
		public void Clear()
		{
			if (this.IsRunningPullback)
			{
				this.OnFinishPullback();
			}
			this.ToggleNotOpenFadeEffect(false);
			this.SetTeleportTimer(false, false);
		}

		// Token: 0x06043634 RID: 276020 RVA: 0x0115BEA0 File Offset: 0x0115A0A0
		public bool OnEnter()
		{
			this.EnterLocation.DeepCopy(ModelBase<MapModel>.Instance.GetLastSafeLocation());
			if (this.EnterLocation.IsNearlyZero(9.999999747378752E-05))
			{
				return false;
			}
			this.TeleportTimer = null;
			this.UpdateEntityInfo(null);
			this.ToggleNotOpenFadeEffect(true);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Map;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "--------进入了未开放区域--------";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EnterLoc", this.EnterLocation);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}

		// Token: 0x06043635 RID: 276021 RVA: 0x0115BF1C File Offset: 0x0115A11C
		public void OnExit()
		{
			Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "- - - - 离开了未开放区域- - - - ", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ToggleNotOpenFadeEffect(false);
			if (this.IsRunningPullback)
			{
				this.OnFinishPullback();
			}
		}

		// Token: 0x06043636 RID: 276022 RVA: 0x0115BF5C File Offset: 0x0115A15C
		public void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
		{
			this.UpdateEntityInfo(newEntityHandle);
			if (this.IsRunningPullback)
			{
				if (oldEntityHandle != null && oldEntityHandle.Valid)
				{
					oldEntityHandle.Entity.GetComponent<CharacterMoveComponent>().StopMoveToLocation("UnopenedAreaPullback.OnChangeRole");
					this.SetPlayerTag(oldEntityHandle, false);
				}
				this.SetPlayerTag(newEntityHandle, true);
				this.MoveToEnterLocation(newEntityHandle);
			}
		}

		// Token: 0x06043637 RID: 276023 RVA: 0x0115BFB0 File Offset: 0x0115A1B0
		private void MoveToEnterLocation(EntityHandle handle)
		{
			this.CheckTryExitClimbState(handle);
			BaseMoveComponent component = handle.Entity.GetComponent<CharacterMoveComponent>();
			MoveCharacterPoint value = new MoveCharacterPoint
			{
				Index = 0,
				Position = this.EnterLocation
			};
			MoveCharacterConfig config = new MoveCharacterConfig
			{
				Points = value,
				Navigation = false,
				IsFly = false,
				DebugMode = true,
				Loop = false,
				Distance = new float?(0f),
				Callback = delegate(ELevelEventState result)
				{
					if (this.IsRunningPullback)
					{
						this.OnFinishPullback();
					}
				},
				ReturnFalseWhenNavigationFailed = false
			};
			component.MoveAlongPath(config, "UnopenedAreaPullback.MoveToEnterLocation");
		}

		// Token: 0x06043638 RID: 276024 RVA: 0x0115C04C File Offset: 0x0115A24C
		private void CheckTryExitClimbState(EntityHandle handle)
		{
			WorldEntity entity = handle.Entity;
			CharacterUnifiedStateComponent characterUnifiedStateComponent = (entity != null) ? entity.CheckGetComponent<CharacterUnifiedStateComponent>() : null;
			if (characterUnifiedStateComponent != null && characterUnifiedStateComponent.PositionState == global::ECharPositionState.Climb)
			{
				WorldEntity entity2 = handle.Entity;
				CharacterClimbComponent characterClimbComponent = (entity2 != null) ? entity2.GetComponent<CharacterClimbComponent>() : null;
				if (characterClimbComponent == null)
				{
					return;
				}
				characterClimbComponent.ClimbPress(true);
			}
		}

		// Token: 0x06043639 RID: 276025 RVA: 0x0115C09C File Offset: 0x0115A29C
		private void TeleportToEnterLocation()
		{
			if (ModelBase<SceneTeamModel>.Instance.IsAllDid())
			{
				return;
			}
			if (this.IsRunningPullback)
			{
				this.OnFinishPullback();
			}
			Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "在未开放区域待太久，开始传送", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RequestUnOpenedAreaPullback();
		}

		// Token: 0x0604363A RID: 276026 RVA: 0x0115C0E6 File Offset: 0x0115A2E6
		private void RequestUnOpenedAreaPullback()
		{
			Singleton<Net>.Instance.Call<UnOpenedAreaPullbackResponse>(ERequestMessageId.UnOpenedAreaPullbackRequest, UnOpenedAreaPullbackRequest.Create(), delegate(UnOpenedAreaPullbackResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode == ErrorCode.ErrPlayerIsTeleportCanNotDoTeleport)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.UnOpenedAreaPullbackResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0604363B RID: 276027 RVA: 0x0115C11C File Offset: 0x0115A31C
		private void RegainActivity(EntityHandle entityHandle)
		{
			CharacterMoveComponent component = entityHandle.Entity.GetComponent<CharacterMoveComponent>();
			component.StopMove(false, "UnopenedAreaPullback.OnChangeRole");
			component.StopMoveWithCallback(ELevelEventState.Success, "UnopenedAreaPullback.OnChangeRole");
			CharacterInputComponent component2 = entityHandle.Entity.GetComponent<CharacterInputComponent>();
			component2.ClearMoveVectorCache();
			component2.SetActive(true);
			this.SetPlayerTag(entityHandle, false);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x0604363C RID: 276028 RVA: 0x0115C174 File Offset: 0x0115A374
		private void StopActivity()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, this.Reason);
			if (this.StateComp.DirectionState == ECharDirectionState.AimDirection)
			{
				this.StateComp.ExitAimStatus();
			}
			else
			{
				this.StateComp.SetDirectionState(this.StateComp.DirectionState);
			}
			if (this.SkillComp != null && this.SkillComp.CurrentSkill != null)
			{
				this.SkillComp.EndOwnerAndFollowSkills();
				this.ResetCharacterState(0, 0);
			}
			this.ActorComp.ClearInput(false, true);
			CharacterInputComponent component = this.PlayerEntity.Entity.GetComponent<CharacterInputComponent>();
			component.ClearMoveVectorCache();
			component.SetActive(false);
			this.SetPlayerTag(this.PlayerEntity, true);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x0604363D RID: 276029 RVA: 0x0115C230 File Offset: 0x0115A430
		[NullableContext(2)]
		private void UpdateEntityInfo(EntityHandle entityHandle = null)
		{
			if (entityHandle != null && entityHandle.Valid)
			{
				this.PlayerEntity = entityHandle;
			}
			else
			{
				this.PlayerEntity = ModelBase<CreatureModel>.Instance.GetEntityById(Global.BaseCharacter.EntityId);
			}
			this.ActorComp = this.PlayerEntity.Entity.GetComponent<CharacterActorComponent>();
			this.SkillComp = this.PlayerEntity.Entity.GetComponent<CharacterSkillComponent>();
			this.StateComp = this.PlayerEntity.Entity.GetComponent<CharacterUnifiedStateComponent>();
		}

		// Token: 0x0604363E RID: 276030 RVA: 0x0115C2B0 File Offset: 0x0115A4B0
		private void ResetCharacterState(int lastMode, byte lastState)
		{
			BaseTagComponent component = this.ActorComp.Entity.GetComponent<BaseTagComponent>();
			if (lastMode == 0 || (component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"])))
			{
				this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Walking,
					CustomMode = lastState,
					Context = "[UnopenedAreaPullback.ResetCharacterState] if true"
				});
				return;
			}
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = (EMovementMode)lastMode,
				CustomMode = lastState,
				Context = "[UnopenedAreaPullback.ResetCharacterState]"
			});
		}

		// Token: 0x0604363F RID: 276031 RVA: 0x0115C348 File Offset: 0x0115A548
		private void SetBattleViewVisibility(bool visible)
		{
			if (visible && this.BattleViewHide)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.AiPullback, 0);
				this.BattleViewHide = false;
			}
			if (!visible && !this.BattleViewHide)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.AiPullback, new EBattleUiChild[]
				{
					EBattleUiChild.BattleFloat
				}, 0);
				this.BattleViewHide = true;
			}
		}

		// Token: 0x06043640 RID: 276032 RVA: 0x0115C3A8 File Offset: 0x0115A5A8
		private void ToggleNotOpenFadeEffect(bool enable)
		{
			this.EnablePostProcess = enable;
			if (!enable)
			{
				Singleton<SceneEffectStateManager>.Instance.SetSceneEffectState(ESceneEffectStateType.AirWall, 0f);
			}
		}

		// Token: 0x06043641 RID: 276033 RVA: 0x0115C3C4 File Offset: 0x0115A5C4
		private void SetTeleportTimer(bool start, bool onVehicle = false)
		{
			if (!start)
			{
				if (this.TeleportTimer != null && TimerSystem.Instance.Has(this.TeleportTimer))
				{
					Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.CWZ, "移除定时器传送", default(ReadOnlySpan<ValueTuple<string, object>>));
					TimerSystem.Instance.Remove(this.TeleportTimer);
				}
				this.TeleportTimer = null;
				return;
			}
			if (this.TeleportTimer == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "开启定时器传送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Time", 20000L);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.TeleportTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.TeleportToEnterLocation();
					this.TeleportTimer = null;
				}, (float)(onVehicle ? 5000L : 20000L), null, null, true, 1f);
			}
		}

		// Token: 0x06043642 RID: 276034 RVA: 0x0115C494 File Offset: 0x0115A694
		private void SetTeleportTimerPause(bool bPause)
		{
			if (this.TeleportTimer == null || !TimerSystem.Instance.Has(this.TeleportTimer))
			{
				return;
			}
			if (bPause)
			{
				if (!this.TeleportTimer.IsPause())
				{
					Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.ZYL, "暂停传送定时器", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.TeleportTimer.Pause();
					return;
				}
			}
			else if (this.TeleportTimer.IsPause())
			{
				Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.ZYL, "恢复传送定时器", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.TeleportTimer.Resume();
			}
		}

		// Token: 0x06043643 RID: 276035 RVA: 0x0115C52C File Offset: 0x0115A72C
		private void SetPlayerTag(EntityHandle handle, bool addTag)
		{
			if (handle == null || !handle.Valid)
			{
				return;
			}
			if (addTag)
			{
				BaseTagComponent component = handle.Entity.GetComponent<BaseTagComponent>();
				if (component != null)
				{
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
				}
				if (component != null)
				{
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"]));
				}
				if (component != null)
				{
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"]));
				}
			}
			if (!addTag)
			{
				BaseTagComponent component2 = handle.Entity.GetComponent<BaseTagComponent>();
				if (component2 != null)
				{
					component2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]));
				}
				if (component2 != null)
				{
					component2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"]));
				}
				if (component2 == null)
				{
					return;
				}
				component2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"]));
			}
		}

		// Token: 0x1700A254 RID: 41556
		// (get) Token: 0x06043644 RID: 276036 RVA: 0x0115C621 File Offset: 0x0115A821
		public bool GetInPullback
		{
			get
			{
				return this.IsRunningPullback;
			}
		}

		// Token: 0x040259F3 RID: 154099
		private const int DISTANCE_FACOR = 100;

		// Token: 0x040259F4 RID: 154100
		private const double TOLERANCE_DISTANCE = 5.0;

		// Token: 0x040259F5 RID: 154101
		private const long TELEPORT_DELAY_TIME = 20000L;

		// Token: 0x040259F6 RID: 154102
		private const long TELEPORT_DELAY_TIME_GONDOLA = 5000L;

		// Token: 0x040259F7 RID: 154103
		private const double END_DISTANCE = 250.0;

		// Token: 0x040259F8 RID: 154104
		private const string TIPS_NAME = "NotOpenArea";

		// Token: 0x040259F9 RID: 154105
		private readonly string Reason = "Input Limited Action";

		// Token: 0x040259FA RID: 154106
		private readonly double ToleranceDistance = 500.0;

		// Token: 0x040259FB RID: 154107
		private bool BattleViewHide;

		// Token: 0x040259FC RID: 154108
		private bool IsRunningPullback;

		// Token: 0x040259FD RID: 154109
		private bool EnablePostProcess;

		// Token: 0x040259FE RID: 154110
		[Nullable(2)]
		private TimerHandle TeleportTimer;

		// Token: 0x040259FF RID: 154111
		private readonly global::Vector EnterLocation = global::Vector.Create();

		// Token: 0x04025A00 RID: 154112
		private readonly global::Vector PullbackDirect = global::Vector.Create();

		// Token: 0x04025A01 RID: 154113
		private readonly global::Vector CacheVector = global::Vector.Create();

		// Token: 0x04025A02 RID: 154114
		private readonly global::Vector CacheVector2 = global::Vector.Create();

		// Token: 0x04025A03 RID: 154115
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x04025A04 RID: 154116
		[Nullable(2)]
		private CharacterSkillComponent SkillComp;

		// Token: 0x04025A05 RID: 154117
		[Nullable(2)]
		private CharacterUnifiedStateComponent StateComp;

		// Token: 0x04025A06 RID: 154118
		[Nullable(2)]
		private EntityHandle PlayerEntity;
	}
}
