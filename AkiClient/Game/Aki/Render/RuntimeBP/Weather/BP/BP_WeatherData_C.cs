using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP
{
	// Token: 0x020039FF RID: 14847
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherData.BP_WeatherData_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_WeatherData_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E3E3 RID: 123875 RVA: 0x008F082F File Offset: 0x008EEA2F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WeatherData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherData.BP_WeatherData_C");
			}
			return BP_WeatherData_C._ClassPtr;
		}

		// Token: 0x0601E3E4 RID: 123876 RVA: 0x008F0854 File Offset: 0x008EEA54
		public BP_WeatherData_C() : this(BuiltinUtils.AllocNativeUObject(BP_WeatherData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E3E5 RID: 123877 RVA: 0x008F087C File Offset: 0x008EEA7C
		[NullableContext(1)]
		public BP_WeatherData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WeatherData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601E3E6 RID: 123878 RVA: 0x008F08AF File Offset: 0x008EEAAF
		protected BP_WeatherData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EDE3 RID: 60899
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/BP_WeatherData.BP_WeatherData_C";

		// Token: 0x0400EDE4 RID: 60900
		private static IntPtr _ClassPtr;

		// Token: 0x0400EDE5 RID: 60901
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
