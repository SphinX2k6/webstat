using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C7A RID: 23674
	[NullableContext(1)]
	public interface IHonamiStoryDragItemHoverInfo
	{
		// Token: 0x170097F0 RID: 38896
		// (get) Token: 0x0603BD1E RID: 245022
		// (set) Token: 0x0603BD1F RID: 245023
		bool IsValid { get; set; }

		// Token: 0x170097F1 RID: 38897
		// (get) Token: 0x0603BD20 RID: 245024
		// (set) Token: 0x0603BD21 RID: 245025
		int StartPosition { get; set; }

		// Token: 0x170097F2 RID: 38898
		// (get) Token: 0x0603BD22 RID: 245026
		// (set) Token: 0x0603BD23 RID: 245027
		int EndPosition { get; set; }

		// Token: 0x170097F3 RID: 38899
		// (get) Token: 0x0603BD24 RID: 245028
		// (set) Token: 0x0603BD25 RID: 245029
		int Height { get; set; }

		// Token: 0x170097F4 RID: 38900
		// (get) Token: 0x0603BD26 RID: 245030
		// (set) Token: 0x0603BD27 RID: 245031
		int Width { get; set; }

		// Token: 0x170097F5 RID: 38901
		// (get) Token: 0x0603BD28 RID: 245032
		// (set) Token: 0x0603BD29 RID: 245033
		List<int> FillPosList { get; set; }
	}
}
