using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200132B RID: 4907
public class FightPhotoActivitySubView : ActivitySubViewBase
{
	// Token: 0x060085D3 RID: 34259 RVA: 0x00233E78 File Offset: 0x00232078
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnRewardBtnClick))
		};
	}

	// Token: 0x060085D4 RID: 34260 RVA: 0x00233F38 File Offset: 0x00232138
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoActivitySubView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoActivitySubView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060085D5 RID: 34261 RVA: 0x00233F7C File Offset: 0x0023217C
	protected override void OnRefreshView()
	{
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.OnRefreshView();
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(((FightPhotoActivityData)this.ActivityBaseData).GetFinishedLevelNum().ToString(), true);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetText("/" + ((FightPhotoActivityData)this.ActivityBaseData).GetTotalLevelNum().ToString(), true);
		}
		int finishedTaskNum = ((FightPhotoActivityData)this.ActivityBaseData).GetFinishedTaskNum();
		int totalTaskNum = ((FightPhotoActivityData)this.ActivityBaseData).GetTotalTaskNum();
		UUIText text3 = base.GetText(4);
		if (text3 != null)
		{
			text3.SetText(finishedTaskNum.ToString() + "/" + totalTaskNum.ToString(), true);
		}
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(((FightPhotoActivityData)this.ActivityBaseData).IsTaskHasRedDot());
		}
		ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
		if (commonInfoPanel2 == null)
		{
			return;
		}
		commonInfoPanel2.SetFunctionRedDotVisible(((FightPhotoActivityData)this.ActivityBaseData).IsLevelHasRedDot());
	}

	// Token: 0x060085D6 RID: 34262 RVA: 0x00234089 File Offset: 0x00232289
	private void OnRewardBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoRewardView, this.ActivityBaseData, null);
	}

	// Token: 0x060085D7 RID: 34263 RVA: 0x002340A4 File Offset: 0x002322A4
	[NullableContext(1)]
	private void OnConfirmBtnClick(ActivityBaseData _)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_600064_Text", Array.Empty<object>());
			return;
		}
		FightPhotoActivityData fightPhotoActivityData = (FightPhotoActivityData)this.ActivityBaseData;
		if (!fightPhotoActivityData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = fightPhotoActivityData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoLoadingView, this.ActivityBaseData, null);
	}

	// Token: 0x04003F56 RID: 16214
	[Nullable(1)]
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x020076C9 RID: 30409
	private class EComponents
	{
		// Token: 0x04028E98 RID: 167576
		public const int CommonActivityInfo = 0;

		// Token: 0x04028E99 RID: 167577
		public const int TextFinishedLevelNum = 1;

		// Token: 0x04028E9A RID: 167578
		public const int TextTotalLevelNum = 2;

		// Token: 0x04028E9B RID: 167579
		public const int BtnReward = 3;

		// Token: 0x04028E9C RID: 167580
		public const int TextRewardProgress = 4;

		// Token: 0x04028E9D RID: 167581
		public const int ItemRedDot = 5;
	}
}
