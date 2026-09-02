using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD2 RID: 3538
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyHideBone.TsAnimNotifyHideBone_C")]
public class TsAnimNotifyHideBone : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000531 RID: 1329
	// (get) Token: 0x060050D0 RID: 20688 RVA: 0x000BB0CB File Offset: 0x000B92CB
	// (set) Token: 0x060050D1 RID: 20689 RVA: 0x000BB0DF File Offset: 0x000B92DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BoneName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyHideBone.__PropertyOffset_BoneName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyHideBone.__PropertyOffset_BoneName)), value);
		}
	}

	// Token: 0x17000532 RID: 1330
	// (get) Token: 0x060050D2 RID: 20690 RVA: 0x000BB0F4 File Offset: 0x000B92F4
	// (set) Token: 0x060050D3 RID: 20691 RVA: 0x000BB104 File Offset: 0x000B9304
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Hide
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyHideBone.__PropertyOffset_Hide) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyHideBone.__PropertyOffset_Hide) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000533 RID: 1331
	// (get) Token: 0x060050D4 RID: 20692 RVA: 0x000BB115 File Offset: 0x000B9315
	// (set) Token: 0x060050D5 RID: 20693 RVA: 0x000BB125 File Offset: 0x000B9325
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IgnoreTsBaseCharacter
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyHideBone.__PropertyOffset_IgnoreTsBaseCharacter) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyHideBone.__PropertyOffset_IgnoreTsBaseCharacter) = (value ? 1 : 0);
		}
	}

	// Token: 0x060050D6 RID: 20694 RVA: 0x000BB138 File Offset: 0x000B9338
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

	// Token: 0x060050D7 RID: 20695 RVA: 0x000BB1D8 File Offset: 0x000B93D8
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.IgnoreTsBaseCharacter)
		{
			MeshComponentUtils.HideBone(meshComp, this.BoneName, this.Hide);
			return true;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null && tsBaseCharacter.CharacterActorComponent != null)
		{
			CharacterAnimationComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
			if (component != null)
			{
				component.HideBone(FNameUtil.GetDynamicFName(this.BoneName).Value, this.Hide, true);
			}
		}
		return true;
	}

	// Token: 0x060050D8 RID: 20696 RVA: 0x000BB250 File Offset: 0x000B9450
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

	// Token: 0x060050D9 RID: 20697 RVA: 0x000BB2CB File Offset: 0x000B94CB
	protected override string GetNotifyName_Implementation()
	{
		return "隐藏骨骼";
	}

	// Token: 0x060050DA RID: 20698 RVA: 0x000BB2D2 File Offset: 0x000B94D2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyHideBone._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyHideBone.TsAnimNotifyHideBone_C");
		}
		return TsAnimNotifyHideBone._ClassPtr;
	}

	// Token: 0x060050DB RID: 20699 RVA: 0x000BB2F8 File Offset: 0x000B94F8
	public TsAnimNotifyHideBone() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyHideBone.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060050DC RID: 20700 RVA: 0x000BB320 File Offset: 0x000B9520
	public TsAnimNotifyHideBone(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyHideBone.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060050DD RID: 20701 RVA: 0x000BB353 File Offset: 0x000B9553
	protected TsAnimNotifyHideBone(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060050DE RID: 20702 RVA: 0x000BB35C File Offset: 0x000B955C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060050DF RID: 20703 RVA: 0x000BB38F File Offset: 0x000B958F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017A9 RID: 6057
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyHideBone.TsAnimNotifyHideBone_C";

	// Token: 0x040017AA RID: 6058
	private static IntPtr _ClassPtr;

	// Token: 0x040017AB RID: 6059
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017AC RID: 6060
	private static int __PropertyOffset_BoneName;

	// Token: 0x040017AD RID: 6061
	private static int __PropertyOffset_Hide;

	// Token: 0x040017AE RID: 6062
	private static int __PropertyOffset_IgnoreTsBaseCharacter;
}
