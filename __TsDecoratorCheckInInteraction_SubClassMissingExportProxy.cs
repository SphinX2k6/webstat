using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200355C RID: 13660
public class __TsDecoratorCheckInInteraction_SubClassMissingExportProxy : __TsDecoratorCheckInInteraction_InheritProxy
{
	// Token: 0x0601CB94 RID: 117652 RVA: 0x008B1850 File Offset: 0x008AFA50
	[NullableContext(1)]
	protected __TsDecoratorCheckInInteraction_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckInInteraction.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB95 RID: 117653 RVA: 0x008B1883 File Offset: 0x008AFA83
	protected __TsDecoratorCheckInInteraction_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
