using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect
{
	// Token: 0x02003D1C RID: 15644
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/BPI_EffectInterface.BPI_EffectInterface_C")]
	public interface IBPI_EffectInterface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x06025CF0 RID: 154864 RVA: 0x009C5A44 File Offset: 0x009C3C44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void RemoveHandle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_EffectInterface_C_ReflectionImplementationFields.__RemoveHandle_NativeFunctionPtr, null);
		}

		// Token: 0x06025CF1 RID: 154865 RVA: 0x009C5A58 File Offset: 0x009C3C58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void SetHandle(int Handle)
		{
			IBPI_EffectInterface_C.__SetHandle_FunctionParams* ptr = stackalloc IBPI_EffectInterface_C.__SetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_EffectInterface_C.__SetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_EffectInterface_C_ReflectionImplementationFields.__SetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_EffectInterface_C_ReflectionImplementationFields.__SetHandle_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025CF2 RID: 154866 RVA: 0x009C5AA0 File Offset: 0x009C3CA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GetHandle(ref int Handle)
		{
			IBPI_EffectInterface_C.__GetHandle_FunctionParams* ptr = stackalloc IBPI_EffectInterface_C.__GetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_EffectInterface_C.__GetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_EffectInterface_C_ReflectionImplementationFields.__GetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_EffectInterface_C_ReflectionImplementationFields.__GetHandle_NativeFunctionPtr, (void*)ptr);
			Handle = ptr->Handle;
		}

		// Token: 0x04013896 RID: 80022
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/BPI_EffectInterface.BPI_EffectInterface_C";

		// Token: 0x02009FB6 RID: 40886
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetHandle_FunctionParams
		{
			// Token: 0x04032B6C RID: 207724
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009FB7 RID: 40887
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetHandle_FunctionParams
		{
			// Token: 0x04032B6D RID: 207725
			[FieldOffset(0)]
			public int Handle;
		}
	}
}
