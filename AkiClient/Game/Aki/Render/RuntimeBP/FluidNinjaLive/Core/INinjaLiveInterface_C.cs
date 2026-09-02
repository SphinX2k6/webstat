using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D04 RID: 15620
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveInterface.NinjaLiveInterface_C")]
	public interface INinjaLiveInterface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x06025B89 RID: 154505 RVA: 0x009C2F58 File Offset: 0x009C1158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void LiveFluidParams(float BrushSize)
		{
			INinjaLiveInterface_C.__LiveFluidParams_FunctionParams* ptr = stackalloc INinjaLiveInterface_C.__LiveFluidParams_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(INinjaLiveInterface_C.__LiveFluidParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(INinjaLiveInterface_C_ReflectionImplementationFields.__LiveFluidParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BrushSize = BrushSize;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, INinjaLiveInterface_C_ReflectionImplementationFields.__LiveFluidParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B8A RID: 154506 RVA: 0x009C2FA0 File Offset: 0x009C11A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void LiveActivation(FName ParamName, float FadeTimeOfBrush, float FadeTimeOfCanvas)
		{
			INinjaLiveInterface_C.__LiveActivation_FunctionParams* ptr = stackalloc INinjaLiveInterface_C.__LiveActivation_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(INinjaLiveInterface_C.__LiveActivation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(INinjaLiveInterface_C_ReflectionImplementationFields.__LiveActivation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ParamName = ParamName;
			ptr->FadeTimeOfBrush = FadeTimeOfBrush;
			ptr->FadeTimeOfCanvas = FadeTimeOfCanvas;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, INinjaLiveInterface_C_ReflectionImplementationFields.__LiveActivation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x040137A5 RID: 79781
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveInterface.NinjaLiveInterface_C";

		// Token: 0x02009F8D RID: 40845
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __LiveFluidParams_FunctionParams
		{
			// Token: 0x04032B2C RID: 207660
			[FieldOffset(0)]
			public float BrushSize;
		}

		// Token: 0x02009F8E RID: 40846
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __LiveActivation_FunctionParams
		{
			// Token: 0x04032B2D RID: 207661
			[FieldOffset(0)]
			public FName ParamName;

			// Token: 0x04032B2E RID: 207662
			[FieldOffset(12)]
			public float FadeTimeOfBrush;

			// Token: 0x04032B2F RID: 207663
			[FieldOffset(16)]
			public float FadeTimeOfCanvas;
		}
	}
}
