using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C97 RID: 23703
	[NullableContext(1)]
	public interface IPickUpItemInfo
	{
		// Token: 0x17009824 RID: 38948
		// (get) Token: 0x0603BD8E RID: 245134
		// (set) Token: 0x0603BD8F RID: 245135
		HonamiStoryItemDataBase ItemData { get; set; }

		// Token: 0x17009825 RID: 38949
		// (get) Token: 0x0603BD90 RID: 245136
		// (set) Token: 0x0603BD91 RID: 245137
		Entity EntitySelf { get; set; }
	}
}
