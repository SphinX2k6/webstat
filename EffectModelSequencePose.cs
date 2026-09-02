using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003417 RID: 13335
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelSequencePose.EffectModelSequencePose_C")]
public class EffectModelSequencePose : UEffectModelSequencePose, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD55 RID: 114005 RVA: 0x0084D1A8 File Offset: 0x0084B3A8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelSequencePose._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelSequencePose.EffectModelSequencePose_C");
		}
		return EffectModelSequencePose._ClassPtr;
	}

	// Token: 0x0601BD56 RID: 114006 RVA: 0x0084D1CC File Offset: 0x0084B3CC
	public EffectModelSequencePose() : this(BuiltinUtils.AllocNativeUObject(EffectModelSequencePose.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD57 RID: 114007 RVA: 0x0084D1F4 File Offset: 0x0084B3F4
	[NullableContext(1)]
	public EffectModelSequencePose(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelSequencePose.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD58 RID: 114008 RVA: 0x0084D227 File Offset: 0x0084B427
	protected EffectModelSequencePose(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0CA RID: 57546
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelSequencePose.EffectModelSequencePose_C";

	// Token: 0x0400E0CB RID: 57547
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0CC RID: 57548
	private static IntPtr _ClassDefaultObjectPtr;
}
