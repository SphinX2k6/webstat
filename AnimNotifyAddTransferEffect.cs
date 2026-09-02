using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033FB RID: 13307
[UClass("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddTransferEffect.AnimNotifyAddTransferEffect_C")]
public class AnimNotifyAddTransferEffect : AnimNotifyAddMaterialControllerData, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BADC RID: 113372 RVA: 0x008419D0 File Offset: 0x0083FBD0
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

	// Token: 0x0601BADD RID: 113373 RVA: 0x00841A4B File Offset: 0x0083FC4B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "角色传送";
	}

	// Token: 0x0601BADE RID: 113374 RVA: 0x00841A52 File Offset: 0x0083FC52
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyAddTransferEffect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddTransferEffect.AnimNotifyAddTransferEffect_C");
		}
		return AnimNotifyAddTransferEffect._ClassPtr;
	}

	// Token: 0x0601BADF RID: 113375 RVA: 0x00841A78 File Offset: 0x0083FC78
	public AnimNotifyAddTransferEffect() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddTransferEffect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BAE0 RID: 113376 RVA: 0x00841AA0 File Offset: 0x0083FCA0
	[NullableContext(1)]
	public AnimNotifyAddTransferEffect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddTransferEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BAE1 RID: 113377 RVA: 0x00841AD3 File Offset: 0x0083FCD3
	protected AnimNotifyAddTransferEffect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BAE2 RID: 113378 RVA: 0x00841ADC File Offset: 0x0083FCDC
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400DFD2 RID: 57298
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddTransferEffect.AnimNotifyAddTransferEffect_C";

	// Token: 0x0400DFD3 RID: 57299
	private static IntPtr _ClassPtr;

	// Token: 0x0400DFD4 RID: 57300
	private static IntPtr _ClassDefaultObjectPtr;
}
