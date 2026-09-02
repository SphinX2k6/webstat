using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200345B RID: 13403
[UClass("/Game/Aki/TypeScript/Game/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Utils/GlobalBlueprintFunctionLibrary.GlobalBlueprintFunctionLibrary_C")]
public class GlobalBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601C1C7 RID: 115143 RVA: 0x00862CDA File Offset: 0x00860EDA
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static UObject GetBpEventManager()
	{
		return GlobalData.BpEventManager;
	}

	// Token: 0x0601C1C8 RID: 115144 RVA: 0x00862CE1 File Offset: 0x00860EE1
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static UObject GetBpFightManager()
	{
		return GlobalData.BpFightManager;
	}

	// Token: 0x0601C1C9 RID: 115145 RVA: 0x00862CE8 File Offset: 0x00860EE8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (GlobalBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Utils/GlobalBlueprintFunctionLibrary.GlobalBlueprintFunctionLibrary_C");
		}
		return GlobalBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x0601C1CA RID: 115146 RVA: 0x00862D0C File Offset: 0x00860F0C
	public GlobalBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(GlobalBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C1CB RID: 115147 RVA: 0x00862D34 File Offset: 0x00860F34
	[NullableContext(1)]
	public GlobalBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GlobalBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C1CC RID: 115148 RVA: 0x00862D67 File Offset: 0x00860F67
	protected GlobalBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C1CD RID: 115149 RVA: 0x00862D70 File Offset: 0x00860F70
	protected unsafe static void __CPPCALL_GetBpEventManager_Implementation(GlobalBlueprintFunctionLibrary.__GetBpEventManager_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UObject bpEventManager = GlobalBlueprintFunctionLibrary.GetBpEventManager();
		ptr = ((bpEventManager != null) ? bpEventManager.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601C1CE RID: 115150 RVA: 0x00862D8C File Offset: 0x00860F8C
	protected unsafe static void __CPPCALL_GetBpFightManager_Implementation(GlobalBlueprintFunctionLibrary.__GetBpFightManager_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UObject bpFightManager = GlobalBlueprintFunctionLibrary.GetBpFightManager();
		ptr = ((bpFightManager != null) ? bpFightManager.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0400E302 RID: 58114
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Utils/GlobalBlueprintFunctionLibrary.GlobalBlueprintFunctionLibrary_C";

	// Token: 0x0400E303 RID: 58115
	private static IntPtr _ClassPtr;

	// Token: 0x0400E304 RID: 58116
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02009548 RID: 38216
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetBpEventManager_FunctionParams
	{
		// Token: 0x040315F3 RID: 202227
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x040315F4 RID: 202228
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x02009549 RID: 38217
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetBpFightManager_FunctionParams
	{
		// Token: 0x040315F5 RID: 202229
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x040315F6 RID: 202230
		[FieldOffset(8)]
		public IntPtr __Result;
	}
}
