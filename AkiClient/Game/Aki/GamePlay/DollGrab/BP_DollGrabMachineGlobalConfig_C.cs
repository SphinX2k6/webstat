using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.DollGrab
{
	// Token: 0x02003DD8 RID: 15832
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/DollGrab/BP_DollGrabMachineGlobalConfig.BP_DollGrabMachineGlobalConfig_C")]
	[UnrealStructLayout(928, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 928)]
	public class BP_DollGrabMachineGlobalConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026CC3 RID: 158915 RVA: 0x009E2400 File Offset: 0x009E0600
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollGrabMachineGlobalConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/DollGrab/BP_DollGrabMachineGlobalConfig.BP_DollGrabMachineGlobalConfig_C");
			}
			return BP_DollGrabMachineGlobalConfig_C._ClassPtr;
		}

		// Token: 0x06026CC4 RID: 158916 RVA: 0x009E2424 File Offset: 0x009E0624
		public BP_DollGrabMachineGlobalConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollGrabMachineGlobalConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026CC5 RID: 158917 RVA: 0x009E244C File Offset: 0x009E064C
		public BP_DollGrabMachineGlobalConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollGrabMachineGlobalConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700592A RID: 22826
		// (get) Token: 0x06026CC6 RID: 158918 RVA: 0x009E247F File Offset: 0x009E067F
		// (set) Token: 0x06026CC7 RID: 158919 RVA: 0x009E248F File Offset: 0x009E068F
		public unsafe float 钩爪移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700592B RID: 22827
		// (get) Token: 0x06026CC8 RID: 158920 RVA: 0x009E24A0 File Offset: 0x009E06A0
		// (set) Token: 0x06026CC9 RID: 158921 RVA: 0x009E24B0 File Offset: 0x009E06B0
		public unsafe float 钩爪X轴移动距离限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700592C RID: 22828
		// (get) Token: 0x06026CCA RID: 158922 RVA: 0x009E24C1 File Offset: 0x009E06C1
		// (set) Token: 0x06026CCB RID: 158923 RVA: 0x009E24D1 File Offset: 0x009E06D1
		public unsafe float 钩爪X轴起始偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700592D RID: 22829
		// (get) Token: 0x06026CCC RID: 158924 RVA: 0x009E24E2 File Offset: 0x009E06E2
		// (set) Token: 0x06026CCD RID: 158925 RVA: 0x009E24F2 File Offset: 0x009E06F2
		public unsafe float 钩爪Y轴移动距离限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700592E RID: 22830
		// (get) Token: 0x06026CCE RID: 158926 RVA: 0x009E2503 File Offset: 0x009E0703
		// (set) Token: 0x06026CCF RID: 158927 RVA: 0x009E2513 File Offset: 0x009E0713
		public unsafe float 钩爪Y轴起始偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700592F RID: 22831
		// (get) Token: 0x06026CD0 RID: 158928 RVA: 0x009E2524 File Offset: 0x009E0724
		// (set) Token: 0x06026CD1 RID: 158929 RVA: 0x009E2534 File Offset: 0x009E0734
		public unsafe float 钩爪下探距离限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005930 RID: 22832
		// (get) Token: 0x06026CD2 RID: 158930 RVA: 0x009E2545 File Offset: 0x009E0745
		// (set) Token: 0x06026CD3 RID: 158931 RVA: 0x009E2555 File Offset: 0x009E0755
		public unsafe float 钩爪下探速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005931 RID: 22833
		// (get) Token: 0x06026CD4 RID: 158932 RVA: 0x009E2566 File Offset: 0x009E0766
		// (set) Token: 0x06026CD5 RID: 158933 RVA: 0x009E2576 File Offset: 0x009E0776
		public unsafe float 钩爪上升速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005932 RID: 22834
		// (get) Token: 0x06026CD6 RID: 158934 RVA: 0x009E2587 File Offset: 0x009E0787
		// (set) Token: 0x06026CD7 RID: 158935 RVA: 0x009E259B File Offset: 0x009E079B
		public unsafe FVector 相机位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005933 RID: 22835
		// (get) Token: 0x06026CD8 RID: 158936 RVA: 0x009E25B0 File Offset: 0x009E07B0
		// (set) Token: 0x06026CD9 RID: 158937 RVA: 0x009E25C4 File Offset: 0x009E07C4
		public unsafe FRotator 相机旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005934 RID: 22836
		// (get) Token: 0x06026CDA RID: 158938 RVA: 0x009E25D9 File Offset: 0x009E07D9
		// (set) Token: 0x06026CDB RID: 158939 RVA: 0x009E25E9 File Offset: 0x009E07E9
		public unsafe float 淡入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005935 RID: 22837
		// (get) Token: 0x06026CDC RID: 158940 RVA: 0x009E25FA File Offset: 0x009E07FA
		// (set) Token: 0x06026CDD RID: 158941 RVA: 0x009E260A File Offset: 0x009E080A
		public unsafe float 淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005936 RID: 22838
		// (get) Token: 0x06026CDE RID: 158942 RVA: 0x009E261B File Offset: 0x009E081B
		// (set) Token: 0x06026CDF RID: 158943 RVA: 0x009E262B File Offset: 0x009E082B
		public unsafe bool 关闭镜头碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005937 RID: 22839
		// (get) Token: 0x06026CE0 RID: 158944 RVA: 0x009E263C File Offset: 0x009E083C
		// (set) Token: 0x06026CE1 RID: 158945 RVA: 0x009E264C File Offset: 0x009E084C
		public unsafe bool 关闭镜头虚化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005938 RID: 22840
		// (get) Token: 0x06026CE2 RID: 158946 RVA: 0x009E265D File Offset: 0x009E085D
		// (set) Token: 0x06026CE3 RID: 158947 RVA: 0x009E266D File Offset: 0x009E086D
		public unsafe float Fov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005939 RID: 22841
		// (get) Token: 0x06026CE4 RID: 158948 RVA: 0x009E267E File Offset: 0x009E087E
		// (set) Token: 0x06026CE5 RID: 158949 RVA: 0x009E268E File Offset: 0x009E088E
		public unsafe float 履带移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700593A RID: 22842
		// (get) Token: 0x06026CE6 RID: 158950 RVA: 0x009E269F File Offset: 0x009E089F
		// (set) Token: 0x06026CE7 RID: 158951 RVA: 0x009E26AF File Offset: 0x009E08AF
		public unsafe float 履带吸附距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700593B RID: 22843
		// (get) Token: 0x06026CE8 RID: 158952 RVA: 0x009E26C0 File Offset: 0x009E08C0
		// (set) Token: 0x06026CE9 RID: 158953 RVA: 0x009E26D0 File Offset: 0x009E08D0
		public unsafe float 履带吸附速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700593C RID: 22844
		// (get) Token: 0x06026CEA RID: 158954 RVA: 0x009E26E1 File Offset: 0x009E08E1
		// (set) Token: 0x06026CEB RID: 158955 RVA: 0x009E26F1 File Offset: 0x009E08F1
		public unsafe float 履带TriggerZ轴缩放值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700593D RID: 22845
		// (get) Token: 0x06026CEC RID: 158956 RVA: 0x009E2702 File Offset: 0x009E0902
		// (set) Token: 0x06026CED RID: 158957 RVA: 0x009E2716 File Offset: 0x009E0916
		public unsafe FVector 展示柜相机位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700593E RID: 22846
		// (get) Token: 0x06026CEE RID: 158958 RVA: 0x009E272B File Offset: 0x009E092B
		// (set) Token: 0x06026CEF RID: 158959 RVA: 0x009E273F File Offset: 0x009E093F
		public unsafe FRotator 展示柜相机旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700593F RID: 22847
		// (get) Token: 0x06026CF0 RID: 158960 RVA: 0x009E2754 File Offset: 0x009E0954
		// (set) Token: 0x06026CF1 RID: 158961 RVA: 0x009E2764 File Offset: 0x009E0964
		public unsafe float 展示柜淡入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005940 RID: 22848
		// (get) Token: 0x06026CF2 RID: 158962 RVA: 0x009E2775 File Offset: 0x009E0975
		// (set) Token: 0x06026CF3 RID: 158963 RVA: 0x009E2785 File Offset: 0x009E0985
		public unsafe float 展示柜淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005941 RID: 22849
		// (get) Token: 0x06026CF4 RID: 158964 RVA: 0x009E2796 File Offset: 0x009E0996
		// (set) Token: 0x06026CF5 RID: 158965 RVA: 0x009E27A6 File Offset: 0x009E09A6
		public unsafe bool 展示柜关闭镜头碰撞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005942 RID: 22850
		// (get) Token: 0x06026CF6 RID: 158966 RVA: 0x009E27B7 File Offset: 0x009E09B7
		// (set) Token: 0x06026CF7 RID: 158967 RVA: 0x009E27C7 File Offset: 0x009E09C7
		public unsafe bool 展示柜关闭镜头虚化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005943 RID: 22851
		// (get) Token: 0x06026CF8 RID: 158968 RVA: 0x009E27D8 File Offset: 0x009E09D8
		// (set) Token: 0x06026CF9 RID: 158969 RVA: 0x009E27E8 File Offset: 0x009E09E8
		public unsafe float 展示柜Fov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005944 RID: 22852
		// (get) Token: 0x06026CFA RID: 158970 RVA: 0x009E27F9 File Offset: 0x009E09F9
		// (set) Token: 0x06026CFB RID: 158971 RVA: 0x009E2809 File Offset: 0x009E0A09
		public unsafe float 钩爪延迟合上时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005945 RID: 22853
		// (get) Token: 0x06026CFC RID: 158972 RVA: 0x009E281A File Offset: 0x009E0A1A
		// (set) Token: 0x06026CFD RID: 158973 RVA: 0x009E282F File Offset: 0x009E0A2F
		public TSoftObjectPtr<ULevelSequence> 钩爪Seq
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_27, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_27, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005946 RID: 22854
		// (get) Token: 0x06026CFE RID: 158974 RVA: 0x009E2854 File Offset: 0x009E0A54
		// (set) Token: 0x06026CFF RID: 158975 RVA: 0x009E2864 File Offset: 0x009E0A64
		public unsafe float 钩爪锁链缩放比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17005947 RID: 22855
		// (get) Token: 0x06026D00 RID: 158976 RVA: 0x009E2875 File Offset: 0x009E0A75
		// (set) Token: 0x06026D01 RID: 158977 RVA: 0x009E2885 File Offset: 0x009E0A85
		public unsafe float 钩爪复位时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17005948 RID: 22856
		// (get) Token: 0x06026D02 RID: 158978 RVA: 0x009E2896 File Offset: 0x009E0A96
		// (set) Token: 0x06026D03 RID: 158979 RVA: 0x009E28A6 File Offset: 0x009E0AA6
		public unsafe float 溶解时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17005949 RID: 22857
		// (get) Token: 0x06026D04 RID: 158980 RVA: 0x009E28B7 File Offset: 0x009E0AB7
		// (set) Token: 0x06026D05 RID: 158981 RVA: 0x009E28C7 File Offset: 0x009E0AC7
		public unsafe float 溶解半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700594A RID: 22858
		// (get) Token: 0x06026D06 RID: 158982 RVA: 0x009E28D8 File Offset: 0x009E0AD8
		// (set) Token: 0x06026D07 RID: 158983 RVA: 0x009E28E8 File Offset: 0x009E0AE8
		public unsafe float 旋转阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700594B RID: 22859
		// (get) Token: 0x06026D08 RID: 158984 RVA: 0x009E28F9 File Offset: 0x009E0AF9
		// (set) Token: 0x06026D09 RID: 158985 RVA: 0x009E2909 File Offset: 0x009E0B09
		public unsafe float 平移阻尼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x1700594C RID: 22860
		// (get) Token: 0x06026D0A RID: 158986 RVA: 0x009E291A File Offset: 0x009E0B1A
		// (set) Token: 0x06026D0B RID: 158987 RVA: 0x009E292F File Offset: 0x009E0B2F
		public TSoftObjectPtr<UEffectModelGroup> 倒计时屏幕特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_34, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_34, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700594D RID: 22861
		// (get) Token: 0x06026D0C RID: 158988 RVA: 0x009E2954 File Offset: 0x009E0B54
		// (set) Token: 0x06026D0D RID: 158989 RVA: 0x009E2969 File Offset: 0x009E0B69
		public TSoftObjectPtr<UTexture> 钩爪松开按钮图标
		{
			get
			{
				return new TSoftObjectPtr<UTexture>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_35, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_35, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700594E RID: 22862
		// (get) Token: 0x06026D0E RID: 158990 RVA: 0x009E298E File Offset: 0x009E0B8E
		// (set) Token: 0x06026D0F RID: 158991 RVA: 0x009E29A3 File Offset: 0x009E0BA3
		public TSoftObjectPtr<UTexture> 钩爪常态按钮图标
		{
			get
			{
				return new TSoftObjectPtr<UTexture>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_36, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_36, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700594F RID: 22863
		// (get) Token: 0x06026D10 RID: 158992 RVA: 0x009E29C8 File Offset: 0x009E0BC8
		// (set) Token: 0x06026D11 RID: 158993 RVA: 0x009E29DD File Offset: 0x009E0BDD
		public TSoftObjectPtr<UTexture> 钩爪抓取按钮图标
		{
			get
			{
				return new TSoftObjectPtr<UTexture>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_37, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_37, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005950 RID: 22864
		// (get) Token: 0x06026D12 RID: 158994 RVA: 0x009E2A02 File Offset: 0x009E0C02
		// (set) Token: 0x06026D13 RID: 158995 RVA: 0x009E2A17 File Offset: 0x009E0C17
		public TSoftObjectPtr<UTexture> 投币按钮图标
		{
			get
			{
				return new TSoftObjectPtr<UTexture>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_38, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_38, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005951 RID: 22865
		// (get) Token: 0x06026D14 RID: 158996 RVA: 0x009E2A3C File Offset: 0x009E0C3C
		// (set) Token: 0x06026D15 RID: 158997 RVA: 0x009E2A50 File Offset: 0x009E0C50
		public unsafe FVector 投出口特效偏移位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17005952 RID: 22866
		// (get) Token: 0x06026D16 RID: 158998 RVA: 0x009E2A65 File Offset: 0x009E0C65
		// (set) Token: 0x06026D17 RID: 158999 RVA: 0x009E2A75 File Offset: 0x009E0C75
		public unsafe float 危险倒计时
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17005953 RID: 22867
		// (get) Token: 0x06026D18 RID: 159000 RVA: 0x009E2A86 File Offset: 0x009E0C86
		// (set) Token: 0x06026D19 RID: 159001 RVA: 0x009E2A9B File Offset: 0x009E0C9B
		public TSoftObjectPtr<ULGUITexturePackerSpriteData> 进度条安全
		{
			get
			{
				return new TSoftObjectPtr<ULGUITexturePackerSpriteData>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_41, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_41, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005954 RID: 22868
		// (get) Token: 0x06026D1A RID: 159002 RVA: 0x009E2AC0 File Offset: 0x009E0CC0
		// (set) Token: 0x06026D1B RID: 159003 RVA: 0x009E2AD5 File Offset: 0x009E0CD5
		public TSoftObjectPtr<ULGUITexturePackerSpriteData> 进度条危险
		{
			get
			{
				return new TSoftObjectPtr<ULGUITexturePackerSpriteData>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_42, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_42, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005955 RID: 22869
		// (get) Token: 0x06026D1C RID: 159004 RVA: 0x009E2AFA File Offset: 0x009E0CFA
		// (set) Token: 0x06026D1D RID: 159005 RVA: 0x009E2B0F File Offset: 0x009E0D0F
		public TSoftObjectPtr<ULevelSequence> 常态灯光
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_43, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_43, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005956 RID: 22870
		// (get) Token: 0x06026D1E RID: 159006 RVA: 0x009E2B34 File Offset: 0x009E0D34
		// (set) Token: 0x06026D1F RID: 159007 RVA: 0x009E2B49 File Offset: 0x009E0D49
		public TSoftObjectPtr<ULevelSequence> 完成态灯光
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_44, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_44, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005957 RID: 22871
		// (get) Token: 0x06026D20 RID: 159008 RVA: 0x009E2B6E File Offset: 0x009E0D6E
		// (set) Token: 0x06026D21 RID: 159009 RVA: 0x009E2B83 File Offset: 0x009E0D83
		public TSoftObjectPtr<ULevelSequence> 开启玩法灯光
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_45, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_45, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005958 RID: 22872
		// (get) Token: 0x06026D22 RID: 159010 RVA: 0x009E2BA8 File Offset: 0x009E0DA8
		// (set) Token: 0x06026D23 RID: 159011 RVA: 0x009E2BBD File Offset: 0x009E0DBD
		public TSoftObjectPtr<ULevelSequence> 玩法进行中灯光
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_46, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_46, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005959 RID: 22873
		// (get) Token: 0x06026D24 RID: 159012 RVA: 0x009E2BE2 File Offset: 0x009E0DE2
		// (set) Token: 0x06026D25 RID: 159013 RVA: 0x009E2BF2 File Offset: 0x009E0DF2
		public unsafe float 钩爪松开时恢复移动时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x1700595A RID: 22874
		// (get) Token: 0x06026D26 RID: 159014 RVA: 0x009E2C03 File Offset: 0x009E0E03
		// (set) Token: 0x06026D27 RID: 159015 RVA: 0x009E2C18 File Offset: 0x009E0E18
		public TSoftObjectPtr<ULevelSequence> 阿布展示Seq
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_48, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_48, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700595B RID: 22875
		// (get) Token: 0x06026D28 RID: 159016 RVA: 0x009E2C3D File Offset: 0x009E0E3D
		// (set) Token: 0x06026D29 RID: 159017 RVA: 0x009E2C51 File Offset: 0x009E0E51
		public unsafe FVectorDouble 阿布展示播放位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x1700595C RID: 22876
		// (get) Token: 0x06026D2A RID: 159018 RVA: 0x009E2C66 File Offset: 0x009E0E66
		// (set) Token: 0x06026D2B RID: 159019 RVA: 0x009E2C76 File Offset: 0x009E0E76
		public unsafe float 黑幕淡入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x1700595D RID: 22877
		// (get) Token: 0x06026D2C RID: 159020 RVA: 0x009E2C87 File Offset: 0x009E0E87
		// (set) Token: 0x06026D2D RID: 159021 RVA: 0x009E2C97 File Offset: 0x009E0E97
		public unsafe float 黑幕淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x1700595E RID: 22878
		// (get) Token: 0x06026D2E RID: 159022 RVA: 0x009E2CA8 File Offset: 0x009E0EA8
		// (set) Token: 0x06026D2F RID: 159023 RVA: 0x009E2CB8 File Offset: 0x009E0EB8
		public unsafe float 黑幕持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x1700595F RID: 22879
		// (get) Token: 0x06026D30 RID: 159024 RVA: 0x009E2CC9 File Offset: 0x009E0EC9
		// (set) Token: 0x06026D31 RID: 159025 RVA: 0x009E2CD9 File Offset: 0x009E0ED9
		public unsafe float 展示动画播放速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabMachineGlobalConfig_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x06026D32 RID: 159026 RVA: 0x009E2CEA File Offset: 0x009E0EEA
		protected BP_DollGrabMachineGlobalConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040143C3 RID: 82883
		public new const string __ObjectPath = "/Game/Aki/GamePlay/DollGrab/BP_DollGrabMachineGlobalConfig.BP_DollGrabMachineGlobalConfig_C";

		// Token: 0x040143C4 RID: 82884
		private static IntPtr _ClassPtr;

		// Token: 0x040143C5 RID: 82885
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040143C6 RID: 82886
		internal static int __PropertyOffset_0;

		// Token: 0x040143C7 RID: 82887
		internal static int __PropertyOffset_1;

		// Token: 0x040143C8 RID: 82888
		internal static int __PropertyOffset_2;

		// Token: 0x040143C9 RID: 82889
		internal static int __PropertyOffset_3;

		// Token: 0x040143CA RID: 82890
		internal static int __PropertyOffset_4;

		// Token: 0x040143CB RID: 82891
		internal static int __PropertyOffset_5;

		// Token: 0x040143CC RID: 82892
		internal static int __PropertyOffset_6;

		// Token: 0x040143CD RID: 82893
		internal static int __PropertyOffset_7;

		// Token: 0x040143CE RID: 82894
		internal static int __PropertyOffset_8;

		// Token: 0x040143CF RID: 82895
		internal static int __PropertyOffset_9;

		// Token: 0x040143D0 RID: 82896
		internal static int __PropertyOffset_10;

		// Token: 0x040143D1 RID: 82897
		internal static int __PropertyOffset_11;

		// Token: 0x040143D2 RID: 82898
		internal static int __PropertyOffset_12;

		// Token: 0x040143D3 RID: 82899
		internal static int __PropertyOffset_13;

		// Token: 0x040143D4 RID: 82900
		internal static int __PropertyOffset_14;

		// Token: 0x040143D5 RID: 82901
		internal static int __PropertyOffset_15;

		// Token: 0x040143D6 RID: 82902
		internal static int __PropertyOffset_16;

		// Token: 0x040143D7 RID: 82903
		internal static int __PropertyOffset_17;

		// Token: 0x040143D8 RID: 82904
		internal static int __PropertyOffset_18;

		// Token: 0x040143D9 RID: 82905
		internal static int __PropertyOffset_19;

		// Token: 0x040143DA RID: 82906
		internal static int __PropertyOffset_20;

		// Token: 0x040143DB RID: 82907
		internal static int __PropertyOffset_21;

		// Token: 0x040143DC RID: 82908
		internal static int __PropertyOffset_22;

		// Token: 0x040143DD RID: 82909
		internal static int __PropertyOffset_23;

		// Token: 0x040143DE RID: 82910
		internal static int __PropertyOffset_24;

		// Token: 0x040143DF RID: 82911
		internal static int __PropertyOffset_25;

		// Token: 0x040143E0 RID: 82912
		internal static int __PropertyOffset_26;

		// Token: 0x040143E1 RID: 82913
		internal static int __PropertyOffset_27;

		// Token: 0x040143E2 RID: 82914
		internal static int __PropertyOffset_28;

		// Token: 0x040143E3 RID: 82915
		internal static int __PropertyOffset_29;

		// Token: 0x040143E4 RID: 82916
		internal static int __PropertyOffset_30;

		// Token: 0x040143E5 RID: 82917
		internal static int __PropertyOffset_31;

		// Token: 0x040143E6 RID: 82918
		internal static int __PropertyOffset_32;

		// Token: 0x040143E7 RID: 82919
		internal static int __PropertyOffset_33;

		// Token: 0x040143E8 RID: 82920
		internal static int __PropertyOffset_34;

		// Token: 0x040143E9 RID: 82921
		internal static int __PropertyOffset_35;

		// Token: 0x040143EA RID: 82922
		internal static int __PropertyOffset_36;

		// Token: 0x040143EB RID: 82923
		internal static int __PropertyOffset_37;

		// Token: 0x040143EC RID: 82924
		internal static int __PropertyOffset_38;

		// Token: 0x040143ED RID: 82925
		internal static int __PropertyOffset_39;

		// Token: 0x040143EE RID: 82926
		internal static int __PropertyOffset_40;

		// Token: 0x040143EF RID: 82927
		internal static int __PropertyOffset_41;

		// Token: 0x040143F0 RID: 82928
		internal static int __PropertyOffset_42;

		// Token: 0x040143F1 RID: 82929
		internal static int __PropertyOffset_43;

		// Token: 0x040143F2 RID: 82930
		internal static int __PropertyOffset_44;

		// Token: 0x040143F3 RID: 82931
		internal static int __PropertyOffset_45;

		// Token: 0x040143F4 RID: 82932
		internal static int __PropertyOffset_46;

		// Token: 0x040143F5 RID: 82933
		internal static int __PropertyOffset_47;

		// Token: 0x040143F6 RID: 82934
		internal static int __PropertyOffset_48;

		// Token: 0x040143F7 RID: 82935
		internal static int __PropertyOffset_49;

		// Token: 0x040143F8 RID: 82936
		internal static int __PropertyOffset_50;

		// Token: 0x040143F9 RID: 82937
		internal static int __PropertyOffset_51;

		// Token: 0x040143FA RID: 82938
		internal static int __PropertyOffset_52;

		// Token: 0x040143FB RID: 82939
		internal static int __PropertyOffset_53;
	}
}
