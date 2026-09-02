using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200386E RID: 14446
public class __TsTowerDefenseEventActor_SubClassMissingExportProxy : __TsTowerDefenseEventActor_InheritProxy
{
	// Token: 0x0601D5B7 RID: 120247 RVA: 0x008C9C8C File Offset: 0x008C7E8C
	[NullableContext(1)]
	protected __TsTowerDefenseEventActor_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTowerDefenseEventActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5B8 RID: 120248 RVA: 0x008C9CBF File Offset: 0x008C7EBF
	protected __TsTowerDefenseEventActor_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
