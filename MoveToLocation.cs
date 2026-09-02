using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

// Token: 0x020030DE RID: 12510
[NullableContext(1)]
[Nullable(0)]
public class MoveToLocation
{
	// Token: 0x06019D4F RID: 105807 RVA: 0x0078CFD5 File Offset: 0x0078B1D5
	[NullableContext(2)]
	public Vector GetCurrentMoveToLocation()
	{
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		return ((moveToLocationConfig != null) ? moveToLocationConfig.Position : null) ?? null;
	}

	// Token: 0x06019D50 RID: 105808 RVA: 0x0078CFEE File Offset: 0x0078B1EE
	public void UpdateConfigMoveState(ECharMoveState? state)
	{
		if (this.MoveToLocationConfig == null)
		{
			return;
		}
		this.MoveToLocationConfig.MoveState = state;
	}

	// Token: 0x06019D51 RID: 105809 RVA: 0x0078D008 File Offset: 0x0078B208
	[NullableContext(2)]
	public Vector GetLastMoveToLocation()
	{
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		Vector vector = (moveToLocationConfig != null) ? moveToLocationConfig.Position : null;
		MoveToPointConfig moveToLocationConfig2 = this.MoveToLocationConfig;
		bool flag;
		if (moveToLocationConfig2 == null)
		{
			flag = true;
		}
		else
		{
			Queue<Vector> nextMovePointConfig = moveToLocationConfig2.NextMovePointConfig;
			flag = !((nextMovePointConfig != null) ? new bool?(nextMovePointConfig.Empty) : null).GetValueOrDefault();
		}
		if (flag)
		{
			MoveToPointConfig moveToLocationConfig3 = this.MoveToLocationConfig;
			Vector vector2;
			if (moveToLocationConfig3 == null)
			{
				vector2 = null;
			}
			else
			{
				Queue<Vector> nextMovePointConfig2 = moveToLocationConfig3.NextMovePointConfig;
				vector2 = ((nextMovePointConfig2 != null) ? nextMovePointConfig2.Get(this.MoveToLocationConfig.NextMovePointConfig.Size - 1) : null);
			}
			vector = vector2;
		}
		return vector ?? null;
	}

	// Token: 0x06019D52 RID: 105810 RVA: 0x0078D098 File Offset: 0x0078B298
	public float GetCurrentDistance()
	{
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		if (moveToLocationConfig != null && moveToLocationConfig.HasNextPoint())
		{
			Vector lastMoveToLocation = this.GetLastMoveToLocation();
			if (lastMoveToLocation != null)
			{
				return (float)((this.MoveToLocationConfig.IsFly != null && this.MoveToLocationConfig.IsFly.Value) ? Vector.Dist(this.ActorComp.ActorLocationProxy, lastMoveToLocation) : Vector.Dist2D(this.ActorComp.ActorLocationProxy, lastMoveToLocation));
			}
		}
		return this.CurrentDistance;
	}

	// Token: 0x06019D53 RID: 105811 RVA: 0x0078D11C File Offset: 0x0078B31C
	public void Init(Entity entity)
	{
		this.Entity = entity;
		this.ActorComp = this.Entity.GetComponent<CharacterActorComponent>();
		this.StateComp = this.Entity.GetComponent<BaseUnifiedStateComponent>();
		this.AnimComp = this.Entity.GetComponent<CharacterAnimationComponent>();
		this.PbDataId = this.ActorComp.CreatureData.GetPbDataId();
	}

	// Token: 0x06019D54 RID: 105812 RVA: 0x0078D179 File Offset: 0x0078B379
	[NullableContext(2)]
	public bool SetMoveToLocation(IMoveToPointConfig location)
	{
		if (location == null)
		{
			return false;
		}
		this.Clear();
		this.UpdateMoveToLocationConfig(location);
		return true;
	}

