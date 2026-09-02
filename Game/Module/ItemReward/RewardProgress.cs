using System;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B19 RID: 23321
	public class RewardProgress : IRewardProgress
	{
		// Token: 0x170096C0 RID: 38592
		// (get) Token: 0x0603B041 RID: 241729 RVA: 0x00EF268C File Offset: 0x00EF088C
		// (set) Token: 0x0603B042 RID: 241730 RVA: 0x00EF2694 File Offset: 0x00EF0894
		public int FromProgress { get; set; }

		// Token: 0x170096C1 RID: 38593
		// (get) Token: 0x0603B043 RID: 241731 RVA: 0x00EF269D File Offset: 0x00EF089D
		// (set) Token: 0x0603B044 RID: 241732 RVA: 0x00EF26A5 File Offset: 0x00EF08A5
		public int ToProgress { get; set; }

		// Token: 0x170096C2 RID: 38594
		// (get) Token: 0x0603B045 RID: 241733 RVA: 0x00EF26AE File Offset: 0x00EF08AE
		// (set) Token: 0x0603B046 RID: 241734 RVA: 0x00EF26B6 File Offset: 0x00EF08B6
		public int MaxProgress { get; set; }
	}
}
