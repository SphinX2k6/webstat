using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA2 RID: 19874
	[NullableContext(1)]
	public interface ITrapDefenseSelectBranchData
	{
		// Token: 0x1700880F RID: 34831
		// (get) Token: 0x06033799 RID: 210841
		// (set) Token: 0x0603379A RID: 210842
		bool IsInDungeon { get; set; }

		// Token: 0x17008810 RID: 34832
		// (get) Token: 0x0603379B RID: 210843
		// (set) Token: 0x0603379C RID: 210844
		TrapDefenseBuildingDevelopItemData Data { get; set; }
	}
}
