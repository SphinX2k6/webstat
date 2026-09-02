using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200357E RID: 13694
public class __TsDecoratorNearChainEdge_SubClassMissingExportProxy : __TsDecoratorNearChainEdge_InheritProxy
{
	// Token: 0x0601CBEB RID: 117739 RVA: 0x008B2428 File Offset: 0x008B0628
	[NullableContext(1)]
	protected __TsDecoratorNearChainEdge_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorNearChainEdge.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBEC RID: 117740 RVA: 0x008B245B File Offset: 0x008B065B
	protected __TsDecoratorNearChainEdge_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
