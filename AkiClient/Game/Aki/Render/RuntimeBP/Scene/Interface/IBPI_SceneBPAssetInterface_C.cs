using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface
{
	// Token: 0x02003AB8 RID: 15032
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interface/BPI_SceneBPAssetInterface.BPI_SceneBPAssetInterface_C")]
	public interface IBPI_SceneBPAssetInterface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602013A RID: 131386 RVA: 0x00921840 File Offset: 0x0091FA40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void WillExport(ref bool Export)
		{
			IBPI_SceneBPAssetInterface_C.__WillExport_FunctionParams* ptr = stackalloc IBPI_SceneBPAssetInterface_C.__WillExport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IBPI_SceneBPAssetInterface_C.__WillExport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_SceneBPAssetInterface_C_ReflectionImplementationFields.__WillExport_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Export = Export;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBPAssetInterface_C_ReflectionImplementationFields.__WillExport_NativeFunctionPtr, (void*)ptr);
			Export = ptr->Export;
		}

		// Token: 0x0602013B RID: 131387 RVA: 0x00921890 File Offset: 0x0091FA90
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void IsAssetValid(ref bool Valid, ref string Reason)
		{
			IBPI_SceneBPAssetInterface_C.__IsAssetValid_FunctionParams* ptr = stackalloc IBPI_SceneBPAssetInterface_C.__IsAssetValid_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(IBPI_SceneBPAssetInterface_C.__IsAssetValid_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_SceneBPAssetInterface_C_ReflectionImplementationFields.__IsAssetValid_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Valid = Valid;
			FString.CopyFrom((void*)(&ptr->Reason), Reason);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBPAssetInterface_C_ReflectionImplementationFields.__IsAssetValid_NativeFunctionPtr, (void*)ptr);
			Valid = ptr->Valid;
			Reason = FString.ToString((void*)(&ptr->Reason));
			UnrealReflectionUtils.DestroyStruct(IBPI_SceneBPAssetInterface_C_ReflectionImplementationFields.__IsAssetValid_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0400FFAC RID: 65452
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interface/BPI_SceneBPAssetInterface.BPI_SceneBPAssetInterface_C";

		// Token: 0x02009956 RID: 39254
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __WillExport_FunctionParams
		{
			// Token: 0x04031FBF RID: 204735
			[FieldOffset(0)]
			public bool Export;
		}

		// Token: 0x02009957 RID: 39255
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __IsAssetValid_FunctionParams
		{
			// Token: 0x04031FC0 RID: 204736
			[FieldOffset(0)]
			public bool Valid;

			// Token: 0x04031FC1 RID: 204737
			[FieldOffset(8)]
			public FString Reason;
		}
	}
}
