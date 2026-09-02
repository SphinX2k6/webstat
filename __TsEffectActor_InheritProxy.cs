using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003839 RID: 14393
public class __TsEffectActor_InheritProxy : TsEffectActor
{
	// Token: 0x0601D4F9 RID: 120057 RVA: 0x008C7AE4 File Offset: 0x008C5CE4
	[NullableContext(1)]
	public __TsEffectActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEffectActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4FA RID: 120058 RVA: 0x008C7B17 File Offset: 0x008C5D17
	protected __TsEffectActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D4FB RID: 120059 RVA: 0x008C7B20 File Offset: 0x008C5D20
	protected unsafe override void __CPPCALL_GetHandle_Implementation(TsEffectActor.__GetHandle_FunctionParams* __Params)
	{
		base.GetHandle_Implementation(ref __Params->handle);
	}

	// Token: 0x0601D4FC RID: 120060 RVA: 0x008C7B2E File Offset: 0x008C5D2E
	protected unsafe override void __CPPCALL_SetHandle_Implementation(TsEffectActor.__SetHandle_FunctionParams* __Params)
	{
		base.SetHandle_Implementation(__Params->handle);
	}

	// Token: 0x0601D4FD RID: 120061 RVA: 0x008C7B3C File Offset: 0x008C5D3C
	protected override void __CPPCALL_RemoveHandle_Implementation()
	{
		base.RemoveHandle_Implementation();
	}

	// Token: 0x0601D4FE RID: 120062 RVA: 0x008C7B44 File Offset: 0x008C5D44
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}
}
