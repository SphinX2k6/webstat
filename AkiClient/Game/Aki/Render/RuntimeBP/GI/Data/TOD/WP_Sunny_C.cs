using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CE6 RID: 15590
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Sunny.WP_Sunny_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Sunny_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252ED RID: 152301 RVA: 0x009B2E34 File Offset: 0x009B1034
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Sunny_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Sunny.WP_Sunny_C");
			}
			return WP_Sunny_C._ClassPtr;
		}

		// Token: 0x060252EE RID: 152302 RVA: 0x009B2E58 File Offset: 0x009B1058
		public WP_Sunny_C() : this(BuiltinUtils.AllocNativeUObject(WP_Sunny_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252EF RID: 152303 RVA: 0x009B2E80 File Offset: 0x009B1080
		[NullableContext(1)]
		public WP_Sunny_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Sunny_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252F0 RID: 152304 RVA: 0x009B2EB3 File Offset: 0x009B10B3
		protected WP_Sunny_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013249 RID: 78409
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Sunny.WP_Sunny_C";

		// Token: 0x0401324A RID: 78410
		private static IntPtr _ClassPtr;

		// Token: 0x0401324B RID: 78411
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
