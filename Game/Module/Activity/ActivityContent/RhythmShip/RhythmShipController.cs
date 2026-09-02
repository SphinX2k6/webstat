using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip
{
	// Token: 0x020064C5 RID: 25797
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RhythmShipController : ActivityControllerBase<RhythmShipController>
	{
		// Token: 0x06040A33 RID: 264755 RVA: 0x010918B2 File Offset: 0x0108FAB2
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06040A34 RID: 264756 RVA: 0x010918B4 File Offset: 0x0108FAB4
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_RhythmShipActivityMain";
		}

		// Token: 0x06040A35 RID: 264757 RVA: 0x010918BB File Offset: 0x0108FABB
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new RhythmShipSubView();
		}

		// Token: 0x06040A36 RID: 264758 RVA: 0x010918C2 File Offset: 0x0108FAC2
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			ModelBase<RhythmShipModel>.Instance.ActivityId = data.Id;
			return new RhythmShipData();
		}

		// Token: 0x06040A37 RID: 264759 RVA: 0x010918D9 File Offset: 0x0108FAD9
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06040A38 RID: 264760 RVA: 0x010918DC File Offset: 0x0108FADC
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x06040A39 RID: 264761 RVA: 0x010918FA File Offset: 0x0108FAFA
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x06040A3A RID: 264762 RVA: 0x01091918 File Offset: 0x0108FB18
		private void OnWorldDone()
		{
			ModelBase<RhythmShipModel>.Instance.InitLocalCalibrationValue();
		}

		// Token: 0x06040A3B RID: 264763 RVA: 0x01091924 File Offset: 0x0108FB24
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RhythmRoleUpdateNotify>(ENotifyMessageId.RhythmRoleUpdateNotify, new Action<RhythmRoleUpdateNotify, Net.CallbackStatus>(this.RhythmRoleUpdateNotify));
			Singleton<Net>.Instance.Register<RhythmTaskUpdateNotify>(ENotifyMessageId.RhythmTaskUpdateNotify, new Action<RhythmTaskUpdateNotify, Net.CallbackStatus>(this.RhythmTaskUpdateNotify));
			Singleton<Net>.Instance.Register<RhythmSubLevelUpdateNotify>(ENotifyMessageId.RhythmSubLevelUpdateNotify, new Action<RhythmSubLevelUpdateNotify, Net.CallbackStatus>(this.RhythmSubLevelUpdateNotify));
			Singleton<Net>.Instance.Register<RhythmShipStartNotify>(ENotifyMessageId.RhythmShipStartNotify, new Action<RhythmShipStartNotify, Net.CallbackStatus>(this.RhythmShipStartNotify));
		}

		// Token: 0x06040A3C RID: 264764 RVA: 0x010919A4 File Offset: 0x0108FBA4
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RhythmRoleUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RhythmTaskUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RhythmSubLevelUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RhythmShipStartNotify);
		}

		// Token: 0x06040A3D RID: 264765 RVA: 0x010919F4 File Offset: 0x0108FBF4
		[NullableContext(2)]
		public void RhythmSetRedDotRequest(List<int> planetId = null, List<int> subLevelId = null, List<int> roleId = null)
		{
			int activityId = 0;
			if (subLevelId != null)
			{
				activityId = ModelBase<RhythmShipModel>.Instance.GetSubLevelActivityId(subLevelId[0]);
			}
			else if (planetId != null)
			{
				activityId = ModelBase<RhythmShipModel>.Instance.GetPlanetActivityId(planetId[0]);
			}
			else if (roleId != null)
			{
				RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
				activityId = ((activityData != null) ? activityData.Id : 0);
			}
			RhythmSetRedDotRequest rhythmSetRedDotRequest = Aki.Protocol.RhythmSetRedDotRequest.Create();
			rhythmSetRedDotRequest.ActivityId = activityId;
			rhythmSetRedDotRequest.RedDot = RhythmRedDotPb.Create();
			rhythmSetRedDotRequest.RedDot.ReadPlanet.AddRange(planetId ?? new List<int>());
			rhythmSetRedDotRequest.RedDot.ReadSubLevel.AddRange(subLevelId ?? new List<int>());
			rhythmSetRedDotRequest.RedDot.ReadRole.AddRange(roleId ?? new List<int>());
			Singleton<Net>.Instance.Call<RhythmSetRedDotResponse>(ERequestMessageId.RhythmSetRedDotRequest, rhythmSetRedDotRequest, delegate(RhythmSetRedDotResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
				{
					return;
				}
				RhythmShipData activityData2 = ModelBase<RhythmShipModel>.Instance.ActivityData;
				if (activityData2 != null)
				{
					if (planetId != null)
					{
						RhythmRedDotPb redDotInfo = activityData2.RedDotInfo;
						if (redDotInfo != null)
						{
							redDotInfo.ReadPlanet.AddRange(planetId);
						}
					}
					if (subLevelId != null)
					{
						RhythmRedDotPb redDotInfo2 = activityData2.RedDotInfo;
						if (redDotInfo2 != null)
						{
							redDotInfo2.ReadSubLevel.AddRange(subLevelId);
						}
					}
					if (roleId != null)
					{
						RhythmRedDotPb redDotInfo3 = activityData2.RedDotInfo;
						if (redDotInfo3 != null)
						{
							redDotInfo3.ReadRole.AddRange(roleId);
						}
					}
					Singleton<EventSystem>.Instance.Emit<List<int>, List<int>, List<int>>(EEventName.OnRhythmShipRedDotRefresh, planetId, subLevelId, roleId);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<RhythmShipModel>.Instance.ActivityId);
				}
			}, 0);
		}

		// Token: 0x06040A3E RID: 264766 RVA: 0x01091B14 File Offset: 0x0108FD14
		public void RhythmChangePartnerRoleRequest(int roleId)
		{
			RhythmChangePartnerRoleRequest rhythmChangePartnerRoleRequest = Aki.Protocol.RhythmChangePartnerRoleRequest.Create();
			rhythmChangePartnerRoleRequest.RhythmRoleId = roleId;
			Singleton<Net>.Instance.Call<RhythmChangePartnerRoleResponse>(ERequestMessageId.RhythmChangePartnerRoleRequest, rhythmChangePartnerRoleRequest, delegate(RhythmChangePartnerRoleResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
				{
					return;
				}
				RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
				if (activityData != null)
				{
					activityData.CurrentRole = roleId;
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRhythmShipSelectRoleRefresh);
			}, 0);
		}

		// Token: 0x06040A3F RID: 264767 RVA: 0x01091B60 File Offset: 0x0108FD60
		public void RhythmTaskOneKeyRewardRequest(int taskId)
		{
			RhythmTaskOneKeyRewardRequest rhythmTaskOneKeyRewardRequest = Aki.Protocol.RhythmTaskOneKeyRewardRequest.Create();
			RhythmTask? rhythmShipTaskById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskById(taskId);
			rhythmTaskOneKeyRewardRequest.TaskId.AddRange(ModelBase<RhythmShipModel>.Instance.GetAllCanGetRewardTaskByType((RhythmTaskTypePb)rhythmShipTaskById.Value.TaskType, rhythmShipTaskById.Value.TaskTab));
			rhythmTaskOneKeyRewardRequest.TaskType = (RhythmTaskTypePb)rhythmShipTaskById.Value.TaskType;
			Singleton<Net>.Instance.Call<RhythmTaskOneKeyRewardResponse>(ERequestMessageId.RhythmTaskOneKeyRewardRequest, rhythmTaskOneKeyRewardRequest, delegate(RhythmTaskOneKeyRewardResponse response, Net.CallbackStatus _)
			{
			}, 0);
		}

		// Token: 0x06040A40 RID: 264768 RVA: 0x01091BF8 File Offset: 0x0108FDF8
		public UniTask RhythmRankListRequest()
		{
			RhythmShipController.<RhythmRankListRequest>d__15 <RhythmRankListRequest>d__;
			<RhythmRankListRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RhythmRankListRequest>d__.<>4__this = this;
			<RhythmRankListRequest>d__.<>1__state = -1;
			<RhythmRankListRequest>d__.<>t__builder.Start<RhythmShipController.<RhythmRankListRequest>d__15>(ref <RhythmRankListRequest>d__);
			return <RhythmRankListRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06040A41 RID: 264769 RVA: 0x01091C3C File Offset: 0x0108FE3C
		public UniTask RhythmRankListSelfDataRequest()
		{
			RhythmShipController.<RhythmRankListSelfDataRequest>d__16 <RhythmRankListSelfDataRequest>d__;
			<RhythmRankListSelfDataRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RhythmRankListSelfDataRequest>d__.<>1__state = -1;
			<RhythmRankListSelfDataRequest>d__.<>t__builder.Start<RhythmShipController.<RhythmRankListSelfDataRequest>d__16>(ref <RhythmRankListSelfDataRequest>d__);
			return <RhythmRankListSelfDataRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06040A42 RID: 264770 RVA: 0x01091C78 File Offset: 0x0108FE78
		public void RhythmSettleRequest(int subLevelId, RhythmSettleReasonPb reason, RhythmResultPayload payload, Dictionary<ERhythmShipSettlementType, int> settlementItemMap, bool isDisableRecordUpLoad, bool isQuit = false)
		{
			int score = payload.Score;
			RhythmShipRank rank = payload.Rank;
			if (isDisableRecordUpLoad)
			{
				payload.Score = 0;
				payload.Rank = RhythmShipRank.B;
				payload.Accuracy = 0;
			}
			RhythmSettleRequest rhythmSettleRequest = Aki.Protocol.RhythmSettleRequest.Create();
			rhythmSettleRequest.SubLevelId = subLevelId;
			rhythmSettleRequest.SettleReason = reason;
			rhythmSettleRequest.Payload = payload;
			Singleton<Net>.Instance.Call<RhythmSettleResponse>(ERequestMessageId.RhythmSettleRequest, rhythmSettleRequest, delegate(RhythmSettleResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.ErrCode > Aki.Protocol.ErrorCode.Success)
				{
					return;
				}
				if (isQuit)
				{
					return;
				}
				payload.Score = score;
				payload.Rank = rank;
				RhythmShipSettlementViewData param = new RhythmShipSettlementViewData
				{
					SubLevelId = subLevelId,
					Reason = reason,
					Payload = payload,
					SettlementItemMap = settlementItemMap
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipSettlementView, param, null);
			}, 0);
		}

		// Token: 0x06040A43 RID: 264771 RVA: 0x01091D44 File Offset: 0x0108FF44
		public void StartRequest(int subLevelId, int levelId)
		{
			if (this.IsStartRequesting)
			{
				return;
			}
			this.IsStartRequesting = true;
			RhythmCtx rhythmCtx = RhythmCtx.Create();
			rhythmCtx.SubLevelId = subLevelId;
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.RhythmCtx = rhythmCtx;
			int instId = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(subLevelId).Value.InstId;
			this.StartRequestAsync(instId, subLevelId, levelId).Forget();
		}

		// Token: 0x06040A44 RID: 264772 RVA: 0x01091DA8 File Offset: 0x0108FFA8
		private UniTask StartRequestAsync(int instanceId, int subLevelId, int levelId)
		{
			RhythmShipController.<StartRequestAsync>d__19 <StartRequestAsync>d__;
			<StartRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartRequestAsync>d__.<>4__this = this;
			<StartRequestAsync>d__.instanceId = instanceId;
			<StartRequestAsync>d__.subLevelId = subLevelId;
			<StartRequestAsync>d__.levelId = levelId;
			<StartRequestAsync>d__.<>1__state = -1;
			<StartRequestAsync>d__.<>t__builder.Start<RhythmShipController.<StartRequestAsync>d__19>(ref <StartRequestAsync>d__);
			return <StartRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040A45 RID: 264773 RVA: 0x01091E04 File Offset: 0x01090004
		public UniTask RhythmMainLineInfoRequest()
		{
			RhythmShipController.<RhythmMainLineInfoRequest>d__20 <RhythmMainLineInfoRequest>d__;
			<RhythmMainLineInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RhythmMainLineInfoRequest>d__.<>1__state = -1;
			<RhythmMainLineInfoRequest>d__.<>t__builder.Start<RhythmShipController.<RhythmMainLineInfoRequest>d__20>(ref <RhythmMainLineInfoRequest>d__);
			return <RhythmMainLineInfoRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06040A46 RID: 264774 RVA: 0x01091E40 File Offset: 0x01090040
		private void RhythmRoleUpdateNotify(RhythmRoleUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData != null)
			{
				activityData.RoleUnlockList.AddRange(message.UnlockedRole);
			}
		}

		// Token: 0x06040A47 RID: 264775 RVA: 0x01091E6C File Offset: 0x0109006C
		private void RhythmTaskUpdateNotify(RhythmTaskUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			foreach (RhythmTaskPb rhythmTaskPb in message.RhythmTask)
			{
				if (rhythmTaskPb.TaskType == RhythmTaskTypePb.Resident)
				{
					foreach (ConditionTask conditionTask in rhythmTaskPb.Task)
					{
						activityData.TaskInfoMap[conditionTask.Id] = conditionTask;
					}
				}
				if (rhythmTaskPb.TaskType == RhythmTaskTypePb.Limit)
				{
					foreach (ConditionTask conditionTask2 in rhythmTaskPb.Task)
					{
						activityData.LimitTaskInfoMap[conditionTask2.Id] = conditionTask2;
					}
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRhythmShipTaskRefresh);
				foreach (int p in activityData.TaskTabList)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRhythmShipTaskTabRefresh, p);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<RhythmShipModel>.Instance.ActivityId);
			}
		}

		// Token: 0x06040A48 RID: 264776 RVA: 0x01092018 File Offset: 0x01090218
		private void RhythmSubLevelUpdateNotify(RhythmSubLevelUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			foreach (RhythmSubLevelPb rhythmSubLevelPb in message.UpdateSubLevelPb)
			{
				if (ModelBase<RhythmShipModel>.Instance.GetSubLevelActivityId(rhythmSubLevelPb.SubLevelId) != 0)
				{
					RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
					if (activityData != null)
					{
						activityData.SubLevelInfoMap[rhythmSubLevelPb.SubLevelId] = rhythmSubLevelPb;
					}
				}
				else
				{
					ModelBase<RhythmShipModel>.Instance.MainLineSubLevelInfoMap[rhythmSubLevelPb.SubLevelId] = rhythmSubLevelPb;
				}
			}
		}

		// Token: 0x06040A49 RID: 264777 RVA: 0x010920A8 File Offset: 0x010902A8
		private void RhythmShipStartNotify(RhythmShipStartNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<RhythmShipModel>.Instance.RhythmShipLevelRole = message.RhythmRoleId;
		}

		// Token: 0x06040A4A RID: 264778 RVA: 0x010920BC File Offset: 0x010902BC
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			RhythmShipController.<OnOpenSubView>d__25 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<RhythmShipController.<OnOpenSubView>d__25>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x06040A4B RID: 264779 RVA: 0x01092100 File Offset: 0x01090300
		public void PlayLoopAudioEvent(string @event)
		{
			if (StringUtils.IsEmpty(this.LastLoopAudio))
			{
				this.LastLoopAudio = @event;
				Singleton<AudioSystem>.Instance.PostEvent(@event);
				return;
			}
			if (@event != this.LastLoopAudio)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.LastLoopAudio, EAudioActionType.Stop, null);
				this.LastLoopAudio = @event;
				Singleton<AudioSystem>.Instance.PostEvent(@event);
				return;
			}
			this.LastLoopAudio = @event;
			Singleton<AudioSystem>.Instance.ExecuteAction(this.LastLoopAudio, EAudioActionType.Resume, null);
		}

		// Token: 0x06040A4C RID: 264780 RVA: 0x0109218C File Offset: 0x0109038C
		public void StopLoopAudioEvent()
		{
			if (!StringUtils.IsEmpty(this.LastLoopAudio))
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.LastLoopAudio, EAudioActionType.Stop, null);
				this.LastLoopAudio = "";
			}
		}

		// Token: 0x04024329 RID: 148265
		private bool IsStartRequesting;

		// Token: 0x0402432A RID: 148266
		public double NextCanRhythmRankListRequestTime;

		// Token: 0x0402432B RID: 148267
		public string LastLoopAudio = "";
	}
}
