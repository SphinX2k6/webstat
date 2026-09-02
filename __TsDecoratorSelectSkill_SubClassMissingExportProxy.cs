using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003586 RID: 13702
public class __TsDecoratorSelectSkill_SubClassMissingExportProxy : __TsDecoratorSelectSkill_InheritProxy
{
	// Token: 0x0601CBFF RID: 117759 RVA: 0x008B26D8 File Offset: 0x008B08D8
	[NullableContext(1)]
	protected __TsDecoratorSelectSkill_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorSelectSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC00 RID: 117760 RVA: 0x008B270B File Offset: 0x008B090B
	protected __TsDecoratorSelectSkill_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
