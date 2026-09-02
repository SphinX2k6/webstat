using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CDC RID: 15580
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Clean.WP_Clean_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Clean_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252C5 RID: 152261 RVA: 0x009B28E4 File Offset: 0x009B0AE4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Clean_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Clean.WP_Clean_C");
			}
			return WP_Clean_C._ClassPtr;
		}

		// Token: 0x060252C6 RID: 152262 RVA: 0x009B2908 File Offset: 0x009B0B08
		public WP_Clean_C() : this(BuiltinUtils.AllocNativeUObject(WP_Clean_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252C7 RID: 152263 RVA: 0x009B2930 File Offset: 0x009B0B30
		[NullableContext(1)]
		public WP_Clean_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Clean_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252C8 RID: 152264 RVA: 0x009B2963 File Offset: 0x009B0B63
		protected WP_Clean_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401322B RID: 78379
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Clean.WP_Clean_C";

		// Token: 0x0401322C RID: 78380
		private static IntPtr _ClassPtr;

		// Token: 0x0401322D RID: 78381
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
