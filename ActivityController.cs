using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001722 RID: 5922
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityController : ControllerBase<ActivityController>
{
	// Token: 0x0600A49A RID: 42138 RVA: 0x002B86B8 File Offset: 0x002B68B8
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		ActivityManager.Init();
		this.OnAddOpenViewCheckFunction();
		Singleton<InputManager>.Instance.RegisterOpenViewFunc(EUiViewName.CommonActivityView, new Action(this.OpenActivityView));
		this.IsDataInit = false;
		return true;
	}

	// Token: 0x0600A49B RID: 42139 RVA: 0x002B86F4 File Offset: 0x002B68F4
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		ActivityManager.Clear();
		this.CancelTimer();
		this.OnRemoveOpenViewCheckFunction();
		this.IsDataInit = false;
		this.DisableRefreshTimer();
		return true;
	}

	// Token: 0x0600A49C RID: 42140 RVA: 0x002B8721 File Offset: 0x002B6921
	public void EnableRefreshTimer(float interval)
	{
		if (this.RefreshTimer != null)
		{
			return;
		}
		this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshTimer), interval, 1f, null, null, true);
	}

	// Token: 0x0600A49D RID: 42141 RVA: 0x002B8751 File Offset: 0x002B6951
	public void DisableRefreshTimer()
	{
		if (this.RefreshTimer == null)
		{
			return;
		}
		this.RefreshTimerDelegateSet.Clear();
		TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
		this.RefreshTimer = null;
	}

	// Token: 0x0600A49E RID: 42142 RVA: 0x002B877F File Offset: 0x002B697F
	public void RegisterRefreshTimerDelegate(Action<float> @delegate)
	{
		this.RefreshTimerDelegateSet.Add(@delegate);
	}

	// Token: 0x0600A49F RID: 42143 RVA: 0x002B878E File Offset: 0x002B698E
	public void UnregisterRefreshTimerDelegate(Action<float> @delegate)
	{
		this.RefreshTimerDelegateSet.Remove(@delegate);
	}

	// Token: 0x0600A4A0 RID: 42144 RVA: 0x002B87A0 File Offset: 0x002B69A0
	private void OnRefreshTimer(float delta)
	{
		if (this.RefreshTimerDelegateSet.Count == 0)
		{
			return;
		}
		foreach (Action<float> action in this.RefreshTimerDelegateSet)
		{
			action(delta);
		}
	}

	// Token: 0x0600A4A1 RID: 42145 RVA: 0x002B8800 File Offset: 0x002B6A00
	private void OpenActivityView()
	{
		this.OpenActivityById(0, EActivityViewOpenType.HotKey, null, null);
	}

	// Token: 0x0600A4A2 RID: 42146 RVA: 0x002B880D File Offset: 0x002B6A0D
	protected void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.CommonActivityView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "ActivityController.CheckCanOpen");
	}

	// Token: 0x0600A4A3 RID: 42147 RVA: 0x002B882F File Offset: 0x002B6A2F
	protected void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.CommonActivityView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
	}

	// Token: 0x0600A4A4 RID: 42148 RVA: 0x002B884C File Offset: 0x002B6A4C
	public bool CheckCanOpen(EUiViewName viewName, object param)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10053))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
			return false;
		}
		return ModelBase<ActivityModel>.Instance.GetCurrentShowingActivities().Count != 0;
	}

	// Token: 0x0600A4A5 RID: 42149 RVA: 0x002B8887 File Offset: 0x002B6A87
	public bool CheckCanOpenWithoutPrompt()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10053) && ModelBase<ActivityModel>.Instance.GetCurrentShowingActivities().Count != 0;
	}

	// Token: 0x0600A4A6 RID: 42150 RVA: 0x002B88AE File Offset: 0x002B6AAE
	private void CheckActivityActiveState()
	{
		ModelBase<ActivityModel>.Instance.RefreshShowingActivities();
	}

	// Token: 0x0600A4A7 RID: 42151 RVA: 0x002B88BC File Offset: 0x002B6ABC
	public void ShowActivityRefreshAndBackToBattleView()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
		confirmBoxDataNew.FunctionMap.Add(1, new Action(ActivityController.<ShowActivityRefreshAndBackToBattleView>g__ConfirmCallback|17_0));
		confirmBoxDataNew.FunctionMap.Add(0, new Action(ActivityController.<ShowActivityRefreshAndBackToBattleView>g__ConfirmCallback|17_0));
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A4A8 RID: 42152 RVA: 0x002B8910 File Offset: 0x002B6B10
	private void ShowActivityClose()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AllActivityClose);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A4A9 RID: 42153 RVA: 0x002B8934 File Offset: 0x002B6B34
	private void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.LocalStorageInitPlayerId, new Action(this.InitActivityLocalRedPointData));
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x0600A4AA RID: 42154 RVA: 0x002B89EC File Offset: 0x002B6BEC
	private void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.LocalStorageInitPlayerId, new Action(this.InitActivityLocalRedPointData));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x0600A4AB RID: 42155 RVA: 0x002B8AA1 File Offset: 0x002B6CA1
	private void OnReceiveActivityData(int type, IReadOnlyList<int> activityIds)
	{
		this.InitActivity(type);
	}

	// Token: 0x0600A4AC RID: 42156 RVA: 0x002B8AAA File Offset: 0x002B6CAA
	public void InitActivity(int type)
	{
	}

	// Token: 0x0600A4AD RID: 42157 RVA: 0x002B8AAC File Offset: 0x002B6CAC
	private void InitActivityLocalRedPointData()
	{
		ModelBase<ActivityModel>.Instance.InitCache();
	}

	// Token: 0x0600A4AE RID: 42158 RVA: 0x002B8AB8 File Offset: 0x002B6CB8
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ActivityUpdateNotify>(ENotifyMessageId.ActivityUpdateNotify, new Action<ActivityUpdateNotify, Net.CallbackStatus>(this.OnActivityUpdateNotify));
		Singleton<Net>.Instance.Register<ActivityDisableNotify>(ENotifyMessageId.ActivityDisableNotify, new Action<ActivityDisableNotify, Net.CallbackStatus>(this.OnActivityDisableNotify));
	}

	// Token: 0x0600A4AF RID: 42159 RVA: 0x002B8AF2 File Offset: 0x002B6CF2
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ActivityUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ActivityDisableNotify);
	}

	// Token: 0x0600A4B0 RID: 42160 RVA: 0x002B8B14 File Offset: 0x002B6D14
	private void OnDataDone()
	{
		this.InitTimer();
	}

	// Token: 0x0600A4B1 RID: 42161 RVA: 0x002B8B1C File Offset: 0x002B6D1C
	private void OnWorldDone()
	{
		if (!this.IsDataInit)
		{
			this.IsDataInit = true;
			ControllerBase<GameModeController>.Instance.AddWorldDoneBlocker(new Func<UniTask>(this.InitActivityDataOnWorldDone), 60000);
		}
	}

	// Token: 0x0600A4B2 RID: 42162 RVA: 0x002B8B48 File Offset: 0x002B6D48
	private UniTask InitActivityDataOnWorldDone()
	{
		ActivityController.<InitActivityDataOnWorldDone>d__28 <InitActivityDataOnWorldDone>d__;
		<InitActivityDataOnWorldDone>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitActivityDataOnWorldDone>d__.<>4__this = this;
		<InitActivityDataOnWorldDone>d__.<>1__state = -1;
		<InitActivityDataOnWorldDone>d__.<>t__builder.Start<ActivityController.<InitActivityDataOnWorldDone>d__28>(ref <InitActivityDataOnWorldDone>d__);
		return <InitActivityDataOnWorldDone>d__.<>t__builder.Task;
	}

	// Token: 0x0600A4B3 RID: 42163 RVA: 0x002B8B8C File Offset: 0x002B6D8C
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		foreach (int id in closeActivities)
		{
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(id);
			if (activityById != null && this.IsOpeningActivityRelativeView((int)activityById.Type))
			{
				this.ShowActivityRefreshAndBackToBattleView();
				break;
			}
		}
	}

	// Token: 0x0600A4B4 RID: 42164 RVA: 0x002B8BF4 File Offset: 0x002B6DF4
	private void OnCrossDay()
	{
		this.RequestActivityData().ContinueWith(delegate(bool success)
		{
			if (!success)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YYZ, "[CrossDay][Activity] 跨天活动数据刷新完成", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit(EEventName.ActivityCrossDayRefresh);
		});
	}

	// Token: 0x0600A4B5 RID: 42165 RVA: 0x002B8C21 File Offset: 0x002B6E21
	private void CancelTimer()
	{
		if (this.CheckActivityTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CheckActivityTimer);
			this.CheckActivityTimer = null;
		}
	}

	// Token: 0x0600A4B6 RID: 42166 RVA: 0x002B8C43 File Offset: 0x002B6E43
	private void InitTimer()
	{
		this.CancelTimer();
		this.CheckActivityTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnCheckActivityTimer), 600000f, 1f, null, null, false);
	}

	// Token: 0x0600A4B7 RID: 42167 RVA: 0x002B8C74 File Offset: 0x002B6E74
	private void OnCheckActivityTimer(float delta)
	{
		this.RequestActivityData();
	}

	// Token: 0x0600A4B8 RID: 42168 RVA: 0x002B8C80 File Offset: 0x002B6E80
	[NullableContext(2)]
	public bool OpenActivityById(int id = 0, EActivityViewOpenType openType = EActivityViewOpenType.Other, object activityOpenParam = null, Action<bool> finishCallback = null)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10053))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
			return false;
		}
		if (ModelBase<ActivityModel>.Instance.GetCurrentShowingActivities().Count == 0)
		{
			this.ShowActivityClose();
			return false;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.CommonActivityView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonActivityView, new object[]
			{
				openType,
				id,
				activityOpenParam
			}, delegate(bool success, int viewId)
			{
				Action<bool> finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2(success);
			});
		}
		else
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewChange, id);
		}
		return true;
	}

	// Token: 0x0600A4B9 RID: 42169 RVA: 0x002B8D37 File Offset: 0x002B6F37
	public void OpenActivityContentView(ActivityBaseData data)
	{
		ActivityManager.GetActivityController(data.Type).OpenView(data);
	}

	// Token: 0x0600A4BA RID: 42170 RVA: 0x002B8D4C File Offset: 0x002B6F4C
	[NullableContext(0)]
	public UniTask<bool> RequestActivityData()
	{
		ActivityController.<RequestActivityData>d__36 <RequestActivityData>d__;
		<RequestActivityData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestActivityData>d__.<>1__state = -1;
		<RequestActivityData>d__.<>t__builder.Start<ActivityController.<RequestActivityData>d__36>(ref <RequestActivityData>d__);
		return <RequestActivityData>d__.<>t__builder.Task;
	}

	// Token: 0x0600A4BB RID: 42171 RVA: 0x002B8D88 File Offset: 0x002B6F88
	[NullableContext(2)]
	public void RequestReadActivity(ActivityBaseData activityData)
	{
		ActivityBaseData activityData2 = activityData;
		if (activityData2 != null && activityData2.GetIfFirstOpen())
		{
			ActivityFirstReadRequest activityFirstReadRequest = ActivityFirstReadRequest.Create();
			activityFirstReadRequest.ActivityId = activityData.Id;
			Singleton<Net>.Instance.Call<ActivityFirstReadResponse>(ERequestMessageId.ActivityFirstReadRequest, activityFirstReadRequest, delegate(ActivityFirstReadResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28950, null, true, true);
				}
				ModelBase<ActivityModel>.Instance.OnReceiveActivityRead(activityData.Id);
			}, 0);
		}
		ModelBase<ActivityModel>.Instance.OnReceiveActivityRead(activityData.Id);
	}

	// Token: 0x0600A4BC RID: 42172 RVA: 0x002B8E00 File Offset: 0x002B7000
	[NullableContext(2)]
	public void RequestPreOpenActivity(ActivityBaseData activityData, Action<bool> callback)
	{
		ActivityBaseData activityData2 = activityData;
		if (activityData2 == null || !activityData2.CanPreOpen())
		{
			return;
		}
		ActivityPreOpenRequest activityPreOpenRequest = ActivityPreOpenRequest.Create();
		activityPreOpenRequest.ActivityId = activityData.Id;
		Singleton<Net>.Instance.Call<ActivityPreOpenResponse>(ERequestMessageId.ActivityPreOpenRequest, activityPreOpenRequest, delegate(ActivityPreOpenResponse response, Net.CallbackStatus _)
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
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22589, null, true, true);
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
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnActivityPreOpen, activityData.Id);
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

	// Token: 0x0600A4BD RID: 42173 RVA: 0x002B8E6D File Offset: 0x002B706D
	private void OnActivityUpdateNotify(ActivityUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<ActivityModel>.Instance.OnActivityUpdate(message.Activities.ToArray<ActivityData>());
		this.CheckActivityActiveState();
	}

	// Token: 0x0600A4BE RID: 42174 RVA: 0x002B8E8A File Offset: 0x002B708A
	private void OnActivityDisableNotify(ActivityDisableNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<ActivityModel>.Instance.OnDisableActivity(message.ActivityIds.ToArray<int>());
		this.CheckActivityActiveState();
	}

	// Token: 0x0600A4BF RID: 42175 RVA: 0x002B8EA7 File Offset: 0x002B70A7
	public ActivityBaseData CreateActivityData(ActivityData data)
	{
		return ActivityManager.GetActivityController(data.Type).CreateActivityData(data);
	}

	// Token: 0x0600A4C0 RID: 42176 RVA: 0x002B8EBA File Offset: 0x002B70BA
	public bool IsOpeningActivityRelativeView(int type)
	{
		IActivityControllerBase activityController = ActivityManager.GetActivityController(type);
		return activityController != null && activityController.GetIsOpeningActivityRelativeView();
	}

	// Token: 0x0600A4C1 RID: 42177 RVA: 0x002B8ED0 File Offset: 0x002B70D0
	public void OpenActivityConditionView(int activityId)
	{
		if (activityId != 0)
		{
			ActivityConditionGroupData param = new ActivityConditionGroupData(activityId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityConditionView, param, null);
		}
	}

	// Token: 0x0600A4C2 RID: 42178 RVA: 0x002B8EF8 File Offset: 0x002B70F8
	public void CheckIsActivityClose(int? type = null, int? activityId = null)
	{
		if (activityId != null)
		{
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(activityId.Value);
			if (activityById != null && activityById.CheckIfClose())
			{
				this.ShowActivityRefreshAndBackToBattleView();
			}
			return;
		}
		if (type == null)
		{
			return;
		}
		using (List<ActivityBaseData>.Enumerator enumerator = ModelBase<ActivityModel>.Instance.GetActivitiesByType(type.Value).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CheckIfClose())
				{
					this.ShowActivityRefreshAndBackToBattleView();
					break;
				}
			}
		}
	}

	// Token: 0x0600A4C4 RID: 42180 RVA: 0x002B8FAB File Offset: 0x002B71AB
	[CompilerGenerated]
	internal static void <ShowActivityRefreshAndBackToBattleView>g__ConfirmCallback|17_0()
	{
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x04004E44 RID: 20036
	[Nullable(2)]
	private TimerHandle CheckActivityTimer;

	// Token: 0x04004E45 RID: 20037
	private bool IsDataInit;

	// Token: 0x04004E46 RID: 20038
	[Nullable(2)]
	private TimerHandle RefreshTimer;

	// Token: 0x04004E47 RID: 20039
	private HashSet<Action<float>> RefreshTimerDelegateSet = new HashSet<Action<float>>();
}
