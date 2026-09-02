using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012BF RID: 4799
[NullableContext(1)]
[Nullable(0)]
public class CumulativeShopTaskView : UiViewBase
{
	// Token: 0x060080DF RID: 32991 RVA: 0x00220F55 File Offset: 0x0021F155
	public CumulativeShopTaskView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060080E0 RID: 32992 RVA: 0x00220F60 File Offset: 0x0021F160
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x060080E1 RID: 32993 RVA: 0x00220FD0 File Offset: 0x0021F1D0
	protected override UniTask OnBeforeStartAsync()
	{
		CumulativeShopTaskView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CumulativeShopTaskView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060080E2 RID: 32994 RVA: 0x00221014 File Offset: 0x0021F214
	protected override void OnStart()
	{
		this.TabScrollView = new GenericScrollViewNew<CumulativeShopTaskTabItem, int>(base.GetScrollViewWithScrollbar(4), new Func<CumulativeShopTaskTabItem>(this.InitTabItem), null, false, null);
		this.TaskLoopScrollView = new LoopScrollView<CumulativeShopTaskItem, int>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<CumulativeShopTaskItem>(this.InitTaskItem), false);
		this.CaptionItem.SetTitleLocalText("Activity_105100001_QuestList_Desc");
	}

	// Token: 0x060080E3 RID: 32995 RVA: 0x00221082 File Offset: 0x0021F282
	protected override void OnBeforeShow()
	{
		ControllerBase<CumulativeShopController>.Instance.ConsumptiveActivityInfoRequest();
	}

	// Token: 0x060080E4 RID: 32996 RVA: 0x00221090 File Offset: 0x0021F290
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CumulativeShopTaskRefresh, new Action<int>(this.OnCumulativeShopTaskRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.CumulativeShopTaskViewDataRefresh, new Action(this.CumulativeShopTaskViewDataRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivityUpdate, new Action(this.OnActivityUpdate));
	}

	// Token: 0x060080E5 RID: 32997 RVA: 0x002210F4 File Offset: 0x0021F2F4
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CumulativeShopTaskRefresh, new Action<int>(this.OnCumulativeShopTaskRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.CumulativeShopTaskViewDataRefresh, new Action(this.CumulativeShopTaskViewDataRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityUpdate, new Action(this.OnActivityUpdate));
	}

	// Token: 0x060080E6 RID: 32998 RVA: 0x00221155 File Offset: 0x0021F355
	private CumulativeShopTaskTabItem InitTabItem()
	{
		return new CumulativeShopTaskTabItem
		{
			OnClickBack = new Action<int, UUIExtendToggle>(this.OnClickTabBack)
		};
	}

	// Token: 0x060080E7 RID: 32999 RVA: 0x0022116E File Offset: 0x0021F36E
	private CumulativeShopTaskItem InitTaskItem()
	{
		return new CumulativeShopTaskItem();
	}

	// Token: 0x060080E8 RID: 33000 RVA: 0x00221178 File Offset: 0x0021F378
	private void OnClickTabBack(int tabIndex, UUIExtendToggle toggle)
	{
		UUIExtendToggle lastSelectToggle = this.LastSelectToggle;
		if (lastSelectToggle != null)
		{
			lastSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.LastSelectToggle = toggle;
		this.CurrentSelectTabIndex = tabIndex;
		List<int> tabTaskList = ControllerBase<CumulativeShopController>.Instance.GetCumulativeShopData().GetTabTaskList(tabIndex);
		this.TaskLoopScrollView.RefreshByData(tabTaskList ?? new List<int>(), false, null, false);
		UUIInturnAnimController uiAnimController = this.TaskLoopScrollView.GetUiAnimController();
		if (uiAnimController == null)
		{
			return;
		}
		uiAnimController.Play("", -1, false);
	}

	// Token: 0x060080E9 RID: 33001 RVA: 0x002211F0 File Offset: 0x0021F3F0
	private void CumulativeShopTaskRefresh()
	{
		List<int> tabTaskList = ControllerBase<CumulativeShopController>.Instance.GetCumulativeShopData().GetTabTaskList(this.CurrentSelectTabIndex);
		this.TaskLoopScrollView.RefreshByData(tabTaskList ?? new List<int>(), false, null, false);
		UUIInturnAnimController uiAnimController = this.TaskLoopScrollView.GetUiAnimController();
		if (uiAnimController == null)
		{
			return;
		}
		uiAnimController.Play("", -1, false);
	}

	// Token: 0x060080EA RID: 33002 RVA: 0x00221247 File Offset: 0x0021F447
	private void OnCumulativeShopTaskRefresh(int tabIndex)
	{
		this.CumulativeShopTaskRefresh();
	}

	// Token: 0x060080EB RID: 33003 RVA: 0x00221250 File Offset: 0x0021F450
	private void OnActivityUpdate()
	{
		CumulativeShopData cumulativeShopData = ControllerBase<CumulativeShopController>.Instance.GetCumulativeShopData();
		if (cumulativeShopData == null || !cumulativeShopData.CheckIfInOpenTime())
		{
			ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
		}
	}

	// Token: 0x060080EC RID: 33004 RVA: 0x00221280 File Offset: 0x0021F480
	private void CumulativeShopTaskViewDataRefresh()
	{
		List<int> taskTabList = new List<int>(ControllerBase<CumulativeShopController>.Instance.GetCumulativeShopData().TaskTabMap.Keys);
		taskTabList.Sort((int a, int b) => a - b);
		this.TabScrollView.RefreshByData(taskTabList, delegate
		{
			CumulativeShopData cumulativeShopData = ControllerBase<CumulativeShopController>.Instance.GetCumulativeShopData();
			bool flag = false;
			for (int i = 0; i < taskTabList.Count; i++)
			{
				int tabIndex = taskTabList[i];
				if (cumulativeShopData.GetTaskTabRedDot(tabIndex))
				{
					this.TabScrollView.SelectGridProxy(i, false);
					if (this.CurrentSelectTabIndex - 1 == i)
					{
						this.CumulativeShopTaskRefresh();
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.TabScrollView.SelectGridProxy(Math.Max(this.CurrentSelectTabIndex - 1, 0), true);
				this.CumulativeShopTaskRefresh();
			}
		}, false);
	}

	// Token: 0x04003D8A RID: 15754
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CumulativeShopTaskTabItem, int> TabScrollView;

	// Token: 0x04003D8B RID: 15755
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<CumulativeShopTaskItem, int> TaskLoopScrollView;

	// Token: 0x04003D8C RID: 15756
	[Nullable(2)]
	private UUIExtendToggle LastSelectToggle;

	// Token: 0x04003D8D RID: 15757
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003D8E RID: 15758
	private int CurrentSelectTabIndex;
}
