using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D24 RID: 3364
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttachActorToSocket.TsAnimNotifyStateAttachActorToSocket_C")]
public class TsAnimNotifyStateAttachActorToSocket : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000343 RID: 835
	// (get) Token: 0x060044DA RID: 17626 RVA: 0x00087BB3 File Offset: 0x00085DB3
	// (set) Token: 0x060044DB RID: 17627 RVA: 0x00087BC7 File Offset: 0x00085DC7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_SocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_SocketName) = value;
		}
	}

	// Token: 0x17000344 RID: 836
	// (get) Token: 0x060044DC RID: 17628 RVA: 0x00087BDC File Offset: 0x00085DDC
	// (set) Token: 0x060044DD RID: 17629 RVA: 0x00087BF0 File Offset: 0x00085DF0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName ActorTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_ActorTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_ActorTag) = value;
		}
	}

	// Token: 0x17000345 RID: 837
	// (get) Token: 0x060044DE RID: 17630 RVA: 0x00087C05 File Offset: 0x00085E05
	// (set) Token: 0x060044DF RID: 17631 RVA: 0x00087C15 File Offset: 0x00085E15
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAttachmentRule LocationAttachRule
	{
		get
		{
			return (EAttachmentRule)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_LocationAttachRule));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_LocationAttachRule) = (byte)value;
		}
	}

	// Token: 0x17000346 RID: 838
	// (get) Token: 0x060044E0 RID: 17632 RVA: 0x00087C26 File Offset: 0x00085E26
	// (set) Token: 0x060044E1 RID: 17633 RVA: 0x00087C36 File Offset: 0x00085E36
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAttachmentRule RotationAttachRule
	{
		get
		{
			return (EAttachmentRule)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_RotationAttachRule));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_RotationAttachRule) = (byte)value;
		}
	}

	// Token: 0x17000347 RID: 839
	// (get) Token: 0x060044E2 RID: 17634 RVA: 0x00087C47 File Offset: 0x00085E47
	// (set) Token: 0x060044E3 RID: 17635 RVA: 0x00087C57 File Offset: 0x00085E57
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EAttachmentRule ScaleAttachRule
	{
		get
		{
			return (EAttachmentRule)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_ScaleAttachRule));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_ScaleAttachRule) = (byte)value;
		}
	}

	// Token: 0x17000348 RID: 840
	// (get) Token: 0x060044E4 RID: 17636 RVA: 0x00087C68 File Offset: 0x00085E68
	// (set) Token: 0x060044E5 RID: 17637 RVA: 0x00087C78 File Offset: 0x00085E78
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EDetachmentRule LocationDetachRule
	{
		get
		{
			return (EDetachmentRule)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_LocationDetachRule));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_LocationDetachRule) = (byte)value;
		}
	}

	// Token: 0x17000349 RID: 841
	// (get) Token: 0x060044E6 RID: 17638 RVA: 0x00087C89 File Offset: 0x00085E89
	// (set) Token: 0x060044E7 RID: 17639 RVA: 0x00087C99 File Offset: 0x00085E99
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EDetachmentRule RotationDetachRule
	{
		get
		{
			return (EDetachmentRule)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_RotationDetachRule));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_RotationDetachRule) = (byte)value;
		}
	}

	// Token: 0x1700034A RID: 842
	// (get) Token: 0x060044E8 RID: 17640 RVA: 0x00087CAA File Offset: 0x00085EAA
	// (set) Token: 0x060044E9 RID: 17641 RVA: 0x00087CBA File Offset: 0x00085EBA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EDetachmentRule ScaleDetachRule
	{
		get
		{
			return (EDetachmentRule)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_ScaleDetachRule));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachActorToSocket.__PropertyOffset_ScaleDetachRule) = (byte)value;
		}
	}

	// Token: 0x060044EA RID: 17642 RVA: 0x00087CCC File Offset: 0x00085ECC
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

	// Token: 0x060044EB RID: 17643 RVA: 0x00087D74 File Offset: 0x00085F74
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.ActorTag == null)
		{
			return false;
		}
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(this.ActorTag, ECollectActorType.Default);
		if (actorWithTag == null)
		{
			return false;
		}
		if (actorWithTag != null)
		{
			actorWithTag.K2_AttachToComponent(meshComp, this.SocketName, this.LocationAttachRule, this.RotationAttachRule, this.ScaleAttachRule, false, true);
		}
		return true;
	}

	// Token: 0x060044EC RID: 17644 RVA: 0x00087DD0 File Offset: 0x00085FD0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animSequence != null) ? animSequence.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060044ED RID: 17645 RVA: 0x00087E70 File Offset: 0x00086070
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		if (this.ActorTag == null)
		{
			return false;
		}
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(this.ActorTag, ECollectActorType.Default);
		if (actorWithTag == null)
		{
			return false;
		}
		if (actorWithTag != null)
		{
			actorWithTag.K2_DetachFromActor(this.LocationDetachRule, this.RotationDetachRule, this.ScaleDetachRule);
		}
		return true;
	}

	// Token: 0x060044EE RID: 17646 RVA: 0x00087EC0 File Offset: 0x000860C0
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

	// Token: 0x060044EF RID: 17647 RVA: 0x00087F3B File Offset: 0x0008613B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "附加Actor到Socket";
	}

	// Token: 0x060044F0 RID: 17648 RVA: 0x00087F42 File Offset: 0x00086142
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAttachActorToSocket._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttachActorToSocket.TsAnimNotifyStateAttachActorToSocket_C");
		}
		return TsAnimNotifyStateAttachActorToSocket._ClassPtr;
	}

	// Token: 0x060044F1 RID: 17649 RVA: 0x00087F68 File Offset: 0x00086168
	public TsAnimNotifyStateAttachActorToSocket() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttachActorToSocket.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060044F2 RID: 17650 RVA: 0x00087F90 File Offset: 0x00086190
	[NullableContext(1)]
	public TsAnimNotifyStateAttachActorToSocket(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttachActorToSocket.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060044F3 RID: 17651 RVA: 0x00087FC3 File Offset: 0x000861C3
	protected TsAnimNotifyStateAttachActorToSocket(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060044F4 RID: 17652 RVA: 0x00087FCC File Offset: 0x000861CC
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060044F5 RID: 17653 RVA: 0x00088008 File Offset: 0x00086208
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060044F6 RID: 17654 RVA: 0x0008803B File Offset: 0x0008623B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001252 RID: 4690
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttachActorToSocket.TsAnimNotifyStateAttachActorToSocket_C";

	// Token: 0x04001253 RID: 4691
	private static IntPtr _ClassPtr;

	// Token: 0x04001254 RID: 4692
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001255 RID: 4693
	private static int __PropertyOffset_SocketName;

	// Token: 0x04001256 RID: 4694
	private static int __PropertyOffset_ActorTag;

	// Token: 0x04001257 RID: 4695
	private static int __PropertyOffset_LocationAttachRule;

	// Token: 0x04001258 RID: 4696
	private static int __PropertyOffset_RotationAttachRule;

	// Token: 0x04001259 RID: 4697
	private static int __PropertyOffset_ScaleAttachRule;

	// Token: 0x0400125A RID: 4698
	private static int __PropertyOffset_LocationDetachRule;

	// Token: 0x0400125B RID: 4699
	private static int __PropertyOffset_RotationDetachRule;

	// Token: 0x0400125C RID: 4700
	private static int __PropertyOffset_ScaleDetachRule;
}
