using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003945 RID: 14661
public class __EffectModelStaticMesh_InheritProxy : EffectModelStaticMesh
{
	// Token: 0x0601D8FA RID: 121082 RVA: 0x008D2D04 File Offset: 0x008D0F04
	[NullableContext(1)]
	public __EffectModelStaticMesh_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelStaticMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8FB RID: 121083 RVA: 0x008D2D37 File Offset: 0x008D0F37
	protected __EffectModelStaticMesh_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
