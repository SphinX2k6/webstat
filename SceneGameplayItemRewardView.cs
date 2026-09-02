using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;

// Token: 0x020020C3 RID: 8387
[NullableContext(1)]
[Nullable(0)]
public class SceneGameplayItemRewardView : CommonResultView
{
	// Token: 0x0601005C RID: 65628 RVA: 0x00466E17 File Offset: 0x00465017
	public SceneGameplayItemRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601005D RID: 65629 RVA: 0x00466E20 File Offset: 0x00465020
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.PlotNetworkStartEvent));
		Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.PlotNetworkEndEvent));
	}

	// Token: 0x0601005E RID: 65630 RVA: 0x00466E5A File Offset: 0x0046505A
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.PlotNetworkStartEvent));
		Singleton<EventSystem>.Instance.Remove<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.PlotNetworkEndEvent));
	}

	// Token: 0x0601005F RID: 65631 RVA: 0x00466E94 File Offset: 0x00465094
	protected override void OnStart()
	{
		base.OnStart();
		this.UpdateView();
	}

	// Token: 0x06010060 RID: 65632 RVA: 0x00466EA2 File Offset: 0x004650A2
	private void PlotNetworkStartEvent(PlotInfo info)
	{
		this.SetActive(false);
	}

	// Token: 0x06010061 RID: 65633 RVA: 0x00466EAB File Offset: 0x004650AB
	private void PlotNetworkEndEvent(PlotResultInfo info)
	{
		this.SetActive(true);
	}

	// Token: 0x06010062 RID: 65634 RVA: 0x00466EB4 File Offset: 0x004650B4
	private void UpdateView()
	{
		this.UpdateRewardPreview();
	}

	// Token: 0x06010063 RID: 65635 RVA: 0x00466EBC File Offset: 0x004650BC
	private void UpdateRewardPreview()
	{
		ItemRewardData itemRewardData = ModelBase<ItemHintModel>.Instance.ShiftItemRewardListFirst();
		List<TItem> data = ItemHintController.ConvertRewardListToItem(new List<ItemRewardInfo>(ControllerBase<ItemHintController>.Instance.CombineAllShowItems(itemRewardData.ItemReward, true)));
		this.RewardLayout.RebuildLayoutByDataNew<TItem>(data, null);
	}

	// Token: 0x06010064 RID: 65636 RVA: 0x00466F08 File Offset: 0x00465108
	protected override void SetupButtonFormat()
	{
		List<CommonResultButtonData> dataList = this.CreateInstanceDungeonCommonButtonData();
		base.RefreshButtonList(dataList);
	}

	// Token: 0x06010065 RID: 65637 RVA: 0x00466F23 File Offset: 0x00465123
	private List<CommonResultButtonData> CreateInstanceDungeonCommonButtonData()
	{
		return new List<CommonResultButtonData>
		{
			this.CreateFirstButtonData()
		};
	}

	// Token: 0x06010066 RID: 65638 RVA: 0x00466F36 File Offset: 0x00465136
	private CommonResultButtonData CreateFirstButtonData()
	{
		CommonResultButtonData commonResultButtonData = new CommonResultButtonData();
		commonResultButtonData.SetRefreshCallBack(delegate(CommonResultButton button)
		{
			button.SetBtnText("ButtonTextConfirm", Array.Empty<object>());
		});
		commonResultButtonData.SetClickCallBack(new Action(this.OnClickBtnConfirm));
		return commonResultButtonData;
	}

	// Token: 0x06010067 RID: 65639 RVA: 0x00466F74 File Offset: 0x00465174
	private void OnClickBtnConfirm()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
		{
			base.CloseMe(null);
		}
	}
}
