using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D76 RID: 3446
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRunRotateBoneToLocation.TsAnimNotifyStateRunRotateBoneToLocation_C")]
public class TsAnimNotifyStateRunRotateBoneToLocation : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x06004B17 RID: 19223 RVA: 0x000A55CB File Offset: 0x000A37CB
	// (set) Token: 0x06004B18 RID: 19224 RVA: 0x000A55DF File Offset: 0x000A37DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D TurnLimit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_TurnLimit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_TurnLimit) = value;
		}
	}

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x06004B19 RID: 19225 RVA: 0x000A55F4 File Offset: 0x000A37F4
	// (set) Token: 0x06004B1A RID: 19226 RVA: 0x000A5608 File Offset: 0x000A3808
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D LookUpLimit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_LookUpLimit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_LookUpLimit) = value;
		}
	}

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x06004B1B RID: 19227 RVA: 0x000A561D File Offset: 0x000A381D
	// (set) Token: 0x06004B1C RID: 19228 RVA: 0x000A5631 File Offset: 0x000A3831
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat TurnSpeed
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_TurnSpeed);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_TurnSpeed, value);
		}
	}

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x06004B1D RID: 19229 RVA: 0x000A5646 File Offset: 0x000A3846
	// (set) Token: 0x06004B1E RID: 19230 RVA: 0x000A565A File Offset: 0x000A385A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat LookUpSpeed
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_LookUpSpeed);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_LookUpSpeed, value);
		}
	}

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x06004B1F RID: 19231 RVA: 0x000A566F File Offset: 0x000A386F
	// (set) Token: 0x06004B20 RID: 19232 RVA: 0x000A567F File Offset: 0x000A387F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_TurnOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_TurnOffset) = value;
		}
	}

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x06004B21 RID: 19233 RVA: 0x000A5690 File Offset: 0x000A3890
	// (set) Token: 0x06004B22 RID: 19234 RVA: 0x000A56A0 File Offset: 0x000A38A0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LookUpOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_LookUpOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRunRotateBoneToLocation.__PropertyOffset_LookUpOffset) = value;
		}
	}

	// Token: 0x06004B23 RID: 19235 RVA: 0x000A56B4 File Offset: 0x000A38B4
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

	// Token: 0x06004B24 RID: 19236 RVA: 0x000A575C File Offset: 0x000A395C
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			if ((owner as TsBaseCharacter).CharacterActorComponent == null)
			{
				return false;
			}
			Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
			CharacterAnimationComponent characterAnimationComponent = (entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null;
			if (characterAnimationComponent == null || characterAnimationComponent.MainAnimInstance == null || !(characterAnimationComponent.MainAnimInstance is UKuroAnimInstance))
			{
				return false;
			}
			float turnAngle = 1f;
			if (this.TurnSpeed != null)
			{
				turnAngle = this.TurnSpeed.GetFloatValue(0f);
			}
			float lookUpAngle = 1f;
			if (this.LookUpSpeed != null)
			{
				lookUpAngle = this.LookUpSpeed.GetFloatValue(0f);
			}
			(characterAnimationComponent.MainAnimInstance as UKuroAnimInstance).SetBoneRotateToLocationInfoRunBegin(turnAngle, lookUpAngle, this.TurnLimit, this.LookUpLimit, this.TurnOffset, this.LookUpOffset);
		}
		return true;
	}

	// Token: 0x06004B25 RID: 19237 RVA: 0x000A582C File Offset: 0x000A3A2C
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

	// Token: 0x06004B26 RID: 19238 RVA: 0x000A58CC File Offset: 0x000A3ACC
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			if ((owner as TsBaseCharacter).CharacterActorComponent == null)
			{
				return false;
			}
			Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
			CharacterAnimationComponent characterAnimationComponent = (entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null;
			if (characterAnimationComponent == null || characterAnimationComponent.MainAnimInstance == null || !(characterAnimationComponent.MainAnimInstance is UKuroAnimInstance))
			{
				return false;
			}
			(characterAnimationComponent.MainAnimInstance as UKuroAnimInstance).SetBoneRotateToLocationInfoRunEnd();
		}
		return true;
	}

	// Token: 0x06004B27 RID: 19239 RVA: 0x000A5940 File Offset: 0x000A3B40
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

	// Token: 0x06004B28 RID: 19240 RVA: 0x000A59E8 File Offset: 0x000A3BE8
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			CharacterAnimationComponent characterAnimationComponent;
			if (characterActorComponent == null)
			{
				characterAnimationComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterAnimationComponent = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
			if (characterAnimationComponent2 != null && characterAnimationComponent2.MainAnimInstance != null)
			{
				UKuroAnimInstance ukuroAnimInstance = characterAnimationComponent2.MainAnimInstance as UKuroAnimInstance;
				if (ukuroAnimInstance != null)
				{
					float currentTriggerOffsetInThisNotifyTick = base.GetCurrentTriggerOffsetInThisNotifyTick();
					float turnAngle = 1f;
					if (this.TurnSpeed != null)
					{
						turnAngle = this.TurnSpeed.GetFloatValue(currentTriggerOffsetInThisNotifyTick);
					}
					float lookUpAngle = 1f;
					if (this.LookUpSpeed != null)
					{
						lookUpAngle = this.LookUpSpeed.GetFloatValue(currentTriggerOffsetInThisNotifyTick);
					}
					ukuroAnimInstance.SetBoneRotateToLocationInfoRunTick(turnAngle, lookUpAngle);
					return true;
				}
			}
			return false;
		}
		return true;
	}

	// Token: 0x06004B29 RID: 19241 RVA: 0x000A5A90 File Offset: 0x000A3C90
	[NullableContext(1)]
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

	// Token: 0x06004B2A RID: 19242 RVA: 0x000A5B0B File Offset: 0x000A3D0B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "控制一根骨骼朝向目标";
	}

	// Token: 0x06004B2B RID: 19243 RVA: 0x000A5B12 File Offset: 0x000A3D12
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRunRotateBoneToLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRunRotateBoneToLocation.TsAnimNotifyStateRunRotateBoneToLocation_C");
		}
		return TsAnimNotifyStateRunRotateBoneToLocation._ClassPtr;
	}

	// Token: 0x06004B2C RID: 19244 RVA: 0x000A5B38 File Offset: 0x000A3D38
	public TsAnimNotifyStateRunRotateBoneToLocation() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRunRotateBoneToLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004B2D RID: 19245 RVA: 0x000A5B60 File Offset: 0x000A3D60
	[NullableContext(1)]
	public TsAnimNotifyStateRunRotateBoneToLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRunRotateBoneToLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004B2E RID: 19246 RVA: 0x000A5B93 File Offset: 0x000A3D93
	protected TsAnimNotifyStateRunRotateBoneToLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004B2F RID: 19247 RVA: 0x000A5B9C File Offset: 0x000A3D9C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004B30 RID: 19248 RVA: 0x000A5BD8 File Offset: 0x000A3DD8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004B31 RID: 19249 RVA: 0x000A5C0C File Offset: 0x000A3E0C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004B32 RID: 19250 RVA: 0x000A5C45 File Offset: 0x000A3E45
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400156D RID: 5485
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRunRotateBoneToLocation.TsAnimNotifyStateRunRotateBoneToLocation_C";

	// Token: 0x0400156E RID: 5486
	private static IntPtr _ClassPtr;

	// Token: 0x0400156F RID: 5487
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001570 RID: 5488
	private static int __PropertyOffset_TurnLimit;

	// Token: 0x04001571 RID: 5489
	private static int __PropertyOffset_LookUpLimit;

	// Token: 0x04001572 RID: 5490
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04001573 RID: 5491
	private static int __PropertyOffset_LookUpSpeed;

	// Token: 0x04001574 RID: 5492
	private static int __PropertyOffset_TurnOffset;

	// Token: 0x04001575 RID: 5493
	private static int __PropertyOffset_LookUpOffset;
}
