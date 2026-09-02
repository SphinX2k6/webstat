using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200276D RID: 10093
[UClass("/Game/Aki/TypeScript/Game/Module/Reward/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/Reward/RewardBlueprintFunctionLibrary.RewardBlueprintFunctionLibrary_C")]
public class RewardBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x06013EB3 RID: 81587 RVA: 0x0058D346 File Offset: 0x0058B546
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RequestPickUpFightDrop(long packageIncId, long dropIncIds)
	{
	}

	// Token: 0x06013EB4 RID: 81588 RVA: 0x0058D348 File Offset: 0x0058B548
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PackageDestroyCallBack(long packageIncId, long dropIncIds)
	{
	}

	// Token: 0x06013EB5 RID: 81589 RVA: 0x0058D34A File Offset: 0x0058B54A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (RewardBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/Reward/RewardBlueprintFunctionLibrary.RewardBlueprintFunctionLibrary_C");
		}
		return RewardBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06013EB6 RID: 81590 RVA: 0x0058D370 File Offset: 0x0058B570
	public RewardBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(RewardBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06013EB7 RID: 81591 RVA: 0x0058D398 File Offset: 0x0058B598
	[NullableContext(1)]
	public RewardBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(RewardBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06013EB8 RID: 81592 RVA: 0x0058D3CB File Offset: 0x0058B5CB
	protected RewardBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06013EB9 RID: 81593 RVA: 0x0058D3D4 File Offset: 0x0058B5D4
	protected unsafe static void __CPPCALL_RequestPickUpFightDrop_Implementation(RewardBlueprintFunctionLibrary.__RequestPickUpFightDrop_FunctionParams* __Params)
	{
		RewardBlueprintFunctionLibrary.RequestPickUpFightDrop(__Params->packageIncId, __Params->dropIncIds);
	}

	// Token: 0x06013EBA RID: 81594 RVA: 0x0058D3E7 File Offset: 0x0058B5E7
	protected unsafe static void __CPPCALL_PackageDestroyCallBack_Implementation(RewardBlueprintFunctionLibrary.__PackageDestroyCallBack_FunctionParams* __Params)
	{
		RewardBlueprintFunctionLibrary.PackageDestroyCallBack(__Params->packageIncId, __Params->dropIncIds);
	}

	// Token: 0x04009AF1 RID: 39665
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/Reward/RewardBlueprintFunctionLibrary.RewardBlueprintFunctionLibrary_C";

	// Token: 0x04009AF2 RID: 39666
	private static IntPtr _ClassPtr;

	// Token: 0x04009AF3 RID: 39667
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02008B28 RID: 35624
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __RequestPickUpFightDrop_FunctionParams
	{
		// Token: 0x0402EEBB RID: 192187
		[FieldOffset(0)]
		public long packageIncId;

		// Token: 0x0402EEBC RID: 192188
		[FieldOffset(8)]
		public long dropIncIds;

		// Token: 0x0402EEBD RID: 192189
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02008B29 RID: 35625
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __PackageDestroyCallBack_FunctionParams
	{
		// Token: 0x0402EEBE RID: 192190
		[FieldOffset(0)]
		public long packageIncId;

		// Token: 0x0402EEBF RID: 192191
		[FieldOffset(8)]
		public long dropIncIds;

		// Token: 0x0402EEC0 RID: 192192
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}
}
