using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D25 RID: 23845
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeAreaData
	{
		// Token: 0x0603C227 RID: 246311 RVA: 0x00F40694 File Offset: 0x00F3E894
		public FlagChallengeAreaData(int id, int activityId)
		{
			this.Id = id;
			this.ActivityId = activityId;
			this.Config = ConfigBase<FlagChallengeConfig>.Instance.GetAreaConfig(id).Value;
		}

		// Token: 0x0603C228 RID: 246312 RVA: 0x00F406CE File Offset: 0x00F3E8CE
		public int GetLevelId()
		{
			return this.Config.LevelId;
		}

		// Token: 0x0603C229 RID: 246313 RVA: 0x00F406DB File Offset: 0x00F3E8DB
		public int[] GetStrongholds()
		{
			return this.Config.Strongholds();
		}

		// Token: 0x0603C22A RID: 246314 RVA: 0x00F406E8 File Offset: 0x00F3E8E8
		public int[] GetRecommendLevel()
		{
			return this.Config.RecommendLevels();
		}

		// Token: 0x0603C22B RID: 246315 RVA: 0x00F406F5 File Offset: 0x00F3E8F5
		public int GetAreaItemPos()
		{
			return this.Config.UiPos;
		}

		// Token: 0x04021C08 RID: 138248
		public readonly int ActivityId;

		// Token: 0x04021C09 RID: 138249
		public readonly int Id;

		// Token: 0x04021C0A RID: 138250
		public FlagChallengeArea Config;
	}
}
