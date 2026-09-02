using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.AIGearStrategy;

namespace CSharpScript.Game.LevelGamePlay.Chess.TicTacToe
{
	// Token: 0x02006F49 RID: 28489
	[NullableContext(1)]
	[Nullable(0)]
	public class TicTacToeGame
	{
		// Token: 0x06044F61 RID: 282465 RVA: 0x011F3F84 File Offset: 0x011F2184
		public TicTacToeGame()
		{
			this.CurrentCamp = this.CampLoop[0];
		}

		// Token: 0x06044F62 RID: 282466 RVA: 0x011F3FF8 File Offset: 0x011F21F8
		public void Init(bool isAiOffensive, Action<int, int> onPieceMove)
		{
			this.Board.Init(this.WinLineCount, new Action<ETicTacToeBoardContent>(this.OnGameOverCallback), new Action(this.OnEndRoundCallback));
			this.Controller.Init(this.Board, this.PlayerCamp);
			this.AiController.InitAi(this.Board, this.AiCamp, this.PlayerCamp);
			this.Controller.RegisterEvent(onPieceMove);
			this.AiController.RegisterEvent(onPieceMove);
			this.SetOffensive(isAiOffensive);
		}

		// Token: 0x06044F63 RID: 282467 RVA: 0x011F4081 File Offset: 0x011F2281
		public void RefreshAiEnable(bool enable)
		{
			if (this.IsAiEnable != enable)
			{
				if (!this.IsAiEnable && this.CurrentCamp == this.AiCamp)
				{
					this.StartRound();
				}
				this.IsAiEnable = enable;
			}
		}

