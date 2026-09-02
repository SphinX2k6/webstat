using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C98 RID: 23704
	[NullableContext(1)]
	[Nullable(0)]
	public class PickUpItemInfo : IPickUpItemInfo
	{
		// Token: 0x17009826 RID: 38950
		// (get) Token: 0x0603BD92 RID: 245138 RVA: 0x00F2B4C4 File Offset: 0x00F296C4
		// (set) Token: 0x0603BD93 RID: 245139 RVA: 0x00F2B4CC File Offset: 0x00F296CC
		public HonamiStoryItemDataBase ItemData { get; set; }

		// Token: 0x17009827 RID: 38951
		// (get) Token: 0x0603BD94 RID: 245140 RVA: 0x00F2B4D5 File Offset: 0x00F296D5
		// (set) Token: 0x0603BD95 RID: 245141 RVA: 0x00F2B4DD File Offset: 0x00F296DD
		public Entity EntitySelf { get; set; }
	}
}
