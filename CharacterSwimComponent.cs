using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.TickScore;
using UnrealEngine;

// Token: 0x02003072 RID: 12402
[NullableContext(2)]
[Nullable(0)]
public class CharacterSwimComponent : EntityComponent, IScoreUpdateObject, IComponentDependency, IStaticVariableResetter
{
	// Token: 0x060197C2 RID: 104386 RVA: 0x0075FCBC File Offset: 0x0075DEBC
	static CharacterSwimComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterSwimComponent.CreateStaticDefaultValue), new Action(CharacterSwimComponent.ResetStaticDefaultValue));
	}

	// Token: 0x1700225A RID: 8794
	// (get) Token: 0x060197C3 RID: 104387 RVA: 0x0075FD20 File Offset: 0x0075DF20
	[Nullable(1)]
	public static Type[] Dependencies
	{
		[NullableContext(1)]
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterMoveComponent),
				typeof(BaseTagComponent)
			};
		}
	}

	// Token: 0x060197C4 RID: 104388 RVA: 0x0075FD4F File Offset: 0x0075DF4F
	private void TeleportComplete(TeleportContext teleportContext)
	{
		this.SetForceCheck();
	}

	// Token: 0x060197C5 RID: 104389 RVA: 0x0075FD57 File Offset: 0x0075DF57
	private void SetForceCheck()
	{
		this.ForceCheck = true;
	}

	// Token: 0x060197C6 RID: 104390 RVA: 0x0075FD60 File Offset: 0x0075DF60
	private void ReceiveMoveStateChange(global::ECharMoveState oldMoveState, global::ECharMoveState newMoveState)
	{
		this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.空中入水"]));
		if (this.EnterSwimFromAirBuffIndex != 0)
		{
			CharacterBuffComponent component = base.Entity.GetComponent<CharacterBuffComponent>();
			if (component != null)
			{
				component.RemoveBuffByHandle(this.EnterSwimFromAirBuffIndex, -1, "空中入水结束", null, null, null);
			}
			this.EnterSwimFromAirBuffIndex = 0;
		}
		if (newMoveState == global::ECharMoveState.FastSwim)
		{
			this.MaxSpeed = this.MoveComp.MovementData.FaceDirection.Standing.FastSwimSpeed;
			this.IsFastSwim = true;
			this.RefreshSwimBuff();
			return;
		}
		if (newMoveState == global::ECharMoveState.NormalSwim)
		{
			this.MaxSpeed = this.MoveComp.MovementData.FaceDirection.Standing.NormalSwimSpeed;
			this.IsFastSwim = false;
			this.RefreshSwimBuff();
			return;
		}
		this.LeaveSwim();
	}

	// Token: 0x060197C7 RID: 104391 RVA: 0x0075FE46 File Offset: 0x0075E046
	private void ReceivePositionStateChanged(global::ECharPositionState oldPositionState, global::ECharPositionState newPositionState)
	{
		if (oldPositionState == global::ECharPositionState.Water)
		{
			this.LeaveSwim();
			return;
		}
		if (newPositionState == global::ECharPositionState.Water)
		{
			this.RefreshSwimBuff();
		}
	}

	// Token: 0x060197C8 RID: 104392 RVA: 0x0075FE5D File Offset: 0x0075E05D
	private void SwimStrengthTagChanged(int count, int tagId, int exactTagId, int oldCount)
	{
		this.RefreshSwimBuff();
	}

	// Token: 0x060197C9 RID: 104393 RVA: 0x0075FE68 File Offset: 0x0075E068
	private void ReceiveSwimEvent(float deltaTime)
	{
		double num = (double)((-(double)Singleton<MathUtils>.Instance.Clamp(this.MoveComp.Speed / 75f, 0f, 1f) + 1f) * 10000f + 1f) * 0.01;
		float angleOffsetFromCurrentToInputAbs = Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.ActorComp);
		float accelerator = this.SwimAcceleratorCurve.GetFloatValue(angleOffsetFromCurrentToInputAbs) * 200f;
		this.RotateSpeed = this.SwimRotationCurve.GetFloatValue(angleOffsetFromCurrentToInputAbs);
		double num2 = (this.SwimState == ESwimState.Other) ? 0.0 : 1.4;
		this.MoveComp.CharacterMovement.KuroSwimming(deltaTime, true, this.Depth, (float)num2, (float)num, this.MaxSpeed, this.WaterSlope, accelerator, 0.06f);
	}

	// Token: 0x1700225B RID: 8795
	// (get) Token: 0x060197CA RID: 104394 RVA: 0x0075FF3B File Offset: 0x0075E13B
	// (set) Token: 0x060197CB RID: 104395 RVA: 0x0075FF43 File Offset: 0x0075E143
	protected long BuffIndex
	{
		get
		{
			return this.BuffIndexInternal;
		}
		set
		{
			if (this.BuffIndexInternal == value)
			{
				return;
			}
			this.BuffIndexInternal = value;
			Singleton<EventSystem>.Instance.EmitWithTarget<long>(base.Entity, EEventName.CharSwimStrengthChanged, this.BuffIndexInternal);
		}
	}

	// Token: 0x1700225C RID: 8796
	// (get) Token: 0x060197CC RID: 104396 RVA: 0x0075FF72 File Offset: 0x0075E172
	// (set) Token: 0x060197CD RID: 104397 RVA: 0x0075FF7C File Offset: 0x0075E17C
	protected int WaterType
	{
		get
		{
			return (int)this.WaterTypeInternal;
		}
		set
		{
			if (this.WaterTypeInternal == (EInteractionWaterType)value)
			{
				return;
			}
			this.WaterTypeInternal = (EInteractionWaterType)value;
			Singleton<EventSystem>.Instance.EmitWithTarget<EInteractionWaterType>(base.Entity, EEventName.OnInteractionWaterTypeChange, (EInteractionWaterType)value);
		}
	}

	// Token: 0x060197CE RID: 104398 RVA: 0x0075FFB3 File Offset: 0x0075E1B3
	[NullableContext(1)]
	private void StateInheritHandle(Entity oldEntity, bool notInheritMoveAndAnim)
	{
		this.LastTickLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
	}

	// Token: 0x060197CF RID: 104399 RVA: 0x0075FFCC File Offset: 0x0075E1CC
	private void EnterSwimmingState()
	{
		if (!this.ActorComp.IsBoss)
		{
			this.SkillComp.StopAllSkills("CharacterSwimComponent.EnterSwimmingState");
			if (this.IsDebug)
			{
				Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.LJM, "[游泳组件]触发入水,打断0组技能", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
		if (!this.MoveComp.FallingIntoWater)
		{
			global::Vector tempVector = this.TempVector;
			FVector lastUpdateVelocity = this.MoveComp.CharacterMovement.LastUpdateVelocity;
			FVectorDouble fvectorDouble = lastUpdateVelocity;
			tempVector.DeepCopy(fvectorDouble);
			double num = Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TempVector);
			num = Singleton<MathUtils>.Instance.Clamp(num, -50.0, 50.0);
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, this.TempVector, num);
			this.MoveComp.CharacterMovement.LastUpdateVelocity = this.TempVector.ToUeVectorOld();
			this.MoveComp.SetForceSpeed(this.TempVector);
			if (this.IsDebug)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[游泳组件]触发入水,入水速度过大，限制到";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("入水速度", this.TempVector);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null)
		{
			return;
		}
		actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Custom,
			CustomMode = 1,
			Context = "[CharacterSwimComponent.EnterSwimmingState]"
		});
	}

	// Token: 0x060197D0 RID: 104400 RVA: 0x00760130 File Offset: 0x0075E330
	protected override bool OnStart()
	{
		this.Depth = 0f;
		this.MaxSpeed = 0f;
		this.WaterSlope = 0f;
		this.RotateSpeed = 0f;
		this.IsFastSwim = false;
		this.InSwimTriggerCount = 0;
		this.ForceCheck = false;
		this.CreateTempVector();
		this.LastEnterWaterTime = 0f;
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		this.IsRole = (component.GetEntityType() == EEntityType.Player);
		this.SwimState = ESwimState.Swim;
		if (!this.LoadActorInfo())
		{
			return false;
		}
		if (!this.LoadConfig())
		{
			return false;
		}
		if (!this.LoadCurve())
		{
			return false;
		}
		this.InitTraceElements();
		if (this.IsRole)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<global::ECharMoveState, global::ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.ReceiveMoveStateChange));
			Singleton<EventSystem>.Instance.AddWithTarget<global::ECharPositionState, global::ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.ReceivePositionStateChanged));
			Singleton<EventSystem>.Instance.AddWithTarget<float>(base.Entity, EEventName.CustomMoveSwim, new Action<float>(this.ReceiveSwimEvent));
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.StateInheritHandle));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.SetForceCheck));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.TeleportComplete));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.SetForceCheck));
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.AddTagChangedListener(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.游泳.游泳体力消耗"], new BaseTagComponent.TTagChangedCallback(this.SwimStrengthTagChanged), null);
			}
		}
		this.ActorComp.Actor.Tags.Add(Singleton<CharacterNameDefines>.Instance.ENABLE_MOVE_TRIGGER_TAG);
		return true;
	}

	// Token: 0x060197D1 RID: 104401 RVA: 0x00760308 File Offset: 0x0075E508
	private void InitTraceElements()
	{
		this.WaterTrace = new UTraceSphereElement();
		this.WaterTrace.WorldContextObject = this.ActorComp.Actor;
		this.WaterTrace.Radius = 1f;
		this.WaterTrace.bIgnoreSelf = true;
		this.WaterTrace.bIsSingle = false;
		this.WaterTrace.SetDrawDebugTrace(this.IsDebug ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
		this.WaterTrace.DrawTime = 0.1f;
		this.WaterTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.WaterTrace, CharacterSwimUtils.DebugColor3);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.WaterTrace, CharacterSwimUtils.DebugColor4);
	}

	// Token: 0x060197D2 RID: 104402 RVA: 0x007603C0 File Offset: 0x0075E5C0
	private void RefreshSwimAreaHeight()
	{
		if (this.MoveComp != null && !this.MoveComp.IsStandardGravity)
		{
			this.InSwimAreaInternal = true;
			this.SwimAreaHeightAboveActor = 500f;
			this.WaterHeightAboveMe = 0f;
			return;
		}
		if (CharacterSwimComponent.UseSwimTrigger)
		{
			this.InSwimAreaInternal = (this.InSwimTriggerCount > 0);
			this.SwimAreaHeightAboveActor = 500f;
			this.WaterHeightAboveMe = 0f;
			return;
		}
		float num = 0f;
		FVectorDouble actorLocation;
		bool flag;
		if (this.ActorComp.IsRoleAndCtrlByMe)
		{
			CharacterUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
			if (unifiedStateComp != null && unifiedStateComp.PositionState == global::ECharPositionState.Air)
			{
				this.ActorComp.ActorVelocityProxy.Multiply((double)this.DeltaTime, this.TempVector);
				double addZ = Math.Min(0.0, Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector));
				this.TempVector.Set(500.0, 500.0, 5000.0);
				Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempVector, addZ);
				UObject actor = this.ActorComp.Actor;
				actorLocation = this.ActorComp.ActorLocation;
				FVectorDouble fvectorDouble = this.TempVector.ToUeVector(false);
				flag = UNavigationSystemV1.D_NavigationGetWaterSurface(actor, actorLocation, fvectorDouble, ref num, this.ActorComp.Actor, null, this.ActorComp.Actor.CapsuleComponent.CapsuleHalfHeight + 50f);
				goto IL_1C1;
			}
		}
		UObject actor2 = this.ActorComp.Actor;
		actorLocation = this.ActorComp.ActorLocation;
		flag = UNavigationSystemV1.D_NavigationGetWaterSurface(actor2, actorLocation, CharacterSwimComponent.waterAreaDetectExtent, ref num, this.ActorComp.Actor, null, this.ActorComp.Actor.CapsuleComponent.CapsuleHalfHeight + 50f);
		IL_1C1:
		this.InSwimAreaInternal = flag;
		if (flag)
		{
			this.WaterHeightAboveMe = (float)((double)num - this.ActorComp.FloorLocation.Z);
			this.SwimAreaHeightAboveActor = (float)((double)num - this.ActorComp.ActorLocationProxy.Z + 100.0);
			return;
		}
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.强制游泳检测"]))
		{
			this.SwimAreaHeightAboveActor = 500f;
			this.InSwimAreaInternal = true;
			return;
		}
		this.SwimAreaHeightAboveActor = 0f;
	}

	// Token: 0x060197D3 RID: 104403 RVA: 0x00760618 File Offset: 0x0075E818
	private bool InSwimArea()
	{
		return this.InSwimAreaInternal;
	}

	// Token: 0x060197D4 RID: 104404 RVA: 0x00760620 File Offset: 0x0075E820
	private void RemoveTraceElements()
	{
		if (this.WaterTrace != null)
		{
			this.WaterTrace.Dispose();
			this.WaterTrace = null;
		}
	}

	// Token: 0x060197D5 RID: 104405 RVA: 0x0076063C File Offset: 0x0075E83C
	protected unsafe override void OnTick(float deltaTime)
	{
		this.ResetWaterLocation();
		if (!this.ActorComp.IsAutonomousProxy)
		{
			return;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.取消游泳检测"]) || this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不会入水"]))
		{
			int id = base.Entity.Id;
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				EntityHandle getCurrentEntity = instance.GetCurrentEntity;
				num = ((getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null);
			}
			int? num2 = num;
			if (id == num2.GetValueOrDefault() & num2 != null)
			{
				this.TempPlayerLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
				if (this.AnimComp != null)
				{
					Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempPlayerLocation, (double)this.AnimComp.IkMeshOffset);
				}
				this.TempPlayerGravityUp.DeepCopy(Singleton<GravityUtils>.Instance.GetGravityUpForActor(this.ActorComp));
				this.CheckTagInWater(true);
				this.LastTickLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			}
			return;
		}
		this.RefreshSwimAreaHeight();
		if (!this.IsRole)
		{
			if (!this.InSwimArea())
			{
				if (this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Custom && this.MoveComp.CharacterMovement.CustomMovementMode == 1)
				{
					CharacterActorComponent actorComp = this.ActorComp;
					if (actorComp != null)
					{
						actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
						{
							Mode = EMovementMode.MOVE_Falling,
							CustomMode = 0,
							Context = "[CharacterSwimComponent.OnTick]"
						});
					}
				}
			}
			else
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 == null || !actorComp2.ActorLocationProxy.Equals(this.ActorComp.LastActorLocation, 9.999999747378752E-05))
				{
					Singleton<TickScoreController>.Instance.SwimTickScore.AddScore(this, 1);
				}
			}
			global::Vector.VectorCopy(this.ActorComp.ActorLocationProxy, this.LastTickLocation);
			return;
		}
		if ((!(this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Custom) || this.MoveComp.CharacterMovement.CustomMovementMode != 1) && !this.InSwimArea() && !this.ForceCheck)
		{
			if (this.MoveComp.FallingIntoWater && Singleton<Time>.Instance.Now > (double)this.LastEnterWaterTime)
			{
				this.MoveComp.FallingIntoWater = false;
				this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.空中入水"]));
				if (this.EnterSwimFromAirBuffIndex != 0)
				{
					CharacterBuffComponent component = base.Entity.GetComponent<CharacterBuffComponent>();
					if (component != null)
					{
						component.RemoveBuffByHandle(this.EnterSwimFromAirBuffIndex, -1, "空中入水结束", null, null, null);
					}
					this.EnterSwimFromAirBuffIndex = 0;
				}
			}
			this.LastTickLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			return;
		}
		this.DeltaTime = deltaTime * 0.001f;
		this.TempPlayerLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		if (this.AnimComp != null)
		{
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempPlayerLocation, (double)this.AnimComp.IkMeshOffset);
		}
		this.TempPlayerGravityUp.DeepCopy(Singleton<GravityUtils>.Instance.GetGravityUpForActor(this.ActorComp));
		if (global::Vector.DistSquared(this.LastTickLocation, this.TempPlayerLocation) > 100000000.0)
		{
			if (this.IsDebug)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[游泳组件]与上一帧位置差巨大,重新设置这一帧位置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LastTickLocation", this.LastTickLocation);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlayerLocation", this.TempPlayerLocation);
				instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			this.LastTickLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		if (this.CheckTagInOtherStateThenEnterWater(this.GetCurrentExpectedEnterState()))
		{
			this.Depth = 1f;
			this.LastTickLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			return;
		}
		this.CheckTagInWater(false);
		this.CheckCustomMovementIsSwim(this.DeltaTime);
		this.HasFloor = this.CheckHasArrivedFloorInSwimming();
		this.CheckSwimState();
		this.LastTickLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.ForceCheck = false;
	}

	// Token: 0x060197D6 RID: 104406 RVA: 0x00760AAF File Offset: 0x0075ECAF
	public void ScoreUpdate()
	{
		if (!base.Active || this.ActorComp == null)
		{
			return;
		}
		global::Vector.VectorCopy(this.ActorComp.ActorLocationProxy, this.TempPlayerLocation);
		this.SimpleCheckInWater();
	}

	// Token: 0x060197D7 RID: 104407 RVA: 0x00760AE0 File Offset: 0x0075ECE0
	protected override bool OnEnd()
	{
		this.ClearTempVector();
		this.RemoveTraceElements();
		if (this.IsRole)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<global::ECharMoveState, global::ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.ReceiveMoveStateChange));
			Singleton<EventSystem>.Instance.RemoveWithTarget<global::ECharPositionState, global::ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.ReceivePositionStateChanged));
			Singleton<EventSystem>.Instance.RemoveWithTarget<float>(base.Entity, EEventName.CustomMoveSwim, new Action<float>(this.ReceiveSwimEvent));
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.StateInheritHandle));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.SetForceCheck));
			Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.TeleportComplete));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.SetForceCheck));
		}
		return true;
	}

	// Token: 0x060197D8 RID: 104408 RVA: 0x00760BE0 File Offset: 0x0075EDE0
	private void CreateTempVector()
	{
		this.TempStartPoint = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempEndPoint = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempVector = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempVector2 = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempVector3 = global::Vector.Create(0.0, 0.0, 0.0);
		this.DetectFallIntoWaterPosition = global::Vector.Create(0.0, 0.0, 0.0);
		this.LastTickLocation = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempPlayerLocation = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempPlayerGravityUp = global::Vector.Create(0.0, 0.0, 1.0);
		this.TempWaterImpactPoint = global::Vector.Create(0.0, 0.0, double.MinValue);
		this.TempSwimImpactPoint = global::Vector.Create(0.0, 0.0, double.MinValue);
		this.TempSwimNormalPoint = global::Vector.Create(0.0, 0.0, 0.0);
	}

	// Token: 0x060197D9 RID: 104409 RVA: 0x00760DB8 File Offset: 0x0075EFB8
	private void ClearTempVector()
	{
		this.TempVector = null;
		this.TempVector2 = null;
		this.TempVector3 = null;
		this.TempStartPoint = null;
		this.TempEndPoint = null;
		this.DetectFallIntoWaterPosition = null;
		this.LastTickLocation = null;
		this.TempPlayerLocation = null;
		this.TempPlayerGravityUp = null;
		this.TempWaterImpactPoint = null;
		this.TempSwimImpactPoint = null;
		this.TempSwimNormalPoint = null;
	}

	// Token: 0x060197DA RID: 104410 RVA: 0x00760E1C File Offset: 0x0075F01C
	private bool LoadActorInfo()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		global::Vector.VectorCopy(this.ActorComp.ActorLocationProxy, this.TempPlayerLocation);
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		this.TagComp = component;
		this.UnifiedStateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.SkillComp = base.Entity.GetComponent<CharacterSkillComponent>();
		this.ClimbComp = base.Entity.GetComponent<CharacterClimbComponent>();
		CharacterMoveComponent component2 = base.Entity.GetComponent<CharacterMoveComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		this.MoveComp = component2;
		this.CharacterHalfHeight = this.ActorComp.HalfHeight;
		global::Vector.VectorCopy(this.ActorComp.ActorLocationProxy, this.LastTickLocation);
		return true;
	}

	// Token: 0x060197DB RID: 104411 RVA: 0x00760F08 File Offset: 0x0075F108
	private bool LoadConfig()
	{
		if (!this.IsRole)
		{
			return true;
		}
		this.SwimConfigInternal = ConfigBase<SwimConfig>.Instance.GetSwimConfigByRoleBodyId(this.ActorComp.CreatureData.GetRoleConfig().Value.RoleBody);
		if (this.SwimConfigInternal != null)
		{
			this.SprintSwimOffset = 0f;
			this.SprintSwimOffsetLerpSpeed = this.SwimConfigInternal.Value.SprintZOffsetSpeed;
			return true;
		}
		return false;
	}

	// Token: 0x060197DC RID: 104412 RVA: 0x00760F84 File Offset: 0x0075F184
	private bool LoadCurve()
	{
		if (!this.IsRole)
		{
			return true;
		}
		this.SwimAcceleratorCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/Role/Common/Data/Curves/CT_SwimAcceleratorStrength.CT_SwimAcceleratorStrength");
		this.SwimRotationCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/Role/Common/Data/Curves/CT_SwimRotateSpeed.CT_SwimRotateSpeed");
		if (this.SwimAcceleratorCurve != null && this.SwimRotationCurve != null)
		{
			return true;
		}
		Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.LJM, "游泳配置曲线加载失败，曲线为/Game/Aki/Character/Role/Common/Data/Curves/CT_SwimAcceleratorStrength.CT_SwimAcceleratorStrength或者/Game/Aki/Character/Role/Common/Data/Curves/CT_SwimRotateSpeed.CT_SwimRotateSpeed", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x060197DD RID: 104413 RVA: 0x00760FF4 File Offset: 0x0075F1F4
	private ECheckFloorResult CheckHasArrivedFloorInSwimming()
	{
		if (!this.MoveComp.HasSwimmingBlock)
		{
			return ECheckFloorResult.None;
		}
		FFindFloorResult ffindFloorResult = new FFindFloorResult();
		this.MoveComp.CharacterMovement.D_K2_FindFloor(this.TempPlayerLocation.ToUeVector(false), ref ffindFloorResult);
		CharacterMoveComponent moveComp = this.MoveComp;
		bool flag;
		if (moveComp == null)
		{
			flag = false;
		}
		else
		{
			UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
			bool? flag2;
			if (characterMovement == null)
			{
				flag2 = null;
			}
			else
			{
				FHitResult hitResult = ffindFloorResult.HitResult;
				flag2 = new bool?(characterMovement.IsWalkable(hitResult));
			}
			bool? flag3 = flag2;
			flag = flag3.GetValueOrDefault();
		}
		if (!flag)
		{
			return ECheckFloorResult.NotFloor;
		}
		return ECheckFloorResult.Floor;
	}

	// Token: 0x060197DE RID: 104414 RVA: 0x00761078 File Offset: 0x0075F278
	private void CheckTagInWater(bool forceCheck = false)
	{
		if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]) && !forceCheck)
		{
			return;
		}
		int num = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.贡多拉.攀瀑"]) ? 600 : 0;
		int num2 = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.贡多拉.攀瀑"]) ? 250 : 0;
		global::Vector tempVector = this.TempVector;
		this.TempPlayerGravityUp.Multiply((double)(this.CharacterHalfHeight * 2f + (float)num), tempVector);
		global::Vector tempStartPoint = this.TempStartPoint;
		this.TempPlayerLocation.Addition(tempVector, tempStartPoint);
		this.TempPlayerGravityUp.Multiply((double)(this.CharacterHalfHeight + (float)num2), tempVector);
		global::Vector tempEndPoint = this.TempEndPoint;
		this.TempPlayerLocation.Subtraction(tempVector, tempEndPoint);
		this.Depth = this.DetectWaterDepth(tempStartPoint, tempEndPoint);
		this.WaterVolume = this.WaterTrace.HitResult.bBlockingHit;
		this.FixNormal(this.TempSwimNormalPoint);
	}

	// Token: 0x060197DF RID: 104415 RVA: 0x00761188 File Offset: 0x0075F388
	[NullableContext(1)]
	private bool UpdateWaterTraceResult(UKuroHitResult hitResult)
	{
		bool flag = false;
		bool flag2 = false;
		this.TempSwimImpactPoint.Reset();
		this.TempSwimNormalPoint.Reset();
		this.TempWaterImpactPoint.Reset();
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempSwimImpactPoint, double.MinValue);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempWaterImpactPoint, double.MinValue);
		double num = double.MinValue;
		double num2 = double.MinValue;
		int hitCount = hitResult.GetHitCount();
		for (int i = 0; i < hitCount; i++)
		{
			TWeakObjectPtr<AActor> weak = hitResult.Actors.Get(i);
			if (weak.IsValid(false, false))
			{
				if (UKuroCollisionLibrary.ActorHasTag(weak, CharacterSwimComponent.TagWaterNoSwim, hitResult.ItemArray.Get(i)))
				{
					flag2 = true;
					Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, this.TempVector);
					double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector);
					if (znInGravityForActor > num2)
					{
						num2 = znInGravityForActor;
						this.TempWaterImpactPoint.DeepCopy(this.TempVector);
					}
				}
				else
				{
					flag = true;
					Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, this.TempVector);
					double znInGravityForActor2 = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector);
					if (znInGravityForActor2 > num)
					{
						num = znInGravityForActor2;
						Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult, i, this.TempSwimNormalPoint);
						this.TempSwimImpactPoint.DeepCopy(this.TempVector);
						this.SwimTime = hitResult.TimeArray.Get(i);
					}
				}
			}
		}
		if (!flag2 && flag)
		{
			this.TempWaterImpactPoint.DeepCopy(this.TempSwimImpactPoint);
		}
		return flag;
	}

	// Token: 0x060197E0 RID: 104416 RVA: 0x0076133C File Offset: 0x0075F53C
	private EEnterWaterState GetCurrentExpectedEnterState()
	{
		if (this.MoveComp.FallingIntoWater)
		{
			return EEnterWaterState.Air;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
		{
			return EEnterWaterState.Air;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]))
		{
			return EEnterWaterState.Climb;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]))
		{
			return EEnterWaterState.Ground;
		}
		return EEnterWaterState.None;
	}

	// Token: 0x060197E1 RID: 104417 RVA: 0x007613B4 File Offset: 0x0075F5B4
	[NullableContext(1)]
	private bool SimpleVisibleTrace(global::Vector start, global::Vector end, float scale = -1f)
	{
		if (scale < 0f)
		{
			scale = this.ActorComp.ScaledRadius;
		}
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Actor;
		actorTrace.Radius = scale;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, end);
		actorTrace.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		return Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "CharacterSwimComponent_CheckHasArrivedFloorInSwimming", "CharacterSwimComponent_CheckHasArrivedFloorInSwimming");
	}

	// Token: 0x060197E2 RID: 104418 RVA: 0x00761494 File Offset: 0x0075F694
	[NullableContext(1)]
	private bool SimpleWaterTrace(global::Vector start, global::Vector end)
	{
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.WaterTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.WaterTrace, end);
		bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.WaterTrace, "CharacterSwimComponent_DetectWaterDepth");
		if (flag)
		{
			flag = this.UpdateWaterTraceResult(this.WaterTrace.HitResult);
		}
		if (this.WaterTrace.HitResult.bBlockingHit)
		{
			this.CheckHitWaterType();
		}
		return flag && this.WaterTrace.HitResult.bBlockingHit;
	}

	// Token: 0x060197E3 RID: 104419 RVA: 0x0076151C File Offset: 0x0075F71C
	private void CheckHitWaterType()
	{
		TArray<TWeakObjectPtr<UPhysicalMaterial>> physMaterials = this.WaterTrace.HitResult.PhysMaterials;
		int hitCount = this.WaterTrace.HitResult.GetHitCount();
		int i = 0;
		while (i < hitCount)
		{
			TWeakObjectPtr<UPrimitiveComponent> weak = this.WaterTrace.HitResult.Components.Get(i);
			UPhysicalMaterial uphysicalMaterial = UKuroCollisionLibrary.GetBodyInstance(this.WaterTrace.HitResult, i).PhysMaterialOverride;
			if (uphysicalMaterial == null)
			{
				uphysicalMaterial = UKuroRenderingRuntimeBPPluginBPLibrary.GetComponentPhysicalMaterial(weak);
			}
			if (uphysicalMaterial != null)
			{
				string name = uphysicalMaterial.GetName();
				if (name == "CloudSeaLand")
				{
					this.WaterType = 1;
					return;
				}
				if (!(name == "GoldWater"))
				{
					this.WaterType = 0;
					return;
				}
				this.WaterType = 2;
				return;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x060197E4 RID: 104420 RVA: 0x007615E4 File Offset: 0x0075F7E4
	private bool SimpleCheckInWater()
	{
		global::Vector tempStartPoint = this.TempStartPoint;
		global::Vector tempEndPoint = this.TempEndPoint;
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]) && this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.不会淹死"]))
		{
			tempStartPoint.DeepCopy(this.TempPlayerLocation);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempStartPoint, 0.25 * (double)this.CharacterHalfHeight * 2.0);
			tempEndPoint.DeepCopy(this.TempPlayerLocation);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempEndPoint, (double)this.SwimAreaHeightAboveActor);
			if (!this.SimpleWaterTrace(tempStartPoint, tempEndPoint))
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						CustomMode = 0,
						Context = "[CharacterSwimComponent.SimpleCheckInWater]"
					});
				}
				this.Depth = 0f;
			}
			else
			{
				this.Depth = 2f;
			}
		}
		else
		{
			tempStartPoint.DeepCopy(this.LastTickLocation);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempStartPoint, (double)(this.CharacterHalfHeight * 2f));
			tempEndPoint.DeepCopy(this.TempPlayerLocation);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempEndPoint, (double)(-(double)this.CharacterHalfHeight));
			this.Depth = this.DetectWaterDepth(tempStartPoint, tempEndPoint);
			if ((double)this.Depth > 0.75)
			{
				this.EnterSwimmingState();
				return true;
			}
		}
		return false;
	}

	// Token: 0x060197E5 RID: 104421 RVA: 0x0076176C File Offset: 0x0075F96C
	[NullableContext(1)]
	private unsafe void SetDetectFallIntoWaterPosition(global::Vector hitLocation, float rootMotionBaseOffset)
	{
		global::Vector tempVector = this.TempVector3;
		tempVector.DeepCopy(hitLocation);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempVector, (double)rootMotionBaseOffset);
		this.DetectFallIntoWaterPosition.DeepCopy(tempVector);
		this.ActorComp.SetActorLocation(this.DetectFallIntoWaterPosition.ToUeVector(false), "游泳.游泳入水播放位置设置", true);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				CustomMode = 0,
				Context = "[CharacterSwimComponent.SetDetectFallIntoWaterPosition]"
			});
		}
		global::Vector tempVector2 = this.TempVector;
		tempVector2.Reset();
		this.MoveComp.SetForceSpeed(tempVector2);
		if (this.IsDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[游泳组件]游泳触发入水机制,游泳入水设置位置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("坐标：", this.DetectFallIntoWaterPosition);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("强制速度：", tempVector2);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor1);
		}
	}

	// Token: 0x060197E6 RID: 104422 RVA: 0x0076187C File Offset: 0x0075FA7C
	public void DetectEnterWaterFromAir()
	{
		if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy) > 0.0 || this.MoveComp.FallingIntoWater)
		{
			return;
		}
		global::Vector tempVector = this.TempVector;
		global::Vector tempVector2 = this.TempVector2;
		tempVector2.DeepCopy(this.ActorComp.ActorVelocityProxy);
		tempVector2.Multiply((double)this.DeltaTime, tempVector2);
		tempVector2.Addition(this.TempPlayerLocation, tempVector);
		if (this.SimpleVisibleTrace(this.TempPlayerLocation, tempVector, -1f))
		{
			return;
		}
		bool flag = this.SimpleWaterTrace(this.TempPlayerLocation, tempVector);
		float characterHalfHeight = this.CharacterHalfHeight;
		if (!flag)
		{
			global::Vector tempVector3 = this.TempVector2;
			tempVector3.DeepCopy(tempVector);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempVector3, (double)(-(double)characterHalfHeight));
			if (this.SimpleVisibleTrace(tempVector, tempVector3, -1f))
			{
				return;
			}
			flag = this.SimpleWaterTrace(tempVector, tempVector3);
		}
		if (!flag)
		{
			return;
		}
		this.FixNormal(this.TempSwimNormalPoint);
		if (!this.IsNormalAccepted(this.TempSwimNormalPoint))
		{
			return;
		}
		global::Vector tempStartPoint = this.TempStartPoint;
		tempStartPoint.DeepCopy(this.TempSwimImpactPoint);
		global::Vector tempEndPoint = this.TempEndPoint;
		tempEndPoint.DeepCopy(tempStartPoint);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempEndPoint, (double)(-(double)this.CharacterHalfHeight) * 0.75 * 2.0);
		if (this.SimpleVisibleTrace(tempStartPoint, tempEndPoint, -1f))
		{
			return;
		}
		this.SkillComp.StopAllSkills("CharacterSwimComponent.DetectEnterWaterFromAir");
		this.SetDetectFallIntoWaterPosition(tempStartPoint, characterHalfHeight);
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.空中入水"]));
		CharacterBuffComponent component = base.Entity.GetComponent<CharacterBuffComponent>();
		if (component != null)
		{
			this.EnterSwimFromAirBuffIndex = component.AddBuffLocal(3098L, new AddBuffParam
			{
				InstigatorId = this.ActorComp.CreatureData.GetCreatureDataId(),
				Duration = new float?((float)1),
				Reason = "空中入水"
			});
		}
		this.MoveComp.FallingIntoWater = true;
		this.LastEnterWaterTime = (float)Singleton<Time>.Instance.Now + 500f;
	}

	// Token: 0x060197E7 RID: 104423 RVA: 0x00761AA0 File Offset: 0x0075FCA0
	[NullableContext(1)]
	private void FixNormal(global::Vector inVector)
	{
		double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, inVector);
		if (znInGravityForActor < 0.0)
		{
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, inVector, -znInGravityForActor * 2.0);
		}
	}

	// Token: 0x060197E8 RID: 104424 RVA: 0x00761AE8 File Offset: 0x0075FCE8
	[NullableContext(1)]
	private bool CheckIntoWater(global::Vector start, global::Vector end, float enterWaterZ)
	{
		start.Subtraction(end, this.TempVector);
		if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector) < 0.0)
		{
			return false;
		}
		if (this.DetectWaterDepth(start, end) == 0f)
		{
			return false;
		}
		if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempSwimImpactPoint) < (double)enterWaterZ)
		{
			return false;
		}
		this.FixNormal(this.TempSwimNormalPoint);
		return this.IsNormalAccepted(this.TempSwimNormalPoint);
	}

	// Token: 0x060197E9 RID: 104425 RVA: 0x00761B6C File Offset: 0x0075FD6C
	private bool CheckTagFromAir()
	{
		if (!this.MoveComp.FallingIntoWater)
		{
			this.DetectEnterWaterFromAir();
		}
		global::Vector tempStartPoint = this.TempStartPoint;
		global::Vector tempEndPoint = this.TempEndPoint;
		tempStartPoint.DeepCopy(this.TempPlayerLocation);
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, tempStartPoint, Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.LastTickLocation) + (double)this.CharacterHalfHeight);
		tempEndPoint.DeepCopy(this.TempPlayerLocation);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempEndPoint, (double)(-(double)this.CharacterHalfHeight));
		if (!this.CheckIntoWater(tempStartPoint, tempEndPoint, (float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempPlayerLocation)))
		{
			return false;
		}
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempEndPoint, (double)(-(double)this.CharacterHalfHeight) * 0.75 * 2.0);
		if (this.SimpleVisibleTrace(tempStartPoint, tempEndPoint, 1f))
		{
			return false;
		}
		this.EnterSwimmingState();
		this.TempPlayerLocation.Subtraction(this.TempSwimImpactPoint, this.TempVector);
		if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector) < (double)(-(double)this.CharacterHalfHeight))
		{
			this.ActorComp.SetActorLocation(this.TempSwimImpactPoint.ToUeVector(false), "游泳.入水位置修正", true);
		}
		if (this.IsDebug)
		{
			Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.LJM, "[游泳组件]触发空中入水", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor2);
		}
		return true;
	}

	// Token: 0x060197EA RID: 104426 RVA: 0x00761CEC File Offset: 0x0075FEEC
	private bool CheckTagFromGround()
	{
		global::Vector tempStartPoint = this.TempStartPoint;
		global::Vector tempEndPoint = this.TempEndPoint;
		tempStartPoint.DeepCopy(this.TempPlayerLocation);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempStartPoint, (double)this.CharacterHalfHeight);
		tempEndPoint.DeepCopy(this.TempPlayerLocation);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, tempEndPoint, (double)(-(double)this.CharacterHalfHeight));
		if (this.CheckIntoWater(tempStartPoint, tempEndPoint, (float)(Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempPlayerLocation) + 0.25 * (double)this.CharacterHalfHeight * 2.0)))
		{
			this.EnterSwimmingState();
			if (this.IsDebug)
			{
				Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.LJM, "[游泳组件]触发地面入水", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor2);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060197EB RID: 104427 RVA: 0x00761DC8 File Offset: 0x0075FFC8
	private bool CheckTagFromClimb()
	{
		if (this.ClimbComp.GetTsClimbState().攀爬状态 == EClimbState.退出攀爬)
		{
			return false;
		}
		global::Vector tempVector = this.TempVector;
		tempVector.DeepCopy(this.TempPlayerGravityUp);
		tempVector.Multiply((double)this.CharacterHalfHeight, tempVector);
		this.LastTickLocation.Addition(tempVector, this.TempStartPoint);
		this.TempPlayerLocation.Subtraction(tempVector, this.TempEndPoint);
		if (!this.CheckIntoWater(this.TempStartPoint, this.TempEndPoint, (float)(Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempPlayerLocation) + 0.8 * (double)this.CharacterHalfHeight)))
		{
			return false;
		}
		if (this.SimpleVisibleTrace(this.TempStartPoint, this.TempEndPoint, 1f))
		{
			return false;
		}
		this.EnterSwimmingState();
		if (this.IsDebug)
		{
			Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.LJM, "[游泳组件]触发攀爬入水", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor2);
		}
		return true;
	}

	// Token: 0x060197EC RID: 104428 RVA: 0x00761EC4 File Offset: 0x007600C4
	public bool CheckUpWaterSurface()
	{
		global::Vector tempStartPoint = this.TempStartPoint;
		this.TempPlayerGravityUp.Multiply((double)this.SwimAreaHeightAboveActor, tempStartPoint);
		tempStartPoint.Addition(this.TempPlayerLocation, tempStartPoint);
		global::Vector tempEndPoint = this.TempEndPoint;
		this.TempPlayerGravityUp.Multiply((double)this.CharacterHalfHeight, tempEndPoint);
		tempEndPoint.Addition(this.TempPlayerLocation, tempEndPoint);
		bool flag = this.CheckIntoWater(tempStartPoint, tempEndPoint, (float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, tempEndPoint));
		if (flag && this.SimpleVisibleTrace(tempEndPoint, this.TempSwimImpactPoint, -1f))
		{
			UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
			Singleton<TraceElementCommon>.Instance.GetImpactPoint(actorTrace.HitResult, 0, this.TempVector);
			double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector);
			Singleton<TraceElementCommon>.Instance.GetImpactPoint(this.WaterTrace.HitResult, 0, this.TempVector);
			double znInGravityForActor2 = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector);
			if (znInGravityForActor < znInGravityForActor2)
			{
				this.ResetWaterLocation();
				return false;
			}
		}
		return flag;
	}

	// Token: 0x060197ED RID: 104429 RVA: 0x00761FD4 File Offset: 0x007601D4
	private bool CheckTagFromUp()
	{
		bool flag = this.CheckUpWaterSurface();
		if (flag)
		{
			this.EnterSwimmingState();
			if (this.IsDebug)
			{
				Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.LJM, "[游泳组件]触发保底的向上探测入水", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor2);
			}
		}
		return flag;
	}

	// Token: 0x060197EE RID: 104430 RVA: 0x00762020 File Offset: 0x00760220
	private bool CheckTagInOtherStateThenEnterWater(EEnterWaterState enterState)
	{
		if (this.MoveComp.FallingIntoWater && Singleton<Time>.Instance.Now > (double)this.LastEnterWaterTime)
		{
			this.MoveComp.FallingIntoWater = false;
			this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.空中入水"]));
			if (this.EnterSwimFromAirBuffIndex != 0)
			{
				CharacterBuffComponent component = base.Entity.GetComponent<CharacterBuffComponent>();
				if (component != null)
				{
					component.RemoveBuffByHandle(this.EnterSwimFromAirBuffIndex, -1, "空中入水结束", null, null, null);
				}
				this.EnterSwimFromAirBuffIndex = 0;
			}
		}
		bool flag = false;
		switch (enterState)
		{
		case EEnterWaterState.None:
			flag = false;
			break;
		case EEnterWaterState.Air:
			flag = this.CheckTagFromAir();
			break;
		case EEnterWaterState.Climb:
			flag = this.CheckTagFromClimb();
			break;
		case EEnterWaterState.Ground:
			flag = this.CheckTagFromGround();
			break;
		}
		if (enterState != EEnterWaterState.None && !flag)
		{
			flag = this.CheckTagFromUp();
		}
		return flag;
	}

	// Token: 0x060197EF RID: 104431 RVA: 0x00762110 File Offset: 0x00760310
	private void CheckCustomMovementIsSwim(float deltaTime)
	{
		if (this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Custom && this.MoveComp.CharacterMovement.CustomMovementMode == 1)
		{
			this.SprintSwimOffset = (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]) ? (this.SwimConfigInternal.Value.SprintZOffsetRate * this.ActorComp.Radius) : 0f);
			this.MoveComp.FallingIntoWater = false;
		}
	}

	// Token: 0x060197F0 RID: 104432 RVA: 0x007621A3 File Offset: 0x007603A3
	[NullableContext(1)]
	private bool IsNormalAccepted(global::Vector normal)
	{
		return Singleton<MathUtils>.Instance.DotProduct(normal, this.MoveComp.GravityUp) > 0.173;
	}

	// Token: 0x060197F1 RID: 104433 RVA: 0x007621C6 File Offset: 0x007603C6
	private void LeaveSwim()
	{
		this.BuffIndex = 0L;
		this.SprintSwimOffset = 0f;
	}

	// Token: 0x060197F2 RID: 104434 RVA: 0x007621DC File Offset: 0x007603DC
	private unsafe void CheckSwimState()
	{
		if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]))
		{
			return;
		}
		if (this.WaterVolume && !this.IsNormalAccepted(this.TempSwimNormalPoint))
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Falling,
					CustomMode = 0,
					Context = "[CharacterSwimComponent.CheckSwimState] 1"
				});
			}
			if (this.IsDebug)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[游泳组件]触发水面角度不够游泳支持触发出水";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("水面法线:", this.TempSwimNormalPoint);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor3);
				return;
			}
		}
		else if (!this.WaterVolume && !this.MoveComp.FallingIntoWater)
		{
			if (this.CheckUpWaterSurface())
			{
				this.Depth = 2f;
				return;
			}
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Walking,
					CustomMode = 0,
					Context = "[CharacterSwimComponent.CheckSwimState] 2"
				});
			}
			this.LeaveSwim();
			if (this.IsDebug)
			{
				Singleton<Log>.Instance.Info(ELogModule.Movement, ELogAuthor.LJM, "[游泳组件]游泳向上探测出水未有水面触发出水", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor3);
				return;
			}
		}
		else if ((double)this.Depth <= 0.7)
		{
			if (this.HasFloor == ECheckFloorResult.Floor)
			{
				CharacterActorComponent actorComp3 = this.ActorComp;
				if (actorComp3 != null)
				{
					actorComp3.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Walking,
						CustomMode = 0,
						Context = "[CharacterSwimComponent.CheckSwimState] 3"
					});
				}
				if (this.IsDebug)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Movement;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "[游泳组件]触发碰撞并且游泳深度不够触发出水";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("当前深度:", this.Depth);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("出水深度:", 0.7);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.DrawDebugCapsuleComponent(CharacterSwimUtils.DebugColor3);
					return;
				}
			}
			else if (this.HasFloor == ECheckFloorResult.NotFloor)
			{
				CharacterActorComponent actorComp4 = this.ActorComp;
				if (actorComp4 == null)
				{
					return;
				}
				actorComp4.SetActorLocation(this.ActorComp.LastActorLocation.ToUeVector(false), "SwimOff", false);
			}
		}
	}

	// Token: 0x060197F3 RID: 104435 RVA: 0x00762439 File Offset: 0x00760639
	public bool CheckCanEnterClimbFromSwim()
	{
		return !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]) || (double)this.Depth <= 0.8;
	}

	// Token: 0x060197F4 RID: 104436 RVA: 0x00762470 File Offset: 0x00760670
	[NullableContext(1)]
	private float DetectWaterDepth(global::Vector start, global::Vector end)
	{
		if (!this.SimpleWaterTrace(start, end))
		{
			return 0f;
		}
		if (this.IsDebug)
		{
			FVectorDouble fvectorDouble = this.TempSwimImpactPoint.ToUeVector(false);
			this.DrawDebugSphere(fvectorDouble, CharacterSwimUtils.DebugColor2);
		}
		start.Subtraction(end, this.TempVector3);
		return (float)(Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TempVector3) * (double)(1f - this.SwimTime) / (double)(2f * this.CharacterHalfHeight));
	}

	// Token: 0x060197F5 RID: 104437 RVA: 0x007624F8 File Offset: 0x007606F8
	private void RefreshSwimBuff()
	{
		CharacterUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
		if (unifiedStateComp == null || unifiedStateComp.PositionState != global::ECharPositionState.Water)
		{
			this.BuffIndex = 0L;
			return;
		}
		if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.游泳.游泳体力消耗"]))
		{
			this.BuffIndex = 0L;
			return;
		}
		bool hasMoveInput = this.MoveComp.HasMoveInput;
		this.BuffIndex = ConfigBase<SwimConfig>.Instance.GetSwimBuffId(hasMoveInput, this.IsFastSwim).Value;
	}

	// Token: 0x060197F6 RID: 104438 RVA: 0x00762578 File Offset: 0x00760778
	private void ResetWaterLocation()
	{
		if (this.TempSwimImpactPoint != null)
		{
			this.TempSwimImpactPoint.Reset();
		}
		if (this.TempSwimNormalPoint != null)
		{
			this.TempSwimNormalPoint.Reset();
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempSwimNormalPoint, double.MinValue);
		}
		if (this.TempWaterImpactPoint != null)
		{
			this.TempWaterImpactPoint.Reset();
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TempWaterImpactPoint, double.MinValue);
		}
	}

	// Token: 0x060197F7 RID: 104439 RVA: 0x007625FC File Offset: 0x007607FC
	public FVectorDouble GetWaterLocation()
	{
		return this.TempWaterImpactPoint.ToUeVector(false);
	}

	// Token: 0x060197F8 RID: 104440 RVA: 0x0076260A File Offset: 0x0076080A
	public FVectorDouble GetSwimLocation()
	{
		return this.TempSwimImpactPoint.ToUeVector(false);
	}

	// Token: 0x060197F9 RID: 104441 RVA: 0x00762618 File Offset: 0x00760818
	public bool GetWaterVolume()
	{
		return this.WaterVolume;
	}

	// Token: 0x060197FA RID: 104442 RVA: 0x00762620 File Offset: 0x00760820
	public void SetEnterWaterState(bool isEnter)
	{
		this.SwimState = (isEnter ? ESwimState.Other : ESwimState.Swim);
	}

	// Token: 0x060197FB RID: 104443 RVA: 0x00762630 File Offset: 0x00760830
	[return: TupleElementNames(new string[]
	{
		"Depth",
		"WaterHeight",
		"SurfaceNormal",
		"Velocity",
		"Location"
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	public ValueTuple<float, float, global::Vector, global::Vector, global::Vector>? GetAboveFootWaterSurfaceInfo()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (((actorComp != null) ? actorComp.SkeletalMesh : null) == null)
		{
			return null;
		}
		if (!this.InSwimArea() || this.Depth <= 0f || this.TempSwimNormalPoint == null)
		{
			return null;
		}
		if (this.Depth == 2f)
		{
			return null;
		}
		float item = this.Depth * this.CharacterHalfHeight * 2f;
		this.FixNormal(this.TempSwimNormalPoint);
		global::Vector item2 = global::Vector.Create(this.TempSwimNormalPoint);
		global::Vector vector = global::Vector.Create();
		global::Vector vector2 = vector;
		FVectorDouble fvectorDouble = this.ActorComp.SkeletalMesh.D_K2_GetComponentLocation();
		vector2.FromUeVector(fvectorDouble);
		global::Vector item3 = global::Vector.Create(this.ActorComp.ActorVelocityProxy);
		return new ValueTuple<float, float, global::Vector, global::Vector, global::Vector>?(new ValueTuple<float, float, global::Vector, global::Vector, global::Vector>(this.Depth, item, item2, item3, vector));
	}

	// Token: 0x060197FC RID: 104444 RVA: 0x00762710 File Offset: 0x00760910
	private void DrawDebugCapsuleComponent(FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugCapsule(this.ActorComp.Actor, this.ActorComp.Actor.D_K2_GetActorLocation(), this.ActorComp.Actor.CapsuleComponent.CapsuleHalfHeight, this.ActorComp.Actor.CapsuleComponent.CapsuleRadius, this.ActorComp.Actor.K2_GetActorRotation(), new FLinearColor?(color), 5f, 2f);
	}

	// Token: 0x060197FD RID: 104445 RVA: 0x00762787 File Offset: 0x00760987
	private void DrawDebugSphere(FVector location, FLinearColor color)
	{
		UKismetSystemLibrary.D_DrawDebugSphere(this.ActorComp.Actor, location, this.ActorComp.Actor.CapsuleComponent.CapsuleHalfHeight, 12, new FLinearColor?(color), 0f, 1f);
	}

	// Token: 0x060197FE RID: 104446 RVA: 0x007627C7 File Offset: 0x007609C7
	public void SetDebug(bool debug)
	{
		this.IsDebug = debug;
		this.WaterTrace.SetDrawDebugTrace(this.IsDebug ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
	}

	// Token: 0x060197FF RID: 104447 RVA: 0x007627E7 File Offset: 0x007609E7
	public void LogSwimTriggerCount()
	{
		bool isDebug = this.IsDebug;
	}

	// Token: 0x06019800 RID: 104448 RVA: 0x007627F0 File Offset: 0x007609F0
	public static void CreateStaticDefaultValue()
	{
		CharacterSwimComponent.UseSwimTrigger = false;
	}

	// Token: 0x06019801 RID: 104449 RVA: 0x007627F8 File Offset: 0x007609F8
	public static void ResetStaticDefaultValue()
	{
		CharacterSwimComponent.UseSwimTrigger = false;
	}

	// Token: 0x06019802 RID: 104450 RVA: 0x00762800 File Offset: 0x00760A00
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSwimComponent characterSwimComponent = (CharacterSwimComponent)componentTemplate;
		if (base.CanResetComponentProperty("IsDebug"))
		{
			this.IsDebug = characterSwimComponent.IsDebug;
		}
		if (base.CanResetComponentProperty("TempPlayerLocation"))
		{
			if (characterSwimComponent.TempPlayerLocation == null)
			{
				this.TempPlayerLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempPlayerLocation), "TempPlayerLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempPlayerGravityUp"))
		{
			if (characterSwimComponent.TempPlayerGravityUp == null)
			{
				this.TempPlayerGravityUp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempPlayerGravityUp), "TempPlayerGravityUp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterHalfHeight"))
		{
			this.CharacterHalfHeight = characterSwimComponent.CharacterHalfHeight;
		}
		if (base.CanResetComponentProperty("LastTickLocation"))
		{
			if (characterSwimComponent.LastTickLocation == null)
			{
				this.LastTickLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastTickLocation), "LastTickLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasFloor"))
		{
			this.HasFloor = characterSwimComponent.HasFloor;
		}
		if (base.CanResetComponentProperty("Depth"))
		{
			this.Depth = characterSwimComponent.Depth;
		}
		if (base.CanResetComponentProperty("RotateSpeed"))
		{
			this.RotateSpeed = characterSwimComponent.RotateSpeed;
		}
		if (base.CanResetComponentProperty("SwimAcceleratorCurve"))
		{
			if (characterSwimComponent.SwimAcceleratorCurve == null)
			{
				this.SwimAcceleratorCurve = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.SwimAcceleratorCurve), "SwimAcceleratorCurve"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SwimRotationCurve"))
		{
			if (characterSwimComponent.SwimRotationCurve == null)
			{
				this.SwimRotationCurve = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.SwimRotationCurve), "SwimRotationCurve"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempWaterImpactPoint"))
		{
			if (characterSwimComponent.TempWaterImpactPoint == null)
			{
				this.TempWaterImpactPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempWaterImpactPoint), "TempWaterImpactPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempSwimImpactPoint"))
		{
			if (characterSwimComponent.TempSwimImpactPoint == null)
			{
				this.TempSwimImpactPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempSwimImpactPoint), "TempSwimImpactPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempSwimNormalPoint"))
		{
			if (characterSwimComponent.TempSwimNormalPoint == null)
			{
				this.TempSwimNormalPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempSwimNormalPoint), "TempSwimNormalPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SwimTime"))
		{
			this.SwimTime = characterSwimComponent.SwimTime;
		}
		if (base.CanResetComponentProperty("WaterVolume"))
		{
			this.WaterVolume = characterSwimComponent.WaterVolume;
		}
		if (base.CanResetComponentProperty("WaterSlope"))
		{
			this.WaterSlope = characterSwimComponent.WaterSlope;
		}
		if (base.CanResetComponentProperty("MaxSpeed"))
		{
			this.MaxSpeed = characterSwimComponent.MaxSpeed;
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterSwimComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterSwimComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComp"))
		{
			if (characterSwimComponent.UnifiedStateComp == null)
			{
				this.UnifiedStateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComp), "UnifiedStateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterSwimComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterSwimComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ClimbComp"))
		{
			if (characterSwimComponent.ClimbComp == null)
			{
				this.ClimbComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterClimbComponent>(this.ClimbComp), "ClimbComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterSwimComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempVector"))
		{
			if (characterSwimComponent.TempVector == null)
			{
				this.TempVector = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector), "TempVector"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempVector2"))
		{
			if (characterSwimComponent.TempVector2 == null)
			{
				this.TempVector2 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector2), "TempVector2"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempVector3"))
		{
			if (characterSwimComponent.TempVector3 == null)
			{
				this.TempVector3 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector3), "TempVector3"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempStartPoint"))
		{
			if (characterSwimComponent.TempStartPoint == null)
			{
				this.TempStartPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempStartPoint), "TempStartPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempEndPoint"))
		{
			if (characterSwimComponent.TempEndPoint == null)
			{
				this.TempEndPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempEndPoint), "TempEndPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SwimConfigInternal"))
		{
			this.SwimConfigInternal = characterSwimComponent.SwimConfigInternal;
		}
		if (base.CanResetComponentProperty("SprintSwimOffset"))
		{
			this.SprintSwimOffset = characterSwimComponent.SprintSwimOffset;
		}
		if (base.CanResetComponentProperty("SprintSwimOffsetLerpSpeed"))
		{
			this.SprintSwimOffsetLerpSpeed = characterSwimComponent.SprintSwimOffsetLerpSpeed;
		}
		if (base.CanResetComponentProperty("DeltaTime"))
		{
			this.DeltaTime = characterSwimComponent.DeltaTime;
		}
		if (base.CanResetComponentProperty("DetectFallIntoWaterPosition"))
		{
			if (characterSwimComponent.DetectFallIntoWaterPosition == null)
			{
				this.DetectFallIntoWaterPosition = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.DetectFallIntoWaterPosition), "DetectFallIntoWaterPosition"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffIndexInternal"))
		{
			this.BuffIndexInternal = characterSwimComponent.BuffIndexInternal;
		}
		if (base.CanResetComponentProperty("EnterSwimFromAirBuffIndex"))
		{
			this.EnterSwimFromAirBuffIndex = characterSwimComponent.EnterSwimFromAirBuffIndex;
		}
		if (base.CanResetComponentProperty("IsFastSwim"))
		{
			this.IsFastSwim = characterSwimComponent.IsFastSwim;
		}
		if (base.CanResetComponentProperty("SwimState"))
		{
			this.SwimState = characterSwimComponent.SwimState;
		}
		if (base.CanResetComponentProperty("LastEnterWaterTime"))
		{
			this.LastEnterWaterTime = characterSwimComponent.LastEnterWaterTime;
		}
		if (base.CanResetComponentProperty("WaterTrace"))
		{
			if (characterSwimComponent.WaterTrace == null)
			{
				this.WaterTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.WaterTrace), "WaterTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InSwimTriggerCount"))
		{
			this.InSwimTriggerCount = characterSwimComponent.InSwimTriggerCount;
		}
		if (base.CanResetComponentProperty("IsRole"))
		{
			this.IsRole = characterSwimComponent.IsRole;
		}
		if (base.CanResetComponentProperty("SwimAreaHeightAboveActor"))
		{
			this.SwimAreaHeightAboveActor = characterSwimComponent.SwimAreaHeightAboveActor;
		}
		if (base.CanResetComponentProperty("InSwimAreaInternal"))
		{
			this.InSwimAreaInternal = characterSwimComponent.InSwimAreaInternal;
		}
		if (base.CanResetComponentProperty("WaterHeightAboveMe"))
		{
			this.WaterHeightAboveMe = characterSwimComponent.WaterHeightAboveMe;
		}
		if (base.CanResetComponentProperty("ForceCheck"))
		{
			this.ForceCheck = characterSwimComponent.ForceCheck;
		}
		if (base.CanResetComponentProperty("WaterTypeInternal"))
		{
			this.WaterTypeInternal = characterSwimComponent.WaterTypeInternal;
		}
		return true;
	}

	// Token: 0x0400CA17 RID: 51735
	[Nullable(1)]
	private const string PROFILE_DETECT_WATER_DEPTH = "CharacterSwimComponent_DetectWaterDepth";

	// Token: 0x0400CA18 RID: 51736
	[Nullable(1)]
	private const string PROFILE_FLOOR = "CharacterSwimComponent_CheckHasArrivedFloorInSwimming";

	// Token: 0x0400CA19 RID: 51737
	private const long MAX_LAST_TICK_OFFSET_SQUARE = 100000000L;

	// Token: 0x0400CA1A RID: 51738
	private const int MAX_SPEED_INTO_WATER = 50;

	// Token: 0x0400CA1B RID: 51739
	private const double ENTER_SWIM_BIGGER_THAN_THIS = 0.75;

	// Token: 0x0400CA1C RID: 51740
	public const double LEAVE_SWIM_LESS_THAN_THIS = 0.7;

	// Token: 0x0400CA1D RID: 51741
	public const double LEAVE_SWIM_LESS_THAN_THIS_AIR = 0.6;

	// Token: 0x0400CA1E RID: 51742
	private const double CLIMB_CHECK_ENTER_WATER_RATE = 0.8;

	// Token: 0x0400CA1F RID: 51743
	private const int ONE_HUNDRED_TO_FIND_SURFACE = 100;

	// Token: 0x0400CA20 RID: 51744
	private const int FIVE_HUNDRED_TO_FIND_SURFACE = 500;

	// Token: 0x0400CA21 RID: 51745
	private const int TIME_CLEAR_ENTER_WATER = 500;

	// Token: 0x0400CA22 RID: 51746
	public const double SWIMMING_BUOYANCY = 1.4;

	// Token: 0x0400CA23 RID: 51747
	private const double SWIMMING_FRICTION = 0.01;

	// Token: 0x0400CA24 RID: 51748
	private const int SWIMMING_FRICTION_MIN_SPEED = 75;

	// Token: 0x0400CA25 RID: 51749
	private const int SWIMMING_FRICTION_RATION = 10000;

	// Token: 0x0400CA26 RID: 51750
	private const int SWIMMING_MAX_DEPTH = 2;

	// Token: 0x0400CA27 RID: 51751
	private const int SWIMMING_ACCELERATOR = 200;

	// Token: 0x0400CA28 RID: 51752
	public const float SWIMMING_DECELERATION = 0.06f;

	// Token: 0x0400CA29 RID: 51753
	private const double COS_EIGHTY = 0.173;

	// Token: 0x0400CA2A RID: 51754
	private const double MIN_DEPTH = -1.7976931348623157E+308;

	// Token: 0x0400CA2B RID: 51755
	private static readonly FVectorDouble waterAreaDetectExtent = new FVectorDouble(500.0, 500.0, 10000.0);

	// Token: 0x0400CA2C RID: 51756
	private const int WATER_BOTTOM_TOLERANCE = 50;

	// Token: 0x0400CA2D RID: 51757
	private const int VEHICLE_ADDITIONAL_HEIGHT = 600;

	// Token: 0x0400CA2E RID: 51758
	private const int VEHICLE_ADDITIONAL_DEPTH = 250;

	// Token: 0x0400CA2F RID: 51759
	public bool IsDebug;

	// Token: 0x0400CA30 RID: 51760
	private static readonly FName TagWaterNoSwim = new FName("Water_No_Swim");

	// Token: 0x0400CA31 RID: 51761
	public static bool UseSwimTrigger = false;

	// Token: 0x0400CA32 RID: 51762
	private global::Vector TempPlayerLocation;

	// Token: 0x0400CA33 RID: 51763
	private global::Vector TempPlayerGravityUp;

	// Token: 0x0400CA34 RID: 51764
	private float CharacterHalfHeight;

	// Token: 0x0400CA35 RID: 51765
	private global::Vector LastTickLocation;

	// Token: 0x0400CA36 RID: 51766
	private ECheckFloorResult HasFloor;

	// Token: 0x0400CA37 RID: 51767
	public float Depth;

	// Token: 0x0400CA38 RID: 51768
	public float RotateSpeed;

	// Token: 0x0400CA39 RID: 51769
	public UCurveFloat SwimAcceleratorCurve;

	// Token: 0x0400CA3A RID: 51770
	public UCurveFloat SwimRotationCurve;

	// Token: 0x0400CA3B RID: 51771
	private global::Vector TempWaterImpactPoint;

	// Token: 0x0400CA3C RID: 51772
	private global::Vector TempSwimImpactPoint;

	// Token: 0x0400CA3D RID: 51773
	private global::Vector TempSwimNormalPoint;

	// Token: 0x0400CA3E RID: 51774
	private float SwimTime;

	// Token: 0x0400CA3F RID: 51775
	private bool WaterVolume;

	// Token: 0x0400CA40 RID: 51776
	public float WaterSlope;

	// Token: 0x0400CA41 RID: 51777
	public float MaxSpeed;

	// Token: 0x0400CA42 RID: 51778
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CA43 RID: 51779
	private BaseTagComponent TagComp;

	// Token: 0x0400CA44 RID: 51780
	private CharacterUnifiedStateComponent UnifiedStateComp;

	// Token: 0x0400CA45 RID: 51781
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400CA46 RID: 51782
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400CA47 RID: 51783
	private CharacterClimbComponent ClimbComp;

	// Token: 0x0400CA48 RID: 51784
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400CA49 RID: 51785
	private global::Vector TempVector;

	// Token: 0x0400CA4A RID: 51786
	private global::Vector TempVector2;

	// Token: 0x0400CA4B RID: 51787
	private global::Vector TempVector3;

	// Token: 0x0400CA4C RID: 51788
	private global::Vector TempStartPoint;

	// Token: 0x0400CA4D RID: 51789
	private global::Vector TempEndPoint;

	// Token: 0x0400CA4E RID: 51790
	private Swim? SwimConfigInternal;

	// Token: 0x0400CA4F RID: 51791
	public float SprintSwimOffset;

	// Token: 0x0400CA50 RID: 51792
	public float SprintSwimOffsetLerpSpeed;

	// Token: 0x0400CA51 RID: 51793
	private float DeltaTime;

	// Token: 0x0400CA52 RID: 51794
	private global::Vector DetectFallIntoWaterPosition;

	// Token: 0x0400CA53 RID: 51795
	private long BuffIndexInternal;

	// Token: 0x0400CA54 RID: 51796
	protected int EnterSwimFromAirBuffIndex;

	// Token: 0x0400CA55 RID: 51797
	private bool IsFastSwim;

	// Token: 0x0400CA56 RID: 51798
	private ESwimState SwimState = ESwimState.Other;

	// Token: 0x0400CA57 RID: 51799
	private float LastEnterWaterTime;

	// Token: 0x0400CA58 RID: 51800
	private UTraceSphereElement WaterTrace;

	// Token: 0x0400CA59 RID: 51801
	public int InSwimTriggerCount;

	// Token: 0x0400CA5A RID: 51802
	public bool IsRole;

	// Token: 0x0400CA5B RID: 51803
	private float SwimAreaHeightAboveActor;

	// Token: 0x0400CA5C RID: 51804
	private bool InSwimAreaInternal;

	// Token: 0x0400CA5D RID: 51805
	public float WaterHeightAboveMe;

	// Token: 0x0400CA5E RID: 51806
	private bool ForceCheck;

	// Token: 0x0400CA5F RID: 51807
	private EInteractionWaterType WaterTypeInternal;
}
