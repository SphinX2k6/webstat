using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200478C RID: 18316
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneInteractionManager : IStaticVariableResetter
	{
		// Token: 0x0602F847 RID: 194631 RVA: 0x00B51018 File Offset: 0x00B4F218
		static SceneInteractionManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SceneInteractionManager.CreateStaticDefaultValue), new Action(SceneInteractionManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602F848 RID: 194632 RVA: 0x00B51037 File Offset: 0x00B4F237
		public static SceneInteractionManager Get()
		{
			return SceneInteractionManager.Instanced;
		}

		// Token: 0x0602F849 RID: 194633 RVA: 0x00B5103E File Offset: 0x00B4F23E
		public static void Initialize()
		{
			if (SceneInteractionManager.Instanced == null)
			{
				SceneInteractionManager.Instanced = new SceneInteractionManager();
				SceneInteractionManager.Instanced.Init();
			}
		}

		// Token: 0x0602F84A RID: 194634 RVA: 0x00B5105C File Offset: 0x00B4F25C
		public static void StaticTick(float delta)
		{
			float deltaSeconds = delta / 1000f;
			if (SceneInteractionManager.Instanced != null)
			{
				SceneInteractionManager.Instanced.Tick(deltaSeconds);
			}
		}

		// Token: 0x0602F84B RID: 194635 RVA: 0x00B51084 File Offset: 0x00B4F284
		protected void Init()
		{
			this.IsOnMobile = (UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldFeatureLevel(GlobalData.World) == KuroFeatureLevel.ES3_1);
			this.UniqueLevelInstanceId = 1;
			this.AllSceneInteractionInfos = new Dictionary<int, SceneInteractionLevel>();
			this.TempCacheIds.Clear();
			this.ActorMap = new Dictionary<AActor, int>();
			this.TempVector = Vector.Create();
			this.WaterObjects = new List<SceneObjectWaterEffect>();
			this.AirWallObjects = new List<SceneObjectAirWallEffect>();
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
			this.LoadAssets();
		}

		// Token: 0x0602F84C RID: 194636 RVA: 0x00B5112C File Offset: 0x00B4F32C
		private void UpdateInteractionConfigs()
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(false))
			{
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				object obj;
				if (entityHandle == null)
				{
					obj = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity == null)
					{
						obj = null;
					}
					else
					{
						CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
						obj = ((component != null) ? component.Owner : null);
					}
				}
				TsBaseCharacter tsBaseCharacter = obj as TsBaseCharacter;
				if (tsBaseCharacter != null)
				{
					if (sceneTeamItem.IsControl())
					{
						CharRenderingComponent charRenderingComponent = tsBaseCharacter.CharRenderingComponent;
						if (charRenderingComponent != null)
						{
							charRenderingComponent.AddInteraction(this.MainPlayerConfig, sceneTeamItem.IsMyRole() ? 1f : 2f);
						}
					}
					else
					{
						CharRenderingComponent charRenderingComponent2 = tsBaseCharacter.CharRenderingComponent;
						if (charRenderingComponent2 != null)
						{
							charRenderingComponent2.RemoveInteraction();
						}
					}
				}
			}
		}

		// Token: 0x0602F84D RID: 194637 RVA: 0x00B511FC File Offset: 0x00B4F3FC
		private void OnUpdateSceneTeam()
		{
			this.OnChangeRole(null, null);
		}

		// Token: 0x0602F84E RID: 194638 RVA: 0x00B51208 File Offset: 0x00B4F408
		private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
		{
			if (this.TickProcessId != 0)
			{
				return;
			}
			if (this.TimerHandle != null)
			{
				this.TimerHandle.Remove();
				this.TimerHandle = null;
			}
			this.TickProcessId = Singleton<TickProcessSystem>.Instance.RegisterOnceTickProcess(ETickingGroup.TG_PostUpdateWork, true, new Action<float>(this.TickProcessUpdateInteraction));
		}

		// Token: 0x0602F84F RID: 194639 RVA: 0x00B51257 File Offset: 0x00B4F457
		private void TickProcessUpdateInteraction(float delta)
		{
			this.TickProcessId = 0;
			this.TimerHandle = TimerSystem.Instance.Next(delegate(float _)
			{
				this.TimerHandle = null;
				this.UpdateInteractionConfigs();
			}, null, null);
		}

		// Token: 0x0602F850 RID: 194640 RVA: 0x00B5127E File Offset: 0x00B4F47E
		protected void LoadAssets()
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<PDA_InteractionPlayerConfig_C>("/Game/Aki/Render/Data/Interaction/DA_InteractionMainPlayerConfig.DA_InteractionMainPlayerConfig", delegate([Nullable(2)] PDA_InteractionPlayerConfig_C result, string _)
			{
				this.MainPlayerConfig = result;
				this.OnChangeRole(null, null);
			}, 100, "js_undefined");
		}

		// Token: 0x0602F851 RID: 194641 RVA: 0x00B512A4 File Offset: 0x00B4F4A4
		[NullableContext(2)]
		public int CreateSceneInteractionLevel([Nullable(1)] string inLevelName, EKuroSceneInteractionState? initState, FVectorDouble location, FRotator rotation, Action onLevelStreamingCompleteCallback, bool afterLoadVisible = true, bool isInitShow = false, int pbDataId = 0, Action onLevelStreamingLoadedCompleteCallback = null)
		{
			UWorld world = GlobalData.World;
			if (world == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderScene, ELogAuthor.HCS, "错误，获取不到World", default(ReadOnlySpan<ValueTuple<string, object>>));
				return -1;
			}
			string text = inLevelName;
			if (inLevelName.Contains("."))
			{
				text = inLevelName.Split(".", StringSplitOptions.None)[0];
			}
			int uniqueLevelInstanceId = this.UniqueLevelInstanceId;
			bool flag = false;
			string optionalLevelNameOverride = "KuroSceneInteraction_" + uniqueLevelInstanceId.ToString();
			ULevelStreamingDynamic ulevelStreamingDynamic = ULevelStreamingDynamic.LoadLevelInstance(world, text, location, rotation, ref flag, optionalLevelNameOverride, default(TSubclassOf<ULevelStreamingDynamic>));
			if (flag && ulevelStreamingDynamic != null)
			{
				SceneInteractionLevel sceneInteractionLevel = new SceneInteractionLevel();
				sceneInteractionLevel.Init(ulevelStreamingDynamic, text, location, rotation, uniqueLevelInstanceId, initState, onLevelStreamingCompleteCallback, afterLoadVisible, isInitShow, pbDataId, onLevelStreamingLoadedCompleteCallback);
				this.UniqueLevelInstanceId++;
				this.AllSceneInteractionInfos[uniqueLevelInstanceId] = sceneInteractionLevel;
				return uniqueLevelInstanceId;
			}
			return -1;
		}

		// Token: 0x0602F852 RID: 194642 RVA: 0x00B5137C File Offset: 0x00B4F57C
		public void SetLevelStreamingPriority(int handleId, int priority)
		{
			SceneInteractionLevel sceneInteractionLevel;
			if (this.AllSceneInteractionInfos != null && this.AllSceneInteractionInfos.TryGetValue(handleId, out sceneInteractionLevel))
			{
				sceneInteractionLevel.SetStreamingPriority(priority);
			}
		}

		// Token: 0x0602F853 RID: 194643 RVA: 0x00B513A8 File Offset: 0x00B4F5A8
		public bool DestroySceneInteraction(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel == null)
			{
				return false;
			}
			sceneInteractionLevel.Destroy();
			this.AllSceneInteractionInfos.Remove(handleId);
			IReadOnlyDictionary<string, AActor> allActor = sceneInteractionLevel.GetAllActor();
			if (allActor == null)
			{
				return true;
			}
			foreach (KeyValuePair<string, AActor> keyValuePair in allActor)
			{
				AActor value = keyValuePair.Value;
				if (value != null)
				{
					this.ActorMap.Remove(value);
				}
			}
			return true;
		}

		// Token: 0x0602F854 RID: 194644 RVA: 0x00B51448 File Offset: 0x00B4F648
		public bool SwitchSceneInteractionToState(int handleId, EKuroSceneInteractionState targetState, bool needTransition, bool force, bool jumpToEnd = false)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			return sceneInteractionLevel != null && sceneInteractionLevel.SwitchToState(targetState, needTransition, force, jumpToEnd);
		}

		// Token: 0x0602F855 RID: 194645 RVA: 0x00B51484 File Offset: 0x00B4F684
		public EKuroSceneInteractionState GetSceneInteractionCurrentState(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetCurrentState();
			}
			return EKuroSceneInteractionState.Error;
		}

		// Token: 0x0602F856 RID: 194646 RVA: 0x00B514BC File Offset: 0x00B4F6BC
		public void PlaySceneInteractionEffect(int handleId, ESceneInteractionEffect effectKey)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.PlaySceneEffect(effectKey);
			}
		}

		// Token: 0x0602F857 RID: 194647 RVA: 0x00B514F4 File Offset: 0x00B4F6F4
		public void EndSceneInteractionEffect(int handleId, ESceneInteractionEffect effectKey)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.EndSceneEffect(effectKey);
			}
		}

		// Token: 0x0602F858 RID: 194648 RVA: 0x00B5152C File Offset: 0x00B4F72C
		public void PlaySceneInteractionEndEffect(int handleId, ESceneInteractionEffect effectKey)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.PlaySceneEndEffect(effectKey);
			}
		}

		// Token: 0x0602F859 RID: 194649 RVA: 0x00B51564 File Offset: 0x00B4F764
		public void ChangeSceneInteractionPlayDirection(int handleId, bool bPlayBack)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.ChangePlayDirection(bPlayBack);
			}
		}

		// Token: 0x0602F85A RID: 194650 RVA: 0x00B5159C File Offset: 0x00B4F79C
		public bool IsSceneInteractionStreamingComplete(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			return sceneInteractionLevel != null && sceneInteractionLevel.IsStreamingComplete();
		}

		// Token: 0x0602F85B RID: 194651 RVA: 0x00B515D4 File Offset: 0x00B4F7D4
		public void ToggleSceneInteractionVisible(int handleId, bool visible, bool needHidden = false, [Nullable(2)] Action onLevelStreamingShowOrHideCallback = null, string reason = "")
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.ToggleLevelVisible(visible, needHidden, onLevelStreamingShowOrHideCallback, reason);
			}
		}

		// Token: 0x0602F85C RID: 194652 RVA: 0x00B51610 File Offset: 0x00B4F810
		[NullableContext(2)]
		public string GetSceneInteractionLevelName(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.LevelName;
			}
			return null;
		}

		// Token: 0x0602F85D RID: 194653 RVA: 0x00B51648 File Offset: 0x00B4F848
		[NullableContext(2)]
		public AActor GetSceneInteractionMainActor(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.MainActor;
			}
			return null;
		}

		// Token: 0x0602F85E RID: 194654 RVA: 0x00B51680 File Offset: 0x00B4F880
		[return: Nullable(2)]
		public AActor GetSceneInteractionActorByKey(int handleId, string key)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetActorByKey(key);
			}
			return null;
		}

		// Token: 0x0602F85F RID: 194655 RVA: 0x00B516B8 File Offset: 0x00B4F8B8
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public IReadOnlyDictionary<string, AActor> GetSceneInteractionAllKeyRefActors(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetAllActor();
			}
			return null;
		}

		// Token: 0x0602F860 RID: 194656 RVA: 0x00B516F0 File Offset: 0x00B4F8F0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public TArray<AActor> GetRefSceneInteractionActorsByTag(int handleId, FGameplayTag tag)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetRefActorsByTag(tag);
			}
			return null;
		}

		// Token: 0x0602F861 RID: 194657 RVA: 0x00B51728 File Offset: 0x00B4F928
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public TArray<AActor> GetSceneInteractionAllActorsInLevel(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetAllActorsInLevel();
			}
			return null;
		}

		// Token: 0x0602F862 RID: 194658 RVA: 0x00B51760 File Offset: 0x00B4F960
		public FTransformDouble? GetActorOriginalRelTransform(int handleId, AActor actor)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetActorOriginalRelTransform(actor);
			}
			return null;
		}

		// Token: 0x0602F863 RID: 194659 RVA: 0x00B517A0 File Offset: 0x00B4F9A0
		public void AttachToActor(int handleId, AActor parentActor)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.AttachToActor(parentActor);
			}
		}

		// Token: 0x0602F864 RID: 194660 RVA: 0x00B517D8 File Offset: 0x00B4F9D8
		public void SetCollisionActorsOwner(int handleId, AActor owner)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.SetCollisionActorsOwner(owner);
			}
		}

		// Token: 0x0602F865 RID: 194661 RVA: 0x00B51810 File Offset: 0x00B4FA10
		public void AttachChildActor(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel == null)
			{
				return;
			}
			IReadOnlyDictionary<string, AActor> allActor = sceneInteractionLevel.GetAllActor();
			if (allActor == null)
			{
				return;
			}
			foreach (KeyValuePair<string, AActor> keyValuePair in allActor)
			{
				AActor value = keyValuePair.Value;
				if (value != null)
				{
					this.ActorMap[value] = handleId;
				}
			}
		}

		// Token: 0x0602F866 RID: 194662 RVA: 0x00B5189C File Offset: 0x00B4FA9C
		public void EmitActor(AActor actor, string seqName, string eventName)
		{
			if (actor == null)
			{
				return;
			}
			int key = this.ActorMap.ContainsKey(actor) ? this.ActorMap[actor] : 0;
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(key) ? this.AllSceneInteractionInfos[key] : null;
			if (sceneInteractionLevel == null)
			{
				return;
			}
			AActor attachActor = sceneInteractionLevel.GetAttachActor();
			if (attachActor == null)
			{
				return;
			}
			EntityHandle entityByActor = ActorUtils.GetEntityByActor(attachActor, true);
			if (entityByActor == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<string, string>(entityByActor, EEventName.SceneItemInteractionEvent, seqName, eventName);
		}

		// Token: 0x0602F867 RID: 194663 RVA: 0x00B51918 File Offset: 0x00B4FB18
		[NullableContext(2)]
		public AActor GetMainCollisionActor(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetMainCollisionActor();
			}
			return null;
		}

		// Token: 0x0602F868 RID: 194664 RVA: 0x00B51950 File Offset: 0x00B4FB50
		[NullableContext(2)]
		public ASkeletalMeshActor GetSceneInteractionSkeletalMeshActor(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetSkeletalMeshActor();
			}
			return null;
		}

		// Token: 0x0602F869 RID: 194665 RVA: 0x00B51988 File Offset: 0x00B4FB88
		public FGameplayTag? GetPartCollisionActorTag(int handleId, AActor actor)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetPartCollisionActorTag(actor);
			}
			return null;
		}

		// Token: 0x0602F86A RID: 194666 RVA: 0x00B519C8 File Offset: 0x00B4FBC8
		public int? GetPartCollisionActorsNum(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetPartCollisionActorsNum();
			}
			return null;
		}

		// Token: 0x0602F86B RID: 194667 RVA: 0x00B51A08 File Offset: 0x00B4FC08
		[NullableContext(2)]
		public AActor GetPartCollisionActor(int handleId, int index)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetPartCollisionActor(index);
			}
			return null;
		}

		// Token: 0x0602F86C RID: 194668 RVA: 0x00B51A40 File Offset: 0x00B4FC40
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public TArray<AActor> GetInteractionEffectHookActors(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetInteractionEffectHookActors();
			}
			return null;
		}

		// Token: 0x0602F86D RID: 194669 RVA: 0x00B51A78 File Offset: 0x00B4FC78
		public float? GetActiveTagSequencePlaybackProgress(int handleId, FGameplayTag tag)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetActiveTagSequencePlaybackProgress(tag);
			}
			return null;
		}

		// Token: 0x0602F86E RID: 194670 RVA: 0x00B51AB8 File Offset: 0x00B4FCB8
		public void SetActiveTagSequencePlaybackProgress(int handleId, FGameplayTag tag, float progress)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.SetActiveTagSequencePlaybackProgress(tag, progress);
			}
		}

		// Token: 0x0602F86F RID: 194671 RVA: 0x00B51AF0 File Offset: 0x00B4FCF0
		public double? GetActiveTagSequenceDurationTime(int handleId, FGameplayTag tag)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetActiveTagSequenceDurationTime(tag);
			}
			return null;
		}

		// Token: 0x0602F870 RID: 194672 RVA: 0x00B51B30 File Offset: 0x00B4FD30
		public void SetActiveTagSequenceDurationTime(int handleId, FGameplayTag tag, float durationSecond)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.SetActiveTagSequenceDurationTime(tag, durationSecond);
			}
		}

		// Token: 0x0602F871 RID: 194673 RVA: 0x00B51B68 File Offset: 0x00B4FD68
		public void PauseActiveTagSequence(int handleId, FGameplayTag tag)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.PauseActiveTagSequence(tag);
			}
		}

		// Token: 0x0602F872 RID: 194674 RVA: 0x00B51BA0 File Offset: 0x00B4FDA0
		public void ResumeActiveTagSequence(int handleId, FGameplayTag tag, bool bReverseFromConfig = false)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.ResumeActiveTagSequence(tag, bReverseFromConfig);
			}
		}

		// Token: 0x0602F873 RID: 194675 RVA: 0x00B51BD8 File Offset: 0x00B4FDD8
		public bool? GetIsActiveTagSequencePlayReverseFromConfig(int handleId, FGameplayTag tag)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetIsActiveTagSequencePlayReverseFromConfig(tag);
			}
			return null;
		}

		// Token: 0x0602F874 RID: 194676 RVA: 0x00B51C18 File Offset: 0x00B4FE18
		public void PlayActiveTagSequenceTo(int handleId, FGameplayTag tag, float progress, bool bReverseFromConfig = false)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.PlayActiveTagSequenceTo(tag, progress, bReverseFromConfig);
			}
		}

		// Token: 0x0602F875 RID: 194677 RVA: 0x00B51C50 File Offset: 0x00B4FE50
		public void RegisterWaterEffectObject(SceneObjectWaterEffect objectParam)
		{
			this.WaterObjects.Add(objectParam);
			objectParam.AfterRegistered();
		}

		// Token: 0x0602F876 RID: 194678 RVA: 0x00B51C64 File Offset: 0x00B4FE64
		public void UnregisterWaterEffectObject(SceneObjectWaterEffect objectParam)
		{
			int num = this.WaterObjects.FindIndex((SceneObjectWaterEffect value) => value == objectParam);
			if (num == -1)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.LSY, "要移除的SceneObjectWaterEffect不存在队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (objectParam != null)
				{
					objectParam.BeforeUnregistered();
				}
				return;
			}
			objectParam.BeforeUnregistered();
			this.WaterObjects[num] = this.WaterObjects[this.WaterObjects.Count - 1];
			this.WaterObjects.RemoveAt(this.WaterObjects.Count - 1);
		}

		// Token: 0x0602F877 RID: 194679 RVA: 0x00B51D11 File Offset: 0x00B4FF11
		public void RegisterAirWallEffectObject(SceneObjectAirWallEffect objectParam)
		{
			this.AirWallObjects.Add(objectParam);
			objectParam.AfterRegistered();
		}

		// Token: 0x0602F878 RID: 194680 RVA: 0x00B51D28 File Offset: 0x00B4FF28
		public void UnregisterAirWallEffectObject(SceneObjectAirWallEffect objectParam)
		{
			int num = this.AirWallObjects.FindIndex((SceneObjectAirWallEffect value) => value == objectParam);
			if (num == -1)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.CH, "要移除的SceneObjectAirWallEffect不存在队列中", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (objectParam != null)
				{
					objectParam.BeforeUnregistered();
				}
				return;
			}
			objectParam.BeforeUnregistered();
			this.AirWallObjects[num] = this.AirWallObjects[this.AirWallObjects.Count - 1];
			this.AirWallObjects.RemoveAt(this.AirWallObjects.Count - 1);
		}

		// Token: 0x0602F879 RID: 194681 RVA: 0x00B51DD8 File Offset: 0x00B4FFD8
		public void PlayExtraEffectByTag(int handleId, FGameplayTag tag, bool jumpToEnd)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.PlayExtraEffect(tag, jumpToEnd);
			}
		}

		// Token: 0x0602F87A RID: 194682 RVA: 0x00B51E10 File Offset: 0x00B50010
		public void PlayKuroSkeletalMeshDestruction(int handleId, AActor actor, bool jumpToEnd = false)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.PlayKuroSkeletalMeshDestruction(actor, jumpToEnd);
			}
		}

		// Token: 0x0602F87B RID: 194683 RVA: 0x00B51E48 File Offset: 0x00B50048
		public void StopExtraEffectByTag(int handleId, FGameplayTag tag)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.StopExtraEffect(tag);
			}
		}

		// Token: 0x0602F87C RID: 194684 RVA: 0x00B51E80 File Offset: 0x00B50080
		public void UpdateHitInfo(int handleId, Vector pos, FVector dir)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.UpdateHitInfo(pos, dir);
			}
		}

		// Token: 0x0602F87D RID: 194685 RVA: 0x00B51EB8 File Offset: 0x00B500B8
		public void UpdateRangeOverlapInfo(int handleId, bool isEnter, AActor otherActor)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.UpdateRangeOverlapInfo(isEnter, otherActor);
			}
		}

		// Token: 0x0602F87E RID: 194686 RVA: 0x00B51EF0 File Offset: 0x00B500F0
		public void SetOverrideSeqBindActor(int handleId, AActor actorToBind, [Nullable(2)] string bindingName = null)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel == null)
			{
				return;
			}
			sceneInteractionLevel.SetOverrideSeqBindActor(actorToBind, bindingName);
		}

		// Token: 0x0602F87F RID: 194687 RVA: 0x00B51F28 File Offset: 0x00B50128
		public void UnsetOverrideSeqBindActor(int handleId, AActor actorToUnBind, [Nullable(2)] string bindingName = null)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel == null)
			{
				return;
			}
			sceneInteractionLevel.UnsetOverrideSeqBindActor(actorToUnBind, bindingName);
		}

		// Token: 0x0602F880 RID: 194688 RVA: 0x00B51F60 File Offset: 0x00B50160
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public TArray<AActor> GetReceivingDecalsActors(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				return sceneInteractionLevel.GetReceivingDecalsActors();
			}
			return null;
		}

		// Token: 0x0602F881 RID: 194689 RVA: 0x00B51F98 File Offset: 0x00B50198
		public void DisableInteractionLevel(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.Disable();
			}
		}

		// Token: 0x0602F882 RID: 194690 RVA: 0x00B51FCC File Offset: 0x00B501CC
		public void EnableInteractionLevel(int handleId)
		{
			SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(handleId) ? this.AllSceneInteractionInfos[handleId] : null;
			if (sceneInteractionLevel != null)
			{
				sceneInteractionLevel.Enable();
			}
		}

		// Token: 0x0602F883 RID: 194691 RVA: 0x00B52000 File Offset: 0x00B50200
		public void Tick(float deltaSeconds)
		{
			int i = 0;
			int count = this.WaterObjects.Count;
			while (i < count)
			{
				this.WaterObjects[i].Update(deltaSeconds);
				i++;
			}
			int j = 0;
			int count2 = this.AirWallObjects.Count;
			while (j < count2)
			{
				this.AirWallObjects[j].Update((double)deltaSeconds);
				j++;
			}
			this.TempCacheIds.Clear();
			foreach (int item in this.AllSceneInteractionInfos.Keys)
			{
				this.TempCacheIds.Add(item);
			}
			foreach (int key in this.TempCacheIds)
			{
				SceneInteractionLevel sceneInteractionLevel = this.AllSceneInteractionInfos.ContainsKey(key) ? this.AllSceneInteractionInfos[key] : null;
				if (sceneInteractionLevel != null && !sceneInteractionLevel.IsInfoDestroyed())
				{
					sceneInteractionLevel.Update(deltaSeconds);
				}
			}
		}

		// Token: 0x0602F884 RID: 194692 RVA: 0x00B52134 File Offset: 0x00B50334
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602F885 RID: 194693 RVA: 0x00B52136 File Offset: 0x00B50336
		public static void ResetStaticDefaultValue()
		{
			SceneInteractionManager.Instanced = null;
		}

		// Token: 0x0401B2DC RID: 111324
		public bool IsOnMobile;

		// Token: 0x0401B2DD RID: 111325
		[Nullable(2)]
		protected static SceneInteractionManager Instanced;

		// Token: 0x0401B2DE RID: 111326
		protected int UniqueLevelInstanceId;

		// Token: 0x0401B2DF RID: 111327
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<int, SceneInteractionLevel> AllSceneInteractionInfos;

		// Token: 0x0401B2E0 RID: 111328
		protected List<int> TempCacheIds = new List<int>();

		// Token: 0x0401B2E1 RID: 111329
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<AActor, int> ActorMap;

		// Token: 0x0401B2E2 RID: 111330
		[Nullable(2)]
		public PDA_InteractionPlayerConfig_C MainPlayerConfig;

		// Token: 0x0401B2E3 RID: 111331
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<SceneObjectWaterEffect> WaterObjects;

		// Token: 0x0401B2E4 RID: 111332
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<SceneObjectAirWallEffect> AirWallObjects;

		// Token: 0x0401B2E5 RID: 111333
		[Nullable(2)]
		protected Vector TempVector;

		// Token: 0x0401B2E6 RID: 111334
		private int TickProcessId;

		// Token: 0x0401B2E7 RID: 111335
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0401B2E8 RID: 111336
		private const float ms2s = 1000f;

		// Token: 0x0401B2E9 RID: 111337
		private const float updateInternalScaleForRemote = 2f;
	}
}
