using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Vehicle
{
	// Token: 0x02003E67 RID: 15975
	[UnrealObjectPath("/Game/Aki/Data/Level/Vehicle/BP_GongduolaConfig.BP_GongduolaConfig_C")]
	[UnrealStructLayout(976, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 972)]
	public class BP_GongduolaConfig_C : BP_VehicleConfig_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060276FD RID: 161533 RVA: 0x009F1D54 File Offset: 0x009EFF54
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GongduolaConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Vehicle/BP_GongduolaConfig.BP_GongduolaConfig_C");
			}
			return BP_GongduolaConfig_C._ClassPtr;
		}

		// Token: 0x060276FE RID: 161534 RVA: 0x009F1D78 File Offset: 0x009EFF78
		public BP_GongduolaConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_GongduolaConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060276FF RID: 161535 RVA: 0x009F1DA0 File Offset: 0x009EFFA0
		[NullableContext(1)]
		public BP_GongduolaConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GongduolaConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005CB6 RID: 23734
		// (get) Token: 0x06027700 RID: 161536 RVA: 0x009F1DD3 File Offset: 0x009EFFD3
		// (set) Token: 0x06027701 RID: 161537 RVA: 0x009F1DE3 File Offset: 0x009EFFE3
		public unsafe float 前进最大移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005CB7 RID: 23735
		// (get) Token: 0x06027702 RID: 161538 RVA: 0x009F1DF4 File Offset: 0x009EFFF4
		// (set) Token: 0x06027703 RID: 161539 RVA: 0x009F1E04 File Offset: 0x009F0004
		public unsafe float 常态后退最大移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005CB8 RID: 23736
		// (get) Token: 0x06027704 RID: 161540 RVA: 0x009F1E15 File Offset: 0x009F0015
		// (set) Token: 0x06027705 RID: 161541 RVA: 0x009F1E25 File Offset: 0x009F0025
		public unsafe float 常态前进加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005CB9 RID: 23737
		// (get) Token: 0x06027706 RID: 161542 RVA: 0x009F1E36 File Offset: 0x009F0036
		// (set) Token: 0x06027707 RID: 161543 RVA: 0x009F1E46 File Offset: 0x009F0046
		public unsafe float 常态后退加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005CBA RID: 23738
		// (get) Token: 0x06027708 RID: 161544 RVA: 0x009F1E57 File Offset: 0x009F0057
		// (set) Token: 0x06027709 RID: 161545 RVA: 0x009F1E67 File Offset: 0x009F0067
		public unsafe float 常态刹车加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005CBB RID: 23739
		// (get) Token: 0x0602770A RID: 161546 RVA: 0x009F1E78 File Offset: 0x009F0078
		// (set) Token: 0x0602770B RID: 161547 RVA: 0x009F1E88 File Offset: 0x009F0088
		public unsafe float 常态最小加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005CBC RID: 23740
		// (get) Token: 0x0602770C RID: 161548 RVA: 0x009F1E99 File Offset: 0x009F0099
		// (set) Token: 0x0602770D RID: 161549 RVA: 0x009F1EA9 File Offset: 0x009F00A9
		public unsafe float 常态最大转向加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005CBD RID: 23741
		// (get) Token: 0x0602770E RID: 161550 RVA: 0x009F1EBA File Offset: 0x009F00BA
		// (set) Token: 0x0602770F RID: 161551 RVA: 0x009F1ECA File Offset: 0x009F00CA
		public unsafe float 常态最小转向加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005CBE RID: 23742
		// (get) Token: 0x06027710 RID: 161552 RVA: 0x009F1EDB File Offset: 0x009F00DB
		// (set) Token: 0x06027711 RID: 161553 RVA: 0x009F1EEB File Offset: 0x009F00EB
		public unsafe float 常态转向公式角度修正系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005CBF RID: 23743
		// (get) Token: 0x06027712 RID: 161554 RVA: 0x009F1EFC File Offset: 0x009F00FC
		// (set) Token: 0x06027713 RID: 161555 RVA: 0x009F1F0C File Offset: 0x009F010C
		public unsafe float 常态转向公式速度修正系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005CC0 RID: 23744
		// (get) Token: 0x06027714 RID: 161556 RVA: 0x009F1F1D File Offset: 0x009F011D
		// (set) Token: 0x06027715 RID: 161557 RVA: 0x009F1F2D File Offset: 0x009F012D
		public unsafe float 常态转向公式最终修正系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005CC1 RID: 23745
		// (get) Token: 0x06027716 RID: 161558 RVA: 0x009F1F3E File Offset: 0x009F013E
		// (set) Token: 0x06027717 RID: 161559 RVA: 0x009F1F4E File Offset: 0x009F014E
		public unsafe float 常态径向运动摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005CC2 RID: 23746
		// (get) Token: 0x06027718 RID: 161560 RVA: 0x009F1F5F File Offset: 0x009F015F
		// (set) Token: 0x06027719 RID: 161561 RVA: 0x009F1F6F File Offset: 0x009F016F
		public unsafe float 常态横向运动摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005CC3 RID: 23747
		// (get) Token: 0x0602771A RID: 161562 RVA: 0x009F1F80 File Offset: 0x009F0180
		// (set) Token: 0x0602771B RID: 161563 RVA: 0x009F1F90 File Offset: 0x009F0190
		public unsafe float 常态最大转向速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005CC4 RID: 23748
		// (get) Token: 0x0602771C RID: 161564 RVA: 0x009F1FA1 File Offset: 0x009F01A1
		// (set) Token: 0x0602771D RID: 161565 RVA: 0x009F1FB1 File Offset: 0x009F01B1
		public unsafe float 常态转向摩擦力系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005CC5 RID: 23749
		// (get) Token: 0x0602771E RID: 161566 RVA: 0x009F1FC2 File Offset: 0x009F01C2
		// (set) Token: 0x0602771F RID: 161567 RVA: 0x009F1FD2 File Offset: 0x009F01D2
		public unsafe float 常态转向静止摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005CC6 RID: 23750
		// (get) Token: 0x06027720 RID: 161568 RVA: 0x009F1FE3 File Offset: 0x009F01E3
		// (set) Token: 0x06027721 RID: 161569 RVA: 0x009F1FF3 File Offset: 0x009F01F3
		public unsafe float 冲刺超限持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005CC7 RID: 23751
		// (get) Token: 0x06027722 RID: 161570 RVA: 0x009F2004 File Offset: 0x009F0204
		// (set) Token: 0x06027723 RID: 161571 RVA: 0x009F2014 File Offset: 0x009F0214
		public unsafe float 冲刺超限移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005CC8 RID: 23752
		// (get) Token: 0x06027724 RID: 161572 RVA: 0x009F2025 File Offset: 0x009F0225
		// (set) Token: 0x06027725 RID: 161573 RVA: 0x009F2035 File Offset: 0x009F0235
		public unsafe float 冲刺最大移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005CC9 RID: 23753
		// (get) Token: 0x06027726 RID: 161574 RVA: 0x009F2046 File Offset: 0x009F0246
		// (set) Token: 0x06027727 RID: 161575 RVA: 0x009F2056 File Offset: 0x009F0256
		public unsafe float 冲刺后退最大移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005CCA RID: 23754
		// (get) Token: 0x06027728 RID: 161576 RVA: 0x009F2067 File Offset: 0x009F0267
		// (set) Token: 0x06027729 RID: 161577 RVA: 0x009F2077 File Offset: 0x009F0277
		public unsafe float 冲刺停止速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005CCB RID: 23755
		// (get) Token: 0x0602772A RID: 161578 RVA: 0x009F2088 File Offset: 0x009F0288
		// (set) Token: 0x0602772B RID: 161579 RVA: 0x009F2098 File Offset: 0x009F0298
		public unsafe float 冲刺前进加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005CCC RID: 23756
		// (get) Token: 0x0602772C RID: 161580 RVA: 0x009F20A9 File Offset: 0x009F02A9
		// (set) Token: 0x0602772D RID: 161581 RVA: 0x009F20B9 File Offset: 0x009F02B9
		public unsafe float 冲刺刹车加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005CCD RID: 23757
		// (get) Token: 0x0602772E RID: 161582 RVA: 0x009F20CA File Offset: 0x009F02CA
		// (set) Token: 0x0602772F RID: 161583 RVA: 0x009F20DA File Offset: 0x009F02DA
		public unsafe float 冲刺后退加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005CCE RID: 23758
		// (get) Token: 0x06027730 RID: 161584 RVA: 0x009F20EB File Offset: 0x009F02EB
		// (set) Token: 0x06027731 RID: 161585 RVA: 0x009F20FB File Offset: 0x009F02FB
		public unsafe float 冲刺最小加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005CCF RID: 23759
		// (get) Token: 0x06027732 RID: 161586 RVA: 0x009F210C File Offset: 0x009F030C
		// (set) Token: 0x06027733 RID: 161587 RVA: 0x009F211C File Offset: 0x009F031C
		public unsafe float 冲刺最大转向加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005CD0 RID: 23760
		// (get) Token: 0x06027734 RID: 161588 RVA: 0x009F212D File Offset: 0x009F032D
		// (set) Token: 0x06027735 RID: 161589 RVA: 0x009F213D File Offset: 0x009F033D
		public unsafe float 冲刺最小转向加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005CD1 RID: 23761
		// (get) Token: 0x06027736 RID: 161590 RVA: 0x009F214E File Offset: 0x009F034E
		// (set) Token: 0x06027737 RID: 161591 RVA: 0x009F215E File Offset: 0x009F035E
		public unsafe float 冲刺转向公式角度修正系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17005CD2 RID: 23762
		// (get) Token: 0x06027738 RID: 161592 RVA: 0x009F216F File Offset: 0x009F036F
		// (set) Token: 0x06027739 RID: 161593 RVA: 0x009F217F File Offset: 0x009F037F
		public unsafe float 冲刺转向公式速度修正系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17005CD3 RID: 23763
		// (get) Token: 0x0602773A RID: 161594 RVA: 0x009F2190 File Offset: 0x009F0390
		// (set) Token: 0x0602773B RID: 161595 RVA: 0x009F21A0 File Offset: 0x009F03A0
		public unsafe float 冲刺转向公式最终修正系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17005CD4 RID: 23764
		// (get) Token: 0x0602773C RID: 161596 RVA: 0x009F21B1 File Offset: 0x009F03B1
		// (set) Token: 0x0602773D RID: 161597 RVA: 0x009F21C1 File Offset: 0x009F03C1
		public unsafe float 冲刺径向运动摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17005CD5 RID: 23765
		// (get) Token: 0x0602773E RID: 161598 RVA: 0x009F21D2 File Offset: 0x009F03D2
		// (set) Token: 0x0602773F RID: 161599 RVA: 0x009F21E2 File Offset: 0x009F03E2
		public unsafe float 冲刺横向运动摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17005CD6 RID: 23766
		// (get) Token: 0x06027740 RID: 161600 RVA: 0x009F21F3 File Offset: 0x009F03F3
		// (set) Token: 0x06027741 RID: 161601 RVA: 0x009F2203 File Offset: 0x009F0403
		public unsafe float 冲刺最大转向速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17005CD7 RID: 23767
		// (get) Token: 0x06027742 RID: 161602 RVA: 0x009F2214 File Offset: 0x009F0414
		// (set) Token: 0x06027743 RID: 161603 RVA: 0x009F2224 File Offset: 0x009F0424
		public unsafe float 冲刺转向摩擦力系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17005CD8 RID: 23768
		// (get) Token: 0x06027744 RID: 161604 RVA: 0x009F2235 File Offset: 0x009F0435
		// (set) Token: 0x06027745 RID: 161605 RVA: 0x009F2245 File Offset: 0x009F0445
		public unsafe float 冲刺转向静止摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17005CD9 RID: 23769
		// (get) Token: 0x06027746 RID: 161606 RVA: 0x009F2256 File Offset: 0x009F0456
		// (set) Token: 0x06027747 RID: 161607 RVA: 0x009F2266 File Offset: 0x009F0466
		public unsafe float 超出最大速度时的额外摩擦力
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17005CDA RID: 23770
		// (get) Token: 0x06027748 RID: 161608 RVA: 0x009F2277 File Offset: 0x009F0477
		// (set) Token: 0x06027749 RID: 161609 RVA: 0x009F2287 File Offset: 0x009F0487
		public unsafe float 冲刺固定前向输入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17005CDB RID: 23771
		// (get) Token: 0x0602774A RID: 161610 RVA: 0x009F2298 File Offset: 0x009F0498
		// (set) Token: 0x0602774B RID: 161611 RVA: 0x009F22A8 File Offset: 0x009F04A8
		public unsafe float 最大上浮速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17005CDC RID: 23772
		// (get) Token: 0x0602774C RID: 161612 RVA: 0x009F22B9 File Offset: 0x009F04B9
		// (set) Token: 0x0602774D RID: 161613 RVA: 0x009F22C9 File Offset: 0x009F04C9
		public unsafe float 浮力平衡位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17005CDD RID: 23773
		// (get) Token: 0x0602774E RID: 161614 RVA: 0x009F22DA File Offset: 0x009F04DA
		// (set) Token: 0x0602774F RID: 161615 RVA: 0x009F22EA File Offset: 0x009F04EA
		public unsafe float 搁浅位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17005CDE RID: 23774
		// (get) Token: 0x06027750 RID: 161616 RVA: 0x009F22FB File Offset: 0x009F04FB
		// (set) Token: 0x06027751 RID: 161617 RVA: 0x009F230B File Offset: 0x009F050B
		public unsafe float 漂浮阻力系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17005CDF RID: 23775
		// (get) Token: 0x06027752 RID: 161618 RVA: 0x009F231C File Offset: 0x009F051C
		// (set) Token: 0x06027753 RID: 161619 RVA: 0x009F232C File Offset: 0x009F052C
		public unsafe float 转动惯量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17005CE0 RID: 23776
		// (get) Token: 0x06027754 RID: 161620 RVA: 0x009F233D File Offset: 0x009F053D
		// (set) Token: 0x06027755 RID: 161621 RVA: 0x009F234D File Offset: 0x009F054D
		public unsafe float 速度冲击力系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17005CE1 RID: 23777
		// (get) Token: 0x06027756 RID: 161622 RVA: 0x009F235E File Offset: 0x009F055E
		// (set) Token: 0x06027757 RID: 161623 RVA: 0x009F236E File Offset: 0x009F056E
		public unsafe float 旋转冲击力系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17005CE2 RID: 23778
		// (get) Token: 0x06027758 RID: 161624 RVA: 0x009F237F File Offset: 0x009F057F
		// (set) Token: 0x06027759 RID: 161625 RVA: 0x009F238F File Offset: 0x009F058F
		public unsafe float 常态转向强制前向输入系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17005CE3 RID: 23779
		// (get) Token: 0x0602775A RID: 161626 RVA: 0x009F23A0 File Offset: 0x009F05A0
		// (set) Token: 0x0602775B RID: 161627 RVA: 0x009F23B0 File Offset: 0x009F05B0
		public unsafe float 冲刺转向强制前向输入系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17005CE4 RID: 23780
		// (get) Token: 0x0602775C RID: 161628 RVA: 0x009F23C1 File Offset: 0x009F05C1
		// (set) Token: 0x0602775D RID: 161629 RVA: 0x009F23D1 File Offset: 0x009F05D1
		public unsafe float 常态最大前后输入阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17005CE5 RID: 23781
		// (get) Token: 0x0602775E RID: 161630 RVA: 0x009F23E2 File Offset: 0x009F05E2
		// (set) Token: 0x0602775F RID: 161631 RVA: 0x009F23F2 File Offset: 0x009F05F2
		public unsafe float 常态最大左右输入阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17005CE6 RID: 23782
		// (get) Token: 0x06027760 RID: 161632 RVA: 0x009F2403 File Offset: 0x009F0603
		// (set) Token: 0x06027761 RID: 161633 RVA: 0x009F2413 File Offset: 0x009F0613
		public unsafe float 冲刺最大前后输入阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17005CE7 RID: 23783
		// (get) Token: 0x06027762 RID: 161634 RVA: 0x009F2424 File Offset: 0x009F0624
		// (set) Token: 0x06027763 RID: 161635 RVA: 0x009F2434 File Offset: 0x009F0634
		public unsafe float 冲刺最大左右输入阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17005CE8 RID: 23784
		// (get) Token: 0x06027764 RID: 161636 RVA: 0x009F2445 File Offset: 0x009F0645
		// (set) Token: 0x06027765 RID: 161637 RVA: 0x009F2455 File Offset: 0x009F0655
		public unsafe float 冲刺持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17005CE9 RID: 23785
		// (get) Token: 0x06027766 RID: 161638 RVA: 0x009F2466 File Offset: 0x009F0666
		// (set) Token: 0x06027767 RID: 161639 RVA: 0x009F2476 File Offset: 0x009F0676
		public unsafe float 冲刺冷却时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17005CEA RID: 23786
		// (get) Token: 0x06027768 RID: 161640 RVA: 0x009F2487 File Offset: 0x009F0687
		// (set) Token: 0x06027769 RID: 161641 RVA: 0x009F2497 File Offset: 0x009F0697
		public unsafe int 冲刺最大使用次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17005CEB RID: 23787
		// (get) Token: 0x0602776A RID: 161642 RVA: 0x009F24A8 File Offset: 0x009F06A8
		// (set) Token: 0x0602776B RID: 161643 RVA: 0x009F24B8 File Offset: 0x009F06B8
		public unsafe float 前向转弯最小X输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17005CEC RID: 23788
		// (get) Token: 0x0602776C RID: 161644 RVA: 0x009F24C9 File Offset: 0x009F06C9
		// (set) Token: 0x0602776D RID: 161645 RVA: 0x009F24D9 File Offset: 0x009F06D9
		public unsafe float 后向转向最大X输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GongduolaConfig_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x0602776E RID: 161646 RVA: 0x009F24EA File Offset: 0x009F06EA
		protected BP_GongduolaConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014A78 RID: 84600
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Vehicle/BP_GongduolaConfig.BP_GongduolaConfig_C";

		// Token: 0x04014A79 RID: 84601
		private static IntPtr _ClassPtr;

		// Token: 0x04014A7A RID: 84602
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014A7B RID: 84603
		internal new static int __PropertyOffset_0;

		// Token: 0x04014A7C RID: 84604
		internal new static int __PropertyOffset_1;

		// Token: 0x04014A7D RID: 84605
		internal new static int __PropertyOffset_2;

		// Token: 0x04014A7E RID: 84606
		internal new static int __PropertyOffset_3;

		// Token: 0x04014A7F RID: 84607
		internal new static int __PropertyOffset_4;

		// Token: 0x04014A80 RID: 84608
		internal new static int __PropertyOffset_5;

		// Token: 0x04014A81 RID: 84609
		internal new static int __PropertyOffset_6;

		// Token: 0x04014A82 RID: 84610
		internal new static int __PropertyOffset_7;

		// Token: 0x04014A83 RID: 84611
		internal new static int __PropertyOffset_8;

		// Token: 0x04014A84 RID: 84612
		internal new static int __PropertyOffset_9;

		// Token: 0x04014A85 RID: 84613
		internal new static int __PropertyOffset_10;

		// Token: 0x04014A86 RID: 84614
		internal new static int __PropertyOffset_11;

		// Token: 0x04014A87 RID: 84615
		internal new static int __PropertyOffset_12;

		// Token: 0x04014A88 RID: 84616
		internal new static int __PropertyOffset_13;

		// Token: 0x04014A89 RID: 84617
		internal new static int __PropertyOffset_14;

		// Token: 0x04014A8A RID: 84618
		internal new static int __PropertyOffset_15;

		// Token: 0x04014A8B RID: 84619
		internal new static int __PropertyOffset_16;

		// Token: 0x04014A8C RID: 84620
		internal new static int __PropertyOffset_17;

		// Token: 0x04014A8D RID: 84621
		internal new static int __PropertyOffset_18;

		// Token: 0x04014A8E RID: 84622
		internal new static int __PropertyOffset_19;

		// Token: 0x04014A8F RID: 84623
		internal static int __PropertyOffset_20;

		// Token: 0x04014A90 RID: 84624
		internal static int __PropertyOffset_21;

		// Token: 0x04014A91 RID: 84625
		internal static int __PropertyOffset_22;

		// Token: 0x04014A92 RID: 84626
		internal static int __PropertyOffset_23;

		// Token: 0x04014A93 RID: 84627
		internal static int __PropertyOffset_24;

		// Token: 0x04014A94 RID: 84628
		internal static int __PropertyOffset_25;

		// Token: 0x04014A95 RID: 84629
		internal static int __PropertyOffset_26;

		// Token: 0x04014A96 RID: 84630
		internal static int __PropertyOffset_27;

		// Token: 0x04014A97 RID: 84631
		internal static int __PropertyOffset_28;

		// Token: 0x04014A98 RID: 84632
		internal static int __PropertyOffset_29;

		// Token: 0x04014A99 RID: 84633
		internal static int __PropertyOffset_30;

		// Token: 0x04014A9A RID: 84634
		internal static int __PropertyOffset_31;

		// Token: 0x04014A9B RID: 84635
		internal static int __PropertyOffset_32;

		// Token: 0x04014A9C RID: 84636
		internal static int __PropertyOffset_33;

		// Token: 0x04014A9D RID: 84637
		internal static int __PropertyOffset_34;

		// Token: 0x04014A9E RID: 84638
		internal static int __PropertyOffset_35;

		// Token: 0x04014A9F RID: 84639
		internal static int __PropertyOffset_36;

		// Token: 0x04014AA0 RID: 84640
		internal static int __PropertyOffset_37;

		// Token: 0x04014AA1 RID: 84641
		internal static int __PropertyOffset_38;

		// Token: 0x04014AA2 RID: 84642
		internal static int __PropertyOffset_39;

		// Token: 0x04014AA3 RID: 84643
		internal static int __PropertyOffset_40;

		// Token: 0x04014AA4 RID: 84644
		internal static int __PropertyOffset_41;

		// Token: 0x04014AA5 RID: 84645
		internal static int __PropertyOffset_42;

		// Token: 0x04014AA6 RID: 84646
		internal static int __PropertyOffset_43;

		// Token: 0x04014AA7 RID: 84647
		internal static int __PropertyOffset_44;

		// Token: 0x04014AA8 RID: 84648
		internal static int __PropertyOffset_45;

		// Token: 0x04014AA9 RID: 84649
		internal static int __PropertyOffset_46;

		// Token: 0x04014AAA RID: 84650
		internal static int __PropertyOffset_47;

		// Token: 0x04014AAB RID: 84651
		internal static int __PropertyOffset_48;

		// Token: 0x04014AAC RID: 84652
		internal static int __PropertyOffset_49;

		// Token: 0x04014AAD RID: 84653
		internal static int __PropertyOffset_50;

		// Token: 0x04014AAE RID: 84654
		internal static int __PropertyOffset_51;

		// Token: 0x04014AAF RID: 84655
		internal static int __PropertyOffset_52;

		// Token: 0x04014AB0 RID: 84656
		internal static int __PropertyOffset_53;

		// Token: 0x04014AB1 RID: 84657
		internal static int __PropertyOffset_54;
	}
}
