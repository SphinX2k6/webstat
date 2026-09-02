using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D2C RID: 23852
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class FlagChallengeController : UiControllerBase<FlagChallengeController>
	{
		// Token: 0x0603C2C7 RID: 246471 RVA: 0x00F4261C File Offset: 0x00F4081C
		protected override void OnAddEvents()
		{
			Singleton<Net>.Instance.Register<FlagChallengeTaskInfoUpdateNotify>(ENotifyMessageId.FlagChallengeTaskInfoUpdateNotify, new Action<FlagChallengeTaskInfoUpdateNotify, Net.CallbackStatus>(this.OnTaskInfoUpdateNotify));
			Singleton<Net>.Instance.Register<FlagChallengeLevelInfoUpdateNotify>(ENotifyMessageId.FlagChallengeLevelInfoUpdateNotify, new Action<FlagChallengeLevelInfoUpdateNotify, Net.CallbackStatus>(this.OnLevelInfoUpdateNotify));
			Singleton<Net>.Instance.Register<FlagStrongholdInfoUpdateNotify>(ENotifyMessageId.FlagStrongholdInfoUpdateNotify, new Action<FlagStrongholdInfoUpdateNotify, Net.CallbackStatus>(this.OnStrongholdInfoUpdateNotify));
			Singleton<Net>.Instance.Register<FlagChallengePerRoleLevelNotify>(ENotifyMessageId.FlagChallengePerRoleLevelNotify, new Action<FlagChallengePerRoleLevelNotify, Net.CallbackStatus>(this.OnPerRoleLevelNotify));
			Singleton<Net>.Instance.Register<FlagChallengeUnlockTeleporterNotify>(ENotifyMessageId.FlagChallengeUnlockTeleporterNotify, new Action<FlagChallengeUnlockTeleporterNotify, Net.CallbackStatus>(this.UnlockTeleporterNotify));
		}

		// Token: 0x0603C2C8 RID: 246472 RVA: 0x00F426B8 File Offset: 0x00F408B8
		protected override void OnRemoveEvents()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengeTaskInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengeLevelInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagStrongholdInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengePerRoleLevelNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengeUnlockTeleporterNotify);
		}

		// Token: 0x0603C2C9 RID: 246473 RVA: 0x00F42718 File Offset: 0x00F40918
		public void RequestFlagChallengeReward(int activityId, List<int> taskIds)
		{
			FlagChallengeRewardRequest flagChallengeRewardRequest = FlagChallengeRewardRequest.Create();
			flagChallengeRewardRequest.ActivityId = activityId;
			flagChallengeRewardRequest.FlagChallengeTaskIds.AddRange(taskIds);
			Singleton<Net>.Instance.Call<FlagChallengeRewardResponse>(ERequestMessageId.FlagChallengeRewardRequest, flagChallengeRewardRequest, delegate(FlagChallengeRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27205, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603C2CA RID: 246474 RVA: 0x00F42770 File Offset: 0x00F40970
		public void RequestChallenge(int instId, int strongholdId, List<int> roleIdList)
		{
			FlagChallengeCtx flagChallengeCtx = FlagChallengeCtx.Create();
			flagChallengeCtx.FlagStrongholdId = strongholdId;
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.FlagChallengeCtx = flagChallengeCtx;
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instId, roleIdList, 0, 0, null, null).Forget<bool>();
		}

		// Token: 0x0603C2CB RID: 246475 RVA: 0x00F427B0 File Offset: 0x00F409B0
		private void OnTaskInfoUpdateNotify(FlagChallengeTaskInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RepeatedField<ConditionTask> conditionTasks = notify.ConditionTasks;
			ModelBase<FlagChallengeModel>.Instance.UpdateTaskData(conditionTasks);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (ConditionTask conditionTask in conditionTasks)
			{
				FlagChallengeTask? taskConfig = ConfigBase<FlagChallengeConfig>.Instance.GetTaskConfig(conditionTask.Id);
				if (taskConfig != null)
				{
					hashSet.Add(taskConfig.Value.ActivityId);
				}
			}
			foreach (int p in hashSet)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, p);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeTaskUpdate, p);
			}
		}

		// Token: 0x0603C2CC RID: 246476 RVA: 0x00F42898 File Offset: 0x00F40A98
		private void OnLevelInfoUpdateNotify(FlagChallengeLevelInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<FlagChallengeModel>.Instance.UpdateLevelData(notify.FlagChallengeLevelInfo);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnFlagChallengeUpdateLevelData);
		}

		// Token: 0x0603C2CD RID: 246477 RVA: 0x00F428BC File Offset: 0x00F40ABC
		private void OnStrongholdInfoUpdateNotify(FlagStrongholdInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			FlagChallengeModel instance = ModelBase<FlagChallengeModel>.Instance;
			List<int> list = new List<int>();
			foreach (FlagStrongholdInfo flagStrongholdInfo in notify.FlagStrongholdInfo)
			{
				FlagChallengeStrongholdData strongholdData = instance.GetStrongholdData(flagStrongholdInfo.Id);
				if (strongholdData != null && !strongholdData.IsPass && flagStrongholdInfo.IsPass)
				{
					list.Add(strongholdData.Id);
				}
			}
			instance.UpdateStrongholdData(notify.FlagStrongholdInfo);
			foreach (int num in list)
			{
				int strongholdActivityId = FlagChallengeUtils.GetStrongholdActivityId(num);
				FlagChallengeData flagChallengeData = instance.GetFlagChallengeData(strongholdActivityId);
				FlagChallengeStrongholdData strongholdData2 = flagChallengeData.GetStrongholdData(num);
				if (!flagChallengeData.IsAreaAllBossStrongholdPass(strongholdData2.StrongholdConfig.AreaId) || strongholdData2.IsBossStronghold())
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeStrongholdOccupied, num);
				}
			}
		}

		// Token: 0x0603C2CE RID: 246478 RVA: 0x00F429CC File Offset: 0x00F40BCC
		private void OnPerRoleLevelNotify(FlagChallengePerRoleLevelNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			FlagChallengeRoleLevelInfo flagChallengeRoleLevelInfo = notify.FlagChallengeRoleLevelInfo;
			if (flagChallengeRoleLevelInfo == null)
			{
				return;
			}
			ModelBase<FlagChallengeModel>.Instance.UpdateRoleLevelData(notify.ActivityId, flagChallengeRoleLevelInfo);
			Singleton<EventSystem>.Instance.Emit<int, int, int>(EEventName.OnFlagChallengeFixedRoleLevelUpdate, notify.ActivityId, flagChallengeRoleLevelInfo.PerLevel, flagChallengeRoleLevelInfo.PerExp);
		}

		// Token: 0x0603C2CF RID: 246479 RVA: 0x00F42A18 File Offset: 0x00F40C18
		private void UnlockTeleporterNotify(FlagChallengeUnlockTeleporterNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RepeatedField<int> teleporterId = notify.TeleporterId;
			ModelBase<FlagChallengeModel>.Instance.UpdateTeleportData(teleporterId);
		}

		// Token: 0x0603C2D0 RID: 246480 RVA: 0x00F42A38 File Offset: 0x00F40C38
		public void OpenFlagChallengeMainView(int activityId, int? levelId = null)
		{
			ActivityFlagChallengeData param = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityFlagChallengeData;
			if (levelId != null)
			{
				FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId);
				if (flagChallengeData != null)
				{
					flagChallengeData.SetMainViewSelectLevelId(new int?(levelId.Value));
				}
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeMainView, param, null);
		}

		// Token: 0x0603C2D1 RID: 246481 RVA: 0x00F42A92 File Offset: 0x00F40C92
		public void OpenFlagChallengeTaskView(int activityId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeRewardView, activityId, null);
		}

		// Token: 0x0603C2D2 RID: 246482 RVA: 0x00F42AAC File Offset: 0x00F40CAC
		public void OpenFlagChallengeSelectRoleView(int activityId, int levelId, int strongholdId)
		{
			FlagChallengeSelectRoleViewParams param = new FlagChallengeSelectRoleViewParams
			{
				ActivityId = activityId,
				LevelId = levelId,
				StrongholdId = strongholdId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeSelectRoleView, param, null);
		}

		// Token: 0x0603C2D3 RID: 246483 RVA: 0x00F42AE8 File Offset: 0x00F40CE8
		public void OpenFlagChallengeAreaDetailView(int activityId, int levelId, int areaId, int? strongholdId = null)
		{
			FlagChallengeAreaDetailViewParams param = new FlagChallengeAreaDetailViewParams
			{
				ActivityId = activityId,
				LevelId = levelId,
				AreaId = areaId,
				StrongholdId = strongholdId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeAreaDetailView, param, null);
		}

		// Token: 0x0603C2D4 RID: 246484 RVA: 0x00F42B2C File Offset: 0x00F40D2C
		public void OpenFlagChallengeBuffView(int activityId, int? selectBuffId = null)
		{
			FlagChallengeBuffViewParams param = new FlagChallengeBuffViewParams
			{
				ActivityId = activityId,
				BuffId = selectBuffId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeBuffView, param, null);
		}

		// Token: 0x0603C2D5 RID: 246485 RVA: 0x00F42B60 File Offset: 0x00F40D60
		public void OpenBuffActiveTipsView(int activityId)
		{
			FlagChallengeBuffActiveTipsParams param = new FlagChallengeBuffActiveTipsParams
			{
				ActivityId = activityId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeBuffActiveTips, param, null);
		}
	}
}
