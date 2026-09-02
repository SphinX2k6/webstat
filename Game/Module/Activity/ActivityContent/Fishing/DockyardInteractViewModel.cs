using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B2 RID: 26546
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractViewModel : IDockyardBackpackInterface, IDockyardConfirmProvider
	{
		// Token: 0x06042340 RID: 271168 RVA: 0x010FBA60 File Offset: 0x010F9C60
		public void RegisterView(DockyardInteractView view)
		{
			this.View = view;
			this.BackpackPanelModel.ConfigId = this.ConfigId;
			this.BackpackPanelModel.RegisterViewModel(this);
			this.InteractPanelModel.ConfigId = this.ConfigId;
			this.InteractPanelModel.RegisterViewModel(this);
			this.BackpackPanelModel.RegisterInteractPanel(this.InteractPanelModel);
			this.InteractPanelModel.RegisterBackpackPanel(this.BackpackPanelModel);
		}

		// Token: 0x06042341 RID: 271169 RVA: 0x010FBAD0 File Offset: 0x010F9CD0
		public bool IsTrawlInteractive()
		{
			return false;
		}

		// Token: 0x06042342 RID: 271170 RVA: 0x010FBAD3 File Offset: 0x010F9CD3
		public void SetInSelectState(bool isInSelectState)
		{
			if (!isInSelectState)
			{
				DockyardInteractView view = this.View;
				if (view == null)
				{
					return;
				}
				view.HideTipsPanel();
			}
		}

		// Token: 0x06042343 RID: 271171 RVA: 0x010FBAE8 File Offset: 0x010F9CE8
		public void NotifyItemBlockToWareHouse(DockyardItemBlockOriginalData data)
		{
		}

		// Token: 0x06042344 RID: 271172 RVA: 0x010FBAEA File Offset: 0x010F9CEA
		[NullableContext(2)]
		public UUIItem GetQuicklySellPanelParentItem()
		{
			return null;
		}

		// Token: 0x06042345 RID: 271173 RVA: 0x010FBAED File Offset: 0x010F9CED
		public void NotifyQuicklySellActive(bool isActive)
		{
		}

		// Token: 0x06042346 RID: 271174 RVA: 0x010FBAEF File Offset: 0x010F9CEF
		[NullableContext(0)]
		public UniTask<bool> TrySetSelectedItemBlockToWareHouse()
		{
			return UniTask.FromResult<bool>(false);
		}

		// Token: 0x06042347 RID: 271175 RVA: 0x010FBAF7 File Offset: 0x010F9CF7
		[NullableContext(0)]
		public UniTask<bool> TrySetSelectedItemBlockToBackpack()
		{
			return UniTask.FromResult<bool>(false);
		}

		// Token: 0x06042348 RID: 271176 RVA: 0x010FBAFF File Offset: 0x010F9CFF
		public void CloseClick()
		{
			if (this.BackpackPanelModel.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return;
			}
			DockyardInteractView view = this.View;
			if (view == null)
			{
				return;
			}
			view.CloseMe(null);
		}

		// Token: 0x06042349 RID: 271177 RVA: 0x010FBB34 File Offset: 0x010F9D34
		public bool CheckCurrencyItemClick(int itemId)
		{
			return false;
		}

		// Token: 0x0604234A RID: 271178 RVA: 0x010FBB37 File Offset: 0x010F9D37
		public bool CheckCurrencyItemClick()
		{
			if (this.BackpackPanelModel.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x0604234B RID: 271179 RVA: 0x010FBB5D File Offset: 0x010F9D5D
		public void ItemBlockClick(int id)
		{
			DockyardInteractView view = this.View;
			if (view == null)
			{
				return;
			}
			view.ShowTipsPanel(id);
		}

		// Token: 0x0604234C RID: 271180 RVA: 0x010FBB70 File Offset: 0x010F9D70
		public void DeleteClick()
		{
			List<FishingItemInfo> leftPanelItemBlockDataListExcludeSelected = this.GetLeftPanelItemBlockDataListExcludeSelected();
			List<FishingItemInfo> itemBlockDataListExcludeSelected = this.BackpackPanelModel.Panel.GetItemBlockDataListExcludeSelected();
			RequestHandleIn requestData = new RequestHandleIn
			{
				InteractId = this.ConfigId,
				LeftDataList = leftPanelItemBlockDataListExcludeSelected,
				RightDataList = itemBlockDataListExcludeSelected,
				ActionIncId = this.ActionIncId,
				RemoveIncId = new int?(this.BackpackPanelModel.InSelectedBlockId),
				Callback = delegate(bool isSuccess, bool _)
				{
					if (isSuccess)
					{
						this.BackpackPanelModel.Panel.DestroySelectItemBlock();
					}
				}
			};
			ControllerBase<FishingController>.Instance.RequestFishingHandIn(requestData);
		}

		// Token: 0x0604234D RID: 271181 RVA: 0x010FBBF4 File Offset: 0x010F9DF4
		public void RotateClick()
		{
			if (!this.BackpackPanelModel.IsOutOfRange)
			{
				this.BackpackPanelModel.Panel.RotateClick();
				return;
			}
			if (!this.InteractPanelModel.IsOutOfRange)
			{
				this.InteractPanelModel.Panel.RotateClick();
			}
		}

		// Token: 0x0604234E RID: 271182 RVA: 0x010FBC34 File Offset: 0x010F9E34
		public void ConfirmClick()
		{
			if (this.TempPanelModel == null)
			{
				return;
			}
			DockyardInteractBackpackPanelModel dockyardInteractBackpackPanelModel = this.TempPanelModel as DockyardInteractBackpackPanelModel;
			if (dockyardInteractBackpackPanelModel != null)
			{
				if (!dockyardInteractBackpackPanelModel.CanConfirm())
				{
					dockyardInteractBackpackPanelModel.ShowScrollingTips();
					return;
				}
			}
			else
			{
				DockyardInteractPanelModel dockyardInteractPanelModel = this.TempPanelModel as DockyardInteractPanelModel;
				if (dockyardInteractPanelModel != null && !dockyardInteractPanelModel.CanConfirm())
				{
					dockyardInteractPanelModel.ShowScrollingTips();
					return;
				}
			}
			DockyardInteractBackpackPanelModel dockyardInteractBackpackPanelModel2 = this.TempPanelModel as DockyardInteractBackpackPanelModel;
			if (dockyardInteractBackpackPanelModel2 != null && dockyardInteractBackpackPanelModel2.IsOverlap())
			{
				dockyardInteractBackpackPanelModel2.Panel.HandleOverlapConfirm();
				return;
			}
			DockyardInteractPanelModel dockyardInteractPanelModel2 = this.TempPanelModel as DockyardInteractPanelModel;
			if (dockyardInteractPanelModel2 != null && dockyardInteractPanelModel2.IsOverlap())
			{
				dockyardInteractPanelModel2.Panel.HandleOverlapConfirm();
				return;
			}
			List<FishingItemInfo> leftPanelItemBlockDataList = this.GetLeftPanelItemBlockDataList();
			List<FishingItemInfo> rightPanelItemBlockDataList = this.GetRightPanelItemBlockDataList();
			RequestHandleIn requestData = new RequestHandleIn
			{
				InteractId = this.ConfigId,
				LeftDataList = leftPanelItemBlockDataList,
				RightDataList = rightPanelItemBlockDataList,
				ActionIncId = this.ActionIncId,
				Callback = delegate(bool isSuccess, bool isComplete)
				{
					this.IsComplete = isComplete;
					if (isSuccess)
					{
						DockyardInteractBackpackPanelModel dockyardInteractBackpackPanelModel3 = this.TempPanelModel as DockyardInteractBackpackPanelModel;
						if (dockyardInteractBackpackPanelModel3 != null)
						{
							dockyardInteractBackpackPanelModel3.Panel.HandleFinishConfirm();
						}
						else
						{
							DockyardInteractPanelModel dockyardInteractPanelModel3 = this.TempPanelModel as DockyardInteractPanelModel;
							if (dockyardInteractPanelModel3 != null)
							{
								dockyardInteractPanelModel3.Panel.HandleFinishConfirm();
							}
						}
					}
					if (isComplete)
					{
						DockyardInteractView view = this.View;
						if (view == null)
						{
							return;
						}
						view.OpenInteractFinishTipsView();
					}
				}
			};
			ControllerBase<FishingController>.Instance.RequestFishingHandIn(requestData);
		}

		// Token: 0x0604234F RID: 271183 RVA: 0x010FBD29 File Offset: 0x010F9F29
		public void TrawlClick(bool isSelected)
		{
		}

		// Token: 0x06042350 RID: 271184 RVA: 0x010FBD2B File Offset: 0x010F9F2B
		public void AllSellClick()
		{
		}

		// Token: 0x06042351 RID: 271185 RVA: 0x010FBD2D File Offset: 0x010F9F2D
		public void HandleDragBegin()
		{
			if (this.InteractPanelModel.LastCanTickState)
			{
				this.TempPanelModel = this.InteractPanelModel;
				return;
			}
			if (!this.BackpackPanelModel.IsOutOfRange)
			{
				this.TempPanelModel = this.BackpackPanelModel;
			}
		}

		// Token: 0x06042352 RID: 271186 RVA: 0x010FBD64 File Offset: 0x010F9F64
		public void HandleDragResult()
		{
			if (!this.BackpackPanelModel.IsOutOfRange)
			{
				this.TempPanelModel = this.BackpackPanelModel;
				this.BackpackPanelModel.Panel.HandleDragSuccess();
				return;
			}
			if (!this.InteractPanelModel.IsOutOfRange)
			{
				this.TempPanelModel = this.InteractPanelModel;
				this.InteractPanelModel.Panel.HandleDragSuccess();
				return;
			}
			if (this.InteractPanelModel.LastCanTickState)
			{
				this.TempPanelModel = this.InteractPanelModel;
				this.InteractPanelModel.Panel.HandleDragFail();
				return;
			}
			DockyardInteractBackpackPanelModel dockyardInteractBackpackPanelModel = this.TempPanelModel as DockyardInteractBackpackPanelModel;
			if (dockyardInteractBackpackPanelModel != null)
			{
				dockyardInteractBackpackPanelModel.Panel.HandleDragFail();
				return;
			}
			DockyardInteractPanelModel dockyardInteractPanelModel = this.TempPanelModel as DockyardInteractPanelModel;
			if (dockyardInteractPanelModel != null)
			{
				dockyardInteractPanelModel.Panel.HandleDragFail();
			}
		}

		// Token: 0x06042353 RID: 271187 RVA: 0x010FBE24 File Offset: 0x010FA024
		public void BackpackTick(float deltaTime)
		{
			this.InteractPanelModel.Tick(deltaTime);
			this.BackpackPanelModel.Tick();
		}

		// Token: 0x06042354 RID: 271188 RVA: 0x010FBE3D File Offset: 0x010FA03D
		public bool IsConfirmInteractive()
		{
			return this.InteractPanelModel.CanConfirm() || !this.BackpackPanelModel.IsSetFail;
		}

		// Token: 0x06042355 RID: 271189 RVA: 0x010FBE5C File Offset: 0x010FA05C
		public bool IsConfirmNiagaraActive()
		{
			return this.InteractPanelModel.CanConfirm() || this.BackpackPanelModel.IsInCanConfirm;
		}

		// Token: 0x06042356 RID: 271190 RVA: 0x010FBE78 File Offset: 0x010FA078
		public DockyardItemBlockOriginalData GetItemBlockDataByIncId(int incId)
		{
			return this.BackpackPanelModel.Panel.GetOriginalItemBlockDataByIncId(incId);
		}

		// Token: 0x06042357 RID: 271191 RVA: 0x010FBE8C File Offset: 0x010FA08C
		private List<FishingItemInfo> GetLeftPanelItemBlockDataList()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			foreach (DockyardInteractItemBlockData dockyardInteractItemBlockData in this.InteractPanelModel.ShowItemMap.Values)
			{
				FishingItemInfo item = DockyardPanelUtil.CreateFishingItemInfo(dockyardInteractItemBlockData.Data, (FishingItemRotate)dockyardInteractItemBlockData.Rotate, dockyardInteractItemBlockData.Pos);
				list.Add(item);
			}
			DockyardInteractPanelModel dockyardInteractPanelModel = this.TempPanelModel as DockyardInteractPanelModel;
			if (dockyardInteractPanelModel != null)
			{
				DockyardItemBlockData data = this.BackpackPanelModel.Panel.InSelectItemBlock.GetData();
				IPanelPos leftTopPanelPos = dockyardInteractPanelModel.Panel.GetLeftTopPanelPos(data.Data.ItemId);
				FishingItemInfo item2 = DockyardPanelUtil.CreateFishingItemInfo(data.Data, data.Rotate, leftTopPanelPos);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06042358 RID: 271192 RVA: 0x010FBF68 File Offset: 0x010FA168
		private List<FishingItemInfo> GetRightPanelItemBlockDataList()
		{
			List<FishingItemInfo> itemBlockDataList = this.BackpackPanelModel.Panel.GetItemBlockDataList();
			if (this.TempPanelModel is DockyardInteractPanelModel)
			{
				for (int i = 0; i < itemBlockDataList.Count; i++)
				{
					if (itemBlockDataList[i].IncrId == this.BackpackPanelModel.InSelectedBlockId)
					{
						itemBlockDataList.RemoveAt(i);
						break;
					}
				}
			}
			return itemBlockDataList;
		}

		// Token: 0x06042359 RID: 271193 RVA: 0x010FBFC8 File Offset: 0x010FA1C8
		private List<FishingItemInfo> GetLeftPanelItemBlockDataListExcludeSelected()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			foreach (DockyardInteractItemBlockData dockyardInteractItemBlockData in this.InteractPanelModel.ShowItemMap.Values)
			{
				if (dockyardInteractItemBlockData.Data.IncId != this.BackpackPanelModel.InSelectedBlockId)
				{
					FishingItemInfo item = DockyardPanelUtil.CreateFishingItemInfo(dockyardInteractItemBlockData.Data, (FishingItemRotate)dockyardInteractItemBlockData.Rotate, dockyardInteractItemBlockData.Pos);
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x04024E0B RID: 151051
		[Nullable(2)]
		private DockyardInteractView View;

		// Token: 0x04024E0C RID: 151052
		public int ConfigId = -1;

		// Token: 0x04024E0D RID: 151053
		public int ActionIncId = -1;

		// Token: 0x04024E0E RID: 151054
		public bool IsComplete;

		// Token: 0x04024E0F RID: 151055
		public readonly DockyardInteractBackpackPanelModel BackpackPanelModel = new DockyardInteractBackpackPanelModel();

		// Token: 0x04024E10 RID: 151056
		public readonly DockyardInteractPanelModel InteractPanelModel = new DockyardInteractPanelModel();

		// Token: 0x04024E11 RID: 151057
		[Nullable(2)]
		private object TempPanelModel;
	}
}
