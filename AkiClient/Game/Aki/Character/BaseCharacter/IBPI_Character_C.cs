using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C2 RID: 16834
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BPI_Character.BPI_Character_C")]
	public interface IBPI_Character_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602CB97 RID: 183191 RVA: 0x00AAD118 File Offset: 0x00AAB318
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceSetCharState(FGameplayTag newCharState)
		{
			IBPI_Character_C.__InterfaceSetCharState_FunctionParams* ptr = stackalloc IBPI_Character_C.__InterfaceSetCharState_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_Character_C.__InterfaceSetCharState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetCharState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->newCharState = newCharState;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetCharState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB98 RID: 183192 RVA: 0x00AAD160 File Offset: 0x00AAB360
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceSetGait(FGameplayTag newGait)
		{
			IBPI_Character_C.__InterfaceSetGait_FunctionParams* ptr = stackalloc IBPI_Character_C.__InterfaceSetGait_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_Character_C.__InterfaceSetGait_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetGait_NativeFunctionPtr, (void*)ptr, 1);
			ptr->newGait = newGait;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetGait_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB99 RID: 183193 RVA: 0x00AAD1A8 File Offset: 0x00AAB3A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceSetRotationMode(FGameplayTag newRotationMode)
		{
			IBPI_Character_C.__InterfaceSetRotationMode_FunctionParams* ptr = stackalloc IBPI_Character_C.__InterfaceSetRotationMode_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_Character_C.__InterfaceSetRotationMode_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetRotationMode_NativeFunctionPtr, (void*)ptr, 1);
			ptr->newRotationMode = newRotationMode;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetRotationMode_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB9A RID: 183194 RVA: 0x00AAD1F0 File Offset: 0x00AAB3F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceSetMovementState(FGameplayTag newMovementState)
		{
			IBPI_Character_C.__InterfaceSetMovementState_FunctionParams* ptr = stackalloc IBPI_Character_C.__InterfaceSetMovementState_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_Character_C.__InterfaceSetMovementState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetMovementState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->newMovementState = newMovementState;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Character_C_ReflectionImplementationFields.__InterfaceSetMovementState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x04018EB3 RID: 102067
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BPI_Character.BPI_Character_C";

		// Token: 0x0200A4FE RID: 42238
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceSetCharState_FunctionParams
		{
			// Token: 0x04033369 RID: 209769
			[FieldOffset(0)]
			public FGameplayTag newCharState;
		}

		// Token: 0x0200A4FF RID: 42239
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceSetGait_FunctionParams
		{
			// Token: 0x0403336A RID: 209770
			[FieldOffset(0)]
			public FGameplayTag newGait;
		}

		// Token: 0x0200A500 RID: 42240
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceSetRotationMode_FunctionParams
		{
			// Token: 0x0403336B RID: 209771
			[FieldOffset(0)]
			public FGameplayTag newRotationMode;
		}

		// Token: 0x0200A501 RID: 42241
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceSetMovementState_FunctionParams
		{
			// Token: 0x0403336C RID: 209772
			[FieldOffset(0)]
			public FGameplayTag newMovementState;
		}
	}
}
