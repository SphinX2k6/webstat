using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.RailSlideFollower
{
	// Token: 0x02003E77 RID: 15991
	[UnrealObjectPath("/Game/Aki/Data/Level/RailSlideFollower/BP_RailSlideFollowerConfig.BP_RailSlideFollowerConfig_C")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 120)]
	public class BP_RailSlideFollowerConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060278C5 RID: 161989 RVA: 0x009F4436 File Offset: 0x009F2636
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RailSlideFollowerConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/RailSlideFollower/BP_RailSlideFollowerConfig.BP_RailSlideFollowerConfig_C");
			}
			return BP_RailSlideFollowerConfig_C._ClassPtr;
		}

		// Token: 0x060278C6 RID: 161990 RVA: 0x009F445C File Offset: 0x009F265C
		public BP_RailSlideFollowerConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_RailSlideFollowerConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060278C7 RID: 161991 RVA: 0x009F4484 File Offset: 0x009F2684
		[NullableContext(1)]
		public BP_RailSlideFollowerConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RailSlideFollowerConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D73 RID: 23923
		// (get) Token: 0x060278C8 RID: 161992 RVA: 0x009F44B7 File Offset: 0x009F26B7
		// (set) Token: 0x060278C9 RID: 161993 RVA: 0x009F44C7 File Offset: 0x009F26C7
		public unsafe bool FollowOnRight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D74 RID: 23924
		// (get) Token: 0x060278CA RID: 161994 RVA: 0x009F44D8 File Offset: 0x009F26D8
		// (set) Token: 0x060278CB RID: 161995 RVA: 0x009F44E8 File Offset: 0x009F26E8
		public unsafe int DelayStartFollow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005D75 RID: 23925
		// (get) Token: 0x060278CC RID: 161996 RVA: 0x009F44F9 File Offset: 0x009F26F9
		// (set) Token: 0x060278CD RID: 161997 RVA: 0x009F4509 File Offset: 0x009F2709
		public unsafe int FrontDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005D76 RID: 23926
		// (get) Token: 0x060278CE RID: 161998 RVA: 0x009F451A File Offset: 0x009F271A
		// (set) Token: 0x060278CF RID: 161999 RVA: 0x009F452A File Offset: 0x009F272A
		public unsafe bool AutoChangeSide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D77 RID: 23927
		// (get) Token: 0x060278D0 RID: 162000 RVA: 0x009F453B File Offset: 0x009F273B
		// (set) Token: 0x060278D1 RID: 162001 RVA: 0x009F454B File Offset: 0x009F274B
		public unsafe int ToleranceDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005D78 RID: 23928
		// (get) Token: 0x060278D2 RID: 162002 RVA: 0x009F455C File Offset: 0x009F275C
		// (set) Token: 0x060278D3 RID: 162003 RVA: 0x009F4570 File Offset: 0x009F2770
		public unsafe FVector2D SideDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005D79 RID: 23929
		// (get) Token: 0x060278D4 RID: 162004 RVA: 0x009F4585 File Offset: 0x009F2785
		// (set) Token: 0x060278D5 RID: 162005 RVA: 0x009F4595 File Offset: 0x009F2795
		public unsafe int DynamicDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005D7A RID: 23930
		// (get) Token: 0x060278D6 RID: 162006 RVA: 0x009F45A6 File Offset: 0x009F27A6
		// (set) Token: 0x060278D7 RID: 162007 RVA: 0x009F45B6 File Offset: 0x009F27B6
		public unsafe int FollowerLerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005D7B RID: 23931
		// (get) Token: 0x060278D8 RID: 162008 RVA: 0x009F45C7 File Offset: 0x009F27C7
		// (set) Token: 0x060278D9 RID: 162009 RVA: 0x009F45D7 File Offset: 0x009F27D7
		public unsafe float FollowSpeedStepRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideFollowerConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x060278DA RID: 162010 RVA: 0x009F45E8 File Offset: 0x009F27E8
		protected BP_RailSlideFollowerConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B81 RID: 84865
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Level/RailSlideFollower/BP_RailSlideFollowerConfig.BP_RailSlideFollowerConfig_C";

		// Token: 0x04014B82 RID: 84866
		private static IntPtr _ClassPtr;

		// Token: 0x04014B83 RID: 84867
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B84 RID: 84868
		internal static int __PropertyOffset_0;

		// Token: 0x04014B85 RID: 84869
		internal static int __PropertyOffset_1;

		// Token: 0x04014B86 RID: 84870
		internal static int __PropertyOffset_2;

		// Token: 0x04014B87 RID: 84871
		internal static int __PropertyOffset_3;

		// Token: 0x04014B88 RID: 84872
		internal static int __PropertyOffset_4;

		// Token: 0x04014B89 RID: 84873
		internal static int __PropertyOffset_5;

		// Token: 0x04014B8A RID: 84874
		internal static int __PropertyOffset_6;

		// Token: 0x04014B8B RID: 84875
		internal static int __PropertyOffset_7;

		// Token: 0x04014B8C RID: 84876
		internal static int __PropertyOffset_8;
	}
}
