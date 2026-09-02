using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200395F RID: 14687
public class __SceneInteractionActor_InheritProxy : SceneInteractionActor
{
	// Token: 0x0601D945 RID: 121157 RVA: 0x008D38A4 File Offset: 0x008D1AA4
	[NullableContext(1)]
	public __SceneInteractionActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneInteractionActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D946 RID: 121158 RVA: 0x008D38D7 File Offset: 0x008D1AD7
	protected __SceneInteractionActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D947 RID: 121159 RVA: 0x008D38E0 File Offset: 0x008D1AE0
	protected unsafe override void __CPPCALL_SetOverrideSeqBindActor_Implementation(SceneInteractionActor.__SetOverrideSeqBindActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actorToBind);
		string bindingName = FString.ToString((void*)(&__Params->bindingName));
		base.SetOverrideSeqBindActor_Implementation(orCreateUObjectByNativePointer, bindingName);
	}

	// Token: 0x0601D948 RID: 121160 RVA: 0x008D3910 File Offset: 0x008D1B10
	protected unsafe override void __CPPCALL_UnsetOverrideSeqBindActor_Implementation(SceneInteractionActor.__UnsetOverrideSeqBindActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actorToUnbind);
		string bindingName = FString.ToString((void*)(&__Params->bindingName));
		base.UnsetOverrideSeqBindActor_Implementation(orCreateUObjectByNativePointer, bindingName);
	}

	// Token: 0x0601D949 RID: 121161 RVA: 0x008D393E File Offset: 0x008D1B3E
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D94A RID: 121162 RVA: 0x008D3948 File Offset: 0x008D1B48
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D94B RID: 121163 RVA: 0x008D3968 File Offset: 0x008D1B68
	protected override void __CPPCALL_AddNewState_Implementation()
	{
		base.AddNewState_Implementation();
	}

	// Token: 0x0601D94C RID: 121164 RVA: 0x008D3970 File Offset: 0x008D1B70
	protected override void __CPPCALL_AddNewEffect_Implementation()
	{
		base.AddNewEffect_Implementation();
	}

	// Token: 0x0601D94D RID: 121165 RVA: 0x008D3978 File Offset: 0x008D1B78
	protected override void __CPPCALL_AddNewEndEffect_Implementation()
	{
		base.AddNewEndEffect_Implementation();
	}

	// Token: 0x0601D94E RID: 121166 RVA: 0x008D3980 File Offset: 0x008D1B80
	protected override void __CPPCALL_UpdateTimeDilation_Implementation()
	{
		base.UpdateTimeDilation_Implementation();
	}

	// Token: 0x0601D94F RID: 121167 RVA: 0x008D3988 File Offset: 0x008D1B88
	protected unsafe override void __CPPCALL_CheckAllEffectPlaying_Implementation(SceneInteractionActor.__CheckAllEffectPlaying_FunctionParams* __Params)
	{
		__Params->__Result = base.CheckAllEffectPlaying_Implementation();
	}

	// Token: 0x0601D950 RID: 121168 RVA: 0x008D3998 File Offset: 0x008D1B98
	protected unsafe override void __CPPCALL_PlayKuroSkeletalMeshDestruction_Implementation(SceneInteractionActor.__PlayKuroSkeletalMeshDestruction_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		base.PlayKuroSkeletalMeshDestruction_Implementation(orCreateUObjectByNativePointer, __Params->isJumpToEnd);
	}

	// Token: 0x0601D951 RID: 121169 RVA: 0x008D39C0 File Offset: 0x008D1BC0
	protected unsafe override void __CPPCALL_OverrideKuroDestructibleActorPhysicsVelocity_Implementation(SceneInteractionActor.__OverrideKuroDestructibleActorPhysicsVelocity_FunctionParams* __Params)
	{
		AKuroDestructibleActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AKuroDestructibleActor>(__Params->skeletalMeshDestruction);
		base.OverrideKuroDestructibleActorPhysicsVelocity_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D952 RID: 121170 RVA: 0x008D39E0 File Offset: 0x008D1BE0
	protected unsafe override void __CPPCALL_GetActiveSequenceRemainTime_Implementation(SceneInteractionActor.__GetActiveSequenceRemainTime_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->sequence);
		__Params->__Result = base.GetActiveSequenceRemainTime_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D953 RID: 121171 RVA: 0x008D3A06 File Offset: 0x008D1C06
	protected unsafe override void __CPPCALL_ApplyAnimOptimizationParams_Implementation(SceneInteractionActor.__ApplyAnimOptimizationParams_FunctionParams* __Params)
	{
		base.ApplyAnimOptimizationParams_Implementation(__Params->bUseDistanceMap);
	}

	// Token: 0x0601D954 RID: 121172 RVA: 0x008D3A14 File Offset: 0x008D1C14
	protected override void __CPPCALL_PendingPlayStateEffect_Implementation()
	{
		base.PendingPlayStateEffect_Implementation();
	}

	// Token: 0x0601D955 RID: 121173 RVA: 0x008D3A1C File Offset: 0x008D1C1C
	protected override void __CPPCALL_RemovePendingStateEffectTick_Implementation()
	{
		base.RemovePendingStateEffectTick_Implementation();
	}

	// Token: 0x0601D956 RID: 121174 RVA: 0x008D3A24 File Offset: 0x008D1C24
	protected override void __CPPCALL_PendingPlayCrossStateEffect_Implementation()
	{
		base.PendingPlayCrossStateEffect_Implementation();
	}

	// Token: 0x0601D957 RID: 121175 RVA: 0x008D3A2C File Offset: 0x008D1C2C
	protected override void __CPPCALL_RemovePendingCrossStateEffectTick_Implementation()
	{
		base.RemovePendingCrossStateEffectTick_Implementation();
	}

	// Token: 0x0601D958 RID: 121176 RVA: 0x008D3A34 File Offset: 0x008D1C34
	protected override void __CPPCALL_PendingPlayTagEffect_Implementation()
	{
		base.PendingPlayTagEffect_Implementation();
	}

	// Token: 0x0601D959 RID: 121177 RVA: 0x008D3A3C File Offset: 0x008D1C3C
	protected override void __CPPCALL_RemovePendingTagEffectTick_Implementation()
	{
		base.RemovePendingTagEffectTick_Implementation();
	}

	// Token: 0x0601D95A RID: 121178 RVA: 0x008D3A44 File Offset: 0x008D1C44
	protected unsafe override void __CPPCALL_PostAutoMergeEvent_Implementation(SceneInteractionActor.__PostAutoMergeEvent_FunctionParams* __Params)
	{
		string eventName = FString.ToString((void*)(&__Params->eventName));
		base.PostAutoMergeEvent_Implementation(eventName, __Params->tagId, __Params->follow);
	}

	// Token: 0x0601D95B RID: 121179 RVA: 0x008D3A74 File Offset: 0x008D1C74
	protected unsafe override void __CPPCALL_PostTagEvent_Implementation(SceneInteractionActor.__PostTagEvent_FunctionParams* __Params)
	{
		string eventName = FString.ToString((void*)(&__Params->eventName));
		base.PostTagEvent_Implementation(eventName, __Params->tag, __Params->follow);
	}

	// Token: 0x0601D95C RID: 121180 RVA: 0x008D3AA1 File Offset: 0x008D1CA1
	protected unsafe override void __CPPCALL_StopTagAkEvent_Implementation(SceneInteractionActor.__StopTagAkEvent_FunctionParams* __Params)
	{
		base.StopTagAkEvent_Implementation(__Params->tag);
	}

	// Token: 0x0601D95D RID: 121181 RVA: 0x008D3AAF File Offset: 0x008D1CAF
	protected unsafe override void __CPPCALL_UpdateProjectionActorTransform_Implementation(SceneInteractionActor.__UpdateProjectionActorTransform_FunctionParams* __Params)
	{
		base.UpdateProjectionActorTransform_Implementation(__Params->transform);
	}

	// Token: 0x0601D95E RID: 121182 RVA: 0x008D3AC0 File Offset: 0x008D1CC0
	protected unsafe override void __CPPCALL_AddMatrialDataForChildrenActor_Implementation(SceneInteractionActor.__AddMatrialDataForChildrenActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		ItemMaterialControllerActorData orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ItemMaterialControllerActorData>(__Params->materialData);
		base.AddMatrialDataForChildrenActor_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D95F RID: 121183 RVA: 0x008D3AED File Offset: 0x008D1CED
	protected override void __CPPCALL_RemoveActorProjection_Implementation()
	{
		base.RemoveActorProjection_Implementation();
	}

	// Token: 0x0601D960 RID: 121184 RVA: 0x008D3AF5 File Offset: 0x008D1CF5
	protected override void __CPPCALL_DestroySelf_Implementation()
	{
		base.DestroySelf_Implementation();
	}

	// Token: 0x0601D961 RID: 121185 RVA: 0x008D3AFD File Offset: 0x008D1CFD
	protected unsafe override void __CPPCALL_ResetTagActorHide_Implementation(SceneInteractionActor.__ResetTagActorHide_FunctionParams* __Params)
	{
		base.ResetTagActorHide_Implementation(__Params->tag);
	}

	// Token: 0x0601D962 RID: 121186 RVA: 0x008D3B0C File Offset: 0x008D1D0C
	protected unsafe override void __CPPCALL_GetDirectorBySequence_Implementation(SceneInteractionActor.__GetDirectorBySequence_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->sequence);
		ref IntPtr ptr = ref *(&__Params->__Result);
		ALevelSequenceActor directorBySequence_Implementation = base.GetDirectorBySequence_Implementation(orCreateUObjectByNativePointer);
		ptr = ((directorBySequence_Implementation != null) ? directorBySequence_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D963 RID: 121187 RVA: 0x008D3B41 File Offset: 0x008D1D41
	protected unsafe override void __CPPCALL_StopExtraEffectOnTagsChange_Implementation(SceneInteractionActor.__StopExtraEffectOnTagsChange_FunctionParams* __Params)
	{
		base.StopExtraEffectOnTagsChange_Implementation(__Params->tag);
	}

	// Token: 0x0601D964 RID: 121188 RVA: 0x008D3B4F File Offset: 0x008D1D4F
	protected override void __CPPCALL_TryStopCurrentState_Implementation()
	{
		base.TryStopCurrentState_Implementation();
	}

	// Token: 0x0601D965 RID: 121189 RVA: 0x008D3B57 File Offset: 0x008D1D57
	protected override void __CPPCALL_使用字段值切换状态_Implementation()
	{
		base.使用字段值切换状态_Implementation();
	}

	// Token: 0x0601D966 RID: 121190 RVA: 0x008D3B5F File Offset: 0x008D1D5F
	protected override void __CPPCALL_ChangeState1_Implementation()
	{
		base.ChangeState1_Implementation();
	}

	// Token: 0x0601D967 RID: 121191 RVA: 0x008D3B67 File Offset: 0x008D1D67
	protected override void __CPPCALL_ChangeState2_Implementation()
	{
		base.ChangeState2_Implementation();
	}

	// Token: 0x0601D968 RID: 121192 RVA: 0x008D3B6F File Offset: 0x008D1D6F
	protected override void __CPPCALL_ChangeState3_Implementation()
	{
		base.ChangeState3_Implementation();
	}

	// Token: 0x0601D969 RID: 121193 RVA: 0x008D3B77 File Offset: 0x008D1D77
	protected override void __CPPCALL_ChangeState4_Implementation()
	{
		base.ChangeState4_Implementation();
	}

	// Token: 0x0601D96A RID: 121194 RVA: 0x008D3B7F File Offset: 0x008D1D7F
	protected override void __CPPCALL_ChangeState5_Implementation()
	{
		base.ChangeState5_Implementation();
	}

	// Token: 0x0601D96B RID: 121195 RVA: 0x008D3B87 File Offset: 0x008D1D87
	protected override void __CPPCALL_ChangeState6_Implementation()
	{
		base.ChangeState6_Implementation();
	}

	// Token: 0x0601D96C RID: 121196 RVA: 0x008D3B8F File Offset: 0x008D1D8F
	protected override void __CPPCALL_ChangeState7_Implementation()
	{
		base.ChangeState7_Implementation();
	}

	// Token: 0x0601D96D RID: 121197 RVA: 0x008D3B97 File Offset: 0x008D1D97
	protected override void __CPPCALL_ChangeState8_Implementation()
	{
		base.ChangeState8_Implementation();
	}

	// Token: 0x0601D96E RID: 121198 RVA: 0x008D3B9F File Offset: 0x008D1D9F
	protected override void __CPPCALL_模拟Tag添加_Implementation()
	{
		base.模拟Tag添加_Implementation();
	}

	// Token: 0x0601D96F RID: 121199 RVA: 0x008D3BA7 File Offset: 0x008D1DA7
	protected override void __CPPCALL_模拟Tag移除_Implementation()
	{
		base.模拟Tag移除_Implementation();
	}

	// Token: 0x0601D970 RID: 121200 RVA: 0x008D3BAF File Offset: 0x008D1DAF
	protected override void __CPPCALL_重置_Implementation()
	{
		base.重置_Implementation();
	}
}
