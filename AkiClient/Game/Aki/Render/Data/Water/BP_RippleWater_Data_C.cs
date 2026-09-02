using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.Data.Water
{
	// Token: 0x02003DA8 RID: 15784
	[UnrealObjectPath("/Game/Aki/Render/Data/Water/BP_RippleWater_Data.BP_RippleWater_Data_C")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 136)]
	public class BP_RippleWater_Data_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026A45 RID: 158277 RVA: 0x009DDE61 File Offset: 0x009DC061
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RippleWater_Data_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/Data/Water/BP_RippleWater_Data.BP_RippleWater_Data_C");
			}
			return BP_RippleWater_Data_C._ClassPtr;
		}

		// Token: 0x06026A46 RID: 158278 RVA: 0x009DDE88 File Offset: 0x009DC088
		public BP_RippleWater_Data_C() : this(BuiltinUtils.AllocNativeUObject(BP_RippleWater_Data_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026A47 RID: 158279 RVA: 0x009DDEB0 File Offset: 0x009DC0B0
		[NullableContext(1)]
		public BP_RippleWater_Data_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RippleWater_Data_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005881 RID: 22657
		// (get) Token: 0x06026A48 RID: 158280 RVA: 0x009DDEE3 File Offset: 0x009DC0E3
		// (set) Token: 0x06026A49 RID: 158281 RVA: 0x009DDEF3 File Offset: 0x009DC0F3
		public unsafe float Step
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005882 RID: 22658
		// (get) Token: 0x06026A4A RID: 158282 RVA: 0x009DDF04 File Offset: 0x009DC104
		// (set) Token: 0x06026A4B RID: 158283 RVA: 0x009DDF14 File Offset: 0x009DC114
		public unsafe float captureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005883 RID: 22659
		// (get) Token: 0x06026A4C RID: 158284 RVA: 0x009DDF25 File Offset: 0x009DC125
		// (set) Token: 0x06026A4D RID: 158285 RVA: 0x009DDF35 File Offset: 0x009DC135
		public unsafe float PlayerSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005884 RID: 22660
		// (get) Token: 0x06026A4E RID: 158286 RVA: 0x009DDF46 File Offset: 0x009DC146
		// (set) Token: 0x06026A4F RID: 158287 RVA: 0x009DDF56 File Offset: 0x009DC156
		public unsafe float RippleDistanceNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005885 RID: 22661
		// (get) Token: 0x06026A50 RID: 158288 RVA: 0x009DDF67 File Offset: 0x009DC167
		// (set) Token: 0x06026A51 RID: 158289 RVA: 0x009DDF77 File Offset: 0x009DC177
		public unsafe float RippleDistanceFluo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005886 RID: 22662
		// (get) Token: 0x06026A52 RID: 158290 RVA: 0x009DDF88 File Offset: 0x009DC188
		// (set) Token: 0x06026A53 RID: 158291 RVA: 0x009DDF98 File Offset: 0x009DC198
		public unsafe float SwimRippleOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005887 RID: 22663
		// (get) Token: 0x06026A54 RID: 158292 RVA: 0x009DDFA9 File Offset: 0x009DC1A9
		// (set) Token: 0x06026A55 RID: 158293 RVA: 0x009DDFBD File Offset: 0x009DC1BD
		public unsafe FVector2D ExtraRipplePoint1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005888 RID: 22664
		// (get) Token: 0x06026A56 RID: 158294 RVA: 0x009DDFD2 File Offset: 0x009DC1D2
		// (set) Token: 0x06026A57 RID: 158295 RVA: 0x009DDFE6 File Offset: 0x009DC1E6
		public unsafe FVector2D ExtraRipplePoint2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005889 RID: 22665
		// (get) Token: 0x06026A58 RID: 158296 RVA: 0x009DDFFB File Offset: 0x009DC1FB
		// (set) Token: 0x06026A59 RID: 158297 RVA: 0x009DE00B File Offset: 0x009DC20B
		public unsafe float PlayerSize_Mul
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700588A RID: 22666
		// (get) Token: 0x06026A5A RID: 158298 RVA: 0x009DE01C File Offset: 0x009DC21C
		// (set) Token: 0x06026A5B RID: 158299 RVA: 0x009DE02C File Offset: 0x009DC22C
		public unsafe float ExtraPlayerSize_Mul
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700588B RID: 22667
		// (get) Token: 0x06026A5C RID: 158300 RVA: 0x009DE03D File Offset: 0x009DC23D
		// (set) Token: 0x06026A5D RID: 158301 RVA: 0x009DE04D File Offset: 0x009DC24D
		public unsafe float RippleIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700588C RID: 22668
		// (get) Token: 0x06026A5E RID: 158302 RVA: 0x009DE05E File Offset: 0x009DC25E
		// (set) Token: 0x06026A5F RID: 158303 RVA: 0x009DE06E File Offset: 0x009DC26E
		public unsafe float RippleAttenuation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RippleWater_Data_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06026A60 RID: 158304 RVA: 0x009DE07F File Offset: 0x009DC27F
		protected BP_RippleWater_Data_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040141A8 RID: 82344
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/Data/Water/BP_RippleWater_Data.BP_RippleWater_Data_C";

		// Token: 0x040141A9 RID: 82345
		private static IntPtr _ClassPtr;

		// Token: 0x040141AA RID: 82346
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040141AB RID: 82347
		internal static int __PropertyOffset_0;

		// Token: 0x040141AC RID: 82348
		internal static int __PropertyOffset_1;

		// Token: 0x040141AD RID: 82349
		internal static int __PropertyOffset_2;

		// Token: 0x040141AE RID: 82350
		internal static int __PropertyOffset_3;

		// Token: 0x040141AF RID: 82351
		internal static int __PropertyOffset_4;

		// Token: 0x040141B0 RID: 82352
		internal static int __PropertyOffset_5;

		// Token: 0x040141B1 RID: 82353
		internal static int __PropertyOffset_6;

		// Token: 0x040141B2 RID: 82354
		internal static int __PropertyOffset_7;

		// Token: 0x040141B3 RID: 82355
		internal static int __PropertyOffset_8;

		// Token: 0x040141B4 RID: 82356
		internal static int __PropertyOffset_9;

		// Token: 0x040141B5 RID: 82357
		internal static int __PropertyOffset_10;

		// Token: 0x040141B6 RID: 82358
		internal static int __PropertyOffset_11;
	}
}
