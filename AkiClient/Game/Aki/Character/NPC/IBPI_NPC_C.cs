using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Data.Interaction.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC
{
	// Token: 0x020040D9 RID: 16601
	[UnrealObjectPath("/Game/Aki/Character/NPC/BPI_NPC.BPI_NPC_C")]
	public interface IBPI_NPC_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602B6DF RID: 177887 RVA: 0x00A7BDF0 File Offset: 0x00A79FF0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe string GetNPCName()
		{
			IBPI_NPC_C.__GetNPCName_FunctionParams* ptr = stackalloc IBPI_NPC_C.__GetNPCName_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(IBPI_NPC_C.__GetNPCName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_NPC_C_ReflectionImplementationFields.__GetNPCName_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NPC_C_ReflectionImplementationFields.__GetNPCName_NativeFunctionPtr, (void*)ptr);
			string result = FString.ToString((void*)(&ptr->__Result));
			UnrealReflectionUtils.DestroyStruct(IBPI_NPC_C_ReflectionImplementationFields.__GetNPCName_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602B6E0 RID: 177888 RVA: 0x00A7BE4C File Offset: 0x00A7A04C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe SInteractionConfig GetCurrInteractionConfig()
		{
			IBPI_NPC_C.__GetCurrInteractionConfig_FunctionParams* ptr = stackalloc IBPI_NPC_C.__GetCurrInteractionConfig_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(IBPI_NPC_C.__GetCurrInteractionConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_NPC_C_ReflectionImplementationFields.__GetCurrInteractionConfig_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NPC_C_ReflectionImplementationFields.__GetCurrInteractionConfig_NativeFunctionPtr, (void*)ptr);
			SInteractionConfig result = new SInteractionConfig(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(IBPI_NPC_C_ReflectionImplementationFields.__GetCurrInteractionConfig_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602B6E1 RID: 177889 RVA: 0x00A7BEAD File Offset: 0x00A7A0AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void InteractNPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NPC_C_ReflectionImplementationFields.__InteractNPC_NativeFunctionPtr, null);
		}

		// Token: 0x0602B6E2 RID: 177890 RVA: 0x00A7BEC4 File Offset: 0x00A7A0C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe bool TriggerNPCInteraction()
		{
			IBPI_NPC_C.__TriggerNPCInteraction_FunctionParams* ptr = stackalloc IBPI_NPC_C.__TriggerNPCInteraction_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IBPI_NPC_C.__TriggerNPCInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_NPC_C_ReflectionImplementationFields.__TriggerNPCInteraction_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NPC_C_ReflectionImplementationFields.__TriggerNPCInteraction_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602B6E3 RID: 177891 RVA: 0x00A7BF0C File Offset: 0x00A7A10C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe bool IsNPCInteractable()
		{
			IBPI_NPC_C.__IsNPCInteractable_FunctionParams* ptr = stackalloc IBPI_NPC_C.__IsNPCInteractable_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IBPI_NPC_C.__IsNPCInteractable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_NPC_C_ReflectionImplementationFields.__IsNPCInteractable_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NPC_C_ReflectionImplementationFields.__IsNPCInteractable_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602B6E4 RID: 177892 RVA: 0x00A7BF54 File Offset: 0x00A7A154
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe bool ApplyEntityConfig(SEntityConfig inConfig)
		{
			IBPI_NPC_C.__ApplyEntityConfig_FunctionParams* ptr = stackalloc IBPI_NPC_C.__ApplyEntityConfig_FunctionParams[(UIntPtr)695] + 15L / (long)sizeof(IBPI_NPC_C.__ApplyEntityConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_NPC_C_ReflectionImplementationFields.__ApplyEntityConfig_NativeFunctionPtr, (void*)ptr, 1);
			if (inConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEntityConfig.StaticStruct(), &ptr->inConfig, inConfig.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NPC_C_ReflectionImplementationFields.__ApplyEntityConfig_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(IBPI_NPC_C_ReflectionImplementationFields.__ApplyEntityConfig_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B6E5 RID: 177893 RVA: 0x00A7BFD0 File Offset: 0x00A7A1D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void NPC通用回调事件(FName EventID)
		{
			IBPI_NPC_C.__NPC通用回调事件_FunctionParams* ptr = stackalloc IBPI_NPC_C.__NPC通用回调事件_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(IBPI_NPC_C.__NPC通用回调事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_NPC_C_ReflectionImplementationFields.__NPC通用回调事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EventID = EventID;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NPC_C_ReflectionImplementationFields.__NPC通用回调事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x04017D26 RID: 97574
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/NPC/BPI_NPC.BPI_NPC_C";

		// Token: 0x0200A3B3 RID: 41907
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetNPCName_FunctionParams
		{
			// Token: 0x04033190 RID: 209296
			[FieldOffset(0)]
			public FString __Result;
		}

		// Token: 0x0200A3B4 RID: 41908
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __GetCurrInteractionConfig_FunctionParams
		{
			// Token: 0x04033191 RID: 209297
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A3B5 RID: 41909
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __TriggerNPCInteraction_FunctionParams
		{
			// Token: 0x04033192 RID: 209298
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A3B6 RID: 41910
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsNPCInteractable_FunctionParams
		{
			// Token: 0x04033193 RID: 209299
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A3B7 RID: 41911
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 680)]
		protected ref struct __ApplyEntityConfig_FunctionParams
		{
			// Token: 0x04033194 RID: 209300
			[FieldOffset(0)]
			public byte inConfig;

			// Token: 0x04033195 RID: 209301
			[FieldOffset(672)]
			public bool __Result;
		}

		// Token: 0x0200A3B8 RID: 41912
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __NPC通用回调事件_FunctionParams
		{
			// Token: 0x04033196 RID: 209302
			[FieldOffset(0)]
			public FName EventID;
		}
	}
}
