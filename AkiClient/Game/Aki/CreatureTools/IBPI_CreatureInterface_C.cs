using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.CreatureTools
{
	// Token: 0x02003F28 RID: 16168
	[UnrealObjectPath("/Game/Aki/CreatureTools/BPI_CreatureInterface.BPI_CreatureInterface_C")]
	public interface IBPI_CreatureInterface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x060285A2 RID: 165282 RVA: 0x00A0854C File Offset: 0x00A0674C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe int GetEntityId()
		{
			IBPI_CreatureInterface_C.__GetEntityId_FunctionParams* ptr = stackalloc IBPI_CreatureInterface_C.__GetEntityId_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(IBPI_CreatureInterface_C.__GetEntityId_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IBPI_CreatureInterface_C_ReflectionImplementationFields.__GetEntityId_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_CreatureInterface_C_ReflectionImplementationFields.__GetEntityId_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x04015396 RID: 86934
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/CreatureTools/BPI_CreatureInterface.BPI_CreatureInterface_C";

		// Token: 0x0200A0E3 RID: 41187
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetEntityId_FunctionParams
		{
			// Token: 0x04032DA2 RID: 208290
			[FieldOffset(0)]
			public int __Result;
		}
	}
}
