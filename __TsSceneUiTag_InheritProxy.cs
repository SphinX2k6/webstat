using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003865 RID: 14437
public class __TsSceneUiTag_InheritProxy : TsSceneUiTag
{
	// Token: 0x0601D59F RID: 120223 RVA: 0x008C99A8 File Offset: 0x008C7BA8
	[NullableContext(1)]
	public __TsSceneUiTag_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSceneUiTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5A0 RID: 120224 RVA: 0x008C99DB File Offset: 0x008C7BDB
	protected __TsSceneUiTag_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5A1 RID: 120225 RVA: 0x008C99E4 File Offset: 0x008C7BE4
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D5A2 RID: 120226 RVA: 0x008C99EC File Offset: 0x008C7BEC
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D5A3 RID: 120227 RVA: 0x008C9A0C File Offset: 0x008C7C0C
	protected unsafe override void __CPPCALL_OnCanTick_Implementation(TsSceneUiTag.__OnCanTick_FunctionParams* __Params)
	{
		__Params->__Result = base.OnCanTick_Implementation();
	}
}
