using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006483 RID: 25731
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityRoadBookController : ActivityControllerBase<ActivityRoadBookController>
	{
		// Token: 0x060408C2 RID: 264386 RVA: 0x0108B9F8 File Offset: 0x01089BF8
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x060408C3 RID: 264387 RVA: 0x0108B9FA File Offset: 0x01089BFA
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RoadBookInfoUpdateNotify>(ENotifyMessageId.RoadBookInfoUpdateNotify, new Action<RoadBookInfoUpdateNotify, Net.CallbackStatus>(this.OnRoadBookInfoUpdateNotify));
		}

		// Token: 0x060408C4 RID: 264388 RVA: 0x0108BA18 File Offset: 0x01089C18
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoadBookInfoUpdateNotify);
		}

		// Token: 0x060408C5 RID: 264389 RVA: 0x0108BA2A File Offset: 0x01089C2A
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x060408C6 RID: 264390 RVA: 0x0108BA48 File Offset: 0x01089C48
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x060408C7 RID: 264391 RVA: 0x0108BA66 File Offset: 0x01089C66
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_MapThemeHall30";
		}

		// Token: 0x060408C8 RID: 264392 RVA: 0x0108BA70 File Offset: 0x01089C70
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			ActivityRoadBookData roadBookData = this.GetRoadBookData();
			if (roadBookData == null)
			{
				return;
			}
			if (roadBookData.GetActivityConfig().ExpItemId != configId)
			{
				return;
			}
			if (roadBookData.CanTravelLevelUp())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, roadBookData.Id);
			}
			this.TryOpenLevelTipsView(roadBookData);
		}

		// Token: 0x060408C9 RID: 264393 RVA: 0x0108BABF File Offset: 0x01089CBF
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewRoadBook();
		}

		// Token: 0x060408CA RID: 264394 RVA: 0x0108BAC6 File Offset: 0x01089CC6
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new ActivityRoadBookData();
		}

		// Token: 0x060408CB RID: 264395 RVA: 0x0108BACD File Offset: 0x01089CCD
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x060408CC RID: 264396 RVA: 0x0108BAD0 File Offset: 0x01089CD0
		[NullableContext(2)]
		public ActivityRoadBookData GetRoadBookData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.RoadBookActivity);
			ActivityRoadBookData result = null;
			if (currentActivitiesByType != null && currentActivitiesByType.Count > 0)
			{
				result = (currentActivitiesByType[0] as ActivityRoadBookData);
			}
			return result;
		}

		// Token: 0x060408CD RID: 264397 RVA: 0x0108BB08 File Offset: 0x01089D08
		private void OnRoadBookInfoUpdateNotify(RoadBookInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityRoadBookData roadBookData = this.GetRoadBookData();
			if (roadBookData == null)
			{
				return;
			}
			if (notify.ActivityTask != null)
			{
				roadBookData.RefreshTravelTaskData(notify.ActivityTask);
			}
			if (notify.MotorcycleLevel != null)
			{
				roadBookData.RefreshMotorChallengePlayData(notify.MotorcycleLevel);
			}
			if (notify.HasUnLockArea)
			{
				roadBookData.UnlockAreaData(notify.UnLockArea);
			}
			if (notify.HasUnLockMonsterId)
			{
				roadBookData.UnlockPhantom(notify.UnLockMonsterId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, roadBookData.Id);
		}

		// Token: 0x060408CE RID: 264398 RVA: 0x0108BB88 File Offset: 0x01089D88
		[NullableContext(2)]
		public void RequestRoadBookLevelUp(Action<bool> callback = null)
		{
			RoadBookLevelUpRequest message = RoadBookLevelUpRequest.Create();
			Singleton<Net>.Instance.Call<RoadBookLevelUpResponse>(ERequestMessageId.RoadBookLevelUpRequest, message, delegate(RoadBookLevelUpResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23624, null, true, true);
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(false);
					return;
				}
				else
				{
					ActivityRoadBookData roadBookData = this.GetRoadBookData();
					if (roadBookData != null)
					{
						roadBookData.TravelLevel++;
						Action<bool> callback4 = callback;
						if (callback4 != null)
						{
							callback4(true);
						}
						roadBookData.RefreshActivityRedDotState();
						this.TryOpenLevelTipsView(roadBookData);
						return;
					}
					Action<bool> callback5 = callback;
					if (callback5 == null)
					{
						return;
					}
					callback5(false);
					return;
				}
			}, 0);
		}

		// Token: 0x060408CF RID: 264399 RVA: 0x0108BBCC File Offset: 0x01089DCC
		public void RequestMultiRoadBookTaskReward(int[] ids)
		{
			if (ids == null || ids.Length == 0)
			{
				return;
			}
			RoadBookTaskRewardRequest roadBookTaskRewardRequest = RoadBookTaskRewardRequest.Create();
			roadBookTaskRewardRequest.TaskIds.AddRange(ids);
			Singleton<Net>.Instance.Call<RoadBookTaskRewardResponse>(ERequestMessageId.RoadBookTaskRewardRequest, roadBookTaskRewardRequest, delegate(RoadBookTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17619, null, true, true);
					return;
				}
				ActivityRoadBookData roadBookData = this.GetRoadBookData();
				if (roadBookData == null)
				{
					return;
				}
				foreach (int travelTaskDataDone in ids)
				{
					roadBookData.SetTravelTaskDataDone(travelTaskDataDone);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, roadBookData.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.RoadBookTaskRefresh);
			}, 0);
		}

		// Token: 0x060408D0 RID: 264400 RVA: 0x0108BC34 File Offset: 0x01089E34
		public void RequestTakeTaskFinalReward()
		{
			RoadBookFullRewardRequest message = RoadBookFullRewardRequest.Create();
			Singleton<Net>.Instance.Call<RoadBookFullRewardResponse>(ERequestMessageId.RoadBookFullRewardRequest, message, delegate(RoadBookFullRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21604, null, true, true);
					return;
				}
				ActivityRoadBookData roadBookData = this.GetRoadBookData();
				if (roadBookData == null)
				{
					return;
				}
				roadBookData.TaskFinalRewardData.IsReceived = true;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, roadBookData.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.RoadBookTaskRefresh);
			}, 0);
		}

		// Token: 0x060408D1 RID: 264401 RVA: 0x0108BC64 File Offset: 0x01089E64
		public void RequestMultiTakeMotorChallengeReward(int[] rewardIds)
		{
			if (rewardIds == null || rewardIds.Length == 0)
			{
				return;
			}
			RoadBookMotorRewardRequest roadBookMotorRewardRequest = RoadBookMotorRewardRequest.Create();
			roadBookMotorRewardRequest.TaskIds.AddRange(rewardIds);
			Singleton<Net>.Instance.Call<RoadBookMotorRewardResponse>(ERequestMessageId.RoadBookMotorRewardRequest, roadBookMotorRewardRequest, delegate(RoadBookMotorRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28569, null, true, true);
					return;
				}
				ActivityRoadBookData roadBookData = this.GetRoadBookData();
				if (roadBookData == null)
				{
					return;
				}
				foreach (int motorChallengeRewardDone in rewardIds)
				{
					roadBookData.SetMotorChallengeRewardDone(motorChallengeRewardDone);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, roadBookData.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.RoadBookMotorRefresh);
			}, 0);
		}

		// Token: 0x060408D2 RID: 264402 RVA: 0x0108BCCB File Offset: 0x01089ECB
		private void TryOpenLevelTipsView(ActivityRoadBookData data)
		{
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RoadBookLevelTipsView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoadBookLevelTipsView, data, null);
			}
		}

		// Token: 0x060408D3 RID: 264403 RVA: 0x0108BCEF File Offset: 0x01089EEF
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipRoadBookView, null, null);
		}
	}
}
