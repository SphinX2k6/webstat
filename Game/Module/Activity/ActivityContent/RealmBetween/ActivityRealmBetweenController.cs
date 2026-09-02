using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006525 RID: 25893
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityRealmBetweenController : ActivityControllerBase<ActivityRealmBetweenController>
	{
		// Token: 0x06040C17 RID: 265239 RVA: 0x0109ADE0 File Offset: 0x01098FE0
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06040C18 RID: 265240 RVA: 0x0109ADE2 File Offset: 0x01098FE2
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RealmBetweenInfoUpdateNotify>(ENotifyMessageId.RealmBetweenInfoUpdateNotify, new Action<RealmBetweenInfoUpdateNotify, Net.CallbackStatus>(this.OnRealmBetweenInfoUpdateNotify));
		}

		// Token: 0x06040C19 RID: 265241 RVA: 0x0109AE00 File Offset: 0x01099000
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RealmBetweenInfoUpdateNotify);
		}

		// Token: 0x06040C1A RID: 265242 RVA: 0x0109AE12 File Offset: 0x01099012
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06040C1B RID: 265243 RVA: 0x0109AE30 File Offset: 0x01099030
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06040C1C RID: 265244 RVA: 0x0109AE4E File Offset: 0x0109904E
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_MapThemeHall35";
		}

		// Token: 0x06040C1D RID: 265245 RVA: 0x0109AE58 File Offset: 0x01099058
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			ActivityRealmBetweenData realmBetweenData = this.GetRealmBetweenData();
			if (realmBetweenData == null)
			{
				return;
			}
			if (realmBetweenData.GetActivityConfig().ExpItemId != configId)
			{
				return;
			}
			if (realmBetweenData.CanTravelLevelUp())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, realmBetweenData.Id);
			}
			this.TryOpenLevelTipsView(realmBetweenData);
		}

		// Token: 0x06040C1E RID: 265246 RVA: 0x0109AEA7 File Offset: 0x010990A7
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewRealmBetween();
		}

		// Token: 0x06040C1F RID: 265247 RVA: 0x0109AEAE File Offset: 0x010990AE
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new ActivityRealmBetweenData();
		}

		// Token: 0x06040C20 RID: 265248 RVA: 0x0109AEB5 File Offset: 0x010990B5
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06040C21 RID: 265249 RVA: 0x0109AEB8 File Offset: 0x010990B8
		[NullableContext(2)]
		public ActivityRealmBetweenData GetRealmBetweenData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.RealmBetween);
			ActivityRealmBetweenData result = null;
			if (currentActivitiesByType != null && currentActivitiesByType.Count > 0)
			{
				result = (currentActivitiesByType[0] as ActivityRealmBetweenData);
			}
			return result;
		}

		// Token: 0x06040C22 RID: 265250 RVA: 0x0109AEF0 File Offset: 0x010990F0
		private void OnRealmBetweenInfoUpdateNotify(RealmBetweenInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityRealmBetweenData realmBetweenData = this.GetRealmBetweenData();
			if (realmBetweenData == null)
			{
				return;
			}
			if (notify.ActivityTask != null)
			{
				realmBetweenData.RefreshTravelTaskData(notify.ActivityTask);
			}
			if (notify.MotorcycleLevel != null)
			{
				realmBetweenData.RefreshMotorChallengePlayData(notify.MotorcycleLevel);
			}
			if (notify.HasUnLockArea)
			{
				realmBetweenData.OnNewAreaUnlocked(notify.UnLockArea);
				Singleton<EventSystem>.Instance.Emit(EEventName.RealmBetweenTaskRefresh);
			}
			if (notify.HasUnLockMonsterId)
			{
				realmBetweenData.UnlockPhantom(notify.UnLockMonsterId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, realmBetweenData.Id);
		}

		// Token: 0x06040C23 RID: 265251 RVA: 0x0109AF80 File Offset: 0x01099180
		[NullableContext(2)]
		public void RequestRealmBetweenLevelUp(Action<bool> callback = null)
		{
			RealmBetweenLevelUpRequest message = RealmBetweenLevelUpRequest.Create();
			Singleton<Net>.Instance.Call<RealmBetweenLevelUpResponse>(ERequestMessageId.RealmBetweenLevelUpRequest, message, delegate(RealmBetweenLevelUpResponse response, Net.CallbackStatus _)
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
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15045, null, true, true);
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
					ActivityRealmBetweenData realmBetweenData = this.GetRealmBetweenData();
					if (realmBetweenData != null)
					{
						realmBetweenData.TravelLevel++;
						Action<bool> callback4 = callback;
						if (callback4 != null)
						{
							callback4(true);
						}
						realmBetweenData.RefreshActivityRedDotState();
						this.TryOpenLevelTipsView(realmBetweenData);
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

		// Token: 0x06040C24 RID: 265252 RVA: 0x0109AFC4 File Offset: 0x010991C4
		public void RequestMultiRealmBetweenTaskReward(int[] ids)
		{
			if (ids == null || ids.Length == 0)
			{
				return;
			}
			RealmBetweenTaskRewardRequest realmBetweenTaskRewardRequest = RealmBetweenTaskRewardRequest.Create();
			realmBetweenTaskRewardRequest.TaskIds.AddRange(ids);
			Singleton<Net>.Instance.Call<RealmBetweenTaskRewardResponse>(ERequestMessageId.RealmBetweenTaskRewardRequest, realmBetweenTaskRewardRequest, delegate(RealmBetweenTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22605, null, true, true);
					return;
				}
				ActivityRealmBetweenData realmBetweenData = this.GetRealmBetweenData();
				if (realmBetweenData == null)
				{
					return;
				}
				foreach (int travelTaskDataDone in ids)
				{
					realmBetweenData.SetTravelTaskDataDone(travelTaskDataDone);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, realmBetweenData.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.RealmBetweenTaskRefresh);
			}, 0);
		}

		// Token: 0x06040C25 RID: 265253 RVA: 0x0109B02C File Offset: 0x0109922C
		public void RequestTakeTaskFinalReward()
		{
			RealmBetweenFullRewardRequest message = RealmBetweenFullRewardRequest.Create();
			Singleton<Net>.Instance.Call<RealmBetweenFullRewardResponse>(ERequestMessageId.RealmBetweenFullRewardRequest, message, delegate(RealmBetweenFullRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25638, null, true, true);
					return;
				}
				ActivityRealmBetweenData realmBetweenData = this.GetRealmBetweenData();
				if (realmBetweenData == null)
				{
					return;
				}
				realmBetweenData.TaskFinalRewardData.IsReceived = true;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, realmBetweenData.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.RealmBetweenTaskRefresh);
			}, 0);
		}

		// Token: 0x06040C26 RID: 265254 RVA: 0x0109B05C File Offset: 0x0109925C
		public void RequestMultiMotorChallengeReward(int[] ids)
		{
			if (ids == null || ids.Length == 0)
			{
				return;
			}
			RealmBetweenMotorRewardRequest realmBetweenMotorRewardRequest = RealmBetweenMotorRewardRequest.Create();
			realmBetweenMotorRewardRequest.TaskIds.AddRange(ids);
			Singleton<Net>.Instance.Call<RealmBetweenMotorRewardResponse>(ERequestMessageId.RealmBetweenMotorRewardRequest, realmBetweenMotorRewardRequest, delegate(RealmBetweenMotorRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19410, null, true, true);
					return;
				}
				ActivityRealmBetweenData realmBetweenData = this.GetRealmBetweenData();
				if (realmBetweenData == null)
				{
					return;
				}
				foreach (int motorChallengeRewardDone in ids)
				{
					realmBetweenData.SetMotorChallengeRewardDone(motorChallengeRewardDone);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, realmBetweenData.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.RealmBetweenMotorRefresh);
			}, 0);
		}

		// Token: 0x06040C27 RID: 265255 RVA: 0x0109B0C3 File Offset: 0x010992C3
		private void TryOpenLevelTipsView(ActivityRealmBetweenData data)
		{
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RealmBetweenLevelTipsView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RealmBetweenLevelTipsView, data, null);
			}
		}

		// Token: 0x06040C28 RID: 265256 RVA: 0x0109B0E7 File Offset: 0x010992E7
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipRealmBetweenView, null, null);
		}
	}
}
