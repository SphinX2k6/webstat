using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A6 RID: 22694
	[NullableContext(1)]
	public interface IMarkItemParam
	{
		// Token: 0x17009311 RID: 37649
		// (get) Token: 0x06039A9A RID: 236186
		// (set) Token: 0x06039A9B RID: 236187
		string Txt { get; set; }

		// Token: 0x17009312 RID: 37650
		// (get) Token: 0x06039A9C RID: 236188
		// (set) Token: 0x06039A9D RID: 236189
		int? FontSize { get; set; }

		// Token: 0x17009313 RID: 37651
		// (get) Token: 0x06039A9E RID: 236190
		// (set) Token: 0x06039A9F RID: 236191
		FVector2D? AnchorOffset { get; set; }

		// Token: 0x17009314 RID: 37652
		// (get) Token: 0x06039AA0 RID: 236192
		// (set) Token: 0x06039AA1 RID: 236193
		float? OutlineSize { get; set; }

		// Token: 0x17009315 RID: 37653
		// (get) Token: 0x06039AA2 RID: 236194
		// (set) Token: 0x06039AA3 RID: 236195
		FColor? OutlineColor { get; set; }
	}
}
