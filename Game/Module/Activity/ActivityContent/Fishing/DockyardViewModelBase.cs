using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200679F RID: 26527
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class DockyardViewModelBase : IDockyardBackpackInterface
	{
		// Token: 0x1700A0EA RID: 41194
		// (get) Token: 0x0604225D RID: 270941 RVA: 0x010F8785 File Offset: 0x010F6985
		protected CabinType RequestCabinType
		{
			get
			{
				if (!this.IsInTrawlState)
				{
					return CabinType.ShipCabin;
				}
				return CabinType.NetCabin;
			}
		}

		// Token: 0x0604225E RID: 270942 RVA: 0x010F8792 File Offset: 0x010F6992
		public void RegisterView(IDockyardViewInterface view)
		{
			this.View = view;
			this.BackpackPanelModel.RegisterViewModel(this);
			this.ListPanelModel.RegisterBackpackPanelModel(this.BackpackPanelModel);
		}

		// Token: 0x0604225F RID: 270943 RVA: 0x010F87B8 File Offset: 0x010F69B8
		public void CloseClick()
		{
			if (this.BackpackPanelModel.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return;
			}
			IDockyardViewInterface view = this.View;
			if (view == null)
			{
				return;
			}
			view.CloseMe(null);
		}

		// Token: 0x06042260 RID: 270944 RVA: 0x010F87ED File Offset: 0x010F69ED
		public bool CheckCurrencyItemClick(int itemId)
		{
			if (this.BackpackPanelModel.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x06042261 RID: 270945 RVA: 0x010F8813 File Offset: 0x010F6A13
		public virtual void AllSellClick()
		{
		}

		// Token: 0x06042262 RID: 270946 RVA: 0x010F8815 File Offset: 0x010F6A15
		public bool IsTrawlInteractive()
		{
			return this.IsInTrawlState;
		}

		// Token: 0x06042263 RID: 270947 RVA: 0x010F881D File Offset: 0x010F6A1D
		public bool IsConfirmInteractive()
		{
			return true;
		}

		// Token: 0x06042264 RID: 270948 RVA: 0x010F8820 File Offset: 0x010F6A20
		public bool IsConfirmNiagaraActive()
		{
			return true;
		}

		// Token: 0x06042265 RID: 270949 RVA: 0x010F8823 File Offset: 0x010F6A23
		public void SetInSelectState(bool inSelectState)
		{
			if (!inSelectState)
			{
				IDockyardViewInterface view = this.View;
				if (view != null)
				{
					view.HideTipsPanel();
				}
				DockyardItemListPanel panel = this.ListPanelModel.Panel;
				if (panel == null)
				{
					return;
				}
				panel.SetDragTipsActive(false);
			}
		}

		// Token: 0x06042266 RID: 270950 RVA: 0x010F884F File Offset: 0x010F6A4F
		public void TrawlClick(bool isSelected)
		{
			this.IsInTrawlState = isSelected;
			IDockyardViewInterface view = this.View;
			if (view == null)
			{
				return;
			}
			view.SetTrawlState(isSelected);
		}

		// Token: 0x06042267 RID: 270951 RVA: 0x010F8869 File Offset: 0x010F6A69
		public virtual void ItemBlockClick(int id)
		{
			IDockyardViewInterface view = this.View;
			if (view == null)
			{
				return;
			}
			view.ShowTipsPanel(id);
		}

		// Token: 0x06042268 RID: 270952 RVA: 0x010F887C File Offset: 0x010F6A7C
		public void DeleteClick()
		{
			List<FishingItemInfo> leftPanelItemBlockDataListExcludeSelected = this.GetLeftPanelItemBlockDataListExcludeSelected();
			List<FishingItemInfo> itemBlockDataListExcludeSelected = this.BackpackPanelModel.Panel.GetItemBlockDataListExcludeSelected();
			RequestCabinPut requestData = new RequestCabinPut
			{
				Type = this.RequestCabinType,
				LeftDataList = leftPanelItemBlockDataListExcludeSelected,
				RightDataList = itemBlockDataListExcludeSelected,
				RemoveIncId = new int?(this.BackpackPanelModel.InSelectedBlockId),
				Callback = delegate(bool isSuccess)
				{
					if (isSuccess)
					{
						this.ListPanelModel.DeleteSelectedItemBlockAndRefresh();
						this.BackpackPanelModel.Panel.DestroySelectItemBlock();
					}
				}
			};
			ControllerBase<FishingController>.Instance.RequestFishingCabinPut(requestData);
		}

		// Token: 0x06042269 RID: 270953 RVA: 0x010F88F4 File Offset: 0x010F6AF4
		public void RotateClick()
		{
			if (!this.BackpackPanelModel.IsOutOfRange)
			{
				this.BackpackPanelModel.Panel.RotateClick();
			}
		}

		// Token: 0x0604226A RID: 270954 RVA: 0x010F8914 File Offset: 0x010F6B14
		public void ConfirmClick()
		{
			if (!this.BackpackPanelModel.CanConfirm())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_CantPutDown", Array.Empty<object>());
				return;
			}
			if (this.BackpackPanelModel.IsOverlap())
			{
				this.BackpackPanelModel.Panel.HandleOverlapConfirm();
				return;
			}
			this.TrySetSelectedItemBlockToBackpack().Forget<bool>();
		}

		// Token: 0x0604226B RID: 270955 RVA: 0x010F896C File Offset: 0x010F6B6C
		public void HandleDragResult()
		{
			if (this.BackpackPanelModel.IsDragFail)
			{
				if (this.IsInTrawlState)
				{
					if (this.BackpackPanelModel.Panel.IsWareHouseDragToBackpack())
					{
						this.BackpackPanelModel.Panel.SetItemBlockToWareHouse();
						return;
					}
					if (this.ListPanelModel.CanDragToListPanel(false))
					{
						this.TryAddToWareHouse().Forget<bool>();
						return;
					}
					this.ListPanelModel.RefreshDragTips(false, true);
				}
				this.BackpackPanelModel.Panel.HandleDragFail();
				return;
			}
			DockyardBackpackPanelModelBase backpackPanelModel = this.BackpackPanelModel;
			if (backpackPanelModel == null)
			{
				return;
			}
			backpackPanelModel.Panel.HandleDragSuccess();
		}

		// Token: 0x0604226C RID: 270956 RVA: 0x010F89FE File Offset: 0x010F6BFE
		public void BackpackTick(float deltaTime)
		{
			this.BackpackPanelModel.Tick();
			this.ListPanelModel.RefreshDragTips(this.BackpackPanelModel.IsInDragState, !this.BackpackPanelModel.IsDragFail);
		}

		// Token: 0x0604226D RID: 270957 RVA: 0x010F8A2F File Offset: 0x010F6C2F
		public void NotifyItemBlockToWareHouse(DockyardItemBlockOriginalData data)
		{
			this.ListPanelModel.SetItemBlockToWareHouse(data);
		}

		// Token: 0x0604226E RID: 270958 RVA: 0x010F8A3D File Offset: 0x010F6C3D
		[NullableContext(2)]
		public UUIItem GetQuicklySellPanelParentItem()
		{
			return this.View.GetQuicklySellPanelParentItem();
		}

		// Token: 0x0604226F RID: 270959 RVA: 0x010F8A4A File Offset: 0x010F6C4A
		public void NotifyQuicklySellActive(bool isActive)
		{
			this.View.NotifyQuicklySellActive(isActive);
		}

		// Token: 0x06042270 RID: 270960 RVA: 0x010F8A58 File Offset: 0x010F6C58
		[NullableContext(0)]
		public UniTask<bool> TrySetSelectedItemBlockToWareHouse()
		{
			DockyardViewModelBase.<TrySetSelectedItemBlockToWareHouse>d__22 <TrySetSelectedItemBlockToWareHouse>d__;
			<TrySetSelectedItemBlockToWareHouse>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySetSelectedItemBlockToWareHouse>d__.<>4__this = this;
			<TrySetSelectedItemBlockToWareHouse>d__.<>1__state = -1;
			<TrySetSelectedItemBlockToWareHouse>d__.<>t__builder.Start<DockyardViewModelBase.<TrySetSelectedItemBlockToWareHouse>d__22>(ref <TrySetSelectedItemBlockToWareHouse>d__);
			return <TrySetSelectedItemBlockToWareHouse>d__.<>t__builder.Task;
		}

		// Token: 0x06042271 RID: 270961 RVA: 0x010F8A9B File Offset: 0x010F6C9B
		public void HandleDragBegin()
		{
		}

		// Token: 0x06042272 RID: 270962 RVA: 0x010F8AA0 File Offset: 0x010F6CA0
		[NullableContext(0)]
		public UniTask<bool> TrySetSelectedItemBlockToBackpack()
		{
			DockyardViewModelBase.<TrySetSelectedItemBlockToBackpack>d__24 <TrySetSelectedItemBlockToBackpack>d__;
			<TrySetSelectedItemBlockToBackpack>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySetSelectedItemBlockToBackpack>d__.<>4__this = this;
			<TrySetSelectedItemBlockToBackpack>d__.<>1__state = -1;
			<TrySetSelectedItemBlockToBackpack>d__.<>t__builder.Start<DockyardViewModelBase.<TrySetSelectedItemBlockToBackpack>d__24>(ref <TrySetSelectedItemBlockToBackpack>d__);
			return <TrySetSelectedItemBlockToBackpack>d__.<>t__builder.Task;
		}

		// Token: 0x06042273 RID: 270963 RVA: 0x010F8AE4 File Offset: 0x010F6CE4
		protected List<FishingItemInfo> GetLeftPanelItemBlockDataList()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			if (this.IsInTrawlState)
			{
				foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ListPanelModel.ShowItemList)
				{
					if (dockyardItemBlockOriginalData.IncId != this.ListPanelModel.InSelectedBlockId)
					{
						list.Add(dockyardItemBlockOriginalData.GetServerData());
					}
				}
			}
			return list;
		}

		// Token: 0x06042274 RID: 270964 RVA: 0x010F8B64 File Offset: 0x010F6D64
		private List<FishingItemInfo> GetLeftPanelItemBlockDataListExcludeSelected()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			if (this.IsInTrawlState)
			{
				foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ListPanelModel.ShowItemList)
				{
					if (dockyardItemBlockOriginalData.IncId != this.ListPanelModel.InSelectedBlockId && dockyardItemBlockOriginalData.IncId != this.BackpackPanelModel.InSelectedBlockId)
					{
						list.Add(dockyardItemBlockOriginalData.GetServerData());
					}
				}
			}
			return list;
		}

		// Token: 0x06042275 RID: 270965 RVA: 0x010F8BF8 File Offset: 0x010F6DF8
		[NullableContext(0)]
		private UniTask<bool> TryAddToWareHouse()
		{
			DockyardViewModelBase.<TryAddToWareHouse>d__27 <TryAddToWareHouse>d__;
			<TryAddToWareHouse>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryAddToWareHouse>d__.<>4__this = this;
			<TryAddToWareHouse>d__.<>1__state = -1;
			<TryAddToWareHouse>d__.<>t__builder.Start<DockyardViewModelBase.<TryAddToWareHouse>d__27>(ref <TryAddToWareHouse>d__);
			return <TryAddToWareHouse>d__.<>t__builder.Task;
		}

		// Token: 0x06042276 RID: 270966 RVA: 0x010F8C3C File Offset: 0x010F6E3C
		public DockyardItemBlockOriginalData GetItemBlockData(int id)
		{
			DockyardItemBlockOriginalData itemBlockData = ModelBase<DockyardModel>.Instance.GetItemBlockData(id);
			if (itemBlockData != null)
			{
				return itemBlockData;
			}
			return ModelBase<DockyardModel>.Instance.GetDataByTrawl(id);
		}

		// Token: 0x1700A0EB RID: 41195
		// (get) Token: 0x06042277 RID: 270967
		public abstract DockyardBackpackPanelModelBase BackpackPanelModel { get; }

		// Token: 0x1700A0EC RID: 41196
		// (get) Token: 0x06042278 RID: 270968
		public abstract DockyardItemListPanelModel ListPanelModel { get; }

		// Token: 0x04024DB7 RID: 150967
		private IDockyardViewInterface View;

		// Token: 0x04024DB8 RID: 150968
		public bool IsInTrawlState;
	}
}
