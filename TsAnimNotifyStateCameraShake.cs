using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D30 RID: 3376
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraShake.TsAnimNotifyStateCameraShake_C")]
public class TsAnimNotifyStateCameraShake : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000371 RID: 881
	// (get) Token: 0x060045DB RID: 17883 RVA: 0x0008BFD7 File Offset: 0x0008A1D7
	// (set) Token: 0x060045DC RID: 17884 RVA: 0x0008BFEB File Offset: 0x0008A1EB
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
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraShake.__PropertyOffset_震动配置);
		}
		[param: Nullable(new byte[]
		{
			0,
			1
		})]
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraShake.__PropertyOffset_震动配置) = value;
		}
	}

	// Token: 0x17000372 RID: 882
	// (get) Token: 0x060045DD RID: 17885 RVA: 0x0008C000 File Offset: 0x0008A200
	// (set) Token: 0x060045DE RID: 17886 RVA: 0x0008C039 File Offset: 0x0008A239
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer ExcludeTag
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._ExcludeTag) == null)
			{
				result = (this._ExcludeTag = new FGameplayTagContainer(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraShake.__PropertyOffset_ExcludeTag, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateCameraShake.__PropertyOffset_ExcludeTag, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x060045DF RID: 17887 RVA: 0x0008C064 File Offset: 0x0008A264
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

	// Token: 0x060045E0 RID: 17888 RVA: 0x0008C10C File Offset: 0x0008A30C
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter) && !(owner is TsBaseVehicle))
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		int num;
		if (tsBaseCharacter == null)
		{
			TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
			if (tsBaseVehicle == null)
			{
				num = 0;
			}
			else
			{
				num = tsBaseVehicle.EntityId;
			}
		}
		else
		{
			num = tsBaseCharacter.EntityId;
		}
		int entityId = num;
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
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
		TsBaseCharacter tsBaseCharacter2 = owner as TsBaseCharacter;
		Entity entity;
		if (tsBaseCharacter2 == null)
		{
			TsBaseVehicle tsBaseVehicle2 = owner as TsBaseVehicle;
			if (tsBaseVehicle2 == null)
			{
				entity = null;
			}
			else
			{
				entity = tsBaseVehicle2.GetEntityNoBlueprint();
			}
		}
		else
		{
			entity = tsBaseCharacter2.GetEntityNoBlueprint();
		}
		Entity entity2 = entity;
		BaseTagComponent baseTagComponent = (entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent == null || !baseTagComponent.HasAnyTagContainer(this.ExcludeTag))
		{
			int cameraShakeInstanceId;
			if (this.CameraShakeInstanceIdMap.TryGetValue(meshComp, out cameraShakeInstanceId))
			{
				ControllerBase<CameraController>.Instance.StopCameraShake(cameraShakeInstanceId, true, "MainCamera");
			}
			this.CameraShakeInstanceIdMap[meshComp] = ControllerBase<CameraController>.Instance.PlayCameraShake(this.震动配置.Get().ToWeakClass(), new float?(ControllerBase<CameraController>.Instance.MainModel.ShakeModify), new ECameraShakePlaySpace?(ECameraShakePlaySpace.CameraLocal), null, true, true, "MainCamera");
		}
		else
		{
			this.PlayingForceFeedback.Add(meshComp);
			ControllerBase<CameraController>.Instance.PlayForceFeedbackFromCameraShake(new TSubclassOf<UCameraShakeBase>?(this.震动配置.As<UCameraShakeBase>()), "MainCamera");
		}
		return true;
	}

	// Token: 0x060045E1 RID: 17889 RVA: 0x0008C2E0 File Offset: 0x0008A4E0
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

	// Token: 0x060045E2 RID: 17890 RVA: 0x0008C380 File Offset: 0x0008A580
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int cameraShakeInstanceId;
		if (this.CameraShakeInstanceIdMap.TryGetValue(meshComp, out cameraShakeInstanceId))
		{
			ControllerBase<CameraController>.Instance.StopCameraShake(cameraShakeInstanceId, true, "MainCamera");
			this.CameraShakeInstanceIdMap.Remove(meshComp);
		}
		if (this.PlayingForceFeedback.Contains(meshComp))
		{
			ControllerBase<CameraController>.Instance.StopForceFeedbackFromCameraShake(new TSubclassOf<UCameraShakeBase>?(this.震动配置.Get()), "MainCamera");
			this.PlayingForceFeedback.Remove(meshComp);
		}
		return true;
	}

	// Token: 0x060045E3 RID: 17891 RVA: 0x0008C400 File Offset: 0x0008A600
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

	// Token: 0x060045E4 RID: 17892 RVA: 0x0008C47B File Offset: 0x0008A67B
	protected override string GetNotifyName_Implementation()
	{
		return "相机震屏ANS";
	}

	// Token: 0x060045E5 RID: 17893 RVA: 0x0008C482 File Offset: 0x0008A682
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCameraShake._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraShake.TsAnimNotifyStateCameraShake_C");
		}
		return TsAnimNotifyStateCameraShake._ClassPtr;
	}

	// Token: 0x060045E6 RID: 17894 RVA: 0x0008C4A8 File Offset: 0x0008A6A8
	public TsAnimNotifyStateCameraShake() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraShake.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060045E7 RID: 17895 RVA: 0x0008C4D0 File Offset: 0x0008A6D0
	public TsAnimNotifyStateCameraShake(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraShake.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060045E8 RID: 17896 RVA: 0x0008C503 File Offset: 0x0008A703
	protected TsAnimNotifyStateCameraShake(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060045E9 RID: 17897 RVA: 0x0008C524 File Offset: 0x0008A724
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060045EA RID: 17898 RVA: 0x0008C560 File Offset: 0x0008A760
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060045EB RID: 17899 RVA: 0x0008C593 File Offset: 0x0008A793
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012CD RID: 4813
	private readonly Dictionary<USkeletalMeshComponent, int> CameraShakeInstanceIdMap = new Dictionary<USkeletalMeshComponent, int>();

	// Token: 0x040012CE RID: 4814
	private readonly HashSet<USkeletalMeshComponent> PlayingForceFeedback = new HashSet<USkeletalMeshComponent>();

	// Token: 0x040012CF RID: 4815
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraShake.TsAnimNotifyStateCameraShake_C";

	// Token: 0x040012D0 RID: 4816
	private static IntPtr _ClassPtr;

	// Token: 0x040012D1 RID: 4817
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012D2 RID: 4818
	private static int __PropertyOffset_震动配置;

	// Token: 0x040012D3 RID: 4819
	private static int __PropertyOffset_ExcludeTag;

	// Token: 0x040012D4 RID: 4820
	[Nullable(2)]
	private FGameplayTagContainer _ExcludeTag;
}
