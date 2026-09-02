using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop
{
	// Token: 0x0200671B RID: 26395
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityMotorDevelopController : ActivityControllerBase<ActivityMotorDevelopController>
	{
		// Token: 0x06041DA0 RID: 269728 RVA: 0x010E53A6 File Offset: 0x010E35A6
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06041DA1 RID: 269729 RVA: 0x010E53A8 File Offset: 0x010E35A8
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityMotoCultivate";
		}

		// Token: 0x06041DA2 RID: 269730 RVA: 0x010E53AF File Offset: 0x010E35AF
		public override void OnActivityFirstUnlock(ActivityBaseData data)
		{
			((ActivityMotorDevelopData)data).SetActivityFirstUnlockUnReadFlag(1);
		}

		// Token: 0x06041DA3 RID: 269731 RVA: 0x010E53C0 File Offset: 0x010E35C0
		public void RefreshFirstUnlockUnReadRedDot()
		{
			ActivityMotorDevelopData activityData = this.GetActivityData();
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetActivityCacheData(this.ActivityId, 0, 2, 0, 0)) : null;
			if (activityData.IsUnLock() && num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					activityData.SetActivityFirstUnlockUnReadFlag(0);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
				}
			}
		}

		// Token: 0x06041DA4 RID: 269732 RVA: 0x010E5443 File Offset: 0x010E3643
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewMotorDevelop();
		}

		// Token: 0x06041DA5 RID: 269733 RVA: 0x010E544A File Offset: 0x010E364A
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new ActivityMotorDevelopData();
		}

		// Token: 0x06041DA6 RID: 269734 RVA: 0x010E545D File Offset: 0x010E365D
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06041DA7 RID: 269735 RVA: 0x010E5460 File Offset: 0x010E3660
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<MotorDevelopTaskUpdateNotify>(ENotifyMessageId.MotorDevelopTaskUpdateNotify, new Action<MotorDevelopTaskUpdateNotify, Net.CallbackStatus>(this.OnMotorDevelopTaskUpdateNotify));
		}

		// Token: 0x06041DA8 RID: 269736 RVA: 0x010E547E File Offset: 0x010E367E
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorDevelopTaskUpdateNotify);
		}

		// Token: 0x06041DA9 RID: 269737 RVA: 0x010E5490 File Offset: 0x010E3690
		[NullableContext(2)]
		public ActivityMotorDevelopData GetActivityData()
		{
			ActivityMotorDevelopData activityMotorDevelopData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityMotorDevelopData;
			if (activityMotorDevelopData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "摩托开发任务活动数据更新错误，没有活动数据:";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId:", this.ActivityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return activityMotorDevelopData;
		}

		// Token: 0x06041DAA RID: 269738 RVA: 0x010E54F0 File Offset: 0x010E36F0
		protected void OnMotorDevelopTaskUpdateNotify(MotorDevelopTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityMotorDevelopData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateMotorDevelopTask(notify.Task);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMotorDevelopTaskUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}

		// Token: 0x06041DAB RID: 269739 RVA: 0x010E553C File Offset: 0x010E373C
		public void RewardReceiveRequest(List<int> taskIds)
		{
			MotorDevelopTaskRewardRequest motorDevelopTaskRewardRequest = MotorDevelopTaskRewardRequest.Create();
			motorDevelopTaskRewardRequest.Ids.AddRange(taskIds);
			Singleton<Net>.Instance.Call<MotorDevelopTaskRewardResponse>(ERequestMessageId.MotorDevelopTaskRewardRequest, motorDevelopTaskRewardRequest, delegate(MotorDevelopTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27353, null, true, true);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			}, 0);
		}

		// Token: 0x04024BF8 RID: 150520
		private const int FIRSTUNLOCK = 2;

		// Token: 0x04024BF9 RID: 150521
		public int ActivityId;
	}
}
