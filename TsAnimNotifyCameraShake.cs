using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB3 RID: 3507
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraShake.TsAnimNotifyCameraShake_C")]
public class TsAnimNotifyCameraShake : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000502 RID: 1282
	// (get) Token: 0x06004F3F RID: 20287 RVA: 0x000B5C13 File Offset: 0x000B3E13
	// (set) Token: 0x06004F40 RID: 20288 RVA: 0x000B5C27 File Offset: 0x000B3E27
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TSubclassOf<UMatineeCameraShake> 震动配置
	{
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraShake.__PropertyOffset_震动配置);
		}
		[param: Nullable(new byte[]
		{
			0,
			1
		})]
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraShake.__PropertyOffset_震动配置) = value;
		}
	}

	// Token: 0x17000503 RID: 1283
	// (get) Token: 0x06004F41 RID: 20289 RVA: 0x000B5C3C File Offset: 0x000B3E3C
	// (set) Token: 0x06004F42 RID: 20290 RVA: 0x000B5C4C File Offset: 0x000B3E4C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bForSelf
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraShake.__PropertyOffset_bForSelf) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraShake.__PropertyOffset_bForSelf) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000504 RID: 1284
	// (get) Token: 0x06004F43 RID: 20291 RVA: 0x000B5C5D File Offset: 0x000B3E5D
	// (set) Token: 0x06004F44 RID: 20292 RVA: 0x000B5C6D File Offset: 0x000B3E6D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Radius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCameraShake.__PropertyOffset_Radius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCameraShake.__PropertyOffset_Radius) = value;
		}
	}

	// Token: 0x06004F45 RID: 20293 RVA: 0x000B5C80 File Offset: 0x000B3E80
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x06004F46 RID: 20294 RVA: 0x000B5D20 File Offset: 0x000B3F20
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
		if (tsBaseCharacter == null && tsBaseVehicle == null)
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((tsBaseCharacter != null) ? tsBaseCharacter.EntityId : tsBaseVehicle.EntityId);
		if (entityById == null || !entityById.Valid)
		{
			return false;
		}
		if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById))
		{
			return false;
		}
		if (!CameraUtility.CheckCameraShakeCondition(entityById))
		{
			return false;
		}
		ECustomCameraMode? cameraMode = ControllerBase<CameraController>.Instance.MainModel.CameraMode;
		ECustomCameraMode ecustomCameraMode = ECustomCameraMode.LockOn;
		if (!(cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null))
		{
			return false;
		}
		if (!ControllerBase<CameraController>.Instance.GetMainPlayerCameraManager().IsValid())
		{
			return false;
		}
		if (this.bForSelf)
		{
			ControllerBase<CameraController>.Instance.PlayCameraShake(this.震动配置.Get().ToClass(), new float?(ControllerBase<CameraController>.Instance.MainModel.ShakeModify), new ECameraShakePlaySpace?(ECameraShakePlaySpace.CameraLocal), null, true, false, "MainCamera");
		}
		else
		{
			CameraController instance = ControllerBase<CameraController>.Instance;
			TSubclassOf<UCameraShakeBase> shakeClass = this.震动配置.Get().ToClass();
			AActor owner2 = meshComp.GetOwner();
			instance.PlayWorldCameraShake(shakeClass, (owner2 != null) ? new FVectorDouble?(owner2.D_K2_GetActorLocation()) : null, this.Radius, this.Radius, 1f, true, "MainCamera");
		}
		return true;
	}

	// Token: 0x06004F47 RID: 20295 RVA: 0x000B5E80 File Offset: 0x000B4080
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004F48 RID: 20296 RVA: 0x000B5EFB File Offset: 0x000B40FB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "相机震屏";
	}

	// Token: 0x06004F49 RID: 20297 RVA: 0x000B5F02 File Offset: 0x000B4102
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyCameraShake._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraShake.TsAnimNotifyCameraShake_C");
		}
		return TsAnimNotifyCameraShake._ClassPtr;
	}

	// Token: 0x06004F4A RID: 20298 RVA: 0x000B5F28 File Offset: 0x000B4128
	public TsAnimNotifyCameraShake() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraShake.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F4B RID: 20299 RVA: 0x000B5F50 File Offset: 0x000B4150
	[NullableContext(1)]
	public TsAnimNotifyCameraShake(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraShake.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F4C RID: 20300 RVA: 0x000B5F83 File Offset: 0x000B4183
	protected TsAnimNotifyCameraShake(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F4D RID: 20301 RVA: 0x000B5F8C File Offset: 0x000B418C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F4E RID: 20302 RVA: 0x000B5FBF File Offset: 0x000B41BF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001714 RID: 5908
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraShake.TsAnimNotifyCameraShake_C";

	// Token: 0x04001715 RID: 5909
	private static IntPtr _ClassPtr;

	// Token: 0x04001716 RID: 5910
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001717 RID: 5911
	private static int __PropertyOffset_震动配置;

	// Token: 0x04001718 RID: 5912
	private static int __PropertyOffset_bForSelf;

	// Token: 0x04001719 RID: 5913
	private static int __PropertyOffset_Radius;
}
