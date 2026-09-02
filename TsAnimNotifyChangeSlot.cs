using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DBA RID: 3514
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeSlot.TsAnimNotifyChangeSlot_C")]
public class TsAnimNotifyChangeSlot : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700050E RID: 1294
	// (get) Token: 0x06004F9C RID: 20380 RVA: 0x000B700B File Offset: 0x000B520B
	// (set) Token: 0x06004F9D RID: 20381 RVA: 0x000B701F File Offset: 0x000B521F
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ComponentName
	{
		[NullableContext(2)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyChangeSlot.__PropertyOffset_ComponentName)));
		}
		[NullableContext(2)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyChangeSlot.__PropertyOffset_ComponentName)), value);
		}
	}

	// Token: 0x1700050F RID: 1295
	// (get) Token: 0x06004F9E RID: 20382 RVA: 0x000B7034 File Offset: 0x000B5234
	// (set) Token: 0x06004F9F RID: 20383 RVA: 0x000B7048 File Offset: 0x000B5248
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SwitchToSlotName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyChangeSlot.__PropertyOffset_SwitchToSlotName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeSlot.__PropertyOffset_SwitchToSlotName) = value;
		}
	}

	// Token: 0x17000510 RID: 1296
	// (get) Token: 0x06004FA0 RID: 20384 RVA: 0x000B705D File Offset: 0x000B525D
	// (set) Token: 0x06004FA1 RID: 20385 RVA: 0x000B7071 File Offset: 0x000B5271
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FTransform SlotTransform
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyChangeSlot.__PropertyOffset_SlotTransform);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeSlot.__PropertyOffset_SlotTransform) = value;
		}
	}

	// Token: 0x06004FA2 RID: 20386 RVA: 0x000B7088 File Offset: 0x000B5288
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

	// Token: 0x06004FA3 RID: 20387 RVA: 0x000B7128 File Offset: 0x000B5328
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return false;
		}
		USkeletalMeshComponent skeletalMesh = characterActorComponent.SkeletalMesh;
		int? num = (skeletalMesh != null) ? new int?(skeletalMesh.GetNumChildrenComponents()) : null;
		int num2 = 0;
		USkeletalMeshComponent uskeletalMeshComponent;
		for (;;)
		{
			int num3 = num2;
			int? num4 = num;
			if (!(num3 < num4.GetValueOrDefault() & num4 != null))
			{
				return true;
			}
			USkeletalMeshComponent skeletalMesh2 = characterActorComponent.SkeletalMesh;
			USceneComponent usceneComponent = (skeletalMesh2 != null) ? skeletalMesh2.GetChildComponent(num2) : null;
			if (usceneComponent != null && usceneComponent.GetName() == this.ComponentName)
			{
				uskeletalMeshComponent = (usceneComponent as USkeletalMeshComponent);
				if (uskeletalMeshComponent != null)
				{
					break;
				}
			}
			num2++;
		}
		uskeletalMeshComponent.K2_AttachToComponent(characterActorComponent.SkeletalMesh, this.SwitchToSlotName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, true, true);
		FTransform slotTransform = this.SlotTransform;
		FHitResult fhitResult = new FHitResult();
		USceneComponent usceneComponent2 = uskeletalMeshComponent;
		FTransform slotTransform2 = this.SlotTransform;
		usceneComponent2.K2_SetRelativeTransform(slotTransform2, false, ref fhitResult, true);
		return true;
	}

	// Token: 0x06004FA4 RID: 20388 RVA: 0x000B7218 File Offset: 0x000B5418
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

	// Token: 0x06004FA5 RID: 20389 RVA: 0x000B7293 File Offset: 0x000B5493
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "切换组件到指定插槽";
	}

	// Token: 0x06004FA6 RID: 20390 RVA: 0x000B729A File Offset: 0x000B549A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyChangeSlot._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeSlot.TsAnimNotifyChangeSlot_C");
		}
		return TsAnimNotifyChangeSlot._ClassPtr;
	}

	// Token: 0x06004FA7 RID: 20391 RVA: 0x000B72C0 File Offset: 0x000B54C0
	public TsAnimNotifyChangeSlot() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeSlot.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004FA8 RID: 20392 RVA: 0x000B72E8 File Offset: 0x000B54E8
	[NullableContext(1)]
	public TsAnimNotifyChangeSlot(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeSlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004FA9 RID: 20393 RVA: 0x000B731B File Offset: 0x000B551B
	protected TsAnimNotifyChangeSlot(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004FAA RID: 20394 RVA: 0x000B7324 File Offset: 0x000B5524
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004FAB RID: 20395 RVA: 0x000B7357 File Offset: 0x000B5557
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001737 RID: 5943
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeSlot.TsAnimNotifyChangeSlot_C";

	// Token: 0x04001738 RID: 5944
	private static IntPtr _ClassPtr;

	// Token: 0x04001739 RID: 5945
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400173A RID: 5946
	private static int __PropertyOffset_ComponentName;

	// Token: 0x0400173B RID: 5947
	private static int __PropertyOffset_SwitchToSlotName;

	// Token: 0x0400173C RID: 5948
	private static int __PropertyOffset_SlotTransform;
}
