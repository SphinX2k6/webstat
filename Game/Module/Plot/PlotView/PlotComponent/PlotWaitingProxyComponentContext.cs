using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053E9 RID: 21481
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotWaitingProxyComponentContext
	{
		// Token: 0x17008DF6 RID: 36342
		// (get) Token: 0x06036D67 RID: 224615 RVA: 0x00DE7DA7 File Offset: 0x00DE5FA7
		// (set) Token: 0x06036D68 RID: 224616 RVA: 0x00DE7DAF File Offset: 0x00DE5FAF
		public Action OnWaitingStartDelegate { get; set; }

		// Token: 0x17008DF7 RID: 36343
		// (get) Token: 0x06036D69 RID: 224617 RVA: 0x00DE7DB8 File Offset: 0x00DE5FB8
		// (set) Token: 0x06036D6A RID: 224618 RVA: 0x00DE7DC0 File Offset: 0x00DE5FC0
		public Action OnWaitingCompleteDelegate { get; set; }

		// Token: 0x17008DF8 RID: 36344
		// (get) Token: 0x06036D6B RID: 224619 RVA: 0x00DE7DC9 File Offset: 0x00DE5FC9
		// (set) Token: 0x06036D6C RID: 224620 RVA: 0x00DE7DD1 File Offset: 0x00DE5FD1
		public Action OnWaitingCancelDelegate { get; set; }
	}
}
