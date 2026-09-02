using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061C7 RID: 25031
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class GuQinActivityController : ActivityControllerBase<GuQinActivityController>
	{
		// Token: 0x0603F2AD RID: 258733 RVA: 0x01036D4C File Offset: 0x01034F4C
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<QingXiaoTaskUpdateNotify>(ENotifyMessageId.QingXiaoTaskUpdateNotify, new Action<QingXiaoTaskUpdateNotify, Net.CallbackStatus>(this.OnQingXiaoTaskUpdateNotify));
		}

		// Token: 0x0603F2AE RID: 258734 RVA: 0x01036D6A File Offset: 0x01034F6A
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QingXiaoTaskUpdateNotify);
		}

		// Token: 0x0603F2AF RID: 258735 RVA: 0x01036D7C File Offset: 0x01034F7C
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603F2B0 RID: 258736 RVA: 0x01036D9A File Offset: 0x01034F9A
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603F2B1 RID: 258737 RVA: 0x01036DB8 File Offset: 0x01034FB8
		private void OnQingXiaoTaskUpdateNotify(QingXiaoTaskUpdateNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			if (this.Data == null)
			{
				return;
			}
			foreach (GuQinActivityTabData guQinActivityTabData in this.Data.GetTabDataMap().Values)
			{
				foreach (GuQinActivityTaskData guQinActivityTaskData in guQinActivityTabData.TaskList)
				{
					int id = guQinActivityTaskData.Id;
					ConditionTask task = data.Task;
					int? num = (task != null) ? new int?(task.Id) : null;
					if (id == num.GetValueOrDefault() & num != null)
					{
						ConditionTaskState status2 = data.Task.Status;
						if (guQinActivityTaskData.TaskState == ConditionTaskState.ConditionTaskTaken && status2 != ConditionTaskState.ConditionTaskTaken)
						{
							break;
						}
						guQinActivityTaskData.TaskState = status2;
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.Data.Id);
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.Data.Id);
						break;
					}
				}
			}
		}

		// Token: 0x0603F2B2 RID: 258738 RVA: 0x01036EF4 File Offset: 0x010350F4
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
		{
			if (this.Data == null)
			{
				return;
			}
			foreach (GuQinActivityTabData guQinActivityTabData in this.Data.GetTabDataMap().Values)
			{
				using (List<GuQinActivityTaskData>.Enumerator enumerator2 = guQinActivityTabData.TaskList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.GetConfig().QuestId == questId)
						{
							Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.Data.Id);
							Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.Data.Id);
							break;
						}
					}
				}
			}
		}

		// Token: 0x0603F2B3 RID: 258739 RVA: 0x01036FD8 File Offset: 0x010351D8
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603F2B4 RID: 258740 RVA: 0x01036FDC File Offset: 0x010351DC
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			GuQinActivityController.<OnOpenSubView>d__8 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<GuQinActivityController.<OnOpenSubView>d__8>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x0603F2B5 RID: 258741 RVA: 0x01037027 File Offset: 0x01035227
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_QingxiaoActivityMain";
		}

		// Token: 0x0603F2B6 RID: 258742 RVA: 0x0103702E File Offset: 0x0103522E
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new GuQinActivitySubView();
		}

		// Token: 0x0603F2B7 RID: 258743 RVA: 0x01037035 File Offset: 0x01035235
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.Data = new GuQinActivityData();
			return this.Data;
		}

		// Token: 0x0603F2B8 RID: 258744 RVA: 0x01037048 File Offset: 0x01035248
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GuQinActivityMainView);
		}

		// Token: 0x0603F2B9 RID: 258745 RVA: 0x0103705C File Offset: 0x0103525C
		public void RequestReward(GuQinActivityTaskData taskData, Action callback)
		{
			QingXiaoTaskRewardRequest qingXiaoTaskRewardRequest = new QingXiaoTaskRewardRequest();
			qingXiaoTaskRewardRequest.ActivityId = this.Data.Id;
			qingXiaoTaskRewardRequest.TaskIds.Add(taskData.Id);
			Singleton<Net>.Instance.Call<QingXiaoTaskRewardResponse>(ERequestMessageId.QingXiaoTaskRewardRequest, qingXiaoTaskRewardRequest, delegate(QingXiaoTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response.ErrCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 25392, null, true, true);
					return;
				}
				taskData.TaskState = ConditionTaskState.ConditionTaskTaken;
				callback();
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.Data.Id);
			}, 0);
		}

		// Token: 0x040237B3 RID: 145331
		[Nullable(2)]
		public GuQinActivityData Data;
	}
}
