using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006983 RID: 27011
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CoopActivityController : ActivityControllerBase<CoopActivityController>
	{
		// Token: 0x06043062 RID: 274530 RVA: 0x01135E9E File Offset: 0x0113409E
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<CoopRoleInfoUpdateNotify>(ENotifyMessageId.CoopRoleInfoUpdateNotify, new Action<CoopRoleInfoUpdateNotify, Net.CallbackStatus>(this.OnCoopActivityUpdate));
		}

		// Token: 0x06043063 RID: 274531 RVA: 0x01135EBC File Offset: 0x011340BC
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CoopRoleInfoUpdateNotify);
		}

		// Token: 0x06043064 RID: 274532 RVA: 0x01135ED0 File Offset: 0x011340D0
		protected override void OnOpenView(ActivityBaseData data)
		{
			CoopActivityData param = data as CoopActivityData;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopEntranceView, param, null);
		}

		// Token: 0x06043065 RID: 274533 RVA: 0x01135EF5 File Offset: 0x011340F5
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.TryShowCoopUpGrateView));
			Singleton<EventSystem>.Instance.Add(EEventName.ShowFloatTips, new Action(this.TryShowCoopUpGrateView));
		}

		// Token: 0x06043066 RID: 274534 RVA: 0x01135F2F File Offset: 0x0113412F
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.TryShowCoopUpGrateView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ShowFloatTips, new Action(this.TryShowCoopUpGrateView));
		}

		// Token: 0x06043067 RID: 274535 RVA: 0x01135F69 File Offset: 0x01134169
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityCoopMain";
		}

		// Token: 0x06043068 RID: 274536 RVA: 0x01135F70 File Offset: 0x01134170
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new CoopActivityView();
		}

		// Token: 0x06043069 RID: 274537 RVA: 0x01135F77 File Offset: 0x01134177
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new CoopActivityData();
		}

		// Token: 0x0604306A RID: 274538 RVA: 0x01135F7E File Offset: 0x0113417E
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0604306B RID: 274539 RVA: 0x01135F84 File Offset: 0x01134184
		private void OnCoopActivityUpdate(CoopRoleInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			CoopActivityData coopActivityData = ((instance != null) ? instance.GetActivityById(response.ActivityId) : null) as CoopActivityData;
			if (response.CoopRoleInfo != null && ((coopActivityData != null) ? new bool?(coopActivityData.UpdateOneRoleData(response.CoopRoleInfo)) : null).GetValueOrDefault() && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.CoopUpGrateView))
			{
				int coopRoleId = response.CoopRoleInfo.CoopRoleId;
				int roleCurCoopLevel = coopActivityData.GetRoleCurCoopLevel(coopRoleId);
				CoopUpGrateViewParams coopUpGrateViewParams = new CoopUpGrateViewParams
				{
					ActivityData = coopActivityData,
					RoleId = coopRoleId,
					PreLevel = roleCurCoopLevel - 1,
					NextLevel = roleCurCoopLevel,
					IsMaxLevel = coopActivityData.IsRoleCurCoopLevelMax(coopRoleId),
					IsNew = (roleCurCoopLevel == 1)
				};
				if (Singleton<UiModel>.Instance.IsInMainView)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopUpGrateView, coopUpGrateViewParams, null);
				}
				else
				{
					this.CoopUpGrateViewOpenParam = coopUpGrateViewParams;
				}
			}
			if (response.CoopTaskCompleteInfo != null && coopActivityData != null)
			{
				coopActivityData.UpdateOneRoleLevelSubConditionData(response.CoopTaskCompleteInfo);
			}
			if (response.PreCompleteId != 0 && coopActivityData != null)
			{
				coopActivityData.UpdatePreCompleteLevelIdSet(new List<int>
				{
					response.PreCompleteId
				});
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnCoopLevelUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, coopActivityData.Id);
		}

		// Token: 0x0604306C RID: 274540 RVA: 0x011360D4 File Offset: 0x011342D4
		public void RequestCoopRoleReward(CoopActivityData data, int roleId)
		{
			CoopRoleRewardRequest coopRoleRewardRequest = CoopRoleRewardRequest.Create();
			coopRoleRewardRequest.CoopId = roleId;
			Singleton<Net>.Instance.Call<CoopRoleRewardResponse>(ERequestMessageId.CoopRoleRewardRequest, coopRoleRewardRequest, delegate(CoopRoleRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22119, null, true, true);
					return;
				}
				data.UpdateCoopRoleReward(roleId);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCoopLevelUpdate);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
			}, 0);
		}

		// Token: 0x0604306D RID: 274541 RVA: 0x01136124 File Offset: 0x01134324
		public void RequestCoopSpReward(CoopActivityData data)
		{
			CoopSpRewardRequest coopSpRewardRequest = CoopSpRewardRequest.Create();
			List<int> rewardIds = new List<int>();
			foreach (CoopSpRewardData coopSpRewardData in data.CoopSpRewardDataList)
			{
				if (coopSpRewardData.State == ECoopSpRewardState.Reward)
				{
					rewardIds.Add(coopSpRewardData.Id);
				}
			}
			coopSpRewardRequest.RewardIds.AddRange(rewardIds);
			Singleton<Net>.Instance.Call<CoopSpRewardResponse>(ERequestMessageId.CoopSpRewardRequest, coopSpRewardRequest, delegate(CoopSpRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22010, null, true, true);
					return;
				}
				data.UpdateCoopSpRewardClaimed(rewardIds);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCoopSpUpdate);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
			}, 0);
		}

		// Token: 0x0604306E RID: 274542 RVA: 0x011361DC File Offset: 0x011343DC
		private void TryShowCoopUpGrateView()
		{
			if (this.CoopUpGrateViewOpenParam != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopUpGrateView, this.CoopUpGrateViewOpenParam, null);
				this.CoopUpGrateViewOpenParam = null;
			}
		}

		// Token: 0x04025538 RID: 152888
		[Nullable(2)]
		private CoopUpGrateViewParams CoopUpGrateViewOpenParam;
	}
}
