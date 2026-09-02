using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FFE RID: 16382
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/IAbp_Shell.IAbp_Shell_C")]
	public interface IIAbp_Shell_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602A870 RID: 174192 RVA: 0x00A5BFEC File Offset: 0x00A5A1EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		unsafe void SetEnableAreaMove(bool Enable)
		{
			IIAbp_Shell_C.__SetEnableAreaMove_FunctionParams* ptr = stackalloc IIAbp_Shell_C.__SetEnableAreaMove_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(IIAbp_Shell_C.__SetEnableAreaMove_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(IIAbp_Shell_C_ReflectionImplementationFields.__SetEnableAreaMove_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable = Enable;
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IIAbp_Shell_C_ReflectionImplementationFields.__SetEnableAreaMove_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0401720C RID: 94732
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/IAbp_Shell.IAbp_Shell_C";

		// Token: 0x0200A253 RID: 41555
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetEnableAreaMove_FunctionParams
		{
			// Token: 0x04032FFC RID: 208892
			[FieldOffset(0)]
			public bool Enable;
		}
	}
}
