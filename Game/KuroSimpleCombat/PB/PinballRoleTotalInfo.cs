using System;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FC6 RID: 28614
	public class PinballRoleTotalInfo : IPinballRoleTotalInfo
	{
		// Token: 0x1700A4B4 RID: 42164
		// (get) Token: 0x06045364 RID: 283492 RVA: 0x01212088 File Offset: 0x01210288
		// (set) Token: 0x06045365 RID: 283493 RVA: 0x01212090 File Offset: 0x01210290
		public float Damage { get; set; }

		// Token: 0x1700A4B5 RID: 42165
		// (get) Token: 0x06045366 RID: 283494 RVA: 0x01212099 File Offset: 0x01210299
		// (set) Token: 0x06045367 RID: 283495 RVA: 0x012120A1 File Offset: 0x012102A1
		public int SkillTimes { get; set; }

		// Token: 0x1700A4B6 RID: 42166
		// (get) Token: 0x06045368 RID: 283496 RVA: 0x012120AA File Offset: 0x012102AA
		// (set) Token: 0x06045369 RID: 283497 RVA: 0x012120B2 File Offset: 0x012102B2
		public float DropCostHp { get; set; }

		// Token: 0x1700A4B7 RID: 42167
		// (get) Token: 0x0604536A RID: 283498 RVA: 0x012120BB File Offset: 0x012102BB
		// (set) Token: 0x0604536B RID: 283499 RVA: 0x012120C3 File Offset: 0x012102C3
		public float HitCostHp { get; set; }

		// Token: 0x1700A4B8 RID: 42168
		// (get) Token: 0x0604536C RID: 283500 RVA: 0x012120CC File Offset: 0x012102CC
		// (set) Token: 0x0604536D RID: 283501 RVA: 0x012120D4 File Offset: 0x012102D4
		public int DieTimes { get; set; }

		// Token: 0x1700A4B9 RID: 42169
		// (get) Token: 0x0604536E RID: 283502 RVA: 0x012120DD File Offset: 0x012102DD
		// (set) Token: 0x0604536F RID: 283503 RVA: 0x012120E5 File Offset: 0x012102E5
		public int ReviveTimes { get; set; }
	}
}
