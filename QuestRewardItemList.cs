using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E0A RID: 7690
[NullableContext(1)]
[Nullable(0)]
public class QuestRewardItemList : UiPanelBase
{
	// Token: 0x0600E30B RID: 58123 RVA: 0x003D286D File Offset: 0x003D0A6D
	[NullableContext(2)]
	public QuestRewardItemList(AActor rootActor)
	{
		if (rootActor == null)
		{
			return;
		}
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600E30C RID: 58124 RVA: 0x003D2884 File Offset: 0x003D0A84
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x0600E30D RID: 58125 RVA: 0x003D2919 File Offset: 0x003D0B19
	protected override void OnStart()
	{
		this.SourceItem = base.GetItem(1);
		this.SourceItem.SetUIActive(false);
		this.GenericScrollView = new GenericScrollViewNew<QuestRewardItemGrid, RewardItemData>(base.GetScrollViewWithScrollbar(2), new Func<QuestRewardItemGrid>(this.OnCreateRewardItem), null, false, null);
	}

	// Token: 0x0600E30E RID: 58126 RVA: 0x003D2958 File Offset: 0x003D0B58
	private QuestRewardItemGrid OnCreateRewardItem()
	{
		QuestRewardItemGrid questRewardItemGrid = new QuestRewardItemGrid();
		questRewardItemGrid.ItemGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		questRewardItemGrid.ItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
		return questRewardItemGrid;
	}

	// Token: 0x0600E30F RID: 58127 RVA: 0x003D29AB File Offset: 0x003D0BAB
	public void Refresh(List<RewardItemData> rewardItemDataList)
	{
		rewardItemDataList.Sort(delegate(RewardItemData aRewardItem, RewardItemData bRewardItem)
		{
			int typeSortIndex = aRewardItem.GetTypeSortIndex();
			int typeSortIndex2 = bRewardItem.GetTypeSortIndex();
			if (typeSortIndex != typeSortIndex2)
			{
				return typeSortIndex2 - typeSortIndex;
			}
			int qualityId = aRewardItem.GetQualityId();
			int qualityId2 = bRewardItem.GetQualityId();
			if (qualityId != qualityId2)
			{
				return qualityId2 - qualityId;
			}
			return aRewardItem.ConfigId - bRewardItem.ConfigId;
		});
		this.GenericScrollView.RefreshByData(rewardItemDataList, null, false);
	}

	// Token: 0x0600E310 RID: 58128 RVA: 0x003D29E0 File Offset: 0x003D0BE0
	private void OnClickedRewardItem(MediumItemGridExtendCallback callbackParameter)
	{
		ItemGridBase selectedItemGrid = this.SelectedItemGrid;
		if (selectedItemGrid != null)
		{
			selectedItemGrid.SetSelected(false, true);
		}
		this.SelectedItemGrid = callbackParameter.MediumItemGrid;
		RewardItemData rewardItemData = (RewardItemData)callbackParameter.Data;
		int configId = rewardItemData.ConfigId;
		int uniqueId = rewardItemData.UniqueId;
		if (uniqueId > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(uniqueId, configId, true, null);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(configId, true, null);
	}

	// Token: 0x04006D32 RID: 27954
	[Nullable(2)]
	private UUIItem SourceItem;

	// Token: 0x04006D33 RID: 27955
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<QuestRewardItemGrid, RewardItemData> GenericScrollView;

	// Token: 0x04006D34 RID: 27956
	[Nullable(2)]
	private ItemGridBase SelectedItemGrid;

	// Token: 0x02008178 RID: 33144
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402BF92 RID: 180114
		public const int ItemContentItem = 0;

		// Token: 0x0402BF93 RID: 180115
		public const int SourceItem = 1;

		// Token: 0x0402BF94 RID: 180116
		public const int ScrollViewWithScrollbar = 2;
	}
}
