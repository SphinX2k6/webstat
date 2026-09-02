using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200636C RID: 25452
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivitySolarSpeedController : ActivityControllerBase<ActivitySolarSpeedController>
	{
		// Token: 0x0603FE7B RID: 261755 RVA: 0x010646CA File Offset: 0x010628CA
		protected override void OnOpenView(ActivityBaseData data)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
		}

		// Token: 0x0603FE7C RID: 261756 RVA: 0x010646E2 File Offset: 0x010628E2
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_GongduolaOnlineGuide";
		}

		// Token: 0x0603FE7D RID: 261757 RVA: 0x010646E9 File Offset: 0x010628E9
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySolarSpeedSubView();
		}

		// Token: 0x0603FE7E RID: 261758 RVA: 0x010646F0 File Offset: 0x010628F0
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return ModelBase<SolarSpeedModel>.Instance.ActivityData;
		}

		// Token: 0x0603FE7F RID: 261759 RVA: 0x010646FC File Offset: 0x010628FC
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603FE80 RID: 261760 RVA: 0x010646FF File Offset: 0x010628FF
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<TeamParkourTaskNotify>(ENotifyMessageId.TeamParkourTaskNotify, new Action<TeamParkourTaskNotify, Net.CallbackStatus>(this.HandleTeamParkourTaskNotify));
			Singleton<Net>.Instance.Register<TeamParkourSettleNotify>(ENotifyMessageId.TeamParkourSettleNotify, new Action<TeamParkourSettleNotify, Net.CallbackStatus>(this.HandleTeamParkourSettleNotify));
		}

		// Token: 0x0603FE81 RID: 261761 RVA: 0x01064739 File Offset: 0x01062939
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeamParkourTaskNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeamParkourSettleNotify);
		}

		// Token: 0x0603FE82 RID: 261762 RVA: 0x0106475B File Offset: 0x0106295B
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnSelectInstanceIdChallenge, new Action<int>(this.HandleOnSelectInstanceIdChallenge));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.CloseInstanceEntrancePositively, new Action<int>(this.HandleCloseInstanceEntrancePositively));
		}

		// Token: 0x0603FE83 RID: 261763 RVA: 0x01064795 File Offset: 0x01062995
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectInstanceIdChallenge, new Action<int>(this.HandleOnSelectInstanceIdChallenge));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseInstanceEntrancePositively, new Action<int>(this.HandleCloseInstanceEntrancePositively));
		}

		// Token: 0x0603FE84 RID: 261764 RVA: 0x010647D0 File Offset: 0x010629D0
		public override bool GetActivityLevelUnlockState(int instanceId)
		{
			bool flag;
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				int ownerId = ModelBase<OnlineModel>.Instance.OwnerId;
				flag = (id.GetValueOrDefault() == ownerId & id != null);
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			return ModelBase<SolarSpeedModel>.Instance.IsUnlockByInstanceId(instanceId) && flag2;
		}

		// Token: 0x0603FE85 RID: 261765 RVA: 0x01064824 File Offset: 0x01062A24
		[NullableContext(0)]
		public UniTask<bool> RequestTeamParkourRewardRequest(int uid)
		{
			ActivitySolarSpeedController.<RequestTeamParkourRewardRequest>d__10 <RequestTeamParkourRewardRequest>d__;
			<RequestTeamParkourRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestTeamParkourRewardRequest>d__.uid = uid;
			<RequestTeamParkourRewardRequest>d__.<>1__state = -1;
			<RequestTeamParkourRewardRequest>d__.<>t__builder.Start<ActivitySolarSpeedController.<RequestTeamParkourRewardRequest>d__10>(ref <RequestTeamParkourRewardRequest>d__);
			return <RequestTeamParkourRewardRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE86 RID: 261766 RVA: 0x01064867 File Offset: 0x01062A67
		public void SyncCurrentChosenLevelId(int id)
		{
			ModelBase<SolarSpeedModel>.Instance.SetCurrentChosenTabInRewardView(id);
		}

		// Token: 0x0603FE87 RID: 261767 RVA: 0x01064874 File Offset: 0x01062A74
		public void HandleConfirmClickInActivitySubView()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(9000, 0, null);
		}

		// Token: 0x0603FE88 RID: 261768 RVA: 0x01064888 File Offset: 0x01062A88
		public void HandleOnClickRewardInActivitySubView()
		{
			SolarSpeedModel instance = ModelBase<SolarSpeedModel>.Instance;
			if (instance.ActivityData.IsUnLock())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SolarSpeedRewardView, instance.BuildSolarSpeedRewardViewDataById(instance.DefaultLevelIdInRewardView), null);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("LianjiPaoku_Reward_Cannot_Open_Tips", Array.Empty<object>());
		}

		// Token: 0x0603FE89 RID: 261769 RVA: 0x010648D9 File Offset: 0x01062AD9
		public void HandleClickPlayerInResultView(int playerId)
		{
			ControllerBase<FriendController>.Instance.RequestFriendApplyAddSend(playerId, FriendApplyWay.RecentlyTeam);
		}

		// Token: 0x0603FE8A RID: 261770 RVA: 0x010648E8 File Offset: 0x01062AE8
		public void HandleClickNextInResultView()
		{
			SolarSpeedModel instance = ModelBase<SolarSpeedModel>.Instance;
			RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "LianjiPaoku_End_Leave",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = new Action<int>(ActivitySolarSpeedController.<HandleClickNextInResultView>g__OnClickQuit|15_0)
			};
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(3024, true, null, null, null, new List<IRewardExploreConfirmButton>
			{
				item
			}, null, null, null, null, null, null, null, instance.BuildSettleReachTargetData(), null, null, null);
		}

		// Token: 0x0603FE8B RID: 261771 RVA: 0x01064973 File Offset: 0x01062B73
		[NullableContext(2)]
		public string GetInstanceSubtitleTextIdByInstanceId(int instanceId)
		{
			return ModelBase<SolarSpeedModel>.Instance.GetInstanceSubtitleTextIdByInstanceId(instanceId);
		}

		// Token: 0x0603FE8C RID: 261772 RVA: 0x01064980 File Offset: 0x01062B80
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetInstanceSubtitleArgsByInstanceId(int instanceId)
		{
			return ModelBase<SolarSpeedModel>.Instance.GetInstanceSubtitleArgsByInstanceId(instanceId);
		}

		// Token: 0x0603FE8D RID: 261773 RVA: 0x0106498D File Offset: 0x01062B8D
		private void HandleTeamParkourTaskNotify(TeamParkourTaskNotify msg, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<SolarSpeedModel>.Instance.SyncTeamParkourTaskNotify(msg);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<SolarSpeedModel>.Instance.CurrentActivityId);
		}

		// Token: 0x0603FE8E RID: 261774 RVA: 0x010649B4 File Offset: 0x01062BB4
		private void HandleTeamParkourSettleNotify(TeamParkourSettleNotify msg, [Nullable(2)] Net.CallbackStatus _)
		{
			foreach (PlayerSettleInfo playerSettleInfo in msg.PlayerSettleInfos)
			{
			}
			SolarSpeedModel instance = ModelBase<SolarSpeedModel>.Instance;
			instance.SyncTeamParkourSettleNotify(msg);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SolarSpeedResultView, instance.BuildSolarSpeedResultViewData(), null);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, instance.CurrentActivityId);
		}

		// Token: 0x0603FE8F RID: 261775 RVA: 0x01064A34 File Offset: 0x01062C34
		private void HandleOnSelectInstanceIdChallenge(int instanceId)
		{
			if (ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByInstanceId(instanceId) != 9000)
			{
				return;
			}
			SolarSpeedModel instance = ModelBase<SolarSpeedModel>.Instance;
			instance.SyncInstanceClicked(instanceId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnChallengeInstanceRedDot, instanceId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, instance.CurrentActivityId);
		}

		// Token: 0x0603FE90 RID: 261776 RVA: 0x01064A88 File Offset: 0x01062C88
		private void HandleCloseInstanceEntrancePositively(int entranceId)
		{
			if (entranceId != 9000)
			{
				return;
			}
			ControllerBase<BlackScreenController>.Instance.AddBlackScreen("Start", "SolarSpeed", "Black");
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "SolarSpeed");
			}, 300f, null, null, true, 1f);
		}

		// Token: 0x0603FE92 RID: 261778 RVA: 0x01064AF6 File Offset: 0x01062CF6
		[CompilerGenerated]
		internal static void <HandleClickNextInResultView>g__OnClickQuit|15_0(int _)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
		}
	}
}
