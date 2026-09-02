using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C49 RID: 7241
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchWeeklyMainView : UiViewBase
{
	// Token: 0x0600D328 RID: 54056 RVA: 0x00383E7F File Offset: 0x0038207F
	public FloroRanchWeeklyMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D329 RID: 54057 RVA: 0x00383EA0 File Offset: 0x003820A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 24;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnStartBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnCloseBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnArchiveBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnSaveBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D32A RID: 54058 RVA: 0x00384298 File Offset: 0x00382498
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchWeeklyMainView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchWeeklyMainView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D32B RID: 54059 RVA: 0x003842DB File Offset: 0x003824DB
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(16));
		this.IsRequesting = false;
	}

	// Token: 0x0600D32C RID: 54060 RVA: 0x003842F8 File Offset: 0x003824F8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EFloroRanchActivityDataType, int>(EEventName.FloroRanchSkillChange, new Action<EFloroRanchActivityDataType, int>(this.OnSkillChange));
		Singleton<EventSystem>.Instance.Add<EFloroRanchActivityDataType>(EEventName.FloroRanchSkillRedDotRefresh, new Action<EFloroRanchActivityDataType>(this.OnSkillRedDotRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.FloroRanchSettlement, new Action(this.OnFloroRanchSettlement));
		Singleton<EventSystem>.Instance.Add(EEventName.FloroRanchSubInsHistoryUpdate, new Action(this.OnSubInsHistoryUpdate));
	}

	// Token: 0x0600D32D RID: 54061 RVA: 0x00384378 File Offset: 0x00382578
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchSkillChange, new Action<EFloroRanchActivityDataType, int>(this.OnSkillChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchSkillRedDotRefresh, new Action<EFloroRanchActivityDataType>(this.OnSkillRedDotRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchSettlement, new Action(this.OnFloroRanchSettlement));
		Singleton<EventSystem>.Instance.Remove(EEventName.FloroRanchSubInsHistoryUpdate, new Action(this.OnSubInsHistoryUpdate));
	}

	// Token: 0x0600D32E RID: 54062 RVA: 0x003843F5 File Offset: 0x003825F5
	protected override void OnBeforeShow()
	{
		this.RefreshStartButton();
		this.RefreshWeeklyScore();
		this.RefreshHistoryPanel();
	}

	// Token: 0x0600D32F RID: 54063 RVA: 0x00384409 File Offset: 0x00382609
	protected override void OnBeforeHide()
	{
		this.IsRequesting = false;
	}

	// Token: 0x0600D330 RID: 54064 RVA: 0x00384412 File Offset: 0x00382612
	private FloroRanchHandBookSmallSlotItem CreateRecommendItem()
	{
		FloroRanchHandBookSmallSlotItem floroRanchHandBookSmallSlotItem = new FloroRanchHandBookSmallSlotItem();
		floroRanchHandBookSmallSlotItem.SetActivityDataType(EFloroRanchActivityDataType.Weekly);
		floroRanchHandBookSmallSlotItem.BindClickCallback(new Action<FloroRanchHandBookSmallSlotItem>(this.OnRecommendItemClick));
		return floroRanchHandBookSmallSlotItem;
	}

	// Token: 0x0600D331 RID: 54065 RVA: 0x00384434 File Offset: 0x00382634
	private void OnRecommendItemClick(FloroRanchHandBookSmallSlotItem item)
	{
		int num = this.RecommendLayout.GetLayoutItemList().IndexOf(item);
		if (num < 0 || this.RecommendUnlockDataList.Count <= 0)
		{
			return;
		}
		FloroRanchRecommendTipViewParam floroRanchRecommendTipViewParam = new FloroRanchRecommendTipViewParam
		{
			RefreshDataList = new List<FloroRanchUnlockDataBase>(this.RecommendUnlockDataList),
			DefaultIndex = num,
			ActivityDataType = EFloroRanchActivityDataType.Weekly
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchRecommendTipView, floroRanchRecommendTipViewParam, null);
		foreach (FloroRanchHandBookSmallSlotItem floroRanchHandBookSmallSlotItem in this.RecommendLayout.GetLayoutItemList())
		{
			floroRanchHandBookSmallSlotItem.OnDeselected(true);
		}
	}

	// Token: 0x0600D332 RID: 54066 RVA: 0x003844F4 File Offset: 0x003826F4
	private FloroRanchRaceItem CreateRaceItem()
	{
		return new FloroRanchRaceItem();
	}

	// Token: 0x0600D333 RID: 54067 RVA: 0x003844FC File Offset: 0x003826FC
	private UniTask RefreshRightInfoPanel()
	{
		FloroRanchWeeklyMainView.<RefreshRightInfoPanel>d__21 <RefreshRightInfoPanel>d__;
		<RefreshRightInfoPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRightInfoPanel>d__.<>4__this = this;
		<RefreshRightInfoPanel>d__.<>1__state = -1;
		<RefreshRightInfoPanel>d__.<>t__builder.Start<FloroRanchWeeklyMainView.<RefreshRightInfoPanel>d__21>(ref <RefreshRightInfoPanel>d__);
		return <RefreshRightInfoPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600D334 RID: 54068 RVA: 0x00384540 File Offset: 0x00382740
	private void RefreshHistoryPanel()
	{
		FloroRanchSubDungeonData floroRanchSubDungeonData = this.ActivityData.GetFloroRanchSubDungeonData(this.SubDungeonId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "FloroRanchDayNum", new <>z__ReadOnlySingleElementList<object>(floroRanchSubDungeonData.MaxDays));
		string coinText = ModelBase<FloroRanchModel>.Instance.GetCoinText(floroRanchSubDungeonData.MaxCoin);
		UUIText text = base.GetText(6);
		if (text != null)
		{
			text.SetText(coinText, true);
		}
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(floroRanchSubDungeonData.HasHistory);
	}

	// Token: 0x0600D335 RID: 54069 RVA: 0x003845C1 File Offset: 0x003827C1
	private void RefreshSkillItem(int skillId)
	{
		this.SkillId = skillId;
		FloroRanchSkillItem skillItem = this.SkillItem;
		if (skillItem == null)
		{
			return;
		}
		skillItem.Refresh(skillId);
	}

	// Token: 0x0600D336 RID: 54070 RVA: 0x003845DB File Offset: 0x003827DB
	private void OnSkillChange(EFloroRanchActivityDataType activityDataType, int skillId)
	{
		if (activityDataType != EFloroRanchActivityDataType.Weekly)
		{
			return;
		}
		this.RefreshSkillItem(skillId);
	}

	// Token: 0x0600D337 RID: 54071 RVA: 0x003845E9 File Offset: 0x003827E9
	private void OnSkillRedDotRefresh(EFloroRanchActivityDataType activityDataType)
	{
		if (activityDataType != EFloroRanchActivityDataType.Weekly)
		{
			return;
		}
		FloroRanchSkillItem skillItem = this.SkillItem;
		if (skillItem == null)
		{
			return;
		}
		skillItem.RefreshRedDot();
	}

	// Token: 0x0600D338 RID: 54072 RVA: 0x00384600 File Offset: 0x00382800
	private void OnFloroRanchSettlement()
	{
		this.RefreshStartButton();
		this.RefreshWeeklyScore();
		this.RefreshHistoryPanel();
	}

	// Token: 0x0600D339 RID: 54073 RVA: 0x00384614 File Offset: 0x00382814
	private void OnSubInsHistoryUpdate()
	{
		this.RefreshHistoryPanel();
	}

	// Token: 0x0600D33A RID: 54074 RVA: 0x0038461C File Offset: 0x0038281C
	private void RefreshStartButton()
	{
		bool flag = this.ActivityData.HasUnFinishedSubIns();
		base.GetButton(2).RootUIComp.Get().SetUIActive(!flag);
		base.GetButton(11).RootUIComp.Get().SetUIActive(flag);
	}

	// Token: 0x0600D33B RID: 54075 RVA: 0x00384670 File Offset: 0x00382870
	private void RefreshWeeklyScore()
	{
		int weeklyCurrentScore = ModelBase<WeeklyChallengeModel>.Instance.WeeklyCurrentScore;
		int weeklyMaxScore = ModelBase<WeeklyChallengeModel>.Instance.WeeklyMaxScore;
		bool flag = weeklyCurrentScore >= weeklyMaxScore;
		base.GetText(23).SetUIActive(flag);
		if (!flag)
		{
			base.GetText(21).SetText(ModelBase<WeeklyChallengeModel>.Instance.WeeklyCurrentScore.ToString(), true);
			base.GetText(22).SetText("/" + ModelBase<WeeklyChallengeModel>.Instance.WeeklyMaxScore.ToString(), true);
		}
		else
		{
			base.GetText(23).ShowTextNew("WeeklyFarm_ScoreMax");
		}
		base.GetText(21).SetUIActive(!flag);
		base.GetText(22).SetUIActive(!flag);
	}

	// Token: 0x0600D33C RID: 54076 RVA: 0x0038472C File Offset: 0x0038292C
	private void OnGameNewStart()
	{
		if (this.IsRequesting)
		{
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
			return;
		}
		if (this.RaceIds.Contains(0))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ChooseRace", Array.Empty<object>());
			return;
		}
		if (this.SkillId == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ChooseSkill", Array.Empty<object>());
			return;
		}
		this.IsRequesting = true;
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(false);
			}
		}
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchStartPlayRequest(this.ActivityData.Id, this.SubDungeonId, this.RaceIds.ToArray(), new int?(this.SkillId), delegate(FloroRanchStartPlayResponse response)
		{
			if (response == null)
			{
				this.IsRequesting = false;
				UUIButtonComponent button2 = base.GetButton(2);
				if (button2 == null)
				{
					return;
				}
				UUIItem uuiitem2 = button2.RootUIComp.Get();
				if (uuiitem2 == null)
				{
					return;
				}
				uuiitem2.SetUIActive(true);
			}
		});
	}

	// Token: 0x0600D33D RID: 54077 RVA: 0x00384810 File Offset: 0x00382A10
	private void OnSaveBtnClick()
	{
		if (this.IsRequesting)
		{
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
			return;
		}
		if (!this.ActivityData.HasUnFinishedSubIns())
		{
			return;
		}
		this.IsRequesting = true;
		FloroRanchSubDungeonData subDungeonData = this.ActivityData.GetUnFinishedSubDungeonData();
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchWeeklyArchiveConfirm);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			this.ActivityData.GetSavedStage().ToString()
		});
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		bool isConfirmed = false;
		Action<FloroRanchSettleResponse> <>9__3;
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
			isConfirmed = true;
			FloroRanchController instance = ControllerBase<FloroRanchController>.Instance;
			int id = this.ActivityData.Id;
			int id2 = subDungeonData.Id;
			Action<FloroRanchSettleResponse> callback;
			if ((callback = <>9__3) == null)
			{
				callback = (<>9__3 = delegate(FloroRanchSettleResponse response)
				{
					this.IsRequesting = false;
					if (response != null)
					{
						this.OnGameNewStart();
					}
				});
			}
			instance.SendFloroRanchAbandonArchiveRequest(id, id2, callback);
		};
		Action<FloroRanchStartPlayResponse> <>9__4;
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			isConfirmed = true;
			FloroRanchController instance = ControllerBase<FloroRanchController>.Instance;
			int id = this.ActivityData.Id;
			int id2 = subDungeonData.Id;
			int[] races = null;
			int? skillId = null;
			Action<FloroRanchStartPlayResponse> callback;
			if ((callback = <>9__4) == null)
			{
				callback = (<>9__4 = delegate(FloroRanchStartPlayResponse response)
				{
					if (response == null)
					{
						this.IsRequesting = false;
					}
				});
			}
			instance.SendFloroRanchStartPlayRequest(id, id2, races, skillId, callback);
		};
		confirmBoxDataNew.DestroyFunction = delegate()
		{
			if (!isConfirmed)
			{
				this.IsRequesting = false;
			}
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D33E RID: 54078 RVA: 0x00384903 File Offset: 0x00382B03
	private void OnCloseBtnClick()
	{
		if (this.IsRequesting)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600D33F RID: 54079 RVA: 0x00384915 File Offset: 0x00382B15
	private void OnStartBtnClick()
	{
		this.OnGameNewStart();
	}

	// Token: 0x0600D340 RID: 54080 RVA: 0x00384920 File Offset: 0x00382B20
	private void OnArchiveBtnClick()
	{
		FloroRanchHandBookViewParam floroRanchHandBookViewParam = new FloroRanchHandBookViewParam
		{
			ActivityDataType = EFloroRanchActivityDataType.Weekly
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchHandBookView, floroRanchHandBookViewParam, null);
	}

	// Token: 0x04006498 RID: 25752
	[Nullable(2)]
	private global::FloroRanchActivityData ActivityData;

	// Token: 0x04006499 RID: 25753
	private int SubDungeonId;

	// Token: 0x0400649A RID: 25754
	private int SkillId;

	// Token: 0x0400649B RID: 25755
	private List<int> RaceIds = new List<int>();

	// Token: 0x0400649C RID: 25756
	[Nullable(2)]
	private FloroRanchSkillItem SkillItem;

	// Token: 0x0400649D RID: 25757
	private GenericLayout<FloroRanchHandBookSmallSlotItem, FloroRanchUnlockDataBase> RecommendLayout;

	// Token: 0x0400649E RID: 25758
	private readonly List<FloroRanchUnlockDataBase> RecommendUnlockDataList = new List<FloroRanchUnlockDataBase>();

	// Token: 0x0400649F RID: 25759
	private GenericLayout<FloroRanchRaceItem, FloroRanchSelectRaceData> RaceLayout;

	// Token: 0x040064A0 RID: 25760
	private bool IsRequesting;

	// Token: 0x02007F57 RID: 32599
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B587 RID: 177543
		public const int TextTitle = 0;

		// Token: 0x0402B588 RID: 177544
		public const int BtnClose = 1;

		// Token: 0x0402B589 RID: 177545
		public const int BtnStart = 2;

		// Token: 0x0402B58A RID: 177546
		public const int ItemRightPanel = 3;

		// Token: 0x0402B58B RID: 177547
		public const int ItemHistoryPanel = 4;

		// Token: 0x0402B58C RID: 177548
		public const int TextHistoryDay = 5;

		// Token: 0x0402B58D RID: 177549
		public const int TextHistoryCoin = 6;

		// Token: 0x0402B58E RID: 177550
		public const int SpineRole = 7;

		// Token: 0x0402B58F RID: 177551
		public const int ItemSKill = 8;

		// Token: 0x0402B590 RID: 177552
		public const int ItemLockPanel = 9;

		// Token: 0x0402B591 RID: 177553
		public const int ItemQuest = 10;

		// Token: 0x0402B592 RID: 177554
		public const int BtnSave = 11;

		// Token: 0x0402B593 RID: 177555
		public const int BtnArchive = 12;

		// Token: 0x0402B594 RID: 177556
		public const int TextInsName = 13;

		// Token: 0x0402B595 RID: 177557
		public const int TextTarget = 14;

		// Token: 0x0402B596 RID: 177558
		public const int ItemDescRoot = 15;

		// Token: 0x0402B597 RID: 177559
		public const int TextDesc = 16;

		// Token: 0x0402B598 RID: 177560
		public const int GridLayoutRecommend = 17;

		// Token: 0x0402B599 RID: 177561
		public const int ItemRecommend = 18;

		// Token: 0x0402B59A RID: 177562
		public const int HorizontalLayoutRace = 19;

		// Token: 0x0402B59B RID: 177563
		public const int ItemRace = 20;

		// Token: 0x0402B59C RID: 177564
		public const int TextCurWeeklyScore = 21;

		// Token: 0x0402B59D RID: 177565
		public const int TextMaxWeeklyScore = 22;

		// Token: 0x0402B59E RID: 177566
		public const int TextWeekFinish = 23;
	}
}
