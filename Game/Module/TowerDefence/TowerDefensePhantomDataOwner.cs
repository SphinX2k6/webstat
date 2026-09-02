using System;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EBD RID: 20157
	public class TowerDefensePhantomDataOwner : ITowerDefensePhantomDataOwner
	{
		// Token: 0x1700899B RID: 35227
		// (get) Token: 0x06034145 RID: 213317 RVA: 0x00D04A18 File Offset: 0x00D02C18
		// (set) Token: 0x06034146 RID: 213318 RVA: 0x00D04A20 File Offset: 0x00D02C20
		public long PlayerId { get; set; }

		// Token: 0x1700899C RID: 35228
		// (get) Token: 0x06034147 RID: 213319 RVA: 0x00D04A29 File Offset: 0x00D02C29
		// (set) Token: 0x06034148 RID: 213320 RVA: 0x00D04A31 File Offset: 0x00D02C31
		public bool IsSelf { get; set; }

		// Token: 0x1700899D RID: 35229
		// (get) Token: 0x06034149 RID: 213321 RVA: 0x00D04A3A File Offset: 0x00D02C3A
		// (set) Token: 0x0603414A RID: 213322 RVA: 0x00D04A42 File Offset: 0x00D02C42
		public int RoleCfgId { get; set; }

		// Token: 0x1700899E RID: 35230
		// (get) Token: 0x0603414B RID: 213323 RVA: 0x00D04A4B File Offset: 0x00D02C4B
		// (set) Token: 0x0603414C RID: 213324 RVA: 0x00D04A53 File Offset: 0x00D02C53
		public int RoleSkinId { get; set; }

		// Token: 0x1700899F RID: 35231
		// (get) Token: 0x0603414D RID: 213325 RVA: 0x00D04A5C File Offset: 0x00D02C5C
		// (set) Token: 0x0603414E RID: 213326 RVA: 0x00D04A64 File Offset: 0x00D02C64
		public int PhantomId { get; set; }
	}
}
