using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CBF RID: 15551
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudFuBen.BP_CloudFuBen_C")]
	[UnrealStructLayout(1944, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1940)]
	public class BP_CloudFuBen_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024CEA RID: 150762 RVA: 0x009A8B8B File Offset: 0x009A6D8B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CloudFuBen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudFuBen.BP_CloudFuBen_C");
			}
			return BP_CloudFuBen_C._ClassPtr;
		}

		// Token: 0x06024CEB RID: 150763 RVA: 0x009A8BB0 File Offset: 0x009A6DB0
		public BP_CloudFuBen_C() : this(BuiltinUtils.AllocNativeUObject(BP_CloudFuBen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024CEC RID: 150764 RVA: 0x009A8BD8 File Offset: 0x009A6DD8
		[NullableContext(1)]
		public BP_CloudFuBen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CloudFuBen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004E03 RID: 19971
		// (get) Token: 0x06024CED RID: 150765 RVA: 0x009A8C0C File Offset: 0x009A6E0C
		// (set) Token: 0x06024CEE RID: 150766 RVA: 0x009A8C45 File Offset: 0x009A6E45
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E04 RID: 19972
		// (get) Token: 0x06024CEF RID: 150767 RVA: 0x009A8C66 File Offset: 0x009A6E66
		// (set) Token: 0x06024CF0 RID: 150768 RVA: 0x009A8C7A File Offset: 0x009A6E7A
		public unsafe UStaticMeshComponent Cloud_Anomalies
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004E05 RID: 19973
		// (get) Token: 0x06024CF1 RID: 150769 RVA: 0x009A8C8F File Offset: 0x009A6E8F
		// (set) Token: 0x06024CF2 RID: 150770 RVA: 0x009A8CA3 File Offset: 0x009A6EA3
		public unsafe UStaticMeshComponent Sun_Moon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004E06 RID: 19974
		// (get) Token: 0x06024CF3 RID: 150771 RVA: 0x009A8CB8 File Offset: 0x009A6EB8
		// (set) Token: 0x06024CF4 RID: 150772 RVA: 0x009A8CCC File Offset: 0x009A6ECC
		public unsafe UStaticMeshComponent Cloud_BigShape
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004E07 RID: 19975
		// (get) Token: 0x06024CF5 RID: 150773 RVA: 0x009A8CE1 File Offset: 0x009A6EE1
		// (set) Token: 0x06024CF6 RID: 150774 RVA: 0x009A8CF5 File Offset: 0x009A6EF5
		public unsafe UStaticMeshComponent Cloud_Special
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004E08 RID: 19976
		// (get) Token: 0x06024CF7 RID: 150775 RVA: 0x009A8D0A File Offset: 0x009A6F0A
		// (set) Token: 0x06024CF8 RID: 150776 RVA: 0x009A8D1E File Offset: 0x009A6F1E
		public unsafe UStaticMeshComponent Cloud_Top
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004E09 RID: 19977
		// (get) Token: 0x06024CF9 RID: 150777 RVA: 0x009A8D33 File Offset: 0x009A6F33
		// (set) Token: 0x06024CFA RID: 150778 RVA: 0x009A8D47 File Offset: 0x009A6F47
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004E0A RID: 19978
		// (get) Token: 0x06024CFB RID: 150779 RVA: 0x009A8D5C File Offset: 0x009A6F5C
		// (set) Token: 0x06024CFC RID: 150780 RVA: 0x009A8D70 File Offset: 0x009A6F70
		public unsafe UMaterialInstanceDynamic DMI_Top
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004E0B RID: 19979
		// (get) Token: 0x06024CFD RID: 150781 RVA: 0x009A8D85 File Offset: 0x009A6F85
		// (set) Token: 0x06024CFE RID: 150782 RVA: 0x009A8D99 File Offset: 0x009A6F99
		public unsafe UMaterialInstanceDynamic DMI_Anomalies
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004E0C RID: 19980
		// (get) Token: 0x06024CFF RID: 150783 RVA: 0x009A8DAE File Offset: 0x009A6FAE
		// (set) Token: 0x06024D00 RID: 150784 RVA: 0x009A8DC2 File Offset: 0x009A6FC2
		public unsafe UMaterialInstanceDynamic DMI_SunMoon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004E0D RID: 19981
		// (get) Token: 0x06024D01 RID: 150785 RVA: 0x009A8DD7 File Offset: 0x009A6FD7
		// (set) Token: 0x06024D02 RID: 150786 RVA: 0x009A8DEB File Offset: 0x009A6FEB
		public unsafe UMaterialInstanceDynamic DMI_BigShape
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004E0E RID: 19982
		// (get) Token: 0x06024D03 RID: 150787 RVA: 0x009A8E00 File Offset: 0x009A7000
		// (set) Token: 0x06024D04 RID: 150788 RVA: 0x009A8E10 File Offset: 0x009A7010
		public unsafe bool UpdatePerFourFrame01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E0F RID: 19983
		// (get) Token: 0x06024D05 RID: 150789 RVA: 0x009A8E21 File Offset: 0x009A7021
		// (set) Token: 0x06024D06 RID: 150790 RVA: 0x009A8E31 File Offset: 0x009A7031
		public unsafe bool UpdatePerFourFrame02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E10 RID: 19984
		// (get) Token: 0x06024D07 RID: 150791 RVA: 0x009A8E42 File Offset: 0x009A7042
		// (set) Token: 0x06024D08 RID: 150792 RVA: 0x009A8E56 File Offset: 0x009A7056
		public unsafe UTexture2D Top_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004E11 RID: 19985
		// (get) Token: 0x06024D09 RID: 150793 RVA: 0x009A8E6B File Offset: 0x009A706B
		// (set) Token: 0x06024D0A RID: 150794 RVA: 0x009A8E7F File Offset: 0x009A707F
		public unsafe UTexture2D POI_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004E12 RID: 19986
		// (get) Token: 0x06024D0B RID: 150795 RVA: 0x009A8E94 File Offset: 0x009A7094
		// (set) Token: 0x06024D0C RID: 150796 RVA: 0x009A8EA8 File Offset: 0x009A70A8
		public unsafe FRotator POI_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004E13 RID: 19987
		// (get) Token: 0x06024D0D RID: 150797 RVA: 0x009A8EBD File Offset: 0x009A70BD
		// (set) Token: 0x06024D0E RID: 150798 RVA: 0x009A8ED1 File Offset: 0x009A70D1
		public unsafe UMaterialInstance TOP_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004E14 RID: 19988
		// (get) Token: 0x06024D0F RID: 150799 RVA: 0x009A8EE6 File Offset: 0x009A70E6
		// (set) Token: 0x06024D10 RID: 150800 RVA: 0x009A8EF6 File Offset: 0x009A70F6
		public unsafe bool UV1UV2_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E15 RID: 19989
		// (get) Token: 0x06024D11 RID: 150801 RVA: 0x009A8F07 File Offset: 0x009A7107
		// (set) Token: 0x06024D12 RID: 150802 RVA: 0x009A8F17 File Offset: 0x009A7117
		public unsafe float UVTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004E16 RID: 19990
		// (get) Token: 0x06024D13 RID: 150803 RVA: 0x009A8F28 File Offset: 0x009A7128
		// (set) Token: 0x06024D14 RID: 150804 RVA: 0x009A8F38 File Offset: 0x009A7138
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004E17 RID: 19991
		// (get) Token: 0x06024D15 RID: 150805 RVA: 0x009A8F49 File Offset: 0x009A7149
		// (set) Token: 0x06024D16 RID: 150806 RVA: 0x009A8F59 File Offset: 0x009A7159
		public unsafe float Top_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004E18 RID: 19992
		// (get) Token: 0x06024D17 RID: 150807 RVA: 0x009A8F6A File Offset: 0x009A716A
		// (set) Token: 0x06024D18 RID: 150808 RVA: 0x009A8F7E File Offset: 0x009A717E
		public unsafe UTexture2D Special_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004E19 RID: 19993
		// (get) Token: 0x06024D19 RID: 150809 RVA: 0x009A8F93 File Offset: 0x009A7193
		// (set) Token: 0x06024D1A RID: 150810 RVA: 0x009A8FA7 File Offset: 0x009A71A7
		public unsafe UMaterialInstance Special_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004E1A RID: 19994
		// (get) Token: 0x06024D1B RID: 150811 RVA: 0x009A8FBC File Offset: 0x009A71BC
		// (set) Token: 0x06024D1C RID: 150812 RVA: 0x009A8FD0 File Offset: 0x009A71D0
		public unsafe FRotator Special_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004E1B RID: 19995
		// (get) Token: 0x06024D1D RID: 150813 RVA: 0x009A8FE5 File Offset: 0x009A71E5
		// (set) Token: 0x06024D1E RID: 150814 RVA: 0x009A8FF5 File Offset: 0x009A71F5
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004E1C RID: 19996
		// (get) Token: 0x06024D1F RID: 150815 RVA: 0x009A9006 File Offset: 0x009A7206
		// (set) Token: 0x06024D20 RID: 150816 RVA: 0x009A9016 File Offset: 0x009A7216
		public unsafe int TransSortNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004E1D RID: 19997
		// (get) Token: 0x06024D21 RID: 150817 RVA: 0x009A9027 File Offset: 0x009A7227
		// (set) Token: 0x06024D22 RID: 150818 RVA: 0x009A903B File Offset: 0x009A723B
		public unsafe UStaticMesh CloudSpecialMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17004E1E RID: 19998
		// (get) Token: 0x06024D23 RID: 150819 RVA: 0x009A9050 File Offset: 0x009A7250
		// (set) Token: 0x06024D24 RID: 150820 RVA: 0x009A9064 File Offset: 0x009A7264
		public unsafe UTexture2D Noise_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004E1F RID: 19999
		// (get) Token: 0x06024D25 RID: 150821 RVA: 0x009A9079 File Offset: 0x009A7279
		// (set) Token: 0x06024D26 RID: 150822 RVA: 0x009A9089 File Offset: 0x009A7289
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004E20 RID: 20000
		// (get) Token: 0x06024D27 RID: 150823 RVA: 0x009A909A File Offset: 0x009A729A
		// (set) Token: 0x06024D28 RID: 150824 RVA: 0x009A90AA File Offset: 0x009A72AA
		public unsafe float NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004E21 RID: 20001
		// (get) Token: 0x06024D29 RID: 150825 RVA: 0x009A90BB File Offset: 0x009A72BB
		// (set) Token: 0x06024D2A RID: 150826 RVA: 0x009A90CB File Offset: 0x009A72CB
		public unsafe float NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004E22 RID: 20002
		// (get) Token: 0x06024D2B RID: 150827 RVA: 0x009A90DC File Offset: 0x009A72DC
		// (set) Token: 0x06024D2C RID: 150828 RVA: 0x009A90F0 File Offset: 0x009A72F0
		public unsafe UTexture2D Anomalies_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17004E23 RID: 20003
		// (get) Token: 0x06024D2D RID: 150829 RVA: 0x009A9105 File Offset: 0x009A7305
		// (set) Token: 0x06024D2E RID: 150830 RVA: 0x009A9119 File Offset: 0x009A7319
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004E24 RID: 20004
		// (get) Token: 0x06024D2F RID: 150831 RVA: 0x009A912E File Offset: 0x009A732E
		// (set) Token: 0x06024D30 RID: 150832 RVA: 0x009A9142 File Offset: 0x009A7342
		public unsafe FRotator Anomalies_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004E25 RID: 20005
		// (get) Token: 0x06024D31 RID: 150833 RVA: 0x009A9157 File Offset: 0x009A7357
		// (set) Token: 0x06024D32 RID: 150834 RVA: 0x009A9167 File Offset: 0x009A7367
		public unsafe float Anomalies_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004E26 RID: 20006
		// (get) Token: 0x06024D33 RID: 150835 RVA: 0x009A9178 File Offset: 0x009A7378
		// (set) Token: 0x06024D34 RID: 150836 RVA: 0x009A918C File Offset: 0x009A738C
		public unsafe FVector Anomalies_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17004E27 RID: 20007
		// (get) Token: 0x06024D35 RID: 150837 RVA: 0x009A91A4 File Offset: 0x009A73A4
		// (set) Token: 0x06024D36 RID: 150838 RVA: 0x009A91DD File Offset: 0x009A73DD
		[Nullable(1)]
		public FKuroCurveFloat Sky
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Sky) == null)
				{
					result = (this._Sky = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_36, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E28 RID: 20008
		// (get) Token: 0x06024D37 RID: 150839 RVA: 0x009A9200 File Offset: 0x009A7400
		// (set) Token: 0x06024D38 RID: 150840 RVA: 0x009A9239 File Offset: 0x009A7439
		[Nullable(1)]
		public FKuroCurveFloat StarTrails
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._StarTrails) == null)
				{
					result = (this._StarTrails = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_37, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E29 RID: 20009
		// (get) Token: 0x06024D39 RID: 150841 RVA: 0x009A925A File Offset: 0x009A745A
		// (set) Token: 0x06024D3A RID: 150842 RVA: 0x009A926A File Offset: 0x009A746A
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004E2A RID: 20010
		// (get) Token: 0x06024D3B RID: 150843 RVA: 0x009A927B File Offset: 0x009A747B
		// (set) Token: 0x06024D3C RID: 150844 RVA: 0x009A928B File Offset: 0x009A748B
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004E2B RID: 20011
		// (get) Token: 0x06024D3D RID: 150845 RVA: 0x009A929C File Offset: 0x009A749C
		// (set) Token: 0x06024D3E RID: 150846 RVA: 0x009A92AC File Offset: 0x009A74AC
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17004E2C RID: 20012
		// (get) Token: 0x06024D3F RID: 150847 RVA: 0x009A92BD File Offset: 0x009A74BD
		// (set) Token: 0x06024D40 RID: 150848 RVA: 0x009A92CD File Offset: 0x009A74CD
		public unsafe bool IsTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E2D RID: 20013
		// (get) Token: 0x06024D41 RID: 150849 RVA: 0x009A92DE File Offset: 0x009A74DE
		// (set) Token: 0x06024D42 RID: 150850 RVA: 0x009A92EE File Offset: 0x009A74EE
		public unsafe float Anomalies_NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17004E2E RID: 20014
		// (get) Token: 0x06024D43 RID: 150851 RVA: 0x009A92FF File Offset: 0x009A74FF
		// (set) Token: 0x06024D44 RID: 150852 RVA: 0x009A930F File Offset: 0x009A750F
		public unsafe float Anomalies_NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17004E2F RID: 20015
		// (get) Token: 0x06024D45 RID: 150853 RVA: 0x009A9320 File Offset: 0x009A7520
		// (set) Token: 0x06024D46 RID: 150854 RVA: 0x009A9330 File Offset: 0x009A7530
		public unsafe float Anomalies_NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17004E30 RID: 20016
		// (get) Token: 0x06024D47 RID: 150855 RVA: 0x009A9341 File Offset: 0x009A7541
		// (set) Token: 0x06024D48 RID: 150856 RVA: 0x009A9355 File Offset: 0x009A7555
		public unsafe UTexture2D Anomalies_NoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudFuBen_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17004E31 RID: 20017
		// (get) Token: 0x06024D49 RID: 150857 RVA: 0x009A936A File Offset: 0x009A756A
		// (set) Token: 0x06024D4A RID: 150858 RVA: 0x009A937E File Offset: 0x009A757E
		[Nullable(1)]
		public unsafe string LevelLog
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_CloudFuBen_C.__PropertyOffset_46)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_CloudFuBen_C.__PropertyOffset_46)), value);
			}
		}

		// Token: 0x17004E32 RID: 20018
		// (get) Token: 0x06024D4B RID: 150859 RVA: 0x009A9393 File Offset: 0x009A7593
		// (set) Token: 0x06024D4C RID: 150860 RVA: 0x009A93A3 File Offset: 0x009A75A3
		public unsafe float Translucent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudFuBen_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x06024D4D RID: 150861 RVA: 0x009A93B4 File Offset: 0x009A75B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(ref float ElapsedTime)
		{
			BP_CloudFuBen_C.__Timer_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__Timer_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CloudFuBen_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__Timer_NativeFunctionPtr, (void*)ptr);
			ElapsedTime = ptr->ElapsedTime;
		}

		// Token: 0x06024D4E RID: 150862 RVA: 0x009A9404 File Offset: 0x009A7604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeSky(bool IsTick)
		{
			BP_CloudFuBen_C.__ChangeSky_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__ChangeSky_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_CloudFuBen_C.__ChangeSky_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__ChangeSky_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsTick = IsTick;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__ChangeSky_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024D4F RID: 150863 RVA: 0x009A944C File Offset: 0x009A764C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Special_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, FRotator POIRotation, float Intensity, FVector Scale, UTexture2D NoiseTex, float NoiseSpeed, float NoiseStrength, float NoiseTilling, FLinearColor Color)
		{
			BP_CloudFuBen_C.__Special_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__Special_Parameters_Initial_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_CloudFuBen_C.__Special_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__Special_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Texture = ((Texture != null) ? Texture.NativePtr : IntPtr.Zero);
			ptr->POIRotation = POIRotation;
			ptr->Intensity = Intensity;
			ptr->Scale = Scale;
			ptr->NoiseTex = ((NoiseTex != null) ? NoiseTex.NativePtr : IntPtr.Zero);
			ptr->NoiseSpeed = NoiseSpeed;
			ptr->NoiseStrength = NoiseStrength;
			ptr->NoiseTilling = NoiseTilling;
			ptr->Color = Color;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__Special_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024D50 RID: 150864 RVA: 0x009A9520 File Offset: 0x009A7720
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SunMoon_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, FRotator POIRotation, float Intensity)
		{
			BP_CloudFuBen_C.__SunMoon_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__SunMoon_Parameters_Initial_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(BP_CloudFuBen_C.__SunMoon_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__SunMoon_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Texture = ((Texture != null) ? Texture.NativePtr : IntPtr.Zero);
			ptr->POIRotation = POIRotation;
			ptr->Intensity = Intensity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__SunMoon_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024D51 RID: 150865 RVA: 0x009A95B4 File Offset: 0x009A77B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Single_POI_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, FRotator POIRotation)
		{
			BP_CloudFuBen_C.__Single_POI_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__Single_POI_Parameters_Initial_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_CloudFuBen_C.__Single_POI_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__Single_POI_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Texture = ((Texture != null) ? Texture.NativePtr : IntPtr.Zero);
			ptr->POIRotation = POIRotation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__Single_POI_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024D52 RID: 150866 RVA: 0x009A9640 File Offset: 0x009A7840
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePerFourFrame()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__UpdatePerFourFrame_NativeFunctionPtr, null);
		}

		// Token: 0x06024D53 RID: 150867 RVA: 0x009A9654 File Offset: 0x009A7854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CreateDMI(UStaticMeshComponent Mesh, UMaterialInstance Material, ref UMaterialInstanceDynamic DMI)
		{
			BP_CloudFuBen_C.__CreateDMI_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__CreateDMI_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CloudFuBen_C.__CreateDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__CreateDMI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ref BP_CloudFuBen_C.__CreateDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMI;
			ptr2.DMI = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__CreateDMI_NativeFunctionPtr, (void*)ptr);
			DMI = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMI);
		}

		// Token: 0x06024D54 RID: 150868 RVA: 0x009A96E4 File Offset: 0x009A78E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Single_Cloud_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, bool UV1UV2_, float CloudSpeed, float Top_Rotation, float UVTiling, float NoiseStrength, float NoiseSpeed, float NoiseTilling, UTexture2D NoiseTex)
		{
			BP_CloudFuBen_C.__Single_Cloud_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__Single_Cloud_Parameters_Initial_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_CloudFuBen_C.__Single_Cloud_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__Single_Cloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Texture = ((Texture != null) ? Texture.NativePtr : IntPtr.Zero);
			ptr->UV1UV2_ = UV1UV2_;
			ptr->CloudSpeed = CloudSpeed;
			ptr->Top_Rotation = Top_Rotation;
			ptr->UVTiling = UVTiling;
			ptr->NoiseStrength = NoiseStrength;
			ptr->NoiseSpeed = NoiseSpeed;
			ptr->NoiseTilling = NoiseTilling;
			ptr->NoiseTex = ((NoiseTex != null) ? NoiseTex.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__Single_Cloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024D55 RID: 150869 RVA: 0x009A97B5 File Offset: 0x009A79B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024D56 RID: 150870 RVA: 0x009A97C9 File Offset: 0x009A79C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBen_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024D57 RID: 150871 RVA: 0x009A97DE File Offset: 0x009A79DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024D58 RID: 150872 RVA: 0x009A97F2 File Offset: 0x009A79F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBen_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024D59 RID: 150873 RVA: 0x009A9808 File Offset: 0x009A7A08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CloudFuBen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024D5A RID: 150874 RVA: 0x009A9850 File Offset: 0x009A7A50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CloudFuBen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024D5B RID: 150875 RVA: 0x009A9898 File Offset: 0x009A7A98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CloudFuBen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024D5C RID: 150876 RVA: 0x009A98E0 File Offset: 0x009A7AE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CloudFuBen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudFuBen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024D5D RID: 150877 RVA: 0x009A9927 File Offset: 0x009A7B27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudFuBen_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06024D5E RID: 150878 RVA: 0x009A993C File Offset: 0x009A7B3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CloudFuBen(int EntryPoint)
		{
			BP_CloudFuBen_C.__ExecuteUbergraph_BP_CloudFuBen_FunctionParams* ptr = stackalloc BP_CloudFuBen_C.__ExecuteUbergraph_BP_CloudFuBen_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_CloudFuBen_C.__ExecuteUbergraph_BP_CloudFuBen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudFuBen_C.__ExecuteUbergraph_BP_CloudFuBen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudFuBen_C.__ExecuteUbergraph_BP_CloudFuBen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024D5F RID: 150879 RVA: 0x009A9986 File Offset: 0x009A7B86
		protected BP_CloudFuBen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012E2A RID: 77354
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudFuBen.BP_CloudFuBen_C";

		// Token: 0x04012E2B RID: 77355
		private static IntPtr _ClassPtr;

		// Token: 0x04012E2C RID: 77356
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012E2D RID: 77357
		internal static int __PropertyOffset_0;

		// Token: 0x04012E2E RID: 77358
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012E2F RID: 77359
		internal static int __PropertyOffset_1;

		// Token: 0x04012E30 RID: 77360
		internal static int __PropertyOffset_2;

		// Token: 0x04012E31 RID: 77361
		internal static int __PropertyOffset_3;

		// Token: 0x04012E32 RID: 77362
		internal static int __PropertyOffset_4;

		// Token: 0x04012E33 RID: 77363
		internal static int __PropertyOffset_5;

		// Token: 0x04012E34 RID: 77364
		internal static int __PropertyOffset_6;

		// Token: 0x04012E35 RID: 77365
		internal static int __PropertyOffset_7;

		// Token: 0x04012E36 RID: 77366
		internal static int __PropertyOffset_8;

		// Token: 0x04012E37 RID: 77367
		internal static int __PropertyOffset_9;

		// Token: 0x04012E38 RID: 77368
		internal static int __PropertyOffset_10;

		// Token: 0x04012E39 RID: 77369
		internal static int __PropertyOffset_11;

		// Token: 0x04012E3A RID: 77370
		internal static int __PropertyOffset_12;

		// Token: 0x04012E3B RID: 77371
		internal static int __PropertyOffset_13;

		// Token: 0x04012E3C RID: 77372
		internal static int __PropertyOffset_14;

		// Token: 0x04012E3D RID: 77373
		internal static int __PropertyOffset_15;

		// Token: 0x04012E3E RID: 77374
		internal static int __PropertyOffset_16;

		// Token: 0x04012E3F RID: 77375
		internal static int __PropertyOffset_17;

		// Token: 0x04012E40 RID: 77376
		internal static int __PropertyOffset_18;

		// Token: 0x04012E41 RID: 77377
		internal static int __PropertyOffset_19;

		// Token: 0x04012E42 RID: 77378
		internal static int __PropertyOffset_20;

		// Token: 0x04012E43 RID: 77379
		internal static int __PropertyOffset_21;

		// Token: 0x04012E44 RID: 77380
		internal static int __PropertyOffset_22;

		// Token: 0x04012E45 RID: 77381
		internal static int __PropertyOffset_23;

		// Token: 0x04012E46 RID: 77382
		internal static int __PropertyOffset_24;

		// Token: 0x04012E47 RID: 77383
		internal static int __PropertyOffset_25;

		// Token: 0x04012E48 RID: 77384
		internal static int __PropertyOffset_26;

		// Token: 0x04012E49 RID: 77385
		internal static int __PropertyOffset_27;

		// Token: 0x04012E4A RID: 77386
		internal static int __PropertyOffset_28;

		// Token: 0x04012E4B RID: 77387
		internal static int __PropertyOffset_29;

		// Token: 0x04012E4C RID: 77388
		internal static int __PropertyOffset_30;

		// Token: 0x04012E4D RID: 77389
		internal static int __PropertyOffset_31;

		// Token: 0x04012E4E RID: 77390
		internal static int __PropertyOffset_32;

		// Token: 0x04012E4F RID: 77391
		internal static int __PropertyOffset_33;

		// Token: 0x04012E50 RID: 77392
		internal static int __PropertyOffset_34;

		// Token: 0x04012E51 RID: 77393
		internal static int __PropertyOffset_35;

		// Token: 0x04012E52 RID: 77394
		internal static int __PropertyOffset_36;

		// Token: 0x04012E53 RID: 77395
		private FKuroCurveFloat _Sky;

		// Token: 0x04012E54 RID: 77396
		internal static int __PropertyOffset_37;

		// Token: 0x04012E55 RID: 77397
		private FKuroCurveFloat _StarTrails;

		// Token: 0x04012E56 RID: 77398
		internal static int __PropertyOffset_38;

		// Token: 0x04012E57 RID: 77399
		internal static int __PropertyOffset_39;

		// Token: 0x04012E58 RID: 77400
		internal static int __PropertyOffset_40;

		// Token: 0x04012E59 RID: 77401
		internal static int __PropertyOffset_41;

		// Token: 0x04012E5A RID: 77402
		internal static int __PropertyOffset_42;

		// Token: 0x04012E5B RID: 77403
		internal static int __PropertyOffset_43;

		// Token: 0x04012E5C RID: 77404
		internal static int __PropertyOffset_44;

		// Token: 0x04012E5D RID: 77405
		internal static int __PropertyOffset_45;

		// Token: 0x04012E5E RID: 77406
		internal static int __PropertyOffset_46;

		// Token: 0x04012E5F RID: 77407
		internal static int __PropertyOffset_47;

		// Token: 0x04012E60 RID: 77408
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x04012E61 RID: 77409
		private static IntPtr __ChangeSky_NativeFunctionPtr;

		// Token: 0x04012E62 RID: 77410
		private static IntPtr __Special_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012E63 RID: 77411
		private static IntPtr __SunMoon_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012E64 RID: 77412
		private static IntPtr __Single_POI_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012E65 RID: 77413
		private static IntPtr __UpdatePerFourFrame_NativeFunctionPtr;

		// Token: 0x04012E66 RID: 77414
		private static IntPtr __CreateDMI_NativeFunctionPtr;

		// Token: 0x04012E67 RID: 77415
		private static IntPtr __Single_Cloud_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012E68 RID: 77416
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012E69 RID: 77417
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012E6A RID: 77418
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012E6B RID: 77419
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012E6C RID: 77420
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04012E6D RID: 77421
		private static IntPtr __ExecuteUbergraph_BP_CloudFuBen_NativeFunctionPtr;

		// Token: 0x02009E76 RID: 40566
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x040328D3 RID: 207059
			[FieldOffset(0)]
			public float ElapsedTime;
		}

		// Token: 0x02009E77 RID: 40567
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __ChangeSky_FunctionParams
		{
			// Token: 0x040328D4 RID: 207060
			[FieldOffset(0)]
			public bool IsTick;
		}

		// Token: 0x02009E78 RID: 40568
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __Special_Parameters_Initial_FunctionParams
		{
			// Token: 0x040328D5 RID: 207061
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x040328D6 RID: 207062
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x040328D7 RID: 207063
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x040328D8 RID: 207064
			[FieldOffset(24)]
			public FRotator POIRotation;

			// Token: 0x040328D9 RID: 207065
			[FieldOffset(36)]
			public float Intensity;

			// Token: 0x040328DA RID: 207066
			[FieldOffset(40)]
			public FVector Scale;

			// Token: 0x040328DB RID: 207067
			[FieldOffset(56)]
			public IntPtr NoiseTex;

			// Token: 0x040328DC RID: 207068
			[FieldOffset(64)]
			public float NoiseSpeed;

			// Token: 0x040328DD RID: 207069
			[FieldOffset(68)]
			public float NoiseStrength;

			// Token: 0x040328DE RID: 207070
			[FieldOffset(72)]
			public float NoiseTilling;

			// Token: 0x040328DF RID: 207071
			[FieldOffset(76)]
			public FLinearColor Color;
		}

		// Token: 0x02009E79 RID: 40569
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __SunMoon_Parameters_Initial_FunctionParams
		{
			// Token: 0x040328E0 RID: 207072
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x040328E1 RID: 207073
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x040328E2 RID: 207074
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x040328E3 RID: 207075
			[FieldOffset(24)]
			public FRotator POIRotation;

			// Token: 0x040328E4 RID: 207076
			[FieldOffset(36)]
			public float Intensity;
		}

		// Token: 0x02009E7A RID: 40570
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __Single_POI_Parameters_Initial_FunctionParams
		{
			// Token: 0x040328E5 RID: 207077
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x040328E6 RID: 207078
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x040328E7 RID: 207079
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x040328E8 RID: 207080
			[FieldOffset(24)]
			public FRotator POIRotation;
		}

		// Token: 0x02009E7B RID: 40571
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __CreateDMI_FunctionParams
		{
			// Token: 0x040328E9 RID: 207081
			[FieldOffset(0)]
			public IntPtr Mesh;

			// Token: 0x040328EA RID: 207082
			[FieldOffset(8)]
			public IntPtr Material;

			// Token: 0x040328EB RID: 207083
			[FieldOffset(16)]
			public IntPtr DMI;
		}

		// Token: 0x02009E7C RID: 40572
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __Single_Cloud_Parameters_Initial_FunctionParams
		{
			// Token: 0x040328EC RID: 207084
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x040328ED RID: 207085
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x040328EE RID: 207086
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x040328EF RID: 207087
			[FieldOffset(24)]
			public bool UV1UV2_;

			// Token: 0x040328F0 RID: 207088
			[FieldOffset(28)]
			public float CloudSpeed;

			// Token: 0x040328F1 RID: 207089
			[FieldOffset(32)]
			public float Top_Rotation;

			// Token: 0x040328F2 RID: 207090
			[FieldOffset(36)]
			public float UVTiling;

			// Token: 0x040328F3 RID: 207091
			[FieldOffset(40)]
			public float NoiseStrength;

			// Token: 0x040328F4 RID: 207092
			[FieldOffset(44)]
			public float NoiseSpeed;

			// Token: 0x040328F5 RID: 207093
			[FieldOffset(48)]
			public float NoiseTilling;

			// Token: 0x040328F6 RID: 207094
			[FieldOffset(56)]
			public IntPtr NoiseTex;
		}

		// Token: 0x02009E7D RID: 40573
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328F7 RID: 207095
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E7E RID: 40574
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328F8 RID: 207096
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E7F RID: 40575
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_CloudFuBen_FunctionParams
		{
			// Token: 0x040328F9 RID: 207097
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
