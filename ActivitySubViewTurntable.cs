using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015E5 RID: 5605
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewTurntable : ActivitySubViewBase
{
	// Token: 0x06009DCD RID: 40397 RVA: 0x002948B4 File Offset: 0x00292AB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009DCE RID: 40398 RVA: 0x00294AD1 File Offset: 0x00292CD1
	protected override void OnSetData()
	{
		this.ActivityTurntableData = (this.ActivityBaseData as ActivityTurntableData);
	}

	// Token: 0x06009DCF RID: 40399 RVA: 0x00294AE4 File Offset: 0x00292CE4
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewTurntable.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewTurntable.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009DD0 RID: 40400 RVA: 0x00294B28 File Offset: 0x00292D28
	protected override void OnStart()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		this.FunctionalArea.FunctionButton.SetFunction(new Action(this.OnClickedTurntableRun));
		this.FunctionalArea.SetFunctionRedDotVisible(true);
		this.TurntableAnim.SetActive(false);
		this.TurntableAnim.Activate = false;
		this.InitTitleSprite();
	}

	// Token: 0x06009DD1 RID: 40401 RVA: 0x00294BA4 File Offset: 0x00292DA4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.TurntableStartRun, new Action<int>(this.OnTurntableStartRun));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDayRefresh));
	}

	// Token: 0x06009DD2 RID: 40402 RVA: 0x00294C08 File Offset: 0x00292E08
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TurntableStartRun, new Action<int>(this.OnTurntableStartRun));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDayRefresh));
	}

	// Token: 0x06009DD3 RID: 40403 RVA: 0x00294C6C File Offset: 0x00292E6C
	protected override void OnRefreshView()
	{
		this.RefreshPanel();
		this.RefreshToggleItem();
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, new <>z__ReadOnlySingleElementList<int>(this.ActivityTurntableData.TurntableCostConfigId));
		if (this.ActivityTurntableData.IsUnLock())
		{
			this.ActivityTurntableData.SaveUnlockRedDot();
		}
		if (this.ActivityTurntableData.TurntableType == ETurntableType.Daily)
		{
			this.ActivityTurntableData.SaveDailyRedDot();
		}
	}

	// Token: 0x06009DD4 RID: 40404 RVA: 0x00294CD6 File Offset: 0x00292ED6
	protected override void OnBeforeDestroy()
	{
		this.SpriteLoaderList.Clear();
		this.SpritePathList.Clear();
	}

	// Token: 0x06009DD5 RID: 40405 RVA: 0x00294CEE File Offset: 0x00292EEE
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06009DD6 RID: 40406 RVA: 0x00294CF6 File Offset: 0x00292EF6
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (id != this.ActivityTurntableData.Id)
		{
			return;
		}
		if (this.ActivityTurntableData.TurntableType == ETurntableType.Quest)
		{
			this.RefreshQuestRedDot();
		}
	}

	// Token: 0x06009DD7 RID: 40407 RVA: 0x00294D1C File Offset: 0x00292F1C
	private void OnActivityCrossDayRefresh()
	{
		this.RefreshPanel();
		if (!this.ActivityTurntableData.CheckIfInShowTime())
		{
			return;
		}
		if (this.ActivityTurntableData.TurntableType != ETurntableType.Daily)
		{
			return;
		}
		if (this.InTurntableRun)
		{
			return;
		}
		if (!this.ActivityTurntableData.IsActivityUnFinished())
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DailyTurntableRefresh);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06009DD8 RID: 40408 RVA: 0x00294D7A File Offset: 0x00292F7A
	private void RefreshPanel()
	{
		if (this.ActivityTurntableData.TurntableType == ETurntableType.Quest)
		{
			this.RefreshQuest();
			return;
		}
		if (this.ActivityTurntableData.TurntableType == ETurntableType.Daily)
		{
			this.RefreshDaily();
		}
	}

	// Token: 0x06009DD9 RID: 40409 RVA: 0x00294DA8 File Offset: 0x00292FA8
	private void RefreshQuestRedDot()
	{
		bool redDot = this.ActivityTurntableData.IsHasNewQuestRedDot();
		ActivityTurntableQuestItem questItem = this.QuestItem;
		if (questItem == null)
		{
			return;
		}
		questItem.SetRedDot(redDot);
	}

	// Token: 0x06009DDA RID: 40410 RVA: 0x00294DD4 File Offset: 0x00292FD4
	private void RefreshQuest()
	{
		this.IsQuestLockTimeShow = false;
		int currentQuestProgress = this.ActivityTurntableData.GetCurrentQuestProgress();
		int count = this.ActivityTurntableData.QuestList.Count;
		base.GetItem(2).SetUIActive(currentQuestProgress < count);
		this.QuestItem.SetActive(currentQuestProgress < count);
		if (currentQuestProgress == count)
		{
			return;
		}
		this.QuestItem.SetTitle("TurntableActivity_Progress", new string[]
		{
			currentQuestProgress.ToString(),
			count.ToString()
		});
		int currentQuestIndex = this.ActivityTurntableData.GetCurrentQuestIndex();
		int num = this.ActivityTurntableData.QuestList[currentQuestIndex];
		ITurntableQuestInfo turntableQuestInfo = this.ActivityTurntableData.QuestStateMap[num];
		IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(num);
		int? num2 = (questConfig != null) ? questConfig.RewardId : null;
		int? num3 = num2;
		int num4 = 0;
		if (num3.GetValueOrDefault() == num4 & num3 != null)
		{
			return;
		}
		List<TItem> previewReward = this.ActivityTurntableData.GetPreviewReward(num2);
		if (previewReward.Count < 1)
		{
			return;
		}
		bool isFinished = false;
		num4 = turntableQuestInfo.QuestState;
		if (num4 - 1 > 1)
		{
			if (num4 == 3)
			{
				isFinished = true;
				this.IsQuestLockTimeShow = true;
				int key = this.ActivityTurntableData.QuestList[currentQuestIndex + 1];
				ITurntableQuestInfo turntableQuestInfo2 = this.ActivityTurntableData.QuestStateMap[key];
				this.QuestLockTime = turntableQuestInfo2.QuestUnlockStamp;
				this.RefreshTimerText();
			}
		}
		else
		{
			string text = (questConfig != null) ? questConfig.TidName : null;
			string txt = (text != null) ? Singleton<PublicUtil>.Instance.GetConfigTextByKey(text) : "";
			this.QuestItem.SetTxt(txt);
		}
		this.QuestItem.Refresh(isFinished, previewReward[0], num, this.ActivityTurntableData.Id);
		this.RefreshQuestRedDot();
	}

	// Token: 0x06009DDB RID: 40411 RVA: 0x00294FA0 File Offset: 0x002931A0
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
		if (this.IsQuestLockTimeShow)
		{
			this.QuestItem.SetTxtById("TurntableActivity_TaskDesc", new string[]
			{
				this.GetRemainQuestUnlockTimeText(this.QuestLockTime)
			});
		}
	}

	// Token: 0x06009DDC RID: 40412 RVA: 0x00295008 File Offset: 0x00293208
	private string GetRemainQuestUnlockTimeText(long endTime)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = Math.Max((double)endTime - serverTime, 1.0);
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> questLockTimeTypeData = this.GetQuestLockTimeTypeData(num);
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(questLockTimeTypeData.Item1), new CommonDefine.ETimeType?(questLockTimeTypeData.Item2)).CountDownText ?? "";
	}

	// Token: 0x06009DDD RID: 40413 RVA: 0x0029506C File Offset: 0x0029326C
	[NullableContext(0)]
	private ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> GetQuestLockTimeTypeData(double remainTime)
	{
		if (remainTime > 86400.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
		}
		if (remainTime > 3600.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Minute);
		}
		if (remainTime > 60.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Second);
		}
		return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
	}

	// Token: 0x06009DDE RID: 40414 RVA: 0x002950BC File Offset: 0x002932BC
	private void RefreshDaily()
	{
		bool flag = this.ActivityTurntableData.IsActivityUnFinished();
		this.DailyPanel.SetActive(flag);
		if (!flag)
		{
			return;
		}
		this.DailyPanel.Refresh();
	}

	// Token: 0x06009DDF RID: 40415 RVA: 0x002950F0 File Offset: 0x002932F0
	private void RefreshFunctionState()
	{
		bool flag = this.ActivityTurntableData.GetCurrentRoundId() == this.CurrentSelectRoundId;
		bool flag2 = this.ActivityTurntableData.IsRoundUnFinished(this.CurrentSelectRoundId);
		bool flag3 = this.ActivityTurntableData.IsHasRewardRedDot();
		if (!flag2)
		{
			this.RefreshFunctionalFinished();
			return;
		}
		if (!flag)
		{
			this.RefreshFunctionalLock("TurntableActivity_ForbidTips02");
			return;
		}
		if (flag3)
		{
			this.RefreshFunctionalRun();
			return;
		}
		this.RefreshFunctionalLock("TurntableActivity_ForbidTips01");
	}

	// Token: 0x06009DE0 RID: 40416 RVA: 0x0029515B File Offset: 0x0029335B
	private void RefreshFunctionalFinished()
	{
		this.FunctionalArea.FunctionButton.SetActive(false);
		this.FunctionalArea.SetPanelConditionVisible(false);
		this.FunctionalArea.SetActivatePanelConditionVisible(true);
	}

	// Token: 0x06009DE1 RID: 40417 RVA: 0x00295186 File Offset: 0x00293386
	private void RefreshFunctionalLock(string textId)
	{
		this.FunctionalArea.FunctionButton.SetActive(false);
		this.FunctionalArea.SetPanelConditionVisible(true);
		this.FunctionalArea.SetLockTextByTextId(textId, Array.Empty<string>());
		this.FunctionalArea.SetActivatePanelConditionVisible(false);
	}

	// Token: 0x06009DE2 RID: 40418 RVA: 0x002951C2 File Offset: 0x002933C2
	private void RefreshFunctionalRun()
	{
		this.FunctionalArea.FunctionButton.SetActive(true);
		this.FunctionalArea.SetPanelConditionVisible(false);
		this.FunctionalArea.SetActivatePanelConditionVisible(false);
	}

	// Token: 0x06009DE3 RID: 40419 RVA: 0x002951ED File Offset: 0x002933ED
	private ActivityTurntableToggleGroupItem InitToggleItem()
	{
		return new ActivityTurntableToggleGroupItem
		{
			ToggleCallBack = new Action<int, bool>(this.ToggleCallBack)
		};
	}

	// Token: 0x06009DE4 RID: 40420 RVA: 0x00295208 File Offset: 0x00293408
	private void ToggleCallBack(int roundId, bool state)
	{
		if (!state)
		{
			return;
		}
		if (this.CurrentSelectRoundId >= 0 && this.CurrentSelectRoundId != roundId)
		{
			this.ToggleLayout.GetLayoutItemByIndex(this.CurrentSelectRoundId).SetToggleState(false, false);
		}
		this.RefreshRound(roundId, this.CurrentSelectRoundId, true).Forget();
		this.RefreshFunctionState();
	}

	// Token: 0x06009DE5 RID: 40421 RVA: 0x0029525C File Offset: 0x0029345C
	private void RefreshToggleItem()
	{
		this.ToggleLayout.RefreshByData(this.ActivityTurntableData.RoundIdList, delegate
		{
			int currentRoundId = this.ActivityTurntableData.GetCurrentRoundId();
			List<ActivityTurntableToggleGroupItem> layoutItemList = this.ToggleLayout.GetLayoutItemList();
			for (int i = 0; i < this.ActivityTurntableData.RoundIdList.Count; i++)
			{
				int num = this.ActivityTurntableData.RoundIdList[i];
				bool flag = this.ActivityTurntableData.IsRoundUnFinished(num);
				layoutItemList[i].SetToggleDisable(!flag);
				bool bSelectOn = num == currentRoundId;
				layoutItemList[i].SetToggleState(bSelectOn, false);
			}
			this.RefreshRound(currentRoundId, this.CurrentSelectRoundId, false).Forget();
			this.RefreshFunctionState();
		}, false);
	}

	// Token: 0x06009DE6 RID: 40422 RVA: 0x00295281 File Offset: 0x00293481
	private void OnClickedTurntableRun()
	{
		if (this.ActivityTurntableData.GetActivityCurrencyCount() >= this.ActivityTurntableData.TurntableCostCount)
		{
			ActivityTurntableController.RequestTurntableRun(this.ActivityTurntableData.Id);
		}
	}

	// Token: 0x06009DE7 RID: 40423 RVA: 0x002952AC File Offset: 0x002934AC
	private void InitTitleSprite()
	{
		ValueTuple<int, int, bool>[] array = new ValueTuple<int, int, bool>[]
		{
			new ValueTuple<int, int, bool>(9, 0, true),
			new ValueTuple<int, int, bool>(10, 0, false),
			new ValueTuple<int, int, bool>(11, 1, true),
			new ValueTuple<int, int, bool>(12, 2, true),
			new ValueTuple<int, int, bool>(13, 0, true)
		};
		foreach (int[] array2 in this.TitleIdNameList)
		{
			List<string> list = new List<string>();
			foreach (int value in array2)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("SP_TurntableTitleRound");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				list.Add(resourcePath);
			}
			this.SpritePathList.Add(list.ToArray());
		}
		foreach (ValueTuple<int, int, bool> valueTuple in array)
		{
			UUISprite sprite = base.GetSprite(valueTuple.Item1);
			ActivitySubViewTurntable.SpriteLoader item = new ActivitySubViewTurntable.SpriteLoader
			{
				Sprite = sprite,
				Index = valueTuple.Item2,
				IsCurrent = valueTuple.Item3
			};
			this.SpriteLoaderList.Add(item);
		}
	}

	// Token: 0x06009DE8 RID: 40424 RVA: 0x002953FC File Offset: 0x002935FC
	private UniTask RefreshTitle(int roundId, int lastRoundId)
	{
		ActivitySubViewTurntable.<RefreshTitle>d__45 <RefreshTitle>d__;
		<RefreshTitle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTitle>d__.<>4__this = this;
		<RefreshTitle>d__.roundId = roundId;
		<RefreshTitle>d__.lastRoundId = lastRoundId;
		<RefreshTitle>d__.<>1__state = -1;
		<RefreshTitle>d__.<>t__builder.Start<ActivitySubViewTurntable.<RefreshTitle>d__45>(ref <RefreshTitle>d__);
		return <RefreshTitle>d__.<>t__builder.Task;
	}

	// Token: 0x06009DE9 RID: 40425 RVA: 0x00295450 File Offset: 0x00293650
	private UniTask RefreshRound(int roundId, int lastRoundId, bool needAnim = true)
	{
		ActivitySubViewTurntable.<RefreshRound>d__46 <RefreshRound>d__;
		<RefreshRound>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRound>d__.<>4__this = this;
		<RefreshRound>d__.roundId = roundId;
		<RefreshRound>d__.lastRoundId = lastRoundId;
		<RefreshRound>d__.needAnim = needAnim;
		<RefreshRound>d__.<>1__state = -1;
		<RefreshRound>d__.<>t__builder.Start<ActivitySubViewTurntable.<RefreshRound>d__46>(ref <RefreshRound>d__);
		return <RefreshRound>d__.<>t__builder.Task;
	}

	// Token: 0x06009DEA RID: 40426 RVA: 0x002954AC File Offset: 0x002936AC
	private UniTask RefreshTurntable(int roundId, ActivityTurntableComponent turntable)
	{
		ActivitySubViewTurntable.<RefreshTurntable>d__47 <RefreshTurntable>d__;
		<RefreshTurntable>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTurntable>d__.<>4__this = this;
		<RefreshTurntable>d__.roundId = roundId;
		<RefreshTurntable>d__.turntable = turntable;
		<RefreshTurntable>d__.<>1__state = -1;
		<RefreshTurntable>d__.<>t__builder.Start<ActivitySubViewTurntable.<RefreshTurntable>d__47>(ref <RefreshTurntable>d__);
		return <RefreshTurntable>d__.<>t__builder.Task;
	}

	// Token: 0x06009DEB RID: 40427 RVA: 0x00295500 File Offset: 0x00293700
	public override void OnCommonViewStateChange(bool show)
	{
		string sequenceName = show ? "TurnTableOut" : "TurnTableIn";
		this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, true, null, false);
	}

	// Token: 0x06009DEC RID: 40428 RVA: 0x00295534 File Offset: 0x00293734
	private void OnTurntableStartRun(int rewardId)
	{
		int currentRoundId = this.ActivityTurntableData.GetCurrentRoundId();
		int lastSelectRoundId = this.CurrentSelectRoundId;
		this.InTurntableRun = true;
		Singleton<EventSystem>.Instance.Emit<bool, EActivityViewState, bool?>(EEventName.SetActivityViewState, false, EActivityViewState.Global, new bool?(true));
		Action <>9__1;
		this.Turntable.RunTurntableByRewardId(rewardId, delegate
		{
			List<TItem> runResult = this.ActivityTurntableData.GetRunResult();
			Action onCloseCallback;
			if ((onCloseCallback = <>9__1) == null)
			{
				onCloseCallback = (<>9__1 = delegate()
				{
					Singleton<EventSystem>.Instance.Emit<bool, EActivityViewState, bool?>(EEventName.SetActivityViewState, true, EActivityViewState.Global, new bool?(true));
					this.InTurntableRun = false;
					if (currentRoundId != lastSelectRoundId)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TurntableActivity_Tips01", Array.Empty<object>());
					}
				});
			}
			ActivityTurntableController.ShowTurntableItemObtain(runResult, onCloseCallback);
			this.RefreshPanel();
			this.RefreshToggleItem();
		});
	}

	// Token: 0x0400489C RID: 18588
	[Nullable(2)]
	protected ActivityTurntableData ActivityTurntableData;

	// Token: 0x0400489D RID: 18589
	[Nullable(2)]
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x0400489E RID: 18590
	[Nullable(2)]
	private ActivityFunctionalTypeA FunctionalArea;

	// Token: 0x0400489F RID: 18591
	[Nullable(2)]
	private ActivityTurntableQuestItem QuestItem;

	// Token: 0x040048A0 RID: 18592
	[Nullable(2)]
	private ActivityTurntableDailyPanel DailyPanel;

	// Token: 0x040048A1 RID: 18593
	[Nullable(2)]
	private ActivityTurntableComponent Turntable;

	// Token: 0x040048A2 RID: 18594
	[Nullable(2)]
	private ActivityTurntableComponent TurntableAnim;

	// Token: 0x040048A3 RID: 18595
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityTurntableToggleGroupItem, int> ToggleLayout;

	// Token: 0x040048A4 RID: 18596
	private int CurrentSelectRoundId = -1;

	// Token: 0x040048A5 RID: 18597
	private bool IsQuestLockTimeShow;

	// Token: 0x040048A6 RID: 18598
	private long QuestLockTime;

	// Token: 0x040048A7 RID: 18599
	private bool InTurntableRun;

	// Token: 0x040048A8 RID: 18600
	private int[][] TitleIdNameList = new int[][]
	{
		new int[]
		{
			1,
			2,
			3
		},
		new int[]
		{
			2,
			1,
			3
		},
		new int[]
		{
			3,
			1,
			2
		}
	};

	// Token: 0x040048A9 RID: 18601
	private readonly List<ActivitySubViewTurntable.ISpriteLoader> SpriteLoaderList = new List<ActivitySubViewTurntable.ISpriteLoader>();

	// Token: 0x040048AA RID: 18602
	private readonly List<string[]> SpritePathList = new List<string[]>();

	// Token: 0x0200799A RID: 31130
	private interface ISpriteLoader
	{
		// Token: 0x1700A7FA RID: 43002
		// (get) Token: 0x06047767 RID: 292711
		// (set) Token: 0x06047768 RID: 292712
		UUISprite Sprite { get; set; }

		// Token: 0x1700A7FB RID: 43003
		// (get) Token: 0x06047769 RID: 292713
		// (set) Token: 0x0604776A RID: 292714
		int Index { get; set; }

		// Token: 0x1700A7FC RID: 43004
		// (get) Token: 0x0604776B RID: 292715
		// (set) Token: 0x0604776C RID: 292716
		bool IsCurrent { get; set; }
	}

	// Token: 0x0200799B RID: 31131
	[Nullable(0)]
	private class SpriteLoader : ActivitySubViewTurntable.ISpriteLoader
	{
		// Token: 0x1700A7FD RID: 43005
		// (get) Token: 0x0604776D RID: 292717 RVA: 0x0130A0CE File Offset: 0x013082CE
		// (set) Token: 0x0604776E RID: 292718 RVA: 0x0130A0D6 File Offset: 0x013082D6
		public UUISprite Sprite { get; set; }

		// Token: 0x1700A7FE RID: 43006
		// (get) Token: 0x0604776F RID: 292719 RVA: 0x0130A0DF File Offset: 0x013082DF
		// (set) Token: 0x06047770 RID: 292720 RVA: 0x0130A0E7 File Offset: 0x013082E7
		public int Index { get; set; }

		// Token: 0x1700A7FF RID: 43007
		// (get) Token: 0x06047771 RID: 292721 RVA: 0x0130A0F0 File Offset: 0x013082F0
		// (set) Token: 0x06047772 RID: 292722 RVA: 0x0130A0F8 File Offset: 0x013082F8
		public bool IsCurrent { get; set; }
	}

	// Token: 0x0200799C RID: 31132
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029C38 RID: 171064
		public const int PanelItem = 0;

		// Token: 0x04029C39 RID: 171065
		public const int TitleItem = 1;

		// Token: 0x04029C3A RID: 171066
		public const int PanelQuest = 2;

		// Token: 0x04029C3B RID: 171067
		public const int QuestItem = 3;

		// Token: 0x04029C3C RID: 171068
		public const int ToggleLayout = 4;

		// Token: 0x04029C3D RID: 171069
		public const int Turntable = 5;

		// Token: 0x04029C3E RID: 171070
		public const int Toggle = 6;

		// Token: 0x04029C3F RID: 171071
		public const int FunctionArea = 7;

		// Token: 0x04029C40 RID: 171072
		public const int TurntableAnim = 8;

		// Token: 0x04029C41 RID: 171073
		public const int Sprite01A = 9;

		// Token: 0x04029C42 RID: 171074
		public const int Sprite01B = 10;

		// Token: 0x04029C43 RID: 171075
		public const int Sprite02A = 11;

		// Token: 0x04029C44 RID: 171076
		public const int Sprite03A = 12;

		// Token: 0x04029C45 RID: 171077
		public const int SpriteIndex = 13;

		// Token: 0x04029C46 RID: 171078
		public const int PanelDaily = 14;
	}
}
