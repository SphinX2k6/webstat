using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Spindrift.Blueprint
{
	// Token: 0x02003B67 RID: 15207
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Spindrift/Blueprint/BPI_EditorTicker.BPI_EditorTicker_C")]
	public interface IBPI_EditorTicker_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x060216EF RID: 136943 RVA: 0x009490F8 File Offset: 0x009472F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_EditorTicker_C_ReflectionImplementationFields.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x04010D4D RID: 68941
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Spindrift/Blueprint/BPI_EditorTicker.BPI_EditorTicker_C";
	}
}
