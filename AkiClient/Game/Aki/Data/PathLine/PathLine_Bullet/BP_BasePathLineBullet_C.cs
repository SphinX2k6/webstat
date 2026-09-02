using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.PathLine.PathLine_Bullet
{
	// Token: 0x02003E55 RID: 15957
	[UnrealObjectPath("/Game/Aki/Data/PathLine/PathLine_Bullet/BP_BasePathLineBullet.BP_BasePathLineBullet_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_BasePathLineBullet_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602762F RID: 161327 RVA: 0x009F0B24 File Offset: 0x009EED24
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BasePathLineBullet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/PathLine/PathLine_Bullet/BP_BasePathLineBullet.BP_BasePathLineBullet_C");
			}
			return BP_BasePathLineBullet_C._ClassPtr;
		}

		// Token: 0x06027630 RID: 161328 RVA: 0x009F0B48 File Offset: 0x009EED48
		public BP_BasePathLineBullet_C() : this(BuiltinUtils.AllocNativeUObject(BP_BasePathLineBullet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027631 RID: 161329 RVA: 0x009F0B70 File Offset: 0x009EED70
		[NullableContext(1)]
		public BP_BasePathLineBullet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BasePathLineBullet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C85 RID: 23685
		// (get) Token: 0x06027632 RID: 161330 RVA: 0x009F0BA3 File Offset: 0x009EEDA3
		// (set) Token: 0x06027633 RID: 161331 RVA: 0x009F0BB7 File Offset: 0x009EEDB7
		[Nullable(2)]
		public unsafe USplineComponent Spline
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLineBullet_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLineBullet_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06027634 RID: 161332 RVA: 0x009F0BCC File Offset: 0x009EEDCC
		protected BP_BasePathLineBullet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040149F6 RID: 84470
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/PathLine/PathLine_Bullet/BP_BasePathLineBullet.BP_BasePathLineBullet_C";

		// Token: 0x040149F7 RID: 84471
		private static IntPtr _ClassPtr;

		// Token: 0x040149F8 RID: 84472
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040149F9 RID: 84473
		internal static int __PropertyOffset_0;
	}
}
