using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200382B RID: 14379
public class __TsActionHandle_InheritProxy : TsActionHandle
{
	// Token: 0x0601D4A6 RID: 119974 RVA: 0x008C6A04 File Offset: 0x008C4C04
	[NullableContext(1)]
	public __TsActionHandle_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsActionHandle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4A7 RID: 119975 RVA: 0x008C6A37 File Offset: 0x008C4C37
	protected __TsActionHandle_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D4A8 RID: 119976 RVA: 0x008C6A40 File Offset: 0x008C4C40
	protected unsafe override void __CPPCALL_OnPressAction_Implementation(TsActionHandle.__OnPressAction_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		base.OnPressAction_Implementation(key);
	}

	// Token: 0x0601D4A9 RID: 119977 RVA: 0x008C6A64 File Offset: 0x008C4C64
	protected unsafe override void __CPPCALL_OnReleaseAction_Implementation(TsActionHandle.__OnReleaseAction_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		base.OnReleaseAction_Implementation(key);
	}
}
