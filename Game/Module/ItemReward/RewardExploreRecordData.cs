using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B25 RID: 23333
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreRecordData : IRewardExploreRecord
	{
		// Token: 0x170096DF RID: 38623
		// (get) Token: 0x0603B085 RID: 241797 RVA: 0x00EF27BB File Offset: 0x00EF09BB
		// (set) Token: 0x0603B086 RID: 241798 RVA: 0x00EF27C3 File Offset: 0x00EF09C3
		public string TitleTextId { get; set; }

		// Token: 0x170096E0 RID: 38624
		// (get) Token: 0x0603B087 RID: 241799 RVA: 0x00EF27CC File Offset: 0x00EF09CC
		// (set) Token: 0x0603B088 RID: 241800 RVA: 0x00EF27D4 File Offset: 0x00EF09D4
		public string Record { get; set; }

		// Token: 0x170096E1 RID: 38625
		// (get) Token: 0x0603B089 RID: 241801 RVA: 0x00EF27DD File Offset: 0x00EF09DD
		// (set) Token: 0x0603B08A RID: 241802 RVA: 0x00EF27E5 File Offset: 0x00EF09E5
		public int? RecordRollingTo { get; set; }

		// Token: 0x170096E2 RID: 38626
		// (get) Token: 0x0603B08B RID: 241803 RVA: 0x00EF27EE File Offset: 0x00EF09EE
		// (set) Token: 0x0603B08C RID: 241804 RVA: 0x00EF27F6 File Offset: 0x00EF09F6
		public bool IsNewRecord { get; set; }
	}
}
