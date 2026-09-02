using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003416 RID: 13334
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelPostProcess.EffectModelPostProcess_C")]
public class EffectModelPostProcess : UEffectModelPostProcess, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD51 RID: 114001 RVA: 0x0084D120 File Offset: 0x0084B320
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelPostProcess._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelPostProcess.EffectModelPostProcess_C");
		}
		return EffectModelPostProcess._ClassPtr;
	}

	// Token: 0x0601BD52 RID: 114002 RVA: 0x0084D144 File Offset: 0x0084B344
	public EffectModelPostProcess() : this(BuiltinUtils.AllocNativeUObject(EffectModelPostProcess.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD53 RID: 114003 RVA: 0x0084D16C File Offset: 0x0084B36C
	[NullableContext(1)]
	public EffectModelPostProcess(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelPostProcess.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD54 RID: 114004 RVA: 0x0084D19F File Offset: 0x0084B39F
	protected EffectModelPostProcess(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0C7 RID: 57543
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelPostProcess.EffectModelPostProcess_C";

	// Token: 0x0400E0C8 RID: 57544
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0C9 RID: 57545
	private static IntPtr _ClassDefaultObjectPtr;
}
