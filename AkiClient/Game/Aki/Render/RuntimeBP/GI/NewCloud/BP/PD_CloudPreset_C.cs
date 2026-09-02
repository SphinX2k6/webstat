using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CCB RID: 15563
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/PD_CloudPreset.PD_CloudPreset_C")]
	[UnrealStructLayout(5744, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 5744)]
	public class PD_CloudPreset_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025099 RID: 151705 RVA: 0x009AF2DD File Offset: 0x009AD4DD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_CloudPreset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/PD_CloudPreset.PD_CloudPreset_C");
			}
			return PD_CloudPreset_C._ClassPtr;
		}

		// Token: 0x0602509A RID: 151706 RVA: 0x009AF304 File Offset: 0x009AD504
		public PD_CloudPreset_C() : this(BuiltinUtils.AllocNativeUObject(PD_CloudPreset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602509B RID: 151707 RVA: 0x009AF32C File Offset: 0x009AD52C
		public PD_CloudPreset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_CloudPreset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004F31 RID: 20273
		// (get) Token: 0x0602509C RID: 151708 RVA: 0x009AF35F File Offset: 0x009AD55F
		// (set) Token: 0x0602509D RID: 151709 RVA: 0x009AF374 File Offset: 0x009AD574
		public TSoftObjectPtr<PD_CloudPrefab_C> 天城
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_0, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F32 RID: 20274
		// (get) Token: 0x0602509E RID: 151710 RVA: 0x009AF399 File Offset: 0x009AD599
		// (set) Token: 0x0602509F RID: 151711 RVA: 0x009AF3AE File Offset: 0x009AD5AE
		public TSoftObjectPtr<PD_CloudPrefab_C> 遗落原乡
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_1, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F33 RID: 20275
		// (get) Token: 0x060250A0 RID: 151712 RVA: 0x009AF3D3 File Offset: 0x009AD5D3
		// (set) Token: 0x060250A1 RID: 151713 RVA: 0x009AF3E8 File Offset: 0x009AD5E8
		public TSoftObjectPtr<PD_CloudPrefab_C> 无光之森
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_2, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F34 RID: 20276
		// (get) Token: 0x060250A2 RID: 151714 RVA: 0x009AF40D File Offset: 0x009AD60D
		// (set) Token: 0x060250A3 RID: 151715 RVA: 0x009AF422 File Offset: 0x009AD622
		public TSoftObjectPtr<PD_CloudPrefab_C> 中曲台地
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_3, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F35 RID: 20277
		// (get) Token: 0x060250A4 RID: 151716 RVA: 0x009AF447 File Offset: 0x009AD647
		// (set) Token: 0x060250A5 RID: 151717 RVA: 0x009AF45C File Offset: 0x009AD65C
		public TSoftObjectPtr<PD_CloudPrefab_C> 登录界面
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_4, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F36 RID: 20278
		// (get) Token: 0x060250A6 RID: 151718 RVA: 0x009AF481 File Offset: 0x009AD681
		// (set) Token: 0x060250A7 RID: 151719 RVA: 0x009AF496 File Offset: 0x009AD696
		public TSoftObjectPtr<PD_CloudPrefab_C> 无音区沉寂态
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_5, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F37 RID: 20279
		// (get) Token: 0x060250A8 RID: 151720 RVA: 0x009AF4BB File Offset: 0x009AD6BB
		// (set) Token: 0x060250A9 RID: 151721 RVA: 0x009AF4D0 File Offset: 0x009AD6D0
		public TSoftObjectPtr<PD_CloudPrefab_C> 无音区01
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_6, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F38 RID: 20280
		// (get) Token: 0x060250AA RID: 151722 RVA: 0x009AF4F5 File Offset: 0x009AD6F5
		// (set) Token: 0x060250AB RID: 151723 RVA: 0x009AF50A File Offset: 0x009AD70A
		public TSoftObjectPtr<PD_CloudPrefab_C> 怨鸟泽
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_7, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F39 RID: 20281
		// (get) Token: 0x060250AC RID: 151724 RVA: 0x009AF52F File Offset: 0x009AD72F
		// (set) Token: 0x060250AD RID: 151725 RVA: 0x009AF544 File Offset: 0x009AD744
		public TSoftObjectPtr<PD_CloudPrefab_C> 原画测试专用云
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_8, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F3A RID: 20282
		// (get) Token: 0x060250AE RID: 151726 RVA: 0x009AF569 File Offset: 0x009AD769
		// (set) Token: 0x060250AF RID: 151727 RVA: 0x009AF57E File Offset: 0x009AD77E
		public TSoftObjectPtr<PD_CloudPrefab_C> 无音区02
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_9, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_9, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F3B RID: 20283
		// (get) Token: 0x060250B0 RID: 151728 RVA: 0x009AF5A3 File Offset: 0x009AD7A3
		// (set) Token: 0x060250B1 RID: 151729 RVA: 0x009AF5B8 File Offset: 0x009AD7B8
		public TSoftObjectPtr<PD_CloudPrefab_C> 无音区03
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_10, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F3C RID: 20284
		// (get) Token: 0x060250B2 RID: 151730 RVA: 0x009AF5DD File Offset: 0x009AD7DD
		// (set) Token: 0x060250B3 RID: 151731 RVA: 0x009AF5F2 File Offset: 0x009AD7F2
		public TSoftObjectPtr<PD_CloudPrefab_C> 无音区04
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_11, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F3D RID: 20285
		// (get) Token: 0x060250B4 RID: 151732 RVA: 0x009AF617 File Offset: 0x009AD817
		// (set) Token: 0x060250B5 RID: 151733 RVA: 0x009AF62C File Offset: 0x009AD82C
		public TSoftObjectPtr<PD_CloudPrefab_C> 无音区05
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_12, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F3E RID: 20286
		// (get) Token: 0x060250B6 RID: 151734 RVA: 0x009AF651 File Offset: 0x009AD851
		// (set) Token: 0x060250B7 RID: 151735 RVA: 0x009AF666 File Offset: 0x009AD866
		public TSoftObjectPtr<PD_CloudPrefab_C> 漩涡云
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_13, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_13, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F3F RID: 20287
		// (get) Token: 0x060250B8 RID: 151736 RVA: 0x009AF68B File Offset: 0x009AD88B
		// (set) Token: 0x060250B9 RID: 151737 RVA: 0x009AF6A0 File Offset: 0x009AD8A0
		public TSoftObjectPtr<PD_CloudPrefab_C> 鸣潮天气
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_14, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F40 RID: 20288
		// (get) Token: 0x060250BA RID: 151738 RVA: 0x009AF6C5 File Offset: 0x009AD8C5
		// (set) Token: 0x060250BB RID: 151739 RVA: 0x009AF6DA File Offset: 0x009AD8DA
		public TSoftObjectPtr<PD_CloudPrefab_C> 阴天异象
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_15, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_15, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F41 RID: 20289
		// (get) Token: 0x060250BC RID: 151740 RVA: 0x009AF6FF File Offset: 0x009AD8FF
		// (set) Token: 0x060250BD RID: 151741 RVA: 0x009AF714 File Offset: 0x009AD914
		public TSoftObjectPtr<PD_CloudPrefab_C> 黄昏异象
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_16, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_16, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F42 RID: 20290
		// (get) Token: 0x060250BE RID: 151742 RVA: 0x009AF739 File Offset: 0x009AD939
		// (set) Token: 0x060250BF RID: 151743 RVA: 0x009AF74E File Offset: 0x009AD94E
		public TSoftObjectPtr<PD_CloudPrefab_C> 夜晚异象
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_17, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_17, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F43 RID: 20291
		// (get) Token: 0x060250C0 RID: 151744 RVA: 0x009AF773 File Offset: 0x009AD973
		// (set) Token: 0x060250C1 RID: 151745 RVA: 0x009AF788 File Offset: 0x009AD988
		public TSoftObjectPtr<PD_CloudPrefab_C> 乘宵山异象
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_18, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F44 RID: 20292
		// (get) Token: 0x060250C2 RID: 151746 RVA: 0x009AF7AD File Offset: 0x009AD9AD
		// (set) Token: 0x060250C3 RID: 151747 RVA: 0x009AF7C2 File Offset: 0x009AD9C2
		public TSoftObjectPtr<PD_CloudPrefab_C> 乘宵山
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_19, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_19, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F45 RID: 20293
		// (get) Token: 0x060250C4 RID: 151748 RVA: 0x009AF7E7 File Offset: 0x009AD9E7
		// (set) Token: 0x060250C5 RID: 151749 RVA: 0x009AF7FC File Offset: 0x009AD9FC
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑海岸上层
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_20, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_20, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F46 RID: 20294
		// (get) Token: 0x060250C6 RID: 151750 RVA: 0x009AF821 File Offset: 0x009ADA21
		// (set) Token: 0x060250C7 RID: 151751 RVA: 0x009AF836 File Offset: 0x009ADA36
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑海岸下层
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_21, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_21, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F47 RID: 20295
		// (get) Token: 0x060250C8 RID: 151752 RVA: 0x009AF85B File Offset: 0x009ADA5B
		// (set) Token: 0x060250C9 RID: 151753 RVA: 0x009AF870 File Offset: 0x009ADA70
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑海岸夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_22, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_22, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F48 RID: 20296
		// (get) Token: 0x060250CA RID: 151754 RVA: 0x009AF895 File Offset: 0x009ADA95
		// (set) Token: 0x060250CB RID: 151755 RVA: 0x009AF8AA File Offset: 0x009ADAAA
		public TSoftObjectPtr<PD_CloudPrefab_C> 肉鸽月亮01
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_23, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_23, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F49 RID: 20297
		// (get) Token: 0x060250CC RID: 151756 RVA: 0x009AF8CF File Offset: 0x009ADACF
		// (set) Token: 0x060250CD RID: 151757 RVA: 0x009AF8E4 File Offset: 0x009ADAE4
		public TSoftObjectPtr<PD_CloudPrefab_C> 肉鸽月亮02
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_24, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_24, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F4A RID: 20298
		// (get) Token: 0x060250CE RID: 151758 RVA: 0x009AF909 File Offset: 0x009ADB09
		// (set) Token: 0x060250CF RID: 151759 RVA: 0x009AF91E File Offset: 0x009ADB1E
		public TSoftObjectPtr<PD_CloudPrefab_C> 肉鸽月亮03
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_25, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_25, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F4B RID: 20299
		// (get) Token: 0x060250D0 RID: 151760 RVA: 0x009AF943 File Offset: 0x009ADB43
		// (set) Token: 0x060250D1 RID: 151761 RVA: 0x009AF958 File Offset: 0x009ADB58
		public TSoftObjectPtr<PD_CloudPrefab_C> 肉鸽月亮04
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_26, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_26, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F4C RID: 20300
		// (get) Token: 0x060250D2 RID: 151762 RVA: 0x009AF97D File Offset: 0x009ADB7D
		// (set) Token: 0x060250D3 RID: 151763 RVA: 0x009AF992 File Offset: 0x009ADB92
		public TSoftObjectPtr<PD_CloudPrefab_C> 黎娜汐塔
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_27, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_27, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F4D RID: 20301
		// (get) Token: 0x060250D4 RID: 151764 RVA: 0x009AF9B7 File Offset: 0x009ADBB7
		// (set) Token: 0x060250D5 RID: 151765 RVA: 0x009AF9CC File Offset: 0x009ADBCC
		public TSoftObjectPtr<PD_CloudPrefab_C> 帕尔米罗墓地
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_28, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_28, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F4E RID: 20302
		// (get) Token: 0x060250D6 RID: 151766 RVA: 0x009AF9F1 File Offset: 0x009ADBF1
		// (set) Token: 0x060250D7 RID: 151767 RVA: 0x009AFA06 File Offset: 0x009ADC06
		public TSoftObjectPtr<PD_CloudPrefab_C> 槲生半岛
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_29, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_29, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F4F RID: 20303
		// (get) Token: 0x060250D8 RID: 151768 RVA: 0x009AFA2B File Offset: 0x009ADC2B
		// (set) Token: 0x060250D9 RID: 151769 RVA: 0x009AFA40 File Offset: 0x009ADC40
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄萨莱海脊永夜解密前
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_30, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_30, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F50 RID: 20304
		// (get) Token: 0x060250DA RID: 151770 RVA: 0x009AFA65 File Offset: 0x009ADC65
		// (set) Token: 0x060250DB RID: 151771 RVA: 0x009AFA7A File Offset: 0x009ADC7A
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄萨莱海脊永夜解密后
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_31, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_31, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F51 RID: 20305
		// (get) Token: 0x060250DC RID: 151772 RVA: 0x009AFA9F File Offset: 0x009ADC9F
		// (set) Token: 0x060250DD RID: 151773 RVA: 0x009AFAB4 File Offset: 0x009ADCB4
		public TSoftObjectPtr<PD_CloudPrefab_C> 金库上层
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_32, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_32, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F52 RID: 20306
		// (get) Token: 0x060250DE RID: 151774 RVA: 0x009AFAD9 File Offset: 0x009ADCD9
		// (set) Token: 0x060250DF RID: 151775 RVA: 0x009AFAEE File Offset: 0x009ADCEE
		public TSoftObjectPtr<PD_CloudPrefab_C> 肉鸽月亮05
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_33, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_33, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F53 RID: 20307
		// (get) Token: 0x060250E0 RID: 151776 RVA: 0x009AFB13 File Offset: 0x009ADD13
		// (set) Token: 0x060250E1 RID: 151777 RVA: 0x009AFB28 File Offset: 0x009ADD28
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑海岸天气_阴
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_34, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_34, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F54 RID: 20308
		// (get) Token: 0x060250E2 RID: 151778 RVA: 0x009AFB4D File Offset: 0x009ADD4D
		// (set) Token: 0x060250E3 RID: 151779 RVA: 0x009AFB62 File Offset: 0x009ADD62
		public TSoftObjectPtr<PD_CloudPrefab_C> 狂欢节
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_35, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_35, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F55 RID: 20309
		// (get) Token: 0x060250E4 RID: 151780 RVA: 0x009AFB87 File Offset: 0x009ADD87
		// (set) Token: 0x060250E5 RID: 151781 RVA: 0x009AFB9C File Offset: 0x009ADD9C
		public TSoftObjectPtr<PD_CloudPrefab_C> 槲生半岛解密后
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_36, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_36, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F56 RID: 20310
		// (get) Token: 0x060250E6 RID: 151782 RVA: 0x009AFBC1 File Offset: 0x009ADDC1
		// (set) Token: 0x060250E7 RID: 151783 RVA: 0x009AFBD6 File Offset: 0x009ADDD6
		public TSoftObjectPtr<PD_CloudPrefab_C> 云海区
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_37, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_37, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F57 RID: 20311
		// (get) Token: 0x060250E8 RID: 151784 RVA: 0x009AFBFB File Offset: 0x009ADDFB
		// (set) Token: 0x060250E9 RID: 151785 RVA: 0x009AFC10 File Offset: 0x009ADE10
		public TSoftObjectPtr<PD_CloudPrefab_C> 罗墓岛夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_38, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_38, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F58 RID: 20312
		// (get) Token: 0x060250EA RID: 151786 RVA: 0x009AFC35 File Offset: 0x009ADE35
		// (set) Token: 0x060250EB RID: 151787 RVA: 0x009AFC4A File Offset: 0x009ADE4A
		public TSoftObjectPtr<PD_CloudPrefab_C> 黎娜汐塔阴
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_39, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_39, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F59 RID: 20313
		// (get) Token: 0x060250EC RID: 151788 RVA: 0x009AFC6F File Offset: 0x009ADE6F
		// (set) Token: 0x060250ED RID: 151789 RVA: 0x009AFC84 File Offset: 0x009ADE84
		public TSoftObjectPtr<PD_CloudPrefab_C> 金库上解密后
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_40, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_40, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F5A RID: 20314
		// (get) Token: 0x060250EE RID: 151790 RVA: 0x009AFCA9 File Offset: 0x009ADEA9
		// (set) Token: 0x060250EF RID: 151791 RVA: 0x009AFCBE File Offset: 0x009ADEBE
		public TSoftObjectPtr<PD_CloudPrefab_C> 费洛洛出场
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_41, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_41, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F5B RID: 20315
		// (get) Token: 0x060250F0 RID: 151792 RVA: 0x009AFCE3 File Offset: 0x009ADEE3
		// (set) Token: 0x060250F1 RID: 151793 RVA: 0x009AFCF8 File Offset: 0x009ADEF8
		public TSoftObjectPtr<PD_CloudPrefab_C> 彩虹天气
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_42, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_42, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F5C RID: 20316
		// (get) Token: 0x060250F2 RID: 151794 RVA: 0x009AFD1D File Offset: 0x009ADF1D
		// (set) Token: 0x060250F3 RID: 151795 RVA: 0x009AFD32 File Offset: 0x009ADF32
		public TSoftObjectPtr<PD_CloudPrefab_C> 颠倒塔白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_43, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_43, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F5D RID: 20317
		// (get) Token: 0x060250F4 RID: 151796 RVA: 0x009AFD57 File Offset: 0x009ADF57
		// (set) Token: 0x060250F5 RID: 151797 RVA: 0x009AFD6C File Offset: 0x009ADF6C
		public TSoftObjectPtr<PD_CloudPrefab_C> 颠倒塔夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_44, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_44, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F5E RID: 20318
		// (get) Token: 0x060250F6 RID: 151798 RVA: 0x009AFD91 File Offset: 0x009ADF91
		// (set) Token: 0x060250F7 RID: 151799 RVA: 0x009AFDA6 File Offset: 0x009ADFA6
		public TSoftObjectPtr<PD_CloudPrefab_C> 颠倒塔流星
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_45, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_45, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F5F RID: 20319
		// (get) Token: 0x060250F8 RID: 151800 RVA: 0x009AFDCB File Offset: 0x009ADFCB
		// (set) Token: 0x060250F9 RID: 151801 RVA: 0x009AFDE0 File Offset: 0x009ADFE0
		public TSoftObjectPtr<PD_CloudPrefab_C> 七丘
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_46, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_46, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F60 RID: 20320
		// (get) Token: 0x060250FA RID: 151802 RVA: 0x009AFE05 File Offset: 0x009AE005
		// (set) Token: 0x060250FB RID: 151803 RVA: 0x009AFE1A File Offset: 0x009AE01A
		public TSoftObjectPtr<PD_CloudPrefab_C> 七丘阴天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_47, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_47, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F61 RID: 20321
		// (get) Token: 0x060250FC RID: 151804 RVA: 0x009AFE3F File Offset: 0x009AE03F
		// (set) Token: 0x060250FD RID: 151805 RVA: 0x009AFE54 File Offset: 0x009AE054
		public TSoftObjectPtr<PD_CloudPrefab_C> 残破竞技场
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_48, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_48, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F62 RID: 20322
		// (get) Token: 0x060250FE RID: 151806 RVA: 0x009AFE79 File Offset: 0x009AE079
		// (set) Token: 0x060250FF RID: 151807 RVA: 0x009AFE8E File Offset: 0x009AE08E
		public TSoftObjectPtr<PD_CloudPrefab_C> 尖刺山
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_49, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_49, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F63 RID: 20323
		// (get) Token: 0x06025100 RID: 151808 RVA: 0x009AFEB3 File Offset: 0x009AE0B3
		// (set) Token: 0x06025101 RID: 151809 RVA: 0x009AFEC8 File Offset: 0x009AE0C8
		public TSoftObjectPtr<PD_CloudPrefab_C> 观测塔
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_50, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_50, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F64 RID: 20324
		// (get) Token: 0x06025102 RID: 151810 RVA: 0x009AFEED File Offset: 0x009AE0ED
		// (set) Token: 0x06025103 RID: 151811 RVA: 0x009AFF02 File Offset: 0x009AE102
		public TSoftObjectPtr<PD_CloudPrefab_C> 初见七丘
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_51, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_51, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F65 RID: 20325
		// (get) Token: 0x06025104 RID: 151812 RVA: 0x009AFF27 File Offset: 0x009AE127
		// (set) Token: 0x06025105 RID: 151813 RVA: 0x009AFF3C File Offset: 0x009AE13C
		public TSoftObjectPtr<PD_CloudPrefab_C> 七丘夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_52, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_52, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F66 RID: 20326
		// (get) Token: 0x06025106 RID: 151814 RVA: 0x009AFF61 File Offset: 0x009AE161
		// (set) Token: 0x06025107 RID: 151815 RVA: 0x009AFF76 File Offset: 0x009AE176
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄斯台地白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_53, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_53, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F67 RID: 20327
		// (get) Token: 0x06025108 RID: 151816 RVA: 0x009AFF9B File Offset: 0x009AE19B
		// (set) Token: 0x06025109 RID: 151817 RVA: 0x009AFFB0 File Offset: 0x009AE1B0
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄斯台地夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_54, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_54, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F68 RID: 20328
		// (get) Token: 0x0602510A RID: 151818 RVA: 0x009AFFD5 File Offset: 0x009AE1D5
		// (set) Token: 0x0602510B RID: 151819 RVA: 0x009AFFEA File Offset: 0x009AE1EA
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄斯台地日月同辉
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_55, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_55, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F69 RID: 20329
		// (get) Token: 0x0602510C RID: 151820 RVA: 0x009B000F File Offset: 0x009AE20F
		// (set) Token: 0x0602510D RID: 151821 RVA: 0x009B0024 File Offset: 0x009AE224
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄斯台地烈日天空
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_56, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_56, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F6A RID: 20330
		// (get) Token: 0x0602510E RID: 151822 RVA: 0x009B0049 File Offset: 0x009AE249
		// (set) Token: 0x0602510F RID: 151823 RVA: 0x009B005E File Offset: 0x009AE25E
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄斯台地受蚀地
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_57, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_57, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F6B RID: 20331
		// (get) Token: 0x06025110 RID: 151824 RVA: 0x009B0083 File Offset: 0x009AE283
		// (set) Token: 0x06025111 RID: 151825 RVA: 0x009B0098 File Offset: 0x009AE298
		public TSoftObjectPtr<PD_CloudPrefab_C> 狄斯台地月相
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_58, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_58, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F6C RID: 20332
		// (get) Token: 0x06025112 RID: 151826 RVA: 0x009B00BD File Offset: 0x009AE2BD
		// (set) Token: 0x06025113 RID: 151827 RVA: 0x009B00D2 File Offset: 0x009AE2D2
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑潮侵蚀
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_59, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_59, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F6D RID: 20333
		// (get) Token: 0x06025114 RID: 151828 RVA: 0x009B00F7 File Offset: 0x009AE2F7
		// (set) Token: 0x06025115 RID: 151829 RVA: 0x009B010C File Offset: 0x009AE30C
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑潮内表世界
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_60, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_60, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F6E RID: 20334
		// (get) Token: 0x06025116 RID: 151830 RVA: 0x009B0131 File Offset: 0x009AE331
		// (set) Token: 0x06025117 RID: 151831 RVA: 0x009B0146 File Offset: 0x009AE346
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑潮内里世界
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_61, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_61, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F6F RID: 20335
		// (get) Token: 0x06025118 RID: 151832 RVA: 0x009B016B File Offset: 0x009AE36B
		// (set) Token: 0x06025119 RID: 151833 RVA: 0x009B0180 File Offset: 0x009AE380
		public TSoftObjectPtr<PD_CloudPrefab_C> 光路幻境
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_62, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_62, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F70 RID: 20336
		// (get) Token: 0x0602511A RID: 151834 RVA: 0x009B01A5 File Offset: 0x009AE3A5
		// (set) Token: 0x0602511B RID: 151835 RVA: 0x009B01BA File Offset: 0x009AE3BA
		public TSoftObjectPtr<PD_CloudPrefab_C> 巡游天国
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_63, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_63, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F71 RID: 20337
		// (get) Token: 0x0602511C RID: 151836 RVA: 0x009B01DF File Offset: 0x009AE3DF
		// (set) Token: 0x0602511D RID: 151837 RVA: 0x009B01F4 File Offset: 0x009AE3F4
		public TSoftObjectPtr<PD_CloudPrefab_C> 隐海试验场
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_64, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_64, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F72 RID: 20338
		// (get) Token: 0x0602511E RID: 151838 RVA: 0x009B0219 File Offset: 0x009AE419
		// (set) Token: 0x0602511F RID: 151839 RVA: 0x009B022E File Offset: 0x009AE42E
		public TSoftObjectPtr<PD_CloudPrefab_C> 失亡彼岸
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_65, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_65, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F73 RID: 20339
		// (get) Token: 0x06025120 RID: 151840 RVA: 0x009B0253 File Offset: 0x009AE453
		// (set) Token: 0x06025121 RID: 151841 RVA: 0x009B0268 File Offset: 0x009AE468
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑潮风暴
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_66, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_66, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F74 RID: 20340
		// (get) Token: 0x06025122 RID: 151842 RVA: 0x009B028D File Offset: 0x009AE48D
		// (set) Token: 0x06025123 RID: 151843 RVA: 0x009B02A2 File Offset: 0x009AE4A2
		public TSoftObjectPtr<PD_CloudPrefab_C> 黑潮风暴加强
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_67, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_67, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F75 RID: 20341
		// (get) Token: 0x06025124 RID: 151844 RVA: 0x009B02C7 File Offset: 0x009AE4C7
		// (set) Token: 0x06025125 RID: 151845 RVA: 0x009B02DC File Offset: 0x009AE4DC
		public TSoftObjectPtr<PD_CloudPrefab_C> 烈阳天气
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_68, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_68, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F76 RID: 20342
		// (get) Token: 0x06025126 RID: 151846 RVA: 0x009B0301 File Offset: 0x009AE501
		// (set) Token: 0x06025127 RID: 151847 RVA: 0x009B0316 File Offset: 0x009AE516
		public TSoftObjectPtr<PD_CloudPrefab_C> 总督日月同辉
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_69, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_69, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F77 RID: 20343
		// (get) Token: 0x06025128 RID: 151848 RVA: 0x009B033B File Offset: 0x009AE53B
		// (set) Token: 0x06025129 RID: 151849 RVA: 0x009B0350 File Offset: 0x009AE550
		public TSoftObjectPtr<PD_CloudPrefab_C> 穗波白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_70, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_70, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F78 RID: 20344
		// (get) Token: 0x0602512A RID: 151850 RVA: 0x009B0375 File Offset: 0x009AE575
		// (set) Token: 0x0602512B RID: 151851 RVA: 0x009B038A File Offset: 0x009AE58A
		public TSoftObjectPtr<PD_CloudPrefab_C> 穗波夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_71, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_71, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F79 RID: 20345
		// (get) Token: 0x0602512C RID: 151852 RVA: 0x009B03AF File Offset: 0x009AE5AF
		// (set) Token: 0x0602512D RID: 151853 RVA: 0x009B03C4 File Offset: 0x009AE5C4
		public TSoftObjectPtr<PD_CloudPrefab_C> 穗波枯山水
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_72, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_72, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F7A RID: 20346
		// (get) Token: 0x0602512E RID: 151854 RVA: 0x009B03E9 File Offset: 0x009AE5E9
		// (set) Token: 0x0602512F RID: 151855 RVA: 0x009B03FE File Offset: 0x009AE5FE
		public TSoftObjectPtr<PD_CloudPrefab_C> 穗波阴天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_73, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_73, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F7B RID: 20347
		// (get) Token: 0x06025130 RID: 151856 RVA: 0x009B0423 File Offset: 0x009AE623
		// (set) Token: 0x06025131 RID: 151857 RVA: 0x009B0438 File Offset: 0x009AE638
		public TSoftObjectPtr<PD_CloudPrefab_C> 安全点白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_74, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_74, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F7C RID: 20348
		// (get) Token: 0x06025132 RID: 151858 RVA: 0x009B045D File Offset: 0x009AE65D
		// (set) Token: 0x06025133 RID: 151859 RVA: 0x009B0472 File Offset: 0x009AE672
		public TSoftObjectPtr<PD_CloudPrefab_C> 安全点夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_75, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_75, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F7D RID: 20349
		// (get) Token: 0x06025134 RID: 151860 RVA: 0x009B0497 File Offset: 0x009AE697
		// (set) Token: 0x06025135 RID: 151861 RVA: 0x009B04AC File Offset: 0x009AE6AC
		public TSoftObjectPtr<PD_CloudPrefab_C> 拉海落白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_76, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_76, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F7E RID: 20350
		// (get) Token: 0x06025136 RID: 151862 RVA: 0x009B04D1 File Offset: 0x009AE6D1
		// (set) Token: 0x06025137 RID: 151863 RVA: 0x009B04E6 File Offset: 0x009AE6E6
		public TSoftObjectPtr<PD_CloudPrefab_C> 拉海洛夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_77, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_77, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F7F RID: 20351
		// (get) Token: 0x06025138 RID: 151864 RVA: 0x009B050B File Offset: 0x009AE70B
		// (set) Token: 0x06025139 RID: 151865 RVA: 0x009B0520 File Offset: 0x009AE720
		public TSoftObjectPtr<PD_CloudPrefab_C> 磁暴前置
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_78, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_78, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F80 RID: 20352
		// (get) Token: 0x0602513A RID: 151866 RVA: 0x009B0545 File Offset: 0x009AE745
		// (set) Token: 0x0602513B RID: 151867 RVA: 0x009B055A File Offset: 0x009AE75A
		public TSoftObjectPtr<PD_CloudPrefab_C> 磁暴后置
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_79, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_79, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F81 RID: 20353
		// (get) Token: 0x0602513C RID: 151868 RVA: 0x009B057F File Offset: 0x009AE77F
		// (set) Token: 0x0602513D RID: 151869 RVA: 0x009B0594 File Offset: 0x009AE794
		public TSoftObjectPtr<PD_CloudPrefab_C> 星门Boss
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_80, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_80, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F82 RID: 20354
		// (get) Token: 0x0602513E RID: 151870 RVA: 0x009B05B9 File Offset: 0x009AE7B9
		// (set) Token: 0x0602513F RID: 151871 RVA: 0x009B05CE File Offset: 0x009AE7CE
		public TSoftObjectPtr<PD_CloudPrefab_C> 坠落炉芯
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_81, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_81, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F83 RID: 20355
		// (get) Token: 0x06025140 RID: 151872 RVA: 0x009B05F3 File Offset: 0x009AE7F3
		// (set) Token: 0x06025141 RID: 151873 RVA: 0x009B0608 File Offset: 0x009AE808
		public TSoftObjectPtr<PD_CloudPrefab_C> 炉芯内部
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_82, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_82, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F84 RID: 20356
		// (get) Token: 0x06025142 RID: 151874 RVA: 0x009B062D File Offset: 0x009AE82D
		// (set) Token: 0x06025143 RID: 151875 RVA: 0x009B0642 File Offset: 0x009AE842
		public TSoftObjectPtr<PD_CloudPrefab_C> 炉芯领主
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_83, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_83, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F85 RID: 20357
		// (get) Token: 0x06025144 RID: 151876 RVA: 0x009B0667 File Offset: 0x009AE867
		// (set) Token: 0x06025145 RID: 151877 RVA: 0x009B067C File Offset: 0x009AE87C
		public TSoftObjectPtr<PD_CloudPrefab_C> 浮光林白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_84, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_84, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F86 RID: 20358
		// (get) Token: 0x06025146 RID: 151878 RVA: 0x009B06A1 File Offset: 0x009AE8A1
		// (set) Token: 0x06025147 RID: 151879 RVA: 0x009B06B6 File Offset: 0x009AE8B6
		public TSoftObjectPtr<PD_CloudPrefab_C> 浮光林夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_85, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_85, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F87 RID: 20359
		// (get) Token: 0x06025148 RID: 151880 RVA: 0x009B06DB File Offset: 0x009AE8DB
		// (set) Token: 0x06025149 RID: 151881 RVA: 0x009B06F0 File Offset: 0x009AE8F0
		public TSoftObjectPtr<PD_CloudPrefab_C> 拉海洛阴天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_86, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_86, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F88 RID: 20360
		// (get) Token: 0x0602514A RID: 151882 RVA: 0x009B0715 File Offset: 0x009AE915
		// (set) Token: 0x0602514B RID: 151883 RVA: 0x009B072A File Offset: 0x009AE92A
		public TSoftObjectPtr<PD_CloudPrefab_C> 梵高
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_87, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_87, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F89 RID: 20361
		// (get) Token: 0x0602514C RID: 151884 RVA: 0x009B074F File Offset: 0x009AE94F
		// (set) Token: 0x0602514D RID: 151885 RVA: 0x009B0764 File Offset: 0x009AE964
		public TSoftObjectPtr<PD_CloudPrefab_C> 不渲染BP_Cloud控制的云
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_88, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_88, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F8A RID: 20362
		// (get) Token: 0x0602514E RID: 151886 RVA: 0x009B0789 File Offset: 0x009AE989
		// (set) Token: 0x0602514F RID: 151887 RVA: 0x009B079E File Offset: 0x009AE99E
		public TSoftObjectPtr<PD_CloudPrefab_C> 罗伊白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_89, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_89, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F8B RID: 20363
		// (get) Token: 0x06025150 RID: 151888 RVA: 0x009B07C3 File Offset: 0x009AE9C3
		// (set) Token: 0x06025151 RID: 151889 RVA: 0x009B07D8 File Offset: 0x009AE9D8
		public TSoftObjectPtr<PD_CloudPrefab_C> 罗伊夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_90, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_90, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F8C RID: 20364
		// (get) Token: 0x06025152 RID: 151890 RVA: 0x009B07FD File Offset: 0x009AE9FD
		// (set) Token: 0x06025153 RID: 151891 RVA: 0x009B0812 File Offset: 0x009AEA12
		public TSoftObjectPtr<PD_CloudPrefab_C> 罗伊极光
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_91, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_91, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F8D RID: 20365
		// (get) Token: 0x06025154 RID: 151892 RVA: 0x009B0837 File Offset: 0x009AEA37
		// (set) Token: 0x06025155 RID: 151893 RVA: 0x009B084C File Offset: 0x009AEA4C
		public TSoftObjectPtr<PD_CloudPrefab_C> 罗伊初见
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_92, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_92, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F8E RID: 20366
		// (get) Token: 0x06025156 RID: 151894 RVA: 0x009B0871 File Offset: 0x009AEA71
		// (set) Token: 0x06025157 RID: 151895 RVA: 0x009B0886 File Offset: 0x009AEA86
		public TSoftObjectPtr<PD_CloudPrefab_C> 星海BOSS一阶
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_93, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_93, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F8F RID: 20367
		// (get) Token: 0x06025158 RID: 151896 RVA: 0x009B08AB File Offset: 0x009AEAAB
		// (set) Token: 0x06025159 RID: 151897 RVA: 0x009B08C0 File Offset: 0x009AEAC0
		public TSoftObjectPtr<PD_CloudPrefab_C> 星海BOSS二阶
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_94, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_94, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F90 RID: 20368
		// (get) Token: 0x0602515A RID: 151898 RVA: 0x009B08E5 File Offset: 0x009AEAE5
		// (set) Token: 0x0602515B RID: 151899 RVA: 0x009B08FA File Offset: 0x009AEAFA
		public TSoftObjectPtr<PD_CloudPrefab_C> 拉海洛初见
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_95, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_95, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F91 RID: 20369
		// (get) Token: 0x0602515C RID: 151900 RVA: 0x009B091F File Offset: 0x009AEB1F
		// (set) Token: 0x0602515D RID: 151901 RVA: 0x009B0934 File Offset: 0x009AEB34
		public TSoftObjectPtr<PD_CloudPrefab_C> 罗伊红色极光
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_96, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_96, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F92 RID: 20370
		// (get) Token: 0x0602515E RID: 151902 RVA: 0x009B0959 File Offset: 0x009AEB59
		// (set) Token: 0x0602515F RID: 151903 RVA: 0x009B096E File Offset: 0x009AEB6E
		public TSoftObjectPtr<PD_CloudPrefab_C> 日灵棺解密前
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_97, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_97, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F93 RID: 20371
		// (get) Token: 0x06025160 RID: 151904 RVA: 0x009B0993 File Offset: 0x009AEB93
		// (set) Token: 0x06025161 RID: 151905 RVA: 0x009B09A8 File Offset: 0x009AEBA8
		public TSoftObjectPtr<PD_CloudPrefab_C> 日灵棺解密后
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_98, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_98, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F94 RID: 20372
		// (get) Token: 0x06025162 RID: 151906 RVA: 0x009B09CD File Offset: 0x009AEBCD
		// (set) Token: 0x06025163 RID: 151907 RVA: 0x009B09E2 File Offset: 0x009AEBE2
		public TSoftObjectPtr<PD_CloudPrefab_C> 高达Boss一阶
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_99, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_99, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F95 RID: 20373
		// (get) Token: 0x06025164 RID: 151908 RVA: 0x009B0A07 File Offset: 0x009AEC07
		// (set) Token: 0x06025165 RID: 151909 RVA: 0x009B0A1C File Offset: 0x009AEC1C
		public TSoftObjectPtr<PD_CloudPrefab_C> 高达Boss三阶
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_100, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_100, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F96 RID: 20374
		// (get) Token: 0x06025166 RID: 151910 RVA: 0x009B0A41 File Offset: 0x009AEC41
		// (set) Token: 0x06025167 RID: 151911 RVA: 0x009B0A56 File Offset: 0x009AEC56
		public TSoftObjectPtr<PD_CloudPrefab_C> 梦州白天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_101, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_101, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F97 RID: 20375
		// (get) Token: 0x06025168 RID: 151912 RVA: 0x009B0A7B File Offset: 0x009AEC7B
		// (set) Token: 0x06025169 RID: 151913 RVA: 0x009B0A90 File Offset: 0x009AEC90
		public TSoftObjectPtr<PD_CloudPrefab_C> 梦州夜晚
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_102, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_102, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F98 RID: 20376
		// (get) Token: 0x0602516A RID: 151914 RVA: 0x009B0AB5 File Offset: 0x009AECB5
		// (set) Token: 0x0602516B RID: 151915 RVA: 0x009B0ACA File Offset: 0x009AECCA
		public TSoftObjectPtr<PD_CloudPrefab_C> 梦州阴天
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_103, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_103, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F99 RID: 20377
		// (get) Token: 0x0602516C RID: 151916 RVA: 0x009B0AEF File Offset: 0x009AECEF
		// (set) Token: 0x0602516D RID: 151917 RVA: 0x009B0B04 File Offset: 0x009AED04
		public TSoftObjectPtr<PD_CloudPrefab_C> 梦州初见
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_104, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_104, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F9A RID: 20378
		// (get) Token: 0x0602516E RID: 151918 RVA: 0x009B0B29 File Offset: 0x009AED29
		// (set) Token: 0x0602516F RID: 151919 RVA: 0x009B0B3E File Offset: 0x009AED3E
		public TSoftObjectPtr<PD_CloudPrefab_C> 宅邸解谜前
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_105, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_105, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F9B RID: 20379
		// (get) Token: 0x06025170 RID: 151920 RVA: 0x009B0B63 File Offset: 0x009AED63
		// (set) Token: 0x06025171 RID: 151921 RVA: 0x009B0B78 File Offset: 0x009AED78
		public TSoftObjectPtr<PD_CloudPrefab_C> 宅邸解谜后
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_106, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_106, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F9C RID: 20380
		// (get) Token: 0x06025172 RID: 151922 RVA: 0x009B0B9D File Offset: 0x009AED9D
		// (set) Token: 0x06025173 RID: 151923 RVA: 0x009B0BB2 File Offset: 0x009AEDB2
		public TSoftObjectPtr<PD_CloudPrefab_C> 梦州特殊1
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_107, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_107, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F9D RID: 20381
		// (get) Token: 0x06025174 RID: 151924 RVA: 0x009B0BD7 File Offset: 0x009AEDD7
		// (set) Token: 0x06025175 RID: 151925 RVA: 0x009B0BEC File Offset: 0x009AEDEC
		public TSoftObjectPtr<PD_CloudPrefab_C> 梦州特殊2
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_108, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_108, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F9E RID: 20382
		// (get) Token: 0x06025176 RID: 151926 RVA: 0x009B0C11 File Offset: 0x009AEE11
		// (set) Token: 0x06025177 RID: 151927 RVA: 0x009B0C26 File Offset: 0x009AEE26
		public TSoftObjectPtr<PD_CloudPrefab_C> 人境
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_109, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_109, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004F9F RID: 20383
		// (get) Token: 0x06025178 RID: 151928 RVA: 0x009B0C4B File Offset: 0x009AEE4B
		// (set) Token: 0x06025179 RID: 151929 RVA: 0x009B0C60 File Offset: 0x009AEE60
		public TSoftObjectPtr<PD_CloudPrefab_C> 地境
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_110, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_110, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004FA0 RID: 20384
		// (get) Token: 0x0602517A RID: 151930 RVA: 0x009B0C85 File Offset: 0x009AEE85
		// (set) Token: 0x0602517B RID: 151931 RVA: 0x009B0C9A File Offset: 0x009AEE9A
		public TSoftObjectPtr<PD_CloudPrefab_C> 天境
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_111, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_111, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004FA1 RID: 20385
		// (get) Token: 0x0602517C RID: 151932 RVA: 0x009B0CBF File Offset: 0x009AEEBF
		// (set) Token: 0x0602517D RID: 151933 RVA: 0x009B0CD4 File Offset: 0x009AEED4
		public TSoftObjectPtr<PD_CloudPrefab_C> 心湖
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_112, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_112, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004FA2 RID: 20386
		// (get) Token: 0x0602517E RID: 151934 RVA: 0x009B0CF9 File Offset: 0x009AEEF9
		// (set) Token: 0x0602517F RID: 151935 RVA: 0x009B0D0E File Offset: 0x009AEF0E
		public TSoftObjectPtr<PD_CloudPrefab_C> 火匣
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_113, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_113, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004FA3 RID: 20387
		// (get) Token: 0x06025180 RID: 151936 RVA: 0x009B0D33 File Offset: 0x009AEF33
		// (set) Token: 0x06025181 RID: 151937 RVA: 0x009B0D48 File Offset: 0x009AEF48
		public TSoftObjectPtr<PD_CloudPrefab_C> 水匣
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_114, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_114, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004FA4 RID: 20388
		// (get) Token: 0x06025182 RID: 151938 RVA: 0x009B0D6D File Offset: 0x009AEF6D
		// (set) Token: 0x06025183 RID: 151939 RVA: 0x009B0D82 File Offset: 0x009AEF82
		public TSoftObjectPtr<PD_CloudPrefab_C> 金匣
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_115, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_115, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004FA5 RID: 20389
		// (get) Token: 0x06025184 RID: 151940 RVA: 0x009B0DA7 File Offset: 0x009AEFA7
		// (set) Token: 0x06025185 RID: 151941 RVA: 0x009B0DBC File Offset: 0x009AEFBC
		public TSoftObjectPtr<PD_CloudPrefab_C> 天演幻心
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_116, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_116, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004FA6 RID: 20390
		// (get) Token: 0x06025186 RID: 151942 RVA: 0x009B0DE1 File Offset: 0x009AEFE1
		// (set) Token: 0x06025187 RID: 151943 RVA: 0x009B0DF6 File Offset: 0x009AEFF6
		public TSoftObjectPtr<PD_CloudPrefab_C> 天演幻心二阶段
		{
			get
			{
				return new TSoftObjectPtr<PD_CloudPrefab_C>(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_117, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)PD_CloudPreset_C.__PropertyOffset_117, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06025188 RID: 151944 RVA: 0x009B0E1B File Offset: 0x009AF01B
		protected PD_CloudPreset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013118 RID: 78104
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/PD_CloudPreset.PD_CloudPreset_C";

		// Token: 0x04013119 RID: 78105
		private static IntPtr _ClassPtr;

		// Token: 0x0401311A RID: 78106
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401311B RID: 78107
		internal static int __PropertyOffset_0;

		// Token: 0x0401311C RID: 78108
		internal static int __PropertyOffset_1;

		// Token: 0x0401311D RID: 78109
		internal static int __PropertyOffset_2;

		// Token: 0x0401311E RID: 78110
		internal static int __PropertyOffset_3;

		// Token: 0x0401311F RID: 78111
		internal static int __PropertyOffset_4;

		// Token: 0x04013120 RID: 78112
		internal static int __PropertyOffset_5;

		// Token: 0x04013121 RID: 78113
		internal static int __PropertyOffset_6;

		// Token: 0x04013122 RID: 78114
		internal static int __PropertyOffset_7;

		// Token: 0x04013123 RID: 78115
		internal static int __PropertyOffset_8;

		// Token: 0x04013124 RID: 78116
		internal static int __PropertyOffset_9;

		// Token: 0x04013125 RID: 78117
		internal static int __PropertyOffset_10;

		// Token: 0x04013126 RID: 78118
		internal static int __PropertyOffset_11;

		// Token: 0x04013127 RID: 78119
		internal static int __PropertyOffset_12;

		// Token: 0x04013128 RID: 78120
		internal static int __PropertyOffset_13;

		// Token: 0x04013129 RID: 78121
		internal static int __PropertyOffset_14;

		// Token: 0x0401312A RID: 78122
		internal static int __PropertyOffset_15;

		// Token: 0x0401312B RID: 78123
		internal static int __PropertyOffset_16;

		// Token: 0x0401312C RID: 78124
		internal static int __PropertyOffset_17;

		// Token: 0x0401312D RID: 78125
		internal static int __PropertyOffset_18;

		// Token: 0x0401312E RID: 78126
		internal static int __PropertyOffset_19;

		// Token: 0x0401312F RID: 78127
		internal static int __PropertyOffset_20;

		// Token: 0x04013130 RID: 78128
		internal static int __PropertyOffset_21;

		// Token: 0x04013131 RID: 78129
		internal static int __PropertyOffset_22;

		// Token: 0x04013132 RID: 78130
		internal static int __PropertyOffset_23;

		// Token: 0x04013133 RID: 78131
		internal static int __PropertyOffset_24;

		// Token: 0x04013134 RID: 78132
		internal static int __PropertyOffset_25;

		// Token: 0x04013135 RID: 78133
		internal static int __PropertyOffset_26;

		// Token: 0x04013136 RID: 78134
		internal static int __PropertyOffset_27;

		// Token: 0x04013137 RID: 78135
		internal static int __PropertyOffset_28;

		// Token: 0x04013138 RID: 78136
		internal static int __PropertyOffset_29;

		// Token: 0x04013139 RID: 78137
		internal static int __PropertyOffset_30;

		// Token: 0x0401313A RID: 78138
		internal static int __PropertyOffset_31;

		// Token: 0x0401313B RID: 78139
		internal static int __PropertyOffset_32;

		// Token: 0x0401313C RID: 78140
		internal static int __PropertyOffset_33;

		// Token: 0x0401313D RID: 78141
		internal static int __PropertyOffset_34;

		// Token: 0x0401313E RID: 78142
		internal static int __PropertyOffset_35;

		// Token: 0x0401313F RID: 78143
		internal static int __PropertyOffset_36;

		// Token: 0x04013140 RID: 78144
		internal static int __PropertyOffset_37;

		// Token: 0x04013141 RID: 78145
		internal static int __PropertyOffset_38;

		// Token: 0x04013142 RID: 78146
		internal static int __PropertyOffset_39;

		// Token: 0x04013143 RID: 78147
		internal static int __PropertyOffset_40;

		// Token: 0x04013144 RID: 78148
		internal static int __PropertyOffset_41;

		// Token: 0x04013145 RID: 78149
		internal static int __PropertyOffset_42;

		// Token: 0x04013146 RID: 78150
		internal static int __PropertyOffset_43;

		// Token: 0x04013147 RID: 78151
		internal static int __PropertyOffset_44;

		// Token: 0x04013148 RID: 78152
		internal static int __PropertyOffset_45;

		// Token: 0x04013149 RID: 78153
		internal static int __PropertyOffset_46;

		// Token: 0x0401314A RID: 78154
		internal static int __PropertyOffset_47;

		// Token: 0x0401314B RID: 78155
		internal static int __PropertyOffset_48;

		// Token: 0x0401314C RID: 78156
		internal static int __PropertyOffset_49;

		// Token: 0x0401314D RID: 78157
		internal static int __PropertyOffset_50;

		// Token: 0x0401314E RID: 78158
		internal static int __PropertyOffset_51;

		// Token: 0x0401314F RID: 78159
		internal static int __PropertyOffset_52;

		// Token: 0x04013150 RID: 78160
		internal static int __PropertyOffset_53;

		// Token: 0x04013151 RID: 78161
		internal static int __PropertyOffset_54;

		// Token: 0x04013152 RID: 78162
		internal static int __PropertyOffset_55;

		// Token: 0x04013153 RID: 78163
		internal static int __PropertyOffset_56;

		// Token: 0x04013154 RID: 78164
		internal static int __PropertyOffset_57;

		// Token: 0x04013155 RID: 78165
		internal static int __PropertyOffset_58;

		// Token: 0x04013156 RID: 78166
		internal static int __PropertyOffset_59;

		// Token: 0x04013157 RID: 78167
		internal static int __PropertyOffset_60;

		// Token: 0x04013158 RID: 78168
		internal static int __PropertyOffset_61;

		// Token: 0x04013159 RID: 78169
		internal static int __PropertyOffset_62;

		// Token: 0x0401315A RID: 78170
		internal static int __PropertyOffset_63;

		// Token: 0x0401315B RID: 78171
		internal static int __PropertyOffset_64;

		// Token: 0x0401315C RID: 78172
		internal static int __PropertyOffset_65;

		// Token: 0x0401315D RID: 78173
		internal static int __PropertyOffset_66;

		// Token: 0x0401315E RID: 78174
		internal static int __PropertyOffset_67;

		// Token: 0x0401315F RID: 78175
		internal static int __PropertyOffset_68;

		// Token: 0x04013160 RID: 78176
		internal static int __PropertyOffset_69;

		// Token: 0x04013161 RID: 78177
		internal static int __PropertyOffset_70;

		// Token: 0x04013162 RID: 78178
		internal static int __PropertyOffset_71;

		// Token: 0x04013163 RID: 78179
		internal static int __PropertyOffset_72;

		// Token: 0x04013164 RID: 78180
		internal static int __PropertyOffset_73;

		// Token: 0x04013165 RID: 78181
		internal static int __PropertyOffset_74;

		// Token: 0x04013166 RID: 78182
		internal static int __PropertyOffset_75;

		// Token: 0x04013167 RID: 78183
		internal static int __PropertyOffset_76;

		// Token: 0x04013168 RID: 78184
		internal static int __PropertyOffset_77;

		// Token: 0x04013169 RID: 78185
		internal static int __PropertyOffset_78;

		// Token: 0x0401316A RID: 78186
		internal static int __PropertyOffset_79;

		// Token: 0x0401316B RID: 78187
		internal static int __PropertyOffset_80;

		// Token: 0x0401316C RID: 78188
		internal static int __PropertyOffset_81;

		// Token: 0x0401316D RID: 78189
		internal static int __PropertyOffset_82;

		// Token: 0x0401316E RID: 78190
		internal static int __PropertyOffset_83;

		// Token: 0x0401316F RID: 78191
		internal static int __PropertyOffset_84;

		// Token: 0x04013170 RID: 78192
		internal static int __PropertyOffset_85;

		// Token: 0x04013171 RID: 78193
		internal static int __PropertyOffset_86;

		// Token: 0x04013172 RID: 78194
		internal static int __PropertyOffset_87;

		// Token: 0x04013173 RID: 78195
		internal static int __PropertyOffset_88;

		// Token: 0x04013174 RID: 78196
		internal static int __PropertyOffset_89;

		// Token: 0x04013175 RID: 78197
		internal static int __PropertyOffset_90;

		// Token: 0x04013176 RID: 78198
		internal static int __PropertyOffset_91;

		// Token: 0x04013177 RID: 78199
		internal static int __PropertyOffset_92;

		// Token: 0x04013178 RID: 78200
		internal static int __PropertyOffset_93;

		// Token: 0x04013179 RID: 78201
		internal static int __PropertyOffset_94;

		// Token: 0x0401317A RID: 78202
		internal static int __PropertyOffset_95;

		// Token: 0x0401317B RID: 78203
		internal static int __PropertyOffset_96;

		// Token: 0x0401317C RID: 78204
		internal static int __PropertyOffset_97;

		// Token: 0x0401317D RID: 78205
		internal static int __PropertyOffset_98;

		// Token: 0x0401317E RID: 78206
		internal static int __PropertyOffset_99;

		// Token: 0x0401317F RID: 78207
		internal static int __PropertyOffset_100;

		// Token: 0x04013180 RID: 78208
		internal static int __PropertyOffset_101;

		// Token: 0x04013181 RID: 78209
		internal static int __PropertyOffset_102;

		// Token: 0x04013182 RID: 78210
		internal static int __PropertyOffset_103;

		// Token: 0x04013183 RID: 78211
		internal static int __PropertyOffset_104;

		// Token: 0x04013184 RID: 78212
		internal static int __PropertyOffset_105;

		// Token: 0x04013185 RID: 78213
		internal static int __PropertyOffset_106;

		// Token: 0x04013186 RID: 78214
		internal static int __PropertyOffset_107;

		// Token: 0x04013187 RID: 78215
		internal static int __PropertyOffset_108;

		// Token: 0x04013188 RID: 78216
		internal static int __PropertyOffset_109;

		// Token: 0x04013189 RID: 78217
		internal static int __PropertyOffset_110;

		// Token: 0x0401318A RID: 78218
		internal static int __PropertyOffset_111;

		// Token: 0x0401318B RID: 78219
		internal static int __PropertyOffset_112;

		// Token: 0x0401318C RID: 78220
		internal static int __PropertyOffset_113;

		// Token: 0x0401318D RID: 78221
		internal static int __PropertyOffset_114;

		// Token: 0x0401318E RID: 78222
		internal static int __PropertyOffset_115;

		// Token: 0x0401318F RID: 78223
		internal static int __PropertyOffset_116;

		// Token: 0x04013190 RID: 78224
		internal static int __PropertyOffset_117;
	}
}
