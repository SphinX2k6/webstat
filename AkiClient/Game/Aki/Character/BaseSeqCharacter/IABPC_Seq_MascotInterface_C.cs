using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseSeqCharacter
{
	// Token: 0x020041B8 RID: 16824
	[UnrealObjectPath("/Game/Aki/Character/BaseSeqCharacter/ABPC_Seq_MascotInterface.ABPC_Seq_MascotInterface_C")]
	public interface IABPC_Seq_MascotInterface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602CB2F RID: 183087 RVA: 0x00AABD1C File Offset: 0x00AA9F1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GetAddSpineHeadValue(ref FRotator AddSpineHead)
		{
			IABPC_Seq_MascotInterface_C.__GetAddSpineHeadValue_FunctionParams* ptr = stackalloc IABPC_Seq_MascotInterface_C.__GetAddSpineHeadValue_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IABPC_Seq_MascotInterface_C.__GetAddSpineHeadValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IABPC_Seq_MascotInterface_C_ReflectionImplementationFields.__GetAddSpineHeadValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AddSpineHead = AddSpineHead;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IABPC_Seq_MascotInterface_C_ReflectionImplementationFields.__GetAddSpineHeadValue_NativeFunctionPtr, (void*)ptr);
			AddSpineHead = ptr->AddSpineHead;
		}

		// Token: 0x0602CB30 RID: 183088 RVA: 0x00AABD74 File Offset: 0x00AA9F74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GetAddSpineValue(ref FRotator AddSpine)
		{
			IABPC_Seq_MascotInterface_C.__GetAddSpineValue_FunctionParams* ptr = stackalloc IABPC_Seq_MascotInterface_C.__GetAddSpineValue_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IABPC_Seq_MascotInterface_C.__GetAddSpineValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IABPC_Seq_MascotInterface_C_ReflectionImplementationFields.__GetAddSpineValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AddSpine = AddSpine;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IABPC_Seq_MascotInterface_C_ReflectionImplementationFields.__GetAddSpineValue_NativeFunctionPtr, (void*)ptr);
			AddSpine = ptr->AddSpine;
		}

		// Token: 0x04018E61 RID: 101985
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseSeqCharacter/ABPC_Seq_MascotInterface.ABPC_Seq_MascotInterface_C";

		// Token: 0x0200A4E3 RID: 42211
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetAddSpineHeadValue_FunctionParams
		{
			// Token: 0x0403333C RID: 209724
			[FieldOffset(0)]
			public FRotator AddSpineHead;
		}

		// Token: 0x0200A4E4 RID: 42212
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetAddSpineValue_FunctionParams
		{
			// Token: 0x0403333D RID: 209725
			[FieldOffset(0)]
			public FRotator AddSpine;
		}
	}
}
