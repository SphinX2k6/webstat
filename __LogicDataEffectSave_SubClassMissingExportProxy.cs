using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200389C RID: 14492
public class __LogicDataEffectSave_SubClassMissingExportProxy : __LogicDataEffectSave_InheritProxy
{
	// Token: 0x0601D63B RID: 120379 RVA: 0x008CAA28 File Offset: 0x008C8C28
	[NullableContext(1)]
	protected __LogicDataEffectSave_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataEffectSave.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D63C RID: 120380 RVA: 0x008CAA5B File Offset: 0x008C8C5B
	protected __LogicDataEffectSave_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
