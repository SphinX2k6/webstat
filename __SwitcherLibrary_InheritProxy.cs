using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003969 RID: 14697
public class __SwitcherLibrary_InheritProxy : SwitcherLibrary
{
	// Token: 0x0601D9DC RID: 121308 RVA: 0x008D5D68 File Offset: 0x008D3F68
	[NullableContext(1)]
	public __SwitcherLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SwitcherLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9DD RID: 121309 RVA: 0x008D5D9B File Offset: 0x008D3F9B
	protected __SwitcherLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
