using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B4 RID: 26548
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardItemBlockData
	{
		// Token: 0x1700A100 RID: 41216
		// (get) Token: 0x0604238C RID: 271244 RVA: 0x010FD06B File Offset: 0x010FB26B
		private List<List<int>> OriginalPosData
		{
			get
			{
				return this.Data.PosDoublyList;
			}
		}

		// Token: 0x0604238D RID: 271245 RVA: 0x010FD078 File Offset: 0x010FB278
		public DockyardItemBlockData(DockyardItemBlockOriginalData data)
		{
			this.Data = data;
			this.OriginalPivot = Vector2D.Create();
			this.TempPivot = Vector2D.Create();
			this.TempOffset = Vector2D.Create();
			this.LeftTopAnchorOffset = Vector2D.Create();
			this.TempPosData = DockyardPanelUtil.RotateOriginalPosData(this.OriginalPosData, data.Rotate).ToList<List<int>>();
			this.LeftTopPosInPanel.ColIndex = data.PosX;
			this.LeftTopPosInPanel.RowIndex = data.PosY;
			this.Rotate = data.Rotate;
			this.CalculatePanelRange(this.PanelRange, this.LeftTopPosInPanel);
			this.RecordLastPanelRange();
			this.CalculateOriginalPivot();
		}

		// Token: 0x0604238E RID: 271246 RVA: 0x010FD198 File Offset: 0x010FB398
		public void RefreshData(DockyardItemBlockOriginalData data)
		{
			this.Data = data;
		}

		// Token: 0x0604238F RID: 271247 RVA: 0x010FD1A1 File Offset: 0x010FB3A1
		public bool IsInUpOrDown()
		{
			return this.Rotate == FishingItemRotate.No || this.Rotate == FishingItemRotate.DirectionLeft;
		}

		// Token: 0x06042390 RID: 271248 RVA: 0x010FD1B6 File Offset: 0x010FB3B6
		private void CalculateOriginalPivot()
		{
			this.OriginalPivot.DeepCopy(DockyardPanelUtil.CalculateOriginalPivot(this.OriginalPosData.Count<List<int>>(), this.OriginalPosData.First<List<int>>().Count<int>()));
		}

		// Token: 0x06042391 RID: 271249 RVA: 0x010FD1E4 File Offset: 0x010FB3E4
		private void CalculatePanelRange(IPanelPosRange panelRange, IPanelPos panelPos)
		{
			int num;
			int num2;
			if (this.IsInUpOrDown())
			{
				num = this.OriginalPosData.Count<List<int>>();
				num2 = this.OriginalPosData.First<List<int>>().Count<int>();
			}
			else
			{
				num = this.OriginalPosData.First<List<int>>().Count<int>();
				num2 = this.OriginalPosData.Count<List<int>>();
			}
			panelRange.RowStartIndex = panelPos.RowIndex;
			panelRange.RowEndIndex = panelPos.RowIndex + num - 1;
			panelRange.ColStartIndex = panelPos.ColIndex;
			panelRange.ColEndIndex = panelPos.ColIndex + num2 - 1;
		}

		// Token: 0x06042392 RID: 271250 RVA: 0x010FD274 File Offset: 0x010FB474
		private int GetLeftTopColIndexInPanel(double positionX, float gridWidth)
		{
			int result;
			if (positionX < 0.0)
			{
				result = ((Math.Abs(positionX % (double)gridWidth) > (double)(gridWidth * 1f / 2f)) ? ((int)Math.Floor(positionX / (double)gridWidth)) : ((int)Math.Ceiling(positionX / (double)gridWidth)));
			}
			else
			{
				result = ((positionX % (double)gridWidth > (double)(gridWidth * 1f / 2f)) ? ((int)Math.Ceiling(positionX / (double)gridWidth)) : ((int)Math.Floor(positionX / (double)gridWidth)));
			}
			return result;
		}

		// Token: 0x06042393 RID: 271251 RVA: 0x010FD2F0 File Offset: 0x010FB4F0
		private int GetLeftTopRowIndexInPanel(double positionY, float gridWidth)
		{
			int result;
			if (positionY > 0.0)
			{
				result = ((Math.Abs(-positionY % (double)gridWidth) > (double)(gridWidth * 1f / 2f)) ? ((int)Math.Floor(-positionY / (double)gridWidth)) : ((int)Math.Ceiling(-positionY / (double)gridWidth)));
			}
			else
			{
				result = ((-positionY % (double)gridWidth > (double)(gridWidth * 1f / 2f)) ? ((int)Math.Ceiling(-positionY / (double)gridWidth)) : ((int)Math.Floor(-positionY / (double)gridWidth)));
			}
			return result;
		}

		// Token: 0x06042394 RID: 271252 RVA: 0x010FD370 File Offset: 0x010FB570
		private void CalculateLeftTopPosInPanel(Vector2D position, float gridWidth)
		{
			int leftTopColIndexInPanel = this.GetLeftTopColIndexInPanel(position.X, gridWidth);
			int leftTopRowIndexInPanel = this.GetLeftTopRowIndexInPanel(position.Y, gridWidth);
			this.LeftTopPosInPanel.ColIndex = leftTopColIndexInPanel;
			this.LeftTopPosInPanel.RowIndex = leftTopRowIndexInPanel;
			this.CalculatePanelRange(this.PanelRange, this.LeftTopPosInPanel);
		}

		// Token: 0x06042395 RID: 271253 RVA: 0x010FD3C4 File Offset: 0x010FB5C4
		private void RecordLastPanelRange()
		{
			this.LastPanelRange.RowStartIndex = this.PanelRange.RowStartIndex;
			this.LastPanelRange.RowEndIndex = this.PanelRange.RowEndIndex;
			this.LastPanelRange.ColStartIndex = this.PanelRange.ColStartIndex;
			this.LastPanelRange.ColEndIndex = this.PanelRange.ColEndIndex;
		}

		// Token: 0x06042396 RID: 271254 RVA: 0x010FD42C File Offset: 0x010FB62C
		private Vector2D GetCenterPivotByRotate()
		{
			switch (this.Rotate)
			{
			case FishingItemRotate.No:
				this.TempPivot.Set(this.OriginalPivot.X, this.OriginalPivot.Y);
				break;
			case FishingItemRotate.DirectionDown:
				this.TempPivot.Set(this.OriginalPivot.Y, 1.0 - this.OriginalPivot.X);
				break;
			case FishingItemRotate.DirectionLeft:
				this.TempPivot.Set(1.0 - this.OriginalPivot.X, 1.0 - this.OriginalPivot.Y);
				break;
			case FishingItemRotate.DirectionUp:
				this.TempPivot.Set(1.0 - this.OriginalPivot.Y, this.OriginalPivot.X);
				break;
			}
			return this.TempPivot;
		}

		// Token: 0x06042397 RID: 271255 RVA: 0x010FD516 File Offset: 0x010FB716
		public Vector2D GetTopLeftOffsetByRotate()
		{
			this.TempOffset.Set(0.0, 1.0);
			this.TempPivot = this.GetCenterPivotByRotate();
			return this.TempOffset.SubtractionEqual(this.TempPivot);
		}

		// Token: 0x06042398 RID: 271256 RVA: 0x010FD554 File Offset: 0x010FB754
		public void RotateData()
		{
			ValueTuple<List<List<int>>, FishingItemRotate> valueTuple = DockyardPanelUtil.RotateItemGridData(this.TempPosData, this.Rotate);
			this.TempPosData = valueTuple.Item1;
			this.Rotate = valueTuple.Item2;
		}

		// Token: 0x06042399 RID: 271257 RVA: 0x010FD58B File Offset: 0x010FB78B
		public List<List<int>> GetGridDataDoubleList()
		{
			return this.TempPosData;
		}

		// Token: 0x0604239A RID: 271258 RVA: 0x010FD593 File Offset: 0x010FB793
		public IEnumerable<IPanelPos> GetPosDataList()
		{
			return this.Data.PosDataList;
		}

		// Token: 0x0604239B RID: 271259 RVA: 0x010FD5A0 File Offset: 0x010FB7A0
		public float GetRotateValue()
		{
			switch (this.Rotate)
			{
			case FishingItemRotate.No:
				return 0f;
			case FishingItemRotate.DirectionDown:
				return -90f;
			case FishingItemRotate.DirectionLeft:
				return -180f;
			case FishingItemRotate.DirectionUp:
				return -270f;
			default:
				return 0f;
			}
		}

		// Token: 0x0604239C RID: 271260 RVA: 0x010FD5E9 File Offset: 0x010FB7E9
		public Vector2D GetOriginalPivot()
		{
			return this.OriginalPivot;
		}

		// Token: 0x0604239D RID: 271261 RVA: 0x010FD5F4 File Offset: 0x010FB7F4
		public void RefreshLeftTopPosInBackpack(Vector2D anchorOffset, float blockWidth, float blockHeight, float gridWidth)
		{
			Vector2D topLeftOffsetByRotate = this.GetTopLeftOffsetByRotate();
			if (this.IsInUpOrDown())
			{
				topLeftOffsetByRotate.X *= (double)blockWidth;
				topLeftOffsetByRotate.Y *= (double)blockHeight;
			}
			else
			{
				topLeftOffsetByRotate.X *= (double)blockHeight;
				topLeftOffsetByRotate.Y *= (double)blockWidth;
			}
			anchorOffset.Addition(topLeftOffsetByRotate, topLeftOffsetByRotate);
			this.LeftTopAnchorOffset.DeepCopy(topLeftOffsetByRotate);
			this.RecordLastPanelRange();
			this.CalculateLeftTopPosInPanel(topLeftOffsetByRotate, gridWidth);
		}

		// Token: 0x0604239E RID: 271262 RVA: 0x010FD672 File Offset: 0x010FB872
		public IPanelPosRange GetLeftTopPosRangeByLeftTopPos(Vector2D offset, float gridWidth)
		{
			this.LeftTopAnchorOffset.DeepCopy(offset);
			this.RecordLastPanelRange();
			this.CalculateLeftTopPosInPanel(offset, gridWidth);
			return this.PanelRange;
		}

		// Token: 0x0604239F RID: 271263 RVA: 0x010FD694 File Offset: 0x010FB894
		public bool IsValidGridPos(int rowIndex, int colIndex)
		{
			int index = rowIndex - this.LeftTopPosInPanel.RowIndex;
			int index2 = colIndex - this.LeftTopPosInPanel.ColIndex;
			return this.TempPosData[index][index2] == 1;
		}

		// Token: 0x060423A0 RID: 271264 RVA: 0x010FD6D4 File Offset: 0x010FB8D4
		public Vector2D GetCenterPosInBackpack(int rowStartIndex, int colStartIndex)
		{
			this.TempPivot = this.GetCenterPivotByRotate();
			double x = (double)colStartIndex + this.TempPivot.X * (double)this.TempPosData[0].Count;
			double y = (double)rowStartIndex + (1.0 - this.TempPivot.Y) * (double)this.TempPosData.Count;
			return Vector2D.Create(x, y);
		}

		// Token: 0x04024E2A RID: 151082
		private List<List<int>> TempPosData = new List<List<int>>();

		// Token: 0x04024E2B RID: 151083
		public FishingItemRotate Rotate;

		// Token: 0x04024E2C RID: 151084
		public readonly IPanelPos LeftTopPosInPanel = new PanelPos
		{
			RowIndex = -1,
			ColIndex = -1
		};

		// Token: 0x04024E2D RID: 151085
		public readonly IPanelPosRange PanelRange = new PanelPosRange
		{
			RowStartIndex = -1,
			RowEndIndex = -1,
			ColStartIndex = -1,
			ColEndIndex = -1
		};

		// Token: 0x04024E2E RID: 151086
		public readonly IPanelPosRange LastPanelRange = new PanelPosRange
		{
			RowStartIndex = -1,
			RowEndIndex = -1,
			ColStartIndex = -1,
			ColEndIndex = -1
		};

		// Token: 0x04024E2F RID: 151087
		private readonly Vector2D OriginalPivot;

		// Token: 0x04024E30 RID: 151088
		private Vector2D TempPivot;

		// Token: 0x04024E31 RID: 151089
		private readonly Vector2D TempOffset;

		// Token: 0x04024E32 RID: 151090
		public readonly Vector2D LeftTopAnchorOffset;

		// Token: 0x04024E33 RID: 151091
		public DockyardItemBlockOriginalData Data;
	}
}
