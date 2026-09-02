using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D2A RID: 3370
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBonesShowControl.TsAnimNotifyStateBonesShowControl_C")]
public class TsAnimNotifyStateBonesShowControl : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06004556 RID: 17750 RVA: 0x00089C97 File Offset: 0x00087E97
	// (set) Token: 0x06004557 RID: 17751 RVA: 0x00089CA7 File Offset: 0x00087EA7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EndPlay
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateBonesShowControl.__PropertyOffset_EndPlay) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateBonesShowControl.__PropertyOffset_EndPlay) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06004558 RID: 17752 RVA: 0x00089CB8 File Offset: 0x00087EB8
	// (set) Token: 0x06004559 RID: 17753 RVA: 0x00089CCC File Offset: 0x00087ECC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName BoneName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateBonesShowControl.__PropertyOffset_BoneName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateBonesShowControl.__PropertyOffset_BoneName) = value;
		}
	}

	// Token: 0x0600455A RID: 17754 RVA: 0x00089CE4 File Offset: 0x00087EE4
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

	// Token: 0x0600455B RID: 17755 RVA: 0x00089D8C File Offset: 0x00087F8C
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
			if (entity == null || !entity.Valid)
			{
				return false;
			}
			if (!meshComp.IsBoneHiddenByName(this.BoneName))
			{
				meshComp.HideBoneByName(this.BoneName, EPhysBodyOp.PBO_None);
				CharacterWeaponComponent component = entity.GetComponent<CharacterWeaponComponent>();
				if (component != null)
				{
					component.HideWeaponsWhenHideBones(true, this.BoneName);
				}
			}
		}
		return false;
	}

	// Token: 0x0600455C RID: 17756 RVA: 0x00089E00 File Offset: 0x00088000
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

	// Token: 0x0600455D RID: 17757 RVA: 0x00089EA0 File Offset: 0x000880A0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity == null || !entity.Valid)
			{
				return false;
			}
			if (meshComp.IsBoneHiddenByName(this.BoneName))
			{
				meshComp.UnHideBoneByName(this.BoneName);
				CharacterWeaponComponent component = entity.GetComponent<CharacterWeaponComponent>();
				if (component != null)
				{
					component.HideWeaponsWhenHideBones(false, this.BoneName);
				}
			}
		}
		return false;
	}

	// Token: 0x0600455E RID: 17758 RVA: 0x00089F1C File Offset: 0x0008811C
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

	// Token: 0x0600455F RID: 17759 RVA: 0x00089F97 File Offset: 0x00088197
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "骨骼显示控制";
	}

	// Token: 0x06004560 RID: 17760 RVA: 0x00089F9E File Offset: 0x0008819E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateBonesShowControl._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBonesShowControl.TsAnimNotifyStateBonesShowControl_C");
		}
		return TsAnimNotifyStateBonesShowControl._ClassPtr;
	}

	// Token: 0x06004561 RID: 17761 RVA: 0x00089FC4 File Offset: 0x000881C4
	public TsAnimNotifyStateBonesShowControl() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBonesShowControl.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004562 RID: 17762 RVA: 0x00089FEC File Offset: 0x000881EC
	[NullableContext(1)]
	public TsAnimNotifyStateBonesShowControl(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBonesShowControl.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004563 RID: 17763 RVA: 0x0008A01F File Offset: 0x0008821F
	protected TsAnimNotifyStateBonesShowControl(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004564 RID: 17764 RVA: 0x0008A028 File Offset: 0x00088228
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004565 RID: 17765 RVA: 0x0008A064 File Offset: 0x00088264
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004566 RID: 17766 RVA: 0x0008A097 File Offset: 0x00088297
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001292 RID: 4754
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBonesShowControl.TsAnimNotifyStateBonesShowControl_C";

	// Token: 0x04001293 RID: 4755
	private static IntPtr _ClassPtr;

	// Token: 0x04001294 RID: 4756
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001295 RID: 4757
	private static int __PropertyOffset_EndPlay;

	// Token: 0x04001296 RID: 4758
	private static int __PropertyOffset_BoneName;
}
