using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE1 RID: 15841
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelLight.BP_EffectModelLight_C")]
	[UnrealStructLayout(1768, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1764)]
	public class BP_EffectModelLight_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026DAB RID: 159147 RVA: 0x009E390F File Offset: 0x009E1B0F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelLight.BP_EffectModelLight_C");
			}
			return BP_EffectModelLight_C._ClassPtr;
		}

		// Token: 0x06026DAC RID: 159148 RVA: 0x009E3934 File Offset: 0x009E1B34
		public BP_EffectModelLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026DAD RID: 159149 RVA: 0x009E395C File Offset: 0x009E1B5C
		public BP_EffectModelLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700598C RID: 22924
		// (get) Token: 0x06026DAE RID: 159150 RVA: 0x009E3990 File Offset: 0x009E1B90
		// (set) Token: 0x06026DAF RID: 159151 RVA: 0x009E39C9 File Offset: 0x009E1BC9
		public FKuroCurveVector Location
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700598D RID: 22925
		// (get) Token: 0x06026DB0 RID: 159152 RVA: 0x009E39EC File Offset: 0x009E1BEC
		// (set) Token: 0x06026DB1 RID: 159153 RVA: 0x009E3A25 File Offset: 0x009E1C25
		public FKuroCurveFloat Intensity
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Intensity) == null)
				{
					result = (this._Intensity = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700598E RID: 22926
		// (get) Token: 0x06026DB2 RID: 159154 RVA: 0x009E3A48 File Offset: 0x009E1C48
		// (set) Token: 0x06026DB3 RID: 159155 RVA: 0x009E3A81 File Offset: 0x009E1C81
		public FKuroCurveLinearColor Color
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._Color) == null)
				{
					result = (this._Color = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700598F RID: 22927
		// (get) Token: 0x06026DB4 RID: 159156 RVA: 0x009E3AA2 File Offset: 0x009E1CA2
		// (set) Token: 0x06026DB5 RID: 159157 RVA: 0x009E3AB2 File Offset: 0x009E1CB2
		public unsafe float CharacterIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005990 RID: 22928
		// (get) Token: 0x06026DB6 RID: 159158 RVA: 0x009E3AC3 File Offset: 0x009E1CC3
		// (set) Token: 0x06026DB7 RID: 159159 RVA: 0x009E3AD7 File Offset: 0x009E1CD7
		public unsafe FLinearColor CharacterColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005991 RID: 22929
		// (get) Token: 0x06026DB8 RID: 159160 RVA: 0x009E3AEC File Offset: 0x009E1CEC
		// (set) Token: 0x06026DB9 RID: 159161 RVA: 0x009E3B25 File Offset: 0x009E1D25
		public FKuroCurveFloat Radius
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Radius) == null)
				{
					result = (this._Radius = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005992 RID: 22930
		// (get) Token: 0x06026DBA RID: 159162 RVA: 0x009E3B48 File Offset: 0x009E1D48
		// (set) Token: 0x06026DBB RID: 159163 RVA: 0x009E3B81 File Offset: 0x009E1D81
		public FKuroCurveFloat FalloffExponent
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._FalloffExponent) == null)
				{
					result = (this._FalloffExponent = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005993 RID: 22931
		// (get) Token: 0x06026DBC RID: 159164 RVA: 0x009E3BA2 File Offset: 0x009E1DA2
		// (set) Token: 0x06026DBD RID: 159165 RVA: 0x009E3BB2 File Offset: 0x009E1DB2
		public unsafe float CharacterFalloffExponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005994 RID: 22932
		// (get) Token: 0x06026DBE RID: 159166 RVA: 0x009E3BC3 File Offset: 0x009E1DC3
		// (set) Token: 0x06026DBF RID: 159167 RVA: 0x009E3BD3 File Offset: 0x009E1DD3
		public unsafe float CharacterBlendAtten
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005995 RID: 22933
		// (get) Token: 0x06026DC0 RID: 159168 RVA: 0x009E3BE4 File Offset: 0x009E1DE4
		// (set) Token: 0x06026DC1 RID: 159169 RVA: 0x009E3BF4 File Offset: 0x009E1DF4
		public unsafe int CharacterPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005996 RID: 22934
		// (get) Token: 0x06026DC2 RID: 159170 RVA: 0x009E3C05 File Offset: 0x009E1E05
		// (set) Token: 0x06026DC3 RID: 159171 RVA: 0x009E3C15 File Offset: 0x009E1E15
		public unsafe float CharacterShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005997 RID: 22935
		// (get) Token: 0x06026DC4 RID: 159172 RVA: 0x009E3C26 File Offset: 0x009E1E26
		// (set) Token: 0x06026DC5 RID: 159173 RVA: 0x009E3C36 File Offset: 0x009E1E36
		public unsafe float CharacterBaseIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005998 RID: 22936
		// (get) Token: 0x06026DC6 RID: 159174 RVA: 0x009E3C47 File Offset: 0x009E1E47
		// (set) Token: 0x06026DC7 RID: 159175 RVA: 0x009E3C57 File Offset: 0x009E1E57
		public unsafe float CharacterHardIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005999 RID: 22937
		// (get) Token: 0x06026DC8 RID: 159176 RVA: 0x009E3C68 File Offset: 0x009E1E68
		// (set) Token: 0x06026DC9 RID: 159177 RVA: 0x009E3C7C File Offset: 0x009E1E7C
		public unsafe FLinearColor CharacterHardColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700599A RID: 22938
		// (get) Token: 0x06026DCA RID: 159178 RVA: 0x009E3C91 File Offset: 0x009E1E91
		// (set) Token: 0x06026DCB RID: 159179 RVA: 0x009E3CA5 File Offset: 0x009E1EA5
		public unsafe FLinearColor CharacterHardShadowColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700599B RID: 22939
		// (get) Token: 0x06026DCC RID: 159180 RVA: 0x009E3CBA File Offset: 0x009E1EBA
		// (set) Token: 0x06026DCD RID: 159181 RVA: 0x009E3CCA File Offset: 0x009E1ECA
		public unsafe float CharacterHardBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700599C RID: 22940
		// (get) Token: 0x06026DCE RID: 159182 RVA: 0x009E3CDC File Offset: 0x009E1EDC
		// (set) Token: 0x06026DCF RID: 159183 RVA: 0x009E3D15 File Offset: 0x009E1F15
		public FKuroCurveFloat CharacterLightAlpha
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._CharacterLightAlpha) == null)
				{
					result = (this._CharacterLightAlpha = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700599D RID: 22941
		// (get) Token: 0x06026DD0 RID: 159184 RVA: 0x009E3D36 File Offset: 0x009E1F36
		// (set) Token: 0x06026DD1 RID: 159185 RVA: 0x009E3D46 File Offset: 0x009E1F46
		public unsafe bool CachedLocationHasCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700599E RID: 22942
		// (get) Token: 0x06026DD2 RID: 159186 RVA: 0x009E3D57 File Offset: 0x009E1F57
		// (set) Token: 0x06026DD3 RID: 159187 RVA: 0x009E3D67 File Offset: 0x009E1F67
		public unsafe bool CachedIntensityHasCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700599F RID: 22943
		// (get) Token: 0x06026DD4 RID: 159188 RVA: 0x009E3D78 File Offset: 0x009E1F78
		// (set) Token: 0x06026DD5 RID: 159189 RVA: 0x009E3D88 File Offset: 0x009E1F88
		public unsafe bool CachedColorHasCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059A0 RID: 22944
		// (get) Token: 0x06026DD6 RID: 159190 RVA: 0x009E3D99 File Offset: 0x009E1F99
		// (set) Token: 0x06026DD7 RID: 159191 RVA: 0x009E3DA9 File Offset: 0x009E1FA9
		public unsafe bool CachedRadiusHasCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059A1 RID: 22945
		// (get) Token: 0x06026DD8 RID: 159192 RVA: 0x009E3DBA File Offset: 0x009E1FBA
		// (set) Token: 0x06026DD9 RID: 159193 RVA: 0x009E3DCA File Offset: 0x009E1FCA
		public unsafe bool CachedFallofffExponentHasCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059A2 RID: 22946
		// (get) Token: 0x06026DDA RID: 159194 RVA: 0x009E3DDB File Offset: 0x009E1FDB
		// (set) Token: 0x06026DDB RID: 159195 RVA: 0x009E3DEB File Offset: 0x009E1FEB
		public unsafe bool CachedCharacterLightAlphaHasCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059A3 RID: 22947
		// (get) Token: 0x06026DDC RID: 159196 RVA: 0x009E3DFC File Offset: 0x009E1FFC
		// (set) Token: 0x06026DDD RID: 159197 RVA: 0x009E3E0C File Offset: 0x009E200C
		public unsafe bool IsCached
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059A4 RID: 22948
		// (get) Token: 0x06026DDE RID: 159198 RVA: 0x009E3E1D File Offset: 0x009E201D
		// (set) Token: 0x06026DDF RID: 159199 RVA: 0x009E3E2D File Offset: 0x009E202D
		public unsafe float SourceRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170059A5 RID: 22949
		// (get) Token: 0x06026DE0 RID: 159200 RVA: 0x009E3E3E File Offset: 0x009E203E
		// (set) Token: 0x06026DE1 RID: 159201 RVA: 0x009E3E4E File Offset: 0x009E204E
		public unsafe float SoftSourceRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170059A6 RID: 22950
		// (get) Token: 0x06026DE2 RID: 159202 RVA: 0x009E3E5F File Offset: 0x009E205F
		// (set) Token: 0x06026DE3 RID: 159203 RVA: 0x009E3E6F File Offset: 0x009E206F
		public unsafe float SourceLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelLight_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x06026DE4 RID: 159204 RVA: 0x009E3E80 File Offset: 0x009E2080
		protected BP_EffectModelLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401444C RID: 83020
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelLight.BP_EffectModelLight_C";

		// Token: 0x0401444D RID: 83021
		private static IntPtr _ClassPtr;

		// Token: 0x0401444E RID: 83022
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401444F RID: 83023
		internal new static int __PropertyOffset_0;

		// Token: 0x04014450 RID: 83024
		[Nullable(2)]
		private FKuroCurveVector _Location;

		// Token: 0x04014451 RID: 83025
		internal new static int __PropertyOffset_1;

		// Token: 0x04014452 RID: 83026
		[Nullable(2)]
		private FKuroCurveFloat _Intensity;

		// Token: 0x04014453 RID: 83027
		internal new static int __PropertyOffset_2;

		// Token: 0x04014454 RID: 83028
		[Nullable(2)]
		private FKuroCurveLinearColor _Color;

		// Token: 0x04014455 RID: 83029
		internal new static int __PropertyOffset_3;

		// Token: 0x04014456 RID: 83030
		internal new static int __PropertyOffset_4;

		// Token: 0x04014457 RID: 83031
		internal new static int __PropertyOffset_5;

		// Token: 0x04014458 RID: 83032
		[Nullable(2)]
		private FKuroCurveFloat _Radius;

		// Token: 0x04014459 RID: 83033
		internal new static int __PropertyOffset_6;

		// Token: 0x0401445A RID: 83034
		[Nullable(2)]
		private FKuroCurveFloat _FalloffExponent;

		// Token: 0x0401445B RID: 83035
		internal new static int __PropertyOffset_7;

		// Token: 0x0401445C RID: 83036
		internal new static int __PropertyOffset_8;

		// Token: 0x0401445D RID: 83037
		internal new static int __PropertyOffset_9;

		// Token: 0x0401445E RID: 83038
		internal new static int __PropertyOffset_10;

		// Token: 0x0401445F RID: 83039
		internal new static int __PropertyOffset_11;

		// Token: 0x04014460 RID: 83040
		internal new static int __PropertyOffset_12;

		// Token: 0x04014461 RID: 83041
		internal static int __PropertyOffset_13;

		// Token: 0x04014462 RID: 83042
		internal static int __PropertyOffset_14;

		// Token: 0x04014463 RID: 83043
		internal static int __PropertyOffset_15;

		// Token: 0x04014464 RID: 83044
		internal static int __PropertyOffset_16;

		// Token: 0x04014465 RID: 83045
		[Nullable(2)]
		private FKuroCurveFloat _CharacterLightAlpha;

		// Token: 0x04014466 RID: 83046
		internal static int __PropertyOffset_17;

		// Token: 0x04014467 RID: 83047
		internal static int __PropertyOffset_18;

		// Token: 0x04014468 RID: 83048
		internal static int __PropertyOffset_19;

		// Token: 0x04014469 RID: 83049
		internal static int __PropertyOffset_20;

		// Token: 0x0401446A RID: 83050
		internal static int __PropertyOffset_21;

		// Token: 0x0401446B RID: 83051
		internal static int __PropertyOffset_22;

		// Token: 0x0401446C RID: 83052
		internal static int __PropertyOffset_23;

		// Token: 0x0401446D RID: 83053
		internal static int __PropertyOffset_24;

		// Token: 0x0401446E RID: 83054
		internal static int __PropertyOffset_25;

		// Token: 0x0401446F RID: 83055
		internal static int __PropertyOffset_26;
	}
}
