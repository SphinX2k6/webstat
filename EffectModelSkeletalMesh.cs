using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003418 RID: 13336
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelSkeletalMesh.EffectModelSkeletalMesh_C")]
public class EffectModelSkeletalMesh : UEffectModelSkeletalMesh, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD59 RID: 114009 RVA: 0x0084D230 File Offset: 0x0084B430
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelSkeletalMesh._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelSkeletalMesh.EffectModelSkeletalMesh_C");
		}
		return EffectModelSkeletalMesh._ClassPtr;
	}

	// Token: 0x0601BD5A RID: 114010 RVA: 0x0084D254 File Offset: 0x0084B454
	public EffectModelSkeletalMesh() : this(BuiltinUtils.AllocNativeUObject(EffectModelSkeletalMesh.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD5B RID: 114011 RVA: 0x0084D27C File Offset: 0x0084B47C
	[NullableContext(1)]
	public EffectModelSkeletalMesh(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelSkeletalMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD5C RID: 114012 RVA: 0x0084D2AF File Offset: 0x0084B4AF
	protected EffectModelSkeletalMesh(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0CD RID: 57549
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelSkeletalMesh.EffectModelSkeletalMesh_C";

	// Token: 0x0400E0CE RID: 57550
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0CF RID: 57551
	private static IntPtr _ClassDefaultObjectPtr;
}
