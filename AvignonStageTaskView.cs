using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011CD RID: 4557
[NullableContext(1)]
[Nullable(0)]
public class AvignonStageTaskView : UiViewBase
{
	// Token: 0x06007836 RID: 30774 RVA: 0x001F7204 File Offset: 0x001F5404
	public AvignonStageTaskView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007837 RID: 30775 RVA: 0x001F7218 File Offset: 0x001F5418
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickPre));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickNext));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007838 RID: 30776 RVA: 0x001F7410 File Offset: 0x001F5610
	protected override UniTask OnBeforeStartAsync()
	{
		AvignonStageTaskView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AvignonStageTaskView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007839 RID: 30777 RVA: 0x001F7453 File Offset: 0x001F5653
	private PageDot<int> InitPageDot()
	{
		return new PageDot<int>();
	}

	// Token: 0x0600783A RID: 30778 RVA: 0x001F745A File Offset: 0x001F565A
	private AvignonTaskItem CreateTaskItem()
	{
		return new AvignonTaskItem();
	}

	// Token: 0x0600783B RID: 30779 RVA: 0x001F7461 File Offset: 0x001F5661
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTaskLayout));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600783C RID: 30780 RVA: 0x001F749B File Offset: 0x001F569B
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshTaskLayout));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600783D RID: 30781 RVA: 0x001F74D8 File Offset: 0x001F56D8
	private void RefreshView()
	{
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentSelectedIndex).UpdateShow(false);
		this.CurrentSelectedIndex = this.NextSelectedIndex;
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentSelectedIndex).UpdateShow(true);
		base.GetButton(7).RootUIComp.Get().SetUIActive(this.CurrentSelectedIndex > 0);
		base.GetButton(6).RootUIComp.Get().SetUIActive(this.CurrentSelectedIndex < this.StageIdList.Count - 1);
		this.StageId = this.StageIdList[this.CurrentSelectedIndex];
		this.AvignonStageConf = ConfigBase<AvignonConfig>.Instance.GetStageConfigById(this.StageId);
		AvignonStageInfo avignonStageInfo = ModelBase<AvignonModel>.Instance.GetAvignonStageInfo(this.StageId);
		this.RefreshTaskList(avignonStageInfo.GetTaskList(), true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), this.AvignonStageConf.Value.Title, Array.Empty<object>());
		string path = this.AvignonStageConf.Value.Icon;
		if (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female)
		{
			path = this.AvignonStageConf.Value.FemaleIcon;
		}
		base.SetTextureByPath(path, base.GetTexture(8), null, null);
		this.SetSpriteByPath(this.AvignonStageConf.Value.RomaIcon, base.GetSprite(9), false, null, null);
		ModelBase<AvignonModel>.Instance.SaveNewStageFlag(this.StageId);
	}

	// Token: 0x0600783E RID: 30782 RVA: 0x001F7674 File Offset: 0x001F5874
	private void OnRefreshTaskLayout(int activityId)
	{
		if (ModelBase<AvignonModel>.Instance.GetAvignonActivityId() == activityId)
		{
			AvignonStageInfo avignonStageInfo = ModelBase<AvignonModel>.Instance.GetAvignonStageInfo(this.StageIdList[this.CurrentSelectedIndex]);
			this.RefreshTaskList(avignonStageInfo.GetTaskList(), false);
		}
	}

	// Token: 0x0600783F RID: 30783 RVA: 0x001F76B7 File Offset: 0x001F58B7
	private void RefreshTaskList(List<AvignonTaskData> data, bool playGridAnim = false)
	{
		this.RefreshStageTaskProgress();
		this.TaskLayout.RefreshByData(data, null, playGridAnim);
	}

	// Token: 0x06007840 RID: 30784 RVA: 0x001F76D0 File Offset: 0x001F58D0
	private void RefreshStageTaskProgress()
	{
		AvignonStageInfo avignonStageInfo = ModelBase<AvignonModel>.Instance.GetAvignonStageInfo(this.StageId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BlackCoastTheme_TaskCompleteProgress", new <>z__ReadOnlySingleElementList<object>(avignonStageInfo.GetTaskProgress()));
	}

	// Token: 0x06007841 RID: 30785 RVA: 0x001F7714 File Offset: 0x001F5914
	private void OnClickPre()
	{
		this.NextSelectedIndex = this.CurrentSelectedIndex - 1;
		base.PlaySequence("SwitchLeft", null, false);
	}

	// Token: 0x06007842 RID: 30786 RVA: 0x001F7734 File Offset: 0x001F5934
	private void OnClickNext()
	{
		int num = this.CurrentSelectedIndex + 1;
		int stageId = this.StageIdList[num];
		AvignonStageInfo avignonStageInfo = ModelBase<AvignonModel>.Instance.GetAvignonStageInfo(stageId);
		if (avignonStageInfo.IsUnlock)
		{
			this.NextSelectedIndex = num;
			base.PlaySequence("SwitchRight", null, false);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(avignonStageInfo.GetLockConditionText(), Array.Empty<object>());
	}

	// Token: 0x06007843 RID: 30787 RVA: 0x001F7795 File Offset: 0x001F5995
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06007844 RID: 30788 RVA: 0x001F779E File Offset: 0x001F599E
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "PageChange")
		{
			this.RefreshView();
		}
	}

	// Token: 0x04003A15 RID: 14869
	private int StageId;

	// Token: 0x04003A16 RID: 14870
	private AvignonStage? AvignonStageConf;

	// Token: 0x04003A17 RID: 14871
	private int CurrentSelectedIndex;

	// Token: 0x04003A18 RID: 14872
	private List<int> StageIdList = new List<int>();

	// Token: 0x04003A19 RID: 14873
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003A1A RID: 14874
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PageDot<int>, int> PageDotLayout;

	// Token: 0x04003A1B RID: 14875
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AvignonTaskItem, AvignonTaskData> TaskLayout;

	// Token: 0x04003A1C RID: 14876
	private int NextSelectedIndex;

	// Token: 0x02007525 RID: 29989
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040286FA RID: 165626
		public const int ItemCaption = 0;

		// Token: 0x040286FB RID: 165627
		public const int TxtFinishPercent = 1;

		// Token: 0x040286FC RID: 165628
		public const int LayoutTaskContent = 2;

		// Token: 0x040286FD RID: 165629
		public const int ItemTask = 3;

		// Token: 0x040286FE RID: 165630
		public const int LayoutPageDotContent = 4;

		// Token: 0x040286FF RID: 165631
		public const int ItemPageDot = 5;

		// Token: 0x04028700 RID: 165632
		public const int BtnArrrowRight = 6;

		// Token: 0x04028701 RID: 165633
		public const int BtnArrrowLeft = 7;

		// Token: 0x04028702 RID: 165634
		public const int TextureIcon = 8;

		// Token: 0x04028703 RID: 165635
		public const int SpriteRoma = 9;

		// Token: 0x04028704 RID: 165636
		public const int TxtStageName = 10;
	}
}
