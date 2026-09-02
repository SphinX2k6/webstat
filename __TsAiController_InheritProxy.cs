using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Monster.Common;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003687 RID: 13959
public class __TsAiController_InheritProxy : TsAiController
{
	// Token: 0x0601CED1 RID: 118481 RVA: 0x008B8D18 File Offset: 0x008B6F18
	[NullableContext(1)]
	public __TsAiController_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAiController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CED2 RID: 118482 RVA: 0x008B8D4B File Offset: 0x008B6F4B
	protected __TsAiController_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CED3 RID: 118483 RVA: 0x008B8D54 File Offset: 0x008B6F54
	protected override void __CPPCALL_OnStart_Implementation()
	{
		base.OnStart_Implementation();
	}

	// Token: 0x0601CED4 RID: 118484 RVA: 0x008B8D5C File Offset: 0x008B6F5C
	protected override void __CPPCALL_获取控制权时_Implementation()
	{
		base.获取控制权时_Implementation();
	}

	// Token: 0x0601CED5 RID: 118485 RVA: 0x008B8D64 File Offset: 0x008B6F64
	protected unsafe override void __CPPCALL_状态切换时_Implementation(TsAiController.__状态切换时_FunctionParams* __Params)
	{
		ECharacterState oldState = (ECharacterState)__Params->oldState;
		ECharacterState newState = (ECharacterState)__Params->newState;
		base.状态切换时_Implementation(oldState, newState, __Params->isAutonomousProxy);
	}

	// Token: 0x0601CED6 RID: 118486 RVA: 0x008B8D8D File Offset: 0x008B6F8D
	protected unsafe override void __CPPCALL_渲染状态改变时_Implementation(TsAiController.__渲染状态改变时_FunctionParams* __Params)
	{
		base.渲染状态改变时_Implementation(__Params->wasRendered);
	}

