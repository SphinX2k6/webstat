using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.InteractiveObject
{
	// Token: 0x02003DD2 RID: 15826
	[UnrealObjectPath("/Game/Aki/GamePlay/InteractiveObject/BPI_PhysicInteraction.BPI_PhysicInteraction_C")]
	public interface IBPI_PhysicInteraction_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x06026C4A RID: 158794 RVA: 0x009E18CC File Offset: 0x009DFACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void IsPhysicInteracted(ref bool OutInteracted)
		{
			IBPI_PhysicInteraction_C.__IsPhysicInteracted_FunctionParams* ptr = stackalloc IBPI_PhysicInteraction_C.__IsPhysicInteracted_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IBPI_PhysicInteraction_C.__IsPhysicInteracted_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_PhysicInteraction_C_ReflectionImplementationFields.__IsPhysicInteracted_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OutInteracted = OutInteracted;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_PhysicInteraction_C_ReflectionImplementationFields.__IsPhysicInteracted_NativeFunctionPtr, (void*)ptr);
			OutInteracted = ptr->OutInteracted;
		}

		// Token: 0x06026C4B RID: 158795 RVA: 0x009E191C File Offset: 0x009DFB1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void WeightResponse(int inMode)
		{
			IBPI_PhysicInteraction_C.__WeightResponse_FunctionParams* ptr = stackalloc IBPI_PhysicInteraction_C.__WeightResponse_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_PhysicInteraction_C.__WeightResponse_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_PhysicInteraction_C_ReflectionImplementationFields.__WeightResponse_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inMode = inMode;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_PhysicInteraction_C_ReflectionImplementationFields.__WeightResponse_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026C4C RID: 158796 RVA: 0x009E1962 File Offset: 0x009DFB62
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void ScanResponse()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_PhysicInteraction_C_ReflectionImplementationFields.__ScanResponse_NativeFunctionPtr, null);
		}

		// Token: 0x06026C4D RID: 158797 RVA: 0x009E1978 File Offset: 0x009DFB78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void GrabedResponse(bool inGrabed)
		{
			IBPI_PhysicInteraction_C.__GrabedResponse_FunctionParams* ptr = stackalloc IBPI_PhysicInteraction_C.__GrabedResponse_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IBPI_PhysicInteraction_C.__GrabedResponse_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_PhysicInteraction_C_ReflectionImplementationFields.__GrabedResponse_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inGrabed = inGrabed;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_PhysicInteraction_C_ReflectionImplementationFields.__GrabedResponse_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0401437D RID: 82813
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/GamePlay/InteractiveObject/BPI_PhysicInteraction.BPI_PhysicInteraction_C";

		// Token: 0x0200A0BC RID: 41148
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsPhysicInteracted_FunctionParams
		{
			// Token: 0x04032D6E RID: 208238
			[FieldOffset(0)]
			public bool OutInteracted;
		}

		// Token: 0x0200A0BD RID: 41149
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __WeightResponse_FunctionParams
		{
			// Token: 0x04032D6F RID: 208239
			[FieldOffset(0)]
			public int inMode;
		}

		// Token: 0x0200A0BE RID: 41150
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __GrabedResponse_FunctionParams
		{
			// Token: 0x04032D70 RID: 208240
			[FieldOffset(0)]
			public bool inGrabed;
		}
	}
}
