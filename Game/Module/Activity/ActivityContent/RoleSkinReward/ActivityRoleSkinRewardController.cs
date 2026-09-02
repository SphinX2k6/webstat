using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinReward
{
	// Token: 0x0200647E RID: 25726
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityRoleSkinRewardController : ActivityControllerBase<ActivityRoleSkinRewardController>
	{
		// Token: 0x06040891 RID: 264337 RVA: 0x0108AC58 File Offset: 0x01088E58
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06040892 RID: 264338 RVA: 0x0108AC5A File Offset: 0x01088E5A
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<SkinRewardInfoUpdateNotify>(ENotifyMessageId.SkinRewardInfoUpdateNotify, new Action<SkinRewardInfoUpdateNotify, Net.CallbackStatus>(this.OnSkinRewardInfoUpdateNotify));
		}

		// Token: 0x06040893 RID: 264339 RVA: 0x0108AC78 File Offset: 0x01088E78
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SkinRewardInfoUpdateNotify);
		}

		// Token: 0x06040894 RID: 264340 RVA: 0x0108AC8A File Offset: 0x01088E8A
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityRoverSkinMain";
		}

		// Token: 0x06040895 RID: 264341 RVA: 0x0108AC91 File Offset: 0x01088E91
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityRoleSkinRewardSubView();
		}

		// Token: 0x06040896 RID: 264342 RVA: 0x0108AC98 File Offset: 0x01088E98
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new ActivityRoleSkinRewardData();
		}

		// Token: 0x06040897 RID: 264343 RVA: 0x0108ACAB File Offset: 0x01088EAB
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06040898 RID: 264344 RVA: 0x0108ACB0 File Offset: 0x01088EB0
		[NullableContext(2)]
		public ActivityRoleSkinRewardData GetSkinRewardData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.SkinRewardActivity);
			ActivityRoleSkinRewardData result = null;
			if (currentActivitiesByType != null)
			{
				result = (currentActivitiesByType[0] as ActivityRoleSkinRewardData);
			}
			return result;
		}

		// Token: 0x06040899 RID: 264345 RVA: 0x0108ACE0 File Offset: 0x01088EE0
		private void OnSkinRewardInfoUpdateNotify(SkinRewardInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify.RewardInfo != null)
			{
				this.GetSkinRewardData().UpdateSkinRewardState(notify.RewardInfo.ConfigId, notify.RewardInfo.State);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.ActivityId);
			}
		}

		// Token: 0x040241DE RID: 147934
		public int ActivityId;
	}
}
