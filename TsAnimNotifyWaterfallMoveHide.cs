using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF9 RID: 3577
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyWaterfallMoveHide.TsAnimNotifyWaterfallMoveHide_C")]
public class TsAnimNotifyWaterfallMoveHide : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700059A RID: 1434
	// (get) Token: 0x0600531D RID: 21277 RVA: 0x000C30B7 File Offset: 0x000C12B7
	// (set) Token: 0x0600531E RID: 21278 RVA: 0x000C30C7 File Offset: 0x000C12C7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Hide
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyWaterfallMoveHide.__PropertyOffset_Hide) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyWaterfallMoveHide.__PropertyOffset_Hide) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600531F RID: 21279 RVA: 0x000C30D8 File Offset: 0x000C12D8
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

	// Token: 0x06005320 RID: 21280 RVA: 0x000C3177 File Offset: 0x000C1377
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		return true;
	}

	// Token: 0x06005321 RID: 21281 RVA: 0x000C317C File Offset: 0x000C137C
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

	// Token: 0x06005322 RID: 21282 RVA: 0x000C31F7 File Offset: 0x000C13F7
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "攀瀑进入二阶段(已废弃)";
	}

	// Token: 0x06005323 RID: 21283 RVA: 0x000C31FE File Offset: 0x000C13FE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyWaterfallMoveHide._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyWaterfallMoveHide.TsAnimNotifyWaterfallMoveHide_C");
		}
		return TsAnimNotifyWaterfallMoveHide._ClassPtr;
	}

	// Token: 0x06005324 RID: 21284 RVA: 0x000C3224 File Offset: 0x000C1424
	public TsAnimNotifyWaterfallMoveHide() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyWaterfallMoveHide.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005325 RID: 21285 RVA: 0x000C324C File Offset: 0x000C144C
	[NullableContext(1)]
	public TsAnimNotifyWaterfallMoveHide(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyWaterfallMoveHide.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005326 RID: 21286 RVA: 0x000C327F File Offset: 0x000C147F
	protected TsAnimNotifyWaterfallMoveHide(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005327 RID: 21287 RVA: 0x000C3288 File Offset: 0x000C1488
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005328 RID: 21288 RVA: 0x000C32BB File Offset: 0x000C14BB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400189C RID: 6300
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyWaterfallMoveHide.TsAnimNotifyWaterfallMoveHide_C";

	// Token: 0x0400189D RID: 6301
	private static IntPtr _ClassPtr;

	// Token: 0x0400189E RID: 6302
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400189F RID: 6303
	private static int __PropertyOffset_Hide;
}
