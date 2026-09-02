using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003411 RID: 13329
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGroup.EffectModelGroup_C")]
public class EffectModelGroup : UEffectModelGroup, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD3D RID: 113981 RVA: 0x0084CE78 File Offset: 0x0084B078
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelGroup._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGroup.EffectModelGroup_C");
		}
		return EffectModelGroup._ClassPtr;
	}

	// Token: 0x0601BD3E RID: 113982 RVA: 0x0084CE9C File Offset: 0x0084B09C
	public EffectModelGroup() : this(BuiltinUtils.AllocNativeUObject(EffectModelGroup.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD3F RID: 113983 RVA: 0x0084CEC4 File Offset: 0x0084B0C4
	[NullableContext(1)]
	public EffectModelGroup(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGroup.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD40 RID: 113984 RVA: 0x0084CEF7 File Offset: 0x0084B0F7
	protected EffectModelGroup(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0B8 RID: 57528
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGroup.EffectModelGroup_C";

	// Token: 0x0400E0B9 RID: 57529
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0BA RID: 57530
	private static IntPtr _ClassDefaultObjectPtr;
}
