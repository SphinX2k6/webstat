using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.VolumetricConeLight
{
	// Token: 0x02003FA0 RID: 16288
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor.BP_VolumetricConeLightShaft_InMotor_C")]
	[UnrealStructLayout(2744, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2744)]
	public class BP_VolumetricConeLightShaft_InMotor_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028D4B RID: 167243 RVA: 0x00A18078 File Offset: 0x00A16278
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_InMotor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor.BP_VolumetricConeLightShaft_InMotor_C");
			}
			return BP_VolumetricConeLightShaft_InMotor_C._ClassPtr;
		}

		// Token: 0x06028D4C RID: 167244 RVA: 0x00A1809C File Offset: 0x00A1629C
		public BP_VolumetricConeLightShaft_InMotor_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028D4D RID: 167245 RVA: 0x00A180C4 File Offset: 0x00A162C4
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_InMotor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InMotor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700644E RID: 25678
		// (get) Token: 0x06028D4E RID: 167246 RVA: 0x00A180F8 File Offset: 0x00A162F8
		// (set) Token: 0x06028D4F RID: 167247 RVA: 0x00A18131 File Offset: 0x00A16331
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700644F RID: 25679
		// (get) Token: 0x06028D50 RID: 167248 RVA: 0x00A18152 File Offset: 0x00A16352
		// (set) Token: 0x06028D51 RID: 167249 RVA: 0x00A18166 File Offset: 0x00A16366
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006450 RID: 25680
		// (get) Token: 0x06028D52 RID: 167250 RVA: 0x00A1817B File Offset: 0x00A1637B
		// (set) Token: 0x06028D53 RID: 167251 RVA: 0x00A1818F File Offset: 0x00A1638F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17006451 RID: 25681
		// (get) Token: 0x06028D54 RID: 167252 RVA: 0x00A181A4 File Offset: 0x00A163A4
		// (set) Token: 0x06028D55 RID: 167253 RVA: 0x00A181B8 File Offset: 0x00A163B8
		public unsafe UStaticMesh StaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17006452 RID: 25682
		// (get) Token: 0x06028D56 RID: 167254 RVA: 0x00A181CD File Offset: 0x00A163CD
		// (set) Token: 0x06028D57 RID: 167255 RVA: 0x00A181E1 File Offset: 0x00A163E1
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17006453 RID: 25683
		// (get) Token: 0x06028D58 RID: 167256 RVA: 0x00A181F6 File Offset: 0x00A163F6
		// (set) Token: 0x06028D59 RID: 167257 RVA: 0x00A1820A File Offset: 0x00A1640A
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17006454 RID: 25684
		// (get) Token: 0x06028D5A RID: 167258 RVA: 0x00A1821F File Offset: 0x00A1641F
		// (set) Token: 0x06028D5B RID: 167259 RVA: 0x00A18233 File Offset: 0x00A16433
		public unsafe FVector VolumetriConeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006455 RID: 25685
		// (get) Token: 0x06028D5C RID: 167260 RVA: 0x00A18248 File Offset: 0x00A16448
		// (set) Token: 0x06028D5D RID: 167261 RVA: 0x00A18258 File Offset: 0x00A16458
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006456 RID: 25686
		// (get) Token: 0x06028D5E RID: 167262 RVA: 0x00A18269 File Offset: 0x00A16469
		// (set) Token: 0x06028D5F RID: 167263 RVA: 0x00A18279 File Offset: 0x00A16479
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006457 RID: 25687
		// (get) Token: 0x06028D60 RID: 167264 RVA: 0x00A1828A File Offset: 0x00A1648A
		// (set) Token: 0x06028D61 RID: 167265 RVA: 0x00A1829A File Offset: 0x00A1649A
		public unsafe bool EnableFlickent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006458 RID: 25688
		// (get) Token: 0x06028D62 RID: 167266 RVA: 0x00A182AB File Offset: 0x00A164AB
		// (set) Token: 0x06028D63 RID: 167267 RVA: 0x00A182BB File Offset: 0x00A164BB
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006459 RID: 25689
		// (get) Token: 0x06028D64 RID: 167268 RVA: 0x00A182CC File Offset: 0x00A164CC
		// (set) Token: 0x06028D65 RID: 167269 RVA: 0x00A182DC File Offset: 0x00A164DC
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700645A RID: 25690
		// (get) Token: 0x06028D66 RID: 167270 RVA: 0x00A182ED File Offset: 0x00A164ED
		// (set) Token: 0x06028D67 RID: 167271 RVA: 0x00A182FD File Offset: 0x00A164FD
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700645B RID: 25691
		// (get) Token: 0x06028D68 RID: 167272 RVA: 0x00A1830E File Offset: 0x00A1650E
		// (set) Token: 0x06028D69 RID: 167273 RVA: 0x00A1831E File Offset: 0x00A1651E
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700645C RID: 25692
		// (get) Token: 0x06028D6A RID: 167274 RVA: 0x00A1832F File Offset: 0x00A1652F
		// (set) Token: 0x06028D6B RID: 167275 RVA: 0x00A18343 File Offset: 0x00A16543
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700645D RID: 25693
		// (get) Token: 0x06028D6C RID: 167276 RVA: 0x00A18358 File Offset: 0x00A16558
		// (set) Token: 0x06028D6D RID: 167277 RVA: 0x00A1836C File Offset: 0x00A1656C
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700645E RID: 25694
		// (get) Token: 0x06028D6E RID: 167278 RVA: 0x00A18381 File Offset: 0x00A16581
		// (set) Token: 0x06028D6F RID: 167279 RVA: 0x00A18391 File Offset: 0x00A16591
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700645F RID: 25695
		// (get) Token: 0x06028D70 RID: 167280 RVA: 0x00A183A2 File Offset: 0x00A165A2
		// (set) Token: 0x06028D71 RID: 167281 RVA: 0x00A183B2 File Offset: 0x00A165B2
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006460 RID: 25696
		// (get) Token: 0x06028D72 RID: 167282 RVA: 0x00A183C3 File Offset: 0x00A165C3
		// (set) Token: 0x06028D73 RID: 167283 RVA: 0x00A183D3 File Offset: 0x00A165D3
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17006461 RID: 25697
		// (get) Token: 0x06028D74 RID: 167284 RVA: 0x00A183E4 File Offset: 0x00A165E4
		// (set) Token: 0x06028D75 RID: 167285 RVA: 0x00A183F4 File Offset: 0x00A165F4
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17006462 RID: 25698
		// (get) Token: 0x06028D76 RID: 167286 RVA: 0x00A18405 File Offset: 0x00A16605
		// (set) Token: 0x06028D77 RID: 167287 RVA: 0x00A18415 File Offset: 0x00A16615
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17006463 RID: 25699
		// (get) Token: 0x06028D78 RID: 167288 RVA: 0x00A18426 File Offset: 0x00A16626
		// (set) Token: 0x06028D79 RID: 167289 RVA: 0x00A18436 File Offset: 0x00A16636
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17006464 RID: 25700
		// (get) Token: 0x06028D7A RID: 167290 RVA: 0x00A18447 File Offset: 0x00A16647
		// (set) Token: 0x06028D7B RID: 167291 RVA: 0x00A1845B File Offset: 0x00A1665B
		public unsafe FVector LightShaftScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17006465 RID: 25701
		// (get) Token: 0x06028D7C RID: 167292 RVA: 0x00A18470 File Offset: 0x00A16670
		// (set) Token: 0x06028D7D RID: 167293 RVA: 0x00A18484 File Offset: 0x00A16684
		public unsafe UStaticMesh LightShaftStaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17006466 RID: 25702
		// (get) Token: 0x06028D7E RID: 167294 RVA: 0x00A18499 File Offset: 0x00A16699
		// (set) Token: 0x06028D7F RID: 167295 RVA: 0x00A184AD File Offset: 0x00A166AD
		public unsafe UMaterialInstance LightShaftCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17006467 RID: 25703
		// (get) Token: 0x06028D80 RID: 167296 RVA: 0x00A184C2 File Offset: 0x00A166C2
		// (set) Token: 0x06028D81 RID: 167297 RVA: 0x00A184D6 File Offset: 0x00A166D6
		public unsafe UTexture2D Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17006468 RID: 25704
		// (get) Token: 0x06028D82 RID: 167298 RVA: 0x00A184EB File Offset: 0x00A166EB
		// (set) Token: 0x06028D83 RID: 167299 RVA: 0x00A184FF File Offset: 0x00A166FF
		public unsafe FLinearColor FallOff_ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17006469 RID: 25705
		// (get) Token: 0x06028D84 RID: 167300 RVA: 0x00A18514 File Offset: 0x00A16714
		// (set) Token: 0x06028D85 RID: 167301 RVA: 0x00A18524 File Offset: 0x00A16724
		public unsafe float FallOff_DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700646A RID: 25706
		// (get) Token: 0x06028D86 RID: 167302 RVA: 0x00A18535 File Offset: 0x00A16735
		// (set) Token: 0x06028D87 RID: 167303 RVA: 0x00A18545 File Offset: 0x00A16745
		public unsafe float ScreenFadeFrom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700646B RID: 25707
		// (get) Token: 0x06028D88 RID: 167304 RVA: 0x00A18556 File Offset: 0x00A16756
		// (set) Token: 0x06028D89 RID: 167305 RVA: 0x00A18566 File Offset: 0x00A16766
		public unsafe float Opacity_CenterPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700646C RID: 25708
		// (get) Token: 0x06028D8A RID: 167306 RVA: 0x00A18577 File Offset: 0x00A16777
		// (set) Token: 0x06028D8B RID: 167307 RVA: 0x00A18587 File Offset: 0x00A16787
		public unsafe float ScreenFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700646D RID: 25709
		// (get) Token: 0x06028D8C RID: 167308 RVA: 0x00A18598 File Offset: 0x00A16798
		// (set) Token: 0x06028D8D RID: 167309 RVA: 0x00A185A8 File Offset: 0x00A167A8
		public unsafe float ShaftTopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700646E RID: 25710
		// (get) Token: 0x06028D8E RID: 167310 RVA: 0x00A185B9 File Offset: 0x00A167B9
		// (set) Token: 0x06028D8F RID: 167311 RVA: 0x00A185CD File Offset: 0x00A167CD
		public unsafe FLinearColor UVScaleAndAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700646F RID: 25711
		// (get) Token: 0x06028D90 RID: 167312 RVA: 0x00A185E2 File Offset: 0x00A167E2
		// (set) Token: 0x06028D91 RID: 167313 RVA: 0x00A185F6 File Offset: 0x00A167F6
		public unsafe UStaticMesh LightMaskStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17006470 RID: 25712
		// (get) Token: 0x06028D92 RID: 167314 RVA: 0x00A1860B File Offset: 0x00A1680B
		// (set) Token: 0x06028D93 RID: 167315 RVA: 0x00A1861B File Offset: 0x00A1681B
		public unsafe float LightMaskZaxis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17006471 RID: 25713
		// (get) Token: 0x06028D94 RID: 167316 RVA: 0x00A1862C File Offset: 0x00A1682C
		// (set) Token: 0x06028D95 RID: 167317 RVA: 0x00A18640 File Offset: 0x00A16840
		public unsafe UMaterialInstance LightMaskMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17006472 RID: 25714
		// (get) Token: 0x06028D96 RID: 167318 RVA: 0x00A18655 File Offset: 0x00A16855
		// (set) Token: 0x06028D97 RID: 167319 RVA: 0x00A18669 File Offset: 0x00A16869
		public unsafe FVector LightMaskScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17006473 RID: 25715
		// (get) Token: 0x06028D98 RID: 167320 RVA: 0x00A1867E File Offset: 0x00A1687E
		// (set) Token: 0x06028D99 RID: 167321 RVA: 0x00A18692 File Offset: 0x00A16892
		public unsafe FLinearColor LightMaskColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17006474 RID: 25716
		// (get) Token: 0x06028D9A RID: 167322 RVA: 0x00A186A7 File Offset: 0x00A168A7
		// (set) Token: 0x06028D9B RID: 167323 RVA: 0x00A186BB File Offset: 0x00A168BB
		public unsafe UTexture2D LightMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17006475 RID: 25717
		// (get) Token: 0x06028D9C RID: 167324 RVA: 0x00A186D0 File Offset: 0x00A168D0
		// (set) Token: 0x06028D9D RID: 167325 RVA: 0x00A186E0 File Offset: 0x00A168E0
		public unsafe float ColorIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17006476 RID: 25718
		// (get) Token: 0x06028D9E RID: 167326 RVA: 0x00A186F1 File Offset: 0x00A168F1
		// (set) Token: 0x06028D9F RID: 167327 RVA: 0x00A18701 File Offset: 0x00A16901
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17006477 RID: 25719
		// (get) Token: 0x06028DA0 RID: 167328 RVA: 0x00A18712 File Offset: 0x00A16912
		// (set) Token: 0x06028DA1 RID: 167329 RVA: 0x00A18722 File Offset: 0x00A16922
		public unsafe float FadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17006478 RID: 25720
		// (get) Token: 0x06028DA2 RID: 167330 RVA: 0x00A18733 File Offset: 0x00A16933
		// (set) Token: 0x06028DA3 RID: 167331 RVA: 0x00A18743 File Offset: 0x00A16943
		public unsafe float FlankInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17006479 RID: 25721
		// (get) Token: 0x06028DA4 RID: 167332 RVA: 0x00A18754 File Offset: 0x00A16954
		// (set) Token: 0x06028DA5 RID: 167333 RVA: 0x00A18764 File Offset: 0x00A16964
		public unsafe float Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x1700647A RID: 25722
		// (get) Token: 0x06028DA6 RID: 167334 RVA: 0x00A18775 File Offset: 0x00A16975
		// (set) Token: 0x06028DA7 RID: 167335 RVA: 0x00A18785 File Offset: 0x00A16985
		public unsafe float RightSideInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x1700647B RID: 25723
		// (get) Token: 0x06028DA8 RID: 167336 RVA: 0x00A18796 File Offset: 0x00A16996
		// (set) Token: 0x06028DA9 RID: 167337 RVA: 0x00A187AA File Offset: 0x00A169AA
		public unsafe FVector CenterLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x1700647C RID: 25724
		// (get) Token: 0x06028DAA RID: 167338 RVA: 0x00A187BF File Offset: 0x00A169BF
		// (set) Token: 0x06028DAB RID: 167339 RVA: 0x00A187D3 File Offset: 0x00A169D3
		public unsafe UTexture MainNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x1700647D RID: 25725
		// (get) Token: 0x06028DAC RID: 167340 RVA: 0x00A187E8 File Offset: 0x00A169E8
		// (set) Token: 0x06028DAD RID: 167341 RVA: 0x00A187FC File Offset: 0x00A169FC
		public unsafe UTexture SecondNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x1700647E RID: 25726
		// (get) Token: 0x06028DAE RID: 167342 RVA: 0x00A18811 File Offset: 0x00A16A11
		// (set) Token: 0x06028DAF RID: 167343 RVA: 0x00A18825 File Offset: 0x00A16A25
		public unsafe FLinearColor MainNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x1700647F RID: 25727
		// (get) Token: 0x06028DB0 RID: 167344 RVA: 0x00A1883A File Offset: 0x00A16A3A
		// (set) Token: 0x06028DB1 RID: 167345 RVA: 0x00A1884E File Offset: 0x00A16A4E
		public unsafe FLinearColor SecondNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17006480 RID: 25728
		// (get) Token: 0x06028DB2 RID: 167346 RVA: 0x00A18863 File Offset: 0x00A16A63
		// (set) Token: 0x06028DB3 RID: 167347 RVA: 0x00A18873 File Offset: 0x00A16A73
		public unsafe float MainUVAddStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17006481 RID: 25729
		// (get) Token: 0x06028DB4 RID: 167348 RVA: 0x00A18884 File Offset: 0x00A16A84
		// (set) Token: 0x06028DB5 RID: 167349 RVA: 0x00A18898 File Offset: 0x00A16A98
		public unsafe FLinearColor MainNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17006482 RID: 25730
		// (get) Token: 0x06028DB6 RID: 167350 RVA: 0x00A188AD File Offset: 0x00A16AAD
		// (set) Token: 0x06028DB7 RID: 167351 RVA: 0x00A188C1 File Offset: 0x00A16AC1
		public unsafe FLinearColor SecondNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17006483 RID: 25731
		// (get) Token: 0x06028DB8 RID: 167352 RVA: 0x00A188D8 File Offset: 0x00A16AD8
		// (set) Token: 0x06028DB9 RID: 167353 RVA: 0x00A18911 File Offset: 0x00A16B11
		[Nullable(1)]
		public TMap<FName, float> MaterialInstanceB_Scalars
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._MaterialInstanceB_Scalars) == null)
				{
					result = (this._MaterialInstanceB_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_53, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceB_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x17006484 RID: 25732
		// (get) Token: 0x06028DBA RID: 167354 RVA: 0x00A18920 File Offset: 0x00A16B20
		// (set) Token: 0x06028DBB RID: 167355 RVA: 0x00A18959 File Offset: 0x00A16B59
		[Nullable(1)]
		public TMap<FName, FLinearColor> MaterialInstanceB_Vectors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._MaterialInstanceB_Vectors) == null)
				{
					result = (this._MaterialInstanceB_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_54, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceB_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x17006485 RID: 25733
		// (get) Token: 0x06028DBC RID: 167356 RVA: 0x00A18968 File Offset: 0x00A16B68
		// (set) Token: 0x06028DBD RID: 167357 RVA: 0x00A189A1 File Offset: 0x00A16BA1
		[Nullable(1)]
		public TMap<FName, UTexture> MaterialInstanceB_Textures
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._MaterialInstanceB_Textures) == null)
				{
					result = (this._MaterialInstanceB_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_55, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceB_Textures.CopyAssign(value);
			}
		}

		// Token: 0x17006486 RID: 25734
		// (get) Token: 0x06028DBE RID: 167358 RVA: 0x00A189B0 File Offset: 0x00A16BB0
		// (set) Token: 0x06028DBF RID: 167359 RVA: 0x00A189E9 File Offset: 0x00A16BE9
		[Nullable(1)]
		public TMap<FName, float> MaterialInstance_Scalars
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._MaterialInstance_Scalars) == null)
				{
					result = (this._MaterialInstance_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_56, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstance_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x17006487 RID: 25735
		// (get) Token: 0x06028DC0 RID: 167360 RVA: 0x00A189F8 File Offset: 0x00A16BF8
		// (set) Token: 0x06028DC1 RID: 167361 RVA: 0x00A18A31 File Offset: 0x00A16C31
		[Nullable(1)]
		public TMap<FName, FLinearColor> MaterialInstance_Vectors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._MaterialInstance_Vectors) == null)
				{
					result = (this._MaterialInstance_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_57, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstance_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x17006488 RID: 25736
		// (get) Token: 0x06028DC2 RID: 167362 RVA: 0x00A18A40 File Offset: 0x00A16C40
		// (set) Token: 0x06028DC3 RID: 167363 RVA: 0x00A18A79 File Offset: 0x00A16C79
		[Nullable(1)]
		public TMap<FName, UTexture> MaterialInstance_Textures
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._MaterialInstance_Textures) == null)
				{
					result = (this._MaterialInstance_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_58, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstance_Textures.CopyAssign(value);
			}
		}

		// Token: 0x17006489 RID: 25737
		// (get) Token: 0x06028DC4 RID: 167364 RVA: 0x00A18A88 File Offset: 0x00A16C88
		// (set) Token: 0x06028DC5 RID: 167365 RVA: 0x00A18AC1 File Offset: 0x00A16CC1
		[Nullable(1)]
		public TMap<FName, float> LightShaftCone_Scalars
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._LightShaftCone_Scalars) == null)
				{
					result = (this._LightShaftCone_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_59, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x1700648A RID: 25738
		// (get) Token: 0x06028DC6 RID: 167366 RVA: 0x00A18AD0 File Offset: 0x00A16CD0
		// (set) Token: 0x06028DC7 RID: 167367 RVA: 0x00A18B09 File Offset: 0x00A16D09
		[Nullable(1)]
		public TMap<FName, FLinearColor> LightShaftCone_Vectors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._LightShaftCone_Vectors) == null)
				{
					result = (this._LightShaftCone_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_60, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x1700648B RID: 25739
		// (get) Token: 0x06028DC8 RID: 167368 RVA: 0x00A18B18 File Offset: 0x00A16D18
		// (set) Token: 0x06028DC9 RID: 167369 RVA: 0x00A18B51 File Offset: 0x00A16D51
		[Nullable(1)]
		public TMap<FName, UTexture> LightShaftCone_Textures
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._LightShaftCone_Textures) == null)
				{
					result = (this._LightShaftCone_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_61, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Textures.CopyAssign(value);
			}
		}

		// Token: 0x1700648C RID: 25740
		// (get) Token: 0x06028DCA RID: 167370 RVA: 0x00A18B60 File Offset: 0x00A16D60
		// (set) Token: 0x06028DCB RID: 167371 RVA: 0x00A18B99 File Offset: 0x00A16D99
		[Nullable(1)]
		public TMap<FName, float> LightMaskMaterial_Scalars
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._LightMaskMaterial_Scalars) == null)
				{
					result = (this._LightMaskMaterial_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_62, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightMaskMaterial_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x1700648D RID: 25741
		// (get) Token: 0x06028DCC RID: 167372 RVA: 0x00A18BA8 File Offset: 0x00A16DA8
		// (set) Token: 0x06028DCD RID: 167373 RVA: 0x00A18BE1 File Offset: 0x00A16DE1
		[Nullable(1)]
		public TMap<FName, FLinearColor> LightMaskMaterial_Vectors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._LightMaskMaterial_Vectors) == null)
				{
					result = (this._LightMaskMaterial_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_63, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightMaskMaterial_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x1700648E RID: 25742
		// (get) Token: 0x06028DCE RID: 167374 RVA: 0x00A18BF0 File Offset: 0x00A16DF0
		// (set) Token: 0x06028DCF RID: 167375 RVA: 0x00A18C29 File Offset: 0x00A16E29
		[Nullable(1)]
		public TMap<FName, UTexture> LightMaskMaterial_Textures
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._LightMaskMaterial_Textures) == null)
				{
					result = (this._LightMaskMaterial_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_64, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightMaskMaterial_Textures.CopyAssign(value);
			}
		}

		// Token: 0x1700648F RID: 25743
		// (get) Token: 0x06028DD0 RID: 167376 RVA: 0x00A18C37 File Offset: 0x00A16E37
		// (set) Token: 0x06028DD1 RID: 167377 RVA: 0x00A18C4B File Offset: 0x00A16E4B
		public unsafe UMaterialInstanceDynamic MaterialInstanceBDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17006490 RID: 25744
		// (get) Token: 0x06028DD2 RID: 167378 RVA: 0x00A18C60 File Offset: 0x00A16E60
		// (set) Token: 0x06028DD3 RID: 167379 RVA: 0x00A18C74 File Offset: 0x00A16E74
		public unsafe UMaterialInstanceDynamic MaterialInstanceDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_66);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_66, value);
			}
		}

		// Token: 0x17006491 RID: 25745
		// (get) Token: 0x06028DD4 RID: 167380 RVA: 0x00A18C89 File Offset: 0x00A16E89
		// (set) Token: 0x06028DD5 RID: 167381 RVA: 0x00A18C9D File Offset: 0x00A16E9D
		public unsafe UMaterialInstanceDynamic LightShaftConeDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_67);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_67, value);
			}
		}

		// Token: 0x17006492 RID: 25746
		// (get) Token: 0x06028DD6 RID: 167382 RVA: 0x00A18CB2 File Offset: 0x00A16EB2
		// (set) Token: 0x06028DD7 RID: 167383 RVA: 0x00A18CC6 File Offset: 0x00A16EC6
		public unsafe UMaterialInstanceDynamic LightMaskMaterialDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_68);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_68, value);
			}
		}

		// Token: 0x17006493 RID: 25747
		// (get) Token: 0x06028DD8 RID: 167384 RVA: 0x00A18CDB File Offset: 0x00A16EDB
		// (set) Token: 0x06028DD9 RID: 167385 RVA: 0x00A18CEB File Offset: 0x00A16EEB
		public unsafe bool IsTickUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_69) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_69) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006494 RID: 25748
		// (get) Token: 0x06028DDA RID: 167386 RVA: 0x00A18CFC File Offset: 0x00A16EFC
		// (set) Token: 0x06028DDB RID: 167387 RVA: 0x00A18D0C File Offset: 0x00A16F0C
		public unsafe bool OptimizeForMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_70) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_70) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006495 RID: 25749
		// (get) Token: 0x06028DDC RID: 167388 RVA: 0x00A18D1D File Offset: 0x00A16F1D
		// (set) Token: 0x06028DDD RID: 167389 RVA: 0x00A18D31 File Offset: 0x00A16F31
		public unsafe UStaticMeshComponent VolumetricCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_71);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InMotor_C.__PropertyOffset_71, value);
			}
		}

		// Token: 0x06028DDE RID: 167390 RVA: 0x00A18D46 File Offset: 0x00A16F46
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x06028DDF RID: 167391 RVA: 0x00A18D5A File Offset: 0x00A16F5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06028DE0 RID: 167392 RVA: 0x00A18D6E File Offset: 0x00A16F6E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028DE1 RID: 167393 RVA: 0x00A18D83 File Offset: 0x00A16F83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028DE2 RID: 167394 RVA: 0x00A18D97 File Offset: 0x00A16F97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028DE3 RID: 167395 RVA: 0x00A18DAC File Offset: 0x00A16FAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028DE4 RID: 167396 RVA: 0x00A18DF4 File Offset: 0x00A16FF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028DE5 RID: 167397 RVA: 0x00A18E3C File Offset: 0x00A1703C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028DE6 RID: 167398 RVA: 0x00A18E84 File Offset: 0x00A17084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028DE7 RID: 167399 RVA: 0x00A18ECB File Offset: 0x00A170CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnGameUserSettingsChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__OnGameUserSettingsChange_NativeFunctionPtr, null);
		}

		// Token: 0x06028DE8 RID: 167400 RVA: 0x00A18EE0 File Offset: 0x00A170E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028DE9 RID: 167401 RVA: 0x00A18F2C File Offset: 0x00A1712C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028DEA RID: 167402 RVA: 0x00A18F78 File Offset: 0x00A17178
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor(int EntryPoint)
		{
			BP_VolumetricConeLightShaft_InMotor_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InMotor_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InMotor_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InMotor_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InMotor_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028DEB RID: 167403 RVA: 0x00A18FBF File Offset: 0x00A171BF
		protected BP_VolumetricConeLightShaft_InMotor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015960 RID: 88416
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/VolumetricConeLight/BP_VolumetricConeLightShaft_InMotor.BP_VolumetricConeLightShaft_InMotor_C";

		// Token: 0x04015961 RID: 88417
		private static IntPtr _ClassPtr;

		// Token: 0x04015962 RID: 88418
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015963 RID: 88419
		internal static int __PropertyOffset_0;

		// Token: 0x04015964 RID: 88420
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015965 RID: 88421
		internal static int __PropertyOffset_1;

		// Token: 0x04015966 RID: 88422
		internal static int __PropertyOffset_2;

		// Token: 0x04015967 RID: 88423
		internal static int __PropertyOffset_3;

		// Token: 0x04015968 RID: 88424
		internal static int __PropertyOffset_4;

		// Token: 0x04015969 RID: 88425
		internal static int __PropertyOffset_5;

		// Token: 0x0401596A RID: 88426
		internal static int __PropertyOffset_6;

		// Token: 0x0401596B RID: 88427
		internal static int __PropertyOffset_7;

		// Token: 0x0401596C RID: 88428
		internal static int __PropertyOffset_8;

		// Token: 0x0401596D RID: 88429
		internal static int __PropertyOffset_9;

		// Token: 0x0401596E RID: 88430
		internal static int __PropertyOffset_10;

		// Token: 0x0401596F RID: 88431
		internal static int __PropertyOffset_11;

		// Token: 0x04015970 RID: 88432
		internal static int __PropertyOffset_12;

		// Token: 0x04015971 RID: 88433
		internal static int __PropertyOffset_13;

		// Token: 0x04015972 RID: 88434
		internal static int __PropertyOffset_14;

		// Token: 0x04015973 RID: 88435
		internal static int __PropertyOffset_15;

		// Token: 0x04015974 RID: 88436
		internal static int __PropertyOffset_16;

		// Token: 0x04015975 RID: 88437
		internal static int __PropertyOffset_17;

		// Token: 0x04015976 RID: 88438
		internal static int __PropertyOffset_18;

		// Token: 0x04015977 RID: 88439
		internal static int __PropertyOffset_19;

		// Token: 0x04015978 RID: 88440
		internal static int __PropertyOffset_20;

		// Token: 0x04015979 RID: 88441
		internal static int __PropertyOffset_21;

		// Token: 0x0401597A RID: 88442
		internal static int __PropertyOffset_22;

		// Token: 0x0401597B RID: 88443
		internal static int __PropertyOffset_23;

		// Token: 0x0401597C RID: 88444
		internal static int __PropertyOffset_24;

		// Token: 0x0401597D RID: 88445
		internal static int __PropertyOffset_25;

		// Token: 0x0401597E RID: 88446
		internal static int __PropertyOffset_26;

		// Token: 0x0401597F RID: 88447
		internal static int __PropertyOffset_27;

		// Token: 0x04015980 RID: 88448
		internal static int __PropertyOffset_28;

		// Token: 0x04015981 RID: 88449
		internal static int __PropertyOffset_29;

		// Token: 0x04015982 RID: 88450
		internal static int __PropertyOffset_30;

		// Token: 0x04015983 RID: 88451
		internal static int __PropertyOffset_31;

		// Token: 0x04015984 RID: 88452
		internal static int __PropertyOffset_32;

		// Token: 0x04015985 RID: 88453
		internal static int __PropertyOffset_33;

		// Token: 0x04015986 RID: 88454
		internal static int __PropertyOffset_34;

		// Token: 0x04015987 RID: 88455
		internal static int __PropertyOffset_35;

		// Token: 0x04015988 RID: 88456
		internal static int __PropertyOffset_36;

		// Token: 0x04015989 RID: 88457
		internal static int __PropertyOffset_37;

		// Token: 0x0401598A RID: 88458
		internal static int __PropertyOffset_38;

		// Token: 0x0401598B RID: 88459
		internal static int __PropertyOffset_39;

		// Token: 0x0401598C RID: 88460
		internal static int __PropertyOffset_40;

		// Token: 0x0401598D RID: 88461
		internal static int __PropertyOffset_41;

		// Token: 0x0401598E RID: 88462
		internal static int __PropertyOffset_42;

		// Token: 0x0401598F RID: 88463
		internal static int __PropertyOffset_43;

		// Token: 0x04015990 RID: 88464
		internal static int __PropertyOffset_44;

		// Token: 0x04015991 RID: 88465
		internal static int __PropertyOffset_45;

		// Token: 0x04015992 RID: 88466
		internal static int __PropertyOffset_46;

		// Token: 0x04015993 RID: 88467
		internal static int __PropertyOffset_47;

		// Token: 0x04015994 RID: 88468
		internal static int __PropertyOffset_48;

		// Token: 0x04015995 RID: 88469
		internal static int __PropertyOffset_49;

		// Token: 0x04015996 RID: 88470
		internal static int __PropertyOffset_50;

		// Token: 0x04015997 RID: 88471
		internal static int __PropertyOffset_51;

		// Token: 0x04015998 RID: 88472
		internal static int __PropertyOffset_52;

		// Token: 0x04015999 RID: 88473
		internal static int __PropertyOffset_53;

		// Token: 0x0401599A RID: 88474
		private TMap<FName, float> _MaterialInstanceB_Scalars;

		// Token: 0x0401599B RID: 88475
		internal static int __PropertyOffset_54;

		// Token: 0x0401599C RID: 88476
		private TMap<FName, FLinearColor> _MaterialInstanceB_Vectors;

		// Token: 0x0401599D RID: 88477
		internal static int __PropertyOffset_55;

		// Token: 0x0401599E RID: 88478
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _MaterialInstanceB_Textures;

		// Token: 0x0401599F RID: 88479
		internal static int __PropertyOffset_56;

		// Token: 0x040159A0 RID: 88480
		private TMap<FName, float> _MaterialInstance_Scalars;

		// Token: 0x040159A1 RID: 88481
		internal static int __PropertyOffset_57;

		// Token: 0x040159A2 RID: 88482
		private TMap<FName, FLinearColor> _MaterialInstance_Vectors;

		// Token: 0x040159A3 RID: 88483
		internal static int __PropertyOffset_58;

		// Token: 0x040159A4 RID: 88484
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _MaterialInstance_Textures;

		// Token: 0x040159A5 RID: 88485
		internal static int __PropertyOffset_59;

		// Token: 0x040159A6 RID: 88486
		private TMap<FName, float> _LightShaftCone_Scalars;

		// Token: 0x040159A7 RID: 88487
		internal static int __PropertyOffset_60;

		// Token: 0x040159A8 RID: 88488
		private TMap<FName, FLinearColor> _LightShaftCone_Vectors;

		// Token: 0x040159A9 RID: 88489
		internal static int __PropertyOffset_61;

		// Token: 0x040159AA RID: 88490
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _LightShaftCone_Textures;

		// Token: 0x040159AB RID: 88491
		internal static int __PropertyOffset_62;

		// Token: 0x040159AC RID: 88492
		private TMap<FName, float> _LightMaskMaterial_Scalars;

		// Token: 0x040159AD RID: 88493
		internal static int __PropertyOffset_63;

		// Token: 0x040159AE RID: 88494
		private TMap<FName, FLinearColor> _LightMaskMaterial_Vectors;

		// Token: 0x040159AF RID: 88495
		internal static int __PropertyOffset_64;

		// Token: 0x040159B0 RID: 88496
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _LightMaskMaterial_Textures;

		// Token: 0x040159B1 RID: 88497
		internal static int __PropertyOffset_65;

		// Token: 0x040159B2 RID: 88498
		internal static int __PropertyOffset_66;

		// Token: 0x040159B3 RID: 88499
		internal static int __PropertyOffset_67;

		// Token: 0x040159B4 RID: 88500
		internal static int __PropertyOffset_68;

		// Token: 0x040159B5 RID: 88501
		internal static int __PropertyOffset_69;

		// Token: 0x040159B6 RID: 88502
		internal static int __PropertyOffset_70;

		// Token: 0x040159B7 RID: 88503
		internal static int __PropertyOffset_71;

		// Token: 0x040159B8 RID: 88504
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x040159B9 RID: 88505
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040159BA RID: 88506
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040159BB RID: 88507
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040159BC RID: 88508
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040159BD RID: 88509
		private static IntPtr __OnGameUserSettingsChange_NativeFunctionPtr;

		// Token: 0x040159BE RID: 88510
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040159BF RID: 88511
		private static IntPtr __ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor_NativeFunctionPtr;

		// Token: 0x0200A151 RID: 41297
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032E8A RID: 208522
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A152 RID: 41298
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032E8B RID: 208523
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A153 RID: 41299
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032E8C RID: 208524
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A154 RID: 41300
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricConeLightShaft_InMotor_FunctionParams
		{
			// Token: 0x04032E8D RID: 208525
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
