using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E4 RID: 26084
	[NullableContext(1)]
	public interface IPinballPlotOptionItemData
	{
		// Token: 0x17009F12 RID: 40722
		// (get) Token: 0x0604128A RID: 266890
		// (set) Token: 0x0604128B RID: 266891
		int OptionIndex { get; set; }

		// Token: 0x17009F13 RID: 40723
		// (get) Token: 0x0604128C RID: 266892
		// (set) Token: 0x0604128D RID: 266893
		TableTextArgNew OptionText { get; set; }

		// Token: 0x17009F14 RID: 40724
		// (get) Token: 0x0604128E RID: 266894
		// (set) Token: 0x0604128F RID: 266895
		Action<int> OptionDelegate { get; set; }
	}
}
