using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C0 RID: 16832
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BPI_Animation.BPI_Animation_C")]
	public interface IBPI_Animation_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602CB90 RID: 183184 RVA: 0x00AACF80 File Offset: 0x00AAB180
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceControlPoint(FVector Offset)
		{
			IBPI_Animation_C.__InterfaceControlPoint_FunctionParams* ptr = stackalloc IBPI_Animation_C.__InterfaceControlPoint_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_Animation_C.__InterfaceControlPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Animation_C_ReflectionImplementationFields.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Animation_C_ReflectionImplementationFields.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB91 RID: 183185 RVA: 0x00AACFC8 File Offset: 0x00AAB1C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceManipulateInteractDirection(float 角度)
		{
			IBPI_Animation_C.__InterfaceManipulateInteractDirection_FunctionParams* ptr = stackalloc IBPI_Animation_C.__InterfaceManipulateInteractDirection_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_Animation_C.__InterfaceManipulateInteractDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Animation_C_ReflectionImplementationFields.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角度 = 角度;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Animation_C_ReflectionImplementationFields.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB92 RID: 183186 RVA: 0x00AAD010 File Offset: 0x00AAB210
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceFixHookDirect(FVector Offset)
		{
			IBPI_Animation_C.__InterfaceFixHookDirect_FunctionParams* ptr = stackalloc IBPI_Animation_C.__InterfaceFixHookDirect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_Animation_C.__InterfaceFixHookDirect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Animation_C_ReflectionImplementationFields.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Animation_C_ReflectionImplementationFields.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB93 RID: 183187 RVA: 0x00AAD058 File Offset: 0x00AAB258
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceSimulateJump(float Speed)
		{
			IBPI_Animation_C.__InterfaceSimulateJump_FunctionParams* ptr = stackalloc IBPI_Animation_C.__InterfaceSimulateJump_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_Animation_C.__InterfaceSimulateJump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Animation_C_ReflectionImplementationFields.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Animation_C_ReflectionImplementationFields.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB94 RID: 183188 RVA: 0x00AAD09E File Offset: 0x00AAB29E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void ClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Animation_C_ReflectionImplementationFields.__ClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB95 RID: 183189 RVA: 0x00AAD0B4 File Offset: 0x00AAB2B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InterfaceJumpPressed(ref float Speed)
		{
			IBPI_Animation_C.__InterfaceJumpPressed_FunctionParams* ptr = stackalloc IBPI_Animation_C.__InterfaceJumpPressed_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_Animation_C.__InterfaceJumpPressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Animation_C_ReflectionImplementationFields.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Animation_C_ReflectionImplementationFields.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr);
			Speed = ptr->Speed;
		}

		// Token: 0x04018EB1 RID: 102065
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BPI_Animation.BPI_Animation_C";

		// Token: 0x0200A4F9 RID: 42233
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceControlPoint_FunctionParams
		{
			// Token: 0x04033364 RID: 209764
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A4FA RID: 42234
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceManipulateInteractDirection_FunctionParams
		{
			// Token: 0x04033365 RID: 209765
			[FieldOffset(0)]
			public float 角度;
		}

		// Token: 0x0200A4FB RID: 42235
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceFixHookDirect_FunctionParams
		{
			// Token: 0x04033366 RID: 209766
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A4FC RID: 42236
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceSimulateJump_FunctionParams
		{
			// Token: 0x04033367 RID: 209767
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A4FD RID: 42237
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceJumpPressed_FunctionParams
		{
			// Token: 0x04033368 RID: 209768
			[FieldOffset(0)]
			public float Speed;
		}
	}
}
