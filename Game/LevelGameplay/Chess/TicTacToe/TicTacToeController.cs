using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Chess.TicTacToe
{
	// Token: 0x02006F48 RID: 28488
	[NullableContext(1)]
	[Nullable(0)]
	public class TicTacToeController
	{
		// Token: 0x06044F55 RID: 282453 RVA: 0x011F3E56 File Offset: 0x011F2056
		public void Init(TicTacToeBoard board, ETicTacToeBoardContent camp)
		{
			this.ChessBoard = board;
			this.SelfCamp = camp;
		}

		// Token: 0x06044F56 RID: 282454 RVA: 0x011F3E66 File Offset: 0x011F2066
		public virtual void OnStartRound()
		{
		}

		// Token: 0x06044F57 RID: 282455 RVA: 0x011F3E68 File Offset: 0x011F2068
		public virtual void OnStartGame()
		{
			this.SelectIndex = -1;
		}

		// Token: 0x1700A466 RID: 42086
		// (get) Token: 0x06044F58 RID: 282456 RVA: 0x011F3E71 File Offset: 0x011F2071
		public bool IsSelecting
		{
			get
			{
				return this.SelectIndex > -1;
			}
		}

		// Token: 0x1700A467 RID: 42087
		// (get) Token: 0x06044F59 RID: 282457 RVA: 0x011F3E7C File Offset: 0x011F207C
		public int SelectPieceIndex
		{
			get
			{
				return this.SelectIndex;
			}
		}

		// Token: 0x06044F5A RID: 282458 RVA: 0x011F3E84 File Offset: 0x011F2084
		public bool SelectPiece(int index)
		{
			if (this.SelectIndex == index)
			{
				return true;
			}
			if (!this.ChessBoard.CheckPieceSelect(index, this.SelfCamp))
			{
				this.SelectIndex = -1;
				return false;
			}
			this.SelectIndex = index;
			return true;
		}

		// Token: 0x06044F5B RID: 282459 RVA: 0x011F3EB6 File Offset: 0x011F20B6
		public bool ResetSelectPiece(int index)
		{
			if (this.SelectIndex == index)
			{
				this.SelectIndex = -1;
				return true;
			}
			return false;
		}

		// Token: 0x06044F5C RID: 282460 RVA: 0x011F3ECB File Offset: 0x011F20CB
		public IReadOnlyList<int> GetSelectNeighbor()
		{
			return this.ChessBoard.GetNoneNeighbors(this.SelectIndex);
		}

		// Token: 0x06044F5D RID: 282461 RVA: 0x011F3EDE File Offset: 0x011F20DE
		public void RegisterEvent(Action<int, int> onPieceMove)
		{
			this.OnPieceMove = onPieceMove;
		}

		// Token: 0x06044F5E RID: 282462 RVA: 0x011F3EE8 File Offset: 0x011F20E8
		public virtual bool MovePiece(int newIndex)
		{
			if (this.ChessBoard == null || !this.ChessBoard.CheckPieceMove(this.SelectIndex, newIndex, this.SelfCamp))
			{
				this.SelectIndex = -1;
				return false;
			}
			if (!this.ChessBoard.OnPieceMove(this.SelectIndex, newIndex))
			{
				this.SelectIndex = -1;
				return false;
			}
			if (this.OnPieceMove != null)
			{
				this.OnPieceMove(this.SelectIndex, newIndex);
			}
			this.SelectIndex = -1;
			return true;
		}

		// Token: 0x06044F5F RID: 282463 RVA: 0x011F3F5F File Offset: 0x011F215F
		public void OnResetGame()
		{
			this.OnStartGame();
		}

		// Token: 0x04026752 RID: 157522
		protected ETicTacToeBoardContent SelfCamp = ETicTacToeBoardContent.White;

		// Token: 0x04026753 RID: 157523
		protected int SelectIndex = -1;

		// Token: 0x04026754 RID: 157524
		protected readonly int WinLineCount = 3;

		// Token: 0x04026755 RID: 157525
		[Nullable(2)]
		protected TicTacToeBoard ChessBoard;

		// Token: 0x04026756 RID: 157526
		[Nullable(2)]
		protected Action<int, int> OnPieceMove;
	}
}
