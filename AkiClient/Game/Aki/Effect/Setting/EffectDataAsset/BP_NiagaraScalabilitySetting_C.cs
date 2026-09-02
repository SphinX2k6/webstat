using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scalability;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE9 RID: 15849
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_NiagaraScalabilitySetting.BP_NiagaraScalabilitySetting_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_NiagaraScalabilitySetting_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026EE7 RID: 159463 RVA: 0x009E5C80 File Offset: 0x009E3E80
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NiagaraScalabilitySetting_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_NiagaraScalabilitySetting.BP_NiagaraScalabilitySetting_C");
			}
			return BP_NiagaraScalabilitySetting_C._ClassPtr;
		}

		// Token: 0x06026EE8 RID: 159464 RVA: 0x009E5CA4 File Offset: 0x009E3EA4
		public BP_NiagaraScalabilitySetting_C() : this(BuiltinUtils.AllocNativeUObject(BP_NiagaraScalabilitySetting_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026EE9 RID: 159465 RVA: 0x009E5CCC File Offset: 0x009E3ECC
		[NullableContext(1)]
		public BP_NiagaraScalabilitySetting_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NiagaraScalabilitySetting_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A1A RID: 23066
		// (get) Token: 0x06026EEA RID: 159466 RVA: 0x009E5D00 File Offset: 0x009E3F00
		// (set) Token: 0x06026EEB RID: 159467 RVA: 0x009E5D39 File Offset: 0x009E3F39
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<ENiagaraScalabilityType>, UNiagaraEffectType> NiagaraEffectTypes
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ENiagaraScalabilityType>, UNiagaraEffectType> result;
				if ((result = this._NiagaraEffectTypes) == null)
				{
					result = (this._NiagaraEffectTypes = new TMap<TEnumAsByte<ENiagaraScalabilityType>, UNiagaraEffectType>(base.NativePtr + (IntPtr)BP_NiagaraScalabilitySetting_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.NiagaraEffectTypes.CopyAssign(value);
			}
		}

		// Token: 0x06026EEC RID: 159468 RVA: 0x009E5D47 File Offset: 0x009E3F47
		protected BP_NiagaraScalabilitySetting_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401452C RID: 83244
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_NiagaraScalabilitySetting.BP_NiagaraScalabilitySetting_C";

		// Token: 0x0401452D RID: 83245
		private static IntPtr _ClassPtr;

		// Token: 0x0401452E RID: 83246
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401452F RID: 83247
		internal static int __PropertyOffset_0;

		// Token: 0x04014530 RID: 83248
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<ENiagaraScalabilityType>, UNiagaraEffectType> _NiagaraEffectTypes;
	}
}
