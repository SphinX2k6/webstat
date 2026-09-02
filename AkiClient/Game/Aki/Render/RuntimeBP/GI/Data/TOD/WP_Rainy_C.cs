using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CE2 RID: 15586
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Rainy.WP_Rainy_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 156)]
	public class WP_Rainy_C : WeatherPreset_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060252DD RID: 152285 RVA: 0x009B2C14 File Offset: 0x009B0E14
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WP_Rainy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Rainy.WP_Rainy_C");
			}
			return WP_Rainy_C._ClassPtr;
		}

		// Token: 0x060252DE RID: 152286 RVA: 0x009B2C38 File Offset: 0x009B0E38
		public WP_Rainy_C() : this(BuiltinUtils.AllocNativeUObject(WP_Rainy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060252DF RID: 152287 RVA: 0x009B2C60 File Offset: 0x009B0E60
		[NullableContext(1)]
		public WP_Rainy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WP_Rainy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x060252E0 RID: 152288 RVA: 0x009B2C93 File Offset: 0x009B0E93
		protected WP_Rainy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401323D RID: 78397
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WP_Rainy.WP_Rainy_C";

		// Token: 0x0401323E RID: 78398
		private static IntPtr _ClassPtr;

		// Token: 0x0401323F RID: 78399
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
