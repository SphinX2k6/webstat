using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal
{
	// Token: 0x020040F2 RID: 16626
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/BPI_AnimalEcological.BPI_AnimalEcological_C")]
	public interface IBPI_AnimalEcological_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602C442 RID: 181314 RVA: 0x00A9BA87 File Offset: 0x00A99C87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void SystemUiEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__SystemUiEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C443 RID: 181315 RVA: 0x00A9BA9B File Offset: 0x00A99C9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void SystemUiStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__SystemUiStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C444 RID: 181316 RVA: 0x00A9BAB0 File Offset: 0x00A99CB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void FeedStart(FGameplayTag GameplayTag)
		{
			IBPI_AnimalEcological_C.__FeedStart_FunctionParams* ptr = stackalloc IBPI_AnimalEcological_C.__FeedStart_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_AnimalEcological_C.__FeedStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_AnimalEcological_C_ReflectionImplementationFields.__FeedStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GameplayTag = GameplayTag;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__FeedStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C445 RID: 181317 RVA: 0x00A9BAF8 File Offset: 0x00A99CF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GetCurrentActionTime(ref float ActionTime)
		{
			IBPI_AnimalEcological_C.__GetCurrentActionTime_FunctionParams* ptr = stackalloc IBPI_AnimalEcological_C.__GetCurrentActionTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_AnimalEcological_C.__GetCurrentActionTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_AnimalEcological_C_ReflectionImplementationFields.__GetCurrentActionTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ActionTime = ActionTime;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__GetCurrentActionTime_NativeFunctionPtr, (void*)ptr);
			ActionTime = ptr->ActionTime;
		}

		// Token: 0x0602C446 RID: 181318 RVA: 0x00A9BB47 File Offset: 0x00A99D47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void NoneStateEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__NoneStateEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C447 RID: 181319 RVA: 0x00A9BB5B File Offset: 0x00A99D5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void NoneStateStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__NoneStateStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C448 RID: 181320 RVA: 0x00A9BB6F File Offset: 0x00A99D6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void StateMachineInitializationComplete()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__StateMachineInitializationComplete_NativeFunctionPtr, null);
		}

		// Token: 0x0602C449 RID: 181321 RVA: 0x00A9BB83 File Offset: 0x00A99D83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void InteractEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__InteractEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C44A RID: 181322 RVA: 0x00A9BB97 File Offset: 0x00A99D97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void InteractStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__InteractStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C44B RID: 181323 RVA: 0x00A9BBAB File Offset: 0x00A99DAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void IdleEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__IdleEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C44C RID: 181324 RVA: 0x00A9BBBF File Offset: 0x00A99DBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void IdleStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__IdleStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C44D RID: 181325 RVA: 0x00A9BBD3 File Offset: 0x00A99DD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void UnderAttackEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__UnderAttackEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C44E RID: 181326 RVA: 0x00A9BBE7 File Offset: 0x00A99DE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void UnderAttackStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__UnderAttackStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C44F RID: 181327 RVA: 0x00A9BBFB File Offset: 0x00A99DFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void AlertEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__AlertEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C450 RID: 181328 RVA: 0x00A9BC0F File Offset: 0x00A99E0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void AlertStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__AlertStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C451 RID: 181329 RVA: 0x00A9BC23 File Offset: 0x00A99E23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void TakeOffEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__TakeOffEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C452 RID: 181330 RVA: 0x00A9BC37 File Offset: 0x00A99E37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void TakeOffStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_AnimalEcological_C_ReflectionImplementationFields.__TakeOffStart_NativeFunctionPtr, null);
		}

		// Token: 0x040188CA RID: 100554
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/BPI_AnimalEcological.BPI_AnimalEcological_C";

		// Token: 0x0200A434 RID: 42036
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __FeedStart_FunctionParams
		{
			// Token: 0x0403322F RID: 209455
			[FieldOffset(0)]
			public FGameplayTag GameplayTag;
		}

		// Token: 0x0200A435 RID: 42037
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetCurrentActionTime_FunctionParams
		{
			// Token: 0x04033230 RID: 209456
			[FieldOffset(0)]
			public float ActionTime;
		}
	}
}
