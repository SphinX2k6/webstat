using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.RailSlide
{
	// Token: 0x02003E75 RID: 15989
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/RailSlide/BP_RailSlideConfig.BP_RailSlideConfig_C")]
	[UnrealStructLayout(336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 335)]
	public class BP_RailSlideConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027854 RID: 161876 RVA: 0x009F3B33 File Offset: 0x009F1D33
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RailSlideConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/RailSlide/BP_RailSlideConfig.BP_RailSlideConfig_C");
			}
			return BP_RailSlideConfig_C._ClassPtr;
		}

		// Token: 0x06027855 RID: 161877 RVA: 0x009F3B58 File Offset: 0x009F1D58
		public BP_RailSlideConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_RailSlideConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027856 RID: 161878 RVA: 0x009F3B80 File Offset: 0x009F1D80
		public BP_RailSlideConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RailSlideConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D40 RID: 23872
		// (get) Token: 0x06027857 RID: 161879 RVA: 0x009F3BB3 File Offset: 0x009F1DB3
		// (set) Token: 0x06027858 RID: 161880 RVA: 0x009F3BC3 File Offset: 0x009F1DC3
		public unsafe int 初始速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005D41 RID: 23873
		// (get) Token: 0x06027859 RID: 161881 RVA: 0x009F3BD4 File Offset: 0x009F1DD4
		// (set) Token: 0x0602785A RID: 161882 RVA: 0x009F3BE4 File Offset: 0x009F1DE4
		public unsafe int 基础目标速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005D42 RID: 23874
		// (get) Token: 0x0602785B RID: 161883 RVA: 0x009F3BF5 File Offset: 0x009F1DF5
		// (set) Token: 0x0602785C RID: 161884 RVA: 0x009F3C05 File Offset: 0x009F1E05
		public unsafe int 基础加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005D43 RID: 23875
		// (get) Token: 0x0602785D RID: 161885 RVA: 0x009F3C16 File Offset: 0x009F1E16
		// (set) Token: 0x0602785E RID: 161886 RVA: 0x009F3C26 File Offset: 0x009F1E26
		public unsafe int 上坡目标速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005D44 RID: 23876
		// (get) Token: 0x0602785F RID: 161887 RVA: 0x009F3C37 File Offset: 0x009F1E37
		// (set) Token: 0x06027860 RID: 161888 RVA: 0x009F3C47 File Offset: 0x009F1E47
		public unsafe int 上坡加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005D45 RID: 23877
		// (get) Token: 0x06027861 RID: 161889 RVA: 0x009F3C58 File Offset: 0x009F1E58
		// (set) Token: 0x06027862 RID: 161890 RVA: 0x009F3C68 File Offset: 0x009F1E68
		public unsafe int 下坡目标速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005D46 RID: 23878
		// (get) Token: 0x06027863 RID: 161891 RVA: 0x009F3C79 File Offset: 0x009F1E79
		// (set) Token: 0x06027864 RID: 161892 RVA: 0x009F3C89 File Offset: 0x009F1E89
		public unsafe int 下坡加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005D47 RID: 23879
		// (get) Token: 0x06027865 RID: 161893 RVA: 0x009F3C9A File Offset: 0x009F1E9A
		// (set) Token: 0x06027866 RID: 161894 RVA: 0x009F3CAA File Offset: 0x009F1EAA
		public unsafe int 基础跳跃高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005D48 RID: 23880
		// (get) Token: 0x06027867 RID: 161895 RVA: 0x009F3CBB File Offset: 0x009F1EBB
		// (set) Token: 0x06027868 RID: 161896 RVA: 0x009F3CCB File Offset: 0x009F1ECB
		public unsafe float 基础跳远倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005D49 RID: 23881
		// (get) Token: 0x06027869 RID: 161897 RVA: 0x009F3CDC File Offset: 0x009F1EDC
		// (set) Token: 0x0602786A RID: 161898 RVA: 0x009F3CEC File Offset: 0x009F1EEC
		public unsafe int 最大跳跃距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005D4A RID: 23882
		// (get) Token: 0x0602786B RID: 161899 RVA: 0x009F3CFD File Offset: 0x009F1EFD
		// (set) Token: 0x0602786C RID: 161900 RVA: 0x009F3D0D File Offset: 0x009F1F0D
		public unsafe int 最大跳跃高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005D4B RID: 23883
		// (get) Token: 0x0602786D RID: 161901 RVA: 0x009F3D1E File Offset: 0x009F1F1E
		// (set) Token: 0x0602786E RID: 161902 RVA: 0x009F3D2E File Offset: 0x009F1F2E
		public unsafe int 起跳加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005D4C RID: 23884
		// (get) Token: 0x0602786F RID: 161903 RVA: 0x009F3D3F File Offset: 0x009F1F3F
		// (set) Token: 0x06027870 RID: 161904 RVA: 0x009F3D4F File Offset: 0x009F1F4F
		public unsafe int 起跳加速度_卡提西亚
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005D4D RID: 23885
		// (get) Token: 0x06027871 RID: 161905 RVA: 0x009F3D60 File Offset: 0x009F1F60
		// (set) Token: 0x06027872 RID: 161906 RVA: 0x009F3D70 File Offset: 0x009F1F70
		public unsafe float 倾斜输入插值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005D4E RID: 23886
		// (get) Token: 0x06027873 RID: 161907 RVA: 0x009F3D81 File Offset: 0x009F1F81
		// (set) Token: 0x06027874 RID: 161908 RVA: 0x009F3D91 File Offset: 0x009F1F91
		public unsafe int 最大倾斜角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005D4F RID: 23887
		// (get) Token: 0x06027875 RID: 161909 RVA: 0x009F3DA2 File Offset: 0x009F1FA2
		// (set) Token: 0x06027876 RID: 161910 RVA: 0x009F3DB2 File Offset: 0x009F1FB2
		public unsafe int 初始进入轨道速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005D50 RID: 23888
		// (get) Token: 0x06027877 RID: 161911 RVA: 0x009F3DC3 File Offset: 0x009F1FC3
		// (set) Token: 0x06027878 RID: 161912 RVA: 0x009F3DD3 File Offset: 0x009F1FD3
		public unsafe int 切换轨道CD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005D51 RID: 23889
		// (get) Token: 0x06027879 RID: 161913 RVA: 0x009F3DE4 File Offset: 0x009F1FE4
		// (set) Token: 0x0602787A RID: 161914 RVA: 0x009F3DF4 File Offset: 0x009F1FF4
		public unsafe int 切换轨道水平距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005D52 RID: 23890
		// (get) Token: 0x0602787B RID: 161915 RVA: 0x009F3E05 File Offset: 0x009F2005
		// (set) Token: 0x0602787C RID: 161916 RVA: 0x009F3E15 File Offset: 0x009F2015
		public unsafe int 切换轨道垂直距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005D53 RID: 23891
		// (get) Token: 0x0602787D RID: 161917 RVA: 0x009F3E26 File Offset: 0x009F2026
		// (set) Token: 0x0602787E RID: 161918 RVA: 0x009F3E36 File Offset: 0x009F2036
		public unsafe int 最大加速度角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005D54 RID: 23892
		// (get) Token: 0x0602787F RID: 161919 RVA: 0x009F3E47 File Offset: 0x009F2047
		// (set) Token: 0x06027880 RID: 161920 RVA: 0x009F3E57 File Offset: 0x009F2057
		public unsafe int 起跳目标速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005D55 RID: 23893
		// (get) Token: 0x06027881 RID: 161921 RVA: 0x009F3E68 File Offset: 0x009F2068
		// (set) Token: 0x06027882 RID: 161922 RVA: 0x009F3E78 File Offset: 0x009F2078
		public unsafe int 切换轨道基速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005D56 RID: 23894
		// (get) Token: 0x06027883 RID: 161923 RVA: 0x009F3E8C File Offset: 0x009F208C
		// (set) Token: 0x06027884 RID: 161924 RVA: 0x009F3EC5 File Offset: 0x009F20C5
		public SFloatCurve 位移曲线
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._位移曲线) == null)
				{
					result = (this._位移曲线 = new SFloatCurve(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D57 RID: 23895
		// (get) Token: 0x06027885 RID: 161925 RVA: 0x009F3EE8 File Offset: 0x009F20E8
		// (set) Token: 0x06027886 RID: 161926 RVA: 0x009F3F21 File Offset: 0x009F2121
		public SFloatCurve 位移曲线_卡提西亚
		{
			get
			{
				base.FastCheckIsValid();
				SFloatCurve result;
				if ((result = this._位移曲线_卡提西亚) == null)
				{
					result = (this._位移曲线_卡提西亚 = new SFloatCurve(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D58 RID: 23896
		// (get) Token: 0x06027887 RID: 161927 RVA: 0x009F3F42 File Offset: 0x009F2142
		// (set) Token: 0x06027888 RID: 161928 RVA: 0x009F3F52 File Offset: 0x009F2152
		public unsafe int 限制输入角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005D59 RID: 23897
		// (get) Token: 0x06027889 RID: 161929 RVA: 0x009F3F64 File Offset: 0x009F2164
		// (set) Token: 0x0602788A RID: 161930 RVA: 0x009F3F9D File Offset: 0x009F219D
		public FGameplayTagContainer 期间Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._期间Tag) == null)
				{
					result = (this._期间Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D5A RID: 23898
		// (get) Token: 0x0602788B RID: 161931 RVA: 0x009F3FBE File Offset: 0x009F21BE
		// (set) Token: 0x0602788C RID: 161932 RVA: 0x009F3FCE File Offset: 0x009F21CE
		public unsafe int 落地最大速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005D5B RID: 23899
		// (get) Token: 0x0602788D RID: 161933 RVA: 0x009F3FDF File Offset: 0x009F21DF
		// (set) Token: 0x0602788E RID: 161934 RVA: 0x009F3FEF File Offset: 0x009F21EF
		public unsafe int 落地最小速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17005D5C RID: 23900
		// (get) Token: 0x0602788F RID: 161935 RVA: 0x009F4000 File Offset: 0x009F2200
		// (set) Token: 0x06027890 RID: 161936 RVA: 0x009F4039 File Offset: 0x009F2239
		public TArray<int> 打断技能列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._打断技能列表) == null)
				{
					result = (this._打断技能列表 = new TArray<int>(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				this.打断技能列表.CopyAssign(value);
			}
		}

		// Token: 0x17005D5D RID: 23901
		// (get) Token: 0x06027891 RID: 161937 RVA: 0x009F4047 File Offset: 0x009F2247
		// (set) Token: 0x06027892 RID: 161938 RVA: 0x009F4057 File Offset: 0x009F2257
		public unsafe int 起跳时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17005D5E RID: 23902
		// (get) Token: 0x06027893 RID: 161939 RVA: 0x009F4068 File Offset: 0x009F2268
		// (set) Token: 0x06027894 RID: 161940 RVA: 0x009F4078 File Offset: 0x009F2278
		public unsafe int 起跳时长_卡提西亚
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17005D5F RID: 23903
		// (get) Token: 0x06027895 RID: 161941 RVA: 0x009F4089 File Offset: 0x009F2289
		// (set) Token: 0x06027896 RID: 161942 RVA: 0x009F4099 File Offset: 0x009F2299
		public unsafe int 落地时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17005D60 RID: 23904
		// (get) Token: 0x06027897 RID: 161943 RVA: 0x009F40AA File Offset: 0x009F22AA
		// (set) Token: 0x06027898 RID: 161944 RVA: 0x009F40BA File Offset: 0x009F22BA
		public unsafe int 落地时长_卡提西亚
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17005D61 RID: 23905
		// (get) Token: 0x06027899 RID: 161945 RVA: 0x009F40CB File Offset: 0x009F22CB
		// (set) Token: 0x0602789A RID: 161946 RVA: 0x009F40DB File Offset: 0x009F22DB
		public unsafe int 跳跃空中总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17005D62 RID: 23906
		// (get) Token: 0x0602789B RID: 161947 RVA: 0x009F40EC File Offset: 0x009F22EC
		// (set) Token: 0x0602789C RID: 161948 RVA: 0x009F40FC File Offset: 0x009F22FC
		public unsafe bool DebugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D63 RID: 23907
		// (get) Token: 0x0602789D RID: 161949 RVA: 0x009F410D File Offset: 0x009F230D
		// (set) Token: 0x0602789E RID: 161950 RVA: 0x009F411D File Offset: 0x009F231D
		public unsafe int 前向基础跳跃高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17005D64 RID: 23908
		// (get) Token: 0x0602789F RID: 161951 RVA: 0x009F412E File Offset: 0x009F232E
		// (set) Token: 0x060278A0 RID: 161952 RVA: 0x009F413E File Offset: 0x009F233E
		public unsafe float 前向基础跳远倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17005D65 RID: 23909
		// (get) Token: 0x060278A1 RID: 161953 RVA: 0x009F414F File Offset: 0x009F234F
		// (set) Token: 0x060278A2 RID: 161954 RVA: 0x009F415F File Offset: 0x009F235F
		public unsafe int 前向最大跳跃距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17005D66 RID: 23910
		// (get) Token: 0x060278A3 RID: 161955 RVA: 0x009F4170 File Offset: 0x009F2370
		// (set) Token: 0x060278A4 RID: 161956 RVA: 0x009F4180 File Offset: 0x009F2380
		public unsafe int 前向最大跳跃高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17005D67 RID: 23911
		// (get) Token: 0x060278A5 RID: 161957 RVA: 0x009F4191 File Offset: 0x009F2391
		// (set) Token: 0x060278A6 RID: 161958 RVA: 0x009F41A1 File Offset: 0x009F23A1
		public unsafe int 前向起跳加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17005D68 RID: 23912
		// (get) Token: 0x060278A7 RID: 161959 RVA: 0x009F41B2 File Offset: 0x009F23B2
		// (set) Token: 0x060278A8 RID: 161960 RVA: 0x009F41C2 File Offset: 0x009F23C2
		public unsafe int 前向起跳目标速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17005D69 RID: 23913
		// (get) Token: 0x060278A9 RID: 161961 RVA: 0x009F41D3 File Offset: 0x009F23D3
		// (set) Token: 0x060278AA RID: 161962 RVA: 0x009F41E3 File Offset: 0x009F23E3
		public unsafe int 前向跳跃空中总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17005D6A RID: 23914
		// (get) Token: 0x060278AB RID: 161963 RVA: 0x009F41F4 File Offset: 0x009F23F4
		// (set) Token: 0x060278AC RID: 161964 RVA: 0x009F4204 File Offset: 0x009F2404
		public unsafe int 前向起跳时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17005D6B RID: 23915
		// (get) Token: 0x060278AD RID: 161965 RVA: 0x009F4215 File Offset: 0x009F2415
		// (set) Token: 0x060278AE RID: 161966 RVA: 0x009F4225 File Offset: 0x009F2425
		public unsafe int 前向落地时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17005D6C RID: 23916
		// (get) Token: 0x060278AF RID: 161967 RVA: 0x009F4236 File Offset: 0x009F2436
		// (set) Token: 0x060278B0 RID: 161968 RVA: 0x009F4246 File Offset: 0x009F2446
		public unsafe bool 是否有落地动画
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D6D RID: 23917
		// (get) Token: 0x060278B1 RID: 161969 RVA: 0x009F4257 File Offset: 0x009F2457
		// (set) Token: 0x060278B2 RID: 161970 RVA: 0x009F4267 File Offset: 0x009F2467
		public unsafe bool 是否启用定制动作_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D6E RID: 23918
		// (get) Token: 0x060278B3 RID: 161971 RVA: 0x009F4278 File Offset: 0x009F2478
		// (set) Token: 0x060278B4 RID: 161972 RVA: 0x009F4288 File Offset: 0x009F2488
		public unsafe bool DebugDraw_Control
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D6F RID: 23919
		// (get) Token: 0x060278B5 RID: 161973 RVA: 0x009F4299 File Offset: 0x009F2499
		// (set) Token: 0x060278B6 RID: 161974 RVA: 0x009F42AD File Offset: 0x009F24AD
		public unsafe SRailSlideControlConfig 横向控制参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17005D70 RID: 23920
		// (get) Token: 0x060278B7 RID: 161975 RVA: 0x009F42C2 File Offset: 0x009F24C2
		// (set) Token: 0x060278B8 RID: 161976 RVA: 0x009F42D2 File Offset: 0x009F24D2
		public unsafe ERailSlideAnimType 滑轨动画类型
		{
			get
			{
				return (ERailSlideAnimType)(*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_48));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_48) = (byte)value;
			}
		}

		// Token: 0x17005D71 RID: 23921
		// (get) Token: 0x060278B9 RID: 161977 RVA: 0x009F42E3 File Offset: 0x009F24E3
		// (set) Token: 0x060278BA RID: 161978 RVA: 0x009F42F3 File Offset: 0x009F24F3
		public unsafe bool 禁止重力方向倾斜
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005D72 RID: 23922
		// (get) Token: 0x060278BB RID: 161979 RVA: 0x009F4304 File Offset: 0x009F2504
		// (set) Token: 0x060278BC RID: 161980 RVA: 0x009F4314 File Offset: 0x009F2514
		public unsafe bool 禁止前后俯仰倾斜
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RailSlideConfig_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x060278BD RID: 161981 RVA: 0x009F4325 File Offset: 0x009F2525
		protected BP_RailSlideConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B40 RID: 84800
		public new const string __ObjectPath = "/Game/Aki/Data/Level/RailSlide/BP_RailSlideConfig.BP_RailSlideConfig_C";

		// Token: 0x04014B41 RID: 84801
		private static IntPtr _ClassPtr;

		// Token: 0x04014B42 RID: 84802
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B43 RID: 84803
		internal static int __PropertyOffset_0;

		// Token: 0x04014B44 RID: 84804
		internal static int __PropertyOffset_1;

		// Token: 0x04014B45 RID: 84805
		internal static int __PropertyOffset_2;

		// Token: 0x04014B46 RID: 84806
		internal static int __PropertyOffset_3;

		// Token: 0x04014B47 RID: 84807
		internal static int __PropertyOffset_4;

		// Token: 0x04014B48 RID: 84808
		internal static int __PropertyOffset_5;

		// Token: 0x04014B49 RID: 84809
		internal static int __PropertyOffset_6;

		// Token: 0x04014B4A RID: 84810
		internal static int __PropertyOffset_7;

		// Token: 0x04014B4B RID: 84811
		internal static int __PropertyOffset_8;

		// Token: 0x04014B4C RID: 84812
		internal static int __PropertyOffset_9;

		// Token: 0x04014B4D RID: 84813
		internal static int __PropertyOffset_10;

		// Token: 0x04014B4E RID: 84814
		internal static int __PropertyOffset_11;

		// Token: 0x04014B4F RID: 84815
		internal static int __PropertyOffset_12;

		// Token: 0x04014B50 RID: 84816
		internal static int __PropertyOffset_13;

		// Token: 0x04014B51 RID: 84817
		internal static int __PropertyOffset_14;

		// Token: 0x04014B52 RID: 84818
		internal static int __PropertyOffset_15;

		// Token: 0x04014B53 RID: 84819
		internal static int __PropertyOffset_16;

		// Token: 0x04014B54 RID: 84820
		internal static int __PropertyOffset_17;

		// Token: 0x04014B55 RID: 84821
		internal static int __PropertyOffset_18;

		// Token: 0x04014B56 RID: 84822
		internal static int __PropertyOffset_19;

		// Token: 0x04014B57 RID: 84823
		internal static int __PropertyOffset_20;

		// Token: 0x04014B58 RID: 84824
		internal static int __PropertyOffset_21;

		// Token: 0x04014B59 RID: 84825
		internal static int __PropertyOffset_22;

		// Token: 0x04014B5A RID: 84826
		[Nullable(2)]
		private SFloatCurve _位移曲线;

		// Token: 0x04014B5B RID: 84827
		internal static int __PropertyOffset_23;

		// Token: 0x04014B5C RID: 84828
		[Nullable(2)]
		private SFloatCurve _位移曲线_卡提西亚;

		// Token: 0x04014B5D RID: 84829
		internal static int __PropertyOffset_24;

		// Token: 0x04014B5E RID: 84830
		internal static int __PropertyOffset_25;

		// Token: 0x04014B5F RID: 84831
		[Nullable(2)]
		private FGameplayTagContainer _期间Tag;

		// Token: 0x04014B60 RID: 84832
		internal static int __PropertyOffset_26;

		// Token: 0x04014B61 RID: 84833
		internal static int __PropertyOffset_27;

		// Token: 0x04014B62 RID: 84834
		internal static int __PropertyOffset_28;

		// Token: 0x04014B63 RID: 84835
		[Nullable(2)]
		private TArray<int> _打断技能列表;

		// Token: 0x04014B64 RID: 84836
		internal static int __PropertyOffset_29;

		// Token: 0x04014B65 RID: 84837
		internal static int __PropertyOffset_30;

		// Token: 0x04014B66 RID: 84838
		internal static int __PropertyOffset_31;

		// Token: 0x04014B67 RID: 84839
		internal static int __PropertyOffset_32;

		// Token: 0x04014B68 RID: 84840
		internal static int __PropertyOffset_33;

		// Token: 0x04014B69 RID: 84841
		internal static int __PropertyOffset_34;

		// Token: 0x04014B6A RID: 84842
		internal static int __PropertyOffset_35;

		// Token: 0x04014B6B RID: 84843
		internal static int __PropertyOffset_36;

		// Token: 0x04014B6C RID: 84844
		internal static int __PropertyOffset_37;

		// Token: 0x04014B6D RID: 84845
		internal static int __PropertyOffset_38;

		// Token: 0x04014B6E RID: 84846
		internal static int __PropertyOffset_39;

		// Token: 0x04014B6F RID: 84847
		internal static int __PropertyOffset_40;

		// Token: 0x04014B70 RID: 84848
		internal static int __PropertyOffset_41;

		// Token: 0x04014B71 RID: 84849
		internal static int __PropertyOffset_42;

		// Token: 0x04014B72 RID: 84850
		internal static int __PropertyOffset_43;

		// Token: 0x04014B73 RID: 84851
		internal static int __PropertyOffset_44;

		// Token: 0x04014B74 RID: 84852
		internal static int __PropertyOffset_45;

		// Token: 0x04014B75 RID: 84853
		internal static int __PropertyOffset_46;

		// Token: 0x04014B76 RID: 84854
		internal static int __PropertyOffset_47;

		// Token: 0x04014B77 RID: 84855
		internal static int __PropertyOffset_48;

		// Token: 0x04014B78 RID: 84856
		internal static int __PropertyOffset_49;

		// Token: 0x04014B79 RID: 84857
		internal static int __PropertyOffset_50;
	}
}
