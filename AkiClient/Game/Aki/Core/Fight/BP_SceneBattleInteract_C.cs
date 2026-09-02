using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F4D RID: 16205
	[UnrealObjectPath("/Game/Aki/Core/Fight/BP_SceneBattleInteract.BP_SceneBattleInteract_C")]
	[UnrealStructLayout(224, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 220)]
	public class BP_SceneBattleInteract_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060287EF RID: 165871 RVA: 0x00A0D534 File Offset: 0x00A0B734
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneBattleInteract_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/BP_SceneBattleInteract.BP_SceneBattleInteract_C");
			}
			return BP_SceneBattleInteract_C._ClassPtr;
		}

		// Token: 0x060287F0 RID: 165872 RVA: 0x00A0D558 File Offset: 0x00A0B758
		public BP_SceneBattleInteract_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneBattleInteract_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060287F1 RID: 165873 RVA: 0x00A0D580 File Offset: 0x00A0B780
		[NullableContext(1)]
		public BP_SceneBattleInteract_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneBattleInteract_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006280 RID: 25216
		// (get) Token: 0x060287F2 RID: 165874 RVA: 0x00A0D5B3 File Offset: 0x00A0B7B3
		// (set) Token: 0x060287F3 RID: 165875 RVA: 0x00A0D5C3 File Offset: 0x00A0B7C3
		public unsafe int ShapeType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006281 RID: 25217
		// (get) Token: 0x060287F4 RID: 165876 RVA: 0x00A0D5D4 File Offset: 0x00A0B7D4
		// (set) Token: 0x060287F5 RID: 165877 RVA: 0x00A0D5E4 File Offset: 0x00A0B7E4
		public unsafe int WeaponType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006282 RID: 25218
		// (get) Token: 0x060287F6 RID: 165878 RVA: 0x00A0D5F5 File Offset: 0x00A0B7F5
		// (set) Token: 0x060287F7 RID: 165879 RVA: 0x00A0D605 File Offset: 0x00A0B805
		public unsafe float EffectRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006283 RID: 25219
		// (get) Token: 0x060287F8 RID: 165880 RVA: 0x00A0D616 File Offset: 0x00A0B816
		// (set) Token: 0x060287F9 RID: 165881 RVA: 0x00A0D626 File Offset: 0x00A0B826
		public unsafe float CollisionRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006284 RID: 25220
		// (get) Token: 0x060287FA RID: 165882 RVA: 0x00A0D637 File Offset: 0x00A0B837
		// (set) Token: 0x060287FB RID: 165883 RVA: 0x00A0D647 File Offset: 0x00A0B847
		public unsafe float CollisionHalfHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006285 RID: 25221
		// (get) Token: 0x060287FC RID: 165884 RVA: 0x00A0D658 File Offset: 0x00A0B858
		// (set) Token: 0x060287FD RID: 165885 RVA: 0x00A0D66C File Offset: 0x00A0B86C
		public unsafe FVectorDouble CollisionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006286 RID: 25222
		// (get) Token: 0x060287FE RID: 165886 RVA: 0x00A0D681 File Offset: 0x00A0B881
		// (set) Token: 0x060287FF RID: 165887 RVA: 0x00A0D691 File Offset: 0x00A0B891
		public unsafe int Interval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006287 RID: 25223
		// (get) Token: 0x06028800 RID: 165888 RVA: 0x00A0D6A2 File Offset: 0x00A0B8A2
		// (set) Token: 0x06028801 RID: 165889 RVA: 0x00A0D6B2 File Offset: 0x00A0B8B2
		public unsafe float RippleRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17006288 RID: 25224
		// (get) Token: 0x06028802 RID: 165890 RVA: 0x00A0D6C3 File Offset: 0x00A0B8C3
		// (set) Token: 0x06028803 RID: 165891 RVA: 0x00A0D6D3 File Offset: 0x00A0B8D3
		public unsafe float RippleIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006289 RID: 25225
		// (get) Token: 0x06028804 RID: 165892 RVA: 0x00A0D6E4 File Offset: 0x00A0B8E4
		// (set) Token: 0x06028805 RID: 165893 RVA: 0x00A0D6F4 File Offset: 0x00A0B8F4
		public unsafe int RippleType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700628A RID: 25226
		// (get) Token: 0x06028806 RID: 165894 RVA: 0x00A0D705 File Offset: 0x00A0B905
		// (set) Token: 0x06028807 RID: 165895 RVA: 0x00A0D715 File Offset: 0x00A0B915
		public unsafe float RippleDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700628B RID: 25227
		// (get) Token: 0x06028808 RID: 165896 RVA: 0x00A0D726 File Offset: 0x00A0B926
		// (set) Token: 0x06028809 RID: 165897 RVA: 0x00A0D73A File Offset: 0x00A0B93A
		public unsafe TEnumAsByte<ESceneBattleInteractEntityType> EntityType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700628C RID: 25228
		// (get) Token: 0x0602880A RID: 165898 RVA: 0x00A0D74F File Offset: 0x00A0B94F
		// (set) Token: 0x0602880B RID: 165899 RVA: 0x00A0D75F File Offset: 0x00A0B95F
		public unsafe bool BreakEvent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700628D RID: 25229
		// (get) Token: 0x0602880C RID: 165900 RVA: 0x00A0D770 File Offset: 0x00A0B970
		// (set) Token: 0x0602880D RID: 165901 RVA: 0x00A0D780 File Offset: 0x00A0B980
		public unsafe float BreakIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700628E RID: 25230
		// (get) Token: 0x0602880E RID: 165902 RVA: 0x00A0D791 File Offset: 0x00A0B991
		// (set) Token: 0x0602880F RID: 165903 RVA: 0x00A0D7A1 File Offset: 0x00A0B9A1
		public unsafe float BreakRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700628F RID: 25231
		// (get) Token: 0x06028810 RID: 165904 RVA: 0x00A0D7B2 File Offset: 0x00A0B9B2
		// (set) Token: 0x06028811 RID: 165905 RVA: 0x00A0D7C2 File Offset: 0x00A0B9C2
		public unsafe float RippleMinConnectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006290 RID: 25232
		// (get) Token: 0x06028812 RID: 165906 RVA: 0x00A0D7D3 File Offset: 0x00A0B9D3
		// (set) Token: 0x06028813 RID: 165907 RVA: 0x00A0D7E3 File Offset: 0x00A0B9E3
		public unsafe float RippleMaxConnectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17006291 RID: 25233
		// (get) Token: 0x06028814 RID: 165908 RVA: 0x00A0D7F4 File Offset: 0x00A0B9F4
		// (set) Token: 0x06028815 RID: 165909 RVA: 0x00A0D804 File Offset: 0x00A0BA04
		public unsafe bool SendWeaponEvent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006292 RID: 25234
		// (get) Token: 0x06028816 RID: 165910 RVA: 0x00A0D815 File Offset: 0x00A0BA15
		// (set) Token: 0x06028817 RID: 165911 RVA: 0x00A0D825 File Offset: 0x00A0BA25
		public unsafe float ForceFieldRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17006293 RID: 25235
		// (get) Token: 0x06028818 RID: 165912 RVA: 0x00A0D836 File Offset: 0x00A0BA36
		// (set) Token: 0x06028819 RID: 165913 RVA: 0x00A0D846 File Offset: 0x00A0BA46
		public unsafe float RotationalForceField
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17006294 RID: 25236
		// (get) Token: 0x0602881A RID: 165914 RVA: 0x00A0D857 File Offset: 0x00A0BA57
		// (set) Token: 0x0602881B RID: 165915 RVA: 0x00A0D867 File Offset: 0x00A0BA67
		public unsafe float CentripetalForceField
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17006295 RID: 25237
		// (get) Token: 0x0602881C RID: 165916 RVA: 0x00A0D878 File Offset: 0x00A0BA78
		// (set) Token: 0x0602881D RID: 165917 RVA: 0x00A0D88C File Offset: 0x00A0BA8C
		public unsafe FVector DirectionalForceField
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17006296 RID: 25238
		// (get) Token: 0x0602881E RID: 165918 RVA: 0x00A0D8A1 File Offset: 0x00A0BAA1
		// (set) Token: 0x0602881F RID: 165919 RVA: 0x00A0D8B1 File Offset: 0x00A0BAB1
		public unsafe float NoiseForceField
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17006297 RID: 25239
		// (get) Token: 0x06028820 RID: 165920 RVA: 0x00A0D8C2 File Offset: 0x00A0BAC2
		// (set) Token: 0x06028821 RID: 165921 RVA: 0x00A0D8D2 File Offset: 0x00A0BAD2
		public unsafe float WeaponRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17006298 RID: 25240
		// (get) Token: 0x06028822 RID: 165922 RVA: 0x00A0D8E3 File Offset: 0x00A0BAE3
		// (set) Token: 0x06028823 RID: 165923 RVA: 0x00A0D8F7 File Offset: 0x00A0BAF7
		public unsafe FVector WeaponOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17006299 RID: 25241
		// (get) Token: 0x06028824 RID: 165924 RVA: 0x00A0D90C File Offset: 0x00A0BB0C
		// (set) Token: 0x06028825 RID: 165925 RVA: 0x00A0D91C File Offset: 0x00A0BB1C
		public unsafe float SampleIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneBattleInteract_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x06028826 RID: 165926 RVA: 0x00A0D92D File Offset: 0x00A0BB2D
		protected BP_SceneBattleInteract_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040154FC RID: 87292
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/BP_SceneBattleInteract.BP_SceneBattleInteract_C";

		// Token: 0x040154FD RID: 87293
		private static IntPtr _ClassPtr;

		// Token: 0x040154FE RID: 87294
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040154FF RID: 87295
		internal static int __PropertyOffset_0;

		// Token: 0x04015500 RID: 87296
		internal static int __PropertyOffset_1;

		// Token: 0x04015501 RID: 87297
		internal static int __PropertyOffset_2;

		// Token: 0x04015502 RID: 87298
		internal static int __PropertyOffset_3;

		// Token: 0x04015503 RID: 87299
		internal static int __PropertyOffset_4;

		// Token: 0x04015504 RID: 87300
		internal static int __PropertyOffset_5;

		// Token: 0x04015505 RID: 87301
		internal static int __PropertyOffset_6;

		// Token: 0x04015506 RID: 87302
		internal static int __PropertyOffset_7;

		// Token: 0x04015507 RID: 87303
		internal static int __PropertyOffset_8;

		// Token: 0x04015508 RID: 87304
		internal static int __PropertyOffset_9;

		// Token: 0x04015509 RID: 87305
		internal static int __PropertyOffset_10;

		// Token: 0x0401550A RID: 87306
		internal static int __PropertyOffset_11;

		// Token: 0x0401550B RID: 87307
		internal static int __PropertyOffset_12;

		// Token: 0x0401550C RID: 87308
		internal static int __PropertyOffset_13;

		// Token: 0x0401550D RID: 87309
		internal static int __PropertyOffset_14;

		// Token: 0x0401550E RID: 87310
		internal static int __PropertyOffset_15;

		// Token: 0x0401550F RID: 87311
		internal static int __PropertyOffset_16;

		// Token: 0x04015510 RID: 87312
		internal static int __PropertyOffset_17;

		// Token: 0x04015511 RID: 87313
		internal static int __PropertyOffset_18;

		// Token: 0x04015512 RID: 87314
		internal static int __PropertyOffset_19;

		// Token: 0x04015513 RID: 87315
		internal static int __PropertyOffset_20;

		// Token: 0x04015514 RID: 87316
		internal static int __PropertyOffset_21;

		// Token: 0x04015515 RID: 87317
		internal static int __PropertyOffset_22;

		// Token: 0x04015516 RID: 87318
		internal static int __PropertyOffset_23;

		// Token: 0x04015517 RID: 87319
		internal static int __PropertyOffset_24;

		// Token: 0x04015518 RID: 87320
		internal static int __PropertyOffset_25;
	}
}
