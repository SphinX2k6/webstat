using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003632 RID: 13874
public class __TsTaskLookForSceneItem_SubClassMissingExportProxy : __TsTaskLookForSceneItem_InheritProxy
{
	// Token: 0x0601CDE8 RID: 118248 RVA: 0x008B6CB0 File Offset: 0x008B4EB0
	[NullableContext(1)]
	protected __TsTaskLookForSceneItem_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskLookForSceneItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDE9 RID: 118249 RVA: 0x008B6CE3 File Offset: 0x008B4EE3
	protected __TsTaskLookForSceneItem_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
