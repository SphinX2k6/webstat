using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseSeqCharacter
{
	// Token: 0x020041B7 RID: 16823
	[UnrealObjectPath("/Game/Aki/Character/BaseSeqCharacter/ABPC_Seq_Interface.ABPC_Seq_Interface_C")]
	public interface IABPC_Seq_Interface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602CB2E RID: 183086 RVA: 0x00AABCB8 File Offset: 0x00AA9EB8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GetABPC_Body_V2(ref ABPC_Seq_Body_V2_C ABPC_Body_V2)
		{
			IABPC_Seq_Interface_C.__GetABPC_Body_V2_FunctionParams* ptr = stackalloc IABPC_Seq_Interface_C.__GetABPC_Body_V2_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IABPC_Seq_Interface_C.__GetABPC_Body_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IABPC_Seq_Interface_C_ReflectionImplementationFields.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr, 1);
			ref IABPC_Seq_Interface_C.__GetABPC_Body_V2_FunctionParams ptr2 = ref *ptr;
			ABPC_Seq_Body_V2_C abpc_Seq_Body_V2_C = ABPC_Body_V2;
			ptr2.ABPC_Body_V2 = ((abpc_Seq_Body_V2_C != null) ? abpc_Seq_Body_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IABPC_Seq_Interface_C_ReflectionImplementationFields.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr);
			ABPC_Body_V2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ABPC_Seq_Body_V2_C>(ptr->ABPC_Body_V2);
		}

		// Token: 0x04018E60 RID: 101984
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseSeqCharacter/ABPC_Seq_Interface.ABPC_Seq_Interface_C";

		// Token: 0x0200A4E2 RID: 42210
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetABPC_Body_V2_FunctionParams
		{
			// Token: 0x0403333B RID: 209723
			[FieldOffset(0)]
			public IntPtr ABPC_Body_V2;
		}
	}
}
