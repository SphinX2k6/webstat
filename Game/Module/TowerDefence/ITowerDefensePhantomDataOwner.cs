using System;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EBC RID: 20156
	public interface ITowerDefensePhantomDataOwner
	{
		// Token: 0x17008996 RID: 35222
		// (get) Token: 0x0603413B RID: 213307
		// (set) Token: 0x0603413C RID: 213308
		long PlayerId { get; set; }

		// Token: 0x17008997 RID: 35223
		// (get) Token: 0x0603413D RID: 213309
		// (set) Token: 0x0603413E RID: 213310
		bool IsSelf { get; set; }

		// Token: 0x17008998 RID: 35224
		// (get) Token: 0x0603413F RID: 213311
		// (set) Token: 0x06034140 RID: 213312
		int RoleCfgId { get; set; }

		// Token: 0x17008999 RID: 35225
		// (get) Token: 0x06034141 RID: 213313
		// (set) Token: 0x06034142 RID: 213314
		int RoleSkinId { get; set; }

		// Token: 0x1700899A RID: 35226
		// (get) Token: 0x06034143 RID: 213315
		// (set) Token: 0x06034144 RID: 213316
		int PhantomId { get; set; }
	}
}
