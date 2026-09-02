using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE7 RID: 15847
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelTrail.BP_EffectModelTrail_C")]
	[UnrealStructLayout(696, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 696)]
	public class BP_EffectModelTrail_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026EC5 RID: 159429 RVA: 0x009E585A File Offset: 0x009E3A5A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelTrail_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelTrail.BP_EffectModelTrail_C");
			}
			return BP_EffectModelTrail_C._ClassPtr;
		}

		// Token: 0x06026EC6 RID: 159430 RVA: 0x009E5880 File Offset: 0x009E3A80
		public BP_EffectModelTrail_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelTrail_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026EC7 RID: 159431 RVA: 0x009E58A8 File Offset: 0x009E3AA8
		public BP_EffectModelTrail_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelTrail_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A0D RID: 23053
		// (get) Token: 0x06026EC8 RID: 159432 RVA: 0x009E58DB File Offset: 0x009E3ADB
		// (set) Token: 0x06026EC9 RID: 159433 RVA: 0x009E58EB File Offset: 0x009E3AEB
		public unsafe bool AttachToBones
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A0E RID: 23054
		// (get) Token: 0x06026ECA RID: 159434 RVA: 0x009E58FC File Offset: 0x009E3AFC
		// (set) Token: 0x06026ECB RID: 159435 RVA: 0x009E5935 File Offset: 0x009E3B35
		public TArray<FName> AttachBoneNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._AttachBoneNames) == null)
				{
					result = (this._AttachBoneNames = new TArray<FName>(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.AttachBoneNames.CopyAssign(value);
			}
		}

		// Token: 0x17005A0F RID: 23055
		// (get) Token: 0x06026ECC RID: 159436 RVA: 0x009E5944 File Offset: 0x009E3B44
		// (set) Token: 0x06026ECD RID: 159437 RVA: 0x009E597D File Offset: 0x009E3B7D
		public TArray<FVector> RelativeLocations
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._RelativeLocations) == null)
				{
					result = (this._RelativeLocations = new TArray<FVector>(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.RelativeLocations.CopyAssign(value);
			}
		}

		// Token: 0x17005A10 RID: 23056
		// (get) Token: 0x06026ECE RID: 159438 RVA: 0x009E598B File Offset: 0x009E3B8B
		// (set) Token: 0x06026ECF RID: 159439 RVA: 0x009E599F File Offset: 0x009E3B9F
		[Nullable(2)]
		public unsafe UMaterialInterface Material
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelTrail_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelTrail_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005A11 RID: 23057
		// (get) Token: 0x06026ED0 RID: 159440 RVA: 0x009E59B4 File Offset: 0x009E3BB4
		// (set) Token: 0x06026ED1 RID: 159441 RVA: 0x009E59ED File Offset: 0x009E3BED
		public FKuroCurveFloat DissipateSpeed
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._DissipateSpeed) == null)
				{
					result = (this._DissipateSpeed = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A12 RID: 23058
		// (get) Token: 0x06026ED2 RID: 159442 RVA: 0x009E5A10 File Offset: 0x009E3C10
		// (set) Token: 0x06026ED3 RID: 159443 RVA: 0x009E5A49 File Offset: 0x009E3C49
		public FKuroCurveFloat Alpha
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Alpha) == null)
				{
					result = (this._Alpha = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A13 RID: 23059
		// (get) Token: 0x06026ED4 RID: 159444 RVA: 0x009E5A6C File Offset: 0x009E3C6C
		// (set) Token: 0x06026ED5 RID: 159445 RVA: 0x009E5AA5 File Offset: 0x009E3CA5
		public TMap<FName, FKuroCurveFloat> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveFloat> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<FName, FKuroCurveFloat>(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x17005A14 RID: 23060
		// (get) Token: 0x06026ED6 RID: 159446 RVA: 0x009E5AB4 File Offset: 0x009E3CB4
		// (set) Token: 0x06026ED7 RID: 159447 RVA: 0x009E5AED File Offset: 0x009E3CED
		public TMap<FName, FKuroCurveLinearColor> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<FName, FKuroCurveLinearColor>(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x17005A15 RID: 23061
		// (get) Token: 0x06026ED8 RID: 159448 RVA: 0x009E5AFB File Offset: 0x009E3CFB
		// (set) Token: 0x06026ED9 RID: 159449 RVA: 0x009E5B0B File Offset: 0x009E3D0B
		public unsafe bool DestroyAtOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A16 RID: 23062
		// (get) Token: 0x06026EDA RID: 159450 RVA: 0x009E5B1C File Offset: 0x009E3D1C
		// (set) Token: 0x06026EDB RID: 159451 RVA: 0x009E5B2C File Offset: 0x009E3D2C
		public unsafe float DissipateSpeedAfterDead
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005A17 RID: 23063
		// (get) Token: 0x06026EDC RID: 159452 RVA: 0x009E5B3D File Offset: 0x009E3D3D
		// (set) Token: 0x06026EDD RID: 159453 RVA: 0x009E5B4D File Offset: 0x009E3D4D
		public unsafe float UnitLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005A18 RID: 23064
		// (get) Token: 0x06026EDE RID: 159454 RVA: 0x009E5B60 File Offset: 0x009E3D60
		// (set) Token: 0x06026EDF RID: 159455 RVA: 0x009E5B99 File Offset: 0x009E3D99
		public TMap<int, FKuroCurveVector> LocationsCurve
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, FKuroCurveVector> result;
				if ((result = this._LocationsCurve) == null)
				{
					result = (this._LocationsCurve = new TMap<int, FKuroCurveVector>(base.NativePtr + (IntPtr)BP_EffectModelTrail_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.LocationsCurve.CopyAssign(value);
			}
		}

		// Token: 0x06026EE0 RID: 159456 RVA: 0x009E5BA7 File Offset: 0x009E3DA7
		protected BP_EffectModelTrail_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014511 RID: 83217
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelTrail.BP_EffectModelTrail_C";

		// Token: 0x04014512 RID: 83218
		private static IntPtr _ClassPtr;

		// Token: 0x04014513 RID: 83219
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014514 RID: 83220
		internal new static int __PropertyOffset_0;

		// Token: 0x04014515 RID: 83221
		internal new static int __PropertyOffset_1;

		// Token: 0x04014516 RID: 83222
		[Nullable(2)]
		private TArray<FName> _AttachBoneNames;

		// Token: 0x04014517 RID: 83223
		internal new static int __PropertyOffset_2;

		// Token: 0x04014518 RID: 83224
		[Nullable(2)]
		private TArray<FVector> _RelativeLocations;

		// Token: 0x04014519 RID: 83225
		internal new static int __PropertyOffset_3;

		// Token: 0x0401451A RID: 83226
		internal new static int __PropertyOffset_4;

		// Token: 0x0401451B RID: 83227
		[Nullable(2)]
		private FKuroCurveFloat _DissipateSpeed;

		// Token: 0x0401451C RID: 83228
		internal new static int __PropertyOffset_5;

		// Token: 0x0401451D RID: 83229
		[Nullable(2)]
		private FKuroCurveFloat _Alpha;

		// Token: 0x0401451E RID: 83230
		internal new static int __PropertyOffset_6;

		// Token: 0x0401451F RID: 83231
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveFloat> _FloatParameters;

		// Token: 0x04014520 RID: 83232
		internal new static int __PropertyOffset_7;

		// Token: 0x04014521 RID: 83233
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveLinearColor> _ColorParameters;

		// Token: 0x04014522 RID: 83234
		internal new static int __PropertyOffset_8;

		// Token: 0x04014523 RID: 83235
		internal new static int __PropertyOffset_9;

		// Token: 0x04014524 RID: 83236
		internal new static int __PropertyOffset_10;

		// Token: 0x04014525 RID: 83237
		internal new static int __PropertyOffset_11;

		// Token: 0x04014526 RID: 83238
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, FKuroCurveVector> _LocationsCurve;
	}
}
