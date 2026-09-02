using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C89 RID: 23689
	[NullableContext(1)]
	public interface IHonamiStoryItemSellInfo
	{
		// Token: 0x17009804 RID: 38916
		// (get) Token: 0x0603BD49 RID: 245065
		// (set) Token: 0x0603BD4A RID: 245066
		HonamiStoryItemDataBase ItemData { get; set; }

		// Token: 0x17009805 RID: 38917
		// (get) Token: 0x0603BD4B RID: 245067
		// (set) Token: 0x0603BD4C RID: 245068
		EHonamiStoryBackpack BackpackType { get; set; }
	}
}
