using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003415 RID: 13333
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNiagara.EffectModelNiagara_C")]
public class EffectModelNiagara : UEffectModelNiagara, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD4D RID: 113997 RVA: 0x0084D098 File Offset: 0x0084B298
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelNiagara._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNiagara.EffectModelNiagara_C");
		}
		return EffectModelNiagara._ClassPtr;
	}

	// Token: 0x0601BD4E RID: 113998 RVA: 0x0084D0BC File Offset: 0x0084B2BC
	public EffectModelNiagara() : this(BuiltinUtils.AllocNativeUObject(EffectModelNiagara.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD4F RID: 113999 RVA: 0x0084D0E4 File Offset: 0x0084B2E4
	[NullableContext(1)]
	public EffectModelNiagara(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelNiagara.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD50 RID: 114000 RVA: 0x0084D117 File Offset: 0x0084B317
	protected EffectModelNiagara(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0C4 RID: 57540
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNiagara.EffectModelNiagara_C";

	// Token: 0x0400E0C5 RID: 57541
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0C6 RID: 57542
	private static IntPtr _ClassDefaultObjectPtr;
}
