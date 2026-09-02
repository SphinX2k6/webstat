using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006794 RID: 26516
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardBackpackPanel : UiPanelBase
	{
		// Token: 0x060421AF RID: 270767 RVA: 0x010F6088 File Offset: 0x010F4288
		public DockyardBackpackPanel(DockyardBackpackPanelModelBase panelModel)
		{
			this.PanelModel = panelModel;
			this.PanelModel.InitPanel(this);
		}

		// Token: 0x060421B0 RID: 270768 RVA: 0x010F6144 File Offset: 0x010F4344
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 8;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.PanelModel.OnSellClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.PanelModel.OnTrawlClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.PanelModel.OnDeleteClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.PanelModel.OnRotateClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.PanelModel.OnConfirmClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.PanelModel.OnAllSellClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.PanelModel.OnBackToWareHouseClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.PanelModel.OnMaskClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060421B1 RID: 270769 RVA: 0x010F6504 File Offset: 0x010F4704
		private void InitTickSystem()
		{
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.PanelModel.BackpackTick), "DockyardBackpackPanel", ETickingGroup.TG_PrePhysics, true, 0, true);
			this.TickId = ((ticker != null) ? ticker.Id : -1);
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
		}

		// Token: 0x060421B2 RID: 270770 RVA: 0x010F6564 File Offset: 0x010F4764
		private void InitOther()
		{
			this.Sell = new DockyardBackpackPanel.ButtonSequencePlayer(base.GetExtendToggle(4).RootUIComp);
			this.Trawl = new DockyardBackpackPanel.ButtonSequencePlayer(base.GetExtendToggle(5).RootUIComp);
			this.Delete = new DockyardBackpackPanel.ButtonSequencePlayer(base.GetButton(6).RootUIComp);
			this.Rotate = new DockyardBackpackPanel.ButtonSequencePlayer(base.GetButton(7).RootUIComp);
			this.Confirm = new DockyardBackpackPanel.ButtonSequencePlayer(base.GetButton(8).RootUIComp);
			this.AllSell = new DockyardBackpackPanel.ButtonSequencePlayer(base.GetButton(10).RootUIComp);
			this.BackToWareHouse = new DockyardBackpackPanel.ButtonSequencePlayer(base.GetButton(11).RootUIComp);
			this.GridItem = base.GetItem(2);
			this.AttachItem = base.GetItem(9);
			this.DragRoot = base.GetItem(3);
			this.ConfirmBtn = base.GetButton(8);
			this.ConfirmBtn.SetCanClickWhenDisable(true);
			this.ConfirmInteractive = this.ConfirmBtn.IsSelfInteractive;
			this.SetQuickSellToggleState();
			this.SetTrawlToggleState();
			this.SetConfirmNiagaraActive(false);
			this.SetQuicklySellRedDotState(false);
		}

		// Token: 0x060421B3 RID: 270771 RVA: 0x010F66A3 File Offset: 0x010F48A3
		private void SetQuickSellToggleState()
		{
			this.Sell.SetActive(this.PanelModel.IsQuickSellOpen());
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnFishingBackpackQuickSellToggleStateChange, this.PanelModel.IsQuickSellOpen());
		}

		// Token: 0x060421B4 RID: 270772 RVA: 0x010F66D6 File Offset: 0x010F48D6
		private void SetTrawlToggleState()
		{
			this.Trawl.SetActive(this.PanelModel.GetIsTrawlOpen());
		}

		// Token: 0x060421B5 RID: 270773 RVA: 0x010F66F0 File Offset: 0x010F48F0
		private UniTask InitLayout()
		{
			DockyardBackpackPanel.<InitLayout>d__31 <InitLayout>d__;
			<InitLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLayout>d__.<>4__this = this;
			<InitLayout>d__.<>1__state = -1;
			<InitLayout>d__.<>t__builder.Start<DockyardBackpackPanel.<InitLayout>d__31>(ref <InitLayout>d__);
			return <InitLayout>d__.<>t__builder.Task;
		}

		// Token: 0x060421B6 RID: 270774 RVA: 0x010F6734 File Offset: 0x010F4934
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<DockyardItemBlock> CreateItemBlock(DockyardItemBlockData itemData, UUIItem parentItem)
		{
			DockyardBackpackPanel.<CreateItemBlock>d__32 <CreateItemBlock>d__;
			<CreateItemBlock>d__.<>t__builder = AsyncUniTaskMethodBuilder<DockyardItemBlock>.Create();
			<CreateItemBlock>d__.<>4__this = this;
			<CreateItemBlock>d__.itemData = itemData;
			<CreateItemBlock>d__.parentItem = parentItem;
			<CreateItemBlock>d__.<>1__state = -1;
			<CreateItemBlock>d__.<>t__builder.Start<DockyardBackpackPanel.<CreateItemBlock>d__32>(ref <CreateItemBlock>d__);
			return <CreateItemBlock>d__.<>t__builder.Task;
		}

		// Token: 0x060421B7 RID: 270775 RVA: 0x010F6788 File Offset: 0x010F4988
		private void InitItemBlockState()
		{
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.Layout.GetLayoutItemList())
			{
				dockyardBackpackGrid.ResetPreviewBgForce();
			}
			foreach (DockyardItemBlock dockyardItemBlock in this.ItemBlockMap.Values)
			{
				dockyardItemBlock.InitAnchorOffset(this.GridItem.Width, this.GridItem.Height, dockyardItemBlock.GetData().LeftTopPosInPanel.RowIndex, dockyardItemBlock.GetData().LeftTopPosInPanel.ColIndex);
				this.RefreshBackpackGridState(dockyardItemBlock);
			}
		}

		// Token: 0x060421B8 RID: 270776 RVA: 0x010F6860 File Offset: 0x010F4A60
		private void RefreshTitle()
		{
			int backpackUseSize = ModelBase<DockyardModel>.Instance.BackpackUseSize;
			int backpackSize = ModelBase<DockyardModel>.Instance.BackpackSize;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Fishing_CabinCapacity", new <>z__ReadOnlyArray<object>(new object[]
			{
				backpackUseSize,
				backpackSize
			}));
		}

		// Token: 0x060421B9 RID: 270777 RVA: 0x010F68B8 File Offset: 0x010F4AB8
		private void RefreshTrawlRedDot()
		{
			bool uiactive = ModelBase<DockyardModel>.Instance.GetTrawlDataList().Count > 0;
			UUIItem item = base.GetItem(12);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x060421BA RID: 270778 RVA: 0x010F68EB File Offset: 0x010F4AEB
		private void SetQuicklySellRedDotState(bool isActive)
		{
			UUIItem item = base.GetItem(14);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isActive);
		}

		// Token: 0x060421BB RID: 270779 RVA: 0x010F6900 File Offset: 0x010F4B00
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardBackpackPanel.<OnBeforeStartAsync>d__37 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardBackpackPanel.<OnBeforeStartAsync>d__37>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060421BC RID: 270780 RVA: 0x010F6944 File Offset: 0x010F4B44
		private UniTask RefreshPanel()
		{
			DockyardBackpackPanel.<RefreshPanel>d__38 <RefreshPanel>d__;
			<RefreshPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshPanel>d__.<>4__this = this;
			<RefreshPanel>d__.<>1__state = -1;
			<RefreshPanel>d__.<>t__builder.Start<DockyardBackpackPanel.<RefreshPanel>d__38>(ref <RefreshPanel>d__);
			return <RefreshPanel>d__.<>t__builder.Task;
		}

		// Token: 0x060421BD RID: 270781 RVA: 0x010F6988 File Offset: 0x010F4B88
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			DockyardBackpackPanel.<OnBeforeShowAsyncImplement>d__39 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<DockyardBackpackPanel.<OnBeforeShowAsyncImplement>d__39>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060421BE RID: 270782 RVA: 0x010F69CB File Offset: 0x010F4BCB
		protected override void OnBeforeShow()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Resume(this.TickId);
			}
			Singleton<EventSystem>.Instance.Add(EEventName.FishingRefreshBackpackData, new Action(this.RefreshBackpackData));
		}

		// Token: 0x060421BF RID: 270783 RVA: 0x010F6A03 File Offset: 0x010F4C03
		protected override void OnAfterHide()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingRefreshBackpackData, new Action(this.RefreshBackpackData));
		}

		// Token: 0x060421C0 RID: 270784 RVA: 0x010F6A3B File Offset: 0x010F4C3B
		private void RefreshBackpackData()
		{
			this.RefreshTitle();
			this.RefreshTrawlRedDot();
		}

		// Token: 0x060421C1 RID: 270785 RVA: 0x010F6A4C File Offset: 0x010F4C4C
		protected override void OnBeforeDestroy()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
			this.Sell.Clear();
			this.Trawl.Clear();
			this.Delete.Clear();
			this.Rotate.Clear();
			this.Confirm.Clear();
			this.AllSell.Clear();
			this.BackToWareHouse.Clear();
		}

		// Token: 0x060421C2 RID: 270786 RVA: 0x010F6AC7 File Offset: 0x010F4CC7
		private DockyardBackpackGrid InitItem()
		{
			return new DockyardBackpackGrid(this.PanelModel);
		}

		// Token: 0x060421C3 RID: 270787 RVA: 0x010F6AD4 File Offset: 0x010F4CD4
		private void ChangeBackpackGridShowType(DockyardItemBlock itemBlock, IPanelPosRange rangePos)
		{
			this.OverlapMap.Clear();
			this.SelectItemBlockGridSet.Clear();
			this.UnValidGridOverlapSet.Clear();
			int num = Math.Max(rangePos.RowStartIndex, 0);
			int num2 = Math.Min(rangePos.RowEndIndex, 6);
			int num3 = Math.Max(rangePos.ColStartIndex, 0);
			int num4 = Math.Min(rangePos.ColEndIndex, 7);
			int uniqueId = itemBlock.GetUniqueId();
			bool flag = itemBlock.IsPartOutOfRange(rangePos, 7, 8);
			bool flag2 = false;
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					DockyardBackpackGrid itemGridInLayout = this.GetItemGridInLayout(i, j);
					if (itemGridInLayout != null)
					{
						int itemBlockId = itemGridInLayout.GetItemBlockId();
						if (!itemBlock.IsValidGridPos(i, j))
						{
							if (itemBlockId != -1)
							{
								this.UnValidGridOverlapSet.Add(itemBlockId);
							}
						}
						else
						{
							flag2 = (flag2 || itemGridInLayout.InDisable());
							this.SelectItemBlockGridSet.Add(itemGridInLayout);
							if ((itemBlockId != uniqueId && itemBlockId != -1) || flag)
							{
								List<DockyardBackpackGrid> list;
								if (!this.OverlapMap.TryGetValue(itemBlockId, out list))
								{
									list = new List<DockyardBackpackGrid>();
									this.OverlapMap.Add(itemBlockId, list);
								}
								list.Add(itemGridInLayout);
							}
						}
					}
				}
			}
			this.PanelModel.IsSetFail = (flag || this.OverlapMap.Count > 1 || flag2);
			this.PanelModel.IsDragFail = this.PanelModel.IsOutOfRange;
			if (this.PanelModel.IsInSelectState)
			{
				this.RefreshOverlapGridShowType(uniqueId);
				return;
			}
			this.RefreshOverlapGridFinishType(uniqueId);
		}

		// Token: 0x060421C4 RID: 270788 RVA: 0x010F6C6C File Offset: 0x010F4E6C
		private void ResetBackpackGridShowType(IPanelPosRange rangePos, int itemBlockId)
		{
			int num = (rangePos.RowStartIndex >= 0) ? rangePos.RowStartIndex : 0;
			int num2 = (rangePos.RowEndIndex < 7) ? rangePos.RowEndIndex : 6;
			int num3 = (rangePos.ColStartIndex >= 0) ? rangePos.ColStartIndex : 0;
			int num4 = (rangePos.ColEndIndex < 8) ? rangePos.ColEndIndex : 7;
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					DockyardBackpackGrid itemGridInLayout = this.GetItemGridInLayout(i, j);
					if (itemGridInLayout != null)
					{
						itemGridInLayout.ResetPreviewBg(itemBlockId);
					}
				}
			}
		}

		// Token: 0x060421C5 RID: 270789 RVA: 0x010F6CF4 File Offset: 0x010F4EF4
		[NullableContext(2)]
		private DockyardItemBlock GetItemBlockById(int id)
		{
			DockyardItemBlock valueOrDefault = this.ItemBlockMap.GetValueOrDefault(id);
			if (valueOrDefault == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Dockyard;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "选择的道具不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemBlockId", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return valueOrDefault;
		}

		// Token: 0x060421C6 RID: 270790 RVA: 0x010F6D44 File Offset: 0x010F4F44
		[NullableContext(2)]
		private DockyardBackpackGrid GetItemGridInLayout(int rowIndex, int colIndex)
		{
			IPanelPos backpackPosByPos = this.PanelModel.BackpackData.GetBackpackPosByPos(rowIndex, colIndex);
			if (backpackPosByPos == null)
			{
				return null;
			}
			return this.Layout.GetLayoutItemByKey(backpackPosByPos);
		}

		// Token: 0x060421C7 RID: 270791 RVA: 0x010F6D78 File Offset: 0x010F4F78
		private void RefreshBackpackGridState(DockyardItemBlock itemBlock)
		{
			IPanelPosRange leftTopPosRangeByPanel = itemBlock.GetLeftTopPosRangeByPanel(this.DragRoot);
			this.ChangeBackpackGridShowType(itemBlock, leftTopPosRangeByPanel);
		}

		// Token: 0x060421C8 RID: 270792 RVA: 0x010F6D9C File Offset: 0x010F4F9C
		private void RefreshOverlapGridShowType(int itemBlockId)
		{
			EFishingGridShowType showType = EFishingGridShowType.Preview;
			if (this.PanelModel.IsSetFail)
			{
				showType = EFishingGridShowType.MultiOccupancy;
			}
			else if (this.OverlapMap.Count == 1)
			{
				showType = EFishingGridShowType.SingleOccupancy;
			}
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.SelectItemBlockGridSet)
			{
				dockyardBackpackGrid.RefreshPreview(itemBlockId, showType);
			}
		}

		// Token: 0x060421C9 RID: 270793 RVA: 0x010F6E14 File Offset: 0x010F5014
		private void RefreshOverlapGridFinishType(int itemBlockId)
		{
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.SelectItemBlockGridSet)
			{
				dockyardBackpackGrid.RefreshPreview(itemBlockId, EFishingGridShowType.Finish);
			}
		}

		// Token: 0x060421CA RID: 270794 RVA: 0x010F6E68 File Offset: 0x010F5068
		private void PlaySelectItemBlockGridSequence(string sequenceName)
		{
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.SelectItemBlockGridSet)
			{
				dockyardBackpackGrid.PlaySequence(sequenceName);
			}
		}

		// Token: 0x060421CB RID: 270795 RVA: 0x010F6EBC File Offset: 0x010F50BC
		private void TryHandleRotateFail()
		{
			if (this.PanelModel.IsDragFail)
			{
				DockyardItemBlock inSelectItemBlock = this.InSelectItemBlock;
				if (inSelectItemBlock != null)
				{
					inSelectItemBlock.ResetToAppropriatePos(7, 8, this.DragRoot);
				}
				this.PanelModel.RefreshPanel(true);
			}
		}

		// Token: 0x060421CC RID: 270796 RVA: 0x010F6EF0 File Offset: 0x010F50F0
		private void SetDeleteBtnState(bool isInSelectState)
		{
			this.Delete.SetActive(this.PanelModel.IsDeleteOpen && isInSelectState);
		}

		// Token: 0x060421CD RID: 270797 RVA: 0x010F6F0C File Offset: 0x010F510C
		public void SetButtonsState(bool isInSelectState)
		{
			this.SetDeleteBtnState(isInSelectState);
			this.Rotate.SetActive(isInSelectState);
			this.Confirm.SetActive(isInSelectState);
			this.BackToWareHouse.SetActive(isInSelectState && this.PanelModel.GetIsBackToWareHouseOpen());
			base.GetButton(13).RootUIComp.Get().SetUIActive(isInSelectState);
			base.GetItem(16).SetUIActive(isInSelectState);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.FishingBackpackBtnStateChange, isInSelectState);
		}

		// Token: 0x060421CE RID: 270798 RVA: 0x010F6F8E File Offset: 0x010F518E
		public void SetAllSellBtnState(bool isInSelectState)
		{
			this.AllSell.SetActive(this.PanelModel.IsAllSellOpen && !isInSelectState);
		}

		// Token: 0x060421CF RID: 270799 RVA: 0x010F6FB0 File Offset: 0x010F51B0
		public void SetItemBlockTextureMaskActive(bool isActive)
		{
			foreach (DockyardItemBlock dockyardItemBlock in this.ItemBlockMap.Values)
			{
				if (dockyardItemBlock.GetData().Data.IncId != this.PanelModel.InSelectedBlockId)
				{
					dockyardItemBlock.SetTextureMaskActive(isActive);
				}
			}
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.Layout.GetLayoutItemList())
			{
				if (dockyardBackpackGrid.GetItemBlockId() != -1)
				{
					dockyardBackpackGrid.SetSpriteMaskActive(isActive);
				}
			}
		}

		// Token: 0x060421D0 RID: 270800 RVA: 0x010F7078 File Offset: 0x010F5278
		public void RefreshAllBackpackGridState(bool checkRangeChange = true)
		{
			IPanelPosRange leftTopPosRangeByPanel = this.InSelectItemBlock.GetLeftTopPosRangeByPanel(this.DragRoot);
			bool flag = this.InSelectItemBlock.IsRangeChange(this.LastLeftTopPos, leftTopPosRangeByPanel);
			if (!flag && checkRangeChange)
			{
				DockyardPanelUtil.DeepCopyItemRangePos(this.LastLeftTopPos, leftTopPosRangeByPanel);
				return;
			}
			bool flag2 = this.InSelectItemBlock.IsOutOfRange(leftTopPosRangeByPanel, 7, 8);
			if (this.PanelModel.IsOutOfRange && flag2)
			{
				DockyardPanelUtil.DeepCopyItemRangePos(this.LastLeftTopPos, leftTopPosRangeByPanel);
				return;
			}
			this.PanelModel.IsMoved = (flag && this.PanelModel.IsInDragState);
			this.PanelModel.IsOutOfRange = flag2;
			this.ResetBackpackGridShowType(this.LastLeftTopPos, this.PanelModel.InSelectedBlockId);
			this.ChangeBackpackGridShowType(this.InSelectItemBlock, leftTopPosRangeByPanel);
			DockyardPanelUtil.DeepCopyItemRangePos(this.LastLeftTopPos, leftTopPosRangeByPanel);
		}

		// Token: 0x060421D1 RID: 270801 RVA: 0x010F7144 File Offset: 0x010F5344
		public void HandleDragFail()
		{
			this.InSelectItemBlock.AdsorbToAppropriatePosByAttachItem(this.AppropriatePos.RowStartIndex, this.AppropriatePos.ColStartIndex, this.DragRoot);
			this.PanelModel.RefreshPanel(true);
			this.PlaySelectItemBlockGridSequence("Success");
			if (!this.PanelModel.IsInHighlight)
			{
				this.HandleFinishConfirm();
				return;
			}
			this.SetButtonsState(true);
		}

		// Token: 0x060421D2 RID: 270802 RVA: 0x010F71AC File Offset: 0x010F53AC
		public void HandleDragSuccess()
		{
			DockyardPanelUtil.DeepCopyItemRangePos(this.AppropriatePos, this.LastLeftTopPos);
			this.InSelectItemBlock.AdsorbToAppropriatePosByAttachItem(this.AppropriatePos.RowStartIndex, this.AppropriatePos.ColStartIndex, this.DragRoot);
			string sequenceName = this.PanelModel.IsSetFail ? "Fail" : "Success";
			this.PlaySelectItemBlockGridSequence(sequenceName);
			if (!this.PanelModel.IsInHighlight && this.PanelModel.IsMoved)
			{
				this.PanelModel.OnConfirmClick();
				return;
			}
			this.SetButtonsState(true);
		}

		// Token: 0x060421D3 RID: 270803 RVA: 0x010F723F File Offset: 0x010F543F
		public void SetItemBlockToWareHouse()
		{
			this.PanelModel.SetItemBlockToWareHouse(this.InSelectItemBlock.GetData().Data);
			this.DestroySelectItemBlock();
			this.TryRefreshQuicklySellPanel();
		}

		// Token: 0x060421D4 RID: 270804 RVA: 0x010F7268 File Offset: 0x010F5468
		public bool CanDrag(int id)
		{
			return this.PanelModel.InSelectedBlockId == -1 || this.PanelModel.InSelectedBlockId == id;
		}

		// Token: 0x060421D5 RID: 270805 RVA: 0x010F7288 File Offset: 0x010F5488
		public void ItemBlockClick(int id)
		{
			this.PanelModel.InSelectedBlockId = id;
			this.PanelModel.IsInSelectState = true;
			this.InSelectItemBlock = this.GetItemBlockById(id);
			this.LastLeftTopPos = this.InSelectItemBlock.GetLeftTopPosRangeByPanel(this.DragRoot);
			DockyardPanelUtil.DeepCopyItemRangePos(this.AppropriatePos, this.LastLeftTopPos);
			this.InSelectItemBlock.SetItemBlockSelectState(true);
			this.InSelectItemBlock.SetUiParent(this.DragRoot);
			this.PanelModel.RefreshPanel(false);
		}

		// Token: 0x060421D6 RID: 270806 RVA: 0x010F730C File Offset: 0x010F550C
		public void RotateClick()
		{
			this.InSelectItemBlock.RotateBlock();
			this.PanelModel.RefreshPanel(false);
			this.TryHandleRotateFail();
			string sequenceName = this.PanelModel.IsSetFail ? "Fail" : "Success";
			this.PlaySelectItemBlockGridSequence(sequenceName);
		}

		// Token: 0x060421D7 RID: 270807 RVA: 0x010F7357 File Offset: 0x010F5557
		public bool CanConfirm()
		{
			return this.ConfirmBtn.IsSelfInteractive;
		}

		// Token: 0x060421D8 RID: 270808 RVA: 0x010F7364 File Offset: 0x010F5564
		public bool IsOverlap()
		{
			return this.OverlapMap.Count == 1;
		}

		// Token: 0x060421D9 RID: 270809 RVA: 0x010F7374 File Offset: 0x010F5574
		public void HandleOverlapConfirm()
		{
			this.PanelModel.IsInSelectState = false;
			this.InSelectItemBlock.SetItemBlockSelectState(false);
			this.InSelectItemBlock.SetUiParent(this.AttachItem);
			this.InSelectItemBlock.PlaySelectSequence("PutIn");
			this.PlaySelectItemBlockGridSequence("PutIn");
			this.RefreshBackpackGridState(this.InSelectItemBlock);
			int key = this.OverlapMap.Keys.First<int>();
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.OverlapMap[key])
			{
				dockyardBackpackGrid.SetItemBlockId(this.PanelModel.InSelectedBlockId);
			}
			this.PanelModel.OnItemBlockClick(this.OverlapMap.Keys.First<int>());
			this.InSelectItemBlock.PlaySelectSequence("Grab");
			this.SetButtonsState(true);
			this.TryRefreshQuicklySellPanel();
		}

		// Token: 0x060421DA RID: 270810 RVA: 0x010F7470 File Offset: 0x010F5670
		public void HandleFinishConfirm()
		{
			this.PanelModel.IsInSelectState = false;
			this.InSelectItemBlock.SetItemBlockSelectState(false);
			this.InSelectItemBlock.SetUiParent(this.AttachItem);
			this.InSelectItemBlock.PlaySelectSequence("PutIn");
			this.PlaySelectItemBlockGridSequence("PutIn");
			this.RefreshBackpackGridState(this.InSelectItemBlock);
			this.PanelModel.InSelectedBlockId = -1;
			this.InSelectItemBlock = null;
			this.TryRefreshQuicklySellPanel();
		}

		// Token: 0x060421DB RID: 270811 RVA: 0x010F74E8 File Offset: 0x010F56E8
		public List<FishingItemInfo> GetItemBlockDataList()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			foreach (DockyardItemBlock dockyardItemBlock in this.ItemBlockMap.Values)
			{
				DockyardItemBlockData data = dockyardItemBlock.GetData();
				FishingItemInfo item = DockyardPanelUtil.CreateFishingItemInfo(data.Data, data.Rotate, data.LeftTopPosInPanel);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060421DC RID: 270812 RVA: 0x010F7564 File Offset: 0x010F5764
		[NullableContext(2)]
		public DockyardItemBlockOriginalData GetOriginalItemBlockDataByIncId(int incId)
		{
			foreach (DockyardItemBlock dockyardItemBlock in this.ItemBlockMap.Values)
			{
				DockyardItemBlockData data = dockyardItemBlock.GetData();
				if (data.Data.IncId == incId)
				{
					return data.Data;
				}
			}
			return null;
		}

		// Token: 0x060421DD RID: 270813 RVA: 0x010F75D4 File Offset: 0x010F57D4
		public List<FishingItemInfo> GetItemBlockDataListExcludeSelected()
		{
			List<FishingItemInfo> list = new List<FishingItemInfo>();
			foreach (DockyardItemBlock dockyardItemBlock in this.ItemBlockMap.Values)
			{
				if (dockyardItemBlock.GetData().Data.IncId != this.PanelModel.InSelectedBlockId)
				{
					DockyardItemBlockData data = dockyardItemBlock.GetData();
					FishingItemInfo item = DockyardPanelUtil.CreateFishingItemInfo(data.Data, data.Rotate, data.LeftTopPosInPanel);
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x060421DE RID: 270814 RVA: 0x010F7674 File Offset: 0x010F5874
		public List<int> GetQuicklySellItemIdList()
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int key in this.PanelModel.TempQuicklySellIncIdSet)
			{
				DockyardItemBlock valueOrDefault = this.ItemBlockMap.GetValueOrDefault(key);
				if (valueOrDefault != null)
				{
					hashSet.Add(valueOrDefault.GetItemId());
				}
			}
			return hashSet.ToList<int>();
		}

		// Token: 0x060421DF RID: 270815 RVA: 0x010F76F0 File Offset: 0x010F58F0
		public void SetConfirmInteractive(bool isInteractive)
		{
			if (this.ConfirmInteractive == isInteractive)
			{
				return;
			}
			this.ConfirmInteractive = isInteractive;
			this.ConfirmBtn.SetSelfInteractive(isInteractive);
		}

		// Token: 0x060421E0 RID: 270816 RVA: 0x010F770F File Offset: 0x010F590F
		public void SetConfirmNiagaraActive(bool active)
		{
			base.GetItem(15).SetUIActive(active);
		}

		// Token: 0x060421E1 RID: 270817 RVA: 0x010F7720 File Offset: 0x010F5920
		private void ItemBlockMove(float delta)
		{
			bool flag = Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(0);
			bool flag2 = Singleton<LguiEventSystemManager>.Instance.IsNowTriggerPressed(0);
			if (!flag && !flag2)
			{
				DockyardItemBlock inSelectItemBlock = this.InSelectItemBlock;
				if (inSelectItemBlock != null)
				{
					inSelectItemBlock.OnDragEnd(null);
				}
				this.RemoveItemDragTick();
				return;
			}
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, true);
			DockyardItemBlock inSelectItemBlock2 = this.InSelectItemBlock;
			if (inSelectItemBlock2 == null)
			{
				return;
			}
			inSelectItemBlock2.OnDrag(pointerEventData);
		}

		// Token: 0x060421E2 RID: 270818 RVA: 0x010F7780 File Offset: 0x010F5980
		private void AddItemDragTick()
		{
			this.RemoveItemDragTick();
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.ItemBlockMove), "CheckItemBlockMove", ETickingGroup.TG_PrePhysics, true, 0, true);
			this.ListDragTick = ((ticker != null) ? ticker.Id : -1);
		}

		// Token: 0x060421E3 RID: 270819 RVA: 0x010F77B9 File Offset: 0x010F59B9
		private void RemoveItemDragTick()
		{
			if (this.ListDragTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.ListDragTick);
				this.ListDragTick = -1;
			}
		}

		// Token: 0x060421E4 RID: 270820 RVA: 0x010F77DC File Offset: 0x010F59DC
		public void DestroyItemBlockById(int id)
		{
			DockyardItemBlock dockyardItemBlock = this.ItemBlockMap[id];
			this.ResetBackpackGridShowType(dockyardItemBlock.GetData().PanelRange, id);
			this.ItemBlockMap.Remove(id);
			this.PanelModel.BackpackData.DeleteItemBlockData(id);
			dockyardItemBlock.Destroy(null);
		}

		// Token: 0x060421E5 RID: 270821 RVA: 0x010F7830 File Offset: 0x010F5A30
		public void DestroySelectItemBlock()
		{
			this.ResetBackpackGridShowType(this.LastLeftTopPos, this.PanelModel.InSelectedBlockId);
			this.PanelModel.IsInSelectState = false;
			this.ItemBlockMap.Remove(this.PanelModel.InSelectedBlockId);
			this.PanelModel.BackpackData.DeleteItemBlockData(this.PanelModel.InSelectedBlockId);
			DockyardItemBlock inSelectItemBlock = this.InSelectItemBlock;
			if (inSelectItemBlock != null)
			{
				inSelectItemBlock.Destroy(null);
			}
			this.PanelModel.InSelectedBlockId = -1;
			this.InSelectItemBlock = null;
		}

		// Token: 0x060421E6 RID: 270822 RVA: 0x010F78B8 File Offset: 0x010F5AB8
		public UniTask CreateItemBlockByView(DockyardItemBlockOriginalData itemData)
		{
			DockyardBackpackPanel.<CreateItemBlockByView>d__80 <CreateItemBlockByView>d__;
			<CreateItemBlockByView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateItemBlockByView>d__.<>4__this = this;
			<CreateItemBlockByView>d__.itemData = itemData;
			<CreateItemBlockByView>d__.<>1__state = -1;
			<CreateItemBlockByView>d__.<>t__builder.Start<DockyardBackpackPanel.<CreateItemBlockByView>d__80>(ref <CreateItemBlockByView>d__);
			return <CreateItemBlockByView>d__.<>t__builder.Task;
		}

		// Token: 0x060421E7 RID: 270823 RVA: 0x010F7904 File Offset: 0x010F5B04
		public UniTask CreateItemBlockByViewAndFollow(DockyardItemBlockOriginalData itemData)
		{
			DockyardBackpackPanel.<CreateItemBlockByViewAndFollow>d__81 <CreateItemBlockByViewAndFollow>d__;
			<CreateItemBlockByViewAndFollow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateItemBlockByViewAndFollow>d__.<>4__this = this;
			<CreateItemBlockByViewAndFollow>d__.itemData = itemData;
			<CreateItemBlockByViewAndFollow>d__.<>1__state = -1;
			<CreateItemBlockByViewAndFollow>d__.<>t__builder.Start<DockyardBackpackPanel.<CreateItemBlockByViewAndFollow>d__81>(ref <CreateItemBlockByViewAndFollow>d__);
			return <CreateItemBlockByViewAndFollow>d__.<>t__builder.Task;
		}

		// Token: 0x060421E8 RID: 270824 RVA: 0x010F794F File Offset: 0x010F5B4F
		public bool IsWareHouseDragToBackpack()
		{
			return this.ListDragTick != -1;
		}

		// Token: 0x060421E9 RID: 270825 RVA: 0x010F7960 File Offset: 0x010F5B60
		public void ReplaceSelectItemBlock(DockyardItemBlockOriginalData itemData)
		{
			this.PanelModel.IsInSelectState = false;
			this.PanelModel.BackpackData.DeleteItemBlockData(this.PanelModel.InSelectedBlockId);
			this.ItemBlockMap.Remove(this.PanelModel.InSelectedBlockId);
			this.PanelModel.BackpackData.AddItemBlockData(itemData);
			this.ItemBlockMap.Add(itemData.IncId, this.InSelectItemBlock);
			DockyardItemBlock inSelectItemBlock = this.InSelectItemBlock;
			if (inSelectItemBlock != null)
			{
				inSelectItemBlock.GetData().RefreshData(itemData);
			}
			DockyardBackpackPanelModelBase panelModel = this.PanelModel;
			if (panelModel == null)
			{
				return;
			}
			panelModel.OnItemBlockClick(itemData.IncId);
		}

		// Token: 0x060421EA RID: 270826 RVA: 0x010F7A04 File Offset: 0x010F5C04
		private UniTask InitQuicklySellPanel()
		{
			DockyardBackpackPanel.<InitQuicklySellPanel>d__86 <InitQuicklySellPanel>d__;
			<InitQuicklySellPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitQuicklySellPanel>d__.<>4__this = this;
			<InitQuicklySellPanel>d__.<>1__state = -1;
			<InitQuicklySellPanel>d__.<>t__builder.Start<DockyardBackpackPanel.<InitQuicklySellPanel>d__86>(ref <InitQuicklySellPanel>d__);
			return <InitQuicklySellPanel>d__.<>t__builder.Task;
		}

		// Token: 0x060421EB RID: 270827 RVA: 0x010F7A48 File Offset: 0x010F5C48
		public void ShowQuicklySellPanel()
		{
			HashSet<int> failIncIdSet = this.RefreshQuicklySellPanel();
			this.RefreshQuicklySellGridState(failIncIdSet);
			DockyardQuicklySellPanel quicklySellPanel = this.QuicklySellPanel;
			if (quicklySellPanel == null)
			{
				return;
			}
			quicklySellPanel.SetPanelVisible(true);
		}

		// Token: 0x060421EC RID: 270828 RVA: 0x010F7A74 File Offset: 0x010F5C74
		public void HideQuicklySellPanel()
		{
			this.ResetQuicklySellGridState();
			DockyardQuicklySellPanel quicklySellPanel = this.QuicklySellPanel;
			if (quicklySellPanel == null)
			{
				return;
			}
			quicklySellPanel.SetPanelVisible(false);
		}

		// Token: 0x060421ED RID: 270829 RVA: 0x010F7A8D File Offset: 0x010F5C8D
		public void CloseQuicklySellPanel()
		{
			this.PanelModel.RefreshBackpackQuicklySellData();
			this.ResetQuicklySellGridState();
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			}
			this.SetQuickSellToggleState();
			this.SetQuicklySellRedDotState(false);
		}

		// Token: 0x060421EE RID: 270830 RVA: 0x010F7AC4 File Offset: 0x010F5CC4
		private HashSet<int> RefreshQuicklySellPanel()
		{
			if (this.QuicklySellPanel == null)
			{
				return new HashSet<int>();
			}
			this.PanelModel.TempQuicklySellType = EBackpackQuicklySellType.Full;
			this.PanelModel.TempQuicklySellIncIdSet.Clear();
			HashSet<int> hashSet = new HashSet<int>();
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.Layout.GetLayoutItemList())
			{
				int itemBlockId = dockyardBackpackGrid.GetItemBlockId();
				if (dockyardBackpackGrid.IsQuicklySell())
				{
					if (itemBlockId == -1)
					{
						this.PanelModel.TempQuicklySellType = EBackpackQuicklySellType.RangeError;
					}
					else
					{
						this.PanelModel.TempQuicklySellIncIdSet.Add(itemBlockId);
						if (this.PanelModel.TempQuicklySellType == EBackpackQuicklySellType.Full && !this.ItemBlockMap[itemBlockId].GetData().Data.IsCanSell)
						{
							this.PanelModel.TempQuicklySellType = EBackpackQuicklySellType.ItemError;
							hashSet.Add(itemBlockId);
						}
					}
				}
			}
			if (!this.PanelModel.IsInSelectState)
			{
				int allSellPrice = this.GetAllSellPrice(hashSet);
				DockyardQuicklySellPanel quicklySellPanel = this.QuicklySellPanel;
				if (quicklySellPanel != null)
				{
					quicklySellPanel.RefreshPanel(allSellPrice, this.PanelModel.TempQuicklySellType);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Dockyard;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "快速出售总价格";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("allSellPrice", allSellPrice);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.SetQuicklySellRedDotState(this.PanelModel.TempQuicklySellType == EBackpackQuicklySellType.Full);
			return hashSet;
		}

		// Token: 0x060421EF RID: 270831 RVA: 0x010F7C30 File Offset: 0x010F5E30
		private int GetAllSellPrice(HashSet<int> failIncIdSet)
		{
			int num = 0;
			foreach (int num2 in this.PanelModel.TempQuicklySellIncIdSet)
			{
				if (!failIncIdSet.Contains(num2))
				{
					int price = this.ItemBlockMap[num2].GetData().Data.Price;
					num += price;
				}
			}
			float quicklySellRatio = ModelBase<DockyardModel>.Instance.GetQuicklySellRatio();
			num += (int)Math.Floor((double)((float)num * quicklySellRatio) / 100.0);
			return num;
		}

		// Token: 0x060421F0 RID: 270832 RVA: 0x010F7CD4 File Offset: 0x010F5ED4
		private void RefreshQuicklySellGridState(HashSet<int> failIncIdSet)
		{
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.QuicklySellGridSet)
			{
				int itemBlockId = dockyardBackpackGrid.GetItemBlockId();
				if (failIncIdSet.Contains(itemBlockId) || itemBlockId == -1)
				{
					dockyardBackpackGrid.RefreshQuicklySell(EFishingQuicklySellType.QuicklySellFailure);
				}
				else
				{
					dockyardBackpackGrid.RefreshQuicklySell(EFishingQuicklySellType.QuicklySellSuccess);
				}
			}
		}

		// Token: 0x060421F1 RID: 270833 RVA: 0x010F7D44 File Offset: 0x010F5F44
		private void ResetQuicklySellGridState()
		{
			foreach (DockyardBackpackGrid dockyardBackpackGrid in this.QuicklySellGridSet)
			{
				dockyardBackpackGrid.ResetQuicklySell();
			}
		}

		// Token: 0x060421F2 RID: 270834 RVA: 0x010F7D94 File Offset: 0x010F5F94
		private void TryRefreshQuicklySellPanel()
		{
			if (!this.PanelModel.IsQuickSellOpen())
			{
				return;
			}
			HashSet<int> failIncIdSet = this.RefreshQuicklySellPanel();
			DockyardQuicklySellPanel quicklySellPanel = this.QuicklySellPanel;
			if (quicklySellPanel == null || !quicklySellPanel.IsShowOrShowing)
			{
				return;
			}
			this.RefreshQuicklySellGridState(failIncIdSet);
		}

		// Token: 0x04024D85 RID: 150917
		[Nullable(2)]
		public DockyardItemBlock InSelectItemBlock;

		// Token: 0x04024D86 RID: 150918
		private readonly Dictionary<int, List<DockyardBackpackGrid>> OverlapMap = new Dictionary<int, List<DockyardBackpackGrid>>();

		// Token: 0x04024D87 RID: 150919
		private readonly HashSet<DockyardBackpackGrid> SelectItemBlockGridSet = new HashSet<DockyardBackpackGrid>();

		// Token: 0x04024D88 RID: 150920
		private readonly HashSet<int> UnValidGridOverlapSet = new HashSet<int>();

		// Token: 0x04024D89 RID: 150921
		protected GenericLayout<DockyardBackpackGrid, IPanelPos> Layout;

		// Token: 0x04024D8A RID: 150922
		protected Dictionary<int, DockyardItemBlock> ItemBlockMap = new Dictionary<int, DockyardItemBlock>();

		// Token: 0x04024D8B RID: 150923
		private int TickId = -1;

		// Token: 0x04024D8C RID: 150924
		public readonly DockyardBackpackPanelModelBase PanelModel;

		// Token: 0x04024D8D RID: 150925
		private UUIButtonComponent ConfirmBtn;

		// Token: 0x04024D8E RID: 150926
		private bool ConfirmInteractive;

		// Token: 0x04024D8F RID: 150927
		private UUIItem AttachItem;

		// Token: 0x04024D90 RID: 150928
		public UUIItem DragRoot;

		// Token: 0x04024D91 RID: 150929
		private UUIItem GridItem;

		// Token: 0x04024D92 RID: 150930
		private int ListDragTick = -1;

		// Token: 0x04024D93 RID: 150931
		private IPanelPosRange LastLeftTopPos = new PanelPosRange
		{
			RowStartIndex = -1,
			RowEndIndex = -1,
			ColStartIndex = -1,
			ColEndIndex = -1
		};

		// Token: 0x04024D94 RID: 150932
		private readonly IPanelPosRange AppropriatePos = new PanelPosRange
		{
			RowStartIndex = -1,
			RowEndIndex = -1,
			ColStartIndex = -1,
			ColEndIndex = -1
		};

		// Token: 0x04024D95 RID: 150933
		private DockyardBackpackPanel.ButtonSequencePlayer Sell;

		// Token: 0x04024D96 RID: 150934
		private DockyardBackpackPanel.ButtonSequencePlayer Trawl;

		// Token: 0x04024D97 RID: 150935
		private DockyardBackpackPanel.ButtonSequencePlayer Delete;

		// Token: 0x04024D98 RID: 150936
		private DockyardBackpackPanel.ButtonSequencePlayer Rotate;

		// Token: 0x04024D99 RID: 150937
		private DockyardBackpackPanel.ButtonSequencePlayer Confirm;

		// Token: 0x04024D9A RID: 150938
		private DockyardBackpackPanel.ButtonSequencePlayer AllSell;

		// Token: 0x04024D9B RID: 150939
		private DockyardBackpackPanel.ButtonSequencePlayer BackToWareHouse;

		// Token: 0x04024D9C RID: 150940
		[Nullable(2)]
		protected DockyardQuicklySellPanel QuicklySellPanel;

		// Token: 0x04024D9D RID: 150941
		private readonly HashSet<DockyardBackpackGrid> QuicklySellGridSet = new HashSet<DockyardBackpackGrid>();

		// Token: 0x0200C7B6 RID: 51126
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D7AF RID: 251823
			public const int Title = 0;

			// Token: 0x0403D7B0 RID: 251824
			public const int Layout = 1;

			// Token: 0x0403D7B1 RID: 251825
			public const int GridItem = 2;

			// Token: 0x0403D7B2 RID: 251826
			public const int DragRoot = 3;

			// Token: 0x0403D7B3 RID: 251827
			public const int SellToggle = 4;

			// Token: 0x0403D7B4 RID: 251828
			public const int TrawlToggle = 5;

			// Token: 0x0403D7B5 RID: 251829
			public const int DeleteBtn = 6;

			// Token: 0x0403D7B6 RID: 251830
			public const int RotateBtn = 7;

			// Token: 0x0403D7B7 RID: 251831
			public const int ConfirmBtn = 8;

			// Token: 0x0403D7B8 RID: 251832
			public const int ItemRoot = 9;

			// Token: 0x0403D7B9 RID: 251833
			public const int AllSellBtn = 10;

			// Token: 0x0403D7BA RID: 251834
			public const int BackToWareHouseBtn = 11;

			// Token: 0x0403D7BB RID: 251835
			public const int TrawlRedDot = 12;

			// Token: 0x0403D7BC RID: 251836
			public const int MaskBtn = 13;

			// Token: 0x0403D7BD RID: 251837
			public const int QuickSellNiagara = 14;

			// Token: 0x0403D7BE RID: 251838
			public const int ConfirmNiagara = 15;

			// Token: 0x0403D7BF RID: 251839
			public const int BottomBtnParent = 16;
		}

		// Token: 0x0200C7B7 RID: 51127
		[Nullable(0)]
		private class ButtonSequencePlayer
		{
			// Token: 0x0604EFB2 RID: 323506 RVA: 0x015FA8CA File Offset: 0x015F8ACA
			public ButtonSequencePlayer(UUIItem uiItem)
			{
				this.UiItem = uiItem;
				this.SequencePlayer = new UiSequencePlayer(this.UiItem);
			}

			// Token: 0x0604EFB3 RID: 323507 RVA: 0x015FA8EA File Offset: 0x015F8AEA
			public void SetActive(bool active)
			{
				this.UiItem.SetUIActive(active);
				if (active)
				{
					this.SequencePlayer.PlaySequencePurely("Show", false, false);
				}
			}

			// Token: 0x0604EFB4 RID: 323508 RVA: 0x015FA90D File Offset: 0x015F8B0D
			public void Clear()
			{
				this.SequencePlayer.Clear();
			}

			// Token: 0x0403D7C0 RID: 251840
			private readonly UiSequencePlayer SequencePlayer;

			// Token: 0x0403D7C1 RID: 251841
			private readonly UUIItem UiItem;
		}
	}
}
