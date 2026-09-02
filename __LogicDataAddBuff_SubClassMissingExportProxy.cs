using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200388C RID: 14476
public class __LogicDataAddBuff_SubClassMissingExportProxy : __LogicDataAddBuff_InheritProxy
{
	// Token: 0x0601D61B RID: 120347 RVA: 0x008CA668 File Offset: 0x008C8868
	[NullableContext(1)]
	protected __LogicDataAddBuff_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataAddBuff.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D61C RID: 120348 RVA: 0x008CA69B File Offset: 0x008C889B
	protected __LogicDataAddBuff_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
