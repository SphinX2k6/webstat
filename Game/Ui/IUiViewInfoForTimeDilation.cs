using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B5 RID: 18869
	[NullableContext(1)]
	public interface IUiViewInfoForTimeDilation
	{
		// Token: 0x1700840A RID: 33802
		// (get) Token: 0x06031512 RID: 202002
		// (set) Token: 0x06031513 RID: 202003
		float TimeDilation { get; set; }

		// Token: 0x1700840B RID: 33803
		// (get) Token: 0x06031514 RID: 202004
		// (set) Token: 0x06031515 RID: 202005
		int ViewId { get; set; }

		// Token: 0x1700840C RID: 33804
		// (get) Token: 0x06031516 RID: 202006
		// (set) Token: 0x06031517 RID: 202007
		EUiViewName? DebugName { get; set; }

		// Token: 0x1700840D RID: 33805
		// (get) Token: 0x06031518 RID: 202008
		// (set) Token: 0x06031519 RID: 202009
		string Reason { get; set; }
	}
}
