using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x020066F7 RID: 26359
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MotorDecalLinkController : ActivityControllerBase<MotorDecalLinkController>
	{
		// Token: 0x06041CB4 RID: 269492 RVA: 0x010E1004 File Offset: 0x010DF204
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<MotorDecalUpdateNotify>(ENotifyMessageId.MotorDecalUpdateNotify, new Action<MotorDecalUpdateNotify, Net.CallbackStatus>(this.OnMotorDecalUpdateNotify));
		}

		// Token: 0x06041CB5 RID: 269493 RVA: 0x010E1022 File Offset: 0x010DF222
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorDecalUpdateNotify);
		}

		// Token: 0x06041CB6 RID: 269494 RVA: 0x010E1034 File Offset: 0x010DF234
		private void OnMotorDecalUpdateNotify(MotorDecalUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ConditionTask task = notify.Task;
			if (task == null)
			{
				return;
			}
			int id = task.Id;
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.MotorDecalActivity);
			if (currentActivitiesByType == null)
			{
				return;
			}
			foreach (ActivityBaseData activityBaseData in currentActivitiesByType)
			{
				MotorDecalLinkData motorDecalLinkData = activityBaseData as MotorDecalLinkData;
				if (motorDecalLinkData != null && motorDecalLinkData.ContainsTaskId(id))
				{
					motorDecalLinkData.OnTaskUpdateNotify(notify);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, motorDecalLinkData.Id);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, motorDecalLinkData.Id);
					break;
				}
			}
		}

		// Token: 0x06041CB7 RID: 269495 RVA: 0x010E10EC File Offset: 0x010DF2EC
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06041CB8 RID: 269496 RVA: 0x010E10EE File Offset: 0x010DF2EE
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiView_MotoLinkageActivityMain33";
		}

		// Token: 0x06041CB9 RID: 269497 RVA: 0x010E10F5 File Offset: 0x010DF2F5
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new MotorDecalLinkView();
		}

		// Token: 0x06041CBA RID: 269498 RVA: 0x010E10FC File Offset: 0x010DF2FC
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new MotorDecalLinkData(data.Id);
		}

		// Token: 0x06041CBB RID: 269499 RVA: 0x010E1109 File Offset: 0x010DF309
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06041CBC RID: 269500 RVA: 0x010E110C File Offset: 0x010DF30C
		public UniTask RequestRandomMotorIpAndRefreshView(int activityId)
		{
			MotorDecalLinkController.<RequestRandomMotorIpAndRefreshView>d__8 <RequestRandomMotorIpAndRefreshView>d__;
			<RequestRandomMotorIpAndRefreshView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRandomMotorIpAndRefreshView>d__.activityId = activityId;
			<RequestRandomMotorIpAndRefreshView>d__.<>1__state = -1;
			<RequestRandomMotorIpAndRefreshView>d__.<>t__builder.Start<MotorDecalLinkController.<RequestRandomMotorIpAndRefreshView>d__8>(ref <RequestRandomMotorIpAndRefreshView>d__);
			return <RequestRandomMotorIpAndRefreshView>d__.<>t__builder.Task;
		}

		// Token: 0x06041CBD RID: 269501 RVA: 0x010E1150 File Offset: 0x010DF350
		public UniTask ReceiveRewardByIpRequest(int activityId, int ipId)
		{
			MotorDecalLinkController.<ReceiveRewardByIpRequest>d__9 <ReceiveRewardByIpRequest>d__;
			<ReceiveRewardByIpRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ReceiveRewardByIpRequest>d__.activityId = activityId;
			<ReceiveRewardByIpRequest>d__.ipId = ipId;
			<ReceiveRewardByIpRequest>d__.<>1__state = -1;
			<ReceiveRewardByIpRequest>d__.<>t__builder.Start<MotorDecalLinkController.<ReceiveRewardByIpRequest>d__9>(ref <ReceiveRewardByIpRequest>d__);
			return <ReceiveRewardByIpRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06041CBE RID: 269502 RVA: 0x010E119C File Offset: 0x010DF39C
		public void OnFirstRead(int activityId)
		{
			MotorDecalLinkData motorDecalLinkData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as MotorDecalLinkData;
			if (motorDecalLinkData == null)
			{
				return;
			}
			motorDecalLinkData.SetHasFirstRead();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}
	}
}
