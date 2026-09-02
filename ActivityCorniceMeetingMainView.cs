using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020012AD RID: 4781
[NullableContext(1)]
[Nullable(0)]
public class ActivityCorniceMeetingMainView : UiViewBase
{
	// Token: 0x06008031 RID: 32817 RVA: 0x0021DC6B File Offset: 0x0021BE6B
	public ActivityCorniceMeetingMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008032 RID: 32818 RVA: 0x0021DC80 File Offset: 0x0021BE80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickBtnChallenge));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008033 RID: 32819 RVA: 0x0021DE98 File Offset: 0x0021C098
	private void OnClickBtnChallenge()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		if (!currentActivityData.GetIsShow(currentActivityData.CurrentSelectLevelPlayId))
		{
			return;
		}
		ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(currentActivityData.CurrentSelectLevelPlayId);
		if (levelEntryData == null)
		{
			return;
		}
		int markId = levelEntryData.GetMarkId();
		WorldMapViewOpenParams data = new WorldMapViewOpenParams
		{
			MarkId = new int?(markId),
			MarkType = EMarkType.CorniceMeeting,
			OpenFogId = new int?(0)
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
	}

	// Token: 0x06008034 RID: 32820 RVA: 0x0021DF0C File Offset: 0x0021C10C
	protected override void OnStart()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		this.CurrentActivity = currentActivityData.GetLevelEntryData(currentActivityData.GetDefaultSelectLevelPlayId());
		this.RewardLayout = new GenericLayout<ActivityCorniceMeetingRewardItem, ActivityCorniceMeetingRewardItemData>(base.GetVerticalLayout(4), new Func<ActivityCorniceMeetingRewardItem>(this.CreateTaskItem), null, false, true);
		this.TabLoopScrollView = new LoopScrollView<ActivityCorniceMeetingTabItem, int>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<ActivityCorniceMeetingTabItem>(this.CreateActivityItem), false);
		this.InitCaptionItem();
		this.RefreshTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimerRefresh), 1000f, 1f, null, null, true);
	}

	// Token: 0x06008035 RID: 32821 RVA: 0x0021DFB6 File Offset: 0x0021C1B6
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().Id);
	}

	// Token: 0x06008036 RID: 32822 RVA: 0x0021DFD8 File Offset: 0x0021C1D8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnClickActivityCorniceMeetingTab, new Action<int>(this.OnClickActivityCorniceMeetingTab));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCorniceMeetingRedDot, new Action<int>(this.RefreshTabState));
	}

	// Token: 0x06008037 RID: 32823 RVA: 0x0021E03C File Offset: 0x0021C23C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickActivityCorniceMeetingTab, new Action<int>(this.OnClickActivityCorniceMeetingTab));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCorniceMeetingRedDot, new Action<int>(this.RefreshTabState));
	}

	// Token: 0x06008038 RID: 32824 RVA: 0x0021E0A0 File Offset: 0x0021C2A0
	private void RefreshTabState(int i)
	{
		int selectedGridIndex = this.TabLoopScrollView.GetSelectedGridIndex();
		this.TabLoopScrollView.RefreshGridProxy(selectedGridIndex);
	}

	// Token: 0x06008039 RID: 32825 RVA: 0x0021E0C8 File Offset: 0x0021C2C8
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		if (closeActivities.Contains(ControllerBase<ActivityCorniceMeetingController>.Instance.ActivityId))
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
			confirmBoxDataNew.FunctionMap[1] = new Action(this.<OnActivityClose>g__confirmCallback|15_0);
			confirmBoxDataNew.FunctionMap[0] = new Action(this.<OnActivityClose>g__confirmCallback|15_0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x0600803A RID: 32826 RVA: 0x0021E12C File Offset: 0x0021C32C
	private void OnClickActivityCorniceMeetingTab(int levelPlayId)
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		currentActivityData.CurrentSelectLevelPlayId = levelPlayId;
		this.CurrentActivity = currentActivityData.GetLevelEntryData(levelPlayId);
		this.RefreshRewardView();
		this.RefreshContainer();
		this.RefreshBestScore();
		base.PlaySequenceAsync("Switch", true, false, null);
	}

	// Token: 0x0600803B RID: 32827 RVA: 0x0021E181 File Offset: 0x0021C381
	protected override void OnBeforeShow()
	{
		this.RefreshLoopScrollView();
		this.RefreshRewardView();
		this.RefreshContainer();
		this.RefreshBestScore();
	}

	// Token: 0x0600803C RID: 32828 RVA: 0x0021E19C File Offset: 0x0021C39C
	protected override void OnBeforeDestroy()
	{
		if (this.RefreshTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.ActivityCorniceMeeting);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().Id);
	}

	// Token: 0x0600803D RID: 32829 RVA: 0x0021E1F8 File Offset: 0x0021C3F8
	private void InitCaptionItem()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickBackBtn));
		this.CaptionItem.SetHelpCallBack(new Action(this.OnClickMoreButton));
		this.CaptionItem.SetTitle(currentActivityData.GetTitle());
	}

	// Token: 0x0600803E RID: 32830 RVA: 0x0021E264 File Offset: 0x0021C464
	private ActivityCorniceMeetingTabItem CreateActivityItem()
	{
		ActivityCorniceMeetingTabItem activityCorniceMeetingTabItem = new ActivityCorniceMeetingTabItem();
		this.TabItemProxyList.Add(activityCorniceMeetingTabItem);
		return activityCorniceMeetingTabItem;
	}

	// Token: 0x0600803F RID: 32831 RVA: 0x0021E284 File Offset: 0x0021C484
	private ActivityCorniceMeetingRewardItem CreateTaskItem()
	{
		return new ActivityCorniceMeetingRewardItem();
	}

	// Token: 0x06008040 RID: 32832 RVA: 0x0021E28B File Offset: 0x0021C48B
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06008041 RID: 32833 RVA: 0x0021E294 File Offset: 0x0021C494
	private void OnClickMoreButton()
	{
		int helpId = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().GetHelpId();
		ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
	}

	// Token: 0x06008042 RID: 32834 RVA: 0x0021E2BC File Offset: 0x0021C4BC
	private void OnTimerRefresh(float _)
	{
		this.RefreshCountDownText();
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		bool isShow = currentActivityData.GetIsShow(currentActivityData.CurrentSelectLevelPlayId);
		if (isShow && this.IsLastShow != isShow)
		{
			int selectedGridIndex = this.TabLoopScrollView.GetSelectedGridIndex();
			this.TabLoopScrollView.RefreshGridProxy(selectedGridIndex);
			this.RefreshBestScore();
			this.RefreshContainer();
		}
		this.IsLastShow = isShow;
	}

	// Token: 0x06008043 RID: 32835 RVA: 0x0021E324 File Offset: 0x0021C524
	private void RefreshCountDownText()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		if (!currentActivityData.GetIsShow(currentActivityData.CurrentSelectLevelPlayId))
		{
			ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(currentActivityData.CurrentSelectLevelPlayId);
			string remainTimeText = this.GetRemainTimeText((float)(levelEntryData.UnlockTime / 1000L), "ActiveToOpenTime");
			base.GetText(8).SetText(remainTimeText, true);
		}
	}

	// Token: 0x06008044 RID: 32836 RVA: 0x0021E380 File Offset: 0x0021C580
	private string GetRemainTimeText(float dataTime, string timeText)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = (double)((int)dataTime) - serverTime;
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime);
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById(timeText), null).Replace("{0}", remainTimeDataFormat.CountDownText);
	}

	// Token: 0x06008045 RID: 32837 RVA: 0x0021E3CC File Offset: 0x0021C5CC
	private void RefreshRewardView()
	{
		List<ActivityCorniceMeetingRewardItemData> data = (from item in this.CurrentActivity.GetRewardList()
		select new ActivityCorniceMeetingRewardItemData
		{
			RewardId = item,
			OnClickFinishBtnCb = new Action(this.OnClickGetReward)
		}).ToList<ActivityCorniceMeetingRewardItemData>();
		this.RewardLayout.RefreshByData(data, null, false);
	}

	// Token: 0x06008046 RID: 32838 RVA: 0x0021E40C File Offset: 0x0021C60C
	private void OnClickGetReward()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		int levelPlayId = this.TabItemProxyList[this.TabLoopScrollView.GetSelectedGridIndex()].LevelPlayId;
		ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(levelPlayId);
		if (levelEntryData == null)
		{
			return;
		}
		List<int> rewardList = levelEntryData.GetRewardList();
		for (int i = 0; i < rewardList.Count; i++)
		{
			if (currentActivityData.GetRewardState(levelPlayId, i) == ECorniceMeetingRewardState.Finished)
			{
				if (dictionary.ContainsKey(levelPlayId))
				{
					dictionary[levelPlayId].Add(i);
				}
				else
				{
					dictionary[levelPlayId] = new List<int>
					{
						i
					};
				}
			}
		}
		ControllerBase<ActivityCorniceMeetingController>.Instance.MultiCorniceMeetingRewardRequest(currentActivityData.Id, dictionary, delegate
		{
			this.RefreshRewardView();
			this.RefreshLoopScrollView();
		});
	}

	// Token: 0x06008047 RID: 32839 RVA: 0x0021E4C8 File Offset: 0x0021C6C8
	private void RefreshLoopScrollView()
	{
		ActivityCorniceMeetingData activityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		List<int> levelPlayIdList = activityData.GetLevelPlayIdList(true);
		this.TabLoopScrollView.BindOnScrollValueChanged(delegate(FVector2D progress)
		{
			bool uiactive = false;
			bool uiactive2 = false;
			for (int i = 0; i < this.TabItemProxyList.Count; i++)
			{
				ActivityCorniceMeetingTabItem activityCorniceMeetingTabItem = this.TabItemProxyList[i];
				if (activityCorniceMeetingTabItem != null)
				{
					ActivityCorniceMeetingLevelEntryData levelEntryData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().GetLevelEntryData(activityCorniceMeetingTabItem.LevelPlayId);
					if (levelEntryData != null)
					{
						if (levelEntryData.GetRedDot() && i < this.TabLoopScrollView.GetDisplayGridStartIndex())
						{
							uiactive = true;
						}
						if (levelEntryData.GetRedDot() && i > this.TabLoopScrollView.GetDisplayGridEndIndex())
						{
							uiactive2 = true;
						}
					}
				}
			}
			this.GetItem(10).SetUIActive(uiactive);
			this.GetItem(11).SetUIActive(uiactive2);
		});
		this.TabLoopScrollView.RefreshByData(levelPlayIdList, false, delegate
		{
			LoopScrollView<ActivityCorniceMeetingTabItem, int> tabLoopScrollView = this.TabLoopScrollView;
			if (tabLoopScrollView == null)
			{
				return;
			}
			tabLoopScrollView.SelectGridProxy(activityData.GetSelectLevelPlayIdIndex(), false);
		}, false);
	}

	// Token: 0x06008048 RID: 32840 RVA: 0x0021E530 File Offset: 0x0021C730
	private void RefreshContainer()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		bool isShow = currentActivityData.GetIsShow(currentActivityData.CurrentSelectLevelPlayId);
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(4);
		if (verticalLayout != null)
		{
			verticalLayout.RootUIComp.Get().SetUIActive(isShow);
		}
		base.GetItem(3).SetUIActive(!isShow);
		UUIButtonComponent button = base.GetButton(7);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(isShow);
	}

	// Token: 0x06008049 RID: 32841 RVA: 0x0021E5A4 File Offset: 0x0021C7A4
	private void RefreshBestScore()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(currentActivityData.CurrentSelectLevelPlayId);
		string timeString = Singleton<TimeUtil>.Instance.GetTimeString((double)levelEntryData.RemainTime);
		if (levelEntryData != null && levelEntryData.MaxScore == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "ActivityCorniceMeetingScoreNoRecord", Array.Empty<object>());
		}
		else
		{
			int maxScore = levelEntryData.MaxScore;
			int num = (levelEntryData != null) ? levelEntryData.GetMaxScoreConfig() : 0;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Text_ItemCost_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				((maxScore > num) ? num : maxScore).ToString(),
				num.ToString()
			}));
		}
		base.GetItem(9).SetUIActive(levelEntryData.IsAllFinished());
		base.GetText(6).SetText(timeString, true);
		base.GetItem(12).SetUIActive(levelEntryData.IsUnlock());
	}

	// Token: 0x0600804A RID: 32842 RVA: 0x0021E688 File Offset: 0x0021C888
	[CompilerGenerated]
	private void <OnActivityClose>g__confirmCallback|15_0()
	{
		base.CloseMe(null);
	}

	// Token: 0x04003D36 RID: 15670
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003D37 RID: 15671
	[Nullable(2)]
	private ActivityCorniceMeetingLevelEntryData CurrentActivity;

	// Token: 0x04003D38 RID: 15672
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<ActivityCorniceMeetingTabItem, int> TabLoopScrollView;

	// Token: 0x04003D39 RID: 15673
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ActivityCorniceMeetingRewardItem, ActivityCorniceMeetingRewardItemData> RewardLayout;

	// Token: 0x04003D3A RID: 15674
	[Nullable(2)]
	private TimerHandle RefreshTimer;

	// Token: 0x04003D3B RID: 15675
	private readonly List<ActivityCorniceMeetingTabItem> TabItemProxyList = new List<ActivityCorniceMeetingTabItem>();

	// Token: 0x04003D3C RID: 15676
	private bool IsLastShow;

	// Token: 0x02007622 RID: 30242
	[NullableContext(0)]
	private class EActivityCorniceMeetingMainViewComponents
	{
		// Token: 0x04028B8D RID: 166797
		public const int CaptionItem = 0;

		// Token: 0x04028B8E RID: 166798
		public const int LoopScrollViewItem = 1;

		// Token: 0x04028B8F RID: 166799
		public const int LoopScrollItem = 2;

		// Token: 0x04028B90 RID: 166800
		public const int PanelLock = 3;

		// Token: 0x04028B91 RID: 166801
		public const int PanelRewardLayout = 4;

		// Token: 0x04028B92 RID: 166802
		public const int TxtBestScore = 5;

		// Token: 0x04028B93 RID: 166803
		public const int TxtBestTime = 6;

		// Token: 0x04028B94 RID: 166804
		public const int BtnChallenge = 7;

		// Token: 0x04028B95 RID: 166805
		public const int LockText = 8;

		// Token: 0x04028B96 RID: 166806
		public const int PanelTime = 9;

		// Token: 0x04028B97 RID: 166807
		public const int PreRedDotItem = 10;

		// Token: 0x04028B98 RID: 166808
		public const int NextRedDotItem = 11;

		// Token: 0x04028B99 RID: 166809
		public const int PanelScore = 12;
	}
}
