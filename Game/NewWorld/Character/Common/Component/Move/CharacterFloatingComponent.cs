using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004920 RID: 18720
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterFloatingComponent : EntityComponent, IComponentDependency, IStaticVariableResetter
	{
		// Token: 0x06030EE2 RID: 200418 RVA: 0x00C22F3A File Offset: 0x00C2113A
		static CharacterFloatingComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CharacterFloatingComponent.CreateStaticDefaultValue), new Action(CharacterFloatingComponent.ResetStaticDefaultValue));
		}

		// Token: 0x17008350 RID: 33616
		// (get) Token: 0x06030EE3 RID: 200419 RVA: 0x00C22F79 File Offset: 0x00C21179
		public static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(CharacterMoveComponent)
				};
			}
		}

		// Token: 0x17008351 RID: 33617
		// (get) Token: 0x06030EE4 RID: 200420 RVA: 0x00C22F8E File Offset: 0x00C2118E
		public bool IsFloating
		{
			get
			{
				return this.InFloatingState;
			}
		}

		// Token: 0x17008352 RID: 33618
		// (get) Token: 0x06030EE5 RID: 200421 RVA: 0x00C22F96 File Offset: 0x00C21196
		public bool IsFloatingMove
		{
			get
			{
				return this.Speed > 1f;
			}
		}

		// Token: 0x17008353 RID: 33619
		// (get) Token: 0x06030EE6 RID: 200422 RVA: 0x00C22FA8 File Offset: 0x00C211A8
		public Vector FloatingLocalDirection
		{
			get
			{
				Vector tempVector = this.TempVector;
				FTransformDouble actorTransform = this.ActorComp.ActorTransform;
				FVectorDouble fvectorDouble = this.TempInputDirection.ToUeVector(false);
				FVectorDouble fvectorDouble2 = actorTransform.InverseTransformVector(fvectorDouble);
				tempVector.FromUeVector(fvectorDouble2);
				return this.TempVector;
			}
		}

		// Token: 0x17008354 RID: 33620
		// (get) Token: 0x06030EE7 RID: 200423 RVA: 0x00C22FEB File Offset: 0x00C211EB
		public float FloatingMoveMix
		{
			get
			{
				return this.FloatingMoveMixInternal;
			}
		}

		// Token: 0x17008355 RID: 33621
		// (get) Token: 0x06030EE8 RID: 200424 RVA: 0x00C22FF3 File Offset: 0x00C211F3
		public float FloatingSpeedMix
		{
			get
			{
				return this.FloatingSpeedMixInternal;
			}
		}

		// Token: 0x17008356 RID: 33622
		// (get) Token: 0x06030EE9 RID: 200425 RVA: 0x00C22FFB File Offset: 0x00C211FB
		public float Speed
		{
			get
			{
				return this.SpeedInternal;
			}
		}

		// Token: 0x06030EEA RID: 200426 RVA: 0x00C23003 File Offset: 0x00C21203
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06030EEB RID: 200427 RVA: 0x00C23008 File Offset: 0x00C21208
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
			this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
			this.TimeScaleComp = base.Entity.GetComponent<CharacterTimeScaleComponent>();
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.InputComp = base.Entity.GetComponent<CharacterInputComponent>();
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			if (creatureDataComp != null && creatureDataComp.Valid && ModelBase<CreatureModel>.Instance.GetPlayerId() == this.CreatureDataComp.GetPlayerId())
			{
				this.AddFloatingStateListener();
				this.InitFloatingStateMachine();
				Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
				Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
				Singleton<EventSystem>.Instance.AddWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
				Singleton<EventSystem>.Instance.AddWithTarget<ECharMoveState, ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.OnUnifiedMoveStateChanged));
				Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnRoleGoUpEnable, new Action(this.OnRoleInheritTransform));
			}
			this.ComponentDisableHandle = base.Disable("悬浮组件默认禁用");
			return true;
		}

		// Token: 0x06030EEC RID: 200428 RVA: 0x00C231AC File Offset: 0x00C213AC
		protected override void OnEnable()
		{
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterFloatingState(true);
			this.ClearCacheInputDirect();
			Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnBeginSkill));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
		}

		// Token: 0x06030EED RID: 200429 RVA: 0x00C2320C File Offset: 0x00C2140C
		protected override void OnDisable(string reason)
		{
			this.ClearCacheInputDirect();
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnBeginSkill)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnBeginSkill));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
			}
		}

		// Token: 0x06030EEE RID: 200430 RVA: 0x00C232A0 File Offset: 0x00C214A0
		protected override bool OnEnd()
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.IsAutonomousProxy)
			{
				return true;
			}
			this.StateMachine = null;
			ITagTask floatingEnableListener = this.FloatingEnableListener;
			if (floatingEnableListener != null)
			{
				floatingEnableListener.EndTask();
			}
			ITagTask floatingMoveModeListener = this.FloatingMoveModeListener;
			if (floatingMoveModeListener != null)
			{
				floatingMoveModeListener.EndTask();
			}
			ITagTask floatingSprintListener = this.FloatingSprintListener;
			if (floatingSprintListener != null)
			{
				floatingSprintListener.EndTask();
			}
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnBeforeChangeRole, new Action<EntityHandle, EntityHandle>(this.OnBeforeChangeRole));
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.RemoveWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
			Singleton<EventSystem>.Instance.RemoveWithTarget<ECharMoveState, ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.OnUnifiedMoveStateChanged));
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnRoleGoUpEnable, new Action(this.OnRoleInheritTransform));
			return true;
		}

		// Token: 0x06030EEF RID: 200431 RVA: 0x00C233C4 File Offset: 0x00C215C4
		public void EnableFloating(string daPath)
		{
			if (this.InFloatingState)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[悬浮模式]重复进入";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("daPath", daPath);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.InFloatingState = true;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[悬浮模式][总开关]进入悬浮模式";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("daPath", daPath);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.InitConfig(daPath, new Action(this.EnterFloatingInternal));
		}

		// Token: 0x06030EF0 RID: 200432 RVA: 0x00C23444 File Offset: 0x00C21644
		public void DisableFloating()
		{
			if (!this.InFloatingState)
			{
				return;
			}
			this.InFloatingState = false;
			Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.LJM, "[悬浮模式][总开关]离开悬浮模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.LeaveFloatingInternal();
		}

		// Token: 0x06030EF1 RID: 200433 RVA: 0x00C23483 File Offset: 0x00C21683
		public void JumpPressInAir()
		{
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterRiseState();
		}

		// Token: 0x06030EF2 RID: 200434 RVA: 0x00C23491 File Offset: 0x00C21691
		public void JumpRelease()
		{
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterFloatingState(false);
		}

		// Token: 0x06030EF3 RID: 200435 RVA: 0x00C234A0 File Offset: 0x00C216A0
		public void CtrlPress()
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.EnterDropState();
			}
		}

		// Token: 0x06030EF4 RID: 200436 RVA: 0x00C234BA File Offset: 0x00C216BA
		public void CtrlRelease()
		{
			if (this.FloatingMoveType == EFloatingMovementType.Drop)
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.EnterFloatingState(false);
				return;
			}
			bool debug2 = CharacterFloatingComponent.Debug;
			this.EnterDropState();
		}

		// Token: 0x06030EF5 RID: 200437 RVA: 0x00C234DF File Offset: 0x00C216DF
		private void EnterDefaultState()
		{
			if (this.FloatingMoveType == EFloatingMovementType.None)
			{
				return;
			}
			this.UpdateState(EFloatingMovementType.None);
		}

		// Token: 0x06030EF6 RID: 200438 RVA: 0x00C234F2 File Offset: 0x00C216F2
		private void EnterRiseState()
		{
			this.EnterFloatingInternal();
			if (this.FloatingMoveType == EFloatingMovementType.Rise)
			{
				return;
			}
			if (this.UpdateState(EFloatingMovementType.Rise))
			{
				return;
			}
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterFloatingState(false);
		}

		// Token: 0x06030EF7 RID: 200439 RVA: 0x00C2351B File Offset: 0x00C2171B
		private void EnterFloatingState(bool forceEnter = false)
		{
			this.EnterFloatingInternal();
			if (this.FloatingMoveType == EFloatingMovementType.Floating && !forceEnter)
			{
				return;
			}
			if (this.UpdateState(EFloatingMovementType.Floating))
			{
				return;
			}
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterDropState();
		}

		// Token: 0x06030EF8 RID: 200440 RVA: 0x00C23546 File Offset: 0x00C21746
		private void EnterDropState()
		{
			this.EnterFloatingInternal();
			if (this.FloatingMoveType == EFloatingMovementType.Drop)
			{
				return;
			}
			if (this.UpdateState(EFloatingMovementType.Drop))
			{
				return;
			}
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterWalkState();
		}

		// Token: 0x06030EF9 RID: 200441 RVA: 0x00C2356E File Offset: 0x00C2176E
		private void EnterWalkState()
		{
			if (this.FloatingMoveType == EFloatingMovementType.Walk)
			{
				return;
			}
			if (this.UpdateState(EFloatingMovementType.Walk))
			{
				return;
			}
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterDropState();
		}

		// Token: 0x06030EFA RID: 200442 RVA: 0x00C23590 File Offset: 0x00C21790
		private bool UpdateState(EFloatingMovementType state)
		{
			return this.StateMachine.Switch(state);
		}

		// Token: 0x06030EFB RID: 200443 RVA: 0x00C235A0 File Offset: 0x00C217A0
		private void EnterFloatingInternal()
		{
			CharacterUnifiedStateComponent stateComp = this.StateComp;
			if (stateComp == null || stateComp.PositionState != ECharPositionState.Floating)
			{
				CharacterMoveComponent moveComp = this.MoveComp;
				if (moveComp != null)
				{
					CharacterActorComponent actorComp = moveComp.ActorComp;
					if (actorComp != null)
					{
						actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
						{
							Mode = EMovementMode.MOVE_Custom,
							CustomMode = 15,
							Context = "[CharacterFloatingComponent.Enter]"
						});
					}
				}
			}
			if (this.ComponentDisableHandle != -1)
			{
				int componentDisableHandle = this.ComponentDisableHandle;
				this.ComponentDisableHandle = -1;
				base.Enable(new int?(componentDisableHandle), "[悬浮模式][总开关]开启悬浮组件Tick功能");
			}
		}

		// Token: 0x06030EFC RID: 200444 RVA: 0x00C23630 File Offset: 0x00C21830
		private void LeaveFloatingInternal()
		{
			bool flag = this.IsOnGround || this.IsNearGround;
			this.ReleaseGroundTag();
			this.IsOnWater = false;
			this.IsOnGround = false;
			this.IsNearGround = false;
			this.CurrentBase = null;
			CharacterUnifiedStateComponent stateComp = this.StateComp;
			if (stateComp != null && stateComp.PositionState == ECharPositionState.Floating)
			{
				if (flag)
				{
					CharacterActorComponent actorComp = this.ActorComp;
					if (actorComp != null)
					{
						actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
						{
							Mode = EMovementMode.MOVE_Walking,
							Context = "[CharacterFloatingComponent.Leave] Walking"
						});
					}
				}
				else
				{
					CharacterMoveComponent moveComp = this.MoveComp;
					if (moveComp != null)
					{
						CharacterActorComponent actorComp2 = moveComp.ActorComp;
						if (actorComp2 != null)
						{
							actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
							{
								Mode = EMovementMode.MOVE_Falling,
								Context = "[CharacterFloatingComponent.Leave] Falling"
							});
						}
					}
				}
			}
			CharacterMoveComponent moveComp2 = this.MoveComp;
			if (moveComp2 != null)
			{
				moveComp2.SetForceSpeed(Vector.ZeroVectorProxy);
			}
			if (this.ComponentDisableHandle == -1)
			{
				this.ComponentDisableHandle = base.Disable("[悬浮模式][总开关]关闭悬浮组件Tick功能");
			}
		}

		// Token: 0x06030EFD RID: 200445 RVA: 0x00C23722 File Offset: 0x00C21922
		private bool QueryInputAction(AkiClient.Game.Aki.Character.Input.Enum.EInputAction inputAction)
		{
			return this.InputComp != null && ControllerBase<InputController>.Instance.IsKeyDown(inputAction);
		}

		// Token: 0x06030EFE RID: 200446 RVA: 0x00C2373E File Offset: 0x00C2193E
		private void OnPositionStateChanged(ECharPositionState oldPositionState, ECharPositionState newPositionState)
		{
			if (!this.InFloatingState)
			{
				return;
			}
			if (newPositionState == ECharPositionState.Floating)
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.EnterFloatingState(false);
			}
			else if (oldPositionState == ECharPositionState.Floating)
			{
				bool debug2 = CharacterFloatingComponent.Debug;
				this.EnterDefaultState();
			}
			this.ClearCacheInputDirect();
		}

		// Token: 0x06030EFF RID: 200447 RVA: 0x00C23772 File Offset: 0x00C21972
		private void OnUnifiedMoveStateChanged(ECharMoveState oldMoveState, ECharMoveState newMoveState)
		{
			if (!this.InFloatingState)
			{
				return;
			}
			if (newMoveState == ECharMoveState.Floating || newMoveState == ECharMoveState.Rise || newMoveState == ECharMoveState.Drop || newMoveState == ECharMoveState.FloatingGround)
			{
				return;
			}
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterDefaultState();
		}

		// Token: 0x06030F00 RID: 200448 RVA: 0x00C237A0 File Offset: 0x00C219A0
		[NullableContext(2)]
		private void OnStateInherit(Entity other, bool notInheritMoveAndAnim)
		{
			if (other == null || !other.Valid)
			{
				return;
			}
			CharacterUnifiedStateComponent component = other.GetComponent<CharacterUnifiedStateComponent>();
			if (component == null || !component.Valid)
			{
				return;
			}
			CharacterFloatingComponent component2 = other.GetComponent<CharacterFloatingComponent>();
			if (component2 == null || !component2.Valid || !component2.InFloatingState)
			{
				return;
			}
			if (!this.InFloatingState)
			{
				if (!component2.IsNearGround)
				{
					CharacterMoveComponent moveComp = this.MoveComp;
					if (moveComp == null)
					{
						return;
					}
					CharacterActorComponent actorComp = moveComp.ActorComp;
					if (actorComp == null)
					{
						return;
					}
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						Context = "[CharacterFloatingComponent.OnStateInherit] Falling"
					});
					return;
				}
			}
			else
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.StateComp.SetPositionState(component.PositionState);
			}
		}

		// Token: 0x06030F01 RID: 200449 RVA: 0x00C23857 File Offset: 0x00C21A57
		private void OnRoleInheritTransform()
		{
			if (!this.InFloatingState)
			{
				return;
			}
			this.DetectFloor();
			this.CheckGround();
		}

		// Token: 0x06030F02 RID: 200450 RVA: 0x00C2386F File Offset: 0x00C21A6F
		private void OnBeginSkill(int skillId, bool isAutonomousProxy)
		{
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterDefaultState();
			this.ClearCacheInputDirect();
		}

		// Token: 0x06030F03 RID: 200451 RVA: 0x00C23883 File Offset: 0x00C21A83
		private void OnCharSkillEnd(int entityId, int skillId)
		{
			if (this.StateComp.PositionState != ECharPositionState.Floating)
			{
				return;
			}
			if (this.FloatingMoveType == EFloatingMovementType.None || this.FloatingMoveType == EFloatingMovementType.Drop)
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.EnterFloatingState(false);
			}
			this.ClearCacheInputDirect();
		}

		// Token: 0x06030F04 RID: 200452 RVA: 0x00C238B8 File Offset: 0x00C21AB8
		private void OnBeforeChangeRole(EntityHandle newEntity, EntityHandle oldEntity)
		{
			if (!this.InFloatingState)
			{
				return;
			}
			if (newEntity == oldEntity || base.Entity != oldEntity.Entity)
			{
				return;
			}
			this.WasNearGround = this.IsNearGround;
			this.WasNearGroundDist = this.NearGroundDist;
			this.WasOnGround = this.IsOnGround;
			CharacterMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.SetForceSpeed(Vector.ZeroVectorProxy);
			}
			this.SpeedInternal = 0f;
		}

		// Token: 0x06030F05 RID: 200453 RVA: 0x00C23928 File Offset: 0x00C21B28
		private void OnChangeRole(EntityHandle newEntity, EntityHandle oldEntity)
		{
			if (this.Config == null || !this.InFloatingState)
			{
				return;
			}
			if (newEntity.Id == base.Entity.Id)
			{
				if (this.StateComp.PositionState != ECharPositionState.Floating)
				{
					return;
				}
				if (this.FloatingMoveType == EFloatingMovementType.None || this.FloatingMoveType == EFloatingMovementType.Drop)
				{
					bool debug = CharacterFloatingComponent.Debug;
					this.EnterFloatingState(false);
				}
				this.ClearCacheInputDirect();
			}
			if (oldEntity.Id == base.Entity.Id)
			{
				bool debug2 = CharacterFloatingComponent.Debug;
				this.EnterDefaultState();
				this.ClearCacheInputDirect();
			}
		}

		// Token: 0x06030F06 RID: 200454 RVA: 0x00C239B4 File Offset: 0x00C21BB4
		protected override void OnTick(float delta)
		{
			this.HasFloatingMoveInput = false;
			if (this.InFloatingState && this.Config != null && this.ActorComp != null)
			{
				CharacterMoveComponent moveComp = this.MoveComp;
				if (moveComp != null && moveComp.Active && this.TagComp != null && this.AnimComp != null && this.StateComp != null && this.TimeScaleComp != null && this.CreatureDataComp != null && this.StateMachine != null)
				{
					if ((this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Custom && this.MoveComp.CharacterMovement.CustomMovementMode == 5) || this.StateComp.PositionSubState == ECharPositionSubState.WaterSurface)
					{
						this.RefreshMoveState();
						this.TriggerFloatingMoveEvent();
						return;
					}
					if (this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Falling)
					{
						this.EnterDefaultState();
						this.TriggerFloatingMoveEvent();
						return;
					}
					if (this.StateComp.PositionState == ECharPositionState.Ground)
					{
						this.EnterFloatingInternal();
						this.TriggerFloatingMoveEvent();
						return;
					}
					if (this.StateComp.PositionState != ECharPositionState.Floating)
					{
						return;
					}
					this.RefreshMoveState();
					this.TriggerFloatingMoveEvent();
					this.StateMachine.Update(delta * this.TimeScaleComp.CurrentTimeScale * this.ActorComp.TimeDilation * 0.001f);
					return;
				}
			}
			this.TriggerFloatingMoveEvent();
		}

		// Token: 0x06030F07 RID: 200455 RVA: 0x00C23B02 File Offset: 0x00C21D02
		public void UpdateMove(float deltaSeconds, Vector output)
		{
			output.DeepCopy(this.ActorComp.InputDirectProxy);
			this.TempInputDirection.DeepCopy(output);
			output.MultiplyEqual((double)(this.SpeedInternal * deltaSeconds));
		}

		// Token: 0x06030F08 RID: 200456 RVA: 0x00C23B34 File Offset: 0x00C21D34
		public void UpdateSpeed(float second)
		{
			if (this.ActorComp.InputDirectProxy.IsNearlyZero(0.0001))
			{
				if (this.Speed > 0f)
				{
					this.SpeedInternal = Math.Max(this.Speed - this.Config.SpeedAcceleration * second, 0f);
				}
				else
				{
					this.SpeedInternal = 0f;
				}
				this.FloatingMoveMixInternal = Singleton<MathUtils>.Instance.Lerp(this.FloatingMoveMix, 0f, this.Config.AnimLerpAlpha);
				return;
			}
			if (this.IsSprintMove)
			{
				if (this.Speed < this.Config.SprintSpeed)
				{
					this.SpeedInternal = Math.Min(this.Speed + this.Config.SpeedAcceleration * second, this.Config.SprintSpeed);
				}
				else
				{
					this.SpeedInternal = Math.Max(this.Speed - this.Config.SpeedAcceleration * second, this.Config.SprintSpeed);
				}
				this.FloatingMoveMixInternal = Singleton<MathUtils>.Instance.Lerp(this.FloatingMoveMix, 1f, this.Config.AnimLerpAlpha);
				return;
			}
			if (this.Speed < this.Config.MoveSpeed)
			{
				this.SpeedInternal = Math.Min(this.Speed + this.Config.SpeedAcceleration * second, this.Config.MoveSpeed);
			}
			else
			{
				this.SpeedInternal = Math.Max(this.Speed - this.Config.SpeedAcceleration * second, this.Config.MoveSpeed);
			}
			this.FloatingMoveMixInternal = Singleton<MathUtils>.Instance.Lerp(this.FloatingMoveMix, 0.5f, this.Config.AnimLerpAlpha);
		}

		// Token: 0x06030F09 RID: 200457 RVA: 0x00C23CEC File Offset: 0x00C21EEC
		public void CloseToGround(float deltaSeconds)
		{
			if (this.TagComp.HasAnyTag(this.Config.ForbidCloseToGroundTagList))
			{
				return;
			}
			float floorDistance = this.GetFloorDistance();
			float num = Math.Min(this.WaterDist, floorDistance);
			if (num > 3f && num < this.Config.CloseToGroundHeight)
			{
				this.TempVector2.DeepCopy(this.MoveComp.GravityDirect);
				this.TempVector2.MultiplyEqual((double)num);
				this.TempVector2.AdditionEqual(this.ActorComp.ActorLocationProxy);
				this.TempVector.DeepCopy(this.ActorComp.ActorLocationProxy);
				Singleton<MathUtils>.Instance.VectorInterpTo(this.TempVector, this.TempVector2, (double)deltaSeconds, 3.0, this.TempVector3);
				this.TempVector3.Subtraction(this.TempVector, this.TempVector2);
				this.MoveDelta.AdditionEqual(this.TempVector2);
			}
		}

		// Token: 0x06030F0A RID: 200458 RVA: 0x00C23DE4 File Offset: 0x00C21FE4
		public void CheckGround()
		{
			float floorDistance = this.GetFloorDistance();
			this.IsNearGround = (floorDistance < this.Config.AirCriticalHeight);
			this.NearGroundDist = (this.IsNearGround ? floorDistance : -1f);
			if (this.IsNearGround)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp == null || !tagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.近地"]))
				{
					BaseTagComponent tagComp2 = this.TagComp;
					if (tagComp2 == null)
					{
						goto IL_D7;
					}
					tagComp2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.近地"]));
					goto IL_D7;
				}
			}
			if (!this.IsNearGround)
			{
				BaseTagComponent tagComp3 = this.TagComp;
				if (tagComp3 != null && tagComp3.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.近地"]))
				{
					BaseTagComponent tagComp4 = this.TagComp;
					if (tagComp4 != null)
					{
						tagComp4.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.近地"]));
					}
				}
			}
			IL_D7:
			this.IsOnWater = (this.WaterDist < 3f);
			this.IsOnGround = (floorDistance < 3f);
			if (this.IsOnGround)
			{
				if (this.HasGroundTag)
				{
					BaseTagComponent tagComp5 = this.TagComp;
					if (tagComp5 != null && tagComp5.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]))
					{
						goto IL_18A;
					}
				}
				BaseTagComponent tagComp6 = this.TagComp;
				if (tagComp6 != null)
				{
					tagComp6.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]));
				}
				this.HasGroundTag = true;
				CharacterUnifiedStateComponent stateComp = this.StateComp;
				if (stateComp == null || stateComp.PositionSubState != ECharPositionSubState.FloatingOnGround)
				{
					CharacterUnifiedStateComponent stateComp2 = this.StateComp;
					if (stateComp2 != null)
					{
						stateComp2.SetPositionSubState(ECharPositionSubState.FloatingOnGround, false);
					}
				}
				IL_18A:
				if (this.HasAirTag)
				{
					BaseTagComponent tagComp7 = this.TagComp;
					if (tagComp7 != null && tagComp7.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
					{
						BaseTagComponent tagComp8 = this.TagComp;
						if (tagComp8 != null)
						{
							tagComp8.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]));
						}
						this.HasAirTag = false;
						CharacterUnifiedStateComponent stateComp3 = this.StateComp;
						if (stateComp3 != null && stateComp3.PositionSubState == ECharPositionSubState.FloatingOnAir)
						{
							CharacterUnifiedStateComponent stateComp4 = this.StateComp;
							if (stateComp4 != null)
							{
								stateComp4.SetPositionSubState(ECharPositionSubState.None, false);
							}
						}
					}
				}
			}
			else
			{
				if (!this.IsOnWater)
				{
					if (this.HasAirTag)
					{
						BaseTagComponent tagComp9 = this.TagComp;
						if (tagComp9 != null && tagComp9.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
						{
							goto IL_2AF;
						}
					}
					BaseTagComponent tagComp10 = this.TagComp;
					if (tagComp10 != null)
					{
						tagComp10.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]));
					}
					this.HasAirTag = true;
					CharacterUnifiedStateComponent stateComp5 = this.StateComp;
					if (stateComp5 == null || stateComp5.PositionSubState != ECharPositionSubState.FloatingOnAir)
					{
						CharacterUnifiedStateComponent stateComp6 = this.StateComp;
						if (stateComp6 != null)
						{
							stateComp6.SetPositionSubState(ECharPositionSubState.FloatingOnAir, false);
						}
					}
				}
				IL_2AF:
				if (this.HasGroundTag)
				{
					BaseTagComponent tagComp11 = this.TagComp;
					if (tagComp11 != null && tagComp11.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]))
					{
						BaseTagComponent tagComp12 = this.TagComp;
						if (tagComp12 != null)
						{
							tagComp12.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]));
						}
						this.HasGroundTag = false;
						CharacterUnifiedStateComponent stateComp7 = this.StateComp;
						if (stateComp7 != null && stateComp7.PositionSubState == ECharPositionSubState.FloatingOnGround)
						{
							CharacterUnifiedStateComponent stateComp8 = this.StateComp;
							if (stateComp8 != null)
							{
								stateComp8.SetPositionSubState(ECharPositionSubState.None, false);
							}
						}
					}
				}
			}
			if (floorDistance >= this.Config.CloseToGroundHeight)
			{
				if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.悬浮贴地中"]))
				{
					this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.悬浮贴地中"]));
					return;
				}
			}
			else if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.悬浮贴地中"]))
			{
				this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.悬浮贴地中"]));
			}
		}

		// Token: 0x06030F0B RID: 200459 RVA: 0x00C241A8 File Offset: 0x00C223A8
		public void ReleaseGroundTag()
		{
			if (this.IsNearGround)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.近地"]))
				{
					BaseTagComponent tagComp2 = this.TagComp;
					if (tagComp2 != null)
					{
						tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.悬浮.近地"]));
					}
				}
			}
			this.IsNearGround = false;
			if (this.HasAirTag)
			{
				BaseTagComponent tagComp3 = this.TagComp;
				if (tagComp3 != null && tagComp3.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
				{
					BaseTagComponent tagComp4 = this.TagComp;
					if (tagComp4 != null)
					{
						tagComp4.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]));
					}
				}
			}
			this.HasAirTag = false;
			if (this.HasGroundTag)
			{
				BaseTagComponent tagComp5 = this.TagComp;
				if (tagComp5 != null && tagComp5.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]))
				{
					BaseTagComponent tagComp6 = this.TagComp;
					if (tagComp6 != null)
					{
						tagComp6.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]));
					}
				}
			}
			this.HasGroundTag = false;
		}

		// Token: 0x06030F0C RID: 200460 RVA: 0x00C242C0 File Offset: 0x00C224C0
		public bool GetTargetDirectionProjection(Vector outVector)
		{
			if (ModelBase<CameraModel>.Instance.MainModel.HasLockTarget())
			{
				ModelBase<CameraModel>.Instance.MainModel.GetLockTargetLocation(this.TempVector);
				this.TempVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
				this.TempVector.Normalize(9.99999993922529E-09);
			}
			else
			{
				FVectorDouble fvectorDouble = Global.CharacterCameraManager.GetCameraRotation().VectorDouble();
				this.TempVector.DeepCopy(fvectorDouble);
			}
			Vector gravityDirect = this.MoveComp.GravityDirect;
			Vector.VectorPlaneProject(this.TempVector, gravityDirect, outVector);
			return outVector.Normalize(9.99999993922529E-09);
		}

		// Token: 0x06030F0D RID: 200461 RVA: 0x00C2436C File Offset: 0x00C2256C
		public void RotatorFloatingDirection(float deltaSeconds, Vector cameraDirection)
		{
			if (cameraDirection.IsNearlyZero(9.999999747378752E-05))
			{
				return;
			}
			Vector actorUpProxy = this.ActorComp.ActorUpProxy;
			float turnSpeedDeg = this.Config.TurnSpeedDeg;
			Vector.VectorPlaneProject(this.ActorComp.ActorForwardProxy, this.MoveComp.GravityDirect, this.TempVector);
			if (!this.TempVector.IsNearlyZero(9.999999747378752E-05))
			{
				this.TempVector.Normalize(9.99999993922529E-09);
				double value = Singleton<MathUtils>.Instance.SignedAngleOnPlaneDeg(this.TempVector, cameraDirection, actorUpProxy);
				float num = turnSpeedDeg * deltaSeconds * 2f;
				double alpha = Singleton<MathUtils>.Instance.Clamp(Math.Abs(value) / 180.0, 0.0, 1.0);
				double value2 = Singleton<MathUtils>.Instance.LerpCubic(0.0, 1.2000000476837158, 1.0, 0.800000011920929, alpha);
				double num2 = Singleton<MathUtils>.Instance.RangeClamp(value2, 0.0, 1.0, 0.10000000149011612, 1.0);
				double num3 = Math.Min(Math.Abs(value), (double)num * num2);
				double angleDeg = (double)Math.Sign(value) * num3;
				this.TempVector.RotateAngleAxis(angleDeg, actorUpProxy, this.TempVector);
				Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector, actorUpProxy, this.TempRotator);
			}
			else
			{
				Singleton<MathUtils>.Instance.LookRotationForwardFirst(cameraDirection, actorUpProxy, this.TempRotator);
			}
			this.ActorComp.SetActorRotation(this.TempRotator.ToUeRotator(), "RailSlide.TangentRotator", false);
			this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, false);
		}

		// Token: 0x06030F0E RID: 200462 RVA: 0x00C24538 File Offset: 0x00C22738
		public bool DetectFloor()
		{
			this.DetectWaterDist();
			this.ActorComp.RefreshCurrentFloor();
			this.CurrentFloor = this.MoveComp.CharacterMovement.CurrentFloor;
			this.RefreshMovementBase();
			if (this.CurrentFloor == null)
			{
				return this.DetectHeightNonFloor();
			}
			AActor aactor = this.CurrentFloor.HitResult.Actor.Get();
			if (aactor == null || !aactor.IsValid())
			{
				return this.DetectHeightNonFloor();
			}
			return (this.CurrentFloor.bWalkableFloor && this.CurrentFloor.FloorDist < 3f) || this.DetectHeightNonFloor();
		}

		// Token: 0x06030F0F RID: 200463 RVA: 0x00C245E0 File Offset: 0x00C227E0
		private void DetectWaterDist()
		{
			float heightDetect = Math.Max(550f, this.Config.CloseToGroundHeight);
			float heightAboveWater = this.MoveComp.GetHeightAboveWater(heightDetect);
			this.WaterDist = heightAboveWater;
		}

		// Token: 0x06030F10 RID: 200464 RVA: 0x00C24618 File Offset: 0x00C22818
		private bool DetectHeightNonFloor()
		{
			float heightDetect = Math.Max(this.Config.AirCriticalHeight, this.Config.CloseToGroundHeight);
			float heightAboveGround = this.MoveComp.GetHeightAboveGround(heightDetect);
			this.HitFloorNonFloor = (heightAboveGround < this.Config.AirCriticalHeight);
			this.HitFloorDist = heightAboveGround;
			return this.HitFloorNonFloor;
		}

		// Token: 0x06030F11 RID: 200465 RVA: 0x00C2466F File Offset: 0x00C2286F
		public float GetFloorDistance()
		{
			FFindFloorResult currentFloor = this.CurrentFloor;
			if (currentFloor != null && currentFloor.bWalkableFloor)
			{
				return this.CurrentFloor.FloorDist;
			}
			if (!this.HitFloorNonFloor)
			{
				return 1E+09f;
			}
			return this.HitFloorDist;
		}

		// Token: 0x06030F12 RID: 200466 RVA: 0x00C246A8 File Offset: 0x00C228A8
		[NullableContext(2)]
		public UKuroHitResult DetectCeiling()
		{
			UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
			actorTrace.WorldContextObject = this.ActorComp.Actor;
			actorTrace.Radius = 1f;
			this.TempVector.DeepCopy(this.ActorComp.ActorLocationProxy);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempVector, (double)this.ActorComp.ScaledHalfHeight);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.TempVector);
			this.TempVector2.DeepCopy(this.TempVector);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempVector2, 1.0);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TempVector2);
			actorTrace.ActorsToIgnore.Empty(true);
			foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
			{
				actorTrace.ActorsToIgnore.Add(value);
			}
			if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "Floating", "Floating"))
			{
				return null;
			}
			return actorTrace.HitResult;
		}

		// Token: 0x06030F13 RID: 200467 RVA: 0x00C247F0 File Offset: 0x00C229F0
		private void RefreshMovementBase()
		{
			FFindFloorResult currentFloor = this.CurrentFloor;
			UPrimitiveComponent uprimitiveComponent = (currentFloor != null) ? currentFloor.HitResult.Component.Get() : null;
			if (this.CurrentBase == uprimitiveComponent)
			{
				return;
			}
			this.CurrentBase = uprimitiveComponent;
			UKuroStaticLibrary.SetBaseAndSaveBaseLocation(this.ActorComp.Actor.CharacterMovement, this.CurrentBase);
		}

		// Token: 0x06030F14 RID: 200468 RVA: 0x00C2484C File Offset: 0x00C22A4C
		private void RefreshMoveState()
		{
			if (!this.MoveComp.CanResponseInput())
			{
				return;
			}
			if (this.QueryInputAction(AkiClient.Game.Aki.Character.Input.Enum.EInputAction.跳跃))
			{
				this.EnterRiseState();
				this.HasFloatingMoveInput = true;
				return;
			}
			if (this.FloatingMoveType == EFloatingMovementType.None && this.MoveComp.HasMoveInput)
			{
				this.EnterFloatingState(false);
			}
		}

		// Token: 0x06030F15 RID: 200469 RVA: 0x00C2489A File Offset: 0x00C22A9A
		private void TriggerFloatingMoveEvent()
		{
			if (this.HadFloatingMoveInput == this.HasFloatingMoveInput)
			{
				return;
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnFloatingMoveInputChanged, this.HadFloatingMoveInput, this.HasFloatingMoveInput);
			this.HadFloatingMoveInput = this.HasFloatingMoveInput;
		}

		// Token: 0x06030F16 RID: 200470 RVA: 0x00C248DC File Offset: 0x00C22ADC
		public void ExitHitState()
		{
			if (this.QueryInputAction(AkiClient.Game.Aki.Character.Input.Enum.EInputAction.跳跃))
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.EnterRiseState();
				return;
			}
			if (Singleton<Info>.Instance.IsInTouch() && this.QueryInputAction(AkiClient.Game.Aki.Character.Input.Enum.EInputAction.下降))
			{
				bool debug2 = CharacterFloatingComponent.Debug;
				this.EnterDropState();
				return;
			}
			if (CharacterFloatingComponent.BeHitMoveStateList.Contains(this.StateComp.MoveState))
			{
				bool debug3 = CharacterFloatingComponent.Debug;
				this.EnterFloatingState(false);
			}
		}

		// Token: 0x06030F17 RID: 200471 RVA: 0x00C24946 File Offset: 0x00C22B46
		public void ExternalEnterFloatingState()
		{
			bool debug = CharacterFloatingComponent.Debug;
			this.EnterFloatingState(true);
		}

		// Token: 0x06030F18 RID: 200472 RVA: 0x00C24955 File Offset: 0x00C22B55
		public void ClearCacheInputDirect()
		{
			this.TempInputDirection.Reset();
		}

		// Token: 0x06030F19 RID: 200473 RVA: 0x00C24964 File Offset: 0x00C22B64
		private void AddFloatingStateListener()
		{
			BaseTagComponent tagComp = this.TagComp;
			this.FloatingEnableListener = ((tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮"]), delegate(int _, bool tagExists)
			{
				if (tagExists)
				{
					this.EnableFloating("/Game/Aki/Character/Role/FemaleZ2/AimisiGD/Data/DA_FloatingMovementConfig.DA_FloatingMovementConfig");
					return;
				}
				this.DisableFloating();
			}, null) : null);
			BaseTagComponent tagComp2 = this.TagComp;
			this.FloatingMoveModeListener = ((tagComp2 != null) ? tagComp2.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.锁敌移动"]), delegate(int _, bool tagExists)
			{
				this.InLockTargetState = tagExists;
			}, null) : null);
			BaseTagComponent tagComp3 = this.TagComp;
			this.FloatingSprintListener = ((tagComp3 != null) ? tagComp3.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.快速移动"]), delegate(int _, bool tagExists)
			{
				this.IsSprintMove = tagExists;
			}, null) : null);
		}

		// Token: 0x06030F1A RID: 200474 RVA: 0x00C24A1C File Offset: 0x00C22C1C
		private void InitConfig(string daPath, Action callback)
		{
			if (this.Config == null)
			{
				this.Config = new FloatingMovementConfig();
			}
			BP_FloatingMovementConfig_C bp_FloatingMovementConfig_C = Singleton<ResourceSystem>.Instance.Load<BP_FloatingMovementConfig_C>(daPath, "js_undefined");
			if (bp_FloatingMovementConfig_C != null && bp_FloatingMovementConfig_C.IsValid())
			{
				this.Config.Init(bp_FloatingMovementConfig_C);
			}
			callback();
		}

		// Token: 0x06030F1B RID: 200475 RVA: 0x00C24A6C File Offset: 0x00C22C6C
		private void InitFloatingStateMachine()
		{
			this.StateMachine = new StateMachine<CharacterFloatingComponent, EFloatingMovementType>(this, null);
			this.StateMachine.AddState<DefaultState>(EFloatingMovementType.None, null);
			this.StateMachine.AddState<FloatingState>(EFloatingMovementType.Floating, null);
			this.StateMachine.AddState<RiseState>(EFloatingMovementType.Rise, null);
			this.StateMachine.AddState<DropState>(EFloatingMovementType.Drop, null);
			this.StateMachine.AddState<WalkState>(EFloatingMovementType.Walk, null);
			this.StateMachine.Start(EFloatingMovementType.None);
		}

		// Token: 0x06030F1C RID: 200476 RVA: 0x00C24AD4 File Offset: 0x00C22CD4
		public string GetStateName(EFloatingMovementType state)
		{
			switch (state)
			{
			case EFloatingMovementType.None:
				return "None";
			case EFloatingMovementType.Floating:
				return "Floating";
			case EFloatingMovementType.Rise:
				return "Rise";
			case EFloatingMovementType.Drop:
				return "Drop";
			case EFloatingMovementType.Walk:
				return "Walk";
			default:
				return "请补充悬浮状态名称";
			}
		}

		// Token: 0x06030F1D RID: 200477 RVA: 0x00C24B20 File Offset: 0x00C22D20
		public static void CreateStaticDefaultValue()
		{
			CharacterFloatingComponent.Debug = false;
		}

		// Token: 0x06030F1E RID: 200478 RVA: 0x00C24B28 File Offset: 0x00C22D28
		public static void ResetStaticDefaultValue()
		{
			CharacterFloatingComponent.Debug = false;
		}

		// Token: 0x06030F1F RID: 200479 RVA: 0x00C24B30 File Offset: 0x00C22D30
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterFloatingComponent characterFloatingComponent = (CharacterFloatingComponent)componentTemplate;
			if (base.CanResetComponentProperty("InFloatingState"))
			{
				this.InFloatingState = characterFloatingComponent.InFloatingState;
			}
			if (base.CanResetComponentProperty("InLockTargetState"))
			{
				this.InLockTargetState = characterFloatingComponent.InLockTargetState;
			}
			if (base.CanResetComponentProperty("SpeedInternal"))
			{
				this.SpeedInternal = characterFloatingComponent.SpeedInternal;
			}
			if (base.CanResetComponentProperty("IsSprintMove"))
			{
				this.IsSprintMove = characterFloatingComponent.IsSprintMove;
			}
			if (base.CanResetComponentProperty("FloatingMoveMixInternal"))
			{
				this.FloatingMoveMixInternal = characterFloatingComponent.FloatingMoveMixInternal;
			}
			if (base.CanResetComponentProperty("FloatingMoveType"))
			{
				this.FloatingMoveType = characterFloatingComponent.FloatingMoveType;
			}
			if (base.CanResetComponentProperty("HadFloatingMoveInput"))
			{
				this.HadFloatingMoveInput = characterFloatingComponent.HadFloatingMoveInput;
			}
			if (base.CanResetComponentProperty("HasFloatingMoveInput"))
			{
				this.HasFloatingMoveInput = characterFloatingComponent.HasFloatingMoveInput;
			}
			if (base.CanResetComponentProperty("IsOnWater"))
			{
				this.IsOnWater = characterFloatingComponent.IsOnWater;
			}
			if (base.CanResetComponentProperty("WaterDist"))
			{
				this.WaterDist = characterFloatingComponent.WaterDist;
			}
			if (base.CanResetComponentProperty("CurrentFloor"))
			{
				if (characterFloatingComponent.CurrentFloor == null)
				{
					this.CurrentFloor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FFindFloorResult>(this.CurrentFloor), "CurrentFloor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentBase"))
			{
				if (characterFloatingComponent.CurrentBase == null)
				{
					this.CurrentBase = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UPrimitiveComponent>(this.CurrentBase), "CurrentBase"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("HitFloorNonFloor"))
			{
				this.HitFloorNonFloor = characterFloatingComponent.HitFloorNonFloor;
			}
			if (base.CanResetComponentProperty("HitFloorDist"))
			{
				this.HitFloorDist = characterFloatingComponent.HitFloorDist;
			}
			if (base.CanResetComponentProperty("IsNearGround"))
			{
				this.IsNearGround = characterFloatingComponent.IsNearGround;
			}
			if (base.CanResetComponentProperty("NearGroundDist"))
			{
				this.NearGroundDist = characterFloatingComponent.NearGroundDist;
			}
			if (base.CanResetComponentProperty("IsOnGround"))
			{
				this.IsOnGround = characterFloatingComponent.IsOnGround;
			}
			if (base.CanResetComponentProperty("HasGroundTag"))
			{
				this.HasGroundTag = characterFloatingComponent.HasGroundTag;
			}
			if (base.CanResetComponentProperty("HasAirTag"))
			{
				this.HasAirTag = characterFloatingComponent.HasAirTag;
			}
			if (base.CanResetComponentProperty("WasNearGround"))
			{
				this.WasNearGround = characterFloatingComponent.WasNearGround;
			}
			if (base.CanResetComponentProperty("WasNearGroundDist"))
			{
				this.WasNearGroundDist = characterFloatingComponent.WasNearGroundDist;
			}
			if (base.CanResetComponentProperty("WasOnGround"))
			{
				this.WasOnGround = characterFloatingComponent.WasOnGround;
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (characterFloatingComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FloatingMovementConfig>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (characterFloatingComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (characterFloatingComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterFloatingComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AnimComp"))
			{
				if (characterFloatingComponent.AnimComp == null)
				{
					this.AnimComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (characterFloatingComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TimeScaleComp"))
			{
				if (characterFloatingComponent.TimeScaleComp == null)
				{
					this.TimeScaleComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterTimeScaleComponent>(this.TimeScaleComp), "TimeScaleComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (characterFloatingComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InputComp"))
			{
				if (characterFloatingComponent.InputComp == null)
				{
					this.InputComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComp), "InputComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateMachine"))
			{
				if (characterFloatingComponent.StateMachine == null)
				{
					this.StateMachine = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<StateMachine<CharacterFloatingComponent, EFloatingMovementType>>(this.StateMachine), "StateMachine"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ComponentDisableHandle"))
			{
				this.ComponentDisableHandle = characterFloatingComponent.ComponentDisableHandle;
			}
			if (base.CanResetComponentProperty("MoveDelta") && characterFloatingComponent.MoveDelta != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.MoveDelta), "MoveDelta"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TempVector") && characterFloatingComponent.TempVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TempVector2") && characterFloatingComponent.TempVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector2), "TempVector2"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TempVector3") && characterFloatingComponent.TempVector3 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector3), "TempVector3"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TempInputDirection") && characterFloatingComponent.TempInputDirection != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempInputDirection), "TempInputDirection"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TempRotator") && characterFloatingComponent.TempRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TempRotator), "TempRotator"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("FloatingEnableListener"))
			{
				if (characterFloatingComponent.FloatingEnableListener == null)
				{
					this.FloatingEnableListener = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.FloatingEnableListener), "FloatingEnableListener"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FloatingMoveModeListener"))
			{
				if (characterFloatingComponent.FloatingMoveModeListener == null)
				{
					this.FloatingMoveModeListener = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.FloatingMoveModeListener), "FloatingMoveModeListener"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FloatingSprintListener"))
			{
				if (characterFloatingComponent.FloatingSprintListener == null)
				{
					this.FloatingSprintListener = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.FloatingSprintListener), "FloatingSprintListener"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C23F RID: 115263
		private const string PROFILE_KEY = "Floating";

		// Token: 0x0401C240 RID: 115264
		private const int TRACE_ERROR_VALUE = 1;

		// Token: 0x0401C241 RID: 115265
		private const int COMPONENT_DISABLE_KEY = -1;

		// Token: 0x0401C242 RID: 115266
		private const int FAST_MOVE_MIX = 1;

		// Token: 0x0401C243 RID: 115267
		private const float NORMAL_MOVE_MIX = 0.5f;

		// Token: 0x0401C244 RID: 115268
		private const int MAX_FLOOR_DIST = 999999999;

		// Token: 0x0401C245 RID: 115269
		private const int WATER_TRACE_DEPTH = 550;

		// Token: 0x0401C246 RID: 115270
		private const int TRACE_ERROR_THRESHOLD = 3;

		// Token: 0x0401C247 RID: 115271
		private const string DEFAULT_DA_PATH = "/Game/Aki/Character/Role/FemaleZ2/AimisiGD/Data/DA_FloatingMovementConfig.DA_FloatingMovementConfig";

		// Token: 0x0401C248 RID: 115272
		[StaticVariableRuleIgnore]
		public static readonly List<int> EmptyArray = new List<int>();

		// Token: 0x0401C249 RID: 115273
		[StaticVariableRuleIgnore]
		public static readonly ECharMoveState[] BeHitMoveStateList = new ECharMoveState[]
		{
			ECharMoveState.KnockDown,
			ECharMoveState.Parry,
			ECharMoveState.SoftKnock,
			ECharMoveState.HeavyKnock,
			ECharMoveState.KnockUp,
			ECharMoveState.Captured
		};

		// Token: 0x0401C24A RID: 115274
		public bool InFloatingState;

		// Token: 0x0401C24B RID: 115275
		public bool InLockTargetState;

		// Token: 0x0401C24C RID: 115276
		public float SpeedInternal;

		// Token: 0x0401C24D RID: 115277
		public bool IsSprintMove;

		// Token: 0x0401C24E RID: 115278
		public float FloatingMoveMixInternal = 1f;

		// Token: 0x0401C24F RID: 115279
		public readonly float FloatingSpeedMixInternal = 1f;

		// Token: 0x0401C250 RID: 115280
		public EFloatingMovementType FloatingMoveType;

		// Token: 0x0401C251 RID: 115281
		public bool HadFloatingMoveInput;

		// Token: 0x0401C252 RID: 115282
		public bool HasFloatingMoveInput;

		// Token: 0x0401C253 RID: 115283
		public bool IsOnWater;

		// Token: 0x0401C254 RID: 115284
		public float WaterDist;

		// Token: 0x0401C255 RID: 115285
		[Nullable(2)]
		public FFindFloorResult CurrentFloor;

		// Token: 0x0401C256 RID: 115286
		[Nullable(2)]
		public UPrimitiveComponent CurrentBase;

		// Token: 0x0401C257 RID: 115287
		public bool HitFloorNonFloor;

		// Token: 0x0401C258 RID: 115288
		public float HitFloorDist;

		// Token: 0x0401C259 RID: 115289
		public bool IsNearGround;

		// Token: 0x0401C25A RID: 115290
		public float NearGroundDist;

		// Token: 0x0401C25B RID: 115291
		public bool IsOnGround;

		// Token: 0x0401C25C RID: 115292
		public bool HasGroundTag;

		// Token: 0x0401C25D RID: 115293
		public bool HasAirTag;

		// Token: 0x0401C25E RID: 115294
		public bool WasNearGround;

		// Token: 0x0401C25F RID: 115295
		public float WasNearGroundDist;

		// Token: 0x0401C260 RID: 115296
		public bool WasOnGround;

		// Token: 0x0401C261 RID: 115297
		[Nullable(2)]
		public FloatingMovementConfig Config;

		// Token: 0x0401C262 RID: 115298
		[Nullable(2)]
		public BaseTagComponent TagComp;

		// Token: 0x0401C263 RID: 115299
		[Nullable(2)]
		public CharacterMoveComponent MoveComp;

		// Token: 0x0401C264 RID: 115300
		[Nullable(2)]
		public CharacterActorComponent ActorComp;

		// Token: 0x0401C265 RID: 115301
		[Nullable(2)]
		public CharacterAnimationComponent AnimComp;

		// Token: 0x0401C266 RID: 115302
		[Nullable(2)]
		public CharacterUnifiedStateComponent StateComp;

		// Token: 0x0401C267 RID: 115303
		[Nullable(2)]
		public CharacterTimeScaleComponent TimeScaleComp;

		// Token: 0x0401C268 RID: 115304
		[Nullable(2)]
		public CreatureDataComponent CreatureDataComp;

		// Token: 0x0401C269 RID: 115305
		[Nullable(2)]
		public CharacterInputComponent InputComp;

		// Token: 0x0401C26A RID: 115306
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private StateMachine<CharacterFloatingComponent, EFloatingMovementType> StateMachine;

		// Token: 0x0401C26B RID: 115307
		private int ComponentDisableHandle = -1;

		// Token: 0x0401C26C RID: 115308
		public readonly Vector MoveDelta = Vector.Create();

		// Token: 0x0401C26D RID: 115309
		public readonly Vector TempVector = Vector.Create();

		// Token: 0x0401C26E RID: 115310
		public readonly Vector TempVector2 = Vector.Create();

		// Token: 0x0401C26F RID: 115311
		public readonly Vector TempVector3 = Vector.Create();

		// Token: 0x0401C270 RID: 115312
		public readonly Vector TempInputDirection = Vector.Create();

		// Token: 0x0401C271 RID: 115313
		public readonly Rotator TempRotator = Rotator.Create();

		// Token: 0x0401C272 RID: 115314
		public static bool Debug;

		// Token: 0x0401C273 RID: 115315
		[Nullable(2)]
		private ITagTask FloatingEnableListener;

		// Token: 0x0401C274 RID: 115316
		[Nullable(2)]
		private ITagTask FloatingMoveModeListener;

		// Token: 0x0401C275 RID: 115317
		[Nullable(2)]
		private ITagTask FloatingSprintListener;
	}
}
