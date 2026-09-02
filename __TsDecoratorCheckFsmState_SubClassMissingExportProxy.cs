using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003558 RID: 13656
public class __TsDecoratorCheckFsmState_SubClassMissingExportProxy : __TsDecoratorCheckFsmState_InheritProxy
{
	// Token: 0x0601CB8A RID: 117642 RVA: 0x008B16F8 File Offset: 0x008AF8F8
	[NullableContext(1)]
	protected __TsDecoratorCheckFsmState_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckFsmState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB8B RID: 117643 RVA: 0x008B172B File Offset: 0x008AF92B
	protected __TsDecoratorCheckFsmState_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
