using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A7E RID: 14974
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_DispersionLightPostprocess.BP_DispersionLightPostprocess_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1480)]
	public class BP_DispersionLightPostprocess_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F4B7 RID: 128183 RVA: 0x0090E1BC File Offset: 0x0090C3BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DispersionLightPostprocess_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_DispersionLightPostprocess.BP_DispersionLightPostprocess_C");
			}
			return BP_DispersionLightPostprocess_C._ClassPtr;
		}

		// Token: 0x0601F4B8 RID: 128184 RVA: 0x0090E1E0 File Offset: 0x0090C3E0
		public BP_DispersionLightPostprocess_C() : this(BuiltinUtils.AllocNativeUObject(BP_DispersionLightPostprocess_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F4B9 RID: 128185 RVA: 0x0090E208 File Offset: 0x0090C408
		[NullableContext(1)]
		public BP_DispersionLightPostprocess_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DispersionLightPostprocess_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002F03 RID: 12035
		// (get) Token: 0x0601F4BA RID: 128186 RVA: 0x0090E23C File Offset: 0x0090C43C
		// (set) Token: 0x0601F4BB RID: 128187 RVA: 0x0090E275 File Offset: 0x0090C475
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002F04 RID: 12036
		// (get) Token: 0x0601F4BC RID: 128188 RVA: 0x0090E296 File Offset: 0x0090C496
		// (set) Token: 0x0601F4BD RID: 128189 RVA: 0x0090E2AA File Offset: 0x0090C4AA
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002F05 RID: 12037
		// (get) Token: 0x0601F4BE RID: 128190 RVA: 0x0090E2BF File Offset: 0x0090C4BF
		// (set) Token: 0x0601F4BF RID: 128191 RVA: 0x0090E2D3 File Offset: 0x0090C4D3
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002F06 RID: 12038
		// (get) Token: 0x0601F4C0 RID: 128192 RVA: 0x0090E2E8 File Offset: 0x0090C4E8
		// (set) Token: 0x0601F4C1 RID: 128193 RVA: 0x0090E2FC File Offset: 0x0090C4FC
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002F07 RID: 12039
		// (get) Token: 0x0601F4C2 RID: 128194 RVA: 0x0090E311 File Offset: 0x0090C511
		// (set) Token: 0x0601F4C3 RID: 128195 RVA: 0x0090E325 File Offset: 0x0090C525
		public unsafe UMaterialInterface MainMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002F08 RID: 12040
		// (get) Token: 0x0601F4C4 RID: 128196 RVA: 0x0090E33A File Offset: 0x0090C53A
		// (set) Token: 0x0601F4C5 RID: 128197 RVA: 0x0090E34E File Offset: 0x0090C54E
		public unsafe UMaterialInterface AddMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002F09 RID: 12041
		// (get) Token: 0x0601F4C6 RID: 128198 RVA: 0x0090E363 File Offset: 0x0090C563
		// (set) Token: 0x0601F4C7 RID: 128199 RVA: 0x0090E377 File Offset: 0x0090C577
		public unsafe UMaterialInterface MultyMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002F0A RID: 12042
		// (get) Token: 0x0601F4C8 RID: 128200 RVA: 0x0090E38C File Offset: 0x0090C58C
		// (set) Token: 0x0601F4C9 RID: 128201 RVA: 0x0090E3A0 File Offset: 0x0090C5A0
		public unsafe UTexture BaseTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002F0B RID: 12043
		// (get) Token: 0x0601F4CA RID: 128202 RVA: 0x0090E3B5 File Offset: 0x0090C5B5
		// (set) Token: 0x0601F4CB RID: 128203 RVA: 0x0090E3C9 File Offset: 0x0090C5C9
		public unsafe FLinearColor BaseTexRGBA_Strength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002F0C RID: 12044
		// (get) Token: 0x0601F4CC RID: 128204 RVA: 0x0090E3DE File Offset: 0x0090C5DE
		// (set) Token: 0x0601F4CD RID: 128205 RVA: 0x0090E3F2 File Offset: 0x0090C5F2
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002F0D RID: 12045
		// (get) Token: 0x0601F4CE RID: 128206 RVA: 0x0090E407 File Offset: 0x0090C607
		// (set) Token: 0x0601F4CF RID: 128207 RVA: 0x0090E41B File Offset: 0x0090C61B
		public unsafe FLinearColor LightShadowColor_Multi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002F0E RID: 12046
		// (get) Token: 0x0601F4D0 RID: 128208 RVA: 0x0090E430 File Offset: 0x0090C630
		// (set) Token: 0x0601F4D1 RID: 128209 RVA: 0x0090E440 File Offset: 0x0090C640
		public unsafe float LightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002F0F RID: 12047
		// (get) Token: 0x0601F4D2 RID: 128210 RVA: 0x0090E451 File Offset: 0x0090C651
		// (set) Token: 0x0601F4D3 RID: 128211 RVA: 0x0090E461 File Offset: 0x0090C661
		public unsafe float LightShadowIntensity_Multi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002F10 RID: 12048
		// (get) Token: 0x0601F4D4 RID: 128212 RVA: 0x0090E472 File Offset: 0x0090C672
		// (set) Token: 0x0601F4D5 RID: 128213 RVA: 0x0090E482 File Offset: 0x0090C682
		public unsafe float ShadowProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002F11 RID: 12049
		// (get) Token: 0x0601F4D6 RID: 128214 RVA: 0x0090E493 File Offset: 0x0090C693
		// (set) Token: 0x0601F4D7 RID: 128215 RVA: 0x0090E4A3 File Offset: 0x0090C6A3
		public unsafe float ShadowWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002F12 RID: 12050
		// (get) Token: 0x0601F4D8 RID: 128216 RVA: 0x0090E4B4 File Offset: 0x0090C6B4
		// (set) Token: 0x0601F4D9 RID: 128217 RVA: 0x0090E4C4 File Offset: 0x0090C6C4
		public unsafe float InnerRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002F13 RID: 12051
		// (get) Token: 0x0601F4DA RID: 128218 RVA: 0x0090E4D5 File Offset: 0x0090C6D5
		// (set) Token: 0x0601F4DB RID: 128219 RVA: 0x0090E4E5 File Offset: 0x0090C6E5
		public unsafe float SecondOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002F14 RID: 12052
		// (get) Token: 0x0601F4DC RID: 128220 RVA: 0x0090E4F6 File Offset: 0x0090C6F6
		// (set) Token: 0x0601F4DD RID: 128221 RVA: 0x0090E506 File Offset: 0x0090C706
		public unsafe float ThirdOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002F15 RID: 12053
		// (get) Token: 0x0601F4DE RID: 128222 RVA: 0x0090E517 File Offset: 0x0090C717
		// (set) Token: 0x0601F4DF RID: 128223 RVA: 0x0090E527 File Offset: 0x0090C727
		public unsafe float OffsetStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002F16 RID: 12054
		// (get) Token: 0x0601F4E0 RID: 128224 RVA: 0x0090E538 File Offset: 0x0090C738
		// (set) Token: 0x0601F4E1 RID: 128225 RVA: 0x0090E548 File Offset: 0x0090C748
		public unsafe float U_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002F17 RID: 12055
		// (get) Token: 0x0601F4E2 RID: 128226 RVA: 0x0090E559 File Offset: 0x0090C759
		// (set) Token: 0x0601F4E3 RID: 128227 RVA: 0x0090E569 File Offset: 0x0090C769
		public unsafe float V_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002F18 RID: 12056
		// (get) Token: 0x0601F4E4 RID: 128228 RVA: 0x0090E57A File Offset: 0x0090C77A
		// (set) Token: 0x0601F4E5 RID: 128229 RVA: 0x0090E58A File Offset: 0x0090C78A
		public unsafe float U_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002F19 RID: 12057
		// (get) Token: 0x0601F4E6 RID: 128230 RVA: 0x0090E59B File Offset: 0x0090C79B
		// (set) Token: 0x0601F4E7 RID: 128231 RVA: 0x0090E5AB File Offset: 0x0090C7AB
		public unsafe float V_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002F1A RID: 12058
		// (get) Token: 0x0601F4E8 RID: 128232 RVA: 0x0090E5BC File Offset: 0x0090C7BC
		// (set) Token: 0x0601F4E9 RID: 128233 RVA: 0x0090E5D0 File Offset: 0x0090C7D0
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17002F1B RID: 12059
		// (get) Token: 0x0601F4EA RID: 128234 RVA: 0x0090E5E5 File Offset: 0x0090C7E5
		// (set) Token: 0x0601F4EB RID: 128235 RVA: 0x0090E5F5 File Offset: 0x0090C7F5
		public unsafe bool UseMultiBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F1C RID: 12060
		// (get) Token: 0x0601F4EC RID: 128236 RVA: 0x0090E608 File Offset: 0x0090C808
		// (set) Token: 0x0601F4ED RID: 128237 RVA: 0x0090E641 File Offset: 0x0090C841
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002F1D RID: 12061
		// (get) Token: 0x0601F4EE RID: 128238 RVA: 0x0090E650 File Offset: 0x0090C850
		// (set) Token: 0x0601F4EF RID: 128239 RVA: 0x0090E689 File Offset: 0x0090C889
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_26, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002F1E RID: 12062
		// (get) Token: 0x0601F4F0 RID: 128240 RVA: 0x0090E698 File Offset: 0x0090C898
		// (set) Token: 0x0601F4F1 RID: 128241 RVA: 0x0090E6D1 File Offset: 0x0090C8D1
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002F1F RID: 12063
		// (get) Token: 0x0601F4F2 RID: 128242 RVA: 0x0090E6DF File Offset: 0x0090C8DF
		// (set) Token: 0x0601F4F3 RID: 128243 RVA: 0x0090E6EF File Offset: 0x0090C8EF
		public unsafe float NoiseUSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002F20 RID: 12064
		// (get) Token: 0x0601F4F4 RID: 128244 RVA: 0x0090E700 File Offset: 0x0090C900
		// (set) Token: 0x0601F4F5 RID: 128245 RVA: 0x0090E710 File Offset: 0x0090C910
		public unsafe float NoiseVSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002F21 RID: 12065
		// (get) Token: 0x0601F4F6 RID: 128246 RVA: 0x0090E721 File Offset: 0x0090C921
		// (set) Token: 0x0601F4F7 RID: 128247 RVA: 0x0090E731 File Offset: 0x0090C931
		public unsafe float NoiseUVMulty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002F22 RID: 12066
		// (get) Token: 0x0601F4F8 RID: 128248 RVA: 0x0090E742 File Offset: 0x0090C942
		// (set) Token: 0x0601F4F9 RID: 128249 RVA: 0x0090E752 File Offset: 0x0090C952
		public unsafe float NoiseStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002F23 RID: 12067
		// (get) Token: 0x0601F4FA RID: 128250 RVA: 0x0090E763 File Offset: 0x0090C963
		// (set) Token: 0x0601F4FB RID: 128251 RVA: 0x0090E777 File Offset: 0x0090C977
		public unsafe UTexture NoiseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DispersionLightPostprocess_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17002F24 RID: 12068
		// (get) Token: 0x0601F4FC RID: 128252 RVA: 0x0090E78C File Offset: 0x0090C98C
		// (set) Token: 0x0601F4FD RID: 128253 RVA: 0x0090E79C File Offset: 0x0090C99C
		public unsafe float Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17002F25 RID: 12069
		// (get) Token: 0x0601F4FE RID: 128254 RVA: 0x0090E7AD File Offset: 0x0090C9AD
		// (set) Token: 0x0601F4FF RID: 128255 RVA: 0x0090E7BD File Offset: 0x0090C9BD
		public unsafe float Desaturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DispersionLightPostprocess_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x0601F500 RID: 128256 RVA: 0x0090E7CE File Offset: 0x0090C9CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0601F501 RID: 128257 RVA: 0x0090E7E2 File Offset: 0x0090C9E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__UpdateEditor_NativeFunctionPtr, null);
		}

		// Token: 0x0601F502 RID: 128258 RVA: 0x0090E7F6 File Offset: 0x0090C9F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F503 RID: 128259 RVA: 0x0090E80A File Offset: 0x0090CA0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F504 RID: 128260 RVA: 0x0090E81F File Offset: 0x0090CA1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F505 RID: 128261 RVA: 0x0090E833 File Offset: 0x0090CA33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F506 RID: 128262 RVA: 0x0090E848 File Offset: 0x0090CA48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DispersionLightPostprocess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DispersionLightPostprocess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DispersionLightPostprocess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DispersionLightPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F507 RID: 128263 RVA: 0x0090E890 File Offset: 0x0090CA90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DispersionLightPostprocess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DispersionLightPostprocess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DispersionLightPostprocess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DispersionLightPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F508 RID: 128264 RVA: 0x0090E8D7 File Offset: 0x0090CAD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F509 RID: 128265 RVA: 0x0090E8EB File Offset: 0x0090CAEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F50A RID: 128266 RVA: 0x0090E900 File Offset: 0x0090CB00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DispersionLightPostprocess(int EntryPoint)
		{
			BP_DispersionLightPostprocess_C.__ExecuteUbergraph_BP_DispersionLightPostprocess_FunctionParams* ptr = stackalloc BP_DispersionLightPostprocess_C.__ExecuteUbergraph_BP_DispersionLightPostprocess_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_DispersionLightPostprocess_C.__ExecuteUbergraph_BP_DispersionLightPostprocess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DispersionLightPostprocess_C.__ExecuteUbergraph_BP_DispersionLightPostprocess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DispersionLightPostprocess_C.__ExecuteUbergraph_BP_DispersionLightPostprocess_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F50B RID: 128267 RVA: 0x0090E947 File Offset: 0x0090CB47
		protected BP_DispersionLightPostprocess_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F87B RID: 63611
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_DispersionLightPostprocess.BP_DispersionLightPostprocess_C";

		// Token: 0x0400F87C RID: 63612
		private static IntPtr _ClassPtr;

		// Token: 0x0400F87D RID: 63613
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F87E RID: 63614
		internal static int __PropertyOffset_0;

		// Token: 0x0400F87F RID: 63615
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F880 RID: 63616
		internal static int __PropertyOffset_1;

		// Token: 0x0400F881 RID: 63617
		internal static int __PropertyOffset_2;

		// Token: 0x0400F882 RID: 63618
		internal static int __PropertyOffset_3;

		// Token: 0x0400F883 RID: 63619
		internal static int __PropertyOffset_4;

		// Token: 0x0400F884 RID: 63620
		internal static int __PropertyOffset_5;

		// Token: 0x0400F885 RID: 63621
		internal static int __PropertyOffset_6;

		// Token: 0x0400F886 RID: 63622
		internal static int __PropertyOffset_7;

		// Token: 0x0400F887 RID: 63623
		internal static int __PropertyOffset_8;

		// Token: 0x0400F888 RID: 63624
		internal static int __PropertyOffset_9;

		// Token: 0x0400F889 RID: 63625
		internal static int __PropertyOffset_10;

		// Token: 0x0400F88A RID: 63626
		internal static int __PropertyOffset_11;

		// Token: 0x0400F88B RID: 63627
		internal static int __PropertyOffset_12;

		// Token: 0x0400F88C RID: 63628
		internal static int __PropertyOffset_13;

		// Token: 0x0400F88D RID: 63629
		internal static int __PropertyOffset_14;

		// Token: 0x0400F88E RID: 63630
		internal static int __PropertyOffset_15;

		// Token: 0x0400F88F RID: 63631
		internal static int __PropertyOffset_16;

		// Token: 0x0400F890 RID: 63632
		internal static int __PropertyOffset_17;

		// Token: 0x0400F891 RID: 63633
		internal static int __PropertyOffset_18;

		// Token: 0x0400F892 RID: 63634
		internal static int __PropertyOffset_19;

		// Token: 0x0400F893 RID: 63635
		internal static int __PropertyOffset_20;

		// Token: 0x0400F894 RID: 63636
		internal static int __PropertyOffset_21;

		// Token: 0x0400F895 RID: 63637
		internal static int __PropertyOffset_22;

		// Token: 0x0400F896 RID: 63638
		internal static int __PropertyOffset_23;

		// Token: 0x0400F897 RID: 63639
		internal static int __PropertyOffset_24;

		// Token: 0x0400F898 RID: 63640
		internal static int __PropertyOffset_25;

		// Token: 0x0400F899 RID: 63641
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F89A RID: 63642
		internal static int __PropertyOffset_26;

		// Token: 0x0400F89B RID: 63643
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F89C RID: 63644
		internal static int __PropertyOffset_27;

		// Token: 0x0400F89D RID: 63645
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F89E RID: 63646
		internal static int __PropertyOffset_28;

		// Token: 0x0400F89F RID: 63647
		internal static int __PropertyOffset_29;

		// Token: 0x0400F8A0 RID: 63648
		internal static int __PropertyOffset_30;

		// Token: 0x0400F8A1 RID: 63649
		internal static int __PropertyOffset_31;

		// Token: 0x0400F8A2 RID: 63650
		internal static int __PropertyOffset_32;

		// Token: 0x0400F8A3 RID: 63651
		internal static int __PropertyOffset_33;

		// Token: 0x0400F8A4 RID: 63652
		internal static int __PropertyOffset_34;

		// Token: 0x0400F8A5 RID: 63653
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0400F8A6 RID: 63654
		private static IntPtr __UpdateEditor_NativeFunctionPtr;

		// Token: 0x0400F8A7 RID: 63655
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F8A8 RID: 63656
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F8A9 RID: 63657
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F8AA RID: 63658
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F8AB RID: 63659
		private static IntPtr __ExecuteUbergraph_BP_DispersionLightPostprocess_NativeFunctionPtr;

		// Token: 0x020098C5 RID: 39109
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F16 RID: 204566
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098C6 RID: 39110
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_BP_DispersionLightPostprocess_FunctionParams
		{
			// Token: 0x04031F17 RID: 204567
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
