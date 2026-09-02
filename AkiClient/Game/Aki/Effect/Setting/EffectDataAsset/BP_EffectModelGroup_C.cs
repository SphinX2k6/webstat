using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE0 RID: 15840
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelGroup.BP_EffectModelGroup_C")]
	[UnrealStructLayout(1464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1464)]
	public class BP_EffectModelGroup_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026D9F RID: 159135 RVA: 0x009E372A File Offset: 0x009E192A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelGroup_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelGroup.BP_EffectModelGroup_C");
			}
			return BP_EffectModelGroup_C._ClassPtr;
		}

		// Token: 0x06026DA0 RID: 159136 RVA: 0x009E3750 File Offset: 0x009E1950
		public BP_EffectModelGroup_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelGroup_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026DA1 RID: 159137 RVA: 0x009E3778 File Offset: 0x009E1978
		public BP_EffectModelGroup_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelGroup_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005988 RID: 22920
		// (get) Token: 0x06026DA2 RID: 159138 RVA: 0x009E37AC File Offset: 0x009E19AC
		// (set) Token: 0x06026DA3 RID: 159139 RVA: 0x009E37E5 File Offset: 0x009E19E5
		public TMap<UEffectModelBase, float> EffectData
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UEffectModelBase, float> result;
				if ((result = this._EffectData) == null)
				{
					result = (this._EffectData = new TMap<UEffectModelBase, float>(base.NativePtr + (IntPtr)BP_EffectModelGroup_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.EffectData.CopyAssign(value);
			}
		}

		// Token: 0x17005989 RID: 22921
		// (get) Token: 0x06026DA4 RID: 159140 RVA: 0x009E37F4 File Offset: 0x009E19F4
		// (set) Token: 0x06026DA5 RID: 159141 RVA: 0x009E382D File Offset: 0x009E1A2D
		public FKuroCurveVector Location
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelGroup_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelGroup_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700598A RID: 22922
		// (get) Token: 0x06026DA6 RID: 159142 RVA: 0x009E3850 File Offset: 0x009E1A50
		// (set) Token: 0x06026DA7 RID: 159143 RVA: 0x009E3889 File Offset: 0x009E1A89
		public FKuroCurveVector Rotation
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelGroup_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelGroup_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700598B RID: 22923
		// (get) Token: 0x06026DA8 RID: 159144 RVA: 0x009E38AC File Offset: 0x009E1AAC
		// (set) Token: 0x06026DA9 RID: 159145 RVA: 0x009E38E5 File Offset: 0x009E1AE5
		public FKuroCurveVector Scale
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveVector result;
				if ((result = this._Scale) == null)
				{
					result = (this._Scale = new FKuroCurveVector(base.NativePtr + (IntPtr)BP_EffectModelGroup_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveVector.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelGroup_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06026DAA RID: 159146 RVA: 0x009E3906 File Offset: 0x009E1B06
		protected BP_EffectModelGroup_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014441 RID: 83009
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelGroup.BP_EffectModelGroup_C";

		// Token: 0x04014442 RID: 83010
		private static IntPtr _ClassPtr;

		// Token: 0x04014443 RID: 83011
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014444 RID: 83012
		internal new static int __PropertyOffset_0;

		// Token: 0x04014445 RID: 83013
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<UEffectModelBase, float> _EffectData;

		// Token: 0x04014446 RID: 83014
		internal new static int __PropertyOffset_1;

		// Token: 0x04014447 RID: 83015
		[Nullable(2)]
		private FKuroCurveVector _Location;

		// Token: 0x04014448 RID: 83016
		internal new static int __PropertyOffset_2;

		// Token: 0x04014449 RID: 83017
		[Nullable(2)]
		private FKuroCurveVector _Rotation;

		// Token: 0x0401444A RID: 83018
		internal new static int __PropertyOffset_3;

		// Token: 0x0401444B RID: 83019
		[Nullable(2)]
		private FKuroCurveVector _Scale;
	}
}
