using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200620B RID: 25099
	[NullableContext(1)]
	public interface IWheelTowerCoverRecordData
	{
		// Token: 0x17009B8B RID: 39819
		// (get) Token: 0x0603F512 RID: 259346
		// (set) Token: 0x0603F513 RID: 259347
		int TotalScore { get; set; }

		// Token: 0x17009B8C RID: 39820
		// (get) Token: 0x0603F514 RID: 259348
		// (set) Token: 0x0603F515 RID: 259349
		int TeamScore { get; set; }

		// Token: 0x17009B8D RID: 39821
		// (get) Token: 0x0603F516 RID: 259350
		// (set) Token: 0x0603F517 RID: 259351
		List<int> TeamRoleIdList { get; set; }

		// Token: 0x17009B8E RID: 39822
		// (get) Token: 0x0603F518 RID: 259352
		// (set) Token: 0x0603F519 RID: 259353
		int BuffId { get; set; }

		// Token: 0x17009B8F RID: 39823
		// (get) Token: 0x0603F51A RID: 259354
		// (set) Token: 0x0603F51B RID: 259355
		int BossRound { get; set; }

		// Token: 0x17009B90 RID: 39824
		// (get) Token: 0x0603F51C RID: 259356
		// (set) Token: 0x0603F51D RID: 259357
		int BossWave { get; set; }

		// Token: 0x17009B91 RID: 39825
		// (get) Token: 0x0603F51E RID: 259358
		// (set) Token: 0x0603F51F RID: 259359
		int NeedChallengeBossWaveNum { get; set; }

		// Token: 0x17009B92 RID: 39826
		// (get) Token: 0x0603F520 RID: 259360
		// (set) Token: 0x0603F521 RID: 259361
		int AddTeamScore { get; set; }
	}
}
