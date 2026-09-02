using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D28 RID: 23848
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeLevelData
	{
		// Token: 0x17009886 RID: 39046
		// (get) Token: 0x0603C27D RID: 246397 RVA: 0x00F4196E File Offset: 0x00F3FB6E
		// (set) Token: 0x0603C27E RID: 246398 RVA: 0x00F41976 File Offset: 0x00F3FB76
		public int Index
		{
			get
			{
				return this.IndexIntl;
			}
			set
			{
				this.IndexIntl = value;
			}
		}

		// Token: 0x0603C27F RID: 246399 RVA: 0x00F41980 File Offset: 0x00F3FB80
		public FlagChallengeLevelData(int id)
		{
			this.Id = id;
			this.LevelConfig = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(id).Value;
		}

		// Token: 0x0603C280 RID: 246400 RVA: 0x00F419B3 File Offset: 0x00F3FBB3
		public void Refresh(FlagChallengeLevelInfo levelData)
		{
			this.UnlockTime = (double)Singleton<MathUtils>.Instance.LongToNumber(levelData.UnlockTime);
			this.LevelStatus = (EFlagChallengeLevelStatus)levelData.State;
		}

		// Token: 0x0603C281 RID: 246401 RVA: 0x00F419D8 File Offset: 0x00F3FBD8
		public double GetUnlockTime()
		{
			return this.UnlockTime;
		}

		// Token: 0x0603C282 RID: 246402 RVA: 0x00F419E0 File Offset: 0x00F3FBE0
		public double GetRemainTime()
		{
			return Math.Max(0.0, this.UnlockTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp());
		}

		// Token: 0x0603C283 RID: 246403 RVA: 0x00F41A01 File Offset: 0x00F3FC01
		public EFlagChallengeLevelStatus GetLevelStatus()
		{
			return this.LevelStatus;
		}

		// Token: 0x0603C284 RID: 246404 RVA: 0x00F41A09 File Offset: 0x00F3FC09
		public bool IsReachUnlockTime()
		{
			return Singleton<TimeUtil>.Instance.GetServerTimeStamp() >= this.GetUnlockTime();
		}

		// Token: 0x0603C285 RID: 246405 RVA: 0x00F41A20 File Offset: 0x00F3FC20
		public int GetInstanceDungeonId()
		{
			return this.LevelConfig.InstId;
		}

		// Token: 0x0603C286 RID: 246406 RVA: 0x00F41A2D File Offset: 0x00F3FC2D
		public int[] GetPreLevelIds()
		{
			return this.LevelConfig.PreLevelId();
		}

		// Token: 0x0603C287 RID: 246407 RVA: 0x00F41A3A File Offset: 0x00F3FC3A
		public int GetUnlockLevel()
		{
			return this.LevelConfig.UnlockLevel;
		}

		// Token: 0x0603C288 RID: 246408 RVA: 0x00F41A47 File Offset: 0x00F3FC47
		public EFlagChallengeUiStyleType GetUiStyle()
		{
			return (EFlagChallengeUiStyleType)this.LevelConfig.UiStyle;
		}

		// Token: 0x0603C289 RID: 246409 RVA: 0x00F41A54 File Offset: 0x00F3FC54
		public bool IsHiddenLevel()
		{
			return this.LevelConfig.IsHiddenLevel;
		}

		// Token: 0x0603C28A RID: 246410 RVA: 0x00F41A61 File Offset: 0x00F3FC61
		public bool IsHidden()
		{
			return this.IsHiddenLevel() && !ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.LevelConfig.ActivityId).IsAllLevelPassWithoutHidden();
		}

		// Token: 0x0603C28B RID: 246411 RVA: 0x00F41A8A File Offset: 0x00F3FC8A
		public int[] GetRecommendLevel()
		{
			return this.LevelConfig.RecommendLevels();
		}

		// Token: 0x0603C28C RID: 246412 RVA: 0x00F41A97 File Offset: 0x00F3FC97
		public bool IsLocked()
		{
			return this.GetLevelStatus() == EFlagChallengeLevelStatus.Locked;
		}

		// Token: 0x0603C28D RID: 246413 RVA: 0x00F41AA2 File Offset: 0x00F3FCA2
		public bool IsCompleted()
		{
			return this.GetLevelStatus() == EFlagChallengeLevelStatus.Completed;
		}

		// Token: 0x0603C28E RID: 246414 RVA: 0x00F41AAD File Offset: 0x00F3FCAD
		public bool IsUnlocked()
		{
			return this.GetLevelStatus() == EFlagChallengeLevelStatus.Unlocked;
		}

		// Token: 0x04021C22 RID: 138274
		public readonly int Id;

		// Token: 0x04021C23 RID: 138275
		public FlagChallengeLevel LevelConfig;

		// Token: 0x04021C24 RID: 138276
		private int IndexIntl;

		// Token: 0x04021C25 RID: 138277
		private double UnlockTime;

		// Token: 0x04021C26 RID: 138278
		private EFlagChallengeLevelStatus LevelStatus;
	}
}
