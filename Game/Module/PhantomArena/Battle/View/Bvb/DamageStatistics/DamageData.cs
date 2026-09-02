using System;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb.DamageStatistics
{
	// Token: 0x020055DD RID: 21981
	public class DamageData : IDamageData
	{
		// Token: 0x17008FF7 RID: 36855
		// (get) Token: 0x06038031 RID: 229425 RVA: 0x00E308EF File Offset: 0x00E2EAEF
		// (set) Token: 0x06038032 RID: 229426 RVA: 0x00E308F7 File Offset: 0x00E2EAF7
		public long EntityId { get; set; }

		// Token: 0x17008FF8 RID: 36856
		// (get) Token: 0x06038033 RID: 229427 RVA: 0x00E30900 File Offset: 0x00E2EB00
		// (set) Token: 0x06038034 RID: 229428 RVA: 0x00E30908 File Offset: 0x00E2EB08
		public int Damage { get; set; }
	}
}
