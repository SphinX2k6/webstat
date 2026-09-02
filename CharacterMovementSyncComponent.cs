using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;

// Token: 0x0200305C RID: 12380
[NullableContext(1)]
[Nullable(0)]
public class CharacterMovementSyncComponent : BaseMovementSyncComponent
{
	// Token: 0x060196E6 RID: 104166 RVA: 0x00758585 File Offset: 0x00756785
	private void OnCharSkillEnd(int entityId, int skillId)
	{
		this.CurEndSkillId = (long)skillId;
	}

	// Token: 0x17002249 RID: 8777
	// (get) Token: 0x060196E7 RID: 104167 RVA: 0x0075858F File Offset: 0x0075678F
	private CharacterActorComponent CharActorComp
	{
		get
		{
			return this.ActorComp as CharacterActorComponent;
		}
	}

	// Token: 0x060196E8 RID: 104168 RVA: 0x0075859C File Offset: 0x0075679C
	public CharacterMovementSyncComponent()
	{
		this.FastMoveSampleInternal = this.ReadOnlyFastMoveSampleInfo;
	}

	// Token: 0x060196E9 RID: 104169 RVA: 0x007585D5 File Offset: 0x007567D5
	protected override bool DefaultEnableMovementSync()
	{
		return true;
	}

	// Token: 0x060196EA RID: 104170 RVA: 0x007585D8 File Offset: 0x007567D8
	protected override bool GetIsMoving()
	{
		int movementModeFromSample = this.GetMovementModeFromSample();
		double num = (double)base.Entity.TimeDilation;
		CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		float? num2 = (timeScaleComp != null) ? new float?(timeScaleComp.CurrentTimeScale) : null;
		double num3 = num * ((num2 != null) ? ((double)num2.GetValueOrDefault()) : 1.0);
		if (this.LastMovementMode == movementModeFromSample)
		{
			BaseUnifiedStateComponent unifiedComp = this.UnifiedComp;
			if ((unifiedComp == null || unifiedComp.DirectionState != ECharDirectionState.AimDirection) && !this.LastHasBaseMovement && this.GetLinearVelocityFromSample().IsZero() && this.LastLocation.Equals(this.GetLocationFromSample(), 9.999999747378752E-05) && this.LastRotation.Equals(this.GetRotationFromSample(), 0.0001f))
			{
				return this.LastTimeScale != num3;
			}
		}
		return true;
	}

	// Token: 0x060196EB RID: 104171 RVA: 0x007586B0 File Offset: 0x007568B0
	protected override bool GetImportantMove(bool moving)
	{
		int movementModeFromSample = this.GetMovementModeFromSample();
		double num = (double)base.Entity.TimeDilation;
		CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		float? num2 = (timeScaleComp != null) ? new float?(timeScaleComp.CurrentTimeScale) : null;
		double num3 = num * ((num2 != null) ? ((double)num2.GetValueOrDefault()) : 1.0);
		return this.LastMovementMode != movementModeFromSample || this.LastHasBaseMovement != this.MoveComp.HasBaseMovement || this.LastTimeScale != num3 || (!moving && this.LastMove);
	}

	// Token: 0x060196EC RID: 104172 RVA: 0x00758748 File Offset: 0x00756948
	protected override bool GetSecondaryImportantMove()
	{
		if (this.CurEndSkillId <= 0L)
		{
			MoveReplaySample lastMoveSample = this.LastMoveSample;
			int? num = (lastMoveSample != null) ? new int?(lastMoveSample.MoveState) : null;
			int moveState = (int)this.UnifiedComp.MoveState;
			return !(num.GetValueOrDefault() == moveState & num != null);
		}
		return true;
	}

	// Token: 0x060196ED RID: 104173 RVA: 0x007587A4 File Offset: 0x007569A4
	protected override void CustomAfterTickInternal(float delta)
	{
		this.UpdateFastMoveSampleBase((double)delta);
		bool flag = this.DriveVehicleComp != null && this.DriveVehicleComp.Seat >= 0;
		if (this.CacheBaseEntityHandle != null && this.TransformFromRelativeMove(this.CacheBaseEntityHandle, this.CacheRelativeLocation, this.CacheRelativeRotator, this.CacheFinalLocation, this.CacheFinalRotator))
		{
			BaseActorComponent actorComp = this.ActorComp;
			if ((actorComp == null || !actorComp.IsMoveAutonomousProxy) && !flag)
			{
				this.ActorComp.SetActorLocationAndRotation(this.CacheFinalLocation.ToUeVector(false), this.CacheFinalRotator.ToUeRotator(), "角色移动同步.添加简单位移(帧末修正相对位置)", false, null);
				this.LastRelativeMove = true;
			}
		}
		base.CustomAfterTickInternal(delta);
	}

