using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE3 RID: 15843
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelNiagara.BP_EffectModelNiagara_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1641)]
	public class BP_EffectModelNiagara_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026DF3 RID: 159219 RVA: 0x009E3FC9 File Offset: 0x009E21C9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelNiagara_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelNiagara.BP_EffectModelNiagara_C");
			}
			return BP_EffectModelNiagara_C._ClassPtr;
		}

		// Token: 0x06026DF4 RID: 159220 RVA: 0x009E3FF0 File Offset: 0x009E21F0
		public BP_EffectModelNiagara_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelNiagara_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026DF5 RID: 159221 RVA: 0x009E4018 File Offset: 0x009E2218
		public BP_EffectModelNiagara_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelNiagara_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170059AC RID: 22956
		// (get) Token: 0x06026DF6 RID: 159222 RVA: 0x009E404C File Offset: 0x009E224C
		// (set) Token: 0x06026DF7 RID: 159223 RVA: 0x009E4085 File Offset: 0x009E2285
		public FKuroCurveVector Location
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059AD RID: 22957
		// (get) Token: 0x06026DF8 RID: 159224 RVA: 0x009E40A8 File Offset: 0x009E22A8
		// (set) Token: 0x06026DF9 RID: 159225 RVA: 0x009E40E1 File Offset: 0x009E22E1
		public FKuroCurveVector Rotation
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059AE RID: 22958
		// (get) Token: 0x06026DFA RID: 159226 RVA: 0x009E4104 File Offset: 0x009E2304
		// (set) Token: 0x06026DFB RID: 159227 RVA: 0x009E413D File Offset: 0x009E233D
		public FKuroCurveVector Scale
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Scale) == null)
				{
					result = (this._Scale = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170059AF RID: 22959
		// (get) Token: 0x06026DFC RID: 159228 RVA: 0x009E4160 File Offset: 0x009E2360
		// (set) Token: 0x06026DFD RID: 159229 RVA: 0x009E4199 File Offset: 0x009E2399
		public TMap<FName, FKuroCurveFloat> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveFloat> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<FName, FKuroCurveFloat>(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x170059B0 RID: 22960
		// (get) Token: 0x06026DFE RID: 159230 RVA: 0x009E41A8 File Offset: 0x009E23A8
		// (set) Token: 0x06026DFF RID: 159231 RVA: 0x009E41E1 File Offset: 0x009E23E1
		public TMap<FName, FKuroCurveLinearColor> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<FName, FKuroCurveLinearColor>(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x170059B1 RID: 22961
		// (get) Token: 0x06026E00 RID: 159232 RVA: 0x009E41F0 File Offset: 0x009E23F0
		// (set) Token: 0x06026E01 RID: 159233 RVA: 0x009E4229 File Offset: 0x009E2429
		public TMap<FName, FKuroCurveVector> VectorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveVector> result;
				if ((result = this._VectorParameters) == null)
				{
					result = (this._VectorParameters = new TMap<FName, FKuroCurveVector>(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.VectorParameters.CopyAssign(value);
			}
		}

		// Token: 0x170059B2 RID: 22962
		// (get) Token: 0x06026E02 RID: 159234 RVA: 0x009E4237 File Offset: 0x009E2437
		// (set) Token: 0x06026E03 RID: 159235 RVA: 0x009E4247 File Offset: 0x009E2447
		public unsafe bool ReceiveDecal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170059B3 RID: 22963
		// (get) Token: 0x06026E04 RID: 159236 RVA: 0x009E4258 File Offset: 0x009E2458
		// (set) Token: 0x06026E05 RID: 159237 RVA: 0x009E4268 File Offset: 0x009E2468
		public unsafe int TranslucencySortPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170059B4 RID: 22964
		// (get) Token: 0x06026E06 RID: 159238 RVA: 0x009E4279 File Offset: 0x009E2479
		// (set) Token: 0x06026E07 RID: 159239 RVA: 0x009E428D File Offset: 0x009E248D
		[Nullable(2)]
		public unsafe UNiagaraSystem NiagaraRef
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelNiagara_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelNiagara_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170059B5 RID: 22965
		// (get) Token: 0x06026E08 RID: 159240 RVA: 0x009E42A2 File Offset: 0x009E24A2
		// (set) Token: 0x06026E09 RID: 159241 RVA: 0x009E42B2 File Offset: 0x009E24B2
		public unsafe bool DeactivateOnStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelNiagara_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026E0A RID: 159242 RVA: 0x009E42C3 File Offset: 0x009E24C3
		protected BP_EffectModelNiagara_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014478 RID: 83064
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelNiagara.BP_EffectModelNiagara_C";

		// Token: 0x04014479 RID: 83065
		private static IntPtr _ClassPtr;

		// Token: 0x0401447A RID: 83066
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401447B RID: 83067
		internal new static int __PropertyOffset_0;

		// Token: 0x0401447C RID: 83068
		[Nullable(2)]
		private FKuroCurveVector _Location;

		// Token: 0x0401447D RID: 83069
		internal new static int __PropertyOffset_1;

		// Token: 0x0401447E RID: 83070
		[Nullable(2)]
		private FKuroCurveVector _Rotation;

		// Token: 0x0401447F RID: 83071
		internal new static int __PropertyOffset_2;

		// Token: 0x04014480 RID: 83072
		[Nullable(2)]
		private FKuroCurveVector _Scale;

		// Token: 0x04014481 RID: 83073
		internal new static int __PropertyOffset_3;

		// Token: 0x04014482 RID: 83074
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveFloat> _FloatParameters;

		// Token: 0x04014483 RID: 83075
		internal new static int __PropertyOffset_4;

		// Token: 0x04014484 RID: 83076
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveLinearColor> _ColorParameters;

		// Token: 0x04014485 RID: 83077
		internal new static int __PropertyOffset_5;

		// Token: 0x04014486 RID: 83078
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveVector> _VectorParameters;

		// Token: 0x04014487 RID: 83079
		internal new static int __PropertyOffset_6;

		// Token: 0x04014488 RID: 83080
		internal new static int __PropertyOffset_7;

		// Token: 0x04014489 RID: 83081
		internal new static int __PropertyOffset_8;

		// Token: 0x0401448A RID: 83082
		internal new static int __PropertyOffset_9;
	}
}
