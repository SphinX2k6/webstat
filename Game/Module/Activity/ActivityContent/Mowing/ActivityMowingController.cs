using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Mowing
{
	// Token: 0x02006667 RID: 26215
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityMowingController : ActivityControllerBase<ActivityMowingController>
	{
		// Token: 0x06041772 RID: 268146 RVA: 0x010CDB94 File Offset: 0x010CBD94
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<HarvestActivityPointNotify>(ENotifyMessageId.HarvestActivityPointNotify, new Action<HarvestActivityPointNotify, Net.CallbackStatus>(this.OnHarvestActivityPointNotify));
			Singleton<Net>.Instance.Register<HarvestActivityLevelNotify>(ENotifyMessageId.HarvestActivityLevelNotify, new Action<HarvestActivityLevelNotify, Net.CallbackStatus>(this.OnHarvestActivityLevelNotify));
			Singleton<Net>.Instance.Register<HarvestActivityResultNotify>(ENotifyMessageId.HarvestActivityResultNotify, new Action<HarvestActivityResultNotify, Net.CallbackStatus>(this.OnHarvestActivityResultNotify));
		}

		// Token: 0x06041773 RID: 268147 RVA: 0x010CDBF5 File Offset: 0x010CBDF5
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HarvestActivityPointNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HarvestActivityLevelNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HarvestActivityResultNotify);
		}

		// Token: 0x06041774 RID: 268148 RVA: 0x010CDC27 File Offset: 0x010CBE27
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
			Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
		}

		// Token: 0x06041775 RID: 268149 RVA: 0x010CDC61 File Offset: 0x010CBE61
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
		}

		// Token: 0x06041776 RID: 268150 RVA: 0x010CDC9B File Offset: 0x010CBE9B
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityMowing";
		}

		// Token: 0x06041777 RID: 268151 RVA: 0x010CDCA4 File Offset: 0x010CBEA4
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason _)
		{
			if (this.CurrentActivityId == 0)
			{
				return;
			}
			ActivityMowingData mowingActivityData = this.GetMowingActivityData();
			if (mowingActivityData == null)
			{
				return;
			}
			ActivityMowingData activityMowingData = mowingActivityData;
			int[] array = (activityMowingData.LocalConfig != null) ? activityMowingData.LocalConfig.GetValueOrDefault().PreShowGuideQuest() : null;
			if (array != null && Array.IndexOf<int>(array, questId) >= 0)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mowingActivityData.Id);
			}
		}

		// Token: 0x06041778 RID: 268152 RVA: 0x010CDD08 File Offset: 0x010CBF08
		private void OnLeaveInstanceDungeonConfirm()
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsMowingInstanceDungeon())
			{
				this.RequestExitDungeon();
			}
		}

		// Token: 0x06041779 RID: 268153 RVA: 0x010CDD1C File Offset: 0x010CBF1C
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0604177A RID: 268154 RVA: 0x010CDD1E File Offset: 0x010CBF1E
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityMowingSubView();
		}

		// Token: 0x0604177B RID: 268155 RVA: 0x010CDD25 File Offset: 0x010CBF25
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.CurrentActivityId = data.Id;
			return new ActivityMowingData();
		}

		// Token: 0x0604177C RID: 268156 RVA: 0x010CDD38 File Offset: 0x010CBF38
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0604177D RID: 268157 RVA: 0x010CDD3C File Offset: 0x010CBF3C
		public void RequestGetPointReward(int activityId, int rewardUid)
		{
			HarvestActivityPointRequest harvestActivityPointRequest = HarvestActivityPointRequest.Create();
			harvestActivityPointRequest.ActivityId = activityId;
			harvestActivityPointRequest.Id = rewardUid;
			Singleton<Net>.Instance.Call<HarvestActivityPointResponse>(ERequestMessageId.HarvestActivityPointRequest, harvestActivityPointRequest, delegate(HarvestActivityPointResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22129, null, true, true);
					return;
				}
				ActivityMowingData activityMowingData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityMowingData;
				activityMowingData.SetPointRewardState(rewardUid);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, activityId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
				{
					Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, activityMowingData.GetRewardViewData());
				}
			}, 0);
		}

		// Token: 0x0604177E RID: 268158 RVA: 0x010CDD98 File Offset: 0x010CBF98
		public void RequestGetLevelReward(int activityId, int instanceId, int rewardUid)
		{
			HarvestActivityLevelRequest harvestActivityLevelRequest = HarvestActivityLevelRequest.Create();
			harvestActivityLevelRequest.ActivityId = activityId;
			harvestActivityLevelRequest.InstId = instanceId;
			Singleton<Net>.Instance.Call<HarvestActivityLevelResponse>(ERequestMessageId.HarvestActivityLevelRequest, harvestActivityLevelRequest, delegate(HarvestActivityLevelResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15797, null, true, true);
					return;
				}
				ActivityMowingData activityMowingData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityMowingData;
				activityMowingData.SetLevelRewardStateToGot(instanceId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, activityId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
				{
					Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, activityMowingData.GetRewardViewData());
				}
			}, 0);
		}

		// Token: 0x0604177F RID: 268159 RVA: 0x010CDDF4 File Offset: 0x010CBFF4
		public void RequestSetDifficulty(int activityId, int diff)
		{
			HarvestActivityLevelDiffRequest harvestActivityLevelDiffRequest = HarvestActivityLevelDiffRequest.Create();
			harvestActivityLevelDiffRequest.ActivityId = activityId;
			harvestActivityLevelDiffRequest.Diff = diff;
			Singleton<Net>.Instance.Call<HarvestActivityLevelDiffResponse>(ERequestMessageId.HarvestActivityLevelDiffRequest, harvestActivityLevelDiffRequest, delegate(HarvestActivityLevelDiffResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19118, null, true, true);
				}
				ActivityMowingData activityMowingData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityMowingData;
				if (((activityMowingData != null) ? activityMowingData.MowingLevelInfoDict : null) != null)
				{
					foreach (KeyValuePair<int, HarvestLevelReward> keyValuePair in activityMowingData.MowingLevelInfoDict)
					{
						keyValuePair.Value.Diff = diff;
					}
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshInstancedRecommendLevel);
			}, 0);
		}

		// Token: 0x06041780 RID: 268160 RVA: 0x010CDE50 File Offset: 0x010CC050
		public void RequestSetDifficultyAll(int activityId, int diff)
		{
			if (this.GetMowingActivityData() == null)
			{
				return;
			}
			this.RequestSetDifficulty(activityId, diff);
		}

		// Token: 0x06041781 RID: 268161 RVA: 0x010CDE64 File Offset: 0x010CC064
		private void OnHarvestActivityPointNotify(HarvestActivityPointNotify notify, [Nullable(2)] Net.CallbackStatus status = null)
		{
			(ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as ActivityMowingData).UpdatePointRewards(notify);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, notify.ActivityId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, notify.ActivityId);
		}

		// Token: 0x06041782 RID: 268162 RVA: 0x010CDEB8 File Offset: 0x010CC0B8
		private void OnHarvestActivityLevelNotify(HarvestActivityLevelNotify notify, [Nullable(2)] Net.CallbackStatus status = null)
		{
			(ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as ActivityMowingData).UpdateLevelRewards(notify);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, notify.ActivityId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, notify.ActivityId);
		}

		// Token: 0x06041783 RID: 268163 RVA: 0x010CDF0C File Offset: 0x010CC10C
		private void OnHarvestActivityResultNotify(HarvestActivityResultNotify notify, [Nullable(2)] Net.CallbackStatus status = null)
		{
			bool flag = notify.ErrorCode > Aki.Protocol.ErrorCode.Success;
			if (flag)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(notify.ErrorCode, 24399, null, true, true);
			}
			RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
			rewardExploreConfirmButtonData.ButtonTextId = "ConfirmBox_133_ButtonText_0";
			rewardExploreConfirmButtonData.DescriptionTextId = null;
			rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
			rewardExploreConfirmButtonData.IsClickedCloseView = true;
			rewardExploreConfirmButtonData.OnClickedCallback = delegate(int _)
			{
				ActivityMowingController.<OnHarvestActivityResultNotify>g__OnClickQuit|18_0();
			};
			RewardExploreConfirmButtonData item = rewardExploreConfirmButtonData;
			RewardExploreConfirmButtonData rewardExploreConfirmButtonData2 = new RewardExploreConfirmButtonData();
			rewardExploreConfirmButtonData2.ButtonTextId = "ConfirmBox_133_ButtonText_1";
			rewardExploreConfirmButtonData2.DescriptionTextId = "MowingHighestPoint";
			rewardExploreConfirmButtonData2.DescriptionArgs = new List<object>
			{
				notify.HisPoint.ToString()
			};
			rewardExploreConfirmButtonData2.IsTimeDownCloseView = false;
			rewardExploreConfirmButtonData2.IsClickedCloseView = false;
			rewardExploreConfirmButtonData2.OnClickedCallback = delegate(int _)
			{
				ActivityMowingController.<OnHarvestActivityResultNotify>g__OnClickFight|18_1();
			};
			RewardExploreConfirmButtonData item2 = rewardExploreConfirmButtonData2;
			RewardExploreRecordData rewardExploreRecordData = new RewardExploreRecordData
			{
				TitleTextId = "MowingCurrentPoint",
				Record = notify.CurPoint.ToString(),
				IsNewRecord = (notify.CurPoint > notify.HisPoint)
			};
			ItemRewardController instance = ControllerBase<ItemRewardController>.Instance;
			int configId = flag ? 3012 : 3013;
			bool isSuccess = !flag && notify.Succ;
			List<RewardItemData> rewardItemDataList = null;
			IRewardExploreRecord exploreRecordInfo = flag ? null : rewardExploreRecordData;
			List<IRewardExploreBar> exploreBarDataList = null;
			List<IRewardExploreConfirmButton> buttonInfoList;
			if (!flag)
			{
				List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
				list.Add(item);
				buttonInfoList = list;
				list.Add(item2);
			}
			else
			{
				(buttonInfoList = new List<IRewardExploreConfirmButton>()).Add(item);
			}
			instance.OpenExploreRewardView(configId, isSuccess, rewardItemDataList, exploreRecordInfo, exploreBarDataList, buttonInfoList, null, null, null, null, null, null, null, null, null, null, null);
		}

		// Token: 0x06041784 RID: 268164 RVA: 0x010CE0A4 File Offset: 0x010CC2A4
		public void RequestExitDungeon()
		{
			HarvestActivityResultRequest message = HarvestActivityResultRequest.Create();
			Singleton<Net>.Instance.Call<HarvestActivityResultResponse>(ERequestMessageId.HarvestActivityResultRequest, message, delegate(HarvestActivityResultResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).Forget<bool>();
				}
			}, 0);
		}

		// Token: 0x06041785 RID: 268165 RVA: 0x010CE0E7 File Offset: 0x010CC2E7
		[NullableContext(2)]
		public ActivityMowingData GetMowingActivityData()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentActivityId) as ActivityMowingData;
		}

		// Token: 0x06041786 RID: 268166 RVA: 0x010CE100 File Offset: 0x010CC300
		public override bool GetActivityLevelUnlockState(int levelId)
		{
			ActivityMowingData mowingActivityData = this.GetMowingActivityData();
			return mowingActivityData == null || mowingActivityData.GetActivityLevelUnlockState(levelId);
		}

		// Token: 0x06041787 RID: 268167 RVA: 0x010CE120 File Offset: 0x010CC320
		public bool IsMowingInstanceDungeon(int instanceId)
		{
			if (instanceId == 0)
			{
				return false;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.GetValueOrDefault().InstSubType == 19;
		}

		// Token: 0x06041788 RID: 268168 RVA: 0x010CE15C File Offset: 0x010CC35C
		public int GetRecommendLevel(int instanceId, int worldLevel)
		{
			ActivityMowingData mowingActivityData = this.GetMowingActivityData();
			if (mowingActivityData == null)
			{
				return 0;
			}
			return mowingActivityData.GetLevelDiffRecommendLevel(instanceId);
		}

		// Token: 0x06041789 RID: 268169 RVA: 0x010CE17C File Offset: 0x010CC37C
		public bool CheckIsActivityLevel(int instanceId)
		{
			return this.IsMowingInstanceDungeon(instanceId);
		}

		// Token: 0x0604178B RID: 268171 RVA: 0x010CE18D File Offset: 0x010CC38D
		[CompilerGenerated]
		internal static void <OnHarvestActivityResultNotify>g__OnClickQuit|18_0()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
		}

		// Token: 0x0604178C RID: 268172 RVA: 0x010CE19A File Offset: 0x010CC39A
		[CompilerGenerated]
		internal static void <OnHarvestActivityResultNotify>g__OnClickFight|18_1()
		{
			ControllerBase<InstanceDungeonController>.Instance.SingleInstReChallengeRequest();
		}

		// Token: 0x0402499C RID: 149916
		public int CurrentActivityId;
	}
}
