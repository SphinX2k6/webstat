using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE6 RID: 15846
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelStaticMesh.BP_EffectModelStaticMesh_C")]
	[UnrealStructLayout(1600, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1600)]
	public class BP_EffectModelStaticMesh_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026EA7 RID: 159399 RVA: 0x009E54EE File Offset: 0x009E36EE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelStaticMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelStaticMesh.BP_EffectModelStaticMesh_C");
			}
			return BP_EffectModelStaticMesh_C._ClassPtr;
		}

		// Token: 0x06026EA8 RID: 159400 RVA: 0x009E5514 File Offset: 0x009E3714
		public BP_EffectModelStaticMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelStaticMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026EA9 RID: 159401 RVA: 0x009E553C File Offset: 0x009E373C
		public BP_EffectModelStaticMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelStaticMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A00 RID: 23040
		// (get) Token: 0x06026EAA RID: 159402 RVA: 0x009E5570 File Offset: 0x009E3770
		// (set) Token: 0x06026EAB RID: 159403 RVA: 0x009E55A9 File Offset: 0x009E37A9
		public FKuroCurveVector Location
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A01 RID: 23041
		// (get) Token: 0x06026EAC RID: 159404 RVA: 0x009E55CC File Offset: 0x009E37CC
		// (set) Token: 0x06026EAD RID: 159405 RVA: 0x009E5605 File Offset: 0x009E3805
		public FKuroCurveVector Rotation
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A02 RID: 23042
		// (get) Token: 0x06026EAE RID: 159406 RVA: 0x009E5628 File Offset: 0x009E3828
		// (set) Token: 0x06026EAF RID: 159407 RVA: 0x009E5661 File Offset: 0x009E3861
		public FKuroCurveVector Scale
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Scale) == null)
				{
					result = (this._Scale = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A03 RID: 23043
		// (get) Token: 0x06026EB0 RID: 159408 RVA: 0x009E5684 File Offset: 0x009E3884
		// (set) Token: 0x06026EB1 RID: 159409 RVA: 0x009E56BD File Offset: 0x009E38BD
		public TMap<FName, FKuroCurveLinearColor> MaterialColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveLinearColor> result;
				if ((result = this._MaterialColorParameters) == null)
				{
					result = (this._MaterialColorParameters = new TMap<FName, FKuroCurveLinearColor>(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.MaterialColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x17005A04 RID: 23044
		// (get) Token: 0x06026EB2 RID: 159410 RVA: 0x009E56CC File Offset: 0x009E38CC
		// (set) Token: 0x06026EB3 RID: 159411 RVA: 0x009E5705 File Offset: 0x009E3905
		public TMap<FName, FKuroCurveFloat> MaterialFloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveFloat> result;
				if ((result = this._MaterialFloatParameters) == null)
				{
					result = (this._MaterialFloatParameters = new TMap<FName, FKuroCurveFloat>(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.MaterialFloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x17005A05 RID: 23045
		// (get) Token: 0x06026EB4 RID: 159412 RVA: 0x009E5713 File Offset: 0x009E3913
		// (set) Token: 0x06026EB5 RID: 159413 RVA: 0x009E5723 File Offset: 0x009E3923
		public unsafe bool ReceiveDecal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A06 RID: 23046
		// (get) Token: 0x06026EB6 RID: 159414 RVA: 0x009E5734 File Offset: 0x009E3934
		// (set) Token: 0x06026EB7 RID: 159415 RVA: 0x009E5744 File Offset: 0x009E3944
		public unsafe bool EnableCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A07 RID: 23047
		// (get) Token: 0x06026EB8 RID: 159416 RVA: 0x009E5755 File Offset: 0x009E3955
		// (set) Token: 0x06026EB9 RID: 159417 RVA: 0x009E5769 File Offset: 0x009E3969
		[Nullable(2)]
		public unsafe UStaticMesh StaticMeshRef
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelStaticMesh_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelStaticMesh_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005A08 RID: 23048
		// (get) Token: 0x06026EBA RID: 159418 RVA: 0x009E577E File Offset: 0x009E397E
		// (set) Token: 0x06026EBB RID: 159419 RVA: 0x009E5792 File Offset: 0x009E3992
		[Nullable(2)]
		public unsafe UMaterialInterface MaterialOverrideRef
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelStaticMesh_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelStaticMesh_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005A09 RID: 23049
		// (get) Token: 0x06026EBC RID: 159420 RVA: 0x009E57A7 File Offset: 0x009E39A7
		// (set) Token: 0x06026EBD RID: 159421 RVA: 0x009E57B7 File Offset: 0x009E39B7
		public unsafe bool UseMultipleMaterialSlots
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A0A RID: 23050
		// (get) Token: 0x06026EBE RID: 159422 RVA: 0x009E57C8 File Offset: 0x009E39C8
		// (set) Token: 0x06026EBF RID: 159423 RVA: 0x009E5801 File Offset: 0x009E3A01
		public TArray<UMaterialInterface> MaterialOverrideArrayRef
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._MaterialOverrideArrayRef) == null)
				{
					result = (this._MaterialOverrideArrayRef = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.MaterialOverrideArrayRef.CopyAssign(value);
			}
		}

		// Token: 0x17005A0B RID: 23051
		// (get) Token: 0x06026EC0 RID: 159424 RVA: 0x009E580F File Offset: 0x009E3A0F
		// (set) Token: 0x06026EC1 RID: 159425 RVA: 0x009E581F File Offset: 0x009E3A1F
		public unsafe bool CastShadow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A0C RID: 23052
		// (get) Token: 0x06026EC2 RID: 159426 RVA: 0x009E5830 File Offset: 0x009E3A30
		// (set) Token: 0x06026EC3 RID: 159427 RVA: 0x009E5840 File Offset: 0x009E3A40
		public unsafe float TranslucencySortPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelStaticMesh_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x06026EC4 RID: 159428 RVA: 0x009E5851 File Offset: 0x009E3A51
		protected BP_EffectModelStaticMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040144FB RID: 83195
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelStaticMesh.BP_EffectModelStaticMesh_C";

		// Token: 0x040144FC RID: 83196
		private static IntPtr _ClassPtr;

		// Token: 0x040144FD RID: 83197
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040144FE RID: 83198
		internal new static int __PropertyOffset_0;

		// Token: 0x040144FF RID: 83199
		[Nullable(2)]
		private FKuroCurveVector _Location;

		// Token: 0x04014500 RID: 83200
		internal new static int __PropertyOffset_1;

		// Token: 0x04014501 RID: 83201
		[Nullable(2)]
		private FKuroCurveVector _Rotation;

		// Token: 0x04014502 RID: 83202
		internal new static int __PropertyOffset_2;

		// Token: 0x04014503 RID: 83203
		[Nullable(2)]
		private FKuroCurveVector _Scale;

		// Token: 0x04014504 RID: 83204
		internal new static int __PropertyOffset_3;

		// Token: 0x04014505 RID: 83205
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveLinearColor> _MaterialColorParameters;

		// Token: 0x04014506 RID: 83206
		internal new static int __PropertyOffset_4;

		// Token: 0x04014507 RID: 83207
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveFloat> _MaterialFloatParameters;

		// Token: 0x04014508 RID: 83208
		internal new static int __PropertyOffset_5;

		// Token: 0x04014509 RID: 83209
		internal new static int __PropertyOffset_6;

		// Token: 0x0401450A RID: 83210
		internal new static int __PropertyOffset_7;

		// Token: 0x0401450B RID: 83211
		internal new static int __PropertyOffset_8;

		// Token: 0x0401450C RID: 83212
		internal new static int __PropertyOffset_9;

		// Token: 0x0401450D RID: 83213
		internal new static int __PropertyOffset_10;

		// Token: 0x0401450E RID: 83214
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _MaterialOverrideArrayRef;

		// Token: 0x0401450F RID: 83215
		internal new static int __PropertyOffset_11;

		// Token: 0x04014510 RID: 83216
		internal new static int __PropertyOffset_12;
	}
}
