using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016EE RID: 5870
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerRoundSelectView : UiViewBase
{
	// Token: 0x0600A2BB RID: 41659 RVA: 0x002AEE73 File Offset: 0x002AD073
	[NullableContext(1)]
	public WheelTowerRoundSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A2BC RID: 41660 RVA: 0x002AEE7C File Offset: 0x002AD07C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 20;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickSwitchLeft));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickSwitchRight));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickStart));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnClickReset));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A2BD RID: 41661 RVA: 0x002AF1EC File Offset: 0x002AD3EC
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerRoundSelectView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerRoundSelectView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A2BE RID: 41662 RVA: 0x002AF230 File Offset: 0x002AD430
	protected override void OnStart()
	{
		bool endlessMode = ModelBase<WheelTowerModel>.Instance.EndlessMode;
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(endlessMode);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(!endlessMode);
		}
		PopupCaptionItem caption = this.Caption;
		if (caption != null)
		{
			caption.SetCloseCallBack(new Action(this.OnClickClose));
		}
		PopupCaptionItem caption2 = this.Caption;
		if (caption2 != null)
		{
			caption2.SetTitleLocalText(endlessMode ? "WheelBattleMode_Endless" : "WheelBattleMode_Normal");
		}
		if (this.TeamItem != null)
		{
			this.TeamItem.ClickCallback = new Action(this.OnClickTeamItem);
		}
		UUIText text = base.GetText(14);
		if (text != null)
		{
			text.SetText(ModelBase<WheelTowerModel>.Instance.GetTowerConfig().DefaultCostEnergy.ToString(), true);
		}
		this.RefreshAll();
		ControllerBase<WheelTowerController>.Instance.TryOpenOverridePopupView(new Action(this.RefreshAll));
		ModelBase<WheelTowerModel>.Instance.ActivityData.RecordEnterLevel(endlessMode);
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		this.AddHomeBtnExtraCallback();
		if (endlessMode)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnEnterWheelTowerEndlessMode);
		}
	}

	// Token: 0x0600A2BF RID: 41663 RVA: 0x002AF351 File Offset: 0x002AD551
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600A2C0 RID: 41664 RVA: 0x002AF36C File Offset: 0x002AD56C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600A2C1 RID: 41665 RVA: 0x002AF387 File Offset: 0x002AD587
	protected override void OnBeforeShow()
	{
		this.RefreshSelectData();
	}

	// Token: 0x0600A2C2 RID: 41666 RVA: 0x002AF38F File Offset: 0x002AD58F
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.Clear();
	}

	// Token: 0x0600A2C3 RID: 41667 RVA: 0x002AF3A1 File Offset: 0x002AD5A1
	private void RefreshAll()
	{
		this.InitAttachTab();
		this.RefreshSwitchButtonInteractive();
		this.RefreshResetRecordButtonInteractive();
		this.RefreshDefaultRound();
	}

	// Token: 0x0600A2C4 RID: 41668 RVA: 0x002AF3BC File Offset: 0x002AD5BC
	private void RefreshDefaultRound()
	{
		int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
		int num = maxChallengeRound;
		object openParam = this.OpenParam;
		if (openParam is int)
		{
			int value = (int)openParam;
			num = Math.Clamp(value, 0, maxChallengeRound);
		}
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView = this.RoundTabAttachView;
		if (roundTabAttachView != null)
		{
			roundTabAttachView.AttachToIndex(num, true);
		}
		this.RefreshRound(num, true);
	}

	// Token: 0x0600A2C5 RID: 41669 RVA: 0x002AF41C File Offset: 0x002AD61C
	private void RefreshRound(int round, bool force = true)
	{
		if (!force && round == ModelBase<WheelTowerModel>.Instance.SelectedRound)
		{
			return;
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}
		ModelBase<WheelTowerModel>.Instance.UpdateSelectRound(round, force);
		this.RefreshSelectData();
		this.RefreshBossList(round);
		if (ModelBase<WheelTowerModel>.Instance.EndlessMode)
		{
			int roundBossRound = ModelBase<WheelTowerModel>.Instance.GetRoundBossRound(round);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "PrefabTextItem_414249711_Text", new <>z__ReadOnlySingleElementList<object>(roundBossRound));
		}
		else
		{
			UUIText text = base.GetText(17);
			if (text != null)
			{
				text.ShowTextNew("WheelTower_RoundSelect_NormalTips");
			}
		}
		RecordItem totalRecordItem = this.TotalRecordItem;
		if (totalRecordItem != null)
		{
			totalRecordItem.Refresh(true);
		}
		RecordItem currentRecordItem = this.CurrentRecordItem;
		if (currentRecordItem != null)
		{
			currentRecordItem.Refresh(false);
		}
		bool flag = ModelBase<WheelTowerModel>.Instance.IsRoundChallenged(round, null);
		UUIText text2 = base.GetText(19);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(flag ? "WheelTower_RoundSelect_Retry" : "WheelTower_RoundSelect_Start");
	}

	// Token: 0x0600A2C6 RID: 41670 RVA: 0x002AF524 File Offset: 0x002AD724
	private void RefreshResetRecordButtonInteractive()
	{
		bool uiactive = ModelBase<WheelTowerModel>.Instance.HasChallengeAnyRound(null);
		UUIButtonComponent button = base.GetButton(16);
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem = button.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(uiactive);
	}

	// Token: 0x0600A2C7 RID: 41671 RVA: 0x002AF56C File Offset: 0x002AD76C
	private void RefreshSwitchButtonInteractive()
	{
		int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
		UUIButtonComponent button = base.GetButton(4);
		if (button != null)
		{
			button.SetSelfInteractive(maxChallengeRound > 0);
		}
		UUIButtonComponent button2 = base.GetButton(5);
		if (button2 == null)
		{
			return;
		}
		button2.SetSelfInteractive(maxChallengeRound > 0);
	}

	// Token: 0x0600A2C8 RID: 41672 RVA: 0x002AF5B8 File Offset: 0x002AD7B8
	private void RefreshSelectData()
	{
		List<int> selectedRoleList = ModelBase<WheelTowerModel>.Instance.SelectedRoleList;
		List<RoleDataWithBranch> list = new List<RoleDataWithBranch>();
		for (int i = 0; i < ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount(); i++)
		{
			list.Add(new RoleDataWithBranch(0, 0));
		}
		for (int j = 0; j < selectedRoleList.Count; j++)
		{
			int roleId = selectedRoleList[j];
			int roleSkillBranchIdInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleId);
			list[j] = new RoleDataWithBranch(roleId, roleSkillBranchIdInCurrentGamePlay);
		}
		WheelTowerBuffItem buffItem = this.BuffItem;
		if (buffItem != null)
		{
			buffItem.Refresh(ModelBase<WheelTowerModel>.Instance.SelectedBuff);
		}
		WheelTowerTeamItem teamItem = this.TeamItem;
		if (teamItem != null)
		{
			teamItem.Refresh(list);
		}
		bool flag = ModelBase<WheelTowerModel>.Instance.CheckSelectTeamIsFull();
		bool flag2 = ModelBase<WheelTowerModel>.Instance.CheckSelectedIsConflict();
		UUIButtonComponent button = base.GetButton(15);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(flag && !flag2);
	}

	// Token: 0x0600A2C9 RID: 41673 RVA: 0x002AF69C File Offset: 0x002AD89C
	private void RefreshBossList(int round)
	{
		List<IBossInfo> bossRoundInfo = ModelBase<WheelTowerModel>.Instance.GetRoundBossInfo(round, null);
		int currentChallengeIndex = bossRoundInfo.FindIndex((IBossInfo info) => info.HpPercentage > 0.0);
		if (currentChallengeIndex < 0)
		{
			currentChallengeIndex = bossRoundInfo.Count - 1;
		}
		List<IBossInfo> prevRoundBossInfo = ModelBase<WheelTowerModel>.Instance.GetPrevRoundBossInfo(round);
		List<IBossItemData> list = new List<IBossItemData>();
		for (int i = 0; i < bossRoundInfo.Count; i++)
		{
			list.Add(new BossItemData
			{
				BossInfo = bossRoundInfo[i],
				StartPercent = new float?((float)prevRoundBossInfo[i].HpPercentage)
			});
		}
		GenericScrollViewNew<WheelTowerBossItem, IBossItemData> bossScrollView = this.BossScrollView;
		if (bossScrollView == null)
		{
			return;
		}
		bossScrollView.RefreshByData(list, delegate
		{
			GenericScrollViewNew<WheelTowerBossItem, IBossItemData> bossScrollView2 = this.BossScrollView;
			if (bossScrollView2 != null)
			{
				WheelTowerBossItem scrollItemByIndex = bossScrollView2.GetScrollItemByIndex(currentChallengeIndex);
				if (scrollItemByIndex != null)
				{
					scrollItemByIndex.SetCurrentChallenge(true);
				}
			}
			GenericScrollViewNew<WheelTowerBossItem, IBossItemData> bossScrollView3 = this.BossScrollView;
			if (bossScrollView3 != null)
			{
				bossScrollView3.ScrollToItemByKey(currentChallengeIndex);
			}
			this.OnClickBossButton(currentChallengeIndex, bossRoundInfo[currentChallengeIndex].WaveConfigId);
		}, false);
	}

	// Token: 0x0600A2CA RID: 41674 RVA: 0x002AF79D File Offset: 0x002AD99D
	[NullableContext(1)]
	private WheelTowerBossItem CreateBossItem()
	{
		WheelTowerBossItem wheelTowerBossItem = new WheelTowerBossItem();
		wheelTowerBossItem.SetClickCallback(new Action<int, int>(this.OnClickBossButton));
		return wheelTowerBossItem;
	}

	// Token: 0x0600A2CB RID: 41675 RVA: 0x002AF7B8 File Offset: 0x002AD9B8
	private void OnClickBossButton(int index, int bossId)
	{
		GenericScrollViewNew<WheelTowerBossItem, IBossItemData> bossScrollView = this.BossScrollView;
		if (bossScrollView != null)
		{
			bossScrollView.SelectGridProxy(index, false);
		}
		NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(bossId);
		if (waveConfigById != null)
		{
			UUIText text = base.GetText(9);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(waveConfigById.Value.Desc);
		}
	}

	// Token: 0x0600A2CC RID: 41676 RVA: 0x002AF810 File Offset: 0x002ADA10
	private void OnClickSwitchLeft()
	{
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView = this.RoundTabAttachView;
		if (roundTabAttachView != null && roundTabAttachView.MovingState())
		{
			return;
		}
		int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
		int selectedRound = ModelBase<WheelTowerModel>.Instance.SelectedRound;
		if (maxChallengeRound == 0)
		{
			this.TryAttachToIndex(0);
			return;
		}
		int num = selectedRound - 1;
		if (num < 0)
		{
			num += maxChallengeRound + 1;
		}
		this.TryAttachToIndex(num);
	}

	// Token: 0x0600A2CD RID: 41677 RVA: 0x002AF874 File Offset: 0x002ADA74
	private void OnClickSwitchRight()
	{
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView = this.RoundTabAttachView;
		if (roundTabAttachView != null && roundTabAttachView.MovingState())
		{
			return;
		}
		int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
		int selectedRound = ModelBase<WheelTowerModel>.Instance.SelectedRound;
		if (maxChallengeRound == 0)
		{
			this.TryAttachToIndex(0);
			return;
		}
		int index = (selectedRound + 1) % (maxChallengeRound + 1);
		this.TryAttachToIndex(index);
	}

	// Token: 0x0600A2CE RID: 41678 RVA: 0x002AF8D0 File Offset: 0x002ADAD0
	private void OnClickStart()
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		if (!instance.CheckSelectedRoleEnergyEnough())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WheelBattleTips_NoFatiguevalue", Array.Empty<object>());
			return;
		}
		if (!instance.CheckBuffIsSelected())
		{
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerTeamBuffNotSelectTips));
			return;
		}
		if (instance.CheckSelectedIsConflict())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerSelectConflictConfirm);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.RequestChallenge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.RequestChallenge();
	}

	// Token: 0x0600A2CF RID: 41679 RVA: 0x002AF95C File Offset: 0x002ADB5C
	private void RequestChallenge()
	{
		ControllerBase<WheelTowerController>.Instance.RequestSelectedRoundChallenge();
		base.CloseMe(null);
	}

	// Token: 0x0600A2D0 RID: 41680 RVA: 0x002AF970 File Offset: 0x002ADB70
	private void OnClickReset()
	{
		if (!ModelBase<WheelTowerModel>.Instance.HasChallengeAnyRound(null))
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerRoundResetAllConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			NewTowerClimbingLevelRecord currentLevelRecord = ModelBase<WheelTowerModel>.Instance.GetCurrentLevelRecord(null);
			ControllerBase<WheelTowerController>.Instance.RequestResetLevelRecord(currentLevelRecord.LevelId).ContinueWith(new Action(this.RefreshAll)).Forget();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A2D1 RID: 41681 RVA: 0x002AF9C2 File Offset: 0x002ADBC2
	private void OnClickClose()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerModeSelectView, null, null);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A2D2 RID: 41682 RVA: 0x002AF9E9 File Offset: 0x002ADBE9
	private void OnClickTeamItem()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerTeamSelectView, null, delegate(bool isSuccess, int viewId)
		{
			if (isSuccess)
			{
				base.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x0600A2D3 RID: 41683 RVA: 0x002AFA08 File Offset: 0x002ADC08
	private void InitAttachTab()
	{
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView = this.RoundTabAttachView;
		if (roundTabAttachView != null)
		{
			roundTabAttachView.SetControllerItem(base.GetItem(6));
		}
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView2 = this.RoundTabAttachView;
		if (roundTabAttachView2 != null)
		{
			roundTabAttachView2.CreateItems(base.GetItem(18).GetOwner(), 0f, new Func<AActor, int, int, RoundTab>(this.CreateTabItem), EAttachDirection.Horizontal);
		}
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView3 = this.RoundTabAttachView;
		if (roundTabAttachView3 != null)
		{
			roundTabAttachView3.SetIfNeedFakeItem(true);
		}
		UUIItem item = base.GetItem(18);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
		List<RoundTabData> list = new List<RoundTabData>();
		for (int i = 0; i <= maxChallengeRound; i++)
		{
			list.Add(new RoundTabData
			{
				Round = i,
				IsLock = false
			});
		}
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView4 = this.RoundTabAttachView;
		if (roundTabAttachView4 == null)
		{
			return;
		}
		roundTabAttachView4.ReloadView(list.Count, list.ToArray(), maxChallengeRound);
	}

	// Token: 0x0600A2D4 RID: 41684 RVA: 0x002AFADF File Offset: 0x002ADCDF
	[NullableContext(1)]
	private RoundTab CreateTabItem(AActor actor, int index, int showNum)
	{
		RoundTab roundTab = new RoundTab();
		roundTab.OnClickCallback = new Action<int>(this.OnToggleClick);
		roundTab.CreateThenShowByActor(actor, null);
		return roundTab;
	}

	// Token: 0x0600A2D5 RID: 41685 RVA: 0x002AFB00 File Offset: 0x002ADD00
	private void OnToggleClick(int round)
	{
		this.TryAttachToIndex(round);
	}

	// Token: 0x0600A2D6 RID: 41686 RVA: 0x002AFB09 File Offset: 0x002ADD09
	private void TryAttachToIndex(int index)
	{
		NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView = this.RoundTabAttachView;
		if (roundTabAttachView == null || roundTabAttachView.GetCurrentSelectIndex() != index)
		{
			NoCircleAttachView<RoundTabData, RoundTab> roundTabAttachView2 = this.RoundTabAttachView;
			if (roundTabAttachView2 != null)
			{
				roundTabAttachView2.AttachToIndex(index, false);
			}
		}
		this.RefreshRound(index, false);
	}

	// Token: 0x0600A2D7 RID: 41687 RVA: 0x002AFB40 File Offset: 0x002ADD40
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.WheelTowerTeamSelectView)
		{
			this.RefreshSelectData();
		}
	}

	// Token: 0x0600A2D8 RID: 41688 RVA: 0x002AFB55 File Offset: 0x002ADD55
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			WheelTowerRoundSelectView.<>c.<<AddHomeBtnExtraCallback>b__37_0>d <<AddHomeBtnExtraCallback>b__37_0>d;
			<<AddHomeBtnExtraCallback>b__37_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__37_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__37_0>d.<>t__builder.Start<WheelTowerRoundSelectView.<>c.<<AddHomeBtnExtraCallback>b__37_0>d>(ref <<AddHomeBtnExtraCallback>b__37_0>d);
			return <<AddHomeBtnExtraCallback>b__37_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x04004D46 RID: 19782
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private NoCircleAttachView<RoundTabData, RoundTab> RoundTabAttachView;

	// Token: 0x04004D47 RID: 19783
	private PopupCaptionItem Caption;

	// Token: 0x04004D48 RID: 19784
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WheelTowerBossItem, IBossItemData> BossScrollView;

	// Token: 0x04004D49 RID: 19785
	private WheelTowerBuffItem BuffItem;

	// Token: 0x04004D4A RID: 19786
	private WheelTowerTeamItem TeamItem;

	// Token: 0x04004D4B RID: 19787
	private RecordItem TotalRecordItem;

	// Token: 0x04004D4C RID: 19788
	private RecordItem CurrentRecordItem;

	// Token: 0x04004D4D RID: 19789
	private LevelSequencePlayer SeqPlayer;
}
