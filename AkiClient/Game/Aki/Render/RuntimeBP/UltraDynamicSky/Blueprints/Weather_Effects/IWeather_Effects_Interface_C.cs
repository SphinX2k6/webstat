using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Weather_Effects
{
	// Token: 0x02003A16 RID: 14870
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Weather_Effects/Weather_Effects_Interface.Weather_Effects_Interface_C")]
	public interface IWeather_Effects_Interface_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0601E971 RID: 125297 RVA: 0x008F8B24 File Offset: 0x008F6D24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void Reset_Emitters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IWeather_Effects_Interface_C_ReflectionImplementationFields.__Reset_Emitters_NativeFunctionPtr, null);
		}

		// Token: 0x0601E972 RID: 125298 RVA: 0x008F8B38 File Offset: 0x008F6D38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void Editor_Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IWeather_Effects_Interface_C_ReflectionImplementationFields.__Editor_Update_NativeFunctionPtr, null);
		}

		// Token: 0x0400F104 RID: 61700
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Weather_Effects/Weather_Effects_Interface.Weather_Effects_Interface_C";
	}
}
