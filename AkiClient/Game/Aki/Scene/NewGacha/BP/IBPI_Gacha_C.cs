using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039C8 RID: 14792
	[UnrealObjectPath("/Game/Aki/Scene/NewGacha/BP/BPI_Gacha.BPI_Gacha_C")]
	public interface IBPI_Gacha_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0601DE93 RID: 122515 RVA: 0x008E6A58 File Offset: 0x008E4C58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void ShowroomStart(int Frame, float Subtime)
		{
			IBPI_Gacha_C.__ShowroomStart_FunctionParams* ptr = stackalloc IBPI_Gacha_C.__ShowroomStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_Gacha_C.__ShowroomStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Gacha_C_ReflectionImplementationFields.__ShowroomStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Gacha_C_ReflectionImplementationFields.__ShowroomStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DE94 RID: 122516 RVA: 0x008E6AA8 File Offset: 0x008E4CA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void OutroStart(int Frame, float Subtime)
		{
			IBPI_Gacha_C.__OutroStart_FunctionParams* ptr = stackalloc IBPI_Gacha_C.__OutroStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_Gacha_C.__OutroStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Gacha_C_ReflectionImplementationFields.__OutroStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Gacha_C_ReflectionImplementationFields.__OutroStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DE95 RID: 122517 RVA: 0x008E6AF8 File Offset: 0x008E4CF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void InteractStart(int Frame, float Subtime)
		{
			IBPI_Gacha_C.__InteractStart_FunctionParams* ptr = stackalloc IBPI_Gacha_C.__InteractStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_Gacha_C.__InteractStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Gacha_C_ReflectionImplementationFields.__InteractStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Gacha_C_ReflectionImplementationFields.__InteractStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DE96 RID: 122518 RVA: 0x008E6B48 File Offset: 0x008E4D48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void IntroStart(int Frame, float Subtime)
		{
			IBPI_Gacha_C.__IntroStart_FunctionParams* ptr = stackalloc IBPI_Gacha_C.__IntroStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(IBPI_Gacha_C.__IntroStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_Gacha_C_ReflectionImplementationFields.__IntroStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Frame = Frame;
			ptr->Subtime = Subtime;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_Gacha_C_ReflectionImplementationFields.__IntroStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0400EA88 RID: 60040
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BPI_Gacha.BPI_Gacha_C";

		// Token: 0x02009732 RID: 38706
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ShowroomStart_FunctionParams
		{
			// Token: 0x04031C9C RID: 203932
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031C9D RID: 203933
			[FieldOffset(4)]
			public float Subtime;
		}

		// Token: 0x02009733 RID: 38707
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OutroStart_FunctionParams
		{
			// Token: 0x04031C9E RID: 203934
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031C9F RID: 203935
			[FieldOffset(4)]
			public float Subtime;
		}

		// Token: 0x02009734 RID: 38708
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __InteractStart_FunctionParams
		{
			// Token: 0x04031CA0 RID: 203936
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031CA1 RID: 203937
			[FieldOffset(4)]
			public float Subtime;
		}

		// Token: 0x02009735 RID: 38709
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __IntroStart_FunctionParams
		{
			// Token: 0x04031CA2 RID: 203938
			[FieldOffset(0)]
			public int Frame;

			// Token: 0x04031CA3 RID: 203939
			[FieldOffset(4)]
			public float Subtime;
		}
	}
}
