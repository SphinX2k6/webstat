using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200238D RID: 9101
[NullableContext(1)]
[Nullable(0)]
public class BattlePassTaskView : UiTabViewBase
{
	// Token: 0x06011706 RID: 71430 RVA: 0x004CE804 File Offset: 0x004CCA04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011707 RID: 71431 RVA: 0x004CE8B0 File Offset: 0x004CCAB0
	private UniTask InitBattlePassBackgroundPanel()
	{
		BattlePassTaskView.<InitBattlePassBackgroundPanel>d__8 <InitBattlePassBackgroundPanel>d__;
		<InitBattlePassBackgroundPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBattlePassBackgroundPanel>d__.<>4__this = this;
		<InitBattlePassBackgroundPanel>d__.<>1__state = -1;
		<InitBattlePassBackgroundPanel>d__.<>t__builder.Start<BattlePassTaskView.<InitBattlePassBackgroundPanel>d__8>(ref <InitBattlePassBackgroundPanel>d__);
		return <InitBattlePassBackgroundPanel>d__.<>t__builder.Task;
	}

	// Token: 0x06011708 RID: 71432 RVA: 0x004CE8F4 File Offset: 0x004CCAF4
	private UniTask InitTaskLoopView()
	{
		BattlePassTaskView.<InitTaskLoopView>d__9 <InitTaskLoopView>d__;
		<InitTaskLoopView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTaskLoopView>d__.<>4__this = this;
		<InitTaskLoopView>d__.<>1__state = -1;
		<InitTaskLoopView>d__.<>t__builder.Start<BattlePassTaskView.<InitTaskLoopView>d__9>(ref <InitTaskLoopView>d__);
		return <InitTaskLoopView>d__.<>t__builder.Task;
	}

