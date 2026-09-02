using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B05 RID: 11013
public class SurvivorsItemDetailTabView : UiPanelBase
{
	// Token: 0x06016032 RID: 90162 RVA: 0x0061B68C File Offset: 0x0061988C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture))
		};
	}

	// Token: 0x06016033 RID: 90163 RVA: 0x0061B740 File Offset: 0x00619940
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsItemDetailTabView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsItemDetailTabView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016034 RID: 90164 RVA: 0x0061B783 File Offset: 0x00619983
	[NullableContext(1)]
	private SurvivorsItemGrid CreateItemProxy()
	{
		SurvivorsItemGrid survivorsItemGrid = new SurvivorsItemGrid();
		survivorsItemGrid.SetClickCallback(new Action<int, int>(this.OnSelectItem));
		survivorsItemGrid.SetCanExecuteChange(new Func<int, bool>(this.CanExecuteChange));
		return survivorsItemGrid;
	}

	// Token: 0x06016035 RID: 90165 RVA: 0x0061B7B0 File Offset: 0x006199B0
	protected override void OnStart()
	{
		List<SurvivorsItemGainData> itemGainList = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetItemGainList();
		if (itemGainList.Count == 0)
		{
			this.RefreshEmptyState(true);
		}
		else
		{
			this.RefreshEmptyState(false);
			LoopScrollView<SurvivorsItemGrid, SurvivorsItemGainData> loopScroll = this.LoopScroll;
			if (loopScroll != null)
			{
				loopScroll.RefreshByDataAsync(itemGainList, false, false).ContinueWith(delegate()
				{
					LoopScrollView<SurvivorsItemGrid, SurvivorsItemGainData> loopScroll2 = this.LoopScroll;
					if (loopScroll2 != null)
					{
						loopScroll2.ScrollToGridIndex(0, true);
					}
					SurvivorsItemGrid survivorsItemGrid = this.LoopScroll.UnsafeGetGridProxy(0, false);
					if (survivorsItemGrid == null)
					{
						return;
					}
					survivorsItemGrid.SetToggleStateForce(true, true, true);
				});
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "SurvivorsPropAttribute_PropNum", new <>z__ReadOnlySingleElementList<object>(itemGainList.Count));
	}

	// Token: 0x06016036 RID: 90166 RVA: 0x0061B831 File Offset: 0x00619A31
	private void RefreshEmptyState(bool isEmpty)
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(!isEmpty);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(isEmpty);
		}
		UUITexture texture = base.GetTexture(6);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(!isEmpty);
	}

	// Token: 0x06016037 RID: 90167 RVA: 0x0061B871 File Offset: 0x00619A71
	private void OnSelectItem(int index, int itemId)
	{
		this.RefreshItemCard(new int?(itemId));
		LoopScrollView<SurvivorsItemGrid, SurvivorsItemGainData> loopScroll = this.LoopScroll;
		if (loopScroll == null)
		{
			return;
		}
		loopScroll.SelectGridProxy(index, false);
	}

	// Token: 0x06016038 RID: 90168 RVA: 0x0061B891 File Offset: 0x00619A91
	private bool CanExecuteChange(int index)
	{
		LoopScrollView<SurvivorsItemGrid, SurvivorsItemGainData> loopScroll = this.LoopScroll;
		return loopScroll == null || loopScroll.GetSelectedGridIndex() != index;
	}

	// Token: 0x06016039 RID: 90169 RVA: 0x0061B8AC File Offset: 0x00619AAC
	private void RefreshItemCard(int? itemId)
	{
		if (itemId == null)
		{
			SurvivorsRogueCardBase cardItem = this.CardItem;
			if (cardItem == null)
			{
				return;
			}
			cardItem.SetUiActive(false);
			return;
		}
		else
		{
			SurvivorsRogueCardBase cardItem2 = this.CardItem;
			if (cardItem2 != null)
			{
				cardItem2.SetUiActive(true);
			}
			SurvivorsRogueItemCard data = SurvivorsRogueCardDataFactory.CreateGeneralItem(itemId.Value);
			SurvivorsRogueCardBase cardItem3 = this.CardItem;
			if (cardItem3 == null)
			{
				return;
			}
			cardItem3.Apply(data);
			return;
		}
	}

	// Token: 0x0400A907 RID: 43271
	[Nullable(2)]
	private SurvivorsRogueCardBase CardItem;

	// Token: 0x0400A908 RID: 43272
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<SurvivorsItemGrid, SurvivorsItemGainData> LoopScroll;
}
