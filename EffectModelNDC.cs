using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003414 RID: 13332
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNDC.EffectModelNDC_C")]
public class EffectModelNDC : UEffectModelNDC, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD49 RID: 113993 RVA: 0x0084D010 File Offset: 0x0084B210
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelNDC._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNDC.EffectModelNDC_C");
		}
		return EffectModelNDC._ClassPtr;
	}

	// Token: 0x0601BD4A RID: 113994 RVA: 0x0084D034 File Offset: 0x0084B234
	public EffectModelNDC() : this(BuiltinUtils.AllocNativeUObject(EffectModelNDC.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD4B RID: 113995 RVA: 0x0084D05C File Offset: 0x0084B25C
	[NullableContext(1)]
	public EffectModelNDC(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelNDC.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD4C RID: 113996 RVA: 0x0084D08F File Offset: 0x0084B28F
	protected EffectModelNDC(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0C1 RID: 57537
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelNDC.EffectModelNDC_C";

	// Token: 0x0400E0C2 RID: 57538
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0C3 RID: 57539
	private static IntPtr _ClassDefaultObjectPtr;
}
