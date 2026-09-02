using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CDB RID: 15579
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Blizzard.WP_Blizzard_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Blizzard_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252C1 RID: 152257 RVA: 0x009B285B File Offset: 0x009B0A5B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Blizzard_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Blizzard.WP_Blizzard_C");
			}
			return WP_Blizzard_C._ClassPtr;
		}

		// Token: 0x060252C2 RID: 152258 RVA: 0x009B2880 File Offset: 0x009B0A80
		public WP_Blizzard_C() : this(BuiltinUtils.AllocNativeUObject(WP_Blizzard_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252C3 RID: 152259 RVA: 0x009B28A8 File Offset: 0x009B0AA8
		[NullableContext(1)]
		public WP_Blizzard_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Blizzard_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252C4 RID: 152260 RVA: 0x009B28DB File Offset: 0x009B0ADB
		protected WP_Blizzard_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013228 RID: 78376
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Blizzard.WP_Blizzard_C";

		// Token: 0x04013229 RID: 78377
		private static IntPtr _ClassPtr;

		// Token: 0x0401322A RID: 78378
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