		// Token: 0x06044F64 RID: 282468 RVA: 0x011F40B0 File Offset: 0x011F22B0
		public void StartRound()
		{
			if (this.CurrentCamp == this.PlayerCamp)
			{
				this.Controller.OnStartRound();
				return;
			}
			if (this.CurrentCamp == this.AiCamp)
			{
				if (this.IsAiEnable)
				{
					this.AiController.OnStartRound();
					return;
				}
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.WLJ, "[TicTacToe]当前回合阵营错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06044F65 RID: 282469 RVA: 0x011F4115 File Offset: 0x011F2315
		public bool OnIndexSelect(int index)
		{
			if (!this.Controller.IsSelecting)
			{
				return this.Controller.SelectPiece(index);
			}
			return this.Controller.ResetSelectPiece(index) || this.Controller.MovePiece(index);
		}

		// Token: 0x06044F66 RID: 282470 RVA: 0x011F414D File Offset: 0x011F234D
		public bool OnIndexMove(int oldIndex, int newIndex)
		{
			this.Controller.SelectPiece(oldIndex);
			return this.Controller.IsSelecting && this.Controller.MovePiece(newIndex);
		}

		// Token: 0x06044F67 RID: 282471 RVA: 0x011F4178 File Offset: 0x011F2378
		public void NextRound()
		{
			this.CurrentRound++;
			int num = this.CampLoop.Length;
			this.CurrentCamp = this.CampLoop[this.CurrentRound % num];
			this.StartRound();
		}

		// Token: 0x06044F68 RID: 282472 RVA: 0x011F41B8 File Offset: 0x011F23B8
		public void SetCurrentRound(int round)
		{
			this.CurrentRound = round;
			int num = this.CampLoop.Length;
			this.CurrentCamp = this.CampLoop[this.CurrentRound % num];
			this.WinCampInternal = ETicTacToeBoardContent.None;
			this.StartRound();
		}

		// Token: 0x1700A468 RID: 42088
		// (get) Token: 0x06044F69 RID: 282473 RVA: 0x011F41F7 File Offset: 0x011F23F7
		public bool IsPlayerRound
		{
			get
			{
				return this.CurrentCamp == this.PlayerCamp;
			}
		}

		// Token: 0x1700A469 RID: 42089
		// (get) Token: 0x06044F6A RID: 282474 RVA: 0x011F4207 File Offset: 0x011F2407
		public bool PlayerWin
		{
			get
			{
				return this.WinCampInternal == this.PlayerCamp;
			}
		}

		// Token: 0x1700A46A RID: 42090
		// (get) Token: 0x06044F6B RID: 282475 RVA: 0x011F4217 File Offset: 0x011F2417
		public bool AiWin
		{
			get
			{
				return this.WinCampInternal == this.AiCamp;
			}
		}

		// Token: 0x1700A46B RID: 42091
		// (get) Token: 0x06044F6C RID: 282476 RVA: 0x011F4227 File Offset: 0x011F2427
		public bool IsFinish
		{
			get
			{
				return this.WinCampInternal > ETicTacToeBoardContent.None;
			}
		}

		// Token: 0x06044F6D RID: 282477 RVA: 0x011F4232 File Offset: 0x011F2432
		public void StartGame()
		{
			this.CurrentRound = 0;
			this.CurrentCamp = this.CampLoop[0];
			this.WinCampInternal = ETicTacToeBoardContent.None;
			this.StartRound();
		}

		// Token: 0x06044F6E RID: 282478 RVA: 0x011F4256 File Offset: 0x011F2456
		public void ResetGame()
		{
			this.Controller.OnResetGame();
			this.AiController.OnResetGame();
			this.Board.ResetGame();
			this.StartGame();
		}

		// Token: 0x06044F6F RID: 282479 RVA: 0x011F427F File Offset: 0x011F247F
		protected void OnGameOver(ETicTacToeBoardContent winCamp)
		{
			this.WinCampInternal = winCamp;
		}

		// Token: 0x06044F70 RID: 282480 RVA: 0x011F4288 File Offset: 0x011F2488
		protected void OnGameOverCallback(ETicTacToeBoardContent winCamp)
		{
			this.OnGameOver(winCamp);
		}

		// Token: 0x06044F71 RID: 282481 RVA: 0x011F4291 File Offset: 0x011F2491
		protected void OnEndRound()
		{
			if (this.AutoNextRound)
			{
				this.NextRound();
			}
		}

		// Token: 0x06044F72 RID: 282482 RVA: 0x011F42A1 File Offset: 0x011F24A1
		protected void OnEndRoundCallback()
		{
			this.OnEndRound();
		}

		// Token: 0x06044F73 RID: 282483 RVA: 0x011F42A9 File Offset: 0x011F24A9
		public void RefreshAiInfo(BP_AIGearStrategy_C aiInfo)
		{
			this.AiController.RefreshAiInfo(aiInfo);
		}

		// Token: 0x06044F74 RID: 282484 RVA: 0x011F42B8 File Offset: 0x011F24B8
		public void InitBoardInfo(IList<int> aiPieces, IList<int> playerPieces, bool initOriginBoardInfo = false)
		{
			ETicTacToeBoardContent[] array = new ETicTacToeBoardContent[this.Board.BoardLength * this.Board.BoardLength];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ETicTacToeBoardContent.None;
			}
			foreach (int num in aiPieces)
			{
				if (num < array.Length)
				{
					array[num] = this.AiCamp;
				}
			}
			foreach (int num2 in playerPieces)
			{
				if (num2 < array.Length)
				{
					array[num2] = this.PlayerCamp;
				}
			}
			if (initOriginBoardInfo)
			{
				this.Board.InitOriginBoardInfo(array);
				return;
			}
			this.Board.InitBoardInfo(array);
		}

		// Token: 0x06044F75 RID: 282485 RVA: 0x011F4398 File Offset: 0x011F2598
		public int[] GetPlayerPieces()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			this.Board.GetBoardInfo(list2);
			for (int i = 0; i < list2.Count; i++)
			{
				if (list2[i] == (int)this.PlayerCamp)
				{
					list.Add(i);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06044F76 RID: 282486 RVA: 0x011F43EA File Offset: 0x011F25EA
		public void SetOffensive(bool isAiOffensive)
		{
			ETicTacToeBoardContent[] campLoop;
			if (!isAiOffensive)
			{
				ETicTacToeBoardContent[] array = new ETicTacToeBoardContent[2];
				array[0] = this.PlayerCamp;
				campLoop = array;
				array[1] = this.AiCamp;
			}
			else
			{
				ETicTacToeBoardContent[] array2 = new ETicTacToeBoardContent[2];
				array2[0] = this.AiCamp;
				campLoop = array2;
				array2[1] = this.PlayerCamp;
			}
			this.CampLoop = campLoop;
		}

		// Token: 0x06044F77 RID: 282487 RVA: 0x011F4427 File Offset: 0x011F2627
		public IReadOnlyList<int> GetNoneNeighbors(int selectIndex)
		{
			return this.Board.GetNoneNeighbors(selectIndex);
		}

		// Token: 0x06044F78 RID: 282488 RVA: 0x011F4435 File Offset: 0x011F2635
		public bool CheckCanMove(int index)
		{
			return this.Board.CheckBoardValue(index, ETicTacToeBoardContent.None);
		}

		// Token: 0x06044F79 RID: 282489 RVA: 0x011F4444 File Offset: 0x011F2644
		public bool CheckIsPlayerPiece(int index)
		{
			return this.Board.CheckBoardValue(index, this.PlayerCamp);
		}

		// Token: 0x06044F7A RID: 282490 RVA: 0x011F4458 File Offset: 0x011F2658
		public bool CheckIsCenter(int index)
		{
			return this.Board.CenterIndex == index;
		}

		// Token: 0x06044F7B RID: 282491 RVA: 0x011F4468 File Offset: 0x011F2668
		public bool CheckGameOver(int index)
		{
			return this.Board.CheckGameOver(index);
		}

		// Token: 0x04026757 RID: 157527
		protected readonly TicTacToeController Controller = new TicTacToeController();

		// Token: 0x04026758 RID: 157528
		protected readonly TicTacToeAiController AiController = new TicTacToeAiController();

		// Token: 0x04026759 RID: 157529
		protected readonly TicTacToeBoard Board = new TicTacToeBoard();

		// Token: 0x0402675A RID: 157530
		protected readonly int WinLineCount = 3;

		// Token: 0x0402675B RID: 157531
		protected ETicTacToeBoardContent[] CampLoop = new ETicTacToeBoardContent[]
		{
			ETicTacToeBoardContent.White,
			ETicTacToeBoardContent.Black
		};

		// Token: 0x0402675C RID: 157532
		protected readonly ETicTacToeBoardContent PlayerCamp = ETicTacToeBoardContent.White;

		// Token: 0x0402675D RID: 157533
		protected readonly ETicTacToeBoardContent AiCamp = ETicTacToeBoardContent.Black;

		// Token: 0x0402675E RID: 157534
		protected ETicTacToeBoardContent CurrentCamp;

		// Token: 0x0402675F RID: 157535
		protected bool AutoNextRound;

		// Token: 0x04026760 RID: 157536
		private int CurrentRound;

		// Token: 0x04026761 RID: 157537
		private bool IsAiEnable = true;

		// Token: 0x04026762 RID: 157538
		private ETicTacToeBoardContent WinCampInternal;
	}
}
