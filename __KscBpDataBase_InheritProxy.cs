using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200383F RID: 14399
public class __KscBpDataBase_InheritProxy : KscBpDataBase
{
	// Token: 0x0601D50C RID: 120076 RVA: 0x008C7DF0 File Offset: 0x008C5FF0
	[NullableContext(1)]
	public __KscBpDataBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscBpDataBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D50D RID: 120077 RVA: 0x008C7E23 File Offset: 0x008C6023
	protected __KscBpDataBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
