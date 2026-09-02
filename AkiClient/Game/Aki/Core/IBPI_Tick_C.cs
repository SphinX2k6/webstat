using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F33 RID: 16179
	[UnrealObjectPath("/Game/Aki/Core/BPI_Tick.BPI_Tick_C")]
	public interface IBPI_Tick_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602865B RID: 165467 RVA: 0x00A094A0 File Offset: 0x00A076A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void Tick(float DeltaSeconds)
		{
			IBPI_Tick_C.__Tick_FunctionParams* ptr = stackalloc IBPI_Tick_C.__Tick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_Tick_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Tick_C_ReflectionImplementationFields.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Tick_C_ReflectionImplementationFields.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x040153EB RID: 87019
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/BPI_Tick.BPI_Tick_C";

		// Token: 0x0200A0E4 RID: 41188
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Tick_FunctionParams
		{
			// Token: 0x04032DA3 RID: 208291
			[FieldOffset(0)]
			public float DeltaSeconds;
		}
	}
}
