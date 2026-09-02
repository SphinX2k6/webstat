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
	// Token: 0x02003A8C RID: 14988
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LevelSequenceHalo.BP_LevelSequenceHalo_C")]
	[UnrealStructLayout(1576, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1576)]
	public class BP_LevelSequenceHalo_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F782 RID: 128898 RVA: 0x00912533 File Offset: 0x00910733
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LevelSequenceHalo_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LevelSequenceHalo.BP_LevelSequenceHalo_C");
			}
			return BP_LevelSequenceHalo_C._ClassPtr;
		}

		// Token: 0x0601F783 RID: 128899 RVA: 0x00912558 File Offset: 0x00910758
		public BP_LevelSequenceHalo_C() : this(BuiltinUtils.AllocNativeUObject(BP_LevelSequenceHalo_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F784 RID: 128900 RVA: 0x00912580 File Offset: 0x00910780
		[NullableContext(1)]
		public BP_LevelSequenceHalo_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LevelSequenceHalo_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700301A RID: 12314
		// (get) Token: 0x0601F785 RID: 128901 RVA: 0x009125B4 File Offset: 0x009107B4
		// (set) Token: 0x0601F786 RID: 128902 RVA: 0x009125ED File Offset: 0x009107ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700301B RID: 12315
		// (get) Token: 0x0601F787 RID: 128903 RVA: 0x0091260E File Offset: 0x0091080E
		// (set) Token: 0x0601F788 RID: 128904 RVA: 0x00912622 File Offset: 0x00910822
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700301C RID: 12316
		// (get) Token: 0x0601F789 RID: 128905 RVA: 0x00912637 File Offset: 0x00910837
		// (set) Token: 0x0601F78A RID: 128906 RVA: 0x0091264B File Offset: 0x0091084B
		public unsafe UKuroHaloComponent KuroHalo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroHaloComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700301D RID: 12317
		// (get) Token: 0x0601F78B RID: 128907 RVA: 0x00912660 File Offset: 0x00910860
		// (set) Token: 0x0601F78C RID: 128908 RVA: 0x00912674 File Offset: 0x00910874
		public unsafe UMaterialInstanceDynamic DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700301E RID: 12318
		// (get) Token: 0x0601F78D RID: 128909 RVA: 0x00912689 File Offset: 0x00910889
		// (set) Token: 0x0601F78E RID: 128910 RVA: 0x00912699 File Offset: 0x00910899
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700301F RID: 12319
		// (get) Token: 0x0601F78F RID: 128911 RVA: 0x009126AA File Offset: 0x009108AA
		// (set) Token: 0x0601F790 RID: 128912 RVA: 0x009126BA File Offset: 0x009108BA
		public unsafe bool bAcceptGI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003020 RID: 12320
		// (get) Token: 0x0601F791 RID: 128913 RVA: 0x009126CB File Offset: 0x009108CB
		// (set) Token: 0x0601F792 RID: 128914 RVA: 0x009126DB File Offset: 0x009108DB
		public unsafe float SizeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003021 RID: 12321
		// (get) Token: 0x0601F793 RID: 128915 RVA: 0x009126EC File Offset: 0x009108EC
		// (set) Token: 0x0601F794 RID: 128916 RVA: 0x009126FC File Offset: 0x009108FC
		public unsafe float IntensityScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003022 RID: 12322
		// (get) Token: 0x0601F795 RID: 128917 RVA: 0x0091270D File Offset: 0x0091090D
		// (set) Token: 0x0601F796 RID: 128918 RVA: 0x0091271D File Offset: 0x0091091D
		public unsafe float LightExponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003023 RID: 12323
		// (get) Token: 0x0601F797 RID: 128919 RVA: 0x0091272E File Offset: 0x0091092E
		// (set) Token: 0x0601F798 RID: 128920 RVA: 0x0091273E File Offset: 0x0091093E
		public unsafe float FadeStartRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003024 RID: 12324
		// (get) Token: 0x0601F799 RID: 128921 RVA: 0x0091274F File Offset: 0x0091094F
		// (set) Token: 0x0601F79A RID: 128922 RVA: 0x0091275F File Offset: 0x0091095F
		public unsafe float FadeEndRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003025 RID: 12325
		// (get) Token: 0x0601F79B RID: 128923 RVA: 0x00912770 File Offset: 0x00910970
		// (set) Token: 0x0601F79C RID: 128924 RVA: 0x00912784 File Offset: 0x00910984
		public unsafe UKuroHaloComponent HaloComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroHaloComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003026 RID: 12326
		// (get) Token: 0x0601F79D RID: 128925 RVA: 0x00912799 File Offset: 0x00910999
		// (set) Token: 0x0601F79E RID: 128926 RVA: 0x009127A9 File Offset: 0x009109A9
		public unsafe float DepthFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003027 RID: 12327
		// (get) Token: 0x0601F79F RID: 128927 RVA: 0x009127BA File Offset: 0x009109BA
		// (set) Token: 0x0601F7A0 RID: 128928 RVA: 0x009127CA File Offset: 0x009109CA
		public unsafe float AspectRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003028 RID: 12328
		// (get) Token: 0x0601F7A1 RID: 128929 RVA: 0x009127DB File Offset: 0x009109DB
		// (set) Token: 0x0601F7A2 RID: 128930 RVA: 0x009127EF File Offset: 0x009109EF
		[Nullable(0)]
		public unsafe TEnumAsByte<E_BillboardMode> FaceCameraMode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_14);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003029 RID: 12329
		// (get) Token: 0x0601F7A3 RID: 128931 RVA: 0x00912804 File Offset: 0x00910A04
		// (set) Token: 0x0601F7A4 RID: 128932 RVA: 0x00912818 File Offset: 0x00910A18
		public unsafe UStaticMesh HaloMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700302A RID: 12330
		// (get) Token: 0x0601F7A5 RID: 128933 RVA: 0x0091282D File Offset: 0x00910A2D
		// (set) Token: 0x0601F7A6 RID: 128934 RVA: 0x0091283D File Offset: 0x00910A3D
		public unsafe float MinDrawDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700302B RID: 12331
		// (get) Token: 0x0601F7A7 RID: 128935 RVA: 0x0091284E File Offset: 0x00910A4E
		// (set) Token: 0x0601F7A8 RID: 128936 RVA: 0x0091285E File Offset: 0x00910A5E
		public unsafe float MaxDrawDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700302C RID: 12332
		// (get) Token: 0x0601F7A9 RID: 128937 RVA: 0x0091286F File Offset: 0x00910A6F
		// (set) Token: 0x0601F7AA RID: 128938 RVA: 0x0091287F File Offset: 0x00910A7F
		public unsafe float MinDrawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700302D RID: 12333
		// (get) Token: 0x0601F7AB RID: 128939 RVA: 0x00912890 File Offset: 0x00910A90
		// (set) Token: 0x0601F7AC RID: 128940 RVA: 0x009128A0 File Offset: 0x00910AA0
		public unsafe float MaxDrawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700302E RID: 12334
		// (get) Token: 0x0601F7AD RID: 128941 RVA: 0x009128B1 File Offset: 0x00910AB1
		// (set) Token: 0x0601F7AE RID: 128942 RVA: 0x009128C1 File Offset: 0x00910AC1
		public unsafe float UseShapeTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700302F RID: 12335
		// (get) Token: 0x0601F7AF RID: 128943 RVA: 0x009128D2 File Offset: 0x00910AD2
		// (set) Token: 0x0601F7B0 RID: 128944 RVA: 0x009128E6 File Offset: 0x00910AE6
		public unsafe UTexture2D VolumeTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003030 RID: 12336
		// (get) Token: 0x0601F7B1 RID: 128945 RVA: 0x009128FB File Offset: 0x00910AFB
		// (set) Token: 0x0601F7B2 RID: 128946 RVA: 0x0091290B File Offset: 0x00910B0B
		public unsafe float VolumeTexOnlyR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003031 RID: 12337
		// (get) Token: 0x0601F7B3 RID: 128947 RVA: 0x0091291C File Offset: 0x00910B1C
		// (set) Token: 0x0601F7B4 RID: 128948 RVA: 0x0091292C File Offset: 0x00910B2C
		public unsafe float VolumeTexDesaturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003032 RID: 12338
		// (get) Token: 0x0601F7B5 RID: 128949 RVA: 0x0091293D File Offset: 0x00910B3D
		// (set) Token: 0x0601F7B6 RID: 128950 RVA: 0x00912951 File Offset: 0x00910B51
		public unsafe FLinearColor VolumeTexUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003033 RID: 12339
		// (get) Token: 0x0601F7B7 RID: 128951 RVA: 0x00912966 File Offset: 0x00910B66
		// (set) Token: 0x0601F7B8 RID: 128952 RVA: 0x0091297A File Offset: 0x00910B7A
		public unsafe FLinearColor VolumeTexUVSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003034 RID: 12340
		// (get) Token: 0x0601F7B9 RID: 128953 RVA: 0x0091298F File Offset: 0x00910B8F
		// (set) Token: 0x0601F7BA RID: 128954 RVA: 0x009129A3 File Offset: 0x00910BA3
		public unsafe PD_HaloPointLightConfig_C HaloPointConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_HaloPointLightConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003035 RID: 12341
		// (get) Token: 0x0601F7BB RID: 128955 RVA: 0x009129B8 File Offset: 0x00910BB8
		// (set) Token: 0x0601F7BC RID: 128956 RVA: 0x009129C8 File Offset: 0x00910BC8
		public unsafe KuroFeatureLevel CurrentFeatureLevel
		{
			get
			{
				return (KuroFeatureLevel)(*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_27));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_27) = (byte)value;
			}
		}

		// Token: 0x17003036 RID: 12342
		// (get) Token: 0x0601F7BD RID: 128957 RVA: 0x009129D9 File Offset: 0x00910BD9
		// (set) Token: 0x0601F7BE RID: 128958 RVA: 0x009129E9 File Offset: 0x00910BE9
		public unsafe float LightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003037 RID: 12343
		// (get) Token: 0x0601F7BF RID: 128959 RVA: 0x009129FA File Offset: 0x00910BFA
		// (set) Token: 0x0601F7C0 RID: 128960 RVA: 0x00912A0E File Offset: 0x00910C0E
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003038 RID: 12344
		// (get) Token: 0x0601F7C1 RID: 128961 RVA: 0x00912A23 File Offset: 0x00910C23
		// (set) Token: 0x0601F7C2 RID: 128962 RVA: 0x00912A33 File Offset: 0x00910C33
		public unsafe float LightAttenRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17003039 RID: 12345
		// (get) Token: 0x0601F7C3 RID: 128963 RVA: 0x00912A44 File Offset: 0x00910C44
		// (set) Token: 0x0601F7C4 RID: 128964 RVA: 0x00912A54 File Offset: 0x00910C54
		public unsafe float LightFalloffExponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700303A RID: 12346
		// (get) Token: 0x0601F7C5 RID: 128965 RVA: 0x00912A65 File Offset: 0x00910C65
		// (set) Token: 0x0601F7C6 RID: 128966 RVA: 0x00912A75 File Offset: 0x00910C75
		public unsafe int TranslucentSortPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700303B RID: 12347
		// (get) Token: 0x0601F7C7 RID: 128967 RVA: 0x00912A86 File Offset: 0x00910C86
		// (set) Token: 0x0601F7C8 RID: 128968 RVA: 0x00912A96 File Offset: 0x00910C96
		public unsafe bool UseTranslucentMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700303C RID: 12348
		// (get) Token: 0x0601F7C9 RID: 128969 RVA: 0x00912AA7 File Offset: 0x00910CA7
		// (set) Token: 0x0601F7CA RID: 128970 RVA: 0x00912ABB File Offset: 0x00910CBB
		public unsafe UMaterialInterface MI_PointLightHalo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x1700303D RID: 12349
		// (get) Token: 0x0601F7CB RID: 128971 RVA: 0x00912AD0 File Offset: 0x00910CD0
		// (set) Token: 0x0601F7CC RID: 128972 RVA: 0x00912AE4 File Offset: 0x00910CE4
		public unsafe UMaterialInterface MI_PointLightHalo_Translucent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x1700303E RID: 12350
		// (get) Token: 0x0601F7CD RID: 128973 RVA: 0x00912AF9 File Offset: 0x00910CF9
		// (set) Token: 0x0601F7CE RID: 128974 RVA: 0x00912B0D File Offset: 0x00910D0D
		public unsafe UMaterialInterface MI_PointLightHalo_Translucent_DOF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x1700303F RID: 12351
		// (get) Token: 0x0601F7CF RID: 128975 RVA: 0x00912B22 File Offset: 0x00910D22
		// (set) Token: 0x0601F7D0 RID: 128976 RVA: 0x00912B36 File Offset: 0x00910D36
		public unsafe UMaterialInterface MI_PointLightHalo_Plus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003040 RID: 12352
		// (get) Token: 0x0601F7D1 RID: 128977 RVA: 0x00912B4B File Offset: 0x00910D4B
		// (set) Token: 0x0601F7D2 RID: 128978 RVA: 0x00912B5F File Offset: 0x00910D5F
		public unsafe UMaterialInterface MI_PointLightHalo_Translucent_Plus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003041 RID: 12353
		// (get) Token: 0x0601F7D3 RID: 128979 RVA: 0x00912B74 File Offset: 0x00910D74
		// (set) Token: 0x0601F7D4 RID: 128980 RVA: 0x00912B88 File Offset: 0x00910D88
		public unsafe UMaterialInterface MI_PointLightHalo_Translucent_DOF_Plus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17003042 RID: 12354
		// (get) Token: 0x0601F7D5 RID: 128981 RVA: 0x00912BA0 File Offset: 0x00910DA0
		// (set) Token: 0x0601F7D6 RID: 128982 RVA: 0x00912BD9 File Offset: 0x00910DD9
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_40, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17003043 RID: 12355
		// (get) Token: 0x0601F7D7 RID: 128983 RVA: 0x00912BE8 File Offset: 0x00910DE8
		// (set) Token: 0x0601F7D8 RID: 128984 RVA: 0x00912C21 File Offset: 0x00910E21
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_41, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17003044 RID: 12356
		// (get) Token: 0x0601F7D9 RID: 128985 RVA: 0x00912C30 File Offset: 0x00910E30
		// (set) Token: 0x0601F7DA RID: 128986 RVA: 0x00912C69 File Offset: 0x00910E69
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_42, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17003045 RID: 12357
		// (get) Token: 0x0601F7DB RID: 128987 RVA: 0x00912C77 File Offset: 0x00910E77
		// (set) Token: 0x0601F7DC RID: 128988 RVA: 0x00912C87 File Offset: 0x00910E87
		public unsafe float AcceptGI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17003046 RID: 12358
		// (get) Token: 0x0601F7DD RID: 128989 RVA: 0x00912C98 File Offset: 0x00910E98
		// (set) Token: 0x0601F7DE RID: 128990 RVA: 0x00912CA8 File Offset: 0x00910EA8
		public unsafe bool Use_DOF_Material
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003047 RID: 12359
		// (get) Token: 0x0601F7DF RID: 128991 RVA: 0x00912CB9 File Offset: 0x00910EB9
		// (set) Token: 0x0601F7E0 RID: 128992 RVA: 0x00912CC9 File Offset: 0x00910EC9
		public unsafe bool 移动端低画质以上生效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003048 RID: 12360
		// (get) Token: 0x0601F7E1 RID: 128993 RVA: 0x00912CDA File Offset: 0x00910EDA
		// (set) Token: 0x0601F7E2 RID: 128994 RVA: 0x00912CEE File Offset: 0x00910EEE
		public unsafe UTexture NoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17003049 RID: 12361
		// (get) Token: 0x0601F7E3 RID: 128995 RVA: 0x00912D03 File Offset: 0x00910F03
		// (set) Token: 0x0601F7E4 RID: 128996 RVA: 0x00912D17 File Offset: 0x00910F17
		public unsafe FLinearColor NoiseTexUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x1700304A RID: 12362
		// (get) Token: 0x0601F7E5 RID: 128997 RVA: 0x00912D2C File Offset: 0x00910F2C
		// (set) Token: 0x0601F7E6 RID: 128998 RVA: 0x00912D3C File Offset: 0x00910F3C
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x1700304B RID: 12363
		// (get) Token: 0x0601F7E7 RID: 128999 RVA: 0x00912D4D File Offset: 0x00910F4D
		// (set) Token: 0x0601F7E8 RID: 129000 RVA: 0x00912D5D File Offset: 0x00910F5D
		public unsafe bool 替换材质开关
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LevelSequenceHalo_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700304C RID: 12364
		// (get) Token: 0x0601F7E9 RID: 129001 RVA: 0x00912D6E File Offset: 0x00910F6E
		// (set) Token: 0x0601F7EA RID: 129002 RVA: 0x00912D82 File Offset: 0x00910F82
		public unsafe UMaterialInterface 替换材质
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LevelSequenceHalo_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x0601F7EB RID: 129003 RVA: 0x00912D98 File Offset: 0x00910F98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLightQualityMaterial(UPrimitiveComponent HaloComponent, bool UseTranslucentMaterial, bool Use_DOF_Material, UMaterialInterface M_PointLightHalo_Translucent_DOF, UMaterialInterface M_PointLightHalo_Translucent, UMaterialInterface M_PointLightHalo)
		{
			BP_LevelSequenceHalo_C.__SetLightQualityMaterial_FunctionParams* ptr = stackalloc BP_LevelSequenceHalo_C.__SetLightQualityMaterial_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_LevelSequenceHalo_C.__SetLightQualityMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LevelSequenceHalo_C.__SetLightQualityMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HaloComponent = ((HaloComponent != null) ? HaloComponent.NativePtr : IntPtr.Zero);
			ptr->UseTranslucentMaterial = UseTranslucentMaterial;
			ptr->Use_DOF_Material = Use_DOF_Material;
			ptr->M_PointLightHalo_Translucent_DOF = ((M_PointLightHalo_Translucent_DOF != null) ? M_PointLightHalo_Translucent_DOF.NativePtr : IntPtr.Zero);
			ptr->M_PointLightHalo_Translucent = ((M_PointLightHalo_Translucent != null) ? M_PointLightHalo_Translucent.NativePtr : IntPtr.Zero);
			ptr->M_PointLightHalo = ((M_PointLightHalo != null) ? M_PointLightHalo.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__SetLightQualityMaterial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F7EC RID: 129004 RVA: 0x00912E43 File Offset: 0x00911043
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__UpdateEditor_NativeFunctionPtr, null);
		}

		// Token: 0x0601F7ED RID: 129005 RVA: 0x00912E57 File Offset: 0x00911057
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0601F7EE RID: 129006 RVA: 0x00912E6C File Offset: 0x0091106C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHaloDrawParameters(ref float MinDrawDistance, ref float MaxDrawDistance, ref float MinDrawRange, ref float MaxDrawRange)
		{
			BP_LevelSequenceHalo_C.__GetHaloDrawParameters_FunctionParams* ptr = stackalloc BP_LevelSequenceHalo_C.__GetHaloDrawParameters_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_LevelSequenceHalo_C.__GetHaloDrawParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LevelSequenceHalo_C.__GetHaloDrawParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MinDrawDistance = MinDrawDistance;
			ptr->MaxDrawDistance = MaxDrawDistance;
			ptr->MinDrawRange = MinDrawRange;
			ptr->MaxDrawRange = MaxDrawRange;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__GetHaloDrawParameters_NativeFunctionPtr, (void*)ptr);
			MinDrawDistance = ptr->MinDrawDistance;
			MaxDrawDistance = ptr->MaxDrawDistance;
			MinDrawRange = ptr->MinDrawRange;
			MaxDrawRange = ptr->MaxDrawRange;
		}

		// Token: 0x0601F7EF RID: 129007 RVA: 0x00912EF0 File Offset: 0x009110F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateHaloParameter(bool UpdateComponent)
		{
			BP_LevelSequenceHalo_C.__UpdateHaloParameter_FunctionParams* ptr = stackalloc BP_LevelSequenceHalo_C.__UpdateHaloParameter_FunctionParams[(UIntPtr)303] + 15L / (long)sizeof(BP_LevelSequenceHalo_C.__UpdateHaloParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LevelSequenceHalo_C.__UpdateHaloParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->UpdateComponent = UpdateComponent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__UpdateHaloParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F7F0 RID: 129008 RVA: 0x00912F39 File Offset: 0x00911139
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F7F1 RID: 129009 RVA: 0x00912F4D File Offset: 0x0091114D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F7F2 RID: 129010 RVA: 0x00912F62 File Offset: 0x00911162
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F7F3 RID: 129011 RVA: 0x00912F76 File Offset: 0x00911176
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F7F4 RID: 129012 RVA: 0x00912F8C File Offset: 0x0091118C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LevelSequenceHalo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LevelSequenceHalo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LevelSequenceHalo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LevelSequenceHalo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F7F5 RID: 129013 RVA: 0x00912FD4 File Offset: 0x009111D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LevelSequenceHalo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LevelSequenceHalo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LevelSequenceHalo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LevelSequenceHalo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F7F6 RID: 129014 RVA: 0x0091301C File Offset: 0x0091121C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LevelSequenceHalo(int EntryPoint)
		{
			BP_LevelSequenceHalo_C.__ExecuteUbergraph_BP_LevelSequenceHalo_FunctionParams* ptr = stackalloc BP_LevelSequenceHalo_C.__ExecuteUbergraph_BP_LevelSequenceHalo_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_LevelSequenceHalo_C.__ExecuteUbergraph_BP_LevelSequenceHalo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LevelSequenceHalo_C.__ExecuteUbergraph_BP_LevelSequenceHalo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LevelSequenceHalo_C.__ExecuteUbergraph_BP_LevelSequenceHalo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F7F7 RID: 129015 RVA: 0x00913063 File Offset: 0x00911263
		protected BP_LevelSequenceHalo_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FA19 RID: 64025
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LevelSequenceHalo.BP_LevelSequenceHalo_C";

		// Token: 0x0400FA1A RID: 64026
		private static IntPtr _ClassPtr;

		// Token: 0x0400FA1B RID: 64027
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FA1C RID: 64028
		internal static int __PropertyOffset_0;

		// Token: 0x0400FA1D RID: 64029
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FA1E RID: 64030
		internal static int __PropertyOffset_1;

		// Token: 0x0400FA1F RID: 64031
		internal static int __PropertyOffset_2;

		// Token: 0x0400FA20 RID: 64032
		internal static int __PropertyOffset_3;

		// Token: 0x0400FA21 RID: 64033
		internal static int __PropertyOffset_4;

		// Token: 0x0400FA22 RID: 64034
		internal static int __PropertyOffset_5;

		// Token: 0x0400FA23 RID: 64035
		internal static int __PropertyOffset_6;

		// Token: 0x0400FA24 RID: 64036
		internal static int __PropertyOffset_7;

		// Token: 0x0400FA25 RID: 64037
		internal static int __PropertyOffset_8;

		// Token: 0x0400FA26 RID: 64038
		internal static int __PropertyOffset_9;

		// Token: 0x0400FA27 RID: 64039
		internal static int __PropertyOffset_10;

		// Token: 0x0400FA28 RID: 64040
		internal static int __PropertyOffset_11;

		// Token: 0x0400FA29 RID: 64041
		internal static int __PropertyOffset_12;

		// Token: 0x0400FA2A RID: 64042
		internal static int __PropertyOffset_13;

		// Token: 0x0400FA2B RID: 64043
		internal static int __PropertyOffset_14;

		// Token: 0x0400FA2C RID: 64044
		internal static int __PropertyOffset_15;

		// Token: 0x0400FA2D RID: 64045
		internal static int __PropertyOffset_16;

		// Token: 0x0400FA2E RID: 64046
		internal static int __PropertyOffset_17;

		// Token: 0x0400FA2F RID: 64047
		internal static int __PropertyOffset_18;

		// Token: 0x0400FA30 RID: 64048
		internal static int __PropertyOffset_19;

		// Token: 0x0400FA31 RID: 64049
		internal static int __PropertyOffset_20;

		// Token: 0x0400FA32 RID: 64050
		internal static int __PropertyOffset_21;

		// Token: 0x0400FA33 RID: 64051
		internal static int __PropertyOffset_22;

		// Token: 0x0400FA34 RID: 64052
		internal static int __PropertyOffset_23;

		// Token: 0x0400FA35 RID: 64053
		internal static int __PropertyOffset_24;

		// Token: 0x0400FA36 RID: 64054
		internal static int __PropertyOffset_25;

		// Token: 0x0400FA37 RID: 64055
		internal static int __PropertyOffset_26;

		// Token: 0x0400FA38 RID: 64056
		internal static int __PropertyOffset_27;

		// Token: 0x0400FA39 RID: 64057
		internal static int __PropertyOffset_28;

		// Token: 0x0400FA3A RID: 64058
		internal static int __PropertyOffset_29;

		// Token: 0x0400FA3B RID: 64059
		internal static int __PropertyOffset_30;

		// Token: 0x0400FA3C RID: 64060
		internal static int __PropertyOffset_31;

		// Token: 0x0400FA3D RID: 64061
		internal static int __PropertyOffset_32;

		// Token: 0x0400FA3E RID: 64062
		internal static int __PropertyOffset_33;

		// Token: 0x0400FA3F RID: 64063
		internal static int __PropertyOffset_34;

		// Token: 0x0400FA40 RID: 64064
		internal static int __PropertyOffset_35;

		// Token: 0x0400FA41 RID: 64065
		internal static int __PropertyOffset_36;

		// Token: 0x0400FA42 RID: 64066
		internal static int __PropertyOffset_37;

		// Token: 0x0400FA43 RID: 64067
		internal static int __PropertyOffset_38;

		// Token: 0x0400FA44 RID: 64068
		internal static int __PropertyOffset_39;

		// Token: 0x0400FA45 RID: 64069
		internal static int __PropertyOffset_40;

		// Token: 0x0400FA46 RID: 64070
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FA47 RID: 64071
		internal static int __PropertyOffset_41;

		// Token: 0x0400FA48 RID: 64072
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FA49 RID: 64073
		internal static int __PropertyOffset_42;

		// Token: 0x0400FA4A RID: 64074
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FA4B RID: 64075
		internal static int __PropertyOffset_43;

		// Token: 0x0400FA4C RID: 64076
		internal static int __PropertyOffset_44;

		// Token: 0x0400FA4D RID: 64077
		internal static int __PropertyOffset_45;

		// Token: 0x0400FA4E RID: 64078
		internal static int __PropertyOffset_46;

		// Token: 0x0400FA4F RID: 64079
		internal static int __PropertyOffset_47;

		// Token: 0x0400FA50 RID: 64080
		internal static int __PropertyOffset_48;

		// Token: 0x0400FA51 RID: 64081
		internal static int __PropertyOffset_49;

		// Token: 0x0400FA52 RID: 64082
		internal static int __PropertyOffset_50;

		// Token: 0x0400FA53 RID: 64083
		private static IntPtr __SetLightQualityMaterial_NativeFunctionPtr;

		// Token: 0x0400FA54 RID: 64084
		private static IntPtr __UpdateEditor_NativeFunctionPtr;

		// Token: 0x0400FA55 RID: 64085
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0400FA56 RID: 64086
		private static IntPtr __GetHaloDrawParameters_NativeFunctionPtr;

		// Token: 0x0400FA57 RID: 64087
		private static IntPtr __UpdateHaloParameter_NativeFunctionPtr;

		// Token: 0x0400FA58 RID: 64088
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FA59 RID: 64089
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FA5A RID: 64090
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FA5B RID: 64091
		private static IntPtr __ExecuteUbergraph_BP_LevelSequenceHalo_NativeFunctionPtr;

		// Token: 0x020098E2 RID: 39138
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __SetLightQualityMaterial_FunctionParams
		{
			// Token: 0x04031F37 RID: 204599
			[FieldOffset(0)]
			public IntPtr HaloComponent;

			// Token: 0x04031F38 RID: 204600
			[FieldOffset(8)]
			public bool UseTranslucentMaterial;

			// Token: 0x04031F39 RID: 204601
			[FieldOffset(9)]
			public bool Use_DOF_Material;

			// Token: 0x04031F3A RID: 204602
			[FieldOffset(16)]
			public IntPtr M_PointLightHalo_Translucent_DOF;

			// Token: 0x04031F3B RID: 204603
			[FieldOffset(24)]
			public IntPtr M_PointLightHalo_Translucent;

			// Token: 0x04031F3C RID: 204604
			[FieldOffset(32)]
			public IntPtr M_PointLightHalo;
		}

		// Token: 0x020098E3 RID: 39139
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetHaloDrawParameters_FunctionParams
		{
			// Token: 0x04031F3D RID: 204605
			[FieldOffset(0)]
			public float MinDrawDistance;

			// Token: 0x04031F3E RID: 204606
			[FieldOffset(4)]
			public float MaxDrawDistance;

			// Token: 0x04031F3F RID: 204607
			[FieldOffset(8)]
			public float MinDrawRange;

			// Token: 0x04031F40 RID: 204608
			[FieldOffset(12)]
			public float MaxDrawRange;
		}

		// Token: 0x020098E4 RID: 39140
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 288)]
		protected ref struct __UpdateHaloParameter_FunctionParams
		{
			// Token: 0x04031F41 RID: 204609
			[FieldOffset(0)]
			public bool UpdateComponent;
		}

		// Token: 0x020098E5 RID: 39141
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F42 RID: 204610
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098E6 RID: 39142
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_LevelSequenceHalo_FunctionParams
		{
			// Token: 0x04031F43 RID: 204611
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
