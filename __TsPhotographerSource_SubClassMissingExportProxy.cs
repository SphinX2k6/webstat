using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003860 RID: 14432
public class __TsPhotographerSource_SubClassMissingExportProxy : __TsPhotographerSource_InheritProxy
{
	// Token: 0x0601D58F RID: 120207 RVA: 0x008C9714 File Offset: 0x008C7914
	[NullableContext(1)]
	protected __TsPhotographerSource_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsPhotographerSource.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D590 RID: 120208 RVA: 0x008C9747 File Offset: 0x008C7947
	protected __TsPhotographerSource_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
