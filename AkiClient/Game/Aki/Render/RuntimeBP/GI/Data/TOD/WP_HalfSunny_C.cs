using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CE0 RID: 15584
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_HalfSunny.WP_HalfSunny_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_HalfSunny_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252D5 RID: 152277 RVA: 0x009B2B04 File Offset: 0x009B0D04
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_HalfSunny_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_HalfSunny.WP_HalfSunny_C");
			}
			return WP_HalfSunny_C._ClassPtr;
		}

		// Token: 0x060252D6 RID: 152278 RVA: 0x009B2B28 File Offset: 0x009B0D28
		public WP_HalfSunny_C() : this(BuiltinUtils.AllocNativeUObject(WP_HalfSunny_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252D7 RID: 152279 RVA: 0x009B2B50 File Offset: 0x009B0D50
		[NullableContext(1)]
		public WP_HalfSunny_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_HalfSunny_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252D8 RID: 152280 RVA: 0x009B2B83 File Offset: 0x009B0D83
		protected WP_HalfSunny_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013237 RID: 78391
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_HalfSunny.WP_HalfSunny_C";

		// Token: 0x04013238 RID: 78392
		private static IntPtr _ClassPtr;

		// Token: 0x04013239 RID: 78393
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
