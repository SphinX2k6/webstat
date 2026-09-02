using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003612 RID: 13842
public class __TsTaskDoTurn_SubClassMissingExportProxy : __TsTaskDoTurn_InheritProxy
{
	// Token: 0x0601CD91 RID: 118161 RVA: 0x008B605C File Offset: 0x008B425C
	[NullableContext(1)]
	protected __TsTaskDoTurn_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskDoTurn.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD92 RID: 118162 RVA: 0x008B608F File Offset: 0x008B428F
	protected __TsTaskDoTurn_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
