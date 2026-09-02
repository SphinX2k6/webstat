using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E3 RID: 14563
public class __TsSimpleInteractCylinder_InheritProxy : TsSimpleInteractCylinder
{
	// Token: 0x0601D706 RID: 120582 RVA: 0x008CC7EC File Offset: 0x008CA9EC
	[NullableContext(1)]
	public __TsSimpleInteractCylinder_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractCylinder.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D707 RID: 120583 RVA: 0x008CC81F File Offset: 0x008CAA1F
	protected __TsSimpleInteractCylinder_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
