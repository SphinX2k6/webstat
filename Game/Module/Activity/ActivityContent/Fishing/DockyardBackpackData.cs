using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006791 RID: 26513
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardBackpackData
	{
		// Token: 0x06042175 RID: 270709 RVA: 0x010F4F5C File Offset: 0x010F315C
		public DockyardBackpackData(bool isQuicklySellOpen)
		{
			this.InitQuicklySellData(isQuicklySellOpen);
			this.InitGridDataMap();
			this.InitItemBlockDataMap();
		}

		// Token: 0x06042176 RID: 270710 RVA: 0x010F4FB0 File Offset: 0x010F31B0
		private void InitQuicklySellData(bool isQuicklySellOpen)
		{
			if (isQuicklySellOpen)
			{
				int quicklySellId = ModelBase<DockyardModel>.Instance.GetQuicklySellId();
				if (quicklySellId > 0)
				{
					this.QuicklySellData = new DockyardQuicklySellData(quicklySellId);
				}
			}
		}

		// Token: 0x06042177 RID: 270711 RVA: 0x010F4FDC File Offset: 0x010F31DC
		private void InitGridDataMap()
		{
			int fishingCabinShape = ModelBase<DockyardModel>.Instance.FishingCabinShape;
			FishingGridItemShape fishingShapeConfig = ConfigBase<FishingConfig>.Instance.GetFishingShapeConfig(fishingCabinShape);
			for (int i = 0; i < 7; i++)
			{
				this.PosDataDoublyList.Add(new List<IPanelPos>());
				for (int j = 0; j < 8; j++)
				{
					PanelPos panelPos = new PanelPos
					{
						RowIndex = i,
						ColIndex = j
					};
					DockyardBackpackGridData dockyardBackpackGridData = new DockyardBackpackGridData(panelPos);
					DockyardQuicklySellData quicklySellData = this.QuicklySellData;
					bool isQuicklySell = quicklySellData != null && quicklySellData.PosDataDoublyList[i][j] == 1;
					if (dockyardBackpackGridData != null)
					{
						dockyardBackpackGridData.SetIsQuicklySell(isQuicklySell);
					}
					if (fishingShapeConfig.FillState()[i].ArrayInt(j) == 1)
					{
						if (dockyardBackpackGridData != null)
						{
							dockyardBackpackGridData.SetGridType(EBackpackGridType.Enable);
						}
					}
					else if (dockyardBackpackGridData != null)
					{
						dockyardBackpackGridData.SetGridType(EBackpackGridType.Disable);
					}
					this.PosDataList.Add(panelPos);
					this.PosDataDoublyList[i].Add(panelPos);
					this.GridDataMap.Add(panelPos, dockyardBackpackGridData);
				}
			}
		}

		// Token: 0x06042178 RID: 270712 RVA: 0x010F50E4 File Offset: 0x010F32E4
		private void ClearGridDataMapItemBlockId()
		{
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					DockyardBackpackGridData valueOrDefault = this.GridDataMap.GetValueOrDefault(this.PosDataDoublyList[i][j]);
					if (valueOrDefault != null)
					{
						valueOrDefault.SetItemBlockId(-1);
					}
				}
			}
		}

		// Token: 0x06042179 RID: 270713 RVA: 0x010F5134 File Offset: 0x010F3334
		private void InitItemBlockDataMap()
		{
			this.ItemBlockDataMap.Clear();
			foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in ModelBase<DockyardModel>.Instance.GetBackpackItemList())
			{
				DockyardItemBlockData dockyardItemBlockData = new DockyardItemBlockData(dockyardItemBlockOriginalData);
				this.ItemBlockDataMap.Add(dockyardItemBlockOriginalData.IncId, dockyardItemBlockData);
				this.RefreshBackpackGrid(dockyardItemBlockData);
			}
		}

		// Token: 0x0604217A RID: 270714 RVA: 0x010F51B0 File Offset: 0x010F33B0
		public void RefreshBackpackData()
		{
			this.ClearGridDataMapItemBlockId();
			this.InitItemBlockDataMap();
		}

		// Token: 0x0604217B RID: 270715 RVA: 0x010F51C0 File Offset: 0x010F33C0
		private void RefreshBackpackGrid(DockyardItemBlockData itemBlockData)
		{
			IPanelPosRange panelRange = itemBlockData.PanelRange;
			for (int i = panelRange.RowStartIndex; i <= panelRange.RowEndIndex; i++)
			{
				for (int j = panelRange.ColStartIndex; j <= panelRange.ColEndIndex; j++)
				{
					if (i >= 0 && i < 7 && j >= 0 && j < 8)
					{
						DockyardBackpackGridData valueOrDefault = this.GridDataMap.GetValueOrDefault(this.PosDataDoublyList[i][j]);
						if (valueOrDefault != null)
						{
							valueOrDefault.SetItemBlockId(itemBlockData.Data.IncId);
						}
					}
				}
			}
		}

		// Token: 0x0604217C RID: 270716 RVA: 0x010F5244 File Offset: 0x010F3444
		private void SetGridDataInQuicklySellType()
		{
			int count = this.QuicklySellData.PosDataDoublyList.Count;
			for (int i = 0; i < count; i++)
			{
				int count2 = this.QuicklySellData.PosDataDoublyList[i].Count;
				for (int j = 0; j < count2; j++)
				{
					DockyardQuicklySellData quicklySellData = this.QuicklySellData;
					bool isQuicklySell = quicklySellData != null && quicklySellData.PosDataDoublyList[i][j] == 1;
					IPanelPos key = this.PosDataDoublyList[i][j];
					DockyardBackpackGridData valueOrDefault = this.GridDataMap.GetValueOrDefault(key);
					if (valueOrDefault != null)
					{
						valueOrDefault.SetIsQuicklySell(isQuicklySell);
					}
				}
			}
		}

		// Token: 0x0604217D RID: 270717 RVA: 0x010F52E4 File Offset: 0x010F34E4
		private void ResetGridDataInQuicklySellType()
		{
			foreach (DockyardBackpackGridData dockyardBackpackGridData in this.GridDataMap.Values)
			{
				dockyardBackpackGridData.SetIsQuicklySell(false);
			}
		}

		// Token: 0x0604217E RID: 270718 RVA: 0x010F533C File Offset: 0x010F353C
		public void RefreshQuicklySellOpen(bool isQuicklySellOpen)
		{
			if (isQuicklySellOpen)
			{
				int quicklySellId = ModelBase<DockyardModel>.Instance.GetQuicklySellId();
				this.QuicklySellData = new DockyardQuicklySellData(quicklySellId);
				this.SetGridDataInQuicklySellType();
				return;
			}
			this.ResetGridDataInQuicklySellType();
		}

		// Token: 0x0604217F RID: 270719 RVA: 0x010F5370 File Offset: 0x010F3570
		public List<IPanelPos> GetBackpackDataList()
		{
			return this.PosDataList;
		}

		// Token: 0x06042180 RID: 270720 RVA: 0x010F5378 File Offset: 0x010F3578
		public IPanelPos GetBackpackPosByPos(int rowIndex, int colIndex)
		{
			return this.PosDataDoublyList[rowIndex][colIndex];
		}

		// Token: 0x06042181 RID: 270721 RVA: 0x010F538C File Offset: 0x010F358C
		public List<DockyardItemBlockData> GetBackpackItemList()
		{
			return this.ItemBlockDataMap.Values.ToList<DockyardItemBlockData>();
		}

		// Token: 0x06042182 RID: 270722 RVA: 0x010F539E File Offset: 0x010F359E
		public Dictionary<int, DockyardItemBlockData> GetBackpackItemMap()
		{
			return this.ItemBlockDataMap;
		}

		// Token: 0x06042183 RID: 270723 RVA: 0x010F53A6 File Offset: 0x010F35A6
		public DockyardBackpackGridData GetBackpackGridData(IPanelPos pos)
		{
			return this.GridDataMap[pos];
		}

		// Token: 0x06042184 RID: 270724 RVA: 0x010F53B4 File Offset: 0x010F35B4
		public DockyardItemBlockData AddItemBlockData(DockyardItemBlockOriginalData data)
		{
			DockyardItemBlockData dockyardItemBlockData = new DockyardItemBlockData(data);
			this.ItemBlockDataMap.Add(data.IncId, dockyardItemBlockData);
			return dockyardItemBlockData;
		}

		// Token: 0x06042185 RID: 270725 RVA: 0x010F53DB File Offset: 0x010F35DB
		public void DeleteItemBlockData(int incId)
		{
			this.ItemBlockDataMap.Remove(incId);
		}

		// Token: 0x06042186 RID: 270726 RVA: 0x010F53EA File Offset: 0x010F35EA
		[NullableContext(2)]
		public DockyardItemBlockData GetItemBlockData(int incId)
		{
			return this.ItemBlockDataMap.GetValueOrDefault(incId);
		}

		// Token: 0x04024D73 RID: 150899
		private readonly Dictionary<IPanelPos, DockyardBackpackGridData> GridDataMap = new Dictionary<IPanelPos, DockyardBackpackGridData>();

		// Token: 0x04024D74 RID: 150900
		private readonly List<List<IPanelPos>> PosDataDoublyList = new List<List<IPanelPos>>();

		// Token: 0x04024D75 RID: 150901
		private readonly Dictionary<int, DockyardItemBlockData> ItemBlockDataMap = new Dictionary<int, DockyardItemBlockData>();

		// Token: 0x04024D76 RID: 150902
		[Nullable(2)]
		private DockyardQuicklySellData QuicklySellData;

		// Token: 0x04024D77 RID: 150903
		private readonly List<IPanelPos> PosDataList = new List<IPanelPos>();
	}
}
