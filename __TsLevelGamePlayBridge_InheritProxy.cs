using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003851 RID: 14417
public class __TsLevelGamePlayBridge_InheritProxy : TsLevelGamePlayBridge
{
	// Token: 0x0601D547 RID: 120135 RVA: 0x008C88EC File Offset: 0x008C6AEC
	[NullableContext(1)]
	public __TsLevelGamePlayBridge_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsLevelGamePlayBridge.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D548 RID: 120136 RVA: 0x008C891F File Offset: 0x008C6B1F
	protected __TsLevelGamePlayBridge_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D549 RID: 120137 RVA: 0x008C8928 File Offset: 0x008C6B28
	protected unsafe override void __CPPCALL_UpdateGamePlayTimerBridge_Implementation(TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams* __Params)
	{
		base.UpdateGamePlayTimerBridge_Implementation(__Params->inGamePlayTimerId, __Params->inActivate);
	}

	// Token: 0x0601D54A RID: 120138 RVA: 0x008C893C File Offset: 0x008C6B3C
	protected unsafe override void __CPPCALL_GetDragonPoolState_Implementation(TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams* __Params)
	{
		__Params->__Result = base.GetDragonPoolState_Implementation(__Params->inDragonId);
	}

	// Token: 0x0601D54B RID: 120139 RVA: 0x008C8950 File Offset: 0x008C6B50
	protected unsafe override void __CPPCALL_ApplyScanEffect_Implementation(TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inActor);
		base.ApplyScanEffect_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D54C RID: 120140 RVA: 0x008C8970 File Offset: 0x008C6B70
	protected override void __CPPCALL_ClearAllScanEffects_Implementation()
	{
		base.ClearAllScanEffects_Implementation();
	}
}
