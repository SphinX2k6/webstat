using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C8A RID: 23690
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiStoryItemSellInfo : IHonamiStoryItemSellInfo
	{
		// Token: 0x17009806 RID: 38918
		// (get) Token: 0x0603BD4D RID: 245069 RVA: 0x00F2B376 File Offset: 0x00F29576
		// (set) Token: 0x0603BD4E RID: 245070 RVA: 0x00F2B37E File Offset: 0x00F2957E
		public HonamiStoryItemDataBase ItemData { get; set; }

		// Token: 0x17009807 RID: 38919
		// (get) Token: 0x0603BD4F RID: 245071 RVA: 0x00F2B387 File Offset: 0x00F29587
		// (set) Token: 0x0603BD50 RID: 245072 RVA: 0x00F2B38F File Offset: 0x00F2958F
		public EHonamiStoryBackpack BackpackType { get; set; }
	}
}
