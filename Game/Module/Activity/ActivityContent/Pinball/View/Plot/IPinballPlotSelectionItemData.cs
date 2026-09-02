using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E7 RID: 26087
	[NullableContext(1)]
	public interface IPinballPlotSelectionItemData
	{
		// Token: 0x17009F18 RID: 40728
		// (get) Token: 0x0604129B RID: 266907
		// (set) Token: 0x0604129C RID: 266908
		int OptionIndex { get; set; }

		// Token: 0x17009F19 RID: 40729
		// (get) Token: 0x0604129D RID: 266909
		// (set) Token: 0x0604129E RID: 266910
		Action<int> OptionDelegate { get; set; }
	}
}
