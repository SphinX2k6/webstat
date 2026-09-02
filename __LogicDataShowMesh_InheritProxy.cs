using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038AB RID: 14507
public class __LogicDataShowMesh_InheritProxy : LogicDataShowMesh
{
	// Token: 0x0601D659 RID: 120409 RVA: 0x008CADAC File Offset: 0x008C8FAC
	[NullableContext(1)]
	public __LogicDataShowMesh_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShowMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D65A RID: 120410 RVA: 0x008CADDF File Offset: 0x008C8FDF
	protected __LogicDataShowMesh_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
