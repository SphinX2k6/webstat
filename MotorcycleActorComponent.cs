using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;
using UnrealEngine;

// Token: 0x02003298 RID: 12952
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleActorComponent : VehicleActorComponent
{
	// Token: 0x170024E1 RID: 9441
	// (get) Token: 0x0601B1ED RID: 111085 RVA: 0x00822B8D File Offset: 0x00820D8D
	public Vector AirRotateInputProxy
	{
		get
		{
			return this.AirRotateInputInternal;
		}
	}

	// Token: 0x0601B1EE RID: 111086 RVA: 0x00822B95 File Offset: 0x00820D95
	public void SetAirRotateInput(IVector v)
	{
		this.AirRotateInputInternal.DeepCopy(v);
	}

	// Token: 0x0601B1EF RID: 111087 RVA: 0x00822BA4 File Offset: 0x00820DA4
	public unsafe override bool SetActorLocation(FVectorDouble value, string context = "unknown", bool sweep = false)
	{
		if (!sweep)
		{
			return base.SetActorLocation(value, context, sweep);
		}
		if (!Singleton<MathUtils>.Instance.IsValidVector(value, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "SetActorLocation的value无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", value);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData = base.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		bool result = false;
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			VehicleActorComponent.TmpVector.FromUeVector(value);
			VehicleActorComponent.TmpVector.SubtractionEqual(this.ActorLocationProxy);
			this.CachedDesiredActorLocation.FromUeVector(value);
			this.IsChangingLocation = true;
			this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(VehicleActorComponent.TmpVector.ToUeVectorOld(), Quat.Identity, sweep);
			this.IsChangingLocation = false;
			base.CheckIsForbidSettingLocAndRot(true, false, true);
			if (this.DebugMovementComp != null)
			{
				this.DebugMovementComp.MarkDebugRecord(context + ".SetActorLocation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
			}
		}
		base.ResetLocationCachedTime();
		this.OnTeleport();
		return result;
	}

	// Token: 0x0601B1F0 RID: 111088 RVA: 0x00822D00 File Offset: 0x00820F00
	public unsafe override bool SetActorLocationNoTeleport(FVectorDouble value, string context = "unknown", bool sweep = false)
	{
		if (!sweep)
		{
			base.SetActorLocationNoTeleport(value, context, sweep);
		}
		if (!Singleton<MathUtils>.Instance.IsValidVector(value, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "SetActorLocation的value无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", value);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData = base.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		bool result = false;
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			VehicleActorComponent.TmpVector.FromUeVector(value);
			VehicleActorComponent.TmpVector.SubtractionEqual(this.ActorLocationProxy);
			this.CachedDesiredActorLocation.FromUeVector(value);
			this.IsChangingLocation = true;
			this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(VehicleActorComponent.TmpVector.ToUeVectorOld(), Quat.Identity, sweep);
			this.IsChangingLocation = false;
			base.CheckIsForbidSettingLocAndRot(true, false, true);
			if (this.DebugMovementComp != null)
			{
				this.DebugMovementComp.MarkDebugRecord(context + ".SetActorLocation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
			}
		}
		base.ResetLocationCachedTime();
		return result;
	}

	// Token: 0x0601B1F1 RID: 111089 RVA: 0x00822E54 File Offset: 0x00821054
	public override bool SetActorRotation(FRotator value, string context, bool sweep = false)
	{
		if (!sweep)
		{
			return base.SetActorRotation(value, context, sweep);
		}
		bool result = false;
		if (!Singleton<MathUtils>.Instance.IsValidRotator(value, 100000000))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.MZJ, "SetActorRotation NaN", default(ReadOnlySpan<ValueTuple<string, object>>));
			return result;
		}
		MotorcycleActorComponent.TmpRotator.FromUeRotator(value);
		MotorcycleActorComponent.TmpRotator.Quaternion(VehicleActorComponent.TmpQuat);
		base.ActorQuatProxy.Inverse(MotorcycleActorComponent.TmpQuat2);
		VehicleActorComponent.TmpQuat.Multiply(MotorcycleActorComponent.TmpQuat2, MotorcycleActorComponent.TmpQuat3);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(Vector.ZeroVector, MotorcycleActorComponent.TmpQuat3.ToUeQuat(), sweep);
		base.ResetRotationCachedTime();
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".SetActorRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		return result;
	}

	// Token: 0x0601B1F2 RID: 111090 RVA: 0x00822F34 File Offset: 0x00821134
	public override bool SetActorLocationAndRotation(FVectorDouble location, FRotator rotation, string context, bool sweep = false, ESetRotationPriority? priority = null)
	{
		if (!sweep)
		{
			return base.SetActorLocationAndRotation(location, rotation, context, sweep, priority);
		}
		bool result = false;
		if (!Singleton<MathUtils>.Instance.IsValidVector(location, 100000000) || !Singleton<MathUtils>.Instance.IsValidRotator(rotation, 100000000))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.MZJ, "SetActorLocationAndRotation NaN", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		VehicleActorComponent.TmpVector.FromUeVector(location);
		VehicleActorComponent.TmpVector.SubtractionEqual(this.ActorLocationProxy);
		MotorcycleActorComponent.TmpRotator.FromUeRotator(rotation);
		MotorcycleActorComponent.TmpRotator.Quaternion(VehicleActorComponent.TmpQuat);
		base.ActorQuatProxy.Inverse(MotorcycleActorComponent.TmpQuat2);
		if (priority != null)
		{
			FunctionRequestWithPriority<ESetRotationPriority> functionRequestWithPriority = new FunctionRequestWithPriority<ESetRotationPriority>();
			functionRequestWithPriority.ModuleName = context;
			functionRequestWithPriority.Priority = priority.Value;
			if (!this.SetRotationRequestProxy.DecideCall(functionRequestWithPriority))
			{
				VehicleActorComponent.TmpQuat.DeepCopy(Quat.IdentityProxy);
			}
		}
		VehicleActorComponent.TmpQuat.Multiply(MotorcycleActorComponent.TmpQuat2, MotorcycleActorComponent.TmpQuat3);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(VehicleActorComponent.TmpVector.ToUeVectorOld(), MotorcycleActorComponent.TmpQuat3.ToUeQuat(), sweep);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".SetActorLocationAndRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetTransformCachedTime();
		this.OnTeleport();
		return result;
	}

	// Token: 0x0601B1F3 RID: 111091 RVA: 0x00823098 File Offset: 0x00821298
	public override bool SetActorTransform(FTransformDouble value, string context, bool sweep = false, ESetRotationPriority? priority = null)
	{
		if (!sweep)
		{
			return base.SetActorTransform(value, context, sweep, priority);
		}
		bool result = false;
		if (priority != null)
		{
			FunctionRequestWithPriority<ESetRotationPriority> functionRequestWithPriority = new FunctionRequestWithPriority<ESetRotationPriority>();
			functionRequestWithPriority.ModuleName = context;
			functionRequestWithPriority.Priority = priority.Value;
			if (!this.SetRotationRequestProxy.DecideCall(functionRequestWithPriority))
			{
				FQuat fquat = base.ActorRotation.Quaternion();
				value.SetRotation(fquat);
			}
		}
		Vector tmpVector = VehicleActorComponent.TmpVector;
		FVectorDouble location = value.GetLocation();
		tmpVector.FromUeVector(location);
		VehicleActorComponent.TmpVector.SubtractionEqual(this.ActorLocationProxy);
		VehicleActorComponent.TmpQuat.FromUeQuat(value.GetRotation());
		base.ActorQuatProxy.Inverse(MotorcycleActorComponent.TmpQuat2);
		VehicleActorComponent.TmpQuat.Multiply(MotorcycleActorComponent.TmpQuat2, MotorcycleActorComponent.TmpQuat3);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(VehicleActorComponent.TmpVector.ToUeVectorOld(), MotorcycleActorComponent.TmpQuat3.ToUeQuat(), sweep);
		base.ResetTransformCachedTime();
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".SetActorTransform", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		return result;
	}

	// Token: 0x0601B1F4 RID: 111092 RVA: 0x008231AC File Offset: 0x008213AC
	public override bool SetActorLocationAndRotationExceptMesh(FVectorDouble location, FRotator rotation, string context, bool sweep = false, ESetRotationPriority? priority = null)
	{
		if (this.SkeletalMesh != null)
		{
			return this.SetActorLocationAndRotation(location, rotation, context, sweep, priority);
		}
		FTransformDouble ftransformDouble = this.SkeletalMesh.D_K2_GetComponentToWorld();
		bool result = this.SetActorLocationAndRotation(location, rotation, context, sweep, priority);
		FHitResult fhitResult = new FHitResult();
		this.SkeletalMesh.D_K2_SetWorldTransform(ftransformDouble, false, ref fhitResult, true);
		return result;
	}

	// Token: 0x0601B1F5 RID: 111093 RVA: 0x00823200 File Offset: 0x00821400
	public override bool SetActorTransformExceptMesh(FTransformDouble value, string context, bool sweep = false, ESetRotationPriority? priority = null)
	{
		if (this.SkeletalMesh != null)
		{
			return this.SetActorTransform(value, context, sweep, priority);
		}
		FTransformDouble ftransformDouble = this.SkeletalMesh.D_K2_GetComponentToWorld();
		bool result = this.SetActorTransform(value, context, sweep, priority);
		FHitResult fhitResult = new FHitResult();
		this.SkeletalMesh.D_K2_SetWorldTransform(ftransformDouble, false, ref fhitResult, true);
		return result;
	}

	// Token: 0x0601B1F6 RID: 111094 RVA: 0x00823250 File Offset: 0x00821450
	public override void EnterFirstPersonMode()
	{
		base.EnterFirstPersonMode();
		TsBaseVehicle tsBaseVehicle = this.ActorInternal as TsBaseVehicle;
		if (tsBaseVehicle != null)
		{
			CharRenderingComponent charRenderingComponent = tsBaseVehicle.CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.SetMaterialPropertyFloatV2(RenderConfig.TexMipOffset, -10f, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, EKuroCharMeshPart.ECharacterMeshPart_Max);
			}
		}
		Singleton<Log>.Instance.Info(ELogModule.Motor, ELogAuthor.LJM, "设置摩托第一人称材质参数", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601B1F7 RID: 111095 RVA: 0x008232B4 File Offset: 0x008214B4
	public override void ExitFirstPersonMode()
	{
		base.ExitFirstPersonMode();
		TsBaseVehicle tsBaseVehicle = this.ActorInternal as TsBaseVehicle;
		if (tsBaseVehicle != null)
		{
			CharRenderingComponent charRenderingComponent = tsBaseVehicle.CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.SetMaterialPropertyFloatV2(RenderConfig.TexMipOffset, 0f, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.All, EKuroCharMeshPart.ECharacterMeshPart_Max);
			}
		}
		Singleton<Log>.Instance.Info(ELogModule.Motor, ELogAuthor.LJM, "还原摩托第一人称材质参数", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601B1F8 RID: 111096 RVA: 0x00823318 File Offset: 0x00821518
	public override void AddActorWorldOffset(FVectorDouble offset, string context = "unknown", bool sweep = false)
	{
		if (!sweep)
		{
			base.AddActorWorldOffset(offset, context, sweep);
			return;
		}
		if (base.CheckIsForbidSettingLocAndRot(true, false, true))
		{
			return;
		}
		VehicleActorComponent.TmpVector.FromUeVector(offset);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(VehicleActorComponent.TmpVector.ToUeVectorOld(), Quat.Identity, sweep);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorWorldOffset", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetLocationCachedTime();
	}

	// Token: 0x0601B1F9 RID: 111097 RVA: 0x00823398 File Offset: 0x00821598
	public override void AddActorLocalOffset(FVectorDouble offset, string context = "unknown", bool sweep = false)
	{
		if (!sweep)
		{
			base.AddActorLocalOffset(offset, context, sweep);
			return;
		}
		if (base.CheckIsForbidSettingLocAndRot(true, false, true))
		{
			return;
		}
		VehicleActorComponent.TmpVector.FromUeVector(offset);
		base.ActorQuatProxy.RotateVector(VehicleActorComponent.TmpVector, VehicleActorComponent.TmpVector);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(VehicleActorComponent.TmpVector.ToUeVectorOld(), Quat.Identity, sweep);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorLocalOffset", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetLocationCachedTime();
	}

	// Token: 0x0601B1FA RID: 111098 RVA: 0x0082342C File Offset: 0x0082162C
	public override void AddActorWorldRotation(FRotator rotation, string context = "unknown", bool sweep = false)
	{
		if (!sweep)
		{
			base.AddActorWorldRotation(rotation, context, sweep);
			return;
		}
		MotorcycleActorComponent.TmpRotator.FromUeRotator(rotation);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(Vector.ZeroVector, MotorcycleActorComponent.TmpRotator.Quaternion(null).ToUeQuat(), sweep);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorWorldRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetRotationCachedTime();
	}

	// Token: 0x0601B1FB RID: 111099 RVA: 0x008234A4 File Offset: 0x008216A4
	public override void AddActorLocalRotation(FRotator rotation, string context = "unknown", bool sweep = false)
	{
		if (!sweep)
		{
			base.AddActorLocalRotation(rotation, context, sweep);
			return;
		}
		MotorcycleActorComponent.TmpRotator.FromUeRotator(rotation);
		MotorcycleActorComponent.TmpRotator.Quaternion(VehicleActorComponent.TmpQuat);
		base.ActorQuatProxy.Multiply(VehicleActorComponent.TmpQuat, MotorcycleActorComponent.TmpQuat2);
		base.ActorQuatProxy.Inverse(VehicleActorComponent.TmpQuat);
		MotorcycleActorComponent.TmpQuat2.Multiply(VehicleActorComponent.TmpQuat, MotorcycleActorComponent.TmpQuat3);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(Vector.ZeroVector, MotorcycleActorComponent.TmpQuat3.ToUeQuat(), sweep);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorWorldRotation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetRotationCachedTime();
	}

	// Token: 0x0601B1FC RID: 111100 RVA: 0x00823560 File Offset: 0x00821760
	public override void AddActorWorldOffsetAndQuat(FVectorDouble offset, FQuat quatOffset, string context = "unknown", bool sweep = false)
	{
		if (!sweep)
		{
			base.AddActorWorldOffsetAndQuat(offset, quatOffset, context, sweep);
			return;
		}
		VehicleActorComponent.TmpVector.FromUeVector(offset);
		this.VehicleMoveComp.VehicleMovement.MoveMotorcycle(VehicleActorComponent.TmpVector.ToUeVectorOld(), quatOffset, sweep);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".AddActorWorldOffsetAndQuat", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetRotationCachedTime();
	}

	// Token: 0x0601B1FD RID: 111101 RVA: 0x008235D4 File Offset: 0x008217D4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleActorComponent motorcycleActorComponent = (MotorcycleActorComponent)componentTemplate;
		return !base.CanResetComponentProperty("AirRotateInputInternal") || motorcycleActorComponent.AirRotateInputInternal == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.AirRotateInputInternal), "AirRotateInputInternal");
	}

	// Token: 0x0400DCC5 RID: 56517
	private const int TEX_MIP_OFFSET = -10;

	// Token: 0x0400DCC6 RID: 56518
	private const int TEX_MIP_OFFSET_DEFAULT = 0;

	// Token: 0x0400DCC7 RID: 56519
	[StaticVariableRuleIgnore]
	protected static Rotator TmpRotator = Rotator.Create();

	// Token: 0x0400DCC8 RID: 56520
	[StaticVariableRuleIgnore]
	protected static Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400DCC9 RID: 56521
	[StaticVariableRuleIgnore]
	protected static Quat TmpQuat3 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400DCCA RID: 56522
	private readonly Vector AirRotateInputInternal = Vector.Create();
}
