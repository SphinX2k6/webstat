using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Interaction.Struct;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200384D RID: 14413
public class __LevelGeneralBpBridge_InheritProxy : LevelGeneralBpBridge
{
	// Token: 0x0601D52B RID: 120107 RVA: 0x008C8214 File Offset: 0x008C6414
	[NullableContext(1)]
	public __LevelGeneralBpBridge_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBpBridge.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D52C RID: 120108 RVA: 0x008C8247 File Offset: 0x008C6447
	protected __LevelGeneralBpBridge_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D52D RID: 120109 RVA: 0x008C8250 File Offset: 0x008C6450
	protected unsafe override void __CPPCALL_HandleCoditionInteractOption_Implementation(LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams* __Params)
	{
		SInteractionOption inInteractOptionConfig = new SInteractionOption(&__Params->inInteractOptionConfig, true, true);
		string inInteractionConfigId = FString.ToString((void*)(&__Params->inInteractionConfigId));
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inTrigger);
		__Params->__Result = base.HandleCoditionInteractOption_Implementation(inInteractOptionConfig, inInteractionConfigId, __Params->inOptionIndex, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D52E RID: 120110 RVA: 0x008C829C File Offset: 0x008C649C
	protected unsafe override void __CPPCALL_TriggerLevelGeneralEvents_Implementation(LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->inTrigger);
		base.TriggerLevelGeneralEvents_Implementation(__Params->inEventGroupId, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D52F RID: 120111 RVA: 0x008C82C4 File Offset: 0x008C64C4
	protected unsafe override void __CPPCALL_HandleConditionalEventListen_Implementation(LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams* __Params)
	{
		TMap<int, int> inTargetMap = new TMap<int, int>(&__Params->inTargetMap, true, true);
		base.HandleConditionalEventListen_Implementation(inTargetMap);
	}

	// Token: 0x0601D530 RID: 120112 RVA: 0x008C82E7 File Offset: 0x008C64E7
	protected unsafe override void __CPPCALL_HandleConditionPush_Implementation(LevelGeneralBpBridge.__HandleConditionPush_FunctionParams* __Params)
	{
		base.HandleConditionPush_Implementation(__Params->inConditionGroupId);
	}

	// Token: 0x0601D531 RID: 120113 RVA: 0x008C82F5 File Offset: 0x008C64F5
	protected override void __CPPCALL_OpenInteractHints_Implementation()
	{
		base.OpenInteractHints_Implementation();
	}

	// Token: 0x0601D532 RID: 120114 RVA: 0x008C82FD File Offset: 0x008C64FD
	protected override void __CPPCALL_CloseInteractHints_Implementation()
	{
		base.CloseInteractHints_Implementation();
	}
}
