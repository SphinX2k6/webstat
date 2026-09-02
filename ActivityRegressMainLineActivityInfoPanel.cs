using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200153C RID: 5436
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressMainLineActivityInfoPanel : UiPanelBase
{
	// Token: 0x0600987E RID: 39038 RVA: 0x0027F148 File Offset: 0x0027D348
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600987F RID: 39039 RVA: 0x0027F1B8 File Offset: 0x0027D3B8
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressMainLineActivityInfoPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressMainLineActivityInfoPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009880 RID: 39040 RVA: 0x0027F1FC File Offset: 0x0027D3FC
	protected override void OnStart()
	{
		this.ActivityBottom.FunctionButton.SetFunction(new Action(this.OnGotoToMainLineBtnClick));
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null);
		this.ActivityBottom.FunctionButton.SetText(localTextNew ?? "");
		this.ActivityRewardListPanel.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.ActivityRewardListPanel.InitCommonGridItem));
		this.ActivityTitlePanel.SetTimeTextVisible(false);
	}

	// Token: 0x06009881 RID: 39041 RVA: 0x0027F273 File Offset: 0x0027D473
	public void RefreshByData(RegressBase config)
	{
		this.Config = new RegressBase?(config);
		this.RefreshTitle();
		this.RefreshDesc();
		this.RefreshReward();
		this.RefreshFuncBtn();
	}

	// Token: 0x06009882 RID: 39042 RVA: 0x0027F29C File Offset: 0x0027D49C
	private void RefreshTitle()
	{
		this.ActivityTitlePanel.SetTitleByTextId(this.Config.Value.Title, Array.Empty<string>());
	}

	// Token: 0x06009883 RID: 39043 RVA: 0x0027F2CC File Offset: 0x0027D4CC
	private void RefreshDesc()
	{
		string subTitle = this.Config.Value.SubTitle;
		string description = this.Config.Value.Description;
		bool flag = !StringUtils.IsEmpty(subTitle);
		this.ActivityTitlePanel.SetSubTitleVisible(flag);
		if (flag)
		{
			this.ActivityTitlePanel.SetSubTitleByTextId(subTitle, Array.Empty<string>());
		}
		this.ActivityDescPanel.SetContentByTextId(description, Array.Empty<string>());
	}

	// Token: 0x06009884 RID: 39044 RVA: 0x0027F33C File Offset: 0x0027D53C
	private void RefreshReward()
	{
		List<TItem> regressBaseRewardPreviewItemList = ModelBase<ActivityRegressModel>.Instance.GetRegressBaseRewardPreviewItemList(this.Config.Value);
		this.ActivityRewardListPanel.RefreshItemLayout(regressBaseRewardPreviewItemList, new Action(this.RefreshRewardState));
	}

	// Token: 0x06009885 RID: 39045 RVA: 0x0027F378 File Offset: 0x0027D578
	private void RefreshRewardState()
	{
		bool receivedVisible = ModelBase<ActivityRegressModel>.Instance.IsMainLineTaskFinish(this.Config.Value);
		CommonItemSmallItemGrid[] layoutItemList = this.ActivityRewardListPanel.GetLayoutItemList();
		for (int i = 0; i < layoutItemList.Length; i++)
		{
			layoutItemList[i].SetReceivedVisible(receivedVisible);
		}
	}

	// Token: 0x06009886 RID: 39046 RVA: 0x0027F3C0 File Offset: 0x0027D5C0
	private void RefreshFuncBtn()
	{
		bool flag = ModelBase<ActivityRegressModel>.Instance.IsMainLineTaskFinish(this.Config.Value);
		this.ActivityBottom.FunctionButton.SetUiActive(!flag);
		this.ActivityBottom.SetActivatePanelConditionVisible(flag);
		if (flag)
		{
			this.ActivityBottom.SetActivateTextByTextId("RecallActivity_Finish", Array.Empty<string>());
			return;
		}
		this.ActivityBottom.FunctionButton.SetLocalTextNew("RecallActivity_Go", Array.Empty<object>());
	}

	// Token: 0x06009887 RID: 39047 RVA: 0x0027F438 File Offset: 0x0027D638
	private void OnGotoToMainLineBtnClick()
	{
		int? num = ModelBase<ActivityRegressModel>.Instance.GetFirstUnFinishTask(this.Config.Value);
		if (num != null)
		{
			ActivityRegressHelper.ReportRecallLog1024(EReportLogEventType.NewMainLine, num.Value);
		}
		else
		{
			num = ModelBase<ActivityRegressModel>.Instance.GetFirstUnFinishMainQuestId();
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Role_Precondition", Array.Empty<object>());
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, num, null);
	}

	// Token: 0x04004694 RID: 18068
	private RegressBase? Config;

	// Token: 0x04004695 RID: 18069
	private ActivityTitleTypeA ActivityTitlePanel;

	// Token: 0x04004696 RID: 18070
	private ActivityDescriptionTypeB ActivityDescPanel;

	// Token: 0x04004697 RID: 18071
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> ActivityRewardListPanel;

	// Token: 0x04004698 RID: 18072
	private ActivityFunctionalTypeA ActivityBottom;

	// Token: 0x020078F4 RID: 30964
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04029935 RID: 170293
		ComActivityTitle,
		// Token: 0x04029936 RID: 170294
		ComActivityDesc,
		// Token: 0x04029937 RID: 170295
		ComActivityReward,
		// Token: 0x04029938 RID: 170296
		ComActivityBottom
	}
}
