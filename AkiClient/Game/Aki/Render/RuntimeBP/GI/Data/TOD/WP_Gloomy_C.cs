using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CDF RID: 15583
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Gloomy.WP_Gloomy_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Gloomy_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252D1 RID: 152273 RVA: 0x009B2A7C File Offset: 0x009B0C7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Gloomy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Gloomy.WP_Gloomy_C");
			}
			return WP_Gloomy_C._ClassPtr;
		}

		// Token: 0x060252D2 RID: 152274 RVA: 0x009B2AA0 File Offset: 0x009B0CA0
		public WP_Gloomy_C() : this(BuiltinUtils.AllocNativeUObject(WP_Gloomy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252D3 RID: 152275 RVA: 0x009B2AC8 File Offset: 0x009B0CC8
		[NullableContext(1)]
		public WP_Gloomy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Gloomy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252D4 RID: 152276 RVA: 0x009B2AFB File Offset: 0x009B0CFB
		protected WP_Gloomy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013234 RID: 78388
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Gloomy.WP_Gloomy_C";

		// Token: 0x04013235 RID: 78389
		private static IntPtr _ClassPtr;

		// Token: 0x04013236 RID: 78390
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
