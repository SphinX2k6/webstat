using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200396F RID: 14703
public class __TsGameBudgetFunctionLibrary_InheritProxy : TsGameBudgetFunctionLibrary
{
	// Token: 0x0601D9FC RID: 121340 RVA: 0x008D6508 File Offset: 0x008D4708
	[NullableContext(1)]
	public __TsGameBudgetFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsGameBudgetFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9FD RID: 121341 RVA: 0x008D653B File Offset: 0x008D473B
	protected __TsGameBudgetFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
