using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062AF RID: 25263
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisBoardData
	{
		// Token: 0x0603F946 RID: 260422 RVA: 0x0104BE94 File Offset: 0x0104A094
		public TetrisBoardData()
		{
			for (int i = 0; i < 8; i++)
			{
				this.CellsInternal[i] = new TetrisCellData[8];
				for (int j = 0; j < 8; j++)
				{
					this.CellsInternal[i][j] = new TetrisCellData();
				}
			}
		}

		// Token: 0x0603F947 RID: 260423 RVA: 0x0104BEE8 File Offset: 0x0104A0E8
		public void Reset()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					this.CellsInternal[i][j].Reset();
				}
			}
		}

		// Token: 0x17009C8F RID: 40079
		// (get) Token: 0x0603F948 RID: 260424 RVA: 0x0104BF1C File Offset: 0x0104A11C
		public TetrisCellData[][] Cells
		{
			get
			{
				return this.CellsInternal;
			}
		}

		// Token: 0x0603F949 RID: 260425 RVA: 0x0104BF24 File Offset: 0x0104A124
		public bool[][] GetBoardOccupancy()
		{
			bool[][] array = new bool[8][];
			for (int i = 0; i < 8; i++)
			{
				array[i] = new bool[8];
				for (int j = 0; j < 8; j++)
				{
					array[i][j] = this.CellsInternal[i][j].IsOccupied;
				}
			}
			return array;
		}

		// Token: 0x0603F94A RID: 260426 RVA: 0x0104BF70 File Offset: 0x0104A170
		public TetrisCellData[][] CloneCells()
		{
			TetrisCellData[][] array = new TetrisCellData[8][];
			for (int i = 0; i < 8; i++)
			{
				array[i] = new TetrisCellData[8];
				for (int j = 0; j < 8; j++)
				{
					array[i][j] = this.CellsInternal[i][j].Clone();
				}
			}
			return array;
		}

		// Token: 0x0603F94B RID: 260427 RVA: 0x0104BFBC File Offset: 0x0104A1BC
		public void RestoreFromSnapshot(TetrisCellData[][] snapshot)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					TetrisCellData tetrisCellData = snapshot[i][j];
					TetrisCellData tetrisCellData2 = this.CellsInternal[i][j];
					tetrisCellData2.Type = tetrisCellData.Type;
					tetrisCellData2.SealState = tetrisCellData.SealState;
					tetrisCellData2.GemType = tetrisCellData.GemType;
					tetrisCellData2.ColorId = tetrisCellData.ColorId;
				}
			}
		}

		// Token: 0x04023AFC RID: 146172
		public TetrisCellData[][] CellsInternal = new TetrisCellData[8][];
	}
}
