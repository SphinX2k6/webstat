using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200625F RID: 25183
	public class TotalTopUpProgressData
	{
		// Token: 0x0603F76F RID: 259951 RVA: 0x01045246 File Offset: 0x01043446
		public void Reset()
		{
			this.Score = 0;
			this.Level.Clear();
		}

		// Token: 0x0603F770 RID: 259952 RVA: 0x0104525A File Offset: 0x0104345A
		public void PushLevel(int level)
		{
			this.Level.Add(level);
		}

		// Token: 0x0603F771 RID: 259953 RVA: 0x01045268 File Offset: 0x01043468
		public void SortLevel()
		{
			this.Level.Sort((int a, int b) => a - b);
			if (this.Level.Count > 0)
			{
				this.MaxScoreByLevel = this.Level[this.Level.Count - 1];
			}
		}

		// Token: 0x0603F772 RID: 259954 RVA: 0x010452CB File Offset: 0x010434CB
		public void SetScore(int score)
		{
			this.Score = score;
		}

		// Token: 0x17009C30 RID: 39984
		// (get) Token: 0x0603F773 RID: 259955 RVA: 0x010452D4 File Offset: 0x010434D4
		public int CurrentScore
		{
			get
			{
				return Math.Min(this.Score, this.MaxScoreByLevel);
			}
		}

		// Token: 0x17009C31 RID: 39985
		// (get) Token: 0x0603F774 RID: 259956 RVA: 0x010452E8 File Offset: 0x010434E8
		public int NextScore
		{
			get
			{
				foreach (int num in this.Level)
				{
					if (num > this.CurrentScore)
					{
						return num;
					}
				}
				if (this.Level.Count <= 0)
				{
					return 0;
				}
				return this.Level[this.Level.Count - 1];
			}
		}

		// Token: 0x040239E7 RID: 145895
		public int Score;

		// Token: 0x040239E8 RID: 145896
		[Nullable(1)]
		public List<int> Level = new List<int>();

		// Token: 0x040239E9 RID: 145897
		private int MaxScoreByLevel;
	}
}
