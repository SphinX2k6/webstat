using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B52 RID: 11090
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueRewardView : UiTickViewBase
{
	// Token: 0x060161E0 RID: 90592 RVA: 0x00623596 File Offset: 0x00621796
	public SurvivorsRogueRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060161E1 RID: 90593 RVA: 0x006235B4 File Offset: 0x006217B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnCardDetailBtnClick))
		};
	}

	// Token: 0x060161E2 RID: 90594 RVA: 0x006236A0 File Offset: 0x006218A0
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueRewardView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueRewardView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060161E3 RID: 90595 RVA: 0x006236E3 File Offset: 0x006218E3
	protected override void OnBeforeShow()
	{
		ControllerBase<SurvivorsActivityController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x060161E4 RID: 90596 RVA: 0x006236EF File Offset: 0x006218EF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshView));
	}

	// Token: 0x060161E5 RID: 90597 RVA: 0x0062370D File Offset: 0x0062190D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshView));
	}

	// Token: 0x060161E6 RID: 90598 RVA: 0x0062372C File Offset: 0x0062192C
	private void OnRefreshView(int activityId)
	{
		if (this.ActivityDataBase.Id != activityId)
		{
			return;
		}
		List<SurvivorsRewardTabItem> layoutItemList = this.TabLayout.GetLayoutItemList();
		for (int i = 0; i < layoutItemList.Count; i++)
		{
			layoutItemList[i].RefreshRedDot();
		}
		this.RefreshTaskLayout();
		this.RefreshProgressItem();
	}

	// Token: 0x060161E7 RID: 90599 RVA: 0x0062377D File Offset: 0x0062197D
	private SurvivorsRewardTabItem CreateTabItem()
	{
		return new SurvivorsRewardTabItem();
	}

	// Token: 0x060161E8 RID: 90600 RVA: 0x00623784 File Offset: 0x00621984
	private void OnTabClickCallBack(SurvivorRewardTaskTabData data)
	{
		if (this.CurTaskTabTypeId != data.Type && this.CurTaskTabTypeId != -1)
		{
			SurvivorsRewardTabItem layoutItemByKey = this.TabLayout.GetLayoutItemByKey(this.CurTaskTabTypeId);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.SetToggleState(false, false);
			}
		}
		this.TabLayout.SelectGridProxy(data.Index, false);
		this.CurTaskTabTypeId = data.Type;
		this.RefreshTaskLayout();
	}

	// Token: 0x060161E9 RID: 90601 RVA: 0x006237EF File Offset: 0x006219EF
	private bool GetTabRedDotState(SurvivorRewardTaskTabData data)
	{
		return this.ActivityDataBase.GetTypeRedDotState(data.Type);
	}

	// Token: 0x060161EA RID: 90602 RVA: 0x00623804 File Offset: 0x00621A04
	private IReadOnlyList<SurvivorRewardTaskTabData> GetTaskTabList()
	{
		List<SurvivorRewardTaskTabData> list = new List<SurvivorRewardTaskTabData>();
		List<int> list2 = new List<int>(this.ActivityDataBase.RewardType2TaskIdList.Keys);
		list2.Sort((int a, int b) => a - b);
		SurvivorsActivityConfig value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsActivityConfigByActivityId(this.ActivityDataBase.Id).Value;
		int num = 0;
		for (int i = 0; i < list2.Count; i++)
		{
			int num2 = list2[i];
			string nameTextId = null;
			for (int j = 0; j < value.TaskTypeLength; j++)
			{
				DicIntString? dicIntString = value.TaskType(j);
				if (dicIntString != null && dicIntString.Value.Key == num2)
				{
					nameTextId = dicIntString.Value.Value;
					break;
				}
			}
			SurvivorRewardTaskTabData item = new SurvivorRewardTaskTabData
			{
				Type = num2,
				Index = num,
				NameTextId = nameTextId,
				ClickedCallback = new Action<SurvivorRewardTaskTabData>(this.OnTabClickCallBack),
				RefreshRedDot = new Func<SurvivorRewardTaskTabData, bool>(this.GetTabRedDotState)
			};
			list.Add(item);
			num++;
		}
		return list;
	}

	// Token: 0x060161EB RID: 90603 RVA: 0x0062393C File Offset: 0x00621B3C
	private SurvivorsRewardTaskItem CreateTaskItem()
	{
		return new SurvivorsRewardTaskItem
		{
			OnGetBtnClick = new Action(this.OnTaskClickCallBack)
		};
	}

	// Token: 0x060161EC RID: 90604 RVA: 0x00623958 File Offset: 0x00621B58
	private void RefreshTaskLayout()
	{
		List<ActivityTaskData> rewardTaskDataListByTypeId = this.ActivityDataBase.GetRewardTaskDataListByTypeId(this.CurTaskTabTypeId);
		this.TaskLayout.RefreshByData(rewardTaskDataListByTypeId, delegate
		{
			this.TaskLayout.ScrollToTopByIndex(0);
		}, true);
	}

	// Token: 0x060161ED RID: 90605 RVA: 0x00623990 File Offset: 0x00621B90
	private void OnTaskClickCallBack()
	{
		List<int> availableGetTaskRewardIdsByType = this.ActivityDataBase.GetAvailableGetTaskRewardIdsByType(this.CurTaskTabTypeId);
		if (availableGetTaskRewardIdsByType.Count > 0)
		{
			ControllerBase<SurvivorsActivityController>.Instance.RequestGetRewardTask(availableGetTaskRewardIdsByType.ToArray());
		}
	}

	// Token: 0x060161EE RID: 90606 RVA: 0x006239C8 File Offset: 0x00621BC8
	private void RefreshProgressItem()
	{
		SurvivorsRogueRewardView.<>c__DisplayClass20_0 CS$<>8__locals1 = new SurvivorsRogueRewardView.<>c__DisplayClass20_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.dataList = this.ActivityDataBase.GetAllMilestoneReward();
		CS$<>8__locals1.currentCount = this.ActivityDataBase.GetMilestoneItemCount();
		UiAsyncTask task = new UiAsyncTask("SurvivorsRogueRewardView.RefreshProgressItem", delegate()
		{
			SurvivorsRogueRewardView.<>c__DisplayClass20_0.<<RefreshProgressItem>b__0>d <<RefreshProgressItem>b__0>d;
			<<RefreshProgressItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshProgressItem>b__0>d.<>4__this = CS$<>8__locals1;
			<<RefreshProgressItem>b__0>d.<>1__state = -1;
			<<RefreshProgressItem>b__0>d.<>t__builder.Start<SurvivorsRogueRewardView.<>c__DisplayClass20_0.<<RefreshProgressItem>b__0>d>(ref <<RefreshProgressItem>b__0>d);
			return <<RefreshProgressItem>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x060161EF RID: 90607 RVA: 0x00623A24 File Offset: 0x00621C24
	private void OnClickGetProgressReward()
	{
		List<int> allAvailableGetMilestoneRewardIds = this.ActivityDataBase.GetAllAvailableGetMilestoneRewardIds();
		if (allAvailableGetMilestoneRewardIds.Count > 0)
		{
			ControllerBase<SurvivorsActivityController>.Instance.RequestGetRewardScore(allAvailableGetMilestoneRewardIds.ToArray());
		}
	}

	// Token: 0x060161F0 RID: 90608 RVA: 0x00623A56 File Offset: 0x00621C56
	protected override void OnTick(float delta)
	{
		this.RefreshTimeText();
	}

	// Token: 0x060161F1 RID: 90609 RVA: 0x00623A60 File Offset: 0x00621C60
	private void RefreshTimeText()
	{
		if (this.ActivityDataBase == null || !this.ActivityDataBase.CheckIfInOpenTime())
		{
			return;
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityDataBase.EndOpenTime, this.RemainTimeText);
		UUIText text = base.GetText(7);
		if (text == null)
		{
			return;
		}
		text.SetText(remainTimeText, true);
	}

	// Token: 0x060161F2 RID: 90610 RVA: 0x00623AB4 File Offset: 0x00621CB4
	private void OnCardDetailBtnClick()
	{
		SurvivorsActivityConfig? survivorsActivityConfig;
		int? num = (ModelBase<SurvivorsRogueModel>.Instance.GetRogueActivityConfig() != null) ? new int?(survivorsActivityConfig.GetValueOrDefault().TaskDisplayItemId) : null;
		if (num != null)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(num.Value, true, null);
		}
	}

	// Token: 0x060161F3 RID: 90611 RVA: 0x00623B11 File Offset: 0x00621D11
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400AAA6 RID: 43686
	[Nullable(2)]
	protected SurvivorsActivityData ActivityDataBase;

	// Token: 0x0400AAA7 RID: 43687
	private int CurTaskTabTypeId = -1;

	// Token: 0x0400AAA8 RID: 43688
	private GenericLayout<SurvivorsRewardTabItem, SurvivorRewardTaskTabData> TabLayout;

	// Token: 0x0400AAA9 RID: 43689
	private GenericScrollViewNew<SurvivorsRewardTaskItem, ActivityTaskData> TaskLayout;

	// Token: 0x0400AAAA RID: 43690
	private SurvivorsScoreProgressPanel ProgressItem;

	// Token: 0x0400AAAB RID: 43691
	private string RemainTimeText = string.Empty;
}
