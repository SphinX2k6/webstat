using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015A8 RID: 5544
[NullableContext(1)]
[Nullable(0)]
public class ScratchTicketMainView : UiTickViewBase
{
	// Token: 0x06009C24 RID: 39972 RVA: 0x0028DFD1 File Offset: 0x0028C1D1
	public ScratchTicketMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06009C25 RID: 39973 RVA: 0x0028E010 File Offset: 0x0028C210
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIMultiTemplateLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009C26 RID: 39974 RVA: 0x0028E1A8 File Offset: 0x0028C3A8
	protected override UniTask OnBeforeStartAsync()
	{
		ScratchTicketMainView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ScratchTicketMainView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009C27 RID: 39975 RVA: 0x0028E1EB File Offset: 0x0028C3EB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.OnScratchTicketConditionRefresh, new Action(this.OnScratchTicketConditionRefresh));
	}

	// Token: 0x06009C28 RID: 39976 RVA: 0x0028E225 File Offset: 0x0028C425
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnScratchTicketConditionRefresh, new Action(this.OnScratchTicketConditionRefresh));
	}

	// Token: 0x06009C29 RID: 39977 RVA: 0x0028E260 File Offset: 0x0028C460
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int index;
		if (configParams.Length == 0 || !int.TryParse(configParams[0], out index))
		{
			return null;
		}
		GenericLayout<ScratchTicketCellItem, ScratchTicketCellData> cellLayout = this.CellLayout;
		UUIItem uuiitem = (cellLayout != null) ? cellLayout.GetItemByIndex(index) : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x06009C2A RID: 39978 RVA: 0x0028E2A8 File Offset: 0x0028C4A8
	private UniTask InitRoundDataList()
	{
		ScratchTicketMainView.<InitRoundDataList>d__19 <InitRoundDataList>d__;
		<InitRoundDataList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoundDataList>d__.<>4__this = this;
		<InitRoundDataList>d__.<>1__state = -1;
		<InitRoundDataList>d__.<>t__builder.Start<ScratchTicketMainView.<InitRoundDataList>d__19>(ref <InitRoundDataList>d__);
		return <InitRoundDataList>d__.<>t__builder.Task;
	}

	// Token: 0x06009C2B RID: 39979 RVA: 0x0028E2EC File Offset: 0x0028C4EC
	private UniTask InitCellLayout()
	{
		ScratchTicketMainView.<InitCellLayout>d__20 <InitCellLayout>d__;
		<InitCellLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCellLayout>d__.<>4__this = this;
		<InitCellLayout>d__.<>1__state = -1;
		<InitCellLayout>d__.<>t__builder.Start<ScratchTicketMainView.<InitCellLayout>d__20>(ref <InitCellLayout>d__);
		return <InitCellLayout>d__.<>t__builder.Task;
	}

	// Token: 0x06009C2C RID: 39980 RVA: 0x0028E330 File Offset: 0x0028C530
	private void ReSelectRoundTab()
	{
		int firstProgressRoundDataIndex = this.ScratchTicketData.GetFirstProgressRoundDataIndex();
		if (firstProgressRoundDataIndex < 0)
		{
			return;
		}
		this.TabLayout.GetLayoutItemByKey(firstProgressRoundDataIndex).SetSelect(true, true);
	}

	// Token: 0x06009C2D RID: 39981 RVA: 0x0028E368 File Offset: 0x0028C568
	private void RefreshCellLayout(ScratchTicketRoundData roundData)
	{
		List<ScratchTicketRoundResult> diagonalResult = roundData.GetDiagonalResultList();
		if (diagonalResult.Count <= 0)
		{
			return;
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ScratchTicketMainView, true);
		this.RefreshRoundReward(diagonalResult[0]);
		this.RefreshCellReward(diagonalResult[0].RewardList);
		int time = 1;
		TTimerAction action = delegate(float _)
		{
			int time;
			if (time >= diagonalResult.Count)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ScratchTicketMainView, false);
				this.ClearRevealTimer();
				return;
			}
			this.RefreshRoundReward(diagonalResult[time]);
			time = time;
			time++;
		};
		this.RevealTimerHandle = TimerSystem.GameplayTimeInstance.Forever(action, 30f, 1f, null, null, true);
	}

	// Token: 0x06009C2E RID: 39982 RVA: 0x0028E410 File Offset: 0x0028C610
	private void RefreshTipPanel()
	{
		if (this.ScratchTicketData.GetScratchCardActivityConfig() == null)
		{
			return;
		}
		Activity? localConfig = this.ScratchTicketData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		this.TitleItem.SetActivityBaseData(this.ScratchTicketData);
		this.TitleItem.SetTitleByText(this.ScratchTicketData.GetTitle());
		this.RewardLayout.RefreshByData(this.CurSelectRoundData.GetRemainRewardList(), null, false);
		this.RefreshTimerText();
		EScratchTicketRoundState roundState = this.CurSelectRoundData.GetRoundState();
		this.FunctionalItem.PanelLock.SetUiActive(roundState == EScratchTicketRoundState.Lock);
		this.FunctionalItem.PanelActivate.SetUiActive(roundState == EScratchTicketRoundState.Finish);
		this.FunctionalItem.FunctionButton.SetUiActive(false);
		this.FunctionalItem.PanelActivate.SetTextByTextId("ScratchCardActivity_CompleteDesc", Array.Empty<string>());
		string togRoundIcon = this.CurSelectRoundData.Config.Value.TogRoundIcon;
		this.SetSpriteByPath(togRoundIcon, base.GetSprite(9), false, null, null);
		bool flag = this.ScratchTicketData.IsAllRoundFinish();
		this.CaptionItem.SetCurrencyItemVisible(!flag);
		base.GetItem(10).SetUIActive(!flag);
		base.GetItem(8).SetUIActive(flag);
		List<ScratchTicketConditionData> conditionDataList = this.ScratchTicketData.GetConditionDataList();
		this.ConditionLayout.RefreshByData(conditionDataList, null, false);
	}

	// Token: 0x06009C2F RID: 39983 RVA: 0x0028E57C File Offset: 0x0028C77C
	private void RefreshTimerText()
	{
		double endOpenTime = (double)this.ScratchTicketData.EndOpenTime;
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = Math.Max(endOpenTime - serverTime, 1.0);
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ScratchCardActivity_TimeDesc", null);
		this.TitleItem.SetTimeTextByText(StringUtils.Format(localTextNew, new string[]
		{
			remainTimeDataFormat.CountDownText
		}));
		if (this.CurSelectRoundData.GetRoundState() == EScratchTicketRoundState.Lock)
		{
			double num = (double)this.CurSelectRoundData.GetUnlockTime() * Singleton<TimeUtil>.Instance.Millisecond - serverTime;
			EScratchTicketRoundState preRoundState = this.CurSelectRoundData.GetPreRoundState();
			if (num > 0.0)
			{
				CommonDefine.ICountDown remainTimeDataFormat2 = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(num);
				string textByText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("ScratchCardActivity_NoJoinTips01", null), new string[]
				{
					remainTimeDataFormat2.CountDownText
				});
				this.FunctionalItem.PanelLock.SetTextByText(textByText);
				return;
			}
			if (preRoundState != EScratchTicketRoundState.Finish)
			{
				this.FunctionalItem.PanelLock.SetTextByTextId("ScratchCardActivity_NoJoinTips02", Array.Empty<string>());
				return;
			}
			this.FunctionalItem.PanelLock.SetTextByTextId("ScratchCardActivity_NoJoinTips03", Array.Empty<string>());
		}
	}

	// Token: 0x06009C30 RID: 39984 RVA: 0x0028E6AC File Offset: 0x0028C8AC
	protected override void OnTick(float delta)
	{
		this.TickTime += delta;
		if (this.TickTime >= (float)Singleton<TimeUtil>.Instance.InverseMillisecond)
		{
			this.RefreshTimerText();
			this.TickTime %= (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
	}

	// Token: 0x06009C31 RID: 39985 RVA: 0x0028E6F8 File Offset: 0x0028C8F8
	protected override void OnBeforeHide()
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ScratchTicketMainView, false);
		this.ClearTimer();
		this.ClearRevealTimer();
	}

	// Token: 0x06009C32 RID: 39986 RVA: 0x0028E71B File Offset: 0x0028C91B
	private void ClearTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.TimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06009C33 RID: 39987 RVA: 0x0028E747 File Offset: 0x0028C947
	private void ClearRevealTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.RevealTimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RevealTimerHandle);
			this.RevealTimerHandle = null;
		}
	}

	// Token: 0x06009C34 RID: 39988 RVA: 0x0028E773 File Offset: 0x0028C973
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Refresh")
		{
			this.RefreshCellLayout(this.CurSelectRoundData);
			this.PlayFirstTabSequence(this.CurSelectRoundData);
		}
	}

	// Token: 0x06009C35 RID: 39989 RVA: 0x0028E79C File Offset: 0x0028C99C
	private void OnScratchTicketConditionRefresh()
	{
		List<ScratchTicketRoundData> roundDataList = this.ScratchTicketData.GetRoundDataList();
		this.TabLayout.RefreshByData(roundDataList, null, false);
		this.RefreshTipPanel();
	}

	// Token: 0x06009C36 RID: 39990 RVA: 0x0028E7CC File Offset: 0x0028C9CC
	private void OnClickRoundTabItem(ScratchTicketRoundData data, ScratchTicketTabItem item)
	{
		if (this.CurSelectRoundTabItem != null)
		{
			this.CurSelectRoundTabItem.SetSelect(false, false);
		}
		ScratchTicketRoundData curSelectRoundData = this.CurSelectRoundData;
		this.CurSelectRoundTabItem = item;
		this.CurSelectRoundTabItem.SetSelect(true, false);
		this.CurSelectRoundData = data;
		this.PlayTabSequence(this.CurSelectRoundData, curSelectRoundData);
		this.RefreshCellLayout(this.CurSelectRoundData);
		this.RefreshTipPanel();
	}

	// Token: 0x06009C37 RID: 39991 RVA: 0x0028E830 File Offset: 0x0028CA30
	private void OnClickCellItem(ScratchTicketCellData data)
	{
		if (!data.IsLock())
		{
			return;
		}
		if (this.CurSelectRoundData == null || this.CurSelectRoundData.GetRoundState() != EScratchTicketRoundState.InProgress)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ScratchCardActivity_ClickTips02", Array.Empty<object>());
			return;
		}
		if (this.ScratchTicketData.GetRemainCount() <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ScratchCardActivity_ClickTips01", Array.Empty<object>());
			return;
		}
		int id = this.CurSelectRoundData.Id;
		ControllerBase<ActivityScratchTicketController>.Instance.SendScratchCardRewardRequest(id, data.Index, new Action<EScratchTicketRewardType, int, List<ScratchTicketRoundResult>, List<RewardItemData>>(this.OnScratchRewardRefresh));
	}

	// Token: 0x06009C38 RID: 39992 RVA: 0x0028E8C0 File Offset: 0x0028CAC0
	private void OnScratchRewardRefresh(EScratchTicketRewardType rewardType, int roundId, List<ScratchTicketRoundResult> resultDataList, List<RewardItemData> rewardItemDataList)
	{
		if (roundId != this.CurSelectRoundData.Id)
		{
			return;
		}
		if (resultDataList.Count <= 0)
		{
			return;
		}
		if (resultDataList.Count == 1)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ScratchTicketMainView, true);
			TTimerAction action = delegate(float _)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ScratchTicketMainView, false);
				this.ShowRewardTip(rewardType, rewardItemDataList);
			};
			this.RefreshRoundReward(resultDataList[0]);
			this.PlayShakeSequence();
			TimerSystem.GameplayTimeInstance.Delay(action, resultDataList[0].DelayInterval, null, null, true, 1f);
			return;
		}
		this.RefreshRoundReward(resultDataList[0]);
		float delayInterval = resultDataList[0].DelayInterval;
		int time = 1;
		float deltaTime = 0f;
		this.PlayShakeSequence();
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ScratchTicketMainView, true);
		TTimerAction action2 = delegate(float delta)
		{
			deltaTime += delta;
			if (deltaTime < delayInterval)
			{
				return;
			}
			deltaTime %= delayInterval;
			int time;
			if (time >= resultDataList.Count)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ScratchTicketMainView, false);
				this.ShowRewardTip(rewardType, rewardItemDataList);
				this.ClearTimer();
			}
			else if (time == resultDataList.Count - 1)
			{
				this.RefreshRoundReward(resultDataList[time]);
				delayInterval = 700f;
			}
			else
			{
				this.RefreshRoundReward(resultDataList[time]);
				delayInterval = resultDataList[time].DelayInterval;
			}
			time = time;
			time++;
		};
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(action2, 50f, 1f, null, null, true);
	}

	// Token: 0x06009C39 RID: 39993 RVA: 0x0028E9FD File Offset: 0x0028CBFD
	private void PlayShakeSequence()
	{
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			base.PlaySequence("Shake", null, false);
		}, 500f, null, null, true, 1f);
	}

	// Token: 0x06009C3A RID: 39994 RVA: 0x0028EA24 File Offset: 0x0028CC24
	private void PlayTabSequence(ScratchTicketRoundData curRoundData, ScratchTicketRoundData lastRoundData)
	{
		int roundDataIndex = this.ScratchTicketData.GetRoundDataIndex(curRoundData);
		int roundDataIndex2 = this.ScratchTicketData.GetRoundDataIndex(lastRoundData);
		bool isReverse = roundDataIndex < roundDataIndex2;
		int num = Math.Min(roundDataIndex, roundDataIndex2);
		int num2 = Math.Max(roundDataIndex, roundDataIndex2);
		if (num2 == 1 && num == 0)
		{
			this.UiViewSequence.PlaySequencePurely("SwitchA", true, isReverse);
		}
		if (num2 == 2 && num == 0)
		{
			this.UiViewSequence.PlaySequencePurely("SwitchB", true, isReverse);
		}
		if (num2 == 2 && num == 1)
		{
			this.UiViewSequence.PlaySequencePurely("SwitchC", true, isReverse);
		}
	}

	// Token: 0x06009C3B RID: 39995 RVA: 0x0028EAA8 File Offset: 0x0028CCA8
	private void PlayFirstTabSequence(ScratchTicketRoundData curRoundData)
	{
		int roundDataIndex = this.ScratchTicketData.GetRoundDataIndex(curRoundData);
		if (roundDataIndex == 1)
		{
			this.UiViewSequence.PlaySequencePurely("SwitchA", true, false);
			return;
		}
		if (roundDataIndex == 2)
		{
			this.UiViewSequence.PlaySequencePurely("SwitchB", true, false);
		}
	}

	// Token: 0x06009C3C RID: 39996 RVA: 0x0028EAEF File Offset: 0x0028CCEF
	private void ShowRewardTip(EScratchTicketRewardType rewardType, List<RewardItemData> rewardItemDataList)
	{
		if (rewardType == EScratchTicketRewardType.Center)
		{
			ControllerBase<ActivityScratchTicketController>.Instance.ShowScratchTicketRewardTip(rewardItemDataList);
			this.OnScratchRewardRefreshUi();
			return;
		}
		ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1009, rewardItemDataList, new Action(this.OnScratchRewardRefreshUi));
	}

	// Token: 0x06009C3D RID: 39997 RVA: 0x0028EB24 File Offset: 0x0028CD24
	private void OnScratchRewardRefreshUi()
	{
		if (this.CurSelectRoundData.GetRoundState() == EScratchTicketRoundState.Finish)
		{
			List<ScratchTicketRoundData> roundDataList = this.ScratchTicketData.GetRoundDataList();
			this.TabLayout.RefreshByData(roundDataList, null, false);
			this.ReSelectRoundTab();
			return;
		}
		this.RefreshTipPanel();
	}

	// Token: 0x06009C3E RID: 39998 RVA: 0x0028EB68 File Offset: 0x0028CD68
	private void RefreshRoundReward(IScratchTicketRoundResult roundData)
	{
		if (roundData.RewardList.Count > 0)
		{
			this.RefreshCellReward(roundData.RewardList);
		}
		if (roundData.SequenceName != "Empty")
		{
			this.UiViewSequence.PlaySequence(roundData.SequenceName, false, null);
		}
	}

	// Token: 0x06009C3F RID: 39999 RVA: 0x0028EBBC File Offset: 0x0028CDBC
	private void RefreshCellReward(List<ScratchTicketRewardResult> resultData)
	{
		foreach (ScratchTicketRewardResult scratchTicketRewardResult in resultData)
		{
			ScratchTicketCellItem layoutItemByKey = this.CellLayout.GetLayoutItemByKey(scratchTicketRewardResult.Index);
			ScratchTicketCellData cellDataByIndex = this.CurSelectRoundData.GetCellDataByIndex(scratchTicketRewardResult.Index);
			if (layoutItemByKey != null)
			{
				layoutItemByKey.RefreshByResultData(cellDataByIndex, scratchTicketRewardResult);
			}
		}
	}

	// Token: 0x06009C40 RID: 40000 RVA: 0x0028EC38 File Offset: 0x0028CE38
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06009C41 RID: 40001 RVA: 0x0028EC41 File Offset: 0x0028CE41
	private void OnClickHelpBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(this.ScratchTicketData.GetHelpId());
	}

	// Token: 0x06009C42 RID: 40002 RVA: 0x0028EC58 File Offset: 0x0028CE58
	private ScratchTicketTabItem CreateRoundTabItem()
	{
		ScratchTicketTabItem scratchTicketTabItem = new ScratchTicketTabItem();
		scratchTicketTabItem.SetClickToggleCallback(new Action<ScratchTicketRoundData, ScratchTicketTabItem>(this.OnClickRoundTabItem));
		return scratchTicketTabItem;
	}

	// Token: 0x06009C43 RID: 40003 RVA: 0x0028EC71 File Offset: 0x0028CE71
	private ScratchTicketCellItem CreateCellItem()
	{
		ScratchTicketCellItem scratchTicketCellItem = new ScratchTicketCellItem();
		scratchTicketCellItem.SetClickCallback(new Action<ScratchTicketCellData>(this.OnClickCellItem));
		return scratchTicketCellItem;
	}

	// Token: 0x06009C44 RID: 40004 RVA: 0x0028EC8A File Offset: 0x0028CE8A
	public ScratchTicketRewardItemGrid CreateRewardGridItem()
	{
		return new ScratchTicketRewardItemGrid();
	}

	// Token: 0x040047DF RID: 18399
	[Nullable(2)]
	private ActivityTitleTypeA TitleItem;

	// Token: 0x040047E0 RID: 18400
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040047E1 RID: 18401
	[Nullable(2)]
	private ActivityFunctionalTypeA FunctionalItem;

	// Token: 0x040047E2 RID: 18402
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ScratchTicketConditionItem, ScratchTicketConditionData> ConditionLayout;

	// Token: 0x040047E3 RID: 18403
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ScratchTicketTabItem, ScratchTicketRoundData> TabLayout;

	// Token: 0x040047E4 RID: 18404
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ScratchTicketCellItem, ScratchTicketCellData> CellLayout;

	// Token: 0x040047E5 RID: 18405
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ScratchTicketRewardItemGrid, TItem> RewardLayout;

	// Token: 0x040047E6 RID: 18406
	[Nullable(2)]
	private ScratchTicketData ScratchTicketData;

	// Token: 0x040047E7 RID: 18407
	[Nullable(2)]
	private ScratchTicketTabItem CurSelectRoundTabItem;

	// Token: 0x040047E8 RID: 18408
	[Nullable(2)]
	private ScratchTicketRoundData CurSelectRoundData;

	// Token: 0x040047E9 RID: 18409
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040047EA RID: 18410
	[Nullable(2)]
	private TimerHandle RevealTimerHandle;

	// Token: 0x040047EB RID: 18411
	private float TickTime = (float)Singleton<TimeUtil>.Instance.InverseMillisecond;

	// Token: 0x040047EC RID: 18412
	private readonly Func<ScratchTicketConditionItem> CreateConditionItem = () => new ScratchTicketConditionItem();

	// Token: 0x02007969 RID: 31081
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04029B4A RID: 170826
		public const int TitleItem = 0;

		// Token: 0x04029B4B RID: 170827
		public const int FunctionItem = 1;

		// Token: 0x04029B4C RID: 170828
		public const int ScratchTicketRootItem = 2;

		// Token: 0x04029B4D RID: 170829
		public const int ScratchTicketConditionLayout = 3;

		// Token: 0x04029B4E RID: 170830
		public const int ScratchTicketTabLayout = 4;

		// Token: 0x04029B4F RID: 170831
		public const int ScratchTicketCellLayout = 5;

		// Token: 0x04029B50 RID: 170832
		public const int CaptionItem = 6;

		// Token: 0x04029B51 RID: 170833
		public const int RewardLayout = 7;

		// Token: 0x04029B52 RID: 170834
		public const int EmptyItem = 8;

		// Token: 0x04029B53 RID: 170835
		public const int RoundSprite = 9;

		// Token: 0x04029B54 RID: 170836
		public const int ScratchTicketConditionRoot = 10;
	}
}
