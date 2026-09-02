using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200355A RID: 13658
public class __TsDecoratorCheckInbound_SubClassMissingExportProxy : __TsDecoratorCheckInbound_InheritProxy
{
	// Token: 0x0601CB8F RID: 117647 RVA: 0x008B17A4 File Offset: 0x008AF9A4
	[NullableContext(1)]
	protected __TsDecoratorCheckInbound_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckInbound.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB90 RID: 117648 RVA: 0x008B17D7 File Offset: 0x008AF9D7
	protected __TsDecoratorCheckInbound_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
