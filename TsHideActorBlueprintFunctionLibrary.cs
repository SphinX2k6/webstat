using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02001EC3 RID: 7875
[UClass("/Game/Aki/TypeScript/Game/Module/HideActor/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/HideActor/TsHideActorBlueprintFunctionLibrary.TsHideActorBlueprintFunctionLibrary_C")]
public class TsHideActorBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600E8CE RID: 59598 RVA: 0x003EFFE9 File Offset: 0x003EE1E9
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void HideMesh()
	{
		ControllerBase<HideActorController>.Instance.HideMesh();
	}

	// Token: 0x0600E8CF RID: 59599 RVA: 0x003EFFF5 File Offset: 0x003EE1F5
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void HideEffect()
	{
		ControllerBase<HideActorController>.Instance.HideEffect();
	}

	// Token: 0x0600E8D0 RID: 59600 RVA: 0x003F0001 File Offset: 0x003EE201
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ShowMesh()
	{
		ControllerBase<HideActorController>.Instance.ShowMesh();
	}

	// Token: 0x0600E8D1 RID: 59601 RVA: 0x003F000D File Offset: 0x003EE20D
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ShowEffect()
	{
		ControllerBase<HideActorController>.Instance.ShowEffect();
	}

	// Token: 0x0600E8D2 RID: 59602 RVA: 0x003F0019 File Offset: 0x003EE219
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void HideNpcMesh()
	{
		ControllerBase<HideActorController>.Instance.HideNpcMesh();
	}

	// Token: 0x0600E8D3 RID: 59603 RVA: 0x003F0025 File Offset: 0x003EE225
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void HideNpcEffect()
	{
		ControllerBase<HideActorController>.Instance.HideNpcEffect();
	}

	// Token: 0x0600E8D4 RID: 59604 RVA: 0x003F0031 File Offset: 0x003EE231
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ShowNpcMesh()
	{
		ControllerBase<HideActorController>.Instance.ShowNpcMesh();
	}

	// Token: 0x0600E8D5 RID: 59605 RVA: 0x003F003D File Offset: 0x003EE23D
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ShowNpcEffect()
	{
		ControllerBase<HideActorController>.Instance.ShowNpcEffect();
	}

	// Token: 0x0600E8D6 RID: 59606 RVA: 0x003F0049 File Offset: 0x003EE249
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetHideParameter(float distance, FName boneName)
	{
		ControllerBase<HideActorController>.Instance.SetHideParameter(distance, boneName);
	}

	// Token: 0x0600E8D7 RID: 59607 RVA: 0x003F0057 File Offset: 0x003EE257
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ResetHideParameter()
	{
		ControllerBase<HideActorController>.Instance.ResetHideParameter();
	}

	// Token: 0x0600E8D8 RID: 59608 RVA: 0x003F0063 File Offset: 0x003EE263
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsHideActorBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/HideActor/TsHideActorBlueprintFunctionLibrary.TsHideActorBlueprintFunctionLibrary_C");
		}
		return TsHideActorBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x0600E8D9 RID: 59609 RVA: 0x003F0088 File Offset: 0x003EE288
	public TsHideActorBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsHideActorBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600E8DA RID: 59610 RVA: 0x003F00B0 File Offset: 0x003EE2B0
	[NullableContext(1)]
	public TsHideActorBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsHideActorBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600E8DB RID: 59611 RVA: 0x003F00E3 File Offset: 0x003EE2E3
	protected TsHideActorBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600E8DC RID: 59612 RVA: 0x003F00EC File Offset: 0x003EE2EC
	protected unsafe static void __CPPCALL_HideMesh_Implementation(TsHideActorBlueprintFunctionLibrary.__HideMesh_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.HideMesh();
	}

	// Token: 0x0600E8DD RID: 59613 RVA: 0x003F00F3 File Offset: 0x003EE2F3
	protected unsafe static void __CPPCALL_HideEffect_Implementation(TsHideActorBlueprintFunctionLibrary.__HideEffect_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.HideEffect();
	}

	// Token: 0x0600E8DE RID: 59614 RVA: 0x003F00FA File Offset: 0x003EE2FA
	protected unsafe static void __CPPCALL_ShowMesh_Implementation(TsHideActorBlueprintFunctionLibrary.__ShowMesh_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.ShowMesh();
	}

	// Token: 0x0600E8DF RID: 59615 RVA: 0x003F0101 File Offset: 0x003EE301
	protected unsafe static void __CPPCALL_ShowEffect_Implementation(TsHideActorBlueprintFunctionLibrary.__ShowEffect_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.ShowEffect();
	}

	// Token: 0x0600E8E0 RID: 59616 RVA: 0x003F0108 File Offset: 0x003EE308
	protected unsafe static void __CPPCALL_HideNpcMesh_Implementation(TsHideActorBlueprintFunctionLibrary.__HideNpcMesh_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.HideNpcMesh();
	}

	// Token: 0x0600E8E1 RID: 59617 RVA: 0x003F010F File Offset: 0x003EE30F
	protected unsafe static void __CPPCALL_HideNpcEffect_Implementation(TsHideActorBlueprintFunctionLibrary.__HideNpcEffect_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.HideNpcEffect();
	}

	// Token: 0x0600E8E2 RID: 59618 RVA: 0x003F0116 File Offset: 0x003EE316
	protected unsafe static void __CPPCALL_ShowNpcMesh_Implementation(TsHideActorBlueprintFunctionLibrary.__ShowNpcMesh_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.ShowNpcMesh();
	}

	// Token: 0x0600E8E3 RID: 59619 RVA: 0x003F011D File Offset: 0x003EE31D
	protected unsafe static void __CPPCALL_ShowNpcEffect_Implementation(TsHideActorBlueprintFunctionLibrary.__ShowNpcEffect_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.ShowNpcEffect();
	}

	// Token: 0x0600E8E4 RID: 59620 RVA: 0x003F0124 File Offset: 0x003EE324
	protected unsafe static void __CPPCALL_SetHideParameter_Implementation(TsHideActorBlueprintFunctionLibrary.__SetHideParameter_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.SetHideParameter(__Params->distance, __Params->boneName);
	}

	// Token: 0x0600E8E5 RID: 59621 RVA: 0x003F0137 File Offset: 0x003EE337
	protected unsafe static void __CPPCALL_ResetHideParameter_Implementation(TsHideActorBlueprintFunctionLibrary.__ResetHideParameter_FunctionParams* __Params)
	{
		TsHideActorBlueprintFunctionLibrary.ResetHideParameter();
	}

	// Token: 0x04007032 RID: 28722
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/HideActor/TsHideActorBlueprintFunctionLibrary.TsHideActorBlueprintFunctionLibrary_C";

	// Token: 0x04007033 RID: 28723
	private static IntPtr _ClassPtr;

	// Token: 0x04007034 RID: 28724
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02008205 RID: 33285
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __HideMesh_FunctionParams
	{
		// Token: 0x0402C1AF RID: 180655
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008206 RID: 33286
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __HideEffect_FunctionParams
	{
		// Token: 0x0402C1B0 RID: 180656
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008207 RID: 33287
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ShowMesh_FunctionParams
	{
		// Token: 0x0402C1B1 RID: 180657
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008208 RID: 33288
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ShowEffect_FunctionParams
	{
		// Token: 0x0402C1B2 RID: 180658
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008209 RID: 33289
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __HideNpcMesh_FunctionParams
	{
		// Token: 0x0402C1B3 RID: 180659
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200820A RID: 33290
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __HideNpcEffect_FunctionParams
	{
		// Token: 0x0402C1B4 RID: 180660
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200820B RID: 33291
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ShowNpcMesh_FunctionParams
	{
		// Token: 0x0402C1B5 RID: 180661
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200820C RID: 33292
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ShowNpcEffect_FunctionParams
	{
		// Token: 0x0402C1B6 RID: 180662
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200820D RID: 33293
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetHideParameter_FunctionParams
	{
		// Token: 0x0402C1B7 RID: 180663
		[FieldOffset(0)]
		public float distance;

		// Token: 0x0402C1B8 RID: 180664
		[FieldOffset(4)]
		public FName boneName;

		// Token: 0x0402C1B9 RID: 180665
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200820E RID: 33294
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __ResetHideParameter_FunctionParams
	{
		// Token: 0x0402C1BA RID: 180666
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}
}
