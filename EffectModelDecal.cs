using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200340E RID: 13326
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelDecal.EffectModelDecal_C")]
public class EffectModelDecal : UEffectModelDecal, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD31 RID: 113969 RVA: 0x0084CCE0 File Offset: 0x0084AEE0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelDecal._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelDecal.EffectModelDecal_C");
		}
		return EffectModelDecal._ClassPtr;
	}

	// Token: 0x0601BD32 RID: 113970 RVA: 0x0084CD04 File Offset: 0x0084AF04
	public EffectModelDecal() : this(BuiltinUtils.AllocNativeUObject(EffectModelDecal.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD33 RID: 113971 RVA: 0x0084CD2C File Offset: 0x0084AF2C
	[NullableContext(1)]
	public EffectModelDecal(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelDecal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD34 RID: 113972 RVA: 0x0084CD5F File Offset: 0x0084AF5F
	protected EffectModelDecal(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0AF RID: 57519
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelDecal.EffectModelDecal_C";

	// Token: 0x0400E0B0 RID: 57520
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0B1 RID: 57521
	private static IntPtr _ClassDefaultObjectPtr;
}
