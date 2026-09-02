using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200385F RID: 14431
public class __TsPhotographerSource_InheritProxy : TsPhotographerSource
{
	// Token: 0x0601D58D RID: 120205 RVA: 0x008C96D8 File Offset: 0x008C78D8
	[NullableContext(1)]
	public __TsPhotographerSource_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsPhotographerSource.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D58E RID: 120206 RVA: 0x008C970B File Offset: 0x008C790B
	protected __TsPhotographerSource_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
