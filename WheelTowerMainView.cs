using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016CE RID: 5838
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerMainView : UiTickViewBase
{
	// Token: 0x0600A1FF RID: 41471 RVA: 0x002AA238 File Offset: 0x002A8438
	[NullableContext(1)]
	public WheelTowerMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A200 RID: 41472 RVA: 0x002AA244 File Offset: 0x002A8444
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnSeasonTipsBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnSeasonMedalsBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A201 RID: 41473 RVA: 0x002AA4E8 File Offset: 0x002A86E8
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A202 RID: 41474 RVA: 0x002AA52B File Offset: 0x002A872B
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A203 RID: 41475 RVA: 0x002AA549 File Offset: 0x002A8749
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
	}

	// Token: 0x0600A204 RID: 41476 RVA: 0x002AA568 File Offset: 0x002A8768
	protected override void OnStart()
	{
		UiSequencePlayer bgSequencePlayer = this.BgSequencePlayer;
		if (bgSequencePlayer != null)
		{
			bgSequencePlayer.PlayOrReplaySequenceByName("SpineStart", false, null);
		}
		this.TryTriggerSeasonReview();
	}

	// Token: 0x0600A205 RID: 41477 RVA: 0x002AA59C File Offset: 0x002A879C
	protected override void OnBeforeShow()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		WheelTowerData activityData = instance.ActivityData;
		this.RefreshRewardBtn();
		NewTowerParam towerConfig = instance.GetTowerConfig();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), towerConfig.CycleName, Array.Empty<object>());
		if (activityData.SeasonId != 0)
		{
			NewTowerSeason? seasonConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonConfig(activityData.SeasonId);
			if (seasonConfig != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), seasonConfig.Value.Name, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "WheelTower_SeasonReward_EndVersion", new <>z__ReadOnlySingleElementList<object>(seasonConfig.Value.EndVersionId));
				base.SetTextureByPath(seasonConfig.Value.VersionIconMain, base.GetTexture(1), null, null);
				UUIButtonComponent button = base.GetButton(12);
				if (button != null)
				{
					UUIItem rootComponent = button.GetRootComponent();
					if (rootComponent != null)
					{
						rootComponent.SetUIActive(seasonConfig.Value.InfoDisplayId != 0);
					}
				}
			}
		}
		ActivityCircleButtonItem bossHandBookButton = this.BossHandBookButton;
		if (bossHandBookButton != null)
		{
			bossHandBookButton.SetRedDotVisible(activityData.HasBossHandBookRedDot());
		}
		ActivityCircleButtonItem roleButton = this.RoleButton;
		if (roleButton != null)
		{
			roleButton.SetRedDotVisible(false);
		}
		WheelTowerNormalModeBtn normalModeBtn = this.NormalModeBtn;
		if (normalModeBtn != null)
		{
			normalModeBtn.Refresh();
		}
		WheelTowerEndlessModeBtn endlessModeBtn = this.EndlessModeBtn;
		if (endlessModeBtn != null)
		{
			endlessModeBtn.Refresh();
		}
		this.RefreshSeasonMedalRedDot();
	}

	// Token: 0x0600A206 RID: 41478 RVA: 0x002AA700 File Offset: 0x002A8900
	private void RefreshSeasonMedalRedDot()
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		int seasonId = (activityData != null) ? activityData.SeasonId : 0;
		bool uiactive = ModelBase<WheelTowerModel>.Instance.HasUnreadSeasonMedalRedDot(seasonId);
		UUIItem item = base.GetItem(14);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600A207 RID: 41479 RVA: 0x002AA744 File Offset: 0x002A8944
	protected override void OnTick(float delta)
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		string text = ConfigMultiTextLang.GetLocalTextNew("WheelTower_CycleReward_RemainTime", null) ?? "";
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(activityData.EndShowTime, text);
		UUIText text2 = base.GetText(3);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(remainTimeText, true);
	}

	// Token: 0x0600A208 RID: 41480 RVA: 0x002AA798 File Offset: 0x002A8998
	private void RefreshRewardBtn()
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		int count = activityData.GetReceivedSeasonRewardIds().Count;
		int count2 = activityData.GetSeasonTaskList().Count;
		ActivityCircleButtonItem seasonRewardButton = this.SeasonRewardButton;
		if (seasonRewardButton != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(count2);
			seasonRewardButton.SetSubText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		ActivityCircleButtonItem seasonRewardButton2 = this.SeasonRewardButton;
		if (seasonRewardButton2 != null)
		{
			seasonRewardButton2.SetRedDotVisible(activityData.ShouldShowSeasonRewardRedDot());
		}
		int currentRewardProgress = activityData.GetCurrentRewardProgress(EFilterMode.All);
		int totalRewardProgress = activityData.GetTotalRewardProgress(EFilterMode.All);
		ActivityCircleButtonItem rewardButton = this.RewardButton;
		if (rewardButton != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(currentRewardProgress);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalRewardProgress);
			rewardButton.SetSubText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		ActivityCircleButtonItem rewardButton2 = this.RewardButton;
		if (rewardButton2 == null)
		{
			return;
		}
		rewardButton2.SetRedDotVisible(activityData.ShouldShowRewardRedDot());
	}

	// Token: 0x0600A209 RID: 41481 RVA: 0x002AA881 File Offset: 0x002A8A81
	private void OnSeasonRewardBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerSeasonRewardView, null, delegate(bool success, int viewId)
		{
			if (success)
			{
				base.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x0600A20A RID: 41482 RVA: 0x002AA89F File Offset: 0x002A8A9F
	private void OnRewardBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerLimitRewardView, null, delegate(bool success, int viewId)
		{
			if (success)
			{
				base.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x0600A20B RID: 41483 RVA: 0x002AA8BD File Offset: 0x002A8ABD
	private void OnCloseBtnClick()
	{
		if (ModelBase<WheelTowerModel>.Instance.CheckInInstanceDungeon())
		{
			ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(null, null, true);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A20C RID: 41484 RVA: 0x002AA8E0 File Offset: 0x002A8AE0
	private void OnBossHandBookBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerBossHandBookView, null, null);
		ModelBase<WheelTowerModel>.Instance.ActivityData.RecordOpenBossHandBook();
	}

	// Token: 0x0600A20D RID: 41485 RVA: 0x002AA902 File Offset: 0x002A8B02
	private void OnRoleBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerEnhanceRoleView, null, null);
	}

	// Token: 0x0600A20E RID: 41486 RVA: 0x002AA918 File Offset: 0x002A8B18
	private void OnSeasonTipsBtnClick()
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		int seasonId = (activityData != null) ? activityData.SeasonId : 0;
		NewTowerSeason? seasonConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonConfig(seasonId);
		if (seasonConfig == null)
		{
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(seasonConfig.Value.InfoDisplayId);
	}

	// Token: 0x0600A20F RID: 41487 RVA: 0x002AA96B File Offset: 0x002A8B6B
	private void OnSeasonMedalsBtnClick()
	{
		ControllerBase<WheelTowerController>.Instance.OpenSeasonMedalView(0, false);
	}

	// Token: 0x0600A210 RID: 41488 RVA: 0x002AA979 File Offset: 0x002A8B79
	private void OnRedDotRefresh(int activityId)
	{
		if (activityId != ModelBase<WheelTowerModel>.Instance.ActivityData.Id)
		{
			return;
		}
		this.RefreshRewardBtn();
		this.RefreshSeasonMedalRedDot();
	}

	// Token: 0x0600A211 RID: 41489 RVA: 0x002AA99A File Offset: 0x002A8B9A
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			WheelTowerMainView.<>c.<<AddHomeBtnExtraCallback>b__26_0>d <<AddHomeBtnExtraCallback>b__26_0>d;
			<<AddHomeBtnExtraCallback>b__26_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__26_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__26_0>d.<>t__builder.Start<WheelTowerMainView.<>c.<<AddHomeBtnExtraCallback>b__26_0>d>(ref <<AddHomeBtnExtraCallback>b__26_0>d);
			return <<AddHomeBtnExtraCallback>b__26_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0600A212 RID: 41490 RVA: 0x002AA9CC File Offset: 0x002A8BCC
	private void TryTriggerSeasonReview()
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		int num = (activityData != null) ? activityData.SeasonId : 0;
		if (num == 0)
		{
			return;
		}
		IReadOnlyList<NewTowerSeason> allSeasonConfigs = ConfigBase<WheelTowerConfig>.Instance.GetAllSeasonConfigs();
		if (allSeasonConfigs == null)
		{
			return;
		}
		int num2 = 0;
		foreach (NewTowerSeason newTowerSeason in allSeasonConfigs)
		{
			if (newTowerSeason.Id < num && newTowerSeason.Id > num2)
			{
				num2 = newTowerSeason.Id;
			}
		}
		if (num2 == 0)
		{
			return;
		}
		bool flag = ModelBase<WheelTowerModel>.Instance.GetSeasonMedalGroupList(num2, EWheelTowerMedalType.Season).Count > 0;
		bool flag2 = Singleton<Info>.Instance.IsBuildDevelopmentOrDebug && LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.IgnoreWheelTowerSeasonReviewMedalCheck, false);
		if (!flag && !flag2)
		{
			return;
		}
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.WheelTowerSeasonReview) as ServerStorageMap;
		if (serverStorageMap == null)
		{
			return;
		}
		int? num3 = serverStorageMap.Get(0);
		int num4 = num2;
		if (num3.GetValueOrDefault() == num4 & num3 != null)
		{
			return;
		}
		WheelTowerSeasonReviewViewData param = new WheelTowerSeasonReviewViewData
		{
			SeasonId = num2
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerSeasonReviewView, param, null);
		serverStorageMap.Set(0, num2);
		ModelBase<WheelTowerModel>.Instance.CleanOldSeasonMedalsStorage(num);
	}

	// Token: 0x04004C34 RID: 19508
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004C35 RID: 19509
	private ActivityCircleButtonItem SeasonRewardButton;

	// Token: 0x04004C36 RID: 19510
	private ActivityCircleButtonItem RewardButton;

	// Token: 0x04004C37 RID: 19511
	private ActivityCircleButtonItem BossHandBookButton;

	// Token: 0x04004C38 RID: 19512
	private ActivityCircleButtonItem RoleButton;

	// Token: 0x04004C39 RID: 19513
	private WheelTowerNormalModeBtn NormalModeBtn;

	// Token: 0x04004C3A RID: 19514
	private WheelTowerEndlessModeBtn EndlessModeBtn;

	// Token: 0x04004C3B RID: 19515
	private UiSequencePlayer BgSequencePlayer;
}
