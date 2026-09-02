using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseSeqCharacter
{
	// Token: 0x020041B9 RID: 16825
	[UnrealObjectPath("/Game/Aki/Character/BaseSeqCharacter/BPI_SeqAudio.BPI_SeqAudio_C")]
	public interface IBPI_SeqAudio_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602CB31 RID: 183089 RVA: 0x00AABDCC File Offset: 0x00AA9FCC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GetSeqAudio(ref SeqAudio_Seq_V2_C SeqAudio)
		{
			IBPI_SeqAudio_C.__GetSeqAudio_FunctionParams* ptr = stackalloc IBPI_SeqAudio_C.__GetSeqAudio_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_SeqAudio_C.__GetSeqAudio_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_SeqAudio_C_ReflectionImplementationFields.__GetSeqAudio_NativeFunctionPtr, (void*)ptr, 1);
			ref IBPI_SeqAudio_C.__GetSeqAudio_FunctionParams ptr2 = ref *ptr;
			SeqAudio_Seq_V2_C seqAudio_Seq_V2_C = SeqAudio;
			ptr2.SeqAudio = ((seqAudio_Seq_V2_C != null) ? seqAudio_Seq_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SeqAudio_C_ReflectionImplementationFields.__GetSeqAudio_NativeFunctionPtr, (void*)ptr);
			SeqAudio = BuiltinUtils.GetOrCreateUObjectByNativePointer<SeqAudio_Seq_V2_C>(ptr->SeqAudio);
		}

		// Token: 0x04018E62 RID: 101986
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseSeqCharacter/BPI_SeqAudio.BPI_SeqAudio_C";

		// Token: 0x0200A4E5 RID: 42213
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetSeqAudio_FunctionParams
		{
			// Token: 0x0403333E RID: 209726
			[FieldOffset(0)]
			public IntPtr SeqAudio;
		}
	}
}
