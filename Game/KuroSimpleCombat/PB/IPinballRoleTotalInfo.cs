using System;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FC5 RID: 28613
	public interface IPinballRoleTotalInfo
	{
		// Token: 0x1700A4AE RID: 42158
		// (get) Token: 0x06045358 RID: 283480
		// (set) Token: 0x06045359 RID: 283481
		float Damage { get; set; }

		// Token: 0x1700A4AF RID: 42159
		// (get) Token: 0x0604535A RID: 283482
		// (set) Token: 0x0604535B RID: 283483
		int SkillTimes { get; set; }

		// Token: 0x1700A4B0 RID: 42160
		// (get) Token: 0x0604535C RID: 283484
		// (set) Token: 0x0604535D RID: 283485
		float DropCostHp { get; set; }

		// Token: 0x1700A4B1 RID: 42161
		// (get) Token: 0x0604535E RID: 283486
		// (set) Token: 0x0604535F RID: 283487
		float HitCostHp { get; set; }

		// Token: 0x1700A4B2 RID: 42162
		// (get) Token: 0x06045360 RID: 283488
		// (set) Token: 0x06045361 RID: 283489
		int DieTimes { get; set; }

		// Token: 0x1700A4B3 RID: 42163
		// (get) Token: 0x06045362 RID: 283490
		// (set) Token: 0x06045363 RID: 283491
		int ReviveTimes { get; set; }
	}
}
