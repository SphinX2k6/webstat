using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC1 RID: 15553
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudSequence.BP_CloudSequence_C")]
	[UnrealStructLayout(1680, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1677)]
	public class BP_CloudSequence_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024DEB RID: 151019 RVA: 0x009AA98B File Offset: 0x009A8B8B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CloudSequence_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudSequence.BP_CloudSequence_C");
			}
			return BP_CloudSequence_C._ClassPtr;
		}

		// Token: 0x06024DEC RID: 151020 RVA: 0x009AA9B0 File Offset: 0x009A8BB0
		public BP_CloudSequence_C() : this(BuiltinUtils.AllocNativeUObject(BP_CloudSequence_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024DED RID: 151021 RVA: 0x009AA9D8 File Offset: 0x009A8BD8
		[NullableContext(1)]
		public BP_CloudSequence_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CloudSequence_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004E6B RID: 20075
		// (get) Token: 0x06024DEE RID: 151022 RVA: 0x009AAA0C File Offset: 0x009A8C0C
		// (set) Token: 0x06024DEF RID: 151023 RVA: 0x009AAA45 File Offset: 0x009A8C45
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E6C RID: 20076
		// (get) Token: 0x06024DF0 RID: 151024 RVA: 0x009AAA66 File Offset: 0x009A8C66
		// (set) Token: 0x06024DF1 RID: 151025 RVA: 0x009AAA7A File Offset: 0x009A8C7A
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004E6D RID: 20077
		// (get) Token: 0x06024DF2 RID: 151026 RVA: 0x009AAA8F File Offset: 0x009A8C8F
		// (set) Token: 0x06024DF3 RID: 151027 RVA: 0x009AAAA3 File Offset: 0x009A8CA3
		public unsafe UStaticMeshComponent Cloud_Anomalies
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004E6E RID: 20078
		// (get) Token: 0x06024DF4 RID: 151028 RVA: 0x009AAAB8 File Offset: 0x009A8CB8
		// (set) Token: 0x06024DF5 RID: 151029 RVA: 0x009AAACC File Offset: 0x009A8CCC
		public unsafe UStaticMeshComponent Sun_Moon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004E6F RID: 20079
		// (get) Token: 0x06024DF6 RID: 151030 RVA: 0x009AAAE1 File Offset: 0x009A8CE1
		// (set) Token: 0x06024DF7 RID: 151031 RVA: 0x009AAAF5 File Offset: 0x009A8CF5
		public unsafe UStaticMeshComponent Cloud_BigShape
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004E70 RID: 20080
		// (get) Token: 0x06024DF8 RID: 151032 RVA: 0x009AAB0A File Offset: 0x009A8D0A
		// (set) Token: 0x06024DF9 RID: 151033 RVA: 0x009AAB1E File Offset: 0x009A8D1E
		public unsafe UStaticMeshComponent Cloud_Special
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004E71 RID: 20081
		// (get) Token: 0x06024DFA RID: 151034 RVA: 0x009AAB33 File Offset: 0x009A8D33
		// (set) Token: 0x06024DFB RID: 151035 RVA: 0x009AAB47 File Offset: 0x009A8D47
		public unsafe UStaticMeshComponent Cloud_Top
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004E72 RID: 20082
		// (get) Token: 0x06024DFC RID: 151036 RVA: 0x009AAB5C File Offset: 0x009A8D5C
		// (set) Token: 0x06024DFD RID: 151037 RVA: 0x009AAB70 File Offset: 0x009A8D70
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004E73 RID: 20083
		// (get) Token: 0x06024DFE RID: 151038 RVA: 0x009AAB85 File Offset: 0x009A8D85
		// (set) Token: 0x06024DFF RID: 151039 RVA: 0x009AAB99 File Offset: 0x009A8D99
		public unsafe UMaterialInstanceDynamic DMI_Top
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004E74 RID: 20084
		// (get) Token: 0x06024E00 RID: 151040 RVA: 0x009AABAE File Offset: 0x009A8DAE
		// (set) Token: 0x06024E01 RID: 151041 RVA: 0x009AABC2 File Offset: 0x009A8DC2
		public unsafe UMaterialInstanceDynamic DMI_Anomalies
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004E75 RID: 20085
		// (get) Token: 0x06024E02 RID: 151042 RVA: 0x009AABD7 File Offset: 0x009A8DD7
		// (set) Token: 0x06024E03 RID: 151043 RVA: 0x009AABEB File Offset: 0x009A8DEB
		public unsafe UMaterialInstanceDynamic DMI_SunMoon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004E76 RID: 20086
		// (get) Token: 0x06024E04 RID: 151044 RVA: 0x009AAC00 File Offset: 0x009A8E00
		// (set) Token: 0x06024E05 RID: 151045 RVA: 0x009AAC14 File Offset: 0x009A8E14
		public unsafe UMaterialInstanceDynamic DMI_BigShape
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004E77 RID: 20087
		// (get) Token: 0x06024E06 RID: 151046 RVA: 0x009AAC29 File Offset: 0x009A8E29
		// (set) Token: 0x06024E07 RID: 151047 RVA: 0x009AAC39 File Offset: 0x009A8E39
		public unsafe bool UpdatePerFourFrame01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E78 RID: 20088
		// (get) Token: 0x06024E08 RID: 151048 RVA: 0x009AAC4A File Offset: 0x009A8E4A
		// (set) Token: 0x06024E09 RID: 151049 RVA: 0x009AAC5A File Offset: 0x009A8E5A
		public unsafe bool UpdatePerFourFrame02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E79 RID: 20089
		// (get) Token: 0x06024E0A RID: 151050 RVA: 0x009AAC6B File Offset: 0x009A8E6B
		// (set) Token: 0x06024E0B RID: 151051 RVA: 0x009AAC7F File Offset: 0x009A8E7F
		public unsafe UTexture2D Top_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004E7A RID: 20090
		// (get) Token: 0x06024E0C RID: 151052 RVA: 0x009AAC94 File Offset: 0x009A8E94
		// (set) Token: 0x06024E0D RID: 151053 RVA: 0x009AACA8 File Offset: 0x009A8EA8
		public unsafe UTexture2D POI_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17004E7B RID: 20091
		// (get) Token: 0x06024E0E RID: 151054 RVA: 0x009AACBD File Offset: 0x009A8EBD
		// (set) Token: 0x06024E0F RID: 151055 RVA: 0x009AACD1 File Offset: 0x009A8ED1
		public unsafe FRotator POI_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004E7C RID: 20092
		// (get) Token: 0x06024E10 RID: 151056 RVA: 0x009AACE6 File Offset: 0x009A8EE6
		// (set) Token: 0x06024E11 RID: 151057 RVA: 0x009AACFA File Offset: 0x009A8EFA
		public unsafe UMaterialInstance TOP_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004E7D RID: 20093
		// (get) Token: 0x06024E12 RID: 151058 RVA: 0x009AAD0F File Offset: 0x009A8F0F
		// (set) Token: 0x06024E13 RID: 151059 RVA: 0x009AAD1F File Offset: 0x009A8F1F
		public unsafe bool UV1UV2_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E7E RID: 20094
		// (get) Token: 0x06024E14 RID: 151060 RVA: 0x009AAD30 File Offset: 0x009A8F30
		// (set) Token: 0x06024E15 RID: 151061 RVA: 0x009AAD40 File Offset: 0x009A8F40
		public unsafe float UVTiling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004E7F RID: 20095
		// (get) Token: 0x06024E16 RID: 151062 RVA: 0x009AAD51 File Offset: 0x009A8F51
		// (set) Token: 0x06024E17 RID: 151063 RVA: 0x009AAD61 File Offset: 0x009A8F61
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004E80 RID: 20096
		// (get) Token: 0x06024E18 RID: 151064 RVA: 0x009AAD72 File Offset: 0x009A8F72
		// (set) Token: 0x06024E19 RID: 151065 RVA: 0x009AAD82 File Offset: 0x009A8F82
		public unsafe float Top_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004E81 RID: 20097
		// (get) Token: 0x06024E1A RID: 151066 RVA: 0x009AAD93 File Offset: 0x009A8F93
		// (set) Token: 0x06024E1B RID: 151067 RVA: 0x009AADA7 File Offset: 0x009A8FA7
		public unsafe UTexture2D Special_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004E82 RID: 20098
		// (get) Token: 0x06024E1C RID: 151068 RVA: 0x009AADBC File Offset: 0x009A8FBC
		// (set) Token: 0x06024E1D RID: 151069 RVA: 0x009AADD0 File Offset: 0x009A8FD0
		public unsafe UMaterialInstance Special_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004E83 RID: 20099
		// (get) Token: 0x06024E1E RID: 151070 RVA: 0x009AADE5 File Offset: 0x009A8FE5
		// (set) Token: 0x06024E1F RID: 151071 RVA: 0x009AADF9 File Offset: 0x009A8FF9
		public unsafe FRotator Special_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004E84 RID: 20100
		// (get) Token: 0x06024E20 RID: 151072 RVA: 0x009AAE0E File Offset: 0x009A900E
		// (set) Token: 0x06024E21 RID: 151073 RVA: 0x009AAE1E File Offset: 0x009A901E
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004E85 RID: 20101
		// (get) Token: 0x06024E22 RID: 151074 RVA: 0x009AAE2F File Offset: 0x009A902F
		// (set) Token: 0x06024E23 RID: 151075 RVA: 0x009AAE3F File Offset: 0x009A903F
		public unsafe int TransSortNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004E86 RID: 20102
		// (get) Token: 0x06024E24 RID: 151076 RVA: 0x009AAE50 File Offset: 0x009A9050
		// (set) Token: 0x06024E25 RID: 151077 RVA: 0x009AAE64 File Offset: 0x009A9064
		public unsafe UStaticMesh CloudSpecialMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004E87 RID: 20103
		// (get) Token: 0x06024E26 RID: 151078 RVA: 0x009AAE79 File Offset: 0x009A9079
		// (set) Token: 0x06024E27 RID: 151079 RVA: 0x009AAE8D File Offset: 0x009A908D
		public unsafe UTexture2D Noise_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17004E88 RID: 20104
		// (get) Token: 0x06024E28 RID: 151080 RVA: 0x009AAEA2 File Offset: 0x009A90A2
		// (set) Token: 0x06024E29 RID: 151081 RVA: 0x009AAEB2 File Offset: 0x009A90B2
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004E89 RID: 20105
		// (get) Token: 0x06024E2A RID: 151082 RVA: 0x009AAEC3 File Offset: 0x009A90C3
		// (set) Token: 0x06024E2B RID: 151083 RVA: 0x009AAED3 File Offset: 0x009A90D3
		public unsafe float NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004E8A RID: 20106
		// (get) Token: 0x06024E2C RID: 151084 RVA: 0x009AAEE4 File Offset: 0x009A90E4
		// (set) Token: 0x06024E2D RID: 151085 RVA: 0x009AAEF4 File Offset: 0x009A90F4
		public unsafe float NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004E8B RID: 20107
		// (get) Token: 0x06024E2E RID: 151086 RVA: 0x009AAF05 File Offset: 0x009A9105
		// (set) Token: 0x06024E2F RID: 151087 RVA: 0x009AAF19 File Offset: 0x009A9119
		public unsafe UTexture2D Anomalies_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17004E8C RID: 20108
		// (get) Token: 0x06024E30 RID: 151088 RVA: 0x009AAF2E File Offset: 0x009A912E
		// (set) Token: 0x06024E31 RID: 151089 RVA: 0x009AAF42 File Offset: 0x009A9142
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004E8D RID: 20109
		// (get) Token: 0x06024E32 RID: 151090 RVA: 0x009AAF57 File Offset: 0x009A9157
		// (set) Token: 0x06024E33 RID: 151091 RVA: 0x009AAF6B File Offset: 0x009A916B
		public unsafe FRotator Anomalies_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004E8E RID: 20110
		// (get) Token: 0x06024E34 RID: 151092 RVA: 0x009AAF80 File Offset: 0x009A9180
		// (set) Token: 0x06024E35 RID: 151093 RVA: 0x009AAF90 File Offset: 0x009A9190
		public unsafe float Anomalies_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17004E8F RID: 20111
		// (get) Token: 0x06024E36 RID: 151094 RVA: 0x009AAFA1 File Offset: 0x009A91A1
		// (set) Token: 0x06024E37 RID: 151095 RVA: 0x009AAFB5 File Offset: 0x009A91B5
		public unsafe FVector Anomalies_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17004E90 RID: 20112
		// (get) Token: 0x06024E38 RID: 151096 RVA: 0x009AAFCC File Offset: 0x009A91CC
		// (set) Token: 0x06024E39 RID: 151097 RVA: 0x009AB005 File Offset: 0x009A9205
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
					result = (this._Sky = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_37, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E91 RID: 20113
		// (get) Token: 0x06024E3A RID: 151098 RVA: 0x009AB028 File Offset: 0x009A9228
		// (set) Token: 0x06024E3B RID: 151099 RVA: 0x009AB061 File Offset: 0x009A9261
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
					result = (this._StarTrails = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_38, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004E92 RID: 20114
		// (get) Token: 0x06024E3C RID: 151100 RVA: 0x009AB082 File Offset: 0x009A9282
		// (set) Token: 0x06024E3D RID: 151101 RVA: 0x009AB092 File Offset: 0x009A9292
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004E93 RID: 20115
		// (get) Token: 0x06024E3E RID: 151102 RVA: 0x009AB0A3 File Offset: 0x009A92A3
		// (set) Token: 0x06024E3F RID: 151103 RVA: 0x009AB0B3 File Offset: 0x009A92B3
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17004E94 RID: 20116
		// (get) Token: 0x06024E40 RID: 151104 RVA: 0x009AB0C4 File Offset: 0x009A92C4
		// (set) Token: 0x06024E41 RID: 151105 RVA: 0x009AB0D4 File Offset: 0x009A92D4
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17004E95 RID: 20117
		// (get) Token: 0x06024E42 RID: 151106 RVA: 0x009AB0E5 File Offset: 0x009A92E5
		// (set) Token: 0x06024E43 RID: 151107 RVA: 0x009AB0F5 File Offset: 0x009A92F5
		public unsafe bool IsTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004E96 RID: 20118
		// (get) Token: 0x06024E44 RID: 151108 RVA: 0x009AB106 File Offset: 0x009A9306
		// (set) Token: 0x06024E45 RID: 151109 RVA: 0x009AB116 File Offset: 0x009A9316
		public unsafe float Anomalies_NoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17004E97 RID: 20119
		// (get) Token: 0x06024E46 RID: 151110 RVA: 0x009AB127 File Offset: 0x009A9327
		// (set) Token: 0x06024E47 RID: 151111 RVA: 0x009AB137 File Offset: 0x009A9337
		public unsafe float Anomalies_NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17004E98 RID: 20120
		// (get) Token: 0x06024E48 RID: 151112 RVA: 0x009AB148 File Offset: 0x009A9348
		// (set) Token: 0x06024E49 RID: 151113 RVA: 0x009AB158 File Offset: 0x009A9358
		public unsafe float Anomalies_NoiseTilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17004E99 RID: 20121
		// (get) Token: 0x06024E4A RID: 151114 RVA: 0x009AB169 File Offset: 0x009A9369
		// (set) Token: 0x06024E4B RID: 151115 RVA: 0x009AB17D File Offset: 0x009A937D
		public unsafe UTexture2D Anomalies_NoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudSequence_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17004E9A RID: 20122
		// (get) Token: 0x06024E4C RID: 151116 RVA: 0x009AB192 File Offset: 0x009A9392
		// (set) Token: 0x06024E4D RID: 151117 RVA: 0x009AB1A6 File Offset: 0x009A93A6
		[Nullable(1)]
		public unsafe string LevelLog
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_CloudSequence_C.__PropertyOffset_47)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_CloudSequence_C.__PropertyOffset_47)), value);
			}
		}

		// Token: 0x17004E9B RID: 20123
		// (get) Token: 0x06024E4E RID: 151118 RVA: 0x009AB1BB File Offset: 0x009A93BB
		// (set) Token: 0x06024E4F RID: 151119 RVA: 0x009AB1CB File Offset: 0x009A93CB
		public unsafe float Translucent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17004E9C RID: 20124
		// (get) Token: 0x06024E50 RID: 151120 RVA: 0x009AB1DC File Offset: 0x009A93DC
		// (set) Token: 0x06024E51 RID: 151121 RVA: 0x009AB1EC File Offset: 0x009A93EC
		public unsafe float Soft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17004E9D RID: 20125
		// (get) Token: 0x06024E52 RID: 151122 RVA: 0x009AB1FD File Offset: 0x009A93FD
		// (set) Token: 0x06024E53 RID: 151123 RVA: 0x009AB20D File Offset: 0x009A940D
		public unsafe float Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17004E9E RID: 20126
		// (get) Token: 0x06024E54 RID: 151124 RVA: 0x009AB21E File Offset: 0x009A941E
		// (set) Token: 0x06024E55 RID: 151125 RVA: 0x009AB22E File Offset: 0x009A942E
		public unsafe bool bDisableAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_51) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudSequence_C.__PropertyOffset_51) = (value ? 1 : 0);
			}
		}

		// Token: 0x06024E56 RID: 151126 RVA: 0x009AB240 File Offset: 0x009A9440
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(ref float ElapsedTime)
		{
			BP_CloudSequence_C.__Timer_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__Timer_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CloudSequence_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__Timer_NativeFunctionPtr, (void*)ptr);
			ElapsedTime = ptr->ElapsedTime;
		}

		// Token: 0x06024E57 RID: 151127 RVA: 0x009AB290 File Offset: 0x009A9490
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeSky(bool IsTick)
		{
			BP_CloudSequence_C.__ChangeSky_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__ChangeSky_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_CloudSequence_C.__ChangeSky_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__ChangeSky_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsTick = IsTick;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__ChangeSky_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024E58 RID: 151128 RVA: 0x009AB2D8 File Offset: 0x009A94D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Special_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, FRotator POIRotation, float Intensity, FVector Scale, UTexture2D NoiseTex, float NoiseSpeed, float NoiseStrength, float NoiseTilling, FLinearColor Color)
		{
			BP_CloudSequence_C.__Special_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__Special_Parameters_Initial_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_CloudSequence_C.__Special_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__Special_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
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
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__Special_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024E59 RID: 151129 RVA: 0x009AB3AC File Offset: 0x009A95AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SunMoon_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, FRotator POIRotation, float Intensity)
		{
			BP_CloudSequence_C.__SunMoon_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__SunMoon_Parameters_Initial_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(BP_CloudSequence_C.__SunMoon_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__SunMoon_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Texture = ((Texture != null) ? Texture.NativePtr : IntPtr.Zero);
			ptr->POIRotation = POIRotation;
			ptr->Intensity = Intensity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__SunMoon_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024E5A RID: 151130 RVA: 0x009AB440 File Offset: 0x009A9640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Single_POI_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, FRotator POIRotation)
		{
			BP_CloudSequence_C.__Single_POI_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__Single_POI_Parameters_Initial_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_CloudSequence_C.__Single_POI_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__Single_POI_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DMI = ((DMI != null) ? DMI.NativePtr : IntPtr.Zero);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Texture = ((Texture != null) ? Texture.NativePtr : IntPtr.Zero);
			ptr->POIRotation = POIRotation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__Single_POI_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024E5B RID: 151131 RVA: 0x009AB4CC File Offset: 0x009A96CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePerFourFrame()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__UpdatePerFourFrame_NativeFunctionPtr, null);
		}

		// Token: 0x06024E5C RID: 151132 RVA: 0x009AB4E0 File Offset: 0x009A96E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CreateDMI(UStaticMeshComponent Mesh, UMaterialInstance Material, ref UMaterialInstanceDynamic DMI)
		{
			BP_CloudSequence_C.__CreateDMI_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__CreateDMI_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CloudSequence_C.__CreateDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__CreateDMI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ref BP_CloudSequence_C.__CreateDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMI;
			ptr2.DMI = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__CreateDMI_NativeFunctionPtr, (void*)ptr);
			DMI = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMI);
		}

		// Token: 0x06024E5D RID: 151133 RVA: 0x009AB570 File Offset: 0x009A9770
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Single_Cloud_Parameters_Initial(UMaterialInstanceDynamic DMI, UStaticMeshComponent Mesh, UTexture2D Texture, bool UV1UV2_, float CloudSpeed, float Top_Rotation, float UVTiling, float NoiseStrength, float NoiseSpeed, float NoiseTilling, UTexture2D NoiseTex)
		{
			BP_CloudSequence_C.__Single_Cloud_Parameters_Initial_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__Single_Cloud_Parameters_Initial_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_CloudSequence_C.__Single_Cloud_Parameters_Initial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__Single_Cloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr, 1);
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
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__Single_Cloud_Parameters_Initial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024E5E RID: 151134 RVA: 0x009AB641 File Offset: 0x009A9841
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024E5F RID: 151135 RVA: 0x009AB655 File Offset: 0x009A9855
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudSequence_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024E60 RID: 151136 RVA: 0x009AB66A File Offset: 0x009A986A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024E61 RID: 151137 RVA: 0x009AB67E File Offset: 0x009A987E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudSequence_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024E62 RID: 151138 RVA: 0x009AB694 File Offset: 0x009A9894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CloudSequence_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudSequence_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024E63 RID: 151139 RVA: 0x009AB6DC File Offset: 0x009A98DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CloudSequence_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudSequence_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudSequence_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024E64 RID: 151140 RVA: 0x009AB723 File Offset: 0x009A9923
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudSequence_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06024E65 RID: 151141 RVA: 0x009AB738 File Offset: 0x009A9938
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CloudSequence(int EntryPoint)
		{
			BP_CloudSequence_C.__ExecuteUbergraph_BP_CloudSequence_FunctionParams* ptr = stackalloc BP_CloudSequence_C.__ExecuteUbergraph_BP_CloudSequence_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_CloudSequence_C.__ExecuteUbergraph_BP_CloudSequence_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudSequence_C.__ExecuteUbergraph_BP_CloudSequence_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudSequence_C.__ExecuteUbergraph_BP_CloudSequence_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024E66 RID: 151142 RVA: 0x009AB782 File Offset: 0x009A9982
		protected BP_CloudSequence_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012EC2 RID: 77506
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudSequence.BP_CloudSequence_C";

		// Token: 0x04012EC3 RID: 77507
		private static IntPtr _ClassPtr;

		// Token: 0x04012EC4 RID: 77508
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012EC5 RID: 77509
		internal static int __PropertyOffset_0;

		// Token: 0x04012EC6 RID: 77510
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012EC7 RID: 77511
		internal static int __PropertyOffset_1;

		// Token: 0x04012EC8 RID: 77512
		internal static int __PropertyOffset_2;

		// Token: 0x04012EC9 RID: 77513
		internal static int __PropertyOffset_3;

		// Token: 0x04012ECA RID: 77514
		internal static int __PropertyOffset_4;

		// Token: 0x04012ECB RID: 77515
		internal static int __PropertyOffset_5;

		// Token: 0x04012ECC RID: 77516
		internal static int __PropertyOffset_6;

		// Token: 0x04012ECD RID: 77517
		internal static int __PropertyOffset_7;

		// Token: 0x04012ECE RID: 77518
		internal static int __PropertyOffset_8;

		// Token: 0x04012ECF RID: 77519
		internal static int __PropertyOffset_9;

		// Token: 0x04012ED0 RID: 77520
		internal static int __PropertyOffset_10;

		// Token: 0x04012ED1 RID: 77521
		internal static int __PropertyOffset_11;

		// Token: 0x04012ED2 RID: 77522
		internal static int __PropertyOffset_12;

		// Token: 0x04012ED3 RID: 77523
		internal static int __PropertyOffset_13;

		// Token: 0x04012ED4 RID: 77524
		internal static int __PropertyOffset_14;

		// Token: 0x04012ED5 RID: 77525
		internal static int __PropertyOffset_15;

		// Token: 0x04012ED6 RID: 77526
		internal static int __PropertyOffset_16;

		// Token: 0x04012ED7 RID: 77527
		internal static int __PropertyOffset_17;

		// Token: 0x04012ED8 RID: 77528
		internal static int __PropertyOffset_18;

		// Token: 0x04012ED9 RID: 77529
		internal static int __PropertyOffset_19;

		// Token: 0x04012EDA RID: 77530
		internal static int __PropertyOffset_20;

		// Token: 0x04012EDB RID: 77531
		internal static int __PropertyOffset_21;

		// Token: 0x04012EDC RID: 77532
		internal static int __PropertyOffset_22;

		// Token: 0x04012EDD RID: 77533
		internal static int __PropertyOffset_23;

		// Token: 0x04012EDE RID: 77534
		internal static int __PropertyOffset_24;

		// Token: 0x04012EDF RID: 77535
		internal static int __PropertyOffset_25;

		// Token: 0x04012EE0 RID: 77536
		internal static int __PropertyOffset_26;

		// Token: 0x04012EE1 RID: 77537
		internal static int __PropertyOffset_27;

		// Token: 0x04012EE2 RID: 77538
		internal static int __PropertyOffset_28;

		// Token: 0x04012EE3 RID: 77539
		internal static int __PropertyOffset_29;

		// Token: 0x04012EE4 RID: 77540
		internal static int __PropertyOffset_30;

		// Token: 0x04012EE5 RID: 77541
		internal static int __PropertyOffset_31;

		// Token: 0x04012EE6 RID: 77542
		internal static int __PropertyOffset_32;

		// Token: 0x04012EE7 RID: 77543
		internal static int __PropertyOffset_33;

		// Token: 0x04012EE8 RID: 77544
		internal static int __PropertyOffset_34;

		// Token: 0x04012EE9 RID: 77545
		internal static int __PropertyOffset_35;

		// Token: 0x04012EEA RID: 77546
		internal static int __PropertyOffset_36;

		// Token: 0x04012EEB RID: 77547
		internal static int __PropertyOffset_37;

		// Token: 0x04012EEC RID: 77548
		private FKuroCurveFloat _Sky;

		// Token: 0x04012EED RID: 77549
		internal static int __PropertyOffset_38;

		// Token: 0x04012EEE RID: 77550
		private FKuroCurveFloat _StarTrails;

		// Token: 0x04012EEF RID: 77551
		internal static int __PropertyOffset_39;

		// Token: 0x04012EF0 RID: 77552
		internal static int __PropertyOffset_40;

		// Token: 0x04012EF1 RID: 77553
		internal static int __PropertyOffset_41;

		// Token: 0x04012EF2 RID: 77554
		internal static int __PropertyOffset_42;

		// Token: 0x04012EF3 RID: 77555
		internal static int __PropertyOffset_43;

		// Token: 0x04012EF4 RID: 77556
		internal static int __PropertyOffset_44;

		// Token: 0x04012EF5 RID: 77557
		internal static int __PropertyOffset_45;

		// Token: 0x04012EF6 RID: 77558
		internal static int __PropertyOffset_46;

		// Token: 0x04012EF7 RID: 77559
		internal static int __PropertyOffset_47;

		// Token: 0x04012EF8 RID: 77560
		internal static int __PropertyOffset_48;

		// Token: 0x04012EF9 RID: 77561
		internal static int __PropertyOffset_49;

		// Token: 0x04012EFA RID: 77562
		internal static int __PropertyOffset_50;

		// Token: 0x04012EFB RID: 77563
		internal static int __PropertyOffset_51;

		// Token: 0x04012EFC RID: 77564
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x04012EFD RID: 77565
		private static IntPtr __ChangeSky_NativeFunctionPtr;

		// Token: 0x04012EFE RID: 77566
		private static IntPtr __Special_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012EFF RID: 77567
		private static IntPtr __SunMoon_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012F00 RID: 77568
		private static IntPtr __Single_POI_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012F01 RID: 77569
		private static IntPtr __UpdatePerFourFrame_NativeFunctionPtr;

		// Token: 0x04012F02 RID: 77570
		private static IntPtr __CreateDMI_NativeFunctionPtr;

		// Token: 0x04012F03 RID: 77571
		private static IntPtr __Single_Cloud_Parameters_Initial_NativeFunctionPtr;

		// Token: 0x04012F04 RID: 77572
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012F05 RID: 77573
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012F06 RID: 77574
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012F07 RID: 77575
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04012F08 RID: 77576
		private static IntPtr __ExecuteUbergraph_BP_CloudSequence_NativeFunctionPtr;

		// Token: 0x02009E8E RID: 40590
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x04032918 RID: 207128
			[FieldOffset(0)]
			public float ElapsedTime;
		}

		// Token: 0x02009E8F RID: 40591
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __ChangeSky_FunctionParams
		{
			// Token: 0x04032919 RID: 207129
			[FieldOffset(0)]
			public bool IsTick;
		}

		// Token: 0x02009E90 RID: 40592
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __Special_Parameters_Initial_FunctionParams
		{
			// Token: 0x0403291A RID: 207130
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x0403291B RID: 207131
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x0403291C RID: 207132
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x0403291D RID: 207133
			[FieldOffset(24)]
			public FRotator POIRotation;

			// Token: 0x0403291E RID: 207134
			[FieldOffset(36)]
			public float Intensity;

			// Token: 0x0403291F RID: 207135
			[FieldOffset(40)]
			public FVector Scale;

			// Token: 0x04032920 RID: 207136
			[FieldOffset(56)]
			public IntPtr NoiseTex;

			// Token: 0x04032921 RID: 207137
			[FieldOffset(64)]
			public float NoiseSpeed;

			// Token: 0x04032922 RID: 207138
			[FieldOffset(68)]
			public float NoiseStrength;

			// Token: 0x04032923 RID: 207139
			[FieldOffset(72)]
			public float NoiseTilling;

			// Token: 0x04032924 RID: 207140
			[FieldOffset(76)]
			public FLinearColor Color;
		}

		// Token: 0x02009E91 RID: 40593
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __SunMoon_Parameters_Initial_FunctionParams
		{
			// Token: 0x04032925 RID: 207141
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x04032926 RID: 207142
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x04032927 RID: 207143
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x04032928 RID: 207144
			[FieldOffset(24)]
			public FRotator POIRotation;

			// Token: 0x04032929 RID: 207145
			[FieldOffset(36)]
			public float Intensity;
		}

		// Token: 0x02009E92 RID: 40594
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __Single_POI_Parameters_Initial_FunctionParams
		{
			// Token: 0x0403292A RID: 207146
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x0403292B RID: 207147
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x0403292C RID: 207148
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x0403292D RID: 207149
			[FieldOffset(24)]
			public FRotator POIRotation;
		}

		// Token: 0x02009E93 RID: 40595
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __CreateDMI_FunctionParams
		{
			// Token: 0x0403292E RID: 207150
			[FieldOffset(0)]
			public IntPtr Mesh;

			// Token: 0x0403292F RID: 207151
			[FieldOffset(8)]
			public IntPtr Material;

			// Token: 0x04032930 RID: 207152
			[FieldOffset(16)]
			public IntPtr DMI;
		}

		// Token: 0x02009E94 RID: 40596
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __Single_Cloud_Parameters_Initial_FunctionParams
		{
			// Token: 0x04032931 RID: 207153
			[FieldOffset(0)]
			public IntPtr DMI;

			// Token: 0x04032932 RID: 207154
			[FieldOffset(8)]
			public IntPtr Mesh;

			// Token: 0x04032933 RID: 207155
			[FieldOffset(16)]
			public IntPtr Texture;

			// Token: 0x04032934 RID: 207156
			[FieldOffset(24)]
			public bool UV1UV2_;

			// Token: 0x04032935 RID: 207157
			[FieldOffset(28)]
			public float CloudSpeed;

			// Token: 0x04032936 RID: 207158
			[FieldOffset(32)]
			public float Top_Rotation;

			// Token: 0x04032937 RID: 207159
			[FieldOffset(36)]
			public float UVTiling;

			// Token: 0x04032938 RID: 207160
			[FieldOffset(40)]
			public float NoiseStrength;

			// Token: 0x04032939 RID: 207161
			[FieldOffset(44)]
			public float NoiseSpeed;

			// Token: 0x0403293A RID: 207162
			[FieldOffset(48)]
			public float NoiseTilling;

			// Token: 0x0403293B RID: 207163
			[FieldOffset(56)]
			public IntPtr NoiseTex;
		}

		// Token: 0x02009E95 RID: 40597
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403293C RID: 207164
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E96 RID: 40598
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_CloudSequence_FunctionParams
		{
			// Token: 0x0403293D RID: 207165
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
