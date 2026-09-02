using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DAE RID: 3502
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBreakConstraint.TsAnimNotifyBreakConstraint_C")]
public class TsAnimNotifyBreakConstraint : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004F2 RID: 1266
	// (get) Token: 0x06004EEE RID: 20206 RVA: 0x000B4B7B File Offset: 0x000B2D7B
	// (set) Token: 0x06004EEF RID: 20207 RVA: 0x000B4B8F File Offset: 0x000B2D8F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName 分离骨骼名
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBreakConstraint.__PropertyOffset_分离骨骼名);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBreakConstraint.__PropertyOffset_分离骨骼名) = value;
		}
	}

	// Token: 0x170004F3 RID: 1267
	// (get) Token: 0x06004EF0 RID: 20208 RVA: 0x000B4BA4 File Offset: 0x000B2DA4
	// (set) Token: 0x06004EF1 RID: 20209 RVA: 0x000B4BB8 File Offset: 0x000B2DB8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector Impulse
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBreakConstraint.__PropertyOffset_Impulse);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBreakConstraint.__PropertyOffset_Impulse) = value;
		}
	}

	// Token: 0x170004F4 RID: 1268
	// (get) Token: 0x06004EF2 RID: 20210 RVA: 0x000B4BCD File Offset: 0x000B2DCD
	// (set) Token: 0x06004EF3 RID: 20211 RVA: 0x000B4BE1 File Offset: 0x000B2DE1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector HitLocation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBreakConstraint.__PropertyOffset_HitLocation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBreakConstraint.__PropertyOffset_HitLocation) = value;
		}
	}

	// Token: 0x06004EF4 RID: 20212 RVA: 0x000B4BF8 File Offset: 0x000B2DF8
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

	// Token: 0x06004EF5 RID: 20213 RVA: 0x000B4C97 File Offset: 0x000B2E97
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp.GetOwner() is TsBaseCharacter)
		{
			meshComp.BreakConstraint(this.Impulse, this.HitLocation, this.分离骨骼名);
		}
		return true;
	}

	// Token: 0x06004EF6 RID: 20214 RVA: 0x000B4CC0 File Offset: 0x000B2EC0
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

	// Token: 0x06004EF7 RID: 20215 RVA: 0x000B4D3B File Offset: 0x000B2F3B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "分离骨骼网格体";
	}

	// Token: 0x06004EF8 RID: 20216 RVA: 0x000B4D42 File Offset: 0x000B2F42
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBreakConstraint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBreakConstraint.TsAnimNotifyBreakConstraint_C");
		}
		return TsAnimNotifyBreakConstraint._ClassPtr;
	}

	// Token: 0x06004EF9 RID: 20217 RVA: 0x000B4D68 File Offset: 0x000B2F68
	public TsAnimNotifyBreakConstraint() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBreakConstraint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004EFA RID: 20218 RVA: 0x000B4D90 File Offset: 0x000B2F90
	[NullableContext(1)]
	public TsAnimNotifyBreakConstraint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBreakConstraint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004EFB RID: 20219 RVA: 0x000B4DC3 File Offset: 0x000B2FC3
	protected TsAnimNotifyBreakConstraint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004EFC RID: 20220 RVA: 0x000B4DCC File Offset: 0x000B2FCC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004EFD RID: 20221 RVA: 0x000B4DFF File Offset: 0x000B2FFF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016F0 RID: 5872
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBreakConstraint.TsAnimNotifyBreakConstraint_C";

	// Token: 0x040016F1 RID: 5873
	private static IntPtr _ClassPtr;

	// Token: 0x040016F2 RID: 5874
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016F3 RID: 5875
	private static int __PropertyOffset_分离骨骼名;

	// Token: 0x040016F4 RID: 5876
	private static int __PropertyOffset_Impulse;

	// Token: 0x040016F5 RID: 5877
	private static int __PropertyOffset_HitLocation;
}
