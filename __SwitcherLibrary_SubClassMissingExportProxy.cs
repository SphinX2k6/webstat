using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200396A RID: 14698
public class __SwitcherLibrary_SubClassMissingExportProxy : __SwitcherLibrary_InheritProxy
{
	// Token: 0x0601D9DE RID: 121310 RVA: 0x008D5DA4 File Offset: 0x008D3FA4
	[NullableContext(1)]
	protected __SwitcherLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SwitcherLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9DF RID: 121311 RVA: 0x008D5DD7 File Offset: 0x008D3FD7
	protected __SwitcherLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
