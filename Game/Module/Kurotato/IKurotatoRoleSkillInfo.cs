using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A3B RID: 23099
	public interface IKurotatoRoleSkillInfo
	{
		// Token: 0x170094EA RID: 38122
		// (get) Token: 0x0603A78A RID: 239498
		// (set) Token: 0x0603A78B RID: 239499
		int AttrId { get; set; }

		// Token: 0x170094EB RID: 38123
		// (get) Token: 0x0603A78C RID: 239500
		// (set) Token: 0x0603A78D RID: 239501
		int Value { get; set; }

		// Token: 0x170094EC RID: 38124
		// (get) Token: 0x0603A78E RID: 239502
		// (set) Token: 0x0603A78F RID: 239503
		bool IsRecommend { get; set; }

		// Token: 0x170094ED RID: 38125
		// (get) Token: 0x0603A790 RID: 239504
		// (set) Token: 0x0603A791 RID: 239505
		bool? IsAddition { get; set; }

		// Token: 0x170094EE RID: 38126
		// (get) Token: 0x0603A792 RID: 239506
		// (set) Token: 0x0603A793 RID: 239507
		int? BaseValue { get; set; }

		// Token: 0x170094EF RID: 38127
		// (get) Token: 0x0603A794 RID: 239508
		// (set) Token: 0x0603A795 RID: 239509
		bool? IsLocked { get; set; }

		// Token: 0x170094F0 RID: 38128
		// (get) Token: 0x0603A796 RID: 239510
		// (set) Token: 0x0603A797 RID: 239511
		int? LockedValue { get; set; }
	}
}
