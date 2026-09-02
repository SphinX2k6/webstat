using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DDC RID: 15836
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelBase.BP_EffectModelBase_C")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 111)]
	public class BP_EffectModelBase_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026D59 RID: 159065 RVA: 0x009E3068 File Offset: 0x009E1268
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelBase.BP_EffectModelBase_C");
			}
			return BP_EffectModelBase_C._ClassPtr;
		}

		// Token: 0x06026D5A RID: 159066 RVA: 0x009E308C File Offset: 0x009E128C
		public BP_EffectModelBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026D5B RID: 159067 RVA: 0x009E30B4 File Offset: 0x009E12B4
		[NullableContext(1)]
		public BP_EffectModelBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700596D RID: 22893
		// (get) Token: 0x06026D5C RID: 159068 RVA: 0x009E30E7 File Offset: 0x009E12E7
		// (set) Token: 0x06026D5D RID: 159069 RVA: 0x009E30F7 File Offset: 0x009E12F7
		public unsafe float StartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700596E RID: 22894
		// (get) Token: 0x06026D5E RID: 159070 RVA: 0x009E3108 File Offset: 0x009E1308
		// (set) Token: 0x06026D5F RID: 159071 RVA: 0x009E3118 File Offset: 0x009E1318
		public unsafe float LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700596F RID: 22895
		// (get) Token: 0x06026D60 RID: 159072 RVA: 0x009E3129 File Offset: 0x009E1329
		// (set) Token: 0x06026D61 RID: 159073 RVA: 0x009E3139 File Offset: 0x009E1339
		public unsafe float EndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005970 RID: 22896
		// (get) Token: 0x06026D62 RID: 159074 RVA: 0x009E314A File Offset: 0x009E134A
		// (set) Token: 0x06026D63 RID: 159075 RVA: 0x009E315A File Offset: 0x009E135A
		public unsafe bool AutoPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005971 RID: 22897
		// (get) Token: 0x06026D64 RID: 159076 RVA: 0x009E316B File Offset: 0x009E136B
		// (set) Token: 0x06026D65 RID: 159077 RVA: 0x009E317B File Offset: 0x009E137B
		public unsafe bool AutoDestroy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005972 RID: 22898
		// (get) Token: 0x06026D66 RID: 159078 RVA: 0x009E318C File Offset: 0x009E138C
		// (set) Token: 0x06026D67 RID: 159079 RVA: 0x009E319C File Offset: 0x009E139C
		public unsafe bool IgnoreTimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005973 RID: 22899
		// (get) Token: 0x06026D68 RID: 159080 RVA: 0x009E31AD File Offset: 0x009E13AD
		// (set) Token: 0x06026D69 RID: 159081 RVA: 0x009E31BD File Offset: 0x009E13BD
		public unsafe bool UiScenePrimitive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005974 RID: 22900
		// (get) Token: 0x06026D6A RID: 159082 RVA: 0x009E31CE File Offset: 0x009E13CE
		// (set) Token: 0x06026D6B RID: 159083 RVA: 0x009E31DE File Offset: 0x009E13DE
		public unsafe int ImportanceLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005975 RID: 22901
		// (get) Token: 0x06026D6C RID: 159084 RVA: 0x009E31EF File Offset: 0x009E13EF
		// (set) Token: 0x06026D6D RID: 159085 RVA: 0x009E31FF File Offset: 0x009E13FF
		public unsafe float DefaultManualSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005976 RID: 22902
		// (get) Token: 0x06026D6E RID: 159086 RVA: 0x009E3210 File Offset: 0x009E1410
		// (set) Token: 0x06026D6F RID: 159087 RVA: 0x009E3220 File Offset: 0x009E1420
		public unsafe float DefaultManualTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005977 RID: 22903
		// (get) Token: 0x06026D70 RID: 159088 RVA: 0x009E3231 File Offset: 0x009E1431
		// (set) Token: 0x06026D71 RID: 159089 RVA: 0x009E3241 File Offset: 0x009E1441
		public unsafe bool DisableOnRemote
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005978 RID: 22904
		// (get) Token: 0x06026D72 RID: 159090 RVA: 0x009E3252 File Offset: 0x009E1452
		// (set) Token: 0x06026D73 RID: 159091 RVA: 0x009E3262 File Offset: 0x009E1462
		public unsafe bool DisableOnMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005979 RID: 22905
		// (get) Token: 0x06026D74 RID: 159092 RVA: 0x009E3273 File Offset: 0x009E1473
		// (set) Token: 0x06026D75 RID: 159093 RVA: 0x009E3283 File Offset: 0x009E1483
		public unsafe bool HideOnBurstSkill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelBase_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026D76 RID: 159094 RVA: 0x009E3294 File Offset: 0x009E1494
		protected BP_EffectModelBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014415 RID: 82965
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelBase.BP_EffectModelBase_C";

		// Token: 0x04014416 RID: 82966
		private static IntPtr _ClassPtr;

		// Token: 0x04014417 RID: 82967
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014418 RID: 82968
		internal static int __PropertyOffset_0;

		// Token: 0x04014419 RID: 82969
		internal static int __PropertyOffset_1;

		// Token: 0x0401441A RID: 82970
		internal static int __PropertyOffset_2;

		// Token: 0x0401441B RID: 82971
		internal static int __PropertyOffset_3;

		// Token: 0x0401441C RID: 82972
		internal static int __PropertyOffset_4;

		// Token: 0x0401441D RID: 82973
		internal static int __PropertyOffset_5;

		// Token: 0x0401441E RID: 82974
		internal static int __PropertyOffset_6;

		// Token: 0x0401441F RID: 82975
		internal static int __PropertyOffset_7;

		// Token: 0x04014420 RID: 82976
		internal static int __PropertyOffset_8;

		// Token: 0x04014421 RID: 82977
		internal static int __PropertyOffset_9;

		// Token: 0x04014422 RID: 82978
		internal static int __PropertyOffset_10;

		// Token: 0x04014423 RID: 82979
		internal static int __PropertyOffset_11;

		// Token: 0x04014424 RID: 82980
		internal static int __PropertyOffset_12;
	}
}