	// Token: 0x06011709 RID: 71433 RVA: 0x004CE938 File Offset: 0x004CCB38
	protected override UniTask OnBeforeStartAsync()
	{
		BattlePassTaskView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BattlePassTaskView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601170A RID: 71434 RVA: 0x004CE97C File Offset: 0x004CCB7C
	protected override void OnAfterShow()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlaySequence("Switch", false, null);
		}
		this.RefreshTaskData();
	}

	// Token: 0x0601170B RID: 71435 RVA: 0x004CE9B0 File Offset: 0x004CCBB0
	public void SelectToggleByIndex(int index, bool bIgnored = false)
	{
		if (bIgnored)
		{
			BattlePassTaskTabItem layoutItemByIndex = this.TypeLayout.GetLayoutItemByIndex(this.CurrentIndex);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetForceSwitch(EToggleState.ETT_UnChecked, false);
			}
			this.CurrentIndex = -1;
		}
		BattlePassTaskTabItem layoutItemByIndex2 = this.TypeLayout.GetLayoutItemByIndex(index);
		if (layoutItemByIndex2 != null)
		{
			layoutItemByIndex2.SetForceSwitch(EToggleState.ETT_Checked, true);
		}
	}

	// Token: 0x0601170C RID: 71436 RVA: 0x004CE9FC File Offset: 0x004CCBFC
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBattlePassTaskEvent, new Action(this.OnReceiveBattlePassTaskUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskData));
	}

	// Token: 0x0601170D RID: 71437 RVA: 0x004CEA36 File Offset: 0x004CCC36
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateBattlePassTaskEvent, new Action(this.OnReceiveBattlePassTaskUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveBattlePassTaskEvent, new Action<bool>(this.OnReceiveBattlePassTaskData));
	}

	// Token: 0x0601170E RID: 71438 RVA: 0x004CEA70 File Offset: 0x004CCC70
	private void OnReceiveBattlePassTaskUpdate()
	{
		this.RefreshTaskData();
	}

	// Token: 0x0601170F RID: 71439 RVA: 0x004CEA78 File Offset: 0x004CCC78
	private void OnReceiveBattlePassTaskData(bool isWeekUpdate)
	{
		if (this.CurrentIndex == -1)
		{
			return;
		}
		if (this.TypeList[this.CurrentIndex] == EBattlePassTaskUpdateState.EveryDay || (this.TypeList[this.CurrentIndex] == EBattlePassTaskUpdateState.EveryWeek && isWeekUpdate))
		{
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(new ConfirmBoxDataNew(EConfirmBoxConfigId.BattlePassTaskExpire));
		}
		this.RefreshTaskData();
	}

	// Token: 0x06011710 RID: 71440 RVA: 0x004CEAD6 File Offset: 0x004CCCD6
	private BattlePassTaskLoopItem CreateLoopItem()
	{
		return new BattlePassTaskLoopItem();
	}

	// Token: 0x06011711 RID: 71441 RVA: 0x004CEADD File Offset: 0x004CCCDD
	private BattlePassTaskTabItem InitDetail()
	{
		BattlePassTaskTabItem battlePassTaskTabItem = new BattlePassTaskTabItem();
		battlePassTaskTabItem.SetSelectedCallBack(new Action<int>(this.OnClickTypeToggle));
		battlePassTaskTabItem.SetCanExecuteChange(new Func<int, bool>(this.OnCanExecuteChange));
		return battlePassTaskTabItem;
	}

	// Token: 0x06011712 RID: 71442 RVA: 0x004CEB08 File Offset: 0x004CCD08
	private void OnClickTypeToggle(int index)
	{
		if (index == this.CurrentIndex)
		{
			return;
		}
		int currentIndex = this.CurrentIndex;
		this.CurrentIndex = index;
		if (currentIndex != -1)
		{
			BattlePassTaskTabItem layoutItemByIndex = this.TypeLayout.GetLayoutItemByIndex(currentIndex);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetForceSwitch(EToggleState.ETT_UnChecked, false);
			}
		}
		this.RefreshTaskData();
	}

	// Token: 0x06011713 RID: 71443 RVA: 0x004CEB4F File Offset: 0x004CCD4F
	private bool OnCanExecuteChange(int index)
	{
		return this.CurrentIndex != index;
	}

	// Token: 0x06011714 RID: 71444 RVA: 0x004CEB60 File Offset: 0x004CCD60
	private void RefreshTaskData()
	{
		if (this.CurrentIndex == -1)
		{
			return;
		}
		ModelBase<BattlePassModel>.Instance.GetTaskList(this.TypeList[this.CurrentIndex], this.TaskList);
		this.TaskLoopView.RefreshByData(this.TaskList, false, null, true);
	}

	// Token: 0x06011715 RID: 71445 RVA: 0x004CEBAC File Offset: 0x004CCDAC
	protected override void OnBeforeDestroy()
	{
		if (this.TaskLoopView != null)
		{
			this.TaskLoopView.ClearGridProxies();
			this.TaskLoopView = null;
		}
		this.TaskList = new List<BattlePassTaskData>();
	}

	// Token: 0x040088E8 RID: 35048
	private int CurrentIndex = -1;

	// Token: 0x040088E9 RID: 35049
	[Nullable(2)]
	private BattlePassBackgroundPanel BackgroundPanel;

	// Token: 0x040088EA RID: 35050
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<BattlePassTaskTabItem, EBattlePassTaskUpdateState> TypeLayout;

	// Token: 0x040088EB RID: 35051
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BattlePassTaskLoopItem, BattlePassTaskData> TaskLoopView;

	// Token: 0x040088EC RID: 35052
	private List<BattlePassTaskData> TaskList = new List<BattlePassTaskData>();

	// Token: 0x040088ED RID: 35053
	private readonly List<EBattlePassTaskUpdateState> TypeList = new List<EBattlePassTaskUpdateState>
	{
		EBattlePassTaskUpdateState.EveryDay,
		EBattlePassTaskUpdateState.EveryWeek,
		EBattlePassTaskUpdateState.Always
	};

	// Token: 0x020086A7 RID: 34471
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402D8B7 RID: 186551
		BattlePassBackground,
		// Token: 0x0402D8B8 RID: 186552
		TypeLayout,
		// Token: 0x0402D8B9 RID: 186553
		TaskLoop,
		// Token: 0x0402D8BA RID: 186554
		TaskItem
	}
}
