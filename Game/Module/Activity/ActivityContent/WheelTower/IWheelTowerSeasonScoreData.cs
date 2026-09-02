using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006213 RID: 25107
	[NullableContext(1)]
	public interface IWheelTowerSeasonScoreData
	{
		// Token: 0x17009BBD RID: 39869
		// (get) Token: 0x0603F57A RID: 259450
		// (set) Token: 0x0603F57B RID: 259451
		int Score { get; set; }

		// Token: 0x17009BBE RID: 39870
		// (get) Token: 0x0603F57C RID: 259452
		// (set) Token: 0x0603F57D RID: 259453
		int PrevScore { get; set; }

		// Token: 0x17009BBF RID: 39871
		// (get) Token: 0x0603F57E RID: 259454
		// (set) Token: 0x0603F57F RID: 259455
		int TotalScore { get; set; }

		// Token: 0x17009BC0 RID: 39872
		// (get) Token: 0x0603F580 RID: 259456
		// (set) Token: 0x0603F581 RID: 259457
		int CurScore { get; set; }

		// Token: 0x17009BC1 RID: 39873
		// (get) Token: 0x0603F582 RID: 259458
		// (set) Token: 0x0603F583 RID: 259459
		bool IsReceived { get; set; }

		// Token: 0x17009BC2 RID: 39874
		// (get) Token: 0x0603F584 RID: 259460
		// (set) Token: 0x0603F585 RID: 259461
		int DropId { get; set; }

		// Token: 0x17009BC3 RID: 39875
		// (get) Token: 0x0603F586 RID: 259462
		// (set) Token: 0x0603F587 RID: 259463
		int MotorPreviewId { get; set; }

		// Token: 0x17009BC4 RID: 39876
		// (get) Token: 0x0603F588 RID: 259464
		// (set) Token: 0x0603F589 RID: 259465
		int WeaponPreviewId { get; set; }

		// Token: 0x17009BC5 RID: 39877
		// (get) Token: 0x0603F58A RID: 259466
		// (set) Token: 0x0603F58B RID: 259467
		string PreviewIcon { get; set; }
	}
}
