using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.GamePlay.TriggerItems;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BE7 RID: 27623
	public class LevelEventSetDataLayerTransition : LevelEventBase
	{
		// Token: 0x060440DB RID: 278747 RVA: 0x011A9B78 File Offset: 0x011A7D78
		public LevelEventSetDataLayerTransition(int id) : base(id)
		{
		}

		// Token: 0x060440DC RID: 278748 RVA: 0x011A9B84 File Offset: 0x011A7D84
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			SetDataLayerTransitions setDataLayerTransitions = inParams as SetDataLayerTransitions;
			string pathName = setDataLayerTransitions.VolumeActor.PathName;
			string[] array = pathName.Split('.', StringSplitOptions.None);
			if (array.Length < 3)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SetDataLayerTransition]actor路径错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RefPath", pathName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			string text = array[1] + "." + array[2];
			EntityHandle entityHandle = LevelGamePlayUtils.GetEntityHandle(null, context);
			if (entityHandle != null && entityHandle.Valid)
			{
				WorldEntity entity = entityHandle.Entity;
				SceneItemReferenceComponent sceneItemReferenceComponent = (entity != null) ? entity.GetComponent<SceneItemReferenceComponent>() : null;
				if (sceneItemReferenceComponent != null && !sceneItemReferenceComponent.IsValidPlatFormPath(text))
				{
					return;
				}
			}
			FName value = FNameUtil.GetDynamicFName(text).Value;
			AActor actor = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroActorSubsystem.StaticClass()) as UKuroActorSubsystem).GetActor(value);
			if (actor == null || !actor.IsValid())
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SetDataLayerTransition]目标actor尚不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RefPath", pathName);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C bp_TsTransitionWorldPartitionTriggerVolumeWrapper_C = actor as BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C;
			if (bp_TsTransitionWorldPartitionTriggerVolumeWrapper_C == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.LevelEvent;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[SetDataLayerTransition]目标actor不是BP_TsTransitionWorldPartitionTriggerVolumeWrapper_C";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("RefPath", pathName);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			TsTransitionWorldPartitionTriggerVolume targetVolume = bp_TsTransitionWorldPartitionTriggerVolumeWrapper_C.TargetVolume;
			if (targetVolume == null || !targetVolume.IsValid())
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.LevelEvent;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[SetDataLayerTransition]目标volume尚不存在";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("RefPath", pathName);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return;
			}
			if (targetVolume != null)
			{
				TsTransitionWorldPartitionTriggerVolume tsTransitionWorldPartitionTriggerVolume = targetVolume;
				tsTransitionWorldPartitionTriggerVolume.SetMatForActivatingDataLayersByPath(setDataLayerTransitions.MaterialDataForEnable);
				tsTransitionWorldPartitionTriggerVolume.SetMatForDeactivatingDataLayersByPath(setDataLayerTransitions.MaterialDataForDisable);
				tsTransitionWorldPartitionTriggerVolume.SetSeqForSourceInByPath(setDataLayerTransitions.VolumeEnterSeq, "");
				tsTransitionWorldPartitionTriggerVolume.SetSeqForSourceOutByPath(setDataLayerTransitions.VolumeOutSeq, "");
				return;
			}
			global::Log instance5 = Singleton<global::Log>.Instance;
			ELogModule module5 = ELogModule.LevelEvent;
			ELogAuthor author5 = ELogAuthor.ZYL;
			string message5 = "[SetDataLayerTransition]目标volume不是TsTransitionWorldPartitionTriggerVolume";
			ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("RefPath", pathName);
			instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
		}
	}
}
