using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF5 RID: 3573
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyUiTimeDilation.TsAnimNotifyUiTimeDilation_C")]
public class TsAnimNotifyUiTimeDilation : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x060052E3 RID: 21219 RVA: 0x000C25AC File Offset: 0x000C07AC
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

	// Token: 0x060052E4 RID: 21220 RVA: 0x000C264B File Offset: 0x000C084B
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		return meshComp.GetOwner() is TsBaseCharacter;
	}

	// Token: 0x060052E5 RID: 21221 RVA: 0x000C265D File Offset: 0x000C085D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyUiTimeDilation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyUiTimeDilation.TsAnimNotifyUiTimeDilation_C");
		}
		return TsAnimNotifyUiTimeDilation._ClassPtr;
	}

	// Token: 0x060052E6 RID: 21222 RVA: 0x000C2684 File Offset: 0x000C0884
	public TsAnimNotifyUiTimeDilation() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyUiTimeDilation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060052E7 RID: 21223 RVA: 0x000C26AC File Offset: 0x000C08AC
	[NullableContext(1)]
	public TsAnimNotifyUiTimeDilation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyUiTimeDilation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060052E8 RID: 21224 RVA: 0x000C26DF File Offset: 0x000C08DF
	protected TsAnimNotifyUiTimeDilation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060052E9 RID: 21225 RVA: 0x000C26E8 File Offset: 0x000C08E8
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400187F RID: 6271
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyUiTimeDilation.TsAnimNotifyUiTimeDilation_C";

	// Token: 0x04001880 RID: 6272
	private static IntPtr _ClassPtr;

	// Token: 0x04001881 RID: 6273
	private static IntPtr _ClassDefaultObjectPtr;
}
