using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.CarPaint.BluePrints
{
	// Token: 0x02003C37 RID: 15415
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BPI_CarPaintChange.BPI_CarPaintChange_C")]
	public interface IBPI_CarPaintChange_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x060235C4 RID: 144836 RVA: 0x0097FDBC File Offset: 0x0097DFBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void SetColorFunctionByBPI(bool _bool)
		{
			IBPI_CarPaintChange_C.__SetColorFunctionByBPI_FunctionParams* ptr = stackalloc IBPI_CarPaintChange_C.__SetColorFunctionByBPI_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IBPI_CarPaintChange_C.__SetColorFunctionByBPI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_CarPaintChange_C_ReflectionImplementationFields.__SetColorFunctionByBPI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->_bool = _bool;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_CarPaintChange_C_ReflectionImplementationFields.__SetColorFunctionByBPI_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x04011FE2 RID: 73698
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BPI_CarPaintChange.BPI_CarPaintChange_C";

		// Token: 0x02009CC9 RID: 40137
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetColorFunctionByBPI_FunctionParams
		{
			// Token: 0x04032634 RID: 206388
			[FieldOffset(0)]
			public bool _bool;
		}
	}
}
