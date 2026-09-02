using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E9 RID: 22249
	[NullableContext(1)]
	public interface IUiItemAspectOffsetConfig
	{
		// Token: 0x170090FC RID: 37116
		// (get) Token: 0x06038A09 RID: 231945
		// (set) Token: 0x06038A0A RID: 231946
		UUIItem UiItem { get; set; }

		// Token: 0x170090FD RID: 37117
		// (get) Token: 0x06038A0B RID: 231947
		// (set) Token: 0x06038A0C RID: 231948
		Vector2D OriginalOffset { get; set; }

		// Token: 0x170090FE RID: 37118
		// (get) Token: 0x06038A0D RID: 231949
		// (set) Token: 0x06038A0E RID: 231950
		float OffsetWidthDirection { get; set; }

		// Token: 0x170090FF RID: 37119
		// (get) Token: 0x06038A0F RID: 231951
		// (set) Token: 0x06038A10 RID: 231952
		float OffsetHeightDirection { get; set; }
	}
}
