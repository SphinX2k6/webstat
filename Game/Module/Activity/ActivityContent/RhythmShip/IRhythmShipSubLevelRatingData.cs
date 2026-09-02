using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip
{
	// Token: 0x020064D1 RID: 25809
	[NullableContext(1)]
	public interface IRhythmShipSubLevelRatingData
	{
		// Token: 0x17009E6A RID: 40554
		// (get) Token: 0x06040A6C RID: 264812
		// (set) Token: 0x06040A6D RID: 264813
		int PlayerId { get; set; }

		// Token: 0x17009E6B RID: 40555
		// (get) Token: 0x06040A6E RID: 264814
		// (set) Token: 0x06040A6F RID: 264815
		string NameText { get; set; }

		// Token: 0x17009E6C RID: 40556
		// (get) Token: 0x06040A70 RID: 264816
		// (set) Token: 0x06040A71 RID: 264817
		int RoleId { get; set; }

		// Token: 0x17009E6D RID: 40557
		// (get) Token: 0x06040A72 RID: 264818
		// (set) Token: 0x06040A73 RID: 264819
		int Score { get; set; }

		// Token: 0x17009E6E RID: 40558
		// (get) Token: 0x06040A74 RID: 264820
		// (set) Token: 0x06040A75 RID: 264821
		int Accuracy { get; set; }

		// Token: 0x17009E6F RID: 40559
		// (get) Token: 0x06040A76 RID: 264822
		// (set) Token: 0x06040A77 RID: 264823
		int? RankingNumber { get; set; }
	}
}
