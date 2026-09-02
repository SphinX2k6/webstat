using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001355 RID: 4949
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewLongShan : ActivitySubViewBase
{
	// Token: 0x0600877B RID: 34683 RVA: 0x0023B32C File Offset: 0x0023952C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickMainQuest));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600877C RID: 34684 RVA: 0x0023B4BA File Offset: 0x002396BA
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityLongShanData)this.ActivityBaseData;
	}

	// Token: 0x0600877D RID: 34685 RVA: 0x0023B4D0 File Offset: 0x002396D0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewLongShan.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewLongShan.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600877E RID: 34686 RVA: 0x0023B513 File Offset: 0x00239713
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LongShanUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x0600877F RID: 34687 RVA: 0x0023B531 File Offset: 0x00239731
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LongShanUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x06008780 RID: 34688 RVA: 0x0023B54F File Offset: 0x0023974F
	protected override void OnStart()
	{
		this.RefreshTimerText();
	}

	// Token: 0x06008781 RID: 34689 RVA: 0x0023B557 File Offset: 0x00239757
	protected override void OnBeforeShow()
	{
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.SetBtnText("LongShanStage_Join", Array.Empty<object>());
		}
		ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
		if (commonInfoPanel2 != null)
		{
			commonInfoPanel2.SetClickFunc(new Action<ActivityBaseData>(this.OnClickDetail));
		}
		this.RefreshRedDot();
	}

	// Token: 0x06008782 RID: 34690 RVA: 0x0023B598 File Offset: 0x00239798
	protected override UniTask OnBeforeHideSelfAsync()
	{
		ActivitySubViewLongShan.<OnBeforeHideSelfAsync>d__12 <OnBeforeHideSelfAsync>d__;
		<OnBeforeHideSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideSelfAsync>d__.<>4__this = this;
		<OnBeforeHideSelfAsync>d__.<>1__state = -1;
		<OnBeforeHideSelfAsync>d__.<>t__builder.Start<ActivitySubViewLongShan.<OnBeforeHideSelfAsync>d__12>(ref <OnBeforeHideSelfAsync>d__);
		return <OnBeforeHideSelfAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008783 RID: 34691 RVA: 0x0023B5DC File Offset: 0x002397DC
	private void OnClickDetail(ActivityBaseData _)
	{
		Singleton<EventSystem>.Instance.Emit<bool, EActivityViewState, bool?>(EEventName.SetActivityViewState, false, EActivityViewState.Side, null);
	}

	// Token: 0x06008784 RID: 34692 RVA: 0x0023B604 File Offset: 0x00239804
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06008785 RID: 34693 RVA: 0x0023B60C File Offset: 0x0023980C
	protected override void OnRefreshView()
	{
		this.RefreshTimerText();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel != null)
		{
			commonInfoPanel.RefreshView();
		}
		this.OnDataUpdate();
		if (this.TransitionAnimFlag)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("TransIn", true, null, false);
			this.TransitionAnimFlag = false;
		}
	}

	// Token: 0x06008786 RID: 34694 RVA: 0x0023B660 File Offset: 0x00239860
	private void OnDataUpdate()
	{
		if (this.StageItems != null)
		{
			foreach (LongShanStageItem longShanStageItem in this.StageItems)
			{
				longShanStageItem.RefreshState();
			}
		}
		base.GetButton(3).RootUIComp.Get().SetUIActive(this.ActivityData.StageIds.Any((int x) => this.ActivityData.GetStageInfoById(x) == null));
		this.RefreshRedDot();
	}

	// Token: 0x06008787 RID: 34695 RVA: 0x0023B6F4 File Offset: 0x002398F4
	public override void OnCommonViewStateChange(bool show)
	{
		this.PlaySubViewSequence(show ? "SwitchOut" : "SwitchIn", true);
	}

	// Token: 0x06008788 RID: 34696 RVA: 0x0023B70C File Offset: 0x0023990C
	[NullableContext(1)]
	protected override void OnSequenceStart(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			this.SetInternalItemInteractive(false);
			return;
		}
		if (sequenceName == "SwitchOut")
		{
			this.SetInternalItemInteractive(false);
			return;
		}
		if (sequenceName == "SwitchIn")
		{
			this.SetInternalItemInteractive(true);
			if (this.StageItems != null && this.StageItems.Count > 0)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.StageItems[0].GetLongShanButton(), true, false, false);
			}
		}
	}

	// Token: 0x06008789 RID: 34697 RVA: 0x0023B78C File Offset: 0x0023998C
	private void SetInternalItemInteractive(bool value)
	{
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.SetSelfInteractive(value);
		}
		if (this.StageItems != null)
		{
			foreach (LongShanStageItem longShanStageItem in this.StageItems)
			{
				longShanStageItem.SetButtonInteractive(value);
			}
		}
	}

	// Token: 0x0600878A RID: 34698 RVA: 0x0023B7F8 File Offset: 0x002399F8
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		base.GetText(1).SetUIActive(item);
		if (item)
		{
			base.GetText(1).SetText(item2, true);
		}
	}

	// Token: 0x0600878B RID: 34699 RVA: 0x0023B838 File Offset: 0x00239A38
	private void OnClickMainQuest()
	{
		if (this.ActivityData == null || this.ActivityData.StageIds == null)
		{
			return;
		}
		int? num = null;
		foreach (int num2 in this.ActivityData.StageIds)
		{
			ActivityLongShanData activityData = this.ActivityData;
			if (((activityData != null) ? activityData.GetStageInfoById(num2) : null) == null)
			{
				LongShanStage? config = ConfigLongShanStageById.GetConfig(num2, true);
				num = ((config != null) ? new int?(config.GetValueOrDefault().QuestionId) : null);
				break;
			}
		}
		if (num != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, num.Value, null);
		}
	}

	// Token: 0x0600878C RID: 34700 RVA: 0x0023B8F4 File Offset: 0x00239AF4
	private void OnClickStageDetail(int stageId)
	{
		if (this.ActivityData.GetStageInfoById(stageId) != null)
		{
			this.TransitionAnimFlag = true;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LongShanView, new object[]
			{
				this.ActivityData,
				stageId
			}, null);
			return;
		}
		ControllerBase<ActivityLongShanController>.Instance.ShowUnlockTip(stageId);
	}

	// Token: 0x0600878D RID: 34701 RVA: 0x0023B94C File Offset: 0x00239B4C
	private void RefreshRedDot()
	{
		bool functionRedDotVisible = this.ActivityData.CheckAnyStageRed();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel == null)
		{
			return;
		}
		commonInfoPanel.SetFunctionRedDotVisible(functionRedDotVisible);
	}

	// Token: 0x04003FCD RID: 16333
	protected ActivityLongShanData ActivityData;

	// Token: 0x04003FCE RID: 16334
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x04003FCF RID: 16335
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected List<LongShanStageItem> StageItems;

	// Token: 0x04003FD0 RID: 16336
	private bool TransitionAnimFlag;

	// Token: 0x020076FA RID: 30458
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028F93 RID: 167827
		public const int ScreenPanel = 0;

		// Token: 0x04028F94 RID: 167828
		public const int TxtTime = 1;

		// Token: 0x04028F95 RID: 167829
		public const int CommonActionInfo = 2;

		// Token: 0x04028F96 RID: 167830
		public const int BtnMainQuest = 3;

		// Token: 0x04028F97 RID: 167831
		public const int TaskBtnItemA = 4;

		// Token: 0x04028F98 RID: 167832
		public const int TaskBtnItemB = 5;

		// Token: 0x04028F99 RID: 167833
		public const int TaskBtnItemC = 6;

		// Token: 0x04028F9A RID: 167834
		public const int TaskBtnItemD = 7;

		// Token: 0x04028F9B RID: 167835
		public const int InfoItem = 8;
	}
}
