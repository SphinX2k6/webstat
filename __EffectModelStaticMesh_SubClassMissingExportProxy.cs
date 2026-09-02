using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003946 RID: 14662
public class __EffectModelStaticMesh_SubClassMissingExportProxy : __EffectModelStaticMesh_InheritProxy
{
	// Token: 0x0601D8FC RID: 121084 RVA: 0x008D2D40 File Offset: 0x008D0F40
	[NullableContext(1)]
	protected __EffectModelStaticMesh_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelStaticMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8FD RID: 121085 RVA: 0x008D2D73 File Offset: 0x008D0F73
	protected __EffectModelStaticMesh_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
