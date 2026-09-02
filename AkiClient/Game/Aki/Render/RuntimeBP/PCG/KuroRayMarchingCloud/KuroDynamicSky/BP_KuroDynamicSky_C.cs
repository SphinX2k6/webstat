using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.KuroDynamicSky
{
	// Token: 0x02003BF0 RID: 15344
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/KuroDynamicSky/BP_KuroDynamicSky.BP_KuroDynamicSky_C")]
	[UnrealStructLayout(2064, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2064)]
	public class BP_KuroDynamicSky_C : AKuroBPCustomCookActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022992 RID: 141714 RVA: 0x00969B20 File Offset: 0x00967D20
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroDynamicSky_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/KuroDynamicSky/BP_KuroDynamicSky.BP_KuroDynamicSky_C");
			}
			return BP_KuroDynamicSky_C._ClassPtr;
		}

		// Token: 0x06022993 RID: 141715 RVA: 0x00969B44 File Offset: 0x00967D44
		public BP_KuroDynamicSky_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroDynamicSky_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022994 RID: 141716 RVA: 0x00969B6C File Offset: 0x00967D6C
		[NullableContext(1)]
		public BP_KuroDynamicSky_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroDynamicSky_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170041AF RID: 16815
		// (get) Token: 0x06022995 RID: 141717 RVA: 0x00969BA0 File Offset: 0x00967DA0
		// (set) Token: 0x06022996 RID: 141718 RVA: 0x00969BD9 File Offset: 0x00967DD9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170041B0 RID: 16816
		// (get) Token: 0x06022997 RID: 141719 RVA: 0x00969BFA File Offset: 0x00967DFA
		// (set) Token: 0x06022998 RID: 141720 RVA: 0x00969C0E File Offset: 0x00967E0E
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170041B1 RID: 16817
		// (get) Token: 0x06022999 RID: 141721 RVA: 0x00969C23 File Offset: 0x00967E23
		// (set) Token: 0x0602299A RID: 141722 RVA: 0x00969C37 File Offset: 0x00967E37
		public unsafe UNiagaraComponent NS_DynamicSkyThunder
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170041B2 RID: 16818
		// (get) Token: 0x0602299B RID: 141723 RVA: 0x00969C4C File Offset: 0x00967E4C
		// (set) Token: 0x0602299C RID: 141724 RVA: 0x00969C60 File Offset: 0x00967E60
		public unsafe UStaticMeshComponent SkyCloud_Mobile
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170041B3 RID: 16819
		// (get) Token: 0x0602299D RID: 141725 RVA: 0x00969C75 File Offset: 0x00967E75
		// (set) Token: 0x0602299E RID: 141726 RVA: 0x00969C89 File Offset: 0x00967E89
		public unsafe UVolumetricCloudComponent VolumetricCloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVolumetricCloudComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170041B4 RID: 16820
		// (get) Token: 0x0602299F RID: 141727 RVA: 0x00969C9E File Offset: 0x00967E9E
		// (set) Token: 0x060229A0 RID: 141728 RVA: 0x00969CB2 File Offset: 0x00967EB2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170041B5 RID: 16821
		// (get) Token: 0x060229A1 RID: 141729 RVA: 0x00969CC7 File Offset: 0x00967EC7
		// (set) Token: 0x060229A2 RID: 141730 RVA: 0x00969CD7 File Offset: 0x00967ED7
		public unsafe float Shadow_Sample_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170041B6 RID: 16822
		// (get) Token: 0x060229A3 RID: 141731 RVA: 0x00969CE8 File Offset: 0x00967EE8
		// (set) Token: 0x060229A4 RID: 141732 RVA: 0x00969CF8 File Offset: 0x00967EF8
		public unsafe float Distance_to_Sample_Max_Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170041B7 RID: 16823
		// (get) Token: 0x060229A5 RID: 141733 RVA: 0x00969D09 File Offset: 0x00967F09
		// (set) Token: 0x060229A6 RID: 141734 RVA: 0x00969D19 File Offset: 0x00967F19
		public unsafe float Shadow_Tracing_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170041B8 RID: 16824
		// (get) Token: 0x060229A7 RID: 141735 RVA: 0x00969D2A File Offset: 0x00967F2A
		// (set) Token: 0x060229A8 RID: 141736 RVA: 0x00969D3A File Offset: 0x00967F3A
		public unsafe float Tracing_Max_Start_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170041B9 RID: 16825
		// (get) Token: 0x060229A9 RID: 141737 RVA: 0x00969D4B File Offset: 0x00967F4B
		// (set) Token: 0x060229AA RID: 141738 RVA: 0x00969D5B File Offset: 0x00967F5B
		public unsafe float Tracing_Max_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170041BA RID: 16826
		// (get) Token: 0x060229AB RID: 141739 RVA: 0x00969D6C File Offset: 0x00967F6C
		// (set) Token: 0x060229AC RID: 141740 RVA: 0x00969D7C File Offset: 0x00967F7C
		public unsafe float View_Sample_Count_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170041BB RID: 16827
		// (get) Token: 0x060229AD RID: 141741 RVA: 0x00969D8D File Offset: 0x00967F8D
		// (set) Token: 0x060229AE RID: 141742 RVA: 0x00969D9D File Offset: 0x00967F9D
		public unsafe float Layer_Height_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170041BC RID: 16828
		// (get) Token: 0x060229AF RID: 141743 RVA: 0x00969DAE File Offset: 0x00967FAE
		// (set) Token: 0x060229B0 RID: 141744 RVA: 0x00969DBE File Offset: 0x00967FBE
		public unsafe float Bottom_Altitude
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170041BD RID: 16829
		// (get) Token: 0x060229B1 RID: 141745 RVA: 0x00969DCF File Offset: 0x00967FCF
		// (set) Token: 0x060229B2 RID: 141746 RVA: 0x00969DDF File Offset: 0x00967FDF
		public unsafe float SubNoise_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170041BE RID: 16830
		// (get) Token: 0x060229B3 RID: 141747 RVA: 0x00969DF0 File Offset: 0x00967FF0
		// (set) Token: 0x060229B4 RID: 141748 RVA: 0x00969E00 File Offset: 0x00968000
		public unsafe float High_Frequency_Noise_Layer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170041BF RID: 16831
		// (get) Token: 0x060229B5 RID: 141749 RVA: 0x00969E11 File Offset: 0x00968011
		// (set) Token: 0x060229B6 RID: 141750 RVA: 0x00969E21 File Offset: 0x00968021
		public unsafe float Extinction_Scale_Top
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170041C0 RID: 16832
		// (get) Token: 0x060229B7 RID: 141751 RVA: 0x00969E32 File Offset: 0x00968032
		// (set) Token: 0x060229B8 RID: 141752 RVA: 0x00969E42 File Offset: 0x00968042
		public unsafe float Extinction_Scale_Bottom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170041C1 RID: 16833
		// (get) Token: 0x060229B9 RID: 141753 RVA: 0x00969E53 File Offset: 0x00968053
		// (set) Token: 0x060229BA RID: 141754 RVA: 0x00969E63 File Offset: 0x00968063
		public unsafe float SubNoise_Erosion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170041C2 RID: 16834
		// (get) Token: 0x060229BB RID: 141755 RVA: 0x00969E74 File Offset: 0x00968074
		// (set) Token: 0x060229BC RID: 141756 RVA: 0x00969E84 File Offset: 0x00968084
		public unsafe float Multiscattering_Occlusion_Factor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170041C3 RID: 16835
		// (get) Token: 0x060229BD RID: 141757 RVA: 0x00969E95 File Offset: 0x00968095
		// (set) Token: 0x060229BE RID: 141758 RVA: 0x00969EA5 File Offset: 0x009680A5
		public unsafe float MultiScattering_Eccentricity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170041C4 RID: 16836
		// (get) Token: 0x060229BF RID: 141759 RVA: 0x00969EB6 File Offset: 0x009680B6
		// (set) Token: 0x060229C0 RID: 141760 RVA: 0x00969EC6 File Offset: 0x009680C6
		public unsafe float Volumetric_Clouds_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170041C5 RID: 16837
		// (get) Token: 0x060229C1 RID: 141761 RVA: 0x00969ED7 File Offset: 0x009680D7
		// (set) Token: 0x060229C2 RID: 141762 RVA: 0x00969EE7 File Offset: 0x009680E7
		public unsafe float Cloud_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170041C6 RID: 16838
		// (get) Token: 0x060229C3 RID: 141763 RVA: 0x00969EF8 File Offset: 0x009680F8
		// (set) Token: 0x060229C4 RID: 141764 RVA: 0x00969F08 File Offset: 0x00968108
		public unsafe float Phase_G
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170041C7 RID: 16839
		// (get) Token: 0x060229C5 RID: 141765 RVA: 0x00969F19 File Offset: 0x00968119
		// (set) Token: 0x060229C6 RID: 141766 RVA: 0x00969F29 File Offset: 0x00968129
		public unsafe float Phase_G_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170041C8 RID: 16840
		// (get) Token: 0x060229C7 RID: 141767 RVA: 0x00969F3A File Offset: 0x0096813A
		// (set) Token: 0x060229C8 RID: 141768 RVA: 0x00969F4A File Offset: 0x0096814A
		public unsafe float Multiscattering_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170041C9 RID: 16841
		// (get) Token: 0x060229C9 RID: 141769 RVA: 0x00969F5B File Offset: 0x0096815B
		// (set) Token: 0x060229CA RID: 141770 RVA: 0x00969F6B File Offset: 0x0096816B
		public unsafe float Overall_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170041CA RID: 16842
		// (get) Token: 0x060229CB RID: 141771 RVA: 0x00969F7C File Offset: 0x0096817C
		// (set) Token: 0x060229CC RID: 141772 RVA: 0x00969F90 File Offset: 0x00968190
		public unsafe FLinearColor Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170041CB RID: 16843
		// (get) Token: 0x060229CD RID: 141773 RVA: 0x00969FA5 File Offset: 0x009681A5
		// (set) Token: 0x060229CE RID: 141774 RVA: 0x00969FB5 File Offset: 0x009681B5
		public unsafe float Base_Clouds_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170041CC RID: 16844
		// (get) Token: 0x060229CF RID: 141775 RVA: 0x00969FC6 File Offset: 0x009681C6
		// (set) Token: 0x060229D0 RID: 141776 RVA: 0x00969FDA File Offset: 0x009681DA
		public unsafe UMaterialInterface Mateiral
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x170041CD RID: 16845
		// (get) Token: 0x060229D1 RID: 141777 RVA: 0x00969FEF File Offset: 0x009681EF
		// (set) Token: 0x060229D2 RID: 141778 RVA: 0x00969FFF File Offset: 0x009681FF
		public unsafe bool bPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170041CE RID: 16846
		// (get) Token: 0x060229D3 RID: 141779 RVA: 0x0096A010 File Offset: 0x00968210
		// (set) Token: 0x060229D4 RID: 141780 RVA: 0x0096A020 File Offset: 0x00968220
		public unsafe float Custom_Lighting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170041CF RID: 16847
		// (get) Token: 0x060229D5 RID: 141781 RVA: 0x0096A031 File Offset: 0x00968231
		// (set) Token: 0x060229D6 RID: 141782 RVA: 0x0096A045 File Offset: 0x00968245
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170041D0 RID: 16848
		// (get) Token: 0x060229D7 RID: 141783 RVA: 0x0096A05A File Offset: 0x0096825A
		// (set) Token: 0x060229D8 RID: 141784 RVA: 0x0096A06A File Offset: 0x0096826A
		public unsafe float VolumeCloudMainLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170041D1 RID: 16849
		// (get) Token: 0x060229D9 RID: 141785 RVA: 0x0096A07B File Offset: 0x0096827B
		// (set) Token: 0x060229DA RID: 141786 RVA: 0x0096A08F File Offset: 0x0096828F
		public unsafe FLinearColor ShadowColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x170041D2 RID: 16850
		// (get) Token: 0x060229DB RID: 141787 RVA: 0x0096A0A4 File Offset: 0x009682A4
		// (set) Token: 0x060229DC RID: 141788 RVA: 0x0096A0B4 File Offset: 0x009682B4
		public unsafe float VolumeCloudSkyLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x170041D3 RID: 16851
		// (get) Token: 0x060229DD RID: 141789 RVA: 0x0096A0C5 File Offset: 0x009682C5
		// (set) Token: 0x060229DE RID: 141790 RVA: 0x0096A0D9 File Offset: 0x009682D9
		public unsafe UMaterialInterface Mateiral_Mobile
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x170041D4 RID: 16852
		// (get) Token: 0x060229DF RID: 141791 RVA: 0x0096A0F0 File Offset: 0x009682F0
		// (set) Token: 0x060229E0 RID: 141792 RVA: 0x0096A129 File Offset: 0x00968329
		[Nullable(1)]
		public FKuroSkyVolumetricCloudSetting Setting
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroSkyVolumetricCloudSetting result;
				if ((result = this._Setting) == null)
				{
					result = (this._Setting = new FKuroSkyVolumetricCloudSetting(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_37, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroSkyVolumetricCloudSetting.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170041D5 RID: 16853
		// (get) Token: 0x060229E1 RID: 141793 RVA: 0x0096A14A File Offset: 0x0096834A
		// (set) Token: 0x060229E2 RID: 141794 RVA: 0x0096A15E File Offset: 0x0096835E
		public unsafe FLinearColor OffsetFromSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x170041D6 RID: 16854
		// (get) Token: 0x060229E3 RID: 141795 RVA: 0x0096A173 File Offset: 0x00968373
		// (set) Token: 0x060229E4 RID: 141796 RVA: 0x0096A187 File Offset: 0x00968387
		public unsafe FVector2D ThunderRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x170041D7 RID: 16855
		// (get) Token: 0x060229E5 RID: 141797 RVA: 0x0096A19C File Offset: 0x0096839C
		// (set) Token: 0x060229E6 RID: 141798 RVA: 0x0096A1B0 File Offset: 0x009683B0
		public unsafe FVectorDouble ThunderCenterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170041D8 RID: 16856
		// (get) Token: 0x060229E7 RID: 141799 RVA: 0x0096A1C5 File Offset: 0x009683C5
		// (set) Token: 0x060229E8 RID: 141800 RVA: 0x0096A1D9 File Offset: 0x009683D9
		public unsafe UCurveFloat ThunderCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x170041D9 RID: 16857
		// (get) Token: 0x060229E9 RID: 141801 RVA: 0x0096A1EE File Offset: 0x009683EE
		// (set) Token: 0x060229EA RID: 141802 RVA: 0x0096A202 File Offset: 0x00968402
		public unsafe FVectorDouble ThunderSpawnPoistion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170041DA RID: 16858
		// (get) Token: 0x060229EB RID: 141803 RVA: 0x0096A217 File Offset: 0x00968417
		// (set) Token: 0x060229EC RID: 141804 RVA: 0x0096A227 File Offset: 0x00968427
		public unsafe bool bStartThunder
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x170041DB RID: 16859
		// (get) Token: 0x060229ED RID: 141805 RVA: 0x0096A238 File Offset: 0x00968438
		// (set) Token: 0x060229EE RID: 141806 RVA: 0x0096A248 File Offset: 0x00968448
		public unsafe float ThunderDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170041DC RID: 16860
		// (get) Token: 0x060229EF RID: 141807 RVA: 0x0096A259 File Offset: 0x00968459
		// (set) Token: 0x060229F0 RID: 141808 RVA: 0x0096A26D File Offset: 0x0096846D
		public unsafe FLinearColor ThunderColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170041DD RID: 16861
		// (get) Token: 0x060229F1 RID: 141809 RVA: 0x0096A282 File Offset: 0x00968482
		// (set) Token: 0x060229F2 RID: 141810 RVA: 0x0096A292 File Offset: 0x00968492
		public unsafe float ThunderTimeCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170041DE RID: 16862
		// (get) Token: 0x060229F3 RID: 141811 RVA: 0x0096A2A3 File Offset: 0x009684A3
		// (set) Token: 0x060229F4 RID: 141812 RVA: 0x0096A2B3 File Offset: 0x009684B3
		public unsafe float ThunderIntervalMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170041DF RID: 16863
		// (get) Token: 0x060229F5 RID: 141813 RVA: 0x0096A2C4 File Offset: 0x009684C4
		// (set) Token: 0x060229F6 RID: 141814 RVA: 0x0096A2D4 File Offset: 0x009684D4
		public unsafe float ThunderIntervalCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x170041E0 RID: 16864
		// (get) Token: 0x060229F7 RID: 141815 RVA: 0x0096A2E5 File Offset: 0x009684E5
		// (set) Token: 0x060229F8 RID: 141816 RVA: 0x0096A2F5 File Offset: 0x009684F5
		public unsafe float ThunderIntervalMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x170041E1 RID: 16865
		// (get) Token: 0x060229F9 RID: 141817 RVA: 0x0096A306 File Offset: 0x00968506
		// (set) Token: 0x060229FA RID: 141818 RVA: 0x0096A316 File Offset: 0x00968516
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x170041E2 RID: 16866
		// (get) Token: 0x060229FB RID: 141819 RVA: 0x0096A327 File Offset: 0x00968527
		// (set) Token: 0x060229FC RID: 141820 RVA: 0x0096A337 File Offset: 0x00968537
		public unsafe bool bUseCameraAsThunderCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_51) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_51) = (value ? 1 : 0);
			}
		}

		// Token: 0x170041E3 RID: 16867
		// (get) Token: 0x060229FD RID: 141821 RVA: 0x0096A348 File Offset: 0x00968548
		// (set) Token: 0x060229FE RID: 141822 RVA: 0x0096A35C File Offset: 0x0096855C
		public unsafe UAkAudioEvent ThunderAudio
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_52);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x170041E4 RID: 16868
		// (get) Token: 0x060229FF RID: 141823 RVA: 0x0096A371 File Offset: 0x00968571
		// (set) Token: 0x06022A00 RID: 141824 RVA: 0x0096A381 File Offset: 0x00968581
		public unsafe bool bEnableThunder
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x170041E5 RID: 16869
		// (get) Token: 0x06022A01 RID: 141825 RVA: 0x0096A392 File Offset: 0x00968592
		// (set) Token: 0x06022A02 RID: 141826 RVA: 0x0096A3A2 File Offset: 0x009685A2
		public unsafe bool bPlayAudio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x170041E6 RID: 16870
		// (get) Token: 0x06022A03 RID: 141827 RVA: 0x0096A3B3 File Offset: 0x009685B3
		// (set) Token: 0x06022A04 RID: 141828 RVA: 0x0096A3C3 File Offset: 0x009685C3
		public unsafe bool bReseted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x170041E7 RID: 16871
		// (get) Token: 0x06022A05 RID: 141829 RVA: 0x0096A3D4 File Offset: 0x009685D4
		// (set) Token: 0x06022A06 RID: 141830 RVA: 0x0096A3E4 File Offset: 0x009685E4
		public unsafe float CamerForwardOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x170041E8 RID: 16872
		// (get) Token: 0x06022A07 RID: 141831 RVA: 0x0096A3F5 File Offset: 0x009685F5
		// (set) Token: 0x06022A08 RID: 141832 RVA: 0x0096A409 File Offset: 0x00968609
		public unsafe FTransform Out_Camera_Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x170041E9 RID: 16873
		// (get) Token: 0x06022A09 RID: 141833 RVA: 0x0096A41E File Offset: 0x0096861E
		// (set) Token: 0x06022A0A RID: 141834 RVA: 0x0096A42E File Offset: 0x0096862E
		public unsafe bool bEnablePostprocess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_58) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_58) = (value ? 1 : 0);
			}
		}

		// Token: 0x170041EA RID: 16874
		// (get) Token: 0x06022A0B RID: 141835 RVA: 0x0096A43F File Offset: 0x0096863F
		// (set) Token: 0x06022A0C RID: 141836 RVA: 0x0096A44F File Offset: 0x0096864F
		public unsafe float TimeLerpStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroDynamicSky_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x170041EB RID: 16875
		// (get) Token: 0x06022A0D RID: 141837 RVA: 0x0096A460 File Offset: 0x00968660
		// (set) Token: 0x06022A0E RID: 141838 RVA: 0x0096A474 File Offset: 0x00968674
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroDynamicSky_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x06022A0F RID: 141839 RVA: 0x0096A489 File Offset: 0x00968689
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetThunder()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__ResetThunder_NativeFunctionPtr, null);
		}

		// Token: 0x06022A10 RID: 141840 RVA: 0x0096A49D File Offset: 0x0096869D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TryToSpawnThunder()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__TryToSpawnThunder_NativeFunctionPtr, null);
		}

		// Token: 0x06022A11 RID: 141841 RVA: 0x0096A4B1 File Offset: 0x009686B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateThunder()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__UpdateThunder_NativeFunctionPtr, null);
		}

		// Token: 0x06022A12 RID: 141842 RVA: 0x0096A4C5 File Offset: 0x009686C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SpawnThunder()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__SpawnThunder_NativeFunctionPtr, null);
		}

		// Token: 0x06022A13 RID: 141843 RVA: 0x0096A4D9 File Offset: 0x009686D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_Params_from_Setting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__Init_Params_from_Setting_NativeFunctionPtr, null);
		}

		// Token: 0x06022A14 RID: 141844 RVA: 0x0096A4ED File Offset: 0x009686ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__UpdateCloudParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022A15 RID: 141845 RVA: 0x0096A501 File Offset: 0x00968701
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022A16 RID: 141846 RVA: 0x0096A515 File Offset: 0x00968715
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroDynamicSky_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A17 RID: 141847 RVA: 0x0096A52A File Offset: 0x0096872A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022A18 RID: 141848 RVA: 0x0096A53E File Offset: 0x0096873E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroDynamicSky_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A19 RID: 141849 RVA: 0x0096A553 File Offset: 0x00968753
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForMobile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__BeforeCookForMobile_NativeFunctionPtr, null);
		}

		// Token: 0x06022A1A RID: 141850 RVA: 0x0096A567 File Offset: 0x00968767
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForMobile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroDynamicSky_C.__BeforeCookForMobile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A1B RID: 141851 RVA: 0x0096A57C File Offset: 0x0096877C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__BeforeCookForPC_NativeFunctionPtr, null);
		}

		// Token: 0x06022A1C RID: 141852 RVA: 0x0096A590 File Offset: 0x00968790
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForPC_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroDynamicSky_C.__BeforeCookForPC_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A1D RID: 141853 RVA: 0x0096A5A5 File Offset: 0x009687A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeSave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroDynamicSky_C.__BeforeSave_NativeFunctionPtr, null);
		}

		// Token: 0x06022A1E RID: 141854 RVA: 0x0096A5B9 File Offset: 0x009687B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BeforeSave_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroDynamicSky_C.__BeforeSave_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A1F RID: 141855 RVA: 0x0096A5D0 File Offset: 0x009687D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroDynamicSky(int EntryPoint)
		{
			BP_KuroDynamicSky_C.__ExecuteUbergraph_BP_KuroDynamicSky_FunctionParams* ptr = stackalloc BP_KuroDynamicSky_C.__ExecuteUbergraph_BP_KuroDynamicSky_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_KuroDynamicSky_C.__ExecuteUbergraph_BP_KuroDynamicSky_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroDynamicSky_C.__ExecuteUbergraph_BP_KuroDynamicSky_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroDynamicSky_C.__ExecuteUbergraph_BP_KuroDynamicSky_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022A20 RID: 141856 RVA: 0x0096A617 File Offset: 0x00968817
		protected BP_KuroDynamicSky_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011875 RID: 71797
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/KuroDynamicSky/BP_KuroDynamicSky.BP_KuroDynamicSky_C";

		// Token: 0x04011876 RID: 71798
		private static IntPtr _ClassPtr;

		// Token: 0x04011877 RID: 71799
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011878 RID: 71800
		internal static int __PropertyOffset_0;

		// Token: 0x04011879 RID: 71801
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401187A RID: 71802
		internal static int __PropertyOffset_1;

		// Token: 0x0401187B RID: 71803
		internal static int __PropertyOffset_2;

		// Token: 0x0401187C RID: 71804
		internal static int __PropertyOffset_3;

		// Token: 0x0401187D RID: 71805
		internal static int __PropertyOffset_4;

		// Token: 0x0401187E RID: 71806
		internal static int __PropertyOffset_5;

		// Token: 0x0401187F RID: 71807
		internal static int __PropertyOffset_6;

		// Token: 0x04011880 RID: 71808
		internal static int __PropertyOffset_7;

		// Token: 0x04011881 RID: 71809
		internal static int __PropertyOffset_8;

		// Token: 0x04011882 RID: 71810
		internal static int __PropertyOffset_9;

		// Token: 0x04011883 RID: 71811
		internal static int __PropertyOffset_10;

		// Token: 0x04011884 RID: 71812
		internal static int __PropertyOffset_11;

		// Token: 0x04011885 RID: 71813
		internal static int __PropertyOffset_12;

		// Token: 0x04011886 RID: 71814
		internal static int __PropertyOffset_13;

		// Token: 0x04011887 RID: 71815
		internal static int __PropertyOffset_14;

		// Token: 0x04011888 RID: 71816
		internal static int __PropertyOffset_15;

		// Token: 0x04011889 RID: 71817
		internal static int __PropertyOffset_16;

		// Token: 0x0401188A RID: 71818
		internal static int __PropertyOffset_17;

		// Token: 0x0401188B RID: 71819
		internal static int __PropertyOffset_18;

		// Token: 0x0401188C RID: 71820
		internal static int __PropertyOffset_19;

		// Token: 0x0401188D RID: 71821
		internal static int __PropertyOffset_20;

		// Token: 0x0401188E RID: 71822
		internal static int __PropertyOffset_21;

		// Token: 0x0401188F RID: 71823
		internal static int __PropertyOffset_22;

		// Token: 0x04011890 RID: 71824
		internal static int __PropertyOffset_23;

		// Token: 0x04011891 RID: 71825
		internal static int __PropertyOffset_24;

		// Token: 0x04011892 RID: 71826
		internal static int __PropertyOffset_25;

		// Token: 0x04011893 RID: 71827
		internal static int __PropertyOffset_26;

		// Token: 0x04011894 RID: 71828
		internal static int __PropertyOffset_27;

		// Token: 0x04011895 RID: 71829
		internal static int __PropertyOffset_28;

		// Token: 0x04011896 RID: 71830
		internal static int __PropertyOffset_29;

		// Token: 0x04011897 RID: 71831
		internal static int __PropertyOffset_30;

		// Token: 0x04011898 RID: 71832
		internal static int __PropertyOffset_31;

		// Token: 0x04011899 RID: 71833
		internal static int __PropertyOffset_32;

		// Token: 0x0401189A RID: 71834
		internal static int __PropertyOffset_33;

		// Token: 0x0401189B RID: 71835
		internal static int __PropertyOffset_34;

		// Token: 0x0401189C RID: 71836
		internal static int __PropertyOffset_35;

		// Token: 0x0401189D RID: 71837
		internal static int __PropertyOffset_36;

		// Token: 0x0401189E RID: 71838
		internal static int __PropertyOffset_37;

		// Token: 0x0401189F RID: 71839
		private FKuroSkyVolumetricCloudSetting _Setting;

		// Token: 0x040118A0 RID: 71840
		internal static int __PropertyOffset_38;

		// Token: 0x040118A1 RID: 71841
		internal static int __PropertyOffset_39;

		// Token: 0x040118A2 RID: 71842
		internal static int __PropertyOffset_40;

		// Token: 0x040118A3 RID: 71843
		internal static int __PropertyOffset_41;

		// Token: 0x040118A4 RID: 71844
		internal static int __PropertyOffset_42;

		// Token: 0x040118A5 RID: 71845
		internal static int __PropertyOffset_43;

		// Token: 0x040118A6 RID: 71846
		internal static int __PropertyOffset_44;

		// Token: 0x040118A7 RID: 71847
		internal static int __PropertyOffset_45;

		// Token: 0x040118A8 RID: 71848
		internal static int __PropertyOffset_46;

		// Token: 0x040118A9 RID: 71849
		internal static int __PropertyOffset_47;

		// Token: 0x040118AA RID: 71850
		internal static int __PropertyOffset_48;

		// Token: 0x040118AB RID: 71851
		internal static int __PropertyOffset_49;

		// Token: 0x040118AC RID: 71852
		internal static int __PropertyOffset_50;

		// Token: 0x040118AD RID: 71853
		internal static int __PropertyOffset_51;

		// Token: 0x040118AE RID: 71854
		internal static int __PropertyOffset_52;

		// Token: 0x040118AF RID: 71855
		internal static int __PropertyOffset_53;

		// Token: 0x040118B0 RID: 71856
		internal static int __PropertyOffset_54;

		// Token: 0x040118B1 RID: 71857
		internal static int __PropertyOffset_55;

		// Token: 0x040118B2 RID: 71858
		internal static int __PropertyOffset_56;

		// Token: 0x040118B3 RID: 71859
		internal static int __PropertyOffset_57;

		// Token: 0x040118B4 RID: 71860
		internal static int __PropertyOffset_58;

		// Token: 0x040118B5 RID: 71861
		internal static int __PropertyOffset_59;

		// Token: 0x040118B6 RID: 71862
		internal static int __PropertyOffset_60;

		// Token: 0x040118B7 RID: 71863
		private static IntPtr __ResetThunder_NativeFunctionPtr;

		// Token: 0x040118B8 RID: 71864
		private static IntPtr __TryToSpawnThunder_NativeFunctionPtr;

		// Token: 0x040118B9 RID: 71865
		private static IntPtr __UpdateThunder_NativeFunctionPtr;

		// Token: 0x040118BA RID: 71866
		private static IntPtr __SpawnThunder_NativeFunctionPtr;

		// Token: 0x040118BB RID: 71867
		private static IntPtr __Init_Params_from_Setting_NativeFunctionPtr;

		// Token: 0x040118BC RID: 71868
		private static IntPtr __UpdateCloudParams_NativeFunctionPtr;

		// Token: 0x040118BD RID: 71869
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040118BE RID: 71870
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040118BF RID: 71871
		private static IntPtr __BeforeCookForMobile_NativeFunctionPtr;

		// Token: 0x040118C0 RID: 71872
		private static IntPtr __BeforeCookForPC_NativeFunctionPtr;

		// Token: 0x040118C1 RID: 71873
		private static IntPtr __BeforeSave_NativeFunctionPtr;

		// Token: 0x040118C2 RID: 71874
		private static IntPtr __ExecuteUbergraph_BP_KuroDynamicSky_NativeFunctionPtr;

		// Token: 0x02009BFD RID: 39933
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_KuroDynamicSky_FunctionParams
		{
			// Token: 0x04032457 RID: 205911
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