	// Token: 0x060196EE RID: 104174 RVA: 0x0075885E File Offset: 0x00756A5E
	public override void TickReplaySamples()
	{
		if (this.DriveVehicleComp != null && this.DriveVehicleComp.Seat >= 0)
		{
			return;
		}
		base.TickReplaySamples();
	}

	// Token: 0x060196EF RID: 104175 RVA: 0x00758880 File Offset: 0x00756A80
	private void UpdateFastMoveSampleBase(double delta)
	{
		CharacterActorComponent charActorComp = this.CharActorComp;
		if (charActorComp != null && charActorComp.IsActorMoveInfoCache)
		{
			if (!this.ReadOnlyFastMoveSampleInfo.IsInit)
			{
				this.ReadOnlyFastMoveSampleInfo.IsInit = true;
				ReadOnlyFastMoveSample readOnlyFastMoveSampleInfo = this.ReadOnlyFastMoveSampleInfo;
				CharacterActorComponent charActorComp2 = this.CharActorComp;
				readOnlyFastMoveSampleInfo.Location = ((charActorComp2 != null) ? charActorComp2.ActorLocationProxy : null);
				ReadOnlyFastMoveSample readOnlyFastMoveSampleInfo2 = this.ReadOnlyFastMoveSampleInfo;
				CharacterActorComponent charActorComp3 = this.CharActorComp;
				readOnlyFastMoveSampleInfo2.Rotation = ((charActorComp3 != null) ? charActorComp3.ActorRotationProxy : null);
				ReadOnlyFastMoveSample readOnlyFastMoveSampleInfo3 = this.ReadOnlyFastMoveSampleInfo;
				CharacterActorComponent charActorComp4 = this.CharActorComp;
				readOnlyFastMoveSampleInfo3.LinearVelocity = ((charActorComp4 != null) ? charActorComp4.ActorVelocityProxy : null);
			}
			this.ReadOnlyFastMoveSampleInfo.MovementMode = (int)this.MoveComp.CharacterMovement.MovementMode;
			this.FastMoveSampleInternal = this.ReadOnlyFastMoveSampleInfo;
			return;
		}
		this.UpdateFastMoveSampleBase(ref this.FastMoveSampleInfo, this.CharActorComp.Actor, this.MoveComp.CharacterMovement);
		this.FastMoveSampleInternal = this.FastMoveSampleInfo;
	}

	// Token: 0x060196F0 RID: 104176 RVA: 0x00758970 File Offset: 0x00756B70
	private int GetMovementModeFromSample()
	{
		FastMoveSample fastMoveSample = this.FastMoveSampleInternal as FastMoveSample;
		if (fastMoveSample != null)
		{
			return fastMoveSample.MovementMode;
		}
		ReadOnlyFastMoveSample readOnlyFastMoveSample = this.FastMoveSampleInternal as ReadOnlyFastMoveSample;
		if (readOnlyFastMoveSample != null)
		{
			return readOnlyFastMoveSample.MovementMode;
		}
		return 0;
	}

	// Token: 0x060196F1 RID: 104177 RVA: 0x007589AC File Offset: 0x00756BAC
	private global::Vector GetLocationFromSample()
	{
		FastMoveSample fastMoveSample = this.FastMoveSampleInternal as FastMoveSample;
		if (fastMoveSample != null)
		{
			return fastMoveSample.Location;
		}
		ReadOnlyFastMoveSample readOnlyFastMoveSample = this.FastMoveSampleInternal as ReadOnlyFastMoveSample;
		if (readOnlyFastMoveSample != null)
		{
			return readOnlyFastMoveSample.Location;
		}
		return global::Vector.Create();
	}

	// Token: 0x060196F2 RID: 104178 RVA: 0x007589EC File Offset: 0x00756BEC
	private global::Rotator GetRotationFromSample()
	{
		FastMoveSample fastMoveSample = this.FastMoveSampleInternal as FastMoveSample;
		if (fastMoveSample != null)
		{
			return fastMoveSample.Rotation;
		}
		ReadOnlyFastMoveSample readOnlyFastMoveSample = this.FastMoveSampleInternal as ReadOnlyFastMoveSample;
		if (readOnlyFastMoveSample != null)
		{
			return readOnlyFastMoveSample.Rotation;
		}
		return global::Rotator.Create();
	}

