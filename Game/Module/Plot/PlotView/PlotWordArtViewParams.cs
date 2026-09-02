using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053D6 RID: 21462
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotWordArtViewParams
	{
		// Token: 0x17008DC4 RID: 36292
		// (get) Token: 0x06036CA4 RID: 224420 RVA: 0x00DE6073 File Offset: 0x00DE4273
		// (set) Token: 0x06036CA5 RID: 224421 RVA: 0x00DE607B File Offset: 0x00DE427B
		public ITransitionPopupYuanChengArtText Config { get; set; }

		// Token: 0x17008DC5 RID: 36293
		// (get) Token: 0x06036CA6 RID: 224422 RVA: 0x00DE6084 File Offset: 0x00DE4284
		// (set) Token: 0x06036CA7 RID: 224423 RVA: 0x00DE608C File Offset: 0x00DE428C
		public float? Duration { get; set; }
	}
}
