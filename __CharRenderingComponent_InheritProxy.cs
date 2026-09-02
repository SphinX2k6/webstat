using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Components;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003917 RID: 14615
public class __CharRenderingComponent_InheritProxy : CharRenderingComponent
{
	// Token: 0x0601D814 RID: 120852 RVA: 0x008CFAF0 File Offset: 0x008CDCF0
	[NullableContext(1)]
	public __CharRenderingComponent_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CharRenderingComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D815 RID: 120853 RVA: 0x008CFB23 File Offset: 0x008CDD23
	protected __CharRenderingComponent_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D816 RID: 120854 RVA: 0x008CFB2C File Offset: 0x008CDD2C
	protected unsafe override void __CPPCALL_QuickInitAndAddData_Implementation(CharRenderingComponent.__QuickInitAndAddData_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		ASkeletalMeshActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ASkeletalMeshActor>(__Params->meshActor);
		__Params->__Result = base.QuickInitAndAddData_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D817 RID: 120855 RVA: 0x008CFB60 File Offset: 0x008CDD60
	protected unsafe override void __CPPCALL_QuickInitAndAddDataWithMeshComponent_Implementation(CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		UMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->meshComponent);
		__Params->__Result = base.QuickInitAndAddDataWithMeshComponent_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D818 RID: 120856 RVA: 0x008CFB94 File Offset: 0x008CDD94
	protected unsafe override void __CPPCALL_QuickInitAndAddDataGroup_Implementation(CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		ASkeletalMeshActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ASkeletalMeshActor>(__Params->meshActor);
		__Params->__Result = base.QuickInitAndAddDataGroup_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D819 RID: 120857 RVA: 0x008CFBC8 File Offset: 0x008CDDC8
	protected unsafe override void __CPPCALL_QuickInitAndAddDataGroupWithMeshComponent_Implementation(CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		UMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->meshComponent);
		__Params->__Result = base.QuickInitAndAddDataGroupWithMeshComponent_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D81A RID: 120858 RVA: 0x008CFBFC File Offset: 0x008CDDFC
	protected unsafe override void __CPPCALL_Init_Implementation(CharRenderingComponent.__Init_FunctionParams* __Params)
	{
		ECharacterRenderingType renderType = (ECharacterRenderingType)__Params->renderType;
		base.Init_Implementation(renderType);
	}

	// Token: 0x0601D81B RID: 120859 RVA: 0x008CFC18 File Offset: 0x008CDE18
	protected unsafe override void __CPPCALL_SetLogicOwner_Implementation(CharRenderingComponent.__SetLogicOwner_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->owner);
		base.SetLogicOwner_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D81C RID: 120860 RVA: 0x008CFC38 File Offset: 0x008CDE38
	protected unsafe override void __CPPCALL_AddComponent_Implementation(CharRenderingComponent.__AddComponent_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		base.AddComponent_Implementation(skelName, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D81D RID: 120861 RVA: 0x008CFC68 File Offset: 0x008CDE68
	protected unsafe override void __CPPCALL_AddComponentWithEmptyMaterial_Implementation(CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		base.AddComponentWithEmptyMaterial_Implementation(skelName, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D81E RID: 120862 RVA: 0x008CFC98 File Offset: 0x008CDE98
	protected unsafe override void __CPPCALL_RemoveComponent_Implementation(CharRenderingComponent.__RemoveComponent_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		base.RemoveComponent_Implementation(skelName);
	}

	// Token: 0x0601D81F RID: 120863 RVA: 0x008CFCBC File Offset: 0x008CDEBC
	protected unsafe override void __CPPCALL_AddComponentByCase_Implementation(CharRenderingComponent.__AddComponentByCase_FunctionParams* __Params)
	{
		ECharacterControllerCaseType caseType = (ECharacterControllerCaseType)__Params->caseType;
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		base.AddComponentByCase_Implementation(caseType, orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D820 RID: 120864 RVA: 0x008CFCE4 File Offset: 0x008CDEE4
	protected unsafe override void __CPPCALL_RemoveComponentByCase_Implementation(CharRenderingComponent.__RemoveComponentByCase_FunctionParams* __Params)
	{
		ECharacterControllerCaseType caseType = (ECharacterControllerCaseType)__Params->caseType;
		base.RemoveComponentByCase_Implementation(caseType);
	}

	// Token: 0x0601D821 RID: 120865 RVA: 0x008CFD00 File Offset: 0x008CDF00
	protected unsafe override void __CPPCALL_AddComponentInnerV2_Implementation(CharRenderingComponent.__AddComponentInnerV2_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->skeletalComp);
		base.AddComponentInnerV2_Implementation(skelName, orCreateUObjectByNativePointer, __Params->useEmptyMaterial);
	}

	// Token: 0x0601D822 RID: 120866 RVA: 0x008CFD34 File Offset: 0x008CDF34
	protected unsafe override void __CPPCALL_RemoveComponentInnerV2_Implementation(CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		base.RemoveComponentInnerV2_Implementation(skelName);
	}

	// Token: 0x0601D823 RID: 120867 RVA: 0x008CFD58 File Offset: 0x008CDF58
	protected unsafe override void __CPPCALL_GetSkeletalMeshComponent_Implementation(CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams* __Params)
	{
		string skelName = FString.ToString((void*)(&__Params->skelName));
		ref IntPtr ptr = ref *(&__Params->__Result);
		USkeletalMeshComponent skeletalMeshComponent_Implementation = base.GetSkeletalMeshComponent_Implementation(skelName);
		ptr = ((skeletalMeshComponent_Implementation != null) ? skeletalMeshComponent_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D824 RID: 120868 RVA: 0x008CFD90 File Offset: 0x008CDF90
	protected unsafe override void __CPPCALL_GetSkeletalMeshComponentBodyName_Implementation(CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->skeletalComp);
		__Params->__Result = base.GetSkeletalMeshComponentBodyName_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D825 RID: 120869 RVA: 0x008CFDB6 File Offset: 0x008CDFB6
	protected unsafe override void __CPPCALL_CheckInit_Implementation(CharRenderingComponent.__CheckInit_FunctionParams* __Params)
	{
		__Params->__Result = base.CheckInit_Implementation();
	}

	// Token: 0x0601D826 RID: 120870 RVA: 0x008CFDC4 File Offset: 0x008CDFC4
	protected unsafe override void __CPPCALL_SetDebug_Implementation(CharRenderingComponent.__SetDebug_FunctionParams* __Params)
	{
		base.SetDebug_Implementation(__Params->value);
	}

	// Token: 0x0601D827 RID: 120871 RVA: 0x008CFDD2 File Offset: 0x008CDFD2
	protected unsafe override void __CPPCALL_GetDebugInfo_Implementation(CharRenderingComponent.__GetDebugInfo_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		PD_MaterialDebug_C debugInfo_Implementation = base.GetDebugInfo_Implementation();
		ptr = ((debugInfo_Implementation != null) ? debugInfo_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D828 RID: 120872 RVA: 0x008CFDF0 File Offset: 0x008CDFF0
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(UActorComponent.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D829 RID: 120873 RVA: 0x008CFE10 File Offset: 0x008CE010
	protected unsafe override void __CPPCALL_GetInWater_Implementation(CharRenderingComponent.__GetInWater_FunctionParams* __Params)
	{
		__Params->__Result = base.GetInWater_Implementation(__Params->depthThreshold);
	}

	// Token: 0x0601D82A RID: 120874 RVA: 0x008CFE24 File Offset: 0x008CE024
	protected unsafe override void __CPPCALL_GetInAudioShr_Implementation(CharRenderingComponent.__GetInAudioShr_FunctionParams* __Params)
	{
		__Params->__Result = base.GetInAudioShr_Implementation();
	}

	// Token: 0x0601D82B RID: 120875 RVA: 0x008CFE32 File Offset: 0x008CE032
	protected override void __CPPCALL_ResetAllRenderingState_Implementation()
	{
		base.ResetAllRenderingState_Implementation();
	}

	// Token: 0x0601D82C RID: 120876 RVA: 0x008CFE3C File Offset: 0x008CE03C
	protected unsafe override void __CPPCALL_AddMaterialControllerDataGroup_Implementation(CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		__Params->__Result = base.AddMaterialControllerDataGroup_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D82D RID: 120877 RVA: 0x008CFE64 File Offset: 0x008CE064
	protected unsafe override void __CPPCALL_AddMaterialControllerDataGroupWithAnimObject_Implementation(CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		USkeletalMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->animObject);
		__Params->__Result = base.AddMaterialControllerDataGroupWithAnimObject_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D82E RID: 120878 RVA: 0x008CFE97 File Offset: 0x008CE097
	protected unsafe override void __CPPCALL_RemoveMaterialControllerDataGroup_Implementation(CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams* __Params)
	{
		base.RemoveMaterialControllerDataGroup_Implementation(__Params->handle);
	}

	// Token: 0x0601D82F RID: 120879 RVA: 0x008CFEA5 File Offset: 0x008CE0A5
	protected unsafe override void __CPPCALL_RemoveMaterialControllerDataGroupWithEnding_Implementation(CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams* __Params)
	{
		base.RemoveMaterialControllerDataGroupWithEnding_Implementation(__Params->handle);
	}

	// Token: 0x0601D830 RID: 120880 RVA: 0x008CFEB4 File Offset: 0x008CE0B4
	protected unsafe override void __CPPCALL_AddMaterialControllerDataWithAnimObject_Implementation(CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		USkeletalMeshComponent orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->animObject);
		UObject orCreateUObjectByNativePointer3 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->userData);
		__Params->__Result = base.AddMaterialControllerDataWithAnimObject_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, orCreateUObjectByNativePointer3);
	}

	// Token: 0x0601D831 RID: 120881 RVA: 0x008CFEF4 File Offset: 0x008CE0F4
	protected unsafe override void __CPPCALL_AddMaterialControllerData_Implementation(CharRenderingComponent.__AddMaterialControllerData_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->data);
		__Params->__Result = base.AddMaterialControllerData_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D832 RID: 120882 RVA: 0x008CFF1A File Offset: 0x008CE11A
	protected unsafe override void __CPPCALL_RemoveMaterialControllerData_Implementation(CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams* __Params)
	{
		base.RemoveMaterialControllerData_Implementation(__Params->handle);
	}

	// Token: 0x0601D833 RID: 120883 RVA: 0x008CFF28 File Offset: 0x008CE128
	protected unsafe override void __CPPCALL_SetEffectPause_Implementation(CharRenderingComponent.__SetEffectPause_FunctionParams* __Params)
	{
		base.SetEffectPause_Implementation(__Params->handle, __Params->paused);
	}

	// Token: 0x0601D834 RID: 120884 RVA: 0x008CFF3C File Offset: 0x008CE13C
	protected unsafe override void __CPPCALL_RemoveMaterialControllerDataWithEnding_Implementation(CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams* __Params)
	{
		base.RemoveMaterialControllerDataWithEnding_Implementation(__Params->handle);
	}

	// Token: 0x0601D835 RID: 120885 RVA: 0x008CFF4C File Offset: 0x008CE14C
	protected unsafe override void __CPPCALL_SetDitherEffect_Implementation(CharRenderingComponent.__SetDitherEffect_FunctionParams* __Params)
	{
		ECharacterDitherType ditherType = (ECharacterDitherType)__Params->ditherType;
		base.SetDitherEffect_Implementation(__Params->ditherRate, ditherType);
	}

	// Token: 0x0601D836 RID: 120886 RVA: 0x008CFF6D File Offset: 0x008CE16D
	protected unsafe override void __CPPCALL_SetDisableFightDither_Implementation(CharRenderingComponent.__SetDisableFightDither_FunctionParams* __Params)
	{
		base.SetDisableFightDither_Implementation(__Params->disable);
	}

	// Token: 0x0601D837 RID: 120887 RVA: 0x008CFF7B File Offset: 0x008CE17B
	protected override void __CPPCALL_SetDitherApplyAll_Implementation()
	{
		base.SetDitherApplyAll_Implementation();
	}

	// Token: 0x0601D838 RID: 120888 RVA: 0x008CFF83 File Offset: 0x008CE183
	protected override void __CPPCALL_SetDitherApplyHeadsOnly_Implementation()
	{
		base.SetDitherApplyHeadsOnly_Implementation();
	}

	// Token: 0x0601D839 RID: 120889 RVA: 0x008CFF8B File Offset: 0x008CE18B
	protected unsafe override void __CPPCALL_SetDitherUseHeadMaskHideEffect_Implementation(CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams* __Params)
	{
		base.SetDitherUseHeadMaskHideEffect_Implementation(__Params->enable);
	}

	// Token: 0x0601D83A RID: 120890 RVA: 0x008CFF99 File Offset: 0x008CE199
	protected override void __CPPCALL_TempRemoveDither_Implementation()
	{
		base.TempRemoveDither_Implementation();
	}

	// Token: 0x0601D83B RID: 120891 RVA: 0x008CFFA1 File Offset: 0x008CE1A1
	protected override void __CPPCALL_TempRecoverDither_Implementation()
	{
		base.TempRecoverDither_Implementation();
	}

	// Token: 0x0601D83C RID: 120892 RVA: 0x008CFFA9 File Offset: 0x008CE1A9
	protected unsafe override void __CPPCALL_GetOpacityConsiderVisibility_Implementation(CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams* __Params)
	{
		__Params->__Result = base.GetOpacityConsiderVisibility_Implementation();
	}

	// Token: 0x0601D83D RID: 120893 RVA: 0x008CFFB8 File Offset: 0x008CE1B8
	protected unsafe override void __CPPCALL_SetMaterialPropertyFloat_Implementation(CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams* __Params)
	{
		ECharacterBodySpecifiedType bodyType = (ECharacterBodySpecifiedType)__Params->bodyType;
		ECharacterSlotSpecifiedType slotType = (ECharacterSlotSpecifiedType)__Params->slotType;
		string propertyName = FString.ToString((void*)(&__Params->propertyName));
		base.SetMaterialPropertyFloat_Implementation(bodyType, __Params->sectionIndex, slotType, propertyName, __Params->value);
	}

	// Token: 0x0601D83E RID: 120894 RVA: 0x008CFFF8 File Offset: 0x008CE1F8
	protected unsafe override void __CPPCALL_SetMaterialPropertyColor_Implementation(CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams* __Params)
	{
		ECharacterBodySpecifiedType bodyType = (ECharacterBodySpecifiedType)__Params->bodyType;
		ECharacterSlotSpecifiedType slotType = (ECharacterSlotSpecifiedType)__Params->slotType;
		string propertyName = FString.ToString((void*)(&__Params->propertyName));
		base.SetMaterialPropertyColor_Implementation(bodyType, __Params->sectionIndex, slotType, propertyName, __Params->value);
	}

	// Token: 0x0601D83F RID: 120895 RVA: 0x008D0038 File Offset: 0x008CE238
	protected unsafe override void __CPPCALL_SetMaterialPropertyFloatV2_Implementation(CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams* __Params)
	{
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		base.SetMaterialPropertyFloatV2_Implementation(__Params->name, __Params->value, bodyType, slotType, meshPart);
	}

	// Token: 0x0601D840 RID: 120896 RVA: 0x008D006F File Offset: 0x008CE26F
	protected unsafe override void __CPPCALL_AddFloatUpdateParamPermanentByIndexV2_Implementation(CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams* __Params)
	{
		base.AddFloatUpdateParamPermanentByIndexV2_Implementation(__Params->name, __Params->value, __Params->bodyName, __Params->materialIndex);
	}

	// Token: 0x0601D841 RID: 120897 RVA: 0x008D0090 File Offset: 0x008CE290
	protected unsafe override void __CPPCALL_SetMaterialPropertyColorV2_Implementation(CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams* __Params)
	{
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		base.SetMaterialPropertyColorV2_Implementation(__Params->name, __Params->value, bodyType, slotType, meshPart);
	}

	// Token: 0x0601D842 RID: 120898 RVA: 0x008D00C8 File Offset: 0x008CE2C8
	protected unsafe override void __CPPCALL_SetMaterialReplaceV2_Implementation(CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams* __Params)
	{
		UMaterialInterface orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInterface>(__Params->material);
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		base.SetMaterialReplaceV2_Implementation(orCreateUObjectByNativePointer, bodyType, slotType, meshPart);
	}

	// Token: 0x0601D843 RID: 120899 RVA: 0x008D0100 File Offset: 0x008CE300
	protected unsafe override void __CPPCALL_RemoveExternalMaterialReplaceV2_Implementation(CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams* __Params)
	{
		EKuroCharBodySpecifiedType bodyType = (EKuroCharBodySpecifiedType)__Params->bodyType;
		EKuroCharSlotSpecifiedType slotType = (EKuroCharSlotSpecifiedType)__Params->slotType;
		EKuroCharMeshPart meshPart = (EKuroCharMeshPart)__Params->meshPart;
		base.RemoveExternalMaterialReplaceV2_Implementation(bodyType, slotType, meshPart);
	}

	// Token: 0x0601D844 RID: 120900 RVA: 0x008D012B File Offset: 0x008CE32B
	protected unsafe override void __CPPCALL_SetStarScarEnergy_Implementation(CharRenderingComponent.__SetStarScarEnergy_FunctionParams* __Params)
	{
		base.SetStarScarEnergy_Implementation(__Params->value);
	}

	// Token: 0x0601D845 RID: 120901 RVA: 0x008D0139 File Offset: 0x008CE339
	protected unsafe override void __CPPCALL_SetCapsuleDither_Implementation(CharRenderingComponent.__SetCapsuleDither_FunctionParams* __Params)
	{
		base.SetCapsuleDither_Implementation(__Params->value);
	}

	// Token: 0x0601D846 RID: 120902 RVA: 0x008D0147 File Offset: 0x008CE347
	protected unsafe override void __CPPCALL_SetDecalShadowEnabled_Implementation(CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams* __Params)
	{
		base.SetDecalShadowEnabled_Implementation(__Params->enable);
	}

	// Token: 0x0601D847 RID: 120903 RVA: 0x008D0155 File Offset: 0x008CE355
	protected override void __CPPCALL_DisableAllShadowByDecalShadowComponent_Implementation()
	{
		base.DisableAllShadowByDecalShadowComponent_Implementation();
	}

	// Token: 0x0601D848 RID: 120904 RVA: 0x008D015D File Offset: 0x008CE35D
	protected unsafe override void __CPPCALL_SetShouldCastShadow_Implementation(CharRenderingComponent.__SetShouldCastShadow_FunctionParams* __Params)
	{
		base.SetShouldCastShadow_Implementation(__Params->castShadow);
	}

	// Token: 0x0601D849 RID: 120905 RVA: 0x008D016B File Offset: 0x008CE36B
	protected unsafe override void __CPPCALL_SetEffectProgress_Implementation(CharRenderingComponent.__SetEffectProgress_FunctionParams* __Params)
	{
		base.SetEffectProgress_Implementation(__Params->progress, __Params->handleId);
	}

	// Token: 0x0601D84A RID: 120906 RVA: 0x008D017F File Offset: 0x008CE37F
	protected unsafe override void __CPPCALL_SetEffectGroupProgress_Implementation(CharRenderingComponent.__SetEffectGroupProgress_FunctionParams* __Params)
	{
		base.SetEffectGroupProgress_Implementation(__Params->progress, __Params->groupHandleId);
	}

	// Token: 0x0601D84B RID: 120907 RVA: 0x008D0193 File Offset: 0x008CE393
	protected override void __CPPCALL_RefreshMaterialController_Implementation()
	{
		base.RefreshMaterialController_Implementation();
	}

	// Token: 0x0601D84C RID: 120908 RVA: 0x008D019B File Offset: 0x008CE39B
	protected override void __CPPCALL_Destroy_Implementation()
	{
		base.Destroy_Implementation();
	}

	// Token: 0x0601D84D RID: 120909 RVA: 0x008D01A3 File Offset: 0x008CE3A3
	protected override void __CPPCALL_OnFinalizedLevelSequence_Implementation()
	{
		base.OnFinalizedLevelSequence_Implementation();
	}

	// Token: 0x0601D84E RID: 120910 RVA: 0x008D01AB File Offset: 0x008CE3AB
	protected unsafe override void __CPPCALL_ShouldTickAfterGoDown_Implementation(CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams* __Params)
	{
		__Params->__Result = base.ShouldTickAfterGoDown_Implementation();
	}

	// Token: 0x0601D84F RID: 120911 RVA: 0x008D01B9 File Offset: 0x008CE3B9
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D850 RID: 120912 RVA: 0x008D01C1 File Offset: 0x008CE3C1
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(UActorComponent.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D851 RID: 120913 RVA: 0x008D01CF File Offset: 0x008CE3CF
	protected unsafe override void __CPPCALL_ReceiveSeqTick_Implementation(CharRenderingComponent.__ReceiveSeqTick_FunctionParams* __Params)
	{
		base.ReceiveSeqTick_Implementation(__Params->deltaSeconds);
	}
}
