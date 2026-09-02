using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x02001467 RID: 5223
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityNewPlayerSupportController : ActivityControllerBase<ActivityNewPlayerSupportController>
{
	// Token: 0x17000C1E RID: 3102
	// (get) Token: 0x060091F1 RID: 37361 RVA: 0x00268149 File Offset: 0x00266349
	[Nullable(2)]
	public ActivityNewPlayerSupportData ActivityData
	{
		[NullableContext(2)]
		get
		{
			return this.ActivityDataInternal;
		}
	}

	// Token: 0x060091F2 RID: 37362 RVA: 0x00268154 File Offset: 0x00266354
	protected override bool OnInit()
	{
		bool flag = false;
		if (!Singleton<Info>.Instance.IsBuildShipping)
		{
			flag = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.NewPlayerSupportForbidStartView, false);
		}
		this.ActivityStartConditionMap[ENewPlayerSupportStartCondition.UnForbidStart] = !flag;
		return true;
	}

	// Token: 0x060091F3 RID: 37363 RVA: 0x0026818C File Offset: 0x0026638C
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivityNewPlayerSupportInfoUpdate, new Action(this.OnActivityInfoUpdate));
	}

	// Token: 0x060091F4 RID: 37364 RVA: 0x002681C6 File Offset: 0x002663C6
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityNewPlayerSupportInfoUpdate, new Action(this.OnActivityInfoUpdate));
	}

	// Token: 0x060091F5 RID: 37365 RVA: 0x00268200 File Offset: 0x00266400
	protected override bool OnClear()
	{
		this.ActivityStartConditionMap.Clear();
		return true;
	}

	// Token: 0x060091F6 RID: 37366 RVA: 0x0026820E File Offset: 0x0026640E
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<NewPlayerSupportActivityTaskUpdateNotify>(ENotifyMessageId.NewPlayerSupportActivityTaskUpdateNotify, new Action<NewPlayerSupportActivityTaskUpdateNotify, Net.CallbackStatus>(this.OnTaskUpdateNotify));
		Singleton<Net>.Instance.Register<NewPlayerSupportActivityTrialRoleUpdateNotify>(ENotifyMessageId.NewPlayerSupportActivityTrialRoleUpdateNotify, new Action<NewPlayerSupportActivityTrialRoleUpdateNotify, Net.CallbackStatus>(this.OnTrialRoleUpdateNotify));
	}

	// Token: 0x060091F7 RID: 37367 RVA: 0x00268248 File Offset: 0x00266448
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewPlayerSupportActivityTaskUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewPlayerSupportActivityTrialRoleUpdateNotify);
	}

	// Token: 0x060091F8 RID: 37368 RVA: 0x0026826A File Offset: 0x0026646A
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060091F9 RID: 37369 RVA: 0x0026826C File Offset: 0x0026646C
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_BeginnerSupportGuideView";
	}

	// Token: 0x060091FA RID: 37370 RVA: 0x00268273 File Offset: 0x00266473
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivityNewPlayerSupportSubView();
	}

	// Token: 0x060091FB RID: 37371 RVA: 0x0026827A File Offset: 0x0026647A
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityDataInternal = new ActivityNewPlayerSupportData();
		return this.ActivityDataInternal;
	}

	// Token: 0x060091FC RID: 37372 RVA: 0x00268290 File Offset: 0x00266490
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		foreach (EUiViewName viewName in new EUiViewName[]
		{
			EUiViewName.ActivityNewPlayerSupportTrialRoleView
		})
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060091FD RID: 37373 RVA: 0x002682D8 File Offset: 0x002664D8
	private void OnTaskUpdateNotify(NewPlayerSupportActivityTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (this.ActivityDataInternal != null)
		{
			this.ActivityDataInternal.UpdateTaskData(notify.ConditionTasks);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityDataInternal.Id);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityNewPlayerSupportTaskUpdate);
	}

	// Token: 0x060091FE RID: 37374 RVA: 0x0026832C File Offset: 0x0026652C
	private void OnTrialRoleUpdateNotify(NewPlayerSupportActivityTrialRoleUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		RepeatedField<int> trialRoleId = notify.TrialRoleId;
		roleInfo curUseRoleInfo = notify.CurUseRoleInfo;
		foreach (int num in trialRoleId)
		{
			if (curUseRoleInfo != null && curUseRoleInfo.RoleId == num)
			{
				this.UpdateActivatedTrialRoleInternal(num, curUseRoleInfo);
			}
			else
			{
				this.UpdateActivatedTrialRoleInternal(num, null);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityDataInternal.Id);
	}

	// Token: 0x060091FF RID: 37375 RVA: 0x002683B4 File Offset: 0x002665B4
	private void OnWorldDone()
	{
		this.ActivityStartConditionMap[ENewPlayerSupportStartCondition.WorldDone] = true;
		this.CheckIsStart(false);
	}

	// Token: 0x06009200 RID: 37376 RVA: 0x002683CC File Offset: 0x002665CC
	private void OnActivityInfoUpdate()
	{
		bool worldDone = ModelBase<GameModeModel>.Instance.WorldDone;
		this.ActivityStartConditionMap[ENewPlayerSupportStartCondition.WorldDone] = worldDone;
		ActivityNewPlayerSupportData activityDataInternal = this.ActivityDataInternal;
		bool value = activityDataInternal != null && activityDataInternal.IsActivityFirstShow;
		this.ActivityStartConditionMap[ENewPlayerSupportStartCondition.FirstShow] = value;
		this.CheckIsStart(true);
	}

	// Token: 0x06009201 RID: 37377 RVA: 0x00268418 File Offset: 0x00266618
	private void CheckIsStart(bool isInstantly = false)
	{
		if (!Singleton<PublicUtil>.Instance.GetIsSilentLogin())
		{
			ActivityNewPlayerSupportData activityDataInternal = this.ActivityDataInternal;
			if (activityDataInternal == null || !activityDataInternal.AlreadyStartView)
			{
				bool flag = true;
				foreach (object obj in Enum.GetValues(typeof(ENewPlayerSupportStartCondition)))
				{
					ENewPlayerSupportStartCondition key = (ENewPlayerSupportStartCondition)obj;
					bool flag2;
					if (!this.ActivityStartConditionMap.TryGetValue(key, out flag2) || !flag2)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					this.ResetCondition();
					return;
				}
				SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.NewPlayerSupport, ESplashScreenType.Config, delegate()
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityNewPlayerSupportStartupView, null, null);
				});
				ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
				return;
			}
		}
		this.ResetCondition();
	}

	// Token: 0x06009202 RID: 37378 RVA: 0x002684F4 File Offset: 0x002666F4
	private void ResetCondition()
	{
		this.ActivityStartConditionMap[ENewPlayerSupportStartCondition.WorldDone] = false;
	}

	// Token: 0x06009203 RID: 37379 RVA: 0x00268504 File Offset: 0x00266704
	public void RequestRewardTask(int taskId, bool receiveAll = false)
	{
		ActivityNewPlayerSupportController.<>c__DisplayClass21_0 CS$<>8__locals1 = new ActivityNewPlayerSupportController.<>c__DisplayClass21_0();
		CS$<>8__locals1.<>4__this = this;
		if (receiveAll)
		{
			ActivityNewPlayerSupportController.<>c__DisplayClass21_0 CS$<>8__locals2 = CS$<>8__locals1;
			ActivityNewPlayerSupportData activityData = this.ActivityData;
			CS$<>8__locals2.taskIds = (((activityData != null) ? activityData.GetCanReceiveTaskIdList() : null) ?? new List<int>());
		}
		else
		{
			CS$<>8__locals1.taskIds = new List<int>
			{
				taskId
			};
		}
		if (CS$<>8__locals1.taskIds == null || CS$<>8__locals1.taskIds.Count <= 0)
		{
			return;
		}
		NewPlayerSupportRewardTaskRequest newPlayerSupportRewardTaskRequest = NewPlayerSupportRewardTaskRequest.Create();
		newPlayerSupportRewardTaskRequest.TaskIds.AddRange(CS$<>8__locals1.taskIds);
		Singleton<Net>.Instance.Call<NewPlayerSupportRewardTaskResponse>(ERequestMessageId.NewPlayerSupportRewardTaskRequest, newPlayerSupportRewardTaskRequest, delegate(NewPlayerSupportRewardTaskResponse response, Net.CallbackStatus __)
		{
			if (response.Code != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 26466, null, true, true);
				return;
			}
			Dictionary<int, RewardItemData> dictionary = new Dictionary<int, RewardItemData>();
			foreach (int id in CS$<>8__locals1.taskIds)
			{
				ActivityNewPlayerSupportTaskData taskData = CS$<>8__locals1.<>4__this.ActivityDataInternal.GetTaskData(id);
				taskData.SetTaskStatus(ConditionTaskState.ConditionTaskTaken);
				foreach (TItem titem in taskData.GetRewardList())
				{
					int itemId = titem.ItemData.ItemId;
					int count = titem.Count;
					int incId = titem.ItemData.IncId;
					RewardItemData rewardItemData;
					if (dictionary.TryGetValue(itemId, out rewardItemData))
					{
						rewardItemData.Count += count;
					}
					else
					{
						dictionary[itemId] = new RewardItemData(itemId, count, new int?(incId), EDropItemType.Normal);
					}
				}
			}
			List<RewardItemData> list = new List<RewardItemData>();
			foreach (RewardItemData item in dictionary.Values)
			{
				list.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityNewPlayerSupportTaskUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, CS$<>8__locals1.<>4__this.ActivityDataInternal.Id);
			RepeatedField<int> roleId = response.RoleId;
			foreach (int roleId2 in roleId)
			{
				CS$<>8__locals1.<>4__this.UpdateActivatedTrialRoleInternal(roleId2, null);
			}
			CS$<>8__locals1.<>4__this.OpenRewardView(list, roleId.ToList<int>());
		}, 0);
	}

	// Token: 0x06009204 RID: 37380 RVA: 0x002685A4 File Offset: 0x002667A4
	public void RequestTrialRoleLvUp(int trialRoleId)
	{
		NewPlayerSupportTrialRoleLvUpRequest newPlayerSupportTrialRoleLvUpRequest = NewPlayerSupportTrialRoleLvUpRequest.Create();
		newPlayerSupportTrialRoleLvUpRequest.TrialRoleId = trialRoleId;
		Singleton<Net>.Instance.Call<NewPlayerSupportTrialRoleLvUpResponse>(ERequestMessageId.NewPlayerSupportTrialRoleLvUpRequest, newPlayerSupportTrialRoleLvUpRequest, delegate(NewPlayerSupportTrialRoleLvUpResponse response, Net.CallbackStatus __)
		{
			if (response.Code != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 25229, null, true, true);
				return;
			}
			this.UpdateActivatedTrialRoleInternal(response.RoleId, response.CurUseRoleInfo);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityData.Id);
		}, 0);
	}

	// Token: 0x06009205 RID: 37381 RVA: 0x002685DC File Offset: 0x002667DC
	[NullableContext(2)]
	public void RequestSetCurUseTrialRole(int trialRoleId, Action<int> callback)
	{
		if (RoleUtils.GetTrialRoleType(trialRoleId) != ETrialRoleType.NewbieSupportTrial)
		{
			return;
		}
		NewPlayerSupportSetCurUseTrialRoleRequest newPlayerSupportSetCurUseTrialRoleRequest = NewPlayerSupportSetCurUseTrialRoleRequest.Create();
		newPlayerSupportSetCurUseTrialRoleRequest.TrialRoleId = trialRoleId;
		Singleton<Net>.Instance.Call<NewPlayerSupportSetCurUseTrialRoleResponse>(ERequestMessageId.NewPlayerSupportSetCurUseTrialRoleRequest, newPlayerSupportSetCurUseTrialRoleRequest, delegate(NewPlayerSupportSetCurUseTrialRoleResponse response, Net.CallbackStatus __)
		{
			if (response.Code != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 26611, null, true, true);
				return;
			}
			int roleId = response.RoleId;
			ActivityNewPlayerSupportData activityData = this.ActivityData;
			if (activityData != null)
			{
				activityData.UpdateCurUseTrialRole(roleId, response.CurUseRoleInfo);
			}
			Action<int> callback2 = callback;
			if (callback2 != null)
			{
				callback2(roleId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnActivityNewPlayerSupportCurTrialRoleChange, roleId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityDataInternal.Id);
		}, 0);
	}

	// Token: 0x06009206 RID: 37382 RVA: 0x00268634 File Offset: 0x00266834
	public void OpenTrialRoleView(int? selectedGroupId = null)
	{
		NewPlayerSupportTrialRoleViewModel newPlayerSupportTrialRoleViewModel = new NewPlayerSupportTrialRoleViewModel(ETrialRoleType.NewbieSupportTrial, ConfigCommonParamById.GetStringConfig("NewPlayerSupportTrialRoleIcon"), ConfigCommonParamById.GetStringConfig("NewPlayerSupportTrialRoleTitle"), 465, selectedGroupId);
		newPlayerSupportTrialRoleViewModel.SetRequestTrialRoleLvUpFunc(new Action<int>(this.RequestTrialRoleLvUp));
		newPlayerSupportTrialRoleViewModel.SetRequestSetCurUseTrialRoleFunc(new Action<int, Action<int>>(this.RequestSetCurUseTrialRole));
		Dictionary<int, string> trialRoleUnlockDesc = ConfigBase<ActivityNewPlayerSupportConfig>.Instance.GetTrialRoleUnlockDesc();
		newPlayerSupportTrialRoleViewModel.SetTrialRoleGroupUnlockDesc(trialRoleUnlockDesc);
		this.ActivityData.SaveTrailRoleEntranceRedDot(false);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityNewPlayerSupportTrialRoleView, newPlayerSupportTrialRoleViewModel, null);
	}

	// Token: 0x06009207 RID: 37383 RVA: 0x002686B8 File Offset: 0x002668B8
	public void OpenRewardView(List<RewardItemData> rewardDataList, List<int> trialRoleList)
	{
		RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCommonRewardDataFromConfig(1009, EUiViewName.ActivityNewPlayerSupportRewardView, rewardDataList, null, null, null, null, null, true, false);
		if (rewardData == null)
		{
			return;
		}
		ActivityNewPlayerSupportRewardViewParam param = new ActivityNewPlayerSupportRewardViewParam
		{
			RewardData = rewardData,
			TrialRoleList = trialRoleList
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityNewPlayerSupportRewardView, param, null);
	}

	// Token: 0x06009208 RID: 37384 RVA: 0x0026870C File Offset: 0x0026690C
	[NullableContext(2)]
	private void UpdateActivatedTrialRoleInternal(int roleId, roleInfo trialRoleInfo = null)
	{
		int? trialRoleGroupId = ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleGroupId(roleId);
		if (ModelBase<TrialRoleModel>.Instance.GetDataByGroupId(trialRoleGroupId.Value).IsLocked())
		{
			this.ActivityData.SaveTrailRoleEntranceRedDot(true);
		}
		this.ActivityData.UpdateActivatedTrialRole(roleId, trialRoleInfo);
	}

	// Token: 0x06009209 RID: 37385 RVA: 0x00268756 File Offset: 0x00266956
	public void NotifyRedDotRefresh()
	{
		if (this.ActivityDataInternal != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityDataInternal.Id);
		}
	}

	// Token: 0x0600920A RID: 37386 RVA: 0x0026877C File Offset: 0x0026697C
	public void SetForbidActivityStart(bool isForbid)
	{
		if (Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		this.ActivityStartConditionMap[ENewPlayerSupportStartCondition.UnForbidStart] = !isForbid;
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.NewPlayerSupportForbidStartView, isForbid);
		if (isForbid)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityNewPlayerSupportStartupView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ActivityNewPlayerSupportStartupView, null);
				return;
			}
		}
		else
		{
			this.CheckIsStart(false);
		}
	}

	// Token: 0x040043A6 RID: 17318
	[Nullable(2)]
	private ActivityNewPlayerSupportData ActivityDataInternal;

	// Token: 0x040043A7 RID: 17319
	private readonly Dictionary<ENewPlayerSupportStartCondition, bool> ActivityStartConditionMap = new Dictionary<ENewPlayerSupportStartCondition, bool>();
}
