using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Monster.Common;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003688 RID: 13960
[NullableContext(1)]
[Nullable(0)]
public class __TsAiController_SubClassMissingExportProxy : __TsAiController_InheritProxy
{
	// Token: 0x0601CF01 RID: 118529 RVA: 0x008B9220 File Offset: 0x008B7420
	protected __TsAiController_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAiController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CF02 RID: 118530 RVA: 0x008B9253 File Offset: 0x008B7453
	protected __TsAiController_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CF03 RID: 118531 RVA: 0x008B925C File Offset: 0x008B745C
	public unsafe override void OnStart()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnStart"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF04 RID: 118532 RVA: 0x008B92CC File Offset: 0x008B74CC
	public unsafe override void 获取控制权时()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("获取控制权时"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF05 RID: 118533 RVA: 0x008B933C File Offset: 0x008B753C
	public unsafe override void 状态切换时(ECharacterState oldState, ECharacterState newState, bool isAutonomousProxy)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("状态切换时"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__状态切换时_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__状态切换时_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__状态切换时_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->oldState) = (byte)oldState;
			*(&ptr2->newState) = (byte)newState;
			ptr2->isAutonomousProxy = isAutonomousProxy;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF06 RID: 118534 RVA: 0x008B93C8 File Offset: 0x008B75C8
	public unsafe override void 渲染状态改变时(bool wasRendered)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("渲染状态改变时"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__渲染状态改变时_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__渲染状态改变时_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__渲染状态改变时_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->wasRendered = wasRendered;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF07 RID: 118535 RVA: 0x008B9440 File Offset: 0x008B7640
	public unsafe override void AddComplicatedEventBinder(SAiConditions conditions, UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComplicatedEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddComplicatedEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddComplicatedEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddComplicatedEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SAiConditions.StaticStruct(), &ptr2->conditions, (conditions != null) ? conditions.NativePtr : ((IntPtr)0), 1, false);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF08 RID: 118536 RVA: 0x008B94E8 File Offset: 0x008B76E8
	public unsafe override void AddSceneItemDestroyEventBinder(float distance, UKuroActorEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddSceneItemDestroyEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddSceneItemDestroyEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->distance = distance;
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF09 RID: 118537 RVA: 0x008B9574 File Offset: 0x008B7774
	public unsafe override void AddLevelVarBoolEventBinder(SAiLevelVar levelVar, UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddLevelVarBoolEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddLevelVarBoolEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddLevelVarBoolEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddLevelVarBoolEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SAiLevelVar.StaticStruct(), &ptr2->levelVar, (levelVar != null) ? levelVar.NativePtr : ((IntPtr)0), 1, false);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF0A RID: 118538 RVA: 0x008B961C File Offset: 0x008B781C
	public unsafe override void AddLevelVarIntEventBinder(SAiLevelVar levelVar, UKuroIntEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddLevelVarIntEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddLevelVarIntEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddLevelVarIntEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddLevelVarIntEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SAiLevelVar.StaticStruct(), &ptr2->levelVar, (levelVar != null) ? levelVar.NativePtr : ((IntPtr)0), 1, false);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF0B RID: 118539 RVA: 0x008B96C4 File Offset: 0x008B78C4
	public unsafe override void AddHateEventBinder(UKuroPerceptionEventBinder handler)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddHateEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddHateEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddHateEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddHateEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->handler) = ((handler != null) ? handler.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF0C RID: 118540 RVA: 0x008B974C File Offset: 0x008B794C
	public unsafe override void AddPerceptionEventBinder(UKuroPerceptionEventBinder handler)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddPerceptionEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddPerceptionEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddPerceptionEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddPerceptionEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->handler) = ((handler != null) ? handler.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF0D RID: 118541 RVA: 0x008B97D4 File Offset: 0x008B79D4
	public unsafe override void SetPerceptionEventState(bool includeFriend, bool includeEnemy, bool includeNeutral)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetPerceptionEventState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetPerceptionEventState_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetPerceptionEventState_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetPerceptionEventState_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->includeFriend = includeFriend;
			ptr2->includeEnemy = includeEnemy;
			ptr2->includeNeutral = includeNeutral;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF0E RID: 118542 RVA: 0x008B985C File Offset: 0x008B7A5C
	public unsafe override void AddHateOutRangeEventBinder(UKuroPerceptionEventBinder handler)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddHateOutRangeEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddHateOutRangeEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddHateOutRangeEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddHateOutRangeEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->handler) = ((handler != null) ? handler.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF0F RID: 118543 RVA: 0x008B98E4 File Offset: 0x008B7AE4
	public unsafe override void ActivateSkillGroup(int skillGroupIndex, bool activate)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ActivateSkillGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__ActivateSkillGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__ActivateSkillGroup_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__ActivateSkillGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->skillGroupIndex = skillGroupIndex;
			ptr2->activate = activate;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF10 RID: 118544 RVA: 0x008B9964 File Offset: 0x008B7B64
	public unsafe override void AddSkillCd(int skillInfoId, float cdAdd)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddSkillCd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddSkillCd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddSkillCd_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddSkillCd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->skillInfoId = skillInfoId;
			ptr2->cdAdd = cdAdd;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF11 RID: 118545 RVA: 0x008B99E4 File Offset: 0x008B7BE4
	protected unsafe override void AicApplyBuff(long buffId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicApplyBuff"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicApplyBuff_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicApplyBuff_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicApplyBuff_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->buffId = buffId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF12 RID: 118546 RVA: 0x008B9A5C File Offset: 0x008B7C5C
	protected unsafe override void AicApplyBuffToTarget(int targetId, long buffId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicApplyBuffToTarget"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicApplyBuffToTarget_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicApplyBuffToTarget_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicApplyBuffToTarget_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->targetId = targetId;
			ptr2->buffId = buffId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF13 RID: 118547 RVA: 0x008B9ADC File Offset: 0x008B7CDC
	protected unsafe override void AicRemoveBuff(long buffId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicRemoveBuff"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicRemoveBuff_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicRemoveBuff_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicRemoveBuff_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->buffId = buffId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF14 RID: 118548 RVA: 0x008B9B54 File Offset: 0x008B7D54
	protected unsafe override void AicAddTag(FGameplayTag tag)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicAddTag"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicAddTag_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicAddTag_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicAddTag_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->tag = tag;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF15 RID: 118549 RVA: 0x008B9BCC File Offset: 0x008B7DCC
	protected unsafe override void AicRemoveTag(FGameplayTag tag)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AicRemoveTag"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AicRemoveTag_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AicRemoveTag_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AicRemoveTag_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->tag = tag;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF16 RID: 118550 RVA: 0x008B9C44 File Offset: 0x008B7E44
	public unsafe override void SetBattleWanderTime(float min, float max)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetBattleWanderTime"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetBattleWanderTime_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetBattleWanderTime_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetBattleWanderTime_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->min = min;
			ptr2->max = max;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF17 RID: 118551 RVA: 0x008B9CC4 File Offset: 0x008B7EC4
	public unsafe override void SetBattleWanderIndex(int index)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetBattleWanderIndex"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetBattleWanderIndex_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetBattleWanderIndex_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetBattleWanderIndex_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->index = index;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF18 RID: 118552 RVA: 0x008B9D3C File Offset: 0x008B7F3C
	public unsafe override void AddBattleWanderEndTime(float addTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddBattleWanderEndTime"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddBattleWanderEndTime_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddBattleWanderEndTime_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddBattleWanderEndTime_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->addTime = addTime;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF19 RID: 118553 RVA: 0x008B9DB4 File Offset: 0x008B7FB4
	public unsafe override void SetAiSenseEnable(int index, bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiSenseEnable"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiSenseEnable_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiSenseEnable_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiSenseEnable_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->index = index;
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF1A RID: 118554 RVA: 0x008B9E34 File Offset: 0x008B8034
	public unsafe override void AddOrRemoveAiSense(int aiSenseId, bool add)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddOrRemoveAiSense"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddOrRemoveAiSense_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddOrRemoveAiSense_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddOrRemoveAiSense_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->aiSenseId = aiSenseId;
			ptr2->add = add;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF1B RID: 118555 RVA: 0x008B9EB4 File Offset: 0x008B80B4
	public unsafe override void EnableAiSenseByType(int type, bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EnableAiSenseByType"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__EnableAiSenseByType_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__EnableAiSenseByType_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__EnableAiSenseByType_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->type = type;
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF1C RID: 118556 RVA: 0x008B9F34 File Offset: 0x008B8134
	public unsafe override void SetAiHateConfig(string configId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiHateConfig"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiHateConfig_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiHateConfig_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiHateConfig_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->configId), configId);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF1D RID: 118557 RVA: 0x008B9FB4 File Offset: 0x008B81B4
	public unsafe override void ChangeHatred(int entityId, float rate, float abs)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeHatred"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__ChangeHatred_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__ChangeHatred_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__ChangeHatred_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
			ptr2->rate = rate;
			ptr2->abs = abs;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF1E RID: 118558 RVA: 0x008BA03C File Offset: 0x008B823C
	public unsafe override void ClearHatred(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ClearHatred"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__ClearHatred_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__ClearHatred_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__ClearHatred_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF1F RID: 118559 RVA: 0x008BA0B4 File Offset: 0x008B82B4
	public unsafe override void BindPlayerDamageEvents()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("BindPlayerDamageEvents"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF20 RID: 118560 RVA: 0x008BA124 File Offset: 0x008B8324
	public unsafe override void AddAlertEventBinder(UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddAlertEventBinder"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__AddAlertEventBinder_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__AddAlertEventBinder_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__AddAlertEventBinder_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF21 RID: 118561 RVA: 0x008BA1AC File Offset: 0x008B83AC
	public unsafe override void SetAiAlertConfig(string configId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiAlertConfig"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiAlertConfig_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiAlertConfig_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiAlertConfig_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->configId), configId);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF22 RID: 118562 RVA: 0x008BA22C File Offset: 0x008B842C
	public unsafe override void SetAiEnable(bool enable, string key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAiEnable"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetAiEnable_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetAiEnable_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetAiEnable_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->enable = enable;
			FString.CopyFrom((void*)(&ptr2->key), key);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF23 RID: 118563 RVA: 0x008BA2B0 File Offset: 0x008B84B0
	public unsafe override void TestChangeAi(string id)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TestChangeAi"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__TestChangeAi_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__TestChangeAi_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__TestChangeAi_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->id), id);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF24 RID: 118564 RVA: 0x008BA330 File Offset: 0x008B8530
	public unsafe override void LogReport(int logId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("LogReport"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__LogReport_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__LogReport_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__LogReport_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->logId = logId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF25 RID: 118565 RVA: 0x008BA3A8 File Offset: 0x008B85A8
	public unsafe override bool 逻辑主控()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("逻辑主控"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__逻辑主控_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__逻辑主控_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__逻辑主控_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601CF26 RID: 118566 RVA: 0x008BA420 File Offset: 0x008B8620
	public unsafe override bool 移动主控()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("移动主控"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__移动主控_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__移动主控_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__移动主控_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601CF27 RID: 118567 RVA: 0x008BA498 File Offset: 0x008B8698
	public unsafe override bool 检查状态机状态(ref TArray<string> states)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("检查状态机状态"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__检查状态机状态_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__检查状态机状态_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__检查状态机状态_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			TArray<string> tarray = states;
			if (tarray != null)
			{
				tarray.CopyTo(&ptr2->states, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601CF28 RID: 118568 RVA: 0x008BA52C File Offset: 0x008B872C
	public unsafe override void 切换状态机状态(ref TArray<string> states)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("切换状态机状态"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__切换状态机状态_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__切换状态机状态_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__切换状态机状态_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			TArray<string> tarray = states;
			if (tarray != null)
			{
				tarray.CopyTo(&ptr2->states, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF29 RID: 118569 RVA: 0x008BA5BC File Offset: 0x008B87BC
	public unsafe override bool GetCoolDownDone(int id)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCoolDownDone"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetCoolDownDone_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetCoolDownDone_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetCoolDownDone_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601CF2A RID: 118570 RVA: 0x008BA63C File Offset: 0x008B883C
	public unsafe override float GetCoolDownRemainTime(int id)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetCoolDownRemainTime"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetCoolDownRemainTime_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetCoolDownRemainTime_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetCoolDownRemainTime_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601CF2B RID: 118571 RVA: 0x008BA6BC File Offset: 0x008B88BC
	public unsafe override void SetCoolDown(int id, float cd)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCoolDown"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__SetCoolDown_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__SetCoolDown_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__SetCoolDown_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
			ptr2->cd = cd;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF2C RID: 118572 RVA: 0x008BA73C File Offset: 0x008B893C
	public unsafe override void InitCooldownEvent(int id, UKuroBooleanEventBinder eventBinder)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitCooldownEvent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__InitCooldownEvent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__InitCooldownEvent_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__InitCooldownEvent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
			*(&ptr2->eventBinder) = ((eventBinder != null) ? eventBinder.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF2D RID: 118573 RVA: 0x008BA7C8 File Offset: 0x008B89C8
	public unsafe override void StartCooldownTimer(int id, float duration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StartCooldownTimer"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__StartCooldownTimer_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__StartCooldownTimer_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__StartCooldownTimer_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->id = id;
			ptr2->duration = duration;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF2E RID: 118574 RVA: 0x008BA848 File Offset: 0x008B8A48
	public unsafe override void GetDebugStateMachine(ref TArray<FText> output)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugStateMachine"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetDebugStateMachine_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetDebugStateMachine_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetDebugStateMachine_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			TArray<FText> tarray = output;
			if (tarray != null)
			{
				tarray.CopyTo(&ptr2->output, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601CF2F RID: 118575 RVA: 0x008BA8D8 File Offset: 0x008B8AD8
	public unsafe override FText GetDebugText()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugText"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAiController.__GetDebugText_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAiController.__GetDebugText_FunctionParams*)ptr + 15L / (long)sizeof(TsAiController.__GetDebugText_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		FText result = new FText(&ptr2->__Result, true, true);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}
}
