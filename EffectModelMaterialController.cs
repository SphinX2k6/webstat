using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003413 RID: 13331
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelMaterialController.EffectModelMaterialController_C")]
public class EffectModelMaterialController : UEffectModelMaterialController, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD45 RID: 113989 RVA: 0x0084CF88 File Offset: 0x0084B188
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelMaterialController._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelMaterialController.EffectModelMaterialController_C");
		}
		return EffectModelMaterialController._ClassPtr;
	}

	// Token: 0x0601BD46 RID: 113990 RVA: 0x0084CFAC File Offset: 0x0084B1AC
	public EffectModelMaterialController() : this(BuiltinUtils.AllocNativeUObject(EffectModelMaterialController.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD47 RID: 113991 RVA: 0x0084CFD4 File Offset: 0x0084B1D4
	[NullableContext(1)]
	public EffectModelMaterialController(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelMaterialController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD48 RID: 113992 RVA: 0x0084D007 File Offset: 0x0084B207
	protected EffectModelMaterialController(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0BE RID: 57534
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelMaterialController.EffectModelMaterialController_C";

	// Token: 0x0400E0BF RID: 57535
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0C0 RID: 57536
	private static IntPtr _ClassDefaultObjectPtr;
}
