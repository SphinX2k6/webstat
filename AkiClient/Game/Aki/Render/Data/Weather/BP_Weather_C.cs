using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.Data.Weather
{
	// Token: 0x02003DA6 RID: 15782
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/Data/Weather/BP_Weather.BP_Weather_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_Weather_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026A07 RID: 158215 RVA: 0x009DD95A File Offset: 0x009DBB5A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Weather_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/Data/Weather/BP_Weather.BP_Weather_C");
			}
			return BP_Weather_C._ClassPtr;
		}

		// Token: 0x06026A08 RID: 158216 RVA: 0x009DD980 File Offset: 0x009DBB80
		public BP_Weather_C() : this(BuiltinUtils.AllocNativeUObject(BP_Weather_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026A09 RID: 158217 RVA: 0x009DD9A8 File Offset: 0x009DBBA8
		[NullableContext(1)]
		public BP_Weather_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Weather_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005866 RID: 22630
		// (get) Token: 0x06026A0A RID: 158218 RVA: 0x009DD9DB File Offset: 0x009DBBDB
		// (set) Token: 0x06026A0B RID: 158219 RVA: 0x009DD9EF File Offset: 0x009DBBEF
		public unsafe UKuroPostProcessComponent KuroPostProcess_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Weather_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Weather_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005867 RID: 22631
		// (get) Token: 0x06026A0C RID: 158220 RVA: 0x009DDA04 File Offset: 0x009DBC04
		// (set) Token: 0x06026A0D RID: 158221 RVA: 0x009DDA18 File Offset: 0x009DBC18
		public unsafe UKuroPostProcessComponent KuroPostProcess_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Weather_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Weather_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06026A0E RID: 158222 RVA: 0x009DDA2D File Offset: 0x009DBC2D
		protected BP_Weather_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014187 RID: 82311
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/Data/Weather/BP_Weather.BP_Weather_C";

		// Token: 0x04014188 RID: 82312
		private static IntPtr _ClassPtr;

		// Token: 0x04014189 RID: 82313
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401418A RID: 82314
		internal static int __PropertyOffset_0;

		// Token: 0x0401418B RID: 82315
		internal static int __PropertyOffset_1;
	}
}
