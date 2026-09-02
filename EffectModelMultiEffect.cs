using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200341C RID: 13340
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/MultiEffect/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/MultiEffect/EffectModelMultiEffect.EffectModelMultiEffect_C")]
public class EffectModelMultiEffect : UEffectModelMultiEffect, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD6A RID: 114026 RVA: 0x0084D48C File Offset: 0x0084B68C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelMultiEffect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/MultiEffect/EffectModelMultiEffect.EffectModelMultiEffect_C");
		}
		return EffectModelMultiEffect._ClassPtr;
	}

	// Token: 0x0601BD6B RID: 114027 RVA: 0x0084D4B0 File Offset: 0x0084B6B0
	public EffectModelMultiEffect() : this(BuiltinUtils.AllocNativeUObject(EffectModelMultiEffect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD6C RID: 114028 RVA: 0x0084D4D8 File Offset: 0x0084B6D8
	[NullableContext(1)]
	public EffectModelMultiEffect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelMultiEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD6D RID: 114029 RVA: 0x0084D50B File Offset: 0x0084B70B
	protected EffectModelMultiEffect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0DB RID: 57563
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/MultiEffect/EffectModelMultiEffect.EffectModelMultiEffect_C";

	// Token: 0x0400E0DC RID: 57564
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0DD RID: 57565
	private static IntPtr _ClassDefaultObjectPtr;
}
