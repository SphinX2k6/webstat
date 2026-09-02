using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002686 RID: 9862
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewMainView : UiViewBase
{
	// Token: 0x06013736 RID: 79670 RVA: 0x0056B273 File Offset: 0x00569473
	public QuestReviewMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013737 RID: 79671 RVA: 0x0056B27C File Offset: 0x0056947C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(USpineSkeletonAnimationComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013738 RID: 79672 RVA: 0x0056B38A File Offset: 0x0056958A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		this.WaitFusionFinish();
		this.WaitTabUnlock();
	}

	// Token: 0x06013739 RID: 79673 RVA: 0x0056B3B6 File Offset: 0x005695B6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0601373A RID: 79674 RVA: 0x0056B3D4 File Offset: 0x005695D4
	protected override UniTask OnBeforeStartAsync()
	{
		QuestReviewMainView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestReviewMainView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601373B RID: 79675 RVA: 0x0056B418 File Offset: 0x00569618
	protected override void OnStart()
	{
		object[] array = this.OpenParam as object[];
		if (array != null && array.Length >= 2)
		{
			this.Data = (array[0] as QuestReviewEntryData);
			this.UseLoopMusic = (array[1] as bool?).GetValueOrDefault();
		}
		this.LayoutQuestTree = new GenericLayout<QuestReviewLineItem, QuestReviewLineData>(base.GetVerticalLayout(1), new Func<QuestReviewLineItem>(this.CreateQuestLineItem), null, false, true);
		this.LayoutTabs = new GenericLayout<QuestReviewTabItem, QuestReviewTabData>(base.GetHorizontalLayout(3), new Func<QuestReviewTabItem>(this.CreateTabItem), null, false, true);
		QuestReviewLineData questReviewLineDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3100);
		int num = (questReviewLineDataById.IsDestroy && questReviewLineDataById.IsFirstTimeDestroy) ? 3 : this.Data.TargetTab;
		this.CurrentTabData = ModelBase<QuestReviewModel>.Instance.GetQuestReviewTabDataById(num);
		this.RefreshDelegate(new int?(num));
		ControllerBase<QuestReviewController>.Instance.AddViewRefreshDelegate(new Action<int?>(this.RefreshDelegate));
		if (this.Data.IsFirstEntry)
		{
			this.UiViewSequence.StartSequenceName = "FirstStart";
			this.UiViewSequence.AddSequenceFinishEvent("FirstStart", new Action<string>(this.OnFirstStartSeqEnd), false);
			return;
		}
		this.UiViewSequence.StartSequenceName = "Start";
	}

	// Token: 0x0601373C RID: 79676 RVA: 0x0056B552 File Offset: 0x00569752
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnQuestReviewMainViewBeforeHide);
	}

	// Token: 0x0601373D RID: 79677 RVA: 0x0056B564 File Offset: 0x00569764
	protected override void OnBeforeDestroy()
	{
		ControllerBase<QuestReviewController>.Instance.RemoveViewRefreshDelegate(new Action<int?>(this.RefreshDelegate));
		this.UiViewSequence.RemoveSequenceFinishEvent("FirstStart", new Action<string>(this.OnFirstStartSeqEnd));
		QuestReviewTabData currentTabData = this.CurrentTabData;
		if (currentTabData != null && currentTabData.Id == 3)
		{
			if (!ModelBase<QuestReviewModel>.Instance.HasQuestLineFused())
			{
				ControllerBase<QuestReviewController>.Instance.SetBurnFinish();
				ControllerBase<QuestReviewController>.Instance.SetFusionFinish();
				ControllerBase<QuestReviewController>.Instance.SetNewTabUnlockFinish();
				ModelBase<QuestReviewModel>.Instance.SetQuestLineFused();
				QuestReviewLineData questReviewLineDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3200);
				questReviewLineDataById.HasFused = true;
				questReviewLineDataById.IsFirstTimeShow = false;
			}
			this.CurrentTabData.IsFirstTimeShow = false;
		}
	}

	// Token: 0x0601373E RID: 79678 RVA: 0x0056B616 File Offset: 0x00569816
	public override bool GetLoopAudioEventSwitch()
	{
		return this.UseLoopMusic;
	}

	// Token: 0x0601373F RID: 79679 RVA: 0x0056B620 File Offset: 0x00569820
	private void RefreshView()
	{
		this.RefreshTabs(this.Data);
		QuestReviewTreeData questReviewTreeDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewTreeDataById(this.CurrentTabData.QuestTree);
		this.RefreshQuestTree(questReviewTreeDataById);
	}

	// Token: 0x06013740 RID: 79680 RVA: 0x0056B658 File Offset: 0x00569858
	private void RefreshQuestTree(QuestReviewTreeData treeData)
	{
		List<QuestReviewLineData> list = new List<QuestReviewLineData>();
		foreach (int id in treeData.QuestLines)
		{
			QuestReviewLineData questReviewLineDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(id);
			if ((questReviewLineDataById == null || !questReviewLineDataById.IsFusionLine || !ModelBase<QuestReviewModel>.Instance.HasQuestLineFused()) && questReviewLineDataById != null && questReviewLineDataById.IsShow)
			{
				list.Add(questReviewLineDataById);
			}
		}
		list.Sort((QuestReviewLineData a, QuestReviewLineData b) => a.DisplayOrder.CompareTo(b.DisplayOrder));
		this.LayoutQuestTree.RefreshByData(list, null, false);
	}

	// Token: 0x06013741 RID: 79681 RVA: 0x0056B714 File Offset: 0x00569914
	private void RefreshAfterBurn()
	{
		QuestReviewLineData questReviewLineDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3100);
		questReviewLineDataById.IsFirstTimeDestroy = false;
		questReviewLineDataById.SkipAnim = true;
		QuestReviewLineData tempLineData = ModelBase<QuestReviewModel>.Instance.GetTempLineData();
		QuestReviewLineData questReviewLineDataById2 = ModelBase<QuestReviewModel>.Instance.GetQuestReviewLineDataById(3200);
		questReviewLineDataById2.IsFirstTimeShow = true;
		questReviewLineDataById2.HasFused = true;
		QuestReviewLineData tempLineData2 = ModelBase<QuestReviewModel>.Instance.GetTempLineData();
		List<QuestReviewLineData> data = new List<QuestReviewLineData>
		{
			questReviewLineDataById,
			tempLineData,
			questReviewLineDataById2,
			tempLineData2
		};
		this.LayoutQuestTree.RefreshByData(data, null, false);
		ModelBase<QuestReviewModel>.Instance.SetQuestLineFused();
	}

	// Token: 0x06013742 RID: 79682 RVA: 0x0056B7B0 File Offset: 0x005699B0
	private void RefreshTabs(QuestReviewEntryData entryData)
	{
		List<QuestReviewTabData> list = new List<QuestReviewTabData>();
		foreach (int num in entryData.Tabs)
		{
			QuestReviewTabData questReviewTabDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewTabDataById(num);
			if (questReviewTabDataById != null && questReviewTabDataById.IsUnlocked)
			{
				questReviewTabDataById.IsSelected = (num == this.CurrentTabData.Id);
				list.Add(questReviewTabDataById);
			}
		}
		this.LayoutTabs.GetRootUiItem().SetUIActive(list.Count > 1);
		if (list.Count <= 2)
		{
			foreach (QuestReviewTabData questReviewTabData in list)
			{
				questReviewTabData.IsFirstTimeShow = false;
			}
		}
		this.LayoutTabs.RefreshByData(list, null, false);
	}

	// Token: 0x06013743 RID: 79683 RVA: 0x0056B89C File Offset: 0x00569A9C
	private UniTask WaitFusionFinish()
	{
		QuestReviewMainView.<WaitFusionFinish>d__19 <WaitFusionFinish>d__;
		<WaitFusionFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitFusionFinish>d__.<>1__state = -1;
		<WaitFusionFinish>d__.<>t__builder.Start<QuestReviewMainView.<WaitFusionFinish>d__19>(ref <WaitFusionFinish>d__);
		return <WaitFusionFinish>d__.<>t__builder.Task;
	}

	// Token: 0x06013744 RID: 79684 RVA: 0x0056B8D8 File Offset: 0x00569AD8
	private UniTask WaitTabUnlock()
	{
		QuestReviewMainView.<WaitTabUnlock>d__20 <WaitTabUnlock>d__;
		<WaitTabUnlock>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitTabUnlock>d__.<>1__state = -1;
		<WaitTabUnlock>d__.<>t__builder.Start<QuestReviewMainView.<WaitTabUnlock>d__20>(ref <WaitTabUnlock>d__);
		return <WaitTabUnlock>d__.<>t__builder.Task;
	}

	// Token: 0x06013745 RID: 79685 RVA: 0x0056B914 File Offset: 0x00569B14
	private void RefreshDelegate(int? tabId = 0)
	{
		int? num = tabId;
		int num2 = 0;
		if (num.GetValueOrDefault() > num2 & num != null)
		{
			this.CurrentTabData = ModelBase<QuestReviewModel>.Instance.GetQuestReviewTabDataById(tabId.Value);
		}
		if (tabId.GetValueOrDefault() == -1)
		{
			this.RefreshAfterBurn();
			return;
		}
		if (tabId.GetValueOrDefault() == 3 && !ModelBase<QuestReviewModel>.Instance.HasQuestLineFused())
		{
			base.GetHorizontalLayout(3).RootUIComp.Get().SetUIActive(false);
			QuestReviewTreeData questReviewTreeDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewTreeDataById(this.CurrentTabData.QuestTree);
			this.RefreshQuestTree(questReviewTreeDataById);
			return;
		}
		if (tabId.GetValueOrDefault() == -2)
		{
			QuestReviewEntryData data = this.Data;
			foreach (int id in (((data != null) ? data.Tabs : null) ?? Array.Empty<int>()))
			{
				QuestReviewTabData questReviewTabDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewTabDataById(id);
				if (questReviewTabDataById != null)
				{
					questReviewTabDataById.IsFirstTimeShow = false;
				}
			}
			this.CurrentTabData = ModelBase<QuestReviewModel>.Instance.GetQuestReviewTabDataById(3);
			this.CurrentTabData.IsFirstTimeShow = true;
			base.GetHorizontalLayout(3).RootUIComp.Get().SetUIActive(true);
			this.RefreshTabs(this.Data);
			return;
		}
		this.RefreshView();
	}

	// Token: 0x06013746 RID: 79686 RVA: 0x0056BA78 File Offset: 0x00569C78
	private QuestReviewLineItem CreateQuestLineItem()
	{
		return new QuestReviewLineItem();
	}

	// Token: 0x06013747 RID: 79687 RVA: 0x0056BA7F File Offset: 0x00569C7F
	private QuestReviewTabItem CreateTabItem()
	{
		return new QuestReviewTabItem();
	}

	// Token: 0x06013748 RID: 79688 RVA: 0x0056BA86 File Offset: 0x00569C86
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Start")
		{
			base.GetSpine(5).SetAnimation(0, param, false);
			return;
		}
		if (param == "Open")
		{
			base.GetSpine(6).SetAnimation(0, param, false);
		}
	}

	// Token: 0x06013749 RID: 79689 RVA: 0x0056BAC3 File Offset: 0x00569CC3
	private void OnFirstStartSeqEnd(string _)
	{
		QuestReviewEntryData data = this.Data;
		if (data != null && data.IsFirstEntry)
		{
			this.Data.IsFirstEntry = false;
		}
	}

	// Token: 0x0400979F RID: 38815
	private GenericLayout<QuestReviewLineItem, QuestReviewLineData> LayoutQuestTree;

	// Token: 0x040097A0 RID: 38816
	private GenericLayout<QuestReviewTabItem, QuestReviewTabData> LayoutTabs;

	// Token: 0x040097A1 RID: 38817
	private PopupCaptionItem Caption;

	// Token: 0x040097A2 RID: 38818
	private QuestReviewEntryData Data;

	// Token: 0x040097A3 RID: 38819
	private bool UseLoopMusic;

	// Token: 0x040097A4 RID: 38820
	private QuestReviewTabData CurrentTabData;

	// Token: 0x02008A24 RID: 35364
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402E966 RID: 190822
		public const int ItemCaption = 0;

		// Token: 0x0402E967 RID: 190823
		public const int LayoutQuestTree = 1;

		// Token: 0x0402E968 RID: 190824
		public const int ItemQuestLine = 2;

		// Token: 0x0402E969 RID: 190825
		public const int LayoutTab = 3;

		// Token: 0x0402E96A RID: 190826
		public const int ItemTab = 4;

		// Token: 0x0402E96B RID: 190827
		public const int SpineBookA = 5;

		// Token: 0x0402E96C RID: 190828
		public const int SpineBookB = 6;
	}
}
