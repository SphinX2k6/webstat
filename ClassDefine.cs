using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200007F RID: 127
public class ClassDefine : IStaticVariableResetter
{
	// Token: 0x06000309 RID: 777 RVA: 0x00010C6C File Offset: 0x0000EE6C
	static ClassDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ClassDefine.CreateStaticDefaultValue), new Action(ClassDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0001284C File Offset: 0x00010A4C
	[NullableContext(1)]
	private unsafe static void add(string key, ClassDefine.EType type, string path, ETypeLoadKind loadKind)
	{
		if (ClassDefine.typeDefined.ContainsKey(key))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Resource;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "类型定义重复";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("名字", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("类型", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("原路径", ClassDefine.typeDefined[key].Item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("新路径", path);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		ClassDefine.typeDefined[key] = new ValueTuple<ClassDefine.EType, string, ETypeLoadKind>(type, path, loadKind);
	}

	// Token: 0x0600030B RID: 779 RVA: 0x00012914 File Offset: 0x00010B14
	public static void CreateStaticDefaultValue()
	{
		ClassDefine.typeDefined = new Dictionary<string, ValueTuple<ClassDefine.EType, string, ETypeLoadKind>>();
		foreach (KeyValuePair<string, ValueTuple<string, ETypeLoadKind>> keyValuePair in ClassDefine.classDefined)
		{
			string key = keyValuePair.Key;
			ValueTuple<string, ETypeLoadKind> value = keyValuePair.Value;
			ClassDefine.add(key, ClassDefine.EType.Class, value.Item1, value.Item2);
		}
		foreach (KeyValuePair<string, ValueTuple<string, ETypeLoadKind>> keyValuePair2 in ClassDefine.structDefined)
		{
			string key2 = keyValuePair2.Key;
			ValueTuple<string, ETypeLoadKind> value2 = keyValuePair2.Value;
			ClassDefine.add(key2, ClassDefine.EType.Struct, value2.Item1, value2.Item2);
		}
		foreach (KeyValuePair<string, ValueTuple<string, ETypeLoadKind>> keyValuePair3 in ClassDefine.enumDefined)
		{
			string key3 = keyValuePair3.Key;
			ValueTuple<string, ETypeLoadKind> value3 = keyValuePair3.Value;
			ClassDefine.add(key3, ClassDefine.EType.Enum, value3.Item1, value3.Item2);
		}
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00012A48 File Offset: 0x00010C48
	public static void ResetStaticDefaultValue()
	{
		ClassDefine.typeDefined = null;
	}

	// Token: 0x04000249 RID: 585
	[Nullable(new byte[]
	{
		1,
		1,
		0,
		1
	})]
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<string, ValueTuple<string, ETypeLoadKind>> classDefined = new Dictionary<string, ValueTuple<string, ETypeLoadKind>>
	{
		{
			"DataTableUtil_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/UI/Framework/DataTableUtil.DataTableUtil_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SequenceData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Manager/BP_SequenceData.BP_SequenceData_C", ETypeLoadKind.Preload)
		},
		{
			"BP_EventManager_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C", ETypeLoadKind.Preload)
		},
		{
			"BP_FightManager_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/Fight/Manager/BP_FightManager.BP_FightManager_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BaseNPC_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/NPC/Common/BP_BaseNPC.BP_BaseNPC_C", ETypeLoadKind.Preload)
		},
		{
			"ABP_MultiStateNPC_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/NPC/Common/ABP_MultiStateNPC.ABP_MultiStateNPC_C", ETypeLoadKind.Preload)
		},
		{
			"BPI_NpcEcological_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/NPC/Common/BPI_NpcEcological.BPI_NpcEcological_C", ETypeLoadKind.Preload)
		},
		{
			"TsBaseCharacter_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Character/TsBaseCharacter.TsBaseCharacter_C", ETypeLoadKind.Preload)
		},
		{
			"PD_CharacterControllerData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerData.PD_CharacterControllerData_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BasePathLine_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/PathLine/BP_BasePathLine.BP_BasePathLine_C", ETypeLoadKind.Preload)
		},
		{
			"BP_MovePathLine_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/PathLine/BP_MovePathLine.BP_MovePathLine_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BasePathLine_Edgewall_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/PathLine/Pathline_EdgeWall/BP_BasePathLine_Edgewall.BP_BasePathLine_Edgewall_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CineCamera_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/BP_CineCamera.BP_CineCamera_C", ETypeLoadKind.Preload)
		},
		{
			"BP_StreamingSourceActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/StreamingSource/BP_StreamingSourceActor.BP_StreamingSourceActor_C", ETypeLoadKind.Preload)
		},
		{
			"BPL_CameraUtility_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/BPL_CameraUtility.BPL_CameraUtility_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CameraDrivenAutoFlightData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Input/Blueprints/BP_CameraDrivenAutoFlightData.BP_CameraDrivenAutoFlightData_C", ETypeLoadKind.Preload)
		},
		{
			"BP_FightCameraConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/BP_FightCameraConfig.BP_FightCameraConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_PhotographCameraConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/BP_PhotographCameraConfig.BP_PhotographCameraConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CameraShot_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Interaction/BP_CameraShot.BP_CameraShot_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SoarConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/Movement/BP_SoarConfig.BP_SoarConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_ScreenEffectSystem_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/ScreenEffect/BP_ScreenEffectSystem.BP_ScreenEffectSystem_C", ETypeLoadKind.Preload)
		},
		{
			"EffectScreenPlayData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/EffectScreenPlayData.EffectScreenPlayData_C", ETypeLoadKind.Preload)
		},
		{
			"BPI_CreatureInterface_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/CreatureTools/BPI_CreatureInterface.BPI_CreatureInterface_C", ETypeLoadKind.Preload)
		},
		{
			"TsParkourCheckPoint_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/LevelGamePlay/Parkour/TsParkourCheckPoint.TsParkourCheckPoint_C", ETypeLoadKind.Preload)
		},
		{
			"BP_GlobalGI_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI.BP_GlobalGI_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Cinematics_Tick_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_Cinematics_Tick.BP_Cinematics_Tick_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Fx_WayFinding_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_WayFinding.BP_Fx_WayFinding_C", ETypeLoadKind.Async)
		},
		{
			"TsSkeletalObserver_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/SkeletalObserver/TsSkeletalObserver.TsSkeletalObserver_C", ETypeLoadKind.Preload)
		},
		{
			"PD_WeaponLevelMaterialDatas_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/PD_WeaponLevelMaterialDatas.PD_WeaponLevelMaterialDatas_C", ETypeLoadKind.Preload)
		},
		{
			"CharRenderingComponent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/Manager/CharRenderingComponent.CharRenderingComponent_C", ETypeLoadKind.Preload)
		},
		{
			"BP_UiCameraAnimation_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/UI/NewModule/UiCameraAnimation/BP_UiCameraAnimation.BP_UiCameraAnimation_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiSceneRoleActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneRoleActor.TsUiSceneRoleActor_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiSceneDangoActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiSceneDangoActor.TsUiSceneDangoActor_C", ETypeLoadKind.Preload)
		},
		{
			"BulletCommonDataAsset_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/Fight/Bullet/BulletCommonDataAsset.BulletCommonDataAsset_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BasePathLineBullet_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/PathLine/PathLine_Bullet/BP_BasePathLineBullet.BP_BasePathLineBullet_C", ETypeLoadKind.Preload)
		},
		{
			"BPL_Fight_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/Fight/BPL_Fight.BPL_Fight_C", ETypeLoadKind.Preload)
		},
		{
			"BulletLogicType_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/Fight/BulletLogicType.BulletLogicType_C", ETypeLoadKind.Preload)
		},
		{
			"PD_NpcSetupData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/Npc/PD_NpcSetupData.PD_NpcSetupData_C", ETypeLoadKind.Preload)
		},
		{
			"TsAiController_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AI/Controller/TsAiController.TsAiController_C", ETypeLoadKind.Preload)
		},
		{
			"BPI_Animation_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/BPI_Animation.BPI_Animation_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KuroProjectilePathTracer_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/KuroProjectilePathTracer/BP_KuroProjectilePathTracer.BP_KuroProjectilePathTracer_C", ETypeLoadKind.Preload)
		},
		{
			"GA_Base_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Abilities/GA/GA_Base.GA_Base_C", ETypeLoadKind.Preload)
		},
		{
			"Ga_Passive_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Abilities/GA/GA_Passive.GA_Passive_C", ETypeLoadKind.Preload)
		},
		{
			"TsCharacterDebugComponent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Component/TsCharacterDebugComponent.TsCharacterDebugComponent_C", ETypeLoadKind.Preload)
		},
		{
			"SimpleNpcFlowComponent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/NPC/SimpleNpcFlow/SimpleNpcFlowComponent.SimpleNpcFlowComponent_C", ETypeLoadKind.Preload)
		},
		{
			"TsSimpleNpc_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/TsSimpleNpc.TsSimpleNpc_C", ETypeLoadKind.Preload)
		},
		{
			"PD_CharacterControllerDataGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerDataGroup.PD_CharacterControllerDataGroup_C", ETypeLoadKind.Preload)
		},
		{
			"BP_MaterialControllerRenderActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/MaterialController/BP_MaterialControllerRenderActor.BP_MaterialControllerRenderActor_C", ETypeLoadKind.Preload)
		},
		{
			"PD_MaterialDebug_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/Components/PD_MaterialDebug.PD_MaterialDebug_C", ETypeLoadKind.Preload)
		},
		{
			"PDA_GlobalRenderDataReference_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/RenderData/PDA_GlobalRenderDataReference.PDA_GlobalRenderDataReference_C", ETypeLoadKind.Preload)
		},
		{
			"BP_EffectActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Effect/BP_EffectActor.BP_EffectActor_C", ETypeLoadKind.Preload)
		},
		{
			"BP_EffectPreview_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Effect/BP_EffectPreview.BP_EffectPreview_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyEffect_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyEffect.AnimNotifyEffect_C", ETypeLoadKind.Preload)
		},
		{
			"EffectModelGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelGroup.EffectModelGroup_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyAddMaterialControllerData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMaterialControllerData.AnimNotifyAddMaterialControllerData_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyAddMaterialControllerDataGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMaterialControllerDataGroup.AnimNotifyAddMaterialControllerDataGroup_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyAddMeshMaterialControllerData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMeshMaterialControllerData.AnimNotifyAddMeshMaterialControllerData_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyAddMeshMaterialControllerDataGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMeshMaterialControllerDataGroup.AnimNotifyAddMeshMaterialControllerDataGroup_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyAddMotionVertexOffset_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMotionVertexOffset.AnimNotifyAddMotionVertexOffset_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyAddTransferEffect_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddTransferEffect.AnimNotifyAddTransferEffect_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyStateAddMaterialControllerData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerData.AnimNotifyStateAddMaterialControllerData_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyStateAddMaterialControllerDataGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerDataGroup.AnimNotifyStateAddMaterialControllerDataGroup_C", ETypeLoadKind.Preload)
		},
		{
			"EffectModelSkeletalMesh_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelSkeletalMesh.EffectModelSkeletalMesh_C", ETypeLoadKind.Preload)
		},
		{
			"EffectModelPostProcess_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Effect/Data/EffectModelPostProcess.EffectModelPostProcess_C", ETypeLoadKind.Async)
		},
		{
			"AnimNotifyStateEffect_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateEffect.AnimNotifyStateEffect_C", ETypeLoadKind.Preload)
		},
		{
			"AnimNotifyStateGhost_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateGhost.AnimNotifyStateGhost_C", ETypeLoadKind.Preload)
		},
		{
			"TsRecordEffect_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Recorder/TsRecordEffect.TsRecordEffect_C", ETypeLoadKind.Preload)
		},
		{
			"TsRecordGameplayCue_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Recorder/TsRecordGameplayCue.TsRecordGameplayCue_C", ETypeLoadKind.Preload)
		},
		{
			"TsAnimNotifyStateAddCharRendering_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddCharRendering.TsAnimNotifyStateAddCharRendering_C", ETypeLoadKind.Preload)
		},
		{
			"TsAnimNotifyStateAddMaterialController_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Recorder/TsAnimNotifyStateAddMaterialController.TsAnimNotifyStateAddMaterialController_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Weather_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/Data/Weather/BP_Weather.BP_Weather_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Wwise_AudioSpectrum_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Audio/BP_Wwise_AudioSpectrum.BP_Wwise_AudioSpectrum_C", ETypeLoadKind.Preload)
		},
		{
			"BP_PartHitEffect_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/BP_PartHitEffect.BP_PartHitEffect_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SceneCapture_3To2_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/SceneCapture_3To2/BP_SceneCapture_3To2.BP_SceneCapture_3To2_C", ETypeLoadKind.Preload)
		},
		{
			"ItemMaterialDataMap_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialDataMap.ItemMaterialDataMap_C", ETypeLoadKind.Preload)
		},
		{
			"ItemMaterialControllerActorData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialControllerActorData.ItemMaterialControllerActorData_C", ETypeLoadKind.Preload)
		},
		{
			"BulletCampType_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/Fight/BulletCampType.BulletCampType_C", ETypeLoadKind.Preload)
		},
		{
			"PDA_AudioVisualizationGlobalConfigs_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/AudioVisualization/PDA_AudioVisualizationGlobalConfigs.PDA_AudioVisualizationGlobalConfigs_C", ETypeLoadKind.Preload)
		},
		{
			"PDA_FoliageClusteredEffectConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Effect/ClusteredStuff/PDA_FoliageClusteredEffectConfig.PDA_FoliageClusteredEffectConfig_C", ETypeLoadKind.Preload)
		},
		{
			"TsEntityDebugInfoManager_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/World/Debug/TsEntityDebugInfoManager.TsEntityDebugInfoManager_C", ETypeLoadKind.Preload)
		},
		{
			"TsPhotographer_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/Photograph/TsPhotographer.TsPhotographer_C", ETypeLoadKind.Preload)
		},
		{
			"BPI_AnimalEcological_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/NPC/Animal/BPI_AnimalEcological.BPI_AnimalEcological_C", ETypeLoadKind.Preload)
		},
		{
			"SceneEffectStatePostVolume_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Effect/Scene/SceneEffectStatePostVolume.SceneEffectStatePostVolume_C", ETypeLoadKind.Preload)
		},
		{
			"BP_StartupPlayerController_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/BP_StartupPlayerController.BP_StartupPlayerController_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KuroDestructibleActor_Stone_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/Destructible/3_0/BP_KuroDestructibleActor_Stone.BP_KuroDestructibleActor_Stone_C", ETypeLoadKind.Async)
		},
		{
			"BP_KuroMotorcycleFreezeWaterComponent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Vehicle/Motor/Component/BP_KuroMotorcycleFreezeWaterComponent.BP_KuroMotorcycleFreezeWaterComponent_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KuroTrackTargetWhileRotate_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/Physics/FauxPhysics/BP_KuroTrackTargetWhileRotate.BP_KuroTrackTargetWhileRotate_C", ETypeLoadKind.Async)
		},
		{
			"BP_FollowShooterDeadEyeConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/FollowShooter/DeadEye/BP_FollowShooterDeadEyeConfig.BP_FollowShooterDeadEyeConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_KuroMasterSeqEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Manager/BP_KuroMasterSeqEvent.BP_KuroMasterSeqEvent_C", ETypeLoadKind.Async)
		},
		{
			"BP_SM_ConditionTimer_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTimer.BP_SM_ConditionTimer_C", ETypeLoadKind.Preload)
		},
		{
			"TsEffectActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Effect/TsEffectActor.TsEffectActor_C", ETypeLoadKind.Preload)
		},
		{
			"BPI_EffectInterface_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Effect/BPI_EffectInterface.BPI_EffectInterface_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionAddBuff_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddBuff.BP_SM_ActionAddBuff_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionRemoveBuff_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveBuff.BP_SM_ActionRemoveBuff_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionResetStatus_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetStatus.BP_SM_ActionResetStatus_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionEnterFight_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionEnterFight.BP_SM_ActionEnterFight_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionChangeInstState_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionChangeInstState.BP_SM_ActionChangeInstState_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionCue_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCue.BP_SM_ActionCue_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionActivatePart_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivatePart.BP_SM_ActionActivatePart_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionActivateSkillGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivateSkillGroup.BP_SM_ActionActivateSkillGroup_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionDispatchEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchEvent.BP_SM_ActionDispatchEvent_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionResetPart_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionResetPart.BP_SM_ActionResetPart_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionStopMontage_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionStopMontage.BP_SM_ActionStopMontage_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionExitHit_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionExitHit.BP_SM_ActionExitHit_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionSendGameplayEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSendGameplayEvent.BP_SM_ActionSendGameplayEvent_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionSetRageFullAttribute_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionSetRageFullAttribute.BP_SM_ActionSetRageFullAttribute_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionAddTagCount_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddTagCount.BP_SM_ActionAddTagCount_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionRemoveTagCount_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveTagCount.BP_SM_ActionRemoveTagCount_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionDispatchGameEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionDispatchGameEvent.BP_SM_ActionDispatchGameEvent_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ActionCameraLockOn_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionCameraLockOn.BP_SM_ActionCameraLockOn_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskSkill_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkill.BP_SM_TaskSkill_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskSkillByName_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkillByName.BP_SM_TaskSkillByName_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskLeaveFight_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskLeaveFight.BP_SM_TaskLeaveFight_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskMontage_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMontage.BP_SM_TaskMontage_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskRandomMontage_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskRandomMontage.BP_SM_TaskRandomMontage_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskMoveToTarget_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMoveToTarget.BP_SM_TaskMoveToTarget_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskPatrol_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskPatrol.BP_SM_TaskPatrol_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskBeHitMontage_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskBeHitMontage.BP_SM_TaskBeHitMontage_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskGroupPatrol_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPatrol.BP_SM_TaskGroupPatrol_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_TaskGroupPerform_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskGroupPerform.BP_SM_TaskGroupPerform_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateBuff_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBuff.BP_SM_BindStateBuff_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateTag_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateTag.BP_SM_BindStateTag_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateAiHateConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiHateConfig.BP_SM_BindStateAiHateConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateAiSenseEnable_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateAiSenseEnable.BP_SM_BindStateAiSenseEnable_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateCue_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCue.BP_SM_BindStateCue_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateDeathMontage_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontage.BP_SM_BindStateDeathMontage_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateDeathMontageByTag_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontageByTag.BP_SM_BindStateDeathMontageByTag_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateDisableActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableActor.BP_SM_BindStateDisableActor_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateBoneCollision_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneCollision.BP_SM_BindStateBoneCollision_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateBoneVisible_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBoneVisible.BP_SM_BindStateBoneVisible_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateMeshVisible_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateMeshVisible.BP_SM_BindStateMeshVisible_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStatePartPanelVisible_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePartPanelVisible.BP_SM_BindStatePartPanelVisible_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateSkillCounter_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateSkillCounter.BP_SM_BindStateSkillCounter_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateDelaySuicide_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDelaySuicide.BP_SM_BindStateDelaySuicide_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateCollisionChannel_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateCollisionChannel.BP_SM_BindStateCollisionChannel_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStateDisableCollision_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableCollision.BP_SM_BindStateDisableCollision_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionTrue_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTrue.BP_SM_ConditionTrue_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionAttribute_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttribute.BP_SM_ConditionAttribute_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionAttributeRate_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionAttributeRate.BP_SM_ConditionAttributeRate_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckState_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckState.BP_SM_ConditionCheckState_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckLastState_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckLastState.BP_SM_ConditionCheckLastState_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionHate_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHate.BP_SM_ConditionHate_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionTag_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTag.BP_SM_ConditionTag_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckInstState_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckInstState.BP_SM_ConditionCheckInstState_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionTaskFinish_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTaskFinish.BP_SM_ConditionTaskFinish_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionBuffStack_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionBuffStack.BP_SM_ConditionBuffStack_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionMontageTimeRemaining_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeRemaining.BP_SM_ConditionMontageTimeRemaining_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionMontageTimeElapsing_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeElapsing.BP_SM_ConditionMontageTimeElapsing_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckPartActivated_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPartActivated.BP_SM_ConditionCheckPartActivated_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionListenEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenEvent.BP_SM_ConditionListenEvent_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionPartLife_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionPartLife.BP_SM_ConditionPartLife_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionListenBeHit_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionListenBeHit.BP_SM_ConditionListenBeHit_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionHasMoveInput_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionHasMoveInput.BP_SM_ConditionHasMoveInput_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckGroupPatrol_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPatrol.BP_SM_ConditionCheckGroupPatrol_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckGroupPerform_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckGroupPerform.BP_SM_ConditionCheckGroupPerform_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_BindStatePalsy_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePalsy.BP_SM_BindStatePalsy_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckPositionState_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPositionState.BP_SM_ConditionCheckPositionState_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SM_ConditionCheckDissolveCombine_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckDissolveCombine.BP_SM_ConditionCheckDissolveCombine_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiNavigationPanelConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationPanelConfig.TsUiNavigationPanelConfig_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiNavigationBehaviorListener_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationBehaviorListener.TsUiNavigationBehaviorListener_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiHotKeyActorComponent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyActorComponent.TsUiHotKeyActorComponent_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiHotKeyLinkListener_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiNavigation/TsUiHotKeyLinkListener.TsUiHotKeyLinkListener_C", ETypeLoadKind.Preload)
		},
		{
			"PDA_EffectPaths_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Effect/Debug/PDA_EffectPaths.PDA_EffectPaths_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiNavigationTextChangeListener_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiNavigation/New/TsUiNavigationTextChangeListener.TsUiNavigationTextChangeListener_C", ETypeLoadKind.Preload)
		},
		{
			"ItemMaterialControllerMPCData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/RenderData/ItemMaterialControllerMPCData.ItemMaterialControllerMPCData_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CharacterRenderingFunctionLibrary_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/Manager/BP_CharacterRenderingFunctionLibrary.BP_CharacterRenderingFunctionLibrary_C", ETypeLoadKind.Async)
		},
		{
			"BP_TeleControlConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/TeleControl/BP_TeleControlConfig.BP_TeleControlConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Miaozhunxian_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/PathLine/BP_Miaozhunxian.BP_Miaozhunxian_C", ETypeLoadKind.Async)
		},
		{
			"BP_Miaozhunxian_Bullet_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/PathLine/BP_Miaozhunxian_Bullet.BP_Miaozhunxian_Bullet_C", ETypeLoadKind.Async)
		},
		{
			"TsHotFixActionHandle_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiBlur_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiComponent/Effect/TsUiBlur.TsUiBlur_C", ETypeLoadKind.Preload)
		},
		{
			"TsAnimNotifyStateAddBuff_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddBuff.TsAnimNotifyStateAddBuff_C", ETypeLoadKind.Preload)
		},
		{
			"TsAnimNotifyAddBuff_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyAddBuff.TsAnimNotifyAddBuff_C", ETypeLoadKind.Preload)
		},
		{
			"TsAnimNotifyRemoveBuff_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRemoveBuff.TsAnimNotifyRemoveBuff_C", ETypeLoadKind.Preload)
		},
		{
			"TsAnimNotifyChangeWeather_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeWeather.TsAnimNotifyChangeWeather_C", ETypeLoadKind.Preload)
		},
		{
			"TsAnimNotifyStateHideMesh_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideMesh.TsAnimNotifyStateHideMesh_C", ETypeLoadKind.Preload)
		},
		{
			"BP_MoraleEffectConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/UI/View/Morale/BP_MoraleEffectConfig.BP_MoraleEffectConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_BasePlatform_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/BP_BasePlatform.BP_BasePlatform_C", ETypeLoadKind.Preload)
		},
		{
			"BPL_BulletPreview_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Tools/BPL_BulletPreview.BPL_BulletPreview_C", ETypeLoadKind.Async)
		},
		{
			"CounterAttackCameraData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Define/CounterAttackCameraData.CounterAttackCameraData_C", ETypeLoadKind.Preload)
		},
		{
			"CounterAttackEffectData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Define/CounterAttackEffectData.CounterAttackEffectData_C", ETypeLoadKind.Preload)
		},
		{
			"BP_LightsGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LightsGroup.BP_LightsGroup_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KuroISMGroup_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_KuroISMGroup.BP_KuroISMGroup_C", ETypeLoadKind.Preload)
		},
		{
			"TsBaseItem_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/BaseItem/TsBaseItem.TsBaseItem_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BaseRole_Seq_V2_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseSeqCharacter/BP_BaseRole_Seq_V2.BP_BaseRole_Seq_V2_C", ETypeLoadKind.Preload)
		},
		{
			"CommonEffectMoveSpline2_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/AI/AIMoveSplineCount/CommonEffectMoveSpline2.CommonEffectMoveSpline2_C", ETypeLoadKind.Preload)
		},
		{
			"PDA_InteractionPlayerConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Interaction/PDA_InteractionPlayerConfig.PDA_InteractionPlayerConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CameraShakeAndForceFeedback_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/BP_CameraShakeAndForceFeedback.BP_CameraShakeAndForceFeedback_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KuroPortalCapture_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/Portal/BP_KuroPortalCapture.BP_KuroPortalCapture_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Portal_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Effect/Portal/BP_Portal.BP_Portal_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BaseItem_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Item/BP_BaseItem.BP_BaseItem_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SplitScreen_New_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen_New.BP_SplitScreen_New_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SplitScreenCharacterData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/SplitScreenData/BP_SplitScreenCharacterData.BP_SplitScreenCharacterData_C", ETypeLoadKind.Preload)
		},
		{
			"LogicDataSpeedReduce_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSpeedReduce.LogicDataSpeedReduce_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CloudFuBen_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_CloudFuBen.BP_CloudFuBen_C", ETypeLoadKind.Async)
		},
		{
			"BP_PhysicsAttachedBase_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/InteractiveObject/BP_PhysicsAttachedBase.BP_PhysicsAttachedBase_C", ETypeLoadKind.Async)
		},
		{
			"BP_SkiConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/Ski/BP_SkiConfig.BP_SkiConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_RailSlideConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/RailSlide/BP_RailSlideConfig.BP_RailSlideConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_RailSlideFollowerConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/RailSlideFollower/BP_RailSlideFollowerConfig.BP_RailSlideFollowerConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KeepFollowingConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/KeepFollowing/BP_KeepFollowingConfig.BP_KeepFollowingConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_AttachMoveConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/AttachMove/BP_AttachMoveConfig.BP_AttachMoveConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_AssistedWalkConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/AssistedWalk/BP_AssistedWalkConfig.BP_AssistedWalkConfig_C", ETypeLoadKind.Preload)
		},
		{
			"PD_HolographicEffect_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/PD_HolographicEffect.PD_HolographicEffect_C", ETypeLoadKind.Preload)
		},
		{
			"BP_NPCMaterialController_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_NPCMaterialController.BP_NPCMaterialController_C", ETypeLoadKind.Preload)
		},
		{
			"BP_FollowShooterConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/FollowShooter/BP_FollowShooterConfig.BP_FollowShooterConfig_C", ETypeLoadKind.Preload)
		},
		{
			"WBP_UILoading_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/UI/Module/Loading/View/WBP_UILoading.WBP_UILoading_C", ETypeLoadKind.Sync)
		},
		{
			"TsBaseVehicle_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/NewWorld/Vehicle/TsBaseVehicle.TsBaseVehicle_C", ETypeLoadKind.Preload)
		},
		{
			"BP_VehicleConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/Vehicle/BP_VehicleConfig.BP_VehicleConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_ReplaceHitEffect_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/BP_ReplaceHitEffect.BP_ReplaceHitEffect_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BaseVision_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Vision/BP_BaseVision.BP_BaseVision_C", ETypeLoadKind.Preload)
		},
		{
			"DAC_BatchCreateBullet_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBullet.DAC_BatchCreateBullet_C", ETypeLoadKind.Preload)
		},
		{
			"BP_FloatingMovementConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/BP_FloatingMovementConfig.BP_FloatingMovementConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SummonGongduolaConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/SummonGongduola/BP_SummonGongduolaConfig.BP_SummonGongduolaConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_AIGearStrategy_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/AIGearStrategy/BP_AiGearStrategy.BP_AIGearStrategy_C", ETypeLoadKind.Preload)
		},
		{
			"BP_AIRaceStrategy_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/BP_AIRaceStrategy.BP_AIRaceStrategy_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SceneBattleInteract_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/Fight/BP_SceneBattleInteract.BP_SceneBattleInteract_C", ETypeLoadKind.Preload)
		},
		{
			"BP_RippleSwim_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Scene/Assets/PCG/BP_Tools/RippleSwim/BP_RippleSwim.BP_RippleSwim_C", ETypeLoadKind.Preload)
		},
		{
			"BP_EffectAudio_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Audio/BP_EffectAudio.BP_EffectAudio_C", ETypeLoadKind.Preload)
		},
		{
			"NinjaLive_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive.NinjaLive_C", ETypeLoadKind.Async)
		},
		{
			"ABP_LevelPrefabDaiyu_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Scene/Assets/Levels/LiNaXiTa/QiQiu/ZhuCheng/SkinMesh/SK_Sev_Mon_01AL/CommonAnim/Montage/ABP_LevelPrefabDaiyu.ABP_LevelPrefabDaiyu_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CustomDepthForToon_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_CustomDepthForToon.BP_CustomDepthForToon_C", ETypeLoadKind.Preload)
		},
		{
			"BP_DangoGlobalConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/NPC/Tuanzi/CommonConfig/BP_DangoGlobalConfig.BP_DangoGlobalConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_HoldingHandsConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Role/Common/Data/Structure/BP_HoldingHandsConfig.BP_HoldingHandsConfig_C", ETypeLoadKind.Preload)
		},
		{
			"TsTowerDefenseEventActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/TowerDefenseEvent/Item/TsTowerDefenseEventActor.TsTowerDefenseEventActor_C", ETypeLoadKind.Preload)
		},
		{
			"PDA_HitMeshData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/PDA_HitMeshData.PDA_HitMeshData_C", ETypeLoadKind.Preload)
		},
		{
			"BP_MediaDissolveManagea_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Seq_BP/BPSeqDissolve/BP_MediaDissolveManagea.BP_MediaDissolveManagea_C", ETypeLoadKind.Preload)
		},
		{
			"BP_NpcCombinedMesh_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/Npc/BP_NpcCombinedMesh.BP_NpcCombinedMesh_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SeqNPC_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Seq_BP/BP_SeqNPC.BP_SeqNPC_C", ETypeLoadKind.Preload)
		},
		{
			"TsSeqAnimNotifyAudioEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyAudioEvent.TsSeqAnimNotifyAudioEvent_C", ETypeLoadKind.Preload)
		},
		{
			"TsSeqAnimNotifyFootstepAudioEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyFootstepAudioEvent.TsSeqAnimNotifyFootstepAudioEvent_C", ETypeLoadKind.Preload)
		},
		{
			"TsSeqAnimNotifyPlayPlot_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyPlayPlot.TsSeqAnimNotifyPlayPlot_C", ETypeLoadKind.Preload)
		},
		{
			"TsSeqAnimNotifyStateAudioEvent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/AnimNotifyState/TsSeqAnimNotifyStateAudioEvent.TsSeqAnimNotifyStateAudioEvent_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KuroStreamingSourceProxy_Seq_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Seq_BP/SeqStreamingSource/BP_KuroStreamingSourceProxy_Seq.BP_KuroStreamingSourceProxy_Seq_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SeqSkeletal_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Seq_BP/BP_SeqSkeletal.BP_SeqSkeletal_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SeqCustom_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Seq_BP/BpSeqCustom/BP_SeqCustom.BP_SeqCustom_C", ETypeLoadKind.Preload)
		},
		{
			"BP_ItemInspectGlobalConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/ItemInspect/BP_ItemInspectGlobalConfig.BP_ItemInspectGlobalConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_FirstPersonConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfig.BP_FirstPersonConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_FirstPersonConfigMap_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfigMap.BP_FirstPersonConfigMap_C", ETypeLoadKind.Preload)
		},
		{
			"BP_MotorAssistInputConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Vehicle/Motor/Data/BP_MotorAssistInputConfig.BP_MotorAssistInputConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_SpecialTagConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Role/Common/Data/Structure/BP_SpecialTagConfig.BP_SpecialTagConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_SplineClimbConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/SplineClimb/BP_SplineClimbConfig.BP_SplineClimbConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_SplineMoveConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/AssestStruct/BP_SplineMoveConfig.BP_SplineMoveConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_KiteConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/AssestStruct/BP_KiteConfig.BP_KiteConfig_C", ETypeLoadKind.Preload)
		},
		{
			"TsUiHomeHelper_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Game/Module/UiComponent/UiHomeButton/TsUiHomeHelper.TsUiHomeHelper_C", ETypeLoadKind.Preload)
		},
		{
			"BP_RoleSwingConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/Swing/BP_RoleSwingConfig.BP_RoleSwingConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_CharacterSwingConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/Swing/BP_CharacterSwingConfig.BP_CharacterSwingConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_PhysicInteractProxy_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/InteractiveObject/BP_PhysicInteractProxy.BP_PhysicInteractProxy_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CrowdAiBoidActorSystemBase_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiBoidActorSystemBase.BP_CrowdAiBoidActorSystemBase_C", ETypeLoadKind.Preload)
		},
		{
			"BP_CrowdAiConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiConfig.BP_CrowdAiConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_RollBlockGameplaySetting_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/RollBlock/BP_RollBlockGameplaySetting.BP_RollBlockGameplaySetting_C", ETypeLoadKind.Preload)
		},
		{
			"BP_PilotThrowGameplaySetting_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/PilotThrow/BP_PilotThrowGameplaySetting.BP_PilotThrowGameplaySetting_C", ETypeLoadKind.Async)
		},
		{
			"BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/TriggerItems/BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C", ETypeLoadKind.Async)
		},
		{
			"BP_FindSunSpiritGlobalConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/FindSunSpirit/BP_FindSunSpiritGlobalConfig.BP_FindSunSpiritGlobalConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_Prop_GobletLiquid_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Seq_BP/BPGobletLiquid/BP_Prop_GobletLiquid.BP_Prop_GobletLiquid_C", ETypeLoadKind.Async)
		},
		{
			"BP_SunSpiritConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/SunSpirit/BP_SunSpiritConfig.BP_SunSpiritConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Motor_BaseVehicle_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle.BP_Motor_BaseVehicle_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BaseVehicle_Seq_V2_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Vehicle/Seq/BP_BaseVehicle_Seq_V2.BP_BaseVehicle_Seq_V2_C", ETypeLoadKind.Preload)
		},
		{
			"BP_MovieCameraConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/BP_MovieCameraConfig..BP_MovieCameraConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_SnowTrailComponent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent.BP_SnowTrailComponent_C", ETypeLoadKind.Preload)
		},
		{
			"MediaPlayForModel_Extra_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Extra.MediaPlayForModel_Extra_C", ETypeLoadKind.Async)
		},
		{
			"MediaPlayForModel_Special_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Special.MediaPlayForModel_Special_C", ETypeLoadKind.Async)
		},
		{
			"BP_SnowTrailComponent_NPC_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_SnowTrailComponent_NPC.BP_SnowTrailComponent_NPC_C", ETypeLoadKind.Preload)
		},
		{
			"BP_FlashLightConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Role/Common/Data/Structure/BP_FlashLightConfig.BP_FlashLightConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_OverShoulderModeConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Role/Common/Data/Structure/BP_OverShoulderModeConfig.BP_OverShoulderModeConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_Fx_Scanning_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Scanning.BP_Fx_Scanning_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Plane_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Level/PlaneYinyou/BP/BP_Plane.BP_Plane_C", ETypeLoadKind.Async)
		},
		{
			"Bp_Tetris_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/Tetris/Bp_Tetris.Bp_Tetris_C", ETypeLoadKind.Async)
		},
		{
			"BP_RhythmGameConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/RhythmGame/BP_RhythmGameConfig.BP_RhythmGameConfig_C", ETypeLoadKind.Preload)
		},
		{
			"BP_BulletHitWorldEntityBridge_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/BP_BulletHitWorldEntityBridge.BP_BulletHitWorldEntityBridge_C", ETypeLoadKind.Preload)
		},
		{
			"BP_Fever_Bar_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/SimpleCombat/3_3Pinball/GameBase/SpawnObj/BP_Fever_Bar.BP_Fever_Bar_C", ETypeLoadKind.Async)
		},
		{
			"BP_QtaCustomizationBase_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomizationBase.BP_QtaCustomizationBase_C", ETypeLoadKind.Preload)
		},
		{
			"BP_QtaCustomization_LimitedHold_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomization_LimitedHold.BP_QtaCustomization_LimitedHold_C", ETypeLoadKind.Async)
		},
		{
			"BP_DollGrabMachineGlobalConfig_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/GamePlay/DollGrab/BP_DollGrabMachineGlobalConfig.BP_DollGrabMachineGlobalConfig_C", ETypeLoadKind.Async)
		},
		{
			"BP_DollActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollActor.BP_DollActor_C", ETypeLoadKind.Preload)
		},
		{
			"BP_DollShowCaseActor_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollShowCaseActor.BP_DollShowCaseActor_C", ETypeLoadKind.Preload)
		},
		{
			"BP_MotorExtraComponent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/Component/BP_MotorExtraComponent.BP_MotorExtraComponent_C", ETypeLoadKind.Preload)
		},
		{
			"PD_MotorExtraComponentData_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/Npc/PD_MotorExtraComponentData.PD_MotorExtraComponentData_C", ETypeLoadKind.Preload)
		},
		{
			"BP_WuWaGo_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo.BP_WuWaGo_C", ETypeLoadKind.Async)
		},
		{
			"BP_WuWaGo_LandBox_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_LandBox.BP_WuWaGo_LandBox_C", ETypeLoadKind.Async)
		},
		{
			"BP_WuWaGo_WallBox_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_WallBox.BP_WuWaGo_WallBox_C", ETypeLoadKind.Async)
		},
		{
			"BP_ZoneFollowCameraController_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/ZoneFollowCamera/BP_ZoneFollowCameraController.BP_ZoneFollowCameraController_C", ETypeLoadKind.Async)
		},
		{
			"BP_QiuQian_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQian.BP_QiuQian_C", ETypeLoadKind.Sync)
		},
		{
			"BP_InteractFoliageActor_Base_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor_Base.BP_InteractFoliageActor_Base_C", ETypeLoadKind.Sync)
		},
		{
			"BP_PhotoCutFilterPostProcess_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Character/Role/BP_PhotoCutFilterPostProcess.BP_PhotoCutFilterPostProcess_C", ETypeLoadKind.Async)
		},
		{
			"BP_PhysicsActor_Parent_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Parent.BP_PhysicsActor_Parent_C", ETypeLoadKind.Sync)
		},
		{
			"UniverseRpcBlueprintFunctionLibrary_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/TypeScript/Test/GM/UniverseRpc/UniverseRpcBlueprintFunctionLibrary.UniverseRpcBlueprintFunctionLibrary_C", ETypeLoadKind.Preload)
		},
		{
			"BPI_BridgeModels_BrokenMobile_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BPI_BridgeModels_BrokenMobile.BPI_BridgeModels_BrokenMobile_C", ETypeLoadKind.Preload)
		},
		{
			"BP_DollGrabMahcineConveyorBelt_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollGrabMahcineConveyorBelt.BP_DollGrabMahcineConveyorBelt_C", ETypeLoadKind.Sync)
		},
		{
			"BPI_CarPaintChange_C",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BPI_CarPaintChange.BPI_CarPaintChange_C", ETypeLoadKind.Preload)
		}
	};

	// Token: 0x0400024A RID: 586
	[Nullable(new byte[]
	{
		1,
		1,
		0,
		1
	})]
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<string, ValueTuple<string, ETypeLoadKind>> structDefined = new Dictionary<string, ValueTuple<string, ETypeLoadKind>>
	{
		{
			"SModelConfig",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Entity/Struct/SModelConfig.SModelConfig", ETypeLoadKind.Preload)
		},
		{
			"SCameraModifier",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier.SCameraModifier", ETypeLoadKind.Preload)
		},
		{
			"SCameraModifier_Settings",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Settings.SCameraModifier_Settings", ETypeLoadKind.Preload)
		},
		{
			"SCamera_Setting",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/SCamera_Setting.SCamera_Setting", ETypeLoadKind.Preload)
		},
		{
			"SBaseCurve",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/SBaseCurve.SBaseCurve", ETypeLoadKind.Preload)
		},
		{
			"SFloatCurve",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/SFloatCurve.SFloatCurve", ETypeLoadKind.Preload)
		},
		{
			"SCameraConfig",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/Camera/SCameraConfig.SCameraConfig", ETypeLoadKind.Preload)
		},
		{
			"SHitInformation",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/SHitInformation.SHitInformation", ETypeLoadKind.Preload)
		},
		{
			"SInputCommand",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/Input/Structures/sInputCommand.SInputCommand", ETypeLoadKind.Preload)
		},
		{
			"SClimbState",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/SClimbState.SClimbState", ETypeLoadKind.Preload)
		},
		{
			"SClimbInfo",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/SClimbInfo.SClimbInfo", ETypeLoadKind.Preload)
		},
		{
			"SCounterAttack",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/SCounterAttack.SCounterAttack", ETypeLoadKind.Preload)
		},
		{
			"SVisionCounterAttack",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Character/BaseCharacter/SVisionCounterAttack.SVisionCounterAttack", ETypeLoadKind.Preload)
		},
		{
			"SCharacterLocationsAndRadius",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Common/Struct/SCharacterLocationsAndRadius.SCharacterLocationsAndRadius", ETypeLoadKind.Preload)
		},
		{
			"SSimpleInteractResult",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Core/World/SSimpleInteractResult.SSimpleInteractResult", ETypeLoadKind.Preload)
		},
		{
			"SSequencesKeyFrames",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Sequence/Manager/SSequencesKeyFrames.SSequencesKeyFrames", ETypeLoadKind.Preload)
		},
		{
			"SCameraDebugTool_CameraModeInfo",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraModeInfo.SCameraDebugTool_CameraModeInfo", ETypeLoadKind.Preload)
		},
		{
			"SCameraDebugTool_CameraFrameInfo",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfo.SCameraDebugTool_CameraFrameInfo", ETypeLoadKind.Preload)
		},
		{
			"SCameraDebugTool_CameraFrameInfoRegion",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraFrameInfoRegion.SCameraDebugTool_CameraFrameInfoRegion", ETypeLoadKind.Preload)
		},
		{
			"SCameraDebugTool_CameraProperty",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_CameraProperty.SCameraDebugTool_CameraProperty", ETypeLoadKind.Preload)
		},
		{
			"SCameraDebugTool_SubCameraModification",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_SubCameraModification.SCameraDebugTool_SubCameraModification", ETypeLoadKind.Preload)
		},
		{
			"SCameraDebugTool_ControllerModification",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Camera/CameraDebugTool/SCameraDebugTool_ControllerModification.SCameraDebugTool_ControllerModification", ETypeLoadKind.Preload)
		},
		{
			"SLockOnPart",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/Struct/SLockOnPart.SLockOnPart", ETypeLoadKind.Preload)
		},
		{
			"SVarRefContext",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/NPC/LevelAiBtTree/SVarRefContext.SVarRefContext", ETypeLoadKind.Preload)
		},
		{
			"SpineThingsInfo",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Sequence/Struct/SpineThingsInfo.SpineThingsInfo", ETypeLoadKind.Preload)
		},
		{
			"BvbPlayerItemData",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/UI/Module/ActiveDebug/BvbPlayerItemData.BvbPlayerItemData", ETypeLoadKind.Preload)
		},
		{
			"BvbCardItemData",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/UI/Module/ActiveDebug/BvbCardItemData.BvbCardItemData", ETypeLoadKind.Preload)
		},
		{
			"BvbEffectItemData",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/UI/Module/ActiveDebug/BvbEffectItemData.BvbEffectItemData", ETypeLoadKind.Preload)
		},
		{
			"SEntityTimeDilation",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Entity/Struct/SEntityTimeDilation.SEntityTimeDilation", ETypeLoadKind.Preload)
		},
		{
			"SGravityHookLockInfo",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Fight/Struct/SGravityHookLockInfo.SGravityHookLockInfo", ETypeLoadKind.Preload)
		},
		{
			"SMotorRailMoveConfig",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/MotorRailMove/SMotorRailMoveConfig.SMotorRailMoveConfig", ETypeLoadKind.Preload)
		},
		{
			"RhythmGameSpeedLevelConfig",
			new ValueTuple<string, ETypeLoadKind>("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameSpeedLevelConfig.RhythmGameSpeedLevelConfig", ETypeLoadKind.Preload)
		}
	};

	// Token: 0x0400024B RID: 587
	[Nullable(new byte[]
	{
		1,
		1,
		0,
		1
	})]
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<string, ValueTuple<string, ETypeLoadKind>> enumDefined = new Dictionary<string, ValueTuple<string, ETypeLoadKind>>();

	// Token: 0x0400024C RID: 588
	[Nullable(new byte[]
	{
		1,
		1,
		0,
		1
	})]
	public static Dictionary<string, ValueTuple<ClassDefine.EType, string, ETypeLoadKind>> typeDefined;

	// Token: 0x0200718D RID: 29069
	public enum EType
	{
		// Token: 0x040278DB RID: 162011
		Class,
		// Token: 0x040278DC RID: 162012
		Struct,
		// Token: 0x040278DD RID: 162013
		Enum
	}
}
