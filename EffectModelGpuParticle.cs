using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003410 RID: 13328
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/Data/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGpuParticle.EffectModelGpuParticle_C")]
public class EffectModelGpuParticle : UEffectModelGpuParticle, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BD39 RID: 113977 RVA: 0x0084CDF0 File Offset: 0x0084AFF0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectModelGpuParticle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGpuParticle.EffectModelGpuParticle_C");
		}
		return EffectModelGpuParticle._ClassPtr;
	}

	// Token: 0x0601BD3A RID: 113978 RVA: 0x0084CE14 File Offset: 0x0084B014
	public EffectModelGpuParticle() : this(BuiltinUtils.AllocNativeUObject(EffectModelGpuParticle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD3B RID: 113979 RVA: 0x0084CE3C File Offset: 0x0084B03C
	[NullableContext(1)]
	public EffectModelGpuParticle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGpuParticle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD3C RID: 113980 RVA: 0x0084CE6F File Offset: 0x0084B06F
	protected EffectModelGpuParticle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E0B5 RID: 57525
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGpuParticle.EffectModelGpuParticle_C";

	// Token: 0x0400E0B6 RID: 57526
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0B7 RID: 57527
	private static IntPtr _ClassDefaultObjectPtr;
}
