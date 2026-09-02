using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B37 RID: 11063
[NullableContext(1)]
[Nullable(0)]
public abstract class SurvivorsTabViewBase<TProxy, [Nullable(0)] TData> : UiTabViewBase where TProxy : class, IGridProxy<TData> where TData : ISurvivorsHandbookItemDataBase
{
	// Token: 0x06016120 RID: 90400
	protected abstract TProxy CreateLoopItem();

	// Token: 0x06016121 RID: 90401
	protected abstract IReadOnlyList<TData> GenerateItemUiDataList();

	// Token: 0x06016122 RID: 90402
	protected abstract int GetLoopItemIndex();

	// Token: 0x06016123 RID: 90403
	protected abstract int GetLoopScrollComponentIndex();

	// Token: 0x06016124 RID: 90404 RVA: 0x0061FD35 File Offset: 0x0061DF35
	protected virtual UniTask InitSubComponents()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x06016125 RID: 90405
	protected abstract void OnSelectItem(TData data, bool isFromClick);

	// Token: 0x17001CBE RID: 7358
	// (get) Token: 0x06016126 RID: 90406
	protected abstract ESurvivorsRogueItemType ItemType { get; }

	// Token: 0x06016127 RID: 90407 RVA: 0x0061FD3C File Offset: 0x0061DF3C
	protected virtual void OnTriggerSequenceStartEvent()
	{
	}

	// Token: 0x06016128 RID: 90408 RVA: 0x0061FD3E File Offset: 0x0061DF3E
	private void OnActivitySequenceEmitEvent(string name)
	{
		if (name == "Start")
		{
			this.OnTriggerSequenceStartEvent();
		}
	}

	// Token: 0x06016129 RID: 90409 RVA: 0x0061FD53 File Offset: 0x0061DF53
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0601612A RID: 90410 RVA: 0x0061FD71 File Offset: 0x0061DF71
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0601612B RID: 90411 RVA: 0x0061FD90 File Offset: 0x0061DF90
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsTabViewBase<TProxy, TData>.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsTabViewBase<TProxy, TData>.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601612C RID: 90412 RVA: 0x0061FDD4 File Offset: 0x0061DFD4
	protected override void OnShowUiTabViewFromToggle()
	{
		LoopScrollView<TProxy, TData> itemScroll = this.ItemScroll;
		if (itemScroll != null)
		{
			itemScroll.ResetGridController();
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Start", false, null);
	}

	// Token: 0x0601612D RID: 90413 RVA: 0x0061FE14 File Offset: 0x0061E014
	protected override void OnShowUiTabViewFromView()
	{
		LoopScrollView<TProxy, TData> itemScroll = this.ItemScroll;
		if (itemScroll != null)
		{
			itemScroll.ResetGridController();
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Start", false, null);
	}

	// Token: 0x0601612E RID: 90414 RVA: 0x0061FE54 File Offset: 0x0061E054
	private UniTask InitItemScroll()
	{
		SurvivorsTabViewBase<TProxy, TData>.<InitItemScroll>d__17 <InitItemScroll>d__;
		<InitItemScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitItemScroll>d__.<>4__this = this;
		<InitItemScroll>d__.<>1__state = -1;
		<InitItemScroll>d__.<>t__builder.Start<SurvivorsTabViewBase<TProxy, TData>.<InitItemScroll>d__17>(ref <InitItemScroll>d__);
		return <InitItemScroll>d__.<>t__builder.Task;
	}

	// Token: 0x0601612F RID: 90415 RVA: 0x0061FE98 File Offset: 0x0061E098
	[NullableContext(2)]
	protected bool OnCanClickItem(object data, bool isForceSelected, EToggleState state)
	{
		if (data == null)
		{
			return false;
		}
		TData tdata = (TData)((object)data);
		int id = tdata.Id;
		int? currentItemId = this.CurrentItemId;
		return !(id == currentItemId.GetValueOrDefault() & currentItemId != null);
	}

	// Token: 0x06016130 RID: 90416 RVA: 0x0061FEDC File Offset: 0x0061E0DC
	protected void OnItemClick(TData data, TProxy itemGrid)
	{
		int id = data.Id;
		int? currentItemId = this.CurrentItemId;
		if (id == currentItemId.GetValueOrDefault() & currentItemId != null)
		{
			return;
		}
		int gridIndex = itemGrid.GridIndex;
		this.SelectItemByIndex(gridIndex, true);
	}

	// Token: 0x06016131 RID: 90417 RVA: 0x0061FF28 File Offset: 0x0061E128
	private void SelectItemByIndex(int gridIndex, bool isFromClick = true)
	{
		this.ItemScroll.SelectGridProxy(gridIndex, false);
		TData tdata = this.ItemScroll.TryGetCachedData(gridIndex);
		this.CurrentItemId = new int?(tdata.Id);
		if (tdata.IsNew.GetValueOrDefault())
		{
			ModelBase<SurvivorsRogueModel>.Instance.SetItemClicked(this.ItemType, tdata.Id);
			ref TData ptr = ref tdata;
			if (default(TData) == null)
			{
				TData tdata2 = tdata;
				ptr = ref tdata2;
			}
			ptr.IsNew = new bool?(false);
			LoopScrollView<TProxy, TData> itemScroll = this.ItemScroll;
			if (itemScroll != null)
			{
				itemScroll.RefreshGridProxy(gridIndex);
			}
		}
		this.OnSelectItem(tdata, isFromClick);
	}

	// Token: 0x06016132 RID: 90418 RVA: 0x0061FFE0 File Offset: 0x0061E1E0
	private void RefreshTitle(IReadOnlyList<TData> uiDataList)
	{
		int num = 0;
		for (int i = 0; i < uiDataList.Count; i++)
		{
			TData tdata = uiDataList[i];
			if (tdata.LockState == null || !tdata.LockState.Value)
			{
				num++;
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WeaponEvolveTitle_UnlockedNum", new <>z__ReadOnlyArray<object>(new object[]
		{
			num.ToString(),
			uiDataList.Count.ToString()
		}));
	}

	// Token: 0x0400A9EC RID: 43500
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<TProxy, TData> ItemScroll;

	// Token: 0x0400A9ED RID: 43501
	protected int? CurrentItemId = new int?(-1);
}
