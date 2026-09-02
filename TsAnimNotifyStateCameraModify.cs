using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D2E RID: 3374
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraModify.TsAnimNotifyStateCameraModify_C")]
public class TsAnimNotifyStateCameraModify : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000362 RID: 866
	// (get) Token: 0x0600459F RID: 17823 RVA: 0x0008B16F File Offset: 0x0008936F
	// (set) Token: 0x060045A0 RID: 17824 RVA: 0x0008B183 File Offset: 0x00089383
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x060045A1 RID: 17825 RVA: 0x0008B198 File Offset: 0x00089398
	// (set) Token: 0x060045A2 RID: 17826 RVA: 0x0008B1A8 File Offset: 0x000893A8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 淡入时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡入时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡入时间) = value;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x060045A3 RID: 17827 RVA: 0x0008B1B9 File Offset: 0x000893B9
	// (set) Token: 0x060045A4 RID: 17828 RVA: 0x0008B1C9 File Offset: 0x000893C9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 淡出时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡出时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡出时间) = value;
		}
	}

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x060045A5 RID: 17829 RVA: 0x0008B1DC File Offset: 0x000893DC
	// (set) Token: 0x060045A6 RID: 17830 RVA: 0x0008B215 File Offset: 0x00089415
	[UProperty(EPropertyFlags.CPF_None)]
	public SBaseCurve 淡入曲线
	{
		get
		{
			base.FastCheckIsValid();
			SBaseCurve result;
			if ((result = this._淡入曲线) == null)
			{
				result = (this._淡入曲线 = new SBaseCurve(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡入曲线, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡入曲线, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x060045A7 RID: 17831 RVA: 0x0008B240 File Offset: 0x00089440
	// (set) Token: 0x060045A8 RID: 17832 RVA: 0x0008B279 File Offset: 0x00089479
	[UProperty(EPropertyFlags.CPF_None)]
	public SBaseCurve 淡出曲线
	{
		get
		{
			base.FastCheckIsValid();
			SBaseCurve result;
			if ((result = this._淡出曲线) == null)
			{
				result = (this._淡出曲线 = new SBaseCurve(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡出曲线, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_淡出曲线, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x060045A9 RID: 17833 RVA: 0x0008B2A1 File Offset: 0x000894A1
	// (set) Token: 0x060045AA RID: 17834 RVA: 0x0008B2B1 File Offset: 0x000894B1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 打断淡出时间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_打断淡出时间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_打断淡出时间) = value;
		}
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x060045AB RID: 17835 RVA: 0x0008B2C4 File Offset: 0x000894C4
	// (set) Token: 0x060045AC RID: 17836 RVA: 0x0008B2FD File Offset: 0x000894FD
	[UProperty(EPropertyFlags.CPF_None)]
	public SCameraModifier_Settings 相机修改配置
	{
		get
		{
			base.FastCheckIsValid();
			SCameraModifier_Settings result;
			if ((result = this._相机修改配置) == null)
			{
				result = (this._相机修改配置 = new SCameraModifier_Settings(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_相机修改配置, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_相机修改配置, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000369 RID: 873
	// (get) Token: 0x060045AD RID: 17837 RVA: 0x0008B325 File Offset: 0x00089525
	// (set) Token: 0x060045AE RID: 17838 RVA: 0x0008B335 File Offset: 0x00089535
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECameraAnsEffectiveClientType 生效客户端类型
	{
		get
		{
			return (ECameraAnsEffectiveClientType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_生效客户端类型));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_生效客户端类型) = (byte)value;
		}
	}

	// Token: 0x1700036A RID: 874
	// (get) Token: 0x060045AF RID: 17839 RVA: 0x0008B346 File Offset: 0x00089546
	// (set) Token: 0x060045B0 RID: 17840 RVA: 0x0008B35A File Offset: 0x0008955A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CameraAttachSocket
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_CameraAttachSocket)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_CameraAttachSocket)), value);
		}
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x060045B1 RID: 17841 RVA: 0x0008B370 File Offset: 0x00089570
	// (set) Token: 0x060045B2 RID: 17842 RVA: 0x0008B3A9 File Offset: 0x000895A9
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SCameraModifier_Condition> 条件
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SCameraModifier_Condition> result;
			if ((result = this._条件) == null)
			{
				result = (this._条件 = new TArray<SCameraModifier_Condition>(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_条件, this));
			}
			return result;
		}
		set
		{
			this.条件.CopyAssign(value);
		}
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x060045B3 RID: 17843 RVA: 0x0008B3B7 File Offset: 0x000895B7
	// (set) Token: 0x060045B4 RID: 17844 RVA: 0x0008B3C7 File Offset: 0x000895C7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 打断后继续
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_打断后继续) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCameraModify.__PropertyOffset_打断后继续) = (value ? 1 : 0);
		}
	}

	// Token: 0x060045B5 RID: 17845 RVA: 0x0008B3D8 File Offset: 0x000895D8
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

	// Token: 0x060045B6 RID: 17846 RVA: 0x0008B480 File Offset: 0x00089680
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter) && !(owner is TsBaseVehicle))
		{
			return false;
		}
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((owner as TsBaseCharacter).EntityId);
		if (entityById == null || !entityById.Valid)
		{
			return false;
		}
		this.IsStopByCharacterType = !CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById);
		return !this.IsStopByCharacterType && this.CheckAndPlayCameraModify(meshComp, animation, entityById);
	}

	// Token: 0x060045B7 RID: 17847 RVA: 0x0008B520 File Offset: 0x00089720
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float deltaTime)
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
			ptr2->FrameDeltaTime = deltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060045B8 RID: 17848 RVA: 0x0008B5C8 File Offset: 0x000897C8
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float deltaTime)
	{
		if (!this.打断后继续)
		{
			return true;
		}
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
		if (tsBaseCharacter == null && tsBaseVehicle == null)
		{
			return false;
		}
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return false;
		}
		if (fightCameraLogicComponent.HasCameraModify())
		{
			return true;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((tsBaseCharacter != null) ? tsBaseCharacter.EntityId : tsBaseVehicle.EntityId);
		return entityById != null && entityById.Valid && !this.IsStopByCharacterType && this.CheckAndPlayCameraModify(meshComp, animation, entityById);
	}

	// Token: 0x060045B9 RID: 17849 RVA: 0x0008B678 File Offset: 0x00089878
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

	// Token: 0x060045BA RID: 17850 RVA: 0x0008B718 File Offset: 0x00089918
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter) && !(owner is TsBaseVehicle))
		{
			return false;
		}
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return false;
		}
		fightCameraLogicComponent.StopCameraModify(animation, this.ModifyInstance);
		return true;
	}

	// Token: 0x060045BB RID: 17851 RVA: 0x0008B77C File Offset: 0x0008997C
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

	// Token: 0x060045BC RID: 17852 RVA: 0x0008B7F7 File Offset: 0x000899F7
	protected override string GetNotifyName_Implementation()
	{
		return "ModifyANS镜头";
	}

	// Token: 0x060045BD RID: 17853 RVA: 0x0008B800 File Offset: 0x00089A00
	private bool CheckAndPlayCameraModify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, EntityHandle entityHandle)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter) && !(owner is TsBaseVehicle))
		{
			return false;
		}
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
		if (fightCameraLogicComponent == null || !fightCameraLogicComponent.Valid)
		{
			return false;
		}
		if (CameraUtility.CheckApplyCameraModifyCondition(entityHandle, this.相机修改配置, this.生效客户端类型, this.条件))
		{
			OneOf<TsBaseCharacter, TsBaseVehicle> newLookAtActor = default(OneOf<TsBaseCharacter, TsBaseVehicle>);
			if (this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.锁定目标客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.仇恨目标客户端_角色为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_载具为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_载具为中心_)
			{
				newLookAtActor = (owner as TsBaseCharacter);
				if (this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_声骸为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_声骸为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.单客户端_伴生物为中心_ && this.生效客户端类型 != ECameraAnsEffectiveClientType.全客户端_伴生物为中心_)
				{
					this.相机修改配置.IsLockInput = true;
					this.相机修改配置.OverrideCameraInput = true;
				}
			}
			this.ModifyInstance = fightCameraLogicComponent.ApplyCameraModify(new FGameplayTag?(this.Tag), 100f, this.淡入时间, this.淡出时间, this.相机修改配置, animation, this.打断淡出时间, this.淡入曲线, this.淡出曲线, newLookAtActor, this.CameraAttachSocket.ToString(), owner as TsBaseCharacter);
		}
		return true;
	}

	// Token: 0x060045BE RID: 17854 RVA: 0x0008B955 File Offset: 0x00089B55
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCameraModify._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraModify.TsAnimNotifyStateCameraModify_C");
		}
		return TsAnimNotifyStateCameraModify._ClassPtr;
	}

	// Token: 0x060045BF RID: 17855 RVA: 0x0008B97C File Offset: 0x00089B7C
	public TsAnimNotifyStateCameraModify() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraModify.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060045C0 RID: 17856 RVA: 0x0008B9A4 File Offset: 0x00089BA4
	public TsAnimNotifyStateCameraModify(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCameraModify.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060045C1 RID: 17857 RVA: 0x0008B9D7 File Offset: 0x00089BD7
	protected TsAnimNotifyStateCameraModify(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060045C2 RID: 17858 RVA: 0x0008B9E0 File Offset: 0x00089BE0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060045C3 RID: 17859 RVA: 0x0008BA1C File Offset: 0x00089C1C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060045C4 RID: 17860 RVA: 0x0008BA58 File Offset: 0x00089C58
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060045C5 RID: 17861 RVA: 0x0008BA8B File Offset: 0x00089C8B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012B1 RID: 4785
	private const int MODIFY_TIME_LENGTH = 100;

	// Token: 0x040012B2 RID: 4786
	private int ModifyInstance;

	// Token: 0x040012B3 RID: 4787
	private bool IsStopByCharacterType;

	// Token: 0x040012B4 RID: 4788
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCameraModify.TsAnimNotifyStateCameraModify_C";

	// Token: 0x040012B5 RID: 4789
	private static IntPtr _ClassPtr;

	// Token: 0x040012B6 RID: 4790
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012B7 RID: 4791
	private static int __PropertyOffset_Tag;

	// Token: 0x040012B8 RID: 4792
	private static int __PropertyOffset_淡入时间;

	// Token: 0x040012B9 RID: 4793
	private static int __PropertyOffset_淡出时间;

	// Token: 0x040012BA RID: 4794
	private static int __PropertyOffset_淡入曲线;

	// Token: 0x040012BB RID: 4795
	[Nullable(2)]
	private SBaseCurve _淡入曲线;

	// Token: 0x040012BC RID: 4796
	private static int __PropertyOffset_淡出曲线;

	// Token: 0x040012BD RID: 4797
	[Nullable(2)]
	private SBaseCurve _淡出曲线;

	// Token: 0x040012BE RID: 4798
	private static int __PropertyOffset_打断淡出时间;

	// Token: 0x040012BF RID: 4799
	private static int __PropertyOffset_相机修改配置;

	// Token: 0x040012C0 RID: 4800
	[Nullable(2)]
	private SCameraModifier_Settings _相机修改配置;

	// Token: 0x040012C1 RID: 4801
	private static int __PropertyOffset_生效客户端类型;

	// Token: 0x040012C2 RID: 4802
	private static int __PropertyOffset_CameraAttachSocket;

	// Token: 0x040012C3 RID: 4803
	private static int __PropertyOffset_条件;

	// Token: 0x040012C4 RID: 4804
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SCameraModifier_Condition> _条件;

	// Token: 0x040012C5 RID: 4805
	private static int __PropertyOffset_打断后继续;
}
