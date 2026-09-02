using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004004 RID: 16388
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/BP_FlashLightConfig.BP_FlashLightConfig_C")]
	[UnrealStructLayout(256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 252)]
	public class BP_FlashLightConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A897 RID: 174231 RVA: 0x00A5C44C File Offset: 0x00A5A64C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FlashLightConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Structure/BP_FlashLightConfig.BP_FlashLightConfig_C");
			}
			return BP_FlashLightConfig_C._ClassPtr;
		}

		// Token: 0x0602A898 RID: 174232 RVA: 0x00A5C470 File Offset: 0x00A5A670
		public BP_FlashLightConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FlashLightConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A899 RID: 174233 RVA: 0x00A5C498 File Offset: 0x00A5A698
		[NullableContext(1)]
		public BP_FlashLightConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FlashLightConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006E8A RID: 28298
		// (get) Token: 0x0602A89A RID: 174234 RVA: 0x00A5C4CB File Offset: 0x00A5A6CB
		// (set) Token: 0x0602A89B RID: 174235 RVA: 0x00A5C4DF File Offset: 0x00A5A6DF
		public unsafe FTransform RelativeTrans
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006E8B RID: 28299
		// (get) Token: 0x0602A89C RID: 174236 RVA: 0x00A5C4F4 File Offset: 0x00A5A6F4
		// (set) Token: 0x0602A89D RID: 174237 RVA: 0x00A5C504 File Offset: 0x00A5A704
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006E8C RID: 28300
		// (get) Token: 0x0602A89E RID: 174238 RVA: 0x00A5C515 File Offset: 0x00A5A715
		// (set) Token: 0x0602A89F RID: 174239 RVA: 0x00A5C525 File Offset: 0x00A5A725
		public unsafe float AttenuationRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006E8D RID: 28301
		// (get) Token: 0x0602A8A0 RID: 174240 RVA: 0x00A5C536 File Offset: 0x00A5A736
		// (set) Token: 0x0602A8A1 RID: 174241 RVA: 0x00A5C546 File Offset: 0x00A5A746
		public unsafe float InnerConeAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006E8E RID: 28302
		// (get) Token: 0x0602A8A2 RID: 174242 RVA: 0x00A5C557 File Offset: 0x00A5A757
		// (set) Token: 0x0602A8A3 RID: 174243 RVA: 0x00A5C567 File Offset: 0x00A5A767
		public unsafe float OuterConeAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006E8F RID: 28303
		// (get) Token: 0x0602A8A4 RID: 174244 RVA: 0x00A5C578 File Offset: 0x00A5A778
		// (set) Token: 0x0602A8A5 RID: 174245 RVA: 0x00A5C588 File Offset: 0x00A5A788
		public unsafe float SpecularScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006E90 RID: 28304
		// (get) Token: 0x0602A8A6 RID: 174246 RVA: 0x00A5C599 File Offset: 0x00A5A799
		// (set) Token: 0x0602A8A7 RID: 174247 RVA: 0x00A5C5AD File Offset: 0x00A5A7AD
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006E91 RID: 28305
		// (get) Token: 0x0602A8A8 RID: 174248 RVA: 0x00A5C5C2 File Offset: 0x00A5A7C2
		// (set) Token: 0x0602A8A9 RID: 174249 RVA: 0x00A5C5D2 File Offset: 0x00A5A7D2
		public unsafe bool UseCameraPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E92 RID: 28306
		// (get) Token: 0x0602A8AA RID: 174250 RVA: 0x00A5C5E3 File Offset: 0x00A5A7E3
		// (set) Token: 0x0602A8AB RID: 174251 RVA: 0x00A5C5F3 File Offset: 0x00A5A7F3
		public unsafe bool UsePitchLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E93 RID: 28307
		// (get) Token: 0x0602A8AC RID: 174252 RVA: 0x00A5C604 File Offset: 0x00A5A804
		// (set) Token: 0x0602A8AD RID: 174253 RVA: 0x00A5C614 File Offset: 0x00A5A814
		public unsafe float MinTurnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006E94 RID: 28308
		// (get) Token: 0x0602A8AE RID: 174254 RVA: 0x00A5C625 File Offset: 0x00A5A825
		// (set) Token: 0x0602A8AF RID: 174255 RVA: 0x00A5C635 File Offset: 0x00A5A835
		public unsafe float MaxTurnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006E95 RID: 28309
		// (get) Token: 0x0602A8B0 RID: 174256 RVA: 0x00A5C646 File Offset: 0x00A5A846
		// (set) Token: 0x0602A8B1 RID: 174257 RVA: 0x00A5C656 File Offset: 0x00A5A856
		public unsafe float LerpBeginDeg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006E96 RID: 28310
		// (get) Token: 0x0602A8B2 RID: 174258 RVA: 0x00A5C667 File Offset: 0x00A5A867
		// (set) Token: 0x0602A8B3 RID: 174259 RVA: 0x00A5C677 File Offset: 0x00A5A877
		public unsafe float LerpPow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006E97 RID: 28311
		// (get) Token: 0x0602A8B4 RID: 174260 RVA: 0x00A5C688 File Offset: 0x00A5A888
		// (set) Token: 0x0602A8B5 RID: 174261 RVA: 0x00A5C69C File Offset: 0x00A5A89C
		public unsafe UCurveFloat LerpCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlashLightConfig_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlashLightConfig_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17006E98 RID: 28312
		// (get) Token: 0x0602A8B6 RID: 174262 RVA: 0x00A5C6B1 File Offset: 0x00A5A8B1
		// (set) Token: 0x0602A8B7 RID: 174263 RVA: 0x00A5C6C1 File Offset: 0x00A5A8C1
		public unsafe float ToonIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006E99 RID: 28313
		// (get) Token: 0x0602A8B8 RID: 174264 RVA: 0x00A5C6D2 File Offset: 0x00A5A8D2
		// (set) Token: 0x0602A8B9 RID: 174265 RVA: 0x00A5C6E2 File Offset: 0x00A5A8E2
		public unsafe float ToonShadowColorIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006E9A RID: 28314
		// (get) Token: 0x0602A8BA RID: 174266 RVA: 0x00A5C6F3 File Offset: 0x00A5A8F3
		// (set) Token: 0x0602A8BB RID: 174267 RVA: 0x00A5C703 File Offset: 0x00A5A903
		public unsafe float ToonRealTimeShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17006E9B RID: 28315
		// (get) Token: 0x0602A8BC RID: 174268 RVA: 0x00A5C714 File Offset: 0x00A5A914
		// (set) Token: 0x0602A8BD RID: 174269 RVA: 0x00A5C728 File Offset: 0x00A5A928
		public unsafe FLinearColor LightToonColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006E9C RID: 28316
		// (get) Token: 0x0602A8BE RID: 174270 RVA: 0x00A5C73D File Offset: 0x00A5A93D
		// (set) Token: 0x0602A8BF RID: 174271 RVA: 0x00A5C74D File Offset: 0x00A5A94D
		public unsafe float ToonPointLightFallOff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17006E9D RID: 28317
		// (get) Token: 0x0602A8C0 RID: 174272 RVA: 0x00A5C75E File Offset: 0x00A5A95E
		// (set) Token: 0x0602A8C1 RID: 174273 RVA: 0x00A5C76E File Offset: 0x00A5A96E
		public unsafe float ToonDistanceBlendIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17006E9E RID: 28318
		// (get) Token: 0x0602A8C2 RID: 174274 RVA: 0x00A5C77F File Offset: 0x00A5A97F
		// (set) Token: 0x0602A8C3 RID: 174275 RVA: 0x00A5C78F File Offset: 0x00A5A98F
		public unsafe int ToonLightingPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17006E9F RID: 28319
		// (get) Token: 0x0602A8C4 RID: 174276 RVA: 0x00A5C7A0 File Offset: 0x00A5A9A0
		// (set) Token: 0x0602A8C5 RID: 174277 RVA: 0x00A5C7B0 File Offset: 0x00A5A9B0
		public unsafe float LightFalloffExponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17006EA0 RID: 28320
		// (get) Token: 0x0602A8C6 RID: 174278 RVA: 0x00A5C7C1 File Offset: 0x00A5A9C1
		// (set) Token: 0x0602A8C7 RID: 174279 RVA: 0x00A5C7D5 File Offset: 0x00A5A9D5
		public unsafe UTextureLightProfile IESTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureLightProfile>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlashLightConfig_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlashLightConfig_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17006EA1 RID: 28321
		// (get) Token: 0x0602A8C8 RID: 174280 RVA: 0x00A5C7EA File Offset: 0x00A5A9EA
		// (set) Token: 0x0602A8C9 RID: 174281 RVA: 0x00A5C7FA File Offset: 0x00A5A9FA
		public unsafe float VolumetricScatteringIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FlashLightConfig_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x0602A8CA RID: 174282 RVA: 0x00A5C80B File Offset: 0x00A5AA0B
		protected BP_FlashLightConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401721E RID: 94750
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/BP_FlashLightConfig.BP_FlashLightConfig_C";

		// Token: 0x0401721F RID: 94751
		private static IntPtr _ClassPtr;

		// Token: 0x04017220 RID: 94752
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017221 RID: 94753
		internal static int __PropertyOffset_0;

		// Token: 0x04017222 RID: 94754
		internal static int __PropertyOffset_1;

		// Token: 0x04017223 RID: 94755
		internal static int __PropertyOffset_2;

		// Token: 0x04017224 RID: 94756
		internal static int __PropertyOffset_3;

		// Token: 0x04017225 RID: 94757
		internal static int __PropertyOffset_4;

		// Token: 0x04017226 RID: 94758
		internal static int __PropertyOffset_5;

		// Token: 0x04017227 RID: 94759
		internal static int __PropertyOffset_6;

		// Token: 0x04017228 RID: 94760
		internal static int __PropertyOffset_7;

		// Token: 0x04017229 RID: 94761
		internal static int __PropertyOffset_8;

		// Token: 0x0401722A RID: 94762
		internal static int __PropertyOffset_9;

		// Token: 0x0401722B RID: 94763
		internal static int __PropertyOffset_10;

		// Token: 0x0401722C RID: 94764
		internal static int __PropertyOffset_11;

		// Token: 0x0401722D RID: 94765
		internal static int __PropertyOffset_12;

		// Token: 0x0401722E RID: 94766
		internal static int __PropertyOffset_13;

		// Token: 0x0401722F RID: 94767
		internal static int __PropertyOffset_14;

		// Token: 0x04017230 RID: 94768
		internal static int __PropertyOffset_15;

		// Token: 0x04017231 RID: 94769
		internal static int __PropertyOffset_16;

		// Token: 0x04017232 RID: 94770
		internal static int __PropertyOffset_17;

		// Token: 0x04017233 RID: 94771
		internal static int __PropertyOffset_18;

		// Token: 0x04017234 RID: 94772
		internal static int __PropertyOffset_19;

		// Token: 0x04017235 RID: 94773
		internal static int __PropertyOffset_20;

		// Token: 0x04017236 RID: 94774
		internal static int __PropertyOffset_21;

		// Token: 0x04017237 RID: 94775
		internal static int __PropertyOffset_22;

		// Token: 0x04017238 RID: 94776
		internal static int __PropertyOffset_23;
	}
}
