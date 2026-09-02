using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200695F RID: 26975
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class AdamSmasherController : ControllerBase<AdamSmasherController>
	{
		// Token: 0x06042ED9 RID: 274137 RVA: 0x0112E326 File Offset: 0x0112C526
		protected override bool OnInit()
		{
			this.OnRegisterNetEvent();
			this.OnAddEvents();
			return true;
		}

		// Token: 0x06042EDA RID: 274138 RVA: 0x0112E335 File Offset: 0x0112C535
		protected override bool OnClear()
		{
			this.OnUnRegisterNetEvent();
			this.OnRemoveEvents();
			this.ResetAllState();
			return true;
		}

		// Token: 0x06042EDB RID: 274139 RVA: 0x0112E34A File Offset: 0x0112C54A
		private void ResetAllState()
		{
			this.SelectedRoleIdList.Clear();
		}

		// Token: 0x06042EDC RID: 274140 RVA: 0x0112E357 File Offset: 0x0112C557
		protected void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<EdgeRunnerLordGymLevelPlayResultNotify>(ENotifyMessageId.EdgeRunnerLordGymLevelPlayResultNotify, new Action<EdgeRunnerLordGymLevelPlayResultNotify, Net.CallbackStatus>(this.OnAdamSmasherResultNotify));
		}

		// Token: 0x06042EDD RID: 274141 RVA: 0x0112E375 File Offset: 0x0112C575
		protected void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EdgeRunnerLordGymLevelPlayResultNotify);
		}

		// Token: 0x06042EDE RID: 274142 RVA: 0x0112E387 File Offset: 0x0112C587
		protected void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		}

		// Token: 0x06042EDF RID: 274143 RVA: 0x0112E3A5 File Offset: 0x0112C5A5
		protected void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		}

		// Token: 0x06042EE0 RID: 274144 RVA: 0x0112E3C4 File Offset: 0x0112C5C4
		private void OnAdamSmasherResultNotify(EdgeRunnerLordGymLevelPlayResultNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (this.IsCyberPunkActivityEnded())
			{
				this.OpenActivityEndedFailView(notify);
				return;
			}
			EdgeRunnerLordGymPassRecord lordGymPassRecord = notify.LordGymPassRecord;
			if (!notify.IsSuccess)
			{
				int failLoadGymId = notify.FailLoadGymId;
				AdamSmasherChallengeFailViewParam param = new AdamSmasherChallengeFailViewParam
				{
					StageId = failLoadGymId
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.AdamSmasherChallengeFailView, param, null);
				return;
			}
			if (lordGymPassRecord == null)
			{
				return;
			}
			CyberPunkData cyberPunkData = this.GetCyberPunkData();
			if (cyberPunkData == null)
			{
				return;
			}
			cyberPunkData.UpdateAdamSmasherPassRecord(lordGymPassRecord);
			List<RewardItemData> list = new List<RewardItemData>();
			foreach (Aki.Protocol.ItemData itemData in notify.ItemDatas)
			{
				RewardItemData item = new RewardItemData(itemData.ItemId, itemData.Count, (itemData.ItemIncId != 0) ? new int?(itemData.ItemIncId) : null, EDropItemType.Normal);
				list.Add(item);
			}
			RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
			rewardExploreConfirmButtonData.ButtonTextId = "ConfirmBox_505_ButtonText_0";
			rewardExploreConfirmButtonData.DescriptionTextId = null;
			rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
			rewardExploreConfirmButtonData.IsClickedCloseView = true;
			rewardExploreConfirmButtonData.OnClickedCallback = delegate(int _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.AdamSmasherSelectView, null, null);
			};
			RewardExploreConfirmButtonData item2 = rewardExploreConfirmButtonData;
			int nextStageId = this.GetNextStageId(lordGymPassRecord.LoadGymId);
			List<IRewardExploreConfirmButton> buttonInfoList;
			if (nextStageId > 0 && this.IsStageUnlocked(nextStageId))
			{
				RewardExploreConfirmButtonData item3 = new RewardExploreConfirmButtonData
				{
					ButtonTextId = "Text_GymContinueChallenge_Text",
					DescriptionTextId = null,
					IsTimeDownCloseView = false,
					IsClickedCloseView = true,
					OnClickedCallback = delegate(int _)
					{
						this.RequestStartChallenge(nextStageId, new List<int>(this.SelectedRoleIdList)).Forget<bool>();
					}
				};
				buttonInfoList = new List<IRewardExploreConfirmButton>
				{
					item2,
					item3
				};
			}
			else
			{
				RewardExploreConfirmButtonData rewardExploreConfirmButtonData2 = new RewardExploreConfirmButtonData();
				rewardExploreConfirmButtonData2.ButtonTextId = "Text_GymReturnToWorld_Text";
				rewardExploreConfirmButtonData2.DescriptionTextId = null;
				rewardExploreConfirmButtonData2.IsTimeDownCloseView = false;
				rewardExploreConfirmButtonData2.IsClickedCloseView = true;
				rewardExploreConfirmButtonData2.OnClickedCallback = delegate(int _)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
				};
				RewardExploreConfirmButtonData item4 = rewardExploreConfirmButtonData2;
				buttonInfoList = new List<IRewardExploreConfirmButton>
				{
					item2,
					item4
				};
			}
			RewardExploreRecordData exploreRecordInfo = new RewardExploreRecordData
			{
				TitleTextId = "LordGym_TimeTitle",
				Record = Singleton<TimeUtil>.Instance.GetTimeString((double)notify.PassTime),
				IsNewRecord = notify.IsNewRecord
			};
			ExploreRewardViewData data = new ExploreRewardViewData
			{
				ConfigId = 3011,
				IsSuccess = true,
				RewardItemDataList = list,
				ExploreRecordInfo = exploreRecordInfo,
				ButtonInfoList = buttonInfoList,
				IsBagFull = new bool?(notify.IsPkgFull)
			};
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardViewNew(data);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, 0);
		}

		// Token: 0x06042EE1 RID: 274145 RVA: 0x0112E684 File Offset: 0x0112C884
		private void OnWorldDoneAndCloseLoading()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return;
			}
			using (List<int>.Enumerator enumerator = ControllerBase<ActivityRoleTrialController>.Instance.CurrentActivityIdList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int trialActivityId = enumerator.Current;
					ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(trialActivityId) as ActivityRoleTrialData;
					if (activityRoleTrialData != null && activityRoleTrialData.IsRoleInstanceOn())
					{
						int currentActivityId = ControllerBase<CyberPunkController>.Instance.CurrentActivityId;
						CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
						if ((((instance != null) ? instance.GetTrialRoleListByCyberPunkActivityId(currentActivityId) : null) ?? Array.Empty<EdgeRunnerTrial>()).Any((EdgeRunnerTrial trialConfig) => trialConfig.ActivityId == trialActivityId))
						{
							activityRoleTrialData.SetRoleTrialState(ERoleTrialFlowState.ActivityOn);
							if (this.GetCyberPunkData() == null)
							{
								break;
							}
							ControllerBase<ActivityController>.Instance.OpenActivityById(currentActivityId, EActivityViewOpenType.Other, null, delegate(bool _)
							{
								if (this.GetCyberPunkData() == null)
								{
									return;
								}
								Singleton<UiManager>.Instance.OpenView(EUiViewName.CyberPunkTrialRoleView, null, null);
							});
							break;
						}
					}
				}
			}
		}

		// Token: 0x06042EE2 RID: 274146 RVA: 0x0112E77C File Offset: 0x0112C97C
		[NullableContext(0)]
		public UniTask<bool> OpenAdamSmasherSelectView()
		{
			AdamSmasherController.<OpenAdamSmasherSelectView>d__13 <OpenAdamSmasherSelectView>d__;
			<OpenAdamSmasherSelectView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenAdamSmasherSelectView>d__.<>1__state = -1;
			<OpenAdamSmasherSelectView>d__.<>t__builder.Start<AdamSmasherController.<OpenAdamSmasherSelectView>d__13>(ref <OpenAdamSmasherSelectView>d__);
			return <OpenAdamSmasherSelectView>d__.<>t__builder.Task;
		}

		// Token: 0x06042EE3 RID: 274147 RVA: 0x0112E7B8 File Offset: 0x0112C9B8
		public bool IsStageUnlocked(int stageId)
		{
			IReadOnlyList<EdgeRunnerLordGym> stageConfigList = this.GetStageConfigList();
			if (stageConfigList == null || stageConfigList.Count == 0)
			{
				return false;
			}
			if (stageConfigList[0].Id == stageId)
			{
				return true;
			}
			this.GetCyberPunkData();
			return this.IsStageCleared(stageId - 1);
		}

		// Token: 0x06042EE4 RID: 274148 RVA: 0x0112E800 File Offset: 0x0112CA00
		public bool IsStageCleared(int stageId)
		{
			CyberPunkData cyberPunkData = this.GetCyberPunkData();
			EdgeRunnerLordGymPassRecord edgeRunnerLordGymPassRecord = (cyberPunkData != null) ? cyberPunkData.GetAdamSmasherData(stageId) : null;
			return edgeRunnerLordGymPassRecord != null && edgeRunnerLordGymPassRecord.PassTime > 0;
		}

		// Token: 0x06042EE5 RID: 274149 RVA: 0x0112E830 File Offset: 0x0112CA30
		[NullableContext(0)]
		public UniTask<bool> RequestStartChallenge(int stageId, [Nullable(1)] List<int> roleIdList)
		{
			AdamSmasherController.<RequestStartChallenge>d__16 <RequestStartChallenge>d__;
			<RequestStartChallenge>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestStartChallenge>d__.<>4__this = this;
			<RequestStartChallenge>d__.stageId = stageId;
			<RequestStartChallenge>d__.roleIdList = roleIdList;
			<RequestStartChallenge>d__.<>1__state = -1;
			<RequestStartChallenge>d__.<>t__builder.Start<AdamSmasherController.<RequestStartChallenge>d__16>(ref <RequestStartChallenge>d__);
			return <RequestStartChallenge>d__.<>t__builder.Task;
		}

		// Token: 0x06042EE6 RID: 274150 RVA: 0x0112E884 File Offset: 0x0112CA84
		[NullableContext(0)]
		public UniTask<bool> ReChallenge(int stageId)
		{
			AdamSmasherController.<ReChallenge>d__17 <ReChallenge>d__;
			<ReChallenge>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ReChallenge>d__.<>1__state = -1;
			<ReChallenge>d__.<>t__builder.Start<AdamSmasherController.<ReChallenge>d__17>(ref <ReChallenge>d__);
			return <ReChallenge>d__.<>t__builder.Task;
		}

		// Token: 0x06042EE7 RID: 274151 RVA: 0x0112E8BF File Offset: 0x0112CABF
		public IReadOnlyList<int> GetSelectedRoleIdList()
		{
			return this.SelectedRoleIdList;
		}

		// Token: 0x06042EE8 RID: 274152 RVA: 0x0112E8C8 File Offset: 0x0112CAC8
		[NullableContext(0)]
		public UniTask<bool> EnterAdamSmasherDungeon(int instId)
		{
			AdamSmasherController.<EnterAdamSmasherDungeon>d__19 <EnterAdamSmasherDungeon>d__;
			<EnterAdamSmasherDungeon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EnterAdamSmasherDungeon>d__.<>4__this = this;
			<EnterAdamSmasherDungeon>d__.instId = instId;
			<EnterAdamSmasherDungeon>d__.<>1__state = -1;
			<EnterAdamSmasherDungeon>d__.<>t__builder.Start<AdamSmasherController.<EnterAdamSmasherDungeon>d__19>(ref <EnterAdamSmasherDungeon>d__);
			return <EnterAdamSmasherDungeon>d__.<>t__builder.Task;
		}

		// Token: 0x06042EE9 RID: 274153 RVA: 0x0112E914 File Offset: 0x0112CB14
		[NullableContext(2)]
		public AdamStageDetailInfo GetStageDetailInfo(int stageId)
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			EdgeRunnerLordGym? edgeRunnerLordGym = (instance != null) ? instance.GetStageConfig(stageId) : null;
			if (edgeRunnerLordGym == null)
			{
				return null;
			}
			CyberPunkData cyberPunkData = this.GetCyberPunkData();
			EdgeRunnerLordGymPassRecord edgeRunnerLordGymPassRecord = (cyberPunkData != null) ? cyberPunkData.GetAdamSmasherData(stageId) : null;
			return new AdamStageDetailInfo
			{
				RecommendLevel = edgeRunnerLordGym.Value.Level,
				BuffDesc = (edgeRunnerLordGym.Value.BuffDesc ?? ""),
				BestScore = 0,
				BestTime = ((edgeRunnerLordGymPassRecord != null) ? edgeRunnerLordGymPassRecord.PassTime : 0),
				HasFirstClearReward = (edgeRunnerLordGym.Value.RewardId > 0),
				FirstClearRewardClaimed = (edgeRunnerLordGymPassRecord != null)
			};
		}

		// Token: 0x06042EEA RID: 274154 RVA: 0x0112E9D0 File Offset: 0x0112CBD0
		public List<TItem> GetSelectedStageRewardPreview(int stageId)
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			int num = (instance != null) ? instance.GetFirstRewardPreview(stageId) : 0;
			if (num <= 0)
			{
				return new List<TItem>();
			}
			List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(num, null);
			if (exchangeRewardPreviewRewardList == null)
			{
				return new List<TItem>();
			}
			return exchangeRewardPreviewRewardList;
		}

		// Token: 0x06042EEB RID: 274155 RVA: 0x0112EA1C File Offset: 0x0112CC1C
		[NullableContext(2)]
		public string GetStageRecordText(int stageId)
		{
			CyberPunkData cyberPunkData = this.GetCyberPunkData();
			EdgeRunnerLordGymPassRecord edgeRunnerLordGymPassRecord = (cyberPunkData != null) ? cyberPunkData.GetAdamSmasherData(stageId) : null;
			if (edgeRunnerLordGymPassRecord == null || edgeRunnerLordGymPassRecord.PassTime <= 0)
			{
				return null;
			}
			int num = edgeRunnerLordGymPassRecord.PassTime / 60;
			int num2 = edgeRunnerLordGymPassRecord.PassTime % 60;
			return num.ToString("D2") + ":" + num2.ToString("D2");
		}

		// Token: 0x06042EEC RID: 274156 RVA: 0x0112EA84 File Offset: 0x0112CC84
		public int[] GetTrialRoleIds(int stageId)
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			EdgeRunnerLordGym? edgeRunnerLordGym = (instance != null) ? instance.GetStageConfig(stageId) : null;
			return ((edgeRunnerLordGym != null) ? edgeRunnerLordGym.GetValueOrDefault().GetTrialRoleArray() : null) ?? Array.Empty<int>();
		}

		// Token: 0x06042EED RID: 274157 RVA: 0x0112EAD0 File Offset: 0x0112CCD0
		public int[] GetUpRoleIds(int stageId)
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			EdgeRunnerLordGym? edgeRunnerLordGym = (instance != null) ? instance.GetStageConfig(stageId) : null;
			return ((edgeRunnerLordGym != null) ? edgeRunnerLordGym.GetValueOrDefault().GetUpRoleArray() : null) ?? Array.Empty<int>();
		}

		// Token: 0x06042EEE RID: 274158 RVA: 0x0112EB1C File Offset: 0x0112CD1C
		public bool IsInAdamSmasherDungeon()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			InstanceDungeon? instanceDungeon = (instance != null) ? instance.InstanceDungeon : null;
			return instanceDungeon != null && instanceDungeon.Value.InstSubType == 56;
		}

		// Token: 0x06042EEF RID: 274159 RVA: 0x0112EB64 File Offset: 0x0112CD64
		private bool IsCyberPunkActivityEnded()
		{
			int currentActivityId = ControllerBase<CyberPunkController>.Instance.CurrentActivityId;
			if (currentActivityId <= 0)
			{
				return false;
			}
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(currentActivityId);
			return activityById == null || !activityById.CheckIfInOpenTime();
		}

		// Token: 0x06042EF0 RID: 274160 RVA: 0x0112EB9C File Offset: 0x0112CD9C
		private void OpenActivityEndedFailView(EdgeRunnerLordGymLevelPlayResultNotify notify)
		{
			int num;
			if (notify.FailLoadGymId == 0)
			{
				EdgeRunnerLordGymPassRecord lordGymPassRecord = notify.LordGymPassRecord;
				num = ((lordGymPassRecord != null) ? lordGymPassRecord.LoadGymId : 0);
			}
			else
			{
				num = notify.FailLoadGymId;
			}
			int stageId = num;
			AdamSmasherChallengeFailViewParam param = new AdamSmasherChallengeFailViewParam
			{
				StageId = stageId,
				IsActivityEnded = true
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AdamSmasherChallengeFailView, param, null);
		}

		// Token: 0x06042EF1 RID: 274161 RVA: 0x0112EBF4 File Offset: 0x0112CDF4
		[NullableContext(2)]
		private CyberPunkData GetCyberPunkData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.EdgeRunnerActivity);
			if (currentActivitiesByType != null && currentActivitiesByType.Count > 0)
			{
				return currentActivitiesByType[0] as CyberPunkData;
			}
			return null;
		}

		// Token: 0x06042EF2 RID: 274162 RVA: 0x0112EC28 File Offset: 0x0112CE28
		[NullableContext(2)]
		private IReadOnlyList<EdgeRunnerLordGym> GetStageConfigList()
		{
			int currentActivityId = ControllerBase<CyberPunkController>.Instance.CurrentActivityId;
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.GetStageConfigList(currentActivityId);
		}

		// Token: 0x06042EF3 RID: 274163 RVA: 0x0112EC54 File Offset: 0x0112CE54
		private int GetNextStageId(int stageId)
		{
			IReadOnlyList<EdgeRunnerLordGym> stageConfigList = this.GetStageConfigList();
			if (stageConfigList == null || stageConfigList.Count == 0)
			{
				return 0;
			}
			int num = -1;
			for (int i = 0; i < stageConfigList.Count; i++)
			{
				if (stageConfigList[i].Id == stageId)
				{
					num = i;
					break;
				}
			}
			if (num < 0 || num >= stageConfigList.Count - 1)
			{
				return 0;
			}
			return stageConfigList[num + 1].Id;
		}

		// Token: 0x0402549E RID: 152734
		private const string LOG_TAG = "[AdamSmasher]";

		// Token: 0x0402549F RID: 152735
		private const int ADAM_SMASHER_ACTIVITY_UID = 0;

		// Token: 0x040254A0 RID: 152736
		private const int SECONDS_PER_MINUTE = 60;

		// Token: 0x040254A1 RID: 152737
		private List<int> SelectedRoleIdList = new List<int>();
	}
}
