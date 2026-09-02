using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015D5 RID: 5589
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewTowerGuide : ActivitySubViewBase
{
	// Token: 0x17000D4F RID: 3407
	// (get) Token: 0x06009D4B RID: 40267 RVA: 0x00292FBE File Offset: 0x002911BE
	private ActivityTowerGuideData TowerGuideData
	{
		get
		{
			return this.ActivityBaseData as ActivityTowerGuideData;
		}
	}

	// Token: 0x06009D4C RID: 40268 RVA: 0x00292FCC File Offset: 0x002911CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(20, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(17, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIText)),
			new ValueTuple<int, Type>(23, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.ButtonRolePreviewClick)),
			new ValueTuple<int, Delegate>(16, new Action(this.ButtonRolePreviewClick)),
			new ValueTuple<int, Delegate>(6, new Action(this.ButtonReward1Click)),
			new ValueTuple<int, Delegate>(11, new Action(this.ButtonReward2Click)),
			new ValueTuple<int, Delegate>(12, new Action(this.ButtonJumpClick)),
			new ValueTuple<int, Delegate>(23, new Action(this.ButtonLockClick))
		};
	}

	// Token: 0x06009D4D RID: 40269 RVA: 0x002932A2 File Offset: 0x002914A2
	protected override void OnSetData()
	{
	}

	// Token: 0x06009D4E RID: 40270 RVA: 0x002932A4 File Offset: 0x002914A4
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewTowerGuide.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewTowerGuide.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009D4F RID: 40271 RVA: 0x002932E7 File Offset: 0x002914E7
	[NullableContext(1)]
	private ActivityTowerGuideRewardGrid CreateGridItem()
	{
		return new ActivityTowerGuideRewardGrid();
	}

	// Token: 0x06009D50 RID: 40272 RVA: 0x002932EE File Offset: 0x002914EE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06009D51 RID: 40273 RVA: 0x0029330C File Offset: 0x0029150C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06009D52 RID: 40274 RVA: 0x0029332A File Offset: 0x0029152A
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (this.TowerGuideData != null && id == this.TowerGuideData.Id)
		{
			this.OnRefreshView();
		}
	}

	// Token: 0x06009D53 RID: 40275 RVA: 0x00293348 File Offset: 0x00291548
	protected override void OnStart()
	{
		this.SetTitlePart();
		this.SetRolePart();
		this.OnRefreshView();
	}

	// Token: 0x06009D54 RID: 40276 RVA: 0x0029335C File Offset: 0x0029155C
	protected override void OnBeforeDestroy()
	{
		if (this.RewardLayout != null)
		{
			foreach (ActivityTowerGuideRewardGrid child in this.RewardLayout.GetLayoutItemList())
			{
				base.AddChild(child);
			}
		}
	}

	// Token: 0x06009D55 RID: 40277 RVA: 0x002933BC File Offset: 0x002915BC
	protected override void OnRefreshView()
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		ETowerGuideViewState viewState = this.TowerGuideData.GetViewState();
		this.SetRemainTimeText();
		this.SetViewState(viewState);
	}

	// Token: 0x06009D56 RID: 40278 RVA: 0x002933EC File Offset: 0x002915EC
	private void SetTitlePart()
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		base.GetText(18).SetText(this.TowerGuideData.GetTitle(), true);
		base.GetText(19).ShowTextNew(this.TowerGuideData.LocalConfig.Value.Desc);
	}

	// Token: 0x06009D57 RID: 40279 RVA: 0x00293440 File Offset: 0x00291640
	private void SetRolePart()
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		this.TrialRoleId = this.TowerGuideData.TrialRoleId;
		RoleDataBase trialRoleData = this.TowerGuideData.GetTrialRoleData();
		if (trialRoleData == null)
		{
			return;
		}
		base.GetText(17).SetText(trialRoleData.GetName(null), true);
	}

	// Token: 0x06009D58 RID: 40280 RVA: 0x00293494 File Offset: 0x00291694
	private void SetViewState(ETowerGuideViewState state)
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		this.ViewState = state;
		bool flag = state == ETowerGuideViewState.InActive;
		bool flag2 = state == ETowerGuideViewState.Active;
		bool uiactive = state == ETowerGuideViewState.Finished;
		base.GetItem(0).SetUIActive(flag);
		base.GetItem(1).SetUIActive(flag);
		base.GetItem(2).SetUIActive(flag);
		base.GetItem(8).SetUIActive(flag);
		base.GetItem(13).SetUIActive(flag);
		base.GetButton(23).RootUIComp.Get().SetUIActive(flag);
		if (flag)
		{
			base.GetText(14).ShowTextNew(this.GetCurrentLockConditionText());
		}
		ETowerProgressState towerProgressState = this.TowerGuideData.GetTowerProgressState(1);
		ETowerProgressState towerProgressState2 = this.TowerGuideData.GetTowerProgressState(2);
		this.RefreshRewardLayout(flag, towerProgressState2 == ETowerProgressState.FinishedAndUnClaimed);
		this.ProgressComponent1.SetUiActive(towerProgressState == ETowerProgressState.Active);
		if (towerProgressState == ETowerProgressState.Active)
		{
			ValueTuple<int, int> towerProgress = this.TowerGuideData.GetTowerProgress(ETowerDifficultId.Low);
			int item = towerProgress.Item1;
			int item2 = towerProgress.Item2;
			this.ProgressComponent1.Refresh(item, item2);
		}
		base.GetItem(3).SetUIActive(towerProgressState == ETowerProgressState.FinishedAndClaimed);
		base.GetButton(6).RootUIComp.Get().SetUIActive(towerProgressState == ETowerProgressState.FinishedAndUnClaimed);
		this.ProgressComponent2.SetUiActive(towerProgressState2 == ETowerProgressState.Active);
		if (towerProgressState2 == ETowerProgressState.Active)
		{
			ValueTuple<int, int> towerProgress2 = this.TowerGuideData.GetTowerProgress(ETowerDifficultId.High);
			int item3 = towerProgress2.Item1;
			int item4 = towerProgress2.Item2;
			this.ProgressComponent2.Refresh(item3, item4);
		}
		base.GetItem(7).SetUIActive(towerProgressState2 == ETowerProgressState.FinishedAndClaimed);
		base.GetButton(11).RootUIComp.Get().SetUIActive(towerProgressState2 == ETowerProgressState.FinishedAndUnClaimed);
		base.GetButton(12).RootUIComp.Get().SetUIActive(flag2);
		if (flag2)
		{
			string key = this.TowerGuideData.GetPreGuideQuestFinishState() ? "ReadyToFightText" : "JumpToQuestText";
			base.GetText(20).ShowTextNew(key);
		}
		base.GetItem(15).SetUIActive(uiactive);
	}

	// Token: 0x06009D59 RID: 40281 RVA: 0x0029368D File Offset: 0x0029188D
	protected override void OnTimer(float gap)
	{
		this.SetRemainTimeText();
	}

	// Token: 0x06009D5A RID: 40282 RVA: 0x00293695 File Offset: 0x00291895
	private void SetRemainTimeActive(bool isActive)
	{
		if (this.IsRemainTimeActive == isActive)
		{
			return;
		}
		this.IsRemainTimeActive = isActive;
		base.GetItem(21).SetUIActive(isActive);
	}

	// Token: 0x06009D5B RID: 40283 RVA: 0x002936B8 File Offset: 0x002918B8
	private void SetRemainTimeText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.SetRemainTimeActive(item);
		if (item && this.RemainTime != null)
		{
			this.RemainTime.SetText(item2, true);
		}
	}

	// Token: 0x06009D5C RID: 40284 RVA: 0x002936F8 File Offset: 0x002918F8
	private void RefreshRewardLayout(bool isLock, bool isReceivableVisible)
	{
		TowerGuide? towerGuideById = ConfigBase<ActivityTowerGuideConfig>.Instance.GetTowerGuideById(2);
		if (towerGuideById == null || this.RewardLayout == null)
		{
			return;
		}
		TowerGuide value = towerGuideById.Value;
		List<ITowerGuideRewardItem> list = new List<ITowerGuideRewardItem>();
		for (int i = 0; i < value.RewardItemLength; i++)
		{
			DicIntInt? dicIntInt = value.RewardItem(i);
			if (dicIntInt != null)
			{
				int key = dicIntInt.Value.Key;
				int value2 = dicIntInt.Value.Value;
				TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value2);
				list.Add(new TowerGuideRewardItem
				{
					Item = item,
					IsLock = isLock,
					IsReceivableVisible = isReceivableVisible
				});
			}
		}
		this.RewardLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06009D5D RID: 40285 RVA: 0x002937BC File Offset: 0x002919BC
	private unsafe void ButtonRolePreviewClick()
	{
		RoleController instance = ControllerBase<RoleController>.Instance;
		ERoleAgentType agentType = ERoleAgentType.Preview;
		int selectRoleId = 0;
		int num = 1;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int index = 0;
		*span[index] = this.TrialRoleId;
		instance.OpenRoleMainView(agentType, selectRoleId, list, null, null);
	}

	// Token: 0x06009D5E RID: 40286 RVA: 0x00293806 File Offset: 0x00291A06
	private void ButtonReward1Click()
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		if (this.TowerGuideData.GetTowerProgressState(1) == ETowerProgressState.FinishedAndUnClaimed)
		{
			ControllerBase<ActivityTowerGuideController>.Instance.RequestTowerReward(ETowerDifficultId.Low);
		}
	}

	// Token: 0x06009D5F RID: 40287 RVA: 0x0029382B File Offset: 0x00291A2B
	private void ButtonReward2Click()
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		if (this.TowerGuideData.GetTowerProgressState(2) == ETowerProgressState.FinishedAndUnClaimed)
		{
			ControllerBase<ActivityTowerGuideController>.Instance.RequestTowerReward(ETowerDifficultId.High);
		}
	}

	// Token: 0x06009D60 RID: 40288 RVA: 0x00293850 File Offset: 0x00291A50
	private void ButtonJumpClick()
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		if (!this.TowerGuideData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.TowerGuideData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
		}
		else
		{
			ControllerBase<TowerController>.Instance.OpenTowerView(false);
		}
		ModelBase<ActivityModel>.Instance.SendActivityViewJumpClickLogData(this.TowerGuideData);
	}

	// Token: 0x06009D61 RID: 40289 RVA: 0x002938B3 File Offset: 0x00291AB3
	private void ButtonLockClick()
	{
		if (this.TowerGuideData == null)
		{
			return;
		}
		ControllerBase<ActivityController>.Instance.OpenActivityConditionView(this.TowerGuideData.Id);
	}

	// Token: 0x04004876 RID: 18550
	private int TrialRoleId;

	// Token: 0x04004877 RID: 18551
	protected ETowerGuideViewState ViewState;

	// Token: 0x04004878 RID: 18552
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ActivityTowerGuideRewardGrid, ITowerGuideRewardItem> RewardLayout;

	// Token: 0x04004879 RID: 18553
	private UUIText RemainTime;

	// Token: 0x0400487A RID: 18554
	private bool IsRemainTimeActive = true;

	// Token: 0x0400487B RID: 18555
	private TowerGuideProgress ProgressComponent1;

	// Token: 0x0400487C RID: 18556
	private TowerGuideProgress ProgressComponent2;

	// Token: 0x02007991 RID: 31121
	[NullableContext(0)]
	private class ETowerGuideComponents
	{
		// Token: 0x04029BF5 RID: 170997
		public const int LockLow1 = 0;

		// Token: 0x04029BF6 RID: 170998
		public const int LockLow2 = 1;

		// Token: 0x04029BF7 RID: 170999
		public const int LockLow3 = 2;

		// Token: 0x04029BF8 RID: 171000
		public const int ClaimedLow = 3;

		// Token: 0x04029BF9 RID: 171001
		public const int Progress1 = 4;

		// Token: 0x04029BFA RID: 171002
		public const int ButtonRolePreview1 = 5;

		// Token: 0x04029BFB RID: 171003
		public const int ButtonReward1 = 6;

		// Token: 0x04029BFC RID: 171004
		public const int ClaimedHigh = 7;

		// Token: 0x04029BFD RID: 171005
		public const int LockHigh1 = 8;

		// Token: 0x04029BFE RID: 171006
		public const int RewardLayout = 9;

		// Token: 0x04029BFF RID: 171007
		public const int Progress2 = 10;

		// Token: 0x04029C00 RID: 171008
		public const int ButtonReward2 = 11;

		// Token: 0x04029C01 RID: 171009
		public const int ButtonJump = 12;

		// Token: 0x04029C02 RID: 171010
		public const int ConditionPanel = 13;

		// Token: 0x04029C03 RID: 171011
		public const int TxtCondition = 14;

		// Token: 0x04029C04 RID: 171012
		public const int FinishedPanel = 15;

		// Token: 0x04029C05 RID: 171013
		public const int ButtonRolePreview2 = 16;

		// Token: 0x04029C06 RID: 171014
		public const int RoleName = 17;

		// Token: 0x04029C07 RID: 171015
		public const int Title = 18;

		// Token: 0x04029C08 RID: 171016
		public const int TxtDesc = 19;

		// Token: 0x04029C09 RID: 171017
		public const int TxtButton = 20;

		// Token: 0x04029C0A RID: 171018
		public const int PanelTime = 21;

		// Token: 0x04029C0B RID: 171019
		public const int TxtTime = 22;

		// Token: 0x04029C0C RID: 171020
		public const int ButtonLock = 23;
	}
}
