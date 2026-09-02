using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053E7 RID: 21479
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTextScrollComponentContext
	{
		// Token: 0x17008DF1 RID: 36337
		// (get) Token: 0x06036D5B RID: 224603 RVA: 0x00DE7D42 File Offset: 0x00DE5F42
		// (set) Token: 0x06036D5C RID: 224604 RVA: 0x00DE7D4A File Offset: 0x00DE5F4A
		public UUIText TextComponent { get; set; }

		// Token: 0x17008DF2 RID: 36338
		// (get) Token: 0x06036D5D RID: 224605 RVA: 0x00DE7D53 File Offset: 0x00DE5F53
		// (set) Token: 0x06036D5E RID: 224606 RVA: 0x00DE7D5B File Offset: 0x00DE5F5B
		public UUIScrollViewComponent TextScrollView { get; set; }
	}
}
