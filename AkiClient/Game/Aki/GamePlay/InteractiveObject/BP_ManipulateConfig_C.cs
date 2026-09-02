using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.InteractiveObject
{
	// Token: 0x02003DD3 RID: 15827
	[UnrealObjectPath("/Game/Aki/GamePlay/InteractiveObject/BP_ManipulateConfig.BP_ManipulateConfig_C")]
	[UnrealStructLayout(352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 348)]
	public class BP_ManipulateConfig_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026C4E RID: 158798 RVA: 0x009E19BE File Offset: 0x009DFBBE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ManipulateConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/InteractiveObject/BP_ManipulateConfig.BP_ManipulateConfig_C");
			}
			return BP_ManipulateConfig_C._ClassPtr;
		}

		// Token: 0x06026C4F RID: 158799 RVA: 0x009E19E4 File Offset: 0x009DFBE4
		public BP_ManipulateConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_ManipulateConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026C50 RID: 158800 RVA: 0x009E1A0C File Offset: 0x009DFC0C
		[NullableContext(1)]
		public BP_ManipulateConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ManipulateConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058F8 RID: 22776
		// (get) Token: 0x06026C51 RID: 158801 RVA: 0x009E1A3F File Offset: 0x009DFC3F
		// (set) Token: 0x06026C52 RID: 158802 RVA: 0x009E1A4F File Offset: 0x009DFC4F
		public unsafe float ChantTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170058F9 RID: 22777
		// (get) Token: 0x06026C53 RID: 158803 RVA: 0x009E1A60 File Offset: 0x009DFC60
		// (set) Token: 0x06026C54 RID: 158804 RVA: 0x009E1A74 File Offset: 0x009DFC74
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> ChantCameraShake
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_1);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170058FA RID: 22778
		// (get) Token: 0x06026C55 RID: 158805 RVA: 0x009E1A89 File Offset: 0x009DFC89
		// (set) Token: 0x06026C56 RID: 158806 RVA: 0x009E1A9D File Offset: 0x009DFC9D
		public unsafe FGameplayTag ChantCameraStateTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170058FB RID: 22779
		// (get) Token: 0x06026C57 RID: 158807 RVA: 0x009E1AB2 File Offset: 0x009DFCB2
		// (set) Token: 0x06026C58 RID: 158808 RVA: 0x009E1AC2 File Offset: 0x009DFCC2
		public unsafe float DrawDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170058FC RID: 22780
		// (get) Token: 0x06026C59 RID: 158809 RVA: 0x009E1AD3 File Offset: 0x009DFCD3
		// (set) Token: 0x06026C5A RID: 158810 RVA: 0x009E1AE3 File Offset: 0x009DFCE3
		public unsafe float DrawTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170058FD RID: 22781
		// (get) Token: 0x06026C5B RID: 158811 RVA: 0x009E1AF4 File Offset: 0x009DFCF4
		// (set) Token: 0x06026C5C RID: 158812 RVA: 0x009E1B04 File Offset: 0x009DFD04
		public unsafe float DrawAlignTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170058FE RID: 22782
		// (get) Token: 0x06026C5D RID: 158813 RVA: 0x009E1B15 File Offset: 0x009DFD15
		// (set) Token: 0x06026C5E RID: 158814 RVA: 0x009E1B25 File Offset: 0x009DFD25
		public unsafe float DrawAlignHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170058FF RID: 22783
		// (get) Token: 0x06026C5F RID: 158815 RVA: 0x009E1B36 File Offset: 0x009DFD36
		// (set) Token: 0x06026C60 RID: 158816 RVA: 0x009E1B4A File Offset: 0x009DFD4A
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> DrawCameraShake
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_7);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005900 RID: 22784
		// (get) Token: 0x06026C61 RID: 158817 RVA: 0x009E1B5F File Offset: 0x009DFD5F
		// (set) Token: 0x06026C62 RID: 158818 RVA: 0x009E1B6F File Offset: 0x009DFD6F
		public unsafe float HoldSwingFreq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005901 RID: 22785
		// (get) Token: 0x06026C63 RID: 158819 RVA: 0x009E1B80 File Offset: 0x009DFD80
		// (set) Token: 0x06026C64 RID: 158820 RVA: 0x009E1B90 File Offset: 0x009DFD90
		public unsafe float HoldAngularVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005902 RID: 22786
		// (get) Token: 0x06026C65 RID: 158821 RVA: 0x009E1BA1 File Offset: 0x009DFDA1
		// (set) Token: 0x06026C66 RID: 158822 RVA: 0x009E1BB5 File Offset: 0x009DFDB5
		public unsafe FRotator HoldRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005903 RID: 22787
		// (get) Token: 0x06026C67 RID: 158823 RVA: 0x009E1BCA File Offset: 0x009DFDCA
		// (set) Token: 0x06026C68 RID: 158824 RVA: 0x009E1BDE File Offset: 0x009DFDDE
		public unsafe FVector HoldOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005904 RID: 22788
		// (get) Token: 0x06026C69 RID: 158825 RVA: 0x009E1BF3 File Offset: 0x009DFDF3
		// (set) Token: 0x06026C6A RID: 158826 RVA: 0x009E1C03 File Offset: 0x009DFE03
		public unsafe float HoldSwingRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005905 RID: 22789
		// (get) Token: 0x06026C6B RID: 158827 RVA: 0x009E1C14 File Offset: 0x009DFE14
		// (set) Token: 0x06026C6C RID: 158828 RVA: 0x009E1C24 File Offset: 0x009DFE24
		public unsafe float CastAngularVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005906 RID: 22790
		// (get) Token: 0x06026C6D RID: 158829 RVA: 0x009E1C35 File Offset: 0x009DFE35
		// (set) Token: 0x06026C6E RID: 158830 RVA: 0x009E1C49 File Offset: 0x009DFE49
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> CastCameraShake
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_14);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005907 RID: 22791
		// (get) Token: 0x06026C6F RID: 158831 RVA: 0x009E1C5E File Offset: 0x009DFE5E
		// (set) Token: 0x06026C70 RID: 158832 RVA: 0x009E1C6E File Offset: 0x009DFE6E
		public unsafe float CastVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005908 RID: 22792
		// (get) Token: 0x06026C71 RID: 158833 RVA: 0x009E1C7F File Offset: 0x009DFE7F
		// (set) Token: 0x06026C72 RID: 158834 RVA: 0x009E1C8F File Offset: 0x009DFE8F
		public unsafe float PhysHandleLinearDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005909 RID: 22793
		// (get) Token: 0x06026C73 RID: 158835 RVA: 0x009E1CA0 File Offset: 0x009DFEA0
		// (set) Token: 0x06026C74 RID: 158836 RVA: 0x009E1CB0 File Offset: 0x009DFEB0
		public unsafe float PhysHandleAngularStiffness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700590A RID: 22794
		// (get) Token: 0x06026C75 RID: 158837 RVA: 0x009E1CC1 File Offset: 0x009DFEC1
		// (set) Token: 0x06026C76 RID: 158838 RVA: 0x009E1CD1 File Offset: 0x009DFED1
		public unsafe float PhysHandleLinearStiffness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700590B RID: 22795
		// (get) Token: 0x06026C77 RID: 158839 RVA: 0x009E1CE2 File Offset: 0x009DFEE2
		// (set) Token: 0x06026C78 RID: 158840 RVA: 0x009E1CF2 File Offset: 0x009DFEF2
		public unsafe float PhysHandleAngularDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700590C RID: 22796
		// (get) Token: 0x06026C79 RID: 158841 RVA: 0x009E1D03 File Offset: 0x009DFF03
		// (set) Token: 0x06026C7A RID: 158842 RVA: 0x009E1D17 File Offset: 0x009DFF17
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UMatineeCameraShake> HoldCameraShake
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_20);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700590D RID: 22797
		// (get) Token: 0x06026C7B RID: 158843 RVA: 0x009E1D2C File Offset: 0x009DFF2C
		// (set) Token: 0x06026C7C RID: 158844 RVA: 0x009E1D40 File Offset: 0x009DFF40
		public unsafe FGameplayTag HoldCameraStateTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ManipulateConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x06026C7D RID: 158845 RVA: 0x009E1D55 File Offset: 0x009DFF55
		protected BP_ManipulateConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401437E RID: 82814
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/InteractiveObject/BP_ManipulateConfig.BP_ManipulateConfig_C";

		// Token: 0x0401437F RID: 82815
		private static IntPtr _ClassPtr;

		// Token: 0x04014380 RID: 82816
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014381 RID: 82817
		internal static int __PropertyOffset_0;

		// Token: 0x04014382 RID: 82818
		internal static int __PropertyOffset_1;

		// Token: 0x04014383 RID: 82819
		internal static int __PropertyOffset_2;

		// Token: 0x04014384 RID: 82820
		internal static int __PropertyOffset_3;

		// Token: 0x04014385 RID: 82821
		internal static int __PropertyOffset_4;

		// Token: 0x04014386 RID: 82822
		internal static int __PropertyOffset_5;

		// Token: 0x04014387 RID: 82823
		internal static int __PropertyOffset_6;

		// Token: 0x04014388 RID: 82824
		internal static int __PropertyOffset_7;

		// Token: 0x04014389 RID: 82825
		internal static int __PropertyOffset_8;

		// Token: 0x0401438A RID: 82826
		internal static int __PropertyOffset_9;

		// Token: 0x0401438B RID: 82827
		internal static int __PropertyOffset_10;

		// Token: 0x0401438C RID: 82828
		internal static int __PropertyOffset_11;

		// Token: 0x0401438D RID: 82829
		internal static int __PropertyOffset_12;

		// Token: 0x0401438E RID: 82830
		internal static int __PropertyOffset_13;

		// Token: 0x0401438F RID: 82831
		internal static int __PropertyOffset_14;

		// Token: 0x04014390 RID: 82832
		internal static int __PropertyOffset_15;

		// Token: 0x04014391 RID: 82833
		internal static int __PropertyOffset_16;

		// Token: 0x04014392 RID: 82834
		internal static int __PropertyOffset_17;

		// Token: 0x04014393 RID: 82835
		internal static int __PropertyOffset_18;

		// Token: 0x04014394 RID: 82836
		internal static int __PropertyOffset_19;

		// Token: 0x04014395 RID: 82837
		internal static int __PropertyOffset_20;

		// Token: 0x04014396 RID: 82838
		internal static int __PropertyOffset_21;
	}
}
