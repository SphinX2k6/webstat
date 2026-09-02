using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015B7 RID: 5559
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewShipTower : ActivitySubViewBase
{
	// Token: 0x06009C9F RID: 40095 RVA: 0x0029060C File Offset: 0x0028E80C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009CA0 RID: 40096 RVA: 0x00290757 File Offset: 0x0028E957
	private void OnBtnReward()
	{
		this.PlaySubViewSequence("HideInfo", false);
		ModelBase<ShipTowerModel>.Instance.OpenViewReward(null);
	}

	// Token: 0x06009CA1 RID: 40097 RVA: 0x00290770 File Offset: 0x0028E970
	protected override void OnSetData()
	{
	}

	// Token: 0x06009CA2 RID: 40098 RVA: 0x00290774 File Offset: 0x0028E974
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewShipTower.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewShipTower.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009CA3 RID: 40099 RVA: 0x002907B7 File Offset: 0x0028E9B7
	protected override void OnStart()
	{
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.SetBtnText("LongShanStage_Join", Array.Empty<object>());
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
	}

	// Token: 0x06009CA4 RID: 40100 RVA: 0x002907EF File Offset: 0x0028E9EF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06009CA5 RID: 40101 RVA: 0x00290826 File Offset: 0x0028EA26
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06009CA6 RID: 40102 RVA: 0x0029085D File Offset: 0x0028EA5D
	protected override void OnBeforeShow()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ShipTowerReward, base.GetItem(3), null, 0);
	}

	// Token: 0x06009CA7 RID: 40103 RVA: 0x00290874 File Offset: 0x0028EA74
	protected override void OnBeforeHide()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ShipTowerReward, base.GetItem(3), 0);
	}

	// Token: 0x06009CA8 RID: 40104 RVA: 0x0029088C File Offset: 0x0028EA8C
	protected override void OnRefreshView()
	{
		this.UpdateOpenState();
		this.UpdateRewardProgress();
		bool flag = ((ActivityShipTowerData)this.ActivityBaseData).HasNewCycle();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.SetFunctionRedDotVisible(flag);
		}
		ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
		if (commonInfoPanel2 == null)
		{
			return;
		}
		commonInfoPanel2.SetPanelTipVisible(flag);
	}

	// Token: 0x06009CA9 RID: 40105 RVA: 0x002908DC File Offset: 0x0028EADC
	private void SetRewardBtnVisible(bool isVisible)
	{
		base.GetButton(1).RootUIComp.Get().SetUIActive(isVisible);
	}

	// Token: 0x06009CAA RID: 40106 RVA: 0x00290904 File Offset: 0x0028EB04
	private void UpdateOpenState()
	{
		string rewardProgressText = ModelBase<ShipTowerModel>.Instance.GetRewardProgressText(true);
		string currentStageSeasonName = ModelBase<ShipTowerModel>.Instance.GetCurrentStageSeasonName();
		base.GetText(2).SetText(rewardProgressText, true);
		base.GetText(4).SetText(currentStageSeasonName, true);
		this.SetRewardBtnVisible(true);
	}

	// Token: 0x06009CAB RID: 40107 RVA: 0x0029094C File Offset: 0x0028EB4C
	private void UpdateRewardProgress()
	{
		List<ShipTowerAreaItemData> areaList = ModelBase<ShipTowerModel>.Instance.GetAreaList();
		List<ShipTowerAreaItemData> list = new List<ShipTowerAreaItemData>();
		foreach (ShipTowerAreaItemData shipTowerAreaItemData in areaList)
		{
			if (shipTowerAreaItemData.Id != 0)
			{
				list.Add(shipTowerAreaItemData);
			}
		}
		list.Sort((ShipTowerAreaItemData a, ShipTowerAreaItemData b) => a.Index.Value - b.Index.Value);
		this.RewardProgressItem1.SetData(list[0]);
		this.RewardProgressItem2.SetData(list[1]);
	}

	// Token: 0x06009CAC RID: 40108 RVA: 0x002909FC File Offset: 0x0028EBFC
	[NullableContext(1)]
	private void ClickCommonInfo(ActivityBaseData data)
	{
		if (!ModelBase<ShipTowerModel>.Instance.CheckCanOpen(EUiViewName.ShipTowerView, null))
		{
			return;
		}
		this.PlaySubViewSequence("HideView", false);
		ShipTowerStageData currentStage = ModelBase<ShipTowerModel>.Instance.GetCurrentStage();
		ShipTowerViewParams shipTowerViewParams = new ShipTowerViewParams();
		shipTowerViewParams.StageId = new int?(currentStage.Id);
		ModelBase<ShipTowerModel>.Instance.OpenViewMain(shipTowerViewParams);
	}

	// Token: 0x06009CAD RID: 40109 RVA: 0x00290A55 File Offset: 0x0028EC55
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.ShipTowerRewardView)
		{
			this.PlaySubViewSequence("ShowInfo", false);
			this.OnRefreshView();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
		}
	}

	// Token: 0x06009CAE RID: 40110 RVA: 0x00290A94 File Offset: 0x0028EC94
	private void OnRefreshCommonActivityRedDot(int i)
	{
		bool flag = ((ActivityShipTowerData)this.ActivityBaseData).HasNewCycle();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.SetFunctionRedDotVisible(flag);
		}
		ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
		if (commonInfoPanel2 == null)
		{
			return;
		}
		commonInfoPanel2.SetPanelTipVisible(flag);
	}

	// Token: 0x06009CAF RID: 40111 RVA: 0x00290AD8 File Offset: 0x0028ECD8
	protected override void OnTimer(float gap)
	{
		if (this.IsNeedUpdate)
		{
			return;
		}
		if (!ModelBase<ShipTowerModel>.Instance.IsOpen())
		{
			return;
		}
		if (ModelBase<ShipTowerModel>.Instance.TimeIsOver() && ModelBase<ShipTowerModel>.Instance.CheckIsNeedShowConfirmSeasonUpdate(new Action(this.OnConfirmSeasonUpdate)))
		{
			this.IsNeedUpdate = true;
		}
	}

	// Token: 0x06009CB0 RID: 40112 RVA: 0x00290B26 File Offset: 0x0028ED26
	private void OnConfirmSeasonUpdate()
	{
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x04004804 RID: 18436
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x04004805 RID: 18437
	private ActivitySubViewShipTowerRewardProgress RewardProgressItem1;

	// Token: 0x04004806 RID: 18438
	private ActivitySubViewShipTowerRewardProgress RewardProgressItem2;

	// Token: 0x04004807 RID: 18439
	private bool IsNeedUpdate;

	// Token: 0x0200797B RID: 31099
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04029BA2 RID: 170914
		ItemCommonPanel,
		// Token: 0x04029BA3 RID: 170915
		BtnReward,
		// Token: 0x04029BA4 RID: 170916
		TxtNum,
		// Token: 0x04029BA5 RID: 170917
		ItemRedDot,
		// Token: 0x04029BA6 RID: 170918
		TxtRewardTitle,
		// Token: 0x04029BA7 RID: 170919
		RewardProgressItem1,
		// Token: 0x04029BA8 RID: 170920
		RewardProgressItem2
	}
}
