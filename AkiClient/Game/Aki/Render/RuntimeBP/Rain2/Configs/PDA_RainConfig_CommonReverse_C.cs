using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2.Configs
{
	// Token: 0x02003B42 RID: 15170
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfig_CommonReverse.PDA_RainConfig_CommonReverse_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1344)]
	public class PDA_RainConfig_CommonReverse_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020DE6 RID: 134630 RVA: 0x009392BD File Offset: 0x009374BD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_RainConfig_CommonReverse_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfig_CommonReverse.PDA_RainConfig_CommonReverse_C");
			}
			return PDA_RainConfig_CommonReverse_C._ClassPtr;
		}

		// Token: 0x06020DE7 RID: 134631 RVA: 0x009392E4 File Offset: 0x009374E4
		public PDA_RainConfig_CommonReverse_C() : this(BuiltinUtils.AllocNativeUObject(PDA_RainConfig_CommonReverse_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020DE8 RID: 134632 RVA: 0x0093930C File Offset: 0x0093750C
		public PDA_RainConfig_CommonReverse_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_RainConfig_CommonReverse_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170037B9 RID: 14265
		// (get) Token: 0x06020DE9 RID: 134633 RVA: 0x00939340 File Offset: 0x00937540
		// (set) Token: 0x06020DEA RID: 134634 RVA: 0x00939379 File Offset: 0x00937579
		public TArray<UMaterialInterface> Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._Materials) == null)
				{
					result = (this._Materials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.Materials.CopyAssign(value);
			}
		}

		// Token: 0x170037BA RID: 14266
		// (get) Token: 0x06020DEB RID: 134635 RVA: 0x00939388 File Offset: 0x00937588
		// (set) Token: 0x06020DEC RID: 134636 RVA: 0x009393C1 File Offset: 0x009375C1
		public TArray<UStaticMesh> Meshes
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._Meshes) == null)
				{
					result = (this._Meshes = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Meshes.CopyAssign(value);
			}
		}

		// Token: 0x170037BB RID: 14267
		// (get) Token: 0x06020DED RID: 134637 RVA: 0x009393D0 File Offset: 0x009375D0
		// (set) Token: 0x06020DEE RID: 134638 RVA: 0x00939409 File Offset: 0x00937609
		public TArray<SCommonRainSpawnerConfig> Spawners
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCommonRainSpawnerConfig> result;
				if ((result = this._Spawners) == null)
				{
					result = (this._Spawners = new TArray<SCommonRainSpawnerConfig>(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.Spawners.CopyAssign(value);
			}
		}

		// Token: 0x170037BC RID: 14268
		// (get) Token: 0x06020DEF RID: 134639 RVA: 0x00939417 File Offset: 0x00937617
		// (set) Token: 0x06020DF0 RID: 134640 RVA: 0x0093942B File Offset: 0x0093762B
		public unsafe FVector Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170037BD RID: 14269
		// (get) Token: 0x06020DF1 RID: 134641 RVA: 0x00939440 File Offset: 0x00937640
		// (set) Token: 0x06020DF2 RID: 134642 RVA: 0x00939454 File Offset: 0x00937654
		public unsafe FVector Wind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170037BE RID: 14270
		// (get) Token: 0x06020DF3 RID: 134643 RVA: 0x00939469 File Offset: 0x00937669
		// (set) Token: 0x06020DF4 RID: 134644 RVA: 0x00939479 File Offset: 0x00937679
		public unsafe float Drag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170037BF RID: 14271
		// (get) Token: 0x06020DF5 RID: 134645 RVA: 0x0093948C File Offset: 0x0093768C
		// (set) Token: 0x06020DF6 RID: 134646 RVA: 0x009394C5 File Offset: 0x009376C5
		public FKuroCurveFloat OpacityCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._OpacityCurve) == null)
				{
					result = (this._OpacityCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037C0 RID: 14272
		// (get) Token: 0x06020DF7 RID: 134647 RVA: 0x009394E8 File Offset: 0x009376E8
		// (set) Token: 0x06020DF8 RID: 134648 RVA: 0x00939521 File Offset: 0x00937721
		public FKuroCurveFloat StretchCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._StretchCurve) == null)
				{
					result = (this._StretchCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037C1 RID: 14273
		// (get) Token: 0x06020DF9 RID: 134649 RVA: 0x00939544 File Offset: 0x00937744
		// (set) Token: 0x06020DFA RID: 134650 RVA: 0x0093957D File Offset: 0x0093777D
		public FKuroCurveFloat ShapeCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._ShapeCurve) == null)
				{
					result = (this._ShapeCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037C2 RID: 14274
		// (get) Token: 0x06020DFB RID: 134651 RVA: 0x0093959E File Offset: 0x0093779E
		// (set) Token: 0x06020DFC RID: 134652 RVA: 0x009395AE File Offset: 0x009377AE
		public unsafe float CycleBoxX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170037C3 RID: 14275
		// (get) Token: 0x06020DFD RID: 134653 RVA: 0x009395BF File Offset: 0x009377BF
		// (set) Token: 0x06020DFE RID: 134654 RVA: 0x009395CF File Offset: 0x009377CF
		public unsafe float CycleBoxY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170037C4 RID: 14276
		// (get) Token: 0x06020DFF RID: 134655 RVA: 0x009395E0 File Offset: 0x009377E0
		// (set) Token: 0x06020E00 RID: 134656 RVA: 0x009395F0 File Offset: 0x009377F0
		public unsafe float CycleBoxZ_Positive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170037C5 RID: 14277
		// (get) Token: 0x06020E01 RID: 134657 RVA: 0x00939601 File Offset: 0x00937801
		// (set) Token: 0x06020E02 RID: 134658 RVA: 0x00939611 File Offset: 0x00937811
		public unsafe float CycleBoxZ_Negative
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170037C6 RID: 14278
		// (get) Token: 0x06020E03 RID: 134659 RVA: 0x00939624 File Offset: 0x00937824
		// (set) Token: 0x06020E04 RID: 134660 RVA: 0x0093965D File Offset: 0x0093785D
		public FKuroCurveFloat GravityPerformanceCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._GravityPerformanceCurve) == null)
				{
					result = (this._GravityPerformanceCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037C7 RID: 14279
		// (get) Token: 0x06020E05 RID: 134661 RVA: 0x00939680 File Offset: 0x00937880
		// (set) Token: 0x06020E06 RID: 134662 RVA: 0x009396B9 File Offset: 0x009378B9
		public FKuroCurveFloat DragPerformanceCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._DragPerformanceCurve) == null)
				{
					result = (this._DragPerformanceCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037C8 RID: 14280
		// (get) Token: 0x06020E07 RID: 134663 RVA: 0x009396DC File Offset: 0x009378DC
		// (set) Token: 0x06020E08 RID: 134664 RVA: 0x00939715 File Offset: 0x00937915
		public FKuroCurveFloat WindPerformanceCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._WindPerformanceCurve) == null)
				{
					result = (this._WindPerformanceCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037C9 RID: 14281
		// (get) Token: 0x06020E09 RID: 134665 RVA: 0x00939738 File Offset: 0x00937938
		// (set) Token: 0x06020E0A RID: 134666 RVA: 0x00939771 File Offset: 0x00937971
		public FKuroCurveFloat SpawnPerformanceCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._SpawnPerformanceCurve) == null)
				{
					result = (this._SpawnPerformanceCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037CA RID: 14282
		// (get) Token: 0x06020E0B RID: 134667 RVA: 0x00939794 File Offset: 0x00937994
		// (set) Token: 0x06020E0C RID: 134668 RVA: 0x009397CD File Offset: 0x009379CD
		public FKuroCurveFloat TimeDilationPerformanceCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._TimeDilationPerformanceCurve) == null)
				{
					result = (this._TimeDilationPerformanceCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfig_CommonReverse_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037CB RID: 14283
		// (get) Token: 0x06020E0D RID: 134669 RVA: 0x009397EE File Offset: 0x009379EE
		// (set) Token: 0x06020E0E RID: 134670 RVA: 0x00939802 File Offset: 0x00937A02
		[Nullable(2)]
		public unsafe UNiagaraSystem Niagara
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonReverse_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonReverse_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170037CC RID: 14284
		// (get) Token: 0x06020E0F RID: 134671 RVA: 0x00939817 File Offset: 0x00937A17
		// (set) Token: 0x06020E10 RID: 134672 RVA: 0x0093982B File Offset: 0x00937A2B
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonReverse_C.__PropertyOffset_19);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfig_CommonReverse_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x06020E11 RID: 134673 RVA: 0x00939840 File Offset: 0x00937A40
		protected PDA_RainConfig_CommonReverse_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040107C8 RID: 67528
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfig_CommonReverse.PDA_RainConfig_CommonReverse_C";

		// Token: 0x040107C9 RID: 67529
		private static IntPtr _ClassPtr;

		// Token: 0x040107CA RID: 67530
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040107CB RID: 67531
		internal static int __PropertyOffset_0;

		// Token: 0x040107CC RID: 67532
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _Materials;

		// Token: 0x040107CD RID: 67533
		internal static int __PropertyOffset_1;

		// Token: 0x040107CE RID: 67534
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _Meshes;

		// Token: 0x040107CF RID: 67535
		internal static int __PropertyOffset_2;

		// Token: 0x040107D0 RID: 67536
		[Nullable(2)]
		private TArray<SCommonRainSpawnerConfig> _Spawners;

		// Token: 0x040107D1 RID: 67537
		internal static int __PropertyOffset_3;

		// Token: 0x040107D2 RID: 67538
		internal static int __PropertyOffset_4;

		// Token: 0x040107D3 RID: 67539
		internal static int __PropertyOffset_5;

		// Token: 0x040107D4 RID: 67540
		internal static int __PropertyOffset_6;

		// Token: 0x040107D5 RID: 67541
		[Nullable(2)]
		private FKuroCurveFloat _OpacityCurve;

		// Token: 0x040107D6 RID: 67542
		internal static int __PropertyOffset_7;

		// Token: 0x040107D7 RID: 67543
		[Nullable(2)]
		private FKuroCurveFloat _StretchCurve;

		// Token: 0x040107D8 RID: 67544
		internal static int __PropertyOffset_8;

		// Token: 0x040107D9 RID: 67545
		[Nullable(2)]
		private FKuroCurveFloat _ShapeCurve;

		// Token: 0x040107DA RID: 67546
		internal static int __PropertyOffset_9;

		// Token: 0x040107DB RID: 67547
		internal static int __PropertyOffset_10;

		// Token: 0x040107DC RID: 67548
		internal static int __PropertyOffset_11;

		// Token: 0x040107DD RID: 67549
		internal static int __PropertyOffset_12;

		// Token: 0x040107DE RID: 67550
		internal static int __PropertyOffset_13;

		// Token: 0x040107DF RID: 67551
		[Nullable(2)]
		private FKuroCurveFloat _GravityPerformanceCurve;

		// Token: 0x040107E0 RID: 67552
		internal static int __PropertyOffset_14;

		// Token: 0x040107E1 RID: 67553
		[Nullable(2)]
		private FKuroCurveFloat _DragPerformanceCurve;

		// Token: 0x040107E2 RID: 67554
		internal static int __PropertyOffset_15;

		// Token: 0x040107E3 RID: 67555
		[Nullable(2)]
		private FKuroCurveFloat _WindPerformanceCurve;

		// Token: 0x040107E4 RID: 67556
		internal static int __PropertyOffset_16;

		// Token: 0x040107E5 RID: 67557
		[Nullable(2)]
		private FKuroCurveFloat _SpawnPerformanceCurve;

		// Token: 0x040107E6 RID: 67558
		internal static int __PropertyOffset_17;

		// Token: 0x040107E7 RID: 67559
		[Nullable(2)]
		private FKuroCurveFloat _TimeDilationPerformanceCurve;

		// Token: 0x040107E8 RID: 67560
		internal static int __PropertyOffset_18;

		// Token: 0x040107E9 RID: 67561
		internal static int __PropertyOffset_19;
	}
}
