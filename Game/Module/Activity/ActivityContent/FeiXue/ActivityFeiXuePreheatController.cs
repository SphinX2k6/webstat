using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x02006839 RID: 26681
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityFeiXuePreheatController : ActivityControllerBase<ActivityFeiXuePreheatController>
	{
		// Token: 0x06042847 RID: 272455 RVA: 0x01112EE5 File Offset: 0x011110E5
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06042848 RID: 272456 RVA: 0x01112EE7 File Offset: 0x011110E7
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_FeixueMain";
		}

		// Token: 0x06042849 RID: 272457 RVA: 0x01112EEE File Offset: 0x011110EE
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewFeiXuePreheat();
		}

		// Token: 0x0604284A RID: 272458 RVA: 0x01112EF5 File Offset: 0x011110F5
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new ActivityFeiXuePreheatData();
		}

		// Token: 0x0604284B RID: 272459 RVA: 0x01112F08 File Offset: 0x01111108
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0604284C RID: 272460 RVA: 0x01112F0B File Offset: 0x0111110B
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<FeiXuePreheatInfoUpdateNotify>(ENotifyMessageId.FeiXuePreheatInfoUpdateNotify, new Action<FeiXuePreheatInfoUpdateNotify, Net.CallbackStatus>(this.OnFeiXuePreheatInfoUpdateNotify));
		}

		// Token: 0x0604284D RID: 272461 RVA: 0x01112F29 File Offset: 0x01111129
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FeiXuePreheatInfoUpdateNotify);
		}

		// Token: 0x0604284E RID: 272462 RVA: 0x01112F3C File Offset: 0x0111113C
		[NullableContext(2)]
		public ActivityFeiXuePreheatData GetActivityData()
		{
			ActivityFeiXuePreheatData activityFeiXuePreheatData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityFeiXuePreheatData;
			if (activityFeiXuePreheatData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "飞雪预热活动数据更新错误，没有活动数据:";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId:", this.ActivityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return activityFeiXuePreheatData;
		}

		// Token: 0x0604284F RID: 272463 RVA: 0x01112F9C File Offset: 0x0111119C
		protected void OnFeiXuePreheatInfoUpdateNotify(FeiXuePreheatInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityFeiXuePreheatData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			foreach (FeiXuePreheatInfo info in notify.FeiXuePreheatInfos)
			{
				activityData.UpdateFeiXuePreheatInfo(info);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}

		// Token: 0x06042850 RID: 272464 RVA: 0x0111300C File Offset: 0x0111120C
		[NullableContext(2)]
		public void RequestTaskReward(int actId, Action callback = null)
		{
			ActivityFeiXuePreheatData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			FeiXuePreheatInfoRewardRequest feiXuePreheatInfoRewardRequest = FeiXuePreheatInfoRewardRequest.Create();
			feiXuePreheatInfoRewardRequest.ActivityId = actId;
			List<int> claimableTaskIdList = activityData.GetClaimableTaskIdList();
			feiXuePreheatInfoRewardRequest.FeiXuePreheatInfoIds.AddRange(claimableTaskIdList);
			Singleton<Net>.Instance.Call<FeiXuePreheatInfoRewardResponse>(ERequestMessageId.FeiXuePreheatInfoRewardRequest, feiXuePreheatInfoRewardRequest, delegate(FeiXuePreheatInfoRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27679, null, true, true);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}, 0);
		}

		// Token: 0x06042851 RID: 272465 RVA: 0x01113078 File Offset: 0x01111278
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			ActivityFeiXuePreheatController.<OnOpenSubView>d__11 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<ActivityFeiXuePreheatController.<OnOpenSubView>d__11>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x0402505B RID: 151643
		public int ActivityId;
	}
}
