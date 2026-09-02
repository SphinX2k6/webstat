using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038CF RID: 14543
public class __TsMoveBlueprintFunctionLibrary_InheritProxy : TsMoveBlueprintFunctionLibrary
{
	// Token: 0x0601D6B9 RID: 120505 RVA: 0x008CBB84 File Offset: 0x008C9D84
	[NullableContext(1)]
	public __TsMoveBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMoveBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6BA RID: 120506 RVA: 0x008CBBB7 File Offset: 0x008C9DB7
	protected __TsMoveBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
