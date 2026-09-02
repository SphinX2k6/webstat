using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003419 RID: 13337
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelStaticMesh.EffectModelStaticMesh_C")]
public class EffectModelStaticMesh : UEffectModelStaticMesh, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD5D RID: 114013 RVA: 0x0084D2B8 File Offset: 0x0084B4B8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelStaticMesh._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelStaticMesh.EffectModelStaticMesh_C");
		}
		return EffectModelStaticMesh._ClassPtr;
	}

	// Token: 0x0601BD5E RID: 114014 RVA: 0x0084D2DC File Offset: 0x0084B4DC
	public EffectModelStaticMesh() : this(BuiltinUtils.AllocNativeUObject(EffectModelStaticMesh.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD5F RID: 114015 RVA: 0x0084D304 File Offset: 0x0084B504
	[NullableContext(1)]
	public EffectModelStaticMesh(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelStaticMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD60 RID: 114016 RVA: 0x0084D337 File Offset: 0x0084B537
	protected EffectModelStaticMesh(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0D0 RID: 57552
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelStaticMesh.EffectModelStaticMesh_C";

	// Token: 0x0400E0D1 RID: 57553
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0D2 RID: 57554
	private static IntPtr _ClassDefaultObjectPtr;
}
