using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200340B RID: 13323
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelAudio.EffectModelAudio_C")]
public class EffectModelAudio : UEffectModelAudio, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD25 RID: 113957 RVA: 0x0084CB48 File Offset: 0x0084AD48
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelAudio._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelAudio.EffectModelAudio_C");
		}
		return EffectModelAudio._ClassPtr;
	}

	// Token: 0x0601BD26 RID: 113958 RVA: 0x0084CB6C File Offset: 0x0084AD6C
	public EffectModelAudio() : this(BuiltinUtils.AllocNativeUObject(EffectModelAudio.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD27 RID: 113959 RVA: 0x0084CB94 File Offset: 0x0084AD94
	[NullableContext(1)]
	public EffectModelAudio(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelAudio.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD28 RID: 113960 RVA: 0x0084CBC7 File Offset: 0x0084ADC7
	protected EffectModelAudio(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0A6 RID: 57510
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelAudio.EffectModelAudio_C";

	// Token: 0x0400E0A7 RID: 57511
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0A8 RID: 57512
	private static IntPtr _ClassDefaultObjectPtr;
}
