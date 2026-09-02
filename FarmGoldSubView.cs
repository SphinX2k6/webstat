using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.FarmGold;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200131B RID: 4891
[NullableContext(2)]
[Nullable(0)]
public class FarmGoldSubView : ActivitySubViewBase
{
	// Token: 0x06008527 RID: 34087 RVA: 0x00231267 File Offset: 0x0022F467
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06008528 RID: 34088 RVA: 0x002312A0 File Offset: 0x0022F4A0
	protected override UniTask OnBeforeStartAsync()
	{
		FarmGoldSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FarmGoldSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008529 RID: 34089 RVA: 0x002312E4 File Offset: 0x0022F4E4
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FarmGoldRefreshRewardRedDot, new Action<int>(this.OnFarmGoldOrCommonRedDot));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnFarmGoldOrCommonRedDot));
		Singleton<EventSystem>.Instance.Add<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshRewardPopUp));
	}

	// Token: 0x0600852A RID: 34090 RVA: 0x0023134C File Offset: 0x0022F54C
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.FarmGoldRefreshRewardRedDot, new Action<int>(this.OnFarmGoldOrCommonRedDot));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnFarmGoldOrCommonRedDot));
		Singleton<EventSystem>.Instance.Remove<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshRewardPopUp));
	}

	// Token: 0x0600852B RID: 34091 RVA: 0x002313B3 File Offset: 0x0022F5B3
	private void OnFarmGoldOrCommonRedDot(int id)
	{
		this.RefreshRedDot();
	}

	// Token: 0x0600852C RID: 34092 RVA: 0x002313BB File Offset: 0x0022F5BB
	private void OnClickRewardButtonItem()
	{
		this.OnClickBtnReward();
	}

	// Token: 0x0600852D RID: 34093 RVA: 0x002313C3 File Offset: 0x0022F5C3
	private void OnClickBtnReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, this.FarmGoldDataField.GetRewardPopUpViewData(), delegate(bool success, int viewId)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonActivityView);
			if (viewByName == null)
			{
				return;
			}
			viewByName.AddChildViewById(viewId);
		});
	}

	// Token: 0x0600852E RID: 34094 RVA: 0x002313FE File Offset: 0x0022F5FE
	protected override void OnStart()
	{
		this.FarmGoldDataField = (this.ActivityBaseData as FarmGoldData);
	}

	// Token: 0x0600852F RID: 34095 RVA: 0x00231414 File Offset: 0x0022F614
	protected override void OnBeforeShow()
	{
		if (this.ActivityBaseData.GetUnFinishPreGuideQuestId() > 0)
		{
			this.InfoComponent.SetBtnText("FarmGoldEnterText", Array.Empty<object>());
		}
		else
		{
			this.InfoComponent.SetBtnText("PrefabTextItem_2701983798_Text", Array.Empty<object>());
		}
		this.UnBindFarmGoldRedDot();
		ButtonItem rewardButtonItem = this.RewardButtonItem;
		if (rewardButtonItem == null)
		{
			return;
		}
		ERedDotName redDotName = ERedDotName.FarmGoldReward;
		ActivityBaseData activityBaseData = this.ActivityBaseData;
		rewardButtonItem.BindRedDot(redDotName, (activityBaseData != null) ? activityBaseData.Id : 0);
	}

	// Token: 0x06008530 RID: 34096 RVA: 0x00231488 File Offset: 0x0022F688
	protected override void OnRefreshView()
	{
		this.RefreshRewardButtonText();
		this.RefreshRedDot();
	}

	// Token: 0x06008531 RID: 34097 RVA: 0x00231498 File Offset: 0x0022F698
	private void RefreshRewardButtonText()
	{
		FarmGoldData farmGoldDataField = this.FarmGoldDataField;
		ValueTuple<int, int>? valueTuple = (farmGoldDataField != null) ? new ValueTuple<int, int>?(farmGoldDataField.GetAllRewardClaimedAndTotalNum()) : null;
		if (valueTuple == null)
		{
			return;
		}
		ButtonItem rewardButtonItem = this.RewardButtonItem;
		if (rewardButtonItem == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(valueTuple.Value.Item1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(valueTuple.Value.Item2);
		rewardButtonItem.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x06008532 RID: 34098 RVA: 0x00231524 File Offset: 0x0022F724
	private void FunctionExecute(ActivityBaseData data)
	{
		int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
		if (unFinishPreGuideQuestId > 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		int entranceId = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldMarkByActivityId(this.ActivityBaseData.Id).EntranceId;
		if (entranceId > 0)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(entranceId, 0, null).Forget<bool>();
		}
	}

	// Token: 0x06008533 RID: 34099 RVA: 0x0023158C File Offset: 0x0022F78C
	private void RefreshRedDot()
	{
		bool flag = this.FarmGoldDataField.EntranceRedDot();
		bool preGuideQuestFinishState = this.FarmGoldDataField.GetPreGuideQuestFinishState();
		this.InfoComponent.SetFunctionRedDotVisible(preGuideQuestFinishState && flag);
	}

	// Token: 0x06008534 RID: 34100 RVA: 0x002315BF File Offset: 0x0022F7BF
	[NullableContext(1)]
	private void OnRefreshRewardPopUp(IActivityRewardViewData data)
	{
		if (this.FarmGoldDataField != null)
		{
			this.RefreshRewardButtonText();
		}
	}

	// Token: 0x06008535 RID: 34101 RVA: 0x002315CF File Offset: 0x0022F7CF
	protected override void OnBeforeHide()
	{
		this.UnBindFarmGoldRedDot();
	}

	// Token: 0x06008536 RID: 34102 RVA: 0x002315D7 File Offset: 0x0022F7D7
	private void UnBindFarmGoldRedDot()
	{
		ButtonItem rewardButtonItem = this.RewardButtonItem;
		if (rewardButtonItem == null)
		{
			return;
		}
		rewardButtonItem.UnBindRedDot();
	}

	// Token: 0x04003F16 RID: 16150
	private FarmGoldData FarmGoldDataField;

	// Token: 0x04003F17 RID: 16151
	private ActivitySubViewGeneralInfo InfoComponent;

	// Token: 0x04003F18 RID: 16152
	private ButtonItem RewardButtonItem;

	// Token: 0x020076BD RID: 30397
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028E76 RID: 167542
		public const int InfoItem = 0;

		// Token: 0x04028E77 RID: 167543
		public const int RewardButton = 1;
	}
}
