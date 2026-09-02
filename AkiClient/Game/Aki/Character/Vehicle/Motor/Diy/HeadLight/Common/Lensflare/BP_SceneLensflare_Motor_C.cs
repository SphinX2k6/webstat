using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.Lensflare
{
	// Token: 0x02003FA3 RID: 16291
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/Lensflare/BP_SceneLensflare_Motor.BP_SceneLensflare_Motor_C")]
	[UnrealStructLayout(1576, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1576)]
	public class BP_SceneLensflare_Motor_C : ALensflareSamplerActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028DF6 RID: 167414 RVA: 0x00A19101 File Offset: 0x00A17301
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneLensflare_Motor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/Lensflare/BP_SceneLensflare_Motor.BP_SceneLensflare_Motor_C");
			}
			return BP_SceneLensflare_Motor_C._ClassPtr;
		}

		// Token: 0x06028DF7 RID: 167415 RVA: 0x00A19128 File Offset: 0x00A17328
		public BP_SceneLensflare_Motor_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneLensflare_Motor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028DF8 RID: 167416 RVA: 0x00A19150 File Offset: 0x00A17350
		[NullableContext(1)]
		public BP_SceneLensflare_Motor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneLensflare_Motor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006497 RID: 25751
		// (get) Token: 0x06028DF9 RID: 167417 RVA: 0x00A19184 File Offset: 0x00A17384
		// (set) Token: 0x06028DFA RID: 167418 RVA: 0x00A191BD File Offset: 0x00A173BD
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006498 RID: 25752
		// (get) Token: 0x06028DFB RID: 167419 RVA: 0x00A191DE File Offset: 0x00A173DE
		// (set) Token: 0x06028DFC RID: 167420 RVA: 0x00A191F2 File Offset: 0x00A173F2
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006499 RID: 25753
		// (get) Token: 0x06028DFD RID: 167421 RVA: 0x00A19207 File Offset: 0x00A17407
		// (set) Token: 0x06028DFE RID: 167422 RVA: 0x00A19217 File Offset: 0x00A17417
		public unsafe bool 自定义Ghost
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700649A RID: 25754
		// (get) Token: 0x06028DFF RID: 167423 RVA: 0x00A19228 File Offset: 0x00A17428
		// (set) Token: 0x06028E00 RID: 167424 RVA: 0x00A19238 File Offset: 0x00A17438
		public unsafe float Ghost_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700649B RID: 25755
		// (get) Token: 0x06028E01 RID: 167425 RVA: 0x00A19249 File Offset: 0x00A17449
		// (set) Token: 0x06028E02 RID: 167426 RVA: 0x00A19259 File Offset: 0x00A17459
		public unsafe float Ghost_分布偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700649C RID: 25756
		// (get) Token: 0x06028E03 RID: 167427 RVA: 0x00A1926A File Offset: 0x00A1746A
		// (set) Token: 0x06028E04 RID: 167428 RVA: 0x00A1927A File Offset: 0x00A1747A
		public unsafe float Ghost_分布范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700649D RID: 25757
		// (get) Token: 0x06028E05 RID: 167429 RVA: 0x00A1928B File Offset: 0x00A1748B
		// (set) Token: 0x06028E06 RID: 167430 RVA: 0x00A1929F File Offset: 0x00A1749F
		public unsafe FLinearColor Ghost_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700649E RID: 25758
		// (get) Token: 0x06028E07 RID: 167431 RVA: 0x00A192B4 File Offset: 0x00A174B4
		// (set) Token: 0x06028E08 RID: 167432 RVA: 0x00A192C4 File Offset: 0x00A174C4
		public unsafe float Ghost_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700649F RID: 25759
		// (get) Token: 0x06028E09 RID: 167433 RVA: 0x00A192D5 File Offset: 0x00A174D5
		// (set) Token: 0x06028E0A RID: 167434 RVA: 0x00A192E5 File Offset: 0x00A174E5
		public unsafe bool 自定义Halo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064A0 RID: 25760
		// (get) Token: 0x06028E0B RID: 167435 RVA: 0x00A192F6 File Offset: 0x00A174F6
		// (set) Token: 0x06028E0C RID: 167436 RVA: 0x00A19306 File Offset: 0x00A17506
		public unsafe float Halo_圆环衰减
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170064A1 RID: 25761
		// (get) Token: 0x06028E0D RID: 167437 RVA: 0x00A19317 File Offset: 0x00A17517
		// (set) Token: 0x06028E0E RID: 167438 RVA: 0x00A19327 File Offset: 0x00A17527
		public unsafe float Halo_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170064A2 RID: 25762
		// (get) Token: 0x06028E0F RID: 167439 RVA: 0x00A19338 File Offset: 0x00A17538
		// (set) Token: 0x06028E10 RID: 167440 RVA: 0x00A19348 File Offset: 0x00A17548
		public unsafe float Halo_分布偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170064A3 RID: 25763
		// (get) Token: 0x06028E11 RID: 167441 RVA: 0x00A19359 File Offset: 0x00A17559
		// (set) Token: 0x06028E12 RID: 167442 RVA: 0x00A19369 File Offset: 0x00A17569
		public unsafe float Halo_分布范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170064A4 RID: 25764
		// (get) Token: 0x06028E13 RID: 167443 RVA: 0x00A1937A File Offset: 0x00A1757A
		// (set) Token: 0x06028E14 RID: 167444 RVA: 0x00A1938E File Offset: 0x00A1758E
		public unsafe FLinearColor Halo_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170064A5 RID: 25765
		// (get) Token: 0x06028E15 RID: 167445 RVA: 0x00A193A3 File Offset: 0x00A175A3
		// (set) Token: 0x06028E16 RID: 167446 RVA: 0x00A193B3 File Offset: 0x00A175B3
		public unsafe float Halo_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170064A6 RID: 25766
		// (get) Token: 0x06028E17 RID: 167447 RVA: 0x00A193C4 File Offset: 0x00A175C4
		// (set) Token: 0x06028E18 RID: 167448 RVA: 0x00A193D4 File Offset: 0x00A175D4
		public unsafe bool 自定义Glare
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064A7 RID: 25767
		// (get) Token: 0x06028E19 RID: 167449 RVA: 0x00A193E5 File Offset: 0x00A175E5
		// (set) Token: 0x06028E1A RID: 167450 RVA: 0x00A193F9 File Offset: 0x00A175F9
		public unsafe FVector2D Glare_大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170064A8 RID: 25768
		// (get) Token: 0x06028E1B RID: 167451 RVA: 0x00A1940E File Offset: 0x00A1760E
		// (set) Token: 0x06028E1C RID: 167452 RVA: 0x00A19422 File Offset: 0x00A17622
		public unsafe FLinearColor Glare_调色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170064A9 RID: 25769
		// (get) Token: 0x06028E1D RID: 167453 RVA: 0x00A19437 File Offset: 0x00A17637
		// (set) Token: 0x06028E1E RID: 167454 RVA: 0x00A19447 File Offset: 0x00A17647
		public unsafe float Glare_不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170064AA RID: 25770
		// (get) Token: 0x06028E1F RID: 167455 RVA: 0x00A19458 File Offset: 0x00A17658
		// (set) Token: 0x06028E20 RID: 167456 RVA: 0x00A19468 File Offset: 0x00A17668
		public unsafe float Glare_旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170064AB RID: 25771
		// (get) Token: 0x06028E21 RID: 167457 RVA: 0x00A19479 File Offset: 0x00A17679
		// (set) Token: 0x06028E22 RID: 167458 RVA: 0x00A19489 File Offset: 0x00A17689
		public unsafe float Glare_锁定动态旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170064AC RID: 25772
		// (get) Token: 0x06028E23 RID: 167459 RVA: 0x00A1949A File Offset: 0x00A1769A
		// (set) Token: 0x06028E24 RID: 167460 RVA: 0x00A194AA File Offset: 0x00A176AA
		public unsafe float Ghost_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170064AD RID: 25773
		// (get) Token: 0x06028E25 RID: 167461 RVA: 0x00A194BB File Offset: 0x00A176BB
		// (set) Token: 0x06028E26 RID: 167462 RVA: 0x00A194CB File Offset: 0x00A176CB
		public unsafe float Halo_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170064AE RID: 25774
		// (get) Token: 0x06028E27 RID: 167463 RVA: 0x00A194DC File Offset: 0x00A176DC
		// (set) Token: 0x06028E28 RID: 167464 RVA: 0x00A194EC File Offset: 0x00A176EC
		public unsafe float Glare_受背景色影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170064AF RID: 25775
		// (get) Token: 0x06028E29 RID: 167465 RVA: 0x00A194FD File Offset: 0x00A176FD
		// (set) Token: 0x06028E2A RID: 167466 RVA: 0x00A1950D File Offset: 0x00A1770D
		public unsafe float Ghost_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170064B0 RID: 25776
		// (get) Token: 0x06028E2B RID: 167467 RVA: 0x00A1951E File Offset: 0x00A1771E
		// (set) Token: 0x06028E2C RID: 167468 RVA: 0x00A1952E File Offset: 0x00A1772E
		public unsafe float Halo_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170064B1 RID: 25777
		// (get) Token: 0x06028E2D RID: 167469 RVA: 0x00A1953F File Offset: 0x00A1773F
		// (set) Token: 0x06028E2E RID: 167470 RVA: 0x00A1954F File Offset: 0x00A1774F
		public unsafe float Glare_视角衰减速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170064B2 RID: 25778
		// (get) Token: 0x06028E2F RID: 167471 RVA: 0x00A19560 File Offset: 0x00A17760
		// (set) Token: 0x06028E30 RID: 167472 RVA: 0x00A19570 File Offset: 0x00A17770
		public unsafe bool Ghost_使用固定旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064B3 RID: 25779
		// (get) Token: 0x06028E31 RID: 167473 RVA: 0x00A19581 File Offset: 0x00A17781
		// (set) Token: 0x06028E32 RID: 167474 RVA: 0x00A19591 File Offset: 0x00A17791
		public unsafe float Ghost_固定旋转值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170064B4 RID: 25780
		// (get) Token: 0x06028E33 RID: 167475 RVA: 0x00A195A2 File Offset: 0x00A177A2
		// (set) Token: 0x06028E34 RID: 167476 RVA: 0x00A195B2 File Offset: 0x00A177B2
		public unsafe bool 自定义Ghost贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064B5 RID: 25781
		// (get) Token: 0x06028E35 RID: 167477 RVA: 0x00A195C3 File Offset: 0x00A177C3
		// (set) Token: 0x06028E36 RID: 167478 RVA: 0x00A195D7 File Offset: 0x00A177D7
		public unsafe UTexture2D Ghost贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x170064B6 RID: 25782
		// (get) Token: 0x06028E37 RID: 167479 RVA: 0x00A195EC File Offset: 0x00A177EC
		// (set) Token: 0x06028E38 RID: 167480 RVA: 0x00A195FC File Offset: 0x00A177FC
		public unsafe bool Halo_使用固定旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064B7 RID: 25783
		// (get) Token: 0x06028E39 RID: 167481 RVA: 0x00A1960D File Offset: 0x00A1780D
		// (set) Token: 0x06028E3A RID: 167482 RVA: 0x00A1961D File Offset: 0x00A1781D
		public unsafe float Halo_固定旋转值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170064B8 RID: 25784
		// (get) Token: 0x06028E3B RID: 167483 RVA: 0x00A1962E File Offset: 0x00A1782E
		// (set) Token: 0x06028E3C RID: 167484 RVA: 0x00A1963E File Offset: 0x00A1783E
		public unsafe bool 自定义Halo贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064B9 RID: 25785
		// (get) Token: 0x06028E3D RID: 167485 RVA: 0x00A1964F File Offset: 0x00A1784F
		// (set) Token: 0x06028E3E RID: 167486 RVA: 0x00A19663 File Offset: 0x00A17863
		public unsafe UTexture2D Halo贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x170064BA RID: 25786
		// (get) Token: 0x06028E3F RID: 167487 RVA: 0x00A19678 File Offset: 0x00A17878
		// (set) Token: 0x06028E40 RID: 167488 RVA: 0x00A19688 File Offset: 0x00A17888
		public unsafe bool 自定义Glare贴图
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064BB RID: 25787
		// (get) Token: 0x06028E41 RID: 167489 RVA: 0x00A19699 File Offset: 0x00A17899
		// (set) Token: 0x06028E42 RID: 167490 RVA: 0x00A196AD File Offset: 0x00A178AD
		public unsafe UTexture2D Glare贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneLensflare_Motor_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x170064BC RID: 25788
		// (get) Token: 0x06028E43 RID: 167491 RVA: 0x00A196C2 File Offset: 0x00A178C2
		// (set) Token: 0x06028E44 RID: 167492 RVA: 0x00A196D6 File Offset: 0x00A178D6
		public unsafe FLinearColor Glare_UV缩放_偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x170064BD RID: 25789
		// (get) Token: 0x06028E45 RID: 167493 RVA: 0x00A196EB File Offset: 0x00A178EB
		// (set) Token: 0x06028E46 RID: 167494 RVA: 0x00A196FB File Offset: 0x00A178FB
		public unsafe float 衰减系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x170064BE RID: 25790
		// (get) Token: 0x06028E47 RID: 167495 RVA: 0x00A1970C File Offset: 0x00A1790C
		// (set) Token: 0x06028E48 RID: 167496 RVA: 0x00A1971C File Offset: 0x00A1791C
		public unsafe float 屏占比剔除阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneLensflare_Motor_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x06028E49 RID: 167497 RVA: 0x00A19730 File Offset: 0x00A17930
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorParameter GetLensflareParameter()
		{
			BP_SceneLensflare_Motor_C.__GetLensflareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetLensflareParameter_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetLensflareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E4A RID: 167498 RVA: 0x00A19780 File Offset: 0x00A17980
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorParameter GetLensflareParameter_Implementation()
		{
			BP_SceneLensflare_Motor_C.__GetLensflareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetLensflareParameter_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetLensflareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetLensflareParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E4B RID: 167499 RVA: 0x00A197D0 File Offset: 0x00A179D0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorGlareParameter GetCustomGlareParameter()
		{
			BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorGlareParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E4C RID: 167500 RVA: 0x00A19820 File Offset: 0x00A17A20
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorGlareParameter GetCustomGlareParameter_Implementation()
		{
			BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetCustomGlareParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorGlareParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E4D RID: 167501 RVA: 0x00A19874 File Offset: 0x00A17A74
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorHaloParameter GetCustomHaloParameter()
		{
			BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorHaloParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E4E RID: 167502 RVA: 0x00A198C4 File Offset: 0x00A17AC4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorHaloParameter GetCustomHaloParameter_Implementation()
		{
			BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetCustomHaloParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorHaloParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E4F RID: 167503 RVA: 0x00A19918 File Offset: 0x00A17B18
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override FLensflareSamplerActorGhostParameter GetCustomGhostParameter()
		{
			BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr);
			return new FLensflareSamplerActorGhostParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E50 RID: 167504 RVA: 0x00A19968 File Offset: 0x00A17B68
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FLensflareSamplerActorGhostParameter GetCustomGhostParameter_Implementation()
		{
			BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__GetCustomGhostParameter_NativeFunctionPtr, (void*)ptr, 0);
			return new FLensflareSamplerActorGhostParameter(&ptr->__Result, true, true);
		}

		// Token: 0x06028E51 RID: 167505 RVA: 0x00A199B9 File Offset: 0x00A17BB9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06028E52 RID: 167506 RVA: 0x00A199CD File Offset: 0x00A17BCD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028E53 RID: 167507 RVA: 0x00A199E4 File Offset: 0x00A17BE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialGhost(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028E54 RID: 167508 RVA: 0x00A19A3C File Offset: 0x00A17C3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialGhost_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGhost_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028E55 RID: 167509 RVA: 0x00A19A94 File Offset: 0x00A17C94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialHalo(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028E56 RID: 167510 RVA: 0x00A19AEC File Offset: 0x00A17CEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialHalo_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialHalo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028E57 RID: 167511 RVA: 0x00A19B44 File Offset: 0x00A17D44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyDynamicMaterialGlare(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028E58 RID: 167512 RVA: 0x00A19B9C File Offset: 0x00A17D9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ApplyDynamicMaterialGlare_Implementation(UMaterialInstanceDynamic DynMaterial)
		{
			BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DynMaterial = ((DynMaterial != null) ? DynMaterial.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__ApplyDynamicMaterialGlare_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028E59 RID: 167513 RVA: 0x00A19BF4 File Offset: 0x00A17DF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneLensflare_Motor(int EntryPoint)
		{
			BP_SceneLensflare_Motor_C.__ExecuteUbergraph_BP_SceneLensflare_Motor_FunctionParams* ptr = stackalloc BP_SceneLensflare_Motor_C.__ExecuteUbergraph_BP_SceneLensflare_Motor_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SceneLensflare_Motor_C.__ExecuteUbergraph_BP_SceneLensflare_Motor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneLensflare_Motor_C.__ExecuteUbergraph_BP_SceneLensflare_Motor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneLensflare_Motor_C.__ExecuteUbergraph_BP_SceneLensflare_Motor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028E5A RID: 167514 RVA: 0x00A19C3B File Offset: 0x00A17E3B
		protected BP_SceneLensflare_Motor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040159C7 RID: 88519
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/Lensflare/BP_SceneLensflare_Motor.BP_SceneLensflare_Motor_C";

		// Token: 0x040159C8 RID: 88520
		private static IntPtr _ClassPtr;

		// Token: 0x040159C9 RID: 88521
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040159CA RID: 88522
		internal static int __PropertyOffset_0;

		// Token: 0x040159CB RID: 88523
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040159CC RID: 88524
		internal static int __PropertyOffset_1;

		// Token: 0x040159CD RID: 88525
		internal static int __PropertyOffset_2;

		// Token: 0x040159CE RID: 88526
		internal static int __PropertyOffset_3;

		// Token: 0x040159CF RID: 88527
		internal static int __PropertyOffset_4;

		// Token: 0x040159D0 RID: 88528
		internal static int __PropertyOffset_5;

		// Token: 0x040159D1 RID: 88529
		internal static int __PropertyOffset_6;

		// Token: 0x040159D2 RID: 88530
		internal static int __PropertyOffset_7;

		// Token: 0x040159D3 RID: 88531
		internal static int __PropertyOffset_8;

		// Token: 0x040159D4 RID: 88532
		internal static int __PropertyOffset_9;

		// Token: 0x040159D5 RID: 88533
		internal static int __PropertyOffset_10;

		// Token: 0x040159D6 RID: 88534
		internal static int __PropertyOffset_11;

		// Token: 0x040159D7 RID: 88535
		internal static int __PropertyOffset_12;

		// Token: 0x040159D8 RID: 88536
		internal static int __PropertyOffset_13;

		// Token: 0x040159D9 RID: 88537
		internal static int __PropertyOffset_14;

		// Token: 0x040159DA RID: 88538
		internal static int __PropertyOffset_15;

		// Token: 0x040159DB RID: 88539
		internal static int __PropertyOffset_16;

		// Token: 0x040159DC RID: 88540
		internal static int __PropertyOffset_17;

		// Token: 0x040159DD RID: 88541
		internal static int __PropertyOffset_18;

		// Token: 0x040159DE RID: 88542
		internal static int __PropertyOffset_19;

		// Token: 0x040159DF RID: 88543
		internal static int __PropertyOffset_20;

		// Token: 0x040159E0 RID: 88544
		internal static int __PropertyOffset_21;

		// Token: 0x040159E1 RID: 88545
		internal static int __PropertyOffset_22;

		// Token: 0x040159E2 RID: 88546
		internal static int __PropertyOffset_23;

		// Token: 0x040159E3 RID: 88547
		internal static int __PropertyOffset_24;

		// Token: 0x040159E4 RID: 88548
		internal static int __PropertyOffset_25;

		// Token: 0x040159E5 RID: 88549
		internal static int __PropertyOffset_26;

		// Token: 0x040159E6 RID: 88550
		internal static int __PropertyOffset_27;

		// Token: 0x040159E7 RID: 88551
		internal static int __PropertyOffset_28;

		// Token: 0x040159E8 RID: 88552
		internal static int __PropertyOffset_29;

		// Token: 0x040159E9 RID: 88553
		internal static int __PropertyOffset_30;

		// Token: 0x040159EA RID: 88554
		internal static int __PropertyOffset_31;

		// Token: 0x040159EB RID: 88555
		internal static int __PropertyOffset_32;

		// Token: 0x040159EC RID: 88556
		internal static int __PropertyOffset_33;

		// Token: 0x040159ED RID: 88557
		internal static int __PropertyOffset_34;

		// Token: 0x040159EE RID: 88558
		internal static int __PropertyOffset_35;

		// Token: 0x040159EF RID: 88559
		internal static int __PropertyOffset_36;

		// Token: 0x040159F0 RID: 88560
		internal static int __PropertyOffset_37;

		// Token: 0x040159F1 RID: 88561
		internal static int __PropertyOffset_38;

		// Token: 0x040159F2 RID: 88562
		internal static int __PropertyOffset_39;

		// Token: 0x040159F3 RID: 88563
		private static IntPtr __GetLensflareParameter_NativeFunctionPtr;

		// Token: 0x040159F4 RID: 88564
		private static IntPtr __GetCustomGlareParameter_NativeFunctionPtr;

		// Token: 0x040159F5 RID: 88565
		private static IntPtr __GetCustomHaloParameter_NativeFunctionPtr;

		// Token: 0x040159F6 RID: 88566
		private static IntPtr __GetCustomGhostParameter_NativeFunctionPtr;

		// Token: 0x040159F7 RID: 88567
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040159F8 RID: 88568
		private static IntPtr __ApplyDynamicMaterialGhost_NativeFunctionPtr;

		// Token: 0x040159F9 RID: 88569
		private static IntPtr __ApplyDynamicMaterialHalo_NativeFunctionPtr;

		// Token: 0x040159FA RID: 88570
		private static IntPtr __ApplyDynamicMaterialGlare_NativeFunctionPtr;

		// Token: 0x040159FB RID: 88571
		private static IntPtr __ExecuteUbergraph_BP_SceneLensflare_Motor_NativeFunctionPtr;

		// Token: 0x0200A155 RID: 41301
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __GetLensflareParameter_FunctionParams
		{
			// Token: 0x04032E8E RID: 208526
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A156 RID: 41302
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected new ref struct __GetCustomGlareParameter_FunctionParams
		{
			// Token: 0x04032E8F RID: 208527
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A157 RID: 41303
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected new ref struct __GetCustomHaloParameter_FunctionParams
		{
			// Token: 0x04032E90 RID: 208528
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A158 RID: 41304
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected new ref struct __GetCustomGhostParameter_FunctionParams
		{
			// Token: 0x04032E91 RID: 208529
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A159 RID: 41305
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialGhost_FunctionParams
		{
			// Token: 0x04032E92 RID: 208530
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x0200A15A RID: 41306
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialHalo_FunctionParams
		{
			// Token: 0x04032E93 RID: 208531
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x0200A15B RID: 41307
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ApplyDynamicMaterialGlare_FunctionParams
		{
			// Token: 0x04032E94 RID: 208532
			[FieldOffset(0)]
			public IntPtr DynMaterial;
		}

		// Token: 0x0200A15C RID: 41308
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_SceneLensflare_Motor_FunctionParams
		{
			// Token: 0x04032E95 RID: 208533
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
