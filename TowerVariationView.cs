using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C0B RID: 11275
[NullableContext(2)]
[Nullable(0)]
public class TowerVariationView : UiTickViewBase
{
	// Token: 0x060167DB RID: 92123 RVA: 0x006409C9 File Offset: 0x0063EBC9
	[NullableContext(1)]
	public TowerVariationView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060167DC RID: 92124 RVA: 0x006409E4 File Offset: 0x0063EBE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRewardBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickChangeTowerBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickShopBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060167DD RID: 92125 RVA: 0x00640C40 File Offset: 0x0063EE40
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRewardReceived, new Action(this.RefreshRewardProgress));
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerReviewGoToReward, new Action(this.OnTowerReviewGoToReward));
	}

	// Token: 0x060167DE RID: 92126 RVA: 0x00640C7A File Offset: 0x0063EE7A
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRewardReceived, new Action(this.RefreshRewardProgress));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerReviewGoToReward, new Action(this.OnTowerReviewGoToReward));
	}

	// Token: 0x060167DF RID: 92127 RVA: 0x00640CB4 File Offset: 0x0063EEB4
	protected override void OnBeforeShow()
	{
		ModelBase<TowerModel>.Instance.CurrentSelectDifficulties = 3;
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TowerReward, base.GetItem(5), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.TowerRewardByDifficulties, base.GetItem(8), null, 5);
		this.RefreshRewardProgress();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotTowerReward);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, 5);
		bool flag = !ModelBase<TowerModel>.Instance.GetOverLockHasShow();
		bool difficultyIsClear = ModelBase<TowerModel>.Instance.GetDifficultyIsClear(3);
		if (flag && difficultyIsClear)
		{
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(true);
			}
		}
		this.UpdateShareBtnItem();
	}

	// Token: 0x060167E0 RID: 92128 RVA: 0x00640D53 File Offset: 0x0063EF53
	protected override void OnBeforeDestroy()
	{
		this.TitleItem.Destroy(null);
		this.TitleItem = null;
		ControllerBase<InstanceDungeonEntranceController>.Instance.RestoreDungeonEntranceEntity();
	}

	// Token: 0x060167E1 RID: 92129 RVA: 0x00640D74 File Offset: 0x0063EF74
	private UniTask BackToBattleView()
	{
		TowerVariationView.<BackToBattleView>d__13 <BackToBattleView>d__;
		<BackToBattleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BackToBattleView>d__.<>4__this = this;
		<BackToBattleView>d__.<>1__state = -1;
		<BackToBattleView>d__.<>t__builder.Start<TowerVariationView.<BackToBattleView>d__13>(ref <BackToBattleView>d__);
		return <BackToBattleView>d__.<>t__builder.Task;
	}

	// Token: 0x060167E2 RID: 92130 RVA: 0x00640DB8 File Offset: 0x0063EFB8
	protected override UniTask OnBeforeStartAsync()
	{
		TowerVariationView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TowerVariationView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060167E3 RID: 92131 RVA: 0x00640DFC File Offset: 0x0063EFFC
	protected override void OnStart()
	{
		ModelBase<TowerModel>.Instance.SetLoopTowerIsClickSeason(ModelBase<TowerModel>.Instance.CurrentSeason);
		ActivityLoopTowerData activityLoopTowerData = ModelBase<ActivityModel>.Instance.GetActivityById(100300002) as ActivityLoopTowerData;
		bool hasRedPointAfter = activityLoopTowerData != null && activityLoopTowerData.RedPointShowState;
		AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
		if (instance != null)
		{
			instance.ReportPeriodicActivityRedClear(EDungeonSubType.LoopTower, hasRedPointAfter);
		}
		if (ModelBase<TowerModel>.Instance.CheckInTower())
		{
			ControllerBase<TowerController>.Instance.ClearAllHatredInTower();
		}
		this.IsHighRiskClear = ModelBase<TowerModel>.Instance.GetDifficultyIsClear(2);
		ModelBase<TowerModel>.Instance.CurrentSelectDifficulties = 3;
		this.TitleItem = new TowerTitleItem(base.GetItem(0), delegate()
		{
			if (ModelBase<TowerModel>.Instance.CheckInTower())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.LeaveTowerOnTowerView);
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ControllerBase<TowerController>.Instance.LeaveTower();
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.BackToBattleView();
		});
		this.TitleItem.RefreshText("InstanceDungeonTitle_31_CommonText", Array.Empty<string>());
		CommonDefine.ICountDown seasonCountDownData = ModelBase<TowerModel>.Instance.GetSeasonCountDownData();
		base.GetText(4).SetText(seasonCountDownData.CountDownText, true);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, 3);
		ModelBase<TowerModel>.Instance.CurrentTowerLock = !this.IsHighRiskClear;
		int[] difficultyAllAreaFirstFloor = ModelBase<TowerModel>.Instance.GetDifficultyAllAreaFirstFloor(3, false);
		for (int i = 0; i < this.TowerAreaList.Count; i++)
		{
			this.TowerAreaList[i].Refresh(difficultyAllAreaFirstFloor[i], false, i);
		}
		this.AddHomeBtnExtraCallback();
	}

	// Token: 0x060167E4 RID: 92132 RVA: 0x00640F38 File Offset: 0x0063F138
	private void UpdateShareBtnItem()
	{
		if (this.ShareBtnItem == null)
		{
			return;
		}
		int num = 0;
		int[] array = new int[]
		{
			0,
			2
		};
		int[] difficultyAllAreaFirstFloor = ModelBase<TowerModel>.Instance.GetDifficultyAllAreaFirstFloor(3, false);
		foreach (int num2 in array)
		{
			if (difficultyAllAreaFirstFloor.Length > num2)
			{
				TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(difficultyAllAreaFirstFloor[num2]);
				int areaAllStars = ModelBase<TowerModel>.Instance.GetAreaAllStars(towerInfo.Value.Difficulty, towerInfo.Value.AreaNum);
				num = ((ModelBase<TowerModel>.Instance.GetAreaStars(towerInfo.Value.Difficulty, towerInfo.Value.AreaNum, false) >= areaAllStars) ? (num + 1) : num);
			}
		}
		bool flag = num >= array.Length;
		ShareBtnItem shareBtnItem = this.ShareBtnItem;
		if (shareBtnItem != null)
		{
			shareBtnItem.SetUiActive(flag);
		}
		if (flag)
		{
			this.ShareBtnItem.SetShareActionId(EShareActionId.TowerVariation);
			this.ShareBtnItem.SetClickCallBack(delegate
			{
				PhotoSaveViewParam param = new PhotoSaveViewParam
				{
					ScreenShot = false,
					IsHiddenBattleView = false,
					ShareId = 14
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
			});
		}
	}

	// Token: 0x060167E5 RID: 92133 RVA: 0x0064105C File Offset: 0x0063F25C
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			TowerVariationView.<>c.<<AddHomeBtnExtraCallback>b__17_0>d <<AddHomeBtnExtraCallback>b__17_0>d;
			<<AddHomeBtnExtraCallback>b__17_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__17_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__17_0>d.<>t__builder.Start<TowerVariationView.<>c.<<AddHomeBtnExtraCallback>b__17_0>d>(ref <<AddHomeBtnExtraCallback>b__17_0>d);
			return <<AddHomeBtnExtraCallback>b__17_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x060167E6 RID: 92134 RVA: 0x0064108D File Offset: 0x0063F28D
	protected override void OnBeforeHide()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.TowerReward, base.GetItem(5), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.TowerRewardByDifficulties, base.GetItem(8), 5);
	}

	// Token: 0x060167E7 RID: 92135 RVA: 0x006410B8 File Offset: 0x0063F2B8
	private void OnClickRewardBtn()
	{
		TowerModel instance = ModelBase<TowerModel>.Instance;
		float? num = (instance != null) ? new float?(instance.GetDifficultyRewardProgress(ModelBase<TowerModel>.Instance.CurrentSelectDifficulties)) : null;
		float num2 = (float)1;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("HaveAllReward", Array.Empty<object>());
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerRewardView, null, delegate(bool success, int viewId)
		{
			base.AddChildViewById(viewId);
		});
	}

	// Token: 0x060167E8 RID: 92136 RVA: 0x00641135 File Offset: 0x0063F335
	private void OnTowerReviewGoToReward()
	{
		this.OnClickRewardBtn();
	}

	// Token: 0x060167E9 RID: 92137 RVA: 0x00641140 File Offset: 0x0063F340
	private void OnClickChangeTowerBtn()
	{
		if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TowerNormalView) != null)
		{
			base.CloseMe(null);
			return;
		}
		Singleton<UiManager>.Instance.OpenViewAsync(EUiViewName.TowerNormalView, null, null);
	}

	// Token: 0x060167EA RID: 92138 RVA: 0x00641180 File Offset: 0x0063F380
	private void OnClickShopBtn()
	{
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType.ActivityShop, 0);
	}

	// Token: 0x060167EB RID: 92139 RVA: 0x0064118E File Offset: 0x0063F38E
	protected override void OnTick(float deltaTime)
	{
		if (this.NeedTick)
		{
			this.RefreshCountDown();
		}
	}

	// Token: 0x060167EC RID: 92140 RVA: 0x006411A0 File Offset: 0x0063F3A0
	private void RefreshCountDown()
	{
		string countDownText = ModelBase<TowerModel>.Instance.GetSeasonCountDownData().CountDownText;
		if (this.CountDownString != countDownText)
		{
			this.CountDownString = countDownText;
			base.GetText(4).SetText(countDownText, true);
		}
		if ((double)ModelBase<TowerModel>.Instance.TowerEndTime.GetValueOrDefault() - Singleton<TimeUtil>.Instance.GetServerTime() <= 1.0)
		{
			this.NeedTick = false;
			Singleton<UiManager>.Instance.ResetToBattleView(delegate(bool _)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CycleTowerSeasonRefresh);
				Action value = delegate()
				{
					if (ModelBase<TowerModel>.Instance.CheckInTower())
					{
						ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
					}
				};
				confirmBoxDataNew.FunctionMap.Add(1, value);
				confirmBoxDataNew.FunctionMap.Add(2, value);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			});
		}
	}

	// Token: 0x060167ED RID: 92141 RVA: 0x00641238 File Offset: 0x0063F438
	private void RefreshRewardProgress()
	{
		TowerModel instance = ModelBase<TowerModel>.Instance;
		float? num = (instance != null) ? new float?(instance.GetDifficultyRewardProgress(3)) : null;
		UUISprite sprite = base.GetSprite(6);
		if (sprite != null)
		{
			sprite.SetFillAmount(num.Value);
		}
		float? num2 = num;
		float num3 = (float)1;
		if (num2.GetValueOrDefault() == num3 & num2 != null)
		{
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(true);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(10);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(11);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0400AE04 RID: 44548
	private bool IsHighRiskClear;

	// Token: 0x0400AE05 RID: 44549
	private bool NeedTick = true;

	// Token: 0x0400AE06 RID: 44550
	private string CountDownString;

	// Token: 0x0400AE07 RID: 44551
	private TowerTitleItem TitleItem;

	// Token: 0x0400AE08 RID: 44552
	private ShareBtnItem ShareBtnItem;

	// Token: 0x0400AE09 RID: 44553
	[Nullable(1)]
	private readonly List<TowerAreaItem> TowerAreaList = new List<TowerAreaItem>();

	// Token: 0x02008F0A RID: 36618
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x040300CD RID: 196813
		TitleItem,
		// Token: 0x040300CE RID: 196814
		TowerLayout,
		// Token: 0x040300CF RID: 196815
		RewardBtn,
		// Token: 0x040300D0 RID: 196816
		ChangeTowerBtn,
		// Token: 0x040300D1 RID: 196817
		RemainTimeText,
		// Token: 0x040300D2 RID: 196818
		RedDotItem,
		// Token: 0x040300D3 RID: 196819
		RewardProgressSprite,
		// Token: 0x040300D4 RID: 196820
		ShopBtn,
		// Token: 0x040300D5 RID: 196821
		LowAndHighRiskRedDotItem,
		// Token: 0x040300D6 RID: 196822
		RewardShowItem,
		// Token: 0x040300D7 RID: 196823
		RewardDownItem,
		// Token: 0x040300D8 RID: 196824
		RewardDownBgItem,
		// Token: 0x040300D9 RID: 196825
		ShareBtnItem
	}
}
