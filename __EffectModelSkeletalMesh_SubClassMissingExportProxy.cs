using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003944 RID: 14660
public class __EffectModelSkeletalMesh_SubClassMissingExportProxy : __EffectModelSkeletalMesh_InheritProxy
{
	// Token: 0x0601D8F8 RID: 121080 RVA: 0x008D2CC8 File Offset: 0x008D0EC8
	[NullableContext(1)]
	protected __EffectModelSkeletalMesh_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelSkeletalMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8F9 RID: 121081 RVA: 0x008D2CFB File Offset: 0x008D0EFB
	protected __EffectModelSkeletalMesh_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
