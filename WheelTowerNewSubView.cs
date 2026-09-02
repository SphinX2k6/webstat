using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016D5 RID: 5845
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerNewSubView : ActivitySubViewBase
{
	// Token: 0x0600A244 RID: 41540 RVA: 0x002AC294 File Offset: 0x002AA494
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A245 RID: 41541 RVA: 0x002AC408 File Offset: 0x002AA608
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerNewSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerNewSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A246 RID: 41542 RVA: 0x002AC44C File Offset: 0x002AA64C
	protected override void OnStart()
	{
		WheelTowerNewSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo != null)
		{
			commonActivityInfo.SetClickFunc(delegate(ActivityBaseData _)
			{
				this.OnClickEnter();
			});
		}
		WheelTowerNewSubViewGeneralInfo commonActivityInfo2 = this.CommonActivityInfo;
		if (commonActivityInfo2 != null)
		{
			commonActivityInfo2.SetBtnText("PrefabTextItem_3920397242_Text", Array.Empty<object>());
		}
		ActivityCircleButtonItem rewardButton = this.RewardButton;
		if (rewardButton != null)
		{
			rewardButton.SetOnClick(new Action(this.OnClickReward));
		}
		ActivityCircleButtonItem seasonRewardButton = this.SeasonRewardButton;
		if (seasonRewardButton != null)
		{
			seasonRewardButton.SetOnClick(new Action(this.OnClickSeasonReward));
		}
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIText text2 = base.GetText(9);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		this.OnRefreshView();
	}

	// Token: 0x0600A247 RID: 41543 RVA: 0x002AC4F8 File Offset: 0x002AA6F8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A248 RID: 41544 RVA: 0x002AC516 File Offset: 0x002AA716
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A249 RID: 41545 RVA: 0x002AC534 File Offset: 0x002AA734
	protected override void OnRefreshView()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		bool flag = wheelTowerData != null && wheelTowerData.IsUnLock();
		bool flag2 = wheelTowerData != null && wheelTowerData.IsInCycle();
		if (!flag || !flag2)
		{
			this.RefreshUnlockState();
			return;
		}
		this.RefreshRewardButton();
		this.RefreshFunctionButton();
		this.RefreshScorePanel();
		WheelTowerNewSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo == null)
		{
			return;
		}
		commonActivityInfo.OnRefreshView();
	}

	// Token: 0x0600A24A RID: 41546 RVA: 0x002AC596 File Offset: 0x002AA796
	protected override void OnTimer(float gap)
	{
		this.RefreshUnlockTimeText();
		this.CheckUpdateData();
	}

	// Token: 0x0600A24B RID: 41547 RVA: 0x002AC5A4 File Offset: 0x002AA7A4
	private void OnRedDotRefresh(int activityId)
	{
		ActivityBaseData activityBaseData = this.ActivityBaseData;
		int? num = (activityBaseData != null) ? new int?(activityBaseData.Id) : null;
		if (!(activityId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.OnRefreshView();
	}

	// Token: 0x0600A24C RID: 41548 RVA: 0x002AC5EC File Offset: 0x002AA7EC
	private bool ShouldUpdateData()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData == null || this.IsUpdatingData)
		{
			return false;
		}
		double cycleBeginTime = wheelTowerData.CycleBeginTime;
		double cycleEndTime = wheelTowerData.CycleEndTime;
		return (cycleBeginTime != -1.0 || cycleEndTime != -1.0) && (Singleton<TimeUtil>.Instance.GetServerTime() > cycleEndTime || (wheelTowerData.IsUnLock() && wheelTowerData.IsInCycleTime() && !wheelTowerData.IsInCycle()));
	}

	// Token: 0x0600A24D RID: 41549 RVA: 0x002AC662 File Offset: 0x002AA862
	private void CheckUpdateData()
	{
		if (!this.ShouldUpdateData())
		{
			return;
		}
		this.IsUpdatingData = true;
		ControllerBase<ActivityController>.Instance.RequestActivityData().ContinueWith((bool result) => this.IsUpdatingData = false);
	}

	// Token: 0x0600A24E RID: 41550 RVA: 0x002AC690 File Offset: 0x002AA890
	private UniTask CheckUpdateDataAsync()
	{
		WheelTowerNewSubView.<CheckUpdateDataAsync>d__14 <CheckUpdateDataAsync>d__;
		<CheckUpdateDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckUpdateDataAsync>d__.<>4__this = this;
		<CheckUpdateDataAsync>d__.<>1__state = -1;
		<CheckUpdateDataAsync>d__.<>t__builder.Start<WheelTowerNewSubView.<CheckUpdateDataAsync>d__14>(ref <CheckUpdateDataAsync>d__);
		return <CheckUpdateDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A24F RID: 41551 RVA: 0x002AC6D4 File Offset: 0x002AA8D4
	private void RefreshUnlockState()
	{
		ActivityCircleButtonItem seasonRewardButton = this.SeasonRewardButton;
		if (seasonRewardButton != null)
		{
			seasonRewardButton.SetUiActive(false);
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(7);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		WheelTowerNewSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
		ActivityFunctionalTypeA activityFunctionalTypeA = (commonActivityInfo != null) ? commonActivityInfo.GetFunctional() : null;
		if (activityFunctionalTypeA != null)
		{
			ActivityButtonItem functionButton = activityFunctionalTypeA.FunctionButton;
			if (functionButton != null)
			{
				functionButton.SetUiActive(false);
			}
		}
		if (activityFunctionalTypeA != null)
		{
			FunctionalPanelConditionLock panelLock = activityFunctionalTypeA.PanelLock;
			if (panelLock != null)
			{
				panelLock.SetUiActive(true);
			}
		}
		this.RefreshUnlockTimeText();
	}

	// Token: 0x0600A250 RID: 41552 RVA: 0x002AC774 File Offset: 0x002AA974
	private void RefreshUnlockTimeText()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData != null && wheelTowerData.IsInCycleTime())
		{
			WheelTowerNewSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
			if (commonActivityInfo == null)
			{
				return;
			}
			commonActivityInfo.RefreshFunction();
			return;
		}
		else
		{
			WheelTowerNewSubViewGeneralInfo commonActivityInfo2 = this.CommonActivityInfo;
			if (commonActivityInfo2 != null)
			{
				ActivityFunctionalTypeA functional = commonActivityInfo2.GetFunctional();
				if (functional != null)
				{
					functional.SetLockConditionButtonVisible(false);
				}
			}
			string nextCycleRemainTime = ModelBase<WheelTowerModel>.Instance.GetNextCycleRemainTime();
			if (string.IsNullOrEmpty(nextCycleRemainTime))
			{
				WheelTowerNewSubViewGeneralInfo commonActivityInfo3 = this.CommonActivityInfo;
				if (commonActivityInfo3 == null)
				{
					return;
				}
				ActivityFunctionalTypeA functional2 = commonActivityInfo3.GetFunctional();
				if (functional2 == null)
				{
					return;
				}
				functional2.SetLockTextByTextId("WheelTower_NonCycle", Array.Empty<string>());
				return;
			}
			else
			{
				WheelTowerNewSubViewGeneralInfo commonActivityInfo4 = this.CommonActivityInfo;
				if (commonActivityInfo4 == null)
				{
					return;
				}
				ActivityFunctionalTypeA functional3 = commonActivityInfo4.GetFunctional();
				if (functional3 == null)
				{
					return;
				}
				functional3.SetLockTextByTextId("WheelTower_TimeLimit", new string[]
				{
					nextCycleRemainTime
				});
				return;
			}
		}
	}

	// Token: 0x0600A251 RID: 41553 RVA: 0x002AC82C File Offset: 0x002AAA2C
	private void RefreshRewardButton()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		bool flag = wheelTowerData != null && wheelTowerData.IsUnLock();
		ActivityCircleButtonItem rewardButton = this.RewardButton;
		if (rewardButton != null)
		{
			rewardButton.SetUiActive(flag);
		}
		ActivityCircleButtonItem seasonRewardButton = this.SeasonRewardButton;
		if (seasonRewardButton != null)
		{
			seasonRewardButton.SetUiActive(flag);
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (!flag || wheelTowerData == null)
		{
			return;
		}
		ActivityCircleButtonItem seasonRewardButton2 = this.SeasonRewardButton;
		if (seasonRewardButton2 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(wheelTowerData.GetReceivedSeasonRewardIds().Count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(wheelTowerData.GetSeasonTaskList().Count);
			seasonRewardButton2.SetSubText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		ActivityCircleButtonItem seasonRewardButton3 = this.SeasonRewardButton;
		if (seasonRewardButton3 != null)
		{
			seasonRewardButton3.SetRedDotVisible(wheelTowerData.ShouldShowSeasonRewardRedDot());
		}
		ActivityCircleButtonItem rewardButton2 = this.RewardButton;
		if (rewardButton2 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(wheelTowerData.GetCurrentRewardProgress(EFilterMode.All));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(wheelTowerData.GetTotalRewardProgress(EFilterMode.All));
			rewardButton2.SetSubText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		ActivityCircleButtonItem rewardButton3 = this.RewardButton;
		if (rewardButton3 == null)
		{
			return;
		}
		rewardButton3.SetRedDotVisible(wheelTowerData.ShouldShowRewardRedDot());
	}

	// Token: 0x0600A252 RID: 41554 RVA: 0x002AC958 File Offset: 0x002AAB58
	private void RefreshFunctionButton()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData == null)
		{
			return;
		}
		bool functionRedDotVisible = wheelTowerData.CheckFirstOpenPage() || ModelBase<WheelTowerModel>.Instance.HasUnreadSeasonMedalRedDot(wheelTowerData.SeasonId);
		WheelTowerNewSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo == null)
		{
			return;
		}
		commonActivityInfo.SetFunctionRedDotVisible(functionRedDotVisible);
	}

	// Token: 0x0600A253 RID: 41555 RVA: 0x002AC9A4 File Offset: 0x002AABA4
	private void RefreshScorePanel()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData == null)
		{
			return;
		}
		bool flag = wheelTowerData.IsLevelUnlocked(true);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(7);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		int totalScore = wheelTowerData.GetTotalScore(flag);
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.SetText(totalScore.ToString(), true);
		}
		UUIText text2 = base.GetText(8);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(totalScore.ToString(), true);
	}

	// Token: 0x0600A254 RID: 41556 RVA: 0x002ACA2D File Offset: 0x002AAC2D
	private void OnClickEnter()
	{
		if (!ModelBase<WheelTowerModel>.Instance.ActivityData.IsTowerUnlocked())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WheelTower_TowerLocked", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerMainView, null, null);
	}

	// Token: 0x0600A255 RID: 41557 RVA: 0x002ACA66 File Offset: 0x002AAC66
	private void OnClickSeasonReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerSeasonRewardView, null, delegate(bool success, int viewId)
		{
			if (success)
			{
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonActivityView);
				if (viewByName == null)
				{
					return;
				}
				viewByName.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x0600A256 RID: 41558 RVA: 0x002ACA97 File Offset: 0x002AAC97
	private void OnClickReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerLimitRewardView, null, delegate(bool success, int viewId)
		{
			if (success)
			{
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonActivityView);
				if (viewByName == null)
				{
					return;
				}
				viewByName.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x04004C95 RID: 19605
	private WheelTowerNewSubViewGeneralInfo CommonActivityInfo;

	// Token: 0x04004C96 RID: 19606
	private ActivityCircleButtonItem SeasonRewardButton;

	// Token: 0x04004C97 RID: 19607
	private ActivityCircleButtonItem RewardButton;

	// Token: 0x04004C98 RID: 19608
	private bool IsUpdatingData;
}
