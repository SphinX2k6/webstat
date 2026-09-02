using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip
{
	// Token: 0x020064D2 RID: 25810
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipSubLevelRatingData : IRhythmShipSubLevelRatingData
	{
		// Token: 0x17009E70 RID: 40560
		// (get) Token: 0x06040A78 RID: 264824 RVA: 0x01092B75 File Offset: 0x01090D75
		// (set) Token: 0x06040A79 RID: 264825 RVA: 0x01092B7D File Offset: 0x01090D7D
		public int PlayerId { get; set; }

		// Token: 0x17009E71 RID: 40561
		// (get) Token: 0x06040A7A RID: 264826 RVA: 0x01092B86 File Offset: 0x01090D86
		// (set) Token: 0x06040A7B RID: 264827 RVA: 0x01092B8E File Offset: 0x01090D8E
		public string NameText { get; set; }

		// Token: 0x17009E72 RID: 40562
		// (get) Token: 0x06040A7C RID: 264828 RVA: 0x01092B97 File Offset: 0x01090D97
		// (set) Token: 0x06040A7D RID: 264829 RVA: 0x01092B9F File Offset: 0x01090D9F
		public int RoleId { get; set; }

		// Token: 0x17009E73 RID: 40563
		// (get) Token: 0x06040A7E RID: 264830 RVA: 0x01092BA8 File Offset: 0x01090DA8
		// (set) Token: 0x06040A7F RID: 264831 RVA: 0x01092BB0 File Offset: 0x01090DB0
		public int Score { get; set; }

		// Token: 0x17009E74 RID: 40564
		// (get) Token: 0x06040A80 RID: 264832 RVA: 0x01092BB9 File Offset: 0x01090DB9
		// (set) Token: 0x06040A81 RID: 264833 RVA: 0x01092BC1 File Offset: 0x01090DC1
		public int Accuracy { get; set; }

		// Token: 0x17009E75 RID: 40565
		// (get) Token: 0x06040A82 RID: 264834 RVA: 0x01092BCA File Offset: 0x01090DCA
		// (set) Token: 0x06040A83 RID: 264835 RVA: 0x01092BD2 File Offset: 0x01090DD2
		public int? RankingNumber { get; set; }
	}
}
