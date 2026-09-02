using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Role.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004917 RID: 18711
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterClimbComponent : EntityComponent
	{
		// Token: 0x1700834E RID: 33614
		// (get) Token: 0x06030E4E RID: 200270 RVA: 0x00C1D94F File Offset: 0x00C1BB4F
		[StaticVariableRuleIgnore]
		public new static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(CharacterActorComponent),
					typeof(CharacterMoveComponent)
				};
			}
		}

		// Token: 0x06030E4F RID: 200271 RVA: 0x00C1D971 File Offset: 0x00C1BB71
		private void ReceiveClimbEvent(float deltaTime)
		{
			this.ClimbEvent(deltaTime);
		}

		// Token: 0x06030E50 RID: 200272 RVA: 0x00C1D97C File Offset: 0x00C1BB7C
		[NullableContext(2)]
		private void OnStateInherit(Entity other, bool notInheritMoveAndAnim)
		{
			if (notInheritMoveAndAnim)
			{
				return;
			}
			if (other == null || !other.Valid)
			{
				return;
			}
			CharacterClimbComponent component = other.GetComponent<CharacterClimbComponent>();
			if (component == null || !component.Valid)
			{
				return;
			}
			if (component.ClimbInputDirect.ContainsNaN())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "OnStateInherit ClimbInput is Nan.";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ClimbInput", component.ClimbInputDirect);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				component.ClimbInputDirect.Reset();
			}
			this.ClimbInputDirect.DeepCopy(component.ClimbInputDirect);
			this.PrevClimbInputDirect.DeepCopy(component.PrevClimbInputDirect);
			this.PreCharacterStateInClimb = component.PreCharacterStateInClimb;
			this.AwakeInput = component.AwakeInput;
			this.ClimbUpNewTransform = component.ClimbUpNewTransform;
			this.ClimbUpNewLocation = component.ClimbUpNewLocation;
			this.LastExitClimbTime = component.LastExitClimbTime;
			this.LastSafeLocation.DeepCopy(component.LastSafeLocation);
			this.SetClimbState(component.ClimbState);
			this.SetEnterClimbType(component.EnterClimbType);
			this.SetExitClimbType(component.ExitClimbType);
			this.ExitClimbCountDown = component.ExitClimbCountDown;
			if (this.ClimbState != EClimbState.无)
			{
				UKuroClimbObject kuroClimbObject = this.KuroClimbObject;
				if (kuroClimbObject != null)
				{
					kuroClimbObject.SyncFromOther(component.KuroClimbObject);
				}
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp == null)
				{
					return;
				}
				actorComp.ResetCachedVelocityTime();
			}
		}

		// Token: 0x06030E51 RID: 200273 RVA: 0x00C1DACC File Offset: 0x00C1BCCC
		private void OnUseSkill(int entityId, int skillId, bool IsAutonomousProxy)
		{
			CharacterMoveComponent moveComp = this.MoveComp;
			if (((moveComp != null) ? moveComp.CharacterMovement : null) == null)
			{
				return;
			}
			if (this.MoveComp.CharacterMovement.MovementMode != EMovementMode.MOVE_Custom || this.MoveComp.CharacterMovement.CustomMovementMode != 0)
			{
				return;
			}
			SSkillInfo skillInfo = base.Entity.GetComponent<CharacterSkillComponent>().GetSkillInfo(skillId);
			if (1 != skillInfo.GroupId)
			{
				return;
			}
			if (this.UnifiedStateComponent.MoveState == global::ECharMoveState.NormalClimb || this.UnifiedStateComponent.MoveState == global::ECharMoveState.FastClimb)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp == null)
				{
					return;
				}
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Walking,
					Context = "[CharacterClimbComponent.OnUseSkill]"
				});
			}
		}

		// Token: 0x1700834F RID: 33615
		// (get) Token: 0x06030E52 RID: 200274 RVA: 0x00C1DB7F File Offset: 0x00C1BD7F
		// (set) Token: 0x06030E53 RID: 200275 RVA: 0x00C1DB88 File Offset: 0x00C1BD88
		protected bool ClimbBlocking
		{
			get
			{
				return this.ClimbBlockingInternal;
			}
			set
			{
				if (this.ClimbBlockingInternal == value)
				{
					return;
				}
				this.ClimbBlockingInternal = value;
				if (this.ClimbBlockingInternal)
				{
					this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.攀爬受阻"]));
					return;
				}
				this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.攀爬受阻"]));
			}
		}

		// Token: 0x06030E54 RID: 200276 RVA: 0x00C1DBEE File Offset: 0x00C1BDEE
		public void SetIsAllowEarlyExitClimb(bool adaptive)
		{
			this.IsAllowEarlyExitClimb = adaptive;
		}

		// Token: 0x06030E55 RID: 200277 RVA: 0x00C1DBF8 File Offset: 0x00C1BDF8
		private unsafe void OnPositionStateChanged(global::ECharPositionState oldPositionState, global::ECharPositionState newPositionState)
		{
			if (oldPositionState == newPositionState)
			{
				return;
			}
			if (oldPositionState == global::ECharPositionState.Climb && newPositionState == global::ECharPositionState.Air && this.ExitClimbType != EExitClimb.蹬墙退出 && this.ExitClimbType != EExitClimb.反斜登顶)
			{
				double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy);
				if (znInGravityForActor > 1.0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Movement;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "错误的退出攀爬";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("退出模式", this.ExitClimbType);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("速度", this.ActorComp.ActorVelocityProxy);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("动作", this.AnimComp.MainAnimInstance.GetMainAnimsDebugText());
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					this.TmpVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
					Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, -znInGravityForActor);
					this.MoveComp.SetForceSpeed(this.TmpVector);
				}
			}
			if (oldPositionState == global::ECharPositionState.Climb)
			{
				FTransformDouble? ftransformDouble = null;
				bool flag = false;
				if (Math.Abs(this.ActorComp.ActorForwardProxy.DotProduct(this.MoveComp.GravityUp)) > 9.99999993922529E-09)
				{
					Singleton<MathUtils>.Instance.LookRotationUpFirst(this.ActorComp.ActorForwardProxy, this.MoveComp.GravityUp, this.TmpQuat);
					this.TmpQuat.Rotator(this.TmpRotator);
					CharacterActorComponent actorComp = this.ActorComp;
					if (actorComp != null)
					{
						actorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "ExitClimb", false);
					}
					flag = true;
					if (this.AnimComp != null && ftransformDouble == null)
					{
						ftransformDouble = new FTransformDouble?(this.AnimComp.GetMeshTransform());
					}
				}
				if (!this.ActorComp.IsDefaultCapsule)
				{
					EResultForExitClimb eresultForExitClimb = LocomotionUtils.FindSpaceForExitClimb(this.ActorComp, this.ActorComp.DefaultHalfHeight, this.ActorComp.DefaultRadius, 5f, this.TmpVector);
					if (eresultForExitClimb == EResultForExitClimb.Safety)
					{
						this.ActorComp.SetActorLocation(this.TmpVector.ToUeVector(false), "ExitClimb Capsule Safety", false);
						flag = true;
						if (this.AnimComp != null && ftransformDouble == null)
						{
							ftransformDouble = new FTransformDouble?(this.AnimComp.GetMeshTransform());
						}
					}
					else if (eresultForExitClimb == EResultForExitClimb.NoSafety)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Movement;
						ELogAuthor author2 = ELogAuthor.LCZ;
						string message2 = "ExitClimb Capsule NotSafety";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
						string item = "CurrentLocation";
						CharacterActorComponent actorComp2 = this.ActorComp;
						ptr = new ValueTuple<string, object>(item, (actorComp2 != null) ? actorComp2.ActorLocationProxy : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Last", this.LastSafeLocation);
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						this.ActorComp.SetActorLocation(this.LastSafeLocation.ToUeVector(false), "ExitClimb Capsule NotSafety", false);
						flag = true;
						if (this.AnimComp != null && ftransformDouble == null)
						{
							ftransformDouble = new FTransformDouble?(this.AnimComp.GetMeshTransform());
						}
					}
				}
				if (flag && ftransformDouble != null)
				{
					this.AnimComp.SetModelBuffer(ftransformDouble.Value, 100f);
				}
				this.ActorComp.ResetCapsuleRadiusAndHeight(false);
				this.CleanClimbState();
				return;
			}
			if (newPositionState == global::ECharPositionState.Climb)
			{
				this.ActorComp.SetRadiusAndHalfHeight(5f, 5f, false, false);
			}
		}

		// Token: 0x06030E56 RID: 200278 RVA: 0x00C1DF84 File Offset: 0x00C1C184
		private void OnForbiddenClimbChanged(int count, int tagId, int exactTagId, int oldCount)
		{
			if (count > 0)
			{
				if (this.ForbiddenClimbKey == null)
				{
					this.ForbiddenClimbKey = new int?(base.Disable("[CharacterClimbComponent.OnForbiddenClimbChanged] 禁用攀爬"));
					if (this.UnifiedStateComponent.PositionState == global::ECharPositionState.Climb)
					{
						this.NormalExitClimb();
						return;
					}
				}
			}
			else if (this.ForbiddenClimbKey != null)
			{
				base.Enable(new int?(this.ForbiddenClimbKey.Value), "[CharacterClimbComponent.OnForbiddenClimbChanged] 启用攀爬");
				this.ForbiddenClimbKey = null;
			}
		}

		// Token: 0x06030E57 RID: 200279 RVA: 0x00C1E002 File Offset: 0x00C1C202
		private void OnForbiddenClimbOnWall(int count, int tagId, int exactTagId, int oldCount)
		{
			if (count > 0 && this.UnifiedStateComponent.PositionState == global::ECharPositionState.Climb)
			{
				this.NormalExitClimb();
			}
		}

		// Token: 0x06030E58 RID: 200280 RVA: 0x00C1E01C File Offset: 0x00C1C21C
		private void OnForceFastClimb(int tagId, bool bTagExists)
		{
			this.ForceFastClimb = bTagExists;
		}

		// Token: 0x06030E59 RID: 200281 RVA: 0x00C1E028 File Offset: 0x00C1C228
		public void UpdateClimbDebug()
		{
			if (GlobalData.IsPlayInEditor)
			{
				TsCharacterDebugComponent tsCharacterDebugComponent = this.ActorComp.Actor.TsCharacterDebugComponent;
				this.DebugNoTop = tsCharacterDebugComponent.NoTop;
				this.DebugEnterClimbTrace = tsCharacterDebugComponent.EnterClimbTrace;
				this.DebugVaultClimbTrace = tsCharacterDebugComponent.VaultClimbTrace;
				this.DebugUpArriveClimbTrace = tsCharacterDebugComponent.UpArriveClimbTrace;
				this.DebugClimbingTrace = tsCharacterDebugComponent.ClimbingTrace;
			}
		}

		// Token: 0x06030E5A RID: 200282 RVA: 0x00C1E09D File Offset: 0x00C1C29D
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.ClimbUpNewTransform = new FTransform?(FTransform.Identity);
			this.CacheTransformBeforeMove = new FTransform?(FTransform.Identity);
			this.RefTransform = FTransformDouble.Identity;
			this.RefFloat = 0f;
			return true;
		}

		// Token: 0x06030E5B RID: 200283 RVA: 0x00C1E0D6 File Offset: 0x00C1C2D6
		protected override bool OnInit()
		{
			this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
			return true;
		}

		// Token: 0x06030E5C RID: 200284 RVA: 0x00C1E0EC File Offset: 0x00C1C2EC
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
			this.MoveComp = base.Entity.CheckGetComponent<CharacterMoveComponent>();
			this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
			this.UnifiedStateComponent = base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>();
			this.AwakeInput = true;
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChanged));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CustomMoveClimb, new Action<float>(this.ReceiveClimbEvent));
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			string roleBody = this.ActorComp.CreatureData.GetRoleConfig().Value.RoleBody;
			if (!this.InitClimbConfig(roleBody))
			{
				return false;
			}
			this.ClimbDownCompleted = true;
			this.InitTraceElement();
			if (this.TagComponent != null && this.TagComponent.Valid)
			{
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止攀爬"]))
				{
					this.ForbiddenClimbKey = new int?(base.Disable("[CharacterClimbComponent.OnStart] 包含了禁止攀爬Tag"));
				}
				this.TagComponent.ListenForTagAnyCountChanged(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止攀爬"], new BaseTagComponent.TTagChangedCallback(this.OnForbiddenClimbChanged));
				this.TagComponent.ListenForTagAnyCountChanged(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止上墙"], new BaseTagComponent.TTagChangedCallback(this.OnForbiddenClimbOnWall));
				this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制快速攀爬"]), new BaseTagComponent.TTagSwitchedCallback(this.OnForceFastClimb), null);
			}
			this.LastSafeLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			return true;
		}

		// Token: 0x06030E5D RID: 200285 RVA: 0x00C1E2FC File Offset: 0x00C1C4FC
		private void InitTraceElement()
		{
			this.TraceElement = new UTraceSphereElement();
			this.TraceElement.WorldContextObject = this.ActorComp.Owner;
			this.TraceElement.bIgnoreSelf = true;
			this.TraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
			this.TraceElement.SetDrawDebugTrace(this.DebugEnterClimbTrace);
			this.TraceElement.DrawTime = 5f;
			this.TraceElement.Radius = this.ClimbConfig.Value.ClimbRadius * 0.85f;
			Singleton<TraceElementCommon>.Instance.SetTraceColor(this.TraceElement, CharacterClimbComponent.TraceColor);
			Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.TraceElement, CharacterClimbComponent.TraceSuccessColor);
		}

		// Token: 0x06030E5E RID: 200286 RVA: 0x00C1E3B5 File Offset: 0x00C1C5B5
		protected override void OnActivate()
		{
			this.CapsuleHalfHeight = this.ActorComp.ScaledHalfHeight;
			this.UpdateClimbDebug();
		}

		// Token: 0x06030E5F RID: 200287 RVA: 0x00C1E3D0 File Offset: 0x00C1C5D0
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChanged));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CustomMoveClimb, new Action<float>(this.ReceiveClimbEvent));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
			Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制快速攀爬"], new BaseTagComponent.TTagSwitchedCallback(this.OnForceFastClimb));
			}
			return true;
		}

		// Token: 0x06030E60 RID: 200288 RVA: 0x00C1E4A8 File Offset: 0x00C1C6A8
		protected unsafe override void OnTick(float delta)
		{
			CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Ride)
			{
				return;
			}
			if (ModelBase<SundryModel>.Instance.SceneCheckOn)
			{
				double num = global::Vector.Dist(this.ActorComp.ActorLocationProxy, this.CachedActorLocation);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "TickMove";
				<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray8<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PrevLocation", this.CachedActorLocation);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CurrentLocation", this.ActorComp.ActorLocationProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("MovementMode", this.MoveComp.CharacterMovement.MovementMode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("CustomMode", this.MoveComp.CharacterMovement.CustomMovementMode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Delta", delta);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("Dist", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("MainAnim", (this.AnimComp.MainAnimInstance as UKuroAnimInstance).GetDebugAnimNodeString());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 8));
				if (num > (double)(2f * delta))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Test;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "OverSpeed";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Velocity", this.ActorComp.ActorVelocityProxy);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				if (num > 500.0)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Test;
					ELogAuthor author3 = ELogAuthor.LCZ;
					string message3 = "OverSpeed2";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Velocity", this.ActorComp.ActorVelocityProxy);
					instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
				actorTrace.WorldContextObject = this.ActorComp.Actor;
				actorTrace.Radius = 5f;
				Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.CachedActorLocation);
				Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.ActorComp.ActorLocationProxy);
				if (Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "CharacterClimbComponent_DetectClimbFromTop", "CharacterClimbComponent_DetectClimbFromTop"))
				{
					UKuroHitResult hitResult = actorTrace.HitResult;
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Test;
					ELogAuthor author4 = ELogAuthor.LCZ;
					string message4 = "MoveHit Something";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", hitResult.Actors.Get(0).Get());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Comp", hitResult.Components.Get(0).Get());
					instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				this.CachedActorLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			}
			global::Vector inputDirectProxy = this.ActorComp.InputDirectProxy;
			if (this.ClimbState != EClimbState.无)
			{
				if (inputDirectProxy.ContainsNaN())
				{
					this.ClimbInputDirect.Reset();
					Log instance5 = Singleton<Log>.Instance;
					ELogModule module5 = ELogModule.Movement;
					ELogAuthor author5 = ELogAuthor.LCZ;
					string message5 = "Set Climb Input Nan.";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Input", inputDirectProxy);
					instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}
				else
				{
					this.ClimbInputDirect.X = inputDirectProxy.X;
					this.ClimbInputDirect.Y = inputDirectProxy.Y;
				}
				if (this.OnWallAngle != 0f)
				{
					if (this.PrevClimbInputDirect.IsNearlyZero(9.999999747378752E-05))
					{
						this.PrevClimbInputDirect.DeepCopy(this.ClimbInputDirect);
					}
					else if (!this.PrevClimbInputDirect.Equals(this.ClimbInputDirect, 9.999999747378752E-05))
					{
						this.OnWallAngle = 0f;
					}
				}
			}
			else
			{
				this.ClimbInputDirect.Reset();
				this.PrevClimbInputDirect.Reset();
			}
			bool flag = this.UnifiedStateComponent.PositionState == global::ECharPositionState.Climb;
			if (!flag)
			{
				this.LastSafeLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			}
			else if (this.ClimbState != EClimbState.退出攀爬)
			{
				global::Vector lastSafeLocation = this.LastSafeLocation;
				FVectorDouble fvectorDouble = this.KuroClimbObject.D_GetSafetyLocation();
				lastSafeLocation.FromUeVector(fvectorDouble);
			}
			if (flag)
			{
				if (this.ExitClimbCountDown > 0f)
				{
					this.ExitClimbCountDown -= delta;
					if (this.ExitClimbCountDown <= 0f)
					{
						this.OnExitClimb();
						flag = false;
					}
				}
			}
			else
			{
				this.ExitClimbCountDown = 0f;
			}
			if (!flag && !this.PreCharacterStateInClimb)
			{
				if (!this.MoveComp.HasMoveInput)
				{
					CharacterUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
					if (unifiedStateComponent2 == null || unifiedStateComponent2.MoveState != global::ECharMoveState.Soar)
					{
						goto IL_509;
					}
				}
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.方向状态.面朝方向"]) || Singleton<MathUtils>.Instance.DotProduct(inputDirectProxy, this.ActorComp.ActorForwardProxy) > 0.7070000171661377)
				{
					this.SetClimbState(EClimbState.无);
					this.DetectClimb(delta);
				}
			}
			IL_509:
			if (flag && ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength) <= 0f && this.ClimbState != EClimbState.退出攀爬 && !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFFID.体力消耗.攀爬跳跃"]))
			{
				this.NormalExitClimb();
			}
			this.PreCharacterStateInClimb = flag;
			if (CharacterClimbComponent.DebugLogController && flag)
			{
				this.PrintClimbDebugLog();
			}
			if (flag && this.ForceFastClimb)
			{
				CharacterUnifiedStateComponent unifiedStateComponent3 = this.UnifiedStateComponent;
				if (unifiedStateComponent3 != null && unifiedStateComponent3.MoveState == global::ECharMoveState.NormalClimb)
				{
					CharacterUnifiedStateComponent unifiedStateComponent4 = this.UnifiedStateComponent;
					if (unifiedStateComponent4 == null)
					{
						return;
					}
					unifiedStateComponent4.SwitchFastClimb(true, false);
				}
			}
		}

		// Token: 0x06030E61 RID: 200289 RVA: 0x00C1EA49 File Offset: 0x00C1CC49
		public EExitClimb GetExitClimbType()
		{
			return this.ExitClimbType;
		}

		// Token: 0x06030E62 RID: 200290 RVA: 0x00C1EA54 File Offset: 0x00C1CC54
		private void DetectClimb(float deltaTime)
		{
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) && !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.冲刺"]))
			{
				return;
			}
			bool flag = this.IsSprintClimb();
			if (flag && this.UnifiedStateComponent.MoveState != global::ECharMoveState.Glide && this.UnifiedStateComponent.MoveState != global::ECharMoveState.Soar)
			{
				this.DetectSprintVault();
				if (this.ClimbState != EClimbState.无)
				{
					return;
				}
			}
			if (flag || this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.钩锁"]))
			{
				this.DetectClimbByMovementMode(true);
				CharacterActorComponent actorComp = this.ActorComp;
				CharacterSkillComponent characterSkillComponent;
				if (actorComp == null)
				{
					characterSkillComponent = null;
				}
				else
				{
					Entity entity = actorComp.Entity;
					characterSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
				}
				CharacterSkillComponent characterSkillComponent2 = characterSkillComponent;
				if (this.ClimbState != EClimbState.无)
				{
					characterSkillComponent2.StopGroup1Skill("攀爬打断技能");
					return;
				}
			}
			else
			{
				this.DetectClimbByMovementMode(false);
			}
		}

		// Token: 0x06030E63 RID: 200291 RVA: 0x00C1EB34 File Offset: 0x00C1CD34
		private void DetectClimbByMovementMode(bool bSprintEnter)
		{
			switch (this.UnifiedStateComponent.PositionState)
			{
			case global::ECharPositionState.Ground:
				this.DetectClimbWalking(bSprintEnter);
				return;
			case global::ECharPositionState.Climb:
				break;
			case global::ECharPositionState.Air:
				if (!CharacterClimbComponent.CanEnterClimbAirStates.Contains(this.UnifiedStateComponent.MoveState))
				{
					if (this.UnifiedStateComponent.MoveState == global::ECharMoveState.Soar)
					{
						this.DetectUpArriveBothVaultAndOnTop();
						if (this.ClimbState != EClimbState.无)
						{
							return;
						}
						this.SpeedDirect.FromUeVector(this.ActorComp.ActorVelocityProxy);
						Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.SpeedDirect);
						this.DetectEnterClimbWithDirectInternal(bSprintEnter ? EEnterClimb.技能进入 : EEnterClimb.空中进入, this.SpeedDirect, false);
						return;
					}
				}
				else if (this.IsForwardBlock())
				{
					this.DetectUpArriveBothVaultAndOnTop();
					if (this.ClimbState != EClimbState.无)
					{
						return;
					}
					this.DetectEnterClimb(bSprintEnter ? EEnterClimb.技能进入 : (this.MoveComp.IsJump ? EEnterClimb.地面上爬进入 : EEnterClimb.空中进入));
					return;
				}
				break;
			case global::ECharPositionState.Water:
				if (this.IsForwardBlock() && base.Entity.GetComponent<CharacterSwimComponent>().CheckCanEnterClimbFromSwim())
				{
					this.DetectUpArriveBothVaultAndOnTop();
					if (this.ClimbState == EClimbState.无)
					{
						this.DetectEnterClimb(EEnterClimb.水中进入);
					}
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06030E64 RID: 200292 RVA: 0x00C1EC4C File Offset: 0x00C1CE4C
		private void DetectUpArriveBothVaultAndOnTop()
		{
			EClimbingArriveType eclimbingArriveType = this.KuroClimbObject.D_TryUpArrives(this.ActorComp.ActorForward, this.GetTimeFromTraceType(this.DebugVaultClimbTrace), ref this.RefTransform);
			if (eclimbingArriveType == EClimbingArriveType.ClimbOnTop)
			{
				this.UpArrive(EExitClimb.到顶退出, this.RefTransform, true);
				return;
			}
			if (eclimbingArriveType != EClimbingArriveType.ClimbVault)
			{
				return;
			}
			this.UpArrive(EExitClimb.地面登上, this.RefTransform, true);
		}

		// Token: 0x06030E65 RID: 200293 RVA: 0x00C1ECB0 File Offset: 0x00C1CEB0
		private void DetectClimbWalking(bool bSprintEnter)
		{
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.行走"]))
			{
				this.DetectClimbFromTop();
				if (this.ClimbState != EClimbState.无)
				{
					return;
				}
			}
			if (!this.IsForwardBlock())
			{
				return;
			}
			this.DetectUpArriveBothVaultAndOnTop();
			if (this.ClimbState != EClimbState.无)
			{
				return;
			}
			this.DetectEnterClimb(bSprintEnter ? EEnterClimb.技能进入 : EEnterClimb.地面上爬进入);
		}

		// Token: 0x06030E66 RID: 200294 RVA: 0x00C1ED10 File Offset: 0x00C1CF10
		private void CleanClimbState()
		{
			this.KuroClimbObject.ExitClimb();
			this.SetClimbState(EClimbState.无);
			this.SetExitClimbType(EExitClimb.未知方式);
			this.CacheLastMoveDirect.Set(0.0, 0.0, 0.0);
			this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, false);
			this.ClimbBlocking = false;
		}

		// Token: 0x06030E67 RID: 200295 RVA: 0x00C1ED7F File Offset: 0x00C1CF7F
		public bool CanClimbPress()
		{
			return true;
		}

		// Token: 0x06030E68 RID: 200296 RVA: 0x00C1ED84 File Offset: 0x00C1CF84
		private void NormalExitClimb()
		{
			if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy) > 0.0)
			{
				this.TmpVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
				Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector);
				this.MoveComp.SetForceSpeed(this.TmpVector);
			}
			if (this.ClimbState == EClimbState.攀爬中)
			{
				this.ClimbingExitPositionFix();
			}
			if (this.UnifiedStateComponent.MoveState == global::ECharMoveState.FastClimb)
			{
				this.TmpVector.DeepCopy(this.ActorComp.InputDirectProxy);
				if (!this.TmpVector.IsNearlyZero(9.999999747378752E-05) && Math.Abs(this.TmpVector.Y) > 1E-08)
				{
					global::Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
					global::Vector actorRightProxy = this.ActorComp.ActorRightProxy;
					actorForwardProxy.Multiply(Math.Abs(this.TmpVector.X), this.TmpVector2);
					actorRightProxy.Multiply(this.TmpVector.Y, this.TmpVector3);
					this.TmpVector2.AdditionEqual(this.TmpVector3);
					Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector2, this.MoveComp.GravityUp, this.TmpQuat);
					FTransformDouble actorTransform = this.ActorComp.ActorTransform;
					FQuat fquat = this.TmpQuat.ToUeQuat();
					actorTransform.SetRotation(fquat);
					this.SetCharacterTransformAndBuffer(actorTransform, 300f, null, true);
				}
			}
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[CharacterClimbComponent.NormalExitClimb]"
			});
		}

		// Token: 0x06030E69 RID: 200297 RVA: 0x00C1EF38 File Offset: 0x00C1D138
		public void ClimbPress(bool pressed)
		{
			CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Climb && (this.ClimbState == EClimbState.攀爬中 || (this.ClimbState == EClimbState.进入攀爬 && this.IsAllowEarlyExitClimb)))
			{
				this.NormalExitClimb();
				this.NextCanEnterClimbTime = (float)Singleton<Time>.Instance.Now + 500f;
			}
		}

		// Token: 0x06030E6A RID: 200298 RVA: 0x00C1EF94 File Offset: 0x00C1D194
		private float CalculateClimbAngle(global::Vector inputDirect, global::Vector wallNormal)
		{
			this.TmpVector.DeepCopy(wallNormal);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector);
			this.TmpVector.Normalize(9.99999993922529E-09);
			return Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(this.ActorComp, wallNormal, inputDirect);
		}

		// Token: 0x06030E6B RID: 200299 RVA: 0x00C1EFEB File Offset: 0x00C1D1EB
		protected bool NeedProcessTransform()
		{
			return (this.ClimbState != EClimbState.进入攀爬 || this.ClimbDownCompleted) && (this.ClimbState == EClimbState.攀爬中 || this.ClimbState == EClimbState.进入攀爬);
		}

		// Token: 0x06030E6C RID: 200300 RVA: 0x00C1F018 File Offset: 0x00C1D218
		private void ConfirmMove(FTransformDouble newTransform, float CachedTime = 200f)
		{
			global::Vector tmpVector = this.TmpVector;
			FVectorDouble location = newTransform.GetLocation();
			tmpVector.FromUeVector(location);
			if (this.AnimComp != null && this.AnimComp.Valid && Singleton<MathUtils>.Instance.DotProduct(newTransform.GetRotation().GetForwardVector(), this.CacheTransformBeforeMove.Value.GetRotation().GetForwardVector()) < 0.8999999761581421)
			{
				this.SetCharacterTransformAndBuffer(newTransform, CachedTime, null, true);
			}
			else
			{
				this.ActorComp.SetActorTransform(newTransform, "攀爬.ConfirmMove", true, null);
			}
			this.KuroClimbObject.ConfirmMove();
		}

		// Token: 0x06030E6D RID: 200301 RVA: 0x00C1F0CC File Offset: 0x00C1D2CC
		private bool IsForwardBlock()
		{
			global::Vector tmpVector = this.TmpVector;
			FVector fvector = this.MoveComp.CharacterMovement.Kuro_GetBlockDirectWhenMove();
			tmpVector.FromUeVector(fvector);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector);
			return this.TmpVector.Normalize(9.99999993922529E-09) && this.ActorComp.InputDirectProxy.DotProduct(this.TmpVector) <= -0.7070000171661377;
		}

		// Token: 0x06030E6E RID: 200302 RVA: 0x00C1F14C File Offset: 0x00C1D34C
		private unsafe void UpArrive(EExitClimb exitType, FTransformDouble transform, bool changeMovementMode = true)
		{
			if (this.UnifiedStateComponent.PositionState == global::ECharPositionState.Ground)
			{
				this.MoveComp.PlayerMotionRequest(MotionType.StepAcross);
			}
			else
			{
				this.MoveComp.PlayerMotionRequest(MotionType.ClimbTop);
			}
			if (changeMovementMode)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Custom,
						Context = "[CharacterClimbComponent.UpArrive]"
					});
				}
			}
			this.SetClimbState(EClimbState.退出攀爬);
			this.ExitClimbCountDown = 800f;
			this.SetExitClimbType(exitType);
			Singleton<EventSystem>.Instance.Emit<int, EExitClimb>(EEventName.CharClimbStartExit, base.Entity.Id, exitType);
			FVectorDouble fvectorDouble;
			if (this.IsSprintClimb())
			{
				if (exitType == EExitClimb.到顶退出)
				{
					this.SetExitClimbType(EExitClimb.跑墙退出);
				}
				else if (exitType == EExitClimb.地面登上)
				{
					this.SetExitClimbType(EExitClimb.冲刺跨越近);
					this.TmpVector.Set(0.0, 0.0, (double)(this.ClimbVault.Value.Z - this.ClimbSprintVault.Value.Z));
					fvectorDouble = this.TmpVector.ToUeVector(false);
					FVectorDouble fvectorDouble2 = transform.TransformPosition(fvectorDouble);
					transform.SetLocation(fvectorDouble2);
				}
			}
			global::Vector climbUpNewLocation = this.ClimbUpNewLocation;
			fvectorDouble = transform.GetLocation();
			climbUpNewLocation.FromUeVector(fvectorDouble);
			if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorForwardProxy) <= 0.0)
			{
				fvectorDouble = this.ActorComp.ActorLocation;
				transform.SetLocation(fvectorDouble);
				this.ClimbUpNewLocation.Subtraction(this.ActorComp.ActorLocationProxy, this.TmpVector);
				Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, 2.0);
			}
			else
			{
				this.TmpVector.DeepCopy(this.ClimbUpNewLocation);
				Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, this.TmpVector, Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorLocationProxy));
				fvectorDouble = this.TmpVector.ToUeVector(false);
				transform.SetLocation(fvectorDouble);
				this.TmpVector.Reset();
				this.ClimbUpNewLocation.Subtraction(this.ActorComp.ActorLocationProxy, this.TmpVector2);
				Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVector2) + 2.0);
			}
			ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(base.Entity.Id, "ClimbOnTopMove", this.TmpVector.X, this.TmpVector.Y, this.TmpVector.Z);
			if (exitType == EExitClimb.反斜登顶)
			{
				FVector secondMoveOffset = this.KuroClimbObject.GetSecondMoveOffset();
				ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(base.Entity.Id, "ClimbBlockUpSecondMove", (double)secondMoveOffset.X, (double)secondMoveOffset.Y, (double)secondMoveOffset.Z);
			}
			if (ModelBase<SundryModel>.Instance.SceneCheckOn)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "UpArrive";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NewLocation", transform.GetLocation());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("From", this.ActorComp.ActorLocationProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Forward", this.ActorComp.ActorForwardProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ExitClimbType", this.ExitClimbType);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			if (this.ExitClimbType == EExitClimb.冲刺跨越近 || this.ExitClimbType == EExitClimb.冲刺跨越远 || this.ExitClimbType == EExitClimb.跑墙退出)
			{
				this.SetCharacterTransformAndBuffer(transform, 100f, null, true);
			}
			else
			{
				this.SetCharacterTransformAndBuffer(transform, 300f, null, true);
			}
			if (ModelBase<SundryModel>.Instance.SceneCheckOn)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Test;
				ELogAuthor author2 = ELogAuthor.LCZ;
				string message2 = "UpArrive2";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Location", this.ActorComp.ActorLocationProxy);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06030E6F RID: 200303 RVA: 0x00C1F55B File Offset: 0x00C1D75B
		private float GetTimeFromTraceType(EDrawDebugTrace TraceType)
		{
			if (TraceType == EDrawDebugTrace.ForOneFrame)
			{
				return 0.1f;
			}
			if (TraceType != EDrawDebugTrace.ForDuration)
			{
				return 0f;
			}
			return 5f;
		}

		// Token: 0x06030E70 RID: 200304 RVA: 0x00C1F578 File Offset: 0x00C1D778
		private void DetectClimbFromTop()
		{
		}

		// Token: 0x06030E71 RID: 200305 RVA: 0x00C1F588 File Offset: 0x00C1D788
		private void DetectEnterClimb(EEnterClimb enterType)
		{
			if ((double)this.NextCanEnterClimbTime > Singleton<Time>.Instance.Now || ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength) <= 10f)
			{
				return;
			}
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止上墙"]))
			{
				return;
			}
			if (this.UnifiedStateComponent.PositionState == global::ECharPositionState.Air && this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
			{
				this.SpeedDirect.DeepCopy(this.ActorComp.InputDirectProxy);
			}
			else
			{
				global::Vector actorVelocityProxy = this.ActorComp.ActorVelocityProxy;
				if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, actorVelocityProxy) < -500.0)
				{
					return;
				}
				this.ActorComp.InputDirectProxy.Multiply(500.0, this.SpeedDirect);
				this.SpeedDirect.AdditionEqual(actorVelocityProxy);
			}
			this.DetectEnterClimbWithDirectInternal(enterType, this.SpeedDirect, false);
		}

		// Token: 0x06030E72 RID: 200306 RVA: 0x00C1F680 File Offset: 0x00C1D880
		private unsafe void DetectEnterClimbWithDirectInternal(EEnterClimb enterType, global::Vector speedDirect, bool log = false)
		{
			if (!speedDirect.Normalize(9.99999993922529E-09))
			{
				return;
			}
			if (this.ClimbTrans == null)
			{
				this.ClimbTrans = global::Transform.Create();
			}
			this.ClimbTrans.SetLocation(this.ActorComp.ActorLocationProxy);
			this.ClimbTrans.SetScale3D(this.ActorComp.ActorScaleProxy);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(speedDirect, this.MoveComp.GravityUp, this.ClimbTrans.GetRotation());
			if (!this.KuroClimbObject.D_TryStartClimb(this.ClimbTrans.ToUeTransform(), this.GetTimeFromTraceType(this.DebugEnterClimbTrace), ref this.RefTransform))
			{
				if (log)
				{
					Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.CWZ, "TryStartClimb检测非法，进入攀爬失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return;
			}
			this.TmpQuat.FromUeQuat(this.RefTransform.GetRotation());
			this.TmpQuat.GetForwardVector(this.TmpVector);
			if (Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityAbsForActor(this.ActorComp, this.TmpVector, speedDirect) > 35f)
			{
				if (log)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "超过一定角度则不允许进入攀爬";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("speedDirect", speedDirect);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TmpVector", this.TmpVector);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				return;
			}
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Custom,
				CustomMode = 0,
				Context = "CharacterClimbComponent.DetectEnterClimbWithDirectInternal",
				Callback = delegate()
				{
					if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]))
					{
						this.SetClimbState(EClimbState.攀爬中);
					}
					else
					{
						this.SetClimbState(EClimbState.进入攀爬);
					}
					this.SetEnterClimbType(enterType);
					if (enterType == EEnterClimb.技能进入)
					{
						this.UnifiedStateComponent.SwitchFastClimb(true, false);
						global::Vector vector = global::Vector.Create(this.RefTransform.GetRotation().GetForwardVector());
						vector.Normalize(1E-08);
						this.OnWallAngle = this.CalculateClimbAngle(this.ActorComp.ActorForwardProxy, vector);
					}
					else
					{
						this.OnWallAngle = 0f;
					}
					this.ConfirmMove(this.RefTransform, 200f);
					this.ClimbDownCompleted = true;
					if (log)
					{
						Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.CWZ, "成功进入攀爬状态", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
			});
		}

		// Token: 0x06030E73 RID: 200307 RVA: 0x00C1F850 File Offset: 0x00C1DA50
		private void DownArrive()
		{
			this.NormalExitClimb();
		}

		// Token: 0x06030E74 RID: 200308 RVA: 0x00C1F858 File Offset: 0x00C1DA58
		private void DetectSprintVault()
		{
			ESprintVaultType esprintVaultType = this.KuroClimbObject.D_TrySprintVault(this.GetTimeFromTraceType(this.DebugVaultClimbTrace), ref this.RefTransform, ref this.RefFloat);
			if (esprintVaultType != ESprintVaultType.Short)
			{
				if (esprintVaultType != ESprintVaultType.Long)
				{
					return;
				}
				FTransformDouble refTransform = this.RefTransform;
				this.UpArrive(EExitClimb.冲刺跨越远, refTransform, true);
				this.TmpQuat.FromUeQuat(refTransform.GetRotation());
				this.TmpQuat.RotateVector(global::Vector.ForwardVectorProxy, this.TmpVector);
				this.TmpVector.MultiplyEqual((double)this.RefFloat);
				ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(base.Entity.Id, "ClimbAddMove", this.TmpVector.X, this.TmpVector.Y, this.TmpVector.Z);
			}
			else
			{
				this.UpArrive(EExitClimb.冲刺跨越近, this.RefTransform, true);
			}
			ControllerBase<RoleAudioController>.Instance.PlayRoleAudio(base.Entity, ERoleAudioType.ClimbLeap, null);
		}

		// Token: 0x06030E75 RID: 200309 RVA: 0x00C1F948 File Offset: 0x00C1DB48
		public void DealClimbUpStart()
		{
		}

		// Token: 0x06030E76 RID: 200310 RVA: 0x00C1F94C File Offset: 0x00C1DB4C
		public unsafe void DealClimbUpFinish()
		{
			EResultForExitClimb eresultForExitClimb = LocomotionUtils.FindSpaceForExitClimb(this.ActorComp, this.ActorComp.DefaultHalfHeight, this.ActorComp.DefaultRadius, 5f, this.TmpVector);
			if (eresultForExitClimb == EResultForExitClimb.Safety)
			{
				this.TmpTransform.Set(this.TmpVector, this.ActorComp.ActorQuatProxy, this.ActorComp.ActorScaleProxy);
				this.SetCharacterTransformAndBuffer(this.TmpTransform.ToUeTransform(), 100f, null, false);
			}
			else if (eresultForExitClimb == EResultForExitClimb.NoSafety)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "DealClimbUpFinish NotSafety";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "CurrentLocation";
				CharacterActorComponent actorComp = this.ActorComp;
				ptr = new ValueTuple<string, object>(item, (actorComp != null) ? actorComp.ActorLocationProxy : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Last", this.LastSafeLocation);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.TmpTransform.Set(this.LastSafeLocation, this.ActorComp.ActorQuatProxy, this.ActorComp.ActorScaleProxy);
				this.SetCharacterTransformAndBuffer(this.TmpTransform.ToUeTransform(), 100f, null, false);
			}
			this.ActorComp.ResetCapsuleRadiusAndHeight(false);
		}

		// Token: 0x06030E77 RID: 200311 RVA: 0x00C1FA88 File Offset: 0x00C1DC88
		private unsafe void ClimbEvent(float deltaTime)
		{
			bool flag = this.NeedProcessTransform();
			if (ModelBase<SundryModel>.Instance.SceneCheckOn)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "ProcessClimbing";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Location", this.ActorComp.ActorLocationProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HasKuroRootMotionAnim", this.AnimComp.GetAnimInstance().HasKuroRootMotionAnim());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("MoveSpeed", this.MoveComp.CharacterMovement.AnimRootMotionVelocity);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("DeltaTime", deltaTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("NeedProcess", flag);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
			global::Vector tmpVector = this.TmpVector;
			FVector animRootMotionVelocity = this.MoveComp.CharacterMovement.AnimRootMotionVelocity;
			FVectorDouble fvectorDouble = animRootMotionVelocity;
			tmpVector.DeepCopy(fvectorDouble);
			if (this.BufferTimeLength != null)
			{
				this.BufferNowTime += deltaTime;
				float bufferNowTime = this.BufferNowTime;
				float? bufferTimeLength = this.BufferTimeLength;
				float num;
				if (bufferNowTime > bufferTimeLength.GetValueOrDefault() & bufferTimeLength != null)
				{
					num = (this.BufferTimeLength.Value - this.BufferNowTime + deltaTime) / deltaTime;
				}
				else
				{
					num = 1f;
				}
				this.BufferOffsetSpeed.Multiply((double)num, this.TmpVector2);
				this.TmpVector.AdditionEqual(this.TmpVector2);
				float bufferNowTime2 = this.BufferNowTime;
				bufferTimeLength = this.BufferTimeLength;
				if (bufferNowTime2 > bufferTimeLength.GetValueOrDefault() & bufferTimeLength != null)
				{
					this.BufferTimeLength = null;
				}
			}
			if (!this.KuroClimbObject.D_ProcessClimbing(this.TmpVector.ToUeVector(false), deltaTime, flag, this.GetTimeFromTraceType(this.DebugClimbingTrace), ref this.RefTransform))
			{
				if (ModelBase<SundryModel>.Instance.SceneCheckOn)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Test;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "ProcessClimbing Failed";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Location", this.ActorComp.Actor.D_K2_GetActorLocation());
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.NormalExitClimb();
				return;
			}
			this.ClimbBlocking = this.KuroClimbObject.ClimbBlock();
			if (ModelBase<SundryModel>.Instance.SceneCheckOn)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Test;
				ELogAuthor author3 = ELogAuthor.LCZ;
				string message3 = "ProcessClimbing Success";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Location", this.ActorComp.Actor.D_K2_GetActorLocation());
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			this.ActorComp.ResetLocationCachedTime();
			if (!flag)
			{
				return;
			}
			switch (this.KuroClimbObject.D_TryClimbingArrives(this.ActorComp.InputDirect, this.GetTimeFromTraceType(this.DebugUpArriveClimbTrace), ref this.RefTransform, this.IsSprintClimb()))
			{
			case EClimbingArriveType.ClimbOnTop:
				this.UpArrive(EExitClimb.到顶退出, this.RefTransform, false);
				return;
			case EClimbingArriveType.ClimbVault:
				this.UpArrive(EExitClimb.地面登上, this.RefTransform, false);
				return;
			case EClimbingArriveType.ClimbDownArrive:
				this.DownArrive();
				return;
			case EClimbingArriveType.ClimbBlockUp:
				this.UpArrive(EExitClimb.反斜登顶, this.RefTransform, false);
				return;
			default:
				return;
			}
		}

		// Token: 0x06030E78 RID: 200312 RVA: 0x00C1FDEC File Offset: 0x00C1DFEC
		public SClimbInfo GetClimbInfo()
		{
			if (this.ClimbInputDirect.ContainsNaN())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "GetClimbInfo Nan.";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ClimbInput", this.ClimbInputDirect);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.ClimbInputDirect.Reset();
			}
			this.ClimbInfo.攀爬移动中 = !this.AwakeInput;
			this.ClimbInfo.攀爬输入向量 = this.ClimbInputDirect.ToUeVector2D(false);
			return this.ClimbInfo;
		}

		// Token: 0x06030E79 RID: 200313 RVA: 0x00C1FE70 File Offset: 0x00C1E070
		public FClimbInfoStruct GetClimbInfoNew()
		{
			if (this.ClimbInputDirect.ContainsNaN())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "GetClimbInfo Nan.";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ClimbInput", this.ClimbInputDirect);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.ClimbInputDirect.Reset();
			}
			this.ClimbInfoNew.IsClimbMoving = !this.AwakeInput;
			this.ClimbInfoNew.ClimbInput = this.ClimbInputDirect.ToUeVector2D(false);
			this.ClimbInfoNew.OnWallAngle = this.OnWallAngle;
			return this.ClimbInfoNew;
		}

		// Token: 0x06030E7A RID: 200314 RVA: 0x00C1FF04 File Offset: 0x00C1E104
		public SClimbInfo GetTsClimbInfo()
		{
			if (this.ClimbInputDirect.ContainsNaN())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "GetClimbInfo Nan.";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ClimbInput", this.ClimbInputDirect);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.ClimbInputDirect.Reset();
			}
			this.TsClimbInfo.攀爬移动中 = !this.AwakeInput;
			this.TsClimbInfo.攀爬输入向量.DeepCopy(this.ClimbInputDirect);
			this.TsClimbInfo.OnWallAngle = this.OnWallAngle;
			return this.TsClimbInfo;
		}

		// Token: 0x06030E7B RID: 200315 RVA: 0x00C1FF98 File Offset: 0x00C1E198
		public void FinishClimbDown()
		{
			this.ClimbDownCompleted = true;
			if (this.KuroClimbObject.D_TryStartClimb(this.ActorComp.ActorTransform, 0f, ref this.RefTransform))
			{
				this.ConfirmMove(this.RefTransform, 200f);
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.LCZ, "下爬动作完成后停留在了一个不太适合攀爬的地点", default(ReadOnlySpan<ValueTuple<string, object>>));
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[CharacterClimbComponent.FinishClimbDown]"
			});
		}

		// Token: 0x06030E7C RID: 200316 RVA: 0x00C20028 File Offset: 0x00C1E228
		[NullableContext(2)]
		public void SetCharacterTransformAndBuffer(FTransformDouble newTransform, float smoothTime, global::Vector newLocation = null, bool sweep = true)
		{
			this.BufferTimeLength = null;
			if (newLocation != null)
			{
				if (smoothTime > 0f)
				{
					global::Vector tmpVector = this.TmpVector;
					FVectorDouble fvectorDouble = newTransform.GetTranslation();
					tmpVector.FromUeVector(fvectorDouble);
					newLocation.Subtraction(this.TmpVector, this.BufferOffsetSpeed);
					this.BufferOffsetSpeed.DivisionEqual((double)smoothTime * Singleton<TimeUtil>.Instance.Millisecond);
					this.BufferNowTime = 0f;
					this.BufferTimeLength = new float?(smoothTime * (float)Singleton<TimeUtil>.Instance.Millisecond);
				}
				else
				{
					FVectorDouble fvectorDouble = newLocation.ToUeVector(false);
					newTransform.SetLocation(fvectorDouble);
				}
			}
			if (this.AnimComp != null && this.AnimComp.Valid)
			{
				this.AnimComp.SetTransformWithModelBuffer(newTransform, smoothTime, null, sweep);
				return;
			}
			this.ActorComp.SetActorTransform(newTransform, "攀爬.SetCharacterTransformAndBuffer", sweep, null);
		}

		// Token: 0x06030E7D RID: 200317 RVA: 0x00C2010E File Offset: 0x00C1E30E
		public void KickWallExit()
		{
			this.SetExitClimbType(EExitClimb.蹬墙退出);
			this.SetClimbState(EClimbState.退出攀爬);
		}

		// Token: 0x06030E7E RID: 200318 RVA: 0x00C20120 File Offset: 0x00C1E320
		public unsafe void SetClimbState(EClimbState climbState)
		{
			if (this.ClimbState == climbState)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SetClimbState";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("From", this.ClimbState);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("To", climbState);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.ClimbState = climbState;
			this.TsOutputClimbState.攀爬状态 = climbState;
			if (this.UnifiedStateComponent.PositionState != global::ECharPositionState.Climb)
			{
				return;
			}
			switch (climbState)
			{
			case EClimbState.进入攀爬:
				this.UnifiedStateComponent.SetMoveState(global::ECharMoveState.EnterClimb);
				return;
			case EClimbState.攀爬中:
				if (this.ClimbInputDirect.IsNearlyZero(9.999999747378752E-05))
				{
					this.UnifiedStateComponent.SetMoveState(global::ECharMoveState.Other);
					return;
				}
				this.UnifiedStateComponent.SwitchFastClimb(this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]), true);
				return;
			case EClimbState.退出攀爬:
				this.UnifiedStateComponent.SetMoveState(global::ECharMoveState.ExitClimb);
				return;
			default:
				return;
			}
		}

		// Token: 0x06030E7F RID: 200319 RVA: 0x00C2025B File Offset: 0x00C1E45B
		public void SetEnterClimbType(EEnterClimb enterType)
		{
			this.EnterClimbType = enterType;
			this.TsOutputClimbState.进入攀爬类型 = enterType;
		}

		// Token: 0x06030E80 RID: 200320 RVA: 0x00C20270 File Offset: 0x00C1E470
		public void SetExitClimbType(EExitClimb exitClimbType)
		{
			bool flag = this.NotConsumeStrengthExitClimbTypes.Contains(this.ExitClimbType);
			bool flag2 = this.NotConsumeStrengthExitClimbTypes.Contains(exitClimbType);
			if (flag)
			{
				if (!flag2)
				{
					this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFFID.体力消耗.Buff体力消耗无效"]));
				}
			}
			else if (flag2)
			{
				this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.BUFFID.体力消耗.Buff体力消耗无效"]));
			}
			this.ExitClimbType = exitClimbType;
			this.TsOutputClimbState.退出攀爬类型 = exitClimbType;
			if (exitClimbType != EExitClimb.未知方式)
			{
				this.LastExitClimbType = exitClimbType;
				this.LastExitClimbTime = (float)Singleton<Time>.Instance.PlayerWorldTime;
			}
		}

		// Token: 0x06030E81 RID: 200321 RVA: 0x00C20314 File Offset: 0x00C1E514
		public SClimbState GetClimbState()
		{
			this.OutputClimbState.攀爬状态 = this.ClimbState;
			this.OutputClimbState.进入攀爬类型 = this.EnterClimbType;
			this.OutputClimbState.退出攀爬类型 = this.ExitClimbType;
			return this.OutputClimbState;
		}

		// Token: 0x06030E82 RID: 200322 RVA: 0x00C20369 File Offset: 0x00C1E569
		public FClimbStateStruct GetClimbStateNew()
		{
			this.OutputClimbStateNew.ClimbState = (EClimbStateType)this.ClimbState;
			this.OutputClimbStateNew.EnterClimbType = (EEnterClimbType)this.EnterClimbType;
			this.OutputClimbStateNew.ExitClimbType = (EExitClimbType)this.ExitClimbType;
			return this.OutputClimbStateNew;
		}

		// Token: 0x06030E83 RID: 200323 RVA: 0x00C203A4 File Offset: 0x00C1E5A4
		public SClimbState GetTsClimbState()
		{
			return this.TsOutputClimbState;
		}

		// Token: 0x06030E84 RID: 200324 RVA: 0x00C203AC File Offset: 0x00C1E5AC
		public float GetOnWallAngle()
		{
			return this.OnWallAngle;
		}

		// Token: 0x06030E85 RID: 200325 RVA: 0x00C203B4 File Offset: 0x00C1E5B4
		public void OnEnterClimb()
		{
			if (this.ClimbState != EClimbState.进入攀爬)
			{
				return;
			}
			this.SetClimbState(EClimbState.攀爬中);
			this.SetExitClimbType(EExitClimb.未知方式);
		}

		// Token: 0x06030E86 RID: 200326 RVA: 0x00C203D0 File Offset: 0x00C1E5D0
		public unsafe void OnExitClimb()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "OnExitClimb";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.ClimbState == EClimbState.无)
			{
				return;
			}
			switch (this.ExitClimbType)
			{
			case EExitClimb.到顶退出:
			case EExitClimb.到底退出:
			case EExitClimb.跑墙退出:
			case EExitClimb.地面登上:
			case EExitClimb.冲刺跨越近:
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp == null)
				{
					goto IL_CB;
				}
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Walking,
					Context = "[CharacterClimbComponent.OnExitClimb] Walking"
				});
				goto IL_CB;
			}
			}
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Falling,
					Context = "[CharacterClimbComponent.OnExitClimb] Falling"
				});
			}
			IL_CB:
			float? bufferTimeLength = this.BufferTimeLength;
			float num = 0f;
			if (bufferTimeLength.GetValueOrDefault() > num & bufferTimeLength != null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Movement;
				ELogAuthor author2 = ELogAuthor.LCZ;
				string message2 = "ClimbUp Buffer is not finished";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Now", this.BufferNowTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TimeLength", this.BufferTimeLength);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.BufferTimeLength = null;
			}
		}

		// Token: 0x06030E87 RID: 200327 RVA: 0x00C2053D File Offset: 0x00C1E73D
		public void ClimbKeyPressed(bool pressed)
		{
			this.ClimbPress(pressed);
		}

		// Token: 0x06030E88 RID: 200328 RVA: 0x00C20546 File Offset: 0x00C1E746
		public void AwakeClimbInput(bool awake)
		{
			this.AwakeInput = awake;
		}

		// Token: 0x06030E89 RID: 200329 RVA: 0x00C20550 File Offset: 0x00C1E750
		public void KickExitCheck()
		{
			if (this.UnifiedStateComponent.PositionState == global::ECharPositionState.Climb)
			{
				if (this.ClimbInputDirect.X < -0.7070000171661377)
				{
					this.KickWallExit();
					return;
				}
				CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
				if (component.Valid)
				{
					component.ClimbDash();
				}
			}
		}

		// Token: 0x06030E8A RID: 200330 RVA: 0x00C205A4 File Offset: 0x00C1E7A4
		public float GetClimbRadius()
		{
			if (this.ClimbConfig == null)
			{
				return 0f;
			}
			return this.ClimbConfig.Value.ClimbRadius;
		}

		// Token: 0x06030E8B RID: 200331 RVA: 0x00C205D8 File Offset: 0x00C1E7D8
		public bool DetectClimbWithDirect(bool bSprintEnter, FVectorDouble direct, bool log = false)
		{
			if (!base.Active || this.UnifiedStateComponent.PositionState == global::ECharPositionState.Climb)
			{
				if (log)
				{
					Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.CWZ, "已处于攀爬状态，进入攀爬检测失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return false;
			}
			this.SetClimbState(EClimbState.无);
			EClimbingArriveType eclimbingArriveType = this.KuroClimbObject.D_TryUpArrives(direct, this.GetTimeFromTraceType(this.DebugEnterClimbTrace), ref this.RefTransform);
			if (eclimbingArriveType == EClimbingArriveType.ClimbOnTop)
			{
				this.UpArrive(EExitClimb.到顶退出, this.RefTransform, true);
				if (log)
				{
					Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.CWZ, "到顶退出进入攀爬", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return true;
			}
			if (eclimbingArriveType != EClimbingArriveType.ClimbVault)
			{
				this.SpeedDirect.FromUeVector(direct);
				this.DetectEnterClimbWithDirectInternal(bSprintEnter ? EEnterClimb.技能进入 : (this.MoveComp.IsJump ? EEnterClimb.地面上爬进入 : EEnterClimb.空中进入), this.SpeedDirect, log);
				return this.ClimbState > EClimbState.无;
			}
			this.UpArrive(EExitClimb.地面登上, this.RefTransform, true);
			if (log)
			{
				Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.CWZ, "地面登上进入攀爬", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return true;
		}

		// Token: 0x06030E8C RID: 200332 RVA: 0x00C206E9 File Offset: 0x00C1E8E9
		public void ResetClimbObjectConfig(string key)
		{
			this.InitClimbConfig(key);
		}

		// Token: 0x06030E8D RID: 200333 RVA: 0x00C206F4 File Offset: 0x00C1E8F4
		private bool InitClimbConfig(string key)
		{
			this.ClimbConfig = ConfigClimbById.GetConfig(key, true);
			if (this.ClimbConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "没有配置攀爬";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleBody", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (this.KuroClimbObject == null)
			{
				this.KuroClimbObject = new UKuroClimbObject(this.ActorComp.Actor, null, EObjectFlags.RF_NoFlags);
			}
			TArray<FVector> tarray = new TArray<FVector>();
			foreach (Aki.Config.Vector value in this.ClimbConfig.Value.ClimbDetectPointsIter())
			{
				tarray.Add(WorldGlobal.ToUeVectorOld(VectorExtension.ToProtocolVector(new Aki.Config.Vector?(value))));
			}
			this.KuroClimbObject.InitBase(this.ActorComp.Actor.CapsuleComponent, KuroCollisionChannel.Climb, tarray, this.ClimbConfig.Value.DetectRadius, this.ClimbConfig.Value.ClimbRadius, 150f, 0f, 0f);
			this.KuroClimbObject.InitClimbSafety(25f, 85f, 100f);
			this.ClimbVault = new FVector?(WorldGlobal.ToUeVectorOld(VectorExtension.ToProtocolVector(this.ClimbConfig.Value.ClimbVault)));
			this.ClimbOnTop = new FVector?(WorldGlobal.ToUeVectorOld(VectorExtension.ToProtocolVector(this.ClimbConfig.Value.ClimbOnTop)));
			this.ClimbFromTop = new FVector?(WorldGlobal.ToUeVectorOld(VectorExtension.ToProtocolVector(this.ClimbConfig.Value.ClimbFromTop)));
			this.ClimbSprintVault = new FVector?(WorldGlobal.ToUeVectorOld(VectorExtension.ToProtocolVector(this.ClimbConfig.Value.ClimbSprintVault)));
			this.ClimbInfo = default(SClimbInfo);
			this.ClimbInfoNew = new FClimbInfoStruct();
			this.TsClimbInfo = new SClimbInfo(null, null, null);
			this.OutputClimbState = default(SClimbState);
			this.OutputClimbStateNew = new FClimbStateStruct();
			this.TsOutputClimbState = new SClimbState(null, null, null);
			tarray.Empty(true);
			TArray<float> tarray2 = new TArray<float>();
			TArray<float> tarray3 = new TArray<float>();
			tarray.Add(this.ClimbOnTop.Value);
			tarray2.Add(this.ClimbConfig.Value.UpArriveRange.Value.Min);
			tarray3.Add(this.ClimbConfig.Value.UpArriveRange.Value.Max);
			tarray.Add(this.ClimbVault.Value);
			tarray2.Add(this.ClimbConfig.Value.VaultRange.Value.Min);
			tarray3.Add(this.ClimbConfig.Value.VaultRange.Value.Max);
			this.KuroClimbObject.InitUpArrives(tarray, tarray2, tarray3);
			this.KuroClimbObject.InitSprintVault(this.ClimbConfig.Value.ForwardBlockHeight, this.ClimbConfig.Value.ForwardBlockRadius, this.ClimbConfig.Value.ForwardBlockDistance.Value.Min, this.ClimbConfig.Value.ForwardBlockDistance.Value.Max, this.ClimbSprintVault.Value, this.ClimbConfig.Value.SprintVaultRange.Value.Min, this.ClimbConfig.Value.SprintVaultRange.Value.Max, this.ClimbConfig.Value.SprintVaultLongNeedDistance, this.ClimbConfig.Value.SprintVaultLongHeight, KuroTraceTypeQuery.AcrossBlock, this.ClimbConfig.Value.SprintVaultLongRange.Value.Min, this.ClimbConfig.Value.SprintVaultLongRange.Value.Max, 45f);
			this.KuroClimbObject.InitBlockUps(WorldGlobal.ToUeVectorOld(VectorExtension.ToProtocolVector(this.ClimbConfig.Value.BlockUpOffset)), this.ClimbConfig.Value.BlockUpDetectRadius, this.ClimbConfig.Value.BlockUpDetectDistance, this.ClimbConfig.Value.BlockUpBackDistance, this.ClimbConfig.Value.BlockUpBackMinDist, new FVector?(WorldGlobal.ToUeVectorOld(VectorExtension.ToProtocolVector(this.ClimbConfig.Value.BlockUpFinalMove))), this.ClimbConfig.Value.BlockUpVerticalRange.Value.Min, this.ClimbConfig.Value.BlockUpVerticalRange.Value.Max);
			return true;
		}

		// Token: 0x06030E8E RID: 200334 RVA: 0x00C20C8C File Offset: 0x00C1EE8C
		private void ClimbingExitPositionFix()
		{
			global::Vector tmpVector = this.TmpVector2;
			FVectorDouble fvectorDouble = this.KuroClimbObject.D_GetSafetyLocation();
			tmpVector.FromUeVector(fvectorDouble);
			this.ActorComp.ActorLocationProxy.Subtraction(this.TmpVector2, this.TmpVector);
			float num = this.ActorComp.DefaultHalfHeight - this.ActorComp.DefaultRadius;
			float num2 = 60f - num;
			double num3 = Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector);
			double num4 = this.TmpVector.SizeSquared();
			float num5 = 25f - this.ActorComp.DefaultRadius;
			if (num5 <= 0f)
			{
				this.TmpVector.Reset();
			}
			else if (num4 > (double)(num5 * num5))
			{
				float num6 = num5 / (float)Math.Sqrt(num4);
				this.TmpVector.MultiplyEqual((double)num6);
			}
			if (num2 <= 0f)
			{
				num3 = 0.0;
			}
			else if (num3 > (double)num2)
			{
				num3 = (double)num2;
			}
			else if (num3 < (double)(-(double)num2))
			{
				num3 = (double)(-(double)num2);
			}
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, num3);
			this.TmpVector.AdditionEqual(this.TmpVector2);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(this.ActorComp.ActorForwardProxy, this.MoveComp.GravityUp, this.TmpQuat);
			this.TmpTransform.Set(this.TmpVector, this.TmpQuat, this.ActorComp.ActorScaleProxy);
			this.SetCharacterTransformAndBuffer(this.TmpTransform.ToUeTransform(), 200f, null, false);
			this.ActorComp.ResetCapsuleRadiusAndHeight(false);
		}

		// Token: 0x06030E8F RID: 200335 RVA: 0x00C20E20 File Offset: 0x00C1F020
		private bool IsSprintClimb()
		{
			return (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]) && !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.快速攀爬禁止"])) || this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.强制快速攀爬"]);
		}

		// Token: 0x06030E90 RID: 200336 RVA: 0x00C20E81 File Offset: 0x00C1F081
		public void SetLastSafeLocation(global::Vector location)
		{
			this.LastSafeLocation.DeepCopy(location);
		}

		// Token: 0x06030E91 RID: 200337 RVA: 0x00C20E8F File Offset: 0x00C1F08F
		private void OnTeleportStart(bool loading)
		{
			CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Climb)
			{
				this.OnExitClimb();
			}
		}

		// Token: 0x06030E92 RID: 200338 RVA: 0x00C20EB0 File Offset: 0x00C1F0B0
		private void PrintClimbDebugLog()
		{
			UAnimInstance mainAnimInstance = base.Entity.GetComponent<CharacterAnimationComponent>().MainAnimInstance;
			if (UKuroStaticLibrary.IsObjectClassByName(mainAnimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE))
			{
				ABP_BaseRole_C abp_BaseRole_C = mainAnimInstance as ABP_BaseRole_C;
				FVector2D climbInput = abp_BaseRole_C.LogicParams.ClimbInfoRef.ClimbInput;
				float num = (float)(57.29577951308232 * Math.Atan2((double)climbInput.Y, (double)climbInput.X));
				if (num < 0f)
				{
					num += 360f;
				}
				num += abp_BaseRole_C.LogicParams.ClimbOnWallAngleRef;
				float currentValue;
				if (num < 90f)
				{
					currentValue = num / 90f;
				}
				else if (num < 180f)
				{
					currentValue = 1f;
				}
				else if (num < 270f)
				{
					currentValue = -1f;
				}
				else
				{
					currentValue = (num - 360f) / 90f;
				}
				currentValue = Singleton<MathUtils>.Instance.Clamp(currentValue, -1f, 1f);
			}
		}

		// Token: 0x06030E93 RID: 200339 RVA: 0x00C20F9C File Offset: 0x00C1F19C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterClimbComponent characterClimbComponent = (CharacterClimbComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterClimbComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (characterClimbComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AnimComp"))
			{
				if (characterClimbComponent.AnimComp == null)
				{
					this.AnimComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClimbConfig"))
			{
				this.ClimbConfig = characterClimbComponent.ClimbConfig;
			}
			if (base.CanResetComponentProperty("ClimbVault"))
			{
				this.ClimbVault = characterClimbComponent.ClimbVault;
			}
			if (base.CanResetComponentProperty("ClimbOnTop"))
			{
				this.ClimbOnTop = characterClimbComponent.ClimbOnTop;
			}
			if (base.CanResetComponentProperty("ClimbFromTop"))
			{
				this.ClimbFromTop = characterClimbComponent.ClimbFromTop;
			}
			if (base.CanResetComponentProperty("ClimbInfo"))
			{
				this.ClimbInfo = characterClimbComponent.ClimbInfo;
			}
			if (base.CanResetComponentProperty("ClimbInfoNew"))
			{
				if (characterClimbComponent.ClimbInfoNew == null)
				{
					this.ClimbInfoNew = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FClimbInfoStruct>(this.ClimbInfoNew), "ClimbInfoNew"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TsClimbInfo"))
			{
				if (characterClimbComponent.TsClimbInfo == null)
				{
					this.TsClimbInfo = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SClimbInfo>(this.TsClimbInfo), "TsClimbInfo"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OutputClimbState"))
			{
				this.OutputClimbState = characterClimbComponent.OutputClimbState;
			}
			if (base.CanResetComponentProperty("OutputClimbStateNew"))
			{
				if (characterClimbComponent.OutputClimbStateNew == null)
				{
					this.OutputClimbStateNew = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FClimbStateStruct>(this.OutputClimbStateNew), "OutputClimbStateNew"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TsOutputClimbState"))
			{
				if (characterClimbComponent.TsOutputClimbState == null)
				{
					this.TsOutputClimbState = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SClimbState>(this.TsOutputClimbState), "TsOutputClimbState"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClimbUpNewTransform"))
			{
				this.ClimbUpNewTransform = characterClimbComponent.ClimbUpNewTransform;
			}
			if (base.CanResetComponentProperty("ClimbUpNewLocation"))
			{
				if (characterClimbComponent.ClimbUpNewLocation == null)
				{
					this.ClimbUpNewLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.ClimbUpNewLocation), "ClimbUpNewLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClimbSprintVault"))
			{
				this.ClimbSprintVault = characterClimbComponent.ClimbSprintVault;
			}
			if (base.CanResetComponentProperty("CacheTransformBeforeMove"))
			{
				this.CacheTransformBeforeMove = characterClimbComponent.CacheTransformBeforeMove;
			}
			if (base.CanResetComponentProperty("CacheLastMoveDirect") && characterClimbComponent.CacheLastMoveDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheLastMoveDirect), "CacheLastMoveDirect"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ClimbInputDirect") && characterClimbComponent.ClimbInputDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector2D>(this.ClimbInputDirect), "ClimbInputDirect"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("PrevClimbInputDirect") && characterClimbComponent.PrevClimbInputDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector2D>(this.PrevClimbInputDirect), "PrevClimbInputDirect"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CapsuleHalfHeight"))
			{
				this.CapsuleHalfHeight = characterClimbComponent.CapsuleHalfHeight;
			}
			if (base.CanResetComponentProperty("AwakeInput"))
			{
				this.AwakeInput = characterClimbComponent.AwakeInput;
			}
			if (base.CanResetComponentProperty("ClimbDownCompleted"))
			{
				this.ClimbDownCompleted = characterClimbComponent.ClimbDownCompleted;
			}
			if (base.CanResetComponentProperty("PreCharacterStateInClimb"))
			{
				this.PreCharacterStateInClimb = characterClimbComponent.PreCharacterStateInClimb;
			}
			if (base.CanResetComponentProperty("ClimbState"))
			{
				this.ClimbState = characterClimbComponent.ClimbState;
			}
			if (base.CanResetComponentProperty("ExitClimbType"))
			{
				this.ExitClimbType = characterClimbComponent.ExitClimbType;
			}
			if (base.CanResetComponentProperty("EnterClimbType"))
			{
				this.EnterClimbType = characterClimbComponent.EnterClimbType;
			}
			if (base.CanResetComponentProperty("ExitClimbCountDown"))
			{
				this.ExitClimbCountDown = characterClimbComponent.ExitClimbCountDown;
			}
			if (base.CanResetComponentProperty("LastExitClimbTime"))
			{
				this.LastExitClimbTime = characterClimbComponent.LastExitClimbTime;
			}
			if (base.CanResetComponentProperty("LastExitClimbType"))
			{
				this.LastExitClimbType = characterClimbComponent.LastExitClimbType;
			}
			if (base.CanResetComponentProperty("ClimbBlockingInternal"))
			{
				this.ClimbBlockingInternal = characterClimbComponent.ClimbBlockingInternal;
			}
			if (base.CanResetComponentProperty("OnWallAngle"))
			{
				this.OnWallAngle = characterClimbComponent.OnWallAngle;
			}
			if (base.CanResetComponentProperty("IsAllowEarlyExitClimb"))
			{
				this.IsAllowEarlyExitClimb = characterClimbComponent.IsAllowEarlyExitClimb;
			}
			if (base.CanResetComponentProperty("RefTransform"))
			{
				this.RefTransform = characterClimbComponent.RefTransform;
			}
			if (base.CanResetComponentProperty("RefFloat"))
			{
				this.RefFloat = characterClimbComponent.RefFloat;
			}
			if (base.CanResetComponentProperty("LastSafeLocation") && characterClimbComponent.LastSafeLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastSafeLocation), "LastSafeLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TagComponent"))
			{
				if (characterClimbComponent.TagComponent == null)
				{
					this.TagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UnifiedStateComponent"))
			{
				if (characterClimbComponent.UnifiedStateComponent == null)
				{
					this.UnifiedStateComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BufferOffsetSpeed") && characterClimbComponent.BufferOffsetSpeed != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.BufferOffsetSpeed), "BufferOffsetSpeed"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("BufferTimeLength"))
			{
				this.BufferTimeLength = characterClimbComponent.BufferTimeLength;
			}
			if (base.CanResetComponentProperty("BufferNowTime"))
			{
				this.BufferNowTime = characterClimbComponent.BufferNowTime;
			}
			if (base.CanResetComponentProperty("SpeedDirect") && characterClimbComponent.SpeedDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SpeedDirect), "SpeedDirect"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpVector") && characterClimbComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector), "TmpVector"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpVector2") && characterClimbComponent.TmpVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector2), "TmpVector2"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpVector3") && characterClimbComponent.TmpVector3 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector3), "TmpVector3"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpQuat") && characterClimbComponent.TmpQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat), "TmpQuat"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpRotator") && characterClimbComponent.TmpRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.TmpRotator), "TmpRotator"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpTransform") && characterClimbComponent.TmpTransform != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Transform>(this.TmpTransform), "TmpTransform"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("KuroClimbObject"))
			{
				if (characterClimbComponent.KuroClimbObject == null)
				{
					this.KuroClimbObject = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroClimbObject>(this.KuroClimbObject), "KuroClimbObject"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DebugNoTop"))
			{
				this.DebugNoTop = characterClimbComponent.DebugNoTop;
			}
			if (base.CanResetComponentProperty("DebugEnterClimbTrace"))
			{
				this.DebugEnterClimbTrace = characterClimbComponent.DebugEnterClimbTrace;
			}
			if (base.CanResetComponentProperty("DebugVaultClimbTrace"))
			{
				this.DebugVaultClimbTrace = characterClimbComponent.DebugVaultClimbTrace;
			}
			if (base.CanResetComponentProperty("DebugUpArriveClimbTrace"))
			{
				this.DebugUpArriveClimbTrace = characterClimbComponent.DebugUpArriveClimbTrace;
			}
			if (base.CanResetComponentProperty("DebugClimbingTrace"))
			{
				this.DebugClimbingTrace = characterClimbComponent.DebugClimbingTrace;
			}
			if (base.CanResetComponentProperty("TraceElement"))
			{
				if (characterClimbComponent.TraceElement == null)
				{
					this.TraceElement = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.TraceElement), "TraceElement"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NextCanEnterClimbTime"))
			{
				this.NextCanEnterClimbTime = characterClimbComponent.NextCanEnterClimbTime;
			}
			if (base.CanResetComponentProperty("ForbiddenClimbKey"))
			{
				this.ForbiddenClimbKey = characterClimbComponent.ForbiddenClimbKey;
			}
			if (base.CanResetComponentProperty("ForceFastClimb"))
			{
				this.ForceFastClimb = characterClimbComponent.ForceFastClimb;
			}
			if (base.CanResetComponentProperty("CachedActorLocation") && characterClimbComponent.CachedActorLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CachedActorLocation), "CachedActorLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("OnTickStat1") && characterClimbComponent.OnTickStat1 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.OnTickStat1), "OnTickStat1"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("OnTickStat2") && characterClimbComponent.OnTickStat2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.OnTickStat2), "OnTickStat2"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("OnTickStat3") && characterClimbComponent.OnTickStat3 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.OnTickStat3), "OnTickStat3"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DetectClimbStat1") && characterClimbComponent.DetectClimbStat1 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectClimbStat1), "DetectClimbStat1"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DetectClimbStat2") && characterClimbComponent.DetectClimbStat2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectClimbStat2), "DetectClimbStat2"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DetectClimbStat3") && characterClimbComponent.DetectClimbStat3 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectClimbStat3), "DetectClimbStat3"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DetectUpArriveBothVaultAndOnTopStat1") && characterClimbComponent.DetectUpArriveBothVaultAndOnTopStat1 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectUpArriveBothVaultAndOnTopStat1), "DetectUpArriveBothVaultAndOnTopStat1"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DetectUpArriveBothVaultAndOnTopStat2") && characterClimbComponent.DetectUpArriveBothVaultAndOnTopStat2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectUpArriveBothVaultAndOnTopStat2), "DetectUpArriveBothVaultAndOnTopStat2"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DetectClimbWalkingStat1") && characterClimbComponent.DetectClimbWalkingStat1 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectClimbWalkingStat1), "DetectClimbWalkingStat1"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("Rotator180"))
			{
				if (characterClimbComponent.Rotator180 == null)
				{
					this.Rotator180 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.Rotator180), "Rotator180"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DetectEnterClimbStat1"))
			{
				if (characterClimbComponent.DetectEnterClimbStat1 == null)
				{
					this.DetectEnterClimbStat1 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectEnterClimbStat1), "DetectEnterClimbStat1"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DetectEnterClimbStat2"))
			{
				if (characterClimbComponent.DetectEnterClimbStat2 == null)
				{
					this.DetectEnterClimbStat2 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.DetectEnterClimbStat2), "DetectEnterClimbStat2"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClimbTrans"))
			{
				if (characterClimbComponent.ClimbTrans == null)
				{
					this.ClimbTrans = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Transform>(this.ClimbTrans), "ClimbTrans"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NotConsumeStrengthExitClimbTypes") && characterClimbComponent.NotConsumeStrengthExitClimbTypes != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<EExitClimb>(this.NotConsumeStrengthExitClimbTypes), "NotConsumeStrengthExitClimbTypes"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ClimbingExitPositionFixStat1"))
			{
				if (characterClimbComponent.ClimbingExitPositionFixStat1 == null)
				{
					this.ClimbingExitPositionFixStat1 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.ClimbingExitPositionFixStat1), "ClimbingExitPositionFixStat1"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClimbingExitPositionFixStat2"))
			{
				if (characterClimbComponent.ClimbingExitPositionFixStat2 == null)
				{
					this.ClimbingExitPositionFixStat2 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.ClimbingExitPositionFixStat2), "ClimbingExitPositionFixStat2"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClimbingExitPositionFixStat3"))
			{
				if (characterClimbComponent.ClimbingExitPositionFixStat3 == null)
				{
					this.ClimbingExitPositionFixStat3 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.ClimbingExitPositionFixStat3), "ClimbingExitPositionFixStat3"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C1AE RID: 115118
		private const string PROFILE_KEY = "CharacterClimbComponent_DetectClimbFromTop";

		// Token: 0x0401C1AF RID: 115119
		private const float THREAHOLD_JUMP_LEAVE = -0.707f;

		// Token: 0x0401C1B0 RID: 115120
		private const float THREADHOLD_ENTER_CLIMB_FORWARD_NEED = 0.707f;

		// Token: 0x0401C1B1 RID: 115121
		private const float THREAHOLD_ENTER_CLIMB_MIN_Z_SPEED = -500f;

		// Token: 0x0401C1B2 RID: 115122
		private const float FIVE_SECONDS = 5f;

		// Token: 0x0401C1B3 RID: 115123
		private const float NORMAL_CACHE_TIME = 200f;

		// Token: 0x0401C1B4 RID: 115124
		private const float FAST_CACHE_TIME = 100f;

		// Token: 0x0401C1B5 RID: 115125
		private const float CACHE_TIME_FROM_TOP = 400f;

		// Token: 0x0401C1B6 RID: 115126
		private const float CACHE_TIME_UP_ARRIVE = 300f;

		// Token: 0x0401C1B7 RID: 115127
		private const float EXIT_CLIMB_CACHE_TIME = 300f;

		// Token: 0x0401C1B8 RID: 115128
		private const float INPUT_ADD_LENGTH = 500f;

		// Token: 0x0401C1B9 RID: 115129
		private const float DOUBLE_HALFHEIGHT = 2f;

		// Token: 0x0401C1BA RID: 115130
		private const float ONE_POINT_FIVE_HALFHRIGHT = 1.5f;

		// Token: 0x0401C1BB RID: 115131
		private const float KINDA_LESS_THAN_ONE = 0.85f;

		// Token: 0x0401C1BC RID: 115132
		private const float STRENGTH_THREADHOLD = 10f;

		// Token: 0x0401C1BD RID: 115133
		private const float THREADHOLD_FORWARD_BLOCK = -0.707f;

		// Token: 0x0401C1BE RID: 115134
		private const float THREADHOLD_MODEL_BUFFER = 0.9f;

		// Token: 0x0401C1BF RID: 115135
		private const int NORMAL_GROUP_ID = 1;

		// Token: 0x0401C1C0 RID: 115136
		private const float SHORT_DRAW_TIME = 0.1f;

		// Token: 0x0401C1C1 RID: 115137
		private const float LONG_DRAW_TIME = 5f;

		// Token: 0x0401C1C2 RID: 115138
		private const float CAN_ENTER_CLIMB_CD = 500f;

		// Token: 0x0401C1C3 RID: 115139
		private const float CLIMBING_CAPSULE_SIZE = 5f;

		// Token: 0x0401C1C4 RID: 115140
		private const float MAX_ROLE_HALF_HEIGHT = 85f;

		// Token: 0x0401C1C5 RID: 115141
		private const float MAX_ROLE_RADIUS = 25f;

		// Token: 0x0401C1C6 RID: 115142
		private const float MAX_ROLE_CYLINDER_HALF_HEIGHT = 60f;

		// Token: 0x0401C1C7 RID: 115143
		private const float MAX_SAFETY_DIST = 100f;

		// Token: 0x0401C1C8 RID: 115144
		private const float ENTER_CLIMB_ANGLE = 35f;

		// Token: 0x0401C1C9 RID: 115145
		private const float ENTER_SPINT_VAULT_ANGLE = 45f;

		// Token: 0x0401C1CA RID: 115146
		private const float DEFAULT_DETECT_LENGTH = 150f;

		// Token: 0x0401C1CB RID: 115147
		private const float EXIT_CLIMB_TIME = 800f;

		// Token: 0x0401C1CC RID: 115148
		[StaticVariableRuleIgnore]
		private static readonly FLinearColor TraceColor = new FLinearColor(1f, 0f, 0f, 1f);

		// Token: 0x0401C1CD RID: 115149
		[StaticVariableRuleIgnore]
		private static readonly FLinearColor TraceSuccessColor = new FLinearColor(0f, 1f, 0f, 1f);

		// Token: 0x0401C1CE RID: 115150
		[StaticVariableRuleIgnore]
		private static readonly HashSet<global::ECharMoveState> CanEnterClimbAirStates = new HashSet<global::ECharMoveState>
		{
			global::ECharMoveState.Other,
			global::ECharMoveState.Flying,
			global::ECharMoveState.Glide,
			global::ECharMoveState.Slide
		};

		// Token: 0x0401C1CF RID: 115151
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C1D0 RID: 115152
		[Nullable(2)]
		private CharacterMoveComponent MoveComp;

		// Token: 0x0401C1D1 RID: 115153
		[Nullable(2)]
		private CharacterAnimationComponent AnimComp;

		// Token: 0x0401C1D2 RID: 115154
		private Climb? ClimbConfig;

		// Token: 0x0401C1D3 RID: 115155
		private FVector? ClimbVault;

		// Token: 0x0401C1D4 RID: 115156
		private FVector? ClimbOnTop;

		// Token: 0x0401C1D5 RID: 115157
		private FVector? ClimbFromTop;

		// Token: 0x0401C1D6 RID: 115158
		private SClimbInfo ClimbInfo;

		// Token: 0x0401C1D7 RID: 115159
		[Nullable(2)]
		private FClimbInfoStruct ClimbInfoNew;

		// Token: 0x0401C1D8 RID: 115160
		[Nullable(2)]
		private SClimbInfo TsClimbInfo;

		// Token: 0x0401C1D9 RID: 115161
		private SClimbState OutputClimbState;

		// Token: 0x0401C1DA RID: 115162
		[Nullable(2)]
		private FClimbStateStruct OutputClimbStateNew;

		// Token: 0x0401C1DB RID: 115163
		[Nullable(2)]
		private SClimbState TsOutputClimbState;

		// Token: 0x0401C1DC RID: 115164
		private FTransform? ClimbUpNewTransform;

		// Token: 0x0401C1DD RID: 115165
		private global::Vector ClimbUpNewLocation = global::Vector.Create();

		// Token: 0x0401C1DE RID: 115166
		private FVector? ClimbSprintVault;

		// Token: 0x0401C1DF RID: 115167
		private FTransform? CacheTransformBeforeMove;

		// Token: 0x0401C1E0 RID: 115168
		private readonly global::Vector CacheLastMoveDirect = global::Vector.Create();

		// Token: 0x0401C1E1 RID: 115169
		private readonly Vector2D ClimbInputDirect = Vector2D.Create();

		// Token: 0x0401C1E2 RID: 115170
		private readonly Vector2D PrevClimbInputDirect = Vector2D.Create();

		// Token: 0x0401C1E3 RID: 115171
		private float CapsuleHalfHeight;

		// Token: 0x0401C1E4 RID: 115172
		private bool AwakeInput;

		// Token: 0x0401C1E5 RID: 115173
		private bool ClimbDownCompleted;

		// Token: 0x0401C1E6 RID: 115174
		private bool PreCharacterStateInClimb;

		// Token: 0x0401C1E7 RID: 115175
		private EClimbState ClimbState;

		// Token: 0x0401C1E8 RID: 115176
		private EExitClimb ExitClimbType = EExitClimb.未知方式;

		// Token: 0x0401C1E9 RID: 115177
		private EEnterClimb EnterClimbType;

		// Token: 0x0401C1EA RID: 115178
		private float ExitClimbCountDown;

		// Token: 0x0401C1EB RID: 115179
		public float LastExitClimbTime;

		// Token: 0x0401C1EC RID: 115180
		public EExitClimb LastExitClimbType = EExitClimb.未知方式;

		// Token: 0x0401C1ED RID: 115181
		private bool ClimbBlockingInternal;

		// Token: 0x0401C1EE RID: 115182
		private float OnWallAngle;

		// Token: 0x0401C1EF RID: 115183
		private bool IsAllowEarlyExitClimb;

		// Token: 0x0401C1F0 RID: 115184
		private FTransformDouble RefTransform;

		// Token: 0x0401C1F1 RID: 115185
		private float RefFloat;

		// Token: 0x0401C1F2 RID: 115186
		private readonly global::Vector LastSafeLocation = global::Vector.Create();

		// Token: 0x0401C1F3 RID: 115187
		[Nullable(2)]
		private BaseTagComponent TagComponent;

		// Token: 0x0401C1F4 RID: 115188
		[Nullable(2)]
		private CharacterUnifiedStateComponent UnifiedStateComponent;

		// Token: 0x0401C1F5 RID: 115189
		private readonly global::Vector BufferOffsetSpeed = global::Vector.Create();

		// Token: 0x0401C1F6 RID: 115190
		private float? BufferTimeLength;

		// Token: 0x0401C1F7 RID: 115191
		private float BufferNowTime;

		// Token: 0x0401C1F8 RID: 115192
		private readonly global::Vector SpeedDirect = global::Vector.Create();

		// Token: 0x0401C1F9 RID: 115193
		private readonly global::Vector TmpVector = global::Vector.Create();

		// Token: 0x0401C1FA RID: 115194
		private readonly global::Vector TmpVector2 = global::Vector.Create();

		// Token: 0x0401C1FB RID: 115195
		private readonly global::Vector TmpVector3 = global::Vector.Create();

		// Token: 0x0401C1FC RID: 115196
		private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401C1FD RID: 115197
		private readonly global::Rotator TmpRotator = global::Rotator.Create();

		// Token: 0x0401C1FE RID: 115198
		private readonly global::Transform TmpTransform = global::Transform.Create();

		// Token: 0x0401C1FF RID: 115199
		[Nullable(2)]
		private UKuroClimbObject KuroClimbObject;

		// Token: 0x0401C200 RID: 115200
		protected bool DebugNoTop;

		// Token: 0x0401C201 RID: 115201
		private EDrawDebugTrace DebugEnterClimbTrace;

		// Token: 0x0401C202 RID: 115202
		private EDrawDebugTrace DebugVaultClimbTrace;

		// Token: 0x0401C203 RID: 115203
		private EDrawDebugTrace DebugUpArriveClimbTrace;

		// Token: 0x0401C204 RID: 115204
		private EDrawDebugTrace DebugClimbingTrace;

		// Token: 0x0401C205 RID: 115205
		[Nullable(2)]
		private UTraceSphereElement TraceElement;

		// Token: 0x0401C206 RID: 115206
		private float NextCanEnterClimbTime;

		// Token: 0x0401C207 RID: 115207
		private int? ForbiddenClimbKey;

		// Token: 0x0401C208 RID: 115208
		private bool ForceFastClimb;

		// Token: 0x0401C209 RID: 115209
		private readonly global::Vector CachedActorLocation = global::Vector.Create();

		// Token: 0x0401C20A RID: 115210
		private readonly Stat OnTickStat1 = Stat.Create("OnTick1", "", "");

		// Token: 0x0401C20B RID: 115211
		private readonly Stat OnTickStat2 = Stat.Create("OnTick2", "", "");

		// Token: 0x0401C20C RID: 115212
		private readonly Stat OnTickStat3 = Stat.Create("OnTick3", "", "");

		// Token: 0x0401C20D RID: 115213
		private readonly Stat DetectClimbStat1 = Stat.Create("DetectClimb1", "", "");

		// Token: 0x0401C20E RID: 115214
		private readonly Stat DetectClimbStat2 = Stat.Create("DetectClimb2", "", "");

		// Token: 0x0401C20F RID: 115215
		private readonly Stat DetectClimbStat3 = Stat.Create("DetectClimb3", "", "");

		// Token: 0x0401C210 RID: 115216
		private readonly Stat DetectUpArriveBothVaultAndOnTopStat1 = Stat.Create("DetectUpArriveBothVaultAndOnTop1", "", "");

		// Token: 0x0401C211 RID: 115217
		private readonly Stat DetectUpArriveBothVaultAndOnTopStat2 = Stat.Create("DetectUpArriveBothVaultAndOnTop2", "", "");

		// Token: 0x0401C212 RID: 115218
		private readonly Stat DetectClimbWalkingStat1 = Stat.Create("DetectClimbWalking1", "", "");

		// Token: 0x0401C213 RID: 115219
		private global::Rotator Rotator180 = global::Rotator.Create(0f, 180f, 0f);

		// Token: 0x0401C214 RID: 115220
		private Stat DetectEnterClimbStat1 = Stat.Create("DetectEnterClimb1", "", "");

		// Token: 0x0401C215 RID: 115221
		private Stat DetectEnterClimbStat2 = Stat.Create("DetectEnterClimb2", "", "");

		// Token: 0x0401C216 RID: 115222
		[Nullable(2)]
		private global::Transform ClimbTrans;

		// Token: 0x0401C217 RID: 115223
		[StaticVariableRuleIgnore]
		private static Stat Stat1 = Stat.Create("ClimbStat1", "", "");

		// Token: 0x0401C218 RID: 115224
		[StaticVariableRuleIgnore]
		private static Stat Stat2 = Stat.Create("ClimbStat2", "", "");

		// Token: 0x0401C219 RID: 115225
		[StaticVariableRuleIgnore]
		private static Stat Stat3 = Stat.Create("ClimbStat3", "", "");

		// Token: 0x0401C21A RID: 115226
		private readonly HashSet<EExitClimb> NotConsumeStrengthExitClimbTypes = new HashSet<EExitClimb>
		{
			EExitClimb.到顶退出,
			EExitClimb.地面登上,
			EExitClimb.冲刺跨越近,
			EExitClimb.冲刺跨越远
		};

		// Token: 0x0401C21B RID: 115227
		private Stat ClimbingExitPositionFixStat1 = Stat.Create("ClimbingExitPositionFix1", "", "");

		// Token: 0x0401C21C RID: 115228
		private Stat ClimbingExitPositionFixStat2 = Stat.Create("ClimbingExitPositionFix2", "", "");

		// Token: 0x0401C21D RID: 115229
		private Stat ClimbingExitPositionFixStat3 = Stat.Create("ClimbingExitPositionFix3", "", "");

		// Token: 0x0401C21E RID: 115230
		[StaticVariableRuleIgnore]
		public static bool DebugLogController = false;
	}
}
