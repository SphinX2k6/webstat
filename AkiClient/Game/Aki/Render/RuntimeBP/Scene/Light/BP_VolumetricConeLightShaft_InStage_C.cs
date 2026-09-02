using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA0 RID: 15008
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaft_InStage.BP_VolumetricConeLightShaft_InStage_C")]
	[UnrealStructLayout(2744, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2744)]
	public class BP_VolumetricConeLightShaft_InStage_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FCB9 RID: 130233 RVA: 0x0091A704 File Offset: 0x00918904
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_InStage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaft_InStage.BP_VolumetricConeLightShaft_InStage_C");
			}
			return BP_VolumetricConeLightShaft_InStage_C._ClassPtr;
		}

		// Token: 0x0601FCBA RID: 130234 RVA: 0x0091A728 File Offset: 0x00918928
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricConeLightShaft_InStage_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FCBB RID: 130235 RVA: 0x0091A730 File Offset: 0x00918930
		public BP_VolumetricConeLightShaft_InStage_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InStage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FCBC RID: 130236 RVA: 0x0091A758 File Offset: 0x00918958
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_InStage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InStage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003222 RID: 12834
		// (get) Token: 0x0601FCBD RID: 130237 RVA: 0x0091A78C File Offset: 0x0091898C
		// (set) Token: 0x0601FCBE RID: 130238 RVA: 0x0091A7C5 File Offset: 0x009189C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003223 RID: 12835
		// (get) Token: 0x0601FCBF RID: 130239 RVA: 0x0091A7E6 File Offset: 0x009189E6
		// (set) Token: 0x0601FCC0 RID: 130240 RVA: 0x0091A7FA File Offset: 0x009189FA
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003224 RID: 12836
		// (get) Token: 0x0601FCC1 RID: 130241 RVA: 0x0091A80F File Offset: 0x00918A0F
		// (set) Token: 0x0601FCC2 RID: 130242 RVA: 0x0091A823 File Offset: 0x00918A23
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003225 RID: 12837
		// (get) Token: 0x0601FCC3 RID: 130243 RVA: 0x0091A838 File Offset: 0x00918A38
		// (set) Token: 0x0601FCC4 RID: 130244 RVA: 0x0091A84C File Offset: 0x00918A4C
		public unsafe UStaticMesh StaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003226 RID: 12838
		// (get) Token: 0x0601FCC5 RID: 130245 RVA: 0x0091A861 File Offset: 0x00918A61
		// (set) Token: 0x0601FCC6 RID: 130246 RVA: 0x0091A875 File Offset: 0x00918A75
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003227 RID: 12839
		// (get) Token: 0x0601FCC7 RID: 130247 RVA: 0x0091A88A File Offset: 0x00918A8A
		// (set) Token: 0x0601FCC8 RID: 130248 RVA: 0x0091A89E File Offset: 0x00918A9E
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003228 RID: 12840
		// (get) Token: 0x0601FCC9 RID: 130249 RVA: 0x0091A8B3 File Offset: 0x00918AB3
		// (set) Token: 0x0601FCCA RID: 130250 RVA: 0x0091A8C7 File Offset: 0x00918AC7
		public unsafe FVector VolumetriConeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003229 RID: 12841
		// (get) Token: 0x0601FCCB RID: 130251 RVA: 0x0091A8DC File Offset: 0x00918ADC
		// (set) Token: 0x0601FCCC RID: 130252 RVA: 0x0091A8EC File Offset: 0x00918AEC
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700322A RID: 12842
		// (get) Token: 0x0601FCCD RID: 130253 RVA: 0x0091A8FD File Offset: 0x00918AFD
		// (set) Token: 0x0601FCCE RID: 130254 RVA: 0x0091A90D File Offset: 0x00918B0D
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700322B RID: 12843
		// (get) Token: 0x0601FCCF RID: 130255 RVA: 0x0091A91E File Offset: 0x00918B1E
		// (set) Token: 0x0601FCD0 RID: 130256 RVA: 0x0091A92E File Offset: 0x00918B2E
		public unsafe bool EnableFlickent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700322C RID: 12844
		// (get) Token: 0x0601FCD1 RID: 130257 RVA: 0x0091A93F File Offset: 0x00918B3F
		// (set) Token: 0x0601FCD2 RID: 130258 RVA: 0x0091A94F File Offset: 0x00918B4F
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700322D RID: 12845
		// (get) Token: 0x0601FCD3 RID: 130259 RVA: 0x0091A960 File Offset: 0x00918B60
		// (set) Token: 0x0601FCD4 RID: 130260 RVA: 0x0091A970 File Offset: 0x00918B70
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700322E RID: 12846
		// (get) Token: 0x0601FCD5 RID: 130261 RVA: 0x0091A981 File Offset: 0x00918B81
		// (set) Token: 0x0601FCD6 RID: 130262 RVA: 0x0091A991 File Offset: 0x00918B91
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700322F RID: 12847
		// (get) Token: 0x0601FCD7 RID: 130263 RVA: 0x0091A9A2 File Offset: 0x00918BA2
		// (set) Token: 0x0601FCD8 RID: 130264 RVA: 0x0091A9B2 File Offset: 0x00918BB2
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003230 RID: 12848
		// (get) Token: 0x0601FCD9 RID: 130265 RVA: 0x0091A9C3 File Offset: 0x00918BC3
		// (set) Token: 0x0601FCDA RID: 130266 RVA: 0x0091A9D7 File Offset: 0x00918BD7
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003231 RID: 12849
		// (get) Token: 0x0601FCDB RID: 130267 RVA: 0x0091A9EC File Offset: 0x00918BEC
		// (set) Token: 0x0601FCDC RID: 130268 RVA: 0x0091AA00 File Offset: 0x00918C00
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003232 RID: 12850
		// (get) Token: 0x0601FCDD RID: 130269 RVA: 0x0091AA15 File Offset: 0x00918C15
		// (set) Token: 0x0601FCDE RID: 130270 RVA: 0x0091AA25 File Offset: 0x00918C25
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003233 RID: 12851
		// (get) Token: 0x0601FCDF RID: 130271 RVA: 0x0091AA36 File Offset: 0x00918C36
		// (set) Token: 0x0601FCE0 RID: 130272 RVA: 0x0091AA46 File Offset: 0x00918C46
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003234 RID: 12852
		// (get) Token: 0x0601FCE1 RID: 130273 RVA: 0x0091AA57 File Offset: 0x00918C57
		// (set) Token: 0x0601FCE2 RID: 130274 RVA: 0x0091AA67 File Offset: 0x00918C67
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003235 RID: 12853
		// (get) Token: 0x0601FCE3 RID: 130275 RVA: 0x0091AA78 File Offset: 0x00918C78
		// (set) Token: 0x0601FCE4 RID: 130276 RVA: 0x0091AA88 File Offset: 0x00918C88
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003236 RID: 12854
		// (get) Token: 0x0601FCE5 RID: 130277 RVA: 0x0091AA99 File Offset: 0x00918C99
		// (set) Token: 0x0601FCE6 RID: 130278 RVA: 0x0091AAA9 File Offset: 0x00918CA9
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003237 RID: 12855
		// (get) Token: 0x0601FCE7 RID: 130279 RVA: 0x0091AABA File Offset: 0x00918CBA
		// (set) Token: 0x0601FCE8 RID: 130280 RVA: 0x0091AACA File Offset: 0x00918CCA
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003238 RID: 12856
		// (get) Token: 0x0601FCE9 RID: 130281 RVA: 0x0091AADB File Offset: 0x00918CDB
		// (set) Token: 0x0601FCEA RID: 130282 RVA: 0x0091AAEF File Offset: 0x00918CEF
		public unsafe FVector LightShaftScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003239 RID: 12857
		// (get) Token: 0x0601FCEB RID: 130283 RVA: 0x0091AB04 File Offset: 0x00918D04
		// (set) Token: 0x0601FCEC RID: 130284 RVA: 0x0091AB18 File Offset: 0x00918D18
		public unsafe UStaticMesh LightShaftStaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x1700323A RID: 12858
		// (get) Token: 0x0601FCED RID: 130285 RVA: 0x0091AB2D File Offset: 0x00918D2D
		// (set) Token: 0x0601FCEE RID: 130286 RVA: 0x0091AB41 File Offset: 0x00918D41
		public unsafe UMaterialInstance LightShaftCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x1700323B RID: 12859
		// (get) Token: 0x0601FCEF RID: 130287 RVA: 0x0091AB56 File Offset: 0x00918D56
		// (set) Token: 0x0601FCF0 RID: 130288 RVA: 0x0091AB6A File Offset: 0x00918D6A
		public unsafe UTexture2D Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x1700323C RID: 12860
		// (get) Token: 0x0601FCF1 RID: 130289 RVA: 0x0091AB7F File Offset: 0x00918D7F
		// (set) Token: 0x0601FCF2 RID: 130290 RVA: 0x0091AB93 File Offset: 0x00918D93
		public unsafe FLinearColor FallOff_ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700323D RID: 12861
		// (get) Token: 0x0601FCF3 RID: 130291 RVA: 0x0091ABA8 File Offset: 0x00918DA8
		// (set) Token: 0x0601FCF4 RID: 130292 RVA: 0x0091ABB8 File Offset: 0x00918DB8
		public unsafe float FallOff_DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700323E RID: 12862
		// (get) Token: 0x0601FCF5 RID: 130293 RVA: 0x0091ABC9 File Offset: 0x00918DC9
		// (set) Token: 0x0601FCF6 RID: 130294 RVA: 0x0091ABD9 File Offset: 0x00918DD9
		public unsafe float ScreenFadeFrom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700323F RID: 12863
		// (get) Token: 0x0601FCF7 RID: 130295 RVA: 0x0091ABEA File Offset: 0x00918DEA
		// (set) Token: 0x0601FCF8 RID: 130296 RVA: 0x0091ABFA File Offset: 0x00918DFA
		public unsafe float Opacity_CenterPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003240 RID: 12864
		// (get) Token: 0x0601FCF9 RID: 130297 RVA: 0x0091AC0B File Offset: 0x00918E0B
		// (set) Token: 0x0601FCFA RID: 130298 RVA: 0x0091AC1B File Offset: 0x00918E1B
		public unsafe float ScreenFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17003241 RID: 12865
		// (get) Token: 0x0601FCFB RID: 130299 RVA: 0x0091AC2C File Offset: 0x00918E2C
		// (set) Token: 0x0601FCFC RID: 130300 RVA: 0x0091AC3C File Offset: 0x00918E3C
		public unsafe float ShaftTopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17003242 RID: 12866
		// (get) Token: 0x0601FCFD RID: 130301 RVA: 0x0091AC4D File Offset: 0x00918E4D
		// (set) Token: 0x0601FCFE RID: 130302 RVA: 0x0091AC61 File Offset: 0x00918E61
		public unsafe FLinearColor UVScaleAndAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17003243 RID: 12867
		// (get) Token: 0x0601FCFF RID: 130303 RVA: 0x0091AC76 File Offset: 0x00918E76
		// (set) Token: 0x0601FD00 RID: 130304 RVA: 0x0091AC8A File Offset: 0x00918E8A
		public unsafe UStaticMesh LightMaskStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003244 RID: 12868
		// (get) Token: 0x0601FD01 RID: 130305 RVA: 0x0091AC9F File Offset: 0x00918E9F
		// (set) Token: 0x0601FD02 RID: 130306 RVA: 0x0091ACAF File Offset: 0x00918EAF
		public unsafe float LightMaskZaxis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17003245 RID: 12869
		// (get) Token: 0x0601FD03 RID: 130307 RVA: 0x0091ACC0 File Offset: 0x00918EC0
		// (set) Token: 0x0601FD04 RID: 130308 RVA: 0x0091ACD4 File Offset: 0x00918ED4
		public unsafe UMaterialInstance LightMaskMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003246 RID: 12870
		// (get) Token: 0x0601FD05 RID: 130309 RVA: 0x0091ACE9 File Offset: 0x00918EE9
		// (set) Token: 0x0601FD06 RID: 130310 RVA: 0x0091ACFD File Offset: 0x00918EFD
		public unsafe FVector LightMaskScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003247 RID: 12871
		// (get) Token: 0x0601FD07 RID: 130311 RVA: 0x0091AD12 File Offset: 0x00918F12
		// (set) Token: 0x0601FD08 RID: 130312 RVA: 0x0091AD26 File Offset: 0x00918F26
		public unsafe FLinearColor LightMaskColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17003248 RID: 12872
		// (get) Token: 0x0601FD09 RID: 130313 RVA: 0x0091AD3B File Offset: 0x00918F3B
		// (set) Token: 0x0601FD0A RID: 130314 RVA: 0x0091AD4F File Offset: 0x00918F4F
		public unsafe UTexture2D LightMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003249 RID: 12873
		// (get) Token: 0x0601FD0B RID: 130315 RVA: 0x0091AD64 File Offset: 0x00918F64
		// (set) Token: 0x0601FD0C RID: 130316 RVA: 0x0091AD74 File Offset: 0x00918F74
		public unsafe float ColorIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x1700324A RID: 12874
		// (get) Token: 0x0601FD0D RID: 130317 RVA: 0x0091AD85 File Offset: 0x00918F85
		// (set) Token: 0x0601FD0E RID: 130318 RVA: 0x0091AD95 File Offset: 0x00918F95
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x1700324B RID: 12875
		// (get) Token: 0x0601FD0F RID: 130319 RVA: 0x0091ADA6 File Offset: 0x00918FA6
		// (set) Token: 0x0601FD10 RID: 130320 RVA: 0x0091ADB6 File Offset: 0x00918FB6
		public unsafe float FadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700324C RID: 12876
		// (get) Token: 0x0601FD11 RID: 130321 RVA: 0x0091ADC7 File Offset: 0x00918FC7
		// (set) Token: 0x0601FD12 RID: 130322 RVA: 0x0091ADD7 File Offset: 0x00918FD7
		public unsafe float FlankInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700324D RID: 12877
		// (get) Token: 0x0601FD13 RID: 130323 RVA: 0x0091ADE8 File Offset: 0x00918FE8
		// (set) Token: 0x0601FD14 RID: 130324 RVA: 0x0091ADF8 File Offset: 0x00918FF8
		public unsafe float Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x1700324E RID: 12878
		// (get) Token: 0x0601FD15 RID: 130325 RVA: 0x0091AE09 File Offset: 0x00919009
		// (set) Token: 0x0601FD16 RID: 130326 RVA: 0x0091AE19 File Offset: 0x00919019
		public unsafe float RightSideInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x1700324F RID: 12879
		// (get) Token: 0x0601FD17 RID: 130327 RVA: 0x0091AE2A File Offset: 0x0091902A
		// (set) Token: 0x0601FD18 RID: 130328 RVA: 0x0091AE3E File Offset: 0x0091903E
		public unsafe FVector CenterLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17003250 RID: 12880
		// (get) Token: 0x0601FD19 RID: 130329 RVA: 0x0091AE53 File Offset: 0x00919053
		// (set) Token: 0x0601FD1A RID: 130330 RVA: 0x0091AE67 File Offset: 0x00919067
		public unsafe UTexture MainNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17003251 RID: 12881
		// (get) Token: 0x0601FD1B RID: 130331 RVA: 0x0091AE7C File Offset: 0x0091907C
		// (set) Token: 0x0601FD1C RID: 130332 RVA: 0x0091AE90 File Offset: 0x00919090
		public unsafe UTexture SecondNoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x17003252 RID: 12882
		// (get) Token: 0x0601FD1D RID: 130333 RVA: 0x0091AEA5 File Offset: 0x009190A5
		// (set) Token: 0x0601FD1E RID: 130334 RVA: 0x0091AEB9 File Offset: 0x009190B9
		public unsafe FLinearColor MainNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17003253 RID: 12883
		// (get) Token: 0x0601FD1F RID: 130335 RVA: 0x0091AECE File Offset: 0x009190CE
		// (set) Token: 0x0601FD20 RID: 130336 RVA: 0x0091AEE2 File Offset: 0x009190E2
		public unsafe FLinearColor SecondNoiseTexUVControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17003254 RID: 12884
		// (get) Token: 0x0601FD21 RID: 130337 RVA: 0x0091AEF7 File Offset: 0x009190F7
		// (set) Token: 0x0601FD22 RID: 130338 RVA: 0x0091AF07 File Offset: 0x00919107
		public unsafe float MainUVAddStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17003255 RID: 12885
		// (get) Token: 0x0601FD23 RID: 130339 RVA: 0x0091AF18 File Offset: 0x00919118
		// (set) Token: 0x0601FD24 RID: 130340 RVA: 0x0091AF2C File Offset: 0x0091912C
		public unsafe FLinearColor MainNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17003256 RID: 12886
		// (get) Token: 0x0601FD25 RID: 130341 RVA: 0x0091AF41 File Offset: 0x00919141
		// (set) Token: 0x0601FD26 RID: 130342 RVA: 0x0091AF55 File Offset: 0x00919155
		public unsafe FLinearColor SecondNoiseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17003257 RID: 12887
		// (get) Token: 0x0601FD27 RID: 130343 RVA: 0x0091AF6C File Offset: 0x0091916C
		// (set) Token: 0x0601FD28 RID: 130344 RVA: 0x0091AFA5 File Offset: 0x009191A5
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
					result = (this._MaterialInstanceB_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_53, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceB_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x17003258 RID: 12888
		// (get) Token: 0x0601FD29 RID: 130345 RVA: 0x0091AFB4 File Offset: 0x009191B4
		// (set) Token: 0x0601FD2A RID: 130346 RVA: 0x0091AFED File Offset: 0x009191ED
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
					result = (this._MaterialInstanceB_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_54, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceB_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x17003259 RID: 12889
		// (get) Token: 0x0601FD2B RID: 130347 RVA: 0x0091AFFC File Offset: 0x009191FC
		// (set) Token: 0x0601FD2C RID: 130348 RVA: 0x0091B035 File Offset: 0x00919235
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
					result = (this._MaterialInstanceB_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_55, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceB_Textures.CopyAssign(value);
			}
		}

		// Token: 0x1700325A RID: 12890
		// (get) Token: 0x0601FD2D RID: 130349 RVA: 0x0091B044 File Offset: 0x00919244
		// (set) Token: 0x0601FD2E RID: 130350 RVA: 0x0091B07D File Offset: 0x0091927D
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
					result = (this._MaterialInstance_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_56, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstance_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x1700325B RID: 12891
		// (get) Token: 0x0601FD2F RID: 130351 RVA: 0x0091B08C File Offset: 0x0091928C
		// (set) Token: 0x0601FD30 RID: 130352 RVA: 0x0091B0C5 File Offset: 0x009192C5
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
					result = (this._MaterialInstance_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_57, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstance_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x1700325C RID: 12892
		// (get) Token: 0x0601FD31 RID: 130353 RVA: 0x0091B0D4 File Offset: 0x009192D4
		// (set) Token: 0x0601FD32 RID: 130354 RVA: 0x0091B10D File Offset: 0x0091930D
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
					result = (this._MaterialInstance_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_58, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstance_Textures.CopyAssign(value);
			}
		}

		// Token: 0x1700325D RID: 12893
		// (get) Token: 0x0601FD33 RID: 130355 RVA: 0x0091B11C File Offset: 0x0091931C
		// (set) Token: 0x0601FD34 RID: 130356 RVA: 0x0091B155 File Offset: 0x00919355
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
					result = (this._LightShaftCone_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_59, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x1700325E RID: 12894
		// (get) Token: 0x0601FD35 RID: 130357 RVA: 0x0091B164 File Offset: 0x00919364
		// (set) Token: 0x0601FD36 RID: 130358 RVA: 0x0091B19D File Offset: 0x0091939D
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
					result = (this._LightShaftCone_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_60, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x1700325F RID: 12895
		// (get) Token: 0x0601FD37 RID: 130359 RVA: 0x0091B1AC File Offset: 0x009193AC
		// (set) Token: 0x0601FD38 RID: 130360 RVA: 0x0091B1E5 File Offset: 0x009193E5
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
					result = (this._LightShaftCone_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_61, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightShaftCone_Textures.CopyAssign(value);
			}
		}

		// Token: 0x17003260 RID: 12896
		// (get) Token: 0x0601FD39 RID: 130361 RVA: 0x0091B1F4 File Offset: 0x009193F4
		// (set) Token: 0x0601FD3A RID: 130362 RVA: 0x0091B22D File Offset: 0x0091942D
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
					result = (this._LightMaskMaterial_Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_62, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightMaskMaterial_Scalars.CopyAssign(value);
			}
		}

		// Token: 0x17003261 RID: 12897
		// (get) Token: 0x0601FD3B RID: 130363 RVA: 0x0091B23C File Offset: 0x0091943C
		// (set) Token: 0x0601FD3C RID: 130364 RVA: 0x0091B275 File Offset: 0x00919475
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
					result = (this._LightMaskMaterial_Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_63, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightMaskMaterial_Vectors.CopyAssign(value);
			}
		}

		// Token: 0x17003262 RID: 12898
		// (get) Token: 0x0601FD3D RID: 130365 RVA: 0x0091B284 File Offset: 0x00919484
		// (set) Token: 0x0601FD3E RID: 130366 RVA: 0x0091B2BD File Offset: 0x009194BD
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
					result = (this._LightMaskMaterial_Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_64, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightMaskMaterial_Textures.CopyAssign(value);
			}
		}

		// Token: 0x17003263 RID: 12899
		// (get) Token: 0x0601FD3F RID: 130367 RVA: 0x0091B2CB File Offset: 0x009194CB
		// (set) Token: 0x0601FD40 RID: 130368 RVA: 0x0091B2DF File Offset: 0x009194DF
		public unsafe UMaterialInstanceDynamic MaterialInstanceBDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17003264 RID: 12900
		// (get) Token: 0x0601FD41 RID: 130369 RVA: 0x0091B2F4 File Offset: 0x009194F4
		// (set) Token: 0x0601FD42 RID: 130370 RVA: 0x0091B308 File Offset: 0x00919508
		public unsafe UMaterialInstanceDynamic MaterialInstanceDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_66);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_66, value);
			}
		}

		// Token: 0x17003265 RID: 12901
		// (get) Token: 0x0601FD43 RID: 130371 RVA: 0x0091B31D File Offset: 0x0091951D
		// (set) Token: 0x0601FD44 RID: 130372 RVA: 0x0091B331 File Offset: 0x00919531
		public unsafe UMaterialInstanceDynamic LightShaftConeDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_67);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_67, value);
			}
		}

		// Token: 0x17003266 RID: 12902
		// (get) Token: 0x0601FD45 RID: 130373 RVA: 0x0091B346 File Offset: 0x00919546
		// (set) Token: 0x0601FD46 RID: 130374 RVA: 0x0091B35A File Offset: 0x0091955A
		public unsafe UMaterialInstanceDynamic LightMaskMaterialDY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_68);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_68, value);
			}
		}

		// Token: 0x17003267 RID: 12903
		// (get) Token: 0x0601FD47 RID: 130375 RVA: 0x0091B36F File Offset: 0x0091956F
		// (set) Token: 0x0601FD48 RID: 130376 RVA: 0x0091B37F File Offset: 0x0091957F
		public unsafe bool IsTickUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_69) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_69) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003268 RID: 12904
		// (get) Token: 0x0601FD49 RID: 130377 RVA: 0x0091B390 File Offset: 0x00919590
		// (set) Token: 0x0601FD4A RID: 130378 RVA: 0x0091B3A0 File Offset: 0x009195A0
		public unsafe bool OptimizeForMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_70) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_70) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003269 RID: 12905
		// (get) Token: 0x0601FD4B RID: 130379 RVA: 0x0091B3B1 File Offset: 0x009195B1
		// (set) Token: 0x0601FD4C RID: 130380 RVA: 0x0091B3C5 File Offset: 0x009195C5
		public unsafe UStaticMeshComponent VolumetricCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_71);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_InStage_C.__PropertyOffset_71, value);
			}
		}

		// Token: 0x0601FD4D RID: 130381 RVA: 0x0091B3DC File Offset: 0x009195DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FD4E RID: 130382 RVA: 0x0091B424 File Offset: 0x00919624
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FD4F RID: 130383 RVA: 0x0091B46A File Offset: 0x0091966A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD50 RID: 130384 RVA: 0x0091B47E File Offset: 0x0091967E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD51 RID: 130385 RVA: 0x0091B492 File Offset: 0x00919692
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FD52 RID: 130386 RVA: 0x0091B4A7 File Offset: 0x009196A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD53 RID: 130387 RVA: 0x0091B4BB File Offset: 0x009196BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FD54 RID: 130388 RVA: 0x0091B4D0 File Offset: 0x009196D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FD55 RID: 130389 RVA: 0x0091B518 File Offset: 0x00919718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD56 RID: 130390 RVA: 0x0091B560 File Offset: 0x00919760
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FD57 RID: 130391 RVA: 0x0091B5A8 File Offset: 0x009197A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD58 RID: 130392 RVA: 0x0091B5EF File Offset: 0x009197EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnGameUserSettingsChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__OnGameUserSettingsChange_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD59 RID: 130393 RVA: 0x0091B604 File Offset: 0x00919804
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FD5A RID: 130394 RVA: 0x0091B650 File Offset: 0x00919850
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD5B RID: 130395 RVA: 0x0091B69C File Offset: 0x0091989C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage(int EntryPoint)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD5C RID: 130396 RVA: 0x0091B6E3 File Offset: 0x009198E3
		protected BP_VolumetricConeLightShaft_InStage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FD16 RID: 64790
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FD17 RID: 64791
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaft_InStage.BP_VolumetricConeLightShaft_InStage_C";

		// Token: 0x0400FD18 RID: 64792
		private static IntPtr _ClassPtr;

		// Token: 0x0400FD19 RID: 64793
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FD1A RID: 64794
		internal static int __PropertyOffset_0;

		// Token: 0x0400FD1B RID: 64795
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FD1C RID: 64796
		internal static int __PropertyOffset_1;

		// Token: 0x0400FD1D RID: 64797
		internal static int __PropertyOffset_2;

		// Token: 0x0400FD1E RID: 64798
		internal static int __PropertyOffset_3;

		// Token: 0x0400FD1F RID: 64799
		internal static int __PropertyOffset_4;

		// Token: 0x0400FD20 RID: 64800
		internal static int __PropertyOffset_5;

		// Token: 0x0400FD21 RID: 64801
		internal static int __PropertyOffset_6;

		// Token: 0x0400FD22 RID: 64802
		internal static int __PropertyOffset_7;

		// Token: 0x0400FD23 RID: 64803
		internal static int __PropertyOffset_8;

		// Token: 0x0400FD24 RID: 64804
		internal static int __PropertyOffset_9;

		// Token: 0x0400FD25 RID: 64805
		internal static int __PropertyOffset_10;

		// Token: 0x0400FD26 RID: 64806
		internal static int __PropertyOffset_11;

		// Token: 0x0400FD27 RID: 64807
		internal static int __PropertyOffset_12;

		// Token: 0x0400FD28 RID: 64808
		internal static int __PropertyOffset_13;

		// Token: 0x0400FD29 RID: 64809
		internal static int __PropertyOffset_14;

		// Token: 0x0400FD2A RID: 64810
		internal static int __PropertyOffset_15;

		// Token: 0x0400FD2B RID: 64811
		internal static int __PropertyOffset_16;

		// Token: 0x0400FD2C RID: 64812
		internal static int __PropertyOffset_17;

		// Token: 0x0400FD2D RID: 64813
		internal static int __PropertyOffset_18;

		// Token: 0x0400FD2E RID: 64814
		internal static int __PropertyOffset_19;

		// Token: 0x0400FD2F RID: 64815
		internal static int __PropertyOffset_20;

		// Token: 0x0400FD30 RID: 64816
		internal static int __PropertyOffset_21;

		// Token: 0x0400FD31 RID: 64817
		internal static int __PropertyOffset_22;

		// Token: 0x0400FD32 RID: 64818
		internal static int __PropertyOffset_23;

		// Token: 0x0400FD33 RID: 64819
		internal static int __PropertyOffset_24;

		// Token: 0x0400FD34 RID: 64820
		internal static int __PropertyOffset_25;

		// Token: 0x0400FD35 RID: 64821
		internal static int __PropertyOffset_26;

		// Token: 0x0400FD36 RID: 64822
		internal static int __PropertyOffset_27;

		// Token: 0x0400FD37 RID: 64823
		internal static int __PropertyOffset_28;

		// Token: 0x0400FD38 RID: 64824
		internal static int __PropertyOffset_29;

		// Token: 0x0400FD39 RID: 64825
		internal static int __PropertyOffset_30;

		// Token: 0x0400FD3A RID: 64826
		internal static int __PropertyOffset_31;

		// Token: 0x0400FD3B RID: 64827
		internal static int __PropertyOffset_32;

		// Token: 0x0400FD3C RID: 64828
		internal static int __PropertyOffset_33;

		// Token: 0x0400FD3D RID: 64829
		internal static int __PropertyOffset_34;

		// Token: 0x0400FD3E RID: 64830
		internal static int __PropertyOffset_35;

		// Token: 0x0400FD3F RID: 64831
		internal static int __PropertyOffset_36;

		// Token: 0x0400FD40 RID: 64832
		internal static int __PropertyOffset_37;

		// Token: 0x0400FD41 RID: 64833
		internal static int __PropertyOffset_38;

		// Token: 0x0400FD42 RID: 64834
		internal static int __PropertyOffset_39;

		// Token: 0x0400FD43 RID: 64835
		internal static int __PropertyOffset_40;

		// Token: 0x0400FD44 RID: 64836
		internal static int __PropertyOffset_41;

		// Token: 0x0400FD45 RID: 64837
		internal static int __PropertyOffset_42;

		// Token: 0x0400FD46 RID: 64838
		internal static int __PropertyOffset_43;

		// Token: 0x0400FD47 RID: 64839
		internal static int __PropertyOffset_44;

		// Token: 0x0400FD48 RID: 64840
		internal static int __PropertyOffset_45;

		// Token: 0x0400FD49 RID: 64841
		internal static int __PropertyOffset_46;

		// Token: 0x0400FD4A RID: 64842
		internal static int __PropertyOffset_47;

		// Token: 0x0400FD4B RID: 64843
		internal static int __PropertyOffset_48;

		// Token: 0x0400FD4C RID: 64844
		internal static int __PropertyOffset_49;

		// Token: 0x0400FD4D RID: 64845
		internal static int __PropertyOffset_50;

		// Token: 0x0400FD4E RID: 64846
		internal static int __PropertyOffset_51;

		// Token: 0x0400FD4F RID: 64847
		internal static int __PropertyOffset_52;

		// Token: 0x0400FD50 RID: 64848
		internal static int __PropertyOffset_53;

		// Token: 0x0400FD51 RID: 64849
		private TMap<FName, float> _MaterialInstanceB_Scalars;

		// Token: 0x0400FD52 RID: 64850
		internal static int __PropertyOffset_54;

		// Token: 0x0400FD53 RID: 64851
		private TMap<FName, FLinearColor> _MaterialInstanceB_Vectors;

		// Token: 0x0400FD54 RID: 64852
		internal static int __PropertyOffset_55;

		// Token: 0x0400FD55 RID: 64853
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _MaterialInstanceB_Textures;

		// Token: 0x0400FD56 RID: 64854
		internal static int __PropertyOffset_56;

		// Token: 0x0400FD57 RID: 64855
		private TMap<FName, float> _MaterialInstance_Scalars;

		// Token: 0x0400FD58 RID: 64856
		internal static int __PropertyOffset_57;

		// Token: 0x0400FD59 RID: 64857
		private TMap<FName, FLinearColor> _MaterialInstance_Vectors;

		// Token: 0x0400FD5A RID: 64858
		internal static int __PropertyOffset_58;

		// Token: 0x0400FD5B RID: 64859
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _MaterialInstance_Textures;

		// Token: 0x0400FD5C RID: 64860
		internal static int __PropertyOffset_59;

		// Token: 0x0400FD5D RID: 64861
		private TMap<FName, float> _LightShaftCone_Scalars;

		// Token: 0x0400FD5E RID: 64862
		internal static int __PropertyOffset_60;

		// Token: 0x0400FD5F RID: 64863
		private TMap<FName, FLinearColor> _LightShaftCone_Vectors;

		// Token: 0x0400FD60 RID: 64864
		internal static int __PropertyOffset_61;

		// Token: 0x0400FD61 RID: 64865
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _LightShaftCone_Textures;

		// Token: 0x0400FD62 RID: 64866
		internal static int __PropertyOffset_62;

		// Token: 0x0400FD63 RID: 64867
		private TMap<FName, float> _LightMaskMaterial_Scalars;

		// Token: 0x0400FD64 RID: 64868
		internal static int __PropertyOffset_63;

		// Token: 0x0400FD65 RID: 64869
		private TMap<FName, FLinearColor> _LightMaskMaterial_Vectors;

		// Token: 0x0400FD66 RID: 64870
		internal static int __PropertyOffset_64;

		// Token: 0x0400FD67 RID: 64871
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _LightMaskMaterial_Textures;

		// Token: 0x0400FD68 RID: 64872
		internal static int __PropertyOffset_65;

		// Token: 0x0400FD69 RID: 64873
		internal static int __PropertyOffset_66;

		// Token: 0x0400FD6A RID: 64874
		internal static int __PropertyOffset_67;

		// Token: 0x0400FD6B RID: 64875
		internal static int __PropertyOffset_68;

		// Token: 0x0400FD6C RID: 64876
		internal static int __PropertyOffset_69;

		// Token: 0x0400FD6D RID: 64877
		internal static int __PropertyOffset_70;

		// Token: 0x0400FD6E RID: 64878
		internal static int __PropertyOffset_71;

		// Token: 0x0400FD6F RID: 64879
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FD70 RID: 64880
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0400FD71 RID: 64881
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FD72 RID: 64882
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FD73 RID: 64883
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FD74 RID: 64884
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FD75 RID: 64885
		private static IntPtr __OnGameUserSettingsChange_NativeFunctionPtr;

		// Token: 0x0400FD76 RID: 64886
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400FD77 RID: 64887
		private static IntPtr __ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_NativeFunctionPtr;

		// Token: 0x02009921 RID: 39201
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F80 RID: 204672
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009922 RID: 39202
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F81 RID: 204673
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009923 RID: 39203
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F82 RID: 204674
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009924 RID: 39204
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031F83 RID: 204675
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009925 RID: 39205
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams
		{
			// Token: 0x04031F84 RID: 204676
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
