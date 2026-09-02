using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053EC RID: 21484
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotAvgMoveComponentPlayContext : IPlotAvgMoveComponentPlayContext
	{
		// Token: 0x17008DFE RID: 36350
		// (get) Token: 0x06036D79 RID: 224633 RVA: 0x00DE7DE2 File Offset: 0x00DE5FE2
		// (set) Token: 0x06036D7A RID: 224634 RVA: 0x00DE7DEA File Offset: 0x00DE5FEA
		public IPlotAvgCharacterMove AvgCharacter { get; set; }

		// Token: 0x17008DFF RID: 36351
		// (get) Token: 0x06036D7B RID: 224635 RVA: 0x00DE7DF3 File Offset: 0x00DE5FF3
		// (set) Token: 0x06036D7C RID: 224636 RVA: 0x00DE7DFB File Offset: 0x00DE5FFB
		public float StartPosition { get; set; }

		// Token: 0x17008E00 RID: 36352
		// (get) Token: 0x06036D7D RID: 224637 RVA: 0x00DE7E04 File Offset: 0x00DE6004
		// (set) Token: 0x06036D7E RID: 224638 RVA: 0x00DE7E0C File Offset: 0x00DE600C
		public float EndPosition { get; set; }

		// Token: 0x17008E01 RID: 36353
		// (get) Token: 0x06036D7F RID: 224639 RVA: 0x00DE7E15 File Offset: 0x00DE6015
		// (set) Token: 0x06036D80 RID: 224640 RVA: 0x00DE7E1D File Offset: 0x00DE601D
		public LTweenEase Ease { get; set; }

		// Token: 0x17008E02 RID: 36354
		// (get) Token: 0x06036D81 RID: 224641 RVA: 0x00DE7E26 File Offset: 0x00DE6026
		// (set) Token: 0x06036D82 RID: 224642 RVA: 0x00DE7E2E File Offset: 0x00DE602E
		public float Duration { get; set; }
	}
}
