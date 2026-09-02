using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200136B RID: 4971
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewLoopTower : ActivitySubViewBase
{
	// Token: 0x06008846 RID: 34886 RVA: 0x0023F038 File Offset: 0x0023D238
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickTowerShopBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickTowerRewardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008847 RID: 34887 RVA: 0x0023F1E9 File Offset: 0x0023D3E9
	protected override void OnSetData()
	{
	}

	// Token: 0x06008848 RID: 34888 RVA: 0x0023F1EC File Offset: 0x0023D3EC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewLoopTower.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewLoopTower.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008849 RID: 34889 RVA: 0x0023F230 File Offset: 0x0023D430
	protected override void OnStart()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		this.DescriptionComponent.SetContentByTextId(this.ActivityBaseData.LocalConfig.Value.Desc, Array.Empty<string>());
		this.RefreshRewardComponent();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
		if (StringUtils.IsEmpty(this.ActivityRemainTimeText))
		{
			this.ActivityRemainTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
		}
	}

	// Token: 0x0600884A RID: 34890 RVA: 0x0023F2CB File Offset: 0x0023D4CB
	protected override void OnBeforeShow()
	{
		this.OnRefreshView();
		this.RefreshNewSeasonTip();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotTowerReward);
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!ModelBase<TowerModel>.Instance.GetLoopTowerIsClickShop());
	}

	// Token: 0x0600884B RID: 34891 RVA: 0x0023F307 File Offset: 0x0023D507
	protected override void OnRefreshView()
	{
		ModelBase<TowerModel>.Instance.CurrentSelectDifficulties = 3;
		base.GetItem(8).SetUIActive(ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(3));
		this.RefreshTimerText();
		this.RefreshFunctionalComponent();
		this.RefreshStarNumber();
	}

	// Token: 0x0600884C RID: 34892 RVA: 0x0023F33D File Offset: 0x0023D53D
	protected override void OnTimer(float gap)
	{
		if (!this.NeedTick)
		{
			return;
		}
		this.RefreshTimerText();
	}

	// Token: 0x0600884D RID: 34893 RVA: 0x0023F350 File Offset: 0x0023D550
	private void RefreshTimerText()
	{
		double num = (double)Singleton<MathUtils>.Instance.LongToNumber(ModelBase<TowerModel>.Instance.TowerEndTime.GetValueOrDefault());
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (num - serverTime <= 0.0)
		{
			ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			this.NeedTick = false;
			return;
		}
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText((long)num, this.ActivityRemainTimeText);
		this.TitleComponent.SetTimeTextByText(remainTimeText);
	}

	// Token: 0x0600884E RID: 34894 RVA: 0x0023F3C4 File Offset: 0x0023D5C4
	private void RefreshRewardComponent()
	{
		List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
		this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
		this.RewardListComponent.RefreshItemLayout(previewReward, null);
	}

	// Token: 0x0600884F RID: 34895 RVA: 0x0023F410 File Offset: 0x0023D610
	private void RefreshFunctionalComponent()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null);
		this.FunctionalComponent.FunctionButton.SetText(localTextNew);
		this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.JumpFunction));
		int loopTowerIsClickSeason = ModelBase<TowerModel>.Instance.GetLoopTowerIsClickSeason();
		this.FunctionalComponent.SetFunctionRedDotVisible(loopTowerIsClickSeason < ModelBase<TowerModel>.Instance.CurrentSeason);
	}

	// Token: 0x06008850 RID: 34896 RVA: 0x0023F47C File Offset: 0x0023D67C
	private void RefreshNewSeasonTip()
	{
		int player = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.LoopTowerSeason, -1);
		int currentSeason = ModelBase<TowerModel>.Instance.CurrentSeason;
		bool flag = player != currentSeason;
		ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
		if (functionalComponent != null)
		{
			functionalComponent.SetPanelTipVisible(flag);
		}
		if (flag)
		{
			ActivityFunctionalTypeA functionalComponent2 = this.FunctionalComponent;
			if (functionalComponent2 != null)
			{
				functionalComponent2.SetPanelTipByTextId("CycleTowerNewPeriod", Array.Empty<string>());
			}
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.LoopTowerSeason, currentSeason);
		}
	}

	// Token: 0x06008851 RID: 34897 RVA: 0x0023F4E4 File Offset: 0x0023D6E4
	private void RefreshStarNumber()
	{
		TowerModel instance = ModelBase<TowerModel>.Instance;
		int difficultyMaxStars = instance.GetDifficultyMaxStars(3, false);
		int difficultyAllStars = instance.GetDifficultyAllStars(3, false);
		base.GetText(6).SetText(difficultyMaxStars.ToString() + "/" + difficultyAllStars.ToString(), true);
	}

	// Token: 0x06008852 RID: 34898 RVA: 0x0023F52C File Offset: 0x0023D72C
	private void JumpFunction()
	{
		ControllerBase<TowerController>.Instance.OpenTowerView(false);
	}

	// Token: 0x06008853 RID: 34899 RVA: 0x0023F53A File Offset: 0x0023D73A
	private void OnClickTowerShopBtn()
	{
		ModelBase<TowerModel>.Instance.SetLoopTowerIsClickShop(true);
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType.ActivityShop, 0);
	}

	// Token: 0x06008854 RID: 34900 RVA: 0x0023F568 File Offset: 0x0023D768
	private void OnClickTowerRewardBtn()
	{
		TowerModel instance = ModelBase<TowerModel>.Instance;
		if (((instance != null) ? instance.GetDifficultyRewardProgress(3) : 0f) == 1f)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("HaveAllReward", Array.Empty<object>());
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerRewardView, 3, delegate(bool success, int viewId)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonActivityView);
			if (viewByName == null)
			{
				return;
			}
			viewByName.AddChildViewById(viewId);
		});
	}

	// Token: 0x0400400B RID: 16395
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x0400400C RID: 16396
	private ActivityDescriptionTypeA DescriptionComponent;

	// Token: 0x0400400D RID: 16397
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x0400400E RID: 16398
	private ActivityFunctionalTypeA FunctionalComponent;

	// Token: 0x0400400F RID: 16399
	private bool NeedTick = true;

	// Token: 0x02007713 RID: 30483
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029026 RID: 167974
		public const int TitleItem = 0;

		// Token: 0x04029027 RID: 167975
		public const int DescriptionItem = 1;

		// Token: 0x04029028 RID: 167976
		public const int RewardListItem = 2;

		// Token: 0x04029029 RID: 167977
		public const int FunctionArea = 3;

		// Token: 0x0402902A RID: 167978
		public const int TowerShopBtn = 4;

		// Token: 0x0402902B RID: 167979
		public const int TowerRewardBtn = 5;

		// Token: 0x0402902C RID: 167980
		public const int TowerProgressText = 6;

		// Token: 0x0402902D RID: 167981
		public const int ShopBtnRedDotItem = 7;

		// Token: 0x0402902E RID: 167982
		public const int RewardBtnRedDotItem = 8;
	}
}
