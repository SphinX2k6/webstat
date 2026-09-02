using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001446 RID: 5190
[NullableContext(2)]
[Nullable(0)]
public class MowingTowerSubView : ActivitySubViewBase
{
	// Token: 0x06009068 RID: 36968 RVA: 0x0025F5CC File Offset: 0x0025D7CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnReward))
		};
	}

	// Token: 0x06009069 RID: 36969 RVA: 0x0025F6A1 File Offset: 0x0025D8A1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshMowingTowerData, new Action(this.OnMowingTowerDataUpdate));
	}

	// Token: 0x0600906A RID: 36970 RVA: 0x0025F6BF File Offset: 0x0025D8BF
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshMowingTowerData, new Action(this.OnMowingTowerDataUpdate));
	}

	// Token: 0x0600906B RID: 36971 RVA: 0x0025F6DD File Offset: 0x0025D8DD
	private void OnMowingTowerDataUpdate()
	{
		this.RefreshRedDot();
	}

	// Token: 0x0600906C RID: 36972 RVA: 0x0025F6E8 File Offset: 0x0025D8E8
	protected override UniTask OnBeforeStartAsync()
	{
		MowingTowerSubView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MowingTowerSubView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600906D RID: 36973 RVA: 0x0025F72B File Offset: 0x0025D92B
	protected override void OnStart()
	{
		this.MowingTowerData = (this.ActivityBaseData as MowingTowerData);
	}

	// Token: 0x0600906E RID: 36974 RVA: 0x0025F73E File Offset: 0x0025D93E
	protected override void OnBeforeShow()
	{
		this.BindRedDot();
	}

	// Token: 0x0600906F RID: 36975 RVA: 0x0025F746 File Offset: 0x0025D946
	protected override void OnBeforeHide()
	{
		this.RemoveRedDot();
	}

	// Token: 0x06009070 RID: 36976 RVA: 0x0025F750 File Offset: 0x0025D950
	protected override void OnRefreshView()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		this.RefreshDesc();
		this.RefreshTitle();
		this.RefreshReward();
		this.RefreshFunctionalComponent();
		this.RefreshRedDot();
		this.RefreshState();
		this.RefreshScoreText();
		this.TryShowNewUnlockTips();
	}

	// Token: 0x06009071 RID: 36977 RVA: 0x0025F7A3 File Offset: 0x0025D9A3
	private void BindRedDot()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.MowingTowerReward, base.GetItem(6), null, this.MowingTowerData.Id);
	}

	// Token: 0x06009072 RID: 36978 RVA: 0x0025F7C7 File Offset: 0x0025D9C7
	private void RemoveRedDot()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.MowingTowerReward, base.GetItem(6), this.MowingTowerData.Id);
	}

	// Token: 0x06009073 RID: 36979 RVA: 0x0025F7EC File Offset: 0x0025D9EC
	private void TryShowNewUnlockTips()
	{
		if (this.MowingTowerData.GetNewUnlockState())
		{
			this.MowingTowerData.CacheNewUnlock();
			DifficultUnlockTipsData difficultUnlockTipsData = new DifficultUnlockTipsData();
			difficultUnlockTipsData.Text = "MowTowerNewLevelTips";
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DifficultUnlockTipView, difficultUnlockTipsData, null);
		}
	}

	// Token: 0x06009074 RID: 36980 RVA: 0x0025F834 File Offset: 0x0025DA34
	private void RefreshState()
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		bool flag = this.ActivityBaseData.IsUnLock();
		this.FunctionalComponent.SetPanelConditionVisible(!flag);
		this.FunctionalComponent.FunctionButton.SetUiActive(flag);
		if (!flag)
		{
			this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
		}
	}

	// Token: 0x06009075 RID: 36981 RVA: 0x0025F8A4 File Offset: 0x0025DAA4
	private void RefreshScoreText()
	{
		MowingTowerData mowingTowerData = this.ActivityBaseData as MowingTowerData;
		base.GetText(5).SetText(mowingTowerData.GetFullScore().ToString() ?? "", true);
	}

	// Token: 0x06009076 RID: 36982 RVA: 0x0025F8E4 File Offset: 0x0025DAE4
	private void RefreshTitle()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06009077 RID: 36983 RVA: 0x0025F948 File Offset: 0x0025DB48
	private void RefreshDesc()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		string descTheme = localConfig.Value.DescTheme;
		string desc = localConfig.Value.Desc;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
	}

	// Token: 0x06009078 RID: 36984 RVA: 0x0025F9C0 File Offset: 0x0025DBC0
	private void RefreshReward()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.SetTitleByTextId("BossRushCollectReward");
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
	}

	// Token: 0x06009079 RID: 36985 RVA: 0x0025F9FF File Offset: 0x0025DBFF
	protected override void OnTimer(float gap)
	{
		base.OnTimer(gap);
		this.RefreshTitle();
	}

	// Token: 0x0600907A RID: 36986 RVA: 0x0025FA0E File Offset: 0x0025DC0E
	private void OnClickBtnReward()
	{
		ModelBase<MowingTowerModel>.Instance.CurrentSelectActivityId = this.ActivityBaseData.Id;
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MowingTowerRewardView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MowingTowerRewardView, null, null);
		}
	}

	// Token: 0x0600907B RID: 36987 RVA: 0x0025FA48 File Offset: 0x0025DC48
	private void RefreshFunctionalComponent()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("BossRushEnterText", null);
		this.FunctionalComponent.FunctionButton.SetText(localTextNew);
	}

	// Token: 0x0600907C RID: 36988 RVA: 0x0025FA74 File Offset: 0x0025DC74
	private void FunctionExecute()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		ControllerBase<MowingTowerController>.Instance.OpenMowingTowerView(this.ActivityBaseData.Id);
	}

	// Token: 0x0600907D RID: 36989 RVA: 0x0025FAC8 File Offset: 0x0025DCC8
	private void RefreshRedDot()
	{
		bool flag = this.MowingTowerData.EntranceRedDot();
		bool preGuideQuestFinishState = this.MowingTowerData.GetPreGuideQuestFinishState();
		this.FunctionalComponent.FunctionButton.SetRedDotVisible(preGuideQuestFinishState && flag);
	}

	// Token: 0x0400430F RID: 17167
	private MowingTowerData MowingTowerData;

	// Token: 0x04004310 RID: 17168
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04004311 RID: 17169
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x04004312 RID: 17170
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x04004313 RID: 17171
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x0200783E RID: 30782
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x040295A5 RID: 169381
		TitleItem,
		// Token: 0x040295A6 RID: 169382
		DescItem,
		// Token: 0x040295A7 RID: 169383
		RewardItem,
		// Token: 0x040295A8 RID: 169384
		FunctionalAreaItem,
		// Token: 0x040295A9 RID: 169385
		RewardBtn,
		// Token: 0x040295AA RID: 169386
		ScoreText,
		// Token: 0x040295AB RID: 169387
		RewardRedDotItem
	}
}
