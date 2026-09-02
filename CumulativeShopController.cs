using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

// Token: 0x020012B8 RID: 4792
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CumulativeShopController : ActivityControllerBase<CumulativeShopController>
{
	// Token: 0x060080A8 RID: 32936 RVA: 0x0021FBCE File Offset: 0x0021DDCE
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060080A9 RID: 32937 RVA: 0x0021FBD0 File Offset: 0x0021DDD0
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiView_CumulativeShop";
	}

	// Token: 0x060080AA RID: 32938 RVA: 0x0021FBD7 File Offset: 0x0021DDD7
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new CumulativeShopSubView();
	}

	// Token: 0x060080AB RID: 32939 RVA: 0x0021FBDE File Offset: 0x0021DDDE
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new CumulativeShopData();
	}

	// Token: 0x060080AC RID: 32940 RVA: 0x0021FBF1 File Offset: 0x0021DDF1
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060080AD RID: 32941 RVA: 0x0021FBF4 File Offset: 0x0021DDF4
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ConsumptiveTaskInfoNotify>(ENotifyMessageId.ConsumptiveTaskInfoNotify, new Action<ConsumptiveTaskInfoNotify, Net.CallbackStatus>(this.ConsumptiveTaskInfoNotify));
		Singleton<Net>.Instance.Register<ConsumptiveTotalScoreNotify>(ENotifyMessageId.ConsumptiveTotalScoreNotify, new Action<ConsumptiveTotalScoreNotify, Net.CallbackStatus>(this.ConsumptiveTotalScoreNotify));
	}

	// Token: 0x060080AE RID: 32942 RVA: 0x0021FC2E File Offset: 0x0021DE2E
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ConsumptiveTaskInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ConsumptiveTotalScoreNotify);
	}

	// Token: 0x060080AF RID: 32943 RVA: 0x0021FC50 File Offset: 0x0021DE50
	public void ConsumptiveRewardRequest(int taskTab)
	{
		CumulativeShopData cumulativeShopData = this.GetCumulativeShopData();
		if (cumulativeShopData == null)
		{
			return;
		}
		List<int> list;
		if (!cumulativeShopData.TaskTabMap.TryGetValue(taskTab, out list) || list == null)
		{
			return;
		}
		List<int> list2 = new List<int>();
		foreach (int num in list)
		{
			ConsumptiveTaskInfo consumptiveTaskInfo;
			if (cumulativeShopData.TaskDataMap.TryGetValue(num, out consumptiveTaskInfo) && ((consumptiveTaskInfo.Reward != null) ? consumptiveTaskInfo.Reward.WaitReward : 0) > 0)
			{
				list2.Add(num);
			}
		}
		ConsumptiveRewardRequest consumptiveRewardRequest = Aki.Protocol.ConsumptiveRewardRequest.Create();
		consumptiveRewardRequest.ActivityId = this.ActivityId;
		foreach (int item in list2)
		{
			consumptiveRewardRequest.TaskIds.Add(item);
		}
		Singleton<Net>.Instance.Call<ConsumptiveRewardResponse>(ERequestMessageId.ConsumptiveRewardRequest, consumptiveRewardRequest, delegate(ConsumptiveRewardResponse response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23185, null, true, true);
				return;
			}
			CumulativeShopData cumulativeShopData2 = this.GetCumulativeShopData();
			for (int i = 0; i < response.TaskInfos.Count; i++)
			{
				ConsumptiveTaskInfo consumptiveTaskInfo2 = response.TaskInfos[i];
				cumulativeShopData2.TaskDataMap[consumptiveTaskInfo2.Id] = consumptiveTaskInfo2;
				int taskTab2 = ConfigBase<CumulativeShopConfig>.Instance.GetCumulativeShopTaskConfig(consumptiveTaskInfo2.Id).Value.TaskTab;
				List<int> list3;
				if (!cumulativeShopData2.TaskTabMap.TryGetValue(taskTab2, out list3) || list3 == null)
				{
					list3 = new List<int>();
				}
				if (!list3.Contains(consumptiveTaskInfo2.Id))
				{
					list3.Add(consumptiveTaskInfo2.Id);
				}
				cumulativeShopData2.TaskTabMap[taskTab2] = list3;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.CumulativeShopTaskRefresh, taskTab2);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}, 0);
	}

	// Token: 0x060080B0 RID: 32944 RVA: 0x0021FD68 File Offset: 0x0021DF68
	public CumulativeShopData GetCumulativeShopData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as CumulativeShopData;
	}

	// Token: 0x060080B1 RID: 32945 RVA: 0x0021FD80 File Offset: 0x0021DF80
	public void ConsumptiveTaskInfoNotify(ConsumptiveTaskInfoNotify massage, [Nullable(2)] Net.CallbackStatus status)
	{
		CumulativeShopData cumulativeShopData = this.GetCumulativeShopData();
		cumulativeShopData.TaskDataMap[massage.ConsumptiveTaskInfo.Id] = massage.ConsumptiveTaskInfo;
		int taskTab = ConfigBase<CumulativeShopConfig>.Instance.GetCumulativeShopTaskConfig(massage.ConsumptiveTaskInfo.Id).Value.TaskTab;
		List<int> list;
		if (!cumulativeShopData.TaskTabMap.TryGetValue(taskTab, out list) || list == null)
		{
			list = new List<int>();
		}
		if (!list.Contains(massage.ConsumptiveTaskInfo.Id))
		{
			list.Add(massage.ConsumptiveTaskInfo.Id);
		}
		cumulativeShopData.TaskTabMap[taskTab] = list;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.CumulativeShopTaskRefresh, taskTab);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
	}

	// Token: 0x060080B2 RID: 32946 RVA: 0x0021FE48 File Offset: 0x0021E048
	private void ConsumptiveTotalScoreNotify(ConsumptiveTotalScoreNotify massage, [Nullable(2)] Net.CallbackStatus status)
	{
		CumulativeShopData cumulativeShopData = this.GetCumulativeShopData();
		if (cumulativeShopData == null)
		{
			return;
		}
		cumulativeShopData.TotalScore = massage.TotalScore;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.ActivityId);
	}

	// Token: 0x060080B3 RID: 32947 RVA: 0x0021FE84 File Offset: 0x0021E084
	public void ConsumptiveActivityInfoRequest()
	{
		ConsumptiveActivityInfoRequest message = Aki.Protocol.ConsumptiveActivityInfoRequest.Create();
		Singleton<Net>.Instance.Call<ConsumptiveActivityInfoResponse>(ERequestMessageId.ConsumptiveActivityInfoRequest, message, delegate(ConsumptiveActivityInfoResponse response, [Nullable(2)] Net.CallbackStatus status)
		{
			CumulativeShopData cumulativeShopData = this.GetCumulativeShopData();
			cumulativeShopData.TaskDataMap.Clear();
			cumulativeShopData.TaskTabMap.Clear();
			RepeatedField<ConsumptiveTaskInfo> tasks = response.ConsumptiveActivityInfo.Tasks;
			int totalScore = response.ConsumptiveActivityInfo.TotalScore;
			cumulativeShopData.TotalScore = totalScore;
			foreach (ConsumptiveTaskInfo consumptiveTaskInfo in tasks)
			{
				cumulativeShopData.TaskDataMap[consumptiveTaskInfo.Id] = consumptiveTaskInfo;
				int taskTab = ConfigBase<CumulativeShopConfig>.Instance.GetCumulativeShopTaskConfig(consumptiveTaskInfo.Id).Value.TaskTab;
				List<int> list;
				if (!cumulativeShopData.TaskTabMap.TryGetValue(taskTab, out list) || list == null)
				{
					list = new List<int>();
				}
				list.Add(consumptiveTaskInfo.Id);
				cumulativeShopData.TaskTabMap[taskTab] = list;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.CumulativeShopTaskViewDataRefresh);
		}, 0);
	}

	// Token: 0x060080B4 RID: 32948 RVA: 0x0021FEB4 File Offset: 0x0021E0B4
	public void ConsumptiveActivityScoreRequest()
	{
		CumulativeShopData data = this.GetCumulativeShopData();
		if (data == null || data.ScoreRequesting)
		{
			return;
		}
		data.ScoreRequesting = true;
		ConsumptiveActivityScoreRequest consumptiveActivityScoreRequest = Aki.Protocol.ConsumptiveActivityScoreRequest.Create();
		consumptiveActivityScoreRequest.ActivityId = this.ActivityId;
		Singleton<Net>.Instance.Call<ConsumptiveActivityScoreResponse>(ERequestMessageId.ConsumptiveActivityScoreRequest, consumptiveActivityScoreRequest, delegate(ConsumptiveActivityScoreResponse response, [Nullable(2)] Net.CallbackStatus status)
		{
			data.ScoreRequesting = false;
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25510, null, true, true);
				return;
			}
			data.TotalScore = response.TotalScore;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.ActivityId);
		}, 0);
	}

	// Token: 0x04003D59 RID: 15705
	public int ActivityId;
}
