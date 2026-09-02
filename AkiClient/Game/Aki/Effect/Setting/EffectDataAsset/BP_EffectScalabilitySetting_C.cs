using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scalability;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DE8 RID: 15848
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectScalabilitySetting.BP_EffectScalabilitySetting_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_EffectScalabilitySetting_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026EE1 RID: 159457 RVA: 0x009E5BB0 File Offset: 0x009E3DB0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectScalabilitySetting_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectScalabilitySetting.BP_EffectScalabilitySetting_C");
			}
			return BP_EffectScalabilitySetting_C._ClassPtr;
		}

		// Token: 0x06026EE2 RID: 159458 RVA: 0x009E5BD4 File Offset: 0x009E3DD4
		public BP_EffectScalabilitySetting_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectScalabilitySetting_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026EE3 RID: 159459 RVA: 0x009E5BFC File Offset: 0x009E3DFC
		[NullableContext(1)]
		public BP_EffectScalabilitySetting_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectScalabilitySetting_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A19 RID: 23065
		// (get) Token: 0x06026EE4 RID: 159460 RVA: 0x009E5C30 File Offset: 0x009E3E30
		// (set) Token: 0x06026EE5 RID: 159461 RVA: 0x009E5C69 File Offset: 0x009E3E69
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<EEffectScalabilityType>, TSoftObjectPtr<NiagaraScalabilitySetting>> NiagaraSettings
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EEffectScalabilityType>, TSoftObjectPtr<NiagaraScalabilitySetting>> result;
				if ((result = this._NiagaraSettings) == null)
				{
					result = (this._NiagaraSettings = new TMap<TEnumAsByte<EEffectScalabilityType>, TSoftObjectPtr<NiagaraScalabilitySetting>>(base.NativePtr + (IntPtr)BP_EffectScalabilitySetting_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.NiagaraSettings.CopyAssign(value);
			}
		}

		// Token: 0x06026EE6 RID: 159462 RVA: 0x009E5C77 File Offset: 0x009E3E77
		protected BP_EffectScalabilitySetting_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014527 RID: 83239
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectScalabilitySetting.BP_EffectScalabilitySetting_C";

		// Token: 0x04014528 RID: 83240
		private static IntPtr _ClassPtr;

		// Token: 0x04014529 RID: 83241
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401452A RID: 83242
		internal static int __PropertyOffset_0;

		// Token: 0x0401452B RID: 83243
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<EEffectScalabilityType>, TSoftObjectPtr<NiagaraScalabilitySetting>> _NiagaraSettings;
	}
}
