using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D50 RID: 3408
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideBone.TsAnimNotifyStateHideBone_C")]
public class TsAnimNotifyStateHideBone : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003E0 RID: 992
	// (get) Token: 0x0600483E RID: 18494 RVA: 0x000988E3 File Offset: 0x00096AE3
	// (set) Token: 0x0600483F RID: 18495 RVA: 0x000988F7 File Offset: 0x00096AF7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BoneName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateHideBone.__PropertyOffset_BoneName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateHideBone.__PropertyOffset_BoneName)), value);
		}
	}

	// Token: 0x170003E1 RID: 993
	// (get) Token: 0x06004840 RID: 18496 RVA: 0x0009890C File Offset: 0x00096B0C
	// (set) Token: 0x06004841 RID: 18497 RVA: 0x00098920 File Offset: 0x00096B20
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string IgnoreTsBaseCharacter
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateHideBone.__PropertyOffset_IgnoreTsBaseCharacter)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateHideBone.__PropertyOffset_IgnoreTsBaseCharacter)), value);
		}
	}

	// Token: 0x06004842 RID: 18498 RVA: 0x00098938 File Offset: 0x00096B38
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

	// Token: 0x06004843 RID: 18499 RVA: 0x000989E0 File Offset: 0x00096BE0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (!string.IsNullOrEmpty(this.IgnoreTsBaseCharacter))
		{
			MeshComponentUtils.HideBone(meshComp, this.BoneName, true);
			return true;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterAnimationComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
			if (component != null)
			{
				component.HideBone(FNameUtil.GetDynamicFName(this.BoneName).Value, true, false);
			}
		}
		return true;
	}

	// Token: 0x06004844 RID: 18500 RVA: 0x00098A4C File Offset: 0x00096C4C
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

	// Token: 0x06004845 RID: 18501 RVA: 0x00098AEC File Offset: 0x00096CEC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!string.IsNullOrEmpty(this.IgnoreTsBaseCharacter))
		{
			MeshComponentUtils.HideBone(meshComp, this.BoneName, false);
			return true;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			CharacterAnimationComponent characterAnimationComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>() : null;
			if (characterAnimationComponent != null)
			{
				characterAnimationComponent.HideBone(FNameUtil.GetDynamicFName(this.BoneName).Value, false, false);
			}
		}
		return true;
	}

	// Token: 0x06004846 RID: 18502 RVA: 0x00098B5C File Offset: 0x00096D5C
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

	// Token: 0x06004847 RID: 18503 RVA: 0x00098BD7 File Offset: 0x00096DD7
	protected override string GetNotifyName_Implementation()
	{
		return "隐藏骨骼";
	}

	// Token: 0x06004848 RID: 18504 RVA: 0x00098BDE File Offset: 0x00096DDE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateHideBone._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideBone.TsAnimNotifyStateHideBone_C");
		}
		return TsAnimNotifyStateHideBone._ClassPtr;
	}

	// Token: 0x06004849 RID: 18505 RVA: 0x00098C04 File Offset: 0x00096E04
	public TsAnimNotifyStateHideBone() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideBone.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600484A RID: 18506 RVA: 0x00098C2C File Offset: 0x00096E2C
	public TsAnimNotifyStateHideBone(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideBone.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600484B RID: 18507 RVA: 0x00098C5F File Offset: 0x00096E5F
	protected TsAnimNotifyStateHideBone(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600484C RID: 18508 RVA: 0x00098C68 File Offset: 0x00096E68
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600484D RID: 18509 RVA: 0x00098CA4 File Offset: 0x00096EA4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600484E RID: 18510 RVA: 0x00098CD7 File Offset: 0x00096ED7
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001416 RID: 5142
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideBone.TsAnimNotifyStateHideBone_C";

	// Token: 0x04001417 RID: 5143
	private static IntPtr _ClassPtr;

	// Token: 0x04001418 RID: 5144
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001419 RID: 5145
	private static int __PropertyOffset_BoneName;

	// Token: 0x0400141A RID: 5146
	private static int __PropertyOffset_IgnoreTsBaseCharacter;
}
