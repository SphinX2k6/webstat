using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038AC RID: 14508
public class __LogicDataShowMesh_SubClassMissingExportProxy : __LogicDataShowMesh_InheritProxy
{
	// Token: 0x0601D65B RID: 120411 RVA: 0x008CADE8 File Offset: 0x008C8FE8
	[NullableContext(1)]
	protected __LogicDataShowMesh_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShowMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D65C RID: 120412 RVA: 0x008CAE1B File Offset: 0x008C901B
	protected __LogicDataShowMesh_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
