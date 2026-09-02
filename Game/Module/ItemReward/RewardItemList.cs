using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B60 RID: 23392
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardItemList : UiPanelBase
	{
		// Token: 0x0603B2B6 RID: 242358 RVA: 0x00EF8C94 File Offset: 0x00EF6E94
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

		// Token: 0x0603B2B7 RID: 242359 RVA: 0x00EF8D29 File Offset: 0x00EF6F29
		protected override void OnStart()
		{
			this.SourceItem = base.GetItem(1);
			this.SourceItem.SetUIActive(false);
			this.GenericScrollView = new GenericScrollViewNew<RewardSmallItemGrid, RewardItemData>(base.GetScrollViewWithScrollbar(2), new Func<RewardSmallItemGrid>(this.OnCreateRewardItem), null, false, null);
		}

		// Token: 0x0603B2B8 RID: 242360 RVA: 0x00EF8D65 File Offset: 0x00EF6F65
		protected override void OnBeforeDestroy()
		{
			this.SelectedItemGrid = null;
			this.GenericScrollView = null;
		}

		// Token: 0x0603B2B9 RID: 242361 RVA: 0x00EF8D75 File Offset: 0x00EF6F75
		private RewardSmallItemGrid OnCreateRewardItem()
		{
			return this.NewRewardItem();
		}

		// Token: 0x0603B2BA RID: 242362 RVA: 0x00EF8D80 File Offset: 0x00EF6F80
		public void Refresh(List<RewardItemData> rewardItemDataList, bool tipsCanSkip = true)
		{
			rewardItemDataList.Sort(delegate(RewardItemData aRewardItem, RewardItemData bRewardItem)
			{
				EDropItemType dropItemType = aRewardItem.GetDropItemType();
				EDropItemType dropItemType2 = bRewardItem.GetDropItemType();
				if (dropItemType != dropItemType2)
				{
					return dropItemType2 - dropItemType;
				}
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
			this.TipsCanSkip = new bool?(tipsCanSkip);
		}

		// Token: 0x0603B2BB RID: 242363 RVA: 0x00EF8DCC File Offset: 0x00EF6FCC
		private RewardSmallItemGrid NewRewardItem()
		{
			RewardSmallItemGrid rewardSmallItemGrid = new RewardSmallItemGrid();
			rewardSmallItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			rewardSmallItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
			return rewardSmallItemGrid;
		}

		// Token: 0x0603B2BC RID: 242364 RVA: 0x00EF8E0C File Offset: 0x00EF700C
		private void OnClickedRewardItem(MediumItemGridExtendCallback callbackParameter)
		{
			ItemGridBase selectedItemGrid = this.SelectedItemGrid;
			if (selectedItemGrid != null)
			{
				selectedItemGrid.SetSelected(false, true);
			}
			this.SelectedItemGrid = callbackParameter.MediumItemGrid;
			RewardItemData rewardItemData = callbackParameter.Data as RewardItemData;
			int configId = rewardItemData.ConfigId;
			int uniqueId = rewardItemData.UniqueId;
			if (uniqueId > 0)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(uniqueId, configId, true, null);
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(configId, this.TipsCanSkip.GetValueOrDefault(true), null);
		}

		// Token: 0x040215A0 RID: 136608
		[Nullable(2)]
		private UUIItem SourceItem;

		// Token: 0x040215A1 RID: 136609
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RewardSmallItemGrid, RewardItemData> GenericScrollView;

		// Token: 0x040215A2 RID: 136610
		[Nullable(2)]
		private ItemGridBase SelectedItemGrid;

		// Token: 0x040215A3 RID: 136611
		private bool? TipsCanSkip;

		// Token: 0x0200BB6C RID: 47980
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D3B RID: 236859
			public const int ItemContentItem = 0;

			// Token: 0x04039D3C RID: 236860
			public const int SourceItem = 1;

			// Token: 0x04039D3D RID: 236861
			public const int ScrollViewWithScrollbar = 2;
		}
	}
}
