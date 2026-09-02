using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033FA RID: 13306
[UClass("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMotionVertexOffset.AnimNotifyAddMotionVertexOffset_C")]
public class AnimNotifyAddMotionVertexOffset : AnimNotifyAddMaterialControllerData, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BAD5 RID: 113365 RVA: 0x008418B0 File Offset: 0x0083FAB0
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

	// Token: 0x0601BAD6 RID: 113366 RVA: 0x0084192B File Offset: 0x0083FB2B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "角色顶点运动偏移";
	}

	// Token: 0x0601BAD7 RID: 113367 RVA: 0x00841932 File Offset: 0x0083FB32
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyAddMotionVertexOffset._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMotionVertexOffset.AnimNotifyAddMotionVertexOffset_C");
		}
		return AnimNotifyAddMotionVertexOffset._ClassPtr;
	}

	// Token: 0x0601BAD8 RID: 113368 RVA: 0x00841958 File Offset: 0x0083FB58
	public AnimNotifyAddMotionVertexOffset() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddMotionVertexOffset.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BAD9 RID: 113369 RVA: 0x00841980 File Offset: 0x0083FB80
	[NullableContext(1)]
	public AnimNotifyAddMotionVertexOffset(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddMotionVertexOffset.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BADA RID: 113370 RVA: 0x008419B3 File Offset: 0x0083FBB3
	protected AnimNotifyAddMotionVertexOffset(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BADB RID: 113371 RVA: 0x008419BC File Offset: 0x0083FBBC
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400DFCF RID: 57295
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMotionVertexOffset.AnimNotifyAddMotionVertexOffset_C";

	// Token: 0x0400DFD0 RID: 57296
	private static IntPtr _ClassPtr;

	// Token: 0x0400DFD1 RID: 57297
	private static IntPtr _ClassDefaultObjectPtr;
}
