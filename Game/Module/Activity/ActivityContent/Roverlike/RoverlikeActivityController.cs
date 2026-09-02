using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A9 RID: 25513
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RoverlikeActivityController : ActivityControllerBase<RoverlikeActivityController>
	{
		// Token: 0x06040122 RID: 262434 RVA: 0x0106C79D File Offset: 0x0106A99D
		protected override void OnOpenView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeMainView, data, null);
		}

		// Token: 0x06040123 RID: 262435 RVA: 0x0106C7B0 File Offset: 0x0106A9B0
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_RoverlikeActivity";
		}

		// Token: 0x06040124 RID: 262436 RVA: 0x0106C7B7 File Offset: 0x0106A9B7
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewRoverlike();
		}

		// Token: 0x06040125 RID: 262437 RVA: 0x0106C7BE File Offset: 0x0106A9BE
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new RoverlikeActivityData();
		}

		// Token: 0x06040126 RID: 262438 RVA: 0x0106C7C8 File Offset: 0x0106A9C8
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			RoverlikeActivityController.<OnOpenSubView>d__4 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<RoverlikeActivityController.<OnOpenSubView>d__4>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x06040127 RID: 262439 RVA: 0x0106C80C File Offset: 0x0106AA0C
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			foreach (EUiViewName viewName in new List<EUiViewName>
			{
				EUiViewName.RoverlikeMainView,
				EUiViewName.RoverlikeLevelSelectView,
				EUiViewName.RoverlikeQuestRewardView,
				EUiViewName.RoverlikeShopView,
				EUiViewName.RoverlikeHandBookView,
				EUiViewName.RoverlikeTalentTreeView
			})
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040128 RID: 262440 RVA: 0x0106C8B0 File Offset: 0x0106AAB0
		[NullableContext(2)]
		public RoverlikeActivityData GetCurrentActivityData()
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			List<ActivityBaseData> list = (instance != null) ? instance.GetActivitiesByType(112) : null;
			RoverlikeActivityData result = null;
			if (list != null)
			{
				foreach (ActivityBaseData activityBaseData in list)
				{
					result = (activityBaseData as RoverlikeActivityData);
				}
			}
			return result;
		}

		// Token: 0x06040129 RID: 262441 RVA: 0x0106C918 File Offset: 0x0106AB18
		public int? GetCurrentActivityId()
		{
			RoverlikeActivityData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return null;
			}
			return new int?(currentActivityData.Id);
		}

		// Token: 0x0604012A RID: 262442 RVA: 0x0106C943 File Offset: 0x0106AB43
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RoverRogueTaskUpdateNotify>(ENotifyMessageId.RoverRogueTaskUpdateNotify, new Action<RoverRogueTaskUpdateNotify, Net.CallbackStatus>(this.OnRoverRogueTaskUpdateNotify));
		}

		// Token: 0x0604012B RID: 262443 RVA: 0x0106C961 File Offset: 0x0106AB61
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueTaskUpdateNotify);
		}

		// Token: 0x0604012C RID: 262444 RVA: 0x0106C974 File Offset: 0x0106AB74
		[NullableContext(2)]
		private void OnRoverRogueTaskUpdateNotify(RoverRogueTaskUpdateNotify notify, Net.CallbackStatus status)
		{
			RoverlikeActivityData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null || notify == null)
			{
				return;
			}
			currentActivityData.QuestData.UpdateTasks(notify.Tasks);
			Singleton<EventSystem>.Instance.Emit(EEventName.RoverlikeQuestTaskUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, currentActivityData.Id);
		}

		// Token: 0x0604012D RID: 262445 RVA: 0x0106C9C6 File Offset: 0x0106ABC6
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeUnlockTipView, null, null);
		}
	}
}
