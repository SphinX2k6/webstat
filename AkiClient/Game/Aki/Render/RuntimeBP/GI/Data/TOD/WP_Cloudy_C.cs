using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CDD RID: 15581
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Cloudy.WP_Cloudy_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Cloudy_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252C9 RID: 152265 RVA: 0x009B296C File Offset: 0x009B0B6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Cloudy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Cloudy.WP_Cloudy_C");
			}
			return WP_Cloudy_C._ClassPtr;
		}

		// Token: 0x060252CA RID: 152266 RVA: 0x009B2990 File Offset: 0x009B0B90
		public WP_Cloudy_C() : this(BuiltinUtils.AllocNativeUObject(WP_Cloudy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252CB RID: 152267 RVA: 0x009B29B8 File Offset: 0x009B0BB8
		[NullableContext(1)]
		public WP_Cloudy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Cloudy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252CC RID: 152268 RVA: 0x009B29EB File Offset: 0x009B0BEB
		protected WP_Cloudy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401322E RID: 78382
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Cloudy.WP_Cloudy_C";

		// Token: 0x0401322F RID: 78383
		private static IntPtr _ClassPtr;

		// Token: 0x04013230 RID: 78384
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
