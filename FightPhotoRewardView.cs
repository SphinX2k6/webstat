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

// Token: 0x02001330 RID: 4912
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoRewardView : UiViewBase
{
	// Token: 0x06008610 RID: 34320 RVA: 0x002354D9 File Offset: 0x002336D9
	public FightPhotoRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008611 RID: 34321 RVA: 0x002354E4 File Offset: 0x002336E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIInturnAnimController))
		};
	}

	// Token: 0x06008612 RID: 34322 RVA: 0x00235580 File Offset: 0x00233780
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoRewardView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoRewardView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008613 RID: 34323 RVA: 0x002355C3 File Offset: 0x002337C3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008614 RID: 34324 RVA: 0x002355FD File Offset: 0x002337FD
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008615 RID: 34325 RVA: 0x00235637 File Offset: 0x00233837
	private void OnRefreshCommonActivityRedDot(int activityId)
	{
		if (activityId == this.ActivityData.Id)
		{
			this.TabLayout.RefreshWithoutDataSync();
			this.RefreshTaskLayout(true);
		}
	}

	// Token: 0x06008616 RID: 34326 RVA: 0x00235659 File Offset: 0x00233859
	private void RefreshTaskLayout(bool isPlayAnim = false)
	{
		this.TaskLayout.RefreshByData(this.ActivityData.GetTaskDataList(this.CurrentTabId), delegate
		{
			this.TaskLayout.LateScrollTo(this.TaskLayout.GetItemByIndex(0), null, false);
		}, isPlayAnim);
	}

	// Token: 0x06008617 RID: 34327 RVA: 0x00235684 File Offset: 0x00233884
	private FightPhotoTaskTabItem CreateTabItem()
	{
		return new FightPhotoTaskTabItem
		{
			activityData = this.ActivityData,
			OnToggleClickCallBack = new Action<int>(this.OnTabClickCallBack)
		};
	}

	// Token: 0x06008618 RID: 34328 RVA: 0x002356A9 File Offset: 0x002338A9
	private void OnTabClickCallBack(int tabId)
	{
		this.CurrentTabId = tabId;
		this.TabLayout.SelectGridProxyByKey(tabId, false);
		base.PlaySequence("Switch", null, false);
		this.RefreshTaskLayout(false);
	}

	// Token: 0x06008619 RID: 34329 RVA: 0x002356D8 File Offset: 0x002338D8
	private FightPhotoTaskItem CreateTaskItem()
	{
		return new FightPhotoTaskItem
		{
			OnRewardBtnClick = new Action(this.OnRewardBtnClick)
		};
	}

	// Token: 0x0600861A RID: 34330 RVA: 0x002356F1 File Offset: 0x002338F1
	private void OnRewardBtnClick()
	{
		this.ActivityData.RequestTaskReward(this.CurrentTabId);
	}

	// Token: 0x0600861B RID: 34331 RVA: 0x00235704 File Offset: 0x00233904
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600861C RID: 34332 RVA: 0x0023570D File Offset: 0x0023390D
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "ListAnim")
		{
			UUIInturnAnimController uiInturnAnimController = base.GetUiInturnAnimController(5);
			if (uiInturnAnimController == null)
			{
				return;
			}
			uiInturnAnimController.Play("", -1, false);
		}
	}

	// Token: 0x04003F6D RID: 16237
	[Nullable(2)]
	private FightPhotoActivityData ActivityData;

	// Token: 0x04003F6E RID: 16238
	private int CurrentTabId;

	// Token: 0x04003F6F RID: 16239
	private GenericLayout<FightPhotoTaskTabItem, PhotoFightRewardTab> TabLayout;

	// Token: 0x04003F70 RID: 16240
	private GenericScrollViewNew<FightPhotoTaskItem, FightPhotoTaskData> TaskLayout;

	// Token: 0x020076D3 RID: 30419
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028EDB RID: 167643
		ItemCaption,
		// Token: 0x04028EDC RID: 167644
		LayoutTab,
		// Token: 0x04028EDD RID: 167645
		ItemTab,
		// Token: 0x04028EDE RID: 167646
		ScrollReward,
		// Token: 0x04028EDF RID: 167647
		ItemReward,
		// Token: 0x04028EE0 RID: 167648
		AnimController
	}
}