	// Token: 0x06019D55 RID: 105813 RVA: 0x0078D190 File Offset: 0x0078B390
	public void UpdateMove(float deltaSeconds)
	{
		if (this.MoveToLocationConfig == null)
		{
			return;
		}
		if (MoveToLocationController.DebugDraw && GlobalData.IsPlayInEditor)
		{
			this.DrawDebug();
		}
		this.DeltaTime += deltaSeconds;
		if (this.DeltaTime > 1f)
		{
			this.DeltaTime = 0f;
			this.UpdateMoveStateAndSpeed();
		}
		bool flag = this.UpdateMoveToDirection();
		if (!flag && this.TickProcessId == 0 && this.ShouldForceResetForLargeDelta(deltaSeconds))
		{
			this.TickProcessId = Singleton<TickProcessSystem>.Instance.RegisterOnceTickProcess(ETickingGroup.TG_PrePhysics, true, delegate(float delta)
			{
				this.TickProcessId = 0;
				this.ResetPullbackLocation();
			});
			return;
		}
		if (flag)
		{
			if (this.ResetLastPointCondition() && (this.MoveToLocationConfig.ResetCondition == null || this.MoveToLocationConfig.ResetCondition()))
			{
				this.ResetLastPatrolPoint(deltaSeconds);
			}
			this.MoveEnd(ELevelEventState.Success);
			return;
		}
		float? returnTimeoutFailed = this.MoveToLocationConfig.ReturnTimeoutFailed;
		float num = 0.0001f;
		if (returnTimeoutFailed.GetValueOrDefault() > num & returnTimeoutFailed != null)
		{
			this.CheckTimeout(deltaSeconds);
		}
	}

	// Token: 0x06019D56 RID: 105814 RVA: 0x0078D288 File Offset: 0x0078B488
	public void ResetPullbackLocation()
	{
		if (this.TickProcessId != 0)
		{
			return;
		}
		this.MoveToLocationConfig.UpdateTargetPosition();
		this.LastPatrolPoint.DeepCopy(this.MoveToLocationConfig.Position);
		this.ResetLastPatrolPoint(Singleton<Time>.Instance.DeltaTime * 0.001f);
		this.MoveEnd(ELevelEventState.Success);
	}

	// Token: 0x06019D57 RID: 105815 RVA: 0x0078D2DD File Offset: 0x0078B4DD
	public void Dispose()
	{
		this.StopMove(null);
	}

	// Token: 0x06019D58 RID: 105816 RVA: 0x0078D2E8 File Offset: 0x0078B4E8
	private unsafe void CheckTimeout(float deltaSeconds)
	{
		if ((float)Math.Sqrt(Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(this.ActorComp, this.ActorComp.ActorLocationProxy, this.ActorComp.LastActorLocation)) / deltaSeconds > 30f)
		{
			this.CurTimeoutTime = this.MoveToLocationConfig.ReturnTimeoutFailed.Value;
			return;
		}
		this.CurTimeoutTime -= deltaSeconds;
		if (this.CurTimeoutTime <= 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "检测到移动行为不符合预期,持续卡住超时,返回移动失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("超时时限", this.MoveToLocationConfig.ReturnTimeoutFailed);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.MoveEnd(ELevelEventState.Failure);
		}
	}

