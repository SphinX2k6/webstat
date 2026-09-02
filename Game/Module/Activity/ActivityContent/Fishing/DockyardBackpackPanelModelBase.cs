using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006797 RID: 26519
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class DockyardBackpackPanelModelBase : IDockyardGridInterface, IDockyardWareHouseInterface
	{
		// Token: 0x1700A0DA RID: 41178
		// (get) Token: 0x060421FC RID: 270844 RVA: 0x010F7ED0 File Offset: 0x010F60D0
		// (set) Token: 0x060421FD RID: 270845 RVA: 0x010F7ED8 File Offset: 0x010F60D8
		public bool IsInSelectState
		{
			get
			{
				return this.IsInSelectStateInternal;
			}
			set
			{
				this.IsInSelectStateInternal = value;
				this.Panel.SetAllSellBtnState(value);
				this.Panel.SetItemBlockTextureMaskActive(value);
				IDockyardBackpackInterface viewModel = this.ViewModel;
				if (viewModel != null)
				{
					viewModel.SetInSelectState(value);
				}
				if (!value)
				{
					this.Panel.SetButtonsState(false);
				}
			}
		}

		// Token: 0x1700A0DB RID: 41179
		// (get) Token: 0x060421FE RID: 270846 RVA: 0x010F7F25 File Offset: 0x010F6125
		public bool IsInHighlight
		{
			get
			{
				return !this.IsInCanConfirm;
			}
		}

		// Token: 0x1700A0DC RID: 41180
		// (get) Token: 0x060421FF RID: 270847 RVA: 0x010F7F30 File Offset: 0x010F6130
		public bool IsInCanConfirm
		{
			get
			{
				return !this.IsSetFail && !this.IsOverlap();
			}
		}

		// Token: 0x06042200 RID: 270848 RVA: 0x010F7F47 File Offset: 0x010F6147
		public DockyardBackpackPanelModelBase()
		{
			this.BackpackData = new DockyardBackpackData(this.IsQuickSellOpen());
		}

		// Token: 0x06042201 RID: 270849 RVA: 0x010F7F84 File Offset: 0x010F6184
		private void InitPreviewBackpackData()
		{
			foreach (IPanelPos key in this.BackpackData.GetBackpackDataList())
			{
				this.PreviewBackpackMap.Add(key, -1);
			}
		}

		// Token: 0x06042202 RID: 270850 RVA: 0x010F7FE4 File Offset: 0x010F61E4
		public void SetPreviewBackpackData(IPanelPos pos, int id)
		{
			this.PreviewBackpackMap[pos] = id;
		}

		// Token: 0x06042203 RID: 270851 RVA: 0x010F7FF3 File Offset: 0x010F61F3
		public int GetPreviewBackpackData(IPanelPos pos)
		{
			return this.PreviewBackpackMap[pos];
		}

		// Token: 0x06042204 RID: 270852 RVA: 0x010F8001 File Offset: 0x010F6201
		public void RefreshBackpackQuicklySellData()
		{
			this.BackpackData.RefreshQuicklySellOpen(this.IsQuickSellOpen());
		}

		// Token: 0x06042205 RID: 270853 RVA: 0x010F8014 File Offset: 0x010F6214
		public void InitPanel(DockyardBackpackPanel panel)
		{
			this.Panel = panel;
			this.InitPreviewBackpackData();
		}

		// Token: 0x06042206 RID: 270854 RVA: 0x010F8023 File Offset: 0x010F6223
		public void RegisterViewModel(IDockyardBackpackInterface viewModel)
		{
			this.ViewModel = viewModel;
		}

		// Token: 0x06042207 RID: 270855 RVA: 0x010F802C File Offset: 0x010F622C
		public void SetItemBlockToWareHouse(DockyardItemBlockOriginalData data)
		{
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.NotifyItemBlockToWareHouse(data);
		}

		// Token: 0x06042208 RID: 270856 RVA: 0x010F8040 File Offset: 0x010F6240
		public void QuicklySellClick()
		{
			if (this.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return;
			}
			List<int> quicklySellItemIdList = this.Panel.GetQuicklySellItemIdList();
			if (ModelBase<FishingQuestModel>.Instance.OnFishingItemSell(quicklySellItemIdList, this.IsInSelectState, new Action(this.RequestFinishingQuickSell)))
			{
				return;
			}
			this.RequestFinishingQuickSell();
		}

		// Token: 0x06042209 RID: 270857 RVA: 0x010F809C File Offset: 0x010F629C
		private void RequestFinishingQuickSell()
		{
			ControllerBase<FishingController>.Instance.RequestFishingQuickSell(delegate(bool isSuccess)
			{
				if (isSuccess)
				{
					this.Panel.CloseQuicklySellPanel();
					foreach (int id in this.TempQuicklySellIncIdSet)
					{
						this.Panel.DestroyItemBlockById(id);
					}
					this.TempQuicklySellIncIdSet.Clear();
				}
			});
		}

		// Token: 0x0604220A RID: 270858 RVA: 0x010F80B4 File Offset: 0x010F62B4
		public void OnSellClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				IDockyardBackpackInterface viewModel = this.ViewModel;
				if (viewModel != null)
				{
					viewModel.NotifyQuicklySellActive(true);
				}
				this.Panel.ShowQuicklySellPanel();
				return;
			}
			IDockyardBackpackInterface viewModel2 = this.ViewModel;
			if (viewModel2 != null)
			{
				viewModel2.NotifyQuicklySellActive(false);
			}
			this.Panel.HideQuicklySellPanel();
		}

		// Token: 0x0604220B RID: 270859 RVA: 0x010F8100 File Offset: 0x010F6300
		public void OnTrawlClick(EToggleState state)
		{
			if (this.IsInSelectState)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
				return;
			}
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.TrawlClick(state == EToggleState.ETT_Checked);
		}

		// Token: 0x0604220C RID: 270860 RVA: 0x010F8134 File Offset: 0x010F6334
		public void OnDeleteClick()
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10076))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOpen", Array.Empty<object>());
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DockyardDeleteItem);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				IDockyardBackpackInterface viewModel = this.ViewModel;
				if (viewModel == null)
				{
					return;
				}
				viewModel.DeleteClick();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0604220D RID: 270861 RVA: 0x010F8196 File Offset: 0x010F6396
		public void OnRotateClick()
		{
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.RotateClick();
		}

		// Token: 0x0604220E RID: 270862 RVA: 0x010F81A8 File Offset: 0x010F63A8
		public void OnConfirmClick()
		{
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.ConfirmClick();
		}

		// Token: 0x0604220F RID: 270863 RVA: 0x010F81BA File Offset: 0x010F63BA
		public void OnAllSellClick()
		{
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.AllSellClick();
		}

		// Token: 0x06042210 RID: 270864 RVA: 0x010F81CC File Offset: 0x010F63CC
		public void OnBackToWareHouseClick()
		{
			this.TrySetItemBlockBackToWareHouse().Forget<bool>();
		}

		// Token: 0x06042211 RID: 270865 RVA: 0x010F81D9 File Offset: 0x010F63D9
		public void OnMaskClick()
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SelectingQuit", Array.Empty<object>());
		}

		// Token: 0x06042212 RID: 270866 RVA: 0x010F81EF File Offset: 0x010F63EF
		public void BackpackTick(float deltaTime)
		{
			if (!this.IsInSelectState)
			{
				return;
			}
			if (!this.IsInDragState)
			{
				return;
			}
			if (this.InSelectedBlockId == -1)
			{
				return;
			}
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.BackpackTick(deltaTime);
		}

		// Token: 0x06042213 RID: 270867 RVA: 0x010F821E File Offset: 0x010F641E
		public void Tick()
		{
			this.RefreshPanel(true);
		}

		// Token: 0x06042214 RID: 270868 RVA: 0x010F8228 File Offset: 0x010F6428
		public void RefreshPanel(bool checkRangeChange = true)
		{
			this.Panel.RefreshAllBackpackGridState(checkRangeChange);
			IDockyardConfirmProvider dockyardConfirmProvider = (this.ViewModel is IDockyardConfirmProvider) ? (this.ViewModel as IDockyardConfirmProvider) : null;
			bool confirmInteractive = (dockyardConfirmProvider != null) ? dockyardConfirmProvider.IsConfirmInteractive() : (!this.IsSetFail);
			this.Panel.SetConfirmInteractive(confirmInteractive);
			bool confirmNiagaraActive = (dockyardConfirmProvider != null) ? dockyardConfirmProvider.IsConfirmNiagaraActive() : this.IsInCanConfirm;
			this.Panel.SetConfirmNiagaraActive(confirmNiagaraActive);
		}

		// Token: 0x06042215 RID: 270869 RVA: 0x010F829C File Offset: 0x010F649C
		public bool CanConfirm()
		{
			return this.Panel.CanConfirm();
		}

		// Token: 0x06042216 RID: 270870 RVA: 0x010F82A9 File Offset: 0x010F64A9
		public bool IsOverlap()
		{
			return this.Panel.IsOverlap();
		}

		// Token: 0x06042217 RID: 270871 RVA: 0x010F82B6 File Offset: 0x010F64B6
		[NullableContext(2)]
		public UUIItem GetQuicklySellPanelParentItem()
		{
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return null;
			}
			return viewModel.GetQuicklySellPanelParentItem();
		}

		// Token: 0x06042218 RID: 270872 RVA: 0x010F82C9 File Offset: 0x010F64C9
		public void OnItemBlockClick(int id)
		{
			if (this.IsInSelectState)
			{
				return;
			}
			this.Panel.ItemBlockClick(id);
			IDockyardBackpackInterface viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.ItemBlockClick(id);
		}

		// Token: 0x06042219 RID: 270873 RVA: 0x010F82F1 File Offset: 0x010F64F1
		public bool CanDrag(int id)
		{
			return this.Panel.CanDrag(id);
		}

		// Token: 0x0604221A RID: 270874 RVA: 0x010F82FF File Offset: 0x010F64FF
		public bool DragBegin(int id)
		{
			if (!this.IsInDragState)
			{
				this.IsInDragState = true;
				this.IsMoved = false;
				IDockyardBackpackInterface viewModel = this.ViewModel;
				if (viewModel != null)
				{
					viewModel.HandleDragBegin();
				}
				this.Panel.SetButtonsState(false);
				return true;
			}
			return false;
		}

		// Token: 0x0604221B RID: 270875 RVA: 0x010F8337 File Offset: 0x010F6537
		public bool DragEnd(int id)
		{
			if (this.IsInDragState)
			{
				this.IsInDragState = false;
				IDockyardBackpackInterface viewModel = this.ViewModel;
				if (viewModel != null)
				{
					viewModel.HandleDragResult();
				}
				return true;
			}
			return false;
		}

		// Token: 0x0604221C RID: 270876 RVA: 0x010F835C File Offset: 0x010F655C
		public void WareHouseItemClick(DockyardItemBlockOriginalData itemData)
		{
			this.Panel.CreateItemBlockByView(itemData).Forget();
		}

		// Token: 0x0604221D RID: 270877 RVA: 0x010F836F File Offset: 0x010F656F
		public void WareHouseItemDragBegin(DockyardItemBlockOriginalData itemData)
		{
			this.Panel.CreateItemBlockByViewAndFollow(itemData).Forget();
		}

		// Token: 0x0604221E RID: 270878 RVA: 0x010F8382 File Offset: 0x010F6582
		public bool IsWareHouseItemCanClick(int id)
		{
			return !this.IsInSelectState;
		}

		// Token: 0x0604221F RID: 270879 RVA: 0x010F838D File Offset: 0x010F658D
		public int GetSelectedId()
		{
			return this.InSelectedBlockId;
		}

		// Token: 0x06042220 RID: 270880 RVA: 0x010F8398 File Offset: 0x010F6598
		[NullableContext(0)]
		public UniTask<bool> TrySetItemBlockBackToWareHouse()
		{
			DockyardBackpackPanelModelBase.<TrySetItemBlockBackToWareHouse>d__52 <TrySetItemBlockBackToWareHouse>d__;
			<TrySetItemBlockBackToWareHouse>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySetItemBlockBackToWareHouse>d__.<>4__this = this;
			<TrySetItemBlockBackToWareHouse>d__.<>1__state = -1;
			<TrySetItemBlockBackToWareHouse>d__.<>t__builder.Start<DockyardBackpackPanelModelBase.<TrySetItemBlockBackToWareHouse>d__52>(ref <TrySetItemBlockBackToWareHouse>d__);
			return <TrySetItemBlockBackToWareHouse>d__.<>t__builder.Task;
		}

		// Token: 0x06042221 RID: 270881 RVA: 0x010F83DC File Offset: 0x010F65DC
		[NullableContext(0)]
		public UniTask<bool> TrySetSelectedItemBlockConfirm()
		{
			DockyardBackpackPanelModelBase.<TrySetSelectedItemBlockConfirm>d__53 <TrySetSelectedItemBlockConfirm>d__;
			<TrySetSelectedItemBlockConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySetSelectedItemBlockConfirm>d__.<>4__this = this;
			<TrySetSelectedItemBlockConfirm>d__.<>1__state = -1;
			<TrySetSelectedItemBlockConfirm>d__.<>t__builder.Start<DockyardBackpackPanelModelBase.<TrySetSelectedItemBlockConfirm>d__53>(ref <TrySetSelectedItemBlockConfirm>d__);
			return <TrySetSelectedItemBlockConfirm>d__.<>t__builder.Task;
		}

		// Token: 0x06042222 RID: 270882 RVA: 0x010F841F File Offset: 0x010F661F
		public virtual bool IsQuickSellOpen()
		{
			return !ModelBase<FishingModel>.Instance.IsInDock && ModelBase<DockyardModel>.Instance.IsQuicklySellOpen;
		}

		// Token: 0x06042223 RID: 270883 RVA: 0x010F8439 File Offset: 0x010F6639
		public virtual bool GetIsTrawlOpen()
		{
			return false;
		}

		// Token: 0x06042224 RID: 270884 RVA: 0x010F843C File Offset: 0x010F663C
		public virtual bool GetIsBackToWareHouseOpen()
		{
			return true;
		}

		// Token: 0x1700A0DD RID: 41181
		// (get) Token: 0x06042225 RID: 270885 RVA: 0x010F843F File Offset: 0x010F663F
		// (set) Token: 0x06042226 RID: 270886 RVA: 0x010F8447 File Offset: 0x010F6647
		public virtual bool IsAllSellOpen { get; set; }

		// Token: 0x1700A0DE RID: 41182
		// (get) Token: 0x06042227 RID: 270887 RVA: 0x010F8450 File Offset: 0x010F6650
		// (set) Token: 0x06042228 RID: 270888 RVA: 0x010F8458 File Offset: 0x010F6658
		public virtual bool IsDeleteOpen { get; set; } = true;

		// Token: 0x04024DA3 RID: 150947
		private bool IsInSelectStateInternal;

		// Token: 0x04024DA4 RID: 150948
		public int InSelectedBlockId = -1;

		// Token: 0x04024DA5 RID: 150949
		public bool IsInDragState;

		// Token: 0x04024DA6 RID: 150950
		public bool IsOutOfRange;

		// Token: 0x04024DA7 RID: 150951
		public bool IsSetFail;

		// Token: 0x04024DA8 RID: 150952
		public DockyardBackpackPanel Panel;

		// Token: 0x04024DA9 RID: 150953
		[Nullable(2)]
		protected IDockyardBackpackInterface ViewModel;

		// Token: 0x04024DAA RID: 150954
		protected Dictionary<IPanelPos, int> PreviewBackpackMap = new Dictionary<IPanelPos, int>();

		// Token: 0x04024DAB RID: 150955
		public EBackpackQuicklySellType TempQuicklySellType;

		// Token: 0x04024DAC RID: 150956
		public HashSet<int> TempQuicklySellIncIdSet = new HashSet<int>();

		// Token: 0x04024DAD RID: 150957
		public DockyardBackpackData BackpackData;

		// Token: 0x04024DAE RID: 150958
		public bool IsDragFail;

		// Token: 0x04024DAF RID: 150959
		public bool IsMoved;
	}
}
