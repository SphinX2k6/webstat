using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E5 RID: 26085
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballPlotOptionItemData : IPinballPlotOptionItemData
	{
		// Token: 0x17009F15 RID: 40725
		// (get) Token: 0x06041290 RID: 266896 RVA: 0x010B7495 File Offset: 0x010B5695
		// (set) Token: 0x06041291 RID: 266897 RVA: 0x010B749D File Offset: 0x010B569D
		public int OptionIndex { get; set; }

		// Token: 0x17009F16 RID: 40726
		// (get) Token: 0x06041292 RID: 266898 RVA: 0x010B74A6 File Offset: 0x010B56A6
		// (set) Token: 0x06041293 RID: 266899 RVA: 0x010B74AE File Offset: 0x010B56AE
		public TableTextArgNew OptionText { get; set; }

		// Token: 0x17009F17 RID: 40727
		// (get) Token: 0x06041294 RID: 266900 RVA: 0x010B74B7 File Offset: 0x010B56B7
		// (set) Token: 0x06041295 RID: 266901 RVA: 0x010B74BF File Offset: 0x010B56BF
		public Action<int> OptionDelegate { get; set; }
	}
}
