using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200171B RID: 5915
[NullableContext(1)]
[Nullable(0)]
public class WuWuLogisticsMissionView : UiViewBase
{
	// Token: 0x0600A45E RID: 42078 RVA: 0x002B7316 File Offset: 0x002B5516
	public WuWuLogisticsMissionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A45F RID: 42079 RVA: 0x002B7328 File Offset: 0x002B5528
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUISprite)),
			new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout))
		};
	}

	// Token: 0x0600A460 RID: 42080 RVA: 0x002B7464 File Offset: 0x002B5664
	protected override UniTask OnBeforeStartAsync()
	{
		WuWuLogisticsMissionView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WuWuLogisticsMissionView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A461 RID: 42081 RVA: 0x002B74A8 File Offset: 0x002B56A8
	protected override void OnStart()
	{
		this.InitCaption();
		this.PackLayout = new GenericLayout<WuWuLogisticsPackItem, int>(base.GetVerticalLayout(1), new Func<WuWuLogisticsPackItem>(this.InitPackItem), null, false, true);
		this.MissionScrollView = new GenericScrollViewNew<WuWuLogisticsMissionItem, int>(base.GetScrollViewWithScrollbar(4), new Func<WuWuLogisticsMissionItem>(this.InitMissionItem), null, false, null);
		this.LogisiticsInfoScrollView = new GenericScrollViewNew<WuWuLogisticsInfoItem, IWuWuLogisticsInfoItemData>(base.GetScrollViewWithScrollbar(7), new Func<WuWuLogisticsInfoItem>(this.InitInfoItem), null, false, null);
		this.AnimationController = (base.GetVerticalLayout(12).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor == null)
		{
			return;
		}
		rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
	}

	// Token: 0x0600A462 RID: 42082 RVA: 0x002B7568 File Offset: 0x002B5768
	protected override void OnBeforeShow()
	{
		this.Data = ControllerBase<WuWuLogisticsActivityController>.Instance.GetActivityData();
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			WuWuLogisticsActivityData data = this.Data;
			captionItem.SetTitle((data != null) ? data.GetTitle() : null);
		}
		WuWuLogisticsActivityData data2 = this.Data;
		this.CurSelectedPackCfgId = ((data2 != null) ? data2.GetDefaultOpenPackCfgId() : 0);
		this.UpdateCurSelectedContent();
		WuWuLogisticsActivityData data3 = this.Data;
		if (data3 == null)
		{
			return;
		}
		data3.SetFirstUnlockPack();
	}

	// Token: 0x0600A463 RID: 42083 RVA: 0x002B75D6 File Offset: 0x002B57D6
	protected override void OnBeforeDestroy()
	{
		this.StopUnlockTimeTimer();
	}

	// Token: 0x0600A464 RID: 42084 RVA: 0x002B75DE File Offset: 0x002B57DE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WuWuLogisticsTaskUpdate, new Action(this.UpdateCurSelectedContent));
	}

	// Token: 0x0600A465 RID: 42085 RVA: 0x002B75FC File Offset: 0x002B57FC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WuWuLogisticsTaskUpdate, new Action(this.UpdateCurSelectedContent));
	}

	// Token: 0x0600A466 RID: 42086 RVA: 0x002B761A File Offset: 0x002B581A
	private void OnPlaySequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "Sequence_Switch")
		{
			this.UpdateMissionInfo();
			this.UpdateInfoScroll();
			this.UpdatePackRewardPanel();
			this.SetCurIndexIcon();
		}
	}

	// Token: 0x0600A467 RID: 42087 RVA: 0x002B7644 File Offset: 0x002B5844
	private void InitCaption()
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			this.CaptionItem = new PopupCaptionItem(item);
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.CaptionItem.SetHelpCallBack(delegate
			{
				if (this.Data == null)
				{
					return;
				}
				ControllerBase<HelpController>.Instance.OpenHelpById(this.Data.LocalConfig.Value.HelpId);
			});
			this.CaptionItem.SetCloseBtnActive(true);
		}
	}

	// Token: 0x0600A468 RID: 42088 RVA: 0x002B76A2 File Offset: 0x002B58A2
	private WuWuLogisticsPackItem InitPackItem()
	{
		WuWuLogisticsPackItem wuWuLogisticsPackItem = new WuWuLogisticsPackItem();
		wuWuLogisticsPackItem.SetClickCallback(new Action<int>(this.OnClickPackItem));
		return wuWuLogisticsPackItem;
	}

	// Token: 0x0600A469 RID: 42089 RVA: 0x002B76BB File Offset: 0x002B58BB
	private WuWuLogisticsMissionItem InitMissionItem()
	{
		WuWuLogisticsMissionItem wuWuLogisticsMissionItem = new WuWuLogisticsMissionItem();
		wuWuLogisticsMissionItem.SetClickCallback(new Action<int>(this.OnClickMissionItem));
		return wuWuLogisticsMissionItem;
	}

	// Token: 0x0600A46A RID: 42090 RVA: 0x002B76D4 File Offset: 0x002B58D4
	private WuWuLogisticsInfoItem InitInfoItem()
	{
		return new WuWuLogisticsInfoItem();
	}

	// Token: 0x0600A46B RID: 42091 RVA: 0x002B76DC File Offset: 0x002B58DC
	private void OnClickPackItem(int cfgId)
	{
		if (cfgId == this.CurSelectedPackCfgId)
		{
			return;
		}
		this.CurSelectedPackCfgId = cfgId;
		this.SetOtherPackTogglesInteractive(cfgId, false);
		this.UpdatePackLayout();
		base.PlaySequence("Switch", delegate
		{
			this.SetAllPackTogglesInteractive(true);
		}, false);
		UUIInturnAnimController animationController = this.AnimationController;
		if (animationController == null)
		{
			return;
		}
		animationController.Play("Start", -1, false);
	}

	// Token: 0x0600A46C RID: 42092 RVA: 0x002B7738 File Offset: 0x002B5938
	private void SetOtherPackTogglesInteractive(int clickedCfgId, bool interactive)
	{
		GenericLayout<WuWuLogisticsPackItem, int> packLayout = this.PackLayout;
		if (packLayout == null)
		{
			return;
		}
		IReadOnlyList<int> datas = packLayout.GetDatas();
		List<WuWuLogisticsPackItem> layoutItemList = packLayout.GetLayoutItemList();
		for (int i = 0; i < layoutItemList.Count; i++)
		{
			if (datas[i] != clickedCfgId)
			{
				layoutItemList[i].SetPackToggleInteractive(interactive);
			}
		}
	}

	// Token: 0x0600A46D RID: 42093 RVA: 0x002B7788 File Offset: 0x002B5988
	private void SetAllPackTogglesInteractive(bool interactive)
	{
		GenericLayout<WuWuLogisticsPackItem, int> packLayout = this.PackLayout;
		List<WuWuLogisticsPackItem> list = (packLayout != null) ? packLayout.GetLayoutItemList() : null;
		if (list == null)
		{
			return;
		}
		foreach (WuWuLogisticsPackItem wuWuLogisticsPackItem in list)
		{
			wuWuLogisticsPackItem.SetPackToggleInteractive(interactive);
		}
	}

	// Token: 0x0600A46E RID: 42094 RVA: 0x002B77EC File Offset: 0x002B59EC
	private void OnClickMissionItem(int taskId)
	{
		WuWuLogisticsActivityData data = this.Data;
		List<int> list = (data != null) ? data.GetTargetPackCanReceiveTaskIds(this.CurSelectedPackCfgId) : null;
		if (list != null && list.Count > 0)
		{
			ControllerBase<WuWuLogisticsActivityController>.Instance.RequestTaskReward(list);
		}
	}

	// Token: 0x0600A46F RID: 42095 RVA: 0x002B7829 File Offset: 0x002B5A29
	private void UpdateCurSelectedContent()
	{
		this.UpdatePackLayout();
		this.UpdateMissionInfo();
		this.UpdateInfoScroll();
		this.UpdatePackRewardPanel();
		this.SetCurIndexIcon();
	}

	// Token: 0x0600A470 RID: 42096 RVA: 0x002B784C File Offset: 0x002B5A4C
	private void UpdateInfoScroll()
	{
		WuWuLogisticsMissionView.<>c__DisplayClass27_0 CS$<>8__locals1 = new WuWuLogisticsMissionView.<>c__DisplayClass27_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.Data == null || this.CurSelectedPackCfgId == 0)
		{
			return;
		}
		WuWuTaskPackage? taskPackageById = ConfigBase<WuWuLogisticsConfig>.Instance.GetTaskPackageById(this.CurSelectedPackCfgId);
		if (taskPackageById == null)
		{
			return;
		}
		IReadOnlyList<WuWuLogisticsDesc> descListByGroupId = ConfigBase<WuWuLogisticsConfig>.Instance.GetDescListByGroupId(taskPackageById.Value.DescGroupId);
		if (descListByGroupId == null)
		{
			return;
		}
		CS$<>8__locals1.infoDataList = new List<IWuWuLogisticsInfoItemData>();
		WuWuTaskPackData taskPackById = this.Data.GetTaskPackById(this.CurSelectedPackCfgId);
		if (taskPackById == null)
		{
			return;
		}
		WuWuLogisticsActivityData activityData = ControllerBase<WuWuLogisticsActivityController>.Instance.GetActivityData();
		if (activityData == null)
		{
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		foreach (WuWuLogisticsDesc wuWuLogisticsDesc in descListByGroupId)
		{
			long num = (long)(wuWuLogisticsDesc.UnlockTime * Singleton<TimeUtil>.Instance.OneDaySeconds) + activityData.BeginOpenTime;
			if (serverTime >= (double)num)
			{
				CS$<>8__locals1.infoDataList.Add(new WuWuLogisticsInfoItemData
				{
					CfgId = wuWuLogisticsDesc.Id,
					IsToday = false,
					Content = null
				});
			}
		}
		if (activityData.IsPackUnlocked(this.CurSelectedPackCfgId))
		{
			WuWuLogisticsInfoItemData item = new WuWuLogisticsInfoItemData
			{
				CfgId = 0,
				IsToday = false,
				Content = "Express_Delivery_Unlock"
			};
			CS$<>8__locals1.infoDataList.Add(item);
		}
		if (taskPackById.HadReward)
		{
			WuWuLogisticsInfoItemData item2 = new WuWuLogisticsInfoItemData
			{
				CfgId = 0,
				IsToday = false,
				Content = "Express_Delivery_Finished"
			};
			CS$<>8__locals1.infoDataList.Add(item2);
		}
		if (CS$<>8__locals1.infoDataList.Count > 0)
		{
			CS$<>8__locals1.infoDataList[CS$<>8__locals1.infoDataList.Count - 1].IsToday = true;
		}
		GenericScrollViewNew<WuWuLogisticsInfoItem, IWuWuLogisticsInfoItemData> logisiticsInfoScrollView = this.LogisiticsInfoScrollView;
		if (logisiticsInfoScrollView == null)
		{
			return;
		}
		logisiticsInfoScrollView.RefreshByData(CS$<>8__locals1.infoDataList, delegate
		{
			WuWuLogisticsMissionView.<>c__DisplayClass27_1 CS$<>8__locals2 = new WuWuLogisticsMissionView.<>c__DisplayClass27_1();
			CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
			WuWuLogisticsMissionView.<>c__DisplayClass27_1 CS$<>8__locals3 = CS$<>8__locals2;
			GenericScrollViewNew<WuWuLogisticsInfoItem, IWuWuLogisticsInfoItemData> logisiticsInfoScrollView2 = CS$<>8__locals1.<>4__this.LogisiticsInfoScrollView;
			CS$<>8__locals3.lastItem = ((logisiticsInfoScrollView2 != null) ? logisiticsInfoScrollView2.GetItemByIndex(CS$<>8__locals1.infoDataList.Count - 1) : null);
			if (CS$<>8__locals2.lastItem != null)
			{
				TimerSystem.GameplayTimeInstance.Delay(delegate(float delta)
				{
					GenericScrollViewNew<WuWuLogisticsInfoItem, IWuWuLogisticsInfoItemData> logisiticsInfoScrollView3 = CS$<>8__locals2.CS$<>8__locals1.<>4__this.LogisiticsInfoScrollView;
					if (logisiticsInfoScrollView3 == null)
					{
						return;
					}
					logisiticsInfoScrollView3.LateScrollTo(CS$<>8__locals2.lastItem, null, false);
				}, 100f, null, null, true, 1f);
			}
		}, false);
	}

	// Token: 0x0600A471 RID: 42097 RVA: 0x002B7A40 File Offset: 0x002B5C40
	private void UpdatePackLayout()
	{
		IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
		if (allTaskPackage == null)
		{
			return;
		}
		List<int> list = new List<int>();
		int selectedIndex = 0;
		for (int i = 0; i < allTaskPackage.Count; i++)
		{
			WuWuTaskPackage wuWuTaskPackage = allTaskPackage[i];
			if (wuWuTaskPackage.Id == this.CurSelectedPackCfgId)
			{
				selectedIndex = i;
			}
			list.Add(wuWuTaskPackage.Id);
		}
		GenericLayout<WuWuLogisticsPackItem, int> packLayout = this.PackLayout;
		if (packLayout == null)
		{
			return;
		}
		packLayout.RefreshByData(list, delegate
		{
			GenericLayout<WuWuLogisticsPackItem, int> packLayout2 = this.PackLayout;
			if (packLayout2 == null)
			{
				return;
			}
			packLayout2.SelectGridProxy(selectedIndex, false);
		}, false);
	}

	// Token: 0x0600A472 RID: 42098 RVA: 0x002B7AD4 File Offset: 0x002B5CD4
	private void UpdateMissionInfo()
	{
		if (this.Data == null || this.CurSelectedPackCfgId == 0)
		{
			return;
		}
		if (this.Data.GetTaskPackById(this.CurSelectedPackCfgId) == null)
		{
			return;
		}
		bool flag = this.Data.IsPackUnlocked(this.CurSelectedPackCfgId);
		base.GetScrollViewWithScrollbar(4).RootUIComp.Get().SetUIActive(flag);
		base.GetItem(6).SetUIActive(!flag);
		base.GetText(3).SetUIActive(flag);
		base.GetScrollViewWithScrollbar(4).RootUIComp.Get().SetUIActive(flag);
		this.SetLockTips();
		if (!flag)
		{
			return;
		}
		List<int> list = new List<int>();
		IReadOnlyList<WuWuWeekTask> weekTaskByWrapId = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskByWrapId(this.CurSelectedPackCfgId);
		if (weekTaskByWrapId != null)
		{
			int num = 0;
			foreach (WuWuWeekTask wuWuWeekTask in weekTaskByWrapId)
			{
				list.Add(wuWuWeekTask.Id);
				WuWuTaskData taskById = this.Data.GetTaskById(wuWuWeekTask.Id);
				if (taskById != null && taskById.IsRewarded)
				{
					num++;
				}
			}
			this.UpdateCurProgressTitle(num, weekTaskByWrapId.Count);
		}
		GenericScrollViewNew<WuWuLogisticsMissionItem, int> missionScrollView = this.MissionScrollView;
		if (missionScrollView == null)
		{
			return;
		}
		missionScrollView.RefreshByData(list, null, false);
	}

	// Token: 0x0600A473 RID: 42099 RVA: 0x002B7C20 File Offset: 0x002B5E20
	private void UpdateCurProgressTitle(int finishCount, int allMission)
	{
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Express_Delivery_Task_Progress");
		string[] array = new string[2];
		int num = 0;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
		defaultInterpolatedStringHandler.AppendLiteral("<color=#ffa200>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(finishCount);
		defaultInterpolatedStringHandler.AppendLiteral("</color>");
		array[num] = defaultInterpolatedStringHandler.ToStringAndClear();
		int num2 = 1;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(allMission);
		array[num2] = defaultInterpolatedStringHandler.ToStringAndClear();
		string newText = StringUtils.Format(multiTextByKey, array);
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x0600A474 RID: 42100 RVA: 0x002B7CAA File Offset: 0x002B5EAA
	private void UpdatePackRewardPanel()
	{
		WuWuLogisticsRewardPreviewPanel packRewardPanel = this.PackRewardPanel;
		if (packRewardPanel != null)
		{
			packRewardPanel.SetPackConfigId(this.CurSelectedPackCfgId, this.Data);
		}
		WuWuLogisticsRewardPreviewPanel packRewardPanel2 = this.PackRewardPanel;
		if (packRewardPanel2 == null)
		{
			return;
		}
		packRewardPanel2.RefreshConfirmButtonRedPoint();
	}

	// Token: 0x0600A475 RID: 42101 RVA: 0x002B7CDC File Offset: 0x002B5EDC
	private void SetLockTips()
	{
		this.StopUnlockTimeTimer();
		WuWuTaskPackData taskPackById = this.Data.GetTaskPackById(this.CurSelectedPackCfgId);
		if (taskPackById == null)
		{
			return;
		}
		bool isUnlock = taskPackById.IsUnlock;
		bool flag = this.Data.IsPackUnlocked(this.CurSelectedPackCfgId);
		if (isUnlock && flag)
		{
			return;
		}
		if (!isUnlock)
		{
			this.StartUnlockTimeTimer(taskPackById.UnlockTime);
			return;
		}
		if (!flag)
		{
			UUIText text = base.GetText(10);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew("Express_Delivery_Delivered");
		}
	}

	// Token: 0x0600A476 RID: 42102 RVA: 0x002B7D50 File Offset: 0x002B5F50
	private void RefreshUnlockTimeText(long unlockTime)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if ((double)unlockTime - serverTime <= 0.0)
		{
			this.UpdateCurSelectedContent();
			this.StopUnlockTimeTimer();
			return;
		}
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Activity_Anniversary2_04_Time");
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(unlockTime, multiTextByKey);
		if (string.IsNullOrEmpty(remainTimeText))
		{
			return;
		}
		UUIText text = base.GetText(10);
		if (text == null)
		{
			return;
		}
		text.SetText(remainTimeText, true);
	}

	// Token: 0x0600A477 RID: 42103 RVA: 0x002B7DC0 File Offset: 0x002B5FC0
	private void StartUnlockTimeTimer(long unlockTime)
	{
		this.RefreshUnlockTimeText(unlockTime);
		this.TickHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
		{
			this.RefreshUnlockTimeText(unlockTime);
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0600A478 RID: 42104 RVA: 0x002B7E16 File Offset: 0x002B6016
	private void StopUnlockTimeTimer()
	{
		if (this.TickHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TickHandle);
			this.TickHandle = null;
		}
	}

	// Token: 0x0600A479 RID: 42105 RVA: 0x002B7E38 File Offset: 0x002B6038
	private void SetCurIndexIcon()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_NumA0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurSelectedPackCfgId);
		string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(11), false, null, null);
	}

	// Token: 0x04004E18 RID: 19992
	[Nullable(2)]
	protected WuWuLogisticsActivityData Data;

	// Token: 0x04004E19 RID: 19993
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004E1A RID: 19994
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WuWuLogisticsPackItem, int> PackLayout;

	// Token: 0x04004E1B RID: 19995
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<WuWuLogisticsMissionItem, int> MissionScrollView;

	// Token: 0x04004E1C RID: 19996
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WuWuLogisticsInfoItem, IWuWuLogisticsInfoItemData> LogisiticsInfoScrollView;

	// Token: 0x04004E1D RID: 19997
	[Nullable(2)]
	private WuWuLogisticsRewardPreviewPanel PackRewardPanel;

	// Token: 0x04004E1E RID: 19998
	private int CurSelectedPackCfgId = 1;

	// Token: 0x04004E1F RID: 19999
	[Nullable(2)]
	protected TimerHandle TickHandle;

	// Token: 0x04004E20 RID: 20000
	[Nullable(2)]
	private UUIInturnAnimController AnimationController;
}
