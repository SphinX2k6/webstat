using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Portal
{
	// Token: 0x02003D3A RID: 15674
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Portal/BP_Portal.BP_Portal_C")]
	[UnrealStructLayout(1856, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1841)]
	public class BP_Portal_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602601D RID: 155677 RVA: 0x009CB013 File Offset: 0x009C9213
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Portal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Portal/BP_Portal.BP_Portal_C");
			}
			return BP_Portal_C._ClassPtr;
		}

		// Token: 0x0602601E RID: 155678 RVA: 0x009CB038 File Offset: 0x009C9238
		public BP_Portal_C() : this(BuiltinUtils.AllocNativeUObject(BP_Portal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602601F RID: 155679 RVA: 0x009CB060 File Offset: 0x009C9260
		[NullableContext(1)]
		public BP_Portal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Portal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170054FF RID: 21759
		// (get) Token: 0x06026020 RID: 155680 RVA: 0x009CB094 File Offset: 0x009C9294
		// (set) Token: 0x06026021 RID: 155681 RVA: 0x009CB0CD File Offset: 0x009C92CD
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005500 RID: 21760
		// (get) Token: 0x06026022 RID: 155682 RVA: 0x009CB0EE File Offset: 0x009C92EE
		// (set) Token: 0x06026023 RID: 155683 RVA: 0x009CB102 File Offset: 0x009C9302
		public unsafe USceneCaptureComponent2D CapturePosition1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005501 RID: 21761
		// (get) Token: 0x06026024 RID: 155684 RVA: 0x009CB117 File Offset: 0x009C9317
		// (set) Token: 0x06026025 RID: 155685 RVA: 0x009CB12B File Offset: 0x009C932B
		public unsafe USceneCaptureComponent2D CapturePosition2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005502 RID: 21762
		// (get) Token: 0x06026026 RID: 155686 RVA: 0x009CB140 File Offset: 0x009C9340
		// (set) Token: 0x06026027 RID: 155687 RVA: 0x009CB154 File Offset: 0x009C9354
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005503 RID: 21763
		// (get) Token: 0x06026028 RID: 155688 RVA: 0x009CB169 File Offset: 0x009C9369
		// (set) Token: 0x06026029 RID: 155689 RVA: 0x009CB17D File Offset: 0x009C937D
		public unsafe FTransformDouble PortalWorldTransform1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005504 RID: 21764
		// (get) Token: 0x0602602A RID: 155690 RVA: 0x009CB192 File Offset: 0x009C9392
		// (set) Token: 0x0602602B RID: 155691 RVA: 0x009CB1A6 File Offset: 0x009C93A6
		public unsafe FTransformDouble PortalWorldTransform2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005505 RID: 21765
		// (get) Token: 0x0602602C RID: 155692 RVA: 0x009CB1BB File Offset: 0x009C93BB
		// (set) Token: 0x0602602D RID: 155693 RVA: 0x009CB1CF File Offset: 0x009C93CF
		public unsafe UMaterialInstanceDynamic DMI_Portal1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005506 RID: 21766
		// (get) Token: 0x0602602E RID: 155694 RVA: 0x009CB1E4 File Offset: 0x009C93E4
		// (set) Token: 0x0602602F RID: 155695 RVA: 0x009CB1F8 File Offset: 0x009C93F8
		public unsafe UMaterialInstanceDynamic DMI_Portal2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005507 RID: 21767
		// (get) Token: 0x06026030 RID: 155696 RVA: 0x009CB20D File Offset: 0x009C940D
		// (set) Token: 0x06026031 RID: 155697 RVA: 0x009CB221 File Offset: 0x009C9421
		public unsafe FLinearColor PortalColor1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005508 RID: 21768
		// (get) Token: 0x06026032 RID: 155698 RVA: 0x009CB236 File Offset: 0x009C9436
		// (set) Token: 0x06026033 RID: 155699 RVA: 0x009CB24A File Offset: 0x009C944A
		public unsafe FLinearColor PortalColor2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005509 RID: 21769
		// (get) Token: 0x06026034 RID: 155700 RVA: 0x009CB25F File Offset: 0x009C945F
		// (set) Token: 0x06026035 RID: 155701 RVA: 0x009CB273 File Offset: 0x009C9473
		public unsafe AActor DebugActor1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700550A RID: 21770
		// (get) Token: 0x06026036 RID: 155702 RVA: 0x009CB288 File Offset: 0x009C9488
		// (set) Token: 0x06026037 RID: 155703 RVA: 0x009CB29C File Offset: 0x009C949C
		public unsafe AActor DebugActor2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700550B RID: 21771
		// (get) Token: 0x06026038 RID: 155704 RVA: 0x009CB2B1 File Offset: 0x009C94B1
		// (set) Token: 0x06026039 RID: 155705 RVA: 0x009CB2C1 File Offset: 0x009C94C1
		public unsafe bool Portal1Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700550C RID: 21772
		// (get) Token: 0x0602603A RID: 155706 RVA: 0x009CB2D2 File Offset: 0x009C94D2
		// (set) Token: 0x0602603B RID: 155707 RVA: 0x009CB2E2 File Offset: 0x009C94E2
		public unsafe bool Portal2Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700550D RID: 21773
		// (get) Token: 0x0602603C RID: 155708 RVA: 0x009CB2F3 File Offset: 0x009C94F3
		// (set) Token: 0x0602603D RID: 155709 RVA: 0x009CB307 File Offset: 0x009C9507
		public unsafe UTextureRenderTarget2D RT2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700550E RID: 21774
		// (get) Token: 0x0602603E RID: 155710 RVA: 0x009CB31C File Offset: 0x009C951C
		// (set) Token: 0x0602603F RID: 155711 RVA: 0x009CB32C File Offset: 0x009C952C
		public unsafe float AnimShowLen_Portal1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700550F RID: 21775
		// (get) Token: 0x06026040 RID: 155712 RVA: 0x009CB33D File Offset: 0x009C953D
		// (set) Token: 0x06026041 RID: 155713 RVA: 0x009CB34D File Offset: 0x009C954D
		public unsafe float AnimFadeLen_Portal1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005510 RID: 21776
		// (get) Token: 0x06026042 RID: 155714 RVA: 0x009CB35E File Offset: 0x009C955E
		// (set) Token: 0x06026043 RID: 155715 RVA: 0x009CB36E File Offset: 0x009C956E
		public unsafe bool AnimIsShowing_Portal1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005511 RID: 21777
		// (get) Token: 0x06026044 RID: 155716 RVA: 0x009CB37F File Offset: 0x009C957F
		// (set) Token: 0x06026045 RID: 155717 RVA: 0x009CB393 File Offset: 0x009C9593
		public unsafe UCurveFloat AnimShowCurve_Portal1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17005512 RID: 21778
		// (get) Token: 0x06026046 RID: 155718 RVA: 0x009CB3A8 File Offset: 0x009C95A8
		// (set) Token: 0x06026047 RID: 155719 RVA: 0x009CB3BC File Offset: 0x009C95BC
		public unsafe UCurveFloat AnimFadeCurve_Portal1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17005513 RID: 21779
		// (get) Token: 0x06026048 RID: 155720 RVA: 0x009CB3D1 File Offset: 0x009C95D1
		// (set) Token: 0x06026049 RID: 155721 RVA: 0x009CB3E1 File Offset: 0x009C95E1
		public unsafe float AnimCounter_Portal1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005514 RID: 21780
		// (get) Token: 0x0602604A RID: 155722 RVA: 0x009CB3F2 File Offset: 0x009C95F2
		// (set) Token: 0x0602604B RID: 155723 RVA: 0x009CB402 File Offset: 0x009C9602
		public unsafe float AnimShowLen_Portal2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005515 RID: 21781
		// (get) Token: 0x0602604C RID: 155724 RVA: 0x009CB413 File Offset: 0x009C9613
		// (set) Token: 0x0602604D RID: 155725 RVA: 0x009CB423 File Offset: 0x009C9623
		public unsafe float AnimFadeLen_Portal2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005516 RID: 21782
		// (get) Token: 0x0602604E RID: 155726 RVA: 0x009CB434 File Offset: 0x009C9634
		// (set) Token: 0x0602604F RID: 155727 RVA: 0x009CB444 File Offset: 0x009C9644
		public unsafe bool AnimIsShowing_Portal2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005517 RID: 21783
		// (get) Token: 0x06026050 RID: 155728 RVA: 0x009CB455 File Offset: 0x009C9655
		// (set) Token: 0x06026051 RID: 155729 RVA: 0x009CB469 File Offset: 0x009C9669
		public unsafe UCurveFloat AnimShowCurve_Portal2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17005518 RID: 21784
		// (get) Token: 0x06026052 RID: 155730 RVA: 0x009CB47E File Offset: 0x009C967E
		// (set) Token: 0x06026053 RID: 155731 RVA: 0x009CB492 File Offset: 0x009C9692
		public unsafe UCurveFloat AnimFadeCurve_Portal2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17005519 RID: 21785
		// (get) Token: 0x06026054 RID: 155732 RVA: 0x009CB4A7 File Offset: 0x009C96A7
		// (set) Token: 0x06026055 RID: 155733 RVA: 0x009CB4B7 File Offset: 0x009C96B7
		public unsafe float AnimCounter_Portal2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700551A RID: 21786
		// (get) Token: 0x06026056 RID: 155734 RVA: 0x009CB4C8 File Offset: 0x009C96C8
		// (set) Token: 0x06026057 RID: 155735 RVA: 0x009CB4DC File Offset: 0x009C96DC
		public unsafe UTextureRenderTarget2D RT1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Portal_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x1700551B RID: 21787
		// (get) Token: 0x06026058 RID: 155736 RVA: 0x009CB4F4 File Offset: 0x009C96F4
		// (set) Token: 0x06026059 RID: 155737 RVA: 0x009CB52D File Offset: 0x009C972D
		[Nullable(1)]
		public FSoftObjectPath EffectData_1
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._EffectData_1) == null)
				{
					result = (this._EffectData_1 = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_28, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700551C RID: 21788
		// (get) Token: 0x0602605A RID: 155738 RVA: 0x009CB550 File Offset: 0x009C9750
		// (set) Token: 0x0602605B RID: 155739 RVA: 0x009CB589 File Offset: 0x009C9789
		[Nullable(1)]
		public FSoftObjectPath EffectData_2
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._EffectData_2) == null)
				{
					result = (this._EffectData_2 = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_29, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700551D RID: 21789
		// (get) Token: 0x0602605C RID: 155740 RVA: 0x009CB5AA File Offset: 0x009C97AA
		// (set) Token: 0x0602605D RID: 155741 RVA: 0x009CB5BE File Offset: 0x009C97BE
		public unsafe FVector PortalBounds1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700551E RID: 21790
		// (get) Token: 0x0602605E RID: 155742 RVA: 0x009CB5D3 File Offset: 0x009C97D3
		// (set) Token: 0x0602605F RID: 155743 RVA: 0x009CB5E3 File Offset: 0x009C97E3
		public unsafe bool EnableDebugCamera1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700551F RID: 21791
		// (get) Token: 0x06026060 RID: 155744 RVA: 0x009CB5F4 File Offset: 0x009C97F4
		// (set) Token: 0x06026061 RID: 155745 RVA: 0x009CB604 File Offset: 0x009C9804
		public unsafe bool EnableDebugCamera2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005520 RID: 21792
		// (get) Token: 0x06026062 RID: 155746 RVA: 0x009CB615 File Offset: 0x009C9815
		// (set) Token: 0x06026063 RID: 155747 RVA: 0x009CB629 File Offset: 0x009C9829
		public unsafe FVector PortalBounds2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17005521 RID: 21793
		// (get) Token: 0x06026064 RID: 155748 RVA: 0x009CB640 File Offset: 0x009C9840
		// (set) Token: 0x06026065 RID: 155749 RVA: 0x009CB679 File Offset: 0x009C9879
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Mobile_VeryLow
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Mobile_VeryLow) == null)
				{
					result = (this._CaptureConfig_Mobile_VeryLow = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_34, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005522 RID: 21794
		// (get) Token: 0x06026066 RID: 155750 RVA: 0x009CB69C File Offset: 0x009C989C
		// (set) Token: 0x06026067 RID: 155751 RVA: 0x009CB6D5 File Offset: 0x009C98D5
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Mobile_Low
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Mobile_Low) == null)
				{
					result = (this._CaptureConfig_Mobile_Low = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_35, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005523 RID: 21795
		// (get) Token: 0x06026068 RID: 155752 RVA: 0x009CB6F8 File Offset: 0x009C98F8
		// (set) Token: 0x06026069 RID: 155753 RVA: 0x009CB731 File Offset: 0x009C9931
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Mobile_Mid
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Mobile_Mid) == null)
				{
					result = (this._CaptureConfig_Mobile_Mid = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_36, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005524 RID: 21796
		// (get) Token: 0x0602606A RID: 155754 RVA: 0x009CB754 File Offset: 0x009C9954
		// (set) Token: 0x0602606B RID: 155755 RVA: 0x009CB78D File Offset: 0x009C998D
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Mobile_High
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Mobile_High) == null)
				{
					result = (this._CaptureConfig_Mobile_High = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_37, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005525 RID: 21797
		// (get) Token: 0x0602606C RID: 155756 RVA: 0x009CB7B0 File Offset: 0x009C99B0
		// (set) Token: 0x0602606D RID: 155757 RVA: 0x009CB7E9 File Offset: 0x009C99E9
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Pc_VeryLow
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Pc_VeryLow) == null)
				{
					result = (this._CaptureConfig_Pc_VeryLow = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_38, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005526 RID: 21798
		// (get) Token: 0x0602606E RID: 155758 RVA: 0x009CB80C File Offset: 0x009C9A0C
		// (set) Token: 0x0602606F RID: 155759 RVA: 0x009CB845 File Offset: 0x009C9A45
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Pc_Low
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Pc_Low) == null)
				{
					result = (this._CaptureConfig_Pc_Low = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_39, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005527 RID: 21799
		// (get) Token: 0x06026070 RID: 155760 RVA: 0x009CB868 File Offset: 0x009C9A68
		// (set) Token: 0x06026071 RID: 155761 RVA: 0x009CB8A1 File Offset: 0x009C9AA1
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Pc_Mid
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Pc_Mid) == null)
				{
					result = (this._CaptureConfig_Pc_Mid = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_40, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005528 RID: 21800
		// (get) Token: 0x06026072 RID: 155762 RVA: 0x009CB8C4 File Offset: 0x009C9AC4
		// (set) Token: 0x06026073 RID: 155763 RVA: 0x009CB8FD File Offset: 0x009C9AFD
		[Nullable(1)]
		public FSceneCaptureComponent2DParams CaptureConfig_Pc_High
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSceneCaptureComponent2DParams result;
				if ((result = this._CaptureConfig_Pc_High) == null)
				{
					result = (this._CaptureConfig_Pc_High = new FSceneCaptureComponent2DParams(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_41, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005529 RID: 21801
		// (get) Token: 0x06026074 RID: 155764 RVA: 0x009CB91E File Offset: 0x009C9B1E
		// (set) Token: 0x06026075 RID: 155765 RVA: 0x009CB92E File Offset: 0x009C9B2E
		public unsafe bool IsMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700552A RID: 21802
		// (get) Token: 0x06026076 RID: 155766 RVA: 0x009CB93F File Offset: 0x009C9B3F
		// (set) Token: 0x06026077 RID: 155767 RVA: 0x009CB94F File Offset: 0x009C9B4F
		public unsafe int PerformanceLevel_A
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x1700552B RID: 21803
		// (get) Token: 0x06026078 RID: 155768 RVA: 0x009CB960 File Offset: 0x009C9B60
		// (set) Token: 0x06026079 RID: 155769 RVA: 0x009CB970 File Offset: 0x009C9B70
		public unsafe int PerformanceLevel_B
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x1700552C RID: 21804
		// (get) Token: 0x0602607A RID: 155770 RVA: 0x009CB981 File Offset: 0x009C9B81
		// (set) Token: 0x0602607B RID: 155771 RVA: 0x009CB991 File Offset: 0x009C9B91
		public unsafe float CaptureMaxViewDistance_A
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x1700552D RID: 21805
		// (get) Token: 0x0602607C RID: 155772 RVA: 0x009CB9A2 File Offset: 0x009C9BA2
		// (set) Token: 0x0602607D RID: 155773 RVA: 0x009CB9B2 File Offset: 0x009C9BB2
		public unsafe float CaptureMaxViewDistance_B
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x1700552E RID: 21806
		// (get) Token: 0x0602607E RID: 155774 RVA: 0x009CB9C3 File Offset: 0x009C9BC3
		// (set) Token: 0x0602607F RID: 155775 RVA: 0x009CB9D3 File Offset: 0x009C9BD3
		public unsafe bool EnableDebugCapture1Params
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700552F RID: 21807
		// (get) Token: 0x06026080 RID: 155776 RVA: 0x009CB9E4 File Offset: 0x009C9BE4
		// (set) Token: 0x06026081 RID: 155777 RVA: 0x009CB9F4 File Offset: 0x009C9BF4
		public unsafe bool EnableDebugCapture2Params
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005530 RID: 21808
		// (get) Token: 0x06026082 RID: 155778 RVA: 0x009CBA05 File Offset: 0x009C9C05
		// (set) Token: 0x06026083 RID: 155779 RVA: 0x009CBA15 File Offset: 0x009C9C15
		public unsafe float CapturePerf_Lv0_MaxDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17005531 RID: 21809
		// (get) Token: 0x06026084 RID: 155780 RVA: 0x009CBA26 File Offset: 0x009C9C26
		// (set) Token: 0x06026085 RID: 155781 RVA: 0x009CBA36 File Offset: 0x009C9C36
		public unsafe float CapturePerf_Lv1_MaxDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17005532 RID: 21810
		// (get) Token: 0x06026086 RID: 155782 RVA: 0x009CBA47 File Offset: 0x009C9C47
		// (set) Token: 0x06026087 RID: 155783 RVA: 0x009CBA57 File Offset: 0x009C9C57
		public unsafe float CapturePerf_Lv2_MaxDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17005533 RID: 21811
		// (get) Token: 0x06026088 RID: 155784 RVA: 0x009CBA68 File Offset: 0x009C9C68
		// (set) Token: 0x06026089 RID: 155785 RVA: 0x009CBAA1 File Offset: 0x009C9CA1
		[Nullable(1)]
		public TMap<string, bool> Capture1InitShowFlags
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<string, bool> result;
				if ((result = this._Capture1InitShowFlags) == null)
				{
					result = (this._Capture1InitShowFlags = new TMap<string, bool>(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_52, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Capture1InitShowFlags.CopyAssign(value);
			}
		}

		// Token: 0x17005534 RID: 21812
		// (get) Token: 0x0602608A RID: 155786 RVA: 0x009CBAB0 File Offset: 0x009C9CB0
		// (set) Token: 0x0602608B RID: 155787 RVA: 0x009CBAE9 File Offset: 0x009C9CE9
		[Nullable(1)]
		public TMap<string, bool> Capture2InitShowFlags
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<string, bool> result;
				if ((result = this._Capture2InitShowFlags) == null)
				{
					result = (this._Capture2InitShowFlags = new TMap<string, bool>(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_53, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Capture2InitShowFlags.CopyAssign(value);
			}
		}

		// Token: 0x17005535 RID: 21813
		// (get) Token: 0x0602608C RID: 155788 RVA: 0x009CBAF7 File Offset: 0x009C9CF7
		// (set) Token: 0x0602608D RID: 155789 RVA: 0x009CBB07 File Offset: 0x009C9D07
		public unsafe bool IsMac
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Portal_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602608E RID: 155790 RVA: 0x009CBB18 File Offset: 0x009C9D18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DrawDebugPortalBounds(bool IsPortal1)
		{
			BP_Portal_C.__DrawDebugPortalBounds_FunctionParams* ptr = stackalloc BP_Portal_C.__DrawDebugPortalBounds_FunctionParams[(UIntPtr)351] + 15L / (long)sizeof(BP_Portal_C.__DrawDebugPortalBounds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__DrawDebugPortalBounds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsPortal1 = IsPortal1;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DrawDebugPortalBounds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602608F RID: 155791 RVA: 0x009CBB64 File Offset: 0x009C9D64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PrintDebugCaptureParams(bool IsCapture1, FSceneCaptureComponent2DParams CaptureParam)
		{
			BP_Portal_C.__PrintDebugCaptureParams_FunctionParams* ptr = stackalloc BP_Portal_C.__PrintDebugCaptureParams_FunctionParams[(UIntPtr)815] + 15L / (long)sizeof(BP_Portal_C.__PrintDebugCaptureParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__PrintDebugCaptureParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsCapture1 = IsCapture1;
			if (CaptureParam != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FSceneCaptureComponent2DParams.StaticStruct(), &ptr->CaptureParam, CaptureParam.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__PrintDebugCaptureParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026090 RID: 155792 RVA: 0x009CBBD0 File Offset: 0x009C9DD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckCapturePerformanceLevel(bool isPortalA, FTransformDouble targetTrans)
		{
			BP_Portal_C.__CheckCapturePerformanceLevel_FunctionParams* ptr = stackalloc BP_Portal_C.__CheckCapturePerformanceLevel_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_Portal_C.__CheckCapturePerformanceLevel_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__CheckCapturePerformanceLevel_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPortalA = isPortalA;
			ptr->targetTrans = targetTrans;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__CheckCapturePerformanceLevel_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026091 RID: 155793 RVA: 0x009CBC20 File Offset: 0x009C9E20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyCapturePerformace(bool IsPortalA, int ConfigLevel, float CaptureMaxViewDistance)
		{
			BP_Portal_C.__ApplyCapturePerformace_FunctionParams* ptr = stackalloc BP_Portal_C.__ApplyCapturePerformace_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_Portal_C.__ApplyCapturePerformace_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__ApplyCapturePerformace_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsPortalA = IsPortalA;
			ptr->ConfigLevel = ConfigLevel;
			ptr->CaptureMaxViewDistance = CaptureMaxViewDistance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__ApplyCapturePerformace_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026092 RID: 155794 RVA: 0x009CBC74 File Offset: 0x009C9E74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAngleBetweenVector(FVector Vector1, FVector Vector2, ref float Angle)
		{
			BP_Portal_C.__GetAngleBetweenVector_FunctionParams* ptr = stackalloc BP_Portal_C.__GetAngleBetweenVector_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_Portal_C.__GetAngleBetweenVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__GetAngleBetweenVector_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vector1 = Vector1;
			ptr->Vector2 = Vector2;
			ptr->Angle = Angle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__GetAngleBetweenVector_NativeFunctionPtr, (void*)ptr);
			Angle = ptr->Angle;
		}

		// Token: 0x06026093 RID: 155795 RVA: 0x009CBCD4 File Offset: 0x009C9ED4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DrawDebugFrustum(FTransformDouble Transform, float FovX, float NearClipPlane, float AspectRatio)
		{
			BP_Portal_C.__DrawDebugFrustum_FunctionParams* ptr = stackalloc BP_Portal_C.__DrawDebugFrustum_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_Portal_C.__DrawDebugFrustum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__DrawDebugFrustum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Transform = Transform;
			ptr->FovX = FovX;
			ptr->NearClipPlane = NearClipPlane;
			ptr->AspectRatio = AspectRatio;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DrawDebugFrustum_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026094 RID: 155796 RVA: 0x009CBD34 File Offset: 0x009C9F34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMappingTransformToOtherPortal(FTransformDouble SourceTransform, bool bA2B, ref FTransformDouble TargetTransform)
		{
			BP_Portal_C.__GetMappingTransformToOtherPortal_FunctionParams* ptr = stackalloc BP_Portal_C.__GetMappingTransformToOtherPortal_FunctionParams[(UIntPtr)607] + 15L / (long)sizeof(BP_Portal_C.__GetMappingTransformToOtherPortal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__GetMappingTransformToOtherPortal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SourceTransform = SourceTransform;
			ptr->bA2B = bA2B;
			ptr->TargetTransform = TargetTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__GetMappingTransformToOtherPortal_NativeFunctionPtr, (void*)ptr);
			TargetTransform = ptr->TargetTransform;
		}

		// Token: 0x06026095 RID: 155797 RVA: 0x009CBD9C File Offset: 0x009C9F9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePortalsCameraPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__UpdatePortalsCameraPosition_NativeFunctionPtr, null);
		}

		// Token: 0x06026096 RID: 155798 RVA: 0x009CBDB0 File Offset: 0x009C9FB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdatePortalAnimation(float ShowLen, float FadeLen, bool IsShown, UCurveFloat ShowCurve, UCurveFloat FadeCurve, float Counter, UStaticMeshComponent SM, UStaticMeshComponent DMI, ref float OutputCounter, ref float Factor)
		{
			BP_Portal_C.__UpdatePortalAnimation_FunctionParams* ptr = stackalloc BP_Portal_C.__UpdatePortalAnimation_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_Portal_C.__UpdatePortalAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__UpdatePortalAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ShowLen = ShowLen;
			ptr->FadeLen = FadeLen;
			ptr->IsShown = IsShown;
			ptr->ShowCurve = ((ShowCurve != null) ? ShowCurve.NativePtr : IntPtr.Zero);
			ptr->FadeCurve = ((FadeCurve != null) ? FadeCurve.NativePtr : IntPtr.Zero);
			ptr->Counter = Counter;
			ptr->SM = ((SM != null) ? SM.NativePtr : IntPtr.Zero);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->OutputCounter = OutputCounter;
			ptr->Factor = Factor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__UpdatePortalAnimation_NativeFunctionPtr, (void*)ptr);
			OutputCounter = ptr->OutputCounter;
			Factor = ptr->Factor;
		}

		// Token: 0x06026097 RID: 155799 RVA: 0x009CBE90 File Offset: 0x009CA090
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetCaptureShowFlags(bool IsCapture1, [Nullable(new byte[]
		{
			2,
			1
		})] TMap<string, bool> ShowFlags)
		{
			BP_Portal_C.__SetCaptureShowFlags_FunctionParams* ptr = stackalloc BP_Portal_C.__SetCaptureShowFlags_FunctionParams[(UIntPtr)543] + 15L / (long)sizeof(BP_Portal_C.__SetCaptureShowFlags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__SetCaptureShowFlags_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsCapture1 = IsCapture1;
			if (ShowFlags != null)
			{
				ShowFlags.CopyTo(&ptr->ShowFlags, default(UScriptStructStackOnlyPtr));
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__SetCaptureShowFlags_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_Portal_C.__SetCaptureShowFlags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026098 RID: 155800 RVA: 0x009CBF04 File Offset: 0x009CA104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCaptureShowFlags(bool IsCapture1, [Nullable(new byte[]
		{
			2,
			1
		})] ref TMap<string, bool> ShowFlags)
		{
			BP_Portal_C.__GetCaptureShowFlags_FunctionParams* ptr = stackalloc BP_Portal_C.__GetCaptureShowFlags_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_Portal_C.__GetCaptureShowFlags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__GetCaptureShowFlags_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsCapture1 = IsCapture1;
			TMap<string, bool> tmap = ShowFlags;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->ShowFlags);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__GetCaptureShowFlags_NativeFunctionPtr, (void*)ptr);
			TMap<string, bool> tmap2 = ShowFlags;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->ShowFlags);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Portal_C.__GetCaptureShowFlags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026099 RID: 155801 RVA: 0x009CBF88 File Offset: 0x009CA188
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetCaptureMaxViewDistance(bool IsCapture1, float MaxViewDistance)
		{
			BP_Portal_C.__SetCaptureMaxViewDistance_FunctionParams* ptr = stackalloc BP_Portal_C.__SetCaptureMaxViewDistance_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_Portal_C.__SetCaptureMaxViewDistance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__SetCaptureMaxViewDistance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsCapture1 = IsCapture1;
			ptr->MaxViewDistance = MaxViewDistance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__SetCaptureMaxViewDistance_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602609A RID: 155802 RVA: 0x009CBFD8 File Offset: 0x009CA1D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetCaptureShowingActors(bool IsCapture1, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<AActor> HiddenActors, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<AActor> ForceShowActors)
		{
			BP_Portal_C.__SetCaptureShowingActors_FunctionParams* ptr = stackalloc BP_Portal_C.__SetCaptureShowingActors_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Portal_C.__SetCaptureShowingActors_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__SetCaptureShowingActors_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsCapture1 = IsCapture1;
			TArray<AActor> tarray = HiddenActors;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->HiddenActors);
			}
			TArray<AActor> tarray2 = ForceShowActors;
			if (tarray2 != null)
			{
				tarray2.MoveTo(&ptr->ForceShowActors);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__SetCaptureShowingActors_NativeFunctionPtr, (void*)ptr);
			TArray<AActor> tarray3 = HiddenActors;
			if (tarray3 != null)
			{
				tarray3.MoveAssign(&ptr->HiddenActors);
			}
			TArray<AActor> tarray4 = ForceShowActors;
			if (tarray4 != null)
			{
				tarray4.MoveAssign(&ptr->ForceShowActors);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Portal_C.__SetCaptureShowingActors_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602609B RID: 155803 RVA: 0x009CC07F File Offset: 0x009CA27F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG_关闭2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DEBUG_关闭2_NativeFunctionPtr, null);
		}

		// Token: 0x0602609C RID: 155804 RVA: 0x009CC093 File Offset: 0x009CA293
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG_关闭1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DEBUG_关闭1_NativeFunctionPtr, null);
		}

		// Token: 0x0602609D RID: 155805 RVA: 0x009CC0A7 File Offset: 0x009CA2A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG_开启2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DEBUG_开启2_NativeFunctionPtr, null);
		}

		// Token: 0x0602609E RID: 155806 RVA: 0x009CC0BB File Offset: 0x009CA2BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisablePortal2Rendering()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DisablePortal2Rendering_NativeFunctionPtr, null);
		}

		// Token: 0x0602609F RID: 155807 RVA: 0x009CC0CF File Offset: 0x009CA2CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnablePortal2Rendering()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__EnablePortal2Rendering_NativeFunctionPtr, null);
		}

		// Token: 0x060260A0 RID: 155808 RVA: 0x009CC0E3 File Offset: 0x009CA2E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisablePortal1Rendering()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DisablePortal1Rendering_NativeFunctionPtr, null);
		}

		// Token: 0x060260A1 RID: 155809 RVA: 0x009CC0F7 File Offset: 0x009CA2F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnablePortal1Rendering()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__EnablePortal1Rendering_NativeFunctionPtr, null);
		}

		// Token: 0x060260A2 RID: 155810 RVA: 0x009CC10C File Offset: 0x009CA30C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPortal2Transform(FTransformDouble Transform, FTransformDouble CaptureTransform)
		{
			BP_Portal_C.__SetPortal2Transform_FunctionParams* ptr = stackalloc BP_Portal_C.__SetPortal2Transform_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_Portal_C.__SetPortal2Transform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__SetPortal2Transform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Transform = Transform;
			ptr->CaptureTransform = CaptureTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__SetPortal2Transform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060260A3 RID: 155811 RVA: 0x009CC15C File Offset: 0x009CA35C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPortal1Transform(FTransformDouble Transform, FTransformDouble CaptureTransform)
		{
			BP_Portal_C.__SetPortal1Transform_FunctionParams* ptr = stackalloc BP_Portal_C.__SetPortal1Transform_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_Portal_C.__SetPortal1Transform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__SetPortal1Transform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Transform = Transform;
			ptr->CaptureTransform = CaptureTransform;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__SetPortal1Transform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060260A4 RID: 155812 RVA: 0x009CC1AC File Offset: 0x009CA3AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPortal2Bounds(FVector Bounds)
		{
			BP_Portal_C.__SetPortal2Bounds_FunctionParams* ptr = stackalloc BP_Portal_C.__SetPortal2Bounds_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_Portal_C.__SetPortal2Bounds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__SetPortal2Bounds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Bounds = Bounds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__SetPortal2Bounds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060260A5 RID: 155813 RVA: 0x009CC1F4 File Offset: 0x009CA3F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPortal1Bounds(FVector Bounds)
		{
			BP_Portal_C.__SetPortal1Bounds_FunctionParams* ptr = stackalloc BP_Portal_C.__SetPortal1Bounds_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_Portal_C.__SetPortal1Bounds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__SetPortal1Bounds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Bounds = Bounds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__SetPortal1Bounds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060260A6 RID: 155814 RVA: 0x009CC23A File Offset: 0x009CA43A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG_开启1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__DEBUG_开启1_NativeFunctionPtr, null);
		}

		// Token: 0x060260A7 RID: 155815 RVA: 0x009CC24E File Offset: 0x009CA44E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060260A8 RID: 155816 RVA: 0x009CC262 File Offset: 0x009CA462
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Portal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060260A9 RID: 155817 RVA: 0x009CC278 File Offset: 0x009CA478
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Portal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Portal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Portal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060260AA RID: 155818 RVA: 0x009CC2C0 File Offset: 0x009CA4C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Portal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Portal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Portal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Portal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060260AB RID: 155819 RVA: 0x009CC307 File Offset: 0x009CA507
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Portal_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060260AC RID: 155820 RVA: 0x009CC31B File Offset: 0x009CA51B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Portal_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060260AD RID: 155821 RVA: 0x009CC330 File Offset: 0x009CA530
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Portal(int EntryPoint)
		{
			BP_Portal_C.__ExecuteUbergraph_BP_Portal_FunctionParams* ptr = stackalloc BP_Portal_C.__ExecuteUbergraph_BP_Portal_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Portal_C.__ExecuteUbergraph_BP_Portal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Portal_C.__ExecuteUbergraph_BP_Portal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Portal_C.__ExecuteUbergraph_BP_Portal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060260AE RID: 155822 RVA: 0x009CC377 File Offset: 0x009CA577
		protected BP_Portal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013A99 RID: 80537
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Portal/BP_Portal.BP_Portal_C";

		// Token: 0x04013A9A RID: 80538
		private static IntPtr _ClassPtr;

		// Token: 0x04013A9B RID: 80539
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013A9C RID: 80540
		internal static int __PropertyOffset_0;

		// Token: 0x04013A9D RID: 80541
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013A9E RID: 80542
		internal static int __PropertyOffset_1;

		// Token: 0x04013A9F RID: 80543
		internal static int __PropertyOffset_2;

		// Token: 0x04013AA0 RID: 80544
		internal static int __PropertyOffset_3;

		// Token: 0x04013AA1 RID: 80545
		internal static int __PropertyOffset_4;

		// Token: 0x04013AA2 RID: 80546
		internal static int __PropertyOffset_5;

		// Token: 0x04013AA3 RID: 80547
		internal static int __PropertyOffset_6;

		// Token: 0x04013AA4 RID: 80548
		internal static int __PropertyOffset_7;

		// Token: 0x04013AA5 RID: 80549
		internal static int __PropertyOffset_8;

		// Token: 0x04013AA6 RID: 80550
		internal static int __PropertyOffset_9;

		// Token: 0x04013AA7 RID: 80551
		internal static int __PropertyOffset_10;

		// Token: 0x04013AA8 RID: 80552
		internal static int __PropertyOffset_11;

		// Token: 0x04013AA9 RID: 80553
		internal static int __PropertyOffset_12;

		// Token: 0x04013AAA RID: 80554
		internal static int __PropertyOffset_13;

		// Token: 0x04013AAB RID: 80555
		internal static int __PropertyOffset_14;

		// Token: 0x04013AAC RID: 80556
		internal static int __PropertyOffset_15;

		// Token: 0x04013AAD RID: 80557
		internal static int __PropertyOffset_16;

		// Token: 0x04013AAE RID: 80558
		internal static int __PropertyOffset_17;

		// Token: 0x04013AAF RID: 80559
		internal static int __PropertyOffset_18;

		// Token: 0x04013AB0 RID: 80560
		internal static int __PropertyOffset_19;

		// Token: 0x04013AB1 RID: 80561
		internal static int __PropertyOffset_20;

		// Token: 0x04013AB2 RID: 80562
		internal static int __PropertyOffset_21;

		// Token: 0x04013AB3 RID: 80563
		internal static int __PropertyOffset_22;

		// Token: 0x04013AB4 RID: 80564
		internal static int __PropertyOffset_23;

		// Token: 0x04013AB5 RID: 80565
		internal static int __PropertyOffset_24;

		// Token: 0x04013AB6 RID: 80566
		internal static int __PropertyOffset_25;

		// Token: 0x04013AB7 RID: 80567
		internal static int __PropertyOffset_26;

		// Token: 0x04013AB8 RID: 80568
		internal static int __PropertyOffset_27;

		// Token: 0x04013AB9 RID: 80569
		internal static int __PropertyOffset_28;

		// Token: 0x04013ABA RID: 80570
		private FSoftObjectPath _EffectData_1;

		// Token: 0x04013ABB RID: 80571
		internal static int __PropertyOffset_29;

		// Token: 0x04013ABC RID: 80572
		private FSoftObjectPath _EffectData_2;

		// Token: 0x04013ABD RID: 80573
		internal static int __PropertyOffset_30;

		// Token: 0x04013ABE RID: 80574
		internal static int __PropertyOffset_31;

		// Token: 0x04013ABF RID: 80575
		internal static int __PropertyOffset_32;

		// Token: 0x04013AC0 RID: 80576
		internal static int __PropertyOffset_33;

		// Token: 0x04013AC1 RID: 80577
		internal static int __PropertyOffset_34;

		// Token: 0x04013AC2 RID: 80578
		private FSceneCaptureComponent2DParams _CaptureConfig_Mobile_VeryLow;

		// Token: 0x04013AC3 RID: 80579
		internal static int __PropertyOffset_35;

		// Token: 0x04013AC4 RID: 80580
		private FSceneCaptureComponent2DParams _CaptureConfig_Mobile_Low;

		// Token: 0x04013AC5 RID: 80581
		internal static int __PropertyOffset_36;

		// Token: 0x04013AC6 RID: 80582
		private FSceneCaptureComponent2DParams _CaptureConfig_Mobile_Mid;

		// Token: 0x04013AC7 RID: 80583
		internal static int __PropertyOffset_37;

		// Token: 0x04013AC8 RID: 80584
		private FSceneCaptureComponent2DParams _CaptureConfig_Mobile_High;

		// Token: 0x04013AC9 RID: 80585
		internal static int __PropertyOffset_38;

		// Token: 0x04013ACA RID: 80586
		private FSceneCaptureComponent2DParams _CaptureConfig_Pc_VeryLow;

		// Token: 0x04013ACB RID: 80587
		internal static int __PropertyOffset_39;

		// Token: 0x04013ACC RID: 80588
		private FSceneCaptureComponent2DParams _CaptureConfig_Pc_Low;

		// Token: 0x04013ACD RID: 80589
		internal static int __PropertyOffset_40;

		// Token: 0x04013ACE RID: 80590
		private FSceneCaptureComponent2DParams _CaptureConfig_Pc_Mid;

		// Token: 0x04013ACF RID: 80591
		internal static int __PropertyOffset_41;

		// Token: 0x04013AD0 RID: 80592
		private FSceneCaptureComponent2DParams _CaptureConfig_Pc_High;

		// Token: 0x04013AD1 RID: 80593
		internal static int __PropertyOffset_42;

		// Token: 0x04013AD2 RID: 80594
		internal static int __PropertyOffset_43;

		// Token: 0x04013AD3 RID: 80595
		internal static int __PropertyOffset_44;

		// Token: 0x04013AD4 RID: 80596
		internal static int __PropertyOffset_45;

		// Token: 0x04013AD5 RID: 80597
		internal static int __PropertyOffset_46;

		// Token: 0x04013AD6 RID: 80598
		internal static int __PropertyOffset_47;

		// Token: 0x04013AD7 RID: 80599
		internal static int __PropertyOffset_48;

		// Token: 0x04013AD8 RID: 80600
		internal static int __PropertyOffset_49;

		// Token: 0x04013AD9 RID: 80601
		internal static int __PropertyOffset_50;

		// Token: 0x04013ADA RID: 80602
		internal static int __PropertyOffset_51;

		// Token: 0x04013ADB RID: 80603
		internal static int __PropertyOffset_52;

		// Token: 0x04013ADC RID: 80604
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, bool> _Capture1InitShowFlags;

		// Token: 0x04013ADD RID: 80605
		internal static int __PropertyOffset_53;

		// Token: 0x04013ADE RID: 80606
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, bool> _Capture2InitShowFlags;

		// Token: 0x04013ADF RID: 80607
		internal static int __PropertyOffset_54;

		// Token: 0x04013AE0 RID: 80608
		private static IntPtr __DrawDebugPortalBounds_NativeFunctionPtr;

		// Token: 0x04013AE1 RID: 80609
		private static IntPtr __PrintDebugCaptureParams_NativeFunctionPtr;

		// Token: 0x04013AE2 RID: 80610
		private static IntPtr __CheckCapturePerformanceLevel_NativeFunctionPtr;

		// Token: 0x04013AE3 RID: 80611
		private static IntPtr __ApplyCapturePerformace_NativeFunctionPtr;

		// Token: 0x04013AE4 RID: 80612
		private static IntPtr __GetAngleBetweenVector_NativeFunctionPtr;

		// Token: 0x04013AE5 RID: 80613
		private static IntPtr __DrawDebugFrustum_NativeFunctionPtr;

		// Token: 0x04013AE6 RID: 80614
		private static IntPtr __GetMappingTransformToOtherPortal_NativeFunctionPtr;

		// Token: 0x04013AE7 RID: 80615
		private static IntPtr __UpdatePortalsCameraPosition_NativeFunctionPtr;

		// Token: 0x04013AE8 RID: 80616
		private static IntPtr __UpdatePortalAnimation_NativeFunctionPtr;

		// Token: 0x04013AE9 RID: 80617
		private static IntPtr __SetCaptureShowFlags_NativeFunctionPtr;

		// Token: 0x04013AEA RID: 80618
		private static IntPtr __GetCaptureShowFlags_NativeFunctionPtr;

		// Token: 0x04013AEB RID: 80619
		private static IntPtr __SetCaptureMaxViewDistance_NativeFunctionPtr;

		// Token: 0x04013AEC RID: 80620
		private static IntPtr __SetCaptureShowingActors_NativeFunctionPtr;

		// Token: 0x04013AED RID: 80621
		private static IntPtr __DEBUG_关闭2_NativeFunctionPtr;

		// Token: 0x04013AEE RID: 80622
		private static IntPtr __DEBUG_关闭1_NativeFunctionPtr;

		// Token: 0x04013AEF RID: 80623
		private static IntPtr __DEBUG_开启2_NativeFunctionPtr;

		// Token: 0x04013AF0 RID: 80624
		private static IntPtr __DisablePortal2Rendering_NativeFunctionPtr;

		// Token: 0x04013AF1 RID: 80625
		private static IntPtr __EnablePortal2Rendering_NativeFunctionPtr;

		// Token: 0x04013AF2 RID: 80626
		private static IntPtr __DisablePortal1Rendering_NativeFunctionPtr;

		// Token: 0x04013AF3 RID: 80627
		private static IntPtr __EnablePortal1Rendering_NativeFunctionPtr;

		// Token: 0x04013AF4 RID: 80628
		private static IntPtr __SetPortal2Transform_NativeFunctionPtr;

		// Token: 0x04013AF5 RID: 80629
		private static IntPtr __SetPortal1Transform_NativeFunctionPtr;

		// Token: 0x04013AF6 RID: 80630
		private static IntPtr __SetPortal2Bounds_NativeFunctionPtr;

		// Token: 0x04013AF7 RID: 80631
		private static IntPtr __SetPortal1Bounds_NativeFunctionPtr;

		// Token: 0x04013AF8 RID: 80632
		private static IntPtr __DEBUG_开启1_NativeFunctionPtr;

		// Token: 0x04013AF9 RID: 80633
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013AFA RID: 80634
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013AFB RID: 80635
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013AFC RID: 80636
		private static IntPtr __ExecuteUbergraph_BP_Portal_NativeFunctionPtr;

		// Token: 0x02009FE1 RID: 40929
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 336)]
		protected ref struct __DrawDebugPortalBounds_FunctionParams
		{
			// Token: 0x04032B99 RID: 207769
			[FieldOffset(0)]
			public bool IsPortal1;
		}

		// Token: 0x02009FE2 RID: 40930
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 800)]
		protected ref struct __PrintDebugCaptureParams_FunctionParams
		{
			// Token: 0x04032B9A RID: 207770
			[FieldOffset(0)]
			public bool IsCapture1;

			// Token: 0x04032B9B RID: 207771
			[FieldOffset(4)]
			public byte CaptureParam;
		}

		// Token: 0x02009FE3 RID: 40931
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __CheckCapturePerformanceLevel_FunctionParams
		{
			// Token: 0x04032B9C RID: 207772
			[FieldOffset(0)]
			public bool isPortalA;

			// Token: 0x04032B9D RID: 207773
			[FieldOffset(16)]
			public FTransformDouble targetTrans;
		}

		// Token: 0x02009FE4 RID: 40932
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ApplyCapturePerformace_FunctionParams
		{
			// Token: 0x04032B9E RID: 207774
			[FieldOffset(0)]
			public bool IsPortalA;

			// Token: 0x04032B9F RID: 207775
			[FieldOffset(4)]
			public int ConfigLevel;

			// Token: 0x04032BA0 RID: 207776
			[FieldOffset(8)]
			public float CaptureMaxViewDistance;
		}

		// Token: 0x02009FE5 RID: 40933
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetAngleBetweenVector_FunctionParams
		{
			// Token: 0x04032BA1 RID: 207777
			[FieldOffset(0)]
			public FVector Vector1;

			// Token: 0x04032BA2 RID: 207778
			[FieldOffset(12)]
			public FVector Vector2;

			// Token: 0x04032BA3 RID: 207779
			[FieldOffset(24)]
			public float Angle;
		}

		// Token: 0x02009FE6 RID: 40934
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __DrawDebugFrustum_FunctionParams
		{
			// Token: 0x04032BA4 RID: 207780
			[FieldOffset(0)]
			public FTransformDouble Transform;

			// Token: 0x04032BA5 RID: 207781
			[FieldOffset(64)]
			public float FovX;

			// Token: 0x04032BA6 RID: 207782
			[FieldOffset(68)]
			public float NearClipPlane;

			// Token: 0x04032BA7 RID: 207783
			[FieldOffset(72)]
			public float AspectRatio;
		}

		// Token: 0x02009FE7 RID: 40935
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 592)]
		protected ref struct __GetMappingTransformToOtherPortal_FunctionParams
		{
			// Token: 0x04032BA8 RID: 207784
			[FieldOffset(0)]
			public FTransformDouble SourceTransform;

			// Token: 0x04032BA9 RID: 207785
			[FieldOffset(64)]
			public bool bA2B;

			// Token: 0x04032BAA RID: 207786
			[FieldOffset(80)]
			public FTransformDouble TargetTransform;
		}

		// Token: 0x02009FE8 RID: 40936
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __UpdatePortalAnimation_FunctionParams
		{
			// Token: 0x04032BAB RID: 207787
			[FieldOffset(0)]
			public float ShowLen;

			// Token: 0x04032BAC RID: 207788
			[FieldOffset(4)]
			public float FadeLen;

			// Token: 0x04032BAD RID: 207789
			[FieldOffset(8)]
			public bool IsShown;

			// Token: 0x04032BAE RID: 207790
			[FieldOffset(16)]
			public IntPtr ShowCurve;

			// Token: 0x04032BAF RID: 207791
			[FieldOffset(24)]
			public IntPtr FadeCurve;

			// Token: 0x04032BB0 RID: 207792
			[FieldOffset(32)]
			public float Counter;

			// Token: 0x04032BB1 RID: 207793
			[FieldOffset(40)]
			public IntPtr SM;

			// Token: 0x04032BB2 RID: 207794
			[FieldOffset(48)]
			public IntPtr DMI;

			// Token: 0x04032BB3 RID: 207795
			[FieldOffset(56)]
			public float OutputCounter;

			// Token: 0x04032BB4 RID: 207796
			[FieldOffset(60)]
			public float Factor;
		}

		// Token: 0x02009FE9 RID: 40937
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 528)]
		protected ref struct __SetCaptureShowFlags_FunctionParams
		{
			// Token: 0x04032BB5 RID: 207797
			[FieldOffset(0)]
			public bool IsCapture1;

			// Token: 0x04032BB6 RID: 207798
			[FieldOffset(8)]
			public byte ShowFlags;
		}

		// Token: 0x02009FEA RID: 40938
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __GetCaptureShowFlags_FunctionParams
		{
			// Token: 0x04032BB7 RID: 207799
			[FieldOffset(0)]
			public bool IsCapture1;

			// Token: 0x04032BB8 RID: 207800
			[FieldOffset(8)]
			public byte ShowFlags;
		}

		// Token: 0x02009FEB RID: 40939
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetCaptureMaxViewDistance_FunctionParams
		{
			// Token: 0x04032BB9 RID: 207801
			[FieldOffset(0)]
			public bool IsCapture1;

			// Token: 0x04032BBA RID: 207802
			[FieldOffset(4)]
			public float MaxViewDistance;
		}

		// Token: 0x02009FEC RID: 40940
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetCaptureShowingActors_FunctionParams
		{
			// Token: 0x04032BBB RID: 207803
			[FieldOffset(0)]
			public bool IsCapture1;

			// Token: 0x04032BBC RID: 207804
			[FieldOffset(8)]
			public byte HiddenActors;

			// Token: 0x04032BBD RID: 207805
			[FieldOffset(24)]
			public byte ForceShowActors;
		}

		// Token: 0x02009FED RID: 40941
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __SetPortal2Transform_FunctionParams
		{
			// Token: 0x04032BBE RID: 207806
			[FieldOffset(0)]
			public FTransformDouble Transform;

			// Token: 0x04032BBF RID: 207807
			[FieldOffset(64)]
			public FTransformDouble CaptureTransform;
		}

		// Token: 0x02009FEE RID: 40942
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __SetPortal1Transform_FunctionParams
		{
			// Token: 0x04032BC0 RID: 207808
			[FieldOffset(0)]
			public FTransformDouble Transform;

			// Token: 0x04032BC1 RID: 207809
			[FieldOffset(64)]
			public FTransformDouble CaptureTransform;
		}

		// Token: 0x02009FEF RID: 40943
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __SetPortal2Bounds_FunctionParams
		{
			// Token: 0x04032BC2 RID: 207810
			[FieldOffset(0)]
			public FVector Bounds;
		}

		// Token: 0x02009FF0 RID: 40944
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __SetPortal1Bounds_FunctionParams
		{
			// Token: 0x04032BC3 RID: 207811
			[FieldOffset(0)]
			public FVector Bounds;
		}

		// Token: 0x02009FF1 RID: 40945
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BC4 RID: 207812
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FF2 RID: 40946
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_Portal_FunctionParams
		{
			// Token: 0x04032BC5 RID: 207813
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
