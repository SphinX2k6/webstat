using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053D9 RID: 21465
	[NullableContext(2)]
	[Nullable(0)]
	public class TransitionPopupViewParams
	{
		// Token: 0x17008DC6 RID: 36294
		// (get) Token: 0x06036CB4 RID: 224436 RVA: 0x00DE65A7 File Offset: 0x00DE47A7
		// (set) Token: 0x06036CB5 RID: 224437 RVA: 0x00DE65AF File Offset: 0x00DE47AF
		public int? BoardId { get; set; }

		// Token: 0x17008DC7 RID: 36295
		// (get) Token: 0x06036CB6 RID: 224438 RVA: 0x00DE65B8 File Offset: 0x00DE47B8
		// (set) Token: 0x06036CB7 RID: 224439 RVA: 0x00DE65C0 File Offset: 0x00DE47C0
		public bool InPlot { get; set; }

		// Token: 0x17008DC8 RID: 36296
		// (get) Token: 0x06036CB8 RID: 224440 RVA: 0x00DE65C9 File Offset: 0x00DE47C9
		// (set) Token: 0x06036CB9 RID: 224441 RVA: 0x00DE65D1 File Offset: 0x00DE47D1
		public float? Duration { get; set; }

		// Token: 0x17008DC9 RID: 36297
		// (get) Token: 0x06036CBA RID: 224442 RVA: 0x00DE65DA File Offset: 0x00DE47DA
		// (set) Token: 0x06036CBB RID: 224443 RVA: 0x00DE65E2 File Offset: 0x00DE47E2
		public ITransitionPopupStyle Style { get; set; }
	}
}
