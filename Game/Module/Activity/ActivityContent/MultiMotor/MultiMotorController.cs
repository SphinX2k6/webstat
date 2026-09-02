using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006654 RID: 26196
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MultiMotorController : ActivityControllerBase<MultiMotorController>
	{
		// Token: 0x0604169E RID: 267934 RVA: 0x010C8950 File Offset: 0x010C6B50
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<OnlineMotorSettleNotify>(ENotifyMessageId.OnlineMotorSettleNotify, new Action<OnlineMotorSettleNotify, Net.CallbackStatus>(this.OnlineMotorSettleNotify));
			Singleton<Net>.Instance.Register<MotorOnlineRankSnapshotNotify>(ENotifyMessageId.MotorOnlineRankSnapshotNotify, new Action<MotorOnlineRankSnapshotNotify, Net.CallbackStatus>(this.MotorOnlineRankSnapshotNotify));
			Singleton<Net>.Instance.Register<OnlineMotorUpdateNotify>(ENotifyMessageId.OnlineMotorUpdateNotify, new Action<OnlineMotorUpdateNotify, Net.CallbackStatus>(this.OnlineMotorUpdateNotify));
			Singleton<Net>.Instance.Register<OnlineMotorStartNotify>(ENotifyMessageId.OnlineMotorStartNotify, new Action<OnlineMotorStartNotify, Net.CallbackStatus>(this.OnlineMotorStartNotify));
			Singleton<Net>.Instance.Register<OnlineMotorEndNotify>(ENotifyMessageId.OnlineMotorEndNotify, new Action<OnlineMotorEndNotify, Net.CallbackStatus>(this.OnlineMotorEndNotify));
			Singleton<Net>.Instance.Register<MotorOnlineRankRuleIdsNotify>(ENotifyMessageId.MotorOnlineRankRuleIdsNotify, new Action<MotorOnlineRankRuleIdsNotify, Net.CallbackStatus>(this.MotorOnlineRankRuleIdsNotify));
		}

		// Token: 0x0604169F RID: 267935 RVA: 0x010C8A08 File Offset: 0x010C6C08
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OnlineMotorSettleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorOnlineRankSnapshotNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OnlineMotorUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OnlineMotorStartNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OnlineMotorEndNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorOnlineRankRuleIdsNotify);
		}

		// Token: 0x060416A0 RID: 267936 RVA: 0x010C8A75 File Offset: 0x010C6C75
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x060416A1 RID: 267937 RVA: 0x010C8A93 File Offset: 0x010C6C93
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x060416A2 RID: 267938 RVA: 0x010C8AB1 File Offset: 0x010C6CB1
		public void OnMultiMotorDataInit()
		{
			if (!this.IsPendingWorldDoneHandle)
			{
				return;
			}
			this.IsPendingWorldDoneHandle = false;
			this.OnWorldDone();
		}

		// Token: 0x060416A3 RID: 267939 RVA: 0x010C8AC9 File Offset: 0x010C6CC9
		public void OnMultiMotorMainViewOpened()
		{
			if (!this.HasPendingStartNotify)
			{
				return;
			}
			this.HasPendingStartNotify = false;
			Singleton<EventSystem>.Instance.Emit(EEventName.MultiMotorStart);
		}

		// Token: 0x060416A4 RID: 267940 RVA: 0x010C8AEC File Offset: 0x010C6CEC
		private void OnWorldDone()
		{
			if (this.CheckInMultiMotorParkourDungeon())
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MultiMotorMainView))
				{
					return;
				}
				int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
				OnlineMotorLevel? motorMultiParkourLevelByInstId = ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelByInstId(instanceId);
				MultiMotorData activityDataById = this.GetActivityDataById(motorMultiParkourLevelByInstId.Value.ActivityId);
				if (activityDataById == null)
				{
					this.IsPendingWorldDoneHandle = true;
					return;
				}
				activityDataById.InitLevelRankData();
				MultiMotorLevelData param;
				activityDataById.LevelDataMap.TryGetValue(motorMultiParkourLevelByInstId.Value.Id, out param);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiMotorMainView, param, null);
			}
		}

		// Token: 0x060416A5 RID: 267941 RVA: 0x010C8B84 File Offset: 0x010C6D84
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			MultiMotorController.<OnOpenSubView>d__9 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<MultiMotorController.<OnOpenSubView>d__9>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x060416A6 RID: 267942 RVA: 0x010C8BC8 File Offset: 0x010C6DC8
		public bool CheckInMultiMotorParkourDungeon()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
				return config != null && config.GetValueOrDefault().InstSubType == 57;
			}
			return false;
		}

		// Token: 0x060416A7 RID: 267943 RVA: 0x010C8C18 File Offset: 0x010C6E18
		private MultiMotorData GetActivityDataById(int activityId)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as MultiMotorData;
		}

		// Token: 0x060416A8 RID: 267944 RVA: 0x010C8C2C File Offset: 0x010C6E2C
		private void OnlineMotorSettleNotify(OnlineMotorSettleNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RepeatedField<OnlineMotorSettleInfo> settleInfos = notify.SettleInfos;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiMotorSettlementView, settleInfos, null);
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MultiMotorMainView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.MultiMotorMainView, null);
			}
		}

		// Token: 0x060416A9 RID: 267945 RVA: 0x010C8C74 File Offset: 0x010C6E74
		private void MotorOnlineRankSnapshotNotify(MotorOnlineRankSnapshotNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			foreach (MotorOnlineRankPlayerInfo motorOnlineRankPlayerInfo in notify.MotorOnlinePlayerInfoList)
			{
				if (activityData != null)
				{
					activityData.LevelBattleRankMap[motorOnlineRankPlayerInfo.PlayerId] = motorOnlineRankPlayerInfo.Rank;
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.MultiMotorRankInfoRefresh);
		}

		// Token: 0x060416AA RID: 267946 RVA: 0x010C8CF0 File Offset: 0x010C6EF0
		public void MotorOnlineProgressReportPush(int instId, float progress)
		{
			MotorOnlineProgressReportPush motorOnlineProgressReportPush = Aki.Protocol.MotorOnlineProgressReportPush.Create();
			motorOnlineProgressReportPush.InstId = instId;
			motorOnlineProgressReportPush.Progress = (int)progress;
			Singleton<Net>.Instance.Send(EPushMessageId.MotorOnlineProgressReportPush, motorOnlineProgressReportPush);
		}

		// Token: 0x060416AB RID: 267947 RVA: 0x010C8D24 File Offset: 0x010C6F24
		public void MotorOnlineRewardRequest(int levelId)
		{
			bool isGlobalTask = levelId < 0;
			MultiMotorData activityData = isGlobalTask ? ModelBase<MultiMotorModel>.Instance.ActivityData : this.GetActivityDataById(ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelById(levelId).Value.ActivityId);
			if (activityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorParkour, ELogAuthor.LJQ, "联机摩托跑酷活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			OnlineMotorActivityLevelRequest onlineMotorActivityLevelRequest = OnlineMotorActivityLevelRequest.Create();
			List<int> taskList = new List<int>();
			foreach (KeyValuePair<int, MultiMotorTaskData> keyValuePair in activityData.TaskDataMap)
			{
				MultiMotorTaskData value = keyValuePair.Value;
				if (isGlobalTask && value.IsGlobalTask && value.IsFinished)
				{
					taskList.Add(-keyValuePair.Key);
				}
				else if (!isGlobalTask && !value.IsGlobalTask && value.LevelId == levelId && value.IsFinished)
				{
					taskList.Add(keyValuePair.Key);
				}
			}
			onlineMotorActivityLevelRequest.RewardIds.AddRange(taskList);
			onlineMotorActivityLevelRequest.RewardType = (isGlobalTask ? OnlineMotorRewardType.GlobalReward : OnlineMotorRewardType.LevelReward);
			Singleton<Net>.Instance.Call<OnlineMotorActivityLevelResponse>(ERequestMessageId.OnlineMotorActivityLevelRequest, onlineMotorActivityLevelRequest, delegate(OnlineMotorActivityLevelResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19791, null, true, true);
					return;
				}
				foreach (int num in taskList)
				{
					int key = isGlobalTask ? (-num) : num;
					MultiMotorTaskData multiMotorTaskData;
					if (activityData.TaskDataMap.TryGetValue(key, out multiMotorTaskData))
					{
						multiMotorTaskData.RefreshState(EActivityTaskState.FinishedAndClaimed);
					}
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.MultiMotorRefresh);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
			}, 0);
		}

		// Token: 0x060416AC RID: 267948 RVA: 0x010C8EAC File Offset: 0x010C70AC
		private void OnlineMotorUpdateNotify(OnlineMotorUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			MultiMotorModel instance = ModelBase<MultiMotorModel>.Instance;
			MultiMotorData multiMotorData = (instance != null) ? instance.ActivityData : null;
			if (multiMotorData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorParkour, ELogAuthor.LJQ, "联机摩托跑酷活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (notify.LevelInfo != null)
			{
				OnlineMotorLevelInfo levelInfo = notify.LevelInfo;
				MultiMotorLevelData multiMotorLevelData;
				if (!multiMotorData.LevelDataMap.TryGetValue(levelInfo.LevelId, out multiMotorLevelData))
				{
					MultiMotorLevelData multiMotorLevelData2 = new MultiMotorLevelData(levelInfo.LevelId);
					multiMotorLevelData2.RefreshByLevelInfo(levelInfo);
					multiMotorData.LevelDataMap[levelInfo.LevelId] = multiMotorLevelData2;
				}
				else
				{
					multiMotorLevelData.RefreshByLevelInfo(levelInfo);
				}
			}
			if (notify.ActivityTasks != null)
			{
				foreach (OnlineMotorTask onlineMotorTask in notify.ActivityTasks.GlobalTasks)
				{
					MultiMotorTaskData multiMotorTaskData;
					if (!multiMotorData.TaskDataMap.TryGetValue(-onlineMotorTask.TaskId, out multiMotorTaskData))
					{
						MultiMotorTaskData multiMotorTaskData2 = new MultiMotorTaskData(-onlineMotorTask.TaskId);
						multiMotorTaskData2.LevelId = -1;
						multiMotorData.TaskDataMap[-onlineMotorTask.TaskId] = multiMotorTaskData2;
					}
					else
					{
						multiMotorTaskData.RefreshByTaskInfo(onlineMotorTask);
					}
				}
				foreach (OnlineMotorTask onlineMotorTask2 in notify.ActivityTasks.LevelTasks)
				{
					MultiMotorTaskData multiMotorTaskData3;
					if (!multiMotorData.TaskDataMap.TryGetValue(onlineMotorTask2.TaskId, out multiMotorTaskData3))
					{
						MultiMotorTaskData multiMotorTaskData4 = new MultiMotorTaskData(onlineMotorTask2.TaskId);
						OnlineMotorLevelTask? motorLevelTaskByTaskId = ConfigBase<MultiMotorConfig>.Instance.GetMotorLevelTaskByTaskId(onlineMotorTask2.TaskId);
						multiMotorTaskData4.LevelId = ((motorLevelTaskByTaskId != null) ? motorLevelTaskByTaskId.GetValueOrDefault().LevelId : 0);
						multiMotorData.TaskDataMap[onlineMotorTask2.TaskId] = multiMotorTaskData4;
					}
					else
					{
						multiMotorTaskData3.RefreshByTaskInfo(onlineMotorTask2);
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, multiMotorData.Id);
		}

		// Token: 0x060416AD RID: 267949 RVA: 0x010C90B4 File Offset: 0x010C72B4
		private void OnlineMotorStartNotify(OnlineMotorStartNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<MultiMotorModel>.Instance.StartFlowTime = Singleton<MathUtils>.Instance.LongToBigInt(notify.BeginTime);
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MultiMotorMainView))
			{
				this.HasPendingStartNotify = true;
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.MultiMotorStart);
		}

		// Token: 0x060416AE RID: 267950 RVA: 0x010C9104 File Offset: 0x010C7304
		private void OnlineMotorEndNotify(OnlineMotorEndNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.MultiMotorPassLine, notify.PlayerId);
		}

		// Token: 0x060416AF RID: 267951 RVA: 0x010C911C File Offset: 0x010C731C
		private void MotorOnlineRankRuleIdsNotify(MotorOnlineRankRuleIdsNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			foreach (MotorOnlineParkPlayerRuleInfo motorOnlineParkPlayerRuleInfo in notify.MotorOnlinePlayerInfoList)
			{
				foreach (int p in motorOnlineParkPlayerRuleInfo.RuleIds)
				{
					Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.MultiMotorBuffRefresh, motorOnlineParkPlayerRuleInfo.PlayerId, p);
				}
			}
		}

		// Token: 0x060416B0 RID: 267952 RVA: 0x010C91B0 File Offset: 0x010C73B0
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x060416B1 RID: 267953 RVA: 0x010C91B2 File Offset: 0x010C73B2
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiView_ActivityMotorRace";
		}

		// Token: 0x060416B2 RID: 267954 RVA: 0x010C91B9 File Offset: 0x010C73B9
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new MultiMotorSubView();
		}

		// Token: 0x060416B3 RID: 267955 RVA: 0x010C91C0 File Offset: 0x010C73C0
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			ModelBase<MultiMotorModel>.Instance.ActivityId = data.Id;
			return new MultiMotorData();
		}

		// Token: 0x060416B4 RID: 267956 RVA: 0x010C91D7 File Offset: 0x010C73D7
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x04024933 RID: 149811
		private bool IsPendingWorldDoneHandle;

		// Token: 0x04024934 RID: 149812
		private bool HasPendingStartNotify;
	}
}
