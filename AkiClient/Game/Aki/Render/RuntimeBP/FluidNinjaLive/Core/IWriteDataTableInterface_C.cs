using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D14 RID: 15636
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/WriteDataTableInterface.WriteDataTableInterface_C")]
	public interface IWriteDataTableInterface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x06025C12 RID: 154642 RVA: 0x009C4194 File Offset: 0x009C2394
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void WriteDataTableFunction([Nullable(2)] UDataTable InputTable, string InputData)
		{
			IWriteDataTableInterface_C.__WriteDataTableFunction_FunctionParams* ptr = stackalloc IWriteDataTableInterface_C.__WriteDataTableFunction_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(IWriteDataTableInterface_C.__WriteDataTableFunction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IWriteDataTableInterface_C_ReflectionImplementationFields.__WriteDataTableFunction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputTable = ((InputTable != null) ? InputTable.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->InputData), InputData);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IWriteDataTableInterface_C_ReflectionImplementationFields.__WriteDataTableFunction_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(IWriteDataTableInterface_C_ReflectionImplementationFields.__WriteDataTableFunction_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0401380A RID: 79882
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/WriteDataTableInterface.WriteDataTableInterface_C";

		// Token: 0x02009FA2 RID: 40866
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __WriteDataTableFunction_FunctionParams
		{
			// Token: 0x04032B50 RID: 207696
			[FieldOffset(0)]
			public IntPtr InputTable;

			// Token: 0x04032B51 RID: 207697
			[FieldOffset(8)]
			public FString InputData;
		}
	}
}
