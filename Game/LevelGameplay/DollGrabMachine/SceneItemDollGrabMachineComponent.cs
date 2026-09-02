using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EDA RID: 28378
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemDollGrabMachineComponent : EntityComponent
	{
		// Token: 0x1700A41F RID: 42015
		// (get) Token: 0x06044C6B RID: 281707 RVA: 0x011E151D File Offset: 0x011DF71D
		public float TimeLimit
		{
			get
			{
				DollGrabMachineComponent config = this.Config;
				if (config == null)
				{
					return 0f;
				}
				return config.TimeLimit;
			}
		}

		// Token: 0x1700A420 RID: 42016
		// (get) Token: 0x06044C6C RID: 281708 RVA: 0x011E1534 File Offset: 0x011DF734
		public FTransformDouble ActorTransform
		{
			get
			{
				return this.ActorComp.ActorTransform;
			}
		}

		// Token: 0x1700A421 RID: 42017
		// (get) Token: 0x06044C6D RID: 281709 RVA: 0x011E1541 File Offset: 0x011DF741
		public bool IsEndlessMode
		{
			get
			{
				return this.IsEndlessModeInternal;
			}
		}

		// Token: 0x1700A422 RID: 42018
		// (get) Token: 0x06044C6E RID: 281710 RVA: 0x011E1549 File Offset: 0x011DF749
		public int LeaveDollCount
		{
			get
			{
				return this.LeaveDollCountInternal;
			}
		}

		// Token: 0x1700A423 RID: 42019
		// (get) Token: 0x06044C6F RID: 281711 RVA: 0x011E1554 File Offset: 0x011DF754
		[Nullable(1)]
		public List<IGrabItemData> CurrentDropItemList
		{
			[NullableContext(1)]
			get
			{
				List<IGrabItemData> list = new List<IGrabItemData>();
				foreach (KeyValuePair<int, int> keyValuePair in this.CurrentDropItemListInternal)
				{
					int num;
					int num2;
					keyValuePair.Deconstruct(out num, out num2);
					int itemId = num;
					int count = num2;
					list.Add(new GrabItemData
					{
						ItemId = itemId,
						Count = count
					});
				}
				return list;
			}
		}

		// Token: 0x1700A424 RID: 42020
		// (get) Token: 0x06044C70 RID: 281712 RVA: 0x011E15D4 File Offset: 0x011DF7D4
		public float PlayCost
		{
			get
			{
				DollGrabMachineComponent config = this.Config;
				return ((config != null) ? config.PlayCost : null).GetValueOrDefault();
			}
		}

		// Token: 0x1700A425 RID: 42021
		// (get) Token: 0x06044C71 RID: 281713 RVA: 0x011E1603 File Offset: 0x011DF803
		public bool IsMachineActive
		{
			get
			{
				return this.IsActiveInternal;
			}
		}

		// Token: 0x1700A426 RID: 42022
		// (get) Token: 0x06044C72 RID: 281714 RVA: 0x011E160B File Offset: 0x011DF80B
		public bool IsMachinePause
		{
			get
			{
				return this.IsPauseInternal;
			}
		}

		// Token: 0x1700A427 RID: 42023
		// (get) Token: 0x06044C73 RID: 281715 RVA: 0x011E1613 File Offset: 0x011DF813
		public IDollGrabInfiniteRewardData EndlessRewardData
		{
			get
			{
				return this.EndlessRewardDataInternal;
			}
		}

		// Token: 0x1700A428 RID: 42024
		// (get) Token: 0x06044C74 RID: 281716 RVA: 0x011E161B File Offset: 0x011DF81B
		public BP_DollActor_C MainDollActor
		{
			get
			{
				DollGrabMachineItem mainDollActorItem = this.MainDollActorItem;
				if (mainDollActorItem == null)
				{
					return null;
				}
				return mainDollActorItem.ItemActor;
			}
		}

		// Token: 0x1700A429 RID: 42025
		// (get) Token: 0x06044C75 RID: 281717 RVA: 0x011E1630 File Offset: 0x011DF830
		public int ConditionId
		{
			get
			{
				DollGrabMachineComponent config = this.Config;
				int? num;
				if (config == null)
				{
					num = null;
				}
				else
				{
					IDollGrabInfiniteModeData infiniteModeData = config.InfiniteModeData;
					num = ((infiniteModeData != null) ? infiniteModeData.UnlockConditionGroupId : null);
				}
				int? num2 = num;
				return num2.GetValueOrDefault();
			}
		}

		// Token: 0x1700A42A RID: 42026
		// (get) Token: 0x06044C76 RID: 281718 RVA: 0x011E1674 File Offset: 0x011DF874
		public IDollGrabInfiniteShowCaseRewardData CurrentScoreRewardData
		{
			get
			{
				DollGrabMachineComponent config = this.Config;
				IDollGrabInfiniteScoreReward dollGrabInfiniteScoreReward;
				if (config == null)
				{
					dollGrabInfiniteScoreReward = null;
				}
				else
				{
					IDollGrabInfiniteModeData infiniteModeData = config.InfiniteModeData;
					dollGrabInfiniteScoreReward = ((infiniteModeData != null) ? infiniteModeData.ScoreReward : null);
				}
				IDollGrabInfiniteScoreReward dollGrabInfiniteScoreReward2 = dollGrabInfiniteScoreReward;
				if (dollGrabInfiniteScoreReward2 == null)
				{
					return null;
				}
				IDollGrabInfiniteRewardData endlessRewardData = this.EndlessRewardData;
				int num = (endlessRewardData != null) ? endlessRewardData.CurrentAccumulatedScore : 0;
				return new DollGrabInfiniteShowCaseRewardData
				{
					DropId = dollGrabInfiniteScoreReward2.RewardId,
					GetRewardIndex = ((dollGrabInfiniteScoreReward2.TargetScore <= num) ? 1 : 0),
					NextRewardIndex = 1
				};
			}
		}

		// Token: 0x06044C77 RID: 281719 RVA: 0x011E16E4 File Offset: 0x011DF8E4
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			DollGrabMachineComponent dollGrabMachineComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemDollGrabMachineComponent>() as DollGrabMachineComponent;
			if (dollGrabMachineComponent == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DollGrabMachine;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[DollGrabMachineComp] 组件配置缺失";
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.Config = dollGrabMachineComponent;
			this.IsEndlessModeInternal = (dollGrabMachineComponent.InfiniteModeData != null);
			if (!string.IsNullOrEmpty(dollGrabMachineComponent.AkEvent))
			{
				string[] array = dollGrabMachineComponent.AkEvent.Split(".", StringSplitOptions.None);
				this.AkEvent = array[array.Length - 1];
			}
			this.OnInitEndlessModeData();
			BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
			this.DissolveRadius = ((dollGrabMachineGlobalConfig != null) ? dollGrabMachineGlobalConfig.溶解半径 : 0f);
			if (this.DissolveRadius > 0f)
			{
				float dissolveRadius = this.DissolveRadius;
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig2 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				this.DissolvePerSecond = dissolveRadius / ((dollGrabMachineGlobalConfig2 != null) ? dollGrabMachineGlobalConfig2.溶解时长 : 0f) / 1000f;
			}
			BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig3 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
			this.ItemRotationDamping = ((dollGrabMachineGlobalConfig3 != null) ? dollGrabMachineGlobalConfig3.旋转阻尼 : 0f);
			BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig4 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
			this.ItemMoveDamping = ((dollGrabMachineGlobalConfig4 != null) ? dollGrabMachineGlobalConfig4.平移阻尼 : 0f);
			return true;
		}

		// Token: 0x06044C78 RID: 281720 RVA: 0x011E1848 File Offset: 0x011DFA48
		private void OnInitEndlessModeData()
		{
			if (this.IsEndlessModeInternal)
			{
				if (this.Config.InfiniteModeData.RefreshIntervalCurve != "")
				{
					Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(this.Config.InfiniteModeData.RefreshIntervalCurve, delegate([Nullable(2)] UCurveFloat curve, string _)
					{
						if (curve == null)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.DollGrabMachine;
							ELogAuthor author = ELogAuthor.FJH;
							string message = "[DollGrabMachineComp][无尽模式] 无尽关曲线加载失败";
							string item = "CurvePath";
							IDollGrabInfiniteModeData infiniteModeData = this.Config.InfiniteModeData;
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, ((infiniteModeData != null) ? infiniteModeData.RefreshIntervalCurve : null) ?? "NoPath");
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							return;
						}
						this.RefreshIntervalCurve = curve;
					}, 100, "js_undefined");
				}
				if (this.Config.InfiniteModeData.StandbyItemPool.Count > 0)
				{
					foreach (IDollGrabStandbyPoolItem dollGrabStandbyPoolItem in this.Config.InfiniteModeData.StandbyItemPool)
					{
						this.EndlessIdleItemIdList.Add(dollGrabStandbyPoolItem.UniqueId);
						DollGrabMachineItem value = new DollGrabMachineItem(dollGrabStandbyPoolItem.UniqueId, dollGrabStandbyPoolItem.ItemId, null, null, null);
						this.EndlessIdleItemPool[dollGrabStandbyPoolItem.UniqueId] = value;
					}
				}
				IDollGrabInfiniteScoreReward scoreReward = this.Config.InfiniteModeData.ScoreReward;
				if (scoreReward != null)
				{
					DollGrabInfiniteRewardData dollGrabInfiniteRewardData = new DollGrabInfiniteRewardData();
					dollGrabInfiniteRewardData.DropId = scoreReward.RewardId;
					dollGrabInfiniteRewardData.CurrentScore = 0;
					dollGrabInfiniteRewardData.TargetAccumulatedScore = scoreReward.TargetScore;
					DollGrabMachineComponentPb dollGrabMachineInfo = this.CreatureDataComp.DollGrabMachineInfo;
					dollGrabInfiniteRewardData.CurrentAccumulatedScore = ((dollGrabMachineInfo != null) ? dollGrabMachineInfo.AccumulatedScore : 0);
					dollGrabInfiniteRewardData.IsFinalReward = false;
					DollGrabMachineComponentPb dollGrabMachineInfo2 = this.CreatureDataComp.DollGrabMachineInfo;
					dollGrabInfiniteRewardData.HighestScore = ((dollGrabMachineInfo2 != null) ? dollGrabMachineInfo2.HighScore : 0);
					dollGrabInfiniteRewardData.IsFirstGetReward = false;
					this.EndlessRewardDataInternal = dollGrabInfiniteRewardData;
					this.EndlessRewardDataInternal.IsFinalReward = (this.EndlessRewardDataInternal.CurrentAccumulatedScore >= this.EndlessRewardDataInternal.TargetAccumulatedScore);
				}
				List<IDollGrabInfiniteStageConfig> stageConfigs = this.Config.InfiniteModeData.StageConfigs;
				if (stageConfigs != null)
				{
					foreach (IDollGrabInfiniteStageConfig dollGrabInfiniteStageConfig in stageConfigs)
					{
						if (dollGrabInfiniteStageConfig.AudioState != null)
						{
							EndlessAudioStateInfo value2 = new EndlessAudioStateInfo(dollGrabInfiniteStageConfig.Duration, dollGrabInfiniteStageConfig.AudioState);
							this.EndlessAudioDataInternal[dollGrabInfiniteStageConfig.Duration] = value2;
						}
					}
				}
			}
		}

		// Token: 0x06044C79 RID: 281721 RVA: 0x011E1A74 File Offset: 0x011DFC74
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DollGrabMachine;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[DollGrabMachineComp] Actor组件缺失";
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.StateComp = base.Entity.GetComponent<SceneItemStateComponent>();
			if (this.StateComp == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.DollGrabMachine;
				ELogAuthor author2 = ELogAuthor.FJH;
				string message2 = "[DollGrabMachineComp] State组件缺失";
				string item2 = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			ControllerBase<DollGrabMachineController>.Instance.RegisterDollGrabMachine(this);
			if (!Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnStateChange)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnStateChange));
			}
			return true;
		}

		// Token: 0x06044C7A RID: 281722 RVA: 0x011E1BB3 File Offset: 0x011DFDB3
		protected override void OnActivate()
		{
			if (!this.ActorComp.GetIsSceneInteractionLoadCompleted())
			{
				Singleton<EventSystem>.Instance.OnceWithTarget(base.Entity, EEventName.OnSceneInteractionShowCompleted, new Action(this.OnSceneInteractionLoadCompleted));
				return;
			}
			this.OnSceneInteractionLoadCompleted();
		}

		// Token: 0x06044C7B RID: 281723 RVA: 0x011E1BEC File Offset: 0x011DFDEC
		protected override bool OnEnd()
		{
			DgmClawStateController clawStateController = this.ClawStateController;
			if (clawStateController != null)
			{
				clawStateController.Dispose();
			}
			this.ClawStateController = null;
			this.DollItemMap.Clear();
			this.GrabbedItemList.Clear();
			this.GrabbingActorList.Clear();
			this.IsActiveInternal = false;
			ControllerBase<DollGrabMachineController>.Instance.UnregisterDollGrabMachine(this);
			this.LightActorGroup = new List<AActor>();
			this.GrabEffectTransform = null;
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnStateChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnStateChange));
			}
			if (this.EndlessDropTimer != null)
			{
				TimerSystem.Instance.Remove(this.EndlessDropTimer);
				this.EndlessDropTimer = null;
			}
			if (this.DissolveStartTimer != null)
			{
				TimerSystem.Instance.Remove(this.DissolveStartTimer);
				this.DissolveStartTimer = null;
			}
			if (this.DissolveCloseTimer != null)
			{
				TimerSystem.Instance.Remove(this.DissolveCloseTimer);
				this.DissolveCloseTimer = null;
			}
			return true;
		}

		// Token: 0x06044C7C RID: 281724 RVA: 0x011E1D01 File Offset: 0x011DFF01
		private void OnStateChange(int stateId, bool isReady)
		{
			this.CheckSceneItemState();
		}

		// Token: 0x06044C7D RID: 281725 RVA: 0x011E1D0C File Offset: 0x011DFF0C
		public void ExecuteTick(float deltaTime)
		{
			if (!this.IsActiveInternal)
			{
				DgmClawStateController clawStateController = this.ClawStateController;
				bool flag;
				if (clawStateController == null)
				{
					flag = true;
				}
				else
				{
					DgmClawBaseMoveState currentState = clawStateController.CurrentState;
					EDollGrabMachineClawState? edollGrabMachineClawState = (currentState != null) ? new EDollGrabMachineClawState?(currentState.ClawState) : null;
					EDollGrabMachineClawState edollGrabMachineClawState2 = EDollGrabMachineClawState.Idle;
					flag = !(edollGrabMachineClawState.GetValueOrDefault() == edollGrabMachineClawState2 & edollGrabMachineClawState != null);
				}
				if (!flag)
				{
					this.DisableTick();
					goto IL_72;
				}
			}
			DgmClawStateController clawStateController2 = this.ClawStateController;
			if (clawStateController2 != null)
			{
				DgmClawBaseMoveState currentState2 = clawStateController2.CurrentState;
				if (currentState2 != null)
				{
					currentState2.Update(deltaTime);
				}
			}
			IL_72:
			if (this.IsEndlessModeInternal && this.IsActiveInternal)
			{
				this.EndlessElapsedTime += deltaTime;
			}
		}

		// Token: 0x06044C7E RID: 281726 RVA: 0x011E1DA9 File Offset: 0x011DFFA9
		private bool IsTickEnabled()
		{
			return ControllerBase<DollGrabMachineController>.Instance.CheckRegisterTick(this);
		}

		// Token: 0x06044C7F RID: 281727 RVA: 0x011E1DB6 File Offset: 0x011DFFB6
		private void EnableTick()
		{
			if (!this.IsTickEnabled())
			{
				ControllerBase<DollGrabMachineController>.Instance.RegisterTick(this);
			}
		}

		// Token: 0x06044C80 RID: 281728 RVA: 0x011E1DCB File Offset: 0x011DFFCB
		private void DisableTick()
		{
			if (this.IsTickEnabled())
			{
				ControllerBase<DollGrabMachineController>.Instance.UnregisterTick(this);
			}
		}

		// Token: 0x06044C81 RID: 281729 RVA: 0x011E1DE0 File Offset: 0x011DFFE0
		private void OnSceneInteractionLoadCompleted()
		{
			this.InitDropTriggerActor();
			AActor referenceActor = this.ActorComp.GetReferenceActor("ItemsPool");
			if (referenceActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有娃娃物品池Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.DollItemPoolActor = referenceActor;
			}
			AActor referenceActor2 = this.ActorComp.GetReferenceActor("ConveyBelt");
			if (referenceActor2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有履带Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				TArray<AActor> tarray = new TArray<AActor>();
				referenceActor2.GetAttachedActors(ref tarray, true);
				foreach (AActor aactor in tarray)
				{
					BP_DollGrabMahcineConveyorBelt_C bp_DollGrabMahcineConveyorBelt_C = aactor as BP_DollGrabMahcineConveyorBelt_C;
					if (bp_DollGrabMahcineConveyorBelt_C != null)
					{
						this.ConveyorBeltActorList.Add(bp_DollGrabMahcineConveyorBelt_C);
						AKuroSplineConveyorBelt akuroSplineConveyorBelt = bp_DollGrabMahcineConveyorBelt_C;
						BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
						akuroSplineConveyorBelt.ConveyorSpeed = ((dollGrabMachineGlobalConfig != null) ? dollGrabMachineGlobalConfig.履带移动速度 : 0f);
						AKuroSplineConveyorBelt akuroSplineConveyorBelt2 = bp_DollGrabMahcineConveyorBelt_C;
						BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig2 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
						akuroSplineConveyorBelt2.ConveyorAdsorbDistance = ((dollGrabMachineGlobalConfig2 != null) ? dollGrabMachineGlobalConfig2.履带吸附距离 : 0f);
						AKuroSplineConveyorBelt akuroSplineConveyorBelt3 = bp_DollGrabMahcineConveyorBelt_C;
						BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig3 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
						akuroSplineConveyorBelt3.ConveyorAdsorbSpeed = ((dollGrabMachineGlobalConfig3 != null) ? dollGrabMachineGlobalConfig3.履带吸附速度 : 0f);
						AKuroSplineConveyorBelt akuroSplineConveyorBelt4 = bp_DollGrabMahcineConveyorBelt_C;
						BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig4 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
						akuroSplineConveyorBelt4.SetConveyorTriggerZScale((dollGrabMachineGlobalConfig4 != null) ? dollGrabMachineGlobalConfig4.履带TriggerZ轴缩放值 : 0f);
						UStaticMeshComponent ustaticMeshComponent = aactor.GetComponentByClass(UStaticMeshComponent.StaticClass()) as UStaticMeshComponent;
						if (ustaticMeshComponent != null)
						{
							ustaticMeshComponent.SetCollisionResponseToAllChannels(ECollisionResponse.ECR_Ignore);
							ustaticMeshComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_PhysicsBody, ECollisionResponse.ECR_Overlap);
						}
					}
				}
			}
			AActor referenceActor3 = this.ActorComp.GetReferenceActor("ConveyBeltCtrl");
			if (referenceActor3 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有履带MeshBp", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.ConveyorBeltMeshBpActor = (referenceActor3 as BP_ConveyorBelt_C);
				this.ConveyorBeltMeshBpActor.RunningSpeed = 0f;
			}
			AActor referenceActor4 = this.ActorComp.GetReferenceActor("CenterDissolve");
			if (referenceActor4 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有溶解Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.DissolveActor = (referenceActor4 as BP_CenterDissolvePosition_C);
			}
			AActor referenceActor5 = this.ActorComp.GetReferenceActor("BoundaryTriggerGroup");
			if (referenceActor5 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有包围盒Actor组", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				TArray<AActor> tarray2 = new TArray<AActor>();
				referenceActor5.GetAttachedActors(ref tarray2, true);
				int num = tarray2.Num();
				for (int i = 0; i < num; i++)
				{
					AActor aactor2 = tarray2.Get(i);
					aactor2.SetActorEnableCollision(false);
					this.BoundaryTriggerActorList.Add(aactor2);
				}
			}
			this.InitClawActor();
			this.InitDollItem();
			this.InitTeleportTriggerActor();
			if (this.IsEndlessModeInternal)
			{
				this.InitEndlessSpawnPoints();
			}
			this.InitLightGroup();
			this.CheckSceneItemState();
		}

		// Token: 0x06044C82 RID: 281730 RVA: 0x011E20CC File Offset: 0x011E02CC
		private void InitDropTriggerActor()
		{
			AActor referenceActor = this.ActorComp.GetReferenceActor("DropTriggerBox");
			if (referenceActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有投入口Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.DropTriggerActor = referenceActor;
			FVectorDouble fvectorDouble = referenceActor.D_K2_GetActorLocation();
			FTransformDouble value = new FTransformDouble();
			FVectorDouble fvectorDouble2 = new FVectorDouble(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z);
			BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
			FVector? fvector = (dollGrabMachineGlobalConfig != null) ? new FVector?(dollGrabMachineGlobalConfig.投出口特效偏移位置) : null;
			FQuat rotation;
			if (fvector != null)
			{
				global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
				rotation = this.ActorTransform.GetRotation();
				FVector value2 = fvector.Value;
				FVector fvector2 = rotation.RotateVector(value2);
				commonTempVector.FromUeVector(fvector2);
				fvectorDouble2.X += Singleton<MathUtils>.Instance.CommonTempVector.X;
				fvectorDouble2.Y += Singleton<MathUtils>.Instance.CommonTempVector.Y;
				fvectorDouble2.Z += Singleton<MathUtils>.Instance.CommonTempVector.Z;
			}
			value.SetLocation(fvectorDouble2);
			rotation = this.ActorTransform.GetRotation();
			value.SetRotation(rotation);
			this.GrabEffectTransform = new FTransformDouble?(value);
		}

		// Token: 0x06044C83 RID: 281731 RVA: 0x011E2220 File Offset: 0x011E0420
		private void InitLightGroup()
		{
			AActor referenceActor = this.ActorComp.GetReferenceActor("Lights");
			if (referenceActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有灯光组Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TArray<AActor> tarray = new TArray<AActor>();
			referenceActor.GetAttachedActors(ref tarray, true);
			for (int i = 0; i < tarray.Num(); i++)
			{
				AActor item = tarray.Get(i);
				this.LightActorGroup.Add(item);
			}
			AKuroLevelSequenceActor akuroLevelSequenceActor = Singleton<ActorSystem>.Instance.Get<AKuroLevelSequenceActor>(AKuroLevelSequenceActor.StaticClass(), this.ActorComp.ActorTransform, null, false);
			if (akuroLevelSequenceActor != null)
			{
				this.LightGroupSequenceActor = akuroLevelSequenceActor;
				this.SwitchLightGroup(EDollGrabMachineLightGroupState.Normal);
			}
		}

		// Token: 0x06044C84 RID: 281732 RVA: 0x011E22CC File Offset: 0x011E04CC
		private void InitTeleportTriggerActor()
		{
			AActor referenceActor = this.ActorComp.GetReferenceActor("RecycleGroup");
			if (referenceActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有传送门Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TArray<AActor> tarray = new TArray<AActor>();
			referenceActor.GetAttachedActors(ref tarray, true);
			foreach (AActor aactor in tarray)
			{
				TArray<AActor> tarray2 = new TArray<AActor>();
				aactor.GetAttachedActors(ref tarray2, true);
				if (tarray2.Count != 2)
				{
					Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体传送门Actor组包含的Actor数量不正确", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					foreach (AActor aactor2 in tarray2)
					{
						if (aactor2 is ATriggerBox)
						{
							this.TeleportTriggerActorList.Add(aactor2);
						}
						else
						{
							this.TeleportTargetLocationList.Add(aactor2.D_K2_GetActorLocation());
						}
					}
				}
			}
		}

		// Token: 0x06044C85 RID: 281733 RVA: 0x011E23F0 File Offset: 0x011E05F0
		private void InitClawActor()
		{
			AActor referenceActor = this.ActorComp.GetReferenceActor("Claw");
			if (referenceActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体抓钩Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.ClawActor = referenceActor;
			}
			AActor referenceActor2 = this.ActorComp.GetReferenceActor("ClawCtrl");
			if (referenceActor2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有钩爪根节点Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.ClawRootCtrlActor = referenceActor2;
			}
			AActor referenceActor3 = this.ActorComp.GetReferenceActor("Chain");
			if (referenceActor3 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有钩爪锁链Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.ClawChainActor = referenceActor3;
			}
			this.ClawStateController = new DgmClawStateController(this, this.ClawActor, this.ClawRootCtrlActor, this.ClawChainActor, this.ActorComp.ActorTransform);
			if (ModelBase<DollGrabModel>.Instance.DollGrabClawSequence != null)
			{
				this.ClawStateController.Init();
			}
			else
			{
				this.NeedInitClawStateController = true;
			}
			AActor referenceActor4 = this.ActorComp.GetReferenceActor("Roof");
			if (referenceActor4 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] 娃娃机实体没有屋顶Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.RoofActor = referenceActor4;
		}

		// Token: 0x06044C86 RID: 281734 RVA: 0x011E2539 File Offset: 0x011E0739
		public void OnClawSequenceLoaded()
		{
			if (this.NeedInitClawStateController && this.ClawStateController != null)
			{
				this.ClawStateController.Init();
			}
			this.NeedInitClawStateController = false;
		}

		// Token: 0x06044C87 RID: 281735 RVA: 0x011E2560 File Offset: 0x011E0760
		private void CheckSceneItemState()
		{
			if (this.StateComp != null && this.StateComp.State == SceneItemStateComponent.ESceneItemState.Completed)
			{
				this.SwitchLightGroup(EDollGrabMachineLightGroupState.Complete);
				foreach (DollGrabMachineItem dollGrabMachineItem in this.DollItemMap.Values)
				{
					this.ToggleEnableDollItemActor(dollGrabMachineItem.ItemActor, false, false, false);
				}
				if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]))
				{
					BaseTagComponent tagComp = this.TagComp;
					if (tagComp == null)
					{
						return;
					}
					tagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]));
					return;
				}
			}
			else if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]))
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 == null)
				{
					return;
				}
				tagComp2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]));
			}
		}

		// Token: 0x06044C88 RID: 281736 RVA: 0x011E2668 File Offset: 0x011E0868
		public void OnStartDollGrabMachine()
		{
			if (this.DropTriggerActor != null)
			{
				this.DropTriggerActor.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.OnDropTriggerActorBeginOverlap));
			}
			foreach (DollGrabMachineItem dollGrabMachineItem in this.DollItemMap.Values)
			{
				if (!this.GrabbedItemList.Contains(dollGrabMachineItem.ItemId))
				{
					this.ToggleEnableDollItemActor(dollGrabMachineItem.ItemActor, true, true, true);
				}
			}
			DgmClawStateController clawStateController = this.ClawStateController;
			bool flag;
			if (clawStateController == null)
			{
				flag = true;
			}
			else
			{
				DgmClawBaseMoveState currentState = clawStateController.CurrentState;
				if (currentState == null)
				{
					flag = true;
				}
				else
				{
					EDollGrabMachineClawState clawState = currentState.ClawState;
					flag = false;
				}
			}
			if (flag)
			{
				DgmClawStateController clawStateController2 = this.ClawStateController;
				if (clawStateController2 != null)
				{
					clawStateController2.SetTargetState(EDollGrabMachineClawState.Idle);
				}
			}
			this.IsActiveInternal = true;
			this.EnableTick();
			foreach (AActor aactor in this.TeleportTriggerActorList)
			{
				aactor.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.OnTeleportTriggerActorBeginOverlap));
			}
			foreach (AActor aactor2 in this.BoundaryTriggerActorList)
			{
				aactor2.SetActorEnableCollision(true);
				aactor2.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.OnBoundaryTriggerActorBeginOverlap));
			}
			this.EnableConveyorBelt(true);
			this.StartGameplayAudio();
			Singleton<AudioSystem>.Instance.SetState("ui_music_3_5_wawaji", "stage1", true);
			if (this.IsEndlessModeInternal)
			{
				this.StartEndlessDropTimer();
				this.EndlessRewardDataInternal.CurrentScore = 0;
				foreach (AActor aactor3 in this.EndlessAvailableSpawnPoints)
				{
					aactor3.SetActorEnableCollision(true);
					aactor3.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.OnEndlessSpawnPointActorBeginOverlap));
					aactor3.OnActorEndOverlap.Add(new Action<AActor, AActor>(this.OnEndlessSpawnPointActorEndOverlap));
				}
				this.StartEndlessAudioState();
			}
			if (this.RoofActor != null)
			{
				this.RoofActor.SetActorEnableCollision(false);
			}
			this.SwitchLightGroup(EDollGrabMachineLightGroupState.Playing);
			this.CurrentDropItemListInternal.Clear();
		}

		// Token: 0x06044C89 RID: 281737 RVA: 0x011E28C0 File Offset: 0x011E0AC0
		[NullableContext(1)]
		public void OnStopDollGrabMachine(DollGrabStopResponse response)
		{
			if (!this.IsMachineActive)
			{
				return;
			}
			if (this.DropTriggerActor != null)
			{
				this.DropTriggerActor.OnActorBeginOverlap.Remove(new Action<AActor, AActor>(this.OnDropTriggerActorBeginOverlap));
			}
			bool flag = this.LeaveDollCount == 0;
			foreach (DollGrabMachineItem dollGrabMachineItem in this.DollItemMap.Values)
			{
				if (this.GrabbedItemList.Contains(dollGrabMachineItem.ItemId))
				{
					if (dollGrabMachineItem.AddTime != null)
					{
						float? addTime = dollGrabMachineItem.AddTime;
						float num = 0f;
						if (addTime.GetValueOrDefault() > num & addTime != null)
						{
							this.GrabbedItemList.Remove(dollGrabMachineItem.ItemId);
						}
					}
				}
				else if (dollGrabMachineItem.ItemActor != null)
				{
					this.ToggleEnableDollItemActor(dollGrabMachineItem.ItemActor, !flag, false, false);
					FHitResult fhitResult = null;
					if (dollGrabMachineItem.OriginLocation != null)
					{
						AActor itemActor = dollGrabMachineItem.ItemActor;
						FTransformDouble actorTransform = this.ActorComp.ActorTransform;
						FVectorDouble fvectorDouble = dollGrabMachineItem.OriginLocation.ToUeVector(false);
						itemActor.D_K2_SetActorLocation(actorTransform.TransformPosition(fvectorDouble), false, ref fhitResult, true);
					}
					if (dollGrabMachineItem.OriginRotation != null)
					{
						dollGrabMachineItem.ItemActor.K2_SetActorRotation(dollGrabMachineItem.OriginRotation.ToUeRotator(), false);
					}
				}
			}
			this.StopClawTriggerOverlap();
			this.IsActiveInternal = false;
			this.IsPauseInternal = false;
			this.IsCacheCheckTouchAction = false;
			if (this.LeaveDollCount == 0)
			{
				this.SwitchLightGroup(EDollGrabMachineLightGroupState.Complete);
			}
			else
			{
				this.SwitchLightGroup(EDollGrabMachineLightGroupState.BeforePlay);
			}
			foreach (AActor aactor in this.TeleportTriggerActorList)
			{
				aactor.OnActorBeginOverlap.Remove(new Action<AActor, AActor>(this.OnTeleportTriggerActorBeginOverlap));
			}
			foreach (AActor aactor2 in this.BoundaryTriggerActorList)
			{
				aactor2.SetActorEnableCollision(false);
				aactor2.OnActorBeginOverlap.Remove(new Action<AActor, AActor>(this.OnBoundaryTriggerActorBeginOverlap));
			}
			this.EnableConveyorBelt(false);
			if (this.AkEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.AkEventHandle, EAudioActionType.Stop, null);
				this.AkEventHandle = -1;
			}
			this.ClawMoveDirectionInternal.X = 0f;
			this.ClawMoveDirectionInternal.Y = 0f;
			if (this.IsEndlessModeInternal)
			{
				if (this.EndlessDropTimer != null)
				{
					this.EndlessDropTimer.Remove();
				}
				this.EndlessDropTimer = null;
				this.EndlessElapsedTime = 0f;
				this.PendingDropItemInfoList.Clear();
				this.IsDropRefreshTime = false;
				this.ResetEndlessRewardData(response);
				foreach (AActor aactor3 in this.EndlessAvailableSpawnPoints)
				{
					aactor3.SetActorEnableCollision(false);
					aactor3.OnActorBeginOverlap.Remove(new Action<AActor, AActor>(this.OnEndlessSpawnPointActorBeginOverlap));
					aactor3.OnActorEndOverlap.Remove(new Action<AActor, AActor>(this.OnEndlessSpawnPointActorEndOverlap));
					this.EndlessAvailableSpawnPointsMap[aactor3].Clear();
				}
				this.RevertEndlessStartItem();
				this.StopEndlessAudioState();
			}
			if (this.RoofActor != null)
			{
				this.RoofActor.SetActorEnableCollision(true);
			}
			this.GrabbingActorList.Clear();
			DgmClawStateController clawStateController = this.ClawStateController;
			if (clawStateController == null)
			{
				return;
			}
			clawStateController.SetTargetState(EDollGrabMachineClawState.Reset);
		}

		// Token: 0x06044C8A RID: 281738 RVA: 0x011E2C60 File Offset: 0x011E0E60
		public void ChangeClawState(EDollGrabMachineClawState newState)
		{
			DgmClawStateController clawStateController = this.ClawStateController;
			if (clawStateController == null)
			{
				return;
			}
			clawStateController.SetTargetState(newState);
		}

		// Token: 0x06044C8B RID: 281739 RVA: 0x011E2C74 File Offset: 0x011E0E74
		public void StartClawTriggerOverlap()
		{
			if (this.ClawActor != null)
			{
				if (!this.ClawActor.OnActorBeginOverlap.IsBound())
				{
					this.ClawActor.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.OnClawTriggerActorBeginOverlap));
				}
				if (!this.ClawActor.OnActorEndOverlap.IsBound())
				{
					this.ClawActor.OnActorEndOverlap.Add(new Action<AActor, AActor>(this.OnClawTriggerActorEndOverlap));
				}
			}
		}

		// Token: 0x06044C8C RID: 281740 RVA: 0x011E2CE5 File Offset: 0x011E0EE5
		public void StopClawTriggerOverlap()
		{
			if (this.ClawActor != null)
			{
				this.ClawActor.OnActorBeginOverlap.Clear();
				this.ClawActor.OnActorEndOverlap.Clear();
			}
		}

		// Token: 0x06044C8D RID: 281741 RVA: 0x011E2D10 File Offset: 0x011E0F10
		private void OnClawTriggerActorBeginOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (overlappedActor == null || otherActor == null || !this.IsMachineActive)
			{
				return;
			}
			BP_DollActor_C bp_DollActor_C = otherActor as BP_DollActor_C;
			if (bp_DollActor_C == null)
			{
				return;
			}
			DollGrabMachineItem dollGrabMachineItem;
			this.DollItemMap.TryGetValue(bp_DollActor_C.Id, out dollGrabMachineItem);
			if (dollGrabMachineItem == null)
			{
				return;
			}
			this.GrabbingActorList.Add(bp_DollActor_C);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDollGrabMachineGrabbingActorChanged, this.HasGrabbingActor);
		}

		// Token: 0x06044C8E RID: 281742 RVA: 0x011E2D71 File Offset: 0x011E0F71
		private void OnClawTriggerActorEndOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (overlappedActor == null || otherActor == null)
			{
				return;
			}
			this.GrabbingActorList.Remove(otherActor);
			BP_DollActor_C bp_DollActor_C = otherActor as BP_DollActor_C;
			if (bp_DollActor_C != null)
			{
				bp_DollActor_C.TogglePlayIdleAnim(true);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDollGrabMachineGrabbingActorChanged, this.HasGrabbingActor);
		}

		// Token: 0x06044C8F RID: 281743 RVA: 0x011E2DB0 File Offset: 0x011E0FB0
		public void CheckTouchGetItemInClawTrigger()
		{
			if (!this.IsMachineActive)
			{
				if (this.IsPauseInternal)
				{
					this.IsCacheCheckTouchAction = true;
				}
				return;
			}
			List<DollGrabMachineItem> list = new List<DollGrabMachineItem>();
			foreach (AActor aactor in this.GrabbingActorList)
			{
				BP_DollActor_C bp_DollActor_C = aactor as BP_DollActor_C;
				if (bp_DollActor_C != null)
				{
					DollGrabMachineItem dollGrabMachineItem;
					this.DollItemMap.TryGetValue(bp_DollActor_C.Id, out dollGrabMachineItem);
					if (dollGrabMachineItem != null)
					{
						if (dollGrabMachineItem.IsTouchGet)
						{
							list.Add(dollGrabMachineItem);
						}
						bp_DollActor_C.TogglePlayGrabAnim(true, 1f);
					}
				}
			}
			foreach (DollGrabMachineItem dollGrabMachineItem2 in list)
			{
				this.ToggleEnableDollItemActor(dollGrabMachineItem2.ItemActor, false, false, false);
				this.NotifyDollGrabRequest(dollGrabMachineItem2, true);
			}
		}

		// Token: 0x1700A42B RID: 42027
		// (get) Token: 0x06044C90 RID: 281744 RVA: 0x011E2EA8 File Offset: 0x011E10A8
		public bool HasGrabbingActor
		{
			get
			{
				return this.GrabbingActorList.Count > 0;
			}
		}

		// Token: 0x1700A42C RID: 42028
		// (get) Token: 0x06044C91 RID: 281745 RVA: 0x011E2EB8 File Offset: 0x011E10B8
		[Nullable(1)]
		public DgmClawBaseMoveState ClawState
		{
			[NullableContext(1)]
			get
			{
				DgmClawStateController clawStateController = this.ClawStateController;
				if (clawStateController == null)
				{
					return null;
				}
				return clawStateController.CurrentState;
			}
		}

		// Token: 0x1700A42D RID: 42029
		// (get) Token: 0x06044C92 RID: 281746 RVA: 0x011E2ECB File Offset: 0x011E10CB
		// (set) Token: 0x06044C93 RID: 281747 RVA: 0x011E2ED3 File Offset: 0x011E10D3
		[Nullable(1)]
		public DollGrabMachineClawDirection ClawMoveDirection
		{
			[NullableContext(1)]
			get
			{
				return this.ClawMoveDirectionInternal;
			}
			[NullableContext(1)]
			set
			{
				this.ClawMoveDirectionInternal.X = value.X;
				this.ClawMoveDirectionInternal.Y = value.Y;
			}
		}

		// Token: 0x1700A42E RID: 42030
		// (get) Token: 0x06044C94 RID: 281748 RVA: 0x011E2EF7 File Offset: 0x011E10F7
		public AKuroLevelSequenceActor ClawAnimSeqActor
		{
			get
			{
				DgmClawStateController clawStateController = this.ClawStateController;
				if (clawStateController == null)
				{
					return null;
				}
				return clawStateController.ClawAnimSeqActor;
			}
		}

		// Token: 0x1700A42F RID: 42031
		// (get) Token: 0x06044C95 RID: 281749 RVA: 0x011E2F0C File Offset: 0x011E110C
		public EDollGrabMachineClawState? LastClawState
		{
			get
			{
				DgmClawStateController clawStateController = this.ClawStateController;
				if (clawStateController == null)
				{
					return null;
				}
				return clawStateController.LastState;
			}
		}

		// Token: 0x06044C96 RID: 281750 RVA: 0x011E2F34 File Offset: 0x011E1134
		private unsafe void InitDollItem()
		{
			if (this.DollItemPoolActor == null || this.Config == null || this.Config.Items.Count == 0)
			{
				return;
			}
			this.LeaveDollCountInternal = 0;
			bool flag = this.StateComp != null && this.StateComp.State == SceneItemStateComponent.ESceneItemState.Completed;
			TArray<AActor> tarray = new TArray<AActor>();
			this.DollItemPoolActor.GetAttachedActors(ref tarray, true);
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				BP_DollActor_C bp_DollActor_C = tarray.Get(i) as BP_DollActor_C;
				if (bp_DollActor_C != null)
				{
					int? num2 = null;
					foreach (IDollGrabItem dollGrabItem in this.Config.Items)
					{
						if (dollGrabItem.Id == bp_DollActor_C.Id)
						{
							num2 = new int?(dollGrabItem.ItemId);
							break;
						}
					}
					if (num2 == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.DollGrabMachine;
						ELogAuthor author = ELogAuthor.FJH;
						string message = "[DollGrabMachineComp] 娃娃实体物品配置缺失";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
						string item = "PbDataId";
						CreatureDataComponent creatureDataComp = this.CreatureDataComp;
						ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ItemId", bp_DollActor_C.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CategoryId", num2);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					}
					else
					{
						global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
						FTransformDouble actorTransform = this.ActorComp.ActorTransform;
						FVectorDouble fvectorDouble = bp_DollActor_C.D_K2_GetActorLocation();
						FVectorDouble fvectorDouble2 = actorTransform.InverseTransformPosition(fvectorDouble);
						commonTempVector.FromUeVector(fvectorDouble2);
						global::Rotator commonTempRotator = Singleton<MathUtils>.Instance.CommonTempRotator;
						FRotator frotator = bp_DollActor_C.K2_GetActorRotation();
						commonTempRotator.FromUeRotator(frotator);
						DollGrabMachineItem dollGrabMachineItem = new DollGrabMachineItem(bp_DollActor_C.Id, num2.Value, bp_DollActor_C, Singleton<MathUtils>.Instance.CommonTempVector, Singleton<MathUtils>.Instance.CommonTempRotator);
						this.DollItemMap[bp_DollActor_C.Id] = dollGrabMachineItem;
						if (this.CreatureDataComp.DollGrabMachineInfo != null && !this.CreatureDataComp.DollGrabMachineInfo.CanCapturedItems.Contains(bp_DollActor_C.Id) && !this.IsEndlessModeInternal)
						{
							this.ToggleEnableDollItemActor(bp_DollActor_C, false, false, false);
							this.GrabbedItemList.Add(bp_DollActor_C.Id);
						}
						else if (dollGrabMachineItem.AddTime == null)
						{
							this.LeaveDollCountInternal++;
							this.ToggleEnableDollItemActor(bp_DollActor_C, true, false, false);
						}
						else if (flag)
						{
							this.ToggleEnableDollItemActor(bp_DollActor_C, false, false, false);
						}
						bp_DollActor_C.SetPhysicsParameters(this.ItemRotationDamping, this.ItemMoveDamping);
						if (this.IsEndlessModeInternal)
						{
							dollGrabMachineItem.IsEndlessStartItem = true;
							this.SetDollActorEndlessMaterial(dollGrabMachineItem).Forget();
						}
						else if (dollGrabMachineItem.AddTime == null)
						{
							bp_DollActor_C.OnBeginPlay.Add(new Action<BP_DollActor_C>(this.OnDollActorBeginPlay));
						}
					}
				}
			}
		}

		// Token: 0x06044C97 RID: 281751 RVA: 0x011E325C File Offset: 0x011E145C
		private void OnDropTriggerActorBeginOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (overlappedActor == null || otherActor == null || !this.IsMachineActive)
			{
				return;
			}
			BP_DollActor_C bp_DollActor_C = otherActor as BP_DollActor_C;
			if (bp_DollActor_C == null)
			{
				return;
			}
			DollGrabMachineItem dollGrabMachineItem;
			this.DollItemMap.TryGetValue(bp_DollActor_C.Id, out dollGrabMachineItem);
			if (dollGrabMachineItem == null)
			{
				return;
			}
			if (this.GrabbedItemList.Contains(bp_DollActor_C.Id) || this.EndlessIdleItemIdList.Contains(bp_DollActor_C.Id))
			{
				return;
			}
			this.ToggleEnableDollItemActor(bp_DollActor_C, false, false, false);
			this.NotifyDollGrabRequest(dollGrabMachineItem, dollGrabMachineItem.IsTouchGet);
		}

		// Token: 0x06044C98 RID: 281752 RVA: 0x011E32DC File Offset: 0x011E14DC
		[NullableContext(1)]
		private void NotifyDollGrabRequest(DollGrabMachineItem itemInfo, bool isTimeBall = false)
		{
			if (isTimeBall)
			{
				DollGrabTimeBallRequest dollGrabTimeBallRequest = DollGrabTimeBallRequest.Create();
				dollGrabTimeBallRequest.EntityIncId = this.CreatureDataComp.GetCreatureDataId();
				dollGrabTimeBallRequest.ItemUniId = itemInfo.ItemId;
				if (itemInfo.AddTime != null)
				{
					float? addTime = itemInfo.AddTime;
					float num = 0f;
					if (!(addTime.GetValueOrDefault() <= num & addTime != null))
					{
						Singleton<Net>.Instance.Call<DollGrabTimeBallResponse>(ERequestMessageId.DollGrabTimeBallRequest, dollGrabTimeBallRequest, delegate(DollGrabTimeBallResponse response, Net.CallbackStatus _)
						{
							if (response == null)
							{
								return;
							}
							if (this.GrabbingActorList.Contains(itemInfo.ItemActor))
							{
								this.GrabbingActorList.Remove(itemInfo.ItemActor);
							}
							ErrorCode errorCode = response.ErrorCode;
							if (errorCode == ErrorCode.Success)
							{
								Singleton<EventSystem>.Instance.Emit<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, itemInfo.AddTime.Value * 1000f);
								if (this.IsEndlessModeInternal)
								{
									this.OnEndlessDollGrabResponse(itemInfo, isTimeBall);
								}
								else
								{
									this.GrabbedItemList.Add(itemInfo.ItemId);
								}
								itemInfo.ItemActor.PlayGrabEffect(this.IsEndlessModeInternal, itemInfo.ItemActor.D_K2_GetActorLocation());
								itemInfo.ItemActor.PlayTimeEffect();
								return;
							}
							if (errorCode == ErrorCode.ErrDollGarbTimeOut)
							{
								ControllerBase<DollGrabMachineController>.Instance.PreExitDollGrabMachine(EDollGrabMachineEndReason.TimeUp, false);
								return;
							}
							if (errorCode != ErrorCode.ErrDollGrabAlreadyPaused)
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.DollGrabMachine;
								ELogAuthor author = ELogAuthor.FJH;
								string message = "[DollGrabMachineComp] 抓取时间球请求失败";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
								instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
								return;
							}
							if (itemInfo.OriginLocation != null)
							{
								FHitResult fhitResult = null;
								AActor itemActor = itemInfo.ItemActor;
								FTransformDouble actorTransform = this.ActorComp.ActorTransform;
								FVectorDouble fvectorDouble = itemInfo.OriginLocation.ToUeVector(false);
								itemActor.D_K2_SetActorLocation(actorTransform.TransformPosition(fvectorDouble), false, ref fhitResult, true);
							}
							this.ToggleEnableDollItemActor(itemInfo.ItemActor, true, false, false);
							this.GrabbingActorList.Add(itemInfo.ItemActor);
						}, 0);
						return;
					}
				}
				return;
			}
			DollGrabRequest dollGrabRequest = DollGrabRequest.Create();
			dollGrabRequest.EntityIncId = this.CreatureDataComp.GetCreatureDataId();
			dollGrabRequest.ItemUniId = itemInfo.ItemId;
			Singleton<Net>.Instance.Call<DollGrabResponse>(ERequestMessageId.DollGrabRequest, dollGrabRequest, delegate(DollGrabResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				ErrorCode errorCode = response.ErrorCode;
				if (errorCode != ErrorCode.Success)
				{
					if (errorCode == ErrorCode.ErrDollGarbTimeOut)
					{
						ControllerBase<DollGrabMachineController>.Instance.PreExitDollGrabMachine(EDollGrabMachineEndReason.TimeUp, false);
						return;
					}
					if (errorCode == ErrorCode.ErrDollGrabAlreadyPaused)
					{
						if (itemInfo.OriginLocation != null)
						{
							FHitResult fhitResult = null;
							AActor itemActor = itemInfo.ItemActor;
							FTransformDouble actorTransform = this.ActorComp.ActorTransform;
							FVectorDouble fvectorDouble = itemInfo.OriginLocation.ToUeVector(false);
							itemActor.D_K2_SetActorLocation(actorTransform.TransformPosition(fvectorDouble), false, ref fhitResult, true);
						}
						this.ToggleEnableDollItemActor(itemInfo.ItemActor, true, false, false);
						return;
					}
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[DollGrabMachineComp] 投入物品请求失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					itemInfo.ItemActor.PlayGrabEffectByTransform(this.IsEndlessModeInternal, this.GrabEffectTransform.Value);
					if (this.IsEndlessModeInternal)
					{
						this.OnEndlessDollGrabResponse(itemInfo, isTimeBall);
						return;
					}
					this.GrabbedItemList.Add(itemInfo.ItemId);
					this.LeaveDollCountInternal--;
					List<IGrabItemData> list = new List<IGrabItemData>();
					foreach (DollGrabItemInfo dollGrabItemInfo in response.GrabItemInfos)
					{
						list.Add(new GrabItemData
						{
							ItemId = dollGrabItemInfo.ItemId,
							Count = dollGrabItemInfo.ItemCount
						});
						if (this.CurrentDropItemListInternal.ContainsKey(dollGrabItemInfo.ItemId))
						{
							this.CurrentDropItemListInternal[dollGrabItemInfo.ItemId] = this.CurrentDropItemListInternal[dollGrabItemInfo.ItemId] + dollGrabItemInfo.ItemCount;
						}
						else
						{
							this.CurrentDropItemListInternal[dollGrabItemInfo.ItemId] = dollGrabItemInfo.ItemCount;
						}
					}
					Singleton<EventSystem>.Instance.Emit<int, List<IGrabItemData>>(EEventName.OnDollGrabMachineGrabDoll, this.LeaveDollCountInternal, list);
					BP_DollActor_C itemActor2 = itemInfo.ItemActor;
					if (itemActor2 != null && itemActor2.MainDoll)
					{
						this.MainDollActorItem = itemInfo;
					}
					if (this.LeaveDollCountInternal <= 0)
					{
						ControllerBase<DollGrabMachineController>.Instance.PreExitDollGrabMachine(EDollGrabMachineEndReason.GetAll, false);
						return;
					}
				}
			}, 0);
		}

		// Token: 0x06044C99 RID: 281753 RVA: 0x011E33DA File Offset: 0x011E15DA
		[NullableContext(1)]
		private void ToggleEnableDollItemActor(BP_DollActor_C dollActor, bool toggleVisibility, bool togglePhysics, bool toggleIdleAnim)
		{
			dollActor.SetVisible(toggleVisibility, togglePhysics);
			if (!togglePhysics)
			{
				dollActor.K2_AttachToActor(this.DollItemPoolActor, null, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true);
			}
			if (toggleIdleAnim)
			{
				dollActor.TogglePlayIdleAnim(toggleIdleAnim);
			}
		}

		// Token: 0x06044C9A RID: 281754 RVA: 0x011E340C File Offset: 0x011E160C
		private void OnTeleportTriggerActorBeginOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (overlappedActor == null || otherActor == null)
			{
				return;
			}
			BP_DollActor_C bp_DollActor_C = otherActor as BP_DollActor_C;
			if (bp_DollActor_C == null)
			{
				return;
			}
			DollGrabMachineItem dollGrabMachineItem;
			this.DollItemMap.TryGetValue(bp_DollActor_C.Id, out dollGrabMachineItem);
			if (dollGrabMachineItem == null)
			{
				return;
			}
			int num = this.TeleportTriggerActorList.IndexOf(overlappedActor);
			if (num == -1 || this.TeleportTargetLocationList.Count <= num)
			{
				return;
			}
			FHitResult fhitResult = null;
			bp_DollActor_C.D_K2_SetActorLocation(this.TeleportTargetLocationList[num], false, ref fhitResult, true);
		}

		// Token: 0x06044C9B RID: 281755 RVA: 0x011E347C File Offset: 0x011E167C
		private void EnableConveyorBelt(bool enable)
		{
			if (this.ConveyorBeltActorList.Count == 0)
			{
				return;
			}
			foreach (BP_DollGrabMahcineConveyorBelt_C bp_DollGrabMahcineConveyorBelt_C in this.ConveyorBeltActorList)
			{
				bp_DollGrabMahcineConveyorBelt_C.ToggleEnableConveyorBelt(enable);
			}
			if (this.ConveyorBeltMeshBpActor != null)
			{
				this.ConveyorBeltMeshBpActor.RunningSpeed = (enable > false);
			}
			if (enable)
			{
				this.ConveyorBeltEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_conveyor_belt_loop");
			}
			else if (this.ConveyorBeltEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ConveyorBeltEventHandle, EAudioActionType.Stop, null);
				this.ConveyorBeltEventHandle = -1;
			}
			ModelBase<DollGrabModel>.Instance.ToggleCancelShadowCache(enable);
		}

		// Token: 0x06044C9C RID: 281756 RVA: 0x011E3544 File Offset: 0x011E1744
		private void InitEndlessSpawnPoints()
		{
			AActor referenceActor = this.ActorComp.GetReferenceActor("EndlessSpawnPoints");
			if (referenceActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp][无尽模式] 娃娃机无尽关实体没有掉落生成点Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TArray<AActor> tarray = new TArray<AActor>();
			referenceActor.GetAttachedActors(ref tarray, true);
			foreach (AActor aactor in tarray)
			{
				this.EndlessSpawnPoints[aactor] = aactor.D_K2_GetActorLocation();
				this.EndlessAvailableSpawnPoints.Add(aactor);
				this.EndlessAvailableSpawnPointsMap[aactor] = new HashSet<AActor>();
				aactor.SetActorEnableCollision(false);
			}
		}

		// Token: 0x06044C9D RID: 281757 RVA: 0x011E3604 File Offset: 0x011E1804
		private void OnEndlessSpawnPointActorBeginOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (overlappedActor == null || otherActor == null)
			{
				return;
			}
			if ((this.ClawStateController.CheckActorInClawPart(otherActor) || otherActor is BP_DollActor_C) && this.EndlessAvailableSpawnPoints.Contains(overlappedActor))
			{
				this.EndlessAvailableSpawnPointsMap[overlappedActor].Add(otherActor);
				this.EndlessAvailableSpawnPoints.Remove(overlappedActor);
			}
		}

		// Token: 0x06044C9E RID: 281758 RVA: 0x011E3664 File Offset: 0x011E1864
		private void OnEndlessSpawnPointActorEndOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (overlappedActor == null || otherActor == null)
			{
				return;
			}
			if (this.ClawStateController.CheckActorInClawPart(otherActor) || otherActor is BP_DollActor_C)
			{
				this.EndlessAvailableSpawnPointsMap[overlappedActor].Remove(otherActor);
			}
			if (!this.EndlessAvailableSpawnPoints.Contains(overlappedActor) && this.EndlessAvailableSpawnPointsMap[overlappedActor].Count == 0)
			{
				this.EndlessAvailableSpawnPoints.Add(overlappedActor);
			}
		}

		// Token: 0x06044C9F RID: 281759 RVA: 0x011E36D4 File Offset: 0x011E18D4
		[NullableContext(1)]
		private void OnEndlessDollGrabResponse(DollGrabMachineItem itemInfo, bool isTimeBall)
		{
			if (itemInfo.EndlessScore > 0)
			{
				this.EndlessRewardData.CurrentScore += itemInfo.EndlessScore;
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnDollGrabMachineEndlessScoreChanged, this.EndlessRewardData.CurrentScore, itemInfo.EndlessScore);
			}
			int randomItem = Singleton<MathUtils>.Instance.GetRandomItem<int>(this.EndlessIdleItemIdList);
			DollGrabMachineItem dollGrabMachineItem;
			this.EndlessIdleItemPool.TryGetValue(randomItem, out dollGrabMachineItem);
			if (dollGrabMachineItem == null)
			{
				return;
			}
			if (this.IsDropRefreshTime)
			{
				this.SpawnEndlessDollItemActor(dollGrabMachineItem);
				this.IsDropRefreshTime = false;
				this.StartEndlessDropTimer();
			}
			else
			{
				this.PendingDropItemInfoList.Add(dollGrabMachineItem);
			}
			this.EndlessIdleItemPool.Remove(randomItem);
			this.EndlessIdleItemIdList.Remove(randomItem);
			this.EndlessIdleItemPool[itemInfo.ItemId] = itemInfo;
			this.EndlessIdleItemIdList.Add(itemInfo.ItemId);
			this.DollItemMap.Remove(itemInfo.ItemId);
			this.DollItemMap[randomItem] = dollGrabMachineItem;
		}

		// Token: 0x06044CA0 RID: 281760 RVA: 0x011E37D0 File Offset: 0x011E19D0
		[NullableContext(1)]
		private void SpawnEndlessDollItemActor(DollGrabMachineItem itemInfo)
		{
			AActor randomItem = Singleton<MathUtils>.Instance.GetRandomItem<AActor>(this.EndlessAvailableSpawnPoints);
			if (randomItem == null)
			{
				return;
			}
			FVectorDouble newLocation;
			if (!this.EndlessSpawnPoints.TryGetValue(randomItem, out newLocation))
			{
				return;
			}
			FTransformDouble transform = new FTransformDouble();
			transform.SetLocation(newLocation);
			if (itemInfo.ItemActor == null)
			{
				UClass uclass = Singleton<ResourceSystem>.Instance.Load<UClass>(itemInfo.ItemBpPath, "js_undefined");
				if (uclass == null)
				{
					return;
				}
				BP_DollActor_C bp_DollActor_C = Singleton<ActorSystem>.Instance.Spawn(uclass.ClassStackOnlyPtr, transform, this.ActorComp.Owner) as BP_DollActor_C;
				if (bp_DollActor_C == null || !bp_DollActor_C.IsValid())
				{
					return;
				}
				itemInfo.ItemActor = bp_DollActor_C;
				bp_DollActor_C.Id = itemInfo.ItemId;
				bp_DollActor_C.K2_AttachToActor(this.DollItemPoolActor, null, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true);
			}
			else
			{
				FHitResult fhitResult = null;
				itemInfo.ItemActor.D_K2_SetActorLocation(newLocation, false, ref fhitResult, true);
			}
			itemInfo.ItemActor.PlaySpawnEffect();
			this.ToggleEnableDollItemActor(itemInfo.ItemActor, true, true, true);
		}

		// Token: 0x06044CA1 RID: 281761 RVA: 0x011E38C4 File Offset: 0x011E1AC4
		private void StartEndlessDropTimer()
		{
			if (this.EndlessDropTimer != null || this.RefreshIntervalCurve == null)
			{
				return;
			}
			float floatValue = this.RefreshIntervalCurve.GetFloatValue(this.EndlessElapsedTime * 0.001f);
			TTimerAction ttimerAction = delegate(float delta)
			{
				this.IsDropRefreshTime = true;
				this.EndlessDropTimer = null;
				if (this.PendingDropItemInfoList.Count > 0)
				{
					DollGrabMachineItem itemInfo = this.PendingDropItemInfoList.Shift<DollGrabMachineItem>();
					this.SpawnEndlessDollItemActor(itemInfo);
					this.IsDropRefreshTime = false;
					this.StartEndlessDropTimer();
				}
			};
			if (floatValue <= 0f)
			{
				ttimerAction(0f);
				return;
			}
			this.EndlessDropTimer = TimerSystem.Instance.Delay(ttimerAction, floatValue * 1000f, null, null, true, 1f);
		}

		// Token: 0x06044CA2 RID: 281762 RVA: 0x011E393C File Offset: 0x011E1B3C
		private void RevertEndlessStartItem()
		{
			if (!this.IsEndlessModeInternal)
			{
				return;
			}
			FHitResult fhitResult = null;
			List<int> list = new List<int>();
			foreach (DollGrabMachineItem dollGrabMachineItem in this.DollItemMap.Values)
			{
				if (dollGrabMachineItem.IsEndlessStartItem)
				{
					this.ToggleEnableDollItemActor(dollGrabMachineItem.ItemActor, true, false, false);
					if (dollGrabMachineItem.OriginLocation != null)
					{
						AActor itemActor = dollGrabMachineItem.ItemActor;
						FTransformDouble actorTransform = this.ActorComp.ActorTransform;
						FVectorDouble fvectorDouble = dollGrabMachineItem.OriginLocation.ToUeVector(false);
						itemActor.D_K2_SetActorLocation(actorTransform.TransformPosition(fvectorDouble), false, ref fhitResult, true);
					}
					if (dollGrabMachineItem.OriginRotation != null)
					{
						dollGrabMachineItem.ItemActor.K2_SetActorRotation(dollGrabMachineItem.OriginRotation.ToUeRotator(), false);
					}
				}
				else
				{
					if (dollGrabMachineItem.ItemActor != null)
					{
						this.ToggleEnableDollItemActor(dollGrabMachineItem.ItemActor, false, false, false);
					}
					this.EndlessIdleItemPool[dollGrabMachineItem.ItemId] = dollGrabMachineItem;
					this.EndlessIdleItemIdList.Add(dollGrabMachineItem.ItemId);
					list.Add(dollGrabMachineItem.ItemId);
				}
			}
			foreach (int key in list)
			{
				this.DollItemMap.Remove(key);
			}
			list.Clear();
			foreach (DollGrabMachineItem dollGrabMachineItem2 in this.EndlessIdleItemPool.Values)
			{
				if (dollGrabMachineItem2.IsEndlessStartItem)
				{
					this.ToggleEnableDollItemActor(dollGrabMachineItem2.ItemActor, true, false, false);
					AActor itemActor2 = dollGrabMachineItem2.ItemActor;
					FTransformDouble actorTransform = this.ActorComp.ActorTransform;
					FVectorDouble fvectorDouble = dollGrabMachineItem2.OriginLocation.ToUeVector(false);
					itemActor2.D_K2_SetActorLocation(actorTransform.TransformPosition(fvectorDouble), false, ref fhitResult, true);
					if (dollGrabMachineItem2.OriginRotation != null)
					{
						dollGrabMachineItem2.ItemActor.K2_SetActorRotation(dollGrabMachineItem2.OriginRotation.ToUeRotator(), false);
					}
					this.DollItemMap[dollGrabMachineItem2.ItemId] = dollGrabMachineItem2;
					this.EndlessIdleItemIdList.Remove(dollGrabMachineItem2.ItemId);
					list.Add(dollGrabMachineItem2.ItemId);
				}
			}
			foreach (int key2 in list)
			{
				this.EndlessIdleItemPool.Remove(key2);
			}
		}

		// Token: 0x06044CA3 RID: 281763 RVA: 0x011E3BE4 File Offset: 0x011E1DE4
		private void StartEndlessAudioState()
		{
			foreach (EndlessAudioStateInfo endlessAudioStateInfo in this.EndlessAudioDataInternal.Values)
			{
				endlessAudioStateInfo.StartAudio();
			}
		}

		// Token: 0x06044CA4 RID: 281764 RVA: 0x011E3C3C File Offset: 0x011E1E3C
		private void StopEndlessAudioState()
		{
			foreach (EndlessAudioStateInfo endlessAudioStateInfo in this.EndlessAudioDataInternal.Values)
			{
				endlessAudioStateInfo.StopAudio();
			}
		}

		// Token: 0x06044CA5 RID: 281765 RVA: 0x011E3C94 File Offset: 0x011E1E94
		private void PauseEndlessAudioState()
		{
			foreach (EndlessAudioStateInfo endlessAudioStateInfo in this.EndlessAudioDataInternal.Values)
			{
				endlessAudioStateInfo.PauseAudio();
			}
			if (this.AkEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.AkEventHandle, EAudioActionType.Pause, null);
			}
		}

		// Token: 0x06044CA6 RID: 281766 RVA: 0x011E3D0C File Offset: 0x011E1F0C
		private void ResumeEndlessAudioState()
		{
			foreach (EndlessAudioStateInfo endlessAudioStateInfo in this.EndlessAudioDataInternal.Values)
			{
				endlessAudioStateInfo.ResumeAudio();
			}
			if (this.AkEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.AkEventHandle, EAudioActionType.Resume, null);
			}
		}

		// Token: 0x06044CA7 RID: 281767 RVA: 0x011E3D84 File Offset: 0x011E1F84
		private void StartGameplayAudio()
		{
			if (!this.IsMachineActive || string.IsNullOrEmpty(this.AkEvent))
			{
				return;
			}
			if (this.AkEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.AkEventHandle, EAudioActionType.Stop, null);
			}
			this.AkEventHandle = Singleton<AudioSystem>.Instance.PostEvent(this.AkEvent, this.ActorComp.Owner, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.EndOfEvent && this.IsMachineActive)
					{
						this.StartGameplayAudio();
					}
				}
			}));
		}

		// Token: 0x06044CA8 RID: 281768 RVA: 0x011E3E1C File Offset: 0x011E201C
		public void StartDissolve()
		{
			if (this.DissolveActor == null || this.DissolveRadius <= 0f || this.DissolvePerSecond <= 0f || this.DissolveActor.DissolveRadius >= this.DissolveRadius || this.DissolveStartTimer != null)
			{
				return;
			}
			if (this.DissolveCloseTimer != null)
			{
				TimerSystem.Instance.Remove(this.DissolveCloseTimer);
				this.DissolveCloseTimer = null;
			}
			this.DissolveStartTimer = TimerSystem.Instance.Forever(delegate(float delta)
			{
				if (this.DissolveProgress >= this.DissolveRadius)
				{
					TimerSystem.Instance.Remove(this.DissolveStartTimer);
					this.DissolveStartTimer = null;
					return;
				}
				this.DissolveProgress += delta * this.DissolvePerSecond;
				this.DissolveProgress = Math.Min(this.DissolveProgress, this.DissolveRadius);
				this.DissolveActor.DissolveRadius = this.DissolveProgress;
			}, 20f, 1f, null, null, true);
			this.RoofDissolveEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_interact_crane_game_roof_melting");
			if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.进行中"]))
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.进行中"]));
				}
			}
			if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]))
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 != null)
				{
					tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]));
				}
			}
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			ControllerBase<FormationDataController>.Instance.AddPlayerTag(playerId, new int?(GameplayTagDefine.EGameplayTagId["系统.功能.休闲待机.禁用休闲待机"]));
			this.SwitchLightGroup(EDollGrabMachineLightGroupState.BeforePlay);
			foreach (DollGrabMachineItem dollGrabMachineItem in this.DollItemMap.Values)
			{
				if (dollGrabMachineItem.AddTime != null)
				{
					float? addTime = dollGrabMachineItem.AddTime;
					float num = 0f;
					if (addTime.GetValueOrDefault() > num & addTime != null)
					{
						this.ToggleEnableDollItemActor(dollGrabMachineItem.ItemActor, true, false, false);
					}
				}
			}
		}

		// Token: 0x06044CA9 RID: 281769 RVA: 0x011E3FFC File Offset: 0x011E21FC
		public void StopDissolve()
		{
			if (this.DissolveActor == null || this.DissolveRadius <= 0f || this.DissolvePerSecond <= 0f || this.DissolveActor.DissolveRadius <= 0f || this.DissolveCloseTimer != null)
			{
				return;
			}
			if (this.DissolveStartTimer != null)
			{
				this.DissolveStartTimer.Remove();
				this.DissolveStartTimer = null;
			}
			this.DissolveCloseTimer = TimerSystem.Instance.Forever(delegate(float delta)
			{
				if (this.DissolveProgress <= 0f)
				{
					TimerSystem.Instance.Remove(this.DissolveCloseTimer);
					this.DissolveCloseTimer = null;
					return;
				}
				this.DissolveProgress -= delta * this.DissolvePerSecond;
				this.DissolveProgress = Math.Max(this.DissolveProgress, 0f);
				this.DissolveActor.DissolveRadius = this.DissolveProgress;
			}, 20f, 1f, null, null, true);
			if (this.RoofDissolveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.RoofDissolveEventHandle, EAudioActionType.Stop, null);
				this.RoofDissolveEventHandle = -1;
			}
			if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.进行中"]))
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.进行中"]));
				}
			}
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			ControllerBase<FormationDataController>.Instance.RemovePlayerTag(playerId, new int?(GameplayTagDefine.EGameplayTagId["系统.功能.休闲待机.禁用休闲待机"]));
			if (this.StateComp != null && this.StateComp.State != SceneItemStateComponent.ESceneItemState.Completed)
			{
				this.SwitchLightGroup(EDollGrabMachineLightGroupState.Normal);
				if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]))
				{
					BaseTagComponent tagComp2 = this.TagComp;
					if (tagComp2 != null)
					{
						tagComp2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.娃娃机.常态"]));
					}
				}
			}
			foreach (DollGrabMachineItem dollGrabMachineItem in this.DollItemMap.Values)
			{
				if (dollGrabMachineItem.AddTime != null)
				{
					float? addTime = dollGrabMachineItem.AddTime;
					float num = 0f;
					if (addTime.GetValueOrDefault() > num & addTime != null)
					{
						this.ToggleEnableDollItemActor(dollGrabMachineItem.ItemActor, false, false, false);
					}
				}
			}
		}

		// Token: 0x06044CAA RID: 281770 RVA: 0x011E4204 File Offset: 0x011E2404
		public void PauseDollGrabMachine()
		{
			if (!this.IsActiveInternal)
			{
				return;
			}
			this.IsActiveInternal = false;
			this.IsPauseInternal = true;
			foreach (BP_DollGrabMahcineConveyorBelt_C bp_DollGrabMahcineConveyorBelt_C in this.ConveyorBeltActorList)
			{
				bp_DollGrabMahcineConveyorBelt_C.ToggleEnableConveyorBelt(false);
			}
			if (this.ConveyorBeltEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ConveyorBeltEventHandle, EAudioActionType.Stop, null);
				this.ConveyorBeltEventHandle = -1;
			}
			DgmClawStateController clawStateController = this.ClawStateController;
			if (((clawStateController != null) ? clawStateController.CurrentState : null) != null)
			{
				this.ClawStateController.CurrentState.Pause();
			}
			using (Dictionary<int, DollGrabMachineItem>.ValueCollection.Enumerator enumerator2 = this.DollItemMap.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					DollGrabMachineItem itemInfo = enumerator2.Current;
					if (itemInfo.ItemActor != null && !this.GrabbedItemList.Contains(itemInfo.ItemId) && this.PendingDropItemInfoList.Find((DollGrabMachineItem item) => item.ItemId == itemInfo.ItemId) == null)
					{
						this.ToggleEnableDollItemActor(itemInfo.ItemActor, true, false, false);
					}
				}
			}
			if (this.EndlessDropTimer != null && this.EndlessDropTimer.Valid())
			{
				this.EndlessDropTimer.Pause();
			}
			this.PauseEndlessAudioState();
		}

		// Token: 0x06044CAB RID: 281771 RVA: 0x011E4380 File Offset: 0x011E2580
		public void ResumeDollGrabMachine()
		{
			this.IsActiveInternal = true;
			this.IsPauseInternal = false;
			foreach (BP_DollGrabMahcineConveyorBelt_C bp_DollGrabMahcineConveyorBelt_C in this.ConveyorBeltActorList)
			{
				bp_DollGrabMahcineConveyorBelt_C.ToggleEnableConveyorBelt(true);
			}
			if (this.ConveyorBeltEventHandle <= 0)
			{
				this.ConveyorBeltEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_conveyor_belt_loop");
			}
			DgmClawStateController clawStateController = this.ClawStateController;
			if (((clawStateController != null) ? clawStateController.CurrentState : null) != null)
			{
				this.ClawStateController.CurrentState.Resume();
			}
			using (Dictionary<int, DollGrabMachineItem>.ValueCollection.Enumerator enumerator2 = this.DollItemMap.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					DollGrabMachineItem itemInfo = enumerator2.Current;
					if (itemInfo.ItemActor != null && !this.GrabbedItemList.Contains(itemInfo.ItemId) && this.PendingDropItemInfoList.Find((DollGrabMachineItem item) => item.ItemId == itemInfo.ItemId) == null)
					{
						this.ToggleEnableDollItemActor(itemInfo.ItemActor, true, true, true);
					}
				}
			}
			if (this.IsCacheCheckTouchAction)
			{
				this.CheckTouchGetItemInClawTrigger();
				this.IsCacheCheckTouchAction = false;
			}
			if (this.EndlessDropTimer != null && this.EndlessDropTimer.Valid())
			{
				this.EndlessDropTimer.Resume();
			}
			this.ResumeEndlessAudioState();
		}

		// Token: 0x06044CAC RID: 281772 RVA: 0x011E44FC File Offset: 0x011E26FC
		private void OnBoundaryTriggerActorBeginOverlap(AActor overlappedActor, AActor otherActor)
		{
			if (overlappedActor == null || otherActor == null)
			{
				return;
			}
			BP_DollActor_C bp_DollActor_C = otherActor as BP_DollActor_C;
			if (bp_DollActor_C == null)
			{
				return;
			}
			DollGrabMachineItem dollGrabMachineItem;
			this.DollItemMap.TryGetValue(bp_DollActor_C.Id, out dollGrabMachineItem);
			if (dollGrabMachineItem == null)
			{
				return;
			}
			FTransformDouble actorTransform = this.ActorComp.ActorTransform;
			FVectorDouble fvectorDouble = dollGrabMachineItem.OriginLocation.ToUeVector(false);
			FVectorDouble newLocation = actorTransform.TransformPosition(fvectorDouble);
			newLocation.Z += 200.0;
			dollGrabMachineItem.ItemActor.ResetPhysics();
			FHitResult fhitResult = null;
			dollGrabMachineItem.ItemActor.D_K2_SetActorLocation(newLocation, false, ref fhitResult, true);
		}

		// Token: 0x06044CAD RID: 281773 RVA: 0x011E458C File Offset: 0x011E278C
		public void SwitchLightGroup(EDollGrabMachineLightGroupState state)
		{
			ULevelSequence sequence;
			if (!ModelBase<DollGrabModel>.Instance.LightGroupSequenceMap.TryGetValue(state, out sequence))
			{
				return;
			}
			ULevelSequencePlayer sequencePlayer = this.LightGroupSequenceActor.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsPlaying())
			{
				ULevelSequencePlayer sequencePlayer2 = this.LightGroupSequenceActor.SequencePlayer;
				if (sequencePlayer2 != null)
				{
					sequencePlayer2.Stop();
				}
			}
			TArray<AActor> tarray = new TArray<AActor>();
			this.LightGroupSequenceActor.SetSequence(sequence);
			foreach (AActor aactor in this.LightActorGroup)
			{
				tarray.Add(aactor);
				this.LightGroupSequenceActor.SetBindingByTag(aactor.Tags.Get(0), tarray, false, false);
				tarray.Empty(true);
			}
			ULevelSequencePlayer sequencePlayer3 = this.LightGroupSequenceActor.SequencePlayer;
			if (sequencePlayer3 == null)
			{
				return;
			}
			sequencePlayer3.Play();
		}

		// Token: 0x06044CAE RID: 281774 RVA: 0x011E466C File Offset: 0x011E286C
		[NullableContext(1)]
		private void ResetEndlessRewardData(DollGrabStopResponse response)
		{
			this.EndlessRewardData.CurrentScore = response.SessionScore;
			this.EndlessRewardData.CurrentAccumulatedScore = response.AccumulatedScore;
			this.EndlessRewardData.HighestScore = response.HighScore;
			this.EndlessRewardData.IsFirstGetReward = false;
			if (this.EndlessRewardData.CurrentAccumulatedScore >= this.EndlessRewardData.TargetAccumulatedScore && !this.EndlessRewardData.IsFinalReward)
			{
				this.EndlessRewardData.IsFinalReward = true;
				this.EndlessRewardData.IsFirstGetReward = true;
			}
		}

		// Token: 0x06044CAF RID: 281775 RVA: 0x011E46F8 File Offset: 0x011E28F8
		[NullableContext(1)]
		private UniTask SetDollActorEndlessMaterial(DollGrabMachineItem itemInfo)
		{
			SceneItemDollGrabMachineComponent.<SetDollActorEndlessMaterial>d__141 <SetDollActorEndlessMaterial>d__;
			<SetDollActorEndlessMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetDollActorEndlessMaterial>d__.itemInfo = itemInfo;
			<SetDollActorEndlessMaterial>d__.<>1__state = -1;
			<SetDollActorEndlessMaterial>d__.<>t__builder.Start<SceneItemDollGrabMachineComponent.<SetDollActorEndlessMaterial>d__141>(ref <SetDollActorEndlessMaterial>d__);
			return <SetDollActorEndlessMaterial>d__.<>t__builder.Task;
		}

		// Token: 0x06044CB0 RID: 281776 RVA: 0x011E473C File Offset: 0x011E293C
		public void ToggleShowMainDollActor(bool toggle, bool canClear)
		{
			if (this.MainDollActorItem == null)
			{
				return;
			}
			if (toggle)
			{
				this.ToggleEnableDollItemActor(this.MainDollActorItem.ItemActor, true, false, false);
				BP_DollActor_C itemActor = this.MainDollActorItem.ItemActor;
				bool toggle2 = true;
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				itemActor.TogglePlayShow(toggle2, (dollGrabMachineGlobalConfig != null) ? dollGrabMachineGlobalConfig.展示动画播放速率 : 1f);
			}
			else
			{
				FHitResult fhitResult = null;
				AActor itemActor2 = this.MainDollActorItem.ItemActor;
				FTransformDouble actorTransform = this.ActorComp.ActorTransform;
				FVectorDouble fvectorDouble = this.MainDollActorItem.OriginLocation.ToUeVector(false);
				itemActor2.D_K2_SetActorLocation(actorTransform.TransformPosition(fvectorDouble), false, ref fhitResult, true);
				this.MainDollActorItem.ItemActor.TogglePlayShow(false, 1f);
				this.ToggleEnableDollItemActor(this.MainDollActorItem.ItemActor, false, false, false);
			}
			if (canClear)
			{
				this.MainDollActorItem = null;
			}
		}

		// Token: 0x06044CB1 RID: 281777 RVA: 0x011E4808 File Offset: 0x011E2A08
		private void OnDollActorBeginPlay(BP_DollActor_C actor)
		{
			Singleton<Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineComp] OnDollActorBeginPlay", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (actor == null || this.IsActiveInternal)
			{
				return;
			}
			if (this.GrabbedItemList.Contains(actor.Id))
			{
				this.ToggleEnableDollItemActor(actor, false, false, false);
				return;
			}
			this.ToggleEnableDollItemActor(actor, true, false, false);
		}

		// Token: 0x06044CB2 RID: 281778 RVA: 0x011E4868 File Offset: 0x011E2A68
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemDollGrabMachineComponent sceneItemDollGrabMachineComponent = (SceneItemDollGrabMachineComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemDollGrabMachineComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemDollGrabMachineComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (sceneItemDollGrabMachineComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (sceneItemDollGrabMachineComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemDollGrabMachineComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DollGrabMachineComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClawActor"))
			{
				if (sceneItemDollGrabMachineComponent.ClawActor == null)
				{
					this.ClawActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.ClawActor), "ClawActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClawRootCtrlActor"))
			{
				if (sceneItemDollGrabMachineComponent.ClawRootCtrlActor == null)
				{
					this.ClawRootCtrlActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.ClawRootCtrlActor), "ClawRootCtrlActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClawChainActor"))
			{
				if (sceneItemDollGrabMachineComponent.ClawChainActor == null)
				{
					this.ClawChainActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.ClawChainActor), "ClawChainActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DropTriggerActor"))
			{
				if (sceneItemDollGrabMachineComponent.DropTriggerActor == null)
				{
					this.DropTriggerActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.DropTriggerActor), "DropTriggerActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DollItemPoolActor"))
			{
				if (sceneItemDollGrabMachineComponent.DollItemPoolActor == null)
				{
					this.DollItemPoolActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.DollItemPoolActor), "DollItemPoolActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TeleportTriggerActorList") && sceneItemDollGrabMachineComponent.TeleportTriggerActorList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.TeleportTriggerActorList), "TeleportTriggerActorList"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TeleportTargetLocationList") && sceneItemDollGrabMachineComponent.TeleportTargetLocationList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<FVectorDouble>>(this.TeleportTargetLocationList), "TeleportTargetLocationList"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ConveyorBeltActorList") && sceneItemDollGrabMachineComponent.ConveyorBeltActorList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<BP_DollGrabMahcineConveyorBelt_C>>(this.ConveyorBeltActorList), "ConveyorBeltActorList"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ConveyorBeltMeshBpActor"))
			{
				if (sceneItemDollGrabMachineComponent.ConveyorBeltMeshBpActor == null)
				{
					this.ConveyorBeltMeshBpActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_ConveyorBelt_C>(this.ConveyorBeltMeshBpActor), "ConveyorBeltMeshBpActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DissolveActor"))
			{
				if (sceneItemDollGrabMachineComponent.DissolveActor == null)
				{
					this.DissolveActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_CenterDissolvePosition_C>(this.DissolveActor), "DissolveActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BoundaryTriggerActorList") && sceneItemDollGrabMachineComponent.BoundaryTriggerActorList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.BoundaryTriggerActorList), "BoundaryTriggerActorList"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("RoofActor"))
			{
				if (sceneItemDollGrabMachineComponent.RoofActor == null)
				{
					this.RoofActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.RoofActor), "RoofActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LightActorGroup"))
			{
				if (sceneItemDollGrabMachineComponent.LightActorGroup == null)
				{
					this.LightActorGroup = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.LightActorGroup), "LightActorGroup"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClawStateController"))
			{
				if (sceneItemDollGrabMachineComponent.ClawStateController == null)
				{
					this.ClawStateController = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DgmClawStateController>(this.ClawStateController), "ClawStateController"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClawMoveDirectionInternal") && sceneItemDollGrabMachineComponent.ClawMoveDirectionInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<DollGrabMachineClawDirection>(this.ClawMoveDirectionInternal), "ClawMoveDirectionInternal"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("NeedInitClawStateController"))
			{
				this.NeedInitClawStateController = sceneItemDollGrabMachineComponent.NeedInitClawStateController;
			}
			if (base.CanResetComponentProperty("DollItemMap"))
			{
				if (sceneItemDollGrabMachineComponent.DollItemMap == null)
				{
					this.DollItemMap = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, DollGrabMachineItem>>(this.DollItemMap), "DollItemMap"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("GrabbedItemList"))
			{
				if (sceneItemDollGrabMachineComponent.GrabbedItemList == null)
				{
					this.GrabbedItemList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<int>>(this.GrabbedItemList), "GrabbedItemList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("GrabbingActorList"))
			{
				if (sceneItemDollGrabMachineComponent.GrabbingActorList == null)
				{
					this.GrabbingActorList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.GrabbingActorList), "GrabbingActorList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LeaveDollCountInternal"))
			{
				this.LeaveDollCountInternal = sceneItemDollGrabMachineComponent.LeaveDollCountInternal;
			}
			if (base.CanResetComponentProperty("CurrentDropItemListInternal") && sceneItemDollGrabMachineComponent.CurrentDropItemListInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, int>>(this.CurrentDropItemListInternal), "CurrentDropItemListInternal"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("IsActiveInternal"))
			{
				this.IsActiveInternal = sceneItemDollGrabMachineComponent.IsActiveInternal;
			}
			if (base.CanResetComponentProperty("IsPauseInternal"))
			{
				this.IsPauseInternal = sceneItemDollGrabMachineComponent.IsPauseInternal;
			}
			if (base.CanResetComponentProperty("IsCacheCheckTouchAction"))
			{
				this.IsCacheCheckTouchAction = sceneItemDollGrabMachineComponent.IsCacheCheckTouchAction;
			}
			if (base.CanResetComponentProperty("AkEvent"))
			{
				this.AkEvent = sceneItemDollGrabMachineComponent.AkEvent;
			}
			if (base.CanResetComponentProperty("AkEventHandle"))
			{
				this.AkEventHandle = sceneItemDollGrabMachineComponent.AkEventHandle;
			}
			if (base.CanResetComponentProperty("GrabEffectTransform"))
			{
				this.GrabEffectTransform = sceneItemDollGrabMachineComponent.GrabEffectTransform;
			}
			if (base.CanResetComponentProperty("ItemRotationDamping"))
			{
				this.ItemRotationDamping = sceneItemDollGrabMachineComponent.ItemRotationDamping;
			}
			if (base.CanResetComponentProperty("ItemMoveDamping"))
			{
				this.ItemMoveDamping = sceneItemDollGrabMachineComponent.ItemMoveDamping;
			}
			if (base.CanResetComponentProperty("LightGroupSequenceActor"))
			{
				if (sceneItemDollGrabMachineComponent.LightGroupSequenceActor == null)
				{
					this.LightGroupSequenceActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AKuroLevelSequenceActor>(this.LightGroupSequenceActor), "LightGroupSequenceActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MainDollActorItem"))
			{
				if (sceneItemDollGrabMachineComponent.MainDollActorItem == null)
				{
					this.MainDollActorItem = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DollGrabMachineItem>(this.MainDollActorItem), "MainDollActorItem"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DissolveStartTimer"))
			{
				if (sceneItemDollGrabMachineComponent.DissolveStartTimer == null)
				{
					this.DissolveStartTimer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.DissolveStartTimer), "DissolveStartTimer"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DissolveCloseTimer"))
			{
				if (sceneItemDollGrabMachineComponent.DissolveCloseTimer == null)
				{
					this.DissolveCloseTimer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.DissolveCloseTimer), "DissolveCloseTimer"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DissolvePerSecond"))
			{
				this.DissolvePerSecond = sceneItemDollGrabMachineComponent.DissolvePerSecond;
			}
			if (base.CanResetComponentProperty("DissolveProgress"))
			{
				this.DissolveProgress = sceneItemDollGrabMachineComponent.DissolveProgress;
			}
			if (base.CanResetComponentProperty("DissolveRadius"))
			{
				this.DissolveRadius = sceneItemDollGrabMachineComponent.DissolveRadius;
			}
			if (base.CanResetComponentProperty("IsEndlessModeInternal"))
			{
				this.IsEndlessModeInternal = sceneItemDollGrabMachineComponent.IsEndlessModeInternal;
			}
			if (base.CanResetComponentProperty("EndlessSpawnPoints") && sceneItemDollGrabMachineComponent.EndlessSpawnPoints != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<AActor, FVectorDouble>>(this.EndlessSpawnPoints), "EndlessSpawnPoints"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EndlessAvailableSpawnPoints") && sceneItemDollGrabMachineComponent.EndlessAvailableSpawnPoints != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.EndlessAvailableSpawnPoints), "EndlessAvailableSpawnPoints"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EndlessAvailableSpawnPointsMap") && sceneItemDollGrabMachineComponent.EndlessAvailableSpawnPointsMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<AActor, HashSet<AActor>>>(this.EndlessAvailableSpawnPointsMap), "EndlessAvailableSpawnPointsMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EndlessIdleItemPool") && sceneItemDollGrabMachineComponent.EndlessIdleItemPool != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, DollGrabMachineItem>>(this.EndlessIdleItemPool), "EndlessIdleItemPool"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EndlessIdleItemIdList") && sceneItemDollGrabMachineComponent.EndlessIdleItemIdList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<int>>(this.EndlessIdleItemIdList), "EndlessIdleItemIdList"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("IsDropRefreshTime"))
			{
				this.IsDropRefreshTime = sceneItemDollGrabMachineComponent.IsDropRefreshTime;
			}
			if (base.CanResetComponentProperty("PendingDropItemInfoList"))
			{
				if (sceneItemDollGrabMachineComponent.PendingDropItemInfoList == null)
				{
					this.PendingDropItemInfoList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<DollGrabMachineItem>>(this.PendingDropItemInfoList), "PendingDropItemInfoList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RefreshIntervalCurve"))
			{
				if (sceneItemDollGrabMachineComponent.RefreshIntervalCurve == null)
				{
					this.RefreshIntervalCurve = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.RefreshIntervalCurve), "RefreshIntervalCurve"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EndlessElapsedTime"))
			{
				this.EndlessElapsedTime = sceneItemDollGrabMachineComponent.EndlessElapsedTime;
			}
			if (base.CanResetComponentProperty("EndlessDropTimer"))
			{
				if (sceneItemDollGrabMachineComponent.EndlessDropTimer == null)
				{
					this.EndlessDropTimer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.EndlessDropTimer), "EndlessDropTimer"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EndlessRewardDataInternal"))
			{
				if (sceneItemDollGrabMachineComponent.EndlessRewardDataInternal == null)
				{
					this.EndlessRewardDataInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IDollGrabInfiniteRewardData>(this.EndlessRewardDataInternal), "EndlessRewardDataInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EndlessAudioDataInternal") && sceneItemDollGrabMachineComponent.EndlessAudioDataInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<float, EndlessAudioStateInfo>>(this.EndlessAudioDataInternal), "EndlessAudioDataInternal"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ConveyorBeltEventHandle"))
			{
				this.ConveyorBeltEventHandle = sceneItemDollGrabMachineComponent.ConveyorBeltEventHandle;
			}
			if (base.CanResetComponentProperty("RoofDissolveEventHandle"))
			{
				this.RoofDissolveEventHandle = sceneItemDollGrabMachineComponent.RoofDissolveEventHandle;
			}
			return true;
		}

		// Token: 0x040264D5 RID: 156885
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x040264D6 RID: 156886
		private SceneItemActorComponent ActorComp;

		// Token: 0x040264D7 RID: 156887
		private SceneItemStateComponent StateComp;

		// Token: 0x040264D8 RID: 156888
		private BaseTagComponent TagComp;

		// Token: 0x040264D9 RID: 156889
		private DollGrabMachineComponent Config;

		// Token: 0x040264DA RID: 156890
		private AActor ClawActor;

		// Token: 0x040264DB RID: 156891
		private AActor ClawRootCtrlActor;

		// Token: 0x040264DC RID: 156892
		private AActor ClawChainActor;

		// Token: 0x040264DD RID: 156893
		private AActor DropTriggerActor;

		// Token: 0x040264DE RID: 156894
		private AActor DollItemPoolActor;

		// Token: 0x040264DF RID: 156895
		[Nullable(1)]
		private readonly List<AActor> TeleportTriggerActorList = new List<AActor>();

		// Token: 0x040264E0 RID: 156896
		[Nullable(1)]
		private readonly List<FVectorDouble> TeleportTargetLocationList = new List<FVectorDouble>();

		// Token: 0x040264E1 RID: 156897
		[Nullable(1)]
		private readonly List<BP_DollGrabMahcineConveyorBelt_C> ConveyorBeltActorList = new List<BP_DollGrabMahcineConveyorBelt_C>();

		// Token: 0x040264E2 RID: 156898
		private BP_ConveyorBelt_C ConveyorBeltMeshBpActor;

		// Token: 0x040264E3 RID: 156899
		private BP_CenterDissolvePosition_C DissolveActor;

		// Token: 0x040264E4 RID: 156900
		[Nullable(1)]
		private readonly List<AActor> BoundaryTriggerActorList = new List<AActor>();

		// Token: 0x040264E5 RID: 156901
		private AActor RoofActor;

		// Token: 0x040264E6 RID: 156902
		[Nullable(1)]
		private List<AActor> LightActorGroup = new List<AActor>();

		// Token: 0x040264E7 RID: 156903
		private DgmClawStateController ClawStateController;

		// Token: 0x040264E8 RID: 156904
		[Nullable(1)]
		private readonly DollGrabMachineClawDirection ClawMoveDirectionInternal = new DollGrabMachineClawDirection(0f, 0f);

		// Token: 0x040264E9 RID: 156905
		private bool NeedInitClawStateController;

		// Token: 0x040264EA RID: 156906
		[Nullable(1)]
		private Dictionary<int, DollGrabMachineItem> DollItemMap = new Dictionary<int, DollGrabMachineItem>();

		// Token: 0x040264EB RID: 156907
		[Nullable(1)]
		private List<int> GrabbedItemList = new List<int>();

		// Token: 0x040264EC RID: 156908
		[Nullable(1)]
		private List<AActor> GrabbingActorList = new List<AActor>();

		// Token: 0x040264ED RID: 156909
		private int LeaveDollCountInternal;

		// Token: 0x040264EE RID: 156910
		[Nullable(1)]
		private readonly Dictionary<int, int> CurrentDropItemListInternal = new Dictionary<int, int>();

		// Token: 0x040264EF RID: 156911
		private bool IsActiveInternal;

		// Token: 0x040264F0 RID: 156912
		private bool IsPauseInternal;

		// Token: 0x040264F1 RID: 156913
		private bool IsCacheCheckTouchAction;

		// Token: 0x040264F2 RID: 156914
		private string AkEvent;

		// Token: 0x040264F3 RID: 156915
		private int AkEventHandle = -1;

		// Token: 0x040264F4 RID: 156916
		private FTransformDouble? GrabEffectTransform;

		// Token: 0x040264F5 RID: 156917
		private float ItemRotationDamping;

		// Token: 0x040264F6 RID: 156918
		private float ItemMoveDamping;

		// Token: 0x040264F7 RID: 156919
		private AKuroLevelSequenceActor LightGroupSequenceActor;

		// Token: 0x040264F8 RID: 156920
		private DollGrabMachineItem MainDollActorItem;

		// Token: 0x040264F9 RID: 156921
		private TimerHandle DissolveStartTimer;

		// Token: 0x040264FA RID: 156922
		private TimerHandle DissolveCloseTimer;

		// Token: 0x040264FB RID: 156923
		private float DissolvePerSecond;

		// Token: 0x040264FC RID: 156924
		private float DissolveProgress;

		// Token: 0x040264FD RID: 156925
		private float DissolveRadius;

		// Token: 0x040264FE RID: 156926
		private bool IsEndlessModeInternal;

		// Token: 0x040264FF RID: 156927
		[Nullable(1)]
		private readonly Dictionary<AActor, FVectorDouble> EndlessSpawnPoints = new Dictionary<AActor, FVectorDouble>();

		// Token: 0x04026500 RID: 156928
		[Nullable(1)]
		private readonly List<AActor> EndlessAvailableSpawnPoints = new List<AActor>();

		// Token: 0x04026501 RID: 156929
		[Nullable(1)]
		private readonly Dictionary<AActor, HashSet<AActor>> EndlessAvailableSpawnPointsMap = new Dictionary<AActor, HashSet<AActor>>();

		// Token: 0x04026502 RID: 156930
		[Nullable(1)]
		private readonly Dictionary<int, DollGrabMachineItem> EndlessIdleItemPool = new Dictionary<int, DollGrabMachineItem>();

		// Token: 0x04026503 RID: 156931
		[Nullable(1)]
		private readonly List<int> EndlessIdleItemIdList = new List<int>();

		// Token: 0x04026504 RID: 156932
		private bool IsDropRefreshTime;

		// Token: 0x04026505 RID: 156933
		[Nullable(1)]
		private List<DollGrabMachineItem> PendingDropItemInfoList = new List<DollGrabMachineItem>();

		// Token: 0x04026506 RID: 156934
		private UCurveFloat RefreshIntervalCurve;

		// Token: 0x04026507 RID: 156935
		private float EndlessElapsedTime;

		// Token: 0x04026508 RID: 156936
		private TimerHandle EndlessDropTimer;

		// Token: 0x04026509 RID: 156937
		private IDollGrabInfiniteRewardData EndlessRewardDataInternal;

		// Token: 0x0402650A RID: 156938
		[Nullable(1)]
		private readonly Dictionary<float, EndlessAudioStateInfo> EndlessAudioDataInternal = new Dictionary<float, EndlessAudioStateInfo>();

		// Token: 0x0402650B RID: 156939
		private int ConveyorBeltEventHandle = -1;

		// Token: 0x0402650C RID: 156940
		private int RoofDissolveEventHandle = -1;
	}
}
