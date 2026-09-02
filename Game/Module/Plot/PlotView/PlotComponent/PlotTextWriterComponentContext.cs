using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053E6 RID: 21478
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTextWriterComponentContext
	{
		// Token: 0x17008DEC RID: 36332
		// (get) Token: 0x06036D50 RID: 224592 RVA: 0x00DE7CE5 File Offset: 0x00DE5EE5
		// (set) Token: 0x06036D51 RID: 224593 RVA: 0x00DE7CED File Offset: 0x00DE5EED
		public UUIText TextComponent { get; set; }

		// Token: 0x17008DED RID: 36333
		// (get) Token: 0x06036D52 RID: 224594 RVA: 0x00DE7CF6 File Offset: 0x00DE5EF6
		// (set) Token: 0x06036D53 RID: 224595 RVA: 0x00DE7CFE File Offset: 0x00DE5EFE
		public UUIEffectTextAnimation TextAnimComp { get; set; }

		// Token: 0x17008DEE RID: 36334
		// (get) Token: 0x06036D54 RID: 224596 RVA: 0x00DE7D07 File Offset: 0x00DE5F07
		// (set) Token: 0x06036D55 RID: 224597 RVA: 0x00DE7D0F File Offset: 0x00DE5F0F
		public ULGUIPlayTweenComponent TweenComp { get; set; }

		// Token: 0x17008DEF RID: 36335
		// (get) Token: 0x06036D56 RID: 224598 RVA: 0x00DE7D18 File Offset: 0x00DE5F18
		// (set) Token: 0x06036D57 RID: 224599 RVA: 0x00DE7D20 File Offset: 0x00DE5F20
		public Action OnAnimCompleteDelegate { get; set; }

		// Token: 0x17008DF0 RID: 36336
		// (get) Token: 0x06036D58 RID: 224600 RVA: 0x00DE7D29 File Offset: 0x00DE5F29
		// (set) Token: 0x06036D59 RID: 224601 RVA: 0x00DE7D31 File Offset: 0x00DE5F31
		public Action OnStopDelegate { get; set; }
	}
}
