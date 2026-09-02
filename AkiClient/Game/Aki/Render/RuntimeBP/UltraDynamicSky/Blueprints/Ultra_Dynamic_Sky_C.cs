using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints
{
	// Token: 0x02003A13 RID: 14867
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Sky.Ultra_Dynamic_Sky_C")]
	[UnrealStructLayout(2456, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2453)]
	public class Ultra_Dynamic_Sky_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E64C RID: 124492 RVA: 0x008F4B1A File Offset: 0x008F2D1A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Ultra_Dynamic_Sky_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Sky.Ultra_Dynamic_Sky_C");
			}
			return Ultra_Dynamic_Sky_C._ClassPtr;
		}

		// Token: 0x0601E64D RID: 124493 RVA: 0x008F4B40 File Offset: 0x008F2D40
		public Ultra_Dynamic_Sky_C() : this(BuiltinUtils.AllocNativeUObject(Ultra_Dynamic_Sky_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E64E RID: 124494 RVA: 0x008F4B68 File Offset: 0x008F2D68
		[NullableContext(1)]
		public Ultra_Dynamic_Sky_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Ultra_Dynamic_Sky_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170029FA RID: 10746
		// (get) Token: 0x0601E64F RID: 124495 RVA: 0x008F4B9C File Offset: 0x008F2D9C
		// (set) Token: 0x0601E650 RID: 124496 RVA: 0x008F4BD5 File Offset: 0x008F2DD5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170029FB RID: 10747
		// (get) Token: 0x0601E651 RID: 124497 RVA: 0x008F4BF6 File Offset: 0x008F2DF6
		// (set) Token: 0x0601E652 RID: 124498 RVA: 0x008F4C0A File Offset: 0x008F2E0A
		public unsafe UNiagaraComponent Inside_Cloud_Fog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170029FC RID: 10748
		// (get) Token: 0x0601E653 RID: 124499 RVA: 0x008F4C1F File Offset: 0x008F2E1F
		// (set) Token: 0x0601E654 RID: 124500 RVA: 0x008F4C33 File Offset: 0x008F2E33
		public unsafe UVolumetricCloudComponent VolumetricAurora
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVolumetricCloudComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170029FD RID: 10749
		// (get) Token: 0x0601E655 RID: 124501 RVA: 0x008F4C48 File Offset: 0x008F2E48
		// (set) Token: 0x0601E656 RID: 124502 RVA: 0x008F4C5C File Offset: 0x008F2E5C
		public unsafe UStaticMeshComponent StaticCloudsSphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170029FE RID: 10750
		// (get) Token: 0x0601E657 RID: 124503 RVA: 0x008F4C71 File Offset: 0x008F2E71
		// (set) Token: 0x0601E658 RID: 124504 RVA: 0x008F4C85 File Offset: 0x008F2E85
		public unsafe UBillboardComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170029FF RID: 10751
		// (get) Token: 0x0601E659 RID: 124505 RVA: 0x008F4C9A File Offset: 0x008F2E9A
		// (set) Token: 0x0601E65A RID: 124506 RVA: 0x008F4CAE File Offset: 0x008F2EAE
		public unsafe UVolumetricCloudComponent VolumetricCloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVolumetricCloudComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002A00 RID: 10752
		// (get) Token: 0x0601E65B RID: 124507 RVA: 0x008F4CC3 File Offset: 0x008F2EC3
		// (set) Token: 0x0601E65C RID: 124508 RVA: 0x008F4CD7 File Offset: 0x008F2ED7
		public unsafe USkyLightComponent CubeMap_Sky_Light
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkyLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002A01 RID: 10753
		// (get) Token: 0x0601E65D RID: 124509 RVA: 0x008F4CEC File Offset: 0x008F2EEC
		// (set) Token: 0x0601E65E RID: 124510 RVA: 0x008F4D00 File Offset: 0x008F2F00
		public unsafe USkyLightComponent Capture_Based_Sky_Light
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkyLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002A02 RID: 10754
		// (get) Token: 0x0601E65F RID: 124511 RVA: 0x008F4D15 File Offset: 0x008F2F15
		// (set) Token: 0x0601E660 RID: 124512 RVA: 0x008F4D29 File Offset: 0x008F2F29
		public unsafe UPostProcessComponent Exposure
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002A03 RID: 10755
		// (get) Token: 0x0601E661 RID: 124513 RVA: 0x008F4D3E File Offset: 0x008F2F3E
		// (set) Token: 0x0601E662 RID: 124514 RVA: 0x008F4D52 File Offset: 0x008F2F52
		public unsafe UExponentialHeightFogComponent HeightFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UExponentialHeightFogComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002A04 RID: 10756
		// (get) Token: 0x0601E663 RID: 124515 RVA: 0x008F4D67 File Offset: 0x008F2F67
		// (set) Token: 0x0601E664 RID: 124516 RVA: 0x008F4D7B File Offset: 0x008F2F7B
		public unsafe UDirectionalLightComponent Moon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002A05 RID: 10757
		// (get) Token: 0x0601E665 RID: 124517 RVA: 0x008F4D90 File Offset: 0x008F2F90
		// (set) Token: 0x0601E666 RID: 124518 RVA: 0x008F4DA4 File Offset: 0x008F2FA4
		public unsafe UDirectionalLightComponent Sun
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002A06 RID: 10758
		// (get) Token: 0x0601E667 RID: 124519 RVA: 0x008F4DB9 File Offset: 0x008F2FB9
		// (set) Token: 0x0601E668 RID: 124520 RVA: 0x008F4DCD File Offset: 0x008F2FCD
		public unsafe UArrowComponent Moon_Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002A07 RID: 10759
		// (get) Token: 0x0601E669 RID: 124521 RVA: 0x008F4DE2 File Offset: 0x008F2FE2
		// (set) Token: 0x0601E66A RID: 124522 RVA: 0x008F4DF6 File Offset: 0x008F2FF6
		public unsafe UArrowComponent Sun_Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002A08 RID: 10760
		// (get) Token: 0x0601E66B RID: 124523 RVA: 0x008F4E0B File Offset: 0x008F300B
		// (set) Token: 0x0601E66C RID: 124524 RVA: 0x008F4E1F File Offset: 0x008F301F
		public unsafe UStaticMeshComponent Ultra_Dynamic_Sky_Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17002A09 RID: 10761
		// (get) Token: 0x0601E66D RID: 124525 RVA: 0x008F4E34 File Offset: 0x008F3034
		// (set) Token: 0x0601E66E RID: 124526 RVA: 0x008F4E48 File Offset: 0x008F3048
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_FeatureToggle> Sun_Light
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_15);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002A0A RID: 10762
		// (get) Token: 0x0601E66F RID: 124527 RVA: 0x008F4E5D File Offset: 0x008F305D
		// (set) Token: 0x0601E670 RID: 124528 RVA: 0x008F4E71 File Offset: 0x008F3071
		public unsafe ADirectionalLight Custom_Sun_Light_Actor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADirectionalLight>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17002A0B RID: 10763
		// (get) Token: 0x0601E671 RID: 124529 RVA: 0x008F4E86 File Offset: 0x008F3086
		// (set) Token: 0x0601E672 RID: 124530 RVA: 0x008F4E9A File Offset: 0x008F309A
		[Nullable(0)]
		public unsafe TEnumAsByte<EComponentMobility> Sun_Mobility
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_17);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002A0C RID: 10764
		// (get) Token: 0x0601E673 RID: 124531 RVA: 0x008F4EAF File Offset: 0x008F30AF
		// (set) Token: 0x0601E674 RID: 124532 RVA: 0x008F4EC3 File Offset: 0x008F30C3
		public unsafe UMaterialInstanceDynamic Sky_MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002A0D RID: 10765
		// (get) Token: 0x0601E675 RID: 124533 RVA: 0x008F4ED8 File Offset: 0x008F30D8
		// (set) Token: 0x0601E676 RID: 124534 RVA: 0x008F4EE8 File Offset: 0x008F30E8
		public unsafe bool Refresh_Settings
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A0E RID: 10766
		// (get) Token: 0x0601E677 RID: 124535 RVA: 0x008F4EF9 File Offset: 0x008F30F9
		// (set) Token: 0x0601E678 RID: 124536 RVA: 0x008F4F09 File Offset: 0x008F3109
		public unsafe float Cloud_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002A0F RID: 10767
		// (get) Token: 0x0601E679 RID: 124537 RVA: 0x008F4F1A File Offset: 0x008F311A
		// (set) Token: 0x0601E67A RID: 124538 RVA: 0x008F4F2A File Offset: 0x008F312A
		public unsafe float Cloud_Wisps_Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002A10 RID: 10768
		// (get) Token: 0x0601E67B RID: 124539 RVA: 0x008F4F3B File Offset: 0x008F313B
		// (set) Token: 0x0601E67C RID: 124540 RVA: 0x008F4F4B File Offset: 0x008F314B
		public unsafe float Time_of_Day
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002A11 RID: 10769
		// (get) Token: 0x0601E67D RID: 124541 RVA: 0x008F4F5C File Offset: 0x008F315C
		// (set) Token: 0x0601E67E RID: 124542 RVA: 0x008F4F70 File Offset: 0x008F3170
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_SkyMode> Sky_Mode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_23);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002A12 RID: 10770
		// (get) Token: 0x0601E67F RID: 124543 RVA: 0x008F4F85 File Offset: 0x008F3185
		// (set) Token: 0x0601E680 RID: 124544 RVA: 0x008F4F95 File Offset: 0x008F3195
		public unsafe float Cloud_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002A13 RID: 10771
		// (get) Token: 0x0601E681 RID: 124545 RVA: 0x008F4FA6 File Offset: 0x008F31A6
		// (set) Token: 0x0601E682 RID: 124546 RVA: 0x008F4FB6 File Offset: 0x008F31B6
		public unsafe float Overall_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002A14 RID: 10772
		// (get) Token: 0x0601E683 RID: 124547 RVA: 0x008F4FC7 File Offset: 0x008F31C7
		// (set) Token: 0x0601E684 RID: 124548 RVA: 0x008F4FD7 File Offset: 0x008F31D7
		public unsafe float Saturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002A15 RID: 10773
		// (get) Token: 0x0601E685 RID: 124549 RVA: 0x008F4FE8 File Offset: 0x008F31E8
		// (set) Token: 0x0601E686 RID: 124550 RVA: 0x008F4FF8 File Offset: 0x008F31F8
		public unsafe float Cloud_Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002A16 RID: 10774
		// (get) Token: 0x0601E687 RID: 124551 RVA: 0x008F5009 File Offset: 0x008F3209
		// (set) Token: 0x0601E688 RID: 124552 RVA: 0x008F5019 File Offset: 0x008F3219
		public unsafe float Cloud_Phase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002A17 RID: 10775
		// (get) Token: 0x0601E689 RID: 124553 RVA: 0x008F502A File Offset: 0x008F322A
		// (set) Token: 0x0601E68A RID: 124554 RVA: 0x008F503A File Offset: 0x008F323A
		public unsafe bool Moon_Casts_Shadows
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A18 RID: 10776
		// (get) Token: 0x0601E68B RID: 124555 RVA: 0x008F504B File Offset: 0x008F324B
		// (set) Token: 0x0601E68C RID: 124556 RVA: 0x008F505B File Offset: 0x008F325B
		public unsafe float Moon_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002A19 RID: 10777
		// (get) Token: 0x0601E68D RID: 124557 RVA: 0x008F506C File Offset: 0x008F326C
		// (set) Token: 0x0601E68E RID: 124558 RVA: 0x008F507C File Offset: 0x008F327C
		public unsafe float Moon_Inclination
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002A1A RID: 10778
		// (get) Token: 0x0601E68F RID: 124559 RVA: 0x008F508D File Offset: 0x008F328D
		// (set) Token: 0x0601E690 RID: 124560 RVA: 0x008F509D File Offset: 0x008F329D
		public unsafe float Moon_Phase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17002A1B RID: 10779
		// (get) Token: 0x0601E691 RID: 124561 RVA: 0x008F50AE File Offset: 0x008F32AE
		// (set) Token: 0x0601E692 RID: 124562 RVA: 0x008F50BE File Offset: 0x008F32BE
		public unsafe bool Automatically_Set_Advanced_Legacy_Settings_using_Time_of_Day
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A1C RID: 10780
		// (get) Token: 0x0601E693 RID: 124563 RVA: 0x008F50CF File Offset: 0x008F32CF
		// (set) Token: 0x0601E694 RID: 124564 RVA: 0x008F50DF File Offset: 0x008F32DF
		public unsafe float Stars_Visibility
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17002A1D RID: 10781
		// (get) Token: 0x0601E695 RID: 124565 RVA: 0x008F50F0 File Offset: 0x008F32F0
		// (set) Token: 0x0601E696 RID: 124566 RVA: 0x008F5100 File Offset: 0x008F3300
		public unsafe bool Change_Moon_Phase_Once_a_Day
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A1E RID: 10782
		// (get) Token: 0x0601E697 RID: 124567 RVA: 0x008F5111 File Offset: 0x008F3311
		// (set) Token: 0x0601E698 RID: 124568 RVA: 0x008F5121 File Offset: 0x008F3321
		public unsafe float Moon_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17002A1F RID: 10783
		// (get) Token: 0x0601E699 RID: 124569 RVA: 0x008F5132 File Offset: 0x008F3332
		// (set) Token: 0x0601E69A RID: 124570 RVA: 0x008F5142 File Offset: 0x008F3342
		public unsafe float Moon_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17002A20 RID: 10784
		// (get) Token: 0x0601E69B RID: 124571 RVA: 0x008F5153 File Offset: 0x008F3353
		// (set) Token: 0x0601E69C RID: 124572 RVA: 0x008F5163 File Offset: 0x008F3363
		public unsafe float Sun_Angle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17002A21 RID: 10785
		// (get) Token: 0x0601E69D RID: 124573 RVA: 0x008F5174 File Offset: 0x008F3374
		// (set) Token: 0x0601E69E RID: 124574 RVA: 0x008F5188 File Offset: 0x008F3388
		public unsafe FLinearColor Horizon_Base_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17002A22 RID: 10786
		// (get) Token: 0x0601E69F RID: 124575 RVA: 0x008F519D File Offset: 0x008F339D
		// (set) Token: 0x0601E6A0 RID: 124576 RVA: 0x008F51B1 File Offset: 0x008F33B1
		public unsafe FLinearColor Zenith_Base_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17002A23 RID: 10787
		// (get) Token: 0x0601E6A1 RID: 124577 RVA: 0x008F51C6 File Offset: 0x008F33C6
		// (set) Token: 0x0601E6A2 RID: 124578 RVA: 0x008F51DA File Offset: 0x008F33DA
		public unsafe FLinearColor Cloud_Light_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17002A24 RID: 10788
		// (get) Token: 0x0601E6A3 RID: 124579 RVA: 0x008F51EF File Offset: 0x008F33EF
		// (set) Token: 0x0601E6A4 RID: 124580 RVA: 0x008F5203 File Offset: 0x008F3403
		public unsafe FLinearColor Cloud_Dark_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17002A25 RID: 10789
		// (get) Token: 0x0601E6A5 RID: 124581 RVA: 0x008F5218 File Offset: 0x008F3418
		// (set) Token: 0x0601E6A6 RID: 124582 RVA: 0x008F522C File Offset: 0x008F342C
		public unsafe FLinearColor Sun_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17002A26 RID: 10790
		// (get) Token: 0x0601E6A7 RID: 124583 RVA: 0x008F5241 File Offset: 0x008F3441
		// (set) Token: 0x0601E6A8 RID: 124584 RVA: 0x008F5251 File Offset: 0x008F3451
		public unsafe float Cloud_Shine_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17002A27 RID: 10791
		// (get) Token: 0x0601E6A9 RID: 124585 RVA: 0x008F5262 File Offset: 0x008F3462
		// (set) Token: 0x0601E6AA RID: 124586 RVA: 0x008F5276 File Offset: 0x008F3476
		public unsafe FLinearColor Sun_Light_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17002A28 RID: 10792
		// (get) Token: 0x0601E6AB RID: 124587 RVA: 0x008F528B File Offset: 0x008F348B
		// (set) Token: 0x0601E6AC RID: 124588 RVA: 0x008F529B File Offset: 0x008F349B
		public unsafe bool Animate_Time_of_Day
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A29 RID: 10793
		// (get) Token: 0x0601E6AD RID: 124589 RVA: 0x008F52AC File Offset: 0x008F34AC
		// (set) Token: 0x0601E6AE RID: 124590 RVA: 0x008F52BC File Offset: 0x008F34BC
		public unsafe float Day_Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17002A2A RID: 10794
		// (get) Token: 0x0601E6AF RID: 124591 RVA: 0x008F52CD File Offset: 0x008F34CD
		// (set) Token: 0x0601E6B0 RID: 124592 RVA: 0x008F52DD File Offset: 0x008F34DD
		public unsafe float Night_Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17002A2B RID: 10795
		// (get) Token: 0x0601E6B1 RID: 124593 RVA: 0x008F52EE File Offset: 0x008F34EE
		// (set) Token: 0x0601E6B2 RID: 124594 RVA: 0x008F52FE File Offset: 0x008F34FE
		public unsafe float Cloud_Density_target
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17002A2C RID: 10796
		// (get) Token: 0x0601E6B3 RID: 124595 RVA: 0x008F530F File Offset: 0x008F350F
		// (set) Token: 0x0601E6B4 RID: 124596 RVA: 0x008F531F File Offset: 0x008F351F
		public unsafe float Contrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17002A2D RID: 10797
		// (get) Token: 0x0601E6B5 RID: 124597 RVA: 0x008F5330 File Offset: 0x008F3530
		// (set) Token: 0x0601E6B6 RID: 124598 RVA: 0x008F5340 File Offset: 0x008F3540
		public unsafe bool Sun_Casts_Shadows
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_51) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_51) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A2E RID: 10798
		// (get) Token: 0x0601E6B7 RID: 124599 RVA: 0x008F5351 File Offset: 0x008F3551
		// (set) Token: 0x0601E6B8 RID: 124600 RVA: 0x008F5361 File Offset: 0x008F3561
		public unsafe float Sun_Disk_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17002A2F RID: 10799
		// (get) Token: 0x0601E6B9 RID: 124601 RVA: 0x008F5372 File Offset: 0x008F3572
		// (set) Token: 0x0601E6BA RID: 124602 RVA: 0x008F5382 File Offset: 0x008F3582
		public unsafe float Sun_Shader_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17002A30 RID: 10800
		// (get) Token: 0x0601E6BB RID: 124603 RVA: 0x008F5393 File Offset: 0x008F3593
		// (set) Token: 0x0601E6BC RID: 124604 RVA: 0x008F53A7 File Offset: 0x008F35A7
		public unsafe FLinearColor Moon_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17002A31 RID: 10801
		// (get) Token: 0x0601E6BD RID: 124605 RVA: 0x008F53BC File Offset: 0x008F35BC
		// (set) Token: 0x0601E6BE RID: 124606 RVA: 0x008F53CC File Offset: 0x008F35CC
		public unsafe float Soften_Cloud_Layer_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17002A32 RID: 10802
		// (get) Token: 0x0601E6BF RID: 124607 RVA: 0x008F53DD File Offset: 0x008F35DD
		// (set) Token: 0x0601E6C0 RID: 124608 RVA: 0x008F53ED File Offset: 0x008F35ED
		public unsafe float Soften_Cloud_Layer_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17002A33 RID: 10803
		// (get) Token: 0x0601E6C1 RID: 124609 RVA: 0x008F53FE File Offset: 0x008F35FE
		// (set) Token: 0x0601E6C2 RID: 124610 RVA: 0x008F540E File Offset: 0x008F360E
		public unsafe float Sharpen_Outer_Edge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17002A34 RID: 10804
		// (get) Token: 0x0601E6C3 RID: 124611 RVA: 0x008F541F File Offset: 0x008F361F
		// (set) Token: 0x0601E6C4 RID: 124612 RVA: 0x008F542F File Offset: 0x008F362F
		public unsafe float Sun_Highlight_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17002A35 RID: 10805
		// (get) Token: 0x0601E6C5 RID: 124613 RVA: 0x008F5440 File Offset: 0x008F3640
		// (set) Token: 0x0601E6C6 RID: 124614 RVA: 0x008F5450 File Offset: 0x008F3650
		public unsafe float Stars_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x17002A36 RID: 10806
		// (get) Token: 0x0601E6C7 RID: 124615 RVA: 0x008F5461 File Offset: 0x008F3661
		// (set) Token: 0x0601E6C8 RID: 124616 RVA: 0x008F5475 File Offset: 0x008F3675
		public unsafe FLinearColor Stars_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17002A37 RID: 10807
		// (get) Token: 0x0601E6C9 RID: 124617 RVA: 0x008F548A File Offset: 0x008F368A
		// (set) Token: 0x0601E6CA RID: 124618 RVA: 0x008F549A File Offset: 0x008F369A
		public unsafe float Moon_Orbit_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x17002A38 RID: 10808
		// (get) Token: 0x0601E6CB RID: 124619 RVA: 0x008F54AB File Offset: 0x008F36AB
		// (set) Token: 0x0601E6CC RID: 124620 RVA: 0x008F54BB File Offset: 0x008F36BB
		public unsafe bool Automatically_Set_Sun_Light_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_62) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_62) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A39 RID: 10809
		// (get) Token: 0x0601E6CD RID: 124621 RVA: 0x008F54CC File Offset: 0x008F36CC
		// (set) Token: 0x0601E6CE RID: 124622 RVA: 0x008F54E0 File Offset: 0x008F36E0
		public unsafe FRotator Sun_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x17002A3A RID: 10810
		// (get) Token: 0x0601E6CF RID: 124623 RVA: 0x008F54F5 File Offset: 0x008F36F5
		// (set) Token: 0x0601E6D0 RID: 124624 RVA: 0x008F5505 File Offset: 0x008F3705
		public unsafe float Sun_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x17002A3B RID: 10811
		// (get) Token: 0x0601E6D1 RID: 124625 RVA: 0x008F5516 File Offset: 0x008F3716
		// (set) Token: 0x0601E6D2 RID: 124626 RVA: 0x008F552A File Offset: 0x008F372A
		public unsafe UMaterialInstanceDynamic Sun_Cloud_Shadows_MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17002A3C RID: 10812
		// (get) Token: 0x0601E6D3 RID: 124627 RVA: 0x008F553F File Offset: 0x008F373F
		// (set) Token: 0x0601E6D4 RID: 124628 RVA: 0x008F554F File Offset: 0x008F374F
		public unsafe bool Use_Cloud_Shadows
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_66) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_66) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A3D RID: 10813
		// (get) Token: 0x0601E6D5 RID: 124629 RVA: 0x008F5560 File Offset: 0x008F3760
		// (set) Token: 0x0601E6D6 RID: 124630 RVA: 0x008F5570 File Offset: 0x008F3770
		public unsafe float Cloud_Shadows_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17002A3E RID: 10814
		// (get) Token: 0x0601E6D7 RID: 124631 RVA: 0x008F5581 File Offset: 0x008F3781
		// (set) Token: 0x0601E6D8 RID: 124632 RVA: 0x008F5591 File Offset: 0x008F3791
		public unsafe float Cloud_Shadows_Intensity_When_Sunny
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17002A3F RID: 10815
		// (get) Token: 0x0601E6D9 RID: 124633 RVA: 0x008F55A2 File Offset: 0x008F37A2
		// (set) Token: 0x0601E6DA RID: 124634 RVA: 0x008F55B6 File Offset: 0x008F37B6
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_FeatureToggle> Moon_Light
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_69);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17002A40 RID: 10816
		// (get) Token: 0x0601E6DB RID: 124635 RVA: 0x008F55CB File Offset: 0x008F37CB
		// (set) Token: 0x0601E6DC RID: 124636 RVA: 0x008F55DF File Offset: 0x008F37DF
		public unsafe ADirectionalLight Custom_Moon_Light_Actor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADirectionalLight>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_70);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_70, value);
			}
		}

		// Token: 0x17002A41 RID: 10817
		// (get) Token: 0x0601E6DD RID: 124637 RVA: 0x008F55F4 File Offset: 0x008F37F4
		// (set) Token: 0x0601E6DE RID: 124638 RVA: 0x008F5604 File Offset: 0x008F3804
		public unsafe bool Manually_Select_Sun_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_71) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_71) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A42 RID: 10818
		// (get) Token: 0x0601E6DF RID: 124639 RVA: 0x008F5615 File Offset: 0x008F3815
		// (set) Token: 0x0601E6E0 RID: 124640 RVA: 0x008F5625 File Offset: 0x008F3825
		public unsafe bool Automatically_Set_Moon_Light_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_72) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_72) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A43 RID: 10819
		// (get) Token: 0x0601E6E1 RID: 124641 RVA: 0x008F5636 File Offset: 0x008F3836
		// (set) Token: 0x0601E6E2 RID: 124642 RVA: 0x008F5646 File Offset: 0x008F3846
		public unsafe float Moonlight_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x17002A44 RID: 10820
		// (get) Token: 0x0601E6E3 RID: 124643 RVA: 0x008F5657 File Offset: 0x008F3857
		// (set) Token: 0x0601E6E4 RID: 124644 RVA: 0x008F5667 File Offset: 0x008F3867
		public unsafe float Stars_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x17002A45 RID: 10821
		// (get) Token: 0x0601E6E5 RID: 124645 RVA: 0x008F5678 File Offset: 0x008F3878
		// (set) Token: 0x0601E6E6 RID: 124646 RVA: 0x008F5688 File Offset: 0x008F3888
		public unsafe float Sun_Inclination
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17002A46 RID: 10822
		// (get) Token: 0x0601E6E7 RID: 124647 RVA: 0x008F5699 File Offset: 0x008F3899
		// (set) Token: 0x0601E6E8 RID: 124648 RVA: 0x008F56AD File Offset: 0x008F38AD
		public unsafe UMaterialInstanceDynamic Moon_Cloud_Shadows_MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_76);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_76, value);
			}
		}

		// Token: 0x17002A47 RID: 10823
		// (get) Token: 0x0601E6E9 RID: 124649 RVA: 0x008F56C2 File Offset: 0x008F38C2
		// (set) Token: 0x0601E6EA RID: 124650 RVA: 0x008F56D2 File Offset: 0x008F38D2
		public unsafe float Sun_Yaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x17002A48 RID: 10824
		// (get) Token: 0x0601E6EB RID: 124651 RVA: 0x008F56E3 File Offset: 0x008F38E3
		// (set) Token: 0x0601E6EC RID: 124652 RVA: 0x008F56F3 File Offset: 0x008F38F3
		public unsafe float Moon_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x17002A49 RID: 10825
		// (get) Token: 0x0601E6ED RID: 124653 RVA: 0x008F5704 File Offset: 0x008F3904
		// (set) Token: 0x0601E6EE RID: 124654 RVA: 0x008F5718 File Offset: 0x008F3918
		public unsafe UTexture2D Custom_Moon_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_79);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_79, value);
			}
		}

		// Token: 0x17002A4A RID: 10826
		// (get) Token: 0x0601E6EF RID: 124655 RVA: 0x008F572D File Offset: 0x008F392D
		// (set) Token: 0x0601E6F0 RID: 124656 RVA: 0x008F573D File Offset: 0x008F393D
		public unsafe bool Use_Custom_Moon_Texture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_80) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_80) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A4B RID: 10827
		// (get) Token: 0x0601E6F1 RID: 124657 RVA: 0x008F574E File Offset: 0x008F394E
		// (set) Token: 0x0601E6F2 RID: 124658 RVA: 0x008F5762 File Offset: 0x008F3962
		[Nullable(0)]
		public unsafe TEnumAsByte<EComponentMobility> Moon_Mobility
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_81);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_81) = value;
			}
		}

		// Token: 0x17002A4C RID: 10828
		// (get) Token: 0x0601E6F3 RID: 124659 RVA: 0x008F5777 File Offset: 0x008F3977
		// (set) Token: 0x0601E6F4 RID: 124660 RVA: 0x008F578B File Offset: 0x008F398B
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_FeatureToggle> Sky_Light
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_82);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_82) = value;
			}
		}

		// Token: 0x17002A4D RID: 10829
		// (get) Token: 0x0601E6F5 RID: 124661 RVA: 0x008F57A0 File Offset: 0x008F39A0
		// (set) Token: 0x0601E6F6 RID: 124662 RVA: 0x008F57B4 File Offset: 0x008F39B4
		public unsafe ASkyLight Custom_Sky_Light_Actor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkyLight>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_83);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_83, value);
			}
		}

		// Token: 0x17002A4E RID: 10830
		// (get) Token: 0x0601E6F7 RID: 124663 RVA: 0x008F57C9 File Offset: 0x008F39C9
		// (set) Token: 0x0601E6F8 RID: 124664 RVA: 0x008F57DD File Offset: 0x008F39DD
		[Nullable(0)]
		public unsafe TEnumAsByte<EComponentMobility> Sky_Light_Mobility
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_84);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x17002A4F RID: 10831
		// (get) Token: 0x0601E6F9 RID: 124665 RVA: 0x008F57F2 File Offset: 0x008F39F2
		// (set) Token: 0x0601E6FA RID: 124666 RVA: 0x008F5806 File Offset: 0x008F3A06
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_FeatureToggle> Height_Fog
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_85);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x17002A50 RID: 10832
		// (get) Token: 0x0601E6FB RID: 124667 RVA: 0x008F581B File Offset: 0x008F3A1B
		// (set) Token: 0x0601E6FC RID: 124668 RVA: 0x008F582F File Offset: 0x008F3A2F
		public unsafe AExponentialHeightFog Custom_Height_Fog_Actor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AExponentialHeightFog>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_86);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_86, value);
			}
		}

		// Token: 0x17002A51 RID: 10833
		// (get) Token: 0x0601E6FD RID: 124669 RVA: 0x008F5844 File Offset: 0x008F3A44
		// (set) Token: 0x0601E6FE RID: 124670 RVA: 0x008F5858 File Offset: 0x008F3A58
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_SkyLightMode> Sky_Light_Mode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_87);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_87) = value;
			}
		}

		// Token: 0x17002A52 RID: 10834
		// (get) Token: 0x0601E6FF RID: 124671 RVA: 0x008F586D File Offset: 0x008F3A6D
		// (set) Token: 0x0601E700 RID: 124672 RVA: 0x008F5881 File Offset: 0x008F3A81
		public unsafe UCurveFloat Night_Filter_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_88);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_88, value);
			}
		}

		// Token: 0x17002A53 RID: 10835
		// (get) Token: 0x0601E701 RID: 124673 RVA: 0x008F5896 File Offset: 0x008F3A96
		// (set) Token: 0x0601E702 RID: 124674 RVA: 0x008F58A6 File Offset: 0x008F3AA6
		public unsafe float Moon_Glow_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_89);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_89) = value;
			}
		}

		// Token: 0x17002A54 RID: 10836
		// (get) Token: 0x0601E703 RID: 124675 RVA: 0x008F58B7 File Offset: 0x008F3AB7
		// (set) Token: 0x0601E704 RID: 124676 RVA: 0x008F58C7 File Offset: 0x008F3AC7
		public unsafe float Sun_Light_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_90);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_90) = value;
			}
		}

		// Token: 0x17002A55 RID: 10837
		// (get) Token: 0x0601E705 RID: 124677 RVA: 0x008F58D8 File Offset: 0x008F3AD8
		// (set) Token: 0x0601E706 RID: 124678 RVA: 0x008F58E8 File Offset: 0x008F3AE8
		public unsafe bool Use_Auroras
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_91) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_91) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A56 RID: 10838
		// (get) Token: 0x0601E707 RID: 124679 RVA: 0x008F58F9 File Offset: 0x008F3AF9
		// (set) Token: 0x0601E708 RID: 124680 RVA: 0x008F5909 File Offset: 0x008F3B09
		public unsafe float Aurora_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x17002A57 RID: 10839
		// (get) Token: 0x0601E709 RID: 124681 RVA: 0x008F591A File Offset: 0x008F3B1A
		// (set) Token: 0x0601E70A RID: 124682 RVA: 0x008F592A File Offset: 0x008F3B2A
		public unsafe float Aurora_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x17002A58 RID: 10840
		// (get) Token: 0x0601E70B RID: 124683 RVA: 0x008F593B File Offset: 0x008F3B3B
		// (set) Token: 0x0601E70C RID: 124684 RVA: 0x008F594B File Offset: 0x008F3B4B
		public unsafe float Cloud_Shadows_Intensity_When_Overcast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17002A59 RID: 10841
		// (get) Token: 0x0601E70D RID: 124685 RVA: 0x008F595C File Offset: 0x008F3B5C
		// (set) Token: 0x0601E70E RID: 124686 RVA: 0x008F596C File Offset: 0x008F3B6C
		public unsafe float Cloud_Shadows_Softness_When_Sunny
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x17002A5A RID: 10842
		// (get) Token: 0x0601E70F RID: 124687 RVA: 0x008F597D File Offset: 0x008F3B7D
		// (set) Token: 0x0601E710 RID: 124688 RVA: 0x008F598D File Offset: 0x008F3B8D
		public unsafe float Cloud_Shadows_Softness_When_Overcast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x17002A5B RID: 10843
		// (get) Token: 0x0601E711 RID: 124689 RVA: 0x008F599E File Offset: 0x008F3B9E
		// (set) Token: 0x0601E712 RID: 124690 RVA: 0x008F59AE File Offset: 0x008F3BAE
		public unsafe float Cloud_Tiling_Layer_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_97);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_97) = value;
			}
		}

		// Token: 0x17002A5C RID: 10844
		// (get) Token: 0x0601E713 RID: 124691 RVA: 0x008F59BF File Offset: 0x008F3BBF
		// (set) Token: 0x0601E714 RID: 124692 RVA: 0x008F59CF File Offset: 0x008F3BCF
		public unsafe float Cloud_Tiling_Layer_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_98);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_98) = value;
			}
		}

		// Token: 0x17002A5D RID: 10845
		// (get) Token: 0x0601E715 RID: 124693 RVA: 0x008F59E0 File Offset: 0x008F3BE0
		// (set) Token: 0x0601E716 RID: 124694 RVA: 0x008F59F0 File Offset: 0x008F3BF0
		public unsafe bool One_Cloud_Layer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_99) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_99) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A5E RID: 10846
		// (get) Token: 0x0601E717 RID: 124695 RVA: 0x008F5A01 File Offset: 0x008F3C01
		// (set) Token: 0x0601E718 RID: 124696 RVA: 0x008F5A11 File Offset: 0x008F3C11
		public unsafe float Cloud_Height_Layer_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x17002A5F RID: 10847
		// (get) Token: 0x0601E719 RID: 124697 RVA: 0x008F5A22 File Offset: 0x008F3C22
		// (set) Token: 0x0601E71A RID: 124698 RVA: 0x008F5A32 File Offset: 0x008F3C32
		public unsafe float Cloud_Height_Layer_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x17002A60 RID: 10848
		// (get) Token: 0x0601E71B RID: 124699 RVA: 0x008F5A43 File Offset: 0x008F3C43
		// (set) Token: 0x0601E71C RID: 124700 RVA: 0x008F5A53 File Offset: 0x008F3C53
		public unsafe float Overcast_Swirling_Texture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17002A61 RID: 10849
		// (get) Token: 0x0601E71D RID: 124701 RVA: 0x008F5A64 File Offset: 0x008F3C64
		// (set) Token: 0x0601E71E RID: 124702 RVA: 0x008F5A74 File Offset: 0x008F3C74
		public unsafe float Dawn_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_103);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x17002A62 RID: 10850
		// (get) Token: 0x0601E71F RID: 124703 RVA: 0x008F5A85 File Offset: 0x008F3C85
		// (set) Token: 0x0601E720 RID: 124704 RVA: 0x008F5A95 File Offset: 0x008F3C95
		public unsafe float Dusk_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17002A63 RID: 10851
		// (get) Token: 0x0601E721 RID: 124705 RVA: 0x008F5AA6 File Offset: 0x008F3CA6
		// (set) Token: 0x0601E722 RID: 124706 RVA: 0x008F5AB6 File Offset: 0x008F3CB6
		public unsafe float Night_brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_105);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_105) = value;
			}
		}

		// Token: 0x17002A64 RID: 10852
		// (get) Token: 0x0601E723 RID: 124707 RVA: 0x008F5AC7 File Offset: 0x008F3CC7
		// (set) Token: 0x0601E724 RID: 124708 RVA: 0x008F5AD7 File Offset: 0x008F3CD7
		public unsafe float Moon_Angle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_106);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_106) = value;
			}
		}

		// Token: 0x17002A65 RID: 10853
		// (get) Token: 0x0601E725 RID: 124709 RVA: 0x008F5AE8 File Offset: 0x008F3CE8
		// (set) Token: 0x0601E726 RID: 124710 RVA: 0x008F5AF8 File Offset: 0x008F3CF8
		public unsafe float Sun_Volumetric_Scattering_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_107);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_107) = value;
			}
		}

		// Token: 0x17002A66 RID: 10854
		// (get) Token: 0x0601E727 RID: 124711 RVA: 0x008F5B09 File Offset: 0x008F3D09
		// (set) Token: 0x0601E728 RID: 124712 RVA: 0x008F5B19 File Offset: 0x008F3D19
		public unsafe float Moon_Volumetric_Scattering_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_108);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_108) = value;
			}
		}

		// Token: 0x17002A67 RID: 10855
		// (get) Token: 0x0601E729 RID: 124713 RVA: 0x008F5B2A File Offset: 0x008F3D2A
		// (set) Token: 0x0601E72A RID: 124714 RVA: 0x008F5B3A File Offset: 0x008F3D3A
		public unsafe float Aurora_Phase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_109);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_109) = value;
			}
		}

		// Token: 0x17002A68 RID: 10856
		// (get) Token: 0x0601E72B RID: 124715 RVA: 0x008F5B4B File Offset: 0x008F3D4B
		// (set) Token: 0x0601E72C RID: 124716 RVA: 0x008F5B5F File Offset: 0x008F3D5F
		[Nullable(1)]
		public unsafe string Readme
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_110)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_110)), value);
			}
		}

		// Token: 0x17002A69 RID: 10857
		// (get) Token: 0x0601E72D RID: 124717 RVA: 0x008F5B74 File Offset: 0x008F3D74
		// (set) Token: 0x0601E72E RID: 124718 RVA: 0x008F5B88 File Offset: 0x008F3D88
		public unsafe ULightComponent Sun_LightComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_111);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_111, value);
			}
		}

		// Token: 0x17002A6A RID: 10858
		// (get) Token: 0x0601E72F RID: 124719 RVA: 0x008F5B9D File Offset: 0x008F3D9D
		// (set) Token: 0x0601E730 RID: 124720 RVA: 0x008F5BB1 File Offset: 0x008F3DB1
		public unsafe ULightComponent Moon_LightComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_112);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_112, value);
			}
		}

		// Token: 0x17002A6B RID: 10859
		// (get) Token: 0x0601E731 RID: 124721 RVA: 0x008F5BC6 File Offset: 0x008F3DC6
		// (set) Token: 0x0601E732 RID: 124722 RVA: 0x008F5BDA File Offset: 0x008F3DDA
		public unsafe USkyLightComponent SkyLightComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkyLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_113);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_113, value);
			}
		}

		// Token: 0x17002A6C RID: 10860
		// (get) Token: 0x0601E733 RID: 124723 RVA: 0x008F5BEF File Offset: 0x008F3DEF
		// (set) Token: 0x0601E734 RID: 124724 RVA: 0x008F5C03 File Offset: 0x008F3E03
		public unsafe UExponentialHeightFogComponent Height_Fog_Component
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UExponentialHeightFogComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_114);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_114, value);
			}
		}

		// Token: 0x17002A6D RID: 10861
		// (get) Token: 0x0601E735 RID: 124725 RVA: 0x008F5C18 File Offset: 0x008F3E18
		// (set) Token: 0x0601E736 RID: 124726 RVA: 0x008F5C28 File Offset: 0x008F3E28
		public unsafe bool Use_Exposure_Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_115) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_115) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A6E RID: 10862
		// (get) Token: 0x0601E737 RID: 124727 RVA: 0x008F5C39 File Offset: 0x008F3E39
		// (set) Token: 0x0601E738 RID: 124728 RVA: 0x008F5C49 File Offset: 0x008F3E49
		public unsafe float Exposure_Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_116);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_116) = value;
			}
		}

		// Token: 0x17002A6F RID: 10863
		// (get) Token: 0x0601E739 RID: 124729 RVA: 0x008F5C5A File Offset: 0x008F3E5A
		// (set) Token: 0x0601E73A RID: 124730 RVA: 0x008F5C6A File Offset: 0x008F3E6A
		public unsafe float Exposure_Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_117);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_117) = value;
			}
		}

		// Token: 0x17002A70 RID: 10864
		// (get) Token: 0x0601E73B RID: 124731 RVA: 0x008F5C7B File Offset: 0x008F3E7B
		// (set) Token: 0x0601E73C RID: 124732 RVA: 0x008F5C8B File Offset: 0x008F3E8B
		public unsafe float TimeRandomOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_118);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_118) = value;
			}
		}

		// Token: 0x17002A71 RID: 10865
		// (get) Token: 0x0601E73D RID: 124733 RVA: 0x008F5C9C File Offset: 0x008F3E9C
		// (set) Token: 0x0601E73E RID: 124734 RVA: 0x008F5CAC File Offset: 0x008F3EAC
		public unsafe float Extend_Dawn_and_Dusk
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_119);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_119) = value;
			}
		}

		// Token: 0x17002A72 RID: 10866
		// (get) Token: 0x0601E73F RID: 124735 RVA: 0x008F5CBD File Offset: 0x008F3EBD
		// (set) Token: 0x0601E740 RID: 124736 RVA: 0x008F5CCD File Offset: 0x008F3ECD
		public unsafe bool Move_Static_Stationary_Lights
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_120) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_120) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A73 RID: 10867
		// (get) Token: 0x0601E741 RID: 124737 RVA: 0x008F5CDE File Offset: 0x008F3EDE
		// (set) Token: 0x0601E742 RID: 124738 RVA: 0x008F5CEE File Offset: 0x008F3EEE
		public unsafe float Fog_Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_121);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_121) = value;
			}
		}

		// Token: 0x17002A74 RID: 10868
		// (get) Token: 0x0601E743 RID: 124739 RVA: 0x008F5CFF File Offset: 0x008F3EFF
		// (set) Token: 0x0601E744 RID: 124740 RVA: 0x008F5D13 File Offset: 0x008F3F13
		public unsafe UCurveLinearColor Fog_Inscattering_Color_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_122);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_122, value);
			}
		}

		// Token: 0x17002A75 RID: 10869
		// (get) Token: 0x0601E745 RID: 124741 RVA: 0x008F5D28 File Offset: 0x008F3F28
		// (set) Token: 0x0601E746 RID: 124742 RVA: 0x008F5D3C File Offset: 0x008F3F3C
		public unsafe UCurveLinearColor Fog_Directional_Inscattering_Color_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_123);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_123, value);
			}
		}

		// Token: 0x17002A76 RID: 10870
		// (get) Token: 0x0601E747 RID: 124743 RVA: 0x008F5D51 File Offset: 0x008F3F51
		// (set) Token: 0x0601E748 RID: 124744 RVA: 0x008F5D61 File Offset: 0x008F3F61
		public unsafe float Stars_Tiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_124);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_124) = value;
			}
		}

		// Token: 0x17002A77 RID: 10871
		// (get) Token: 0x0601E749 RID: 124745 RVA: 0x008F5D72 File Offset: 0x008F3F72
		// (set) Token: 0x0601E74A RID: 124746 RVA: 0x008F5D86 File Offset: 0x008F3F86
		public unsafe UTexture2D Stars_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_125);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_125, value);
			}
		}

		// Token: 0x17002A78 RID: 10872
		// (get) Token: 0x0601E74B RID: 124747 RVA: 0x008F5D9B File Offset: 0x008F3F9B
		// (set) Token: 0x0601E74C RID: 124748 RVA: 0x008F5DAB File Offset: 0x008F3FAB
		public unsafe float Night_Sky_Glow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_126);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_126) = value;
			}
		}

		// Token: 0x17002A79 RID: 10873
		// (get) Token: 0x0601E74D RID: 124749 RVA: 0x008F5DBC File Offset: 0x008F3FBC
		// (set) Token: 0x0601E74E RID: 124750 RVA: 0x008F5DD0 File Offset: 0x008F3FD0
		public unsafe FLinearColor Night_Sky_Glow_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_127);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_127) = value;
			}
		}

		// Token: 0x17002A7A RID: 10874
		// (get) Token: 0x0601E74F RID: 124751 RVA: 0x008F5DE5 File Offset: 0x008F3FE5
		// (set) Token: 0x0601E750 RID: 124752 RVA: 0x008F5DF5 File Offset: 0x008F3FF5
		public unsafe float Stars_Phase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_128);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_128) = value;
			}
		}

		// Token: 0x17002A7B RID: 10875
		// (get) Token: 0x0601E751 RID: 124753 RVA: 0x008F5E06 File Offset: 0x008F4006
		// (set) Token: 0x0601E752 RID: 124754 RVA: 0x008F5E1A File Offset: 0x008F401A
		public unsafe UCurveFloat Stars_Intensity_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_129);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_129, value);
			}
		}

		// Token: 0x17002A7C RID: 10876
		// (get) Token: 0x0601E753 RID: 124755 RVA: 0x008F5E2F File Offset: 0x008F402F
		// (set) Token: 0x0601E754 RID: 124756 RVA: 0x008F5E3F File Offset: 0x008F403F
		public unsafe float Sky_Light_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_130);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_130) = value;
			}
		}

		// Token: 0x17002A7D RID: 10877
		// (get) Token: 0x0601E755 RID: 124757 RVA: 0x008F5E50 File Offset: 0x008F4050
		// (set) Token: 0x0601E756 RID: 124758 RVA: 0x008F5E64 File Offset: 0x008F4064
		public unsafe UTextureCube Flat_Sunny_Cubemap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureCube>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_131);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_131, value);
			}
		}

		// Token: 0x17002A7E RID: 10878
		// (get) Token: 0x0601E757 RID: 124759 RVA: 0x008F5E79 File Offset: 0x008F4079
		// (set) Token: 0x0601E758 RID: 124760 RVA: 0x008F5E8D File Offset: 0x008F408D
		public unsafe UTextureCube Flat_Overcast_Cubemap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureCube>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_132);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_132, value);
			}
		}

		// Token: 0x17002A7F RID: 10879
		// (get) Token: 0x0601E759 RID: 124761 RVA: 0x008F5EA2 File Offset: 0x008F40A2
		// (set) Token: 0x0601E75A RID: 124762 RVA: 0x008F5EB6 File Offset: 0x008F40B6
		public unsafe UCurveLinearColor Sky_Light_Dynamic_Tinting_Color_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_133);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_133, value);
			}
		}

		// Token: 0x17002A80 RID: 10880
		// (get) Token: 0x0601E75B RID: 124763 RVA: 0x008F5ECB File Offset: 0x008F40CB
		// (set) Token: 0x0601E75C RID: 124764 RVA: 0x008F5EDF File Offset: 0x008F40DF
		public unsafe UTextureCube Custom_Cubemap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureCube>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_134);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_134, value);
			}
		}

		// Token: 0x17002A81 RID: 10881
		// (get) Token: 0x0601E75D RID: 124765 RVA: 0x008F5EF4 File Offset: 0x008F40F4
		// (set) Token: 0x0601E75E RID: 124766 RVA: 0x008F5F08 File Offset: 0x008F4108
		public unsafe FLinearColor Sky_Light_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_135);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_135) = value;
			}
		}

		// Token: 0x17002A82 RID: 10882
		// (get) Token: 0x0601E75F RID: 124767 RVA: 0x008F5F1D File Offset: 0x008F411D
		// (set) Token: 0x0601E760 RID: 124768 RVA: 0x008F5F31 File Offset: 0x008F4131
		public unsafe FLinearColor Sky_Light_Lower_Hemisphere_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_136);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_136) = value;
			}
		}

		// Token: 0x17002A83 RID: 10883
		// (get) Token: 0x0601E761 RID: 124769 RVA: 0x008F5F46 File Offset: 0x008F4146
		// (set) Token: 0x0601E762 RID: 124770 RVA: 0x008F5F56 File Offset: 0x008F4156
		public unsafe bool Recapture_Sky_light_Periodically
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_137) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_137) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A84 RID: 10884
		// (get) Token: 0x0601E763 RID: 124771 RVA: 0x008F5F67 File Offset: 0x008F4167
		// (set) Token: 0x0601E764 RID: 124772 RVA: 0x008F5F77 File Offset: 0x008F4177
		public unsafe float Sky_Light_Recapture_Period__Seconds_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_138);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_138) = value;
			}
		}

		// Token: 0x17002A85 RID: 10885
		// (get) Token: 0x0601E765 RID: 124773 RVA: 0x008F5F88 File Offset: 0x008F4188
		// (set) Token: 0x0601E766 RID: 124774 RVA: 0x008F5F98 File Offset: 0x008F4198
		public unsafe float Sunrise_Event_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_139);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_139) = value;
			}
		}

		// Token: 0x17002A86 RID: 10886
		// (get) Token: 0x0601E767 RID: 124775 RVA: 0x008F5FA9 File Offset: 0x008F41A9
		// (set) Token: 0x0601E768 RID: 124776 RVA: 0x008F5FB9 File Offset: 0x008F41B9
		public unsafe float Sunset_Event_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_140);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_140) = value;
			}
		}

		// Token: 0x17002A87 RID: 10887
		// (get) Token: 0x0601E769 RID: 124777 RVA: 0x008F5FCC File Offset: 0x008F41CC
		// (set) Token: 0x0601E76A RID: 124778 RVA: 0x008F6005 File Offset: 0x008F4205
		[Nullable(1)]
		public Sunset Sunset
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				Sunset result;
				if ((result = this._Sunset) == null)
				{
					result = (this._Sunset = new Sunset(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_141, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_141, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002A88 RID: 10888
		// (get) Token: 0x0601E76B RID: 124779 RVA: 0x008F6028 File Offset: 0x008F4228
		// (set) Token: 0x0601E76C RID: 124780 RVA: 0x008F6061 File Offset: 0x008F4261
		[Nullable(1)]
		public Sunrise Sunrise
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				Sunrise result;
				if ((result = this._Sunrise) == null)
				{
					result = (this._Sunrise = new Sunrise(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_142, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_142, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002A89 RID: 10889
		// (get) Token: 0x0601E76D RID: 124781 RVA: 0x008F6082 File Offset: 0x008F4282
		// (set) Token: 0x0601E76E RID: 124782 RVA: 0x008F6092 File Offset: 0x008F4292
		public unsafe bool Use_Fog_Density_Curve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_143) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_143) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002A8A RID: 10890
		// (get) Token: 0x0601E76F RID: 124783 RVA: 0x008F60A3 File Offset: 0x008F42A3
		// (set) Token: 0x0601E770 RID: 124784 RVA: 0x008F60B7 File Offset: 0x008F42B7
		public unsafe UCurveFloat Fog_Density_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_144);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_144, value);
			}
		}

		// Token: 0x17002A8B RID: 10891
		// (get) Token: 0x0601E771 RID: 124785 RVA: 0x008F60CC File Offset: 0x008F42CC
		// (set) Token: 0x0601E772 RID: 124786 RVA: 0x008F60DC File Offset: 0x008F42DC
		public unsafe float Internal_Time_of_Day
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_145);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_145) = value;
			}
		}

		// Token: 0x17002A8C RID: 10892
		// (get) Token: 0x0601E773 RID: 124787 RVA: 0x008F60ED File Offset: 0x008F42ED
		// (set) Token: 0x0601E774 RID: 124788 RVA: 0x008F60FD File Offset: 0x008F42FD
		public unsafe float Horizon_Density_Multiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_146);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_146) = value;
			}
		}

		// Token: 0x17002A8D RID: 10893
		// (get) Token: 0x0601E775 RID: 124789 RVA: 0x008F610E File Offset: 0x008F430E
		// (set) Token: 0x0601E776 RID: 124790 RVA: 0x008F611E File Offset: 0x008F431E
		public unsafe float Zenith_Density_Multiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_147);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_147) = value;
			}
		}

		// Token: 0x17002A8E RID: 10894
		// (get) Token: 0x0601E777 RID: 124791 RVA: 0x008F612F File Offset: 0x008F432F
		// (set) Token: 0x0601E778 RID: 124792 RVA: 0x008F613F File Offset: 0x008F433F
		public unsafe float Latitude_Gradient_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_148);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_148) = value;
			}
		}

		// Token: 0x17002A8F RID: 10895
		// (get) Token: 0x0601E779 RID: 124793 RVA: 0x008F6150 File Offset: 0x008F4350
		// (set) Token: 0x0601E77A RID: 124794 RVA: 0x008F6160 File Offset: 0x008F4360
		public unsafe float Latitude_Gradient_Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_149);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_149) = value;
			}
		}

		// Token: 0x17002A90 RID: 10896
		// (get) Token: 0x0601E77B RID: 124795 RVA: 0x008F6171 File Offset: 0x008F4371
		// (set) Token: 0x0601E77C RID: 124796 RVA: 0x008F6181 File Offset: 0x008F4381
		public unsafe float Around_Sun_Density_Multiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_150);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_150) = value;
			}
		}

		// Token: 0x17002A91 RID: 10897
		// (get) Token: 0x0601E77D RID: 124797 RVA: 0x008F6192 File Offset: 0x008F4392
		// (set) Token: 0x0601E77E RID: 124798 RVA: 0x008F61A2 File Offset: 0x008F43A2
		public unsafe float Around_Sun_Density_Exponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_151);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_151) = value;
			}
		}

		// Token: 0x17002A92 RID: 10898
		// (get) Token: 0x0601E77F RID: 124799 RVA: 0x008F61B3 File Offset: 0x008F43B3
		// (set) Token: 0x0601E780 RID: 124800 RVA: 0x008F61C3 File Offset: 0x008F43C3
		public unsafe float Around_Moon_Density_Multiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_152);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_152) = value;
			}
		}

		// Token: 0x17002A93 RID: 10899
		// (get) Token: 0x0601E781 RID: 124801 RVA: 0x008F61D4 File Offset: 0x008F43D4
		// (set) Token: 0x0601E782 RID: 124802 RVA: 0x008F61E4 File Offset: 0x008F43E4
		public unsafe float Around_Moon_Density_Exponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_153);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_153) = value;
			}
		}

		// Token: 0x17002A94 RID: 10900
		// (get) Token: 0x0601E783 RID: 124803 RVA: 0x008F61F5 File Offset: 0x008F43F5
		// (set) Token: 0x0601E784 RID: 124804 RVA: 0x008F6209 File Offset: 0x008F4409
		public unsafe UTexture2D Cloud_Wisps_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_154);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_154, value);
			}
		}

		// Token: 0x17002A95 RID: 10901
		// (get) Token: 0x0601E785 RID: 124805 RVA: 0x008F621E File Offset: 0x008F441E
		// (set) Token: 0x0601E786 RID: 124806 RVA: 0x008F6232 File Offset: 0x008F4432
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_NoiseType> Cloud_Noise_Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_155);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_155) = value;
			}
		}

		// Token: 0x17002A96 RID: 10902
		// (get) Token: 0x0601E787 RID: 124807 RVA: 0x008F6247 File Offset: 0x008F4447
		// (set) Token: 0x0601E788 RID: 124808 RVA: 0x008F625B File Offset: 0x008F445B
		public unsafe UTexture Custom_Noise_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_156);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_156, value);
			}
		}

		// Token: 0x17002A97 RID: 10903
		// (get) Token: 0x0601E789 RID: 124809 RVA: 0x008F6270 File Offset: 0x008F4470
		// (set) Token: 0x0601E78A RID: 124810 RVA: 0x008F6280 File Offset: 0x008F4480
		public unsafe float Sun_Lighting_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_157);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_157) = value;
			}
		}

		// Token: 0x17002A98 RID: 10904
		// (get) Token: 0x0601E78B RID: 124811 RVA: 0x008F6291 File Offset: 0x008F4491
		// (set) Token: 0x0601E78C RID: 124812 RVA: 0x008F62A1 File Offset: 0x008F44A1
		public unsafe float Shine_Variation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_158);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_158) = value;
			}
		}

		// Token: 0x17002A99 RID: 10905
		// (get) Token: 0x0601E78D RID: 124813 RVA: 0x008F62B2 File Offset: 0x008F44B2
		// (set) Token: 0x0601E78E RID: 124814 RVA: 0x008F62C6 File Offset: 0x008F44C6
		public unsafe UCurveFloat Sun_Highlight_Radius_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_159);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_159, value);
			}
		}

		// Token: 0x17002A9A RID: 10906
		// (get) Token: 0x0601E78F RID: 124815 RVA: 0x008F62DB File Offset: 0x008F44DB
		// (set) Token: 0x0601E790 RID: 124816 RVA: 0x008F62EF File Offset: 0x008F44EF
		public unsafe UCurveFloat Sun_Highlight_Intensity_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_160);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_160, value);
			}
		}

		// Token: 0x17002A9B RID: 10907
		// (get) Token: 0x0601E791 RID: 124817 RVA: 0x008F6304 File Offset: 0x008F4504
		// (set) Token: 0x0601E792 RID: 124818 RVA: 0x008F6318 File Offset: 0x008F4518
		public unsafe UCurveFloat Shine_Intensity_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_161);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_161, value);
			}
		}

		// Token: 0x17002A9C RID: 10908
		// (get) Token: 0x0601E793 RID: 124819 RVA: 0x008F632D File Offset: 0x008F452D
		// (set) Token: 0x0601E794 RID: 124820 RVA: 0x008F633D File Offset: 0x008F453D
		public unsafe float Cloud_Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_162);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_162) = value;
			}
		}

		// Token: 0x17002A9D RID: 10909
		// (get) Token: 0x0601E795 RID: 124821 RVA: 0x008F634E File Offset: 0x008F454E
		// (set) Token: 0x0601E796 RID: 124822 RVA: 0x008F635E File Offset: 0x008F455E
		public unsafe float Sun_Vertical_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_163);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_163) = value;
			}
		}

		// Token: 0x17002A9E RID: 10910
		// (get) Token: 0x0601E797 RID: 124823 RVA: 0x008F636F File Offset: 0x008F456F
		// (set) Token: 0x0601E798 RID: 124824 RVA: 0x008F637F File Offset: 0x008F457F
		public unsafe float Moon_Vertical_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_164);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_164) = value;
			}
		}

		// Token: 0x17002A9F RID: 10911
		// (get) Token: 0x0601E799 RID: 124825 RVA: 0x008F6390 File Offset: 0x008F4590
		// (set) Token: 0x0601E79A RID: 124826 RVA: 0x008F63A0 File Offset: 0x008F45A0
		public unsafe float Directional_Lights_Absent_Brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_165);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_165) = value;
			}
		}

		// Token: 0x17002AA0 RID: 10912
		// (get) Token: 0x0601E79B RID: 124827 RVA: 0x008F63B1 File Offset: 0x008F45B1
		// (set) Token: 0x0601E79C RID: 124828 RVA: 0x008F63C5 File Offset: 0x008F45C5
		public unsafe UMaterialInstanceDynamic Volumetric_Clouds_MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_166);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_166, value);
			}
		}

		// Token: 0x17002AA1 RID: 10913
		// (get) Token: 0x0601E79D RID: 124829 RVA: 0x008F63DA File Offset: 0x008F45DA
		// (set) Token: 0x0601E79E RID: 124830 RVA: 0x008F63EA File Offset: 0x008F45EA
		public unsafe float Layer_Height_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_167);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_167) = value;
			}
		}

		// Token: 0x17002AA2 RID: 10914
		// (get) Token: 0x0601E79F RID: 124831 RVA: 0x008F63FB File Offset: 0x008F45FB
		// (set) Token: 0x0601E7A0 RID: 124832 RVA: 0x008F640B File Offset: 0x008F460B
		public unsafe float Bottom_Altitude
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_168);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_168) = value;
			}
		}

		// Token: 0x17002AA3 RID: 10915
		// (get) Token: 0x0601E7A1 RID: 124833 RVA: 0x008F641C File Offset: 0x008F461C
		// (set) Token: 0x0601E7A2 RID: 124834 RVA: 0x008F642C File Offset: 0x008F462C
		public unsafe float Base_Clouds_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_169);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_169) = value;
			}
		}

		// Token: 0x17002AA4 RID: 10916
		// (get) Token: 0x0601E7A3 RID: 124835 RVA: 0x008F643D File Offset: 0x008F463D
		// (set) Token: 0x0601E7A4 RID: 124836 RVA: 0x008F644D File Offset: 0x008F464D
		public unsafe float SubNoise_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_170);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_170) = value;
			}
		}

		// Token: 0x17002AA5 RID: 10917
		// (get) Token: 0x0601E7A5 RID: 124837 RVA: 0x008F645E File Offset: 0x008F465E
		// (set) Token: 0x0601E7A6 RID: 124838 RVA: 0x008F646E File Offset: 0x008F466E
		public unsafe float High_Frequency_Noise_Layer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_171);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_171) = value;
			}
		}

		// Token: 0x17002AA6 RID: 10918
		// (get) Token: 0x0601E7A7 RID: 124839 RVA: 0x008F647F File Offset: 0x008F467F
		// (set) Token: 0x0601E7A8 RID: 124840 RVA: 0x008F648F File Offset: 0x008F468F
		public unsafe float Extinction_Scale_Top
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_172);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_172) = value;
			}
		}

		// Token: 0x17002AA7 RID: 10919
		// (get) Token: 0x0601E7A9 RID: 124841 RVA: 0x008F64A0 File Offset: 0x008F46A0
		// (set) Token: 0x0601E7AA RID: 124842 RVA: 0x008F64B0 File Offset: 0x008F46B0
		public unsafe float Extinction_Scale_Bottom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_173);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_173) = value;
			}
		}

		// Token: 0x17002AA8 RID: 10920
		// (get) Token: 0x0601E7AB RID: 124843 RVA: 0x008F64C1 File Offset: 0x008F46C1
		// (set) Token: 0x0601E7AC RID: 124844 RVA: 0x008F64D1 File Offset: 0x008F46D1
		public unsafe float View_Sample_Count_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_174);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_174) = value;
			}
		}

		// Token: 0x17002AA9 RID: 10921
		// (get) Token: 0x0601E7AD RID: 124845 RVA: 0x008F64E2 File Offset: 0x008F46E2
		// (set) Token: 0x0601E7AE RID: 124846 RVA: 0x008F64F2 File Offset: 0x008F46F2
		public unsafe float Shadow_Sample_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_175);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_175) = value;
			}
		}

		// Token: 0x17002AAA RID: 10922
		// (get) Token: 0x0601E7AF RID: 124847 RVA: 0x008F6503 File Offset: 0x008F4703
		// (set) Token: 0x0601E7B0 RID: 124848 RVA: 0x008F6517 File Offset: 0x008F4717
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_NoiseType> Volumetric_Cloud_Noise_Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_176);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_176) = value;
			}
		}

		// Token: 0x17002AAB RID: 10923
		// (get) Token: 0x0601E7B1 RID: 124849 RVA: 0x008F652C File Offset: 0x008F472C
		// (set) Token: 0x0601E7B2 RID: 124850 RVA: 0x008F6540 File Offset: 0x008F4740
		public unsafe UTexture Volumetric_Custom_Noise_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_177);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_177, value);
			}
		}

		// Token: 0x17002AAC RID: 10924
		// (get) Token: 0x0601E7B3 RID: 124851 RVA: 0x008F6555 File Offset: 0x008F4755
		// (set) Token: 0x0601E7B4 RID: 124852 RVA: 0x008F6565 File Offset: 0x008F4765
		public unsafe float Multiscattering_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_178);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_178) = value;
			}
		}

		// Token: 0x17002AAD RID: 10925
		// (get) Token: 0x0601E7B5 RID: 124853 RVA: 0x008F6576 File Offset: 0x008F4776
		// (set) Token: 0x0601E7B6 RID: 124854 RVA: 0x008F6586 File Offset: 0x008F4786
		public unsafe float Multiscattering_Occlusion_Factor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_179);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_179) = value;
			}
		}

		// Token: 0x17002AAE RID: 10926
		// (get) Token: 0x0601E7B7 RID: 124855 RVA: 0x008F6597 File Offset: 0x008F4797
		// (set) Token: 0x0601E7B8 RID: 124856 RVA: 0x008F65A7 File Offset: 0x008F47A7
		public unsafe float Shadow_Tracing_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_180);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_180) = value;
			}
		}

		// Token: 0x17002AAF RID: 10927
		// (get) Token: 0x0601E7B9 RID: 124857 RVA: 0x008F65B8 File Offset: 0x008F47B8
		// (set) Token: 0x0601E7BA RID: 124858 RVA: 0x008F65C8 File Offset: 0x008F47C8
		public unsafe float SubNoise_Erosion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_181);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_181) = value;
			}
		}

		// Token: 0x17002AB0 RID: 10928
		// (get) Token: 0x0601E7BB RID: 124859 RVA: 0x008F65D9 File Offset: 0x008F47D9
		// (set) Token: 0x0601E7BC RID: 124860 RVA: 0x008F65E9 File Offset: 0x008F47E9
		public unsafe float FullCloudiness_Fog_Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_182);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_182) = value;
			}
		}

		// Token: 0x17002AB1 RID: 10929
		// (get) Token: 0x0601E7BD RID: 124861 RVA: 0x008F65FA File Offset: 0x008F47FA
		// (set) Token: 0x0601E7BE RID: 124862 RVA: 0x008F660A File Offset: 0x008F480A
		public unsafe bool Runtime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_183) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_183) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002AB2 RID: 10930
		// (get) Token: 0x0601E7BF RID: 124863 RVA: 0x008F661B File Offset: 0x008F481B
		// (set) Token: 0x0601E7C0 RID: 124864 RVA: 0x008F662B File Offset: 0x008F482B
		public unsafe float Clouds_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_184);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_184) = value;
			}
		}

		// Token: 0x17002AB3 RID: 10931
		// (get) Token: 0x0601E7C1 RID: 124865 RVA: 0x008F663C File Offset: 0x008F483C
		// (set) Token: 0x0601E7C2 RID: 124866 RVA: 0x008F664C File Offset: 0x008F484C
		public unsafe float Fog_Density_Distribution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_185);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_185) = value;
			}
		}

		// Token: 0x17002AB4 RID: 10932
		// (get) Token: 0x0601E7C3 RID: 124867 RVA: 0x008F665D File Offset: 0x008F485D
		// (set) Token: 0x0601E7C4 RID: 124868 RVA: 0x008F666D File Offset: 0x008F486D
		public unsafe bool Use_Volumetric_Fog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_186) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_186) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002AB5 RID: 10933
		// (get) Token: 0x0601E7C5 RID: 124869 RVA: 0x008F667E File Offset: 0x008F487E
		// (set) Token: 0x0601E7C6 RID: 124870 RVA: 0x008F668E File Offset: 0x008F488E
		public unsafe bool Randomize_Cloud_Formation_on_Run
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_187) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_187) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002AB6 RID: 10934
		// (get) Token: 0x0601E7C7 RID: 124871 RVA: 0x008F669F File Offset: 0x008F489F
		// (set) Token: 0x0601E7C8 RID: 124872 RVA: 0x008F66AF File Offset: 0x008F48AF
		public unsafe float Phase_G
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_188);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_188) = value;
			}
		}

		// Token: 0x17002AB7 RID: 10935
		// (get) Token: 0x0601E7C9 RID: 124873 RVA: 0x008F66C0 File Offset: 0x008F48C0
		// (set) Token: 0x0601E7CA RID: 124874 RVA: 0x008F66D0 File Offset: 0x008F48D0
		public unsafe float Phase_G_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_189);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_189) = value;
			}
		}

		// Token: 0x17002AB8 RID: 10936
		// (get) Token: 0x0601E7CB RID: 124875 RVA: 0x008F66E1 File Offset: 0x008F48E1
		// (set) Token: 0x0601E7CC RID: 124876 RVA: 0x008F66F1 File Offset: 0x008F48F1
		public unsafe float MultiScattering_Eccentricity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_190);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_190) = value;
			}
		}

		// Token: 0x17002AB9 RID: 10937
		// (get) Token: 0x0601E7CD RID: 124877 RVA: 0x008F6702 File Offset: 0x008F4902
		// (set) Token: 0x0601E7CE RID: 124878 RVA: 0x008F6712 File Offset: 0x008F4912
		public unsafe float Distance_to_Sample_Max_Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_191);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_191) = value;
			}
		}

		// Token: 0x17002ABA RID: 10938
		// (get) Token: 0x0601E7CF RID: 124879 RVA: 0x008F6723 File Offset: 0x008F4923
		// (set) Token: 0x0601E7D0 RID: 124880 RVA: 0x008F6733 File Offset: 0x008F4933
		public unsafe float Time_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_192);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_192) = value;
			}
		}

		// Token: 0x17002ABB RID: 10939
		// (get) Token: 0x0601E7D1 RID: 124881 RVA: 0x008F6744 File Offset: 0x008F4944
		// (set) Token: 0x0601E7D2 RID: 124882 RVA: 0x008F6754 File Offset: 0x008F4954
		public unsafe bool Force_Light_Functions_On
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_193) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_193) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002ABC RID: 10940
		// (get) Token: 0x0601E7D3 RID: 124883 RVA: 0x008F6765 File Offset: 0x008F4965
		// (set) Token: 0x0601E7D4 RID: 124884 RVA: 0x008F6779 File Offset: 0x008F4979
		public unsafe Ultra_Dynamic_Weather_C Weather_BP
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<Ultra_Dynamic_Weather_C>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_194);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_194, value);
			}
		}

		// Token: 0x17002ABD RID: 10941
		// (get) Token: 0x0601E7D5 RID: 124885 RVA: 0x008F678E File Offset: 0x008F498E
		// (set) Token: 0x0601E7D6 RID: 124886 RVA: 0x008F679E File Offset: 0x008F499E
		public unsafe float Volumetric_Clouds_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_195);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_195) = value;
			}
		}

		// Token: 0x17002ABE RID: 10942
		// (get) Token: 0x0601E7D7 RID: 124887 RVA: 0x008F67AF File Offset: 0x008F49AF
		// (set) Token: 0x0601E7D8 RID: 124888 RVA: 0x008F67BF File Offset: 0x008F49BF
		public unsafe float Tracing_Max_Start_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_196);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_196) = value;
			}
		}

		// Token: 0x17002ABF RID: 10943
		// (get) Token: 0x0601E7D9 RID: 124889 RVA: 0x008F67D0 File Offset: 0x008F49D0
		// (set) Token: 0x0601E7DA RID: 124890 RVA: 0x008F67E4 File Offset: 0x008F49E4
		public unsafe UMaterialInstanceDynamic Static_Clouds_MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_197);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_197, value);
			}
		}

		// Token: 0x17002AC0 RID: 10944
		// (get) Token: 0x0601E7DB RID: 124891 RVA: 0x008F67F9 File Offset: 0x008F49F9
		// (set) Token: 0x0601E7DC RID: 124892 RVA: 0x008F680D File Offset: 0x008F4A0D
		public unsafe FLinearColor Aurora_Color_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_198);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_198) = value;
			}
		}

		// Token: 0x17002AC1 RID: 10945
		// (get) Token: 0x0601E7DD RID: 124893 RVA: 0x008F6822 File Offset: 0x008F4A22
		// (set) Token: 0x0601E7DE RID: 124894 RVA: 0x008F6836 File Offset: 0x008F4A36
		public unsafe FLinearColor Aurora_Color_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_199);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_199) = value;
			}
		}

		// Token: 0x17002AC2 RID: 10946
		// (get) Token: 0x0601E7DF RID: 124895 RVA: 0x008F684B File Offset: 0x008F4A4B
		// (set) Token: 0x0601E7E0 RID: 124896 RVA: 0x008F685F File Offset: 0x008F4A5F
		public unsafe FLinearColor Aurora_Color_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_200);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_200) = value;
			}
		}

		// Token: 0x17002AC3 RID: 10947
		// (get) Token: 0x0601E7E1 RID: 124897 RVA: 0x008F6874 File Offset: 0x008F4A74
		// (set) Token: 0x0601E7E2 RID: 124898 RVA: 0x008F6888 File Offset: 0x008F4A88
		public unsafe UMaterialInstanceDynamic Volumetric_Aurora_MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_201);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_201, value);
			}
		}

		// Token: 0x17002AC4 RID: 10948
		// (get) Token: 0x0601E7E3 RID: 124899 RVA: 0x008F689D File Offset: 0x008F4A9D
		// (set) Token: 0x0601E7E4 RID: 124900 RVA: 0x008F68AD File Offset: 0x008F4AAD
		public unsafe float Overcast_Night_Brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_202);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_202) = value;
			}
		}

		// Token: 0x17002AC5 RID: 10949
		// (get) Token: 0x0601E7E5 RID: 124901 RVA: 0x008F68BE File Offset: 0x008F4ABE
		// (set) Token: 0x0601E7E6 RID: 124902 RVA: 0x008F68CE File Offset: 0x008F4ACE
		public unsafe bool Use_Sky_Mode_Scalability_Map
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_203) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_203) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002AC6 RID: 10950
		// (get) Token: 0x0601E7E7 RID: 124903 RVA: 0x008F68E0 File Offset: 0x008F4AE0
		// (set) Token: 0x0601E7E8 RID: 124904 RVA: 0x008F6919 File Offset: 0x008F4B19
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<int, TEnumAsByte<UDS_SkyMode>> Sky_Mode_ScalabilityMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<int, TEnumAsByte<UDS_SkyMode>> result;
				if ((result = this._Sky_Mode_ScalabilityMap) == null)
				{
					result = (this._Sky_Mode_ScalabilityMap = new TMap<int, TEnumAsByte<UDS_SkyMode>>(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_204, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Sky_Mode_ScalabilityMap.CopyAssign(value);
			}
		}

		// Token: 0x17002AC7 RID: 10951
		// (get) Token: 0x0601E7E9 RID: 124905 RVA: 0x008F6927 File Offset: 0x008F4B27
		// (set) Token: 0x0601E7EA RID: 124906 RVA: 0x008F6937 File Offset: 0x008F4B37
		public unsafe float Scale_Skylight_Intensity_at_Night
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_205);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_205) = value;
			}
		}

		// Token: 0x17002AC8 RID: 10952
		// (get) Token: 0x0601E7EB RID: 124907 RVA: 0x008F6948 File Offset: 0x008F4B48
		// (set) Token: 0x0601E7EC RID: 124908 RVA: 0x008F6958 File Offset: 0x008F4B58
		public unsafe float Scale_Skylight_Intensity_when_Cloudy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_206);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_206) = value;
			}
		}

		// Token: 0x17002AC9 RID: 10953
		// (get) Token: 0x0601E7ED RID: 124909 RVA: 0x008F6969 File Offset: 0x008F4B69
		// (set) Token: 0x0601E7EE RID: 124910 RVA: 0x008F697D File Offset: 0x008F4B7D
		public unsafe UCurveLinearColor Horizon_Base_Color__Legacy_Color_Curve_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_207);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_207, value);
			}
		}

		// Token: 0x17002ACA RID: 10954
		// (get) Token: 0x0601E7EF RID: 124911 RVA: 0x008F6992 File Offset: 0x008F4B92
		// (set) Token: 0x0601E7F0 RID: 124912 RVA: 0x008F69A6 File Offset: 0x008F4BA6
		public unsafe UCurveLinearColor Cloud_Dark_Color__Legacy_Color_Curve_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_208);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_208, value);
			}
		}

		// Token: 0x17002ACB RID: 10955
		// (get) Token: 0x0601E7F1 RID: 124913 RVA: 0x008F69BB File Offset: 0x008F4BBB
		// (set) Token: 0x0601E7F2 RID: 124914 RVA: 0x008F69CF File Offset: 0x008F4BCF
		public unsafe UCurveLinearColor Cloud_Light_Color__Legacy_Color_Curve_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_209);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_209, value);
			}
		}

		// Token: 0x17002ACC RID: 10956
		// (get) Token: 0x0601E7F3 RID: 124915 RVA: 0x008F69E4 File Offset: 0x008F4BE4
		// (set) Token: 0x0601E7F4 RID: 124916 RVA: 0x008F69F8 File Offset: 0x008F4BF8
		public unsafe UCurveLinearColor Sun_Color__Legacy_Color_Curve_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_210);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_210, value);
			}
		}

		// Token: 0x17002ACD RID: 10957
		// (get) Token: 0x0601E7F5 RID: 124917 RVA: 0x008F6A0D File Offset: 0x008F4C0D
		// (set) Token: 0x0601E7F6 RID: 124918 RVA: 0x008F6A21 File Offset: 0x008F4C21
		public unsafe UCurveLinearColor Sun_Cloudy_Color_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_211);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_211, value);
			}
		}

		// Token: 0x17002ACE RID: 10958
		// (get) Token: 0x0601E7F7 RID: 124919 RVA: 0x008F6A36 File Offset: 0x008F4C36
		// (set) Token: 0x0601E7F8 RID: 124920 RVA: 0x008F6A4A File Offset: 0x008F4C4A
		public unsafe UCurveLinearColor Zenith_Base_Color__Legacy_Color_Curve_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveLinearColor>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_212);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_212, value);
			}
		}

		// Token: 0x17002ACF RID: 10959
		// (get) Token: 0x0601E7F9 RID: 124921 RVA: 0x008F6A5F File Offset: 0x008F4C5F
		// (set) Token: 0x0601E7FA RID: 124922 RVA: 0x008F6A73 File Offset: 0x008F4C73
		public unsafe UCurveFloat Directional_Intensity_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_213);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_213, value);
			}
		}

		// Token: 0x17002AD0 RID: 10960
		// (get) Token: 0x0601E7FB RID: 124923 RVA: 0x008F6A88 File Offset: 0x008F4C88
		// (set) Token: 0x0601E7FC RID: 124924 RVA: 0x008F6A9C File Offset: 0x008F4C9C
		public unsafe UCurveFloat Aurora_Intensity_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_214);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_214, value);
			}
		}

		// Token: 0x17002AD1 RID: 10961
		// (get) Token: 0x0601E7FD RID: 124925 RVA: 0x008F6AB1 File Offset: 0x008F4CB1
		// (set) Token: 0x0601E7FE RID: 124926 RVA: 0x008F6AC5 File Offset: 0x008F4CC5
		public unsafe UMaterialInstanceDynamic Inside_Clouds_Fog_MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_215);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Sky_C.__PropertyOffset_215, value);
			}
		}

		// Token: 0x17002AD2 RID: 10962
		// (get) Token: 0x0601E7FF RID: 124927 RVA: 0x008F6ADA File Offset: 0x008F4CDA
		// (set) Token: 0x0601E800 RID: 124928 RVA: 0x008F6AEA File Offset: 0x008F4CEA
		public unsafe float Tracing_Max_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_216);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_216) = value;
			}
		}

		// Token: 0x17002AD3 RID: 10963
		// (get) Token: 0x0601E801 RID: 124929 RVA: 0x008F6AFB File Offset: 0x008F4CFB
		// (set) Token: 0x0601E802 RID: 124930 RVA: 0x008F6B0B File Offset: 0x008F4D0B
		public unsafe bool Enable_Fog_Inside_Clouds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_217) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_217) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002AD4 RID: 10964
		// (get) Token: 0x0601E803 RID: 124931 RVA: 0x008F6B1C File Offset: 0x008F4D1C
		// (set) Token: 0x0601E804 RID: 124932 RVA: 0x008F6B2C File Offset: 0x008F4D2C
		public unsafe float Volumetric_Aurora_Sample_Count_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_218);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_218) = value;
			}
		}

		// Token: 0x17002AD5 RID: 10965
		// (get) Token: 0x0601E805 RID: 124933 RVA: 0x008F6B3D File Offset: 0x008F4D3D
		// (set) Token: 0x0601E806 RID: 124934 RVA: 0x008F6B4D File Offset: 0x008F4D4D
		public unsafe bool For_Mobile_Renderer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_219) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Sky_C.__PropertyOffset_219) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E807 RID: 124935 RVA: 0x008F6B5E File Offset: 0x008F4D5E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Sky_Mode_with_Scalability_Map()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Set_Sky_Mode_with_Scalability_Map_NativeFunctionPtr, null);
		}

		// Token: 0x0601E808 RID: 124936 RVA: 0x008F6B72 File Offset: 0x008F4D72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Get_Reference_to_Weather_BP()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Get_Reference_to_Weather_BP_NativeFunctionPtr, null);
		}

		// Token: 0x0601E809 RID: 124937 RVA: 0x008F6B86 File Offset: 0x008F4D86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Variables_Controlled_by_Weather()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Update_Variables_Controlled_by_Weather_NativeFunctionPtr, null);
		}

		// Token: 0x0601E80A RID: 124938 RVA: 0x008F6B9A File Offset: 0x008F4D9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Static_Variables()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Update_Static_Variables_NativeFunctionPtr, null);
		}

		// Token: 0x0601E80B RID: 124939 RVA: 0x008F6BB0 File Offset: 0x008F4DB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ConstructionScript_Function(bool Run_By_Counterpart)
		{
			Ultra_Dynamic_Sky_C.__ConstructionScript_Function_FunctionParams* ptr = stackalloc Ultra_Dynamic_Sky_C.__ConstructionScript_Function_FunctionParams[(UIntPtr)2943] + 15L / (long)sizeof(Ultra_Dynamic_Sky_C.__ConstructionScript_Function_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Sky_C.__ConstructionScript_Function_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Run_By_Counterpart = Run_By_Counterpart;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__ConstructionScript_Function_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E80C RID: 124940 RVA: 0x008F6BF9 File Offset: 0x008F4DF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Cloud_Timing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Set_Cloud_Timing_NativeFunctionPtr, null);
		}

		// Token: 0x0601E80D RID: 124941 RVA: 0x008F6C10 File Offset: 0x008F4E10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Time_of_Day_using_Time_Code(FTimecode Time_Code)
		{
			Ultra_Dynamic_Sky_C.__Set_Time_of_Day_using_Time_Code_FunctionParams* ptr = stackalloc Ultra_Dynamic_Sky_C.__Set_Time_of_Day_using_Time_Code_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(Ultra_Dynamic_Sky_C.__Set_Time_of_Day_using_Time_Code_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Sky_C.__Set_Time_of_Day_using_Time_Code_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time_Code = Time_Code;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Set_Time_of_Day_using_Time_Code_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E80E RID: 124942 RVA: 0x008F6C58 File Offset: 0x008F4E58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Time_of_Day_in_Real_Time_Format(ref FTimecode Time)
		{
			Ultra_Dynamic_Sky_C.__Get_Time_of_Day_in_Real_Time_Format_FunctionParams* ptr = stackalloc Ultra_Dynamic_Sky_C.__Get_Time_of_Day_in_Real_Time_Format_FunctionParams[(UIntPtr)99] + 15L / (long)sizeof(Ultra_Dynamic_Sky_C.__Get_Time_of_Day_in_Real_Time_Format_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Sky_C.__Get_Time_of_Day_in_Real_Time_Format_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Get_Time_of_Day_in_Real_Time_Format_NativeFunctionPtr, (void*)ptr);
			Time = ptr->Time;
		}

		// Token: 0x0601E80F RID: 124943 RVA: 0x008F6CAF File Offset: 0x008F4EAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Active_Variables()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Update_Active_Variables_NativeFunctionPtr, null);
		}

		// Token: 0x0601E810 RID: 124944 RVA: 0x008F6CC4 File Offset: 0x008F4EC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Sun_and_Moon_Rotation(bool Move_Static_Lights)
		{
			Ultra_Dynamic_Sky_C.__Set_Sun_and_Moon_Rotation_FunctionParams* ptr = stackalloc Ultra_Dynamic_Sky_C.__Set_Sun_and_Moon_Rotation_FunctionParams[(UIntPtr)991] + 15L / (long)sizeof(Ultra_Dynamic_Sky_C.__Set_Sun_and_Moon_Rotation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Sky_C.__Set_Sun_and_Moon_Rotation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Move_Static_Lights = Move_Static_Lights;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Set_Sun_and_Moon_Rotation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E811 RID: 124945 RVA: 0x008F6D0D File Offset: 0x008F4F0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E812 RID: 124946 RVA: 0x008F6D21 File Offset: 0x008F4F21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E813 RID: 124947 RVA: 0x008F6D38 File Offset: 0x008F4F38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			Ultra_Dynamic_Sky_C.__ReceiveTick_FunctionParams* ptr = stackalloc Ultra_Dynamic_Sky_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Ultra_Dynamic_Sky_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Sky_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E814 RID: 124948 RVA: 0x008F6D80 File Offset: 0x008F4F80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			Ultra_Dynamic_Sky_C.__ReceiveTick_FunctionParams* ptr = stackalloc Ultra_Dynamic_Sky_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Ultra_Dynamic_Sky_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Sky_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E815 RID: 124949 RVA: 0x008F6DC7 File Offset: 0x008F4FC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E816 RID: 124950 RVA: 0x008F6DDB File Offset: 0x008F4FDB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E817 RID: 124951 RVA: 0x008F6DF0 File Offset: 0x008F4FF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Midnight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__Midnight_NativeFunctionPtr, null);
		}

		// Token: 0x0601E818 RID: 124952 RVA: 0x008F6E04 File Offset: 0x008F5004
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Ultra_Dynamic_Sky(int EntryPoint)
		{
			Ultra_Dynamic_Sky_C.__ExecuteUbergraph_Ultra_Dynamic_Sky_FunctionParams* ptr = stackalloc Ultra_Dynamic_Sky_C.__ExecuteUbergraph_Ultra_Dynamic_Sky_FunctionParams[(UIntPtr)179] + 15L / (long)sizeof(Ultra_Dynamic_Sky_C.__ExecuteUbergraph_Ultra_Dynamic_Sky_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Sky_C.__ExecuteUbergraph_Ultra_Dynamic_Sky_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Sky_C.__ExecuteUbergraph_Ultra_Dynamic_Sky_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E819 RID: 124953 RVA: 0x008F6E4E File Offset: 0x008F504E
		protected Ultra_Dynamic_Sky_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EF4F RID: 61263
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Sky.Ultra_Dynamic_Sky_C";

		// Token: 0x0400EF50 RID: 61264
		private static IntPtr _ClassPtr;

		// Token: 0x0400EF51 RID: 61265
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EF52 RID: 61266
		public static IntPtr __Sunrise__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EF53 RID: 61267
		public static IntPtr __Sunset__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EF54 RID: 61268
		internal static int __PropertyOffset_0;

		// Token: 0x0400EF55 RID: 61269
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EF56 RID: 61270
		internal static int __PropertyOffset_1;

		// Token: 0x0400EF57 RID: 61271
		internal static int __PropertyOffset_2;

		// Token: 0x0400EF58 RID: 61272
		internal static int __PropertyOffset_3;

		// Token: 0x0400EF59 RID: 61273
		internal static int __PropertyOffset_4;

		// Token: 0x0400EF5A RID: 61274
		internal static int __PropertyOffset_5;

		// Token: 0x0400EF5B RID: 61275
		internal static int __PropertyOffset_6;

		// Token: 0x0400EF5C RID: 61276
		internal static int __PropertyOffset_7;

		// Token: 0x0400EF5D RID: 61277
		internal static int __PropertyOffset_8;

		// Token: 0x0400EF5E RID: 61278
		internal static int __PropertyOffset_9;

		// Token: 0x0400EF5F RID: 61279
		internal static int __PropertyOffset_10;

		// Token: 0x0400EF60 RID: 61280
		internal static int __PropertyOffset_11;

		// Token: 0x0400EF61 RID: 61281
		internal static int __PropertyOffset_12;

		// Token: 0x0400EF62 RID: 61282
		internal static int __PropertyOffset_13;

		// Token: 0x0400EF63 RID: 61283
		internal static int __PropertyOffset_14;

		// Token: 0x0400EF64 RID: 61284
		internal static int __PropertyOffset_15;

		// Token: 0x0400EF65 RID: 61285
		internal static int __PropertyOffset_16;

		// Token: 0x0400EF66 RID: 61286
		internal static int __PropertyOffset_17;

		// Token: 0x0400EF67 RID: 61287
		internal static int __PropertyOffset_18;

		// Token: 0x0400EF68 RID: 61288
		internal static int __PropertyOffset_19;

		// Token: 0x0400EF69 RID: 61289
		internal static int __PropertyOffset_20;

		// Token: 0x0400EF6A RID: 61290
		internal static int __PropertyOffset_21;

		// Token: 0x0400EF6B RID: 61291
		internal static int __PropertyOffset_22;

		// Token: 0x0400EF6C RID: 61292
		internal static int __PropertyOffset_23;

		// Token: 0x0400EF6D RID: 61293
		internal static int __PropertyOffset_24;

		// Token: 0x0400EF6E RID: 61294
		internal static int __PropertyOffset_25;

		// Token: 0x0400EF6F RID: 61295
		internal static int __PropertyOffset_26;

		// Token: 0x0400EF70 RID: 61296
		internal static int __PropertyOffset_27;

		// Token: 0x0400EF71 RID: 61297
		internal static int __PropertyOffset_28;

		// Token: 0x0400EF72 RID: 61298
		internal static int __PropertyOffset_29;

		// Token: 0x0400EF73 RID: 61299
		internal static int __PropertyOffset_30;

		// Token: 0x0400EF74 RID: 61300
		internal static int __PropertyOffset_31;

		// Token: 0x0400EF75 RID: 61301
		internal static int __PropertyOffset_32;

		// Token: 0x0400EF76 RID: 61302
		internal static int __PropertyOffset_33;

		// Token: 0x0400EF77 RID: 61303
		internal static int __PropertyOffset_34;

		// Token: 0x0400EF78 RID: 61304
		internal static int __PropertyOffset_35;

		// Token: 0x0400EF79 RID: 61305
		internal static int __PropertyOffset_36;

		// Token: 0x0400EF7A RID: 61306
		internal static int __PropertyOffset_37;

		// Token: 0x0400EF7B RID: 61307
		internal static int __PropertyOffset_38;

		// Token: 0x0400EF7C RID: 61308
		internal static int __PropertyOffset_39;

		// Token: 0x0400EF7D RID: 61309
		internal static int __PropertyOffset_40;

		// Token: 0x0400EF7E RID: 61310
		internal static int __PropertyOffset_41;

		// Token: 0x0400EF7F RID: 61311
		internal static int __PropertyOffset_42;

		// Token: 0x0400EF80 RID: 61312
		internal static int __PropertyOffset_43;

		// Token: 0x0400EF81 RID: 61313
		internal static int __PropertyOffset_44;

		// Token: 0x0400EF82 RID: 61314
		internal static int __PropertyOffset_45;

		// Token: 0x0400EF83 RID: 61315
		internal static int __PropertyOffset_46;

		// Token: 0x0400EF84 RID: 61316
		internal static int __PropertyOffset_47;

		// Token: 0x0400EF85 RID: 61317
		internal static int __PropertyOffset_48;

		// Token: 0x0400EF86 RID: 61318
		internal static int __PropertyOffset_49;

		// Token: 0x0400EF87 RID: 61319
		internal static int __PropertyOffset_50;

		// Token: 0x0400EF88 RID: 61320
		internal static int __PropertyOffset_51;

		// Token: 0x0400EF89 RID: 61321
		internal static int __PropertyOffset_52;

		// Token: 0x0400EF8A RID: 61322
		internal static int __PropertyOffset_53;

		// Token: 0x0400EF8B RID: 61323
		internal static int __PropertyOffset_54;

		// Token: 0x0400EF8C RID: 61324
		internal static int __PropertyOffset_55;

		// Token: 0x0400EF8D RID: 61325
		internal static int __PropertyOffset_56;

		// Token: 0x0400EF8E RID: 61326
		internal static int __PropertyOffset_57;

		// Token: 0x0400EF8F RID: 61327
		internal static int __PropertyOffset_58;

		// Token: 0x0400EF90 RID: 61328
		internal static int __PropertyOffset_59;

		// Token: 0x0400EF91 RID: 61329
		internal static int __PropertyOffset_60;

		// Token: 0x0400EF92 RID: 61330
		internal static int __PropertyOffset_61;

		// Token: 0x0400EF93 RID: 61331
		internal static int __PropertyOffset_62;

		// Token: 0x0400EF94 RID: 61332
		internal static int __PropertyOffset_63;

		// Token: 0x0400EF95 RID: 61333
		internal static int __PropertyOffset_64;

		// Token: 0x0400EF96 RID: 61334
		internal static int __PropertyOffset_65;

		// Token: 0x0400EF97 RID: 61335
		internal static int __PropertyOffset_66;

		// Token: 0x0400EF98 RID: 61336
		internal static int __PropertyOffset_67;

		// Token: 0x0400EF99 RID: 61337
		internal static int __PropertyOffset_68;

		// Token: 0x0400EF9A RID: 61338
		internal static int __PropertyOffset_69;

		// Token: 0x0400EF9B RID: 61339
		internal static int __PropertyOffset_70;

		// Token: 0x0400EF9C RID: 61340
		internal static int __PropertyOffset_71;

		// Token: 0x0400EF9D RID: 61341
		internal static int __PropertyOffset_72;

		// Token: 0x0400EF9E RID: 61342
		internal static int __PropertyOffset_73;

		// Token: 0x0400EF9F RID: 61343
		internal static int __PropertyOffset_74;

		// Token: 0x0400EFA0 RID: 61344
		internal static int __PropertyOffset_75;

		// Token: 0x0400EFA1 RID: 61345
		internal static int __PropertyOffset_76;

		// Token: 0x0400EFA2 RID: 61346
		internal static int __PropertyOffset_77;

		// Token: 0x0400EFA3 RID: 61347
		internal static int __PropertyOffset_78;

		// Token: 0x0400EFA4 RID: 61348
		internal static int __PropertyOffset_79;

		// Token: 0x0400EFA5 RID: 61349
		internal static int __PropertyOffset_80;

		// Token: 0x0400EFA6 RID: 61350
		internal static int __PropertyOffset_81;

		// Token: 0x0400EFA7 RID: 61351
		internal static int __PropertyOffset_82;

		// Token: 0x0400EFA8 RID: 61352
		internal static int __PropertyOffset_83;

		// Token: 0x0400EFA9 RID: 61353
		internal static int __PropertyOffset_84;

		// Token: 0x0400EFAA RID: 61354
		internal static int __PropertyOffset_85;

		// Token: 0x0400EFAB RID: 61355
		internal static int __PropertyOffset_86;

		// Token: 0x0400EFAC RID: 61356
		internal static int __PropertyOffset_87;

		// Token: 0x0400EFAD RID: 61357
		internal static int __PropertyOffset_88;

		// Token: 0x0400EFAE RID: 61358
		internal static int __PropertyOffset_89;

		// Token: 0x0400EFAF RID: 61359
		internal static int __PropertyOffset_90;

		// Token: 0x0400EFB0 RID: 61360
		internal static int __PropertyOffset_91;

		// Token: 0x0400EFB1 RID: 61361
		internal static int __PropertyOffset_92;

		// Token: 0x0400EFB2 RID: 61362
		internal static int __PropertyOffset_93;

		// Token: 0x0400EFB3 RID: 61363
		internal static int __PropertyOffset_94;

		// Token: 0x0400EFB4 RID: 61364
		internal static int __PropertyOffset_95;

		// Token: 0x0400EFB5 RID: 61365
		internal static int __PropertyOffset_96;

		// Token: 0x0400EFB6 RID: 61366
		internal static int __PropertyOffset_97;

		// Token: 0x0400EFB7 RID: 61367
		internal static int __PropertyOffset_98;

		// Token: 0x0400EFB8 RID: 61368
		internal static int __PropertyOffset_99;

		// Token: 0x0400EFB9 RID: 61369
		internal static int __PropertyOffset_100;

		// Token: 0x0400EFBA RID: 61370
		internal static int __PropertyOffset_101;

		// Token: 0x0400EFBB RID: 61371
		internal static int __PropertyOffset_102;

		// Token: 0x0400EFBC RID: 61372
		internal static int __PropertyOffset_103;

		// Token: 0x0400EFBD RID: 61373
		internal static int __PropertyOffset_104;

		// Token: 0x0400EFBE RID: 61374
		internal static int __PropertyOffset_105;

		// Token: 0x0400EFBF RID: 61375
		internal static int __PropertyOffset_106;

		// Token: 0x0400EFC0 RID: 61376
		internal static int __PropertyOffset_107;

		// Token: 0x0400EFC1 RID: 61377
		internal static int __PropertyOffset_108;

		// Token: 0x0400EFC2 RID: 61378
		internal static int __PropertyOffset_109;

		// Token: 0x0400EFC3 RID: 61379
		internal static int __PropertyOffset_110;

		// Token: 0x0400EFC4 RID: 61380
		internal static int __PropertyOffset_111;

		// Token: 0x0400EFC5 RID: 61381
		internal static int __PropertyOffset_112;

		// Token: 0x0400EFC6 RID: 61382
		internal static int __PropertyOffset_113;

		// Token: 0x0400EFC7 RID: 61383
		internal static int __PropertyOffset_114;

		// Token: 0x0400EFC8 RID: 61384
		internal static int __PropertyOffset_115;

		// Token: 0x0400EFC9 RID: 61385
		internal static int __PropertyOffset_116;

		// Token: 0x0400EFCA RID: 61386
		internal static int __PropertyOffset_117;

		// Token: 0x0400EFCB RID: 61387
		internal static int __PropertyOffset_118;

		// Token: 0x0400EFCC RID: 61388
		internal static int __PropertyOffset_119;

		// Token: 0x0400EFCD RID: 61389
		internal static int __PropertyOffset_120;

		// Token: 0x0400EFCE RID: 61390
		internal static int __PropertyOffset_121;

		// Token: 0x0400EFCF RID: 61391
		internal static int __PropertyOffset_122;

		// Token: 0x0400EFD0 RID: 61392
		internal static int __PropertyOffset_123;

		// Token: 0x0400EFD1 RID: 61393
		internal static int __PropertyOffset_124;

		// Token: 0x0400EFD2 RID: 61394
		internal static int __PropertyOffset_125;

		// Token: 0x0400EFD3 RID: 61395
		internal static int __PropertyOffset_126;

		// Token: 0x0400EFD4 RID: 61396
		internal static int __PropertyOffset_127;

		// Token: 0x0400EFD5 RID: 61397
		internal static int __PropertyOffset_128;

		// Token: 0x0400EFD6 RID: 61398
		internal static int __PropertyOffset_129;

		// Token: 0x0400EFD7 RID: 61399
		internal static int __PropertyOffset_130;

		// Token: 0x0400EFD8 RID: 61400
		internal static int __PropertyOffset_131;

		// Token: 0x0400EFD9 RID: 61401
		internal static int __PropertyOffset_132;

		// Token: 0x0400EFDA RID: 61402
		internal static int __PropertyOffset_133;

		// Token: 0x0400EFDB RID: 61403
		internal static int __PropertyOffset_134;

		// Token: 0x0400EFDC RID: 61404
		internal static int __PropertyOffset_135;

		// Token: 0x0400EFDD RID: 61405
		internal static int __PropertyOffset_136;

		// Token: 0x0400EFDE RID: 61406
		internal static int __PropertyOffset_137;

		// Token: 0x0400EFDF RID: 61407
		internal static int __PropertyOffset_138;

		// Token: 0x0400EFE0 RID: 61408
		internal static int __PropertyOffset_139;

		// Token: 0x0400EFE1 RID: 61409
		internal static int __PropertyOffset_140;

		// Token: 0x0400EFE2 RID: 61410
		internal static int __PropertyOffset_141;

		// Token: 0x0400EFE3 RID: 61411
		private Sunset _Sunset;

		// Token: 0x0400EFE4 RID: 61412
		internal static int __PropertyOffset_142;

		// Token: 0x0400EFE5 RID: 61413
		private Sunrise _Sunrise;

		// Token: 0x0400EFE6 RID: 61414
		internal static int __PropertyOffset_143;

		// Token: 0x0400EFE7 RID: 61415
		internal static int __PropertyOffset_144;

		// Token: 0x0400EFE8 RID: 61416
		internal static int __PropertyOffset_145;

		// Token: 0x0400EFE9 RID: 61417
		internal static int __PropertyOffset_146;

		// Token: 0x0400EFEA RID: 61418
		internal static int __PropertyOffset_147;

		// Token: 0x0400EFEB RID: 61419
		internal static int __PropertyOffset_148;

		// Token: 0x0400EFEC RID: 61420
		internal static int __PropertyOffset_149;

		// Token: 0x0400EFED RID: 61421
		internal static int __PropertyOffset_150;

		// Token: 0x0400EFEE RID: 61422
		internal static int __PropertyOffset_151;

		// Token: 0x0400EFEF RID: 61423
		internal static int __PropertyOffset_152;

		// Token: 0x0400EFF0 RID: 61424
		internal static int __PropertyOffset_153;

		// Token: 0x0400EFF1 RID: 61425
		internal static int __PropertyOffset_154;

		// Token: 0x0400EFF2 RID: 61426
		internal static int __PropertyOffset_155;

		// Token: 0x0400EFF3 RID: 61427
		internal static int __PropertyOffset_156;

		// Token: 0x0400EFF4 RID: 61428
		internal static int __PropertyOffset_157;

		// Token: 0x0400EFF5 RID: 61429
		internal static int __PropertyOffset_158;

		// Token: 0x0400EFF6 RID: 61430
		internal static int __PropertyOffset_159;

		// Token: 0x0400EFF7 RID: 61431
		internal static int __PropertyOffset_160;

		// Token: 0x0400EFF8 RID: 61432
		internal static int __PropertyOffset_161;

		// Token: 0x0400EFF9 RID: 61433
		internal static int __PropertyOffset_162;

		// Token: 0x0400EFFA RID: 61434
		internal static int __PropertyOffset_163;

		// Token: 0x0400EFFB RID: 61435
		internal static int __PropertyOffset_164;

		// Token: 0x0400EFFC RID: 61436
		internal static int __PropertyOffset_165;

		// Token: 0x0400EFFD RID: 61437
		internal static int __PropertyOffset_166;

		// Token: 0x0400EFFE RID: 61438
		internal static int __PropertyOffset_167;

		// Token: 0x0400EFFF RID: 61439
		internal static int __PropertyOffset_168;

		// Token: 0x0400F000 RID: 61440
		internal static int __PropertyOffset_169;

		// Token: 0x0400F001 RID: 61441
		internal static int __PropertyOffset_170;

		// Token: 0x0400F002 RID: 61442
		internal static int __PropertyOffset_171;

		// Token: 0x0400F003 RID: 61443
		internal static int __PropertyOffset_172;

		// Token: 0x0400F004 RID: 61444
		internal static int __PropertyOffset_173;

		// Token: 0x0400F005 RID: 61445
		internal static int __PropertyOffset_174;

		// Token: 0x0400F006 RID: 61446
		internal static int __PropertyOffset_175;

		// Token: 0x0400F007 RID: 61447
		internal static int __PropertyOffset_176;

		// Token: 0x0400F008 RID: 61448
		internal static int __PropertyOffset_177;

		// Token: 0x0400F009 RID: 61449
		internal static int __PropertyOffset_178;

		// Token: 0x0400F00A RID: 61450
		internal static int __PropertyOffset_179;

		// Token: 0x0400F00B RID: 61451
		internal static int __PropertyOffset_180;

		// Token: 0x0400F00C RID: 61452
		internal static int __PropertyOffset_181;

		// Token: 0x0400F00D RID: 61453
		internal static int __PropertyOffset_182;

		// Token: 0x0400F00E RID: 61454
		internal static int __PropertyOffset_183;

		// Token: 0x0400F00F RID: 61455
		internal static int __PropertyOffset_184;

		// Token: 0x0400F010 RID: 61456
		internal static int __PropertyOffset_185;

		// Token: 0x0400F011 RID: 61457
		internal static int __PropertyOffset_186;

		// Token: 0x0400F012 RID: 61458
		internal static int __PropertyOffset_187;

		// Token: 0x0400F013 RID: 61459
		internal static int __PropertyOffset_188;

		// Token: 0x0400F014 RID: 61460
		internal static int __PropertyOffset_189;

		// Token: 0x0400F015 RID: 61461
		internal static int __PropertyOffset_190;

		// Token: 0x0400F016 RID: 61462
		internal static int __PropertyOffset_191;

		// Token: 0x0400F017 RID: 61463
		internal static int __PropertyOffset_192;

		// Token: 0x0400F018 RID: 61464
		internal static int __PropertyOffset_193;

		// Token: 0x0400F019 RID: 61465
		internal static int __PropertyOffset_194;

		// Token: 0x0400F01A RID: 61466
		internal static int __PropertyOffset_195;

		// Token: 0x0400F01B RID: 61467
		internal static int __PropertyOffset_196;

		// Token: 0x0400F01C RID: 61468
		internal static int __PropertyOffset_197;

		// Token: 0x0400F01D RID: 61469
		internal static int __PropertyOffset_198;

		// Token: 0x0400F01E RID: 61470
		internal static int __PropertyOffset_199;

		// Token: 0x0400F01F RID: 61471
		internal static int __PropertyOffset_200;

		// Token: 0x0400F020 RID: 61472
		internal static int __PropertyOffset_201;

		// Token: 0x0400F021 RID: 61473
		internal static int __PropertyOffset_202;

		// Token: 0x0400F022 RID: 61474
		internal static int __PropertyOffset_203;

		// Token: 0x0400F023 RID: 61475
		internal static int __PropertyOffset_204;

		// Token: 0x0400F024 RID: 61476
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<int, TEnumAsByte<UDS_SkyMode>> _Sky_Mode_ScalabilityMap;

		// Token: 0x0400F025 RID: 61477
		internal static int __PropertyOffset_205;

		// Token: 0x0400F026 RID: 61478
		internal static int __PropertyOffset_206;

		// Token: 0x0400F027 RID: 61479
		internal static int __PropertyOffset_207;

		// Token: 0x0400F028 RID: 61480
		internal static int __PropertyOffset_208;

		// Token: 0x0400F029 RID: 61481
		internal static int __PropertyOffset_209;

		// Token: 0x0400F02A RID: 61482
		internal static int __PropertyOffset_210;

		// Token: 0x0400F02B RID: 61483
		internal static int __PropertyOffset_211;

		// Token: 0x0400F02C RID: 61484
		internal static int __PropertyOffset_212;

		// Token: 0x0400F02D RID: 61485
		internal static int __PropertyOffset_213;

		// Token: 0x0400F02E RID: 61486
		internal static int __PropertyOffset_214;

		// Token: 0x0400F02F RID: 61487
		internal static int __PropertyOffset_215;

		// Token: 0x0400F030 RID: 61488
		internal static int __PropertyOffset_216;

		// Token: 0x0400F031 RID: 61489
		internal static int __PropertyOffset_217;

		// Token: 0x0400F032 RID: 61490
		internal static int __PropertyOffset_218;

		// Token: 0x0400F033 RID: 61491
		internal static int __PropertyOffset_219;

		// Token: 0x0400F034 RID: 61492
		private static IntPtr __Set_Sky_Mode_with_Scalability_Map_NativeFunctionPtr;

		// Token: 0x0400F035 RID: 61493
		private static IntPtr __Get_Reference_to_Weather_BP_NativeFunctionPtr;

		// Token: 0x0400F036 RID: 61494
		private static IntPtr __Update_Variables_Controlled_by_Weather_NativeFunctionPtr;

		// Token: 0x0400F037 RID: 61495
		private static IntPtr __Update_Static_Variables_NativeFunctionPtr;

		// Token: 0x0400F038 RID: 61496
		private static IntPtr __ConstructionScript_Function_NativeFunctionPtr;

		// Token: 0x0400F039 RID: 61497
		private static IntPtr __Set_Cloud_Timing_NativeFunctionPtr;

		// Token: 0x0400F03A RID: 61498
		private static IntPtr __Set_Time_of_Day_using_Time_Code_NativeFunctionPtr;

		// Token: 0x0400F03B RID: 61499
		private static IntPtr __Get_Time_of_Day_in_Real_Time_Format_NativeFunctionPtr;

		// Token: 0x0400F03C RID: 61500
		private static IntPtr __Update_Active_Variables_NativeFunctionPtr;

		// Token: 0x0400F03D RID: 61501
		private static IntPtr __Set_Sun_and_Moon_Rotation_NativeFunctionPtr;

		// Token: 0x0400F03E RID: 61502
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F03F RID: 61503
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F040 RID: 61504
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F041 RID: 61505
		private static IntPtr __Midnight_NativeFunctionPtr;

		// Token: 0x0400F042 RID: 61506
		private static IntPtr __ExecuteUbergraph_Ultra_Dynamic_Sky_NativeFunctionPtr;

		// Token: 0x020097B4 RID: 38836
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2928)]
		protected ref struct __ConstructionScript_Function_FunctionParams
		{
			// Token: 0x04031D8D RID: 204173
			[FieldOffset(0)]
			public bool Run_By_Counterpart;
		}

		// Token: 0x020097B5 RID: 38837
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __Set_Time_of_Day_using_Time_Code_FunctionParams
		{
			// Token: 0x04031D8E RID: 204174
			[FieldOffset(0)]
			public FTimecode Time_Code;
		}

		// Token: 0x020097B6 RID: 38838
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 84)]
		protected ref struct __Get_Time_of_Day_in_Real_Time_Format_FunctionParams
		{
			// Token: 0x04031D8F RID: 204175
			[FieldOffset(0)]
			public FTimecode Time;
		}

		// Token: 0x020097B7 RID: 38839
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 976)]
		protected ref struct __Set_Sun_and_Moon_Rotation_FunctionParams
		{
			// Token: 0x04031D90 RID: 204176
			[FieldOffset(0)]
			public bool Move_Static_Lights;
		}

		// Token: 0x020097B8 RID: 38840
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D91 RID: 204177
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097B9 RID: 38841
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 164)]
		protected ref struct __ExecuteUbergraph_Ultra_Dynamic_Sky_FunctionParams
		{
			// Token: 0x04031D92 RID: 204178
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
