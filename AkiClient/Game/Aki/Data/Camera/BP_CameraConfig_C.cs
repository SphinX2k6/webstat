using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Camera
{
	// Token: 0x02003F11 RID: 16145
	[UnrealObjectPath("/Game/Aki/Data/Camera/BP_CameraConfig.BP_CameraConfig_C")]
	[UnrealStructLayout(568, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 568)]
	public class BP_CameraConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602835F RID: 164703 RVA: 0x00A05500 File Offset: 0x00A03700
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CameraConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Camera/BP_CameraConfig.BP_CameraConfig_C");
			}
			return BP_CameraConfig_C._ClassPtr;
		}

		// Token: 0x06028360 RID: 164704 RVA: 0x00A05524 File Offset: 0x00A03724
		public BP_CameraConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_CameraConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028361 RID: 164705 RVA: 0x00A0554C File Offset: 0x00A0374C
		[NullableContext(1)]
		public BP_CameraConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CameraConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006110 RID: 24848
		// (get) Token: 0x06028362 RID: 164706 RVA: 0x00A0557F File Offset: 0x00A0377F
		// (set) Token: 0x06028363 RID: 164707 RVA: 0x00A0558F File Offset: 0x00A0378F
		public unsafe float 切换角色相机臂中心点过渡时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006111 RID: 24849
		// (get) Token: 0x06028364 RID: 164708 RVA: 0x00A055A0 File Offset: 0x00A037A0
		// (set) Token: 0x06028365 RID: 164709 RVA: 0x00A055B0 File Offset: 0x00A037B0
		public unsafe float 在水中摄像机碰撞检测起点额外高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006112 RID: 24850
		// (get) Token: 0x06028366 RID: 164710 RVA: 0x00A055C1 File Offset: 0x00A037C1
		// (set) Token: 0x06028367 RID: 164711 RVA: 0x00A055D1 File Offset: 0x00A037D1
		public unsafe float 障碍碰撞检测胶囊体半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006113 RID: 24851
		// (get) Token: 0x06028368 RID: 164712 RVA: 0x00A055E2 File Offset: 0x00A037E2
		// (set) Token: 0x06028369 RID: 164713 RVA: 0x00A055F2 File Offset: 0x00A037F2
		public unsafe float 自动俯仰角输入下界_目标高_高度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006114 RID: 24852
		// (get) Token: 0x0602836A RID: 164714 RVA: 0x00A05603 File Offset: 0x00A03803
		// (set) Token: 0x0602836B RID: 164715 RVA: 0x00A05613 File Offset: 0x00A03813
		public unsafe float 自动俯仰角输入上界_目标高_高度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006115 RID: 24853
		// (get) Token: 0x0602836C RID: 164716 RVA: 0x00A05624 File Offset: 0x00A03824
		// (set) Token: 0x0602836D RID: 164717 RVA: 0x00A05634 File Offset: 0x00A03834
		public unsafe float 自动俯仰角输入下界_目标高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006116 RID: 24854
		// (get) Token: 0x0602836E RID: 164718 RVA: 0x00A05645 File Offset: 0x00A03845
		// (set) Token: 0x0602836F RID: 164719 RVA: 0x00A05655 File Offset: 0x00A03855
		public unsafe float 自动俯仰角输入上界_目标高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006117 RID: 24855
		// (get) Token: 0x06028370 RID: 164720 RVA: 0x00A05666 File Offset: 0x00A03866
		// (set) Token: 0x06028371 RID: 164721 RVA: 0x00A05676 File Offset: 0x00A03876
		public unsafe float 自动俯仰角输出下界_目标高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17006118 RID: 24856
		// (get) Token: 0x06028372 RID: 164722 RVA: 0x00A05687 File Offset: 0x00A03887
		// (set) Token: 0x06028373 RID: 164723 RVA: 0x00A05697 File Offset: 0x00A03897
		public unsafe float 自动俯仰角输出上界_目标高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006119 RID: 24857
		// (get) Token: 0x06028374 RID: 164724 RVA: 0x00A056A8 File Offset: 0x00A038A8
		// (set) Token: 0x06028375 RID: 164725 RVA: 0x00A056B8 File Offset: 0x00A038B8
		public unsafe float 自动俯仰角输入下界_目标矮_高度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700611A RID: 24858
		// (get) Token: 0x06028376 RID: 164726 RVA: 0x00A056C9 File Offset: 0x00A038C9
		// (set) Token: 0x06028377 RID: 164727 RVA: 0x00A056D9 File Offset: 0x00A038D9
		public unsafe float 自动俯仰角输入上界_目标矮_高度差
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700611B RID: 24859
		// (get) Token: 0x06028378 RID: 164728 RVA: 0x00A056EA File Offset: 0x00A038EA
		// (set) Token: 0x06028379 RID: 164729 RVA: 0x00A056FA File Offset: 0x00A038FA
		public unsafe float 自动俯仰角输入下界_目标矮
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700611C RID: 24860
		// (get) Token: 0x0602837A RID: 164730 RVA: 0x00A0570B File Offset: 0x00A0390B
		// (set) Token: 0x0602837B RID: 164731 RVA: 0x00A0571B File Offset: 0x00A0391B
		public unsafe float 自动俯仰角输入上界_目标矮
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700611D RID: 24861
		// (get) Token: 0x0602837C RID: 164732 RVA: 0x00A0572C File Offset: 0x00A0392C
		// (set) Token: 0x0602837D RID: 164733 RVA: 0x00A0573C File Offset: 0x00A0393C
		public unsafe float 自动俯仰角输出下界_目标矮
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700611E RID: 24862
		// (get) Token: 0x0602837E RID: 164734 RVA: 0x00A0574D File Offset: 0x00A0394D
		// (set) Token: 0x0602837F RID: 164735 RVA: 0x00A0575D File Offset: 0x00A0395D
		public unsafe float 自动俯仰角输出上界_目标矮
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700611F RID: 24863
		// (get) Token: 0x06028380 RID: 164736 RVA: 0x00A0576E File Offset: 0x00A0396E
		// (set) Token: 0x06028381 RID: 164737 RVA: 0x00A0577E File Offset: 0x00A0397E
		public unsafe float 摄像机最小Pitch_目标比角色矮_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006120 RID: 24864
		// (get) Token: 0x06028382 RID: 164738 RVA: 0x00A0578F File Offset: 0x00A0398F
		// (set) Token: 0x06028383 RID: 164739 RVA: 0x00A0579F File Offset: 0x00A0399F
		public unsafe float 摄像机最大Pitch_目标比角色矮_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17006121 RID: 24865
		// (get) Token: 0x06028384 RID: 164740 RVA: 0x00A057B0 File Offset: 0x00A039B0
		// (set) Token: 0x06028385 RID: 164741 RVA: 0x00A057C0 File Offset: 0x00A039C0
		public unsafe float 摄像机最小Pitch_目标比角色高_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006122 RID: 24866
		// (get) Token: 0x06028386 RID: 164742 RVA: 0x00A057D1 File Offset: 0x00A039D1
		// (set) Token: 0x06028387 RID: 164743 RVA: 0x00A057E1 File Offset: 0x00A039E1
		public unsafe float 摄像机最大Pitch_目标比角色高_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17006123 RID: 24867
		// (get) Token: 0x06028388 RID: 164744 RVA: 0x00A057F2 File Offset: 0x00A039F2
		// (set) Token: 0x06028389 RID: 164745 RVA: 0x00A05802 File Offset: 0x00A03A02
		public unsafe float 近距离范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17006124 RID: 24868
		// (get) Token: 0x0602838A RID: 164746 RVA: 0x00A05813 File Offset: 0x00A03A13
		// (set) Token: 0x0602838B RID: 164747 RVA: 0x00A05823 File Offset: 0x00A03A23
		public unsafe float 近距离修正最小角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17006125 RID: 24869
		// (get) Token: 0x0602838C RID: 164748 RVA: 0x00A05834 File Offset: 0x00A03A34
		// (set) Token: 0x0602838D RID: 164749 RVA: 0x00A05844 File Offset: 0x00A03A44
		public unsafe float 近距离修正最大角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17006126 RID: 24870
		// (get) Token: 0x0602838E RID: 164750 RVA: 0x00A05855 File Offset: 0x00A03A55
		// (set) Token: 0x0602838F RID: 164751 RVA: 0x00A05865 File Offset: 0x00A03A65
		public unsafe float 远距离修正最小角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17006127 RID: 24871
		// (get) Token: 0x06028390 RID: 164752 RVA: 0x00A05876 File Offset: 0x00A03A76
		// (set) Token: 0x06028391 RID: 164753 RVA: 0x00A05886 File Offset: 0x00A03A86
		public unsafe float 远距离修正最大角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17006128 RID: 24872
		// (get) Token: 0x06028392 RID: 164754 RVA: 0x00A05897 File Offset: 0x00A03A97
		// (set) Token: 0x06028393 RID: 164755 RVA: 0x00A058A7 File Offset: 0x00A03AA7
		public unsafe float 检测屏幕内MinX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17006129 RID: 24873
		// (get) Token: 0x06028394 RID: 164756 RVA: 0x00A058B8 File Offset: 0x00A03AB8
		// (set) Token: 0x06028395 RID: 164757 RVA: 0x00A058C8 File Offset: 0x00A03AC8
		public unsafe float 检测屏幕内MaxX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700612A RID: 24874
		// (get) Token: 0x06028396 RID: 164758 RVA: 0x00A058D9 File Offset: 0x00A03AD9
		// (set) Token: 0x06028397 RID: 164759 RVA: 0x00A058E9 File Offset: 0x00A03AE9
		public unsafe float 检测屏幕内MinY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700612B RID: 24875
		// (get) Token: 0x06028398 RID: 164760 RVA: 0x00A058FA File Offset: 0x00A03AFA
		// (set) Token: 0x06028399 RID: 164761 RVA: 0x00A0590A File Offset: 0x00A03B0A
		public unsafe float 检测屏幕内MaxY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700612C RID: 24876
		// (get) Token: 0x0602839A RID: 164762 RVA: 0x00A0591B File Offset: 0x00A03B1B
		// (set) Token: 0x0602839B RID: 164763 RVA: 0x00A0592B File Offset: 0x00A03B2B
		public unsafe float 目标比角色更靠近镜头时额外臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700612D RID: 24877
		// (get) Token: 0x0602839C RID: 164764 RVA: 0x00A0593C File Offset: 0x00A03B3C
		// (set) Token: 0x0602839D RID: 164765 RVA: 0x00A0594C File Offset: 0x00A03B4C
		public unsafe float 额外臂长系数_目标距离_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700612E RID: 24878
		// (get) Token: 0x0602839E RID: 164766 RVA: 0x00A0595D File Offset: 0x00A03B5D
		// (set) Token: 0x0602839F RID: 164767 RVA: 0x00A0596D File Offset: 0x00A03B6D
		public unsafe float 额外臂长系数_目标高度差_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700612F RID: 24879
		// (get) Token: 0x060283A0 RID: 164768 RVA: 0x00A0597E File Offset: 0x00A03B7E
		// (set) Token: 0x060283A1 RID: 164769 RVA: 0x00A0598E File Offset: 0x00A03B8E
		public unsafe float 额外臂水平偏移_目标距离_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17006130 RID: 24880
		// (get) Token: 0x060283A2 RID: 164770 RVA: 0x00A0599F File Offset: 0x00A03B9F
		// (set) Token: 0x060283A3 RID: 164771 RVA: 0x00A059AF File Offset: 0x00A03BAF
		public unsafe float 额外最大水平臂偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17006131 RID: 24881
		// (get) Token: 0x060283A4 RID: 164772 RVA: 0x00A059C0 File Offset: 0x00A03BC0
		// (set) Token: 0x060283A5 RID: 164773 RVA: 0x00A059D0 File Offset: 0x00A03BD0
		public unsafe float 角色屏幕高度参考
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17006132 RID: 24882
		// (get) Token: 0x060283A6 RID: 164774 RVA: 0x00A059E1 File Offset: 0x00A03BE1
		// (set) Token: 0x060283A7 RID: 164775 RVA: 0x00A059F1 File Offset: 0x00A03BF1
		public unsafe float 额外臂垂直偏移系数_角色屏幕高度与参考值差_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17006133 RID: 24883
		// (get) Token: 0x060283A8 RID: 164776 RVA: 0x00A05A02 File Offset: 0x00A03C02
		// (set) Token: 0x060283A9 RID: 164777 RVA: 0x00A05A12 File Offset: 0x00A03C12
		public unsafe float 额外臂垂直偏移速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17006134 RID: 24884
		// (get) Token: 0x060283AA RID: 164778 RVA: 0x00A05A23 File Offset: 0x00A03C23
		// (set) Token: 0x060283AB RID: 164779 RVA: 0x00A05A33 File Offset: 0x00A03C33
		public unsafe float 额外臂垂直偏移系数_目标高度差_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17006135 RID: 24885
		// (get) Token: 0x060283AC RID: 164780 RVA: 0x00A05A44 File Offset: 0x00A03C44
		// (set) Token: 0x060283AD RID: 164781 RVA: 0x00A05A54 File Offset: 0x00A03C54
		public unsafe float 额外最大垂直臂偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17006136 RID: 24886
		// (get) Token: 0x060283AE RID: 164782 RVA: 0x00A05A65 File Offset: 0x00A03C65
		// (set) Token: 0x060283AF RID: 164783 RVA: 0x00A05A75 File Offset: 0x00A03C75
		public unsafe float 臂长过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17006137 RID: 24887
		// (get) Token: 0x060283B0 RID: 164784 RVA: 0x00A05A86 File Offset: 0x00A03C86
		// (set) Token: 0x060283B1 RID: 164785 RVA: 0x00A05A96 File Offset: 0x00A03C96
		public unsafe float 臂偏移过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17006138 RID: 24888
		// (get) Token: 0x060283B2 RID: 164786 RVA: 0x00A05AA7 File Offset: 0x00A03CA7
		// (set) Token: 0x060283B3 RID: 164787 RVA: 0x00A05AB7 File Offset: 0x00A03CB7
		public unsafe float 检测屏幕内MinX_外_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17006139 RID: 24889
		// (get) Token: 0x060283B4 RID: 164788 RVA: 0x00A05AC8 File Offset: 0x00A03CC8
		// (set) Token: 0x060283B5 RID: 164789 RVA: 0x00A05AD8 File Offset: 0x00A03CD8
		public unsafe float 检测屏幕内MaxX_外_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700613A RID: 24890
		// (get) Token: 0x060283B6 RID: 164790 RVA: 0x00A05AE9 File Offset: 0x00A03CE9
		// (set) Token: 0x060283B7 RID: 164791 RVA: 0x00A05AF9 File Offset: 0x00A03CF9
		public unsafe float 检测屏幕内MinY_外_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700613B RID: 24891
		// (get) Token: 0x060283B8 RID: 164792 RVA: 0x00A05B0A File Offset: 0x00A03D0A
		// (set) Token: 0x060283B9 RID: 164793 RVA: 0x00A05B1A File Offset: 0x00A03D1A
		public unsafe float 检测屏幕内MaxY_外_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x1700613C RID: 24892
		// (get) Token: 0x060283BA RID: 164794 RVA: 0x00A05B2B File Offset: 0x00A03D2B
		// (set) Token: 0x060283BB RID: 164795 RVA: 0x00A05B3B File Offset: 0x00A03D3B
		public unsafe float 臂旋转过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x1700613D RID: 24893
		// (get) Token: 0x060283BC RID: 164796 RVA: 0x00A05B4C File Offset: 0x00A03D4C
		// (set) Token: 0x060283BD RID: 164797 RVA: 0x00A05B5C File Offset: 0x00A03D5C
		public unsafe float 滚轮轴影响臂长系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x1700613E RID: 24894
		// (get) Token: 0x060283BE RID: 164798 RVA: 0x00A05B6D File Offset: 0x00A03D6D
		// (set) Token: 0x060283BF RID: 164799 RVA: 0x00A05B7D File Offset: 0x00A03D7D
		public unsafe float 臂长还原过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x1700613F RID: 24895
		// (get) Token: 0x060283C0 RID: 164800 RVA: 0x00A05B8E File Offset: 0x00A03D8E
		// (set) Token: 0x060283C1 RID: 164801 RVA: 0x00A05B9E File Offset: 0x00A03D9E
		public unsafe float 臂偏移还原过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17006140 RID: 24896
		// (get) Token: 0x060283C2 RID: 164802 RVA: 0x00A05BAF File Offset: 0x00A03DAF
		// (set) Token: 0x060283C3 RID: 164803 RVA: 0x00A05BBF File Offset: 0x00A03DBF
		public unsafe float 旋转还原过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17006141 RID: 24897
		// (get) Token: 0x060283C4 RID: 164804 RVA: 0x00A05BD0 File Offset: 0x00A03DD0
		// (set) Token: 0x060283C5 RID: 164805 RVA: 0x00A05BE0 File Offset: 0x00A03DE0
		public unsafe float Fov还原过渡速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17006142 RID: 24898
		// (get) Token: 0x060283C6 RID: 164806 RVA: 0x00A05BF1 File Offset: 0x00A03DF1
		// (set) Token: 0x060283C7 RID: 164807 RVA: 0x00A05C01 File Offset: 0x00A03E01
		public unsafe float 技能修正过渡时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17006143 RID: 24899
		// (get) Token: 0x060283C8 RID: 164808 RVA: 0x00A05C12 File Offset: 0x00A03E12
		// (set) Token: 0x060283C9 RID: 164809 RVA: 0x00A05C22 File Offset: 0x00A03E22
		public unsafe float G修正角度Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17006144 RID: 24900
		// (get) Token: 0x060283CA RID: 164810 RVA: 0x00A05C33 File Offset: 0x00A03E33
		// (set) Token: 0x060283CB RID: 164811 RVA: 0x00A05C43 File Offset: 0x00A03E43
		public unsafe float G修正角度Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17006145 RID: 24901
		// (get) Token: 0x060283CC RID: 164812 RVA: 0x00A05C54 File Offset: 0x00A03E54
		// (set) Token: 0x060283CD RID: 164813 RVA: 0x00A05C64 File Offset: 0x00A03E64
		public unsafe float G额外臂长系数_目标水平距离_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17006146 RID: 24902
		// (get) Token: 0x060283CE RID: 164814 RVA: 0x00A05C75 File Offset: 0x00A03E75
		// (set) Token: 0x060283CF RID: 164815 RVA: 0x00A05C85 File Offset: 0x00A03E85
		public unsafe float G额外臂长系数_目标高度差_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17006147 RID: 24903
		// (get) Token: 0x060283D0 RID: 164816 RVA: 0x00A05C96 File Offset: 0x00A03E96
		// (set) Token: 0x060283D1 RID: 164817 RVA: 0x00A05CA6 File Offset: 0x00A03EA6
		public unsafe float G额外臂长限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17006148 RID: 24904
		// (get) Token: 0x060283D2 RID: 164818 RVA: 0x00A05CB7 File Offset: 0x00A03EB7
		// (set) Token: 0x060283D3 RID: 164819 RVA: 0x00A05CC7 File Offset: 0x00A03EC7
		public unsafe float G额外臂水平偏移系数_目标水平距离_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17006149 RID: 24905
		// (get) Token: 0x060283D4 RID: 164820 RVA: 0x00A05CD8 File Offset: 0x00A03ED8
		// (set) Token: 0x060283D5 RID: 164821 RVA: 0x00A05CE8 File Offset: 0x00A03EE8
		public unsafe float G额外臂水平偏移上限
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x1700614A RID: 24906
		// (get) Token: 0x060283D6 RID: 164822 RVA: 0x00A05CF9 File Offset: 0x00A03EF9
		// (set) Token: 0x060283D7 RID: 164823 RVA: 0x00A05D09 File Offset: 0x00A03F09
		public unsafe float G额外臂垂直偏移系数_目标高度差_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x1700614B RID: 24907
		// (get) Token: 0x060283D8 RID: 164824 RVA: 0x00A05D1A File Offset: 0x00A03F1A
		// (set) Token: 0x060283D9 RID: 164825 RVA: 0x00A05D2A File Offset: 0x00A03F2A
		public unsafe float G额外臂垂直偏移上限
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x1700614C RID: 24908
		// (get) Token: 0x060283DA RID: 164826 RVA: 0x00A05D3B File Offset: 0x00A03F3B
		// (set) Token: 0x060283DB RID: 164827 RVA: 0x00A05D4B File Offset: 0x00A03F4B
		public unsafe float GInRangeMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x1700614D RID: 24909
		// (get) Token: 0x060283DC RID: 164828 RVA: 0x00A05D5C File Offset: 0x00A03F5C
		// (set) Token: 0x060283DD RID: 164829 RVA: 0x00A05D6C File Offset: 0x00A03F6C
		public unsafe float GInRangeMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x1700614E RID: 24910
		// (get) Token: 0x060283DE RID: 164830 RVA: 0x00A05D7D File Offset: 0x00A03F7D
		// (set) Token: 0x060283DF RID: 164831 RVA: 0x00A05D8D File Offset: 0x00A03F8D
		public unsafe float GOutRangeMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x1700614F RID: 24911
		// (get) Token: 0x060283E0 RID: 164832 RVA: 0x00A05D9E File Offset: 0x00A03F9E
		// (set) Token: 0x060283E1 RID: 164833 RVA: 0x00A05DAE File Offset: 0x00A03FAE
		public unsafe float GOutRangeMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x17006150 RID: 24912
		// (get) Token: 0x060283E2 RID: 164834 RVA: 0x00A05DBF File Offset: 0x00A03FBF
		// (set) Token: 0x060283E3 RID: 164835 RVA: 0x00A05DCF File Offset: 0x00A03FCF
		public unsafe float GCameraPitchMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x17006151 RID: 24913
		// (get) Token: 0x060283E4 RID: 164836 RVA: 0x00A05DE0 File Offset: 0x00A03FE0
		// (set) Token: 0x060283E5 RID: 164837 RVA: 0x00A05DF0 File Offset: 0x00A03FF0
		public unsafe float GCameraPitchMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x17006152 RID: 24914
		// (get) Token: 0x060283E6 RID: 164838 RVA: 0x00A05E01 File Offset: 0x00A04001
		// (set) Token: 0x060283E7 RID: 164839 RVA: 0x00A05E11 File Offset: 0x00A04011
		public unsafe float GCameraPitchOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17006153 RID: 24915
		// (get) Token: 0x060283E8 RID: 164840 RVA: 0x00A05E22 File Offset: 0x00A04022
		// (set) Token: 0x060283E9 RID: 164841 RVA: 0x00A05E32 File Offset: 0x00A04032
		public unsafe float GNearerRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17006154 RID: 24916
		// (get) Token: 0x060283EA RID: 164842 RVA: 0x00A05E43 File Offset: 0x00A04043
		// (set) Token: 0x060283EB RID: 164843 RVA: 0x00A05E53 File Offset: 0x00A04053
		public unsafe float E修正角度Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17006155 RID: 24917
		// (get) Token: 0x060283EC RID: 164844 RVA: 0x00A05E64 File Offset: 0x00A04064
		// (set) Token: 0x060283ED RID: 164845 RVA: 0x00A05E74 File Offset: 0x00A04074
		public unsafe float E修正角度Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17006156 RID: 24918
		// (get) Token: 0x060283EE RID: 164846 RVA: 0x00A05E85 File Offset: 0x00A04085
		// (set) Token: 0x060283EF RID: 164847 RVA: 0x00A05E95 File Offset: 0x00A04095
		public unsafe float EInRangeMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x17006157 RID: 24919
		// (get) Token: 0x060283F0 RID: 164848 RVA: 0x00A05EA6 File Offset: 0x00A040A6
		// (set) Token: 0x060283F1 RID: 164849 RVA: 0x00A05EB6 File Offset: 0x00A040B6
		public unsafe float EInRangeMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x17006158 RID: 24920
		// (get) Token: 0x060283F2 RID: 164850 RVA: 0x00A05EC7 File Offset: 0x00A040C7
		// (set) Token: 0x060283F3 RID: 164851 RVA: 0x00A05ED7 File Offset: 0x00A040D7
		public unsafe float EOutRangeMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x17006159 RID: 24921
		// (get) Token: 0x060283F4 RID: 164852 RVA: 0x00A05EE8 File Offset: 0x00A040E8
		// (set) Token: 0x060283F5 RID: 164853 RVA: 0x00A05EF8 File Offset: 0x00A040F8
		public unsafe float EOutRangeMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x1700615A RID: 24922
		// (get) Token: 0x060283F6 RID: 164854 RVA: 0x00A05F09 File Offset: 0x00A04109
		// (set) Token: 0x060283F7 RID: 164855 RVA: 0x00A05F19 File Offset: 0x00A04119
		public unsafe float E摄像机合法角度_移动方向_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x1700615B RID: 24923
		// (get) Token: 0x060283F8 RID: 164856 RVA: 0x00A05F2A File Offset: 0x00A0412A
		// (set) Token: 0x060283F9 RID: 164857 RVA: 0x00A05F3A File Offset: 0x00A0413A
		public unsafe float E移动方向合法角度_看向点方向_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x1700615C RID: 24924
		// (get) Token: 0x060283FA RID: 164858 RVA: 0x00A05F4B File Offset: 0x00A0414B
		// (set) Token: 0x060283FB RID: 164859 RVA: 0x00A05F5B File Offset: 0x00A0415B
		public unsafe float D淡入系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x1700615D RID: 24925
		// (get) Token: 0x060283FC RID: 164860 RVA: 0x00A05F6C File Offset: 0x00A0416C
		// (set) Token: 0x060283FD RID: 164861 RVA: 0x00A05F7C File Offset: 0x00A0417C
		public unsafe float D淡入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x1700615E RID: 24926
		// (get) Token: 0x060283FE RID: 164862 RVA: 0x00A05F8D File Offset: 0x00A0418D
		// (set) Token: 0x060283FF RID: 164863 RVA: 0x00A05F9D File Offset: 0x00A0419D
		public unsafe float D淡出速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x1700615F RID: 24927
		// (get) Token: 0x06028400 RID: 164864 RVA: 0x00A05FAE File Offset: 0x00A041AE
		// (set) Token: 0x06028401 RID: 164865 RVA: 0x00A05FBE File Offset: 0x00A041BE
		public unsafe float D检查旋转角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_79);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_79) = value;
			}
		}

		// Token: 0x17006160 RID: 24928
		// (get) Token: 0x06028402 RID: 164866 RVA: 0x00A05FCF File Offset: 0x00A041CF
		// (set) Token: 0x06028403 RID: 164867 RVA: 0x00A05FDF File Offset: 0x00A041DF
		public unsafe float D检查最小俯仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_80);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_80) = value;
			}
		}

		// Token: 0x17006161 RID: 24929
		// (get) Token: 0x06028404 RID: 164868 RVA: 0x00A05FF0 File Offset: 0x00A041F0
		// (set) Token: 0x06028405 RID: 164869 RVA: 0x00A06000 File Offset: 0x00A04200
		public unsafe float D检查最大俯仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_81);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_81) = value;
			}
		}

		// Token: 0x17006162 RID: 24930
		// (get) Token: 0x06028406 RID: 164870 RVA: 0x00A06011 File Offset: 0x00A04211
		// (set) Token: 0x06028407 RID: 164871 RVA: 0x00A06021 File Offset: 0x00A04221
		public unsafe float D调整旋转角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_82);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_82) = value;
			}
		}

		// Token: 0x17006163 RID: 24931
		// (get) Token: 0x06028408 RID: 164872 RVA: 0x00A06032 File Offset: 0x00A04232
		// (set) Token: 0x06028409 RID: 164873 RVA: 0x00A06042 File Offset: 0x00A04242
		public unsafe float D调整最小俯仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_83);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_83) = value;
			}
		}

		// Token: 0x17006164 RID: 24932
		// (get) Token: 0x0602840A RID: 164874 RVA: 0x00A06053 File Offset: 0x00A04253
		// (set) Token: 0x0602840B RID: 164875 RVA: 0x00A06063 File Offset: 0x00A04263
		public unsafe float D调整最大俯仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x17006165 RID: 24933
		// (get) Token: 0x0602840C RID: 164876 RVA: 0x00A06074 File Offset: 0x00A04274
		// (set) Token: 0x0602840D RID: 164877 RVA: 0x00A06084 File Offset: 0x00A04284
		public unsafe float D中心点偏移比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_85);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x17006166 RID: 24934
		// (get) Token: 0x0602840E RID: 164878 RVA: 0x00A06095 File Offset: 0x00A04295
		// (set) Token: 0x0602840F RID: 164879 RVA: 0x00A060A5 File Offset: 0x00A042A5
		public unsafe float D中心点最大偏移距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_86);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_86) = value;
			}
		}

		// Token: 0x17006167 RID: 24935
		// (get) Token: 0x06028410 RID: 164880 RVA: 0x00A060B6 File Offset: 0x00A042B6
		// (set) Token: 0x06028411 RID: 164881 RVA: 0x00A060C6 File Offset: 0x00A042C6
		public unsafe float 最小上浮臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_87);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_87) = value;
			}
		}

		// Token: 0x17006168 RID: 24936
		// (get) Token: 0x06028412 RID: 164882 RVA: 0x00A060D7 File Offset: 0x00A042D7
		// (set) Token: 0x06028413 RID: 164883 RVA: 0x00A060E7 File Offset: 0x00A042E7
		public unsafe float 最大上浮臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_88);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_88) = value;
			}
		}

		// Token: 0x17006169 RID: 24937
		// (get) Token: 0x06028414 RID: 164884 RVA: 0x00A060F8 File Offset: 0x00A042F8
		// (set) Token: 0x06028415 RID: 164885 RVA: 0x00A06108 File Offset: 0x00A04308
		public unsafe float C退出攀爬淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_89);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_89) = value;
			}
		}

		// Token: 0x1700616A RID: 24938
		// (get) Token: 0x06028416 RID: 164886 RVA: 0x00A06119 File Offset: 0x00A04319
		// (set) Token: 0x06028417 RID: 164887 RVA: 0x00A06129 File Offset: 0x00A04329
		public unsafe float C无操作等待时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_90);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_90) = value;
			}
		}

		// Token: 0x1700616B RID: 24939
		// (get) Token: 0x06028418 RID: 164888 RVA: 0x00A0613A File Offset: 0x00A0433A
		// (set) Token: 0x06028419 RID: 164889 RVA: 0x00A0614A File Offset: 0x00A0434A
		public unsafe float C持续移动进入修正时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_91);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_91) = value;
			}
		}

		// Token: 0x1700616C RID: 24940
		// (get) Token: 0x0602841A RID: 164890 RVA: 0x00A0615B File Offset: 0x00A0435B
		// (set) Token: 0x0602841B RID: 164891 RVA: 0x00A0616B File Offset: 0x00A0436B
		public unsafe float C镜头角度插值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x1700616D RID: 24941
		// (get) Token: 0x0602841C RID: 164892 RVA: 0x00A0617C File Offset: 0x00A0437C
		// (set) Token: 0x0602841D RID: 164893 RVA: 0x00A0618C File Offset: 0x00A0438C
		public unsafe float C角色移动基准速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x1700616E RID: 24942
		// (get) Token: 0x0602841E RID: 164894 RVA: 0x00A0619D File Offset: 0x00A0439D
		// (set) Token: 0x0602841F RID: 164895 RVA: 0x00A061AD File Offset: 0x00A043AD
		public unsafe float C进入攀爬增加臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x1700616F RID: 24943
		// (get) Token: 0x06028420 RID: 164896 RVA: 0x00A061BE File Offset: 0x00A043BE
		// (set) Token: 0x06028421 RID: 164897 RVA: 0x00A061CE File Offset: 0x00A043CE
		public unsafe float C进入攀爬修正时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x17006170 RID: 24944
		// (get) Token: 0x06028422 RID: 164898 RVA: 0x00A061DF File Offset: 0x00A043DF
		// (set) Token: 0x06028423 RID: 164899 RVA: 0x00A061EF File Offset: 0x00A043EF
		public unsafe float C进入攀爬淡出系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x17006171 RID: 24945
		// (get) Token: 0x06028424 RID: 164900 RVA: 0x00A06200 File Offset: 0x00A04400
		// (set) Token: 0x06028425 RID: 164901 RVA: 0x00A06210 File Offset: 0x00A04410
		public unsafe float C攀爬基准臂长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_97);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_97) = value;
			}
		}

		// Token: 0x17006172 RID: 24946
		// (get) Token: 0x06028426 RID: 164902 RVA: 0x00A06221 File Offset: 0x00A04421
		// (set) Token: 0x06028427 RID: 164903 RVA: 0x00A06231 File Offset: 0x00A04431
		public unsafe float C臂长插值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_98);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_98) = value;
			}
		}

		// Token: 0x17006173 RID: 24947
		// (get) Token: 0x06028428 RID: 164904 RVA: 0x00A06242 File Offset: 0x00A04442
		// (set) Token: 0x06028429 RID: 164905 RVA: 0x00A06252 File Offset: 0x00A04452
		public unsafe float C镜头预期朝向与角色移动方向夹角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_99);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_99) = value;
			}
		}

		// Token: 0x17006174 RID: 24948
		// (get) Token: 0x0602842A RID: 164906 RVA: 0x00A06263 File Offset: 0x00A04463
		// (set) Token: 0x0602842B RID: 164907 RVA: 0x00A06273 File Offset: 0x00A04473
		public unsafe float C镜头预期朝向俯视角压缩倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x17006175 RID: 24949
		// (get) Token: 0x0602842C RID: 164908 RVA: 0x00A06284 File Offset: 0x00A04484
		// (set) Token: 0x0602842D RID: 164909 RVA: 0x00A06294 File Offset: 0x00A04494
		public unsafe float C镜头预期朝向仰视角压缩倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x17006176 RID: 24950
		// (get) Token: 0x0602842E RID: 164910 RVA: 0x00A062A5 File Offset: 0x00A044A5
		// (set) Token: 0x0602842F RID: 164911 RVA: 0x00A062B5 File Offset: 0x00A044B5
		public unsafe float S旋转角速度插值速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17006177 RID: 24951
		// (get) Token: 0x06028430 RID: 164912 RVA: 0x00A062C6 File Offset: 0x00A044C6
		// (set) Token: 0x06028431 RID: 164913 RVA: 0x00A062D6 File Offset: 0x00A044D6
		public unsafe float C镜头预期朝向和角色面朝方向夹角合法范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_103);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x17006178 RID: 24952
		// (get) Token: 0x06028432 RID: 164914 RVA: 0x00A062E7 File Offset: 0x00A044E7
		// (set) Token: 0x06028433 RID: 164915 RVA: 0x00A062F7 File Offset: 0x00A044F7
		public unsafe float C输入粘滞时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17006179 RID: 24953
		// (get) Token: 0x06028434 RID: 164916 RVA: 0x00A06308 File Offset: 0x00A04508
		// (set) Token: 0x06028435 RID: 164917 RVA: 0x00A06318 File Offset: 0x00A04518
		public unsafe float S俯仰角插值速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_105);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_105) = value;
			}
		}

		// Token: 0x1700617A RID: 24954
		// (get) Token: 0x06028436 RID: 164918 RVA: 0x00A06329 File Offset: 0x00A04529
		// (set) Token: 0x06028437 RID: 164919 RVA: 0x00A06339 File Offset: 0x00A04539
		public unsafe float S相机俯角偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_106);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_106) = value;
			}
		}

		// Token: 0x1700617B RID: 24955
		// (get) Token: 0x06028438 RID: 164920 RVA: 0x00A0634A File Offset: 0x00A0454A
		// (set) Token: 0x06028439 RID: 164921 RVA: 0x00A0635A File Offset: 0x00A0455A
		public unsafe float S最大俯角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_107);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_107) = value;
			}
		}

		// Token: 0x1700617C RID: 24956
		// (get) Token: 0x0602843A RID: 164922 RVA: 0x00A0636B File Offset: 0x00A0456B
		// (set) Token: 0x0602843B RID: 164923 RVA: 0x00A0637B File Offset: 0x00A0457B
		public unsafe float S最大仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_108);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_108) = value;
			}
		}

		// Token: 0x1700617D RID: 24957
		// (get) Token: 0x0602843C RID: 164924 RVA: 0x00A0638C File Offset: 0x00A0458C
		// (set) Token: 0x0602843D RID: 164925 RVA: 0x00A0639C File Offset: 0x00A0459C
		public unsafe float S俯仰修正时间阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_109);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_109) = value;
			}
		}

		// Token: 0x1700617E RID: 24958
		// (get) Token: 0x0602843E RID: 164926 RVA: 0x00A063AD File Offset: 0x00A045AD
		// (set) Token: 0x0602843F RID: 164927 RVA: 0x00A063BD File Offset: 0x00A045BD
		public unsafe float 弹簧臂中心点垂直插值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_110);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_110) = value;
			}
		}

		// Token: 0x1700617F RID: 24959
		// (get) Token: 0x06028440 RID: 164928 RVA: 0x00A063CE File Offset: 0x00A045CE
		// (set) Token: 0x06028441 RID: 164929 RVA: 0x00A063DE File Offset: 0x00A045DE
		public unsafe float 弹簧臂中心点垂直偏移距离上限
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_111);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_111) = value;
			}
		}

		// Token: 0x17006180 RID: 24960
		// (get) Token: 0x06028442 RID: 164930 RVA: 0x00A063EF File Offset: 0x00A045EF
		// (set) Token: 0x06028443 RID: 164931 RVA: 0x00A063FF File Offset: 0x00A045FF
		public unsafe float 弹簧臂中心点水平插值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_112);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_112) = value;
			}
		}

		// Token: 0x17006181 RID: 24961
		// (get) Token: 0x06028444 RID: 164932 RVA: 0x00A06410 File Offset: 0x00A04610
		// (set) Token: 0x06028445 RID: 164933 RVA: 0x00A06420 File Offset: 0x00A04620
		public unsafe float 弹簧臂中心点水平偏移距离上限
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_113);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_113) = value;
			}
		}

		// Token: 0x17006182 RID: 24962
		// (get) Token: 0x06028446 RID: 164934 RVA: 0x00A06431 File Offset: 0x00A04631
		// (set) Token: 0x06028447 RID: 164935 RVA: 0x00A06441 File Offset: 0x00A04641
		public unsafe float S俯仰角加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_114);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_114) = value;
			}
		}

		// Token: 0x17006183 RID: 24963
		// (get) Token: 0x06028448 RID: 164936 RVA: 0x00A06452 File Offset: 0x00A04652
		// (set) Token: 0x06028449 RID: 164937 RVA: 0x00A06462 File Offset: 0x00A04662
		public unsafe float C登顶镜头插值速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_115);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_115) = value;
			}
		}

		// Token: 0x17006184 RID: 24964
		// (get) Token: 0x0602844A RID: 164938 RVA: 0x00A06473 File Offset: 0x00A04673
		// (set) Token: 0x0602844B RID: 164939 RVA: 0x00A06483 File Offset: 0x00A04683
		public unsafe float C登顶镜头预期Pitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_116);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_116) = value;
			}
		}

		// Token: 0x17006185 RID: 24965
		// (get) Token: 0x0602844C RID: 164940 RVA: 0x00A06494 File Offset: 0x00A04694
		// (set) Token: 0x0602844D RID: 164941 RVA: 0x00A064A4 File Offset: 0x00A046A4
		public unsafe float 镜头输入缓冲系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_117);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_117) = value;
			}
		}

		// Token: 0x17006186 RID: 24966
		// (get) Token: 0x0602844E RID: 164942 RVA: 0x00A064B5 File Offset: 0x00A046B5
		// (set) Token: 0x0602844F RID: 164943 RVA: 0x00A064C5 File Offset: 0x00A046C5
		public unsafe float 镜头基准灵敏度Yaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_118);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_118) = value;
			}
		}

		// Token: 0x17006187 RID: 24967
		// (get) Token: 0x06028450 RID: 164944 RVA: 0x00A064D6 File Offset: 0x00A046D6
		// (set) Token: 0x06028451 RID: 164945 RVA: 0x00A064E6 File Offset: 0x00A046E6
		public unsafe float 镜头基准灵敏度Pitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_119);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_119) = value;
			}
		}

		// Token: 0x17006188 RID: 24968
		// (get) Token: 0x06028452 RID: 164946 RVA: 0x00A064F7 File Offset: 0x00A046F7
		// (set) Token: 0x06028453 RID: 164947 RVA: 0x00A06507 File Offset: 0x00A04707
		public unsafe float 镜头输入速率Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_120);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_120) = value;
			}
		}

		// Token: 0x17006189 RID: 24969
		// (get) Token: 0x06028454 RID: 164948 RVA: 0x00A06518 File Offset: 0x00A04718
		// (set) Token: 0x06028455 RID: 164949 RVA: 0x00A06528 File Offset: 0x00A04728
		public unsafe float 镜头输入速率Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_121);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraConfig_C.__PropertyOffset_121) = value;
			}
		}

		// Token: 0x06028456 RID: 164950 RVA: 0x00A06539 File Offset: 0x00A04739
		protected BP_CameraConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401524E RID: 86606
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Camera/BP_CameraConfig.BP_CameraConfig_C";

		// Token: 0x0401524F RID: 86607
		private static IntPtr _ClassPtr;

		// Token: 0x04015250 RID: 86608
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015251 RID: 86609
		internal static int __PropertyOffset_0;

		// Token: 0x04015252 RID: 86610
		internal static int __PropertyOffset_1;

		// Token: 0x04015253 RID: 86611
		internal static int __PropertyOffset_2;

		// Token: 0x04015254 RID: 86612
		internal static int __PropertyOffset_3;

		// Token: 0x04015255 RID: 86613
		internal static int __PropertyOffset_4;

		// Token: 0x04015256 RID: 86614
		internal static int __PropertyOffset_5;

		// Token: 0x04015257 RID: 86615
		internal static int __PropertyOffset_6;

		// Token: 0x04015258 RID: 86616
		internal static int __PropertyOffset_7;

		// Token: 0x04015259 RID: 86617
		internal static int __PropertyOffset_8;

		// Token: 0x0401525A RID: 86618
		internal static int __PropertyOffset_9;

		// Token: 0x0401525B RID: 86619
		internal static int __PropertyOffset_10;

		// Token: 0x0401525C RID: 86620
		internal static int __PropertyOffset_11;

		// Token: 0x0401525D RID: 86621
		internal static int __PropertyOffset_12;

		// Token: 0x0401525E RID: 86622
		internal static int __PropertyOffset_13;

		// Token: 0x0401525F RID: 86623
		internal static int __PropertyOffset_14;

		// Token: 0x04015260 RID: 86624
		internal static int __PropertyOffset_15;

		// Token: 0x04015261 RID: 86625
		internal static int __PropertyOffset_16;

		// Token: 0x04015262 RID: 86626
		internal static int __PropertyOffset_17;

		// Token: 0x04015263 RID: 86627
		internal static int __PropertyOffset_18;

		// Token: 0x04015264 RID: 86628
		internal static int __PropertyOffset_19;

		// Token: 0x04015265 RID: 86629
		internal static int __PropertyOffset_20;

		// Token: 0x04015266 RID: 86630
		internal static int __PropertyOffset_21;

		// Token: 0x04015267 RID: 86631
		internal static int __PropertyOffset_22;

		// Token: 0x04015268 RID: 86632
		internal static int __PropertyOffset_23;

		// Token: 0x04015269 RID: 86633
		internal static int __PropertyOffset_24;

		// Token: 0x0401526A RID: 86634
		internal static int __PropertyOffset_25;

		// Token: 0x0401526B RID: 86635
		internal static int __PropertyOffset_26;

		// Token: 0x0401526C RID: 86636
		internal static int __PropertyOffset_27;

		// Token: 0x0401526D RID: 86637
		internal static int __PropertyOffset_28;

		// Token: 0x0401526E RID: 86638
		internal static int __PropertyOffset_29;

		// Token: 0x0401526F RID: 86639
		internal static int __PropertyOffset_30;

		// Token: 0x04015270 RID: 86640
		internal static int __PropertyOffset_31;

		// Token: 0x04015271 RID: 86641
		internal static int __PropertyOffset_32;

		// Token: 0x04015272 RID: 86642
		internal static int __PropertyOffset_33;

		// Token: 0x04015273 RID: 86643
		internal static int __PropertyOffset_34;

		// Token: 0x04015274 RID: 86644
		internal static int __PropertyOffset_35;

		// Token: 0x04015275 RID: 86645
		internal static int __PropertyOffset_36;

		// Token: 0x04015276 RID: 86646
		internal static int __PropertyOffset_37;

		// Token: 0x04015277 RID: 86647
		internal static int __PropertyOffset_38;

		// Token: 0x04015278 RID: 86648
		internal static int __PropertyOffset_39;

		// Token: 0x04015279 RID: 86649
		internal static int __PropertyOffset_40;

		// Token: 0x0401527A RID: 86650
		internal static int __PropertyOffset_41;

		// Token: 0x0401527B RID: 86651
		internal static int __PropertyOffset_42;

		// Token: 0x0401527C RID: 86652
		internal static int __PropertyOffset_43;

		// Token: 0x0401527D RID: 86653
		internal static int __PropertyOffset_44;

		// Token: 0x0401527E RID: 86654
		internal static int __PropertyOffset_45;

		// Token: 0x0401527F RID: 86655
		internal static int __PropertyOffset_46;

		// Token: 0x04015280 RID: 86656
		internal static int __PropertyOffset_47;

		// Token: 0x04015281 RID: 86657
		internal static int __PropertyOffset_48;

		// Token: 0x04015282 RID: 86658
		internal static int __PropertyOffset_49;

		// Token: 0x04015283 RID: 86659
		internal static int __PropertyOffset_50;

		// Token: 0x04015284 RID: 86660
		internal static int __PropertyOffset_51;

		// Token: 0x04015285 RID: 86661
		internal static int __PropertyOffset_52;

		// Token: 0x04015286 RID: 86662
		internal static int __PropertyOffset_53;

		// Token: 0x04015287 RID: 86663
		internal static int __PropertyOffset_54;

		// Token: 0x04015288 RID: 86664
		internal static int __PropertyOffset_55;

		// Token: 0x04015289 RID: 86665
		internal static int __PropertyOffset_56;

		// Token: 0x0401528A RID: 86666
		internal static int __PropertyOffset_57;

		// Token: 0x0401528B RID: 86667
		internal static int __PropertyOffset_58;

		// Token: 0x0401528C RID: 86668
		internal static int __PropertyOffset_59;

		// Token: 0x0401528D RID: 86669
		internal static int __PropertyOffset_60;

		// Token: 0x0401528E RID: 86670
		internal static int __PropertyOffset_61;

		// Token: 0x0401528F RID: 86671
		internal static int __PropertyOffset_62;

		// Token: 0x04015290 RID: 86672
		internal static int __PropertyOffset_63;

		// Token: 0x04015291 RID: 86673
		internal static int __PropertyOffset_64;

		// Token: 0x04015292 RID: 86674
		internal static int __PropertyOffset_65;

		// Token: 0x04015293 RID: 86675
		internal static int __PropertyOffset_66;

		// Token: 0x04015294 RID: 86676
		internal static int __PropertyOffset_67;

		// Token: 0x04015295 RID: 86677
		internal static int __PropertyOffset_68;

		// Token: 0x04015296 RID: 86678
		internal static int __PropertyOffset_69;

		// Token: 0x04015297 RID: 86679
		internal static int __PropertyOffset_70;

		// Token: 0x04015298 RID: 86680
		internal static int __PropertyOffset_71;

		// Token: 0x04015299 RID: 86681
		internal static int __PropertyOffset_72;

		// Token: 0x0401529A RID: 86682
		internal static int __PropertyOffset_73;

		// Token: 0x0401529B RID: 86683
		internal static int __PropertyOffset_74;

		// Token: 0x0401529C RID: 86684
		internal static int __PropertyOffset_75;

		// Token: 0x0401529D RID: 86685
		internal static int __PropertyOffset_76;

		// Token: 0x0401529E RID: 86686
		internal static int __PropertyOffset_77;

		// Token: 0x0401529F RID: 86687
		internal static int __PropertyOffset_78;

		// Token: 0x040152A0 RID: 86688
		internal static int __PropertyOffset_79;

		// Token: 0x040152A1 RID: 86689
		internal static int __PropertyOffset_80;

		// Token: 0x040152A2 RID: 86690
		internal static int __PropertyOffset_81;

		// Token: 0x040152A3 RID: 86691
		internal static int __PropertyOffset_82;

		// Token: 0x040152A4 RID: 86692
		internal static int __PropertyOffset_83;

		// Token: 0x040152A5 RID: 86693
		internal static int __PropertyOffset_84;

		// Token: 0x040152A6 RID: 86694
		internal static int __PropertyOffset_85;

		// Token: 0x040152A7 RID: 86695
		internal static int __PropertyOffset_86;

		// Token: 0x040152A8 RID: 86696
		internal static int __PropertyOffset_87;

		// Token: 0x040152A9 RID: 86697
		internal static int __PropertyOffset_88;

		// Token: 0x040152AA RID: 86698
		internal static int __PropertyOffset_89;

		// Token: 0x040152AB RID: 86699
		internal static int __PropertyOffset_90;

		// Token: 0x040152AC RID: 86700
		internal static int __PropertyOffset_91;

		// Token: 0x040152AD RID: 86701
		internal static int __PropertyOffset_92;

		// Token: 0x040152AE RID: 86702
		internal static int __PropertyOffset_93;

		// Token: 0x040152AF RID: 86703
		internal static int __PropertyOffset_94;

		// Token: 0x040152B0 RID: 86704
		internal static int __PropertyOffset_95;

		// Token: 0x040152B1 RID: 86705
		internal static int __PropertyOffset_96;

		// Token: 0x040152B2 RID: 86706
		internal static int __PropertyOffset_97;

		// Token: 0x040152B3 RID: 86707
		internal static int __PropertyOffset_98;

		// Token: 0x040152B4 RID: 86708
		internal static int __PropertyOffset_99;

		// Token: 0x040152B5 RID: 86709
		internal static int __PropertyOffset_100;

		// Token: 0x040152B6 RID: 86710
		internal static int __PropertyOffset_101;

		// Token: 0x040152B7 RID: 86711
		internal static int __PropertyOffset_102;

		// Token: 0x040152B8 RID: 86712
		internal static int __PropertyOffset_103;

		// Token: 0x040152B9 RID: 86713
		internal static int __PropertyOffset_104;

		// Token: 0x040152BA RID: 86714
		internal static int __PropertyOffset_105;

		// Token: 0x040152BB RID: 86715
		internal static int __PropertyOffset_106;

		// Token: 0x040152BC RID: 86716
		internal static int __PropertyOffset_107;

		// Token: 0x040152BD RID: 86717
		internal static int __PropertyOffset_108;

		// Token: 0x040152BE RID: 86718
		internal static int __PropertyOffset_109;

		// Token: 0x040152BF RID: 86719
		internal static int __PropertyOffset_110;

		// Token: 0x040152C0 RID: 86720
		internal static int __PropertyOffset_111;

		// Token: 0x040152C1 RID: 86721
		internal static int __PropertyOffset_112;

		// Token: 0x040152C2 RID: 86722
		internal static int __PropertyOffset_113;

		// Token: 0x040152C3 RID: 86723
		internal static int __PropertyOffset_114;

		// Token: 0x040152C4 RID: 86724
		internal static int __PropertyOffset_115;

		// Token: 0x040152C5 RID: 86725
		internal static int __PropertyOffset_116;

		// Token: 0x040152C6 RID: 86726
		internal static int __PropertyOffset_117;

		// Token: 0x040152C7 RID: 86727
		internal static int __PropertyOffset_118;

		// Token: 0x040152C8 RID: 86728
		internal static int __PropertyOffset_119;

		// Token: 0x040152C9 RID: 86729
		internal static int __PropertyOffset_120;

		// Token: 0x040152CA RID: 86730
		internal static int __PropertyOffset_121;
	}
}
