using System;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B15 RID: 23317
	public class TowerDefenceRewardInfo : RewardInfo, ITowerDefenceRewardInfo, IRewardInfo
	{
		// Token: 0x170096AE RID: 38574
		// (get) Token: 0x0603B01B RID: 241691 RVA: 0x00EF25E3 File Offset: 0x00EF07E3
		// (set) Token: 0x0603B01C RID: 241692 RVA: 0x00EF25EB File Offset: 0x00EF07EB
		public bool IsSuccess { get; set; }

		// Token: 0x170096AF RID: 38575
		// (get) Token: 0x0603B01D RID: 241693 RVA: 0x00EF25F4 File Offset: 0x00EF07F4
		// (set) Token: 0x0603B01E RID: 241694 RVA: 0x00EF25FC File Offset: 0x00EF07FC
		public int Score { get; set; }

		// Token: 0x170096B0 RID: 38576
		// (get) Token: 0x0603B01F RID: 241695 RVA: 0x00EF2605 File Offset: 0x00EF0805
		// (set) Token: 0x0603B020 RID: 241696 RVA: 0x00EF260D File Offset: 0x00EF080D
		public int RecordScore { get; set; }
	}
}
