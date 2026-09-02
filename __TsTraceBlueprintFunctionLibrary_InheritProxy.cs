using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D3 RID: 14547
public class __TsTraceBlueprintFunctionLibrary_InheritProxy : TsTraceBlueprintFunctionLibrary
{
	// Token: 0x0601D6C1 RID: 120513 RVA: 0x008CBC74 File Offset: 0x008C9E74
	[NullableContext(1)]
	public __TsTraceBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTraceBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6C2 RID: 120514 RVA: 0x008CBCA7 File Offset: 0x008C9EA7
	protected __TsTraceBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
