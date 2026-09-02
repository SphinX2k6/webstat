using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001413 RID: 5139
[NullableContext(1)]
[Nullable(0)]
public class RewardMainView : UiViewBase
{
	// Token: 0x06008E64 RID: 36452 RVA: 0x002567E8 File Offset: 0x002549E8
	public RewardMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008E65 RID: 36453 RVA: 0x00256810 File Offset: 0x00254A10
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06008E66 RID: 36454 RVA: 0x00256898 File Offset: 0x00254A98
	protected override UniTask OnBeforeStartAsync()
	{
		RewardMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RewardMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008E67 RID: 36455 RVA: 0x002568DB File Offset: 0x00254ADB
	protected override void OnBeforeShow()
	{
		ControllerBase<ActivityMoonChasingController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06008E68 RID: 36456 RVA: 0x002568E7 File Offset: 0x00254AE7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TakenRewardTargetData, new Action<int>(this.TakenRewardTargetData));
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshRewardRedDot, new Action(this.OnMoonChasingRefreshRewardRedDot));
	}

	// Token: 0x06008E69 RID: 36457 RVA: 0x00256921 File Offset: 0x00254B21
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TakenRewardTargetData, new Action<int>(this.TakenRewardTargetData));
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshRewardRedDot, new Action(this.OnMoonChasingRefreshRewardRedDot));
	}

	// Token: 0x06008E6A RID: 36458 RVA: 0x0025695C File Offset: 0x00254B5C
	private void TakenRewardTargetData(int id)
	{
		TaskData specialTaskData = ModelBase<MoonChasingRewardModel>.Instance.GetSpecialTaskData();
		if (id == specialTaskData.TaskId)
		{
			this.RefreshGrandItem();
			return;
		}
		this.RefreshTabItem();
	}

	// Token: 0x06008E6B RID: 36459 RVA: 0x0025698A File Offset: 0x00254B8A
	private void OnMoonChasingRefreshRewardRedDot()
	{
		this.RefreshTabItem();
	}

	// Token: 0x06008E6C RID: 36460 RVA: 0x00256992 File Offset: 0x00254B92
	private void OnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06008E6D RID: 36461 RVA: 0x0025699B File Offset: 0x00254B9B
	private void ToggleCallBack(int index)
	{
		this.InsControl.TabItemToggleClick(index);
	}

	// Token: 0x06008E6E RID: 36462 RVA: 0x002569AC File Offset: 0x00254BAC
	public UniTask InitCaption()
	{
		RewardMainView.<InitCaption>d__16 <InitCaption>d__;
		<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaption>d__.<>4__this = this;
		<InitCaption>d__.<>1__state = -1;
		<InitCaption>d__.<>t__builder.Start<RewardMainView.<InitCaption>d__16>(ref <InitCaption>d__);
		return <InitCaption>d__.<>t__builder.Task;
	}

	// Token: 0x06008E6F RID: 36463 RVA: 0x002569F0 File Offset: 0x00254BF0
	public UniTask InitGrandItem()
	{
		RewardMainView.<InitGrandItem>d__17 <InitGrandItem>d__;
		<InitGrandItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitGrandItem>d__.<>4__this = this;
		<InitGrandItem>d__.<>1__state = -1;
		<InitGrandItem>d__.<>t__builder.Start<RewardMainView.<InitGrandItem>d__17>(ref <InitGrandItem>d__);
		return <InitGrandItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008E70 RID: 36464 RVA: 0x00256A34 File Offset: 0x00254C34
	private void RefreshGrandItem()
	{
		this.GrandItem.SetActive(false);
		TaskData specialTaskData = ModelBase<MoonChasingRewardModel>.Instance.GetSpecialTaskData();
		this.GrandItem.Refresh(specialTaskData);
		this.GrandItem.SetActive(true);
	}

	// Token: 0x06008E71 RID: 36465 RVA: 0x00256A70 File Offset: 0x00254C70
	private void RefreshTabItem()
	{
		bool allTaskDataRedDotState = ModelBase<MoonChasingRewardModel>.Instance.GetAllTaskDataRedDotState(false);
		this.TabItemList[0].SetRedDotVisible(allTaskDataRedDotState);
		bool shopRedDotState = ModelBase<MoonChasingRewardModel>.Instance.GetShopRedDotState();
		this.TabItemList[1].SetRedDotVisible(shopRedDotState);
	}

	// Token: 0x06008E72 RID: 36466 RVA: 0x00256AB8 File Offset: 0x00254CB8
	public UniTask InitTabComponent()
	{
		RewardMainView.<InitTabComponent>d__20 <InitTabComponent>d__;
		<InitTabComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTabComponent>d__.<>4__this = this;
		<InitTabComponent>d__.<>1__state = -1;
		<InitTabComponent>d__.<>t__builder.Start<RewardMainView.<InitTabComponent>d__20>(ref <InitTabComponent>d__);
		return <InitTabComponent>d__.<>t__builder.Task;
	}

	// Token: 0x06008E73 RID: 36467 RVA: 0x00256AFB File Offset: 0x00254CFB
	public void InitTabViewComponent()
	{
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
	}

	// Token: 0x06008E74 RID: 36468 RVA: 0x00256B10 File Offset: 0x00254D10
	public void SetTabState(int index, bool state, bool bFireEvent)
	{
		this.TabItemList[index].SetToggleState(state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent);
	}

	// Token: 0x06008E75 RID: 36469 RVA: 0x00256B2C File Offset: 0x00254D2C
	public void SwitchTabView(UiDynamicTab data, int index)
	{
		EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
		this.TabViewComponent.ToggleCallBack(data, viewName, this.TabItemList[index], this.CanAccomplishTask, null);
		UUIItem rootItem = this.TabItemList[0].GetRootItem();
		UUIItem rootItem2 = this.TabItemList[1].GetRootItem();
		int hierarchyIndex = rootItem.GetHierarchyIndex();
		int hierarchyIndex2 = rootItem2.GetHierarchyIndex();
		if ((hierarchyIndex > hierarchyIndex2 && index == 0) || (hierarchyIndex < hierarchyIndex2 && index == 1))
		{
			return;
		}
		rootItem.SetHierarchyIndex(hierarchyIndex2);
		rootItem2.SetHierarchyIndex(hierarchyIndex);
	}

	// Token: 0x0400425D RID: 16989
	private readonly RewardInstanceController InsControl = new RewardInstanceController();

	// Token: 0x0400425E RID: 16990
	protected PopupCaptionItem Caption;

	// Token: 0x0400425F RID: 16991
	protected RewardGrandItem GrandItem;

	// Token: 0x04004260 RID: 16992
	protected List<RewardMainTabItem> TabItemList = new List<RewardMainTabItem>();

	// Token: 0x04004261 RID: 16993
	protected TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x04004262 RID: 16994
	private bool CanAccomplishTask = true;

	// Token: 0x02007801 RID: 30721
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04029489 RID: 169097
		public const int CaptionItem = 0;

		// Token: 0x0402948A RID: 169098
		public const int ContentItem = 1;

		// Token: 0x0402948B RID: 169099
		public const int ShopButtonItem = 2;

		// Token: 0x0402948C RID: 169100
		public const int TargetButtonItem = 3;

		// Token: 0x0402948D RID: 169101
		public const int GrandItem = 4;
	}
}
