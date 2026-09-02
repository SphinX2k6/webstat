using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200340D RID: 13325
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelCurveTrailDecal.EffectModelCurveTrailDecal_C")]
public class EffectModelCurveTrailDecal : UEffectModelCurveTrailDecal, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD2D RID: 113965 RVA: 0x0084CC58 File Offset: 0x0084AE58
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelCurveTrailDecal._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelCurveTrailDecal.EffectModelCurveTrailDecal_C");
		}
		return EffectModelCurveTrailDecal._ClassPtr;
	}

	// Token: 0x0601BD2E RID: 113966 RVA: 0x0084CC7C File Offset: 0x0084AE7C
	public EffectModelCurveTrailDecal() : this(BuiltinUtils.AllocNativeUObject(EffectModelCurveTrailDecal.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD2F RID: 113967 RVA: 0x0084CCA4 File Offset: 0x0084AEA4
	[NullableContext(1)]
	public EffectModelCurveTrailDecal(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelCurveTrailDecal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD30 RID: 113968 RVA: 0x0084CCD7 File Offset: 0x0084AED7
	protected EffectModelCurveTrailDecal(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0AC RID: 57516
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelCurveTrailDecal.EffectModelCurveTrailDecal_C";

	// Token: 0x0400E0AD RID: 57517
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0AE RID: 57518
	private static IntPtr _ClassDefaultObjectPtr;
}
