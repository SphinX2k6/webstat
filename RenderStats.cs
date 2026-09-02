using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

// Token: 0x02003423 RID: 13347
[NullableContext(2)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public class RenderStats
{
	// Token: 0x0601BDBB RID: 114107 RVA: 0x0084E35C File Offset: 0x0084C55C
	public static void Init()
	{
		if (RenderStats.IsInit || !Singleton<Info>.Instance.IsGameRunning())
		{
			return;
		}
		RenderStats.IsInit = true;
		RenderStats.StatRenderModuleModelAddTickable = Stat.Create("Render_RenderModuleModel_AddTickable", "", "");
		RenderStats.StatRenderModuleModelTickTickable = Stat.Create("Render_RenderModuleModel_TickTickable", "", "");
		RenderStats.StatRenderModuleModelTickRenderShell = Stat.Create("Render_RenderModuleModel_TickRenderShell", "", "");
		RenderStats.StatBadSignalUpdate = Stat.Create("Render_BadSignal_Update", "", "");
		RenderStats.StatComplexBrokenUpdate = Stat.Create("Render_ComplexBroken_Update", "", "");
		RenderStats.StatCharRenderingComponentAddData = Stat.Create("Render_CharRenderComponent_AddMaterialControlData", "", "");
		RenderStats.StatCharRenderingComponentDataCache = Stat.Create("Render_CharRenderComponent_CacheData", "", "");
		RenderStats.StatCharRenderingComponentInit = Stat.Create("Render_CharRenderComponent_Init", "", "");
		RenderStats.StatCharRenderingComponentUpdate = Stat.Create("Render_CharRenderComponent_Update", "", "");
		RenderStats.StatCharRenderingComponentDataGroupBeforeUpdate = Stat.Create("Render_CharRenderComponent_DataGroupBeforeUpdate", "", "");
		RenderStats.StatCharRenderingComponentDataGroupAfterUpdate = Stat.Create("Render_CharRenderComponent_DataGroupAfterUpdate", "", "");
		RenderStats.StatCharRenderingComponentUpdateInner = Stat.Create("Render_CharRenderComponent_UpdateInner", "", "");
		RenderStats.StatCharRenderingComponentLateUpdate = Stat.Create("Render_CharRenderComponent_LateUpdate", "", "");
		RenderStats.StatCharRenderingComponentRuntimeDataUpdateState = Stat.Create("Render_CharRenderComponent_RuntimeDataUpdateState", "", "");
		RenderStats.StatCharRenderingComponentRuntimeDataUpdateEffect = Stat.Create("Render_CharRenderComponent_RuntimeDataUpdateEffect", "", "");
		RenderStats.StatCharRenderingComponentRuntimeDataSetSpecified = Stat.Create("Render_CharRenderComponent_RuntimeDataSetSpecified", "", "");
		RenderStats.StatCharRenderShellTick = Stat.Create("Render_RenderShell_Tick", "", "");
		RenderStats.StatRenderBillboardTick = Stat.Create("Render_Billboard_Tick", "", "");
		RenderStats.StatEffectBaseActorTick = Stat.Create("Render_EffectBaseActor_Tick", "", "");
		RenderStats.StatEffectBaseActorInit = Stat.Create("Render_EffectBaseActor_Init", "", "");
		RenderStats.StatEffectBaseActorComplete = Stat.Create("Render_EffectBaseActor_Complete", "", "");
		RenderStats.StatEffectBaseActorUpdateTime = Stat.Create("Render_EffectBaseActor_UpdateTime", "", "");
		RenderStats.StatEffectBaseActorUpdateNiagara = Stat.Create("Render_EffectBaseActor_UpdateNiagara", "", "");
		RenderStats.StatEffectBaseActorUpdateTsUpdate = Stat.Create("Render_EffectBaseActor_TsUpdate", "", "");
		RenderStats.StatSceneCharLimbTick = Stat.Create("Render_SceneCharLimb_Tick", "", "");
		RenderStats.StatSceneInteractionManagerTick = Stat.Create("Render_SceneInteraction_Tick", "", "");
		RenderStats.StatSceneInteractionGrass = Stat.Create("Render_SceneInteraction_Grass_Tick", "", "");
		RenderStats.StatSceneInteractionPc = Stat.Create("Render_SceneInteraction_PC_Tick", "", "");
		RenderStats.StatSceneInteractionWater = Stat.Create("Render_SceneInteraction_Water_Tick", "", "");
		RenderStats.StatSceneInteractionOthers = Stat.Create("Render_SceneInteraction_Others_Tick", "", "");
		RenderStats.StatRenderDataManagerTick = Stat.Create("Render_RenderDataManager_Tick", "", "");
		RenderStats.StatItemMaterialManagerTick = Stat.Create("Render_ItemMaterialManager_Tick", "", "");
		RenderStats.StatItemMaterialControllerCollectParameter = Stat.Create("Render_ItemMaterialController_CollectParameter", "", "");
		RenderStats.StatEffectTick = Stat.Create("Render_Effect_Tick", "", "");
		RenderStats.StatFoliageClusteredEffectTick = Stat.Create("Render_FoliageClusteredEffect_Tick", "", "");
		RenderStats.StatAudioVisualizationManagerTick = Stat.Create("Render_AudioVisualizationManager_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateRim = Stat.Create("Render_StatCharMaterialControllerUpdateRim_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateDissolve = Stat.Create("Render_StatCharMaterialControllerUpdateDissolve_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateOutline = Stat.Create("Render_StatCharMaterialControllerUpdateOutline_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateModifyOtherParameters = Stat.Create("Render_StatCharMaterialControllerUpdateModifyOtherParameters_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateSampleTexture = Stat.Create("Render_StatCharMaterialControllerUpdateSampleTexture_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateTransfer = Stat.Create("Render_StatCharMaterialControllerUpdateTransfer_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateMotionOffset = Stat.Create("Render_StatCharMaterialControllerUpdateMotionOffset_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateAbsorbed = Stat.Create("Render_StatCharMaterialControllerUpdateAbsorbed_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateStripMask = Stat.Create("Render_StatCharMaterialControllerUpdateStripMask_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateDither = Stat.Create("Render_StatCharMaterialControllerUpdateDither_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateCustomMaterialEffect = Stat.Create("Render_StatCharMaterialControllerUpdateCustomMaterialEffect_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateHairReplace = Stat.Create("Render_StatCharMaterialControllerUpdateHairReplace_Tick", "", "");
		RenderStats.StatCharMaterialControllerUpdateMaterialReplace = Stat.Create("Render_StatCharMaterialControllerUpdateMaterialReplace_Tick", "", "");
	}

	// Token: 0x0400E0F0 RID: 57584
	private static bool IsInit;

	// Token: 0x0400E0F1 RID: 57585
	public static Stat StatRenderModuleModelAddTickable;

	// Token: 0x0400E0F2 RID: 57586
	public static Stat StatRenderModuleModelTickTickable;

	// Token: 0x0400E0F3 RID: 57587
	public static Stat StatRenderModuleModelTickRenderShell;

	// Token: 0x0400E0F4 RID: 57588
	public static Stat StatBadSignalUpdate;

	// Token: 0x0400E0F5 RID: 57589
	public static Stat StatComplexBrokenUpdate;

	// Token: 0x0400E0F6 RID: 57590
	public static Stat StatCharRenderingComponentAddData;

	// Token: 0x0400E0F7 RID: 57591
	public static Stat StatCharRenderingComponentDataCache;

	// Token: 0x0400E0F8 RID: 57592
	public static Stat StatCharRenderingComponentInit;

	// Token: 0x0400E0F9 RID: 57593
	public static Stat StatCharRenderingComponentUpdate;

	// Token: 0x0400E0FA RID: 57594
	public static Stat StatCharRenderingComponentDataGroupBeforeUpdate;

	// Token: 0x0400E0FB RID: 57595
	public static Stat StatCharRenderingComponentDataGroupAfterUpdate;

	// Token: 0x0400E0FC RID: 57596
	public static Stat StatCharRenderingComponentUpdateInner;

	// Token: 0x0400E0FD RID: 57597
	public static Stat StatCharRenderingComponentLateUpdate;

	// Token: 0x0400E0FE RID: 57598
	public static Stat StatCharRenderingComponentRuntimeDataUpdateState;

	// Token: 0x0400E0FF RID: 57599
	public static Stat StatCharRenderingComponentRuntimeDataUpdateEffect;

	// Token: 0x0400E100 RID: 57600
	public static Stat StatCharRenderingComponentRuntimeDataSetSpecified;

	// Token: 0x0400E101 RID: 57601
	public static Stat StatCharRenderShellTick;

	// Token: 0x0400E102 RID: 57602
	public static Stat StatRenderBillboardTick;

	// Token: 0x0400E103 RID: 57603
	public static Stat StatEffectBaseActorTick;

	// Token: 0x0400E104 RID: 57604
	public static Stat StatEffectBaseActorInit;

	// Token: 0x0400E105 RID: 57605
	public static Stat StatEffectBaseActorComplete;

	// Token: 0x0400E106 RID: 57606
	public static Stat StatEffectBaseActorUpdateTime;

	// Token: 0x0400E107 RID: 57607
	public static Stat StatEffectBaseActorUpdateNiagara;

	// Token: 0x0400E108 RID: 57608
	public static Stat StatEffectBaseActorUpdateTsUpdate;

	// Token: 0x0400E109 RID: 57609
	public static Stat StatSceneCharLimbTick;

	// Token: 0x0400E10A RID: 57610
	public static Stat StatSceneInteractionManagerTick;

	// Token: 0x0400E10B RID: 57611
	public static Stat StatSceneInteractionPc;

	// Token: 0x0400E10C RID: 57612
	public static Stat StatSceneInteractionGrass;

	// Token: 0x0400E10D RID: 57613
	public static Stat StatSceneInteractionWater;

	// Token: 0x0400E10E RID: 57614
	public static Stat StatSceneInteractionOthers;

	// Token: 0x0400E10F RID: 57615
	public static Stat StatRenderDataManagerTick;

	// Token: 0x0400E110 RID: 57616
	public static Stat StatItemMaterialManagerTick;

	// Token: 0x0400E111 RID: 57617
	public static Stat StatItemMaterialControllerCollectParameter;

	// Token: 0x0400E112 RID: 57618
	public static Stat StatEffectTick;

	// Token: 0x0400E113 RID: 57619
	public static Stat StatFoliageClusteredEffectTick;

	// Token: 0x0400E114 RID: 57620
	public static Stat StatAudioVisualizationManagerTick;

	// Token: 0x0400E115 RID: 57621
	public static Stat StatCharMaterialControllerUpdateRim;

	// Token: 0x0400E116 RID: 57622
	public static Stat StatCharMaterialControllerUpdateDissolve;

	// Token: 0x0400E117 RID: 57623
	public static Stat StatCharMaterialControllerUpdateOutline;

	// Token: 0x0400E118 RID: 57624
	public static Stat StatCharMaterialControllerUpdateModifyOtherParameters;

	// Token: 0x0400E119 RID: 57625
	public static Stat StatCharMaterialControllerUpdateSampleTexture;

	// Token: 0x0400E11A RID: 57626
	public static Stat StatCharMaterialControllerUpdateTransfer;

	// Token: 0x0400E11B RID: 57627
	public static Stat StatCharMaterialControllerUpdateMotionOffset;

	// Token: 0x0400E11C RID: 57628
	public static Stat StatCharMaterialControllerUpdateAbsorbed;

	// Token: 0x0400E11D RID: 57629
	public static Stat StatCharMaterialControllerUpdateStripMask;

	// Token: 0x0400E11E RID: 57630
	public static Stat StatCharMaterialControllerUpdateDither;

	// Token: 0x0400E11F RID: 57631
	public static Stat StatCharMaterialControllerUpdateCustomMaterialEffect;

	// Token: 0x0400E120 RID: 57632
	public static Stat StatCharMaterialControllerUpdateHairReplace;

	// Token: 0x0400E121 RID: 57633
	public static Stat StatCharMaterialControllerUpdateMaterialReplace;

	// Token: 0x0400E122 RID: 57634
	public static Stat StatSceneInteractionActor;
}
