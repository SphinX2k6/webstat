using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D5E RID: 3422
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMontageSpeedChange.TsAnimNotifyStateMontageSpeedChange_C")]
public class TsAnimNotifyStateMontageSpeedChange : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x06004929 RID: 18729 RVA: 0x0009CD2F File Offset: 0x0009AF2F
	// (set) Token: 0x0600492A RID: 18730 RVA: 0x0009CD3F File Offset: 0x0009AF3F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MontagePlayRate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateMontageSpeedChange.__PropertyOffset_MontagePlayRate);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateMontageSpeedChange.__PropertyOffset_MontagePlayRate) = value;
		}
	}

	// Token: 0x0600492B RID: 18731 RVA: 0x0009CD50 File Offset: 0x0009AF50
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

	// Token: 0x0600492C RID: 18732 RVA: 0x0009CDF8 File Offset: 0x0009AFF8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			UAnimInstance animInstance = meshComp.GetAnimInstance();
			if (animInstance != null)
			{
				animInstance.Montage_SetPlayRate(null, this.MontagePlayRate);
			}
			return true;
		}
		Entity entityNoBlueprint = ((TsBaseCharacter)owner).GetEntityNoBlueprint();
		if (entityNoBlueprint != null)
		{
			CharacterAnimationComponent component = entityNoBlueprint.GetComponent<CharacterAnimationComponent>();
			if (component != null)
			{
				UAnimInstance mainAnimInstance = component.MainAnimInstance;
				if (mainAnimInstance != null)
				{
					mainAnimInstance.Montage_SetPlayRate(null, this.MontagePlayRate);
				}
			}
		}
		return true;
	}

	// Token: 0x0600492D RID: 18733 RVA: 0x0009CE64 File Offset: 0x0009B064
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

	// Token: 0x0600492E RID: 18734 RVA: 0x0009CF04 File Offset: 0x0009B104
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			UAnimInstance animInstance = meshComp.GetAnimInstance();
			if (animInstance != null)
			{
				animInstance.Montage_SetPlayRate(null, 1f);
			}
			return true;
		}
		Entity entityNoBlueprint = ((TsBaseCharacter)owner).GetEntityNoBlueprint();
		if (entityNoBlueprint != null)
		{
			CharacterAnimationComponent component = entityNoBlueprint.GetComponent<CharacterAnimationComponent>();
			if (component != null)
			{
				UAnimInstance mainAnimInstance = component.MainAnimInstance;
				if (mainAnimInstance != null)
				{
					mainAnimInstance.Montage_SetPlayRate(null, 1f);
				}
			}
		}
		return true;
	}

	// Token: 0x0600492F RID: 18735 RVA: 0x0009CF6C File Offset: 0x0009B16C
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

	// Token: 0x06004930 RID: 18736 RVA: 0x0009CFE7 File Offset: 0x0009B1E7
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "配置蒙太奇播放速度变化";
	}

	// Token: 0x06004931 RID: 18737 RVA: 0x0009CFEE File Offset: 0x0009B1EE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateMontageSpeedChange._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMontageSpeedChange.TsAnimNotifyStateMontageSpeedChange_C");
		}
		return TsAnimNotifyStateMontageSpeedChange._ClassPtr;
	}

	// Token: 0x06004932 RID: 18738 RVA: 0x0009D014 File Offset: 0x0009B214
	public TsAnimNotifyStateMontageSpeedChange() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateMontageSpeedChange.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004933 RID: 18739 RVA: 0x0009D03C File Offset: 0x0009B23C
	[NullableContext(1)]
	public TsAnimNotifyStateMontageSpeedChange(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateMontageSpeedChange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004934 RID: 18740 RVA: 0x0009D06F File Offset: 0x0009B26F
	protected TsAnimNotifyStateMontageSpeedChange(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004935 RID: 18741 RVA: 0x0009D078 File Offset: 0x0009B278
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004936 RID: 18742 RVA: 0x0009D0B4 File Offset: 0x0009B2B4
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004937 RID: 18743 RVA: 0x0009D0E7 File Offset: 0x0009B2E7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400147D RID: 5245
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMontageSpeedChange.TsAnimNotifyStateMontageSpeedChange_C";

	// Token: 0x0400147E RID: 5246
	private static IntPtr _ClassPtr;

	// Token: 0x0400147F RID: 5247
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001480 RID: 5248
	private static int __PropertyOffset_MontagePlayRate;
}
