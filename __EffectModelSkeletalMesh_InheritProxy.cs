using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003943 RID: 14659
public class __EffectModelSkeletalMesh_InheritProxy : EffectModelSkeletalMesh
{
	// Token: 0x0601D8F6 RID: 121078 RVA: 0x008D2C8C File Offset: 0x008D0E8C
	[NullableContext(1)]
	public __EffectModelSkeletalMesh_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelSkeletalMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8F7 RID: 121079 RVA: 0x008D2CBF File Offset: 0x008D0EBF
	protected __EffectModelSkeletalMesh_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
