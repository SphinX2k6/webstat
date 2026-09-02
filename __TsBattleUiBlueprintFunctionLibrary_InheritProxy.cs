using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C1 RID: 14529
public class __TsBattleUiBlueprintFunctionLibrary_InheritProxy : TsBattleUiBlueprintFunctionLibrary
{
	// Token: 0x0601D69D RID: 120477 RVA: 0x008CB83C File Offset: 0x008C9A3C
	[NullableContext(1)]
	public __TsBattleUiBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBattleUiBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D69E RID: 120478 RVA: 0x008CB86F File Offset: 0x008C9A6F
	protected __TsBattleUiBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
