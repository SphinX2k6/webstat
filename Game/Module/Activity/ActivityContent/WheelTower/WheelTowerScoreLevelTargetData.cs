using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200621E RID: 25118
	public class WheelTowerScoreLevelTargetData
	{
		// Token: 0x0603F61E RID: 259614 RVA: 0x0103EDF6 File Offset: 0x0103CFF6
		public WheelTowerScoreLevelTargetData(int levelId, int score)
		{
			this.LevelId = levelId;
			this.Score = score;
		}

		// Token: 0x17009C0C RID: 39948
		// (get) Token: 0x0603F61F RID: 259615 RVA: 0x0103EE0C File Offset: 0x0103D00C
		// (set) Token: 0x0603F620 RID: 259616 RVA: 0x0103EE14 File Offset: 0x0103D014
		public int LevelId { get; set; }

		// Token: 0x17009C0D RID: 39949
		// (get) Token: 0x0603F621 RID: 259617 RVA: 0x0103EE1D File Offset: 0x0103D01D
		// (set) Token: 0x0603F622 RID: 259618 RVA: 0x0103EE25 File Offset: 0x0103D025
		public int Score { get; set; }
	}
}
