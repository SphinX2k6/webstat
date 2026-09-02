using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001308 RID: 4872
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyTaskView : DangoMonopolyViewBase
{
	// Token: 0x17000B2A RID: 2858
	// (get) Token: 0x06008487 RID: 33927 RVA: 0x0022F7F8 File Offset: 0x0022D9F8
	[Nullable(2)]
	public new DangoMonopolyTaskViewParam OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as DangoMonopolyTaskViewParam;
		}
	}

	// Token: 0x06008488 RID: 33928 RVA: 0x0022F805 File Offset: 0x0022DA05
	public DangoMonopolyTaskView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008489 RID: 33929 RVA: 0x0022F810 File Offset: 0x0022DA10
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickClose))
		};
	}

	// Token: 0x0600848A RID: 33930 RVA: 0x0022F913 File Offset: 0x0022DB13
	private void InitDataParam()
	{
	}

	// Token: 0x0600848B RID: 33931 RVA: 0x0022F918 File Offset: 0x0022DB18
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyTaskView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyTaskView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600848C RID: 33932 RVA: 0x0022F95B File Offset: 0x0022DB5B
	protected override void OnStart()
	{
		UUIText text = base.GetText(6);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew("DangoMonopoly_title_4");
	}

	// Token: 0x0600848D RID: 33933 RVA: 0x0022F973 File Offset: 0x0022DB73
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EDangoMonopolyTaskUpdateType>(EEventName.DangoMonopolyTaskUpdate, new Action<EDangoMonopolyTaskUpdateType>(this.EventDangoMonopolyTaskUpdate));
	}

	// Token: 0x0600848E RID: 33934 RVA: 0x0022F991 File Offset: 0x0022DB91
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DangoMonopolyTaskUpdate, new Action<EDangoMonopolyTaskUpdateType>(this.EventDangoMonopolyTaskUpdate));
	}

	// Token: 0x0600848F RID: 33935 RVA: 0x0022F9B0 File Offset: 0x0022DBB0
	protected override void OnBeforeShow()
	{
		this.TabFinish();
		if (this.IsShowRemainTime)
		{
			int num = 200;
			this.RefreshTimerHandle = TimerSystem.RealTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)num, 1f, null, null, true);
		}
	}

	// Token: 0x06008490 RID: 33936 RVA: 0x0022F9F7 File Offset: 0x0022DBF7
	protected override void OnAfterHide()
	{
		this.ClearTimer();
	}

	// Token: 0x06008491 RID: 33937 RVA: 0x0022FA00 File Offset: 0x0022DC00
	private void TabFinish()
	{
		Dictionary<int, ShipTowerTeamTabItem> tabItemMap = this.TabComponent.GetTabItemMap();
		DangoMonopolyTaskViewParam openParam = this.OpenParam;
		List<IDangoMonopolyTaskTabData> list = ((openParam != null) ? openParam.TaskList : null) ?? new List<IDangoMonopolyTaskTabData>();
		foreach (KeyValuePair<int, ShipTowerTeamTabItem> keyValuePair in tabItemMap)
		{
			int key = keyValuePair.Key;
			ShipTowerTeamTabItem value = keyValuePair.Value;
			if (key < list.Count)
			{
				value.UpdateNameText(list[key].TaskTypeName);
				value.UpdateRedDotVisible(this.GetTaskListRedDotState(key));
			}
		}
		this.TabComponent.SelectToggleByIndex(this.GetJumpTabIndex(), true, true);
	}

	// Token: 0x06008492 RID: 33938 RVA: 0x0022FABC File Offset: 0x0022DCBC
	public void UpdateTabRedDotState()
	{
		Dictionary<int, ShipTowerTeamTabItem> tabItemMap = this.TabComponent.GetTabItemMap();
		DangoMonopolyTaskViewParam openParam = this.OpenParam;
		List<IDangoMonopolyTaskTabData> list = ((openParam != null) ? openParam.TaskList : null) ?? new List<IDangoMonopolyTaskTabData>();
		foreach (KeyValuePair<int, ShipTowerTeamTabItem> keyValuePair in tabItemMap)
		{
			int key = keyValuePair.Key;
			ShipTowerTeamTabItem value = keyValuePair.Value;
			if (key < list.Count)
			{
				value.UpdateRedDotVisible(this.GetTaskListRedDotState(key));
			}
		}
	}

	// Token: 0x06008493 RID: 33939 RVA: 0x0022FB54 File Offset: 0x0022DD54
	public bool GetTaskListRedDotState(int index)
	{
		DangoMonopolyTaskViewParam openParam = this.OpenParam;
		List<IDangoMonopolyTaskTabData> list = ((openParam != null) ? openParam.TaskList : null) ?? new List<IDangoMonopolyTaskTabData>();
		if (index >= list.Count)
		{
			return false;
		}
		foreach (DangoMonopolyTaskData dangoMonopolyTaskData in list[index].TaskList)
		{
			if (dangoMonopolyTaskData.IsCanReceive() || !this.ActivityData.TaskLookedSet.Contains(dangoMonopolyTaskData.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06008494 RID: 33940 RVA: 0x0022FBF0 File Offset: 0x0022DDF0
	public void UpdateTabRedDotStateByIndex(int index)
	{
		ShipTowerTeamTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		DangoMonopolyTaskViewParam openParam = this.OpenParam;
		List<IDangoMonopolyTaskTabData> list = ((openParam != null) ? openParam.TaskList : null) ?? new List<IDangoMonopolyTaskTabData>();
		if (tabItemByIndex != null && index < list.Count)
		{
			using (IEnumerator<DangoMonopolyTaskData> enumerator = list[index].TaskList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsCanReceive())
					{
						tabItemByIndex.UpdateRedDotVisible(true);
						return;
					}
				}
			}
			tabItemByIndex.UpdateRedDotVisible(false);
		}
	}

	// Token: 0x06008495 RID: 33941 RVA: 0x0022FC88 File Offset: 0x0022DE88
	private int GetJumpTabIndex()
	{
		if (this.OpenParam == null)
		{
			return 0;
		}
		int valueOrDefault = this.OpenParam.TaskId.GetValueOrDefault();
		ActivityDangoMonopolyData activityData = this.ActivityData;
		DangoMonopolyTaskData dangoMonopolyTaskData;
		if (activityData != null && activityData.TaskIdMap.TryGetValue(valueOrDefault, out dangoMonopolyTaskData) && dangoMonopolyTaskData != null)
		{
			EDangoMonopolyTaskType taskType = dangoMonopolyTaskData.TaskType;
			List<IDangoMonopolyTaskTabData> taskList = this.OpenParam.TaskList;
			for (int i = 0; i < taskList.Count; i++)
			{
				if (taskList[i].TaskType == taskType)
				{
					return Math.Max(i, 0);
				}
			}
		}
		List<IDangoMonopolyTaskTabData> taskList2 = this.OpenParam.TaskList;
		for (int j = 0; j < taskList2.Count; j++)
		{
			using (IEnumerator<DangoMonopolyTaskData> enumerator = taskList2[j].TaskList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsCanReceive())
					{
						return Math.Max(j, 0);
					}
				}
			}
		}
		return 0;
	}

	// Token: 0x06008496 RID: 33942 RVA: 0x0022FD90 File Offset: 0x0022DF90
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x06008497 RID: 33943 RVA: 0x0022FD92 File Offset: 0x0022DF92
	private ShipTowerTeamTabItem TabItemProxyCreate([Nullable(2)] UUIItem _1, int? _2)
	{
		return new ShipTowerTeamTabItem();
	}

	// Token: 0x06008498 RID: 33944 RVA: 0x0022FD9C File Offset: 0x0022DF9C
	private void ToggleTwoTabCallBack(int index)
	{
		this.CurSelectTabIndex = index;
		DangoMonopolyTaskViewParam openParam = this.OpenParam;
		List<IDangoMonopolyTaskTabData> list = ((openParam != null) ? openParam.TaskList : null) ?? new List<IDangoMonopolyTaskTabData>();
		if (index < list.Count)
		{
			IDangoMonopolyTaskTabData data = list[index];
			this.UpdateTaskInfo(data);
		}
	}

	// Token: 0x06008499 RID: 33945 RVA: 0x0022FDE4 File Offset: 0x0022DFE4
	private void UpdateTaskInfo(IDangoMonopolyTaskTabData data)
	{
		GenericLayout<DangoMonopolyTaskItem, DangoMonopolyTaskData> rewardScrollView = this.RewardScrollView;
		if (rewardScrollView != null)
		{
			rewardScrollView.RefreshByData(data.TaskList.ToList<DangoMonopolyTaskData>(), null, true);
		}
		this.UpdateRemainTimeInfo(data);
		List<int> list = new List<int>();
		foreach (DangoMonopolyTaskData dangoMonopolyTaskData in data.TaskList)
		{
			list.Add(dangoMonopolyTaskData.Id);
		}
		ActivityDangoMonopolyData activityData = this.ActivityData;
		if (activityData != null && activityData.AddNewTaskIdList(list))
		{
			this.UpdateTabRedDotStateByIndex(this.CurSelectTabIndex);
		}
	}

	// Token: 0x0600849A RID: 33946 RVA: 0x0022FE84 File Offset: 0x0022E084
	public void UpdateRemainTimeInfo(IDangoMonopolyTaskTabData data)
	{
		UUIText text = base.GetText(4);
		if (this.IsShowRemainTime)
		{
			this.EndTime = data.EndTime;
			if (text != null)
			{
				text.SetUIActive(this.EndTime > 0L);
			}
			this.OnTimerRefresh(0f);
			return;
		}
		EDangoMonopolyTaskType taskType = data.TaskType;
		if (taskType != EDangoMonopolyTaskType.DailyTask)
		{
			if (taskType != EDangoMonopolyTaskType.WeeklyTask)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
			else
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				if (text != null)
				{
					text.ShowTextNew("DangoMonopoly_title_23");
					return;
				}
			}
		}
		else
		{
			if (text != null)
			{
				text.SetUIActive(true);
			}
			if (text != null)
			{
				text.ShowTextNew("DangoMonopoly_title_22");
				return;
			}
		}
	}

	// Token: 0x0600849B RID: 33947 RVA: 0x0022FF18 File Offset: 0x0022E118
	private DangoMonopolyTaskItem CreateRewardItem()
	{
		return new DangoMonopolyTaskItem
		{
			ClickCallBack = new Action<DangoMonopolyTaskData>(this.OnClickReceive)
		};
	}

	// Token: 0x0600849C RID: 33948 RVA: 0x0022FF31 File Offset: 0x0022E131
	private void OnClickReceive(DangoMonopolyTaskData data)
	{
		ActivityDangoMonopolyData activityData = this.ActivityData;
		if (activityData == null)
		{
			return;
		}
		activityData.RequestReceiveTask(data.Id, false);
	}

	// Token: 0x0600849D RID: 33949 RVA: 0x0022FF4A File Offset: 0x0022E14A
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600849E RID: 33950 RVA: 0x0022FF53 File Offset: 0x0022E153
	private void EventDangoMonopolyTaskUpdate(EDangoMonopolyTaskUpdateType updateType)
	{
		if (updateType != EDangoMonopolyTaskUpdateType.Update)
		{
			if (updateType - EDangoMonopolyTaskUpdateType.Add <= 1)
			{
				this.ShowTipClose();
			}
		}
		else
		{
			this.ToggleTwoTabCallBack(this.CurSelectTabIndex);
		}
		this.UpdateTabRedDotState();
	}

	// Token: 0x0600849F RID: 33951 RVA: 0x0022FF7C File Offset: 0x0022E17C
	public void ShowTipClose()
	{
		if (this.IsNeedClose)
		{
			return;
		}
		this.IsNeedClose = true;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BattlePassTaskExpire);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			base.CloseMe(null);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x060084A0 RID: 33952 RVA: 0x0022FFD0 File Offset: 0x0022E1D0
	private void OnTimerRefresh(float _)
	{
		if (this.EndTime > 0L)
		{
			double remainTime = Math.Max((double)this.EndTime - Singleton<TimeUtil>.Instance.GetServerTime(), 0.0);
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime);
			UUIText text = base.GetText(4);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "DangoMonopoly_title_20", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
		}
	}

	// Token: 0x060084A1 RID: 33953 RVA: 0x00230037 File Offset: 0x0022E237
	private void ClearTimer()
	{
		if (this.RefreshTimerHandle != null && TimerSystem.RealTimeInstance.Has(this.RefreshTimerHandle))
		{
			TimerSystem.RealTimeInstance.Remove(this.RefreshTimerHandle);
			this.RefreshTimerHandle = null;
		}
	}

	// Token: 0x04003EE3 RID: 16099
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<ShipTowerTeamTabItem> TabComponent;

	// Token: 0x04003EE4 RID: 16100
	private int CurSelectTabIndex;

	// Token: 0x04003EE5 RID: 16101
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DangoMonopolyTaskItem, DangoMonopolyTaskData> RewardScrollView;

	// Token: 0x04003EE6 RID: 16102
	[Nullable(2)]
	private TimerHandle RefreshTimerHandle;

	// Token: 0x04003EE7 RID: 16103
	private long EndTime;

	// Token: 0x04003EE8 RID: 16104
	public bool IsNeedClose;

	// Token: 0x04003EE9 RID: 16105
	[Nullable(2)]
	public CommonCurrencyItemListComponent CurrencyItemListComponent;

	// Token: 0x04003EEA RID: 16106
	public bool IsShowRemainTime;

	// Token: 0x020076B3 RID: 30387
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028E46 RID: 167494
		BtnClose,
		// Token: 0x04028E47 RID: 167495
		ItemTabComponent,
		// Token: 0x04028E48 RID: 167496
		VLayoutReward,
		// Token: 0x04028E49 RID: 167497
		ItemReward,
		// Token: 0x04028E4A RID: 167498
		TxtCountDown,
		// Token: 0x04028E4B RID: 167499
		BtnEmpty,
		// Token: 0x04028E4C RID: 167500
		TxtTitle,
		// Token: 0x04028E4D RID: 167501
		CostContent
	}
}
