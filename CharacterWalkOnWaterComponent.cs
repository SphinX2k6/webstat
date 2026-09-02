using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Capability;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;

// Token: 0x0200307A RID: 12410
[NullableContext(1)]
[Nullable(0)]
public class CharacterWalkOnWaterComponent : EntityComponent, IComponentDependency
{
	// Token: 0x06019831 RID: 104497 RVA: 0x007644C8 File Offset: 0x007626C8
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		this.TagComp = component;
		CharacterMoveComponent component2 = base.Entity.GetComponent<CharacterMoveComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		this.WalkOnWaterStage = EWalkOnWaterStage.None;
		this.MoveComp = component2;
		this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.FloatingComp = base.Entity.GetComponent<CharacterFloatingComponent>();
		this.CharacterHalfHeight = this.ActorComp.HalfHeight + 3f;
		this.CreateTempVector();
		this.RegisterEvent();
		this.InitTraceElements();
		this.OriginChannelResponse = new ECollisionResponse?(this.ActorComp.Actor.CapsuleComponent.GetCollisionResponseToChannel(KuroCollisionChannel.KuroWater));
		return true;
	}

	// Token: 0x06019832 RID: 104498 RVA: 0x007645B0 File Offset: 0x007627B0
	protected override bool OnEnd()
	{
		this.UnregisterEvent();
		this.ClearTempVector();
		foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
		{
			waterDetectedCapability.Deactivate();
		}
		this.GameCapabilities.Clear();
		return true;
	}

	// Token: 0x06019833 RID: 104499 RVA: 0x00764618 File Offset: 0x00762818
	protected override void OnEnable()
	{
		this.PrePlayerLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
	}

	// Token: 0x06019834 RID: 104500 RVA: 0x00764630 File Offset: 0x00762830
	protected override void OnDisable(string reason)
	{
		this.SetWalkOnWaterStage(EWalkOnWaterStage.None);
	}

	// Token: 0x06019835 RID: 104501 RVA: 0x0076463C File Offset: 0x0076283C
	private void RegisterEvent()
	{
		this.OnStateTagsChanged(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不会入水"], this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不会入水"]));
		this.OnGameplayTagNewOrRemove = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不会入水"]), new BaseTagComponent.TTagSwitchedCallback(this.OnStateTagsChanged), null);
		this.OnFreezeWaterTagChanged(this.freeWaterStateTag, this.TagComp.HasTag(this.freeWaterStateTag));
		this.OnFreezeWaterTagAddOrRemove = this.TagComp.ListenForTagAddOrRemove(new int?(this.freeWaterStateTag), new BaseTagComponent.TTagSwitchedCallback(this.OnFreezeWaterTagChanged), null);
		Singleton<EventSystem>.Instance.AddWithTarget<ECharMoveState, ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.OnMoveStateChange));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.AddWithTarget<float>(base.Entity, EEventName.CustomMoveWalkOnWater, new Action<float>(this.ReceiveWalkOnWaterEvent));
		Singleton<EventSystem>.Instance.AddWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, float, float, bool>(base.Entity, EEventName.OnCharacterCapsuleChanged, new Action<Entity, float, float, bool>(this.OnCharacterCapsuleChanged));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
	}

	// Token: 0x06019836 RID: 104502 RVA: 0x007647B4 File Offset: 0x007629B4
	private void UnregisterEvent()
	{
		this.OnGameplayTagNewOrRemove.EndTask();
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.RemoveWithTarget<float>(base.Entity, EEventName.CustomMoveWalkOnWater, new Action<float>(this.ReceiveWalkOnWaterEvent));
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharMoveState, ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.OnMoveStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, float, float, bool>(base.Entity, EEventName.OnCharacterCapsuleChanged, new Action<Entity, float, float, bool>(this.OnCharacterCapsuleChanged));
		Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
	}

	// Token: 0x06019837 RID: 104503 RVA: 0x00764890 File Offset: 0x00762A90
	private void CreateTempVector()
	{
		this.TempVector = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempVector2 = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempStartPoint = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempEndPoint = global::Vector.Create(0.0, 0.0, 0.0);
		this.TempNormalPoint = global::Vector.Create(0.0, 0.0, 0.0);
	}

	// Token: 0x06019838 RID: 104504 RVA: 0x0076495B File Offset: 0x00762B5B
	private void ClearTempVector()
	{
		this.TempVector = null;
		this.TempVector2 = null;
		this.TempStartPoint = null;
		this.TempEndPoint = null;
		this.TempNormalPoint = null;
	}

	// Token: 0x1700225E RID: 8798
	// (get) Token: 0x06019839 RID: 104505 RVA: 0x00764980 File Offset: 0x00762B80
	public static Type[] Dependencies
	{
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

	// Token: 0x0601983A RID: 104506 RVA: 0x007649B0 File Offset: 0x00762BB0
	private void InitTraceElements()
	{
		this.WaterTrace = new UTraceSphereElement();
		this.WaterTrace.WorldContextObject = this.ActorComp.Actor;
		this.WaterTrace.Radius = 3f;
		this.WaterTrace.bIgnoreSelf = true;
		this.WaterTrace.bIsSingle = true;
		this.WaterTrace.SetDrawDebugTrace(this.IsDebug ? EDrawDebugTrace.ForOneFrame : EDrawDebugTrace.None);
		this.WaterTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.WaterTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor3);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.WaterTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor4);
		this.WaterEdgeTrace = new UTraceSphereElement();
		this.WaterEdgeTrace.WorldContextObject = this.ActorComp.Actor;
		this.WaterEdgeTrace.Radius = this.ActorComp.Radius + 20f;
		this.WaterEdgeTrace.bIgnoreSelf = true;
		this.WaterEdgeTrace.bIsSingle = true;
		this.WaterEdgeTrace.SetDrawDebugTrace(this.IsDebug ? EDrawDebugTrace.ForOneFrame : EDrawDebugTrace.None);
		this.WaterEdgeTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.WaterEdgeTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor1);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.WaterEdgeTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor2);
		this.WaterUpTrace = new UTraceLineElement();
		this.WaterUpTrace.WorldContextObject = this.ActorComp.Actor;
		this.WaterUpTrace.bIgnoreSelf = true;
		this.WaterUpTrace.bIsSingle = true;
		this.WaterUpTrace.SetDrawDebugTrace(this.IsDebug ? EDrawDebugTrace.ForOneFrame : EDrawDebugTrace.None);
		this.WaterUpTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.WaterUpTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor3);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.WaterUpTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor4);
		this.GroundTrace = new UTraceSphereElement();
		this.GroundTrace.WorldContextObject = this.ActorComp.Actor;
		this.GroundTrace.Radius = 3f;
		this.GroundTrace.bIgnoreSelf = true;
		this.GroundTrace.bIsSingle = false;
		this.GroundTrace.SetDrawDebugTrace(this.IsDebug ? EDrawDebugTrace.ForOneFrame : EDrawDebugTrace.None);
		this.GroundTrace.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.GroundTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor1);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.GroundTrace, <CharacterWalkOnWaterComponent>FDDFC8204C59A900BB2FEEFF8DF7D2C031BD14FA064800C38FA8A739A77F73174__CharacterSwimUtils.DebugColor2);
	}

	// Token: 0x0601983B RID: 104507 RVA: 0x00764C24 File Offset: 0x00762E24
	private void AddFreezeWaterCapabilities()
	{
		if (this.GameCapabilities.Count > 0)
		{
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		bool flag;
		if (actorComp == null)
		{
			flag = true;
		}
		else
		{
			AActor owner = actorComp.Owner;
			flag = !((owner != null) ? new bool?(owner.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		string text = ConfigCommonParamById.GetStringConfig("FeixueTrailCollisionAsset") ?? string.Empty;
		UKuroTrailCollisionAsset ukuroTrailCollisionAsset = Singleton<ResourceSystem>.Instance.Load<UKuroTrailCollisionAsset>(text, "js_undefined");
		if (ukuroTrailCollisionAsset == null || !ukuroTrailCollisionAsset.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "CharacterWalkOnWaterComponent: kuroTrailCollisionAsset is invalid";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", text);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.FreezeWaterRenderCapability = new FreezeWaterRenderCapability(this.ActorComp.Owner, ukuroTrailCollisionAsset);
		this.GameCapabilities.Add(this.FreezeWaterRenderCapability);
		foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
		{
			waterDetectedCapability.Activate();
		}
	}

	// Token: 0x0601983C RID: 104508 RVA: 0x00764D44 File Offset: 0x00762F44
	private float GetMaxSpeed(ECharMoveState state)
	{
		switch (state)
		{
		case ECharMoveState.Walk:
			return this.MoveComp.WalkSpeed;
		case ECharMoveState.Run:
			return this.MoveComp.RunSpeed;
		case ECharMoveState.Sprint:
			return this.MoveComp.SprintSpeed;
		}
		return 0f;
	}

	// Token: 0x0601983D RID: 104509 RVA: 0x00764D98 File Offset: 0x00762F98
	private void OnMoveStateChange(ECharMoveState oldMoveState, ECharMoveState newMoveState)
	{
		if (this.WalkOnWaterStage == EWalkOnWaterStage.UpToWaterSurface && this.GetMaxSpeed(newMoveState) > 0f)
		{
			this.MoveComp.CharacterMovement.MaxCustomMovementSpeed = this.GetMaxSpeed(newMoveState);
		}
	}

	// Token: 0x0601983E RID: 104510 RVA: 0x00764DC8 File Offset: 0x00762FC8
	private void ReceiveWalkOnWaterEvent(float deltaTime)
	{
		this.MoveComp.CharacterMovement.KuroFlying(deltaTime, 0f, 0f, 0f, this.MoveComp.CurrentMovementSettings.Acceleration, this.GetMaxSpeed(this.StateComp.MoveState), 1f);
	}

	// Token: 0x0601983F RID: 104511 RVA: 0x00764E1C File Offset: 0x0076301C
	private void OnStateInherit(Entity other, bool notInheritMoveAndAnim)
	{
		if (other == null || !other.Valid)
		{
			return;
		}
		this.IsActive = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不会入水"]);
		if (!this.IsActive)
		{
			this.SetWalkOnWaterStage(EWalkOnWaterStage.None);
		}
	}

	// Token: 0x06019840 RID: 104512 RVA: 0x00764E6A File Offset: 0x0076306A
	private void OnFreezeWaterTagChanged(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			this.AddFreezeWaterCapabilities();
			return;
		}
		this.BroadcastWaterDetectedEnd();
	}

	// Token: 0x06019841 RID: 104513 RVA: 0x00764E7C File Offset: 0x0076307C
	private void OnStateTagsChanged(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			if (this.DisableKey != 0)
			{
				base.Enable(new int?(this.DisableKey), "不会入水Tag");
				this.DisableKey = 0;
			}
		}
		else if (this.DisableKey == 0)
		{
			this.DisableKey = base.Disable("不会入水Tag");
		}
		this.IsActive = tagExists;
		if (!tagExists)
		{
			this.SetWalkOnWaterStage(EWalkOnWaterStage.None);
		}
	}

	// Token: 0x06019842 RID: 104514 RVA: 0x00764EE0 File Offset: 0x007630E0
	private void OnPositionStateChanged(ECharPositionState oldPositionState, ECharPositionState newPositionState)
	{
		if (!this.IsActive)
		{
			return;
		}
		if (newPositionState == ECharPositionState.Ground)
		{
			if (this.CheckEnterWater() || this.CheckWaterEdge() || this.CheckUpWaterSurface())
			{
				this.StateComp.SetPositionSubState(ECharPositionSubState.WaterSurface, false);
				return;
			}
			this.StateComp.SetPositionSubState(ECharPositionSubState.None, false);
		}
	}

	// Token: 0x06019843 RID: 104515 RVA: 0x00764F2C File Offset: 0x0076312C
	private void OnCharacterCapsuleChanged(Entity entity, float radius, float halfHeight, bool bUpdateOverlaps)
	{
		this.CharacterHalfHeight = halfHeight + 3f;
	}

	// Token: 0x06019844 RID: 104516 RVA: 0x00764F3C File Offset: 0x0076313C
	[NullableContext(2)]
	private void OnTeleportComplete(TeleportContext teleportContext)
	{
		if (!this.IsActive)
		{
			return;
		}
		CharacterUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null && stateComp.PositionState == ECharPositionState.Ground && (this.CheckEnterWater() || this.CheckWaterEdge() || this.CheckUpWaterSurface()))
		{
			this.StateComp.SetPositionSubState(ECharPositionSubState.WaterSurface, false);
		}
	}

	// Token: 0x06019845 RID: 104517 RVA: 0x00764F8E File Offset: 0x0076318E
	public bool BlockMoveModeInherit(UCharacterMovementComponent otherCharacterMovement)
	{
		return !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不会入水"]) && otherCharacterMovement.MovementMode == EMovementMode.MOVE_Custom && otherCharacterMovement.CustomMovementMode == 5;
	}

	// Token: 0x06019846 RID: 104518 RVA: 0x00764FCB File Offset: 0x007631CB
	private bool IsNormalAccepted(global::Vector normal)
	{
		return Math.Abs(Singleton<MathUtils>.Instance.DotProduct(normal, this.ActorComp.ActorUpProxy)) > 0.17299999296665192;
	}

	// Token: 0x06019847 RID: 104519 RVA: 0x00764FF4 File Offset: 0x007631F4
	private bool CheckUpWaterSurface()
	{
		global::Vector tempStartPoint = this.TempStartPoint;
		this.ActorComp.ActorUpProxy.Multiply(1000.0, tempStartPoint);
		this.ActorComp.ActorLocationProxy.Addition(tempStartPoint, tempStartPoint);
		global::Vector tempEndPoint = this.TempEndPoint;
		this.ActorComp.ActorUpProxy.Multiply((double)(-(double)this.CharacterHalfHeight), tempEndPoint);
		this.ActorComp.ActorLocationProxy.Subtraction(tempEndPoint, tempEndPoint);
		bool flag = this.CheckIntoWater(tempStartPoint, tempEndPoint);
		if (flag)
		{
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.WaterUpTrace, tempEndPoint);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.WaterUpTrace, tempStartPoint);
			global::Vector tempVector = this.TempVector;
			if (Singleton<TraceElementCommon>.Instance.LineTrace(this.WaterUpTrace, "CharacterWalkOnWaterComponent_WaterUpBlock") && this.WaterUpTrace.HitResult.bBlockingHit)
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(this.WaterUpTrace.HitResult, 0, tempVector);
				this.WaterHeight = (float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, tempVector);
				Singleton<TraceElementCommon>.Instance.GetImpactNormal(this.WaterTrace.HitResult, 0, this.WaterNormal);
				Singleton<TraceElementCommon>.Instance.GetImpactPoint(this.WaterTrace.HitResult, 0, this.WaterImpactPoint);
				if ((double)this.WaterHeight - Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.FloorLocation) < (double)this.Depth)
				{
					return false;
				}
			}
		}
		return flag;
	}

	// Token: 0x06019848 RID: 104520 RVA: 0x00765168 File Offset: 0x00763368
	private bool CheckEnterWater()
	{
		global::Vector tempStartPoint = this.TempStartPoint;
		global::Vector tempEndPoint = this.TempEndPoint;
		if (this.WalkOnWaterStage == EWalkOnWaterStage.None)
		{
			global::Vector tempVector = this.TempVector2;
			this.ActorComp.ActorLocationProxy.Subtraction(this.PrePlayerLocation, tempVector);
			if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, tempVector) < 0.0 && global::Vector.DistSquared(this.PrePlayerLocation, this.ActorComp.ActorLocationProxy) < 1000000.0)
			{
				global::Vector tempVector2 = this.TempVector;
				this.ActorComp.ActorUpProxy.Multiply((double)(this.CharacterHalfHeight - 3f), tempVector2);
				global::Vector tempVector3 = this.TempVector2;
				this.ActorComp.ActorLocationProxy.Subtraction(this.PrePlayerLocation, tempVector3);
				tempVector3.Normalize(9.99999993922529E-09);
				tempVector3.Multiply(3.0, tempVector3);
				this.PrePlayerLocation.Addition(tempVector2, tempStartPoint);
				tempStartPoint.SubtractionEqual(tempVector3);
				this.ActorComp.ActorLocationProxy.Subtraction(tempVector2, tempEndPoint);
				tempEndPoint.AdditionEqual(tempVector3);
				return this.CheckIntoWater(tempStartPoint, tempEndPoint);
			}
		}
		global::Vector tempVector4 = this.TempVector;
		this.ActorComp.ActorUpProxy.Multiply((double)this.CharacterHalfHeight, tempVector4);
		this.ActorComp.ActorLocationProxy.Addition(tempVector4, tempStartPoint);
		this.ActorComp.ActorLocationProxy.Subtraction(tempVector4, tempEndPoint);
		return this.CheckIntoWater(tempStartPoint, tempEndPoint);
	}

	// Token: 0x06019849 RID: 104521 RVA: 0x007652EC File Offset: 0x007634EC
	private bool CheckWaterEdge()
	{
		global::Vector tempVector = this.TempVector;
		this.ActorComp.ActorUpProxy.Multiply((double)this.CharacterHalfHeight, tempVector);
		global::Vector tempStartPoint = this.TempStartPoint;
		this.ActorComp.ActorLocationProxy.Addition(tempVector, tempStartPoint);
		global::Vector tempEndPoint = this.TempEndPoint;
		this.ActorComp.ActorLocationProxy.Subtraction(tempVector, tempEndPoint);
		return this.SimpleWaterEdgeTrace(tempStartPoint, tempEndPoint);
	}

	// Token: 0x0601984A RID: 104522 RVA: 0x00765358 File Offset: 0x00763558
	private bool CheckIntoWater(global::Vector start, global::Vector end)
	{
		this.Depth = this.DetectWaterDepth(start, end);
		if (this.Depth == 0f)
		{
			return false;
		}
		Singleton<TraceElementCommon>.Instance.GetImpactNormal(this.WaterTrace.HitResult, 0, this.TempNormalPoint);
		return this.IsNormalAccepted(this.TempNormalPoint);
	}

	// Token: 0x0601984B RID: 104523 RVA: 0x007653B0 File Offset: 0x007635B0
	private float DetectWaterDepth(global::Vector start, global::Vector end)
	{
		bool flag = this.SimpleWaterTrace(start, end);
		global::Vector tempVector = this.TempVector;
		if (flag && this.WaterTrace.HitResult.bBlockingHit)
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(this.WaterTrace.HitResult, 0, tempVector);
			this.WaterHeight = (float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, tempVector);
			double num = (double)this.WaterHeight - Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.FloorLocation);
			if (num > 0.0)
			{
				return (float)num;
			}
		}
		return 0f;
	}

	// Token: 0x0601984C RID: 104524 RVA: 0x00765448 File Offset: 0x00763648
	private void FixedEnterWaterDepth(float deltaTime)
	{
		if (this.Depth < 4f)
		{
			return;
		}
		this.UpTime += (double)deltaTime * Singleton<TimeUtil>.Instance.Millisecond;
		global::Vector tempVector = this.TempVector;
		tempVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorLocationProxy);
		double num = Singleton<MathUtils>.Instance.Clamp((double)this.StartUpZ + this.UpTime * 500.0, (double)this.StartUpZ, znInGravityForActor + (double)this.Depth - 1.0);
		tempVector.AdditionEqual(this.ActorComp.ActorUpProxy.Multiply(num - znInGravityForActor, this.TempVector2));
		this.ActorComp.SetActorLocation(tempVector.ToUeVector(false), "修正在水中的Z轴", true);
	}

	// Token: 0x0601984D RID: 104525 RVA: 0x00765528 File Offset: 0x00763728
	private void EnterUpToWalkOnWater()
	{
		this.TempVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TempVector);
		this.ActorComp.SetActorVelocity(this.TempVector);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Custom,
				CustomMode = 5,
				Context = "[CharacterWalkOnWaterComponent.EnterUpToWalkOnWater]"
			});
		}
		this.UpTime = 0.0;
		this.StartUpZ = (float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorLocationProxy);
		this.OriginMaxSpeed = this.MoveComp.CharacterMovement.MaxCustomMovementSpeed;
	}

	// Token: 0x0601984E RID: 104526 RVA: 0x007655EE File Offset: 0x007637EE
	private void ExitUpToWalkOnWater()
	{
		this.MoveComp.CharacterMovement.MaxCustomMovementSpeed = this.OriginMaxSpeed;
	}

	// Token: 0x0601984F RID: 104527 RVA: 0x00765608 File Offset: 0x00763808
	private void EnterWalkOnWater()
	{
		this.TempVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TempVector);
		this.ActorComp.SetActorVelocity(this.TempVector);
		this.EnableOrDisableWalkOnWater(true, "CharWalkOnWaterComp", false);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null)
		{
			return;
		}
		actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Walking,
			Context = "[CharacterWalkOnWaterComponent.EnterWalkOnWater]"
		});
	}

	// Token: 0x06019850 RID: 104528 RVA: 0x0076568C File Offset: 0x0076388C
	private void ExitWalkOnWater(bool isBuffEnd = false)
	{
		if (isBuffEnd && this.CheckUpWaterSurface())
		{
			this.FixedEnterWaterDepth((float)Singleton<TimeUtil>.Instance.InverseMillisecond);
		}
		this.EnableOrDisableWalkOnWater(false, "CharWalkOnWaterComp", false);
	}

	// Token: 0x06019851 RID: 104529 RVA: 0x007656B8 File Offset: 0x007638B8
	private bool SimpleWaterTrace(global::Vector start, global::Vector end)
	{
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.WaterTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.WaterTrace, end);
		if (Singleton<TraceElementCommon>.Instance.SphereTrace(this.WaterTrace, "CharacterWalkOnWaterComponent_DetectWaterDepth") && this.WaterTrace.HitResult.bBlockingHit)
		{
			TWeakObjectPtr<UPrimitiveComponent> weak = this.WaterTrace.HitResult.Components.Get(0);
			int instanceIndex = this.WaterTrace.HitResult.ItemArray.Get(0);
			UKuroCollisionLibrary.GetCollisionResponseToChannel(weak, this.ActorComp.Actor.CapsuleComponent.GetCollisionObjectType(), instanceIndex);
			return true;
		}
		return false;
	}

	// Token: 0x06019852 RID: 104530 RVA: 0x00765768 File Offset: 0x00763968
	private bool SimpleWaterEdgeTrace(global::Vector start, global::Vector end)
	{
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.WaterEdgeTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.WaterEdgeTrace, end);
		return Singleton<TraceElementCommon>.Instance.SphereTrace(this.WaterEdgeTrace, "CharacterWalkOnWaterComponent_DetectWaterDepth") && this.WaterEdgeTrace.HitResult.bBlockingHit;
	}

	// Token: 0x06019853 RID: 104531 RVA: 0x007657C0 File Offset: 0x007639C0
	private void SetWalkOnWaterStage(EWalkOnWaterStage stage)
	{
		if (this.InChangeStateProcess)
		{
			this.CacheWalkOnWaterStage = new EWalkOnWaterStage?(stage);
			return;
		}
		if (this.WalkOnWaterStage == stage)
		{
			return;
		}
		this.InChangeStateProcess = true;
		this.ExitStage(this.WalkOnWaterStage);
		this.EnterStage(stage);
		this.InChangeStateProcess = false;
		if (this.CacheWalkOnWaterStage != null)
		{
			EWalkOnWaterStage? cacheWalkOnWaterStage = this.CacheWalkOnWaterStage;
			EWalkOnWaterStage walkOnWaterStage = this.WalkOnWaterStage;
			if (!(cacheWalkOnWaterStage.GetValueOrDefault() == walkOnWaterStage & cacheWalkOnWaterStage != null))
			{
				this.ExitStage(stage);
				this.EnterStage(this.CacheWalkOnWaterStage.Value);
				this.CacheWalkOnWaterStage = null;
			}
		}
	}

	// Token: 0x06019854 RID: 104532 RVA: 0x00765860 File Offset: 0x00763A60
	private void EnterStage(EWalkOnWaterStage newStage)
	{
		this.WalkOnWaterStage = newStage;
		switch (newStage)
		{
		case EWalkOnWaterStage.None:
		{
			this.SetWaterDepthType(EWaterDepthType.None);
			CharacterFloatingComponent floatingComp = this.FloatingComp;
			if (floatingComp != null && floatingComp.IsFloating)
			{
				this.FloatingComp.ExternalEnterFloatingState();
				return;
			}
			if (this.MoveComp.CharacterMovement.MovementMode != EMovementMode.MOVE_Flying && (!(this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Custom) || this.MoveComp.CharacterMovement.CustomMovementMode != 6))
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp == null || !actorComp.Actor.OnMovementModeChanged)
				{
					CharacterActorComponent actorComp2 = this.ActorComp;
					if (actorComp2 == null)
					{
						return;
					}
					actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						Context = "[CharacterWalkOnWaterComponent.EnterStage]"
					});
				}
			}
			return;
		}
		case EWalkOnWaterStage.UpToWaterSurface:
			this.EnterUpToWalkOnWater();
			return;
		case EWalkOnWaterStage.WalkOnWaterSurface:
			this.EnterWalkOnWater();
			return;
		default:
			return;
		}
	}

	// Token: 0x06019855 RID: 104533 RVA: 0x00765951 File Offset: 0x00763B51
	private void ExitStage(EWalkOnWaterStage oldStage)
	{
		switch (oldStage)
		{
		case EWalkOnWaterStage.None:
			this.StateComp.SetPositionSubState(ECharPositionSubState.WaterSurface, false);
			return;
		case EWalkOnWaterStage.UpToWaterSurface:
			this.ExitUpToWalkOnWater();
			return;
		case EWalkOnWaterStage.WalkOnWaterSurface:
			this.ExitWalkOnWater(!this.IsActive);
			return;
		default:
			return;
		}
	}

	// Token: 0x06019856 RID: 104534 RVA: 0x0076598C File Offset: 0x00763B8C
	private void TickWalkOnWaterStage(float deltaTime)
	{
		switch (this.WalkOnWaterStage)
		{
		case EWalkOnWaterStage.None:
		case EWalkOnWaterStage.WalkOnWaterSurface:
			break;
		case EWalkOnWaterStage.UpToWaterSurface:
			this.FixedEnterWaterDepth(deltaTime);
			break;
		default:
			return;
		}
	}

	// Token: 0x06019857 RID: 104535 RVA: 0x007659BC File Offset: 0x00763BBC
	protected override void OnTick(float deltaTime)
	{
		EWalkOnWaterStage walkOnWaterStage = EWalkOnWaterStage.None;
		if (this.CheckEnterWater())
		{
			if (this.Depth < 4f)
			{
				walkOnWaterStage = EWalkOnWaterStage.WalkOnWaterSurface;
			}
			else
			{
				walkOnWaterStage = EWalkOnWaterStage.UpToWaterSurface;
			}
		}
		else if (this.CheckUpWaterSurface())
		{
			walkOnWaterStage = EWalkOnWaterStage.UpToWaterSurface;
		}
		else if (this.WalkOnWaterStage != EWalkOnWaterStage.None)
		{
			if (!this.CheckWaterEdge())
			{
				walkOnWaterStage = EWalkOnWaterStage.None;
			}
			else
			{
				walkOnWaterStage = EWalkOnWaterStage.WalkOnWaterSurface;
			}
		}
		this.SetWalkOnWaterStage(walkOnWaterStage);
		this.TickWalkOnWaterStage(deltaTime);
		if (this.WalkOnWaterStage == EWalkOnWaterStage.None)
		{
			this.CheckInGroundTime -= deltaTime;
			if (this.CheckInGroundTime < 0f)
			{
				this.CheckInGroundTime = 1000f;
				CharacterUnifiedStateComponent stateComp = this.StateComp;
				if (stateComp != null && stateComp.PositionState == ECharPositionState.Ground)
				{
					CharacterUnifiedStateComponent stateComp2 = this.StateComp;
					if (stateComp2 != null && stateComp2.PositionSubState == ECharPositionSubState.WaterSurface)
					{
						this.StateComp.SetPositionSubState(ECharPositionSubState.None, false);
					}
				}
			}
		}
		else
		{
			this.CheckWaterDepthType(deltaTime);
		}
		this.PrePlayerLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
	}

	// Token: 0x06019858 RID: 104536 RVA: 0x00765AA0 File Offset: 0x00763CA0
	private void CheckWaterDepthType(float deltaTime)
	{
		global::Vector tempStartPoint = this.TempStartPoint;
		tempStartPoint.DeepCopy(this.ActorComp.ActorLocationProxy);
		if ((double)this.WaterHeight > Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, tempStartPoint) - (double)this.ActorComp.HalfHeight)
		{
			double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorLocationProxy);
			tempStartPoint.AdditionEqual(this.ActorComp.ActorUpProxy.Multiply((double)this.WaterHeight - znInGravityForActor, this.TempVector2));
		}
		else
		{
			tempStartPoint.AdditionEqual(this.ActorComp.ActorUpProxy.Multiply((double)(-(double)this.ActorComp.HalfHeight), this.TempVector2));
		}
		global::Vector tempEndPoint = this.TempEndPoint;
		global::Vector tempVector = this.TempVector;
		this.ActorComp.ActorUpProxy.Multiply((double)(this.CharacterHalfHeight * 1.5f), tempVector);
		tempStartPoint.Subtraction(tempVector, tempEndPoint);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.GroundTrace, tempStartPoint);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.GroundTrace, tempEndPoint);
		bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.GroundTrace, "CharacterWalkOnWaterComponent_DetectWaterDepth");
		global::Vector tempVector2 = this.TempVector2;
		if (!flag || !this.GroundTrace.HitResult.bBlockingHit)
		{
			this.CheckWaterNormal(deltaTime);
			this.SetWaterDepthType(EWaterDepthType.Deep);
			return;
		}
		int hitCount = this.GroundTrace.HitResult.GetHitCount();
		bool flag2 = false;
		float num = float.NegativeInfinity;
		TArray<TWeakObjectPtr<AActor>> actors = this.GroundTrace.HitResult.Actors;
		TArray<TWeakObjectPtr<UPrimitiveComponent>> components = this.GroundTrace.HitResult.Components;
		for (int i = 0; i < hitCount; i++)
		{
			TWeakObjectPtr<AActor> tweakObjectPtr = actors.Get(i);
			TWeakObjectPtr<UPrimitiveComponent> tweakObjectPtr2 = components.Get(i);
			if (tweakObjectPtr.Get() != null)
			{
				if (tweakObjectPtr.Get().bHidden)
				{
					UPrimitiveComponent uprimitiveComponent = tweakObjectPtr2.Get();
					if (uprimitiveComponent == null || !uprimitiveComponent.bCanCharacterStandOn)
					{
						goto IL_204;
					}
				}
				flag2 = true;
				Singleton<TraceElementCommon>.Instance.GetHitLocation(this.GroundTrace.HitResult, i, tempVector2);
				double znInGravityForActor2 = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, tempVector2);
				if (znInGravityForActor2 > (double)num)
				{
					num = (float)znInGravityForActor2;
				}
			}
			IL_204:;
		}
		if (!flag2)
		{
			this.CheckWaterNormal(deltaTime);
			this.SetWaterDepthType(EWaterDepthType.Deep);
			return;
		}
		if (num <= this.WaterHeight)
		{
			this.CheckWaterNormal(deltaTime);
			this.SetWaterDepthType(EWaterDepthType.Shallow);
			return;
		}
		this.BroadcastWaterDetectedEnd();
		this.SetWaterDepthType(EWaterDepthType.None);
	}

	// Token: 0x06019859 RID: 104537 RVA: 0x00765D0C File Offset: 0x00763F0C
	private void ChangeWaterDepthTypeTag(EWaterDepthType type, bool isAdd)
	{
		int? tagId = null;
		if (type == EWaterDepthType.Shallow)
		{
			tagId = new int?(GameplayTagUtils.GetTagIdByName("行为状态.水域状态.浅水区"));
		}
		else if (type == EWaterDepthType.Deep)
		{
			tagId = new int?(GameplayTagUtils.GetTagIdByName("行为状态.水域状态.深水区"));
		}
		if (tagId == null)
		{
			return;
		}
		if (isAdd)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp == null)
			{
				return;
			}
			tagComp.AddTag(tagId);
			return;
		}
		else
		{
			BaseTagComponent tagComp2 = this.TagComp;
			if (tagComp2 == null)
			{
				return;
			}
			tagComp2.RemoveTag(tagId);
			return;
		}
	}

	// Token: 0x0601985A RID: 104538 RVA: 0x00765D80 File Offset: 0x00763F80
	private void BroadcastWaterDetectedStart()
	{
		if (this.WaterDetected)
		{
			return;
		}
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null || !tagComp.HasTag(this.freeWaterStateTag))
		{
			return;
		}
		foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
		{
			waterDetectedCapability.OnWaterDetectedStart();
		}
		this.WaterDetected = true;
	}

	// Token: 0x0601985B RID: 104539 RVA: 0x00765E00 File Offset: 0x00764000
	private void BroadcastWaterDetectedEnd()
	{
		if (!this.WaterDetected)
		{
			return;
		}
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null || !tagComp.HasTag(this.freeWaterStateTag))
		{
			return;
		}
		foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
		{
			waterDetectedCapability.OnWaterDetectedEnd();
		}
		this.WaterDetected = false;
	}

	// Token: 0x0601985C RID: 104540 RVA: 0x00765E80 File Offset: 0x00764080
	private void BroadcastWaterDetectedTick(float deltaTime, global::Vector hitWaterPoint)
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null || !tagComp.HasTag(this.freeWaterStateTag) || this.ActorComp == null)
		{
			return;
		}
		foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
		{
			waterDetectedCapability.OnWaterDetectedTick(deltaTime, hitWaterPoint, this.ActorComp.ActorUpProxy);
		}
	}

	// Token: 0x0601985D RID: 104541 RVA: 0x00765F04 File Offset: 0x00764104
	private bool CheckWaterNormal(float deltaTime)
	{
		if (!this.ActorComp)
		{
			this.BroadcastWaterDetectedEnd();
			return false;
		}
		global::Vector gravityDirectForActor = Singleton<GravityUtils>.Instance.GetGravityDirectForActor(this.ActorComp);
		if (!this.WaterNormal.Normalize(9.99999993922529E-09) || !global::Vector.Parallel(this.WaterNormal, gravityDirectForActor, 0.999845027923584))
		{
			this.BroadcastWaterDetectedEnd();
			return false;
		}
		this.BroadcastWaterDetectedStart();
		this.BroadcastWaterDetectedTick(deltaTime, this.WaterImpactPoint);
		return true;
	}

	// Token: 0x0601985E RID: 104542 RVA: 0x00765F80 File Offset: 0x00764180
	private void SetWaterDepthType(EWaterDepthType newType)
	{
		if (this.WaterDepthType == newType)
		{
			return;
		}
		this.ChangeWaterDepthTypeTag(this.WaterDepthType, false);
		this.WaterDepthType = newType;
		this.ChangeWaterDepthTypeTag(newType, true);
	}

	// Token: 0x0601985F RID: 104543 RVA: 0x00765FA8 File Offset: 0x007641A8
	public void EnableOrDisableWalkOnWater(bool enable, string key, bool fixLocation = false)
	{
		if (enable)
		{
			if (!this.WalkOnWaterSet.Contains(key))
			{
				if (this.WalkOnWaterSet.Count == 0)
				{
					UCapsuleComponent capsuleComponent = this.ActorComp.Actor.CapsuleComponent;
					if (capsuleComponent != null)
					{
						capsuleComponent.SetCollisionResponseToChannel(KuroCollisionChannel.KuroWater, ECollisionResponse.ECR_Block);
					}
					if (fixLocation)
					{
						ValueTuple<bool, global::Vector> valueTuple = this.ActorComp.FixActorLocation(0f, true, this.ActorComp.ActorLocationProxy, "WalkOnWater", true, false);
						bool item = valueTuple.Item1;
						global::Vector item2 = valueTuple.Item2;
						if (item)
						{
							CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
							if (component != null)
							{
								component.SetLocationAndRotatorWithModelBuffer(item2.ToUeVector(false), this.ActorComp.ActorRotation, 300f, "WalkOnWater.FixLocation", ESetRotationPriority.Anim, false);
							}
							else
							{
								this.ActorComp.SetActorLocation(item2.ToUeVector(false), "WalkOnWater.FixLocation", false);
							}
						}
					}
				}
				this.WalkOnWaterSet.Add(key);
				return;
			}
		}
		else
		{
			this.WalkOnWaterSet.Remove(key);
			if (this.WalkOnWaterSet.Count == 0)
			{
				this.ActorComp.Actor.CapsuleComponent.SetCollisionResponseToChannel(KuroCollisionChannel.KuroWater, this.OriginChannelResponse.GetValueOrDefault(ECollisionResponse.ECR_Overlap));
			}
		}
	}

	// Token: 0x06019860 RID: 104544 RVA: 0x007660D4 File Offset: 0x007642D4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterWalkOnWaterComponent characterWalkOnWaterComponent = (CharacterWalkOnWaterComponent)componentTemplate;
		if (base.CanResetComponentProperty("freeWaterStateTag"))
		{
			this.freeWaterStateTag = characterWalkOnWaterComponent.freeWaterStateTag;
		}
		if (base.CanResetComponentProperty("IsDebug"))
		{
			this.IsDebug = characterWalkOnWaterComponent.IsDebug;
		}
		if (base.CanResetComponentProperty("WaterUpTrace"))
		{
			if (characterWalkOnWaterComponent.WaterUpTrace == null)
			{
				this.WaterUpTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceLineElement>(this.WaterUpTrace), "WaterUpTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GroundTrace"))
		{
			if (characterWalkOnWaterComponent.GroundTrace == null)
			{
				this.GroundTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.GroundTrace), "GroundTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WaterTrace"))
		{
			if (characterWalkOnWaterComponent.WaterTrace == null)
			{
				this.WaterTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.WaterTrace), "WaterTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WaterEdgeTrace"))
		{
			if (characterWalkOnWaterComponent.WaterEdgeTrace == null)
			{
				this.WaterEdgeTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.WaterEdgeTrace), "WaterEdgeTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterWalkOnWaterComponent.ActorComp == null)
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
			if (characterWalkOnWaterComponent.TagComp == null)
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
			if (characterWalkOnWaterComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (characterWalkOnWaterComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FloatingComp"))
		{
			if (characterWalkOnWaterComponent.FloatingComp == null)
			{
				this.FloatingComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterFloatingComponent>(this.FloatingComp), "FloatingComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnGameplayTagNewOrRemove"))
		{
			if (characterWalkOnWaterComponent.OnGameplayTagNewOrRemove == null)
			{
				this.OnGameplayTagNewOrRemove = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnGameplayTagNewOrRemove), "OnGameplayTagNewOrRemove"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnFreezeWaterTagAddOrRemove"))
		{
			if (characterWalkOnWaterComponent.OnFreezeWaterTagAddOrRemove == null)
			{
				this.OnFreezeWaterTagAddOrRemove = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnFreezeWaterTagAddOrRemove), "OnFreezeWaterTagAddOrRemove"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsActive"))
		{
			this.IsActive = characterWalkOnWaterComponent.IsActive;
		}
		if (base.CanResetComponentProperty("CharacterHalfHeight"))
		{
			this.CharacterHalfHeight = characterWalkOnWaterComponent.CharacterHalfHeight;
		}
		if (base.CanResetComponentProperty("TempVector"))
		{
			if (characterWalkOnWaterComponent.TempVector == null)
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
			if (characterWalkOnWaterComponent.TempVector2 == null)
			{
				this.TempVector2 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector2), "TempVector2"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempStartPoint"))
		{
			if (characterWalkOnWaterComponent.TempStartPoint == null)
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
			if (characterWalkOnWaterComponent.TempEndPoint == null)
			{
				this.TempEndPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempEndPoint), "TempEndPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Depth"))
		{
			this.Depth = characterWalkOnWaterComponent.Depth;
		}
		if (base.CanResetComponentProperty("OriginMaxSpeed"))
		{
			this.OriginMaxSpeed = characterWalkOnWaterComponent.OriginMaxSpeed;
		}
		if (base.CanResetComponentProperty("PrePlayerLocation") && characterWalkOnWaterComponent.PrePlayerLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.PrePlayerLocation), "PrePlayerLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempNormalPoint"))
		{
			if (characterWalkOnWaterComponent.TempNormalPoint == null)
			{
				this.TempNormalPoint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempNormalPoint), "TempNormalPoint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WalkOnWaterStage"))
		{
			this.WalkOnWaterStage = characterWalkOnWaterComponent.WalkOnWaterStage;
		}
		if (base.CanResetComponentProperty("WaterDepthType"))
		{
			this.WaterDepthType = characterWalkOnWaterComponent.WaterDepthType;
		}
		if (base.CanResetComponentProperty("OriginChannelResponse"))
		{
			this.OriginChannelResponse = characterWalkOnWaterComponent.OriginChannelResponse;
		}
		if (base.CanResetComponentProperty("InChangeStateProcess"))
		{
			this.InChangeStateProcess = characterWalkOnWaterComponent.InChangeStateProcess;
		}
		if (base.CanResetComponentProperty("CacheWalkOnWaterStage"))
		{
			this.CacheWalkOnWaterStage = characterWalkOnWaterComponent.CacheWalkOnWaterStage;
		}
		if (base.CanResetComponentProperty("WaterHeight"))
		{
			this.WaterHeight = characterWalkOnWaterComponent.WaterHeight;
		}
		if (base.CanResetComponentProperty("WalkOnWaterSet") && characterWalkOnWaterComponent.WalkOnWaterSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<string>(this.WalkOnWaterSet), "WalkOnWaterSet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("DisableKey"))
		{
			this.DisableKey = characterWalkOnWaterComponent.DisableKey;
		}
		if (base.CanResetComponentProperty("FreezeWaterRenderCapability"))
		{
			if (characterWalkOnWaterComponent.FreezeWaterRenderCapability == null)
			{
				this.FreezeWaterRenderCapability = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<WaterDetectedCapability>(this.FreezeWaterRenderCapability), "FreezeWaterRenderCapability"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MovementTrailCollisionCapability"))
		{
			if (characterWalkOnWaterComponent.MovementTrailCollisionCapability == null)
			{
				this.MovementTrailCollisionCapability = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<WaterDetectedCapability>(this.MovementTrailCollisionCapability), "MovementTrailCollisionCapability"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GameCapabilities") && characterWalkOnWaterComponent.GameCapabilities != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<WaterDetectedCapability>>(this.GameCapabilities), "GameCapabilities"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InteractionComp"))
		{
			if (characterWalkOnWaterComponent.InteractionComp == null)
			{
				this.InteractionComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroEnviInteractionComponent>(this.InteractionComp), "InteractionComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WaterDetected"))
		{
			this.WaterDetected = characterWalkOnWaterComponent.WaterDetected;
		}
		if (base.CanResetComponentProperty("WaterNormal") && characterWalkOnWaterComponent.WaterNormal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.WaterNormal), "WaterNormal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("WaterImpactPoint") && characterWalkOnWaterComponent.WaterImpactPoint != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.WaterImpactPoint), "WaterImpactPoint"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("StartUpZ"))
		{
			this.StartUpZ = characterWalkOnWaterComponent.StartUpZ;
		}
		if (base.CanResetComponentProperty("UpTime"))
		{
			this.UpTime = characterWalkOnWaterComponent.UpTime;
		}
		if (base.CanResetComponentProperty("CheckInGroundTime"))
		{
			this.CheckInGroundTime = characterWalkOnWaterComponent.CheckInGroundTime;
		}
		return true;
	}

	// Token: 0x0400CA8E RID: 51854
	private const float COS_EIGHTY = 0.173f;

	// Token: 0x0400CA8F RID: 51855
	private const string PROFILE_DETECT_WATER_DEPTH = "CharacterWalkOnWaterComponent_DetectWaterDepth";

	// Token: 0x0400CA90 RID: 51856
	private const string PROFILE_DETECT_WATER_UP_BLOCK = "CharacterWalkOnWaterComponent_WaterUpBlock";

	// Token: 0x0400CA91 RID: 51857
	private const int ENTER_WALK_ON_WATER_DEPTH = 4;

	// Token: 0x0400CA92 RID: 51858
	private const int PRE_FRAME_POSITION_MAX_DISTANCE = 1000;

	// Token: 0x0400CA93 RID: 51859
	private const int PRE_FRAME_POSITION_MAX_DISTANCE_SQUARED = 1000000;

	// Token: 0x0400CA94 RID: 51860
	private const int UP_TO_WATER_SURFACE_SPEED = 500;

	// Token: 0x0400CA95 RID: 51861
	private const int CHECK_IN_GROUND_INTERVAL = 1000;

	// Token: 0x0400CA96 RID: 51862
	private const int FIVE_HUNDRED_TO_FIND_SURFACE = 1000;

	// Token: 0x0400CA97 RID: 51863
	private const int WALK_ON_WATER_HALF_HEIGHT_OFFSET = 3;

	// Token: 0x0400CA98 RID: 51864
	private const int WALK_ON_WATER_RADIUS_OFFSET = 20;

	// Token: 0x0400CA99 RID: 51865
	private const int WALK_ON_WATER_MOVEDIR_OFFSET = 3;

	// Token: 0x0400CA9A RID: 51866
	private const int MODEL_BUFFER_TIME_LENGTH = 300;

	// Token: 0x0400CA9B RID: 51867
	private const float SHALLOW_WATER_THRESOLD = 1.5f;

	// Token: 0x0400CA9C RID: 51868
	private int freeWaterStateTag = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冻结水面"];

	// Token: 0x0400CA9D RID: 51869
	public bool IsDebug;

	// Token: 0x0400CA9E RID: 51870
	[Nullable(2)]
	private UTraceLineElement WaterUpTrace;

	// Token: 0x0400CA9F RID: 51871
	[Nullable(2)]
	private UTraceSphereElement GroundTrace;

	// Token: 0x0400CAA0 RID: 51872
	[Nullable(2)]
	private UTraceSphereElement WaterTrace;

	// Token: 0x0400CAA1 RID: 51873
	[Nullable(2)]
	private UTraceSphereElement WaterEdgeTrace;

	// Token: 0x0400CAA2 RID: 51874
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CAA3 RID: 51875
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400CAA4 RID: 51876
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400CAA5 RID: 51877
	[Nullable(2)]
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400CAA6 RID: 51878
	[Nullable(2)]
	private CharacterFloatingComponent FloatingComp;

	// Token: 0x0400CAA7 RID: 51879
	[Nullable(2)]
	private ITagTask OnGameplayTagNewOrRemove;

	// Token: 0x0400CAA8 RID: 51880
	[Nullable(2)]
	private ITagTask OnFreezeWaterTagAddOrRemove;

	// Token: 0x0400CAA9 RID: 51881
	public bool IsActive;

	// Token: 0x0400CAAA RID: 51882
	private float CharacterHalfHeight;

	// Token: 0x0400CAAB RID: 51883
	[Nullable(2)]
	private global::Vector TempVector;

	// Token: 0x0400CAAC RID: 51884
	[Nullable(2)]
	private global::Vector TempVector2;

	// Token: 0x0400CAAD RID: 51885
	[Nullable(2)]
	private global::Vector TempStartPoint;

	// Token: 0x0400CAAE RID: 51886
	[Nullable(2)]
	private global::Vector TempEndPoint;

	// Token: 0x0400CAAF RID: 51887
	private float Depth;

	// Token: 0x0400CAB0 RID: 51888
	private float OriginMaxSpeed;

	// Token: 0x0400CAB1 RID: 51889
	private readonly global::Vector PrePlayerLocation = global::Vector.Create();

	// Token: 0x0400CAB2 RID: 51890
	[Nullable(2)]
	private global::Vector TempNormalPoint;

	// Token: 0x0400CAB3 RID: 51891
	public EWalkOnWaterStage WalkOnWaterStage;

	// Token: 0x0400CAB4 RID: 51892
	public EWaterDepthType WaterDepthType;

	// Token: 0x0400CAB5 RID: 51893
	private ECollisionResponse? OriginChannelResponse;

	// Token: 0x0400CAB6 RID: 51894
	private bool InChangeStateProcess;

	// Token: 0x0400CAB7 RID: 51895
	private EWalkOnWaterStage? CacheWalkOnWaterStage;

	// Token: 0x0400CAB8 RID: 51896
	private float WaterHeight;

	// Token: 0x0400CAB9 RID: 51897
	private readonly HashSet<string> WalkOnWaterSet = new HashSet<string>();

	// Token: 0x0400CABA RID: 51898
	private int DisableKey;

	// Token: 0x0400CABB RID: 51899
	[Nullable(2)]
	private WaterDetectedCapability FreezeWaterRenderCapability;

	// Token: 0x0400CABC RID: 51900
	[Nullable(2)]
	private WaterDetectedCapability MovementTrailCollisionCapability;

	// Token: 0x0400CABD RID: 51901
	private readonly List<WaterDetectedCapability> GameCapabilities = new List<WaterDetectedCapability>();

	// Token: 0x0400CABE RID: 51902
	[Nullable(2)]
	private UKuroEnviInteractionComponent InteractionComp;

	// Token: 0x0400CABF RID: 51903
	private bool WaterDetected;

	// Token: 0x0400CAC0 RID: 51904
	private readonly global::Vector WaterNormal = global::Vector.Create();

	// Token: 0x0400CAC1 RID: 51905
	private readonly global::Vector WaterImpactPoint = global::Vector.Create();

	// Token: 0x0400CAC2 RID: 51906
	private float StartUpZ;

	// Token: 0x0400CAC3 RID: 51907
	private double UpTime;

	// Token: 0x0400CAC4 RID: 51908
	private float CheckInGroundTime = 1000f;
}