	// Token: 0x06019D59 RID: 105817 RVA: 0x0078D3FC File Offset: 0x0078B5FC
	protected bool UpdateMoveToDirection()
	{
		this.UpdateCurrentTargetVector();
		if (this.CheckExceedTargetPoint())
		{
			return true;
		}
		this.DirectionVector.Normalize(9.99999993922529E-09);
		if (this.StateComp != null && this.StateComp.PositionState == ECharPositionState.Climb)
		{
			MoveToLocation.CacheQuat.DeepCopy(this.ActorComp.ActorQuatProxy);
			MoveToLocation.CacheQuat.Inverse(MoveToLocation.CacheQuat);
			MoveToLocation.CacheQuat.RotateVector(this.DirectionVector, this.DirectionVector);
			double x = this.DirectionVector.X;
			this.DirectionVector.X = this.DirectionVector.Z;
			this.DirectionVector.Z = x;
			this.ActorComp.SetInputDirect(this.DirectionVector, false);
			return false;
		}
		float? turnSpeed = this.MoveToLocationConfig.TurnSpeed;
		Entity entity = this.Entity;
		float? overrideTurnSpeed = turnSpeed * (float)((entity != null) ? entity.GetTickInterval() : 1);
		this.ActorComp.SetOverrideTurnSpeed(overrideTurnSpeed);
		if (this.StateComp != null && this.StateComp.MoveState == ECharMoveState.Walk)
		{
			MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
			if (moveToLocationConfig == null || !moveToLocationConfig.IsForward.GetValueOrDefault())
			{
				if (this.MoveToLocationConfig.FaceToPosition != null)
				{
					MoveToLocation.CacheVector3.DeepCopy(this.MoveToLocationConfig.FaceToPosition);
					MoveToLocation.CacheVector3.SubtractionEqual(this.ActorComp.ActorLocationProxy);
				}
				AiControllerLibrary.InputNearestDirection(this.ActorComp, this.DirectionVector, MoveToLocation.CacheQuat, MoveToLocation.CacheVector2, this.MoveToLocationConfig.TurnSpeed.Value, this.MoveToLocationConfig.UseNearestDirection.GetValueOrDefault(), (this.MoveToLocationConfig.FaceToPosition != null) ? MoveToLocation.CacheVector3 : null);
				return false;
			}
		}
		AiControllerLibrary.TurnToDirect(this.ActorComp, this.DirectionVector, overrideTurnSpeed.Value, this.MoveToLocationConfig.IsFly.GetValueOrDefault(), 0f);
		this.ActorComp.SetInputDirect(this.ActorComp.ActorForwardProxy, false);
		return false;
	}

	// Token: 0x06019D5A RID: 105818 RVA: 0x0078D62D File Offset: 0x0078B82D
	[NullableContext(2)]
	public void StopMove(string context = null)
	{
		if (this.MoveToLocationConfig == null)
		{
			return;
		}
		this.Clear();
		this.ActorComp.ClearInput(false, true);
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		if (moveToLocationConfig != null)
		{
			moveToLocationConfig.Clear();
		}
		this.MoveToLocationConfig = null;
	}

	// Token: 0x06019D5B RID: 105819 RVA: 0x0078D664 File Offset: 0x0078B864
	public void MoveEnd(ELevelEventState state)
	{
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		if (moveToLocationConfig != null)
		{
			moveToLocationConfig.HasNextPoint();
		}
		MoveToPointConfig moveToLocationConfig2 = this.MoveToLocationConfig;
		bool? flag = (moveToLocationConfig2 != null) ? new bool?(moveToLocationConfig2.UpdateNextPoint()) : null;
		if (state == ELevelEventState.Success && flag.GetValueOrDefault())
		{
			this.CurTimeoutTime = this.MoveToLocationConfig.ReturnTimeoutFailed.GetValueOrDefault();
			this.ResetInputAndVelocity();
			return;
		}
		MoveToPointConfig moveToLocationConfig3 = this.MoveToLocationConfig;
		if (moveToLocationConfig3 != null)
		{
			moveToLocationConfig3.RunCallbackList(state);
		}
		this.Clear();
		this.StopMove(null);
		MoveToPointConfig moveToLocationConfig4 = this.MoveToLocationConfig;
		if (moveToLocationConfig4 != null)
		{
			moveToLocationConfig4.Clear();
		}
		this.MoveToLocationConfig = null;
	}

	// Token: 0x06019D5C RID: 105820 RVA: 0x0078D708 File Offset: 0x0078B908
	private void UpdateMoveToLocationConfig(IMoveToPointConfig config)
	{
		this.StartMoveLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		MoveToPointConfig moveToPointConfig = config as MoveToPointConfig;
		if (moveToPointConfig != null)
		{
			this.MoveToLocationConfig = moveToPointConfig;
		}
		else if (this.MoveToLocationConfig != null)
		{
			this.MoveToLocationConfig.DeepCopy(config);
		}
		else
		{
			this.MoveToLocationConfig = new MoveToPointConfig(config, this.PointCacheVector);
		}
		this.CurTimeoutTime = this.MoveToLocationConfig.ReturnTimeoutFailed.Value;
	}

