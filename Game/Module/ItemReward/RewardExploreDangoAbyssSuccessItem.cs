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
	// Token: 0x02005B51 RID: 23377
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreDangoAbyssSuccessItem : UiPanelBase
	{
		// Token: 0x0603B253 RID: 242259 RVA: 0x00EF7048 File Offset: 0x00EF5248
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B254 RID: 242260 RVA: 0x00EF7135 File Offset: 0x00EF5335
		protected override void OnStart()
		{
			this.GenericScrollView = new GenericLayout<RewardSmallItemGrid, RewardItemData>(base.GetGridLayout(2), new Func<RewardSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
		}

		// Token: 0x0603B255 RID: 242261 RVA: 0x00EF7158 File Offset: 0x00EF5358
		public void Refresh(IDangoAbyssSuccessData data)
		{
			this.RefreshReward(data.RewardItemData);
			this.RefreshProgress(data.Progress);
		}

		// Token: 0x0603B256 RID: 242262 RVA: 0x00EF7174 File Offset: 0x00EF5374
		private void RefreshProgress(float progress)
		{
			int num = (int)Math.Floor((double)(progress * 100f));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "AbyssLevelProgress", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
		}

		// Token: 0x0603B257 RID: 242263 RVA: 0x00EF71B4 File Offset: 0x00EF53B4
		private void RefreshReward(List<RewardItemData> rewardItemDataList)
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
			base.GetItem(5).SetUIActive(rewardItemDataList.Count > 0);
		}

		// Token: 0x0603B258 RID: 242264 RVA: 0x00EF7209 File Offset: 0x00EF5409
		private RewardSmallItemGrid OnCreateRewardItem()
		{
			return this.NewRewardItem();
		}

		// Token: 0x0603B259 RID: 242265 RVA: 0x00EF7211 File Offset: 0x00EF5411
		private RewardSmallItemGrid NewRewardItem()
		{
			RewardSmallItemGrid rewardSmallItemGrid = new RewardSmallItemGrid();
			rewardSmallItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			rewardSmallItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
			return rewardSmallItemGrid;
		}

		// Token: 0x0603B25A RID: 242266 RVA: 0x00EF7250 File Offset: 0x00EF5450
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

		// Token: 0x0402157F RID: 136575
		[Nullable(2)]
		private ItemGridBase SelectedItemGrid;

		// Token: 0x04021580 RID: 136576
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RewardSmallItemGrid, RewardItemData> GenericScrollView;

		// Token: 0x0200BB51 RID: 47953
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039CE2 RID: 236770
			public const int ProgressItem = 0;

			// Token: 0x04039CE3 RID: 236771
			public const int ProgressText = 1;

			// Token: 0x04039CE4 RID: 236772
			public const int RewardGridLayout = 2;

			// Token: 0x04039CE5 RID: 236773
			public const int RewardItem = 3;

			// Token: 0x04039CE6 RID: 236774
			public const int MaxText = 4;

			// Token: 0x04039CE7 RID: 236775
			public const int LayoutRoot = 5;
		}
	}
}
