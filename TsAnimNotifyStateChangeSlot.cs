using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D34 RID: 3380
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateChangeSlot.TsAnimNotifyStateChangeSlot_C")]
public class TsAnimNotifyStateChangeSlot : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000379 RID: 889
	// (get) Token: 0x06004622 RID: 17954 RVA: 0x0008D4AB File Offset: 0x0008B6AB
	// (set) Token: 0x06004623 RID: 17955 RVA: 0x0008D4BF File Offset: 0x0008B6BF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ComponentName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateChangeSlot.__PropertyOffset_ComponentName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateChangeSlot.__PropertyOffset_ComponentName)), value);
		}
	}

	// Token: 0x1700037A RID: 890
	// (get) Token: 0x06004624 RID: 17956 RVA: 0x0008D4D4 File Offset: 0x0008B6D4
	// (set) Token: 0x06004625 RID: 17957 RVA: 0x0008D4E8 File Offset: 0x0008B6E8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SwitchToSlotName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateChangeSlot.__PropertyOffset_SwitchToSlotName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateChangeSlot.__PropertyOffset_SwitchToSlotName) = value;
		}
	}

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x06004626 RID: 17958 RVA: 0x0008D4FD File Offset: 0x0008B6FD
	// (set) Token: 0x06004627 RID: 17959 RVA: 0x0008D511 File Offset: 0x0008B711
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FTransform SlotTransform
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateChangeSlot.__PropertyOffset_SlotTransform);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateChangeSlot.__PropertyOffset_SlotTransform) = value;
		}
	}

	// Token: 0x06004628 RID: 17960 RVA: 0x0008D528 File Offset: 0x0008B728
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

	// Token: 0x06004629 RID: 17961 RVA: 0x0008D5D0 File Offset: 0x0008B7D0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
		SubMeshComponent subMeshComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<SubMeshComponent>() : null;
		if (subMeshComponent != null)
		{
			subMeshComponent.SetSubMeshAttach(this.ComponentName, this.SwitchToSlotName, this.SlotTransform);
		}
		return true;
	}

	// Token: 0x0600462A RID: 17962 RVA: 0x0008D624 File Offset: 0x0008B824
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

	// Token: 0x0600462B RID: 17963 RVA: 0x0008D6C4 File Offset: 0x0008B8C4
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
		SubMeshComponent subMeshComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<SubMeshComponent>() : null;
		if (subMeshComponent != null)
		{
			subMeshComponent.ResetSubMeshAttach(this.ComponentName);
		}
		return true;
	}

	// Token: 0x0600462C RID: 17964 RVA: 0x0008D70C File Offset: 0x0008B90C
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

	// Token: 0x0600462D RID: 17965 RVA: 0x0008D787 File Offset: 0x0008B987
	protected override string GetNotifyName_Implementation()
	{
		return "切换组件到指定插槽";
	}

	// Token: 0x0600462E RID: 17966 RVA: 0x0008D78E File Offset: 0x0008B98E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateChangeSlot._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateChangeSlot.TsAnimNotifyStateChangeSlot_C");
		}
		return TsAnimNotifyStateChangeSlot._ClassPtr;
	}

	// Token: 0x0600462F RID: 17967 RVA: 0x0008D7B4 File Offset: 0x0008B9B4
	public TsAnimNotifyStateChangeSlot() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateChangeSlot.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004630 RID: 17968 RVA: 0x0008D7DC File Offset: 0x0008B9DC
	public TsAnimNotifyStateChangeSlot(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateChangeSlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004631 RID: 17969 RVA: 0x0008D80F File Offset: 0x0008BA0F
	protected TsAnimNotifyStateChangeSlot(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004632 RID: 17970 RVA: 0x0008D818 File Offset: 0x0008BA18
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004633 RID: 17971 RVA: 0x0008D854 File Offset: 0x0008BA54
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004634 RID: 17972 RVA: 0x0008D887 File Offset: 0x0008BA87
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012E9 RID: 4841
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateChangeSlot.TsAnimNotifyStateChangeSlot_C";

	// Token: 0x040012EA RID: 4842
	private static IntPtr _ClassPtr;

	// Token: 0x040012EB RID: 4843
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012EC RID: 4844
	private static int __PropertyOffset_ComponentName;

	// Token: 0x040012ED RID: 4845
	private static int __PropertyOffset_SwitchToSlotName;

	// Token: 0x040012EE RID: 4846
	private static int __PropertyOffset_SlotTransform;
}
