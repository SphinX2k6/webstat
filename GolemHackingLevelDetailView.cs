using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020010C4 RID: 4292
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingLevelDetailView : UiViewBase
{
	// Token: 0x06006FB6 RID: 28598 RVA: 0x001D14F9 File Offset: 0x001CF6F9
	public GolemHackingLevelDetailView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06006FB7 RID: 28599 RVA: 0x001D151C File Offset: 0x001CF71C
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickedBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06006FB8 RID: 28600 RVA: 0x001D16F0 File Offset: 0x001CF8F0
	protected override UniTask OnBeforeStartAsync()
	{
		GolemHackingLevelDetailView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GolemHackingLevelDetailView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006FB9 RID: 28601 RVA: 0x001D1734 File Offset: 0x001CF934
	protected override void OnBeforeShow()
	{
		bool flag = this.EasyItem.RefreshState(false);
		this.HardItem.RefreshState(false);
		if (this.NeedRefreshAfterPlay)
		{
			this.EasyItem.SetSelected(!flag);
			this.HardItem.SetSelected(flag);
			if (flag)
			{
				this.HardItem.SetFocusGamepad();
			}
		}
		else if (this.IsInitShow)
		{
			this.IsInitShow = false;
			this.EasyItem.SetSelected(true);
			this.HardItem.SetSelected(false);
		}
		if (this.CurLevelId != 0)
		{
			this.OnClickedToggle(this.CurLevelId, this.IsHardMode);
		}
	}

	// Token: 0x06006FBA RID: 28602 RVA: 0x001D17CF File Offset: 0x001CF9CF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06006FBB RID: 28603 RVA: 0x001D1809 File Offset: 0x001CFA09
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06006FBC RID: 28604 RVA: 0x001D1843 File Offset: 0x001CFA43
	private CommonItemSmallItemGrid InitCommonGridItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = new Func<TItem, bool>(this.CheckLevelFinished)
		};
	}

	// Token: 0x06006FBD RID: 28605 RVA: 0x001D185C File Offset: 0x001CFA5C
	private bool CheckLevelFinished(TItem data)
	{
		return ControllerBase<GolemHackingController>.Instance.GetActivityData().GetLevelInfo(this.CurLevelId).State == GolemCrackState.GolemCrackFinished;
	}

	// Token: 0x06006FBE RID: 28606 RVA: 0x001D187C File Offset: 0x001CFA7C
	private void OnClickedBtn()
	{
		if (!ControllerBase<GolemHackingController>.Instance.GetActivityData().CheckIfInOpenTime())
		{
			ControllerBase<GolemHackingController>.Instance.CloseActivityView(new HashSet<int>(), true);
			return;
		}
		ControllerBase<GolemHackingController>.Instance.OpenGameplayView(new List<int>(this.CurLevelConfigId), new Action<bool>(this.OnGameplayEnd), false, new TOpenViewCallBack(this.OpenLogReport));
	}

	// Token: 0x06006FBF RID: 28607 RVA: 0x001D18DC File Offset: 0x001CFADC
	private void OpenLogReport(bool success, int _)
	{
		ControllerBase<GolemHackingController>.Instance.IsActivityOpen = true;
		int activityOpenTime = (int)Singleton<TimeUtil>.Instance.GetServerTime();
		ControllerBase<GolemHackingController>.Instance.ActivityOpenTime = activityOpenTime;
		ControllerBase<GolemHackingController>.Instance.CacheLevelId = this.CurLevelId;
		ControllerBase<GolemHackingController>.Instance.CacheHardMode = this.IsHardMode;
		GolemHackingStartEvent golemHackingStartEvent = new GolemHackingStartEvent();
		golemHackingStartEvent.i_id = this.CurLevelId;
		golemHackingStartEvent.i_type = (this.IsHardMode ? 2 : 1);
		golemHackingStartEvent.s_trace_id = activityOpenTime.ToString();
		bool flag = ControllerBase<GolemHackingController>.Instance.GetActivityData().GetLevelInfo(this.CurLevelId).State == GolemCrackState.GolemCrackFinished;
		golemHackingStartEvent.i_first_pass = ((!flag) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.LogReport(golemHackingStartEvent);
	}

	// Token: 0x06006FC0 RID: 28608 RVA: 0x001D1990 File Offset: 0x001CFB90
	private void OnCloseRewardView()
	{
		if (!this.NeedRefreshAfterPlay)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGolemHackingLevelStateUpdate);
		if (this.IsHardMode)
		{
			ControllerBase<GolemHackingController>.Instance.CacheRewardFocus = true;
			base.CloseMe(null);
			return;
		}
		bool flag = this.EasyItem.RefreshState(false);
		this.HardItem.RefreshState(false);
		this.EasyItem.SetSelected(!flag);
		this.HardItem.SetSelected(flag);
		if (flag)
		{
			this.HardItem.SetFocusGamepad();
		}
	}

	// Token: 0x06006FC1 RID: 28609 RVA: 0x001D1A14 File Offset: 0x001CFC14
	private void OnClickedToggle(int levelId, bool isHard)
	{
		this.IsHardMode = isHard;
		GolemHackingLevelInfo levelInfo = ControllerBase<GolemHackingController>.Instance.GetActivityData().GetLevelInfo(levelId);
		this.NeedRefreshAfterPlay = (levelInfo.State == GolemCrackState.GolemCrackUnlocked);
		bool flag = levelInfo.State == GolemCrackState.GolemCrackLocked;
		UUIButtonComponent button = base.GetButton(8);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(!flag);
		}
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		this.CurLevelId = levelId;
		GolemCrack value = ConfigGolemCrackById.GetConfig(levelId, true).Value;
		int[] array = new int[value.ConfigIdsLength];
		for (int i = 0; i < value.ConfigIdsLength; i++)
		{
			array[i] = value.ConfigIds(i);
		}
		this.CurLevelConfigId = array;
		string text;
		if (levelId < 10)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(levelId);
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(levelId);
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		string newText = text;
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.SetText(newText, true);
		}
		UUIText text3 = base.GetText(4);
		if (text3 != null)
		{
			text3.ShowTextNew(value.Title);
		}
		UUIText text4 = base.GetText(6);
		if (text4 != null)
		{
			text4.ShowTextNew(value.Desc);
		}
		UUIText text5 = base.GetText(5);
		if (text5 != null)
		{
			text5.SetUIActive(true);
		}
		string key = isHard ? "PrefabTextItem_3863107273_Text" : "PrefabTextItem_126203885_Text";
		UUIText text6 = base.GetText(5);
		if (text6 != null)
		{
			text6.ShowTextNew(key);
		}
		if (this.EasyItem.LevelId != levelId)
		{
			this.EasyItem.SetSelected(false);
		}
		else
		{
			this.HardItem.SetSelected(false);
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(value.DropId);
		this.RewardListComponent.RefreshItemLayout(dropPackagePreviewItemList, null);
		GolemHackingActivityData activityData = ControllerBase<GolemHackingController>.Instance.GetActivityData();
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(activityData.CheckLevelRedDot(levelId));
		}
		this.DoAnimLogic();
	}

	// Token: 0x06006FC2 RID: 28610 RVA: 0x001D1C14 File Offset: 0x001CFE14
	protected void DoAnimLogic()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null && sequencePlayer.IsPlayingSequence("Switch_ToRed"))
		{
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null)
			{
				sequencePlayer2.StopSequenceByKey("Switch_ToRed", false, false);
			}
		}
		LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
		if (sequencePlayer3 != null && sequencePlayer3.IsPlayingSequence("Switch_ToBlue"))
		{
			LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
			if (sequencePlayer4 != null)
			{
				sequencePlayer4.StopSequenceByKey("Switch_ToBlue", false, false);
			}
		}
		string sequenceName = this.IsHardMode ? "Switch_ToRed" : "Switch_ToBlue";
		LevelSequencePlayer sequencePlayer5 = this.SequencePlayer;
		if (sequencePlayer5 == null)
		{
			return;
		}
		sequencePlayer5.PlayOrReplaySequenceByName(sequenceName, false, null);
	}

	// Token: 0x06006FC3 RID: 28611 RVA: 0x001D1CB3 File Offset: 0x001CFEB3
	private void OnGameplayEnd(bool isSuccess)
	{
		ControllerBase<GolemHackingController>.Instance.IsActivityOpen = false;
		if (!ControllerBase<GolemHackingController>.Instance.GetActivityData().CheckIfInOpenTime())
		{
			return;
		}
		if (isSuccess)
		{
			ControllerBase<GolemHackingController>.Instance.RequestGolemCrackUpdate(this.CurLevelId).Forget<bool>();
		}
	}

	// Token: 0x06006FC4 RID: 28612 RVA: 0x001D1CEA File Offset: 0x001CFEEA
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		ControllerBase<GolemHackingController>.Instance.CloseActivityView(closeActivities, false);
	}

	// Token: 0x040035BC RID: 13756
	protected PopupCaptionItem CaptionItem;

	// Token: 0x040035BD RID: 13757
	protected GolemHackingLevelDetailToggle EasyItem;

	// Token: 0x040035BE RID: 13758
	protected GolemHackingLevelDetailToggleHard HardItem;

	// Token: 0x040035BF RID: 13759
	protected int CurLevelId;

	// Token: 0x040035C0 RID: 13760
	protected int[] CurLevelConfigId = Array.Empty<int>();

	// Token: 0x040035C1 RID: 13761
	protected bool IsInitShow = true;

	// Token: 0x040035C2 RID: 13762
	protected bool IsHardMode;

	// Token: 0x040035C3 RID: 13763
	protected bool NeedRefreshAfterPlay = true;

	// Token: 0x040035C4 RID: 13764
	[Nullable(2)]
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x040035C5 RID: 13765
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

	// Token: 0x02007453 RID: 29779
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x04028365 RID: 164709
		CaptionItem,
		// Token: 0x04028366 RID: 164710
		PanelEasy,
		// Token: 0x04028367 RID: 164711
		PanelHard,
		// Token: 0x04028368 RID: 164712
		TxtLevelCode,
		// Token: 0x04028369 RID: 164713
		TxtName,
		// Token: 0x0402836A RID: 164714
		TxtHardModelTitle,
		// Token: 0x0402836B RID: 164715
		TxtDesc,
		// Token: 0x0402836C RID: 164716
		RewardItem,
		// Token: 0x0402836D RID: 164717
		Btn,
		// Token: 0x0402836E RID: 164718
		LockItem,
		// Token: 0x0402836F RID: 164719
		RedDotItem
	}
}
