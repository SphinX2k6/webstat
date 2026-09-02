using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C93 RID: 23699
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiStoryAttrData : IHonamiStoryAttrData
	{
		// Token: 0x17009817 RID: 38935
		// (get) Token: 0x0603BD72 RID: 245106 RVA: 0x00F2B405 File Offset: 0x00F29605
		// (set) Token: 0x0603BD73 RID: 245107 RVA: 0x00F2B40D File Offset: 0x00F2960D
		public string Name { get; set; } = string.Empty;

		// Token: 0x17009818 RID: 38936
		// (get) Token: 0x0603BD74 RID: 245108 RVA: 0x00F2B416 File Offset: 0x00F29616
		// (set) Token: 0x0603BD75 RID: 245109 RVA: 0x00F2B41E File Offset: 0x00F2961E
		public string IconPath { get; set; } = string.Empty;

		// Token: 0x17009819 RID: 38937
		// (get) Token: 0x0603BD76 RID: 245110 RVA: 0x00F2B427 File Offset: 0x00F29627
		// (set) Token: 0x0603BD77 RID: 245111 RVA: 0x00F2B42F File Offset: 0x00F2962F
		public int OldValue { get; set; }

		// Token: 0x1700981A RID: 38938
		// (get) Token: 0x0603BD78 RID: 245112 RVA: 0x00F2B438 File Offset: 0x00F29638
		// (set) Token: 0x0603BD79 RID: 245113 RVA: 0x00F2B440 File Offset: 0x00F29640
		public int NewValue { get; set; }

		// Token: 0x1700981B RID: 38939
		// (get) Token: 0x0603BD7A RID: 245114 RVA: 0x00F2B449 File Offset: 0x00F29649
		// (set) Token: 0x0603BD7B RID: 245115 RVA: 0x00F2B451 File Offset: 0x00F29651
		public bool IsPercent { get; set; }
	}
}
