using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E5 RID: 14565
public class __TsSimpleInteractHookPoint_InheritProxy : TsSimpleInteractHookPoint
{
	// Token: 0x0601D70A RID: 120586 RVA: 0x008CC864 File Offset: 0x008CAA64
	[NullableContext(1)]
	public __TsSimpleInteractHookPoint_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractHookPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D70B RID: 120587 RVA: 0x008CC897 File Offset: 0x008CAA97
	protected __TsSimpleInteractHookPoint_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
