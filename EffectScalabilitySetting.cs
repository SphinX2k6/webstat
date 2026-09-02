using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scalability;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200341B RID: 13339
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectScalabilitySetting.EffectScalabilitySetting_C")]
public class EffectScalabilitySetting : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025AD RID: 9645
	// (get) Token: 0x0601BD65 RID: 114021 RVA: 0x0084D3C8 File Offset: 0x0084B5C8
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	[UProperty(EPropertyFlags.CPF_None)]
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
				result = (this._NiagaraSettings = new TMap<TEnumAsByte<EEffectScalabilityType>, TSoftObjectPtr<NiagaraScalabilitySetting>>(base.NativePtr + (IntPtr)EffectScalabilitySetting.__PropertyOffset_NiagaraSettings, this));
			}
			return result;
		}
	}

	// Token: 0x0601BD66 RID: 114022 RVA: 0x0084D401 File Offset: 0x0084B601
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectScalabilitySetting._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectScalabilitySetting.EffectScalabilitySetting_C");
		}
		return EffectScalabilitySetting._ClassPtr;
	}

	// Token: 0x0601BD67 RID: 114023 RVA: 0x0084D428 File Offset: 0x0084B628
	public EffectScalabilitySetting() : this(BuiltinUtils.AllocNativeUObject(EffectScalabilitySetting.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD68 RID: 114024 RVA: 0x0084D450 File Offset: 0x0084B650
	[NullableContext(1)]
	public EffectScalabilitySetting(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectScalabilitySetting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD69 RID: 114025 RVA: 0x0084D483 File Offset: 0x0084B683
	protected EffectScalabilitySetting(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0D6 RID: 57558
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectScalabilitySetting.EffectScalabilitySetting_C";

	// Token: 0x0400E0D7 RID: 57559
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0D8 RID: 57560
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E0D9 RID: 57561
	private static int __PropertyOffset_NiagaraSettings;

	// Token: 0x0400E0DA RID: 57562
	[Nullable(new byte[]
	{
		2,
		0,
		1,
		1
	})]
	private TMap<TEnumAsByte<EEffectScalabilityType>, TSoftObjectPtr<NiagaraScalabilitySetting>> _NiagaraSettings;
}
