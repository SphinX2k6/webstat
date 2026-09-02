using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD0 RID: 19920
	public interface ITrapDefenseDevelopBranchSelectInfo
	{
		// Token: 0x1700884A RID: 34890
		// (get) Token: 0x060338F6 RID: 211190
		// (set) Token: 0x060338F7 RID: 211191
		int Id { get; set; }

		// Token: 0x1700884B RID: 34891
		// (get) Token: 0x060338F8 RID: 211192
		// (set) Token: 0x060338F9 RID: 211193
		bool IsCurLevel { get; set; }

		// Token: 0x1700884C RID: 34892
		// (get) Token: 0x060338FA RID: 211194
		// (set) Token: 0x060338FB RID: 211195
		bool IsSelected { get; set; }
	}
}
