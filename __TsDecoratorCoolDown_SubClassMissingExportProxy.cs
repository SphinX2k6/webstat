using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003568 RID: 13672
public class __TsDecoratorCoolDown_SubClassMissingExportProxy : __TsDecoratorCoolDown_InheritProxy
{
	// Token: 0x0601CBB4 RID: 117684 RVA: 0x008B1CC4 File Offset: 0x008AFEC4
	[NullableContext(1)]
	protected __TsDecoratorCoolDown_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCoolDown.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBB5 RID: 117685 RVA: 0x008B1CF7 File Offset: 0x008AFEF7
	protected __TsDecoratorCoolDown_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
