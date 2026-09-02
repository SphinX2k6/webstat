using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.InteractionLight
{
	// Token: 0x02003C8D RID: 15501
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/InteractionLight/BP_VolumetricConeLightShaft_InStage.BP_VolumetricConeLightShaft_InStage_C")]
	[UnrealStructLayout(2744, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2744)]
	public class BP_VolumetricConeLightShaft_InStage_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060241FE RID: 147966 RVA: 0x00995683 File Offset: 0x00993883
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricConeLightShaft_InStage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/InteractionLight/BP_VolumetricConeLightShaft_InStage.BP_VolumetricConeLightShaft_InStage_C");
			}
			return BP_VolumetricConeLightShaft_InStage_C._ClassPtr;
		}

		// Token: 0x060241FF RID: 147967 RVA: 0x009956A8 File Offset: 0x009938A8
		public BP_VolumetricConeLightShaft_InStage_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InStage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024200 RID: 147968 RVA: 0x009956D0 File Offset: 0x009938D0
		[NullableContext(1)]
		public BP_VolumetricConeLightShaft_InStage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricConeLightShaft_InStage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A23 RID: 18979
		// (get) Token: 0x06024201 RID: 147969 RVA: 0x00995704 File Offset: 0x00993904
		// (set) Token: 0x06024202 RID: 147970 RVA: 0x0099573D File Offset: 0x0099393D
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

		// Token: 0x17004A24 RID: 18980
		// (get) Token: 0x06024203 RID: 147971 RVA: 0x0099575E File Offset: 0x0099395E
		// (set) Token: 0x06024204 RID: 147972 RVA: 0x00995772 File Offset: 0x00993972
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

		// Token: 0x17004A25 RID: 18981
		// (get) Token: 0x06024205 RID: 147973 RVA: 0x00995787 File Offset: 0x00993987
		// (set) Token: 0x06024206 RID: 147974 RVA: 0x0099579B File Offset: 0x0099399B
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

		// Token: 0x17004A26 RID: 18982
		// (get) Token: 0x06024207 RID: 147975 RVA: 0x009957B0 File Offset: 0x009939B0
		// (set) Token: 0x06024208 RID: 147976 RVA: 0x009957C4 File Offset: 0x009939C4
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

		// Token: 0x17004A27 RID: 18983
		// (get) Token: 0x06024209 RID: 147977 RVA: 0x009957D9 File Offset: 0x009939D9
		// (set) Token: 0x0602420A RID: 147978 RVA: 0x009957ED File Offset: 0x009939ED
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

		// Token: 0x17004A28 RID: 18984
		// (get) Token: 0x0602420B RID: 147979 RVA: 0x00995802 File Offset: 0x00993A02
		// (set) Token: 0x0602420C RID: 147980 RVA: 0x00995816 File Offset: 0x00993A16
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

		// Token: 0x17004A29 RID: 18985
		// (get) Token: 0x0602420D RID: 147981 RVA: 0x0099582B File Offset: 0x00993A2B
		// (set) Token: 0x0602420E RID: 147982 RVA: 0x0099583F File Offset: 0x00993A3F
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

		// Token: 0x17004A2A RID: 18986
		// (get) Token: 0x0602420F RID: 147983 RVA: 0x00995854 File Offset: 0x00993A54
		// (set) Token: 0x06024210 RID: 147984 RVA: 0x00995864 File Offset: 0x00993A64
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

		// Token: 0x17004A2B RID: 18987
		// (get) Token: 0x06024211 RID: 147985 RVA: 0x00995875 File Offset: 0x00993A75
		// (set) Token: 0x06024212 RID: 147986 RVA: 0x00995885 File Offset: 0x00993A85
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

		// Token: 0x17004A2C RID: 18988
		// (get) Token: 0x06024213 RID: 147987 RVA: 0x00995896 File Offset: 0x00993A96
		// (set) Token: 0x06024214 RID: 147988 RVA: 0x009958A6 File Offset: 0x00993AA6
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

		// Token: 0x17004A2D RID: 18989
		// (get) Token: 0x06024215 RID: 147989 RVA: 0x009958B7 File Offset: 0x00993AB7
		// (set) Token: 0x06024216 RID: 147990 RVA: 0x009958C7 File Offset: 0x00993AC7
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

		// Token: 0x17004A2E RID: 18990
		// (get) Token: 0x06024217 RID: 147991 RVA: 0x009958D8 File Offset: 0x00993AD8
		// (set) Token: 0x06024218 RID: 147992 RVA: 0x009958E8 File Offset: 0x00993AE8
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

		// Token: 0x17004A2F RID: 18991
		// (get) Token: 0x06024219 RID: 147993 RVA: 0x009958F9 File Offset: 0x00993AF9
		// (set) Token: 0x0602421A RID: 147994 RVA: 0x00995909 File Offset: 0x00993B09
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

		// Token: 0x17004A30 RID: 18992
		// (get) Token: 0x0602421B RID: 147995 RVA: 0x0099591A File Offset: 0x00993B1A
		// (set) Token: 0x0602421C RID: 147996 RVA: 0x0099592A File Offset: 0x00993B2A
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

		// Token: 0x17004A31 RID: 18993
		// (get) Token: 0x0602421D RID: 147997 RVA: 0x0099593B File Offset: 0x00993B3B
		// (set) Token: 0x0602421E RID: 147998 RVA: 0x0099594F File Offset: 0x00993B4F
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

		// Token: 0x17004A32 RID: 18994
		// (get) Token: 0x0602421F RID: 147999 RVA: 0x00995964 File Offset: 0x00993B64
		// (set) Token: 0x06024220 RID: 148000 RVA: 0x00995978 File Offset: 0x00993B78
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

		// Token: 0x17004A33 RID: 18995
		// (get) Token: 0x06024221 RID: 148001 RVA: 0x0099598D File Offset: 0x00993B8D
		// (set) Token: 0x06024222 RID: 148002 RVA: 0x0099599D File Offset: 0x00993B9D
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

		// Token: 0x17004A34 RID: 18996
		// (get) Token: 0x06024223 RID: 148003 RVA: 0x009959AE File Offset: 0x00993BAE
		// (set) Token: 0x06024224 RID: 148004 RVA: 0x009959BE File Offset: 0x00993BBE
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

		// Token: 0x17004A35 RID: 18997
		// (get) Token: 0x06024225 RID: 148005 RVA: 0x009959CF File Offset: 0x00993BCF
		// (set) Token: 0x06024226 RID: 148006 RVA: 0x009959DF File Offset: 0x00993BDF
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

		// Token: 0x17004A36 RID: 18998
		// (get) Token: 0x06024227 RID: 148007 RVA: 0x009959F0 File Offset: 0x00993BF0
		// (set) Token: 0x06024228 RID: 148008 RVA: 0x00995A00 File Offset: 0x00993C00
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

		// Token: 0x17004A37 RID: 18999
		// (get) Token: 0x06024229 RID: 148009 RVA: 0x00995A11 File Offset: 0x00993C11
		// (set) Token: 0x0602422A RID: 148010 RVA: 0x00995A21 File Offset: 0x00993C21
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

		// Token: 0x17004A38 RID: 19000
		// (get) Token: 0x0602422B RID: 148011 RVA: 0x00995A32 File Offset: 0x00993C32
		// (set) Token: 0x0602422C RID: 148012 RVA: 0x00995A42 File Offset: 0x00993C42
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

		// Token: 0x17004A39 RID: 19001
		// (get) Token: 0x0602422D RID: 148013 RVA: 0x00995A53 File Offset: 0x00993C53
		// (set) Token: 0x0602422E RID: 148014 RVA: 0x00995A67 File Offset: 0x00993C67
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

		// Token: 0x17004A3A RID: 19002
		// (get) Token: 0x0602422F RID: 148015 RVA: 0x00995A7C File Offset: 0x00993C7C
		// (set) Token: 0x06024230 RID: 148016 RVA: 0x00995A90 File Offset: 0x00993C90
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

		// Token: 0x17004A3B RID: 19003
		// (get) Token: 0x06024231 RID: 148017 RVA: 0x00995AA5 File Offset: 0x00993CA5
		// (set) Token: 0x06024232 RID: 148018 RVA: 0x00995AB9 File Offset: 0x00993CB9
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

		// Token: 0x17004A3C RID: 19004
		// (get) Token: 0x06024233 RID: 148019 RVA: 0x00995ACE File Offset: 0x00993CCE
		// (set) Token: 0x06024234 RID: 148020 RVA: 0x00995AE2 File Offset: 0x00993CE2
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

		// Token: 0x17004A3D RID: 19005
		// (get) Token: 0x06024235 RID: 148021 RVA: 0x00995AF7 File Offset: 0x00993CF7
		// (set) Token: 0x06024236 RID: 148022 RVA: 0x00995B0B File Offset: 0x00993D0B
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

		// Token: 0x17004A3E RID: 19006
		// (get) Token: 0x06024237 RID: 148023 RVA: 0x00995B20 File Offset: 0x00993D20
		// (set) Token: 0x06024238 RID: 148024 RVA: 0x00995B30 File Offset: 0x00993D30
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

		// Token: 0x17004A3F RID: 19007
		// (get) Token: 0x06024239 RID: 148025 RVA: 0x00995B41 File Offset: 0x00993D41
		// (set) Token: 0x0602423A RID: 148026 RVA: 0x00995B51 File Offset: 0x00993D51
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

		// Token: 0x17004A40 RID: 19008
		// (get) Token: 0x0602423B RID: 148027 RVA: 0x00995B62 File Offset: 0x00993D62
		// (set) Token: 0x0602423C RID: 148028 RVA: 0x00995B72 File Offset: 0x00993D72
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

		// Token: 0x17004A41 RID: 19009
		// (get) Token: 0x0602423D RID: 148029 RVA: 0x00995B83 File Offset: 0x00993D83
		// (set) Token: 0x0602423E RID: 148030 RVA: 0x00995B93 File Offset: 0x00993D93
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

		// Token: 0x17004A42 RID: 19010
		// (get) Token: 0x0602423F RID: 148031 RVA: 0x00995BA4 File Offset: 0x00993DA4
		// (set) Token: 0x06024240 RID: 148032 RVA: 0x00995BB4 File Offset: 0x00993DB4
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

		// Token: 0x17004A43 RID: 19011
		// (get) Token: 0x06024241 RID: 148033 RVA: 0x00995BC5 File Offset: 0x00993DC5
		// (set) Token: 0x06024242 RID: 148034 RVA: 0x00995BD9 File Offset: 0x00993DD9
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

		// Token: 0x17004A44 RID: 19012
		// (get) Token: 0x06024243 RID: 148035 RVA: 0x00995BEE File Offset: 0x00993DEE
		// (set) Token: 0x06024244 RID: 148036 RVA: 0x00995C02 File Offset: 0x00993E02
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

		// Token: 0x17004A45 RID: 19013
		// (get) Token: 0x06024245 RID: 148037 RVA: 0x00995C17 File Offset: 0x00993E17
		// (set) Token: 0x06024246 RID: 148038 RVA: 0x00995C27 File Offset: 0x00993E27
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

		// Token: 0x17004A46 RID: 19014
		// (get) Token: 0x06024247 RID: 148039 RVA: 0x00995C38 File Offset: 0x00993E38
		// (set) Token: 0x06024248 RID: 148040 RVA: 0x00995C4C File Offset: 0x00993E4C
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

		// Token: 0x17004A47 RID: 19015
		// (get) Token: 0x06024249 RID: 148041 RVA: 0x00995C61 File Offset: 0x00993E61
		// (set) Token: 0x0602424A RID: 148042 RVA: 0x00995C75 File Offset: 0x00993E75
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

		// Token: 0x17004A48 RID: 19016
		// (get) Token: 0x0602424B RID: 148043 RVA: 0x00995C8A File Offset: 0x00993E8A
		// (set) Token: 0x0602424C RID: 148044 RVA: 0x00995C9E File Offset: 0x00993E9E
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

		// Token: 0x17004A49 RID: 19017
		// (get) Token: 0x0602424D RID: 148045 RVA: 0x00995CB3 File Offset: 0x00993EB3
		// (set) Token: 0x0602424E RID: 148046 RVA: 0x00995CC7 File Offset: 0x00993EC7
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

		// Token: 0x17004A4A RID: 19018
		// (get) Token: 0x0602424F RID: 148047 RVA: 0x00995CDC File Offset: 0x00993EDC
		// (set) Token: 0x06024250 RID: 148048 RVA: 0x00995CEC File Offset: 0x00993EEC
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

		// Token: 0x17004A4B RID: 19019
		// (get) Token: 0x06024251 RID: 148049 RVA: 0x00995CFD File Offset: 0x00993EFD
		// (set) Token: 0x06024252 RID: 148050 RVA: 0x00995D0D File Offset: 0x00993F0D
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

		// Token: 0x17004A4C RID: 19020
		// (get) Token: 0x06024253 RID: 148051 RVA: 0x00995D1E File Offset: 0x00993F1E
		// (set) Token: 0x06024254 RID: 148052 RVA: 0x00995D2E File Offset: 0x00993F2E
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

		// Token: 0x17004A4D RID: 19021
		// (get) Token: 0x06024255 RID: 148053 RVA: 0x00995D3F File Offset: 0x00993F3F
		// (set) Token: 0x06024256 RID: 148054 RVA: 0x00995D4F File Offset: 0x00993F4F
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

		// Token: 0x17004A4E RID: 19022
		// (get) Token: 0x06024257 RID: 148055 RVA: 0x00995D60 File Offset: 0x00993F60
		// (set) Token: 0x06024258 RID: 148056 RVA: 0x00995D70 File Offset: 0x00993F70
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

		// Token: 0x17004A4F RID: 19023
		// (get) Token: 0x06024259 RID: 148057 RVA: 0x00995D81 File Offset: 0x00993F81
		// (set) Token: 0x0602425A RID: 148058 RVA: 0x00995D91 File Offset: 0x00993F91
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

		// Token: 0x17004A50 RID: 19024
		// (get) Token: 0x0602425B RID: 148059 RVA: 0x00995DA2 File Offset: 0x00993FA2
		// (set) Token: 0x0602425C RID: 148060 RVA: 0x00995DB6 File Offset: 0x00993FB6
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

		// Token: 0x17004A51 RID: 19025
		// (get) Token: 0x0602425D RID: 148061 RVA: 0x00995DCB File Offset: 0x00993FCB
		// (set) Token: 0x0602425E RID: 148062 RVA: 0x00995DDF File Offset: 0x00993FDF
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

		// Token: 0x17004A52 RID: 19026
		// (get) Token: 0x0602425F RID: 148063 RVA: 0x00995DF4 File Offset: 0x00993FF4
		// (set) Token: 0x06024260 RID: 148064 RVA: 0x00995E08 File Offset: 0x00994008
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

		// Token: 0x17004A53 RID: 19027
		// (get) Token: 0x06024261 RID: 148065 RVA: 0x00995E1D File Offset: 0x0099401D
		// (set) Token: 0x06024262 RID: 148066 RVA: 0x00995E31 File Offset: 0x00994031
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

		// Token: 0x17004A54 RID: 19028
		// (get) Token: 0x06024263 RID: 148067 RVA: 0x00995E46 File Offset: 0x00994046
		// (set) Token: 0x06024264 RID: 148068 RVA: 0x00995E5A File Offset: 0x0099405A
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

		// Token: 0x17004A55 RID: 19029
		// (get) Token: 0x06024265 RID: 148069 RVA: 0x00995E6F File Offset: 0x0099406F
		// (set) Token: 0x06024266 RID: 148070 RVA: 0x00995E7F File Offset: 0x0099407F
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

		// Token: 0x17004A56 RID: 19030
		// (get) Token: 0x06024267 RID: 148071 RVA: 0x00995E90 File Offset: 0x00994090
		// (set) Token: 0x06024268 RID: 148072 RVA: 0x00995EA4 File Offset: 0x009940A4
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

		// Token: 0x17004A57 RID: 19031
		// (get) Token: 0x06024269 RID: 148073 RVA: 0x00995EB9 File Offset: 0x009940B9
		// (set) Token: 0x0602426A RID: 148074 RVA: 0x00995ECD File Offset: 0x009940CD
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

		// Token: 0x17004A58 RID: 19032
		// (get) Token: 0x0602426B RID: 148075 RVA: 0x00995EE4 File Offset: 0x009940E4
		// (set) Token: 0x0602426C RID: 148076 RVA: 0x00995F1D File Offset: 0x0099411D
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

		// Token: 0x17004A59 RID: 19033
		// (get) Token: 0x0602426D RID: 148077 RVA: 0x00995F2C File Offset: 0x0099412C
		// (set) Token: 0x0602426E RID: 148078 RVA: 0x00995F65 File Offset: 0x00994165
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

		// Token: 0x17004A5A RID: 19034
		// (get) Token: 0x0602426F RID: 148079 RVA: 0x00995F74 File Offset: 0x00994174
		// (set) Token: 0x06024270 RID: 148080 RVA: 0x00995FAD File Offset: 0x009941AD
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

		// Token: 0x17004A5B RID: 19035
		// (get) Token: 0x06024271 RID: 148081 RVA: 0x00995FBC File Offset: 0x009941BC
		// (set) Token: 0x06024272 RID: 148082 RVA: 0x00995FF5 File Offset: 0x009941F5
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

		// Token: 0x17004A5C RID: 19036
		// (get) Token: 0x06024273 RID: 148083 RVA: 0x00996004 File Offset: 0x00994204
		// (set) Token: 0x06024274 RID: 148084 RVA: 0x0099603D File Offset: 0x0099423D
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

		// Token: 0x17004A5D RID: 19037
		// (get) Token: 0x06024275 RID: 148085 RVA: 0x0099604C File Offset: 0x0099424C
		// (set) Token: 0x06024276 RID: 148086 RVA: 0x00996085 File Offset: 0x00994285
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

		// Token: 0x17004A5E RID: 19038
		// (get) Token: 0x06024277 RID: 148087 RVA: 0x00996094 File Offset: 0x00994294
		// (set) Token: 0x06024278 RID: 148088 RVA: 0x009960CD File Offset: 0x009942CD
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

		// Token: 0x17004A5F RID: 19039
		// (get) Token: 0x06024279 RID: 148089 RVA: 0x009960DC File Offset: 0x009942DC
		// (set) Token: 0x0602427A RID: 148090 RVA: 0x00996115 File Offset: 0x00994315
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

		// Token: 0x17004A60 RID: 19040
		// (get) Token: 0x0602427B RID: 148091 RVA: 0x00996124 File Offset: 0x00994324
		// (set) Token: 0x0602427C RID: 148092 RVA: 0x0099615D File Offset: 0x0099435D
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

		// Token: 0x17004A61 RID: 19041
		// (get) Token: 0x0602427D RID: 148093 RVA: 0x0099616C File Offset: 0x0099436C
		// (set) Token: 0x0602427E RID: 148094 RVA: 0x009961A5 File Offset: 0x009943A5
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

		// Token: 0x17004A62 RID: 19042
		// (get) Token: 0x0602427F RID: 148095 RVA: 0x009961B4 File Offset: 0x009943B4
		// (set) Token: 0x06024280 RID: 148096 RVA: 0x009961ED File Offset: 0x009943ED
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

		// Token: 0x17004A63 RID: 19043
		// (get) Token: 0x06024281 RID: 148097 RVA: 0x009961FC File Offset: 0x009943FC
		// (set) Token: 0x06024282 RID: 148098 RVA: 0x00996235 File Offset: 0x00994435
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

		// Token: 0x17004A64 RID: 19044
		// (get) Token: 0x06024283 RID: 148099 RVA: 0x00996243 File Offset: 0x00994443
		// (set) Token: 0x06024284 RID: 148100 RVA: 0x00996257 File Offset: 0x00994457
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

		// Token: 0x17004A65 RID: 19045
		// (get) Token: 0x06024285 RID: 148101 RVA: 0x0099626C File Offset: 0x0099446C
		// (set) Token: 0x06024286 RID: 148102 RVA: 0x00996280 File Offset: 0x00994480
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

		// Token: 0x17004A66 RID: 19046
		// (get) Token: 0x06024287 RID: 148103 RVA: 0x00996295 File Offset: 0x00994495
		// (set) Token: 0x06024288 RID: 148104 RVA: 0x009962A9 File Offset: 0x009944A9
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

		// Token: 0x17004A67 RID: 19047
		// (get) Token: 0x06024289 RID: 148105 RVA: 0x009962BE File Offset: 0x009944BE
		// (set) Token: 0x0602428A RID: 148106 RVA: 0x009962D2 File Offset: 0x009944D2
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

		// Token: 0x17004A68 RID: 19048
		// (get) Token: 0x0602428B RID: 148107 RVA: 0x009962E7 File Offset: 0x009944E7
		// (set) Token: 0x0602428C RID: 148108 RVA: 0x009962F7 File Offset: 0x009944F7
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

		// Token: 0x17004A69 RID: 19049
		// (get) Token: 0x0602428D RID: 148109 RVA: 0x00996308 File Offset: 0x00994508
		// (set) Token: 0x0602428E RID: 148110 RVA: 0x00996318 File Offset: 0x00994518
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

		// Token: 0x17004A6A RID: 19050
		// (get) Token: 0x0602428F RID: 148111 RVA: 0x00996329 File Offset: 0x00994529
		// (set) Token: 0x06024290 RID: 148112 RVA: 0x0099633D File Offset: 0x0099453D
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

		// Token: 0x06024291 RID: 148113 RVA: 0x00996352 File Offset: 0x00994552
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x06024292 RID: 148114 RVA: 0x00996366 File Offset: 0x00994566
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024293 RID: 148115 RVA: 0x0099637A File Offset: 0x0099457A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024294 RID: 148116 RVA: 0x0099638F File Offset: 0x0099458F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024295 RID: 148117 RVA: 0x009963A3 File Offset: 0x009945A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024296 RID: 148118 RVA: 0x009963B8 File Offset: 0x009945B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024297 RID: 148119 RVA: 0x00996400 File Offset: 0x00994600
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024298 RID: 148120 RVA: 0x00996448 File Offset: 0x00994648
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024299 RID: 148121 RVA: 0x00996490 File Offset: 0x00994690
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602429A RID: 148122 RVA: 0x009964D7 File Offset: 0x009946D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnGameUserSettingsChange()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__OnGameUserSettingsChange_NativeFunctionPtr, null);
		}

		// Token: 0x0602429B RID: 148123 RVA: 0x009964EC File Offset: 0x009946EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602429C RID: 148124 RVA: 0x00996538 File Offset: 0x00994738
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602429D RID: 148125 RVA: 0x00996584 File Offset: 0x00994784
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVolumeColor(FLinearColor LightColor)
		{
			BP_VolumetricConeLightShaft_InStage_C.__SetVolumeColor_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__SetVolumeColor_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__SetVolumeColor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__SetVolumeColor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LightColor = LightColor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__SetVolumeColor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602429E RID: 148126 RVA: 0x009965CC File Offset: 0x009947CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage(int EntryPoint)
		{
			BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams* ptr = stackalloc BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricConeLightShaft_InStage_C.__ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602429F RID: 148127 RVA: 0x00996616 File Offset: 0x00994816
		protected BP_VolumetricConeLightShaft_InStage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012790 RID: 75664
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/InteractionLight/BP_VolumetricConeLightShaft_InStage.BP_VolumetricConeLightShaft_InStage_C";

		// Token: 0x04012791 RID: 75665
		private static IntPtr _ClassPtr;

		// Token: 0x04012792 RID: 75666
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012793 RID: 75667
		internal static int __PropertyOffset_0;

		// Token: 0x04012794 RID: 75668
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012795 RID: 75669
		internal static int __PropertyOffset_1;

		// Token: 0x04012796 RID: 75670
		internal static int __PropertyOffset_2;

		// Token: 0x04012797 RID: 75671
		internal static int __PropertyOffset_3;

		// Token: 0x04012798 RID: 75672
		internal static int __PropertyOffset_4;

		// Token: 0x04012799 RID: 75673
		internal static int __PropertyOffset_5;

		// Token: 0x0401279A RID: 75674
		internal static int __PropertyOffset_6;

		// Token: 0x0401279B RID: 75675
		internal static int __PropertyOffset_7;

		// Token: 0x0401279C RID: 75676
		internal static int __PropertyOffset_8;

		// Token: 0x0401279D RID: 75677
		internal static int __PropertyOffset_9;

		// Token: 0x0401279E RID: 75678
		internal static int __PropertyOffset_10;

		// Token: 0x0401279F RID: 75679
		internal static int __PropertyOffset_11;

		// Token: 0x040127A0 RID: 75680
		internal static int __PropertyOffset_12;

		// Token: 0x040127A1 RID: 75681
		internal static int __PropertyOffset_13;

		// Token: 0x040127A2 RID: 75682
		internal static int __PropertyOffset_14;

		// Token: 0x040127A3 RID: 75683
		internal static int __PropertyOffset_15;

		// Token: 0x040127A4 RID: 75684
		internal static int __PropertyOffset_16;

		// Token: 0x040127A5 RID: 75685
		internal static int __PropertyOffset_17;

		// Token: 0x040127A6 RID: 75686
		internal static int __PropertyOffset_18;

		// Token: 0x040127A7 RID: 75687
		internal static int __PropertyOffset_19;

		// Token: 0x040127A8 RID: 75688
		internal static int __PropertyOffset_20;

		// Token: 0x040127A9 RID: 75689
		internal static int __PropertyOffset_21;

		// Token: 0x040127AA RID: 75690
		internal static int __PropertyOffset_22;

		// Token: 0x040127AB RID: 75691
		internal static int __PropertyOffset_23;

		// Token: 0x040127AC RID: 75692
		internal static int __PropertyOffset_24;

		// Token: 0x040127AD RID: 75693
		internal static int __PropertyOffset_25;

		// Token: 0x040127AE RID: 75694
		internal static int __PropertyOffset_26;

		// Token: 0x040127AF RID: 75695
		internal static int __PropertyOffset_27;

		// Token: 0x040127B0 RID: 75696
		internal static int __PropertyOffset_28;

		// Token: 0x040127B1 RID: 75697
		internal static int __PropertyOffset_29;

		// Token: 0x040127B2 RID: 75698
		internal static int __PropertyOffset_30;

		// Token: 0x040127B3 RID: 75699
		internal static int __PropertyOffset_31;

		// Token: 0x040127B4 RID: 75700
		internal static int __PropertyOffset_32;

		// Token: 0x040127B5 RID: 75701
		internal static int __PropertyOffset_33;

		// Token: 0x040127B6 RID: 75702
		internal static int __PropertyOffset_34;

		// Token: 0x040127B7 RID: 75703
		internal static int __PropertyOffset_35;

		// Token: 0x040127B8 RID: 75704
		internal static int __PropertyOffset_36;

		// Token: 0x040127B9 RID: 75705
		internal static int __PropertyOffset_37;

		// Token: 0x040127BA RID: 75706
		internal static int __PropertyOffset_38;

		// Token: 0x040127BB RID: 75707
		internal static int __PropertyOffset_39;

		// Token: 0x040127BC RID: 75708
		internal static int __PropertyOffset_40;

		// Token: 0x040127BD RID: 75709
		internal static int __PropertyOffset_41;

		// Token: 0x040127BE RID: 75710
		internal static int __PropertyOffset_42;

		// Token: 0x040127BF RID: 75711
		internal static int __PropertyOffset_43;

		// Token: 0x040127C0 RID: 75712
		internal static int __PropertyOffset_44;

		// Token: 0x040127C1 RID: 75713
		internal static int __PropertyOffset_45;

		// Token: 0x040127C2 RID: 75714
		internal static int __PropertyOffset_46;

		// Token: 0x040127C3 RID: 75715
		internal static int __PropertyOffset_47;

		// Token: 0x040127C4 RID: 75716
		internal static int __PropertyOffset_48;

		// Token: 0x040127C5 RID: 75717
		internal static int __PropertyOffset_49;

		// Token: 0x040127C6 RID: 75718
		internal static int __PropertyOffset_50;

		// Token: 0x040127C7 RID: 75719
		internal static int __PropertyOffset_51;

		// Token: 0x040127C8 RID: 75720
		internal static int __PropertyOffset_52;

		// Token: 0x040127C9 RID: 75721
		internal static int __PropertyOffset_53;

		// Token: 0x040127CA RID: 75722
		private TMap<FName, float> _MaterialInstanceB_Scalars;

		// Token: 0x040127CB RID: 75723
		internal static int __PropertyOffset_54;

		// Token: 0x040127CC RID: 75724
		private TMap<FName, FLinearColor> _MaterialInstanceB_Vectors;

		// Token: 0x040127CD RID: 75725
		internal static int __PropertyOffset_55;

		// Token: 0x040127CE RID: 75726
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _MaterialInstanceB_Textures;

		// Token: 0x040127CF RID: 75727
		internal static int __PropertyOffset_56;

		// Token: 0x040127D0 RID: 75728
		private TMap<FName, float> _MaterialInstance_Scalars;

		// Token: 0x040127D1 RID: 75729
		internal static int __PropertyOffset_57;

		// Token: 0x040127D2 RID: 75730
		private TMap<FName, FLinearColor> _MaterialInstance_Vectors;

		// Token: 0x040127D3 RID: 75731
		internal static int __PropertyOffset_58;

		// Token: 0x040127D4 RID: 75732
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _MaterialInstance_Textures;

		// Token: 0x040127D5 RID: 75733
		internal static int __PropertyOffset_59;

		// Token: 0x040127D6 RID: 75734
		private TMap<FName, float> _LightShaftCone_Scalars;

		// Token: 0x040127D7 RID: 75735
		internal static int __PropertyOffset_60;

		// Token: 0x040127D8 RID: 75736
		private TMap<FName, FLinearColor> _LightShaftCone_Vectors;

		// Token: 0x040127D9 RID: 75737
		internal static int __PropertyOffset_61;

		// Token: 0x040127DA RID: 75738
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _LightShaftCone_Textures;

		// Token: 0x040127DB RID: 75739
		internal static int __PropertyOffset_62;

		// Token: 0x040127DC RID: 75740
		private TMap<FName, float> _LightMaskMaterial_Scalars;

		// Token: 0x040127DD RID: 75741
		internal static int __PropertyOffset_63;

		// Token: 0x040127DE RID: 75742
		private TMap<FName, FLinearColor> _LightMaskMaterial_Vectors;

		// Token: 0x040127DF RID: 75743
		internal static int __PropertyOffset_64;

		// Token: 0x040127E0 RID: 75744
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _LightMaskMaterial_Textures;

		// Token: 0x040127E1 RID: 75745
		internal static int __PropertyOffset_65;

		// Token: 0x040127E2 RID: 75746
		internal static int __PropertyOffset_66;

		// Token: 0x040127E3 RID: 75747
		internal static int __PropertyOffset_67;

		// Token: 0x040127E4 RID: 75748
		internal static int __PropertyOffset_68;

		// Token: 0x040127E5 RID: 75749
		internal static int __PropertyOffset_69;

		// Token: 0x040127E6 RID: 75750
		internal static int __PropertyOffset_70;

		// Token: 0x040127E7 RID: 75751
		internal static int __PropertyOffset_71;

		// Token: 0x040127E8 RID: 75752
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x040127E9 RID: 75753
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040127EA RID: 75754
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040127EB RID: 75755
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040127EC RID: 75756
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040127ED RID: 75757
		private static IntPtr __OnGameUserSettingsChange_NativeFunctionPtr;

		// Token: 0x040127EE RID: 75758
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040127EF RID: 75759
		private static IntPtr __SetVolumeColor_NativeFunctionPtr;

		// Token: 0x040127F0 RID: 75760
		private static IntPtr __ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_NativeFunctionPtr;

		// Token: 0x02009D91 RID: 40337
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032788 RID: 206728
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D92 RID: 40338
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032789 RID: 206729
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D93 RID: 40339
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403278A RID: 206730
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D94 RID: 40340
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SetVolumeColor_FunctionParams
		{
			// Token: 0x0403278B RID: 206731
			[FieldOffset(0)]
			public FLinearColor LightColor;
		}

		// Token: 0x02009D95 RID: 40341
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricConeLightShaft_InStage_FunctionParams
		{
			// Token: 0x0403278C RID: 206732
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