	// Token: 0x060196F3 RID: 104179 RVA: 0x00758A2C File Offset: 0x00756C2C
	private global::Vector GetLinearVelocityFromSample()
	{
		FastMoveSample fastMoveSample = this.FastMoveSampleInternal as FastMoveSample;
		if (fastMoveSample != null)
		{
			return fastMoveSample.LinearVelocity;
		}
		ReadOnlyFastMoveSample readOnlyFastMoveSample = this.FastMoveSampleInternal as ReadOnlyFastMoveSample;
		if (readOnlyFastMoveSample != null)
		{
			return readOnlyFastMoveSample.LinearVelocity;
		}
		return global::Vector.Create();
	}

	// Token: 0x060196F4 RID: 104180 RVA: 0x00758A6C File Offset: 0x00756C6C
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.InputComp = base.Entity.GetComponent<CharacterInputComponent>();
		this.SlideComponent = base.Entity.GetComponent<CharacterSlideComponent>();
		this.UnifiedComp = base.Entity.GetComponent<BaseUnifiedStateComponent>();
		this.DriveVehicleComp = base.Entity.GetComponent<CharacterDriveVehicleComponent>();
		this.AiComponent = base.Entity.GetComponent<CharacterAiComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
		return true;
	}

	// Token: 0x060196F5 RID: 104181 RVA: 0x00758AF8 File Offset: 0x00756CF8
	protected override bool OnEnd()
	{
		if (!base.OnEnd())
		{
			return false;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(base.Entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnCharSkillEnd));
		return true;
	}

	// Token: 0x060196F6 RID: 104182 RVA: 0x00758B24 File Offset: 0x00756D24
	protected override void ApplyInput(int input, global::Rotator rotation)
	{
		if (this.InputComp != null)
		{
			if (input != 65535)
			{
				int input2 = input >> 8;
				int num = input & 255;
				this.UnpackInputDirection(input2, this.TmpVector);
				this.UnpackInputDirection(num, this.TmpVector2);
				this.InputComp.SetMoveVectorCache(this.TmpVector, this.TmpVector2);
				CharacterActorComponent charActorComp = this.CharActorComp;
				if (charActorComp == null)
				{
					return;
				}
				charActorComp.SetInputRotatorByNumber(0f, (float)num / 255f * 360f, 0f);
				return;
			}
			else
			{
				this.InputComp.ResetMoveVectorCache();
				CharacterActorComponent charActorComp2 = this.CharActorComp;
				if (charActorComp2 == null)
				{
					return;
				}
				charActorComp2.SetInputRotator(rotation);
			}
		}
	}

	// Token: 0x060196F7 RID: 104183 RVA: 0x00758BC8 File Offset: 0x00756DC8
	private void UnpackInputDirection(int input, global::Vector outVector)
	{
		if (input == 255)
		{
			outVector.Reset();
			return;
		}
		double num = Singleton<MathUtils>.Instance.RangeClamp((double)input, 0.0, 255.0, 0.0, 6.283185307179586);
		outVector.X = Math.Cos(num);
		outVector.Y = Math.Sin(num);
	}

	// Token: 0x060196F8 RID: 104184 RVA: 0x00758C30 File Offset: 0x00756E30
	public unsafe override MoveReplaySample GetCurrentMoveSample()
	{
		MoveReplaySample moveReplaySample = MoveReplaySample.Create();
		moveReplaySample.Location = new Aki.Protocol.Vector
		{
			X = 0f,
			Y = 0f,
			Z = 0f
		};
		moveReplaySample.LinearVelocity = new Aki.Protocol.Vector
		{
			X = 0f,
			Y = 0f,
			Z = 0f
		};
		moveReplaySample.Rotation = new Aki.Protocol.Rotator
		{
			Pitch = 0f,
			Roll = 0f,
			Yaw = 0f
		};
		CharacterInputComponent inputComp = this.InputComp;
		float valueOrDefault = ((inputComp != null) ? inputComp.QueryInputAxis(EInputAxis.MoveForward) : null).GetValueOrDefault();
		CharacterInputComponent inputComp2 = this.InputComp;
		float valueOrDefault2 = ((inputComp2 != null) ? inputComp2.QueryInputAxis(EInputAxis.MoveRight) : null).GetValueOrDefault();
		CharacterActorComponent charActorComp = this.CharActorComp;
		this.UpdateFastMoveSampleInput(ref moveReplaySample, (charActorComp != null) ? charActorComp.Actor : null, this.MoveComp.CharacterMovement, valueOrDefault, valueOrDefault2, 255f, ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw);
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance != null && instance.InstanceType == InstanceType.BigWorldInstance && moveReplaySample.Location.X == 0f && moveReplaySample.Location.Y == 0f && moveReplaySample.Location.Z == 0f)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Move;
			Entity entity = base.Entity;
			string message = "移动坐标点为0";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Component", this.CharActorComp != null);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "Actor";
			CharacterActorComponent charActorComp2 = this.CharActorComp;
			ptr = new ValueTuple<string, object>(item, ((charActorComp2 != null) ? charActorComp2.Actor : null) != null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Location", moveReplaySample.Location);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("LinearVelocity", moveReplaySample.LinearVelocity);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Rotation", moveReplaySample.Rotation);
			instance2.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		}
		MoveReplaySample moveReplaySample2 = moveReplaySample;
		BaseUnifiedStateComponent unifiedComp = this.UnifiedComp;
		moveReplaySample2.MoveState = (int)((unifiedComp != null) ? unifiedComp.MoveState : global::ECharMoveState.Other);
		moveReplaySample.ServerTimeStamp = (long)Singleton<Time>.Instance.CombatServerTime;
		moveReplaySample.TimeStamp = (float)Singleton<Time>.Instance.NowSeconds;
		if (base.Entity.GetTickInterval() > 1 && this.LastLogicTickTime > 0.0 && this.NowLogicTickTime > 0.0)
		{
			moveReplaySample.TickInterval = (int)(this.NowLogicTickTime - this.LastLogicTickTime) * 1000;
		}
		moveReplaySample.RTT = (int)Singleton<Net>.Instance.RttMs;
		MoveReplaySample moveReplaySample3 = moveReplaySample;
		float timeDilation = base.Entity.TimeDilation;
		CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		moveReplaySample3.TimeScale = timeDilation * ((timeScaleComp != null) ? timeScaleComp.CurrentTimeScale : 1f);
		if (this.SlideComponent != null)
		{
			global::Vector slideForward = this.SlideComponent.SlideForward;
			moveReplaySample.SlideForward = new Aki.Protocol.Vector
			{
				X = (float)slideForward.X,
				Y = (float)slideForward.Y,
				Z = (float)slideForward.Z
			};
		}
		BaseMoveComponent moveComp = this.MoveComp;
		if (((moveComp != null) ? moveComp.BasePlatform : null) != null)
		{
			moveReplaySample.RelativeMoveReplaySample = this.GetRelativeMoveSample(this.MoveComp.BasePlatform, false);
		}
		else if (this.LastHasBaseMovement)
		{
			if (this.LastBasePlatform != null)
			{
				moveReplaySample.RelativeMoveReplaySample = this.GetRelativeMoveSample(this.LastBasePlatform, true);
			}
			else
			{
				this.LastHasBaseMovement = false;
			}
		}
		moveReplaySample.SkillId = this.CurEndSkillId;
		this.CurEndSkillId = 0L;
		this.LastMoveSample = moveReplaySample;
		base.CompressData(moveReplaySample);
		return moveReplaySample;
	}

	// Token: 0x060196F9 RID: 104185 RVA: 0x0075900C File Offset: 0x0075720C
	[return: Nullable(2)]
	protected RelativeMoveReplaySample GetRelativeMoveSample(BasePlatform platform, bool checkLeave = false)
	{
		EntityHandle entityHandle = platform.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			this.LastHasBaseMovement = false;
			this.LastBasePlatform = null;
			return null;
		}
		if (checkLeave && platform.CheckLeave(base.Entity, this.GetLocationFromSample()))
		{
			this.LastHasBaseMovement = false;
			this.LastBasePlatform = null;
			return null;
		}
		FRotator actorRotation = this.ActorComp.ActorRotation;
		float scaledHalfHeight = this.CharActorComp.ScaledHalfHeight;
		FVectorDouble inPosition = this.CharActorComp.Actor.D_K2_GetActorLocation();
		inPosition.Z -= (double)scaledHalfHeight;
		FVectorDouble fvectorDouble = new FVectorDouble();
		FRotator frotator = new FRotator();
		platform.TransformToRelativeSpace(inPosition, actorRotation, ref fvectorDouble, ref frotator);
		RelativeMoveReplaySample relativeMoveReplaySample = RelativeMoveReplaySample.Create();
		relativeMoveReplaySample.BaseMovementEntityId = Singleton<MathUtils>.Instance.NumberToLong(platform.EntityHandle.CreatureDataId);
		relativeMoveReplaySample.RelativeLocation = new Aki.Protocol.Vector
		{
			X = (float)fvectorDouble.X,
			Y = (float)fvectorDouble.Y,
			Z = (float)fvectorDouble.Z
		};
		relativeMoveReplaySample.RelativeRotation = new Aki.Protocol.Rotator
		{
			Pitch = frotator.Pitch,
			Roll = frotator.Roll,
			Yaw = frotator.Yaw
		};
		return relativeMoveReplaySample;
	}

	// Token: 0x060196FA RID: 104186 RVA: 0x0075913C File Offset: 0x0075733C
	protected override void RecordLastData(bool isMove = false)
	{
		this.LastMovementMode = this.GetMovementModeFromSample();
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp != null && moveComp.HasBaseMovement)
		{
			BaseMoveComponent moveComp2 = this.MoveComp;
			if (((moveComp2 != null) ? moveComp2.BasePlatform : null) != null)
			{
				this.LastHasBaseMovement = this.MoveComp.HasBaseMovement;
				if (this.MoveComp.BasePlatform != this.LastBasePlatform)
				{
					this.LastBasePlatform = this.MoveComp.BasePlatform;
					this.LastBasePlatform.OnCharacterEnter(base.Entity, this.MoveComp.CharacterMovement);
				}
			}
		}
		this.LastLocation.DeepCopy(this.GetLocationFromSample());
		this.LastRotation.DeepCopy(this.GetRotationFromSample());
		this.LastMoveAutonomousProxy = this.ActorComp.IsMoveAutonomousProxy;
		this.LastMove = isMove;
		double num = (double)base.Entity.TimeDilation;
		CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		float? num2 = (timeScaleComp != null) ? new float?(timeScaleComp.CurrentTimeScale) : null;
		double lastTimeScale = num * ((num2 != null) ? ((double)num2.GetValueOrDefault()) : 1.0);
		this.LastTimeScale = lastTimeScale;
	}

	// Token: 0x060196FB RID: 104187 RVA: 0x0075925C File Offset: 0x0075745C
	protected override bool CalcRelativeMove(ReplaySample sample1, ReplaySample sample2, float lerpPercent, global::Vector outLocation, global::Rotator outRotator)
	{
		if (sample1.RelativeMove == null || sample2.RelativeMove == null)
		{
			return false;
		}
		EntityHandle entityHandle = ModelBase<CreatureModel>.Instance.GetEntity(sample1.RelativeMove.BaseMovementEntityId);
		if (entityHandle == null)
		{
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntityWithDelayRemoveContainer(sample1.RelativeMove.BaseMovementEntityId);
		}
		if (entityHandle == null)
		{
			return false;
		}
		BasePlatform basePlatformByEntity = BasePlatformController.GetBasePlatformByEntity(entityHandle);
		if (basePlatformByEntity == null)
		{
			return false;
		}
		global::Vector.Lerp(sample1.RelativeMove.RelativeLocation, sample2.RelativeMove.RelativeLocation, (double)lerpPercent, outLocation);
		global::Rotator.Lerp(sample1.RelativeMove.RelativeRotation, sample2.RelativeMove.RelativeRotation, lerpPercent, outRotator);
		FVectorDouble fvectorDouble = new FVectorDouble();
		FRotator frotator = new FRotator();
		basePlatformByEntity.TransformFromRelativeSpace(outLocation.ToUeVector(false), outRotator.ToUeRotator(), ref fvectorDouble, ref frotator);
		outLocation.DeepCopy(fvectorDouble);
		float scaledHalfHeight = this.CharActorComp.ScaledHalfHeight;
		outLocation.Z += (double)scaledHalfHeight;
		outRotator.DeepCopy(frotator);
		return true;
	}

	// Token: 0x060196FC RID: 104188 RVA: 0x00759350 File Offset: 0x00757550
	[return: Nullable(2)]
	protected override EntityHandle CheckRelativeMove(ReplaySample sample1, ReplaySample sample2, float lerpPercent, global::Vector outLocation, global::Rotator outRotator)
	{
		if (sample1.RelativeMove == null || sample2.RelativeMove == null)
		{
			return null;
		}
		EntityHandle entityHandle = ModelBase<CreatureModel>.Instance.GetEntity(sample1.RelativeMove.BaseMovementEntityId);
		if (entityHandle == null)
		{
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntityWithDelayRemoveContainer(sample1.RelativeMove.BaseMovementEntityId);
		}
		if (entityHandle == null)
		{
			return null;
		}
		if (BasePlatformController.GetBasePlatformByEntity(entityHandle) == null)
		{
			return null;
		}
		global::Vector.Lerp(sample1.RelativeMove.RelativeLocation, sample2.RelativeMove.RelativeLocation, (double)lerpPercent, outLocation);
		global::Rotator.Lerp(sample1.RelativeMove.RelativeRotation, sample2.RelativeMove.RelativeRotation, lerpPercent, outRotator);
		return entityHandle;
	}

	// Token: 0x060196FD RID: 104189 RVA: 0x007593EC File Offset: 0x007575EC
	protected override bool TransformFromRelativeMove(EntityHandle handle, global::Vector location, global::Rotator rotator, global::Vector outLocation, global::Rotator outRotator)
	{
		BasePlatform basePlatformByEntity = BasePlatformController.GetBasePlatformByEntity(handle);
		if (basePlatformByEntity == null)
		{
			return false;
		}
		FVectorDouble fvectorDouble = new FVectorDouble();
		FRotator frotator = new FRotator();
		basePlatformByEntity.TransformFromRelativeSpace(location.ToUeVector(false), rotator.ToUeRotator(), ref fvectorDouble, ref frotator);
		outLocation.DeepCopy(fvectorDouble);
		float scaledHalfHeight = this.CharActorComp.ScaledHalfHeight;
		outLocation.Z += (double)scaledHalfHeight;
		outRotator.DeepCopy(frotator);
		return true;
	}

	// Token: 0x060196FE RID: 104190 RVA: 0x0075945C File Offset: 0x0075765C
	protected override void ApplyMoveSample(int movementMode, global::Vector location, global::Rotator rotator, global::Vector linearVelocity, global::Vector slideForward, int controllerPlayerId, int input, float controllerPitch, float timeScale, long serverTimeStamp, float originRtt)
	{
		base.ApplyMoveSample(movementMode, location, rotator, linearVelocity, slideForward, controllerPlayerId, input, controllerPitch, timeScale, serverTimeStamp, originRtt);
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp != null)
		{
			moveComp.SetForceSpeed(linearVelocity);
		}
		this.ControllerPlayerId = controllerPlayerId;
		CharacterSlideComponent slideComponent = this.SlideComponent;
		if (slideComponent != null)
		{
			slideComponent.SlideForward.DeepCopy(slideForward);
		}
		CharacterAiComponent aiComponent = this.AiComponent;
		bool flag;
		if (aiComponent == null)
		{
			flag = false;
		}
		else
		{
			AiController aiController = aiComponent.AiController;
			flag = ((aiController != null) ? new bool?(aiController.IsWaitingReceiveControl()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			this.LastReceivedMovementMode = movementMode;
		}
		else
		{
			CharacterActorComponent charActorComp = this.CharActorComp;
			if (charActorComp != null)
			{
				charActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = (EMovementMode)movementMode,
					Context = "[CharacterMovementSyncComponent.ApplyMoveSample]"
				});
			}
		}
		this.ApplyInput(input, rotator);
		this.CacheFinalRotator.Reset();
		this.CacheFinalRotator.Pitch = controllerPitch;
		AController controller = this.CharActorComp.Actor.Controller;
		if (controller != null)
		{
			FRotator frotator = this.CacheFinalRotator.ToUeRotator();
			controller.SetControlRotation(frotator);
		}
		CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		if (timeScaleComp != null)
		{
			timeScaleComp.SetMoveSyncTimeScale(timeScale);
		}
		double num = 0.0;
		if (this.LastReceiveMoveSample != null)
		{
			num = (this.LastReceiveMoveSample.TimeStamp - Singleton<Time>.Instance.NowSeconds) * 1000.0;
		}
		base.ReportMoveDataApplyInfo((float)Singleton<Time>.Instance.CombatServerTime - (float)serverTimeStamp, (float)num, originRtt);
	}

	// Token: 0x060196FF RID: 104191 RVA: 0x007595C9 File Offset: 0x007577C9
	public void ClearBasePlatform()
	{
		this.LastHasBaseMovement = false;
		this.LastBasePlatform = null;
	}

	// Token: 0x06019700 RID: 104192 RVA: 0x007595DC File Offset: 0x007577DC
	private void UpdateFastMoveSampleBase(ref FastMoveSample moveSample, [Nullable(2)] APawn pawn, UCharacterMovementComponent moveComp)
	{
		if (pawn == null)
		{
			return;
		}
		FVectorDouble fvectorDouble = pawn.D_K2_GetActorLocation();
		FRotator frotator = pawn.K2_GetActorRotation();
		FVector velocity = pawn.GetVelocity();
		moveSample.Location.X = (double)((float)fvectorDouble.X);
		moveSample.Location.Y = (double)((float)fvectorDouble.Y);
		moveSample.Location.Z = (double)((float)fvectorDouble.Z);
		moveSample.Rotation.Pitch = frotator.Pitch;
		moveSample.Rotation.Yaw = frotator.Yaw;
		moveSample.Rotation.Roll = frotator.Roll;
		moveSample.LinearVelocity.X = (double)velocity.X;
		moveSample.LinearVelocity.Y = (double)velocity.Y;
		moveSample.LinearVelocity.Z = (double)velocity.Z;
		moveSample.MovementMode = (int)moveComp.MovementMode;
	}

	// Token: 0x06019701 RID: 104193 RVA: 0x007596C8 File Offset: 0x007578C8
	private void UpdateFastMoveSampleInput(ref MoveReplaySample moveSample, [Nullable(2)] APawn pawn, UCharacterMovementComponent moveComp, float inputX, float inputY, float inputSize, float cameraYaw)
	{
		if (pawn == null)
		{
			return;
		}
		FVector2D fvector2D = new FVector2D(inputX, inputY);
		float controllerPitch = 0f;
		if (pawn.GetController() != null)
		{
			controllerPitch = pawn.GetController().GetControlRotation().Pitch;
		}
		FVectorDouble fvectorDouble = pawn.D_K2_GetActorLocation();
		FRotator frotator = pawn.K2_GetActorRotation();
		FVector velocity = pawn.GetVelocity();
		moveSample.Location.X = (float)fvectorDouble.X;
		moveSample.Location.Y = (float)fvectorDouble.Y;
		moveSample.Location.Z = (float)fvectorDouble.Z;
		moveSample.Rotation.Pitch = frotator.Pitch;
		moveSample.Rotation.Yaw = frotator.Yaw;
		moveSample.Rotation.Roll = frotator.Roll;
		moveSample.LinearVelocity.X = velocity.X;
		moveSample.LinearVelocity.Y = velocity.Y;
		moveSample.LinearVelocity.Z = velocity.Z;
		moveSample.ControllerPitch = controllerPitch;
		moveSample.InputDirection = this.CalculateInputDirection(fvector2D.GetSafeNormal(1E-08f), inputSize, cameraYaw);
		moveSample.MovementMode = (int)moveComp.MovementMode;
	}

	// Token: 0x06019702 RID: 104194 RVA: 0x00759800 File Offset: 0x00757A00
	private int CalculateInputDirection(FVector2D inputDirection, float inputDirectionSize, float cameraRotatorYaw)
	{
		int num = (int)this.PackJoystickInput(inputDirection, inputDirectionSize);
		FVector2D rotated = inputDirection.GetRotated(cameraRotatorYaw);
		int num2 = (int)this.PackJoystickInput(rotated, inputDirectionSize);
		return num << 8 | num2;
	}

	// Token: 0x06019703 RID: 104195 RVA: 0x00759830 File Offset: 0x00757A30
	private float PackJoystickInput(FVector2D inputDirection, float inputDirectionSize)
	{
		if (inputDirection.IsNearlyZero(1E-08f))
		{
			return 255f;
		}
		float num = FMath.Asin(inputDirection.Y);
		if (inputDirection.X < 0f)
		{
			num = 3.1415927f - num;
		}
		if (num < 0f)
		{
			num += 6.2831855f;
		}
		return UKismetMathLibrary.MapRangeClamped(num, 0f, 6.2831855f, 0f, 255f);
	}

	// Token: 0x06019704 RID: 104196 RVA: 0x0075989C File Offset: 0x00757A9C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterMovementSyncComponent characterMovementSyncComponent = (CharacterMovementSyncComponent)componentTemplate;
		if (base.CanResetComponentProperty("LastMovementMode"))
		{
			this.LastMovementMode = characterMovementSyncComponent.LastMovementMode;
		}
		if (base.CanResetComponentProperty("LastReceivedMovementMode"))
		{
			this.LastReceivedMovementMode = characterMovementSyncComponent.LastReceivedMovementMode;
		}
		if (base.CanResetComponentProperty("LastTimeScale"))
		{
			this.LastTimeScale = characterMovementSyncComponent.LastTimeScale;
		}
		if (base.CanResetComponentProperty("InputComp"))
		{
			if (characterMovementSyncComponent.InputComp == null)
			{
				this.InputComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComp), "InputComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SlideComponent"))
		{
			if (characterMovementSyncComponent.SlideComponent == null)
			{
				this.SlideComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSlideComponent>(this.SlideComponent), "SlideComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedComp"))
		{
			if (characterMovementSyncComponent.UnifiedComp == null)
			{
				this.UnifiedComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseUnifiedStateComponent>(this.UnifiedComp), "UnifiedComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DriveVehicleComp"))
		{
			if (characterMovementSyncComponent.DriveVehicleComp == null)
			{
				this.DriveVehicleComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterDriveVehicleComponent>(this.DriveVehicleComp), "DriveVehicleComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AiComponent"))
		{
			if (characterMovementSyncComponent.AiComponent == null)
			{
				this.AiComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAiComponent>(this.AiComponent), "AiComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FastMoveSampleInfo"))
		{
			if (characterMovementSyncComponent.FastMoveSampleInfo == null)
			{
				this.FastMoveSampleInfo = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FastMoveSample>(this.FastMoveSampleInfo), "FastMoveSampleInfo"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ReadOnlyFastMoveSampleInfo") && characterMovementSyncComponent.ReadOnlyFastMoveSampleInfo != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<ReadOnlyFastMoveSample>(this.ReadOnlyFastMoveSampleInfo), "ReadOnlyFastMoveSampleInfo"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("FastMoveSampleInternal"))
		{
			if (characterMovementSyncComponent.FastMoveSampleInternal == null)
			{
				this.FastMoveSampleInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<object>(this.FastMoveSampleInternal), "FastMoveSampleInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurEndSkillId"))
		{
			this.CurEndSkillId = characterMovementSyncComponent.CurEndSkillId;
		}
		return true;
	}

	// Token: 0x0400C94F RID: 51535
	private const int InputDirectionSize = 255;

	// Token: 0x0400C950 RID: 51536
	private const int InvalidInput = 65535;

	// Token: 0x0400C951 RID: 51537
	private const float PI = 3.1415927f;

	// Token: 0x0400C952 RID: 51538
	protected int LastMovementMode;

	// Token: 0x0400C953 RID: 51539
	protected int LastReceivedMovementMode;

	// Token: 0x0400C954 RID: 51540
	protected double LastTimeScale = 1.0;

	// Token: 0x0400C955 RID: 51541
	[Nullable(2)]
	private CharacterInputComponent InputComp;

	// Token: 0x0400C956 RID: 51542
	[Nullable(2)]
	private CharacterSlideComponent SlideComponent;

	// Token: 0x0400C957 RID: 51543
	[Nullable(2)]
	private BaseUnifiedStateComponent UnifiedComp;

	// Token: 0x0400C958 RID: 51544
	[Nullable(2)]
	private CharacterDriveVehicleComponent DriveVehicleComp;

	// Token: 0x0400C959 RID: 51545
	[Nullable(2)]
	private CharacterAiComponent AiComponent;

	// Token: 0x0400C95A RID: 51546
	private FastMoveSample FastMoveSampleInfo = new FastMoveSample();

	// Token: 0x0400C95B RID: 51547
	private readonly ReadOnlyFastMoveSample ReadOnlyFastMoveSampleInfo = new ReadOnlyFastMoveSample();

	// Token: 0x0400C95C RID: 51548
	private object FastMoveSampleInternal;

	// Token: 0x0400C95D RID: 51549
	private long CurEndSkillId;
}
