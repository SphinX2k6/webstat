using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CDE RID: 15582
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Foggy.WP_Foggy_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Foggy_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252CD RID: 152269 RVA: 0x009B29F4 File Offset: 0x009B0BF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Foggy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Foggy.WP_Foggy_C");
			}
			return WP_Foggy_C._ClassPtr;
		}

		// Token: 0x060252CE RID: 152270 RVA: 0x009B2A18 File Offset: 0x009B0C18
		public WP_Foggy_C() : this(BuiltinUtils.AllocNativeUObject(WP_Foggy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252CF RID: 152271 RVA: 0x009B2A40 File Offset: 0x009B0C40
		[NullableContext(1)]
		public WP_Foggy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Foggy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252D0 RID: 152272 RVA: 0x009B2A73 File Offset: 0x009B0C73
		protected WP_Foggy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013231 RID: 78385
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Foggy.WP_Foggy_C";

		// Token: 0x04013232 RID: 78386
		private static IntPtr _ClassPtr;

		// Token: 0x04013233 RID: 78387
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
