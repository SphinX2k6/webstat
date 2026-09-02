using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B54 RID: 23380
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreHonamiTowerSuccessItem : UiPanelBase
	{
		// Token: 0x0603B266 RID: 242278 RVA: 0x00EF7624 File Offset: 0x00EF5824
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B267 RID: 242279 RVA: 0x00EF76D0 File Offset: 0x00EF58D0
		protected override void OnStart()
		{
			this.RecordLayout = new GenericLayout<HonamiTowerRecordItem, IHonamiTowerRecordData>(base.GetVerticalLayout(0), new Func<HonamiTowerRecordItem>(this.OnCreateRecordItem), null, false, true);
			this.RewardLayout = new GenericLayout<RewardSmallItemGrid, RewardItemData>(base.GetHorizontalLayout(3), new Func<RewardSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
		}

		// Token: 0x0603B268 RID: 242280 RVA: 0x00EF771F File Offset: 0x00EF591F
		public void Refresh(IHonamiTowerSuccessData data)
		{
			GenericLayout<HonamiTowerRecordItem, IHonamiTowerRecordData> recordLayout = this.RecordLayout;
			if (recordLayout != null)
			{
				recordLayout.RefreshByData(data.RecordItemList.ToList<IHonamiTowerRecordData>(), null, false);
			}
			this.RefreshRewardList(data.RewardItemList.ToList<RewardItemData>());
		}

		// Token: 0x0603B269 RID: 242281 RVA: 0x00EF7750 File Offset: 0x00EF5950
		private HonamiTowerRecordItem OnCreateRecordItem()
		{
			return new HonamiTowerRecordItem();
		}

		// Token: 0x0603B26A RID: 242282 RVA: 0x00EF7758 File Offset: 0x00EF5958
		private void RefreshRewardList(List<RewardItemData> rewardList)
		{
			bool flag = rewardList.Count > 0;
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			rewardList.Sort(delegate(RewardItemData aRewardItem, RewardItemData bRewardItem)
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
			GenericLayout<RewardSmallItemGrid, RewardItemData> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByData(rewardList, null, false);
		}

		// Token: 0x0603B26B RID: 242283 RVA: 0x00EF77D1 File Offset: 0x00EF59D1
		private RewardSmallItemGrid OnCreateRewardItem()
		{
			RewardSmallItemGrid rewardSmallItemGrid = new RewardSmallItemGrid();
			rewardSmallItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			rewardSmallItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
			return rewardSmallItemGrid;
		}

		// Token: 0x0603B26C RID: 242284 RVA: 0x00EF7810 File Offset: 0x00EF5A10
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
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(configId, true, null);
		}

		// Token: 0x04021582 RID: 136578
		private ItemGridBase SelectedItemGrid;

		// Token: 0x04021583 RID: 136579
		private GenericLayout<HonamiTowerRecordItem, IHonamiTowerRecordData> RecordLayout;

		// Token: 0x04021584 RID: 136580
		private GenericLayout<RewardSmallItemGrid, RewardItemData> RewardLayout;

		// Token: 0x0200BB55 RID: 47957
		[NullableContext(0)]
		private class ESuccessItemType
		{
			// Token: 0x04039CF4 RID: 236788
			public const int RecordLayout = 0;

			// Token: 0x04039CF5 RID: 236789
			public const int RewardTitleText = 1;

			// Token: 0x04039CF6 RID: 236790
			public const int RewardItem = 2;

			// Token: 0x04039CF7 RID: 236791
			public const int RewardLayout = 3;
		}
	}
}
