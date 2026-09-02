using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA3 RID: 19875
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseSelectBranchData : ITrapDefenseSelectBranchData
	{
		// Token: 0x17008811 RID: 34833
		// (get) Token: 0x0603379D RID: 210845 RVA: 0x00CDFA9D File Offset: 0x00CDDC9D
		// (set) Token: 0x0603379E RID: 210846 RVA: 0x00CDFAA5 File Offset: 0x00CDDCA5
		public bool IsInDungeon { get; set; }

		// Token: 0x17008812 RID: 34834
		// (get) Token: 0x0603379F RID: 210847 RVA: 0x00CDFAAE File Offset: 0x00CDDCAE
		// (set) Token: 0x060337A0 RID: 210848 RVA: 0x00CDFAB6 File Offset: 0x00CDDCB6
		public TrapDefenseBuildingDevelopItemData Data { get; set; }
	}
}
