using System;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B43 RID: 19267
	public class OneExploreItemData : IOneExploreItemData
	{
		// Token: 0x17008646 RID: 34374
		// (get) Token: 0x06032445 RID: 205893 RVA: 0x00C910A0 File Offset: 0x00C8F2A0
		// (set) Token: 0x06032446 RID: 205894 RVA: 0x00C910A8 File Offset: 0x00C8F2A8
		public int ExploreProgressId { get; set; }

		// Token: 0x17008647 RID: 34375
		// (get) Token: 0x06032447 RID: 205895 RVA: 0x00C910B1 File Offset: 0x00C8F2B1
		// (set) Token: 0x06032448 RID: 205896 RVA: 0x00C910B9 File Offset: 0x00C8F2B9
		public float ExplorePercent { get; set; }
	}
}
