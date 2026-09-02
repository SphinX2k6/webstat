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
	// Token: 0x02005B61 RID: 23393
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardItemLoopList : UiPanelBase
	{
		// Token: 0x0603B2BE RID: 242366 RVA: 0x00EF8E84 File Offset: 0x00EF7084
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B2BF RID: 242367 RVA: 0x00EF8EF8 File Offset: 0x00EF70F8
		protected override void OnStart()
		{
			this.LoopScrollViewOb = new LoopScrollView<RewardSmallItemGrid, RewardItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<RewardSmallItemGrid>(this.InitItem), false);
		}

		// Token: 0x0603B2C0 RID: 242368 RVA: 0x00EF8F2A File Offset: 0x00EF712A
		protected override void OnBeforeDestroy()
		{
			this.LoopScrollViewOb = null;
			this.SelectedItemGrid = null;
		}

		// Token: 0x0603B2C1 RID: 242369 RVA: 0x00EF8F3A File Offset: 0x00EF713A
		private RewardSmallItemGrid InitItem()
		{
			return this.NewRewardItem();
		}

		// Token: 0x0603B2C2 RID: 242370 RVA: 0x00EF8F44 File Offset: 0x00EF7144
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
			this.LoopScrollViewOb.RefreshByData(rewardItemDataList, false, null, false);
			this.TipsCanSkip = new bool?(tipsCanSkip);
		}

		// Token: 0x0603B2C3 RID: 242371 RVA: 0x00EF8F91 File Offset: 0x00EF7191
		private RewardSmallItemGrid NewRewardItem()
		{
			RewardSmallItemGrid rewardSmallItemGrid = new RewardSmallItemGrid();
			rewardSmallItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			rewardSmallItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
			return rewardSmallItemGrid;
		}

		// Token: 0x0603B2C4 RID: 242372 RVA: 0x00EF8FD0 File Offset: 0x00EF71D0
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
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(uniqueId, configId, this.TipsCanSkip.GetValueOrDefault(true), null);
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(configId, this.TipsCanSkip.GetValueOrDefault(true), null);
		}

		// Token: 0x040215A4 RID: 136612
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RewardSmallItemGrid, RewardItemData> LoopScrollViewOb;

		// Token: 0x040215A5 RID: 136613
		[Nullable(2)]
		private ItemGridBase SelectedItemGrid;

		// Token: 0x040215A6 RID: 136614
		private bool? TipsCanSkip;

		// Token: 0x0200BB6E RID: 47982
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D41 RID: 236865
			public const int ItemLoopList = 0;

			// Token: 0x04039D42 RID: 236866
			public const int SourceItem = 1;
		}
	}
}
