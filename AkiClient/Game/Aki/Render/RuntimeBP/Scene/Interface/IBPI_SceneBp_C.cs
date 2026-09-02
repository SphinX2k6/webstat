using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface
{
	// Token: 0x02003AB9 RID: 15033
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interface/BPI_SceneBp.BPI_SceneBp_C")]
	public interface IBPI_SceneBp_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602013C RID: 131388 RVA: 0x0092190C File Offset: 0x0091FB0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void ShouldStopOnHide(ref bool ret)
		{
			IBPI_SceneBp_C.__ShouldStopOnHide_FunctionParams* ptr = stackalloc IBPI_SceneBp_C.__ShouldStopOnHide_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IBPI_SceneBp_C.__ShouldStopOnHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_SceneBp_C_ReflectionImplementationFields.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBp_C_ReflectionImplementationFields.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x0602013D RID: 131389 RVA: 0x0092195B File Offset: 0x0091FB5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void Resume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBp_C_ReflectionImplementationFields.__Resume_NativeFunctionPtr, null);
		}

		// Token: 0x0602013E RID: 131390 RVA: 0x0092196F File Offset: 0x0091FB6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void Pause()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBp_C_ReflectionImplementationFields.__Pause_NativeFunctionPtr, null);
		}

		// Token: 0x0602013F RID: 131391 RVA: 0x00921984 File Offset: 0x0091FB84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GetAoiRange(ref int ret)
		{
			IBPI_SceneBp_C.__GetAoiRange_FunctionParams* ptr = stackalloc IBPI_SceneBp_C.__GetAoiRange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_SceneBp_C.__GetAoiRange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_SceneBp_C_ReflectionImplementationFields.__GetAoiRange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBp_C_ReflectionImplementationFields.__GetAoiRange_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06020140 RID: 131392 RVA: 0x009219D3 File Offset: 0x0091FBD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBp_C_ReflectionImplementationFields.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x06020141 RID: 131393 RVA: 0x009219E7 File Offset: 0x0091FBE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBp_C_ReflectionImplementationFields.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x06020142 RID: 131394 RVA: 0x009219FB File Offset: 0x0091FBFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void TickOutside()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_SceneBp_C_ReflectionImplementationFields.__TickOutside_NativeFunctionPtr, null);
		}

		// Token: 0x0400FFAD RID: 65453
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interface/BPI_SceneBp.BPI_SceneBp_C";

		// Token: 0x02009958 RID: 39256
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __ShouldStopOnHide_FunctionParams
		{
			// Token: 0x04031FC2 RID: 204738
			[FieldOffset(0)]
			public bool ret;
		}

		// Token: 0x02009959 RID: 39257
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetAoiRange_FunctionParams
		{
			// Token: 0x04031FC3 RID: 204739
			[FieldOffset(0)]
			public int ret;
		}
	}
}
