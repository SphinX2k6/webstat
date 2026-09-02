using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x02006641 RID: 26177
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class NewbieMainController : ActivityControllerBase<NewbieMainController>
	{
		// Token: 0x06041612 RID: 267794 RVA: 0x010C5798 File Offset: 0x010C3998
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<NewbieMainTaskUpdateNotify>(ENotifyMessageId.NewbieMainTaskUpdateNotify, new Action<NewbieMainTaskUpdateNotify, Net.CallbackStatus>(this.OnNewbieMainTaskUpdate));
		}

		// Token: 0x06041613 RID: 267795 RVA: 0x010C57B6 File Offset: 0x010C39B6
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewbieMainTaskUpdateNotify);
		}

		// Token: 0x06041614 RID: 267796 RVA: 0x010C57C8 File Offset: 0x010C39C8
		private void OnNewbieMainTaskUpdate(NewbieMainTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			NewbieMainData newbieMainData = ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as NewbieMainData;
			if (newbieMainData == null)
			{
				return;
			}
			if (notify.NewbieMainTabs != null)
			{
				newbieMainData.UpdateTabs(notify.NewbieMainTabs);
			}
			newbieMainData.UpdateProgressScore(notify.ProgressScore);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, newbieMainData.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnNewbieMainTaskUpdate);
		}

		// Token: 0x06041615 RID: 267797 RVA: 0x010C5838 File Offset: 0x010C3A38
		public static void RequestFetchScoreRewardAsync(int activityId, List<int> rewardIds, Action<bool> callback)
		{
			NewbieFetchScoreRewardRequest newbieFetchScoreRewardRequest = NewbieFetchScoreRewardRequest.Create();
			newbieFetchScoreRewardRequest.ActivityId = activityId;
			newbieFetchScoreRewardRequest.ScoreRewardIds.AddRange(rewardIds);
			Singleton<Net>.Instance.Call<NewbieFetchScoreRewardResponse>(ERequestMessageId.NewbieFetchScoreRewardRequest, newbieFetchScoreRewardRequest, delegate(NewbieFetchScoreRewardResponse response, Net.CallbackStatus _)
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
				else if (response.Code != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 27907, null, true, true);
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
					NewbieMainData newbieMainData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as NewbieMainData;
					if (newbieMainData != null)
					{
						newbieMainData.AddTakenScoreRewardIds(rewardIds);
					}
					Action<bool> callback4 = callback;
					if (callback4 == null)
					{
						return;
					}
					callback4(true);
					return;
				}
			}, 0);
		}

		// Token: 0x06041616 RID: 267798 RVA: 0x010C58A0 File Offset: 0x010C3AA0
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06041617 RID: 267799 RVA: 0x010C58A2 File Offset: 0x010C3AA2
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_NewcomerMainSignin";
		}

		// Token: 0x06041618 RID: 267800 RVA: 0x010C58A9 File Offset: 0x010C3AA9
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new NewbieMainSubView();
		}

		// Token: 0x06041619 RID: 267801 RVA: 0x010C58B0 File Offset: 0x010C3AB0
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new NewbieMainData();
		}

		// Token: 0x0604161A RID: 267802 RVA: 0x010C58B7 File Offset: 0x010C3AB7
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}
	}
}
