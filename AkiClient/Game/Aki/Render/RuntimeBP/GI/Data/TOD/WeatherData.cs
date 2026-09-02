using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD
{
	// Token: 0x02003CD9 RID: 15577
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WeatherData.WeatherData")]
	[UnrealStructLayout(108, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 108)]
	public class WeatherData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602527D RID: 152189 RVA: 0x009B22B3 File Offset: 0x009B04B3
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (WeatherData._ScriptStructPtr != 0) ? WeatherData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WeatherData.WeatherData", ref WeatherData._ScriptStructPtr);
		}

		// Token: 0x17004FF3 RID: 20467
		// (get) Token: 0x0602527E RID: 152190 RVA: 0x009B22D7 File Offset: 0x009B04D7
		// (set) Token: 0x0602527F RID: 152191 RVA: 0x009B22E7 File Offset: 0x009B04E7
		public unsafe float CloudsScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004FF4 RID: 20468
		// (get) Token: 0x06025280 RID: 152192 RVA: 0x009B22F8 File Offset: 0x009B04F8
		// (set) Token: 0x06025281 RID: 152193 RVA: 0x009B2308 File Offset: 0x009B0508
		public unsafe float CloudsDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004FF5 RID: 20469
		// (get) Token: 0x06025282 RID: 152194 RVA: 0x009B2319 File Offset: 0x009B0519
		// (set) Token: 0x06025283 RID: 152195 RVA: 0x009B2329 File Offset: 0x009B0529
		public unsafe float CloudsVertexDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004FF6 RID: 20470
		// (get) Token: 0x06025284 RID: 152196 RVA: 0x009B233A File Offset: 0x009B053A
		// (set) Token: 0x06025285 RID: 152197 RVA: 0x009B234A File Offset: 0x009B054A
		public unsafe float CloudsHarness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004FF7 RID: 20471
		// (get) Token: 0x06025286 RID: 152198 RVA: 0x009B235B File Offset: 0x009B055B
		// (set) Token: 0x06025287 RID: 152199 RVA: 0x009B236B File Offset: 0x009B056B
		public unsafe float CloudsTranslucent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FF8 RID: 20472
		// (get) Token: 0x06025288 RID: 152200 RVA: 0x009B237C File Offset: 0x009B057C
		// (set) Token: 0x06025289 RID: 152201 RVA: 0x009B238C File Offset: 0x009B058C
		public unsafe float CloudsBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004FF9 RID: 20473
		// (get) Token: 0x0602528A RID: 152202 RVA: 0x009B239D File Offset: 0x009B059D
		// (set) Token: 0x0602528B RID: 152203 RVA: 0x009B23AD File Offset: 0x009B05AD
		public unsafe float CloudsDistotion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004FFA RID: 20474
		// (get) Token: 0x0602528C RID: 152204 RVA: 0x009B23BE File Offset: 0x009B05BE
		// (set) Token: 0x0602528D RID: 152205 RVA: 0x009B23CE File Offset: 0x009B05CE
		public unsafe float CloudsScattering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004FFB RID: 20475
		// (get) Token: 0x0602528E RID: 152206 RVA: 0x009B23DF File Offset: 0x009B05DF
		// (set) Token: 0x0602528F RID: 152207 RVA: 0x009B23EF File Offset: 0x009B05EF
		public unsafe float CloudsUpperBrightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004FFC RID: 20476
		// (get) Token: 0x06025290 RID: 152208 RVA: 0x009B2400 File Offset: 0x009B0600
		// (set) Token: 0x06025291 RID: 152209 RVA: 0x009B2410 File Offset: 0x009B0610
		public unsafe float CloudsLowerBrightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004FFD RID: 20477
		// (get) Token: 0x06025292 RID: 152210 RVA: 0x009B2421 File Offset: 0x009B0621
		// (set) Token: 0x06025293 RID: 152211 RVA: 0x009B2431 File Offset: 0x009B0631
		public unsafe float CloudsAmbient
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004FFE RID: 20478
		// (get) Token: 0x06025294 RID: 152212 RVA: 0x009B2442 File Offset: 0x009B0642
		// (set) Token: 0x06025295 RID: 152213 RVA: 0x009B2452 File Offset: 0x009B0652
		public unsafe float CloudsShadowSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004FFF RID: 20479
		// (get) Token: 0x06025296 RID: 152214 RVA: 0x009B2463 File Offset: 0x009B0663
		// (set) Token: 0x06025297 RID: 152215 RVA: 0x009B2473 File Offset: 0x009B0673
		public unsafe float CloudsShadowSoft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005000 RID: 20480
		// (get) Token: 0x06025298 RID: 152216 RVA: 0x009B2484 File Offset: 0x009B0684
		// (set) Token: 0x06025299 RID: 152217 RVA: 0x009B2494 File Offset: 0x009B0694
		public unsafe float CloudsBackground
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005001 RID: 20481
		// (get) Token: 0x0602529A RID: 152218 RVA: 0x009B24A5 File Offset: 0x009B06A5
		// (set) Token: 0x0602529B RID: 152219 RVA: 0x009B24B5 File Offset: 0x009B06B5
		public unsafe float CloudsHorizonDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005002 RID: 20482
		// (get) Token: 0x0602529C RID: 152220 RVA: 0x009B24C6 File Offset: 0x009B06C6
		// (set) Token: 0x0602529D RID: 152221 RVA: 0x009B24D6 File Offset: 0x009B06D6
		public unsafe float CloudsHorizonAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005003 RID: 20483
		// (get) Token: 0x0602529E RID: 152222 RVA: 0x009B24E7 File Offset: 0x009B06E7
		// (set) Token: 0x0602529F RID: 152223 RVA: 0x009B24F7 File Offset: 0x009B06F7
		public unsafe float CloudsHorizonScattering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005004 RID: 20484
		// (get) Token: 0x060252A0 RID: 152224 RVA: 0x009B2508 File Offset: 0x009B0708
		// (set) Token: 0x060252A1 RID: 152225 RVA: 0x009B2518 File Offset: 0x009B0718
		public unsafe float HorizonFalloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005005 RID: 20485
		// (get) Token: 0x060252A2 RID: 152226 RVA: 0x009B2529 File Offset: 0x009B0729
		// (set) Token: 0x060252A3 RID: 152227 RVA: 0x009B2539 File Offset: 0x009B0739
		public unsafe float WindForceScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005006 RID: 20486
		// (get) Token: 0x060252A4 RID: 152228 RVA: 0x009B254A File Offset: 0x009B074A
		// (set) Token: 0x060252A5 RID: 152229 RVA: 0x009B255A File Offset: 0x009B075A
		public unsafe float WindDynamic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005007 RID: 20487
		// (get) Token: 0x060252A6 RID: 152230 RVA: 0x009B256B File Offset: 0x009B076B
		// (set) Token: 0x060252A7 RID: 152231 RVA: 0x009B257B File Offset: 0x009B077B
		public unsafe float WindDispersing_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005008 RID: 20488
		// (get) Token: 0x060252A8 RID: 152232 RVA: 0x009B258C File Offset: 0x009B078C
		// (set) Token: 0x060252A9 RID: 152233 RVA: 0x009B259C File Offset: 0x009B079C
		public unsafe float SkylightBrightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005009 RID: 20489
		// (get) Token: 0x060252AA RID: 152234 RVA: 0x009B25AD File Offset: 0x009B07AD
		// (set) Token: 0x060252AB RID: 152235 RVA: 0x009B25BD File Offset: 0x009B07BD
		public unsafe float SecondLayerHardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700500A RID: 20490
		// (get) Token: 0x060252AC RID: 152236 RVA: 0x009B25CE File Offset: 0x009B07CE
		// (set) Token: 0x060252AD RID: 152237 RVA: 0x009B25DE File Offset: 0x009B07DE
		public unsafe float SecondLayerColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700500B RID: 20491
		// (get) Token: 0x060252AE RID: 152238 RVA: 0x009B25EF File Offset: 0x009B07EF
		// (set) Token: 0x060252AF RID: 152239 RVA: 0x009B25FF File Offset: 0x009B07FF
		public unsafe float SecondLayerAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700500C RID: 20492
		// (get) Token: 0x060252B0 RID: 152240 RVA: 0x009B2610 File Offset: 0x009B0810
		// (set) Token: 0x060252B1 RID: 152241 RVA: 0x009B2620 File Offset: 0x009B0820
		public unsafe float SecondLayerScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700500D RID: 20493
		// (get) Token: 0x060252B2 RID: 152242 RVA: 0x009B2631 File Offset: 0x009B0831
		// (set) Token: 0x060252B3 RID: 152243 RVA: 0x009B2641 File Offset: 0x009B0841
		public unsafe float SecondLayerWind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WeatherData.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x060252B4 RID: 152244 RVA: 0x009B2652 File Offset: 0x009B0852
		public WeatherData()
		{
		}

		// Token: 0x060252B5 RID: 152245 RVA: 0x009B265C File Offset: 0x009B085C
		public WeatherData(float CloudsScale, float CloudsDensity, float CloudsVertexDensity, float CloudsHarness, float CloudsTranslucent, float CloudsBlend, float CloudsDistotion, float CloudsScattering, float CloudsUpperBrightness, float CloudsLowerBrightness, float CloudsAmbient, float CloudsShadowSize, float CloudsShadowSoft, float CloudsBackground, float CloudsHorizonDensity, float CloudsHorizonAlpha, float CloudsHorizonScattering, float HorizonFalloff, float WindForceScale, float WindDynamic, float WindDispersing_, float SkylightBrightness, float SecondLayerHardness, float SecondLayerColor, float SecondLayerAlpha, float SecondLayerScale, float SecondLayerWind)
		{
			this.CloudsScale = CloudsScale;
			this.CloudsDensity = CloudsDensity;
			this.CloudsVertexDensity = CloudsVertexDensity;
			this.CloudsHarness = CloudsHarness;
			this.CloudsTranslucent = CloudsTranslucent;
			this.CloudsBlend = CloudsBlend;
			this.CloudsDistotion = CloudsDistotion;
			this.CloudsScattering = CloudsScattering;
			this.CloudsUpperBrightness = CloudsUpperBrightness;
			this.CloudsLowerBrightness = CloudsLowerBrightness;
			this.CloudsAmbient = CloudsAmbient;
			this.CloudsShadowSize = CloudsShadowSize;
			this.CloudsShadowSoft = CloudsShadowSoft;
			this.CloudsBackground = CloudsBackground;
			this.CloudsHorizonDensity = CloudsHorizonDensity;
			this.CloudsHorizonAlpha = CloudsHorizonAlpha;
			this.CloudsHorizonScattering = CloudsHorizonScattering;
			this.HorizonFalloff = HorizonFalloff;
			this.WindForceScale = WindForceScale;
			this.WindDynamic = WindDynamic;
			this.WindDispersing_ = WindDispersing_;
			this.SkylightBrightness = SkylightBrightness;
			this.SecondLayerHardness = SecondLayerHardness;
			this.SecondLayerColor = SecondLayerColor;
			this.SecondLayerAlpha = SecondLayerAlpha;
			this.SecondLayerScale = SecondLayerScale;
			this.SecondLayerWind = SecondLayerWind;
		}

		// Token: 0x060252B6 RID: 152246 RVA: 0x009B2744 File Offset: 0x009B0944
		protected override IntPtr GetUStructPtr()
		{
			return WeatherData.StaticStruct();
		}

		// Token: 0x060252B7 RID: 152247 RVA: 0x009B2750 File Offset: 0x009B0950
		[NullableContext(2)]
		public WeatherData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060252B8 RID: 152248 RVA: 0x009B275A File Offset: 0x009B095A
		public WeatherData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060252B9 RID: 152249 RVA: 0x009B2765 File Offset: 0x009B0965
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new WeatherData(Pointer, false, true);
		}

		// Token: 0x060252BA RID: 152250 RVA: 0x009B276F File Offset: 0x009B096F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new WeatherData(Pointer, MemoryOwner);
		}

		// Token: 0x04013206 RID: 78342
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Data/TOD/WeatherData.WeatherData";

		// Token: 0x04013207 RID: 78343
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013208 RID: 78344
		internal static int __PropertyOffset_0;

		// Token: 0x04013209 RID: 78345
		internal static int __PropertyOffset_1;

		// Token: 0x0401320A RID: 78346
		internal static int __PropertyOffset_2;

		// Token: 0x0401320B RID: 78347
		internal static int __PropertyOffset_3;

		// Token: 0x0401320C RID: 78348
		internal static int __PropertyOffset_4;

		// Token: 0x0401320D RID: 78349
		internal static int __PropertyOffset_5;

		// Token: 0x0401320E RID: 78350
		internal static int __PropertyOffset_6;

		// Token: 0x0401320F RID: 78351
		internal static int __PropertyOffset_7;

		// Token: 0x04013210 RID: 78352
		internal static int __PropertyOffset_8;

		// Token: 0x04013211 RID: 78353
		internal static int __PropertyOffset_9;

		// Token: 0x04013212 RID: 78354
		internal static int __PropertyOffset_10;

		// Token: 0x04013213 RID: 78355
		internal static int __PropertyOffset_11;

		// Token: 0x04013214 RID: 78356
		internal static int __PropertyOffset_12;

		// Token: 0x04013215 RID: 78357
		internal static int __PropertyOffset_13;

		// Token: 0x04013216 RID: 78358
		internal static int __PropertyOffset_14;

		// Token: 0x04013217 RID: 78359
		internal static int __PropertyOffset_15;

		// Token: 0x04013218 RID: 78360
		internal static int __PropertyOffset_16;

		// Token: 0x04013219 RID: 78361
		internal static int __PropertyOffset_17;

		// Token: 0x0401321A RID: 78362
		internal static int __PropertyOffset_18;

		// Token: 0x0401321B RID: 78363
		internal static int __PropertyOffset_19;

		// Token: 0x0401321C RID: 78364
		internal static int __PropertyOffset_20;

		// Token: 0x0401321D RID: 78365
		internal static int __PropertyOffset_21;

		// Token: 0x0401321E RID: 78366
		internal static int __PropertyOffset_22;

		// Token: 0x0401321F RID: 78367
		internal static int __PropertyOffset_23;

		// Token: 0x04013220 RID: 78368
		internal static int __PropertyOffset_24;

		// Token: 0x04013221 RID: 78369
		internal static int __PropertyOffset_25;

		// Token: 0x04013222 RID: 78370
		internal static int __PropertyOffset_26;
	}
}
