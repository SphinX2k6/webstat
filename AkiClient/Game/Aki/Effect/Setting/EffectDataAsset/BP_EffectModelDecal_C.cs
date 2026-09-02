using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DDE RID: 15838
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelDecal.BP_EffectModelDecal_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1552)]
	public class BP_EffectModelDecal_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026D87 RID: 159111 RVA: 0x009E33F6 File Offset: 0x009E15F6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelDecal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelDecal.BP_EffectModelDecal_C");
			}
			return BP_EffectModelDecal_C._ClassPtr;
		}

		// Token: 0x06026D88 RID: 159112 RVA: 0x009E341C File Offset: 0x009E161C
		public BP_EffectModelDecal_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelDecal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026D89 RID: 159113 RVA: 0x009E3444 File Offset: 0x009E1644
		public BP_EffectModelDecal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelDecal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005980 RID: 22912
		// (get) Token: 0x06026D8A RID: 159114 RVA: 0x009E3478 File Offset: 0x009E1678
		// (set) Token: 0x06026D8B RID: 159115 RVA: 0x009E34B1 File Offset: 0x009E16B1
		public FKuroCurveVector Location
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005981 RID: 22913
		// (get) Token: 0x06026D8C RID: 159116 RVA: 0x009E34D4 File Offset: 0x009E16D4
		// (set) Token: 0x06026D8D RID: 159117 RVA: 0x009E350D File Offset: 0x009E170D
		public FKuroCurveVector Rotation
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005982 RID: 22914
		// (get) Token: 0x06026D8E RID: 159118 RVA: 0x009E3530 File Offset: 0x009E1730
		// (set) Token: 0x06026D8F RID: 159119 RVA: 0x009E3569 File Offset: 0x009E1769
		public FKuroCurveVector Scale
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Scale) == null)
				{
					result = (this._Scale = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005983 RID: 22915
		// (get) Token: 0x06026D90 RID: 159120 RVA: 0x009E358C File Offset: 0x009E178C
		// (set) Token: 0x06026D91 RID: 159121 RVA: 0x009E35C5 File Offset: 0x009E17C5
		public TMap<FName, FKuroCurveFloat> MaterialFloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveFloat> result;
				if ((result = this._MaterialFloatParameters) == null)
				{
					result = (this._MaterialFloatParameters = new TMap<FName, FKuroCurveFloat>(base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.MaterialFloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x17005984 RID: 22916
		// (get) Token: 0x06026D92 RID: 159122 RVA: 0x009E35D4 File Offset: 0x009E17D4
		// (set) Token: 0x06026D93 RID: 159123 RVA: 0x009E360D File Offset: 0x009E180D
		public TMap<FName, FKuroCurveLinearColor> MaterialColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FKuroCurveLinearColor> result;
				if ((result = this._MaterialColorParameters) == null)
				{
					result = (this._MaterialColorParameters = new TMap<FName, FKuroCurveLinearColor>(base.NativePtr + (IntPtr)BP_EffectModelDecal_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.MaterialColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x17005985 RID: 22917
		// (get) Token: 0x06026D94 RID: 159124 RVA: 0x009E361B File Offset: 0x009E181B
		// (set) Token: 0x06026D95 RID: 159125 RVA: 0x009E362F File Offset: 0x009E182F
		[Nullable(2)]
		public unsafe UMaterialInterface DecalMaterialRef
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelDecal_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelDecal_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06026D96 RID: 159126 RVA: 0x009E3644 File Offset: 0x009E1844
		protected BP_EffectModelDecal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401442E RID: 82990
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelDecal.BP_EffectModelDecal_C";

		// Token: 0x0401442F RID: 82991
		private static IntPtr _ClassPtr;

		// Token: 0x04014430 RID: 82992
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014431 RID: 82993
		internal new static int __PropertyOffset_0;

		// Token: 0x04014432 RID: 82994
		[Nullable(2)]
		private FKuroCurveVector _Location;

		// Token: 0x04014433 RID: 82995
		internal new static int __PropertyOffset_1;

		// Token: 0x04014434 RID: 82996
		[Nullable(2)]
		private FKuroCurveVector _Rotation;

		// Token: 0x04014435 RID: 82997
		internal new static int __PropertyOffset_2;

		// Token: 0x04014436 RID: 82998
		[Nullable(2)]
		private FKuroCurveVector _Scale;

		// Token: 0x04014437 RID: 82999
		internal new static int __PropertyOffset_3;

		// Token: 0x04014438 RID: 83000
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveFloat> _MaterialFloatParameters;

		// Token: 0x04014439 RID: 83001
		internal new static int __PropertyOffset_4;

		// Token: 0x0401443A RID: 83002
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, FKuroCurveLinearColor> _MaterialColorParameters;

		// Token: 0x0401443B RID: 83003
		internal new static int __PropertyOffset_5;
	}
}
