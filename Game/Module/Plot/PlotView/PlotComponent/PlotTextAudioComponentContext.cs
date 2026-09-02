using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053E3 RID: 21475
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTextAudioComponentContext
	{
		// Token: 0x17008DE6 RID: 36326
		// (get) Token: 0x06036D41 RID: 224577 RVA: 0x00DE7C67 File Offset: 0x00DE5E67
		// (set) Token: 0x06036D42 RID: 224578 RVA: 0x00DE7C6F File Offset: 0x00DE5E6F
		public Action OnAudioStartDelegate { get; set; }

		// Token: 0x17008DE7 RID: 36327
		// (get) Token: 0x06036D43 RID: 224579 RVA: 0x00DE7C78 File Offset: 0x00DE5E78
		// (set) Token: 0x06036D44 RID: 224580 RVA: 0x00DE7C80 File Offset: 0x00DE5E80
		public Action OnAudioEndDelegate { get; set; }

		// Token: 0x17008DE8 RID: 36328
		// (get) Token: 0x06036D45 RID: 224581 RVA: 0x00DE7C89 File Offset: 0x00DE5E89
		// (set) Token: 0x06036D46 RID: 224582 RVA: 0x00DE7C91 File Offset: 0x00DE5E91
		public Action OnAudioLoadTimeoutDelegate { get; set; }
	}
}
