using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A9F RID: 15007
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaft.BP_VolumetricConeLightShaft_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1385)]
	public class BP_VolumetricConeLightShaft_C : AActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FC46 RID: 130118 RVA: 0x00919D3C File Offset: 0x00917F3C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaft.BP_VolumetricConeLightShaft_C");
			}
			return BP_VolumetricConeLightShaft_C._ClassPtr;
		}

		// Token: 0x0601FC47 RID: 130119 RVA: 0x00919D60 File Offset: 0x00917F60
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricConeLightShaft_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FC48 RID: 130120 RVA: 0x00919D68 File Offset: 0x00917F68
		public BP_VolumetricConeLightShaft_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FC49 RID: 130121 RVA: 0x00919D90 File Offset: 0x00917F90
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170031F0 RID: 12784
		// (get) Token: 0x0601FC4A RID: 130122 RVA: 0x00919DC4 File Offset: 0x00917FC4
		// (set) Token: 0x0601FC4B RID: 130123 RVA: 0x00919DFD File Offset: 0x00917FFD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170031F1 RID: 12785
		// (get) Token: 0x0601FC4C RID: 130124 RVA: 0x00919E1E File Offset: 0x0091801E
		// (set) Token: 0x0601FC4D RID: 130125 RVA: 0x00919E32 File Offset: 0x00918032
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170031F2 RID: 12786
		// (get) Token: 0x0601FC4E RID: 130126 RVA: 0x00919E47 File Offset: 0x00918047
		// (set) Token: 0x0601FC4F RID: 130127 RVA: 0x00919E5B File Offset: 0x0091805B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170031F3 RID: 12787
		// (get) Token: 0x0601FC50 RID: 130128 RVA: 0x00919E70 File Offset: 0x00918070
		// (set) Token: 0x0601FC51 RID: 130129 RVA: 0x00919E84 File Offset: 0x00918084
		public unsafe UStaticMesh StaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170031F4 RID: 12788
		// (get) Token: 0x0601FC52 RID: 130130 RVA: 0x00919E99 File Offset: 0x00918099
		// (set) Token: 0x0601FC53 RID: 130131 RVA: 0x00919EAD File Offset: 0x009180AD
		public unsafe UMaterialInstance MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170031F5 RID: 12789
		// (get) Token: 0x0601FC54 RID: 130132 RVA: 0x00919EC2 File Offset: 0x009180C2
		// (set) Token: 0x0601FC55 RID: 130133 RVA: 0x00919ED6 File Offset: 0x009180D6
		public unsafe UMaterialInstance MaterialInstanceB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170031F6 RID: 12790
		// (get) Token: 0x0601FC56 RID: 130134 RVA: 0x00919EEB File Offset: 0x009180EB
		// (set) Token: 0x0601FC57 RID: 130135 RVA: 0x00919EFF File Offset: 0x009180FF
		public unsafe UMaterialInstance MaterialInstanceBT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170031F7 RID: 12791
		// (get) Token: 0x0601FC58 RID: 130136 RVA: 0x00919F14 File Offset: 0x00918114
		// (set) Token: 0x0601FC59 RID: 130137 RVA: 0x00919F28 File Offset: 0x00918128
		public unsafe UMaterialInstance MaterialInstanceT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170031F8 RID: 12792
		// (get) Token: 0x0601FC5A RID: 130138 RVA: 0x00919F3D File Offset: 0x0091813D
		// (set) Token: 0x0601FC5B RID: 130139 RVA: 0x00919F51 File Offset: 0x00918151
		public unsafe FVector VolumetriConeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170031F9 RID: 12793
		// (get) Token: 0x0601FC5C RID: 130140 RVA: 0x00919F66 File Offset: 0x00918166
		// (set) Token: 0x0601FC5D RID: 130141 RVA: 0x00919F76 File Offset: 0x00918176
		public unsafe bool EnableBottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031FA RID: 12794
		// (get) Token: 0x0601FC5E RID: 130142 RVA: 0x00919F87 File Offset: 0x00918187
		// (set) Token: 0x0601FC5F RID: 130143 RVA: 0x00919F97 File Offset: 0x00918197
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031FB RID: 12795
		// (get) Token: 0x0601FC60 RID: 130144 RVA: 0x00919FA8 File Offset: 0x009181A8
		// (set) Token: 0x0601FC61 RID: 130145 RVA: 0x00919FB8 File Offset: 0x009181B8
		public unsafe bool EnableFlickent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170031FC RID: 12796
		// (get) Token: 0x0601FC62 RID: 130146 RVA: 0x00919FC9 File Offset: 0x009181C9
		// (set) Token: 0x0601FC63 RID: 130147 RVA: 0x00919FD9 File Offset: 0x009181D9
		public unsafe float ConeSin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170031FD RID: 12797
		// (get) Token: 0x0601FC64 RID: 130148 RVA: 0x00919FEA File Offset: 0x009181EA
		// (set) Token: 0x0601FC65 RID: 130149 RVA: 0x00919FFA File Offset: 0x009181FA
		public unsafe float RadFallOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170031FE RID: 12798
		// (get) Token: 0x0601FC66 RID: 130150 RVA: 0x0091A00B File Offset: 0x0091820B
		// (set) Token: 0x0601FC67 RID: 130151 RVA: 0x0091A01B File Offset: 0x0091821B
		public unsafe float TopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170031FF RID: 12799
		// (get) Token: 0x0601FC68 RID: 130152 RVA: 0x0091A02C File Offset: 0x0091822C
		// (set) Token: 0x0601FC69 RID: 130153 RVA: 0x0091A03C File Offset: 0x0091823C
		public unsafe float TopColorLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003200 RID: 12800
		// (get) Token: 0x0601FC6A RID: 130154 RVA: 0x0091A04D File Offset: 0x0091824D
		// (set) Token: 0x0601FC6B RID: 130155 RVA: 0x0091A061 File Offset: 0x00918261
		public unsafe FLinearColor TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003201 RID: 12801
		// (get) Token: 0x0601FC6C RID: 130156 RVA: 0x0091A076 File Offset: 0x00918276
		// (set) Token: 0x0601FC6D RID: 130157 RVA: 0x0091A08A File Offset: 0x0091828A
		public unsafe FLinearColor BottomColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003202 RID: 12802
		// (get) Token: 0x0601FC6E RID: 130158 RVA: 0x0091A09F File Offset: 0x0091829F
		// (set) Token: 0x0601FC6F RID: 130159 RVA: 0x0091A0AF File Offset: 0x009182AF
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003203 RID: 12803
		// (get) Token: 0x0601FC70 RID: 130160 RVA: 0x0091A0C0 File Offset: 0x009182C0
		// (set) Token: 0x0601FC71 RID: 130161 RVA: 0x0091A0D0 File Offset: 0x009182D0
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003204 RID: 12804
		// (get) Token: 0x0601FC72 RID: 130162 RVA: 0x0091A0E1 File Offset: 0x009182E1
		// (set) Token: 0x0601FC73 RID: 130163 RVA: 0x0091A0F1 File Offset: 0x009182F1
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003205 RID: 12805
		// (get) Token: 0x0601FC74 RID: 130164 RVA: 0x0091A102 File Offset: 0x00918302
		// (set) Token: 0x0601FC75 RID: 130165 RVA: 0x0091A112 File Offset: 0x00918312
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003206 RID: 12806
		// (get) Token: 0x0601FC76 RID: 130166 RVA: 0x0091A123 File Offset: 0x00918323
		// (set) Token: 0x0601FC77 RID: 130167 RVA: 0x0091A133 File Offset: 0x00918333
		public unsafe float DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003207 RID: 12807
		// (get) Token: 0x0601FC78 RID: 130168 RVA: 0x0091A144 File Offset: 0x00918344
		// (set) Token: 0x0601FC79 RID: 130169 RVA: 0x0091A154 File Offset: 0x00918354
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003208 RID: 12808
		// (get) Token: 0x0601FC7A RID: 130170 RVA: 0x0091A165 File Offset: 0x00918365
		// (set) Token: 0x0601FC7B RID: 130171 RVA: 0x0091A179 File Offset: 0x00918379
		public unsafe FVector LightShaftScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003209 RID: 12809
		// (get) Token: 0x0601FC7C RID: 130172 RVA: 0x0091A18E File Offset: 0x0091838E
		// (set) Token: 0x0601FC7D RID: 130173 RVA: 0x0091A1A2 File Offset: 0x009183A2
		public unsafe UStaticMesh LightShaftStaticMeshCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x1700320A RID: 12810
		// (get) Token: 0x0601FC7E RID: 130174 RVA: 0x0091A1B7 File Offset: 0x009183B7
		// (set) Token: 0x0601FC7F RID: 130175 RVA: 0x0091A1CB File Offset: 0x009183CB
		public unsafe UMaterialInstance LightShaftCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x1700320B RID: 12811
		// (get) Token: 0x0601FC80 RID: 130176 RVA: 0x0091A1E0 File Offset: 0x009183E0
		// (set) Token: 0x0601FC81 RID: 130177 RVA: 0x0091A1F4 File Offset: 0x009183F4
		public unsafe UTexture2D Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x1700320C RID: 12812
		// (get) Token: 0x0601FC82 RID: 130178 RVA: 0x0091A209 File Offset: 0x00918409
		// (set) Token: 0x0601FC83 RID: 130179 RVA: 0x0091A21D File Offset: 0x0091841D
		public unsafe FLinearColor FallOff_ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700320D RID: 12813
		// (get) Token: 0x0601FC84 RID: 130180 RVA: 0x0091A232 File Offset: 0x00918432
		// (set) Token: 0x0601FC85 RID: 130181 RVA: 0x0091A242 File Offset: 0x00918442
		public unsafe float FallOff_DepthFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700320E RID: 12814
		// (get) Token: 0x0601FC86 RID: 130182 RVA: 0x0091A253 File Offset: 0x00918453
		// (set) Token: 0x0601FC87 RID: 130183 RVA: 0x0091A263 File Offset: 0x00918463
		public unsafe float ScreenFadeFrom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700320F RID: 12815
		// (get) Token: 0x0601FC88 RID: 130184 RVA: 0x0091A274 File Offset: 0x00918474
		// (set) Token: 0x0601FC89 RID: 130185 RVA: 0x0091A284 File Offset: 0x00918484
		public unsafe float Opacity_CenterPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17003210 RID: 12816
		// (get) Token: 0x0601FC8A RID: 130186 RVA: 0x0091A295 File Offset: 0x00918495
		// (set) Token: 0x0601FC8B RID: 130187 RVA: 0x0091A2A5 File Offset: 0x009184A5
		public unsafe float ScreenFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17003211 RID: 12817
		// (get) Token: 0x0601FC8C RID: 130188 RVA: 0x0091A2B6 File Offset: 0x009184B6
		// (set) Token: 0x0601FC8D RID: 130189 RVA: 0x0091A2C6 File Offset: 0x009184C6
		public unsafe float ShaftTopClip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17003212 RID: 12818
		// (get) Token: 0x0601FC8E RID: 130190 RVA: 0x0091A2D7 File Offset: 0x009184D7
		// (set) Token: 0x0601FC8F RID: 130191 RVA: 0x0091A2EB File Offset: 0x009184EB
		public unsafe FLinearColor UVScaleAndAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17003213 RID: 12819
		// (get) Token: 0x0601FC90 RID: 130192 RVA: 0x0091A300 File Offset: 0x00918500
		// (set) Token: 0x0601FC91 RID: 130193 RVA: 0x0091A314 File Offset: 0x00918514
		public unsafe UStaticMesh LightMaskStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003214 RID: 12820
		// (get) Token: 0x0601FC92 RID: 130194 RVA: 0x0091A329 File Offset: 0x00918529
		// (set) Token: 0x0601FC93 RID: 130195 RVA: 0x0091A339 File Offset: 0x00918539
		public unsafe float LightMaskZaxis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003215 RID: 12821
		// (get) Token: 0x0601FC94 RID: 130196 RVA: 0x0091A34A File Offset: 0x0091854A
		// (set) Token: 0x0601FC95 RID: 130197 RVA: 0x0091A35E File Offset: 0x0091855E
		public unsafe UMaterialInstance LightMaskMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003216 RID: 12822
		// (get) Token: 0x0601FC96 RID: 130198 RVA: 0x0091A373 File Offset: 0x00918573
		// (set) Token: 0x0601FC97 RID: 130199 RVA: 0x0091A387 File Offset: 0x00918587
		public unsafe FVector LightMaskScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17003217 RID: 12823
		// (get) Token: 0x0601FC98 RID: 130200 RVA: 0x0091A39C File Offset: 0x0091859C
		// (set) Token: 0x0601FC99 RID: 130201 RVA: 0x0091A3B0 File Offset: 0x009185B0
		public unsafe FLinearColor LightMaskColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17003218 RID: 12824
		// (get) Token: 0x0601FC9A RID: 130202 RVA: 0x0091A3C5 File Offset: 0x009185C5
		// (set) Token: 0x0601FC9B RID: 130203 RVA: 0x0091A3D9 File Offset: 0x009185D9
		public unsafe UTexture2D LightMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x17003219 RID: 12825
		// (get) Token: 0x0601FC9C RID: 130204 RVA: 0x0091A3EE File Offset: 0x009185EE
		// (set) Token: 0x0601FC9D RID: 130205 RVA: 0x0091A3FE File Offset: 0x009185FE
		public unsafe float ColorIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700321A RID: 12826
		// (get) Token: 0x0601FC9E RID: 130206 RVA: 0x0091A40F File Offset: 0x0091860F
		// (set) Token: 0x0601FC9F RID: 130207 RVA: 0x0091A41F File Offset: 0x0091861F
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700321B RID: 12827
		// (get) Token: 0x0601FCA0 RID: 130208 RVA: 0x0091A430 File Offset: 0x00918630
		// (set) Token: 0x0601FCA1 RID: 130209 RVA: 0x0091A440 File Offset: 0x00918640
		public unsafe float FadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x1700321C RID: 12828
		// (get) Token: 0x0601FCA2 RID: 130210 RVA: 0x0091A451 File Offset: 0x00918651
		// (set) Token: 0x0601FCA3 RID: 130211 RVA: 0x0091A461 File Offset: 0x00918661
		public unsafe float FlankInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x1700321D RID: 12829
		// (get) Token: 0x0601FCA4 RID: 130212 RVA: 0x0091A472 File Offset: 0x00918672
		// (set) Token: 0x0601FCA5 RID: 130213 RVA: 0x0091A482 File Offset: 0x00918682
		public unsafe float Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x1700321E RID: 12830
		// (get) Token: 0x0601FCA6 RID: 130214 RVA: 0x0091A493 File Offset: 0x00918693
		// (set) Token: 0x0601FCA7 RID: 130215 RVA: 0x0091A4A3 File Offset: 0x009186A3
		public unsafe float RightSideInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x1700321F RID: 12831
		// (get) Token: 0x0601FCA8 RID: 130216 RVA: 0x0091A4B4 File Offset: 0x009186B4
		// (set) Token: 0x0601FCA9 RID: 130217 RVA: 0x0091A4C8 File Offset: 0x009186C8
		public unsafe UStaticMeshComponent VolumetricCone
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x17003220 RID: 12832
		// (get) Token: 0x0601FCAA RID: 130218 RVA: 0x0091A4DD File Offset: 0x009186DD
		// (set) Token: 0x0601FCAB RID: 130219 RVA: 0x0091A4F1 File Offset: 0x009186F1
		public unsafe UStaticMeshComponent LightShaft
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricConeLightShaft_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x17003221 RID: 12833
		// (get) Token: 0x0601FCAC RID: 130220 RVA: 0x0091A506 File Offset: 0x00918706
		// (set) Token: 0x0601FCAD RID: 130221 RVA: 0x0091A516 File Offset: 0x00918716
		public unsafe bool OptimizeForMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricConeLightShaft_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601FCAE RID: 130222 RVA: 0x0091A528 File Offset: 0x00918728
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FCAF RID: 130223 RVA: 0x0091A570 File Offset: 0x00918770
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FCB0 RID: 130224 RVA: 0x0091A5B6 File Offset: 0x009187B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FCB1 RID: 130225 RVA: 0x0091A5CA File Offset: 0x009187CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FCB2 RID: 130226 RVA: 0x0091A5DF File Offset: 0x009187DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FCB3 RID: 130227 RVA: 0x0091A5F3 File Offset: 0x009187F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FCB4 RID: 130228 RVA: 0x0091A608 File Offset: 0x00918808
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnGameUserSettingsChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__OnGameUserSettingsChange_NativeFunctionPtr, null);
		}

		// Token: 0x0601FCB5 RID: 130229 RVA: 0x0091A61C File Offset: 0x0091881C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FCB6 RID: 130230 RVA: 0x0091A668 File Offset: 0x00918868
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FCB7 RID: 130231 RVA: 0x0091A6B4 File Offset: 0x009188B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricConeLightShaft(int EntryPoint)
		{
			BP_VolumetricConeLightShaft_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FCB8 RID: 130232 RVA: 0x0091A6FB File Offset: 0x009188FB
		protected BP_VolumetricConeLightShaft_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FCD9 RID: 64729
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FCDA RID: 64730
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricConeLightShaft.BP_VolumetricConeLightShaft_C";

		// Token: 0x0400FCDB RID: 64731
		private static IntPtr _ClassPtr;

		// Token: 0x0400FCDC RID: 64732
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FCDD RID: 64733
		internal static int __PropertyOffset_0;

		// Token: 0x0400FCDE RID: 64734
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FCDF RID: 64735
		internal static int __PropertyOffset_1;

		// Token: 0x0400FCE0 RID: 64736
		internal static int __PropertyOffset_2;

		// Token: 0x0400FCE1 RID: 64737
		internal static int __PropertyOffset_3;

		// Token: 0x0400FCE2 RID: 64738
		internal static int __PropertyOffset_4;

		// Token: 0x0400FCE3 RID: 64739
		internal static int __PropertyOffset_5;

		// Token: 0x0400FCE4 RID: 64740
		internal static int __PropertyOffset_6;

		// Token: 0x0400FCE5 RID: 64741
		internal static int __PropertyOffset_7;

		// Token: 0x0400FCE6 RID: 64742
		internal static int __PropertyOffset_8;

		// Token: 0x0400FCE7 RID: 64743
		internal static int __PropertyOffset_9;

		// Token: 0x0400FCE8 RID: 64744
		internal static int __PropertyOffset_10;

		// Token: 0x0400FCE9 RID: 64745
		internal static int __PropertyOffset_11;

		// Token: 0x0400FCEA RID: 64746
		internal static int __PropertyOffset_12;

		// Token: 0x0400FCEB RID: 64747
		internal static int __PropertyOffset_13;

		// Token: 0x0400FCEC RID: 64748
		internal static int __PropertyOffset_14;

		// Token: 0x0400FCED RID: 64749
		internal static int __PropertyOffset_15;

		// Token: 0x0400FCEE RID: 64750
		internal static int __PropertyOffset_16;

		// Token: 0x0400FCEF RID: 64751
		internal static int __PropertyOffset_17;

		// Token: 0x0400FCF0 RID: 64752
		internal static int __PropertyOffset_18;

		// Token: 0x0400FCF1 RID: 64753
		internal static int __PropertyOffset_19;

		// Token: 0x0400FCF2 RID: 64754
		internal static int __PropertyOffset_20;

		// Token: 0x0400FCF3 RID: 64755
		internal static int __PropertyOffset_21;

		// Token: 0x0400FCF4 RID: 64756
		internal static int __PropertyOffset_22;

		// Token: 0x0400FCF5 RID: 64757
		internal static int __PropertyOffset_23;

		// Token: 0x0400FCF6 RID: 64758
		internal static int __PropertyOffset_24;

		// Token: 0x0400FCF7 RID: 64759
		internal static int __PropertyOffset_25;

		// Token: 0x0400FCF8 RID: 64760
		internal static int __PropertyOffset_26;

		// Token: 0x0400FCF9 RID: 64761
		internal static int __PropertyOffset_27;

		// Token: 0x0400FCFA RID: 64762
		internal static int __PropertyOffset_28;

		// Token: 0x0400FCFB RID: 64763
		internal static int __PropertyOffset_29;

		// Token: 0x0400FCFC RID: 64764
		internal static int __PropertyOffset_30;

		// Token: 0x0400FCFD RID: 64765
		internal static int __PropertyOffset_31;

		// Token: 0x0400FCFE RID: 64766
		internal static int __PropertyOffset_32;

		// Token: 0x0400FCFF RID: 64767
		internal static int __PropertyOffset_33;

		// Token: 0x0400FD00 RID: 64768
		internal static int __PropertyOffset_34;

		// Token: 0x0400FD01 RID: 64769
		internal static int __PropertyOffset_35;

		// Token: 0x0400FD02 RID: 64770
		internal static int __PropertyOffset_36;

		// Token: 0x0400FD03 RID: 64771
		internal static int __PropertyOffset_37;

		// Token: 0x0400FD04 RID: 64772
		internal static int __PropertyOffset_38;

		// Token: 0x0400FD05 RID: 64773
		internal static int __PropertyOffset_39;

		// Token: 0x0400FD06 RID: 64774
		internal static int __PropertyOffset_40;

		// Token: 0x0400FD07 RID: 64775
		internal static int __PropertyOffset_41;

		// Token: 0x0400FD08 RID: 64776
		internal static int __PropertyOffset_42;

		// Token: 0x0400FD09 RID: 64777
		internal static int __PropertyOffset_43;

		// Token: 0x0400FD0A RID: 64778
		internal static int __PropertyOffset_44;

		// Token: 0x0400FD0B RID: 64779
		internal static int __PropertyOffset_45;

		// Token: 0x0400FD0C RID: 64780
		internal static int __PropertyOffset_46;

		// Token: 0x0400FD0D RID: 64781
		internal static int __PropertyOffset_47;

		// Token: 0x0400FD0E RID: 64782
		internal static int __PropertyOffset_48;

		// Token: 0x0400FD0F RID: 64783
		internal static int __PropertyOffset_49;

		// Token: 0x0400FD10 RID: 64784
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FD11 RID: 64785
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FD12 RID: 64786
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FD13 RID: 64787
		private static IntPtr __OnGameUserSettingsChange_NativeFunctionPtr;

		// Token: 0x0400FD14 RID: 64788
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400FD15 RID: 64789
		private static IntPtr __ExecuteUbergraph_BP_VolumetricConeLightShaft_NativeFunctionPtr;

		// Token: 0x0200991E RID: 39198
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F7D RID: 204669
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x0200991F RID: 39199
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031F7E RID: 204670
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009920 RID: 39200
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricConeLightShaft_FunctionParams
		{
			// Token: 0x04031F7F RID: 204671
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
