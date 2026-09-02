using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE4 RID: 15844
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelPostProcess.BP_EffectModelPostProcess_C")]
	[UnrealStructLayout(7632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 7632)]
	public class BP_EffectModelPostProcess_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026E0B RID: 159243 RVA: 0x009E42CC File Offset: 0x009E24CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelPostProcess_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelPostProcess.BP_EffectModelPostProcess_C");
			}
			return BP_EffectModelPostProcess_C._ClassPtr;
		}

		// Token: 0x06026E0C RID: 159244 RVA: 0x009E42F0 File Offset: 0x009E24F0
		public BP_EffectModelPostProcess_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelPostProcess_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026E0D RID: 159245 RVA: 0x009E4318 File Offset: 0x009E2518
		public BP_EffectModelPostProcess_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelPostProcess_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170059B6 RID: 22966
		// (get) Token: 0x06026E0E RID: 159246 RVA: 0x009E434C File Offset: 0x009E254C
		// (set) Token: 0x06026E0F RID: 159247 RVA: 0x009E4385 File Offset: 0x009E2585
		public FKuroCurveVector Location
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059B7 RID: 22967
		// (get) Token: 0x06026E10 RID: 159248 RVA: 0x009E43A8 File Offset: 0x009E25A8
		// (set) Token: 0x06026E11 RID: 159249 RVA: 0x009E43E1 File Offset: 0x009E25E1
		public FKuroCurveFloat BlurIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._BlurIntensity) == null)
				{
					result = (this._BlurIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059B8 RID: 22968
		// (get) Token: 0x06026E12 RID: 159250 RVA: 0x009E4402 File Offset: 0x009E2602
		// (set) Token: 0x06026E13 RID: 159251 RVA: 0x009E4412 File Offset: 0x009E2612
		public unsafe bool EnableVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059B9 RID: 22969
		// (get) Token: 0x06026E14 RID: 159252 RVA: 0x009E4423 File Offset: 0x009E2623
		// (set) Token: 0x06026E15 RID: 159253 RVA: 0x009E4433 File Offset: 0x009E2633
		public unsafe float VolumeRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170059BA RID: 22970
		// (get) Token: 0x06026E16 RID: 159254 RVA: 0x009E4444 File Offset: 0x009E2644
		// (set) Token: 0x06026E17 RID: 159255 RVA: 0x009E4454 File Offset: 0x009E2654
		public unsafe float VolumeHardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170059BB RID: 22971
		// (get) Token: 0x06026E18 RID: 159256 RVA: 0x009E4465 File Offset: 0x009E2665
		// (set) Token: 0x06026E19 RID: 159257 RVA: 0x009E4475 File Offset: 0x009E2675
		public unsafe bool UseWorldPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059BC RID: 22972
		// (get) Token: 0x06026E1A RID: 159258 RVA: 0x009E4486 File Offset: 0x009E2686
		// (set) Token: 0x06026E1B RID: 159259 RVA: 0x009E449A File Offset: 0x009E269A
		public unsafe FVector2D ScreenPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170059BD RID: 22973
		// (get) Token: 0x06026E1C RID: 159260 RVA: 0x009E44AF File Offset: 0x009E26AF
		// (set) Token: 0x06026E1D RID: 159261 RVA: 0x009E44BF File Offset: 0x009E26BF
		public unsafe bool BlurIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059BE RID: 22974
		// (get) Token: 0x06026E1E RID: 159262 RVA: 0x009E44D0 File Offset: 0x009E26D0
		// (set) Token: 0x06026E1F RID: 159263 RVA: 0x009E44E0 File Offset: 0x009E26E0
		public unsafe bool MainLightIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059BF RID: 22975
		// (get) Token: 0x06026E20 RID: 159264 RVA: 0x009E44F4 File Offset: 0x009E26F4
		// (set) Token: 0x06026E21 RID: 159265 RVA: 0x009E452D File Offset: 0x009E272D
		public FKuroCurveFloat MainLightIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._MainLightIntensity) == null)
				{
					result = (this._MainLightIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059C0 RID: 22976
		// (get) Token: 0x06026E22 RID: 159266 RVA: 0x009E454E File Offset: 0x009E274E
		// (set) Token: 0x06026E23 RID: 159267 RVA: 0x009E455E File Offset: 0x009E275E
		public unsafe bool MainLightColorOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059C1 RID: 22977
		// (get) Token: 0x06026E24 RID: 159268 RVA: 0x009E4570 File Offset: 0x009E2770
		// (set) Token: 0x06026E25 RID: 159269 RVA: 0x009E45A9 File Offset: 0x009E27A9
		public FKuroCurveLinearColor MainLightColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._MainLightColor) == null)
				{
					result = (this._MainLightColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059C2 RID: 22978
		// (get) Token: 0x06026E26 RID: 159270 RVA: 0x009E45CA File Offset: 0x009E27CA
		// (set) Token: 0x06026E27 RID: 159271 RVA: 0x009E45DA File Offset: 0x009E27DA
		public unsafe bool SkyLightIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059C3 RID: 22979
		// (get) Token: 0x06026E28 RID: 159272 RVA: 0x009E45EC File Offset: 0x009E27EC
		// (set) Token: 0x06026E29 RID: 159273 RVA: 0x009E4625 File Offset: 0x009E2825
		public FKuroCurveFloat SkyLightIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._SkyLightIntensity) == null)
				{
					result = (this._SkyLightIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059C4 RID: 22980
		// (get) Token: 0x06026E2A RID: 159274 RVA: 0x009E4646 File Offset: 0x009E2846
		// (set) Token: 0x06026E2B RID: 159275 RVA: 0x009E4656 File Offset: 0x009E2856
		public unsafe bool SkyLightColorOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059C5 RID: 22981
		// (get) Token: 0x06026E2C RID: 159276 RVA: 0x009E4668 File Offset: 0x009E2868
		// (set) Token: 0x06026E2D RID: 159277 RVA: 0x009E46A1 File Offset: 0x009E28A1
		public FKuroCurveLinearColor SkyLightColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._SkyLightColor) == null)
				{
					result = (this._SkyLightColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059C6 RID: 22982
		// (get) Token: 0x06026E2E RID: 159278 RVA: 0x009E46C2 File Offset: 0x009E28C2
		// (set) Token: 0x06026E2F RID: 159279 RVA: 0x009E46D2 File Offset: 0x009E28D2
		public unsafe bool FogDensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059C7 RID: 22983
		// (get) Token: 0x06026E30 RID: 159280 RVA: 0x009E46E4 File Offset: 0x009E28E4
		// (set) Token: 0x06026E31 RID: 159281 RVA: 0x009E471D File Offset: 0x009E291D
		public FKuroCurveFloat FogDensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._FogDensity) == null)
				{
					result = (this._FogDensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059C8 RID: 22984
		// (get) Token: 0x06026E32 RID: 159282 RVA: 0x009E473E File Offset: 0x009E293E
		// (set) Token: 0x06026E33 RID: 159283 RVA: 0x009E474E File Offset: 0x009E294E
		public unsafe bool FogColorOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059C9 RID: 22985
		// (get) Token: 0x06026E34 RID: 159284 RVA: 0x009E4760 File Offset: 0x009E2960
		// (set) Token: 0x06026E35 RID: 159285 RVA: 0x009E4799 File Offset: 0x009E2999
		public FKuroCurveLinearColor FogColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._FogColor) == null)
				{
					result = (this._FogColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059CA RID: 22986
		// (get) Token: 0x06026E36 RID: 159286 RVA: 0x009E47BA File Offset: 0x009E29BA
		// (set) Token: 0x06026E37 RID: 159287 RVA: 0x009E47CA File Offset: 0x009E29CA
		public unsafe bool FogStartDistanceOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059CB RID: 22987
		// (get) Token: 0x06026E38 RID: 159288 RVA: 0x009E47DC File Offset: 0x009E29DC
		// (set) Token: 0x06026E39 RID: 159289 RVA: 0x009E4815 File Offset: 0x009E2A15
		public FKuroCurveFloat FogStartDistance
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._FogStartDistance) == null)
				{
					result = (this._FogStartDistance = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059CC RID: 22988
		// (get) Token: 0x06026E3A RID: 159290 RVA: 0x009E4836 File Offset: 0x009E2A36
		// (set) Token: 0x06026E3B RID: 159291 RVA: 0x009E4846 File Offset: 0x009E2A46
		public unsafe bool VolumetricFogColorOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059CD RID: 22989
		// (get) Token: 0x06026E3C RID: 159292 RVA: 0x009E4858 File Offset: 0x009E2A58
		// (set) Token: 0x06026E3D RID: 159293 RVA: 0x009E4891 File Offset: 0x009E2A91
		public FKuroCurveLinearColor VolumetricFogColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._VolumetricFogColor) == null)
				{
					result = (this._VolumetricFogColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059CE RID: 22990
		// (get) Token: 0x06026E3E RID: 159294 RVA: 0x009E48B2 File Offset: 0x009E2AB2
		// (set) Token: 0x06026E3F RID: 159295 RVA: 0x009E48C2 File Offset: 0x009E2AC2
		public unsafe bool VolumetricFogFalloffOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059CF RID: 22991
		// (get) Token: 0x06026E40 RID: 159296 RVA: 0x009E48D4 File Offset: 0x009E2AD4
		// (set) Token: 0x06026E41 RID: 159297 RVA: 0x009E490D File Offset: 0x009E2B0D
		public FKuroCurveFloat VolumetricFogFalloff
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._VolumetricFogFalloff) == null)
				{
					result = (this._VolumetricFogFalloff = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059D0 RID: 22992
		// (get) Token: 0x06026E42 RID: 159298 RVA: 0x009E492E File Offset: 0x009E2B2E
		// (set) Token: 0x06026E43 RID: 159299 RVA: 0x009E493E File Offset: 0x009E2B3E
		public unsafe bool VolumetricFogDistanceOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059D1 RID: 22993
		// (get) Token: 0x06026E44 RID: 159300 RVA: 0x009E4950 File Offset: 0x009E2B50
		// (set) Token: 0x06026E45 RID: 159301 RVA: 0x009E4989 File Offset: 0x009E2B89
		public FKuroCurveFloat VolumetricFogDistance
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._VolumetricFogDistance) == null)
				{
					result = (this._VolumetricFogDistance = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059D2 RID: 22994
		// (get) Token: 0x06026E46 RID: 159302 RVA: 0x009E49AA File Offset: 0x009E2BAA
		// (set) Token: 0x06026E47 RID: 159303 RVA: 0x009E49BA File Offset: 0x009E2BBA
		public unsafe bool KuroBloomIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059D3 RID: 22995
		// (get) Token: 0x06026E48 RID: 159304 RVA: 0x009E49CC File Offset: 0x009E2BCC
		// (set) Token: 0x06026E49 RID: 159305 RVA: 0x009E4A05 File Offset: 0x009E2C05
		public FKuroCurveFloat KuroBloomIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._KuroBloomIntensity) == null)
				{
					result = (this._KuroBloomIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059D4 RID: 22996
		// (get) Token: 0x06026E4A RID: 159306 RVA: 0x009E4A26 File Offset: 0x009E2C26
		// (set) Token: 0x06026E4B RID: 159307 RVA: 0x009E4A36 File Offset: 0x009E2C36
		public unsafe bool KuroThresholdOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059D5 RID: 22997
		// (get) Token: 0x06026E4C RID: 159308 RVA: 0x009E4A48 File Offset: 0x009E2C48
		// (set) Token: 0x06026E4D RID: 159309 RVA: 0x009E4A81 File Offset: 0x009E2C81
		public FKuroCurveFloat KuroThreshold
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._KuroThreshold) == null)
				{
					result = (this._KuroThreshold = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059D6 RID: 22998
		// (get) Token: 0x06026E4E RID: 159310 RVA: 0x009E4AA2 File Offset: 0x009E2CA2
		// (set) Token: 0x06026E4F RID: 159311 RVA: 0x009E4AB2 File Offset: 0x009E2CB2
		public unsafe bool SceneFringeIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059D7 RID: 22999
		// (get) Token: 0x06026E50 RID: 159312 RVA: 0x009E4AC4 File Offset: 0x009E2CC4
		// (set) Token: 0x06026E51 RID: 159313 RVA: 0x009E4AFD File Offset: 0x009E2CFD
		public FKuroCurveFloat SceneFringeIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._SceneFringeIntensity) == null)
				{
					result = (this._SceneFringeIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059D8 RID: 23000
		// (get) Token: 0x06026E52 RID: 159314 RVA: 0x009E4B1E File Offset: 0x009E2D1E
		// (set) Token: 0x06026E53 RID: 159315 RVA: 0x009E4B2E File Offset: 0x009E2D2E
		public unsafe bool StartOffsetOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059D9 RID: 23001
		// (get) Token: 0x06026E54 RID: 159316 RVA: 0x009E4B40 File Offset: 0x009E2D40
		// (set) Token: 0x06026E55 RID: 159317 RVA: 0x009E4B79 File Offset: 0x009E2D79
		public FKuroCurveFloat StartOffset
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._StartOffset) == null)
				{
					result = (this._StartOffset = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059DA RID: 23002
		// (get) Token: 0x06026E56 RID: 159318 RVA: 0x009E4B9A File Offset: 0x009E2D9A
		// (set) Token: 0x06026E57 RID: 159319 RVA: 0x009E4BAA File Offset: 0x009E2DAA
		public unsafe bool VignetteIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059DB RID: 23003
		// (get) Token: 0x06026E58 RID: 159320 RVA: 0x009E4BBC File Offset: 0x009E2DBC
		// (set) Token: 0x06026E59 RID: 159321 RVA: 0x009E4BF5 File Offset: 0x009E2DF5
		public FKuroCurveFloat VignetteIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._VignetteIntensity) == null)
				{
					result = (this._VignetteIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059DC RID: 23004
		// (get) Token: 0x06026E5A RID: 159322 RVA: 0x009E4C16 File Offset: 0x009E2E16
		// (set) Token: 0x06026E5B RID: 159323 RVA: 0x009E4C26 File Offset: 0x009E2E26
		public unsafe bool GrainJitterOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059DD RID: 23005
		// (get) Token: 0x06026E5C RID: 159324 RVA: 0x009E4C38 File Offset: 0x009E2E38
		// (set) Token: 0x06026E5D RID: 159325 RVA: 0x009E4C71 File Offset: 0x009E2E71
		public FKuroCurveFloat GrainJitter
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._GrainJitter) == null)
				{
					result = (this._GrainJitter = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059DE RID: 23006
		// (get) Token: 0x06026E5E RID: 159326 RVA: 0x009E4C92 File Offset: 0x009E2E92
		// (set) Token: 0x06026E5F RID: 159327 RVA: 0x009E4CA2 File Offset: 0x009E2EA2
		public unsafe bool GrainIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059DF RID: 23007
		// (get) Token: 0x06026E60 RID: 159328 RVA: 0x009E4CB4 File Offset: 0x009E2EB4
		// (set) Token: 0x06026E61 RID: 159329 RVA: 0x009E4CED File Offset: 0x009E2EED
		public FKuroCurveFloat GrainIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._GrainIntensity) == null)
				{
					result = (this._GrainIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059E0 RID: 23008
		// (get) Token: 0x06026E62 RID: 159330 RVA: 0x009E4D0E File Offset: 0x009E2F0E
		// (set) Token: 0x06026E63 RID: 159331 RVA: 0x009E4D1E File Offset: 0x009E2F1E
		public unsafe bool LutIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059E1 RID: 23009
		// (get) Token: 0x06026E64 RID: 159332 RVA: 0x009E4D30 File Offset: 0x009E2F30
		// (set) Token: 0x06026E65 RID: 159333 RVA: 0x009E4D69 File Offset: 0x009E2F69
		public FKuroCurveFloat LutIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._LutIntensity) == null)
				{
					result = (this._LutIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059E2 RID: 23010
		// (get) Token: 0x06026E66 RID: 159334 RVA: 0x009E4D8A File Offset: 0x009E2F8A
		// (set) Token: 0x06026E67 RID: 159335 RVA: 0x009E4D9A File Offset: 0x009E2F9A
		public unsafe bool LutTextureOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059E3 RID: 23011
		// (get) Token: 0x06026E68 RID: 159336 RVA: 0x009E4DAB File Offset: 0x009E2FAB
		// (set) Token: 0x06026E69 RID: 159337 RVA: 0x009E4DBF File Offset: 0x009E2FBF
		[Nullable(2)]
		public unsafe UTexture2D LutTexture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelPostProcess_C.__PropertyOffset_45);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelPostProcess_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x170059E4 RID: 23012
		// (get) Token: 0x06026E6A RID: 159338 RVA: 0x009E4DD4 File Offset: 0x009E2FD4
		// (set) Token: 0x06026E6B RID: 159339 RVA: 0x009E4DE4 File Offset: 0x009E2FE4
		public unsafe bool SceneColorTintOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059E5 RID: 23013
		// (get) Token: 0x06026E6C RID: 159340 RVA: 0x009E4DF8 File Offset: 0x009E2FF8
		// (set) Token: 0x06026E6D RID: 159341 RVA: 0x009E4E31 File Offset: 0x009E3031
		public FKuroCurveLinearColor SceneColorTint
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._SceneColorTint) == null)
				{
					result = (this._SceneColorTint = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059E6 RID: 23014
		// (get) Token: 0x06026E6E RID: 159342 RVA: 0x009E4E52 File Offset: 0x009E3052
		// (set) Token: 0x06026E6F RID: 159343 RVA: 0x009E4E62 File Offset: 0x009E3062
		public unsafe bool BlackWhiteFlashIntensityOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059E7 RID: 23015
		// (get) Token: 0x06026E70 RID: 159344 RVA: 0x009E4E74 File Offset: 0x009E3074
		// (set) Token: 0x06026E71 RID: 159345 RVA: 0x009E4EAD File Offset: 0x009E30AD
		public FKuroCurveFloat BlackWhiteFlashIntensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._BlackWhiteFlashIntensity) == null)
				{
					result = (this._BlackWhiteFlashIntensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059E8 RID: 23016
		// (get) Token: 0x06026E72 RID: 159346 RVA: 0x009E4ECE File Offset: 0x009E30CE
		// (set) Token: 0x06026E73 RID: 159347 RVA: 0x009E4EDE File Offset: 0x009E30DE
		public unsafe bool BlackWhiteFlashFactorOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059E9 RID: 23017
		// (get) Token: 0x06026E74 RID: 159348 RVA: 0x009E4EF0 File Offset: 0x009E30F0
		// (set) Token: 0x06026E75 RID: 159349 RVA: 0x009E4F29 File Offset: 0x009E3129
		public FKuroCurveFloat BlackWhiteFlashFactor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._BlackWhiteFlashFactor) == null)
				{
					result = (this._BlackWhiteFlashFactor = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059EA RID: 23018
		// (get) Token: 0x06026E76 RID: 159350 RVA: 0x009E4F4A File Offset: 0x009E314A
		// (set) Token: 0x06026E77 RID: 159351 RVA: 0x009E4F5A File Offset: 0x009E315A
		public unsafe bool BlackWhiteFlashThresholdOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_52) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_52) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059EB RID: 23019
		// (get) Token: 0x06026E78 RID: 159352 RVA: 0x009E4F6C File Offset: 0x009E316C
		// (set) Token: 0x06026E79 RID: 159353 RVA: 0x009E4FA5 File Offset: 0x009E31A5
		public FKuroCurveFloat BlackWhiteFlashThreshold
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._BlackWhiteFlashThreshold) == null)
				{
					result = (this._BlackWhiteFlashThreshold = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059EC RID: 23020
		// (get) Token: 0x06026E7A RID: 159354 RVA: 0x009E4FC6 File Offset: 0x009E31C6
		// (set) Token: 0x06026E7B RID: 159355 RVA: 0x009E4FD6 File Offset: 0x009E31D6
		public unsafe bool BlackWhiteFlashBlackAreaColorOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059ED RID: 23021
		// (get) Token: 0x06026E7C RID: 159356 RVA: 0x009E4FE8 File Offset: 0x009E31E8
		// (set) Token: 0x06026E7D RID: 159357 RVA: 0x009E5021 File Offset: 0x009E3221
		public FKuroCurveLinearColor BlackWhiteFlashBlackAreaColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._BlackWhiteFlashBlackAreaColor) == null)
				{
					result = (this._BlackWhiteFlashBlackAreaColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059EE RID: 23022
		// (get) Token: 0x06026E7E RID: 159358 RVA: 0x009E5042 File Offset: 0x009E3242
		// (set) Token: 0x06026E7F RID: 159359 RVA: 0x009E5052 File Offset: 0x009E3252
		public unsafe bool BlackWhiteFlashWhiteAreaColorOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059EF RID: 23023
		// (get) Token: 0x06026E80 RID: 159360 RVA: 0x009E5064 File Offset: 0x009E3264
		// (set) Token: 0x06026E81 RID: 159361 RVA: 0x009E509D File Offset: 0x009E329D
		public FKuroCurveLinearColor BlackWhiteFlashWhiteAreaColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._BlackWhiteFlashWhiteAreaColor) == null)
				{
					result = (this._BlackWhiteFlashWhiteAreaColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059F0 RID: 23024
		// (get) Token: 0x06026E82 RID: 159362 RVA: 0x009E50BE File Offset: 0x009E32BE
		// (set) Token: 0x06026E83 RID: 159363 RVA: 0x009E50D2 File Offset: 0x009E32D2
		[Nullable(2)]
		public unsafe UKuroWeatherDataAsset WeatherDataAsset
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelPostProcess_C.__PropertyOffset_58);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelPostProcess_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x170059F1 RID: 23025
		// (get) Token: 0x06026E84 RID: 159364 RVA: 0x009E50E7 File Offset: 0x009E32E7
		// (set) Token: 0x06026E85 RID: 159365 RVA: 0x009E50F7 File Offset: 0x009E32F7
		public unsafe float WeatherPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x170059F2 RID: 23026
		// (get) Token: 0x06026E86 RID: 159366 RVA: 0x009E5108 File Offset: 0x009E3308
		// (set) Token: 0x06026E87 RID: 159367 RVA: 0x009E5118 File Offset: 0x009E3318
		public unsafe bool UseVolumeHardnessCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_60) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_60) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059F3 RID: 23027
		// (get) Token: 0x06026E88 RID: 159368 RVA: 0x009E512C File Offset: 0x009E332C
		// (set) Token: 0x06026E89 RID: 159369 RVA: 0x009E5165 File Offset: 0x009E3365
		public FKuroCurveFloat VolumeHardnessCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._VolumeHardnessCurve) == null)
				{
					result = (this._VolumeHardnessCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059F4 RID: 23028
		// (get) Token: 0x06026E8A RID: 159370 RVA: 0x009E5188 File Offset: 0x009E3388
		// (set) Token: 0x06026E8B RID: 159371 RVA: 0x009E51C1 File Offset: 0x009E33C1
		public FKuroCurveFloat RadialBlurHardness
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._RadialBlurHardness) == null)
				{
					result = (this._RadialBlurHardness = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059F5 RID: 23029
		// (get) Token: 0x06026E8C RID: 159372 RVA: 0x009E51E4 File Offset: 0x009E33E4
		// (set) Token: 0x06026E8D RID: 159373 RVA: 0x009E521D File Offset: 0x009E341D
		public FKuroCurveFloat RadialBlurRadius
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._RadialBlurRadius) == null)
				{
					result = (this._RadialBlurRadius = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059F6 RID: 23030
		// (get) Token: 0x06026E8E RID: 159374 RVA: 0x009E523E File Offset: 0x009E343E
		// (set) Token: 0x06026E8F RID: 159375 RVA: 0x009E5252 File Offset: 0x009E3452
		[Nullable(2)]
		public unsafe UTexture RadialBlurMask
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelPostProcess_C.__PropertyOffset_64);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelPostProcess_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x170059F7 RID: 23031
		// (get) Token: 0x06026E90 RID: 159376 RVA: 0x009E5267 File Offset: 0x009E3467
		// (set) Token: 0x06026E91 RID: 159377 RVA: 0x009E527B File Offset: 0x009E347B
		public unsafe FVector2D RadialBlurMaskScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelPostProcess_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x06026E92 RID: 159378 RVA: 0x009E5290 File Offset: 0x009E3490
		protected BP_EffectModelPostProcess_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401448B RID: 83083
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelPostProcess.BP_EffectModelPostProcess_C";

		// Token: 0x0401448C RID: 83084
		private static IntPtr _ClassPtr;

		// Token: 0x0401448D RID: 83085
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401448E RID: 83086
		internal new static int __PropertyOffset_0;

		// Token: 0x0401448F RID: 83087
		[Nullable(2)]
		private FKuroCurveVector _Location;

		// Token: 0x04014490 RID: 83088
		internal new static int __PropertyOffset_1;

		// Token: 0x04014491 RID: 83089
		[Nullable(2)]
		private FKuroCurveFloat _BlurIntensity;

		// Token: 0x04014492 RID: 83090
		internal new static int __PropertyOffset_2;

		// Token: 0x04014493 RID: 83091
		internal new static int __PropertyOffset_3;

		// Token: 0x04014494 RID: 83092
		internal new static int __PropertyOffset_4;

		// Token: 0x04014495 RID: 83093
		internal new static int __PropertyOffset_5;

		// Token: 0x04014496 RID: 83094
		internal new static int __PropertyOffset_6;

		// Token: 0x04014497 RID: 83095
		internal new static int __PropertyOffset_7;

		// Token: 0x04014498 RID: 83096
		internal new static int __PropertyOffset_8;

		// Token: 0x04014499 RID: 83097
		internal new static int __PropertyOffset_9;

		// Token: 0x0401449A RID: 83098
		[Nullable(2)]
		private FKuroCurveFloat _MainLightIntensity;

		// Token: 0x0401449B RID: 83099
		internal new static int __PropertyOffset_10;

		// Token: 0x0401449C RID: 83100
		internal new static int __PropertyOffset_11;

		// Token: 0x0401449D RID: 83101
		[Nullable(2)]
		private FKuroCurveLinearColor _MainLightColor;

		// Token: 0x0401449E RID: 83102
		internal new static int __PropertyOffset_12;

		// Token: 0x0401449F RID: 83103
		internal static int __PropertyOffset_13;

		// Token: 0x040144A0 RID: 83104
		[Nullable(2)]
		private FKuroCurveFloat _SkyLightIntensity;

		// Token: 0x040144A1 RID: 83105
		internal static int __PropertyOffset_14;

		// Token: 0x040144A2 RID: 83106
		internal static int __PropertyOffset_15;

		// Token: 0x040144A3 RID: 83107
		[Nullable(2)]
		private FKuroCurveLinearColor _SkyLightColor;

		// Token: 0x040144A4 RID: 83108
		internal static int __PropertyOffset_16;

		// Token: 0x040144A5 RID: 83109
		internal static int __PropertyOffset_17;

		// Token: 0x040144A6 RID: 83110
		[Nullable(2)]
		private FKuroCurveFloat _FogDensity;

		// Token: 0x040144A7 RID: 83111
		internal static int __PropertyOffset_18;

		// Token: 0x040144A8 RID: 83112
		internal static int __PropertyOffset_19;

		// Token: 0x040144A9 RID: 83113
		[Nullable(2)]
		private FKuroCurveLinearColor _FogColor;

		// Token: 0x040144AA RID: 83114
		internal static int __PropertyOffset_20;

		// Token: 0x040144AB RID: 83115
		internal static int __PropertyOffset_21;

		// Token: 0x040144AC RID: 83116
		[Nullable(2)]
		private FKuroCurveFloat _FogStartDistance;

		// Token: 0x040144AD RID: 83117
		internal static int __PropertyOffset_22;

		// Token: 0x040144AE RID: 83118
		internal static int __PropertyOffset_23;

		// Token: 0x040144AF RID: 83119
		[Nullable(2)]
		private FKuroCurveLinearColor _VolumetricFogColor;

		// Token: 0x040144B0 RID: 83120
		internal static int __PropertyOffset_24;

		// Token: 0x040144B1 RID: 83121
		internal static int __PropertyOffset_25;

		// Token: 0x040144B2 RID: 83122
		[Nullable(2)]
		private FKuroCurveFloat _VolumetricFogFalloff;

		// Token: 0x040144B3 RID: 83123
		internal static int __PropertyOffset_26;

		// Token: 0x040144B4 RID: 83124
		internal static int __PropertyOffset_27;

		// Token: 0x040144B5 RID: 83125
		[Nullable(2)]
		private FKuroCurveFloat _VolumetricFogDistance;

		// Token: 0x040144B6 RID: 83126
		internal static int __PropertyOffset_28;

		// Token: 0x040144B7 RID: 83127
		internal static int __PropertyOffset_29;

		// Token: 0x040144B8 RID: 83128
		[Nullable(2)]
		private FKuroCurveFloat _KuroBloomIntensity;

		// Token: 0x040144B9 RID: 83129
		internal static int __PropertyOffset_30;

		// Token: 0x040144BA RID: 83130
		internal static int __PropertyOffset_31;

		// Token: 0x040144BB RID: 83131
		[Nullable(2)]
		private FKuroCurveFloat _KuroThreshold;

		// Token: 0x040144BC RID: 83132
		internal static int __PropertyOffset_32;

		// Token: 0x040144BD RID: 83133
		internal static int __PropertyOffset_33;

		// Token: 0x040144BE RID: 83134
		[Nullable(2)]
		private FKuroCurveFloat _SceneFringeIntensity;

		// Token: 0x040144BF RID: 83135
		internal static int __PropertyOffset_34;

		// Token: 0x040144C0 RID: 83136
		internal static int __PropertyOffset_35;

		// Token: 0x040144C1 RID: 83137
		[Nullable(2)]
		private FKuroCurveFloat _StartOffset;

		// Token: 0x040144C2 RID: 83138
		internal static int __PropertyOffset_36;

		// Token: 0x040144C3 RID: 83139
		internal static int __PropertyOffset_37;

		// Token: 0x040144C4 RID: 83140
		[Nullable(2)]
		private FKuroCurveFloat _VignetteIntensity;

		// Token: 0x040144C5 RID: 83141
		internal static int __PropertyOffset_38;

		// Token: 0x040144C6 RID: 83142
		internal static int __PropertyOffset_39;

		// Token: 0x040144C7 RID: 83143
		[Nullable(2)]
		private FKuroCurveFloat _GrainJitter;

		// Token: 0x040144C8 RID: 83144
		internal static int __PropertyOffset_40;

		// Token: 0x040144C9 RID: 83145
		internal static int __PropertyOffset_41;

		// Token: 0x040144CA RID: 83146
		[Nullable(2)]
		private FKuroCurveFloat _GrainIntensity;

		// Token: 0x040144CB RID: 83147
		internal static int __PropertyOffset_42;

		// Token: 0x040144CC RID: 83148
		internal static int __PropertyOffset_43;

		// Token: 0x040144CD RID: 83149
		[Nullable(2)]
		private FKuroCurveFloat _LutIntensity;

		// Token: 0x040144CE RID: 83150
		internal static int __PropertyOffset_44;

		// Token: 0x040144CF RID: 83151
		internal static int __PropertyOffset_45;

		// Token: 0x040144D0 RID: 83152
		internal static int __PropertyOffset_46;

		// Token: 0x040144D1 RID: 83153
		internal static int __PropertyOffset_47;

		// Token: 0x040144D2 RID: 83154
		[Nullable(2)]
		private FKuroCurveLinearColor _SceneColorTint;

		// Token: 0x040144D3 RID: 83155
		internal static int __PropertyOffset_48;

		// Token: 0x040144D4 RID: 83156
		internal static int __PropertyOffset_49;

		// Token: 0x040144D5 RID: 83157
		[Nullable(2)]
		private FKuroCurveFloat _BlackWhiteFlashIntensity;

		// Token: 0x040144D6 RID: 83158
		internal static int __PropertyOffset_50;

		// Token: 0x040144D7 RID: 83159
		internal static int __PropertyOffset_51;

		// Token: 0x040144D8 RID: 83160
		[Nullable(2)]
		private FKuroCurveFloat _BlackWhiteFlashFactor;

		// Token: 0x040144D9 RID: 83161
		internal static int __PropertyOffset_52;

		// Token: 0x040144DA RID: 83162
		internal static int __PropertyOffset_53;

		// Token: 0x040144DB RID: 83163
		[Nullable(2)]
		private FKuroCurveFloat _BlackWhiteFlashThreshold;

		// Token: 0x040144DC RID: 83164
		internal static int __PropertyOffset_54;

		// Token: 0x040144DD RID: 83165
		internal static int __PropertyOffset_55;

		// Token: 0x040144DE RID: 83166
		[Nullable(2)]
		private FKuroCurveLinearColor _BlackWhiteFlashBlackAreaColor;

		// Token: 0x040144DF RID: 83167
		internal static int __PropertyOffset_56;

		// Token: 0x040144E0 RID: 83168
		internal static int __PropertyOffset_57;

		// Token: 0x040144E1 RID: 83169
		[Nullable(2)]
		private FKuroCurveLinearColor _BlackWhiteFlashWhiteAreaColor;

		// Token: 0x040144E2 RID: 83170
		internal static int __PropertyOffset_58;

		// Token: 0x040144E3 RID: 83171
		internal static int __PropertyOffset_59;

		// Token: 0x040144E4 RID: 83172
		internal static int __PropertyOffset_60;

		// Token: 0x040144E5 RID: 83173
		internal static int __PropertyOffset_61;

		// Token: 0x040144E6 RID: 83174
		[Nullable(2)]
		private FKuroCurveFloat _VolumeHardnessCurve;

		// Token: 0x040144E7 RID: 83175
		internal static int __PropertyOffset_62;

		// Token: 0x040144E8 RID: 83176
		[Nullable(2)]
		private FKuroCurveFloat _RadialBlurHardness;

		// Token: 0x040144E9 RID: 83177
		internal static int __PropertyOffset_63;

		// Token: 0x040144EA RID: 83178
		[Nullable(2)]
		private FKuroCurveFloat _RadialBlurRadius;

		// Token: 0x040144EB RID: 83179
		internal static int __PropertyOffset_64;

		// Token: 0x040144EC RID: 83180
		internal static int __PropertyOffset_65;
	}
}
