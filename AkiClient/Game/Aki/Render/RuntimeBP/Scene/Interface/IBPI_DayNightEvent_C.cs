using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface
{
	// Token: 0x02003AB7 RID: 15031
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interface/BPI_DayNightEvent.BPI_DayNightEvent_C")]
	public interface IBPI_DayNightEvent_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x06020138 RID: 131384 RVA: 0x00921816 File Offset: 0x0091FA16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void OnEnterNight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DayNightEvent_C_ReflectionImplementationFields.__OnEnterNight_NativeFunctionPtr, null);
		}

		// Token: 0x06020139 RID: 131385 RVA: 0x0092182A File Offset: 0x0091FA2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void OnEnterDay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_DayNightEvent_C_ReflectionImplementationFields.__OnEnterDay_NativeFunctionPtr, null);
		}

		// Token: 0x0400FFAB RID: 65451
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interface/BPI_DayNightEvent.BPI_DayNightEvent_C";
	}
}
