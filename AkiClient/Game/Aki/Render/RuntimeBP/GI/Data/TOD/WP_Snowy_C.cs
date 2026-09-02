using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CE4 RID: 15588
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Snowy.WP_Snowy_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Snowy_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252E5 RID: 152293 RVA: 0x009B2D24 File Offset: 0x009B0F24
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Snowy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Snowy.WP_Snowy_C");
			}
			return WP_Snowy_C._ClassPtr;
		}

		// Token: 0x060252E6 RID: 152294 RVA: 0x009B2D48 File Offset: 0x009B0F48
		public WP_Snowy_C() : this(BuiltinUtils.AllocNativeUObject(WP_Snowy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252E7 RID: 152295 RVA: 0x009B2D70 File Offset: 0x009B0F70
		[NullableContext(1)]
		public WP_Snowy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Snowy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252E8 RID: 152296 RVA: 0x009B2DA3 File Offset: 0x009B0FA3
		protected WP_Snowy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013243 RID: 78403
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Snowy.WP_Snowy_C";

		// Token: 0x04013244 RID: 78404
		private static IntPtr _ClassPtr;

		// Token: 0x04013245 RID: 78405
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
