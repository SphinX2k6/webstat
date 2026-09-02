using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D92 RID: 23954
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class DreamLinkController : ActivityControllerBase<DreamLinkController>
	{
		// Token: 0x0603C4FF RID: 247039 RVA: 0x00F4E340 File Offset: 0x00F4C540
		protected override void OnOpenView(ActivityBaseData data)
		{
			DreamLinkData dreamLinkData = data as DreamLinkData;
			if (!dreamLinkData.IsDreamLinkFunctionUnlock(0))
			{
				int unFinishPreGuideQuestId = dreamLinkData.GetUnFinishPreGuideQuestId();
				dreamLinkData.SaveQuestRedDotState();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			dreamLinkData.GetActivityConfig();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DreamLinkMainView, 1, null);
		}

		// Token: 0x0603C500 RID: 247040 RVA: 0x00F4E39E File Offset: 0x00F4C59E
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiView_DreamLandActivity";
		}

		// Token: 0x0603C501 RID: 247041 RVA: 0x00F4E3A5 File Offset: 0x00F4C5A5
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new DreamLinkActivitySubView();
		}

		// Token: 0x0603C502 RID: 247042 RVA: 0x00F4E3AC File Offset: 0x00F4C5AC
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new DreamLinkData();
		}

		// Token: 0x0603C503 RID: 247043 RVA: 0x00F4E3B3 File Offset: 0x00F4C5B3
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603C504 RID: 247044 RVA: 0x00F4E3B8 File Offset: 0x00F4C5B8
		[NullableContext(2)]
		public DreamLinkData GetCurrentActivityData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.RogueWhiteCat);
			DreamLinkData result = null;
			foreach (ActivityBaseData activityBaseData in currentActivitiesByType)
			{
				result = (activityBaseData as DreamLinkData);
			}
			return result;
		}

		// Token: 0x0603C505 RID: 247045 RVA: 0x00F4E414 File Offset: 0x00F4C614
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.DreamLinkDungeonView, new Func<EUiViewName, object, bool>(this.OpenViewCheck), "DreamLinkDungeonView.Check");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.DreamLinkWhiteCatView, new Func<EUiViewName, object, bool>(this.OpenViewCheck), "DreamLinkWhiteCatView.Check");
		}

		// Token: 0x0603C506 RID: 247046 RVA: 0x00F4E480 File Offset: 0x00F4C680
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.DreamLinkDungeonView, new Func<EUiViewName, object, bool>(this.OpenViewCheck));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.DreamLinkWhiteCatView, new Func<EUiViewName, object, bool>(this.OpenViewCheck));
		}

		// Token: 0x0603C507 RID: 247047 RVA: 0x00F4E4DF File Offset: 0x00F4C6DF
		private bool OpenViewCheck(EUiViewName viewName, object openParam)
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("DreamLink_MultiModeNotSupport", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x0603C508 RID: 247048 RVA: 0x00F4E504 File Offset: 0x00F4C704
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RogueWhiteCatDataUpdateNotify>(ENotifyMessageId.RogueWhiteCatDataUpdateNotify, new Action<RogueWhiteCatDataUpdateNotify, Net.CallbackStatus>(this.OnRogueWhiteCatDataUpdateNotify));
			Singleton<Net>.Instance.Register<RogueWhiteCatLimitedUpdateNotify>(ENotifyMessageId.RogueWhiteCatLimitedUpdateNotify, new Action<RogueWhiteCatLimitedUpdateNotify, Net.CallbackStatus>(this.OnRogueWhiteCatLimitedUpdateNotify));
			Singleton<Net>.Instance.Register<RogueLevelPlayNotify>(ENotifyMessageId.RogueLevelPlayNotify, new Action<RogueLevelPlayNotify, Net.CallbackStatus>(this.OnRogueLevelPlayNotify));
			Singleton<Net>.Instance.Register<RogueBossLinkSettleNotify>(ENotifyMessageId.RogueBossLinkSettleNotify, new Action<RogueBossLinkSettleNotify, Net.CallbackStatus>(this.OnRogueBossLinkSettleNotify));
		}

		// Token: 0x0603C509 RID: 247049 RVA: 0x00F4E584 File Offset: 0x00F4C784
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWhiteCatDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWhiteCatLimitedUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueLevelPlayNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueBossLinkSettleNotify);
		}

		// Token: 0x0603C50A RID: 247050 RVA: 0x00F4E5D4 File Offset: 0x00F4C7D4
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason arg3)
		{
			DreamLinkData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			if (currentActivityData.LocalConfig.Value.PreShowGuideQuest().Contains(questId))
			{
				currentActivityData.RefreshActivityRedDotState();
			}
		}

		// Token: 0x0603C50B RID: 247051 RVA: 0x00F4E60D File Offset: 0x00F4C80D
		private void OnRogueBossLinkSettleNotify(RogueBossLinkSettleNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DreamLinkWhiteCatSettleView, data, null);
		}

		// Token: 0x0603C50C RID: 247052 RVA: 0x00F4E620 File Offset: 0x00F4C820
		private void OnRogueWhiteCatDataUpdateNotify(RogueWhiteCatDataUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			DreamLinkData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.UpdateData(data);
		}

		// Token: 0x0603C50D RID: 247053 RVA: 0x00F4E640 File Offset: 0x00F4C840
		private void OnRogueWhiteCatLimitedUpdateNotify(RogueWhiteCatLimitedUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			DreamLinkData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.RefreshAllLimitTimeReward(data.RogueLimitedAwards.ToList<RogueLimitedAward>());
			currentActivityData.RefreshLimitRewardPerformance();
		}

		// Token: 0x0603C50E RID: 247054 RVA: 0x00F4E670 File Offset: 0x00F4C870
		private unsafe void OnRogueLevelPlayNotify(RogueLevelPlayNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			if (this.GetCurrentActivityData() == null)
			{
				return;
			}
			RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_45_ButtonText_1",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true
			};
			RewardExploreRecordData rewardExploreRecordData = new RewardExploreRecordData
			{
				TitleTextId = "WorldRun_Settlement",
				Record = Singleton<TimeUtil>.Instance.GetTimeString((double)Math.Max(data.UseTime, 0)),
				IsNewRecord = data.IsNewRecord
			};
			ItemRewardController instance = ControllerBase<ItemRewardController>.Instance;
			int configId = 3020;
			bool isSuccess = data.IsSuccess;
			List<RewardItemData> rewardItemDataList = null;
			IRewardExploreRecord exploreRecordInfo = rewardExploreRecordData;
			List<IRewardExploreBar> exploreBarDataList = null;
			int num = 1;
			List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>(num);
			CollectionsMarshal.SetCount<IRewardExploreConfirmButton>(list, num);
			Span<IRewardExploreConfirmButton> span = CollectionsMarshal.AsSpan<IRewardExploreConfirmButton>(list);
			int index = 0;
			*span[index] = rewardExploreConfirmButtonData;
			instance.OpenExploreRewardView(configId, isSuccess, rewardItemDataList, exploreRecordInfo, exploreBarDataList, list, null, null, null, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0603C50F RID: 247055 RVA: 0x00F4E740 File Offset: 0x00F4C940
		public override bool GetActivityMapMarkState(int markId)
		{
			DreamLinkData currentActivityData = this.GetCurrentActivityData();
			return currentActivityData != null && currentActivityData.IsDreamLinkRunMarkShow(markId);
		}

		// Token: 0x0603C510 RID: 247056 RVA: 0x00F4E760 File Offset: 0x00F4C960
		public void RoguelikeSetDungeonProgressRequest(int progress)
		{
			RogueWhiteCatRecordRequest rogueWhiteCatRecordRequest = RogueWhiteCatRecordRequest.Create();
			rogueWhiteCatRecordRequest.Value = progress;
			rogueWhiteCatRecordRequest.ActivityId = this.GetCurrentActivityData().Id;
			Singleton<Net>.Instance.Call<RogueWhiteCatRecordResponse>(ERequestMessageId.RogueWhiteCatRecordRequest, rogueWhiteCatRecordRequest, delegate(RogueWhiteCatRecordResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27006, null, true, true);
					return;
				}
				this.GetCurrentActivityData().DungeonProgressRecord = progress;
			}, 0);
		}

		// Token: 0x0603C511 RID: 247057 RVA: 0x00F4E7C4 File Offset: 0x00F4C9C4
		public void RoguelikeRoleInstStartRequest(int dungeonIndex)
		{
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			if (ModelBase<SceneTeamModel>.Instance.IsPhantomTeam)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
				return;
			}
			DreamLinkData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			RoguelikeRoleInstStartRequest roguelikeRoleInstStartRequest = Aki.Protocol.RoguelikeRoleInstStartRequest.Create();
			roguelikeRoleInstStartRequest.Index = dungeonIndex;
			roguelikeRoleInstStartRequest.ActivityId = currentActivityData.Id;
			Singleton<Net>.Instance.Call<RoguelikeRoleInstStartResponse>(ERequestMessageId.RoguelikeRoleInstStartRequest, roguelikeRoleInstStartRequest, delegate(RoguelikeRoleInstStartResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.DreamLink, ELogAuthor.LPH, "RoleInstStartRequest response is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26578, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603C512 RID: 247058 RVA: 0x00F4E868 File Offset: 0x00F4CA68
		public void RunTaskRewardRequest(int id)
		{
			DreamLinkData dreamLinkData = this.GetCurrentActivityData();
			if (dreamLinkData == null)
			{
				return;
			}
			RoguelikeWriteCatLevelPlayRewardRequest roguelikeWriteCatLevelPlayRewardRequest = RoguelikeWriteCatLevelPlayRewardRequest.Create();
			roguelikeWriteCatLevelPlayRewardRequest.Index = id;
			roguelikeWriteCatLevelPlayRewardRequest.ActivityId = dreamLinkData.Id;
			Singleton<Net>.Instance.Call<RoguelikeWriteCatLevelPlayRewardResponse>(ERequestMessageId.RoguelikeWriteCatLevelPlayRewardRequest, roguelikeWriteCatLevelPlayRewardRequest, delegate(RoguelikeWriteCatLevelPlayRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15620, null, true, true);
					return;
				}
				dreamLinkData.SetRunTaskDone(id);
				dreamLinkData.RefreshRewardPerformance();
			}, 0);
		}

		// Token: 0x0603C513 RID: 247059 RVA: 0x00F4E8D8 File Offset: 0x00F4CAD8
		public void MultiEnergyRewardRequest(int[] ids)
		{
			DreamLinkData dreamLinkData = this.GetCurrentActivityData();
			if (dreamLinkData == null)
			{
				return;
			}
			MulRoguelikeWriteCatRewardRequest mulRoguelikeWriteCatRewardRequest = MulRoguelikeWriteCatRewardRequest.Create();
			mulRoguelikeWriteCatRewardRequest.Index.AddRange(ids);
			mulRoguelikeWriteCatRewardRequest.ActivityId = dreamLinkData.Id;
			Singleton<Net>.Instance.Call<MulRoguelikeWriteCatRewardResponse>(ERequestMessageId.MulRoguelikeWriteCatRewardRequest, mulRoguelikeWriteCatRewardRequest, delegate(MulRoguelikeWriteCatRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26440, null, true, true);
					return;
				}
				foreach (int id in ids)
				{
					dreamLinkData.RefreshEnergyRewardData(id, EActivityTaskState.FinishedAndClaimed);
				}
				dreamLinkData.RefreshRewardPerformance();
			}, 0);
		}

		// Token: 0x0603C514 RID: 247060 RVA: 0x00F4E94C File Offset: 0x00F4CB4C
		public void LimitTimeRewardRequest(int id)
		{
			DreamLinkData dreamLinkData = this.GetCurrentActivityData();
			if (dreamLinkData == null)
			{
				return;
			}
			RogueWhiteCatLimitedRewardRequest rogueWhiteCatLimitedRewardRequest = RogueWhiteCatLimitedRewardRequest.Create();
			rogueWhiteCatLimitedRewardRequest.Index = id;
			Singleton<Net>.Instance.Call<RogueWhiteCatLimitedRewardResponse>(ERequestMessageId.RogueWhiteCatLimitedRewardRequest, rogueWhiteCatLimitedRewardRequest, delegate(RogueWhiteCatLimitedRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24861, null, true, true);
					return;
				}
				dreamLinkData.RefreshLimitTimeRewardData(id, EActivityTaskState.FinishedAndClaimed, null, null);
				dreamLinkData.RefreshLimitRewardPerformance();
			}, 0);
		}

		// Token: 0x0603C515 RID: 247061 RVA: 0x00F4E9AC File Offset: 0x00F4CBAC
		public void BossRewardRequest(int id)
		{
			DreamLinkData dreamLinkData = this.GetCurrentActivityData();
			if (dreamLinkData == null)
			{
				return;
			}
			RoguelikeWriteCatBossRewardRequest roguelikeWriteCatBossRewardRequest = RoguelikeWriteCatBossRewardRequest.Create();
			roguelikeWriteCatBossRewardRequest.Index = id;
			roguelikeWriteCatBossRewardRequest.ActivityId = dreamLinkData.Id;
			Singleton<Net>.Instance.Call<RoguelikeWriteCatBossRewardResponse>(ERequestMessageId.RoguelikeWriteCatBossRewardRequest, roguelikeWriteCatBossRewardRequest, delegate(RoguelikeWriteCatBossRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29348, null, true, true);
					return;
				}
				dreamLinkData.RefreshBossRewardData(id, EActivityTaskState.FinishedAndClaimed);
				dreamLinkData.RefreshRewardPerformance();
			}, 0);
		}

		// Token: 0x0603C516 RID: 247062 RVA: 0x00F4EA1B File Offset: 0x00F4CC1B
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipDreamLinkView, null, null);
		}
	}
}
