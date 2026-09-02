using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;

namespace CSharpScript.Game.Module.ExploreLevel
{
	// Token: 0x02005D8E RID: 23950
	public class CountryExploreScoreData
	{
		// Token: 0x0603C4E1 RID: 247009 RVA: 0x00F4DC19 File Offset: 0x00F4BE19
		public void Initialize(int countryId, int areaId, int progress, int lastProgress, int score)
		{
			this.CountryId = countryId;
			this.AreaId = areaId;
			this.Progress = progress;
			this.LastProgress = lastProgress;
			this.Score = score;
			this.IsReceived = false;
			this.AreaConfig = ConfigBase<CSharpScript.Game.Module.Area.AreaConfig>.Instance.GetAreaInfo(areaId);
		}

		// Token: 0x0603C4E2 RID: 247010 RVA: 0x00F4DC58 File Offset: 0x00F4BE58
		public void SetReceived(bool bReceived)
		{
			this.IsReceived = bReceived;
		}

		// Token: 0x0603C4E3 RID: 247011 RVA: 0x00F4DC61 File Offset: 0x00F4BE61
		public bool GetIsReceived()
		{
			return this.IsReceived;
		}

		// Token: 0x0603C4E4 RID: 247012 RVA: 0x00F4DC6C File Offset: 0x00F4BE6C
		[NullableContext(1)]
		public string GetAreaNameTextId()
		{
			return this.AreaConfig.Value.Title;
		}

		// Token: 0x0603C4E5 RID: 247013 RVA: 0x00F4DC8C File Offset: 0x00F4BE8C
		public Area? GetAreaConfig()
		{
			return this.AreaConfig;
		}

		// Token: 0x0603C4E6 RID: 247014 RVA: 0x00F4DC94 File Offset: 0x00F4BE94
		public bool CanReceive()
		{
			return this.GetAreaProgress() >= this.Progress && !this.IsReceived;
		}

		// Token: 0x0603C4E7 RID: 247015 RVA: 0x00F4DCAF File Offset: 0x00F4BEAF
		public int GetAreaProgress()
		{
			return ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(this.AreaId).GetProgress();
		}

		// Token: 0x04021EA0 RID: 138912
		public int CountryId;

		// Token: 0x04021EA1 RID: 138913
		public int AreaId;

		// Token: 0x04021EA2 RID: 138914
		public int Progress;

		// Token: 0x04021EA3 RID: 138915
		public int LastProgress;

		// Token: 0x04021EA4 RID: 138916
		public int Score;

		// Token: 0x04021EA5 RID: 138917
		private bool IsReceived;

		// Token: 0x04021EA6 RID: 138918
		private Area? AreaConfig;
	}
}
