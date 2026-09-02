using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CE1 RID: 15585
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Overcast.WP_Overcast_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Overcast_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252D9 RID: 152281 RVA: 0x009B2B8C File Offset: 0x009B0D8C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Overcast_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Overcast.WP_Overcast_C");
			}
			return WP_Overcast_C._ClassPtr;
		}

		// Token: 0x060252DA RID: 152282 RVA: 0x009B2BB0 File Offset: 0x009B0DB0
		public WP_Overcast_C() : this(BuiltinUtils.AllocNativeUObject(WP_Overcast_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252DB RID: 152283 RVA: 0x009B2BD8 File Offset: 0x009B0DD8
		[NullableContext(1)]
		public WP_Overcast_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Overcast_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252DC RID: 152284 RVA: 0x009B2C0B File Offset: 0x009B0E0B
		protected WP_Overcast_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401323A RID: 78394
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Overcast.WP_Overcast_C";

		// Token: 0x0401323B RID: 78395
		private static IntPtr _ClassPtr;

		// Token: 0x0401323C RID: 78396
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
