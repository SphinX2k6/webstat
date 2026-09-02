using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058A7 RID: 22695
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkItemParam : IMarkItemParam
	{
		// Token: 0x17009316 RID: 37654
		// (get) Token: 0x06039AA4 RID: 236196 RVA: 0x00E9F57B File Offset: 0x00E9D77B
		// (set) Token: 0x06039AA5 RID: 236197 RVA: 0x00E9F583 File Offset: 0x00E9D783
		public string Txt { get; set; }

		// Token: 0x17009317 RID: 37655
		// (get) Token: 0x06039AA6 RID: 236198 RVA: 0x00E9F58C File Offset: 0x00E9D78C
		// (set) Token: 0x06039AA7 RID: 236199 RVA: 0x00E9F594 File Offset: 0x00E9D794
		public int? FontSize { get; set; }

		// Token: 0x17009318 RID: 37656
		// (get) Token: 0x06039AA8 RID: 236200 RVA: 0x00E9F59D File Offset: 0x00E9D79D
		// (set) Token: 0x06039AA9 RID: 236201 RVA: 0x00E9F5A5 File Offset: 0x00E9D7A5
		public FVector2D? AnchorOffset { get; set; }

		// Token: 0x17009319 RID: 37657
		// (get) Token: 0x06039AAA RID: 236202 RVA: 0x00E9F5AE File Offset: 0x00E9D7AE
		// (set) Token: 0x06039AAB RID: 236203 RVA: 0x00E9F5B6 File Offset: 0x00E9D7B6
		public float? OutlineSize { get; set; }

		// Token: 0x1700931A RID: 37658
		// (get) Token: 0x06039AAC RID: 236204 RVA: 0x00E9F5BF File Offset: 0x00E9D7BF
		// (set) Token: 0x06039AAD RID: 236205 RVA: 0x00E9F5C7 File Offset: 0x00E9D7C7
		public FColor? OutlineColor { get; set; }
	}
}
