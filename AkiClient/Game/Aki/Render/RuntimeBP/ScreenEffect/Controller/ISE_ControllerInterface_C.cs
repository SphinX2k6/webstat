using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Controller
{
	// Token: 0x02003A6F RID: 14959
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_ControllerInterface.SE_ControllerInterface_C")]
	public interface ISE_ControllerInterface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0601F2F9 RID: 127737 RVA: 0x0090A708 File Offset: 0x00908908
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void ApplyEnvironmentFactor(float EnvironmentFactor)
		{
			ISE_ControllerInterface_C.__ApplyEnvironmentFactor_FunctionParams* ptr = stackalloc ISE_ControllerInterface_C.__ApplyEnvironmentFactor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ISE_ControllerInterface_C.__ApplyEnvironmentFactor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ISE_ControllerInterface_C_ReflectionImplementationFields.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EnvironmentFactor = EnvironmentFactor;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, ISE_ControllerInterface_C_ReflectionImplementationFields.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2FA RID: 127738 RVA: 0x0090A74E File Offset: 0x0090894E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void BeforeStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, ISE_ControllerInterface_C_ReflectionImplementationFields.__BeforeStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601F2FB RID: 127739 RVA: 0x0090A764 File Offset: 0x00908964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void ApplyVisibility(bool visibility)
		{
			ISE_ControllerInterface_C.__ApplyVisibility_FunctionParams* ptr = stackalloc ISE_ControllerInterface_C.__ApplyVisibility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ISE_ControllerInterface_C.__ApplyVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ISE_ControllerInterface_C_ReflectionImplementationFields.__ApplyVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->visibility = visibility;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, ISE_ControllerInterface_C_ReflectionImplementationFields.__ApplyVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2FC RID: 127740 RVA: 0x0090A7AC File Offset: 0x009089AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void ApplyAlpha(float alpha)
		{
			ISE_ControllerInterface_C.__ApplyAlpha_FunctionParams* ptr = stackalloc ISE_ControllerInterface_C.__ApplyAlpha_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ISE_ControllerInterface_C.__ApplyAlpha_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ISE_ControllerInterface_C_ReflectionImplementationFields.__ApplyAlpha_NativeFunctionPtr, (void*)ptr, 1);
			ptr->alpha = alpha;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, ISE_ControllerInterface_C_ReflectionImplementationFields.__ApplyAlpha_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2FD RID: 127741 RVA: 0x0090A7F4 File Offset: 0x009089F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void End(float time)
		{
			ISE_ControllerInterface_C.__End_FunctionParams* ptr = stackalloc ISE_ControllerInterface_C.__End_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ISE_ControllerInterface_C.__End_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ISE_ControllerInterface_C_ReflectionImplementationFields.__End_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, ISE_ControllerInterface_C_ReflectionImplementationFields.__End_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2FE RID: 127742 RVA: 0x0090A83C File Offset: 0x00908A3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void Loop(float time)
		{
			ISE_ControllerInterface_C.__Loop_FunctionParams* ptr = stackalloc ISE_ControllerInterface_C.__Loop_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ISE_ControllerInterface_C.__Loop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ISE_ControllerInterface_C_ReflectionImplementationFields.__Loop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, ISE_ControllerInterface_C_ReflectionImplementationFields.__Loop_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2FF RID: 127743 RVA: 0x0090A884 File Offset: 0x00908A84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void Start(float time)
		{
			ISE_ControllerInterface_C.__Start_FunctionParams* ptr = stackalloc ISE_ControllerInterface_C.__Start_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ISE_ControllerInterface_C.__Start_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ISE_ControllerInterface_C_ReflectionImplementationFields.__Start_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, ISE_ControllerInterface_C_ReflectionImplementationFields.__Start_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0400F757 RID: 63319
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_ControllerInterface.SE_ControllerInterface_C";

		// Token: 0x0200988B RID: 39051
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ApplyEnvironmentFactor_FunctionParams
		{
			// Token: 0x04031ECF RID: 204495
			[FieldOffset(0)]
			public float EnvironmentFactor;
		}

		// Token: 0x0200988C RID: 39052
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __ApplyVisibility_FunctionParams
		{
			// Token: 0x04031ED0 RID: 204496
			[FieldOffset(0)]
			public bool visibility;
		}

		// Token: 0x0200988D RID: 39053
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ApplyAlpha_FunctionParams
		{
			// Token: 0x04031ED1 RID: 204497
			[FieldOffset(0)]
			public float alpha;
		}

		// Token: 0x0200988E RID: 39054
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __End_FunctionParams
		{
			// Token: 0x04031ED2 RID: 204498
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200988F RID: 39055
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Loop_FunctionParams
		{
			// Token: 0x04031ED3 RID: 204499
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x02009890 RID: 39056
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Start_FunctionParams
		{
			// Token: 0x04031ED4 RID: 204500
			[FieldOffset(0)]
			public float time;
		}
	}
}
