using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x02006885 RID: 26757
	public class DropCatchLevelData
	{
		// Token: 0x1700A1B3 RID: 41395
		// (get) Token: 0x06042AB2 RID: 273074 RVA: 0x0111D1CA File Offset: 0x0111B3CA
		public bool IsUnlock
		{
			get
			{
				return this.UnlockTime <= Singleton<TimeUtil>.Instance.GetServerTime();
			}
		}

		// Token: 0x06042AB3 RID: 273075 RVA: 0x0111D1E1 File Offset: 0x0111B3E1
		public EDropCatchLevelState? GetTargetStarState(int starIndex)
		{
			if (this.RewardStates == null || this.RewardStates.Count == 0)
			{
				return new EDropCatchLevelState?(EDropCatchLevelState.Lock);
			}
			return new EDropCatchLevelState?(this.RewardStates[starIndex]);
		}

		// Token: 0x1700A1B4 RID: 41396
		// (get) Token: 0x06042AB4 RID: 273076 RVA: 0x0111D210 File Offset: 0x0111B410
		public bool IsAllRewarded
		{
			get
			{
				if (this.RewardStates == null || this.RewardStates.Count == 0)
				{
					return false;
				}
				using (List<EDropCatchLevelState>.Enumerator enumerator = this.RewardStates.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current != EDropCatchLevelState.Rewarded)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		// Token: 0x1700A1B5 RID: 41397
		// (get) Token: 0x06042AB5 RID: 273077 RVA: 0x0111D27C File Offset: 0x0111B47C
		public bool IsAllStar
		{
			get
			{
				if (this.RewardStates == null || this.RewardStates.Count == 0)
				{
					return false;
				}
				using (List<EDropCatchLevelState>.Enumerator enumerator = this.RewardStates.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == EDropCatchLevelState.Lock)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		// Token: 0x1700A1B6 RID: 41398
		// (get) Token: 0x06042AB6 RID: 273078 RVA: 0x0111D2E8 File Offset: 0x0111B4E8
		public bool HasAnyStar
		{
			get
			{
				if (this.RewardStates == null || this.RewardStates.Count == 0)
				{
					return false;
				}
				foreach (EDropCatchLevelState edropCatchLevelState in this.RewardStates)
				{
					if (edropCatchLevelState == EDropCatchLevelState.Unlock || edropCatchLevelState == EDropCatchLevelState.Rewarded)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x1700A1B7 RID: 41399
		// (get) Token: 0x06042AB7 RID: 273079 RVA: 0x0111D35C File Offset: 0x0111B55C
		public bool CanReceiveReward
		{
			get
			{
				if (this.RewardStates == null || this.RewardStates.Count == 0)
				{
					return false;
				}
				using (List<EDropCatchLevelState>.Enumerator enumerator = this.RewardStates.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == EDropCatchLevelState.Unlock)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x040251CE RID: 152014
		public int ConfigId;

		// Token: 0x040251CF RID: 152015
		public double UnlockTime;

		// Token: 0x040251D0 RID: 152016
		public int HighestScore;

		// Token: 0x040251D1 RID: 152017
		[Nullable(1)]
		public List<EDropCatchLevelState> RewardStates = new List<EDropCatchLevelState>();
	}
}
