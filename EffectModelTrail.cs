using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200341A RID: 13338
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelTrail.EffectModelTrail_C")]
public class EffectModelTrail : UEffectModelTrail, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD61 RID: 114017 RVA: 0x0084D340 File Offset: 0x0084B540
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelTrail._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelTrail.EffectModelTrail_C");
		}
		return EffectModelTrail._ClassPtr;
	}

	// Token: 0x0601BD62 RID: 114018 RVA: 0x0084D364 File Offset: 0x0084B564
	public EffectModelTrail() : this(BuiltinUtils.AllocNativeUObject(EffectModelTrail.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD63 RID: 114019 RVA: 0x0084D38C File Offset: 0x0084B58C
	[NullableContext(1)]
	public EffectModelTrail(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelTrail.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD64 RID: 114020 RVA: 0x0084D3BF File Offset: 0x0084B5BF
	protected EffectModelTrail(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0D3 RID: 57555
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelTrail.EffectModelTrail_C";

	// Token: 0x0400E0D4 RID: 57556
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0D5 RID: 57557
	private static IntPtr _ClassDefaultObjectPtr;
}
