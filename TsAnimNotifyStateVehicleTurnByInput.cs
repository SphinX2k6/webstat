using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D99 RID: 3481
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVehicleTurnByInput.TsAnimNotifyStateVehicleTurnByInput_C")]
public class TsAnimNotifyStateVehicleTurnByInput : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06004D78 RID: 19832 RVA: 0x000AEC57 File Offset: 0x000ACE57
	// (set) Token: 0x06004D79 RID: 19833 RVA: 0x000AEC67 File Offset: 0x000ACE67
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06004D7A RID: 19834 RVA: 0x000AEC78 File Offset: 0x000ACE78
	// (set) Token: 0x06004D7B RID: 19835 RVA: 0x000AEC88 File Offset: 0x000ACE88
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableMinSpeedFixUp
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_EnableMinSpeedFixUp) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_EnableMinSpeedFixUp) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06004D7C RID: 19836 RVA: 0x000AEC99 File Offset: 0x000ACE99
	// (set) Token: 0x06004D7D RID: 19837 RVA: 0x000AECA9 File Offset: 0x000ACEA9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_MinSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_MinSpeed) = value;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06004D7E RID: 19838 RVA: 0x000AECBA File Offset: 0x000ACEBA
	// (set) Token: 0x06004D7F RID: 19839 RVA: 0x000AECCA File Offset: 0x000ACECA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableRollBalanceFixUp
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_EnableRollBalanceFixUp) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_EnableRollBalanceFixUp) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06004D80 RID: 19840 RVA: 0x000AECDB File Offset: 0x000ACEDB
	// (set) Token: 0x06004D81 RID: 19841 RVA: 0x000AECEB File Offset: 0x000ACEEB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float RollInterpolationSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_RollInterpolationSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleTurnByInput.__PropertyOffset_RollInterpolationSpeed) = value;
		}
	}

	// Token: 0x06004D82 RID: 19842 RVA: 0x000AECFC File Offset: 0x000ACEFC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004D83 RID: 19843 RVA: 0x000AEDA4 File Offset: 0x000ACFA4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseVehicle))
		{
			return false;
		}
		VehicleActorComponent vehicleActorComponent = (owner as TsBaseVehicle).VehicleActorComponent;
		Entity entity = (vehicleActorComponent != null) ? vehicleActorComponent.Entity : null;
		VehicleMoveComponent vehicleMoveComponent = (entity != null) ? entity.GetComponent<VehicleMoveComponent>() : null;
		if (vehicleActorComponent == null || vehicleMoveComponent == null)
		{
			return false;
		}
		this.KeepVelocity(owner as TsBaseVehicle);
		return true;
	}

	// Token: 0x06004D84 RID: 19844 RVA: 0x000AEDFC File Offset: 0x000ACFFC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004D85 RID: 19845 RVA: 0x000AEEA4 File Offset: 0x000AD0A4
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseVehicle tsBaseVehicle = meshComp.GetOwner() as TsBaseVehicle;
		if (tsBaseVehicle == null)
		{
			return false;
		}
		VehicleActorComponent vehicleActorComponent = tsBaseVehicle.VehicleActorComponent;
		Vector inputDirectProxy = tsBaseVehicle.VehicleActorComponent.InputDirectProxy;
		Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(vehicleActorComponent, TsAnimNotifyStateVehicleTurnByInput.TmpQuat);
		TsAnimNotifyStateVehicleTurnByInput.TmpQuat.Inverse(TsAnimNotifyStateVehicleTurnByInput.TmpQuat2);
		double num = (double)this.TurnSpeed * inputDirectProxy.Y * (double)frameDeltaTime;
		TsAnimNotifyStateVehicleTurnByInput.TmpRotator.Set(0f, (float)num, 0f);
		TsAnimNotifyStateVehicleTurnByInput.TmpQuat.Multiply(TsAnimNotifyStateVehicleTurnByInput.TmpRotator.Quaternion(null), TsAnimNotifyStateVehicleTurnByInput.TmpQuat3);
		TsAnimNotifyStateVehicleTurnByInput.TmpQuat3.Multiply(TsAnimNotifyStateVehicleTurnByInput.TmpQuat2, TsAnimNotifyStateVehicleTurnByInput.TmpQuat);
		TsAnimNotifyStateVehicleTurnByInput.TmpQuat.RotateVector(vehicleActorComponent.ActorVelocityProxy, TsAnimNotifyStateVehicleTurnByInput.TmpVector1);
		vehicleActorComponent.VehicleMoveComp.SetForceSpeed(TsAnimNotifyStateVehicleTurnByInput.TmpVector1);
		TsAnimNotifyStateVehicleTurnByInput.TmpQuat.Multiply(vehicleActorComponent.ActorQuatProxy, TsAnimNotifyStateVehicleTurnByInput.TmpQuat2);
		TsAnimNotifyStateVehicleTurnByInput.TmpQuat3.DeepCopy(TsAnimNotifyStateVehicleTurnByInput.TmpQuat2);
		if (this.EnableRollBalanceFixUp)
		{
			Vector.CrossProduct(vehicleActorComponent.ActorForwardProxy, vehicleActorComponent.ActorGravityDirectProxy, TsAnimNotifyStateVehicleTurnByInput.TmpVector1);
			double value = Vector.DotProduct(vehicleActorComponent.ActorRightProxy, TsAnimNotifyStateVehicleTurnByInput.TmpVector1);
			double currentValue = Vector.DotProduct(vehicleActorComponent.ActorUpProxy, TsAnimNotifyStateVehicleTurnByInput.TmpVector1);
			double num2 = 90.0 - Math.Acos(Singleton<MathUtils>.Instance.Clamp(currentValue, -1.0, 1.0)) * 57.295780181884766;
			double num3 = Singleton<MathUtils>.Instance.RotatorAxisInterpTo(num2, 0.0, (double)frameDeltaTime, (double)this.RollInterpolationSpeed);
			double num4 = (double)Math.Sign(value) * (num3 - num2);
			TsAnimNotifyStateVehicleTurnByInput.TmpRotator.Set(0f, 0f, (float)num4);
			TsAnimNotifyStateVehicleTurnByInput.TmpQuat2.Multiply(TsAnimNotifyStateVehicleTurnByInput.TmpRotator.Quaternion(null), TsAnimNotifyStateVehicleTurnByInput.TmpQuat3);
		}
		if (vehicleActorComponent != null)
		{
			vehicleActorComponent.SetActorRotation(TsAnimNotifyStateVehicleTurnByInput.TmpQuat3.Rotator(null).ToUeRotator(), "TsAnsVehicleTurnByInput", true);
		}
		return true;
	}

	// Token: 0x06004D86 RID: 19846 RVA: 0x000AF090 File Offset: 0x000AD290
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004D87 RID: 19847 RVA: 0x000AF12F File Offset: 0x000AD32F
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		return meshComp.GetOwner() is TsBaseCharacter;
	}

	// Token: 0x06004D88 RID: 19848 RVA: 0x000AF144 File Offset: 0x000AD344
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004D89 RID: 19849 RVA: 0x000AF1BF File Offset: 0x000AD3BF
	protected override string GetNotifyName_Implementation()
	{
		return "输入改变载具速度和旋转";
	}

	// Token: 0x06004D8A RID: 19850 RVA: 0x000AF1C8 File Offset: 0x000AD3C8
	private bool KeepVelocity(TsBaseVehicle owner)
	{
		if (!this.EnableMinSpeedFixUp)
		{
			return true;
		}
		VehicleActorComponent vehicleActorComponent = owner.VehicleActorComponent;
		VehicleMoveComponent vehicleMoveComponent = (vehicleActorComponent != null) ? vehicleActorComponent.VehicleMoveComp : null;
		if (vehicleMoveComponent == null)
		{
			return false;
		}
		UKuroVehicleMovementComponent vehicleMovement = vehicleMoveComponent.VehicleMovement;
		if (vehicleMovement != null && vehicleMovement.MotorSubState == EMotorSubState.AirMoving)
		{
			return this.KeepVelocityFromAir(owner);
		}
		return this.KeepVelocityFromGround(owner);
	}

	// Token: 0x06004D8B RID: 19851 RVA: 0x000AF220 File Offset: 0x000AD420
	private bool KeepVelocityFromGround(TsBaseVehicle owner)
	{
		VehicleActorComponent vehicleActorComponent = owner.VehicleActorComponent;
		if (vehicleActorComponent == null)
		{
			return false;
		}
		double num = Vector.DotProduct(vehicleActorComponent.ActorForwardProxy, vehicleActorComponent.ActorGravityDirectProxy);
		TsAnimNotifyStateVehicleTurnByInput.TmpVector1.DeepCopy(vehicleActorComponent.ActorForwardProxy);
		if (num > 0.0)
		{
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(vehicleActorComponent, TsAnimNotifyStateVehicleTurnByInput.TmpVector1);
			TsAnimNotifyStateVehicleTurnByInput.TmpVector1.Normalize(9.99999993922529E-09);
		}
		TsAnimNotifyStateVehicleTurnByInput.TmpVector1.Multiply(Vector.DotProduct(vehicleActorComponent.ActorVelocityProxy, TsAnimNotifyStateVehicleTurnByInput.TmpVector1), TsAnimNotifyStateVehicleTurnByInput.TmpVector2);
		if (TsAnimNotifyStateVehicleTurnByInput.TmpVector2.SizeSquared() < (double)(this.MinSpeed * this.MinSpeed))
		{
			TsAnimNotifyStateVehicleTurnByInput.TmpVector1.Multiply((double)this.MinSpeed, TsAnimNotifyStateVehicleTurnByInput.TmpVector2);
		}
		vehicleActorComponent.VehicleMoveComp.SetForceSpeed(TsAnimNotifyStateVehicleTurnByInput.TmpVector2);
		UKuroVehicleMovementComponent vehicleMovement = vehicleActorComponent.VehicleMoveComp.VehicleMovement;
		if (vehicleMovement != null && vehicleMovement.MotorSubState == EMotorSubState.Stop)
		{
			vehicleActorComponent.VehicleMoveComp.SetMotorSubState(EMotorSubState.TwoWheelMoving);
		}
		return true;
	}

	// Token: 0x06004D8C RID: 19852 RVA: 0x000AF314 File Offset: 0x000AD514
	private bool KeepVelocityFromAir(TsBaseVehicle owner)
	{
		VehicleActorComponent vehicleActorComponent = owner.VehicleActorComponent;
		if (vehicleActorComponent == null)
		{
			return false;
		}
		TsAnimNotifyStateVehicleTurnByInput.TmpVector1.DeepCopy(vehicleActorComponent.ActorForwardProxy);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(vehicleActorComponent, TsAnimNotifyStateVehicleTurnByInput.TmpVector1);
		TsAnimNotifyStateVehicleTurnByInput.TmpVector1.Normalize(9.99999993922529E-09);
		TsAnimNotifyStateVehicleTurnByInput.TmpVector1.Multiply(Vector.DotProduct(vehicleActorComponent.ActorVelocityProxy, TsAnimNotifyStateVehicleTurnByInput.TmpVector1), TsAnimNotifyStateVehicleTurnByInput.TmpVector2);
		if (TsAnimNotifyStateVehicleTurnByInput.TmpVector2.SizeSquared() < (double)(this.MinSpeed * this.MinSpeed))
		{
			TsAnimNotifyStateVehicleTurnByInput.TmpVector1.Multiply((double)this.MinSpeed, TsAnimNotifyStateVehicleTurnByInput.TmpVector2);
		}
		vehicleActorComponent.VehicleMoveComp.SetForceSpeed(TsAnimNotifyStateVehicleTurnByInput.TmpVector2);
		UKuroVehicleMovementComponent vehicleMovement = vehicleActorComponent.VehicleMoveComp.VehicleMovement;
		if (vehicleMovement != null && vehicleMovement.MotorSubState == EMotorSubState.Stop)
		{
			vehicleActorComponent.VehicleMoveComp.SetMotorSubState(EMotorSubState.AirMoving);
		}
		return true;
	}

	// Token: 0x06004D8D RID: 19853 RVA: 0x000AF3EC File Offset: 0x000AD5EC
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateVehicleTurnByInput._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVehicleTurnByInput.TsAnimNotifyStateVehicleTurnByInput_C");
		}
		return TsAnimNotifyStateVehicleTurnByInput._ClassPtr;
	}

	// Token: 0x06004D8E RID: 19854 RVA: 0x000AF410 File Offset: 0x000AD610
	public TsAnimNotifyStateVehicleTurnByInput() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVehicleTurnByInput.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004D8F RID: 19855 RVA: 0x000AF438 File Offset: 0x000AD638
	public TsAnimNotifyStateVehicleTurnByInput(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVehicleTurnByInput.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004D90 RID: 19856 RVA: 0x000AF46B File Offset: 0x000AD66B
	protected TsAnimNotifyStateVehicleTurnByInput(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004D91 RID: 19857 RVA: 0x000AF474 File Offset: 0x000AD674
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004D92 RID: 19858 RVA: 0x000AF4B0 File Offset: 0x000AD6B0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004D93 RID: 19859 RVA: 0x000AF4EC File Offset: 0x000AD6EC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004D94 RID: 19860 RVA: 0x000AF51F File Offset: 0x000AD71F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001652 RID: 5714
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x04001653 RID: 5715
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x04001654 RID: 5716
	[StaticVariableRuleIgnore]
	private static readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x04001655 RID: 5717
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001656 RID: 5718
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001657 RID: 5719
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat3 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001658 RID: 5720
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVehicleTurnByInput.TsAnimNotifyStateVehicleTurnByInput_C";

	// Token: 0x04001659 RID: 5721
	private static IntPtr _ClassPtr;

	// Token: 0x0400165A RID: 5722
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400165B RID: 5723
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x0400165C RID: 5724
	private static int __PropertyOffset_EnableMinSpeedFixUp;

	// Token: 0x0400165D RID: 5725
	private static int __PropertyOffset_MinSpeed;

	// Token: 0x0400165E RID: 5726
	private static int __PropertyOffset_EnableRollBalanceFixUp;

	// Token: 0x0400165F RID: 5727
	private static int __PropertyOffset_RollInterpolationSpeed;
}
