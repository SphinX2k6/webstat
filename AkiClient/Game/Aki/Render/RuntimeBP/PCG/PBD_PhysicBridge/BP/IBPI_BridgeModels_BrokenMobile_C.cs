using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BAD RID: 15277
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BPI_BridgeModels_BrokenMobile.BPI_BridgeModels_BrokenMobile_C")]
	public interface IBPI_BridgeModels_BrokenMobile_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x06021FE7 RID: 139239 RVA: 0x00959573 File Offset: 0x00957773
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void BreakTrigger()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_BridgeModels_BrokenMobile_C_ReflectionImplementationFields.__BreakTrigger_NativeFunctionPtr, null);
		}

		// Token: 0x040112BB RID: 70331
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BPI_BridgeModels_BrokenMobile.BPI_BridgeModels_BrokenMobile_C";
	}
}
