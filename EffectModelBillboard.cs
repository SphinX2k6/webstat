using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200340C RID: 13324
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelBillboard.EffectModelBillboard_C")]
public class EffectModelBillboard : UEffectModelBillboard, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD29 RID: 113961 RVA: 0x0084CBD0 File Offset: 0x0084ADD0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelBillboard._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelBillboard.EffectModelBillboard_C");
		}
		return EffectModelBillboard._ClassPtr;
	}

	// Token: 0x0601BD2A RID: 113962 RVA: 0x0084CBF4 File Offset: 0x0084ADF4
	public EffectModelBillboard() : this(BuiltinUtils.AllocNativeUObject(EffectModelBillboard.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD2B RID: 113963 RVA: 0x0084CC1C File Offset: 0x0084AE1C
	[NullableContext(1)]
	public EffectModelBillboard(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelBillboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD2C RID: 113964 RVA: 0x0084CC4F File Offset: 0x0084AE4F
	protected EffectModelBillboard(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0A9 RID: 57513
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelBillboard.EffectModelBillboard_C";

	// Token: 0x0400E0AA RID: 57514
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0AB RID: 57515
	private static IntPtr _ClassDefaultObjectPtr;
}