	// Token: 0x06019D5D RID: 105821 RVA: 0x0078D77F File Offset: 0x0078B97F
	private void Clear()
	{
		this.CurTimeoutTime = 0f;
		this.StartMoveLocation.Reset();
		this.LastPatrolPoint.Reset();
	}

	// Token: 0x06019D5E RID: 105822 RVA: 0x0078D7A4 File Offset: 0x0078B9A4
	private void UpdateCurrentTargetVector()
	{
		if (this.MoveToLocationConfig.UpdateTargetPosition())
		{
			this.StartMoveLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		this.DirectionVector.DeepCopy(this.MoveToLocationConfig.Position);
		this.DirectionVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.CurrentToTargetVector.DeepCopy(this.DirectionVector);
		BaseUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null && stateComp.PositionState == ECharPositionState.Climb)
		{
			MoveToLocation.CacheVector.DeepCopy(this.DirectionVector);
			double inB = MoveToLocation.CacheVector.DotProduct(this.ActorComp.ActorForwardProxy);
			MoveToLocation.CacheVector.DeepCopy(this.ActorComp.ActorForwardProxy);
			MoveToLocation.CacheVector.MultiplyEqual(inB);
			MoveToLocation.CacheVector.UnaryNegation(MoveToLocation.CacheVector);
			MoveToLocation.CacheVector.AdditionEqual(this.DirectionVector);
			this.DirectionVector.DeepCopy(MoveToLocation.CacheVector);
		}
		else if (!this.MoveToLocationConfig.IsFly.GetValueOrDefault())
		{
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, this.DirectionVector, 0.0);
		}
		this.CurrentDistance = (float)((this.MoveToLocationConfig.IsFly != null && this.MoveToLocationConfig.IsFly.Value) ? this.CurrentToTargetVector.Size() : ((double)((float)Math.Sqrt(Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(this.ActorComp, this.CurrentToTargetVector)))));
	}

	// Token: 0x06019D5F RID: 105823 RVA: 0x0078D934 File Offset: 0x0078BB34
	private bool CheckExceedTargetPoint()
	{
		double num = (double)this.CurrentDistance;
		double? distance = this.MoveToLocationConfig.Distance;
		if (num <= distance.GetValueOrDefault() & distance != null)
		{
			return true;
		}
		this.MoveToLocationConfig.Position.Subtraction(this.StartMoveLocation, MoveToLocation.CacheVector);
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, MoveToLocation.CacheVector, 0.0);
		MoveToLocation.CacheVector2.DeepCopy(this.CurrentToTargetVector);
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, MoveToLocation.CacheVector2, 0.0);
		double num2 = MoveToLocation.CacheVector2.DotProduct(MoveToLocation.CacheVector);
		if (num2 < 0.0)
		{
			this.UpdateLastActorLocation();
		}
		return num2 < 0.0;
	}

	// Token: 0x06019D60 RID: 105824 RVA: 0x0078DA00 File Offset: 0x0078BC00
	private void UpdateMoveStateAndSpeed()
	{
		BaseMoveComponent component = this.Entity.GetComponent<BaseMoveComponent>();
		if (component == null)
		{
			return;
		}
		float? moveSpeed = this.MoveToLocationConfig.MoveSpeed;
		if (this.MoveToLocationConfig.IsFly.GetValueOrDefault())
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Flying,
					Context = "[MoveToLocation.UpdateMoveStateAndSpeed]"
				});
			}
			if (moveSpeed != null)
			{
				component.SetMaxSpeed(moveSpeed.Value);
			}
			return;
		}
		if (moveSpeed != null)
		{
			component.SetMaxSpeed(moveSpeed.Value);
		}
		ECharMoveState? moveState = this.MoveToLocationConfig.MoveState;
		if (moveState != null)
		{
			this.StateComp.SetMoveState(moveState.Value);
		}
	}

	// Token: 0x06019D61 RID: 105825 RVA: 0x0078DABF File Offset: 0x0078BCBF
	private void UpdateLastActorLocation()
	{
		this.MoveToLocationConfig.UpdateTargetPosition();
		this.LastPatrolPoint.DeepCopy(this.MoveToLocationConfig.Position);
	}

	// Token: 0x06019D62 RID: 105826 RVA: 0x0078DAE4 File Offset: 0x0078BCE4
	private void ResetLastPatrolPoint(float deltaSeconds)
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.ConsumeExtractedRootMotion(1f);
			}
		}
		this.ActorComp.ClearInput(false, true);
		if (this.AnimComp != null && this.Entity.GetTickInterval() > 1)
		{
			FTransformDouble meshTransform = this.AnimComp.GetMeshTransform();
			this.SetLocationAndRotation();
			this.AnimComp.SetModelBuffer(meshTransform, deltaSeconds * 1000f * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		}
		else
		{
			this.SetLocationAndRotation();
		}
		this.LastPatrolPoint.Set(0.0, 0.0, 0.0);
	}

	// Token: 0x06019D63 RID: 105827 RVA: 0x0078DB94 File Offset: 0x0078BD94
	private unsafe void SetLocationAndRotation()
	{
		if (this.MoveToLocationConfig.IsFly.GetValueOrDefault())
		{
			this.ActorComp.SetActorLocation(this.LastPatrolPoint.ToUeVector(false), "拉回目标点设置坐标", false);
			return;
		}
		if (!this.ActorComp.FixBornLocation("拉回目标点地面修正", true, this.LastPatrolPoint, false, true, true))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "未能检测到地面，没设置拉回目标点";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("LastPatrolPoint", this.LastPatrolPoint);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ActorLocation", this.ActorComp.ActorLocationProxy);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}

	// Token: 0x06019D64 RID: 105828 RVA: 0x0078DCAC File Offset: 0x0078BEAC
	private bool ResetLastPointCondition()
	{
		if (this.LastPatrolPoint.Size() < 1.0)
		{
			return false;
		}
		if (Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(this.ActorComp, this.LastPatrolPoint, this.ActorComp.ActorLocationProxy) < Singleton<MathUtils>.Instance.Square(this.MoveToLocationConfig.Distance.Value + 10.0))
		{
			this.LastPatrolPoint.Set(0.0, 0.0, 0.0);
			return false;
		}
		return true;
	}

	// Token: 0x06019D65 RID: 105829 RVA: 0x0078DD44 File Offset: 0x0078BF44
	private void ResetInputAndVelocity()
	{
		MoveToLocation.CacheVector.DeepCopy(this.MoveToLocationConfig.Position);
		MoveToLocation.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		if (moveToLocationConfig == null || !moveToLocationConfig.IsFly.GetValueOrDefault())
		{
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, MoveToLocation.CacheVector, 0.0);
		}
		MoveToLocation.CacheVector.Normalize(9.99999993922529E-09);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.ClearInput(false, true);
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 != null)
		{
			actorComp2.SetInputDirect(MoveToLocation.CacheVector, false);
		}
		double inB = this.ActorComp.ActorVelocityProxy.Size();
		MoveToLocation.CacheVector.MultiplyEqual(inB);
		this.ActorComp.ActorVelocityProxy.Set(MoveToLocation.CacheVector.X, MoveToLocation.CacheVector.Y, MoveToLocation.CacheVector.Z);
	}

	// Token: 0x06019D66 RID: 105830 RVA: 0x0078DE48 File Offset: 0x0078C048
	private bool ShouldForceResetForLargeDelta(float deltaSeconds)
	{
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		if (moveToLocationConfig == null || !moveToLocationConfig.ForceResetOnLargeDelta.GetValueOrDefault() || moveToLocationConfig.ReferencePosition == null)
		{
			return false;
		}
		if (this.LastPatrolPoint.Size() >= 1.0)
		{
			return false;
		}
		double num = (double)this.CurrentDistance;
		double? num2 = moveToLocationConfig.Distance + (double)10;
		if (num <= num2.GetValueOrDefault() & num2 != null)
		{
			return false;
		}
		Entity entity = this.Entity;
		return (((entity != null) ? entity.GetTickInterval() : 1) > 1 || deltaSeconds >= 0.18f) && (float)Math.Sqrt(Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(this.ActorComp, this.ActorComp.ActorLocationProxy, this.ActorComp.LastActorLocation)) >= (float)moveToLocationConfig.LargeDeltaResetMinMove.GetValueOrDefault(120);
	}

	// Token: 0x06019D67 RID: 105831 RVA: 0x0078DF4C File Offset: 0x0078C14C
	private void DrawDebug()
	{
		if (this.MoveToLocationConfig == null || !GlobalData.IsPlayInEditor)
		{
			return;
		}
		if (this.RandomColor == null)
		{
			this.RandomColor = new FLinearColor?(new FLinearColor(new Random().NextDouble() <= 0.5, new Random().NextDouble() <= 0.5, new Random().NextDouble() <= 0.5, 0f));
		}
		int segments = 10;
		int num = 30;
		MoveToPointConfig moveToLocationConfig = this.MoveToLocationConfig;
		UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, this.ActorComp.ActorLocation, (float)num, segments, this.RandomColor, 0f, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, this.MoveToLocationConfig.Position.ToUeVector(false), (float)num, segments, this.RandomColor, 0f, 0f);
		if (moveToLocationConfig.NextMovePointConfig != null)
		{
			for (int i = 0; i < moveToLocationConfig.NextMovePointConfig.Size; i++)
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, moveToLocationConfig.NextMovePointConfig.Get(i).ToUeVector(false), (float)num, segments, this.RandomColor, 0f, 0f);
			}
		}
	}

	// Token: 0x0400CEBB RID: 52923
	[Nullable(2)]
	private Entity Entity;

	// Token: 0x0400CEBC RID: 52924
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CEBD RID: 52925
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400CEBE RID: 52926
	[Nullable(2)]
	private BaseUnifiedStateComponent StateComp;

	// Token: 0x0400CEBF RID: 52927
	[StaticVariableRuleIgnore]
	private static readonly Vector CacheVector = Vector.Create();

	// Token: 0x0400CEC0 RID: 52928
	[StaticVariableRuleIgnore]
	private static readonly Vector CacheVector2 = Vector.Create();

	// Token: 0x0400CEC1 RID: 52929
	[StaticVariableRuleIgnore]
	private static readonly Vector CacheVector3 = Vector.Create();

	// Token: 0x0400CEC2 RID: 52930
	[StaticVariableRuleIgnore]
	private static readonly Quat CacheQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400CEC3 RID: 52931
	private float DeltaTime = 1f;

	// Token: 0x0400CEC4 RID: 52932
	private float CurrentDistance;

	// Token: 0x0400CEC5 RID: 52933
	private readonly Vector DirectionVector = Vector.Create();

	// Token: 0x0400CEC6 RID: 52934
	private readonly Vector CurrentToTargetVector = Vector.Create();

	// Token: 0x0400CEC7 RID: 52935
	private int PbDataId;

	// Token: 0x0400CEC8 RID: 52936
	private readonly Vector LastPatrolPoint = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400CEC9 RID: 52937
	private readonly Vector StartMoveLocation = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400CECA RID: 52938
	[Nullable(2)]
	private MoveToPointConfig MoveToLocationConfig;

	// Token: 0x0400CECB RID: 52939
	private readonly Vector PointCacheVector = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400CECC RID: 52940
	private float CurTimeoutTime;

	// Token: 0x0400CECD RID: 52941
	private int TickProcessId;

	// Token: 0x0400CECE RID: 52942
	private FLinearColor? RandomColor;
}
