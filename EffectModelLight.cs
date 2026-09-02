using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003412 RID: 13330
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelLight.EffectModelLight_C")]
public class EffectModelLight : UEffectModelLight, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD41 RID: 113985 RVA: 0x0084CF00 File Offset: 0x0084B100
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelLight._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelLight.EffectModelLight_C");
		}
		return EffectModelLight._ClassPtr;
	}

	// Token: 0x0601BD42 RID: 113986 RVA: 0x0084CF24 File Offset: 0x0084B124
	public EffectModelLight() : this(BuiltinUtils.AllocNativeUObject(EffectModelLight.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD43 RID: 113987 RVA: 0x0084CF4C File Offset: 0x0084B14C
	[NullableContext(1)]
	public EffectModelLight(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelLight.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD44 RID: 113988 RVA: 0x0084CF7F File Offset: 0x0084B17F
	protected EffectModelLight(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0BB RID: 57531
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelLight.EffectModelLight_C";

	// Token: 0x0400E0BC RID: 57532
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0BD RID: 57533
	private static IntPtr _ClassDefaultObjectPtr;
}
