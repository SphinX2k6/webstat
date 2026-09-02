using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.TickMaster
{
	// Token: 0x02003CA9 RID: 15529
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/TickMaster/BPI_EditorTickMaster.BPI_EditorTickMaster_C")]
	public interface IBPI_EditorTickMaster_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x060249F2 RID: 150002 RVA: 0x009A302C File Offset: 0x009A122C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void EditorTickMaster(float DeltaTime)
		{
			IBPI_EditorTickMaster_C.__EditorTickMaster_FunctionParams* ptr = stackalloc IBPI_EditorTickMaster_C.__EditorTickMaster_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_EditorTickMaster_C.__EditorTickMaster_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_EditorTickMaster_C_ReflectionImplementationFields.__EditorTickMaster_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_EditorTickMaster_C_ReflectionImplementationFields.__EditorTickMaster_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x04012C6F RID: 76911
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/TickMaster/BPI_EditorTickMaster.BPI_EditorTickMaster_C";

		// Token: 0x02009E23 RID: 40483
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __EditorTickMaster_FunctionParams
		{
			// Token: 0x0403286F RID: 206959
			[FieldOffset(0)]
			public float DeltaTime;
		}
	}
}
