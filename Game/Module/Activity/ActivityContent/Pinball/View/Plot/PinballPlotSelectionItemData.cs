using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E8 RID: 26088
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballPlotSelectionItemData : IPinballPlotSelectionItemData
	{
		// Token: 0x17009F1A RID: 40730
		// (get) Token: 0x0604129F RID: 266911 RVA: 0x010B7631 File Offset: 0x010B5831
		// (set) Token: 0x060412A0 RID: 266912 RVA: 0x010B7639 File Offset: 0x010B5839
		public int OptionIndex { get; set; }

		// Token: 0x17009F1B RID: 40731
		// (get) Token: 0x060412A1 RID: 266913 RVA: 0x010B7642 File Offset: 0x010B5842
		// (set) Token: 0x060412A2 RID: 266914 RVA: 0x010B764A File Offset: 0x010B584A
		public Action<int> OptionDelegate { get; set; }
	}
}
