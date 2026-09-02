using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B0 RID: 26544
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractPanelModel
	{
		// Token: 0x1700A0FF RID: 41215
		// (get) Token: 0x0604231E RID: 271134 RVA: 0x010FB21C File Offset: 0x010F941C
		[Nullable(2)]
		public DockyardItemBlock InSelectItemBlock
		{
			[NullableContext(2)]
			get
			{
				return this.BackpackPanelModel.Panel.InSelectItemBlock;
			}
		}

		// Token: 0x0604231F RID: 271135 RVA: 0x010FB230 File Offset: 0x010F9430
		private void InitGridData()
		{
			for (int i = 0; i < 3; i++)
			{
				this.PosDataDoublyList.Add(new List<IPanelPos>());
				for (int j = 0; j < 6; j++)
				{
					DockyardInteractPanelModel.PanelPos panelPos = new DockyardInteractPanelModel.PanelPos
					{
						RowIndex = i,
						ColIndex = j
					};
					DockyardInteractGridData value = new DockyardInteractGridData(panelPos);
					this.PosDataList.Add(panelPos);
					this.PosDataDoublyList[i].Add(panelPos);
					this.GridDataMap.Add(panelPos, value);
				}
			}
		}

		// Token: 0x06042320 RID: 271136 RVA: 0x010FB2AB File Offset: 0x010F94AB
		private DockyardInteractItemBlockData CreateItemBlock(DockyardItemBlockOriginalData data, int rowIndex, int colIndex, int rotate)
		{
			return new DockyardInteractItemBlockData(data)
			{
				Pos = 
				{
					RowIndex = rowIndex,
					ColIndex = colIndex
				},
				Rotate = rotate
			};
		}

		// Token: 0x06042321 RID: 271137 RVA: 0x010FB2D4 File Offset: 0x010F94D4
		private void InitShowItemMap()
		{
			Dictionary<int, DockyardItemBlockOriginalData> dataMapByInteract = ModelBase<FishingModel>.Instance.GetDataMapByInteract(this.ConfigId);
			if (dataMapByInteract != null)
			{
				foreach (KeyValuePair<int, DockyardItemBlockOriginalData> keyValuePair in dataMapByInteract)
				{
					DockyardInteractItemBlockData value = this.CreateItemBlock(keyValuePair.Value, keyValuePair.Value.PosY, keyValuePair.Value.PosX, (int)keyValuePair.Value.Rotate);
					this.ShowItemMap.Add(keyValuePair.Key, value);
				}
			}
		}

		// Token: 0x06042322 RID: 271138 RVA: 0x010FB374 File Offset: 0x010F9574
		public void InitPanel(DockyardInteractPanel panel)
		{
			this.Panel = panel;
			this.InitShowItemMap();
			this.InitGridData();
		}

		// Token: 0x06042323 RID: 271139 RVA: 0x010FB389 File Offset: 0x010F9589
		public void RegisterViewModel(DockyardInteractViewModel viewModel)
		{
			this.ViewModel = viewModel;
		}

		// Token: 0x06042324 RID: 271140 RVA: 0x010FB392 File Offset: 0x010F9592
		public void RegisterBackpackPanel(DockyardBackpackPanelModelBase backpackPanel)
		{
			this.BackpackPanelModel = (DockyardInteractBackpackPanelModel)backpackPanel;
		}

		// Token: 0x06042325 RID: 271141 RVA: 0x010FB3A0 File Offset: 0x010F95A0
		public DockyardInteractGridData GetInteractGridData(IPanelPos pos)
		{
			return this.GridDataMap[pos];
		}

		// Token: 0x06042326 RID: 271142 RVA: 0x010FB3AE File Offset: 0x010F95AE
		public IPanelPos GetInteractPosByPos(int rowIndex, int colIndex)
		{
			return this.PosDataDoublyList[rowIndex][colIndex];
		}

		// Token: 0x06042327 RID: 271143 RVA: 0x010FB3C4 File Offset: 0x010F95C4
		public void Tick(float deltaTime)
		{
			if (!this.BackpackPanelModel.IsOutOfRange)
			{
				if (this.LastCanTickState)
				{
					this.Panel.ResetLastBackpackGridShowType();
				}
				this.LastCanTickState = false;
				return;
			}
			DockyardItemBlock inSelectItemBlock = this.InSelectItemBlock;
			if (inSelectItemBlock == null || !inSelectItemBlock.IsItemBlockInPanel(this.Panel.AttachItem))
			{
				if (this.LastCanTickState)
				{
					this.Panel.ResetLastBackpackGridShowType();
				}
				this.IsOutOfRange = true;
				this.LastCanTickState = false;
				return;
			}
			this.Panel.RefreshAllBackpackGridState(this.LastCanTickState == this.BackpackPanelModel.IsOutOfRange);
			this.LastCanTickState = this.BackpackPanelModel.IsOutOfRange;
		}

		// Token: 0x06042328 RID: 271144 RVA: 0x010FB46C File Offset: 0x010F966C
		public bool CanConfirm()
		{
			return this.IsAllMatch;
		}

		// Token: 0x06042329 RID: 271145 RVA: 0x010FB474 File Offset: 0x010F9674
		public bool IsOverlap()
		{
			return this.IsOverlapAnother;
		}

		// Token: 0x0604232A RID: 271146 RVA: 0x010FB47C File Offset: 0x010F967C
		public void DragClick(DockyardItemBlockOriginalData oldData, IPanelPos startPos)
		{
			if (!this.CanClick(oldData.IncId))
			{
				return;
			}
			this.LastCanTickState = true;
			this.Panel.InitAppropriatePos(oldData);
			this.ShowItemMap.Remove(oldData.IncId);
			this.Panel.DisableInteractItemBlock(oldData, startPos);
			DockyardItemBlockOriginalData dataByInteract = ModelBase<FishingModel>.Instance.GetDataByInteract(this.ConfigId, oldData.IncId);
			this.BackpackPanelModel.WareHouseItemDragBegin(dataByInteract);
		}

		// Token: 0x0604232B RID: 271147 RVA: 0x010FB4F0 File Offset: 0x010F96F0
		public void DragBegin(DockyardItemBlockOriginalData oldData, IPanelPos startPos)
		{
			if (!this.CanClick(oldData.IncId))
			{
				return;
			}
			this.LastCanTickState = true;
			this.Panel.InitAppropriatePos(oldData);
			this.ShowItemMap.Remove(oldData.IncId);
			DockyardInteractViewModel viewModel = this.ViewModel;
			if (viewModel != null)
			{
				viewModel.HandleDragBegin();
			}
			this.Panel.DisableInteractItemBlock(oldData, startPos);
			DockyardItemBlockOriginalData dataByInteract = ModelBase<FishingModel>.Instance.GetDataByInteract(this.ConfigId, oldData.IncId);
			this.BackpackPanelModel.WareHouseItemDragBegin(dataByInteract);
		}

		// Token: 0x0604232C RID: 271148 RVA: 0x010FB574 File Offset: 0x010F9774
		public void ChangeShowItemData()
		{
			DockyardItemBlockData data = this.InSelectItemBlock.GetData();
			DockyardItemBlockOriginalData data2 = data.Data;
			DockyardInteractItemBlockData oldData = this.GetOldData(data2.ItemId, (int)data.Rotate);
			DockyardInteractItemBlockData value = this.CreateItemBlock(data2, this.MatchPos.RowIndex, this.MatchPos.ColIndex, (int)data.Rotate);
			this.ShowItemMap.Add(data2.IncId, value);
			this.Panel.EnableInteractItemBlock(data2);
			if (oldData != null)
			{
				this.BackpackPanelModel.Panel.ReplaceSelectItemBlock(oldData.Data);
				this.ShowItemMap.Remove(oldData.Data.IncId);
			}
		}

		// Token: 0x0604232D RID: 271149 RVA: 0x010FB619 File Offset: 0x010F9819
		public void ShowScrollingTips()
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_MatchFail", Array.Empty<object>());
		}

		// Token: 0x0604232E RID: 271150 RVA: 0x010FB630 File Offset: 0x010F9830
		[NullableContext(2)]
		private DockyardInteractItemBlockData GetOldData(int itemId, int rotateType)
		{
			foreach (DockyardInteractItemBlockData dockyardInteractItemBlockData in this.ShowItemMap.Values)
			{
				if (dockyardInteractItemBlockData.Data.ItemId == itemId && dockyardInteractItemBlockData.Pos.ColIndex == this.MatchPos.ColIndex && dockyardInteractItemBlockData.Pos.RowIndex == this.MatchPos.RowIndex && rotateType == dockyardInteractItemBlockData.Rotate)
				{
					return dockyardInteractItemBlockData;
				}
			}
			return null;
		}

		// Token: 0x0604232F RID: 271151 RVA: 0x010FB6D0 File Offset: 0x010F98D0
		private bool CanClick(int id)
		{
			return this.BackpackPanelModel.IsWareHouseItemCanClick(id);
		}

		// Token: 0x04024DF9 RID: 151033
		public int ConfigId;

		// Token: 0x04024DFA RID: 151034
		public DockyardInteractPanel Panel;

		// Token: 0x04024DFB RID: 151035
		public bool IsOutOfRange = true;

		// Token: 0x04024DFC RID: 151036
		public bool IsAllMatch;

		// Token: 0x04024DFD RID: 151037
		public bool IsOverlapAnother;

		// Token: 0x04024DFE RID: 151038
		private readonly List<List<IPanelPos>> PosDataDoublyList = new List<List<IPanelPos>>();

		// Token: 0x04024DFF RID: 151039
		public readonly List<IPanelPos> PosDataList = new List<IPanelPos>();

		// Token: 0x04024E00 RID: 151040
		private readonly Dictionary<IPanelPos, DockyardInteractGridData> GridDataMap = new Dictionary<IPanelPos, DockyardInteractGridData>();

		// Token: 0x04024E01 RID: 151041
		public bool LastCanTickState;

		// Token: 0x04024E02 RID: 151042
		[Nullable(2)]
		protected DockyardInteractViewModel ViewModel;

		// Token: 0x04024E03 RID: 151043
		public DockyardInteractBackpackPanelModel BackpackPanelModel;

		// Token: 0x04024E04 RID: 151044
		public Dictionary<int, DockyardInteractItemBlockData> ShowItemMap = new Dictionary<int, DockyardInteractItemBlockData>();

		// Token: 0x04024E05 RID: 151045
		public IPanelPos MatchPos = new DockyardInteractPanelModel.PanelPos
		{
			RowIndex = -1,
			ColIndex = -1
		};

		// Token: 0x0200C7D6 RID: 51158
		[NullableContext(0)]
		private class PanelPos : IPanelPos
		{
			// Token: 0x1700AA61 RID: 43617
			// (get) Token: 0x0604EFEE RID: 323566 RVA: 0x015FC83E File Offset: 0x015FAA3E
			// (set) Token: 0x0604EFEF RID: 323567 RVA: 0x015FC846 File Offset: 0x015FAA46
			public int RowIndex { get; set; }

			// Token: 0x1700AA62 RID: 43618
			// (get) Token: 0x0604EFF0 RID: 323568 RVA: 0x015FC84F File Offset: 0x015FAA4F
			// (set) Token: 0x0604EFF1 RID: 323569 RVA: 0x015FC857 File Offset: 0x015FAA57
			public int ColIndex { get; set; }
		}
	}
}
