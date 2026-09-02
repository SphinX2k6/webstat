using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP.Thunder
{
	// Token: 0x02003A05 RID: 14853
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_ThunderConfig.PDA_ThunderConfig_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1081)]
	public class PDA_ThunderConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E43A RID: 123962 RVA: 0x008F143C File Offset: 0x008EF63C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_ThunderConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_ThunderConfig.PDA_ThunderConfig_C");
			}
			return PDA_ThunderConfig_C._ClassPtr;
		}

		// Token: 0x0601E43B RID: 123963 RVA: 0x008F1460 File Offset: 0x008EF660
		public PDA_ThunderConfig_C() : this(BuiltinUtils.AllocNativeUObject(PDA_ThunderConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E43C RID: 123964 RVA: 0x008F1488 File Offset: 0x008EF688
		public PDA_ThunderConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_ThunderConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700293D RID: 10557
		// (get) Token: 0x0601E43D RID: 123965 RVA: 0x008F14BB File Offset: 0x008EF6BB
		// (set) Token: 0x0601E43E RID: 123966 RVA: 0x008F14CB File Offset: 0x008EF6CB
		public unsafe float 落雷概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700293E RID: 10558
		// (get) Token: 0x0601E43F RID: 123967 RVA: 0x008F14DC File Offset: 0x008EF6DC
		// (set) Token: 0x0601E440 RID: 123968 RVA: 0x008F14EC File Offset: 0x008EF6EC
		public unsafe float 雷落地概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700293F RID: 10559
		// (get) Token: 0x0601E441 RID: 123969 RVA: 0x008F14FD File Offset: 0x008EF6FD
		// (set) Token: 0x0601E442 RID: 123970 RVA: 0x008F150D File Offset: 0x008EF70D
		public unsafe float 落雷间隔Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002940 RID: 10560
		// (get) Token: 0x0601E443 RID: 123971 RVA: 0x008F151E File Offset: 0x008EF71E
		// (set) Token: 0x0601E444 RID: 123972 RVA: 0x008F152E File Offset: 0x008EF72E
		public unsafe float 落雷间隔Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002941 RID: 10561
		// (get) Token: 0x0601E445 RID: 123973 RVA: 0x008F153F File Offset: 0x008EF73F
		// (set) Token: 0x0601E446 RID: 123974 RVA: 0x008F1553 File Offset: 0x008EF753
		[Nullable(2)]
		public unsafe UNiagaraSystem ThunderNiagara
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002942 RID: 10562
		// (get) Token: 0x0601E447 RID: 123975 RVA: 0x008F1568 File Offset: 0x008EF768
		// (set) Token: 0x0601E448 RID: 123976 RVA: 0x008F15A1 File Offset: 0x008EF7A1
		public FKuroCurveFloat 灯光强度曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._灯光强度曲线) == null)
				{
					result = (this._灯光强度曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002943 RID: 10563
		// (get) Token: 0x0601E449 RID: 123977 RVA: 0x008F15C4 File Offset: 0x008EF7C4
		// (set) Token: 0x0601E44A RID: 123978 RVA: 0x008F15FD File Offset: 0x008EF7FD
		public FKuroCurveFloat 灯光半径曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._灯光半径曲线) == null)
				{
					result = (this._灯光半径曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002944 RID: 10564
		// (get) Token: 0x0601E44B RID: 123979 RVA: 0x008F1620 File Offset: 0x008EF820
		// (set) Token: 0x0601E44C RID: 123980 RVA: 0x008F1659 File Offset: 0x008EF859
		public FKuroCurveFloat 后处理强度曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._后处理强度曲线) == null)
				{
					result = (this._后处理强度曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002945 RID: 10565
		// (get) Token: 0x0601E44D RID: 123981 RVA: 0x008F167A File Offset: 0x008EF87A
		// (set) Token: 0x0601E44E RID: 123982 RVA: 0x008F168A File Offset: 0x008EF88A
		public unsafe float 落雷内半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002946 RID: 10566
		// (get) Token: 0x0601E44F RID: 123983 RVA: 0x008F169B File Offset: 0x008EF89B
		// (set) Token: 0x0601E450 RID: 123984 RVA: 0x008F16AB File Offset: 0x008EF8AB
		public unsafe float 落雷外半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002947 RID: 10567
		// (get) Token: 0x0601E451 RID: 123985 RVA: 0x008F16BC File Offset: 0x008EF8BC
		// (set) Token: 0x0601E452 RID: 123986 RVA: 0x008F16CC File Offset: 0x008EF8CC
		public unsafe float 位置系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002948 RID: 10568
		// (get) Token: 0x0601E453 RID: 123987 RVA: 0x008F16DD File Offset: 0x008EF8DD
		// (set) Token: 0x0601E454 RID: 123988 RVA: 0x008F16ED File Offset: 0x008EF8ED
		public unsafe float 射线高度Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002949 RID: 10569
		// (get) Token: 0x0601E455 RID: 123989 RVA: 0x008F16FE File Offset: 0x008EF8FE
		// (set) Token: 0x0601E456 RID: 123990 RVA: 0x008F170E File Offset: 0x008EF90E
		public unsafe float 射线高度Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700294A RID: 10570
		// (get) Token: 0x0601E457 RID: 123991 RVA: 0x008F1720 File Offset: 0x008EF920
		// (set) Token: 0x0601E458 RID: 123992 RVA: 0x008F1759 File Offset: 0x008EF959
		public FKuroCurveFloat 云层雷闪光强度曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._云层雷闪光强度曲线) == null)
				{
					result = (this._云层雷闪光强度曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700294B RID: 10571
		// (get) Token: 0x0601E459 RID: 123993 RVA: 0x008F177A File Offset: 0x008EF97A
		// (set) Token: 0x0601E45A RID: 123994 RVA: 0x008F178E File Offset: 0x008EF98E
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEvent_2D
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_14);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700294C RID: 10572
		// (get) Token: 0x0601E45B RID: 123995 RVA: 0x008F17A3 File Offset: 0x008EF9A3
		// (set) Token: 0x0601E45C RID: 123996 RVA: 0x008F17B3 File Offset: 0x008EF9B3
		public unsafe int _2DEventStopTransition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700294D RID: 10573
		// (get) Token: 0x0601E45D RID: 123997 RVA: 0x008F17C4 File Offset: 0x008EF9C4
		// (set) Token: 0x0601E45E RID: 123998 RVA: 0x008F17D8 File Offset: 0x008EF9D8
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEvent_Lightening
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700294E RID: 10574
		// (get) Token: 0x0601E45F RID: 123999 RVA: 0x008F17F0 File Offset: 0x008EF9F0
		// (set) Token: 0x0601E460 RID: 124000 RVA: 0x008F1829 File Offset: 0x008EFA29
		public FKuroCurveFloat 云层压暗曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._云层压暗曲线) == null)
				{
					result = (this._云层压暗曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700294F RID: 10575
		// (get) Token: 0x0601E461 RID: 124001 RVA: 0x008F184C File Offset: 0x008EFA4C
		// (set) Token: 0x0601E462 RID: 124002 RVA: 0x008F1885 File Offset: 0x008EFA85
		public FKuroCurveFloat 暗角曲线
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._暗角曲线) == null)
				{
					result = (this._暗角曲线 = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002950 RID: 10576
		// (get) Token: 0x0601E463 RID: 124003 RVA: 0x008F18A6 File Offset: 0x008EFAA6
		// (set) Token: 0x0601E464 RID: 124004 RVA: 0x008F18B6 File Offset: 0x008EFAB6
		public unsafe bool 局部云层闪光
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002951 RID: 10577
		// (get) Token: 0x0601E465 RID: 124005 RVA: 0x008F18C7 File Offset: 0x008EFAC7
		// (set) Token: 0x0601E466 RID: 124006 RVA: 0x008F18D7 File Offset: 0x008EFAD7
		public unsafe float 云层闪电高度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002952 RID: 10578
		// (get) Token: 0x0601E467 RID: 124007 RVA: 0x008F18E8 File Offset: 0x008EFAE8
		// (set) Token: 0x0601E468 RID: 124008 RVA: 0x008F18FC File Offset: 0x008EFAFC
		[Nullable(2)]
		public unsafe UKuroWeatherDataAsset PostProcessData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_21);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ThunderConfig_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17002953 RID: 10579
		// (get) Token: 0x0601E469 RID: 124009 RVA: 0x008F1911 File Offset: 0x008EFB11
		// (set) Token: 0x0601E46A RID: 124010 RVA: 0x008F1925 File Offset: 0x008EFB25
		public unsafe FLinearColor 默认闪电颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002954 RID: 10580
		// (get) Token: 0x0601E46B RID: 124011 RVA: 0x008F193A File Offset: 0x008EFB3A
		// (set) Token: 0x0601E46C RID: 124012 RVA: 0x008F194A File Offset: 0x008EFB4A
		public unsafe float 落雷最小半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002955 RID: 10581
		// (get) Token: 0x0601E46D RID: 124013 RVA: 0x008F195B File Offset: 0x008EFB5B
		// (set) Token: 0x0601E46E RID: 124014 RVA: 0x008F196B File Offset: 0x008EFB6B
		public unsafe float 落雷最大半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002956 RID: 10582
		// (get) Token: 0x0601E46F RID: 124015 RVA: 0x008F197C File Offset: 0x008EFB7C
		// (set) Token: 0x0601E470 RID: 124016 RVA: 0x008F198C File Offset: 0x008EFB8C
		public unsafe float 落雷边缘区域厚度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002957 RID: 10583
		// (get) Token: 0x0601E471 RID: 124017 RVA: 0x008F199D File Offset: 0x008EFB9D
		// (set) Token: 0x0601E472 RID: 124018 RVA: 0x008F19AD File Offset: 0x008EFBAD
		public unsafe float 最小垂直角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002958 RID: 10584
		// (get) Token: 0x0601E473 RID: 124019 RVA: 0x008F19BE File Offset: 0x008EFBBE
		// (set) Token: 0x0601E474 RID: 124020 RVA: 0x008F19CE File Offset: 0x008EFBCE
		public unsafe float 最大垂直角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002959 RID: 10585
		// (get) Token: 0x0601E475 RID: 124021 RVA: 0x008F19DF File Offset: 0x008EFBDF
		// (set) Token: 0x0601E476 RID: 124022 RVA: 0x008F19EF File Offset: 0x008EFBEF
		public unsafe float 水平朝向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700295A RID: 10586
		// (get) Token: 0x0601E477 RID: 124023 RVA: 0x008F1A00 File Offset: 0x008EFC00
		// (set) Token: 0x0601E478 RID: 124024 RVA: 0x008F1A10 File Offset: 0x008EFC10
		public unsafe float 水平朝向强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700295B RID: 10587
		// (get) Token: 0x0601E479 RID: 124025 RVA: 0x008F1A21 File Offset: 0x008EFC21
		// (set) Token: 0x0601E47A RID: 124026 RVA: 0x008F1A31 File Offset: 0x008EFC31
		public unsafe float 随机种子
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700295C RID: 10588
		// (get) Token: 0x0601E47B RID: 124027 RVA: 0x008F1A42 File Offset: 0x008EFC42
		// (set) Token: 0x0601E47C RID: 124028 RVA: 0x008F1A52 File Offset: 0x008EFC52
		public unsafe bool 全方位落雷
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ThunderConfig_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E47D RID: 124029 RVA: 0x008F1A63 File Offset: 0x008EFC63
		protected PDA_ThunderConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE1C RID: 60956
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/PDA_ThunderConfig.PDA_ThunderConfig_C";

		// Token: 0x0400EE1D RID: 60957
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE1E RID: 60958
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE1F RID: 60959
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE20 RID: 60960
		internal static int __PropertyOffset_1;

		// Token: 0x0400EE21 RID: 60961
		internal static int __PropertyOffset_2;

		// Token: 0x0400EE22 RID: 60962
		internal static int __PropertyOffset_3;

		// Token: 0x0400EE23 RID: 60963
		internal static int __PropertyOffset_4;

		// Token: 0x0400EE24 RID: 60964
		internal static int __PropertyOffset_5;

		// Token: 0x0400EE25 RID: 60965
		[Nullable(2)]
		private FKuroCurveFloat _灯光强度曲线;

		// Token: 0x0400EE26 RID: 60966
		internal static int __PropertyOffset_6;

		// Token: 0x0400EE27 RID: 60967
		[Nullable(2)]
		private FKuroCurveFloat _灯光半径曲线;

		// Token: 0x0400EE28 RID: 60968
		internal static int __PropertyOffset_7;

		// Token: 0x0400EE29 RID: 60969
		[Nullable(2)]
		private FKuroCurveFloat _后处理强度曲线;

		// Token: 0x0400EE2A RID: 60970
		internal static int __PropertyOffset_8;

		// Token: 0x0400EE2B RID: 60971
		internal static int __PropertyOffset_9;

		// Token: 0x0400EE2C RID: 60972
		internal static int __PropertyOffset_10;

		// Token: 0x0400EE2D RID: 60973
		internal static int __PropertyOffset_11;

		// Token: 0x0400EE2E RID: 60974
		internal static int __PropertyOffset_12;

		// Token: 0x0400EE2F RID: 60975
		internal static int __PropertyOffset_13;

		// Token: 0x0400EE30 RID: 60976
		[Nullable(2)]
		private FKuroCurveFloat _云层雷闪光强度曲线;

		// Token: 0x0400EE31 RID: 60977
		internal static int __PropertyOffset_14;

		// Token: 0x0400EE32 RID: 60978
		internal static int __PropertyOffset_15;

		// Token: 0x0400EE33 RID: 60979
		internal static int __PropertyOffset_16;

		// Token: 0x0400EE34 RID: 60980
		internal static int __PropertyOffset_17;

		// Token: 0x0400EE35 RID: 60981
		[Nullable(2)]
		private FKuroCurveFloat _云层压暗曲线;

		// Token: 0x0400EE36 RID: 60982
		internal static int __PropertyOffset_18;

		// Token: 0x0400EE37 RID: 60983
		[Nullable(2)]
		private FKuroCurveFloat _暗角曲线;

		// Token: 0x0400EE38 RID: 60984
		internal static int __PropertyOffset_19;

		// Token: 0x0400EE39 RID: 60985
		internal static int __PropertyOffset_20;

		// Token: 0x0400EE3A RID: 60986
		internal static int __PropertyOffset_21;

		// Token: 0x0400EE3B RID: 60987
		internal static int __PropertyOffset_22;

		// Token: 0x0400EE3C RID: 60988
		internal static int __PropertyOffset_23;

		// Token: 0x0400EE3D RID: 60989
		internal static int __PropertyOffset_24;

		// Token: 0x0400EE3E RID: 60990
		internal static int __PropertyOffset_25;

		// Token: 0x0400EE3F RID: 60991
		internal static int __PropertyOffset_26;

		// Token: 0x0400EE40 RID: 60992
		internal static int __PropertyOffset_27;

		// Token: 0x0400EE41 RID: 60993
		internal static int __PropertyOffset_28;

		// Token: 0x0400EE42 RID: 60994
		internal static int __PropertyOffset_29;

		// Token: 0x0400EE43 RID: 60995
		internal static int __PropertyOffset_30;

		// Token: 0x0400EE44 RID: 60996
		internal static int __PropertyOffset_31;
	}
}
