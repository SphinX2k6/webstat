using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C8 RID: 26568
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardShopTabViewModel : DockyardViewModelBase
	{
		// Token: 0x1700A113 RID: 41235
		// (get) Token: 0x06042486 RID: 271494 RVA: 0x0110068C File Offset: 0x010FE88C
		public virtual DockyardShopBackpackPanelModel BackpackPanelModel { [PreserveBaseOverrides] get; } = new DockyardShopBackpackPanelModel();

		// Token: 0x1700A114 RID: 41236
		// (get) Token: 0x06042487 RID: 271495 RVA: 0x01100694 File Offset: 0x010FE894
		public virtual DockyardShopListPanelModel ListPanelModel { [PreserveBaseOverrides] get; } = new DockyardShopListPanelModel();

		// Token: 0x06042488 RID: 271496 RVA: 0x0110069C File Offset: 0x010FE89C
		public void RegisterMainView(DockyardShopMainView mainView)
		{
			this.MainView = mainView;
		}

		// Token: 0x06042489 RID: 271497 RVA: 0x011006A5 File Offset: 0x010FE8A5
		public override void ItemBlockClick(int id)
		{
			base.ItemBlockClick(id);
			this.MainView.HidePlotPanel();
		}

		// Token: 0x0604248A RID: 271498 RVA: 0x011006BC File Offset: 0x010FE8BC
		public unsafe void SellClick(int incId, int itemId)
		{
			if (this.BackpackPanelModel.IsInDragState || !this.BackpackPanelModel.IsInSelectState || this.BackpackPanelModel.InSelectedBlockId == -1)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GenericPrompt_NotAllowOpenPhotograph_TipsText", Array.Empty<object>());
				return;
			}
			bool isInSelectState = this.BackpackPanelModel.IsInSelectState;
			FishingController instance = ControllerBase<FishingController>.Instance;
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int num2 = 0;
			*span[num2] = incId;
			num2 = 1;
			List<int> list2 = new List<int>(num2);
			CollectionsMarshal.SetCount<int>(list2, num2);
			span = CollectionsMarshal.AsSpan<int>(list2);
			num = 0;
			*span[num] = itemId;
			instance.TryRequestFishingSell(list, list2, isInSelectState, delegate(bool isSuccess)
			{
				if (isSuccess)
				{
					this.ListPanelModel.DeleteSelectedItemBlockAndRefresh();
					this.BackpackPanelModel.Panel.DestroySelectItemBlock();
					this.MainView.ShowPlotPanel("SellItem");
				}
			});
		}

		// Token: 0x0604248B RID: 271499 RVA: 0x01100770 File Offset: 0x010FE970
		public override void AllSellClick()
		{
			List<FishingItemInfo> leftPanelItemBlockDataList = base.GetLeftPanelItemBlockDataList();
			List<int> leftIncIdList = this.GetAllSellIncIdList(leftPanelItemBlockDataList);
			List<int> allSellItemIdList = this.GetAllSellItemIdList(leftPanelItemBlockDataList);
			List<FishingItemInfo> itemBlockDataList = this.BackpackPanelModel.Panel.GetItemBlockDataList();
			List<int> rightIncIdList = this.GetAllSellIncIdList(itemBlockDataList);
			List<int> allSellItemIdList2 = this.GetAllSellItemIdList(itemBlockDataList);
			if (leftIncIdList.Count + rightIncIdList.Count == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SellAllFailed", Array.Empty<object>());
				return;
			}
			bool isInSelectState = this.BackpackPanelModel.IsInSelectState;
			List<int> incIdList = leftIncIdList.Concat(rightIncIdList).ToList<int>();
			List<int> itemIdList = allSellItemIdList.Concat(allSellItemIdList2).ToList<int>();
			ControllerBase<FishingController>.Instance.TryRequestFishingSell(incIdList, itemIdList, isInSelectState, delegate(bool isSuccess)
			{
				if (isSuccess)
				{
					if (leftIncIdList.Count > 0)
					{
						this.ListPanelModel.DeleteItemBlockListFromWareHouse(leftIncIdList);
					}
					foreach (int id in rightIncIdList)
					{
						this.BackpackPanelModel.Panel.DestroyItemBlockById(id);
					}
					this.MainView.ShowPlotPanel("SellAllItem");
				}
			});
		}

		// Token: 0x0604248C RID: 271500 RVA: 0x0110084B File Offset: 0x010FEA4B
		public void NotifyMainViewClose()
		{
			this.MainView.CloseMe(null);
		}

		// Token: 0x0604248D RID: 271501 RVA: 0x0110085C File Offset: 0x010FEA5C
		private List<int> GetAllSellIncIdList(List<FishingItemInfo> dataList)
		{
			List<int> list = new List<int>();
			foreach (FishingItemInfo fishingItemInfo in dataList)
			{
				if (fishingItemInfo.Price > 0)
				{
					list.Add(fishingItemInfo.IncrId);
				}
			}
			return list;
		}

		// Token: 0x0604248E RID: 271502 RVA: 0x011008C0 File Offset: 0x010FEAC0
		private List<int> GetAllSellItemIdList(List<FishingItemInfo> dataList)
		{
			List<int> list = new List<int>();
			foreach (FishingItemInfo fishingItemInfo in dataList)
			{
				if (fishingItemInfo.Price > 0)
				{
					list.Add(fishingItemInfo.ItemId);
				}
			}
			return list;
		}

		// Token: 0x0604248F RID: 271503 RVA: 0x01100924 File Offset: 0x010FEB24
		public void NotifyMainViewUiBlur(bool enable)
		{
			this.MainView.NotifyUiBlur(enable);
		}

		// Token: 0x1700A115 RID: 41237
		// (get) Token: 0x06042490 RID: 271504 RVA: 0x01100934 File Offset: 0x010FEB34
		public bool HasFishingCanSell
		{
			get
			{
				List<DockyardItemBlockOriginalData> showItemList = this.ListPanelModel.GetShowItemList();
				List<DockyardItemBlockOriginalData> backpackItemList = ModelBase<DockyardModel>.Instance.GetBackpackItemList();
				List<int> list = new List<int>();
				foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in showItemList)
				{
					if (dockyardItemBlockOriginalData.Price > 0)
					{
						list.Add(dockyardItemBlockOriginalData.IncId);
					}
				}
				foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData2 in backpackItemList)
				{
					if (dockyardItemBlockOriginalData2.Price > 0)
					{
						list.Add(dockyardItemBlockOriginalData2.IncId);
					}
				}
				return list.Count > 0;
			}
		}

		// Token: 0x04024E7F RID: 151167
		private DockyardShopMainView MainView;
	}
}
