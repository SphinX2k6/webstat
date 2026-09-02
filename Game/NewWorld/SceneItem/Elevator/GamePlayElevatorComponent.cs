using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.Render;
using CSharpScript.Game.Utils;
using CSharpScript.Game.World.Controller;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Elevator
{
	// Token: 0x02004869 RID: 18537
	[NullableContext(1)]
	[Nullable(0)]
	public class GamePlayElevatorComponent : EntityComponent
	{
		// Token: 0x1700827F RID: 33407
		// (get) Token: 0x060303C5 RID: 197573 RVA: 0x00BBAFBA File Offset: 0x00BB91BA
		public int CurLiftFloor
		{
			get
			{
				return this.CurFloor;
			}
		}

		// Token: 0x060303C6 RID: 197574 RVA: 0x00BBAFC4 File Offset: 0x00BB91C4
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			LiftComponent liftComponent = args.GetP1<CreateEntityData>().GetParam<GamePlayElevatorComponent>() as LiftComponent;
			if (liftComponent == null)
			{
				throw new Exception("创建GamePlayElevatorComponent缺少配置参数");
			}
			this.CustomLiftBuffType = liftComponent.CustomLiftBuffType;
			this.TempVector = global::Vector.Create(0.0, 0.0, 0.0);
			this.TempLocation = global::Vector.Create(0.0, 0.0, 0.0);
			this.ActorHitElevator = new List<AActor>();
			this.ActorOnElevator = new List<AActor>();
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.EntityConfigId = new int?(this.CreatureDataComp.GetPbDataId());
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Elevator_");
			defaultInterpolatedStringHandler.AppendFormatted<int?>(this.EntityConfigId);
			this.AFMEKey = defaultInterpolatedStringHandler.ToStringAndClear();
			Aki.Protocol.Vector initLocation = this.CreatureDataComp.GetInitLocation();
			float initLocationX = (initLocation.X != 0f) ? initLocation.X : 0f;
			float initLocationY = (initLocation.Y != 0f) ? initLocation.Y : 0f;
			float initLocationZ = (initLocation.Z != 0f) ? initLocation.Z : 0f;
			this.CurFloor = ((this.CreatureDataComp.LiftFloor > 0) ? this.CreatureDataComp.LiftFloor : 1);
			this.TargetFloor = 0;
			this.IsDescending = false;
			this.IsAutoMove = (liftComponent.AutoConfig != null);
			IAutoConfig autoConfig = liftComponent.AutoConfig;
			this.IsAnnular = (autoConfig != null && autoConfig.IsCircle);
			this.IsReverseAutoRunning = false;
			IAutoConfig autoConfig2 = liftComponent.AutoConfig;
			this.HoverTime = (float)((autoConfig2 != null) ? autoConfig2.Interval : 0);
			this.HoveringTime = 0f;
			if (liftComponent.SafePoint != null)
			{
				this.SafePosition = global::Vector.Create((double)liftComponent.SafePoint.X.GetValueOrDefault(), (double)liftComponent.SafePoint.Y.GetValueOrDefault(), (double)liftComponent.SafePoint.Z.GetValueOrDefault());
			}
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			this.MoveCtx = new ElevatorContext();
			this.MoveCtx.ActorComp = this.ActorComp;
			this.MoveCtx.Entity = base.Entity;
			this.MoveCtx.EntityConfigId = this.EntityConfigId;
			this.MoveCtx.CurFloor = this.CurFloor;
			this.MoveCtx.TargetFloor = this.TargetFloor;
			this.MoveCtx.State = this.State;
			this.MoveCtx.IsAnnular = this.IsAnnular;
			this.MoveCtx.MaxSpeed = new float?((float)liftComponent.MaxSpeed);
			this.MoveCtx.UniformMovement = new bool?(liftComponent.UniformMovement);
			this.MoveCtx.DelayMoveTime = new float?(liftComponent.TurnTime);
			if (liftComponent.UseFloorSeqMarkMapping.GetValueOrDefault())
			{
				this.MoveStrategy = new ElevatorSequenceMoveStrategy();
			}
			else
			{
				this.MoveStrategy = new ElevatorNormalMoveStrategy();
			}
			this.MoveStrategy.InitFromConfig(liftComponent, this.MoveCtx, initLocationX, initLocationY, initLocationZ);
			return true;
		}

		// Token: 0x060303C7 RID: 197575 RVA: 0x00BBB2FD File Offset: 0x00BB94FD
		protected override bool OnInit()
		{
			this.MoveStrategy.OnInit();
			return true;
		}

		// Token: 0x060303C8 RID: 197576 RVA: 0x00BBB30C File Offset: 0x00BB950C
		protected override bool OnStart()
		{
			this.RangeComp = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			if (this.RangeComp != null)
			{
				this.RangeComp.AddOnPlayerOverlapCallback(new Action<bool>(this.SetPlayerOnElevatorBuff));
				this.RangeComp.AddOnEntityOverlapCallback(new Action<bool, EntityHandle>(this.RecordManipulatableItem));
			}
			this.PropComp = base.Entity.GetComponent<SceneItemPropertyComponent>();
			this.MoveStrategy.OnStart(delegate
			{
				this.TryStartAutoMove();
			});
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			return true;
		}

		// Token: 0x060303C9 RID: 197577 RVA: 0x00BBB3AC File Offset: 0x00BB95AC
		protected override bool OnClear()
		{
			if (this.RangeComp != null)
			{
				this.RangeComp.RemoveOnPlayerOverlapCallback(new Action<bool>(this.SetPlayerOnElevatorBuff));
				this.RangeComp.RemoveOnEntityOverlapCallback(new Action<bool, EntityHandle>(this.RecordManipulatableItem));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			this.EnableAFME();
			this.ClearStartMoveDelayTimer();
			this.MoveStrategy.OnClear();
			return true;
		}

		// Token: 0x060303CA RID: 197578 RVA: 0x00BBB44C File Offset: 0x00BB964C
		protected override void OnForceTick(float deltaSeconds)
		{
			this.ForceTickInternal(deltaSeconds);
		}

		// Token: 0x060303CB RID: 197579 RVA: 0x00BBB455 File Offset: 0x00BB9655
		private void ForceTickInternal(float deltaSeconds)
		{
			this.ForceTickElevatorTick(deltaSeconds);
			this.ForceTickAfterElevatorTick(deltaSeconds);
		}

		// Token: 0x060303CC RID: 197580 RVA: 0x00BBB468 File Offset: 0x00BB9668
		private void ForceTickElevatorTick(float deltaSeconds)
		{
			if (this.GetLock())
			{
				return;
			}
			if (this.State == EGamePlayElevatorState.Hovering)
			{
				this.TickHovering(deltaSeconds);
				return;
			}
			if (this.State != EGamePlayElevatorState.Moving && this.State != EGamePlayElevatorState.MovingPhaseTwo)
			{
				return;
			}
			if (this.IsDescending && this.HasEntityBelow())
			{
				return;
			}
			this.MoveStrategy.TickMove(deltaSeconds);
			this.MoveStrategy.CheckAndFinishMove(delegate
			{
				this.OnMoveArrived();
			});
		}

		// Token: 0x060303CD RID: 197581 RVA: 0x00BBB4D8 File Offset: 0x00BB96D8
		private unsafe void EnterState(EGamePlayElevatorState newState)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.CK;
			string message = "EnterState";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Before", this.State);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("After", newState);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			EGamePlayElevatorState state = this.State;
			this.State = newState;
			this.MoveCtx.State = newState;
			switch (newState)
			{
			case EGamePlayElevatorState.Stop:
			case EGamePlayElevatorState.Hovering:
				this.SetIsMoving(false);
				this.UpdateIsDescending();
				break;
			case EGamePlayElevatorState.Moving:
			{
				ElevatorNormalMoveStrategy elevatorNormalMoveStrategy = this.MoveStrategy as ElevatorNormalMoveStrategy;
				if (elevatorNormalMoveStrategy != null)
				{
					elevatorNormalMoveStrategy.SetPathMoveStartTimeStamp(UGameplayStatics.GetTimeSeconds(this.ActorComp.Owner));
				}
				this.EnterMovePhase();
				break;
			}
			case EGamePlayElevatorState.MovingPhaseTwo:
				this.EnterMovePhase();
				break;
			}
			this.OnStateChange(state, newState);
		}

		// Token: 0x060303CE RID: 197582 RVA: 0x00BBB5E8 File Offset: 0x00BB97E8
		private void ExecuteTeleport()
		{
			this.EnterState(EGamePlayElevatorState.Teleporting);
			global::Vector teleportEndPosition = ((ElevatorNormalMoveStrategy)this.MoveStrategy).GetTeleportEndPosition();
			if (this.HasPlayerInElevator())
			{
				ControllerBase<TeleportController>.Instance.TeleportElevatorAndPlayerSeparately(new ITeleportContextParam
				{
					ClientReason = "ElevatorTeleportPlayer",
					TargetPosition = teleportEndPosition.ToUeVector(false),
					ElevatorEntity = base.Entity
				}).Finally(delegate()
				{
					this.EnterState(EGamePlayElevatorState.MovingPhaseTwo);
				});
				return;
			}
			base.Entity.GetComponent<BaseActorComponent>().SetActorLocation(teleportEndPosition.ToUeVector(false), "unknown", true);
			this.EnterState(EGamePlayElevatorState.MovingPhaseTwo);
		}

		// Token: 0x060303CF RID: 197583 RVA: 0x00BBB680 File Offset: 0x00BB9880
		private void EnterMovePhase()
		{
			this.SetIsMoving(true);
			this.UpdateIsDescending();
			this.MoveStrategy.OnEnterMovePhase();
		}

		// Token: 0x060303D0 RID: 197584 RVA: 0x00BBB69A File Offset: 0x00BB989A
		private void SetIsMoving(bool value)
		{
			if (this.PropComp != null)
			{
				this.PropComp.IsMoving = value;
			}
		}

		// Token: 0x060303D1 RID: 197585 RVA: 0x00BBB6B0 File Offset: 0x00BB98B0
		private void UpdateIsDescending()
		{
			this.IsDescending = (this.TargetFloor > 0 && this.TargetFloor < this.CurFloor);
		}

		// Token: 0x060303D2 RID: 197586 RVA: 0x00BBB6D4 File Offset: 0x00BB98D4
		private void OnStateChange(EGamePlayElevatorState oldState, EGamePlayElevatorState newState)
		{
			if (oldState == newState)
			{
				return;
			}
			bool flag = oldState == EGamePlayElevatorState.Stop || oldState == EGamePlayElevatorState.Hovering;
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = newState - EGamePlayElevatorState.Moving <= 1;
				flag2 = flag3;
			}
			if (flag2)
			{
				this.OnMovingStateChange(true);
				return;
			}
			flag2 = (oldState - EGamePlayElevatorState.Moving <= 1);
			flag = flag2;
			if (flag)
			{
				bool flag3 = newState == EGamePlayElevatorState.Stop || newState == EGamePlayElevatorState.Hovering;
				flag = flag3;
			}
			if (flag)
			{
				this.OnMovingStateChange(false);
			}
		}

		// Token: 0x060303D3 RID: 197587 RVA: 0x00BBB73B File Offset: 0x00BB993B
		private long GetActiveElevatorBuffId()
		{
			if (this.CustomLiftBuffType.GetValueOrDefault() == ELiftBuffType.AllowJumpDash)
			{
				return 640003037L;
			}
			return 640003011L;
		}

		// Token: 0x060303D4 RID: 197588 RVA: 0x00BBB758 File Offset: 0x00BB9958
		[NullableContext(2)]
		public static bool IsCharacterOnMovingElevator(Entity entity)
		{
			if (entity == null || !entity.Valid)
			{
				return false;
			}
			CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
			return ((component != null) ? component.GetBuffById(640003011L) : null) != null || ((component != null) ? component.GetBuffById(640003037L) : null) != null;
		}

		// Token: 0x060303D5 RID: 197589 RVA: 0x00BBB7AC File Offset: 0x00BB99AC
		private void OnMovingStateChange(bool isMoving)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterBuffComponent characterBuffComponent;
			if (baseCharacter == null)
			{
				characterBuffComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					characterBuffComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					characterBuffComponent = ((entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null);
				}
			}
			CharacterBuffComponent characterBuffComponent2 = characterBuffComponent;
			long activeElevatorBuffId = this.GetActiveElevatorBuffId();
			if (characterBuffComponent2 != null && this.HasPlayerInElevator())
			{
				if (isMoving)
				{
					characterBuffComponent2.AddBuff(activeElevatorBuffId, new AddBuffParam
					{
						InstigatorId = characterBuffComponent2.CreatureDataId,
						Duration = new float?(this.GetRunDuration() + this.MoveCtx.DelayMoveTime.GetValueOrDefault()),
						Reason = "电梯添加buff"
					});
					Singleton<EventSystem>.Instance.EmitWithTarget(characterBuffComponent2.Entity, EEventName.ElevatorMove);
				}
				else
				{
					characterBuffComponent2.RemoveBuff(activeElevatorBuffId, -1, "电梯移除buff", null, null, null);
				}
			}
			if (this.ActorHitElevator.Count > 0)
			{
				foreach (AActor aactor in this.ActorHitElevator)
				{
					if (this.ActorOnElevator.IndexOf(aactor) != -1)
					{
						if (isMoving)
						{
							this.AttachToElevator(aactor);
						}
						else
						{
							this.DetachFromElevator(aactor);
						}
					}
				}
			}
			if (isMoving)
			{
				this.DisableAFME();
				if (this.HasPlayerInElevator())
				{
					this.DisableMotionBlur();
					return;
				}
			}
			else
			{
				this.EnableAFME();
				if (this.HasPlayerInElevator())
				{
					this.EnableMotionBlur();
				}
			}
		}

		// Token: 0x060303D6 RID: 197590 RVA: 0x00BBB924 File Offset: 0x00BB9B24
		private void DisableAFME()
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.IsSupportedAFME)
			{
				Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableAFME(this.AFMEKey);
			}
		}

		// Token: 0x060303D7 RID: 197591 RVA: 0x00BBB942 File Offset: 0x00BB9B42
		private void EnableAFME()
		{
			if (Singleton<GameSettingsDeviceRender>.Instance.IsSupportedAFME)
			{
				Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableAFME(this.AFMEKey);
			}
		}

		// Token: 0x060303D8 RID: 197592 RVA: 0x00BBB960 File Offset: 0x00BB9B60
		private void DisableMotionBlur()
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.MotionBlur.Amount 0", null);
		}

		// Token: 0x060303D9 RID: 197593 RVA: 0x00BBB972 File Offset: 0x00BB9B72
		private void EnableMotionBlur()
		{
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.MOTIONBLUR, EGameSettingsApplyReason.AnyTime, true);
		}

		// Token: 0x060303DA RID: 197594 RVA: 0x00BBB984 File Offset: 0x00BB9B84
		private void SyncElevatorStateToServer(int floor, bool isMoving)
		{
			if (this.GetLock() || this.IsInStateChange.GetValueOrDefault())
			{
				return;
			}
			this.IsInStateChange = new bool?(true);
			ElevatorState state = ElevatorState.End;
			if (isMoving)
			{
				state = ((this.TargetFloor > this.CurFloor) ? ElevatorState.Forward : ElevatorState.Reverse);
			}
			ControllerBase<LevelGamePlayController>.Instance.ElevatorStateChangeRequest(base.Entity.Id, floor, state, new Action(this.HandleStateChangeResponse));
		}

		// Token: 0x060303DB RID: 197595 RVA: 0x00BBB9F0 File Offset: 0x00BB9BF0
		private void OnMoveArrived()
		{
			ElevatorNormalMoveStrategy elevatorNormalMoveStrategy = this.MoveStrategy as ElevatorNormalMoveStrategy;
			ElevatorNormalMoveStrategy elevatorNormalMoveStrategy2 = (elevatorNormalMoveStrategy != null) ? elevatorNormalMoveStrategy : null;
			bool flag = elevatorNormalMoveStrategy2 != null && elevatorNormalMoveStrategy2.GetMoveType() == ELiftMoveType.Teleport;
			if (flag && this.State == EGamePlayElevatorState.Moving)
			{
				this.ExecuteTeleport();
				return;
			}
			if (!this.IsAutoMove && this.PendingServerTargetFloor == 0)
			{
				this.SyncElevatorStateToServer(this.TargetFloor, false);
			}
			int targetFloor = this.TargetFloor;
			this.CurFloor = targetFloor;
			this.MoveCtx.CurFloor = targetFloor;
			int num = 0;
			if (this.PendingServerTargetFloor > 0)
			{
				if (this.CurFloor != this.PendingServerTargetFloor)
				{
					num = this.PendingServerTargetFloor;
				}
				this.PendingServerTargetFloor = 0;
			}
			this.TargetFloor = 0;
			this.MoveCtx.TargetFloor = 0;
			if (flag && this.State == EGamePlayElevatorState.MovingPhaseTwo)
			{
				this.EnterState(EGamePlayElevatorState.Stop);
				if (num > 0)
				{
					this.MoveToTargetFloor(num, "TeleportPhaseTwoComplete_PendingServerTargetFloor");
				}
				return;
			}
			if (!this.IsAutoMove)
			{
				this.EnterState(EGamePlayElevatorState.Stop);
				if (num > 0)
				{
					this.MoveToTargetFloor(num, "MoveComplete_PendingServerTargetFloor");
				}
				return;
			}
			if (num <= 0)
			{
				num = this.GetNextTargetFloor();
			}
			if (this.HoverTime > 0f)
			{
				this.PendingAutoRunNextFloor = num;
				this.EnterState(EGamePlayElevatorState.Hovering);
				return;
			}
			this.MoveToTargetFloor(num, "AutoRun");
		}

		// Token: 0x060303DC RID: 197596 RVA: 0x00BBBB28 File Offset: 0x00BB9D28
		private unsafe bool CheckTargetFloorValid(int targetFloor)
		{
			if (this.GetLock())
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "CheckTargetFloorValid Failed, Elevator is Locked";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurFloor", this.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetFloor", targetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("RunningTargetFloor", this.TargetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("State", this.State);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				return false;
			}
			int floorCount = this.MoveStrategy.GetFloorCount();
			if (targetFloor < 1 || targetFloor > floorCount)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "CheckTargetFloorValid Failed, Target Floor Out Of Range";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CurFloor", this.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("TargetFloor", targetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("FloorCount", floorCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("RunningTargetFloor", this.TargetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("State", this.State);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 6));
				return false;
			}
			if (this.TargetFloor == targetFloor)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.CK;
				string message3 = "CheckTargetFloorValid Failed, Target Floor Already Running";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("CurFloor", this.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("TargetFloor", targetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("FloorCount", floorCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("State", this.State);
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
				return false;
			}
			if (this.TargetFloor != 0)
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.CK;
				string message4 = "CheckTargetFloorValid Failed, Elevator Is Running";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("CurFloor", this.CurFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("TargetFloor", targetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("RunningTargetFloor", this.TargetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("FloorCount", floorCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 5) = new ValueTuple<string, object>("State", this.State);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 6));
				this.PendingServerTargetFloor = targetFloor;
				return false;
			}
			return true;
		}

		// Token: 0x060303DD RID: 197597 RVA: 0x00BBBED3 File Offset: 0x00BBA0D3
		public bool IsMovingOrTeleporting()
		{
			return this.State == EGamePlayElevatorState.Moving || this.State == EGamePlayElevatorState.MovingPhaseTwo || this.State == EGamePlayElevatorState.Teleporting;
		}

		// Token: 0x060303DE RID: 197598 RVA: 0x00BBBEF4 File Offset: 0x00BBA0F4
		private void TryStartAutoMove()
		{
			if (this.IsAutoMove)
			{
				int nextTargetFloor = this.GetNextTargetFloor();
				this.MoveToTargetFloor(nextTargetFloor, "AutoMoveStart");
			}
		}

		// Token: 0x060303DF RID: 197599 RVA: 0x00BBBF1C File Offset: 0x00BBA11C
		public unsafe void MoveToTargetFloor(int targetFloor, string reason)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.CK;
			string message = "MoveToTargetFloor";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetFloor", targetFloor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			ElevatorSequenceMoveStrategy elevatorSequenceMoveStrategy = this.MoveStrategy as ElevatorSequenceMoveStrategy;
			if (elevatorSequenceMoveStrategy != null && elevatorSequenceMoveStrategy.IsInitializing)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "MoveToTargetFloor 电梯正在初始化, 忽略移动请求";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("TargetFloor", targetFloor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", reason);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			if (!this.PrepareMoveToFloor(targetFloor))
			{
				return;
			}
			ElevatorNormalMoveStrategy elevatorNormalMoveStrategy = this.MoveStrategy as ElevatorNormalMoveStrategy;
			if (elevatorNormalMoveStrategy != null)
			{
				elevatorNormalMoveStrategy.StartMoveByDefault();
			}
			this.StartPreparedMove(targetFloor);
		}

		// Token: 0x060303E0 RID: 197600 RVA: 0x00BBC060 File Offset: 0x00BBA260
		public unsafe void MoveToTargetFloorByTeleport(int targetFloor, float startOffset, float endOffset, bool needEmitEvent = false, float startEventOffset = 0f)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.CK;
			string message = "MoveToTargetFloorByTeleport";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetFloor", targetFloor);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!this.PrepareMoveToFloor(targetFloor))
			{
				return;
			}
			((ElevatorNormalMoveStrategy)this.MoveStrategy).StartMoveByTeleport(startOffset, endOffset, needEmitEvent, startEventOffset);
			this.StartPreparedMove(targetFloor);
		}

		// Token: 0x060303E1 RID: 197601 RVA: 0x00BBC0F8 File Offset: 0x00BBA2F8
		public unsafe void MoveToTargetFloorByCurve(int targetFloor, string curveName, float duration)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.CK;
			string message = "MoveToTargetFloorByPath";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetFloor", targetFloor);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!this.PrepareMoveToFloor(targetFloor))
			{
				return;
			}
			((ElevatorNormalMoveStrategy)this.MoveStrategy).StartMoveByCurve(curveName, duration);
			this.StartPreparedMove(targetFloor);
		}

		// Token: 0x060303E2 RID: 197602 RVA: 0x00BBC18A File Offset: 0x00BBA38A
		private bool PrepareMoveToFloor(int targetFloor)
		{
			if (!this.CheckTargetFloorValid(targetFloor))
			{
				return false;
			}
			this.TargetFloor = targetFloor;
			this.MoveCtx.TargetFloor = targetFloor;
			return true;
		}

		// Token: 0x060303E3 RID: 197603 RVA: 0x00BBC1AC File Offset: 0x00BBA3AC
		private void StartPreparedMove(int targetFloor)
		{
			this.MoveStrategy.PrepareMoveToFloor(delegate
			{
				this.StartMoveWithDelay(targetFloor);
			});
		}

		// Token: 0x060303E4 RID: 197604 RVA: 0x00BBC1E4 File Offset: 0x00BBA3E4
		private void StartMoveWithDelay(int targetFloor)
		{
			GamePlayElevatorComponent.<>c__DisplayClass60_0 CS$<>8__locals1 = new GamePlayElevatorComponent.<>c__DisplayClass60_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.targetFloor = targetFloor;
			this.ClearStartMoveDelayTimer();
			if (this.MoveCtx.DelayMoveTime != null && this.MoveCtx.DelayMoveTime.Value != 0f)
			{
				this.DelayMoveTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					CS$<>8__locals1.<>4__this.DelayMoveTimer = null;
					base.<StartMoveWithDelay>g__DoEnter|0();
				}, this.MoveCtx.DelayMoveTime.Value * 1000f, null, null, true, 1f);
				return;
			}
			CS$<>8__locals1.<StartMoveWithDelay>g__DoEnter|0();
		}

		// Token: 0x060303E5 RID: 197605 RVA: 0x00BBC275 File Offset: 0x00BBA475
		private void ClearStartMoveDelayTimer()
		{
			if (this.DelayMoveTimer != null)
			{
				TimerSystem.Instance.Remove(this.DelayMoveTimer);
				this.DelayMoveTimer = null;
			}
		}

		// Token: 0x060303E6 RID: 197606 RVA: 0x00BBC298 File Offset: 0x00BBA498
		private void PostMoveToFloor(int targetFloor)
		{
			if (this.IsAutoMove)
			{
				this.SyncElevatorStateToServer(targetFloor, true);
			}
			if (!this.IsAutoMove)
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				if (baseCharacter != null)
				{
					global::Vector actorLocationProxy = baseCharacter.CharacterActorComponent.ActorLocationProxy;
					ElevatorUsedRecord elevatorUsedRecord = new ElevatorUsedRecord();
					elevatorUsedRecord.i_config_id = (((this.EntityConfigId != null) ? this.EntityConfigId.GetValueOrDefault().ToString() : null) ?? "");
					elevatorUsedRecord.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId.ToString();
					elevatorUsedRecord.i_state_id = targetFloor.ToString();
					elevatorUsedRecord.f_player_pos_x = actorLocationProxy.X.ToString("F2");
					elevatorUsedRecord.f_player_pos_y = actorLocationProxy.Y.ToString("F2");
					elevatorUsedRecord.f_player_pos_z = actorLocationProxy.Z.ToString("F2");
					ControllerBase<LogController>.Instance.LogElevatorUsedPush(elevatorUsedRecord);
				}
			}
		}

		// Token: 0x060303E7 RID: 197607 RVA: 0x00BBC390 File Offset: 0x00BBA590
		private void TickHovering(float deltaSeconds)
		{
			this.HoveringTime += deltaSeconds * 0.001f;
			if (this.HoveringTime > this.HoverTime)
			{
				this.HoveringTime = 0f;
				int pendingAutoRunNextFloor = this.PendingAutoRunNextFloor;
				this.PendingAutoRunNextFloor = 0;
				this.EnterState(EGamePlayElevatorState.Stop);
				if (pendingAutoRunNextFloor > 0)
				{
					this.MoveToTargetFloor(pendingAutoRunNextFloor, "HoverFinished");
				}
			}
		}

		// Token: 0x060303E8 RID: 197608 RVA: 0x00BBC3EF File Offset: 0x00BBA5EF
		private bool GetLock()
		{
			return base.Entity.GetComponent<LevelTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.锁定"]);
		}

		// Token: 0x060303E9 RID: 197609 RVA: 0x00BBC410 File Offset: 0x00BBA610
		private void HandleStateChangeResponse()
		{
			this.IsInStateChange = new bool?(false);
		}

		// Token: 0x060303EA RID: 197610 RVA: 0x00BBC420 File Offset: 0x00BBA620
		private bool HasEntityBelow()
		{
			if (this.RangeComp == null)
			{
				return false;
			}
			IReadOnlyDictionary<int, EntityHandle> entitiesInRangeLocal = this.RangeComp.GetEntitiesInRangeLocal();
			if (entitiesInRangeLocal == null)
			{
				return false;
			}
			bool result = false;
			foreach (EntityHandle entityHandle in entitiesInRangeLocal.Values)
			{
				if (entityHandle != null && entityHandle.Valid && entityHandle.Entity != base.Entity)
				{
					BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
					global::Vector vector = (component != null) ? component.ActorLocationProxy : null;
					BaseActorComponent component2 = entityHandle.Entity.GetComponent<BaseActorComponent>();
					bool? flag = (component2 != null) ? new bool?(component2.HasMesh()) : null;
					CreatureDataComponent component3 = entityHandle.Entity.GetComponent<CreatureDataComponent>();
					long? num = (component3 != null) ? new long?(component3.GetSummonerId()) : null;
					bool flag2;
					if (num != null)
					{
						long? num2 = num;
						long num3 = 0L;
						flag2 = !(num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag2 = false;
					}
					bool flag3 = flag2;
					BaseActorComponent component4 = base.Entity.GetComponent<BaseActorComponent>();
					global::Vector vector2 = (component4 != null) ? component4.ActorLocationProxy : null;
					if (flag.GetValueOrDefault() && vector != null && vector.Z < vector2.Z - 100.0 && !flag3)
					{
						Entity entity = entityHandle.Entity;
						TsBaseCharacter baseCharacter = Global.BaseCharacter;
						if (entity == ((baseCharacter != null) ? baseCharacter.CharacterActorComponent.Entity : null))
						{
							WorldEntity entity2 = entityHandle.Entity;
							if (entity2 != null)
							{
								CharacterManipulateComponent component5 = entity2.GetComponent<CharacterManipulateComponent>();
								if (component5 != null)
								{
									component5.StopManipulate();
								}
							}
						}
						this.SetEntitySafePos(entityHandle.Entity);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060303EB RID: 197611 RVA: 0x00BBC5D8 File Offset: 0x00BBA7D8
		private void SetEntitySafePos(Entity entity)
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			global::Vector vector = (component != null) ? component.ActorLocationProxy : null;
			global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
			if (vector == null || actorLocationProxy == null)
			{
				return;
			}
			if (this.SafePosition == null)
			{
				actorLocationProxy.Subtraction(vector, this.TempVector);
				this.TempVector.Z = 0.0;
				BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
				int num = 3;
				int i = 0;
				while (i <= num)
				{
					this.TempLocation.X = vector.X + this.TempVector.X * (double)((float)i / (float)num);
					this.TempLocation.Y = vector.Y + this.TempVector.Y * (double)((float)i / (float)num);
					this.TempLocation.Z = vector.Z;
					ValueTuple<bool, UKuroHitResult> valueTuple = TraceUtils.LineTraceWithLocation(this.TempLocation, 2000f, 0f);
					bool item = valueTuple.Item1;
					UKuroHitResult item2 = valueTuple.Item2;
					if (item && !item2.bStartPenetrating)
					{
						global::Vector commonHitLocation = ModelBase<TraceElementModel>.Instance.CommonHitLocation;
						Singleton<TraceElementCommon>.Instance.GetImpactPoint(item2, 0, commonHitLocation);
						float radius = component2.GetRadius();
						commonHitLocation.Z += (double)radius;
						CharacterActorComponent component3 = entity.GetComponent<CharacterActorComponent>();
						if (component3 != null)
						{
							int handle = component2.DisableCollision("[GamePlayElevatorComponent.SetEntitySafePos]");
							component3.TeleportAndFindStandLocation(commonHitLocation, true);
							component2.EnableCollision(handle);
							return;
						}
						SceneItemManipulatableComponent component4 = entity.GetComponent<SceneItemManipulatableComponent>();
						if (component4 != null)
						{
							component4.TryEnableTick(true);
						}
						component2.SetActorLocation(commonHitLocation.ToUeVector(false), base.GetType().Name, false);
						return;
					}
					else
					{
						i++;
					}
				}
				return;
			}
			BaseActorComponent component5 = entity.GetComponent<BaseActorComponent>();
			float radius2 = component5.GetRadius();
			global::Vector vector2 = global::Vector.Create(actorLocationProxy.X + this.SafePosition.X, actorLocationProxy.Y + this.SafePosition.Y, actorLocationProxy.Z + this.SafePosition.Z + (double)radius2);
			CharacterActorComponent component6 = entity.GetComponent<CharacterActorComponent>();
			if (component6 != null)
			{
				int handle2 = component5.DisableCollision("[GamePlayElevatorComponent.SetEntitySafePos]");
				component6.TeleportAndFindStandLocation(vector2, true);
				component5.EnableCollision(handle2);
				return;
			}
			component5.SetActorLocation(vector2.ToUeVector(false), base.GetType().Name, false);
		}

		// Token: 0x060303EC RID: 197612 RVA: 0x00BBC818 File Offset: 0x00BBAA18
		private bool HasPlayerInElevator()
		{
			if (this.RangeComp == null)
			{
				return false;
			}
			IReadOnlyDictionary<int, EntityHandle> entitiesInRangeLocal = this.RangeComp.GetEntitiesInRangeLocal();
			if (entitiesInRangeLocal == null)
			{
				return false;
			}
			int key = -1;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null)
			{
				key = baseCharacter.CharacterActorComponent.Entity.Id;
			}
			return entitiesInRangeLocal.ContainsKey(key);
		}

		// Token: 0x060303ED RID: 197613 RVA: 0x00BBC864 File Offset: 0x00BBAA64
		private void RecordManipulatableItem(bool isEnter, EntityHandle handle)
		{
			WorldEntity entity = handle.Entity;
			if (entity.GetComponent<SceneItemManipulatableComponent>() != null)
			{
				BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
				int num = this.ActorOnElevator.IndexOf(component.Owner);
				if (isEnter)
				{
					if (num == -1)
					{
						this.ActorOnElevator.Add(component.Owner);
					}
				}
				else if (num != -1)
				{
					this.ActorOnElevator.RemoveAt(num);
				}
				num = this.ActorHitElevator.IndexOf(component.Owner);
				if (num != -1)
				{
					this.ActorHitElevator.RemoveAt(num);
				}
			}
		}

		// Token: 0x060303EE RID: 197614 RVA: 0x00BBC8E8 File Offset: 0x00BBAAE8
		private void SetPlayerOnElevatorBuff(bool isEnter)
		{
			if (!this.IsMovingOrTeleporting())
			{
				return;
			}
			long activeElevatorBuffId = this.GetActiveElevatorBuffId();
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null)
			{
				CharacterBuffComponent component = baseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterBuffComponent>();
				if (component != null)
				{
					if (isEnter)
					{
						double z = baseCharacter.D_K2_GetActorLocation().Z;
						double z2 = this.ActorComp.ActorLocationProxy.Z;
						if (z > z2)
						{
							component.AddBuff(activeElevatorBuffId, new AddBuffParam
							{
								InstigatorId = component.CreatureDataId,
								Duration = new float?(this.GetRunDuration()),
								Reason = "电梯添加buff"
							});
							Singleton<EventSystem>.Instance.EmitWithTarget(component.Entity, EEventName.ElevatorMove);
							this.DisableMotionBlur();
							return;
						}
					}
					else
					{
						component.RemoveBuff(activeElevatorBuffId, -1, "电梯移除buff", null, null, null);
						this.EnableMotionBlur();
					}
				}
			}
		}

		// Token: 0x060303EF RID: 197615 RVA: 0x00BBC9D1 File Offset: 0x00BBABD1
		private float GetRunDuration()
		{
			return this.MoveStrategy.GetMoveDuration();
		}

		// Token: 0x060303F0 RID: 197616 RVA: 0x00BBC9E0 File Offset: 0x00BBABE0
		private unsafe int GetNextTargetFloor()
		{
			int floorCount = this.MoveStrategy.GetFloorCount();
			if (floorCount == 0)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CK;
				string message = "GetNextTargetFloor 楼层列表为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return this.CurFloor;
			}
			int num = this.CurFloor - 1;
			if (num < 0 || num >= floorCount)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "GetNextTargetFloor 当前楼层索引越界";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityConfigId", this.EntityConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurFloor", this.CurFloor);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return 1;
			}
			int num2 = this.IsReverseAutoRunning ? (num - 1) : (num + 1);
			if (this.IsAnnular)
			{
				if (num2 >= floorCount)
				{
					num2 = 0;
				}
				else if (num2 < 0)
				{
					num2 = floorCount - 1;
				}
			}
			else if (num2 >= floorCount)
			{
				num2 = num - 1;
				this.IsReverseAutoRunning = true;
			}
			else if (num2 < 0)
			{
				num2 = num + 1;
				this.IsReverseAutoRunning = false;
			}
			return num2 + 1;
		}

		// Token: 0x060303F1 RID: 197617 RVA: 0x00BBCAFC File Offset: 0x00BBACFC
		[NullableContext(2)]
		private void OnManipulatableSceneItemHit(AActor selfActor, AActor otherActor, FVector normalImpulse, [Nullable(1)] FHitResult hit)
		{
			EntityHandle entityByActor = ActorUtils.GetEntityByActor(otherActor, true);
			if (entityByActor == null)
			{
				return;
			}
			if (entityByActor.Entity.GetComponent<SceneItemManipulatableComponent>() == null)
			{
				return;
			}
			if (this.ActorHitElevator.IndexOf(otherActor) == -1)
			{
				if (this.IsMovingOrTeleporting() && this.ActorOnElevator.IndexOf(otherActor) != -1)
				{
					this.AttachToElevator(otherActor);
				}
				this.ActorHitElevator.Add(otherActor);
			}
		}

		// Token: 0x060303F2 RID: 197618 RVA: 0x00BBCB5C File Offset: 0x00BBAD5C
		protected void OnSceneInteractionLoadCompleted()
		{
			SceneItemActorComponent component = base.Entity.GetComponent<SceneItemActorComponent>();
			AActor mainCollisionActor = SceneInteractionManager.Get().GetMainCollisionActor(component.GetSceneInteractionLevelHandleId());
			this.PrimitiveComp = (((mainCollisionActor != null) ? mainCollisionActor.GetComponentByClass(UPrimitiveComponent.StaticClass()) : null) as UPrimitiveComponent);
			if (this.PrimitiveComp != null)
			{
				mainCollisionActor.OnActorHit.Add(new Action<AActor, AActor, FVector, FHitResult>(this.OnManipulatableSceneItemHit));
				this.PrimitiveComp.SetNotifyRigidBodyCollision(true);
			}
		}

		// Token: 0x060303F3 RID: 197619 RVA: 0x00BBCBD4 File Offset: 0x00BBADD4
		private void AttachToElevator(AActor actor)
		{
			EntityHandle entityByActor = ActorUtils.GetEntityByActor(actor, true);
			if (entityByActor == null)
			{
				return;
			}
			SceneItemManipulatableComponent component = entityByActor.Entity.GetComponent<SceneItemManipulatableComponent>();
			if (component == null)
			{
				return;
			}
			component.TryDisableTick("[GamePlayElevator.AttachToElevator] 上电梯关闭Tick");
			SceneItemActorComponent component2 = base.Entity.GetComponent<SceneItemActorComponent>();
			ControllerBase<AttachToActorController>.Instance.AttachToActor(actor, component2.Owner, EDetachType.DestroyExternal, "GamePlayElevatorComponent.AttachToElevator", null, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true, false, false, false);
		}

		// Token: 0x060303F4 RID: 197620 RVA: 0x00BBCC40 File Offset: 0x00BBAE40
		private void DetachFromElevator(AActor actor)
		{
			ControllerBase<AttachToActorController>.Instance.DetachActor(actor, false, "GamePlayElevatorComponent.DetachFromElevator", EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
			EntityHandle entityByActor = ActorUtils.GetEntityByActor(actor, true);
			if (entityByActor == null)
			{
				return;
			}
			SceneItemManipulatableComponent component = entityByActor.Entity.GetComponent<SceneItemManipulatableComponent>();
			if (component == null)
			{
				return;
			}
			component.TryEnableTick(true);
		}

		// Token: 0x060303F5 RID: 197621 RVA: 0x00BBCC88 File Offset: 0x00BBAE88
		public void RegisterAfterElevatorTickHandler(object key, Action<float> tickHandler)
		{
			HashSet<Action<float>> hashSet;
			if (!this.AfterElevatorTickHandlers.TryGetValue(key, out hashSet))
			{
				hashSet = new HashSet<Action<float>>();
				this.AfterElevatorTickHandlers[key] = hashSet;
			}
			hashSet.Add(tickHandler);
		}

		// Token: 0x060303F6 RID: 197622 RVA: 0x00BBCCC0 File Offset: 0x00BBAEC0
		public void UnRegisterAfterElevatorTickHandlers(object key)
		{
			this.AfterElevatorTickHandlers.Remove(key);
		}

		// Token: 0x060303F7 RID: 197623 RVA: 0x00BBCCD0 File Offset: 0x00BBAED0
		private void ForceTickAfterElevatorTick(float deltaSeconds)
		{
			this.TempAfterElevatorTickHandlers.Clear();
			foreach (HashSet<Action<float>> collection in this.AfterElevatorTickHandlers.Values)
			{
				this.TempAfterElevatorTickHandlers.AddRange(collection);
			}
			foreach (Action<float> action in this.TempAfterElevatorTickHandlers)
			{
				if (action != null)
				{
					action(deltaSeconds);
				}
			}
			this.TempAfterElevatorTickHandlers.Clear();
		}

		// Token: 0x060303F8 RID: 197624 RVA: 0x00BBCD8C File Offset: 0x00BBAF8C
		protected override void OnActivate()
		{
			if (!Singleton<Info>.Instance.EnableForceTick && base.Active)
			{
				ControllerBase<ComponentForceTickController>.Instance.RegisterPreMoveTick(this, new Action<float>(this.ForceTickInternal));
			}
		}

		// Token: 0x060303F9 RID: 197625 RVA: 0x00BBCDB9 File Offset: 0x00BBAFB9
		protected override void OnEnable()
		{
			if (!Singleton<Info>.Instance.EnableForceTick)
			{
				Entity entity = base.Entity;
				if (entity != null && entity.IsInit)
				{
					ControllerBase<ComponentForceTickController>.Instance.RegisterPreMoveTick(this, new Action<float>(this.ForceTickInternal));
				}
			}
		}

		// Token: 0x060303FA RID: 197626 RVA: 0x00BBCDF2 File Offset: 0x00BBAFF2
		protected override bool OnEnd()
		{
			if (!Singleton<Info>.Instance.EnableForceTick)
			{
				ControllerBase<ComponentForceTickController>.Instance.UnregisterPreMoveTick(this);
			}
			return true;
		}

		// Token: 0x060303FB RID: 197627 RVA: 0x00BBCE0C File Offset: 0x00BBB00C
		protected override void OnDisable(string reason)
		{
			if (!Singleton<Info>.Instance.EnableForceTick)
			{
				ControllerBase<ComponentForceTickController>.Instance.UnregisterPreMoveTick(this);
			}
		}

		// Token: 0x060303FC RID: 197628 RVA: 0x00BBCE28 File Offset: 0x00BBB028
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			GamePlayElevatorComponent gamePlayElevatorComponent = (GamePlayElevatorComponent)componentTemplate;
			if (base.CanResetComponentProperty("State"))
			{
				this.State = gamePlayElevatorComponent.State;
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (gamePlayElevatorComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SafePosition"))
			{
				if (gamePlayElevatorComponent.SafePosition == null)
				{
					this.SafePosition = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SafePosition), "SafePosition"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsInStateChange"))
			{
				this.IsInStateChange = gamePlayElevatorComponent.IsInStateChange;
			}
			if (base.CanResetComponentProperty("RangeComp"))
			{
				if (gamePlayElevatorComponent.RangeComp == null)
				{
					this.RangeComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>(this.RangeComp), "RangeComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PropComp"))
			{
				if (gamePlayElevatorComponent.PropComp == null)
				{
					this.PropComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemPropertyComponent>(this.PropComp), "PropComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (gamePlayElevatorComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EntityConfigId"))
			{
				this.EntityConfigId = gamePlayElevatorComponent.EntityConfigId;
			}
			if (base.CanResetComponentProperty("AFMEKey"))
			{
				this.AFMEKey = gamePlayElevatorComponent.AFMEKey;
			}
			if (base.CanResetComponentProperty("HoveringTime"))
			{
				this.HoveringTime = gamePlayElevatorComponent.HoveringTime;
			}
			if (base.CanResetComponentProperty("HoverTime"))
			{
				this.HoverTime = gamePlayElevatorComponent.HoverTime;
			}
			if (base.CanResetComponentProperty("CurFloor"))
			{
				this.CurFloor = gamePlayElevatorComponent.CurFloor;
			}
			if (base.CanResetComponentProperty("TargetFloor"))
			{
				this.TargetFloor = gamePlayElevatorComponent.TargetFloor;
			}
			if (base.CanResetComponentProperty("PendingServerTargetFloor"))
			{
				this.PendingServerTargetFloor = gamePlayElevatorComponent.PendingServerTargetFloor;
			}
			if (base.CanResetComponentProperty("IsDescending"))
			{
				this.IsDescending = gamePlayElevatorComponent.IsDescending;
			}
			if (base.CanResetComponentProperty("IsAutoMove"))
			{
				this.IsAutoMove = gamePlayElevatorComponent.IsAutoMove;
			}
			if (base.CanResetComponentProperty("IsAnnular"))
			{
				this.IsAnnular = gamePlayElevatorComponent.IsAnnular;
			}
			if (base.CanResetComponentProperty("IsReverseAutoRunning"))
			{
				this.IsReverseAutoRunning = gamePlayElevatorComponent.IsReverseAutoRunning;
			}
			if (base.CanResetComponentProperty("ActorHitElevator"))
			{
				if (gamePlayElevatorComponent.ActorHitElevator == null)
				{
					this.ActorHitElevator = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.ActorHitElevator), "ActorHitElevator"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorOnElevator"))
			{
				if (gamePlayElevatorComponent.ActorOnElevator == null)
				{
					this.ActorOnElevator = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.ActorOnElevator), "ActorOnElevator"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PrimitiveComp"))
			{
				if (gamePlayElevatorComponent.PrimitiveComp == null)
				{
					this.PrimitiveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UPrimitiveComponent>(this.PrimitiveComp), "PrimitiveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CustomLiftBuffType"))
			{
				this.CustomLiftBuffType = gamePlayElevatorComponent.CustomLiftBuffType;
			}
			if (base.CanResetComponentProperty("PendingAutoRunNextFloor"))
			{
				this.PendingAutoRunNextFloor = gamePlayElevatorComponent.PendingAutoRunNextFloor;
			}
			if (base.CanResetComponentProperty("MoveCtx"))
			{
				if (gamePlayElevatorComponent.MoveCtx == null)
				{
					this.MoveCtx = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ElevatorContext>(this.MoveCtx), "MoveCtx"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveStrategy"))
			{
				if (gamePlayElevatorComponent.MoveStrategy == null)
				{
					this.MoveStrategy = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IElevatorMoveStrategy>(this.MoveStrategy), "MoveStrategy"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DelayMoveTimer"))
			{
				if (gamePlayElevatorComponent.DelayMoveTimer == null)
				{
					this.DelayMoveTimer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.DelayMoveTimer), "DelayMoveTimer"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TempVector"))
			{
				if (gamePlayElevatorComponent.TempVector == null)
				{
					this.TempVector = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector), "TempVector"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TempLocation"))
			{
				if (gamePlayElevatorComponent.TempLocation == null)
				{
					this.TempLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempLocation), "TempLocation"))
				{
					return false;
				}
			}
			return (!base.CanResetComponentProperty("AfterElevatorTickHandlers") || gamePlayElevatorComponent.AfterElevatorTickHandlers == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<object, HashSet<Action<float>>>>(this.AfterElevatorTickHandlers), "AfterElevatorTickHandlers")) && (!base.CanResetComponentProperty("TempAfterElevatorTickHandlers") || gamePlayElevatorComponent.TempAfterElevatorTickHandlers == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<Action<float>>>(this.TempAfterElevatorTickHandlers), "TempAfterElevatorTickHandlers"));
		}

		// Token: 0x0401BB34 RID: 113460
		private EGamePlayElevatorState State;

		// Token: 0x0401BB35 RID: 113461
		[Nullable(2)]
		private BaseActorComponent ActorComp;

		// Token: 0x0401BB36 RID: 113462
		[Nullable(2)]
		private global::Vector SafePosition;

		// Token: 0x0401BB37 RID: 113463
		private bool? IsInStateChange;

		// Token: 0x0401BB38 RID: 113464
		[Nullable(2)]
		private CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent RangeComp;

		// Token: 0x0401BB39 RID: 113465
		[Nullable(2)]
		private SceneItemPropertyComponent PropComp;

		// Token: 0x0401BB3A RID: 113466
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BB3B RID: 113467
		private int? EntityConfigId;

		// Token: 0x0401BB3C RID: 113468
		private string AFMEKey = "";

		// Token: 0x0401BB3D RID: 113469
		private float HoveringTime;

		// Token: 0x0401BB3E RID: 113470
		private float HoverTime;

		// Token: 0x0401BB3F RID: 113471
		private int CurFloor = 1;

		// Token: 0x0401BB40 RID: 113472
		private int TargetFloor;

		// Token: 0x0401BB41 RID: 113473
		private int PendingServerTargetFloor;

		// Token: 0x0401BB42 RID: 113474
		private bool IsDescending;

		// Token: 0x0401BB43 RID: 113475
		private bool IsAutoMove;

		// Token: 0x0401BB44 RID: 113476
		private bool IsAnnular;

		// Token: 0x0401BB45 RID: 113477
		private bool IsReverseAutoRunning;

		// Token: 0x0401BB46 RID: 113478
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<AActor> ActorHitElevator;

		// Token: 0x0401BB47 RID: 113479
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<AActor> ActorOnElevator;

		// Token: 0x0401BB48 RID: 113480
		[Nullable(2)]
		private UPrimitiveComponent PrimitiveComp;

		// Token: 0x0401BB49 RID: 113481
		private ELiftBuffType? CustomLiftBuffType;

		// Token: 0x0401BB4A RID: 113482
		private int PendingAutoRunNextFloor;

		// Token: 0x0401BB4B RID: 113483
		private ElevatorContext MoveCtx;

		// Token: 0x0401BB4C RID: 113484
		private IElevatorMoveStrategy MoveStrategy;

		// Token: 0x0401BB4D RID: 113485
		[Nullable(2)]
		private TimerHandle DelayMoveTimer;

		// Token: 0x0401BB4E RID: 113486
		[Nullable(2)]
		private global::Vector TempVector;

		// Token: 0x0401BB4F RID: 113487
		[Nullable(2)]
		private global::Vector TempLocation;

		// Token: 0x0401BB50 RID: 113488
		private readonly Dictionary<object, HashSet<Action<float>>> AfterElevatorTickHandlers = new Dictionary<object, HashSet<Action<float>>>();

		// Token: 0x0401BB51 RID: 113489
		private readonly List<Action<float>> TempAfterElevatorTickHandlers = new List<Action<float>>();
	}
}
