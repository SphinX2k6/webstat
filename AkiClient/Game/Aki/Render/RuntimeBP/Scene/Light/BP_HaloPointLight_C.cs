using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Billboard;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A82 RID: 14978
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_HaloPointLight.BP_HaloPointLight_C")]
	[UnrealStructLayout(1256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1253)]
	public class BP_HaloPointLight_C : APointLight, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F56E RID: 128366 RVA: 0x0090F371 File Offset: 0x0090D571
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HaloPointLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_HaloPointLight.BP_HaloPointLight_C");
			}
			return BP_HaloPointLight_C._ClassPtr;
		}

		// Token: 0x0601F56F RID: 128367 RVA: 0x0090F395 File Offset: 0x0090D595
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_HaloPointLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F570 RID: 128368 RVA: 0x0090F39C File Offset: 0x0090D59C
		public BP_HaloPointLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_HaloPointLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F571 RID: 128369 RVA: 0x0090F3C4 File Offset: 0x0090D5C4
		[NullableContext(1)]
		public BP_HaloPointLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HaloPointLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002F48 RID: 12104
		// (get) Token: 0x0601F572 RID: 128370 RVA: 0x0090F3F8 File Offset: 0x0090D5F8
		// (set) Token: 0x0601F573 RID: 128371 RVA: 0x0090F431 File Offset: 0x0090D631
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002F49 RID: 12105
		// (get) Token: 0x0601F574 RID: 128372 RVA: 0x0090F452 File Offset: 0x0090D652
		// (set) Token: 0x0601F575 RID: 128373 RVA: 0x0090F466 File Offset: 0x0090D666
		public unsafe UMaterialInstanceDynamic DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002F4A RID: 12106
		// (get) Token: 0x0601F576 RID: 128374 RVA: 0x0090F47B File Offset: 0x0090D67B
		// (set) Token: 0x0601F577 RID: 128375 RVA: 0x0090F48B File Offset: 0x0090D68B
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F4B RID: 12107
		// (get) Token: 0x0601F578 RID: 128376 RVA: 0x0090F49C File Offset: 0x0090D69C
		// (set) Token: 0x0601F579 RID: 128377 RVA: 0x0090F4AC File Offset: 0x0090D6AC
		public unsafe bool bAcceptGI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F4C RID: 12108
		// (get) Token: 0x0601F57A RID: 128378 RVA: 0x0090F4BD File Offset: 0x0090D6BD
		// (set) Token: 0x0601F57B RID: 128379 RVA: 0x0090F4CD File Offset: 0x0090D6CD
		public unsafe bool Enable_Black
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F4D RID: 12109
		// (get) Token: 0x0601F57C RID: 128380 RVA: 0x0090F4DE File Offset: 0x0090D6DE
		// (set) Token: 0x0601F57D RID: 128381 RVA: 0x0090F4EE File Offset: 0x0090D6EE
		public unsafe bool FaceToCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F4E RID: 12110
		// (get) Token: 0x0601F57E RID: 128382 RVA: 0x0090F4FF File Offset: 0x0090D6FF
		// (set) Token: 0x0601F57F RID: 128383 RVA: 0x0090F50F File Offset: 0x0090D70F
		public unsafe float SizeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002F4F RID: 12111
		// (get) Token: 0x0601F580 RID: 128384 RVA: 0x0090F520 File Offset: 0x0090D720
		// (set) Token: 0x0601F581 RID: 128385 RVA: 0x0090F530 File Offset: 0x0090D730
		public unsafe float IntensityScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002F50 RID: 12112
		// (get) Token: 0x0601F582 RID: 128386 RVA: 0x0090F541 File Offset: 0x0090D741
		// (set) Token: 0x0601F583 RID: 128387 RVA: 0x0090F551 File Offset: 0x0090D751
		public unsafe float LightExponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002F51 RID: 12113
		// (get) Token: 0x0601F584 RID: 128388 RVA: 0x0090F562 File Offset: 0x0090D762
		// (set) Token: 0x0601F585 RID: 128389 RVA: 0x0090F572 File Offset: 0x0090D772
		public unsafe float FadeStartRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002F52 RID: 12114
		// (get) Token: 0x0601F586 RID: 128390 RVA: 0x0090F583 File Offset: 0x0090D783
		// (set) Token: 0x0601F587 RID: 128391 RVA: 0x0090F593 File Offset: 0x0090D793
		public unsafe float FadeEndRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002F53 RID: 12115
		// (get) Token: 0x0601F588 RID: 128392 RVA: 0x0090F5A4 File Offset: 0x0090D7A4
		// (set) Token: 0x0601F589 RID: 128393 RVA: 0x0090F5B8 File Offset: 0x0090D7B8
		public unsafe UKuroHaloComponent HaloComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroHaloComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002F54 RID: 12116
		// (get) Token: 0x0601F58A RID: 128394 RVA: 0x0090F5CD File Offset: 0x0090D7CD
		// (set) Token: 0x0601F58B RID: 128395 RVA: 0x0090F5DD File Offset: 0x0090D7DD
		public unsafe float DepthFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002F55 RID: 12117
		// (get) Token: 0x0601F58C RID: 128396 RVA: 0x0090F5EE File Offset: 0x0090D7EE
		// (set) Token: 0x0601F58D RID: 128397 RVA: 0x0090F5FE File Offset: 0x0090D7FE
		public unsafe float AspectRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002F56 RID: 12118
		// (get) Token: 0x0601F58E RID: 128398 RVA: 0x0090F60F File Offset: 0x0090D80F
		// (set) Token: 0x0601F58F RID: 128399 RVA: 0x0090F623 File Offset: 0x0090D823
		[Nullable(0)]
		public unsafe TEnumAsByte<E_BillboardMode> FaceCameraMode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_14);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002F57 RID: 12119
		// (get) Token: 0x0601F590 RID: 128400 RVA: 0x0090F638 File Offset: 0x0090D838
		// (set) Token: 0x0601F591 RID: 128401 RVA: 0x0090F64C File Offset: 0x0090D84C
		public unsafe UStaticMesh HaloMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17002F58 RID: 12120
		// (get) Token: 0x0601F592 RID: 128402 RVA: 0x0090F661 File Offset: 0x0090D861
		// (set) Token: 0x0601F593 RID: 128403 RVA: 0x0090F671 File Offset: 0x0090D871
		public unsafe float MinDrawDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002F59 RID: 12121
		// (get) Token: 0x0601F594 RID: 128404 RVA: 0x0090F682 File Offset: 0x0090D882
		// (set) Token: 0x0601F595 RID: 128405 RVA: 0x0090F692 File Offset: 0x0090D892
		public unsafe float MaxDrawDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002F5A RID: 12122
		// (get) Token: 0x0601F596 RID: 128406 RVA: 0x0090F6A3 File Offset: 0x0090D8A3
		// (set) Token: 0x0601F597 RID: 128407 RVA: 0x0090F6B3 File Offset: 0x0090D8B3
		public unsafe float MinDrawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002F5B RID: 12123
		// (get) Token: 0x0601F598 RID: 128408 RVA: 0x0090F6C4 File Offset: 0x0090D8C4
		// (set) Token: 0x0601F599 RID: 128409 RVA: 0x0090F6D4 File Offset: 0x0090D8D4
		public unsafe float MaxDrawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002F5C RID: 12124
		// (get) Token: 0x0601F59A RID: 128410 RVA: 0x0090F6E5 File Offset: 0x0090D8E5
		// (set) Token: 0x0601F59B RID: 128411 RVA: 0x0090F6F5 File Offset: 0x0090D8F5
		public unsafe float UseShapeTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002F5D RID: 12125
		// (get) Token: 0x0601F59C RID: 128412 RVA: 0x0090F706 File Offset: 0x0090D906
		// (set) Token: 0x0601F59D RID: 128413 RVA: 0x0090F71A File Offset: 0x0090D91A
		public unsafe UTexture2D VolumeTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17002F5E RID: 12126
		// (get) Token: 0x0601F59E RID: 128414 RVA: 0x0090F72F File Offset: 0x0090D92F
		// (set) Token: 0x0601F59F RID: 128415 RVA: 0x0090F73F File Offset: 0x0090D93F
		public unsafe float PointLinghtIntenty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002F5F RID: 12127
		// (get) Token: 0x0601F5A0 RID: 128416 RVA: 0x0090F750 File Offset: 0x0090D950
		// (set) Token: 0x0601F5A1 RID: 128417 RVA: 0x0090F764 File Offset: 0x0090D964
		public unsafe PD_HaloPointLightConfig_C HaloPointConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_HaloPointLightConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17002F60 RID: 12128
		// (get) Token: 0x0601F5A2 RID: 128418 RVA: 0x0090F779 File Offset: 0x0090D979
		// (set) Token: 0x0601F5A3 RID: 128419 RVA: 0x0090F789 File Offset: 0x0090D989
		public unsafe KuroFeatureLevel CurrentFeatureLevel
		{
			get
			{
				return (KuroFeatureLevel)(*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_24));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_24) = (byte)value;
			}
		}

		// Token: 0x17002F61 RID: 12129
		// (get) Token: 0x0601F5A4 RID: 128420 RVA: 0x0090F79A File Offset: 0x0090D99A
		// (set) Token: 0x0601F5A5 RID: 128421 RVA: 0x0090F7AE File Offset: 0x0090D9AE
		public unsafe UMaterialInterface HaloMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17002F62 RID: 12130
		// (get) Token: 0x0601F5A6 RID: 128422 RVA: 0x0090F7C3 File Offset: 0x0090D9C3
		// (set) Token: 0x0601F5A7 RID: 128423 RVA: 0x0090F7D7 File Offset: 0x0090D9D7
		public unsafe UMaterialInterface HaloMaterial_NoBillboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17002F63 RID: 12131
		// (get) Token: 0x0601F5A8 RID: 128424 RVA: 0x0090F7EC File Offset: 0x0090D9EC
		// (set) Token: 0x0601F5A9 RID: 128425 RVA: 0x0090F800 File Offset: 0x0090DA00
		public unsafe FVector NoFaceCameraSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002F64 RID: 12132
		// (get) Token: 0x0601F5AA RID: 128426 RVA: 0x0090F815 File Offset: 0x0090DA15
		// (set) Token: 0x0601F5AB RID: 128427 RVA: 0x0090F829 File Offset: 0x0090DA29
		public unsafe UMaterialInterface HaloMaterial_NoBillboard_Black
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17002F65 RID: 12133
		// (get) Token: 0x0601F5AC RID: 128428 RVA: 0x0090F83E File Offset: 0x0090DA3E
		// (set) Token: 0x0601F5AD RID: 128429 RVA: 0x0090F852 File Offset: 0x0090DA52
		public unsafe UMaterialInterface HaloMaterial_Black
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HaloPointLight_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17002F66 RID: 12134
		// (get) Token: 0x0601F5AE RID: 128430 RVA: 0x0090F867 File Offset: 0x0090DA67
		// (set) Token: 0x0601F5AF RID: 128431 RVA: 0x0090F877 File Offset: 0x0090DA77
		public unsafe int TranslucentSortPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002F67 RID: 12135
		// (get) Token: 0x0601F5B0 RID: 128432 RVA: 0x0090F888 File Offset: 0x0090DA88
		// (set) Token: 0x0601F5B1 RID: 128433 RVA: 0x0090F898 File Offset: 0x0090DA98
		public unsafe int FrameCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002F68 RID: 12136
		// (get) Token: 0x0601F5B2 RID: 128434 RVA: 0x0090F8A9 File Offset: 0x0090DAA9
		// (set) Token: 0x0601F5B3 RID: 128435 RVA: 0x0090F8BD File Offset: 0x0090DABD
		[Nullable(0)]
		public unsafe TEnumAsByte<ELightQualityType> Quality
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_32);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17002F69 RID: 12137
		// (get) Token: 0x0601F5B4 RID: 128436 RVA: 0x0090F8D2 File Offset: 0x0090DAD2
		// (set) Token: 0x0601F5B5 RID: 128437 RVA: 0x0090F8E2 File Offset: 0x0090DAE2
		public unsafe int CurrentQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17002F6A RID: 12138
		// (get) Token: 0x0601F5B6 RID: 128438 RVA: 0x0090F8F3 File Offset: 0x0090DAF3
		// (set) Token: 0x0601F5B7 RID: 128439 RVA: 0x0090F903 File Offset: 0x0090DB03
		public unsafe float BoundsScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17002F6B RID: 12139
		// (get) Token: 0x0601F5B8 RID: 128440 RVA: 0x0090F914 File Offset: 0x0090DB14
		// (set) Token: 0x0601F5B9 RID: 128441 RVA: 0x0090F924 File Offset: 0x0090DB24
		public unsafe bool bNeedToShow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HaloPointLight_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F5BA RID: 128442 RVA: 0x0090F938 File Offset: 0x0090DB38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_HaloPointLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_HaloPointLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HaloPointLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HaloPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F5BB RID: 128443 RVA: 0x0090F980 File Offset: 0x0090DB80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_HaloPointLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_HaloPointLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HaloPointLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HaloPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HaloPointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F5BC RID: 128444 RVA: 0x0090F9C6 File Offset: 0x0090DBC6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetQuality()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__SetQuality_NativeFunctionPtr, null);
		}

		// Token: 0x0601F5BD RID: 128445 RVA: 0x0090F9DC File Offset: 0x0090DBDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHaloDrawParameters(ref float MinDrawDistance, ref float MaxDrawDistance, ref float MinDrawRange, ref float MaxDrawRange)
		{
			BP_HaloPointLight_C.__GetHaloDrawParameters_FunctionParams* ptr = stackalloc BP_HaloPointLight_C.__GetHaloDrawParameters_FunctionParams[(UIntPtr)171] + 15L / (long)sizeof(BP_HaloPointLight_C.__GetHaloDrawParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HaloPointLight_C.__GetHaloDrawParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MinDrawDistance = MinDrawDistance;
			ptr->MaxDrawDistance = MaxDrawDistance;
			ptr->MinDrawRange = MinDrawRange;
			ptr->MaxDrawRange = MaxDrawRange;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__GetHaloDrawParameters_NativeFunctionPtr, (void*)ptr);
			MinDrawDistance = ptr->MinDrawDistance;
			MaxDrawDistance = ptr->MaxDrawDistance;
			MinDrawRange = ptr->MinDrawRange;
			MaxDrawRange = ptr->MaxDrawRange;
		}

		// Token: 0x0601F5BE RID: 128446 RVA: 0x0090FA60 File Offset: 0x0090DC60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateHaloParameter(bool UpdateComponent)
		{
			BP_HaloPointLight_C.__UpdateHaloParameter_FunctionParams* ptr = stackalloc BP_HaloPointLight_C.__UpdateHaloParameter_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_HaloPointLight_C.__UpdateHaloParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HaloPointLight_C.__UpdateHaloParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->UpdateComponent = UpdateComponent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__UpdateHaloParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F5BF RID: 128447 RVA: 0x0090FAA9 File Offset: 0x0090DCA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F5C0 RID: 128448 RVA: 0x0090FABD File Offset: 0x0090DCBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HaloPointLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F5C1 RID: 128449 RVA: 0x0090FAD2 File Offset: 0x0090DCD2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F5C2 RID: 128450 RVA: 0x0090FAE6 File Offset: 0x0090DCE6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HaloPointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F5C3 RID: 128451 RVA: 0x0090FAFB File Offset: 0x0090DCFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void HaloPointParaUpdate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__HaloPointParaUpdate_NativeFunctionPtr, null);
		}

		// Token: 0x0601F5C4 RID: 128452 RVA: 0x0090FB0F File Offset: 0x0090DD0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void HaloPointParaUpdate_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HaloPointLight_C.__HaloPointParaUpdate_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F5C5 RID: 128453 RVA: 0x0090FB24 File Offset: 0x0090DD24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_HaloPointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HaloPointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HaloPointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HaloPointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F5C6 RID: 128454 RVA: 0x0090FB6C File Offset: 0x0090DD6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_HaloPointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HaloPointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HaloPointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HaloPointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HaloPointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F5C7 RID: 128455 RVA: 0x0090FBB3 File Offset: 0x0090DDB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HaloPointLight_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x0601F5C8 RID: 128456 RVA: 0x0090FBC8 File Offset: 0x0090DDC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_HaloPointLight(int EntryPoint)
		{
			BP_HaloPointLight_C.__ExecuteUbergraph_BP_HaloPointLight_FunctionParams* ptr = stackalloc BP_HaloPointLight_C.__ExecuteUbergraph_BP_HaloPointLight_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_HaloPointLight_C.__ExecuteUbergraph_BP_HaloPointLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HaloPointLight_C.__ExecuteUbergraph_BP_HaloPointLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HaloPointLight_C.__ExecuteUbergraph_BP_HaloPointLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F5C9 RID: 128457 RVA: 0x0090FC0F File Offset: 0x0090DE0F
		protected BP_HaloPointLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F8E6 RID: 63718
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F8E7 RID: 63719
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_HaloPointLight.BP_HaloPointLight_C";

		// Token: 0x0400F8E8 RID: 63720
		private static IntPtr _ClassPtr;

		// Token: 0x0400F8E9 RID: 63721
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F8EA RID: 63722
		internal static int __PropertyOffset_0;

		// Token: 0x0400F8EB RID: 63723
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F8EC RID: 63724
		internal static int __PropertyOffset_1;

		// Token: 0x0400F8ED RID: 63725
		internal static int __PropertyOffset_2;

		// Token: 0x0400F8EE RID: 63726
		internal static int __PropertyOffset_3;

		// Token: 0x0400F8EF RID: 63727
		internal static int __PropertyOffset_4;

		// Token: 0x0400F8F0 RID: 63728
		internal static int __PropertyOffset_5;

		// Token: 0x0400F8F1 RID: 63729
		internal static int __PropertyOffset_6;

		// Token: 0x0400F8F2 RID: 63730
		internal static int __PropertyOffset_7;

		// Token: 0x0400F8F3 RID: 63731
		internal static int __PropertyOffset_8;

		// Token: 0x0400F8F4 RID: 63732
		internal static int __PropertyOffset_9;

		// Token: 0x0400F8F5 RID: 63733
		internal static int __PropertyOffset_10;

		// Token: 0x0400F8F6 RID: 63734
		internal static int __PropertyOffset_11;

		// Token: 0x0400F8F7 RID: 63735
		internal static int __PropertyOffset_12;

		// Token: 0x0400F8F8 RID: 63736
		internal static int __PropertyOffset_13;

		// Token: 0x0400F8F9 RID: 63737
		internal static int __PropertyOffset_14;

		// Token: 0x0400F8FA RID: 63738
		internal static int __PropertyOffset_15;

		// Token: 0x0400F8FB RID: 63739
		internal static int __PropertyOffset_16;

		// Token: 0x0400F8FC RID: 63740
		internal static int __PropertyOffset_17;

		// Token: 0x0400F8FD RID: 63741
		internal static int __PropertyOffset_18;

		// Token: 0x0400F8FE RID: 63742
		internal static int __PropertyOffset_19;

		// Token: 0x0400F8FF RID: 63743
		internal static int __PropertyOffset_20;

		// Token: 0x0400F900 RID: 63744
		internal static int __PropertyOffset_21;

		// Token: 0x0400F901 RID: 63745
		internal static int __PropertyOffset_22;

		// Token: 0x0400F902 RID: 63746
		internal static int __PropertyOffset_23;

		// Token: 0x0400F903 RID: 63747
		internal static int __PropertyOffset_24;

		// Token: 0x0400F904 RID: 63748
		internal static int __PropertyOffset_25;

		// Token: 0x0400F905 RID: 63749
		internal static int __PropertyOffset_26;

		// Token: 0x0400F906 RID: 63750
		internal static int __PropertyOffset_27;

		// Token: 0x0400F907 RID: 63751
		internal static int __PropertyOffset_28;

		// Token: 0x0400F908 RID: 63752
		internal static int __PropertyOffset_29;

		// Token: 0x0400F909 RID: 63753
		internal static int __PropertyOffset_30;

		// Token: 0x0400F90A RID: 63754
		internal static int __PropertyOffset_31;

		// Token: 0x0400F90B RID: 63755
		internal static int __PropertyOffset_32;

		// Token: 0x0400F90C RID: 63756
		internal static int __PropertyOffset_33;

		// Token: 0x0400F90D RID: 63757
		internal static int __PropertyOffset_34;

		// Token: 0x0400F90E RID: 63758
		internal static int __PropertyOffset_35;

		// Token: 0x0400F90F RID: 63759
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400F910 RID: 63760
		private static IntPtr __SetQuality_NativeFunctionPtr;

		// Token: 0x0400F911 RID: 63761
		private static IntPtr __GetHaloDrawParameters_NativeFunctionPtr;

		// Token: 0x0400F912 RID: 63762
		private static IntPtr __UpdateHaloParameter_NativeFunctionPtr;

		// Token: 0x0400F913 RID: 63763
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F914 RID: 63764
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F915 RID: 63765
		private static IntPtr __HaloPointParaUpdate_NativeFunctionPtr;

		// Token: 0x0400F916 RID: 63766
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F917 RID: 63767
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x0400F918 RID: 63768
		private static IntPtr __ExecuteUbergraph_BP_HaloPointLight_NativeFunctionPtr;

		// Token: 0x020098CD RID: 39117
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F1F RID: 204575
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x020098CE RID: 39118
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 156)]
		protected ref struct __GetHaloDrawParameters_FunctionParams
		{
			// Token: 0x04031F20 RID: 204576
			[FieldOffset(0)]
			public float MinDrawDistance;

			// Token: 0x04031F21 RID: 204577
			[FieldOffset(4)]
			public float MaxDrawDistance;

			// Token: 0x04031F22 RID: 204578
			[FieldOffset(8)]
			public float MinDrawRange;

			// Token: 0x04031F23 RID: 204579
			[FieldOffset(12)]
			public float MaxDrawRange;
		}

		// Token: 0x020098CF RID: 39119
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __UpdateHaloParameter_FunctionParams
		{
			// Token: 0x04031F24 RID: 204580
			[FieldOffset(0)]
			public bool UpdateComponent;
		}

		// Token: 0x020098D0 RID: 39120
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F25 RID: 204581
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098D1 RID: 39121
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_HaloPointLight_FunctionParams
		{
			// Token: 0x04031F26 RID: 204582
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
