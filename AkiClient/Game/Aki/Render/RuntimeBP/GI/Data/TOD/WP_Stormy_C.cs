using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CE5 RID: 15589
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Stormy.WP_Stormy_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Stormy_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252E9 RID: 152297 RVA: 0x009B2DAC File Offset: 0x009B0FAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Stormy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Stormy.WP_Stormy_C");
			}
			return WP_Stormy_C._ClassPtr;
		}

		// Token: 0x060252EA RID: 152298 RVA: 0x009B2DD0 File Offset: 0x009B0FD0
		public WP_Stormy_C() : this(BuiltinUtils.AllocNativeUObject(WP_Stormy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252EB RID: 152299 RVA: 0x009B2DF8 File Offset: 0x009B0FF8
		[NullableContext(1)]
		public WP_Stormy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Stormy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252EC RID: 152300 RVA: 0x009B2E2B File Offset: 0x009B102B
		protected WP_Stormy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013246 RID: 78406
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Stormy.WP_Stormy_C";

		// Token: 0x04013247 RID: 78407
		private static IntPtr _ClassPtr;

		// Token: 0x04013248 RID: 78408
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
