using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AEA RID: 15082
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BPI_DollActor.BPI_DollActor_C")]
	public interface IBPI_DollActor_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602064C RID: 132684 RVA: 0x0092A8C4 File Offset: 0x00928AC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void PlayGrabEffectByTransform(bool IsEndless, FTransformDouble Transform)
		{
			IBPI_DollActor_C.__PlayGrabEffectByTransform_FunctionParams* ptr = stackalloc IBPI_DollActor_C.__PlayGrabEffectByTransform_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(IBPI_DollActor_C.__PlayGrabEffectByTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_DollActor_C_ReflectionImplementationFields.__PlayGrabEffectByTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEndless = IsEndless;
			ptr->Transform = Transform;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__PlayGrabEffectByTransform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602064D RID: 132685 RVA: 0x0092A914 File Offset: 0x00928B14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void TogglePlayGrabAnim(bool Enable, float Rate)
		{
			IBPI_DollActor_C.__TogglePlayGrabAnim_FunctionParams* ptr = stackalloc IBPI_DollActor_C.__TogglePlayGrabAnim_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_DollActor_C.__TogglePlayGrabAnim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_DollActor_C_ReflectionImplementationFields.__TogglePlayGrabAnim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			ptr->Rate = Rate;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__TogglePlayGrabAnim_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602064E RID: 132686 RVA: 0x0092A964 File Offset: 0x00928B64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void TogglePlayShow(bool Toggle, float PlayRate)
		{
			IBPI_DollActor_C.__TogglePlayShow_FunctionParams* ptr = stackalloc IBPI_DollActor_C.__TogglePlayShow_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_DollActor_C.__TogglePlayShow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_DollActor_C_ReflectionImplementationFields.__TogglePlayShow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Toggle = Toggle;
			ptr->PlayRate = PlayRate;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__TogglePlayShow_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602064F RID: 132687 RVA: 0x0092A9B1 File Offset: 0x00928BB1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void PlayTimeEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__PlayTimeEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06020650 RID: 132688 RVA: 0x0092A9C5 File Offset: 0x00928BC5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void ResetPhysics()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__ResetPhysics_NativeFunctionPtr, null);
		}

		// Token: 0x06020651 RID: 132689 RVA: 0x0092A9DC File Offset: 0x00928BDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void PlayGrabEffectByLocation(FVectorDouble Location)
		{
			IBPI_DollActor_C.__PlayGrabEffectByLocation_FunctionParams* ptr = stackalloc IBPI_DollActor_C.__PlayGrabEffectByLocation_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(IBPI_DollActor_C.__PlayGrabEffectByLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_DollActor_C_ReflectionImplementationFields.__PlayGrabEffectByLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__PlayGrabEffectByLocation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020652 RID: 132690 RVA: 0x0092AA24 File Offset: 0x00928C24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void SetPhysicsParameters(float AngularDamping, float LineraDamping)
		{
			IBPI_DollActor_C.__SetPhysicsParameters_FunctionParams* ptr = stackalloc IBPI_DollActor_C.__SetPhysicsParameters_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_DollActor_C.__SetPhysicsParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_DollActor_C_ReflectionImplementationFields.__SetPhysicsParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AngularDamping = AngularDamping;
			ptr->LineraDamping = LineraDamping;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__SetPhysicsParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020653 RID: 132691 RVA: 0x0092AA71 File Offset: 0x00928C71
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void PlaySpawnEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__PlaySpawnEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06020654 RID: 132692 RVA: 0x0092AA88 File Offset: 0x00928C88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void PlayGrabEffect(bool IsEndless, FVectorDouble Location)
		{
			IBPI_DollActor_C.__PlayGrabEffect_FunctionParams* ptr = stackalloc IBPI_DollActor_C.__PlayGrabEffect_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(IBPI_DollActor_C.__PlayGrabEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_DollActor_C_ReflectionImplementationFields.__PlayGrabEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEndless = IsEndless;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__PlayGrabEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020655 RID: 132693 RVA: 0x0092AAD8 File Offset: 0x00928CD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void SetVisible(bool ToggleVisibility, bool TogglePhysics)
		{
			IBPI_DollActor_C.__SetVisible_FunctionParams* ptr = stackalloc IBPI_DollActor_C.__SetVisible_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(IBPI_DollActor_C.__SetVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_DollActor_C_ReflectionImplementationFields.__SetVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ToggleVisibility = ToggleVisibility;
			ptr->TogglePhysics = TogglePhysics;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DollActor_C_ReflectionImplementationFields.__SetVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x040102E5 RID: 66277
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BPI_DollActor.BPI_DollActor_C";

		// Token: 0x020099A3 RID: 39331
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __PlayGrabEffectByTransform_FunctionParams
		{
			// Token: 0x04032036 RID: 204854
			[FieldOffset(0)]
			public bool IsEndless;

			// Token: 0x04032037 RID: 204855
			[FieldOffset(16)]
			public FTransformDouble Transform;
		}

		// Token: 0x020099A4 RID: 39332
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __TogglePlayGrabAnim_FunctionParams
		{
			// Token: 0x04032038 RID: 204856
			[FieldOffset(0)]
			public bool Enable;

			// Token: 0x04032039 RID: 204857
			[FieldOffset(4)]
			public float Rate;
		}

		// Token: 0x020099A5 RID: 39333
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __TogglePlayShow_FunctionParams
		{
			// Token: 0x0403203A RID: 204858
			[FieldOffset(0)]
			public bool Toggle;

			// Token: 0x0403203B RID: 204859
			[FieldOffset(4)]
			public float PlayRate;
		}

		// Token: 0x020099A6 RID: 39334
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __PlayGrabEffectByLocation_FunctionParams
		{
			// Token: 0x0403203C RID: 204860
			[FieldOffset(0)]
			public FVectorDouble Location;
		}

		// Token: 0x020099A7 RID: 39335
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetPhysicsParameters_FunctionParams
		{
			// Token: 0x0403203D RID: 204861
			[FieldOffset(0)]
			public float AngularDamping;

			// Token: 0x0403203E RID: 204862
			[FieldOffset(4)]
			public float LineraDamping;
		}

		// Token: 0x020099A8 RID: 39336
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __PlayGrabEffect_FunctionParams
		{
			// Token: 0x0403203F RID: 204863
			[FieldOffset(0)]
			public bool IsEndless;

			// Token: 0x04032040 RID: 204864
			[FieldOffset(8)]
			public FVectorDouble Location;
		}

		// Token: 0x020099A9 RID: 39337
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __SetVisible_FunctionParams
		{
			// Token: 0x04032041 RID: 204865
			[FieldOffset(0)]
			public bool ToggleVisibility;

			// Token: 0x04032042 RID: 204866
			[FieldOffset(1)]
			public bool TogglePhysics;
		}
	}
}
