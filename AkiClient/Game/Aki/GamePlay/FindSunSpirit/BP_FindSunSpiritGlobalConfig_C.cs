using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.FindSunSpirit
{
	// Token: 0x02003DD7 RID: 15831
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/FindSunSpirit/BP_FindSunSpiritGlobalConfig.BP_FindSunSpiritGlobalConfig_C")]
	[UnrealStructLayout(488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 488)]
	public class BP_FindSunSpiritGlobalConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026C89 RID: 158857 RVA: 0x009E1EE8 File Offset: 0x009E00E8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FindSunSpiritGlobalConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/FindSunSpirit/BP_FindSunSpiritGlobalConfig.BP_FindSunSpiritGlobalConfig_C");
			}
			return BP_FindSunSpiritGlobalConfig_C._ClassPtr;
		}

		// Token: 0x06026C8A RID: 158858 RVA: 0x009E1F0C File Offset: 0x009E010C
		public BP_FindSunSpiritGlobalConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FindSunSpiritGlobalConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026C8B RID: 158859 RVA: 0x009E1F34 File Offset: 0x009E0134
		public BP_FindSunSpiritGlobalConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FindSunSpiritGlobalConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700590F RID: 22799
		// (get) Token: 0x06026C8C RID: 158860 RVA: 0x009E1F67 File Offset: 0x009E0167
		// (set) Token: 0x06026C8D RID: 158861 RVA: 0x009E1F7B File Offset: 0x009E017B
		[Nullable(2)]
		public unsafe UAnimMontage 跳跃蒙太奇
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005910 RID: 22800
		// (get) Token: 0x06026C8E RID: 158862 RVA: 0x009E1F90 File Offset: 0x009E0190
		// (set) Token: 0x06026C8F RID: 158863 RVA: 0x009E1FA0 File Offset: 0x009E01A0
		public unsafe int 跳跃旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005911 RID: 22801
		// (get) Token: 0x06026C90 RID: 158864 RVA: 0x009E1FB1 File Offset: 0x009E01B1
		// (set) Token: 0x06026C91 RID: 158865 RVA: 0x009E1FC1 File Offset: 0x009E01C1
		public unsafe int 跳跃高度偏移基准
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005912 RID: 22802
		// (get) Token: 0x06026C92 RID: 158866 RVA: 0x009E1FD2 File Offset: 0x009E01D2
		// (set) Token: 0x06026C93 RID: 158867 RVA: 0x009E1FE2 File Offset: 0x009E01E2
		public unsafe int 跳跃时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005913 RID: 22803
		// (get) Token: 0x06026C94 RID: 158868 RVA: 0x009E1FF3 File Offset: 0x009E01F3
		// (set) Token: 0x06026C95 RID: 158869 RVA: 0x009E2003 File Offset: 0x009E0203
		public unsafe int 跳跃上升偏移曲线高度范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005914 RID: 22804
		// (get) Token: 0x06026C96 RID: 158870 RVA: 0x009E2014 File Offset: 0x009E0214
		// (set) Token: 0x06026C97 RID: 158871 RVA: 0x009E2024 File Offset: 0x009E0224
		public unsafe int 跳跃下降偏移曲线高度范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005915 RID: 22805
		// (get) Token: 0x06026C98 RID: 158872 RVA: 0x009E2035 File Offset: 0x009E0235
		// (set) Token: 0x06026C99 RID: 158873 RVA: 0x009E2049 File Offset: 0x009E0249
		[Nullable(2)]
		public unsafe UCurveFloat 跳跃上升偏移曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005916 RID: 22806
		// (get) Token: 0x06026C9A RID: 158874 RVA: 0x009E205E File Offset: 0x009E025E
		// (set) Token: 0x06026C9B RID: 158875 RVA: 0x009E2072 File Offset: 0x009E0272
		[Nullable(2)]
		public unsafe UCurveFloat 跳跃下降偏移曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005917 RID: 22807
		// (get) Token: 0x06026C9C RID: 158876 RVA: 0x009E2087 File Offset: 0x009E0287
		// (set) Token: 0x06026C9D RID: 158877 RVA: 0x009E209B File Offset: 0x009E029B
		[Nullable(2)]
		public unsafe UAnimMontage 奔跑蒙太奇
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005918 RID: 22808
		// (get) Token: 0x06026C9E RID: 158878 RVA: 0x009E20B0 File Offset: 0x009E02B0
		// (set) Token: 0x06026C9F RID: 158879 RVA: 0x009E20C0 File Offset: 0x009E02C0
		public unsafe int 奔跑移动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005919 RID: 22809
		// (get) Token: 0x06026CA0 RID: 158880 RVA: 0x009E20D1 File Offset: 0x009E02D1
		// (set) Token: 0x06026CA1 RID: 158881 RVA: 0x009E20E1 File Offset: 0x009E02E1
		public unsafe int 奔跑旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700591A RID: 22810
		// (get) Token: 0x06026CA2 RID: 158882 RVA: 0x009E20F2 File Offset: 0x009E02F2
		// (set) Token: 0x06026CA3 RID: 158883 RVA: 0x009E2102 File Offset: 0x009E0302
		public unsafe int 奔跑结束停顿时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700591B RID: 22811
		// (get) Token: 0x06026CA4 RID: 158884 RVA: 0x009E2113 File Offset: 0x009E0313
		// (set) Token: 0x06026CA5 RID: 158885 RVA: 0x009E2123 File Offset: 0x009E0323
		public unsafe int 导航线持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700591C RID: 22812
		// (get) Token: 0x06026CA6 RID: 158886 RVA: 0x009E2134 File Offset: 0x009E0334
		// (set) Token: 0x06026CA7 RID: 158887 RVA: 0x009E2149 File Offset: 0x009E0349
		public TSoftObjectPtr<UEffectModelGroup> 成功导航线特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_13, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_13, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700591D RID: 22813
		// (get) Token: 0x06026CA8 RID: 158888 RVA: 0x009E216E File Offset: 0x009E036E
		// (set) Token: 0x06026CA9 RID: 158889 RVA: 0x009E2183 File Offset: 0x009E0383
		public TSoftObjectPtr<UEffectModelGroup> 失败导航线特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_14, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700591E RID: 22814
		// (get) Token: 0x06026CAA RID: 158890 RVA: 0x009E21A8 File Offset: 0x009E03A8
		// (set) Token: 0x06026CAB RID: 158891 RVA: 0x009E21E1 File Offset: 0x009E03E1
		public FSoftObjectPath 扩散装置路径
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._扩散装置路径) == null)
				{
					result = (this._扩散装置路径 = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700591F RID: 22815
		// (get) Token: 0x06026CAC RID: 158892 RVA: 0x009E2202 File Offset: 0x009E0402
		// (set) Token: 0x06026CAD RID: 158893 RVA: 0x009E2212 File Offset: 0x009E0412
		public unsafe int 扩散触发持续时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005920 RID: 22816
		// (get) Token: 0x06026CAE RID: 158894 RVA: 0x009E2224 File Offset: 0x009E0424
		// (set) Token: 0x06026CAF RID: 158895 RVA: 0x009E225D File Offset: 0x009E045D
		public TArray<FIntPoint> 扩散影响范围
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FIntPoint> result;
				if ((result = this._扩散影响范围) == null)
				{
					result = (this._扩散影响范围 = new TArray<FIntPoint>(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				this.扩散影响范围.CopyAssign(value);
			}
		}

		// Token: 0x17005921 RID: 22817
		// (get) Token: 0x06026CB0 RID: 158896 RVA: 0x009E226B File Offset: 0x009E046B
		// (set) Token: 0x06026CB1 RID: 158897 RVA: 0x009E2280 File Offset: 0x009E0480
		public TSoftObjectPtr<UNiagaraSystem> 关卡地板Niagara
		{
			get
			{
				return new TSoftObjectPtr<UNiagaraSystem>(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_18, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005922 RID: 22818
		// (get) Token: 0x06026CB2 RID: 158898 RVA: 0x009E22A5 File Offset: 0x009E04A5
		// (set) Token: 0x06026CB3 RID: 158899 RVA: 0x009E22B5 File Offset: 0x009E04B5
		public unsafe int 关卡地板单位大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005923 RID: 22819
		// (get) Token: 0x06026CB4 RID: 158900 RVA: 0x009E22C6 File Offset: 0x009E04C6
		// (set) Token: 0x06026CB5 RID: 158901 RVA: 0x009E22DA File Offset: 0x009E04DA
		[Nullable(2)]
		public unsafe UAnimMontage 寻路失败蒙太奇
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_20);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17005924 RID: 22820
		// (get) Token: 0x06026CB6 RID: 158902 RVA: 0x009E22EF File Offset: 0x009E04EF
		// (set) Token: 0x06026CB7 RID: 158903 RVA: 0x009E2303 File Offset: 0x009E0503
		[Nullable(2)]
		public unsafe UAnimMontage 到达终点蒙太奇
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_21);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17005925 RID: 22821
		// (get) Token: 0x06026CB8 RID: 158904 RVA: 0x009E2318 File Offset: 0x009E0518
		// (set) Token: 0x06026CB9 RID: 158905 RVA: 0x009E232C File Offset: 0x009E052C
		[Nullable(2)]
		public unsafe UAnimMontage 终点待机蒙太奇
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_22);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17005926 RID: 22822
		// (get) Token: 0x06026CBA RID: 158906 RVA: 0x009E2341 File Offset: 0x009E0541
		// (set) Token: 0x06026CBB RID: 158907 RVA: 0x009E2356 File Offset: 0x009E0556
		public TSoftObjectPtr<UEffectModelGroup> 射击轨迹特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_23, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_23, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005927 RID: 22823
		// (get) Token: 0x06026CBC RID: 158908 RVA: 0x009E237B File Offset: 0x009E057B
		// (set) Token: 0x06026CBD RID: 158909 RVA: 0x009E2390 File Offset: 0x009E0590
		public TSoftObjectPtr<UEffectModelGroup> 射击终点特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_24, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_24, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005928 RID: 22824
		// (get) Token: 0x06026CBE RID: 158910 RVA: 0x009E23B5 File Offset: 0x009E05B5
		// (set) Token: 0x06026CBF RID: 158911 RVA: 0x009E23C5 File Offset: 0x009E05C5
		public unsafe int 射击冷却时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005929 RID: 22825
		// (get) Token: 0x06026CC0 RID: 158912 RVA: 0x009E23D6 File Offset: 0x009E05D6
		// (set) Token: 0x06026CC1 RID: 158913 RVA: 0x009E23E6 File Offset: 0x009E05E6
		public unsafe int 失败重置延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FindSunSpiritGlobalConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x06026CC2 RID: 158914 RVA: 0x009E23F7 File Offset: 0x009E05F7
		protected BP_FindSunSpiritGlobalConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040143A3 RID: 82851
		public new const string __ObjectPath = "/Game/Aki/GamePlay/FindSunSpirit/BP_FindSunSpiritGlobalConfig.BP_FindSunSpiritGlobalConfig_C";

		// Token: 0x040143A4 RID: 82852
		private static IntPtr _ClassPtr;

		// Token: 0x040143A5 RID: 82853
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040143A6 RID: 82854
		internal static int __PropertyOffset_0;

		// Token: 0x040143A7 RID: 82855
		internal static int __PropertyOffset_1;

		// Token: 0x040143A8 RID: 82856
		internal static int __PropertyOffset_2;

		// Token: 0x040143A9 RID: 82857
		internal static int __PropertyOffset_3;

		// Token: 0x040143AA RID: 82858
		internal static int __PropertyOffset_4;

		// Token: 0x040143AB RID: 82859
		internal static int __PropertyOffset_5;

		// Token: 0x040143AC RID: 82860
		internal static int __PropertyOffset_6;

		// Token: 0x040143AD RID: 82861
		internal static int __PropertyOffset_7;

		// Token: 0x040143AE RID: 82862
		internal static int __PropertyOffset_8;

		// Token: 0x040143AF RID: 82863
		internal static int __PropertyOffset_9;

		// Token: 0x040143B0 RID: 82864
		internal static int __PropertyOffset_10;

		// Token: 0x040143B1 RID: 82865
		internal static int __PropertyOffset_11;

		// Token: 0x040143B2 RID: 82866
		internal static int __PropertyOffset_12;

		// Token: 0x040143B3 RID: 82867
		internal static int __PropertyOffset_13;

		// Token: 0x040143B4 RID: 82868
		internal static int __PropertyOffset_14;

		// Token: 0x040143B5 RID: 82869
		internal static int __PropertyOffset_15;

		// Token: 0x040143B6 RID: 82870
		[Nullable(2)]
		private FSoftObjectPath _扩散装置路径;

		// Token: 0x040143B7 RID: 82871
		internal static int __PropertyOffset_16;

		// Token: 0x040143B8 RID: 82872
		internal static int __PropertyOffset_17;

		// Token: 0x040143B9 RID: 82873
		[Nullable(2)]
		private TArray<FIntPoint> _扩散影响范围;

		// Token: 0x040143BA RID: 82874
		internal static int __PropertyOffset_18;

		// Token: 0x040143BB RID: 82875
		internal static int __PropertyOffset_19;

		// Token: 0x040143BC RID: 82876
		internal static int __PropertyOffset_20;

		// Token: 0x040143BD RID: 82877
		internal static int __PropertyOffset_21;

		// Token: 0x040143BE RID: 82878
		internal static int __PropertyOffset_22;

		// Token: 0x040143BF RID: 82879
		internal static int __PropertyOffset_23;

		// Token: 0x040143C0 RID: 82880
		internal static int __PropertyOffset_24;

		// Token: 0x040143C1 RID: 82881
		internal static int __PropertyOffset_25;

		// Token: 0x040143C2 RID: 82882
		internal static int __PropertyOffset_26;
	}
}
