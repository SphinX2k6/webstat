using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C92 RID: 23698
	[NullableContext(1)]
	public interface IHonamiStoryAttrData
	{
		// Token: 0x17009812 RID: 38930
		// (get) Token: 0x0603BD68 RID: 245096
		// (set) Token: 0x0603BD69 RID: 245097
		string Name { get; set; }

		// Token: 0x17009813 RID: 38931
		// (get) Token: 0x0603BD6A RID: 245098
		// (set) Token: 0x0603BD6B RID: 245099
		string IconPath { get; set; }

		// Token: 0x17009814 RID: 38932
		// (get) Token: 0x0603BD6C RID: 245100
		// (set) Token: 0x0603BD6D RID: 245101
		int OldValue { get; set; }

		// Token: 0x17009815 RID: 38933
		// (get) Token: 0x0603BD6E RID: 245102
		// (set) Token: 0x0603BD6F RID: 245103
		int NewValue { get; set; }

		// Token: 0x17009816 RID: 38934
		// (get) Token: 0x0603BD70 RID: 245104
		// (set) Token: 0x0603BD71 RID: 245105
		bool IsPercent { get; set; }
	}
}
