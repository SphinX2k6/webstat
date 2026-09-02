using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003578 RID: 13688
public class __TsDecoratorInTeamArea_SubClassMissingExportProxy : __TsDecoratorInTeamArea_InheritProxy
{
	// Token: 0x0601CBDC RID: 117724 RVA: 0x008B2224 File Offset: 0x008B0424
	[NullableContext(1)]
	protected __TsDecoratorInTeamArea_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorInTeamArea.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBDD RID: 117725 RVA: 0x008B2257 File Offset: 0x008B0457
	protected __TsDecoratorInTeamArea_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