	// Token: 0x0601CED7 RID: 118487 RVA: 0x008B8D9C File Offset: 0x008B6F9C
	protected unsafe override void __CPPCALL_AddComplicatedEventBinder_Implementation(TsAiController.__AddComplicatedEventBinder_FunctionParams* __Params)
	{
		SAiConditions conditions = new SAiConditions(&__Params->conditions, true, true);
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		base.AddComplicatedEventBinder_Implementation(conditions, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CED8 RID: 118488 RVA: 0x008B8DCC File Offset: 0x008B6FCC
	protected unsafe override void __CPPCALL_AddSceneItemDestroyEventBinder_Implementation(TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams* __Params)
	{
		UKuroActorEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroActorEventBinder>(__Params->eventBinder);
		base.AddSceneItemDestroyEventBinder_Implementation(__Params->distance, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CED9 RID: 118489 RVA: 0x008B8DF4 File Offset: 0x008B6FF4
	protected unsafe override void __CPPCALL_AddLevelVarBoolEventBinder_Implementation(TsAiController.__AddLevelVarBoolEventBinder_FunctionParams* __Params)
	{
		SAiLevelVar levelVar = new SAiLevelVar(&__Params->levelVar, true, true);
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		base.AddLevelVarBoolEventBinder_Implementation(levelVar, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CEDA RID: 118490 RVA: 0x008B8E24 File Offset: 0x008B7024
	protected unsafe override void __CPPCALL_AddLevelVarIntEventBinder_Implementation(TsAiController.__AddLevelVarIntEventBinder_FunctionParams* __Params)
	{
		SAiLevelVar levelVar = new SAiLevelVar(&__Params->levelVar, true, true);
		UKuroIntEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroIntEventBinder>(__Params->eventBinder);
		base.AddLevelVarIntEventBinder_Implementation(levelVar, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CEDB RID: 118491 RVA: 0x008B8E54 File Offset: 0x008B7054
	protected unsafe override void __CPPCALL_AddHateEventBinder_Implementation(TsAiController.__AddHateEventBinder_FunctionParams* __Params)
	{
		UKuroPerceptionEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroPerceptionEventBinder>(__Params->handler);
		base.AddHateEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CEDC RID: 118492 RVA: 0x008B8E74 File Offset: 0x008B7074
	protected unsafe override void __CPPCALL_AddPerceptionEventBinder_Implementation(TsAiController.__AddPerceptionEventBinder_FunctionParams* __Params)
	{
		UKuroPerceptionEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroPerceptionEventBinder>(__Params->handler);
		base.AddPerceptionEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CEDD RID: 118493 RVA: 0x008B8E94 File Offset: 0x008B7094
	protected unsafe override void __CPPCALL_SetPerceptionEventState_Implementation(TsAiController.__SetPerceptionEventState_FunctionParams* __Params)
	{
		base.SetPerceptionEventState_Implementation(__Params->includeFriend, __Params->includeEnemy, __Params->includeNeutral);
	}

	// Token: 0x0601CEDE RID: 118494 RVA: 0x008B8EB0 File Offset: 0x008B70B0
	protected unsafe override void __CPPCALL_AddHateOutRangeEventBinder_Implementation(TsAiController.__AddHateOutRangeEventBinder_FunctionParams* __Params)
	{
		UKuroPerceptionEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroPerceptionEventBinder>(__Params->handler);
		base.AddHateOutRangeEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CEDF RID: 118495 RVA: 0x008B8ED0 File Offset: 0x008B70D0
	protected unsafe override void __CPPCALL_ActivateSkillGroup_Implementation(TsAiController.__ActivateSkillGroup_FunctionParams* __Params)
	{
		base.ActivateSkillGroup_Implementation(__Params->skillGroupIndex, __Params->activate);
	}

	// Token: 0x0601CEE0 RID: 118496 RVA: 0x008B8EE4 File Offset: 0x008B70E4
	protected unsafe override void __CPPCALL_AddSkillCd_Implementation(TsAiController.__AddSkillCd_FunctionParams* __Params)
	{
		base.AddSkillCd_Implementation(__Params->skillInfoId, __Params->cdAdd);
	}

	// Token: 0x0601CEE1 RID: 118497 RVA: 0x008B8EF8 File Offset: 0x008B70F8
	protected unsafe override void __CPPCALL_AicApplyBuff_Implementation(TsAiController.__AicApplyBuff_FunctionParams* __Params)
	{
		base.AicApplyBuff_Implementation(__Params->buffId);
	}

	// Token: 0x0601CEE2 RID: 118498 RVA: 0x008B8F06 File Offset: 0x008B7106
	protected unsafe override void __CPPCALL_AicApplyBuffToTarget_Implementation(TsAiController.__AicApplyBuffToTarget_FunctionParams* __Params)
	{
		base.AicApplyBuffToTarget_Implementation(__Params->targetId, __Params->buffId);
	}

	// Token: 0x0601CEE3 RID: 118499 RVA: 0x008B8F1A File Offset: 0x008B711A
	protected unsafe override void __CPPCALL_AicRemoveBuff_Implementation(TsAiController.__AicRemoveBuff_FunctionParams* __Params)
	{
		base.AicRemoveBuff_Implementation(__Params->buffId);
	}

	// Token: 0x0601CEE4 RID: 118500 RVA: 0x008B8F28 File Offset: 0x008B7128
	protected unsafe override void __CPPCALL_AicAddTag_Implementation(TsAiController.__AicAddTag_FunctionParams* __Params)
	{
		base.AicAddTag_Implementation(__Params->tag);
	}

	// Token: 0x0601CEE5 RID: 118501 RVA: 0x008B8F36 File Offset: 0x008B7136
	protected unsafe override void __CPPCALL_AicRemoveTag_Implementation(TsAiController.__AicRemoveTag_FunctionParams* __Params)
	{
		base.AicRemoveTag_Implementation(__Params->tag);
	}

	// Token: 0x0601CEE6 RID: 118502 RVA: 0x008B8F44 File Offset: 0x008B7144
	protected unsafe override void __CPPCALL_SetBattleWanderTime_Implementation(TsAiController.__SetBattleWanderTime_FunctionParams* __Params)
	{
		base.SetBattleWanderTime_Implementation(__Params->min, __Params->max);
	}

	// Token: 0x0601CEE7 RID: 118503 RVA: 0x008B8F58 File Offset: 0x008B7158
	protected unsafe override void __CPPCALL_SetBattleWanderIndex_Implementation(TsAiController.__SetBattleWanderIndex_FunctionParams* __Params)
	{
		base.SetBattleWanderIndex_Implementation(__Params->index);
	}

	// Token: 0x0601CEE8 RID: 118504 RVA: 0x008B8F66 File Offset: 0x008B7166
	protected unsafe override void __CPPCALL_AddBattleWanderEndTime_Implementation(TsAiController.__AddBattleWanderEndTime_FunctionParams* __Params)
	{
		base.AddBattleWanderEndTime_Implementation(__Params->addTime);
	}

	// Token: 0x0601CEE9 RID: 118505 RVA: 0x008B8F74 File Offset: 0x008B7174
	protected unsafe override void __CPPCALL_SetAiSenseEnable_Implementation(TsAiController.__SetAiSenseEnable_FunctionParams* __Params)
	{
		base.SetAiSenseEnable_Implementation(__Params->index, __Params->enable);
	}

	// Token: 0x0601CEEA RID: 118506 RVA: 0x008B8F88 File Offset: 0x008B7188
	protected unsafe override void __CPPCALL_AddOrRemoveAiSense_Implementation(TsAiController.__AddOrRemoveAiSense_FunctionParams* __Params)
	{
		base.AddOrRemoveAiSense_Implementation(__Params->aiSenseId, __Params->add);
	}

	// Token: 0x0601CEEB RID: 118507 RVA: 0x008B8F9C File Offset: 0x008B719C
	protected unsafe override void __CPPCALL_EnableAiSenseByType_Implementation(TsAiController.__EnableAiSenseByType_FunctionParams* __Params)
	{
		base.EnableAiSenseByType_Implementation(__Params->type, __Params->enable);
	}

	// Token: 0x0601CEEC RID: 118508 RVA: 0x008B8FB0 File Offset: 0x008B71B0
	protected unsafe override void __CPPCALL_SetAiHateConfig_Implementation(TsAiController.__SetAiHateConfig_FunctionParams* __Params)
	{
		string aiHateConfig_Implementation = FString.ToString((void*)(&__Params->configId));
		base.SetAiHateConfig_Implementation(aiHateConfig_Implementation);
	}

	// Token: 0x0601CEED RID: 118509 RVA: 0x008B8FD1 File Offset: 0x008B71D1
	protected unsafe override void __CPPCALL_ChangeHatred_Implementation(TsAiController.__ChangeHatred_FunctionParams* __Params)
	{
		base.ChangeHatred_Implementation(__Params->entityId, __Params->rate, __Params->abs);
	}

	// Token: 0x0601CEEE RID: 118510 RVA: 0x008B8FEB File Offset: 0x008B71EB
	protected unsafe override void __CPPCALL_ClearHatred_Implementation(TsAiController.__ClearHatred_FunctionParams* __Params)
	{
		base.ClearHatred_Implementation(__Params->entityId);
	}

	// Token: 0x0601CEEF RID: 118511 RVA: 0x008B8FF9 File Offset: 0x008B71F9
	protected override void __CPPCALL_BindPlayerDamageEvents_Implementation()
	{
		base.BindPlayerDamageEvents_Implementation();
	}

	// Token: 0x0601CEF0 RID: 118512 RVA: 0x008B9004 File Offset: 0x008B7204
	protected unsafe override void __CPPCALL_AddAlertEventBinder_Implementation(TsAiController.__AddAlertEventBinder_FunctionParams* __Params)
	{
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		base.AddAlertEventBinder_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CEF1 RID: 118513 RVA: 0x008B9024 File Offset: 0x008B7224
	protected unsafe override void __CPPCALL_SetAiAlertConfig_Implementation(TsAiController.__SetAiAlertConfig_FunctionParams* __Params)
	{
		string aiAlertConfig_Implementation = FString.ToString((void*)(&__Params->configId));
		base.SetAiAlertConfig_Implementation(aiAlertConfig_Implementation);
	}

	// Token: 0x0601CEF2 RID: 118514 RVA: 0x008B9048 File Offset: 0x008B7248
	protected unsafe override void __CPPCALL_SetAiEnable_Implementation(TsAiController.__SetAiEnable_FunctionParams* __Params)
	{
		string key = FString.ToString((void*)(&__Params->key));
		base.SetAiEnable_Implementation(__Params->enable, key);
	}

	// Token: 0x0601CEF3 RID: 118515 RVA: 0x008B9070 File Offset: 0x008B7270
	protected unsafe override void __CPPCALL_TestChangeAi_Implementation(TsAiController.__TestChangeAi_FunctionParams* __Params)
	{
		string id = FString.ToString((void*)(&__Params->id));
		base.TestChangeAi_Implementation(id);
	}

	// Token: 0x0601CEF4 RID: 118516 RVA: 0x008B9091 File Offset: 0x008B7291
	protected unsafe override void __CPPCALL_LogReport_Implementation(TsAiController.__LogReport_FunctionParams* __Params)
	{
		base.LogReport_Implementation(__Params->logId);
	}

	// Token: 0x0601CEF5 RID: 118517 RVA: 0x008B909F File Offset: 0x008B729F
	protected unsafe override void __CPPCALL_逻辑主控_Implementation(TsAiController.__逻辑主控_FunctionParams* __Params)
	{
		__Params->__Result = base.逻辑主控_Implementation();
	}

	// Token: 0x0601CEF6 RID: 118518 RVA: 0x008B90AD File Offset: 0x008B72AD
	protected unsafe override void __CPPCALL_移动主控_Implementation(TsAiController.__移动主控_FunctionParams* __Params)
	{
		__Params->__Result = base.移动主控_Implementation();
	}

	// Token: 0x0601CEF7 RID: 118519 RVA: 0x008B90BC File Offset: 0x008B72BC
	protected unsafe override void __CPPCALL_检查状态机状态_Implementation(TsAiController.__检查状态机状态_FunctionParams* __Params)
	{
		TArray<string> tarray = new TArray<string>(&__Params->states, true, true);
		__Params->__Result = base.检查状态机状态_Implementation(ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->states, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x0601CEF8 RID: 118520 RVA: 0x008B9100 File Offset: 0x008B7300
	protected unsafe override void __CPPCALL_切换状态机状态_Implementation(TsAiController.__切换状态机状态_FunctionParams* __Params)
	{
		TArray<string> tarray = new TArray<string>(&__Params->states, true, true);
		base.切换状态机状态_Implementation(ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->states, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x0601CEF9 RID: 118521 RVA: 0x008B913D File Offset: 0x008B733D
	protected unsafe override void __CPPCALL_GetCoolDownDone_Implementation(TsAiController.__GetCoolDownDone_FunctionParams* __Params)
	{
		__Params->__Result = base.GetCoolDownDone_Implementation(__Params->id);
	}

	// Token: 0x0601CEFA RID: 118522 RVA: 0x008B9151 File Offset: 0x008B7351
	protected unsafe override void __CPPCALL_GetCoolDownRemainTime_Implementation(TsAiController.__GetCoolDownRemainTime_FunctionParams* __Params)
	{
		__Params->__Result = base.GetCoolDownRemainTime_Implementation(__Params->id);
	}

	// Token: 0x0601CEFB RID: 118523 RVA: 0x008B9165 File Offset: 0x008B7365
	protected unsafe override void __CPPCALL_SetCoolDown_Implementation(TsAiController.__SetCoolDown_FunctionParams* __Params)
	{
		base.SetCoolDown_Implementation(__Params->id, __Params->cd);
	}

	// Token: 0x0601CEFC RID: 118524 RVA: 0x008B917C File Offset: 0x008B737C
	protected unsafe override void __CPPCALL_InitCooldownEvent_Implementation(TsAiController.__InitCooldownEvent_FunctionParams* __Params)
	{
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		base.InitCooldownEvent_Implementation(__Params->id, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601CEFD RID: 118525 RVA: 0x008B91A2 File Offset: 0x008B73A2
	protected unsafe override void __CPPCALL_StartCooldownTimer_Implementation(TsAiController.__StartCooldownTimer_FunctionParams* __Params)
	{
		base.StartCooldownTimer_Implementation(__Params->id, __Params->duration);
	}

	// Token: 0x0601CEFE RID: 118526 RVA: 0x008B91B8 File Offset: 0x008B73B8
	protected unsafe override void __CPPCALL_GetDebugStateMachine_Implementation(TsAiController.__GetDebugStateMachine_FunctionParams* __Params)
	{
		TArray<FText> tarray = new TArray<FText>(&__Params->output, true, true);
		base.GetDebugStateMachine_Implementation(ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->output, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x0601CEFF RID: 118527 RVA: 0x008B91F5 File Offset: 0x008B73F5
	protected unsafe override void __CPPCALL_GetDebugText_Implementation(TsAiController.__GetDebugText_FunctionParams* __Params)
	{
		void* dest = (void*)(&__Params->__Result);
		FText debugText_Implementation = base.GetDebugText_Implementation();
		FText.NativeCopy(dest, (debugText_Implementation != null) ? debugText_Implementation.NativePtr : null, 1);
	}

	// Token: 0x0601CF00 RID: 118528 RVA: 0x008B9217 File Offset: 0x008B7417
	protected override void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		base.ReceiveDestroyed_Implementation();
	}
}
