using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001417 RID: 5143
[NullableContext(1)]
[Nullable(0)]
public class RewardTargetTabView : UiTabViewBase
{
	// Token: 0x06008E8B RID: 36491 RVA: 0x00256F90 File Offset: 0x00255190
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06008E8C RID: 36492 RVA: 0x00257000 File Offset: 0x00255200
	protected override void OnStart()
	{
		object extraParams = this.ExtraParams;
		bool canAccomplishTask;
		if (extraParams is bool)
		{
			bool flag = (bool)extraParams;
			canAccomplishTask = flag;
		}
		else
		{
			canAccomplishTask = true;
		}
		this.CanAccomplishTask = canAccomplishTask;
		this.TabLayout = new GenericLayout<RewardTargetTabItem, RewardTabData>(base.GetHorizontalLayout(0), new Func<RewardTargetTabItem>(this.TabItemProxyCreate), null, false, true);
		this.LoopScroll = new LoopScrollView<TaskItem, TaskData>(base.GetLoopScrollViewComponent(2), (AUIBaseActor)base.GetItem(3).GetOwner(), new Func<TaskItem>(this.InitTargetItem), false);
	}

	// Token: 0x06008E8D RID: 36493 RVA: 0x00257080 File Offset: 0x00255280
	private List<RewardTabData> CreateTabItemDataList(IReadOnlyList<TrackMoonTargetType> tabList)
	{
		List<RewardTabData> list = new List<RewardTabData>();
		for (int i = 0; i < tabList.Count; i++)
		{
			RewardTabData rewardTabData = new RewardTabData();
			rewardTabData.NameTextId = tabList[i].Name;
			rewardTabData.Index = i;
			rewardTabData.ClickedCallback = new Action<int>(this.TabCallBack);
			rewardTabData.RefreshRedDot = ((int tabIndex) => ModelBase<MoonChasingRewardModel>.Instance.GetTaskDataRedDotStateByTabId(tabIndex));
			list.Add(rewardTabData);
		}
		return list;
	}

	// Token: 0x06008E8E RID: 36494 RVA: 0x00257108 File Offset: 0x00255308
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		RewardTargetTabView.<OnBeforeShowAsyncImplement>d__8 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<RewardTargetTabView.<OnBeforeShowAsyncImplement>d__8>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008E8F RID: 36495 RVA: 0x0025714C File Offset: 0x0025534C
	protected override void OnBeforeShow()
	{
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
	}

	// Token: 0x06008E90 RID: 36496 RVA: 0x00257186 File Offset: 0x00255386
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TakenRewardTargetData, new Action<int>(this.TakenRewardTargetData));
	}

	// Token: 0x06008E91 RID: 36497 RVA: 0x002571A4 File Offset: 0x002553A4
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TakenRewardTargetData, new Action<int>(this.TakenRewardTargetData));
	}

	// Token: 0x06008E92 RID: 36498 RVA: 0x002571C4 File Offset: 0x002553C4
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIItem grid = this.LoopScroll.GetGrid(0);
		if (grid == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			grid,
			grid
		};
	}

	// Token: 0x06008E93 RID: 36499 RVA: 0x002571F1 File Offset: 0x002553F1
	private void TakenRewardTargetData(int id)
	{
		if (ModelBase<MoonChasingRewardModel>.Instance.GetTaskDataById(id) == null)
		{
			return;
		}
		this.TabLayout.GetLayoutItemByIndex(this.CurrentTabIndex).RefreshRedDot();
		this.RefreshLoopScrollView(this.CurrentTabIndex);
	}

	// Token: 0x06008E94 RID: 36500 RVA: 0x00257223 File Offset: 0x00255423
	private TaskItem InitTargetItem()
	{
		return new TaskItem();
	}

	// Token: 0x06008E95 RID: 36501 RVA: 0x0025722A File Offset: 0x0025542A
	private RewardTargetTabItem TabItemProxyCreate()
	{
		return new RewardTargetTabItem();
	}

	// Token: 0x06008E96 RID: 36502 RVA: 0x00257234 File Offset: 0x00255434
	private void TabCallBack(int index)
	{
		if (this.CurrentTabIndex != index && this.CurrentTabIndex != -1)
		{
			RewardTargetTabItem layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex(this.CurrentTabIndex);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetToggleState(false, false);
			}
		}
		this.CurrentTabIndex = index;
		this.RefreshLoopScrollView(this.CurrentTabIndex);
	}

	// Token: 0x06008E97 RID: 36503 RVA: 0x00257284 File Offset: 0x00255484
	private void RefreshLoopScrollView(int tabIndex)
	{
		this.DataList.Clear();
		List<TaskData> taskDataByTabId = ModelBase<MoonChasingRewardModel>.Instance.GetTaskDataByTabId(tabIndex + 1);
		taskDataByTabId.Sort(new Comparison<TaskData>(ModelBase<MoonChasingRewardModel>.Instance.SortTaskData));
		if (!this.CanAccomplishTask)
		{
			using (List<TaskData>.Enumerator enumerator = taskDataByTabId.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TaskData taskData = enumerator.Current;
					TaskData taskData2 = taskData.DeepCopy(taskData);
					taskData2.JumpId = 0;
					taskData2.DoingTextId = "Moonfiesta_TargetDone";
					this.DataList.Add(taskData2);
				}
				goto IL_8C;
			}
		}
		this.DataList = taskDataByTabId;
		IL_8C:
		this.LoopScroll.RefreshByDataAsync(this.DataList, false, true).Forget();
	}

	// Token: 0x04004266 RID: 16998
	protected GenericLayout<RewardTargetTabItem, RewardTabData> TabLayout;

	// Token: 0x04004267 RID: 16999
	private int CurrentTabIndex = -1;

	// Token: 0x04004268 RID: 17000
	protected LoopScrollView<TaskItem, TaskData> LoopScroll;

	// Token: 0x04004269 RID: 17001
	private List<TaskData> DataList = new List<TaskData>();

	// Token: 0x0400426A RID: 17002
	private bool CanAccomplishTask = true;

	// Token: 0x0200780A RID: 30730
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040294AA RID: 169130
		public const int TabRootItem = 0;

		// Token: 0x040294AB RID: 169131
		public const int TabItem = 1;

		// Token: 0x040294AC RID: 169132
		public const int Scroll = 2;

		// Token: 0x040294AD RID: 169133
		public const int TargetItem = 3;
	}
}
