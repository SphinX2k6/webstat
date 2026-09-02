using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006669 RID: 26217
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityMowingRiskController : ActivityControllerBase<ActivityMowingRiskController>
	{
		// Token: 0x060417AB RID: 268203 RVA: 0x010CEE85 File Offset: 0x010CD085
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x060417AC RID: 268204 RVA: 0x010CEE87 File Offset: 0x010CD087
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityMowingRisk";
		}

		// Token: 0x060417AD RID: 268205 RVA: 0x010CEE8E File Offset: 0x010CD08E
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityMowingRiskSubView();
		}

		// Token: 0x060417AE RID: 268206 RVA: 0x010CEE95 File Offset: 0x010CD095
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			ModelBase<MowingRiskModel>.Instance.InitContext();
			return ModelBase<MowingRiskModel>.Instance.ActivityData;
		}

		// Token: 0x060417AF RID: 268207 RVA: 0x010CEEAB File Offset: 0x010CD0AB
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x060417B0 RID: 268208 RVA: 0x010CEEB0 File Offset: 0x010CD0B0
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RiskHarvestEndNotify>(ENotifyMessageId.RiskHarvestEndNotify, new Action<RiskHarvestEndNotify, Net.CallbackStatus>(this.HandleRiskHarvestEndNotify));
			Singleton<Net>.Instance.Register<RiskHarvestInstUpdateNotify>(ENotifyMessageId.RiskHarvestInstUpdateNotify, new Action<RiskHarvestInstUpdateNotify, Net.CallbackStatus>(this.HandleRiskHarvestInstUpdateNotify));
			Singleton<Net>.Instance.Register<RiskHarvestArtifactNotify>(ENotifyMessageId.RiskHarvestArtifactNotify, new Action<RiskHarvestArtifactNotify, Net.CallbackStatus>(this.HandleRiskHarvestArtifactNotify));
			Singleton<Net>.Instance.Register<RiskHarvestBuffUpdateNotify>(ENotifyMessageId.RiskHarvestBuffUpdateNotify, new Action<RiskHarvestBuffUpdateNotify, Net.CallbackStatus>(this.HandleRiskHarvestBuffUpdateNotify));
			Singleton<Net>.Instance.Register<RiskHarvestBuffUnlockNotify>(ENotifyMessageId.RiskHarvestBuffUnlockNotify, new Action<RiskHarvestBuffUnlockNotify, Net.CallbackStatus>(this.HandleRiskHarvestBuffUnlockNotify));
			Singleton<Net>.Instance.Register<RiskHarvestActivityUpdateNotify>(ENotifyMessageId.RiskHarvestActivityUpdateNotify, new Action<RiskHarvestActivityUpdateNotify, Net.CallbackStatus>(this.HandleRiskHarvestActivityUpdateNotify));
		}

		// Token: 0x060417B1 RID: 268209 RVA: 0x010CEF68 File Offset: 0x010CD168
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RiskHarvestEndNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RiskHarvestInstUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RiskHarvestArtifactNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RiskHarvestBuffUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RiskHarvestBuffUnlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RiskHarvestActivityUpdateNotify);
		}

		// Token: 0x060417B2 RID: 268210 RVA: 0x010CEFD8 File Offset: 0x010CD1D8
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.EnterInstanceDungeon, new Action(this.HandleEnterInstanceDungeon));
			Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.HandleLeaveInstanceDungeon));
			Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeonConfirm, new Action(this.HandleLeaveInstanceDungeonConfirm));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.HandleWorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Add(EEventName.MowingRiskOnBuffTipsAfterDestroy, new Action(this.HandleMowingRiskOnBuffTipsAfterDestroy));
		}

		// Token: 0x060417B3 RID: 268211 RVA: 0x010CF074 File Offset: 0x010CD274
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EnterInstanceDungeon, new Action(this.HandleEnterInstanceDungeon));
			Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.HandleLeaveInstanceDungeon));
			Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeonConfirm, new Action(this.HandleLeaveInstanceDungeonConfirm));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.HandleWorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Remove(EEventName.MowingRiskOnBuffTipsAfterDestroy, new Action(this.HandleMowingRiskOnBuffTipsAfterDestroy));
		}

		// Token: 0x060417B4 RID: 268212 RVA: 0x010CF10D File Offset: 0x010CD30D
		public override bool GetActivityLevelUnlockState(int instanceId)
		{
			return ModelBase<MowingRiskModel>.Instance.IsInstanceUnlockedByInstanceId(instanceId);
		}

		// Token: 0x060417B5 RID: 268213 RVA: 0x010CF11A File Offset: 0x010CD31A
		private void HandleRiskHarvestEndNotify(RiskHarvestEndNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			this.DumpNotifyMessage(message);
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return;
			}
			ModelBase<MowingRiskModel>.Instance.SyncProtocolRiskHarvestEndNotify(message);
			this.TryOpenSettleViewAsync(message).Forget();
		}

		// Token: 0x060417B6 RID: 268214 RVA: 0x010CF147 File Offset: 0x010CD347
		private void HandleRiskHarvestInstUpdateNotify(RiskHarvestInstUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			this.DumpNotifyMessage(message);
			ModelBase<MowingRiskModel>.Instance.SyncProtocolRiskHarvestInstUpdateNotify(message);
		}

		// Token: 0x060417B7 RID: 268215 RVA: 0x010CF15B File Offset: 0x010CD35B
		private void HandleRiskHarvestArtifactNotify(RiskHarvestArtifactNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			this.DumpNotifyMessage(message);
			ModelBase<MowingRiskModel>.Instance.SyncProtocolRiskHarvestArtifactNotify(message);
		}

		// Token: 0x060417B8 RID: 268216 RVA: 0x010CF170 File Offset: 0x010CD370
		private void HandleRiskHarvestBuffUpdateNotify(RiskHarvestBuffUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			this.DumpNotifyMessage(message);
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			instance.SyncProtocolRiskHarvestBuffUpdateNotify(message);
			this.TryOpenNewBuffTips();
			Singleton<EventSystem>.Instance.Emit<IMowingRiskInBattleRootData>(EEventName.MowingRiskInBattleRootUpdate, instance.BuildInBattleRootData());
		}

		// Token: 0x060417B9 RID: 268217 RVA: 0x010CF1AD File Offset: 0x010CD3AD
		private void HandleRiskHarvestBuffUnlockNotify(RiskHarvestBuffUnlockNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			this.DumpNotifyMessage(message);
			ModelBase<MowingRiskModel>.Instance.SyncProtocolRiskHarvestBuffUnlockNotify(message);
		}

		// Token: 0x060417BA RID: 268218 RVA: 0x010CF1C4 File Offset: 0x010CD3C4
		private void HandleRiskHarvestActivityUpdateNotify(RiskHarvestActivityUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			this.DumpNotifyMessage(message);
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			instance.SyncProtocolRiskHarvestActivityUpdateNotify(message);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnNeedRefreshByProtocol);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, instance.ActivityData.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, instance.ActivityData.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.MowingRiskOnRefreshRewardRedDot);
		}

		// Token: 0x060417BB RID: 268219 RVA: 0x010CF23C File Offset: 0x010CD43C
		public UniTask RequestRiskHarvestInstRewardRequest(int id)
		{
			ActivityMowingRiskController.<RequestRiskHarvestInstRewardRequest>d__17 <RequestRiskHarvestInstRewardRequest>d__;
			<RequestRiskHarvestInstRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRiskHarvestInstRewardRequest>d__.id = id;
			<RequestRiskHarvestInstRewardRequest>d__.<>1__state = -1;
			<RequestRiskHarvestInstRewardRequest>d__.<>t__builder.Start<ActivityMowingRiskController.<RequestRiskHarvestInstRewardRequest>d__17>(ref <RequestRiskHarvestInstRewardRequest>d__);
			return <RequestRiskHarvestInstRewardRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060417BC RID: 268220 RVA: 0x010CF280 File Offset: 0x010CD480
		public UniTask RequestRiskHarvestScoreRewardRequest(int id)
		{
			ActivityMowingRiskController.<RequestRiskHarvestScoreRewardRequest>d__18 <RequestRiskHarvestScoreRewardRequest>d__;
			<RequestRiskHarvestScoreRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRiskHarvestScoreRewardRequest>d__.id = id;
			<RequestRiskHarvestScoreRewardRequest>d__.<>1__state = -1;
			<RequestRiskHarvestScoreRewardRequest>d__.<>t__builder.Start<ActivityMowingRiskController.<RequestRiskHarvestScoreRewardRequest>d__18>(ref <RequestRiskHarvestScoreRewardRequest>d__);
			return <RequestRiskHarvestScoreRewardRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060417BD RID: 268221 RVA: 0x010CF2C4 File Offset: 0x010CD4C4
		public UniTask RequestRiskHarvestStarRewardRequest(int id, int index)
		{
			ActivityMowingRiskController.<RequestRiskHarvestStarRewardRequest>d__19 <RequestRiskHarvestStarRewardRequest>d__;
			<RequestRiskHarvestStarRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRiskHarvestStarRewardRequest>d__.id = id;
			<RequestRiskHarvestStarRewardRequest>d__.index = index;
			<RequestRiskHarvestStarRewardRequest>d__.<>1__state = -1;
			<RequestRiskHarvestStarRewardRequest>d__.<>t__builder.Start<ActivityMowingRiskController.<RequestRiskHarvestStarRewardRequest>d__19>(ref <RequestRiskHarvestStarRewardRequest>d__);
			return <RequestRiskHarvestStarRewardRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060417BE RID: 268222 RVA: 0x010CF310 File Offset: 0x010CD510
		public UniTask RequestRiskHarvestSettleRequest()
		{
			ActivityMowingRiskController.<RequestRiskHarvestSettleRequest>d__20 <RequestRiskHarvestSettleRequest>d__;
			<RequestRiskHarvestSettleRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRiskHarvestSettleRequest>d__.<>1__state = -1;
			<RequestRiskHarvestSettleRequest>d__.<>t__builder.Start<ActivityMowingRiskController.<RequestRiskHarvestSettleRequest>d__20>(ref <RequestRiskHarvestSettleRequest>d__);
			return <RequestRiskHarvestSettleRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060417BF RID: 268223 RVA: 0x010CF34B File Offset: 0x010CD54B
		private void HandleLeaveInstanceDungeonConfirm()
		{
			if (!this.CheckInInstanceDungeon())
			{
				return;
			}
			this.RequestRiskHarvestSettleRequest().Forget();
		}

		// Token: 0x060417C0 RID: 268224 RVA: 0x010CF361 File Offset: 0x010CD561
		private void HandleEnterInstanceDungeon()
		{
		}

		// Token: 0x060417C1 RID: 268225 RVA: 0x010CF363 File Offset: 0x010CD563
		private void HandleLeaveInstanceDungeon()
		{
			if (!this.CheckInInstanceDungeon())
			{
				return;
			}
			ModelBase<DeadReviveModel>.Instance.HandleOnClickGiveUpExternal = null;
			ControllerBase<InstanceDungeonEntranceController>.Instance.IsSettleExternalProcess = false;
			ModelBase<MowingRiskModel>.Instance.ResetCacheInBattle();
		}

		// Token: 0x060417C2 RID: 268226 RVA: 0x010CF38E File Offset: 0x010CD58E
		private void HandleWorldDoneAndCloseLoading()
		{
			if (!this.CheckInInstanceDungeon())
			{
				return;
			}
			ModelBase<DeadReviveModel>.Instance.HandleOnClickGiveUpExternal = delegate()
			{
				this.RequestRiskHarvestSettleRequest().Forget();
			};
			ControllerBase<InstanceDungeonEntranceController>.Instance.IsSettleExternalProcess = true;
			CustomPromise beInInstancePromise = this.BeInInstancePromise;
			if (beInInstancePromise == null)
			{
				return;
			}
			beInInstancePromise.SetResult();
		}

		// Token: 0x060417C3 RID: 268227 RVA: 0x010CF3CA File Offset: 0x010CD5CA
		private void HandleMowingRiskOnBuffTipsAfterDestroy()
		{
			this.TryOpenNewBuffTips();
		}

		// Token: 0x060417C4 RID: 268228 RVA: 0x010CF3D2 File Offset: 0x010CD5D2
		private void DumpNotifyMessage(object msg)
		{
		}

		// Token: 0x060417C5 RID: 268229 RVA: 0x010CF3D4 File Offset: 0x010CD5D4
		private void TryOpenNewBuffTips()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MowingBuffNewBuffTipsView) || !this.CheckInInstanceDungeon())
			{
				return;
			}
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			int? nextNewBuffId = instance.NextNewBuffId;
			if (nextNewBuffId != null)
			{
				int? num = nextNewBuffId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					IMowingRiskNewBasicBuffTipsData param = instance.BuildNewBuffTipsDataById(nextNewBuffId.Value);
					Singleton<UiManager>.Instance.OpenView(EUiViewName.MowingBuffNewBuffTipsView, param, null);
					if (instance.IsSuperBuffById(nextNewBuffId.Value))
					{
						this.TryShowBuffBigTip(nextNewBuffId.Value);
						Singleton<EventSystem>.Instance.Emit(EEventName.MowingRiskOnNeedPlayLevelUpSequence);
					}
				}
			}
		}

		// Token: 0x060417C6 RID: 268230 RVA: 0x010CF478 File Offset: 0x010CD678
		private void TryShowBuffBigTip(int buffId)
		{
			IMowingRiskInBattleBuffData extraParam = ModelBase<MowingRiskModel>.Instance.BuildInBattleBuffDataById(buffId);
			ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<IMowingRiskInBattleBuffData>(EPromptSubViewType.MowingRiskBuff, null, null, null, null, null, null, extraParam, null, false, null);
		}

		// Token: 0x060417C7 RID: 268231 RVA: 0x010CF4B8 File Offset: 0x010CD6B8
		private UniTask TryOpenSettleViewAsync(RiskHarvestEndNotify message)
		{
			ActivityMowingRiskController.<TryOpenSettleViewAsync>d__29 <TryOpenSettleViewAsync>d__;
			<TryOpenSettleViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryOpenSettleViewAsync>d__.<>4__this = this;
			<TryOpenSettleViewAsync>d__.message = message;
			<TryOpenSettleViewAsync>d__.<>1__state = -1;
			<TryOpenSettleViewAsync>d__.<>t__builder.Start<ActivityMowingRiskController.<TryOpenSettleViewAsync>d__29>(ref <TryOpenSettleViewAsync>d__);
			return <TryOpenSettleViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060417C8 RID: 268232 RVA: 0x010CF504 File Offset: 0x010CD704
		private void OpenAccumulatedScoreSettleView(RiskHarvestEndNotify message)
		{
			Action<int> onClickedCallback = delegate(int index)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			};
			RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "riskofrain_UIBacktoworld",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = onClickedCallback
			};
			Action<int> onClickedCallback2 = delegate(int _)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
			};
			RewardExploreConfirmButtonData item2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_133_ButtonText_1",
				IsTimeDownCloseView = false,
				IsClickedCloseView = false,
				OnClickedCallback = onClickedCallback2,
				DescriptionTextId = null
			};
			int maxScoreById = ModelBase<MowingRiskModel>.Instance.GetMaxScoreById(message.Id);
			AccumulatedScoreData accumulatedScoreData = new AccumulatedScoreData
			{
				DetailScoreDataList = new List<IAccumulatedScoreLineData>
				{
					new AccumulatedScoreLineData
					{
						DescTextId = "RiskHarvest_Timepoint",
						ScoreText = message.TimeScore.ToString()
					},
					new AccumulatedScoreLineData
					{
						DescTextId = "RiskHarvest_Monsterpoint",
						ScoreText = message.MonsterScore.ToString()
					}
				},
				TotalScoreDataList = new List<IAccumulatedScoreLineData>
				{
					new AccumulatedScoreLineData
					{
						DescTextId = "RiskHarvest_Score",
						ScoreText = message.TotalScore.ToString()
					}
				},
				CurScore = message.InstScore,
				MaxScore = maxScoreById
			};
			string titleTextId = (message.TimeScore > 0) ? null : "riskofrain_UIFinish";
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(message.Pass ? 3013 : 3012, message.Pass, null, null, null, new List<IRewardExploreConfirmButton>
			{
				item,
				item2
			}, null, null, null, null, null, null, null, null, null, accumulatedScoreData, titleTextId);
		}

		// Token: 0x060417C9 RID: 268233 RVA: 0x010CF6DC File Offset: 0x010CD8DC
		private unsafe void OpenNotAccumulatedScoreSettleView(RiskHarvestEndNotify message)
		{
			Action<int> onClickedCallback = delegate(int _)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			};
			RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "riskofrain_UIBacktoworld",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = onClickedCallback
			};
			Action<int> onClickedCallback2 = delegate(int _)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().Forget<bool>();
			};
			RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
			rewardExploreConfirmButtonData.ButtonTextId = "ConfirmBox_133_ButtonText_1";
			rewardExploreConfirmButtonData.DescriptionTextId = "RiskHarvest_HistoryToppoint";
			int num = 1;
			List<object> list = new List<object>(num);
			CollectionsMarshal.SetCount<object>(list, num);
			Span<object> span = CollectionsMarshal.AsSpan<object>(list);
			int index = 0;
			*span[index] = ModelBase<MowingRiskModel>.Instance.GetRecordScoreById(message.Id).ToString();
			rewardExploreConfirmButtonData.DescriptionArgs = list;
			rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
			rewardExploreConfirmButtonData.IsClickedCloseView = false;
			rewardExploreConfirmButtonData.OnClickedCallback = onClickedCallback2;
			RewardExploreConfirmButtonData item2 = rewardExploreConfirmButtonData;
			int maxScoreById = ModelBase<MowingRiskModel>.Instance.GetMaxScoreById(message.Id);
			int totalScore = message.TotalScore;
			string titleTextId = (message.TimeScore > 0) ? null : "riskofrain_UIFinish";
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(message.Pass ? 3013 : 3012, message.Pass, null, null, null, new List<IRewardExploreConfirmButton>
			{
				item,
				item2
			}, null, null, null, null, null, null, null, new ReachTargetData
			{
				TargetReached = new List<IRewardExploreTargetReached>
				{
					new RewardExploreTargetReachedData
					{
						Target = new List<string>
						{
							message.TimeScore.ToString()
						},
						DescriptionTextId = "RiskHarvest_Timepoint",
						IsReached = true
					},
					new RewardExploreTargetReachedData
					{
						Target = new List<string>
						{
							message.MonsterScore.ToString()
						},
						DescriptionTextId = "RiskHarvest_Monsterpoint",
						IsReached = true
					}
				},
				IfNewRecord = false,
				FullScore = totalScore,
				RecordTextId = ((totalScore < maxScoreById) ? "RiskHarvest_Score" : "RiskHarvest_Scorelimit")
			}, null, null, titleTextId);
		}

		// Token: 0x060417CA RID: 268234 RVA: 0x010CF904 File Offset: 0x010CDB04
		private UniTask WaitForBeInInstance()
		{
			ActivityMowingRiskController.<WaitForBeInInstance>d__32 <WaitForBeInInstance>d__;
			<WaitForBeInInstance>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitForBeInInstance>d__.<>4__this = this;
			<WaitForBeInInstance>d__.<>1__state = -1;
			<WaitForBeInInstance>d__.<>t__builder.Start<ActivityMowingRiskController.<WaitForBeInInstance>d__32>(ref <WaitForBeInInstance>d__);
			return <WaitForBeInInstance>d__.<>t__builder.Task;
		}

		// Token: 0x060417CB RID: 268235 RVA: 0x010CF948 File Offset: 0x010CDB48
		public bool CheckInInstanceDungeon()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
				return instanceDungeon != null && instanceDungeon.Value.InstSubType == 22;
			}
			return false;
		}

		// Token: 0x060417CC RID: 268236 RVA: 0x010CF98C File Offset: 0x010CDB8C
		public bool IsMowingRiskInstanceDungeon(int instanceId)
		{
			if (instanceId <= 0)
			{
				return false;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.GetValueOrDefault().InstSubType == 22;
		}

		// Token: 0x060417CD RID: 268237 RVA: 0x010CF9C9 File Offset: 0x010CDBC9
		[NullableContext(2)]
		public string GetInstanceSubtitleTextIdByInstanceId(int id)
		{
			return ModelBase<MowingRiskModel>.Instance.BuildInstanceSubtitleTextIdByInstanceId(id);
		}

		// Token: 0x060417CE RID: 268238 RVA: 0x010CF9D6 File Offset: 0x010CDBD6
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetInstanceSubtitleArgsByInstanceId(int id)
		{
			return ModelBase<MowingRiskModel>.Instance.BuildInstanceSubtitleTextArgsByInstanceId(id);
		}

		// Token: 0x060417CF RID: 268239 RVA: 0x010CF9E3 File Offset: 0x010CDBE3
		public bool CheckInstanceFinishedByInstanceId(int id)
		{
			return ModelBase<MowingRiskModel>.Instance.CheckInstanceFinishedByInstanceId(id);
		}

		// Token: 0x060417D0 RID: 268240 RVA: 0x010CF9F0 File Offset: 0x010CDBF0
		public bool CheckInstanceUnlockByInstanceId(int id)
		{
			return ModelBase<MowingRiskModel>.Instance.IsInstanceUnlockedByInstanceId(id);
		}

		// Token: 0x060417D1 RID: 268241 RVA: 0x010CF9FD File Offset: 0x010CDBFD
		public string GetInstanceLockTextIdByInstanceId(int id)
		{
			return ModelBase<MowingRiskModel>.Instance.GetInstanceLockTextIdByInstanceId(id);
		}

		// Token: 0x060417D2 RID: 268242 RVA: 0x010CFA0A File Offset: 0x010CDC0A
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetInstanceLockTextArgsByInstanceId(int id)
		{
			return ModelBase<MowingRiskModel>.Instance.GetLockTextArgsByInstanceId(id);
		}

		// Token: 0x060417D3 RID: 268243 RVA: 0x010CFA18 File Offset: 0x010CDC18
		public IInstanceDungeonEntranceViewSelectData GetEntranceViewDefaultSelectData(Dictionary<int, List<int>> instanceByTitleMap)
		{
			int seriesId = 0;
			int instanceId = 0;
			foreach (KeyValuePair<int, List<int>> keyValuePair in instanceByTitleMap)
			{
				seriesId = keyValuePair.Key;
				foreach (int num in keyValuePair.Value)
				{
					instanceId = num;
					if (!this.CheckInstanceFinishedByInstanceId(num))
					{
						return new InstanceDungeonEntranceViewSelectData
						{
							InstanceId = instanceId,
							SeriesId = seriesId
						};
					}
				}
			}
			return new InstanceDungeonEntranceViewSelectData
			{
				InstanceId = instanceId,
				SeriesId = seriesId
			};
		}

		// Token: 0x040249A2 RID: 149922
		private CustomPromise BeInInstancePromise = new CustomPromise();
	}
}
