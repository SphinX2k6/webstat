using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scalability;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200341D RID: 13341
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/NiagaraScalabilitySetting.NiagaraScalabilitySetting_C")]
public class NiagaraScalabilitySetting : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025AE RID: 9646
	// (get) Token: 0x0601BD6E RID: 114030 RVA: 0x0084D514 File Offset: 0x0084B714
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<ENiagaraScalabilityType, UNiagaraEffectType> NiagaraEffectTypes
	{
		get
		{
			base.FastCheckIsValid();
			TMap<ENiagaraScalabilityType, UNiagaraEffectType> result;
			if ((result = this._NiagaraEffectTypes) == null)
			{
				result = (this._NiagaraEffectTypes = new TMap<ENiagaraScalabilityType, UNiagaraEffectType>(base.NativePtr + (IntPtr)NiagaraScalabilitySetting.__PropertyOffset_NiagaraEffectTypes, this));
			}
			return result;
		}
	}

	// Token: 0x0601BD6F RID: 114031 RVA: 0x0084D54D File Offset: 0x0084B74D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (NiagaraScalabilitySetting._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/NiagaraScalabilitySetting.NiagaraScalabilitySetting_C");
		}
		return NiagaraScalabilitySetting._ClassPtr;
	}

	// Token: 0x0601BD70 RID: 114032 RVA: 0x0084D574 File Offset: 0x0084B774
	public NiagaraScalabilitySetting() : this(BuiltinUtils.AllocNativeUObject(NiagaraScalabilitySetting.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD71 RID: 114033 RVA: 0x0084D59C File Offset: 0x0084B79C
	public NiagaraScalabilitySetting(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NiagaraScalabilitySetting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD72 RID: 114034 RVA: 0x0084D5CF File Offset: 0x0084B7CF
	protected NiagaraScalabilitySetting(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0DE RID: 57566
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/NiagaraScalabilitySetting.NiagaraScalabilitySetting_C";

	// Token: 0x0400E0DF RID: 57567
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0E0 RID: 57568
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E0E1 RID: 57569
	private static int __PropertyOffset_NiagaraEffectTypes;

	// Token: 0x0400E0E2 RID: 57570
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<ENiagaraScalabilityType, UNiagaraEffectType> _NiagaraEffectTypes;
}
