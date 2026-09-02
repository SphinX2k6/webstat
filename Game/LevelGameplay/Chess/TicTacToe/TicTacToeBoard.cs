using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Chess.TicTacToe
{
	// Token: 0x02006F47 RID: 28487
	[NullableContext(1)]
	[Nullable(0)]
	public class TicTacToeBoard
	{
		// Token: 0x06044F40 RID: 282432 RVA: 0x011F368C File Offset: 0x011F188C
		public void GetBoardInfo(List<int> infos)
		{
			infos.Clear();
			foreach (int item in this.BoardInfo)
			{
				infos.Add(item);
			}
		}

		// Token: 0x06044F41 RID: 282433 RVA: 0x011F36C0 File Offset: 0x011F18C0
		public void GetNextPoints(List<int> points)
		{
			points.Clear();
			foreach (int item in this.NextPoints)
			{
				points.Add(item);
			}
		}

		// Token: 0x06044F42 RID: 282434 RVA: 0x011F36F4 File Offset: 0x011F18F4
		public void GetPrePoints(List<int> points)
		{
			points.Clear();
			foreach (int item in this.PrePoints)
			{
				points.Add(item);
			}
		}

		// Token: 0x06044F43 RID: 282435 RVA: 0x011F3728 File Offset: 0x011F1928
		public void GetCirclePoints(List<int> points)
		{
			points.Clear();
			foreach (int item in this.CirclePoints)
			{
				points.Add(item);
			}
		}

		// Token: 0x1700A463 RID: 42083
		// (get) Token: 0x06044F44 RID: 282436 RVA: 0x011F375B File Offset: 0x011F195B
		public int BoardLength
		{
			get
			{
				return this.BoardLengthInternal;
			}
		}

		// Token: 0x1700A464 RID: 42084
		// (get) Token: 0x06044F45 RID: 282437 RVA: 0x011F3763 File Offset: 0x011F1963
		public int CenterIndex
		{
			get
			{
				return this.CenterIndexInternal;
			}
		}

		// Token: 0x1700A465 RID: 42085
		// (get) Token: 0x06044F46 RID: 282438 RVA: 0x011F376B File Offset: 0x011F196B
		public int WinLineCount
		{
			get
			{
				return this.WinLineCountInternal;
			}
		}

		// Token: 0x06044F47 RID: 282439 RVA: 0x011F3773 File Offset: 0x011F1973
		public void Init(int winLineCount, Action<ETicTacToeBoardContent> onGameOver, Action onEndRound)
		{
			this.WinLineCountInternal = winLineCount;
			this.OnGameOver = onGameOver;
			this.OnEndRound = onEndRound;
		}

		// Token: 0x06044F48 RID: 282440 RVA: 0x011F378C File Offset: 0x011F198C
		public void InitOriginBoardInfo(ETicTacToeBoardContent[] originInfo)
		{
			Array.Resize<int>(ref this.OriginBoardInfo, originInfo.Length);
			Array.Resize<int>(ref this.BoardInfo, originInfo.Length);
			for (int i = 0; i < originInfo.Length; i++)
			{
				this.OriginBoardInfo[i] = (int)originInfo[i];
				this.BoardInfo[i] = (int)originInfo[i];
			}
		}

		// Token: 0x06044F49 RID: 282441 RVA: 0x011F37DC File Offset: 0x011F19DC
		public void InitBoardInfo(ETicTacToeBoardContent[] originInfo)
		{
			Array.Resize<int>(ref this.BoardInfo, originInfo.Length);
			for (int i = 0; i < originInfo.Length; i++)
			{
				this.BoardInfo[i] = (int)originInfo[i];
			}
		}

		// Token: 0x06044F4A RID: 282442 RVA: 0x011F3810 File Offset: 0x011F1A10
		public void StartGame()
		{
		}

		// Token: 0x06044F4B RID: 282443 RVA: 0x011F3814 File Offset: 0x011F1A14
		public void ResetGame()
		{
			this.BoardInfo = new int[this.OriginBoardInfo.Length];
			for (int i = 0; i < this.OriginBoardInfo.Length; i++)
			{
				this.BoardInfo[i] = this.OriginBoardInfo[i];
			}
		}

		// Token: 0x06044F4C RID: 282444 RVA: 0x011F3857 File Offset: 0x011F1A57
		public bool CheckPieceSelect(int index, ETicTacToeBoardContent camp)
		{
			return this.BoardInfo.Length > index && this.BoardInfo[index] == (int)camp;
		}

		// Token: 0x06044F4D RID: 282445 RVA: 0x011F3874 File Offset: 0x011F1A74
		public bool CheckPieceMove(int index, int oldIndex, ETicTacToeBoardContent camp)
		{
			return this.BoardInfo[index] == (int)camp && this.BoardInfo[oldIndex] == 0 && (index == this.CenterIndexInternal || oldIndex == this.CenterIndexInternal || this.PrePoints[oldIndex] == index || this.NextPoints[oldIndex] == index);
		}

		// Token: 0x06044F4E RID: 282446 RVA: 0x011F38C8 File Offset: 0x011F1AC8
		public bool OnPieceMove(int index, int newIndex)
		{
			if (this.BoardInfo[newIndex] != 0)
			{
				return false;
			}
			int num = this.BoardInfo[index];
			this.BoardInfo[index] = 0;
			this.BoardInfo[newIndex] = num;
			if (!this.CheckGameOver(newIndex) && this.OnEndRound != null)
			{
				this.OnEndRound();
			}
			return true;
		}

		// Token: 0x06044F4F RID: 282447 RVA: 0x011F3919 File Offset: 0x011F1B19
		public bool CheckBoardValue(int index, ETicTacToeBoardContent value)
		{
			return this.BoardInfo[index] == (int)value;
		}

		// Token: 0x06044F50 RID: 282448 RVA: 0x011F3928 File Offset: 0x011F1B28
		public IReadOnlyList<int> GetNoneNeighbors(int selectIndex)
		{
			this.SelectNeighbors.Clear();
			if (selectIndex == this.CenterIndex)
			{
				int num = selectIndex % this.BoardLengthInternal;
				int num2 = selectIndex / this.BoardLengthInternal;
				for (int i = num2 - 1; i < num2 + 2; i++)
				{
					if (i >= 0 && i < this.BoardLengthInternal)
					{
						for (int j = num - 1; j < num + 2; j++)
						{
							if (j >= 0 && j < this.BoardLengthInternal)
							{
								int num3 = i * this.BoardLengthInternal + j;
								if (this.BoardInfo[num3] == 0)
								{
									this.SelectNeighbors.Add(num3);
								}
							}
						}
					}
				}
			}
			else if (selectIndex > -1)
			{
				int num4 = selectIndex % this.BoardLengthInternal;
				int num5 = selectIndex / this.BoardLengthInternal;
				for (int k = num5 - 1; k < num5 + 2; k++)
				{
					if (k >= 0 && k < this.BoardLengthInternal)
					{
						int num6 = k * this.BoardLengthInternal + num4;
						if (this.BoardInfo[num6] == 0)
						{
							this.SelectNeighbors.Add(num6);
						}
					}
				}
				for (int l = num4 - 1; l < num4 + 2; l++)
				{
					if (l >= 0 && l < this.BoardLengthInternal)
					{
						int num7 = num5 * this.BoardLengthInternal + l;
						if (this.BoardInfo[num7] == 0)
						{
							this.SelectNeighbors.Add(num7);
						}
					}
				}
				if (this.BoardInfo[this.CenterIndexInternal] == 0 && !this.SelectNeighbors.Contains(this.CenterIndexInternal))
				{
					this.SelectNeighbors.Add(this.CenterIndexInternal);
				}
			}
			return this.SelectNeighbors;
		}

		// Token: 0x06044F51 RID: 282449 RVA: 0x011F3AA8 File Offset: 0x011F1CA8
		public IReadOnlyList<int> GetNoneNeighborsWithCustomInfos(List<int> infos, int selectIndex)
		{
			List<int> list = new List<int>();
			if (selectIndex == this.CenterIndex)
			{
				int num = selectIndex % this.BoardLengthInternal;
				int num2 = selectIndex / this.BoardLengthInternal;
				for (int i = num2 - 1; i < num2 + 2; i++)
				{
					if (i >= 0 && i < this.BoardLengthInternal)
					{
						for (int j = num - 1; j < num + 2; j++)
						{
							if (j >= 0 && j < this.BoardLengthInternal)
							{
								int num3 = i * this.BoardLengthInternal + j;
								if (infos[num3] == 0)
								{
									list.Add(num3);
								}
							}
						}
					}
				}
			}
			else if (selectIndex > -1)
			{
				int num4 = selectIndex % this.BoardLengthInternal;
				int num5 = selectIndex / this.BoardLengthInternal;
				for (int k = num5 - 1; k < num5 + 2; k++)
				{
					if (k >= 0 && k < this.BoardLengthInternal)
					{
						int num6 = k * this.BoardLengthInternal + num4;
						if (infos[num6] == 0)
						{
							list.Add(num6);
						}
					}
				}
				for (int l = num4 - 1; l < num4 + 2; l++)
				{
					if (l >= 0 && l < this.BoardLengthInternal)
					{
						int num7 = num5 * this.BoardLengthInternal + l;
						if (infos[num7] == 0)
						{
							list.Add(num7);
						}
					}
				}
				if (infos[this.CenterIndexInternal] == 0 && !list.Contains(this.CenterIndexInternal))
				{
					list.Add(this.CenterIndexInternal);
				}
			}
			return list;
		}

		// Token: 0x06044F52 RID: 282450 RVA: 0x011F3C08 File Offset: 0x011F1E08
		public bool CheckGameOver(int startIndex)
		{
			int num = this.BoardInfo[startIndex];
			if (num == 0)
			{
				return false;
			}
			int num2 = this.CirclePoints.Length;
			int num3 = this.CirclePoints.Length / 2;
			if (startIndex != this.CenterIndexInternal)
			{
				int num4 = this.WinLineCountInternal - 1;
				int num5 = this.NextPoints[startIndex];
				while (num4-- > 0)
				{
					if (this.BoardInfo[num5] != num)
					{
						num4++;
						break;
					}
					num5 = this.NextPoints[num5];
				}
				int num6 = this.PrePoints[startIndex];
				while (num4-- > 0)
				{
					if (this.BoardInfo[num6] != num)
					{
						num4++;
						break;
					}
					num6 = this.PrePoints[num6];
				}
				if (num4 < 1)
				{
					if (this.OnGameOver != null)
					{
						this.OnGameOver((ETicTacToeBoardContent)num);
					}
					return true;
				}
				if (num == this.BoardInfo[this.CenterIndexInternal])
				{
					int num7 = Array.IndexOf<int>(this.CirclePoints, startIndex);
					if (num7 > -1)
					{
						int num8 = (num7 + num3) % num2;
						if (num == this.BoardInfo[this.CirclePoints[num8]])
						{
							if (this.OnGameOver != null)
							{
								this.OnGameOver((ETicTacToeBoardContent)num);
							}
							return true;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < num3; i++)
				{
					int num9 = (i + num3) % num2;
					if (num == this.BoardInfo[this.CirclePoints[i]] && num == this.BoardInfo[this.CirclePoints[num9]])
					{
						if (this.OnGameOver != null)
						{
							this.OnGameOver((ETicTacToeBoardContent)num);
						}
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06044F53 RID: 282451 RVA: 0x011F3D78 File Offset: 0x011F1F78
		public void GetDebugBoardInfo(TArray<int> infos)
		{
			infos.Empty(true);
			foreach (int value in this.BoardInfo)
			{
				infos.Add(value);
			}
		}

		// Token: 0x04026747 RID: 157511
		protected int[] OriginBoardInfo = new int[]
		{
			0,
			0,
			2,
			2,
			1,
			1,
			0,
			1,
			2
		};

		// Token: 0x04026748 RID: 157512
		protected int[] BoardInfo = new int[]
		{
			0,
			0,
			2,
			2,
			1,
			1,
			0,
			1,
			2
		};

		// Token: 0x04026749 RID: 157513
		protected int[] NextPoints = new int[]
		{
			1,
			2,
			5,
			0,
			-1,
			8,
			3,
			6,
			7
		};

		// Token: 0x0402674A RID: 157514
		protected int[] PrePoints = new int[]
		{
			3,
			0,
			1,
			6,
			-1,
			2,
			7,
			8,
			5
		};

		// Token: 0x0402674B RID: 157515
		protected int[] CirclePoints = new int[]
		{
			1,
			2,
			5,
			8,
			7,
			6,
			3,
			0
		};

		// Token: 0x0402674C RID: 157516
		private readonly int BoardLengthInternal = 3;

		// Token: 0x0402674D RID: 157517
		private readonly int CenterIndexInternal = 4;

		// Token: 0x0402674E RID: 157518
		private int WinLineCountInternal = 3;

		// Token: 0x0402674F RID: 157519
		[Nullable(2)]
		private Action<ETicTacToeBoardContent> OnGameOver;

		// Token: 0x04026750 RID: 157520
		[Nullable(2)]
		private Action OnEndRound;

		// Token: 0x04026751 RID: 157521
		protected List<int> SelectNeighbors = new List<int>();
	}
}
