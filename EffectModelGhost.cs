using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200340F RID: 13327
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGhost.EffectModelGhost_C")]
public class EffectModelGhost : UEffectModelGhost, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD35 RID: 113973 RVA: 0x0084CD68 File Offset: 0x0084AF68
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelGhost._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGhost.EffectModelGhost_C");
		}
		return EffectModelGhost._ClassPtr;
	}

	// Token: 0x0601BD36 RID: 113974 RVA: 0x0084CD8C File Offset: 0x0084AF8C
	public EffectModelGhost() : this(BuiltinUtils.AllocNativeUObject(EffectModelGhost.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD37 RID: 113975 RVA: 0x0084CDB4 File Offset: 0x0084AFB4
	[NullableContext(1)]
	public EffectModelGhost(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGhost.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD38 RID: 113976 RVA: 0x0084CDE7 File Offset: 0x0084AFE7
	protected EffectModelGhost(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0B2 RID: 57522
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGhost.EffectModelGhost_C";

	// Token: 0x0400E0B3 RID: 57523
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0B4 RID: 57524
	private static IntPtr _ClassDefaultObjectPtr;
}
