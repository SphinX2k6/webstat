using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B2 RID: 25266
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisScoreData
	{
		// Token: 0x0603F95D RID: 260445 RVA: 0x0104C06C File Offset: 0x0104A26C
		public void Reset()
		{
			this.CurrentScore = 0;
			this.LastClearTurn = -999;
			this.ComboCount = 0;
			this.MaxComboCount = 0;
		}

		// Token: 0x0603F95E RID: 260446 RVA: 0x0104C090 File Offset: 0x0104A290
		public int Calculate(int linesCleared, bool isBoardEmpty, int currentTurn)
		{
			if (linesCleared <= 0)
			{
				if (currentTurn - this.LastClearTurn >= 2)
				{
					this.ComboCount = 0;
				}
				return 0;
			}
			TetrisSetting value = ConfigBase<ActivityTetrisConfig>.Instance.GetSetting("BasicScore").Value;
			if (linesCleared > value.BasicScoreLength)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Log;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "消除行数没有对应的分数";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("行数", linesCleared);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			int num = value.BasicScore(linesCleared - 1);
			if (isBoardEmpty)
			{
				num += ConfigBase<ActivityTetrisConfig>.Instance.GetSetting("AllClear").Value.AllClear;
			}
			if (currentTurn - this.LastClearTurn < 2)
			{
				this.ComboCount++;
			}
			else
			{
				this.ComboCount = 1;
			}
			this.ComboCount = Math.Min(ConfigBase<ActivityTetrisConfig>.Instance.GetSetting("ComboAddation").Value.ComboAddationLength, this.ComboCount);
			if (this.ComboCount > this.MaxComboCount)
			{
				this.MaxComboCount = this.ComboCount;
			}
			int num2 = 100 + ConfigBase<ActivityTetrisConfig>.Instance.GetSetting("ComboAddation").Value.ComboAddation(this.ComboCount - 1);
			num = (int)Math.Floor((double)(num * num2) / 100.0);
			this.LastClearTurn = currentTurn;
			int currentScore = this.CurrentScore;
			this.CurrentScore = Math.Min(this.CurrentScore + num, TetrisScoreData.MaxScore);
			return this.CurrentScore - currentScore;
		}

		// Token: 0x0603F95F RID: 260447 RVA: 0x0104C215 File Offset: 0x0104A415
		public int GetScore()
		{
			return this.CurrentScore;
		}

		// Token: 0x0603F960 RID: 260448 RVA: 0x0104C21D File Offset: 0x0104A41D
		public void AddScore(int score)
		{
			this.CurrentScore = Math.Min(this.CurrentScore + score, TetrisScoreData.MaxScore);
		}

		// Token: 0x0603F961 RID: 260449 RVA: 0x0104C237 File Offset: 0x0104A437
		public int GetComboCount()
		{
			return this.ComboCount;
		}

		// Token: 0x0603F962 RID: 260450 RVA: 0x0104C23F File Offset: 0x0104A43F
		public void SetComboCount(int count, int roundIndex)
		{
			this.ComboCount = count;
			this.LastClearTurn = roundIndex;
			if (this.ComboCount > this.MaxComboCount)
			{
				this.MaxComboCount = this.ComboCount;
			}
		}

		// Token: 0x0603F963 RID: 260451 RVA: 0x0104C269 File Offset: 0x0104A469
		public int GetMaxComboCount()
		{
			return this.MaxComboCount;
		}

		// Token: 0x0603F964 RID: 260452 RVA: 0x0104C271 File Offset: 0x0104A471
		public ITetrisScoreSnapshot CreateSnapshot()
		{
			return new TetrisScoreSnapshot
			{
				CurrentScore = this.CurrentScore,
				LastClearTurn = this.LastClearTurn,
				ComboCount = this.ComboCount,
				MaxComboCount = this.MaxComboCount
			};
		}

		// Token: 0x0603F965 RID: 260453 RVA: 0x0104C2A8 File Offset: 0x0104A4A8
		public void RestoreFromSnapshot(ITetrisScoreSnapshot snapshot)
		{
			this.CurrentScore = Math.Min(snapshot.CurrentScore, TetrisScoreData.MaxScore);
			this.LastClearTurn = snapshot.LastClearTurn;
			this.ComboCount = snapshot.ComboCount;
			this.MaxComboCount = snapshot.MaxComboCount;
		}

		// Token: 0x04023B01 RID: 146177
		private static readonly int MaxScore = 999999;

		// Token: 0x04023B02 RID: 146178
		private int CurrentScore;

		// Token: 0x04023B03 RID: 146179
		private int LastClearTurn = -999;

		// Token: 0x04023B04 RID: 146180
		private int ComboCount;

		// Token: 0x04023B05 RID: 146181
		private int MaxComboCount;
	}
}
