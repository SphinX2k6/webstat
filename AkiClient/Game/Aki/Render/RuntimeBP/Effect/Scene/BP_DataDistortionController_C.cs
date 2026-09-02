using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D2F RID: 15663
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_DataDistortionController.BP_DataDistortionController_C")]
	[UnrealStructLayout(2328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2324)]
	public class BP_DataDistortionController_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025EED RID: 155373 RVA: 0x009C8EFB File Offset: 0x009C70FB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DataDistortionController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_DataDistortionController.BP_DataDistortionController_C");
			}
			return BP_DataDistortionController_C._ClassPtr;
		}

		// Token: 0x06025EEE RID: 155374 RVA: 0x009C8F20 File Offset: 0x009C7120
		public BP_DataDistortionController_C() : this(BuiltinUtils.AllocNativeUObject(BP_DataDistortionController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025EEF RID: 155375 RVA: 0x009C8F48 File Offset: 0x009C7148
		public BP_DataDistortionController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DataDistortionController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005490 RID: 21648
		// (get) Token: 0x06025EF0 RID: 155376 RVA: 0x009C8F7C File Offset: 0x009C717C
		// (set) Token: 0x06025EF1 RID: 155377 RVA: 0x009C8FB5 File Offset: 0x009C71B5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005491 RID: 21649
		// (get) Token: 0x06025EF2 RID: 155378 RVA: 0x009C8FD6 File Offset: 0x009C71D6
		// (set) Token: 0x06025EF3 RID: 155379 RVA: 0x009C8FEA File Offset: 0x009C71EA
		[Nullable(2)]
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DataDistortionController_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DataDistortionController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005492 RID: 21650
		// (get) Token: 0x06025EF4 RID: 155380 RVA: 0x009C8FFF File Offset: 0x009C71FF
		// (set) Token: 0x06025EF5 RID: 155381 RVA: 0x009C9013 File Offset: 0x009C7213
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DataDistortionController_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DataDistortionController_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005493 RID: 21651
		// (get) Token: 0x06025EF6 RID: 155382 RVA: 0x009C9028 File Offset: 0x009C7228
		// (set) Token: 0x06025EF7 RID: 155383 RVA: 0x009C9038 File Offset: 0x009C7238
		public unsafe float Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005494 RID: 21652
		// (get) Token: 0x06025EF8 RID: 155384 RVA: 0x009C9049 File Offset: 0x009C7249
		// (set) Token: 0x06025EF9 RID: 155385 RVA: 0x009C9059 File Offset: 0x009C7259
		public unsafe float Process
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005495 RID: 21653
		// (get) Token: 0x06025EFA RID: 155386 RVA: 0x009C906A File Offset: 0x009C726A
		// (set) Token: 0x06025EFB RID: 155387 RVA: 0x009C907A File Offset: 0x009C727A
		public unsafe float WiggleAmpScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005496 RID: 21654
		// (get) Token: 0x06025EFC RID: 155388 RVA: 0x009C908C File Offset: 0x009C728C
		// (set) Token: 0x06025EFD RID: 155389 RVA: 0x009C90C5 File Offset: 0x009C72C5
		public TArray<FKuroCurveFloat> WiggleCurves
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCurveFloat> result;
				if ((result = this._WiggleCurves) == null)
				{
					result = (this._WiggleCurves = new TArray<FKuroCurveFloat>(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.WiggleCurves.CopyAssign(value);
			}
		}

		// Token: 0x17005497 RID: 21655
		// (get) Token: 0x06025EFE RID: 155390 RVA: 0x009C90D4 File Offset: 0x009C72D4
		// (set) Token: 0x06025EFF RID: 155391 RVA: 0x009C910D File Offset: 0x009C730D
		public TArray<float> WiggleCurvePeriods
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._WiggleCurvePeriods) == null)
				{
					result = (this._WiggleCurvePeriods = new TArray<float>(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.WiggleCurvePeriods.CopyAssign(value);
			}
		}

		// Token: 0x17005498 RID: 21656
		// (get) Token: 0x06025F00 RID: 155392 RVA: 0x009C911B File Offset: 0x009C731B
		// (set) Token: 0x06025F01 RID: 155393 RVA: 0x009C912B File Offset: 0x009C732B
		public unsafe float WiggleFreq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005499 RID: 21657
		// (get) Token: 0x06025F02 RID: 155394 RVA: 0x009C913C File Offset: 0x009C733C
		// (set) Token: 0x06025F03 RID: 155395 RVA: 0x009C914C File Offset: 0x009C734C
		public unsafe float WiggleYFreq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700549A RID: 21658
		// (get) Token: 0x06025F04 RID: 155396 RVA: 0x009C915D File Offset: 0x009C735D
		// (set) Token: 0x06025F05 RID: 155397 RVA: 0x009C916D File Offset: 0x009C736D
		public unsafe float WiggleYAmp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700549B RID: 21659
		// (get) Token: 0x06025F06 RID: 155398 RVA: 0x009C9180 File Offset: 0x009C7380
		// (set) Token: 0x06025F07 RID: 155399 RVA: 0x009C91B9 File Offset: 0x009C73B9
		public FKuroCurveLinearColor ColorCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._ColorCurve) == null)
				{
					result = (this._ColorCurve = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700549C RID: 21660
		// (get) Token: 0x06025F08 RID: 155400 RVA: 0x009C91DC File Offset: 0x009C73DC
		// (set) Token: 0x06025F09 RID: 155401 RVA: 0x009C9215 File Offset: 0x009C7415
		public FKuroCurveFloat SignalCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._SignalCurve) == null)
				{
					result = (this._SignalCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700549D RID: 21661
		// (get) Token: 0x06025F0A RID: 155402 RVA: 0x009C9238 File Offset: 0x009C7438
		// (set) Token: 0x06025F0B RID: 155403 RVA: 0x009C9271 File Offset: 0x009C7471
		public FKuroCurveFloat SignalColorCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._SignalColorCurve) == null)
				{
					result = (this._SignalColorCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700549E RID: 21662
		// (get) Token: 0x06025F0C RID: 155404 RVA: 0x009C9292 File Offset: 0x009C7492
		// (set) Token: 0x06025F0D RID: 155405 RVA: 0x009C92A2 File Offset: 0x009C74A2
		public unsafe float SignaPeriod
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700549F RID: 21663
		// (get) Token: 0x06025F0E RID: 155406 RVA: 0x009C92B3 File Offset: 0x009C74B3
		// (set) Token: 0x06025F0F RID: 155407 RVA: 0x009C92C3 File Offset: 0x009C74C3
		public unsafe float SignaFreq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170054A0 RID: 21664
		// (get) Token: 0x06025F10 RID: 155408 RVA: 0x009C92D4 File Offset: 0x009C74D4
		// (set) Token: 0x06025F11 RID: 155409 RVA: 0x009C92E4 File Offset: 0x009C74E4
		public unsafe float SignaSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170054A1 RID: 21665
		// (get) Token: 0x06025F12 RID: 155410 RVA: 0x009C92F5 File Offset: 0x009C74F5
		// (set) Token: 0x06025F13 RID: 155411 RVA: 0x009C9305 File Offset: 0x009C7505
		public unsafe float 抖动强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170054A2 RID: 21666
		// (get) Token: 0x06025F14 RID: 155412 RVA: 0x009C9316 File Offset: 0x009C7516
		// (set) Token: 0x06025F15 RID: 155413 RVA: 0x009C9326 File Offset: 0x009C7526
		public unsafe float 抖动触发频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170054A3 RID: 21667
		// (get) Token: 0x06025F16 RID: 155414 RVA: 0x009C9337 File Offset: 0x009C7537
		// (set) Token: 0x06025F17 RID: 155415 RVA: 0x009C9347 File Offset: 0x009C7547
		public unsafe float 抖动触发概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170054A4 RID: 21668
		// (get) Token: 0x06025F18 RID: 155416 RVA: 0x009C9358 File Offset: 0x009C7558
		// (set) Token: 0x06025F19 RID: 155417 RVA: 0x009C9368 File Offset: 0x009C7568
		public unsafe float 每次抖动最小时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170054A5 RID: 21669
		// (get) Token: 0x06025F1A RID: 155418 RVA: 0x009C9379 File Offset: 0x009C7579
		// (set) Token: 0x06025F1B RID: 155419 RVA: 0x009C9389 File Offset: 0x009C7589
		public unsafe float 每次抖动最大时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170054A6 RID: 21670
		// (get) Token: 0x06025F1C RID: 155420 RVA: 0x009C939A File Offset: 0x009C759A
		// (set) Token: 0x06025F1D RID: 155421 RVA: 0x009C93AA File Offset: 0x009C75AA
		public unsafe float 扰动强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170054A7 RID: 21671
		// (get) Token: 0x06025F1E RID: 155422 RVA: 0x009C93BB File Offset: 0x009C75BB
		// (set) Token: 0x06025F1F RID: 155423 RVA: 0x009C93CB File Offset: 0x009C75CB
		public unsafe float 扰动触发频率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170054A8 RID: 21672
		// (get) Token: 0x06025F20 RID: 155424 RVA: 0x009C93DC File Offset: 0x009C75DC
		// (set) Token: 0x06025F21 RID: 155425 RVA: 0x009C93EC File Offset: 0x009C75EC
		public unsafe float 扰动触发概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170054A9 RID: 21673
		// (get) Token: 0x06025F22 RID: 155426 RVA: 0x009C93FD File Offset: 0x009C75FD
		// (set) Token: 0x06025F23 RID: 155427 RVA: 0x009C940D File Offset: 0x009C760D
		public unsafe int WiggleCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170054AA RID: 21674
		// (get) Token: 0x06025F24 RID: 155428 RVA: 0x009C941E File Offset: 0x009C761E
		// (set) Token: 0x06025F25 RID: 155429 RVA: 0x009C942E File Offset: 0x009C762E
		public unsafe int SignalCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170054AB RID: 21675
		// (get) Token: 0x06025F26 RID: 155430 RVA: 0x009C943F File Offset: 0x009C763F
		// (set) Token: 0x06025F27 RID: 155431 RVA: 0x009C944F File Offset: 0x009C764F
		public unsafe float 每次扰动最小时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170054AC RID: 21676
		// (get) Token: 0x06025F28 RID: 155432 RVA: 0x009C9460 File Offset: 0x009C7660
		// (set) Token: 0x06025F29 RID: 155433 RVA: 0x009C9470 File Offset: 0x009C7670
		public unsafe float 每次扰动最大时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170054AD RID: 21677
		// (get) Token: 0x06025F2A RID: 155434 RVA: 0x009C9481 File Offset: 0x009C7681
		// (set) Token: 0x06025F2B RID: 155435 RVA: 0x009C9491 File Offset: 0x009C7691
		public unsafe float WiggleTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170054AE RID: 21678
		// (get) Token: 0x06025F2C RID: 155436 RVA: 0x009C94A2 File Offset: 0x009C76A2
		// (set) Token: 0x06025F2D RID: 155437 RVA: 0x009C94B2 File Offset: 0x009C76B2
		public unsafe float SignalTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170054AF RID: 21679
		// (get) Token: 0x06025F2E RID: 155438 RVA: 0x009C94C3 File Offset: 0x009C76C3
		// (set) Token: 0x06025F2F RID: 155439 RVA: 0x009C94D7 File Offset: 0x009C76D7
		public unsafe FVector WaveDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170054B0 RID: 21680
		// (get) Token: 0x06025F30 RID: 155440 RVA: 0x009C94EC File Offset: 0x009C76EC
		// (set) Token: 0x06025F31 RID: 155441 RVA: 0x009C94FC File Offset: 0x009C76FC
		public unsafe float Wave_Interval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170054B1 RID: 21681
		// (get) Token: 0x06025F32 RID: 155442 RVA: 0x009C950D File Offset: 0x009C770D
		// (set) Token: 0x06025F33 RID: 155443 RVA: 0x009C951D File Offset: 0x009C771D
		public unsafe float Wave_Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170054B2 RID: 21682
		// (get) Token: 0x06025F34 RID: 155444 RVA: 0x009C952E File Offset: 0x009C772E
		// (set) Token: 0x06025F35 RID: 155445 RVA: 0x009C953E File Offset: 0x009C773E
		public unsafe float Wave_Phase_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DataDistortionController_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x06025F36 RID: 155446 RVA: 0x009C954F File Offset: 0x009C774F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDataDistortionControl()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DataDistortionController_C.__UpdateDataDistortionControl_NativeFunctionPtr, null);
		}

		// Token: 0x06025F37 RID: 155447 RVA: 0x009C9563 File Offset: 0x009C7763
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDataDistortion()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DataDistortionController_C.__UpdateDataDistortion_NativeFunctionPtr, null);
		}

		// Token: 0x06025F38 RID: 155448 RVA: 0x009C9577 File Offset: 0x009C7777
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DataDistortionController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025F39 RID: 155449 RVA: 0x009C958B File Offset: 0x009C778B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DataDistortionController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025F3A RID: 155450 RVA: 0x009C95A0 File Offset: 0x009C77A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DataDistortionController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DataDistortionController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DataDistortionController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DataDistortionController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DataDistortionController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025F3B RID: 155451 RVA: 0x009C95E8 File Offset: 0x009C77E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DataDistortionController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DataDistortionController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DataDistortionController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DataDistortionController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DataDistortionController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F3C RID: 155452 RVA: 0x009C9630 File Offset: 0x009C7830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_DataDistortionController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_DataDistortionController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DataDistortionController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DataDistortionController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DataDistortionController_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025F3D RID: 155453 RVA: 0x009C9678 File Offset: 0x009C7878
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_DataDistortionController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_DataDistortionController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DataDistortionController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DataDistortionController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DataDistortionController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F3E RID: 155454 RVA: 0x009C96C0 File Offset: 0x009C78C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DataDistortionController(int EntryPoint)
		{
			BP_DataDistortionController_C.__ExecuteUbergraph_BP_DataDistortionController_FunctionParams* ptr = stackalloc BP_DataDistortionController_C.__ExecuteUbergraph_BP_DataDistortionController_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_DataDistortionController_C.__ExecuteUbergraph_BP_DataDistortionController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DataDistortionController_C.__ExecuteUbergraph_BP_DataDistortionController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DataDistortionController_C.__ExecuteUbergraph_BP_DataDistortionController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025F3F RID: 155455 RVA: 0x009C9707 File Offset: 0x009C7907
		protected BP_DataDistortionController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040139C9 RID: 80329
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Scene/BP_DataDistortionController.BP_DataDistortionController_C";

		// Token: 0x040139CA RID: 80330
		private static IntPtr _ClassPtr;

		// Token: 0x040139CB RID: 80331
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040139CC RID: 80332
		internal static int __PropertyOffset_0;

		// Token: 0x040139CD RID: 80333
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040139CE RID: 80334
		internal static int __PropertyOffset_1;

		// Token: 0x040139CF RID: 80335
		internal static int __PropertyOffset_2;

		// Token: 0x040139D0 RID: 80336
		internal static int __PropertyOffset_3;

		// Token: 0x040139D1 RID: 80337
		internal static int __PropertyOffset_4;

		// Token: 0x040139D2 RID: 80338
		internal static int __PropertyOffset_5;

		// Token: 0x040139D3 RID: 80339
		internal static int __PropertyOffset_6;

		// Token: 0x040139D4 RID: 80340
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCurveFloat> _WiggleCurves;

		// Token: 0x040139D5 RID: 80341
		internal static int __PropertyOffset_7;

		// Token: 0x040139D6 RID: 80342
		[Nullable(2)]
		private TArray<float> _WiggleCurvePeriods;

		// Token: 0x040139D7 RID: 80343
		internal static int __PropertyOffset_8;

		// Token: 0x040139D8 RID: 80344
		internal static int __PropertyOffset_9;

		// Token: 0x040139D9 RID: 80345
		internal static int __PropertyOffset_10;

		// Token: 0x040139DA RID: 80346
		internal static int __PropertyOffset_11;

		// Token: 0x040139DB RID: 80347
		[Nullable(2)]
		private FKuroCurveLinearColor _ColorCurve;

		// Token: 0x040139DC RID: 80348
		internal static int __PropertyOffset_12;

		// Token: 0x040139DD RID: 80349
		[Nullable(2)]
		private FKuroCurveFloat _SignalCurve;

		// Token: 0x040139DE RID: 80350
		internal static int __PropertyOffset_13;

		// Token: 0x040139DF RID: 80351
		[Nullable(2)]
		private FKuroCurveFloat _SignalColorCurve;

		// Token: 0x040139E0 RID: 80352
		internal static int __PropertyOffset_14;

		// Token: 0x040139E1 RID: 80353
		internal static int __PropertyOffset_15;

		// Token: 0x040139E2 RID: 80354
		internal static int __PropertyOffset_16;

		// Token: 0x040139E3 RID: 80355
		internal static int __PropertyOffset_17;

		// Token: 0x040139E4 RID: 80356
		internal static int __PropertyOffset_18;

		// Token: 0x040139E5 RID: 80357
		internal static int __PropertyOffset_19;

		// Token: 0x040139E6 RID: 80358
		internal static int __PropertyOffset_20;

		// Token: 0x040139E7 RID: 80359
		internal static int __PropertyOffset_21;

		// Token: 0x040139E8 RID: 80360
		internal static int __PropertyOffset_22;

		// Token: 0x040139E9 RID: 80361
		internal static int __PropertyOffset_23;

		// Token: 0x040139EA RID: 80362
		internal static int __PropertyOffset_24;

		// Token: 0x040139EB RID: 80363
		internal static int __PropertyOffset_25;

		// Token: 0x040139EC RID: 80364
		internal static int __PropertyOffset_26;

		// Token: 0x040139ED RID: 80365
		internal static int __PropertyOffset_27;

		// Token: 0x040139EE RID: 80366
		internal static int __PropertyOffset_28;

		// Token: 0x040139EF RID: 80367
		internal static int __PropertyOffset_29;

		// Token: 0x040139F0 RID: 80368
		internal static int __PropertyOffset_30;

		// Token: 0x040139F1 RID: 80369
		internal static int __PropertyOffset_31;

		// Token: 0x040139F2 RID: 80370
		internal static int __PropertyOffset_32;

		// Token: 0x040139F3 RID: 80371
		internal static int __PropertyOffset_33;

		// Token: 0x040139F4 RID: 80372
		internal static int __PropertyOffset_34;

		// Token: 0x040139F5 RID: 80373
		private static IntPtr __UpdateDataDistortionControl_NativeFunctionPtr;

		// Token: 0x040139F6 RID: 80374
		private static IntPtr __UpdateDataDistortion_NativeFunctionPtr;

		// Token: 0x040139F7 RID: 80375
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040139F8 RID: 80376
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040139F9 RID: 80377
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040139FA RID: 80378
		private static IntPtr __ExecuteUbergraph_BP_DataDistortionController_NativeFunctionPtr;

		// Token: 0x02009FCF RID: 40911
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B87 RID: 207751
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FD0 RID: 40912
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032B88 RID: 207752
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FD1 RID: 40913
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_DataDistortionController_FunctionParams
		{
			// Token: 0x04032B89 RID: 207753
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
