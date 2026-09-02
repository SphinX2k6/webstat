using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067A0 RID: 26528
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class DockyardWareHouseViewModelBase : IDockyardBackpackInterface
	{
		// Token: 0x0604227B RID: 270971 RVA: 0x010F8C8D File Offset: 0x010F6E8D
		public void RegisterView(DockyardWareHouseView view)
		{
			this.View = view;
			this.BackpackPanelModel.RegisterViewModel(this);
			this.ListPanelModel.RegisterBackpackPanelModel(this.BackpackPanelModel);
			this.OnInit();
		}

		// Token: 0x0604227C RID: 270972 RVA: 0x010F8CB9 File Offset: 0x010F6EB9
		public void CloseClick()
		{
			if (this.BackpackPanelModel.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return;
			}
			this.OnCloseClick();
		}

		// Token: 0x0604227D RID: 270973 RVA: 0x010F8CE3 File Offset: 0x010F6EE3
		public bool CheckCurrencyItemClick(int itemId)
		{
			if (this.BackpackPanelModel.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x0604227E RID: 270974 RVA: 0x010F8D09 File Offset: 0x010F6F09
		public void ItemBlockClick(int id)
		{
			DockyardWareHouseView view = this.View;
			if (view == null)
			{
				return;
			}
			view.ShowTipsPanel(id);
		}

		// Token: 0x0604227F RID: 270975 RVA: 0x010F8D1C File Offset: 0x010F6F1C
		public void SetInSelectState(bool inSelectState)
		{
			if (!inSelectState)
			{
				DockyardWareHouseView view = this.View;
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

		// Token: 0x06042280 RID: 270976 RVA: 0x010F8D48 File Offset: 0x010F6F48
		public void HandleDragResult()
		{
			if (!this.BackpackPanelModel.IsDragFail)
			{
				this.BackpackPanelModel.Panel.HandleDragSuccess();
				return;
			}
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
			this.BackpackPanelModel.Panel.HandleDragFail();
			this.ListPanelModel.RefreshDragTips(false, true);
		}

		// Token: 0x06042281 RID: 270977 RVA: 0x010F8DD0 File Offset: 0x010F6FD0
		public void DeleteClick()
		{
			List<FishingItemInfo> leftPanelItemBlockDataListExcludeSelected = this.GetLeftPanelItemBlockDataListExcludeSelected();
			List<FishingItemInfo> itemBlockDataListExcludeSelected = this.BackpackPanelModel.Panel.GetItemBlockDataListExcludeSelected();
			RequestCabinPut requestData = new RequestCabinPut
			{
				Type = this.RequestCabinType,
				RequestId = new int?(this.RequestId),
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

		// Token: 0x06042282 RID: 270978 RVA: 0x010F8E59 File Offset: 0x010F7059
		public void RotateClick()
		{
			if (!this.BackpackPanelModel.IsOutOfRange)
			{
				this.BackpackPanelModel.Panel.RotateClick();
			}
		}

		// Token: 0x06042283 RID: 270979 RVA: 0x010F8E78 File Offset: 0x010F7078
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

		// Token: 0x06042284 RID: 270980 RVA: 0x010F8ED0 File Offset: 0x010F70D0
		public void NotifyItemBlockToWareHouse(DockyardItemBlockOriginalData data)
		{
			this.ListPanelModel.SetItemBlockToWareHouse(data);
		}

		// Token: 0x06042285 RID: 270981 RVA: 0x010F8EDE File Offset: 0x010F70DE
		public void BackpackTick(float deltaTime)
		{
			this.BackpackPanelModel.Tick();
			this.ListPanelModel.RefreshDragTips(this.BackpackPanelModel.IsInDragState, !this.BackpackPanelModel.IsDragFail);
		}

		// Token: 0x06042286 RID: 270982 RVA: 0x010F8F0F File Offset: 0x010F710F
		public UUIItem GetQuicklySellPanelParentItem()
		{
			return this.View.GetPanelParentItem();
		}

		// Token: 0x06042287 RID: 270983 RVA: 0x010F8F1C File Offset: 0x010F711C
		public void NotifyQuicklySellActive(bool isActive)
		{
			this.View.NotifyQuicklySellActive(isActive);
		}

		// Token: 0x06042288 RID: 270984 RVA: 0x010F8F2C File Offset: 0x010F712C
		[NullableContext(0)]
		public UniTask<bool> TrySetSelectedItemBlockToWareHouse()
		{
			DockyardWareHouseViewModelBase.<TrySetSelectedItemBlockToWareHouse>d__15 <TrySetSelectedItemBlockToWareHouse>d__;
			<TrySetSelectedItemBlockToWareHouse>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySetSelectedItemBlockToWareHouse>d__.<>4__this = this;
			<TrySetSelectedItemBlockToWareHouse>d__.<>1__state = -1;
			<TrySetSelectedItemBlockToWareHouse>d__.<>t__builder.Start<DockyardWareHouseViewModelBase.<TrySetSelectedItemBlockToWareHouse>d__15>(ref <TrySetSelectedItemBlockToWareHouse>d__);
			return <TrySetSelectedItemBlockToWareHouse>d__.<>t__builder.Task;
		}

		// Token: 0x06042289 RID: 270985 RVA: 0x010F8F70 File Offset: 0x010F7170
		[NullableContext(0)]
		public UniTask<bool> TrySetSelectedItemBlockToBackpack()
		{
			DockyardWareHouseViewModelBase.<TrySetSelectedItemBlockToBackpack>d__16 <TrySetSelectedItemBlockToBackpack>d__;
			<TrySetSelectedItemBlockToBackpack>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySetSelectedItemBlockToBackpack>d__.<>4__this = this;
			<TrySetSelectedItemBlockToBackpack>d__.<>1__state = -1;
			<TrySetSelectedItemBlockToBackpack>d__.<>t__builder.Start<DockyardWareHouseViewModelBase.<TrySetSelectedItemBlockToBackpack>d__16>(ref <TrySetSelectedItemBlockToBackpack>d__);
			return <TrySetSelectedItemBlockToBackpack>d__.<>t__builder.Task;
		}

		// Token: 0x0604228A RID: 270986 RVA: 0x010F8FB4 File Offset: 0x010F71B4
		private List<FishingItemInfo> GetLeftPanelItemBlockDataList()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ListPanelModel.ShowItemList)
			{
				if (dockyardItemBlockOriginalData.IncId != this.ListPanelModel.InSelectedBlockId)
				{
					list.Add(dockyardItemBlockOriginalData.GetServerData());
				}
			}
			return list;
		}

		// Token: 0x0604228B RID: 270987 RVA: 0x010F902C File Offset: 0x010F722C
		private List<FishingItemInfo> GetLeftPanelItemBlockDataListExcludeSelected()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ListPanelModel.ShowItemList)
			{
				if (dockyardItemBlockOriginalData.IncId != this.ListPanelModel.InSelectedBlockId && dockyardItemBlockOriginalData.IncId != this.BackpackPanelModel.InSelectedBlockId)
				{
					list.Add(dockyardItemBlockOriginalData.GetServerData());
				}
			}
			return list;
		}

		// Token: 0x0604228C RID: 270988 RVA: 0x010F90B8 File Offset: 0x010F72B8
		[NullableContext(0)]
		private UniTask<bool> TryAddToWareHouse()
		{
			DockyardWareHouseViewModelBase.<TryAddToWareHouse>d__19 <TryAddToWareHouse>d__;
			<TryAddToWareHouse>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryAddToWareHouse>d__.<>4__this = this;
			<TryAddToWareHouse>d__.<>1__state = -1;
			<TryAddToWareHouse>d__.<>t__builder.Start<DockyardWareHouseViewModelBase.<TryAddToWareHouse>d__19>(ref <TryAddToWareHouse>d__);
			return <TryAddToWareHouse>d__.<>t__builder.Task;
		}

		// Token: 0x0604228D RID: 270989 RVA: 0x010F90FB File Offset: 0x010F72FB
		public void HandleDragBegin()
		{
		}

		// Token: 0x0604228E RID: 270990 RVA: 0x010F90FD File Offset: 0x010F72FD
		public bool IsConfirmInteractive()
		{
			return true;
		}

		// Token: 0x0604228F RID: 270991 RVA: 0x010F9100 File Offset: 0x010F7300
		public bool IsConfirmNiagaraActive()
		{
			return true;
		}

		// Token: 0x06042290 RID: 270992 RVA: 0x010F9103 File Offset: 0x010F7303
		public bool IsTrawlInteractive()
		{
			return false;
		}

		// Token: 0x06042291 RID: 270993 RVA: 0x010F9106 File Offset: 0x010F7306
		public void TrawlClick(bool isSelected)
		{
		}

		// Token: 0x06042292 RID: 270994 RVA: 0x010F9108 File Offset: 0x010F7308
		public void AllSellClick()
		{
		}

		// Token: 0x1700A0ED RID: 41197
		// (get) Token: 0x06042293 RID: 270995
		public abstract DockyardBackpackPanelModelBase BackpackPanelModel { get; }

		// Token: 0x1700A0EE RID: 41198
		// (get) Token: 0x06042294 RID: 270996
		public abstract DockyardItemListPanelModel ListPanelModel { get; }

		// Token: 0x1700A0EF RID: 41199
		// (get) Token: 0x06042295 RID: 270997
		protected abstract CabinType RequestCabinType { get; }

		// Token: 0x06042296 RID: 270998
		[NullableContext(2)]
		public abstract DockyardItemBlockOriginalData GetItemBlockData(int id);

		// Token: 0x06042297 RID: 270999 RVA: 0x010F910A File Offset: 0x010F730A
		protected virtual void OnInit()
		{
		}

		// Token: 0x06042298 RID: 271000 RVA: 0x010F910C File Offset: 0x010F730C
		public virtual UniTask BeforeStartAsync()
		{
			DockyardWareHouseViewModelBase.<BeforeStartAsync>d__34 <BeforeStartAsync>d__;
			<BeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BeforeStartAsync>d__.<>4__this = this;
			<BeforeStartAsync>d__.<>1__state = -1;
			<BeforeStartAsync>d__.<>t__builder.Start<DockyardWareHouseViewModelBase.<BeforeStartAsync>d__34>(ref <BeforeStartAsync>d__);
			return <BeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042299 RID: 271001 RVA: 0x010F914F File Offset: 0x010F734F
		protected virtual void OnCloseClick()
		{
			DockyardWareHouseView view = this.View;
			if (view == null)
			{
				return;
			}
			view.CloseMe(null);
		}

		// Token: 0x1700A0F0 RID: 41200
		// (get) Token: 0x0604229A RID: 271002 RVA: 0x010F9162 File Offset: 0x010F7362
		protected virtual int RequestId
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x04024DB9 RID: 150969
		[Nullable(2)]
		protected DockyardWareHouseView View;

		// Token: 0x04024DBA RID: 150970
		public string ViewTitle = "";
	}
}
