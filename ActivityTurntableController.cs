using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x020015EA RID: 5610
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityTurntableController : ActivityControllerBase<ActivityTurntableController>
{
	// Token: 0x06009E16 RID: 40470 RVA: 0x00296253 File Offset: 0x00294453
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TurntableTaskUpdateNotify>(ENotifyMessageId.TurntableTaskUpdateNotify, new Action<TurntableTaskUpdateNotify, Net.CallbackStatus>(this.OnTurntableTaskUpdateNotify));
	}

	// Token: 0x06009E17 RID: 40471 RVA: 0x00296271 File Offset: 0x00294471
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TurntableTaskUpdateNotify);
	}

	// Token: 0x06009E18 RID: 40472 RVA: 0x00296283 File Offset: 0x00294483
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06009E19 RID: 40473 RVA: 0x002962BD File Offset: 0x002944BD
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06009E1A RID: 40474 RVA: 0x002962F7 File Offset: 0x002944F7
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009E1B RID: 40475 RVA: 0x002962F9 File Offset: 0x002944F9
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		if (data.GetPreGuideQuestFinishState())
		{
			return "UiItem_ActivityTurntable";
		}
		return "UiItem_ActivityTurntableLock";
	}

	// Token: 0x06009E1C RID: 40476 RVA: 0x0029630E File Offset: 0x0029450E
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		if (data.GetPreGuideQuestFinishState())
		{
			return new ActivitySubViewTurntable();
		}
		return new ActivitySubViewTurntableLock();
	}

	// Token: 0x06009E1D RID: 40477 RVA: 0x00296323 File Offset: 0x00294523
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityTurntableData();
	}

	// Token: 0x06009E1E RID: 40478 RVA: 0x0029632A File Offset: 0x0029452A
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009E1F RID: 40479 RVA: 0x00296330 File Offset: 0x00294530
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(15))
		{
			(activityBaseData as ActivityTurntableData).OnQuestStateChange(questId, state, EQuestStatusUpdateReason.ReLogin);
		}
	}

	// Token: 0x06009E20 RID: 40480 RVA: 0x00296390 File Offset: 0x00294590
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(15))
		{
			(activityBaseData as ActivityTurntableData).OnCommonItemCountAnyChange(configId, count);
		}
	}

	// Token: 0x06009E21 RID: 40481 RVA: 0x002963F0 File Offset: 0x002945F0
	private void OnTurntableTaskUpdateNotify(TurntableTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(15))
		{
			ActivityTurntableData activityTurntableData = activityBaseData as ActivityTurntableData;
			if (notify.TurntableTask != null)
			{
				activityTurntableData.RefreshTask(notify.TurntableTask, false);
			}
		}
	}

	// Token: 0x06009E22 RID: 40482 RVA: 0x0029645C File Offset: 0x0029465C
	public static void RequestTurntableRun(int activityId)
	{
		RunTurntableActivityRequest runTurntableActivityRequest = RunTurntableActivityRequest.Create();
		runTurntableActivityRequest.ActivityId = activityId;
		Singleton<Net>.Instance.Call<RunTurntableActivityResponse>(ERequestMessageId.RunTurntableActivityRequest, runTurntableActivityRequest, delegate(RunTurntableActivityResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18579, null, true, true);
			}
			ActivityTurntableData activityTurntableData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityTurntableData;
			if (activityTurntableData == null)
			{
				return;
			}
			List<TItem> list = new List<TItem>();
			foreach (int num in response.ItemMap.Keys)
			{
				TItem item = new TItem(new InventoryDefine.GetItemData(num, 0), response.ItemMap[num]);
				list.Add(item);
			}
			activityTurntableData.SetRunResult(response.RewardId, list);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.TurntableStartRun, response.RewardId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06009E23 RID: 40483 RVA: 0x002964A8 File Offset: 0x002946A8
	public static void ShowTurntableItemObtain(List<TItem> itemList, [Nullable(2)] Action onCloseCallback = null)
	{
		if (itemList.Count == 0)
		{
			return;
		}
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (TItem titem in itemList)
		{
			RewardItemData item = new RewardItemData(titem.ItemData.ItemId, titem.Count, new int?(titem.ItemData.IncId), EDropItemType.Normal);
			list.Add(item);
		}
		RewardViewFromSource? rewardViewFromSource;
		int? num = (ConfigBase<ItemRewardConfig>.Instance.GetRewardViewFromSourceConfig(20531) != null) ? new int?(rewardViewFromSource.GetValueOrDefault().RewardViewId) : null;
		if (num != null)
		{
			ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(num.Value, list, onCloseCallback);
		}
	}
}
