using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.ExploreLevel
{
	// Token: 0x02005D8D RID: 23949
	[NullableContext(1)]
	[Nullable(0)]
	public class CountryExploreLevelRewardData
	{
		// Token: 0x0603C4D4 RID: 246996 RVA: 0x00F4DAC0 File Offset: 0x00F4BCC0
		public void Initialize(ExploreReward exploreRewardConfig)
		{
			this.ScoreName = exploreRewardConfig.ScoreName;
			this.RewardNameId = exploreRewardConfig.Reward;
			this.ScoreTexturePath = exploreRewardConfig.ScoreTexturePath;
			this.ShowItem = exploreRewardConfig.ShowItem;
			this.NeedScore = exploreRewardConfig.NeedScore;
			this.DropId = exploreRewardConfig.Drop;
			this.UnlockSpritePath = exploreRewardConfig.Pic;
			this.ExploreLevel = exploreRewardConfig.ExploreLevel;
			this.ShowUnlockSprite = exploreRewardConfig.Show;
			this.HelpId = exploreRewardConfig.Help;
			int country = exploreRewardConfig.Country;
			this.CountryNameId = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(country).Value.Title;
		}

		// Token: 0x0603C4D5 RID: 246997 RVA: 0x00F4DB78 File Offset: 0x00F4BD78
		public string GetScoreNameId()
		{
			return this.ScoreName;
		}

		// Token: 0x0603C4D6 RID: 246998 RVA: 0x00F4DB80 File Offset: 0x00F4BD80
		public string GetRewardNameId()
		{
			return this.RewardNameId;
		}

		// Token: 0x0603C4D7 RID: 246999 RVA: 0x00F4DB88 File Offset: 0x00F4BD88
		public string GetScoreTexturePath()
		{
			return this.ScoreTexturePath;
		}

		// Token: 0x0603C4D8 RID: 247000 RVA: 0x00F4DB90 File Offset: 0x00F4BD90
		public int GetPreviewItemConfigId()
		{
			return this.ShowItem;
		}

		// Token: 0x0603C4D9 RID: 247001 RVA: 0x00F4DB98 File Offset: 0x00F4BD98
		public int GetMaxExploreScore()
		{
			return this.NeedScore;
		}

		// Token: 0x0603C4DA RID: 247002 RVA: 0x00F4DBA0 File Offset: 0x00F4BDA0
		public string GetCountryNameId()
		{
			return this.CountryNameId;
		}

		// Token: 0x0603C4DB RID: 247003 RVA: 0x00F4DBA8 File Offset: 0x00F4BDA8
		[NullableContext(2)]
		public Dictionary<int, int> GetDropItemNumMap()
		{
			return ConfigBase<ExploreLevelConfig>.Instance.GetDropShowInfo(this.DropId);
		}

		// Token: 0x0603C4DC RID: 247004 RVA: 0x00F4DBBA File Offset: 0x00F4BDBA
		public int GetExploreLevel()
		{
			return this.ExploreLevel;
		}

		// Token: 0x0603C4DD RID: 247005 RVA: 0x00F4DBC2 File Offset: 0x00F4BDC2
		public string GetUnlockSpritePath()
		{
			return this.UnlockSpritePath;
		}

		// Token: 0x0603C4DE RID: 247006 RVA: 0x00F4DBCA File Offset: 0x00F4BDCA
		public bool IsShowUnlockSprite()
		{
			return this.ShowUnlockSprite;
		}

		// Token: 0x0603C4DF RID: 247007 RVA: 0x00F4DBD2 File Offset: 0x00F4BDD2
		public int GetHelpId()
		{
			return this.HelpId;
		}

		// Token: 0x04021E95 RID: 138901
		private string ScoreName = "";

		// Token: 0x04021E96 RID: 138902
		private string RewardNameId = "";

		// Token: 0x04021E97 RID: 138903
		private string ScoreTexturePath = "";

		// Token: 0x04021E98 RID: 138904
		private int ShowItem;

		// Token: 0x04021E99 RID: 138905
		private int NeedScore;

		// Token: 0x04021E9A RID: 138906
		private int DropId;

		// Token: 0x04021E9B RID: 138907
		private string UnlockSpritePath = "";

		// Token: 0x04021E9C RID: 138908
		private int ExploreLevel;

		// Token: 0x04021E9D RID: 138909
		private bool ShowUnlockSprite;

		// Token: 0x04021E9E RID: 138910
		private int HelpId;

		// Token: 0x04021E9F RID: 138911
		private string CountryNameId = "";
	}
}
