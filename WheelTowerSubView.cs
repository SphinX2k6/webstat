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

// Token: 0x02001702 RID: 5890
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerSubView : ActivitySubViewBase
{
	// Token: 0x0600A32A RID: 41770 RVA: 0x002B1974 File Offset: 0x002AFB74
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A32B RID: 41771 RVA: 0x002B1A20 File Offset: 0x002AFC20
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A32C RID: 41772 RVA: 0x002B1A64 File Offset: 0x002AFC64
	protected override void OnStart()
	{
		WheelTowerSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo != null)
		{
			commonActivityInfo.SetClickFunc(delegate(ActivityBaseData _)
			{
				this.OnClickEnter();
			});
		}
		WheelTowerSubViewGeneralInfo commonActivityInfo2 = this.CommonActivityInfo;
		if (commonActivityInfo2 != null)
		{
			commonActivityInfo2.SetBtnText("PrefabTextItem_3920397242_Text", Array.Empty<object>());
		}
		ActivityCircleButtonItem rewardButton = this.RewardButton;
		if (rewardButton != null)
		{
			rewardButton.SetOnClick(new Action(this.OnClickReward));
		}
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData != null)
		{
			wheelTowerData.ReadRedDot();
		}
		this.OnRefreshView();
	}

	// Token: 0x0600A32D RID: 41773 RVA: 0x002B1AE2 File Offset: 0x002AFCE2
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A32E RID: 41774 RVA: 0x002B1B00 File Offset: 0x002AFD00
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A32F RID: 41775 RVA: 0x002B1B20 File Offset: 0x002AFD20
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
		WheelTowerSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo == null)
		{
			return;
		}
		commonActivityInfo.OnRefreshView();
	}

	// Token: 0x0600A330 RID: 41776 RVA: 0x002B1B7C File Offset: 0x002AFD7C
	protected override void OnTimer(float gap)
	{
		this.RefreshUnlockTimeText();
		this.CheckUpdateData();
	}

	// Token: 0x0600A331 RID: 41777 RVA: 0x002B1B8C File Offset: 0x002AFD8C
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

	// Token: 0x0600A332 RID: 41778 RVA: 0x002B1BD4 File Offset: 0x002AFDD4
	private bool ShouldUpdateData()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData == null || this.IsUpdatingData)
		{
			return false;
		}
		double cycleBeginTime = wheelTowerData.CycleBeginTime;
		double cycleEndTime = wheelTowerData.CycleEndTime;
		if (cycleBeginTime == -1.0 && cycleEndTime == -1.0)
		{
			return false;
		}
		if (Singleton<TimeUtil>.Instance.GetServerTime() > cycleEndTime)
		{
			return true;
		}
		bool flag = wheelTowerData.IsUnLock();
		bool flag2 = wheelTowerData.IsInCycleTime();
		bool flag3 = wheelTowerData.IsInCycle();
		return flag && flag2 && !flag3;
	}

	// Token: 0x0600A333 RID: 41779 RVA: 0x002B1C55 File Offset: 0x002AFE55
	private void CheckUpdateData()
	{
		if (!this.ShouldUpdateData())
		{
			return;
		}
		this.IsUpdatingData = true;
		ControllerBase<ActivityController>.Instance.RequestActivityData().ContinueWith((bool result) => this.IsUpdatingData = false);
	}

	// Token: 0x0600A334 RID: 41780 RVA: 0x002B1C84 File Offset: 0x002AFE84
	private UniTask CheckUpdateDataAsync()
	{
		WheelTowerSubView.<CheckUpdateDataAsync>d__15 <CheckUpdateDataAsync>d__;
		<CheckUpdateDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckUpdateDataAsync>d__.<>4__this = this;
		<CheckUpdateDataAsync>d__.<>1__state = -1;
		<CheckUpdateDataAsync>d__.<>t__builder.Start<WheelTowerSubView.<CheckUpdateDataAsync>d__15>(ref <CheckUpdateDataAsync>d__);
		return <CheckUpdateDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A335 RID: 41781 RVA: 0x002B1CC8 File Offset: 0x002AFEC8
	private void RefreshUnlockState()
	{
		ActivityCircleButtonItem rewardButton = this.RewardButton;
		if (rewardButton != null)
		{
			rewardButton.SetUiActive(false);
		}
		WheelTowerSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
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

	// Token: 0x0600A336 RID: 41782 RVA: 0x002B1D30 File Offset: 0x002AFF30
	private void RefreshUnlockTimeText()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData != null && wheelTowerData.IsInCycleTime())
		{
			WheelTowerSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
			if (commonActivityInfo == null)
			{
				return;
			}
			commonActivityInfo.RefreshFunction();
			return;
		}
		else
		{
			WheelTowerSubViewGeneralInfo commonActivityInfo2 = this.CommonActivityInfo;
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
				WheelTowerSubViewGeneralInfo commonActivityInfo3 = this.CommonActivityInfo;
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
				WheelTowerSubViewGeneralInfo commonActivityInfo4 = this.CommonActivityInfo;
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

	// Token: 0x0600A337 RID: 41783 RVA: 0x002B1DE8 File Offset: 0x002AFFE8
	private void RefreshRewardButton()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		bool flag = wheelTowerData != null && wheelTowerData.IsUnLock();
		ActivityCircleButtonItem rewardButton = this.RewardButton;
		if (rewardButton != null)
		{
			rewardButton.SetUiActive(flag);
		}
		if (!flag || wheelTowerData == null)
		{
			return;
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
		if (rewardButton3 != null)
		{
			rewardButton3.SetRedDotVisible(wheelTowerData.ShouldShowRewardRedDot());
		}
		WheelTowerProgressBar normalProgress = this.NormalProgress;
		if (normalProgress != null)
		{
			normalProgress.Refresh(wheelTowerData.GetTotalScore(false));
		}
		WheelTowerProgressBar endlessProgress = this.EndlessProgress;
		if (endlessProgress == null)
		{
			return;
		}
		endlessProgress.Refresh(wheelTowerData.GetTotalScore(true));
	}

	// Token: 0x0600A338 RID: 41784 RVA: 0x002B1EB8 File Offset: 0x002B00B8
	private void RefreshFunctionButton()
	{
		WheelTowerData wheelTowerData = this.ActivityBaseData as WheelTowerData;
		if (wheelTowerData == null)
		{
			return;
		}
		WheelTowerSubViewGeneralInfo commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo == null)
		{
			return;
		}
		commonActivityInfo.SetFunctionRedDotVisible(wheelTowerData.HasAnyLevelRedDot());
	}

	// Token: 0x0600A339 RID: 41785 RVA: 0x002B1EEB File Offset: 0x002B00EB
	private void OnClickEnter()
	{
		if (!ModelBase<WheelTowerModel>.Instance.ActivityData.IsTowerUnlocked())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WheelTower_TowerLocked", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerModeSelectView, null, null);
	}

	// Token: 0x0600A33A RID: 41786 RVA: 0x002B1F24 File Offset: 0x002B0124
	private void OnClickReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerRewardView, null, delegate(bool success, int viewId)
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

	// Token: 0x04004DAE RID: 19886
	private WheelTowerSubViewGeneralInfo CommonActivityInfo;

	// Token: 0x04004DAF RID: 19887
	private ActivityCircleButtonItem RewardButton;

	// Token: 0x04004DB0 RID: 19888
	private WheelTowerProgressBar NormalProgress;

	// Token: 0x04004DB1 RID: 19889
	private WheelTowerProgressBar EndlessProgress;

	// Token: 0x04004DB2 RID: 19890
	private bool IsUpdatingData;
}
