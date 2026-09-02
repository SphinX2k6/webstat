using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.PilotThrow
{
	// Token: 0x02003EA3 RID: 16035
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/PilotThrow/BP_PilotThrowGameplaySetting.BP_PilotThrowGameplaySetting_C")]
	[UnrealStructLayout(288, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 288)]
	public class BP_PilotThrowGameplaySetting_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027CA8 RID: 162984 RVA: 0x009FA995 File Offset: 0x009F8B95
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PilotThrowGameplaySetting_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/PilotThrow/BP_PilotThrowGameplaySetting.BP_PilotThrowGameplaySetting_C");
			}
			return BP_PilotThrowGameplaySetting_C._ClassPtr;
		}

		// Token: 0x06027CA9 RID: 162985 RVA: 0x009FA9BC File Offset: 0x009F8BBC
		public BP_PilotThrowGameplaySetting_C() : this(BuiltinUtils.AllocNativeUObject(BP_PilotThrowGameplaySetting_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027CAA RID: 162986 RVA: 0x009FA9E4 File Offset: 0x009F8BE4
		public BP_PilotThrowGameplaySetting_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PilotThrowGameplaySetting_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005EF2 RID: 24306
		// (get) Token: 0x06027CAB RID: 162987 RVA: 0x009FAA17 File Offset: 0x009F8C17
		// (set) Token: 0x06027CAC RID: 162988 RVA: 0x009FAA27 File Offset: 0x009F8C27
		public unsafe bool DebugMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005EF3 RID: 24307
		// (get) Token: 0x06027CAD RID: 162989 RVA: 0x009FAA38 File Offset: 0x009F8C38
		// (set) Token: 0x06027CAE RID: 162990 RVA: 0x009FAA48 File Offset: 0x009F8C48
		public unsafe float 初速度仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005EF4 RID: 24308
		// (get) Token: 0x06027CAF RID: 162991 RVA: 0x009FAA59 File Offset: 0x009F8C59
		// (set) Token: 0x06027CB0 RID: 162992 RVA: 0x009FAA69 File Offset: 0x009F8C69
		public unsafe float 初速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005EF5 RID: 24309
		// (get) Token: 0x06027CB1 RID: 162993 RVA: 0x009FAA7A File Offset: 0x009F8C7A
		// (set) Token: 0x06027CB2 RID: 162994 RVA: 0x009FAA8A File Offset: 0x009F8C8A
		public unsafe float 射线检测半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005EF6 RID: 24310
		// (get) Token: 0x06027CB3 RID: 162995 RVA: 0x009FAA9B File Offset: 0x009F8C9B
		// (set) Token: 0x06027CB4 RID: 162996 RVA: 0x009FAAAB File Offset: 0x009F8CAB
		public unsafe float 重力加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005EF7 RID: 24311
		// (get) Token: 0x06027CB5 RID: 162997 RVA: 0x009FAABC File Offset: 0x009F8CBC
		// (set) Token: 0x06027CB6 RID: 162998 RVA: 0x009FAAD1 File Offset: 0x009F8CD1
		public TSoftObjectPtr<EffectModelGroup> 样条特效
		{
			get
			{
				return new TSoftObjectPtr<EffectModelGroup>(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_5, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EF8 RID: 24312
		// (get) Token: 0x06027CB7 RID: 162999 RVA: 0x009FAAF6 File Offset: 0x009F8CF6
		// (set) Token: 0x06027CB8 RID: 163000 RVA: 0x009FAB0B File Offset: 0x009F8D0B
		public TSoftObjectPtr<UEffectModelGroup> 终点特效
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_6, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005EF9 RID: 24313
		// (get) Token: 0x06027CB9 RID: 163001 RVA: 0x009FAB30 File Offset: 0x009F8D30
		// (set) Token: 0x06027CBA RID: 163002 RVA: 0x009FAB44 File Offset: 0x009F8D44
		public unsafe FVector2D 触屏移动系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005EFA RID: 24314
		// (get) Token: 0x06027CBB RID: 163003 RVA: 0x009FAB59 File Offset: 0x009F8D59
		// (set) Token: 0x06027CBC RID: 163004 RVA: 0x009FAB6D File Offset: 0x009F8D6D
		public unsafe FVector2D PC移动系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005EFB RID: 24315
		// (get) Token: 0x06027CBD RID: 163005 RVA: 0x009FAB82 File Offset: 0x009F8D82
		// (set) Token: 0x06027CBE RID: 163006 RVA: 0x009FAB96 File Offset: 0x009F8D96
		public unsafe FVector2D 手柄移动系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005EFC RID: 24316
		// (get) Token: 0x06027CBF RID: 163007 RVA: 0x009FABAB File Offset: 0x009F8DAB
		// (set) Token: 0x06027CC0 RID: 163008 RVA: 0x009FABBB File Offset: 0x009F8DBB
		public unsafe int 目标点高亮距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005EFD RID: 24317
		// (get) Token: 0x06027CC1 RID: 163009 RVA: 0x009FABCC File Offset: 0x009F8DCC
		// (set) Token: 0x06027CC2 RID: 163010 RVA: 0x009FABDC File Offset: 0x009F8DDC
		public unsafe int 边缘超出角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005EFE RID: 24318
		// (get) Token: 0x06027CC3 RID: 163011 RVA: 0x009FABED File Offset: 0x009F8DED
		// (set) Token: 0x06027CC4 RID: 163012 RVA: 0x009FABFD File Offset: 0x009F8DFD
		public unsafe float Ui缩放_废弃_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005EFF RID: 24319
		// (get) Token: 0x06027CC5 RID: 163013 RVA: 0x009FAC0E File Offset: 0x009F8E0E
		// (set) Token: 0x06027CC6 RID: 163014 RVA: 0x009FAC1E File Offset: 0x009F8E1E
		public unsafe float 铁驭旋转偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005F00 RID: 24320
		// (get) Token: 0x06027CC7 RID: 163015 RVA: 0x009FAC2F File Offset: 0x009F8E2F
		// (set) Token: 0x06027CC8 RID: 163016 RVA: 0x009FAC43 File Offset: 0x009F8E43
		[Nullable(2)]
		public unsafe UKuroForceFeedbackEffect 手柄震动配置
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroForceFeedbackEffect>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PilotThrowGameplaySetting_C.__PropertyOffset_14);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PilotThrowGameplaySetting_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17005F01 RID: 24321
		// (get) Token: 0x06027CC9 RID: 163017 RVA: 0x009FAC58 File Offset: 0x009F8E58
		// (set) Token: 0x06027CCA RID: 163018 RVA: 0x009FAC6C File Offset: 0x009F8E6C
		public unsafe FVectorDouble 抛物线起点偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005F02 RID: 24322
		// (get) Token: 0x06027CCB RID: 163019 RVA: 0x009FAC81 File Offset: 0x009F8E81
		// (set) Token: 0x06027CCC RID: 163020 RVA: 0x009FAC91 File Offset: 0x009F8E91
		public unsafe float 启动镜头插值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005F03 RID: 24323
		// (get) Token: 0x06027CCD RID: 163021 RVA: 0x009FACA2 File Offset: 0x009F8EA2
		// (set) Token: 0x06027CCE RID: 163022 RVA: 0x009FACB2 File Offset: 0x009F8EB2
		public unsafe float 自动投掷转状态延迟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PilotThrowGameplaySetting_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005F04 RID: 24324
		// (get) Token: 0x06027CCF RID: 163023 RVA: 0x009FACC3 File Offset: 0x009F8EC3
		// (set) Token: 0x06027CD0 RID: 163024 RVA: 0x009FACD7 File Offset: 0x009F8ED7
		[Nullable(2)]
		public unsafe UCurveFloat 缩放曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PilotThrowGameplaySetting_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PilotThrowGameplaySetting_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x06027CD1 RID: 163025 RVA: 0x009FACEC File Offset: 0x009F8EEC
		protected BP_PilotThrowGameplaySetting_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014E0C RID: 85516
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/PilotThrow/BP_PilotThrowGameplaySetting.BP_PilotThrowGameplaySetting_C";

		// Token: 0x04014E0D RID: 85517
		private static IntPtr _ClassPtr;

		// Token: 0x04014E0E RID: 85518
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014E0F RID: 85519
		internal static int __PropertyOffset_0;

		// Token: 0x04014E10 RID: 85520
		internal static int __PropertyOffset_1;

		// Token: 0x04014E11 RID: 85521
		internal static int __PropertyOffset_2;

		// Token: 0x04014E12 RID: 85522
		internal static int __PropertyOffset_3;

		// Token: 0x04014E13 RID: 85523
		internal static int __PropertyOffset_4;

		// Token: 0x04014E14 RID: 85524
		internal static int __PropertyOffset_5;

		// Token: 0x04014E15 RID: 85525
		internal static int __PropertyOffset_6;

		// Token: 0x04014E16 RID: 85526
		internal static int __PropertyOffset_7;

		// Token: 0x04014E17 RID: 85527
		internal static int __PropertyOffset_8;

		// Token: 0x04014E18 RID: 85528
		internal static int __PropertyOffset_9;

		// Token: 0x04014E19 RID: 85529
		internal static int __PropertyOffset_10;

		// Token: 0x04014E1A RID: 85530
		internal static int __PropertyOffset_11;

		// Token: 0x04014E1B RID: 85531
		internal static int __PropertyOffset_12;

		// Token: 0x04014E1C RID: 85532
		internal static int __PropertyOffset_13;

		// Token: 0x04014E1D RID: 85533
		internal static int __PropertyOffset_14;

		// Token: 0x04014E1E RID: 85534
		internal static int __PropertyOffset_15;

		// Token: 0x04014E1F RID: 85535
		internal static int __PropertyOffset_16;

		// Token: 0x04014E20 RID: 85536
		internal static int __PropertyOffset_17;

		// Token: 0x04014E21 RID: 85537
		internal static int __PropertyOffset_18;
	}
}
